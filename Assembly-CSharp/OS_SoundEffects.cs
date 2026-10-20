using System;
using System.Collections.Generic;
using UnityEngine;

public class OS_SoundEffects : MonoBehaviour
{
	public enum SoundType
	{
		click = 0,
		tap = 1,
		dragStart = 2,
		dragEnd = 3,
		error = 4,
		open = 5
	}

	public List<AudioClip> clickSounds;

	public List<AudioClip> dragStartSounds;

	public List<AudioClip> dragEndSounds;

	public List<AudioClip> tapSounds;

	public List<AudioClip> errorSounds;

	public List<AudioClip> openSounds;

	public AudioSource aud;

	public static Action<SoundType> PlaySystemSound;

	public static Action<AudioClip> PlayMusicTrack;

	private void OnEnable()
	{
		PlayMusicTrack = (Action<AudioClip>)Delegate.Combine(PlayMusicTrack, new Action<AudioClip>(PlayMusic));
	}

	private void OnDisable()
	{
		PlayMusicTrack = (Action<AudioClip>)Delegate.Remove(PlayMusicTrack, new Action<AudioClip>(PlayMusic));
	}

	private void Start()
	{
		aud = GetComponent<AudioSource>();
	}

	private void Update()
	{
	}

	public void PlayMusic(AudioClip clip)
	{
		aud.clip = clip;
		aud.Play();
	}
}
