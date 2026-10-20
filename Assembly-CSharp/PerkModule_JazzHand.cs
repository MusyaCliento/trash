using UnityEngine;

public class PerkModule_JazzHand : PerkModule
{
	public float restoreGrip;

	public bool useBuff;

	public BuffContainer buff;

	private BuffContainer currentBuff;

	public float clickRate = 0.3f;

	private float currentMultiplier;

	public float buffMaxMultiplier = 1f;

	public float buffMultiplierIncreaseAmount = 0.1f;

	public float buffDecayRate = 1f;

	public float jazzVolume = 0.1f;

	public AudioClip[] consumeAudio;

	private float[] lastOpenTime;

	public AnimationCurve pitchCurve;

	public bool requireGrounded;

	public float activationThreshold;

	public float activationRate = 1f;

	private float curActivation;

	public override void Initialize(Perk p, bool firstTime)
	{
		base.Initialize(p, firstTime);
		if (useBuff)
		{
			if (buff.id != "")
			{
				currentBuff = perk.player.curBuffs.GetBuffContainer(buff.id);
			}
			if (currentBuff == null)
			{
				perk.player.curBuffs.AddBuff(buff);
				currentBuff = perk.player.curBuffs.GetBuffContainer(buff.id);
			}
			currentBuff.SetMultiplier(0f);
		}
		lastOpenTime = new float[2];
	}

	public override void Update()
	{
		base.Update();
		if (!requireGrounded || perk.player.IsGrounded())
		{
			ENT_Player.Hand[] hands = perk.player.hands;
			foreach (ENT_Player.Hand hand in hands)
			{
				if (!hand.IsFree() || !InputManager.GetButton(hand.fireButton).Down)
				{
					continue;
				}
				if (Time.time - lastOpenTime[hand.id] < clickRate)
				{
					if (restoreGrip > 0f)
					{
						hand.AddGripStrength(restoreGrip);
					}
					else if (restoreGrip < 0f)
					{
						hand.DamageGripStrength(0f - restoreGrip);
					}
					curActivation = Mathf.Clamp(curActivation + activationRate, 0f, activationThreshold);
					if (curActivation >= activationThreshold)
					{
						currentMultiplier += buffMultiplierIncreaseAmount;
						if (consumeAudio != null)
						{
							AudioManager.PlaySound(consumeAudio[Random.Range(0, consumeAudio.Length)], perk.player.transform.position, jazzVolume, pitchCurve.Evaluate(currentMultiplier / buffMaxMultiplier), 0.3f);
						}
					}
				}
				lastOpenTime[hand.id] = Time.time;
			}
		}
		if (useBuff)
		{
			currentBuff.SetMultiplier(currentMultiplier);
			currentMultiplier = Mathf.Clamp(currentMultiplier - Time.deltaTime * buffDecayRate, 0f, buffMaxMultiplier);
			curActivation = Mathf.Clamp(curActivation - Time.deltaTime, 0f, activationThreshold);
		}
	}
}
