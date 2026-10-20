using UnityEngine;

public class PerkModule_ColdBuff : PerkModule
{
	public BuffContainer buff;

	public float buffMultiplier = 1f;

	public bool useCurve;

	public AnimationCurve curve;

	private BuffContainer currentBuff;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
		if (buff.id != "")
		{
			currentBuff = perk.player.curBuffs.GetBuffContainer(buff.id);
		}
		if (currentBuff == null)
		{
			perk.player.curBuffs.AddBuff(buff);
			currentBuff = perk.player.curBuffs.GetBuffContainer(buff.id);
		}
		currentBuff.SetMultiplier(1f * buffMultiplier);
	}

	public override void Update()
	{
		base.Update();
		float num = Event_Cold.GetFreezingAmount();
		if (useCurve)
		{
			num = curve.Evaluate(num);
		}
		currentBuff.SetMultiplier(num * buffMultiplier * (float)perk.GetStackAmount());
	}

	public override void OnDestroy(Perk p)
	{
		perk.player.curBuffs.RemoveBuffContainer(buff.id);
		base.OnDestroy(p);
	}
}
