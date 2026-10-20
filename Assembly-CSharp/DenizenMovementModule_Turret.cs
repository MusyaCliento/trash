using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DenizenMovementModule_Turret : DenizenMovementModule
{
	[Serializable]
	public class TurretSegment
	{
		public Transform turretTransform;

		public bool lockXRotation;

		public bool lockYRotation;

		public bool lockZRotation;

		public float trackSpeedMult = 1f;

		public float clampAngle = -1f;

		internal Vector3 rotationVelocity;
	}

	public List<TurretSegment> turretSegments;

	public float horizontalTurnSpeed = 10f;

	public float verticalTurnSpeed = 10f;

	public float turnSpeedMult = 1f;

	public float verticalScaleMult = 1f;

	private float currentSpeedMult = 1f;

	public bool clampHorizontalAngle;

	public float minLookHorizontalAngle = -90f;

	public float maxLookHorizontalAngle = 90f;

	public bool clampVerticalAngle;

	public float minLookVerticalAngle = -90f;

	public float maxLookVerticalAngle = 90f;

	public float acceleration = 2f;

	private Vector3 lookVector;

	private AIGameEntity aiEnt;

	public override void Initialize(GameEntity gE)
	{
		base.Initialize(gE);
		aiEnt = gE.GetComponent<AIGameEntity>();
	}

	public override void Update()
	{
		base.Update();
		Vector3 vector = lookVector;
		if (vector == Vector3.zero)
		{
			return;
		}
		for (int i = 0; i < turretSegments.Count; i++)
		{
			Vector3 eulerAngles = Quaternion.LookRotation(turretSegments[i].turretTransform.parent.InverseTransformVector(vector), turretSegments[i].turretTransform.parent.up).eulerAngles;
			if (clampHorizontalAngle)
			{
				float num = eulerAngles.y;
				if (num > 180f)
				{
					num -= 360f;
				}
				num = Mathf.Clamp(num, minLookHorizontalAngle, maxLookHorizontalAngle);
				eulerAngles.y = num;
			}
			if (clampVerticalAngle)
			{
				float num2 = eulerAngles.x;
				if (num2 > 180f)
				{
					num2 -= 360f;
				}
				num2 = Mathf.Clamp(num2, minLookVerticalAngle, maxLookVerticalAngle);
				eulerAngles.x = num2;
			}
			if (turretSegments[i].clampAngle > 0f)
			{
				float num3 = eulerAngles.y;
				if (num3 > 180f)
				{
					num3 -= 360f;
				}
				num3 = Mathf.Clamp(num3, 0f - turretSegments[i].clampAngle, turretSegments[i].clampAngle);
				eulerAngles.y = num3;
				float num4 = eulerAngles.x;
				if (num4 > 180f)
				{
					num4 -= 360f;
				}
				num4 = Mathf.Clamp(num4, 0f - turretSegments[i].clampAngle, turretSegments[i].clampAngle);
				eulerAngles.x = num4;
			}
			Vector3 b = Vector3.zero;
			if (canMove)
			{
				b = eulerAngles - turretSegments[i].turretTransform.localRotation.eulerAngles;
				b.x = Mathf.DeltaAngle(turretSegments[i].turretTransform.localRotation.eulerAngles.x, eulerAngles.x);
				b.y = Mathf.DeltaAngle(turretSegments[i].turretTransform.localRotation.eulerAngles.y, eulerAngles.y);
				b.x = Mathf.Clamp(b.x, (0f - verticalTurnSpeed) * turnSpeedMult, verticalTurnSpeed * turnSpeedMult);
				b.y = Mathf.Clamp(b.y, (0f - horizontalTurnSpeed) * turnSpeedMult, horizontalTurnSpeed * turnSpeedMult);
				if (turretSegments[i].lockXRotation)
				{
					b.x = 0f;
				}
				if (turretSegments[i].lockYRotation)
				{
					b.y = 0f;
				}
				if (turretSegments[i].lockZRotation)
				{
					b.z = 0f;
				}
				b *= turretSegments[i].trackSpeedMult * currentSpeedMult;
			}
			turretSegments[i].rotationVelocity = Vector3.Lerp(turretSegments[i].rotationVelocity, b, Time.deltaTime * acceleration);
			Vector3 eulerAngles2 = turretSegments[i].turretTransform.localRotation.eulerAngles;
			turretSegments[i].turretTransform.localRotation = Quaternion.Euler(eulerAngles2 + new Vector3(turretSegments[i].rotationVelocity.x * verticalScaleMult, turretSegments[i].rotationVelocity.y, 0f) * Time.deltaTime);
		}
	}

	public override void SetLookVector(Vector3 v)
	{
		base.SetLookVector(v);
		lookVector = v;
	}

	public override void SetSpeedMult(float mult)
	{
		base.SetSpeedMult(mult);
		currentSpeedMult = mult;
	}

	public override float GetSpeedMult()
	{
		return currentSpeedMult;
	}
}
