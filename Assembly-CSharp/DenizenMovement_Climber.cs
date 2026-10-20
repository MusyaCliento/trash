using System;
using UnityEngine;

[Serializable]
public class DenizenMovement_Climber : DenizenMovementModule
{
	public bool canClimb = true;

	[Header("Movement")]
	public float maxSpeed = 3f;

	public float acceleration = 12f;

	public float deceleration = 16f;

	public float rotationSpeed = 8f;

	public float speedMult = 1f;

	[Header("Rotation")]
	public float slowTurnMultiplier = 0.1f;

	public float slowTurnDistance = 1f;

	[Header("Rotation")]
	public float minimumVelocityThreshhold = 1E-05f;

	[Header("Surface Probing")]
	public bool multidirectionalProbeWhenAirborn;

	public float surfaceCheckDistance = 1f;

	public float surfaceProbeRadius = 0.25f;

	public LayerMask surfaceMask;

	[Header("Normal Blending")]
	public float normalAlignSpeed = 10f;

	public float cornerAlignSpeed = 14f;

	[Header("Stick To Surface")]
	public float stickForce = 40f;

	[Header("Grounding")]
	[Tooltip("Cosine of max allowed angle difference between current surface normal and hit normal")]
	public float groundedNormalTolerance = 0.7f;

	private Rigidbody rigid;

	private Vector3 surfaceNormal = Vector3.up;

	private Vector3 desiredMoveVector;

	private Vector3 currentVelocity;

	private bool forceDetached;

	public Animator animator;

	public bool useAnimator = true;

	public string animWalkBool = "Walking";

	public string animFallingBool = "Falling";

	public string animWalkSpeedFloat = "WalkSpeed";

	public float animWalkSpeedMult = 1f;

	public float walkAnimSpeedRequirement = 0.5f;

	public bool autoJump;

	public float autoJumpDot = 0.95f;

	public float autoJumpMinDistance = 1f;

	public float autoJumpMinVelocity = 0.1f;

	public float jumpForce = 5f;

	private bool jumping;

	private float jumpTime;

	private bool isGrounded;

	public bool faceLookVector;

	private Denizen denizen;

	public override void Initialize(GameEntity gE)
	{
		base.Initialize(gE);
		rigid = ent.GetComponent<Rigidbody>();
		rigid.useGravity = false;
		rigid.interpolation = RigidbodyInterpolation.Interpolate;
		denizen = gE as Denizen;
	}

	public void SetMoveVector(Vector3 worldMoveVector)
	{
		desiredMoveVector = worldMoveVector;
	}

	public override void FixedUpdate()
	{
		Movement();
		Rotation();
	}

	private void Movement()
	{
		Vector3 vector = Vector3.ClampMagnitude(Vector3.ProjectOnPlane(targetPosition - ent.transform.position, surfaceNormal) * 3f, 1f);
		SetMoveVector(Vector3.ClampMagnitude(vector * 2f, 4f) * speedMult);
		if (!canClimb)
		{
			surfaceNormal = Vector3.up;
		}
		if (forceDetached)
		{
			SetWorldGravity(enabled: true);
			return;
		}
		jumpTime -= Time.fixedDeltaTime;
		isGrounded = GroundedCheck();
		if (!isGrounded)
		{
			SetWorldGravity(enabled: true);
			if (!TryReattach())
			{
				surfaceNormal = Vector3.Lerp(surfaceNormal, Vector3.up, Time.deltaTime * 0.2f);
				currentVelocity = Vector3.zero;
				return;
			}
			SetWorldGravity(enabled: false);
			if (useAnimator)
			{
				animator.SetBool(animFallingBool, value: true);
			}
		}
		else
		{
			SetWorldGravity(enabled: false);
			if (useAnimator)
			{
				animator.SetBool(animFallingBool, value: false);
			}
		}
		if (canClimb)
		{
			if (TryGetPrimarySurface(out var hit))
			{
				surfaceNormal = Vector3.Slerp(surfaceNormal, hit.normal, normalAlignSpeed * Time.fixedDeltaTime);
			}
			HandleCornerProbing();
		}
		Vector3 vector2 = Vector3.ProjectOnPlane(desiredMoveVector, surfaceNormal);
		float num = Mathf.Clamp(vector2.magnitude, 0f, maxSpeed);
		Vector3 target = ((vector2.sqrMagnitude > 0.0001f) ? (vector2.normalized * num) : Vector3.zero);
		float num2 = ((target.sqrMagnitude > currentVelocity.sqrMagnitude) ? acceleration : deceleration);
		currentVelocity = Vector3.MoveTowards(currentVelocity, target, num2 * Time.fixedDeltaTime);
		if (currentVelocity.sqrMagnitude < 1E-05f)
		{
			currentVelocity = Vector3.zero;
		}
		float num3 = 1f;
		if (DarkMachineFunctions.GetManhattanDistance(ent.transform.position, targetPosition) < slowTurnDistance)
		{
			num3 = 0.1f;
		}
		float magnitude = ent.GetTrueVelocity().magnitude;
		if (canMove)
		{
			rigid.MovePosition(rigid.position + currentVelocity * Time.fixedDeltaTime * num3);
		}
		float num4 = currentVelocity.magnitude;
		if (!canMove)
		{
			num4 = 0f;
		}
		if (useAnimator)
		{
			animator.SetFloat(animWalkSpeedFloat, magnitude * animWalkSpeedMult);
		}
		if (magnitude > walkAnimSpeedRequirement)
		{
			if (useAnimator)
			{
				animator.SetBool(animWalkBool, value: true);
			}
		}
		else
		{
			if (useAnimator)
			{
				animator.SetBool(animWalkBool, value: false);
			}
			if (DarkMachineFunctions.GetManhattanDistance(ent.transform.position, targetPosition) < slowTurnDistance)
			{
				_ = slowTurnMultiplier;
			}
		}
		rigid.AddForce(-surfaceNormal * stickForce, ForceMode.Acceleration);
		if (isGrounded && jumping)
		{
			Land();
		}
		if (isGrounded && num4 < autoJumpMinVelocity && Vector3.Dot((targetPosition - ent.transform.position).normalized, ent.transform.up) > autoJumpDot && autoJump && !jumping && Vector3.Distance(targetPosition, ent.transform.position) > autoJumpMinDistance)
		{
			Jump();
		}
	}

	private void Rotation()
	{
		float num = 1f;
		if (currentVelocity.magnitude < walkAnimSpeedRequirement && DarkMachineFunctions.GetManhattanDistance(ent.transform.position, targetPosition) < slowTurnDistance)
		{
			num = slowTurnMultiplier;
		}
		if ((!IsGrounded() || jumping) && canRotate)
		{
			Quaternion identity = Quaternion.identity;
			identity = ((!(rigid.linearVelocity.sqrMagnitude > 0.0001f)) ? Quaternion.LookRotation(rigid.transform.forward, Vector3.up) : Quaternion.LookRotation(rigid.transform.forward, -rigid.linearVelocity.normalized));
			rigid.MoveRotation(Quaternion.Slerp(rigid.rotation, identity, rotationSpeed * Time.fixedDeltaTime * 2f));
		}
		else if (currentVelocity.sqrMagnitude > 0.0001f && canRotate)
		{
			Quaternion identity2 = Quaternion.identity;
			identity2 = ((!faceLookVector) ? Quaternion.LookRotation(currentVelocity.normalized, surfaceNormal) : Quaternion.LookRotation(Vector3.ProjectOnPlane(denizen.GetLookVector(), surfaceNormal), surfaceNormal));
			rigid.MoveRotation(Quaternion.Slerp(rigid.rotation, identity2, rotationSpeed * Time.fixedDeltaTime * num));
		}
	}

	private void SetWorldGravity(bool enabled)
	{
		rigid.useGravity = enabled;
	}

	public override bool GroundedCheck()
	{
		if (forceDetached || jumpTime > 0f)
		{
			return false;
		}
		if (!Physics.SphereCast(rigid.worldCenterOfMass, surfaceProbeRadius, -surfaceNormal, out var hitInfo, surfaceCheckDistance, surfaceMask, QueryTriggerInteraction.Ignore))
		{
			return false;
		}
		return Vector3.Dot(surfaceNormal, hitInfo.normal) >= groundedNormalTolerance;
	}

	public override bool IsGrounded()
	{
		return isGrounded;
	}

	private bool TryGetPrimarySurface(out RaycastHit hit)
	{
		return Physics.SphereCast(rigid.worldCenterOfMass, surfaceProbeRadius, -surfaceNormal, out hit, surfaceCheckDistance, surfaceMask, QueryTriggerInteraction.Ignore);
	}

	private bool TryReattach()
	{
		if (Physics.SphereCast(rigid.worldCenterOfMass, surfaceProbeRadius, -ent.transform.up, out var hitInfo, surfaceCheckDistance * 1.5f, surfaceMask, QueryTriggerInteraction.Ignore))
		{
			surfaceNormal = hitInfo.normal;
			return true;
		}
		if (multidirectionalProbeWhenAirborn)
		{
			if (Physics.Raycast(rigid.worldCenterOfMass, Vector3.up, out var hitInfo2, surfaceCheckDistance, surfaceMask))
			{
				surfaceNormal = hitInfo2.normal;
				return true;
			}
			if (Physics.Raycast(rigid.worldCenterOfMass, Vector3.right, out hitInfo2, surfaceCheckDistance, surfaceMask))
			{
				surfaceNormal = hitInfo2.normal;
				return true;
			}
			if (Physics.Raycast(rigid.worldCenterOfMass, Vector3.left, out hitInfo2, surfaceCheckDistance, surfaceMask))
			{
				surfaceNormal = hitInfo2.normal;
				return true;
			}
			if (Physics.Raycast(rigid.worldCenterOfMass, Vector3.forward, out hitInfo2, surfaceCheckDistance, surfaceMask))
			{
				surfaceNormal = hitInfo2.normal;
				return true;
			}
			if (Physics.Raycast(rigid.worldCenterOfMass, Vector3.back, out hitInfo2, surfaceCheckDistance, surfaceMask))
			{
				surfaceNormal = hitInfo2.normal;
				return true;
			}
			if (Physics.Raycast(rigid.worldCenterOfMass, Vector3.down, out hitInfo2, surfaceCheckDistance, surfaceMask))
			{
				surfaceNormal = hitInfo2.normal;
				return true;
			}
		}
		return false;
	}

	private void HandleCornerProbing()
	{
		if (!(desiredMoveVector.sqrMagnitude < 0.0001f))
		{
			Vector3 normalized = (Vector3.ProjectOnPlane(desiredMoveVector, surfaceNormal).normalized - surfaceNormal * 0.5f).normalized;
			if (Physics.SphereCast(rigid.worldCenterOfMass, surfaceProbeRadius, normalized, out var hitInfo, surfaceCheckDistance, surfaceMask, QueryTriggerInteraction.Ignore))
			{
				surfaceNormal = Vector3.Slerp(surfaceNormal, hitInfo.normal, cornerAlignSpeed * Time.fixedDeltaTime);
			}
		}
	}

	public void ForceDetach()
	{
		forceDetached = true;
		currentVelocity = Vector3.zero;
		SetWorldGravity(enabled: true);
	}

	public void AllowReattach()
	{
		forceDetached = false;
	}

	public override void Jump(float mult = 1f, float leap = 0f)
	{
		Vector3 vector = ent.transform.forward * leap;
		rigid.AddForce(jumpForce * (ent.transform.up + Vector3.up * 0.5f) * mult + vector, ForceMode.VelocityChange);
		SetWorldGravity(enabled: true);
		jumpTime = 0.5f;
		jumping = true;
	}

	public void Land()
	{
		if (jumping)
		{
			jumping = false;
			SetWorldGravity(enabled: false);
		}
	}

	public override Vector3 GetVelocity()
	{
		return currentVelocity;
	}

	public override void AddForce(Vector3 f)
	{
		rigid.AddForce(f);
		base.AddForce(f);
	}

	public override void SetSpeedMult(float mult)
	{
		speedMult = mult;
		base.SetSpeedMult(mult);
	}
}
