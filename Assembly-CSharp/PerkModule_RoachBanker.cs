using System.Collections.Generic;
using UnityEngine;

public class PerkModule_RoachBanker : PerkModule
{
	public string itemTag;

	public bool bagOnly;

	public AudioClip bankClip;

	public GameObject removeEffect;

	public BuffContainer bankBuff;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
	}

	public override void Update()
	{
		base.Update();
		List<Item> itemsByTag = Inventory.instance.GetItemsByTag(itemTag, checkBag: true, !bagOnly);
		if (!((float)itemsByTag.Count > 0f))
		{
			return;
		}
		foreach (Item item in itemsByTag)
		{
			if (item.inBag)
			{
				int result = 1;
				int.TryParse(itemsByTag[0].data[0], out result);
				CL_GameManager.AddRoaches(result);
				CL_ScoreManager.sessionScore.AddScore("Roaches Banked", "Roaches Banked", result * 20, 0f, result);
				perk.player.AddNewBuff(bankBuff.CopyBuffContainer());
				item.inBag = false;
			}
		}
		if (itemsByTag != null && itemsByTag.Count > 0 && removeEffect != null && itemsByTag[0].GetDropObject() != null && itemsByTag[0].GetDropObject().transform != null)
		{
			Vector3 position = itemsByTag[0].GetDropObject().transform.position;
			if (!Inventory.IsShowingInventory())
			{
				position = perk.player.cam.transform.position + perk.player.cam.transform.forward;
			}
			Object.Instantiate(removeEffect, position, Quaternion.identity);
		}
		Inventory.instance.ClearItemFromInventory(itemsByTag[0]);
		if (bankClip != null)
		{
			AudioManager.PlaySound(bankClip, perk.player.transform.position, 0.5f, 1f, 0.3f);
		}
	}
}
