using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ScoreScreen : MonoBehaviour
{
	public bool useTipText = true;

	public TMP_Text tipText;

	public bool useDeathText = true;

	public TMP_Text deathText;

	public bool isChallengeScreen;

	public TMP_Text scoreRankText;

	public Image scoreRankImage;

	public TMP_Text timeDifferenceText;

	public UI_LerpOpen mainScorePanel;

	public bool isDeathScreen;

	public UI_LerpOpen youDiedPopup;

	public bool showScoreWindow = true;

	public UI_EndScreenScoreWindow scoringWindow;

	public GameObject scoreInfoButton;

	public bool showSettingsGameObjects = true;

	public List<GameObject> settingsGameObjects;

	public Leaderboard_Panel leaderboardPanel;

	private bool skip;

	private void Update()
	{
		if (InputManager.GetButton("Jump").Down)
		{
			skip = true;
		}
	}

	public void ShowScreen()
	{
		if (scoringWindow != null && !showScoreWindow)
		{
			scoringWindow.gameObject.SetActive(value: false);
		}
		if (settingsGameObjects != null && (!showSettingsGameObjects || !CL_GameManager.GetBaseGamemode().useGamemodeSettings))
		{
			foreach (GameObject settingsGameObject in settingsGameObjects)
			{
				settingsGameObject.SetActive(value: false);
			}
		}
		youDiedPopup.gameObject.SetActive(value: false);
		mainScorePanel.gameObject.SetActive(value: false);
		StartCoroutine(ScreenAnimation());
		IEnumerator ScreenAnimation()
		{
			if (isDeathScreen && !SettingsManager.settings.g_skipDeathPopup)
			{
				youDiedPopup.gameObject.SetActive(value: true);
				youDiedPopup.Show();
				float waitTimer = 4f;
				while (waitTimer >= 0f && !skip)
				{
					yield return null;
					waitTimer -= Time.unscaledDeltaTime;
				}
				youDiedPopup.Hide();
				if (!skip)
				{
					yield return new WaitForSecondsRealtime(0.1f);
				}
			}
			mainScorePanel.Show();
			if (showScoreWindow)
			{
				scoreInfoButton.SetActive(value: true);
				if (!SettingsManager.settings.g_skipScoreScreen)
				{
					mainScorePanel.GetComponent<CanvasGroup>().interactable = false;
					yield return new WaitForSecondsRealtime(0.7f);
					OpenScoreInfoPanel();
					scoringWindow.StartAnimation();
				}
				else
				{
					scoringWindow.StartAnimation();
					scoringWindow.SkipAnimation();
				}
			}
			else
			{
				scoreInfoButton.SetActive(value: false);
			}
			if (isChallengeScreen)
			{
				PlayMedalAnimation();
			}
			yield return new WaitForSecondsRealtime(3f);
			leaderboardPanel.Refresh();
		}
	}

	public void SetTip(string tip)
	{
		if (useTipText && tipText != null)
		{
			tipText.text = tip;
		}
	}

	public void SetDeathText(string text)
	{
		if (useDeathText && deathText != null)
		{
			deathText.text = text;
		}
	}

	public void SetMedalInfo(string medalTitle, Sprite medalImage, Color textColor)
	{
		scoreRankImage.sprite = medalImage;
		scoreRankText.text = medalTitle;
		scoreRankText.color = textColor;
	}

	public void OpenScoreInfoPanel()
	{
		scoringWindow.GetComponent<UI_LerpOpen>().Show();
		mainScorePanel.GetComponent<CanvasGroup>().interactable = false;
	}

	public void CloseScoreInfoPanel()
	{
		mainScorePanel.GetComponent<CanvasGroup>().interactable = true;
		scoringWindow.GetComponent<UI_LerpOpen>().Hide();
		CL_ProgressionManager.instance?.deathList?.Check();
	}

	public void PlayMedalAnimation()
	{
		StartCoroutine(MedalAnimator());
		IEnumerator MedalAnimator()
		{
			Color textColor = scoreRankText.color;
			scoreRankImage.transform.localScale = Vector3.one * 1.8f;
			scoreRankImage.color = Color.clear;
			scoreRankText.color = Color.clear;
			yield return new WaitForSecondsRealtime(0.5f);
			scoreRankImage.DOColor(Color.white, 0.5f).SetUpdate(isIndependentUpdate: true);
			yield return scoreRankImage.transform.DOPunchScale(Vector3.one * 0.3f, 0.3f, 5, 0.5f).SetUpdate(isIndependentUpdate: true).WaitForCompletion();
			yield return scoreRankImage.transform.DOScale(1f, 0.35f).SetUpdate(isIndependentUpdate: true).SetEase(Ease.InCirc)
				.WaitForCompletion();
			scoreRankImage.transform.DOPunchRotation(Vector3.one * 3f, 0.5f).SetUpdate(isIndependentUpdate: true);
			yield return scoreRankImage.transform.DOPunchScale(Vector3.one * 0.2f, 0.5f, 5, 0.5f).SetUpdate(isIndependentUpdate: true).WaitForCompletion();
			scoreRankText.DOColor(textColor, 0.5f).SetUpdate(isIndependentUpdate: true);
		}
	}

	public void Skip()
	{
		skip = true;
	}

	public void PlayTimeReductionAnimation(float timeReduction)
	{
		if (!(timeDifferenceText == null))
		{
			StartCoroutine(TimeAnimator());
		}
		IEnumerator TimeAnimator()
		{
			Color textColor = Color.green;
			timeDifferenceText.gameObject.SetActive(value: true);
			timeDifferenceText.transform.localScale = Vector3.one * 1.8f;
			timeDifferenceText.text = "-" + DarkMachineFunctions.SecondsToTimeString(timeReduction, "mm\\:ss\\:ff");
			yield return new WaitForSecondsRealtime(0.5f);
			timeDifferenceText.DOColor(Color.white, 0.5f).SetUpdate(isIndependentUpdate: true);
			yield return timeDifferenceText.transform.DOPunchScale(Vector3.one * 0.3f, 0.3f, 5, 0.5f).SetUpdate(isIndependentUpdate: true).WaitForCompletion();
			yield return timeDifferenceText.transform.DOScale(1f, 0.35f).SetUpdate(isIndependentUpdate: true).SetEase(Ease.InCirc)
				.WaitForCompletion();
			timeDifferenceText.transform.DOPunchRotation(Vector3.one * 3f, 0.5f).SetUpdate(isIndependentUpdate: true);
			yield return timeDifferenceText.transform.DOPunchScale(Vector3.one * 0.2f, 0.5f, 5, 0.5f).SetUpdate(isIndependentUpdate: true).WaitForCompletion();
			yield return timeDifferenceText.DOColor(textColor, 0.5f).SetUpdate(isIndependentUpdate: true);
		}
	}
}
