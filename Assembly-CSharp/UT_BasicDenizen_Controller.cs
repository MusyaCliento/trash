using System.Collections.Generic;
using UnityEngine;

public class UT_BasicDenizen_Controller : MonoBehaviour
{
	public List<DEN_BasicDenizen> targetDenizens;

	public bool active = true;

	private float activeUntilTime;

	public bool overrideTargetPosition;

	private void Update()
	{
		if (!active && Time.time > activeUntilTime)
		{
			return;
		}
		foreach (DEN_BasicDenizen targetDenizen in targetDenizens)
		{
			if (overrideTargetPosition)
			{
				if (targetDenizen.attackModule is DenizenAttackModule_Basic)
				{
					(targetDenizen.attackModule as DenizenAttackModule_Basic).SetCustomTargetPositionForNextFrame(base.transform.position);
				}
				targetDenizen.SetTargetPosition(base.transform.position);
				targetDenizen.SetOverrideTargetPosition(base.transform.position);
				targetDenizen.SetOverrideLookVector((base.transform.position - targetDenizen.transform.position).normalized);
			}
		}
	}

	public void ActivateForDuration(float duration)
	{
		activeUntilTime = Mathf.Max(activeUntilTime, Time.time + duration);
	}

	public void Deactivate()
	{
		activeUntilTime = 0f;
		active = false;
	}

	public void Activate()
	{
		activeUntilTime = 0f;
		active = true;
	}

	public void SetActive(bool b)
	{
		if (!b)
		{
			activeUntilTime = 0f;
		}
		active = b;
	}

	public void KillDenizens()
	{
		foreach (DEN_BasicDenizen targetDenizen in targetDenizens)
		{
			targetDenizen.Kill("", null);
		}
	}

	public void DamageDenizens(float amount)
	{
		foreach (DEN_BasicDenizen targetDenizen in targetDenizens)
		{
			targetDenizen.Damage(Damageable.DamageInfo.CreateDamageInfo(amount));
		}
	}

	public void TargetPlayer()
	{
		foreach (DEN_BasicDenizen targetDenizen in targetDenizens)
		{
			targetDenizen.SetTarget(ENT_Player.GetPlayer().transform);
			targetDenizen.targetComponent.SetTarget(ENT_Player.GetPlayer().transform);
		}
	}
}
