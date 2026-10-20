using System;
using UnityEngine;
using UnityEngine.Events;

public class UT_SettingEvent : MonoBehaviour
{
	public string settingName;

	public UnityEvent activeEvent;

	public UnityEvent inactiveEvent;

	public bool runOnSettingChange;

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
		if (bool.Parse(SettingsManager.GetSetting(settingName)))
		{
			activeEvent.Invoke();
		}
		else
		{
			inactiveEvent.Invoke();
		}
	}
}
