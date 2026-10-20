using System.Collections.Generic;
using DG.Tweening;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class DEN_Hunter : Denizen
{
	private class Tendril
	{
		public GameObject tendrilObject;

		public DEN_Hunter_Arm armComponent;

		public Vector3 initialVector;

		public bool hasLatched;

		private float latchTime;

		private DEN_Hunter hunter;

		public Vector3 targetPosition;

		private Vector3 relativeTargetPosition;

		private Vector3 targetNormal;

		private Vector3 slowNormal;

		private float swayOffset;

		public void Initialize(DEN_Hunter h)
		{
			hunter = h;
			FindLatchPoint(hunter.transform.forward, 180f, hunter.tendrilMaxLatchDistance);
			initialVector = hunter.transform.InverseTransformVector(tendrilObject.transform.position - hunter.transform.position);
			armComponent = tendrilObject.GetComponent<DEN_Hunter_Arm>();
			tendrilObject.transform.rotation = Quaternion.LookRotation(tendrilObject.transform.position - hunter.transform.position);
			swayOffset = Random.value * 1000f;
			latchTime = Random.value * 10f;
		}

		public void SetTargetPosition(Vector3 pos)
		{
			targetPosition = pos;
			relativeTargetPosition = hunter.transform.InverseTransformPoint(pos);
		}

		public void SetTargetNormal(Vector3 normal)
		{
			targetNormal = normal;
		}

		public void Animate()
		{
			slowNormal = Vector3.Lerp(slowNormal, targetNormal, Time.deltaTime * 2f);
			latchTime += Time.deltaTime;
			if (hasLatched)
			{
				float num = Vector3.Distance(tendrilObject.transform.position, targetPosition);
				Vector3.Lerp(b: new Vector3(1f, 1f, num), a: tendrilObject.transform.localScale, t: Time.deltaTime * 10f);
				if (CL_UIManager.debug)
				{
					CL_DebugView.draw.Arrow(tendrilObject.transform.position, targetPosition, Color.yellow);
				}
				float num2 = num;
				bool flag = Vector3.Dot((targetPosition - hunter.transform.position).normalized, hunter.GetReachVector()) < 0f;
				armComponent.SetTargetPosition(Vector3.Lerp(armComponent.GetTargetPosition(), targetPosition, Time.deltaTime * 6f), slowNormal);
				if ((latchTime > 0.5f && num2 > (flag ? hunter.tendrilMaxBehindDistance : hunter.tendrilMaxLatchDistance)) || latchTime > hunter.tendrilMaxLatchTime)
				{
					ReleaseLatch();
				}
			}
			else
			{
				_ = hunter.tendrilMaxLatchDistance;
				if (Vector3.Dot((targetPosition - hunter.transform.position).normalized, hunter.GetReachVector()) < 0f)
				{
					_ = hunter.tendrilMaxBehindDistance;
				}
				Vector3 zero = Vector3.zero;
				zero.x = (Mathf.PerlinNoise(Time.time * hunter.tendrilRandomSwayFrequency + swayOffset, 0f) - 0.5f) * 2f * hunter.tendrilRandomSwayAmount;
				zero.y = (Mathf.PerlinNoise(0f, Time.time * hunter.tendrilRandomSwayFrequency + swayOffset) - 0.5f) * 2f * hunter.tendrilRandomSwayAmount;
				zero.z = (Mathf.PerlinNoise(Time.time * hunter.tendrilRandomSwayFrequency + swayOffset, Time.time * hunter.tendrilRandomSwayFrequency + swayOffset) - 0.5f) * 2f * hunter.tendrilRandomSwayAmount;
				Vector3 defaultEndPosition = armComponent.GetDefaultEndPosition();
				Vector3 vector = Vector3.Lerp(targetPosition, defaultEndPosition + hunter.GetReachVector() * hunter.maxTendrilRandomOffset, latchTime * 2f);
				armComponent.SetTargetPosition(vector, slowNormal);
				if (CL_UIManager.debug)
				{
					CL_DebugView.draw.Arrow(tendrilObject.transform.position, vector, Vector3.up, 0.2f, Color.cyan);
				}
				if (latchTime > hunter.tendrilLatchWait)
				{
					FindLatchPoint(tendrilObject.transform.forward, 0f, hunter.tendrilMaxLatchDistance);
				}
			}
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Label2D(hunter.transform.position + Vector3.up * 2f, "Tendril Latched: " + hasLatched, Color.cyan);
			}
		}

		public void ReleaseLatch()
		{
			hasLatched = false;
			latchTime = 0f;
			relativeTargetPosition = hunter.transform.InverseTransformVector(targetPosition);
		}

		public void FindLatchPoint(Vector3 dir, float maxAngle, float maxDistance)
		{
			Vector3 vector = Quaternion.Euler(Random.insideUnitSphere * maxAngle) * dir;
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Arrow(tendrilObject.transform.position, tendrilObject.transform.position + vector * maxDistance, Color.green);
			}
			if (Physics.Raycast(tendrilObject.transform.position, vector, out var hitInfo, maxDistance, hunter.tendrilWorldMask))
			{
				SetTargetPosition(hitInfo.point);
				SetTargetNormal(hitInfo.normal);
				hasLatched = true;
				latchTime = 0f;
			}
		}
	}

	private Queue<Vector3> playerTrackPositions;

	private Vector3 lastPlayerTrackPosition;

	public Transform headObject;

	public float healthRegenRate = 0.1f;

	private List<Renderer> bodySegments;

	public float hurtWiggleAmount = 0.1f;

	public float healthyWiggleAmount = 0.05f;

	public Color hurtColor = Color.red;

	public Texture2D corruptionTexture;

	private UT_SegmentTrail segmentTrail;

	private bool active = true;

	public float startSpeed = 1f;

	public float speedMult = 1f;

	private float curSpeedMult = 1f;

	private float curSpeed = 1f;

	public float turnSpeed = 1f;

	public float speedIncreaseRate = 0.1f;

	public float trackPositionDistance = 0.5f;

	public float minimumPhaseDistance = 15f;

	public float lurchAmount = 0.1f;

	public float lurchSpeed = 1f;

	private Rigidbody rigid;

	public float minimumForwardTendrilVelocity = 0.25f;

	public float contactPushForce = 1f;

	private Vector3 contactDir;

	private bool targetVisible;

	public bool ignoreCollisions;

	public float gravityForce;

	public GameObject tendrilAsset;

	public int tendrilCount = 10;

	public float tendrilSphericalOffset = 1f;

	public float tendrilMaxLatchAngle = 30f;

	public float tendrilMaxLatchDistance = 10f;

	public float tendrilMaxBehindDistance = 5f;

	public float tendrilMaxLatchTime = 10f;

	public float tendrilLatchWait = 0.25f;

	public float tendrilRandomSwayAmount = 1f;

	public float tendrilRandomSwayFrequency = 1f;

	public float maxTendrilRandomOffset = 180f;

	public LayerMask tendrilWorldMask;

	public float tendrilPushForce = 10f;

	public float tendrilPushDistanceThreshold = 2f;

	public float reachVectorBlend = 0.5f;

	public float slamMinimumVelocity = 2f;

	public float slamShakeMult = 0.01f;

	public float slamVolumeMult = 0.1f;

	public float slamRecoveryRate = 1f;

	private float slamRecoveryMult = 1f;

	private float freezeTime;

	public float slamVelocityLoss = 0.5f;

	public UnityEvent slamEvent;

	public string barkClipID = "hunter:bark";

	public float barkRate = 10f;

	private float barkTimer;

	public float barkShakeMult = 0.05f;

	public float barkShakeDistance = 15f;

	private bool isPrimary;

	public GameObject screenEffectRoot;

	public List<Renderer> screenEffectRenderers;

	public static float screenEffectAmount;

	private float screenEffectSmooth;

	public float screenEffectDistance = 10f;

	public AnimationCurve screenEffectCurve;

	public ParticleSystem screenEffectParticles;

	public ParticleSystem eyeParticles;

	public float headDamageRadius = 1f;

	public float segmentDamageRadius = 1f;

	public string damageTag = "face";

	public float collisionDamage = 1f;

	public float collisionDamageRate = 0.1f;

	private float damageTime;

	private int collisionCheckOffset;

	private float lastDamageTime;

	public static List<DEN_Hunter> activeHunters = new List<DEN_Hunter>();

	private bool frozen;

	private List<Tendril> tendrils = new List<Tendril>();

	private float stunTime;

	public override void Start()
	{
		base.Start();
		playerTrackPositions = new Queue<Vector3>();
		Shader.SetGlobalTexture("_CORRUPTTEXTURE", corruptionTexture);
		curSpeed = startSpeed;
		if (CL_GameManager.IsHardmode())
		{
			curSpeed *= 1.5f;
		}
		base.transform.parent = WorldLoader.GetWorldLoaderNullParent();
		rigid = GetComponent<Rigidbody>();
		target = ENT_Player.playerObject.transform;
		bodySegments = new List<Renderer>();
		segmentTrail = GetComponentInChildren<UT_SegmentTrail>();
		if (segmentTrail != null)
		{
			foreach (Transform segment in segmentTrail.GetSegments())
			{
				Renderer component = segment.GetComponent<Renderer>();
				if (component != null)
				{
					if (bodySegments == null)
					{
						bodySegments = new List<Renderer>();
					}
					bodySegments.Add(component);
				}
				ENT_Hitbox component2 = segment.gameObject.GetComponent<ENT_Hitbox>();
				if (component2 != null)
				{
					component2.SetGameEntity(this);
				}
			}
		}
		CreateTendrils();
		if (activeHunters == null)
		{
			activeHunters = new List<DEN_Hunter>();
		}
		if (activeHunters.Count == 0)
		{
			isPrimary = true;
			screenEffectAmount = 0f;
			CommandConsole.BuildVariableBool(() => ref active, "hunter-setactive", null);
		}
		if (!activeHunters.Contains(this))
		{
			activeHunters.Add(this);
		}
	}

	private void OnDestroy()
	{
		if (activeHunters.Contains(this))
		{
			activeHunters.Remove(this);
		}
		if (isPrimary)
		{
			screenEffectAmount = 0f;
		}
		if (isPrimary && activeHunters.Count > 0)
		{
			activeHunters[0].active = active;
		}
	}

	public override void Update()
	{
		base.Update();
		if (activeHunters == null || activeHunters.Count <= 0 || activeHunters[0].active)
		{
			TrackPlayerPosition();
			Movement();
			contactDir = Vector3.Lerp(contactDir, Vector3.zero, Time.deltaTime * 2f);
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Cross(base.transform.position, 0.3f, new Color(1f, 0f, 0f, 0.5f));
				CL_DebugView.draw.Label2D(base.transform.position + Vector3.up, "Using F5 to spy is cringe.", 16f, LabelAlignment.Center);
				CL_DebugView.draw.Label2D(base.transform.position + Vector3.up * 2f, "Mood: Pissed Off.", 14f, LabelAlignment.Center);
				CL_DebugView.draw.Label2D(base.transform.position + Vector3.up * -1f, "Speed: " + curSpeed, 14f, LabelAlignment.Center);
			}
			Bark();
			AnimateTendrils();
			AnimateMaterials();
			health += Time.deltaTime * healthRegenRate;
			health = Mathf.Clamp(health, 0f, maxHealth);
			TargetCollisionCheck();
		}
	}

	private void LateUpdate()
	{
		ScreenEffect();
	}

	private void TargetCollisionCheck()
	{
		damageTime -= Time.deltaTime;
		GameEntity player = ENT_Player.GetPlayer();
		if (player == null || damageTime > 0f || player.dead)
		{
			return;
		}
		int num = 3;
		if (CL_UIManager.debug)
		{
			CL_DebugView.draw.WireSphere(base.transform.position, headDamageRadius, new Color(1f, 0f, 0f, 0.6f));
			CL_DebugView.draw.Label2D(base.transform.position + -Vector3.up * 5f, "Damage: " + health + " / " + maxHealth);
		}
		for (int i = 0; i < bodySegments.Count; i++)
		{
			if ((i + collisionCheckOffset) % num == 0)
			{
				float num2 = bodySegments[i].transform.localScale.y * segmentDamageRadius;
				if (CL_UIManager.debug)
				{
					CL_DebugView.draw.WireSphere(bodySegments[i].transform.position, num2, new Color(1f, 0f, 0f, 0.2f));
				}
				if (Vector3.Distance(bodySegments[i].transform.position, player.transform.position) < num2)
				{
					player.Damage(Damageable.DamageInfo.CreateDamageInfo(collisionDamage, damageTag));
					player.AddForce((target.position - bodySegments[i].transform.position).normalized, "denizen");
					damageTime = collisionDamageRate;
					break;
				}
			}
		}
		collisionCheckOffset++;
		if (collisionCheckOffset >= bodySegments.Count)
		{
			collisionCheckOffset = 0;
		}
	}

	private void CreateTendrils()
	{
		for (int i = 0; i < tendrilCount; i++)
		{
			Vector3 position = base.transform.position + Random.onUnitSphere * tendrilSphericalOffset;
			GameObject tendrilObject = Object.Instantiate(tendrilAsset, position, Quaternion.identity, base.transform);
			Tendril tendril = new Tendril();
			tendril.tendrilObject = tendrilObject;
			tendril.Initialize(this);
			tendrils.Add(tendril);
		}
	}

	private void AnimateTendrils()
	{
		foreach (Tendril tendril in tendrils)
		{
			tendril.Animate();
		}
	}

	private void AnimateMaterials()
	{
		for (int i = 0; i < bodySegments.Count; i++)
		{
			Material material = bodySegments[i].material;
			material.SetColor("_Color", Color.Lerp(t: Mathf.Max(health / maxHealth, Mathf.Sin(Time.time * 15f + (float)i * 0.232f)), a: hurtColor, b: Color.white));
			float value = Mathf.Lerp(hurtWiggleAmount, healthyWiggleAmount, health / maxHealth);
			material.SetFloat("_Wiggle", value);
		}
	}

	private float GetCurrentLatchAmount()
	{
		float num = 0f;
		foreach (Tendril tendril in tendrils)
		{
			if (tendril.hasLatched)
			{
				num += 1f;
			}
		}
		return num / (float)tendrils.Count;
	}

	private void Bark()
	{
		barkTimer -= Time.deltaTime;
		if (barkTimer <= 0f)
		{
			clipHandler.PlaySound(barkClipID);
			barkTimer = barkRate + Random.Range((0f - barkRate) * 0.5f, barkRate * 0.5f);
			CL_CameraControl.ShakeAtPosition(base.transform.position, barkShakeMult, barkShakeDistance);
		}
	}

	private Vector3 GetTendrilPushForce()
	{
		Vector3 zero = Vector3.zero;
		foreach (Tendril tendril in tendrils)
		{
			if (tendril.hasLatched)
			{
				Vector3 vector = Vector3.ClampMagnitude(tendril.tendrilObject.transform.position - tendril.targetPosition, tendrilPushDistanceThreshold);
				zero += vector.normalized * (tendrilPushDistanceThreshold - vector.magnitude) / tendrilPushDistanceThreshold * tendrilPushForce;
			}
		}
		return zero;
	}

	private void Movement()
	{
		if (frozen)
		{
			return;
		}
		slamRecoveryMult += Time.deltaTime * slamRecoveryRate;
		slamRecoveryMult = Mathf.Clamp01(slamRecoveryMult);
		float num = ((!(freezeTime > 0f)) ? 1 : 0);
		if (freezeTime > 0f)
		{
			rigid.linearVelocity = Vector3.Lerp(rigid.linearVelocity, Vector3.zero, Time.deltaTime * 0.5f);
			ParticleSystem.MainModule main = eyeParticles.main;
			main.startColor = Color.red;
			freezeTime -= Time.deltaTime;
		}
		else
		{
			ParticleSystem.MainModule main2 = eyeParticles.main;
			main2.startColor = Color.white;
		}
		float buff = ENT_Player.GetPlayer().curBuffs.GetBuff("massResist");
		if (buff > 5f && !HasEffect("fire"))
		{
			AddEffect("fire", 1f);
		}
		if (playerTrackPositions.Count <= 0)
		{
			return;
		}
		float num2 = 1f;
		if (CL_GameManager.IsHardmode())
		{
			num2 = 2f;
		}
		curSpeed += Time.deltaTime * speedIncreaseRate * num2;
		float num3 = curSpeed;
		float buff2 = ENT_Player.GetPlayer().curBuffs.GetBuff("massSpeedMult");
		float buff3 = ENT_Player.GetPlayer().curBuffs.GetBuff("massSlow");
		num3 *= 1f + buff2;
		num3 /= 1f + buff3;
		if (WorldLoader.initialized && WorldLoader.isLoaded && WorldLoader.instance.GetCurrentLevel() != null)
		{
			num3 *= WorldLoader.instance.GetCurrentLevel().GetLevel().hunterSpeedMult;
		}
		if (buff > 1f)
		{
			num3 *= 0.5f;
		}
		Vector3 vector = playerTrackPositions.Peek();
		Vector3 normalized = (vector - base.transform.position).normalized;
		float num4 = Vector3.Distance(target.position, base.transform.position);
		if (num4 < screenEffectDistance)
		{
			SetScreenEffect(1f - num4 / screenEffectDistance);
		}
		if ((num4 > minimumPhaseDistance && !targetVisible) || ignoreCollisions)
		{
			rigid.isKinematic = true;
			float num5 = 1f;
			if (num4 > minimumPhaseDistance * 3.5f)
			{
				num5 = 2f;
			}
			base.transform.position += normalized * Time.deltaTime * num3 * speedMult * slamRecoveryMult * num5 * (health / maxHealth);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(normalized, Vector3.up), Time.deltaTime * turnSpeed);
		}
		else
		{
			rigid.isKinematic = false;
			float num6 = gravityForce * (1f - GetCurrentLatchAmount());
			Vector3 zero = Vector3.zero;
			float num7 = Mathf.Sin(Time.time * 5f) * 0.1f + 1f;
			Vector3 vector2 = new Vector3(Mathf.PerlinNoise(Time.time * lurchSpeed, 0f) - 0.5f, Mathf.PerlinNoise(0f, Time.time * lurchSpeed) - 0.5f, Mathf.PerlinNoise(Time.time * lurchSpeed, Time.time * lurchSpeed) - 0.5f) * lurchAmount;
			zero += vector2;
			zero += normalized * num3 * speedMult * num7 * slamRecoveryMult * num * (health / maxHealth) * Mathf.Max(GetCurrentLatchAmount(), minimumForwardTendrilVelocity) + contactDir * contactPushForce;
			zero += Vector3.down * num6;
			zero += GetTendrilPushForce();
			rigid.AddForce(zero * Time.deltaTime, ForceMode.VelocityChange);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(rigid.linearVelocity.normalized, Vector3.up), Time.deltaTime * turnSpeed * Mathf.Max(num, 0.1f));
		}
		if (Vector3.Distance(base.transform.position, vector) < trackPositionDistance)
		{
			playerTrackPositions.Dequeue();
		}
		if (num4 < 2f)
		{
			ENT_Player.playerObject.Kill(objectType);
		}
	}

	private void TrackPlayerPosition()
	{
		targetVisible = sight.CanSeeTarget(target);
		if (targetVisible)
		{
			playerTrackPositions.Clear();
			playerTrackPositions.Enqueue(target.position);
		}
		if (Vector3.Distance(lastPlayerTrackPosition, ENT_Player.playerObject.transform.position) > trackPositionDistance)
		{
			playerTrackPositions.Enqueue(ENT_Player.playerObject.transform.position);
			lastPlayerTrackPosition = ENT_Player.playerObject.transform.position;
		}
	}

	private void OnCollisionStay(Collision collision)
	{
		contactDir = Vector3.zero;
		ContactPoint[] contacts = collision.contacts;
		foreach (ContactPoint contactPoint in contacts)
		{
			contactDir += contactPoint.normal;
		}
	}

	public Vector3 GetCurrentDesiredMovementVector()
	{
		if (playerTrackPositions.Count > 0)
		{
			curSpeed += Time.deltaTime * speedIncreaseRate;
			return (playerTrackPositions.Peek() - base.transform.position).normalized;
		}
		return rigid.linearVelocity;
	}

	public Vector3 GetReachVector()
	{
		return Vector3.Lerp(rigid.linearVelocity, GetCurrentDesiredMovementVector(), reachVectorBlend);
	}

	internal override void OnCollisionEnter(Collision collision)
	{
		base.OnCollisionEnter(collision);
		if ((collision.gameObject.layer == LayerMask.NameToLayer("World") || collision.gameObject.layer == LayerMask.NameToLayer("Default")) && collision.relativeVelocity.magnitude > slamMinimumVelocity)
		{
			CL_CameraControl.ShakeAtPosition(base.transform.position, slamShakeMult * collision.relativeVelocity.magnitude, 15f);
			clipHandler.PlaySound("hunter:collision", collision.relativeVelocity.magnitude * slamVolumeMult);
			slamRecoveryMult = 0f;
			rigid.linearVelocity *= slamVelocityLoss;
			slamEvent.Invoke();
		}
	}

	private void ScreenEffect()
	{
		if (!isPrimary)
		{
			return;
		}
		screenEffectRoot.transform.position = Camera.main.transform.position;
		screenEffectRoot.transform.rotation = Camera.main.transform.rotation;
		foreach (Renderer screenEffectRenderer in screenEffectRenderers)
		{
			screenEffectRenderer.material.SetFloat("_AlphaMult", screenEffectCurve.Evaluate(screenEffectSmooth));
		}
		screenEffectSmooth = Mathf.Lerp(screenEffectSmooth, screenEffectAmount, Time.deltaTime * 2f);
		if (screenEffectAmount > 0.5f)
		{
			if (!screenEffectParticles.isPlaying)
			{
				screenEffectParticles.Play();
			}
		}
		else if (screenEffectParticles.isPlaying)
		{
			screenEffectParticles.Stop();
		}
		screenEffectAmount = 0f;
	}

	internal static void SetScreenEffect(float f)
	{
		screenEffectAmount = Mathf.Max(f, screenEffectAmount);
	}

	public override bool Damage(Damageable.DamageInfo info)
	{
		if (info.amount > 3f)
		{
			clipHandler.PlaySound("hunter:heavyhit");
		}
		else
		{
			clipHandler.PlaySound("hunter:lighthit");
		}
		info = ProcessDamageInfo(info);
		health -= info.amount;
		if (health <= 0f)
		{
			health = 0f;
			if (Time.time - stunTime > 5f)
			{
				clipHandler.PlaySound("hunter:stun");
				stunTime = Time.time;
			}
		}
		else if (Time.time - lastDamageTime > 8f)
		{
			clipHandler.PlaySound("hunter:hitroar");
			freezeTime = 1.5f;
			DOTween.Complete(headObject);
			headObject.DOPunchScale(Vector3.one * 0.05f, 1f);
			headObject.DOPunchRotation(Random.onUnitSphere * 20f, 1.5f, 5).onComplete = delegate
			{
				CL_CameraControl.Shake(0.2f);
			};
		}
		else
		{
			DOTween.Complete(headObject);
			headObject.DOPunchRotation(Random.onUnitSphere * 12f, 0.5f, 5);
		}
		lastDamageTime = Time.time;
		return false;
	}

	public override void Kill(string type = "", Damageable.DamageInfo info = null)
	{
		base.Kill(type, info);
		Object.Destroy(base.gameObject);
	}

	public void SetFrozen(bool f)
	{
		frozen = f;
		rigid.isKinematic = f;
	}

	public override void AddForce(Vector3 v, string source = "")
	{
		rigid.AddForce(v);
		base.AddForce(v, source);
	}

	public void WipeTrackPositions()
	{
		playerTrackPositions = new Queue<Vector3>();
	}

	public static bool HasActiveHunters()
	{
		if (activeHunters != null && activeHunters.Count > 0)
		{
			return true;
		}
		return false;
	}

	public static void TeleportActiveHunters(Vector3 hunterTarget)
	{
		if (activeHunters == null || activeHunters.Count <= 0)
		{
			return;
		}
		foreach (DEN_Hunter activeHunter in activeHunters)
		{
			activeHunter.transform.position = hunterTarget;
			activeHunter.ResetSegments();
			activeHunter.SetFrozen(f: false);
			activeHunter.WipeTrackPositions();
		}
	}

	public void ResetSegments()
	{
		segmentTrail.ResetHistory();
	}

	public void SetSpeedMult(float s)
	{
		speedMult = s;
	}

	internal static void Despawn()
	{
		foreach (DEN_Hunter activeHunter in activeHunters)
		{
			activeHunter.Kill("", null);
		}
	}

	public override void OffsetEntity(float amount)
	{
		base.OffsetEntity(amount);
		Vector3 vector = Vector3.up * amount;
		base.transform.position += Vector3.up * amount;
		for (int i = 0; i < bodySegments.Count; i++)
		{
			Renderer renderer = bodySegments[i];
			if (renderer != null)
			{
				renderer.transform.position += vector;
			}
		}
		Queue<Vector3> queue = playerTrackPositions;
		playerTrackPositions = new Queue<Vector3>(queue.Count);
		Vector3 result;
		while (queue.TryDequeue(out result))
		{
			result += vector;
			playerTrackPositions.Enqueue(result);
		}
		lastPlayerTrackPosition += vector;
		for (int j = 0; j < tendrils.Count; j++)
		{
			if (tendrils[j].tendrilObject != null)
			{
				tendrils[j].tendrilObject.transform.position += vector;
			}
		}
	}
}
