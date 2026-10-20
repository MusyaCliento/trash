using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UT_AudioClipHandler : MonoBehaviour
{
	[Serializable]
	public class AudioGroup
	{
		public string name;

		public List<AudioSet> audioSets;

		internal Dictionary<string, AudioSet> audioDictionary;

		private UT_AudioClipHandler handler;

		public void Initialize(UT_AudioClipHandler h)
		{
			audioDictionary = new Dictionary<string, AudioSet>();
			handler = h;
			foreach (AudioSet audioSet in audioSets)
			{
				audioDictionary.Add(audioSet.name, audioSet);
				audioSet.transform = handler.transform;
				audioSet.parentGroup = this;
				audioSet.handler = handler;
			}
		}

		public AudioSet GetAudioSet(string n)
		{
			if (audioDictionary == null)
			{
				Initialize(handler);
			}
			if (!audioDictionary.ContainsKey(n))
			{
				Debug.LogWarning("Missing Audio Clip Set " + n);
				return null;
			}
			return audioDictionary[n];
		}

		public void PlayAudioSet(string n)
		{
			if (audioDictionary == null)
			{
				Initialize(handler);
			}
			if (!audioDictionary.ContainsKey(n))
			{
				Debug.LogWarning("Missing Audio Clip Set " + n);
			}
			else
			{
				audioDictionary[n].Play(1f);
			}
		}

		public void OverrideAudioSet(string n, AudioClip clip)
		{
			if (audioDictionary == null)
			{
				Initialize(handler);
			}
			if (!audioDictionary.ContainsKey(n))
			{
				Debug.LogWarning("Missing Audio Clip Set " + n);
			}
			else
			{
				audioDictionary[n].PlaySound(1f, clip);
			}
		}

		public void StopAudioSet(string n)
		{
			if (audioDictionary == null)
			{
				Initialize(handler);
			}
			if (!audioDictionary.ContainsKey(n))
			{
				Debug.LogWarning("Missing Audio Clip Set " + n);
			}
			else
			{
				audioDictionary[n].StopSound();
			}
		}

		public void PlayAudioSetAtPoint(string n, Vector3 pos)
		{
			if (audioDictionary == null)
			{
				Initialize(handler);
			}
			audioDictionary[n].PlayAtPoint(1f, pos);
		}

		public AudioSet GetSet(string n)
		{
			if (audioDictionary == null)
			{
				audioDictionary = new Dictionary<string, AudioSet>();
			}
			if (!audioDictionary.ContainsKey(n))
			{
				return null;
			}
			return audioDictionary[n];
		}
	}

	[Serializable]
	public class AudioSet
	{
		public enum AudioOrdering
		{
			smartRandom = 0,
			sequential = 1,
			reverse = 2,
			pureRandom = 3
		}

		public string name;

		[SerializeReference]
		internal AudioGroup parentGroup;

		internal UT_AudioClipHandler handler;

		public AudioOrdering orderStyle;

		private int sequenceCounter;

		public List<AudioClip> clips;

		[Range(0f, 2f)]
		public float minVolume = 1f;

		[Range(0f, 2f)]
		public float maxVolume = 1f;

		[Range(0f, 2f)]
		public float minPitch = 1f;

		[Range(0f, 2f)]
		public float maxPitch = 1f;

		public bool loop;

		public bool preventInterrupt;

		[Range(0f, 1f)]
		public float spatialBlend = 1f;

		[Range(0f, 1f)]
		public float reverbZoneMix = 1f;

		public AudioSource aud;

		[HideInInspector]
		public Transform transform;

		public bool useSubtitles;

		public string subtitleGroup = "sound";

		public string subtitleId = "";

		public bool subtitleGlobal;

		public bool subtitleShowDirectionality = true;

		public bool subtitleAmbient = true;

		public float subtitleRadius = 15f;

		public bool useCustomMixerGroup;

		public AudioMixerGroup customMixerGroup;

		public bool broadcastToListeners;

		public string broadcastTag = "";

		public float broadcastRadius = 5f;

		public float broadcastVolumeMult = 1f;

		private List<int> smartRandomStack = new List<int>();

		private int lastSmartRandom = -1;

		public AudioClip GetClip()
		{
			if (orderStyle == AudioOrdering.smartRandom)
			{
				if (smartRandomStack.Count == 0 && clips.Count > 0)
				{
					for (int i = 0; i < clips.Count; i++)
					{
						smartRandomStack.Add(i);
					}
					DarkMachineFunctions.ShuffleList(smartRandomStack);
					List<int> list = smartRandomStack;
					if (list[list.Count - 1] == lastSmartRandom)
					{
						List<int> list2 = smartRandomStack;
						List<int> list3;
						int index = (list3 = smartRandomStack).Count - 1;
						List<int> list4 = smartRandomStack;
						int num = list4[list4.Count - 1];
						int num2 = smartRandomStack[0];
						int num3 = (list2[0] = num);
						num3 = (list3[index] = num2);
					}
					lastSmartRandom = smartRandomStack[0];
				}
				if (smartRandomStack.Count > 0)
				{
					List<int> list5 = smartRandomStack;
					int index2 = list5[list5.Count - 1];
					smartRandomStack.RemoveAt(smartRandomStack.Count - 1);
					return clips[index2];
				}
			}
			else
			{
				if (orderStyle == AudioOrdering.pureRandom)
				{
					return clips[UnityEngine.Random.Range(0, clips.Count)];
				}
				if (orderStyle == AudioOrdering.sequential)
				{
					sequenceCounter++;
					if (sequenceCounter >= clips.Count)
					{
						sequenceCounter = 0;
					}
					return clips[sequenceCounter];
				}
				if (orderStyle == AudioOrdering.reverse)
				{
					sequenceCounter--;
					if (sequenceCounter < 0)
					{
						sequenceCounter = clips.Count - 1;
					}
					return clips[sequenceCounter];
				}
			}
			if (clips.Count == 0)
			{
				return null;
			}
			return clips[0];
		}

		public float GetPitch()
		{
			return UnityEngine.Random.Range(minPitch, maxPitch);
		}

		public float GetVolume()
		{
			return maxVolume;
		}

		public AudioClip GetClip(int i)
		{
			return clips[i];
		}

		public List<AudioClip> GetClips()
		{
			return clips;
		}

		public void Play(float globalVolume, AudioSource src = null)
		{
			AudioClip audioClip = null;
			if (handler != null && handler.overrides != null)
			{
				audioClip = handler.GetOverrideSet(parentGroup.name, name)?.GetClip();
			}
			if (audioClip == null)
			{
				audioClip = GetClip();
			}
			if (audioClip == null)
			{
				return;
			}
			if (src == null && aud == null)
			{
				Transform softParent = handler.softParent;
				if (softParent == null)
				{
					softParent = transform;
				}
				if (!(softParent == null))
				{
					if (broadcastToListeners)
					{
						AudioManager.PlayListenedSound(broadcastTag, transform.position, broadcastRadius);
					}
					AudioManager.PlaySound(audioClip, softParent, UnityEngine.Random.Range(minVolume, maxVolume) * globalVolume, UnityEngine.Random.Range(minPitch, maxPitch), spatialBlend, bypass: false, reverbZoneMix, useCustomMixerGroup ? customMixerGroup : null);
					PlaySubtitle(audioClip.name, aud);
				}
				return;
			}
			AudioSource audioSource = aud;
			if (src != null)
			{
				audioSource = src;
			}
			if (!preventInterrupt || !audioSource.isPlaying)
			{
				audioSource.clip = audioClip;
				audioSource.volume = UnityEngine.Random.Range(minVolume, maxVolume) * globalVolume;
				audioSource.pitch = UnityEngine.Random.Range(minPitch, maxPitch);
				audioSource.loop = loop;
				audioSource.Play();
				if (broadcastToListeners)
				{
					AudioManager.PlayListenedSound(broadcastTag, audioSource.transform.position, broadcastRadius);
				}
				PlaySubtitle(audioSource.clip.name, aud);
			}
		}

		public void Play(float globalVolume, Vector3 pos)
		{
			AudioClip audioClip = handler.GetOverrideSet(parentGroup.name, name)?.GetClip();
			if (audioClip == null)
			{
				audioClip = GetClip();
			}
			AudioManager.PlaySound(audioClip, pos, UnityEngine.Random.Range(minVolume, maxVolume) * globalVolume, UnityEngine.Random.Range(minPitch, maxPitch), spatialBlend, bypass: false, reverbZoneMix, useCustomMixerGroup ? customMixerGroup : null);
			PlaySubtitle(audioClip.name, aud);
			if (broadcastToListeners)
			{
				AudioManager.PlayListenedSound(broadcastTag, transform.position, broadcastRadius);
			}
		}

		public void PlaySound(float globalVolume, AudioClip clip)
		{
			if (clip == null)
			{
				aud.Stop();
				return;
			}
			if (aud != null)
			{
				AudioSource audioSource = aud;
				audioSource.clip = clip;
				audioSource.volume = UnityEngine.Random.Range(minVolume, maxVolume) * globalVolume;
				audioSource.pitch = UnityEngine.Random.Range(minPitch, maxPitch);
				audioSource.spatialBlend = spatialBlend;
				audioSource.loop = loop;
				audioSource.Play();
				if (broadcastToListeners)
				{
					AudioManager.PlayListenedSound(broadcastTag, audioSource.transform.position, broadcastRadius);
				}
			}
			else
			{
				AudioManager.PlaySound(clip, transform.position, UnityEngine.Random.Range(minVolume, maxVolume) * globalVolume, UnityEngine.Random.Range(minPitch, maxPitch), spatialBlend, bypass: false, reverbZoneMix, useCustomMixerGroup ? customMixerGroup : null);
				if (broadcastToListeners)
				{
					AudioManager.PlayListenedSound(broadcastTag, transform.position, broadcastRadius);
				}
			}
			PlaySubtitle(clip.name, aud);
		}

		public void PlayAtPoint(float globalVolume, Vector3 pos, AudioSource src = null)
		{
			AudioClip audioClip = handler.GetOverrideSet(parentGroup.name, name)?.GetClip();
			if (audioClip == null)
			{
				audioClip = GetClip();
			}
			AudioManager.PlaySound(audioClip, pos, UnityEngine.Random.Range(minVolume, maxVolume) * globalVolume, UnityEngine.Random.Range(minPitch, maxPitch), 1f, bypass: false, reverbZoneMix);
			if (broadcastToListeners)
			{
				AudioManager.PlayListenedSound(broadcastTag, pos, broadcastRadius);
			}
			PlaySubtitle(audioClip.name, src);
		}

		private void PlaySubtitle(string clipName, AudioSource src)
		{
			if (aud != null)
			{
				PlaySubtitle(clipName, aud.transform);
			}
			else
			{
				PlaySubtitle(clipName, transform);
			}
		}

		private void PlaySubtitle(string clipName, Transform originTransform = null)
		{
			if (useSubtitles)
			{
				if (originTransform == null)
				{
					originTransform = transform;
				}
				CL_UIManager.SubtitleId id = CL_UIManager.SubtitleCreate(CL_LocalizationManager.currentLocalization.GetLine(subtitleGroup, (subtitleId == "") ? clipName : subtitleId), "");
				CL_UIManager.SubtitleFlags subtitleFlags = CL_UIManager.SubtitleFlags.Default;
				if (subtitleAmbient)
				{
					subtitleFlags |= CL_UIManager.SubtitleFlags.Ambient;
				}
				CL_UIManager.SubtitleFlagsSet(id, subtitleFlags);
				if (!subtitleGlobal)
				{
					CL_UIManager.SubtitleSpace(id, originTransform, Vector3.zero, subtitleRadius);
				}
			}
		}

		public void StopSound()
		{
			if (aud != null)
			{
				aud.Stop();
			}
		}

		public void SetAudiosource(AudioSource a)
		{
			aud = a;
		}

		public void SetVolume(float v)
		{
			if (aud != null)
			{
				aud.volume = v;
			}
		}

		public float GetCurrentVolume()
		{
			return aud.volume;
		}

		public void FadeSound(float target, float delta, bool autoStop = true)
		{
			if (aud == null)
			{
				Debug.LogError("Audio Clip " + name + " Is missing an audio source, for fading.");
				return;
			}
			aud.clip = clips[0];
			if (autoStop)
			{
				if (aud.volume == 0f && target == 0f)
				{
					aud.Stop();
				}
				else if (!aud.isPlaying)
				{
					aud.Play();
				}
			}
			aud.volume = Mathf.Lerp(aud.volume, target, delta);
		}

		public void FadeIn(float delta, bool autoStop = true)
		{
			if (aud == null)
			{
				Debug.LogError("Audio Clip " + name + " Is missing an audio source, for fading.");
				return;
			}
			aud.clip = clips[0];
			if (autoStop && !aud.isPlaying)
			{
				aud.Play();
			}
			aud.volume = Mathf.Lerp(aud.volume, maxVolume, delta);
		}
	}

	public float globalVolume = 1f;

	public Transform softParent;

	private AudioSource aud;

	public List<AudioGroup> groups;

	private Dictionary<string, AudioGroup> groupDictionary;

	private bool initialized;

	public List<AudioClipHandlerOverride> overrides;

	public void Initialize()
	{
		if (initialized)
		{
			return;
		}
		groupDictionary = new Dictionary<string, AudioGroup>();
		foreach (AudioGroup group in groups)
		{
			groupDictionary.Add(group.name, group);
			group.Initialize(this);
		}
		aud = GetComponent<AudioSource>();
		initialized = true;
	}

	private void Start()
	{
		Initialize();
	}

	public AudioGroup GetGroup(string s)
	{
		if (groupDictionary == null || !groupDictionary.ContainsKey(s))
		{
			return null;
		}
		return groupDictionary[s];
	}

	public void StopSound()
	{
		aud.Stop();
	}

	public void StopSound(string sound)
	{
		string[] array = sound.Split(':');
		GetGroup(array[0]).StopAudioSet(array[1]);
	}

	public AudioClip GetSound(string sound)
	{
		if (!HasSound(sound))
		{
			return null;
		}
		if (!sound.Contains(':'))
		{
			return null;
		}
		string[] array = sound.Split(':');
		if (groupDictionary.ContainsKey(array[0]))
		{
			AudioSet audioSet = GetGroup(array[0]).GetAudioSet(array[1]);
			if (audioSet != null)
			{
				return audioSet.GetClip();
			}
		}
		return null;
	}

	public void PlaySound(string sound)
	{
		if (HasSound(sound) && sound.Contains(':'))
		{
			string[] array = sound.Split(':');
			if (groupDictionary.ContainsKey(array[0]))
			{
				GetGroup(array[0]).PlayAudioSet(array[1]);
			}
		}
	}

	public void PlaySound(string sound, float volume)
	{
		if (HasSound(sound))
		{
			string[] array = sound.Split(':');
			GetGroup(array[0])?.GetSet(array[1])?.Play(volume);
		}
	}

	public void PlaySound(string sound, Vector3 pos)
	{
		if (HasSound(sound))
		{
			string[] array = sound.Split(':');
			GetGroup(array[0]).PlayAudioSetAtPoint(array[1], pos);
		}
	}

	public void FadeSound(string sound, float volume, float delta, bool autoStop = true)
	{
		if (HasSound(sound))
		{
			string[] array = sound.Split(':');
			GetGroup(array[0]).GetSet(array[1]).FadeSound(volume, delta, autoStop);
		}
	}

	public void FadeIn(string sound, float delta, bool autoStop = true)
	{
		if (HasSound(sound))
		{
			string[] array = sound.Split(':');
			GetGroup(array[0]).GetSet(array[1]).FadeIn(delta, autoStop);
		}
	}

	public bool HasSound(string sound)
	{
		if (groupDictionary == null)
		{
			return false;
		}
		if (!sound.Contains(':'))
		{
			return false;
		}
		string[] array = sound.Split(':');
		if (GetGroup(array[0]) == null)
		{
			return false;
		}
		if (GetGroup(array[0]).GetSet(array[1]) == null)
		{
			return false;
		}
		return true;
	}

	public AudioSet AddOrGetAudioSet(string group, string set, bool createAudioEmitter = false)
	{
		AudioGroup audioGroup2;
		if (!groupDictionary.ContainsKey(group))
		{
			AudioGroup audioGroup = new AudioGroup();
			audioGroup.name = group;
			groupDictionary.Add(group, audioGroup);
			groups.Add(audioGroup);
			audioGroup2 = audioGroup;
			audioGroup2.audioDictionary = new Dictionary<string, AudioSet>();
			audioGroup2.audioSets = new List<AudioSet>();
		}
		else
		{
			audioGroup2 = GetGroup(group);
		}
		AudioSet audioSet = audioGroup2.GetSet(set);
		if (audioSet == null)
		{
			audioSet = new AudioSet();
			audioSet.name = set;
			audioGroup2.audioSets.Add(audioSet);
			audioGroup2.audioDictionary.Add(set, audioSet);
			audioSet.clips = new List<AudioClip>();
			if (createAudioEmitter)
			{
				audioSet.aud = base.gameObject.AddComponent<AudioSource>();
			}
		}
		return audioSet;
	}

	public void AddOverride(AudioClipHandlerOverride o)
	{
		if (overrides == null)
		{
			overrides = new List<AudioClipHandlerOverride>();
		}
		overrides.Add(o);
	}

	public void RemoveOverride(AudioClipHandlerOverride o)
	{
		if (overrides != null)
		{
			overrides.Remove(o);
		}
	}

	public AudioClipHandlerOverride.AudioSetOverride GetOverrideSet(string group, string set)
	{
		if (overrides == null)
		{
			return null;
		}
		foreach (AudioClipHandlerOverride @override in overrides)
		{
			if (@override == null)
			{
				continue;
			}
			foreach (AudioClipHandlerOverride.AudioSetOverride setOverride in @override.setOverrides)
			{
				if (setOverride.groupName == group && setOverride.setName == set)
				{
					Debug.Log("Found Sound: " + setOverride.groupName + " " + setOverride.setName);
					return setOverride;
				}
			}
		}
		return null;
	}

	public void LogAllGroupsAndClips()
	{
		string text = "";
		foreach (AudioGroup group in groups)
		{
			text = text + "GROUP: " + group.name + "\n";
			foreach (AudioSet audioSet in group.audioSets)
			{
				text = text + "SET: " + audioSet.name + "\n";
			}
		}
		Debug.Log(text);
	}
}
