using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Radio Station", menuName = "White Knuckle/Radio/Radio Station", order = 0)]
public class ENV_RadioStation : ScriptableObject
{
	[Serializable]
	public class RadioTrack
	{
		public string trackName;

		public bool showTrackName = true;

		public AudioClip trackClip;

		public SpawnTable.SpawnSettings spawnSettings;
	}

	private bool initialized;

	public string stationName = "jackFM";

	public float stationFrequency = 93.7f;

	public List<RadioTrack> tracks;

	private List<RadioTrack> curTrackList;

	private static HashSet<ENV_RadioStation> initializedStations;

	internal float curQuality = 1f;

	private float timeTest;

	[Range(0f, 1f)]
	public float qualityRandomAmplitude;

	public float qualityRandomFrequency = 1f;

	private float totalDuration;

	public RadioTrack GetRandomTrack()
	{
		if (tracks == null || tracks.Count == 0)
		{
			Debug.LogWarning("Radio List is empty!");
			return null;
		}
		float num = 0f;
		foreach (RadioTrack track in tracks)
		{
			num += track.spawnSettings.GetEffectiveSpawnChance();
		}
		float num2 = UnityEngine.Random.Range(0f, num);
		float num3 = 0f;
		foreach (RadioTrack track2 in tracks)
		{
			num3 += track2.spawnSettings.GetEffectiveSpawnChance();
			if (num2 <= num3)
			{
				return track2;
			}
		}
		return null;
	}

	public static void ResetStations()
	{
		initializedStations = new HashSet<ENV_RadioStation>();
	}

	public void Initialize()
	{
		if (initializedStations == null)
		{
			initializedStations = new HashSet<ENV_RadioStation>();
		}
		if (initializedStations.Contains(this))
		{
			return;
		}
		initializedStations.Add(this);
		curTrackList = new List<RadioTrack>();
		List<RadioTrack> list = new List<RadioTrack>();
		list.AddRange(tracks);
		while (list.Count > 0)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			if (list[index] != null && list[index].spawnSettings.RandomCheck())
			{
				curTrackList.Add(list[index]);
			}
			list.RemoveAt(index);
		}
		totalDuration = 0f;
		foreach (RadioTrack curTrack in curTrackList)
		{
			if (curTrack.trackClip != null)
			{
				totalDuration += curTrack.trackClip.length;
			}
		}
	}

	public void GetCurrentTrackClip(out AudioClip clip, out float clipTime)
	{
		Initialize();
		float time = Time.time;
		clip = null;
		clipTime = 0f;
		if (curTrackList == null || curTrackList.Count == 0 || totalDuration <= 0f)
		{
			return;
		}
		if (ENV_RadioEmitter.activeEmitters != null)
		{
			foreach (ENV_RadioEmitter activeEmitter in ENV_RadioEmitter.activeEmitters)
			{
				if (activeEmitter.force && activeEmitter.station != this)
				{
					activeEmitter.station.GetCurrentTrackClip(out clip, out clipTime);
					return;
				}
				if (activeEmitter.force && activeEmitter.station == this)
				{
					break;
				}
			}
		}
		float num = time % totalDuration;
		for (int i = 0; i < curTrackList.Count; i++)
		{
			RadioTrack radioTrack = curTrackList[i];
			if (radioTrack != null)
			{
				if (num < radioTrack.trackClip.length)
				{
					clip = radioTrack.trackClip;
					clipTime = num;
					return;
				}
				num -= radioTrack.trackClip.length;
			}
		}
		timeTest = num;
	}

	public RadioTrack GetCurrentTrack()
	{
		float time = Time.time;
		Initialize();
		if (curTrackList == null || curTrackList.Count == 0 || totalDuration <= 0f)
		{
			return null;
		}
		if (ENV_RadioEmitter.activeEmitters != null)
		{
			foreach (ENV_RadioEmitter activeEmitter in ENV_RadioEmitter.activeEmitters)
			{
				if (activeEmitter.force && activeEmitter.station != this)
				{
					return activeEmitter.station.GetCurrentTrack();
				}
				if (activeEmitter.force && activeEmitter.station == this)
				{
					break;
				}
			}
		}
		float num = time % totalDuration;
		for (int i = 0; i < curTrackList.Count; i++)
		{
			RadioTrack radioTrack = curTrackList[i];
			if (radioTrack != null)
			{
				if (num < radioTrack.trackClip.length)
				{
					return radioTrack;
				}
				num -= radioTrack.trackClip.length;
			}
		}
		return null;
	}

	public static List<ENV_RadioStation> GetLocalRadioStations()
	{
		List<ENV_RadioStation> list = new List<ENV_RadioStation>();
		if (WorldLoader.instance != null && WorldLoader.instance.GetCurrentLevel() != null && WorldLoader.instance.GetCurrentLevel().GetLevel() != null)
		{
			if (WorldLoader.instance.GetCurrentLevel().GetLevel().region != null)
			{
				if (WorldLoader.instance.GetCurrentLevel().GetLevel().region.radioStations != null)
				{
					list.AddRange(WorldLoader.instance.GetCurrentLevel().GetLevel().region.radioStations);
				}
				list.AddRange(CL_CustomRadioLoader.GetRegionStations(WorldLoader.instance.GetCurrentLevel().GetLevel().region.regionName));
			}
			if (WorldLoader.instance.GetCurrentLevel().GetLevel().subRegion != null)
			{
				if (WorldLoader.instance.GetCurrentLevel().GetLevel().subRegion.radioStations != null)
				{
					list.AddRange(WorldLoader.instance.GetCurrentLevel().GetLevel().subRegion.radioStations);
				}
				list.AddRange(CL_CustomRadioLoader.GetRegionStations(WorldLoader.instance.GetCurrentLevel().GetLevel().subRegion.subregionName));
			}
		}
		list.AddRange(CL_CustomRadioLoader.GetGlobalStations());
		if (ENV_RadioEmitter.activeEmitters != null)
		{
			foreach (ENV_RadioEmitter activeEmitter in ENV_RadioEmitter.activeEmitters)
			{
				list.Add(activeEmitter.station);
			}
		}
		return list;
	}

	public float GetCurrentQuality()
	{
		return curQuality - Mathf.PerlinNoise1D(Time.time * qualityRandomFrequency) * qualityRandomAmplitude;
	}
}
