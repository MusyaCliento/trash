using System.Collections;
using UnityEngine;

public class UT_SpriteFade : MonoBehaviour
{
	public SpriteRenderer spriteRenderer;

	public float changeRate = 1f;

	private void Start()
	{
		if (spriteRenderer == null)
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}
	}

	public void FadeSprite(float targetAlpha)
	{
		StopAllCoroutines();
		StartCoroutine(FadeTo());
		IEnumerator FadeTo()
		{
			float timer = 0f;
			Color startColor = spriteRenderer.color;
			Color targetColor = spriteRenderer.color;
			targetColor.a = targetAlpha;
			while (timer < 1f)
			{
				timer += Time.deltaTime * changeRate;
				spriteRenderer.color = Color.Lerp(startColor, targetColor, timer);
				yield return null;
			}
		}
	}
}
