using System.Collections.Generic;
using UnityEngine;

public class ENV_CavityFakeoutController : MonoBehaviour
{
	public Transform cavityFakeoutFollowGeo;

	private Vector3 cavityFakeoutFollowLocalStartPosition;

	public float fakeoutFollowDistance = 10f;

	private bool hasStartedFakeout;

	public List<Transform> fakeoutRemovalObjects;

	private void Start()
	{
		cavityFakeoutFollowLocalStartPosition = cavityFakeoutFollowGeo.transform.localPosition;
	}

	private void Update()
	{
		bool flag = ENT_Player.GetPlayer().camRoot.CanSeeTarget(cavityFakeoutFollowGeo, 140f);
		float num = ENT_Player.GetPlayer().transform.position.y - cavityFakeoutFollowGeo.transform.position.y;
		if (!hasStartedFakeout)
		{
			if (num > 40f)
			{
				hasStartedFakeout = true;
			}
			return;
		}
		if (!flag && num > fakeoutFollowDistance)
		{
			Vector3 position = cavityFakeoutFollowGeo.transform.parent.TransformPoint(cavityFakeoutFollowLocalStartPosition);
			position.y = ENT_Player.GetPlayer().transform.position.y - fakeoutFollowDistance;
			cavityFakeoutFollowGeo.transform.position = position;
		}
		else if (num > 35f)
		{
			Vector3 position2 = cavityFakeoutFollowGeo.transform.parent.TransformPoint(cavityFakeoutFollowLocalStartPosition);
			position2.y = ENT_Player.GetPlayer().transform.position.y - 35f;
			cavityFakeoutFollowGeo.transform.position = position2;
		}
		foreach (Transform fakeoutRemovalObject in fakeoutRemovalObjects)
		{
			if (fakeoutRemovalObject.gameObject.activeSelf)
			{
				float num2 = ENT_Player.GetPlayer().transform.position.y - fakeoutRemovalObject.position.y;
				if (num2 > 20f)
				{
					fakeoutRemovalObject.gameObject.SetActive(value: false);
				}
				else if (num2 > 3f && !ENT_Player.GetPlayer().camRoot.CanSeeTarget(fakeoutRemovalObject, 120f))
				{
					fakeoutRemovalObject.gameObject.SetActive(value: false);
				}
			}
		}
	}
}
