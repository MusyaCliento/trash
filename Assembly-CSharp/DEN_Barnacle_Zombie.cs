using UnityEngine;

public class DEN_Barnacle_Zombie : DEN_BasicDenizen
{
	public DEN_Barnacle barnacle;

	private Vector3 lastEntityPosition;

	private float trackedVelocity;

	public float animationWalkVelocityMult = 1f;

	public string footstepSoundID = "zombie:step";

	public new float footstepSoundVelocityThreshold = 0.1f;

	private float timeToAttack;

	public override void Update()
	{
		base.Update();
		if (dead)
		{
			return;
		}
		if (movementModule.GetType() == typeof(DenizenMovement_SimpleWalker))
		{
			if (barnacle.tongueInterface.HasLatched())
			{
				(movementModule as DenizenMovement_SimpleWalker).forceLookBlend = Mathf.Lerp((movementModule as DenizenMovement_SimpleWalker).forceLookBlend, 1f, Time.deltaTime * 3f);
			}
			else
			{
				(movementModule as DenizenMovement_SimpleWalker).forceLookBlend = Mathf.Lerp((movementModule as DenizenMovement_SimpleWalker).forceLookBlend, 0f, Time.deltaTime * 3f);
			}
			if (animator != null)
			{
				animator.SetFloat("Walking", (movementModule as DenizenMovement_SimpleWalker).GetSmoothedVelocity() * animationWalkVelocityMult);
			}
			if (CL_UIManager.debug)
			{
				CL_DebugView.draw.Arrow(base.transform.position, base.transform.position + (movementModule as DenizenMovement_SimpleWalker).lookDirection * 2f);
				CL_DebugView.draw.Label2D(base.transform.position + Vector3.up, "State:" + currentState.name, Color.yellow);
			}
		}
		if (targetComponent.HasTarget())
		{
			target = targetComponent.target.targetTransform;
			if (Vector3.Angle(targetComponent.target.targetTransform.position - base.transform.position, base.transform.forward) < 70f)
			{
				timeToAttack += Time.deltaTime;
			}
			else
			{
				timeToAttack = 0f;
			}
		}
		else
		{
			target = null;
		}
	}

	public override void AnimationUpdate()
	{
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		lastEntityPosition = base.transform.position;
		trackedVelocity = (base.transform.position - lastEntityPosition).magnitude / Time.fixedDeltaTime;
	}

	internal override void AttackCheck()
	{
		if (!(timeToAttack < 0.5f))
		{
			base.AttackCheck();
		}
	}

	public override void Kill(string type = "", Damageable.DamageInfo damageInfo = null)
	{
		if (!dead)
		{
			barnacle.Kill("", null);
			base.Kill(type, damageInfo);
		}
	}

	public new void PlayFootstepSound()
	{
		if (dead)
		{
			return;
		}
		if (movementModule.GetType() == typeof(DenizenMovement_SimpleWalker))
		{
			if ((movementModule as DenizenMovement_SimpleWalker).GetSmoothedVelocity() > footstepSoundVelocityThreshold)
			{
				clipHandler.PlaySound(footstepSoundID);
			}
		}
		else
		{
			clipHandler.PlaySound(footstepSoundID);
		}
	}

	public override DenizenMovementModule GetMovementModule()
	{
		return movementModule;
	}
}
