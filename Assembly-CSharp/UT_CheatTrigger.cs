using UnityEngine;
using UnityEngine.Events;

public class UT_CheatTrigger : MonoBehaviour
{
	private bool hasDetectedCheats;

	public UnityEvent hasCheatedEvent;

	private void Update()
	{
		if (!hasDetectedCheats && CommandConsole.hasCheated)
		{
			hasDetectedCheats = true;
			hasCheatedEvent.Invoke();
		}
	}
}
