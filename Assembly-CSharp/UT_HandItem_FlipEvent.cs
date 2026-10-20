using UnityEngine;
using UnityEngine.Events;

public class UT_HandItem_FlipEvent : MonoBehaviour
{
	public HandItem handItem;

	public UnityEvent leftHandEvent;

	public UnityEvent rightHandEvent;

	private void Start()
	{
		if (handItem != null)
		{
			if (handItem.GetDirection() > 0)
			{
				rightHandEvent.Invoke();
			}
			else
			{
				leftHandEvent.Invoke();
			}
		}
	}
}
