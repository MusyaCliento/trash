using System;
using System.Collections.Generic;
using UnityEngine;

public class PerkModule_PlayerPlaySoundOnEvent : PerkModule
{
	public enum SoundAction
	{
		Jump = 0,
		GroundJump = 1,
		HangJump = 2,
		Crouch = 3,
		Grab = 4,
		Land = 5,
		Eat = 6,
		Rest = 7
	}

	public List<AudioClip> audioClips;

	public SoundAction playerAction;

	public float volume = 1f;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
		ENT_Player player = perk.player;
		if (player == null)
		{
			player = ENT_Player.GetPlayer();
		}
		if (playerAction == SoundAction.Jump)
		{
			ENT_Player eNT_Player = player;
			eNT_Player._OnJump = (Action)Delegate.Combine(eNT_Player._OnJump, new Action(PlaySound));
		}
		else if (playerAction == SoundAction.HangJump)
		{
			ENT_Player eNT_Player2 = player;
			eNT_Player2._OnClimbJump = (Action)Delegate.Combine(eNT_Player2._OnClimbJump, new Action(PlaySound));
		}
		else if (playerAction == SoundAction.GroundJump)
		{
			ENT_Player eNT_Player3 = player;
			eNT_Player3._OnGroundedJump = (Action)Delegate.Combine(eNT_Player3._OnGroundedJump, new Action(PlaySound));
		}
		else if (playerAction == SoundAction.Land)
		{
			ENT_Player eNT_Player4 = player;
			eNT_Player4._OnLand = (Action)Delegate.Combine(eNT_Player4._OnLand, new Action(PlaySound));
		}
		else if (playerAction == SoundAction.Eat)
		{
			ENT_Player eNT_Player5 = player;
			eNT_Player5._OnEat = (Action<string>)Delegate.Combine(eNT_Player5._OnEat, new Action<string>(PlaySound));
		}
		else if (playerAction == SoundAction.Grab)
		{
			ENT_Player eNT_Player6 = player;
			eNT_Player6._OnHandGrab = (Action<ENT_Player.Hand>)Delegate.Combine(eNT_Player6._OnHandGrab, new Action<ENT_Player.Hand>(PlaySound));
		}
		else if (playerAction == SoundAction.Rest)
		{
			ENT_Player eNT_Player7 = player;
			eNT_Player7._OnClimbRest = (Action)Delegate.Combine(eNT_Player7._OnClimbRest, new Action(PlaySound));
		}
	}

	public override void OnDestroy(Perk p)
	{
		base.OnDestroy(p);
		ENT_Player player = ENT_Player.GetPlayer();
		if (!(player == null))
		{
			if (playerAction == SoundAction.Jump)
			{
				player._OnJump = (Action)Delegate.Remove(player._OnJump, new Action(PlaySound));
			}
			else if (playerAction == SoundAction.HangJump)
			{
				player._OnClimbJump = (Action)Delegate.Remove(player._OnClimbJump, new Action(PlaySound));
			}
			else if (playerAction == SoundAction.GroundJump)
			{
				player._OnGroundedJump = (Action)Delegate.Remove(player._OnGroundedJump, new Action(PlaySound));
			}
			else if (playerAction == SoundAction.Land)
			{
				player._OnLand = (Action)Delegate.Remove(player._OnLand, new Action(PlaySound));
			}
			else if (playerAction == SoundAction.Eat)
			{
				player._OnEat = (Action<string>)Delegate.Remove(player._OnEat, new Action<string>(PlaySound));
			}
			else if (playerAction == SoundAction.Grab)
			{
				player._OnHandGrab = (Action<ENT_Player.Hand>)Delegate.Remove(player._OnHandGrab, new Action<ENT_Player.Hand>(PlaySound));
			}
		}
	}

	public void PlaySound()
	{
		AudioManager.PlaySound(audioClips[UnityEngine.Random.Range(0, audioClips.Count)], perk.player.transform.position, volume);
	}

	public void PlaySound(ENT_Player.Hand h)
	{
		PlaySound();
	}

	public void PlaySound(string s)
	{
		PlaySound();
	}
}
