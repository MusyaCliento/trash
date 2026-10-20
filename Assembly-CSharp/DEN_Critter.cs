using UnityEngine;

public class DEN_Critter : Denizen
{
	public enum CritterState
	{
		idle = 0,
		hungry = 1,
		wandering = 2
	}

	public LayerMask worldMask;

	public LayerMask playerMask;

	public float floorOffset = 0.01f;

	private RaycastHit hit;

	private Vector3 velocity;

	private Vector3 targetVelocity;

	private float wanderTime;

	public float speed = 0.5f;

	private bool onFloor;

	public GameObject deathEffect;

	private bool sightedPlayer;

	private float hissTimer = 1f;

	public CritterState state;

	public bool canClimb = true;

	public bool flock = true;

	public bool fearPlayer = true;

	public float fearDistance = 4f;

	public float runSpeed = 2f;

	public override void Start()
	{
		velocity = Vector3.zero;
		targetVelocity = Vector3.zero;
		clipHandler = GetComponent<UT_AudioClipHandler>();
		if (GetComponent<AudioSource>() != null)
		{
			GetComponent<AudioSource>().Play();
			GetComponent<AudioSource>().time = Random.value * GetComponent<AudioSource>().clip.length;
		}
		hissTimer = Random.value * 5f;
		base.Start();
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		if (!CL_GameManager.gMan.isPaused)
		{
			AI();
		}
	}

	private void AI()
	{
		if (Physics.Raycast(base.transform.position + base.transform.forward * floorOffset, base.transform.up, out hit, velocity.magnitude * Time.fixedDeltaTime, worldMask))
		{
			if (!canClimb)
			{
				velocity = Vector3.Reflect(velocity, hit.normal);
				targetVelocity = Vector3.Reflect(targetVelocity, hit.normal);
				Debug.Log("reflecting");
			}
			else
			{
				base.transform.position = hit.point + hit.normal * floorOffset;
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(hit.normal, base.transform.up), Time.deltaTime * 40f);
				velocity = base.transform.up;
			}
			onFloor = true;
		}
		else if (Physics.Raycast(base.transform.position + base.transform.forward * floorOffset, -base.transform.forward, out hit, 0.15f, worldMask))
		{
			base.transform.position = hit.point + hit.normal * floorOffset;
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(hit.normal, base.transform.up + velocity.normalized), Time.deltaTime * 40f);
			onFloor = true;
		}
		else if (Physics.Raycast(base.transform.position + base.transform.up * floorOffset, -base.transform.forward + -base.transform.up, out hit, 0.02f, worldMask))
		{
			if (canClimb)
			{
				base.transform.position = hit.point + hit.normal * floorOffset;
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(hit.normal, base.transform.up), Time.deltaTime * 40f);
				velocity = base.transform.up;
				onFloor = true;
			}
			else
			{
				velocity = -velocity;
				targetVelocity = velocity;
			}
		}
		else if (onFloor)
		{
			targetVelocity = -targetVelocity;
			velocity = -velocity;
			onFloor = false;
			wanderTime = 0.5f;
		}
		else
		{
			base.transform.position += Vector3.down * Time.deltaTime * 2f;
		}
		base.transform.position += velocity * Time.deltaTime;
		velocity = Vector3.Lerp(velocity, targetVelocity, Time.deltaTime * 5f);
		if (wanderTime <= 0f && !sightedPlayer)
		{
			Wander();
			wanderTime = Random.Range(0f, 3f);
		}
		else
		{
			wanderTime -= Time.deltaTime;
		}
		hissTimer -= Time.deltaTime;
		if (hissTimer <= 0f)
		{
			hissTimer = Random.value * 20f;
			clipHandler.PlaySound("critter:hiss");
		}
		Collider[] array = Physics.OverlapSphere(base.transform.position, fearDistance, playerMask);
		if (array.Length != 0 && fearPlayer)
		{
			if (!sightedPlayer)
			{
				clipHandler.PlaySound("critter:fear");
				sightedPlayer = true;
			}
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.SphereOutline(base.transform.position, 0.45f, Color.yellow);
			}
			targetVelocity = targetVelocity.normalized * runSpeed + (base.transform.position - array[0].transform.position).normalized * Time.fixedDeltaTime;
			if (Vector3.Distance(array[0].ClosestPoint(base.transform.position), base.transform.position) < 0.45f)
			{
				if (CL_UIManager.debug)
				{
					CL_DebugView.draw.SphereOutline(base.transform.position, 0.45f, Color.red);
				}
				Object.Instantiate(deathEffect, base.transform.position, Quaternion.identity);
				Object.Destroy(base.gameObject);
			}
			wanderTime = 0.5f;
		}
		else
		{
			sightedPlayer = false;
		}
	}

	private void Wander()
	{
		if (Random.value > 0.7f)
		{
			state = CritterState.idle;
			targetVelocity = Vector3.zero;
		}
		else
		{
			state = CritterState.wandering;
			Vector2 insideUnitCircle = Random.insideUnitCircle;
			targetVelocity = (base.transform.up * insideUnitCircle.x + base.transform.right * insideUnitCircle.y + GetFlockVector()) * speed;
		}
	}

	private Vector3 GetFlockVector()
	{
		return Vector3.zero;
	}
}
