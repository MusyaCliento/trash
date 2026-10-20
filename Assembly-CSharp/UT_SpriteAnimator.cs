using System;
using System.Collections.Generic;
using UnityEngine;

public class UT_SpriteAnimator : MonoBehaviour
{
	[Serializable]
	public class SpriteAnimation
	{
		public string name;

		public List<Sprite> sprites;

		public float animationSpeed = 1f;
	}

	public List<SpriteAnimation> animations;

	private SpriteRenderer spriteRenderer;

	public string startAnimationName;

	private SpriteAnimation currentAnimation;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		SetAnimation(startAnimationName);
	}

	private void Update()
	{
		if (currentAnimation != null)
		{
			PlayAnimation();
		}
	}

	private void PlayAnimation()
	{
		int index = Mathf.FloorToInt(Mathf.Repeat(Time.time * currentAnimation.animationSpeed, currentAnimation.sprites.Count));
		Sprite sprite = currentAnimation.sprites[index];
		spriteRenderer.sprite = sprite;
	}

	public void SetAnimation(string s)
	{
		foreach (SpriteAnimation animation in animations)
		{
			if (animation.name == s)
			{
				currentAnimation = animation;
				break;
			}
		}
	}
}
