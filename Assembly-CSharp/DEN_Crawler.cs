using System.Collections;
using UnityEngine;

public class DEN_Crawler : DEN_BasicNavigator
{
	private Rigidbody rigid;

	private bool isColliding;

	private new Collision lastCollision;

	private float collisionTime;

	public BuffContainer attackHitDebuff;

	public float gravity = 1f;

	public bool destroyAfterDeadTime = true;

	public float destroyDeadTime = 20f;

	private DenizenMovement_Climber climberMovementModule;

	public bool faceTarget;

	private Vector3 upNormal;

	public override void Start()
	{
		base.Start();
		rigid = GetComponent<Rigidbody>();
		rigid.useGravity = false;
		if (baseMovementModule.GetType() == typeof(DenizenMovement_Climber))
		{
			climberMovementModule = (DenizenMovement_Climber)baseMovementModule;
		}
	}

	public override void Update()
	{
		base.Update();
		if (faceTarget)
		{
			if (currentState.name == "hunt" && canSeeTarget && !dead)
			{
				climberMovementModule.faceLookVector = true;
			}
			else
			{
				climberMovementModule.faceLookVector = false;
			}
		}
		if (lastCollision != null && lastCollision.contactCount > 0)
		{
			collisionTime -= Time.deltaTime;
			if (collisionTime <= 0f)
			{
				lastCollision = null;
				isColliding = false;
			}
		}
		if (dead && destroyAfterDeadTime)
		{
			destroyDeadTime -= Time.deltaTime;
			if (destroyDeadTime <= 0f)
			{
				Object.Destroy(base.gameObject);
			}
		}
		if (!baseMovementModule.IsGrounded())
		{
			animator.SetBool("Falling", value: true);
		}
		else
		{
			animator.SetBool("Falling", value: false);
		}
	}

	public void RotateToFaceDirection()
	{
		upNormal = Vector3.Lerp(upNormal, Vector3.up, Time.deltaTime);
		if (lastCollision != null && lastCollision.contactCount > 0)
		{
			upNormal = -lastCollision.contacts[0].normal;
		}
		base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(Vector3.Lerp(Vector3.ProjectOnPlane(GetLookDirection(), upNormal), GetLookDirection(), 0.5f), upNormal), Time.deltaTime * 5f);
	}

	internal override void OnCollisionEnter(Collision collision)
	{
		base.OnCollisionEnter(collision);
		Collide(collision);
		baseMovementModule.OnCollisionEnter(collision);
		if (dead)
		{
			baseMovementModule.GroundedCheck();
		}
	}

	private void OnCollisionStay(Collision collision)
	{
		Collide(collision);
		baseMovementModule.OnCollisionStay(collision);
	}

	private void OnCollisionExit(Collision collision)
	{
		if (dead)
		{
			baseMovementModule.GroundedCheck();
		}
	}

	private void Collide(Collision collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Default") || collision.gameObject.layer == LayerMask.NameToLayer("World"))
		{
			lastCollision = collision;
			collisionTime = 0.5f;
			isColliding = true;
		}
	}

	public override bool Damage(Damageable.DamageInfo info)
	{
		if (!damageable)
		{
			return false;
		}
		animator.SetTrigger("Hit");
		return base.Damage(info);
	}

	public override void Kill(string type = "", Damageable.DamageInfo damageInfo = null)
	{
		base.Kill(type, damageInfo);
		rigid.isKinematic = false;
		rigid.useGravity = true;
		baseMovementModule.Jump(0.5f);
		StartCoroutine(DieLayer());
		animator.SetBool("Dead", value: true);
		base.gameObject.layer = LayerMask.NameToLayer("Interactable Only World Collide");
		IEnumerator DieLayer()
		{
			float f = 0f;
			while (f < 1f)
			{
				animator.SetLayerWeight(1, f);
				f += Time.deltaTime;
				yield return null;
			}
		}
	}

	internal override void OnAttackHit(GameEntity hitEntity, bool hasKilled)
	{
		base.OnAttackHit(hitEntity, hasKilled);
		if (hitEntity.GetTagger().HasTag("Player"))
		{
			hitEntity.GetComponent<ENT_Player>().Buff(attackHitDebuff.CopyBuffContainer());
		}
	}
}
