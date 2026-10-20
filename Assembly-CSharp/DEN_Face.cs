using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DarkMachine.AI;
using Drawing;
using UnityEngine;

public class DEN_Face : Denizen
{
	public DenizenMovement_SteeringVehicle movementModule;

	public bool active = true;

	public float baseVelocityMult = 0.6f;

	public float aggression = 1f;

	public float aggressionIncreaseRate = 0.002f;

	public float aggressionRandom = 0.1f;

	public float rubberbandMult = 1f;

	public AIC_Face_Stalk stalkState;

	public AIC_Face_Hunt huntState;

	public AIC_Face_Block blockState;

	public AIC_Face_Dive diveState;

	public List<Transform> segmentPrefab;

	public int initialSegments = 8;

	public float segmentSpacing = 0.35f;

	public float segmentGap = 0.35f;

	public float segmentRotationOffset = 115f;

	private List<Transform> segments = new List<Transform>();

	private List<Vector3> positionHistory = new List<Vector3>();

	private Vector3 lastPos;

	public AnimationCurve bodyScaleCurve;

	public float headDamageRadius = 1f;

	public float segmentDamageRadius = 1f;

	public string damageTag = "face";

	public float collisionDamage = 1f;

	public float collisionDamageRate = 0.1f;

	private float damageTime;

	private Transform parent;

	private Transform bodyRoot;

	private Vector3 startPos;

	private GameEntity targetEntity;

	private int collisionCheckOffset;

	private float headDistance = 100f;

	internal bool avoidPlayer;

	public ParticleSystem residueSystem;

	public LayerMask residueMask;

	public float residueRadius = 2f;

	public Texture2D corruptionTexture;

	public Animator animator;

	public float animationBlendDistance = 100f;

	public AnimationCurve animationBlendCurve;

	public AudioSource fuseAudio;

	private bool isPrimary;

	public GameObject screenEffectRoot;

	public Material screenEffectMaterial;

	public static float screenEffectAmount;

	private float screenEffectSmooth;

	public float screenEffectDistance = 10f;

	public AnimationCurve screenEffectCurve;

	public ParticleSystem screenEffectParticles;

	private Steering.SteeringEntity steeringEntity;

	public Renderer faceMesh;

	private float updateSpeedMult = 1f;

	private float commandSpeedMult = 1f;

	private float curDamage;

	private Coroutine damageHitCouroutine;

	public static List<DEN_Face> faceInstances;

	public override void Start()
	{
		base.Start();
		aggression += (Random.value - 0.5f) * aggressionRandom;
		SetTarget(ENT_Player.playerObject.transform);
		aiStates = new List<AIStateComponent> { stalkState, huntState, blockState, diveState };
		foreach (AIStateComponent aiState in aiStates)
		{
			aiState.Initialize(this, stateVariables);
		}
		Shader.SetGlobalTexture("_CORRUPTTEXTURE", corruptionTexture);
		parent = new GameObject("DEN_Face_Root").transform;
		parent.parent = WorldLoader.GetWorldLoaderNullParent();
		parent.transform.position = base.transform.position;
		base.transform.parent = parent;
		GameObject gameObject = new GameObject("Face_BodySegments");
		gameObject.transform.position = parent.position;
		gameObject.transform.parent = parent;
		bodyRoot = gameObject.transform;
		segments = new List<Transform>();
		for (int i = 0; i < initialSegments; i++)
		{
			Grow();
		}
		movementModule.Initialize(this);
		movementModule.Start();
		startPos = base.transform.position;
		if (CL_GameManager.GetBaseGamemode().HasTag("endless"))
		{
			if (CL_GameManager.IsIronKnuckle())
			{
				aggression = Mathf.Max((CL_GameManager.GetGametime() - 600f) / 2200f, aggression);
				aggression = Mathf.Max(CL_GameManager.GetPlayerTravelDistance() / 6000f, aggression);
			}
			else
			{
				aggression = Mathf.Max((CL_GameManager.GetGametime() - 600f) / 1800f, aggression);
				aggression = Mathf.Max(CL_GameManager.GetPlayerTravelDistance() / 4000f, aggression);
			}
			if (CL_GameManager.GetPlayerTravelDistance() > 10000f)
			{
				_ = CL_GameManager.noTarget;
			}
		}
		if (CL_GameManager.IsHardmode())
		{
			aggression *= 1.6f;
		}
		ChangeState("stalk");
	}

	public override void OnEnable()
	{
		base.OnEnable();
		AddFaceInstance(this);
		if (!isPrimary)
		{
			screenEffectRoot.gameObject.SetActive(value: false);
		}
	}

	public override void OnDisable()
	{
		base.OnDisable();
		RemoveFaceInstance(this);
	}

	public override void OffsetEntity(float amount)
	{
		base.OffsetEntity(amount);
		if (base.transform.parent != null)
		{
			base.transform.parent.position += Vector3.up * amount;
		}
		for (int i = 0; i < positionHistory.Count; i++)
		{
			positionHistory[i] += Vector3.up * amount;
		}
	}

	public override void Update()
	{
		base.Update();
		if (!active)
		{
			return;
		}
		currentState.Execute(this);
		steeringEntity?.SetPosition(base.transform.position);
		float num = 1f * aggression * baseVelocityMult * commandSpeedMult;
		num = Mathf.Max(num * (headDistance * 0.07f * rubberbandMult), num) * updateSpeedMult;
		float buff = ENT_Player.GetPlayer().curBuffs.GetBuff("massResist");
		float buff2 = ENT_Player.GetPlayer().curBuffs.GetBuff("massSpeedMult");
		float buff3 = ENT_Player.GetPlayer().curBuffs.GetBuff("massSlow");
		if (buff > 5f && !HasEffect("fire"))
		{
			AddEffect("fire", 1f);
		}
		if (buff > 1f)
		{
			num *= 0.5f;
		}
		num *= 1f + buff2;
		num /= 1f + buff3;
		if (headDistance > 50f)
		{
			num *= 2f;
			if (headDistance > 100f)
			{
				aggression += Time.deltaTime * aggressionIncreaseRate * 3f;
			}
			else
			{
				aggression += Time.deltaTime * aggressionIncreaseRate;
			}
		}
		else
		{
			aggression += Time.deltaTime * aggressionIncreaseRate;
		}
		if (CL_GameManager.IsHardmode())
		{
			aggression += Time.deltaTime * aggressionIncreaseRate;
		}
		if (WorldLoader.initialized && WorldLoader.isLoaded && WorldLoader.instance.GetCurrentLevel() != null)
		{
			num *= WorldLoader.instance.GetCurrentLevel().GetLevel().massSpeedMult;
			if (WorldLoader.instance.GetCurrentLevel().GetLevel().subRegion != null)
			{
				num *= WorldLoader.instance.GetCurrentLevel().GetLevel().subRegion.massSpeedMult;
			}
		}
		if (!isPrimary)
		{
			num *= 0.8f;
		}
		movementModule.velocityMult = num;
		movementModule.targetPosition = GetTargetPosition();
		movementModule.currentPosition = base.transform.position;
		movementModule.Update();
		base.transform.rotation = Quaternion.LookRotation(movementModule.GetVelocity());
		AnimateSegments();
		TargetCollisionCheck();
		bool value = Vector3.Angle(target.position - base.transform.position, base.transform.forward) < 30f && headDistance < 15f;
		animator.SetBool("Biting", value);
		animator.SetFloat("DistanceBlend", animationBlendCurve.Evaluate(headDistance / animationBlendDistance));
		updateSpeedMult = 1f;
		Color b = Color.Lerp(Color.black, Color.red, Mathf.Sin(Time.time * (curDamage / maxHealth) * 6f) * 0.5f + 0.5f);
		faceMesh.material.SetColor("_EmissionColor", Color.Lerp(Color.white, b, curDamage / (maxHealth / 2f)));
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		UpdateSegments();
	}

	private void LateUpdate()
	{
		if (!isPrimary)
		{
			return;
		}
		screenEffectRoot.transform.position = Camera.main.transform.position;
		screenEffectRoot.transform.rotation = Camera.main.transform.rotation;
		screenEffectMaterial.SetFloat("_AlphaMult", screenEffectCurve.Evaluate(screenEffectSmooth));
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

	private void AnimateSegments()
	{
		float a = Time.fixedDeltaTime * segmentGap;
		int num = Mathf.RoundToInt(segmentSpacing / Mathf.Max(a, 0.0001f));
		for (int i = 0; i < initialSegments; i++)
		{
			int num2 = i * num;
			if (num2 < positionHistory.Count)
			{
				Vector3 vector = positionHistory[num2];
				Transform transform = segments[i];
				transform.position = Vector3.Lerp(transform.position, vector, Time.deltaTime * 5f * movementModule.velocityMult);
				transform.localScale = Vector3.one * bodyScaleCurve.Evaluate((float)i / (float)initialSegments);
				Vector3 forward = vector - transform.position;
				Quaternion quaternion2 = Quaternion.Euler((Vector3.right * Mathf.Sin((float)i * segmentRotationOffset) + Vector3.up * Mathf.Cos((float)i * segmentRotationOffset)) * 360f);
				if (forward.sqrMagnitude > 0.0001f)
				{
					transform.rotation = Quaternion.LookRotation(forward, Vector3.up) * quaternion2;
				}
				continue;
			}
			break;
		}
	}

	private void UpdateSegments()
	{
		float a = Time.fixedDeltaTime * segmentGap;
		int num = Mathf.RoundToInt(segmentSpacing / Mathf.Max(a, 0.0001f));
		if (Vector3.Distance(base.transform.position, lastPos) > segmentSpacing)
		{
			positionHistory.Insert(0, base.transform.position);
			lastPos = base.transform.position;
		}
		int num2 = initialSegments * num + 1;
		if (positionHistory.Count > num2)
		{
			positionHistory.RemoveRange(num2, positionHistory.Count - num2);
		}
	}

	public void ResetFace(string[] args)
	{
	}

	public void Grow()
	{
		Transform transform;
		if (segments.Count > 0)
		{
			List<Transform> list = segments;
			transform = list[list.Count - 1];
		}
		else
		{
			transform = base.transform;
		}
		Transform item = Object.Instantiate(segmentPrefab[Random.Range(0, segmentPrefab.Count)], transform.position, transform.rotation, bodyRoot);
		segments.Add(item);
	}

	public new void SetTarget(Transform t)
	{
		target = t;
		targetEntity = target.GetComponent<GameEntity>();
	}

	private void TargetCollisionCheck()
	{
		damageTime -= Time.deltaTime;
		if (targetEntity == null || damageTime > 0f || targetEntity.dead)
		{
			return;
		}
		int num = 3;
		float num2 = 1f;
		if (aggression > 6f)
		{
			num2 = 2.3f;
		}
		headDistance = Vector3.Distance(base.transform.position, target.position);
		if (headDistance < num2)
		{
			targetEntity.Kill(damageTag);
			damageTime = 5f;
		}
		float num3 = headDistance / 2f;
		if (Physics.CheckSphere(base.transform.position, residueRadius, residueMask))
		{
			fuseAudio.volume = Mathf.Lerp(fuseAudio.volume, 1f, Time.deltaTime);
			if (!residueSystem.isPlaying)
			{
				residueSystem.Play();
			}
		}
		else
		{
			fuseAudio.volume = Mathf.Lerp(fuseAudio.volume, 0f, Time.deltaTime);
			if (!residueSystem.isStopped)
			{
				residueSystem.Stop();
			}
		}
		if (CL_UIManager.debug)
		{
			CL_DebugView.draw.WireSphere(base.transform.position, headDamageRadius, new Color(1f, 0f, 0f, 0.6f));
			CL_DebugView.draw.Label2D(base.transform.position + -Vector3.up * 3f, "Aggression: " + GetAggression());
			CL_DebugView.draw.Label2D(base.transform.position + -Vector3.up * 5f, "Damage: " + curDamage + " / " + maxHealth);
		}
		for (int i = 0; i < initialSegments; i++)
		{
			if ((i + collisionCheckOffset) % num == 0)
			{
				float num4 = segments[i].localScale.y * segmentDamageRadius;
				if (CL_UIManager.debug)
				{
					CL_DebugView.draw.WireSphere(segments[i].position, num4, new Color(1f, 0f, 0f, 0.2f));
				}
				float num5 = Vector3.Distance(segments[i].position, target.position);
				num3 = Mathf.Min(num3, num5);
				if (num5 < num4)
				{
					targetEntity.Damage(Damageable.DamageInfo.CreateDamageInfo(collisionDamage, damageTag));
					targetEntity.AddForce((target.position - segments[i].position).normalized, "denizen");
					damageTime = collisionDamageRate;
					break;
				}
			}
		}
		collisionCheckOffset++;
		if (collisionCheckOffset > initialSegments)
		{
			collisionCheckOffset = 0;
		}
		if (num3 < screenEffectDistance)
		{
			SetScreenEffect(1f - num3 / screenEffectDistance);
		}
	}

	public override void DrawGizmos()
	{
		if (GizmoContext.InSelection(this))
		{
			Draw.SphereOutline(base.transform.position, movementModule.sphereRadius, new Color(1f, 0.5f, 0f, 0.5f));
			Draw.WireSphere(base.transform.position, headDamageRadius, new Color(1f, 0f, 0f, 1f));
		}
	}

	public float GetAggression()
	{
		return aggression;
	}

	public void MoveToPosition()
	{
	}

	public override bool Damage(Damageable.DamageInfo info)
	{
		huntState.AddHuntTime(info.amount * 0.25f);
		clipHandler.PlaySound("face:hurt");
		float hitShiftAmount;
		if (info.amount >= 4f)
		{
			if (aggression > 1.8f)
			{
				info.amount *= 0.5f;
			}
			hitShiftAmount = 1f;
			if (info.type.Contains("rebar"))
			{
				if (info.type.Contains("return"))
				{
					curDamage += info.amount * 0.35f;
					hitShiftAmount = 0.2f;
				}
				else
				{
					curDamage += info.amount * 0.5f;
				}
			}
			else if (info.type.Contains("flare"))
			{
				curDamage += info.amount * 3f;
			}
			else
			{
				curDamage += info.amount;
			}
			if (damageHitCouroutine != null)
			{
				StopCoroutine(damageHitCouroutine);
			}
			damageHitCouroutine = StartCoroutine(HitShift());
			CL_GameManager.gMan.FreezeForTime();
			CL_CameraControl.Shake(0.05f);
			if (curDamage >= maxHealth)
			{
				curDamage = 0f;
				ChangeState("stalk");
				clipHandler.PlaySound("face:hurt-retreat");
				CL_CameraControl.Shake(0.09f);
			}
		}
		return false;
		IEnumerator HitShift()
		{
			Vector3 adjustedVelocity = movementModule.GetVelocity();
			float magnitude = adjustedVelocity.magnitude;
			adjustedVelocity = Vector3.Lerp(b: Vector3.ProjectOnPlane(adjustedVelocity + Random.insideUnitSphere * 0.01f, (base.transform.position - ENT_Player.playerObject.transform.position).normalized).normalized, a: movementModule.GetVelocity(), t: hitShiftAmount).normalized;
			adjustedVelocity *= magnitude;
			float movetime = 0f;
			while (movetime < 1f)
			{
				movetime += Time.deltaTime;
				movementModule.SetVelocity(Vector3.Lerp(movementModule.GetVelocity(), adjustedVelocity, Time.deltaTime * 3f));
				faceMesh.material.SetColor("_Color", Color.Lerp(new Color(1f, 0.7f, 0.7f, 1f), Color.white, movetime));
				yield return null;
			}
		}
	}

	public static void AddFaceInstance(DEN_Face f)
	{
		if (faceInstances == null || faceInstances.Count == 0)
		{
			faceInstances = new List<DEN_Face>();
			CommandConsole.BuildCommand("face-setstate", ChangeFaceState).Description("(state=stalk)").OverValue(() => faceInstances.Select((DEN_Face dEN_Face) => dEN_Face.currentState.name));
			CommandConsole.BuildCommand("face-setspeed", ChangeFaceSpeed).Description("(newspeed=1)").OverValue(() => faceInstances.Select((DEN_Face dEN_Face) => dEN_Face.commandSpeedMult));
			CommandConsole.BuildCommand("face-avoidplayer", SetAvoidPlayer).AutocompleteSingleBool().OverValue(() => faceInstances.Select((DEN_Face dEN_Face) => dEN_Face.avoidPlayer));
			CommandConsole.BuildCommand("face-setactive", SetActive).Description("(freeze=toggle)").AutocompleteSingleBool()
				.OverValue(() => faceInstances.Select((DEN_Face dEN_Face) => dEN_Face.active));
			f.isPrimary = true;
		}
		if (!faceInstances.Contains(f))
		{
			faceInstances.Add(f);
			f.steeringEntity = Steering.AddSteeringEntity(f.gameObject.GetInstanceID().ToString(), f.movementModule.tags, f.transform.position, f.headDamageRadius * 1.5f);
		}
		Debug.Log("Adding Face Instance: " + faceInstances.Count);
	}

	public static void RemoveFaceInstance(DEN_Face f)
	{
		if (faceInstances.Contains(f))
		{
			Steering.RemoveSteeringEntity(f.gameObject.GetInstanceID().ToString());
			faceInstances.Remove(f);
		}
		if (faceInstances != null && faceInstances.Count == 0)
		{
			faceInstances = new List<DEN_Face>();
			CommandConsole.RemoveCommand("face-setstate");
			CommandConsole.RemoveCommand("face-avoidplayer");
			CommandConsole.RemoveCommand("face-setactive");
		}
	}

	public static void SetAvoidPlayer(bool b)
	{
		if (faceInstances == null)
		{
			return;
		}
		foreach (DEN_Face faceInstance in faceInstances)
		{
			faceInstance.avoidPlayer = b;
			if (faceInstance.avoidPlayer)
			{
				faceInstance.ChangeState("stalk");
			}
		}
	}

	public static void SetAvoidPlayer(string[] args)
	{
		if (args.Length == 0)
		{
			foreach (DEN_Face faceInstance in faceInstances)
			{
				faceInstance.avoidPlayer = !faceInstance.avoidPlayer;
				if (faceInstance.avoidPlayer)
				{
					faceInstance.ChangeState("stalk");
				}
			}
			return;
		}
		if (bool.TryParse(args[0], out var result))
		{
			foreach (DEN_Face faceInstance2 in faceInstances)
			{
				faceInstance2.avoidPlayer = result;
			}
			return;
		}
		CommandConsole.Log("Unable to parse " + args[0] + " arg needs to be a boolean (true/false).");
	}

	public static void SetActive(bool b)
	{
		foreach (DEN_Face faceInstance in faceInstances)
		{
			faceInstance.active = b;
		}
	}

	public static void SetActive(string[] args)
	{
		if (args.Length == 0)
		{
			foreach (DEN_Face faceInstance in faceInstances)
			{
				faceInstance.active = !faceInstance.active;
			}
			return;
		}
		if (bool.TryParse(args[0], out var result))
		{
			foreach (DEN_Face faceInstance2 in faceInstances)
			{
				faceInstance2.active = result;
			}
			return;
		}
		CommandConsole.Log("Unable to parse " + args[0] + " arg needs to be a boolean (true/false).");
	}

	public static void ChangeFaceState(string s)
	{
		if (faceInstances == null)
		{
			return;
		}
		foreach (DEN_Face faceInstance in faceInstances)
		{
			faceInstance.ChangeState(s);
		}
	}

	public static void ChangeFaceSpeed(string[] args)
	{
		float num = 1f;
		if (args.Length != 0 && float.TryParse(args[0], out var result))
		{
			num = result;
		}
		foreach (DEN_Face faceInstance in faceInstances)
		{
			faceInstance.commandSpeedMult = num;
		}
	}

	public static void ChangeFaceState(string[] args)
	{
		if (args.Length == 0)
		{
			ChangeFaceState("stalk");
		}
		else
		{
			ChangeFaceState(args[0]);
		}
	}

	public static void StartHunt()
	{
		ChangeFaceState("hunt");
	}

	public static void StartStalk()
	{
		ChangeFaceState("stalk");
	}

	public static void StartDive()
	{
		ChangeFaceState("dive");
	}

	internal static void Despawn()
	{
		if (faceInstances == null || faceInstances.Count <= 0)
		{
			return;
		}
		Debug.Log("Number of Faces to Despawn: " + faceInstances.Count);
		while (faceInstances.Count > 0)
		{
			if (faceInstances[faceInstances.Count - 1].parent != null)
			{
				Object.Destroy(faceInstances[faceInstances.Count - 1].parent.gameObject);
			}
		}
		Debug.Log("Number of Faces to Despawn: " + faceInstances.Count);
		faceInstances.Clear();
	}

	internal static void SetGlobalUpdateSpeedMultiplier(float massMult)
	{
		if (faceInstances != null && faceInstances.Count > 0)
		{
			for (int num = faceInstances.Count - 1; num >= 0; num--)
			{
				faceInstances[num].SetUpdateSpeedMultiplier(massMult);
			}
		}
	}

	private void SetUpdateSpeedMultiplier(float massMult)
	{
		updateSpeedMult *= massMult;
	}
}
