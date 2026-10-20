using System;
using System.Collections;
using DG.Tweening;
using Drawing;
using TMPro;
using UnityEngine;

public class UI_RoachBankPopup : MonoBehaviourGizmos
{
	public TMP_Text roachText;

	public TMP_Text creditText;

	public bool animateOnPopup = true;

	public Vector2 hidePositionOffset;

	private Vector2 rootPositon = Vector2.zero;

	public float openSpeed = 1f;

	public float holdTime = 2f;

	private bool showingAnimation;

	private RectTransform rectTransform;

	private static Action<int, int, int, int> adjustRoaches;

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		rootPositon = rectTransform.anchoredPosition;
		if (animateOnPopup)
		{
			rectTransform.anchoredPosition = rootPositon + hidePositionOffset;
		}
	}

	private void OnEnable()
	{
		adjustRoaches = (Action<int, int, int, int>)Delegate.Combine(adjustRoaches, new Action<int, int, int, int>(Popup));
	}

	private void OnDisable()
	{
		adjustRoaches = (Action<int, int, int, int>)Delegate.Remove(adjustRoaches, new Action<int, int, int, int>(Popup));
	}

	public static void ShowRoachChangePopup(int roaches, int credits)
	{
		if (adjustRoaches != null)
		{
			adjustRoaches(roaches, credits, CL_GameManager.GetRoaches(), CL_GameManager.GetRoaches(global: true));
		}
	}

	public static void ShowRoachChangePopup(int roaches, int credits, int roachStart = 0, int creditStart = 0)
	{
		if (adjustRoaches != null)
		{
			adjustRoaches(roaches, credits, roachStart, creditStart);
		}
	}

	public void Popup(int roaches, int credits, int roachStart = 0, int creditStart = 0)
	{
		StartCoroutine(PopupAnimation(roaches, credits, roachStart, creditStart));
	}

	private IEnumerator PopupAnimation(int roaches, int credits, int roachStart = 0, int creditStart = 0)
	{
		if (showingAnimation)
		{
			while (showingAnimation)
			{
				yield return null;
			}
		}
		int curRoaches = roachStart;
		int curCredits = creditStart;
		showingAnimation = true;
		rectTransform.DOAnchorPos(rootPositon, openSpeed).SetUpdate(isIndependentUpdate: true);
		roachText.text = curRoaches.ToString();
		creditText.text = curCredits.ToString();
		yield return new WaitForSecondsRealtime(openSpeed);
		base.transform.DOPunchScale(Vector3.one * 0.05f, 0.5f, 3, 1.2f);
		float num = 0f;
		float elapsed = 0f;
		float automaticOneRemove = 0.05f;
		float cubicFactor = 2f;
		float punchInterval = 0.35f;
		float intervalsUntilMaxScale = 10f;
		float scaleMultAdd = 1.4f;
		float scaleMultSub = 0.2f;
		while (Mathf.Max(Mathf.Abs(roaches), Mathf.Abs(credits)) > 0)
		{
			int value = (int)(elapsed * elapsed * elapsed * cubicFactor);
			int max = Mathf.Max(Mathf.Abs(roaches), Mathf.Abs(credits));
			int min = (int)(elapsed / automaticOneRemove) - (int)(num / automaticOneRemove);
			int num2 = Mathf.Clamp(value, min, max);
			float num3 = 1f - elapsed % punchInterval / punchInterval;
			num3 *= num3 * num3;
			num3 *= Mathf.Min((int)(elapsed / punchInterval) + 1, intervalsUntilMaxScale) / intervalsUntilMaxScale;
			float num4 = 1f + num3 * scaleMultAdd;
			float num5 = 1f - num3 * scaleMultSub;
			float num6 = 1f;
			if (roaches > 0)
			{
				roaches -= num2;
				curRoaches += num2;
				num6 = num4;
			}
			else if (roaches < 0)
			{
				roaches += num2;
				curRoaches -= num2;
				num6 = num5;
			}
			float num7 = 1f;
			if (credits > 0)
			{
				credits -= num2;
				curCredits += num2;
				num7 = num4;
			}
			else if (credits < 0)
			{
				credits += num2;
				curCredits -= num2;
				num7 = num5;
			}
			roachText.text = curRoaches.ToString();
			creditText.text = curCredits.ToString();
			roachText.transform.localScale = Vector3.one * num6;
			creditText.transform.localScale = Vector3.one * num7;
			yield return null;
			num = elapsed;
			elapsed += Time.unscaledDeltaTime;
		}
		roachText.transform.DOScale(1f, holdTime * 0.25f);
		creditText.transform.DOScale(1f, holdTime * 0.25f);
		yield return new WaitForSecondsRealtime(holdTime);
		rectTransform.DOAnchorPos(rootPositon + hidePositionOffset, openSpeed).SetUpdate(isIndependentUpdate: true).SetEase(Ease.InOutSine);
		yield return new WaitForSecondsRealtime(openSpeed);
		showingAnimation = false;
	}

	public override void DrawGizmos()
	{
		if (GizmoContext.InSelection(this))
		{
			if (rectTransform == null)
			{
				rectTransform = GetComponent<RectTransform>();
			}
			Draw.Cross(rectTransform.position + (Vector3)hidePositionOffset, 20f, new Color(1f, 0.561f, 0f, 0.25f));
		}
	}
}
