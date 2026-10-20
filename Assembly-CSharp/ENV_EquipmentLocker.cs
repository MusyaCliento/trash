using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ENV_EquipmentLocker : MonoBehaviour
{
	[Serializable]
	public class GlobalLocker
	{
		public int lockerID;

		public Item item;
	}

	public int lockerID;

	public static Dictionary<int, GlobalLocker> lockers;

	private GlobalLocker currentLocker;

	public GameObject itemDropoffObject;

	public Transform itemLocation;

	public bool saveToGlobalFlags;

	public UnityEvent EventOnEmpty;

	public UnityEvent EventOnFull;

	public AudioClip doorCloseEmpty;

	public AudioClip doorCloseFull;

	public AudioClip doorOpenEmpty;

	public AudioClip doorOpenSaved;

	private void OnEnable()
	{
		if (lockers == null)
		{
			lockers = new Dictionary<int, GlobalLocker>();
		}
		if (lockers.ContainsKey(lockerID))
		{
			currentLocker = lockers[lockerID];
		}
		else
		{
			currentLocker = new GlobalLocker();
			currentLocker.lockerID = lockerID;
			lockers.Add(lockerID, currentLocker);
		}
		LoadFromLockerState();
		if (currentLocker.item == null)
		{
			EventOnEmpty.Invoke();
		}
		else
		{
			EventOnFull.Invoke();
		}
	}

	public void StashItem(Item item)
	{
		currentLocker.item = item;
		item._OnPickupAction = (Action<Item>)Delegate.Combine(item._OnPickupAction, new Action<Item>(OnGrabItem));
		itemDropoffObject.gameObject.SetActive(value: false);
		Item_Object dropObject = item.GetDropObject();
		dropObject.transform.position = itemLocation.position;
		dropObject.transform.rotation = itemLocation.rotation;
		Rigidbody component = dropObject.GetComponent<Rigidbody>();
		if (component != null)
		{
			component.isKinematic = true;
		}
		dropObject.onPlaceInInventory.Invoke();
		Denizen component2 = dropObject.GetComponent<Denizen>();
		if (component2 != null)
		{
			component2.enabled = false;
			component2.damageable = false;
		}
		if (!currentLocker.item.itemTags.Contains("inLocker"))
		{
			currentLocker.item.itemTags.Add("inLocker");
		}
		UpdateLockerState();
	}

	public void OpenLocker()
	{
		if (currentLocker.item == null)
		{
			itemDropoffObject.gameObject.SetActive(value: true);
			AudioManager.PlaySound(doorOpenEmpty, base.transform.position);
			return;
		}
		currentLocker.item.CleanItemInformation();
		Item_Object dropObject = currentLocker.item.GetDropObject();
		dropObject.transform.position = itemLocation.position;
		dropObject.transform.rotation = itemLocation.rotation;
		UT_SpawnChance component = dropObject.gameObject.GetComponent<UT_SpawnChance>();
		if (component != null)
		{
			UnityEngine.Object.Destroy(component);
		}
		AudioManager.PlaySound(doorOpenSaved, base.transform.position);
		ObjectTagger component2 = dropObject.gameObject.GetComponent<ObjectTagger>();
		if (component2 != null)
		{
			component2.AddTag("DontRemove");
		}
		Rigidbody component3 = dropObject.GetComponent<Rigidbody>();
		if (component3 != null)
		{
			component3.isKinematic = true;
		}
		dropObject.gameObject.SetActive(value: true);
		dropObject.itemData.InitializeItemData(dropObject);
		dropObject.onPlaceInInventory.Invoke();
		Denizen component4 = dropObject.GetComponent<Denizen>();
		if (component4 != null)
		{
			component4.enabled = false;
			component4.damageable = false;
		}
		Item item = currentLocker.item;
		item._OnPickupAction = (Action<Item>)Delegate.Combine(item._OnPickupAction, new Action<Item>(OnGrabItem));
		itemDropoffObject.gameObject.SetActive(value: false);
	}

	public void CloseLocker()
	{
		itemDropoffObject.gameObject.SetActive(value: false);
		if (currentLocker.item == null)
		{
			EventOnEmpty.Invoke();
			AudioManager.PlaySound(doorCloseEmpty, base.transform.position);
			return;
		}
		EventOnFull.Invoke();
		AudioManager.PlaySound(doorCloseFull, base.transform.position);
		Item item = currentLocker.item;
		item._OnPickupAction = (Action<Item>)Delegate.Remove(item._OnPickupAction, new Action<Item>(OnGrabItem));
		currentLocker.item.ClearDropObject();
	}

	public void OnGrabItem(Item item)
	{
		if (item.GetDropObject().TryGetComponent<Denizen>(out var component))
		{
			component.damageable = true;
		}
		if (item.itemTags.Contains("inLocker"))
		{
			item.itemTags.Remove("inLocker");
		}
		currentLocker.item = null;
		item._OnPickupAction = (Action<Item>)Delegate.Remove(item._OnPickupAction, new Action<Item>(OnGrabItem));
		itemDropoffObject.gameObject.SetActive(value: true);
		UpdateLockerState();
	}

	private void LoadFromLockerState()
	{
		string text = "equiplocker-" + CL_GameManager.GetBaseGamemode().GetGamemodeName();
		if (ENT_Player.GetPlayer() != null && ENT_Player.GetPlayer().HasPerk("Perk_Binding_PitonsAndBeans"))
		{
			text += "-pitonsandbeans-";
		}
		text = text + (saveToGlobalFlags ? "local" : "") + lockerID;
		CL_GameManager.SessionFlag gameFlag = CL_GameManager.GetGameFlag(text);
		if (gameFlag != null && gameFlag.data != "" && gameFlag.data.Length > 0)
		{
			if (!gameFlag.data.Contains('{'))
			{
				Item_Object itemObjectPrefab = CL_AssetManager.GetItemObjectPrefab(gameFlag.data);
				if (itemObjectPrefab == null)
				{
					currentLocker.item = null;
					return;
				}
				Item clone = itemObjectPrefab.itemData.GetClone();
				currentLocker.item = clone;
			}
			else
			{
				Item item = Item.CreateFromSaveInfo(JsonUtility.FromJson<SaveableInfo>(gameFlag.data));
				Debug.Log("Attempting to load item: " + item.itemAsset);
				currentLocker.item = item;
			}
			if (currentLocker.item != null && !currentLocker.item.itemTags.Contains("inLocker"))
			{
				currentLocker.item.itemTags.Add("inLocker");
			}
			if (currentLocker.item == null || currentLocker.item.itemAsset == null)
			{
				currentLocker.item = null;
			}
		}
		else
		{
			currentLocker.item = null;
		}
	}

	private void UpdateLockerState()
	{
		string text = "equiplocker-" + CL_GameManager.GetBaseGamemode().GetGamemodeName();
		if (ENT_Player.GetPlayer() != null && ENT_Player.GetPlayer().HasPerk("Perk_Binding_PitonsAndBeans"))
		{
			text += "-pitonsandbeans-";
		}
		text = text + (saveToGlobalFlags ? "local" : "") + lockerID;
		if (currentLocker.item != null)
		{
			string data = JsonUtility.ToJson(currentLocker.item.GetSaveInfo());
			CL_GameManager.SetGameFlag(text, state: true, data, saveToGlobalFlags);
		}
		else
		{
			CL_GameManager.SetGameFlag(text, state: true, "", saveToGlobalFlags);
		}
	}
}
