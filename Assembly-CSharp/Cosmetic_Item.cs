using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Cosmetic", menuName = "White Knuckle/Cosmetic/Item")]
public class Cosmetic_Item : Cosmetic_Base
{
	[Serializable]
	public class Cosmetic_Item_Data
	{
		[Serializable]
		public class AudioSwap
		{
			public string group;

			public string set;

			public List<AudioClip> clips;
		}

		public string id;

		public string itemName;

		public string modelfile;

		public List<AudioSwap> audioSwaps;
	}

	public Cosmetic_Item_Data cosmeticData;

	public Cosmetic_HandItem handItemCosmetic;

	public Mesh swapMesh;

	public Material swapMaterial;

	public Item_Object swapItem;

	public Sprite infoSprite;

	public override string GetCosmeticType()
	{
		return "item";
	}

	internal void Initialize()
	{
	}

	public override Sprite GetInfoSprite()
	{
		return infoSprite;
	}

	public void SetupHandItem(HandItem handItem)
	{
		UT_AudioClipHandler componentInChildren = handItem.gameObject.GetComponentInChildren<UT_AudioClipHandler>();
		if (!(componentInChildren != null))
		{
			return;
		}
		componentInChildren.Initialize();
		Debug.Log("Found Hand Item");
		foreach (Cosmetic_Item_Data.AudioSwap audioSwap in cosmeticData.audioSwaps)
		{
			UT_AudioClipHandler.AudioGroup audioGroup = componentInChildren.GetGroup(audioSwap.group);
			Debug.Log("Clip Group: " + audioGroup);
			if (audioGroup != null)
			{
				Debug.Log("Clip Set: " + audioGroup);
				UT_AudioClipHandler.AudioSet set = audioGroup.GetSet(audioSwap.set);
				if (set != null)
				{
					set.clips = audioSwap.clips;
				}
			}
		}
	}
}
