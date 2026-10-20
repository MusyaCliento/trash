using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ObjectTagger))]
public class ENT_Hitbox : MonoBehaviour, Damageable, Hitbox, Blinkable
{
	[Serializable]
	public class HealthStateEvent
	{
		public string desc;

		public float targetHealthValue;

		public UnityEvent reachEvent;

		public bool hasReached;

		public void CheckEvent(ENT_Hitbox hitbox)
		{
			if (!hasReached && hitbox.health < targetHealthValue)
			{
				reachEvent.Invoke();
				hasReached = true;
			}
		}
	}

	public GameEntity entity;

	public UnityEvent damageEvent;

	public List<Damageable.DamageEffect> damageEffects;

	public float armorRating = 1f;

	public float nonEffectDamageMult = 1f;

	public bool armorAfterDestroy;

	public bool independentHealth;

	public float health = 3f;

	public float maxHealth = 3f;

	public bool killEntityOnDestroy;

	public UnityEvent onDamageHealthEvent;

	public UnityEvent onDestroyEvent;

	public List<HealthStateEvent> healthStateEvents;

	public bool canBlinkFrag = true;

	public UnityEvent onBlinkTeleportEvent;

	public List<string> passTags;

	private bool destroyed;

	private void Start()
	{
		if (entity != null)
		{
			GameEntity gameEntity = entity;
			gameEntity._OnDeath = (Action<GameEntity>)Delegate.Combine(gameEntity._OnDeath, new Action<GameEntity>(OnDeath));
		}
	}

	public virtual bool Damage(Damageable.DamageInfo info)
	{
		Debug.Log(base.name + " :: Damage Received: " + info.amount + " of type: " + info.type);
		ProcessDamageInfo(info);
		if (independentHealth)
		{
			bool flag = destroyed;
			if (!destroyed)
			{
				health -= info.amount;
				onDamageHealthEvent?.Invoke();
				if (health <= 0f)
				{
					onDestroyEvent?.Invoke();
					if (killEntityOnDestroy && entity != null)
					{
						entity.Kill("");
					}
					destroyed = true;
				}
			}
			foreach (HealthStateEvent healthStateEvent in healthStateEvents)
			{
				healthStateEvent.CheckEvent(this);
			}
			if (!flag || (flag && armorAfterDestroy))
			{
				info.amount /= armorRating;
			}
		}
		else
		{
			info.amount /= armorRating;
		}
		damageEvent?.Invoke();
		Debug.Log("Damaging! " + entity);
		if (entity == null)
		{
			return false;
		}
		return entity.Damage(info);
	}

	public void Damage(float amount)
	{
		Damageable.DamageInfo damageInfo = Damageable.DamageInfo.CreateDamageInfo(amount);
		damageInfo.position = base.transform.position;
		Damage(damageInfo);
	}

	public GameObject GetGameObject()
	{
		return entity.gameObject;
	}

	public GameEntity GetGameEntity()
	{
		return entity;
	}

	public virtual bool CanBlinkFrag()
	{
		return canBlinkFrag;
	}

	public virtual GameObject GetBlinkableGameObject()
	{
		return entity.gameObject;
	}

	public void OnDeath(GameEntity e)
	{
		base.gameObject.layer = entity.gameObject.layer;
		if (TryGetComponent<ObjectTagger>(out var component))
		{
			component.AddTag("Dead");
		}
	}

	internal void SetGameEntity(GameEntity e)
	{
		entity = e;
	}

	internal Damageable.DamageInfo ProcessDamageInfo(Damageable.DamageInfo info)
	{
		if (passTags != null)
		{
			if (info.tags == null)
			{
				info.tags = new List<string>();
			}
			info.tags.AddRange(passTags);
		}
		Damageable.DamageEffect damageEffectFromList = GetDamageEffectFromList(info);
		if (damageEffectFromList != null)
		{
			info.amount *= damageEffectFromList.damageMultiplier;
			damageEffectFromList.damageEvent.Invoke();
		}
		else
		{
			info.amount *= nonEffectDamageMult;
		}
		return info;
	}

	internal Damageable.DamageEffect GetDamageEffectFromList(Damageable.DamageInfo info)
	{
		if (damageEffects == null || damageEffects.Count == 0)
		{
			return null;
		}
		foreach (Damageable.DamageEffect damageEffect in damageEffects)
		{
			if (damageEffect.HasTag(info.tags))
			{
				return damageEffect;
			}
		}
		return null;
	}

	public void OnBlinkTeleport()
	{
		onBlinkTeleportEvent.Invoke();
	}
}
