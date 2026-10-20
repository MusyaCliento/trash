using System;
using System.Collections.Generic;
using UnityEngine;

public class HandItem_Melee : HandItem
{
	[Serializable]
	public class HammerHitEffect
	{
		public string tag;

		public string hitAudioSet;

		public bool useLastHitAudio;

		public string lasthitAudioSet;

		public GameObject hitEffect;

		public FX_DecalShared decal;

		public bool freezeOnHit;

		public float freezeTime = 0.2f;

		[SerializeReference]
		public List<HitEffectModule> hitEffectModules;

		public int bloodSplatterAmount;

		public int chargedExtraBloodSplatterAmount;
	}

	public LayerMask hitMask;

	public UT_AudioClipHandler aud;

	public List<HammerHitEffect> hitEffects;

	internal RaycastHit hit;

	internal bool hasHit;

	internal ObjectTagger hitTagger;

	public float damage = 1f;

	public string damageType = "Melee";

	public List<string> damageTags;

	public float range = 2.8f;

	public float sphereCastSize = 0.1f;

	public float multiSwingTime = 0.8f;

	public float hammerAmount = 0.35f;

	public float hammerAssist = 50f;

	public float hammerAssistRadius = 1f;

	public int randomHammerAnimMin;

	public int randomHammerAnims = 3;

	public bool banHammer;

	[Header("Charge Attack Settings")]
	public bool canCharge;

	public float minimumChargeAttackTime = 0.5f;

	public float chargeAttackDamage = 2f;

	public float chargeHammer = 0.35f;

	public AudioSource chargeAudioSource;

	public float chargeAudioVolume = 1f;

	public string swingAudioName = "hammer:swing";

	public string chargeStartAudioName = "hammer:charge-start";

	public float chargeStartAudioTime = 0.25f;

	public string chargeSwingAudioName = "hammer:charge-swing";

	private float chargeStartTime;

	internal bool isChargedAttack;

	internal bool isCharging;

	private bool hasPlayedChargeStartAudio;

	internal bool hasChargedEnough;

	private float timeSinceLastSwing;

	private bool isUsing;

	public override void OnEnable()
	{
		used = false;
		chargeStartTime = float.PositiveInfinity;
	}

	public override void Update()
	{
		if (CL_UIManager.debug && Physics.SphereCast(Camera.main.transform.position, 0.1f, Camera.main.transform.forward, out var hitInfo, range, hitMask))
		{
			CL_DebugView.draw.SphereOutline(hitInfo.point, 0.1f, Color.magenta);
		}
		HitCast();
		if (hasHit && hitTagger != null && hitTagger.HasTag("Meleeable") && hitTagger.HasTag("Highlightable"))
		{
			UT_Highlight component = hitTagger.GetComponent<UT_Highlight>();
			if (component != null)
			{
				component.Highlight();
			}
		}
		timeSinceLastSwing += Time.deltaTime;
		base.Update();
		if (canCharge)
		{
			if (chargeAudioSource != null)
			{
				if (!chargeAudioSource.isPlaying)
				{
					chargeAudioSource.Play();
				}
				chargeAudioSource.volume = Mathf.Lerp(chargeAudioSource.volume, (isCharging && Time.time - chargeStartTime > 0.25f) ? chargeAudioVolume : 0f, Time.deltaTime * 4f);
			}
			if (Time.time - chargeStartTime > minimumChargeAttackTime)
			{
				anim.SetBool("Charged", value: true);
				if (!hasChargedEnough)
				{
					hasChargedEnough = true;
					OnChargeReady();
				}
			}
			if (isCharging && Time.time - chargeStartTime > chargeStartAudioTime && !hasPlayedChargeStartAudio)
			{
				hasPlayedChargeStartAudio = true;
				aud.PlaySound(chargeStartAudioName);
			}
		}
		if (canCharge && !isUsing && isCharging && !used)
		{
			OnChargeStop();
			StopUse();
		}
	}

	public override void Use()
	{
		base.Use();
		isUsing = true;
		if (used)
		{
			if (canCharge)
			{
				isCharging = true;
				anim.SetBool("Charging", value: true);
				chargeStartTime = Time.time;
			}
		}
		else if (!canCharge)
		{
			StartUse();
		}
		else
		{
			chargeStartTime = Time.time;
			anim.SetBool("Charging", value: true);
			isCharging = true;
		}
	}

	public override void StopUse()
	{
		base.StopUse();
		isUsing = false;
		if (canCharge && isCharging && !used)
		{
			if (Time.time - chargeStartTime > minimumChargeAttackTime)
			{
				StartUse(charged: true);
			}
			else
			{
				StartUse();
			}
			anim.SetBool("Charging", value: false);
			anim.SetBool("Charged", value: false);
			chargeStartTime = float.PositiveInfinity;
			isCharging = false;
			hasChargedEnough = false;
			hasPlayedChargeStartAudio = false;
		}
	}

	public virtual void StartUse(bool charged = false)
	{
		used = true;
		if (charged)
		{
			isChargedAttack = true;
			OnChargeAttack();
			aud.PlaySound(chargeSwingAudioName);
		}
		else
		{
			aud.PlaySound(swingAudioName);
		}
		if (timeSinceLastSwing < multiSwingTime || charged)
		{
			anim.SetInteger("Random", UnityEngine.Random.Range(randomHammerAnimMin, randomHammerAnims));
			ENT_Player.playerObject.AddRotationVelocity(Vector3.up * -GetDirection() * UnityEngine.Random.Range(-0.5f, 1.1f) * 15f + UnityEngine.Random.Range(0f, 7f) * Vector3.right);
		}
		else
		{
			anim.SetInteger("Random", 0);
		}
		if (charged)
		{
			anim.SetTrigger("UseCharged");
		}
		else
		{
			anim.SetTrigger("Use");
		}
		CL_CameraControl.Shake(0.01f);
	}

	public virtual void HitCast()
	{
		if (Physics.SphereCast(Camera.main.transform.position, sphereCastSize, Camera.main.transform.forward, out hit, range, hitMask))
		{
			hasHit = true;
			hitTagger = hit.collider.GetComponent<ObjectTagger>();
		}
		else
		{
			hasHit = false;
			hitTagger = null;
		}
		if (timeSinceLastSwing < multiSwingTime && hitTagger == null && Physics.SphereCast(Camera.main.transform.position, sphereCastSize * 2f, Camera.main.transform.forward, out var hitInfo, range, hitMask))
		{
			hasHit = true;
			hit = hitInfo;
			hitTagger = hit.collider.GetComponent<ObjectTagger>();
		}
		if (!InputManager.IsGamepad())
		{
			return;
		}
		Vector3 point = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
		if (hasHit)
		{
			point = hit.point;
		}
		Collider[] array = Physics.OverlapCapsule(point, Camera.main.transform.position, hammerAssistRadius, hitMask);
		for (int i = 0; i < array.Length; i++)
		{
			ObjectTagger component = array[i].GetComponent<ObjectTagger>();
			if (component != null && component.HasTag("Meleeable") && component.HasTag("Highlightable"))
			{
				CL_Handhold component2 = component.GetComponent<CL_Handhold>();
				if (!component2.secure)
				{
					Vector3 normalized = (component2.transform.position - (Camera.main.transform.forward + Camera.main.transform.position)).normalized;
					Vector3 normalized2 = (Camera.main.transform.forward - normalized).normalized;
					normalized2 = Camera.main.transform.InverseTransformVector(normalized2);
					Vector3 vector = new Vector3(normalized2.y, 0f - normalized2.x, 0f);
					ENT_Player.playerObject.AddRotationVelocity(vector * hammerAssist * Time.deltaTime);
					hasHit = true;
					hitTagger = component;
					break;
				}
			}
		}
	}

	public virtual void Hit()
	{
		float buff = ENT_Player.playerObject.curBuffs.GetBuff("addStrike");
		buff = ((!isChargedAttack) ? (buff + damage) : (buff + chargeAttackDamage));
		bool flag = false;
		bool flag2 = false;
		if (hasHit)
		{
			if (isChargedAttack)
			{
				aud.PlaySound("hit:charged");
				OnChargeAttackHit(hit);
			}
			if (banHammer)
			{
				UnityEngine.Object.Destroy(hit.collider.gameObject);
				aud.GetGroup("hit").PlayAudioSet("hit");
				return;
			}
			Debug.Log("MELEE HIT: " + hit.collider.name + " :: " + hitTagger);
			if (hitTagger != null)
			{
				GameEntity gameEntity = null;
				Hitbox component = hitTagger.GetComponent<Hitbox>();
				if (component != null)
				{
					gameEntity = component.GetGameEntity();
				}
				if (gameEntity != null)
				{
					hitTagger = gameEntity.GetTagger();
				}
				bool flag3 = hitTagger.HasTag("Hammerable");
				if (hitTagger.HasTag("Damageable") && !flag3)
				{
					Damageable.DamageInfo damageInfo = Damageable.DamageInfo.CreateDamageInfo(buff, "Melee", damageTags, ENT_Player.playerObject);
					damageInfo.position = hit.point;
					damageInfo.tags.Add("player");
					damageInfo.sourceEntity = hand.GetPlayer();
					damageInfo.sourceObject = hand.GetPlayer().gameObject;
					flag2 = hit.collider.GetComponent<Damageable>().Damage(damageInfo);
				}
				if (hitTagger.HasTag("Handhold"))
				{
					CL_Handhold component2 = hitTagger.GetComponent<CL_Handhold>();
					if (component2 != null && component2.canHammer)
					{
						float num = ENT_Player.playerObject.curBuffs.GetBuff("addHammer");
						if (isChargedAttack)
						{
							num += chargeHammer;
						}
						component2.HammerIn(hammerAmount + num);
						flag = true;
						if (!component2.secure)
						{
							aud.GetGroup("hit").PlayAudioSet("hit-piton");
						}
						else
						{
							HitFreeze();
							aud.GetGroup("hit").PlayAudioSet("hit-secure");
						}
					}
				}
				else if (hitTagger.HasTag("Button"))
				{
					CL_Button component3 = hitTagger.GetComponent<CL_Button>();
					if (component3 != null && component3.hammerCanPress)
					{
						component3.Interact();
					}
				}
				if (hitTagger.HasTag("Entity") && gameEntity != null)
				{
					if (hitTagger.HasTag("Prop"))
					{
						gameEntity.AddForceAtPosition(Camera.main.transform.forward * 40f, hit.point);
						CL_Prop component4 = GetComponent<CL_Prop>();
						if (component4 != null)
						{
							component4.AddBreakingVelocity(Camera.main.transform.forward);
						}
					}
					else if (gameEntity != null)
					{
						gameEntity.AddForce(Camera.main.transform.forward * 20f);
					}
				}
				if (!flag && (gameEntity == null || gameEntity.damageable))
				{
					foreach (HammerHitEffect hitEffect in hitEffects)
					{
						if (!hitTagger.HasTag(hitEffect.tag))
						{
							continue;
						}
						if (hitEffect.hitEffect != null)
						{
							UnityEngine.Object.Instantiate(hitEffect.hitEffect, hit.point, Quaternion.Euler(hit.normal), null);
						}
						if (hitEffect.decal != null)
						{
							FXManager.DecalHandle handle = FXManager.DecalCreate(FXManager.DecalPriority.Low);
							FXManager.DecalSharedApply(handle, FXManager.DecalSharedData(hitEffect.decal));
							FXManager.DecalPointingFrom(handle, hit.point, hit.normal, base.transform.forward, (hit.collider != null) ? hit.collider.transform : null);
						}
						if (hitEffect.freezeOnHit && flag2)
						{
							CL_CameraControl.Shake(0.03f);
							HitFreeze(hitEffect.freezeTime, 0.02f);
							if (hitEffect.useLastHitAudio)
							{
								aud.GetGroup("hit").PlayAudioSet(hitEffect.lasthitAudioSet);
							}
						}
						if (!flag2 || !hitEffect.useLastHitAudio)
						{
							aud.GetGroup("hit").PlayAudioSet(hitEffect.hitAudioSet);
						}
						if (hitEffect.hitEffectModules != null && hitEffect.hitEffectModules.Count > 0)
						{
							foreach (HitEffectModule hitEffectModule in hitEffect.hitEffectModules)
							{
								hitEffectModule.OnHit(new HitEffectModule.Desc
								{
									target = hit.transform,
									position = hit.point,
									normal = hit.normal
								});
							}
						}
						if (hitEffect.bloodSplatterAmount > 0)
						{
							ENT_Player.GetPlayer().SplatterScreenBlood(hitEffect.bloodSplatterAmount, hitTagger.tags);
						}
						if (isChargedAttack && hitEffect.chargedExtraBloodSplatterAmount > 0)
						{
							ENT_Player.GetPlayer().SplatterScreenBlood(hitEffect.chargedExtraBloodSplatterAmount, hitTagger.tags);
						}
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				UnityEngine.Object.Instantiate(hitEffects[0].hitEffect, hit.point, Quaternion.Euler(hit.normal), null);
				if (hitEffects[0].decal != null)
				{
					FXManager.DecalHandle handle2 = FXManager.DecalCreate(FXManager.DecalPriority.Low);
					FXManager.DecalSharedApply(handle2, FXManager.DecalSharedData(hitEffects[0].decal));
					FXManager.DecalPointingFrom(handle2, hit.point, hit.normal, base.transform.forward, (hit.collider != null) ? hit.collider.transform : null);
				}
				aud.GetGroup("hit").PlayAudioSet("hit");
			}
			CL_CameraControl.Shake(0.015f);
			used = true;
		}
		isChargedAttack = false;
	}

	internal void HitFreeze(float amount = 0.1f, float shakeAmount = 0.01f, float scale = 0.01f)
	{
		if (isChargedAttack)
		{
			amount *= 1.8f;
			shakeAmount *= 1.5f;
		}
		CL_GameManager.gMan.FreezeForTime(amount, scale);
		sway.Shake(shakeAmount);
	}

	public virtual void OnChargeAttack()
	{
	}

	public virtual void OnChargeAttackHit(RaycastHit hit)
	{
	}

	public virtual void OnChargeReady()
	{
	}

	public virtual void OnChargeStop()
	{
	}

	public virtual void Ready()
	{
		used = false;
		timeSinceLastSwing = 0f;
		isChargedAttack = false;
	}
}
