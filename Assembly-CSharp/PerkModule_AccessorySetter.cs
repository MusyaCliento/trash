using UnityEngine;

public class PerkModule_AccessorySetter : PerkModule
{
	public string accessoryID;

	public Sprite accessorySprite;

	public int handID = -1;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
		UT_AccessoryRenderer.SetAccessorySprite(accessoryID, accessorySprite, handID);
	}

	public override void OnDestroy(Perk p)
	{
		base.OnDestroy(p);
		UT_AccessoryRenderer.SetAccessorySprite(accessoryID, null, handID);
	}
}
