using System;
using System.Collections;
using System.Collections.Generic;
using Drawing;
using UnityEngine;

public class App_SolarKnight_Entity : MonoBehaviourGizmos
{
	[Serializable]
	public class KillDrops
	{
		public App_SolarKnight_Collectable dropPrefab;

		public float dropChance = 0.5f;

		public int minDrop = 1;

		public int maxDrop = 3;

		public float dropForce = 2f;
	}

	internal Vector3 velocity;

	internal float angularVelocity;

	public List<string> tags = new List<string>();

	public float skin = 0.01f;

	public float drag;

	public float angularDrag;

	public float maxVelocity = 20f;

	public float mass = 1f;

	public bool lockRotation;

	public bool canCollide = true;

	public SpriteRenderer sprite;

	private CircleCollider2D circleCollider;

	public bool useHealth = true;

	public float health = 1f;

	public int hitDamage = 1;

	public int destroyScore;

	public List<KillDrops> killDrops = new List<KillDrops>();

	public float lifeTime;

	private float lifeTimer;

	public string deathParticle = "hit";

	private HashSet<GameObject> ignoreObject = new HashSet<GameObject>();

	public List<string> ignoreTags = new List<string>();

	private bool hasBeenDestroyed;

	public static Action<GameObject> _OnDestroy;

	public AudioClip destroySound;

	private Coroutine damageFlashCoroutine;

	private void Awake()
	{
		circleCollider = GetComponent<CircleCollider2D>();
		App_SolarKnight_World.instance.RegisterEntity(this);
		_OnDestroy = (Action<GameObject>)Delegate.Combine(_OnDestroy, new Action<GameObject>(RemoveFromIgnoreList));
	}

	private void Update()
	{
		if (lifeTime > 0f)
		{
			lifeTimer += App_SolarKnight_World.gameDeltaTime;
			if (lifeTimer >= lifeTime)
			{
				Kill();
			}
		}
	}

	public virtual void FixedUpdate()
	{
		PhysicsCheck();
		Movement();
	}

	public virtual void Movement()
	{
		velocity = Vector3.ClampMagnitude(velocity, maxVelocity);
		base.transform.localPosition = App_SolarKnight_World.instance.CalculatePosition(base.transform.localPosition + velocity * App_SolarKnight_World.gameFixedDeltaTime, this);
		velocity -= velocity * drag * App_SolarKnight_World.gameFixedDeltaTime;
		if (!lockRotation)
		{
			angularVelocity -= angularVelocity * angularDrag * App_SolarKnight_World.gameFixedDeltaTime;
			base.transform.Rotate(new Vector3(0f, 0f, angularVelocity * App_SolarKnight_World.gameFixedDeltaTime));
		}
	}

	public virtual void PhysicsCheck()
	{
		if (circleCollider == null || !canCollide)
		{
			return;
		}
		circleCollider.enabled = false;
		RaycastHit2D raycastHit2D = Physics2D.CircleCast(base.transform.position, circleCollider.radius * 0.9f, velocity.normalized, velocity.magnitude * App_SolarKnight_World.gameFixedDeltaTime);
		_ = (bool)raycastHit2D;
		if (raycastHit2D.collider != null)
		{
			if (ignoreObject.Contains(raycastHit2D.collider.gameObject))
			{
				circleCollider.enabled = true;
				return;
			}
			App_SolarKnight_Entity hitEntity = raycastHit2D.collider.GetComponent<App_SolarKnight_Entity>();
			if (hitEntity != null && (hitEntity.ignoreObject.Contains(base.gameObject) || hitEntity.ignoreTags.Exists((string tag) => tags.Contains(tag)) || ignoreTags.Exists((string tag) => hitEntity.tags.Contains(tag))))
			{
				circleCollider.enabled = true;
				return;
			}
			Vector2 vector = velocity.normalized;
			base.transform.position += (Vector3)(vector * (raycastHit2D.distance - skin));
			Vector2 normal = raycastHit2D.normal;
			float num = Vector2.Dot(velocity, normal);
			if (num >= 0f)
			{
				circleCollider.enabled = true;
				return;
			}
			velocity -= (Vector3)normal * num;
			if (hitEntity != null)
			{
				if (!hitEntity.canCollide)
				{
					circleCollider.enabled = true;
					return;
				}
				hitEntity.AddVelocity(normal * num * 0.5f);
				hitEntity.Damage(hitDamage);
				Damage(hitEntity.hitDamage);
				ApplyAngularImpulse(hitEntity, -velocity * num * 0.5f, raycastHit2D.point);
				hitEntity.AddAngularVelocity(num * 5f);
			}
		}
		circleCollider.enabled = true;
	}

	private void ApplyAngularImpulse(App_SolarKnight_Entity body, Vector2 impulse, Vector2 worldPoint)
	{
		Vector2 vector = worldPoint - (Vector2)body.transform.position;
		float num = vector.x * impulse.y - vector.y * impulse.x;
		float num2 = 0.5f * body.mass * body.GetCollider().radius * body.GetCollider().radius;
		float num3 = num / num2;
		body.angularVelocity += num3;
	}

	public virtual void Damage(float amount)
	{
		if (!useHealth)
		{
			return;
		}
		health -= amount;
		if (health <= 0f)
		{
			StopAllCoroutines();
			sprite.color = Color.white;
			Kill();
		}
		else if (sprite != null)
		{
			if (damageFlashCoroutine != null)
			{
				sprite.color = Color.white;
				StopCoroutine(damageFlashCoroutine);
			}
			damageFlashCoroutine = StartCoroutine(DamageFlash());
		}
		IEnumerator DamageFlash()
		{
			Color originalColor = sprite.color;
			sprite.color = Color.red;
			yield return new WaitForSeconds(0.1f);
			sprite.color = originalColor;
		}
	}

	public virtual void Kill(bool spawnDrops = true)
	{
		App_SolarKnight_World.instance.AddScore(destroyScore);
		if (destroySound != null)
		{
			App_SolarKnight_World.instance.PlaySound(destroySound, 0.5f);
		}
		if (deathParticle != "")
		{
			App_SolarKnight_World.instance.PlayParticle(deathParticle, base.transform.position, 7);
		}
		if (spawnDrops)
		{
			SpawnDrops();
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public virtual void SpawnDrops()
	{
		foreach (KillDrops killDrop in killDrops)
		{
			if (UnityEngine.Random.value < killDrop.dropChance)
			{
				int num = UnityEngine.Random.Range(killDrop.minDrop, killDrop.maxDrop + 1);
				for (int i = 0; i < num; i++)
				{
					UnityEngine.Object.Instantiate(killDrop.dropPrefab, base.transform.position, Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(0, 360)), base.transform.parent).AddVelocity(UnityEngine.Random.insideUnitCircle.normalized * UnityEngine.Random.Range(1f, 3f) * killDrop.dropForce);
				}
			}
		}
	}

	public virtual void AddVelocity(Vector3 vel)
	{
		velocity += vel / mass;
	}

	public virtual void AddAngularVelocity(float angVel)
	{
		angularVelocity += angVel;
	}

	public void AddIgnoreObject(GameObject obj)
	{
		ignoreObject.Add(obj);
	}

	public CircleCollider2D GetCollider()
	{
		return circleCollider;
	}

	public virtual void OnTeleport()
	{
	}

	public virtual void OnDestroy()
	{
		hasBeenDestroyed = true;
		_OnDestroy?.Invoke(base.gameObject);
	}

	public virtual void RemoveFromIgnoreList(GameObject obj)
	{
		if (ignoreObject != null && ignoreObject.Contains(obj))
		{
			ignoreObject.Remove(obj);
		}
	}

	public bool IsDestroyed()
	{
		return hasBeenDestroyed;
	}

	public bool HasTag(string tag)
	{
		return tags.Contains(tag);
	}

	public void AddIgnoreTag(string tag)
	{
		if (!ignoreTags.Contains(tag))
		{
			ignoreTags.Add(tag);
		}
	}
}
