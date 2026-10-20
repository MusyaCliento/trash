using UnityEngine;
using UnityEngine.EventSystems;

namespace DarkMachine.UI
{
	internal static class MultipleDisplayUtilities
	{
		public static bool GetRelativeMousePositionForDrag(PointerEventData eventData, ref Vector2 position)
		{
			position = eventData.position;
			return true;
		}

		internal static Vector3 GetRelativeMousePositionForRaycast(PointerEventData eventData)
		{
			Vector3 vector = RelativeMouseAtScaled(eventData.position);
			if (vector == Vector3.zero)
			{
				vector = eventData.position;
				vector.z = Display.activeEditorGameViewTarget;
			}
			return vector;
		}

		public static Vector3 RelativeMouseAtScaled(Vector2 position)
		{
			return Display.RelativeMouseAt(position);
		}
	}
}
