using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SessionEventModule_FlashVignette : SessionEventModule
{
	public string vignetteID;

	public bool useCustomSprite;

	public List<Sprite> customSprites;

	public bool useCustomColor;

	public Color customColor = Color.white;

	public override void Initialize(SessionEvent s)
	{
		base.Initialize(s);
		Activate();
	}

	public override void Activate()
	{
		base.Activate();
		Play();
	}

	public void Play()
	{
		if (useCustomSprite)
		{
			CL_UIManager.instance.SetVignetteImage(vignetteID, customSprites[UnityEngine.Random.Range(0, customSprites.Count)]);
		}
		if (useCustomColor)
		{
			CL_UIManager.instance.SetVignetteColor(vignetteID, customColor);
		}
		CL_UIManager.instance.FlashVignette(vignetteID);
	}
}
