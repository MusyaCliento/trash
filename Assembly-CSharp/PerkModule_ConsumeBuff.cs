using System;
using System.Collections.Generic;
using UnityEngine;

public class PerkModule_ConsumeBuff : PerkModule
{
	public List<string> consumeBuffIDs = new List<string> { "food" };

	public int addExtraJumpOnConsume;

	public AudioClip consumeAudio;

	public float audioVolume = 0.5f;

	public bool canStack = true;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
		ENT_Player player = ENT_Player.GetPlayer();
		player._OnEat = (Action<string>)Delegate.Combine(player._OnEat, new Action<string>(OnConsume));
	}

	public override void Update()
	{
	}

	public override void OnDestroy(Perk p)
	{
		base.OnDestroy(p);
		if (ENT_Player.GetPlayer() != null)
		{
			ENT_Player player = ENT_Player.GetPlayer();
			player._OnEat = (Action<string>)Delegate.Remove(player._OnEat, new Action<string>(OnConsume));
		}
	}

	public void OnConsume(string type)
	{
		if (consumeBuffIDs.Contains(type))
		{
			int num = addExtraJumpOnConsume;
			if (canStack)
			{
				num *= perk.stackAmount;
			}
			ENT_Player.GetPlayer().AddExtraJumpsOneTime(num);
			AudioManager.PlaySound(consumeAudio, ENT_Player.GetPlayer().transform.position, audioVolume, 1f, 0.5f);
		}
	}
}
