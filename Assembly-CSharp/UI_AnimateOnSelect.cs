using System.Collections.Generic;
using System.Globalization;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_AnimateOnSelect : MonoBehaviour, ISelectHandler, IEventSystemHandler, IPointerClickHandler, ISubmitHandler
{
	public bool animateOnSubmit;

	public List<string> selectAnimations;

	private Vector3 startScale;

	private Selectable selectable;

	private void Awake()
	{
		startScale = base.transform.localScale;
		selectable = GetComponent<Selectable>();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if ((!selectable || selectable.IsInteractable()) && animateOnSubmit)
		{
			Animate();
		}
	}

	public void OnSelect(BaseEventData eventData)
	{
		if ((!selectable || selectable.IsInteractable()) && !animateOnSubmit)
		{
			Animate();
		}
	}

	public void OnSubmit(BaseEventData eventData)
	{
		if ((!selectable || selectable.IsInteractable()) && animateOnSubmit)
		{
			Animate();
		}
	}

	private void OnDisable()
	{
		DOTween.Complete(base.transform);
	}

	private void Animate()
	{
		base.transform.DOComplete();
		foreach (string selectAnimation in selectAnimations)
		{
			string[] array = selectAnimation.Split(':');
			switch (array[0])
			{
			case "punch-position":
				base.transform.DOPunchPosition(Vector3.one * float.Parse(array[1], NumberStyles.Float, CultureInfo.InvariantCulture), float.Parse(array[2], NumberStyles.Float, CultureInfo.InvariantCulture)).SetUpdate(isIndependentUpdate: true);
				break;
			case "punch-scale":
				base.transform.localScale = startScale;
				base.transform.DOPunchScale(Vector3.one * float.Parse(array[1], NumberStyles.Float, CultureInfo.InvariantCulture), float.Parse(array[2], NumberStyles.Float, CultureInfo.InvariantCulture)).SetUpdate(isIndependentUpdate: true);
				break;
			case "punch-rotation":
				base.transform.DOPunchRotation(Vector3.one * float.Parse(array[1], NumberStyles.Float, CultureInfo.InvariantCulture), float.Parse(array[2], NumberStyles.Float, CultureInfo.InvariantCulture)).SetUpdate(isIndependentUpdate: true);
				break;
			}
		}
	}
}
