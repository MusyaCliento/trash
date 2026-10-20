using UnityEngine;
using UnityEngine.Events;

public class UT_GetPlayer : MonoBehaviour
{
	public UnityEvent<Transform> transformEvent;

	public void SendPlayer()
	{
		transformEvent.Invoke(ENT_Player.GetPlayer().transform);
	}
}
