using System;
using System.Collections.Generic;
using DarkMachine.AI;
using UnityEngine;
using UnityEngine.Events;

public class DEN_BasicNavigator : Denizen
{
	[Header("Denizen")]
	public string changeLayerOnDeath = "CreaturePassthrough";

	public bool dieOnTouchWater;

	public AITargetComponent targetComponent;

	public AIN_Standard navigator = new AIN_Standard();

	public bool automaticRepathing = true;

	public bool useNodeGraphs = true;

	public bool useNavWander = true;

	public bool forceMoveToTarget = true;

	public bool forceDistanceNavigation;

	[SerializeReference]
	public DenizenMovementModule baseMovementModule;

	public float speedMult = 1f;

	public AIC_SimpleCreature_Wander_Patrol patrolState = new AIC_SimpleCreature_Wander_Patrol();

	public AIC_SimpleCreature_Hunt huntState = new AIC_SimpleCreature_Hunt();

	private AIC_SimpleCreature_Empty emptyState = new AIC_SimpleCreature_Empty();

	[SerializeReference]
	public List<AIStateComponent> extraStates;

	public DenizenAttackModule_Basic attackModule;

	public Animator animator;

	public bool locked;

	internal Vector3 moveTarget;

	public string attackTag = "denizen";

	public string huntStartSound = "denizen:hunt-start";

	public string patrolStartSound = "denizen:patrol-start";

	public string attackHitSound = "denizen:attack-hit";

	public string hurtSound = "denizen:hurt";

	public string deathSound = "denizen:death";

	public string pickupSound = "denizen:pickup";

	public float footstepSoundVelocityThreshold = 0.1f;

	public string footstepSound = "denizen:step";

	public string barkSound = "denizen:bark";

	public float barkRate = 10f;

	private float barkTimer;

	public string animGroundedBool = "Grounded";

	public string animWalkingBool = "Walking";

	public string animAttackRangeBool = "";

	public string animHurtTrigger = "Hurt";

	public string animJumpTrigger = "Jump";

	public string animLandTrigger = "Land";

	public string animDieTrigger = "Die";

	public int animDieLayer = -1;

	private bool pickedUp;

	private bool forceFalling;

	public UnityEvent deathEvent;

	public UnityEvent<Damageable.DamageInfo> damageEvent;

	private float curVelocity;

	private Vector3 lastPosition;

	private Vector3 lastStuckPosition;

	private float stuckTime;

	public Vector3 grabbedUp = Vector3.up;

	internal Vector3 navigationTargetPosition;

	internal bool canSeeTarget;

	private float seeTargetTime;

	internal bool canRememberTarget;

	internal float repathTime;

	private void Awake()
	{
		navigator.Initialize(this);
	}

	public override void Start()
	{
		base.Start();
		baseMovementModule.Initialize(this);
		baseMovementModule.Start();
		DenizenMovementModule denizenMovementModule = baseMovementModule;
		denizenMovementModule._OnJump = (Action)Delegate.Combine(denizenMovementModule._OnJump, new Action(OnJump));
		DenizenMovementModule denizenMovementModule2 = baseMovementModule;
		denizenMovementModule2._OnLand = (Action)Delegate.Combine(denizenMovementModule2._OnLand, new Action(OnLand));
		attackModule.Initialize(this);
		emptyState.lookVector = base.transform.forward;
		aiStates = new List<AIStateComponent> { patrolState, huntState, emptyState };
		if (extraStates != null && extraStates.Count > 0)
		{
			aiStates.AddRange(extraStates);
		}
		foreach (AIStateComponent aiState in aiStates)
		{
			aiState.Initialize(this, stateVariables);
		}
		if (base.transform.lossyScale.x < 0f)
		{
			base.transform.localScale = Vector3.Scale(base.transform.localScale, new Vector3(-1f, 1f, 1f));
		}
		moveTarget = base.transform.position;
		SetTargetPosition(base.transform.position);
		if (disableAI)
		{
			ChangeState("empty");
			navigationTargetPosition = base.transform.position;
		}
		else
		{
			ChangeState("wander");
			if (useNavWander)
			{
				navigationTargetPosition = GetWanderPosition();
			}
		}
		AIC_SimpleCreature_Wander_Patrol aIC_SimpleCreature_Wander_Patrol = patrolState;
		aIC_SimpleCreature_Wander_Patrol._OnReachWaypoint = (Action<AIC_SimpleCreature_Wander_Patrol>)Delegate.Combine(aIC_SimpleCreature_Wander_Patrol._OnReachWaypoint, new Action<AIC_SimpleCreature_Wander_Patrol>(OnReachPatrolPoint));
		_OnChangeState = (Action<string>)Delegate.Combine(_OnChangeState, new Action<string>(OnChangeState));
		base.Start();
	}

	public override void Update()
	{
		if (locked || dead)
		{
			return;
		}
		barkTimer -= Time.deltaTime;
		if (barkTimer <= 0f)
		{
			clipHandler.PlaySound(barkSound);
			barkTimer = barkRate + UnityEngine.Random.Range((0f - barkRate) * 0.3f, barkRate * 0.3f);
		}
		base.Update();
		DebugDraw();
		targetComponent.Update();
		if (pickedUp && targetComponent.HasTarget())
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(Vector3.ProjectOnPlane(targetComponent.target.targetTransform.position - base.transform.position, grabbedUp).normalized, grabbedUp), Time.deltaTime * 5f);
			return;
		}
		currentState.Execute(this);
		if (disableAI && currentState.name != "empty")
		{
			ChangeState(emptyState.name);
		}
		if (animAttackRangeBool != "")
		{
			if (currentState.name == "hunt" && huntState.IsInAttackRange())
			{
				animator.SetBool(animAttackRangeBool, value: true);
			}
			else
			{
				animator.SetBool(animAttackRangeBool, value: false);
			}
		}
		Movement();
		if (currentState != patrolState)
		{
			return;
		}
		stuckTime += Time.deltaTime;
		if (stuckTime > 4f)
		{
			if (useNavWander)
			{
				navigationTargetPosition = GetWanderPosition();
			}
			stuckTime = 0f;
		}
		if (Vector3.Distance(lastStuckPosition, base.transform.position) > 1f)
		{
			stuckTime = 0f;
			lastStuckPosition = base.transform.position;
		}
	}

	public override void FixedUpdate()
	{
		curVelocity = Vector3.Magnitude(base.transform.position - lastPosition) / Time.fixedDeltaTime;
		lastPosition = base.transform.position;
		base.FixedUpdate();
		if (!pickedUp && !dead)
		{
			baseMovementModule.FixedUpdate();
		}
	}

	public override void TickUpdate()
	{
		base.TickUpdate();
		UpdateTarget();
	}

	private void Movement()
	{
		_ = speedMult;
		if (!dead)
		{
			baseMovementModule.targetPosition = moveTarget;
			baseMovementModule.currentPosition = base.transform.position;
			baseMovementModule.Update();
		}
	}

	public virtual void UpdateTarget()
	{
		bool flag = false;
		repathTime += tickRate;
		if (repathTime > 0.25f && automaticRepathing)
		{
			repathTime = 0f;
			flag = true;
		}
		if (navigator.GetLastPath() == null)
		{
			flag = true;
		}
		canSeeTarget = false;
		canRememberTarget = false;
		bool flag2 = true;
		if (!disableAI && useNavWander)
		{
			_ = navigationTargetPosition;
			if (Vector3.Distance(base.transform.position, navigationTargetPosition) < 5f || navigator.GetLastPath() == null || navigator.GetLastPath().vectorPath == null || navigator.GetLastPath().vectorPath.Count <= 1)
			{
				navigationTargetPosition = GetWanderPosition();
			}
		}
		if (!targetComponent.HasTarget() && IsTickFrame())
		{
			if (!disableAI)
			{
				targetComponent.CheckForTarget(base.transform.position, sight.sightDistance, sight);
			}
			navigator.UpdatePath(base.transform.position, navigationTargetPosition, null);
			seeTargetTime = 0f;
		}
		else if (!disableAI && targetComponent.HasTarget())
		{
			bool flag3 = sight.CanSeeTarget(targetComponent.target.targetTransform);
			if (flag3)
			{
				canSeeTarget = flag3;
				seeTargetTime += tickRate;
			}
			canRememberTarget = canSeeTarget;
			bool flag4 = false;
			float num = Vector3.Distance(base.transform.position, targetComponent.target.targetTransform.position);
			float num2 = Vector3.Distance(navigator.GetPathEndPosition(), targetComponent.target.targetTransform.position);
			if (!canSeeTarget)
			{
				if (forceMoveToTarget)
				{
					huntState.huntMoveToTarget = false;
				}
				if (sight.CanRemember())
				{
					if (forceMoveToTarget)
					{
						navigationTargetPosition = targetComponent.target.targetTransform.position;
					}
					else
					{
						navigationTargetPosition = GetTargetPosition();
					}
					canRememberTarget = true;
					flag4 = true;
					if (currentState == huntState && forceMoveToTarget)
					{
						SetTargetPosition(navigationTargetPosition);
					}
				}
			}
			else
			{
				if (forceMoveToTarget)
				{
					navigationTargetPosition = targetComponent.target.targetTransform.position;
				}
				else
				{
					navigationTargetPosition = GetTargetPosition();
				}
				canRememberTarget = true;
				if (num > num2 + 1f)
				{
					if (forceMoveToTarget)
					{
						huntState.huntMoveToTarget = false;
						SetTargetPosition(navigationTargetPosition);
					}
					flag4 = true;
					flag2 = true;
				}
				else
				{
					if (forceMoveToTarget)
					{
						huntState.huntMoveToTarget = true;
						SetTargetPosition(navigationTargetPosition);
					}
					flag2 = false;
				}
			}
			if (!flag3 && !canSeeTarget && !canRememberTarget && currentState == patrolState)
			{
				targetComponent.target.Clear();
			}
			else
			{
				target = targetComponent.target.targetTransform;
			}
			if (forceDistanceNavigation)
			{
				flag4 = true;
			}
			if (flag4 && flag)
			{
				navigator.UpdatePath(base.transform.position, navigationTargetPosition, null);
			}
		}
		if (navigator.GetLastPath() != null && flag2)
		{
			Vector3 vector = GetTargetPosition();
			if (navigator.GetLastPath().vectorPath.Count > 1 && sight.CanSeeToPosition(navigator.GetLastPath().vectorPath[1]))
			{
				navigator.ClearFirstPathnode();
				vector = navigator.GetLastPath().vectorPath[0];
			}
			else if (navigator.GetLastPath().vectorPath.Count > 1 && Vector3.Distance(base.transform.position, navigator.GetLastPath().vectorPath[0]) < 1.5f)
			{
				navigator.ClearFirstPathnode();
				vector = navigator.GetLastPath().vectorPath[0];
			}
			else if (navigator.GetLastPath().vectorPath.Count > 0)
			{
				vector = navigator.GetLastPath().vectorPath[0];
			}
			moveTarget = vector;
		}
		else
		{
			moveTarget = GetTargetPosition();
		}
		patrolState.SetHomePosition(moveTarget);
	}

	public void SetNavigationTarget(Vector3 navTarget)
	{
		navigationTargetPosition = navTarget;
		navigator.UpdatePath(base.transform.position, navTarget, null);
		if (sight.CanSeeToPosition(navTarget))
		{
			moveTarget = navTarget;
			patrolState.SetHomePosition(moveTarget);
			SetTargetPosition(navTarget);
		}
		else
		{
			patrolState.SetHomePosition(navigator.GetLastPath().vectorPath[0]);
			moveTarget = navigator.GetLastPath().vectorPath[0];
			SetTargetPosition(navigator.GetLastPath().vectorPath[0]);
		}
	}

	private void OnReachPatrolPoint(AIC_SimpleCreature_Wander_Patrol state)
	{
		if (navigator.GetLastPath() != null)
		{
			if (navigator.GetLastPath().vectorPath.Count > 1)
			{
				navigator.ClearFirstPathnode();
				moveTarget = navigator.GetLastPath().vectorPath[0];
				repathTime = 0f;
			}
			else if (currentState != emptyState && useNavWander)
			{
				SetNavigationTarget(GetWanderPosition());
			}
		}
	}

	private void DebugDraw()
	{
	}

	internal virtual void OnChangeState(string s)
	{
		if (s == "hunt")
		{
			clipHandler.PlaySound(huntStartSound);
		}
		else if (s == "wander")
		{
			clipHandler.PlaySound(patrolStartSound);
			if (useNavWander)
			{
				SetNavigationTarget(GetWanderPosition());
			}
		}
	}

	internal override void AttackCheck()
	{
		GameEntity targetEntity = targetComponent.target.targetEntity;
		if (!(targetEntity == null))
		{
			attackModule.AttackCheck(targetEntity);
		}
	}

	public virtual void AttackAnimationEvent(string eName)
	{
		attackModule.StartAttackEvent(eName);
	}

	internal virtual void OnKillPlayer()
	{
	}

	internal override void OnAttackHit(GameEntity hitEntity, bool hasKilled)
	{
		if (hasKilled && hitEntity.GetTagger().HasTag("Player"))
		{
			OnKillPlayer();
		}
	}

	public virtual Vector3 GetWanderPosition()
	{
		if (useNodeGraphs)
		{
			return AI_NodeGraphCreator.GetRandomNode().position;
		}
		return base.transform.position + UnityEngine.Random.insideUnitSphere * 40f;
	}

	public virtual Vector3 GetLookDirection()
	{
		if (canSeeTarget)
		{
			return Vector3.Lerp(targetComponent.target.targetTransform.position - base.transform.position, baseMovementModule.GetVelocity(), 0.2f);
		}
		return Vector3.Lerp(targetPosition - base.transform.position, baseMovementModule.GetVelocity(), 0.2f);
	}

	public override GameEntity GetTargetEntity()
	{
		if (targetComponent.HasTarget())
		{
			return targetComponent.target.targetEntity;
		}
		return null;
	}

	internal override void OnCollisionEnter(Collision collision)
	{
		if (!pickedUp && forceFalling)
		{
			forceFalling = false;
		}
		attackModule.OnCollisionEnter(collision);
	}

	public override void SetTargetPosition(Vector3 position)
	{
		navigationTargetPosition = position;
		base.SetTargetPosition(position);
	}

	public override void SetNavigationTargetPosition(Vector3 position)
	{
		navigationTargetPosition = position;
		navigator.UpdatePath(base.transform.position, navigationTargetPosition, null);
	}

	internal virtual void OnJump()
	{
		animator.SetTrigger(animJumpTrigger);
	}

	internal virtual void OnLand()
	{
		animator.SetTrigger(animLandTrigger);
	}

	public override bool Damage(Damageable.DamageInfo info)
	{
		if (!damageable)
		{
			return false;
		}
		if (dead)
		{
			return base.Damage(info);
		}
		clipHandler.PlaySound(hurtSound);
		if (info.sourceEntity != null)
		{
			disableAI = false;
			targetComponent.SetTarget(info.sourceEntity.transform);
			ChangeState(huntState.name);
		}
		damageEvent.Invoke(info);
		return base.Damage(info);
	}

	public override void Kill(string type = "", Damageable.DamageInfo damageInfo = null)
	{
		if (!dead)
		{
			clipHandler.PlaySound(deathSound);
			deathEvent.Invoke();
			if (changeLayerOnDeath != "")
			{
				base.gameObject.layer = LayerMask.NameToLayer(changeLayerOnDeath);
			}
			base.Kill(type, damageInfo);
		}
	}

	public void PlayFootstepSound()
	{
		if (!dead && baseMovementModule.GetVelocity().magnitude > footstepSoundVelocityThreshold)
		{
			clipHandler.PlaySound(footstepSound);
		}
	}

	public void Pickup()
	{
		pickedUp = true;
		forceFalling = true;
		animator.SetBool("PickedUp", value: true);
		if (!dead)
		{
			clipHandler.PlaySound(pickupSound);
		}
	}

	public void Drop()
	{
		pickedUp = false;
		forceFalling = false;
		animator.SetBool("PickedUp", value: false);
	}

	public override void SetGrappled(bool b, Grappler grappler = null)
	{
		base.SetGrappled(b, grappler);
		if (b && grappled)
		{
			Pickup();
		}
		else if (!b && !grappled)
		{
			Drop();
		}
	}

	public override void AddForce(Vector3 v, string source = "")
	{
		baseMovementModule.AddForce(v);
		base.AddForce(v, source);
	}

	public override void TonguePull(Vector3 v)
	{
		base.TonguePull(v);
		AddForce(v * 1000f);
	}

	public override DenizenMovementModule GetMovementModule()
	{
		return baseMovementModule;
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		attackModule?.DrawGizmos(base.transform);
	}

	internal override void EnterSwimZone(UT_SwimZone zone)
	{
		base.EnterSwimZone(zone);
		if (dieOnTouchWater)
		{
			Kill("drowned");
		}
	}

	public override void SetAnimationTrigger(string triggerID)
	{
		base.SetAnimationTrigger(triggerID);
		animator.SetTrigger(triggerID);
	}

	public void SetSpeedMult(float amount = 1f)
	{
		baseMovementModule.SetSpeedMult(amount);
	}
}
