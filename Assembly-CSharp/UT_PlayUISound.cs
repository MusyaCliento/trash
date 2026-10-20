using UnityEngine;

public class UT_PlayUISound : MonoBehaviour
{
	public float volume = 1f;

	public AudioClip audioClip;

	public void PlaySound(AudioClip clip)
	{
		AudioManager.PlayUISound(clip, volume);
	}

	public void PlaySound()
	{
		AudioManager.PlayUISound(audioClip, volume);
	}
}
