using System.Collections.Generic;
using UnityEngine;

public class UT_PerkHolder : MonoBehaviour
{
	public List<Perk> stashedPerks;

	public List<string> tagsWhitelist;

	public List<string> tagsBlacklist;

	public void StashAllPlayerPerks()
	{
		ENT_Player player = ENT_Player.GetPlayer();
		int count = player.perks.Count;
		while (count-- > 0)
		{
			Perk perk = player.perks[count];
			bool flag = false;
			bool flag2 = tagsWhitelist.Count == 0;
			foreach (string item in tagsWhitelist)
			{
				flag2 |= perk.tags.Contains(item);
			}
			flag = !flag2;
			foreach (string item2 in tagsBlacklist)
			{
				flag &= !perk.tags.Contains(item2);
			}
			if (flag)
			{
				player.RemovePerk(perk);
				stashedPerks.Add(perk);
			}
		}
		player.curBuffs.UpdateBuffs();
		player.ClearExtraJumpsRemaining();
	}

	public void RestoreAllPlayerPerks()
	{
		ENT_Player player = ENT_Player.GetPlayer();
		foreach (Perk stashedPerk in stashedPerks)
		{
			player.AddPerk(stashedPerk, stashedPerk.stackAmount, firstTime: false);
		}
		stashedPerks.Clear();
	}
}
