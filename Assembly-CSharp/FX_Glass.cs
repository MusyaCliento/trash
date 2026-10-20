using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FX_Glass : MonoBehaviour, Damageable
{
	public enum DamagePropagation
	{
		Default = 0,
		Cascade = 1,
		Exact = 2
	}

	private struct DamageQueueEntry
	{
		public int region;

		public float timeout;

		public float extra;

		public Vector3 velocity;
	}

	public FX_GlassShared shared;

	private static int shatterRegionId;

	private uint[] shatteredRegionsStaging;

	private bool shatteredRegionsStagingDirty;

	private ComputeBuffer shatteredRegions;

	private bool glassDebug;

	private int glassDebugConnections = -1;

	private bool glassShatterToggle;

	public float health = 1f;

	public float maxHealth = 1f;

	public bool allowDamageAccumulation = true;

	public float shatterMult = 1f;

	public float propagationStartDelay = 0.2f;

	public float propagationSpeedLinear = 0.04f;

	public float propagationMinSpeed = 0.04f;

	public DamagePropagation propagationKind;

	public float minimumNeighborFactor = 0.8f;

	public float weightAboveMult = 2f;

	private Queue<DamageQueueEntry> damageQueue = new Queue<DamageQueueEntry>();

	public AudioSource audioSource;

	public List<AudioClip> breakAudioClips;

	public float breakSoundFrequency = 0.2f;

	public string breakParticleEffectID;

	public float minimumCollisionShatterVelocityAmount = 2f;

	public float shatterVelocityMultiplier = 1f;

	public float shatterProjectileVelocityMultiplier = 10f;

	public bool becomePierceableAfterShatter = true;

	public AnimationCurve shatterHealthEffectCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

	private Material material;

	public UnityEvent shatterEvent;

	public LayerMask entityLayerMask;

	private bool hasShattered;

	private ObjectTagger tagger;

	private float lastShatterSoundTime;

	private void Awake()
	{
		material = GetComponent<Renderer>().material;
		shared.Initialize();
		shatteredRegionsStaging = new uint[16];
		shatteredRegions = new ComputeBuffer(16, 4);
		shatteredRegions.name = $"Shatter region {shatterRegionId++}";
		shatteredRegions.SetData(shatteredRegionsStaging);
		CommandConsole.BuildVariableBool(() => ref glassDebug, "glass_debug", "show glass debug info");
		CommandConsole.BuildVariableInt(() => ref glassDebugConnections, "glass_debug_connections", "show connections from given region");
		CommandConsole.BuildCommand("glass_region_toggle", ShatterRegionCommand);
		CommandConsole.BuildVariableBool(() => ref glassShatterToggle, "glass_shatter", "toggle shattered state of glass").Execute(delegate
		{
			GlassSetAll(glassShatterToggle);
		});
		tagger = GetComponent<ObjectTagger>();
	}

	private int WorldPosToRegion(Vector3 pos)
	{
		Vector3 vector = base.transform.worldToLocalMatrix.MultiplyPoint(pos);
		Vector2 normPos = new Vector2(vector.x, vector.y);
		for (int i = 0; i < 2; i++)
		{
			normPos[i] = (normPos[i] * 2f + 1f) / 2f;
		}
		int result = 0;
		if (normPos.x >= 0f && normPos.x < 1f && normPos.y >= 0f && normPos.y < 1f)
		{
			result = shared.NormPosToRegion(normPos);
		}
		return result;
	}

	private Vector3 RegionToWorldPos(int from)
	{
		_ = shared.shatterRegions[from];
		Vector2 centerPosition = shared.shatterRegions[from].centerPosition;
		for (int i = 0; i < 2; i++)
		{
			centerPosition[i] = (centerPosition[i] * 2f - 1f) * 0.5f;
		}
		return base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(centerPosition.x, centerPosition.y, 0f));
	}

	private void ShatterRegionCommand(string[] args)
	{
		byte result = 0;
		byte result2 = 0;
		if (args.Length != 0 && byte.TryParse(args[0], out result))
		{
			result2 = (byte)(result + 1);
		}
		if (args.Length > 1)
		{
			byte.TryParse(args[1], out result2);
		}
		for (byte b = result; b < result2; b++)
		{
			ShatterBitSet(b, !ShatterBitGet(b));
		}
	}

	private void Update()
	{
		float time = Time.time;
		int num = 0;
		DamageQueueEntry result;
		while (damageQueue.TryPeek(out result) && result.timeout <= time && num < 1000)
		{
			num++;
			damageQueue.Dequeue();
			if (ShatterBitSet(result.region, newValue: true))
			{
				continue;
			}
			PlayBreakEffects(result);
			Span<byte> span = shared.RegionNeighbors(result.region);
			float num2 = Mathf.Max(result.extra - propagationSpeedLinear, propagationMinSpeed);
			for (int i = 0; i < span.Length; i++)
			{
				if (ShatterBitGet(span[i]))
				{
					continue;
				}
				bool flag = false;
				if (propagationKind == DamagePropagation.Default)
				{
					Span<byte> span2 = shared.RegionNeighbors(span[i]);
					float num3 = (float)span2.Length * minimumNeighborFactor;
					Vector2 centerPosition = shared.shatterRegions[span[i]].centerPosition;
					float num4 = 0f;
					for (int j = 0; j < span2.Length; j++)
					{
						float num5 = 1f;
						Vector2 centerPosition2 = shared.shatterRegions[span2[j]].centerPosition;
						bool num6 = centerPosition.y > centerPosition2.y;
						bool flag2 = ShatterBitGet(span2[j]);
						if (num6)
						{
							num5 *= weightAboveMult;
						}
						if (!flag2)
						{
							num4 += num5;
						}
					}
					if (num4 < num3)
					{
						flag = true;
					}
				}
				if (propagationKind == DamagePropagation.Cascade)
				{
					flag = true;
				}
				if (flag)
				{
					damageQueue.Enqueue(new DamageQueueEntry
					{
						region = span[i],
						timeout = time + num2,
						extra = num2,
						velocity = result.velocity * 0.5f
					});
				}
			}
		}
		if (glassDebug)
		{
			string text = "";
			for (int k = 0; k < shatteredRegionsStaging.Length; k++)
			{
				text += $"{shatteredRegionsStaging[k]:X}, ";
			}
			CL_DebugView.draw.Label2D(base.transform.position, text);
		}
		if (glassDebugConnections != -1)
		{
			int num7 = glassDebugConnections;
			FX_GlassShared.Region region = shared.shatterRegions[num7];
			Vector2 centerPosition3 = shared.shatterRegions[num7].centerPosition;
			for (int l = 0; l < 2; l++)
			{
				centerPosition3[l] = (centerPosition3[l] * 2f - 1f) * 0.5f;
			}
			Vector3 vector = base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(centerPosition3.x, centerPosition3.y, 0f));
			for (int m = region.shatterLinksBeg; m < region.shatterLinksEnd; m++)
			{
				CL_DebugView.draw.PushColor(DarkMachineCrayons.Arbitrary(m));
				int num8 = shared.shatterLinks[m];
				Vector2 centerPosition4 = shared.shatterRegions[num8].centerPosition;
				for (int n = 0; n < 2; n++)
				{
					centerPosition4[n] = (centerPosition4[n] * 2f - 1f) * 0.5f;
				}
				Vector3 vector2 = base.transform.localToWorldMatrix.MultiplyPoint(new Vector3(centerPosition4.x, centerPosition4.y, 0f));
				CL_DebugView.draw.Arrow(vector, vector2);
				CL_DebugView.draw.PopColor();
			}
		}
		if (shatteredRegionsStagingDirty)
		{
			shatteredRegions.SetData(shatteredRegionsStaging);
			shatteredRegionsStagingDirty = false;
		}
		material.SetBuffer("_ShatteredRegions", shatteredRegions);
		material.SetTexture("_RegionMap", shared.regionMap);
		material.SetFloat("_ShatterMult", shatterHealthEffectCurve.Evaluate(1f - health / maxHealth));
		if (!hasShattered && health <= 0f)
		{
			hasShattered = true;
			OnShatter();
		}
		Collider[] array = Physics.OverlapBox(base.transform.position, new Vector3(base.transform.localScale.x, base.transform.localScale.y, 0.5f), base.transform.rotation, entityLayerMask);
		if (glassDebug)
		{
			CL_DebugView.draw.WireBox(base.transform.position, base.transform.rotation, new Vector3(base.transform.localScale.x, base.transform.localScale.y, 0.5f));
		}
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (!collider.TryGetComponent<GameEntity>(out var component))
			{
				continue;
			}
			if (!hasShattered)
			{
				if (component != ENT_Player.GetPlayer())
				{
					continue;
				}
				float f = component.GetTrueVelocity().magnitude * Vector3.Dot(component.GetTrueVelocity().normalized, base.transform.forward);
				if (Mathf.Abs(f) > minimumCollisionShatterVelocityAmount)
				{
					Damageable.DamageInfo damageInfo = Damageable.DamageInfo.CreateDamageInfo(component.GetRadius() * 2f);
					damageInfo.position = collider.transform.position;
					damageInfo.force = component.GetTrueVelocity() * shatterVelocityMultiplier;
					Damage(damageInfo);
					if (health <= 0f)
					{
						component.AddForce(base.transform.forward * (0f - Mathf.Sign(f)) * 0.4f);
					}
				}
			}
			else
			{
				if (glassDebug)
				{
					CL_DebugView.draw.WireSphere(collider.transform.position, component.GetRadius(), Color.red);
				}
				Damageable.DamageInfo damageInfo2 = Damageable.DamageInfo.CreateDamageInfo(component.GetRadius() * 2f);
				damageInfo2.position = collider.transform.position;
				damageInfo2.force = component.GetTrueVelocity() * shatterVelocityMultiplier;
				Damage(damageInfo2);
				damageInfo2.position = collider.transform.position + component.GetRadius() * Vector3.up;
				Damage(damageInfo2);
				damageInfo2.position = collider.transform.position + component.GetRadius() * -Vector3.up;
				Damage(damageInfo2);
			}
		}
	}

	private void OnShatter()
	{
		shatterEvent.Invoke();
		if (becomePierceableAfterShatter)
		{
			tagger.AddTag("Pierceable");
		}
		if (TryGetComponent<UT_SoftParentTarget>(out var component))
		{
			component.ClearChildren();
		}
	}

	public int ShatteredGlassCount()
	{
		int num = 0;
		for (int i = 0; i < 8; i++)
		{
			uint n = shatteredRegionsStaging[i];
			num += DarkMachineFunctions.Count1BitsFast(n);
		}
		return num;
	}

	public void GlassSetAll(bool restore)
	{
		for (int i = 1; i < shared.shatterRegions.Length; i++)
		{
			if ((shared.shatterRegions[i].flags & FX_GlassShared.RegionFlags.IsOnEdge) == 0)
			{
				ShatterBitSet(i, restore);
			}
		}
	}

	private bool ShatterBitGet(int index)
	{
		int num = index & 0x1F;
		int num2 = index >> 5;
		return (shatteredRegionsStaging[num2] & (uint)(1 << num)) != 0;
	}

	private bool ShatterBitSet(int index, bool newValue)
	{
		if ((index & -257) == 0)
		{
			return false;
		}
		int num = index & 0x1F;
		int num2 = index >> 5;
		bool flag = (shatteredRegionsStaging[num2] & (1 << num)) != 0;
		if (newValue)
		{
			shatteredRegionsStaging[num2] |= (uint)(1 << num);
		}
		else
		{
			shatteredRegionsStaging[num2] &= (uint)(~(1 << num));
		}
		shatteredRegionsStagingDirty |= flag != newValue;
		return flag;
	}

	private void OnDestroy()
	{
		if (shatteredRegions != null)
		{
			shatteredRegions.Dispose();
			shatteredRegions = null;
		}
	}

	public bool Damage(Damageable.DamageInfo info)
	{
		int num = WorldPosToRegion(info.position);
		if (info.HasTag("projectile"))
		{
			info.force = info.direction.normalized * shatterProjectileVelocityMultiplier;
		}
		if (info.HasTag("glass-pierce"))
		{
			info.amount = 1f;
		}
		if (info.HasTag("glass-shatter"))
		{
			health = 0f;
		}
		if (num != 0)
		{
			ApplyDamageToRegion(num, info.amount, info.force);
		}
		if (health <= 0f)
		{
			return true;
		}
		return false;
	}

	private void ApplyDamageToRegion(int region, float damage, Vector3 velocity = default(Vector3))
	{
		if ((ShatterBitSet(region + 256, newValue: true) && !allowDamageAccumulation && health != 0f) || region == 0)
		{
			return;
		}
		health = Mathf.Max(health - damage, 0f);
		bool flag = ShatterBitGet(region);
		if (health != 0f || flag)
		{
			return;
		}
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		HashSet<int> hashSet = new HashSet<int>();
		list.Add(region);
		int num = Mathf.RoundToInt(damage * shatterMult) - 1;
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < list.Count; j++)
			{
				Span<byte> span = shared.RegionNeighbors(list[j]);
				for (int k = 0; k < span.Length; k++)
				{
					if (!ShatterBitGet(span[k]) && hashSet.Add(span[k]))
					{
						list2.Add(span[k]);
					}
				}
			}
			list.Clear();
			List<int> list3 = list2;
			List<int> list4 = list;
			list = list3;
			list2 = list4;
		}
		hashSet.Add(region);
		float time = Time.time;
		foreach (int item in hashSet)
		{
			damageQueue.Enqueue(new DamageQueueEntry
			{
				region = item,
				timeout = time,
				extra = propagationStartDelay,
				velocity = velocity
			});
		}
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	private void PlayBreakEffects(DamageQueueEntry info)
	{
		Vector3 vector = RegionToWorldPos(info.region);
		if (audioSource != null && Time.time > lastShatterSoundTime + breakSoundFrequency)
		{
			lastShatterSoundTime = Time.time;
			AudioManager.PlaySound(breakAudioClips[UnityEngine.Random.Range(0, breakAudioClips.Count)], vector, 0.8f);
		}
		FXManager.PlayParticleWithRadius(breakParticleEffectID, vector, 0.1f, 10, info.velocity);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.relativeVelocity.magnitude > minimumCollisionShatterVelocityAmount)
		{
			Damageable.DamageInfo damageInfo = Damageable.DamageInfo.CreateDamageInfo(collision.relativeVelocity.magnitude);
			damageInfo.position = collision.contacts[0].point;
			damageInfo.force = collision.relativeVelocity * shatterVelocityMultiplier;
			Damage(damageInfo);
		}
	}
}
