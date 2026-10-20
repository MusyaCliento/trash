using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandItem_BlinkEye : HandItem
{
	private int uses;

	public ParticleSystem blinkTargetEffect;

	public CL_Lamp blinkTargetLamp;

	public ParticleSystem blinkHoldEffect;

	public ParticleSystem crushEffect;

	public SpriteRenderer eyeSprite;

	public SpriteRenderer fragSprite;

	public LayerMask blinkMask;

	public float blinkDistance = 10f;

	public AudioSource squeezeAudioSource;

	public float squeezeAudioVolume = 0.8f;

	private Vector3 blinkTargetPosition;

	private UT_AudioClipHandler clipHandler;

	private float holdTime;

	private float quickTime;

	public bool crushOnLastUse = true;

	public bool canBlinkFrag = true;

	public int blinkFragRegen;

	private Blinkable hitBlinkable;

	private float detectFragTime;

	private bool detectingFrag;

	public UnityEvent OnStartDetectBlinkFrag;

	public UnityEvent OnEndDetectBlinkFrag;

	public UnityEvent OnBlinkFrag;

	private Blinkable lastBlinkable;

	private float lastBlinkableTime;

	private Vector3 lastBlinkablePosition;

	public bool useBuff;

	public BuffContainer teleportBuff;

	public override void Initialize(Item i, ENT_Player.Hand h)
	{
		base.Initialize(i, h);
		int.TryParse(item.GetFirstDataStringByType("uses"), out uses);
		anim.SetInteger("Uses", uses);
		clipHandler = GetComponent<UT_AudioClipHandler>();
		StartCoroutine(WaitOneFrame());
		Item obj = item;
		obj._OnDataAdjust = (Action<string, string>)Delegate.Combine(obj._OnDataAdjust, new Action<string, string>(RefreshDisplay));
		IEnumerator WaitOneFrame()
		{
			yield return null;
			anim.SetInteger("Uses", uses);
		}
	}

	private void OnDisable()
	{
		Item obj = item;
		obj._OnDataAdjust = (Action<string, string>)Delegate.Remove(obj._OnDataAdjust, new Action<string, string>(RefreshDisplay));
	}

	public void RefreshDisplay(string type, string value)
	{
		if (type == "uses")
		{
			int.TryParse(value, out uses);
			anim.SetInteger("Uses", uses);
		}
	}

	public override void Refresh()
	{
		base.Refresh();
		int.TryParse(item.GetFirstDataStringByType("uses"), out uses);
		anim.SetInteger("Uses", uses);
	}

	public override void Use()
	{
		int.TryParse(item.GetFirstDataStringByType("uses"), out uses);
		if (uses <= 0)
		{
			clipHandler.PlaySound("eye:empty");
			return;
		}
		used = true;
		clipHandler.PlaySound("eye:squish");
		anim.SetBool("Squeeze", value: true);
		holdTime = 0f;
		base.Use();
	}

	public override void StopUse()
	{
		if (holdTime < 0.2f && quickTime <= 0f)
		{
			anim.SetBool("Squeeze", value: false);
			used = false;
		}
		else
		{
			if (!used)
			{
				return;
			}
			used = false;
			if (!ENT_Player.GetPlayer().HasInfiniteAmmo())
			{
				uses--;
			}
			uses = Mathf.Max(uses, 0);
			anim.SetInteger("Uses", uses);
			anim.SetBool("Squeeze", value: false);
			item.SetFirstDataStringsofType("uses", uses.ToString());
			if (lastBlinkable != null && (double)(Time.time - lastBlinkableTime) < 0.5)
			{
				blinkTargetPosition = lastBlinkablePosition;
				lastBlinkableTime = 0f;
				hitBlinkable = lastBlinkable;
				lastBlinkable = null;
			}
			ENT_Player.playerObject.DropHang(0f);
			ENT_Player.playerObject.Teleport(blinkTargetPosition);
			ENT_Player.playerObject.SetCrouched(v: true);
			ENT_Player.playerObject.ClearGrapple();
			if (teleportBuff != null && useBuff)
			{
				ENT_Player.GetPlayer().AddNewBuff(teleportBuff.CopyBuffContainer());
			}
			clipHandler.PlaySound("eye:warp");
			if (uses == 0 && crushOnLastUse)
			{
				clipHandler.PlaySound("eye:crush");
			}
			quickTime = 0.5f;
			if (hitBlinkable != null)
			{
				hitBlinkable.OnBlinkEnd();
				hitBlinkable.OnBlinkTeleport();
				if (canBlinkFrag && hitBlinkable.CanBlinkFrag())
				{
					hitBlinkable.GetBlinkableGameObject()?.GetComponent<Hitbox>()?.GetGameEntity()?.Kill("gib", Damageable.DamageInfo.CreateDamageInfo(100f, "telefrag", new List<string>(), ENT_Player.GetPlayer()));
					if (blinkFragRegen > 0)
					{
						uses = Mathf.Min(uses + blinkFragRegen);
						item.SetFirstDataStringsofType("uses", uses.ToString());
						clipHandler.PlaySound("eye:recharge");
						if (fragSprite != null)
						{
							Debug.Log("Settings sprite overlay:");
							fragSprite.material.SetFloat("_OverlayMultAmount", 1f);
						}
						OnBlinkFrag.Invoke();
					}
				}
				hitBlinkable = null;
			}
			UpdateStats();
			base.StopUse();
		}
	}

	public void Crush()
	{
		crushEffect.Play();
	}

	public override void LateUpdate()
	{
		base.LateUpdate();
		if (detectingFrag && (double)(Time.time - detectFragTime) > 0.1)
		{
			detectingFrag = false;
			OnEndDetectBlinkFrag.Invoke();
			anim.SetBool("hasFoundFrag", value: false);
		}
		if (quickTime > 0f)
		{
			quickTime -= Time.deltaTime;
		}
		if (InputManager.GetButton("Inventory").Down)
		{
			CancelBlink();
		}
		if (used)
		{
			eyeSprite.material.SetFloat("_Shimmer", 20f);
			holdTime += Time.deltaTime;
			if (!squeezeAudioSource.isPlaying)
			{
				squeezeAudioSource.Play();
			}
			squeezeAudioSource.volume = Mathf.Lerp(squeezeAudioSource.volume, squeezeAudioVolume, Time.deltaTime * 2f);
			blinkTargetPosition = ENT_Player.playerObject.cam.transform.position + base.transform.forward * blinkDistance;
			_ = base.transform.position + ENT_Player.playerObject.cCon.center + Vector3.up * (0f - ENT_Player.playerObject.cCon.height) * 0.5f + Vector3.up * ENT_Player.playerObject.cCon.height;
			Vector3 position = ENT_Player.playerObject.cam.transform.position;
			Physics.queriesHitBackfaces = true;
			if (Physics.SphereCast(position, ENT_Player.playerObject.cCon.radius, base.transform.forward, out var hitInfo, blinkDistance, blinkMask))
			{
				blinkTargetPosition = position + base.transform.forward * hitInfo.distance;
				Blinkable component = hitInfo.collider.GetComponent<Blinkable>();
				if (component != null)
				{
					hitBlinkable = component;
					hitBlinkable.OnBlinkStart();
					lastBlinkable = hitBlinkable;
					lastBlinkablePosition = blinkTargetPosition;
					lastBlinkableTime = Time.time;
					if (canBlinkFrag && hitBlinkable.CanBlinkFrag())
					{
						if ((double)(Time.time - detectFragTime) > 0.5)
						{
							detectingFrag = true;
							clipHandler.PlaySound("eye:detectfrag");
							anim.SetBool("hasFoundFrag", value: true);
							OnStartDetectBlinkFrag.Invoke();
						}
						detectFragTime = Time.time;
					}
				}
				else if (hitBlinkable != null)
				{
					hitBlinkable.OnBlinkEnd();
					hitBlinkable = null;
				}
			}
			Physics.queriesHitBackfaces = false;
			blinkTargetEffect.transform.position = blinkTargetPosition;
			blinkTargetEffect.transform.rotation = Quaternion.identity;
			if (!blinkTargetEffect.isPlaying)
			{
				blinkTargetEffect.Play();
				blinkHoldEffect.Play();
			}
			blinkTargetLamp.lampActive = true;
		}
		else
		{
			eyeSprite.material.SetFloat("_Shimmer", 0f);
			squeezeAudioSource.volume = Mathf.Lerp(squeezeAudioSource.volume, 0f, Time.deltaTime);
			blinkTargetEffect.transform.position = blinkTargetPosition;
			blinkTargetEffect.transform.rotation = Quaternion.identity;
			if (blinkTargetEffect.isPlaying)
			{
				blinkTargetEffect.Stop();
				blinkHoldEffect.Stop();
			}
			blinkTargetLamp.lampActive = false;
		}
	}

	public override bool CanDrop(bool pocket = false)
	{
		if (uses == 0 && crushOnLastUse)
		{
			return false;
		}
		return !used;
	}

	public void CancelBlink()
	{
		anim.SetBool("Squeeze", value: false);
		used = false;
	}
}
