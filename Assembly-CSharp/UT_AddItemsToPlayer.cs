using System.Collections.Generic;
using UnityEngine;

public class UT_AddItemsToPlayer : MonoBehaviour
{
	public bool addAllItems = true;

	public List<Item_Object> itemsToAdd;

	private void Start()
	{
	}

	public void AddItems()
	{
		List<Item> list = new List<Item>();
		if (addAllItems)
		{
			foreach (Item_Object item in itemsToAdd)
			{
				if (!(item == null))
				{
					Item clone = item.itemData.GetClone();
					clone.bagPosition = new Vector3(0f, 0f, 1f) + Random.insideUnitSphere * 0.01f;
					clone.bagRotation = Quaternion.LookRotation(clone.upDirection);
					list.Add(clone);
				}
			}
		}
		else
		{
			Item clone2 = itemsToAdd[Random.Range(0, itemsToAdd.Count)].itemData.GetClone();
			clone2.bagPosition = new Vector3(0f, 0f, 1f) + Random.insideUnitSphere * 0.01f;
			clone2.bagRotation = Quaternion.LookRotation(clone2.upDirection);
			list.Add(clone2);
		}
		Inventory.instance.LoadItemsIntoBag(list);
	}
}
