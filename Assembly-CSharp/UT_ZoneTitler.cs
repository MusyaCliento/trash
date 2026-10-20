using UnityEngine;

public class UT_ZoneTitler : MonoBehaviour
{
	private CL_GameManager gMan;

	private AudioSource aud;

	public AudioClip playEffect;

	public float volume = 1f;

	public string region;

	public string subRegion;

	private void Start()
	{
		gMan = GameObject.Find("GameManager").GetComponent<CL_GameManager>();
		aud = GetComponent<AudioSource>();
	}

	public void Play()
	{
		string text = (CL_GameManager.IsHardmode() ? "<color=red>" : "") + "<size=40>" + region + "</size>" + (CL_GameManager.IsHardmode() ? "</color>" : "") + "\n<color=grey>" + subRegion;
		Debug.Log(text);
		if (region != "" && gMan != null)
		{
			gMan.uiMan.header.ShowText(text);
		}
		if (playEffect != null)
		{
			if (aud != null)
			{
				aud.clip = playEffect;
				aud.Play();
			}
			else
			{
				AudioManager.PlayUISound(playEffect, volume);
			}
		}
	}
}
