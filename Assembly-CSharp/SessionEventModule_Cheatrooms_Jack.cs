using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SessionEventModule_Cheatrooms_Jack : SessionEventModule
{
	[Serializable]
	public class Jack_AnnouncerEvent
	{
		public string name;

		public AudioClip tone;

		public List<AudioClip> audioClips;

		internal bool hasBeenPlayed;

		public string eventCommand;
	}

	[Serializable]
	public class Jack_AnnouncementPeriod
	{
		public int currentEvent;

		public List<Jack_AnnouncerEvent> announcements;

		public float announcementTimeMin = 20f;

		public float announcementTimeMax = 20f;

		public float startTime;
	}

	public List<Jack_AnnouncementPeriod> announcements;

	public float startTimer = 60f;

	private int currentAnnouncementSet;

	private float timer;

	private float announcementTimer = 20f;

	public GameObject chaserAsset;

	public override void Initialize(SessionEvent s)
	{
		timer = 0f;
		currentAnnouncementSet = 0;
		announcementTimer = startTimer;
		base.Initialize(s);
		Debug.Log("Jack has entered the building.");
	}

	public override void Update()
	{
		timer += Time.deltaTime;
		base.Update();
		if (announcements.Count > currentAnnouncementSet + 1 && announcements[currentAnnouncementSet + 1].startTime < timer)
		{
			currentAnnouncementSet++;
		}
		announcementTimer -= Time.deltaTime;
		if (announcementTimer <= 0f)
		{
			announcements[currentAnnouncementSet].currentEvent++;
			if (announcements[currentAnnouncementSet].currentEvent >= announcements[currentAnnouncementSet].announcements.Count)
			{
				announcements[currentAnnouncementSet].currentEvent = 0;
			}
			Jack_AnnouncerEvent jack_AnnouncerEvent = announcements[currentAnnouncementSet].announcements[announcements[currentAnnouncementSet].currentEvent];
			AnnouncementController.instance.StartAnnouncement(jack_AnnouncerEvent.audioClips[UnityEngine.Random.Range(0, jack_AnnouncerEvent.audioClips.Count)], null, force: true);
			announcementTimer = UnityEngine.Random.Range(announcements[currentAnnouncementSet].announcementTimeMin, announcements[currentAnnouncementSet].announcementTimeMax);
			if (jack_AnnouncerEvent.eventCommand == "end")
			{
				WorldLoader.instance.StartCoroutine(WaitAndKillPlayer());
			}
		}
		IEnumerator WaitAndKillPlayer()
		{
			yield return new WaitForSeconds(15f);
			UnityEngine.Object.Instantiate(chaserAsset, ENT_Player.playerObject.transform.position + Vector3.up * -40f, Quaternion.identity);
			CL_GameManager.SetGameFlag("jackkill", state: true, "", save: true);
			sessionEvent.StopEvent();
		}
	}

	public override void OnModuleDestroy()
	{
		base.OnModuleDestroy();
		Debug.Log("Jack has left the room");
	}
}
