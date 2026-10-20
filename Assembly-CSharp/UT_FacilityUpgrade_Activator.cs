using System;
using UnityEngine;
using UnityEngine.Events;

public class UT_FacilityUpgrade_Activator : MonoBehaviour
{
	public FacilityUpgrade upgrade;

	public Facility facility;

	public UnityEvent ownedEvent;

	public UnityEvent notOwnedEvent;

	private bool initialized;

	private bool active;

	public bool disableIfNotOwned;

	public bool checkOnEnable = true;

	public bool invert;

	private void Awake()
	{
		Facility.onPurchaseUpgrade = (Action)Delegate.Combine(Facility.onPurchaseUpgrade, new Action(Check));
		Check();
		initialized = true;
	}

	private void OnDestroy()
	{
		Facility.onPurchaseUpgrade = (Action)Delegate.Remove(Facility.onPurchaseUpgrade, new Action(Check));
	}

	private void OnEnable()
	{
		if (checkOnEnable)
		{
			Check();
		}
	}

	public void Check()
	{
		bool flag = false;
		Debug.Log("Checking Upgrade Activator: " + base.name + " :: " + facility.name + " :: " + upgrade.IsOwned(facility.id));
		flag = (upgrade.IsOwned(facility.id) ? true : false);
		if (CL_GameManager.GetCurrentGamemode().IsCompetitive())
		{
			flag = true;
		}
		if (invert)
		{
			flag = !flag;
		}
		if (flag)
		{
			if (!active || !initialized)
			{
				active = true;
				ownedEvent.Invoke();
				if (disableIfNotOwned)
				{
					base.gameObject.SetActive(value: true);
				}
			}
		}
		else if (active || !initialized)
		{
			active = false;
			notOwnedEvent.Invoke();
			if (disableIfNotOwned)
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}
}
