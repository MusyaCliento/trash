using System;
using UnityEngine;

public class UT_EntomophobiaDisabler : MonoBehaviour
{
	public bool runOnSettingChange = true;

	public bool hideOnSettingActive = true;

	private void Start()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Combine(SettingsManager._OnRefreshAllSettings, new Action(OnUpdateChange));
		CheckStatus();
	}

	private void OnDestroy()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Remove(SettingsManager._OnRefreshAllSettings, new Action(OnUpdateChange));
	}

	public void OnUpdateChange()
	{
		if (runOnSettingChange)
		{
			CheckStatus();
		}
	}

	public void CheckStatus()
	{
		bool entomophobia = SettingsManager.settings.entomophobia;
		base.gameObject.SetActive(entomophobia ? (!hideOnSettingActive) : hideOnSettingActive);
	}
}
