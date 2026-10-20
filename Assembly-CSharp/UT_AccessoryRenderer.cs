using System.Collections.Generic;
using UnityEngine;

public class UT_AccessoryRenderer : MonoBehaviour
{
	public string cosmeticID;

	public SpriteRenderer rend;

	public int handID = -1;

	public static Dictionary<string, List<UT_AccessoryRenderer>> accessoryRenderers = new Dictionary<string, List<UT_AccessoryRenderer>>();

	private void Awake()
	{
		if (rend == null)
		{
			rend = GetComponent<SpriteRenderer>();
		}
		if (accessoryRenderers == null)
		{
			accessoryRenderers = new Dictionary<string, List<UT_AccessoryRenderer>>();
		}
		if (!accessoryRenderers.ContainsKey(cosmeticID))
		{
			List<UT_AccessoryRenderer> list = new List<UT_AccessoryRenderer>();
			list.Add(this);
			accessoryRenderers.Add(cosmeticID, list);
		}
		else
		{
			accessoryRenderers[cosmeticID].Add(this);
		}
	}

	private void OnDestroy()
	{
		if (accessoryRenderers.ContainsKey(cosmeticID))
		{
			accessoryRenderers.Remove(cosmeticID);
		}
	}

	public static void SetAccessorySprite(string id, Sprite sprite, int checkID = -1)
	{
		if (accessoryRenderers == null || !accessoryRenderers.ContainsKey(id))
		{
			return;
		}
		foreach (UT_AccessoryRenderer item in accessoryRenderers[id])
		{
			if (item != null && (checkID == -1 || item.handID == checkID))
			{
				item.rend.sprite = sprite;
			}
		}
	}

	public void MoveThisShit()
	{
		if (!(rend == null))
		{
			rend.gameObject.name = cosmeticID;
			rend.gameObject.AddComponent<UT_AccessoryRenderer>().cosmeticID = cosmeticID;
		}
	}
}
