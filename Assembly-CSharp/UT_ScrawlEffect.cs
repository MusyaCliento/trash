using UnityEngine;

public class UT_ScrawlEffect : MonoBehaviour
{
	public enum ScrawlType
	{
		header = 0,
		ascentHeader = 1,
		highscoreHeader = 2,
		tip = 3,
		descriptor = 4
	}

	private CL_GameManager gMan;

	private AudioSource aud;

	public AudioClip playEffect;

	public ScrawlType type;

	[TextArea]
	public string playScrawl;

	private void Start()
	{
		gMan = GameObject.Find("GameManager").GetComponent<CL_GameManager>();
		aud = GetComponent<AudioSource>();
	}

	public void Play()
	{
		if (!base.enabled)
		{
			return;
		}
		if (playScrawl != "")
		{
			if (type == ScrawlType.header)
			{
				gMan.uiMan.header.ShowText(playScrawl);
			}
			else if (type == ScrawlType.ascentHeader)
			{
				gMan.uiMan.ascentHeader.ShowText(playScrawl);
			}
			else if (type == ScrawlType.highscoreHeader)
			{
				gMan.uiMan.highscoreHeader.ShowText(playScrawl);
			}
			else if (type == ScrawlType.tip)
			{
				gMan.uiMan.tipHeader.ShowText(playScrawl);
			}
		}
		if (playEffect != null)
		{
			aud.clip = playEffect;
			aud.Play();
		}
	}

	public void PlayString(string s)
	{
		if (s != "")
		{
			if (type == ScrawlType.header)
			{
				gMan.uiMan.header.ShowText(s);
			}
			else if (type == ScrawlType.ascentHeader)
			{
				gMan.uiMan.ascentHeader.ShowText(s);
			}
			else if (type == ScrawlType.highscoreHeader)
			{
				gMan.uiMan.highscoreHeader.ShowText(s);
			}
			else if (type == ScrawlType.tip)
			{
				gMan.uiMan.tipHeader.ShowText(s);
			}
		}
		if (playEffect != null)
		{
			aud.clip = playEffect;
			aud.Play();
		}
	}
}
