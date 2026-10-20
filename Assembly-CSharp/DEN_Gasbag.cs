using System.Collections.Generic;
using UnityEngine;

public class DEN_Gasbag : Denizen
{
	[Header("Movement")]
	public float speed = 1f;

	private Rigidbody rigid;

	private Vector3 wanderDirection;

	public float wanderDrift = 100f;

	public float flockCohesion = 0.5f;

	private List<DEN_Gasbag> flock;

	public LayerMask flockLayermask;

	[Header("Visuals")]
	public float minSize = 1f;

	[Header("Visuals")]
	public float maxSize = 1f;

	private MeshFilter meshFilter;

	public List<Mesh> meshOptions;

	[Header("Explosion")]
	public bool explodeOnDeath = true;

	public string[] explodeTags;

	public float explodeDamage = 1f;

	private float wanderOffset;

	public float explodeDetectRadius = 3f;

	public float explodeForce = 2f;

	[Header("AI")]
	public float sightDistance = 6f;

	private Vector3 startPosition;

	[Header("Audio")]
	public float barkRate = 5f;

	private float barkTime = 10f;

	public override void Start()
	{
		base.Start();
		barkTime = Random.Range(barkRate, barkRate * 2f);
		rigid = GetComponent<Rigidbody>();
		rigid.useGravity = false;
		meshFilter = GetComponent<MeshFilter>();
		if (meshOptions != null && meshOptions.Count > 0)
		{
			meshFilter.mesh = meshOptions[Random.Range(0, meshOptions.Count)];
		}
		flock = new List<DEN_Gasbag>();
		base.transform.localScale *= Random.Range(minSize, maxSize);
		wanderOffset = Random.Range(0f, 100f);
		Collider[] array = Physics.OverlapSphere(base.transform.position, 10f, flockLayermask);
		startPosition = base.transform.position;
		if (array.Length != 0)
		{
			Collider[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				DEN_Gasbag component = array2[i].GetComponent<DEN_Gasbag>();
				if (component != null && component != this)
				{
					flock.Add(component);
				}
			}
		}
		clipHandler = GetComponent<UT_AudioClipHandler>();
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		wanderDirection.x += (Mathf.PerlinNoise(Time.time - base.transform.position.x + wanderOffset, Time.time + base.transform.position.x + wanderOffset) - 0.5f) * Time.fixedDeltaTime * wanderDrift;
		wanderDirection.y += (Mathf.PerlinNoise(Time.time - base.transform.position.y + wanderOffset, Time.time + base.transform.position.y + wanderOffset) - 0.5f) * Time.fixedDeltaTime * wanderDrift;
		wanderDirection.z += (Mathf.PerlinNoise(Time.time - base.transform.position.z + wanderOffset, Time.time + base.transform.position.z + wanderOffset) - 0.5f) * Time.fixedDeltaTime * wanderDrift;
		wanderDirection = wanderDirection.normalized;
		wanderDirection += GetFlockingVector() * 0.5f * flockCohesion;
		if (CL_UIManager.debug)
		{
			CL_DebugView.draw.Arrow(base.transform.position, base.transform.position + wanderDirection * 2f);
		}
		if (target != null && !CL_GameManager.noTarget)
		{
			wanderDirection += (target.position - base.transform.position).normalized;
		}
		else
		{
			wanderDirection.y += (startPosition.y - base.transform.position.y) * 0.1f;
		}
		rigid.AddForce(wanderDirection * Time.fixedDeltaTime * speed);
		if (rigid.linearVelocity.magnitude > 0f)
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(Vector3.Scale(rigid.linearVelocity.normalized, new Vector3(1f, 0.01f, 1f))), Time.fixedDeltaTime * 1.2f);
		}
		if (IsTickFrame())
		{
			ExplodeScan();
			ScanForTarget();
		}
		barkTime -= Time.fixedDeltaTime;
		if (barkTime < 0f)
		{
			barkTime = Random.Range(barkRate, barkRate * 2f);
			clipHandler.PlaySound("gasbag:grunt");
		}
	}

	public Vector3 GetFlockingVector()
	{
		Vector3 zero = Vector3.zero;
		foreach (DEN_Gasbag item in flock)
		{
			zero += (item.transform.position - base.transform.position).normalized / flock.Count;
		}
		return zero;
	}

	public void ScanForTarget()
	{
		if (CL_GameManager.noTarget)
		{
			return;
		}
		if (target != null)
		{
			if (Vector3.Distance(base.transform.position, target.position) > sightDistance * 1.5f)
			{
				target = null;
			}
			return;
		}
		Collider[] array = Physics.OverlapSphere(base.transform.position, sightDistance);
		foreach (Collider collider in array)
		{
			ObjectTagger component = collider.gameObject.GetComponent<ObjectTagger>();
			if (component != null && component.HasTagInList(explodeTags))
			{
				target = collider.transform;
				clipHandler.PlaySound("gasbag:alert");
				break;
			}
		}
	}

	public void ExplodeScan()
	{
		if (dead)
		{
			return;
		}
		Collider[] array = Physics.OverlapSphere(base.transform.position, explodeDetectRadius);
		foreach (Collider collider in array)
		{
			ObjectTagger component = collider.gameObject.GetComponent<ObjectTagger>();
			if (!(component != null) || !component.HasTagInList(explodeTags))
			{
				continue;
			}
			float num = Vector3.Angle(collider.transform.position - base.transform.position, Vector3.up);
			Kill("", null);
			if (explodeOnDeath && component.HasTag("Entity"))
			{
				GameEntity component2 = collider.GetComponent<GameEntity>();
				Vector3 vector = (collider.transform.position - base.transform.position).normalized;
				if (num < 70f)
				{
					vector = Vector3.up * 1.4f;
					if (component.HasTag("Player"))
					{
						CL_AchievementManager.SetAchievementValue("ACH_GASBAGJUMP", b: true);
						component2.ClampVelocityToAxis(Vector3.up);
					}
				}
				component2.AddForce(vector * explodeForce);
				List<string> tags = new List<string> { "explosion" };
				component2.Damage(Damageable.DamageInfo.CreateDamageInfo(explodeDamage, objectType, tags));
			}
			dead = true;
			break;
		}
	}

	private new void OnCollisionEnter(Collision other)
	{
		wanderDirection = other.contacts[0].normal;
	}

	public override void Kill(string type = "", Damageable.DamageInfo damageInfo = null)
	{
		clipHandler.PlaySound("gasbag:death");
		base.gameObject.SetActive(value: false);
		base.Kill(type, damageInfo);
	}

	public override void AddForce(Vector3 v, string source = "")
	{
		rigid.AddForce(v);
		base.AddForce(v);
	}

	public override bool Damage(Damageable.DamageInfo info)
	{
		clipHandler.PlaySound("gasbag:hurt");
		return base.Damage(info);
	}

	public override void OffsetEntity(float amount)
	{
		base.OffsetEntity(amount);
		startPosition.y += amount;
	}
}
