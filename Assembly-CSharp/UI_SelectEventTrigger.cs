using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UI_SelectEventTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, ISubmitHandler
{
	internal UnityEvent<BaseEventData> OnSelectEvent;

	internal UnityEvent<BaseEventData> OnDeselectEvent;

	internal UnityEvent<BaseEventData> OnPointerEnterEvent;

	internal UnityEvent<BaseEventData> OnPointerExitEvent;

	internal UnityEvent<BaseEventData> OnSubmitEvent;

	public List<EventTrigger.Entry> triggers;

	private void Awake()
	{
		OnSelectEvent = new UnityEvent<BaseEventData>();
		OnDeselectEvent = new UnityEvent<BaseEventData>();
		OnPointerEnterEvent = new UnityEvent<BaseEventData>();
		OnPointerExitEvent = new UnityEvent<BaseEventData>();
		OnSubmitEvent = new UnityEvent<BaseEventData>();
	}

	public void AddEvent(UnityAction<BaseEventData> eventData, EventTriggerType triggerType)
	{
		switch (triggerType)
		{
		case EventTriggerType.PointerEnter:
			OnPointerEnterEvent.AddListener(eventData);
			break;
		case EventTriggerType.PointerExit:
			OnPointerExitEvent.AddListener(eventData);
			break;
		case EventTriggerType.Select:
			OnSelectEvent.AddListener(eventData);
			break;
		case EventTriggerType.Deselect:
			OnDeselectEvent.AddListener(eventData);
			break;
		case EventTriggerType.Submit:
			OnSubmitEvent.AddListener(eventData);
			break;
		}
	}

	public void OnSelect(BaseEventData eventData)
	{
		OnSelectEvent.Invoke(eventData);
	}

	public void OnDeselect(BaseEventData eventData)
	{
		OnDeselectEvent.Invoke(eventData);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		OnPointerEnterEvent.Invoke(eventData);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		OnPointerExitEvent.Invoke(eventData);
	}

	public void OnSubmit(BaseEventData eventData)
	{
		OnSubmitEvent.Invoke(eventData);
	}
}
