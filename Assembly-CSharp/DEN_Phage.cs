using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DEN_Phage : DEN_BasicNavigator
{
	public CL_Lamp eyeLamp;

	private BuffContainer lookDebuff;

	public BuffContainer lookEffects;

	public float lookCamShake = 0.01f;

	public FXManager.FXData lookAtFX;

	[SerializeReference]
	public new DenizenMovement_SteeringVehicle baseMovementModule;

	private float lookTime;

	private Vector3 lookDir = Vector3.up;

	public Transform cameraTakeoverRoot;

	public Transform meshRoot;

	public UnityEvent huntStartEvent;

	public UnityEvent huntEndEvent;

	public Perk perkAsset;

	private Rigidbody rigid;

	public UnityEvent stunEvent;

	public UnityEvent stunRecoverEvent;

	private Collider curCollider;

	private LayerMask excludedLayers;

	public static List<DEN_Phage> activePhages;

	public int infectionAmount = 1;

	private float lastHeardTime;

	private float lookBlend;

	private float stunTime;

	private float anger = 1f;

	public override void Start()
	{
		base.Start();
		Listener_Core listener_Core = listener;
		listener_Core._OnCatchSound = (Action<Listener_Core.ListenEvent>)Delegate.Combine(listener_Core._OnCatchSound, new Action<Listener_Core.ListenEvent>(OnCatchSound));
		rigid = GetComponent<Rigidbody>();
		curCollider = GetComponent<Collider>();
		excludedLayers = curCollider.excludeLayers;
	}

	public override void Initialize()
	{
		base.Initialize();
	}

	public override void Update()
	{
		base.Update();
		if (targetComponent.HasTarget())
		{
			eyeLamp.transform.rotation = Quaternion.Lerp(eyeLamp.transform.rotation, Quaternion.LookRotation(sight.GetLastSeenPosition() - eyeLamp.transform.position), Time.deltaTime * 5f);
		}
		else
		{
			lookTime -= Time.deltaTime;
			if (lookTime < 0f)
			{
				lookTime = 1f + UnityEngine.Random.value;
				lookDir = UnityEngine.Random.onUnitSphere + (GetTargetPosition() - base.transform.position).normalized * 0.5f;
			}
			eyeLamp.transform.rotation = Quaternion.Lerp(eyeLamp.transform.rotation, Quaternion.LookRotation(lookDir), Time.deltaTime * 8f);
		}
		if (currentState == huntState || canRememberTarget)
		{
			sight.visibilityBlend = 0.6f;
		}
		else
		{
			sight.visibilityBlend = 1f;
		}
		if (target != null && currentState == huntState && (Vector3.Distance(target.position, base.transform.position) < 15f || canSeeTarget))
		{
			meshRoot.localRotation = Quaternion.Lerp(meshRoot.localRotation, Quaternion.Euler(-90f, 0f, 0f), Time.deltaTime * 3f);
		}
		else
		{
			meshRoot.localRotation = Quaternion.Lerp(meshRoot.localRotation, Quaternion.Euler(-90f, 0f, -180f), Time.deltaTime * 3f);
		}
		if (stunTime > 0f)
		{
			stunTime -= Time.deltaTime;
			if (stunTime <= 0f)
			{
				stunRecoverEvent.Invoke();
				SetNavigationTarget(ENT_Player.GetPlayer().transform.position);
			}
			sight.active = false;
		}
		else
		{
			if (baseMovementModule.velocityMult == 0f)
			{
				baseMovementModule.velocityMult = 1f;
			}
			sight.active = true;
		}
	}

	private void LateUpdate()
	{
		LookCheck();
		float num = Vector3.Distance(ENT_Player.GetPlayer().transform.position, base.transform.position);
		if (canSeeTarget)
		{
			baseMovementModule.velocityMult = 1.6f;
			rigid.linearDamping = 2.5f;
		}
		else if (canRememberTarget)
		{
			baseMovementModule.velocityMult = 1.3f;
			rigid.linearDamping = 1.5f;
		}
		else if (stunTime > 0f)
		{
			baseMovementModule.velocityMult = 1.8f;
			rigid.linearDamping = 1.5f;
		}
		else
		{
			baseMovementModule.velocityMult = 1f;
			rigid.linearDamping = 1f;
		}
		if (num > 75f)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, GetTargetPosition(), Time.deltaTime * 3f);
			rigid.isKinematic = true;
		}
		else
		{
			rigid.isKinematic = false;
		}
	}

	public override void OnEnable()
	{
		if (activePhages == null)
		{
			activePhages = new List<DEN_Phage>();
		}
		activePhages.Add(this);
		AddDebuffToPlayer(ref lookDebuff, lookEffects);
		base.OnEnable();
	}

	public override void OnDisable()
	{
		if (activePhages != null)
		{
			activePhages.Remove(this);
		}
		ENT_Player.GetPlayer()?.curBuffs?.RemoveBuffContainer(lookDebuff.id);
		base.OnDisable();
	}

	public void OnCatchSound(Listener_Core.ListenEvent listenEvent)
	{
		bool flag = true;
		if (canSeeTarget)
		{
			flag = false;
		}
		if (flag && Time.time - lastHeardTime > 10f && listenEvent.tag != "organism")
		{
			lastHeardTime = Time.time;
			SetNavigationTarget(listenEvent.position);
			clipHandler.PlaySound("ai:hearsound");
		}
	}

	public void LookCheck()
	{
		float b = 0f;
		if (canSeeTarget)
		{
			b = 1f;
		}
		else if (canRememberTarget)
		{
			b = 0.5f;
		}
		lookBlend = Mathf.Lerp(lookBlend, b, Time.deltaTime);
		lookDebuff.SetMultiplier(lookBlend);
		ENT_Player.playerObject.camRoot.ShakeCamera(lookCamShake * lookBlend * (Mathf.Sin(Time.time * 3f) + 1f) * Time.deltaTime);
		DataLerp();
	}

	private void DataLerp()
	{
		FXManager.FXZoneStore fXZoneStore = new FXManager.FXZoneStore();
		fXZoneStore.blend = lookBlend;
		fXZoneStore.priority = 15;
		fXZoneStore.data = lookAtFX;
		FXManager.fxZones.Enqueue(fXZoneStore, 15);
	}

	private void AddDebuffToPlayer(ref BuffContainer debuff, BuffContainer effects)
	{
		debuff = new BuffContainer();
		debuff.id = effects.id;
		debuff.buffs = new List<BuffContainer.Buff>();
		debuff.buffs.AddRange(effects.buffs);
		debuff.loseOverTime = false;
		debuff.SetMultiplier(0f);
		if (!ENT_Player.GetPlayer().curBuffs.HasBuffContainer(effects.id))
		{
			ENT_Player.GetPlayer().curBuffs.AddBuff(debuff);
		}
	}

	internal override void OnAttackHit(GameEntity hitEntity, bool hasKilled)
	{
		bool num = hitEntity.GetTagger().HasTag("Player");
		hasKilled = false;
		clipHandler.PlaySound("ai:attack-hit");
		hitEntity.AddForce(base.transform.forward);
		if (!num)
		{
			return;
		}
		ENT_Player eNT_Player = hitEntity as ENT_Player;
		if (!eNT_Player.IsDead())
		{
			if (eNT_Player.HasPerk(perkAsset.id) && eNT_Player.GetPerk(perkAsset.id).stackAmount >= 3)
			{
				OnKillPlayer();
				return;
			}
			hitEntity.Damage(Damageable.DamageInfo.CreateDamageInfo(0f, attackTag));
			eNT_Player.AddPerk(perkAsset, infectionAmount);
		}
	}

	internal override void OnKillPlayer()
	{
		base.OnKillPlayer();
		StartCoroutine(KillPlayerAnimation());
		IEnumerator KillPlayerAnimation()
		{
			ENT_Player.playerObject.dead = true;
			clipHandler.PlaySound("phage:killplayer");
			speedMult = 0f;
			Vector3.Dot((base.transform.position - ENT_Player.playerObject.cam.transform.position).normalized, ENT_Player.playerObject.cam.transform.forward);
			ENT_Player.playerObject.DropEverything();
			ENT_Player.playerObject.Lock();
			CL_GameManager.gMan.lockPlayer = true;
			CL_GameManager.gMan.canPause = false;
			locked = true;
			Camera playerCam = ENT_Player.playerObject.cam;
			ENT_Player.playerObject.DropEverything();
			float anim = 0f;
			Vector3 camStartPos = playerCam.transform.position;
			Quaternion camStartRot = playerCam.transform.rotation;
			playerCam.transform.localRotation = Quaternion.identity;
			while (anim < 1f)
			{
				playerCam.fieldOfView = Mathf.Lerp(playerCam.fieldOfView, 30f, Time.deltaTime * 5f);
				ENT_Player.playerObject.Lock();
				anim += Time.deltaTime;
				ENT_Player.playerObject.camRoot.transform.position = Vector3.Lerp(camStartPos, cameraTakeoverRoot.position, anim);
				ENT_Player.playerObject.camRoot.transform.rotation = Quaternion.Lerp(camStartRot, cameraTakeoverRoot.rotation, anim);
				yield return null;
			}
			animator.SetTrigger("killplayer");
			anim = 0f;
			CL_CameraControl.Shake(0.1f);
			while (anim < 2.8f)
			{
				Mathf.Lerp(playerCam.fieldOfView, 20f, Time.deltaTime * 5f);
				ENT_Player.playerObject.Lock();
				anim += Time.deltaTime;
				ENT_Player.playerObject.camRoot.transform.position = cameraTakeoverRoot.position;
				ENT_Player.playerObject.camRoot.transform.rotation = cameraTakeoverRoot.rotation;
				playerCam.transform.localRotation = Quaternion.identity;
				yield return null;
			}
			ENT_Player.playerObject.transform.position = cameraTakeoverRoot.position;
			ENT_Player.playerObject.camRoot.transform.position = cameraTakeoverRoot.position;
			ENT_Player.playerObject.camRoot.transform.rotation = cameraTakeoverRoot.rotation;
			CL_GameManager.gMan.canPause = true;
			ENT_Player.playerObject.dead = false;
			ENT_Player.playerObject.Kill("phage");
		}
	}

	internal override void OnChangeState(string s)
	{
		base.OnChangeState(s);
		if (s == "hunt")
		{
			CL_CameraControl.Shake(0.2f);
			huntStartEvent.Invoke();
			curCollider.excludeLayers = 0;
		}
		else if (s == "wander")
		{
			huntEndEvent.Invoke();
			curCollider.excludeLayers = excludedLayers;
		}
	}

	public override bool Damage(Damageable.DamageInfo info)
	{
		info.amount /= anger;
		animator.SetTrigger("hurt");
		health -= info.amount;
		clipHandler.PlaySound("phage:hit");
		if (health <= 0f)
		{
			stunTime = 10f;
			health = maxHealth;
			clipHandler.PlaySound("phage:stun");
			CL_CameraControl.Shake(0.2f);
			stunEvent.Invoke();
			anger += 0.5f;
			ChangeState("wander");
			sight.ClearMemory();
			UT_Locator.LocatorGroup locatorGroup = UT_Locator.GetLocatorGroup("denizen-flee");
			if (locatorGroup == null)
			{
				SetNavigationTarget((base.transform.position - ENT_Player.GetPlayer().transform.position).normalized * 40f + base.transform.position);
			}
			else
			{
				UT_Locator uT_Locator = null;
				float num = 0f;
				foreach (UT_Locator allLocator in locatorGroup.GetAllLocators())
				{
					float num2 = Vector3.Distance(allLocator.transform.position, base.transform.position);
					if (num2 > num)
					{
						num = num2;
						uT_Locator = allLocator;
					}
				}
				if (uT_Locator == null)
				{
					SetNavigationTarget((base.transform.position - ENT_Player.GetPlayer().transform.position).normalized * 40f + base.transform.position);
				}
				else
				{
					SetNavigationTarget(uT_Locator.transform.position);
				}
			}
		}
		else
		{
			clipHandler.PlaySound("phage:hurt");
		}
		return false;
	}
}
