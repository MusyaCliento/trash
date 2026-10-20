using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GamemodeSlideshowController : MonoBehaviour
{
	[Serializable]
	public class SlideHolder
	{
		public List<Sprite> slideImages;

		public string unlockFlagID;

		public bool IsUnlocked()
		{
			if (unlockFlagID == "")
			{
				return true;
			}
			return StatManager.saveData.GetFlagState(unlockFlagID);
		}

		public Sprite GetRandomSlideSprite()
		{
			if (slideImages == null || slideImages.Count == 0)
			{
				return null;
			}
			int index = UnityEngine.Random.Range(0, slideImages.Count);
			return slideImages[index];
		}
	}

	[Header("Slide Data")]
	public List<SlideHolder> slides;

	private List<SlideHolder> currentSlides = new List<SlideHolder>();

	[Header("UI References")]
	public Image imageForeground;

	public Image imageBackground;

	[Header("Timing")]
	public float displayTime = 2f;

	public float fadeDuration = 1f;

	private bool isForegroundActive = true;

	private void Start()
	{
		if (slides == null || slides.Count == 0)
		{
			Debug.LogWarning("No slides assigned to the slideshow.");
			return;
		}
		foreach (SlideHolder slide in slides)
		{
			if (slide.IsUnlocked())
			{
				currentSlides.Add(slide);
			}
		}
	}

	private void OnEnable()
	{
		StopAllCoroutines();
		StartCoroutine(SlideshowLoop());
	}

	private IEnumerator SlideshowLoop()
	{
		yield return null;
		imageForeground.sprite = currentSlides[0].GetRandomSlideSprite();
		SetImageAlpha(imageForeground, 1f);
		SetImageAlpha(imageBackground, 0f);
		int currentIndex = 0;
		yield return new WaitForSeconds(displayTime);
		while (true)
		{
			int nextIndex = (currentIndex + 1) % currentSlides.Count;
			Sprite randomSlideSprite = currentSlides[nextIndex].GetRandomSlideSprite();
			if (isForegroundActive)
			{
				imageBackground.sprite = randomSlideSprite;
				SetImageAlpha(imageBackground, 1f);
				yield return StartCoroutine(FadeOut(imageForeground));
				isForegroundActive = false;
			}
			else
			{
				imageForeground.sprite = randomSlideSprite;
				SetImageAlpha(imageForeground, 0f);
				yield return StartCoroutine(FadeIn(imageForeground));
				SetImageAlpha(imageBackground, 0f);
				isForegroundActive = true;
			}
			currentIndex = nextIndex;
			yield return new WaitForSeconds(displayTime);
		}
	}

	private IEnumerator FadeIn(Image img)
	{
		float elapsed = 0f;
		SetImageAlpha(img, 0f);
		while (elapsed < fadeDuration)
		{
			elapsed += Time.deltaTime;
			float alpha = Mathf.Clamp01(elapsed / fadeDuration);
			SetImageAlpha(img, alpha);
			yield return null;
		}
		SetImageAlpha(img, 1f);
	}

	private IEnumerator FadeOut(Image img)
	{
		float elapsed = 0f;
		SetImageAlpha(img, 1f);
		while (elapsed < fadeDuration)
		{
			elapsed += Time.deltaTime;
			float num = Mathf.Clamp01(elapsed / fadeDuration);
			SetImageAlpha(img, 1f - num);
			yield return null;
		}
		SetImageAlpha(img, 0f);
	}

	private void SetImageAlpha(Image img, float alpha)
	{
		if (!(img == null))
		{
			Color color = img.color;
			color.a = alpha;
			img.color = color;
		}
	}
}
