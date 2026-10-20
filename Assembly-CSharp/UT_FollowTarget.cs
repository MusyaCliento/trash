using UnityEngine;

[DefaultExecutionOrder(5)]
public class UT_FollowTarget : MonoBehaviour
{
	public Transform target;

	public UT_FollowBase follow;

	public bool OnLateUpdate;

	private void Update()
	{
		if (!OnLateUpdate)
		{
			follow.MoveToTarget(base.transform, target);
		}
	}

	private void LateUpdate()
	{
		if (OnLateUpdate)
		{
			follow.MoveToTarget(base.transform, target);
		}
	}

	public void SetTarget(Transform t)
	{
		target = t;
	}
}
