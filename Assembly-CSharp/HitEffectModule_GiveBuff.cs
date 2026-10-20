using System;

[Serializable]
public class HitEffectModule_GiveBuff : HitEffectModule
{
	public BuffContainer buff;

	public override void OnHit(in Desc desc)
	{
		base.OnHit(in desc);
		BuffContainer buffContainer = buff.CopyBuffContainer();
		buffContainer.Initialize();
		ENT_Player.GetPlayer().Buff(buffContainer);
	}
}
