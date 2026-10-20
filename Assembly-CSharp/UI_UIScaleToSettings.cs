using System;
using UnityEngine;

public class UI_UIScaleToSettings : MonoBehaviour
{
	private void OnEnable()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Combine(SettingsManager._OnRefreshAllSettings, new Action(Refresh));
		Refresh();
	}

	private void OnDisable()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Remove(SettingsManager._OnRefreshAllSettings, new Action(Refresh));
	}

	private void Refresh()
	{
		base.transform.localScale = Vector3.one * (float)SettingsManager.settings.UIScale;
	}
}
