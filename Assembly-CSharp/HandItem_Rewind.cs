using System.Collections.Generic;
using UnityEngine;

public class HandItem_Rewind : HandItem
{
	public AudioSource holdAudioSource;

	public float holdAudioVolume = 0.8f;

	private UT_AudioClipHandler clipHandler;

	public List<SpriteRenderer> clockHands;

	public float clockHandOffset = 5f;

	private float holdTime;

	private float quickTime;

	private bool rewinding;

	public float shatterAmount = 0.2f;

	public float shatterVelocityDisplaceAmount = 1f;

	public float shatterWiggleSpeed = 0.2f;

	public float shatterWiggleAmount = 0.2f;

	public float shatterWiggleFrequency = 3f;

	public float shatterVelocityAdjust = 1f;

	public float shatterVelocityDifferential = 1f;

	public Transform shatterCenter;

	public List<Transform> shatterFragments;

	private List<Vector3> shatterStartPos;

	private List<Quaternion> shatterStartRot;

	private Vector3 lastPos;

	private Vector3 smoothedVel;

	private float maxTimer;

	private float glassLerp;

	public float staminaRegenRate;

	public float healthRegenRate;

	public override void Start()
	{
		base.Start();
		shatterStartPos = new List<Vector3>();
		shatterStartRot = new List<Quaternion>();
		foreach (Transform shatterFragment in shatterFragments)
		{
			shatterStartPos.Add(shatterFragment.transform.localPosition);
			shatterStartRot.Add(shatterFragment.transform.localRotation);
		}
		lastPos = base.transform.position;
	}

	public override void Initialize(Item i, ENT_Player.Hand h)
	{
		base.Initialize(i, h);
		clipHandler = GetComponent<UT_AudioClipHandler>();
		Item_Object_Rewind rewindObject = GetRewindObject();
		float timer = rewindObject.GetTimer();
		glassLerp = 0f;
		float num = timer / rewindObject.GetMaxTime();
		float num2 = clockHandOffset;
		if (hand.id == 1)
		{
			num2 = 0f - num2;
		}
		foreach (SpriteRenderer clockHand in clockHands)
		{
			clockHand.sharedMaterial.SetFloat("_Rotation", (num2 + num * 360f) * (float)GetDirection());
		}
		maxTimer = rewindObject.GetMaxTime();
		holdAudioSource.volume = 0f;
	}

	public void RefreshDisplay(string type, string value)
	{
	}

	public override void Use()
	{
		Item_Object_Rewind rewindObject = GetRewindObject();
		if (rewindObject.GetTimer() <= 1f || rewindObject.GetCooldown() > 0f)
		{
			clipHandler.PlaySound("item:empty");
			return;
		}
		holdAudioSource.Play();
		used = true;
		rewinding = true;
		rewindObject.SetRewinding(b: true);
		clipHandler.PlaySound("item:use");
		anim.SetBool("Hold", value: true);
		holdTime = 0f;
		base.Use();
	}

	public override void StopUse()
	{
		if (rewinding)
		{
			Item_Object_Rewind rewindObject = GetRewindObject();
			anim.SetBool("Hold", value: false);
			rewinding = false;
			rewindObject.SetRewinding(b: false);
			clipHandler.PlaySound("item:stoprewind");
			if (holdTime < 0.2f && quickTime <= 0f)
			{
				used = false;
			}
			else if (used)
			{
				used = false;
				quickTime = 0.5f;
				UpdateStats();
				base.StopUse();
			}
		}
	}

	public override void LateUpdate()
	{
		base.LateUpdate();
		Item_Object_Rewind rewindObject = GetRewindObject();
		if (rewindObject == null)
		{
			return;
		}
		float num = clockHandOffset;
		if (hand.id == 1)
		{
			num = 0f - num;
		}
		Vector3 vector = (lastPos - base.transform.position) / Time.unscaledDeltaTime;
		vector = base.transform.InverseTransformVector(vector);
		smoothedVel = Vector3.Lerp(smoothedVel, vector, Time.unscaledDeltaTime * 3f);
		lastPos = base.transform.position;
		if (quickTime > 0f)
		{
			quickTime -= Time.deltaTime;
		}
		float num2 = rewindObject.GetTimer();
		float num3 = num2 / rewindObject.GetMaxTime();
		glassLerp = Mathf.Lerp(glassLerp, num3, Time.deltaTime * 2f);
		if (rewinding && num2 > 0f)
		{
			holdAudioSource.volume = Mathf.Lerp(holdAudioSource.volume, holdAudioVolume, Time.deltaTime);
			ENT_Player.playerObject.SetCrouched(v: true);
			num2 -= Time.deltaTime;
			num2 = Mathf.Max(num2, 0f);
			rewindObject.SetTimer(num2);
			hand.GetPlayer().AddGripStrength(Time.deltaTime * staminaRegenRate);
			hand.GetPlayer().Heal(Time.deltaTime * healthRegenRate);
		}
		else
		{
			holdAudioSource.volume = Mathf.Lerp(holdAudioSource.volume, 0f, Time.deltaTime);
		}
		foreach (SpriteRenderer clockHand in clockHands)
		{
			clockHand.sharedMaterial.SetFloat("_Rotation", (num + num3 * 360f) * (float)GetDirection());
		}
		if (rewinding && num2 <= 0f)
		{
			StopUse();
			clipHandler.PlaySound("item:runout");
		}
		if (float.IsNormal(glassLerp) && shatterStartPos != null && shatterStartPos.Count > 0)
		{
			for (int i = 0; i < shatterFragments.Count; i++)
			{
				Transform obj = shatterFragments[i];
				Vector3 vector2 = shatterStartPos[i] - shatterCenter.localPosition;
				Vector3 vector3 = new Vector3(Mathf.PerlinNoise(shatterStartPos[i].x * shatterWiggleFrequency + Time.time * shatterWiggleSpeed, shatterStartPos[i].y * shatterWiggleFrequency), Mathf.PerlinNoise(shatterStartPos[i].x * shatterWiggleFrequency + 22.5f, shatterStartPos[i].y * shatterWiggleFrequency + 55.55f + Time.time * shatterWiggleSpeed), 0f);
				vector3.x -= 0.5f;
				vector3.y -= 0.5f;
				vector3.x += smoothedVel.x * shatterVelocityAdjust * vector2.magnitude * shatterVelocityDisplaceAmount;
				vector3.y += smoothedVel.y * shatterVelocityAdjust * vector2.magnitude * shatterVelocityDisplaceAmount;
				vector3 = Vector3.ClampMagnitude(vector3, 5f);
				obj.localPosition = shatterStartPos[i] + (vector2 + vector3 * shatterWiggleAmount) * shatterAmount * glassLerp;
			}
		}
	}

	public override bool CanDrop(bool pocket = false)
	{
		return !used;
	}

	private Item_Object_Rewind GetRewindObject()
	{
		return (Item_Object_Rewind)item.GetDropObject();
	}
}
