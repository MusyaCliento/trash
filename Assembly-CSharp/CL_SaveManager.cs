using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using UnityEngine;

public class CL_SaveManager : MonoBehaviour
{
	[Serializable]
	public class SaveState
	{
		public enum SaveType
		{
			standard = 0,
			disk = 1,
			scissors = 2,
			reset = 3,
			resetwithitems = 4,
			session = 5
		}

		public string id;

		public string flag;

		public string gamemode;

		public ENT_Player.SaveData playerData;

		public List<M_Level.SaveData> levelData;

		public List<WorldLoader.BranchInfo.LevelId> levelGenerationList;

		public DEN_DeathFloor.SaveData gooData;

		public SaveType type;

		public int amount;

		public List<string> soldOutTerminals;

		public bool clearItems;

		public bool forceRoomReset;

		public float playerTravelDistance;

		public float playerBestTravelDistance;

		public Vector3 playerLastTravelCheckpointOffset;

		public IEnumerator LoadSave(SessionSave sessionSave = null)
		{
			WorldLoader.SkyboxManager.UnloadSkyboxes();
			ENT_Player player = ENT_Player.GetPlayer();
			if (playerData.pocketInventory == null)
			{
				playerData.pocketInventory = Array.Empty<Inventory.Pouch.PouchSaveData>();
			}
			if (sessionSave != null)
			{
				playerData = sessionSave.playerSave.playerData;
			}
			if (type == SaveType.disk || type == SaveType.reset || clearItems)
			{
				for (int i = 0; i < playerData.pouchInventory.Length; i++)
				{
					playerData.pouchInventory[i].items = playerData.ProcessWipeInventory(player, playerData.pouchInventory[i].items.ToArray(), type, spawnHammerIfMissing: false).ToList();
				}
				for (int j = 0; j < playerData.pocketInventory.Length; j++)
				{
					playerData.pocketInventory[j].items = playerData.ProcessWipeInventory(player, playerData.pocketInventory[j].items.ToArray(), type, spawnHammerIfMissing: false).ToList();
				}
				bool flag = false;
				foreach (Inventory.Pouch.PouchSaveData item in playerData.pouchInventory.Concat(playerData.pocketInventory))
				{
					foreach (Item item2 in item.items)
					{
						if (item2.HasTag("hammer"))
						{
							flag = true;
						}
					}
				}
				playerData.inventory = playerData.ProcessWipeInventory(player, playerData.inventory, type, !flag);
				playerData.handInventory = new Item[2];
				if (!playerData.HasPerk("Perk_AnomalousBonds"))
				{
					foreach (Inventory.Pouch.PouchSaveData item3 in playerData.pouchInventory.Concat(playerData.pocketInventory))
					{
						int count = item3.items.Count;
						while (count-- > 0)
						{
							if (type != SaveType.disk || !item3.items[count].HasTag("savewithdisk"))
							{
								item3.items.RemoveAt(count);
							}
						}
					}
				}
			}
			if (sessionSave != null)
			{
				playerData.perks = sessionSave.playerSave.playerData.perks;
				playerData.buffs = sessionSave.playerSave.playerData.buffs;
			}
			if (type == SaveType.disk)
			{
				if (sessionSave != null)
				{
					playerData.LoadDataIntoPlayer(ENT_Player.playerObject, loadInventory: true, loadPerks: true, loadBuffs: true);
				}
				else
				{
					playerData.LoadDataIntoPlayer(ENT_Player.playerObject);
				}
			}
			else
			{
				playerData.LoadDataIntoPlayer(ENT_Player.playerObject, loadInventory: true, loadPerks: true, loadBuffs: true, "other");
			}
			if (gamemode != null || gamemode != "")
			{
				M_Gamemode gamemodeAsset = CL_AssetManager.GetGamemodeAsset(gamemode);
				if (gamemodeAsset != null)
				{
					CL_GameManager.gMan.SetGamemode(gamemodeAsset);
				}
			}
			ENT_Player.playerObject.UnLock();
			List<M_Level.LevelAssetHolder> list = new List<M_Level.LevelAssetHolder>();
			if (levelData != null)
			{
				foreach (M_Level.SaveData levelDatum in levelData)
				{
					list.Add(CL_AssetManager.GetLevelAsset(levelDatum.levelName));
				}
			}
			if (WorldLoader.initialized)
			{
				if (DEN_DeathFloor.instance != null)
				{
					DEN_DeathFloor.instance.transform.position = Vector3.up * -50f;
				}
				WorldLoader.GenerationParameters.GenerationType generationType = WorldLoader.GenerationParameters.GenerationType.saveLoad;
				if (levelGenerationList == null || levelGenerationList.Count == 0)
				{
					generationType = WorldLoader.GenerationParameters.GenerationType.generateUntilFound;
				}
				WorldLoader.GenerationParameters generationParameters = new WorldLoader.GenerationParameters
				{
					generationType = generationType,
					targetLevel = list[0].id,
					saveLevels = levelGenerationList,
					levelData = levelData,
					preloadLevels = list,
					lastRegion = CL_AssetManager.GetRegionAsset(levelData[0].regionName),
					startRegion = CL_AssetManager.GetRegionAsset(levelData[0].regionName),
					setPlayerPositionToTargetLevel = true,
					flags = new List<string>()
				};
				if (type == SaveType.reset)
				{
					generationParameters.setPlayerPositionToTargetLevel = false;
				}
				if (type == SaveType.disk)
				{
					WorldLoader.IncrementSeed(1);
					generationParameters.flags.Add("loadtype-disk");
				}
				else if (!forceRoomReset)
				{
					generationParameters.loadSavedEntities = true;
				}
				WorldLoader.instance.RestartGenerationFromLevelList(generationParameters);
				if (type != SaveType.disk)
				{
					CL_UIManager.instance.FadeOut();
				}
				while (!WorldLoader.isLoaded)
				{
					yield return null;
				}
				if (type != SaveType.disk)
				{
					CL_UIManager.instance.FadeIn();
				}
				if (type == SaveType.reset)
				{
					ENT_Player.playerObject.transform.position = WorldLoader.instance.GetCurrentLevel().GetLevel().transform.TransformPoint(playerData.positionRelativeToLevel);
					ENT_Player.playerObject.transform.rotation = playerData.playerRotation * WorldLoader.instance.GetCurrentLevel().GetLevel().transform.rotation;
					ENT_Player.playerObject.camTransform.localRotation = playerData.playerCameraRotation;
				}
			}
			else
			{
				ENT_Player.playerObject.transform.position = playerData.positionRelativeToLevel;
				ENT_Player.playerObject.transform.rotation = playerData.playerRotation;
				ENT_Player.playerObject.camTransform.localRotation = playerData.playerCameraRotation;
			}
			CL_GameManager.gMan.ResetPlayerDistanceCheckPosition(ENT_Player.playerObject.transform.position, playerTravelDistance, 0f, 1f, playerBestTravelDistance);
			instance.StartCoroutine(LoadDelay());
			if (DEN_Teeth.instance != null)
			{
				DEN_Teeth.instance.Despawn();
			}
			DEN_Face.Despawn();
			DEN_Hunter.Despawn();
			if (type == SaveType.disk)
			{
				amount--;
				if (amount <= 0)
				{
					saveStates.Remove(this);
				}
			}
			yield return new WaitForSeconds(3f);
			if (sessionSave != null)
			{
				if (type == SaveType.reset || type == SaveType.resetwithitems)
				{
					yield break;
				}
				int numberOfDiskLives = GetNumberOfDiskLives();
				if (numberOfDiskLives > 0)
				{
					if (numberOfDiskLives == 1)
					{
						CL_UIManager.instance.highscoreHeader.ShowText($"<size=28>Resumed Save. {numberOfDiskLives} Life Remaining.");
					}
					else
					{
						CL_UIManager.instance.highscoreHeader.ShowText($"<size=28>Resumed Save. {numberOfDiskLives} Lives Remaining.");
					}
				}
				else
				{
					CL_UIManager.instance.highscoreHeader.ShowText("<size=28>No Lives Remaining.\nGood Luck.");
				}
			}
			else
			{
				if (type == SaveType.reset || type == SaveType.resetwithitems)
				{
					yield break;
				}
				int numberOfDiskLives2 = GetNumberOfDiskLives();
				if (numberOfDiskLives2 > 0)
				{
					if (numberOfDiskLives2 == 1)
					{
						CL_UIManager.instance.highscoreHeader.ShowText($"<size=28>Life Lost. {numberOfDiskLives2} Life Remaining.");
					}
					else
					{
						CL_UIManager.instance.highscoreHeader.ShowText($"<size=28>Life Lost. {numberOfDiskLives2} Lives Remaining.");
					}
				}
				else
				{
					CL_UIManager.instance.highscoreHeader.ShowText("<size=28>No Lives Remaining.\nGood Luck.");
				}
			}
		}

		private IEnumerator LoadDelay()
		{
			if (DEN_DeathFloor.instance != null)
			{
				DEN_DeathFloor.instance.transform.position = Vector3.up * -50f;
			}
			yield return new WaitForSeconds(0.5f);
			if (DEN_DeathFloor.instance != null)
			{
				DEN_DeathFloor.instance.transform.position = Vector3.up * -50f;
				DEN_DeathFloor.instance.LoadDataFromSave(gooData);
			}
		}

		public void UpdatePlayerData(ENT_Player player)
		{
			playerData = new ENT_Player.SaveData();
			playerData.SaveDataIntoClass(player);
		}

		public void Save(string[] flags = null)
		{
			UpdatePlayerData(ENT_Player.playerObject);
			playerTravelDistance = CL_GameManager.GetPlayerLastTravelDistance();
			playerBestTravelDistance = CL_GameManager.gMan.GetPlayerBestTravelDistance();
			if (WorldLoader.initialized)
			{
				M_Level.SaveData save = M_Level.SaveData.GetSave(WorldLoader.GetCurrentLevelFromBounds().GetLevel(), flags);
				save.playerRespawnLevel = true;
				if (type == SaveType.disk)
				{
					save.activeStates.Add("onDiskReload");
				}
				save.activeStates.Add("onLoad");
				levelData = new List<M_Level.SaveData> { save };
				levelGenerationList = new List<WorldLoader.BranchInfo.LevelId>();
				bool flag = false;
				foreach (WorldLoader.BranchInfo.LevelId levelID in WorldLoader.instance.currentBranch.levelIDs)
				{
					if (levelID.level == save.levelName)
					{
						flag = true;
					}
					if (flag)
					{
						levelGenerationList.Add(levelID);
					}
				}
			}
			if (DEN_DeathFloor.instance != null)
			{
				gooData = DEN_DeathFloor.instance.GetSaveData();
			}
		}
	}

	public class SessionSave
	{
		public int version = 2;

		public string saveName;

		public string gamemode;

		public int worldSeed;

		public StatManager.GameStats sessionStats;

		public CL_ScoreManager.SessionScore saveSessionScore;

		public SaveState checkpointState;

		public List<SaveState> saveStates = new List<SaveState>();

		public SaveState playerSave;

		public List<CL_GameManager.SessionFlag> sessionFlags;

		public float playerAscent;

		public float travelDistance;

		public Vector3 checkpointPosition;

		public float checkpointTravelDistance;

		public float checkpointSpacewarp;

		public float checkpointBestTravelDistance;

		public float lastTravelDistance;

		public float gameTime;

		public bool hasCheated;

		public int roaches;

		public bool clearItems;

		public string loadInText;
	}

	public const int saveVersion = 2;

	public static bool loadSessionSaveOnLoad = false;

	public static bool isSessionSave;

	public static bool isSavedRun;

	public static CL_SaveManager instance;

	private SessionSave lastSessionSave;

	public static List<SaveState> saveStates = new List<SaveState>();

	private void Start()
	{
		instance = this;
		saveStates = new List<SaveState>();
		if (loadSessionSaveOnLoad)
		{
			loadSessionSaveOnLoad = false;
			isSessionSave = true;
			isSavedRun = true;
			StartCoroutine(WaitUntilLoad());
		}
		IEnumerator WaitUntilLoad()
		{
			yield return null;
			LoadSession();
		}
	}

	private void Update()
	{
	}

	public static SaveState GetMostRecentSaveStateWithFlag(string flag, bool contains = false)
	{
		foreach (SaveState saveState2 in saveStates)
		{
			Debug.Log(saveState2.flag);
		}
		for (int num = saveStates.Count - 1; num >= 0; num--)
		{
			SaveState saveState = saveStates[num];
			Debug.Log(saveState.flag);
			if (contains)
			{
				if (saveState.flag.Contains(flag))
				{
					Debug.Log("Found save state with session: " + flag + " : " + saveState.type);
					return saveState;
				}
			}
			else if (saveState.flag == flag)
			{
				Debug.Log("Found save state with session: " + flag + " : " + saveState.type);
				return saveState;
			}
		}
		return null;
	}

	public static SaveState GetMostRecentSaveStateByType(SaveState.SaveType type)
	{
		for (int num = saveStates.Count - 1; num >= 0; num--)
		{
			SaveState saveState = saveStates[num];
			if (saveState.type == type)
			{
				return saveState;
			}
		}
		return null;
	}

	public static SaveState GetSaveStateByID(string id, SaveState.SaveType type)
	{
		for (int num = saveStates.Count - 1; num >= 0; num--)
		{
			SaveState saveState = saveStates[num];
			if (saveState.id == id)
			{
				return saveState;
			}
		}
		return null;
	}

	public static List<SaveState> GetAllSaveStatesByType(SaveState.SaveType type)
	{
		List<SaveState> list = new List<SaveState>();
		for (int num = saveStates.Count - 1; num >= 0; num--)
		{
			if (saveStates[num].type == type)
			{
				list.Add(saveStates[num]);
			}
		}
		return list;
	}

	public static int GetNumberOfDiskLives()
	{
		int num = 0;
		for (int num2 = saveStates.Count - 1; num2 >= 0; num2--)
		{
			if (saveStates[num2].type == SaveState.SaveType.disk)
			{
				num += saveStates[num2].amount;
			}
		}
		return num;
	}

	public static void CreateSaveState(string id, string flag, SaveState.SaveType type)
	{
		SaveState saveState = new SaveState();
		saveState.id = id;
		saveState.flag = flag;
		saveState.type = type;
		saveState.amount = 1;
		saveState.gamemode = CL_GameManager.gamemode.name;
		List<string> list = new List<string>();
		list.Add("savetype:" + type);
		saveState.Save(list.ToArray());
		saveStates.Add(saveState);
	}

	public static SaveState CreateOrUpdateSaveState(string id, string flag, SaveState.SaveType type, int amountAdjust = 1, bool saveToSaveStates = true)
	{
		SaveState saveState = (saveToSaveStates ? GetSaveStateByID(id, type) : null);
		Debug.Log("CREATING SAVE STATE: " + flag + " ID: " + id);
		List<string> list = new List<string>();
		list.Add("savetype:" + type);
		if (saveState == null)
		{
			saveState = new SaveState();
			saveState.id = id;
			saveState.flag = flag;
			saveState.type = type;
			saveState.amount = Mathf.Max(amountAdjust, 0);
			saveState.Save(list.ToArray());
			saveState.clearItems = false;
			saveState.gamemode = CL_GameManager.gamemode.name;
			if (type == SaveState.SaveType.reset)
			{
				saveState.forceRoomReset = true;
			}
			if (saveToSaveStates)
			{
				saveStates.Add(saveState);
			}
		}
		else
		{
			saveState.Save(list.ToArray());
			saveState.amount += amountAdjust;
			saveState.amount = Mathf.Max(saveState.amount, 0);
		}
		return saveState;
	}

	public static void LoadSave(SaveState save, SessionSave sessionSave = null)
	{
		if (save != null)
		{
			instance.StartCoroutine(save.LoadSave(sessionSave));
		}
	}

	public void StartDiskDeathSequence()
	{
		StartCoroutine(DeathSequence());
	}

	public IEnumerator DeathSequence()
	{
		CL_GameManager.SetTimescale(0.05f);
		AudioManager.instance.gameMixerPitchMult = 0.1f;
		yield return new WaitForSecondsRealtime(1f);
		AudioManager.instance.gameMixerPitchMult = 1f;
	}

	public void LoadSession()
	{
		string text = "";
		if (CL_GameManager.IsHardmode())
		{
			text += "-hardmode";
		}
		string text2 = CL_GameManager.GetGamemodeName(includeOptions: false).ToLower() + text;
		SessionSave sessionSave = LoadSessionFromFile(text2);
		CL_GameManager.gMan.sessionFlags = sessionSave.sessionFlags;
		CL_GameManager.gMan.RebuildSessionFlagDictionary();
		CL_GameManager.SetRoaches(sessionSave.roaches);
		CommandConsole.hasCheated = sessionSave.hasCheated;
		Debug.Log(sessionSave.gamemode);
		if (text2 != null || text2 != "")
		{
			M_Gamemode gamemodeAsset = CL_AssetManager.GetGamemodeAsset(sessionSave.gamemode);
			CL_GameManager.gMan.SetGamemode(gamemodeAsset);
		}
		CL_GameManager.SetLoading(b: true);
		saveStates = sessionSave.saveStates;
		StatManager.sessionStats = sessionSave.sessionStats;
		CL_ScoreManager.Initialize(sessionSave.saveSessionScore);
		CL_GameManager.gMan.SetGameTime(sessionSave.gameTime);
		CL_GameManager.gMan.ResetPlayerDistanceCheckPosition(sessionSave.checkpointPosition, sessionSave.lastTravelDistance, sessionSave.checkpointTravelDistance, sessionSave.checkpointSpacewarp, sessionSave.checkpointBestTravelDistance);
		for (int num = saveStates.Count - 1; num >= 0; num--)
		{
			SaveState saveState = saveStates[num];
			Debug.Log("Save State Found: " + saveState.id + " " + saveState.flag + " " + saveState.type.ToString() + " Amount: " + saveState.amount);
		}
		SaveState saveState2 = null;
		int num2 = saveStates.Count - 1;
		if (num2 >= 0)
		{
			SaveState saveState3 = saveStates[num2];
			Debug.Log("Save State: " + saveState3.id + " " + saveState3.flag + " " + saveState3.type);
			if (saveState3.type == SaveState.SaveType.standard && saveState3.flag.Contains("session"))
			{
				saveState2 = saveState3;
				Debug.Log("Found Save: " + saveState2.flag + " Clear: " + saveState2.clearItems);
			}
			else
			{
				saveState2 = saveState3;
			}
		}
		if (saveState2 == null)
		{
			if (saveStates.Count > 0)
			{
				saveState2 = saveStates[saveStates.Count - 1];
			}
			else
			{
				saveState2 = sessionSave.playerSave;
				Debug.LogError("Uh oh! Found no normal save data, this should not happen! Resetting to the playersave.");
			}
		}
		else if (saveState2.type == SaveState.SaveType.standard)
		{
			RemoveOrLowerSaveAmount(ref saveStates, saveState2);
		}
		Debug.Log("Loading State: " + saveState2.id + " " + saveState2.flag + " " + saveState2.type);
		LoadSave(saveState2, sessionSave);
		lastSessionSave = sessionSave;
	}

	public SessionSave SaveSession(bool eraseStats = false, bool saveToFile = true, bool clearItems = false, string nameAppend = "", bool resetRoom = false)
	{
		SessionSave sessionSave = new SessionSave();
		sessionSave.gamemode = CL_GameManager.GetGamemodeName(includeOptions: false, mainMode: true);
		sessionSave.sessionStats = StatManager.sessionStats;
		if (WorldLoader.instance != null)
		{
			sessionSave.worldSeed = WorldLoader.instance.seed;
		}
		sessionSave.sessionFlags = CL_GameManager.gMan.sessionFlags;
		sessionSave.gameTime = CL_GameManager.gMan.GetGameTime();
		sessionSave.playerAscent = CL_GameManager.gMan.GetPlayerAscent();
		sessionSave.travelDistance = CL_GameManager.gMan.GetPlayerBestTravelDistance();
		sessionSave.checkpointPosition = CL_GameManager.gMan.GetPlayerDistanceCheckPosition();
		sessionSave.checkpointTravelDistance = CL_GameManager.gMan.GetPlayerDistanceFromCheck();
		sessionSave.checkpointBestTravelDistance = CL_GameManager.gMan.GetPlayerBestTravelDistance();
		sessionSave.saveSessionScore = CL_ScoreManager.sessionScore;
		sessionSave.lastTravelDistance = CL_GameManager.GetPlayerLastTravelDistance();
		sessionSave.hasCheated = CommandConsole.hasCheated;
		sessionSave.roaches = CL_GameManager.GetRoaches();
		sessionSave.clearItems = clearItems;
		if (WorldLoader.instance != null && WorldLoader.instance.GetCurrentLevel().GetLevel() != null)
		{
			sessionSave.saveName = WorldLoader.instance.GetCurrentLevel().GetLevel().saveName;
		}
		else
		{
			sessionSave.saveName = "Unknown";
		}
		string text = "session";
		if (nameAppend != "")
		{
			text = text + "-" + nameAppend;
		}
		SaveState mostRecentSaveStateWithFlag = GetMostRecentSaveStateWithFlag(text);
		if (mostRecentSaveStateWithFlag != null)
		{
			saveStates.Remove(mostRecentSaveStateWithFlag);
		}
		SaveState saveState = CreateOrUpdateSaveState(CL_GameManager.gamemode.gamemodeName + "-" + text, text, SaveState.SaveType.standard, 0);
		if (clearItems)
		{
			saveState.clearItems = true;
		}
		saveState.forceRoomReset = resetRoom;
		sessionSave.saveStates = saveStates;
		sessionSave.playerSave = CreateOrUpdateSaveState(CL_GameManager.gamemode.gamemodeName + "-" + text, text, SaveState.SaveType.standard, 0, saveToSaveStates: false);
		string text2 = "";
		if (CL_GameManager.IsHardmode())
		{
			text2 += "-hardmode";
		}
		string fileName = CL_GameManager.GetGamemodeName(includeOptions: false, mainMode: true).ToLower() + text2;
		if (saveToFile)
		{
			SaveSessionToFile(sessionSave, fileName);
		}
		isSavedRun = true;
		if (eraseStats)
		{
			StatManager.sessionStats = new StatManager.GameStats();
		}
		lastSessionSave = sessionSave;
		return sessionSave;
	}

	public static void SaveSessionToFile(SessionSave data, string fileName)
	{
		string value = JsonUtility.ToJson(data, prettyPrint: true);
		Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "Sessions/"));
		using FileStream stream = new FileStream(Path.Combine(Application.persistentDataPath, "Sessions/" + fileName + "-save.session"), FileMode.Create, FileAccess.Write);
		using GZipStream stream2 = new GZipStream(stream, System.IO.Compression.CompressionLevel.Optimal);
		using StreamWriter streamWriter = new StreamWriter(stream2, Encoding.UTF8);
		streamWriter.Write(value);
	}

	public static SessionSave LoadSessionFromFile(string fileName)
	{
		string path = Path.Combine(Application.persistentDataPath, "Sessions/" + fileName + "-save.session");
		if (!File.Exists(path))
		{
			return null;
		}
		using FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
		using GZipStream stream2 = new GZipStream(stream, CompressionMode.Decompress);
		using StreamReader streamReader = new StreamReader(stream2, Encoding.UTF8);
		return JsonUtility.FromJson<SessionSave>(streamReader.ReadToEnd());
	}

	internal static void DeleteSessionSave(string gamemodeName, bool hardmode)
	{
		string text = "";
		if (hardmode)
		{
			text += "-hardmode";
		}
		string text2 = gamemodeName.ToLower() + text;
		string path = Path.Combine(Application.persistentDataPath, "Sessions/" + text2 + "-save.session");
		if (File.Exists(path))
		{
			File.Delete(path);
		}
	}

	public void RemoveOrLowerSaveAmount(ref List<SaveState> saveList, SaveState s)
	{
		if (s.amount > 1)
		{
			s.amount--;
		}
		else
		{
			saveList.Remove(s);
		}
	}

	public void SaveLastSessionToFile(bool removeLastDisk = true, bool copyCurrentPlayerInventory = false)
	{
		if (lastSessionSave == null)
		{
			return;
		}
		string text = "";
		if (CL_GameManager.IsHardmode())
		{
			text += "-hardmode";
		}
		string fileName = CL_GameManager.GetGamemodeName(includeOptions: false, mainMode: true).ToLower() + text;
		if (removeLastDisk)
		{
			for (int num = lastSessionSave.saveStates.Count - 1; num >= 0; num--)
			{
				if (lastSessionSave.saveStates[num].type == SaveState.SaveType.standard)
				{
					lastSessionSave.saveStates.RemoveAt(num);
				}
			}
		}
		string saveName = lastSessionSave.saveName;
		SaveState saveState = null;
		if (lastSessionSave.saveStates.Count > 0)
		{
			List<SaveState> list = lastSessionSave.saveStates;
			saveState = list[list.Count - 1];
		}
		M_Level.SaveData saveData = null;
		if (saveState != null && saveState.levelData.Count > 0)
		{
			saveData = saveState.levelData[0];
		}
		M_Level.LevelAssetHolder levelAssetHolder = null;
		if (saveData != null && saveState.levelData.Count > 0)
		{
			levelAssetHolder = CL_AssetManager.GetLevelAsset(saveData.levelName);
		}
		if (levelAssetHolder != null)
		{
			saveName = levelAssetHolder.GetLevel().saveName;
		}
		lastSessionSave.saveName = saveName;
		lastSessionSave.playerSave = CreateOrUpdateSaveState(CL_GameManager.gamemode.gamemodeName + "-session", "playerSave", SaveState.SaveType.standard, 0, saveToSaveStates: false);
		new ENT_Player.SaveData().SaveDataIntoClass(ENT_Player.GetPlayer());
		lastSessionSave.playerSave.playerData.SaveDataIntoClass(ENT_Player.GetPlayer());
		SaveSessionToFile(lastSessionSave, fileName);
	}

	public static bool SessionFileExists(string gamemode, bool hardmode)
	{
		string text = "";
		if (hardmode)
		{
			text += "-hardmode";
		}
		SessionSave sessionSave = LoadSessionFromFile(gamemode.ToLower() + text);
		if (sessionSave != null)
		{
			if (sessionSave.version == 2)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public static bool IsInSavedRun()
	{
		return isSavedRun;
	}

	public static bool HasAnySaves()
	{
		bool flag = GetMostRecentSaveStateWithFlag("session", contains: true) != null;
		bool flag2 = GetMostRecentSaveStateWithFlag("disk", contains: true) != null;
		if (CL_GameManager.runHasEnded)
		{
			return false;
		}
		if (isSavedRun && (flag || flag2))
		{
			return true;
		}
		return false;
	}

	public static string GetSessionArea(string gamemode, bool hardmode)
	{
		string text = "";
		if (hardmode)
		{
			text += "-hardmode";
		}
		string fileName = gamemode.ToLower() + text;
		Debug.Log("Getting Session Area");
		SessionSave sessionSave = LoadSessionFromFile(fileName);
		if (sessionSave != null)
		{
			return sessionSave.saveName;
		}
		return "Null";
	}
}
