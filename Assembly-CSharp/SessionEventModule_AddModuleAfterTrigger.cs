using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SessionEventModule_AddModuleAfterTrigger : SessionEventModule
{
	public enum TriggerEvent
	{
		afterRegion = 0,
		afterSubregion = 1,
		afterLevel = 2
	}

	public TriggerEvent triggerEvent;

	[SerializeReference]
	public List<SessionEventModule> modules;

	private bool hasTriggered;

	public override void Initialize(SessionEvent s)
	{
		hasTriggered = false;
		base.Initialize(s);
	}

	public override void Update()
	{
		base.Update();
		if (hasTriggered)
		{
			return;
		}
		switch (triggerEvent)
		{
		case TriggerEvent.afterRegion:
			if (sessionEvent.startRegion != CL_EventManager.currentRegion)
			{
				AddModules();
			}
			break;
		case TriggerEvent.afterSubregion:
			if (CL_EventManager.currentSubregion == null)
			{
				break;
			}
			if (sessionEvent.startSubregion == null)
			{
				if (sessionEvent.startSubregion != CL_EventManager.currentSubregion)
				{
					AddModules();
				}
			}
			else if (sessionEvent.startSubregion.subregionName != CL_EventManager.currentSubregion.subregionName)
			{
				AddModules();
			}
			break;
		case TriggerEvent.afterLevel:
			if (sessionEvent.startLevel != CL_EventManager.currentLevel)
			{
				AddModules();
			}
			break;
		}
	}

	private void AddModules()
	{
		hasTriggered = true;
		foreach (SessionEventModule module in modules)
		{
			sessionEvent.AddModule(module);
		}
	}
}
