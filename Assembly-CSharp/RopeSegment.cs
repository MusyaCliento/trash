using UnityEngine;

public class RopeSegment
{
	public Vector3 Position;

	public Vector3 TargetPosition;

	public Vector3 Velocity;

	public RopeSegment(Vector3 initialPosition)
	{
		Position = initialPosition;
		TargetPosition = initialPosition;
		Velocity = Vector3.zero;
	}
}
