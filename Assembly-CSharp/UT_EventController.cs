using System;
using System.Collections;
using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class UT_EventController : MonoBehaviourGizmos
{
	[Serializable]
	public class EventContainer
	{
		public string name;

		public Color color = Color.white;

		public UnityEvent playEvents;

		public int maxPlays;

		private int currentPlays;

		public bool useSpawnSettings;

		public SpawnTable.SpawnSettings spawnSettings;

		public string falseEventName;

		public float delay;

		public bool Play()
		{
			if (useSpawnSettings && !spawnSettings.RandomCheck())
			{
				return false;
			}
			if (maxPlays != 0)
			{
				if (currentPlays >= maxPlays)
				{
					return false;
				}
				currentPlays++;
			}
			if (delay > 0f)
			{
				CL_GameManager.gMan.StartCoroutine(DelayedActivate());
			}
			else
			{
				Activate();
			}
			return true;
			IEnumerator DelayedActivate()
			{
				yield return new WaitForSeconds(delay);
				Activate();
			}
		}

		private void Activate()
		{
			playEvents.Invoke();
		}

		public void ResetPlays()
		{
			currentPlays = 0;
		}
	}

	public List<EventContainer> events = new List<EventContainer>();

	private Dictionary<string, EventContainer> eventDictionary;

	private void Awake()
	{
		eventDictionary = new Dictionary<string, EventContainer>();
		foreach (EventContainer @event in events)
		{
			eventDictionary.Add(@event.name, @event);
		}
	}

	public void PlayEvent(string eventName)
	{
		if (eventDictionary != null && eventDictionary.ContainsKey(eventName) && !eventDictionary[eventName].Play())
		{
			string falseEventName = eventDictionary[eventName].falseEventName;
			if (falseEventName != "")
			{
				eventDictionary[falseEventName].Play();
			}
		}
	}

	public void PlayAllEvents()
	{
		foreach (EventContainer @event in events)
		{
			@event.Play();
		}
	}

	public void ResetEventCounter(string eventName)
	{
		if (eventDictionary.ContainsKey(eventName))
		{
			eventDictionary[eventName].ResetPlays();
		}
	}

	public void ResetAllEventCounters()
	{
		foreach (EventContainer @event in events)
		{
			@event.ResetPlays();
		}
	}

	public override void DrawGizmos()
	{
		List<DarkMachineFunctions.RenderUnityEventDesc> list = new List<DarkMachineFunctions.RenderUnityEventDesc>();
		foreach (EventContainer @event in events)
		{
			list.Add(new DarkMachineFunctions.RenderUnityEventDesc
			{
				ev = @event.playEvents,
				prependString = @event.name + ": ",
				color = @event.color
			});
		}
	}
}
