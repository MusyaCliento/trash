using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SessionEventModule_AnnouncementPlayer : SessionEventModule
{
	public AudioClip tone;

	public List<AudioClip> audioClips;

	public override void Initialize(SessionEvent s)
	{
		base.Initialize(s);
		Activate();
	}

	public override void Activate()
	{
		AnnouncementController.instance.StartAnnouncement(audioClips[UnityEngine.Random.Range(0, audioClips.Count)], tone);
		base.Activate();
	}
}
