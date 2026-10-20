using System;
using UnityEngine;

[Serializable]
public class SessionEventModule_LocatorRunEvents : SessionEventModule
{
	public string locatorID;

	public override void Initialize(SessionEvent s)
	{
		base.Initialize(s);
		Activate();
	}

	public override void Activate()
	{
		RunEvents();
		base.Activate();
	}

	public override void SendMessage(string m)
	{
		base.SendMessage(m);
	}

	public void RunEvents()
	{
		UT_Locator.LocatorGroup locatorGroup = UT_Locator.GetLocatorGroup(locatorID);
		Debug.Log("Getting Locator Group: " + locatorID + " : " + locatorGroup);
		if (locatorGroup == null)
		{
			return;
		}
		foreach (UT_Locator allLocator in locatorGroup.GetAllLocators())
		{
			allLocator.RunEvent();
		}
	}
}
