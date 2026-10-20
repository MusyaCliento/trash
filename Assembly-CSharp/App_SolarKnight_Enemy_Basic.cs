using System.Collections.Generic;
using Drawing;
using UnityEngine;

public class App_SolarKnight_Enemy_Basic : App_SolarKnight_Entity
{
	public List<string> targetTags = new List<string>();

	private App_SolarKnight_Entity targetEntity;

	public float speed = 5f;

	public float acceleration = 1f;

	public float sinMotionAmplitude;

	public float sinMotionFrequency = 1f;

	private float sinTime;

	public float detectionRadius = 10f;

	private bool canSeeTarget;

	public App_SolarKnight_Player.HardpointInfo weaponHardpoint;

	public App_SolarKnight_Weapon weapon;

	public bool homeInOnTarget;

	public bool rotateTowardsVelocity;

	private void Start()
	{
		if (weapon != null)
		{
			weaponHardpoint.AddWeapon(weapon.weaponInfo.GetCopy());
		}
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		targetEntity = FindTarget();
		sinTime += App_SolarKnight_World.gameFixedDeltaTime;
		bool flag = false;
		if (targetEntity != null)
		{
			VisionCheck();
			if (canSeeTarget)
			{
				Vector3 normalized = (targetEntity.transform.localPosition - base.transform.localPosition).normalized;
				Vector3 vector = Vector3.Cross(normalized, Vector3.forward);
				if (homeInOnTarget)
				{
					Vector3 vector2 = normalized * speed - velocity;
					vector2 += vector * Mathf.Sin(sinTime * sinMotionFrequency) * sinMotionAmplitude;
					AddVelocity(vector2 * App_SolarKnight_World.gameFixedDeltaTime);
					flag = true;
				}
				if (weaponHardpoint.weaponInfo != null)
				{
					weaponHardpoint.ShootInDirection(this, null, normalized);
				}
			}
		}
		if (!flag)
		{
			Vector3 vector3 = Vector3.Cross(velocity.normalized, Vector3.forward) * Mathf.Sin(sinTime * sinMotionFrequency) * sinMotionAmplitude;
			Vector3 normalized2 = (velocity.normalized + vector3).normalized;
			velocity = Vector3.Lerp(velocity, normalized2 * speed, Time.fixedDeltaTime * acceleration);
		}
		if (rotateTowardsVelocity && velocity.magnitude > 0.1f)
		{
			Vector3 normalized3 = velocity.normalized;
			float z = Mathf.Atan2(normalized3.y, normalized3.x) * 57.29578f;
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.Euler(0f, 0f, z), Time.fixedDeltaTime * 5f);
		}
	}

	public App_SolarKnight_Entity FindTarget()
	{
		foreach (string targetTag in targetTags)
		{
			List<App_SolarKnight_Entity> entitiesWithTag = App_SolarKnight_World.instance.GetEntitiesWithTag(targetTag);
			float num = float.MaxValue;
			App_SolarKnight_Entity app_SolarKnight_Entity = null;
			foreach (App_SolarKnight_Entity item in entitiesWithTag)
			{
				float num2 = Vector3.Distance(base.transform.localPosition, item.transform.localPosition);
				if (num2 < num && num2 <= detectionRadius)
				{
					num = num2;
					app_SolarKnight_Entity = item;
				}
			}
			if (app_SolarKnight_Entity != null)
			{
				return app_SolarKnight_Entity;
			}
		}
		return null;
	}

	public void VisionCheck()
	{
		if (targetEntity != null)
		{
			if (Vector3.Distance(base.transform.localPosition, targetEntity.transform.localPosition) <= detectionRadius)
			{
				canSeeTarget = true;
			}
			else
			{
				canSeeTarget = false;
			}
		}
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
		foreach (Vector3 hardpointPosition in weaponHardpoint.hardpointPositions)
		{
			Vector3 vector = base.transform.TransformPoint(hardpointPosition);
			Draw.Arrow(vector, vector + base.transform.TransformVector(weaponHardpoint.hardpointForward), Color.cyan);
		}
		Vector3 vector2 = base.transform.position;
		Vector3 lhs = Vector3.right;
		for (float num = 0f; num < 10f; num += 0.1f)
		{
			if (homeInOnTarget)
			{
				Vector3 vector3 = Vector3.right * speed * 0.1f;
				Vector3 vector4 = Vector3.up * Mathf.Sin(num * sinMotionFrequency) * sinMotionAmplitude;
				Vector3 vector5 = vector2 + vector3 + vector4;
				Draw.Line(vector2, vector5, Color.magenta);
				vector2 = vector5;
			}
			else
			{
				Vector3 vector6 = lhs.normalized * speed * 0.1f;
				Vector3 vector7 = Vector3.Cross(lhs, Vector3.forward) * Mathf.Sin(num * sinMotionFrequency) * sinMotionAmplitude;
				Vector3 vector8 = vector2 + vector6 + vector7 * 0.1f;
				Draw.Line(vector8, vector2, Color.magenta);
				lhs = vector8 - vector2;
				vector2 = vector8;
			}
		}
	}
}
