using UnityEngine;
using UnityEngine.Events;

public class DEN_Drone : Denizen
{
	public enum AIStates
	{
		searching = 0,
		wandering = 1,
		hunting = 2,
		charging = 3
	}

	public enum MovementState
	{
		flying = 0,
		charging = 1
	}

	public class Target
	{
		public Transform transform;

		public ObjectTagger tagger;

		public GameEntity entity;

		public Vector3 lastSighted;

		public bool isVisible;

		public float lastSightedTimer;

		public void Clear()
		{
			transform = null;
			tagger = null;
			entity = null;
			isVisible = false;
		}
	}

	[Header("Drone")]
	public LayerMask flyMask;

	public float flySpeed = 1f;

	public float flySpeedClamp = 1f;

	public float crawlSpeed = 1f;

	public float hoverDistance = 1f;

	public float rotationSpeed = 2f;

	public float maxBankAngle = 45f;

	public float hoverTimeMin = 1f;

	public float hoverTimeMax = 2f;

	private float hoverTime;

	public float chargeHitForce = 2f;

	[Header("AI")]
	public AIStates aiState = AIStates.wandering;

	public MovementState moveState;

	public float loseTargetTimer = 5f;

	public bool willCharge = true;

	public float chargeDistance;

	private float chargeTime;

	public float chargeWindup = 3f;

	public float chargeCooldown = 10f;

	private float chargeCooldownTime;

	private float restTimer;

	private bool foundRestSpot;

	private bool hasCharged;

	public AudioSource flyAudio;

	private float flyAudioTarget;

	private Collision collision;

	public bool alwaysTargetPlayer;

	private Target droneTarget;

	private Vector3 targetMoveVector;

	public string[] targetTags;

	public bool lookForTarget = true;

	private RaycastHit searchRaycast;

	private bool grounded;

	private Vector3 wallNormal;

	private Vector3 facingDir;

	[Header("Physics")]
	public float pGain = 1f;

	public float iGain = 0.1f;

	public float dGain = 0.5f;

	private Rigidbody rigid;

	private Vector3 positionErrorSum = Vector3.zero;

	private Vector3 lastPositionError = Vector3.zero;

	public float noiseIntensity = 0.5f;

	public float noiseFrequency = 1f;

	private float noiseOffsetX;

	private float noiseOffsetY;

	private float noiseOffsetZ;

	private Vector3 landDir;

	public UnityEvent deathEvent;

	public override void Start()
	{
		base.Start();
		droneTarget = new Target();
		rigid = GetComponent<Rigidbody>();
		targetPosition = FindWanderSpot();
		rigid.AddForce(base.transform.forward);
		noiseOffsetX = Random.Range(0f, 100f);
		noiseOffsetY = Random.Range(0f, 100f);
		noiseOffsetZ = Random.Range(0f, 100f);
		clipHandler = GetComponent<UT_AudioClipHandler>();
		restTimer = Random.Range(5, 15);
		flyAudioTarget = flyAudio.volume;
		if (alwaysTargetPlayer)
		{
			droneTarget.transform = CL_GameManager.gMan.localPlayer.transform;
			droneTarget.tagger = CL_GameManager.gMan.localPlayer.GetTagger();
			droneTarget.entity = CL_GameManager.gMan.localPlayer;
			droneTarget.isVisible = true;
		}
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		if (alwaysTargetPlayer && droneTarget.transform == null)
		{
			droneTarget.transform = CL_GameManager.gMan.localPlayer.transform;
			droneTarget.tagger = CL_GameManager.gMan.localPlayer.GetTagger();
			droneTarget.entity = CL_GameManager.gMan.localPlayer;
			droneTarget.isVisible = true;
			droneTarget.lastSightedTimer = 1000f;
		}
		if (dead)
		{
			if (flyAudio.volume > 0.1f && flyAudio.isPlaying)
			{
				flyAudio.volume = Mathf.Lerp(flyAudio.volume, 0f, Time.fixedDeltaTime * 5f);
			}
			else if (flyAudio.isPlaying)
			{
				flyAudio.Stop();
			}
		}
		else
		{
			AI();
			Movement();
		}
	}

	public override void Update()
	{
		if (CL_UIManager.debug)
		{
			CL_DebugView.draw.Cross(targetPosition, 0.5f, Color.green);
		}
	}

	private void AI()
	{
		float num = 0f;
		if (chargeCooldownTime > 0f)
		{
			chargeCooldownTime -= Time.fixedDeltaTime;
		}
		if (droneTarget.transform == null)
		{
			aiState = AIStates.wandering;
		}
		else
		{
			num = Vector3.Distance(base.transform.position, droneTarget.transform.position);
			if (!droneTarget.isVisible)
			{
				droneTarget.lastSightedTimer -= Time.fixedDeltaTime;
			}
			else
			{
				droneTarget.lastSightedTimer = loseTargetTimer;
			}
			if (droneTarget.lastSightedTimer <= 0f)
			{
				droneTarget.Clear();
				aiState = AIStates.wandering;
			}
		}
		switch (aiState)
		{
		case AIStates.wandering:
			moveState = MovementState.flying;
			if (Vector3.Distance(base.transform.position, targetPosition) < 1f)
			{
				if (hoverTime <= 0f)
				{
					targetPosition = FindWanderSpot();
					hoverTime = Random.Range(hoverTimeMin, hoverTimeMax);
				}
				else
				{
					hoverTime -= Time.deltaTime;
				}
			}
			if (alwaysTargetPlayer)
			{
				aiState = AIStates.hunting;
			}
			break;
		case AIStates.hunting:
			moveState = MovementState.flying;
			if (droneTarget.isVisible)
			{
				targetPosition = droneTarget.transform.position + Vector3.up * 0.5f - (droneTarget.transform.position + Vector3.up * 0.5f - base.transform.position).normalized * hoverDistance;
				if (num < chargeDistance && chargeCooldownTime <= 0f && willCharge)
				{
					aiState = AIStates.charging;
					clipHandler.PlaySound("drone:chargewindup");
				}
			}
			else
			{
				targetPosition = droneTarget.lastSighted;
			}
			break;
		case AIStates.charging:
			targetPosition = droneTarget.transform.position + Vector3.up * 0.5f - (droneTarget.transform.position + Vector3.up * 0.5f - base.transform.position).normalized * 1f;
			chargeTime += Time.fixedDeltaTime;
			if (chargeTime > chargeWindup)
			{
				moveState = MovementState.charging;
				rigid.AddForce((droneTarget.transform.position - base.transform.position).normalized * 100f);
				if (!hasCharged)
				{
					hasCharged = true;
					clipHandler.PlaySound("drone:charge");
				}
				if (chargeTime > chargeWindup + 1f)
				{
					moveState = MovementState.flying;
					aiState = AIStates.hunting;
					chargeCooldownTime = chargeCooldown;
					chargeTime = 0f;
					hasCharged = false;
				}
			}
			break;
		}
		if (!IsTickFrame())
		{
			return;
		}
		if (WorldLoader.initialized)
		{
			base.transform.parent = WorldLoader.GetClosestLevelToPosition(base.transform.position).GetLevel().GetParentRoot();
		}
		if (lookForTarget)
		{
			if (alwaysTargetPlayer)
			{
				droneTarget.isVisible = true;
				droneTarget.lastSighted = droneTarget.transform.position;
				return;
			}
			if (Physics.Raycast(base.transform.position, -Vector3.up, out var _, 3f, flyMask))
			{
				rigid.AddForce(Vector3.up * 50f);
			}
			if (droneTarget.transform == null)
			{
				FindTarget();
			}
			else if (sight.CanSeeTarget(base.transform.position, droneTarget.transform, sight.sightDistance) && !CL_GameManager.noTarget)
			{
				droneTarget.isVisible = true;
				droneTarget.lastSighted = droneTarget.transform.position;
			}
			else
			{
				droneTarget.isVisible = false;
			}
		}
		else
		{
			droneTarget.isVisible = false;
		}
	}

	private void Movement()
	{
		switch (moveState)
		{
		case MovementState.flying:
			Fly();
			break;
		case MovementState.charging:
			Charge();
			break;
		}
		rigid.AddForce(targetMoveVector);
		ApplyBankingRotation();
	}

	private void Fly()
	{
		rigid.useGravity = true;
		rigid.isKinematic = false;
		flyAudio.volume = Mathf.Lerp(flyAudio.volume, flyAudioTarget, Time.fixedDeltaTime * 3f);
		if (moveState != MovementState.charging)
		{
			moveState = MovementState.flying;
		}
		_ = aiState;
		_ = 1;
		Vector3 vector = new Vector3(Mathf.PerlinNoise(Time.time * noiseFrequency + noiseOffsetX, 0f) - 0.5f, Mathf.PerlinNoise(Time.time * noiseFrequency + noiseOffsetY, 0f) - 0.5f, Mathf.PerlinNoise(Time.time * noiseFrequency + noiseOffsetZ, 0f) - 0.5f);
		vector *= noiseIntensity;
		Vector3 vector2 = targetPosition - base.transform.position;
		Vector3 vector3 = vector2;
		positionErrorSum = Vector3.ClampMagnitude(positionErrorSum, 1f);
		positionErrorSum += vector2 * Time.fixedDeltaTime;
		if (CL_UIManager.debug)
		{
			CL_DebugView.draw.Arrow(base.transform.position, base.transform.position + positionErrorSum, Color.green);
			CL_DebugView.draw.Arrow(base.transform.position, base.transform.position + rigid.linearVelocity, Color.blue);
			CL_DebugView.draw.Arrow(base.transform.position, base.transform.position + vector2, Color.red);
		}
		Vector3 vector4 = positionErrorSum;
		Vector3 vector5 = (vector2 - lastPositionError) / Time.fixedDeltaTime;
		Vector3 vector6 = pGain * vector3 + iGain * vector4 + dGain * vector5;
		vector6 = Vector3.ClampMagnitude(vector6 * flySpeed, flySpeedClamp);
		rigid.AddForce(vector6 + vector);
		if (!droneTarget.isVisible)
		{
			lookVector = Vector3.Scale((rigid.linearVelocity.normalized + vector2.normalized).normalized, new Vector3(1f, 0.2f, 1f));
		}
		else if (aiState == AIStates.charging)
		{
			lookVector = droneTarget.transform.position - base.transform.position;
		}
		else
		{
			lookVector = Vector3.Lerp(droneTarget.transform.position, targetPosition, 0.5f) - base.transform.position;
		}
		lastPositionError = vector2;
	}

	private void Charge()
	{
		Fly();
	}

	private void ApplyBankingRotation()
	{
		if (lookVector.magnitude < 0.01f)
		{
			lookVector = targetPosition - base.transform.position;
		}
		Vector3 normalized = lookVector.normalized;
		normalized.y *= 0.3f;
		float num = Mathf.Clamp(Vector3.SignedAngle(base.transform.forward, normalized, Vector3.up), 0f - maxBankAngle, maxBankAngle);
		Quaternion quaternion2 = Quaternion.Euler(0f, 0f, 0f - num);
		Quaternion b = Quaternion.LookRotation(normalized, Vector3.up) * quaternion2;
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * rotationSpeed);
	}

	private Vector3 FindWanderSpot()
	{
		Vector3 vector = Random.onUnitSphere * Random.Range(1f, 10f);
		if (Physics.Raycast(base.transform.position, vector, out var hitInfo, vector.magnitude, flyMask))
		{
			Vector3 vector2 = hitInfo.point + hitInfo.normal * 2f;
			if (Physics.Linecast(base.transform.position, vector2, flyMask))
			{
				vector2 = base.transform.position + vector.normalized * hitInfo.distance * 0.2f;
			}
			return vector2;
		}
		return base.transform.position + vector;
	}

	private void FindTarget()
	{
		if (CL_GameManager.noTarget)
		{
			return;
		}
		Collider[] array = Physics.OverlapSphere(base.transform.position, sight.sightDistance, sight.sightMask);
		foreach (Collider collider in array)
		{
			if (ObjectTagger.TagCheck(collider.gameObject, targetTags, out var objectTagger) && sight.CanSeeTarget(base.transform.position, collider.transform, sight.sightDistance))
			{
				droneTarget.transform = collider.transform;
				droneTarget.tagger = objectTagger;
				droneTarget.entity = collider.GetComponent<GameEntity>();
				droneTarget.isVisible = true;
				aiState = AIStates.hunting;
				break;
			}
		}
	}

	private void OnCollisionStay(Collision other)
	{
		collision = other;
	}

	internal override void OnCollisionEnter(Collision other)
	{
		if (moveState == MovementState.charging)
		{
			ObjectTagger component = other.gameObject.GetComponent<ObjectTagger>();
			if (component != null && component.HasTag("Entity"))
			{
				GameEntity component2 = other.gameObject.GetComponent<GameEntity>();
				float num = 1f;
				float amount = 1f;
				if (CL_GameManager.IsHardmode())
				{
					num = 1.7f;
					amount = 2f;
				}
				component2.AddForce((Vector3.Scale((other.transform.position - base.transform.position).normalized, new Vector3(1f, 0f, 1f)) + Vector3.up * 0.5f).normalized * chargeHitForce * num, "denizen");
				component2.Damage(Damageable.DamageInfo.CreateDamageInfo(amount, objectType));
				if (component.HasTag("Player"))
				{
					component2.GetComponent<ENT_Player>().DropHang(0.1f, 1f, cooldownOnlyOnHangingHands: false, "drop", canResist: true);
				}
			}
			moveState = MovementState.flying;
			aiState = AIStates.hunting;
			if (CL_GameManager.IsHardmode())
			{
				chargeCooldownTime = chargeCooldown * 0.75f;
			}
			else
			{
				chargeCooldownTime = chargeCooldown;
			}
			chargeTime = 0f;
			hasCharged = false;
		}
		else if (moveState == MovementState.flying && aiState == AIStates.wandering && rigid != null && collision != null)
		{
			rigid.AddForce(collision.impulse.normalized * 5f);
			targetPosition = collision.contacts[0].point + collision.contacts[0].normal;
		}
		if (dead)
		{
			grounded = true;
		}
	}

	private void OnCollisionExit(Collision other)
	{
		if (dead)
		{
			grounded = false;
		}
	}

	public override void AddForce(Vector3 v, string source = "")
	{
		rigid.AddForce(v * 10f);
		base.AddForce(v);
	}

	public override bool Damage(Damageable.DamageInfo info)
	{
		if (!dead)
		{
			clipHandler.PlaySound("drone:hurt");
		}
		return base.Damage(info);
	}

	public override void Kill(string type = "", Damageable.DamageInfo damageInfo = null)
	{
		if (!dead)
		{
			deathEvent.Invoke();
			rigid.freezeRotation = false;
			rigid.AddTorque(Random.onUnitSphere * 10f);
			clipHandler.PlaySound("drone:die");
			base.gameObject.layer = LayerMask.NameToLayer("CreaturePassthrough");
			dead = true;
			if ((bool)destroyObject)
			{
				Object.Instantiate(destroyObject, base.transform.position, base.transform.rotation, base.transform.parent);
			}
			health = 0f;
			CL_GameTracker.AddEventToSession(CL_GameTracker.CreateEvent(base.name, base.gameObject.GetInstanceID().ToString(), objectType, CL_GameTracker.Session.Tick.Event.EventType.kill, base.transform.position));
			base.Kill(type, damageInfo);
		}
	}

	public Target GetTarget()
	{
		return droneTarget;
	}
}
