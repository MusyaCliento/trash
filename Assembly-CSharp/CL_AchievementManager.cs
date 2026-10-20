using System;
using System.Collections;
using System.Collections.Generic;
using Steamworks;
using Steamworks.Data;
using UnityEngine;

public class CL_AchievementManager : MonoBehaviour
{
	[Serializable]
	public class GameAchievement
	{
		public string id;

		public string name;

		public bool flagged;

		public bool announce = true;

		public string announceText;

		public int xp = 10;

		[Header("Steam Achievements")]
		public string steamAchievementID;

		public bool steamHasAchieved;

		public List<string> modeTagWhitelist;

		public List<string> modeTagBlacklist;

		public void SetState(bool b, bool skipSteam = false)
		{
			if (SettingsManager.settings.unlockAll)
			{
				return;
			}
			if (!flagged && b)
			{
				if (!skipSteam)
				{
					GetSteamAchievement();
				}
				if (announce)
				{
					ShowAchievement("<size=30>" + name + "</size>\n<color=grey>" + announceText);
				}
				flagged = b;
				CL_ProgressionManager.AddExperience(xp);
				CL_ProgressionManager.UpdateUnlocks(showPopups: true);
			}
			Debug.Log("Getting Achievement " + name);
			flagged = b;
		}

		public void GetSteamAchievement()
		{
			if (steamAchievementID != "" && !CommandConsole.hasCheated)
			{
				SteamManager.GiveSteamAchievement(steamAchievementID);
			}
		}

		internal bool CheckTags(M_Gamemode mode)
		{
			if (modeTagWhitelist != null && modeTagWhitelist.Count > 0)
			{
				if (mode == null)
				{
					return false;
				}
				if (!mode.HasAnyTag(modeTagWhitelist))
				{
					return false;
				}
			}
			if (modeTagBlacklist != null && modeTagBlacklist.Count > 0)
			{
				if (mode == null)
				{
					return true;
				}
				if (mode.HasAnyTag(modeTagBlacklist))
				{
					return false;
				}
			}
			return true;
		}
	}

	internal List<GameAchievement> achievements;

	public List<AchievementCollection> achievementCollections;

	private Dictionary<string, GameAchievement> achievementDictionary;

	public static CL_AchievementManager instance;

	public static UI_AchievementText textInstance;

	private float slowUpdateTime;

	private static Dictionary<string, Achievement> steamAchievements;

	private void Awake()
	{
		instance = this;
		achievements = new List<GameAchievement>();
		foreach (AchievementCollection achievementCollection2 in achievementCollections)
		{
			AchievementCollection achievementCollection = UnityEngine.Object.Instantiate(achievementCollection2);
			achievements.AddRange(achievementCollection.achievements);
		}
		LoadAchievements(StatManager.saveData.flags);
		StartCoroutine(WaitForSteamManagerToLoad());
	}

	private void OnDestroy()
	{
		SaveAchievements();
	}

	private void Update()
	{
		if (slowUpdateTime < 0f && CL_GameManager.AreAchievementsAllowed())
		{
			CheckAchievement();
			slowUpdateTime = 1f;
		}
		slowUpdateTime -= Time.unscaledDeltaTime;
	}

	private void CheckAchievement()
	{
		if (SettingsManager.settings.unlockAll)
		{
			foreach (GameAchievement achievement in achievements)
			{
				achievement.SetState(b: true, skipSteam: true);
			}
			return;
		}
		_ = StatManager.saveData;
		if (!CL_GameManager.gMan || CL_GameManager.isDead())
		{
			return;
		}
		if (StatManager.GetStatisticInt(StatManager.sessionStats, "pitons-used") + StatManager.GetStatisticInt(StatManager.saveData.gameStats, "pitons-used") >= 100)
		{
			SetAchievementValue("ACH_PITONIST", b: true);
		}
		if (StatManager.GetStatisticInt(StatManager.sessionStats, "navitems-used") + StatManager.GetStatisticInt(StatManager.saveData.gameStats, "navitems-used") >= 100)
		{
			SetAchievementValue("ACH_PATHFINDER", b: true);
		}
		if (StatManager.GetStatisticInt(StatManager.sessionStats, "grubs-used") + StatManager.GetStatisticInt(StatManager.saveData.gameStats, "grubs-used") >= 50)
		{
			SetAchievementValue("ACH_50GRUBSKILLED", b: true);
		}
		if (StatManager.GetStatisticInt(StatManager.sessionStats, "roach-killed") + StatManager.GetStatisticInt(StatManager.saveData.gameStats, "roach-killed") >= 100)
		{
			SetAchievementValue("ACH_ROACHSMASH", b: true);
		}
		if (StatManager.GetTotalStatisticInt("grubs-used") > 0)
		{
			SetAchievementValue("ACH_CRIMINAL", b: true);
		}
		if (CL_GameManager.GetCurrentGamemode() != null && !CL_GameManager.GetCurrentGamemode().HasTag("blockroachachievements") && !CL_GameManager.GetBaseGamemode().HasActiveSetting("unlimited"))
		{
			if (CL_GameManager.GetCombinedRoaches() >= 50)
			{
				SetAchievementValue("ACH_50ROACHES", b: true);
			}
			if (CL_GameManager.GetCombinedRoaches() >= 100)
			{
				SetAchievementValue("ACH_100ROACHES", b: true);
			}
			if (CL_GameManager.GetCombinedRoaches() >= 500)
			{
				SetAchievementValue("ACH_500ROACHES", b: true);
			}
		}
		if (StatManager.GetStatisticInt(StatManager.sessionStats, "rebar-used") + StatManager.GetStatisticInt(StatManager.saveData.gameStats, "rebar-used") >= 100)
		{
			SetAchievementValue("ACH_RODGOD", b: true);
		}
		if (StatManager.GetTotalStatisticInt("flaregun-jump") >= 1)
		{
			SetAchievementValue("ACH_FLAREJUMP", b: true);
		}
		if (ENT_Player.GetPlayer() != null)
		{
			bool flag = true;
			if (!ENT_Player.GetPlayer().HasPerk("Perk_Injury_ShatteredArm_Left"))
			{
				flag = false;
			}
			if (!ENT_Player.GetPlayer().HasPerk("Perk_Injury_ShatteredArm_Right"))
			{
				flag = false;
			}
			if (!ENT_Player.GetPlayer().HasPerk("Perk_Injury_FracturedLeg"))
			{
				flag = false;
			}
			if (flag)
			{
				SetAchievementValue("ACH_BROKENEVERYTHING", b: true);
			}
		}
	}

	public static void SaveAchievements()
	{
		if (instance == null)
		{
			return;
		}
		foreach (GameAchievement achievement in instance.achievements)
		{
			StatManager.saveData.SaveFlag(achievement.id, achievement.flagged);
		}
	}

	public static void LoadAchievements(List<StatManager.SaveData.SaveFlags> flags)
	{
		if (instance == null)
		{
			return;
		}
		if (instance.achievementDictionary == null)
		{
			instance.achievementDictionary = new Dictionary<string, GameAchievement>();
			foreach (GameAchievement achievement in instance.achievements)
			{
				if (!instance.achievementDictionary.ContainsKey(achievement.id))
				{
					instance.achievementDictionary.Add(achievement.id, achievement);
				}
				steamAchievements = new Dictionary<string, Achievement>();
				if (SteamUserStats.StatsRecieved)
				{
					foreach (Achievement achievement2 in SteamUserStats.Achievements)
					{
						steamAchievements.Add(achievement2.Name, achievement2);
					}
				}
				if (achievement.steamAchievementID != "" && steamAchievements.ContainsKey(achievement.steamAchievementID))
				{
					achievement.steamHasAchieved = steamAchievements[achievement.steamAchievementID].State;
				}
			}
		}
		if (flags == null)
		{
			return;
		}
		foreach (StatManager.SaveData.SaveFlags flag in flags)
		{
			if (instance.achievementDictionary.ContainsKey(flag.name))
			{
				instance.achievementDictionary[flag.name].flagged = flag.value;
			}
		}
	}

	public static bool GetAchievementValue(string name)
	{
		if (instance == null)
		{
			Debug.LogError("ERROR: No achievement manager instance found, returning achievement " + name + " as FALSE.");
			return false;
		}
		if (SettingsManager.settings == null)
		{
			Debug.LogError("ERROR: No settings found, returning achievement " + name + " as FALSE.");
			return false;
		}
		if (SettingsManager.settings.unlockAll)
		{
			return true;
		}
		if (CL_GameManager.gamemode != null && CL_GameManager.IsInGame() && CL_GameManager.GetCurrentGamemode().IsCompetitive())
		{
			return true;
		}
		if (!instance.achievementDictionary.ContainsKey(name))
		{
			CommandConsole.LogError("Tried finding achievement: " + name + ". Achievement not found.");
			return false;
		}
		return instance.achievementDictionary[name].flagged;
	}

	public static void SetAchievementValue(string name, bool b)
	{
		if (instance == null)
		{
			Debug.Log($"Could not set achievement {name} to {b}, achievement manager not found!");
		}
		else if (CL_GameManager.gamemode != null && !CL_GameManager.AreAchievementsAllowed())
		{
			Debug.Log($"Could not set achievement {name} to {b}, achievements are not allowed in this gamemode!");
		}
		else
		{
			if (!instance.achievementDictionary.ContainsKey(name))
			{
				return;
			}
			if (!instance.achievementDictionary[name].CheckTags(CL_GameManager.GetBaseGamemode()) && instance.achievementDictionary[name].CheckTags(CL_GameManager.GetCurrentGamemode()))
			{
				Debug.Log($"Could not set achievement {name} to {b}, tags disallow it!");
				return;
			}
			if (instance.achievementDictionary[name].flagged != b && !SettingsManager.settings.unlockAll)
			{
				Debug.Log("Setting " + name + " from  " + instance.achievementDictionary[name].flagged + " to " + b);
			}
			if (instance.achievementDictionary[name].flagged == b)
			{
				if (b)
				{
					instance.achievementDictionary[name].GetSteamAchievement();
				}
			}
			else
			{
				instance.achievementDictionary[name].SetState(b);
			}
		}
	}

	public IEnumerator WaitForSteamManagerToLoad()
	{
		while (!SteamManager.initialized)
		{
			Debug.Log("Steam not connected, retrying.");
			yield return new WaitForSecondsRealtime(5f);
		}
		steamAchievements = new Dictionary<string, Achievement>();
		if (SteamUserStats.Achievements != null)
		{
			foreach (Achievement achievement2 in SteamUserStats.Achievements)
			{
				steamAchievements.Add(achievement2.Identifier, achievement2);
			}
		}
		else
		{
			Debug.Log("Could not load steam stats.");
		}
		foreach (GameAchievement achievement3 in instance.achievements)
		{
			if (achievement3.steamAchievementID != "" && steamAchievements.ContainsKey(achievement3.steamAchievementID))
			{
				achievement3.steamHasAchieved = steamAchievements[achievement3.steamAchievementID].State;
			}
		}
		foreach (GameAchievement achievement in instance.achievements)
		{
			if (achievement.steamAchievementID != "" && steamAchievements.ContainsKey(achievement.steamAchievementID) && !achievement.steamHasAchieved && achievement.flagged)
			{
				yield return null;
				Debug.Log("Getting achievement not set on steam: " + achievement.id);
				achievement.GetSteamAchievement();
			}
		}
	}

	public static void ShowAchievement(string announceText)
	{
		if (!(instance == null) && !(textInstance == null))
		{
			textInstance.ShowText(announceText);
		}
	}

	public static void ResetAchievements()
	{
		foreach (GameAchievement achievement in instance.achievements)
		{
			achievement.flagged = false;
		}
		SaveAchievements();
	}

	public void ResetSteamAchievements()
	{
		SteamUserStats.ResetAll(includeAchievements: true);
	}

	public static int GetCalculatedXP()
	{
		int num = 0;
		foreach (GameAchievement achievement in instance.achievements)
		{
			if (achievement.flagged)
			{
				num += achievement.xp;
			}
		}
		return num;
	}
}
