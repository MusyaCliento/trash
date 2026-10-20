using System.Collections.Generic;
using UnityEngine;

public class UT_DebugController : MonoBehaviour
{
	public void ToggleNoclip()
	{
		ENT_Player.playerObject.noclip = !ENT_Player.playerObject.noclip;
	}

	public void GiveItem(Item_Object o)
	{
		List<Item> list = new List<Item>();
		Item clone = o.itemData.GetClone();
		clone.bagPosition = new Vector3(0f, 0f, 1f) + Random.insideUnitSphere * 0.01f;
		clone.bagRotation = Quaternion.LookRotation(clone.upDirection);
		list.Add(clone);
		Inventory.instance.LoadItemsIntoBag(list);
	}

	public void TeleportPlayerToLevel(string s)
	{
		WorldLoader.instance.TeleportPlayerToTargetLevel(new string[1] { s });
	}

	public void KillPlayer()
	{
		ENT_Player.playerObject.Kill("", null);
	}

	public void ToggleFullbright()
	{
		FXManager.Fullbright(new string[0]);
	}

	public void ToggleMass()
	{
		DEN_DeathFloor.instance.DeathGooToggle(new string[0]);
	}
}
