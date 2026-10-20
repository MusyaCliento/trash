using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(HandholdManager))]
public class WorldLoader : MonoBehaviour
{
	public class SkyboxManager
	{
		public static List<GameObject> activeSkyboxes = new List<GameObject>();

		public static void UnloadSkyboxes()
		{
			if (activeSkyboxes != null && activeSkyboxes.Count > 0)
			{
				for (int num = activeSkyboxes.Count - 1; num >= 0; num--)
				{
					UnityEngine.Object.Destroy(activeSkyboxes[num]);
				}
				activeSkyboxes.Clear();
			}
		}

		public static void AddSkybox(GameObject s)
		{
			if (activeSkyboxes == null)
			{
				activeSkyboxes = new List<GameObject>();
			}
			activeSkyboxes.Add(s);
		}
	}

	[Serializable]
	public class LevelInfo
	{
		private M_Level level;

		private M_Level.LevelAssetHolder levelAssetReference;

		internal BranchInfo.LevelId levelID;

		public GameObject spawnedLOD;

		[SerializeReference]
		public BranchInfo branch;

		public float lowBounds;

		public float highBounds;

		[HideInInspector]
		[SerializeReference]
		public List<LevelInfo> connectedLevels;

		public bool loaded;

		public bool adjacent;

		public bool stopLevel;

		public void DestroyLevelObject()
		{
			foreach (LevelInfo connectedLevel in connectedLevels)
			{
				int num = 0;
				while (connectedLevel != null && connectedLevel.connectedLevels != null && num < connectedLevel.connectedLevels.Count)
				{
					if (connectedLevel.connectedLevels[num] == this)
					{
						connectedLevel.connectedLevels.RemoveAt(num--);
					}
					num++;
				}
			}
			if (spawnedLOD != null)
			{
				UnityEngine.Object.Destroy(spawnedLOD);
			}
			UnityEngine.Object.Destroy(level.gameObject);
		}

		internal void SetLevel(M_Level l, M_Level.LevelAssetHolder lA)
		{
			level = l;
			levelAssetReference = lA;
		}

		public M_Level GetLevel()
		{
			return level;
		}

		public M_Level.LevelAssetHolder GetLevelAssetReference()
		{
			return levelAssetReference;
		}
	}

	[Serializable]
	public class BranchInfo
	{
		[Serializable]
		public class LevelId
		{
			public int id;

			public string level;

			public string region;

			public string subRegion;
		}

		public string id;

		[DoNotSerialize]
		public M_GenerationBranch generationBranch;

		[HideInInspector]
		[SerializeReference]
		public BranchInfo parent;

		[HideInInspector]
		[SerializeReference]
		public LevelInfo parentLevel;

		[HideInInspector]
		[SerializeReference]
		public List<BranchInfo> children;

		public Transform originTransform;

		[HideInInspector]
		public List<LevelInfo> levelTracker = new List<LevelInfo>();

		internal List<LevelId> levelIDs;

		internal List<LevelId> pausedLevelIDs;

		[HideInInspector]
		public LevelInfo currentLevel;

		private int currentLevelId;

		public List<LevelId> GetLevelIds()
		{
			return levelIDs;
		}

		public List<LevelId> GetLevelIdsAfterRegion(string regionName)
		{
			List<LevelId> list = new List<LevelId>();
			bool flag = false;
			for (int i = 0; i < levelIDs.Count; i++)
			{
				if (levelIDs[i].region == regionName && list.Count == 0)
				{
					flag = true;
				}
				else if (flag)
				{
					list.Add(levelIDs[i]);
				}
			}
			return list;
		}

		public List<LevelId> GetLevelIdsAfterLevel(M_Level level)
		{
			List<LevelId> list = new List<LevelId>();
			bool flag = false;
			LevelId levelId = null;
			for (int i = 0; i < levelTracker.Count; i++)
			{
				if (!flag && levelTracker[i].GetLevel() == level)
				{
					flag = true;
					levelId = levelTracker[i].levelID;
					break;
				}
			}
			if (levelId != null && levelIDs.Contains(levelId))
			{
				int num = levelIDs.IndexOf(levelId) + 1;
				if (levelIDs.Count <= num)
				{
					return list;
				}
				for (int j = num; j < levelIDs.Count; j++)
				{
					list.Add(levelIDs[j]);
				}
			}
			return list;
		}

		public LevelInfo GetLevelInfoFromLevel(M_Level level)
		{
			foreach (LevelInfo item in levelTracker)
			{
				if (item.GetLevel() == level)
				{
					return item;
				}
			}
			return null;
		}
	}

	[Serializable]
	public class GenerationParameters
	{
		public enum GenerationType
		{
			standard = 0,
			continued = 1,
			replace = 2,
			generateUntilFound = 3,
			saveLoad = 4
		}

		public enum ReachEndType
		{
			restart = 0,
			stop = 1
		}

		public GenerationType generationType;

		public ReachEndType endType;

		public bool forceResetGeneratorToGamemode;

		public WorldGenerator generator;

		public float generationHeightOffset;

		public M_Region lastRegion;

		public M_Region startRegion;

		public List<M_Level.LevelAssetHolder> preloadLevels;

		public string targetLevel;

		public List<BranchInfo.LevelId> saveLevels;

		public bool removeLevelsBeforeTarget;

		public bool setPlayerPositionToTargetLevel = true;

		public bool setPlayerPositionToStartLevel;

		public List<M_Level.SaveData> levelData;

		public bool loadSavedEntities;

		public List<string> flags;

		public int seedOffset;
	}

	public bool active = true;

	public List<M_Level> introSegments;

	public List<M_Level> levels;

	[HideInInspector]
	public List<BranchInfo> branchTracker;

	[HideInInspector]
	public BranchInfo currentBranch;

	[HideInInspector]
	private List<BranchInfo> branches;

	private int idCounter;

	public static bool inNewLevel;

	private LevelInfo latestLevel;

	private Vector3 levelEntryPosition;

	private Vector3 levelExitPosition;

	private HandholdManager handholdManager;

	private float curLevelMinBounds;

	private float curLevelMaxBounds;

	private List<M_Level> previousLevels = new List<M_Level>();

	private List<M_Level> levelOrdering = new List<M_Level>();

	public List<M_Region> regions;

	private float heightTarget = 50f;

	private M_Region currentRegion;

	private M_Subregion currentSubregion;

	public static WorldLoader instance;

	private bool loading;

	public M_Level loadTestlevel;

	public M_Region loadTestRegion;

	public M_Subregion loadTestSubregion;

	public int seed;

	public int startingSeed;

	private static int presetSeed;

	public static bool customSeed;

	private ENT_Player.SaveData playerSave = new ENT_Player.SaveData();

	public static bool initialized;

	public static bool isLoaded;

	private Transform lodRoot;

	private WorldGenerator currentGenerator;

	private List<GameObject> visibleLODs = new List<GameObject>();

	internal static int safeAreaCount;

	private M_Chamber activeChamber;

	public static Action<LevelInfo> onLevelActivate;

	public bool isDebugWorld;

	private static Transform currentNonLevelParent;

	private static Transform worldloaderNullParent;

	private void Awake()
	{
		instance = this;
		if (presetSeed != 0)
		{
			Debug.Log("WorldLoader: Using custom seed: " + presetSeed);
			customSeed = true;
		}
	}

	public void Initialize()
	{
		safeAreaCount = 0;
		handholdManager = GetComponent<HandholdManager>();
		branches = new List<BranchInfo>();
		currentBranch = new BranchInfo();
		currentBranch.id = "branch-root";
		currentBranch.levelTracker = new List<LevelInfo>();
		currentBranch.children = new List<BranchInfo>();
		branches.Add(currentBranch);
		if (!active || !base.gameObject.activeSelf)
		{
			return;
		}
		lodRoot = new GameObject("LOD Root").transform;
		lodRoot.parent = base.transform;
		StopAllCoroutines();
		if (presetSeed != 0)
		{
			Debug.Log("WorldLoader: Using custom seed: " + presetSeed);
			seed = presetSeed;
			customSeed = true;
			presetSeed = 0;
		}
		else
		{
			customSeed = false;
			if (seed == 0 || seed == -1)
			{
				seed = UnityEngine.Random.Range(0, 10000000);
			}
		}
		if (!CL_SaveManager.loadSessionSaveOnLoad && !isDebugWorld)
		{
			StartCoroutine(LoadWorldRoutine());
		}
		else if (isDebugWorld)
		{
			isLoaded = true;
		}
		initialized = true;
		CommandConsole.BuildCommand("teleportplayertolevel", TeleportPlayerToTargetLevel).AutocompleteCustom(delegate(CommandConsole.CommandAutocomplete autocomplete)
		{
			if (autocomplete.activeArg > 0)
			{
				autocomplete.Reject();
			}
			else
			{
				List<string> list = new List<string>();
				foreach (LevelInfo item2 in GetCurrentBranch().levelTracker)
				{
					string item = item2.GetLevel().name.ToLower().Replace("(clone)", "");
					list.Add(item);
				}
				autocomplete.FromArray(list);
			}
		});
		CommandConsole.BuildCommand("teleportplayertolastlevel", TeleportPlayerToLastLevel);
		CommandConsole.BuildCommand("teleportplayertonextlevel", TeleportPlayerToNextLevel);
		CommandConsole.AddCommand("listloadedlevels", ListLoadedLevels);
		CommandConsole.AddCommand("getgenerationseed", GetSeed);
		CommandConsole.AddCommand("setgenerationseed", ReloadWithSeed);
		startingSeed = seed;
		IEnumerator LoadWorldRoutine()
		{
			yield return GenerateLevels(GetCurrentBranch());
			if (currentBranch.levelTracker != null && currentBranch.levelTracker.Count > 0)
			{
				currentBranch.currentLevel = currentBranch.levelTracker[0];
				if (currentBranch.currentLevel.GetLevel().spawnPosition != null)
				{
					ENT_Player.playerObject.Teleport(currentBranch.currentLevel.GetLevel().spawnPosition.position, currentBranch.currentLevel.GetLevel().spawnPosition.rotation);
				}
				isLoaded = true;
			}
			else
			{
				isLoaded = true;
			}
		}
	}

	public BranchInfo GetNewBranch(string id)
	{
		BranchInfo branchInfo = new BranchInfo();
		branchInfo.id = id;
		branchInfo.levelTracker = new List<LevelInfo>();
		branchInfo.children = new List<BranchInfo>();
		branches.Add(branchInfo);
		return branchInfo;
	}

	private void Update()
	{
		if (currentBranch.levelTracker == null || currentBranch.levelTracker.Count == 0 || !isLoaded)
		{
			return;
		}
		LoadUnload(CL_GameManager.gMan.localPlayer.transform.position.y);
		if (FXManager.fxMan != null && currentBranch != null && currentBranch.currentLevel != null && currentBranch.currentLevel.GetLevel() != null && currentBranch.currentLevel.GetLevel().region != null)
		{
			float num = 0.1f;
			FXManager.defaultData.ditherLevels = Mathf.Lerp(FXManager.defaultData.ditherLevels, currentBranch.currentLevel.GetLevel().region.ditherLevels, Time.fixedDeltaTime * num);
			FXManager.defaultData.fog = Color.Lerp(FXManager.defaultData.fog, currentBranch.currentLevel.GetLevel().region.fogColor, Time.fixedDeltaTime * num);
			if (currentBranch.currentLevel != null && currentBranch.currentLevel.GetLevel().subRegion != null)
			{
				currentBranch.currentLevel.GetLevel().subRegion.Update();
			}
		}
	}

	private void OnDestroy()
	{
		if (instance == this)
		{
			initialized = false;
			instance = null;
		}
	}

	private IEnumerator GenerateLevels(BranchInfo branch, GenerationParameters genParams = null)
	{
		isLoaded = false;
		int startingLevel = branch.levelTracker.Count;
		int worldPreloadStartID = -1;
		if (genParams == null)
		{
			genParams = new GenerationParameters();
		}
		if (genParams.forceResetGeneratorToGamemode)
		{
			genParams.generator = CL_GameManager.gamemode;
		}
		if (genParams.generator == null)
		{
			if (currentGenerator == null)
			{
				genParams.generator = CL_GameManager.gamemode;
			}
			else
			{
				genParams.generator = currentGenerator;
			}
		}
		currentGenerator = genParams.generator;
		Debug.Log("WorldLoader: Generation Seed: " + seed);
		if (seed != -1)
		{
			seed += genParams.seedOffset;
			UnityEngine.Random.InitState(seed);
		}
		loading = true;
		CL_GameManager.SetLoading(b: true);
		List<M_Level.LevelAssetHolder> levelGenerationList = new List<M_Level.LevelAssetHolder>();
		List<M_Level.LevelAssetHolder> list = null;
		int playerStartLevel = startingLevel;
		if (branch.pausedLevelIDs != null && branch.pausedLevelIDs.Count > 0)
		{
			Debug.Log("WorldLoader: Spawning from Paused Levels");
			list = new List<M_Level.LevelAssetHolder>();
			foreach (BranchInfo.LevelId pausedLevelID in branch.pausedLevelIDs)
			{
				Debug.Log(pausedLevelID.region);
				M_Level.LevelAssetHolder levelAsset = CL_AssetManager.GetLevelAsset(pausedLevelID.level);
				if (pausedLevelID.region != "")
				{
					levelAsset.region = CL_AssetManager.GetRegionAsset(pausedLevelID.region);
				}
				if (pausedLevelID.subRegion != "")
				{
					levelAsset.subregion = CL_AssetManager.GetSubregionAsset(pausedLevelID.subRegion);
				}
				Debug.Log(pausedLevelID.id + " LID " + pausedLevelID.level + " R: " + pausedLevelID.region + " SR: " + pausedLevelID.subRegion);
				if (levelAsset.region == null)
				{
					Debug.Log("WorldLoader: No region found for " + pausedLevelID.level);
				}
				if (levelAsset.subregion == null)
				{
					Debug.Log("WorldLoader: No subregion found for " + pausedLevelID.level);
				}
				list.Add(levelAsset);
			}
			Debug.Log("WorldLoader: Generation List Size: " + list.Count);
			branch.pausedLevelIDs.Clear();
		}
		else if (genParams.preloadLevels != null && genParams.generationType == GenerationParameters.GenerationType.generateUntilFound)
		{
			Debug.Log("WorldLoader: Preload levels!!");
			bool flag = false;
			Debug.Log(CL_GameManager.gamemode);
			int num = 0;
			while (!flag)
			{
				num++;
				worldPreloadStartID = 0;
				List<M_Level.LevelAssetHolder> generationList = genParams.generator.GetGenerationList();
				for (int i = 0; i < generationList.Count; i++)
				{
					if (generationList[i].id == genParams.preloadLevels[0].id)
					{
						flag = true;
						if (genParams.preloadLevels.Count > 1)
						{
							generationList.InsertRange(i, genParams.preloadLevels.GetRange(1, genParams.preloadLevels.Count - 1));
						}
						playerStartLevel = i;
						list = generationList;
						worldPreloadStartID += i;
						Debug.Log($"WorldLoader: Preload ID : {worldPreloadStartID} I: {i} Start ID: {startingLevel}");
						break;
					}
				}
				if (flag)
				{
					break;
				}
				if (num > 1000)
				{
					Debug.LogError("WorldLoader: ERROR: COULD NOT FIND LEVEL " + genParams.preloadLevels[0].id + " IN GENERATION STEP. EXITING GAME.");
					CL_GameManager.gMan.LoadScene("Main-Menu");
					yield break;
				}
			}
		}
		else if (genParams.saveLevels != null && genParams.generationType == GenerationParameters.GenerationType.saveLoad)
		{
			Debug.Log("WorldLoader: Save levels!");
			bool flag2 = false;
			Debug.Log(CL_GameManager.gamemode);
			int num2 = 0;
			while (!flag2)
			{
				num2++;
				worldPreloadStartID = 0;
				List<M_Level.LevelAssetHolder> generationList2 = genParams.generator.GetGenerationList();
				List<BranchInfo.LevelId> list2 = new List<BranchInfo.LevelId>();
				list2.Clear();
				for (int j = 0; j < genParams.saveLevels.Count; j++)
				{
					BranchInfo.LevelId levelId = genParams.saveLevels[j];
					list2.Add(levelId);
					for (int k = 0; k < generationList2.Count; k++)
					{
						M_Level.LevelAssetHolder levelAssetHolder = generationList2[k];
						M_Level.LevelAssetHolder levelAssetFromLevelName = GetLevelAssetFromLevelName(levelId.level);
						if (levelAssetFromLevelName == null || (!(levelAssetHolder.id == levelId.level) && (string.IsNullOrEmpty(levelAssetFromLevelName.level.levelNeighborhoodID) || !(levelAssetHolder.level.levelNeighborhoodID == levelAssetFromLevelName.level.levelNeighborhoodID))))
						{
							continue;
						}
						flag2 = true;
						if (genParams.saveLevels.Count > 1)
						{
							List<M_Level.LevelAssetHolder> list3 = new List<M_Level.LevelAssetHolder>();
							foreach (BranchInfo.LevelId item in list2)
							{
								Debug.Log("Worldloader: Adding Level To List: " + item.level);
								list3.Add(GetLevelAssetFromLevelName(item.level));
							}
							generationList2.RemoveRange(0, k + 1);
							generationList2.InsertRange(0, list3);
						}
						playerStartLevel = 0;
						list = generationList2;
						worldPreloadStartID = 0;
						Debug.Log($"WorldLoader: Preload ID : {worldPreloadStartID} I: {k} Start ID: {startingLevel}");
						break;
					}
					if (flag2)
					{
						break;
					}
				}
				if (flag2)
				{
					break;
				}
				if (num2 > 1000)
				{
					Debug.LogError("WorldLoader: ERROR: COULD NOT FIND LEVEL " + genParams.preloadLevels[0].id + " IN GENERATION STEP. EXITING GAME.");
					CL_GameManager.gMan.LoadScene("Main-Menu");
					yield break;
				}
			}
		}
		else if (genParams.preloadLevels != null && genParams.generationType == GenerationParameters.GenerationType.replace)
		{
			list = genParams.preloadLevels;
		}
		else
		{
			list = genParams.generator.GetGenerationList(genParams.lastRegion, genParams.startRegion);
			for (int l = 0; l < levelGenerationList.Count; l++)
			{
				Debug.Log(levelGenerationList[l].region);
			}
		}
		levelGenerationList.AddRange(list);
		Vector3 positionOffset = Vector3.up * genParams.generationHeightOffset;
		bool isPausingGeneration = false;
		List<LevelInfo> tempLevelInfoList = new List<LevelInfo>();
		for (int m = 0; m < levelGenerationList.Count; m++)
		{
			levelGenerationList[m].LoadLevel();
		}
		for (int n = 0; n < levelGenerationList.Count; n++)
		{
			while (!levelGenerationList[n].IsLoaded())
			{
				yield return null;
			}
			M_Level.LevelAssetHolder levelAssetHolder2 = levelGenerationList[n];
			if (levelAssetHolder2 == null)
			{
				Debug.LogError("WorldLoader: ERROR: No level found for " + levelGenerationList[n].id + ", Worldloader Unable to Create. Skipping.");
				continue;
			}
			BranchInfo.LevelId levelId2 = new BranchInfo.LevelId();
			levelId2.id = idCounter++;
			levelId2.level = levelAssetHolder2.id;
			if (levelAssetHolder2.region != null)
			{
				levelId2.region = levelAssetHolder2.region.name;
			}
			if (levelAssetHolder2.subregion != null)
			{
				levelId2.subRegion = levelAssetHolder2.subregion.name;
			}
			if (branch.levelIDs == null)
			{
				branch.levelIDs = new List<BranchInfo.LevelId>();
			}
			if (branch.pausedLevelIDs == null)
			{
				branch.pausedLevelIDs = new List<BranchInfo.LevelId>();
			}
			branch.levelIDs.Add(levelId2);
			if (isPausingGeneration && n > worldPreloadStartID)
			{
				branch.pausedLevelIDs.Add(levelId2);
			}
			if (isPausingGeneration && n > worldPreloadStartID)
			{
				if (levelAssetHolder2.GetLevel().IsLastLevel())
				{
					break;
				}
				continue;
			}
			M_Level m_Level = UnityEngine.Object.Instantiate(levelAssetHolder2.GetLevel(), Vector3.zero, Quaternion.identity, base.transform);
			m_Level.OnSpawn(levelGenerationList[n].region, levelGenerationList[n].subregion);
			if (n > 0)
			{
				if (UnityEngine.Random.value > 0.5f && m_Level.canFlip)
				{
					m_Level.transform.localScale = new Vector3(-1f, 1f, 1f);
					m_Level.SetFlipped(b: true);
				}
				else
				{
					m_Level.SetFlipped(b: false);
				}
			}
			if (branch.levelTracker.Count > 0 || branch.parentLevel != null)
			{
				Transform transform;
				if (branch.levelTracker.Count > 0)
				{
					transform = branch.levelTracker[n - 1 + startingLevel].GetLevel().GetLevelExit();
				}
				else
				{
					_ = branch.parentLevel;
					transform = branch.originTransform;
				}
				levelExitPosition = transform.position;
				Quaternion quaternion2 = transform.rotation * Quaternion.Inverse(m_Level.GetLevelEntrance().rotation);
				m_Level.transform.rotation = quaternion2 * m_Level.transform.rotation;
				m_Level.transform.position += transform.position - m_Level.GetLevelEntrance().position;
			}
			else
			{
				levelExitPosition = positionOffset;
				m_Level.transform.position = positionOffset;
			}
			handholdManager.LoadHandholds(m_Level.gameObject);
			LevelInfo levelInfo = new LevelInfo();
			levelInfo.SetLevel(m_Level, levelGenerationList[n]);
			levelInfo.levelID = levelId2;
			levelInfo.connectedLevels = new List<LevelInfo>();
			levelInfo.branch = branch;
			if (levelInfo.GetLevel().lodAsset != null)
			{
				levelInfo.spawnedLOD = UnityEngine.Object.Instantiate(levelInfo.GetLevel().lodAsset, m_Level.transform.position, m_Level.transform.rotation, lodRoot);
				levelInfo.spawnedLOD.transform.localScale = levelInfo.GetLevel().transform.localScale;
				levelInfo.spawnedLOD.gameObject.SetActive(value: false);
			}
			if (branch.levelTracker.Count > 0 || branch.parentLevel != null)
			{
				if (branch.levelTracker.Count > 0)
				{
					levelInfo.connectedLevels.Add(branch.levelTracker[n - 1 + startingLevel]);
					branch.levelTracker[n - 1 + startingLevel].connectedLevels.Add(levelInfo);
				}
				else
				{
					levelInfo.connectedLevels.Add(branch.parentLevel);
					branch.parentLevel.connectedLevels.Add(levelInfo);
				}
			}
			levelInfo.lowBounds = levelInfo.GetLevel().GetLevelEntrance().transform.position.y - 1f;
			levelInfo.highBounds = levelInfo.GetLevel().GetLevelExit().transform.position.y + 1f;
			branch.levelTracker.Add(levelInfo);
			tempLevelInfoList.Add(levelInfo);
			if (branch.levelTracker[n] != branch.currentLevel)
			{
				branch.levelTracker[n].GetLevel().gameObject.SetActive(value: false);
			}
			if (playerStartLevel < n + 1 && (m_Level.IsLastLevel() || m_Level.DoesPauseGeneration() || m_Level.IsPausingGeneration()))
			{
				isPausingGeneration = true;
				branch.levelTracker[n].stopLevel = true;
				branch.levelTracker[n].GetLevel().isPausingGeneration = true;
			}
			m_Level.gameObject.SetActive(value: false);
			if (m_Level.IsLastLevel())
			{
				break;
			}
			if (Mathf.Repeat(n, 2f) == 0f)
			{
				yield return null;
			}
		}
		yield return null;
		if (genParams.endType == GenerationParameters.ReachEndType.stop)
		{
			branch.levelTracker[branch.levelTracker.Count - 1].stopLevel = true;
		}
		if (genParams.setPlayerPositionToStartLevel)
		{
			if (branch.levelTracker[0].GetLevel().spawnPosition != null)
			{
				ENT_Player.playerObject.Teleport(branch.levelTracker[0].GetLevel().spawnPosition.position, branch.levelTracker[0].GetLevel().spawnPosition.rotation);
			}
			else
			{
				ENT_Player.playerObject.Teleport(branch.levelTracker[0].GetLevel().transform.position, Quaternion.identity);
			}
		}
		CL_GameManager.SetLoading(b: true);
		for (int num3 = 0; num3 < tempLevelInfoList.Count; num3++)
		{
			if (tempLevelInfoList[num3] != branch.currentLevel)
			{
				tempLevelInfoList[num3].GetLevel().gameObject.SetActive(value: true);
			}
			tempLevelInfoList[num3].GetLevel().Initialize(seed + num3 * 999);
			if (tempLevelInfoList[num3] != branch.currentLevel)
			{
				tempLevelInfoList[num3].GetLevel().gameObject.SetActive(value: false);
			}
		}
		branch.currentLevel = tempLevelInfoList[0];
		loading = false;
		LevelInfo closestLevelToPosition = GetClosestLevelToPosition(ENT_Player.playerObject.transform.position);
		int num4 = branch.levelTracker.IndexOf(closestLevelToPosition);
		if (genParams.levelData != null)
		{
			if (worldPreloadStartID < 0)
			{
				worldPreloadStartID = 0;
			}
			for (int num5 = 0; num5 < genParams.levelData.Count; num5++)
			{
				Debug.Log("WorldLoader: Level " + genParams.levelData[num5].levelName);
				Debug.Log("WorldLoader: Branch " + branch.id + " " + worldPreloadStartID + " :: " + num5 + " :: " + branch.levelTracker.Count);
				Debug.Log("WorldLoader: Branch " + branch.levelTracker[num5]);
				Debug.Log(genParams.levelData.Count + " :: " + branch.levelTracker.Count + " :: " + worldPreloadStartID + " :: " + num5);
				if (branch.levelTracker[worldPreloadStartID + num5].GetLevel() != null && genParams.levelData[num5].levelName == branch.levelTracker[worldPreloadStartID + num5].GetLevel().levelName)
				{
					M_Level.SaveData.LoadDataIntoLevel(genParams.levelData[num5], branch.levelTracker[worldPreloadStartID + num5].GetLevel(), genParams.setPlayerPositionToTargetLevel, genParams.loadSavedEntities, genParams.flags);
				}
			}
		}
		if (!CL_GameManager.gMan.IsReviving() && isLoaded && num4 > 10)
		{
			UnloadLevelRange(0, num4 - 10);
		}
		if (closestLevelToPosition != null && closestLevelToPosition.GetLevel() != null)
		{
			closestLevelToPosition.GetLevel().gameObject.SetActive(value: true);
		}
		yield return new WaitForSecondsRealtime(0.1f);
		CL_GameManager.SetLoading(b: false);
		isLoaded = true;
	}

	private void UnloadLevelRange(int start, int end)
	{
		for (int i = start; i < end; i++)
		{
			currentBranch.levelTracker[i].DestroyLevelObject();
			currentBranch.levelTracker[i].GetLevelAssetReference().UnloadLevelAsset();
		}
		currentBranch.levelTracker.RemoveRange(start, end);
	}

	public void UnloadPreviousLevels(int offset = 1)
	{
		int num = currentBranch.levelTracker.IndexOf(currentBranch.currentLevel) - offset;
		if (num >= 0)
		{
			UnloadLevelRange(0, num);
		}
	}

	public void DeleteOtherBranches()
	{
		for (int num = branches.Count - 1; num >= 0; num--)
		{
			if (branches[num] != currentBranch)
			{
				DeleteBranch(branches[num]);
			}
		}
	}

	private void UnloadLevelsAfterTargetLevel(M_Level level)
	{
		LevelInfo levelInfoFromLevel = GetLevelInfoFromLevel(level);
		if (levelInfoFromLevel != null)
		{
			int num = currentBranch.levelTracker.IndexOf(levelInfoFromLevel);
			for (int num2 = currentBranch.levelTracker.Count - 1; num2 > num; num2--)
			{
				currentBranch.levelTracker[num2].DestroyLevelObject();
				currentBranch.levelTracker.RemoveAt(num2);
			}
		}
	}

	private void UnloadAllLevels()
	{
		for (int num = branches.Count - 1; num >= 0; num--)
		{
			UnloadLevelsFromBranch(branches[num]);
		}
		if (currentBranch != null)
		{
			UnloadLevelsFromBranch(currentBranch);
		}
		branches.Clear();
		currentBranch = GetNewBranch("branch-root");
	}

	public void UnloadLevelsFromBranch(BranchInfo branch, bool ignoreCurrentLevel = false)
	{
		for (int num = branch.levelTracker.Count - 1; num >= 0; num--)
		{
			if (ignoreCurrentLevel && GetCurrentLevel() == branch.levelTracker[num])
			{
				branch.levelTracker[num].stopLevel = true;
			}
			else
			{
				branch.levelTracker[num].DestroyLevelObject();
				branch.levelTracker.RemoveAt(num);
			}
		}
	}

	public void GenerateBranchFromLevel(M_Level level, Transform startTransform, WorldGenerator generator, M_GenerationBranch branch)
	{
		BranchInfo branchInfo = new BranchInfo();
		branchInfo.id = branch.id;
		branchInfo.generationBranch = branch;
		branchInfo.parent = currentBranch;
		branchInfo.parentLevel = GetLevelInfoFromLevel(level);
		branchInfo.originTransform = startTransform;
		branches.Add(branchInfo);
		if (currentBranch.children == null)
		{
			currentBranch.children = new List<BranchInfo>();
		}
		currentBranch.children.Add(branchInfo);
		GenerationParameters genParams = new GenerationParameters
		{
			lastRegion = level.region,
			startRegion = null,
			generator = generator
		};
		StartCoroutine(GenerateLevels(branchInfo, genParams));
	}

	public void ChangeBranch(BranchInfo branch)
	{
		foreach (LevelInfo item in currentBranch.levelTracker)
		{
			if (item != currentBranch.currentLevel)
			{
				item.GetLevel().gameObject.SetActive(value: false);
			}
		}
		if (currentBranch.parentLevel != null && currentBranch.parentLevel.GetLevel() != null)
		{
			currentBranch.parentLevel.GetLevel().gameObject.SetActive(value: false);
		}
		currentBranch = branch;
		if (branch.currentLevel == null)
		{
			branch.currentLevel = branch.levelTracker[0];
		}
	}

	public void ChangeBranch(string id)
	{
		foreach (BranchInfo branch in branches)
		{
			if (branch.id == id)
			{
				ChangeBranch(branch);
				break;
			}
		}
	}

	public void ChangeToLevelBranch(M_Level level)
	{
		foreach (BranchInfo branch in branches)
		{
			foreach (LevelInfo item in branch.levelTracker)
			{
				if (item != null && item.GetLevel() != null && item.GetLevel() == level)
				{
					ChangeBranch(branch);
					return;
				}
			}
		}
	}

	public BranchInfo GetBranchOfLevel(M_Level level)
	{
		foreach (BranchInfo branch in branches)
		{
			foreach (LevelInfo item in branch.levelTracker)
			{
				if (item != null && item.GetLevel() != null && item.GetLevel() == level)
				{
					return branch;
				}
			}
		}
		return null;
	}

	public void DeleteBranch(BranchInfo b, bool ignoreCurrentLevel = false)
	{
		if (branches.Contains(b))
		{
			if (ignoreCurrentLevel && GetCurrentLevel().branch != b)
			{
				UnloadLevelsFromBranch(b);
				branches.Remove(b);
			}
			else
			{
				UnloadLevelsFromBranch(b, ignoreCurrentLevel);
			}
		}
	}

	public void DeleteOtherBranches(string id)
	{
		Debug.Log("WorldLoader: Deleting Other Branches");
		for (int num = branches.Count - 1; num >= 0; num--)
		{
			if (branches[num].id != id)
			{
				Debug.Log("WorldLoader: Pruning " + branches[num].id);
				DeleteBranch(branches[num], ignoreCurrentLevel: true);
			}
		}
	}

	public void RestartGenerationFromLevelList(GenerationParameters generationParameters = null)
	{
		UnloadAllLevels();
		StartCoroutine(GenerateLevels(GetCurrentBranch(), generationParameters));
	}

	public void RestartGenerationFromLevel(M_Level.LevelAssetHolder level, M_Region region, M_Subregion subregion, List<M_Level.SaveData> levelData = null)
	{
		GenerationParameters generationParameters = new GenerationParameters
		{
			levelData = levelData,
			preloadLevels = new List<M_Level.LevelAssetHolder> { level },
			lastRegion = region,
			startRegion = region
		};
		RestartGenerationFromLevelList(generationParameters);
	}

	private void LoadUnload(float playerHeight, bool force = false)
	{
		ref LevelInfo currentLevel = ref GetCurrentBranch().currentLevel;
		if (loading || currentBranch.levelTracker.Count == 0)
		{
			return;
		}
		if (force)
		{
			currentLevel = currentBranch.levelTracker[0];
		}
		if (currentBranch != null)
		{
			DebugMenu.UpdateDebugText("current-branch", "<color=red>Current Branch: " + currentBranch.id);
		}
		else
		{
			DebugMenu.UpdateDebugText("current-branch", "<color=red>Current Branch: N/A");
		}
		if (currentLevel != null && currentLevel.GetLevel() != null)
		{
			if (currentLevel.GetLevel().region != null && currentLevel.GetLevel().subRegion != null)
			{
				DebugMenu.UpdateDebugText("current-level", "<color=red>Current Level: " + currentLevel.GetLevel().name + " : " + currentLevel.GetLevel().region.name + "/" + currentLevel.GetLevel().subRegion.name);
			}
			else
			{
				DebugMenu.UpdateDebugText("current-level", "<color=red>Current Level: " + currentLevel.GetLevel().name + " : inter_region");
			}
		}
		if (CL_GameManager.gMan.GetPlayerBestTravelDistance() > heightTarget && !CL_GameManager.GetBaseGamemode().HasTag("hideascenttracker"))
		{
			heightTarget += 50f;
			if (CL_GameManager.gMan.GetPlayerBestTravelDistance() - 50f < heightTarget)
			{
				int num = Mathf.FloorToInt(CL_GameManager.gMan.GetPlayerBestTravelDistance());
				CL_GameManager.gMan.uiMan.ascentHeader.ShowText("CLIMBED " + num + " METERS");
				CL_GameManager.RichPresenceSet(default(CL_GameManager.RichPresenceMarker), "distance", $"({num / 1000}.{num / 100 % 10}km)");
			}
		}
		if (ENT_Player.GetPlayer() == null)
		{
			return;
		}
		LevelInfo closestLevelToPosition = GetClosestLevelToPosition(ENT_Player.GetPlayer().transform.position);
		bool firstTimeEnteringCurrentLevel = false;
		if (currentLevel != closestLevelToPosition)
		{
			if (currentLevel != null && currentLevel.GetLevel() != null)
			{
				currentLevel.GetLevel().OnExit();
			}
			if (closestLevelToPosition != null && closestLevelToPosition.GetLevel() != null)
			{
				Debug.Log(currentLevel.GetLevel().name + " :: " + closestLevelToPosition.GetLevel().name);
				DEN_DeathFloor dEN_DeathFloor = DEN_DeathFloor.instance;
				if (dEN_DeathFloor != null)
				{
					Debug.Log($"WorldLoader: Deathgoo stats: {{active: {dEN_DeathFloor.IsActive()}, height: {dEN_DeathFloor.transform.position.y}, speed: {dEN_DeathFloor.speed}}}");
				}
				else
				{
					Debug.Log("WorldLoader: Deathgoo does not exist!");
				}
				if (currentLevel.branch != null && currentLevel.branch != closestLevelToPosition.branch)
				{
					ChangeBranch(closestLevelToPosition.branch);
				}
				currentLevel = closestLevelToPosition;
				currentLevel.GetLevel().CycleColliders();
				if (!currentLevel.GetLevel().HasEntered())
				{
					firstTimeEnteringCurrentLevel = true;
					inNewLevel = true;
					latestLevel = currentLevel;
				}
				else if (currentLevel == latestLevel)
				{
					inNewLevel = true;
				}
				else
				{
					inNewLevel = false;
				}
				if (currentLevel.GetLevel().gameObject.activeInHierarchy)
				{
					currentLevel.GetLevel().OnEnter();
				}
			}
			CL_GameManager.SetSafe(b: false);
		}
		if (currentBranch.parentLevel != null)
		{
			CheckLevelLoad(currentBranch.parentLevel, currentLevel, currentBranch.levelTracker[0], currentBranch, lastLevelCheck: false);
		}
		for (int i = 0; i < currentBranch.levelTracker.Count; i++)
		{
			LevelInfo info = currentBranch.levelTracker[i];
			LevelInfo nextLevel = null;
			if (currentBranch.levelTracker.Count > i + 1)
			{
				nextLevel = currentBranch.levelTracker[i + 1];
			}
			if (!CheckLevelLoad(info, currentLevel, nextLevel, currentBranch, i == currentBranch.levelTracker.Count - 1))
			{
				return;
			}
		}
		if (!(currentLevel.spawnedLOD != null) && !currentLevel.GetLevel().isLODGap)
		{
			return;
		}
		HashSet<LevelInfo> hashSet = new HashSet<LevelInfo>();
		List<LevelInfo> list = new List<LevelInfo> { currentLevel };
		HashSet<GameObject> hashSet2 = new HashSet<GameObject>();
		while (list.Count > 0)
		{
			LevelInfo levelInfo = list[0];
			hashSet.Add(levelInfo);
			list.Remove(levelInfo);
			if (levelInfo == null)
			{
				continue;
			}
			if (levelInfo.spawnedLOD != null)
			{
				bool flag = !levelInfo.loaded;
				if (!flag && visibleLODs.Contains(levelInfo.spawnedLOD))
				{
					visibleLODs.Remove(levelInfo.spawnedLOD);
				}
				else if (flag && !visibleLODs.Contains(levelInfo.spawnedLOD))
				{
					visibleLODs.Add(levelInfo.spawnedLOD);
				}
				if (flag)
				{
					hashSet2.Add(levelInfo.spawnedLOD);
				}
				levelInfo.spawnedLOD.gameObject.SetActive(flag);
			}
			for (int j = 0; j < levelInfo.connectedLevels.Count; j++)
			{
				if (!hashSet.Contains(levelInfo.connectedLevels[j]))
				{
					list.Add(levelInfo.connectedLevels[j]);
				}
			}
		}
		for (int num2 = visibleLODs.Count - 1; num2 >= 0; num2--)
		{
			if (!hashSet2.Contains(visibleLODs[num2]) && !(visibleLODs[num2] == null))
			{
				visibleLODs[num2].gameObject.SetActive(value: false);
				visibleLODs.RemoveAt(num2);
			}
		}
		bool CheckLevelLoad(LevelInfo levelInfo2, LevelInfo levelInfo3, LevelInfo item, BranchInfo currentBranch, bool lastLevelCheck)
		{
			bool loaded = levelInfo2.loaded;
			if (levelInfo2 == levelInfo3)
			{
				DrawLevelDebug(levelInfo2, Color.green);
				levelInfo2.GetLevel().gameObject.SetActive(value: true);
				if (levelInfo2.GetLevel().subRegion != null && levelInfo2.GetLevel().region != null)
				{
					if ((levelInfo2.GetLevel().region != currentRegion || levelInfo2.GetLevel().subRegion != currentSubregion) && firstTimeEnteringCurrentLevel && levelInfo2.GetLevel().showIntroText)
					{
						if (levelInfo2.GetLevel().introText != "")
						{
							CL_GameManager.gMan.uiMan.header.ShowText(levelInfo2.GetLevel().introText);
						}
						else if (levelInfo2.GetLevel().subRegion.showIntroText)
						{
							if (CL_GameManager.IsHardmode())
							{
								CL_GameManager.gMan.uiMan.header.ShowText("<size=40><color=red>" + levelInfo2.GetLevel().region.introText + "</size></color>\n<color=grey>" + levelInfo2.GetLevel().subRegion.introText);
							}
							else
							{
								CL_GameManager.gMan.uiMan.header.ShowText("<size=40>" + levelInfo2.GetLevel().region.introText + "</size>\n<color=grey>" + levelInfo2.GetLevel().subRegion.introText);
							}
						}
					}
					currentRegion = levelInfo2.GetLevel().region;
					currentSubregion = levelInfo2.GetLevel().subRegion;
				}
				if (!levelInfo2.GetLevel().HasEntered())
				{
					levelInfo2.GetLevel().OnEnter();
				}
				if (levelInfo2.connectedLevels != null)
				{
					foreach (LevelInfo connectedLevel in levelInfo2.connectedLevels)
					{
						if (connectedLevel != null && !(connectedLevel.GetLevel() == null) && !connectedLevel.GetLevel().gameObject.activeSelf)
						{
							connectedLevel.GetLevel().gameObject.SetActive(value: true);
						}
					}
				}
				levelInfo2.loaded = true;
				levelInfo2.adjacent = false;
				if (lastLevelCheck && !levelInfo2.GetLevel().IsPausingGeneration() && !levelInfo2.stopLevel)
				{
					GenerationParameters generationParameters = new GenerationParameters
					{
						lastRegion = currentBranch.levelTracker[currentBranch.levelTracker.Count - 1].GetLevel().region,
						seedOffset = 1
					};
					Debug.Log($"WorldLoader: Continuing Generation. Last Region: {generationParameters.lastRegion}");
					if (levelInfo2.GetLevel().transform.position.y > 10000f)
					{
						float y = levelInfo2.GetLevel().transform.position.y;
						float num3 = 0f - levelInfo2.GetLevel().transform.position.y + 500f;
						Debug.Log($"WorldLoader: Recentering world due to high Y. Going from {y} to {num3}");
						CL_GameManager.gMan.SetWorldOffset(num3);
					}
					UnloadPreviousLevels(5);
					StartCoroutine(GenerateLevels(GetCurrentBranch(), generationParameters));
					levelInfo2.connectedLevels.Add(item);
					foreach (LevelInfo connectedLevel2 in levelInfo2.connectedLevels)
					{
						if (connectedLevel2 != null && !(connectedLevel2.GetLevel() == null) && !connectedLevel2.GetLevel().gameObject.activeSelf)
						{
							connectedLevel2.GetLevel().gameObject.SetActive(value: true);
						}
					}
					if (!loaded && levelInfo2.loaded)
					{
						levelInfo2.GetLevel().OnLevelActivate();
						onLevelActivate?.Invoke(levelInfo2);
					}
					return false;
				}
			}
			else if (levelInfo3.connectedLevels != null && levelInfo3.connectedLevels.Count > 0 && !levelInfo3.connectedLevels.Contains(levelInfo2))
			{
				levelInfo2.adjacent = false;
				bool flag2 = false;
				foreach (LevelInfo connectedLevel3 in levelInfo2.connectedLevels)
				{
					if (connectedLevel3 != null && connectedLevel3.GetLevel().loadAdjacent && connectedLevel3.loaded && connectedLevel3.adjacent)
					{
						levelInfo2.loaded = true;
						flag2 = true;
						levelInfo2.GetLevel().gameObject.SetActive(value: true);
						DrawLevelDebug(levelInfo2, Color.magenta);
						break;
					}
				}
				if (!flag2 && levelInfo2.GetLevel() != null)
				{
					levelInfo2.GetLevel().gameObject.SetActive(value: false);
					levelInfo2.loaded = false;
					DrawLevelDebug(levelInfo2, Color.red);
				}
			}
			else
			{
				levelInfo2.loaded = true;
				levelInfo2.adjacent = true;
				DrawLevelDebug(levelInfo2, Color.yellow);
			}
			if (!loaded && levelInfo2.loaded)
			{
				levelInfo2.GetLevel().OnLevelActivate();
				onLevelActivate?.Invoke(levelInfo2);
			}
			return true;
		}
	}

	private void DrawLevelDebug(LevelInfo info, Color color)
	{
		if (CL_UIManager.debug && info.GetLevel() != null)
		{
			CL_DebugView.draw.PushMatrix(info.GetLevel().transform.localToWorldMatrix);
			Bounds localBounds = info.GetLevel().GetLocalBounds();
			CL_DebugView.draw.WireBox(localBounds, color);
			string text = "Name: " + info.GetLevel().levelName + "\nBranch: " + info.branch.id;
			CL_DebugView.draw.Label2D(localBounds.max, text, color);
			CL_DebugView.draw.PopMatrix();
		}
	}

	private M_Level GetRandomLevel(int i = 0)
	{
		M_Level m_Level = levelOrdering[UnityEngine.Random.Range(0, levelOrdering.Count)];
		if (i == 0)
		{
			m_Level = introSegments[UnityEngine.Random.Range(0, introSegments.Count)];
		}
		levelOrdering.Remove(m_Level);
		return m_Level;
	}

	private void RefillLevelList()
	{
		levelOrdering = new List<M_Level>();
		foreach (M_Level level in levels)
		{
			levelOrdering.Add(level);
		}
	}

	public static LevelInfo GetClosestLevelToPosition(Vector3 position)
	{
		if (instance == null || instance.GetCurrentBranch().levelTracker == null || instance.GetCurrentBranch().levelTracker.Count == 0)
		{
			return null;
		}
		LevelInfo item = instance.GetCurrentBranch().levelTracker[0];
		if (instance.GetCurrentBranch().currentLevel != null && instance.GetCurrentBranch().levelTracker.Contains(instance.GetCurrentBranch().currentLevel))
		{
			item = instance.GetCurrentBranch().currentLevel;
		}
		Queue<LevelInfo> queue = new Queue<LevelInfo>();
		HashSet<LevelInfo> hashSet = new HashSet<LevelInfo>();
		queue.Enqueue(item);
		hashSet.Add(item);
		float num = float.PositiveInfinity;
		LevelInfo result = null;
		while (queue.Count > 0)
		{
			LevelInfo levelInfo = queue.Dequeue();
			if (levelInfo.GetLevel() == null)
			{
				continue;
			}
			Vector3 point = levelInfo.GetLevel().transform.worldToLocalMatrix.MultiplyPoint(position);
			Bounds localBounds = levelInfo.GetLevel().GetLocalBounds();
			if (localBounds.Contains(point))
			{
				return levelInfo;
			}
			float num2 = localBounds.SqrDistance(point);
			if (num2 < num)
			{
				num = num2;
				result = levelInfo;
			}
			foreach (LevelInfo connectedLevel in levelInfo.connectedLevels)
			{
				if (connectedLevel != null && !hashSet.Contains(connectedLevel) && levelInfo.branch == instance.GetCurrentBranch())
				{
					hashSet.Add(connectedLevel);
					queue.Enqueue(connectedLevel);
				}
			}
		}
		return result;
	}

	public static LevelInfo GetCurrentLevelFromBounds()
	{
		if (instance != null)
		{
			return instance.GetCurrentBranch().currentLevel;
		}
		return null;
	}

	public void TeleportPlayerToTargetLevel(string[] args)
	{
		if (args.Length == 0)
		{
			CommandConsole.Log("Missing name of target level!");
			return;
		}
		foreach (LevelInfo item in GetCurrentBranch().levelTracker)
		{
			if (item.GetLevel().name.ToLower().Replace("(clone)", "").Contains(args[0].ToLower()))
			{
				if (item.GetLevel().spawnPosition != null)
				{
					ENT_Player.playerObject.Teleport(item.GetLevel().GetSpawnPosition());
				}
				else
				{
					ENT_Player.playerObject.Teleport(item.GetLevel().GetLevelEntrance().position + Vector3.up * 5f);
				}
				if (DEN_DeathFloor.instance != null && DEN_DeathFloor.instance.transform.position.y > ENT_Player.playerObject.transform.position.y)
				{
					DEN_DeathFloor.instance.Teleport(ENT_Player.playerObject.transform.position - Vector3.up * 20f);
				}
				break;
			}
		}
	}

	public void TeleportPlayerToLastLevel(string[] args)
	{
		LevelInfo levelInfo = currentBranch.levelTracker[currentBranch.levelTracker.Count - 1];
		ENT_Player.playerObject.Teleport(levelInfo.GetLevel().GetSpawnPosition());
		CommandConsole.Log("Teleported to Last Level");
	}

	public void TeleportPlayerToNextLevel(string[] args)
	{
		List<BranchInfo.LevelId> idsAfter = currentBranch.GetLevelIdsAfterLevel(currentBranch.currentLevel.GetLevel());
		LevelInfo levelInfo = ((idsAfter.Count > 0) ? currentBranch.levelTracker.FirstOrDefault((LevelInfo info) => info.levelID == idsAfter[0]) : null);
		if (levelInfo == null)
		{
			CommandConsole.Log("Began loading next levels.");
			GetCurrentLevel().GetLevel().ContinueGeneration();
			StartCoroutine(WaitThenTeleportToNext());
		}
		else
		{
			TeleportToNext(levelInfo.GetLevel());
		}
		static void TeleportToNext(M_Level level)
		{
			ENT_Player.playerObject.Teleport(level.transform.localToWorldMatrix.MultiplyPoint(level.GetLocalBounds().center));
			CommandConsole.Log("Teleported to Next Level");
		}
		IEnumerator WaitThenTeleportToNext()
		{
			while (isLoaded)
			{
				yield return null;
			}
			while (!isLoaded)
			{
				yield return null;
			}
			TeleportToNext(currentBranch.currentLevel.GetLevel());
		}
	}

	public void ListLoadedLevels(string[] args)
	{
		foreach (LevelInfo item in GetCurrentBranch().levelTracker)
		{
			CommandConsole.Log(item.GetLevel().name.ToLower().Replace("(clone)", "") + " : " + item.GetLevel().transform.position);
		}
	}

	public void GetSeed(string[] args)
	{
		CommandConsole.Log(seed.ToString() ?? "");
	}

	public int GetSeed()
	{
		return seed;
	}

	public static void ReloadWithSeed(string[] args)
	{
		presetSeed = int.Parse(args[0]);
		CL_GameManager.gMan.RestartScene();
	}

	public static void SetPresetSeed(string s)
	{
		presetSeed = int.Parse(s);
	}

	public static Transform GetCurrentLevelParentRoot()
	{
		if (!initialized)
		{
			return null;
		}
		if (instance == null)
		{
			return null;
		}
		if (currentNonLevelParent != null && currentNonLevelParent.gameObject.activeInHierarchy)
		{
			return currentNonLevelParent;
		}
		if (initialized && instance != null && instance.GetCurrentBranch().currentLevel != null)
		{
			return instance.GetCurrentBranch().currentLevel.GetLevel().GetParentRoot();
		}
		return null;
	}

	public static void SetCurrentNonLevelParent(Transform t)
	{
		currentNonLevelParent = t;
	}

	public static Transform GetWorldLoaderNullParent()
	{
		if (instance == null)
		{
			return null;
		}
		if (worldloaderNullParent == null)
		{
			worldloaderNullParent = new GameObject("WORLD-NullParent").transform;
			worldloaderNullParent.parent = instance.transform;
		}
		return worldloaderNullParent;
	}

	internal static void IncrementSeed(int v)
	{
		instance.seed += v;
	}

	internal void SetCurrentLevel(M_Level level)
	{
		foreach (LevelInfo item in GetCurrentBranch().levelTracker)
		{
			if (item.GetLevel() == level)
			{
				GetCurrentBranch().currentLevel = item;
				break;
			}
		}
	}

	private LevelInfo GetLevelInfoFromLevel(M_Level level)
	{
		foreach (LevelInfo item in GetCurrentBranch().levelTracker)
		{
			if (item.GetLevel() == level)
			{
				return item;
			}
		}
		return null;
	}

	public void ClearCurrentGenerator()
	{
		currentGenerator = null;
	}

	public BranchInfo GetCurrentBranch()
	{
		return currentBranch;
	}

	public LevelInfo GetCurrentLevel()
	{
		return currentBranch.currentLevel;
	}

	public void ResumeGeneration()
	{
		currentBranch.currentLevel.stopLevel = false;
	}

	internal void SetOffset(float amount)
	{
		Vector3 vector = Vector3.up * amount;
		foreach (BranchInfo branch in branches)
		{
			foreach (LevelInfo item in branch.levelTracker)
			{
				item.GetLevel().transform.position += vector;
				if (item.spawnedLOD != null)
				{
					item.spawnedLOD.transform.position += vector;
				}
			}
		}
		if (SkyboxManager.activeSkyboxes == null)
		{
			return;
		}
		foreach (GameObject activeSkybox in SkyboxManager.activeSkyboxes)
		{
			if (activeSkybox != null)
			{
				activeSkybox.transform.position += vector;
			}
		}
	}

	public HandholdManager GetHandholdManager()
	{
		return handholdManager;
	}

	public static float GetPlayerLevelDistance()
	{
		return Vector3.Distance(ENT_Player.playerObject.transform.position, instance.levelEntryPosition);
	}

	public static bool IsInNewLevel()
	{
		return inNewLevel;
	}

	internal static void HideWorld()
	{
		instance?.gameObject.SetActive(value: false);
	}

	internal static void ShowWorld()
	{
		instance?.gameObject.SetActive(value: true);
		M_Level obj = instance?.GetCurrentLevel()?.GetLevel();
		obj?.CycleColliders();
		obj?.OnEnter();
	}

	internal bool IsWorldActive()
	{
		return base.gameObject.activeSelf;
	}

	public M_Chamber GetActiveChamber()
	{
		return activeChamber;
	}

	public void SetActiveChamber(M_Chamber c)
	{
		activeChamber = c;
	}

	public void ClearActiveChamber()
	{
		activeChamber = null;
	}

	public M_Level.LevelAssetHolder GetLevelAssetFromLevelName(string levelName)
	{
		return CL_AssetManager.GetLevelAsset(levelName);
	}
}
