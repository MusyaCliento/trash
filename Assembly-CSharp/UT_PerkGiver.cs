using System.Collections.Generic;
using UnityEngine;

public class UT_PerkGiver : MonoBehaviour
{
	public List<Perk> perks;

	public bool giveRandomPerks;

	public int randomPerkNumber = 1;

	public void GivePerksToPlayer()
	{
		if (giveRandomPerks)
		{
			for (int i = 0; i < randomPerkNumber; i++)
			{
				ENT_Player.playerObject.AddPerk(perks[Random.Range(0, perks.Count)]);
			}
			return;
		}
		foreach (Perk perk in perks)
		{
			ENT_Player.playerObject.AddPerk(perk);
		}
	}

	public void RemovePerkFromPlayer(string id)
	{
		ENT_Player.GetPlayer().RemovePerk(id);
	}
}
