using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ContextMenu : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[Serializable]
	public class ContextOption
	{
		public string text;

		public string data;

		public UnityEvent clickEvent;
	}

	public List<ContextOption> options;

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			ShowMessage();
		}
	}

	private void ShowMessage()
	{
		ContextMenu_Manager.OnClick("", OS_Manager.mouseRealPosition, options);
	}
}
