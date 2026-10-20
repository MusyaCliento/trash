using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Barnacle_Tongue_Interface_Module_Basic : Barnacle_Tongue_Interface_Module
{
	public LayerMask hitMask;

	public LayerMask playerMask;

	public List<Barnacle_Tongue_Basic> tongues;

	public float tongueScatter = 0.1f;

	public float scanDistance = 5f;

	public float tongueGravity = 1f;

	public float tongueSpeed = 1f;

	public float tongueRetractSpeed = 1f;

	public float tongueRetractTime = 5f;

	public float tongueAimTime = 1f;

	public float tongueReachTimeMin = 10f;

	public float tongueReachTimeMax = 40f;

	public float tongueWiggle = 0.1f;

	public float pullStrength = 0.1f;

	public float tongueReelTime = 0.1f;

	public float tongueReelIncreaseRate = 1f;

	public bool lookAtAim;

	public Transform aimRoot;

	public bool aimForwardIsUp;

	private Quaternion aimStartRotation;

	public override void Initialize(DEN_Barnacle b)
	{
		base.Initialize(b);
		foreach (Barnacle_Tongue_Basic tongue in tongues)
		{
			tongue.Initialize(this);
		}
		if (aimRoot != null)
		{
			aimStartRotation = aimRoot.rotation;
		}
	}

	public override void Update()
	{
		base.Update();
		foreach (Barnacle_Tongue_Basic tongue in tongues)
		{
			tongue.Update();
		}
		if (!lookAtAim)
		{
			return;
		}
		if (tongues[0].IsAiming())
		{
			if (aimForwardIsUp)
			{
				aimRoot.transform.rotation = Quaternion.Lerp(aimRoot.transform.rotation, Quaternion.LookRotation(aimRoot.parent.forward, tongues[0].GetAimTarget() - aimRoot.position), Time.deltaTime);
			}
			else
			{
				aimRoot.transform.rotation = Quaternion.Lerp(aimRoot.transform.rotation, Quaternion.LookRotation(tongues[0].GetAimTarget() - aimRoot.position, GetBarnacle().transform.up), Time.deltaTime);
			}
		}
		else
		{
			aimRoot.transform.rotation = Quaternion.Lerp(aimRoot.transform.rotation, aimStartRotation, Time.deltaTime);
		}
	}

	public override void Kill()
	{
		foreach (Barnacle_Tongue_Basic tongue in tongues)
		{
			tongue.BarnacleDie();
		}
		base.Kill();
	}

	public override void ReleaseGrapple()
	{
		foreach (Barnacle_Tongue_Basic tongue in tongues)
		{
			tongue.KillTongue();
		}
		base.ReleaseGrapple();
	}

	public override bool IsPulling()
	{
		foreach (Barnacle_Tongue_Basic tongue in tongues)
		{
			if (tongue.GetState() == Barnacle_Tongue_Core.TongueState.grabbing)
			{
				return true;
			}
		}
		return false;
	}

	public override void OffsetEntity(float amount)
	{
		foreach (Barnacle_Tongue_Basic tongue in tongues)
		{
			tongue.OffsetTargetPoint(Vector3.up * amount);
		}
	}

	public override void HurtHeld()
	{
		base.HurtHeld();
		if (GetBarnacle() == null)
		{
			return;
		}
		foreach (Barnacle_Tongue_Basic tongue in tongues)
		{
			if (tongue.GetGrabbed() == null)
			{
				break;
			}
			if (tongue.GetGrabbed() == GetBarnacle())
			{
				tongue.Retract();
				break;
			}
			if (!tongue.CanBite())
			{
				continue;
			}
			ObjectTagger tagger = tongue.GetGrabbed().GetTagger();
			if ((GetBarnacle().vomitTags != null && tagger != null && tagger.HasTagInList(GetBarnacle().vomitTags.ToArray())) || tongue.GetGrabbed().maxHealth == 0f)
			{
				tongue.Retract();
				GetBarnacle().Vomit();
				break;
			}
			if (tongue.GetGrabbed() != null)
			{
				Damageable.DamageInfo damageInfo = Damageable.DamageInfo.CreateDamageInfo(GetBarnacle().damage, "barnacle");
				damageInfo.sourceEntity = GetBarnacle();
				damageInfo.position = GetBarnacle().transform.position;
				if (tongue.GetGrabbed().Damage(damageInfo))
				{
					GetBarnacle().SetHasVomited(b: false);
				}
			}
			else
			{
				tongue.Retract();
			}
			GetBarnacle().eating = true;
			break;
		}
	}

	public override void ReachTongues(Transform target)
	{
		base.ReachTongues(target);
		foreach (Barnacle_Tongue_Basic tongue in tongues)
		{
			if (tongue.GetState() != Barnacle_Tongue_Core.TongueState.reaching)
			{
				tongue.ForceExtend();
			}
		}
	}

	public override bool HasLatched()
	{
		foreach (Barnacle_Tongue_Basic tongue in tongues)
		{
			if (tongue.HasLatched())
			{
				return true;
			}
		}
		return false;
	}

	public override Vector3 GetTongueDirection()
	{
		Vector3 zero = Vector3.zero;
		foreach (Barnacle_Tongue_Basic tongue in tongues)
		{
			zero += (tongue.GetReachPosition() - tongue.tongue.position).normalized;
		}
		return zero.normalized;
	}

	public override bool CanHitTarget()
	{
		foreach (Barnacle_Tongue_Basic tongue in tongues)
		{
			if (tongue.HasFoundTarget())
			{
				return true;
			}
		}
		return false;
	}
}
