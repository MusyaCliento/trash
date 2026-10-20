using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UT_Counter : MonoBehaviour
{
	[Serializable]
	public class CounterEvent
	{
		public string name;

		public int activateCount = 1;

		public UnityEvent countEvent;

		public bool hasRun;

		public float delay;
	}

	public int maxCount = 5;

	public int count;

	public UnityEvent addCountEvent;

	public List<CounterEvent> counterEvents;

	public virtual void AddCount(int i)
	{
		count = Mathf.Min(count + i, maxCount);
		addCountEvent.Invoke();
		foreach (CounterEvent counterEvent in counterEvents)
		{
			CounterEvent cE = counterEvent;
			if (!cE.hasRun && cE.activateCount <= count)
			{
				if (cE.delay > 0f)
				{
					StartCoroutine(DelayedEvent());
					continue;
				}
				cE.countEvent.Invoke();
				cE.hasRun = true;
			}
			IEnumerator DelayedEvent()
			{
				yield return new WaitForSeconds(cE.delay);
				cE.countEvent.Invoke();
				cE.hasRun = true;
			}
		}
	}

	public virtual void Reset()
	{
		foreach (CounterEvent counterEvent in counterEvents)
		{
			counterEvent.hasRun = false;
		}
		count = 0;
	}
}
