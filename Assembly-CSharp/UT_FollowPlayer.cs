using UnityEngine;

[DefaultExecutionOrder(5)]
public class UT_FollowPlayer : MonoBehaviour
{
	public UT_FollowBase follow;

	public bool OnLateUpdate;

	public bool followCamera;

	private void Update()
	{
		Transform target = ENT_Player.playerObject.transform;
		if (followCamera)
		{
			target = ENT_Player.GetPlayer().cam.transform;
		}
		if (!OnLateUpdate)
		{
			follow.MoveToTarget(base.transform, target);
		}
	}

	private void LateUpdate()
	{
		Transform target = ENT_Player.playerObject.transform;
		if (followCamera)
		{
			target = ENT_Player.GetPlayer().cam.transform;
		}
		if (OnLateUpdate)
		{
			follow.MoveToTarget(base.transform, target);
		}
	}
}
