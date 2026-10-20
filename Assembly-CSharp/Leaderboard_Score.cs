using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard_Score : MonoBehaviour
{
	public string username;

	public LeaderboardEntry scoreInfo;

	public RawImage profile;

	public TMP_Text nameText;

	public TMP_Text positionText;

	public TMP_Text scoreText;

	public Image ikIcon;

	public Image hmIcon;

	public Image otherIcon;

	public Action<LeaderboardEntry> OnSelect;

	public void Select()
	{
		OnSelect?.Invoke(scoreInfo);
	}

	public void SetNameText(string name)
	{
		nameText.text = name.Replace("<size", "imadingus");
	}
}
