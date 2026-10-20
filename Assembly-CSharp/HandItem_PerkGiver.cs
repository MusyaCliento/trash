using System.Collections.Generic;
using UnityEngine.Events;

public class HandItem_PerkGiver : HandItem
{
	public List<Perk> pickupPerks;

	public int pouches;

	public UnityEvent applyEvent;

	public override void Start()
	{
		base.Start();
		applyEvent.Invoke();
		foreach (Perk pickupPerk in pickupPerks)
		{
			ENT_Player.GetPlayer().AddPerk(pickupPerk);
		}
		if (pouches > 0)
		{
			for (int i = 0; i < pouches; i++)
			{
				Inventory.instance.AddExtraPouch();
			}
		}
		item.Destroy();
	}
}
