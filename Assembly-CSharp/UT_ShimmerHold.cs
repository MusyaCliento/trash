using UnityEngine;

public class UT_ShimmerHold : MonoBehaviour
{
	public ColorSetting.ColorType handholdColorType;

	private Renderer holdRenderer;

	private void Start()
	{
		holdRenderer = GetComponent<Renderer>();
		holdRenderer.material = FXManager.GetSharedHandholdMaterial(holdRenderer.material, handholdColorType);
	}
}
