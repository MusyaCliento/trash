using System;
using System.Collections.Generic;
using UnityEngine;

public class PerkModule_DamagePlayerOnAction : PerkModule
{
	public enum DamageAction
	{
		Jump = 0,
		GroundJump = 1,
		HangJump = 2,
		Crouch = 3,
		Grab = 4,
		Land = 5,
		Eat = 6
	}

	public DamageAction damageAction;

	public float amount;

	public string damageType;

	public float staminaDamage;

	public float perHandStaminaDamage;

	public int perHandRequiredID;

	public float minimumPlayerHealth;

	public float minimumPlayerStamina;

	public List<AudioClip> damageAudioClips;

	public float volume = 1f;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
		ENT_Player player = perk.player;
		if (player == null)
		{
			player = ENT_Player.GetPlayer();
		}
		if (damageAction == DamageAction.Jump)
		{
			ENT_Player eNT_Player = player;
			eNT_Player._OnJump = (Action)Delegate.Combine(eNT_Player._OnJump, new Action(Damage));
		}
		else if (damageAction == DamageAction.HangJump)
		{
			if (perHandRequiredID != -1)
			{
				ENT_Player eNT_Player2 = player;
				eNT_Player2._OnHandJump = (Action<ENT_Player.Hand>)Delegate.Combine(eNT_Player2._OnHandJump, new Action<ENT_Player.Hand>(Damage));
			}
			else
			{
				ENT_Player eNT_Player3 = player;
				eNT_Player3._OnClimbJump = (Action)Delegate.Combine(eNT_Player3._OnClimbJump, new Action(Damage));
			}
		}
		else if (damageAction == DamageAction.GroundJump)
		{
			ENT_Player eNT_Player4 = player;
			eNT_Player4._OnGroundedJump = (Action)Delegate.Combine(eNT_Player4._OnGroundedJump, new Action(Damage));
		}
		else if (damageAction == DamageAction.Land)
		{
			ENT_Player eNT_Player5 = player;
			eNT_Player5._OnLand = (Action)Delegate.Combine(eNT_Player5._OnLand, new Action(Damage));
		}
		else if (damageAction == DamageAction.Eat)
		{
			ENT_Player eNT_Player6 = player;
			eNT_Player6._OnEat = (Action<string>)Delegate.Combine(eNT_Player6._OnEat, new Action<string>(Damage));
		}
		else if (damageAction == DamageAction.Grab)
		{
			ENT_Player eNT_Player7 = player;
			eNT_Player7._OnHandGrab = (Action<ENT_Player.Hand>)Delegate.Combine(eNT_Player7._OnHandGrab, new Action<ENT_Player.Hand>(Damage));
		}
	}

	public override void OnDestroy(Perk p)
	{
		base.OnDestroy(p);
		ENT_Player player = ENT_Player.GetPlayer();
		if (!(player == null))
		{
			if (damageAction == DamageAction.Jump)
			{
				player._OnJump = (Action)Delegate.Remove(player._OnJump, new Action(Damage));
			}
			else if (damageAction == DamageAction.HangJump)
			{
				player._OnClimbJump = (Action)Delegate.Remove(player._OnClimbJump, new Action(Damage));
				player._OnHandJump = (Action<ENT_Player.Hand>)Delegate.Remove(player._OnHandJump, new Action<ENT_Player.Hand>(Damage));
			}
			else if (damageAction == DamageAction.GroundJump)
			{
				player._OnGroundedJump = (Action)Delegate.Remove(player._OnGroundedJump, new Action(Damage));
			}
			else if (damageAction == DamageAction.Land)
			{
				player._OnLand = (Action)Delegate.Remove(player._OnLand, new Action(Damage));
			}
			else if (damageAction == DamageAction.Eat)
			{
				player._OnEat = (Action<string>)Delegate.Remove(player._OnEat, new Action<string>(Damage));
			}
			else if (damageAction == DamageAction.Grab)
			{
				player._OnHandGrab = (Action<ENT_Player.Hand>)Delegate.Remove(player._OnHandGrab, new Action<ENT_Player.Hand>(Damage));
			}
		}
	}

	public void Damage()
	{
		bool flag = false;
		if (perk.player.health > minimumPlayerHealth && perk.player.GetLowestGripStrength() > minimumPlayerStamina)
		{
			flag = true;
		}
		if (flag)
		{
			if (amount != 0f)
			{
				perk.player.Damage(Damageable.DamageInfo.CreateDamageInfo(amount, damageType));
			}
			if (staminaDamage > 0f)
			{
				perk.player.DamageGripStrength(staminaDamage);
			}
		}
		if (damageAudioClips != null && damageAudioClips.Count > 0)
		{
			AudioManager.PlaySound(damageAudioClips[UnityEngine.Random.Range(0, damageAudioClips.Count)], perk.player.transform.position, volume, 1f, 0.3f);
		}
	}

	public void Damage(ENT_Player.Hand h)
	{
		if (perHandRequiredID == -1 || h.id == perHandRequiredID)
		{
			h?.DamageGripStrength(perHandStaminaDamage);
			Damage();
		}
	}

	public void Damage(string s)
	{
		Damage();
	}
}
