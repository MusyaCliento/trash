using System.Collections.Generic;
using System.Linq;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class UT_Locator : MonoBehaviourGizmos
{
	public class LocatorGroup
	{
		public string id;

		private List<UT_Locator> locators;

		private HashSet<UT_Locator> locatorHash;

		public void AddLocator(UT_Locator locator)
		{
			if (locatorHash == null)
			{
				locatorHash = new HashSet<UT_Locator>();
				locators = new List<UT_Locator>();
			}
			if (!locatorHash.Contains(locator))
			{
				locators.Add(locator);
				locatorHash.Add(locator);
				locators.RemoveAll((UT_Locator item) => item == null);
			}
		}

		public void RemoveLocator(UT_Locator locator)
		{
			if (locatorHash.Contains(locator))
			{
				locatorHash.Remove(locator);
				locators.Remove(locator);
			}
		}

		public List<UT_Locator> GetClosestLocators(Vector3 pos, int count, bool onlyActive = true)
		{
			if (locators == null || locators.Count == 0 || count <= 0)
			{
				return new List<UT_Locator>();
			}
			return (from l in locators
				where l != null && (!onlyActive || l.gameObject.activeInHierarchy)
				orderby (l.transform.position - pos).sqrMagnitude
				select l).Take(count).ToList();
		}

		public UT_Locator GetLocatorClosestToPosition(Vector3 pos, bool onlyActive = true)
		{
			if (locators == null || locators.Count == 0)
			{
				return null;
			}
			UT_Locator result = null;
			float num = float.MaxValue;
			foreach (UT_Locator locator in locators)
			{
				if (!(locator == null) && (!onlyActive || locator.gameObject.activeInHierarchy))
				{
					float sqrMagnitude = (locator.transform.position - pos).sqrMagnitude;
					if (sqrMagnitude < num)
					{
						num = sqrMagnitude;
						result = locator;
					}
				}
			}
			return result;
		}

		public UT_Locator GetFirstLocator()
		{
			return locators[0];
		}

		public List<UT_Locator> GetAllLocators()
		{
			return locators;
		}
	}

	public string locatorID;

	public bool removeOnDisable;

	[SerializeField]
	private M_Level parentLevel;

	public UnityEvent locatorEvent;

	public List<UT_EventController.EventContainer> events = new List<UT_EventController.EventContainer>();

	private Dictionary<string, UT_EventController.EventContainer> eventDictionary;

	public static Dictionary<string, LocatorGroup> locators;

	private bool initialized;

	private void Awake()
	{
		Initialize();
	}

	public void Initialize()
	{
		if (removeOnDisable || initialized)
		{
			return;
		}
		initialized = true;
		AddToLocators();
		eventDictionary = new Dictionary<string, UT_EventController.EventContainer>();
		foreach (UT_EventController.EventContainer @event in events)
		{
			eventDictionary.Add(@event.name, @event);
		}
	}

	private void OnEnable()
	{
		if (removeOnDisable)
		{
			AddToLocators();
		}
	}

	private void OnDisable()
	{
		if (removeOnDisable)
		{
			RemoveFromLocators();
		}
	}

	private void OnDestroy()
	{
		if (!removeOnDisable)
		{
			RemoveFromLocators();
		}
	}

	private void AddToLocators()
	{
		if (locators == null)
		{
			locators = new Dictionary<string, LocatorGroup>();
		}
		if (locators.ContainsKey(locatorID))
		{
			locators[locatorID].AddLocator(this);
			return;
		}
		LocatorGroup locatorGroup = new LocatorGroup();
		locatorGroup.id = locatorID;
		locatorGroup.AddLocator(this);
		locators.Add(locatorID, locatorGroup);
	}

	private void RemoveFromLocators()
	{
		if (locators != null && locators.ContainsKey(locatorID))
		{
			locators[locatorID].RemoveLocator(this);
		}
	}

	public void RunEvent()
	{
		locatorEvent.Invoke();
	}

	public void RunEventWithID(string eventName)
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

	public static UT_Locator GetLocator(string id)
	{
		return locators[id].GetFirstLocator();
	}

	public static LocatorGroup GetLocatorGroup(string id)
	{
		if (locators.ContainsKey(id))
		{
			return locators[id];
		}
		return null;
	}

	public static Transform GetClosestLocatorInGroupToPosition(string id, Vector3 position)
	{
		if (locators.ContainsKey(id))
		{
			UT_Locator locatorClosestToPosition = locators[id].GetLocatorClosestToPosition(position);
			if (locatorClosestToPosition != null)
			{
				return locatorClosestToPosition.transform;
			}
		}
		return null;
	}

	public static List<UT_Locator> GetClosestLocatorsInGroupToPosition(string id, Vector3 position, int count = 4)
	{
		if (locators.ContainsKey(id))
		{
			return locators[id].GetClosestLocators(position, count);
		}
		return null;
	}

	public static UT_Locator GetClosestLocatorInGroupToPosition(string id, Vector3 position, Vector3 distanceComparePosition, float minimumRange = 0f, float maximumRange = 0f, bool onlyActive = true)
	{
		if (locators.ContainsKey(id))
		{
			List<UT_Locator> closestLocators = locators[id].GetClosestLocators(position, 5, onlyActive);
			if (closestLocators == null)
			{
				return null;
			}
			foreach (UT_Locator item in closestLocators)
			{
				float num = Vector3.Distance(item.transform.position, distanceComparePosition);
				if (num > minimumRange && (!(maximumRange > 0f) || num < maximumRange))
				{
					return item;
				}
			}
		}
		return null;
	}

	public static List<UT_Locator> GetClosestLocatorsWithinRange(string id, Vector3 position, Vector3 distanceComparePosition, float minimumRange = 0f, float maximumRange = 0f, bool onlyActive = true, int count = 10)
	{
		List<UT_Locator> list = new List<UT_Locator>();
		if (locators == null)
		{
			return null;
		}
		if (locators.ContainsKey(id))
		{
			List<UT_Locator> closestLocators = locators[id].GetClosestLocators(position, count, onlyActive);
			if (closestLocators == null)
			{
				return null;
			}
			foreach (UT_Locator item in closestLocators)
			{
				float num = Vector3.Distance(item.transform.position, distanceComparePosition);
				if (num > minimumRange && (!(maximumRange > 0f) || num < maximumRange))
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	public static UT_Locator GetClosestLocatorInGroupToPosition(string id, Vector3 position, float minimumRange = 0f, float maximumRange = 0f, bool onlyActive = true)
	{
		return GetClosestLocatorInGroupToPosition(id, position, position, minimumRange, maximumRange, onlyActive);
	}

	public override void DrawGizmos()
	{
		if (GizmoContext.InSelection(this))
		{
			Draw.Label2D(base.transform.position + Vector3.up, base.name + " : " + locatorID, 12f, LabelAlignment.Center);
		}
	}

	private void OnDrawGizmos()
	{
		if (locatorID == "creature-fly-spawn")
		{
			Gizmos.DrawIcon(base.transform.position, "gizmo-mosquito", allowScaling: true, Color.yellow);
		}
		else if (locatorID == "creature-spawn")
		{
			Gizmos.DrawIcon(base.transform.position, "gizmo-bug", allowScaling: true, Color.yellow);
		}
		else if (locatorID == "object-spawn")
		{
			Gizmos.DrawIcon(base.transform.position, "gizmo-radio", allowScaling: true, Color.yellow);
		}
		else
		{
			Gizmos.DrawIcon(base.transform.position, "gizmo-crosshair", allowScaling: true, Color.yellow);
		}
	}

	public void SetParentLevel(M_Level p)
	{
		parentLevel = p;
	}

	public M_Level GetParentLevel()
	{
		return parentLevel;
	}

	public static List<string> GetListOfAllLocatorGroupNames()
	{
		List<string> list = new List<string>();
		Debug.Log(locators.Count);
		foreach (KeyValuePair<string, LocatorGroup> locator in locators)
		{
			list.Add(locator.Value.id);
			Debug.Log("LISTING LOCATOR: " + locator.Key);
		}
		return list;
	}
}
