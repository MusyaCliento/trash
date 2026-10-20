using System;
using System.Collections.Generic;
using DarkMachine.AI;
using UnityEngine;
using UnityEngine.Events;

public class DEN_BasicDenizen : Denizen
{
	public enum FaceDirection
	{
		faceStateLookDirection = 0,
		faceTargetPosition = 1,
		faceTarget = 2,
		faceVelocity = 3,
		doNotPassToMovementModule = 4
	}

	[Serializable]
	public class AnimatorDeathType
	{
		public int id;

		public List<string> tags;
	}

	public bool active = true;

	[Header("Basic Denizen")]
	public string changeLayerOnDeath = "CreaturePassthrough";

	public bool canDrown;

	public bool dieOnTouchWater;

	public AITargetComponent targetComponent;

	[SerializeReference]
	public FaceDirection faceDirection;

	[SerializeReference]
	public DenizenMovementModule movementModule;

	[SerializeReference]
	public List<AIStateComponent> aiStateComponents;

	[SerializeReference]
	public DenizenAttackModule attackModule;

	internal Rigidbody rigid;

	public float barkRate = 10f;

	private float barkTime;

	public string barkSoundID = "denizen:bark";

	public string huntSoundID = "denizen:hunt";

	public string attackSoundID = "denizen:attack-start";

	public string attackHitSoundID = "denizen:attack-hit";

	public string hurtSoundID = "denizen:hurt";

	public string impactHurtSoundID = "denizen:hurt";

	public string dieSoundID = "denizen:die";

	public float footstepSoundVelocityThreshold = 0.1f;

	public string footstepSound = "denizen:step";

	public UnityEvent eventOnStep;

	public Animator animator;

	public string animGroundedBool = "Grounded";

	public string animWalkingBool = "Walking";

	public string animHurtTrigger = "Hurt";

	public string animJumpTrigger = "Jump";

	public string animLandTrigger = "Land";

	public string animDieTrigger = "Die";

	public int animDieLayer = -1;

	public bool useCustomDeathTypes;

	public List<AnimatorDeathType> animatorDeathTypes;

	public UnityEvent deathEvent;

	public bool destroyOnDeath;

	internal bool canSeeTarget;

	internal bool canRememberTarget;

	public float bouyancy = 1f;

	private float startDrag;

	private float lastTimeInWater;

	public override void Start()
	{
		base.Start();
		rigid = GetComponent<Rigidbody>();
		if (rigid != null)
		{
			startDrag = rigid.linearDamping;
		}
		movementModule.Initialize(this);
		movementModule.Start();
		if (attackModule != null)
		{
			attackModule.Initialize(this);
		}
		if (base.transform.lossyScale.x < 0f)
		{
			base.transform.localScale = Vector3.Scale(base.transform.localScale, new Vector3(-1f, 1f, 1f));
		}
		DenizenMovementModule denizenMovementModule = movementModule;
		denizenMovementModule._OnJump = (Action)Delegate.Combine(denizenMovementModule._OnJump, new Action(OnJump));
		DenizenMovementModule denizenMovementModule2 = movementModule;
		denizenMovementModule2._OnLand = (Action)Delegate.Combine(denizenMovementModule2._OnLand, new Action(OnLand));
		aiStates = aiStateComponents;
		foreach (AIStateComponent aiState in aiStates)
		{
			aiState.Initialize(this, stateVariables);
		}
		ChangeState(aiStates[0].name);
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		if (active)
		{
			movementModule.FixedUpdate();
		}
	}

	public override void TickUpdate()
	{
		base.TickUpdate();
		TargetCheck();
		targetComponent.Update();
	}

	public override void Update()
	{
		base.Update();
		AnimationUpdate();
		if (dead || !active)
		{
			return;
		}
		movementModule.SetLookVector(GetLookVector());
		if (barkTime > 0f)
		{
			BarkCheck();
		}
		if (currentState != null)
		{
			currentState.Execute(this);
		}
		movementModule.SetTargetPosition(targetPosition);
		if (faceDirection == FaceDirection.faceTargetPosition)
		{
			movementModule.SetLookVector(targetPosition - base.transform.position);
		}
		else if (faceDirection == FaceDirection.faceTarget && targetComponent.target.targetTransform != null)
		{
			movementModule.SetLookVector(target.position - base.transform.position);
		}
		else if (faceDirection == FaceDirection.faceStateLookDirection)
		{
			movementModule.SetLookVector(currentState.GetLookVector());
		}
		else if (faceDirection == FaceDirection.faceVelocity)
		{
			if (rigid.linearVelocity.magnitude > 0f)
			{
				movementModule.SetLookVector(rigid.linearVelocity);
			}
			else
			{
				movementModule.SetLookVector(base.transform.forward);
			}
		}
		movementModule.Update();
		if (CL_UIManager.debug)
		{
			CL_DebugView.draw.Label2D(base.transform.position + Vector3.up, "State:" + currentState.name, Color.yellow);
			CL_DebugView.draw.Arrow(base.transform.position, GetTargetPosition(), Color.red);
		}
	}

	public virtual void BarkCheck()
	{
		barkTime -= Time.deltaTime;
		if (barkTime <= 0f)
		{
			barkTime = UnityEngine.Random.Range(barkRate, barkRate * 2f);
			clipHandler.PlaySound(barkSoundID);
		}
	}

	public virtual void AnimationUpdate()
	{
		if (!(animator == null))
		{
			if (animWalkingBool != "")
			{
				animator.SetBool(animWalkingBool, movementModule.IsWalking());
			}
			if (animGroundedBool != "")
			{
				animator.SetBool(animGroundedBool, movementModule.IsGrounded());
			}
		}
	}

	public virtual void TargetCheck()
	{
		if (!targetComponent.HasTarget())
		{
			targetComponent.CheckForTarget(base.transform.position, sight.sightDistance, sight);
		}
		if (targetComponent.HasTarget())
		{
			if (!sight.CanRemember())
			{
				targetComponent.ClearTarget();
				target = null;
			}
			else
			{
				target = targetComponent.target.targetTransform;
			}
		}
	}

	internal override void AttackCheck()
	{
		GameEntity targetEntity = targetComponent.target.targetEntity;
		if (!(targetEntity == null))
		{
			attackModule?.AttackCheck(targetEntity);
		}
	}

	public virtual void AttackAnimationEvent(string eName)
	{
		barkTime = barkRate * 2f;
		attackModule?.StartAttackEvent(eName);
	}

	public override bool Damage(Damageable.DamageInfo info)
	{
		if (health <= -3f && gibAsset != null && dead)
		{
			Gib();
		}
		if (dead)
		{
			return base.Damage(info);
		}
		if (info.HasTag("impact"))
		{
			clipHandler.PlaySound(impactHurtSoundID);
		}
		else
		{
			clipHandler.PlaySound(hurtSoundID);
		}
		if (animator != null)
		{
			animator.SetTrigger(animHurtTrigger);
		}
		if (info.sourceEntity != null)
		{
			targetComponent.SetTarget(info.sourceEntity.transform);
			sight.SetTargetAsVisible(info.sourceEntity.transform, 4f);
			target = info.sourceEntity.transform;
			ChangeState("hunt");
		}
		barkTime = barkRate * 2f;
		return base.Damage(info);
	}

	public override void Kill(string type = "", Damageable.DamageInfo damageInfo = null)
	{
		if (dead)
		{
			return;
		}
		base.gameObject.layer = LayerMask.NameToLayer(changeLayerOnDeath);
		if (animator != null)
		{
			if (animDieLayer != -1)
			{
				animator.SetLayerWeight(animDieLayer, 1f);
			}
			animator.SetTrigger(animDieTrigger);
			if (useCustomDeathTypes)
			{
				foreach (AnimatorDeathType animatorDeathType in animatorDeathTypes)
				{
					if (animatorDeathType.tags.Contains(type))
					{
						animator.SetInteger("DeathType", animatorDeathType.id);
						break;
					}
					if (damageInfo != null && damageInfo.HasTagInList(animatorDeathType.tags))
					{
						animator.SetInteger("DeathType", animatorDeathType.id);
						break;
					}
				}
			}
		}
		base.Kill(type, damageInfo);
		barkTime = barkRate * 2f;
		clipHandler.PlaySound(dieSoundID);
		deathEvent.Invoke();
		if (rigid != null)
		{
			rigid.useGravity = true;
		}
		if (destroyOnDeath)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	internal virtual void OnJump()
	{
		if (animator != null)
		{
			animator.SetTrigger(animJumpTrigger);
		}
		rigid.linearDamping = startDrag;
	}

	internal virtual void OnLand()
	{
		if (animator != null)
		{
			animator.SetTrigger(animLandTrigger);
		}
	}

	public override void AddForce(Vector3 v, string source = "")
	{
		if (rigid == null)
		{
			rigid = GetComponent<Rigidbody>();
		}
		if (!(rigid == null))
		{
			base.AddForce(v);
			rigid.AddForce(v * 10f);
		}
	}

	internal override void OnCollisionEnter(Collision collision)
	{
		attackModule?.OnCollisionEnter(collision);
		movementModule?.OnCollisionEnter(collision);
	}

	internal virtual void OnCollisionExit(Collision collision)
	{
		movementModule?.OnCollisionExit(collision);
	}

	internal virtual void OnCollisionStay(Collision collision)
	{
		movementModule?.OnCollisionStay(collision);
	}

	public virtual void OnLeapHit(Collision collision, GameEntity gameEntity)
	{
	}

	public override void ChangeState(string state)
	{
		base.ChangeState(state);
		if (state == "hunt" && clipHandler != null)
		{
			clipHandler.PlaySound(huntSoundID);
		}
	}

	public override void TonguePull(Vector3 v)
	{
		base.TonguePull(v);
		AddForce(v * 1000f);
	}

	public override DenizenMovementModule GetMovementModule()
	{
		return movementModule;
	}

	internal override void EnterSwimZone(UT_SwimZone zone)
	{
		base.EnterSwimZone(zone);
		if (!rigid.isKinematic)
		{
			rigid.linearDamping = zone.drag;
			if (lastTimeInWater + 0.5f < Time.time)
			{
				zone.Splash(base.transform.position);
			}
		}
	}

	internal override void ExitSwimZone(UT_SwimZone zone)
	{
		if (!rigid.isKinematic)
		{
			lastTimeInWater = Time.time;
			base.ExitSwimZone(zone);
			if (enterWaterTime + 0.5f < Time.time && zone != null)
			{
				zone.Splash(base.transform.position);
			}
		}
	}

	internal override void WaterUpdate()
	{
		base.WaterUpdate();
		float num = Mathf.Clamp01(currentSwimZone.GetDepth(base.transform.position) * 1f);
		rigid.AddForce(Vector3.up * bouyancy * Time.deltaTime * 1000f * num, ForceMode.Acceleration);
		if (dieOnTouchWater)
		{
			Kill("drowned");
		}
	}

	public void SetHome()
	{
		AIStateComponent state = GetState("wander");
		if (state is AIC_SimpleCreature_Wander)
		{
			(state as AIC_SimpleCreature_Wander).SetHomePosition(base.transform.position);
		}
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		attackModule?.DrawGizmos(base.transform);
	}

	public void SendCommandToAttackModule(string message)
	{
		attackModule?.RecieveCommand(message);
	}

	public override void SetNavigationTargetPosition(Vector3 position)
	{
		SetTargetPosition(position);
	}

	public void PlayFootstepSound()
	{
		if (!dead && movementModule.GetVelocity().magnitude > footstepSoundVelocityThreshold)
		{
			clipHandler.PlaySound(footstepSound);
			eventOnStep.Invoke();
		}
	}
}
