using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyModule_SpeakToPlayer : BuddyModule
{
	public List<AudioClip> speakClips;

	public bool flyToPlayer = true;

	public override void Initialize(DEN_Buddy b)
	{
		base.Initialize(b);
		b.StartCoroutine(MoveToPlayer());
	}

	private IEnumerator MoveToPlayer()
	{
		bool isHanging = buddy.IsHanging();
		if (flyToPlayer)
		{
			buddy.SetHangoutState(b: false);
			buddy.SetTarget(ENT_Player.playerObject.transform);
			buddy.SetLookForTarget(b: true);
			yield return new WaitForSeconds(5f);
		}
		AudioClip audioClip = speakClips[Random.Range(0, speakClips.Count)];
		buddy.PlaySound(audioClip);
		yield return new WaitForSeconds(audioClip.length);
		if (flyToPlayer)
		{
			buddy.SetHangoutState(isHanging);
		}
		buddy.ClearEvent();
	}

	public override void Update()
	{
		base.Update();
	}
}
