using System;
using System.Collections;
using System.Collections.Generic;
using Drawing;
using UnityEngine;

[ExecuteInEditMode]
public class FX_Zone : MonoBehaviourGizmos
{
	public float maxRange;

	public float minRange;

	[Range(0f, 1f)]
	public float blend = 1f;

	public byte priority = 1;

	public bool resetBlendOnStart;

	public float resetBlend = 1f;

	private float tickRate = 0.1f;

	private float tickTime;

	public FXManager.FXData fxData = new FXManager.FXData();

	private FXManager.FXData lerpData = new FXManager.FXData();

	private float lerpAmount;

	private bool tick;

	private Dictionary<Camera, bool> inRange = new Dictionary<Camera, bool>();

	private void Start()
	{
		tickTime = UnityEngine.Random.value;
		lerpData = new FXManager.FXData();
		if (resetBlendOnStart && Application.isPlaying)
		{
			blend = resetBlend;
		}
	}

	private void OnEnable()
	{
		FXManager.OnPreRenderFX = (Action<Camera>)Delegate.Combine(FXManager.OnPreRenderFX, new Action<Camera>(RenderFX));
	}

	private void OnDisable()
	{
		FXManager.OnPreRenderFX = (Action<Camera>)Delegate.Remove(FXManager.OnPreRenderFX, new Action<Camera>(RenderFX));
	}

	[ExecuteAlways]
	private void LateUpdate()
	{
		if (tickTime <= 0f)
		{
			tickTime = tickRate;
			tick = true;
		}
		else
		{
			tick = false;
		}
	}

	private void RenderFX(Camera camera)
	{
		float num = float.PositiveInfinity;
		if (!inRange.ContainsKey(camera))
		{
			inRange.Add(camera, value: false);
		}
		num = Vector3.Distance(camera.transform.position, base.transform.position);
		if (num < maxRange)
		{
			inRange[camera] = true;
			DataLerp(num);
		}
		else if (inRange[camera])
		{
			inRange[camera] = false;
			DataLerp(num);
		}
	}

	private void DataLerp(float distance)
	{
		lerpAmount = (1f - Mathf.Clamp((distance - minRange) / (maxRange - minRange), 0f, 1f)) * blend;
		if (base.enabled)
		{
			FXManager.FXZoneStore fXZoneStore = new FXManager.FXZoneStore();
			fXZoneStore.blend = lerpAmount;
			fXZoneStore.priority = priority;
			fXZoneStore.data = fxData;
			FXManager.fxZones.Enqueue(fXZoneStore, priority);
		}
	}

	public override void DrawGizmos()
	{
		if (GizmoContext.InSelection(this))
		{
			Draw.SphereOutline(base.transform.position, maxRange, fxData.fog * new Color(1f, 1f, 1f, 0.5f));
			Draw.SphereOutline(base.transform.position, maxRange + 0.5f, new Color(1f, 1f, 1f, 0.02f));
			Draw.SphereOutline(base.transform.position, minRange, fxData.fog * 2f * new Color(1f, 1f, 1f, 1f));
		}
		else
		{
			Draw.SphereOutline(base.transform.position, maxRange, fxData.fog * new Color(1f, 1f, 1f, 0.005f));
			Draw.SphereOutline(base.transform.position, minRange, fxData.fog * new Color(1f, 1f, 1f, 0.01f));
		}
		Draw.Label2D(base.transform.position, "Lerp: " + lerpAmount);
	}

	public void FadeTo(float fadeTarget)
	{
		StartCoroutine(FadeOverTime(fadeTarget));
	}

	private IEnumerator FadeOverTime(float fadeTarget)
	{
		float fade = 0f;
		float startBlend = blend;
		while (fade < 1f)
		{
			fade += Time.deltaTime * 0.5f;
			blend = Mathf.Lerp(startBlend, fadeTarget, fade);
			yield return null;
		}
	}

	public void SetBlend(float b)
	{
		blend = b;
	}

	public void LerpToBlend(float target, float a)
	{
		blend = Mathf.Lerp(blend, target, a);
	}
}
