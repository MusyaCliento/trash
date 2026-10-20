using UnityEngine;

public class PerkModule_LastStand : PerkModule
{
	public string statName;

	public BuffContainer buff;

	public BuffContainer increaseBuff;

	public float healthMin = 1f;

	public bool useCurve;

	public int curveMax = 10;

	public AnimationCurve curve = AnimationCurve.Constant(0f, 1f, 1f);

	private BuffContainer currentBuff;

	private int lastStat;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
		lastStat = StatManager.GetStatisticInt(StatManager.sessionStats, statName);
		if (buff.id != "")
		{
			currentBuff = perk.player.curBuffs.GetBuffContainer(buff.id);
		}
		if (currentBuff == null)
		{
			perk.player.curBuffs.AddBuff(buff);
			currentBuff = perk.player.curBuffs.GetBuffContainer(buff.id);
		}
	}

	public override void Update()
	{
		base.Update();
		int statisticInt = StatManager.GetStatisticInt(StatManager.sessionStats, statName);
		if (lastStat < statisticInt)
		{
			lastStat = statisticInt;
			increaseBuff.Initialize();
			CL_GameManager.gMan.localPlayer.Buff(increaseBuff.CopyBuffContainer());
		}
		float num = statisticInt;
		if (useCurve)
		{
			num = curve.Evaluate(num / (float)curveMax);
		}
	}

	public override void OnDestroy(Perk p)
	{
		if (perk.player != null)
		{
			perk.player.curBuffs.RemoveBuffContainer(buff.id);
		}
		base.OnDestroy(p);
	}
}
