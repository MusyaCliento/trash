using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DenizenMovement_SteeringVehicle : DenizenMovementModule
{
	public List<string> tags;

	public float mass = 1f;

	public float maxSpeed = 1f;

	public float maxForce = 1f;

	public float addForceMultiplayer = 1f;

	public bool turnToFaceHeading;

	public float maxTurnRate = 1f;

	public float velocityMult = 1f;

	private Vector3 heading;

	private Vector3 side;

	private SteeringModule steeringModule;

	internal float speedMult = 1f;

	public bool useSeek;

	public float seekAmount = 1f;

	internal float seekMult = 1f;

	public bool useWander;

	public float wanderAmount = 1f;

	public float wanderRadius;

	public float wanderDistance;

	public float wanderJitter;

	internal float wanderMult = 1f;

	public LayerMask blockMask;

	public float sphereRadius = 1f;

	public float raycastAvoidSpeed = 5f;

	public bool useFlee;

	public List<string> avoidTags;

	public float avoidStrength = 10f;

	public float avoidRadius = 1f;

	public Rigidbody rigidbody;

	private string instanceId;

	private bool isStuck;

	private float stuckTime;

	private Vector3 lastStuckPosition;

	public override void Start()
	{
		base.Start();
		steeringModule = new SteeringModule();
	}

	public override void Initialize(GameEntity gE)
	{
		base.Initialize(gE);
		instanceId = ent.gameObject.GetInstanceID().ToString();
	}

	public override void Update()
	{
		base.Update();
		Vector3 vector = steeringModule.Calculate() / mass;
		velocity += vector * Time.deltaTime;
		heading = velocity.normalized;
		side = Vector3.Cross(heading, Vector3.up);
		if (!rigidbody)
		{
			ent.transform.position += velocity * Time.deltaTime * velocityMult;
			if (turnToFaceHeading)
			{
				ent.transform.rotation = Quaternion.Lerp(ent.transform.rotation, Quaternion.LookRotation(heading, Vector3.up), maxTurnRate * Time.deltaTime);
			}
		}
		else
		{
			if (Vector3.Distance(ent.transform.position, lastStuckPosition) > 0.1f)
			{
				lastStuckPosition = ent.transform.position;
				stuckTime = 0f;
			}
			else
			{
				stuckTime += Time.deltaTime;
				if (stuckTime > 3f)
				{
					ent.transform.position += velocity * velocityMult * 0.5f;
				}
			}
			rigidbody.linearVelocity = velocity * velocityMult * addForceMultiplayer;
			if (turnToFaceHeading)
			{
				rigidbody.MoveRotation(Quaternion.Lerp(rigidbody.transform.rotation, Quaternion.LookRotation(heading, Vector3.up), maxTurnRate * Time.deltaTime));
			}
		}
		float num = speedMult * maxSpeed;
		if (useSeek)
		{
			Vector3 vector2 = Steering.Seek(currentPosition, targetPosition, num * velocityMult, velocity) * seekAmount * seekMult;
			velocity += vector2 * Time.deltaTime;
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Arrow(currentPosition, currentPosition + vector2 * 1f, Color.green);
			}
		}
		if (useWander)
		{
			Vector3 vector3 = Steering.Wander(currentPosition, num * velocityMult, velocity, wanderRadius, wanderDistance, wanderJitter) * wanderMult * wanderAmount;
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Arrow(currentPosition, currentPosition + vector3 * 1f, Color.green);
			}
			velocity += vector3 * Time.deltaTime;
		}
		if (useFlee)
		{
			Vector3 vector4 = Steering.Flee(currentPosition, num * velocityMult, velocity, avoidTags, avoidRadius, instanceId) * avoidStrength;
			velocity += vector4 * Time.deltaTime;
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Arrow(currentPosition, currentPosition + vector4 * 1f, Color.yellow);
			}
		}
		if (CL_UIManager.debug)
		{
			CL_DebugView.draw.Arrow(currentPosition, currentPosition + velocity * 1f, Color.white);
		}
		if (Physics.SphereCast(ent.transform.position, sphereRadius, velocity.normalized, out var hitInfo, velocity.magnitude, blockMask))
		{
			velocity = Vector3.Lerp(velocity, Vector3.ProjectOnPlane(velocity, hitInfo.normal).normalized * velocity.magnitude, Time.deltaTime * raycastAvoidSpeed);
		}
		velocity = Vector3.ClampMagnitude(velocity, maxForce);
	}

	public new void SetTargetPosition(Vector3 pos)
	{
		targetPosition = pos;
	}

	public float GetCurSpeed()
	{
		return speedMult * velocityMult;
	}

	public bool IsStuck()
	{
		return isStuck;
	}
}
