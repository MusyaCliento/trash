using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UI_PointerClickHandler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerMoveHandler
{
	public UnityEvent<PointerEventData> onClick;

	public UnityEvent<PointerEventData> onMove;

	public void OnPointerMove(PointerEventData eventData)
	{
		onMove.Invoke(eventData);
	}

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		onClick.Invoke(eventData);
	}
}
