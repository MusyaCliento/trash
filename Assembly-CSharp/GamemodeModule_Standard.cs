using System;

[Serializable]
public class GamemodeModule_Standard : GamemodeModule
{
	public float winScoreMultiplier = 5f;

	public bool divideScoreOnMultiDeath;

	public override void OnFinish(bool hasFinished)
	{
		if (hasFinished)
		{
			CL_ScoreManager.sessionScore.AddScore("win", "Won", 0f, winScoreMultiplier - 1f);
		}
		if (divideScoreOnMultiDeath)
		{
			int statisticInt = StatManager.GetStatisticInt(StatManager.sessionStats, "revives");
			if (statisticInt > 0)
			{
				float bonusMultiplier = 1f / ((float)statisticInt + 1f);
				CL_ScoreManager.sessionScore.AddScore("reviveloss", "Revive Loss", 0f, 0f, 0, 1f, 1f, bonusMultiplier);
			}
		}
	}

	public override float GetScore(bool hasFinished = false)
	{
		return (float)Math.Round((CL_GameManager.gMan.GetPlayerBestTravelDistance() * CL_GameManager.gMan.GetPlayerTravelSpeed() + CL_ScoreManager.GetCurrentScoreBonus()) * CL_ScoreManager.GetCurrentScoreMultiplier(), 2, MidpointRounding.AwayFromZero);
	}

	public override float GetBaseScore()
	{
		return CL_GameManager.gMan.GetPlayerBestTravelDistance() * CL_GameManager.gMan.GetPlayerTravelSpeed();
	}
}
