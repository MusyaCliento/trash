using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_EndScreenScoreWindow_ScoreItem : MonoBehaviour
{
	public TMP_Text titleText;

	public TMP_Text bonusText;

	public TMP_Text multiplierText;

	public Color negativeColor = Color.red;

	public void Initialize(string title, float bonus, float multiplier, int count)
	{
		titleText.text = title;
		if (count != 0)
		{
			titleText.text = $"{title} <color=grey>({count})";
		}
		if (bonus > 0f)
		{
			bonusText.text = "+" + Mathf.Round(bonus);
		}
		else
		{
			bonusText.text = Mathf.Round(bonus).ToString();
		}
		multiplierText.text = Math.Round(multiplier + 1f, 2) + "X";
		if (multiplier == 0f)
		{
			multiplierText.text = "";
		}
		if (bonus == 0f)
		{
			bonusText.text = "";
		}
		if (bonus < 0f || multiplier < 0f)
		{
			GetComponent<Image>().color = negativeColor;
			bonusText.color = Color.red;
			multiplierText.color = Color.red;
		}
		if (bonus == 0f)
		{
			bonusText.gameObject.SetActive(value: false);
		}
		if (multiplier == 0f)
		{
			multiplierText.gameObject.SetActive(value: false);
		}
	}
}
