using System;
using System.Collections;
using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class DenizenAttackModule_Basic : DenizenAttackModule
{
	[Serializable]
	public class AttackClass
	{
		public enum AttackType
		{
			melee = 0,
			projectile = 1,
			charge = 2,
			none = 3
		}

		private DenizenAttackModule_Basic attackModule;

		private Denizen denizen;

		public string attackID;

		public bool active = true;

		public bool blockLowerAttacks;

		public SpawnTable.SpawnSettings attackChance;

		public string attackTypeTag = "denizen";

		public List<string> attackTaglist;

		public bool canMoveWhileAttacking;

		public bool canTurnWhileAttacking = true;

		public bool canAttackWhileAirborn = true;

		public bool useProjectileOriginForAttackAngle;

		public float maxAttackAngle = 360f;

		public Vector3 attackAngleDirection = Vector3.forward;

		public bool stopAttackOnDeath = true;

		public int maxAttackAmmo = -1;

		private int curAttackAmmo = -1;

		public bool canReloadAmmo = true;

		public bool canMoveWhileReloading;

		public UnityEvent eventOnReloadStart;

		public UnityEvent eventOnReloadFinish;

		public float reloadTime = 1f;

		public float reloadRecoveryTime = 1f;

		public string attackAnimationTrigger = "Attack";

		public string attackFinishAnimationTrigger = "";

		public string chargeAnimationBool = "Charging";

		public string chargeHitAnimationTrigger = "ChargeHit";

		public Vector3 attackStartMoveVector;

		public float attackStartMoveTime = 1f;

		public AnimationCurve attackStartMoveCurve = AnimationCurve.Constant(0f, 1f, 1f);

		public Vector3 attackActivateMoveVector;

		public float attackActivateMoveTime = 1f;

		public AnimationCurve attackActivateMoveCurve = AnimationCurve.Constant(0f, 1f, 1f);

		public string reloadAnimationBool = "Reloading";

		public string attackSpinupAnimationTrigger = "";

		[Tooltip("Sound played when the attack begins.")]
		public string attackSound = "denizen:attack-start";

		[Tooltip("Sound played when the attack hits.")]
		public string attackHitSound = "denizen:attack-hit";

		[Tooltip("Sound played when the attack misses.")]
		public string attackMissSound = "denizen:attack-miss";

		[Tooltip("Sound played when the attack is activated, which may be different from the attack start sound if waitForAttackStart is true.")]
		public string attackActivateSound = "denizen:attack-activate";

		[Tooltip("Played when each individual projectile is shot.")]
		public string projectileShootSound = "";

		[Tooltip("Sound played when the spinup begins.")]
		public string spinupSound = "denizen:spinup-start";

		[Tooltip("Sound played when the spinup begins.")]
		public string reloadStartSound = "denizen:reload-start";

		[Tooltip("Sound played when the spinup begins.")]
		public string reloadEndSound = "denizen:reload-end";

		public AttackType attackType;

		public float attackCooldown = 2f;

		[Tooltip("Prevents the Denizen from moving after attacking.")]
		public float attackRecovery;

		[Tooltip("If we aren't using an animation callback, use a delay instead.")]
		public bool waitForAttackStart = true;

		[Tooltip("If we aren't using an animation callback, how long until the attack should fire?")]
		public float attackStartDelay;

		[Tooltip("How long for the first attack to spin up, before we use normal cooldown.")]
		public float attackSpinupDelay;

		[Tooltip("Cooldown spinup time. (Adds extra time to cooldown)")]
		public float attackSpinupCooldown;

		private float lastAttackTime;

		private float spinupStartTime;

		private float attackStartTime;

		private float curSpinup;

		private float curCooldownSpinup;

		public bool canHit = true;

		public Transform customMeleeHitOrigin;

		[Header("Melee/Charge Attack Variables")]
		public float meleeAttackHitDamage = 1f;

		public float meleeAttackHitForce = 1f;

		public float meleeAttackHitUpForce;

		public float meleeAttackDistance = 1f;

		public bool meleeAttackDropHang = true;

		public float dropHangMinimumStaminaThreshhold = -1f;

		public float meleeStaminaDamage;

		public bool meleeStaminaDamageOnlyToActiveHands = true;

		public BoxCollider meleeHitbox;

		public LayerMask meleeHitLayerMask;

		[Header("Charge Attack Variables")]
		public float chargeAttackDistance = 5f;

		public float chargeAttackBeginWait = 1f;

		public bool chargeAttackUsesMovementJump = true;

		public float attackJumpHeight = 1f;

		public float attackLeapForce = 5f;

		public float attackJumpHeightTargetMod = 0.5f;

		public float chargeAttackDelay;

		public float chargeAttackBoost = 1f;

		public float chargeAttackReboundForce = 1f;

		public UnityEvent<Collision, GameEntity> onChargeHit;

		public List<string> chargeHitIgnoreTags = new List<string>();

		public float projectileMaximumAttackDistance = 40f;

		public float projectileMinimumAttackDistance;

		public float projectileLeadAmount;

		[Header("Projectile Attack Variables")]
		public Projectile attackProjectile;

		public List<Transform> projectileOrigin;

		public int projectileCount;

		public float projectileShootDelay;

		public float projectileShootHold;

		public float rangedAttackCooldown = 1f;

		public float projectileSpread;

		[Range(0f, 1f)]
		public float forwardVectorBlend;

		public float projectileDamageMult = 1f;

		public bool useProjectileDamageOverride;

		public float projectileDamageOverride = 1f;

		public AnimationCurve projectileBloom = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 1f));

		public UnityEvent attackStartEvent;

		public UnityEvent attackHitEvent;

		public UnityEvent attackActivateEvent;

		public UnityEvent meleeAttackEndEvent;

		public bool useHitBuff;

		public BuffContainer attackHitBuff;

		private bool inRange;

		private float inRangeTime;

		private int lastProjectileTransform;

		internal bool isAttacking;

		internal bool isReloading;

		private bool isSpinningUp;

		public float attackTimeoutTime = 5f;

		private Coroutine recoveryCoroutine;

		private List<Coroutine> activeCoroutines = new List<Coroutine>();

		private Coroutine curMoveOverTimeCoroutine;

		public void Initialize(DenizenAttackModule_Basic attackModule)
		{
			this.attackModule = attackModule;
			denizen = attackModule.denizen;
			curAttackAmmo = maxAttackAmmo;
		}

		public void ReadyAttack()
		{
			float num = Time.time - lastAttackTime;
			if (attackSpinupDelay > 0f)
			{
				if (spinupStartTime < Time.time && num > attackCooldown * 2f && !isAttacking)
				{
					spinupStartTime = Time.time + attackSpinupDelay;
					lastAttackTime = Time.time;
					attackModule.denizen.clipHandler?.PlaySound(spinupSound);
					isAttacking = true;
					attackModule.attackCooldownTime = Time.time + attackCooldown;
					attackModule.attackStartTime = Time.time;
					isSpinningUp = true;
					attackStartTime = Time.time;
					if (attackModule.animator != null && attackSpinupAnimationTrigger != "")
					{
						attackModule.animator?.SetTrigger(attackSpinupAnimationTrigger);
					}
					return;
				}
				if (spinupStartTime >= Time.time)
				{
					lastAttackTime = Time.time;
					isSpinningUp = true;
					return;
				}
			}
			isSpinningUp = false;
		}

		public void Attack()
		{
			if (isSpinningUp)
			{
				return;
			}
			if (curAttackAmmo > 0)
			{
				curAttackAmmo--;
			}
			StopAttack();
			isAttacking = true;
			lastAttackTime = Time.time;
			attackStartTime = Time.time;
			attackModule.attackCooldownTime = Time.time + attackCooldown;
			if (attackType == AttackType.projectile && projectileShootDelay > 0f)
			{
				attackModule.attackCooldownTime += rangedAttackCooldown + projectileShootDelay * (float)projectileCount;
			}
			attackModule.attackStartTime = Time.time;
			DenizenMovementModule movementModule = denizen.GetMovementModule();
			if (movementModule != null && !canMoveWhileAttacking)
			{
				movementModule.canMove = false;
			}
			if (movementModule != null && !canTurnWhileAttacking)
			{
				movementModule.canRotate = false;
			}
			if (attackType == AttackType.charge)
			{
				Debug.Log("Attacking with a charge!");
				ChargeAttack();
				attackModule.denizen.clipHandler?.PlaySound(attackSound);
				attackModule.currentAttack = this;
			}
			else if (attackType == AttackType.projectile)
			{
				if (!attackModule.attacking)
				{
					if (attackModule.animator != null && attackAnimationTrigger != "")
					{
						attackModule.animator?.SetTrigger(attackAnimationTrigger);
					}
					attackModule.denizen?.clipHandler?.PlaySound(attackSound);
					attackModule.attacking = true;
					attackModule.currentAttack = this;
					if (!waitForAttackStart)
					{
						if (attackStartDelay > 0f)
						{
							activeCoroutines.Add(attackModule.denizen.StartCoroutine(DelayedAttack()));
						}
						else
						{
							AttackActivate();
						}
					}
				}
			}
			else if (attackType == AttackType.melee)
			{
				if (!attackModule.attacking)
				{
					if (attackModule.animator != null && attackAnimationTrigger != "")
					{
						attackModule.animator?.SetTrigger(attackAnimationTrigger);
					}
					attackModule.denizen.clipHandler?.PlaySound(attackSound);
					attackModule.attacking = true;
					attackModule.currentAttack = this;
					if (!waitForAttackStart)
					{
						if (attackStartDelay > 0f)
						{
							activeCoroutines.Add(attackModule.denizen.StartCoroutine(DelayedAttack()));
						}
						else
						{
							AttackActivate();
						}
					}
				}
			}
			else
			{
				activeCoroutines.Add(attackModule.denizen.StartCoroutine(WaitUntilAttackFinish()));
			}
			if (attackStartMoveVector != Vector3.zero)
			{
				if (curMoveOverTimeCoroutine != null)
				{
					attackModule.denizen.StopCoroutine(curMoveOverTimeCoroutine);
				}
				curMoveOverTimeCoroutine = attackModule.denizen.StartCoroutine(MoveOverTime(attackModule.denizen.transform.TransformVector(attackStartMoveVector), attackStartMoveTime, attackStartMoveCurve));
			}
			attackStartEvent.Invoke();
			IEnumerator DelayedAttack()
			{
				yield return new WaitForSeconds(attackStartDelay);
				AttackActivate();
			}
			IEnumerator WaitUntilAttackFinish()
			{
				yield return new WaitForSeconds(attackCooldown);
				attackModule.attacking = false;
				isAttacking = false;
				if (attackModule.animator != null && attackFinishAnimationTrigger != "")
				{
					attackModule.animator?.SetTrigger(attackFinishAnimationTrigger);
				}
			}
		}

		public void ChargeAttack(bool force = false, bool leap = true)
		{
			if (!attackModule.denizen.dead)
			{
				activeCoroutines.Add(attackModule.denizen.StartCoroutine(ChargeAttackWait()));
			}
			IEnumerator ChargeAttackWait()
			{
				if (attackModule.animator != null)
				{
					attackModule?.animator?.SetBool(chargeAnimationBool, value: true);
				}
				yield return new WaitForSeconds(chargeAttackDelay);
				if (!attackModule.denizen.dead)
				{
					attackModule.denizen.clipHandler?.PlaySound(attackActivateSound);
					DenizenMovementModule movementModule = attackModule.denizen.GetMovementModule();
					movementModule?.Jump(0f);
					Vector3 a = attackModule.GetCurrentTargetPosition() - attackModule.denizen.transform.position;
					a = Vector3.Scale(a, new Vector3(1f, 0.5f, 1f));
					Vector3 normalized = a.normalized;
					if (leap)
					{
						attackModule.rigid.linearVelocity = normalized * chargeAttackBoost;
					}
					attackModule.attacking = true;
					attackModule.hasHit = false;
					if ((chargeAttackUsesMovementJump && movementModule != null && (movementModule.IsGrounded() || attackModule.denizen.IsInWater()) && a.magnitude < 5f) || force)
					{
						float num = Mathf.Clamp((attackModule.GetCurrentTargetPosition().y - attackModule.denizen.transform.position.y) * attackJumpHeightTargetMod, 1f, 5f);
						if (leap)
						{
							movementModule.Jump(attackJumpHeight * num, attackLeapForce);
						}
						else
						{
							movementModule.Jump(0f);
						}
					}
					else
					{
						movementModule.Jump(0f);
					}
				}
			}
		}

		internal virtual void OnAttackHit(GameEntity hitEntity)
		{
			if (canHit)
			{
				if (attackType == AttackType.melee || attackType == AttackType.charge)
				{
					bool hasKilled = hitEntity.Damage(Damageable.DamageInfo.CreateDamageInfo(meleeAttackHitDamage, attackTypeTag, attackTaglist, denizen));
					Transform transform = denizen.transform;
					if (customMeleeHitOrigin != null)
					{
						transform = customMeleeHitOrigin;
					}
					hitEntity.AddForce(transform.forward * meleeAttackHitForce + Vector3.up * meleeAttackHitUpForce, "denizen");
					denizen.OnAttackHit(hitEntity, hasKilled);
				}
				if (useHitBuff)
				{
					hitEntity.AddNewBuff(attackHitBuff.CopyBuffContainer());
				}
			}
			denizen.clipHandler?.PlaySound(attackHitSound);
			attackHitEvent.Invoke();
		}

		internal virtual void OnProjectileHitEntity(Projectile hitProjectile, RaycastHit hit, GameEntity hitEntity, Damageable.DamageInfo hitInfo)
		{
			if (useHitBuff)
			{
				hitEntity.AddNewBuff(attackHitBuff.CopyBuffContainer());
			}
		}

		internal virtual void OnProjectileHit(Projectile hitProjectile, RaycastHit hit, ObjectTagger hitTagger)
		{
		}

		public virtual void AttackActivate()
		{
			if (denizen.dead)
			{
				attackModule.attacking = false;
				isAttacking = false;
				return;
			}
			attackModule.denizen.clipHandler?.PlaySound(attackActivateSound);
			if (attackType == AttackType.melee)
			{
				MeleeHitCheck();
			}
			else if (attackType != AttackType.charge && attackType == AttackType.projectile)
			{
				ShootProjectile();
			}
			DenizenMovementModule movementModule = denizen.GetMovementModule();
			if (movementModule != null && (!canMoveWhileAttacking || !canTurnWhileAttacking))
			{
				if (recoveryCoroutine != null)
				{
					denizen.StopCoroutine(recoveryCoroutine);
				}
				if (attackRecovery > 0f)
				{
					recoveryCoroutine = denizen.StartCoroutine(Recovery());
				}
				else
				{
					if (!canMoveWhileAttacking)
					{
						movementModule.canMove = true;
					}
					if (!canTurnWhileAttacking)
					{
						movementModule.canRotate = true;
					}
				}
			}
			attackActivateEvent.Invoke();
			if (attackActivateMoveVector != Vector3.zero)
			{
				if (curMoveOverTimeCoroutine != null)
				{
					attackModule.denizen.StopCoroutine(curMoveOverTimeCoroutine);
				}
				curMoveOverTimeCoroutine = attackModule.denizen.StartCoroutine(MoveOverTime(attackModule.denizen.transform.TransformVector(attackStartMoveVector), attackActivateMoveTime, attackActivateMoveCurve));
			}
			IEnumerator Recovery()
			{
				yield return new WaitForSeconds(attackRecovery);
				if (!canMoveWhileAttacking)
				{
					movementModule.canMove = true;
				}
				if (!canTurnWhileAttacking)
				{
					movementModule.canRotate = true;
				}
			}
		}

		public virtual void MeleeHitCheck()
		{
			if (meleeHitbox != null)
			{
				Collider[] array = Physics.OverlapBox(meleeHitbox.transform.position, meleeHitbox.size / 2f, meleeHitbox.transform.rotation, meleeHitLayerMask);
				bool flag = false;
				Collider[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					GameEntity component = array2[i].GetComponent<GameEntity>();
					if (!(component != null))
					{
						continue;
					}
					if (meleeAttackDropHang || meleeStaminaDamage > 0f)
					{
						ENT_Player component2 = component.GetComponent<ENT_Player>();
						if (component2 != null)
						{
							if (meleeAttackDropHang && (dropHangMinimumStaminaThreshhold < 0f || component2.GetAverageGripStrength(onlyHangingHands: true) < dropHangMinimumStaminaThreshhold))
							{
								component2.DropHang(0.1f, 1f, cooldownOnlyOnHangingHands: false, "drop", canResist: true);
							}
							component2.DamageGripStrength(meleeStaminaDamage, meleeStaminaDamageOnlyToActiveHands);
						}
					}
					flag = true;
					OnAttackHit(component);
				}
				if (!flag)
				{
					denizen.clipHandler?.PlaySound(attackMissSound);
				}
			}
			else
			{
				Transform transform = attackModule.denizen.transform;
				if (customMeleeHitOrigin != null)
				{
					transform = customMeleeHitOrigin;
				}
				Vector3 b = transform.position + transform.forward * 2f;
				GameEntity targetEntity = attackModule.denizen.GetTargetEntity();
				bool flag2 = targetEntity != null;
				if (flag2)
				{
					b = targetEntity.transform.position;
				}
				if (!IsInAttackAngle(targetEntity))
				{
					attackModule.denizen.clipHandler?.PlaySound(attackMissSound);
					return;
				}
				if (Vector3.Distance(transform.position, b) < meleeAttackDistance && flag2)
				{
					OnAttackHit(targetEntity);
					if (meleeAttackDropHang || meleeStaminaDamage > 0f)
					{
						ENT_Player component3 = targetEntity.GetComponent<ENT_Player>();
						if (component3 != null)
						{
							if (meleeAttackDropHang && (dropHangMinimumStaminaThreshhold < 0f || component3.GetAverageGripStrength(onlyHangingHands: true) < dropHangMinimumStaminaThreshhold))
							{
								component3.DropHang(0.1f, 1f, cooldownOnlyOnHangingHands: false, "drop", canResist: true);
							}
							component3.DamageGripStrength(meleeStaminaDamage, meleeStaminaDamageOnlyToActiveHands);
						}
					}
				}
				else
				{
					denizen.clipHandler?.PlaySound(attackMissSound);
				}
			}
			activeCoroutines.Add(attackModule.denizen.StartCoroutine(WaitUntilAttackFinish()));
			meleeAttackEndEvent.Invoke();
			IEnumerator WaitUntilAttackFinish()
			{
				yield return new WaitForSeconds(attackCooldown);
				attackModule.attacking = false;
				isAttacking = false;
			}
		}

		public void ShootProjectile()
		{
			activeCoroutines.Add(attackModule.denizen.StartCoroutine(WaitUntilAttackFinish()));
			activeCoroutines.Add(attackModule.denizen.StartCoroutine(Shoot()));
			IEnumerator Shoot()
			{
				List<Projectile> shotProjectiles = new List<Projectile>();
				for (int i = 0; i < projectileCount; i++)
				{
					if (stopAttackOnDeath && denizen.dead)
					{
						yield break;
					}
					Vector3 a = attackModule.denizen.transform.forward;
					if (attackModule.denizen.target != null)
					{
						GameEntity targetEntity = attackModule.denizen.GetTargetEntity();
						Vector3 vector = Vector3.zero;
						if (targetEntity != null && projectileLeadAmount > 0f)
						{
							vector = targetEntity.GetTrueVelocity() * projectileLeadAmount;
						}
						a = (attackModule.GetCurrentTargetPosition() + vector - projectileOrigin[lastProjectileTransform].position).normalized;
					}
					float num = 1f;
					if (projectileCount > 1)
					{
						num = projectileBloom.Evaluate((float)i / (float)(projectileCount - 1));
					}
					a = Vector3.Lerp(a, projectileOrigin[lastProjectileTransform].forward, forwardVectorBlend);
					a = (a + UnityEngine.Random.insideUnitSphere * projectileSpread * num).normalized;
					Projectile projectile = UnityEngine.Object.Instantiate(attackProjectile, projectileOrigin[lastProjectileTransform].position, Quaternion.LookRotation(a));
					projectile.Initialize(a, attackModule.denizen);
					if (useProjectileDamageOverride)
					{
						projectile.damage = projectileDamageOverride;
					}
					projectile.damage *= projectileDamageMult;
					projectile._OnProjectileHit = (Action<Projectile, RaycastHit, ObjectTagger>)Delegate.Combine(projectile._OnProjectileHit, new Action<Projectile, RaycastHit, ObjectTagger>(OnProjectileHit));
					projectile._OnProjectileHitGameEntity = (Action<Projectile, RaycastHit, GameEntity, Damageable.DamageInfo>)Delegate.Combine(projectile._OnProjectileHitGameEntity, new Action<Projectile, RaycastHit, GameEntity, Damageable.DamageInfo>(OnProjectileHitEntity));
					if (attackModule.denizen.target != null)
					{
						projectile.SetTarget(attackModule.denizen.target);
					}
					attackModule.denizen.clipHandler?.PlaySound(projectileShootSound);
					projectile.AddIgnore(attackModule.denizen.gameObject);
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
						if (stopAttackOnDeath && denizen.dead)
						{
							yield break;
						}
						if (shotProjectiles[i] != null)
						{
							shotProjectiles[i].SetVelocityMultiplier(1f);
							Vector3 normalized = (attackModule.GetCurrentTargetPosition() - shotProjectiles[i].transform.position).normalized;
							float num2 = 1f;
							if (projectileCount > 1)
							{
								num2 = projectileBloom.Evaluate(i / (projectileCount - 1));
							}
							normalized = (normalized + UnityEngine.Random.insideUnitSphere * projectileSpread * num2).normalized;
							shotProjectiles[i].Initialize(normalized, attackModule.denizen);
							yield return new WaitForSeconds(projectileShootDelay);
						}
					}
				}
				if (attackModule.animator != null && attackFinishAnimationTrigger != "")
				{
					attackModule.animator?.SetTrigger(attackFinishAnimationTrigger);
				}
			}
			IEnumerator WaitUntilAttackFinish()
			{
				yield return new WaitForSeconds(attackCooldown);
				attackModule.attacking = false;
				isAttacking = false;
			}
		}

		public bool TryAttack(GameEntity targetEntity, bool force = false)
		{
			if (CanAttack(targetEntity, force))
			{
				if (maxAttackAmmo > 0 && curAttackAmmo <= 0)
				{
					if (canReloadAmmo)
					{
						StartReload();
						return true;
					}
					return false;
				}
				ReadyAttack();
				if (attackModule.attacking)
				{
					return false;
				}
				Attack();
				return true;
			}
			return false;
		}

		public bool CanAttack(GameEntity targetEntity, bool force = false)
		{
			if (!active)
			{
				return false;
			}
			if (!attackChance.RandomCheck())
			{
				return false;
			}
			if (force)
			{
				return true;
			}
			if (!IsInAttackAngle(targetEntity))
			{
				return false;
			}
			if (attackModule.attackStartTime + 5f < Time.time)
			{
				attackModule.attacking = false;
				isAttacking = false;
				isReloading = false;
			}
			if (attackModule.attackCooldownTime < Time.time && attackType == AttackType.charge)
			{
				attackModule.attacking = false;
				isAttacking = false;
				isReloading = false;
			}
			if (attackModule.attacking || attackModule.attackCooldownTime > Time.time)
			{
				return false;
			}
			if (isReloading)
			{
				return false;
			}
			if (!canAttackWhileAirborn)
			{
				DenizenMovementModule movementModule = denizen.GetMovementModule();
				if (movementModule != null && !movementModule.IsGrounded())
				{
					return false;
				}
			}
			if (attackType == AttackType.melee)
			{
				if (targetEntity == null)
				{
					return false;
				}
				Transform transform = attackModule.denizen.transform;
				if (customMeleeHitOrigin != null)
				{
					transform = customMeleeHitOrigin;
				}
				if (Vector3.Distance(transform.position, targetEntity.transform.position) > meleeAttackDistance)
				{
					inRange = false;
					return false;
				}
				if (!inRange)
				{
					inRange = true;
				}
			}
			else
			{
				if (attackType == AttackType.charge)
				{
					if (attackModule.rigid.linearVelocity.magnitude <= 0.1f || attackModule.denizen.GetMovementModule().IsGrounded())
					{
						attackModule.attacking = false;
						isAttacking = false;
					}
					if (targetEntity == null)
					{
						return false;
					}
					if (Vector3.Distance(attackModule.denizen.transform.position, targetEntity.transform.position) > chargeAttackDistance)
					{
						inRange = false;
						return false;
					}
					if (!inRange)
					{
						inRange = true;
						inRangeTime = Time.time;
					}
					if (inRange && Time.time - inRangeTime > chargeAttackBeginWait)
					{
						return true;
					}
					return false;
				}
				if (attackType == AttackType.projectile)
				{
					if (targetEntity == null)
					{
						return false;
					}
					float num = Vector3.Distance(attackModule.denizen.transform.position, targetEntity.transform.position);
					if (num > projectileMaximumAttackDistance || num < projectileMinimumAttackDistance)
					{
						inRange = false;
						return false;
					}
				}
			}
			return true;
		}

		public bool IsInAttackAngle(GameEntity targetEntity)
		{
			if (targetEntity == null)
			{
				return false;
			}
			Transform transform = attackModule.denizen.transform;
			if (useProjectileOriginForAttackAngle)
			{
				transform = projectileOrigin[0];
			}
			if (customMeleeHitOrigin != null)
			{
				transform = customMeleeHitOrigin;
			}
			if (Vector3.Angle(GetWorldForwardVector(transform), targetEntity.transform.position - transform.position) > maxAttackAngle)
			{
				return false;
			}
			return true;
		}

		public Vector3 GetWorldForwardVector(Transform transform)
		{
			return transform.TransformVector(attackAngleDirection.normalized);
		}

		public bool IsSpinningUp()
		{
			return isSpinningUp;
		}

		public bool AttackTimeoutCheck()
		{
			if (Time.time - attackStartTime > attackTimeoutTime)
			{
				isAttacking = false;
				return true;
			}
			return false;
		}

		private void StartReload()
		{
			attackModule.denizen.StartCoroutine(ReloadCoroutine());
			attackModule.attackCooldownTime = Time.time + reloadTime + reloadRecoveryTime;
			IEnumerator ReloadCoroutine()
			{
				isReloading = true;
				eventOnReloadStart.Invoke();
				if (reloadAnimationBool != "")
				{
					attackModule.animator.SetBool(reloadAnimationBool, value: true);
				}
				denizen.clipHandler.PlaySound(reloadStartSound);
				if (!canMoveWhileReloading)
				{
					denizen.GetMovementModule().canMove = false;
				}
				yield return new WaitForSeconds(reloadTime);
				if (!canMoveWhileReloading)
				{
					denizen.GetMovementModule().canMove = true;
				}
				eventOnReloadFinish.Invoke();
				if (reloadAnimationBool != "")
				{
					attackModule.animator.SetBool(reloadAnimationBool, value: false);
				}
				denizen.clipHandler.PlaySound(reloadEndSound);
				curAttackAmmo = maxAttackAmmo;
				yield return new WaitForSeconds(reloadRecoveryTime);
				isReloading = false;
			}
		}

		public void StopAttack()
		{
			isAttacking = false;
			isSpinningUp = false;
			foreach (Coroutine activeCoroutine in activeCoroutines)
			{
				if (activeCoroutine != null)
				{
					denizen.StopCoroutine(activeCoroutine);
				}
			}
			activeCoroutines.Clear();
		}

		private IEnumerator MoveOverTime(Vector3 movement, float time, AnimationCurve curve)
		{
			float animRate = 1f / time;
			float timer = 0f;
			while (timer < 1f)
			{
				Vector3 vector = movement * Time.deltaTime * curve.Evaluate(timer);
				if (attackModule.rigid != null)
				{
					attackModule.rigid.MovePosition(attackModule.rigid.transform.position + vector);
				}
				else
				{
					attackModule.denizen.transform.position += vector;
				}
				timer += Time.deltaTime * animRate;
				yield return null;
			}
		}
	}

	public List<AttackClass> attacks = new List<AttackClass>();

	private bool attacking;

	private bool hasHit;

	private float attackStartTime;

	private float attackCooldownTime;

	private AttackClass currentAttack;

	private Rigidbody rigid;

	public Animator animator;

	private int lastCustomTargetPositionFrame;

	internal Vector3 customTargetPosition;

	public override void Initialize(Denizen denizen)
	{
		base.Initialize(denizen);
		rigid = denizen.GetComponent<Rigidbody>();
		foreach (AttackClass attack in attacks)
		{
			attack.Initialize(this);
		}
	}

	public override void AttackCheck(GameEntity targetEntity)
	{
		base.AttackCheck(targetEntity);
		if (Time.time < attackCooldownTime)
		{
			return;
		}
		foreach (AttackClass attack in attacks)
		{
			if (attack.isAttacking || attack.isReloading)
			{
				if (attack.IsSpinningUp())
				{
					attack.ReadyAttack();
					currentAttack = attack;
					attack.Attack();
				}
				if (!attack.AttackTimeoutCheck())
				{
					return;
				}
			}
		}
		foreach (AttackClass attack2 in attacks)
		{
			if (attack2.TryAttack(targetEntity))
			{
				currentAttack = attack2;
				break;
			}
			if (attack2.blockLowerAttacks && attack2.isAttacking)
			{
				break;
			}
		}
	}

	public override void Attack(GameEntity targetEntity, string attackID = "")
	{
		base.Attack(targetEntity, attackID);
		foreach (AttackClass attack in attacks)
		{
			if ((!(attackID != "") || !(attackID != attack.attackID)) && (attack.isAttacking || attack.isReloading))
			{
				if (attack.IsSpinningUp())
				{
					attack.ReadyAttack();
					currentAttack = attack;
					attack.Attack();
				}
				return;
			}
		}
		foreach (AttackClass attack2 in attacks)
		{
			if (!(attackID != "") || !(attackID != attack2.attackID))
			{
				if (attack2.TryAttack(targetEntity, force: true) && !attack2.isAttacking)
				{
					currentAttack = attack2;
					break;
				}
				if (attack2.blockLowerAttacks && attack2.isAttacking)
				{
					break;
				}
			}
		}
	}

	public override void StopAllAttacks()
	{
		base.StopAllAttacks();
		currentAttack = null;
		foreach (AttackClass attack in attacks)
		{
			attack.StopAttack();
		}
	}

	public override void StartAttackEvent(string eventName)
	{
		base.StartAttackEvent(eventName);
		if (currentAttack != null)
		{
			currentAttack.AttackActivate();
		}
	}

	public override void OnCollisionEnter(Collision collision)
	{
		base.OnCollisionEnter(collision);
		if (denizen == null || denizen.dead || !attacking || hasHit || currentAttack.attackType != AttackClass.AttackType.charge)
		{
			return;
		}
		if (animator != null)
		{
			animator?.SetTrigger(currentAttack.chargeHitAnimationTrigger);
		}
		if (animator != null)
		{
			animator?.SetBool(currentAttack.chargeAnimationBool, value: false);
		}
		GameEntity gameEntity = GameEntity.GetGameEntity(collision.gameObject);
		if (gameEntity != null)
		{
			if (gameEntity.GetTagger().HasTagInList(currentAttack.chargeHitIgnoreTags.ToArray()))
			{
				return;
			}
			attacking = false;
			currentAttack.isAttacking = false;
			float num = 1f;
			float num2 = 1f;
			if (CL_GameManager.IsHardmode())
			{
				num2 = 1.7f;
				num = 2f;
			}
			gameEntity.Damage(Damageable.DamageInfo.CreateDamageInfo(currentAttack.meleeAttackHitDamage * num, currentAttack.attackTypeTag, currentAttack.attackTaglist, denizen));
			gameEntity.AddForce((gameEntity.transform.position - denizen.transform.position) * currentAttack.meleeAttackHitForce * num2 + Vector3.up * currentAttack.meleeAttackHitUpForce, "denizen");
			rigid.AddForce(collision.contacts[0].normal * currentAttack.chargeAttackReboundForce, ForceMode.VelocityChange);
			denizen.clipHandler?.PlaySound(currentAttack.attackHitSound);
			if (currentAttack.meleeAttackDropHang || currentAttack.meleeStaminaDamage > 0f)
			{
				ENT_Player component = gameEntity.GetComponent<ENT_Player>();
				if (component != null)
				{
					Debug.Log("Player Stamina Threshhold: " + currentAttack.dropHangMinimumStaminaThreshhold + " Player Average Grip Strength: " + component.GetAverageGripStrength(onlyHangingHands: true));
					if (currentAttack.meleeAttackDropHang && (currentAttack.dropHangMinimumStaminaThreshhold < 0f || component.GetAverageGripStrength(onlyHangingHands: true) < currentAttack.dropHangMinimumStaminaThreshhold))
					{
						component.DropHangWithThreshold(currentAttack.dropHangMinimumStaminaThreshhold, 1f, cooldownOnlyOnHangingHands: false, "drop", canResist: true);
					}
					component.DamageGripStrength(currentAttack.meleeStaminaDamage, currentAttack.meleeStaminaDamageOnlyToActiveHands);
				}
			}
			hasHit = true;
			Debug.Log("has hit:" + gameEntity.name);
			currentAttack.onChargeHit.Invoke(collision, gameEntity);
		}
		else
		{
			attacking = false;
			currentAttack.isAttacking = false;
		}
	}

	public void ForceChargeAttack(bool leap = true)
	{
		for (int i = 0; i < attacks.Count; i++)
		{
			if (attacks[i].attackType == AttackClass.AttackType.charge)
			{
				currentAttack = attacks[i];
				currentAttack.ChargeAttack(force: true, leap);
				break;
			}
		}
	}

	public override void RecieveCommand(string command)
	{
		string[] array = command.Split(':');
		if (!(array[0] == "setActive") || array.Length <= 2)
		{
			return;
		}
		string text = array[1];
		if (!bool.TryParse(array[2], out var result))
		{
			return;
		}
		foreach (AttackClass attack in attacks)
		{
			if (attack.attackID == text)
			{
				attack.active = result;
				break;
			}
		}
	}

	public override void DrawGizmos(Transform entityTransform)
	{
		foreach (AttackClass attack in attacks)
		{
			if (attack.attackType == AttackClass.AttackType.melee)
			{
				Transform transform = entityTransform.transform;
				if (attack.customMeleeHitOrigin != null)
				{
					transform = attack.customMeleeHitOrigin;
				}
				Draw.Circle(transform.position, transform.up, attack.meleeAttackDistance, Color.red);
				Draw.Arrow(transform.position, transform.position + attack.GetWorldForwardVector(transform) * attack.meleeAttackDistance, Color.red);
				Vector3 worldForwardVector = attack.GetWorldForwardVector(transform);
				Vector3 vector = Quaternion.AngleAxis(attack.maxAttackAngle, transform.up) * worldForwardVector;
				Vector3 vector2 = Quaternion.AngleAxis(0f - attack.maxAttackAngle, transform.up) * worldForwardVector;
				Draw.Line(transform.position, transform.position + vector * attack.meleeAttackDistance, Color.yellow);
				Draw.Line(transform.position, transform.position + vector2 * attack.meleeAttackDistance, Color.yellow);
			}
			else if (attack.attackType == AttackClass.AttackType.charge)
			{
				Draw.Circle(entityTransform.position, entityTransform.up, attack.chargeAttackDistance, Color.blue);
				Draw.Arrow(entityTransform.position, entityTransform.position + attack.GetWorldForwardVector(entityTransform) * attack.chargeAttackDistance, Color.blue);
			}
			else
			{
				if (attack.attackType != AttackClass.AttackType.projectile)
				{
					continue;
				}
				foreach (Transform item in attack.projectileOrigin)
				{
					Draw.Circle(item.position, item.up, 0.2f, Color.green);
				}
			}
		}
	}

	public Vector3 GetCurrentTargetPosition()
	{
		bool flag = false;
		if (Time.frameCount <= lastCustomTargetPositionFrame)
		{
			flag = true;
		}
		if (!flag && denizen.target != null)
		{
			return denizen.target.position;
		}
		if (flag)
		{
			return customTargetPosition;
		}
		return denizen.transform.position + denizen.transform.forward * 10f;
	}

	public void SetCustomTargetPositionForNextFrame(Vector3 pos)
	{
		lastCustomTargetPositionFrame = Time.frameCount + 1;
		customTargetPosition = pos;
	}
}
