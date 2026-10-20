using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandItem_Spawner : HandItem
{
	private int uses;

	public ParticleSystem targetEffect;

	public CL_Lamp targetLamp;

	public LayerMask targetMask;

	public float targetDistance = 10f;

	public AudioSource holdAudioSource;

	public float holdAudioVolume = 0.8f;

	private Vector3 holdTargetPosition;

	private UT_AudioClipHandler clipHandler;

	public List<GameObject> spawnAssets;

	private float holdTime;

	private float quickTime;

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

	public override void Use()
	{
		int.TryParse(item.GetFirstDataStringByType("uses"), out uses);
		if (uses <= 0)
		{
			clipHandler.PlaySound("item:empty");
			return;
		}
		used = true;
		clipHandler.PlaySound("item:use");
		anim.SetBool("Hold", value: true);
		holdTime = 0f;
		base.Use();
	}

	public override void StopUse()
	{
		anim.SetBool("Hold", value: false);
		if (holdTime < 0.2f && quickTime <= 0f)
		{
			used = false;
		}
		else if (used)
		{
			used = false;
			uses--;
			uses = Mathf.Max(uses, 0);
			item.SetFirstDataStringsofType("uses", uses.ToString());
			UnityEngine.Object.Instantiate(spawnAssets[UnityEngine.Random.Range(0, spawnAssets.Count)], holdTargetPosition, base.transform.rotation).transform.parent = WorldLoader.GetCurrentLevelParentRoot();
			clipHandler.PlaySound("item:spawn");
			quickTime = 0.5f;
			UpdateStats();
			base.StopUse();
		}
	}

	public override void LateUpdate()
	{
		base.LateUpdate();
		if (quickTime > 0f)
		{
			quickTime -= Time.deltaTime;
		}
		if (used)
		{
			holdTime += Time.deltaTime;
			if (holdAudioSource != null)
			{
				if (!holdAudioSource.isPlaying)
				{
					holdAudioSource.Play();
				}
				holdAudioSource.volume = Mathf.Lerp(holdAudioSource.volume, holdAudioVolume, Time.deltaTime * 2f);
			}
			holdTargetPosition = ENT_Player.playerObject.cam.transform.position + base.transform.forward * targetDistance;
			_ = base.transform.position + ENT_Player.playerObject.cCon.center + Vector3.up * (0f - ENT_Player.playerObject.cCon.height) * 0.5f + Vector3.up * ENT_Player.playerObject.cCon.height;
			Vector3 position = ENT_Player.playerObject.cam.transform.position;
			Physics.queriesHitBackfaces = true;
			if (Physics.SphereCast(position, ENT_Player.playerObject.cCon.radius, base.transform.forward, out var hitInfo, targetDistance, targetMask))
			{
				holdTargetPosition = position + base.transform.forward * hitInfo.distance;
			}
			Physics.queriesHitBackfaces = false;
			if (targetEffect != null)
			{
				targetEffect.transform.position = holdTargetPosition;
				targetEffect.transform.rotation = Quaternion.identity;
			}
			if (!targetEffect.isPlaying)
			{
				targetEffect.Play();
			}
			if (targetLamp != null)
			{
				targetLamp.lampActive = true;
			}
			return;
		}
		if (holdAudioSource != null)
		{
			holdAudioSource.volume = Mathf.Lerp(holdAudioSource.volume, 0f, Time.deltaTime);
		}
		if (targetEffect != null)
		{
			targetEffect.transform.position = holdTargetPosition;
			targetEffect.transform.rotation = Quaternion.identity;
			if (targetEffect.isPlaying)
			{
				targetEffect.Stop();
			}
		}
		if (targetLamp != null)
		{
			targetLamp.lampActive = false;
		}
	}

	public override bool CanDrop(bool pocket = false)
	{
		return !used;
	}
}
