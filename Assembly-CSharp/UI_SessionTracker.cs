using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SessionTracker : MonoBehaviour
{
	[Serializable]
	public class EventIcons
	{
		public string name;

		public Sprite icon;

		public Sprite destroyIcon;
	}

	public class SpecialObjectType
	{
		public string objectType;

		public GameObject specialGameObject;
	}

	public class ObjectTracker
	{
		public string name;

		public string id;

		public string objectType;

		public EventIcons curIcon;

		public GameObject trackerGameObject;

		private Vector3 targetPosition;

		private Image spriteRenderer;

		public void Initialize()
		{
			spriteRenderer = trackerGameObject.GetComponent<Image>();
			spriteRenderer.sprite = curIcon.icon;
			if (curIcon.icon == null)
			{
				spriteRenderer.enabled = false;
			}
		}

		public void Update()
		{
			trackerGameObject.transform.localPosition = Vector3.Lerp(trackerGameObject.transform.localPosition, targetPosition, Time.unscaledDeltaTime * 3f);
		}

		public void SetTargetPosition(Vector3 pos)
		{
			targetPosition = pos;
		}

		public void SetIcon(Sprite sprite)
		{
			spriteRenderer.sprite = sprite;
			if (spriteRenderer.sprite == null)
			{
				spriteRenderer.enabled = false;
			}
			else
			{
				spriteRenderer.enabled = true;
			}
		}
	}

	public GameObject trackerObject;

	public Transform startPosition;

	public Transform endPosition;

	public List<EventIcons> eventIcons;

	public Dictionary<string, EventIcons> eventIconDict;

	public List<ObjectTracker> trackedObjects;

	public Dictionary<string, ObjectTracker> trackedObjectsDict;

	private CL_GameTracker.Session loadedSession;

	private float readTime;

	public float playbackSpeed = 1f;

	private Queue<CL_GameTracker.Session.Tick> sessionTickQueue;

	private void Start()
	{
		eventIconDict = new Dictionary<string, EventIcons>();
		foreach (EventIcons eventIcon in eventIcons)
		{
			eventIconDict.Add(eventIcon.name, eventIcon);
		}
		trackedObjectsDict = new Dictionary<string, ObjectTracker>();
		trackedObjects = new List<ObjectTracker>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Quote))
		{
			StartShowcase();
		}
		if (loadedSession != null)
		{
			UpdateShowcase();
		}
	}

	private void UpdateShowcase()
	{
		readTime += Time.unscaledDeltaTime * playbackSpeed;
		if (sessionTickQueue.Count == 0)
		{
			return;
		}
		CL_GameTracker.Session.Tick tick = sessionTickQueue.Peek();
		if (tick.timeStamp < readTime)
		{
			ShowcaseTick(tick);
			sessionTickQueue.Dequeue();
		}
		foreach (ObjectTracker trackedObject in trackedObjects)
		{
			trackedObject.Update();
		}
	}

	private void ShowcaseTick(CL_GameTracker.Session.Tick tick)
	{
		if (tick.events.Count > 0)
		{
			for (int i = 0; i < tick.events.Count; i++)
			{
				ShowcaseEvent(tick.events[i]);
			}
		}
	}

	private void ShowcaseEvent(CL_GameTracker.Session.Tick.Event curEvent)
	{
		string[] array = curEvent.id.Split(":");
		if (curEvent.type == CL_GameTracker.Session.Tick.Event.EventType.spawn)
		{
			ObjectTracker objectTracker = new ObjectTracker();
			objectTracker.id = array[1];
			objectTracker.name = array[0];
			objectTracker.objectType = curEvent.objectType;
			if (eventIconDict.ContainsKey(curEvent.objectType))
			{
				objectTracker.curIcon = eventIconDict[curEvent.objectType];
			}
			else
			{
				objectTracker.curIcon = eventIcons[0];
			}
			Vector3 vector = ConvertPositionVector((Vector3)CL_GameTracker.DecomposeData(curEvent));
			objectTracker.trackerGameObject = UnityEngine.Object.Instantiate(trackerObject, base.transform);
			objectTracker.trackerGameObject.name = objectTracker.objectType + " " + objectTracker.name + " " + objectTracker.id;
			objectTracker.trackerGameObject.transform.localPosition = vector;
			objectTracker.SetTargetPosition(vector);
			objectTracker.Initialize();
			trackedObjectsDict.Add(objectTracker.id, objectTracker);
			trackedObjects.Add(objectTracker);
		}
		else
		{
			ObjectTracker objectTracker2 = trackedObjectsDict[array[1]];
			if (curEvent.type == CL_GameTracker.Session.Tick.Event.EventType.destroy || curEvent.type == CL_GameTracker.Session.Tick.Event.EventType.kill)
			{
				Vector3 targetPosition = ConvertPositionVector((Vector3)CL_GameTracker.DecomposeData(curEvent));
				objectTracker2.SetIcon(objectTracker2.curIcon.destroyIcon);
				objectTracker2.SetTargetPosition(targetPosition);
			}
			else if (curEvent.type == CL_GameTracker.Session.Tick.Event.EventType.move)
			{
				Vector3 targetPosition2 = ConvertPositionVector((Vector3)CL_GameTracker.DecomposeData(curEvent));
				objectTracker2.SetTargetPosition(targetPosition2);
			}
		}
	}

	private Vector3 ConvertPositionVector(Vector3 input)
	{
		float num = Mathf.Abs(startPosition.localPosition.y - endPosition.localPosition.y);
		Vector3 result = input / loadedSession.maxHeight * num + startPosition.localPosition;
		result.x = (result.z + result.x) * 0.7f;
		result.z = 0f;
		return result;
	}

	public void StartShowcase()
	{
		readTime = 0f;
		loadedSession = CL_GameTracker.LoadData();
		sessionTickQueue = new Queue<CL_GameTracker.Session.Tick>(loadedSession.ticks);
	}
}
