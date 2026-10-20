using System;
using UnityEngine;

[Serializable]
public class DenizenMovement_SimpleMover : DenizenMovementModule
{
	public float moveSpeedMax = 10f;

	public float acceleration = 10f;

	public float turnSpeed = 10f;

	public float jumpForce = 5f;

	public float speedMult = 1f;

	public bool clampMovementToPlane;

	private Rigidbody rigid;

	private Vector3 smoothedVelocity;

	public bool faceTargetPosition = true;

	[Range(0f, 1f)]
	public float facingWorldUpBlend = 1f;

	internal float forceLookBlend;

	internal Vector3 lookDirection;

	private float trueVelocity;

	private Vector3 lastPosition;

	private Vector3 lastLookVector;

	public override void Initialize(GameEntity gE)
	{
		base.Initialize(gE);
		rigid = gE.GetComponent<Rigidbody>();
	}

	public override void Update()
	{
		base.Update();
		smoothedVelocity = Vector3.Lerp(smoothedVelocity, rigid.linearVelocity, Time.deltaTime * 4f);
		GroundedCheck();
		MoveToTargetPosition();
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		trueVelocity = (ent.transform.position - lastPosition).magnitude / Time.fixedDeltaTime;
		lastPosition = ent.transform.position;
	}

	public void MoveToTargetPosition()
	{
		Vector3 vector = targetPosition - ent.transform.position;
		bool flag = true;
		if (vector.magnitude < 0.2f)
		{
			flag = false;
		}
		else
		{
			lastLookVector = smoothedVelocity;
		}
		Vector3 vector2 = Vector3.ClampMagnitude(vector, moveSpeedMax);
		if (clampMovementToPlane)
		{
			vector2 = Vector3.ProjectOnPlane(vector2, Vector3.up);
		}
		if (vector2.magnitude < 1f)
		{
			vector2 = vector2.normalized;
		}
		Vector3 vector3 = lastLookVector;
		if (!faceTargetPosition)
		{
			vector3 = Vector3.ProjectOnPlane(vector3, Vector3.up);
		}
		else if (faceTargetPosition)
		{
			lookDirection = Vector3.Lerp(vector, Vector3.ProjectOnPlane(vector, Vector3.up), facingWorldUpBlend);
			flag = true;
		}
		else
		{
			flag = false;
		}
		vector3 = Vector3.Lerp(vector3, lookDirection, forceLookBlend);
		Quaternion b = Quaternion.LookRotation(vector3, Vector3.up);
		float num = ((!(smoothedVelocity.magnitude < 0.5f)) ? turnSpeed : (turnSpeed * 0.1f));
		if (!canRotate)
		{
			num = 0f;
		}
		if (flag)
		{
			ent.transform.rotation = Quaternion.Lerp(ent.transform.rotation, b, Time.deltaTime * num);
		}
		if (canMove)
		{
			Vector3 vector4 = Vector3.ProjectOnPlane(rigid.linearVelocity, Vector3.up);
			if (Vector3.Dot(vector4.normalized, vector2.normalized) < 0f || vector4.magnitude < moveSpeedMax)
			{
				rigid.AddForce(vector2 * Time.deltaTime * acceleration * speedMult, ForceMode.VelocityChange);
			}
		}
	}

	public new void SetTargetPosition(Vector3 t)
	{
		targetPosition = t;
	}

	public void SetCanMove(bool b)
	{
		canMove = b;
	}

	public override void Jump(float mult = 1f, float leap = 0f)
	{
		Vector3 vector = ent.transform.forward * leap;
		rigid.AddForce(jumpForce * Vector3.up * mult + vector, ForceMode.VelocityChange);
	}

	public void Land()
	{
	}

	public override bool IsWalking()
	{
		return trueVelocity > 0.4f;
	}

	public float GetTrueVelocity()
	{
		return trueVelocity;
	}

	public float GetSmoothedVelocity()
	{
		return smoothedVelocity.magnitude;
	}

	public override Vector3 GetVelocity()
	{
		return base.GetVelocity();
	}

	public override void AddForce(Vector3 f)
	{
		rigid.AddForce(f);
		base.AddForce(f);
	}
}
