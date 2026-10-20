using UnityEngine;

public class UT_PlaySoundOnProximity : MonoBehaviour
{
	private AudioSource aud;

	public bool playOnce = true;

	private void Start()
	{
		aud = GetComponent<AudioSource>();
	}

	private void Update()
	{
	}
}
