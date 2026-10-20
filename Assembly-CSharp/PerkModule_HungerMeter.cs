using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PerkModule_HungerMeter : PerkModule
{
	public List<string> consumeBuffIDs = new List<string> { "food" };

	public Image hungerMeterAsset;

	private Image hungerMeterObject;

	public BuffContainer buff;

	public BuffContainer debuff;

	private BuffContainer currentBuff;

	private BuffContainer currentDeBuff;

	public AnimationCurve buffCurve;

	public AnimationCurve debuffCurve;

	public float hungerMax = 1f;

	public float hungerMeter = 1f;

	public float hungerDecayRate = 0.01f;

	public float eatRecovery = 0.5f;

	public Color fullColor = Color.white;

	public Color emptyColor = Color.red;

	private float effectTimer;

	public List<AudioClip> hungerTickAudio;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
		ENT_Player player = ENT_Player.GetPlayer();
		player._OnEat = (Action<string>)Delegate.Combine(player._OnEat, new Action<string>(OnConsume));
		hungerMeterObject = UnityEngine.Object.Instantiate(hungerMeterAsset, CL_UIManager.instance.uiMeterLayoutRoot);
		if (buff.id != "")
		{
			currentBuff = perk.player.curBuffs.GetBuffContainer(buff.id);
			currentDeBuff = perk.player.curBuffs.GetBuffContainer(debuff.id);
		}
		if (currentBuff == null)
		{
			perk.player.curBuffs.AddBuff(buff);
			currentBuff = perk.player.curBuffs.GetBuffContainer(buff.id);
			perk.player.curBuffs.AddBuff(debuff);
			currentDeBuff = perk.player.curBuffs.GetBuffContainer(debuff.id);
		}
		currentBuff.SetMultiplier(1f);
		currentDeBuff.SetMultiplier(0f);
	}

	public override void Update()
	{
		if (perk.player.dead)
		{
			hungerMeter = hungerMax;
		}
		if (perk.player.IsInCutsceneMode() || perk.player.IsInteractionLocked())
		{
			return;
		}
		float num = hungerMeter / hungerMax;
		hungerMeter = Mathf.Clamp(hungerMeter - hungerDecayRate * Time.deltaTime, 0f, hungerMax);
		hungerMeterObject.material.SetFloat("_Amount", num);
		hungerMeterObject.color = Color.Lerp(emptyColor, fullColor, num * 2f);
		currentBuff.SetMultiplier(buffCurve.Evaluate(1f - num));
		currentDeBuff.SetMultiplier(debuffCurve.Evaluate(1f - num));
		effectTimer -= Time.deltaTime;
		if (!(effectTimer < 0f))
		{
			return;
		}
		effectTimer = 1.5f;
		if (num <= 0f)
		{
			DOTween.Complete(hungerMeterObject.transform);
			hungerMeterObject.transform.DOPunchScale(Vector3.one * 0.1f, 2f, 5, 0.1f);
			hungerMeterObject.transform.DOPunchRotation(Vector3.forward * 5f, 1f, 5);
			effectTimer = 1f;
			perk.player.Damage(Damageable.DamageInfo.CreateDamageInfo(0.3f, "hunger"));
			if ((hungerTickAudio != null) & (hungerTickAudio.Count > 0))
			{
				AudioManager.PlayUISound(hungerTickAudio[UnityEngine.Random.Range(0, hungerTickAudio.Count)], 0.6f, 1f + UnityEngine.Random.value * 0.1f);
			}
		}
		else
		{
			if (!(num < hungerMax / 3f))
			{
				return;
			}
			DOTween.Complete(hungerMeterObject.transform);
			hungerMeterObject.transform.DOPunchScale(Vector3.one * 0.1f, 2f, 5, 0.1f);
			hungerMeterObject.transform.DOPunchRotation(Vector3.forward * 5f, 1f, 5);
			if (num < hungerMax / 6f)
			{
				perk.player.Damage(Damageable.DamageInfo.CreateDamageInfo(0f, "hunger"));
				if ((hungerTickAudio != null) & (hungerTickAudio.Count > 0))
				{
					AudioManager.PlayUISound(hungerTickAudio[UnityEngine.Random.Range(0, hungerTickAudio.Count)], 0.2f, 1f + UnityEngine.Random.value * 0.1f);
				}
			}
			else if ((hungerTickAudio != null) & (hungerTickAudio.Count > 0))
			{
				AudioManager.PlayUISound(hungerTickAudio[UnityEngine.Random.Range(0, hungerTickAudio.Count)], 0.05f, 1f + UnityEngine.Random.value * 0.1f);
			}
		}
	}

	public override void OnDestroy(Perk p)
	{
		base.OnDestroy(p);
		if (hungerMeterObject != null)
		{
			UnityEngine.Object.Destroy(hungerMeterObject.gameObject);
		}
		ENT_Player player = ENT_Player.GetPlayer();
		if (player != null)
		{
			player._OnEat = (Action<string>)Delegate.Remove(player._OnEat, new Action<string>(OnConsume));
		}
		if (perk != null && perk.player != null)
		{
			perk.player.curBuffs.RemoveBuffContainer(buff.id);
			perk.player.curBuffs.RemoveBuffContainer(debuff.id);
		}
	}

	public void OnConsume(string type)
	{
		if (consumeBuffIDs.Contains(type))
		{
			hungerMeter = Mathf.Clamp(hungerMeter + eatRecovery, 0f, hungerMax);
			DOTween.Complete(hungerMeterObject.transform);
			hungerMeterObject.transform.DOPunchScale(Vector3.one * 0.15f, 2f, 5, 0.1f);
			hungerMeterObject.transform.DOPunchRotation(Vector3.forward * 10f, 1f, 5);
		}
	}
}
