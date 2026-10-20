using UnityEngine;

[AddComponentMenu("Image Effects/CRT/Ultimate CRT (standalone)")]
public class StandaloneCRTEffect : BaseCRTEffect
{
	private void OnPreCull()
	{
		InternalPreRender();
	}

	protected override RenderTexture CreateCameraTexture(RenderTexture currentCameraTexture)
	{
		RenderTexture renderTexture = base.CreateCameraTexture(currentCameraTexture);
		if (renderTexture != null)
		{
			return renderTexture;
		}
		return new RenderTexture(Screen.width, Screen.height, 0);
	}

	protected override void OnCameraPostRender(Texture texture)
	{
		ProcessEffect(texture, null);
	}
}
