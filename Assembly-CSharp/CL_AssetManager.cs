using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[Serializable]
public class CL_AssetManager
{
	public class WKDatabaseHolder
	{
		public string id;

		public WKAssetDatabase database;

		private Dictionary<string, GameObject> assetDictionary;

		private Dictionary<string, AssetReferenceGameObject> addressibleAssetDictionary;

		public void RefreshDictionary()
		{
			assetDictionary = new Dictionary<string, GameObject>();
			addressibleAssetDictionary = new Dictionary<string, AssetReferenceGameObject>();
			FillObjectDictionaryFromList(database.itemPrefabs);
			FillObjectDictionaryFromList(database.entityPrefabs);
			foreach (M_Level.LevelAssetHolder levelAsset in database.levelAssets)
			{
				addressibleAssetDictionary.Add(levelAsset.id, levelAsset.levelAssetReference);
			}
			void FillObjectDictionaryFromList(List<GameObject> objectList)
			{
				foreach (GameObject @object in objectList)
				{
					if (!assetDictionary.ContainsKey(@object.name))
					{
						assetDictionary.Add(@object.name, @object);
					}
				}
			}
		}

		public GameObject GetAssetFromDictionary(string id)
		{
			return assetDictionary[id];
		}

		public bool HasAssetInDictionary(string id)
		{
			if (assetDictionary == null)
			{
				RefreshDictionary();
			}
			if (assetDictionary == null || id == null || id == "")
			{
				return false;
			}
			return assetDictionary.ContainsKey(id);
		}
	}

	private static UT_Null loaderObject;

	private static List<WKDatabaseHolder> databases;

	private static Dictionary<string, WKDatabaseHolder> activeDatabases;

	public List<M_Level> levelPrefabs;

	public static WKAssetDatabase baseDatabase;

	public static CL_AssetManager instance;

	private bool initialized;

	private static UT_Null GetLoaderObject()
	{
		if (loaderObject == null)
		{
			loaderObject = new GameObject("WKLOADER").AddComponent<UT_Null>();
		}
		return loaderObject;
	}

	public void Initialize()
	{
		if (!initialized)
		{
			initialized = true;
			instance = this;
		}
	}

	public static GameObject GetAssetGameObject(string name, string database = "")
	{
		if (instance == null || databases == null)
		{
			InitializeAssetManager();
		}
		bool flag = database != "" && database != null;
		foreach (WKDatabaseHolder database2 in databases)
		{
			if ((!flag || !(database2.id != database)) && database2.HasAssetInDictionary(name))
			{
				return database2.GetAssetFromDictionary(name);
			}
		}
		Debug.LogWarning("Entity Not Found in Asset Database: " + name);
		return null;
	}

	public static M_Region GetRegionAsset(string name, string database = "")
	{
		bool flag = database != "" && database != null;
		foreach (WKDatabaseHolder database2 in databases)
		{
			if (flag && database2.id != database)
			{
				continue;
			}
			foreach (M_Region regionAsset in database2.database.regionAssets)
			{
				if (regionAsset.name == name)
				{
					return regionAsset;
				}
			}
		}
		return null;
	}

	public static M_Subregion GetSubregionAsset(string name, string database = "")
	{
		bool flag = database != "" && database != null;
		foreach (WKDatabaseHolder database2 in databases)
		{
			if (flag && database2.id != database)
			{
				continue;
			}
			foreach (M_Subregion subRegionAsset in database2.database.subRegionAssets)
			{
				if (subRegionAsset.name == name)
				{
					return subRegionAsset;
				}
			}
		}
		return null;
	}

	public static M_Level.LevelAssetHolder GetLevelAsset(string name, string database = "")
	{
		bool flag = database != "" && database != null;
		foreach (WKDatabaseHolder database2 in databases)
		{
			if (flag && database2.id != database)
			{
				continue;
			}
			foreach (M_Level.LevelAssetHolder levelAsset in database2.database.levelAssets)
			{
				if (levelAsset.id.ToLower() == name.ToLower())
				{
					return levelAsset;
				}
			}
		}
		return null;
	}

	public static void UnloadAllLevels()
	{
		foreach (WKDatabaseHolder database in databases)
		{
			foreach (M_Level.LevelAssetHolder levelAsset in database.database.levelAssets)
			{
				if (levelAsset.levelAssetReference.Asset != null)
				{
					levelAsset.UnloadLevelAsset();
				}
			}
		}
	}

	public static M_Gamemode GetGamemodeAsset(string name, string database = "")
	{
		bool flag = database != "" && database != null;
		foreach (WKDatabaseHolder database2 in databases)
		{
			if (flag && database2.id != database)
			{
				continue;
			}
			foreach (M_Gamemode gamemodeAsset in database2.database.gamemodeAssets)
			{
				if (gamemodeAsset.gamemodeName == name || gamemodeAsset.name == name)
				{
					return gamemodeAsset;
				}
			}
		}
		return null;
	}

	public static OS_DiskData GetDiskDataAsset(string id, string database = "")
	{
		bool flag = database != "" && database != null;
		foreach (WKDatabaseHolder database2 in databases)
		{
			if (flag && database2.id != database)
			{
				continue;
			}
			foreach (OS_DiskData diskDatum in database2.database.diskData)
			{
				if (diskDatum.id == id)
				{
					return diskDatum;
				}
			}
		}
		return null;
	}

	public static Sprite GetSpriteAsset(string name, string database = "")
	{
		bool flag = database != "" && database != null;
		foreach (WKDatabaseHolder database2 in databases)
		{
			if (flag && database2.id != database)
			{
				continue;
			}
			foreach (Sprite spriteAsset in database2.database.spriteAssets)
			{
				if (!(spriteAsset == null) && spriteAsset.name == name)
				{
					return spriteAsset;
				}
			}
		}
		return null;
	}

	public static Item_Object GetItemObjectPrefab(string id, string database = "")
	{
		bool flag = database != "" && database != null;
		foreach (WKDatabaseHolder database2 in databases)
		{
			if (flag && database2.id != database)
			{
				continue;
			}
			foreach (GameObject itemPrefab in database2.database.itemPrefabs)
			{
				Item_Object component = itemPrefab.GetComponent<Item_Object>();
				if (!(component == null) && component.itemData.prefabName.ToLower() == id.ToLower())
				{
					return component;
				}
			}
		}
		return null;
	}

	public static Perk GetPerkAsset(string id, string database = "")
	{
		bool flag = database != "" && database != null;
		foreach (WKDatabaseHolder database2 in databases)
		{
			if (flag && database2.id != database)
			{
				continue;
			}
			foreach (Perk perkAsset in database2.database.perkAssets)
			{
				if (perkAsset.id.ToLower().Contains(id.ToLower()))
				{
					return perkAsset;
				}
			}
		}
		return null;
	}

	public static Trinket GetTrinketAsset(string id, string database = "")
	{
		bool flag = database != "" && database != null;
		foreach (WKDatabaseHolder database2 in databases)
		{
			if (flag && database2.id != database)
			{
				continue;
			}
			foreach (Trinket trinketAsset in database2.database.trinketAssets)
			{
				if (trinketAsset.name.ToLower().Contains(id.ToLower()))
				{
					return trinketAsset;
				}
			}
		}
		return null;
	}

	public static Facility GetFacilityAsset(string id, string database = "")
	{
		bool flag = database != "" && database != null;
		foreach (WKDatabaseHolder database2 in databases)
		{
			if (flag && database2.id != database)
			{
				continue;
			}
			foreach (Facility facilityAsset in database2.database.facilityAssets)
			{
				if (facilityAsset.id.ToLower().Contains(id.ToLower()))
				{
					return facilityAsset;
				}
			}
		}
		return null;
	}

	public static SessionEvent GetSessionEvent(string name, string database = "")
	{
		bool flag = database != "" && database != null;
		foreach (WKDatabaseHolder database2 in databases)
		{
			if (flag && database2.id != database)
			{
				continue;
			}
			foreach (SessionEvent sessionEvent in database2.database.sessionEvents)
			{
				if (sessionEvent.name == name || sessionEvent.name == name)
				{
					return sessionEvent;
				}
			}
		}
		return null;
	}

	public static Cosmetic_Item GetCosmeticItemAsset(string id, string database = "")
	{
		bool flag = database != "" && database != null;
		foreach (WKDatabaseHolder database2 in databases)
		{
			if (flag && database2.id != database)
			{
				continue;
			}
			foreach (Cosmetic_Item cosmeticItem in database2.database.cosmeticItems)
			{
				if (cosmeticItem.cosmeticInfo.id == id)
				{
					return cosmeticItem;
				}
			}
		}
		return null;
	}

	public static GameObject GetNullItemObject()
	{
		return databases[0].database.nullItemObject;
	}

	public static void InitializeDatabases()
	{
		if (databases == null && !(baseDatabase == null))
		{
			databases = new List<WKDatabaseHolder>();
			activeDatabases = new Dictionary<string, WKDatabaseHolder>();
			WKAssetDatabase wKAssetDatabase = baseDatabase;
			AddNewDatabase(wKAssetDatabase.id, wKAssetDatabase);
		}
	}

	public static void AddNewDatabase(string id, WKAssetDatabase database)
	{
		if (databases == null || databases.Count == 0)
		{
			InitializeDatabases();
		}
		if (!activeDatabases.ContainsKey(id))
		{
			WKDatabaseHolder wKDatabaseHolder = new WKDatabaseHolder
			{
				id = id,
				database = database
			};
			wKDatabaseHolder.RefreshDictionary();
			CommandConsole.Log("Initialized Asset Database: " + id);
			activeDatabases.Add(id, wKDatabaseHolder);
			databases.Add(wKDatabaseHolder);
		}
	}

	public static WKAssetDatabase GetDatabase(string id)
	{
		if (databases == null)
		{
			Debug.LogError("No databases found. Initialize databases before you attempt to call.");
			return null;
		}
		if (activeDatabases.ContainsKey(id))
		{
			return activeDatabases[id].database;
		}
		Debug.LogError("Error: No database of " + id + " found in database.");
		return null;
	}

	public static void RemoveDatabase(string id)
	{
		if (activeDatabases.ContainsKey(id))
		{
			WKDatabaseHolder item = activeDatabases[id];
			activeDatabases.Remove(id);
			databases.Remove(item);
			CommandConsole.Log("Database " + id + " Removed.");
		}
	}

	public static void InitializeAssetManager()
	{
		if ((instance == null || databases == null) && !(baseDatabase == null))
		{
			InitializeDatabases();
			instance = new CL_AssetManager();
			instance.Initialize();
		}
	}

	private static WKAssetDatabase GetStandardDatabaseAssetFromResources()
	{
		return Resources.Load<WKAssetDatabase>("WK_AssetDatabase");
	}

	public static CL_AssetManager GetAssetManager()
	{
		if (instance != null)
		{
			return instance;
		}
		InitializeAssetManager();
		return instance;
	}

	public static WKAssetDatabase GetBaseAssetDatabase()
	{
		return databases[0].database;
	}

	public static void RefreshDatabaseList()
	{
		foreach (WKDatabaseHolder database in databases)
		{
			database.RefreshDictionary();
		}
	}

	public static WKAssetDatabase GetFullCombinedAssetDatabase()
	{
		WKAssetDatabase wKAssetDatabase = new WKAssetDatabase
		{
			denizenPrefabs = new List<GameObject>(),
			entityPrefabs = new List<GameObject>(),
			itemPrefabs = new List<GameObject>(),
			levelAssets = new List<M_Level.LevelAssetHolder>(),
			regionAssets = new List<M_Region>(),
			subRegionAssets = new List<M_Subregion>(),
			gamemodeAssets = new List<M_Gamemode>(),
			perkAssets = new List<Perk>(),
			diskData = new List<OS_DiskData>(),
			sessionEvents = new List<SessionEvent>(),
			spriteAssets = new List<Sprite>()
		};
		foreach (WKDatabaseHolder database in databases)
		{
			wKAssetDatabase.denizenPrefabs.AddRange(database.database.denizenPrefabs);
			wKAssetDatabase.entityPrefabs.AddRange(database.database.entityPrefabs);
			wKAssetDatabase.itemPrefabs.AddRange(database.database.itemPrefabs);
			wKAssetDatabase.levelAssets.AddRange(database.database.levelAssets);
			wKAssetDatabase.regionAssets.AddRange(database.database.regionAssets);
			wKAssetDatabase.subRegionAssets.AddRange(database.database.subRegionAssets);
			wKAssetDatabase.gamemodeAssets.AddRange(database.database.gamemodeAssets);
			wKAssetDatabase.perkAssets.AddRange(database.database.perkAssets);
			wKAssetDatabase.diskData.AddRange(database.database.diskData);
			wKAssetDatabase.sessionEvents.AddRange(database.database.sessionEvents);
			wKAssetDatabase.spriteAssets.AddRange(database.database.spriteAssets);
			wKAssetDatabase.cosmeticHands.AddRange(database.database.cosmeticHands);
			wKAssetDatabase.cosmeticItems.AddRange(database.database.cosmeticItems);
			wKAssetDatabase.cosmeticVoices.AddRange(database.database.cosmeticVoices);
		}
		return wKAssetDatabase;
	}
}
