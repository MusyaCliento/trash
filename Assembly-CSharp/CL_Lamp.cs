using System;
using System.Collections;
using System.Collections.Generic;
using Drawing;
using UnityEngine;

[ExecuteInEditMode]
public class CL_Lamp : MonoBehaviourGizmos
{
	public enum Animations
	{
		None = 0,
		Pulse = 1,
		Flicker = 2,
		Lightning = 3
	}

	public static List<CL_Lamp> effectorLamps;

	public bool lampActive;

	[Range(0f, 240f)]
	public float range = 1f;

	[Range(0f, 10f)]
	public int attentuation = 1;

	[HideInInspector]
	public float curRange = 1f;

	public Color startColor = Color.white;

	[HideInInspector]
	public Color color;

	[Range(0f, 360f)]
	public float angle;

	public float intensity = 1f;

	private float intensityMultiplier = 1f;

	public float bypassLightmap;

	public float emissiveMult = 1f;

	public bool prioritizeOnEnable;

	[Tooltip("Due to light bleeding from one light to other nearby lights, Forward+ may cull out the bleedthrough without realising that it's being overeager.\nIn these situations, set this factor to 2 or 3, to make the light bigger for Forward+'s culling.")]
	public float forwardPlusHiddenMult = 1f;

	public float corruptionIntensity;

	public Animations anim;

	public float animSpeed = 0.2f;

	public float animAmplitude = 0.2f;

	public float animOffset;

	public float flickerLerpSpeed = 2f;

	[Space]
	public float fadeTarget = 1f;

	public float fadeStart = 1f;

	public float fadeSpeed = 2f;

	private float fade = 1f;

	private float flickerTime;

	private Color flickerTarget = Color.black;

	public bool isEffector;

	public float fearMultiplier = 1f;

	public bool fearUsesIntensity = true;

	private void Awake()
	{
		fade = fadeStart;
		intensityMultiplier = 1f;
	}

	private void Update()
	{
		fade = Mathf.Lerp(fade, fadeTarget, Time.deltaTime * fadeSpeed);
	}

	private void LateUpdate()
	{
		if (!base.gameObject.activeInHierarchy)
		{
			return;
		}
		float deltaTime = Time.deltaTime;
		switch (anim)
		{
		case Animations.Flicker:
			if (flickerTime <= 0f)
			{
				flickerTime = 1f / animSpeed;
				curRange = range;
				flickerTarget = startColor * (1f - UnityEngine.Random.Range(0f, animAmplitude * 0.5f));
			}
			color = Color.Lerp(color, flickerTarget, deltaTime * flickerLerpSpeed);
			flickerTime -= deltaTime;
			break;
		case Animations.Pulse:
			color = startColor * Mathf.Max(1f - (Mathf.Sin(Time.time * animSpeed + animOffset) + 1f) * animAmplitude * 0.1f, 0f);
			curRange = range;
			flickerTime -= deltaTime;
			break;
		case Animations.Lightning:
			color = Color.Lerp(color, Color.black, deltaTime * animAmplitude);
			curRange = range;
			intensityMultiplier = Mathf.Lerp(intensityMultiplier, 0f, deltaTime * animAmplitude);
			if (UnityEngine.Random.value < animSpeed * deltaTime / 100f && flickerTime <= 0f)
			{
				color = startColor;
				curRange = range;
				intensityMultiplier = 1f;
				flickerTime = 1f;
			}
			flickerTime -= deltaTime;
			break;
		default:
			if (color != startColor || curRange != range)
			{
				color = startColor;
				curRange = range;
				return;
			}
			break;
		}
		if (FXManager.fxMan != null)
		{
			FXManager.fxMan.UpdateLamp(this);
		}
	}

	private void OnEnable()
	{
		if (effectorLamps == null)
		{
			effectorLamps = new List<CL_Lamp>();
		}
		if (isEffector)
		{
			effectorLamps.Add(this);
		}
		if (!(FXManager.fxMan == null))
		{
			FXManager.fxMan.AddLamp(this);
			SetIntensityMultiplier(1f);
			if (prioritizeOnEnable)
			{
				MoveToFrontOfQueue();
			}
		}
	}

	private void OnDisable()
	{
		if (effectorLamps == null)
		{
			effectorLamps = new List<CL_Lamp>();
		}
		if (isEffector)
		{
			effectorLamps.Remove(this);
		}
		if (!(FXManager.fxMan == null))
		{
			FXManager.fxMan.DeleteLamp(this);
		}
	}

	private void OnDestroy()
	{
		if (!(FXManager.fxMan == null))
		{
			FXManager.fxMan.DeleteLamp(this);
		}
	}

	public float RealRadius()
	{
		float b = Mathf.Max(corruptionIntensity, bypassLightmap);
		float num = range * Mathf.Abs(intensity) * Mathf.Max(1f, b);
		num *= forwardPlusHiddenMult;
		if (attentuation == 0)
		{
			num *= 3.4f;
		}
		if (attentuation == 1)
		{
			num *= 1.7f;
		}
		if (intensity < -1f)
		{
			num *= 0f - intensity;
		}
		return num;
	}

	public override void DrawGizmos()
	{
		Draw.SphereOutline(base.transform.position, 0.2f, Color.yellow);
		if (GizmoContext.InSelection(this))
		{
			Draw.SphereOutline(base.transform.position, range, startColor * new Color(1f, 1f, 1f, 0.1f));
			Draw.SphereOutline(base.transform.position, RealRadius(), startColor * new Color(1f, 1f, 1f, 0.05f));
		}
		else
		{
			Draw.SphereOutline(base.transform.position, range, startColor * new Color(1f, 1f, 1f, 0.005f));
		}
		if (angle > 0f)
		{
			float num = Mathf.Cos(angle * 0.00872665f);
			float num2 = Mathf.Sin(angle * 0.00872665f);
			Draw.Line(base.transform.position, base.transform.position + base.transform.forward * range, startColor);
			float num3 = 0.25f;
			Draw.DashedLine(base.transform.position, base.transform.position + (base.transform.forward * num + base.transform.up * num2).normalized * range, num3, num3, startColor);
			Draw.DashedLine(base.transform.position, base.transform.position + (base.transform.forward * num + -base.transform.up * num2).normalized * range, num3, num3, startColor);
			Draw.DashedLine(base.transform.position, base.transform.position + (base.transform.forward * num + -base.transform.right * num2).normalized * range, num3, num3, startColor);
			Draw.DashedLine(base.transform.position, base.transform.position + (base.transform.forward * num + base.transform.right * num2).normalized * range, num3, num3, startColor);
		}
	}

	public void SetAnimation(string a)
	{
		anim = (Animations)Enum.Parse(typeof(Animations), a);
	}

	public void SetColor(Color c)
	{
		startColor = c;
		color = c;
	}

	public void SetColor(string c)
	{
		Color color = this.color;
		ColorUtility.TryParseHtmlString(c, out color);
		this.color = color;
		startColor = color;
	}

	public void SetRange(float r)
	{
		range = r;
	}

	public void SetAngle(float a)
	{
		angle = a;
	}

	public void FadeOut()
	{
		fadeTarget = 0f;
	}

	public void FadeIn()
	{
		fadeTarget = 1f;
	}

	public void FadeTo(float f)
	{
		fadeTarget = f;
	}

	public void InstantFade(float f)
	{
		fadeTarget = f;
		fade = f;
	}

	public float GetFade()
	{
		return fade;
	}

	public void LerpRangeToTarget(float target)
	{
		StartCoroutine(RangeLerper());
		IEnumerator RangeLerper()
		{
			float a = 0f;
			float startRange = range;
			while (a < 1f)
			{
				a += Time.deltaTime * animSpeed;
				range = Mathf.Lerp(startRange, target, a);
				yield return null;
			}
		}
	}

	public static List<CL_Lamp> GetEffectorsOfPosition(Vector3 position)
	{
		List<CL_Lamp> list = new List<CL_Lamp>();
		if (effectorLamps != null && effectorLamps.Count > 0)
		{
			foreach (CL_Lamp effectorLamp in effectorLamps)
			{
				if (effectorLamp == null)
				{
					continue;
				}
				Vector3 vector = position - effectorLamp.transform.position;
				float num = Vector3.SqrMagnitude(vector);
				float num2 = effectorLamp.range * effectorLamp.range;
				if (!(num < num2))
				{
					continue;
				}
				if (effectorLamp.angle > 0f)
				{
					if (Vector3.Angle(effectorLamp.transform.forward, vector) * 2f < effectorLamp.angle)
					{
						list.Add(effectorLamp);
					}
				}
				else
				{
					list.Add(effectorLamp);
				}
			}
			if (list.Count == 0)
			{
				return null;
			}
			return list;
		}
		return null;
	}

	public static bool IsLitByEffector(Vector3 position)
	{
		if (GetEffectorsOfPosition(position) != null)
		{
			return true;
		}
		return false;
	}

	public static float GetHighestEffectorFearRating(Vector3 position)
	{
		List<CL_Lamp> effectorsOfPosition = GetEffectorsOfPosition(position);
		if (effectorsOfPosition == null)
		{
			return 0f;
		}
		float num = 0f;
		foreach (CL_Lamp item in effectorsOfPosition)
		{
			if (item.fearMultiplier != 0f && !(item.fearMultiplier < num))
			{
				float num2 = Vector3.Distance(item.transform.position, position) / item.range;
				if (item.angle > 0f)
				{
					float num3 = 1f - Vector3.Angle(item.transform.forward, position - item.transform.position) * 2f / item.angle;
					num2 *= num3;
					float num4 = Mathf.Cos(item.angle * 0.00872665f);
					float num5 = Mathf.Sin(item.angle * 0.00872665f);
					Draw.Line(item.transform.position, item.transform.position + item.transform.forward * item.range, Color.red * item.fearMultiplier);
					Draw.SphereOutline(item.transform.position, 5f, Color.red * item.fearMultiplier);
					Draw.Label2D(item.transform.position, "Fear: " + num2 * item.fearMultiplier + " A: " + num3);
					float num6 = 0.25f;
					Draw.DashedLine(item.transform.position, item.transform.position + (item.transform.forward * num4 + item.transform.up * num5).normalized * item.range, num6, num6, Color.red * item.fearMultiplier);
					Draw.DashedLine(item.transform.position, item.transform.position + (item.transform.forward * num4 + -item.transform.up * num5).normalized * item.range, num6, num6, Color.red * item.fearMultiplier);
					Draw.DashedLine(item.transform.position, item.transform.position + (item.transform.forward * num4 + -item.transform.right * num5).normalized * item.range, num6, num6, Color.red * item.fearMultiplier);
					Draw.DashedLine(item.transform.position, item.transform.position + (item.transform.forward * num4 + item.transform.right * num5).normalized * item.range, num6, num6, Color.red * item.fearMultiplier);
				}
				if (item.fearUsesIntensity)
				{
					num2 *= item.intensity;
				}
				if (num2 > num)
				{
					num = item.fearMultiplier;
				}
			}
		}
		return num;
	}

	public float GetCurrentIntensity()
	{
		return intensity * intensityMultiplier;
	}

	public float GetCurrentCorruption()
	{
		return intensity * corruptionIntensity;
	}

	internal void SetIntensityMultiplier(float v)
	{
		intensityMultiplier = v;
	}

	public void MoveToFrontOfQueue()
	{
		FXManager.fxMan.MoveLampToFrontOfQueue(this);
	}
}
