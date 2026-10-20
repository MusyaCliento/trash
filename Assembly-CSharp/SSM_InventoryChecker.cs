using System.Collections.Generic;
using UnityEngine;

public class SSM_InventoryChecker : SpawnSettingModule
{
	public List<string> inventoryCheckTags;

	[Range(0f, 1f)]
	public float trueValue = 1f;

	[Range(0f, 1f)]
	public float falseValue;

	public override float Check()
	{
		bool flag = false;
		foreach (string inventoryCheckTag in inventoryCheckTags)
		{
			if (Inventory.instance.HasItemWithTag(inventoryCheckTag))
			{
				flag = true;
			}
		}
		if (flag)
		{
			return trueValue;
		}
		return falseValue;
	}
}
