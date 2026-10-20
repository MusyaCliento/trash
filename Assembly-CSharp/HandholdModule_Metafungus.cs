using System.Collections.Generic;
using UnityEngine;

public class HandholdModule_Metafungus : HandholdModule
{
	private static float lastPoisonTime;

	public float poisonMinTime = 4f;

	public float poisonChance = 0.3f;

	public List<AudioClip> poisonSound;

	public GameObject sporePuffAsset;

	public override void OnGrab(ENT_Player p, ENT_Player.Hand hand, Clickable.InteractionInfo info = null)
	{
		if (poisonChance < Random.value && Time.time - lastPoisonTime > poisonMinTime)
		{
			lastPoisonTime = Time.time;
			if (poisonSound.Count > 0)
			{
				AudioManager.PlaySound(poisonSound[Random.Range(0, poisonSound.Count)], hand.GetHoldWorldPosition(), 0.45f);
			}
			BuffContainer buffContainer = new BuffContainer();
			buffContainer.id = "metafungus-poison";
			buffContainer.loseRate = 0.3f;
			buffContainer.buffs = new List<BuffContainer.Buff>();
			buffContainer.buffs.Add(new BuffContainer.Buff
			{
				id = "poisoned",
				maxAmount = 1f
			});
			buffContainer.buffs.Add(new BuffContainer.Buff
			{
				id = "poisonStaminaDamage",
				maxAmount = 2f
			});
			p.curBuffs.AddOrResetBuff(buffContainer);
			Object.Instantiate(sporePuffAsset, hand.GetHoldWorldPosition(), Quaternion.identity, handhold.transform);
			CL_CameraControl.Shake(0.01f);
		}
		base.OnGrab(p, hand, info);
	}

	public override void Update()
	{
		base.Update();
	}
}
