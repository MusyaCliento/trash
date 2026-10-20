using UnityEngine;

public class Hand_SpriteController : MonoBehaviour
{
	private SpriteRenderer sprite;

	public bool allowGlobalMaterialAssignments = true;

	public bool allowCustomStaminaColor = true;

	public string spriteName;

	private void OnEnable()
	{
		sprite = base.gameObject.GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
	}

	public void SetColor(Color c)
	{
		if (!(sprite == null))
		{
			c.a = sprite.color.a;
			sprite.color = c;
		}
	}

	public void SetStaminaInfo(Color staminaColor, Color staminaOutlineColor, Color outlineMaskColor, float amount)
	{
		if (sprite == null || !base.gameObject.activeInHierarchy || !sprite.enabled)
		{
			return;
		}
		staminaColor.a = sprite.color.a;
		if (!allowCustomStaminaColor)
		{
			staminaColor = Color.red;
			staminaOutlineColor = Color.red;
		}
		if (sprite.sharedMaterial != null)
		{
			if (sprite.sharedMaterial.HasFloat("_StaminaAmount"))
			{
				sprite.sharedMaterial.SetFloat("_StaminaAmount", amount);
			}
			if (sprite.sharedMaterial.HasColor("_StaminaColor"))
			{
				sprite.sharedMaterial.SetColor("_StaminaColor", staminaColor);
			}
			if (sprite.sharedMaterial.HasColor("_StaminaOutlineColor"))
			{
				sprite.sharedMaterial.SetColor("_StaminaOutlineColor", staminaOutlineColor);
			}
			if (sprite.sharedMaterial.HasColor("_OutlineMaskColor") && outlineMaskColor != Color.clear)
			{
				sprite.sharedMaterial.SetColor("_OutlineMaskColor", outlineMaskColor);
			}
		}
	}
}
