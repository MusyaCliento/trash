using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ENV_Barterer : MonoBehaviour
{
	[Serializable]
	public class PriceOverride
	{
		public string tag;

		public int price;
	}

	public BoxCollider inputZone;

	public LayerMask mask;

	public Transform sellItemLocator;

	public Transform buyItemLocator;

	public List<Item_Object> itemsInZone = new List<Item_Object>();

	private int currentValue;

	public UnityEvent eventOnPurchaseFailure;

	public UnityEvent eventOnCanPurchase;

	public UnityEvent eventOnCannotPurchase;

	public UnityEvent<List<Item_Object>> eventOnPurchaseSuccess;

	public UnityEvent<int> eventOnValueChange;

	public NumberCounter saleValueCounter;

	public NumberCounter buyValueCounter;

	public NumberCounter totalCounter;

	public bool destroyItemsOnPurchase;

	public List<PriceOverride> priceOverrides;

	private void Start()
	{
		eventOnCannotPurchase.Invoke();
	}

	private void Update()
	{
		ScanForItems();
	}

	private void ScanForItems()
	{
		Collider[] array = Physics.OverlapBox(inputZone.transform.position, inputZone.size / 2f, inputZone.transform.rotation, mask);
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		if (array.Length != 0)
		{
			bool flag = false;
			itemsInZone.Clear();
			Collider[] array2 = array;
			foreach (Collider collider in array2)
			{
				collider.GetComponent<Rigidbody>();
				ObjectTagger component = collider.GetComponent<ObjectTagger>();
				if (!(component != null) || !component.HasTag("Item"))
				{
					continue;
				}
				Item_Object component2 = collider.GetComponent<Item_Object>();
				if (itemsInZone.Contains(component2))
				{
					continue;
				}
				Denizen component3 = collider.GetComponent<Denizen>();
				if (component3 != null)
				{
					DEN_Roach component4 = collider.GetComponent<DEN_Roach>();
					if (component4 != null)
					{
						component4.speed = 0f;
						component4.runSpeed = 0.2f;
						component4.canSquish = false;
						component4.sightDistance = 0.4f;
					}
					else
					{
						component3.enabled = false;
					}
				}
				num++;
				if (CL_UIManager.debug)
				{
					CL_DebugView.draw.Label3D(base.transform.position + Vector3.up * num * 0.15f, base.transform.rotation, $"Item: {num} {component.gameObject.name}", 0.15f);
				}
				itemsInZone.Add(component2);
				if (!(component2 != null))
				{
					continue;
				}
				int num5 = component2.itemData.worth;
				foreach (PriceOverride priceOverride in priceOverrides)
				{
					if (component2.itemData.HasTag(priceOverride.tag))
					{
						num5 = priceOverride.price;
						break;
					}
				}
				if (component2.itemData.HasTag("unpurchased"))
				{
					flag = true;
					num2 -= num5;
					num4 += num5;
				}
				else
				{
					num2 += num5;
					num3 += num5;
				}
			}
			if (currentValue != num2)
			{
				eventOnValueChange.Invoke(num2);
				currentValue = num2;
				if (totalCounter != null)
				{
					totalCounter.SetDigits(num2);
				}
				if (buyValueCounter != null)
				{
					buyValueCounter.SetDigits(num3);
				}
				if (saleValueCounter != null)
				{
					saleValueCounter.SetDigits(num4);
				}
				if (currentValue >= 0 && flag)
				{
					eventOnCanPurchase.Invoke();
				}
				else
				{
					eventOnCannotPurchase.Invoke();
				}
			}
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Label3D(base.transform.position + Vector3.up * (num + 1) * 0.15f, base.transform.rotation, $"Total Worth: {num2}", 0.15f, Color.red);
			}
		}
		else if (currentValue != num2)
		{
			eventOnValueChange.Invoke(num2);
			currentValue = num2;
			if (totalCounter != null)
			{
				totalCounter.SetDigits(num2);
			}
			if (buyValueCounter != null)
			{
				buyValueCounter.SetDigits(num3);
			}
			if (saleValueCounter != null)
			{
				saleValueCounter.SetDigits(num4);
			}
			eventOnCannotPurchase.Invoke();
		}
	}

	public void TryPurchase()
	{
		List<Item_Object> list = new List<Item_Object>();
		if (itemsInZone.Count > 0 && currentValue >= 0)
		{
			foreach (Item_Object item in itemsInZone)
			{
				if (item.itemData.HasTag("unpurchased"))
				{
					item.itemData.itemTags.Remove("unpurchased");
					StatManager.sessionStats.UpdateStatistic("bazaar-buy-item-" + item.itemData.itemName, 1, StatManager.Statistic.DataType.Int, StatManager.Statistic.ModType.Add);
					ObjectTagger tagger = item.GetTagger();
					if (tagger != null)
					{
						tagger.RemoveTag("ItemLocked");
					}
				}
				else if (destroyItemsOnPurchase)
				{
					item.itemData.Destroy();
				}
				else
				{
					list.Add(item);
				}
			}
			eventOnPurchaseSuccess.Invoke(list);
		}
		else
		{
			eventOnPurchaseFailure.Invoke();
		}
	}

	public void PlaceItem(Item item)
	{
		if (item.HasTag("unpurchased"))
		{
			item.GetDropObject().transform.position = sellItemLocator.transform.position;
			item.GetDropObject().transform.rotation = sellItemLocator.transform.rotation;
		}
		else
		{
			item.GetDropObject().transform.position = buyItemLocator.transform.position;
			item.GetDropObject().transform.rotation = buyItemLocator.transform.rotation;
		}
	}

	internal bool CanAfford()
	{
		if (itemsInZone.Count > 0 && currentValue >= 0)
		{
			return true;
		}
		return false;
	}
}
