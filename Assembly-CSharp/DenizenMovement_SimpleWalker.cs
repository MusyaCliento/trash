using System;
using UnityEngine;

[Serializable]
public class DenizenMovement_SimpleWalker : DenizenMovementModule
{
	public float moveSpeedMax = 10f;

	public float acceleration = 10f;

	public float turnSpeed = 10f;

	public float jumpForce = 5f;

	public float speedMult = 1f;

	public float deadzone;

	public Vector3 axialMovementMultiplier = Vector3.one;

	private Rigidbody rigid;

	public LayerMask worldMask;

	private bool isGrounded;

	private Vector3 groundedNormal;

	private float stuckTime;

	public bool jumpIfStuck = true;

	private Vector3 lastPos;

	private Vector3 lastForward;

	private Vector3 smoothedVelocity;

	public bool faceTargetPosition = true;

	public bool alwaysRotateBeforeMovement;

	public float maximumRotateBeforeMovementAngle = 15f;

	private bool jumping;

	public float groundedCheckDistance = 0.3f;

	public bool preventFalling;

	internal float forceLookBlend;

	internal Vector3 lookDirection;

	private float trueVelocity;

	private Vector3 lastPosition;

	public float swimSpeedMult = 0.5f;

	public float lookYScaleMult = 1f;

	public bool allowGroundedRotation = true;

	public Animator animator;

	public bool useAnimator;

	public string animWalkBool = "Walking";

	public string animWalkSpeedFloat = "WalkSpeed";

	public string animTurnBool = "Turning";

	public float animWalkSpeedMult = 1f;

	public float walkAnimSpeedRequirement = 0.5f;

	[Header("Directional Motion")]
	public bool useDirectionalAnimatorBlending;

	public float directionalAnimatorDeadzone = 0.1f;

	public float directionalAnimatorVelocityMagnitudeMultiplier = 1f;

	public float directionalAnimatorTurnMagnitudeMultiplier = 1f;

	public float directionalAnimatorTurnDeadzone = 0.1f;

	public string animDirectionalWalkBlendID = "Move_Walking";

	public string animDirectionalStrafeBlendID = "Move_Strafing";

	public string animDirectionalTurningID = "Move_Turning";

	public bool useVerticalAimAnimatorBlend;

	public string animVerticalAim = "Aim_Y";

	public float animVerticalAimMultiplier = 1f;

	private Vector3 lastLookVector;

	private Vector3 smoothedLookVector;

	private Vector3 rotationVelocity = Vector3.zero;

	private bool hasSetLookVector;

	public override void Initialize(GameEntity gE)
	{
		base.Initialize(gE);
		rigid = gE.GetComponent<Rigidbody>();
		lastPos = gE.transform.position;
	}

	public override void Update()
	{
		base.Update();
		smoothedVelocity = Vector3.Lerp(smoothedVelocity, rigid.linearVelocity, Time.deltaTime * 4f);
		GroundedCheck();
		MoveToTargetPosition();
		smoothedLookVector = Vector3.Lerp(smoothedLookVector, lastLookVector, Time.deltaTime * 2f);
		float magnitude = ent.GetTrueVelocity().magnitude;
		if (!useAnimator)
		{
			return;
		}
		animator.SetFloat(animWalkSpeedFloat, magnitude * animWalkSpeedMult);
		if (magnitude > walkAnimSpeedRequirement)
		{
			animator.SetBool(animWalkBool, value: true);
		}
		else
		{
			animator.SetBool(animWalkBool, value: false);
		}
		if (useDirectionalAnimatorBlending)
		{
			Vector3 vector = ent.transform.InverseTransformVector(ent.GetTrueVelocity()) * directionalAnimatorVelocityMagnitudeMultiplier;
			bool flag = false;
			if (vector.magnitude < directionalAnimatorDeadzone)
			{
				vector = Vector3.zero;
				flag = true;
			}
			if (animDirectionalStrafeBlendID != "" && !flag)
			{
				float value = Mathf.Lerp(animator.GetFloat(animDirectionalStrafeBlendID), vector.x, Time.deltaTime * 2f);
				animator.SetFloat(animDirectionalStrafeBlendID, value);
			}
			if (animDirectionalWalkBlendID != "" && !flag)
			{
				float value2 = Mathf.Lerp(animator.GetFloat(animDirectionalWalkBlendID), vector.z, Time.deltaTime * 2f);
				animator.SetFloat(animDirectionalWalkBlendID, value2);
			}
			if (animDirectionalTurningID != "" && rigid != null)
			{
				float num = Vector3.SignedAngle(lastForward, ent.transform.forward, ent.transform.up) * directionalAnimatorTurnMagnitudeMultiplier;
				Debug.Log(num);
				if (Mathf.Abs(num) < directionalAnimatorTurnDeadzone)
				{
					animator.SetBool(animTurnBool, value: false);
				}
				else
				{
					float value3 = Mathf.Lerp(animator.GetFloat(animDirectionalTurningID), num, Time.deltaTime * 2f);
					animator.SetFloat(animDirectionalTurningID, value3);
					animator.SetBool(animTurnBool, value: true);
				}
			}
		}
		if (useVerticalAimAnimatorBlend)
		{
			Vector3 vector2 = ent.transform.InverseTransformVector(smoothedLookVector);
			animator.SetFloat(animVerticalAim, vector2.y / vector2.z * animVerticalAimMultiplier);
		}
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		trueVelocity = (ent.transform.position - lastPosition).magnitude / Time.fixedDeltaTime;
		lastPosition = ent.transform.position;
	}

	public void MoveToTargetPosition()
	{
		Vector3 vector = Vector3.ProjectOnPlane(targetPosition - ent.transform.position, Vector3.up);
		bool flag = true;
		bool flag2 = true;
		if (!hasSetLookVector)
		{
			if (vector.magnitude < 0.8f)
			{
				flag = false;
			}
			else if (!hasSetLookVector)
			{
				lastLookVector = smoothedVelocity;
			}
		}
		Vector3 vector2 = Vector3.ClampMagnitude(vector, moveSpeedMax);
		vector2 = Vector3.ProjectOnPlane(vector2, Vector3.up);
		if (vector2.magnitude < 1f)
		{
			vector2 = vector2.normalized;
		}
		Vector3 vector3 = lastLookVector;
		if (!faceTargetPosition)
		{
			if (isGrounded)
			{
				vector3 = Vector3.ProjectOnPlane(vector3, groundedNormal);
			}
		}
		else if (faceTargetPosition)
		{
			vector3 = Vector3.ProjectOnPlane(vector, groundedNormal);
			flag = true;
		}
		else
		{
			flag = false;
		}
		if (!allowGroundedRotation)
		{
			lookDirection = Vector3.ProjectOnPlane(lookDirection, groundedNormal);
		}
		vector3 = Vector3.Lerp(vector3, lookDirection, forceLookBlend);
		Quaternion b = Quaternion.LookRotation(vector3, Vector3.up);
		float num = 10f;
		num = ((hasSetLookVector || !(smoothedVelocity.magnitude < 0.5f)) ? turnSpeed : (turnSpeed * 0.1f));
		if (!canRotate)
		{
			num = 0f;
		}
		lastForward = ent.transform.forward;
		if (flag)
		{
			Vector3 eulerAngles = ent.transform.rotation.eulerAngles;
			ent.transform.rotation = Quaternion.Lerp(ent.transform.rotation, b, Time.deltaTime * num);
			Vector3 vector4 = eulerAngles - ent.transform.rotation.eulerAngles;
			rotationVelocity = Vector3.Lerp(rotationVelocity, vector4 / Time.deltaTime, Time.deltaTime * 2f);
		}
		else
		{
			rotationVelocity = Vector3.Lerp(rotationVelocity, Vector3.zero, Time.deltaTime);
		}
		if (float.IsNaN(rotationVelocity.x))
		{
			rotationVelocity = Vector3.zero;
		}
		if (alwaysRotateBeforeMovement)
		{
			float num2 = Vector3.Angle(Vector3.ProjectOnPlane(ent.transform.forward, Vector3.up), vector2);
			if (maximumRotateBeforeMovementAngle < num2)
			{
				flag2 = false;
			}
		}
		if (preventFalling && !Physics.Raycast(ent.transform.position + vector2.normalized, Vector3.down, out var _, 5f, worldMask))
		{
			vector2 = Vector3.ProjectOnPlane(ent.transform.forward, Vector3.ProjectOnPlane(vector2, Vector3.up)).normalized;
		}
		if (jumpIfStuck && !preventFalling)
		{
			if (rigid.linearVelocity.magnitude <= 0.01f && Vector3.SqrMagnitude(lastPos - ent.transform.position) / Time.deltaTime < 0.003f && Vector3.SqrMagnitude(Vector3.ProjectOnPlane(ent.transform.position - targetPosition, Vector3.up)) > 2.5f)
			{
				stuckTime += Time.deltaTime;
				if (stuckTime > 0.5f)
				{
					Jump();
					stuckTime = 0f;
				}
			}
			else
			{
				stuckTime = 0f;
			}
			lastPos = ent.transform.position;
		}
		if (flag2)
		{
			Vector3 b2 = axialMovementMultiplier;
			vector2 = ent.transform.TransformVector(Vector3.Scale(ent.transform.InverseTransformVector(vector2), b2));
			if (vector2.magnitude < deadzone)
			{
				vector2 = Vector3.zero;
			}
			if (canMove && isGrounded)
			{
				Vector3 vector5 = Vector3.ProjectOnPlane(rigid.linearVelocity, Vector3.up);
				if (Vector3.Dot(vector5.normalized, vector2.normalized) < 0f || vector5.magnitude < moveSpeedMax)
				{
					rigid.AddForce(vector2 * Time.deltaTime * acceleration * speedMult, ForceMode.VelocityChange);
				}
			}
			else if (canMove && ent.IsInWater())
			{
				Vector3 vector6 = Vector3.ProjectOnPlane(rigid.linearVelocity, Vector3.up);
				if (Vector3.Dot(vector6.normalized, vector2.normalized) < 0f || vector6.magnitude < moveSpeedMax * swimSpeedMult)
				{
					rigid.AddForce(vector2 * Time.deltaTime * acceleration * speedMult * swimSpeedMult, ForceMode.VelocityChange);
				}
			}
		}
		hasSetLookVector = false;
	}

	public override bool GroundedCheck()
	{
		if (ent.IsInWater())
		{
			isGrounded = false;
			groundedNormal = Vector3.up;
			return false;
		}
		if (Physics.SphereCast(ent.transform.position + Vector3.up * 0.03f, 0.2f, -Vector3.up, out var hitInfo, groundedCheckDistance, worldMask))
		{
			isGrounded = true;
			groundedNormal = hitInfo.normal;
		}
		else
		{
			groundedNormal = Vector3.up;
			isGrounded = false;
		}
		groundedNormal = Vector3.Lerp(Vector3.up, groundedNormal, lookYScaleMult);
		if (!allowGroundedRotation)
		{
			groundedNormal = Vector3.up;
		}
		if (CL_UIManager.debug)
		{
			CL_DebugView.draw.Label2D(ent.transform.position, "Grounded:" + isGrounded + " True Velocity: " + smoothedVelocity.magnitude, Color.red);
			CL_DebugView.draw.WireCapsule(ent.transform.position + Vector3.up * 0.03f, ent.transform.position + -Vector3.up * groundedCheckDistance, 0.2f, new Color(1f, 0f, 0f, 0.6f));
		}
		if (jumping && isGrounded && Vector3.Dot(rigid.linearVelocity, Vector3.up) < 0.02f)
		{
			Land();
		}
		return isGrounded;
	}

	public bool IsCurrentlyGrounded()
	{
		return isGrounded;
	}

	public override bool IsGrounded()
	{
		return isGrounded;
	}

	public void SetCanMove(bool b)
	{
		canMove = b;
	}

	public override void Jump(float mult = 1f, float leap = 0f)
	{
		Vector3 vector = ent.transform.forward * leap;
		rigid.AddForce(jumpForce * Vector3.up * mult + vector, ForceMode.VelocityChange);
		if (_OnJump != null)
		{
			_OnJump();
		}
		jumping = true;
	}

	public void Land()
	{
		if (jumping)
		{
			jumping = false;
			if (_OnLand != null)
			{
				_OnLand();
			}
		}
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
		return smoothedVelocity;
	}

	public override void AddForce(Vector3 f)
	{
		rigid.AddForce(f);
		base.AddForce(f);
	}

	public override void SetSpeedMult(float mult)
	{
		speedMult = mult;
	}

	public override float GetSpeedMult()
	{
		return speedMult;
	}

	public override void SetLookVector(Vector3 v)
	{
		base.SetLookVector(v);
		lastLookVector = v;
		hasSetLookVector = true;
	}
}
