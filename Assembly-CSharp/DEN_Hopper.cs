using DarkMachine.AI;
using UnityEngine;

public class DEN_Hopper : DEN_BasicDenizen
{
	public override void Update()
	{
		base.Update();
		if (dead || !active)
		{
			return;
		}
		if (ENT_Player.GetPlayer() != null && target == ENT_Player.playerObject.transform && (ENT_Player.GetPlayer().HasPerk("Perk_PheromoneGlands") || CL_GameManager.HasActiveFlag("pacifyroaches")))
		{
			target = null;
			targetComponent.ClearTarget();
			sight.ClearSight();
		}
		if (currentState is AIC_SimpleCreature_Hunt && target != null)
		{
			if (currentState.name == "hunt")
			{
				if (!(currentState as AIC_SimpleCreature_Hunt).fear && Vector3.Distance(base.transform.position, target.position) < 4f)
				{
					movementModule.SetSpeedMult(1f);
				}
				else
				{
					movementModule.SetSpeedMult(1f);
				}
			}
		}
		else
		{
			movementModule.SetSpeedMult(1f);
		}
	}

	public override bool Damage(Damageable.DamageInfo info)
	{
		if (info.HasTag("hammer"))
		{
			rigid.AddForce(Vector3.up * 5f, ForceMode.VelocityChange);
		}
		return base.Damage(info);
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

	public virtual void StartHopAttack(bool force = false, bool leap = true)
	{
		Vector3.Scale(target.position - base.transform.position, new Vector3(1f, 0.5f, 1f));
		if (attackModule is DenizenAttackModule_Basic)
		{
			(attackModule as DenizenAttackModule_Basic).ForceChargeAttack(leap);
		}
	}
}
