using UnityEngine;

[CreateAssetMenu(fileName = "Facility_Upgrade_New", menuName = "White Knuckle/Facility Upgrade")]
public class FacilityUpgrade : ScriptableObject
{
	public string id;

	public int cost = 20;

	public bool global;

	public string cardName;

	[TextArea(1, 10)]
	public string description;

	public int minWidth = 3;

	public int maxWidth = 3;

	public int minHeight = 2;

	public int maxHeight = 2;

	public Sprite cardArt;

	public string purchaseFlag;

	public FacilityUpgrade prerequisiteUpgrade;

	public bool showIfLocked = true;

	public string unlockFlag;

	public string unlockDesc;

	public bool allowInIronKnuckle;

	public void Purchase(StatManager.SaveData.Facility facility)
	{
		Facility facilityFromID = Facility.GetFacilityFromID(facility.id);
		int num = cost;
		if (facilityFromID != null)
		{
			num = Mathf.RoundToInt((float)num * facilityFromID.upgradeCostMult + (float)facilityFromID.upgradeBonusCost);
		}
		if (CL_GameManager.IsInGame())
		{
			CL_GameManager.WithdrawRoachesFromGlobalBank(num);
			CL_GameManager.AddRoaches(-num);
		}
		facility.GetOrCreateUpgrade(id).owned = true;
		if (!string.IsNullOrEmpty(purchaseFlag))
		{
			CL_GameManager.SetGameFlag(purchaseFlag, state: true, "", save: true);
		}
		if (Facility.onPurchaseUpgrade != null)
		{
			Facility.onPurchaseUpgrade();
		}
	}

	public void Purchase(string facilityID)
	{
		StatManager.SaveData.Facility facility = StatManager.saveData.GetFacility(facilityID);
		if (facility != null)
		{
			Purchase(facility);
		}
	}

	public bool IsOwned(string facilityID)
	{
		if (CL_GameManager.IsIronKnuckle())
		{
			return allowInIronKnuckle;
		}
		StatManager.SaveData.Facility.Upgrade upgrade = StatManager.saveData.GetFacility(facilityID).GetUpgrade(id);
		if (upgrade != null && upgrade.owned)
		{
			return true;
		}
		return false;
	}

	public bool IsLocked(string facilityID)
	{
		bool flag = false;
		if (!string.IsNullOrEmpty(unlockFlag) && !CL_GameManager.HasActiveFlag(unlockFlag, useUnlockAll: true))
		{
			flag = true;
		}
		StatManager.SaveData.Facility facility = StatManager.saveData.GetFacility(facilityID);
		if (prerequisiteUpgrade != null && !facility.HasUpgrade(prerequisiteUpgrade.id))
		{
			flag = true;
		}
		if (flag)
		{
			return true;
		}
		return false;
	}

	public int GetCost(string facilityID)
	{
		Facility facilityFromID = Facility.GetFacilityFromID(facilityID);
		if (facilityFromID != null)
		{
			return Mathf.RoundToInt((float)cost * facilityFromID.upgradeCostMult + (float)facilityFromID.upgradeBonusCost);
		}
		return cost;
	}
}
