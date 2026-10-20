using UnityEngine;

public class UT_ScoreSetter : MonoBehaviour
{
	public string scoreID;

	public string scoreTitle;

	public float scoreBonus;

	public float winScoreMultiplier;

	public int scoreCount;

	public void AddScore()
	{
		CL_ScoreManager.sessionScore.AddScore(scoreID, scoreTitle, scoreBonus, winScoreMultiplier, scoreCount);
	}
}
