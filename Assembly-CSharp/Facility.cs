using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Facility_New", menuName = "White Knuckle/Facility")]
public class Facility : ScriptableObject
{
	public string id;

	public List<FacilityUpgrade> upgrades;

	public List<Facility> subFacilities;

	public float upgradeCostMult = 1f;

	public int upgradeBonusCost;

	public int perkCostModifier;

	public int highValuePerks = 1;

	public static Action onPurchaseUpgrade;

	public List<FacilityUpgrade> GetUpgrades()
	{
		List<FacilityUpgrade> list = new List<FacilityUpgrade>();
		list.AddRange(upgrades);
		if (subFacilities != null && subFacilities.Count > 0)
		{
			foreach (Facility subFacility in subFacilities)
			{
				list.AddRange(subFacility.GetUpgrades());
			}
		}
		return list;
	}

	public bool IsComplete()
	{
		foreach (FacilityUpgrade upgrade in upgrades)
		{
			if (!upgrade.IsOwned(id))
			{
				return false;
			}
		}
		return true;
	}

	public static Facility GetFacilityFromID(string id)
	{
		return CL_AssetManager.GetFacilityAsset(id);
	}
}
