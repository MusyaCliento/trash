using System;
using System.Collections.Generic;
using Drawing;
using UnityEngine;

public class UT_Explosion : MonoBehaviourGizmos
{
	[Serializable]
	public class ExplosionEffect
	{
		public List<string> hitTags;

		public float distance;

		public float damage;

		public float force = 1f;

		public float upwardsForce;

		public float torqueMultiplier = 2f;

		public float hitFreeze;

		public AnimationCurve forceCurve;

		public AnimationCurve damageCurve = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 1f));
	}

	public LayerMask hitMask;

	public float damageMult = 1f;

	public float maxDistance = 5f;

	public List<ExplosionEffect> effects;

	public string damageType = "explosion";

	public List<string> damageTags = new List<string> { "explosion", "explosive" };

	public bool incendiary;

	public float incendiaryAmount = 5f;

	public bool runOnStart = true;

	public float shakeMagnitude = 0.1f;

	public float shakeDistance = 10f;

	private void Start()
	{
		if (runOnStart)
		{
			Explode();
		}
	}

	public void Explode()
	{
		CL_CameraControl.ShakeAtPosition(base.transform.position, shakeMagnitude, shakeDistance);
		Collider[] array = Physics.OverlapSphere(base.transform.position, maxDistance, hitMask);
		List<GameEntity> list = new List<GameEntity>();
		if (array.Length == 0)
		{
			return;
		}
		for (int i = 0; i < array.Length; i++)
		{
			ObjectTagger component = array[i].GetComponent<ObjectTagger>();
			Hitbox component2 = array[i].GetComponent<Hitbox>();
			GameEntity gameEntity = null;
			gameEntity = ((component2 == null) ? array[i].GetComponent<GameEntity>() : component2.GetGameEntity());
			if (gameEntity != null)
			{
				if (list.Contains(gameEntity))
				{
					continue;
				}
				list.Add(gameEntity);
			}
			float num = Vector3.Distance(base.transform.position, array[i].transform.position);
			if (!(component != null))
			{
				continue;
			}
			foreach (ExplosionEffect effect in effects)
			{
				if (!component.HasTagInList(effect.hitTags.ToArray()))
				{
					continue;
				}
				if (num > effect.distance)
				{
					break;
				}
				float num2 = effect.damageCurve.Evaluate(num / effect.distance);
				if (gameEntity != null)
				{
					gameEntity.Damage(Damageable.DamageInfo.CreateDamageInfo(effect.damage * num2 * damageMult, damageType, damageTags));
					float num3 = effect.forceCurve.Evaluate(num / effect.distance);
					gameEntity.AddForce((gameEntity.transform.position - base.transform.position).normalized * (effect.force * num3) + Vector3.up * effect.upwardsForce * num3);
					Rigidbody component3 = array[i].GetComponent<Rigidbody>();
					if (component3 != null)
					{
						component3.AddTorque(UnityEngine.Random.insideUnitSphere * effect.torqueMultiplier * (effect.force * num3));
					}
					if (incendiary)
					{
						gameEntity.AddEffect("fire", incendiaryAmount);
					}
					if (effect.hitFreeze > 0f)
					{
						CL_GameManager.gMan.FreezeForTime(effect.hitFreeze, 0.01f);
					}
					break;
				}
				array[i].gameObject.GetComponent<Damageable>()?.Damage(Damageable.DamageInfo.CreateDamageInfo(effect.damage * num2 * damageMult, damageType, damageTags));
			}
		}
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		Draw.WireSphere(base.transform.position, maxDistance, DarkMachineCrayons.orange);
	}
}
