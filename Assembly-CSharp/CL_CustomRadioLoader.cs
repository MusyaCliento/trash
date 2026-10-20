using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class CL_CustomRadioLoader
{
	[Serializable]
	public class CustomRadioStation
	{
		[Serializable]
		public class RadioTrack
		{
			public string trackName;

			public string fileName;

			public bool showTrackName = true;

			public AudioClip trackClip;
		}

		public string name = "Null Station";

		public float frequency;

		public bool global;

		public List<string> regions;

		public List<RadioTrack> tracks;

		private ENV_RadioStation createdStation;

		public ENV_RadioStation CreateRadioStation()
		{
			if (createdStation != null)
			{
				return createdStation;
			}
			ENV_RadioStation eNV_RadioStation = ScriptableObject.CreateInstance<ENV_RadioStation>();
			eNV_RadioStation.stationName = name;
			eNV_RadioStation.stationFrequency = frequency;
			eNV_RadioStation.tracks = new List<ENV_RadioStation.RadioTrack>();
			foreach (RadioTrack track in tracks)
			{
				ENV_RadioStation.RadioTrack radioTrack = new ENV_RadioStation.RadioTrack();
				radioTrack.trackName = track.trackName;
				radioTrack.showTrackName = track.showTrackName;
				radioTrack.trackClip = track.trackClip;
				radioTrack.spawnSettings = new SpawnTable.SpawnSettings();
				eNV_RadioStation.tracks.Add(radioTrack);
			}
			eNV_RadioStation.qualityRandomAmplitude = 0.25f;
			eNV_RadioStation.qualityRandomFrequency = 1.5f;
			createdStation = eNV_RadioStation;
			return eNV_RadioStation;
		}
	}

	public static List<CustomRadioStation> customStations;

	private static bool initialized;

	public static string GetRadioFolderPath()
	{
		return Path.Combine(Application.dataPath, "Mods", "Radio");
	}

	public static void LoadCustomStations(bool force = false)
	{
		if (initialized && !force)
		{
			return;
		}
		initialized = true;
		customStations = new List<CustomRadioStation>();
		string radioFolderPath = GetRadioFolderPath();
		if (!Directory.Exists(radioFolderPath))
		{
			Debug.Log("No Radio Folder found at " + radioFolderPath);
			return;
		}
		string[] directories = Directory.GetDirectories(radioFolderPath);
		foreach (string text in directories)
		{
			string path = Path.Combine(text, "config.json");
			if (!File.Exists(path))
			{
				Debug.LogWarning("No config.json found for radio station in folder: " + text);
				continue;
			}
			string json = File.ReadAllText(path);
			CustomRadioStation station;
			try
			{
				station = JsonUtility.FromJson<CustomRadioStation>(json);
			}
			catch (Exception ex)
			{
				Debug.LogError("Failed to parse config.json for radio station in folder: " + text + "\n" + ex);
				continue;
			}
			CL_GameManager.gMan.StartCoroutine(CreateStation(text, station));
		}
	}

	public static IEnumerator CreateStation(string stationFolder, CustomRadioStation station)
	{
		string[] files = Directory.GetFiles(stationFolder, "*.wav");
		if (station.tracks == null)
		{
			station.tracks = new List<CustomRadioStation.RadioTrack>();
		}
		string[] array = files;
		foreach (string audioFile in array)
		{
			string uri = "file://" + audioFile;
			using UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(uri, AudioType.WAV);
			yield return uwr.SendWebRequest();
			if (uwr.result != UnityWebRequest.Result.Success)
			{
				Debug.LogError(uwr.error);
				yield break;
			}
			AudioClip content = DownloadHandlerAudioClip.GetContent(uwr);
			content.name = Path.GetFileNameWithoutExtension(audioFile);
			bool flag = false;
			foreach (CustomRadioStation.RadioTrack track in station.tracks)
			{
				if (track.fileName == content.name)
				{
					track.trackClip = content;
					flag = true;
					content.name = track.trackName;
					break;
				}
			}
			if (!flag)
			{
				Debug.LogWarning("No track config found for audio file: " + audioFile + " in station: " + station.name);
				station.tracks.Add(new CustomRadioStation.RadioTrack
				{
					trackName = content.name,
					fileName = content.name,
					trackClip = content,
					showTrackName = true
				});
			}
		}
		station.CreateRadioStation();
		Debug.Log("Loaded custom radio station: " + station.name + " with " + station.tracks.Count + " tracks.");
		customStations.Add(station);
	}

	public static List<ENV_RadioStation> GetGlobalStations()
	{
		List<ENV_RadioStation> list = new List<ENV_RadioStation>();
		foreach (CustomRadioStation customStation in customStations)
		{
			if (customStation.global)
			{
				list.Add(customStation.CreateRadioStation());
			}
		}
		return list;
	}

	public static List<ENV_RadioStation> GetRegionStations(string region)
	{
		List<ENV_RadioStation> list = new List<ENV_RadioStation>();
		foreach (CustomRadioStation customStation in customStations)
		{
			bool flag = true;
			foreach (CustomRadioStation.RadioTrack track in customStation.tracks)
			{
				if (track == null || track.trackClip == null)
				{
					flag = false;
					break;
				}
			}
			if (flag && customStation.regions != null && customStation.regions.Contains(region.ToLower()))
			{
				list.Add(customStation.CreateRadioStation());
			}
		}
		return list;
	}

	public static void RefreshCustomStations(string[] args)
	{
		LoadCustomStations(force: true);
	}
}
