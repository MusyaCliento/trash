using System;
using System.Collections.Generic;
using DitzelGames.FastIK;
using Pathfinding;
using UnityEngine;

[RequireComponent(typeof(UT_AudioClipHandler))]
public class TheClamberer : MonoBehaviour
{
	[Serializable]
	public class Limb
	{
		public enum LimbState
		{
			idle = 0,
			reaching = 1,
			grabbed = 2
		}

		public FastIKFabric ikSolver;

		public Transform parent;

		public bool grabbing;

		public Vector3 grabTarget;

		public float maxReach;

		private float reachValue;

		public float releaseValue = 0.5f;

		public float releaseWait = 1f;

		private float releaseWaitTime;

		public LimbState limbState;

		private Vector3 limbDirection;

		public void Initialize()
		{
			limbDirection = parent.up;
		}

		public bool ShouldLetGo(Vector3 dVel, Vector3 dPos)
		{
			_ = grabTarget - dPos;
			Vector3 up = parent.up;
			float num = Vector3.Dot(grabTarget, up);
			float num2 = Vector3.Distance(parent.position, grabTarget);
			if (num < 0f - releaseValue || num2 > maxReach)
			{
				return true;
			}
			return false;
		}

		private float CalculateGrabHeuristic(Vector3 hitPos, Vector3 dPos, Vector3 dVel)
		{
			Vector3 lhs = hitPos - dPos;
			float num = hitPos.y - dPos.y;
			Vector3 up = parent.up;
			float num2 = Vector3.Dot(lhs, up);
			float num3 = Vector3.Distance(parent.position, hitPos);
			if (num2 < 0f)
			{
				return float.NegativeInfinity;
			}
			if (num3 > maxReach)
			{
				return float.NegativeInfinity;
			}
			return (Vector3.Dot(lhs.normalized, dVel.normalized) + 1f + num * 0.3f) * (num2 + 1f);
		}

		public void ChooseGrabTarget(Vector3[] hits, Vector3 dPos, Vector3 dVel)
		{
			Vector3 vector = hits[0];
			float num = -10f;
			bool flag = false;
			for (int i = 0; i < hits.Length; i++)
			{
				flag = true;
				float num2 = CalculateGrabHeuristic(hits[i], dPos, dVel);
				if (num2 != float.NegativeInfinity && num2 > num)
				{
					num = num2;
					vector = hits[i];
				}
			}
			if (grabbing)
			{
				float num3 = CalculateGrabHeuristic(grabTarget, dPos, dVel);
				if (num3 > num)
				{
					num = num3;
					vector = grabTarget;
				}
			}
			CL_DebugView.draw.Label2D(ikSolver.transform.position, "H: " + num, 12f, Color.white);
			if (num > 0.5f && releaseWaitTime <= 0f && flag)
			{
				grabTarget = vector;
				grabbing = true;
				releaseWaitTime = releaseWait;
			}
		}

		public void Release()
		{
			grabbing = false;
			releaseWaitTime = releaseWait;
		}

		public void Animate(Vector3 dVel, Vector3 dPos)
		{
			if (releaseWaitTime > 0f)
			{
				releaseWaitTime -= Time.deltaTime;
			}
			Vector3 up = parent.up;
			CL_DebugView.draw.Line(parent.position, parent.position + up, Color.red);
			if (grabbing && ShouldLetGo(dVel, dPos))
			{
				Release();
			}
			if (grabbing)
			{
				ikSolver.Target.position = Vector3.Lerp(ikSolver.Target.position, grabTarget, Time.deltaTime * 6f);
				CL_DebugView.draw.SphereOutline(grabTarget, 0.3f, Color.red);
				if (reachValue < 1f)
				{
					reachValue += Time.deltaTime;
					limbState = LimbState.reaching;
				}
				else
				{
					reachValue = 1f;
					limbState = LimbState.grabbed;
				}
				Vector3.Distance(parent.position, grabTarget);
			}
			else
			{
				ikSolver.Target.position = Vector3.Lerp(ikSolver.Target.position, ikSolver.transform.position + Vector3.down * 0.1f, Time.deltaTime * 6f);
				if (reachValue > 0f)
				{
					reachValue -= Time.deltaTime;
					limbState = LimbState.reaching;
				}
				else
				{
					reachValue = 0f;
					limbState = LimbState.idle;
				}
			}
		}
	}

	public enum ClambererAIStates
	{
		idling = 0,
		chasing = 1,
		charging = 2,
		hunting = 3,
		waiting = 4,
		running = 5
	}

	public enum AIMoveStates
	{
		normal = 0,
		jumping = 1,
		climbing = 2,
		crawling = 3,
		falling = 4
	}

	[Header("Movement")]
	public float huntSpeed = 1f;

	public float chaseSpeed;

	public float stopDistance = 3f;

	private Vector3 velocity;

	private Rigidbody rigid;

	[Header("AI")]
	public ClambererAIStates aiState = ClambererAIStates.hunting;

	public AIMoveStates moveState;

	public Transform target;

	public float sightDistance = 10f;

	public float memoryTime = 10f;

	private float curMemory;

	private Vector3 memoryTarget;

	private float targetDistance;

	private bool targetVisible;

	public LayerMask levelMask;

	private float grabPoints;

	private Vector3 surfaceDir = Vector3.forward;

	private List<Vector3> foundHits = new List<Vector3>();

	private float pathCheckTime = 1f;

	private bool findingPath;

	private Seeker seeker;

	private Path path;

	private float nextWaypointDistance = 3f;

	private int currentWaypoint;

	private bool reachedEndOfPath;

	[Header("Audio")]
	private UT_AudioClipHandler clipHandler;

	public float randomSoundInterval = 4f;

	private float randomSoundTime;

	[Header("Animation")]
	public float rotationSpeed = 5f;

	private void Start()
	{
		rigid = GetComponent<Rigidbody>();
		seeker = GetComponent<Seeker>();
		clipHandler = GetComponent<UT_AudioClipHandler>();
		randomSoundTime = randomSoundInterval;
	}

	private void Update()
	{
		if (target == null)
		{
			return;
		}
		targetDistance = Vector3.Distance(base.transform.position, target.position);
		DecisionTree();
		Movement();
		RandomNoises();
		if (CL_UIManager.debug)
		{
			CL_DebugView.draw.SphereOutline(base.transform.position, 0.3f, Color.yellow);
			CL_DebugView.draw.Arrowhead(base.transform.position + rigid.linearVelocity, rigid.linearVelocity, 0.5f, Color.yellow);
			CL_DebugView.draw.Arrowhead(base.transform.position + surfaceDir.normalized, surfaceDir, 0.25f, Color.cyan);
			CL_DebugView.draw.Label2D(base.transform.position + Vector3.up, "Clamberer : " + aiState, 10f, Color.yellow);
			if (CanSeeTarget(target, sightDistance))
			{
				CL_DebugView.draw.Label2D(base.transform.position + Vector3.up * 1.2f, "TARGET VISIBLE", 16f, Color.red);
			}
			CL_DebugView.draw.Cross(memoryTarget, 0.8f, Color.blue);
			CL_DebugView.draw.SphereOutline(memoryTarget, 2f, Color.blue);
		}
	}

	private void DecisionTree()
	{
		if (CanSeeTarget(target, sightDistance))
		{
			if (!targetVisible)
			{
				clipHandler.PlaySound("clamberer:target-sighted");
			}
			targetVisible = true;
			if (targetDistance < 5f)
			{
				aiState = ClambererAIStates.charging;
			}
			else
			{
				aiState = ClambererAIStates.chasing;
			}
			memoryTarget = target.position;
			curMemory = memoryTime;
		}
		else if (curMemory >= 0f)
		{
			curMemory -= Time.deltaTime;
			aiState = ClambererAIStates.chasing;
			if (reachedEndOfPath)
			{
				memoryTarget = target.position + UnityEngine.Random.insideUnitSphere * 10f;
				reachedEndOfPath = false;
			}
		}
		else
		{
			if (targetVisible)
			{
				targetVisible = false;
				clipHandler.PlaySound("clamberer:target-lost");
			}
			aiState = ClambererAIStates.hunting;
			if (reachedEndOfPath)
			{
				memoryTarget = target.position + UnityEngine.Random.insideUnitSphere * 10f;
				reachedEndOfPath = false;
			}
		}
		if (pathCheckTime > 0f)
		{
			pathCheckTime -= Time.deltaTime;
		}
		else if (!findingPath)
		{
			findingPath = true;
			seeker.StartPath(base.transform.position, memoryTarget, OnPathComplete);
		}
	}

	private void Movement()
	{
		Vector3 vector = target.position - base.transform.position;
		Vector3 vector2 = target.position - vector.normalized * stopDistance;
		DebugMenu.UpdateDebugText("creature-surface", Vector3.Dot(surfaceDir.normalized, Vector3.up).ToString() ?? "");
		float num = 1f;
		base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(Vector3.Scale(surfaceDir.normalized, new Vector3(1f, 0f, 1f))), Time.deltaTime * rotationSpeed);
		num = ((aiState != ClambererAIStates.chasing && aiState != ClambererAIStates.charging) ? (num * huntSpeed) : (num * chaseSpeed));
		if (path == null)
		{
			return;
		}
		Vector3 zero = Vector3.zero;
		if (aiState != ClambererAIStates.charging)
		{
			reachedEndOfPath = false;
			float num2;
			while (true)
			{
				num2 = Vector3.Distance(base.transform.position, path.vectorPath[currentWaypoint]);
				if (!(num2 < nextWaypointDistance * 1.5f))
				{
					break;
				}
				if (currentWaypoint + 1 < path.vectorPath.Count)
				{
					currentWaypoint++;
					continue;
				}
				reachedEndOfPath = true;
				break;
			}
			float num3 = (reachedEndOfPath ? Mathf.Sqrt(num2 / nextWaypointDistance) : 1f);
			vector = (path.vectorPath[currentWaypoint] - base.transform.position).normalized;
			zero = vector * num * num3;
		}
		else
		{
			zero = (vector2 - base.transform.position).normalized * num;
		}
		ScanAround();
		float num4 = (1f - grabPoints) * -16f;
		zero.y += num4;
		rigid.linearVelocity += zero * Time.deltaTime;
	}

	private void RandomNoises()
	{
		if (randomSoundTime >= 0f)
		{
			randomSoundTime -= Time.deltaTime;
			return;
		}
		randomSoundTime = randomSoundInterval;
		clipHandler.PlaySound("clamberer:random");
	}

	public void ScanAround()
	{
		grabPoints = 0f;
		int num = 32;
		Vector3[] array = GenerateEquidistantVectors(num);
		Vector3 zero = Vector3.zero;
		zero = rigid.linearVelocity.normalized * 0.5f;
		float num2 = 3f;
		foundHits.Clear();
		for (int i = 0; i < num; i++)
		{
			Vector3 vector = array[i] - Vector3.ClampMagnitude(rigid.linearVelocity * 0.25f, 0.9f);
			if (Physics.Raycast(base.transform.position, vector, out var hitInfo, num2, levelMask))
			{
				if (hitInfo.distance < num2 / 4f)
				{
					rigid.linearVelocity += -vector * Time.deltaTime * 1f;
				}
				else
				{
					rigid.linearVelocity += vector * Time.deltaTime * 1f;
				}
				foundHits.Add(hitInfo.point);
				zero += vector.normalized * 0.8f;
				grabPoints = Mathf.Clamp(grabPoints + 0.5f, 0f, 1f);
				if (CL_UIManager.debug)
				{
					CL_DebugView.draw.Line(base.transform.position, hitInfo.point, new Color(1f, 0f, 0f, 0.1f));
					CL_DebugView.draw.Cross(hitInfo.point, 0.3f, new Color(1f, 0f, 0f, 0.1f));
				}
			}
			else if (CL_UIManager.debug)
			{
				CL_DebugView.draw.DashedLine(base.transform.position, base.transform.position + vector * 3f, 0.1f, 0.1f, new Color(0f, 1f, 0f, 0.02f));
			}
		}
		surfaceDir = Vector3.Lerp(surfaceDir, zero, Time.deltaTime * 10f);
	}

	public bool CanSeeTarget(Transform t, float dist = 10f)
	{
		if (Physics.Raycast(base.transform.position, t.position - base.transform.position, out var hitInfo, dist))
		{
			if (hitInfo.collider.transform == t)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public Vector3[] GenerateEquidistantVectors(int numPoints)
	{
		Vector3[] array = new Vector3[numPoints];
		float num = MathF.PI * (3f - Mathf.Sqrt(5f));
		for (int i = 0; i < numPoints; i++)
		{
			float num2 = 1f - (float)i / (float)(numPoints - 1) * 2f;
			float num3 = Mathf.Sqrt(1f - num2 * num2);
			float f = num * (float)i;
			float x = Mathf.Cos(f) * num3;
			float z = Mathf.Sin(f) * num3;
			array[i] = new Vector3(x, num2, z);
		}
		return array;
	}

	public void OnPathComplete(Path p)
	{
		findingPath = false;
		pathCheckTime = 1f;
		if (!p.error)
		{
			path = p;
			currentWaypoint = 0;
		}
	}
}
