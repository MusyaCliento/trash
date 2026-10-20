using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "White Knuckle/Events/Base Event")]
public class SessionEvent : ScriptableObject
{
	public enum EventStart
	{
		startOfRegion = 0,
		startOfSubregion = 1,
		startOfLevel = 2,
		checkEverySecond = 3
	}

	public string id;

	public EventStart startCheck;

	public SpawnTable.SpawnSettings spawnSettings;

	[SerializeReference]
	public List<SessionEventModule> modules;

	internal M_Level startLevel;

	internal M_Subregion startSubregion;

	internal M_Region startRegion;

	public bool showInList = true;

	public bool playOnce;

	public virtual void StartEvent(M_Level curLevel = null, M_Subregion curSubregion = null, M_Region curRegion = null)
	{
		startLevel = curLevel;
		startSubregion = curSubregion;
		startRegion = curRegion;
		foreach (SessionEventModule module in modules)
		{
			module.Initialize(this);
			module.OnModuleStart();
		}
	}

	public virtual void EndEvent()
	{
	}

	public virtual void StopEvent()
	{
		foreach (SessionEventModule module in modules)
		{
			module.OnModuleDestroy();
		}
		CL_EventManager.RemoveEvent(id);
	}

	public virtual void UpdateEvent()
	{
		for (int i = 0; i < modules.Count; i++)
		{
			modules[i].Update();
		}
	}

	public virtual void LateUpdateEvent()
	{
		for (int i = 0; i < modules.Count; i++)
		{
			modules[i].LateUpdate();
		}
	}

	public virtual void AddModule(SessionEventModule m)
	{
		m.Initialize(this);
		m.OnModuleStart();
		modules.Add(m);
	}

	public virtual void EnterRegion(M_Region r)
	{
	}

	public virtual void LeaveRegion(M_Region r)
	{
	}

	public virtual void EnterSubregion(M_Subregion sR)
	{
	}

	public virtual void LeaveSubregion(M_Subregion sR)
	{
	}

	public virtual void EnterLevel(M_Level l)
	{
	}

	public virtual void LeaveLevel(M_Level l)
	{
	}

	public virtual void SendMessageToModule(string moduleID, string message)
	{
		for (int i = 0; i < modules.Count; i++)
		{
			if (modules[i].name == moduleID)
			{
				modules[i].SendMessage(message);
			}
		}
	}
}
