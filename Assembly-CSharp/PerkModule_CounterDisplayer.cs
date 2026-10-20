public class PerkModule_CounterDisplayer : PerkModule
{
	public enum CounterOutput
	{
		custom = 0,
		temporaryExtraJumpsRemaining = 1
	}

	public string prefix;

	public CounterOutput counterOutput;

	public bool showIfZero = true;

	public override string GetCounterString()
	{
		if (counterOutput == CounterOutput.temporaryExtraJumpsRemaining)
		{
			int temporaryExtraJumpsRemaining = ENT_Player.GetPlayer().GetTemporaryExtraJumpsRemaining();
			if (!showIfZero && temporaryExtraJumpsRemaining == 0)
			{
				return "";
			}
			return prefix + temporaryExtraJumpsRemaining;
		}
		return base.GetCounterString();
	}

	public override float GetStatBuff(string key, bool total = false)
	{
		if (key == "player_tempextrajumps")
		{
			return ENT_Player.GetPlayer().GetTemporaryExtraJumpsRemaining();
		}
		return base.GetStatBuff(key, total);
	}
}
