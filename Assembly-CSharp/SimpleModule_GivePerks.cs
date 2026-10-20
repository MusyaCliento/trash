using System.Collections.Generic;

public class SimpleModule_GivePerks : SimpleModule
{
	public List<Perk> GetPerks;

	public bool onlyAddIfPlayerDoesntHave = true;

	private List<string> addedPerkIDs = new List<string>();

	public override void Activate()
	{
		base.Activate();
		foreach (Perk getPerk in GetPerks)
		{
			if (!ENT_Player.GetPlayer().HasPerk(getPerk.id) || !onlyAddIfPlayerDoesntHave)
			{
				ENT_Player.GetPlayer().AddPerk(getPerk);
				addedPerkIDs.Add(getPerk.id);
			}
		}
	}

	public override void Deactivate()
	{
		base.Deactivate();
		foreach (string addedPerkID in addedPerkIDs)
		{
			ENT_Player.GetPlayer().RemovePerk(addedPerkID, removeAll: false);
		}
	}
}
