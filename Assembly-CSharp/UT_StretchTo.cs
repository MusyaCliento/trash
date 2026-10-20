using UnityEngine;

public class UT_StretchTo : MonoBehaviour
{
	public bool useRaycast;

	public LayerMask layerMask;

	public float maxDistance;

	public Transform target;

	private void Start()
	{
	}

	private void LateUpdate()
	{
		if (useRaycast)
		{
			if (Physics.Raycast(base.transform.position, base.transform.forward, out var hitInfo, maxDistance, layerMask))
			{
				float z = Vector3.Distance(hitInfo.point, base.transform.position);
				base.transform.localScale = new Vector3(1f, 1f, z);
			}
			else
			{
				base.transform.localScale = new Vector3(1f, 1f, maxDistance);
			}
		}
		else
		{
			float z2 = Vector3.Distance(target.position, base.transform.position);
			base.transform.rotation = Quaternion.LookRotation(target.position - base.transform.position, base.transform.up);
			base.transform.localScale = new Vector3(1f, 1f, z2);
		}
	}
}
