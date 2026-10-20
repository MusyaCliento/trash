using UnityEngine;

public class Event_Cold_Controller : MonoBehaviour
{
	public void SetColdEventState(bool b)
	{
		Event_Cold.SetEventStatus(b);
	}

	public void StartBlizzard()
	{
		Event_Cold.ForceBlizzard();
	}
}
