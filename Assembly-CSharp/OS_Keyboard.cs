using UnityEngine;
using UnityEngine.Events;

public class OS_Keyboard : MonoBehaviour
{
	public UnityEvent<string> inputEvent;

	public void InputKey(string k)
	{
		inputEvent.Invoke(k);
	}
}
