using System;
using UnityEngine;

[Serializable]
public class UT_FollowBase
{
	public bool followRotation;

	public bool lerpToTarget;

	public float speed = 5f;

	[Header("Movement Axis Lock")]
	public bool lockX;

	public bool lockY;

	public bool lockZ;

	[Header("Rotation Axis Lock")]
	public bool lockXRot;

	public bool lockYRot;

	public bool lockZRot;

	public void MoveToTarget(Transform root, Transform target)
	{
		if (!target)
		{
			return;
		}
		Vector3 position = target.position;
		Quaternion quaternion = target.rotation;
		if (lockX)
		{
			position.x = root.position.x;
		}
		if (lockY)
		{
			position.y = root.position.y;
		}
		if (lockZ)
		{
			position.z = root.position.z;
		}
		if (lockXRot)
		{
			quaternion = Quaternion.Euler(root.rotation.eulerAngles.x, quaternion.eulerAngles.y, quaternion.eulerAngles.z);
		}
		if (lockYRot)
		{
			quaternion = Quaternion.Euler(quaternion.eulerAngles.x, root.rotation.eulerAngles.y, quaternion.eulerAngles.z);
		}
		if (lockZRot)
		{
			quaternion = Quaternion.Euler(quaternion.eulerAngles.x, quaternion.eulerAngles.y, root.rotation.eulerAngles.z);
		}
		if (lerpToTarget)
		{
			root.position = Vector3.Lerp(root.position, position, Time.deltaTime * speed);
		}
		else
		{
			root.position = position;
		}
		if (followRotation)
		{
			if (lerpToTarget)
			{
				root.rotation = Quaternion.Lerp(root.rotation, quaternion, Time.deltaTime * speed);
			}
			else
			{
				root.rotation = quaternion;
			}
		}
	}
}
