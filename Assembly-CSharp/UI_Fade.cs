using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI_Fade : MonoBehaviour
{
	public enum StartFade
	{
		none = 0,
		fadeIn = 1,
		fadeOut = 2
	}

	public StartFade startFade;

	public float startFadeTime = 1f;

	public float fadeSpeed = 1f;

	private Image fadeImage;

	private Color fadeTarget;

	private Color fadeColor;

	private void Start()
	{
		fadeImage = GetComponent<Image>();
		fadeColor = fadeImage.color;
		StartCoroutine(BeginFade());
	}

	private IEnumerator BeginFade()
	{
		if (startFade == StartFade.fadeOut)
		{
			fadeImage.color = Color.clear;
		}
		fadeTarget = fadeImage.color;
		yield return new WaitForSeconds(startFadeTime);
		switch (startFade)
		{
		case StartFade.none:
			fadeTarget = fadeImage.color;
			break;
		case StartFade.fadeIn:
			fadeTarget = Color.clear;
			break;
		case StartFade.fadeOut:
			fadeImage.color = Color.clear;
			fadeTarget = fadeColor;
			break;
		}
	}

	public void FadeIn()
	{
		fadeTarget = Color.clear;
	}

	public void FadeOut()
	{
		fadeTarget = fadeColor;
	}

	private void Update()
	{
		fadeImage.color = Color.Lerp(fadeImage.color, fadeTarget, Time.deltaTime * fadeSpeed);
	}
}
