using UnityEngine;

public class UT_FollowCam : MonoBehaviour
{
	public UT_FollowBase follow;

	private void OnRenderObject()
	{
		follow.MoveToTarget(base.transform, Camera.current.transform);
	}
}
