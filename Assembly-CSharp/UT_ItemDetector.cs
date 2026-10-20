using UnityEngine;
using UnityEngine.Events;

public class UT_ItemDetector : MonoBehaviour
{
	public string searchTag;

	public bool active = true;

	public UnityEvent searchSuccess;

	public UnityEvent searchFail;

	public bool runContinuouslyUntilFound;

	public bool checkInHand;

	private float checkTime;

	private bool hasFoundItem;

	private void Update()
	{
		if (active && runContinuouslyUntilFound && !hasFoundItem)
		{
			checkTime -= Time.deltaTime;
			if (checkTime <= 0f)
			{
				Search();
				checkTime = 1f;
			}
		}
	}

	public void Search()
	{
		if (Inventory.instance.HasItemWithTag(searchTag, checkInHand))
		{
			searchSuccess.Invoke();
			hasFoundItem = true;
		}
		else
		{
			searchFail.Invoke();
		}
	}

	public void SetActive(bool b)
	{
		active = b;
	}
}
