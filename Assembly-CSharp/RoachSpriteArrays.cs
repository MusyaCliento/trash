using UnityEngine;

public class RoachSpriteArrays : MonoBehaviour
{
	[SerializeField]
	private Sprite[] RegSprites;

	[SerializeField]
	private Sprite[] SwapSprites;

	[SerializeField]
	private SpriteRenderer[] BodyParts;

	public Material roachMaterial;

	private void Start()
	{
		for (int i = 0; i < BodyParts.Length; i++)
		{
			if (roachMaterial != null)
			{
				BodyParts[i].material = roachMaterial;
			}
		}
	}

	private void LateUpdate()
	{
		for (int i = 0; i < BodyParts.Length; i++)
		{
			for (int j = 0; j < RegSprites.Length; j++)
			{
				if (BodyParts.Length > i && RegSprites.Length > j && BodyParts[i].sprite == RegSprites[j] && SwapSprites.Length > j)
				{
					BodyParts[i].sprite = SwapSprites[j];
				}
			}
		}
	}
}
