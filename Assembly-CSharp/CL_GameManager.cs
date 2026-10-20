using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-9)]
public class CL_GameManager : MonoBehaviour
{
	[Serializable]
	public class DeathType
	{
		public string name;

		public string deathText = "Died";

		public TipList tipList;
	}

	[Serializable]
	public class SessionFlag
	{
		public string name;

		public bool state;

		public string data;

		public void SetState(bool b)
		{
			state = b;
		}
	}

	[Serializable]
	public class ReplaceInfo
	{
		public string[] entityReplaceTags;

		public string[] entityIgnoreTags;

		public GameEntity replacementPrefab;

		public bool replaceOnEnable;

		public float replaceChance;

		public bool disableOnReplace;

		public HashSet<GameEntity> spawnedEntities = new HashSet<GameEntity>();

		public bool ShouldReplace(GameEntity entity, bool useRandom)
		{
			int num = LayerMask.NameToLayer("Inventory");
			if (true && gMan.noReplaceCount == 0 && entity != null && !entity.GetTagger().HasTag("Replaced") && entity.GetTagger().HasTagInList(entityReplaceTags) && !entity.GetTagger().HasTagInList(entityIgnoreTags) && !spawnedEntities.Contains(entity) && entity.gameObject.layer != num)
			{
				if (!useRandom)
				{
					return replaceChance >= 1f;
				}
				return UnityEngine.Random.value < replaceChance;
			}
			return false;
		}

		public GameEntity Replace(GameEntity entity)
		{
			GameEntity gameEntity = entity.ReplaceWith(replacementPrefab, disableOnReplace);
			if (gameEntity != null)
			{
				gameEntity.GetTagger().AddTag("Replaced");
				spawnedEntities.Add(gameEntity);
			}
			return gameEntity;
		}
	}

	[Serializable]
	public class RichPresencePair
	{
		public string key;

		public string value;
	}

	public struct RichPresenceMarker
	{
		internal int version;
	}

	[Header("Managers")]
	public static CL_GameManager gMan;

	public FXManager fxMan;

	public StatManager statManager;

	public CL_ProgressionManager progressionManager;

	public ENT_Player localPlayer;

	public Transform playerSpawn;

	private Transform playerTransform;

	public CL_UIManager uiMan;

	public float tickRate = 15f;

	[Header("Map Info")]
	public CL_CameraControl levelCam;

	public float gravity = -9f;

	[Header("Pause Vars")]
	public bool isPaused;

	public bool canPause;

	[Header("GUI Win & Death")]
	public GameObject pauseMenu;

	public GameObject settingsMenu;

	public GameObject loadScreen;

	public List<DeathType> deathTypes;

	public static DeathType curDeathType;

	public TipList generalTips;

	[Header("Audio")]
	public AudioManager audMan;

	public bool lockPlayer;

	public bool freecam;

	public bool lockPlayerInput;

	private float loadTimer = 0.5f;

	private static bool dead = false;

	internal bool reviving;

	public List<GameEntity> gameEntityPrefabs;

	private Dictionary<string, GameEntity> entityPrefabDictionary;

	private readonly Dictionary<Type, object> perRunData = new Dictionary<Type, object>();

	public static string gameType = "campaign";

	public static bool safeExit = false;

	public static bool runHasEnded = false;

	public static bool hasReportedVersion = false;

	private float currentWorldOffset;

	private float playerAscent;

	private float ascentRate;

	private float playerLastTravelDistance;

	private float bestPlayerTravelDistance;

	private float currentBestPlayerTravelDistance;

	private float playerTravelSpeed;

	private Vector3 lastPlayerDistanceCheckPosition;

	private float playerCheckDistance;

	private float checkpointSpacewarp = 1f;

	private float gameTime;

	private bool runTimer = true;

	public AudioClip highScoreClip;

	private float previousHighScore;

	private bool achievedHighScore;

	private float highScoreCooldown;

	public static bool noTarget = false;

	public bool allowScores;

	private bool isSafe;

	public static M_Gamemode gamemode;

	public M_Gamemode defaultGamemode;

	internal M_Gamemode baseGamemode;

	public List<SessionFlag> sessionFlags = new List<SessionFlag>();

	public readonly List<Action<GameEntity>> gameEntityOnEnable = new List<Action<GameEntity>>();

	public readonly List<Action<GameEntity>> gameEntityOnStart = new List<Action<GameEntity>>();

	public int noReplaceCount;

	public readonly List<ReplaceInfo> replacementScopes = new List<ReplaceInfo>();

	private Dictionary<string, SessionFlag> sessionFlagDict = new Dictionary<string, SessionFlag>();

	public static List<SessionFlag> presessionFlags;

	[HideInInspector]
	public RichPresenceMarker richPresenceBase;

	public static int runRoaches = 0;

	public static int globalRoaches = 0;

	public static float currentDifficulty = 0f;

	private static bool m_showCursor = true;

	public static uint fixedFrameCounter;

	private bool loading;

	private static List<string> gamemodeArgs = new List<string>();

	private static string startupCommand = "";

	private int richPresenceLast;

	private static float timeScale = 1f;

	private static float timeScaleMult = 1f;

	private static float tempTimeScaleMult = 1f;

	private static float playerPerceivedTimeScale = 1f;

	private Coroutine freezeFrameCoroutine;

	public static Action _onPlayerDeath;

	private static int richPresenceUniqueInt = 0;

	private static int richPresenceVersion = 0;

	private static long richPresenceClearUnixTime = 0L;

	private static List<(int version, Dictionary<string, string> richPre)> richPresenceContextStack = new List<(int, Dictionary<string, string>)>();

	private static Dictionary<string, string> richPresenceMap;

	public static bool showCursor
	{
		get
		{
			return m_showCursor;
		}
		set
		{
			m_showCursor = value;
			InputManager.UpdateCursorVisibility();
		}
	}

	public static void BeginNoReplaceScope()
	{
		if (gMan != null)
		{
			gMan.noReplaceCount++;
		}
	}

	public static void EndNoReplaceScope()
	{
		if (gMan != null)
		{
			gMan.noReplaceCount--;
		}
	}

	private void Awake()
	{
		RichPresenceClear();
		richPresenceBase = RichPresencePush();
		if (!hasReportedVersion)
		{
			hasReportedVersion = true;
			Debug.Log("Game Version: " + DarkMachineFunctions.GetVersionName(""));
		}
		if ((bool)localPlayer)
		{
			playerTransform = localPlayer.transform;
		}
		string command;
		if (startupCommand != "")
		{
			command = "delay; " + startupCommand;
			StartCoroutine(WaitOneFrame());
		}
		InitializeGlobals();
		CommandConsole.Log("<color=yellow>Game Manager Started.</color>");
		CommandConsole.Log("---");
		CommandConsole.Log("<color=red>CURRENT GAMEMODE: " + gamemode?.ToString() + "</color>");
		if (IsHardmode())
		{
			currentDifficulty += 1f;
		}
		IEnumerator WaitOneFrame()
		{
			yield return null;
			CommandConsole.instance.ExecuteCommand(command, recordHistory: false);
		}
	}

	private void InitializeGlobals()
	{
		gMan = this;
		dead = false;
		noTarget = false;
		runHasEnded = false;
		if (gamemode == null)
		{
			baseGamemode = defaultGamemode;
			gamemode = defaultGamemode;
		}
		else
		{
			baseGamemode = gamemode;
		}
		runRoaches = 0;
		ResetTimescale();
		CommandConsole.hasCheated = false;
		CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
		CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
		UT_AccessoryRenderer.accessoryRenderers = new Dictionary<string, List<UT_AccessoryRenderer>>();
		CL_AssetManager.InitializeAssetManager();
		CL_AssetManager.UnloadAllLevels();
		CL_ScoreManager.Initialize();
		CL_CosmeticManager.Initialize();
		CL_CustomRadioLoader.LoadCustomStations();
		ENV_RadioStation.ResetStations();
		OS_Manager.inUse = false;
		SpeedrunManager.Initialize();
		Steering.Initialize();
		if (progressionManager != null)
		{
			progressionManager.Initialize();
		}
		GrabSavedRoaches();
		baseGamemode.Initialize(gamemodeArgs.ToArray());
		if (WorldLoader.instance != null && WorldLoader.instance.enabled)
		{
			WorldLoader.instance.Initialize();
		}
		gamemodeArgs.Clear();
		startupCommand = "";
		Application.targetFrameRate = SettingsManager.settings.targetFramerate;
		fixedFrameCounter = 0u;
	}

	private void Start()
	{
		RichPresenceSet(richPresenceBase, "modifier", " ");
		string value = "(0.0km)";
		if (GetBaseGamemode().HasTag("hideascenttracker"))
		{
			value = " ";
		}
		RichPresenceSet(richPresenceBase, "distance", value);
		string value2 = "none";
		if (IsIronKnuckle() && IsHardmode())
		{
			value2 = "ikhm";
		}
		if (GetBaseGamemode().HasActiveSetting("unlimited") && IsHardmode())
		{
			value2 = "hm_unlimited";
		}
		else if (IsIronKnuckle())
		{
			value2 = "ik";
		}
		else if (IsHardmode())
		{
			value2 = "hm";
		}
		else if (GetBaseGamemode().HasActiveSetting("unlimited"))
		{
			value2 = "unlimited";
		}
		else if (GetCurrentGamemode().IsCompetitive())
		{
			value2 = "comp";
		}
		RichPresenceSet(richPresenceBase, "gamemode_modifiers", value2);
		foreach (RichPresencePair richPresenceDefaultValue in gamemode.richPresenceDefaultValues)
		{
			RichPresenceSet(richPresenceBase, richPresenceDefaultValue.key, richPresenceDefaultValue.value);
		}
		if ((bool)localPlayer)
		{
			StartCoroutine(LoadIn());
			previousHighScore = 0f;
			try
			{
				if (gamemode == null)
				{
					previousHighScore = (float)StatManager.saveData.gameStats.GetStatistic("score").GetValue();
				}
				else
				{
					previousHighScore = (float)StatManager.saveData.GetGameMode(GetGamemodeName()).stats.GetStatistic("score").GetValue();
				}
			}
			catch
			{
			}
			entityPrefabDictionary = new Dictionary<string, GameEntity>();
			foreach (GameEntity gameEntityPrefab in gameEntityPrefabs)
			{
				if (!(gameEntityPrefab == null) && !entityPrefabDictionary.ContainsKey(gameEntityPrefab.name.ToLower()))
				{
					entityPrefabDictionary.Add(gameEntityPrefab.name.ToLower(), gameEntityPrefab);
				}
			}
			InitializeCommands();
			AudioListener.pause = false;
			uiMan.crosshairController.SetCrosshairFocus(state: false, instant: true);
			SetPlayerDistanceCheckPosition(localPlayer.transform.position, 1f);
			StatManager.sessionStats.UpdateStatistic("runs", 1, StatManager.Statistic.DataType.Int);
			StatManager.sessionStats.UpdateStatistic("player-ascent", 0f, StatManager.Statistic.DataType.Float, StatManager.Statistic.DisplayType.Meters);
			StatManager.sessionStats.UpdateStatistic("travel-distance", 0f, StatManager.Statistic.DataType.Float, StatManager.Statistic.DisplayType.Meters);
		}
		if (StatManager.saveData != null)
		{
			if (StatManager.saveData.flags == null)
			{
				StatManager.saveData.flags = new List<StatManager.SaveData.SaveFlags>();
			}
			foreach (StatManager.SaveData.SaveFlags flag in StatManager.saveData.flags)
			{
				SessionFlag item = new SessionFlag
				{
					name = flag.name,
					state = flag.value,
					data = flag.data
				};
				sessionFlags.Add(item);
			}
			RebuildSessionFlagDictionary();
			SetupFlags();
		}
		baseGamemode.StartFreshGamemode();
		RebuildSessionFlagDictionary();
		if (presessionFlags != null)
		{
			foreach (SessionFlag presessionFlag in presessionFlags)
			{
				Debug.Log("Activating Presession Flag: " + presessionFlag.name + " :: " + presessionFlag.state);
				SetGameFlag(presessionFlag.name, presessionFlag.state, presessionFlag.data);
			}
			presessionFlags = new List<SessionFlag>();
		}
		if (HasActiveFlag("jackkill", useUnlockAll: true))
		{
			CommandConsole.BuildCommand("punishme", SpawnJack).Description("[strength]: I need to be hit.");
		}
		AudioSource component = GetComponent<AudioSource>();
		if (component != null)
		{
			if (GetCurrentGamemode() != null && GetCurrentGamemode().startSound != null)
			{
				component.clip = GetCurrentGamemode().startSound;
				component.volume = GetCurrentGamemode().startSoundVolume;
			}
			component.Play();
		}
	}

	private void OnEnable()
	{
		gMan = this;
	}

	private void OnDisable()
	{
		isPaused = false;
		showCursor = true;
	}

	private IEnumerator LoadIn()
	{
		isPaused = true;
		SetTimescale(0f);
		SetLoading(b: true);
		uiMan.SetFadeAmount(1f);
		showCursor = false;
		yield return new WaitForSecondsRealtime(loadTimer);
		if (WorldLoader.instance != null && WorldLoader.instance.gameObject.activeInHierarchy && WorldLoader.instance.enabled && !WorldLoader.instance.isDebugWorld)
		{
			Debug.Log("Worldloader Instance Found. Waiting to Initialize..");
			while (!WorldLoader.isLoaded)
			{
				yield return null;
			}
		}
		else
		{
			yield return new WaitForSecondsRealtime(0.2f);
			SetTimescale(1f);
			SetLoading(b: false);
		}
		if (GetBaseGamemode().IsCompetitive() && SettingsManager.settings != null && SettingsManager.settings.competitiveSettings != null && SettingsManager.settings.competitiveSettings.lockerItems != null && SettingsManager.settings.competitiveSettings.lockerItems.Count > 0)
		{
			for (int i = 0; i < SettingsManager.settings.competitiveSettings.lockerItems.Count; i++)
			{
				Item_Object itemObjectPrefab = CL_AssetManager.GetItemObjectPrefab(SettingsManager.settings.competitiveSettings.lockerItems[i]);
				if (itemObjectPrefab != null && !itemObjectPrefab.itemData.HasTag("contraband"))
				{
					string data = SettingsManager.settings.competitiveSettings.lockerItems[i];
					SetGameFlag("equiplocker-" + GetBaseGamemode().GetGamemodeName() + "local" + (i + 1), state: true, data);
				}
				else
				{
					SetGameFlag("equiplocker-" + GetBaseGamemode().GetGamemodeName() + "local" + (i + 1), state: false);
				}
			}
		}
		uiMan.FadeIn();
		yield return new WaitForSecondsRealtime(1.5f);
		if (gamemode == null)
		{
			uiMan.header.ShowText("ASCEND");
		}
		else if (!CL_SaveManager.IsInSavedRun())
		{
			if (IsHardmode())
			{
				uiMan.header.ShowText("<color=red>" + gamemode.introText);
			}
			else
			{
				uiMan.header.ShowText(gamemode.introText);
			}
		}
		if (!GetBaseGamemode().forceStartingRoaches && GetRoaches(global: true) > 0 && GetBaseGamemode().roachBankID == "campaign" && !CL_SaveManager.IsInSavedRun() && !IsIronKnuckle())
		{
			Debug.Log($"GAMEMANAGER - Pulling Starting Roaches: Global Bank = {GetRoaches(global: true)} : roachbankid = {GetBaseGamemode().roachBankID} : Is In Saved Run: {CL_SaveManager.IsInSavedRun()}");
			if (StatManager.saveData.GetFacility("GLOBAL").HasUpgrade("UPG_Global_StartingRoaches_T3"))
			{
				int num = WithdrawRoachesFromGlobalBank(20);
				Debug.Log("GAMEMANAGER - Pulling 20 roaches from global bank.");
				UI_RoachBankPopup.ShowRoachChangePopup(num, -num, 0, GetRoaches(global: true) + num);
			}
			else if (StatManager.saveData.GetFacility("GLOBAL").HasUpgrade("UPG_Global_StartingRoaches_T2"))
			{
				int num2 = WithdrawRoachesFromGlobalBank(15);
				Debug.Log("GAMEMANAGER - Pulling 15 roaches from global bank.");
				UI_RoachBankPopup.ShowRoachChangePopup(num2, -num2, 0, GetRoaches(global: true) + num2);
			}
			else if (StatManager.saveData.GetFacility("GLOBAL").HasUpgrade("UPG_Global_StartingRoaches_T1"))
			{
				int num3 = WithdrawRoachesFromGlobalBank(10);
				Debug.Log("GAMEMANAGER - Pulling 10 roaches from global bank.");
				UI_RoachBankPopup.ShowRoachChangePopup(num3, -num3, 0, GetRoaches(global: true) + num3);
			}
			else
			{
				int num4 = WithdrawRoachesFromGlobalBank(5);
				Debug.Log("GAMEMANAGER - Pulling 5 roaches from global bank.");
				UI_RoachBankPopup.ShowRoachChangePopup(num4, -num4, 0, GetRoaches(global: true) + num4);
			}
		}
		else
		{
			Debug.Log($"GAMEMANAGER - Standard starting roaches not pulled: Global Bank = {GetRoaches(global: true)} : roachbankid = {GetBaseGamemode().roachBankID} : Is In Saved Run: {CL_SaveManager.IsInSavedRun()}");
		}
	}

	private void Update()
	{
		RefreshTimescale();
		if (!Application.isFocused)
		{
			if (!SettingsManager.settings.vsync)
			{
				Application.targetFrameRate = 25;
			}
			if (SettingsManager.settings.muteWhenNotFocused)
			{
				AudioListener.volume = 0f;
			}
		}
		else
		{
			if (!SettingsManager.settings.vsync)
			{
				Application.targetFrameRate = SettingsManager.GetTargetFramerate();
			}
			AudioListener.volume = (float)SettingsManager.settings.masterVolume;
		}
		if (loadTimer > 0f)
		{
			loadTimer -= Time.deltaTime;
			return;
		}
		if (canPause && !OS_Manager.inUse && !loading && !reviving && InputManager.GetButton("Pause").Down && !isPaused)
		{
			Pause();
		}
		if (CL_UIManager.debug)
		{
			DebugMenu.UpdateDebugText("player-experience", "<color=yellow>Player Experience: " + CL_ProgressionManager.playerExperience);
			DebugMenu.UpdateDebugText("gametimer", "Game Timer: " + Math.Round(gameTime, 1) + " :: Real Time: " + Math.Round(Time.unscaledDeltaTime, 1) + " :: Current Warp: " + checkpointSpacewarp);
		}
		if (richPresenceLast != RichPresenceVersion())
		{
			richPresenceLast = RichPresenceVersion();
			string text = RichPresenceStringifyEn(RichPresencePeek());
			DebugMenu.UpdateDebugText("richpresence", "Rich Presence: " + text);
		}
		GameEntity.GameEntityListGc();
		if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && Input.GetKeyDown(KeyCode.F12))
		{
			Screenshot.TakeScreenshot(3);
		}
		if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Semicolon))
		{
			RestartScene();
		}
		if (dead)
		{
			SetTimescale(Mathf.Lerp(timeScale, 0f, Time.unscaledDeltaTime * 1f));
			return;
		}
		float num = GetPlayerBestTravelDistance() * playerTravelSpeed;
		if (uiMan != null && uiMan.scoreTracker != null)
		{
			uiMan.scoreTracker.text = $"Score: {Mathf.RoundToInt(num)}";
			uiMan.ascentTracker.text = $"Climb Distance: {Math.Round(GetPlayerBestTravelDistance(), 2)}";
			uiMan.ascentRateTracker.text = $"Climb Speed: {Math.Round(playerTravelSpeed, 2)}";
			if (previousHighScore > num)
			{
				uiMan.highScoreTracker.text = $"High Score: {Mathf.RoundToInt(previousHighScore)}";
			}
			else
			{
				uiMan.highScoreTracker.text = $"High Score: {Mathf.RoundToInt(num)}";
			}
		}
		if (isPaused || loading)
		{
			return;
		}
		if (allowScores)
		{
			float playerCorrectedHeight = GetPlayerCorrectedHeight();
			if (playerCorrectedHeight > playerAscent)
			{
				playerAscent = GetPlayerCorrectedHeight();
				StatManager.sessionStats.UpdateStatistic("player-ascent", playerAscent, StatManager.Statistic.DataType.Float, StatManager.Statistic.DisplayType.Meters);
			}
			if (WorldLoader.IsInNewLevel())
			{
				playerCheckDistance = Mathf.Max(GetPlayerDistanceFromCheck(), playerCheckDistance);
			}
			if (GetPlayerTravelDistance() > bestPlayerTravelDistance)
			{
				bestPlayerTravelDistance = GetPlayerTravelDistance();
				StatManager.sessionStats.UpdateStatistic("travel-distance", bestPlayerTravelDistance, StatManager.Statistic.DataType.Float, StatManager.Statistic.DisplayType.Meters);
			}
			playerCheckDistance = GetPlayerDistanceFromCheck();
			if (!GetBaseGamemode().HasTag("hideascenttracker"))
			{
				if (highScoreCooldown <= 0f && num > previousHighScore && !achievedHighScore && previousHighScore > 50f && playerCorrectedHeight > 50f)
				{
					achievedHighScore = true;
					AudioManager.PlaySound(highScoreClip, base.transform.position, 0.5f, 1f, 0f);
					uiMan.highscoreHeader.ShowText("BEST CLIMB - " + Mathf.Round(bestPlayerTravelDistance) + " METERS AT " + Math.Round(playerTravelSpeed, 2) + "M/S");
					highScoreCooldown = 5f;
				}
				if (highScoreCooldown > 0f)
				{
					highScoreCooldown -= Time.deltaTime;
				}
			}
			StatManager.sessionStats.UpdateStatistic("ascent-rate", ascentRate, StatManager.Statistic.DataType.Float, StatManager.Statistic.ModType.Set, StatManager.Statistic.DisplayType.Speed, StatManager.Statistic.ModType.Max);
			StatManager.sessionStats.UpdateStatistic("travel-speed", playerTravelSpeed, StatManager.Statistic.DataType.Float, StatManager.Statistic.ModType.Set, StatManager.Statistic.DisplayType.Speed, StatManager.Statistic.ModType.Max);
			StatManager.sessionStats.UpdateStatistic("game-time", gameTime, StatManager.Statistic.DataType.Float, StatManager.Statistic.ModType.Set, StatManager.Statistic.DisplayType.Time);
			DebugMenu.UpdateDebugText("ascentRate", "Travel Speed: " + playerTravelSpeed);
		}
		gameTime += Time.deltaTime * checkpointSpacewarp;
		if (runTimer)
		{
			ascentRate = playerAscent / gameTime;
			playerTravelSpeed = bestPlayerTravelDistance / gameTime;
		}
	}

	private void OnDestroy()
	{
		CommandConsole.Log("<color=grey>Game Manager Unloaded.</color>\n");
	}

	private void FixedUpdate()
	{
		fixedFrameCounter++;
	}

	public void UnPause()
	{
		if (!dead)
		{
			Cursor.lockState = CursorLockMode.Locked;
			showCursor = false;
			SetTimescale(1f);
			isPaused = false;
		}
		pauseMenu.SetActive(value: false);
		AudioListener.pause = false;
		CommandConsole.HideConsole();
	}

	public void Pause()
	{
		Cursor.lockState = CursorLockMode.None;
		showCursor = true;
		pauseMenu.SetActive(value: true);
		isPaused = true;
		AudioListener.pause = true;
		SetTimescale(0f);
	}

	public void SetGamemode(M_Gamemode mode)
	{
		Debug.Log("Gamemode Set to " + mode);
		gamemode.SavePlayerTempInfo(playerAscent, bestPlayerTravelDistance);
		gamemode = mode;
		if (mode.HasSavedPlayerInfo())
		{
			playerAscent = mode.GetSavedPlayerAscent();
			bestPlayerTravelDistance = mode.GetSavedPlayerTravelDistance();
		}
		if (baseGamemode == null || mode.baseGamemode)
		{
			baseGamemode = gamemode;
		}
		foreach (RichPresencePair richPresenceDefaultValue in mode.richPresenceDefaultValues)
		{
			RichPresenceSet(richPresenceBase, richPresenceDefaultValue.key, richPresenceDefaultValue.value);
		}
	}

	public void LoadScene(string l, bool async = false)
	{
		if (async)
		{
			SceneManager.LoadSceneAsync(l);
		}
		else
		{
			SceneManager.LoadScene(l);
		}
	}

	private List<(string name, int count)> PostProcessArgsForCounts(string[] args)
	{
		List<(string, int)> list = new List<(string, int)>();
		for (int i = 0; i < args.Length; i++)
		{
			if (!int.TryParse(args[i], out var _))
			{
				string s = "";
				if (i < args.Length - 1)
				{
					s = args[i + 1];
				}
				if (!int.TryParse(s, out var result2))
				{
					result2 = 1;
				}
				list.Add((args[i], result2));
			}
		}
		return list;
	}

	public void RestartScene()
	{
		dead = false;
		gamemode = baseGamemode;
		CL_SaveManager.isSavedRun = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public static void SetLoading(bool b)
	{
		CL_UIManager.SetLoading(b);
		gMan.loading = b;
		if (b)
		{
			SetTimescale(0f);
			gMan.isPaused = true;
		}
		else
		{
			SetTimescale(1f);
			gMan.isPaused = false;
		}
	}

	internal void RebuildSessionFlagDictionary()
	{
		sessionFlagDict.Clear();
		foreach (SessionFlag sessionFlag in sessionFlags)
		{
			if (!sessionFlagDict.TryAdd(sessionFlag.name, sessionFlag))
			{
				Debug.LogWarning("Flag (" + sessionFlag.name + ") contained multiple times in session flags! Discarding duplicate...");
			}
		}
	}

	public static void SetGameFlag(string name, bool state, string data = "", bool save = false, bool presession = false)
	{
		if (presession)
		{
			if (presessionFlags == null)
			{
				presessionFlags = new List<SessionFlag>();
			}
			bool flag = false;
			foreach (SessionFlag presessionFlag in presessionFlags)
			{
				if (presessionFlag.name == name)
				{
					flag = true;
					presessionFlag.state = state;
					presessionFlag.data = data;
				}
			}
			if (!flag)
			{
				presessionFlags.Add(new SessionFlag
				{
					name = name,
					state = state,
					data = data
				});
			}
		}
		foreach (SessionFlag sessionFlag in gMan.sessionFlags)
		{
			if (sessionFlag.name == name)
			{
				sessionFlag.state = state;
				sessionFlag.data = data;
				if (save)
				{
					StatManager.saveData.SaveFlag(name, state, data);
				}
				return;
			}
		}
		gMan.sessionFlags.Add(new SessionFlag
		{
			name = name,
			state = state,
			data = data
		});
		gMan.sessionFlagDict.Add(name, gMan.sessionFlags[gMan.sessionFlags.Count - 1]);
		if (save)
		{
			StatManager.saveData.SaveFlag(name, state, data);
		}
	}

	public static SessionFlag GetGameFlag(string name)
	{
		if (gMan.sessionFlagDict.TryGetValue(name, out var value))
		{
			return value;
		}
		foreach (StatManager.SaveData.SaveFlags flag in StatManager.saveData.flags)
		{
			if (flag.name == name)
			{
				return new SessionFlag
				{
					name = flag.name,
					state = flag.value,
					data = flag.data
				};
			}
		}
		return null;
	}

	public static bool HasActiveFlag(string name, bool useUnlockAll = false)
	{
		if (string.IsNullOrEmpty(name))
		{
			return false;
		}
		if (gMan.sessionFlagDict.ContainsKey(name))
		{
			return gMan.sessionFlagDict[name].state;
		}
		if (StatManager.saveData == null)
		{
			return false;
		}
		if (StatManager.saveData != null && StatManager.saveData.flags != null)
		{
			foreach (StatManager.SaveData.SaveFlags flag in StatManager.saveData.flags)
			{
				if (flag.name == name)
				{
					return flag.value;
				}
			}
		}
		return false;
	}

	public static void ChangeState(string s)
	{
		CommandConsole.Log("State Change: " + s);
		switch (s)
		{
		case "die":
			gMan.Die();
			break;
		case "win":
			gMan.Win();
			CommandConsole.Log("Game Ended");
			break;
		case "restart":
			gMan.RestartScene();
			break;
		}
	}

	public void SetTargetFramerate(int fps)
	{
		SettingsManager.settings.targetFramerate = fps;
		Application.targetFrameRate = fps;
	}

	public FXManager GetFXManager()
	{
		return fxMan;
	}

	public void TransitionFade(float waitTime)
	{
		StartCoroutine("TransitionCoroutine", waitTime);
	}

	private IEnumerator TransitionCoroutine(float waitTime)
	{
		lockPlayer = true;
		uiMan.FadeOut();
		yield return new WaitForSeconds(waitTime);
		uiMan.FadeIn();
		lockPlayer = false;
	}

	public void SetWorldOffset(float amount)
	{
		if (WorldLoader.initialized)
		{
			WorldLoader.instance.SetOffset(amount);
		}
		if ((UnityEngine.Object)(object)AstarPath.active != null)
		{
			AstarPath.active.Scan();
		}
		GameEntity.OffsetEntities(amount);
		FXManager.fxMan.corruptionHeight = -10000f;
		if (DarkMachineFunctions.offsetAction != null)
		{
			DarkMachineFunctions.offsetAction(amount);
		}
		SetPlayerDistanceCheckPosition(ENT_Player.playerObject.transform.position, 1f);
		currentWorldOffset += amount;
	}

	public void ShakeCam(float amount)
	{
		localPlayer.camRoot.ShakeCamera(amount);
	}

	public float GetGameTime()
	{
		return gameTime;
	}

	public void SetTimerState(bool b)
	{
		runTimer = b;
	}

	public static bool IsLoading()
	{
		return gMan.loading;
	}

	public bool IsReviving()
	{
		return reviving;
	}

	public string GetReleventTip()
	{
		List<TipList> list = new List<TipList>();
		list.Add(generalTips);
		if (curDeathType != null && curDeathType.tipList != null)
		{
			list.Add(curDeathType.tipList);
		}
		if (localPlayer != null && curDeathType != null && localPlayer.GetLastHitSource() != curDeathType.name)
		{
			foreach (DeathType deathType in deathTypes)
			{
				if (localPlayer.GetLastHitSource() == deathType.name && deathType.tipList != null)
				{
					list.Add(deathType.tipList);
					break;
				}
			}
		}
		if (WorldLoader.initialized && WorldLoader.instance.GetCurrentLevel() != null)
		{
			if (WorldLoader.instance.GetCurrentLevel().GetLevel().subRegion != null && WorldLoader.instance.GetCurrentLevel().GetLevel().subRegion.tips != null)
			{
				list.AddRange(WorldLoader.instance.GetCurrentLevel().GetLevel().subRegion.tips);
			}
			if (WorldLoader.instance.GetCurrentLevel().GetLevel().tips != null)
			{
				list.AddRange(WorldLoader.instance.GetCurrentLevel().GetLevel().tips);
			}
		}
		return list[UnityEngine.Random.Range(0, list.Count)].GetTip();
	}

	public static bool IsSafe()
	{
		if (gMan != null && gMan.isSafe && ENT_Player.playerObject != null)
		{
			return true;
		}
		return false;
	}

	public static void SetSafe(bool b)
	{
		if (gMan != null)
		{
			gMan.isSafe = b;
		}
		if (gMan.isSafe)
		{
			CL_UIManager.instance.safeAreaText.Show();
		}
		else
		{
			CL_UIManager.instance.safeAreaText.Hide();
		}
	}

	public static bool IsInGame()
	{
		if (gMan == null)
		{
			return false;
		}
		return gMan.localPlayer != null;
	}

	public static string GetGamemodeName(bool includeOptions = true, bool mainMode = false)
	{
		string gamemodeName = gamemode.GetGamemodeName(includeOptions);
		if (mainMode)
		{
			gamemodeName = gMan.baseGamemode.GetGamemodeName(includeOptions);
			Debug.Log("Getting the main mode: " + gamemodeName);
		}
		return gamemodeName;
	}

	public static M_Gamemode GetCurrentGamemode()
	{
		return gamemode;
	}

	public static M_Gamemode GetBaseGamemode()
	{
		return gMan.baseGamemode;
	}

	public static bool IsHardmode()
	{
		if (GetBaseGamemode() == null)
		{
			return false;
		}
		return GetBaseGamemode().IsHardMode();
	}

	public static bool IsIronKnuckle()
	{
		if (GetBaseGamemode() == null)
		{
			return false;
		}
		return GetBaseGamemode().IsIronKnuckle();
	}

	public static bool AreAchievementsAllowed()
	{
		if (gamemode != null && gamemode.allowAchievements && gMan.baseGamemode.allowAchievements)
		{
			return true;
		}
		return false;
	}

	internal void SetGameTime(float f)
	{
		gameTime = f;
	}

	public static void ResetTimescale()
	{
		timeScale = 1f;
		timeScaleMult = 1f;
		tempTimeScaleMult = 1f;
		playerPerceivedTimeScale = 1f;
	}

	public static void SetTimescale(float m)
	{
		timeScale = m;
		RefreshTimescale();
	}

	public static float GetBaseTimescale()
	{
		return timeScale;
	}

	public static void SetTimescaleMult(float mult)
	{
		timeScaleMult = mult;
		RefreshTimescale();
	}

	public static void RefreshTimescale()
	{
		float num = timeScale * timeScaleMult * tempTimeScaleMult;
		float num2 = 1f;
		if (ENT_Player.GetPlayer() != null)
		{
			num2 = ENT_Player.GetPlayer().GetCurrentSlowTimeMult();
			num *= num2;
		}
		Time.timeScale = num;
		playerPerceivedTimeScale = 1f / num2;
	}

	public static float GetPlayerPerceivedDeltaTime()
	{
		float num = Time.deltaTime * playerPerceivedTimeScale;
		if (!float.IsFinite(num))
		{
			num = Time.deltaTime;
		}
		return num;
	}

	public void FreezeForTime(float seconds = 0.1f, float scale = 0f)
	{
		if (freezeFrameCoroutine != null)
		{
			StopCoroutine(freezeFrameCoroutine);
		}
		freezeFrameCoroutine = StartCoroutine(FreezeFrame());
		IEnumerator FreezeFrame()
		{
			tempTimeScaleMult = scale;
			yield return new WaitForSecondsRealtime(seconds);
			tempTimeScaleMult = 1f;
		}
	}

	private void SetupFlags(bool regenerate = false)
	{
		if (GetGameFlag("sinkcode") == null || string.IsNullOrEmpty(GetGameFlag("sinkcode").data) || regenerate)
		{
			SetGameFlag("sinkcode", state: true, UnityEngine.Random.Range(1000, 9999).ToString(), save: true);
		}
		if (GetGameFlag("chutecode") == null || string.IsNullOrEmpty(GetGameFlag("chutecode").data) || regenerate)
		{
			SetGameFlag("chutecode", state: true, UnityEngine.Random.Range(1000, 9999).ToString(), save: true);
		}
		if (GetGameFlag("diverfrequency") == null || string.IsNullOrEmpty(GetGameFlag("diverfrequency").data) || regenerate)
		{
			SetGameFlag("diverfrequency", state: true, (Mathf.Round(UnityEngine.Random.Range(5f, 20f) * 4f) / 4f).ToString(), save: true);
		}
		if (GetGameFlag("diveramplitude") == null || string.IsNullOrEmpty(GetGameFlag("diveramplitude").data) || regenerate)
		{
			SetGameFlag("diveramplitude", state: true, (Mathf.Round(UnityEngine.Random.Range(-0.95f, 0.95f) * 10f) / 10f).ToString(), save: true);
		}
	}

	public static float GetGametime()
	{
		return gMan.gameTime;
	}

	public static T GetPerRunData<T>() where T : class, new()
	{
		if (gMan == null)
		{
			Debug.LogError("Can't get instance of per run data when gMan is null!");
		}
		T val = null;
		if (gMan.perRunData.TryGetValue(typeof(T), out var value))
		{
			val = (T)value;
		}
		else
		{
			val = new T();
			gMan.perRunData.Add(typeof(T), val);
		}
		return val;
	}

	public static void AddRoaches(int i, bool global = false)
	{
		if (GetBaseGamemode().HasActiveSetting("unlimited"))
		{
			return;
		}
		if (global)
		{
			SetRoaches(Mathf.Clamp(GetRoaches(global: true) + i, 0, 9999), global: true);
		}
		else
		{
			SetRoaches(Mathf.Clamp(GetRoaches() + i, 0, 999));
			if (i > 0)
			{
				StatManager.sessionStats.UpdateStatistic("total-banked-roaches", i, StatManager.Statistic.DataType.Int, StatManager.Statistic.ModType.Add);
			}
		}
		if (!gamemode.IsCompetitive())
		{
			StatManager.GetStatisticInt(StatManager.sessionStats, "total-banked-roaches");
			_ = 0;
			if (!GetBaseGamemode().IsIronKnuckle() && !GetBaseGamemode().IsCompetitive())
			{
				StatManager.sessionStats.UpdateStatistic("bank-roaches", runRoaches, StatManager.Statistic.DataType.Int, StatManager.Statistic.ModType.Set, StatManager.Statistic.DisplayType.Default, StatManager.Statistic.ModType.Set);
			}
		}
	}

	public static int WithdrawRoachesFromGlobalBank(int i)
	{
		if (GetBaseGamemode().HasActiveSetting("unlimited"))
		{
			return 0;
		}
		int num = Mathf.Min(globalRoaches, i);
		globalRoaches -= num;
		runRoaches += num;
		return num;
	}

	public static void MoveRunRoachesIntoBank()
	{
		if (!GetBaseGamemode().HasActiveSetting("unlimited"))
		{
			globalRoaches = Mathf.Clamp(globalRoaches + runRoaches, 0, 9999);
			runRoaches = 0;
		}
	}

	public static int GetRoaches(bool global = false)
	{
		if (GetBaseGamemode().HasActiveSetting("unlimited"))
		{
			if (global)
			{
				return 0;
			}
			return 999;
		}
		if (global)
		{
			return globalRoaches;
		}
		return runRoaches;
	}

	public static int GetCombinedRoaches()
	{
		if (GetBaseGamemode().HasActiveSetting("unlimited"))
		{
			return 0;
		}
		return globalRoaches + runRoaches;
	}

	public static void SetRoaches(int amount, bool global = false)
	{
		if (!GetBaseGamemode().HasActiveSetting("unlimited"))
		{
			if (global)
			{
				amount = Mathf.Clamp(amount, 0, 9999);
				globalRoaches = amount;
			}
			else
			{
				amount = Mathf.Clamp(amount, 0, 999);
				runRoaches = amount;
			}
		}
	}

	private void GrabSavedRoaches()
	{
		if (GetBaseGamemode().HasActiveSetting("unlimited"))
		{
			runRoaches = 999;
			globalRoaches = 0;
		}
		else if (baseGamemode != null)
		{
			int amount = 0;
			if (SettingsManager.settings != null && !IsIronKnuckle() && !gamemode.IsCompetitive() && baseGamemode.saveRoaches)
			{
				amount = StatManager.saveData.GetRoachBankByID(gamemode.roachBankID).value;
			}
			Debug.Log("Pulling roaches: " + amount);
			SetRoaches(amount, global: true);
		}
		else
		{
			Debug.Log("No base gamemode found. Resetting roaches.");
			SetRoaches(0, global: true);
		}
	}

	private void InitializeCommands()
	{
		CommandConsole.BuildCommand("targetframerate", SetTargetFramerate).NotCheat().Description("[target fps]: Set application's target framerate")
			.OverValue(() => Application.targetFrameRate);
		CommandConsole.AddCommand("load", LoadScene);
		CommandConsole.BuildCommand("loadlevels", LoadLevels).Description("[level1 (count=1) level2 (count=1)...] (loop): Spawn a sequence of levels").AutocompleteCustom(delegate(CommandConsole.CommandAutocomplete autocomplete)
		{
			for (int i = 1; i < autocomplete.activeArg - 1; i++)
			{
				if (autocomplete.ArgumentAt(i) == "loop")
				{
					autocomplete.Reject();
					return;
				}
			}
			List<(string, string)> list = new List<(string, string)>();
			if (autocomplete.activeArg > 0)
			{
				list.Add(("loop", "Loop currently selected levels"));
			}
			foreach (M_Level.LevelAssetHolder levelAsset in CL_AssetManager.GetFullCombinedAssetDatabase().levelAssets)
			{
				list.Add((levelAsset.id.ToLower(), null));
			}
			autocomplete.FromArrayWithDesc(list);
		})
			.AutocompleteValidator(delegate(CommandConsole.CommandValidator validator)
			{
				for (int i = 1; i < validator.activeArg - 1; i++)
				{
					if (validator.ArgumentAt(i) == "loop")
					{
						validator.Reject();
						return;
					}
				}
				string text = validator.ArgumentAt(validator.activeArg);
				if (validator.activeArg <= 0 || !(text == "loop"))
				{
					string text2 = validator.ArgumentAt(validator.activeArg - 1);
					bool num = CL_AssetManager.GetLevelAsset(text) != null;
					bool flag = CL_AssetManager.GetLevelAsset(text2) != null;
					if (!num && (!flag || !int.TryParse(text, out var _)))
					{
						validator.Reject();
					}
				}
			});
		CommandConsole.AddCommand("listentityprefabs", ListEntities);
		CommandConsole.AddCommand("listlevels", ListLevels);
		CommandConsole.BuildCommand("spawnentity", SpawnEntity).Description("[entity1 (count=1), entity2 (count=1)...]: Spawn entities at cursor").AutocompleteCustom(delegate(CommandConsole.CommandAutocomplete autocomplete)
		{
			AutocompleteUnlockedItems(autocomplete, gameEntityPrefabs);
		})
			.AutocompleteValidator(delegate(CommandConsole.CommandValidator autocomplete)
			{
				AutocompleteValidateItemFromListWithCount(autocomplete, gameEntityPrefabs);
			});
		CommandConsole.BuildCommand("spawnitem", SpawnItem).Description("[item1 (count=1), item2 (count=1)...]: Spawn items directly in inventory").AutocompleteCustom(delegate(CommandConsole.CommandAutocomplete autocomplete)
		{
			AutocompleteUnlockedItems(autocomplete, CL_AssetManager.GetFullCombinedAssetDatabase().itemPrefabs);
		})
			.AutocompleteValidator(delegate(CommandConsole.CommandValidator autocomplete)
			{
				AutocompleteValidateItemFromListWithCount(autocomplete, CL_AssetManager.GetFullCombinedAssetDatabase().itemPrefabs);
			});
		CommandConsole.BuildCommand("teleportplayertonearestlocator", TeleportPlayerToLocator).Description("[locatorid]: Teleport player to nearest valid active locator.").AutocompleteCustom(delegate(CommandConsole.CommandAutocomplete autocomplete)
		{
			if (autocomplete.activeArg > 0)
			{
				autocomplete.Reject();
			}
			else
			{
				autocomplete.FromArray(UT_Locator.GetListOfAllLocatorGroupNames());
			}
		});
		CommandConsole.BuildCommand("notarget", NoTarget).Description("(enable=toggle): Stop entities from targetting player").OverValue(() => noTarget);
		CommandConsole.BuildCommand("teleportplayer", TeleportPlayer).OverValue(() => localPlayer.transform.position);
		CommandConsole.BuildCommand("setroaches", SetRoaches).Description("[roach count] (where=run): Set roaches for either this run or bank").AutocompleteCustom(delegate(CommandConsole.CommandAutocomplete autocomplete)
		{
			if (autocomplete.activeArg == 0 && !int.TryParse(autocomplete.ArgumentAt(0), out var _))
			{
				autocomplete.Reject();
			}
			if (autocomplete.activeArg == 1)
			{
				autocomplete.FromArray(new string[2] { "run", "bank" });
			}
			if (autocomplete.activeArg > 1)
			{
				autocomplete.Reject();
			}
		})
			.OverValue(() => new int[2] { runRoaches, globalRoaches });
		CommandConsole.AddCommand("listflags", ListFlags);
		CommandConsole.AddCommand("offsetworld", OffsetWorldCommand);
		CommandConsole.BuildCommand("restart", Restart).NotCheat();
		CommandConsole.BuildCommand("timescale", TimescaleCommand).AutocompleteSingeFloat().OverValue(() => timeScaleMult);
		CommandConsole.BuildCommand("loadhandcosmetic", CL_CosmeticManager.LoadHandCosmetic).NotCheat().Description("[cosmetic id] [left/both/right]")
			.AutocompleteCustom(delegate(CommandConsole.CommandAutocomplete autocomplete)
			{
				if (autocomplete.activeArg == 0)
				{
					List<(string, string)> list = new List<(string, string)>();
					foreach (Cosmetic_HandItem cosmeticHand in CL_CosmeticManager.cosmeticHands)
					{
						list.Add((cosmeticHand.cosmeticData.id, cosmeticHand.cosmeticData.cosmeticName));
					}
					autocomplete.FromArrayWithDesc(list);
				}
				else if (autocomplete.activeArg == 1)
				{
					autocomplete.FromArray(new string[3] { "left", "both", "right" });
				}
				else
				{
					autocomplete.Reject();
				}
			});
		CommandConsole.AddCommand("listhandcosmetics", CL_CosmeticManager.ListHandCosmetics, cheat: false);
		CommandConsole.AddCommand("refreshcosmetics", CL_CosmeticManager.RefreshCosmetics, cheat: false);
		CommandConsole.AddCommand("refreshradiostations", CL_CustomRadioLoader.RefreshCustomStations, cheat: false);
		static void AutocompleteUnlockedItems(CommandConsole.CommandAutocomplete autocomplete, IReadOnlyList<UnityEngine.Object> available)
		{
			List<string> list = new List<string>();
			foreach (UnityEngine.Object item in available)
			{
				Item_Object item_Object = null;
				if (item != null)
				{
					item_Object = item.GetComponent<Item_Object>();
				}
				if ((!(item_Object != null) || item_Object.itemData.IsUnlocked()) && item != null)
				{
					list.Add(item.name.ToLower());
				}
			}
			autocomplete.FromArray(list);
		}
		static void AutocompleteValidateItemFromListWithCount(CommandConsole.CommandValidator autocomplete, IReadOnlyList<UnityEngine.Object> available)
		{
			string lastStr = autocomplete.ArgumentAt(autocomplete.activeArg - 1);
			string curStr = autocomplete.ArgumentAt(autocomplete.activeArg);
			UnityEngine.Object obj = available.FirstOrDefault((UnityEngine.Object i) => i != null && i.name.Equals(curStr, StringComparison.OrdinalIgnoreCase));
			Item_Object item_Object = null;
			if (obj != null)
			{
				item_Object = obj.GetComponent<Item_Object>();
			}
			if (item_Object != null && !item_Object.itemData.IsUnlocked())
			{
				item_Object = null;
				obj = null;
			}
			UnityEngine.Object obj2 = available.FirstOrDefault((UnityEngine.Object i) => i != null && i.name.Equals(lastStr, StringComparison.OrdinalIgnoreCase));
			Item_Object item_Object2 = null;
			if (obj2 != null)
			{
				item_Object2 = obj2.GetComponent<Item_Object>();
			}
			if (item_Object2 != null && !item_Object2.itemData.IsUnlocked())
			{
				item_Object2 = null;
				obj2 = null;
			}
			if (!(obj != null) && (!(obj2 != null) || !int.TryParse(curStr, out var _)))
			{
				autocomplete.Reject();
			}
		}
	}

	public void Restart(string[] args)
	{
		string text = CommandConsole.instance.CancelCommandExecution();
		if (text != "")
		{
			startupCommand = text;
		}
		CL_SaveManager.DeleteSessionSave(GetGamemodeName(includeOptions: false, mainMode: true), IsHardmode());
		CL_SaveManager.isSavedRun = false;
		ChangeState("restart");
	}

	public void LoadScene(string[] args)
	{
		SceneManager.LoadScene(args[0]);
	}

	public void LoadLevels(string[] args)
	{
		if (args.Length == 0)
		{
			CommandConsole.Log("Error: Incorrect Formatting. Use level names as arguments, one for each level.");
			return;
		}
		bool flag = false;
		for (int i = 0; i < args.Length; i++)
		{
			if (CL_AssetManager.GetLevelAsset(args[i]) != null)
			{
				flag = true;
			}
		}
		if (!flag)
		{
			CommandConsole.Log("Error: None of the listed levels exist.");
			return;
		}
		List<(string name, int count)> list = PostProcessArgsForCounts(args);
		List<string> list2 = new List<string>();
		foreach (var item3 in list)
		{
			string item = item3.name;
			int item2 = item3.count;
			for (int j = 0; j < item2; j++)
			{
				list2.Add(item);
			}
		}
		gamemodeArgs.AddRange(list2);
		string text = CommandConsole.instance.CancelCommandExecution();
		if (text != "")
		{
			startupCommand = text;
		}
		M_Gamemode gamemodeAsset = CL_AssetManager.GetGamemodeAsset("GM_Level_Tester");
		SetGamemode(gamemodeAsset);
		baseGamemode = gamemodeAsset;
		SceneManager.LoadScene("Game-Main");
	}

	public void ListLevels(string[] args)
	{
		foreach (M_Level.LevelAssetHolder levelAsset in CL_AssetManager.GetFullCombinedAssetDatabase().levelAssets)
		{
			M_Level level = levelAsset.GetLevel();
			if (!(level != null) || level.showInLevelList)
			{
				CommandConsole.Log("Level : " + levelAsset.id.ToLower());
			}
		}
	}

	public void NoTarget(string[] args)
	{
		if (args.Length == 0)
		{
			noTarget = !noTarget;
		}
		else if (!bool.TryParse(args[0], out noTarget))
		{
			CommandConsole.Log("Unable to parse " + args[0] + " arg needs to be a boolean (true/false/0/1).");
			return;
		}
		CommandConsole.Log("Notarget set to " + noTarget);
	}

	private void ListFlags(string[] obj)
	{
		foreach (SessionFlag sessionFlag in sessionFlags)
		{
			CommandConsole.Log($"Flag: {sessionFlag.name} -- {sessionFlag.state}");
		}
	}

	public void ListEntities(string[] args)
	{
		foreach (GameEntity gameEntityPrefab in gameEntityPrefabs)
		{
			Item_Object component = gameEntityPrefab.GetComponent<Item_Object>();
			if (!(component != null) || component.itemData.IsUnlocked())
			{
				CommandConsole.Log("Game Entity : " + gameEntityPrefab.name.ToLower());
			}
		}
	}

	public void SpawnEntity(string[] args)
	{
		if (args.Length == 0)
		{
			CommandConsole.Log("Entity Must Have Name.");
			return;
		}
		foreach (var (text, num) in PostProcessArgsForCounts(args))
		{
			if (!entityPrefabDictionary.TryGetValue(text.ToLower(), out var value))
			{
				CommandConsole.Log("No entity with the name '" + text + "' exists.");
				continue;
			}
			for (int i = 0; i < num; i++)
			{
				Vector3 position = Camera.main.transform.position + Camera.main.transform.forward;
				Quaternion identity = Quaternion.identity;
				if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out var hitInfo, float.PositiveInfinity))
				{
					position = hitInfo.point;
					identity = Quaternion.LookRotation(hitInfo.normal);
					GameEntity gameEntity = UnityEngine.Object.Instantiate(value, position, identity);
					if (gameEntity.spawnWithBounds)
					{
						Collider component = gameEntity.GetComponent<Collider>();
						if (component != null)
						{
							Bounds bounds = component.bounds;
							Vector3 vector = hitInfo.normal * bounds.extents.magnitude;
							gameEntity.transform.position += vector;
						}
					}
				}
				else
				{
					UnityEngine.Object.Instantiate(value, position, identity);
				}
			}
		}
	}

	public void SpawnItem(string[] args)
	{
		if (ENT_Player.GetPlayer() == null)
		{
			CommandConsole.Log("No player found to give items to.");
			return;
		}
		if (args.Length == 0)
		{
			CommandConsole.Log("Item Must Have Name.");
			return;
		}
		List<(string, int)> list = PostProcessArgsForCounts(args);
		List<GameObject> itemPrefabs = CL_AssetManager.GetFullCombinedAssetDatabase().itemPrefabs;
		for (int i = 0; i < list.Count; i++)
		{
			string item = list[i].Item1;
			int item2 = list[i].Item2;
			GameObject gameObject = null;
			foreach (GameObject item3 in itemPrefabs)
			{
				if (item3.name.Equals(item, StringComparison.OrdinalIgnoreCase))
				{
					gameObject = item3;
					break;
				}
			}
			if (gameObject == null)
			{
				CommandConsole.Log("Could not find item named " + item);
				continue;
			}
			Item_Object component = gameObject.GetComponent<Item_Object>();
			if (component == null)
			{
				CommandConsole.Log("Item named " + item + " does not contain Item_Object!");
				continue;
			}
			for (int j = 0; j < item2; j++)
			{
				Inventory.instance.AddItemToInventoryScreen(new Vector3(0f, 0f, 1f) + UnityEngine.Random.insideUnitSphere * 0.01f, component.itemData.GetClone(), localSpacePosition: true, useStoredValues: false, i == list.Count - 1 && j == item2 - 1);
			}
		}
	}

	public void SpawnJack(string[] args)
	{
		if (args.Length == 0 || args[0] == "")
		{
			CommandConsole.Log("Incorrect Format, include difficulty:\n<color=green>0 (EASY)</color>, 1 (NORMAL), <color=yellow>2 (HARD)</color>, <color=red>3 (NIGHTMARE)</color>. \nExample: punishme 3");
			return;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(CL_AssetManager.GetAssetGameObject("DEN_Jack"), ENT_Player.playerObject.transform.position + Vector3.up * -40f, Quaternion.identity);
		int num = int.Parse(args[0]);
		DEN_SimpleChaseKiller component = gameObject.GetComponent<DEN_SimpleChaseKiller>();
		if (num < 5)
		{
			switch (num)
			{
			case 0:
				component.speedIncreaseRate = 0f;
				component.speed = 3f;
				CommandConsole.Log("Jack Difficulty: <color=green>EASY</color>");
				break;
			case 1:
				component.speedIncreaseRate = 0.005f;
				component.speed = 5f;
				CommandConsole.Log("Jack Difficulty: MEDIUM");
				break;
			case 2:
				component.speedIncreaseRate = 0.01f;
				component.speed = 7f;
				CommandConsole.Log("Jack Difficulty: <color=yellow>HARD</color>");
				break;
			case 3:
				component.speedIncreaseRate = 0.03f;
				component.speed = 7f;
				component.ignoreCollisions = true;
				CommandConsole.Log("Jack Difficulty: <color=red>NIGHTMARE</color>");
				break;
			case 4:
				component.speedIncreaseRate = 0.06f;
				component.speed = 10f;
				component.ignoreCollisions = true;
				CommandConsole.Log("Jack <color=purple>SECRET</color> Difficulty: <color=purple>ULTRA-NIGHTMARE</color>\n<color=red>Good Luck. You will need it.</color>");
				break;
			}
			CommandConsole.Log("<color=grey>Spawned the little freaky guy.</color> <color=red>Run.</color>");
		}
		else
		{
			UnityEngine.Object.Destroy(gameObject);
			CommandConsole.Log("<color=purple>NO. WHY.</color> Go seek help. Please.");
		}
	}

	public void SetTargetFramerate(string[] args)
	{
		if (args.Length == 0)
		{
			CommandConsole.Log("Current Framerate is " + Application.targetFrameRate);
			return;
		}
		int result = Application.targetFrameRate;
		if (int.TryParse(args[0], out result))
		{
			Application.targetFrameRate = result;
		}
		else
		{
			CommandConsole.Log("Error: Framerate needs to be an integer");
		}
	}

	public void SetRoaches(string[] args)
	{
		if (args.Length < 1)
		{
			CommandConsole.Log("Error: Incorrect Formatting. Use setroaches X");
			return;
		}
		int num = int.Parse(args[0]);
		bool flag = true;
		if (args.Length >= 2 && args[1] == "bank")
		{
			flag = false;
		}
		if (flag)
		{
			runRoaches = num;
		}
		else
		{
			globalRoaches = num;
		}
	}

	public void TeleportPlayerToLocator(string[] args)
	{
		if (args == null || args.Length == 0)
		{
			CommandConsole.LogError("ERROR: ID Missing.");
			return;
		}
		UT_Locator closestLocatorInGroupToPosition = UT_Locator.GetClosestLocatorInGroupToPosition(args[0], ENT_Player.GetPlayer().transform.position, 0f, 0f, onlyActive: false);
		if (closestLocatorInGroupToPosition == null)
		{
			CommandConsole.LogError("ERROR: No locator of ID " + args[0] + " found.");
		}
		else
		{
			ENT_Player.GetPlayer().Teleport(closestLocatorInGroupToPosition.transform.position);
		}
	}

	private void OffsetWorldCommand(string[] args)
	{
		if (args.Length < 1)
		{
			CommandConsole.Log("Error: Incorrect Formatting. Height Required.");
		}
		else
		{
			SetWorldOffset(float.Parse(args[0]));
		}
	}

	public void TimescaleCommand(string[] args)
	{
		if (args.Length < 1)
		{
			SetTimescaleMult(1f);
		}
		else
		{
			SetTimescaleMult(float.Parse(args[0]));
		}
	}

	public static void GetGameEntitiesAroundPoint(ref List<GameEntity> entityList, float radius)
	{
		Debug.Log("FUCK YOU SHILOH <3");
	}

	public float PlayerDistance(Vector3 location)
	{
		if (localPlayer == null)
		{
			return float.PositiveInfinity;
		}
		return Vector3.Distance(localPlayer.transform.position, location);
	}

	public float PlayerHeightDistance(Vector3 location)
	{
		if (!localPlayer)
		{
			return 0f;
		}
		return Mathf.Abs(localPlayer.transform.position.y - location.y);
	}

	public float GetPlayerHeight()
	{
		if (!localPlayer)
		{
			return 0f;
		}
		return localPlayer.transform.position.y;
	}

	public float GetPlayerCorrectedHeight()
	{
		if (!localPlayer)
		{
			return 0f;
		}
		return localPlayer.transform.position.y - currentWorldOffset;
	}

	public Vector3 GetCorrectedPosition(Vector3 pos)
	{
		return pos - Vector3.up * currentWorldOffset;
	}

	public void SetPlayerDistanceCheckPosition(Vector3 p, float warp)
	{
		lastPlayerDistanceCheckPosition = p;
		playerLastTravelDistance += playerCheckDistance;
		playerCheckDistance = 0f;
		checkpointSpacewarp = warp;
	}

	public void ResetPlayerDistanceCheckPosition(Vector3 p, float setLastTravelDistance, float setCheckDistance, float warp, float bestTravelDistance)
	{
		lastPlayerDistanceCheckPosition = p;
		playerLastTravelDistance = setLastTravelDistance;
		playerCheckDistance = setCheckDistance;
		checkpointSpacewarp = warp;
	}

	public void SetPlayerLastTravelDistance(float f)
	{
		playerLastTravelDistance = f;
	}

	public void SetPlayerBestTravelDistance(float f)
	{
		bestPlayerTravelDistance = f;
	}

	public Vector3 GetPlayerOffsetFromLastCheck()
	{
		return lastPlayerDistanceCheckPosition - localPlayer.transform.position;
	}

	public Vector3 GetPlayerDistanceCheckPosition()
	{
		return lastPlayerDistanceCheckPosition;
	}

	public float GetPlayerDistanceFromCheck()
	{
		return Vector3.Distance(localPlayer.transform.position, lastPlayerDistanceCheckPosition) * checkpointSpacewarp;
	}

	public static float GetPlayerTravelDistance()
	{
		return gMan.playerLastTravelDistance + gMan.playerCheckDistance;
	}

	public static float GetPlayerLastTravelDistance()
	{
		return gMan.playerLastTravelDistance;
	}

	public void TeleportPlayer(Vector3 pos)
	{
		localPlayer.Teleport(pos);
	}

	public void TeleportPlayer(Vector3 pos, Quaternion rot)
	{
		localPlayer.Teleport(pos, rot);
	}

	public void TeleportPlayer(string[] args)
	{
		if (args.Length < 3)
		{
			CommandConsole.Log("Error: Incorrect Formatting. Use teleportplayer x y z.");
		}
		else
		{
			localPlayer.Teleport(new Vector3(float.Parse(args[0]), float.Parse(args[1]), float.Parse(args[2])));
		}
	}

	public float GetPlayerAscent()
	{
		return playerAscent;
	}

	public float GetPlayerBestTravelDistance()
	{
		return bestPlayerTravelDistance;
	}

	public float GetPlayerTravelSpeed()
	{
		return playerTravelSpeed;
	}

	public float GetPlayerAscentRate()
	{
		return ascentRate;
	}

	public void Die(string type = "")
	{
		if (dead)
		{
			return;
		}
		dead = true;
		_onPlayerDeath?.Invoke();
		StatManager.sessionStats.UpdateStatistic("deaths", 1, StatManager.Statistic.DataType.Int, StatManager.Statistic.ModType.Add);
		CL_SaveManager.SaveState save = CL_SaveManager.GetMostRecentSaveStateByType(CL_SaveManager.SaveState.SaveType.disk);
		if (save != null)
		{
			StartCoroutine(ReviveSequence());
			return;
		}
		curDeathType = deathTypes[0];
		string localization = CL_LocalizationManager.GetLocalization("deathmessages", type);
		if (localization == "")
		{
			localization = CL_LocalizationManager.GetLocalization("deathmessages", "basic");
		}
		foreach (DeathType deathType in deathTypes)
		{
			if (type == deathType.name)
			{
				curDeathType = deathType;
			}
		}
		statManager.GetScoreScreen().SetDeathText(localization);
		statManager.GetScoreScreen().SetTip(GetReleventTip());
		StartCoroutine(EndGameSequence());
		localPlayer.KillEffects(type);
		IEnumerator ReviveSequence()
		{
			if (DEN_DeathFloor.instance != null)
			{
				DEN_DeathFloor.instance.StopAllCoroutines();
			}
			CL_EventManager.StopAllEvents();
			reviving = true;
			localPlayer.clipHandler.GetGroup("player").GetSet("death").Play(1f);
			SetTimescale(0.1f);
			uiMan.reviveGroup.gameObject.SetActive(value: true);
			AudioManager.FadeOutMusic();
			if (WorldLoader.instance != null)
			{
				WorldLoader.instance.ClearCurrentGenerator();
			}
			localPlayer.SetGravityMult(1f);
			localPlayer.SetGravity(b: true);
			yield return new WaitForSecondsRealtime(1f);
			float fadeSpeed = 0.2f;
			AudioSource reviveAudio = CL_UIManager.instance.reviveGroup.GetComponent<AudioSource>();
			localPlayer.Lock();
			while (uiMan.reviveGroup.alpha < 1f)
			{
				reviveAudio.volume += Time.unscaledDeltaTime * fadeSpeed * 0.5f;
				uiMan.reviveGroup.alpha += Time.unscaledDeltaTime * fadeSpeed;
				yield return null;
			}
			GetComponent<AudioSource>().Play();
			save.UpdatePlayerData(localPlayer);
			CL_SaveManager.LoadSave(save);
			yield return new WaitForSecondsRealtime(2f);
			localPlayer.SetGravityMult(1f);
			localPlayer.SetGravity(b: true);
			dead = false;
			SetTimescale(1f);
			localPlayer.UnLock();
			localPlayer.AddGripStrength(20f);
			yield return new WaitForSecondsRealtime(0.5f);
			if (WorldLoader.initialized)
			{
				while (!WorldLoader.isLoaded)
				{
					yield return null;
				}
			}
			yield return new WaitForSecondsRealtime(0.5f);
			reviving = false;
			while (uiMan.reviveGroup.alpha > 0f)
			{
				uiMan.reviveGroup.alpha -= Time.unscaledDeltaTime;
				reviveAudio.volume -= Time.unscaledDeltaTime * 1f;
				yield return null;
			}
			uiMan.reviveGroup.alpha = 0f;
			reviveAudio.volume = 0f;
			reviving = false;
			lockPlayer = false;
			localPlayer.SetGravityMult(1f);
			localPlayer.SetGravity(b: true);
			CL_UIManager.instance.SetVignetteTarget("bloodied", 0f);
			uiMan.reviveGroup.gameObject.SetActive(value: false);
			uiMan.ResetVignettes();
			CL_AchievementManager.SetAchievementValue("ACH_REVIVE", b: true);
			StatManager.sessionStats.UpdateStatistic("revives", 1, StatManager.Statistic.DataType.Int, StatManager.Statistic.ModType.Add);
			yield return new WaitForSecondsRealtime(1f);
			localPlayer.SetGravity(b: true);
			if (localPlayer.GetTagger() != null)
			{
				localPlayer.GetTagger().RemoveTag("Dead");
			}
			localPlayer.dead = false;
			CL_UIManager.instance.SetVignetteTarget("bloodied", 0f);
			uiMan.reviveGroup.alpha = 0f;
			uiMan.reviveGroup.gameObject.SetActive(value: false);
		}
	}

	public void Win()
	{
		StartCoroutine(EndGameSequence(win: true));
	}

	private IEnumerator EndGameSequence(bool win = false)
	{
		runHasEnded = true;
		dead = true;
		SetTimescale(0.1f);
		CL_SaveManager.DeleteSessionSave(GetGamemodeName(includeOptions: false, mainMode: true), IsHardmode());
		gameTime = (float)Math.Round(gameTime, 2, MidpointRounding.AwayFromZero);
		float timeDifference = 0f;
		if (gamemode.GetGamemodeSaveData() != null && gamemode.GetGamemodeSaveData().stats.HasStatistic("best-time"))
		{
			float statisticFloat = StatManager.GetStatisticFloat(gamemode.GetGamemodeSaveData().stats, "best-time");
			timeDifference = gameTime - statisticFloat;
		}
		Debug.Log("Gametime: " + gameTime);
		uiMan.SetFadeTarget(1f);
		yield return new WaitForSecondsRealtime(1f);
		isPaused = true;
		gamemode.gamemodeModule.OnFinish(win);
		EndGameStatUpdate(win);
		gamemode.Finish(gameTime, win);
		yield return null;
		CL_ProgressionManager.UpdateUnlocks(showPopups: true);
		statManager.ShowScoreScreen(win);
		if (win && timeDifference < 0f && gamemode.timeGoal)
		{
			statManager.GetScoreScreen(win).PlayTimeReductionAnimation(timeDifference);
		}
		CL_GameTracker.SaveSession();
		Cursor.lockState = CursorLockMode.None;
		showCursor = true;
		yield return new WaitForSecondsRealtime(0.5f);
		float fadeOut = 1f;
		AudioManager.FadeOutMusic();
		AudioManager.instance.gameMixer.audioMixer.GetFloat("MasterVolume", out fadeOut);
		while (fadeOut > -80f)
		{
			fadeOut -= Time.unscaledDeltaTime * 10f;
			AudioManager.instance.gameMixer.audioMixer.SetFloat("MasterVolume", fadeOut);
			AudioManager.instance.gameMixer.audioMixer.SetFloat("AmbienceVolume", fadeOut);
			AudioManager.instance.gameMixer.audioMixer.SetFloat("EffectsVolume", fadeOut);
			yield return null;
		}
		Cursor.lockState = CursorLockMode.None;
	}

	private void EndGameStatUpdate(bool win = false)
	{
		StatManager.sessionStats.UpdateStatistic("death-height", GetPlayerCorrectedHeight(), StatManager.Statistic.DataType.Float, StatManager.Statistic.ModType.Max, StatManager.Statistic.DisplayType.Meters, StatManager.Statistic.ModType.Max);
		float playerScore = gamemode.GetPlayerScore(win);
		StatManager.sessionStats.UpdateStatistic("score", playerScore, StatManager.Statistic.DataType.Float, StatManager.Statistic.ModType.Set, StatManager.Statistic.DisplayType.Default, StatManager.Statistic.ModType.Max);
		StatManager.sessionStats.UpdateStatistic("highest-ascent", playerAscent, StatManager.Statistic.DataType.Float, StatManager.Statistic.ModType.Max, StatManager.Statistic.DisplayType.Meters, StatManager.Statistic.ModType.Max);
		StatManager.sessionStats.UpdateStatistic("combined-ascent-rate", ascentRate, StatManager.Statistic.DataType.Float, StatManager.Statistic.ModType.Set, StatManager.Statistic.DisplayType.Speed);
		StatManager.sessionStats.UpdateStatistic("best-travel-distance", bestPlayerTravelDistance, StatManager.Statistic.DataType.Float, StatManager.Statistic.ModType.Max, StatManager.Statistic.DisplayType.Meters, StatManager.Statistic.ModType.Max);
		StatManager.sessionStats.UpdateStatistic("combined-travel-speed", playerTravelSpeed, StatManager.Statistic.DataType.Float, StatManager.Statistic.ModType.Set, StatManager.Statistic.DisplayType.Speed);
		if (StatManager.saveData.gameStats.HasStatistic("combined-ascent-rate") && StatManager.saveData.gameStats.HasStatistic("runs"))
		{
			float num = ((float)StatManager.saveData.gameStats.GetStatistic("combined-ascent-rate").GetValue() + ascentRate) / (float)((int)StatManager.saveData.gameStats.GetStatistic("runs").GetValue() + 1);
			StatManager.sessionStats.UpdateStatistic("average-ascent-rate", num, StatManager.Statistic.DataType.Float, StatManager.Statistic.ModType.Set, StatManager.Statistic.DisplayType.Speed, StatManager.Statistic.ModType.Set);
			float num2 = ((float)StatManager.saveData.gameStats.GetStatistic("combined-travel-speed").GetValue() + playerTravelSpeed) / (float)((int)StatManager.saveData.gameStats.GetStatistic("runs").GetValue() + 1);
			StatManager.sessionStats.UpdateStatistic("average-travel-speed", num2, StatManager.Statistic.DataType.Float, StatManager.Statistic.ModType.Set, StatManager.Statistic.DisplayType.Speed, StatManager.Statistic.ModType.Set);
		}
		else
		{
			StatManager.sessionStats.UpdateStatistic("average-ascent-rate", ascentRate, StatManager.Statistic.DataType.Float, StatManager.Statistic.ModType.Set, StatManager.Statistic.DisplayType.Speed, StatManager.Statistic.ModType.Set);
			StatManager.sessionStats.UpdateStatistic("average-travel-speed", playerTravelSpeed, StatManager.Statistic.DataType.Float, StatManager.Statistic.ModType.Set, StatManager.Statistic.DisplayType.Speed, StatManager.Statistic.ModType.Set);
		}
		StatManager.sessionStats.UpdateStatistic("game-time", gameTime, StatManager.Statistic.DataType.Float, StatManager.Statistic.ModType.Set, StatManager.Statistic.DisplayType.Time);
		if (win)
		{
			StatManager.sessionStats.UpdateStatistic("wins", 1, StatManager.Statistic.DataType.Int);
			if (gamemode.timeGoal)
			{
				StatManager.sessionStats.UpdateStatistic("best-time", gameTime, StatManager.Statistic.DataType.Float, StatManager.Statistic.ModType.Min, StatManager.Statistic.DisplayType.Time, StatManager.Statistic.ModType.Min);
			}
		}
	}

	public static bool isDead()
	{
		return dead;
	}

	public static RichPresenceMarker RichPresencePush()
	{
		richPresenceVersion++;
		RichPresenceMarker result = new RichPresenceMarker
		{
			version = ++richPresenceUniqueInt
		};
		richPresenceContextStack.Add((result.version, new Dictionary<string, string>()));
		return result;
	}

	public static void RichPresencePop(RichPresenceMarker marker)
	{
		if (marker.version == 0)
		{
			return;
		}
		for (int i = 0; i < richPresenceContextStack.Count; i++)
		{
			if (richPresenceContextStack[i].version == marker.version)
			{
				richPresenceContextStack.RemoveAt(i);
				if (i == richPresenceContextStack.Count)
				{
					richPresenceVersion++;
				}
				break;
			}
		}
	}

	public static void RichPresenceClear()
	{
		richPresenceClearUnixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		richPresenceVersion++;
		richPresenceContextStack.Clear();
	}

	public static void RichPresenceSet(RichPresenceMarker marker, string key, string value)
	{
		if (richPresenceContextStack.Count == 0)
		{
			richPresenceContextStack.Add((0, new Dictionary<string, string>()));
		}
		for (int i = 0; i < richPresenceContextStack.Count; i++)
		{
			var (num, dictionary) = richPresenceContextStack[i];
			if (marker.version == num || marker.version == 0)
			{
				string valueOrDefault = dictionary.GetValueOrDefault(key);
				dictionary[key] = value;
				if (i == richPresenceContextStack.Count - 1 && valueOrDefault != value)
				{
					richPresenceVersion++;
				}
			}
		}
	}

	public static Dictionary<string, string> RichPresencePeek()
	{
		if (richPresenceContextStack.Count == 0)
		{
			richPresenceContextStack.Add((0, new Dictionary<string, string>()));
		}
		List<(int version, Dictionary<string, string> richPre)> list = richPresenceContextStack;
		return list[list.Count - 1].richPre;
	}

	public static int RichPresenceVersion()
	{
		return richPresenceVersion;
	}

	public static long RichPresenceStartTime()
	{
		return richPresenceClearUnixTime;
	}

	public static string RichPresenceStringifyEn(Dictionary<string, string> keys)
	{
		if (richPresenceMap == null)
		{
			richPresenceMap = new Dictionary<string, string>();
			richPresenceMap["detail_resting_at_silos_interlude"] = "Resting at Lockdown";
			richPresenceMap["detail_tangled_sink_interlude"] = "Resting at Filtration";
			richPresenceMap["detail_expulsion_chute_interlude"] = "Resting at Disposal";
			richPresenceMap["detail_duct_interlude"] = "Resting at Analysis";
			richPresenceMap["detail_diver_interlude1"] = "Fighting through Intersection";
			richPresenceMap["detail_diver_interlude2"] = "Resting at Intersection";
			richPresenceMap["detail_pipeworks_interlude"] = "Climbing Ascent";
			richPresenceMap["detail_habitation_forlorn_gateway"] = "Resting at Forlorn Gateway";
			richPresenceMap["detail_abyss_interlude"] = "Resting at Evacuation";
			richPresenceMap["detail_nest_interlude"] = "Resting at Symbiosis";
			richPresenceMap["detail_nest_mother"] = "Ending Pact";
			richPresenceMap["detail_bazaar"] = "Shopping";
			richPresenceMap["detail_rho_challenge_1"] = "Entertainment";
			richPresenceMap["detail_rho_challenge_2"] = "Evaluation";
			richPresenceMap["detail_rho_challenge_3"] = "Observation";
			richPresenceMap["unknown_location"] = "Unknown";
			richPresenceMap["detail_ladder"] = "LllaAAdDderR";
			richPresenceMap["detail_his_domain"] = "His Domain";
			richPresenceMap["detail_her_domain"] = "Her Domain";
			richPresenceMap["detail_playground"] = "At the Playground";
			richPresenceMap["pipeworks"] = "Pipes";
			richPresenceMap["habitation"] = "Hab";
			richPresenceMap["sb17"] = "Substructure";
			richPresenceMap["none"] = "";
			richPresenceMap["ik"] = " IK";
			richPresenceMap["hm"] = " HM";
			richPresenceMap["ikhm"] = " IK HM";
			richPresenceMap["competetive"] = " COMP";
			richPresenceMap["unlimited"] = " INF";
			richPresenceMap["hm_unlimited"] = " HM INF";
		}
		string valueOrDefault = keys.GetValueOrDefault("main");
		string result = "";
		if (valueOrDefault == "#mode_playlist")
		{
			result = GetValue("gamemode") + GetValue("gamemode_modifiers") + ": " + GetValue("region") + " " + GetValue("distance");
		}
		if (valueOrDefault == "#mode_playlist_single_region")
		{
			result = GetValue("gamemode") + GetValue("gamemode_modifiers") + " " + GetValue("distance");
		}
		switch (valueOrDefault)
		{
		case "#mode_playlist_detailed":
			result = GetValue("gamemode") + GetValue("gamemode_modifiers") + ": " + GetValue("details") + " " + GetValue("distance");
			break;
		case "#mode_chamber":
			result = GetValue("chamber_title") + ": " + GetValue("chamber_subtitle") + " " + GetValue("modifier");
			break;
		case "#win":
			result = GetValue("gamomode") + GetValue("gamemode_modifiers") + ": Won";
			break;
		case "#loss":
			result = GetValue("gamomode") + GetValue("gamemode_modifiers") + ": Died";
			break;
		case "#loss_height":
			result = GetValue("gamomode") + GetValue("gamemode_modifiers") + ": Died at " + GetValue("distance");
			break;
		case "#main_menu":
			result = "Main Menu: Pondering Climbs";
			break;
		default:
		{
			if (richPresenceMap.TryGetValue(valueOrDefault.Substring(1), out var value))
			{
				result = value;
			}
			break;
		}
		case null:
			break;
		}
		return result;
		string GetValue(string key)
		{
			string valueOrDefault2 = keys.GetValueOrDefault(key, "");
			if (key == "region" && valueOrDefault2 == "shortcut")
			{
				valueOrDefault2 = keys.GetValueOrDefault("subregion", "");
			}
			if (richPresenceMap.TryGetValue(valueOrDefault2, out var value2))
			{
				return value2;
			}
			valueOrDefault2 = valueOrDefault2.Replace("sb17", "substructure");
			valueOrDefault2 = valueOrDefault2.Replace("endless", "∞");
			char[] array = valueOrDefault2.ToCharArray();
			if (array.Length != 0)
			{
				array[0] = char.ToUpper(array[0]);
			}
			for (int i = 0; i < array.Length - 1; i++)
			{
				if (array[i] == '_')
				{
					array[i] = ' ';
					array[i + 1] = char.ToUpper(array[i + 1]);
				}
			}
			return new string(array);
		}
	}
}
