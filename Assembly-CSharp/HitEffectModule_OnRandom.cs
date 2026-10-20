using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HitEffectModule_OnRandom : HitEffectModule
{
	public SpawnTable.SpawnSettings randomChance;

	public float hittingDeadTargetMult = 1f;

	public string[] tagBlacklist;

	[SerializeReference]
	public List<HitEffectModule> successModules;

	[SerializeReference]
	public List<HitEffectModule> failureModules;

	public override void OnHit(in Desc desc)
	{
		base.OnHit(in desc);
		bool flag = false;
		if (desc.target.TryGetComponent<ObjectTagger>(out var component))
		{
			flag = component.HasTagInList(tagBlacklist);
		}
		float num = 1f;
		if (desc.target.TryGetComponent<GameEntity>(out var component2) && component2.IsDead())
		{
			num *= hittingDeadTargetMult;
		}
		if (!flag && randomChance.RandomCheck(runOnSpawn: true, num))
		{
			foreach (HitEffectModule successModule in successModules)
			{
				successModule.OnHit(in desc);
			}
			return;
		}
		foreach (HitEffectModule failureModule in failureModules)
		{
			failureModule.OnHit(in desc);
		}
	}
}
