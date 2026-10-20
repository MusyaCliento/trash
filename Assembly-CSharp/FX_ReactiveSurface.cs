using System.Collections.Generic;
using UnityEngine;

public class FX_ReactiveSurface : MonoBehaviour
{
	private Renderer rend;

	private float activity;

	private float curActivity;

	public float fadeTime = 0.5f;

	public float reactEmissionAmount = 5f;

	public float reactShimmerAmount = 2f;

	public float randomReactChance;

	public float randomReactAmount = 1f;

	public AudioClip[] reactAudio;

	public float reactVolume = 1f;

	public AudioClip[] randomReactAudio;

	public float randomReactVolume = 0.5f;

	public float randomReactAudioChance = 0.1f;

	private void Start()
	{
		rend = GetComponent<Renderer>();
	}

	private void Update()
	{
		activity = Mathf.Lerp(activity, 0f, Time.deltaTime * fadeTime);
		curActivity = Mathf.Lerp(curActivity, activity, Time.deltaTime * 6f);
		rend.material.SetFloat("_EmissionMultiplier", reactEmissionAmount * curActivity);
		rend.material.SetFloat("_Shimmer", reactShimmerAmount * curActivity);
		if (Random.value < randomReactChance * Time.deltaTime / 100f)
		{
			activity = Random.Range(0f, randomReactAmount);
			if (randomReactAudio != null && Random.value < randomReactAudioChance)
			{
				AudioManager.PlaySound(randomReactAudio[Random.Range(0, randomReactAudio.Length)], base.transform.position, randomReactVolume);
			}
		}
	}

	public void React()
	{
		activity = 1f;
		if (reactAudio != null)
		{
			AudioManager.PlaySound(reactAudio[Random.Range(0, reactAudio.Length)], base.transform.position, reactVolume);
		}
	}

	public void SetupHeaterScripts()
	{
		UT_Damage uT_Damage = GetComponent<UT_Damage>();
		if (uT_Damage == null)
		{
			uT_Damage = base.gameObject.AddComponent<UT_Damage>();
		}
		uT_Damage.maxHealth = 0f;
		uT_Damage.health = 0f;
		uT_Damage.killType = UT_Damage.KillType.nothing;
		if (uT_Damage.damageSources == null)
		{
			uT_Damage.damageSources = new List<UT_Damage.DamageSource>();
		}
		UT_Damage.DamageSource damageSource = null;
		foreach (UT_Damage.DamageSource damageSource2 in uT_Damage.damageSources)
		{
			if (damageSource2.sourceTypes.Contains("ice"))
			{
				damageSource = damageSource2;
				break;
			}
		}
		if (damageSource == null)
		{
			damageSource = new UT_Damage.DamageSource();
			damageSource.sourceTypes = new List<string>();
			damageSource.sourceTypes.Add("ice");
			uT_Damage.damageSources.Add(damageSource);
		}
		ObjectTagger objectTagger = GetComponent<ObjectTagger>();
		if (objectTagger == null)
		{
			objectTagger = base.gameObject.AddComponent<ObjectTagger>();
		}
		if (objectTagger.tags == null)
		{
			objectTagger.tags = new List<string>();
		}
		if (!objectTagger.tags.Contains("Damageable"))
		{
			objectTagger.tags.Add("Damageable");
		}
		if (!objectTagger.tags.Contains("Heater"))
		{
			objectTagger.tags.Add("Heater");
		}
	}
}
