using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class HandItem_Shoot : HandItem
{
	[Serializable]
	public class ChargeShot
	{
		public string chargeShotName;

		public float chargeShotTime = 1f;

		public int chargeShotAmmoUse = 2;

		public bool useHoldBuff;

		public float holdBuffChangeRate = 1f;

		public BuffContainer holdBuff;

		private BuffContainer targetHoldBuffContainer;

		public GameObject chargeProjectile;

		public string primeAnimationTrigger = "Charged";

		public string primeAnimationBool = "";

		public string shootAnimationName = "Use";

		public bool useCustomCrosshair;

		public UI_CrosshairController.Crosshair crosshair;

		public UnityEvent shotStartEvent;

		public UnityEvent shotFireEvent;

		private bool initialized;

		public void Initialize()
		{
			if (!initialized)
			{
				initialized = true;
				if (useHoldBuff)
				{
					targetHoldBuffContainer = holdBuff.CopyBuffContainer();
					targetHoldBuffContainer.multiplier = 0f;
					ENT_Player.GetPlayer().Buff(targetHoldBuffContainer);
				}
			}
		}

		public void Activate()
		{
			if (useCustomCrosshair)
			{
				UI_CrosshairController.Crosshair obj = CL_UIManager.instance.crosshairController.AddCrosshair(crosshair);
				obj.crosshairImage.transform.DOPunchScale(Vector3.one * 8f, 1f);
				obj.crosshairImage.rectTransform.DORotate(new Vector3(0f, 0f, 180f), 0.5f);
				obj.crosshairImage.color = Color.clear;
				obj.crosshairImage.DOColor(Color.white, 0.4f);
			}
		}

		public void Deactivate()
		{
			if (useCustomCrosshair)
			{
				CL_UIManager.instance.crosshairController.RemoveCrosshair(crosshair.id);
			}
		}

		public void Unload()
		{
			Deactivate();
			if (useHoldBuff)
			{
				ENT_Player.GetPlayer().RemoveBuff(targetHoldBuffContainer);
			}
		}

		public BuffContainer GetTargetHoldBuffContainer()
		{
			return targetHoldBuffContainer;
		}
	}

	public LayerMask aimMask;

	public GameObject projectile;

	public bool useSelfItemAsProjectileHitEffect;

	private RaycastHit hit;

	public float shootSpeed = 50f;

	public float recoil = 1f;

	public string damageBuff = "addThrow";

	public string recoilBuff = "";

	public float maxRecoilMagnitude = 0.5f;

	public Vector2 cameraRecoil;

	public float initialShotInaccuracy;

	public float addedShotInaccuracy;

	public float maxShotInaccuracyMagnitude = 0.5f;

	public float shotInaccuracyLoseRate = 1f;

	private float curShotInaccuracy;

	public bool useCustomCrosshair;

	public UI_CrosshairController.Crosshair crosshair;

	public bool canUseUnderwater = true;

	public bool useAmmo;

	public string ammoTag;

	public int fillAmountPerAmmo = -1;

	public bool canReload = true;

	public bool canPocketWhileReloading;

	public bool canChargeReload;

	public int chargeReloadAmount = 1;

	public float chargeReloadTime = 3f;

	public UnityEvent chargeReloadStartEvent;

	public UnityEvent chargeReloadFinishEvent;

	public UnityEvent chargeReloadStopEvent;

	private bool reloading;

	private bool reloadBuffer;

	private List<Item> reloadingAmmo;

	private int reloadAmmo;

	public int maxAmmo = 5;

	public string maxAmmoBuffMod = "";

	public bool loadedAnimationState;

	private int ammo = 5;

	public bool shootOnStopUse;

	public bool useChargeShot;

	public List<ChargeShot> chargeShots;

	public float addThrowBuffMult = 1f;

	public UnityEvent useEvent;

	public UnityEvent reloadEvent;

	public UnityEvent shootEvent;

	public UT_AudioClipHandler clipHandler;

	public bool destroyItemAfterShoot;

	public bool dropOnlyItemAfterShoot;

	public string recoilJumpStat;

	public float shootStartShake = 0.015f;

	public float shootShake = 0.1f;

	public float primeShake;

	public string useAnimationTriggerName = "Use";

	public string primeAnimationName = "Primed";

	public string chargeReloadAnimationName = "Recharge";

	public string ammoAnimationIntegerName = "";

	public bool allowTwoHandedReload;

	public ParticleSystem tracerParticle;

	public float shootPunchFOV;

	public bool splatterBloodOnHit;

	public float splatterBloodDistance = 2f;

	private float twoHanded;

	private bool primed;

	private float primeStartTime;

	private ChargeShot curChargeShot;

	private bool recharging;

	private bool rechargeHasStarted;

	private float rechargeStartTime;

	private ChargeShot lastChargeShot;

	private int lastShotFrame;

	private bool pocketBuffer;

	public override void Initialize(Item i, ENT_Player.Hand h)
	{
		base.Initialize(i, h);
		if (useAmmo)
		{
			int.TryParse(item.GetFirstDataStringByType("ammo"), out ammo);
			if (loadedAnimationState)
			{
				anim.SetBool("Loaded", ammo > 0);
			}
			if (ammoAnimationIntegerName != "")
			{
				anim.SetInteger(ammoAnimationIntegerName, ammo);
			}
		}
		foreach (ChargeShot chargeShot in chargeShots)
		{
			chargeShot.Initialize();
		}
	}

	public override void OnEnable()
	{
		ResetUsedState();
	}

	public override void Update()
	{
		base.Update();
		if (allowTwoHandedReload)
		{
			twoHanded = Mathf.Lerp(twoHanded, (ENT_Player.GetPlayer().hands[(hand.id == 0) ? 1u : 0u].IsFree() && ENT_Player.GetPlayer().IsGrounded()) ? 1 : 0, Time.deltaTime * 15f);
			anim.SetFloat("TwoHanded", twoHanded);
		}
		curShotInaccuracy = Mathf.Max(curShotInaccuracy - Time.deltaTime * shotInaccuracyLoseRate, 0f);
		if (primed && !used)
		{
			CL_CameraControl.Shake(primeShake * Time.deltaTime);
			if (useChargeShot)
			{
				if (useChargeShot && curChargeShot != null && lastChargeShot != curChargeShot)
				{
					curChargeShot.shotStartEvent.Invoke();
					lastChargeShot = curChargeShot;
				}
				float num = Time.time - primeStartTime;
				float num2 = -1f;
				bool flag = false;
				ChargeShot chargeShot = null;
				foreach (ChargeShot chargeShot2 in chargeShots)
				{
					if (num > chargeShot2.chargeShotTime && chargeShot2.chargeShotTime > num2 && ammo >= chargeShot2.chargeShotAmmoUse)
					{
						num2 = chargeShot2.chargeShotTime;
						chargeShot = chargeShot2;
					}
				}
				if (curChargeShot != chargeShot)
				{
					if (curChargeShot != null)
					{
						curChargeShot.Deactivate();
					}
					chargeShot?.Activate();
					curChargeShot = chargeShot;
					flag = true;
				}
				if (curChargeShot != null && flag && !string.IsNullOrEmpty(curChargeShot.primeAnimationTrigger))
				{
					anim.SetTrigger(curChargeShot.primeAnimationTrigger);
				}
			}
		}
		foreach (ChargeShot chargeShot3 in chargeShots)
		{
			if (chargeShot3.useHoldBuff)
			{
				if (curChargeShot == chargeShot3)
				{
					chargeShot3.GetTargetHoldBuffContainer().multiplier = Mathf.Lerp(chargeShot3.GetTargetHoldBuffContainer().multiplier, 1f, Time.deltaTime * chargeShot3.holdBuffChangeRate);
				}
				else
				{
					chargeShot3.GetTargetHoldBuffContainer().multiplier = Mathf.Lerp(chargeShot3.GetTargetHoldBuffContainer().multiplier, 0f, Time.deltaTime * chargeShot3.holdBuffChangeRate);
				}
			}
			if (chargeShot3.primeAnimationBool != "" && curChargeShot != null)
			{
				anim.SetBool(curChargeShot.primeAnimationBool, curChargeShot == chargeShot3 && primed);
			}
		}
		if (!recharging)
		{
			return;
		}
		if (Time.time - rechargeStartTime > chargeReloadTime)
		{
			recharging = false;
			StartReload();
			Recharge(chargeReloadAmount);
			if (!string.IsNullOrEmpty(primeAnimationName))
			{
				anim.SetBool(primeAnimationName, value: false);
			}
			if (!string.IsNullOrEmpty(chargeReloadAnimationName))
			{
				anim.SetBool(chargeReloadAnimationName, value: false);
			}
			chargeReloadStopEvent.Invoke();
			primed = false;
			used = false;
			reloading = false;
			rechargeHasStarted = false;
			reloadBuffer = false;
		}
		else if (!rechargeHasStarted && Time.time - rechargeStartTime > 0.4f)
		{
			rechargeHasStarted = true;
			chargeReloadStartEvent.Invoke();
			if (!string.IsNullOrEmpty(chargeReloadAnimationName))
			{
				anim.SetBool(chargeReloadAnimationName, value: true);
			}
		}
	}

	public override void Refresh()
	{
		base.Refresh();
		int.TryParse(item.GetFirstDataStringByType("ammo"), out ammo);
	}

	public override void Use()
	{
		if (IsCurrentlyInteracting())
		{
			return;
		}
		if (hand.GetPlayer().IsCameraUnderwater() && !canUseUnderwater)
		{
			if (clipHandler != null)
			{
				clipHandler.PlaySound("item:useUnderwater");
			}
			return;
		}
		base.Use();
		if (used)
		{
			return;
		}
		if (useAmmo && ammo <= 0 && canChargeReload)
		{
			recharging = true;
			rechargeStartTime = Time.time;
			if (!shootOnStopUse && clipHandler != null)
			{
				clipHandler.PlaySound("item:noAmmo");
			}
		}
		if (!primed && clipHandler != null)
		{
			clipHandler.PlaySound("item:prime");
		}
		primed = true;
		primeStartTime = Time.time;
		if (!shootOnStopUse)
		{
			StartShoot();
		}
		else if ((!useAmmo || ammo > 0) && !string.IsNullOrEmpty(primeAnimationName))
		{
			anim.SetBool(primeAnimationName, value: true);
		}
	}

	public override void StopUse()
	{
		base.StopUse();
		if (primed)
		{
			if (shootOnStopUse)
			{
				StartShoot();
			}
			primed = false;
			if (!string.IsNullOrEmpty(primeAnimationName))
			{
				anim.SetBool(primeAnimationName, value: false);
			}
		}
		if (recharging)
		{
			recharging = false;
			rechargeHasStarted = false;
			reloading = false;
			reloadBuffer = false;
			chargeReloadStopEvent.Invoke();
			if (!string.IsNullOrEmpty(chargeReloadAnimationName))
			{
				anim.SetBool(chargeReloadAnimationName, value: false);
			}
		}
	}

	public virtual void StartShoot()
	{
		if (used)
		{
			return;
		}
		if (useAmmo)
		{
			int.TryParse(item.GetFirstDataStringByType("ammo"), out ammo);
			if (loadedAnimationState)
			{
				anim.SetBool("Loaded", ammo > 0);
			}
			if (ammo <= 0)
			{
				List<Item> list = null;
				if (canReload)
				{
					list = Inventory.instance.GetItemsByTag(ammoTag, checkBag: true, checkHands: true, allowInUse: false);
				}
				if (list != null && list.Count > 0)
				{
					reloadingAmmo = new List<Item>();
					int num = 0;
					reloadAmmo = 0;
					foreach (Item item in list)
					{
						num++;
						reloadingAmmo.Add(item);
						item.itemTags.Add("inuse");
						if (fillAmountPerAmmo > 0)
						{
							reloadAmmo += fillAmountPerAmmo;
						}
						else
						{
							reloadAmmo = maxAmmo;
						}
						if (!canPocketWhileReloading)
						{
							item.Destroy();
						}
						if ((float)num >= (float)maxAmmo / (float)fillAmountPerAmmo)
						{
							break;
						}
					}
					StartReload();
				}
				else if (canReload && ENT_Player.GetPlayer().HasInfiniteAmmo())
				{
					reloadAmmo = maxAmmo;
					StartReload();
				}
				else if (clipHandler != null)
				{
					clipHandler.PlaySound("item:noAmmo");
				}
				return;
			}
		}
		used = true;
		if (curChargeShot != null)
		{
			anim.SetTrigger(curChargeShot.shootAnimationName);
		}
		else
		{
			anim.SetTrigger(useAnimationTriggerName);
		}
		if (useAmmo)
		{
			if (canReload || !ENT_Player.GetPlayer().HasInfiniteAmmo())
			{
				if (curChargeShot != null)
				{
					ammo -= curChargeShot.chargeShotAmmoUse;
				}
				else
				{
					ammo--;
				}
			}
			base.item.SetFirstDataStringsofType("ammo", ammo.ToString());
			if (loadedAnimationState && ammo == 0)
			{
				anim.SetBool("Loaded", value: false);
			}
		}
		CL_CameraControl.Shake(shootStartShake);
		if (ammoAnimationIntegerName != "")
		{
			anim.SetInteger(ammoAnimationIntegerName, ammo);
		}
		if (clipHandler != null)
		{
			clipHandler.PlaySound("item:use");
		}
		useEvent.Invoke();
	}

	public virtual void Shoot()
	{
		int frameCount = Time.frameCount;
		if (frameCount - lastShotFrame <= 2)
		{
			return;
		}
		lastShotFrame = frameCount;
		shootEvent.Invoke();
		if (clipHandler != null)
		{
			clipHandler.PlaySound("item:shoot");
		}
		Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out var hitInfo, float.PositiveInfinity, aimMask);
		Vector3 startPos = Vector3.Lerp(base.transform.position, Camera.main.transform.position, 0.8f) + -Camera.main.transform.forward * 0.4f;
		CreateProjectile(hitInfo, startPos);
		curShotInaccuracy += addedShotInaccuracy;
		UpdateStats();
		CL_CameraControl.Shake(shootShake);
		if (recoilJumpStat != "" && hand.GetPlayer().cCon.velocity.y > 1f)
		{
			StatManager.sessionStats.UpdateStatistic(recoilJumpStat, 1, StatManager.Statistic.DataType.Int, StatManager.Statistic.ModType.Add);
		}
		if (hand.GetPlayer().cCon.isGrounded)
		{
			hand.GetPlayer().AddForce(-Camera.main.transform.forward * recoil * 0.2f);
		}
		else
		{
			hand.GetPlayer().AddForce(-Camera.main.transform.forward * recoil * 1f, maxRecoilMagnitude, "", 0.5f);
			if (!canUseWhileHanging)
			{
				hand.GetPlayer().DropHang(0.3f);
			}
		}
		if (curChargeShot != null)
		{
			curChargeShot.Deactivate();
		}
		curChargeShot = null;
		lastChargeShot = null;
		if (destroyItemAfterShoot)
		{
			item.Destroy();
		}
		else if (dropOnlyItemAfterShoot)
		{
			DropItemWithoutRemovingFromHand();
		}
		ENT_Player.GetPlayer().FOVShock(shootPunchFOV);
	}

	internal virtual Projectile CreateProjectile(RaycastHit hit, Vector3 startPos)
	{
		GameObject chargeProjectile = this.projectile;
		Projectile projectile = null;
		if (useChargeShot && curChargeShot != null)
		{
			chargeProjectile = curChargeShot.chargeProjectile;
			curChargeShot.shotFireEvent.Invoke();
		}
		ENT_Player.playerObject.AddQuickRotationVelocity(new Vector3(cameraRecoil.x, cameraRecoil.y, 0f));
		if (chargeProjectile != null)
		{
			Vector3 vector = UnityEngine.Random.insideUnitSphere * Mathf.Max(curShotInaccuracy, initialShotInaccuracy);
			vector = Vector3.ClampMagnitude(vector, maxShotInaccuracyMagnitude);
			GameObject gameObject = UnityEngine.Object.Instantiate(chargeProjectile, startPos, Quaternion.LookRotation(base.transform.forward));
			projectile = gameObject.GetComponent<Projectile>();
			projectile.damageTags.Add("player");
			projectile.AddIgnore(hand.GetPlayer().gameObject);
			ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
			if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, float.PositiveInfinity, aimMask))
			{
				Vector3 normalized = ((hit.point - gameObject.transform.position).normalized + vector).normalized;
				projectile.Initialize(normalized * shootSpeed, ENT_Player.GetPlayer(), item);
			}
			else
			{
				Vector3 normalized2 = (Camera.main.transform.forward + vector).normalized;
				projectile.Initialize(normalized2 * shootSpeed, ENT_Player.GetPlayer(), item);
			}
			emitParams.velocity = projectile.velocity.normalized * 300f;
			emitParams.startLifetime = hit.distance / 300f;
			if (ENT_Player.GetPlayer().curBuffs.GetBuff("addThrow") > 0f)
			{
				projectile.damage *= addThrowBuffMult * ENT_Player.GetPlayer().curBuffs.GetBuff("addThrow") + 1f;
			}
			if (tracerParticle != null)
			{
				tracerParticle.Emit(emitParams, 1);
			}
			Projectile obj = projectile;
			obj._OnProjectileHit = (Action<Projectile, RaycastHit, ObjectTagger>)Delegate.Combine(obj._OnProjectileHit, new Action<Projectile, RaycastHit, ObjectTagger>(OnProjectileHit));
		}
		if (useSelfItemAsProjectileHitEffect)
		{
			projectile.SetHitItem(item);
		}
		return projectile;
	}

	public void ResetUsedState()
	{
		used = false;
		if (pocketBuffer)
		{
			PocketHandItem();
		}
	}

	public void PitonHit()
	{
		Shoot();
	}

	public virtual void StartReload()
	{
		used = true;
		reloading = true;
		if (allowTwoHandedReload)
		{
			if (hand.GetOtherHand().IsFree() && ENT_Player.GetPlayer().IsGrounded())
			{
				anim.SetTrigger("ReloadTwoHanded");
				if (clipHandler != null)
				{
					clipHandler.PlaySound("item:reloadtwohand");
				}
			}
			else
			{
				anim.SetTrigger("Reload");
				if (clipHandler != null)
				{
					clipHandler.PlaySound("item:reload");
				}
			}
		}
		else
		{
			anim.SetTrigger("Reload");
			if (clipHandler != null)
			{
				clipHandler.PlaySound("item:reload");
			}
		}
	}

	public virtual void FinishReload()
	{
		used = false;
		reloading = false;
		reloadBuffer = false;
		if (reloadAmmo > 0)
		{
			ammo = reloadAmmo;
		}
		else
		{
			ammo = GetMaxAmmo();
		}
		if (ammoAnimationIntegerName != "")
		{
			anim.SetInteger(ammoAnimationIntegerName, ammo);
		}
		item.SetFirstDataStringsofType("ammo", ammo.ToString() ?? "");
		if (loadedAnimationState)
		{
			anim.SetBool("Loaded", value: true);
		}
		reloadEvent.Invoke();
		if (pocketBuffer)
		{
			PocketHandItem();
		}
	}

	public virtual void AllowReloadBuffer()
	{
		reloadBuffer = true;
		RemoveReloadingAmmo();
	}

	public virtual void OnDisable()
	{
		if (reloadingAmmo != null)
		{
			foreach (Item item in reloadingAmmo)
			{
				if (item != null && item.itemTags.Contains("inuse"))
				{
					item.itemTags.Remove("inuse");
				}
			}
		}
		foreach (ChargeShot chargeShot in chargeShots)
		{
			chargeShot.Unload();
		}
	}

	private void RemoveReloadingAmmo()
	{
		if (reloadingAmmo == null || reloadingAmmo.Count <= 0)
		{
			return;
		}
		foreach (Item item in reloadingAmmo)
		{
			item.Destroy();
		}
	}

	public override void OnDrop()
	{
		base.OnDrop();
	}

	public override bool CanDrop(bool pocket = false)
	{
		if (pocket && canPocketWhileReloading && reloading && !pocketBuffer)
		{
			return true;
		}
		if (reloading)
		{
			return false;
		}
		return !used;
	}

	public override void OnTryPocket()
	{
		if ((reloading && reloadBuffer) || (!reloading && used))
		{
			pocketBuffer = true;
		}
		base.OnTryPocket();
	}

	public override void PocketHandItem()
	{
		pocketBuffer = false;
		base.PocketHandItem();
	}

	public int GetAmmo()
	{
		return ammo;
	}

	public int GetMaxAmmo()
	{
		float num = maxAmmo;
		if (maxAmmoBuffMod != "")
		{
			float num2 = 1f + ENT_Player.GetPlayer().curBuffs.GetBuff(maxAmmoBuffMod);
			num *= num2;
		}
		return Mathf.CeilToInt(num);
	}

	public float GetAmmoPercent()
	{
		return (float)ammo / (float)GetMaxAmmo();
	}

	public float GetPrimeLength()
	{
		if (!primed)
		{
			return 0f;
		}
		return Time.time - primeStartTime;
	}

	public void Recharge()
	{
		ammo = GetMaxAmmo();
		item.SetFirstDataStringsofType("ammo", ammo.ToString());
	}

	public void Recharge(int i)
	{
		ammo = Mathf.Clamp(ammo + i, 0, GetMaxAmmo());
		item.SetFirstDataStringsofType("ammo", ammo.ToString());
	}

	public virtual void OnProjectileHit(Projectile p, RaycastHit hit, ObjectTagger tagger)
	{
		Debug.Log("Projectile hit: " + p.name + " hit: " + hit.point);
		if (splatterBloodOnHit && tagger != null && tagger.HasTag("Creature") && Vector3.Distance(hit.point, ENT_Player.GetPlayer().cam.transform.position) < splatterBloodDistance)
		{
			ENT_Player.GetPlayer().SplatterScreenBlood(3, tagger.tags);
		}
	}
}
