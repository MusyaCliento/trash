using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UT_RoachBankReader : MonoBehaviour
{
	[Serializable]
	public class CheckEvent
	{
		public enum CheckType
		{
			greater = 0,
			lesser = 1,
			equal = 2
		}

		public string name;

		public CheckType type;

		public int checkAmount;

		public UnityEvent succeedEvent;

		private bool hasRun;

		public void Check()
		{
			if (!hasRun)
			{
				bool flag = false;
				if (type == CheckType.greater && CL_GameManager.GetRoaches() > checkAmount)
				{
					flag = true;
				}
				else if (type == CheckType.equal && CL_GameManager.GetRoaches() == checkAmount)
				{
					flag = true;
				}
				else if (type == CheckType.equal && CL_GameManager.GetRoaches() < checkAmount)
				{
					flag = true;
				}
				if (flag)
				{
					succeedEvent.Invoke();
					hasRun = true;
				}
			}
		}

		public void Reset()
		{
			hasRun = false;
		}
	}

	public List<CheckEvent> checkEvents;

	private int lastRoachAmount;

	public bool resetOnChange;

	private void Update()
	{
		if (lastRoachAmount != CL_GameManager.GetRoaches())
		{
			lastRoachAmount = CL_GameManager.GetRoaches();
			if (resetOnChange)
			{
				Reset();
			}
			Check();
		}
	}

	public void Check()
	{
		foreach (CheckEvent checkEvent in checkEvents)
		{
			checkEvent.Check();
		}
	}

	public void Reset()
	{
		foreach (CheckEvent checkEvent in checkEvents)
		{
			checkEvent.Reset();
		}
	}
}
