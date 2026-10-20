using UnityEngine;

public class PerkModule_FallBuff : PerkModule
{
	public BuffContainer buff;

	public float buffMultiplier = 1f;

	public float fallMin = 10f;

	public float fallMax = 10f;

	private float curBuffMultiplier;

	private BuffContainer currentBuff;

	private bool isPlayerGrounded;

	public float buffDecayRate = 1f;

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
		curBuffMultiplier = 0f;
		currentBuff.SetMultiplier(1f * curBuffMultiplier);
	}

	public override void Update()
	{
		base.Update();
		isPlayerGrounded = perk.player.IsGrounded();
		float num = Mathf.Max(curBuffMultiplier, Mathf.Max(perk.player.GetCurrentFallDistance() - fallMin, 0f) / (fallMax - fallMin));
		curBuffMultiplier = num;
		currentBuff.SetMultiplier(buffMultiplier * curBuffMultiplier * (float)perk.GetStackAmount());
		curBuffMultiplier = Mathf.Max(0f, curBuffMultiplier - Time.deltaTime * buffDecayRate);
	}

	public override void OnDestroy(Perk p)
	{
		perk.player.curBuffs.RemoveBuffContainer(buff.id);
		base.OnDestroy(p);
	}
}
