using System.Collections.Generic;
using UnityEngine;

public class PerkModule_BuffFromInventory : PerkModule
{
	public enum TrackingCategory
	{
		Count = 0,
		Weight = 1
	}

	public string itemTag;

	public BuffContainer buff;

	public float buffMultiplier = 1f;

	public bool useCurve;

	public int curveMax = 10;

	public AnimationCurve itemCurve = AnimationCurve.Constant(0f, 1f, 1f);

	public bool includeHands;

	public bool includePouches;

	private BuffContainer currentBuff;

	public bool useCounterText;

	public string counterPrepend = "";

	public TrackingCategory tracking;

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
		float num = GetItemCount();
		if (useCurve)
		{
			num = itemCurve.Evaluate(num / (float)curveMax);
		}
		float num2 = Mathf.Max(perk.GetStackEvaluationMultiplier(), 1f);
		currentBuff.SetMultiplier(num * buffMultiplier * num2);
	}

	public float GetItemCount()
	{
		float num = 0f;
		List<Item> list = (string.IsNullOrWhiteSpace(itemTag) ? Inventory.instance.GetItems(checkBag: true, includeHands, includePouches) : Inventory.instance.GetItemsByTag(itemTag, checkBag: true, includeHands));
		if (tracking == TrackingCategory.Count)
		{
			num = list.Count;
		}
		if (tracking == TrackingCategory.Weight)
		{
			foreach (Item item in list)
			{
				num += Inventory.instance.CalculateItemWeight(item);
			}
		}
		return num;
	}

	public override void OnDestroy(Perk p)
	{
		if (perk.player != null)
		{
			perk.player.curBuffs.RemoveBuffContainer(buff.id);
		}
		base.OnDestroy(p);
	}

	public override float GetStatBuff(string key, bool total = false)
	{
		float num = 1f;
		if (perk != null && total)
		{
			_ = perk.stackAmount;
			num = Mathf.Max(perk.GetStackEvaluationMultiplier(), 1f);
		}
		float itemCount = GetItemCount();
		float num2 = 1f;
		if (useCurve)
		{
			num2 = itemCurve.Evaluate(itemCount / (float)curveMax);
		}
		if (key == "bfi_count")
		{
			return itemCount;
		}
		foreach (BuffContainer.Buff buff in buff.buffs)
		{
			if ("bfi_count_" + buff.id == key)
			{
				return buff.maxAmount * num2 * num * buffMultiplier;
			}
			if ("bfi_count_current_" + buff.id == key)
			{
				return buff.maxAmount * num2 * itemCount * num * buffMultiplier;
			}
		}
		return base.GetStatBuff(key);
	}

	public override string GetCounterString()
	{
		if (useCounterText)
		{
			float itemCount = GetItemCount();
			if (itemCount == 0f)
			{
				return "";
			}
			return counterPrepend + itemCount;
		}
		return "";
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
