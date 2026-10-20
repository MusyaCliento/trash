using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasScaler))]
public class UI_CanvasScaler : MonoBehaviour
{
	[Header("Scale Settings")]
	[Tooltip("Minimum scale factor for UI elements.")]
	public float minScale = 0.8f;

	[Tooltip("Maximum scale factor for UI elements.")]
	public float maxScale = 1.2f;

	[Header("Resolution Settings")]
	[Tooltip("Minimum screen width resolution.")]
	public float minResolution = 800f;

	[Tooltip("Maximum screen width resolution.")]
	public float maxResolution = 1920f;

	private CanvasScaler canvasScaler;

	public AnimationCurve scaleCurve;

	private float currentScale = 1f;

	private void Start()
	{
		canvasScaler = GetComponent<CanvasScaler>();
		canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
		Refresh();
		UpdateScale();
	}

	private void Update()
	{
		UpdateScale();
	}

	private void UpdateScale()
	{
		float time = (Mathf.Clamp(Screen.width, minResolution, maxResolution) - minResolution) / (maxResolution - minResolution);
		time = scaleCurve.Evaluate(time);
		float num = Mathf.Lerp(minScale, maxScale, time) * currentScale;
		if ((float)(Screen.width / Screen.height) > 2.5f)
		{
			num *= 0.6f;
		}
		canvasScaler.scaleFactor = num;
	}

	private void OnEnable()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Combine(SettingsManager._OnRefreshAllSettings, new Action(Refresh));
	}

	private void OnDisable()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Remove(SettingsManager._OnRefreshAllSettings, new Action(Refresh));
	}

	private void Refresh()
	{
		currentScale = (float)SettingsManager.settings.UIScale;
	}
}
