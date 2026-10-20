using System;
using UnityEngine;

[Serializable]
public class DenizenMovement_BasicFlier : DenizenMovementModule
{
	public float flySpeed = 1f;

	public float flySpeedClamp = 1f;

	public float rotationSpeed = 2f;

	public float maxBankAngle = 45f;

	public bool allowRotation = true;

	[Header("Avoidance")]
	public bool avoidGround;

	public float hoverDistance = 3f;

	public float groundAvoidForce = 10f;

	[Header("Physics")]
	public float pGain = 1f;

	public float iGain = 0.1f;

	public float dGain = 0.5f;

	public Vector3 directionalPIDAdjust = new Vector3(1f, 1f, 1f);

	private Rigidbody rigid;

	private Vector3 positionErrorSum = Vector3.zero;

	private Vector3 lastPositionError = Vector3.zero;

	[Header("Noise")]
	public float noiseIntensity = 0.5f;

	public float noiseFrequency = 1f;

	private float noiseOffsetX;

	private float noiseOffsetY;

	private float noiseOffsetZ;

	private float noiseOffsetRand;

	private Vector3 landDir;

	private Vector3 lookVector;

	[Header("Crawl Settings")]
	public float crawlSpeed = 1f;

	public bool canCrawl;

	public bool isCrawling;

	public bool canCrawlWhileHunting;

	public LayerMask flyMask;

	private Vector3 wallNormal;

	private Vector3 facingDir;

	private Denizen denizen;

	public bool faceMovementVectorWhenDead = true;

	public bool disableMovementWhenDead;

	private float angleDifference;

	private Vector3 lastPIDOutput;

	private Collision collision;

	public override void Initialize(GameEntity gE)
	{
		rigid = gE.GetComponent<Rigidbody>();
		base.Initialize(gE);
		noiseOffsetRand = UnityEngine.Random.value * 1000f;
		if (gE is Denizen)
		{
			denizen = gE as Denizen;
		}
	}

	public override void Update()
	{
		base.Update();
		Movement();
	}

	private void Movement()
	{
		if (!denizen.dead || !disableMovementWhenDead)
		{
			ApplyBankingRotation();
			if (isCrawling)
			{
				Crawl();
			}
			else
			{
				Fly();
			}
		}
	}

	private void Fly()
	{
		rigid.useGravity = true;
		rigid.isKinematic = false;
		AvoidGround();
		Vector3 vector = new Vector3(Mathf.PerlinNoise(Time.time * noiseFrequency + noiseOffsetX + noiseOffsetRand, 0f) - 0.5f, Mathf.PerlinNoise(Time.time * noiseFrequency + noiseOffsetY + 600f + noiseOffsetRand, 0f) - 0.5f, Mathf.PerlinNoise(Time.time * noiseFrequency + noiseOffsetZ + 1500f + noiseOffsetRand, 0f) - 0.5f);
		vector *= noiseIntensity;
		Vector3 vector2 = Vector3.Scale(targetPosition - ent.transform.position, directionalPIDAdjust);
		Vector3 vector3 = vector2;
		positionErrorSum = Vector3.ClampMagnitude(positionErrorSum, 1f);
		positionErrorSum += vector2 * Time.fixedDeltaTime;
		if (CL_UIManager.debug)
		{
			CL_DebugView.draw.Arrow(ent.transform.position, ent.transform.position + positionErrorSum, Color.green);
			CL_DebugView.draw.Arrow(ent.transform.position, ent.transform.position + rigid.linearVelocity, Color.blue);
			CL_DebugView.draw.Arrow(ent.transform.position, ent.transform.position + vector2, Color.red);
		}
		Vector3 vector4 = positionErrorSum;
		Vector3 vector5 = (vector2 - lastPositionError) / Time.fixedDeltaTime;
		Vector3 vector6 = pGain * vector3 + iGain * vector4 + dGain * vector5;
		vector6 = Vector3.ClampMagnitude(vector6 * flySpeed, flySpeedClamp);
		rigid.AddForce((vector6 + vector) * Time.deltaTime * 100f);
		lastPIDOutput = vector6 + vector;
		if (!canMove)
		{
			Vector3 linearVelocity = rigid.linearVelocity;
			linearVelocity.x = 0f;
			linearVelocity.z = 0f;
			rigid.linearVelocity = linearVelocity;
		}
		lookVector = Vector3.Scale((rigid.linearVelocity.normalized + vector2.normalized).normalized, new Vector3(1f, 0.2f, 1f));
		lastPositionError = vector2;
	}

	private void AvoidGround()
	{
		if (avoidGround && Physics.Raycast(ent.transform.position, -Vector3.up, out var _, hoverDistance, flyMask))
		{
			rigid.AddForce(Vector3.up * groundAvoidForce * Time.deltaTime * 100f, ForceMode.Acceleration);
		}
	}

	private void ApplyBankingRotation()
	{
		if (allowRotation)
		{
			if (lookVector.magnitude < 0.01f)
			{
				lookVector = targetPosition - ent.transform.position;
			}
			if (faceMovementVectorWhenDead && ent.dead && !IsGrounded())
			{
				ent.transform.rotation = Quaternion.Lerp(ent.transform.rotation, Quaternion.LookRotation(Vector3.up, rigid.linearVelocity), Time.fixedDeltaTime * 5f);
				return;
			}
			Vector3 normalized = lookVector.normalized;
			normalized.y *= 0.3f;
			angleDifference = Vector3.SignedAngle(ent.transform.forward, normalized, Vector3.up);
			float num = Mathf.Clamp(angleDifference, 0f - maxBankAngle, maxBankAngle);
			Quaternion quaternion2 = Quaternion.Euler(0f, 0f, 0f - num);
			Quaternion b = Quaternion.LookRotation(normalized, Vector3.up) * quaternion2;
			ent.transform.rotation = Quaternion.Slerp(ent.transform.rotation, b, Time.deltaTime * rotationSpeed);
		}
	}

	public override void SetLookVector(Vector3 v)
	{
		lookVector = v;
	}

	public override void SetTargetPosition(Vector3 t)
	{
		targetPosition = t;
	}

	private void Crawl()
	{
		if (isCrawling && Vector3.Distance(ent.transform.position, targetPosition) > 3f)
		{
			isCrawling = false;
			return;
		}
		if (isCrawling && !canCrawlWhileHunting && denizen != null && denizen.currentState != null && denizen.currentState.name == "hunt")
		{
			isCrawling = false;
			return;
		}
		if (!rigid.isKinematic)
		{
			rigid.linearVelocity = targetPosition - ent.transform.position;
		}
		if (rigid.isKinematic)
		{
			ent.transform.rotation = Quaternion.Lerp(ent.transform.rotation, Quaternion.LookRotation(facingDir, wallNormal), Time.fixedDeltaTime * 5f);
		}
		if (collision != null && collision.contactCount > 0)
		{
			rigid.useGravity = false;
			if (!rigid.isKinematic)
			{
				rigid.linearVelocity = Vector3.zero;
			}
			wallNormal = (targetPosition - ent.transform.position).normalized;
			if (Physics.Raycast(ent.transform.position, collision.GetContact(0).point - ent.transform.position, out var hitInfo, 5f, flyMask))
			{
				wallNormal = hitInfo.normal;
			}
			float num = Vector3.Dot(landDir, wallNormal);
			if ((double)num < -0.8 || num > 0.1f)
			{
				landDir = Vector3.ProjectOnPlane(UnityEngine.Random.onUnitSphere, wallNormal).normalized;
			}
			if (rigid.linearVelocity.magnitude > 0.1f)
			{
				facingDir = Vector3.ProjectOnPlane(landDir, wallNormal).normalized;
			}
			else
			{
				facingDir = Vector3.ProjectOnPlane(landDir, wallNormal).normalized;
				rigid.isKinematic = true;
			}
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Arrow(ent.transform.position, ent.transform.position + facingDir, wallNormal, 0.5f, Color.yellow);
				CL_DebugView.draw.Arrow(ent.transform.position, ent.transform.position + wallNormal, wallNormal, 0.5f, Color.red);
			}
			ent.transform.rotation = Quaternion.Lerp(ent.transform.rotation, Quaternion.LookRotation(facingDir, wallNormal), Time.fixedDeltaTime * 5f);
		}
	}

	public override void OnCollisionEnter(Collision other)
	{
		if (!(ent == null))
		{
			if (ent.dead)
			{
				isCrawling = true;
			}
			if ((canCrawlWhileHunting || !(denizen != null) || denizen.currentState == null || !(denizen.currentState.name == "hunt")) && canCrawl && (other.gameObject.layer == LayerMask.NameToLayer("World") || other.gameObject.layer == LayerMask.NameToLayer("Default")) && !other.gameObject.GetComponent<GameEntity>())
			{
				isCrawling = true;
				landDir = ent.transform.forward;
				collision = other;
			}
		}
	}

	public override void OnCollisionExit(Collision other)
	{
		if (ent.dead)
		{
			isCrawling = false;
		}
	}

	public override void Jump(float mult = 1f, float leap = 0f)
	{
		base.Jump(mult, leap);
		isCrawling = false;
		rigid.useGravity = true;
		rigid.isKinematic = false;
	}

	public float GetLastAngleDifference()
	{
		return angleDifference;
	}

	public Vector3 GetLastPIDOutput()
	{
		return lastPIDOutput;
	}

	public override bool IsGrounded()
	{
		return isCrawling;
	}
}
