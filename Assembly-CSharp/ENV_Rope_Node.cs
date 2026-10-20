using System;
using UnityEngine;

[Serializable]
public class ENV_Rope_Node
{
	public Vector3 position;

	public Vector3 previousPosition;

	public Transform mesh;

	public bool locked;

	public bool colliding;

	public Vector3 velocity;

	public ENV_Rope_Node(Vector3 initialPosition)
	{
		position = initialPosition;
		previousPosition = initialPosition;
	}
}
