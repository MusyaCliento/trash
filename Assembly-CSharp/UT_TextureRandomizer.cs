using System.Collections.Generic;
using UnityEngine;

public class UT_TextureRandomizer : MonoBehaviour
{
	public bool randomizeOnStart;

	public List<Texture2D> textures;

	public Renderer targetRenderer;

	private void Start()
	{
		if (randomizeOnStart)
		{
			Randomize();
		}
	}

	public void Randomize()
	{
		targetRenderer.material.mainTexture = textures[Random.Range(0, textures.Count)];
	}
}
