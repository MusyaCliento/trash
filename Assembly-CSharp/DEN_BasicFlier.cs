using System.Collections;
using System.Collections.Generic;
using DarkMachine.AI;
using UnityEngine;
using UnityEngine.Events;

public class DEN_BasicFlier : Denizen
{
	public enum FlierAttackType
	{
		melee = 0,
		projectile = 1
	}

	public Animator animator;

	public DenizenMovement_BasicFlier movementModule;

	public AITargetComponent targetComponent;

	public AIC_SimpleCreature_Wander wanderState;

	public AIC_SimpleCreature_Hunt huntState;

	public string attackDamageTag = "flier";

	private float attackTime;

	public FlierAttackType attackType;

	public float meleeAttackBoost = 1f;

	public float meleeAttackHitDamage = 1f;

	public float meleeAttackHitForce = 1f;

	public float meleeAttackUpwardForce = 1f;

	public float meleeAttackReboundForce = 1f;

	public bool meleeAttackDropHang = true;

	public Projectile attackProjectile;

	public List<Transform> projectileOrigin;

	public int projectileCount;

	public float projectileShootDelay;

	public float projectileShootHold;

	public float rangedAttackCooldown = 1f;

	public float projectileSpread;

	private Rigidbody rigid;

	private bool attacking;

	private bool hasHit;

	internal Vector3 targetPositionOffset;

	public UnityEvent deathEvent;

	public bool destroyOnKill;

	private int lastProjectileTransform;

	public override void Start()
	{
		base.Start();
		rigid = GetComponent<Rigidbody>();
		movementModule.Initialize(this);
		movementModule.Start();
		aiStates = new List<AIStateComponent> { wanderState, huntState };
		foreach (AIStateComponent aiState in aiStates)
		{
			aiState.Initialize(this, stateVariables);
		}
		if (base.transform.lossyScale.x < 0f)
		{
			base.transform.localScale = Vector3.Scale(base.transform.localScale, new Vector3(-1f, 1f, 1f));
		}
		ChangeState("wander");
	}

	public override void Update()
	{
		base.Update();
		movementModule.SetTargetPosition(GetTargetPosition() + targetPositionOffset);
		targetPositionOffset = Vector3.zero;
		if (currentState.name == "hunt" && target != null)
		{
			movementModule.SetLookVector(target.position - base.transform.position);
		}
		else if (currentState.name == "wander")
		{
			movementModule.SetLookVector(GetLookVector());
		}
		movementModule.Update();
		currentState.Execute(this);
		targetComponent.Update();
		if (!targetComponent.HasTarget())
		{
			targetComponent.CheckForTarget(base.transform.position, sight.sightDistance);
		}
		else if (!sight.CanSeeTarget(targetComponent.target.targetTransform, checkMemory: true))
		{
			targetComponent.target.Clear();
		}
		else
		{
			target = targetComponent.target.targetTransform;
		}
		if (attacking && attackType == FlierAttackType.melee)
		{
			attackTime -= Time.deltaTime;
			if (attackTime <= 0f)
			{
				attacking = false;
				hasHit = false;
			}
		}
	}

	private void LateUpdate()
	{
	}

	internal override void AttackCheck()
	{
		if (attackType == FlierAttackType.melee)
		{
			MeleeAttack();
			clipHandler.PlaySound("denizen:attack-start");
		}
		else if (attackType == FlierAttackType.projectile && !attacking)
		{
			if (animator != null)
			{
				animator?.SetTrigger("Attack");
			}
			clipHandler.PlaySound("denizen:attack-start");
			attacking = true;
		}
	}

	public void MeleeAttack()
	{
		if (!(target == null))
		{
			Vector3 normalized = (target.position - base.transform.position).normalized;
			rigid.linearVelocity = normalized * meleeAttackBoost;
			attacking = true;
			attackTime = 2f;
			hasHit = false;
		}
	}

	private new void OnCollisionEnter(Collision collision)
	{
		if (dead || !attacking || hasHit || attackType != FlierAttackType.melee)
		{
			return;
		}
		GameEntity gameEntity = GameEntity.GetGameEntity(collision.gameObject);
		if (!(gameEntity != null))
		{
			return;
		}
		attacking = false;
		gameEntity.Damage(Damageable.DamageInfo.CreateDamageInfo(meleeAttackHitDamage, attackDamageTag));
		gameEntity.AddForce((gameEntity.transform.position - base.transform.position) * meleeAttackHitForce + Vector3.up * meleeAttackUpwardForce, "denizen");
		rigid.AddForce(collision.contacts[0].normal * meleeAttackReboundForce, ForceMode.VelocityChange);
		clipHandler.PlaySound("denizen:attack-hit");
		if (meleeAttackDropHang)
		{
			ObjectTagger objectTagger = gameEntity.GetTagger();
			ENT_Player component = gameEntity.GetComponent<ENT_Player>();
			if (objectTagger != null && objectTagger.HasTag("Player") && component != null)
			{
				component.DropHang(0.1f, 1f, cooldownOnlyOnHangingHands: false, "drop", canResist: true);
			}
		}
		hasHit = true;
		Debug.Log("has hit:" + gameEntity.name);
	}

	public override void AddForce(Vector3 v, string source = "")
	{
		rigid.AddForce(v * 10f);
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
		clipHandler.PlaySound("denizen:hurt");
		if (animator != null)
		{
			animator?.SetTrigger("Hurt");
		}
		if (info.sourceEntity != null)
		{
			targetComponent.SetTarget(info.sourceEntity.transform);
		}
		return base.Damage(info);
	}

	public override void Kill(string type = "", Damageable.DamageInfo damageInfo = null)
	{
		if (!dead)
		{
			clipHandler.PlaySound("denizen:die");
			if (animator != null)
			{
				animator?.SetBool("Dead", value: true);
				animator?.SetLayerWeight(1, 1f);
			}
			deathEvent.Invoke();
			base.gameObject.layer = LayerMask.NameToLayer("CreaturePassthrough");
			base.Kill(type, damageInfo);
			if (destroyOnKill)
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}

	public void ShootProjectile()
	{
		StartCoroutine(Shoot());
		IEnumerator Shoot()
		{
			List<Projectile> shotProjectiles = new List<Projectile>();
			for (int i = 0; i < projectileCount; i++)
			{
				Vector3 vector = base.transform.forward;
				if (target != null)
				{
					vector = (target.position - projectileOrigin[lastProjectileTransform].position).normalized;
				}
				vector = (vector + Random.insideUnitSphere * projectileSpread).normalized;
				Projectile projectile = Object.Instantiate(attackProjectile, projectileOrigin[lastProjectileTransform].position, Quaternion.LookRotation(vector));
				projectile.Initialize(vector, this);
				projectile.AddIgnore(base.gameObject);
				shotProjectiles.Add(projectile);
				if (projectileShootHold > 0f)
				{
					projectile.SetVelocityMultiplier(0f);
				}
				if (projectileShootDelay > 0f)
				{
					yield return new WaitForSeconds(projectileShootDelay);
				}
				lastProjectileTransform++;
				if (lastProjectileTransform >= projectileOrigin.Count)
				{
					lastProjectileTransform = 0;
				}
			}
			if (projectileShootHold > 0f)
			{
				yield return new WaitForSeconds(projectileShootHold);
				for (int i = 0; i < projectileCount; i++)
				{
					if (shotProjectiles[i] != null)
					{
						shotProjectiles[i].SetVelocityMultiplier(1f);
						if (target != null)
						{
							Vector3 normalized = (target.position - shotProjectiles[i].transform.position).normalized;
							normalized = (normalized + Random.insideUnitSphere * projectileSpread).normalized;
							shotProjectiles[i].Initialize(normalized, this);
						}
						yield return new WaitForSeconds(projectileShootDelay);
					}
				}
			}
			yield return new WaitForSeconds(rangedAttackCooldown);
			attacking = false;
		}
	}

	public void SetHome()
	{
		wanderState.SetHomePosition(base.transform.position);
	}

	public override DenizenMovementModule GetMovementModule()
	{
		return movementModule;
	}
}
