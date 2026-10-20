using UnityEngine;
using UnityEngine.Events;

public class UT_SendPlayerTransform : MonoBehaviour
{
	public UnityEvent<Transform> output;

	public bool sendOnStart;

	private void Start()
	{
		if (sendOnStart)
		{
			SendTransform();
		}
	}

	public void SendTransform()
	{
		output.Invoke(ENT_Player.playerObject.transform);
	}
}
