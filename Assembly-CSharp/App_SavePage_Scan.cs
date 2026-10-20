using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class App_SavePage_Scan : MonoBehaviour
{
	public Transform crosshair;

	public Image image;

	public Image foreground;

	public List<Sprite> sprites;

	public List<Sprite> foregroundSprites;

	private float imageTime = 1f;

	private float foregroundTime = 0.3f;

	public float imageSpeed = 1f;

	public List<AudioClip> imageAudio;

	private Vector3 crosshairTarget;

	private float crosshairRotation;

	private void Start()
	{
		crosshairTarget = Vector3.Scale(Random.insideUnitSphere, new Vector3(250f, 150f, 0f));
	}

	private void Update()
	{
		imageTime += Time.unscaledDeltaTime * imageSpeed;
		foregroundTime += Time.unscaledDeltaTime * imageSpeed;
		if (imageTime >= 1f)
		{
			image.sprite = sprites[Random.Range(0, sprites.Count)];
			imageTime = 0f;
			if (imageAudio != null && imageAudio.Count > 0)
			{
				AudioManager.PlayUISound(imageAudio[Random.Range(0, imageAudio.Count)]);
			}
			crosshairTarget = Vector3.Scale(Random.insideUnitSphere, new Vector3(250f, 150f, 0f));
		}
		if (foregroundTime >= 0.5f)
		{
			foreground.sprite = sprites[Random.Range(0, sprites.Count)];
			foregroundTime = 0f;
			if (imageAudio != null && imageAudio.Count > 0)
			{
				AudioManager.PlayUISound(imageAudio[Random.Range(0, imageAudio.Count)], 0.5f, 1.5f);
			}
			crosshairRotation = Random.Range(-15, 15);
		}
		foreground.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 1.2f, foregroundTime);
		image.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 1.3f, imageTime);
		if (crosshair != null)
		{
			crosshair.localPosition = Vector3.Lerp(crosshair.localPosition, crosshairTarget, Time.unscaledDeltaTime * 4f);
			crosshair.rotation = Quaternion.Lerp(crosshair.rotation, Quaternion.Euler(0f, 0f, crosshairRotation), Time.unscaledDeltaTime * 5f);
		}
	}
}
