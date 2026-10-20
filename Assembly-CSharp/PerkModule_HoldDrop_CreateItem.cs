using System.Collections.Generic;
using UnityEngine;

public class PerkModule_HoldDrop_CreateItem : PerkModule_HoldDrop
{
	public float holdTimeRequirement = 5f;

	public float minimumStamina = 5f;

	public float recoveryWait = 10f;

	public List<AudioClip> growClips;

	public List<AudioClip> cannotGrowClips;

	private float[] holdTime = new float[2];

	private float[] recoveryTime = new float[2];

	public Item_Object item;

	public float restoreGrip;

	public float damage;

	public bool useBuff;

	public BuffContainer buff;

	private BuffContainer currentBuff;

	private float currentMultiplier;

	public float buffDecayRate = 1f;

	public List<Sprite> holdBackgroundSprites;

	public List<Sprite> holdForegroundSprites;

	private bool[] holding = new bool[2];

	public GameObject spawnEffect;

	public bool useHoldAudio = true;

	private UT_AudioClipHandler.AudioSet createItemAudioSet;

	public AudioClip holdAudioClip;

	public string audioGroup;

	public string audioSet;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
		if (useHoldAudio)
		{
			createItemAudioSet = ENT_Player.GetPlayer().clipHandler.AddOrGetAudioSet(audioGroup, audioSet, createAudioEmitter: true);
			createItemAudioSet.loop = true;
			createItemAudioSet.clips.Add(holdAudioClip);
			createItemAudioSet.Play(0f);
		}
		if (useBuff)
		{
			if (buff.id != "")
			{
				currentBuff = perk.player.curBuffs.GetBuffContainer(buff.id);
			}
			if (currentBuff == null)
			{
				perk.player.curBuffs.AddBuff(buff);
				currentBuff = perk.player.curBuffs.GetBuffContainer(buff.id);
			}
			currentMultiplier = 0f;
			currentBuff.SetMultiplier(1f * currentMultiplier);
		}
	}

	public override void Update()
	{
		base.Update();
		if (useBuff)
		{
			currentBuff.SetMultiplier(currentMultiplier * (float)perk.GetStackAmount());
			currentMultiplier = Mathf.Max(0f, currentMultiplier - Time.deltaTime * buffDecayRate);
		}
		if (useHoldAudio)
		{
			float num = 0f;
			ENT_Player.Hand[] hands = perk.player.hands;
			foreach (ENT_Player.Hand hand in hands)
			{
				num = Mathf.Max(holdTime[hand.id] / holdTimeRequirement, num);
			}
			createItemAudioSet.SetVolume(num);
		}
		float num2 = Mathf.Max(recoveryTime[0], recoveryTime[1]);
		perk.SetBarValue(1f - num2 / recoveryWait);
	}

	public override void UpdateHand(ENT_Player.Hand hand)
	{
		base.UpdateHand(hand);
		if (!perk.player.IsLocked() && hand.IsFree())
		{
			if (InputManager.GetButton(hand.throwButton).Pressed && hand.GetGripStrength() > minimumStamina / 10f * hand.GetGripStrengthMax() && recoveryTime[hand.id] <= 0f)
			{
				if (!holding[hand.id])
				{
					holding[hand.id] = true;
				}
				holdTime[hand.id] = Mathf.Clamp(holdTime[hand.id] + Time.deltaTime, 0f, holdTimeRequirement);
				currentMultiplier = Mathf.Max(currentMultiplier, holdTime[hand.id] / holdTimeRequirement);
				hand.AddGripStrength(0f - Time.deltaTime);
				hand.ShakeHand(0.1f * Time.deltaTime * currentMultiplier);
				hand.SetCanInteract(b: false);
			}
			else
			{
				if (recoveryTime[hand.id] > 0f && InputManager.GetButton(hand.throwButton).Down)
				{
					AudioManager.PlaySound(cannotGrowClips[Random.Range(0, cannotGrowClips.Count)], perk.player.transform.position);
					perk.player.Damage(Damageable.DamageInfo.CreateDamageInfo(0.1f, "nonlethal"));
				}
				holdTime[hand.id] = Mathf.Clamp(holdTime[hand.id] - Time.deltaTime * 2f, 0f, holdTimeRequirement);
			}
		}
		if (holding[hand.id] && holdBackgroundSprites != null && holdBackgroundSprites.Count > 0)
		{
			int index = Mathf.Clamp(Mathf.FloorToInt(holdTime[hand.id] / holdTimeRequirement * (float)holdBackgroundSprites.Count), 0, holdBackgroundSprites.Count - 1);
			hand.SetSprite(holdBackgroundSprites[index], holdForegroundSprites[index]);
		}
		if (holding[hand.id] && holdTime[hand.id] == 0f)
		{
			holding[hand.id] = false;
			hand.SetCanInteract(b: true);
		}
		recoveryTime[hand.id] = Mathf.Clamp(recoveryTime[hand.id] - Time.deltaTime, 0f, recoveryWait);
		if (holdTime[hand.id] >= holdTimeRequirement)
		{
			GenerateItem(hand);
			holdTime[hand.id] = 0f;
		}
	}

	private void GenerateItem(ENT_Player.Hand hand)
	{
		Item clone = item.itemData.GetClone();
		Inventory.instance.AddItemToHand(clone, hand);
		hand.AddGripStrength(restoreGrip);
		hand.SetHandWait(1f);
		hand.SetRegenWait(10f);
		perk.player.Damage(Damageable.DamageInfo.CreateDamageInfo(damage, "nonlethal"));
		AudioManager.PlaySound(growClips[Random.Range(0, growClips.Count)], perk.player.transform.position);
		currentMultiplier = 1f;
		recoveryTime[hand.id] = recoveryWait;
		Item_Object item_Object = null;
		if (clone != null)
		{
			Object.Instantiate(spawnEffect, hand.handModel.position, hand.handModel.rotation, hand.handModel);
			item_Object = clone.GetDropObject();
		}
		ObjectTagger objectTagger = null;
		if (item_Object != null)
		{
			objectTagger = item_Object.GetTagger();
		}
		if (objectTagger != null)
		{
			objectTagger.AddTag("DontRemove");
		}
		hand.SetCanInteract(b: true);
	}

	public override void HoldDrop(ENT_Player.Hand hand)
	{
		base.HoldDrop(hand);
	}

	public override void OnDestroy(Perk p)
	{
		if (p != null && p.player != null)
		{
			if (useBuff)
			{
				p.player.curBuffs.RemoveBuffContainer(buff);
			}
			if (useHoldAudio)
			{
				createItemAudioSet.SetVolume(0f);
			}
			base.OnDestroy(p);
		}
	}
}
