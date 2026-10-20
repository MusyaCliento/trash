using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class UT_AudioEffects : MonoBehaviour
{
	private AudioSource aud;

	public bool slowPitch;

	public bool lerpVolume;

	public float lerpSpeed = 1f;

	public float pitchSpeed = 1f;

	private float targetPitch;

	private float targetVolume;

	public bool setStartVolume;

	public float startVolume;

	private void Awake()
	{
		aud = GetComponent<AudioSource>();
		if (setStartVolume)
		{
			aud.volume = startVolume;
			targetVolume = startVolume;
			return;
		}
		targetVolume = aud.volume;
		startVolume = aud.volume;
		if (startVolume == 0f)
		{
			startVolume = 1f;
		}
	}

	private void Update()
	{
		if (!CL_GameManager.gMan.isPaused)
		{
			if (slowPitch)
			{
				aud.pitch = Mathf.Lerp(aud.pitch, targetPitch, Time.deltaTime * pitchSpeed);
			}
			if (lerpVolume)
			{
				aud.volume = Mathf.Lerp(aud.volume, targetVolume, lerpSpeed * Time.deltaTime);
			}
		}
	}

	public void SetPitch(float f)
	{
		if (!slowPitch)
		{
			aud.pitch = f;
		}
		targetPitch = f;
	}

	public void SetVolume(float f)
	{
		if (!(aud == null))
		{
			if (!aud.isPlaying)
			{
				aud.Play();
			}
			targetVolume = f;
		}
	}

	public void FadeOut()
	{
		targetVolume = 0f;
	}

	public void FadeIn()
	{
		if (!(aud == null))
		{
			targetVolume = startVolume;
			if (!aud.isPlaying)
			{
				aud.Play();
			}
		}
	}
}
