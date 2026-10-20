using System;
using System.Collections.Generic;
using Drawing;
using UnityEngine;
using UnityEngine.Events;

public class Item_Object : MonoBehaviourGizmos, SaveableObject
{
	public Item itemData;

	public ObjectTagger tagger;

	private float dropTime;

	public bool canPickup = true;

	private bool dropWait;

	public UnityEvent pickupEvent;

	public Action<Item_Object> onPickup;

	public Action<Item_Object> onFirstPickup;

	private bool hasPickedUp;

	public UnityEvent onPlaceInInventory;

	public UnityEvent onPlaceInWorld;

	public UnityEvent onDrop;

	public virtual void Start()
	{
		itemData.InitializeItemData(this);
		if (!itemData.CanSpawn())
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public ObjectTagger GetTagger()
	{
		if (tagger == null)
		{
			tagger = base.gameObject.GetComponent<ObjectTagger>();
		}
		return tagger;
	}

	public virtual void Update()
	{
		if (dropTime > 0f)
		{
			dropTime -= Time.deltaTime;
			dropWait = true;
		}
		else
		{
			dropWait = false;
		}
		if (!itemData.InInventory())
		{
			itemData.Execute(null);
		}
	}

	private void FixedUpdate()
	{
		if (!itemData.InInventory())
		{
			FixedExecute(null);
		}
	}

	public void OnPickup()
	{
		Debug.Log("We're picking up.");
		if (!hasPickedUp)
		{
			pickupEvent.Invoke();
			onFirstPickup?.Invoke(this);
		}
		onPickup?.Invoke(this);
		hasPickedUp = true;
		if (TryGetComponent<UT_SoftParent>(out var component))
		{
			component.ClearParent();
			component.enabled = false;
		}
	}

	public void OnDrop()
	{
		dropTime = 0.025f;
		dropWait = true;
		onDrop.Invoke();
	}

	public bool CanPickup()
	{
		if (canPickup)
		{
			return !dropWait;
		}
		return false;
	}

	public virtual void Execute(Inventory inv)
	{
	}

	public virtual void FixedExecute(Inventory inv)
	{
	}

	public SaveableInfo GetSaveInfo()
	{
		SaveableInfo saveableInfo = new SaveableInfo();
		itemData.Save();
		saveableInfo.id = itemData.prefabName;
		saveableInfo.data = JsonUtility.ToJson(itemData);
		return saveableInfo;
	}

	public void SetSaveInfo(SaveableInfo info, List<string> flags)
	{
		itemData.data = new List<string>();
		Item item = new Item();
		item = JsonUtility.FromJson<Item>(info.data);
		item.Load();
		itemData.data = item.data;
		itemData.dataModules = item.dataModules;
		itemData.dataModuleSaves = item.dataModuleSaves;
	}

	public override void DrawGizmos()
	{
		if (GizmoContext.InSelection(this) || DebugCore.showItems)
		{
			Draw.SphereOutline(base.transform.position, 0.3f, Color.grey);
			Draw.SphereOutline(base.transform.position, 0.5f, Color.magenta);
		}
		DarkMachineFunctions.RenderUnityEvent(ref Draw.editor, base.transform, new List<DarkMachineFunctions.RenderUnityEventDesc>
		{
			new DarkMachineFunctions.RenderUnityEventDesc
			{
				ev = pickupEvent,
				prependString = "On Pickup: ",
				color = Color.magenta
			},
			new DarkMachineFunctions.RenderUnityEventDesc
			{
				ev = onPlaceInInventory,
				prependString = "On Place In Inventory: ",
				color = Color.red
			}
		});
	}

	internal void OnPlaceInInventory()
	{
		onPlaceInInventory.Invoke();
	}

	internal void OnPlaceInWorld()
	{
		onPlaceInWorld.Invoke();
	}

	public virtual void OnHover()
	{
		bool flag = false;
		if (itemData.HasTag("unpurchased") || itemData.HasTag("trinket"))
		{
			flag = true;
		}
		if (flag)
		{
			string localization = CL_LocalizationManager.GetLocalization("items", "desc-" + itemData.prefabName);
			if (localization != "")
			{
				CL_UIManager.instance.SetDescription(localization);
			}
		}
	}
}
