using System.Collections;
using System.Collections.Generic;
using Drawing;
using UnityEngine;

public class ENV_LightningDischarge : MonoBehaviourGizmos
{
	public GameObject dischargeRoot;

	public Transform endTransform;

	public float strikeLength = 1f;

	public float strikeBuildupLength = 1f;

	public float strikeWaitMin = 5f;

	public float strikeWaitMax = 10f;

	public float strikeDrift = 5f;

	public float strikeCamShake = 3f;

	public float strikeCamShakeDistance = 20f;

	public List<CL_Lamp> lamps;

	public List<CL_Lamp> lampsEpilepsy;

	public List<Renderer> lightningRenderers;

	public List<Renderer> lightningRenderersEpilepsy;

	public ParticleSystem lightningParticle;

	public ParticleSystem chargeParticle;

	private float strikeWaitTime;

	public AnimationCurve strikeCurve;

	public AudioSource loopAudio;

	public float loopAudioVolume = 1f;

	private UT_AudioClipHandler clipHandler;

	public float hitDamage = 1f;

	public LayerMask damageMask;

	public float damageRadius;

	private void Start()
	{
		clipHandler = GetComponent<UT_AudioClipHandler>();
		strikeWaitTime = Random.Range(strikeWaitMin, strikeWaitMax);
		DischargeEnd();
	}

	private void Update()
	{
		if (strikeWaitTime <= 0f)
		{
			strikeWaitTime = Random.Range(strikeWaitMin, strikeWaitMax);
			StartCoroutine(Discharge());
		}
		strikeWaitTime -= Time.deltaTime;
	}

	private IEnumerator Discharge()
	{
		float strikeTime = strikeLength;
		float damageTime = 0f;
		dischargeRoot.transform.localRotation = Quaternion.identity;
		lightningParticle.Play();
		yield return new WaitForSeconds(strikeBuildupLength);
		foreach (Renderer item in LightningRenderers())
		{
			item.gameObject.SetActive(value: true);
		}
		foreach (CL_Lamp item2 in Lamps())
		{
			item2.gameObject.SetActive(value: true);
		}
		loopAudio.Play();
		clipHandler.PlaySound("discharge:strike");
		CL_CameraControl.ShakeAtPosition(base.transform.position, strikeCamShake, strikeCamShakeDistance);
		Quaternion targetRotation = Quaternion.Euler(Random.insideUnitSphere * strikeDrift);
		while (strikeTime >= 0f)
		{
			float num = strikeCurve.Evaluate(strikeTime / strikeLength);
			loopAudio.volume = num * loopAudioVolume;
			dischargeRoot.transform.localRotation = Quaternion.Lerp(Quaternion.identity, targetRotation, 1f - strikeTime / strikeLength);
			foreach (Renderer item3 in LightningRenderers())
			{
				item3.material.SetFloat("_AlphaMult", num);
			}
			foreach (CL_Lamp item4 in Lamps())
			{
				item4.SetIntensityMultiplier(num);
			}
			CL_CameraControl.ShakeAtPosition(base.transform.position, strikeCamShake * Time.deltaTime, strikeCamShakeDistance);
			strikeTime -= Time.deltaTime;
			if (damageTime <= 0f)
			{
				DamageCheck();
				damageTime = 0.1f;
			}
			damageTime -= Time.deltaTime;
			yield return null;
		}
		DischargeEnd();
	}

	private void DamageCheck()
	{
		Collider[] array = Physics.OverlapCapsule(dischargeRoot.transform.position, endTransform.position, damageRadius, damageMask);
		foreach (Collider collider in array)
		{
			if (ObjectTagger.TagCheck(collider.gameObject, "Damageable"))
			{
				collider.GetComponent<Damageable>()?.Damage(Damageable.DamageInfo.CreateDamageInfo(hitDamage, "lightning"));
			}
		}
	}

	private void DischargeEnd()
	{
		lightningParticle.Stop();
		loopAudio.Stop();
		foreach (CL_Lamp item in Lamps())
		{
			item.SetIntensityMultiplier(0f);
			item.gameObject.SetActive(value: false);
		}
		dischargeRoot.transform.localRotation = Quaternion.identity;
		foreach (Renderer item2 in LightningRenderers())
		{
			item2.gameObject.SetActive(value: false);
		}
	}

	private List<CL_Lamp> Lamps()
	{
		List<CL_Lamp> result = lamps;
		if (SettingsManager.settings.epilepsy && lampsEpilepsy.Count > 0)
		{
			result = lampsEpilepsy;
		}
		return result;
	}

	private List<Renderer> LightningRenderers()
	{
		List<Renderer> result = lightningRenderers;
		if (SettingsManager.settings.epilepsy && lightningRenderers.Count > 0)
		{
			result = lightningRenderersEpilepsy;
		}
		return result;
	}

	public override void DrawGizmos()
	{
		if (GizmoContext.InSelection(this))
		{
			Draw.WireCapsule(dischargeRoot.transform.position, endTransform.position, damageRadius, new Color(1f, 1f, 1f, 0.1f));
		}
	}
}
