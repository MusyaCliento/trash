using System;
using TMPro;
using UnityEngine;

public class TextSettingsBinder : MonoBehaviour
{
	public string settingName;

	private TMP_Text text;

	public int roundedLevel = 2;

	private void Start()
	{
		text = GetComponent<TMP_Text>();
		PullSetting();
	}

	private void PullSetting()
	{
		string setting = SettingsManager.GetSetting(settingName);
		if (setting != null && !(text == null))
		{
			text.text = setting;
		}
	}

	public void DisplayFloat(float value)
	{
		float num = (float)Math.Round(value, roundedLevel);
		if (text != null)
		{
			text.text = num.ToString() ?? "";
		}
	}
}
