using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OS_EventSystem : MonoBehaviour
{
	public Transform pointer;

	public PointerEventData pointerData;

	public LayerMask layerMask;

	private GraphicRaycaster m_Raycaster;

	private EventSystem m_EventSystem;

	private Vector2 lastPointerPosition;

	private void Start()
	{
		m_Raycaster = GetComponent<GraphicRaycaster>();
		m_EventSystem = GetComponent<EventSystem>();
	}

	private void Update()
	{
		PointerHandler();
	}

	private void PointerHandler()
	{
		pointerData = new PointerEventData(m_EventSystem);
		pointerData.position = pointer.position;
		pointerData.delta = lastPointerPosition - pointerData.position;
		lastPointerPosition = pointer.position;
		if (Input.GetMouseButtonDown(0))
		{
			pointerData.button = PointerEventData.InputButton.Left;
			OnOSClick(pointerData);
		}
		if (Input.GetMouseButtonDown(1))
		{
			pointerData.button = PointerEventData.InputButton.Right;
			OnOSClick(pointerData);
		}
	}

	private void OnOSClick(PointerEventData pointerEvent)
	{
		List<RaycastResult> list = new List<RaycastResult>();
		m_Raycaster.Raycast(pointerData, list);
		if (list.Count > 0)
		{
			list[0].gameObject.GetComponent<OSPointerClickHandler>()?.OSPointerClick(pointerEvent);
		}
		foreach (RaycastResult item in list)
		{
			Debug.Log("Hit " + item.gameObject.name);
		}
	}
}
