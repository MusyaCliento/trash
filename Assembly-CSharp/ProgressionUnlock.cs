using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unlock", menuName = "White Knuckle/Progression/Unlock")]
public class ProgressionUnlock : ScriptableObject
{
	public enum RequirementType
	{
		experience = 0,
		achievement = 1,
		stat = 2,
		flag = 3,
		gamemodeCompletion = 4,
		facilityUpgrade = 5,
		completeFacility = 6
	}

	[Serializable]
	public class UnlockRequirement
	{
		public RequirementType requirement;

		public int unlockExperience;

		public string unlockAchievement;

		public string unlockFlag;

		public string statName;

		public Facility facility;

		public FacilityUpgrade upgrade;

		public bool upgradeOldStat;

		public string upgradeOldStatID;

		public M_Gamemode completionCheckGamemode;

		public int statRequirement;
	}

	public string id;

	public bool requireAllRequirements;

	public List<UnlockRequirement> unlockRequirements;

	public bool state;

	[Header("Unlock Details")]
	public Sprite unlockIcon;

	public string unlockTitle;

	[TextArea]
	public string unlockDescription;

	[TextArea]
	public string unlockLogDescription;

	public string unlockHint;

	public Color glowColor = Color.clear;

	public bool showProgression;

	public string progressionString = "used";

	public bool showProgressionPopup = true;

	private float lastProgress;

	public AudioClip unlockClip;

	public bool CheckUnlock()
	{
		if (SettingsManager.settings.unlockAll || (CL_GameManager.IsInGame() && CL_GameManager.GetCurrentGamemode().IsCompetitive()))
		{
			state = true;
			return true;
		}
		bool result = true;
		bool flag = true;
		foreach (UnlockRequirement unlockRequirement in unlockRequirements)
		{
			if (unlockRequirement.requirement == RequirementType.experience)
			{
				flag = CL_ProgressionManager.playerExperience >= unlockRequirement.unlockExperience;
			}
			else if (unlockRequirement.requirement == RequirementType.achievement)
			{
				flag = CL_AchievementManager.GetAchievementValue(unlockRequirement.unlockAchievement);
			}
			else if (unlockRequirement.requirement == RequirementType.stat)
			{
				flag = StatManager.GetTotalStatisticFloat(unlockRequirement.statName) >= (float)unlockRequirement.statRequirement;
			}
			else if (unlockRequirement.requirement == RequirementType.flag)
			{
				flag = StatManager.saveData.GetFlagState(unlockRequirement.unlockFlag);
			}
			else if (unlockRequirement.requirement == RequirementType.gamemodeCompletion)
			{
				flag = unlockRequirement.completionCheckGamemode.HasBeatGamemode();
			}
			else if (unlockRequirement.requirement == RequirementType.facilityUpgrade)
			{
				flag = unlockRequirement.upgrade.IsOwned(unlockRequirement.facility.id);
			}
			else if (unlockRequirement.requirement == RequirementType.completeFacility)
			{
				flag = unlockRequirement.facility.IsComplete();
			}
			if (flag && !requireAllRequirements)
			{
				state = true;
				if (CL_GameManager.gMan != null)
				{
					CL_GameManager.SetGameFlag("unlock_" + base.name, state);
				}
				return true;
			}
			if (!flag && requireAllRequirements)
			{
				state = false;
				if (CL_GameManager.gMan != null)
				{
					CL_GameManager.SetGameFlag("unlock_" + base.name, state);
				}
				return false;
			}
			if (!flag)
			{
				result = false;
			}
		}
		state = result;
		if (CL_GameManager.gMan != null)
		{
			CL_GameManager.SetGameFlag("unlock_" + base.name, result);
		}
		return result;
	}

	public void TryUpgrade()
	{
		UnlockRequirement unlockRequirement = unlockRequirements[0];
		if (unlockRequirement.upgradeOldStat && !StatManager.HasGlobalStat(unlockRequirement.statName))
		{
			if (StatManager.GetTotalStatisticInt(unlockRequirement.upgradeOldStatID) > 0)
			{
				Debug.Log("Upgrading an old stat!");
				StatManager.saveData.gameStats.UpdateStatistic(unlockRequirement.statName, StatManager.GetTotalStatisticInt(unlockRequirement.upgradeOldStatID), StatManager.Statistic.DataType.Int, StatManager.Statistic.ModType.Set, StatManager.Statistic.DisplayType.Default, StatManager.Statistic.ModType.Add);
			}
			else
			{
				StatManager.saveData.gameStats.UpdateStatistic(unlockRequirement.statName, 0, StatManager.Statistic.DataType.Int, StatManager.Statistic.ModType.Set, StatManager.Statistic.DisplayType.Default, StatManager.Statistic.ModType.Add);
			}
		}
	}

	public float GetLastProgress()
	{
		return lastProgress;
	}

	public float GetProgress()
	{
		UnlockRequirement unlockRequirement = unlockRequirements[0];
		if (unlockRequirement.requirement == RequirementType.stat)
		{
			lastProgress = StatManager.GetTotalStatisticFloat(unlockRequirement.statName) / (float)unlockRequirement.statRequirement;
			return lastProgress;
		}
		if (unlockRequirement.requirement == RequirementType.experience)
		{
			lastProgress = CL_ProgressionManager.playerExperience / unlockRequirement.statRequirement;
			return lastProgress;
		}
		return 1f;
	}

	public string GetProgressString()
	{
		UnlockRequirement unlockRequirement = unlockRequirements[0];
		if (unlockRequirement.requirement == RequirementType.stat)
		{
			return $"{Math.Round(StatManager.GetTotalStatisticFloat(unlockRequirement.statName), 2)}/{unlockRequirement.statRequirement}";
		}
		if (unlockRequirement.requirement == RequirementType.experience)
		{
			return $"{CL_ProgressionManager.playerExperience}/{unlockRequirement.unlockExperience}";
		}
		return "N/A";
	}
}
