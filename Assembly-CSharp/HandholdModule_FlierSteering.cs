using UnityEngine;

public class HandholdModule_FlierSteering : HandholdModule
{
	public DEN_BasicDenizen basicFlier;

	public string attackDamageTag = "bloodbug";

	public float steerHorizontalForce = 10f;

	public float steerDownwardsForce = 10f;

	public float steerUpwardsForce = 1f;

	public float gravityForce = 1f;

	public float placementForce = 10f;

	public float placementDistance = 1f;

	public float placementHeight = 1f;

	public Animator animator;

	public float jumpBoost = 100f;

	public float forceMult = 1f;

	public bool canBuck;

	public float buckWait = 10f;

	public float buckRate = 3f;

	private float buckTime;

	public float buckDamage = 0.3f;

	public float buckStaminaDamage = 3f;

	public float buckRechargeSpeed = 0.5f;

	public int maxBuckDropHits = 6;

	private int currentBuckDropHits;

	private bool isHeld;

	public override void Initialize(CL_Handhold h)
	{
		base.Initialize(h);
	}

	public override void LateUpdate()
	{
		base.LateUpdate();
		if (basicFlier.IsDead())
		{
			if (handhold.GetHolding())
			{
				handhold.ForceDropHands();
			}
			if (handhold.active)
			{
				handhold.active = false;
			}
			return;
		}
		if (handhold.GetHolding())
		{
			if (!isHeld)
			{
				basicFlier.clipHandler.PlaySound("denizen:hang-start");
				isHeld = true;
			}
			Vector3 vector = new Vector3(InputManager.GetVector("Move").vector.x, InputManager.GetVector("Move").vector.y);
			Vector3 vector2 = handhold.GetPlayer().cam.transform.forward * vector.y + handhold.GetPlayer().cam.transform.right * vector.x;
			vector2 = Vector3.ClampMagnitude(vector2, 1f);
			vector2.x *= steerHorizontalForce;
			vector2.z *= steerHorizontalForce;
			if (vector2.y > 0f)
			{
				vector2.y *= steerUpwardsForce;
			}
			else
			{
				vector2.y *= steerDownwardsForce;
			}
			vector2 += -Vector3.up * gravityForce;
			Vector3 a = handhold.GetPlayer().cam.transform.forward * placementDistance;
			a = Vector3.Scale(a, new Vector3(1f, 0.5f, 1f)).normalized;
			Vector3 vector3 = handhold.GetPlayer().cam.transform.position + (a + Vector3.up * placementHeight);
			basicFlier.SetTargetPosition(vector3 + vector2 * forceMult);
			basicFlier.movementModule.SetLookVector(handhold.GetPlayer().cam.transform.position - basicFlier.transform.position);
			basicFlier.transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(handhold.GetPlayer().cam.transform.position - basicFlier.transform.position, Vector3.up));
			animator.SetFloat("HangBlend", handhold.GetPlayer().transform.position.y - handhold.transform.position.y);
			foreach (ENT_Player.Hand hand in handhold.hands)
			{
				hand.UpdateHandPosition();
			}
			animator.SetBool("Hanging", value: true);
			if (canBuck)
			{
				buckTime -= Time.deltaTime;
				if (buckTime <= 0f)
				{
					buckTime = buckRate;
					animator.SetTrigger("Buck");
					currentBuckDropHits++;
					handhold.GetPlayer().Damage(Damageable.DamageInfo.CreateDamageInfo(buckDamage, attackDamageTag));
					CL_CameraControl.Shake(0.1f);
					handhold.GetPlayer().DamageGripStrength(buckStaminaDamage, onlyToGrabbingHands: true);
					if (currentBuckDropHits > maxBuckDropHits)
					{
						handhold.GetPlayer().DropHang(0.3f);
					}
					basicFlier.clipHandler.PlaySound("denizen:buck");
				}
			}
			basicFlier.SetHome();
			return;
		}
		if (isHeld)
		{
			basicFlier.clipHandler.PlaySound("denizen:hang-end");
			isHeld = false;
		}
		if (canBuck)
		{
			if (buckTime < buckWait)
			{
				buckTime += Time.deltaTime * buckRechargeSpeed;
			}
			currentBuckDropHits = 0;
		}
		animator.SetBool("Hanging", value: false);
	}

	public override void OnGrab(ENT_Player p, ENT_Player.Hand hand, Clickable.InteractionInfo info = null)
	{
		base.OnGrab(p, hand, info);
	}

	public override void OnRelease(ENT_Player p, ENT_Player.Hand hand)
	{
		base.OnRelease(p, hand);
	}

	public override void OnJump(ENT_Player p, ENT_Player.Hand hand, bool hasJumped)
	{
		base.OnJump(p, hand);
		basicFlier.AddForce(Vector3.up * jumpBoost);
	}

	public override void OnDoubleJump(ENT_Player p, ENT_Player.Hand hand, bool hasJumped)
	{
		base.OnJump(p, hand);
		basicFlier.AddForce(Vector3.up * jumpBoost * 0.7f);
	}
}
