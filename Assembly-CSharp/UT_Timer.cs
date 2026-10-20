using System;
using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class UT_Timer : MonoBehaviourGizmos
{
	[Serializable]
	public class IntermediateEvent
	{
		public float time;

		public UnityEvent timeEvent;

		public bool hasRun;

		public bool isStartingTime;

		public string desc;

		public SpawnTable.SpawnSettings spawnSettings;

		private UT_Timer parentTimer;

		public void SetParentTimer(UT_Timer t)
		{
			parentTimer = t;
		}

		public float GetTime()
		{
			if (!isStartingTime)
			{
				return time;
			}
			return parentTimer.time - time;
		}

		public float GetTimeFromStart()
		{
			if (isStartingTime)
			{
				return time;
			}
			return parentTimer.time - time;
		}

		public bool CanRun()
		{
			if (hasRun)
			{
				return false;
			}
			if (!spawnSettings.RandomCheck())
			{
				return false;
			}
			return true;
		}

		public string GetLabel()
		{
			return desc + " || " + GetTimeFromStart() + " Seconds From Timer Start";
		}
	}

	public string description;

	public float time = 60f;

	public float startDelay;

	private float curTime;

	private bool running;

	public bool runOnAwake;

	public bool repeat;

	public bool unscaledTime;

	public UnityEvent endEvent;

	public UnityEvent<float> percentRemainingEvent;

	public List<IntermediateEvent> otherEvents = new List<IntermediateEvent>();

	private void Start()
	{
		curTime = time + startDelay;
		SetupEvents();
	}

	private void Awake()
	{
		if (runOnAwake)
		{
			running = true;
		}
	}

	private void OnValidate()
	{
		SetupEvents();
	}

	private void SetupEvents()
	{
		foreach (IntermediateEvent otherEvent in otherEvents)
		{
			otherEvent.SetParentTimer(this);
		}
	}

	private void Update()
	{
		if ((CL_GameManager.gMan.isPaused && !unscaledTime) || !running)
		{
			return;
		}
		if (unscaledTime)
		{
			curTime -= Time.unscaledDeltaTime;
		}
		else
		{
			curTime -= Time.deltaTime;
		}
		percentRemainingEvent.Invoke(curTime / time);
		foreach (IntermediateEvent otherEvent in otherEvents)
		{
			if (curTime <= otherEvent.GetTime() && !otherEvent.hasRun)
			{
				if (otherEvent.CanRun())
				{
					otherEvent.timeEvent.Invoke();
				}
				otherEvent.hasRun = true;
			}
		}
		if (curTime <= 0f)
		{
			running = false;
			endEvent.Invoke();
			if (repeat)
			{
				Play(reset: true);
			}
		}
	}

	public void Play(bool reset = false)
	{
		running = true;
		if (reset)
		{
			Reset();
		}
	}

	public void Pause()
	{
		running = false;
	}

	public void Reset()
	{
		curTime = time;
		foreach (IntermediateEvent otherEvent in otherEvents)
		{
			otherEvent.hasRun = false;
		}
	}

	public void Stop()
	{
		running = false;
		Reset();
	}

	public void AddTime(float t)
	{
		curTime += t;
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		List<DarkMachineFunctions.RenderUnityEventDesc> list = new List<DarkMachineFunctions.RenderUnityEventDesc>
		{
			new DarkMachineFunctions.RenderUnityEventDesc
			{
				ev = endEvent,
				prependString = "On End: ",
				color = Color.green
			}
		};
		foreach (IntermediateEvent otherEvent in otherEvents)
		{
			list.Add(new DarkMachineFunctions.RenderUnityEventDesc
			{
				ev = otherEvent.timeEvent,
				prependString = "At Time: " + otherEvent.time,
				color = Color.yellow
			});
		}
		DarkMachineFunctions.RenderUnityEvent(ref Draw.editor, base.transform, list);
	}
}
