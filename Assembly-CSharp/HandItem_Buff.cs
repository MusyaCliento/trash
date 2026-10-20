using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandItem_Buff : HandItem
{
	public BuffContainer buff;

	public bool useSecondaryBuffs;

	public List<BuffContainer> secondaryBuffs;

	public float healAmount;

	public AudioClip audioClip;

	public float audioVolume;

	public UnityEvent useEvent;

	public UnityEvent applyBuffEvent;

	public string onEatType = "consumeable";

	public override void OnEnable()
	{
		used = false;
	}

	public override void Use()
	{
		base.Use();
		if (!used)
		{
			StartBuff();
		}
	}

	public virtual void StartBuff()
	{
		foreach (SimpleModule simpleUseModule in simpleUseModules)
		{
			simpleUseModule.Activate();
		}
		used = true;
		anim.SetTrigger("Use");
		CL_CameraControl.Shake(0.015f);
		if (!string.IsNullOrEmpty(onEatType))
		{
			hand.GetPlayer().OnEat(onEatType);
		}
		if (audioClip != null)
		{
			AudioManager.PlaySound(audioClip, hand.GetPlayer().transform, audioVolume, 1f, 0f);
		}
		useEvent.Invoke();
	}

	public override void Activate()
	{
		CL_CameraControl.Shake(0.115f);
		buff.Initialize();
		CL_GameManager.gMan.localPlayer.Buff(buff);
		if (useSecondaryBuffs)
		{
			foreach (BuffContainer secondaryBuff in secondaryBuffs)
			{
				secondaryBuff.Initialize();
				CL_GameManager.gMan.localPlayer.Buff(secondaryBuff);
			}
		}
		applyBuffEvent.Invoke();
		hand.GetPlayer().Heal(healAmount);
		UpdateStats();
	}

	public override bool CanDrop(bool pocket = false)
	{
		return !used;
	}
}
