using System.Collections.Generic;
using UnityEngine;

public class PerkModule_MassProximityEffect : PerkModule
{
	public float massProximityDistance = 10f;

	public ParticleSystem particleEffect;

	private List<ParticleSystem> spawnedEffects;

	public float proximityMassSpeedMult = 1f;

	private float timeSinceInProximity;

	public float timeSinceInProximityThreshold = 10f;

	public string enterProximityText = "";

	public AudioClip proximityAudioLoop;

	public float proximityAudioLoopVolume = 0.5f;

	public float proximityAudioLoopDistance = 10f;

	private AudioSource proximityAudioSourceObject;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
		spawnedEffects = new List<ParticleSystem>();
		if (ENT_Player.GetPlayer() != null)
		{
			ParticleSystem item = Object.Instantiate(particleEffect, ENT_Player.GetPlayer().camRoot.transform);
			spawnedEffects.Add(item);
			if (proximityAudioLoop != null)
			{
				GameObject gameObject = new GameObject(perk.id + "-MassProximitySound");
				proximityAudioSourceObject = gameObject.AddComponent<AudioSource>();
				proximityAudioSourceObject.clip = proximityAudioLoop;
				proximityAudioSourceObject.volume = 0f;
				proximityAudioSourceObject.loop = true;
				proximityAudioSourceObject.Play();
			}
		}
	}

	public override void OnDestroy(Perk p)
	{
		base.OnDestroy(p);
		if (spawnedEffects != null)
		{
			foreach (ParticleSystem spawnedEffect in spawnedEffects)
			{
				Object.Destroy(spawnedEffect.gameObject);
			}
			spawnedEffects.Clear();
		}
		if (proximityAudioSourceObject != null)
		{
			Object.Destroy(proximityAudioSourceObject.gameObject);
		}
	}

	public override void Update()
	{
		base.Update();
		float num = ENT_Player.GetPlayer().transform.position.y - DEN_DeathFloor.GetHeight();
		if (spawnedEffects != null)
		{
			for (int i = 0; i < spawnedEffects.Count; i++)
			{
				if (num < massProximityDistance && DEN_DeathFloor.instance.IsActiveAndMoving())
				{
					if (spawnedEffects[i].isStopped)
					{
						spawnedEffects[i].Play();
					}
				}
				else if (spawnedEffects[i].isPlaying)
				{
					spawnedEffects[i].Stop();
				}
			}
			if (num < massProximityDistance && DEN_DeathFloor.instance.IsActiveAndMoving())
			{
				if (timeSinceInProximity > timeSinceInProximityThreshold && enterProximityText != "")
				{
					UT_TextScrawl.ShowTextOnScrawl("bottom-header", enterProximityText);
				}
				timeSinceInProximity = 0f;
				if (DEN_DeathFloor.instance != null)
				{
					DEN_DeathFloor.instance.SetUpdateSpeedMultiplier(proximityMassSpeedMult);
				}
				DEN_Face.SetGlobalUpdateSpeedMultiplier(proximityMassSpeedMult);
			}
			else
			{
				timeSinceInProximity += Time.deltaTime;
			}
		}
		if (proximityAudioSourceObject != null)
		{
			proximityAudioSourceObject.volume = (1f - Mathf.Clamp01(num / proximityAudioLoopDistance)) * proximityAudioLoopVolume;
		}
	}
}
