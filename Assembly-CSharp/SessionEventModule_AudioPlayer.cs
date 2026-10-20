using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SessionEventModule_AudioPlayer : SessionEventModule
{
	public List<AudioClip> clips;

	public float spatialBlend = 1f;

	public float volume = 1f;

	public bool randomDirection;

	public float distanceFromPlayer = 1f;

	public Vector3 relativePositionToPlayerCamera;

	public bool repeat;

	public float repeatTime;

	private float timer;

	public override void Initialize(SessionEvent s)
	{
		base.Initialize(s);
		Activate();
	}

	public override void Activate()
	{
		PlaySound();
		timer = repeatTime;
		base.Activate();
	}

	public override void Update()
	{
		base.Update();
		if (repeat)
		{
			timer -= Time.deltaTime;
			if (timer <= 0f)
			{
				timer = repeatTime;
				PlaySound();
			}
		}
	}

	public void PlaySound()
	{
		Transform transform = ENT_Player.playerObject.cam.transform;
		Vector3 position = transform.position;
		if (randomDirection)
		{
			position += UnityEngine.Random.onUnitSphere * distanceFromPlayer;
		}
		else
		{
			position += transform.TransformVector(relativePositionToPlayerCamera);
		}
		AudioManager.PlaySound(clips[UnityEngine.Random.Range(0, clips.Count)], position, volume, 1f, spatialBlend);
	}
}
