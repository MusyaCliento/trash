using UnityEngine;

public class UT_EventZone : MonoBehaviour
{
	private CL_GameManager gMan;

	private AudioSource aud;

	public bool active = true;

	public AudioClip enterEffect;

	public AudioClip exitEffect;

	public string enterScrawl;

	public string exitScrawl;

	public bool runOnce;

	private bool hasRun;

	public string[] triggerTags = new string[1] { "Player" };

	public string triggerMessage;

	public TransformEvent enterEvent;

	public TransformEvent exitEvent;

	public TransformEvent stayEvent;

	public bool pathfinderZone;

	private void Start()
	{
		gMan = GameObject.Find("GameManager").GetComponent<CL_GameManager>();
		aud = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (hasRun || !active)
		{
			return;
		}
		string[] array = triggerTags;
		foreach (string text in array)
		{
			if (other.tag == text)
			{
				if (enterScrawl != "")
				{
					gMan.uiMan.header.ShowText(enterScrawl);
				}
				if (enterEffect != null)
				{
					aud.clip = enterEffect;
					aud.Play();
				}
				enterEvent.Invoke(other.transform);
				if (triggerMessage != null && triggerMessage != "")
				{
					other.gameObject.SendMessage(triggerMessage);
				}
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (hasRun || !active)
		{
			return;
		}
		string[] array = triggerTags;
		foreach (string text in array)
		{
			if (other.tag == text)
			{
				if (exitScrawl != "")
				{
					gMan.uiMan.header.ShowText(exitScrawl);
				}
				if (exitEffect != null)
				{
					aud.clip = exitEffect;
					aud.Play();
				}
				if (runOnce)
				{
					hasRun = true;
				}
				exitEvent.Invoke(other.transform);
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (hasRun || !active)
		{
			return;
		}
		string[] array = triggerTags;
		foreach (string text in array)
		{
			if (other.tag == text)
			{
				stayEvent.Invoke(other.transform);
			}
		}
	}

	public void SetActive(bool b)
	{
		active = b;
	}
}
