using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VoiceSettingsBinder : MonoBehaviour
{
	public string settingName;

	public Button voiceToggle;

	public TMP_Text text;

	private int curValue;

	public AudioClip[] voiceExamples;

	private void Start()
	{
		PullSetting();
		voiceToggle.onClick.AddListener(delegate
		{
			UpdateSetting();
		});
	}

	private void PullSetting()
	{
		ToggleDisplay(curValue = int.Parse(SettingsManager.GetSetting(settingName)));
	}

	private void ToggleDisplay(int value)
	{
		text.text = "Voice " + (value + 1);
	}

	public void UpdateSetting()
	{
		if (curValue == 1)
		{
			curValue = 0;
		}
		else
		{
			curValue = 1;
		}
		ToggleDisplay(curValue);
		AudioManager.PlayUISound(voiceExamples[curValue], 0.7f);
		SettingsManager.SetSetting(new string[2]
		{
			settingName,
			curValue.ToString()
		});
		SettingsManager.RefreshSettings(settingName);
	}
}
