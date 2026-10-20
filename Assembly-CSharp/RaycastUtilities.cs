using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class RaycastUtilities
{
	public static bool PointerIsOverUI(Vector2 screenPos, string layerName = "UI")
	{
		GameObject gameObject = UIRaycast(ScreenPosToPointerData(screenPos));
		if (gameObject != null)
		{
			return gameObject.layer == LayerMask.NameToLayer(layerName);
		}
		return false;
	}

	public static bool PointerIsOverUI(Vector2 screenPos, string tag, string layerName = "UI")
	{
		GameObject gameObject = UIRaycast(screenPos, tag, layerName);
		if (gameObject != null)
		{
			return gameObject.layer == LayerMask.NameToLayer(layerName);
		}
		return false;
	}

	public static GameObject UIRaycast(PointerEventData pointerData)
	{
		List<RaycastResult> list = new List<RaycastResult>();
		EventSystem.current.RaycastAll(pointerData, list);
		if (list.Count >= 1)
		{
			return list[0].gameObject;
		}
		return null;
	}

	public static GameObject UIRaycast(Vector2 screenPos)
	{
		return UIRaycast(ScreenPosToPointerData(screenPos));
	}

	public static GameObject UIRaycast(Vector2 screenPos, string tag, string layerName)
	{
		PointerEventData eventData = ScreenPosToPointerData(screenPos);
		List<RaycastResult> list = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventData, list);
		if (list.Count == 0)
		{
			return null;
		}
		while (list.Count > 0)
		{
			if (list[0].gameObject.tag == tag && list[0].gameObject.layer == LayerMask.NameToLayer(layerName))
			{
				return list[0].gameObject;
			}
			list.RemoveAt(0);
		}
		return null;
	}

	private static PointerEventData ScreenPosToPointerData(Vector2 screenPos)
	{
		return new PointerEventData(EventSystem.current)
		{
			position = screenPos
		};
	}
}
