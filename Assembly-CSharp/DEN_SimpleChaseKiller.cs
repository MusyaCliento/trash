using System.Collections.Generic;
using Drawing;
using UnityEngine;

public class DEN_SimpleChaseKiller : Denizen
{
	protected Queue<Vector3> playerTrackPositions;

	private Vector3 lastPlayerTrackPosition;

	public string mood = "Pissed Off";

	public float speed = 1f;

	protected float curSpeed = 1f;

	public float speedIncreaseRate = 0.1f;

	public float speedMax = 100000000f;

	public float trackPositionDistance = 0.5f;

	public float stopAtDistance;

	private Rigidbody rigid;

	public float contactPushForce = 1f;

	private Vector3 contactDir;

	private bool targetVisible;

	public bool ignoreCollisions;

	public bool canKillPlayer = true;

	public override void Start()
	{
		base.Start();
		playerTrackPositions = new Queue<Vector3>();
		curSpeed = speed;
		base.transform.parent = null;
		rigid = GetComponent<Rigidbody>();
		target = ENT_Player.playerObject.transform;
	}

	public override void Update()
	{
		base.Update();
		TrackPlayerPosition();
		Movement();
		contactDir = Vector3.Lerp(contactDir, Vector3.zero, Time.deltaTime * 2f);
		if (ENT_Player.playerObject.IsDead())
		{
			Object.Destroy(base.gameObject);
		}
		else if (CL_UIManager.debug)
		{
			CL_DebugView.draw.Cross(base.transform.position, 0.3f, new Color(1f, 0f, 0f, 0.5f));
			CL_DebugView.draw.Label2D(base.transform.position + Vector3.up, "Using F5 to spy is cringe.", 16f, LabelAlignment.Center);
			CL_DebugView.draw.Label2D(base.transform.position + Vector3.up * 2f, "Mood: " + mood + ".", 14f, LabelAlignment.Center);
			CL_DebugView.draw.Label2D(base.transform.position + Vector3.up * -1f, "Speed: " + curSpeed, 14f, LabelAlignment.Center);
		}
	}

	private void Movement()
	{
		if (playerTrackPositions.Count > 0)
		{
			curSpeed = Mathf.Min(curSpeed + Time.deltaTime * speedIncreaseRate, speedMax);
			Vector3 vector = playerTrackPositions.Peek();
			Vector3 normalized = (vector - base.transform.position).normalized;
			float num = ((target != null) ? Vector3.Distance(target.position, base.transform.position) : float.PositiveInfinity);
			float num2 = float.PositiveInfinity;
			if (playerTrackPositions.Count == 1)
			{
				num2 = Mathf.Max(num - stopAtDistance, 0f);
			}
			if ((num > 10f && !targetVisible) || ignoreCollisions)
			{
				rigid.isKinematic = true;
				base.transform.position += Vector3.ClampMagnitude(normalized * Time.deltaTime * curSpeed, num2);
			}
			else
			{
				rigid.isKinematic = false;
				rigid.linearVelocity = normalized * Mathf.Min(curSpeed, num2) + contactDir * contactPushForce;
			}
			if (Vector3.Distance(base.transform.position, vector) < trackPositionDistance)
			{
				playerTrackPositions.Dequeue();
			}
			if (canKillPlayer && num < 2f)
			{
				ENT_Player.playerObject.Kill(objectType);
			}
			if (num < stopAtDistance)
			{
				playerTrackPositions.Clear();
			}
		}
	}

	private void TrackPlayerPosition()
	{
		if (!(target == null))
		{
			targetVisible = sight.CanSeeTarget(target);
			if (targetVisible)
			{
				playerTrackPositions.Clear();
				playerTrackPositions.Enqueue(target.position);
			}
			if (Vector3.Distance(lastPlayerTrackPosition, target.position) > trackPositionDistance)
			{
				playerTrackPositions.Enqueue(target.position);
				lastPlayerTrackPosition = target.position;
			}
		}
	}

	private void OnCollisionStay(Collision collision)
	{
		contactDir = Vector3.zero;
		ContactPoint[] contacts = collision.contacts;
		foreach (ContactPoint contactPoint in contacts)
		{
			contactDir += contactPoint.normal;
		}
	}
}
