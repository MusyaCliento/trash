using System;
using System.Collections;
using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;

public class M_Level : MonoBehaviourGizmos
{
	[Serializable]
	public class LevelAssetHolder
	{
		private static Dictionary<string, AssetReferenceGameObject> loadedLevels;

		public string id;

		public float length;

		public bool setCustomRegionInfo;

		public M_Region region;

		public M_Subregion subregion;

		public AssetReferenceGameObject levelAssetReference;

		public M_Level level;

		public SpawnTable.SpawnSettings spawnSettings;

		public List<string> tags;

		public bool isPausingGeneration;

		public bool pauseGeneration;

		public static LevelAssetHolder GetNewHolderFromLevel(M_Level level)
		{
			return new LevelAssetHolder
			{
				id = level.levelName,
				length = level.GetLength(),
				spawnSettings = level.spawnSettings,
				region = level.region,
				subregion = level.subRegion,
				setCustomRegionInfo = level.setCustomRegionInfo,
				tags = level.tags,
				pauseGeneration = level.pauseGeneration,
				level = level
			};
		}

		public void LoadLevel()
		{
		}

		public bool IsLoaded()
		{
			return true;
		}

		public M_Level GetLevel()
		{
			LoadLevel();
			return level;
		}

		public void UnloadLevelAsset()
		{
		}
	}

	[Serializable]
	public class LoadState
	{
		public string name;

		public bool state;

		public UnityEvent stateEvent;

		public bool resetPlayerPosition;
	}

	[Serializable]
	public class SaveData
	{
		public string levelName;

		public List<string> activeStates;

		public string regionName;

		public string subregionName;

		public bool playerRespawnLevel;

		public Vector3 playerRespawnPositionRelativeToLevel;

		public int seed;

		public List<GameEntity.BaseEntitySaveData> baseEntitySaves;

		public List<SaveableInfo> saveInfos;

		public static void LoadDataIntoLevel(SaveData data, M_Level targetLevel, bool setPlayerPosition = false, bool loadEntities = false, List<string> flags = null)
		{
			Debug.Log("Loading Level: " + data.playerRespawnLevel);
			Debug.Log("Loading Level: " + data.playerRespawnPositionRelativeToLevel);
			if (data.playerRespawnLevel && setPlayerPosition)
			{
				ENT_Player.playerObject.transform.position = targetLevel.transform.TransformPoint(data.playerRespawnPositionRelativeToLevel);
				Debug.Log("Respawn Position: " + targetLevel.transform.TransformPoint(data.playerRespawnPositionRelativeToLevel));
				Debug.Log("Local Respawn Position: " + data.playerRespawnPositionRelativeToLevel);
				Debug.Log("Respawn Level: " + data.playerRespawnPositionRelativeToLevel);
			}
			targetLevel.levelSeed = data.seed;
			targetLevel.UpdateSeedables();
			foreach (string activeState in data.activeStates)
			{
				targetLevel.AddEnableLoadState(activeState);
			}
			if (loadEntities)
			{
				ClearGameEntitiesFromLevel(targetLevel);
				foreach (GameEntity.BaseEntitySaveData baseEntitySafe in data.baseEntitySaves)
				{
					GameObject assetGameObject = CL_AssetManager.GetAssetGameObject(baseEntitySafe.entityID);
					if (!(assetGameObject == null))
					{
						GameObject gameObject = UnityEngine.Object.Instantiate(assetGameObject, targetLevel.transform.TransformPoint(baseEntitySafe.position), baseEntitySafe.rotation, targetLevel.transform);
						gameObject.transform.rotation = targetLevel.transform.rotation * baseEntitySafe.rotation;
						GameEntity component = gameObject.GetComponent<GameEntity>();
						if (component != null)
						{
							component.LoadEntitySaveData(baseEntitySafe);
						}
						Item_Object component2 = gameObject.GetComponent<Item_Object>();
						if (component2 != null && component2.itemData != null)
						{
							component2.itemData.InitializeItemData(component2);
						}
					}
				}
			}
			SaveableObject[] componentsInChildren = targetLevel.GetComponentsInChildren<SaveableObject>();
			Debug.Log("Save Objects: " + componentsInChildren.Length + " Info Count: " + data.saveInfos.Count);
			if (data.saveInfos == null)
			{
				return;
			}
			SaveableObject[] array = componentsInChildren;
			foreach (SaveableObject saveableObject in array)
			{
				if (!saveableObject.CanSave())
				{
					continue;
				}
				foreach (SaveableInfo saveInfo in data.saveInfos)
				{
					if (saveableObject.GetSaveID() != "" && saveableObject.GetSaveID() == saveInfo.id)
					{
						saveableObject.SetSaveInfo(saveInfo, flags);
						break;
					}
				}
			}
		}

		public static SaveData GetSave(M_Level targetLevel, string[] flags = null)
		{
			SaveData saveData = new SaveData();
			saveData.levelName = targetLevel.levelName;
			saveData.activeStates = new List<string>();
			saveData.seed = targetLevel.levelSeed;
			foreach (LoadState loadState in targetLevel.loadStates)
			{
				if (loadState.state)
				{
					saveData.activeStates.Add(loadState.name);
				}
			}
			if (targetLevel.region != null)
			{
				if (targetLevel.region != null)
				{
					saveData.regionName = targetLevel.region.name;
				}
				if (targetLevel.subRegion != null)
				{
					saveData.subregionName = targetLevel.subRegion.name;
				}
			}
			if (ENT_Player.playerObject != null)
			{
				if (WorldLoader.initialized && WorldLoader.GetCurrentLevelFromBounds().GetLevel() == targetLevel)
				{
					Debug.Log("Player is located in this level: " + targetLevel);
					saveData.playerRespawnLevel = true;
					saveData.playerRespawnPositionRelativeToLevel = targetLevel.transform.InverseTransformPoint(ENT_Player.playerObject.transform.position);
				}
				else
				{
					saveData.playerRespawnPositionRelativeToLevel = ENT_Player.playerObject.transform.position;
				}
			}
			saveData.baseEntitySaves = new List<GameEntity.BaseEntitySaveData>();
			GameEntity[] componentsInChildren = targetLevel.GetComponentsInChildren<GameEntity>();
			foreach (GameEntity gameEntity in componentsInChildren)
			{
				if (gameEntity.canSave && gameEntity.isActiveAndEnabled)
				{
					GameEntity.BaseEntitySaveData entitySaveData = gameEntity.GetEntitySaveData();
					entitySaveData.position = targetLevel.transform.InverseTransformPoint(gameEntity.transform.position);
					entitySaveData.rotation = Quaternion.Inverse(targetLevel.transform.rotation) * gameEntity.transform.rotation;
					saveData.baseEntitySaves.Add(entitySaveData);
				}
			}
			saveData.saveInfos = new List<SaveableInfo>();
			SaveableObject[] componentsInChildren2 = targetLevel.GetComponentsInChildren<SaveableObject>();
			Debug.Log("Found Saveable Objects: " + componentsInChildren2.Length);
			SaveableObject[] array = componentsInChildren2;
			foreach (SaveableObject saveableObject in array)
			{
				Debug.Log($"Save Object: {saveableObject.GetSaveID()} :: {saveableObject.CanSave()}");
				if (saveableObject.CanSave(flags))
				{
					saveData.saveInfos.Add(saveableObject.GetSaveInfo());
				}
			}
			return saveData;
		}

		public static void ClearGameEntitiesFromLevel(M_Level targetLevel)
		{
			GameEntity[] componentsInChildren = targetLevel.GetComponentsInChildren<GameEntity>();
			for (int num = componentsInChildren.Length - 1; num >= 0; num--)
			{
				if (componentsInChildren[num].canSave)
				{
					componentsInChildren[num].gameObject.SetActive(value: false);
				}
			}
		}
	}

	public string levelName;

	public Transform levelExit;

	public Transform levelEntrance;

	[Tooltip("The neighborhood ID is used to determine if a level is part of a collection, for the purpose of saving and loading and inserting new content in old saves.")]
	public string levelNeighborhoodID;

	[Space]
	[Tooltip("Is this level considered to have an LOD model when figuring out what LODS are visible?")]
	public bool isLODGap;

	[Tooltip("Level LOD asset that spawns in when the level is unloaded but connected to adjacent LODS")]
	public GameObject lodAsset;

	[Space]
	public Transform spawnPosition;

	[Space]
	public bool lastLevel;

	public bool pauseGeneration;

	internal bool isPausingGeneration;

	[Space]
	public bool showIntroText = true;

	[TextArea]
	public string introText = "";

	public List<CL_GameManager.RichPresencePair> richPresenceOverride = new List<CL_GameManager.RichPresencePair>();

	[Space]
	public UnityEvent enterEvent;

	public string saveName = "";

	private bool hasEntered;

	public bool customBounds;

	public BoxCollider boundsObject;

	public Bounds levelBounds;

	private Bounds currentBoundsLocal;

	private MeshCollider[] meshColliders;

	public List<SessionEventList> sessionEventLists;

	public bool setCustomRegionInfo;

	public M_Region region;

	public M_Subregion subRegion;

	public bool canFlip = true;

	public List<Transform> positiveFlipList = new List<Transform>();

	public List<Transform> negativeFlipList = new List<Transform>();

	private bool flipped;

	public List<LoadState> loadStates;

	public SpawnTable.SpawnSettings spawnSettings;

	public float massSpeedMult = 1f;

	public float hunterSpeedMult = 1f;

	public List<TipList> tips;

	public Transform parentRoot;

	public bool loadAdjacent;

	public bool showInLevelList = true;

	public bool safeArea;

	private int safeAreaID;

	public bool allowEvents = true;

	public List<string> tags;

	public float devTime;

	private int levelSeed;

	private List<string> onEnableRunStates;

	private float levelStartTime;

	private bool timerRunning;

	private List<GameObject> placedObjects;

	private Action spawnAction;

	private HashSet<Action> spawnActionHash;

	[SerializeField]
	private List<UT_Locator> locators;

	private CL_GameManager.RichPresenceMarker richPresenceOverrideMarker;

	private void Awake()
	{
		currentBoundsLocal = CalculateBounds();
	}

	public void OnSpawn(M_Region r, M_Subregion s)
	{
		region = r;
		subRegion = s;
		if (!isPausingGeneration)
		{
			isPausingGeneration = pauseGeneration;
		}
		if (safeArea)
		{
			WorldLoader.safeAreaCount++;
		}
		safeAreaID = WorldLoader.safeAreaCount;
		if (locators == null || locators.Count <= 0)
		{
			return;
		}
		foreach (UT_Locator locator in locators)
		{
			if (locator != null)
			{
				locator.Initialize();
			}
		}
	}

	public void OnLevelActivate()
	{
		WorldLoader.instance.StartCoroutine(RunEnableStates());
		IEnumerator RunEnableStates()
		{
			yield return null;
			if (onEnableRunStates != null)
			{
				foreach (string onEnableRunState in onEnableRunStates)
				{
					PlayLoadState(onEnableRunState);
				}
				onEnableRunStates.Clear();
			}
		}
	}

	public void OnEnter()
	{
		CL_GameManager.RichPresenceMarker marker = default(CL_GameManager.RichPresenceMarker);
		if (CL_GameManager.gMan != null)
		{
			marker = CL_GameManager.gMan.richPresenceBase;
		}
		if (region != null && !string.IsNullOrEmpty(region.richPresenceIdentifier))
		{
			CL_GameManager.RichPresenceSet(marker, "region", region.richPresenceIdentifier);
		}
		if (subRegion != null && !string.IsNullOrEmpty(subRegion.richPresenceIdentifier))
		{
			CL_GameManager.RichPresenceSet(marker, "subregion", subRegion.richPresenceIdentifier);
		}
		CL_GameManager.RichPresencePop(richPresenceOverrideMarker);
		if (richPresenceOverride.Count > 0)
		{
			richPresenceOverrideMarker = CL_GameManager.RichPresencePush();
		}
		foreach (CL_GameManager.RichPresencePair item in richPresenceOverride)
		{
			CL_GameManager.RichPresenceSet(richPresenceOverrideMarker, item.key, item.value);
		}
		if (!hasEntered)
		{
			hasEntered = true;
			enterEvent.Invoke();
			CL_EventManager.EnterLevel(this);
			if (subRegion != null)
			{
				StatManager.saveData.SaveFlag("hasvisited-" + subRegion.subregionName, flagged: true);
			}
		}
	}

	public void OnExit()
	{
		CL_GameManager.RichPresencePop(richPresenceOverrideMarker);
		RemoveTimeTracker();
	}

	private void OnDisable()
	{
		CL_GameManager.RichPresencePop(richPresenceOverrideMarker);
	}

	private void OnValidate()
	{
	}

	public void AddLocators()
	{
		locators = new List<UT_Locator>();
		locators.AddRange(GetComponentsInChildren<UT_Locator>());
	}

	public void SetFlipped(bool b)
	{
		flipped = b;
		foreach (Transform positiveFlip in positiveFlipList)
		{
			if (!(positiveFlip == null))
			{
				positiveFlip.gameObject.SetActive(!flipped);
			}
		}
		foreach (Transform negativeFlip in negativeFlipList)
		{
			if (!(negativeFlip == null))
			{
				negativeFlip.gameObject.SetActive(flipped);
			}
		}
		BoxCollider[] componentsInChildren = GetComponentsInChildren<BoxCollider>();
		foreach (BoxCollider boxCollider in componentsInChildren)
		{
			if (boxCollider.transform.lossyScale.x < 0f || boxCollider.transform.lossyScale.y < 0f || boxCollider.transform.lossyScale.z < 0f)
			{
				boxCollider.size = Vector3.Scale(boxCollider.size, new Vector3(-1f, 1f, 1f));
			}
		}
		_ = flipped;
		Flippable[] componentsInChildren2 = GetComponentsInChildren<Flippable>();
		for (int i = 0; i < componentsInChildren2.Length; i++)
		{
			componentsInChildren2[i].OnFlip(flipped);
		}
	}

	private void FindFlips()
	{
		positiveFlipList = new List<Transform>();
		negativeFlipList = new List<Transform>();
		foreach (Transform item in TraverseHierarchy(base.transform))
		{
			if (item.name.Contains("flip"))
			{
				string[] array = item.name.Split(":");
				if (array[1] == "positive")
				{
					positiveFlipList.Add(item);
				}
				else if (array[1] == "negative")
				{
					negativeFlipList.Add(item);
				}
			}
		}
		SetFlipped(b: false);
	}

	private List<Transform> TraverseHierarchy(Transform root)
	{
		List<Transform> list = new List<Transform>();
		foreach (Transform item in root)
		{
			list.Add(item);
			list.AddRange(TraverseHierarchy(item));
		}
		return list;
	}

	public bool HasEntered()
	{
		return hasEntered;
	}

	public Bounds CalculateBounds()
	{
		if (customBounds)
		{
			if (boundsObject != null)
			{
				Bounds result = new Bounds((boundsObject.transform.localToWorldMatrix * base.transform.worldToLocalMatrix).MultiplyPoint(boundsObject.center), boundsObject.size);
				boundsObject.gameObject.SetActive(value: false);
				return result;
			}
			return new Bounds(levelBounds.center, levelBounds.size);
		}
		Collider[] componentsInChildren = GetComponentsInChildren<Collider>();
		Matrix4x4 worldToLocalMatrix = base.transform.worldToLocalMatrix;
		Bounds result2 = new Bounds(base.transform.position, Vector3.zero);
		Collider[] array = componentsInChildren;
		foreach (Collider collider in array)
		{
			if (collider.gameObject.activeSelf && collider.enabled)
			{
				Bounds bounds = collider.bounds;
				result2.Encapsulate(worldToLocalMatrix.MultiplyPoint(bounds.min));
				result2.Encapsulate(worldToLocalMatrix.MultiplyPoint(bounds.max));
			}
		}
		return result2;
	}

	public override void DrawGizmos()
	{
		if (GizmoContext.InSelection(this))
		{
			Bounds localBounds = GetLocalBounds();
			Draw.PushSetMatrix(base.transform.localToWorldMatrix);
			Draw.WireBox(localBounds, Color.green);
			Draw.PopMatrix();
		}
		if ((bool)spawnPosition)
		{
			Draw.WireCapsule(spawnPosition.position - Vector3.up * 0.75f, spawnPosition.position + Vector3.up * 0.75f, 0.5f, Color.red);
		}
	}

	public Bounds GetLocalBounds()
	{
		_ = currentBoundsLocal;
		return currentBoundsLocal;
	}

	private void Update()
	{
		if (timerRunning)
		{
			LevelStat levelStat = StatManager.instance.GetLevelStat(levelName);
			float num = CL_GameManager.gMan.GetGameTime() - levelStartTime;
			if (levelStat.bestTime == -1f)
			{
				UI_ObjectiveViewer.CreateOrUpdateObjective("timer", "<color=yellow>Level Timer:</color>", "<color=yellow>" + DarkMachineFunctions.SecondsToTimeString(num, "mm\\:ss\\:ff") + "</color>");
			}
			else if (num < levelStat.bestTime)
			{
				UI_ObjectiveViewer.CreateOrUpdateObjective("timer", "<color=yellow>Level Timer:</color>", "<color=yellow>" + DarkMachineFunctions.SecondsToTimeString(num, "mm\\:ss\\:ff") + "</color> / " + DarkMachineFunctions.SecondsToTimeString(levelStat.bestTime, "mm\\:ss\\:ff"));
			}
			else
			{
				UI_ObjectiveViewer.CreateOrUpdateObjective("timer", "<color=yellow>Level Timer:</color>", "<color=red>" + DarkMachineFunctions.SecondsToTimeString(num, "mm\\:ss\\:ff") + "</color> / " + DarkMachineFunctions.SecondsToTimeString(levelStat.bestTime, "mm\\:ss\\:ff"));
			}
		}
		if (CL_UIManager.debug)
		{
			CL_DebugView.draw.Label2D(base.transform.position, "Zone: " + safeAreaID, Color.white);
		}
	}

	public void Initialize(int seed)
	{
		levelSeed = seed;
		meshColliders = GetComponentsInChildren<MeshCollider>();
		UpdateSeedables();
	}

	private void UpdateSeedables()
	{
		Seedable[] componentsInChildren = base.transform.GetComponentsInChildren<Seedable>();
		int num = 0;
		Seedable[] array = componentsInChildren;
		foreach (Seedable obj in array)
		{
			num++;
			obj.SetSeed(levelSeed + num);
		}
	}

	public void CycleColliders()
	{
		if (base.gameObject == null || meshColliders == null || meshColliders.Length == 0)
		{
			return;
		}
		MeshCollider[] array = meshColliders;
		foreach (MeshCollider meshCollider in array)
		{
			if (meshCollider != null && meshCollider.enabled && meshCollider.sharedMesh != null && meshCollider.sharedMesh.vertexCount > 0 && (!meshCollider.sharedMesh.isReadable || meshCollider.sharedMesh.vertices.Length > 2))
			{
				meshCollider.enabled = false;
				meshCollider.enabled = true;
			}
		}
		if (base.gameObject != null && base.gameObject.activeSelf)
		{
			StartCoroutine(Cycle());
		}
		IEnumerator Cycle()
		{
			yield return null;
			if (!(base.gameObject == null))
			{
				MeshCollider[] array2 = meshColliders;
				foreach (MeshCollider meshCollider2 in array2)
				{
					if (meshCollider2 != null && meshCollider2.enabled && meshCollider2.sharedMesh != null && meshCollider2.sharedMesh.vertexCount > 0)
					{
						meshCollider2.enabled = false;
						meshCollider2.enabled = true;
					}
				}
			}
		}
	}

	public float GetHeight()
	{
		return GetLevelExit().position.y - GetLevelEntrance().position.y;
	}

	public float GetLength()
	{
		return Vector3.Distance(GetLevelExit().position, GetLevelEntrance().position);
	}

	public void SetLoadState(string s)
	{
		foreach (LoadState loadState in loadStates)
		{
			if (s == loadState.name)
			{
				Debug.Log("Loading State into " + base.name);
				loadState.stateEvent.Invoke();
				loadState.state = true;
			}
		}
	}

	public void PlayLoadState(string s)
	{
		ENT_Player player = ENT_Player.GetPlayer();
		foreach (LoadState loadState in loadStates)
		{
			try
			{
				if (s == loadState.name)
				{
					Debug.Log("Loading State into " + base.name);
					loadState.stateEvent.Invoke();
					if (spawnPosition != null && loadState.resetPlayerPosition && player != null)
					{
						player.Teleport(spawnPosition.position, spawnPosition.rotation);
					}
					break;
				}
			}
			catch (Exception message)
			{
				if (loadState != null)
				{
					Debug.LogError("M_LEVEL - Issue loading state " + s + " into " + loadState.name);
				}
				else
				{
					Debug.LogError("M_LEVEL - Issue loading state " + s + " into NULL: State does not exist.");
				}
				Debug.LogError(message);
			}
		}
	}

	public void AddEnableLoadState(string s)
	{
		if (onEnableRunStates == null)
		{
			onEnableRunStates = new List<string>();
		}
		onEnableRunStates.Add(s);
	}

	public float GetSpawnChance()
	{
		return spawnSettings.GetEffectiveSpawnChance();
	}

	public bool CanSpawn()
	{
		if (spawnSettings.GetEffectiveSpawnChance() == 0f)
		{
			return false;
		}
		return true;
	}

	public Transform GetParentRoot()
	{
		if (parentRoot == null)
		{
			return base.transform;
		}
		return parentRoot;
	}

	public void ClearGameobjectsInParentRoot()
	{
		if (!(parentRoot == null))
		{
			for (int num = parentRoot.childCount - 1; num >= 0; num--)
			{
				UnityEngine.Object.Destroy(parentRoot.GetChild(num).gameObject);
			}
		}
	}

	public Transform GetLevelEntrance()
	{
		if ((bool)levelEntrance)
		{
			return levelEntrance;
		}
		return base.transform;
	}

	public Transform GetLevelExit()
	{
		if ((bool)levelExit)
		{
			return levelExit;
		}
		return base.transform;
	}

	public void SetMassSpeedMult(float f)
	{
		massSpeedMult = f;
	}

	public void SetAsCurrentLevel()
	{
		if (WorldLoader.initialized && !(WorldLoader.instance == null))
		{
			WorldLoader.instance.SetCurrentLevel(this);
		}
	}

	public void MovePlayerIntoLevelBranch()
	{
		WorldLoader.instance.ChangeToLevelBranch(this);
	}

	public int GetSpawnRoomID()
	{
		return safeAreaID;
	}

	public int GetLevelSeed()
	{
		return levelSeed;
	}

	public bool IsLastLevel()
	{
		return lastLevel;
	}

	public bool DoesPauseGeneration()
	{
		if (!lastLevel && !pauseGeneration)
		{
			return isPausingGeneration;
		}
		return true;
	}

	public bool IsPausingGeneration()
	{
		if (!lastLevel)
		{
			return isPausingGeneration;
		}
		return true;
	}

	public void ContinueGeneration()
	{
		lastLevel = false;
		isPausingGeneration = false;
		WorldLoader.instance.ResumeGeneration();
	}

	public void TimeTrackerStart()
	{
		levelStartTime = CL_GameManager.gMan.GetGameTime();
		timerRunning = true;
		UI_ObjectiveViewer.SetTitle("RACE: " + levelName);
		UI_ObjectiveViewer.CreateOrUpdateObjective("timer", "Level Timer", "00:00", punch: true);
		if (devTime != 0f)
		{
			UI_ObjectiveViewer.CreateOrUpdateObjective("devtime", "<sprite=\"challenge_icons\" name=\"challenge_icons_plat\"> Dev Time", DarkMachineFunctions.SecondsToTimeString(devTime, "mm\\:ss\\:ff"), punch: true);
			float seconds = Mathf.Floor(devTime * 1.35f);
			UI_ObjectiveViewer.CreateOrUpdateObjective("goldtime", "<sprite=\"challenge_icons\" name=\"challenge_icons_gold\"> Gold Time", DarkMachineFunctions.SecondsToTimeString(seconds, "mm\\:ss\\:ff"), punch: true);
			float seconds2 = Mathf.Floor(devTime * 2f);
			UI_ObjectiveViewer.CreateOrUpdateObjective("silvertime", "<sprite=\"challenge_icons\" name=\"challenge_icons_silver\"> Silver Time", DarkMachineFunctions.SecondsToTimeString(seconds2, "mm\\:ss\\:ff"), punch: true);
		}
	}

	public void TimeTrackerEnd()
	{
		if (!timerRunning)
		{
			return;
		}
		timerRunning = false;
		float num = CL_GameManager.gMan.GetGameTime() - levelStartTime;
		LevelStat levelStat = StatManager.instance.GetLevelStat(levelName);
		levelStat.AddTime(num);
		string text = DarkMachineFunctions.SecondsToTimeString(num, "mm\\:ss\\:ff");
		_ = devTime;
		string text2 = "";
		if (devTime != 0f && num <= devTime)
		{
			text2 = "<color=grey>Dev Time Beaten (" + DarkMachineFunctions.SecondsToTimeString(devTime, "mm\\:ss\\:ff") + ")";
		}
		if (levelStat.bestTime == -1f || num < levelStat.bestTime)
		{
			UI_ObjectiveViewer.CreateOrUpdateObjective("timer", "<color=yellow>New Best Time!</color>", "<color=yellow>" + text + "</color>", punch: true);
			levelStat.bestTime = num;
			CL_UIManager.instance.tipHeader.ShowText("<color=yellow>New Best Time: " + text + "\n" + text2);
			AudioManager.PlayUISound("ui_challenge_major_objective_earned");
		}
		else
		{
			string text3 = DarkMachineFunctions.SecondsToTimeString(levelStat.bestTime, "mm\\:ss\\:ff");
			UI_ObjectiveViewer.CreateOrUpdateObjective("timer", "<color=yellow>Level Timer:</color>", "<color=red>" + text + " | Best: " + text3 + "</color>", punch: true);
			CL_UIManager.instance.tipHeader.ShowText("<color=red>New Time: " + text + " | Best: " + text3);
			AudioManager.PlayUISound("ui_challenge_failed");
		}
		if (devTime != 0f)
		{
			if (num <= devTime)
			{
				UI_ObjectiveViewer.CreateOrUpdateObjective("devtime", "<sprite=\"challenge_icons\" name=\"challenge_icons_plat\"> <color=green>Dev Time Beaten", DarkMachineFunctions.SecondsToTimeString(devTime, "mm\\:ss\\:ff"), punch: true);
			}
			float num2 = Mathf.Floor(devTime * 1.35f);
			if (num <= num2)
			{
				UI_ObjectiveViewer.CreateOrUpdateObjective("goldtime", "<sprite=\"challenge_icons\" name=\"challenge_icons_gold\"> <color=green>Gold Time Beaten", DarkMachineFunctions.SecondsToTimeString(num2, "mm\\:ss\\:ff"), punch: true);
			}
			float num3 = Mathf.Floor(devTime * 2f);
			if (num <= num3)
			{
				UI_ObjectiveViewer.CreateOrUpdateObjective("silvertime", "<sprite=\"challenge_icons\" name=\"challenge_icons_silver\"> <color=green>Silver Time Beaten", DarkMachineFunctions.SecondsToTimeString(num3, "mm\\:ss\\:ff"), punch: true);
			}
		}
		StatManager.instance.SaveLevelStat(levelStat);
	}

	public void RemoveTimeTracker()
	{
		timerRunning = false;
	}

	internal void AddPlacedObject(GameObject o)
	{
		if (placedObjects == null)
		{
			placedObjects = new List<GameObject>();
		}
		placedObjects.Add(o);
	}

	public void DestroyPlacedObjects()
	{
		if (placedObjects == null || placedObjects.Count == 0)
		{
			return;
		}
		for (int num = placedObjects.Count - 1; num >= 0; num--)
		{
			if (!(placedObjects[num] == null))
			{
				UnityEngine.Object.Destroy(placedObjects[num]);
			}
		}
		placedObjects.Clear();
	}

	public void AddSpawnAction(Action a)
	{
		if (spawnActionHash == null)
		{
			spawnActionHash = new HashSet<Action>();
		}
		if (!spawnActionHash.Contains(a))
		{
			spawnAction = (Action)Delegate.Combine(spawnAction, a);
			spawnActionHash.Add(a);
		}
	}

	public bool HasTag(string t)
	{
		if (tags != null && tags.Count > 0 && tags.Contains(t))
		{
			return true;
		}
		return false;
	}

	public Vector3 GetSpawnPosition()
	{
		if (spawnPosition != null)
		{
			return spawnPosition.position;
		}
		return base.transform.position + Vector3.up * 5f;
	}

	public Transform GetSpawnPositionTransform()
	{
		if (spawnPosition != null)
		{
			return spawnPosition;
		}
		return base.transform;
	}

	public M_Level GetAdjacentLevel(int offset = 1)
	{
		WorldLoader.BranchInfo branchOfLevel = WorldLoader.instance.GetBranchOfLevel(this);
		if (branchOfLevel == null)
		{
			return null;
		}
		int num = branchOfLevel.levelTracker.IndexOf(branchOfLevel.GetLevelInfoFromLevel(this));
		num += offset;
		if (num < 0 || num > branchOfLevel.levelTracker.Count - 1)
		{
			return null;
		}
		return branchOfLevel.levelTracker[num + offset].GetLevel();
	}
}
