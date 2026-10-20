using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HitEffectModule_PlaySound : HitEffectModule
{
	public bool playAudioAtPosition = true;

	public List<AudioClip> clips;

	public float volume;

	public override void OnHit(in Desc desc)
	{
		base.OnHit(in desc);
		if (playAudioAtPosition)
		{
			AudioManager.PlaySound(clips[UnityEngine.Random.Range(0, clips.Count)], desc.position, volume);
		}
		else
		{
			AudioManager.PlayUISound(clips[UnityEngine.Random.Range(0, clips.Count)], volume);
		}
	}
}
