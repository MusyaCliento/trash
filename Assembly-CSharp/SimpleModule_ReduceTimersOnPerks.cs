public class SimpleModule_ReduceTimersOnPerks : SimpleModule
{
	public string targetPerkTag;

	public float timeToReduce;

	public override void Activate()
	{
		base.Activate();
		foreach (Perk perk in ENT_Player.GetPlayer().perks)
		{
			if (!(targetPerkTag == "") && !perk.tags.Contains(targetPerkTag))
			{
				continue;
			}
			foreach (PerkModule module in perk.modules)
			{
				if (module is PerkModule_RemovalTimer)
				{
					(module as PerkModule_RemovalTimer).AddTime(0f - timeToReduce);
				}
			}
		}
	}
}
