using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PerkModule
{
	[Serializable]
	public class PerkModuleSaveInfo
	{
		public string perkModuleType;

		public List<string> data;
	}

	public string name;

	internal Perk perk;

	public virtual void Initialize(Perk p, bool firstTime)
	{
		perk = p;
		Debug.Log("Initializing Perk: " + p);
	}

	public virtual void AddModule(int amount = 1, bool firstTime = true)
	{
	}

	public virtual void Update()
	{
	}

	public virtual void OnDestroy(Perk p)
	{
	}

	public virtual void LoadSaveData(PerkModuleSaveInfo m)
	{
	}

	public virtual List<string> GetSaveData()
	{
		return null;
	}

	public virtual string GetCounterString()
	{
		return "";
	}

	public virtual float GetStatBuff(string key, bool total = false)
	{
		return float.NaN;
	}

	public virtual string GetDescriptionFromKey(string key)
	{
		return "";
	}
}
