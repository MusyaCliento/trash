using UnityEngine;

public class UT_SoundtrackController : MonoBehaviour
{
	public float fadeTime;

	public int track;

	public float volume = 0.9f;

	public void PlaySong(string songName)
	{
		AudioManager.PlayTrack(songName);
	}

	public void StopMusic()
	{
		AudioManager.StopMusic();
	}

	public void FadeOut()
	{
		AudioManager.FadeOutMusic(fadeTime);
	}

	public void PlaySongAsset(AudioClip song)
	{
		AudioManager.PlayTrack(song, loop: false, volume, fadeTime > 0f, fadeTime, track);
	}

	public void PlayLoopedSongAsset(AudioClip song)
	{
		AudioManager.PlayTrack(song, loop: true, volume, fadeTime > 0f, fadeTime, track);
	}

	public void SetFadeTime(float f)
	{
		fadeTime = f;
	}
}
