using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DropdownBinder : MonoBehaviour
{
	public string settingName;

	public TMP_Dropdown dropdown;

	private Dictionary<int, string> dropdownDictionary;

	private void Start()
	{
		PullSetting();
	}

	private void PullSetting()
	{
		string setting = SettingsManager.GetSetting(settingName);
		dropdown.value = int.Parse(setting);
	}

	public void OnUpdateDropDown()
	{
		SettingsManager.SetSetting(new string[2]
		{
			settingName,
			dropdown.value.ToString()
		});
		SettingsManager.RefreshSettings();
	}
}
