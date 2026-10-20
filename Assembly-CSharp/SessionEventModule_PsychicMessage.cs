using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SessionEventModule_PsychicMessage : SessionEventModule
{
	public HUD_CustomElement_PsychicCommunication psychicCommunicationPrefab;

	public float showTime = 5f;

	public List<string> text;

	public Sprite image;

	public float imageHoldTime = 1f;

	public float imageFadeTime = 2f;

	public List<AudioClip> clips;

	public float audioFlareMult = 2f;

	public float darken = 0.05f;

	public override void Initialize(SessionEvent s)
	{
		base.Initialize(s);
		Activate();
	}

	public override void Activate()
	{
		base.Activate();
		HUD_CustomElement_PsychicCommunication hUD_CustomElement_PsychicCommunication = (HUD_CustomElement_PsychicCommunication)CL_UIManager.instance.AddCustomHudElement(psychicCommunicationPrefab);
		hUD_CustomElement_PsychicCommunication.Show(showTime, darken);
		if (image != null)
		{
			hUD_CustomElement_PsychicCommunication.ShowImage(image, imageFadeTime, imageHoldTime);
		}
		hUD_CustomElement_PsychicCommunication.PlaySubtitle(text[UnityEngine.Random.Range(0, text.Count)]);
		if (clips != null && clips.Count > 0)
		{
			hUD_CustomElement_PsychicCommunication.PlayAudio(clips[UnityEngine.Random.Range(0, clips.Count)], audioFlareMult);
		}
	}
}
