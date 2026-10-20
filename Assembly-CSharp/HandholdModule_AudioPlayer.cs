using System.Collections.Generic;
using UnityEngine;

public class HandholdModule_AudioPlayer : HandholdModule
{
	public List<AudioClip> grabSounds;

	public List<AudioClip> releaseSounds;

	public List<AudioClip> jumpSounds;

	public float volume = 1f;

	public AudioSource audioSource;

	public override void OnGrab(ENT_Player p, ENT_Player.Hand hand, Clickable.InteractionInfo info = null)
	{
		base.OnGrab(p, hand, info);
		PlaySound(ref grabSounds);
	}

	public override void OnRelease(ENT_Player p, ENT_Player.Hand hand)
	{
		base.OnRelease(p, hand);
		PlaySound(ref releaseSounds);
	}

	public override void OnJump(ENT_Player p, ENT_Player.Hand hand, bool hasJumped)
	{
		base.OnJump(p, hand, hasJumped);
		if (!hasJumped)
		{
			PlaySound(ref jumpSounds);
		}
	}

	private void PlaySound(ref List<AudioClip> clips)
	{
		if (clips != null && clips.Count > 0 && handhold != null && handhold.transform != null)
		{
			if (audioSource != null)
			{
				audioSource.clip = clips[Random.Range(0, clips.Count)];
			}
			else
			{
				AudioManager.PlaySound(clips[Random.Range(0, clips.Count)], handhold.transform.position, volume);
			}
		}
	}
}
