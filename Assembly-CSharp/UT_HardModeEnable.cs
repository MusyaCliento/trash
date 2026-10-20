using System;
using UnityEngine;

public class UT_HardModeEnable : MonoBehaviour
{
	public bool disable;

	public bool useCurrentGamemodeInfo;

	public GameObject gamemodeHolder;

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
		if (gamemodeHolder != null)
		{
			base.gameObject.SetActive(gamemodeHolder.GetComponent<GamemodeHolder>().GetGamemode().IsHardMode() ? (!disable) : disable);
		}
		else if (useCurrentGamemodeInfo)
		{
			base.gameObject.SetActive(CL_GameManager.IsHardmode() ? (!disable) : disable);
		}
		else
		{
			base.gameObject.SetActive(CL_GameManager.IsHardmode() ? (!disable) : disable);
		}
	}
}
