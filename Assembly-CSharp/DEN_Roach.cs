using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEN_Roach : Denizen
{
	public enum RoachState
	{
		idle = 0,
		hungry = 1,
		wandering = 2
	}

	public bool active = true;

	public LayerMask worldMask;

	public float floorOffset = 0.01f;

	private RaycastHit hit;

	public string[] flockTags;

	public string[] fearTags;

	private Vector3 moveVel;

	private Vector3 targetMoveVelocity;

	private Vector3 velocity;

	private float wanderTime;

	public float speed = 0.5f;

	private bool onFloor;

	public bool canSquish = true;

	public float sightDistance = 1.5f;

	public GameObject deathEffect;

	private bool sightedFear;

	private float hissTimer = 1f;

	public RoachState state;

	public bool flock = true;

	public bool fearPlayer = true;

	public float runSpeed = 2f;

	private float dropTime = 2f;

	private Vector3 startPos;

	private List<Vector3> flockPositions = new List<Vector3>();

	private bool tooFarFromPlayer;

	private Collider[] sighted;

	public float deathTime;

	public override void Start()
	{
		startPos = base.transform.position;
		clipHandler = GetComponent<UT_AudioClipHandler>();
		GetComponent<AudioSource>().Play();
		GetComponent<AudioSource>().time = Random.value * GetComponent<AudioSource>().clip.length;
		hissTimer = Random.value * 5f;
	}

	public override void Update()
	{
		base.Update();
		if (dead)
		{
			return;
		}
		if (IsTickFrame())
		{
			if (Vector3.Distance(Camera.main.transform.position, base.transform.position) > 30f)
			{
				tooFarFromPlayer = true;
			}
			else
			{
				tooFarFromPlayer = false;
			}
			sighted = Physics.OverlapSphere(base.transform.position, sightDistance, sight.sightMask);
		}
		if (!CL_GameManager.gMan.isPaused && active && !tooFarFromPlayer)
		{
			AI();
			if (dropTime >= 0f)
			{
				dropTime -= Time.deltaTime;
			}
		}
	}

	public override void OnEnable()
	{
		dropTime = 2f;
		startPos = base.transform.position;
		StartCoroutine(WaitToSetStartPos());
		base.OnEnable();
		IEnumerator WaitToSetStartPos()
		{
			yield return null;
			startPos = base.transform.position;
		}
	}

	private void AI()
	{
		if (Physics.Raycast(base.transform.position + base.transform.forward * floorOffset, base.transform.up, out hit, 0.03f, worldMask))
		{
			base.transform.position = hit.point + hit.normal * floorOffset;
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(hit.normal, base.transform.up), Time.deltaTime * 40f);
			moveVel = base.transform.up;
			onFloor = true;
		}
		else if (Physics.Raycast(base.transform.position + base.transform.forward * floorOffset, -base.transform.forward, out hit, 0.15f, worldMask))
		{
			base.transform.position = hit.point + hit.normal * floorOffset;
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(hit.normal, base.transform.up + moveVel.normalized), Time.deltaTime * 40f);
			onFloor = true;
		}
		else if (Physics.Raycast(base.transform.position + base.transform.up * floorOffset, -base.transform.forward + -base.transform.up, out hit, 0.02f, worldMask))
		{
			base.transform.position = hit.point + hit.normal * floorOffset;
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(hit.normal, base.transform.up), Time.deltaTime * 40f);
			moveVel = base.transform.up;
			onFloor = true;
		}
		else if (onFloor)
		{
			targetMoveVelocity = -targetMoveVelocity;
			moveVel = -moveVel;
			onFloor = false;
			wanderTime = 0.5f;
		}
		else if (Vector3.Distance(startPos, base.transform.position) > 10f)
		{
			base.gameObject.SetActive(value: false);
		}
		else if (Physics.Raycast(base.transform.position, moveVel + velocity, out hit, Time.deltaTime * 8f, worldMask))
		{
			base.transform.position = hit.point + hit.normal * floorOffset;
			base.transform.rotation = Quaternion.LookRotation(hit.normal, base.transform.up);
			moveVel = Vector3.zero;
			targetMoveVelocity = Vector3.zero;
			onFloor = true;
		}
		else
		{
			velocity += Vector3.down * Time.deltaTime * 9f;
			base.transform.rotation = Quaternion.LookRotation(moveVel);
		}
		if (onFloor)
		{
			velocity = Vector3.zero;
		}
		base.transform.position += (moveVel + velocity) * Time.deltaTime;
		moveVel = Vector3.Lerp(moveVel, targetMoveVelocity, Time.deltaTime * 5f);
		if (wanderTime <= 0f)
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
			clipHandler.PlaySound("roach:hiss");
		}
		if (sighted != null && sighted.Length != 0)
		{
			flockPositions.Clear();
			for (int i = 0; i < sighted.Length; i++)
			{
				if (sighted == null || sighted[i] == null)
				{
					continue;
				}
				ObjectTagger component = sighted[i].GetComponent<ObjectTagger>();
				if (!(component != null))
				{
					continue;
				}
				if (component.HasTagInList(fearTags))
				{
					if (CL_UIManager.debug)
					{
						CL_DebugView.draw.SphereOutline(base.transform.position, 0.45f, Color.yellow);
					}
					if (ENT_Player.playerObject.HasPerk("Perk_PheromoneGlands") || CL_GameManager.HasActiveFlag("pacifyroaches"))
					{
						continue;
					}
					targetMoveVelocity = (base.transform.position - sighted[i].transform.position).normalized * runSpeed;
					if (canSquish && Vector3.Distance(sighted[i].ClosestPoint(base.transform.position), base.transform.position) < 0.45f && dropTime <= 0f)
					{
						if (CL_UIManager.debug)
						{
							CL_DebugView.draw.SphereOutline(base.transform.position, 0.45f, Color.red);
						}
						CL_ScoreManager.sessionScore.AddScore("Roaches Smashed", "Roaches Smashed", 10f, 0f, 1);
						Kill("", null);
						break;
					}
				}
				else if (component.HasTagInList(flockTags))
				{
					flockPositions.Add(sighted[i].transform.position);
				}
			}
		}
		else
		{
			sightedFear = false;
		}
	}

	private void Wander()
	{
		if (Random.value > 0.7f)
		{
			state = RoachState.idle;
			targetMoveVelocity = Vector3.zero;
		}
		else
		{
			state = RoachState.wandering;
			Vector2 insideUnitCircle = Random.insideUnitCircle;
			targetMoveVelocity = (base.transform.up * insideUnitCircle.x + base.transform.right * insideUnitCircle.y + GetFlockVector()) * speed;
		}
	}

	private Vector3 GetFlockVector()
	{
		if (!flock)
		{
			return Vector3.zero;
		}
		Vector3 zero = Vector3.zero;
		foreach (Vector3 flockPosition in flockPositions)
		{
			zero += (flockPosition - base.transform.position) * 0.15f;
		}
		return Vector3.ClampMagnitude(zero, 1f);
	}

	public override void Kill(string type = "", Damageable.DamageInfo info = null)
	{
		if (!dead)
		{
			dead = true;
			StartCoroutine(DeathTimer());
		}
		IEnumerator DeathTimer()
		{
			bool flag = type == "explosion";
			yield return new WaitForSeconds((deathTime + (flag ? 0.5f : 0f)) * Random.value);
			StatManager.sessionStats.UpdateStatistic("roach-killed", 1, StatManager.Statistic.DataType.Int, StatManager.Statistic.ModType.Add);
			Object.Instantiate(deathEffect, base.transform.position, Quaternion.identity);
			Object.Destroy(base.gameObject);
		}
	}

	public override bool Damage(Damageable.DamageInfo info)
	{
		if (!damageable)
		{
			return false;
		}
		if (info.amount == 0f)
		{
			return false;
		}
		Kill(info.type, info);
		base.Damage(info);
		return true;
	}

	public override void AddForce(Vector3 v, string source = "")
	{
		velocity += v;
		base.AddForce(v);
	}

	public override void SetForce(Vector3 v)
	{
		velocity = v;
		base.transform.position += v * Time.deltaTime;
		onFloor = false;
		startPos = base.transform.position;
		base.SetForce(v);
	}
}
