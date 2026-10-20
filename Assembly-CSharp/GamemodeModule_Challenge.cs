using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GamemodeModule_Challenge : GamemodeModule
{
	[Serializable]
	public class Medal
	{
		public string medalTitle;

		public Sprite medalSprite;

		public float scoreRequirement;

		public Color textColor = Color.white;

		public AudioClip audioClip;
	}

	public List<Medal> medals;

	public Medal failureMedal;

	public float winScoreMultiplier = 5f;

	public string medalAppend;

	public bool useTime;

	public bool scoreUsesAscent;

	private float addedScore;

	private float bonusScore;

	public float startingScore = 100f;

	private static GamemodeModule_Challenge instance;

	public override void Initialize(M_Gamemode gamemode)
	{
		base.Initialize(gamemode);
		addedScore = 0f;
		bonusScore = 0f;
		instance = this;
	}

	public override void OnFinish(bool hasFinished)
	{
		float score = GetScore(hasFinished);
		Medal currentMedal;
		if (hasFinished)
		{
			currentMedal = GetMedalFromScore(score);
			StatManager.instance.GetScoreScreen(hasFinished).SetMedalInfo(currentMedal.medalTitle + medalAppend, currentMedal.medalSprite, currentMedal.textColor);
			int num = medals.IndexOf(currentMedal) + 1;
			Debug.Log("Got Medal: " + num);
			StatManager.sessionStats.UpdateStatistic("best-medal", num, StatManager.Statistic.DataType.Int, StatManager.Statistic.ModType.Max, StatManager.Statistic.DisplayType.Default, StatManager.Statistic.ModType.Max);
			CL_GameManager.gMan.StartCoroutine(WaitToPlayAudio());
		}
		else
		{
			CL_GameManager.gMan.StartCoroutine(WaitToPlayAudio2());
		}
		IEnumerator WaitToPlayAudio()
		{
			yield return new WaitForSecondsRealtime(0.5f);
			if (currentMedal.audioClip != null)
			{
				AudioManager.PlayUISound(currentMedal.audioClip);
			}
			ChallengeMode.CheckChallengeAchievements();
		}
		IEnumerator WaitToPlayAudio2()
		{
			yield return new WaitForSecondsRealtime(0.5f);
			if (failureMedal != null)
			{
				AudioManager.PlayUISound(failureMedal.audioClip);
			}
		}
	}

	public override float GetScore(bool hasFinished = false)
	{
		float num = 0f;
		if (scoreUsesAscent)
		{
			num = CL_GameManager.gMan.GetPlayerBestTravelDistance() * CL_GameManager.gMan.GetPlayerTravelSpeed();
		}
		else
		{
			num = (addedScore + startingScore) / CL_GameManager.gMan.GetGameTime() + bonusScore;
			Debug.Log(CL_GameManager.gMan.GetGameTime());
			Debug.Log("Score Check = " + num);
			if (!hasFinished)
			{
				num = 0f;
			}
		}
		return (float)Math.Round(num, 2, MidpointRounding.AwayFromZero);
	}

	public Medal GetMedalFromScore(float score)
	{
		Medal result = medals[0];
		foreach (Medal medal in medals)
		{
			if (score >= medal.scoreRequirement)
			{
				result = medal;
			}
		}
		return result;
	}

	public int GetMedalRankFromScore(float score)
	{
		int result = 0;
		for (int i = 0; i < medals.Count; i++)
		{
			if (score >= medals[i].scoreRequirement)
			{
				result = i + 1;
			}
		}
		return result;
	}

	public static void AddScore(float f)
	{
		if (instance != null)
		{
			instance.addedScore += f;
		}
	}

	public static void AddBonusScore(float f)
	{
		if (instance != null)
		{
			instance.bonusScore += f;
		}
	}
}
