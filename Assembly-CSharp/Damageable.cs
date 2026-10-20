using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface Damageable
{
	[Serializable]
	public class DamageInfo
	{
		public float amount;

		public string type;

		public List<string> tags;

		public Vector3 position;

		public Vector3 force;

		public Vector3 direction;

		public GameEntity sourceEntity;

		public GameObject sourceObject;

		public Action onKill;

		public bool isLight;

		public float intensity = 1f;

		public BuffContainer hitBuffContainer;

		public bool hasKilled;

		public bool HasTag(string t)
		{
			if (type == t)
			{
				return true;
			}
			if (tags == null)
			{
				return false;
			}
			if (tags.Contains(t))
			{
				return true;
			}
			return false;
		}

		public bool HasTagInList(List<string> checkTags)
		{
			for (int i = 0; i < checkTags.Count; i++)
			{
				if (HasTag(checkTags[i]))
				{
					return true;
				}
			}
			return false;
		}

		public static DamageInfo CreateDamageInfo(float amount, string type = "")
		{
			DamageInfo damageInfo = new DamageInfo();
			damageInfo.amount = amount;
			damageInfo.type = type;
			damageInfo.tags = new List<string>();
			damageInfo.tags.Add(type);
			return damageInfo;
		}

		public static DamageInfo CreateDamageInfo(float amount, string type, List<string> tags, GameEntity sourceEntity = null)
		{
			DamageInfo damageInfo = CreateDamageInfo(amount, type);
			damageInfo.tags.AddRange(tags);
			damageInfo.sourceEntity = sourceEntity;
			damageInfo.position = ((sourceEntity != null) ? sourceEntity.transform.position : Vector3.zero);
			return damageInfo;
		}

		public static DamageInfo CreateDamageInfo(float amount, GameEntity sourceEntity, string type = "")
		{
			DamageInfo damageInfo = CreateDamageInfo(amount, type);
			damageInfo.sourceEntity = sourceEntity;
			damageInfo.position = ((sourceEntity != null) ? sourceEntity.transform.position : Vector3.zero);
			return damageInfo;
		}
	}

	[Serializable]
	public class DamageEffect
	{
		public string id;

		public List<string> requiredTags;

		public float damageMultiplier = 1f;

		public UnityEvent damageEvent;

		public bool HasTag(List<string> t)
		{
			if (requiredTags == null)
			{
				return false;
			}
			foreach (string item in t)
			{
				if (HasTag(item))
				{
					return true;
				}
			}
			return false;
		}

		public bool HasTag(string t)
		{
			if (requiredTags == null)
			{
				return false;
			}
			if (requiredTags.Contains(t))
			{
				return true;
			}
			return false;
		}
	}

	bool Damage(DamageInfo info);

	bool Damage(float amount)
	{
		DamageInfo info = DamageInfo.CreateDamageInfo(amount);
		return Damage(info);
	}

	GameObject GetGameObject();
}
