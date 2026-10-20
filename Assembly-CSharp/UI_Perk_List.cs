using System.Collections.Generic;
using UnityEngine;

public class UI_Perk_List : MonoBehaviour
{
	public bool showAllPerks;

	public UI_Perk_Icon perkIconAsset;

	private List<UI_Perk_Icon> spawnedIcons = new List<UI_Perk_Icon>();

	private void OnEnable()
	{
		foreach (Transform item in base.transform)
		{
			Object.Destroy(item.gameObject);
		}
		List<Perk> list = new List<Perk>();
		ENT_Player player = ENT_Player.GetPlayer();
		if (showAllPerks && player != null)
		{
			list.AddRange(player.GetOldPerks());
		}
		if (!showAllPerks && player != null)
		{
			list.AddRange(player.perks);
		}
		foreach (Perk item2 in list)
		{
			UI_Perk_Icon uI_Perk_Icon = Object.Instantiate(perkIconAsset, base.transform);
			uI_Perk_Icon.SetPerk(item2);
			spawnedIcons.Add(uI_Perk_Icon);
		}
	}
}
