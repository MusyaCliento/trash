using System.Collections.Generic;
using UnityEngine;

public class UT_Fire : UT_TriggerBase<UT_TriggerComponent<GameEntity>>
{
	public bool active = true;

	public float fireTime = 1f;

	private float damageTime;

	public List<AudioClip> damageAudio;

	public float damageAudioVolume = 1f;

	public float damageAudioPitch = 1f;

	private ParticleSystem particleSystem;

	internal override void Start()
	{
		base.Start();
		particleSystem = GetComponent<ParticleSystem>();
	}

	internal override void FixedUpdate()
	{
		base.FixedUpdate();
		damageTime -= Time.fixedDeltaTime;
		if (!(damageTime < 0f))
		{
			return;
		}
		damageTime = 0.5f;
		for (int i = 0; i < triggerObjects.Count; i++)
		{
			if (triggerObjects[i].other == null)
			{
				triggerObjects.RemoveAt(i--);
			}
			else
			{
				Damage(triggerObjects[i].other);
			}
		}
	}

	private void Update()
	{
	}

	private void Damage(GameEntity gameEntity)
	{
		if (active && !(gameEntity == null) && gameEntity.GetGameObject().activeInHierarchy)
		{
			if (damageAudio != null && damageAudio.Count > 0)
			{
				AudioManager.PlaySound(damageAudio[Random.Range(0, damageAudio.Count)], gameEntity.GetGameObject().transform.position, damageAudioVolume, damageAudioPitch);
			}
			gameEntity?.AddEffect("fire", fireTime);
		}
	}

	public void SetFireState(bool b)
	{
		active = b;
		if (particleSystem != null)
		{
			if (active && !particleSystem.isPlaying)
			{
				particleSystem.Play();
			}
			else if (!active && particleSystem.isPlaying)
			{
				particleSystem.Stop();
			}
		}
	}

	public void ToggleFireState()
	{
		SetFireState(!active);
	}
}
