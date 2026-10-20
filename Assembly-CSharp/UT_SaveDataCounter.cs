using UnityEngine;
using UnityEngine.Events;

public class UT_SaveDataCounter : MonoBehaviour
{
	public string saveFlagName;

	public bool unityEventOnReachAmount;

	public int targetCounterAmount = 1;

	public UnityEvent succeedCounterEvent;

	public UnityEvent failedCounterEvent;

	public void LogData()
	{
		StatManager.sessionStats.UpdateStatistic("counter-" + saveFlagName + "-amount", 1, StatManager.Statistic.DataType.Int, StatManager.Statistic.ModType.Add);
		int totalStatisticInt = StatManager.GetTotalStatisticInt("counter-" + saveFlagName + "-amount");
		Debug.Log("Counting: " + totalStatisticInt);
		if (unityEventOnReachAmount)
		{
			if (totalStatisticInt >= targetCounterAmount)
			{
				succeedCounterEvent.Invoke();
			}
			else
			{
				failedCounterEvent.Invoke();
			}
		}
	}

	public void ResetCounterData()
	{
		StatManager.sessionStats.UpdateStatistic("counter-" + saveFlagName + "-amount", 0, StatManager.Statistic.DataType.Int, StatManager.Statistic.ModType.Set, StatManager.Statistic.DisplayType.Default, StatManager.Statistic.ModType.Add);
	}
}
