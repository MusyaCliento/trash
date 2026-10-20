using System.Collections.Generic;
using UnityEngine;

public class Event_Cold : MonoBehaviour
{
	public static bool active = true;

	private ENT_Player player;

	private BuffContainer coldDebuff;

	public List<BuffContainer.Buff> coldEffects;

	private float coldAmount;

	public float freezeRate = 1f;

	public ParticleSystem snowEffect;

	[MinMaxSlider(5f, 200f)]
	public Vector2 blizzardInbetweenTime;

	[MinMaxSlider(0f, 400f)]
	public Vector2 blizzardLength;

	private float nextBlizzardTime = 1f;

	private bool hasBlizzard;

	private float blizzardTimeRemaining;

	private float blizzardValue;

	public BuffContainer blizzardDebuff;

	public Material blizzardMaterial;

	public ParticleSystem blizzardSnow;

	public WindZone blizzardParticleWindZone;

	public float blizzardParticleWindZoneForce = 1f;

	public float blizzardCameraShake = 0.01f;

	private Vector3 blizzardWindDirection = Vector3.forward;

	public float blizzardWindSpeed = 1f;

	public float blizzardWindChangeRate = 1f;

	public AudioSource blizzardAudio;

	public float blizzardAudioVolume = 1f;

	public GameObject blizzardObject;

	internal static Event_Cold instance;

	private void Start()
	{
		player = CL_GameManager.gMan.localPlayer;
		coldDebuff = new BuffContainer();
		coldDebuff.id = "freezing";
		coldDebuff.buffs = new List<BuffContainer.Buff>();
		coldDebuff.buffs.AddRange(coldEffects);
		coldDebuff.loseOverTime = false;
		if (!player.curBuffs.HasBuffContainer("freezing"))
		{
			player.curBuffs.AddBuff(coldDebuff);
		}
		if (!player.curBuffs.HasBuffContainer(blizzardDebuff.id))
		{
			player.curBuffs.AddBuff(blizzardDebuff);
		}
		nextBlizzardTime = Random.Range(blizzardInbetweenTime.x, blizzardInbetweenTime.y) + CL_GameManager.gMan.GetGameTime();
		blizzardSnow.Play();
		ParticleSystem.EmissionModule emission = blizzardSnow.emission;
		emission.rateOverTimeMultiplier = 0f;
		instance = this;
	}

	private void LateUpdate()
	{
		float num = 1f + player.curBuffs.GetBuff("addFreezeResist");
		coldAmount = Mathf.Clamp01(coldDebuff.GetMultiplier() + Time.deltaTime * freezeRate / num);
		if (player.curBuffs.GetBuff("warming") > 0.01f)
		{
			coldAmount = Mathf.Clamp01(coldDebuff.GetMultiplier() - Time.deltaTime * freezeRate * 4f * player.curBuffs.GetBuff("warming"));
		}
		coldDebuff.SetMultiplier(coldAmount);
		if (nextBlizzardTime < CL_GameManager.gMan.GetGameTime() && active)
		{
			StartBlizzard();
		}
		BlizzardEffects();
		if (hasBlizzard)
		{
			if (blizzardTimeRemaining <= 0f && hasBlizzard)
			{
				hasBlizzard = false;
			}
			blizzardTimeRemaining -= Time.deltaTime;
		}
		if (active)
		{
			if (!snowEffect.isPlaying)
			{
				snowEffect.Play();
				nextBlizzardTime = Random.Range(blizzardInbetweenTime.x, blizzardInbetweenTime.y) + CL_GameManager.gMan.GetGameTime() + blizzardTimeRemaining;
			}
		}
		else if (snowEffect.isPlaying)
		{
			snowEffect.Stop();
			hasBlizzard = false;
		}
	}

	public void StartBlizzard()
	{
		hasBlizzard = true;
		blizzardTimeRemaining = Random.Range(blizzardLength.x, blizzardLength.y);
		nextBlizzardTime = Random.Range(blizzardInbetweenTime.x, blizzardInbetweenTime.y) + CL_GameManager.gMan.GetGameTime() + blizzardTimeRemaining;
	}

	public void BlizzardEffects()
	{
		if (!(Camera.main == null))
		{
			blizzardObject.transform.position = Camera.main.transform.position;
			blizzardMaterial.SetFloat("_AlphaMult", blizzardValue);
			blizzardParticleWindZone.transform.rotation = Quaternion.LookRotation(blizzardWindDirection);
			if (hasBlizzard)
			{
				blizzardValue = Mathf.Lerp(blizzardValue, 1f, Time.deltaTime * 0.1f);
				Vector3 vector = new Vector3(Mathf.PerlinNoise(Time.time, 0f), Mathf.PerlinNoise(Time.time, 5f), Mathf.PerlinNoise(Time.time, 10f)) - Vector3.one * 0.5f;
				blizzardWindDirection = Vector3.Normalize(blizzardWindDirection + vector * blizzardWindChangeRate);
				player.AddForce(blizzardWindDirection * blizzardValue * blizzardWindSpeed * Time.deltaTime);
				CL_GameManager.gMan.ShakeCam(blizzardCameraShake * blizzardValue * Time.deltaTime);
			}
			else
			{
				blizzardValue = Mathf.Lerp(blizzardValue, 0f, Time.deltaTime * 0.2f);
			}
			blizzardAudio.volume = Mathf.Lerp(blizzardAudio.volume, blizzardValue * blizzardAudioVolume, CL_GameManager.GetPlayerPerceivedDeltaTime());
			blizzardParticleWindZone.windMain = blizzardValue * blizzardParticleWindZoneForce;
			blizzardDebuff.SetMultiplier(blizzardValue);
			ParticleSystem.EmissionModule emission = blizzardSnow.emission;
			emission.rateOverTimeMultiplier = blizzardValue * 1000f;
		}
	}

	public static void SetEventStatus(bool b)
	{
		active = b;
	}

	public static void ForceBlizzard()
	{
		if (!(instance == null))
		{
			instance.StartBlizzard();
		}
	}

	public static float GetFreezingAmount()
	{
		return ENT_Player.GetPlayer().curBuffs.GetBuff("freezing");
	}
}
