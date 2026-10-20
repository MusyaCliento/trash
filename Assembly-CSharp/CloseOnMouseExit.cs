using UnityEngine;
using UnityEngine.EventSystems;

public class CloseOnMouseExit : MonoBehaviour, IPointerExitHandler, IEventSystemHandler
{
	public bool destroy;

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log(eventData);
		if (destroy)
		{
			Object.Destroy(base.gameObject);
		}
		base.gameObject.SetActive(value: false);
	}
}
