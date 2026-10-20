using UnityEngine;

public class UT_LookAt : MonoBehaviour
{
	public Transform target;

	public bool lockXRotation;

	public bool lockYRotation;

	public bool lockZRotation;

	public float trackSpeed = 10f;

	private void Update()
	{
		if (target != null)
		{
			Quaternion identity = Quaternion.identity;
			Transform parent = base.transform;
			if (base.transform.parent != null)
			{
				parent = base.transform.parent;
			}
			Vector3 eulerAngles = Quaternion.LookRotation(parent.InverseTransformVector(target.position - base.transform.position)).eulerAngles;
			Vector3 eulerAngles2 = base.transform.localRotation.eulerAngles;
			if (lockXRotation)
			{
				eulerAngles.x = eulerAngles2.x;
			}
			if (lockYRotation)
			{
				eulerAngles.y = eulerAngles2.y;
			}
			if (lockZRotation)
			{
				eulerAngles.z = eulerAngles2.z;
			}
			base.transform.localRotation = Quaternion.Lerp(base.transform.localRotation, Quaternion.Euler(eulerAngles), Time.deltaTime * trackSpeed);
		}
	}

	public void SetTarget(Transform t)
	{
		target = t;
	}
}
