using UnityEngine;

public class UT_LocationDataCollector : MonoBehaviour
{
	public string locationName;

	public bool unlockAchievement;

	public int unlockVisitAmount = 1;

	public string unlockName;

	public void LogData()
	{
		StatManager.sessionStats.UpdateStatistic("ldc-" + locationName + "-besttimetoreach", CL_GameManager.gMan.GetGameTime(), StatManager.Statistic.DataType.Float, StatManager.Statistic.ModType.Min, StatManager.Statistic.DisplayType.Time, StatManager.Statistic.ModType.Min);
		StatManager.sessionStats.UpdateStatistic("ldc-" + locationName + "-totaltimesreached", 1, StatManager.Statistic.DataType.Int, StatManager.Statistic.ModType.Add);
		CL_GameManager.SetGameFlag("hasvisited-" + locationName, state: true, "", save: true);
		int totalStatisticInt = StatManager.GetTotalStatisticInt("ldc-" + locationName + "-totaltimesreached");
		Debug.Log("Reach Amount: " + totalStatisticInt);
		Debug.Log("Reached " + locationName + " At " + CL_GameManager.gMan.GetGameTime());
		if (unlockAchievement && totalStatisticInt >= unlockVisitAmount)
		{
			CL_AchievementManager.SetAchievementValue(unlockName, b: true);
		}
	}
}
