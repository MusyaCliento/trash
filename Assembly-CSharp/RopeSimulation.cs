using System.Collections.Generic;
using UnityEngine;

public class RopeSimulation
{
	private List<RopeSegment> ropeSegments;

	private int segmentCount;

	private float segmentLength;

	private float ropeStiffness;

	private Vector3 gravity;

	public RopeSimulation(int segmentCount, float segmentLength, float ropeStiffness, Vector3 gravity)
	{
		this.segmentCount = segmentCount;
		this.segmentLength = segmentLength;
		this.ropeStiffness = ropeStiffness;
		this.gravity = gravity;
		ropeSegments = new List<RopeSegment>();
		for (int i = 0; i < segmentCount; i++)
		{
			ropeSegments.Add(new RopeSegment(Vector3.zero));
		}
	}

	public void SimulateRope(Vector3 startPosition)
	{
		for (int i = 1; i < ropeSegments.Count; i++)
		{
			RopeSegment ropeSegment = ropeSegments[i];
			ropeSegment.Position += (ropeSegment.Velocity += gravity * Time.deltaTime) * Time.deltaTime;
		}
		for (int j = 0; j < 50; j++)
		{
			ApplyConstraints(startPosition);
		}
	}

	private void ApplyConstraints(Vector3 startPosition)
	{
		ropeSegments[0].Position = startPosition;
		for (int i = 0; i < ropeSegments.Count - 1; i++)
		{
			RopeSegment ropeSegment = ropeSegments[i];
			RopeSegment ropeSegment2 = ropeSegments[i + 1];
			float magnitude = (ropeSegment.Position - ropeSegment2.Position).magnitude;
			float num = Mathf.Abs(magnitude - segmentLength);
			Vector3 vector = (ropeSegment.Position - ropeSegment2.Position).normalized * num;
			if (magnitude > segmentLength)
			{
				ropeSegment2.Position += vector * (1f - ropeStiffness);
				ropeSegment.Position -= vector * ropeStiffness;
			}
			else
			{
				ropeSegment2.Position -= vector * (1f - ropeStiffness);
				ropeSegment.Position += vector * ropeStiffness;
			}
			ropeSegments[i] = ropeSegment;
			ropeSegments[i + 1] = ropeSegment2;
			ropeSegment.TargetPosition = ropeSegment2.Position;
		}
	}

	public List<RopeSegment> GetRopeSegments()
	{
		return ropeSegments;
	}
}
