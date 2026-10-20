using System;
using System.Collections.Generic;
using UnityEngine;

public class ENV_RationVendor : MonoBehaviour, SaveableObject
{
	public string saveId = "";

	public List<UT_SpawnEntityByID> vendoredItems = new List<UT_SpawnEntityByID>();

	public UT_Door door;

	public CL_Button button;

	public bool CanSave(string[] flags = null)
	{
		return true;
	}

	public string GetSaveID()
	{
		return saveId;
	}

	public SaveableInfo GetSaveInfo()
	{
		SaveableInfo saveableInfo = new SaveableInfo();
		saveableInfo.id = saveId;
		bool flag = door.IsOpen();
		saveableInfo.data = (flag ? "1" : "0");
		if (flag)
		{
			foreach (UT_SpawnEntityByID vendoredItem in vendoredItems)
			{
				string text = ((vendoredItem != null && vendoredItem.hasSpawned) ? "1" : "0");
				saveableInfo.data += text;
			}
		}
		return saveableInfo;
	}

	public void SetSaveInfo(SaveableInfo info, List<string> flags)
	{
		if (info.data.Length > 0 && info.data[0] != '0')
		{
			door.startOpen = true;
			button.active = false;
		}
		ReadOnlySpan<char> readOnlySpan = default(ReadOnlySpan<char>);
		if (info.data.Length > 1)
		{
			ReadOnlySpan<char> readOnlySpan2 = info.data.AsSpan();
			readOnlySpan = readOnlySpan2.Slice(1, readOnlySpan2.Length - 1);
		}
		int num = Mathf.Min(vendoredItems.Count, readOnlySpan.Length);
		for (int i = 0; i < num; i++)
		{
			if (readOnlySpan[i] != '0' && vendoredItems[i] != null)
			{
				vendoredItems[i].hasSpawned = true;
			}
		}
	}
}
