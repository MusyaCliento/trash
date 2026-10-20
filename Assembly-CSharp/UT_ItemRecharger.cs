using UnityEngine;
using UnityEngine.Events;

public class UT_ItemRecharger : MonoBehaviour, Clickable
{
	public bool active = true;

	public int maxUses = -1;

	private int currentUses;

	public UnityEvent rechargeEvent;

	public bool CanRecharge()
	{
		if (maxUses != -1 && currentUses > maxUses)
		{
			return false;
		}
		return true;
	}

	internal void Recharge(Item item, string rechargeDataName, string rechargeMaxDataName)
	{
		if (maxUses != -1 && currentUses > maxUses)
		{
			return;
		}
		rechargeEvent.Invoke();
		string firstDataStringByType = item.GetFirstDataStringByType(rechargeMaxDataName);
		item.SetFirstDataStringsofType(rechargeDataName, firstDataStringByType);
		if (item.GetHandItem() != null)
		{
			HandItem_Shoot component = item.GetHandItem().GetComponent<HandItem_Shoot>();
			if (component != null)
			{
				component.Recharge();
			}
			item.GetHandItem().Refresh();
		}
		currentUses++;
	}

	public bool CanInteract(Interaction info)
	{
		if (!active)
		{
			return false;
		}
		Item currentItem = info.curhand.inventoryHand.currentItem;
		if (currentItem != null && currentItem.interactType == Item.InteractType.usable)
		{
			return true;
		}
		return false;
	}
}
