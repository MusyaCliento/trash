using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(UT_AudioClipHandler))]
public class DEN_Barnacle : Denizen, AIGameEntity.Grappler
{
	public enum AudioState
	{
		idle = 0,
		pulling = 1,
		eating = 2
	}

	public Transform geo;

	public Animator animator;

	[SerializeReference]
	public Barnacle_Tongue_Interface_Module tongueInterface;

	public Grappler.GrappleInfo grappleInfo;

	public float damage = 1f;

	public float attackRate = 0.5f;

	public float attackDistance = 2f;

	public bool dropOnDamage;

	private float attackTime;

	private float vomitTimer;

	public List<string> grabTags = new List<string> { "Player", "Prop" };

	public List<string> ignoreTags = new List<string> { "BarnacleIgnore" };

	public List<string> vomitTags = new List<string> { "BarnacleBad" };

	public bool usePrepareTongueAnimation;

	private bool hasVomited = true;

	public ParticleSystem vomitSystem;

	public ParticleSystem spikeSystem;

	private Quaternion startRotation;

	internal bool eating;

	public LayerMask polypMask;

	public bool spawnPolyps = true;

	public int polypCount = 5;

	public List<GameObject> polyps;

	public UnityEvent onGrabEvent;

	public bool canReachAutomatically = true;

	private AudioState audioState;

	public void SetHasVomited(bool b)
	{
		hasVomited = b;
	}

	public override void Start()
	{
		base.Start();
		clipHandler = GetComponent<UT_AudioClipHandler>();
		tongueInterface.Initialize(this);
		startRotation = geo.localRotation;
		if (spawnPolyps)
		{
			SpawnPolyps(base.transform.position, base.transform.forward, polypCount, polypMask, polyps, base.transform);
		}
	}

	private void LateUpdate()
	{
		tongueInterface.Update();
		HurtHeld();
		if (vomitTimer > 0f && !hasVomited)
		{
			float num = 20f;
			Vector3 vector = new Vector3(Mathf.PerlinNoise(Time.time * num, geo.position.y) - 0.5f, Mathf.PerlinNoise((0f - Time.time) * num, geo.position.x) - 0.5f, Mathf.PerlinNoise(Time.time * num, geo.position.z) - 0.5f);
			geo.localRotation = startRotation * Quaternion.Euler(vector * 5f);
			vomitTimer -= Time.deltaTime;
		}
		if (vomitTimer <= 0f && !hasVomited)
		{
			Vomit();
		}
		geo.localRotation = Quaternion.Lerp(geo.localRotation, startRotation, Time.deltaTime * 3f);
		if (dead)
		{
			return;
		}
		if (eating)
		{
			if (audioState != AudioState.eating)
			{
				clipHandler.StopSound("barnacle:pull-target");
				clipHandler.StopSound("barnacle:loop-idle");
			}
			audioState = AudioState.eating;
			clipHandler.FadeIn("barnacle:bite", Time.deltaTime * 15f);
			if (spikeSystem != null && !spikeSystem.isPlaying)
			{
				spikeSystem.Play();
			}
		}
		else if (IsPulling())
		{
			if (audioState != AudioState.pulling)
			{
				clipHandler.StopSound("barnacle:bite");
				clipHandler.StopSound("barnacle:loop-idle");
			}
			audioState = AudioState.pulling;
			clipHandler.FadeIn("barnacle:pull-target", Time.deltaTime * 15f);
		}
		else
		{
			audioState = AudioState.idle;
			clipHandler.FadeSound("barnacle:bite", 0f, Time.deltaTime * 15f);
			clipHandler.FadeSound("barnacle:pull-target", 0f, Time.deltaTime * 15f);
			clipHandler.FadeIn("barnacle:loop-idle", Time.deltaTime * 15f);
			if (spikeSystem != null && spikeSystem.isPlaying)
			{
				spikeSystem.Stop();
			}
		}
	}

	public override void Kill(string type = "", Damageable.DamageInfo damageInfo = null)
	{
		if (spikeSystem != null && spikeSystem.isPlaying)
		{
			spikeSystem.Stop();
		}
		if (!dead)
		{
			base.Kill(type, damageInfo);
			clipHandler.StopSound("barnacle:loop-idle");
			tongueInterface.Kill();
			clipHandler.PlaySound("barnacle:die");
			if (animator != null)
			{
				animator.SetBool("dead", value: true);
			}
		}
	}

	public override bool Damage(Damageable.DamageInfo info)
	{
		if (!damageable)
		{
			return false;
		}
		if (dead)
		{
			return false;
		}
		clipHandler.PlaySound("barnacle:hurt");
		if (animator != null)
		{
			animator.SetTrigger("hurt");
		}
		if (dropOnDamage)
		{
			ReleaseGrapple();
		}
		return base.Damage(info);
	}

	public void ReachTongues(Transform target)
	{
		tongueInterface.ReachTongues(target);
	}

	public virtual void PrepareTongue()
	{
		if (usePrepareTongueAnimation)
		{
			animator.SetTrigger("prime");
			clipHandler.PlaySound("barnacle:prime");
		}
	}

	public virtual void ShootTongue()
	{
		if (usePrepareTongueAnimation)
		{
			animator.SetTrigger("fire");
			clipHandler.PlaySound("barnacle:reach");
		}
	}

	public void HurtHeld()
	{
		attackTime -= Time.deltaTime;
		if (!(attackTime > 0f))
		{
			eating = false;
			attackTime = attackRate;
			tongueInterface.HurtHeld();
		}
	}

	public void Vomit()
	{
		if (vomitSystem != null)
		{
			vomitSystem.Play();
		}
		hasVomited = true;
		vomitTimer = 1f;
		clipHandler.PlaySound("barnacle:burp");
	}

	private bool IsPulling()
	{
		return tongueInterface.IsPulling();
	}

	public void ReleaseGrapple()
	{
		try
		{
			tongueInterface.ReleaseGrapple();
		}
		catch (Exception message)
		{
			Debug.LogError("Denizen: Barnacle - Release Grapple Failed. Continuing.");
			Debug.LogError(message);
		}
	}

	public override void OffsetEntity(float amount)
	{
		base.OffsetEntity(amount);
		tongueInterface.OffsetEntity(amount);
	}

	public static void SpawnPolyps(Vector3 origin, Vector3 forward, int count, LayerMask hitMask, List<GameObject> polyps, Transform transform)
	{
		Vector3 origin2 = origin + forward * 0.5f;
		for (int i = 0; i < count; i++)
		{
			for (int j = 0; j < 10; j++)
			{
				if (Physics.Raycast(origin2, -forward * 0.8f + UnityEngine.Random.onUnitSphere, out var hitInfo, 4f, hitMask))
				{
					UnityEngine.Object.Instantiate(polyps[UnityEngine.Random.Range(0, polyps.Count)], hitInfo.point, Quaternion.LookRotation(hitInfo.normal), transform);
					break;
				}
			}
		}
	}

	public void OnGrab()
	{
		onGrabEvent.Invoke();
	}

	public Grappler.GrappleInfo GetGrappleInfo()
	{
		return grappleInfo;
	}
}
