using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyModule_RadioEvent : BuddyModule
{
	public ENV_RadioStation station;

	public List<AudioClip> startClips;

	public List<AudioClip> endClips;

	public override void Initialize(DEN_Buddy b)
	{
		base.Initialize(b);
		buddy.StartCoroutine(RadioEventCoroutine());
		IEnumerator RadioEventCoroutine()
		{
			AudioClip audioClip = startClips[Random.Range(0, startClips.Count)];
			buddy.PlaySound(audioClip);
			yield return new WaitForSeconds(audioClip.length + 0.5f);
			audioClip = station.GetRandomTrack().trackClip;
			buddy.PlaySound(audioClip);
			yield return new WaitForSeconds(audioClip.length + 1f);
			audioClip = endClips[Random.Range(0, endClips.Count)];
			buddy.PlaySound(audioClip);
			yield return new WaitForSeconds(audioClip.length + 1f);
			buddy.ClearEvent();
		}
	}
}
