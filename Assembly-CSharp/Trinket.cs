using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Trinket_New", menuName = "White Knuckle/Trinket")]
public class Trinket : ScriptableObject
{
	public struct ScoreCalc
	{
		public float trinketValue;

		public float bindingValue;
	}

	public string title;

	[TextArea]
	public string description;

	[TextArea]
	public string flavorText;

	public bool isBinding;

	public Sprite icon;

	public Sprite lockIcon;

	public int cost = 1;

	public List<Item_Object> itemsToGrant = new List<Item_Object>();

	public List<Perk> perksToGrant = new List<Perk>();

	public int pouchesToGrant;

	public ProgressionUnlock progressionUnlock;

	public float scoreMultiplierBonus = 1f;

	public float scoreBonus;

	public bool comingSoon;

	public List<string> settingBlacklist;

	public int activateOrder;

	public void Activate(float scoreAdjustmentMult = 1f)
	{
		Debug.Log("Activating trinket: " + title);
		if (ENT_Player.GetPlayer() == null)
		{
			Debug.LogError("No player found to activate trinket on!");
			return;
		}
		CL_GameManager gMan = CL_GameManager.gMan;
		for (int i = 0; i < itemsToGrant.Count; i++)
		{
			Item_Object item_Object = itemsToGrant[i];
			foreach (CL_GameManager.ReplaceInfo replacementScope in gMan.replacementScopes)
			{
				if (item_Object != null && item_Object.TryGetComponent<GameEntity>(out var component) && replacementScope.ShouldReplace(component, useRandom: true))
				{
					GameEntity gameEntity = replacementScope.Replace(Object.Instantiate(component));
					Item_Object item_Object2 = ((gameEntity != null) ? gameEntity.GetComponent<Item_Object>() : null);
					if (gameEntity != null && item_Object2 != null)
					{
						item_Object = item_Object2;
					}
					if (gameEntity != null && item_Object2 == null)
					{
						Debug.LogError("Could not find Item_Object component on replaced " + gameEntity.name + " from " + item_Object.name);
						item_Object = null;
					}
					if (gameEntity == null)
					{
						item_Object = null;
					}
				}
			}
			if (item_Object != null)
			{
				Inventory.instance.AddItemToInventoryScreen(new Vector3(-0.4f, 0.4f, 1f) + Random.insideUnitSphere * 0.01f, item_Object.itemData.GetClone(), localSpacePosition: true);
			}
		}
		foreach (Perk item in perksToGrant)
		{
			ENT_Player.GetPlayer().AddPerk(item);
		}
		if (pouchesToGrant > 0)
		{
			for (int j = 0; j < pouchesToGrant; j++)
			{
				Inventory.instance.AddExtraPouch();
			}
		}
	}

	public bool IsUnlocked()
	{
		if (progressionUnlock == null)
		{
			return true;
		}
		return progressionUnlock.CheckUnlock();
	}

	public string GetDescription()
	{
		string text = "";
		if (isBinding)
		{
			return text + "<color=grey>Binding:</color> <color=red><shimmer s=0.1>" + title + "</shimmer></color>. <shake a=0.01>" + description + "</shake>\n<color=grey>" + flavorText + "</color>";
		}
		return text + "<color=grey>Trinket:</color> <color=#FF8AFF><shimmer s=0.1>" + title + "</shimmer>. </color>" + description + "\n<color=grey>" + flavorText + "</color>";
	}

	public string GetLockedDescription()
	{
		string text = "<color=#FF8AFF><shimmer s=0.1>" + title + "</shimmer></color>";
		if (isBinding)
		{
			text = "<color=red><shimmer s=0.1>" + title + "</shimmer></color>";
		}
		string text2 = (isBinding ? "Binding" : "Trinket");
		if (comingSoon)
		{
			return "<color=grey>Locked " + text2 + ": </color>" + text + "</color>";
		}
		if (progressionUnlock.showProgression)
		{
			return "<color=grey>Locked " + text2 + ": </color>" + text + "\n<color=grey>Unlock Requirement: " + progressionUnlock.unlockHint + " (" + progressionUnlock.GetProgressString() + ")</color>";
		}
		return "<color=grey>Locked " + text2 + ": </color>" + text + "\n<color=grey>Unlock Requirement: " + progressionUnlock.unlockHint + "</color>";
	}

	public static ScoreCalc CalculateScoreFromTrinkets(List<Trinket> trinkets)
	{
		ScoreCalc result = default(ScoreCalc);
		List<float> list = new List<float>();
		List<float> list2 = new List<float>();
		foreach (Trinket trinket in trinkets)
		{
			if (!trinket.isBinding)
			{
				list2.Add(trinket.scoreMultiplierBonus);
			}
			else
			{
				list.Add(trinket.scoreMultiplierBonus);
			}
		}
		list.Sort();
		list2.Sort();
		int num = 1;
		for (int i = 0; i < list.Count; i++)
		{
			float num2 = list[list.Count - 1 - i];
			if (num2 != 0f)
			{
				float num3 = num2 / (float)num;
				result.bindingValue += num3;
				num++;
			}
		}
		int num4 = 1;
		for (int j = 0; j < list2.Count; j++)
		{
			float num5 = list2[j];
			if (num5 != 0f)
			{
				float num6 = num5 / (float)num4;
				result.trinketValue += num6;
				num4++;
			}
		}
		return result;
	}
}
