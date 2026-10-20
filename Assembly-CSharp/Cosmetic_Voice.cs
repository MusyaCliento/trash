using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

[CreateAssetMenu(fileName = "New Voice Cosmetic", menuName = "White Knuckle/Cosmetic/Voice")]
public class Cosmetic_Voice : Cosmetic_Base
{
	[Serializable]
	public class Cosmetic_Voice_Data
	{
		[Serializable]
		public class VoiceOverride
		{
			public string groupName;

			public string setName;

			public List<string> clips;
		}

		public string id;

		public string cosmeticName;

		public string author;

		public string description;

		public string unlock;

		public List<VoiceOverride> setOverrides;

		public AudioClipHandlerOverride clipHandlerOverride;
	}

	public Cosmetic_Voice_Data cosmeticData;

	public Sprite infoSprite;

	public List<AudioClip> sampleClips;

	public override string GetCosmeticType()
	{
		return "voice";
	}

	internal void Initialize()
	{
	}

	public override Sprite GetInfoSprite()
	{
		return infoSprite;
	}

	public static Cosmetic_Voice BuildVoiceCosmetic(string folderPath, string jsonPath)
	{
		string json = File.ReadAllText(jsonPath);
		Cosmetic_Voice_Data createdData = JsonUtility.FromJson<Cosmetic_Voice_Data>(json);
		string clipPath = Path.Combine(folderPath, "clips");
		Directory.CreateDirectory(clipPath);
		List<AudioClip> loadedClips = new List<AudioClip>();
		AudioClipHandlerOverride newOverride = new AudioClipHandlerOverride();
		CL_GameManager.gMan.StartCoroutine(LoadAudio());
		createdData.clipHandlerOverride = newOverride;
		Cosmetic_Voice cosmetic_Voice = new Cosmetic_Voice();
		cosmetic_Voice.cosmeticInfo = new Cosmetic_Info
		{
			id = createdData.id,
			cosmeticName = createdData.cosmeticName,
			tag = "voice",
			author = createdData.author,
			description = createdData.description,
			unlock = createdData.unlock
		};
		cosmetic_Voice.cosmeticData = createdData;
		cosmetic_Voice.cosmeticInfo.cardBackground = RuntimeSpriteImporter.LoadSpriteFromFile(Path.Combine(folderPath, "card-background.png"), 100f, FilterMode.Bilinear, mipmap: true);
		cosmetic_Voice.cosmeticInfo.cardForeground = RuntimeSpriteImporter.LoadSpriteFromFile(Path.Combine(folderPath, "card-foreground.png"), 100f, FilterMode.Bilinear, mipmap: true);
		return cosmetic_Voice;
		IEnumerator LoadAudio()
		{
			string[] files = Directory.GetFiles(clipPath, "*.wav");
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
				Debug.Log("Loaded Clip: " + content.name);
				loadedClips.Add(content);
			}
			Dictionary<string, AudioClip> dictionary = new Dictionary<string, AudioClip>();
			foreach (AudioClip item in loadedClips)
			{
				dictionary.Add(item.name, item);
				Debug.Log("Found Clip: " + item.name);
			}
			newOverride.setOverrides = new List<AudioClipHandlerOverride.AudioSetOverride>();
			foreach (Cosmetic_Voice_Data.VoiceOverride setOverride in createdData.setOverrides)
			{
				AudioClipHandlerOverride.AudioSetOverride audioSetOverride = new AudioClipHandlerOverride.AudioSetOverride
				{
					setName = setOverride.setName,
					groupName = setOverride.groupName
				};
				if (audioSetOverride.clips == null)
				{
					audioSetOverride.clips = new List<AudioClip>();
				}
				foreach (string clip in setOverride.clips)
				{
					if (dictionary.TryGetValue(clip, out var value))
					{
						audioSetOverride.clips.Add(value);
					}
				}
				newOverride.setOverrides.Add(audioSetOverride);
			}
		}
	}
}
