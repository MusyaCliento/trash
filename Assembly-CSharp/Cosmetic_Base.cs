using System.Collections.Generic;
using UnityEngine;

public class Cosmetic_Base : ScriptableObject
{
	public Cosmetic_Info cosmeticInfo;

	public bool showInCosmeticsWindow = true;

	public float accessoryOpacity = 1f;

	public virtual string GetCosmeticType()
	{
		return "base";
	}

	public virtual List<string> GetCosmeticSaveData()
	{
		return null;
	}

	public virtual void SetCosmeticSaveData(List<string> data)
	{
	}

	public bool IsUnlocked()
	{
		if (string.IsNullOrEmpty(cosmeticInfo.unlock))
		{
			return true;
		}
		if (CL_ProgressionManager.HasProgressionUnlock(cosmeticInfo.unlock))
		{
			return true;
		}
		return false;
	}

	public ProgressionUnlock GetUnlock()
	{
		if (string.IsNullOrEmpty(cosmeticInfo.unlock))
		{
			return null;
		}
		return CL_ProgressionManager.GetProgressionUnlock(cosmeticInfo.unlock);
	}

	public virtual Sprite GetInfoSprite()
	{
		return null;
	}
}
