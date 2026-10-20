using System.Collections.Generic;
using UnityEngine;

public class PerkModule_BuffFromStat : PerkModule
{
	public string statName;

	public BuffContainer buff;

	public bool increaseBuffUsesPerkStack;

	public BuffContainer increaseBuff;

	public float buffMultiplier = 1f;

	public bool useCurve;

	public int curveMax = 10;

	public AnimationCurve curve = AnimationCurve.Constant(0f, 1f, 1f);

	private BuffContainer currentBuff;

	private int lastStat;

	private int startStat;

	public bool useCounterText;

	public string counterPrepend = "";

	public bool countStatFromPerkInitialization;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
		if (firstTime)
		{
			lastStat = StatManager.GetStatisticInt(StatManager.sessionStats, statName);
			startStat = lastStat;
		}
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
		int num = StatManager.GetStatisticInt(StatManager.sessionStats, statName);
		float stackEvaluationMultiplier = perk.GetStackEvaluationMultiplier();
		if (lastStat < num)
		{
			lastStat = num;
			increaseBuff.Initialize();
			if (increaseBuffUsesPerkStack)
			{
				increaseBuff.SetMultiplier(stackEvaluationMultiplier);
			}
			else
			{
				increaseBuff.SetMultiplier(1f);
			}
			CL_GameManager.gMan.localPlayer.Buff(increaseBuff.CopyBuffContainer());
		}
		if (countStatFromPerkInitialization)
		{
			num -= startStat;
		}
		float num2 = num;
		if (useCurve)
		{
			num2 = curve.Evaluate(num2 / (float)curveMax);
		}
		currentBuff.SetMultiplier(num2 * buffMultiplier * stackEvaluationMultiplier);
	}

	public override void OnDestroy(Perk p)
	{
		if (perk.player != null)
		{
			perk.player.curBuffs.RemoveBuffContainer(buff.id);
		}
		base.OnDestroy(p);
	}

	public override string GetCounterString()
	{
		if (useCounterText)
		{
			int num = StatManager.GetStatisticInt(StatManager.sessionStats, statName);
			if (countStatFromPerkInitialization)
			{
				num -= startStat;
			}
			return counterPrepend + num;
		}
		return "";
	}

	public override float GetStatBuff(string key, bool total = false)
	{
		float num = 1f;
		if (perk != null && total)
		{
			_ = perk.stackAmount;
			num = Mathf.Max(perk.GetStackEvaluationMultiplier(), 1f);
		}
		int num2 = StatManager.GetStatisticInt(StatManager.sessionStats, statName);
		if (countStatFromPerkInitialization)
		{
			num2 -= startStat;
		}
		if (!total)
		{
			num2 = 1;
		}
		float num3 = 1f;
		if (useCurve)
		{
			num3 = curve.Evaluate(num2 / curveMax);
		}
		if (key == "bfs_stat")
		{
			return num2;
		}
		foreach (BuffContainer.Buff buff in buff.buffs)
		{
			if ("bfs_stat_" + buff.id == key)
			{
				return buff.maxAmount * num3 * num;
			}
			if ("bfs_stat_current_" + buff.id == key)
			{
				return buff.maxAmount * num3 * (float)num2 * num;
			}
		}
		foreach (BuffContainer.Buff buff2 in increaseBuff.buffs)
		{
			if ("bfs_increase_" + buff2.id == key)
			{
				if (increaseBuffUsesPerkStack)
				{
					return buff2.maxAmount * num;
				}
				return buff2.maxAmount;
			}
		}
		return base.GetStatBuff(key);
	}

	public override void LoadSaveData(PerkModuleSaveInfo m)
	{
		base.LoadSaveData(m);
		if (m.data != null && m.data.Count > 0)
		{
			int.TryParse(m.data[0], out startStat);
		}
	}

	public override List<string> GetSaveData()
	{
		return new List<string> { startStat.ToString() };
	}

	public override string GetDescriptionFromKey(string key)
	{
		if (perk == null)
		{
			return "";
		}
		return base.GetDescriptionFromKey(key);
	}
}
