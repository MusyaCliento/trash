using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HitEffectModule_SpawnObject : HitEffectModule
{
	public int spawnAmount = 1;

	public List<GameObject> successRandomObjects;

	public List<GameObject> successObjects;

	public AudioClip successAudio;

	public float successAudioVolume = 1f;

	public bool playSuccessAudioAtPosition = true;

	public float spawnForce;

	public override void OnHit(in Desc desc)
	{
		base.OnHit(in desc);
		Quaternion rotation = Quaternion.LookRotation(desc.normal);
		if (spawnAmount > 0 && successRandomObjects != null && successRandomObjects.Count > 0)
		{
			for (int i = 0; i < spawnAmount; i++)
			{
				Rigidbody component = UnityEngine.Object.Instantiate(successRandomObjects[UnityEngine.Random.Range(0, successRandomObjects.Count)], desc.position, rotation).GetComponent<Rigidbody>();
				if (component != null && spawnForce > 0f)
				{
					component.AddForce(UnityEngine.Random.insideUnitSphere * spawnForce);
				}
			}
		}
		if (successObjects != null && successObjects.Count > 0)
		{
			foreach (GameObject successObject in successObjects)
			{
				Rigidbody component2 = UnityEngine.Object.Instantiate(successObject, desc.position, rotation).GetComponent<Rigidbody>();
				if (component2 != null && spawnForce > 0f)
				{
					component2.AddForce(UnityEngine.Random.insideUnitSphere * spawnForce);
				}
			}
		}
		if (successAudio != null)
		{
			if (playSuccessAudioAtPosition)
			{
				AudioManager.PlaySound(successAudio, desc.position, successAudioVolume);
			}
			else
			{
				AudioManager.PlayUISound(successAudio, successAudioVolume);
			}
		}
	}
}
