using System;
using System.Collections.Generic;
using UnityEngine;

public class PerkModule_AutoConsumer : PerkModule
{
	public enum ConsumptionReason
	{
		stamina = 0,
		health = 1,
		death = 2
	}

	public ConsumptionReason consumptionReason;

	public string itemTag;

	public BuffContainer buff;

	public float restoreGrip;

	private BuffContainer currentBuff;

	private float currentMultiplier;

	public float buffDecayRate = 1f;

	public AudioClip consumeAudio;

	public float consumeShake;

	public bool invokeOnEat = true;

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
		currentBuff.SetMultiplier(0f);
		ENT_Player player = perk.player;
		player.preGripBrokenStamina = (Action<ENT_Player.Hand>)Delegate.Combine(player.preGripBrokenStamina, new Action<ENT_Player.Hand>(OnGripBroken));
	}

	private void OnGripBroken(ENT_Player.Hand hand)
	{
		if (consumptionReason == ConsumptionReason.stamina)
		{
			Consume();
		}
	}

	public override void Update()
	{
		base.Update();
		bool flag = false;
		if (consumptionReason == ConsumptionReason.stamina && perk.player.GetLowestGripStrength() < 0.2f)
		{
			flag = true;
		}
		if (flag)
		{
			Consume();
		}
		currentBuff.SetMultiplier(currentMultiplier);
		currentMultiplier = Mathf.Max(0f, currentMultiplier - Time.deltaTime * buffDecayRate);
	}

	private void Consume()
	{
		List<Item> itemsByTag = Inventory.instance.GetItemsByTag(itemTag);
		if (itemsByTag.Count > 0)
		{
			Inventory.instance.ClearItemFromInventory(itemsByTag[0]);
			if (restoreGrip > 0f)
			{
				perk.player.AddGripStrength(restoreGrip);
			}
			currentMultiplier = 1f;
			if (consumeAudio != null)
			{
				AudioManager.PlaySound(consumeAudio, perk.player.transform.position, 1f, 1f, 0.3f);
			}
			if (invokeOnEat)
			{
				ENT_Player.GetPlayer().OnEat("food");
			}
			CL_CameraControl.Shake(consumeShake);
		}
	}

	public override void OnDestroy(Perk p)
	{
		perk.player.curBuffs.RemoveBuffContainer(currentBuff.id);
		ENT_Player player = perk.player;
		player.preGripBrokenStamina = (Action<ENT_Player.Hand>)Delegate.Remove(player.preGripBrokenStamina, new Action<ENT_Player.Hand>(OnGripBroken));
		base.OnDestroy(p);
	}
}
