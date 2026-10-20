using System.Collections.Generic;
using UnityEngine;

public class UT_DamageTrigger : UT_TriggerBase<UT_DamageTrigger.DamageEntry>
{
	public class DamageEntry : UT_TriggerEntry
	{
		public GameEntity other;

		public float damageTime;

		public GameObject gameObject { get; set; }

		public bool FillFrom(GameObject gameObject)
		{
			this.gameObject = gameObject;
			other = gameObject.GetComponent<GameEntity>();
			return other != null;
		}
	}

	public float damage = 1f;

	public string damageType = "trigger";

	public bool damageOverTime;

	public float damageRate = 0.5f;

	public bool damageWhenMoving;

	public float speedMultiplier = 1f;

	public float minimumSpeed;

	public float minimumDamage;

	private Vector3 lastPosition;

	private float currentSpeed;

	private float curDamage;

	public List<AudioClip> damageAudio;

	public float damageAudioVolume = 1f;

	public float damageAudioPitch = 1f;

	internal override void FixedUpdate()
	{
		base.FixedUpdate();
		if (!damageOverTime)
		{
			return;
		}
		for (int i = 0; i < triggerObjects.Count; i++)
		{
			if (triggerObjects[i].other == null)
			{
				triggerObjects.RemoveAt(i--);
				continue;
			}
			triggerObjects[i].damageTime -= Time.fixedDeltaTime;
			if (triggerObjects[i].damageTime < 0f)
			{
				triggerObjects[i].damageTime = damageRate;
				Damage(triggerObjects[i].other);
			}
		}
	}

	private void LateUpdate()
	{
		currentSpeed = (base.transform.position - lastPosition).magnitude / Time.deltaTime / 50f;
		lastPosition = base.transform.position;
		if (damageWhenMoving)
		{
			curDamage = Mathf.Max(currentSpeed * speedMultiplier * damage, minimumDamage);
		}
	}

	private void Update()
	{
		if (!CL_UIManager.debug || !damageWhenMoving)
		{
			return;
		}
		if (currentSpeed > minimumSpeed)
		{
			if (curDamage >= 5f)
			{
				CL_DebugView.draw.Label2D(base.transform.position, "VDMG: " + curDamage, Color.red);
			}
			else
			{
				CL_DebugView.draw.Label2D(base.transform.position, "VDMG: " + curDamage, Color.yellow);
			}
		}
		else
		{
			CL_DebugView.draw.Label2D(base.transform.position, "VDMG: " + curDamage, Color.green);
		}
	}

	private void Damage(Damageable damageable)
	{
		if (damageable == null || !damageable.GetGameObject().activeInHierarchy)
		{
			return;
		}
		if (damageAudio != null && damageAudio.Count > 0)
		{
			AudioManager.PlaySound(damageAudio[Random.Range(0, damageAudio.Count)], damageable.GetGameObject().transform.position, damageAudioVolume, damageAudioPitch);
		}
		if (damageWhenMoving)
		{
			float num = currentSpeed * speedMultiplier;
			if (currentSpeed > minimumSpeed)
			{
				damageable.Damage(Damageable.DamageInfo.CreateDamageInfo(Mathf.Max(damage * num, minimumDamage), damageType));
			}
			else if (minimumDamage > 0f)
			{
				damageable.Damage(Damageable.DamageInfo.CreateDamageInfo(minimumDamage, damageType));
			}
		}
		else
		{
			damageable.Damage(Damageable.DamageInfo.CreateDamageInfo(damage, damageType));
		}
	}

	protected override void OnTriggerEnter(Collider other)
	{
		if (!ObjectTagger.TagCheck(other.gameObject, triggerTags))
		{
			return;
		}
		Damageable component = other.GetComponent<Damageable>();
		if (component != null)
		{
			if (damageOverTime)
			{
				AddTriggerObjectFromCollider(other);
			}
			else
			{
				Damage(component);
			}
		}
	}
}
