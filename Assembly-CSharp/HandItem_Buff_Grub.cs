using UnityEngine;
using UnityEngine.Events;

public class HandItem_Buff_Grub : HandItem_Buff
{
	public BuffContainer grubPetBuff;

	public AudioClip petClip;

	public AudioClip petFinishClip;

	public UnityEvent petEvent;

	public UnityEvent applyPetBuffEvent;

	private bool petting;

	public override void StartBuff()
	{
		if (Time.time - DEN_Mother.motherGiveTime < 5f)
		{
			return;
		}
		if (!CanPet())
		{
			base.StartBuff();
		}
		else
		{
			if (!hand.GetOtherHand().IsFree())
			{
				return;
			}
			foreach (SimpleModule simpleUseModule in simpleUseModules)
			{
				simpleUseModule.Activate();
			}
			used = true;
			anim.SetTrigger("Pet");
			CL_CameraControl.Shake(0.015f);
			if (petClip != null)
			{
				AudioManager.PlaySound(petClip, hand.GetPlayer().transform, audioVolume, 1f, 0f);
			}
			petEvent.Invoke();
		}
	}

	public override void Update()
	{
		base.Update();
		if (CanPet() && used && !hand.GetOtherHand().IsFree())
		{
			anim.SetTrigger("Stop");
			used = false;
		}
	}

	public bool CanPet()
	{
		if (ENT_Player.GetPlayer().HasPerk("Perk_MotherlyInstinct"))
		{
			return true;
		}
		return false;
	}

	public override void Activate()
	{
		if (!CanPet())
		{
			base.Activate();
			if (DEN_Mother.instance != null && Vector3.Distance(base.transform.position, DEN_Mother.instance.transform.position) < 50f)
			{
				DEN_Mother.instance.Enrage();
			}
		}
		else if (used)
		{
			used = false;
			Perk perk = ENT_Player.GetPlayer().GetPerk("Perk_MotherlyInstinct");
			if (perk != null)
			{
				grubPetBuff.multiplier = perk.GetStackAmount();
			}
			else
			{
				grubPetBuff.multiplier = 1f;
			}
			grubPetBuff.Initialize();
			CL_GameManager.gMan.localPlayer.Buff(grubPetBuff);
			if (petFinishClip != null)
			{
				AudioManager.PlaySound(petFinishClip, hand.GetPlayer().transform, audioVolume, 1f, 0f);
			}
			applyPetBuffEvent.Invoke();
		}
	}
}
