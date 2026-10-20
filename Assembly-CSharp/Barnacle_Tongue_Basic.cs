using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Barnacle_Tongue_Basic : Barnacle_Tongue_Core
{
	public Transform tongue;

	private CL_Handhold tongueHandhold;

	private Vector3 targetPoint;

	private Vector3 aimPoint;

	private Transform hitTarget;

	public ParticleSystem goopParticle;

	private Vector3 reachPoint;

	private Vector3 reachVelocity;

	private Vector3 aimTarget;

	private bool targetFound;

	private bool hasLatched;

	private float retractTime;

	private float aimTime;

	private float reachTime;

	private float tongueSlack;

	private float pullStrength;

	public float extremeDistancePullRadius;

	public float extremeDistancePullModifer = 2f;

	private Transform visualObject;

	private Material tongueMaterial;

	private GameEntity grabbedEntity;

	private Vector3 grabbedLocalPosition;

	public List<UT_Damage> tongueDamage;

	public bool canReachForAir;

	public float airReachWanderAmplitude = 1f;

	public float airReachWanderSpeed = 0.5f;

	public float airReachRangeMin = 0.5f;

	public Transform aimEye;

	public bool aimForPlayer;

	public bool onlyAimForEntity;

	public bool hardModeAdjustsDifficulty = true;

	public float velocityLead = 1f;

	private bool wanderTarget;

	private bool isAiming;

	private TongueState state;

	private bool canBite;

	public bool hideWhenRetracted;

	public float hitDamage;

	public float hitIntensity = 1f;

	public string hitDamageSource = "barnacle";

	public GameObject latchEffect;

	private float reelTimer;

	public bool grabOnHit = true;

	public bool dropPlayerOnHit;

	public override void Initialize(Barnacle_Tongue_Interface_Module_Basic b)
	{
		base.Initialize(b);
		visualObject = tongue.GetChild(0);
		tongueMaterial = visualObject.GetComponent<Renderer>().material;
		if (tongueDamage == null || tongueDamage.Count == 0)
		{
			tongueDamage = new List<UT_Damage>();
			tongueDamage.Add(visualObject.GetComponent<UT_Damage>());
		}
		reachPoint = tongue.position;
		targetPoint = tongue.position;
		aimTime = barnacleInterface.tongueAimTime;
		if (tongueDamage != null)
		{
			foreach (UT_Damage item in tongueDamage)
			{
				item.DamageAction = (Action<float>)Delegate.Combine(item.DamageAction, new Action<float>(DamageTongue));
				item.KillAction = (Action)Delegate.Combine(item.KillAction, new Action(KillTongue));
			}
		}
		state = TongueState.searching;
		tongueHandhold = tongue.GetComponentInChildren<CL_Handhold>();
	}

	public void DamageTongue(float amount)
	{
		if (state == TongueState.searching)
		{
			barnacleInterface.GetBarnacle().Damage(Damageable.DamageInfo.CreateDamageInfo(amount, "tongue"));
		}
		barnacleInterface.GetBarnacle().clipHandler.PlaySound("barnacle:hurt");
	}

	public override void KillTongue()
	{
		Retract();
		barnacleInterface.GetBarnacle()?.clipHandler.PlaySound("barnacle:hurt");
	}

	public override void BarnacleDie()
	{
		DropTarget();
	}

	public void FindTarget()
	{
		Vector3 vector = tongue.forward + UnityEngine.Random.onUnitSphere * barnacleInterface.tongueScatter;
		bool flag = false;
		if (((CL_GameManager.IsHardmode() && hardModeAdjustsDifficulty) || aimForPlayer) && ENT_Player.playerObject != null && Vector3.Distance(ENT_Player.playerObject.transform.position, tongue.position) < barnacleInterface.scanDistance)
		{
			Vector3 velocity = ENT_Player.playerObject.cCon.velocity;
			Vector3 vector2 = ENT_Player.playerObject.transform.position + velocity * velocityLead - tongue.position;
			float num = Vector3.Angle(tongue.forward, vector2.normalized);
			if (aimEye != null)
			{
				num = Vector3.Angle(aimEye.forward, vector2.normalized);
			}
			if (num < 60f)
			{
				vector = vector2.normalized + UnityEngine.Random.onUnitSphere * barnacleInterface.tongueScatter * 0.05f;
				flag = (barnacleInterface.GetBarnacle().sight.CanSeeTarget(ENT_Player.playerObject.transform) ? true : false);
				aimTarget = ENT_Player.playerObject.transform.position;
			}
		}
		RaycastHit hitInfo;
		if (onlyAimForEntity && !flag)
		{
			targetFound = false;
		}
		else if (Physics.Raycast(tongue.position, vector, out hitInfo, barnacleInterface.scanDistance, barnacleInterface.hitMask))
		{
			targetFound = true;
			aimPoint = hitInfo.point;
			reachVelocity += Vector3.up * barnacleInterface.tongueGravity * 10f;
			state = TongueState.searching;
		}
		else if (canReachForAir)
		{
			targetFound = true;
			aimPoint = tongue.position + vector * barnacleInterface.scanDistance * UnityEngine.Random.Range(airReachRangeMin, 1f);
			reachVelocity += Vector3.up * barnacleInterface.tongueGravity * 10f;
			state = TongueState.searching;
			wanderTarget = true;
		}
		else
		{
			targetFound = false;
			aimPoint = tongue.position;
		}
	}

	public override void Update()
	{
		base.Update();
		if (Vector3.Distance(reachPoint, barnacleInterface.GetBarnacle().transform.position) > barnacleInterface.scanDistance * 10f)
		{
			reachPoint = tongue.position;
			targetPoint = tongue.position;
			reachVelocity = Vector3.zero;
			Retract();
		}
		if (CL_UIManager.debug)
		{
			CL_DebugView.draw.SphereOutline(reachPoint, 0.1f, Color.magenta);
			CL_DebugView.draw.Label2D(reachPoint, "State : " + state, 10f, Color.magenta);
			CL_DebugView.draw.Label2D(tongue.position, "AimTime : " + aimTime, 10f, Color.magenta);
		}
		if (state == TongueState.retracting)
		{
			hasLatched = false;
		}
		Vector3 vector = targetPoint;
		if (wanderTarget && targetFound)
		{
			Vector3 vector2 = new Vector3(Mathf.PerlinNoise(vector.x * 0.5f + Time.time * airReachWanderSpeed, vector.y * 0.5f), Mathf.PerlinNoise(vector.x * 0.5f, vector.y * 0.5f + Time.time * airReachWanderSpeed), Mathf.PerlinNoise(vector.x * 0.5f - Time.time * airReachWanderSpeed, vector.y * 0.5f));
			vector2 -= Vector3.one * 0.5f;
			vector += vector2 * airReachWanderAmplitude;
		}
		float num = Vector3.Distance(vector, reachPoint);
		if (grabbedEntity == null)
		{
			float num2 = barnacleInterface.tongueSpeed;
			if (state == TongueState.retracting)
			{
				num2 = barnacleInterface.tongueRetractSpeed;
			}
			reachVelocity = Vector3.ClampMagnitude(vector - reachPoint, num2) * num2;
			float num3 = Mathf.PerlinNoise(reachPoint.x * 0.5f, reachPoint.y * 0.5f);
			Vector3 vector3 = new Vector3(num3 - 0.5f, 0f - num3 + 0.5f, num3 - 0.5f);
			reachVelocity += Vector3.ClampMagnitude(vector3 * num, num2 * 0.5f);
			reachPoint += reachVelocity * Time.deltaTime;
			if (hasLatched && !wanderTarget)
			{
				reachPoint = targetPoint;
			}
			if (reachPoint - visualObject.position != Vector3.zero)
			{
				visualObject.rotation = Quaternion.LookRotation(reachPoint - visualObject.position);
			}
			visualObject.localScale = new Vector3(1f, 1f, Vector3.Distance(visualObject.position, reachPoint));
			tongueMaterial.SetFloat("_Wiggle", barnacleInterface.tongueWiggle * num * 0.25f);
			tongueMaterial.SetFloat("_Length", visualObject.localScale.z);
			tongueSlack = Mathf.Lerp(tongueSlack, num * barnacleInterface.tongueGravity, Time.deltaTime);
			tongueMaterial.SetFloat("_Slack", tongueSlack);
		}
		else
		{
			if (grabbedEntity.IsDead())
			{
				grabbedEntity = null;
				return;
			}
			if (grabbedEntity == ENT_Player.GetPlayer())
			{
				reachPoint = ENT_Player.GetPlayer().cCon.ClosestPoint(visualObject.position);
			}
			else
			{
				reachPoint = grabbedEntity.transform.TransformPoint(grabbedLocalPosition) + Vector3.down * 0.5f + grabbedEntity.transform.forward * 0.25f;
			}
			float z = Vector3.Distance(visualObject.position, reachPoint);
			visualObject.localScale = new Vector3(1f, 1f, z);
			visualObject.rotation = Quaternion.LookRotation(reachPoint - visualObject.position);
			tongueMaterial.SetFloat("_Wiggle", barnacleInterface.tongueWiggle * 0.5f);
			tongueMaterial.SetFloat("_Length", visualObject.localScale.z);
			tongueSlack = Mathf.Lerp(tongueSlack, 0.2f * barnacleInterface.tongueGravity, Time.deltaTime);
			tongueMaterial.SetFloat("_Slack", tongueSlack);
			float num4 = Vector3.Distance(grabbedEntity.transform.position, tongue.position);
			if (num4 < barnacleInterface.GetBarnacle().attackDistance)
			{
				canBite = true;
			}
			else
			{
				float num5 = 2f;
				if (grabbedEntity.transform.position.y > barnacleInterface.GetBarnacle().transform.position.y)
				{
					num5 = 1f;
				}
				if (num4 > barnacleInterface.scanDistance * num5)
				{
					Retract();
				}
				canBite = false;
			}
		}
		if (barnacleInterface.GetBarnacle().dead && hideWhenRetracted && num < 0.2f)
		{
			tongue.gameObject.SetActive(value: false);
		}
		if (!barnacleInterface.GetBarnacle().dead)
		{
			AI(num);
		}
	}

	private void AI(float distance)
	{
		switch (state)
		{
		case TongueState.searching:
			if (hideWhenRetracted)
			{
				tongue.gameObject.SetActive(value: false);
			}
			if (!barnacleInterface.GetBarnacle().canReachAutomatically)
			{
				break;
			}
			if (retractTime > 0f)
			{
				retractTime -= Time.deltaTime;
				break;
			}
			if (!targetFound)
			{
				FindTarget();
			}
			if (!targetFound)
			{
				break;
			}
			if (onlyAimForEntity)
			{
				if (aimTime > 0f)
				{
					FindTarget();
					aimTime -= Time.deltaTime;
					if (!isAiming)
					{
						isAiming = true;
						barnacleInterface.GetBarnacle().PrepareTongue();
					}
				}
				else
				{
					Extend();
				}
			}
			else
			{
				Extend();
			}
			break;
		case TongueState.reaching:
			reachTime -= Time.deltaTime;
			if (reachTime < 0f)
			{
				Retract();
				return;
			}
			if (distance < 0.2f && !hasLatched)
			{
				hasLatched = true;
				reachPoint = targetPoint;
				reelTimer = barnacleInterface.tongueReelTime;
				barnacleInterface.GetBarnacle().clipHandler.PlaySound("barnacle:latch", reachPoint);
				if (latchEffect != null && !wanderTarget)
				{
					UnityEngine.Object.Instantiate(latchEffect, targetPoint, Quaternion.identity, null);
				}
			}
			tongueHandhold.climbMult = 1f;
			ScanForHitEntity();
			break;
		case TongueState.retracting:
			if (Vector3.Distance(reachPoint, targetPoint) < 0.5f)
			{
				state = TongueState.searching;
				retractTime = barnacleInterface.tongueRetractTime;
				if (hideWhenRetracted)
				{
					tongue.gameObject.SetActive(value: false);
				}
			}
			break;
		case TongueState.grabbing:
			PullTarget();
			break;
		}
		if (state != TongueState.grabbing)
		{
			canBite = false;
		}
	}

	public void ForceExtend()
	{
		FindTarget();
		_ = aimTarget;
		if (aimTarget == Vector3.zero || !targetFound)
		{
			aimTarget = barnacleInterface.GetBarnacle().transform.position + barnacleInterface.GetBarnacle().transform.forward * 3f + UnityEngine.Random.onUnitSphere * 0.35f;
		}
		_ = aimPoint;
		if (aimPoint == Vector3.zero || !targetFound)
		{
			aimPoint = barnacleInterface.GetBarnacle().transform.position + barnacleInterface.GetBarnacle().transform.forward * 3f + UnityEngine.Random.onUnitSphere * 0.35f;
		}
		_ = targetPoint;
		if (targetPoint == Vector3.zero || !targetFound)
		{
			targetPoint = barnacleInterface.GetBarnacle().transform.position + barnacleInterface.GetBarnacle().transform.forward * 3f + UnityEngine.Random.onUnitSphere * 0.35f;
		}
		Extend();
	}

	public void Extend()
	{
		aimTime = barnacleInterface.tongueAimTime;
		if (state != TongueState.reaching && barnacleInterface.GetBarnacle().clipHandler != null)
		{
			barnacleInterface.GetBarnacle().clipHandler.PlaySound("barnacle:reach");
		}
		state = TongueState.reaching;
		barnacleInterface.GetBarnacle().ShootTongue();
		if (goopParticle != null)
		{
			goopParticle.Play();
		}
		reachTime = UnityEngine.Random.Range(barnacleInterface.tongueReachTimeMin, barnacleInterface.tongueReachTimeMax);
		targetPoint = aimPoint;
		aimTarget = targetPoint;
		if (hideWhenRetracted)
		{
			tongue.gameObject.SetActive(value: true);
		}
	}

	public override void Retract()
	{
		targetFound = false;
		state = TongueState.retracting;
		aimTime = barnacleInterface.tongueAimTime;
		isAiming = false;
		if (grabbedEntity != null)
		{
			grabbedEntity.SetGrappled(b: false, barnacleInterface.GetBarnacle());
		}
		if (barnacleInterface == null)
		{
			return;
		}
		grabbedEntity = null;
		if (barnacleInterface.GetBarnacle().clipHandler != null)
		{
			barnacleInterface.GetBarnacle().clipHandler.PlaySound("barnacle:retract");
		}
		foreach (UT_Damage item in tongueDamage)
		{
			item.ResetHealth();
		}
		hasLatched = false;
		if (tongue != null)
		{
			targetPoint = tongue.position;
		}
	}

	public void DropTarget()
	{
		if (grabbedEntity != null)
		{
			grabbedEntity.SetGrappled(b: false, barnacleInterface.GetBarnacle());
		}
		targetFound = false;
		state = TongueState.retracting;
		grabbedEntity = null;
		barnacleInterface.GetBarnacle().clipHandler.PlaySound("barnacle:retract", reachPoint);
		foreach (UT_Damage item in tongueDamage)
		{
			item.ResetHealth();
		}
		hasLatched = false;
		targetPoint = tongue.position;
	}

	private void PullTarget()
	{
		if (grabbedEntity == null)
		{
			Retract();
			return;
		}
		aimTarget = grabbedEntity.transform.TransformPoint(grabbedLocalPosition);
		if (CL_GameManager.IsHardmode())
		{
			pullStrength = Mathf.Lerp(pullStrength, barnacleInterface.pullStrength * 1.5f, Time.deltaTime * 0.8f * barnacleInterface.tongueReelIncreaseRate);
		}
		else
		{
			pullStrength = Mathf.Lerp(pullStrength, barnacleInterface.pullStrength, Time.deltaTime * 0.3f * barnacleInterface.tongueReelIncreaseRate);
		}
		if (reelTimer > 0f)
		{
			pullStrength = 0f;
			reelTimer -= Time.deltaTime;
		}
		float num = Mathf.Max(Vector3.Distance(tongue.position, grabbedEntity.transform.position) / barnacleInterface.scanDistance, 1f);
		grabbedEntity.SetGrappled(b: true, barnacleInterface.GetBarnacle());
		if (extremeDistancePullRadius > 0f && Vector3.Distance(tongue.position, grabbedEntity.transform.position) > extremeDistancePullRadius)
		{
			pullStrength *= extremeDistancePullModifer;
		}
		grabbedEntity.TonguePull((tongue.position - grabbedEntity.transform.position).normalized * Time.deltaTime * pullStrength * num);
		if (grabbedEntity.transform.position.y > tongue.position.y)
		{
			tongueHandhold.climbMult = 0f;
			tongueHandhold.jumpMult = 0f;
		}
		else
		{
			tongueHandhold.climbMult = 1f;
			tongueHandhold.jumpMult = 1f;
		}
	}

	private void ArriveAtTarget()
	{
	}

	private void ScanForHitEntity()
	{
		if (!Physics.Linecast(tongue.position, reachPoint, out var hitInfo, barnacleInterface.playerMask))
		{
			return;
		}
		grabbedEntity = hitInfo.collider.GetComponent<GameEntity>();
		grabbedLocalPosition = hitInfo.collider.transform.InverseTransformPoint(hitInfo.point);
		if (grabbedEntity == null)
		{
			return;
		}
		if (!grabbedEntity.GetTagger().HasTagInList(barnacleInterface.GetBarnacle().grabTags.ToArray()) && grabbedEntity.GetTagger().HasTagInList(barnacleInterface.GetBarnacle().ignoreTags.ToArray()))
		{
			grabbedEntity = null;
			return;
		}
		if (grabbedEntity.IsDead())
		{
			grabbedEntity = null;
			if (state == TongueState.grabbing)
			{
				state = TongueState.retracting;
			}
			return;
		}
		state = TongueState.grabbing;
		pullStrength = 0f;
		Damageable.DamageInfo damageInfo = Damageable.DamageInfo.CreateDamageInfo(hitDamage, hitDamageSource);
		damageInfo.intensity = hitIntensity;
		damageInfo.position = hitInfo.point;
		damageInfo.sourceEntity = barnacleInterface.GetBarnacle();
		grabbedEntity.Damage(damageInfo);
		barnacleInterface.GetBarnacle().clipHandler.PlaySound("barnacle:grabbed-object");
		barnacleInterface.GetBarnacle().OnGrab();
		if (!grabOnHit)
		{
			grabbedEntity = null;
			Retract();
		}
		if (dropPlayerOnHit)
		{
			grabbedEntity.GetComponent<ENT_Player>()?.DropHang(0.4f, 1f, cooldownOnlyOnHangingHands: false, "drop", canResist: true);
		}
	}

	public override GameEntity GetGrabbed()
	{
		return grabbedEntity;
	}

	public override bool CanBite()
	{
		return canBite;
	}

	public override TongueState GetState()
	{
		return state;
	}

	public override void OffsetTargetPoint(Vector3 o)
	{
		targetPoint += o;
		reachPoint += o;
	}

	public override bool IsAiming()
	{
		return isAiming;
	}

	public override Vector3 GetAimTarget()
	{
		return aimTarget;
	}

	public Vector3 GetReachPosition()
	{
		return reachPoint;
	}

	public bool HasLatched()
	{
		return hasLatched;
	}

	internal bool HasFoundTarget()
	{
		FindTarget();
		return targetFound;
	}
}
