using DarkMachine.AI;
using UnityEngine;

public class Projectile_Homing : Projectile
{
	public AITargetComponent targetComponent;

	public AISightComponent sightComponent;

	public float rotationSpeed = 10f;

	public Transform bankingRootTransform;

	public float maxBankAngle;

	public float bankAngleMult = 1f;

	internal Vector3 alignmentVector;

	public override void Initialize(Vector3 direction, GameEntity ent = null, Item item = null)
	{
		base.Initialize(direction, ent, item);
		targetComponent.CheckForTarget(base.transform.position, sightComponent.sightDistance, sightComponent, base.transform);
	}

	public override void Update()
	{
		base.Update();
		if (targetComponent.HasTarget() && sightComponent.CanSeeTarget(targetComponent.target.targetTransform, checkMemory: true))
		{
			alignmentVector = sightComponent.GetLastSeenPosition() - base.transform.position;
			velocity = Vector3.RotateTowards(velocity.normalized, alignmentVector.normalized, rotationSpeed * Time.deltaTime, Time.deltaTime).normalized * velocity.magnitude;
		}
		if (bankingRootTransform != null)
		{
			Vector3 to = alignmentVector;
			to.y *= 0.3f;
			float num = Mathf.Clamp(Vector3.SignedAngle(velocity.normalized, to, Vector3.up) * bankAngleMult, 0f - maxBankAngle, maxBankAngle);
			Quaternion b = Quaternion.Euler(0f, 0f, 0f - num);
			bankingRootTransform.localRotation = Quaternion.Lerp(bankingRootTransform.localRotation, b, Time.deltaTime * 5f);
		}
	}

	public override void SetTarget(Transform t)
	{
		base.SetTarget(t);
		targetComponent.SetTarget(t);
	}
}
