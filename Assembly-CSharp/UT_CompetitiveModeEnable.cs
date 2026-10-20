using System;
using UnityEngine;

public class UT_CompetitiveModeEnable : MonoBehaviour
{
	public bool disable;

	public bool onlyOnEnable;

	private void Awake()
	{
		if (!onlyOnEnable)
		{
			SettingsManager._OnRefreshAllSettings = (Action)Delegate.Combine(SettingsManager._OnRefreshAllSettings, new Action(CheckStatus));
		}
	}

	private void OnDestroy()
	{
		if (!onlyOnEnable)
		{
			SettingsManager._OnRefreshAllSettings = (Action)Delegate.Remove(SettingsManager._OnRefreshAllSettings, new Action(CheckStatus));
		}
	}

	private void OnEnable()
	{
		CheckStatus();
	}

	public void CheckStatus()
	{
		if (CL_GameManager.GetCurrentGamemode() != null)
		{
			base.gameObject.SetActive(CL_GameManager.GetCurrentGamemode().IsCompetitive() ? (!disable) : disable);
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
