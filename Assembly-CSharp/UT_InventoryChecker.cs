using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UT_InventoryChecker : MonoBehaviour
{
	public bool active = true;

	public List<string> inventoryCheckTags;

	public UnityEvent hasItemEvent;

	public UnityEvent noItemEvent;

	public bool checkEveryFrame;

	public bool checkOnStart;

	private void Start()
	{
		if (checkOnStart)
		{
			Check();
		}
	}

	private void Update()
	{
		if (active && checkEveryFrame)
		{
			Check();
		}
	}

	public void Check()
	{
		bool flag = false;
		foreach (string inventoryCheckTag in inventoryCheckTags)
		{
			if (Inventory.instance.HasItemWithTag(inventoryCheckTag))
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			hasItemEvent.Invoke();
		}
		else
		{
			noItemEvent.Invoke();
		}
	}

	public void SetActive(bool b)
	{
		active = b;
	}
}
