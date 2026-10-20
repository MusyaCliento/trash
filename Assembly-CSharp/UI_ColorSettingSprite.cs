using System;
using UnityEngine;
using UnityEngine.UI;

public class UI_ColorSettingSprite : MonoBehaviour
{
	public Image targetImage;

	public ColorSetting.ColorType colorType;

	private void Awake()
	{
		if (targetImage != null)
		{
			targetImage = GetComponent<Image>();
		}
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Combine(SettingsManager._OnRefreshAllSettings, new Action(CheckStatus));
	}

	private void OnDestroy()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Remove(SettingsManager._OnRefreshAllSettings, new Action(CheckStatus));
	}

	private void OnEnable()
	{
		CheckStatus();
	}

	public void CheckStatus()
	{
		targetImage.color = SettingsManager.GetCurrentColorSetting().GetColor(colorType);
	}
}
