using System.Collections.Generic;
using UnityEngine;

public class UT_LocatorController : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	public void InvokeLocatorGroup(string locatorID)
	{
		_ = ENT_Player.playerObject.transform.position;
		UT_Locator.LocatorGroup locatorGroup = UT_Locator.GetLocatorGroup(locatorID);
		if (locatorGroup != null)
		{
			InvokeLocators(locatorGroup.GetAllLocators());
		}
	}

	public void RunEventIDOnLocatorGroup(string s)
	{
		_ = ENT_Player.playerObject.transform.position;
		string[] array = s.Split(':');
		if (array.Length > 1)
		{
			UT_Locator.LocatorGroup locatorGroup = UT_Locator.GetLocatorGroup(array[0]);
			if (locatorGroup != null)
			{
				RunEventWithIDOnLocators(locatorGroup.GetAllLocators(), array[1]);
			}
		}
	}

	private static void InvokeLocators(List<UT_Locator> locators)
	{
		if (locators == null || locators.Count == 0)
		{
			return;
		}
		foreach (UT_Locator locator in locators)
		{
			locator.RunEvent();
		}
	}

	private static void RunEventWithIDOnLocators(List<UT_Locator> locators, string eventID)
	{
		if (locators == null || locators.Count == 0)
		{
			return;
		}
		foreach (UT_Locator locator in locators)
		{
			locator.RunEventWithID(eventID);
		}
	}
}
