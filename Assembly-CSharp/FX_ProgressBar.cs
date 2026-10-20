using System;
using UnityEngine;
using UnityEngine.UI;

public class FX_ProgressBar : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;

	private MeshRenderer meshRenderer;

	private Image imageRenderer;

	private Material mat;

	public static float amount;

	private float opacity;

	public static Action<float> SetBarValue;

	private void OnEnable()
	{
		SetBarValue = (Action<float>)Delegate.Combine(SetBarValue, new Action<float>(SetValue));
	}

	private void OnDisable()
	{
		SetBarValue = (Action<float>)Delegate.Remove(SetBarValue, new Action<float>(SetValue));
	}

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		meshRenderer = GetComponent<MeshRenderer>();
		imageRenderer = GetComponent<Image>();
		if ((bool)spriteRenderer)
		{
			mat = spriteRenderer.material;
		}
		else if ((bool)meshRenderer)
		{
			mat = meshRenderer.material;
		}
		else if ((bool)imageRenderer)
		{
			mat = imageRenderer.material;
		}
	}

	private void Update()
	{
		if ((bool)mat)
		{
			mat.SetFloat("_Amount", amount);
		}
		Color color = imageRenderer.color;
		color.a = opacity;
		imageRenderer.color = color;
		if (opacity > 0f)
		{
			opacity -= Time.deltaTime;
		}
	}

	public void SetValue(float a)
	{
		if ((bool)mat)
		{
			amount = a;
		}
		opacity = 1f;
	}
}
