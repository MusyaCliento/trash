using System;
using System.Collections.Generic;
using UnityEngine;

public class PerkModule_InjuryController : PerkModule
{
	[Serializable]
	public class InjuryType
	{
		[Serializable]
		public struct InjuryTier
		{
			public string basePerkID;

			public List<Perk> injuryPerks;
		}

		public string id;

		public float chance = 1f;

		public List<string> damageTags;

		public List<Perk> baseInjuryPerks;

		public List<InjuryTier> injuryTiers;

		public int maxInjuries = 1;

		public bool killOnMaxInjuries;

		public float audioVolume = 0.5f;

		public List<AudioClip> injurySounds;

		public List<AudioClip> injuryAvoidSounds;

		private List<Perk> appliedPerks = new List<Perk>();

		public void GetInjury()
		{
			if (chance < UnityEngine.Random.value)
			{
				if (injuryAvoidSounds != null && injuryAvoidSounds.Count > 0)
				{
					AudioManager.PlaySound(injuryAvoidSounds[UnityEngine.Random.Range(0, injuryAvoidSounds.Count)], ENT_Player.GetPlayer().transform.position, audioVolume);
				}
				return;
			}
			int num = 0;
			Perk perk = baseInjuryPerks[UnityEngine.Random.Range(0, baseInjuryPerks.Count)];
			foreach (Perk appliedPerk in appliedPerks)
			{
				foreach (Perk baseInjuryPerk in baseInjuryPerks)
				{
					if (appliedPerk.id == baseInjuryPerk.id)
					{
						num += appliedPerk.GetStackAmount();
					}
				}
				foreach (InjuryTier injuryTier in injuryTiers)
				{
					foreach (Perk injuryPerk in injuryTier.injuryPerks)
					{
						if (appliedPerk.id == injuryPerk.id)
						{
							num += appliedPerk.GetStackAmount();
						}
					}
				}
			}
			if (injurySounds != null && injurySounds.Count > 0)
			{
				AudioManager.PlaySound(injurySounds[UnityEngine.Random.Range(0, injurySounds.Count)], ENT_Player.GetPlayer().transform.position, audioVolume);
			}
			if (num >= maxInjuries && killOnMaxInjuries)
			{
				ENT_Player.GetPlayer().Kill("injury");
			}
			else
			{
				if (num >= maxInjuries)
				{
					return;
				}
				if (ENT_Player.GetPlayer().HasPerk(perk.id))
				{
					foreach (InjuryTier injuryTier2 in injuryTiers)
					{
						if (injuryTier2.basePerkID == perk.id)
						{
							ENT_Player.GetPlayer().RemovePerk(perk.id);
							Perk perk2 = ENT_Player.GetPlayer().AddPerk(injuryTier2.injuryPerks[UnityEngine.Random.Range(0, injuryTier2.injuryPerks.Count)]);
							appliedPerks.Add(perk2);
							perk2._OnPerkDestroy = (Action<Perk>)Delegate.Combine(perk2._OnPerkDestroy, new Action<Perk>(RemovePerk));
							break;
						}
					}
					return;
				}
				if (num > 0)
				{
					appliedPerks[0].AddStack();
					return;
				}
				Perk perk3 = ENT_Player.GetPlayer().AddPerk(perk);
				appliedPerks.Add(perk3);
				perk3._OnPerkDestroy = (Action<Perk>)Delegate.Combine(perk3._OnPerkDestroy, new Action<Perk>(RemovePerk));
			}
		}

		private void RemovePerk(Perk p)
		{
			if (appliedPerks == null || !appliedPerks.Contains(p))
			{
				return;
			}
			for (int num = appliedPerks.Count - 1; num >= 0; num--)
			{
				if (appliedPerks[num].id == p.id)
				{
					appliedPerks.RemoveAt(num);
				}
			}
		}
	}

	public List<InjuryType> injuryTypes;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
		ENT_Player player = perk.player;
		player._OnDamage = (Action<Damageable.DamageInfo>)Delegate.Combine(player._OnDamage, new Action<Damageable.DamageInfo>(OnPlayerTakeDamage));
	}

	public override void OnDestroy(Perk p)
	{
		if (perk != null && perk.player != null)
		{
			ENT_Player player = perk.player;
			player._OnDamage = (Action<Damageable.DamageInfo>)Delegate.Remove(player._OnDamage, new Action<Damageable.DamageInfo>(OnPlayerTakeDamage));
		}
		base.OnDestroy(p);
	}

	public void OnPlayerTakeDamage(Damageable.DamageInfo info)
	{
		foreach (string tag in info.tags)
		{
			Debug.Log("Player has taken damage: " + tag);
		}
		foreach (InjuryType injuryType in injuryTypes)
		{
			if (info.HasTagInList(injuryType.damageTags) || injuryType.damageTags.Contains(info.type))
			{
				injuryType.GetInjury();
			}
		}
	}
}
