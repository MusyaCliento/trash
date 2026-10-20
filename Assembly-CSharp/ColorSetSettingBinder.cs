using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorSetSettingBinder : MonoBehaviour
{
	public string settingName;

	public TMP_Text text;

	public bool showColorSetInfo = true;

	public string textTitle = "Shimmer Color";

	private void Start()
	{
		if (TryGetComponent<Button>(out var component))
		{
			component.onClick.AddListener(Swap);
		}
		UpdateText();
	}

	private void Swap()
	{
		string setting = SettingsManager.GetSetting(settingName);
		int num = 0;
		for (int i = 0; i < SettingsManager.GetColorSettingsSet().colorSettings.Count; i++)
		{
			if (SettingsManager.GetColorSettingsSet().colorSettings[i].name == setting)
			{
				num = i;
				break;
			}
		}
		num++;
		if (num >= SettingsManager.GetColorSettingsSet().colorSettings.Count)
		{
			num = 0;
		}
		SettingsManager.SetSetting(new string[2]
		{
			settingName,
			SettingsManager.GetColorSettingsSet().colorSettings[num].name
		});
		SettingsManager.RefreshSettings(settingName);
		UpdateText();
	}

	public void UpdateText()
	{
		int num = 0;
		string setting = SettingsManager.GetSetting(settingName);
		for (int i = 0; i < SettingsManager.GetColorSettingsSet().colorSettings.Count; i++)
		{
			if (SettingsManager.GetColorSettingsSet().colorSettings[i].name == setting)
			{
				num = i;
				break;
			}
		}
		if (showColorSetInfo && text != null)
		{
			text.text = $"{textTitle}\n<color=grey>{SettingsManager.GetColorSettingsSet().colorSettings[num].title} ({num + 1}/{SettingsManager.GetColorSettingsSet().colorSettings.Count})";
		}
	}
}
