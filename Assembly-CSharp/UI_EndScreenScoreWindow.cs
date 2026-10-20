using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Febucci.UI;
using Febucci.UI.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_EndScreenScoreWindow : MonoBehaviour
{
	[Serializable]
	public class FinishSound
	{
		public float minimumScore;

		public AudioClip clip;

		public string scoreTitlePrefix;

		public string scoreTitleSuffix;
	}

	public TMP_Text totalScoreText;

	public TMP_Text baseScoreText;

	public TMP_Text distanceScoreText;

	public TMP_Text speedScoreText;

	public TMP_Text modifierTitleText;

	public TMP_Text highScoreText;

	public TMP_Text deathScoreText;

	public Image deathBloodSplatterSprite;

	public UI_EndScreenScoreWindow_ScoreItem scoreItemAsset;

	public Transform scoreItemRoot;

	private List<UI_EndScreenScoreWindow_ScoreItem> scoreItems = new List<UI_EndScreenScoreWindow_ScoreItem>();

	public AudioClip startSound;

	public AudioClip deathSound;

	private Color titleColor;

	public List<FinishSound> finishSounds;

	public FinishSound personalBestFinishSound;

	public List<AudioClip> scoreTickSounds;

	public AudioSource tickSound;

	public Image scoreTitle;

	public TextAnimator_TMP loadingTextAnimator;

	private string loadingText;

	public float heightBase = 600f;

	public float heightDeathHeightAdd = 25f;

	private bool skip;

	private void Start()
	{
		loadingText = loadingTextAnimator.GetOriginalTextFromSource();
		loadingTextAnimator.SetText("");
		titleColor = scoreTitle.color;
		highScoreText.gameObject.SetActive(value: false);
		foreach (Transform item in scoreItemRoot)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
	}

	public void StartAnimation()
	{
		foreach (Transform item in scoreItemRoot)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
		StartCoroutine(AnimateEndScreen());
	}

	public void SkipAnimation()
	{
		skip = true;
	}

	private IEnumerator AnimateEndScreen()
	{
		totalScoreText.text = "FINAL: 0";
		baseScoreText.text = "";
		deathScoreText.text = "";
		RectTransform rectTransform = GetComponent<RectTransform>();
		rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, heightBase);
		Color bloodColor = deathBloodSplatterSprite.color;
		deathBloodSplatterSprite.color = Color.clear;
		Vector3 bloodScale = deathBloodSplatterSprite.transform.localScale;
		float currentScore = Mathf.Round(CL_GameManager.gMan.GetPlayerBestTravelDistance() * CL_GameManager.gMan.GetPlayerTravelSpeed());
		modifierTitleText.gameObject.SetActive(value: false);
		distanceScoreText.text = "";
		speedScoreText.text = "";
		scoreTitle.color = Color.clear;
		loadingTextAnimator.TMProComponent.color = Color.clear;
		if (!skip)
		{
			yield return new WaitForSecondsRealtime(0.5f);
		}
		if (!skip)
		{
			AudioManager.PlayUISound(startSound, 0.7f);
		}
		scoreTitle.transform.DOPunchScale(Vector3.one * -0.05f, 0.5f).SetUpdate(isIndependentUpdate: true);
		scoreTitle.transform.DOPunchRotation(Vector3.forward * 5f, 0.5f, 16).SetUpdate(isIndependentUpdate: true);
		scoreTitle.DOColor(titleColor, 0.5f).SetUpdate(isIndependentUpdate: true);
		loadingTextAnimator.SetText(loadingText);
		loadingTextAnimator.TMProComponent.color = titleColor;
		loadingTextAnimator.GetComponent<TypewriterCore>().StartShowingText(restart: true);
		if (!skip)
		{
			yield return new WaitForSecondsRealtime(0.8f);
		}
		loadingTextAnimator.GetComponent<TypewriterCore>().StartDisappearingText();
		string baseDistanceScoreString = "DISTANCE: .............................";
		string baseSpeedScoreString = "SPEED: ..........................";
		baseScoreText.text = "SCORE: 0";
		distanceScoreText.text = baseDistanceScoreString;
		speedScoreText.text = baseSpeedScoreString;
		if (currentScore > 10f)
		{
			PlayTickSound();
			if (!skip)
			{
				yield return new WaitForSecondsRealtime(0.5f);
			}
			float scoreTickTime = 0f;
			tickSound.Play();
			while (scoreTickTime < 1f)
			{
				scoreTickTime += Time.unscaledDeltaTime;
				float f = Mathf.Lerp(0f, currentScore, scoreTickTime);
				totalScoreText.GetComponent<TextAnimator_TMP>().SetText("FINAL: " + Mathf.Round(f));
				baseScoreText.text = $"SCORE: {Mathf.Round(f)}";
				string text = Mathf.RoundToInt(Mathf.Lerp(0f, CL_GameManager.gMan.GetPlayerBestTravelDistance(), scoreTickTime)) + "M";
				string text2 = baseDistanceScoreString.Remove(baseDistanceScoreString.Length - text.Length, text.Length);
				text2 += text;
				distanceScoreText.text = text2;
				string text3 = Math.Round(Mathf.Lerp(0f, CL_GameManager.gMan.GetPlayerTravelSpeed(), scoreTickTime), 2) + "m/s";
				string text4 = baseSpeedScoreString.Remove(baseSpeedScoreString.Length - text3.Length, text3.Length);
				text4 += text3;
				speedScoreText.text = text4;
				if (!skip)
				{
					yield return null;
				}
			}
			tickSound.Stop();
		}
		DOTween.Complete(totalScoreText.transform);
		totalScoreText.transform.DOPunchScale(Vector3.one * 0.02f, 0.5f).SetUpdate(isIndependentUpdate: true);
		totalScoreText.text = "FINAL: " + Mathf.Round(currentScore);
		PlayTickSound();
		baseScoreText.text = $"<color=grey>SCORE: {Mathf.Round(currentScore)}";
		baseScoreText.transform.DOPunchScale(Vector3.one * 0.02f, 0.5f).SetUpdate(isIndependentUpdate: true);
		if (!skip)
		{
			yield return new WaitForSecondsRealtime(0.5f);
		}
		modifierTitleText.gameObject.SetActive(value: true);
		float totalMultiplier = 1f;
		float totalBonus = 0f;
		float reviveLoss = 1f;
		int revives = StatManager.GetStatisticInt(StatManager.sessionStats, "revives");
		if (CL_ScoreManager.sessionScore.scores.Count > 0)
		{
			foreach (CL_ScoreManager.SessionScore.Score score in CL_ScoreManager.sessionScore.scores)
			{
				if (score.id == "reviveloss")
				{
					reviveLoss = score.bonusMultiplier;
					continue;
				}
				PlayTickSound();
				if (!skip)
				{
					yield return new WaitForSecondsRealtime(0.08f);
				}
				UI_EndScreenScoreWindow_ScoreItem uI_EndScreenScoreWindow_ScoreItem = UnityEngine.Object.Instantiate(scoreItemAsset, scoreItemRoot);
				uI_EndScreenScoreWindow_ScoreItem.Initialize(score.title, score.bonus, score.multiplier, score.count);
				uI_EndScreenScoreWindow_ScoreItem.transform.DOPunchScale(Vector3.one * 0.05f, 0.5f).SetUpdate(isIndependentUpdate: true);
				totalMultiplier += score.multiplier;
				totalBonus += score.bonus;
				if (!skip)
				{
					yield return new WaitForSecondsRealtime(0.08f);
				}
				totalScoreText.text = "FINAL: " + Mathf.Round((currentScore + totalBonus) * totalMultiplier);
				DOTween.Complete(totalScoreText.transform);
			}
		}
		if (!skip)
		{
			yield return new WaitForSecondsRealtime(0.08f);
		}
		if (reviveLoss < 1f)
		{
			Color color = deathScoreText.color;
			if (revives > 1)
			{
				deathScoreText.text = $"{revives} REVIVES   1/{revives + 1} BONUS";
			}
			else
			{
				deathScoreText.text = $"{revives} REVIVE   1/{revives + 1} BONUS";
			}
			deathScoreText.color = Color.clear;
			deathScoreText.DOColor(color, 0.25f).SetUpdate(isIndependentUpdate: true).SetLoops(3, LoopType.Yoyo);
			deathScoreText.transform.DOPunchScale(Vector3.one * 0.2f, 0.8f).SetUpdate(isIndependentUpdate: true);
			if (CL_ScoreManager.sessionScore.scores.Count > 8)
			{
				rectTransform.DOSizeDelta(rectTransform.sizeDelta + new Vector2(0f, heightDeathHeightAdd), 0.25f).SetEase(Ease.InOutSine).SetUpdate(isIndependentUpdate: true);
			}
			totalScoreText.text = "FINAL: " + Mathf.Round((currentScore + totalBonus * reviveLoss) * totalMultiplier);
			if (!skip)
			{
				AudioManager.PlayUISound(deathSound, 0.7f);
			}
			deathBloodSplatterSprite.DOColor(bloodColor, 0.25f).SetUpdate(isIndependentUpdate: true);
			deathBloodSplatterSprite.transform.localScale = bloodScale * 0.9f;
			deathBloodSplatterSprite.transform.DOScale(bloodScale, 0.5f).SetUpdate(isIndependentUpdate: true);
			if (!skip)
			{
				yield return new WaitForSecondsRealtime(0.5f);
			}
		}
		totalScoreText.transform.DOPunchScale(Vector3.one * 0.2f, 0.8f).SetUpdate(isIndependentUpdate: true);
		totalScoreText.DOColor(Color.white, 0.5f).SetLoops(2, LoopType.Yoyo).SetUpdate(isIndependentUpdate: true);
		FinishSound finishSound = finishSounds[0];
		if (M_Gamemode.IsCurrentlyAHighScore())
		{
			finishSound = personalBestFinishSound;
		}
		else
		{
			for (int num = finishSounds.Count - 1; num >= 0; num--)
			{
				if (CL_GameManager.GetCurrentGamemode().GetPlayerScore() > finishSounds[num].minimumScore)
				{
					finishSound = finishSounds[num];
					break;
				}
			}
		}
		if (!skip)
		{
			AudioManager.PlayUISound(finishSound.clip, 0.7f);
		}
		if (!skip)
		{
			base.transform.DOPunchRotation(Vector3.forward * 0.5f, 0.5f).SetUpdate(isIndependentUpdate: true);
		}
		totalScoreText.text = finishSound.scoreTitlePrefix + "FINAL: " + CL_GameManager.GetCurrentGamemode().GetPlayerScore() + finishSound.scoreTitleSuffix;
		if (!skip)
		{
			yield return new WaitForSecondsRealtime(0.5f);
		}
		if (M_Gamemode.IsCurrentlyAHighScore())
		{
			highScoreText.gameObject.SetActive(value: true);
			highScoreText.transform.DOPunchScale(Vector3.one * 0.1f, 0.5f);
		}
		if (!skip)
		{
			yield return new WaitForSecondsRealtime(3.5f);
		}
		CL_ProgressionManager.instance?.deathList?.Check();
	}

	private void PlayTickSound()
	{
		if (!skip)
		{
			AudioManager.PlayUISound(scoreTickSounds[UnityEngine.Random.Range(0, scoreTickSounds.Count)], 0.7f, UnityEngine.Random.Range(0.9f, 1.1f));
		}
	}
}
