using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemExecutionModule_PerkAdder : ItemExecutionModule
{
	public bool onPickupAndDrop = true;

	public bool onEnterInventory;

	public bool excludeInHand = true;

	private bool isInInventory;

	private bool hasActivated;

	[Header("Perk Adder")]
	public List<Perk> GetPerks;

	private List<string> addedPerkIDs = new List<string>();

	public override void Initialize(Item i)
	{
		base.Initialize(i);
		if (!onPickupAndDrop && !onEnterInventory)
		{
			Activate();
		}
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		Deactivate();
	}

	public override void OnPickup()
	{
		base.OnPickup();
		if (onPickupAndDrop)
		{
			Activate();
		}
	}

	public override void OnDrop()
	{
		base.OnDrop();
		if (onPickupAndDrop)
		{
			Deactivate();
		}
	}

	public override void Execute()
	{
		base.Execute();
		if (!onEnterInventory)
		{
			return;
		}
		if (item.InInventory())
		{
			if (excludeInHand && item.InHand())
			{
				if (isInInventory)
				{
					isInInventory = false;
					Deactivate();
				}
			}
			else if (!isInInventory)
			{
				isInInventory = true;
				Activate();
			}
		}
		else if (isInInventory)
		{
			isInInventory = false;
			Deactivate();
		}
	}

	private void Activate()
	{
		if (hasActivated)
		{
			return;
		}
		foreach (Perk getPerk in GetPerks)
		{
			int count = ENT_Player.GetInventory().GetItemsByPrefab(item.prefabName, !excludeInHand).Count;
			Debug.Log("Activating Item! " + count);
			if (ENT_Player.GetPlayer().HasPerk(getPerk.id))
			{
				ENT_Player.GetPlayer().GetPerk(getPerk.id).SetStackAmount(count);
			}
			else
			{
				ENT_Player.GetPlayer().AddPerk(getPerk, count);
			}
		}
		hasActivated = true;
	}

	private void Deactivate()
	{
		if (!hasActivated)
		{
			return;
		}
		foreach (Perk getPerk in GetPerks)
		{
			int count = ENT_Player.GetInventory().GetItemsByPrefab(item.prefabName, !excludeInHand).Count;
			Debug.Log("Deactivating Item! " + count);
			if (ENT_Player.GetPlayer().HasPerk(getPerk.id))
			{
				ENT_Player.GetPlayer().GetPerk(getPerk.id).SetStackAmount(count);
			}
		}
		hasActivated = false;
	}

	public override ItemExecutionModule GetCopy()
	{
		return new ItemExecutionModule_PerkAdder
		{
			onPickupAndDrop = onPickupAndDrop,
			onEnterInventory = onEnterInventory,
			excludeInHand = excludeInHand,
			GetPerks = GetPerks
		};
	}
}
