using System;
using UnityEngine;

[Serializable]
public class ItemExecutionModule_RechargeAmount : ItemExecutionModule
{
	public float maxCharge = 50f;

	public float rechargeRate = 1f;

	private float rechargeTime;

	public string chargeStringName = "charge";

	public bool playAudioOnRecharge;

	public AudioClip rechargeAudio;

	public bool charging = true;

	public bool chargeWhenInHand = true;

	public override void Execute()
	{
		base.Execute();
		if (charging && item != null && (!chargeWhenInHand || item.InHand()))
		{
			float result = 0f;
			float.TryParse(item.GetFirstDataStringByType(chargeStringName), out result);
			if (ENT_Player.GetPlayer().HasInfiniteCharge())
			{
				result = maxCharge;
			}
			result = Mathf.Clamp(result + Time.deltaTime * rechargeRate, 0f, maxCharge);
			item.SetFirstDataStringsofType(chargeStringName, result.ToString());
		}
	}

	public override ItemExecutionModule GetCopy()
	{
		return new ItemExecutionModule_RechargeAmount
		{
			rechargeAudio = rechargeAudio,
			rechargeRate = rechargeRate,
			maxCharge = maxCharge,
			playAudioOnRecharge = playAudioOnRecharge,
			charging = charging,
			chargeWhenInHand = chargeWhenInHand,
			chargeStringName = chargeStringName
		};
	}
}
