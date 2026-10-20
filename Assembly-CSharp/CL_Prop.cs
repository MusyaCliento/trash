using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ObjectTagger))]
public class CL_Prop : GameEntity, Clickable, Flippable
{
	[Serializable]
	public class PropAudioEffect
	{
		public string name;

		public float minVelocity = 0.5f;

		public float maxVelocity = 1f;

		public float minPitch = 1f;

		public float maxPitch = 1f;

		public float maxVolume = 1f;

		public List<AudioClip> clip;
	}

	public bool canInteract = true;

	public float holdDistance = 2f;

	public float addForceMult = 1f;

	public float loadInTime;

	public Vector3 holdOffset = Vector3.zero;

	public float igniteOnHitMinimumDamage = 1f;

	public float igniteOnHitChance;

	public float damageMultWhenOnFire = 1f;

	public UnityEvent onGrabEvent;

	public UnityEvent onDropEvent;

	public GameEntity targetEntity;

	public bool hideOnKill = true;

	public float randomDelayToKill;

	public UnityEvent onDamage;

	public UnityEvent onKill;

	public float buoyancy = 1f;

	public Transform[] grabPoints;

	private List<Collider> colliders;

	private List<Collision> collisionsInfo = new List<Collision>();

	private bool colliding;

	private Rigidbody rigid;

	private float startDrag;

	[Range(0f, 2f)]
	public float volume = 0.5f;

	[Range(0f, 2f)]
	public float dragVolume = 0.5f;

	public List<PropAudioEffect> hitSounds;

	public List<PropAudioEffect> dragSounds;

	public List<PropAudioEffect> breakSounds;

	public List<PropAudioEffect> unstickSounds;

	public List<PropAudioEffect> damageSounds;

	private AudioSource hitAud;

	private AudioSource dragAud;

	private AudioSource thirdAud;

	public bool stuck;

	public float stuckStrength = 1f;

	public float stuckHealth;

	public Vector3 anchorPoint;

	public UnityEvent unstickEvent;

	public bool usePhysicsHitEffect;

	public float minPhysHitImpulse = 1f;

	public GameObject physHitEffect;

	public float minDamageHitImpulse = 999f;

	public float hitImpulseDamageMult;

	public bool hitImpulseDamageOnlyWhenHolding = true;

	private float timeSinceCollision;

	private Vector3 calculatedVelocity = Vector3.zero;

	private Vector3 lastPos;

	private float velMag;

	private bool initialized;

	private float breakStuckMagnitude;

	private Vector3 currentPosition;

	private Vector3 currentVelocity;

	private float velocityMagnitude;

	private bool isDragAudPlaying;

	public bool allowFlipping = true;

	private bool distanceLockWasKinematic;

	private bool distanceLock;

	private List<ENT_Player.Hand> handsHolding = new List<ENT_Player.Hand>();

	private float lastTimeInWater;

	private void Awake()
	{
		rigid = GetComponent<Rigidbody>();
	}

	public override void Start()
	{
		base.Start();
		currentPosition = base.transform.position;
		Initialize();
		startDrag = rigid.linearDamping;
	}

	public override void Update()
	{
		base.Update();
		if (dragAud != null)
		{
			isDragAudPlaying = dragAud.isPlaying;
		}
		if (IsInWater() && currentSwimZone != null)
		{
			rigid.linearDamping = Mathf.Lerp(rigid.linearDamping, currentSwimZone.drag, Time.deltaTime * 2f);
		}
		else
		{
			rigid.linearDamping = Mathf.Lerp(rigid.linearDamping, startDrag, Time.deltaTime * 2f);
		}
	}

	public override void OnEnable()
	{
		base.OnEnable();
		if (dragAud != null)
		{
			dragAud.volume = 0f;
			colliding = false;
		}
	}

	public override void TickUpdate()
	{
		base.TickUpdate();
		if (!(ENT_Player.GetPlayer() != null))
		{
			return;
		}
		float manhattanDistance = DarkMachineFunctions.GetManhattanDistance(ENT_Player.GetPlayer().transform.position, base.transform.position);
		if (manhattanDistance > 250f)
		{
			if (manhattanDistance > 5000f)
			{
				base.gameObject.SetActive(value: false);
			}
			if (!distanceLock)
			{
				distanceLockWasKinematic = rigid.isKinematic;
				rigid.isKinematic = true;
				distanceLock = true;
			}
		}
		else if (distanceLock)
		{
			rigid.isKinematic = distanceLockWasKinematic;
			distanceLock = false;
		}
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		currentPosition = base.transform.position;
		currentVelocity = rigid.linearVelocity;
		velocityMagnitude = currentVelocity.magnitude;
		calculatedVelocity = currentPosition - lastPos;
		velMag = calculatedVelocity.magnitude / Time.fixedDeltaTime;
		lastPos = currentPosition;
		if (loadInTime >= 0f)
		{
			loadInTime -= Time.fixedDeltaTime;
		}
		if (colliding && !stuck)
		{
			if (dragAud != null)
			{
				PropAudioEffect soundFromVelocity = GetSoundFromVelocity(dragSounds, velocityMagnitude);
				dragAud.volume = dragVolume * (soundFromVelocity.maxVolume * (velMag / soundFromVelocity.maxVelocity));
				dragAud.pitch = Mathf.Lerp(soundFromVelocity.minPitch, soundFromVelocity.maxPitch, velMag / soundFromVelocity.maxVelocity);
			}
		}
		else if (dragAud != null)
		{
			if (dragAud.volume > 0f && isDragAudPlaying && !stuck)
			{
				dragAud.volume = Mathf.Lerp(dragAud.volume, 0f, Time.fixedDeltaTime * 30f);
			}
			else if (isDragAudPlaying)
			{
				dragAud.Pause();
			}
		}
		if (stuck)
		{
			if (breakStuckMagnitude > stuckStrength)
			{
				Unstick();
			}
			else if ((bool)dragAud)
			{
				dragAud.volume = Mathf.Lerp(dragAud.volume, breakStuckMagnitude / stuckStrength * dragVolume * 0.25f, Time.fixedDeltaTime * 4f);
				dragAud.pitch = Mathf.Clamp(Mathf.Lerp(dragAud.pitch, breakStuckMagnitude / stuckStrength, Time.deltaTime * 3f), 0.8f, 1f);
				if (breakStuckMagnitude > 0.1f && !isDragAudPlaying)
				{
					dragAud.Play();
				}
			}
			breakStuckMagnitude = Mathf.Lerp(breakStuckMagnitude, 0f, Time.fixedDeltaTime * 10f);
		}
		if (!rigid.isKinematic && velocityMagnitude > 0f)
		{
			if (!isDragAudPlaying && dragAud != null)
			{
				dragAud.Play();
			}
		}
		else if (isDragAudPlaying && dragAud != null)
		{
			dragAud.Pause();
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (!(Time.timeSinceLevelLoad < 1f) && !(loadInTime >= 0f))
		{
			if (dragAud != null && !isDragAudPlaying)
			{
				dragAud.Play();
			}
			if (hitSounds.Count > 0)
			{
				PropAudioEffect soundFromVelocity = GetSoundFromVelocity(hitSounds, velocityMagnitude);
				hitAud.clip = soundFromVelocity.clip[UnityEngine.Random.Range(0, soundFromVelocity.clip.Count)];
				hitAud.volume = volume * (soundFromVelocity.maxVolume * (velMag / soundFromVelocity.maxVelocity));
				hitAud.Play();
			}
			float magnitude = other.relativeVelocity.magnitude;
			if (usePhysicsHitEffect && magnitude >= minPhysHitImpulse)
			{
				UnityEngine.Object.Instantiate(physHitEffect, other.GetContact(0).point, Quaternion.identity);
			}
			if ((!hitImpulseDamageOnlyWhenHolding || handsHolding.Count > 0) && hitImpulseDamageMult > 0f && magnitude >= minDamageHitImpulse)
			{
				Damage(new Damageable.DamageInfo
				{
					amount = (magnitude - minDamageHitImpulse) * hitImpulseDamageMult,
					type = "impact",
					tags = new List<string> { "impact" }
				});
				CL_CameraControl.ShakeAtPosition(base.transform.position, Mathf.Clamp01((magnitude - minDamageHitImpulse) * hitImpulseDamageMult * 0.1f), 0.2f);
				Debug.Log("Hit with impulse of magnitude: " + magnitude + " dealing damage of: " + (magnitude - minDamageHitImpulse) * hitImpulseDamageMult);
			}
		}
	}

	private void OnCollisionExit(Collision other)
	{
		colliding = false;
	}

	private void OnCollisionStay(Collision other)
	{
		if (!(Time.timeSinceLevelLoad < 1f) && !(loadInTime >= 0f))
		{
			if (dragAud != null && !isDragAudPlaying)
			{
				dragAud.Play();
			}
			colliding = true;
		}
	}

	private int GetSoundEffectLevel(List<PropAudioEffect> effects, float vel)
	{
		int result = 0;
		for (int i = 0; i < effects.Count; i++)
		{
			if (velocityMagnitude > effects[i].minVelocity)
			{
				result = i;
			}
		}
		return result;
	}

	private PropAudioEffect GetSoundFromVelocity(List<PropAudioEffect> effects, float vel)
	{
		int index = 0;
		for (int i = 0; i < effects.Count; i++)
		{
			if (velocityMagnitude > effects[i].minVelocity)
			{
				index = i;
			}
		}
		return effects[index];
	}

	public Rigidbody GetRigidbody()
	{
		return rigid;
	}

	public void Pickup()
	{
		Unstick();
		if (rigid != null)
		{
			rigid.collisionDetectionMode = CollisionDetectionMode.Continuous;
		}
	}

	public override void Kill(string type = "", Damageable.DamageInfo damageInfo = null)
	{
		if (targetEntity != null)
		{
			targetEntity.Kill(type, damageInfo);
		}
		else if (!dead)
		{
			if (randomDelayToKill > 0f && health > (0f - maxHealth) / 2f && !damageInfo.HasTag("SkipPropDelayedKill"))
			{
				StartCoroutine(DelayedKill());
			}
			else
			{
				FinishKill();
			}
		}
		IEnumerator DelayedKill()
		{
			yield return new WaitForSeconds(UnityEngine.Random.Range(0f, randomDelayToKill));
			FinishKill();
		}
		void FinishKill()
		{
			if (breakSounds.Count > 0)
			{
				PropAudioEffect propAudioEffect = breakSounds[0];
				AudioManager.PlaySound(propAudioEffect.clip[UnityEngine.Random.Range(0, propAudioEffect.clip.Count)], currentPosition, propAudioEffect.maxVolume);
			}
			base.Kill(type, damageInfo);
			onKill.Invoke();
			if (hideOnKill)
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}

	public void Unstick()
	{
		if (stuck)
		{
			unstickEvent.Invoke();
			rigid.isKinematic = false;
			stuck = false;
			if (unstickSounds.Count > 0)
			{
				thirdAud.clip = unstickSounds[0].clip[UnityEngine.Random.Range(0, unstickSounds[0].clip.Count)];
				thirdAud.volume = Mathf.Clamp(velocityMagnitude * 0.8f, 0.7f, 1f);
				thirdAud.Play();
			}
		}
	}

	public void Stick()
	{
		rigid.isKinematic = true;
		stuck = true;
	}

	public void Initialize()
	{
		if (!initialized)
		{
			colliders = new List<Collider>();
			colliders.AddRange(GetComponentsInChildren<Collider>());
			if (stuck)
			{
				rigid.isKinematic = true;
			}
			hitAud = GetComponent<AudioSource>();
			if (hitAud == null)
			{
				hitAud = base.gameObject.AddComponent<AudioSource>();
				hitAud.spatialBlend = 1f;
				hitAud.playOnAwake = false;
				hitAud.volume = volume;
				hitAud.outputAudioMixerGroup = AudioManager.instance.gameMixer;
			}
			if (dragSounds.Count > 0)
			{
				dragAud = base.gameObject.AddComponent<AudioSource>();
				dragAud.loop = true;
				dragAud.clip = dragSounds[0].clip[UnityEngine.Random.Range(0, dragSounds[0].clip.Count)];
				dragAud.spatialBlend = 1f;
				dragAud.playOnAwake = false;
				dragAud.volume = 0f;
				dragAud.outputAudioMixerGroup = AudioManager.instance.gameMixer;
			}
			if (unstickSounds.Count > 0)
			{
				thirdAud = base.gameObject.AddComponent<AudioSource>();
				thirdAud.clip = dragSounds[0].clip[UnityEngine.Random.Range(0, dragSounds[0].clip.Count)];
				thirdAud.spatialBlend = 1f;
				thirdAud.playOnAwake = false;
				thirdAud.outputAudioMixerGroup = AudioManager.instance.gameMixer;
			}
			lastPos = currentPosition;
			initialized = true;
		}
	}

	public override void SetDirectionalForce(Vector3 v)
	{
		AddForce(v);
	}

	public override void SetForce(Vector3 v)
	{
		rigid.linearVelocity = v;
	}

	public override void AddForce(Vector3 v, string source = "")
	{
		v *= 10f * addForceMult;
		rigid.AddForce(v);
	}

	public override void AddForceAtPosition(Vector3 v, Vector3 p, string source = "")
	{
		v *= 10f * addForceMult;
		rigid.AddForceAtPosition(v, p);
	}

	public override void TonguePull(Vector3 v)
	{
		base.TonguePull(v);
		AddForce(v * 1000f);
	}

	public override void AddForce(Vector3 v, float maxVel, string source = "", float maxVelScale = 0f)
	{
		rigid.AddForce(v * 5f, ForceMode.Acceleration);
	}

	public void AddBreakingVelocity(Vector3 v)
	{
		breakStuckMagnitude = v.magnitude;
	}

	public void Interact(Clickable.InteractionInfo info)
	{
		Debug.Log("We are being grabbed: " + info.hand.id);
		if (rigid.isKinematic && !stuck)
		{
			rigid.isKinematic = false;
		}
		rigid.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
		if (handsHolding.Count == 0)
		{
			onGrabEvent.Invoke();
		}
		if (!handsHolding.Contains(info.hand))
		{
			handsHolding.Add(info.hand);
		}
		if (grabPoints != null && grabPoints.Length != 0)
		{
			info.hand.SetWorldHoldPosition(grabPoints[0].position);
		}
	}

	public void StopInteract(ENT_Player p, ENT_Player.Hand hand, string s)
	{
		Debug.Log("We are being dropped: " + hand.id);
		if (handsHolding.Contains(hand))
		{
			handsHolding.Remove(hand);
		}
		if (handsHolding.Count == 0)
		{
			onDropEvent.Invoke();
		}
	}

	public void Drop()
	{
		Initialize();
		if (dragAud != null)
		{
			dragAud.volume = 0f;
			dragAud.Play();
			dragAud.Pause();
		}
		rigid.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
	}

	public override bool Damage(Damageable.DamageInfo info)
	{
		if (!damageable)
		{
			return false;
		}
		if (targetEntity != null)
		{
			return targetEntity.Damage(info);
		}
		PropAudioEffect propAudioEffect = null;
		propAudioEffect = ((damageSounds == null || damageSounds.Count <= 0) ? GetSoundFromVelocity(hitSounds, info.amount) : GetSoundFromVelocity(damageSounds, info.amount));
		hitAud.clip = propAudioEffect.clip[UnityEngine.Random.Range(0, propAudioEffect.clip.Count)];
		hitAud.volume = volume * propAudioEffect.maxVolume;
		hitAud.Play();
		onDamage.Invoke();
		if (HasEffect("fire") && !info.HasTag("fire"))
		{
			info.amount *= damageMultWhenOnFire;
		}
		if (igniteOnHitChance > 0f && UnityEngine.Random.value < igniteOnHitChance * info.amount && !HasEffect("fire") && health - info.amount <= maxHealth - igniteOnHitMinimumDamage)
		{
			AddEffect("fire", 5f);
		}
		if (info.type == "drone")
		{
			info.amount *= 0.25f;
		}
		if (stuckHealth > 0f)
		{
			stuckHealth -= info.amount;
			if (stuckHealth <= 0f)
			{
				Unstick();
			}
		}
		if (maxHealth > 0f)
		{
			return base.Damage(info);
		}
		return false;
	}

	public bool CanInteract(Interaction info)
	{
		return canInteract;
	}

	public List<Collider> GetColliders()
	{
		return colliders;
	}

	internal override void WaterUpdate()
	{
		base.WaterUpdate();
		if (!(currentSwimZone == null))
		{
			float num = Mathf.Clamp01(currentSwimZone.GetDepth(base.transform.position) * 1f);
			rigid.AddForce(Vector3.up * buoyancy * Time.deltaTime * 1000f * num, ForceMode.Acceleration);
		}
	}

	internal override void EnterSwimZone(UT_SwimZone zone)
	{
		base.EnterSwimZone(zone);
		if (!rigid.isKinematic)
		{
			rigid.linearDamping = zone.drag;
			if (lastTimeInWater + 0.5f < Time.time)
			{
				zone.Splash(base.transform.position);
			}
		}
	}

	internal override void ExitSwimZone(UT_SwimZone zone)
	{
		if (!rigid.isKinematic)
		{
			lastTimeInWater = Time.time;
			base.ExitSwimZone(zone);
			if (enterWaterTime + 0.5f < Time.time && zone != null)
			{
				zone.Splash(base.transform.position);
			}
		}
	}

	public void OnFlip(bool flipped)
	{
		if (!allowFlipping && flipped)
		{
			base.transform.localScale = new Vector3(0f - base.transform.localScale.x, base.transform.localScale.y, base.transform.localScale.z);
		}
	}
}
