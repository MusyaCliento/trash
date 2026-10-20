using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_AutoScrollToSelected : MonoBehaviour
{
	private ScrollRect scrollRect;

	public List<Transform> ignoreList;

	public bool onlyScrollOnController;

	private void Awake()
	{
		scrollRect = GetComponent<ScrollRect>();
	}

	private void LateUpdate()
	{
		if (onlyScrollOnController && !InputManager.IsGamepad())
		{
			return;
		}
		GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;
		if (currentSelectedGameObject == null)
		{
			return;
		}
		foreach (Transform ignore in ignoreList)
		{
			if (currentSelectedGameObject.transform.IsChildOf(ignore))
			{
				return;
			}
		}
		if (!currentSelectedGameObject.transform.IsChildOf(scrollRect.content))
		{
			return;
		}
		RectTransform component = currentSelectedGameObject.GetComponent<RectTransform>();
		if (!(component == null))
		{
			Vector2 vector = CalculateScrollOffset(scrollRect, component);
			if (scrollRect.vertical)
			{
				float y = scrollRect.content.anchoredPosition.y + vector.y;
				scrollRect.content.anchoredPosition = new Vector2(scrollRect.content.anchoredPosition.x, y);
			}
			if (scrollRect.horizontal)
			{
				float x = scrollRect.content.anchoredPosition.x + vector.x;
				scrollRect.content.anchoredPosition = new Vector2(x, scrollRect.content.anchoredPosition.y);
			}
		}
	}

	private Vector2 CalculateScrollOffset(ScrollRect scrollRect, RectTransform target)
	{
		Vector2 zero = Vector2.zero;
		RectTransform content = scrollRect.content;
		RectTransform viewport = scrollRect.viewport;
		Vector3[] array = new Vector3[4];
		content.GetWorldCorners(array);
		Vector3[] array2 = new Vector3[4];
		viewport.GetWorldCorners(array2);
		Vector3[] array3 = new Vector3[4];
		target.GetWorldCorners(array3);
		if (scrollRect.vertical)
		{
			_ = ref array[1];
			_ = ref array[0];
			float y = array2[1].y;
			float y2 = array2[0].y;
			float y3 = array3[1].y;
			float y4 = array3[0].y;
			if (y3 > y)
			{
				zero.y = y - y3;
			}
			else if (y4 < y2)
			{
				zero.y = y2 - y4;
			}
		}
		if (scrollRect.horizontal)
		{
			_ = ref array[0];
			_ = ref array[2];
			float x = array2[0].x;
			float x2 = array2[2].x;
			float x3 = array3[0].x;
			float x4 = array3[2].x;
			if (x3 < x)
			{
				zero.x = x - x3;
			}
			else if (x4 > x2)
			{
				zero.x = x2 - x4;
			}
		}
		return zero;
	}
}
