using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_TrinketPicker_Icon : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
	public Trinket trinket;

	public Image image;

	private UI_TrinketPicker parentPicker;

	public bool activated;

	private bool selected;

	public Image lockImage;

	private bool isLocked;

	public void SetTrinket(Trinket t, UI_TrinketPicker picker = null)
	{
		trinket = t;
		parentPicker = picker;
		if (trinket.IsUnlocked() && !trinket.comingSoon)
		{
			isLocked = false;
			lockImage.gameObject.SetActive(value: false);
			lockImage.color = Color.clear;
		}
		else
		{
			isLocked = true;
			lockImage.gameObject.SetActive(value: false);
			lockImage.color = Color.clear;
		}
		if (image != null)
		{
			image.sprite = (isLocked ? trinket.lockIcon : trinket.icon);
			if (trinket.comingSoon)
			{
				image.sprite = trinket.icon;
			}
		}
		image.transform.localScale = Vector3.one;
		Color color = (activated ? Color.white : new Color(0.45f, 0.45f, 0.45f));
		if (isLocked)
		{
			color = Color.grey;
		}
		image.color = color;
		Deactivate();
		GetComponent<Button>().onClick.AddListener(OnClick);
	}

	private void Update()
	{
		if (image != null)
		{
			if (activated)
			{
				image.transform.localScale = Vector3.Lerp(image.transform.localScale, Vector3.one * 1.1f, Time.unscaledDeltaTime * 15f);
			}
			else
			{
				image.transform.localScale = Vector3.Lerp(image.transform.localScale, Vector3.one, Time.unscaledDeltaTime * 15f);
			}
			if (selected)
			{
				image.transform.localPosition = Vector3.Lerp(image.transform.localPosition, Vector3.up * 3f, Time.unscaledDeltaTime * 15f);
			}
			else
			{
				image.transform.localPosition = Vector3.Lerp(image.transform.localPosition, Vector3.zero, Time.unscaledDeltaTime * 15f);
			}
			Color b = (activated ? Color.white : new Color(0.45f, 0.45f, 0.45f));
			if (isLocked)
			{
				b = Color.grey;
			}
			if (selected)
			{
				b *= Color.red;
			}
			image.color = Color.Lerp(image.color, b, Time.unscaledDeltaTime * 15f);
			if (isLocked)
			{
				lockImage.color = Color.Lerp(lockImage.color, selected ? new Color(1f, 0.5f, 0.5f, 1f) : Color.clear, Time.unscaledDeltaTime * 15f);
			}
		}
	}

	public void Activate()
	{
		activated = true;
	}

	public void Deactivate()
	{
		activated = false;
	}

	public void OnClick()
	{
		if (!isLocked)
		{
			Debug.Log(trinket.description);
			parentPicker.SelectTrinket(trinket);
			DOTween.Complete(base.transform);
			base.transform.DOPunchScale(Vector3.one * 0.05f, 0.5f, 8);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (isLocked)
		{
			parentPicker.ShowDescription(trinket.GetLockedDescription());
		}
		else
		{
			parentPicker.ShowTrinketDescription(trinket);
		}
		selected = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		selected = false;
		parentPicker.HideDescription();
	}

	public void OnSelect(BaseEventData eventData)
	{
		if (isLocked || trinket.comingSoon)
		{
			parentPicker.ShowDescription(trinket.GetLockedDescription());
		}
		else
		{
			parentPicker.ShowTrinketDescription(trinket);
		}
		selected = true;
	}

	public void OnDeselect(BaseEventData eventData)
	{
		selected = false;
		parentPicker.HideDescription();
	}
}
