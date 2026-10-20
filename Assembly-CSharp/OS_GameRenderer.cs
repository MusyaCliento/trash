using UnityEngine;

public class OS_GameRenderer : MonoBehaviour
{
	public int resolutionX = 400;

	public int resolutionY = 300;

	public int worldPoint = 5000;

	private RenderTexture renderTexture;

	public Camera renderCamera;

	private void Start()
	{
		base.transform.position = new Vector3(worldPoint, -worldPoint, 0f);
		GetRenderTexture();
	}

	private void Update()
	{
	}

	public void Unload()
	{
		if (renderTexture != null)
		{
			renderTexture.Release();
			renderTexture = null;
		}
		Object.Destroy(base.gameObject);
	}

	public RenderTexture GetRenderTexture()
	{
		if (this.renderTexture == null)
		{
			RenderTexture renderTexture = new RenderTexture(resolutionX, resolutionY, 24);
			renderTexture.filterMode = FilterMode.Point;
			this.renderTexture = renderTexture;
			renderCamera.targetTexture = this.renderTexture;
		}
		return this.renderTexture;
	}
}
