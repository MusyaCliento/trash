using System;
using System.Collections.Generic;
using Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviourGizmos
{
	[Serializable]
	public class HitEffect
	{
		public string name;

		public List<string> tags;

		public GameObject hitEffect;

		public string hitParticleID;

		public int hitParticleAmount = 10;

		public HitType hitType = HitType.none;

		public bool disableOnNoParent = true;

		public List<AudioClip> hitSounds;

		public float hitSoundVolume = 1f;

		public float hitSoundPitchVariance = 0.1f;

		public float hitSoundSpatialBlend = 1f;

		public FX_DecalShared decal;

		public bool allowRicochet = true;

		public UnityEvent onHitEvent;

		public bool punchHole;

		public string punchHoleParticleID = "";

		public int punchHoleParticleAmount = 10;
	}

	public enum HitType
	{
		parent = 0,
		locationParent = 1,
		pierce = 2,
		none = 3,
		ignore = 4,
		parentHitItem = 5,
		softParentRelativePositionNoRotation = 32
	}

	public float damage = 1f;

	public string damageType;

	public List<string> damageTags;

	public bool knockHold;

	public float staminaDamage;

	public float speed = 1f;

	public float lifetime = 10f;

	public bool pierceOnKill;

	public bool skewerOnKill;

	internal Vector3 velocity;

	public LayerMask hitMask;

	public float airResistance = 0.1f;

	public float hitRadius = 0.1f;

	public float hitForceMultiplier = 1f;

	public string hitForceTag = "projectile";

	public float hitForceBase;

	public float gravity;

	public bool canRicochet = true;

	public float bounceAngle = 30f;

	public float bounceDampen = 0.8f;

	public int maxBounces;

	public Vector3 lastPos;

	public bool faceVelocity = true;

	public bool parentUnderActiveLevel = true;

	public GameObject lifetimeBreakEffectPrefab;

	public bool useHitEffects = true;

	public bool destroyOnHit = true;

	public bool softParentProjectileOnHit;

	public bool punchHole;

	public UnityEvent onHitEvent;

	public FX_DecalShared defaultDecal;

	public GameObject hitEffect;

	public bool flipHitEffect;

	public HitType hitType = HitType.none;

	public List<HitEffect> customHitEffects;

	internal Item hitItem;

	public float hitFaceNormalBlend;

	public bool useTracer;

	public FXManager.ParticleTracerInfo particleTracerInfo;

	private bool hasHitSurface;

	public List<AudioClip> spawnSound;

	public List<AudioClip> reflectSound;

	public List<AudioClip> hitSound;

	public List<AudioClip> pierceSound;

	public List<AudioClip> hitDamageSounds;

	public float hitDamageSoundSpacial;

	public List<AudioClip> hitKillSounds;

	public List<AudioClip> hitWeakSpotSounds;

	public bool broadcastHitToListeners;

	public string broadcastTag;

	public float broadcastRadius;

	internal bool stopped;

	internal int bounces;

	private Vector3 fakeStartPos = Vector3.zero;

	private Vector3 startPos;

	internal float timer;

	internal List<Transform> hasHit = new List<Transform>();

	internal List<GameEntity> skeweredEntities = new List<GameEntity>();

	private Vector3 startScale;

	private float velMult = 1f;

	private List<GameObject> ignoreObjects = new List<GameObject>();

	private GameEntity sourceEntity;

	internal Item sourceItem;

	public Action<Projectile, RaycastHit, ObjectTagger> _OnProjectileHit;

	public Action<Projectile, RaycastHit, GameEntity, Damageable.DamageInfo> _OnProjectileHitGameEntity;

	private bool initialized;

	public virtual void Initialize(Vector3 direction, GameEntity ent = null, Item item = null)
	{
		velocity = direction * speed;
		sourceEntity = ent;
		sourceItem = item;
		if (parentUnderActiveLevel)
		{
			base.transform.parent = WorldLoader.GetCurrentLevelParentRoot();
		}
		initialized = true;
		startPos = base.transform.position;
	}

	public void SetHitItem(Item i)
	{
		hitItem = i;
		hitItem.GetDropObject().gameObject.SetActive(value: false);
	}

	private void Start()
	{
		startScale = base.transform.localScale;
		startPos = base.transform.position;
		lastPos = base.transform.position;
		if (spawnSound != null && spawnSound.Count > 0)
		{
			AudioManager.PlaySound(spawnSound[UnityEngine.Random.Range(0, spawnSound.Count)], base.transform.position);
		}
		if (useTracer && particleTracerInfo.muzzleID != "")
		{
			FXManager.PlayParticle(particleTracerInfo.muzzleID, base.transform.position, 15);
		}
		skeweredEntities = new List<GameEntity>();
		if (!initialized)
		{
			Initialize(base.transform.forward);
		}
	}

	public virtual void Update()
	{
		ProjectilePhysics();
		lifetime -= Time.deltaTime;
		if (lifetime <= 0f)
		{
			if (lifetimeBreakEffectPrefab != null)
			{
				UnityEngine.Object.Instantiate(lifetimeBreakEffectPrefab, base.transform.position, base.transform.rotation);
			}
			UnityEngine.Object.Destroy(base.gameObject);
			if (useTracer)
			{
				FXManager.PlayTracer(particleTracerInfo.tracerID, startPos, base.transform.position, velocity.magnitude);
			}
		}
		if (hitItem != null)
		{
			if (hitItem.hasBeenDestroyed)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			hitItem.GetDropObject().gameObject.SetActive(value: false);
			hitItem.Execute(null);
			hitItem.GetDropObject().transform.position = base.transform.position;
			hitItem.GetDropObject().transform.rotation = base.transform.rotation;
		}
	}

	protected virtual void LateUpdate()
	{
		if (!skewerOnKill || skeweredEntities == null || skeweredEntities.Count <= 0)
		{
			return;
		}
		foreach (GameEntity skeweredEntity in skeweredEntities)
		{
			if (skeweredEntity != null)
			{
				skeweredEntity.transform.position = base.transform.position;
				skeweredEntity.transform.rotation = base.transform.rotation;
			}
		}
	}

	public virtual void ProjectilePhysics()
	{
		if (hasHitSurface)
		{
			return;
		}
		base.transform.localScale = Vector3.Lerp(startScale * 0.25f, startScale, timer * 8f);
		timer += Time.deltaTime;
		if (!stopped && !CL_GameManager.gMan.isPaused)
		{
			velocity += Vector3.down * gravity * Time.deltaTime;
			Vector3 vector = -velocity.normalized * airResistance * velocity.sqrMagnitude;
			velocity += vector * Time.deltaTime;
			base.transform.position += velocity * Time.deltaTime * velMult;
			if (faceVelocity)
			{
				base.transform.rotation = Quaternion.LookRotation(velocity);
			}
			CollisionCheck();
			lastPos = base.transform.position;
		}
	}

	internal virtual void CollisionCheck()
	{
		if (!Physics.SphereCast(lastPos, hitRadius, (base.transform.position - lastPos).normalized, out var hitInfo, Vector3.Distance(base.transform.position, lastPos), hitMask))
		{
			return;
		}
		ObjectTagger tagger = hitInfo.collider.GetComponent<ObjectTagger>();
		if (ignoreObjects.Contains(hitInfo.collider.gameObject))
		{
			return;
		}
		if (tagger != null && tagger.HasTag("Hitbox"))
		{
			Hitbox component = hitInfo.collider.GetComponent<Hitbox>();
			if (component != null && component.GetGameEntity() != null && ignoreObjects.Contains(component.GetGameEntity().gameObject))
			{
				return;
			}
		}
		bool hasHitThis = false;
		bool num = RicochetCheck(hitInfo);
		bool hasKilled = false;
		if (tagger != null)
		{
			HitInteractions(ref hitInfo, ref tagger, ref hasHitThis, out hasKilled);
		}
		else
		{
			_OnProjectileHit?.Invoke(this, hitInfo, null);
		}
		if (!num)
		{
			OnCollisionHit(hitInfo, tagger, hasHitThis, hasKilled);
		}
	}

	internal virtual void OnCollisionHit(RaycastHit hit, ObjectTagger tagger, bool hasHitThis, bool hasKilled = false)
	{
		if (hasHitSurface)
		{
			return;
		}
		base.transform.localScale = startScale;
		if (!(hit.collider != null))
		{
			return;
		}
		bool flag = false;
		if (tagger != null)
		{
			foreach (HitEffect customHitEffect in customHitEffects)
			{
				if (!tagger.HasTagInList(customHitEffect.tags.ToArray()))
				{
					continue;
				}
				if (customHitEffect.hitType == HitType.pierce)
				{
					if (!hasHitThis)
					{
						if (pierceSound != null && pierceSound.Count > 0)
						{
							AudioManager.PlaySound(pierceSound[UnityEngine.Random.Range(0, pierceSound.Count)], base.transform.position);
						}
						else if (hitSound != null && hitSound.Count > 0)
						{
							AudioManager.PlaySound(hitSound[UnityEngine.Random.Range(0, hitSound.Count)], base.transform.position);
						}
					}
					int layer = hit.collider.gameObject.layer;
					hit.collider.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
					CollisionCheck();
					hit.collider.gameObject.layer = layer;
				}
				else if (customHitEffect.hitType != HitType.ignore)
				{
					if (customHitEffect.hitType == HitType.parentHitItem)
					{
						ParentHitItem(hit, customHitEffect);
					}
					if (!hasKilled || !pierceOnKill)
					{
						CreateHitEffect(hit, customHitEffect);
					}
					flag = true;
				}
				return;
			}
		}
		if (!flag && (!hasKilled || !pierceOnKill))
		{
			HitEffect hitEffect = new HitEffect();
			hitEffect.hitEffect = this.hitEffect;
			hitEffect.hitType = hitType;
			hitEffect.decal = defaultDecal;
			CreateHitEffect(hit, hitEffect);
			ParentHitItem(hit, hitEffect);
		}
		else
		{
			int layer2 = hit.collider.gameObject.layer;
			hit.collider.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
			CollisionCheck();
			hit.collider.gameObject.layer = layer2;
		}
	}

	private void ParentHitItem(RaycastHit hit, HitEffect baseHitEffect)
	{
		if (hitItem == null)
		{
			return;
		}
		Item clone = hitItem.GetClone();
		if (!hitItem.hasBeenDestroyed)
		{
			hitItem.Destroy();
		}
		clone.hasBeenDestroyed = false;
		clone.PlaceInWorld(hit.point);
		clone.GetDropObject().transform.position = hit.point;
		Quaternion rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(-hit.normal), hitFaceNormalBlend);
		clone.GetDropObject().transform.rotation = rotation;
		if (!(hit.transform != null))
		{
			return;
		}
		if (baseHitEffect.hitType == HitType.parent)
		{
			clone.GetDropObject().transform.parent = hit.collider.transform;
		}
		else if (baseHitEffect.hitType == HitType.locationParent || baseHitEffect.hitType == HitType.parentHitItem || baseHitEffect.hitType == HitType.softParentRelativePositionNoRotation)
		{
			UT_SoftParent orAddComponent = clone.GetDropObject().GetOrAddComponent<UT_SoftParent>();
			orAddComponent.Initialize(hit.transform);
			if (baseHitEffect.hitType == HitType.softParentRelativePositionNoRotation)
			{
				orAddComponent.parentOnlyOffsetInWorldSpace = true;
			}
			orAddComponent.disableOnNoParent = baseHitEffect.disableOnNoParent;
		}
	}

	internal virtual void CreateHitEffect(RaycastHit hit, HitEffect effect)
	{
		if (hasHitSurface)
		{
			return;
		}
		onHitEvent.Invoke();
		if (effect.hitSounds != null && effect.hitSounds.Count > 0)
		{
			AudioManager.PlaySound(effect.hitSounds[UnityEngine.Random.Range(0, effect.hitSounds.Count)], base.transform.position, effect.hitSoundVolume, 1f + UnityEngine.Random.Range(0f - effect.hitSoundPitchVariance, effect.hitSoundPitchVariance), effect.hitSoundSpatialBlend);
		}
		hasHitSurface = true;
		if (effect.hitEffect != null)
		{
			Quaternion rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(-hit.normal), hitFaceNormalBlend);
			if (flipHitEffect)
			{
				rotation *= Quaternion.Euler(0f, 180f, 0f);
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(effect.hitEffect, hit.point, rotation);
			gameObject.transform.parent = WorldLoader.GetCurrentLevelParentRoot();
			if (hit.transform != null)
			{
				if (effect.hitType == HitType.parent)
				{
					gameObject.transform.parent = hit.collider.transform;
				}
				else if (effect.hitType == HitType.locationParent || effect.hitType == HitType.softParentRelativePositionNoRotation)
				{
					UT_SoftParent uT_SoftParent = gameObject.AddComponent<UT_SoftParent>();
					uT_SoftParent.Initialize(hit.transform);
					if (effect.hitType == HitType.softParentRelativePositionNoRotation)
					{
						uT_SoftParent.parentOnlyOffsetInWorldSpace = true;
					}
					uT_SoftParent.disableOnNoParent = effect.disableOnNoParent;
				}
				else if (effect.hitType == HitType.parentHitItem)
				{
					ParentHitItem(hit, effect);
				}
				if (WorldLoader.initialized)
				{
					WorldLoader.GetCurrentLevelFromBounds().GetLevel().AddPlacedObject(gameObject);
				}
			}
		}
		if (!string.IsNullOrEmpty(effect.hitParticleID))
		{
			FXManager.PlayParticleWithRotation(effect.hitParticleID, hit.point, effect.hitParticleAmount, base.transform.rotation);
		}
		effect?.onHitEvent?.Invoke();
		if (hitSound != null && hitSound.Count > 0)
		{
			AudioManager.PlaySound(hitSound[UnityEngine.Random.Range(0, hitSound.Count)], base.transform.position);
		}
		if (broadcastHitToListeners)
		{
			AudioManager.PlayListenedSound(broadcastTag, base.transform.position, broadcastRadius);
		}
		CreateSurfaceDecal(hit, effect);
		if (destroyOnHit)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else if (softParentProjectileOnHit)
		{
			UT_SoftParent uT_SoftParent2 = base.gameObject.AddComponent<UT_SoftParent>();
			velocity = Vector3.zero;
			base.transform.position = hit.point;
			uT_SoftParent2.UseLateUpdate = true;
			uT_SoftParent2.Initialize(hit.collider.transform);
		}
		if (useTracer)
		{
			FXManager.PlayTracer(particleTracerInfo.tracerID, startPos, hit.point, velocity.magnitude, particleTracerInfo.hitID);
		}
	}

	protected void CreateSurfaceDecal(RaycastHit hit, HitEffect effect)
	{
		if (!(effect.decal != null))
		{
			return;
		}
		FXManager.DecalHandle handle = FXManager.DecalCreate(FXManager.DecalPriority.Low);
		FXManager.DecalSharedApply(handle, FXManager.DecalSharedData(effect.decal));
		Transform transform = ((hit.collider != null) ? hit.collider.transform : null);
		Matrix4x4 matrix4x = FXManager.DecalPointingFrom(handle, hit.point, hit.normal, base.transform.forward, transform);
		if (!effect.punchHole)
		{
			return;
		}
		Matrix4x4 inverse = matrix4x.inverse;
		if (transform != null)
		{
			inverse *= transform.worldToLocalMatrix;
		}
		Physics.queriesHitBackfaces = true;
		float num = 50f;
		if (Physics.Raycast(hit.point + velocity.normalized * 0.005f, velocity, out var hitInfo, num, hitMask))
		{
			num = hitInfo.distance;
			FXManager.DecalHandle handle2 = FXManager.DecalCreate(FXManager.DecalPriority.Low);
			FXManager.DecalSharedApply(handle2, FXManager.DecalSharedData(effect.decal));
			Matrix4x4 inverse2 = FXManager.DecalPointingFrom(handle2, hitInfo.point, hitInfo.normal, -base.transform.forward, hitInfo.collider.transform).inverse;
			if (hitInfo.transform != null)
			{
				inverse2 *= hitInfo.transform.worldToLocalMatrix;
			}
			FXManager.DecalRenderModeSet(handle2, FXManager.DecalRenderMode.Punchthrough, inverse2.MultiplyVector(-velocity), Color.grey, num);
			if (!string.IsNullOrEmpty(effect.punchHoleParticleID))
			{
				FXManager.PlayParticleWithRotation(effect.punchHoleParticleID, hitInfo.point, effect.punchHoleParticleAmount, base.transform.rotation);
			}
		}
		Physics.queriesHitBackfaces = false;
		FXManager.DecalRenderModeSet(handle, FXManager.DecalRenderMode.Punchthrough, inverse.MultiplyVector(velocity), Color.grey, num);
	}

	internal virtual bool RicochetCheck(RaycastHit hit)
	{
		if (!canRicochet)
		{
			return false;
		}
		if (hit.collider != null)
		{
			ObjectTagger component = hit.collider.GetComponent<ObjectTagger>();
			if (component != null)
			{
				foreach (HitEffect customHitEffect in customHitEffects)
				{
					if (component.HasTagInList(customHitEffect.tags.ToArray()) && !customHitEffect.allowRicochet)
					{
						return false;
					}
				}
			}
		}
		if (Vector3.Angle(velocity, -hit.normal) > bounceAngle)
		{
			velocity = Vector3.Reflect(velocity, -hit.normal) * 1f * bounceDampen;
			if (reflectSound != null && reflectSound.Count > 0)
			{
				AudioSource.PlayClipAtPoint(reflectSound[UnityEngine.Random.Range(0, reflectSound.Count)], hit.point, 1f);
			}
			bounces++;
			if (maxBounces != 0 && maxBounces <= bounces)
			{
				if (useHitEffects || destroyOnHit)
				{
					return false;
				}
				velocity = Vector3.zero;
				stopped = true;
			}
			OnRichochet();
			return true;
		}
		return false;
	}

	internal virtual void HitInteractions(ref RaycastHit hit, ref ObjectTagger tagger, ref bool hasHitThis, out bool hasKilled)
	{
		hasKilled = false;
		GameObject gameObject = hit.collider.gameObject;
		GameEntity gameEntity = null;
		ObjectTagger objectTagger = tagger;
		Transform item = hit.collider.transform;
		if (tagger.HasTag("Hitbox"))
		{
			gameEntity = hit.collider.GetComponent<Hitbox>().GetGameEntity();
			if (gameEntity != null)
			{
				tagger = gameEntity.GetTagger();
				item = gameEntity.transform;
			}
			gameObject = tagger.gameObject;
		}
		if (!hasHit.Contains(item))
		{
			Damageable component = hit.collider.GetComponent<Damageable>();
			if (!hasHit.Contains(item))
			{
				hasHit.Add(item);
			}
			if (tagger.HasTag("Entity") || tagger.HasTag("Prop"))
			{
				gameEntity = gameObject.GetComponent<GameEntity>();
				if (tagger.HasTag("Prop"))
				{
					gameEntity.AddForceAtPosition(velocity * hitForceMultiplier + velocity.normalized * hitForceBase, hit.point, hitForceTag);
					Debug.Log("Hit Prop: " + velocity);
				}
				else
				{
					gameEntity.AddForce(velocity * hitForceMultiplier + velocity.normalized * hitForceBase, hitForceTag);
				}
				if (!hasHit.Contains(item))
				{
					hasHit.Add(item);
				}
				if (tagger.HasTag("Player"))
				{
					ENT_Player component2 = gameObject.GetComponent<ENT_Player>();
					if (knockHold)
					{
						component2.DropHang(0.1f, 1f, cooldownOnlyOnHangingHands: false, "drop", canResist: true);
					}
					if (staminaDamage > 0f)
					{
						component2.DamageGripStrength(staminaDamage);
					}
				}
			}
			if (component != null)
			{
				Damageable.DamageInfo damageInfo = Damageable.DamageInfo.CreateDamageInfo(damage, damageType, damageTags, sourceEntity);
				damageInfo.position = hit.point;
				damageInfo.force = hitForceMultiplier * velocity + velocity.normalized * hitForceBase;
				damageInfo.direction = velocity.normalized;
				damageInfo.tags.Add("projectile");
				bool flag = gameEntity != null && gameEntity.dead;
				hasKilled = OnDamage(component, damageInfo);
				if (gameEntity != null)
				{
					_OnProjectileHitGameEntity?.Invoke(this, hit, gameEntity, damageInfo);
				}
				if (!objectTagger.HasTag("NoHitSound"))
				{
					if (!hasKilled && !flag)
					{
						if (objectTagger.HasTag("WeakSpot"))
						{
							if (hitWeakSpotSounds != null && hitWeakSpotSounds.Count > 0)
							{
								AudioManager.PlaySound(hitWeakSpotSounds[UnityEngine.Random.Range(0, hitWeakSpotSounds.Count)], base.transform.position, 1f, 1f, hitDamageSoundSpacial);
							}
						}
						else if (!hasKilled && hitDamageSounds != null && hitDamageSounds.Count > 0)
						{
							AudioManager.PlaySound(hitDamageSounds[UnityEngine.Random.Range(0, hitDamageSounds.Count)], base.transform.position, 1f, 1f + UnityEngine.Random.Range(-0.1f, 0.1f), hitDamageSoundSpacial);
						}
					}
					if (hasKilled && tagger.HasTag("Denizen") && hitKillSounds != null && hitKillSounds.Count > 0 && !flag)
					{
						AudioManager.PlaySound(hitKillSounds[UnityEngine.Random.Range(0, hitKillSounds.Count)], base.transform.position, 1f, 1f, hitDamageSoundSpacial);
					}
				}
				if (hasKilled && pierceOnKill && !hasHit.Contains(item))
				{
					hasHit.Add(item);
				}
			}
			else if (tagger.HasTag("Button"))
			{
				CL_Button component3 = gameObject.GetComponent<CL_Button>();
				Debug.Log("Has Hit Button");
				if (component3.projectilesCanPress)
				{
					component3.Interact();
				}
				if (!hasHit.Contains(item))
				{
					hasHit.Add(item);
				}
			}
			if (gameEntity != null && skewerOnKill && gameEntity != null && !skeweredEntities.Contains(gameEntity))
			{
				Debug.Log(gameEntity.name + " is skewerable: " + gameEntity.skewerable + " onlyOnKill: " + gameEntity.onlySkewerOnKill);
				if (gameEntity.skewerable && (!gameEntity.onlySkewerOnKill || (gameEntity.onlySkewerOnKill & hasKilled)))
				{
					Debug.Log("Skewering entity: " + gameEntity.name);
					Rigidbody component4 = gameObject.GetComponent<Rigidbody>();
					if (component4 != null)
					{
						component4.isKinematic = true;
					}
					skeweredEntities.Add(gameEntity);
				}
			}
		}
		else
		{
			hasHitThis = true;
		}
		_OnProjectileHit?.Invoke(this, hit, tagger);
	}

	internal virtual bool OnDamage(Damageable damageable, Damageable.DamageInfo damageInfo)
	{
		return damageable.Damage(damageInfo);
	}

	public virtual void OnRichochet()
	{
	}

	public override void DrawGizmos()
	{
		if (GizmoContext.InSelection(this))
		{
			Draw.SphereOutline(base.transform.position, hitRadius, new Color(1f, 0.561f, 0f, 0.25f));
		}
	}

	public void SetVelocityMultiplier(float f)
	{
		velMult = f;
	}

	public void AddIgnore(GameObject g)
	{
		ignoreObjects.Add(g);
	}

	public void SetLifetime(float f)
	{
		lifetime = f;
	}

	public void AddDamageTag(string s)
	{
		damageTags.Add(s);
	}

	public bool HasHitSurface()
	{
		return hasHitSurface;
	}

	public virtual void SetTarget(Transform t)
	{
	}
}
