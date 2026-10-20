using System;
using UnityEngine;

public class UT_ExperimentalFeatureEnable : MonoBehaviour
{
	public bool disable;

	private void Awake()
	{
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
		base.gameObject.SetActive(SettingsManager.settings.experimentalFeatures ? (!disable) : disable);
	}
}
