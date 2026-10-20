using UnityEngine;

public class UT_PsychicCommunicator : MonoBehaviour
{
	public HUD_CustomElement_PsychicCommunication psychicCommunicationPrefab;

	public float showTime = 5f;

	public string text;

	public Sprite image;

	public float imageHoldTime = 1f;

	public float imageFadeTime = 2f;

	public AudioClip clip;

	public UT_AudioClipHandler clipHandler;

	public string clipHandlerID;

	public float audioFlareMult = 2f;

	public float darken = 0.05f;

	private void Start()
	{
		if (clipHandler != null && clipHandlerID != "")
		{
			clip = clipHandler.GetSound(clipHandlerID);
		}
	}

	public void Activate()
	{
		HUD_CustomElement_PsychicCommunication hUD_CustomElement_PsychicCommunication = (HUD_CustomElement_PsychicCommunication)CL_UIManager.instance.AddCustomHudElement(psychicCommunicationPrefab);
		hUD_CustomElement_PsychicCommunication.Show(showTime, darken);
		if (image != null)
		{
			hUD_CustomElement_PsychicCommunication.ShowImage(image, imageFadeTime, imageHoldTime);
		}
		hUD_CustomElement_PsychicCommunication.PlaySubtitle(text);
		if (clipHandler != null && clipHandlerID != "")
		{
			clip = clipHandler.GetSound(clipHandlerID);
		}
		if (clip != null)
		{
			hUD_CustomElement_PsychicCommunication.PlayAudio(clip, audioFlareMult);
		}
	}

	public void PlayString(string s)
	{
		HUD_CustomElement_PsychicCommunication hUD_CustomElement_PsychicCommunication = (HUD_CustomElement_PsychicCommunication)CL_UIManager.instance.AddCustomHudElement(psychicCommunicationPrefab);
		hUD_CustomElement_PsychicCommunication.Show(showTime, darken);
		if (image != null)
		{
			hUD_CustomElement_PsychicCommunication.ShowImage(image, imageFadeTime, imageHoldTime);
		}
		hUD_CustomElement_PsychicCommunication.PlaySubtitle(s);
		if (clipHandler != null && clipHandlerID != "")
		{
			clip = clipHandler.GetSound(clipHandlerID);
		}
		if (clip != null)
		{
			hUD_CustomElement_PsychicCommunication.PlayAudio(clip, audioFlareMult);
		}
	}

	public void SetClipHandlerID(string s)
	{
		clipHandlerID = s;
		if (clipHandler != null && clipHandlerID != "")
		{
			clip = clipHandler.GetSound(clipHandlerID);
		}
	}

	public void SetDarken(float f)
	{
		darken = f;
	}

	public void AudioFlareMult(float f)
	{
		audioFlareMult = f;
	}
}
