using UnityEngine;

public class DEN_SimpleSwimmer : DEN_BasicDenizen
{
	public bool canTargetOutsideOfWater;

	private bool hasHit;

	private float seeTargetTime;

	private UT_SwimZone startingSwimZone;

	public override void Start()
	{
		base.Start();
		startingSwimZone = UT_SwimZone.GetTargetSwimZone(base.transform.position);
		if (startingSwimZone == null)
		{
			Kill("", null);
		}
	}

	public override void TickUpdate()
	{
		base.TickUpdate();
		if (!targetComponent.HasTarget())
		{
			targetComponent.CheckForTarget(base.transform.position, sight.sightDistance);
		}
		if (targetComponent.HasTarget())
		{
			target = targetComponent.target.targetTransform;
		}
	}

	public override void Update()
	{
		if (targetComponent.HasTarget())
		{
			if (!canTargetOutsideOfWater && startingSwimZone != null && !startingSwimZone.IsPositionInSwimZone(targetComponent.target.targetTransform.position))
			{
				sight.active = false;
			}
			else
			{
				sight.active = true;
			}
		}
		base.Update();
		if (!dead && active)
		{
			if (startingSwimZone != null && !startingSwimZone.IsPositionInSwimZone(base.transform.position))
			{
				base.transform.position = startingSwimZone.ClampPositionToSwimZone(base.transform.position);
			}
			if (startingSwimZone != null && !startingSwimZone.IsPositionInSwimZone(GetTargetPosition()))
			{
				SetTargetPosition(startingSwimZone.ClampPositionToSwimZone(GetTargetPosition()) - Vector3.up * 0.75f);
			}
		}
	}

	public override void Kill(string type = "", Damageable.DamageInfo damageInfo = null)
	{
		base.Kill(type, damageInfo);
		rigid.useGravity = true;
	}

	public override void AddForce(Vector3 v, string source = "")
	{
		if (rigid == null)
		{
			rigid = GetComponent<Rigidbody>();
		}
		base.AddForce(v, "");
		rigid.AddForce(v * 10f);
	}

	internal override void WaterUpdate()
	{
		base.WaterUpdate();
		if (dead)
		{
			float num = Mathf.Clamp01(startingSwimZone.GetDepth(base.transform.position) * 1f);
			rigid.AddForce(Vector3.up * 1f * Time.deltaTime * 1000f * num, ForceMode.Acceleration);
		}
	}
}
