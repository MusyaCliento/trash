using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_CapsuleButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
	public float showDelayAnimation;

	private Selectable button;

	public string unlockAchievement;

	public Image unlockIcon;

	private CanvasGroup group;

	private void Start()
	{
		button = GetComponent<Selectable>();
		group = GetComponent<CanvasGroup>();
	}

	private void Update()
	{
		CheckAchievement();
	}

	private void CheckAchievement()
	{
		if (unlockAchievement != "")
		{
			bool achievementValue = CL_AchievementManager.GetAchievementValue(unlockAchievement);
			if (unlockIcon != null)
			{
				unlockIcon.gameObject.SetActive(!achievementValue);
			}
			if (group != null)
			{
				group.interactable = achievementValue;
				group.alpha = (achievementValue ? 1f : 0.5f);
			}
			button.interactable = achievementValue;
		}
		else
		{
			if (unlockIcon != null)
			{
				unlockIcon.gameObject.SetActive(value: false);
			}
			if (group != null)
			{
				group.interactable = true;
				group.alpha = 1f;
			}
			button.interactable = true;
		}
	}

	public void Show()
	{
		if (!(button == null) && button.gameObject.activeInHierarchy)
		{
			StartCoroutine(ShowAnimation());
		}
	}

	public IEnumerator ShowAnimation()
	{
		yield return new WaitForSeconds(showDelayAnimation);
		base.transform.DOPunchScale(Vector3.one * 0.04f, 0.5f, 5, 0.5f);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!(button == null) && button.interactable)
		{
			base.transform.DOPunchScale(Vector3.one * 0.04f, 0.25f, 5, 0.5f);
			base.transform.DOScale(1.05f, 0.25f);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (!(button == null) && button.interactable)
		{
			base.transform.DOScale(1f, 0.25f);
		}
	}

	public void OnSelect(BaseEventData data)
	{
		if (!(button == null) && button.interactable)
		{
			base.transform.DOPunchScale(Vector3.one * 0.04f, 0.25f, 5, 0.5f);
			base.transform.DOScale(1.05f, 0.25f);
		}
	}

	public void OnDeselect(BaseEventData data)
	{
		if (!(button != null) || button.interactable)
		{
			base.transform.DOScale(1f, 0.25f);
		}
	}
}
