using System;
using UnityEngine;

[Serializable]
public class Barnacle_Tongue_Core
{
	public enum TongueState
	{
		retracting = 0,
		reaching = 1,
		searching = 2,
		grabbing = 3
	}

	[SerializeReference]
	internal Barnacle_Tongue_Interface_Module_Basic barnacleInterface;

	public virtual void Initialize(Barnacle_Tongue_Interface_Module_Basic bI)
	{
		barnacleInterface = bI;
	}

	public virtual void Update()
	{
	}

	public virtual void KillTongue()
	{
	}

	public virtual void BarnacleDie()
	{
	}

	public virtual TongueState GetState()
	{
		return TongueState.retracting;
	}

	public virtual void OffsetTargetPoint(Vector3 o)
	{
	}

	public virtual bool CanBite()
	{
		return false;
	}

	public virtual GameEntity GetGrabbed()
	{
		return null;
	}

	public virtual void Retract()
	{
	}

	public virtual Vector3 GetAimTarget()
	{
		return barnacleInterface.GetBarnacle().transform.position;
	}

	public virtual bool IsAiming()
	{
		return false;
	}
}
