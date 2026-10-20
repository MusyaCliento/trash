using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	[Serializable]
	public class ItemHand
	{
		[NonSerialized]
		public Item currentItem;

		public int currentItemNumber;

		public Transform handInventoryRoot;

		public ViewSway handModel;

		[NonSerialized]
		public ENT_Player.Hand hand;

		public bool HasItem()
		{
			return currentItem != null;
		}
	}

	[Serializable]
	public class Pocket
	{
		public Transform transform;

		public string key;

		public int targetHandID;

		public Pouch pouch;

		public bool HasItem()
		{
			if (pouch.pouchItems.Count > 0)
			{
				return true;
			}
			return false;
		}
	}

	public class Pouch
	{
		[Serializable]
		public class PouchSaveData
		{
			public List<Item> items = new List<Item>();

			public int maxCapacity;

			public int maxLargeCapacity;
		}

		public Bag_Pouch pouchVisual;

		public List<Item> pouchItems = new List<Item>();

		public int maxCapacity;

		public int maxLargeCapacity;

		public bool allowNonPouchable;

		public void AddItemToPouch(Item item, bool pushItemsApart = true)
		{
			if (!CanAddItemToPouch(item))
			{
				Debug.LogError("Can't add item to pouch, it doesn't match the item type already in the pouch.");
				return;
			}
			pouchItems.Add(item);
			item._OnPickupAction = (Action<Item>)Delegate.Combine(item._OnPickupAction, new Action<Item>(RemoveItemFromPouch));
			item._OnClearDropObject = (Action<Item>)Delegate.Combine(item._OnClearDropObject, new Action<Item>(RemoveItemFromPouch));
			item.GetDropObject().transform.localPosition = GetCorrectedPosition();
			if (pouchItems.Count > 1)
			{
				item.GetDropObject().gameObject.SetActive(value: false);
				item.currentWeightMult = 0f;
			}
			pouchVisual.AddItem();
			pouchVisual.SetItemCount(pouchItems.Count, maxCapacity);
			instance.CalculateEncumberance(pushItemsApart);
		}

		public Vector3 GetCorrectedPosition()
		{
			return pouchVisual.transform.localPosition.normalized * 1.6f;
		}

		public void RemoveItemFromPouch(Item item)
		{
			Debug.Log("Removing From Pouch: " + item.itemName);
			if (pouchItems.Contains(item))
			{
				Debug.Log("Has Removed!");
				item._OnPickupAction = (Action<Item>)Delegate.Remove(item._OnPickupAction, new Action<Item>(RemoveItemFromPouch));
				item._OnClearDropObject = (Action<Item>)Delegate.Remove(item._OnClearDropObject, new Action<Item>(RemoveItemFromPouch));
				pouchItems.Remove(item);
				pouchVisual.SetItemCount(pouchItems.Count, maxCapacity);
				item.GetDropObject().transform.localPosition = Vector3.forward;
				if (pouchItems.Count > 0)
				{
					pouchItems[0].GetDropObject().gameObject.SetActive(value: true);
					pouchItems[0].currentWeightMult = 1f;
				}
				instance.CalculateEncumberance();
			}
		}

		public Item RemoveItemFromPouch()
		{
			if (pouchItems.Count > 0)
			{
				Item item = pouchItems[0];
				item._OnPickupAction = (Action<Item>)Delegate.Remove(item._OnPickupAction, new Action<Item>(RemoveItemFromPouch));
				item._OnClearDropObject = (Action<Item>)Delegate.Remove(item._OnClearDropObject, new Action<Item>(RemoveItemFromPouch));
				pouchItems.RemoveAt(0);
				pouchVisual.SetItemCount(pouchItems.Count, maxCapacity);
				if (pouchItems.Count > 0)
				{
					pouchItems[0].GetDropObject().gameObject.SetActive(value: true);
					pouchItems[0].currentWeightMult = 1f;
				}
				return item;
			}
			return null;
		}

		public bool CanAddItemToPouch(Item item)
		{
			if (item == null)
			{
				return false;
			}
			if ((!item.pocketable && maxLargeCapacity <= pouchItems.Count) || (!item.pouchable && !allowNonPouchable))
			{
				return false;
			}
			if (pouchItems.Count == 0)
			{
				return true;
			}
			if (pouchItems.Contains(item))
			{
				return false;
			}
			if (pouchItems.Count >= maxCapacity)
			{
				return false;
			}
			return pouchItems[0].itemName == item.itemName;
		}

		public void UpdatePouch()
		{
			for (int num = pouchItems.Count - 1; num >= 0; num--)
			{
				if (pouchItems[num] == null || pouchItems[num].hasBeenDestroyed)
				{
					pouchItems.RemoveAt(num);
				}
				else
				{
					pouchItems[num].GetDropObject().transform.position = pouchVisual.transform.position;
				}
			}
			if (pouchItems.Count > 0)
			{
				pouchItems[0].GetDropObject().gameObject.SetActive(value: true);
			}
			pouchVisual.SetItemCount(pouchItems.Count, maxCapacity);
		}
	}

	public Transform playerInventoryRoot;

	public ItemHand[] itemHands = new ItemHand[2]
	{
		new ItemHand(),
		new ItemHand()
	};

	public Image iconAsset;

	private UT_AudioClipHandler aud;

	private ENT_Player player;

	public bool showingInventory;

	public Transform inventory;

	public Transform itemRoot;

	public Bag_Handler bagHandler;

	public Bag_Pouch pocketAsset;

	public List<Item> bagItems = new List<Item>();

	public MeshRenderer bagRenderer;

	public Color bagEncumberedColor = Color.red;

	public Color bagUnencumberedColor = Color.white;

	private Color bagCurrentColor;

	public int pouchCount;

	[HideInInspector]
	public List<Pouch> extraPouches = new List<Pouch>();

	internal List<Pouch> pouches = new List<Pouch>();

	private int pouchMaxCapacity = 5;

	public int maxEncumberedItems = 10;

	public int unencumberedItems = 5;

	public float encumberance = 1f;

	private Quaternion inventoryRotation;

	private Transform lastSoftParent;

	private Vector3 inventoryLookVector;

	private GameObject itemObject;

	public float minDistance = 1f;

	public float moveSpeed = 1f;

	public Transform inventoryCenterLocator;

	public List<Pocket> pockets;

	public static Inventory instance;

	public List<Item> testBagLoad;

	private int buffVersion;

	private int lastAddedFrame;

	public void Initialize(ENT_Player p)
	{
		aud = GetComponent<UT_AudioClipHandler>();
		instance = this;
		for (int i = 0; i < itemRoot.childCount; i++)
		{
			Item_Object component = itemRoot.GetChild(i).GetComponent<Item_Object>();
			bagItems.Add(component.itemData);
		}
		player = p;
		showingInventory = false;
		for (int j = 0; j < itemHands.Length; j++)
		{
			player.hands[j].inventoryHand = itemHands[j];
			itemHands[j].hand = player.hands[j];
		}
		CreatePouches();
	}

	private void Update()
	{
		if (CL_GameManager.gMan.lockPlayer || CL_GameManager.gMan.isPaused)
		{
			return;
		}
		bagCurrentColor = Color.Lerp(bagCurrentColor, Color.white, CL_GameManager.GetPlayerPerceivedDeltaTime() * 3f);
		bagRenderer.material.SetColor("_Color", bagCurrentColor);
		bagHandler.SetBagColor(bagCurrentColor, encumberance);
		if (player.IsLocked() || CL_GameManager.gMan.lockPlayerInput)
		{
			return;
		}
		if (!player.IsInventoryLocked())
		{
			if (SettingsManager.settings.toggleInventory)
			{
				if (InputManager.GetButton("Inventory").Down)
				{
					if (showingInventory)
					{
						HideInventory();
					}
					else
					{
						ShowInventory();
					}
				}
			}
			else
			{
				if (InputManager.GetButton("Inventory").Down)
				{
					ShowInventory();
				}
				if (InputManager.GetButton("Inventory").Up)
				{
					HideInventory();
				}
			}
			int num = player.curBuffs.GetBuffVersion();
			if (buffVersion != num)
			{
				CalculateEncumberance();
				buffVersion = num;
			}
		}
		if (InputManager.GetButton("Hand-Swap").Down)
		{
			SwapHands();
		}
		foreach (Pocket pocket in pockets)
		{
			if (InputManager.GetButton(pocket.key).Down && !player.IsInventoryLocked())
			{
				TryPocketItemInHand(pocket.targetHandID);
			}
		}
		PushItemsApart();
		if (showingInventory)
		{
			if (player.GetSoftParent().GetParent() != lastSoftParent)
			{
				if (player.GetSoftParent().GetParent() == null)
				{
					inventoryLookVector = inventory.transform.forward;
				}
				else
				{
					inventoryLookVector = player.GetSoftParent().GetParent().InverseTransformDirection(inventory.transform.forward);
				}
				lastSoftParent = player.GetSoftParent().GetParent();
			}
			if (player.GetSoftParent().IsParented())
			{
				Vector3 forward = player.GetSoftParent().parent.TransformDirection(inventoryLookVector);
				inventory.rotation = Quaternion.LookRotation(forward);
			}
			else
			{
				inventory.rotation = Quaternion.LookRotation(inventoryLookVector);
			}
			if (Vector3.Angle(Camera.main.transform.forward, inventory.forward) > 75f)
			{
				HideInventory();
			}
		}
		else if (inventoryLookVector != Vector3.zero)
		{
			inventory.rotation = Quaternion.LookRotation(base.transform.TransformDirection(inventoryLookVector), base.transform.up);
		}
		for (int i = 0; i < itemHands.Length; i++)
		{
			ItemHand itemHand = itemHands[i];
			ENT_Player.Hand hand = player.hands[i];
			if (itemHand.currentItem != null)
			{
				itemHand.currentItem.Execute(this);
			}
			if (itemHand.currentItem != null && !(hand.cooldown > 0f) && !showingInventory)
			{
				if (InputManager.GetButton(hand.fireButton).Down)
				{
					itemHand.currentItem.Use();
				}
				if (InputManager.GetButton(hand.fireButton).Up)
				{
					itemHand.currentItem.StopUse();
				}
			}
		}
		foreach (Item bagItem in bagItems)
		{
			bagItem.Execute(this);
		}
	}

	private void FixedUpdate()
	{
		for (int i = 0; i < itemHands.Length; i++)
		{
			ItemHand itemHand = itemHands[i];
			if (itemHand.currentItem != null)
			{
				itemHand.currentItem.FixedExecute(this);
			}
		}
		foreach (Item bagItem in bagItems)
		{
			bagItem.FixedExecute(this);
		}
	}

	private void PushItemsApart()
	{
		Item_Object[] componentsInChildren = itemRoot.GetComponentsInChildren<Item_Object>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Transform itemTransform = componentsInChildren[i].transform;
			float num = 1.3f;
			float num2 = Vector3.Dot(Vector3.forward, itemTransform.localPosition.normalized);
			float num3 = Vector3.Distance(itemTransform.localPosition, inventoryCenterLocator.localPosition);
			if (itemTransform.localPosition == Vector3.zero || num2 < 0f)
			{
				itemTransform.position = inventoryCenterLocator.position;
			}
			if (num3 > 1.45f)
			{
				Vector3 vector = (inventoryCenterLocator.localPosition - itemTransform.localPosition).normalized * moveSpeed * Time.deltaTime;
				vector.z = 0f;
				itemTransform.localPosition += vector * 0.5f;
			}
			for (int j = i + 1; j < componentsInChildren.Length; j++)
			{
				Transform itemB = componentsInChildren[j].transform;
				if (componentsInChildren[i] != base.transform && componentsInChildren[j] != base.transform)
				{
					MoveItemsAwayFromEachother(itemTransform, itemB, minDistance, moveSpeed);
				}
			}
			foreach (Pouch pouch in pouches)
			{
				Vector3 correctedPosition = pouch.GetCorrectedPosition();
				if (Vector3.Distance(correctedPosition, itemTransform.localPosition) < minDistance * 0.6f)
				{
					if (pouch.CanAddItemToPouch(componentsInChildren[i].itemData) && componentsInChildren[i].gameObject.activeSelf)
					{
						pouch.AddItemToPouch(componentsInChildren[i].itemData);
					}
					else if (pouch.pouchItems.Contains(componentsInChildren[i].itemData))
					{
						itemTransform.localPosition = correctedPosition;
						num = Mathf.Min(num, 0.8f);
					}
					else if (componentsInChildren[i].gameObject.activeSelf)
					{
						bagCurrentColor = Color.red;
						MoveItemAwayFromPoint(correctedPosition, minDistance, moveSpeed * 0.25f);
						num = Mathf.Min(num, 1.3f);
						itemTransform.localPosition = Vector3.Normalize(itemTransform.localPosition) * 1.6f;
					}
				}
			}
			foreach (Pocket pocket in pockets)
			{
				float f = 1f + player.curBuffs.GetBuff("addPocketCapacity");
				float buff = player.curBuffs.GetBuff("addPocketBigItemCapacity");
				pocket.pouch.maxCapacity = Mathf.CeilToInt(f);
				pocket.pouch.maxLargeCapacity = Mathf.CeilToInt(buff);
				Vector3 vector2 = pocket.transform.localPosition.normalized * 1.6f;
				if (Vector3.Distance(vector2, itemTransform.localPosition) < minDistance * 1f)
				{
					if (pocket.pouch.pouchItems.Contains(componentsInChildren[i].itemData))
					{
						Mathf.Min(Vector3.Distance(itemTransform.localPosition, vector2) * 3f, 1f);
						MoveItemAwayFromPoint(vector2, minDistance, (0f - moveSpeed) * 8f, multiplyByDistance: true);
						num = Mathf.Min(num, 0.8f);
					}
					else
					{
						num = Mathf.Min(num, 1.3f);
						MoveItemAwayFromPoint(vector2, minDistance, moveSpeed * 1f);
					}
				}
			}
			itemTransform.localScale = Vector3.Lerp(itemTransform.localScale, Vector3.one * num * componentsInChildren[i].itemData.inventoryScale, Time.deltaTime * 6f);
			NormalizeItemPositions();
			void MoveItemAwayFromPoint(Vector3 point, float radius, float moveSpeed, bool multiplyByDistance = false)
			{
				Vector3 vector3 = itemTransform.localPosition - point;
				float magnitude = vector3.magnitude;
				if (magnitude < radius)
				{
					vector3.Normalize();
					Vector3 vector4 = vector3 * (radius - magnitude) * moveSpeed * Time.deltaTime;
					if (multiplyByDistance)
					{
						vector4 *= magnitude;
					}
					itemTransform.localPosition += vector4;
				}
				itemTransform.localPosition = Vector3.Normalize(itemTransform.localPosition) * 1.6f;
			}
		}
		static void MoveItemsAwayFromEachother(Transform itemA, Transform transform, float radius, float moveSpeed)
		{
			Vector3 vector3 = itemA.localPosition - transform.localPosition;
			float magnitude = vector3.magnitude;
			if (magnitude < radius)
			{
				vector3.Normalize();
				Vector3 vector4 = vector3 * (radius - magnitude) * moveSpeed * Time.deltaTime;
				itemA.localPosition += vector4 / 2f;
				transform.localPosition -= vector4 / 2f;
			}
		}
	}

	private void NormalizeItemPositions()
	{
		Item_Object[] componentsInChildren = itemRoot.GetComponentsInChildren<Item_Object>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Transform obj = componentsInChildren[i].transform;
			obj.localPosition = Vector3.Normalize(obj.localPosition) * 1.6f;
		}
	}

	private void CreatePouches()
	{
		extraPouches = new List<Pouch>();
		pouches = new List<Pouch>();
		bagHandler.maxPouches = pouchCount;
		bagHandler.CreatePouches();
		for (int i = 0; i < bagHandler.extraPouches.Count; i++)
		{
			Pouch pouch = new Pouch();
			pouch.pouchVisual = bagHandler.extraPouches[i];
			pouch.maxCapacity = pouchMaxCapacity;
			pouch.maxLargeCapacity = 0;
			extraPouches.Add(pouch);
			pouches.Add(pouch);
		}
		foreach (Pocket pocket in pockets)
		{
			Pouch pouch2 = new Pouch();
			pouch2.pouchVisual = bagHandler.CreateCustomPouch(pocket.transform.position, pocketAsset);
			pouch2.maxCapacity = 1;
			pouch2.maxLargeCapacity = 0;
			pocket.pouch = pouch2;
			pouches.Add(pouch2);
		}
	}

	public void AddExtraPouch()
	{
		if (extraPouches.Count >= 4)
		{
			return;
		}
		pouchCount = Mathf.Clamp(pouchCount + 1, 0, 4);
		bagHandler.maxPouches = pouchCount;
		bagHandler.CreatePouches();
		for (int i = 0; i < pouchCount; i++)
		{
			if (extraPouches.Count <= i)
			{
				Pouch pouch = new Pouch();
				pouch.pouchVisual = bagHandler.extraPouches[i];
				pouch.maxCapacity = pouchMaxCapacity;
				extraPouches.Add(pouch);
				pouches.Add(pouch);
			}
			else
			{
				extraPouches[i].pouchVisual = bagHandler.extraPouches[i];
				extraPouches[i].maxCapacity = pouchMaxCapacity;
				if (extraPouches[i].pouchItems.Count > 0)
				{
					extraPouches[i].pouchItems[0].GetDropObject().transform.position = extraPouches[i].pouchVisual.transform.position;
				}
			}
		}
		UpdatePouches();
		CalculateEncumberance();
	}

	public void RemoveExtraPouch()
	{
		if (extraPouches.Count <= 0)
		{
			return;
		}
		Pouch pouch = extraPouches[extraPouches.Count - 1];
		foreach (Item pouchItem in pouch.pouchItems)
		{
			pouchItem.GetDropObject().gameObject.SetActive(value: true);
			pouchItem.GetDropObject().transform.position = pouch.pouchVisual.transform.position + UnityEngine.Random.insideUnitSphere * 0.01f;
		}
		pouches.Remove(pouch);
		extraPouches.Remove(pouch);
		pouchCount = Mathf.Clamp(pouchCount - 1, 0, 4);
		bagHandler.maxPouches = pouchCount;
		bagHandler.CreatePouches();
		for (int i = 0; i < extraPouches.Count; i++)
		{
			extraPouches[i].pouchVisual = bagHandler.extraPouches[i];
		}
		UpdatePouches();
		CalculateEncumberance();
	}

	private void ShowInventory()
	{
		if (!showingInventory)
		{
			showingInventory = true;
			inventory.gameObject.SetActive(value: true);
			inventory.localRotation = Quaternion.identity;
			Vector3 direction = Vector3.Lerp(base.transform.forward, Camera.main.transform.forward, 0.5f);
			if (player.GetSoftParent().IsParented())
			{
				inventoryLookVector = player.GetSoftParent().parent.InverseTransformDirection(direction);
			}
			else
			{
				inventoryLookVector = direction;
			}
			inventoryRotation = Quaternion.Lerp(inventory.rotation, player.transform.rotation, 0.5f);
		}
	}

	private void HideInventory()
	{
		if (showingInventory)
		{
			showingInventory = false;
			inventory.gameObject.SetActive(value: false);
		}
	}

	private bool CheckOtherHandsForItem(int currentHand, int itemNumber)
	{
		if (itemHands[currentHand].currentItemNumber == -1)
		{
			return false;
		}
		for (int i = 0; i < itemHands.Length; i++)
		{
			if (i != currentHand && itemHands[i].currentItemNumber == itemNumber)
			{
				return true;
			}
		}
		return false;
	}

	public Item GetItem(string itemName)
	{
		foreach (Item bagItem in bagItems)
		{
			if (bagItem.itemName.ToLower() == itemName.ToLower())
			{
				return bagItem;
			}
		}
		foreach (Pouch pouch in pouches)
		{
			if (pouch == null)
			{
				continue;
			}
			foreach (Item pouchItem in pouch.pouchItems)
			{
				if (pouchItem != null && pouchItem.itemName.ToLower() == itemName.ToLower())
				{
					return pouchItem;
				}
			}
		}
		ItemHand[] array = itemHands;
		foreach (ItemHand itemHand in array)
		{
			if (itemHand.currentItem != null && itemHand.currentItem.itemName.ToLower() == itemName.ToLower())
			{
				return itemHand.currentItem;
			}
		}
		return null;
	}

	public Item GetItemByPrefab(string prefabName)
	{
		foreach (Item bagItem in bagItems)
		{
			if (bagItem != null && bagItem.prefabName.ToLower() == prefabName.ToLower())
			{
				return bagItem;
			}
		}
		foreach (Pouch pouch in pouches)
		{
			if (pouch == null)
			{
				continue;
			}
			foreach (Item pouchItem in pouch.pouchItems)
			{
				if (pouchItem != null && pouchItem.prefabName.ToLower() == prefabName.ToLower())
				{
					return pouchItem;
				}
			}
		}
		ItemHand[] array = itemHands;
		foreach (ItemHand itemHand in array)
		{
			if (itemHand.currentItem != null && itemHand.currentItem.prefabName.ToLower() == prefabName.ToLower())
			{
				return itemHand.currentItem;
			}
		}
		return null;
	}

	public List<Item> GetItemsByPrefab(string prefabName, bool includeHands = true, bool includeBag = true)
	{
		List<Item> list = new List<Item>();
		if (includeBag)
		{
			foreach (Item bagItem in bagItems)
			{
				if (bagItem.prefabName.ToLower() == prefabName.ToLower())
				{
					list.Add(bagItem);
				}
			}
			foreach (Pouch pouch in pouches)
			{
				if (pouch == null)
				{
					continue;
				}
				foreach (Item pouchItem in pouch.pouchItems)
				{
					if (pouchItem != null && !list.Contains(pouchItem) && pouchItem.prefabName.ToLower() == prefabName.ToLower())
					{
						list.Add(pouchItem);
					}
				}
			}
		}
		if (includeHands)
		{
			ItemHand[] array = itemHands;
			foreach (ItemHand itemHand in array)
			{
				if (itemHand.currentItem != null && itemHand.currentItem.prefabName.ToLower() == prefabName.ToLower())
				{
					list.Add(itemHand.currentItem);
				}
			}
		}
		return list;
	}

	public Item GetItemByTag(string itemTag, bool pouchLast = true, bool allowInUse = true)
	{
		ItemHand[] array = itemHands;
		foreach (ItemHand itemHand in array)
		{
			if (itemHand.currentItem != null && itemHand.currentItem.HasTag(itemTag) && (allowInUse || !itemHand.currentItem.HasTag("inuse")))
			{
				return itemHand.currentItem;
			}
		}
		Item result = null;
		Item item = null;
		foreach (Item item2 in GetItems(checkBag: true, checkHands: false))
		{
			if (item2 == null || !item2.HasTag(itemTag) || (!allowInUse && item2.HasTag("inuse")))
			{
				continue;
			}
			bool flag = false;
			foreach (Pouch extraPouch in extraPouches)
			{
				if (extraPouch.pouchItems.Count > 0 && extraPouch.pouchItems.Contains(item2))
				{
					item = item2;
					flag = true;
					break;
				}
			}
			if (flag)
			{
				continue;
			}
			foreach (Pocket pocket in pockets)
			{
				if (pocket.pouch.pouchItems.Count > 0 && pocket.pouch.pouchItems[0] == item2)
				{
					result = item2;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return item2;
			}
		}
		if (item != null)
		{
			return item;
		}
		return result;
	}

	public List<Item> GetItemsByTag(string itemTag, bool checkBag = true, bool checkHands = true, bool allowInUse = true)
	{
		List<Item> list = new List<Item>();
		if (checkHands)
		{
			ItemHand[] array = itemHands;
			foreach (ItemHand itemHand in array)
			{
				if (itemHand.currentItem != null && itemHand.currentItem.HasTag(itemTag) && (allowInUse || !itemHand.currentItem.HasTag("inuse")))
				{
					list.Add(itemHand.currentItem);
				}
			}
		}
		if (checkBag)
		{
			foreach (Item bagItem in bagItems)
			{
				if (bagItem != null && bagItem.HasTag(itemTag) && (allowInUse || !bagItem.HasTag("inuse")))
				{
					list.Add(bagItem);
				}
			}
			foreach (Pouch pouch in pouches)
			{
				if (pouch == null)
				{
					continue;
				}
				foreach (Item pouchItem in pouch.pouchItems)
				{
					if (pouchItem != null && !list.Contains(pouchItem) && pouchItem.HasTag(itemTag) && (allowInUse || !pouchItem.HasTag("inuse")))
					{
						list.Add(pouchItem);
					}
				}
			}
		}
		return list;
	}

	public List<Item> GetItems(bool checkBag = true, bool checkHands = true, bool checkPouches = true)
	{
		List<Item> list = new List<Item>();
		if (checkHands)
		{
			ItemHand[] array = itemHands;
			foreach (ItemHand itemHand in array)
			{
				if (itemHand.currentItem != null)
				{
					list.Add(itemHand.currentItem);
				}
			}
		}
		if (checkBag)
		{
			foreach (Item bagItem in bagItems)
			{
				if (bagItem != null)
				{
					list.Add(bagItem);
				}
			}
		}
		if (checkPouches)
		{
			foreach (Pouch pouch in pouches)
			{
				if (pouch == null)
				{
					continue;
				}
				foreach (Item pouchItem in pouch.pouchItems)
				{
					if (pouchItem != null && !list.Contains(pouchItem))
					{
						list.Add(pouchItem);
					}
				}
			}
		}
		return list;
	}

	public int GetItemCount(bool checkBag = true, bool checkHands = true, bool checkPouches = true)
	{
		int num = 0;
		if (checkHands)
		{
			ItemHand[] array = itemHands;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].currentItem != null)
				{
					num++;
				}
			}
		}
		if (checkBag)
		{
			num += bagItems.Count;
		}
		if (!checkPouches)
		{
			foreach (Pouch extraPouch in extraPouches)
			{
				num -= Mathf.Max(extraPouch.pouchItems.Count - 1, 0);
			}
		}
		return num;
	}

	public bool HasItemWithTag(string itemTag, bool inHand = false)
	{
		if (inHand)
		{
			Item itemByTag = GetItemByTag(itemTag);
			if (itemByTag != null && itemByTag.GetHandItem() != null)
			{
				return true;
			}
			return false;
		}
		return GetItemByTag(itemTag) != null;
	}

	public void DestroyItemInHand(int h)
	{
		Item currentItem = itemHands[h].currentItem;
		if (currentItem != null)
		{
			ClearItemFromHand(currentItem);
			if (!currentItem.hasBeenDestroyed)
			{
				currentItem.Destroy();
			}
		}
	}

	public void ClearItemFromHand(Item i)
	{
		ItemHand[] array = itemHands;
		foreach (ItemHand itemHand in array)
		{
			if (itemHand.currentItem != null && itemHand.currentItem == i && itemHand.currentItem.GetHandItem() != null)
			{
				UnityEngine.Object.Destroy(itemHand.currentItem.GetHandItem().gameObject);
				itemHand.currentItem = null;
				itemHand.handModel.targetOffset = Vector3.zero;
				itemHand.hand.interactState = ENT_Player.InteractType.none;
			}
		}
		CalculateEncumberance();
	}

	public void AddItemToHand(Item i, int hand)
	{
		AddItemToHand(i, itemHands[hand].hand);
	}

	public void AddItemToHand(Item i, ENT_Player.Hand playerHand)
	{
		if (i == null)
		{
			return;
		}
		if (playerHand.GetHandItem() != null)
		{
			AddItemToInventoryScreen(new Vector3(0f, 0f, 1f) + UnityEngine.Random.insideUnitSphere * 0.01f, i, localSpacePosition: true, useStoredValues: true);
			return;
		}
		int frameCount = Time.frameCount;
		i.InitializeInHand(this, playerHand);
		itemHands[playerHand.id].currentItem = i;
		lastAddedFrame = frameCount;
		i.inventory = this;
		i.OnPickup();
		ItemHand itemHand = itemHands[playerHand.id];
		if (i.pickupSounds != null && i.pickupSounds.Count > 0)
		{
			aud.GetGroup("inventory").GetSet("inventory-swap").PlaySound(1f, i.pickupSounds[UnityEngine.Random.Range(0, i.pickupSounds.Count)]);
		}
		else
		{
			aud.GetGroup("inventory").GetSet("inventory-swap").Play(1f);
		}
		if (bagItems.Contains(i))
		{
			bagItems.Remove(i);
			CalculateEncumberance();
		}
		itemHand.currentItem.ActivateItem(itemHand);
		itemHand.handModel.targetOffset = Vector3.down * 0.6f;
		CalculateEncumberance();
	}

	public void MoveItemFromHandToInventoryScreen(Vector3 pos, int handID)
	{
		if (itemHands[handID].currentItem != null)
		{
			AddItemToInventoryScreen(pos, itemHands[handID].currentItem);
		}
	}

	public void AddItemToInventoryCenter(Item item)
	{
		AddItemToInventoryScreen(new Vector3(0f, 0f, 1f) + UnityEngine.Random.insideUnitSphere * 0.01f, item, localSpacePosition: true);
	}

	public void AddItemToInventoryScreen(Vector3 pos, Item item, bool localSpacePosition = false, bool useStoredValues = false, bool pushItems = true)
	{
		item.GetDropObject().transform.parent = itemRoot;
		item.GetDropObject().gameObject.layer = LayerMask.NameToLayer("Inventory");
		item.inBag = true;
		item.GetDropObject().gameObject.SetActive(value: true);
		bagItems.Add(item);
		Renderer[] componentsInChildren = item.GetDropObject().transform.GetComponentsInChildren<Renderer>(includeInactive: true);
		foreach (Renderer renderer in componentsInChildren)
		{
			if (renderer.gameObject.layer != LayerMask.NameToLayer("Scanner"))
			{
				renderer.gameObject.layer = LayerMask.NameToLayer("Inventory");
			}
		}
		item.GetDropObject().transform.localScale = Vector3.one * item.inventoryScale * 1f;
		if (!localSpacePosition)
		{
			item.GetDropObject().transform.position = item.GetDropObject().transform.position + UnityEngine.Random.insideUnitSphere * 0.01f;
		}
		else
		{
			item.GetDropObject().transform.localPosition = pos;
		}
		item.bagPosition = item.GetDropObject().transform.localPosition;
		if (useStoredValues)
		{
			item.GetDropObject().transform.localRotation = item.bagRotation;
		}
		else
		{
			if (showingInventory)
			{
				item.GetDropObject().transform.rotation = Quaternion.LookRotation(item.GetDropObject().transform.position - Camera.main.transform.position + Camera.main.transform.up * 0.5f, Vector3.Lerp(inventory.transform.up, Vector3.up, 0.5f)) * Quaternion.LookRotation(item.upDirection);
			}
			else
			{
				ShowInventory();
				inventory.rotation = Quaternion.LookRotation(inventoryLookVector);
				item.GetDropObject().transform.rotation = Quaternion.LookRotation(item.GetDropObject().transform.position - Camera.main.transform.position + Camera.main.transform.up * 0.5f, Vector3.Lerp(inventory.transform.up, Vector3.up, 0.5f)) * Quaternion.LookRotation(item.upDirection);
				HideInventory();
			}
			item.bagRotation = item.GetDropObject().transform.localRotation;
		}
		ObjectTagger component = item.GetDropObject().GetComponent<ObjectTagger>();
		if (component != null)
		{
			if (component.HasTag("Denizen"))
			{
				Denizen component2 = item.GetDropObject().GetComponent<Denizen>();
				if (component2 != null)
				{
					component2.enabled = false;
				}
			}
			else if (component.HasTag("Roach"))
			{
				item.GetDropObject().GetComponent<DEN_Roach>().active = false;
			}
		}
		Rigidbody component3 = item.GetDropObject().GetComponent<Rigidbody>();
		if (component3 != null)
		{
			component3.isKinematic = true;
		}
		item.inventory = this;
		item.GetDropObject().transform.localPosition = Vector3.Normalize(item.GetDropObject().transform.localPosition) * 1.6f;
		item.InitializeItemData(item.GetDropObject());
		item.currentWeightMult = 1f;
		if (pushItems)
		{
			PushItemsApart();
		}
		CalculateEncumberance(pushItems);
		if (GetInventoryWeight() > GetUnencumberanceAmount() && item.currentWeightMult > 0f)
		{
			aud.PlaySound("inventory:inventory-overencumbered");
		}
		item.GetDropObject().OnPlaceInInventory();
	}

	public bool DropItemFromHand(Vector3 pos, int h, bool addtoInventory = false, bool force = false, bool pocket = false)
	{
		ItemHand itemHand = itemHands[h];
		if (itemHand.currentItem != null)
		{
			Item currentItem = itemHand.currentItem;
			currentItem.GetHandItem().OnTryDrop();
			if (!currentItem.GetHandItem().CanDrop(pocket) && !force)
			{
				return false;
			}
			currentItem.GetHandItem().OnDrop();
			if (showingInventory || addtoInventory)
			{
				aud.GetGroup("inventory").GetSet("inventory-drop").Play(1f);
				currentItem.PlaceInWorld(pos);
				pos = (pos - Camera.main.transform.position).normalized * 1.9f + Camera.main.transform.position;
				MoveItemFromHandToInventoryScreen(pos, h);
				currentItem.inventory = this;
			}
			else
			{
				DropItemIntoWorld(currentItem, pos);
			}
			itemHand.currentItem = null;
			itemHand.handModel.targetOffset = Vector3.zero;
			player.hands[h].interactState = ENT_Player.InteractType.none;
		}
		return true;
	}

	public void DropItemIntoWorld(Item item, Vector3 pos, bool removeFromHand = true)
	{
		aud.GetGroup("inventory").GetSet("inventory-drop").Play(1f);
		foreach (Pouch pouch in pouches)
		{
			if (pouch.pouchItems.Contains(item))
			{
				pouch.RemoveItemFromPouch(item);
			}
		}
		item.PlaceInWorld(pos, removeFromHand);
		item.GetDropObject().OnPlaceInWorld();
		item.inventory = null;
		item.GetDropObject().gameObject.layer = LayerMask.NameToLayer(item.customDropLayer);
		Renderer[] componentsInChildren = item.GetDropObject().transform.GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in componentsInChildren)
		{
			if (renderer.gameObject.layer != LayerMask.NameToLayer("Scanner"))
			{
				renderer.gameObject.layer = LayerMask.NameToLayer(item.customDropLayer);
			}
		}
		item.GetDropObject().transform.rotation = player.cam.transform.rotation * Quaternion.LookRotation(item.upDirection);
		item.GetDropObject().StartCoroutine(scaleUpDropObject());
		Rigidbody component = item.GetDropObject().GetComponent<Rigidbody>();
		item.inBag = false;
		if (component != null)
		{
			component.isKinematic = false;
			component.AddForce(Camera.main.transform.forward * item.dropVel + Camera.main.transform.forward * 2f, ForceMode.VelocityChange);
		}
		ObjectTagger component2 = item.GetDropObject().GetComponent<ObjectTagger>();
		if (component2 != null)
		{
			if (component2.HasTag("Denizen"))
			{
				Denizen component3 = item.GetDropObject().GetComponent<Denizen>();
				if (component3 != null)
				{
					component3.enabled = true;
				}
			}
			else if (component2.HasTag("Roach"))
			{
				item.GetDropObject().GetComponent<DEN_Roach>().active = true;
			}
		}
		if (bagItems.Contains(item))
		{
			bagItems.Remove(item);
		}
		CalculateEncumberance();
		IEnumerator scaleUpDropObject()
		{
			float time = 0.1f;
			while (time < 1f)
			{
				time = Mathf.Clamp(time + CL_GameManager.GetPlayerPerceivedDeltaTime() * 8f, 0f, 1f);
				item.GetDropObject().transform.localScale = Vector3.one * time;
				yield return null;
			}
		}
	}

	private void SwapHands()
	{
		Item currentItem = itemHands[0].currentItem;
		Item currentItem2 = itemHands[1].currentItem;
		if ((currentItem == null || itemHands[0].currentItem.GetHandItem().CanDrop()) && (currentItem2 == null || itemHands[1].currentItem.GetHandItem().CanDrop()))
		{
			bool num = itemHands[0].hand.GetHandItem() != null || itemHands[0].hand.interactState == ENT_Player.InteractType.none;
			bool flag = itemHands[1].hand.GetHandItem() != null || itemHands[1].hand.interactState == ENT_Player.InteractType.none;
			if (num && flag)
			{
				DropItemFromHand(Vector3.zero, 0);
				DropItemFromHand(Vector3.zero, 1);
				AddItemToHand(currentItem2, itemHands[0].hand);
				AddItemToHand(currentItem, itemHands[1].hand);
			}
		}
	}

	public void CalculateEncumberance(bool pushItemsApart = true)
	{
		player.curBuffs.GetBuff("addCapacity");
		float inventoryWeight = GetInventoryWeight();
		float encumberanceAmount = inventoryWeight / GetUnencumberanceAmount();
		if (inventoryWeight > GetUnencumberanceAmount())
		{
			encumberance = Mathf.Clamp(1f - (inventoryWeight - GetUnencumberanceAmount()) / (float)maxEncumberedItems, 0.1f, 1f);
			bagCurrentColor = Color.red;
		}
		else
		{
			encumberance = 1f;
		}
		bagHandler.SetEncumberance(encumberanceAmount, encumberance);
	}

	public float GetInventoryWeight()
	{
		float num = 0f;
		foreach (Item bagItem in bagItems)
		{
			if (bagItem != null)
			{
				num += CalculateItemWeight(bagItem);
			}
		}
		return num;
	}

	public float CalculateItemWeight(Item item)
	{
		if ((bool)player.GetPerk("Perk_AmmoSpiracles") && item.HasTag("ammo"))
		{
			return 0f;
		}
		return item.itemWeight * item.currentWeightMult;
	}

	public void UpdatePouches(bool pushItemsApart = true)
	{
		foreach (Pouch extraPouch in extraPouches)
		{
			extraPouch.UpdatePouch();
		}
		foreach (Pocket pocket in pockets)
		{
			pocket.pouch.UpdatePouch();
		}
		if (pushItemsApart)
		{
			PushItemsApart();
		}
		NormalizeItemPositions();
	}

	public (Pouch.PouchSaveData[] pouches, Pouch.PouchSaveData[] pockets) SavePouches()
	{
		Pouch.PouchSaveData[] array = new Pouch.PouchSaveData[extraPouches.Count];
		for (int i = 0; i < extraPouches.Count; i++)
		{
			array[i] = CreateSaveDataFromPouch(extraPouches[i]);
		}
		Pouch.PouchSaveData[] array2 = new Pouch.PouchSaveData[pockets.Count];
		for (int j = 0; j < pockets.Count; j++)
		{
			array2[j] = CreateSaveDataFromPouch(pockets[j].pouch);
		}
		return (pouches: array, pockets: array2);
		static Pouch.PouchSaveData CreateSaveDataFromPouch(Pouch pouch)
		{
			Pouch.PouchSaveData pouchSaveData = new Pouch.PouchSaveData
			{
				maxCapacity = pouch.maxCapacity,
				maxLargeCapacity = pouch.maxLargeCapacity
			};
			foreach (Item pouchItem in pouch.pouchItems)
			{
				pouchSaveData.items.Add(pouchItem.GetClone(null, copyNonDataFromItemAsset: true));
			}
			return pouchSaveData;
		}
	}

	public void LoadPouches(Pouch.PouchSaveData[] extraPouchesLoaded, Pouch.PouchSaveData[] pocketsLoaded)
	{
		while (extraPouches != null && extraPouches.Count > 0)
		{
			List<Pouch> list = extraPouches;
			int count = list[list.Count - 1].pouchItems.Count;
			while (count-- > 0)
			{
				List<Pouch> list2 = extraPouches;
				list2[list2.Count - 1].pouchItems[count].Destroy();
			}
			List<Pouch> list3 = extraPouches;
			list3[list3.Count - 1].pouchItems.Clear();
			RemoveExtraPouch();
		}
		int num = 0;
		while (extraPouchesLoaded != null && num < extraPouchesLoaded.Length)
		{
			AddExtraPouch();
			foreach (Item item in extraPouchesLoaded[num].items)
			{
				Item clone = item.GetClone();
				clone.CopyNonDataFromItemAsset();
				AddItemToInventoryScreen(Vector3.zero, clone, localSpacePosition: false, useStoredValues: false, pushItems: false);
				if (extraPouches[num].CanAddItemToPouch(clone))
				{
					extraPouches[num].AddItemToPouch(clone);
				}
			}
			num++;
		}
		int num2 = 0;
		while (pockets != null && num2 < pockets.Count)
		{
			Pouch pouch = pockets[num2].pouch;
			int count2 = pouch.pouchItems.Count;
			while (count2-- > 0)
			{
				pouch.pouchItems[count2].Destroy();
			}
			pouch.pouchItems.Clear();
			num2++;
		}
		int num3 = 0;
		while (pockets != null && pocketsLoaded != null && num3 < Mathf.Min(pockets.Count, pocketsLoaded.Length))
		{
			Pocket pocket = pockets[num3];
			Pouch pouch2 = pocket.pouch;
			Pouch.PouchSaveData pouchSaveData = pocketsLoaded[num3];
			pouch2.maxCapacity = pouchSaveData.maxCapacity;
			pouch2.maxLargeCapacity = pouchSaveData.maxLargeCapacity;
			foreach (Item item2 in pouchSaveData.items)
			{
				Item clone2 = item2.GetClone();
				clone2.CopyNonDataFromItemAsset();
				AddItemToInventoryScreen(Vector3.zero, clone2, localSpacePosition: false, useStoredValues: false, pushItems: false);
				if (pouch2.CanAddItemToPouch(clone2))
				{
					pouch2.AddItemToPouch(clone2, pushItemsApart: false);
					clone2.GetDropObject().transform.position = pocket.transform.position;
				}
			}
			num3++;
		}
		UpdatePouches();
		CalculateEncumberance();
	}

	public float GetEncumberance()
	{
		return encumberance;
	}

	public float GetUnencumberanceAmount()
	{
		return Mathf.Ceil((player.curBuffs.GetBuff("addCapacity") + (float)unencumberedItems) / (1f + player.curBuffs.GetBuff("divideCapacity")));
	}

	internal void LoadItemsIntoBag(List<Item> itemList)
	{
		Item[] array = itemList.ToArray();
		foreach (Item item in array)
		{
			Debug.Log("INVENTORY - Loading Item Into Bag: " + item.prefabName);
			AddItemToInventoryScreen(item.bagPosition, item, localSpacePosition: true, useStoredValues: true);
			item.inventory = this;
		}
	}

	internal void ClearInventory()
	{
		for (int num = bagItems.Count - 1; num >= 0; num--)
		{
			bagItems[num].Destroy();
		}
		for (int i = 0; i < itemHands.Length; i++)
		{
			DestroyItemInHand(i);
		}
		CalculateEncumberance();
	}

	internal void ClearInventoryExceptTag(string tag)
	{
		for (int num = bagItems.Count - 1; num >= 0; num--)
		{
			if (!bagItems[num].HasTag(tag))
			{
				bagItems[num].ClearDropObject();
				bagItems.RemoveAt(num);
			}
		}
		for (int i = 0; i < itemHands.Length; i++)
		{
			if (itemHands[i].currentItem != null && !itemHands[i].currentItem.HasTag(tag))
			{
				DestroyItemInHand(i);
			}
		}
		CalculateEncumberance();
	}

	internal void ClearItemTagFromInventory(string tag)
	{
		for (int num = bagItems.Count - 1; num >= 0; num--)
		{
			if (bagItems[num].HasTag(tag))
			{
				bagItems[num].ClearDropObject();
				bagItems.RemoveAt(num);
			}
		}
		for (int i = 0; i < itemHands.Length; i++)
		{
			if (itemHands[i].currentItem != null && itemHands[i].currentItem.HasTag(tag))
			{
				DestroyItemInHand(i);
			}
		}
		CalculateEncumberance();
	}

	internal void ClearItemFromInventory(Item item)
	{
		foreach (Pouch pouch in pouches)
		{
			if (pouch.pouchItems.Contains(item))
			{
				pouch.RemoveItemFromPouch(item);
			}
		}
		for (int num = bagItems.Count - 1; num >= 0; num--)
		{
			if (bagItems[num] == item)
			{
				bagItems[num].ClearDropObject();
				bagItems.RemoveAt(num);
			}
		}
		for (int i = 0; i < itemHands.Length; i++)
		{
			if (itemHands[i].currentItem != null && itemHands[i].currentItem == item)
			{
				DestroyItemInHand(i);
			}
		}
		CalculateEncumberance();
	}

	public void RescanInventory()
	{
		bagItems.Clear();
		for (int i = 0; i < itemRoot.childCount; i++)
		{
			Item_Object component = itemRoot.GetChild(i).gameObject.GetComponent<Item_Object>();
			if (component != null && component.gameObject.activeSelf && !component.itemData.hasBeenDestroyed)
			{
				bagItems.Add(component.itemData);
				component.itemData.inventory = this;
			}
		}
		CalculateEncumberance();
	}

	public List<Pouch> GetAllPouches()
	{
		List<Pouch> list = new List<Pouch>(pockets.Count + extraPouches.Count);
		foreach (Pocket pocket in pockets)
		{
			if (pocket.pouch != null)
			{
				list.Add(pocket.pouch);
			}
		}
		foreach (Pouch extraPouch in extraPouches)
		{
			list.Add(extraPouch);
		}
		return list;
	}

	public void TryPocketItemInHand(int handID)
	{
		Pocket pocket = pockets[handID];
		bool flag = itemHands[pocket.targetHandID].currentItem != null;
		if (!flag && pocket.HasItem() && player.hands[pocket.targetHandID].interactState == ENT_Player.InteractType.none)
		{
			ENT_Player.Hand hand = player.hands[pocket.targetHandID];
			hand.HideInteractionSprite();
			AddItemToHand(pocket.pouch.RemoveItemFromPouch(), hand);
		}
		else if ((flag && !pocket.HasItem()) || (flag && pocket.pouch.CanAddItemToPouch(itemHands[pocket.targetHandID].currentItem)))
		{
			if (itemHands[pocket.targetHandID].currentItem.pocketable || pocket.pouch.maxLargeCapacity > pocket.pouch.pouchItems.Count)
			{
				itemHands[pocket.targetHandID].currentItem.GetHandItem().OnTryPocket();
				DropItemFromHand(pocket.transform.position, pocket.targetHandID, addtoInventory: true, force: false, pocket: true);
			}
			else
			{
				aud.PlaySound("inventory:inventory-toobig");
			}
		}
		else
		{
			Debug.Log("Can Deposit: " + pocket.pouch.CanAddItemToPouch(itemHands[pocket.targetHandID].currentItem));
		}
	}

	public static bool IsShowingInventory()
	{
		return instance.showingInventory;
	}
}
