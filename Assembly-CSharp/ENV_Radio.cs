using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ENV_Radio : MonoBehaviour
{
	public class RadioController
	{
		public List<ENV_RadioStation.RadioTrack> trackList;

		private int currentTrackID;

		public ENV_RadioStation radioStation;

		public void RecieveStation(ENV_RadioStation station)
		{
			radioStation = station;
		}

		public void GetCurrentTrack(float worldTime, out AudioClip clip, out float clipTime)
		{
			radioStation.GetCurrentTrackClip(out clip, out clipTime);
		}
	}

	public bool playOnStart = true;

	public bool useRadioStation;

	public AudioClip radioClip;

	public ENV_RadioStation radioStation;

	public bool randomTrackEachPlay;

	public UnityEvent toggleOnEvent;

	public UnityEvent toggleOffEvent;

	public UnityEvent toggleEvent;

	public AudioSource aud;

	private ENV_RadioStation.RadioTrack currentTrack;

	public bool loop = true;

	public string subtitleOnPlay = "";

	private void Start()
	{
		aud.loop = loop;
		if (playOnStart)
		{
			Play();
		}
	}

	public void Play()
	{
		if (useRadioStation)
		{
			if (currentTrack == null || randomTrackEachPlay)
			{
				currentTrack = radioStation.GetRandomTrack();
			}
			aud.clip = currentTrack.trackClip;
		}
		else
		{
			aud.clip = radioClip;
		}
		if (subtitleOnPlay != "")
		{
			AnnouncementController.instance.ResetAnnouncementTimer();
			AnnouncementController.instance.StopAnnouncement();
			CL_UIManager.ShowSubtitle(CL_LocalizationManager.currentLocalization.GetLine("recordings", subtitleOnPlay));
		}
		aud.Play();
		toggleOnEvent.Invoke();
	}

	public void Stop()
	{
		aud.Stop();
		toggleOffEvent.Invoke();
	}

	public void Toggle()
	{
		toggleEvent.Invoke();
		if (aud.isPlaying)
		{
			Stop();
		}
		else
		{
			Play();
		}
	}

	public void SetStation(ENV_RadioStation station)
	{
		radioStation = station;
		currentTrack = radioStation.GetRandomTrack();
		aud.clip = currentTrack.trackClip;
		Play();
	}
}
