using System.Collections.Generic;
using UnityEngine;

public class FX_SpriteOutline : MonoBehaviour
{
	public List<SpriteRenderer> renderers;

	public Material outlineMaterial;

	private Dictionary<SpriteRenderer, SpriteRenderer> outlineRenderers;

	public void Start()
	{
		outlineRenderers = new Dictionary<SpriteRenderer, SpriteRenderer>();
		foreach (SpriteRenderer renderer in renderers)
		{
			GameObject obj = new GameObject(renderer.name + ":OUTLINE");
			obj.transform.parent = renderer.transform;
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localRotation = Quaternion.identity;
			obj.transform.localScale = Vector3.one;
			SpriteRenderer spriteRenderer = obj.AddComponent<SpriteRenderer>();
			spriteRenderer.sharedMaterial = outlineMaterial;
			spriteRenderer.material.CopyMatchingPropertiesFromMaterial(renderer.material);
			spriteRenderer.material.shader = outlineMaterial.shader;
			spriteRenderer.sortingOrder = -20;
			spriteRenderer.gameObject.layer = renderer.gameObject.layer;
			spriteRenderer.sortingLayerID = renderer.sortingLayerID;
			outlineRenderers.Add(renderer, spriteRenderer);
		}
	}

	private void LateUpdate()
	{
		foreach (SpriteRenderer renderer in renderers)
		{
			SpriteRenderer spriteRenderer = outlineRenderers[renderer];
			spriteRenderer.flipX = renderer.flipX;
			spriteRenderer.flipY = renderer.flipY;
			spriteRenderer.sprite = renderer.sprite;
			spriteRenderer.color = renderer.color;
			spriteRenderer.enabled = renderer.enabled;
		}
	}
}
