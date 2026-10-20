using UnityEngine;

public class UT_AchievementSetter : MonoBehaviour
{
	public void GetAchievement(string name)
	{
		CL_AchievementManager.SetAchievementValue(name, b: true);
	}
}
