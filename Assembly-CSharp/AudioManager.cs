using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	[Serializable]
	public class Soundtrack
	{
		public string name;

		public AudioClip clip;

		public bool loop;

		public float volume = 1f;
	}

	[Serializable]
	public class AudioClipHolder
	{
		public string id;

		public List<AudioClip> clips;
	}

	[Serializable]
	public class AudioSourceType
	{
		public string name;

		public AudioSource audioSourcePrefab;
	}

	private struct SoftParentedAudio
	{
		public AudioSource source;

		public Transform softParent;
	}

	private static List<AudioSource> auds = new List<AudioSource>();

	public AudioMixer mixer;

	public AudioMixerGroup soundtrackMixer;

	public AudioMixerGroup gameMixer;

	public AudioMixerGroup UIMixer;

	[SerializeField]
	private int audCount = 5;

	public List<Soundtrack> music;

	private static Dictionary<string, Soundtrack> musicLibrary = new Dictionary<string, Soundtrack>();

	public static AudioManager instance;

	[SerializeField]
	private int poolSize = 10;

	[SerializeField]
	private GameObject audioSourcePrefab;

	[SerializeField]
	private Transform poolParent;

	private Queue<AudioSource> audioSourcePool;

	private List<SoftParentedAudio> softParentedAudioSources = new List<SoftParentedAudio>();

	private static AudioSource defaultAudio;

	public List<AudioSourceType> audioSourceTypes;

	private static Dictionary<string, AudioSourceType> sourceTypeDict;

	public List<AudioClip> clips;

	public List<AudioClipHolder> audioClips;

	private Dictionary<string, AudioClipHolder> clipDict;

	private static float targetMusicVolume = 0f;

	internal float gameMixerPitchMult = 1f;

	private static Dictionary<int, Coroutine> fadeCoroutines = new Dictionary<int, Coroutine>();

	private static List<Listener_Core> listeners;

	private void Start()
	{
		auds = new List<AudioSource>();
		musicLibrary = new Dictionary<string, Soundtrack>();
		sourceTypeDict = new Dictionary<string, AudioSourceType>();
		foreach (AudioSourceType audioSourceType in audioSourceTypes)
		{
			sourceTypeDict.Add(audioSourceType.name, audioSourceType);
		}
		for (int i = 0; i < audCount; i++)
		{
			auds.Add(base.gameObject.AddComponent<AudioSource>());
			auds[i].loop = true;
			auds[i].bypassReverbZones = true;
			auds[i].outputAudioMixerGroup = soundtrackMixer;
		}
		foreach (Soundtrack item in music)
		{
			musicLibrary.Add(item.name, item);
		}
		defaultAudio = audioSourcePrefab.GetComponent<AudioSource>();
		ResetGameAudioVolume();
		clipDict = new Dictionary<string, AudioClipHolder>();
		foreach (AudioClipHolder audioClip in audioClips)
		{
			clipDict.Add(audioClip.id, audioClip);
		}
	}

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			InitializePool();
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public static void ResetGameAudioVolume()
	{
		instance.gameMixer.audioMixer.SetFloat("MasterVolume", 0f);
		instance.gameMixer.audioMixer.SetFloat("AmbienceVolume", 0f);
		instance.gameMixer.audioMixer.SetFloat("EffectsVolume", 0f);
	}

	private void InitializePool()
	{
		audioSourcePool = new Queue<AudioSource>();
		for (int i = 0; i < poolSize; i++)
		{
			GameObject obj = UnityEngine.Object.Instantiate(audioSourcePrefab, poolParent);
			AudioSource component = obj.GetComponent<AudioSource>();
			obj.SetActive(value: false);
			audioSourcePool.Enqueue(component);
		}
	}

	public static void PlaySound(AudioClip clip, Vector3 position, float volume = 1f, float pitch = 1f, float spatial = 1f, bool bypass = false, float reverbMix = 1f, AudioMixerGroup mixerGroup = null, string sourceType = "")
	{
		if (clip == null)
		{
			return;
		}
		if (instance == null)
		{
			Debug.LogWarning("AudioManager instance not found.");
			return;
		}
		AudioSource pooledAudioSource = instance.GetPooledAudioSource();
		if (!(pooledAudioSource == null))
		{
			pooledAudioSource.bypassListenerEffects = bypass;
			if (sourceType != "" && sourceTypeDict.ContainsKey(sourceType))
			{
				AudioSource audioSource = sourceTypeDict[sourceType].audioSourcePrefab;
				pooledAudioSource.dopplerLevel = audioSource.dopplerLevel;
				pooledAudioSource.spread = audioSource.spread;
				pooledAudioSource.maxDistance = audioSource.maxDistance;
				AnimationCurve customCurve = audioSource.GetCustomCurve(AudioSourceCurveType.CustomRolloff);
				pooledAudioSource.SetCustomCurve(AudioSourceCurveType.CustomRolloff, customCurve);
			}
			else if (defaultAudio != null)
			{
				AudioSource audioSource2 = defaultAudio;
				pooledAudioSource.dopplerLevel = audioSource2.dopplerLevel;
				pooledAudioSource.spread = audioSource2.spread;
				pooledAudioSource.maxDistance = audioSource2.maxDistance;
				AnimationCurve customCurve2 = audioSource2.GetCustomCurve(AudioSourceCurveType.CustomRolloff);
				pooledAudioSource.SetCustomCurve(AudioSourceCurveType.CustomRolloff, customCurve2);
			}
			pooledAudioSource.outputAudioMixerGroup = instance.gameMixer;
			pooledAudioSource.transform.position = position;
			pooledAudioSource.volume = volume;
			pooledAudioSource.pitch = pitch;
			pooledAudioSource.clip = clip;
			pooledAudioSource.spatialBlend = spatial;
			pooledAudioSource.reverbZoneMix = reverbMix;
			pooledAudioSource.ignoreListenerPause = false;
			pooledAudioSource.gameObject.SetActive(value: true);
			if (mixerGroup != null)
			{
				Debug.Log("Playing Sound on special mixer: " + clip.name);
				pooledAudioSource.outputAudioMixerGroup = mixerGroup;
			}
			else
			{
				pooledAudioSource.outputAudioMixerGroup = instance.gameMixer;
			}
			pooledAudioSource.Play();
			instance.StartCoroutine(instance.ReturnToPoolAfterPlaying(pooledAudioSource));
		}
	}

	public static void PlaySound(AudioClip clip, Transform from, float volume = 1f, float pitch = 1f, float spatial = 1f, bool bypass = false, float reverbMix = 1f, AudioMixerGroup mixerGroup = null, string sourceType = "")
	{
		if (clip == null)
		{
			return;
		}
		if (instance == null)
		{
			Debug.LogWarning("AudioManager instance not found.");
			return;
		}
		AudioSource pooledAudioSource = instance.GetPooledAudioSource();
		if (!(pooledAudioSource == null))
		{
			pooledAudioSource.bypassListenerEffects = bypass;
			if (sourceType != "" && sourceTypeDict.ContainsKey(sourceType))
			{
				AudioSource audioSource = sourceTypeDict[sourceType].audioSourcePrefab;
				pooledAudioSource.dopplerLevel = audioSource.dopplerLevel;
				pooledAudioSource.spread = audioSource.spread;
				pooledAudioSource.maxDistance = audioSource.maxDistance;
				AnimationCurve customCurve = audioSource.GetCustomCurve(AudioSourceCurveType.CustomRolloff);
				pooledAudioSource.SetCustomCurve(AudioSourceCurveType.CustomRolloff, customCurve);
			}
			else if (defaultAudio != null)
			{
				AudioSource audioSource2 = defaultAudio;
				pooledAudioSource.dopplerLevel = audioSource2.dopplerLevel;
				pooledAudioSource.spread = audioSource2.spread;
				pooledAudioSource.maxDistance = audioSource2.maxDistance;
				AnimationCurve customCurve2 = audioSource2.GetCustomCurve(AudioSourceCurveType.CustomRolloff);
				pooledAudioSource.SetCustomCurve(AudioSourceCurveType.CustomRolloff, customCurve2);
			}
			pooledAudioSource.outputAudioMixerGroup = instance.gameMixer;
			pooledAudioSource.transform.position = from.position;
			pooledAudioSource.volume = volume;
			pooledAudioSource.pitch = pitch;
			pooledAudioSource.clip = clip;
			pooledAudioSource.spatialBlend = spatial;
			pooledAudioSource.reverbZoneMix = reverbMix;
			pooledAudioSource.ignoreListenerPause = false;
			pooledAudioSource.gameObject.SetActive(value: true);
			if (mixerGroup != null)
			{
				Debug.Log("Playing Sound on special mixer: " + clip.name);
				pooledAudioSource.outputAudioMixerGroup = mixerGroup;
			}
			else
			{
				pooledAudioSource.outputAudioMixerGroup = instance.gameMixer;
			}
			pooledAudioSource.Play();
			instance.softParentedAudioSources.Add(new SoftParentedAudio
			{
				source = pooledAudioSource,
				softParent = from
			});
		}
	}

	private void LateUpdate()
	{
		int count = instance.softParentedAudioSources.Count;
		while (count-- > 0)
		{
			SoftParentedAudio softParentedAudio = instance.softParentedAudioSources[count];
			bool flag = false;
			if (softParentedAudio.softParent != null)
			{
				softParentedAudio.source.transform.SetPositionAndRotation(softParentedAudio.softParent.position, softParentedAudio.softParent.rotation);
			}
			if (!softParentedAudio.source.isPlaying)
			{
				flag = true;
			}
			if (flag)
			{
				softParentedAudio.source.Stop();
				softParentedAudio.source.clip = null;
				softParentedAudio.source.gameObject.SetActive(value: false);
				audioSourcePool.Enqueue(softParentedAudio.source);
				instance.softParentedAudioSources.RemoveAtSwapBack(count);
			}
		}
		gameMixer.audioMixer.GetFloat("pitch", out var value);
		float b = Time.deltaTime / CL_GameManager.GetPlayerPerceivedDeltaTime() * gameMixerPitchMult;
		float num = Mathf.Lerp(value, b, CL_GameManager.GetPlayerPerceivedDeltaTime() * 8f);
		if (!float.IsFinite(num))
		{
			num = 1f;
		}
		gameMixer.audioMixer.SetFloat("pitch", num);
	}

	public static AudioSource PlayUISound(AudioClip clip, float volume = 1f, float pitch = 1f)
	{
		if (instance == null)
		{
			Debug.LogWarning("AudioManager instance not found.");
			return null;
		}
		AudioSource pooledAudioSource = instance.GetPooledAudioSource();
		pooledAudioSource.ignoreListenerPause = true;
		pooledAudioSource.outputAudioMixerGroup = instance.UIMixer;
		pooledAudioSource.transform.position = Vector3.zero;
		pooledAudioSource.volume = volume;
		pooledAudioSource.pitch = pitch;
		pooledAudioSource.clip = clip;
		pooledAudioSource.spatialBlend = 0f;
		pooledAudioSource.reverbZoneMix = 0.3f;
		pooledAudioSource.gameObject.SetActive(value: true);
		pooledAudioSource.Play();
		instance.StartCoroutine(instance.ReturnToPoolAfterPlaying(pooledAudioSource));
		return pooledAudioSource;
	}

	public static void PlayUISound(string clipName, float volume = 1f, float pitch = 1f)
	{
		if (instance == null)
		{
			Debug.LogWarning("AudioManager instance not found.");
			return;
		}
		AudioSource pooledAudioSource = instance.GetPooledAudioSource();
		pooledAudioSource.ignoreListenerPause = true;
		pooledAudioSource.outputAudioMixerGroup = instance.UIMixer;
		pooledAudioSource.transform.position = Vector3.zero;
		pooledAudioSource.volume = volume;
		pooledAudioSource.pitch = pitch;
		pooledAudioSource.clip = instance.GetAudioClip(clipName);
		pooledAudioSource.spatialBlend = 0f;
		pooledAudioSource.gameObject.SetActive(value: true);
		pooledAudioSource.reverbZoneMix = 0.3f;
		pooledAudioSource.Play();
		instance.StartCoroutine(instance.ReturnToPoolAfterPlaying(pooledAudioSource));
	}

	private AudioSource GetPooledAudioSource()
	{
		if (audioSourcePool.Count > 0)
		{
			return audioSourcePool.Dequeue();
		}
		return UnityEngine.Object.Instantiate(audioSourcePrefab, poolParent).GetComponent<AudioSource>();
	}

	private IEnumerator ReturnToPoolAfterPlaying(AudioSource audioSource)
	{
		if (audioSource.clip != null)
		{
			yield return new WaitForSeconds(audioSource.clip.length);
		}
		audioSource.Stop();
		audioSource.clip = null;
		audioSource.gameObject.SetActive(value: false);
		audioSourcePool.Enqueue(audioSource);
	}

	public void AdjustVolume(float sVol, float mVol)
	{
		mixer.SetFloat("musicVol", mVol);
		mixer.SetFloat("soundVol", sVol);
	}

	public static void PlayTrack(string t)
	{
		instance.StopCoroutine("FadeOut");
		instance.StopAllCoroutines();
		foreach (AudioSource aud in auds)
		{
			aud.Stop();
		}
		auds[0].clip = musicLibrary[t].clip;
		auds[0].loop = musicLibrary[t].loop;
		auds[0].volume = musicLibrary[t].volume;
		auds[0].Play();
	}

	public static void PlayTrack(AudioClip c, bool loop = false, float volume = 1f, bool fadeIn = false, float fadeTime = 1f, int track = 0)
	{
		if (fadeCoroutines.ContainsKey(track))
		{
			instance.StopCoroutine(fadeCoroutines[track]);
		}
		auds[track].clip = c;
		auds[track].loop = loop;
		auds[track].volume = volume;
		auds[track].Play();
		if (fadeIn)
		{
			auds[track].volume = 0f;
			fadeCoroutines[track] = instance.StartCoroutine(instance.FadeIn(auds[track], 1f / fadeTime));
		}
	}

	public static void PlayTrack(string t, int a = 0, bool stopAll = true, float volume = 1f)
	{
		instance.StopCoroutine("FadeOut");
		instance.StopAllCoroutines();
		if (stopAll)
		{
			foreach (AudioSource aud in auds)
			{
				aud.Stop();
			}
		}
		auds[a].clip = musicLibrary[t].clip;
		auds[a].loop = musicLibrary[t].loop;
		auds[a].volume = musicLibrary[t].volume;
		auds[a].Play();
		CommandConsole.Log("Playing Track: " + t);
	}

	public static void StopMusic()
	{
		instance.StopCoroutine("FadeOut");
		instance.StopAllCoroutines();
		for (int i = 0; i < auds.Count; i++)
		{
			auds[i].Stop();
		}
	}

	public static void FadeOutMusic(float rate = 1f)
	{
		if (rate <= 0f)
		{
			rate = 0.01f;
		}
		instance.StopAllCoroutines();
		instance.StartCoroutine(instance.FadeOut(auds[0], 1f / rate));
	}

	public IEnumerator FadeOut(AudioSource audiosource, float fadeRate)
	{
		while (audiosource.volume > 0f)
		{
			audiosource.volume -= Time.unscaledDeltaTime * fadeRate;
			yield return new WaitForEndOfFrame();
		}
	}

	public IEnumerator FadeIn(AudioSource audiosource, float fadeRate)
	{
		while (audiosource.volume < 1f)
		{
			audiosource.volume += Time.unscaledDeltaTime * fadeRate;
			yield return new WaitForEndOfFrame();
		}
	}

	public static void SetMusicVolumeSetting(float f)
	{
		targetMusicVolume = f;
		instance.soundtrackMixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-30f, 0f, f));
	}

	public AudioClip GetAudioClip(string a)
	{
		foreach (AudioClip clip in clips)
		{
			if (clip.name == a)
			{
				return clip;
			}
		}
		return clips[0];
	}

	public static AudioClip GetAudioClipFromList(string h)
	{
		if (!instance.clipDict.ContainsKey(h))
		{
			return null;
		}
		return instance.clipDict[h].clips[UnityEngine.Random.Range(0, instance.clipDict[h].clips.Count)];
	}

	public static void AddListener(Listener_Core l)
	{
		if (listeners == null)
		{
			listeners = new List<Listener_Core>();
		}
		if (!listeners.Contains(l))
		{
			listeners.Add(l);
		}
	}

	public static void RemoveListener(Listener_Core l)
	{
		if (listeners != null && listeners.Contains(l))
		{
			listeners.Remove(l);
		}
	}

	public static void PlayListenedSound(string tag, Vector3 position, float radius)
	{
		if (CL_UIManager.debug)
		{
			CL_DebugView.draw.Cross(position, Color.Lerp(Color.yellow, Color.red, radius / 10f));
		}
		if (listeners == null || listeners.Count == 0)
		{
			return;
		}
		for (int num = listeners.Count - 1; num >= 0; num--)
		{
			Listener_Core listener_Core = listeners[num];
			if (listeners[num] == null)
			{
				listeners.RemoveAt(num);
			}
			else
			{
				float manhattanDistance = DarkMachineFunctions.GetManhattanDistance(position, listener_Core.GetPosition());
				if (manhattanDistance < radius)
				{
					Listener_Core.ListenEvent listenEvent = new Listener_Core.ListenEvent();
					listenEvent.tag = tag;
					listenEvent.position = position;
					listenEvent.distance = manhattanDistance;
					listenEvent.volume = 1f;
					listener_Core.CatchSound(listenEvent);
					if (CL_UIManager.debug)
					{
						CL_DebugView.draw.Cross(position, Color.green);
						CL_DebugView.draw.Arrow(listener_Core.GetPosition(), position, Color.green);
					}
				}
			}
		}
	}

	public static void PlaySubtitle(string groupID, string subtitleID, Transform parent, bool isAmbient = true, bool isGlobal = true, float radius = 15f)
	{
		CL_UIManager.SubtitleId id = CL_UIManager.SubtitleCreate(CL_LocalizationManager.currentLocalization.GetLine(groupID, subtitleID), "");
		CL_UIManager.SubtitleFlags subtitleFlags = CL_UIManager.SubtitleFlags.Default;
		if (isAmbient)
		{
			subtitleFlags |= CL_UIManager.SubtitleFlags.Ambient;
		}
		CL_UIManager.SubtitleFlagsSet(id, subtitleFlags);
		if (!isGlobal && parent != null)
		{
			CL_UIManager.SubtitleSpace(id, parent, Vector3.zero, radius);
		}
	}
}
