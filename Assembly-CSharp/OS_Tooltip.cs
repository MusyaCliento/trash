using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class OS_Tooltip : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
	[TextArea]
	public string tip;

	public float timeToWait = 0.5f;

	private bool isShowing;

	public Vector2 offset;

	public bool isOSTooltip = true;

	public bool showAtDefaultTooltipTarget;

	public Transform customTooltipTargetTransform;

	private void OnDisable()
	{
		if (isShowing)
		{
			StopAllCoroutines();
			HideTooltip();
		}
	}

	private void ShowMessage()
	{
		if (isOSTooltip && OS_Tooltip_Manager.currentOSTooltip != null)
		{
			ShowTooltip(OS_Manager.mouseRealPosition);
		}
		else if (!isOSTooltip && OS_Tooltip_Manager.currentUITooltip != null)
		{
			ShowTooltip(Input.mousePosition);
		}
	}

	private IEnumerator StartTimer()
	{
		yield return new WaitForSecondsRealtime(timeToWait);
		ShowMessage();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		StopAllCoroutines();
		StartCoroutine(StartTimer());
		isShowing = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		StopAllCoroutines();
		HideTooltip();
		isShowing = false;
	}

	public void OnDeselect(BaseEventData eventData)
	{
		if (!isOSTooltip && isShowing)
		{
			StopAllCoroutines();
			HideTooltip();
			isShowing = false;
		}
	}

	public void OnSelect(BaseEventData eventData)
	{
		if (!isOSTooltip && !isShowing && OS_Tooltip_Manager.currentUITooltip != null)
		{
			StopAllCoroutines();
			StartCoroutine(StartOnSelectTimer());
			isShowing = true;
		}
		IEnumerator StartOnSelectTimer()
		{
			yield return new WaitForSecondsRealtime(timeToWait);
			ShowTooltip(base.transform.position);
		}
	}

	private void ShowTooltip(Vector2 position)
	{
		if (customTooltipTargetTransform != null)
		{
			position = customTooltipTargetTransform.position;
		}
		if (isOSTooltip && OS_Tooltip_Manager.currentOSTooltip != null)
		{
			OS_Tooltip_Manager.currentOSTooltip.ShowTip(tip, position + offset, showAtDefaultTooltipTarget);
		}
		else if (!isOSTooltip && OS_Tooltip_Manager.currentUITooltip != null)
		{
			OS_Tooltip_Manager.currentUITooltip.ShowTip(tip, position + offset, showAtDefaultTooltipTarget);
		}
	}

	private void HideTooltip()
	{
		if (isOSTooltip && OS_Tooltip_Manager.currentOSTooltip != null)
		{
			OS_Tooltip_Manager.currentOSTooltip.HideTip();
		}
		else if (!isOSTooltip && OS_Tooltip_Manager.currentUITooltip != null)
		{
			OS_Tooltip_Manager.currentUITooltip.HideTip();
		}
	}
}
