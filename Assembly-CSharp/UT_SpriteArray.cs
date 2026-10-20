using System.Collections.Generic;
using UnityEngine;

public class UT_SpriteArray : MonoBehaviour
{
	public SpriteRenderer spriteRenderer;

	public List<Sprite> sprites;

	private int curSprite;

	public void Increment()
	{
		curSprite++;
		if (curSprite >= sprites.Count)
		{
			curSprite = 0;
		}
		spriteRenderer.sprite = sprites[curSprite];
	}
}
