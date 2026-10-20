using System;
using UnityEngine;

[Serializable]
public class SessionEventModule_StopEventAfterExit : SessionEventModule
{
	public enum ExitEvent
	{
		afterRegion = 0,
		afterSubregion = 1,
		afterLevel = 2
	}

	public ExitEvent exitEvent;

	public override void Update()
	{
		base.Update();
		switch (exitEvent)
		{
		case ExitEvent.afterRegion:
			if (sessionEvent.startRegion != null && CL_EventManager.currentRegion != null && sessionEvent.startRegion.regionName != CL_EventManager.currentRegion.regionName)
			{
				sessionEvent.StopEvent();
			}
			break;
		case ExitEvent.afterSubregion:
			if (sessionEvent.startSubregion == null)
			{
				if (sessionEvent.startSubregion != CL_EventManager.currentSubregion)
				{
					sessionEvent.StopEvent();
				}
			}
			else if (sessionEvent.startSubregion.subregionName != CL_EventManager.currentSubregion.subregionName)
			{
				sessionEvent.StopEvent();
				Debug.Log($"Ending Event {sessionEvent} - Moved from {sessionEvent.startSubregion.subregionName} to {CL_EventManager.currentSubregion.subregionName}");
			}
			break;
		case ExitEvent.afterLevel:
			if (sessionEvent.startLevel != CL_EventManager.currentLevel)
			{
				sessionEvent.StopEvent();
			}
			break;
		}
	}
}
