public class PerkModule_PlayerHandCosmeticOverride : PerkModule
{
	public int hands = -1;

	public string cosmeticName;

	public bool removeCosmetics = true;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
		string text = "both";
		if (hands == 0)
		{
			text = "left";
		}
		else if (hands == 1)
		{
			text = "right";
		}
		if (removeCosmetics)
		{
			ENT_Player.Hand[] array = perk.player.hands;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].currentCosmetics.Clear();
			}
		}
		CL_CosmeticManager.LoadHandCosmetic(new string[2] { cosmeticName, text });
	}

	public override void OnDestroy(Perk p)
	{
		base.OnDestroy(p);
	}
}
