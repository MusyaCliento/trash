using UnityEngine;

public struct InteractHit
{
	public Vector3 point;

	public float distance;

	public Collider collider;

	public Vector3 normal;

	public Transform transform;

	public Rigidbody rigidbody;

	public InteractHit(RaycastHit hit)
	{
		point = hit.point;
		distance = hit.distance;
		collider = hit.collider;
		normal = hit.normal;
		transform = hit.transform;
		rigidbody = hit.rigidbody;
	}

	public readonly bool IsValid()
	{
		return distance > 0f;
	}
}
