using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UT_SpriteSwapper : MonoBehaviour
{
	[Serializable]
	public class SpriteSwap
	{
		public string target;

		public Sprite swap;
	}

	public class ReturnSprite
	{
		public SpriteRenderer target;

		public Sprite returnSprite;
	}

	public List<SpriteSwap> swaps;

	private Dictionary<string, Sprite> swapDict;

	private SpriteRenderer[] swapRenderers;

	private void Start()
	{
		swapDict = new Dictionary<string, Sprite>();
		for (int i = 0; i < swaps.Count; i++)
		{
			swapDict.Add(swaps[i].target, swaps[i].swap);
		}
		swapRenderers = base.gameObject.GetComponentsInChildren<SpriteRenderer>();
	}

	private void LateUpdate()
	{
		List<ReturnSprite> returnSprites = new List<ReturnSprite>();
		for (int i = 0; i < swapRenderers.Length; i++)
		{
			string key = swapRenderers[i].sprite.name;
			if (swapDict.ContainsKey(key))
			{
				ReturnSprite item = new ReturnSprite
				{
					target = swapRenderers[i],
					returnSprite = swapRenderers[i].sprite
				};
				returnSprites.Add(item);
				swapRenderers[i].sprite = swapDict[key];
			}
		}
		if (returnSprites.Count > 0)
		{
			StartCoroutine(ReturnAllSprites());
		}
		IEnumerator ReturnAllSprites()
		{
			yield return new WaitForEndOfFrame();
			for (int j = 0; j < returnSprites.Count; j++)
			{
				returnSprites[j].target.sprite = returnSprites[j].returnSprite;
			}
		}
	}
}
