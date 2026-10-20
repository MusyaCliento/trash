using System;
using UnityEngine;

public class UT_TrackObject : MonoBehaviour
{
	public enum UpdateType
	{
		everything = 0,
		onDestroy = 1,
		onSpawn = 2,
		position = 3
	}

	public string objectType = "object";

	public bool active = true;

	public UpdateType updateType;

	public float movementRecordDelta = 0.5f;

	private Vector3 lastPosition = Vector3.zero;

	private void Start()
	{
		CL_GameTracker.EventUpdate = (Action)Delegate.Combine(CL_GameTracker.EventUpdate, new Action(SessionUpdate));
		if (active)
		{
			if (updateType == UpdateType.onSpawn)
			{
				CL_GameTracker.AddEventToSession(CL_GameTracker.CreateEvent(base.name, base.gameObject.GetInstanceID().ToString(), objectType, CL_GameTracker.Session.Tick.Event.EventType.spawn, base.transform.position));
			}
			lastPosition = base.transform.position;
		}
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
		if (updateType == UpdateType.onDestroy)
		{
			CL_GameTracker.AddEventToSession(CL_GameTracker.CreateEvent(base.name, base.gameObject.GetInstanceID().ToString(), objectType, CL_GameTracker.Session.Tick.Event.EventType.destroy, base.transform.position));
		}
		CL_GameTracker.EventUpdate = (Action)Delegate.Remove(CL_GameTracker.EventUpdate, new Action(SessionUpdate));
	}

	public virtual void SessionUpdate()
	{
		if ((updateType == UpdateType.everything || updateType == UpdateType.position) && Vector3.Distance(base.transform.position, lastPosition) > movementRecordDelta)
		{
			lastPosition = base.transform.position;
			CL_GameTracker.AddEventToSession(CL_GameTracker.CreateEvent(base.name, base.gameObject.GetInstanceID().ToString(), objectType, CL_GameTracker.Session.Tick.Event.EventType.move, base.transform.position));
		}
	}
}
