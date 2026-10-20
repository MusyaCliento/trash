using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SessionEventModule_LocatorSpawner : SessionEventModule
{
	public string locatorID;

	public List<GameObject> spawnList;

	public int spawnMin;

	public int spawnMax;

	public Vector3 checkPlayerPositionOffset;

	public int locatorAmount = 1;

	public float minimumDistanceToPlayer = 5f;

	public bool invokeLocators;

	public override void Initialize(SessionEvent s)
	{
		base.Initialize(s);
		Activate();
	}

	public override void Activate()
	{
		Spawn();
		base.Activate();
	}

	public override void SendMessage(string m)
	{
		base.SendMessage(m);
		if (m == "spawn")
		{
			Spawn();
		}
	}

	public void Spawn()
	{
		Vector3 pos = ENT_Player.playerObject.transform.position + checkPlayerPositionOffset;
		UT_Locator.LocatorGroup locatorGroup = UT_Locator.GetLocatorGroup(locatorID);
		if (locatorGroup == null)
		{
			return;
		}
		List<UT_Locator> closestLocators = locatorGroup.GetClosestLocators(pos, locatorAmount, onlyActive: false);
		if (closestLocators == null || closestLocators.Count == 0)
		{
			return;
		}
		foreach (UT_Locator item in closestLocators)
		{
			if (!(Vector3.Distance(item.transform.position, ENT_Player.playerObject.transform.position) < minimumDistanceToPlayer))
			{
				int num = Mathf.FloorToInt(UnityEngine.Random.Range(spawnMin, spawnMax));
				for (int i = 0; i < num; i++)
				{
					UnityEngine.Object.Instantiate(spawnList[UnityEngine.Random.Range(0, spawnList.Count)], item.transform.position, item.transform.rotation, item.transform);
				}
				if (invokeLocators)
				{
					item.RunEvent();
				}
			}
		}
	}
}
