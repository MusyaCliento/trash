public class PerkModule_PlayerAudioOverride : PerkModule
{
	public AudioClipHandlerOverride audioOverride;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
		ENT_Player.GetPlayer().clipHandler.AddOverride(audioOverride);
	}

	public override void OnDestroy(Perk p)
	{
		base.OnDestroy(p);
		if (ENT_Player.GetPlayer() != null)
		{
			ENT_Player.GetPlayer().clipHandler.RemoveOverride(audioOverride);
		}
	}
}
