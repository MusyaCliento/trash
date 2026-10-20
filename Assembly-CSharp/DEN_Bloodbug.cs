using UnityEngine;

public class DEN_Bloodbug : Denizen
{
	public enum AIStates
	{
		searching = 0,
		wandering = 1,
		resting = 2,
		hunting = 3,
		charging = 4
	}

	public enum MovementState
	{
		flying = 0,
		landed = 1,
		charging = 2
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

	[Header("Bloodbug")]
	public LayerMask flyMask;

	public float flySpeed = 1f;

	public float flySpeedClamp = 1f;

	public float crawlSpeed = 1f;

	public float rotationSpeed = 2f;

	public float maxBankAngle = 45f;

	public float hoverTimeMin = 1f;

	public float hoverTimeMax = 2f;

	private float hoverTime;

	public float chargeHitForce = 2f;

	[Header("AI")]
	public AIStates aiState = AIStates.wandering;

	public MovementState moveState;

	public float sightDistance;

	public float chargeDistance;

	public float loseTargetTimer = 5f;

	private float chargeTime;

	public float chargeWindup = 3f;

	public float chargeCooldown = 10f;

	private float chargeCooldownTime;

	private float restTimer;

	private bool foundRestSpot;

	private bool hasCharged;

	private AudioSource flyAudio;

	private float flyAudioTarget;

	private Collision collision;

	public bool alwaysTargetPlayer;

	private Vector3 home;

	private Target bloodbugTarget;

	private Vector3 targetMoveVector;

	public string[] targetTags;

	private new Vector3 lookVector;

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

	[Header("Visuals")]
	public Animator animator;

	public override void Start()
	{
		base.Start();
		bloodbugTarget = new Target();
		rigid = GetComponent<Rigidbody>();
		SetTargetPosition(base.transform.position);
		bloodbugTarget.lastSighted = base.transform.position;
		rigid.AddForce(base.transform.forward);
		noiseOffsetX = Random.Range(0f, 100f);
		noiseOffsetY = Random.Range(0f, 100f);
		noiseOffsetZ = Random.Range(0f, 100f);
		clipHandler = GetComponent<UT_AudioClipHandler>();
		restTimer = Random.Range(5, 15);
		flyAudio = GetComponent<AudioSource>();
		flyAudioTarget = flyAudio.volume;
		if (alwaysTargetPlayer)
		{
			bloodbugTarget.transform = CL_GameManager.gMan.localPlayer.transform;
			bloodbugTarget.tagger = CL_GameManager.gMan.localPlayer.GetTagger();
			bloodbugTarget.entity = CL_GameManager.gMan.localPlayer;
			bloodbugTarget.isVisible = true;
		}
		home = base.transform.position;
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		if (alwaysTargetPlayer && bloodbugTarget.transform == null)
		{
			bloodbugTarget.transform = CL_GameManager.gMan.localPlayer.transform;
			bloodbugTarget.tagger = CL_GameManager.gMan.localPlayer.GetTagger();
			bloodbugTarget.entity = CL_GameManager.gMan.localPlayer;
			bloodbugTarget.isVisible = true;
			bloodbugTarget.lastSightedTimer = 1000f;
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
			if (rigid.linearVelocity.magnitude > 1f)
			{
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(rigid.linearVelocity.normalized, base.transform.forward), Time.fixedDeltaTime * 10f);
			}
			else
			{
				base.transform.rotation = Quaternion.LookRotation(Vector3.forward);
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
		base.Update();
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
		if (bloodbugTarget.transform == null)
		{
			if (aiState != AIStates.resting)
			{
				aiState = AIStates.wandering;
			}
		}
		else
		{
			num = Vector3.Distance(base.transform.position, bloodbugTarget.transform.position);
			if (!bloodbugTarget.isVisible)
			{
				bloodbugTarget.lastSightedTimer -= Time.fixedDeltaTime;
			}
			else
			{
				bloodbugTarget.lastSightedTimer = loseTargetTimer;
			}
			if (bloodbugTarget.lastSightedTimer <= 0f)
			{
				bloodbugTarget.Clear();
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
			restTimer -= Time.fixedDeltaTime;
			if (restTimer <= 0f)
			{
				aiState = AIStates.resting;
				restTimer = Random.Range(10, 30);
				foundRestSpot = false;
			}
			if (alwaysTargetPlayer)
			{
				aiState = AIStates.hunting;
			}
			break;
		case AIStates.resting:
			if (!foundRestSpot)
			{
				targetPosition = FindRestSpot();
			}
			if (foundRestSpot)
			{
				restTimer -= Time.fixedDeltaTime;
				if (restTimer <= 0f)
				{
					moveState = MovementState.flying;
					aiState = AIStates.wandering;
					targetPosition = FindWanderSpot();
					restTimer = Random.Range(2, 10);
				}
			}
			break;
		case AIStates.hunting:
			moveState = MovementState.flying;
			if (bloodbugTarget.isVisible)
			{
				targetPosition = bloodbugTarget.transform.position + Vector3.up * 0.5f - (bloodbugTarget.transform.position + Vector3.up * 0.5f - base.transform.position).normalized * 1f;
				if (num < chargeDistance && chargeCooldownTime <= 0f)
				{
					aiState = AIStates.charging;
					animator.SetBool("charging", value: true);
					clipHandler.PlaySound("bloodbug:chargewindup");
				}
			}
			else
			{
				targetPosition = bloodbugTarget.lastSighted;
			}
			break;
		case AIStates.charging:
			targetPosition = bloodbugTarget.transform.position + Vector3.up * 0.5f - (bloodbugTarget.transform.position + Vector3.up * 0.5f - base.transform.position).normalized * 1f;
			chargeTime += Time.fixedDeltaTime;
			if (chargeTime > chargeWindup)
			{
				moveState = MovementState.charging;
				rigid.AddForce((bloodbugTarget.transform.position - base.transform.position).normalized * 50f);
				if (!hasCharged)
				{
					hasCharged = true;
					clipHandler.PlaySound("bloodbug:charge");
				}
				if (chargeTime > chargeWindup + 1f || (chargeTime > chargeWindup / 2f && rigid.linearVelocity.magnitude < 0.03f))
				{
					moveState = MovementState.flying;
					aiState = AIStates.hunting;
					chargeCooldownTime = chargeCooldown;
					chargeTime = 0f;
					hasCharged = false;
					animator.SetBool("charging", value: false);
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
		if (alwaysTargetPlayer)
		{
			bloodbugTarget.isVisible = true;
			bloodbugTarget.lastSighted = bloodbugTarget.transform.position;
			return;
		}
		if (Physics.Raycast(base.transform.position, -Vector3.up, out var _, 3f, flyMask))
		{
			rigid.AddForce(Vector3.up * 50f);
		}
		if (bloodbugTarget.transform == null)
		{
			FindTarget();
		}
		else if (CanSeeTarget(bloodbugTarget.transform, sightDistance) && !CL_GameManager.noTarget)
		{
			bloodbugTarget.isVisible = true;
			bloodbugTarget.lastSighted = bloodbugTarget.transform.position;
		}
		else
		{
			bloodbugTarget.isVisible = false;
		}
	}

	private void Movement()
	{
		switch (moveState)
		{
		case MovementState.flying:
			Fly();
			break;
		case MovementState.landed:
			Crawl();
			break;
		case MovementState.charging:
			Charge();
			break;
		}
		rigid.AddForce(targetMoveVector);
		ApplyBankingRotation();
	}

	private void Crawl()
	{
		if (!grounded)
		{
			Fly();
			return;
		}
		flyAudio.volume = Mathf.Lerp(flyAudio.volume, 0f, Time.fixedDeltaTime * 3f);
		moveState = MovementState.landed;
		animator.SetBool("grounded", value: true);
		if (!rigid.isKinematic)
		{
			rigid.linearVelocity = targetPosition - base.transform.position;
		}
		if (rigid.isKinematic)
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(facingDir, wallNormal), Time.fixedDeltaTime * 5f);
		}
		if (collision != null && collision.contactCount > 0)
		{
			rigid.useGravity = false;
			if (!rigid.isKinematic)
			{
				rigid.linearVelocity = Vector3.zero;
			}
			wallNormal = (targetPosition - base.transform.position).normalized;
			if (Physics.Raycast(base.transform.position, targetPosition - base.transform.position, out var hitInfo, 5f, flyMask))
			{
				wallNormal = hitInfo.normal;
			}
			float num = Vector3.Dot(landDir, wallNormal);
			if ((double)num < -0.8 || num > 0.1f)
			{
				landDir = Vector3.ProjectOnPlane(Random.onUnitSphere, wallNormal).normalized;
			}
			if (rigid.linearVelocity.magnitude > 0.1f)
			{
				facingDir = Vector3.ProjectOnPlane(landDir, wallNormal).normalized;
			}
			else
			{
				facingDir = Vector3.ProjectOnPlane(landDir, wallNormal).normalized;
				rigid.isKinematic = true;
			}
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Arrow(base.transform.position, base.transform.position + facingDir, wallNormal, 0.5f, Color.yellow);
				CL_DebugView.draw.Arrow(base.transform.position, base.transform.position + wallNormal, wallNormal, 0.5f, Color.red);
			}
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(facingDir, wallNormal), Time.fixedDeltaTime * 5f);
		}
	}

	private void Fly()
	{
		rigid.useGravity = true;
		rigid.isKinematic = false;
		animator.SetBool("grounded", value: false);
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
		positionErrorSum = Vector3.ClampMagnitude(positionErrorSum, 2f);
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
		if (!bloodbugTarget.isVisible)
		{
			lookVector = Vector3.Scale((rigid.linearVelocity.normalized + vector2.normalized).normalized, new Vector3(1f, 0.2f, 1f));
		}
		else if (aiState == AIStates.charging)
		{
			lookVector = bloodbugTarget.transform.position - base.transform.position;
		}
		else
		{
			lookVector = targetPosition - base.transform.position;
		}
		lastPositionError = vector2;
	}

	private void Charge()
	{
		Fly();
	}

	private void ApplyBankingRotation()
	{
		Vector3 normalized = lookVector.normalized;
		normalized.y = 0f;
		float num = Mathf.Clamp(Vector3.SignedAngle(base.transform.forward, normalized, Vector3.up), 0f - maxBankAngle, maxBankAngle);
		Quaternion quaternion2 = Quaternion.Euler(0f, 0f, 0f - num);
		Quaternion b = Quaternion.LookRotation(normalized) * quaternion2;
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * rotationSpeed);
	}

	private Vector3 FindRestSpot()
	{
		Vector3 onUnitSphere = Random.onUnitSphere;
		if (Physics.Raycast(base.transform.position, onUnitSphere, out var hitInfo, 10f, flyMask))
		{
			Vector3 point = hitInfo.point;
			foundRestSpot = true;
			return point;
		}
		moveState = MovementState.flying;
		foundRestSpot = false;
		return FindWanderSpot();
	}

	private Vector3 FindWanderSpot()
	{
		Vector3 vector = Random.onUnitSphere * Random.Range(1f, 10f);
		if (Vector3.Distance(home, base.transform.position + vector) > 15f)
		{
			vector = Vector3.Lerp(vector, home - base.transform.position, 0.3f);
		}
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
		Collider[] array = Physics.OverlapSphere(base.transform.position, sightDistance, sight.sightMask);
		foreach (Collider collider in array)
		{
			if (ObjectTagger.TagCheck(collider.gameObject, targetTags, out var objectTagger) && CanSeeTarget(collider.transform, sightDistance))
			{
				bloodbugTarget.transform = collider.transform;
				bloodbugTarget.tagger = objectTagger;
				bloodbugTarget.entity = collider.GetComponent<GameEntity>();
				bloodbugTarget.isVisible = true;
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
			}
			animator.SetTrigger("chargehit");
			animator.SetBool("charging", value: false);
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
		else if (aiState == AIStates.resting)
		{
			moveState = MovementState.landed;
			grounded = true;
			landDir = base.transform.forward;
			animator.SetBool("grounded", value: true);
			collision = other;
		}
		if (dead)
		{
			grounded = true;
			animator.SetBool("grounded", value: true);
		}
	}

	private void OnCollisionExit(Collision other)
	{
		if (dead)
		{
			grounded = false;
			animator.SetBool("grounded", value: false);
		}
	}

	public override void AddForce(Vector3 v, string source = "")
	{
		rigid.AddForce(v);
		base.AddForce(v);
	}

	public override bool Damage(Damageable.DamageInfo info)
	{
		if (!damageable)
		{
			return false;
		}
		if (!dead)
		{
			clipHandler.PlaySound("bloodbug:hurt");
			animator.SetTrigger("hurt");
		}
		return base.Damage(info);
	}

	public override void Kill(string type = "", Damageable.DamageInfo damageInfo = null)
	{
		if (!dead)
		{
			clipHandler.PlaySound("bloodbug:die");
			animator.SetBool("dead", value: true);
			animator.SetLayerWeight(1, 1f);
			base.gameObject.layer = LayerMask.NameToLayer("CreaturePassthrough");
			dead = true;
			if ((bool)destroyObject)
			{
				Object.Instantiate(destroyObject, base.transform.position, base.transform.rotation, base.transform.parent);
			}
			health = 0f;
			GetComponent<CapsuleCollider>().radius = 0.1f;
			CL_GameTracker.AddEventToSession(CL_GameTracker.CreateEvent(base.name, base.gameObject.GetInstanceID().ToString(), objectType, CL_GameTracker.Session.Tick.Event.EventType.kill, base.transform.position));
			if (type == "gib" && gibAsset != null)
			{
				Object.Instantiate(gibAsset, base.transform.position, base.transform.rotation, base.transform.parent);
				Object.Destroy(base.gameObject);
			}
		}
	}

	public override void OffsetEntity(float amount)
	{
		base.OffsetEntity(amount);
		home += Vector3.up * amount;
	}

	internal override void WaterUpdate()
	{
		base.WaterUpdate();
		rigid.AddForce(Vector3.up * Time.deltaTime * 1000f, ForceMode.Acceleration);
	}
}
