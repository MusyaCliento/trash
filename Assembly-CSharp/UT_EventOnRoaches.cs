using UnityEngine;
using UnityEngine.Events;

public class UT_EventOnRoaches : MonoBehaviour
{
	public float roachCount;

	private int lastRoaches;

	public UnityEvent onLessRoaches;

	public UnityEvent onMoreRoaches;

	private void Start()
	{
		if ((float)CL_GameManager.GetRoaches() >= roachCount)
		{
			onMoreRoaches.Invoke();
		}
		else if ((float)CL_GameManager.GetRoaches() < roachCount)
		{
			onLessRoaches.Invoke();
		}
		lastRoaches = CL_GameManager.GetRoaches();
	}

	private void Update()
	{
		if (CL_GameManager.GetRoaches() != lastRoaches)
		{
			if ((float)CL_GameManager.GetRoaches() >= roachCount && (float)lastRoaches < roachCount)
			{
				onMoreRoaches.Invoke();
			}
			else if ((float)CL_GameManager.GetRoaches() < roachCount && (float)lastRoaches >= roachCount)
			{
				onLessRoaches.Invoke();
			}
			lastRoaches = CL_GameManager.GetRoaches();
		}
	}
}
