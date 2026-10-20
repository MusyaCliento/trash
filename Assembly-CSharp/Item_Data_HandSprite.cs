using UnityEngine;

public class Item_Data_HandSprite : Item_Data
{
	public Sprite handSprite;

	public override string GetDataType()
	{
		return "handsprite";
	}

	public override string GetSaveData()
	{
		if (handSprite != null)
		{
			return handSprite.name;
		}
		return "";
	}

	public override void LoadSaveData(string s)
	{
		base.LoadSaveData(s);
		Debug.Log("Load Data: " + s);
		handSprite = CL_AssetManager.GetSpriteAsset(s);
	}
}
