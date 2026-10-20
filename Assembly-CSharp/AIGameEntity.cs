using System;
using System.Collections.Generic;
using DarkMachine.AI;
using UnityEngine;

public class AIGameEntity : GameEntity
{
	public interface Grappler
	{
		[Serializable]
		public class GrappleInfo
		{
			public bool forcePlayerCrouched;

			public bool forcePlayerGrounded;

			public float playerGrappleSpeedMod = 1f;

			public bool forceLeaveGrounded;

			public float frictionMultiplier = 1f;

			public float airbornFrictionMultiplier = 1f;

			public float gravityMultiplier = 1f;
		}

		GrappleInfo GetGrappleInfo();

		void ReleaseGrapple();
	}

	internal List<AIStateComponent> aiStates = new List<AIStateComponent>();

	public Transform target;

	public AIStateVariable[] stateVariables;

	public AISightComponent sight;

	public bool disableAI;

	public UT_AudioClipHandler clipHandler;

	public bool reparentBetweenLevels = true;

	internal AIStateComponent currentState;

	internal Vector3 targetPosition;

	internal Vector3 lookVector;

	internal Action<string> _OnChangeState;

	private int overrideLookVectorFrame;

	private Vector3 overrideLookVector;

	private int overrideTargetPositionFrame;

	private Vector3 overrideOverrideTargetPosition;

	private Transform underLevel;

	public virtual void ChangeState(string state)
	{
		foreach (AIStateComponent aiState in aiStates)
		{
			if (state == aiState.name && aiState.CanEnterState())
			{
				if (currentState != null)
				{
					currentState.Exit(this);
				}
				currentState = aiState;
				aiState.Enter(this);
				_OnChangeState?.Invoke(state);
				break;
			}
		}
	}

	public virtual AIStateComponent GetState(string state)
	{
		foreach (AIStateComponent aiState in aiStates)
		{
			if (state == aiState.name)
			{
				return aiState;
			}
		}
		return null;
	}

	public virtual Vector3 GetTargetPosition()
	{
		if (overrideTargetPositionFrame >= Time.frameCount)
		{
			return overrideOverrideTargetPosition;
		}
		return targetPosition;
	}

	public virtual void SetTargetPosition(Vector3 position)
	{
		targetPosition = position;
	}

	public virtual void SetNavigationTargetPosition(Vector3 position)
	{
		targetPosition = position;
	}

	public virtual Vector3 GetLookVector()
	{
		if (overrideLookVectorFrame >= Time.frameCount)
		{
			return overrideLookVector;
		}
		if (currentState != null)
		{
			return currentState.GetLookVector();
		}
		return base.transform.forward;
	}

	public virtual void SetOverrideLookVector(Vector3 vec)
	{
		overrideLookVector = vec;
		overrideLookVectorFrame = Time.frameCount + 1;
	}

	public virtual void SetOverrideTargetPosition(Vector3 position)
	{
		overrideOverrideTargetPosition = position;
		overrideTargetPositionFrame = Time.frameCount + 1;
	}

	public virtual GameEntity GetTargetEntity()
	{
		if (target != null)
		{
			return target.GetComponent<GameEntity>();
		}
		return null;
	}

	public virtual void SetTarget(Transform entity)
	{
		if (entity != null)
		{
			target = entity;
		}
		else
		{
			target = null;
		}
	}

	public virtual AIStateComponent GetCurrentState()
	{
		return currentState;
	}

	public override void Start()
	{
		base.Start();
		UpdateUnderLevel(isAlreadyParented: true);
	}

	public override void TickUpdate()
	{
		base.TickUpdate();
		UpdateUnderLevel(isAlreadyParented: false);
	}

	private void UpdateUnderLevel(bool isAlreadyParented)
	{
		if (reparentBetweenLevels && !(WorldLoader.instance == null) && WorldLoader.instance.IsWorldActive())
		{
			WorldLoader.LevelInfo closestLevelToPosition = WorldLoader.GetClosestLevelToPosition(base.transform.position);
			Transform transform = null;
			if (closestLevelToPosition != null)
			{
				transform = closestLevelToPosition.GetLevel().GetParentRoot();
			}
			if (transform != underLevel && !isAlreadyParented)
			{
				base.transform.parent = transform;
			}
			underLevel = transform;
		}
	}

	public override void OffsetEntity(float amount)
	{
		base.OffsetEntity(amount);
		targetPosition.y += amount;
		foreach (AIStateComponent aiState in aiStates)
		{
			aiState.OnOffsetEntity(amount);
		}
	}

	public virtual void SetAnimationTrigger(string triggerID)
	{
	}
}
