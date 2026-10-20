using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioClipHandlerOverride_New", menuName = "White Knuckle/Audio/AudioClipHandlerOverride")]
public class AudioClipHandlerOverride : ScriptableObject
{
	[Serializable]
	public class AudioSetOverride
	{
		public string groupName;

		public string setName;

		public List<AudioClip> clips;

		public AudioClip GetClip()
		{
			if (clips == null || clips.Count == 0)
			{
				return null;
			}
			return clips[UnityEngine.Random.Range(0, clips.Count)];
		}
	}

	public List<AudioSetOverride> setOverrides;

	public AudioClip GetRandomSound()
	{
		if (setOverrides != null && setOverrides.Count > 0)
		{
			AudioSetOverride audioSetOverride = setOverrides[UnityEngine.Random.Range(0, setOverrides.Count)];
			return audioSetOverride.clips[UnityEngine.Random.Range(0, audioSetOverride.clips.Count)];
		}
		return null;
	}
}
