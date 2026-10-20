using System.Collections.Generic;
using UnityEngine;

public class UT_AnimatedTexture : MonoBehaviour
{
	private Material m;

	public List<Texture2D> frames;

	public SpriteRenderer spriteRenderer;

	public List<Sprite> spriteFrames;

	public float framerate = 30f;

	private int currentFrame;

	public float offset;

	private float frameTime;

	private void Start()
	{
		frameTime = offset;
		if (spriteRenderer == null)
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}
		MeshRenderer component = GetComponent<MeshRenderer>();
		if (component != null)
		{
			m = component.material;
		}
	}

	private void Update()
	{
		if (frameTime <= 0f)
		{
			frameTime = 1f / framerate;
			currentFrame++;
			if (spriteRenderer == null)
			{
				if (currentFrame >= frames.Count)
				{
					currentFrame = 0;
				}
				m.mainTexture = frames[currentFrame];
			}
			else
			{
				if (currentFrame >= spriteFrames.Count)
				{
					currentFrame = 0;
				}
				spriteRenderer.sprite = spriteFrames[currentFrame];
			}
		}
		frameTime -= Time.deltaTime;
	}
}
