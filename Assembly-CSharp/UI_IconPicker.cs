using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_IconPicker : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
	public Image image;

	public bool activated;

	private bool selected;

	public Action<UI_IconPicker> onSelect;

	public void Initialize(Sprite s, bool active = false)
	{
		activated = active;
		if (image != null)
		{
			image.sprite = s;
		}
		image.transform.localScale = Vector3.one;
		Color color = (activated ? Color.white : new Color(0.45f, 0.45f, 0.45f));
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
			if (selected)
			{
				b *= Color.red;
			}
			image.color = Color.Lerp(image.color, b, Time.unscaledDeltaTime * 15f);
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
		onSelect(this);
		DOTween.Complete(base.transform);
		base.transform.DOPunchScale(Vector3.one * 0.05f, 0.5f, 8);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		selected = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		selected = false;
	}

	public void OnSelect(BaseEventData eventData)
	{
		selected = true;
	}

	public void OnDeselect(BaseEventData eventData)
	{
		selected = false;
	}
}
