using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;

public class StatManager : MonoBehaviour
{
	[Serializable]
	public class Statistic
	{
		public enum DataType
		{
			Int = 0,
			String = 1,
			Float = 2
		}

		public enum ModType
		{
			Set = 0,
			Add = 1,
			Max = 2,
			Min = 3,
			None = 4
		}

		public enum DisplayType
		{
			Default = 0,
			Meters = 1,
			Speed = 2,
			Rounded = 3,
			Time = 4
		}

		public string id;

		public string value;

		public DataType type;

		public ModType defaultModType = ModType.Add;

		public DisplayType displayType;

		public object GetValue()
		{
			switch (type)
			{
			case DataType.Int:
			{
				if (value == "NaN" || value == "")
				{
					value = "0";
				}
				int result2 = 0;
				if (int.TryParse(value, out result2))
				{
					return result2;
				}
				return 0;
			}
			case DataType.String:
				return value;
			case DataType.Float:
			{
				float result = 0f;
				if (value == "NaN" || value == "")
				{
					value = "0";
				}
				if (value.Contains(","))
				{
					value = value.Replace(',', '.');
				}
				if (float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
				{
					return result;
				}
				return 0f;
			}
			default:
			{
				float result = 0f;
				if (value == "NaN" || value == "")
				{
					value = "0";
				}
				if (value.Contains(","))
				{
					value = value.Replace(',', '.');
				}
				if (float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
				{
					return result;
				}
				return 0f;
			}
			}
		}

		public void SetValue(object newValue)
		{
			if (value == "NaN")
			{
				value = "";
			}
			switch (type)
			{
			case DataType.Int:
				value = ((int)newValue).ToString();
				break;
			case DataType.String:
				value = (string)newValue;
				break;
			case DataType.Float:
				value = ((float)newValue).ToString(CultureInfo.InvariantCulture);
				break;
			}
		}

		public void AddValue(object newValue)
		{
			if (value == "NaN")
			{
				value = "";
			}
			switch (type)
			{
			case DataType.Int:
				value = ((int)GetValue() + (int)newValue).ToString();
				break;
			case DataType.String:
				value += (string)newValue;
				break;
			case DataType.Float:
				value = ((float)GetValue() + (float)newValue).ToString(CultureInfo.InvariantCulture);
				break;
			}
		}

		public string GetString()
		{
			string text = "";
			try
			{
				switch (displayType)
				{
				case DisplayType.Meters:
					text = Math.Round((float)GetValue(), 2).ToString(CultureInfo.InvariantCulture) + " Meters";
					break;
				case DisplayType.Rounded:
					text = Math.Round((float)GetValue()).ToString(CultureInfo.InvariantCulture);
					break;
				case DisplayType.Speed:
					text = Math.Round((float)GetValue(), 2).ToString(CultureInfo.InvariantCulture) + " m/s";
					break;
				case DisplayType.Time:
				{
					TimeSpan timeSpan = TimeSpan.FromSeconds((float)GetValue());
					text = ((!(timeSpan.TotalHours < 1.0)) ? ((!(timeSpan.TotalDays < 1.0)) ? string.Format($"D:{timeSpan.Days} H:{timeSpan.Hours} M:{timeSpan.Minutes} S:{timeSpan.Seconds}.{timeSpan.Milliseconds}") : string.Format($"H:{timeSpan.Hours} M:{timeSpan.Minutes} S:{timeSpan.Seconds}.{timeSpan.Milliseconds}")) : timeSpan.ToString("mm\\:ss\\:ff"));
					break;
				}
				default:
					text = value;
					break;
				}
				return text;
			}
			catch (Exception message)
			{
				Debug.LogError("STATMANAGER: Error getting stat: " + id + " | Value: " + value);
				Debug.LogError(message);
				return "";
			}
		}
	}

	[Serializable]
	public class GameStats
	{
		public List<Statistic> statistics = new List<Statistic>();

		[NonSerialized]
		public Dictionary<string, Statistic> statsDictionary = new Dictionary<string, Statistic>();

		public int xp;

		public void InitializeDictionary()
		{
			statsDictionary = new Dictionary<string, Statistic>();
			foreach (Statistic statistic in statistics)
			{
				statsDictionary[statistic.id] = statistic;
			}
		}

		public Statistic GetStatistic(string id)
		{
			if (statsDictionary.TryGetValue(id, out var value))
			{
				return value;
			}
			return new Statistic
			{
				value = ""
			};
		}

		public void UpdateStatistic(string id, object value, Statistic.DataType type, Statistic.ModType modType = Statistic.ModType.Set, Statistic.DisplayType displayType = Statistic.DisplayType.Default, Statistic.ModType globalMod = Statistic.ModType.Add)
		{
			if (statsDictionary.TryGetValue(id, out var value2))
			{
				switch (modType)
				{
				case Statistic.ModType.Set:
					value2.SetValue(value);
					break;
				case Statistic.ModType.Add:
					value2.AddValue(value);
					break;
				default:
					if (type == Statistic.DataType.Float && modType == Statistic.ModType.Max)
					{
						value2.SetValue(Mathf.Max((float)value, (float)value2.GetValue()));
						break;
					}
					if (type == Statistic.DataType.Float && modType == Statistic.ModType.Min)
					{
						value2.SetValue(Mathf.Min((float)value, (float)value2.GetValue()));
						break;
					}
					if (type == Statistic.DataType.Int && modType == Statistic.ModType.Max)
					{
						value2.SetValue(Mathf.Max((int)value, (int)value2.GetValue()));
						break;
					}
					if (type == Statistic.DataType.Int && modType == Statistic.ModType.Min)
					{
						value2.SetValue(Mathf.Min((int)value, (int)value2.GetValue()));
						break;
					}
					Debug.LogError("STATMANAGER: Unable to apply statistic " + id + " Returning.");
					return;
				}
			}
			else
			{
				value2 = new Statistic
				{
					id = id,
					type = type,
					displayType = displayType,
					defaultModType = globalMod
				};
				if (statsDictionary.ContainsKey(id))
				{
					statsDictionary[id] = value2;
					statsDictionary[id].SetValue(value);
				}
				else
				{
					value2.SetValue(value);
					statistics.Add(value2);
				}
			}
			InitializeDictionary();
		}

		public void UpdateStatistic(string id, object value, Statistic.DataType type, Statistic.DisplayType displayType = Statistic.DisplayType.Default)
		{
			UpdateStatistic(id, value, type, Statistic.ModType.Set, displayType);
		}

		public void UpdateStatistic(string id, object value, Statistic.DataType type)
		{
			UpdateStatistic(id, value, type, Statistic.ModType.Set, Statistic.DisplayType.Default, Statistic.ModType.Add);
		}

		public void SetStatistic(string id, object value, Statistic.DataType type)
		{
			UpdateStatistic(id, value, type, Statistic.ModType.Set, Statistic.DisplayType.Default, Statistic.ModType.Set);
		}

		public bool HasStatistic(string id)
		{
			if (statsDictionary.Count == 0)
			{
				InitializeDictionary();
			}
			return statsDictionary.ContainsKey(id);
		}
	}

	[Serializable]
	public class SaveData
	{
		[Serializable]
		public class GameModeData
		{
			public string name;

			public GameStats stats;

			public List<string> activeTrinkets;

			public List<string> activeSettings;
		}

		[Serializable]
		public class SaveFlags
		{
			public string name;

			public bool value;

			public string data;
		}

		[Serializable]
		public class RoachBank
		{
			public string id;

			public int value;
		}

		[Serializable]
		public class Facility
		{
			[Serializable]
			public class Upgrade
			{
				public string id;

				public List<string> data;

				public bool state;

				public int level;

				public bool owned;
			}

			public string id;

			public List<Upgrade> upgrades;

			public bool HasUpgrade(string upgradeId)
			{
				return GetUpgrade(upgradeId) != null;
			}

			public Upgrade GetUpgrade(string upgradeId)
			{
				if (upgrades == null || upgrades.Count == 0)
				{
					return null;
				}
				foreach (Upgrade upgrade in upgrades)
				{
					if (upgrade.id == upgradeId)
					{
						return upgrade;
					}
				}
				return null;
			}

			public Upgrade GetOrCreateUpgrade(string upgradeId)
			{
				Upgrade upgrade = GetUpgrade(upgradeId);
				if (upgrades == null)
				{
					upgrades = new List<Upgrade>();
				}
				if (upgrade == null)
				{
					upgrade = new Upgrade();
					upgrade.id = upgradeId;
					upgrades.Add(upgrade);
				}
				return upgrade;
			}

			internal void Initialize()
			{
				upgrades = new List<Upgrade>();
			}
		}

		public int version = 7;

		public GameStats gameStats;

		public List<GameModeData> gameModes;

		public List<SaveFlags> flags;

		public List<RoachBank> banks;

		public List<Facility> facilities;

		public List<LevelStat> levelStats;

		public int xp;

		public GameModeData GetGameMode(string gameModeName)
		{
			if (gameModes == null)
			{
				return null;
			}
			foreach (GameModeData gameMode in gameModes)
			{
				if (gameMode.name == gameModeName)
				{
					return gameMode;
				}
			}
			CommandConsole.Log("Could not find gamemode: " + gameModeName + ", Gamemode not found, creating new one.");
			GameModeData gameModeData = new GameModeData();
			gameModeData.name = gameModeName;
			gameModeData.stats = new GameStats();
			gameModeData.activeSettings = new List<string>();
			gameModeData.activeTrinkets = new List<string>();
			gameModeData.stats.InitializeDictionary();
			gameModes.Add(gameModeData);
			return gameModeData;
		}

		public void SetupGamemode(string gameModeName)
		{
			if (gameModes == null)
			{
				gameModes = new List<GameModeData>();
			}
			foreach (GameModeData gameMode in gameModes)
			{
				if (gameMode.name == gameModeName)
				{
					return;
				}
			}
			GameModeData gameModeData = new GameModeData();
			gameModeData.name = gameModeName;
			gameModeData.stats = new GameStats();
			gameModeData.stats.InitializeDictionary();
			gameModes.Add(gameModeData);
		}

		public void UpdateGamemodeStats(string gameModeName, GameStats stats)
		{
			if (gameModes == null)
			{
				gameModes = new List<GameModeData>();
			}
			foreach (GameModeData gameMode in gameModes)
			{
				if (!(gameMode.name == gameModeName))
				{
					continue;
				}
				foreach (Statistic statistic in stats.statistics)
				{
					gameMode.stats.UpdateStatistic(statistic.id, statistic.GetValue(), statistic.type, statistic.defaultModType, statistic.displayType);
				}
				CommandConsole.Log("STATMANAGER: Saving stats in " + gameMode.name);
				return;
			}
			CommandConsole.Log("STATMANAGER: Attempted to store data in gamemode: " + gameModeName + ", Gamemode not found, creating new one.");
			GameModeData gameModeData = new GameModeData();
			gameModeData.name = gameModeName;
			gameModeData.stats = stats;
			gameModeData.stats.InitializeDictionary();
			gameModes.Add(gameModeData);
		}

		public List<string> GetGamemodeTrinkets(string gameModeName)
		{
			GameModeData gameMode = GetGameMode(gameModeName);
			Debug.Log("STATMANAGER: Attempting to get gamemode trinket info for " + gameModeName + " - Found Gamemode: " + (gameMode != null));
			if (gameMode != null && gameMode.activeTrinkets != null)
			{
				return gameMode.activeTrinkets;
			}
			return new List<string>();
		}

		public void SetGamemodeTrinkets(string gameModeName, List<string> trinkets)
		{
			GameModeData gameMode = GetGameMode(gameModeName);
			if (gameMode != null)
			{
				gameMode.activeTrinkets = trinkets;
			}
		}

		public bool IsSettingActive(string gameModeName, string settingID)
		{
			GameModeData gameMode = GetGameMode(gameModeName);
			if (gameMode != null)
			{
				if (gameMode.activeSettings == null)
				{
					gameMode.activeSettings = new List<string>();
				}
				return gameMode.activeSettings.Contains(settingID);
			}
			return false;
		}

		public void SetSetting(string gameModeName, string settingID, bool state)
		{
			GameModeData gameMode = GetGameMode(gameModeName);
			if (gameMode != null)
			{
				if (state && !gameMode.activeSettings.Contains(settingID))
				{
					gameMode.activeSettings.Add(settingID);
				}
				else if (!state && gameMode.activeSettings.Contains(settingID))
				{
					gameMode.activeSettings.Remove(settingID);
				}
			}
		}

		public void SaveFlag(string name, bool flagged, string data = "")
		{
			if (flags == null)
			{
				flags = new List<SaveFlags>();
			}
			foreach (SaveFlags flag in flags)
			{
				if (flag.name == name)
				{
					flag.value = flagged;
					flag.data = data;
					return;
				}
			}
			SaveFlags saveFlags = new SaveFlags();
			saveFlags.name = name;
			saveFlags.value = flagged;
			saveFlags.data = data;
			flags.Add(saveFlags);
		}

		public SaveFlags GetFlag(string name)
		{
			if (flags == null)
			{
				return null;
			}
			foreach (SaveFlags flag in flags)
			{
				if (flag.name == name)
				{
					return flag;
				}
			}
			return null;
		}

		public bool GetFlagState(string name)
		{
			if (flags == null)
			{
				return false;
			}
			foreach (SaveFlags flag in flags)
			{
				if (flag.name == name)
				{
					return flag.value;
				}
			}
			return false;
		}

		public RoachBank GetRoachBankByID(string id)
		{
			if (banks == null)
			{
				banks = new List<RoachBank>();
			}
			foreach (RoachBank bank in banks)
			{
				if (bank.id == id)
				{
					return bank;
				}
			}
			Debug.Log("STATMANAGER: No bank found, creating new one: " + id);
			RoachBank roachBank = new RoachBank();
			roachBank.id = id;
			banks.Add(roachBank);
			return roachBank;
		}

		public Facility GetFacility(string id)
		{
			if (facilities == null)
			{
				facilities = new List<Facility>();
			}
			foreach (Facility facility2 in facilities)
			{
				if (facility2.id == id)
				{
					return facility2;
				}
			}
			Facility facility = new Facility();
			facility.id = id;
			facility.Initialize();
			facilities.Add(facility);
			return facility;
		}
	}

	private const int saveVersion = 7;

	public static GameStats sessionStats;

	private bool hasSaved;

	private static bool hasLoaded = false;

	public static SaveData saveData;

	public static StatManager instance;

	public static bool initialized = false;

	public static Action refreshStatText;

	public static bool showUpgradeDialogue;

	public static bool showUpdateDialogue;

	private string filePathOld;

	private string filePath;

	private static int loadAttempts;

	private UI_ScoreScreen winScreen;

	private UI_ScoreScreen loseScreen;

	private static int recursionMaxDepth = 1024;

	private void Awake()
	{
		instance = this;
		sessionStats = new GameStats();
		saveData = null;
		filePathOld = Path.Combine(Application.persistentDataPath, "save.json");
		filePath = Path.Combine(Application.persistentDataPath, "wk_save.json");
		LoadStats();
		saveData.gameStats.InitializeDictionary();
		sessionStats.InitializeDictionary();
		if (saveData.gameModes != null)
		{
			foreach (SaveData.GameModeData gameMode in saveData.gameModes)
			{
				gameMode.stats.InitializeDictionary();
			}
		}
		CommandConsole.AddCommand("erasesavedata", EraseStats);
		CommandConsole.AddCommand("erasefacilitydata", EraseFacilityData);
		initialized = true;
	}

	private void Start()
	{
		if (CL_GameManager.gamemode != null)
		{
			winScreen = UnityEngine.Object.Instantiate(CL_GameManager.gamemode.winScreen, base.transform);
			loseScreen = UnityEngine.Object.Instantiate(CL_GameManager.gamemode.loseScreen, base.transform);
			winScreen.gameObject.SetActive(value: false);
			loseScreen.gameObject.SetActive(value: false);
		}
	}

	private void OnDestroy()
	{
		if (!hasSaved)
		{
			SaveStats();
		}
		sessionStats = new GameStats();
		initialized = false;
	}

	private void OnApplicationQuit()
	{
		Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "Backups"));
		try
		{
			File.Copy(filePath, Path.Combine(Path.Combine(Application.persistentDataPath, "Backups"), "save-backup-quit.json"), overwrite: true);
		}
		catch (Exception)
		{
			throw;
		}
		if (!CL_GameManager.safeExit)
		{
			File.Copy(filePath, Path.Combine(Path.Combine(Application.persistentDataPath, "Backups"), "save-backup-crash.json"), overwrite: true);
		}
		if (!hasSaved)
		{
			SaveStats();
		}
		sessionStats = new GameStats();
		initialized = false;
	}

	public void SaveStats(bool writeAll = true)
	{
		Debug.Log("STATMANAGER: Attempting Save: Has Cheated? " + CommandConsole.hasCheated);
		if (CommandConsole.hasCheated && (CL_GameManager.gamemode == null || (CL_GameManager.gamemode != null && !CL_GameManager.gamemode.allowCheatedScores)))
		{
			return;
		}
		Debug.Log("STATMANAGER: Writing Save");
		if (writeAll)
		{
			if (CL_GameManager.gMan.allowScores)
			{
				M_Gamemode baseGamemode = CL_GameManager.GetBaseGamemode();
				SaveData.RoachBank roachBankByID = saveData.GetRoachBankByID(baseGamemode.GetRoachBankID());
				if (!CL_SaveManager.HasAnySaves() && !baseGamemode.HasActiveSetting("unlimited") && baseGamemode.saveRoaches)
				{
					UI_RoachBankPopup.ShowRoachChangePopup(-CL_GameManager.GetRoaches(), Mathf.CeilToInt((float)CL_GameManager.GetRoaches() * baseGamemode.creditConversionRate));
					CL_GameManager.MoveRunRoachesIntoBank();
				}
				if (!baseGamemode.IsIronKnuckle() && !baseGamemode.IsCompetitive() && !baseGamemode.HasActiveSetting("unlimited") && baseGamemode.saveRoaches)
				{
					Debug.Log("Moved roaches into bank: " + roachBankByID.value + " :: " + CL_GameManager.GetRoaches(global: true));
					roachBankByID.value = CL_GameManager.GetRoaches(global: true);
				}
				foreach (Statistic statistic in sessionStats.statistics)
				{
					saveData.gameStats.UpdateStatistic(statistic.id, statistic.GetValue(), statistic.type, statistic.defaultModType, statistic.displayType);
				}
				if (CL_GameManager.gamemode != null)
				{
					saveData.UpdateGamemodeStats(CL_GameManager.GetGamemodeName(), sessionStats);
				}
			}
			CL_AchievementManager.SaveAchievements();
		}
		SaveJsonDiffed(filePath, saveData);
		if (writeAll)
		{
			UpdateUI();
			hasSaved = true;
		}
	}

	private static void DiffJson(JObject diffInto, JObject original, int depth)
	{
		if (depth >= recursionMaxDepth)
		{
			throw new Exception("Wow this is infinite recursion");
		}
		foreach (KeyValuePair<string, JToken> item in original)
		{
			item.Deconstruct(out var key, out var value);
			string propertyName = key;
			JToken jToken = value;
			JToken value2 = diffInto.GetValue(propertyName);
			if (value2 == null)
			{
				diffInto[propertyName] = jToken;
			}
			else if (value2 is JObject diffInto2 && jToken is JObject original2)
			{
				DiffJson(diffInto2, original2, depth + 1);
			}
		}
	}

	private static void SaveJsonDiffed<T>(string filePath, T what)
	{
		JObject jObject = JObject.FromObject(what);
		Debug.Log("STATMANAGER: Starting save of Stats in diffed json @ " + filePath);
		if (File.Exists(filePath))
		{
			try
			{
				JObject original = JObject.Parse(File.ReadAllText(filePath));
				DiffJson(jObject, original, 0);
			}
			catch (Exception arg)
			{
				Debug.LogError($"STATMANAGER: Got exception while attempting to save diffed file! Skipping diff. Exception: {arg}");
				jObject = JObject.FromObject(what);
			}
		}
		string contents = jObject.ToString();
		File.WriteAllText(filePath, contents);
		Debug.Log("STATMANAGER: Stat save completed @ " + filePath);
	}

	public void LoadStats()
	{
		bool hasUpgraded = false;
		int newSaveVersion = 0;
		Debug.Log("STATMANAGER: Loading save @ " + filePath);
		if (!hasLoaded && File.Exists(filePathOld) && !File.Exists(filePath))
		{
			Debug.Log("STATMANAGER: Copying old save from @ " + filePathOld);
			File.Copy(filePathOld, filePath);
		}
		if (File.Exists(filePath))
		{
			string text = File.ReadAllText(filePath);
			if (text.Length > 15)
			{
				SaveData saveData;
				try
				{
					saveData = JsonUtility.FromJson<SaveData>(text);
				}
				catch (Exception ex)
				{
					Debug.LogError("STATMANAGER: Warning! Unable to load. Checking Backup: " + ex);
					File.Copy(filePath, Path.Combine(Application.persistentDataPath, "save-error-backup.json"), overwrite: true);
					File.Delete(filePath);
					AttemptLoadBackup();
					return;
				}
				DateTime date = DateTime.UtcNow.Date;
				if (PlayerPrefs.HasKey("backup-date"))
				{
					string s = PlayerPrefs.GetString("backup-date");
					Debug.Log("STATMANAGER: Checking Daily Backup: Last Save = " + date);
					if (DateTime.TryParse(s, out var result))
					{
						result = result.Date;
						if ((date - result).Days != 0)
						{
							File.Copy(filePath, Path.Combine(Application.persistentDataPath, "wk_save-backup.json"), overwrite: true);
							PlayerPrefs.SetString("backup-date", date.ToString("yyyy-MM-dd"));
							PlayerPrefs.Save();
						}
					}
				}
				else
				{
					File.Copy(filePath, Path.Combine(Application.persistentDataPath, "wk_save-backup.json"), overwrite: true);
					Debug.Log("STATMANAGER: Checking Daily Backup: No Last Date. Creating new Backup. " + date);
					PlayerPrefs.SetString("backup-date", date.ToString("yyyy-MM-dd"));
					PlayerPrefs.Save();
				}
				newSaveVersion = saveData.version;
				if (newSaveVersion != 7)
				{
					Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "Backups"));
					File.Copy(filePath, Path.Combine(Path.Combine(Application.persistentDataPath, "Backups"), "wk_save-backup-v" + newSaveVersion + ".json"), overwrite: true);
				}
				if (newSaveVersion < 3)
				{
					foreach (SaveData.GameModeData gameMode in saveData.gameModes)
					{
						int statisticInt = GetStatisticInt(gameMode.stats, "bank-roaches");
						string[] array = gameMode.name.Split('-');
						bool flag = false;
						if (array.Length > 1)
						{
							Debug.Log("STATMANAGER: Converting Gamemode: " + array[0] + " as " + array[1]);
							if (array[1] == "Hardmode")
							{
								flag = true;
							}
						}
						else
						{
							Debug.Log("STATMANAGER: Converting Gamemode: " + array[0]);
						}
						M_Gamemode gamemodeAsset = CL_AssetManager.GetGamemodeAsset(array[0]);
						if (gamemodeAsset != null)
						{
							string text2 = gamemodeAsset.roachBankID;
							if (flag)
							{
								text2 += "-hard";
							}
							saveData.GetRoachBankByID(text2).value += statisticInt;
							Debug.Log($"STATMANAGER: Roaches added to Bank {text2}. Total Value: {saveData.GetRoachBankByID(text2).value}, from {statisticInt}");
						}
					}
				}
				if (newSaveVersion <= 3)
				{
					saveData.gameStats.InitializeDictionary();
					float.TryParse(saveData.gameStats.GetStatistic("player-ascent").value, out var result2);
					float.TryParse(saveData.gameStats.GetStatistic("highest-ascent").value, out var result3);
					float.TryParse(saveData.gameStats.GetStatistic("ascent-rate").value, out var result4);
					float.TryParse(saveData.gameStats.GetStatistic("combined-ascent-rate").value, out var result5);
					float.TryParse(saveData.gameStats.GetStatistic("average-ascent-rate").value, out var result6);
					saveData.gameStats.UpdateStatistic("travel-distance", result2, Statistic.DataType.Float, Statistic.DisplayType.Meters);
					saveData.gameStats.UpdateStatistic("best-travel-distance", result3, Statistic.DataType.Float, Statistic.ModType.Max, Statistic.DisplayType.Meters, Statistic.ModType.Max);
					saveData.gameStats.UpdateStatistic("travel-speed", result4, Statistic.DataType.Float, Statistic.ModType.Set, Statistic.DisplayType.Speed, Statistic.ModType.Max);
					saveData.gameStats.UpdateStatistic("combined-travel-speed", result5, Statistic.DataType.Float, Statistic.ModType.Set, Statistic.DisplayType.Speed);
					saveData.gameStats.UpdateStatistic("average-travel-speed", result6, Statistic.DataType.Float, Statistic.ModType.Set, Statistic.DisplayType.Speed, Statistic.ModType.Set);
					foreach (SaveData.GameModeData gameMode2 in saveData.gameModes)
					{
						string[] array2 = gameMode2.name.Split('-');
						result2 = 0f;
						result3 = 0f;
						result4 = 0f;
						result5 = 0f;
						result6 = 0f;
						float.TryParse(gameMode2.stats.GetStatistic("player-ascent").value, out result2);
						float.TryParse(gameMode2.stats.GetStatistic("highest-ascent").value, out result3);
						float.TryParse(gameMode2.stats.GetStatistic("ascent-rate").value, out result4);
						float.TryParse(gameMode2.stats.GetStatistic("combined-ascent-rate").value, out result5);
						float.TryParse(gameMode2.stats.GetStatistic("average-ascent-rate").value, out result6);
						if (array2.Length > 1)
						{
							Debug.Log("STATMANAGER: Converting Gamemode: " + array2[0] + " as " + array2[1]);
						}
						else
						{
							Debug.Log("STATMANAGER: Converting Gamemode: " + array2[0]);
						}
						gameMode2.stats.UpdateStatistic("travel-distance", result2, Statistic.DataType.Float, Statistic.DisplayType.Meters);
						gameMode2.stats.UpdateStatistic("best-travel-distance", result3, Statistic.DataType.Float, Statistic.ModType.Max, Statistic.DisplayType.Meters, Statistic.ModType.Max);
						gameMode2.stats.UpdateStatistic("travel-speed", result4, Statistic.DataType.Float, Statistic.ModType.Set, Statistic.DisplayType.Speed, Statistic.ModType.Max);
						gameMode2.stats.UpdateStatistic("combined-travel-speed", result5, Statistic.DataType.Float, Statistic.ModType.Set, Statistic.DisplayType.Speed);
						gameMode2.stats.UpdateStatistic("average-travel-speed", result6, Statistic.DataType.Float, Statistic.ModType.Set, Statistic.DisplayType.Speed, Statistic.ModType.Set);
					}
				}
				if (newSaveVersion < 5)
				{
					if (saveData.banks != null && saveData.banks.Count > 0)
					{
						SaveData.RoachBank roachBank = null;
						int num = 0;
						foreach (SaveData.RoachBank bank in saveData.banks)
						{
							if (bank.id == "campaign")
							{
								roachBank = bank;
								num += bank.value;
							}
							if (bank.id == "endless")
							{
								num += bank.value;
							}
						}
						if (roachBank != null)
						{
							roachBank.value = num;
						}
					}
					showUpdateDialogue = true;
				}
				if (newSaveVersion < 6)
				{
					showUpdateDialogue = true;
				}
				if (newSaveVersion < 7)
				{
					if (newSaveVersion == 6)
					{
						newSaveVersion = 7;
						saveData.version = 7;
					}
					PlayerPrefs.SetString("rebinds", "");
					InputManager.instance.ResetAllBindings();
				}
				if (newSaveVersion == 7)
				{
					StatManager.saveData = saveData;
					if (StatManager.saveData.gameStats != null)
					{
						StatManager.saveData.gameStats.InitializeDictionary();
					}
					else
					{
						StatManager.saveData.gameStats = new GameStats();
					}
					StartCoroutine(WaitOneFrameForXPCalc());
				}
				else
				{
					hasUpgraded = true;
					if (saveData.flags != null)
					{
						foreach (SaveData.SaveFlags flag2 in saveData.flags)
						{
							if (flag2.name == "ACH_HABITATION")
							{
								StatManager.saveData = saveData;
								StatManager.saveData.version = 7;
								if (StatManager.saveData.gameStats != null)
								{
									StatManager.saveData.gameStats.InitializeDictionary();
								}
								else
								{
									StatManager.saveData.gameStats = new GameStats();
								}
								StartCoroutine(WaitOneFrameForXPCalc());
								return;
							}
						}
					}
					showUpgradeDialogue = true;
					File.Copy(filePath, Path.Combine(Application.persistentDataPath, "save-backup.json"), overwrite: true);
					File.Copy(filePath, Path.Combine(Application.persistentDataPath, "save-demo.json"), overwrite: true);
					StatManager.saveData = saveData;
					StatManager.saveData.version = 7;
					if (StatManager.saveData.gameStats != null)
					{
						StatManager.saveData.gameStats.InitializeDictionary();
					}
					else
					{
						StatManager.saveData.gameStats = new GameStats();
					}
					if (newSaveVersion <= 1)
					{
						SettingsManager.WipeSettings();
					}
					StartCoroutine(WaitOneFrameForXPCalc());
				}
			}
			else
			{
				StatManager.saveData = new SaveData();
				StatManager.saveData.gameStats = new GameStats();
			}
		}
		else
		{
			StatManager.saveData = new SaveData();
			StatManager.saveData.gameStats = new GameStats();
		}
		hasLoaded = true;
		Debug.Log("STATMANAGER: Finished loading Stat save @ " + filePath);
		IEnumerator WaitOneFrameForXPCalc()
		{
			yield return new WaitForSeconds(0.5f);
			StatManager.saveData.gameStats.SetStatistic("progression-experience", CL_AchievementManager.GetCalculatedXP(), Statistic.DataType.Int);
			if (hasUpgraded && CL_OverlayUIManager.instance != null)
			{
				Debug.Log("STATMANAGER: Showing Popup");
				Message_Manager.Message_Packet packet = new Message_Manager.Message_Packet
				{
					type = "default",
					closeText = "Continue",
					message = $"<color=yellow>Your Save has Been Upgraded:</color>\nVersion <color=red>{newSaveVersion}</color> --> <color=green>{7}</color>!",
					screenPos = new Vector2(0f, 0f)
				};
				CL_OverlayUIManager.instance.messageManager.CreateMessage(packet);
			}
		}
	}

	private bool AttemptLoadBackup()
	{
		if (loadAttempts < 2 && File.Exists(Path.Combine(Application.persistentDataPath, "wk_save-backup.json")) && File.ReadAllText(Path.Combine(Application.persistentDataPath, "wk_save-backup.json")).Length > 5)
		{
			Debug.LogError("STATMANAGER: Error! Failed to load save file. Attempting to load backup.");
			File.Copy(Path.Combine(Application.persistentDataPath, "wk_save-backup.json"), filePath, overwrite: true);
			loadAttempts++;
			LoadStats();
			return true;
		}
		return false;
	}

	private void UpgradeVersion(string json, SaveData newSaveData)
	{
	}

	public void EraseStats(string[] args = null)
	{
		CommandConsole.Log("Are you sure you want to erase your stats? They'll be gone forever!");
		CommandConsole.CommandContextPush();
		Action<string[]> callback = delegate
		{
			CommandConsole.Log("Goodbye.");
			CommandConsole.CommandContextPop();
			EraseStats();
		};
		Action<string[]> callback2 = delegate
		{
			CommandConsole.Log("Understandable.");
			CommandConsole.CommandContextPop();
		};
		CommandConsole.BuildCommand("no", callback2).NotCheat().Description("I want to back out.");
		CommandConsole.BuildCommand("yes", callback).NotCheat().Description("I am sure I want to delete my entire save.");
	}

	public void EraseFacilityData(string[] args = null)
	{
		saveData.facilities = new List<SaveData.Facility>();
		if (Facility.onPurchaseUpgrade != null)
		{
			Facility.onPurchaseUpgrade();
		}
	}

	public void EraseStats()
	{
		CL_AchievementManager.ResetAchievements();
		if (filePath != null)
		{
			File.Delete(filePath);
		}
		LoadStats();
		CommandConsole.Log("Erased all saved statistics and scores.");
		CL_GameManager.gMan.RestartScene();
		SettingsManager.settings.cosmeticSaveData = new CL_CosmeticManager.CosmeticSaveData();
		SettingsManager.SetSetting(new string[2] { "g_hard", "false" });
	}

	public void UpdateUI()
	{
		TMP_Text[] componentsInChildren = GetComponentsInChildren<TMP_Text>();
		foreach (TMP_Text tMP_Text in componentsInChildren)
		{
			if (tMP_Text.name.StartsWith("session-stat:"))
			{
				string key = tMP_Text.name.Substring("session-stat:".Length);
				if (sessionStats.statsDictionary.TryGetValue(key, out var value))
				{
					tMP_Text.text = ReplaceTextAfterColon(tMP_Text.text, value.GetString());
				}
			}
			else if (tMP_Text.name.StartsWith("global-stat:"))
			{
				string key2 = tMP_Text.name.Substring("global-stat:".Length);
				if (saveData.gameStats.statsDictionary.TryGetValue(key2, out var value2))
				{
					tMP_Text.text = ReplaceTextAfterColon(tMP_Text.text, value2.GetString());
				}
			}
			else if (tMP_Text.name.StartsWith("gamemode-stat:") && CL_GameManager.gamemode != null)
			{
				string key3 = tMP_Text.name.Substring("gamemode-stat:".Length);
				if (saveData.GetGameMode(CL_GameManager.GetGamemodeName()) != null && saveData.GetGameMode(CL_GameManager.GetGamemodeName()).stats.statsDictionary.TryGetValue(key3, out var value3))
				{
					tMP_Text.text = ReplaceTextAfterColon(tMP_Text.text, value3.GetString());
				}
			}
		}
	}

	private string ReplaceTextAfterColon(string originalText, string newValue)
	{
		int num = originalText.IndexOf(':');
		if (num != -1)
		{
			return originalText.Substring(0, num + 1) + " " + newValue;
		}
		return originalText;
	}

	public static object GetStatisticValue(GameStats stats, string statName)
	{
		if (stats == null)
		{
			Debug.LogWarning("Warning! No stats variable found for " + statName);
		}
		if (!stats.HasStatistic(statName))
		{
			return null;
		}
		return stats.GetStatistic(statName).GetValue();
	}

	public static int GetStatisticInt(GameStats stats, string statName)
	{
		if (!stats.HasStatistic(statName))
		{
			return 0;
		}
		return (int)stats.GetStatistic(statName).GetValue();
	}

	public static float GetStatisticFloat(GameStats stats, string statName)
	{
		if (!stats.HasStatistic(statName))
		{
			return 0f;
		}
		return (float)stats.GetStatistic(statName).GetValue();
	}

	public static int GetTotalStatisticInt(string statName)
	{
		Statistic statistic = saveData.gameStats.GetStatistic(statName);
		if (statistic != null)
		{
			if (statistic.type == Statistic.DataType.Int)
			{
				return (int)saveData.gameStats.GetStatistic(statName).GetValue() + (int)sessionStats.GetStatistic(statName).GetValue();
			}
			if (statistic.type == Statistic.DataType.Float)
			{
				return Mathf.RoundToInt((float)saveData.gameStats.GetStatistic(statName).GetValue() + (float)sessionStats.GetStatistic(statName).GetValue());
			}
		}
		return 0;
	}

	public static float GetTotalStatisticFloat(string statName)
	{
		float num = 0f;
		float num2 = 0f;
		if (saveData.gameStats.GetStatistic(statName).type == Statistic.DataType.Int)
		{
			num += (float)(int)saveData.gameStats.GetStatistic(statName).GetValue();
		}
		else if (saveData.gameStats.GetStatistic(statName).type == Statistic.DataType.Float)
		{
			num += (float)saveData.gameStats.GetStatistic(statName).GetValue();
		}
		if (sessionStats.GetStatistic(statName).type == Statistic.DataType.Int)
		{
			num += (float)(int)sessionStats.GetStatistic(statName).GetValue();
		}
		else if (sessionStats.GetStatistic(statName).type == Statistic.DataType.Float)
		{
			num += (float)sessionStats.GetStatistic(statName).GetValue();
		}
		return num + num2;
	}

	public static bool HasGlobalStat(string statName)
	{
		return saveData.gameStats.HasStatistic(statName);
	}

	public LevelStat GetLevelStat(string id)
	{
		foreach (LevelStat levelStat in saveData.levelStats)
		{
			if (levelStat.levelId == id)
			{
				return levelStat;
			}
		}
		return new LevelStat
		{
			levelId = id,
			bestTime = -1f
		};
	}

	public void SaveLevelStat(LevelStat s)
	{
		if (saveData.levelStats == null)
		{
			saveData.levelStats = new List<LevelStat>();
		}
		saveData.levelStats.Add(s);
	}

	public UI_ScoreScreen GetScoreScreen(bool win = false)
	{
		if (win)
		{
			return winScreen;
		}
		return loseScreen;
	}

	public void ShowScoreScreen(bool win = false)
	{
		SaveStats();
		UI_ScoreScreen uI_ScoreScreen = null;
		if (win)
		{
			uI_ScoreScreen = winScreen;
			winScreen.gameObject.SetActive(value: true);
		}
		else
		{
			uI_ScoreScreen = loseScreen;
			loseScreen.gameObject.SetActive(value: true);
		}
		uI_ScoreScreen.ShowScreen();
		UpdateUI();
	}
}
