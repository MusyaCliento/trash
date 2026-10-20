using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UT_SoundtrackMixer : MonoBehaviour
{
	private enum MixType
	{
		Standard = 0,
		DistanceBlend = 1
	}

	[SerializeField]
	private MixType type;

	public List<AudioClip> clips = new List<AudioClip>();

	[SerializeField]
	private AudioMixerGroup mixer;

	private Transform target;

	[SerializeField]
	private float blendDistance = 1f;

	[SerializeField]
	private float soundDistance = 15f;

	[SerializeField]
	private float volume = 1f;

	private List<AudioSource> auds = new List<AudioSource>();

	private bool running;

	private void Start()
	{
		for (int i = 0; i < clips.Count; i++)
		{
			auds.Add(base.gameObject.AddComponent<AudioSource>());
			auds[i].loop = true;
			auds[i].bypassReverbZones = true;
			auds[i].outputAudioMixerGroup = mixer;
			auds[i].clip = clips[i];
			auds[i].playOnAwake = false;
		}
	}

	private void Update()
	{
		if (running && type == MixType.DistanceBlend)
		{
			DistanceBlend();
		}
	}

	private void DistanceBlend()
	{
		float num = Vector3.Distance(target.position, base.transform.position);
		Mathf.Clamp01(num / blendDistance);
		for (int i = 0; i < clips.Count; i++)
		{
			float num2 = soundDistance * ((float)i / (float)clips.Count);
			float num3 = (num2 - num) / num2;
			if (num > num2)
			{
				num3 = 0f;
			}
			auds[i].volume = num3 * volume;
		}
	}

	public void SetBlendTarget(Transform t)
	{
		target = t;
	}

	public void Play()
	{
		running = true;
		foreach (AudioSource aud in auds)
		{
			aud.Play();
		}
	}

	public void Pause()
	{
		running = false;
		foreach (AudioSource aud in auds)
		{
			aud.Pause();
		}
	}
}
