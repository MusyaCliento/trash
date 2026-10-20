using System;
using UnityEngine;

[Serializable]
public class SessionEventModule_LocatorSetActive : SessionEventModule
{
	public string locatorID;

	public bool targetState;

	public override void Initialize(SessionEvent s)
	{
		base.Initialize(s);
		Activate();
	}

	public override void Activate()
	{
		SetState(targetState);
		base.Activate();
	}

	public override void SendMessage(string m)
	{
		base.SendMessage(m);
		if (m == "activate")
		{
			SetState(b: true);
		}
		else if (m == "deactivate")
		{
			SetState(b: false);
		}
	}

	public void SetState(bool b)
	{
		UT_Locator.LocatorGroup locatorGroup = UT_Locator.GetLocatorGroup(locatorID);
		Debug.Log("Getting Locator Group: " + locatorID + " : " + locatorGroup);
		if (locatorGroup == null)
		{
			return;
		}
		foreach (UT_Locator allLocator in locatorGroup.GetAllLocators())
		{
			Debug.Log("Setting Active: " + allLocator.gameObject.name + " : " + b);
			allLocator.gameObject.SetActive(b);
		}
	}
}
