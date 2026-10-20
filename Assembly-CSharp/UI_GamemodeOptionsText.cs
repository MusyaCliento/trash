using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_GamemodeOptionsText : MonoBehaviour
{
	public GameObject gamemodeHolderObject;

	private GamemodeHolder gamemodeHolder;

	private TMP_Text text;

	private void OnEnable()
	{
		if (gamemodeHolderObject != null)
		{
			gamemodeHolder = gamemodeHolderObject.GetComponent<GamemodeHolder>();
		}
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Combine(SettingsManager._OnRefreshAllSettings, new Action(Refresh));
		Refresh();
	}

	public void Refresh()
	{
		this.text = GetComponent<TMP_Text>();
		string text = "";
		M_Gamemode m_Gamemode = CL_GameManager.GetBaseGamemode();
		if (gamemodeHolder != null)
		{
			m_Gamemode = gamemodeHolder.GetGamemode();
		}
		List<GamemodeSetting> activeSettings = m_Gamemode.GetActiveSettings();
		if (activeSettings.Count > 0)
		{
			foreach (GamemodeSetting gamemodeSetting in m_Gamemode.gamemodeSettings)
			{
				for (int i = 0; i < activeSettings.Count; i++)
				{
					if (gamemodeSetting.id == activeSettings[i].id)
					{
						text = text + "<color=#" + ColorUtility.ToHtmlStringRGB(activeSettings[i].color) + ">" + activeSettings[i].title + "</color> ";
					}
				}
			}
		}
		this.text.text = text;
	}

	private void OnDisable()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Remove(SettingsManager._OnRefreshAllSettings, new Action(Refresh));
	}
}
