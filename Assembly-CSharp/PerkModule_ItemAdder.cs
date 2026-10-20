using System.Collections.Generic;
using UnityEngine;

public class PerkModule_ItemAdder : PerkModule
{
	public List<Item_Object> itemsToAdd;

	public override void AddModule(int amount = 1, bool firstTime = true)
	{
		base.AddModule(amount, firstTime);
		if (firstTime)
		{
			Debug.Log("Adding items into inventory - " + perk.name);
			foreach (Item_Object item in itemsToAdd)
			{
				Debug.Log(item.name);
			}
			List<Item> list = new List<Item>();
			foreach (Item_Object item2 in itemsToAdd)
			{
				if (!(item2 == null))
				{
					Item clone = item2.itemData.GetClone();
					clone.bagPosition = new Vector3(0f, 0f, 1f) + Random.insideUnitSphere * 0.01f;
					clone.bagRotation = Quaternion.LookRotation(clone.upDirection);
					list.Add(clone);
				}
			}
			Inventory.instance.LoadItemsIntoBag(list);
		}
		else
		{
			Debug.Log("Not adding items as firstTime is false");
		}
		perk.RemoveModule(this);
	}
}
