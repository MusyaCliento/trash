using UnityEngine;

public class UT_BuddyController : MonoBehaviour
{
	private DEN_Buddy buddy;

	public DEN_Buddy.BuddyEvent buddyEvent;

	public void SetBuddy(Transform t)
	{
		buddy = t.GetComponent<DEN_Buddy>();
	}

	public void SetBuddy(DEN_Buddy t)
	{
		buddy = t;
	}

	public void SetBuddyHangoutSpot(Transform t)
	{
		if (buddy == null)
		{
			Debug.LogError("BUDDYCONTROLLER: No Buddy Assigned :(");
		}
		else
		{
			buddy.SetHangoutSpot(t.position);
		}
	}

	public void PlayBuddyEvent()
	{
		buddy.PlayEvent(buddyEvent);
	}
}
