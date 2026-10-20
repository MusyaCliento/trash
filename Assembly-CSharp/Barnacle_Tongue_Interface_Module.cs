using System;
using UnityEngine;

[Serializable]
public class Barnacle_Tongue_Interface_Module
{
	private DEN_Barnacle barnacle;

	public virtual void Initialize(DEN_Barnacle b)
	{
		barnacle = b;
	}

	public virtual void Update()
	{
	}

	public virtual void Kill()
	{
	}

	public virtual void HurtHeld()
	{
	}

	public virtual bool IsPulling()
	{
		return false;
	}

	public virtual void ReleaseGrapple()
	{
	}

	public virtual void OffsetEntity(float amount)
	{
	}

	public virtual void ReachTongues(Transform target)
	{
	}

	public virtual bool HasLatched()
	{
		return false;
	}

	public virtual Vector3 GetTongueDirection()
	{
		return barnacle.transform.forward;
	}

	public DEN_Barnacle GetBarnacle()
	{
		return barnacle;
	}

	public virtual bool CanHitTarget()
	{
		return false;
	}
}
