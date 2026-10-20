using DG.Tweening;
using Febucci.UI;
using TMPro;
using UnityEngine;

public class OS_Tooltip_Manager : MonoBehaviour
{
	public TMP_Text tipText;

	public RectTransform tipWindow;

	public Transform defaultTooltipTarget;

	private CanvasGroup tipCanvasGroup;

	public bool isOSTooltip = true;

	public static OS_Tooltip_Manager currentOSTooltip;

	public static OS_Tooltip_Manager currentUITooltip;

	private void Start()
	{
		tipText.text = null;
		tipWindow.gameObject.SetActive(value: false);
		if (isOSTooltip)
		{
			currentOSTooltip = this;
		}
		else
		{
			currentUITooltip = this;
		}
		tipCanvasGroup = tipWindow.GetComponent<CanvasGroup>();
	}

	public void ShowTip(string tip, Vector2 mousePos, bool useDefaultPosition = false)
	{
		tipText.text = tip;
		TextAnimator_TMP component = tipText.GetComponent<TextAnimator_TMP>();
		if (component != null)
		{
			component.SetText(tip);
		}
		tipWindow.sizeDelta = new Vector2((tipText.preferredWidth > 200f) ? 200f : (tipText.preferredWidth + 6f), tipText.preferredHeight + 5f);
		if (!tipWindow.gameObject.activeSelf)
		{
			tipWindow.gameObject.SetActive(value: true);
		}
		DOTween.Kill(tipCanvasGroup);
		tipCanvasGroup.DOFade(1f, 0.25f).SetUpdate(isIndependentUpdate: true);
		Vector3 position = new Vector2(mousePos.x, mousePos.y);
		if (isOSTooltip)
		{
			mousePos = OS_Manager.mousePosition;
		}
		else
		{
			mousePos /= CL_OverlayUIManager.instance.GetScreenScale();
		}
		Vector2 vector = ((!isOSTooltip) ? (new Vector2(Screen.currentResolution.width, Screen.currentResolution.height) / CL_OverlayUIManager.instance.GetScreenScale()) : OS_Manager.activeComputer.GetScreenSize());
		if (useDefaultPosition)
		{
			position = defaultTooltipTarget.position;
			mousePos = defaultTooltipTarget.position;
		}
		if (mousePos.x < tipWindow.sizeDelta.x / 2f)
		{
			position.x += tipWindow.sizeDelta.x / 2f;
		}
		if (mousePos.x > vector.x - tipWindow.sizeDelta.x / 2f)
		{
			position.x -= tipWindow.sizeDelta.x / 2f;
		}
		if (mousePos.y < tipWindow.sizeDelta.y / 2f)
		{
			position.y += tipWindow.sizeDelta.y / 2f;
		}
		if (mousePos.y > vector.y - tipWindow.sizeDelta.y / 2f)
		{
			position.y -= tipWindow.sizeDelta.y / 2f;
		}
		tipWindow.transform.position = position;
	}

	public void HideTip()
	{
		tipText.text = null;
		DOTween.Kill(tipCanvasGroup);
		tipCanvasGroup.DOFade(0f, 0.15f).SetUpdate(isIndependentUpdate: true);
	}
}
