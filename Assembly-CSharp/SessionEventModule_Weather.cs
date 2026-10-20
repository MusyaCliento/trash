using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SessionEventModule_Weather : SessionEventModule
{
	public bool active = true;

	private ENT_Player player;

	private BuffContainer weatherDebuff;

	public BuffContainer weatherEffects;

	private ParticleSystem[] particleEffect;

	public bool useCloudEffect;

	public List<Material> cloudMaterials;

	public float cloudMaterialOffsetMult = 1f;

	public GameObject weatherObjectAsset;

	private GameObject weatherObject;

	public bool useFXZone;

	public FXManager.FXData fxZone;

	public byte fxZonePriority;

	private float fadeTarget = 1f;

	private float fadeCur;

	private Dictionary<ParticleSystem, float> particleRates;

	public override void Initialize(SessionEvent s)
	{
		base.Initialize(s);
		player = CL_GameManager.gMan.localPlayer;
		weatherDebuff = new BuffContainer();
		weatherDebuff.id = weatherEffects.id;
		weatherDebuff.buffs = new List<BuffContainer.Buff>();
		weatherDebuff.buffs.AddRange(weatherEffects.buffs);
		weatherDebuff.loseOverTime = false;
		weatherDebuff.SetMultiplier(fadeCur);
		if (!player.curBuffs.HasBuffContainer(weatherEffects.id))
		{
			player.curBuffs.AddBuff(weatherDebuff);
		}
		if (useCloudEffect)
		{
			weatherObject = UnityEngine.Object.Instantiate(weatherObjectAsset);
			particleEffect = weatherObject.GetComponentsInChildren<ParticleSystem>();
		}
		fadeTarget = 1f;
		fadeCur = 0f;
		particleRates = new Dictionary<ParticleSystem, float>();
		if (particleEffect != null)
		{
			ParticleSystem[] array = particleEffect;
			foreach (ParticleSystem particleSystem in array)
			{
				particleSystem.Play();
				ParticleSystem.EmissionModule emission = particleSystem.emission;
				particleRates.Add(particleSystem, emission.rateOverTimeMultiplier);
				emission.rateOverTimeMultiplier = 0f;
			}
		}
	}

	public override void LateUpdate()
	{
		base.Update();
		if (useCloudEffect && weatherObject != null)
		{
			weatherObject.transform.position = Camera.main.transform.position;
		}
		fadeCur = Mathf.Lerp(fadeCur, fadeTarget, Time.deltaTime * 0.25f);
		weatherDebuff.SetMultiplier(fadeCur);
		DataLerp();
		if (useCloudEffect)
		{
			BlendClouds();
		}
	}

	public override void OnModuleDestroy()
	{
		player.curBuffs.RemoveBuffContainer(weatherDebuff.id);
		if (useCloudEffect)
		{
			UnityEngine.Object.Destroy(weatherObject);
		}
		base.OnModuleDestroy();
	}

	private void DataLerp()
	{
		if (useFXZone)
		{
			FXManager.FXZoneStore fXZoneStore = new FXManager.FXZoneStore();
			fXZoneStore.blend = fadeCur;
			fXZoneStore.priority = fxZonePriority;
			fXZoneStore.data = fxZone;
			FXManager.fxZones.Enqueue(fXZoneStore, fxZonePriority);
		}
	}

	private void BlendClouds()
	{
		ParticleSystem[] array = particleEffect;
		foreach (ParticleSystem particleSystem in array)
		{
			if (!particleSystem.isPlaying)
			{
				particleSystem.Play();
			}
			ParticleSystem.EmissionModule emission = particleSystem.emission;
			emission.rateOverTimeMultiplier = fadeCur * particleRates[particleSystem];
		}
		foreach (Material cloudMaterial in cloudMaterials)
		{
			cloudMaterial.SetFloat("_AlphaMult", fadeCur);
			cloudMaterial.SetTextureOffset("_MainTex", new Vector2(0f, Camera.main.transform.position.y * cloudMaterialOffsetMult));
		}
	}

	public override void SendMessage(string m)
	{
		base.SendMessage(m);
		if (m == "fadeout")
		{
			fadeTarget = 0f;
		}
		else if (m == "fadein")
		{
			fadeTarget = 1f;
		}
	}
}
