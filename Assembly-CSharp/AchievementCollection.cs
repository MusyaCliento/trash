using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AchievementCollection_New", menuName = "White Knuckle/Achievements/Achievement Collection")]
public class AchievementCollection : ScriptableObject
{
	public List<CL_AchievementManager.GameAchievement> achievements;
}
