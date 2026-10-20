using System;
using UnityEngine;

[Serializable]
public class ItemExecutionModule_RechargeUses : ItemExecutionModule
{
	public int maxUses;

	public float timeForEachUse = 5f;

	private float rechargeTime;

	public bool playAudioOnRecharge;

	public string usesDataString = "uses";

	public AudioClip rechargeAudio;

	public string rechargeAudioSubtitle = "";

	public override void Initialize(Item i)
	{
		base.Initialize(i);
		rechargeTime = timeForEachUse;
	}

	public override void Execute()
	{
		base.Execute();
		if (item == null)
		{
			return;
		}
		if (ENT_Player.GetPlayer().HasInfiniteCharge())
		{
			rechargeTime = 0f;
		}
		int result = 0;
		int.TryParse(item.GetFirstDataStringByType(usesDataString), out result);
		if (result < maxUses)
		{
			rechargeTime -= Time.deltaTime;
			if (!(rechargeTime <= 0f))
			{
				return;
			}
			rechargeTime = timeForEachUse;
			result++;
			item.SetFirstDataStringsofType(usesDataString, result.ToString());
			if (playAudioOnRecharge)
			{
				AudioManager.PlaySound(rechargeAudio, item.GetDropObject().transform.position, 0.6f);
				if (rechargeAudioSubtitle != "")
				{
					AudioManager.PlaySubtitle("sound", rechargeAudioSubtitle, item.GetDropObject().transform, isAmbient: true, isGlobal: false);
				}
			}
		}
		else
		{
			rechargeTime = timeForEachUse;
		}
	}

	public override ItemExecutionModule GetCopy()
	{
		return new ItemExecutionModule_RechargeUses
		{
			rechargeAudio = rechargeAudio,
			maxUses = maxUses,
			timeForEachUse = timeForEachUse,
			rechargeTime = rechargeTime,
			playAudioOnRecharge = playAudioOnRecharge,
			usesDataString = usesDataString
		};
	}
}
