using System;
using System.Collections.Generic;
using UnityEngine;

public class CL_ScoreManager
{
	[Serializable]
	public class SessionScore
	{
		[Serializable]
		public class Score
		{
			public string id;

			public string title;

			public float bonus;

			public float multiplier;

			public float stackMultiplier = 1f;

			public float stackDivide = 1f;

			public float bonusMultiplier = 1f;

			public int count;
		}

		public List<Score> scores;

		public Dictionary<string, Score> scoreDict;

		public void AddScore(string id, string title = "", float bonus = 0f, float multiplier = 0f, int count = 0, float stackMultiplier = 1f, float stackDivide = 1f, float bonusMultiplier = 1f)
		{
			if (scores == null)
			{
				Initialize();
			}
			if (scoreDict.ContainsKey(id))
			{
				scoreDict[id].bonus += bonus;
				scoreDict[id].multiplier += multiplier;
				scoreDict[id].count += count;
				if (scoreDict[id].multiplier < -1f)
				{
					scoreDict[id].multiplier = -1f;
				}
			}
			else
			{
				Score score = new Score
				{
					id = id,
					bonus = bonus,
					multiplier = multiplier,
					title = title,
					count = count,
					stackMultiplier = stackMultiplier,
					stackDivide = stackDivide,
					bonusMultiplier = bonusMultiplier
				};
				scores.Add(score);
				scoreDict.Add(id, score);
			}
		}

		public void Initialize()
		{
			if (scores == null)
			{
				scores = new List<Score>();
			}
			scoreDict = new Dictionary<string, Score>();
			foreach (Score score in scores)
			{
				scoreDict.Add(score.id, score);
			}
		}
	}

	public static SessionScore sessionScore;

	public static void Initialize(SessionScore sessionToLoad = null)
	{
		if (sessionToLoad == null)
		{
			sessionScore = new SessionScore();
			sessionScore.Initialize();
		}
	}

	internal static float GetCurrentScoreBonus()
	{
		if (sessionScore == null)
		{
			return 0f;
		}
		float num = 0f;
		foreach (SessionScore.Score score in sessionScore.scores)
		{
			num += score.bonus;
		}
		foreach (SessionScore.Score score2 in sessionScore.scores)
		{
			num *= score2.bonusMultiplier;
		}
		return num;
	}

	internal static float GetCurrentScoreMultiplier()
	{
		if (sessionScore == null)
		{
			return 1f;
		}
		float num = 1f;
		float num2 = 1f;
		float num3 = 1f;
		foreach (SessionScore.Score score in sessionScore.scores)
		{
			if (score.multiplier > 0f)
			{
				num2 += score.multiplier;
			}
			else
			{
				num3 += score.multiplier;
			}
		}
		num *= num2 * num3;
		foreach (SessionScore.Score score2 in sessionScore.scores)
		{
			num *= score2.stackMultiplier;
		}
		foreach (SessionScore.Score score3 in sessionScore.scores)
		{
			num /= score3.stackDivide;
		}
		return Mathf.Max(num, 0f);
	}
}
