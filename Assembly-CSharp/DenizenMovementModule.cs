using System;
using UnityEngine;

[Serializable]
public class DenizenMovementModule
{
	internal GameEntity ent;

	internal Vector3 currentPosition;

	internal Vector3 targetPosition;

	internal Vector3 velocity;

	internal bool canMove = true;

	internal bool canRotate = true;

	public Action _OnJump;

	public Action _OnLand;

	public virtual void Initialize(GameEntity gE)
	{
		ent = gE;
	}

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void FixedUpdate()
	{
	}

	public virtual void Move()
	{
	}

	public virtual void Rotate()
	{
	}

	public virtual Vector3 GetVelocity()
	{
		return velocity;
	}

	public virtual void SetVelocity(Vector3 v)
	{
		velocity = v;
	}

	public virtual void OnCollisionEnter(Collision collision)
	{
	}

	public virtual void OnCollisionStay(Collision collision)
	{
	}

	public virtual void OnCollisionExit(Collision collision)
	{
	}

	public virtual bool IsWalking()
	{
		return false;
	}

	public virtual bool GroundedCheck()
	{
		return false;
	}

	public virtual bool IsGrounded()
	{
		return true;
	}

	public virtual void Jump(float mult = 1f, float leap = 0f)
	{
	}

	public virtual void AddForce(Vector3 f)
	{
	}

	public virtual void SetTargetPosition(Vector3 pos)
	{
		targetPosition = pos;
	}

	public virtual void SetLookVector(Vector3 v)
	{
	}

	public virtual void SetSpeedMult(float mult)
	{
	}

	public virtual float GetSpeedMult()
	{
		return 1f;
	}
}
