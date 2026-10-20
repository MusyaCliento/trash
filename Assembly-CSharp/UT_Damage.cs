using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UT_Damage : MonoBehaviour, Damageable
{
	[Serializable]
	public class DamageTiers
	{
		public float healthThreshold;

		public UnityEvent onEnterTier;

		public bool hasEntered;

		public AudioClip audioClip;
	}

	[Serializable]
	public class DamageSource
	{
		public List<string> sourceTypes;

		public float damageMult = 1f;

		public UnityEvent DamageEvent;

		public bool allowDamageEvent = true;
	}

	public enum KillType
	{
		hide = 0,
		destroy = 1,
		nothing = 2
	}

	public Action<float> DamageAction;

	public Action KillAction;

	public UnityEvent DamageEvent;

	public UnityEvent KillEvent;

	public float health = 1f;

	public float maxHealth = 1f;

	public float damageMult = 1f;

	public float minimumDamageThreshold;

	public List<DamageTiers> damageTiers = new List<DamageTiers>();

	public bool canDamage = true;

	public bool limitDamagePerFrame;

	public string hitParticle = "";

	public float hitParticleAmountMult = 1f;

	private bool dead;

	public List<DamageSource> damageSources;

	public KillType killType;

	private float lastDamageFrame = -1f;

	private float totalDamageInFrame;

	public bool Damage(Damageable.DamageInfo info)
	{
		if (!canDamage)
		{
			return false;
		}
		bool flag = false;
		if (hitParticle != "")
		{
			_ = info.position;
			FXManager.PlayParticle(hitParticle, info.position, Mathf.CeilToInt(25f * info.amount));
		}
		if (info.tags != null && info.tags.Contains("skipThreshhold"))
		{
			flag = true;
		}
		if (minimumDamageThreshold > 0f && !flag && info.amount < minimumDamageThreshold)
		{
			return false;
		}
		if (limitDamagePerFrame)
		{
			if ((float)Time.frameCount != lastDamageFrame)
			{
				totalDamageInFrame = 0f;
				lastDamageFrame = Time.frameCount;
			}
			if (info.amount > totalDamageInFrame)
			{
				info.amount -= totalDamageInFrame;
			}
			totalDamageInFrame = Mathf.Max(info.amount, totalDamageInFrame);
		}
		bool flag2 = true;
		foreach (DamageSource damageSource in damageSources)
		{
			bool flag3 = false;
			if (damageSource.sourceTypes.Contains(info.type))
			{
				flag3 = true;
			}
			else
			{
				foreach (string tag in info.tags)
				{
					if (damageSource.sourceTypes.Contains(tag))
					{
						flag3 = true;
						break;
					}
				}
			}
			if (flag3)
			{
				info.amount *= damageSource.damageMult * damageMult;
				damageSource.DamageEvent.Invoke();
				if (!damageSource.allowDamageEvent)
				{
					flag2 = false;
				}
				break;
			}
		}
		foreach (DamageTiers damageTier in damageTiers)
		{
			if (!damageTier.hasEntered && health - info.amount <= damageTier.healthThreshold)
			{
				damageTier.hasEntered = true;
				damageTier.onEnterTier.Invoke();
				if (damageTier.audioClip != null)
				{
					AudioManager.PlaySound(damageTier.audioClip, base.transform.position);
				}
			}
		}
		if (DamageAction != null)
		{
			DamageAction(info.amount);
		}
		if (flag2)
		{
			DamageEvent.Invoke();
		}
		if (maxHealth > 0f)
		{
			health -= info.amount;
			if (health <= 0f && !dead)
			{
				dead = true;
				Kill();
				return true;
			}
			return false;
		}
		return false;
	}

	public void Damage(float amount)
	{
		Damageable.DamageInfo info = Damageable.DamageInfo.CreateDamageInfo(amount);
		Damage(info);
	}

	public void DamageSkipThreshhold(float amount)
	{
		Damageable.DamageInfo damageInfo = Damageable.DamageInfo.CreateDamageInfo(amount);
		if (damageInfo.tags == null)
		{
			damageInfo.tags = new List<string>();
		}
		damageInfo.tags.Add("skipThreshhold");
		Damage(damageInfo);
	}

	public void Kill()
	{
		KillEvent.Invoke();
		if (KillAction != null)
		{
			KillAction();
		}
		switch (killType)
		{
		case KillType.hide:
			base.gameObject.SetActive(value: false);
			break;
		case KillType.destroy:
			UnityEngine.Object.Destroy(base.gameObject);
			break;
		}
	}

	public void ResetHealth()
	{
		health = maxHealth;
		dead = false;
		foreach (DamageTiers damageTier in damageTiers)
		{
			damageTier.hasEntered = false;
		}
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public void SetDamageable(bool b)
	{
		canDamage = b;
	}
}
