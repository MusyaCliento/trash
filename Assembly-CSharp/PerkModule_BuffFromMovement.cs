using System;
using UnityEngine;

public class PerkModule_BuffFromMovement : PerkModule
{
	public string statName;

	public BuffContainer buff;

	public float buffMultiplier = 1f;

	public bool useCurve;

	public int curveMax = 10;

	public AnimationCurve curve = AnimationCurve.Constant(0f, 1f, 1f);

	private BuffContainer currentBuff;

	public bool activateOnClimb = true;

	public float minimumClimbVelocity = 1f;

	public bool resetOnJump;

	public float buffAmount;

	public float buffMax = 10f;

	public float buffIncreaseRate = 1f;

	public float buffDecay;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
		if (buff.id != "")
		{
			currentBuff = perk.player.curBuffs.GetBuffContainer(buff.id);
		}
		if (currentBuff == null)
		{
			perk.player.curBuffs.AddBuff(buff);
			currentBuff = perk.player.curBuffs.GetBuffContainer(buff.id);
		}
		if (resetOnJump)
		{
			ENT_Player player = perk.player;
			player._OnJump = (Action)Delegate.Combine(player._OnJump, new Action(OnJump));
		}
		currentBuff.SetMultiplier(1f * buffMultiplier);
	}

	public override void Update()
	{
		base.Update();
		bool flag = false;
		if (activateOnClimb && perk.player.IsHanging() && perk.player.GetTrueVelocity().magnitude > minimumClimbVelocity)
		{
			flag = true;
			buffAmount += buffIncreaseRate * Time.deltaTime;
		}
		float num = buffAmount;
		currentBuff.SetMultiplier(num * buffMultiplier * (float)perk.GetStackAmount());
		if (!flag)
		{
			buffAmount = Mathf.Clamp(buffAmount - Time.deltaTime * buffDecay, 0f, buffMax);
		}
	}

	public void OnJump()
	{
		if (resetOnJump)
		{
			buffAmount = 0f;
		}
	}

	public override void OnDestroy(Perk p)
	{
		if (perk != null && perk.player != null)
		{
			perk.player.curBuffs.RemoveBuffContainer(buff.id);
			if (resetOnJump)
			{
				ENT_Player player = perk.player;
				player._OnJump = (Action)Delegate.Remove(player._OnJump, new Action(OnJump));
			}
		}
		base.OnDestroy(p);
	}
}
