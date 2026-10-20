using System.Collections.Generic;
using UnityEngine;

public class DEN_BasicDenizen_Flier_Swarm : DEN_BasicDenizen_Flier
{
	private class SwarmObject
	{
		public Vector3 localPosition;

		public ENT_Hitbox hitbox;

		public float followAmount;

		public Vector3 velocity;

		public float expand;
	}

	public ENT_Hitbox swarmGameObject;

	public int swarmCount = 5;

	public float swarmTightness = 3f;

	public float swarmFollowRate = 0.1f;

	public float swarmNoiseFrequency = 1f;

	public float swarmNoiseIntensity;

	public float swarmNoiseFrequencyOffset = 1f;

	private List<SwarmObject> swarmObjects = new List<SwarmObject>();

	public override void Start()
	{
		base.Start();
		for (int i = 0; i < swarmCount; i++)
		{
			ENT_Hitbox eNT_Hitbox = Object.Instantiate(swarmGameObject);
			eNT_Hitbox.entity = this;
			SwarmObject swarmObject = new SwarmObject();
			swarmObject.localPosition = Random.onUnitSphere * i;
			swarmObject.hitbox = eNT_Hitbox;
			swarmObject.followAmount = i;
			eNT_Hitbox.transform.localScale = eNT_Hitbox.transform.localScale * Random.Range(0.9f, 1.1f);
			swarmObjects.Add(swarmObject);
		}
		maxHealth = swarmCount;
		health = swarmCount;
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		Vector3 forward = rigid.linearVelocity;
		bool flag = false;
		if (targetComponent.HasTarget() && Vector3.Distance(base.transform.position, targetComponent.target.targetTransform.position) < 3f)
		{
			flag = true;
		}
		for (int i = 0; i < swarmObjects.Count; i++)
		{
			SwarmObject swarmObject = swarmObjects[i];
			Vector3 vector = new Vector3(Mathf.PerlinNoise(Time.time * swarmNoiseFrequency + (float)i * swarmNoiseFrequencyOffset + 10.026f, 0f) - 0.5f, Mathf.PerlinNoise(Time.time * swarmNoiseFrequency + (float)i * swarmNoiseFrequencyOffset + 600f + 10.026f, 0f) - 0.5f, Mathf.PerlinNoise(Time.time * swarmNoiseFrequency + (float)i * swarmNoiseFrequencyOffset + 1500f + 10.026f, 0f) - 0.5f);
			vector *= swarmNoiseIntensity;
			Vector3 b = base.transform.InverseTransformVector(rigid.linearVelocity * swarmObject.followAmount * swarmFollowRate) + vector;
			_ = swarmObject.hitbox.transform.position;
			swarmObject.velocity = Vector3.Lerp(swarmObject.velocity, b, Time.deltaTime * 1f);
			swarmObject.expand = Mathf.Lerp(swarmObject.expand, rigid.linearVelocity.magnitude * 0.1f + 1f + Mathf.Sin(Time.time + (float)i * 0.2f) * 0.25f, Time.deltaTime);
			Vector3 b2 = base.transform.TransformPoint(swarmObject.localPosition * swarmObject.expand / swarmTightness - swarmObject.velocity);
			swarmObject.hitbox.transform.position = Vector3.Lerp(swarmObject.hitbox.transform.position, b2, Time.deltaTime * (swarmObject.followAmount + 1f) * 5f);
			_ = swarmObject.hitbox.transform.position;
			if (flag)
			{
				forward = ((!(targetComponent.target.targetEntity != null) || !(targetComponent.target.targetEntity == ENT_Player.GetPlayer())) ? (targetComponent.target.targetTransform.position - swarmObject.hitbox.transform.position) : (ENT_Player.GetPlayer().cam.transform.position - swarmObject.hitbox.transform.position));
			}
			if (rigid.linearVelocity.magnitude > 0.8f)
			{
				swarmObject.hitbox.transform.rotation = Quaternion.Lerp(swarmObject.hitbox.transform.rotation, Quaternion.LookRotation(forward), Time.deltaTime * (float)(i + 1) * 0.5f);
			}
		}
	}

	public override bool Damage(Damageable.DamageInfo info)
	{
		if (!damageable)
		{
			return false;
		}
		info.amount = 1f;
		if (info.HasTag("explosive"))
		{
			Kill("", null);
			return true;
		}
		return base.Damage(info);
	}

	public override void Kill(string type = "", Damageable.DamageInfo damageInfo = null)
	{
		base.Kill(type, damageInfo);
		foreach (SwarmObject swarmObject in swarmObjects)
		{
			Object.Destroy(swarmObject.hitbox.gameObject);
		}
		Object.Destroy(base.gameObject);
	}
}
