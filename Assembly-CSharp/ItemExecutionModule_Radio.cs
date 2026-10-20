using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemExecutionModule_Radio : ItemExecutionModule
{
	public bool isPlaying = true;

	public AudioSource audioSource;

	public AudioSource staticAudioSource;

	public AudioClip changeStationClip;

	public AudioClip changeTrackClip;

	public ENV_RadioStation currentStation;

	public bool findRandomStation = true;

	private ENV_Radio.RadioController radioController;

	private bool detuned;

	private float curQuality = 1f;

	private bool hasBeenDestroyed;

	private float resumeTime;

	public override void Initialize(Item i)
	{
		if (audioSource != null)
		{
			audioSource.transform.parent = null;
		}
		radioController = new ENV_Radio.RadioController();
		if (findRandomStation && ENV_RadioStation.GetLocalRadioStations().Count > 0)
		{
			ENV_RadioStation eNV_RadioStation = ENV_RadioStation.GetLocalRadioStations()[0];
			if (eNV_RadioStation != null)
			{
				currentStation = eNV_RadioStation;
			}
		}
		if (staticAudioSource != null && !staticAudioSource.isPlaying)
		{
			staticAudioSource.Play();
			staticAudioSource.volume = 0f;
		}
		radioController.RecieveStation(currentStation);
		base.Initialize(i);
	}

	public override void Execute()
	{
		if (item == null || item.GetDropObject() == null)
		{
			return;
		}
		if (audioSource == null)
		{
			audioSource = item.GetDropObject().transform.Find("Radio_AudioSource").GetComponent<AudioSource>();
			audioSource.transform.parent = null;
			return;
		}
		if (staticAudioSource == null)
		{
			staticAudioSource = audioSource.transform.Find("Radio_AudioStaticSource").GetComponent<AudioSource>();
			return;
		}
		Transform transform = item.GetDropObject().transform;
		bool flag = false;
		if (item.GetHandItem() != null)
		{
			transform = item.GetHandItem().transform;
		}
		audioSource.transform.position = transform.position;
		if (!item.InInventory())
		{
			return;
		}
		float num = 1f;
		if (!isPlaying)
		{
			num = 0f;
		}
		if ((bool)currentStation && !detuned)
		{
			curQuality = currentStation.GetCurrentQuality();
			staticAudioSource.volume = Mathf.Lerp(staticAudioSource.volume, 1f - curQuality, Time.deltaTime * 5f);
			audioSource.volume = Mathf.Lerp(audioSource.volume, num * curQuality, Time.deltaTime * 5f);
			if (isPlaying)
			{
				if (findRandomStation)
				{
					if (ENV_RadioStation.GetLocalRadioStations().Count > 0)
					{
						if (!ENV_RadioStation.GetLocalRadioStations().Contains(currentStation))
						{
							bool flag2 = false;
							foreach (ENV_RadioStation localRadioStation in ENV_RadioStation.GetLocalRadioStations())
							{
								if (localRadioStation.stationFrequency == currentStation.stationFrequency)
								{
									flag2 = true;
									currentStation = localRadioStation;
									flag = true;
									RefreshStation(localRadioStation);
									break;
								}
							}
							if (currentStation != null && !flag2)
							{
								ShowText("Signal Lost");
								currentStation = null;
								detuned = true;
								flag = true;
							}
						}
					}
					else
					{
						if (currentStation != null)
						{
							ShowText("Signal Lost");
						}
						currentStation = null;
					}
				}
				radioController.GetCurrentTrack(Time.time, out var clip, out var clipTime);
				if ((audioSource.clip != clip || !audioSource.isPlaying) && currentStation != null)
				{
					string text = currentStation.stationFrequency + " - " + currentStation.stationName;
					ENV_RadioStation.RadioTrack currentTrack = currentStation.GetCurrentTrack();
					if (currentTrack != null && currentTrack.showTrackName)
					{
						text = text + " - " + currentTrack.trackName;
					}
					ShowText(text);
					if (!flag)
					{
						AudioManager.PlaySound(changeTrackClip, audioSource.transform.position);
					}
					audioSource.clip = clip;
					audioSource.time = 0f;
					audioSource.Play();
					resumeTime = clipTime;
				}
				if (audioSource.time > 0.1f && resumeTime > 0f)
				{
					audioSource.Pause();
					audioSource.time = resumeTime;
					audioSource.Play();
					resumeTime = 0f;
				}
			}
			else if (audioSource.isPlaying)
			{
				audioSource.Stop();
			}
		}
		else
		{
			staticAudioSource.volume = Mathf.Lerp(staticAudioSource.volume, num * 0.4f, Time.deltaTime * 5f);
			audioSource.volume = Mathf.Lerp(audioSource.volume, 0f, Time.deltaTime * 5f);
			if (ENV_RadioStation.GetLocalRadioStations().Count > 0 && !detuned && isPlaying)
			{
				ChangeStation();
			}
		}
		base.Execute();
	}

	public override void OnDestroy()
	{
		UnityEngine.Object.Destroy(audioSource.gameObject);
		audioSource = null;
		staticAudioSource = null;
		hasBeenDestroyed = true;
		base.OnDestroy();
	}

	public override void SendMessage(string m)
	{
		base.SendMessage(m);
		switch (m)
		{
		case "toggle":
			isPlaying = !isPlaying;
			break;
		case "changestation":
			ChangeStation();
			break;
		case "activate":
			isPlaying = true;
			break;
		}
	}

	public override ItemExecutionModule GetCopy()
	{
		return new ItemExecutionModule_Radio
		{
			findRandomStation = findRandomStation,
			changeStationClip = changeStationClip,
			changeTrackClip = changeTrackClip,
			curQuality = curQuality,
			detuned = detuned,
			resumeTime = resumeTime,
			isPlaying = isPlaying,
			audioSource = null,
			staticAudioSource = null
		};
	}

	private void RefreshStation(ENV_RadioStation station)
	{
		AudioManager.PlaySound(changeStationClip, audioSource.transform.position);
		if (station != null)
		{
			currentStation = station;
		}
		detuned = false;
		radioController.RecieveStation(currentStation);
		string text = currentStation.stationFrequency + " - " + currentStation.stationName;
		ENV_RadioStation.RadioTrack currentTrack = currentStation.GetCurrentTrack();
		if (currentTrack != null && currentTrack.showTrackName)
		{
			text = text + " - " + currentTrack.trackName;
		}
		ShowText(text);
	}

	private void ChangeStation()
	{
		if (!findRandomStation)
		{
			return;
		}
		List<ENV_RadioStation> localRadioStations = ENV_RadioStation.GetLocalRadioStations();
		if (localRadioStations == null || localRadioStations.Count == 0)
		{
			isPlaying = !isPlaying;
			if (!isPlaying)
			{
				ShowText("Off");
			}
			else
			{
				ShowText("No Signal");
			}
			return;
		}
		foreach (ENV_RadioStation item in localRadioStations)
		{
			Debug.Log(item.name);
		}
		int num = 0;
		if (currentStation != null)
		{
			if (localRadioStations.Contains(currentStation))
			{
				num = localRadioStations.IndexOf(currentStation);
			}
			else
			{
				Debug.Log("Station Not Found: " + currentStation.name);
				currentStation = null;
				num = -1;
			}
		}
		Debug.Log("Current Station: " + num);
		if (detuned && isPlaying && currentStation == null)
		{
			detuned = false;
			isPlaying = false;
			ShowText("Off");
			return;
		}
		if (!detuned && isPlaying)
		{
			num++;
		}
		isPlaying = true;
		if (num < 0)
		{
			num = 0;
		}
		Debug.Log("Station Count: " + localRadioStations.Count);
		if (num >= localRadioStations.Count)
		{
			num = 0;
			if (!detuned && currentStation != null)
			{
				currentStation = null;
				detuned = true;
				ShowText("No Station");
				return;
			}
		}
		ENV_RadioStation eNV_RadioStation = localRadioStations[num];
		if (eNV_RadioStation == currentStation)
		{
			currentStation = null;
			detuned = true;
			ShowText("No Station");
		}
		else
		{
			RefreshStation(eNV_RadioStation);
		}
	}

	private void ShowText(string text)
	{
		if (item.InInventory())
		{
			UT_TextScrawl.ShowTextOnScrawl("bottom-header", text);
		}
	}
}
