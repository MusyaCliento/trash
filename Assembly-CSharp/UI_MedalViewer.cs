using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_MedalViewer : MonoBehaviour
{
	public enum ViewerType
	{
		currentGamemode = 0,
		allGamemodes = 1
	}

	public List<Sprite> medalSprites;

	public Image medalImage;

	public TMP_Text counterText;

	public bool showMedalGoal;

	public int medalGoalLevel;

	public bool onlyShowIfSuccessful;

	public GameObject gamemodeHolder;

	private void OnEnable()
	{
		Refresh();
	}

	public void Refresh()
	{
		StartCoroutine(WaitOneFrame());
		IEnumerator WaitOneFrame()
		{
			yield return null;
			if (!showMedalGoal)
			{
				UpdateMedalIcon();
			}
			else
			{
				UpdateGoalInfo();
			}
		}
	}

	private void UpdateMedalIcon()
	{
		M_Gamemode m_Gamemode = null;
		if (gamemodeHolder != null)
		{
			m_Gamemode = gamemodeHolder.GetComponent<GamemodeHolder>().GetGamemode();
			Debug.Log(gamemodeHolder.GetComponent<GamemodeHolder>());
			Debug.Log("Attempting to Get Gamemode from Holder");
		}
		else
		{
			m_Gamemode = CL_GameManager.GetCurrentGamemode();
		}
		Debug.Log(m_Gamemode);
		if (m_Gamemode != null)
		{
			int num = ChallengeMode.GetMedalRankFromGamemode(m_Gamemode);
			bool flag = m_Gamemode.HasWonGamemode();
			Debug.Log("Gamemode: " + m_Gamemode?.ToString() + " :: " + num + " :: " + flag);
			if (onlyShowIfSuccessful)
			{
				num--;
			}
			if (num < 0 || (onlyShowIfSuccessful && !flag))
			{
				medalImage.color = Color.clear;
				return;
			}
			Debug.Log("Best Medal Found: " + num);
			medalImage.sprite = medalSprites[num];
			medalImage.color = Color.white;
		}
		else
		{
			medalImage.sprite = medalSprites[0];
			medalImage.color = Color.clear;
		}
	}

	public void UpdateGoalInfo()
	{
		M_Gamemode m_Gamemode = null;
		m_Gamemode = ((!(gamemodeHolder != null)) ? CL_GameManager.GetCurrentGamemode() : gamemodeHolder.GetComponent<GamemodeHolder>().GetGamemode());
		if (m_Gamemode != null && m_Gamemode.gamemodeModule.GetType() == typeof(GamemodeModule_Challenge))
		{
			GamemodeModule_Challenge gamemodeModule_Challenge = (GamemodeModule_Challenge)m_Gamemode.gamemodeModule;
			GamemodeModule_Challenge.Medal medal = gamemodeModule_Challenge.medals[medalGoalLevel];
			medalImage.sprite = medalSprites[medalGoalLevel];
			if (gamemodeModule_Challenge.useTime)
			{
				string text = TimeSpan.FromSeconds(Mathf.Round(gamemodeModule_Challenge.startingScore / medal.scoreRequirement)).ToString("mm\\:ss");
				counterText.text = text;
			}
			else
			{
				counterText.text = medal.scoreRequirement.ToString();
			}
		}
	}
}
