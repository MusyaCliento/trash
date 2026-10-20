using System.Collections.Generic;
using UnityEngine;

public class DEN_Hunter_Arm : MonoBehaviour
{
	private Vector3 targetPosition;

	private bool isLatched;

	private Vector3 targetNormal = Vector3.up;

	public List<Transform> armSegments;

	public Transform endTransform;

	private float totalLength;

	private void Start()
	{
		totalLength = 0f;
		for (int i = 0; i < armSegments.Count - 1; i++)
		{
			totalLength += Vector3.Distance(armSegments[i].position, armSegments[i + 1].position);
		}
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
		Solve(armSegments, targetPosition, 5, 0.7f);
		ApplyPoleNormal(armSegments, targetNormal, 0.8f);
	}

	public void Solve(List<Transform> chain, Vector3 targetPosition, int iterations = 5, float damping = 1f)
	{
		for (int i = 0; i < chain.Count - 1; i++)
		{
			chain[i].localScale = Vector3.one;
		}
		if (chain == null || chain.Count < 2)
		{
			return;
		}
		Transform obj = chain[0];
		Transform transform = chain[chain.Count - 1];
		Vector3.Distance(obj.position, targetPosition);
		for (int j = 0; j < iterations; j++)
		{
			for (int num = chain.Count - 2; num >= 0; num--)
			{
				Transform transform2 = chain[num];
				Vector3 fromDirection = transform.position - transform2.position;
				Vector3 toDirection = targetPosition - transform2.position;
				if (!(fromDirection.sqrMagnitude < 0.0001f) && !(toDirection.sqrMagnitude < 0.0001f))
				{
					Quaternion quaternion = Quaternion.FromToRotation(fromDirection, toDirection);
					transform2.rotation = Quaternion.Slerp(transform2.rotation, quaternion * transform2.rotation, damping);
				}
			}
		}
	}

	public static void ApplyPoleNormal(List<Transform> chain, Vector3 poleNormal, float weight = 1f)
	{
		if (chain == null || chain.Count < 3)
		{
			return;
		}
		Transform transform = chain[0];
		Vector3 vector = chain[chain.Count - 1].position - transform.position;
		if (vector.sqrMagnitude < 0.0001f)
		{
			return;
		}
		vector.Normalize();
		Vector3 normalized = Vector3.ProjectOnPlane(poleNormal, vector).normalized;
		if (normalized.sqrMagnitude < 0.0001f)
		{
			return;
		}
		_ = Vector3.Cross(normalized, vector).normalized;
		for (int i = 0; i < chain.Count - 1; i++)
		{
			Transform transform2 = chain[i];
			Vector3 normalized2 = (chain[i + 1].position - transform2.position).normalized;
			if (!(normalized2.sqrMagnitude < 0.0001f))
			{
				Vector3 normalized3 = Vector3.ProjectOnPlane(normalized2, normalized).normalized;
				if (!(normalized3.sqrMagnitude < 0.0001f))
				{
					Quaternion quaternion = Quaternion.FromToRotation(normalized2, normalized3);
					transform2.rotation = Quaternion.Slerp(transform2.rotation, quaternion * transform2.rotation, weight);
				}
			}
		}
	}

	public void SetTargetPosition(Vector3 pos)
	{
		targetPosition = pos;
	}

	public Vector3 GetTargetPosition()
	{
		return targetPosition;
	}

	public void SetTargetPosition(Vector3 pos, Vector3 normal)
	{
		targetPosition = pos;
		targetNormal = normal;
	}

	public Vector3 GetDefaultEndPosition()
	{
		return endTransform.position;
	}

	public void SetLatched(bool b)
	{
		isLatched = b;
	}
}
