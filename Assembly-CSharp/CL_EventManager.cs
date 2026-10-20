using System.Collections.Generic;
using UnityEngine;

public class CL_EventManager : MonoBehaviour
{
	private static List<SessionEvent> currentEvents = new List<SessionEvent>();

	private static Dictionary<string, SessionEvent> currentEventDict = new Dictionary<string, SessionEvent>();

	private static Dictionary<string, SessionEvent> previousEventDict = new Dictionary<string, SessionEvent>();

	public static M_Level currentLevel;

	public static M_Region currentRegion;

	public static M_Subregion currentSubregion;

	private float checkTime;

	private void Start()
	{
		currentEvents = new List<SessionEvent>();
		currentEventDict = new Dictionary<string, SessionEvent>();
		previousEventDict = new Dictionary<string, SessionEvent>();
		currentRegion = null;
		currentLevel = null;
		currentSubregion = null;
	}

	private void Update()
	{
		checkTime -= Time.deltaTime;
		if (checkTime <= 0f)
		{
			checkTime = 1f;
			CheckEventList(GetPossibleEvents(enteredLevel: false, enteredRegion: false, enteredSubregion: false, update: true));
		}
		for (int i = 0; i < currentEvents.Count; i++)
		{
			currentEvents[i].UpdateEvent();
		}
	}

	private void LateUpdate()
	{
		for (int i = 0; i < currentEvents.Count; i++)
		{
			currentEvents[i].LateUpdateEvent();
		}
	}

	public static void EnterLevel(M_Level level)
	{
		currentLevel = level;
		bool enteredRegion = currentRegion != level.region;
		bool enteredSubregion = currentSubregion != level.subRegion;
		currentRegion = level.region;
		currentSubregion = level.subRegion;
		CheckEventList(GetPossibleEvents(enteredLevel: true, enteredRegion, enteredSubregion));
	}

	public static void RemoveEvent(string id)
	{
		if (currentEventDict.ContainsKey(id))
		{
			currentEventDict[id].EndEvent();
			currentEvents.Remove(currentEventDict[id]);
			currentEventDict.Remove(id);
		}
	}

	public static List<SessionEvent> CheckEventList(List<SessionEvent> eventList)
	{
		if (eventList == null)
		{
			return null;
		}
		List<SessionEvent> list = new List<SessionEvent>();
		foreach (SessionEvent @event in eventList)
		{
			if (@event.spawnSettings.RandomCheck() && !currentEventDict.ContainsKey(@event.id) && (!@event.playOnce || !previousEventDict.ContainsKey(@event.id)))
			{
				list.Add(@event);
			}
		}
		foreach (SessionEvent item in list)
		{
			if (!currentEventDict.ContainsKey(item.id))
			{
				SessionEvent sessionEvent = Object.Instantiate(item);
				currentEvents.Add(sessionEvent);
				currentEventDict.Add(item.id, sessionEvent);
				sessionEvent.StartEvent(currentLevel, currentSubregion, currentRegion);
				if (!previousEventDict.ContainsKey(item.id))
				{
					previousEventDict.Add(item.id, sessionEvent);
				}
			}
		}
		return list;
	}

	public static List<SessionEvent> GetPossibleEvents(bool enteredLevel = false, bool enteredRegion = false, bool enteredSubregion = false, bool update = false)
	{
		if (CL_GameManager.GetBaseGamemode().IsCompetitive())
		{
			return null;
		}
		if (currentLevel != null && !currentLevel.allowEvents)
		{
			return null;
		}
		List<SessionEvent> list = new List<SessionEvent>();
		if (currentRegion != null)
		{
			foreach (SessionEventList sessionEventList in currentRegion.sessionEventLists)
			{
				foreach (SessionEvent @event in sessionEventList.events)
				{
					list.Add(@event);
				}
			}
		}
		if (currentSubregion != null)
		{
			foreach (SessionEventList sessionEventList2 in currentSubregion.sessionEventLists)
			{
				foreach (SessionEvent event2 in sessionEventList2.events)
				{
					list.Add(event2);
				}
			}
		}
		if (currentSubregion != null)
		{
			foreach (SessionEventList sessionEventList3 in currentSubregion.sessionEventLists)
			{
				foreach (SessionEvent event3 in sessionEventList3.events)
				{
					list.Add(event3);
				}
			}
		}
		List<SessionEvent> list2 = new List<SessionEvent>();
		foreach (SessionEvent item in list)
		{
			if (!(item == null) && (item.startCheck != SessionEvent.EventStart.startOfRegion || enteredRegion) && (item.startCheck != SessionEvent.EventStart.startOfSubregion || enteredSubregion) && (item.startCheck != SessionEvent.EventStart.startOfLevel || enteredLevel) && (item.startCheck != SessionEvent.EventStart.checkEverySecond || update))
			{
				list2.Add(item);
			}
		}
		return list2;
	}

	public static void StopAllEvents()
	{
		for (int num = currentEvents.Count - 1; num >= 0; num--)
		{
			currentEvents[num].StopEvent();
		}
		currentEvents.Clear();
		currentEventDict.Clear();
		previousEventDict.Clear();
	}

	public static void StartEvent(SessionEvent sessionEvent)
	{
		SessionEvent sessionEvent2 = Object.Instantiate(sessionEvent);
		currentEvents.Add(sessionEvent2);
		currentEventDict.Add(sessionEvent.id, sessionEvent2);
		sessionEvent2.StartEvent(currentLevel, currentSubregion, currentRegion);
		if (!previousEventDict.ContainsKey(sessionEvent.id))
		{
			previousEventDict.Add(sessionEvent.id, sessionEvent2);
		}
	}

	public void StartEventCommand(string[] args)
	{
		if (args.Length != 0)
		{
			SessionEvent sessionEvent = null;
			foreach (SessionEvent sessionEvent2 in CL_AssetManager.GetFullCombinedAssetDatabase().sessionEvents)
			{
				if (sessionEvent2.name.ToLower().Contains(args[0].ToLower()))
				{
					sessionEvent = sessionEvent2;
					StartEvent(sessionEvent);
					CommandConsole.Log("Starting Event: " + sessionEvent.name);
					return;
				}
			}
			CommandConsole.LogError("Event Not Found.");
		}
		else
		{
			CommandConsole.LogError("Error: Missing Argument. Provide Event Name.");
		}
	}

	public void ListSessionEvents(string[] args)
	{
		foreach (SessionEvent sessionEvent in CL_AssetManager.GetFullCombinedAssetDatabase().sessionEvents)
		{
			if (sessionEvent.showInList)
			{
				CommandConsole.Log(sessionEvent.name + "\n-- Spawn Type: " + sessionEvent.startCheck.ToString() + "\n-- Spawn Chance: " + sessionEvent.spawnSettings.GetEffectiveSpawnChance());
			}
		}
	}
}
