using UnityEngine;

public class UT_Highlight : MonoBehaviour
{
	public MeshRenderer meshRenderer;

	public bool active = true;

	private float highlightAmount;

	private Material tempMaterial;

	private Material originalMaterial;

	private float defaultShimmer;

	private void Start()
	{
	}

	private void Update()
	{
		if (meshRenderer != null)
		{
			if (meshRenderer.sharedMaterial != originalMaterial && meshRenderer.sharedMaterial != tempMaterial)
			{
				originalMaterial = meshRenderer.sharedMaterial;
			}
			if (tempMaterial != null)
			{
				Object.Destroy(tempMaterial);
			}
			tempMaterial = Object.Instantiate(originalMaterial);
			meshRenderer.sharedMaterial = tempMaterial;
			defaultShimmer = tempMaterial.GetFloat("_Shimmer");
			_ = defaultShimmer;
			_ = highlightAmount;
			if (defaultShimmer > 0.5f)
			{
				_ = defaultShimmer;
				_ = highlightAmount;
			}
			tempMaterial.SetFloat("_Shimmer", defaultShimmer + highlightAmount);
		}
		highlightAmount = Mathf.Lerp(highlightAmount, 0f, Time.deltaTime * 3f);
	}

	public void Highlight()
	{
		if (active)
		{
			highlightAmount = 3f;
		}
	}
}
