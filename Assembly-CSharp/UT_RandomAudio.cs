using System.Collections.Generic;
using UnityEngine;

public class UT_RandomAudio : MonoBehaviour
{
	public List<AudioClip> clips = new List<AudioClip>();

	public AudioSource aud;

	public float spacial = 1f;

	public float pitchModulation;

	public bool playOnStart;

	private void Awake()
	{
		if (aud == null)
		{
			aud = GetComponent<AudioSource>();
		}
		if (playOnStart)
		{
			Play();
		}
	}

	public void Play()
	{
		if (aud == null)
		{
			AudioManager.PlaySound(clips[Random.Range(0, clips.Count)], base.transform.position, 1f, 1f + Random.Range(0f - pitchModulation, pitchModulation), spacial);
			return;
		}
		aud.clip = clips[Random.Range(0, clips.Count)];
		if (pitchModulation > 0f)
		{
			aud.pitch = 1f + Random.Range(0f - pitchModulation, pitchModulation);
		}
		aud.Play();
	}
}
