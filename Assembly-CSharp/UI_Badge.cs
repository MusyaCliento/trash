using System.Collections;
using DG.Tweening;
using Febucci.UI.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Badge : MonoBehaviour
{
	public Image badgeSprite;

	public TypewriterCore badgeTypewriter;

	public TMP_Text badgeText;

	public static UI_Badge instance;

	private void Start()
	{
		instance = this;
		base.gameObject.SetActive(value: false);
	}

	public void ShowBadge(Sprite sprite, string title, float delay = 0.5f)
	{
		base.gameObject.SetActive(value: true);
		instance.badgeSprite.sprite = sprite;
		badgeText.text = title;
		StartCoroutine(BadgeAnimator());
		IEnumerator BadgeAnimator()
		{
			badgeSprite.transform.localScale = Vector3.one * 1.8f;
			badgeSprite.color = Color.clear;
			badgeText.color = Color.clear;
			yield return new WaitForSecondsRealtime(delay);
			badgeSprite.DOColor(Color.white, 0.5f).SetUpdate(isIndependentUpdate: true);
			yield return badgeSprite.transform.DOPunchScale(Vector3.one * 0.3f, 0.3f, 5, 0.5f).SetUpdate(isIndependentUpdate: true).WaitForCompletion();
			yield return badgeSprite.transform.DOScale(1f, 0.35f).SetUpdate(isIndependentUpdate: true).SetEase(Ease.InCirc)
				.WaitForCompletion();
			badgeSprite.transform.DOPunchRotation(Vector3.one * 3f, 0.5f).SetUpdate(isIndependentUpdate: true);
			yield return badgeSprite.transform.DOPunchScale(Vector3.one * 0.2f, 0.5f, 5, 0.5f).SetUpdate(isIndependentUpdate: true).WaitForCompletion();
			badgeText.DOColor(Color.white, 0.5f).SetUpdate(isIndependentUpdate: true);
			yield return new WaitForSeconds(3f);
			badgeSprite.DOColor(Color.clear, 0.5f).SetUpdate(isIndependentUpdate: true);
			badgeText.DOColor(Color.clear, 0.5f).SetUpdate(isIndependentUpdate: true);
		}
	}

	public static void GetBadge(Sprite sprite, string title, float delay = 0.5f)
	{
		instance.ShowBadge(sprite, title, delay);
	}
}
