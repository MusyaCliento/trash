using System.Collections.Generic;
using UnityEngine;

public class PerkModule_Flight : PerkModule
{
	public BuffContainer buff;

	public BuffContainer debuff;

	public AnimationCurve debuffMultiplierCurve;

	public float debuffMultiplierDecayRate = 0.25f;

	public float flightBuildupTime = 0.5f;

	public float flightStartTime = 0.5f;

	public float flightStaminaDrainRate = 1f;

	public float flightDamageRate = 0.5f;

	public string flightDamageType = "";

	public float initialUpwardsBoost = 1f;

	public float minimumStamina = 2f;

	public float stopFlyStamina = 2f;

	private float holdTimer;

	public float flySpeed = 1f;

	public float ySinFrequency = 1f;

	public float ySinAmplitude;

	public float ySinOffset;

	private float buffMultiplier;

	private float debuffMultiplier;

	private BuffContainer currentBuff;

	private BuffContainer currentDebuff;

	[SerializeReference]
	public PerkModule_HandEffect handEffectModule;

	public GameObject flightEffectPrefab;

	private GameObject spawnedEffectObject;

	private Animator flightEffectAnimator;

	public AudioClip flightStartClip;

	public AudioClip flightEndClip;

	private bool isFlying;

	private float flightTime;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
		if (this.buff.id != "")
		{
			currentBuff = perk.player.curBuffs.GetBuffContainer(this.buff.id);
		}
		if (debuff.id != "")
		{
			currentDebuff = perk.player.curBuffs.GetBuffContainer(debuff.id);
		}
		if (currentBuff == null)
		{
			perk.player.curBuffs.AddBuff(this.buff);
			currentBuff = perk.player.curBuffs.GetBuffContainer(this.buff.id);
		}
		if (currentDebuff == null)
		{
			perk.player.curBuffs.AddBuff(debuff);
			currentDebuff = perk.player.curBuffs.GetBuffContainer(debuff.id);
		}
		BuffContainer.Buff buff = new BuffContainer.Buff();
		buff.id = "flight";
		buff.amount = 1f;
		buff.maxAmount = 1f;
		currentBuff.buffs.Add(buff);
		currentBuff.SetMultiplier(1f * buffMultiplier);
		currentDebuff.SetMultiplier(1f * debuffMultiplier);
		if (flightEffectPrefab != null)
		{
			spawnedEffectObject = Object.Instantiate(flightEffectPrefab, null);
			flightEffectAnimator = spawnedEffectObject.GetComponent<Animator>();
		}
		handEffectModule.Initialize(p, firstTime);
	}

	public override void OnDestroy(Perk p)
	{
		perk.player.curBuffs.RemoveBuffContainer(buff.id);
		handEffectModule.OnDestroy(p);
		base.OnDestroy(p);
	}

	public override void Update()
	{
		base.Update();
		handEffectModule.Update();
		bool flag = isFlying;
		bool flag2 = false;
		bool flag3 = false;
		if (spawnedEffectObject != null)
		{
			spawnedEffectObject.transform.position = ENT_Player.GetPlayer().cam.transform.position;
			spawnedEffectObject.transform.rotation = ENT_Player.GetPlayer().cam.transform.rotation;
		}
		ENT_Player.Hand[] hands = perk.player.hands;
		foreach (ENT_Player.Hand obj in hands)
		{
			if (obj.GetGripStrength() > stopFlyStamina)
			{
				flag2 = true;
			}
			if (obj.GetGripStrength() > minimumStamina)
			{
				flag3 = true;
			}
		}
		if (InputManager.GetButton("Jump").Pressed)
		{
			holdTimer = Mathf.Min(holdTimer + Time.deltaTime, flightBuildupTime);
		}
		else
		{
			holdTimer = Mathf.Max(holdTimer - Time.deltaTime, 0f);
		}
		if (InputManager.GetButton("Jump").Pressed && flag2)
		{
			if (holdTimer >= flightBuildupTime && (flag3 || isFlying))
			{
				Vector3 zero = Vector3.zero;
				if (flightTime > flightStartTime)
				{
					zero += perk.player.cam.transform.forward * flySpeed * Time.deltaTime;
					zero += perk.player.cam.transform.up * (Mathf.Sin(Time.time * ySinFrequency + ySinOffset) * ySinAmplitude) * Time.deltaTime;
					perk.player.DamageGripStrength(flightStaminaDrainRate * Time.deltaTime);
					perk.player.Damage(Damageable.DamageInfo.CreateDamageInfo(flightDamageRate * Time.deltaTime, flightDamageType, new List<string> { "NoEffects" }));
				}
				else
				{
					perk.player.DamageGripStrength(flightStaminaDrainRate * Time.deltaTime * 0.5f);
					perk.player.Damage(Damageable.DamageInfo.CreateDamageInfo(flightDamageRate * Time.deltaTime * 0.5f, flightDamageType, new List<string> { "NoEffects" }));
				}
				if (!isFlying)
				{
					zero += Vector3.up * initialUpwardsBoost;
					AudioManager.PlaySound(flightStartClip, perk.player.transform, 0.4f);
				}
				perk.player.AddForce(zero);
				isFlying = true;
			}
		}
		else if (!flag2 && isFlying)
		{
			perk.player.DamageGripStrength(3f);
			perk.player.Damage(Damageable.DamageInfo.CreateDamageInfo(0.5f, "rho"));
			isFlying = false;
		}
		else
		{
			isFlying = false;
		}
		if (InputManager.GetButton("Jump").Up)
		{
			isFlying = false;
		}
		if (isFlying)
		{
			flightTime += Time.deltaTime;
			currentBuff.multiplier = 1f;
			debuffMultiplier = Mathf.Lerp(debuffMultiplier, 1f, Time.deltaTime * 0.5f);
			currentDebuff.multiplier = 0f;
			handEffectModule.active = true;
			if (flightEffectAnimator != null)
			{
				flightEffectAnimator.SetBool("Flying", value: true);
			}
			return;
		}
		flightTime = 0f;
		if (flag)
		{
			AudioManager.PlaySound(flightEndClip, perk.player.transform, 0.4f);
		}
		currentBuff.multiplier = 0f;
		debuffMultiplier = Mathf.Lerp(debuffMultiplier, 0f, Time.deltaTime * debuffMultiplierDecayRate);
		currentDebuff.multiplier = debuffMultiplierCurve.Evaluate(debuffMultiplier);
		handEffectModule.active = false;
		if (flightEffectAnimator != null)
		{
			flightEffectAnimator.SetBool("Flying", value: false);
		}
	}
}
