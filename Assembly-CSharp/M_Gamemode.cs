using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sirenix.Utilities;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gamemode", menuName = "White Knuckle/Gamemode")]
public class M_Gamemode : ScriptableObject, WorldGenerator
{
	[Serializable]
	public class SpawnItem
	{
		public string itemid;

		public Vector2 position;
	}

	public enum GameType
	{
		standard = 0,
		playlist = 1,
		shuffledPlaylist = 2,
		endlessPlaylist = 3,
		single = 4
	}

	public enum TimeScoreMeasure
	{
		centiseconds = 0,
		seconds = 1
	}

	[Flags]
	public enum LeaderboardCategories
	{
		score = 1,
		time = 2,
		distance = 4,
		climb = 8
	}

	public string gamemodeName;

	public bool useCustomCapsuleName;

	public string capsuleName;

	[SerializeReference]
	public GamemodeModule gamemodeModule;

	public GameType modeType;

	public string introText;

	[TextArea(8, 10)]
	public string modeDescription;

	public bool useGamemodeSettings;

	public string newGameText = "Play";

	[Header("Mode Customization")]
	public List<GameObject> gamemodeObjects;

	public List<SpawnItem> startItems;

	public bool timeGoal;

	public bool allowAchievements = true;

	public bool allowHeightAchievements = true;

	private List<GameObject> spawnedObjects;

	public string gamemodeScene = "Game-Main";

	[Space(5f)]
	public bool isEndless;

	public bool hasRevives = true;

	public bool hasPerks = true;

	public bool baseGamemode = true;

	[Space(5f)]
	public bool allowCheats = true;

	public bool allowCheatedScores;

	[Header("Roach & Bank Settings")]
	public string roachBankID = "standard-bank";

	public bool showBankAmount = true;

	public bool saveRoaches = true;

	public bool forceStartingRoaches;

	public int startingRoaches;

	public int competitiveStartingRoaches = 50;

	public float creditConversionRate = 1f;

	public int winCredits;

	public int winCreditMaximum = 1000;

	[Header("Gamemode Flags")]
	public List<string> modeTags;

	public TrinketList availableTrinkets;

	public List<M_Level> playlistLevels;

	public List<M_Level.LevelAssetHolder> playlistLevelAssets;

	public List<M_Region> regions;

	public int levelsToGenerate = 4;

	public List<GamemodeSetting> gamemodeSettings;

	public bool allowHardmode = true;

	public bool allowIronKnuckle = true;

	public bool allowCompetitive;

	public float gooSpeedMult = 1f;

	public float gooSpeedIncreaseMult = 1f;

	public Sprite capsuleArt;

	public Sprite screenArt;

	public Color gamemodeColor;

	public UI_GamemodeScreen_Panel gamemodePanel;

	public Sprite roachEndSprite;

	public AudioClip startSound;

	public float startSoundVolume = 0.4f;

	public string unlockAchievement;

	public string unlockHint;

	public bool hiddenUntilUnlocked;

	public bool devOnly;

	public UI_ScoreScreen winScreen;

	public UI_ScoreScreen loseScreen;

	public bool allowLeaderboardScoring = true;

	public string steamLeaderboardName;

	public bool useGlobalSteamLeaderboardVersion = true;

	public bool scoreLeaderboardTime = true;

	public LeaderboardCategories leaderboardCategories;

	public TimeScoreMeasure timeMeasure = TimeScoreMeasure.seconds;

	public bool scoreLeaderboardScore = true;

	public bool scoreLeaderboardHard = true;

	public bool scoreLeaderboardIronKnuckle = true;

	public List<CL_GameManager.RichPresencePair> richPresenceDefaultValues = new List<CL_GameManager.RichPresencePair>();

	private bool hasSavedPlayerInfo;

	private float savedPlayerAscent;

	private float savedPlayerTravelDistance;

	private static bool isHighScore;

	public void Initialize(string[] args)
	{
		hasSavedPlayerInfo = false;
		savedPlayerAscent = 0f;
		GameObject gameObject = new GameObject(gamemodeName + "-root");
		if (ENT_Player.GetPlayer() == null)
		{
			return;
		}
		foreach (GameObject gamemodeObject in gamemodeObjects)
		{
			UnityEngine.Object.Instantiate(gamemodeObject, gameObject.transform);
		}
		if (playlistLevelAssets == null)
		{
			playlistLevelAssets = new List<M_Level.LevelAssetHolder>();
		}
		if (args.Length != 0)
		{
			playlistLevelAssets = new List<M_Level.LevelAssetHolder>();
		}
		for (int i = 0; i < args.Length; i++)
		{
			string text = args[i];
			M_Level.LevelAssetHolder levelAsset = CL_AssetManager.GetLevelAsset(text);
			if (levelAsset != null)
			{
				CommandConsole.Log("Loaded Level Into List: " + levelAsset);
				playlistLevelAssets.Add(levelAsset);
				if (i == args.Length - 1)
				{
					playlistLevelAssets.Add(CL_AssetManager.GetLevelAsset("MX_Level_Null"));
				}
			}
			else
			{
				CommandConsole.Log("Error: Level does not exist - " + text);
			}
		}
		if (gamemodeModule == null)
		{
			GamemodeModule_Standard gamemodeModule_Standard = new GamemodeModule_Standard();
			gamemodeModule_Standard.winScoreMultiplier = 5f;
			gamemodeModule = gamemodeModule_Standard;
		}
		gamemodeModule.Initialize(this);
		if (forceStartingRoaches)
		{
			CL_GameManager.SetRoaches(startingRoaches);
		}
		if (IsCompetitive())
		{
			CL_GameManager.SetRoaches(competitiveStartingRoaches);
		}
	}

	public virtual void StartFreshGamemode()
	{
		List<string> gamemodeTrinkets = StatManager.saveData.GetGamemodeTrinkets(GetGamemodeName());
		List<Trinket> list = new List<Trinket>();
		foreach (string item in gamemodeTrinkets)
		{
			Trinket trinketAsset = CL_AssetManager.GetTrinketAsset(item);
			if (trinketAsset != null)
			{
				list.Add(trinketAsset);
			}
		}
		Trinket[] array = list.OrderBy((Trinket t) => t.activateOrder).ToArray();
		for (int num = 0; num < array.Length; num++)
		{
			array[num].Activate();
		}
		Trinket.ScoreCalc scoreCalc = Trinket.CalculateScoreFromTrinkets(list);
		if (scoreCalc.bindingValue != 0f)
		{
			CL_ScoreManager.sessionScore.AddScore("bindings", "Bindings", 0f, scoreCalc.bindingValue);
		}
		if (scoreCalc.trinketValue != 0f)
		{
			CL_ScoreManager.sessionScore.AddScore("trinkets", "Trinkets", 0f, scoreCalc.trinketValue);
		}
		isHighScore = false;
		ENT_Player player = ENT_Player.GetPlayer();
		if (!(player != null))
		{
			return;
		}
		List<Item> list2 = new List<Item>();
		foreach (SpawnItem startItem in startItems)
		{
			GameObject assetGameObject = CL_AssetManager.GetAssetGameObject(startItem.itemid);
			GameEntity gameEntity = null;
			if (assetGameObject != null)
			{
				gameEntity = assetGameObject.GetComponent<GameEntity>();
			}
			bool flag = true;
			if (gameEntity != null)
			{
				foreach (CL_GameManager.ReplaceInfo replacementScope in CL_GameManager.gMan.replacementScopes)
				{
					if (replacementScope.ShouldReplace(gameEntity, useRandom: false))
					{
						flag = false;
					}
				}
			}
			if (flag)
			{
				Item clone = assetGameObject.GetComponent<Item_Object>().itemData.GetClone();
				clone.GetDropObject();
				clone.bagPosition = new Vector3(startItem.position.x, startItem.position.y, 1f).normalized;
				clone.bagRotation = Quaternion.LookRotation(-player.transform.forward + Vector3.up * 0.5f) * Quaternion.LookRotation(clone.upDirection);
				list2.Add(clone);
			}
		}
		if (list2.Count > 0)
		{
			ENT_Player.GetInventory().LoadItemsIntoBag(list2);
		}
		ENT_Player.GetInventory().RescanInventory();
	}

	public void Remove()
	{
	}

	public void Reset()
	{
	}

	public string GetLeaderboardSettingAffix()
	{
		string text = "";
		List<GamemodeSetting> activeSettings = GetActiveSettings();
		if (activeSettings.Count > 0)
		{
			foreach (GamemodeSetting gamemodeSetting in gamemodeSettings)
			{
				for (int i = 0; i < activeSettings.Count; i++)
				{
					if (gamemodeSetting.id == activeSettings[i].id)
					{
						text = text + "-" + activeSettings[i].leaderboardAppendID;
					}
				}
			}
		}
		return text;
	}

	public virtual void Finish(float time, bool hasFinished = false)
	{
		isHighScore = false;
		if (GetGamemodeSaveData() != null && GetGamemodeSaveData().stats.HasStatistic("score"))
		{
			float statisticFloat = StatManager.GetStatisticFloat(GetGamemodeSaveData().stats, "score");
			if (GetPlayerScore() > statisticFloat)
			{
				isHighScore = true;
			}
		}
		if (saveRoaches && hasFinished)
		{
			int num = 0;
			foreach (Item item in Inventory.instance.GetItemsByTag("roach"))
			{
				if (item.data != null && item.data.Count > 0 && int.TryParse(item.data[0], out var result))
				{
					num += result;
				}
			}
			if (num > 0)
			{
				CL_ProgressionManager.ShowUnlockProgress(roachEndSprite, "ROACHES BANKED", $"Banked {num} from your inventory.");
				CL_GameManager.AddRoaches(num);
			}
		}
		if ((!allowCheatedScores && CommandConsole.hasCheated) || (!allowCheatedScores && !CL_GameManager.AreAchievementsAllowed()) || WorldLoader.customSeed || !CL_GameManager.gMan.allowScores || !allowLeaderboardScoring || CL_Leaderboard.WK_Leaderboard_Core.disableLeaderboards)
		{
			return;
		}
		if (hasFinished && winCredits > 0 && CL_GameManager.GetRoaches(global: true) < winCreditMaximum && !IsCompetitive())
		{
			CL_ProgressionManager.ShowUnlockPopup(roachEndSprite, "WIN BONUS", $"{winCredits} Facility Credits Added", DarkMachineCrayons.gold * 0.5f, null, addToSession: false);
			CL_GameManager.AddRoaches(winCredits, global: true);
		}
		float playerScore = GetPlayerScore(hasFinished);
		Debug.Log(GetPlayerScore(hasFinished));
		CL_Leaderboard.WK_Leaderboard_UserData value = CL_Leaderboard.CreateUserDataFromCurrentSession();
		_ = CL_Leaderboard.leaderboardApi;
		string text = (useGlobalSteamLeaderboardVersion ? "ea-v08-" : "") + CL_GameManager.gamemode.steamLeaderboardName;
		bool flag = scoreLeaderboardIronKnuckle && IsIronKnuckle();
		bool flag2 = scoreLeaderboardHard && CL_GameManager.IsHardmode();
		int flags = DarkMachineFunctions.PackBools(new bool[4]
		{
			flag,
			flag2,
			CL_GameManager.GetBaseGamemode().IsCompetitive(),
			false
		});
		string text2 = "";
		List<GamemodeSetting> activeSettings = GetActiveSettings();
		bool flag3 = true;
		if (activeSettings.Count > 0)
		{
			foreach (GamemodeSetting gamemodeSetting in gamemodeSettings)
			{
				for (int i = 0; i < activeSettings.Count; i++)
				{
					if (gamemodeSetting.id == activeSettings[i].id)
					{
						text2 = text2 + "-" + activeSettings[i].leaderboardAppendID;
						if (!activeSettings[i].allowDownstream)
						{
							flag3 = false;
						}
					}
				}
			}
		}
		Debug.Log("Submitting to leaderboard: " + text + text2);
		string[] leaderboardCategoryNames = Enum.GetNames(typeof(LeaderboardCategories));
		int?[] scores = new int?[leaderboardCategoryNames.Length];
		for (int j = 0; j < scores.Length; j++)
		{
			int? num2 = null;
			switch ((LeaderboardCategories)((uint)(1 << j) & (uint)leaderboardCategories))
			{
			case LeaderboardCategories.score:
				num2 = (int)playerScore;
				break;
			case LeaderboardCategories.time:
			{
				float num3 = time;
				if (timeMeasure == TimeScoreMeasure.centiseconds)
				{
					num3 *= 100f;
				}
				if (hasFinished)
				{
					num2 = (int)num3;
				}
				break;
			}
			case LeaderboardCategories.distance:
				num2 = Mathf.CeilToInt(CL_GameManager.gMan.GetPlayerBestTravelDistance());
				break;
			case LeaderboardCategories.climb:
				num2 = Mathf.CeilToInt(CL_GameManager.gMan.GetPlayerBestTravelDistance() * CL_GameManager.gMan.GetPlayerTravelSpeed());
				break;
			}
			scores[j] = num2;
		}
		HashSet<(string name, int score)> submittingToLeaderboards = new HashSet<(string, int)>();
		if (IsCompetitive() || !flag3)
		{
			AddToLeaderboard(text + text2);
		}
		else if (flag3)
		{
			string text3 = "";
			AddToLeaderboard(text + text3);
			if (flag2)
			{
				text3 += "-hard";
				AddToLeaderboard(text + text3);
			}
			if (flag)
			{
				text3 += "-ik";
				AddToLeaderboard(text + "-ik");
				AddToLeaderboard(text + text3);
			}
		}
		List<(string ident, byte[] data)> details = new List<(string, byte[])>();
		string s = JsonConvert.SerializeObject(value);
		byte[] bytes = Encoding.UTF8.GetBytes(s);
		details.Add(("UserData_1", bytes));
		LeaderboardApi leaderboardApi = CL_Leaderboard.leaderboardApi;
		List<LeaderboardSubmission> submissions = new List<LeaderboardSubmission>();
		foreach (var (leaderboardId, score) in submittingToLeaderboards)
		{
			submissions.Add(new LeaderboardSubmission
			{
				flags = flags,
				leaderboardId = leaderboardId,
				score = score
			});
		}
		try
		{
			SubmitToLeaderboards();
		}
		catch (Exception ex)
		{
			Debug.LogError("Got Exception " + ex.Message + " at " + ex.StackTrace + " while submitting to leaderboards!");
		}
		void AddToLeaderboard(string name)
		{
			for (int k = 0; k < leaderboardCategoryNames.Length; k++)
			{
				if (scores[k].HasValue)
				{
					submittingToLeaderboards.Add((name + "-" + leaderboardCategoryNames[k], scores[k].Value));
				}
			}
		}
		async Task SubmitToLeaderboards()
		{
			LeaderboardUser userCurrent = leaderboardApi.UserCurrent;
			var (flag4, task) = await leaderboardApi.PlaceScore(userCurrent, submissions, details, CancellationToken.None);
			if (flag4)
			{
				try
				{
					Leaderboard_Panel._RefreshLeaderboards?.Invoke();
				}
				catch (Exception ex2)
				{
					Debug.LogWarning("Got exception " + ex2.Message + " at " + ex2.StackTrace + " while refreshing leaderboards!");
				}
			}
			if (task != null)
			{
				await task;
			}
		}
	}

	internal void SavePlayerTempInfo(float playerAscent, float playerTravelDistance)
	{
		savedPlayerAscent = playerAscent;
		savedPlayerTravelDistance = playerTravelDistance;
		hasSavedPlayerInfo = true;
	}

	internal bool HasSavedPlayerInfo()
	{
		return hasSavedPlayerInfo;
	}

	internal float GetSavedPlayerAscent()
	{
		return savedPlayerAscent;
	}

	internal float GetSavedPlayerTravelDistance()
	{
		return savedPlayerTravelDistance;
	}

	public string GetRoachBankID()
	{
		return roachBankID;
	}

	public float GetPlayerScore(bool hasFinished = false)
	{
		return gamemodeModule.GetScore(hasFinished);
	}

	public float GetBaseScore()
	{
		return gamemodeModule.GetBaseScore();
	}

	public bool HasBeatGamemode()
	{
		int num = 0;
		if (GetGamemodeSaveData() == null)
		{
			if (!IsCurrentGamemode())
			{
				return false;
			}
		}
		else
		{
			num = StatManager.GetStatisticInt(GetGamemodeSaveData().stats, "wins");
		}
		if (IsCurrentGamemode() && StatManager.sessionStats != null)
		{
			num = Mathf.Max(num, StatManager.GetStatisticInt(StatManager.sessionStats, "wins"));
		}
		if (num > 0)
		{
			return true;
		}
		return false;
	}

	public bool IsCurrentBaseGamemode()
	{
		if (CL_GameManager.GetBaseGamemode() == this)
		{
			return true;
		}
		return false;
	}

	public bool IsCurrentGamemode()
	{
		if (CL_GameManager.GetCurrentGamemode() == this)
		{
			return true;
		}
		return false;
	}

	public List<M_Level.LevelAssetHolder> GetGenerationList(M_Region lastRegion = null, M_Region regionToGenerate = null, M_Subregion startAfterSubregion = null)
	{
		List<M_Level.LevelAssetHolder> levelGenerationList = new List<M_Level.LevelAssetHolder>();
		if (modeType == GameType.single)
		{
			levelGenerationList = new List<M_Level.LevelAssetHolder>();
			levelGenerationList.Add(playlistLevelAssets[0]);
			FinalizeLevelList(ref levelGenerationList);
			return levelGenerationList;
		}
		if (modeType == GameType.playlist)
		{
			levelGenerationList.AddRange(playlistLevelAssets);
			FinalizeLevelList(ref levelGenerationList);
			return levelGenerationList;
		}
		if (regionToGenerate != null)
		{
			List<M_Level.LevelAssetHolder> regionLevels = GetRegionLevels(regionToGenerate, lastRegion, startAfterSubregion);
			levelGenerationList.AddRange(regionLevels);
			lastRegion = regionToGenerate;
			if (levelGenerationList.Count > levelsToGenerate)
			{
				levelGenerationList.SetLength(levelsToGenerate);
				FinalizeLevelList(ref levelGenerationList);
				return levelGenerationList;
			}
		}
		List<M_Region> list = new List<M_Region>();
		if (lastRegion == null || regions.Count == 1 || lastRegion == regions[regions.Count - 1])
		{
			list.AddRange(regions);
		}
		else
		{
			bool flag = false;
			for (int i = 0; i < regions.Count; i++)
			{
				if (flag)
				{
					list.Add(regions[i]);
				}
				else if (!flag && regions[i] == lastRegion)
				{
					flag = true;
				}
				if (i == regions.Count - 1)
				{
					list.AddRange(regions);
				}
			}
		}
		while (levelGenerationList.Count < levelsToGenerate)
		{
			for (int j = 0; j < list.Count; j++)
			{
				M_Region m_Region = list[j];
				if (list.Count <= 1 || !(m_Region == lastRegion))
				{
					List<M_Level.LevelAssetHolder> regionLevels2 = GetRegionLevels(m_Region, lastRegion, startAfterSubregion);
					levelGenerationList.AddRange(regionLevels2);
					lastRegion = m_Region;
					if (levelGenerationList.Count > levelsToGenerate)
					{
						FinalizeLevelList(ref levelGenerationList);
						return levelGenerationList;
					}
					if (j == list.Count - 1)
					{
						list = regions;
					}
				}
			}
		}
		FinalizeLevelList(ref levelGenerationList);
		return levelGenerationList;
	}

	private void FinalizeLevelList(ref List<M_Level.LevelAssetHolder> levelGenerationList)
	{
		if (modeType == GameType.single)
		{
			levelGenerationList[levelGenerationList.Count - 1].isPausingGeneration = true;
		}
		else if (!levelGenerationList[levelGenerationList.Count - 1].pauseGeneration)
		{
			levelGenerationList[levelGenerationList.Count - 1].isPausingGeneration = false;
		}
	}

	private List<M_Level.LevelAssetHolder> GetRegionLevels(M_Region region, M_Region lastRegion = null, M_Subregion lastSubregion = null)
	{
		List<M_Level.LevelAssetHolder> levels = region.GetLevels(lastRegion, lastSubregion);
		foreach (M_Level.LevelAssetHolder item in levels)
		{
			if (item != null)
			{
				item.region = region;
			}
		}
		for (int num = levels.Count - 1; num >= 0; num--)
		{
			if (levels[num] == null)
			{
				levels.RemoveAt(num);
			}
		}
		return levels;
	}

	public string GetGamemodeName(bool includeOptions = true)
	{
		string text = gamemodeName;
		if (includeOptions)
		{
			foreach (GamemodeSetting gamemodeSetting in gamemodeSettings)
			{
				if (gamemodeSetting.nameAppend != "" && HasActiveSetting(gamemodeSetting.id))
				{
					text = text + "-" + gamemodeSetting.nameAppend;
				}
			}
		}
		return text;
	}

	public bool HasWonGamemode()
	{
		if (GetGamemodeSaveData() == null)
		{
			return false;
		}
		return Mathf.Max(StatManager.GetStatisticInt(GetGamemodeSaveData().stats, "wins"), StatManager.GetStatisticInt(StatManager.sessionStats, "wins")) > 0;
	}

	public StatManager.SaveData.GameModeData GetGamemodeSaveData()
	{
		return StatManager.saveData.GetGameMode(GetGamemodeName());
	}

	public bool HasTag(string s)
	{
		return modeTags.Contains(s);
	}

	public bool HasAnyTag(List<string> strings)
	{
		foreach (string @string in strings)
		{
			if (HasTag(@string))
			{
				return true;
			}
		}
		return false;
	}

	public bool IsCompetitive()
	{
		if (allowCompetitive && StatManager.saveData != null)
		{
			return StatManager.saveData.IsSettingActive(gamemodeName, "competitive");
		}
		return false;
	}

	public bool IsIronKnuckle()
	{
		if (allowIronKnuckle && StatManager.saveData != null)
		{
			return StatManager.saveData.IsSettingActive(gamemodeName, "ironknuckle");
		}
		return false;
	}

	public bool IsHardMode()
	{
		if (allowHardmode && StatManager.saveData != null)
		{
			return StatManager.saveData.IsSettingActive(gamemodeName, "hardmode");
		}
		return false;
	}

	public bool HasActiveSetting(string id)
	{
		return StatManager.saveData.IsSettingActive(gamemodeName, id);
	}

	public List<GamemodeSetting> GetActiveSettings()
	{
		List<GamemodeSetting> list = new List<GamemodeSetting>();
		if (StatManager.saveData.GetGameMode(gamemodeName) == null)
		{
			return list;
		}
		if (StatManager.saveData.GetGameMode(gamemodeName).activeSettings != null)
		{
			foreach (string activeSetting in StatManager.saveData.GetGameMode(gamemodeName).activeSettings)
			{
				foreach (GamemodeSetting gamemodeSetting in gamemodeSettings)
				{
					if (gamemodeSetting.id == activeSetting)
					{
						list.Add(gamemodeSetting);
					}
				}
			}
		}
		return list;
	}

	public static bool IsCurrentlyAHighScore()
	{
		return isHighScore;
	}
}
