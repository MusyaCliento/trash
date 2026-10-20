using System.Collections.Generic;
using UnityEngine;

public class HandholdModule_PerkModifier : HandholdModule
{
	public string perkId;

	[Header("Overrides")]
	public float climbMult = 1f;

	public float strainRate = 1f;

	public float jumpStrainMult = 1f;

	public float speedMult = 1f;

	[SerializeReference]
	public List<HandholdModule> submodules;

	public override void OnGrab(ENT_Player p, ENT_Player.Hand hand, Clickable.InteractionInfo info = null)
	{
		base.OnGrab(p, hand, info);
		if (!enabled)
		{
			return;
		}
		if (p.HasPerk(perkId) && handhold != null)
		{
			handhold.climbMult = climbMult;
			handhold.strainRate = strainRate;
			handhold.jumpStrainMult = jumpStrainMult;
			handhold.speedMult = speedMult;
		}
		if (!p.HasPerk(perkId) || submodules == null || submodules.Count <= 0)
		{
			return;
		}
		foreach (HandholdModule submodule in submodules)
		{
			submodule.OnGrab(p, hand, info);
		}
	}

	public override void Initialize(CL_Handhold h)
	{
		base.Initialize(h);
		if (submodules == null || submodules.Count <= 0)
		{
			return;
		}
		foreach (HandholdModule submodule in submodules)
		{
			submodule.Initialize(h);
		}
	}

	public override void OnRelease(ENT_Player p, ENT_Player.Hand hand)
	{
		base.OnRelease(p, hand);
		if (!p.HasPerk(perkId) || submodules == null || submodules.Count <= 0)
		{
			return;
		}
		foreach (HandholdModule submodule in submodules)
		{
			submodule.OnRelease(p, hand);
		}
	}

	public override void OnJump(ENT_Player p, ENT_Player.Hand hand, bool hasJumped = false)
	{
		base.OnJump(p, hand, hasJumped);
		if (!p.HasPerk(perkId) || submodules == null || submodules.Count <= 0)
		{
			return;
		}
		foreach (HandholdModule submodule in submodules)
		{
			submodule.OnJump(p, hand, hasJumped);
		}
	}

	public override void OnDoubleJump(ENT_Player p, ENT_Player.Hand hand, bool hasJumped = false)
	{
		base.OnDoubleJump(p, hand, hasJumped);
		if (!p.HasPerk(perkId) || submodules == null || submodules.Count <= 0)
		{
			return;
		}
		foreach (HandholdModule submodule in submodules)
		{
			submodule.OnDoubleJump(p, hand, hasJumped);
		}
	}
}
