using UnityEngine;

public class UT_SessionEventController : MonoBehaviour
{
	public void StartEvent(SessionEvent sessionEvent)
	{
		CL_EventManager.StartEvent(sessionEvent);
	}
}
