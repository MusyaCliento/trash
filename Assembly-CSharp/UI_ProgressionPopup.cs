using System.Collections;
using DG.Tweening;
using Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ProgressionPopup : MonoBehaviourGizmos
{
	public Image icon;

	public Image glow;

	public TMP_Text text;

	public bool animateOnPopup = true;

	public Vector2 hidePositionOffset;

	private Vector2 rootPositon = Vector2.zero;

	public float openSpeed = 1f;

	public float holdTime = 2f;

	private bool showingAnimation;

	private RectTransform rectTransform;

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		rootPositon = rectTransform.anchoredPosition;
		if (animateOnPopup)
		{
			rectTransform.anchoredPosition = rootPositon + hidePositionOffset;
		}
	}

	public void Popup(Sprite i, string title, string desc, Color glowColor, AudioClip clip = null)
	{
		StartCoroutine(PopupAnimation(i, title, desc, glowColor, clip));
	}

	private IEnumerator PopupAnimation(Sprite i, string title, string desc, Color glowColor, AudioClip clip = null)
	{
		if (showingAnimation)
		{
			while (showingAnimation)
			{
				yield return null;
			}
		}
		UpdateInformation(i, title, desc);
		showingAnimation = true;
		rectTransform.DOAnchorPos(rootPositon, openSpeed).SetUpdate(isIndependentUpdate: true);
		glow.color = Color.clear;
		glow.DOColor(glowColor, 1.5f).SetUpdate(isIndependentUpdate: true);
		if (clip != null)
		{
			AudioManager.PlayUISound(clip, 0.75f);
		}
		yield return new WaitForSecondsRealtime(openSpeed);
		base.transform.DOPunchScale(Vector3.one * 0.05f, 0.5f, 3, 1.2f);
		yield return new WaitForSecondsRealtime(holdTime);
		rectTransform.DOAnchorPos(rootPositon + hidePositionOffset, openSpeed).SetUpdate(isIndependentUpdate: true);
		glow.DOColor(Color.clear, 0.5f).SetUpdate(isIndependentUpdate: true);
		yield return new WaitForSecondsRealtime(openSpeed);
		showingAnimation = false;
	}

	public void UpdateInformation(Sprite i, string title, string desc)
	{
		icon.sprite = i;
		text.text = "<size=20>" + title.ToUpper() + "</size>\n<color=grey>" + desc + "</color>";
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
