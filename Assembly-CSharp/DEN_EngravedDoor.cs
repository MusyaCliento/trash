using System.Collections.Generic;
using DarkMachine.AI;
using UnityEngine;

public class DEN_EngravedDoor : Denizen
{
	public Transform lookTarget;

	public float lookForce;

	public float lookFreq = 3f;

	public float lookCamShake = 0.03f;

	public AnimationCurve lookForceCurve;

	public float pullForce = 1f;

	public float damage;

	private float damageTime;

	public FXManager.FXData lookAtFX;

	public FXManager.FXData proximityFX;

	private float lookBlend;

	private float proximityBlend;

	private BuffContainer proximityDebuff;

	public BuffContainer proximityEffects;

	private BuffContainer lookDebuff;

	public BuffContainer lookEffects;

	private ENT_Player player;

	private AudioSource aud;

	public float audioVolume = 1f;

	public AISightComponent vision;

	private bool canSeeTarget;

	public Transform door;

	public float doorSwingAmount = 90f;

	public float doorSwingDist = 2f;

	public AnimationCurve doorSwingCurve;

	public List<string> headerStrings;

	public float headerFrequency;

	private float headerTimer;

	public AudioSource speakSource;

	public List<AudioClip> speakClips;

	private static int doorIDCounter;

	private int doorID;

	private void Awake()
	{
		doorID = doorIDCounter;
		doorIDCounter++;
		player = CL_GameManager.gMan.localPlayer;
		aud = GetComponent<AudioSource>();
		aud.volume = 0f;
	}

	private new void OnEnable()
	{
		AddDebuffToPlayer(ref proximityDebuff, proximityEffects);
		AddDebuffToPlayer(ref lookDebuff, lookEffects);
	}

	private new void OnDisable()
	{
		player.curBuffs.RemoveBuffContainer(proximityDebuff.id);
		player.curBuffs.RemoveBuffContainer(lookDebuff.id);
	}

	public override void Update()
	{
		base.Update();
		float num = Vector3.Distance(player.transform.position, lookTarget.transform.position);
		proximityBlend = 1f - Mathf.Clamp01((num + 4f) / vision.sightDistance);
		if (num > vision.sightDistance * 1.5f)
		{
			lookBlend = Mathf.Lerp(lookBlend, 0f, Time.deltaTime * 1f);
			DataLerp();
			return;
		}
		canSeeTarget = vision.CanSeeTarget(player.transform);
		RotatePlayerCamTowardsLookTarget();
		LookCheck();
		float num2 = doorSwingCurve.Evaluate(1f - Mathf.Clamp(num / doorSwingDist, 0f, 1f));
		num2 *= doorSwingAmount;
		door.localRotation = Quaternion.Euler(0f, num2, 0f);
		if (num < 1f)
		{
			player.Kill("engraveddoor");
		}
		if (canSeeTarget)
		{
			headerTimer -= Time.deltaTime;
			if (headerTimer <= 0f)
			{
				string s = "<color=red>" + headerStrings[Random.Range(0, headerStrings.Count)] + "</color>";
				CL_UIManager.instance.tipHeader.ShowText(s);
				speakSource.clip = speakClips[Random.Range(0, speakClips.Count)];
				speakSource.Play();
				headerTimer = Random.Range(headerFrequency, headerFrequency * 2f);
			}
		}
	}

	public void RotatePlayerCamTowardsLookTarget()
	{
		if (canSeeTarget)
		{
			Vector3 normalized = (lookTarget.transform.position - (Camera.main.transform.forward + Camera.main.transform.position)).normalized;
			Vector3 normalized2 = (Camera.main.transform.forward - normalized).normalized;
			normalized2 = Camera.main.transform.InverseTransformVector(normalized2);
			Vector3 vector = new Vector3(normalized2.y, 0f - normalized2.x, 0f).normalized * lookForceCurve.Evaluate(Mathf.Sin(Time.time * lookFreq) * 0.5f + 0.5f);
			float num = (InputManager.IsGamepad() ? 0.5f : 1f);
			ENT_Player.playerObject.AddRotationVelocity(vector * lookForce * Time.deltaTime * num);
			player.AddForce((lookTarget.transform.position - player.transform.position).normalized * pullForce * Time.deltaTime, "denizen");
		}
	}

	public void LookCheck()
	{
		float b = 0f;
		if (canSeeTarget && ENT_Player.playerObject.camRoot.CanSeeTarget(lookTarget, 70f))
		{
			if (damageTime <= 0f)
			{
				ENT_Player.playerObject.Damage(Damageable.DamageInfo.CreateDamageInfo(damage, "engraveddoor"));
				damageTime = 0.5f;
			}
			damageTime -= Time.deltaTime;
			b = 1f;
		}
		else
		{
			damageTime = 1f;
		}
		lookBlend = Mathf.Lerp(lookBlend, b, Time.deltaTime);
		lookDebuff.SetMultiplier(lookBlend);
		aud.volume = Mathf.Lerp(0f, audioVolume, lookBlend);
		ENT_Player.playerObject.camRoot.ShakeCamera(lookCamShake * lookBlend * (Mathf.Sin(Time.time * lookFreq) + 1f) * Time.deltaTime);
		DataLerp();
	}

	private void DataLerp()
	{
		FXManager.FXZoneStore fXZoneStore = new FXManager.FXZoneStore();
		fXZoneStore.blend = lookBlend;
		fXZoneStore.priority = 15;
		fXZoneStore.data = lookAtFX;
		FXManager.fxZones.Enqueue(fXZoneStore, 15);
		FXManager.FXZoneStore fXZoneStore2 = new FXManager.FXZoneStore();
		fXZoneStore2.blend = proximityBlend;
		fXZoneStore2.priority = 14;
		fXZoneStore2.data = proximityFX;
		FXManager.fxZones.Enqueue(fXZoneStore2, 14);
	}

	private void AddDebuffToPlayer(ref BuffContainer debuff, BuffContainer effects)
	{
		debuff = new BuffContainer();
		debuff.id = effects.id + doorID;
		debuff.buffs = new List<BuffContainer.Buff>();
		debuff.buffs.AddRange(effects.buffs);
		debuff.loseOverTime = false;
		debuff.SetMultiplier(0f);
		if (!player.curBuffs.HasBuffContainer(effects.id))
		{
			player.curBuffs.AddBuff(debuff);
		}
	}
}
