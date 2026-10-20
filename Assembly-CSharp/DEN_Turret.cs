using DarkMachine.AI;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class DEN_Turret : Denizen, Activatable
{
	public bool active = true;

	public float lookSpeed = 1f;

	public float maxTurnAngle = 90f;

	public float maxShootAngle = 10f;

	public float maxRange = 15f;

	public float shootSpeed = 1f;

	private float shootTime;

	public float shootDelay = 0.5f;

	private float shootDelayTime;

	[Header("Aim")]
	public float bulletSpread = 0.1f;

	public float leadMult = 1f;

	private float spreadMult = 1f;

	[Header("Damage")]
	public float damage = 0.5f;

	public string damageType;

	public LayerMask shootMask;

	[Header("Idle Animations")]
	public float spinScanAmount;

	public float spinScanSpeed = 1f;

	private float scanCurrentDirection = 1f;

	[Header("Other")]
	public bool canKnockOver = true;

	public float knockOverAngle = 30f;

	[Header("Events")]
	public UnityEvent activateEvent;

	public UnityEvent deactivateEvent;

	public UnityEvent deathEvent;

	[SerializeReference]
	public DenizenAttackModule attackModule;

	public Transform turretGun;

	public Transform turretBarrel;

	public AITargetComponent targetComponent;

	[Header("Effects")]
	public ParticleSystem shootParticles;

	public ParticleSystem hitParticles;

	public ParticleSystem flashParticles;

	public float barkSoundFrequency = 3f;

	private float barkSoundTime = 10f;

	public CL_Prop prop;

	private Vector3 forwardStart;

	private bool hasSightedTarget;

	private bool knockedOver;

	private bool hasStartedDeathAttack;

	private float knockOverShootTime;

	private Vector3 targetLastPos;

	private Rigidbody rigid;

	public override void Start()
	{
		rigid = GetComponent<Rigidbody>();
		base.Start();
		forwardStart = base.transform.InverseTransformDirection(turretGun.forward);
		barkSoundTime = barkSoundFrequency * Random.value + 2f;
		shootDelayTime = shootDelay;
		if (attackModule != null)
		{
			attackModule.Initialize(this);
		}
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		if (!active)
		{
			return;
		}
		bool flag = false;
		flag = targetComponent.HasTarget();
		if (flag)
		{
			target = targetComponent.target.targetTransform;
		}
		if (canKnockOver)
		{
			if (knockedOver)
			{
				if (!hasStartedDeathAttack)
				{
					attackModule.StopAllAttacks();
					hasStartedDeathAttack = true;
				}
				if (knockOverShootTime < 1f && !dead)
				{
					turretGun.localRotation = Quaternion.Lerp(turretGun.localRotation, Quaternion.Euler(Mathf.Cos(Time.time * spinScanSpeed * 3f) * spinScanAmount, Mathf.Sin(Time.time * spinScanSpeed * 5f) * spinScanAmount, 0f), Time.deltaTime * 5f);
					if (shootTime < shootSpeed)
					{
						shootTime += Time.deltaTime;
					}
					else
					{
						attackModule?.Attack(null, "death");
					}
					knockOverShootTime += Time.deltaTime;
				}
				else if (knockOverShootTime >= 1f && !dead)
				{
					clipHandler.PlaySound("turret:pushover");
					Deactivate();
					dead = true;
					deathEvent.Invoke();
				}
				return;
			}
			if (Vector3.Angle(base.transform.up, Vector3.up) > knockOverAngle)
			{
				knockedOver = true;
			}
		}
		sight.Update();
		bool flag2 = false;
		if (flag)
		{
			Quaternion b = Quaternion.LookRotation(target.position + (target.position - targetLastPos) * Time.fixedDeltaTime * leadMult - turretGun.position);
			Vector3 to = base.transform.TransformDirection(forwardStart);
			if (Vector3.Angle((target.position - turretGun.position).normalized, to) < maxTurnAngle && sight.CanSeeTarget(target))
			{
				flag2 = true;
				if (!hasSightedTarget)
				{
					hasSightedTarget = true;
					clipHandler.PlaySound("turret:targetfound");
				}
				turretGun.rotation = Quaternion.Lerp(turretGun.rotation, b, Time.deltaTime * lookSpeed);
				if (Vector3.Angle((target.position - turretGun.position).normalized, turretGun.forward) < maxShootAngle)
				{
					if (shootDelayTime > 0f)
					{
						shootDelayTime -= Time.deltaTime;
					}
					else
					{
						spreadMult = Mathf.Lerp(spreadMult, 1f, Time.fixedDeltaTime);
						if (shootTime < shootSpeed)
						{
							shootTime += Time.deltaTime;
						}
						else
						{
							AttackCheck();
						}
					}
				}
			}
		}
		if (!flag2)
		{
			spreadMult = Mathf.Lerp(spreadMult, 2f, Time.fixedDeltaTime);
			if (hasSightedTarget)
			{
				hasSightedTarget = false;
				clipHandler.PlaySound("turret:targetlost");
				shootDelayTime = shootDelay;
			}
			if (!sight.CanRemember())
			{
				float num = turretGun.localRotation.eulerAngles.y;
				if (num > 180f)
				{
					num -= 360f;
				}
				if (num > spinScanAmount)
				{
					scanCurrentDirection = -1f;
				}
				else if (num < 0f - spinScanAmount)
				{
					scanCurrentDirection = 1f;
				}
				turretGun.localRotation = Quaternion.Slerp(turretGun.localRotation, Quaternion.Euler(0f, num + scanCurrentDirection * spinScanSpeed, 0f), Time.deltaTime * lookSpeed * 0.5f);
			}
			barkSoundTime -= Time.fixedDeltaTime;
			if (barkSoundTime < 0f)
			{
				barkSoundTime = barkSoundFrequency * Random.value + 2f;
				clipHandler.PlaySound("turret:randombark");
			}
		}
		if (flag)
		{
			targetLastPos = target.position;
		}
	}

	public override void TickUpdate()
	{
		base.TickUpdate();
		TargetCheck();
		targetComponent.Update();
	}

	public virtual void TargetCheck()
	{
		if (!targetComponent.HasTarget())
		{
			targetComponent.CheckForTarget(base.transform.position, sight.sightDistance, sight, base.transform);
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
		base.AttackCheck();
		shootTime = 0f;
		GameEntity targetEntity = targetComponent.target.targetEntity;
		if (!(targetEntity == null))
		{
			attackModule?.AttackCheck(targetEntity);
		}
	}

	public void Shoot()
	{
		shootTime = 0f;
		clipHandler.PlaySound("turret:shoot");
		Vector3 direction = turretBarrel.forward + Random.insideUnitSphere * bulletSpread * spreadMult;
		if (Physics.Raycast(turretBarrel.position, direction, out var hitInfo, maxRange, shootMask))
		{
			if (ObjectTagger.TagCheck(hitInfo.collider.gameObject, new string[1] { "Damageable" }))
			{
				Damageable component = hitInfo.collider.GetComponent<Damageable>();
				if (component != null)
				{
					if (!knockedOver)
					{
						Damageable.DamageInfo damageInfo = Damageable.DamageInfo.CreateDamageInfo(damage, damageType);
						damageInfo.sourceEntity = this;
						damageInfo.position = hitInfo.point;
						damageInfo.tags.Add("bullet");
						component.Damage(damageInfo);
					}
					GameEntity component2 = hitInfo.collider.GetComponent<GameEntity>();
					if (component2 != null)
					{
						component2.AddForce(direction.normalized * 0.1f, "denizen");
					}
				}
			}
			PlayTracer(turretBarrel.position, hitInfo.point);
		}
		else
		{
			PlayTracer(turretBarrel.position, turretBarrel.transform.position + turretBarrel.transform.forward * maxRange, 100f, playHitParticle: false);
		}
	}

	private void PlayTracer(Vector3 startPoint, Vector3 endPoint, float speed = 100f, bool playHitParticle = true)
	{
		ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
		Vector3 vector = endPoint - startPoint;
		emitParams.velocity = vector.normalized * speed;
		emitParams.startLifetime = vector.magnitude / speed;
		ParticleSystem.EmitParams emitParams2 = new ParticleSystem.EmitParams
		{
			position = endPoint,
			applyShapeToPosition = true
		};
		if (playHitParticle)
		{
			hitParticles.Emit(emitParams2, 20);
		}
		emitParams2.position = turretBarrel.position;
		flashParticles.Emit(emitParams2, 15);
		shootParticles.Emit(emitParams, 1);
	}

	public override void DrawGizmos()
	{
		if (GizmoContext.InSelection(this))
		{
			float num = Mathf.Cos(maxTurnAngle * 0.00872665f);
			float num2 = Mathf.Sin(maxTurnAngle * 0.00872665f);
			Draw.Line(base.transform.position, base.transform.position + base.transform.forward * maxRange, Color.red);
			float num3 = 0.25f;
			Draw.DashedLine(base.transform.position, base.transform.position + (base.transform.forward * num + base.transform.up * num2).normalized * maxRange, num3, num3, Color.white);
			Draw.DashedLine(base.transform.position, base.transform.position + (base.transform.forward * num + -base.transform.up * num2).normalized * maxRange, num3, num3, Color.white);
			Draw.DashedLine(base.transform.position, base.transform.position + (base.transform.forward * num + -base.transform.right * num2).normalized * maxRange, num3, num3, Color.white);
			Draw.DashedLine(base.transform.position, base.transform.position + (base.transform.forward * num + base.transform.right * num2).normalized * maxRange, num3, num3, Color.white);
		}
	}

	public override void AddForce(Vector3 v, string source = "")
	{
		prop.Unstick();
		rigid.AddForce(v * 3f);
		base.AddForce(v);
	}

	public override void AddForceAtPosition(Vector3 v, Vector3 p, string source = "")
	{
		prop.Unstick();
		base.AddForceAtPosition(v * 6f + Vector3.up * 2f, p);
	}

	public override bool Damage(Damageable.DamageInfo info)
	{
		info = ProcessDamageInfo(info);
		health -= info.amount;
		if (info.amount > 4f || health <= 0f)
		{
			knockedOver = true;
			return true;
		}
		return false;
	}

	public override void Kill(string type = "", Damageable.DamageInfo info = null)
	{
		if (!dead)
		{
			knockedOver = true;
			dead = true;
			Deactivate();
			Kill(type);
		}
	}

	public void Deactivate()
	{
		if (!dead)
		{
			deactivateEvent.Invoke();
			clipHandler.PlaySound("turret:deactivate");
			active = false;
		}
	}

	public void Activate()
	{
		if (!dead)
		{
			activateEvent.Invoke();
			clipHandler.PlaySound("turret:activate");
			active = true;
		}
	}

	public void ToggleActivated()
	{
		if (active)
		{
			Deactivate();
		}
		else
		{
			Activate();
		}
	}
}
