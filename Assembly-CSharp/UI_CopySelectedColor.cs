using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_CopySelectedColor : MonoBehaviour
{
	public Selectable selectable;

	private MaskableGraphic thisGraphic;

	public Color selectedColor;

	public Color normalColor;

	public bool useDisableColor;

	public Color disabledColor;

	public bool affectAlpha;

	private bool isDisabled;

	private UI_SelectEventTrigger selectableEvents;

	private void Start()
	{
		thisGraphic = GetComponent<MaskableGraphic>();
		selectableEvents = selectable.GetComponent<UI_SelectEventTrigger>();
		if (selectableEvents == null)
		{
			selectableEvents = selectable.gameObject.AddComponent<UI_SelectEventTrigger>();
		}
		GenerateEvent(OnSelect, EventTriggerType.Select);
		GenerateEvent(OnSubmit, EventTriggerType.Submit);
		GenerateEvent(OnDeselect, EventTriggerType.Deselect);
		GenerateEvent(OnSelect, EventTriggerType.PointerEnter);
		GenerateEvent(OnDeselect, EventTriggerType.PointerExit);
		void GenerateEvent(UnityAction<BaseEventData> actionEvent, EventTriggerType triggerType)
		{
			selectableEvents.AddEvent(actionEvent, triggerType);
		}
	}

	private void Update()
	{
		if (useDisableColor)
		{
			if (!isDisabled && !selectable.interactable)
			{
				thisGraphic.color = disabledColor;
				isDisabled = true;
			}
			else if (isDisabled && selectable.interactable)
			{
				isDisabled = false;
				thisGraphic.color = normalColor;
			}
		}
	}

	private void OnSelect(BaseEventData arg0)
	{
		if (selectable.interactable)
		{
			Color color = selectedColor;
			if (!affectAlpha)
			{
				color.a = thisGraphic.color.a;
			}
			thisGraphic.color = color;
		}
	}

	private void OnDeselect(BaseEventData arg0)
	{
		if (selectable.interactable)
		{
			Color color = normalColor;
			if (!affectAlpha)
			{
				color.a = thisGraphic.color.a;
			}
			thisGraphic.color = color;
		}
	}

	private void OnSubmit(BaseEventData arg0)
	{
		if (selectable.interactable)
		{
			Color color = selectedColor;
			if (!affectAlpha)
			{
				color.a = thisGraphic.color.a;
			}
			thisGraphic.color = color;
		}
	}
}
