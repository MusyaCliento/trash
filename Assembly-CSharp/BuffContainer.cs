using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuffContainer
{
	[Serializable]
	public class Buff
	{
		public string id;

		public float maxAmount;

		[HideInInspector]
		public float amount;
	}

	public string id;

	public string desc;

	public List<Buff> buffs;

	public float loseRate = 0.1f;

	public bool loseRateEffectedByPerks = true;

	public float buffTime = 1f;

	public bool loseOverTime = true;

	public float multiplier = 1f;

	public void Initialize()
	{
		buffTime = 1f;
		multiplier = 1f;
	}

	public bool Update()
	{
		if (loseOverTime)
		{
			float num = ENT_Player.playerObject.curBuffs.GetBuff("buffTimeMult");
			if (!loseRateEffectedByPerks)
			{
				num = 0f;
			}
			float num2 = 1f / Mathf.Max(1f + num, 0.1f);
			buffTime -= Time.deltaTime * loseRate * num2;
		}
		foreach (Buff buff in buffs)
		{
			buff.amount = Mathf.Lerp(buff.maxAmount, 0f, 1f - buffTime);
		}
		if (buffTime < 0f)
		{
			return true;
		}
		return false;
	}

	public float GetMultiplier()
	{
		return multiplier;
	}

	public void SetMultiplier(float m)
	{
		multiplier = m;
	}

	public BuffContainer CopyBuffContainer()
	{
		BuffContainer buffContainer = new BuffContainer();
		buffContainer.id = id;
		buffContainer.buffs = new List<Buff>();
		buffContainer.buffs.AddRange(buffs);
		buffContainer.desc = desc;
		buffContainer.loseRate = loseRate;
		buffContainer.buffTime = buffTime;
		buffContainer.multiplier = multiplier;
		buffContainer.loseRateEffectedByPerks = loseRateEffectedByPerks;
		return buffContainer;
	}
}
