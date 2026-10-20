using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Settings_Resolution : MonoBehaviour
{
	public TMP_Dropdown dropdown;

	private Resolution[] resolutions;

	private void Start()
	{
		resolutions = Screen.resolutions;
		List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
		int num = -1;
		for (int i = 0; i < resolutions.Length; i++)
		{
			TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData();
			optionData.text = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRateRatio.value + "hz";
			if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height && resolutions[i].refreshRateRatio.value.ToString() == SettingsManager.settings.refreshRate)
			{
				num = i;
			}
			list.Add(optionData);
		}
		if (num == -1)
		{
			TMP_Dropdown.OptionData optionData2 = new TMP_Dropdown.OptionData();
			optionData2.text = Screen.currentResolution.width + "x" + Screen.currentResolution.height + " " + Screen.currentResolution.refreshRateRatio.value + "hz";
			list.Add(optionData2);
			num = list.Count - 1;
		}
		dropdown.AddOptions(list);
		dropdown.value = num;
	}

	public void OnUpdateDropDown()
	{
		if (dropdown.value < resolutions.Length)
		{
			Resolution resolution = resolutions[dropdown.value];
			SettingsManager.SetSetting(new string[2]
			{
				"screenResX",
				resolution.width.ToString()
			});
			SettingsManager.SetSetting(new string[2]
			{
				"screenResY",
				resolution.height.ToString()
			});
			SettingsManager.SetSetting(new string[2]
			{
				"refreshRate",
				resolution.refreshRateRatio.value.ToString()
			});
			SettingsManager.RefreshSettings();
		}
	}
}
