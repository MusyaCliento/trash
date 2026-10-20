using UnityEngine;

public class OS_SoundPlayer : MonoBehaviour
{
	public string soundName;

	public bool loop;

	public bool playOnAwake;

	private void OnEnable()
	{
		if (playOnAwake)
		{
			Play();
		}
	}

	public void Play()
	{
		if (!(OS_Manager.soundPlayer == null))
		{
			OS_Manager.soundPlayer.PlaySound("os:" + soundName);
		}
	}
}
