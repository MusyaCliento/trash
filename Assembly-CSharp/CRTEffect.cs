using UnityEngine;

[AddComponentMenu("Image Effects/CRT/Ultimate CRT")]
public class CRTEffect : BaseCRTEffect
{
	private void OnPreCull()
	{
		InternalPreRender();
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		ProcessEffect(src, dest);
	}
}
