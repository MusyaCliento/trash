using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Craft Asset", menuName = "White Knuckle/Crafting/Craft Asset")]
public class Craft_Base : ScriptableObject
{
	[Serializable]
	public class CraftGroup
	{
		[Serializable]
		public class TagCombination
		{
			public List<string> tagComboSet;
		}

		public string desc;

		public int requiredCount;

		public List<TagCombination> possibleInputTags;

		public List<string> inputBlacklistTags;

		public bool CanCraft(List<string> tags)
		{
			foreach (string tag in tags)
			{
				if (inputBlacklistTags.Contains(tag))
				{
					return false;
				}
			}
			foreach (TagCombination possibleInputTag in possibleInputTags)
			{
				bool flag = true;
				foreach (string item in possibleInputTag.tagComboSet)
				{
					if (!tags.Contains(item))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					return true;
				}
			}
			return false;
		}
	}

	[Serializable]
	public class CraftOutput
	{
		public List<GameEntity> outputEntities;
	}

	[Serializable]
	public class CraftObject
	{
		public string craftID;

		public List<CraftGroup> requiredGroups;

		public List<CraftOutput> outputs;
	}

	public List<CraftObject> crafts;

	public (bool canCraft, List<Item> craftableItems, CraftObject foundCraft) CanCraftFromItems(List<Item> items)
	{
		List<Item> list = new List<Item>();
		foreach (CraftObject craft in crafts)
		{
			bool flag = true;
			foreach (CraftGroup requiredGroup in craft.requiredGroups)
			{
				List<Item> list2 = new List<Item>();
				list2.AddRange(items);
				for (int i = 0; i < requiredGroup.requiredCount; i++)
				{
					bool flag2 = false;
					if (list2.Count == 0)
					{
						flag = false;
						break;
					}
					for (int num = list2.Count - 1; num >= 0; num--)
					{
						Item item = list2[num];
						if (requiredGroup.CanCraft(item.itemTags))
						{
							list2.RemoveAt(num);
							list.Add(item);
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				return (canCraft: true, craftableItems: list, foundCraft: craft);
			}
		}
		return (canCraft: false, craftableItems: list, foundCraft: null);
	}

	public List<GameEntity> CraftObjectFromItems(List<Item> items)
	{
		(bool, List<Item>, CraftObject) tuple = CanCraftFromItems(items);
		if (tuple.Item1)
		{
			foreach (Item item in tuple.Item2)
			{
				item.Destroy();
			}
			if (tuple.Item3 != null)
			{
				return tuple.Item3.outputs[UnityEngine.Random.Range(0, tuple.Item3.outputs.Count)].outputEntities;
			}
		}
		return null;
	}
}
