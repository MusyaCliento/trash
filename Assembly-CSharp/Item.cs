using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Item
{
	public enum InteractType
	{
		none = 0,
		roach = 1,
		usable = 2
	}

	[Serializable]
	public class DataModuleSave
	{
		public string type;

		public string moduleData;

		public string saveData;
	}

	public enum UnlockType
	{
		none = 0,
		progression = 1,
		stat = 2
	}

	public string itemName;

	public string itemTag;

	public List<string> itemTags;

	[Space]
	public string prefabName;

	public float inventoryScale = 1f;

	public float lockboxScale = 1f;

	public float itemWeight = 1f;

	internal float currentWeightMult = 1f;

	[Tooltip("This is rarely set manually, determines the data state of the object")]
	public bool used;

	public bool allowCosmetics = true;

	private bool isCosmetic;

	public bool cosmeticMesh = true;

	[Tooltip("How hard is this item thrown from the player when dropped?")]
	public float dropVel;

	[Tooltip("Does this item fit in pockets?")]
	public bool pocketable = true;

	public bool pouchable = true;

	[Tooltip("The direction that this object points in the inventory.")]
	public Vector3 upDirection = Vector3.up;

	public InteractType interactType;

	public string customDropLayer = "Interactable No Collide";

	[TextArea(4, 15)]
	public List<string> data;

	[SerializeReference]
	public List<Item_Data> dataModules;

	public int worth = 2;

	[HideInInspector]
	public List<DataModuleSave> dataModuleSaves;

	[HideInInspector]
	public Vector3 bagPosition;

	[HideInInspector]
	public Quaternion bagRotation;

	[HideInInspector]
	public Inventory inventory;

	public Sprite normalSprite;

	public Item_Object itemAsset;

	public HandItem handItemAsset;

	public List<AudioClip> pickupSounds;

	public bool useFlags;

	public string flagOnPickup;

	public string flagOnDrop;

	public string pickupStat = "";

	public UnlockType unlockType;

	public string progressionUnlockID;

	public string statUnlockName;

	public int statUnlockAmount;

	public Sprite unlockSprite;

	public string unlockTextDesc;

	public int respawnLimit = -1;

	public string respawnLimitFlagID = "";

	private Item_Object dropObject;

	private Vector2 offset;

	private HandItem handItem;

	private Image itemImage;

	private ENT_Player.Hand pHand;

	[HideInInspector]
	public bool inBag;

	private bool initialized;

	private bool objectInitialized;

	public bool hasBeenPickedUp;

	public bool hasBeenDestroyed;

	public string itemGUID;

	[SerializeReference]
	public List<ItemExecutionModule> executionModules;

	public Action<Item> _OnPickupAction;

	public Action<Item> _OnClearDropObject;

	public Action<Item> _OnDropAction;

	public Action<string, string> _OnDataAdjust;

	public virtual void Initialize()
	{
		if (initialized || hasBeenDestroyed)
		{
			return;
		}
		initialized = true;
		if (allowCosmetics && !isCosmetic)
		{
			Cosmetic_Item activeItemCosmetic = CL_CosmeticManager.GetActiveItemCosmetic(prefabName);
			if (activeItemCosmetic != null)
			{
				if (activeItemCosmetic.swapItem != null)
				{
					Item_Object item_Object = UnityEngine.Object.Instantiate(activeItemCosmetic.swapItem, GetDropObject().transform.position, GetDropObject().transform.rotation, GetDropObject().transform.parent);
					item_Object.itemData.isCosmetic = true;
					item_Object.itemData.prefabName = prefabName;
					item_Object.itemData.itemName = itemName;
					Rigidbody component = item_Object.GetComponent<Rigidbody>();
					Rigidbody component2 = GetDropObject().GetComponent<Rigidbody>();
					if (component != null)
					{
						if (component2 != null)
						{
							component.isKinematic = component2.isKinematic;
						}
						if (InInventory())
						{
							component.isKinematic = true;
						}
					}
					item_Object.gameObject.layer = GetDropObject().gameObject.layer;
					CL_Prop component3 = item_Object.GetComponent<CL_Prop>();
					CL_Prop component4 = GetDropObject().GetComponent<CL_Prop>();
					if ((bool)component3 && (bool)component4)
					{
						component3.entityPrefabID = component4.entityPrefabID;
					}
					item_Object.itemData.InitializeItemData(item_Object);
					if (InInventory())
					{
						inventory.RescanInventory();
					}
					Destroy();
					return;
				}
				if (activeItemCosmetic.swapMesh != null)
				{
					MeshRenderer componentInChildren = GetDropObject().GetComponentInChildren<MeshRenderer>();
					MeshFilter component5 = componentInChildren.GetComponent<MeshFilter>();
					if (componentInChildren != null)
					{
						component5.mesh = activeItemCosmetic.swapMesh;
						componentInChildren.material = activeItemCosmetic.swapMaterial;
					}
				}
			}
		}
		if (executionModules == null || executionModules.Count <= 0)
		{
			return;
		}
		foreach (ItemExecutionModule executionModule in executionModules)
		{
			if (executionModule.item != this)
			{
				executionModule.Initialize(this);
			}
		}
	}

	public virtual void InitializeItemData(Item_Object selfObject)
	{
		if (dropObject == null)
		{
			dropObject = selfObject;
		}
		Initialize();
		if (objectInitialized || hasBeenDestroyed)
		{
			return;
		}
		itemGUID = Guid.NewGuid().ToString();
		objectInitialized = true;
		try
		{
			itemAsset = CL_AssetManager.GetAssetGameObject(prefabName).GetComponent<Item_Object>();
		}
		catch
		{
			Debug.LogError("Cannot find asset " + prefabName + " in Asset Manager! Make sure an asset with that name exists in there, or that this prefab has an asset ID assigned!");
		}
	}

	public void InitializeInHand(Inventory inv, ENT_Player.Hand h)
	{
		Initialize();
		Debug.Log("Initializing In Hand: " + prefabName + " :: " + handItemAsset?.ToString() + " :: " + itemName);
		if (hasBeenDestroyed)
		{
			return;
		}
		if (handItemAsset == null)
		{
			CopyNonDataFromItemAsset();
			Debug.Log("Checking For Asset: " + prefabName + " :: " + handItemAsset?.ToString() + " :: " + itemName);
			if (handItemAsset == null)
			{
				Debug.Log("Missing Asset: " + prefabName + " :: " + itemName);
			}
		}
		pHand = h;
		inventory = inv;
		Vector3 position = h.inventoryHand.handInventoryRoot.TransformPoint(Vector3.up * -0.22f);
		handItem = UnityEngine.Object.Instantiate(handItemAsset, position, inv.playerInventoryRoot.rotation, inv.playerInventoryRoot);
		Vector3 localScale = handItem.transform.localScale;
		localScale.x = ((h.id == 0) ? (0f - localScale.x) : localScale.x);
		handItem.transform.localScale = localScale;
		handItem.Initialize(this, h);
		if (dropObject == null)
		{
			CreateDropObject();
		}
		dropObject.gameObject.SetActive(value: false);
		if (useFlags && flagOnPickup != "")
		{
			CL_GameManager.SetGameFlag(flagOnPickup, state: true);
		}
	}

	public virtual void Execute(Inventory inv)
	{
		if (dropObject != null)
		{
			dropObject.Execute(inv);
		}
		if (executionModules == null || executionModules.Count <= 0)
		{
			return;
		}
		foreach (ItemExecutionModule executionModule in executionModules)
		{
			executionModule.Execute();
		}
	}

	public virtual void FixedExecute(Inventory inv)
	{
		if (dropObject != null)
		{
			dropObject.FixedExecute(inv);
		}
	}

	private void OnDestroy()
	{
	}

	public HandItem GetHandItem()
	{
		return handItem;
	}

	public virtual string GetFullItemName()
	{
		return itemName;
	}

	public void Flash(Color c)
	{
		itemImage.color = c;
		UI_TabFade component = itemImage.gameObject.GetComponent<UI_TabFade>();
		if (component != null)
		{
			component.delayTime = 0.5f;
		}
	}

	public virtual void ActivateItem(Inventory.ItemHand hand)
	{
		handItem.gameObject.SetActive(value: true);
		handItem.GetComponent<ViewSway>().targetOffset = Vector3.up * 0.3f;
		handItem.GetComponent<ViewSway>().animationOffset = hand.hand.id * 5;
		handItem.active = true;
	}

	public virtual bool CanUse()
	{
		return true;
	}

	public virtual void SetUsed(bool b)
	{
		used = b;
	}

	public virtual void Use()
	{
		handItem.TryUse();
	}

	public virtual void StopUse()
	{
		handItem.StopUse();
	}

	public void Drop(Vector3 pos, bool removeFromHand = true)
	{
		inventory.DropItemIntoWorld(this, pos, removeFromHand);
	}

	public void PlaceInWorld(Vector3 pos, bool removeFromHand = true)
	{
		OnDrop();
		GetDropObject().OnDrop();
		if (itemAsset == null)
		{
			try
			{
				itemAsset = CL_AssetManager.GetAssetGameObject(prefabName).GetComponent<Item_Object>();
			}
			catch
			{
				Debug.LogError("Cannot find asset " + prefabName + " in Asset Manager! Make sure an asset with that name exists in there, or that this prefab has an asset ID assigned!");
				return;
			}
		}
		if (dropObject != null)
		{
			dropObject.transform.position = pos;
			dropObject.gameObject.SetActive(value: true);
		}
		else
		{
			CreateDropObject().transform.position = pos;
			dropObject.gameObject.SetActive(value: true);
			dropObject.itemData = this;
		}
		dropObject.transform.parent = WorldLoader.GetCurrentLevelParentRoot();
		dropObject.itemData = this;
		Rigidbody component = dropObject.GetComponent<Rigidbody>();
		if (component != null)
		{
			component.linearVelocity = Vector3.zero;
		}
		CL_Prop component2 = dropObject.GetComponent<CL_Prop>();
		if (component2 != null)
		{
			component2.Drop();
		}
		if (removeFromHand && handItem != null)
		{
			UnityEngine.Object.Destroy(handItem.gameObject);
		}
		handItem = null;
	}

	public void SetItemAsset(Item_Object asset)
	{
		Debug.Log("ITEM: Setting item asset for " + prefabName + " to " + asset.name);
		itemAsset = asset;
		prefabName = asset.name;
		itemName = asset.itemData.itemName;
		itemTag = asset.itemData.itemTag;
		itemTags = new List<string>(asset.itemData.itemTags);
		itemGUID = asset.itemData.itemGUID;
		inventoryScale = asset.itemData.inventoryScale;
		lockboxScale = asset.itemData.lockboxScale;
		itemWeight = asset.itemData.itemWeight;
		pocketable = asset.itemData.pocketable;
		pouchable = asset.itemData.pouchable;
		interactType = asset.itemData.interactType;
		customDropLayer = asset.itemData.customDropLayer;
		data = new List<string>(asset.itemData.data);
		ClearDropObject();
		CreateDropObject();
	}

	public void ClearDropObject()
	{
		if (!(dropObject != null))
		{
			return;
		}
		initialized = false;
		_OnClearDropObject?.Invoke(this);
		UnityEngine.Object.Destroy(GetDropObject().gameObject);
		if (executionModules != null && executionModules.Count > 0)
		{
			foreach (ItemExecutionModule executionModule in executionModules)
			{
				executionModule.OnDestroy();
			}
		}
		dropObject = null;
	}

	public void SetDropObject(Item_Object ob)
	{
		dropObject = ob;
		dropVel = dropObject.itemData.dropVel;
	}

	public Item_Object CreateDropObject()
	{
		Debug.Log($"ITEM: Creating Drop Object - {itemName} :: {itemAsset} :: {handItemAsset}");
		if (itemAsset == null)
		{
			GameObject assetGameObject = CL_AssetManager.GetAssetGameObject(prefabName);
			if (assetGameObject != null)
			{
				itemAsset = assetGameObject.GetComponent<Item_Object>();
				if (itemAsset == null)
				{
					Debug.LogError("ITEM: Error! Could not find asset from database for " + prefabName + " : Missing Item Component");
					Debug.LogError("ITEM: Creating temp drop object from database to substitute.");
					itemAsset = CL_AssetManager.GetNullItemObject().GetComponent<Item_Object>();
				}
			}
			else
			{
				Debug.LogError("ITEM: Error! Could not find asset gameobject from database for " + prefabName);
				Debug.LogError("ITEM: Creating temp drop object from database to substitute.");
				itemAsset = CL_AssetManager.GetNullItemObject().GetComponent<Item_Object>();
			}
		}
		Item_Object item_Object = UnityEngine.Object.Instantiate(itemAsset, Vector3.zero, Quaternion.Euler(UnityEngine.Random.insideUnitSphere * 360f));
		item_Object.gameObject.SetActive(value: false);
		item_Object.itemData = this;
		dropObject = item_Object;
		Debug.Log("ITEM: Creating Drop Object - FINISHED");
		return item_Object;
	}

	public Item_Object GetDropObject(bool createIfNotExisting = true)
	{
		if (createIfNotExisting && dropObject == null)
		{
			CreateDropObject();
		}
		return dropObject;
	}

	public virtual void Interact(Interaction interaction, ref bool interacting, ref InteractHit hit, out Sprite interactSprite)
	{
		if (handItem != null)
		{
			handItem.Interact(interaction, ref interacting, ref hit, out interactSprite);
		}
		else
		{
			interactSprite = null;
		}
	}

	public Item GetClone(Item prefab = null, bool copyNonDataFromItemAsset = false)
	{
		Item item = new Item();
		if (copyNonDataFromItemAsset)
		{
			CopyNonDataFromItemAsset();
		}
		Save();
		item.itemName = itemName;
		item.prefabName = prefabName;
		item.inventoryScale = inventoryScale;
		item.lockboxScale = lockboxScale;
		item.used = used;
		item.dropVel = dropVel;
		item.pocketable = pocketable;
		item.pouchable = pouchable;
		item.upDirection = upDirection;
		item.interactType = interactType;
		item.data = new List<string>();
		item.data.AddRange(data);
		item.dataModules = new List<Item_Data>();
		item.dataModules.AddRange(dataModules);
		item.hasBeenPickedUp = hasBeenPickedUp;
		item.respawnLimitFlagID = respawnLimitFlagID;
		item.respawnLimit = respawnLimit;
		item.dataModuleSaves = new List<DataModuleSave>();
		item.dataModuleSaves.AddRange(dataModuleSaves);
		if (prefab != null)
		{
			item.normalSprite = prefab.normalSprite;
			item.itemAsset = prefab.itemAsset;
			item.handItemAsset = prefab.handItemAsset;
			item.pickupSounds = prefab.pickupSounds;
		}
		else
		{
			item.normalSprite = normalSprite;
			item.itemAsset = itemAsset;
			item.handItemAsset = handItemAsset;
			item.pickupSounds = pickupSounds;
		}
		item.offset = offset;
		item.bagPosition = bagPosition;
		item.bagRotation = bagRotation;
		item.inBag = false;
		item.initialized = false;
		item.itemTags = new List<string>();
		item.itemTags.AddRange(itemTags);
		item.allowCosmetics = allowCosmetics;
		item.isCosmetic = isCosmetic;
		item.worth = worth;
		item.customDropLayer = customDropLayer;
		item.executionModules = new List<ItemExecutionModule>();
		foreach (ItemExecutionModule executionModule in executionModules)
		{
			item.executionModules.Add(executionModule.GetCopy());
		}
		return item;
	}

	internal bool InInventory()
	{
		return inventory != null;
	}

	public bool InBag()
	{
		if (InInventory())
		{
			return !InHand();
		}
		return false;
	}

	internal bool InHand()
	{
		return handItem != null;
	}

	public void ClearCurrentHandItem()
	{
		if (handItem != null)
		{
			handItem.hand.inventoryHand.currentItem = null;
		}
		handItem = null;
	}

	public List<T> GetAllDataModulesByType<T>() where T : Item_Data
	{
		if (dataModules == null || dataModules.Count == 0)
		{
			return null;
		}
		List<T> list = new List<T>();
		Debug.Log("Got here at least.");
		foreach (Item_Data dataModule in dataModules)
		{
			Debug.Log("Checking Type: " + dataModule.GetType());
			Debug.Log("Type Name: " + typeof(T).Name);
			Debug.Log("Is Assigneable?: " + typeof(T).IsAssignableFrom(dataModule.GetType()));
			if (typeof(T).IsAssignableFrom(dataModule.GetType()))
			{
				Debug.Log("Getting Type of Data Module: " + dataModule.GetType());
				list.Add(dataModule as T);
			}
		}
		return list;
	}

	public string GetFirstDataStringByType(string type, bool returnEverythingAfterType = false)
	{
		if (data == null || data.Count == 0)
		{
			return "";
		}
		foreach (string datum in data)
		{
			if (datum.Contains(type + ":"))
			{
				if (returnEverythingAfterType)
				{
					return datum.Replace(type + ":", "");
				}
				return datum.Split(':')[1];
			}
		}
		return "";
	}

	public void SetFirstDataStringsofType(string type, string value)
	{
		if (data == null || data.Count == 0)
		{
			data = new List<string>();
		}
		_OnDataAdjust?.Invoke(type, value);
		for (int i = 0; i < data.Count; i++)
		{
			string text = data[i];
			if (text.Contains(type + ":"))
			{
				text.Split(':')[1] = value;
				data[i] = type + ":" + value;
				return;
			}
		}
		data.Add(type + ":" + value);
	}

	public bool IsUnlocked()
	{
		if (unlockType == UnlockType.progression)
		{
			if (CL_ProgressionManager.HasProgressionUnlock(progressionUnlockID))
			{
				return true;
			}
			return false;
		}
		if (unlockType == UnlockType.stat)
		{
			if (StatManager.GetTotalStatisticInt(statUnlockName) >= statUnlockAmount)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	public void SendUnlockMessage()
	{
		CL_ProgressionManager.ShowUnlockPopup(unlockSprite, "Vendor Restock", unlockTextDesc, Color.clear);
	}

	public void CleanItemInformation()
	{
		hasBeenDestroyed = false;
		CopyNonDataFromItemAsset();
	}

	public void CopyNonDataFromItemAsset(Item itemData = null)
	{
		Debug.Log("Attempting To Copy Data From: " + prefabName);
		GameObject assetGameObject = CL_AssetManager.GetAssetGameObject(prefabName);
		Debug.Log("Copying Data From: " + prefabName + " :: " + assetGameObject);
		if (assetGameObject != null && itemData == null)
		{
			Item_Object component = assetGameObject.GetComponent<Item_Object>();
			if (component != null)
			{
				itemData = component.itemData;
			}
		}
		if (itemData == null)
		{
			return;
		}
		handItemAsset = itemData.handItemAsset;
		Debug.Log(handItemAsset);
		itemAsset = itemData.itemAsset;
		pickupSounds = itemData.pickupSounds;
		unlockSprite = itemData.unlockSprite;
		prefabName = itemData.prefabName;
		executionModules = new List<ItemExecutionModule>();
		foreach (ItemExecutionModule executionModule in itemData.executionModules)
		{
			executionModules.Add(executionModule.GetCopy());
		}
		foreach (ItemExecutionModule executionModule2 in executionModules)
		{
			if (executionModule2.item != this)
			{
				executionModule2.Initialize(this);
			}
		}
	}

	public void OnPickup()
	{
		Debug.Log("Picked up item: " + itemName);
		_OnPickupAction?.Invoke(this);
		GetDropObject()?.OnPickup();
		if (!hasBeenPickedUp)
		{
			if (respawnLimit > 0 && respawnLimitFlagID != "")
			{
				string name = "haspickedup-" + prefabName + "-" + respawnLimitFlagID;
				int result = 0;
				if (CL_GameManager.GetGameFlag(name) != null)
				{
					int.TryParse(CL_GameManager.GetGameFlag(name).data, out result);
				}
				CL_GameManager.SetGameFlag(name, state: true, (result + 1).ToString());
			}
			if (pickupStat != "")
			{
				StatManager.sessionStats.UpdateStatistic(pickupStat, 1, StatManager.Statistic.DataType.Int, StatManager.Statistic.ModType.Add);
			}
			StatManager.sessionStats.UpdateStatistic("pickup-item-" + itemName, 1, StatManager.Statistic.DataType.Int, StatManager.Statistic.ModType.Add);
			if (itemTags != null)
			{
				foreach (string itemTag in itemTags)
				{
					StatManager.sessionStats.UpdateStatistic("pickup-tag-" + itemTag, 1, StatManager.Statistic.DataType.Int, StatManager.Statistic.ModType.Add);
				}
			}
			hasBeenPickedUp = true;
		}
		foreach (ItemExecutionModule executionModule in executionModules)
		{
			executionModule.OnPickup();
		}
	}

	public void OnDrop()
	{
		foreach (ItemExecutionModule executionModule in executionModules)
		{
			executionModule.OnDrop();
		}
		_OnDropAction?.Invoke(this);
	}

	internal void UpdateProgressionStat(int i = 1)
	{
		if (!CL_GameManager.GetBaseGamemode().HasTag("blockvendorunlocks") && unlockType == UnlockType.progression)
		{
			ProgressionUnlock progressionUnlock = CL_ProgressionManager.GetProgressionUnlock(progressionUnlockID);
			if (progressionUnlock != null)
			{
				StatManager.sessionStats.UpdateStatistic(progressionUnlock.unlockRequirements[0].statName, i, StatManager.Statistic.DataType.Int, StatManager.Statistic.ModType.Add);
			}
		}
	}

	public void Save()
	{
		if (dataModules == null || dataModules.Count <= 0)
		{
			return;
		}
		dataModuleSaves = new List<DataModuleSave>();
		foreach (Item_Data dataModule in dataModules)
		{
			DataModuleSave dataModuleSave = new DataModuleSave();
			dataModuleSave.type = dataModule.GetType().Name;
			dataModuleSave.moduleData = JsonUtility.ToJson(dataModule);
			dataModuleSave.saveData = dataModule.GetSaveData();
			dataModuleSaves.Add(dataModuleSave);
			Debug.Log("saving this info: " + JsonUtility.ToJson(dataModule));
		}
	}

	public void Load()
	{
		if (dataModuleSaves == null || dataModuleSaves.Count <= 0)
		{
			return;
		}
		dataModules = new List<Item_Data>();
		foreach (DataModuleSave dataModuleSafe in dataModuleSaves)
		{
			object obj = JsonUtility.FromJson(dataModuleSafe.moduleData, Type.GetType(dataModuleSafe.type));
			dataModules.Add((Item_Data)obj);
			dataModules[dataModules.Count - 1].LoadSaveData(dataModuleSafe.saveData);
		}
	}

	public SaveableInfo GetSaveInfo()
	{
		SaveableInfo saveableInfo = new SaveableInfo();
		Save();
		saveableInfo.id = prefabName;
		saveableInfo.data = JsonUtility.ToJson(this);
		return saveableInfo;
	}

	public static Item CreateFromSaveInfo(SaveableInfo saveInfo)
	{
		Item item = new Item();
		item = JsonUtility.FromJson<Item>(saveInfo.data);
		Debug.Log("Attempting to create item: " + saveInfo.data);
		Item_Object itemObjectPrefab = CL_AssetManager.GetItemObjectPrefab(item.prefabName);
		if (itemObjectPrefab == null)
		{
			return null;
		}
		item.Load();
		Debug.Log("Creating Item From Save File: " + item.prefabName);
		return item.GetClone(itemObjectPrefab.itemData);
	}

	public bool CanSpawn()
	{
		if (hasBeenPickedUp)
		{
			return true;
		}
		if (respawnLimit > 0 && respawnLimitFlagID != "")
		{
			string name = "haspickedup-" + prefabName + "-" + respawnLimitFlagID;
			int result = 0;
			if (CL_GameManager.GetGameFlag(name) != null)
			{
				int.TryParse(CL_GameManager.GetGameFlag(name).data, out result);
			}
			if (result >= respawnLimit)
			{
				return false;
			}
		}
		return true;
	}

	public bool HasTag(string s)
	{
		if (itemTags == null || itemTags.Count == 0)
		{
			return false;
		}
		foreach (string itemTag in itemTags)
		{
			if (itemTag.ToLower() == s.ToLower())
			{
				return true;
			}
		}
		return false;
	}

	public bool HasTagInList(List<string> s)
	{
		if (itemTags == null || itemTags.Count == 0)
		{
			return false;
		}
		foreach (string itemTag in itemTags)
		{
			if (s.Contains(itemTag))
			{
				return true;
			}
		}
		return false;
	}

	public void Destroy(bool clearFromInventory = true)
	{
		if (!hasBeenDestroyed)
		{
			hasBeenDestroyed = true;
			if (InInventory() && clearFromInventory)
			{
				inventory.ClearItemFromInventory(this);
			}
			ClearDropObject();
		}
	}
}
