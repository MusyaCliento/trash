using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SessionEventModule_AnnouncementSequence : SessionEventModule
{
	[Serializable]
	public class AnnouncerEvent
	{
		public string name;

		public float time;

		public AudioClip tone;

		public List<AudioClip> audioClips;

		internal bool hasBeenPlayed;
	}

	public List<AnnouncerEvent> announcements;

	private float timer;

	public override void Initialize(SessionEvent s)
	{
		timer = 0f;
		base.Initialize(s);
	}

	public override void Update()
	{
		timer += Time.deltaTime;
		base.Update();
		foreach (AnnouncerEvent announcement in announcements)
		{
			if (!announcement.hasBeenPlayed && timer > announcement.time)
			{
				announcement.hasBeenPlayed = true;
				AnnouncementController.instance.StartAnnouncement(announcement.audioClips[UnityEngine.Random.Range(0, announcement.audioClips.Count)], announcement.tone);
			}
		}
	}
}
