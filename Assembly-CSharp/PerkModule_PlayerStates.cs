using UnityEngine;

public class PerkModule_PlayerStates : PerkModule
{
	public enum PlayerState
	{
		normal = 0,
		grounded = 1,
		notGrounded = 2,
		sprinting = 3,
		fullSprint = 4,
		crouching = 5,
		healthPercent = 6,
		staminaPercent = 7
	}

	public PlayerState playerState;

	public BuffContainer buff;

	public float buffMultiplier = 1f;

	public bool useCurve;

	public AnimationCurve curve;

	public float buffChangeRate = 10f;

	private float curBuffAmount;

	public float buffRaiseRateMult = 1f;

	public float buffLowerRateMult = 1f;

	public float persistTime;

	public float buildPersistTime;

	private float persistTimer;

	private float buildPersistTimer;

	public bool decreaseLossRateWithStack;

	private BuffContainer currentBuff;

	public bool useHandEffectModule;

	[SerializeReference]
	public PerkModule_HandEffect handEffectModule;

	public bool useFullyChargeHandEffectModule;

	public ParticleSystem fullyChargedParticle;

	private ParticleSystem instantiatedParticle;

	public AudioClip buffMaxSound;

	public float buffMaxSoundVolume = 0.5f;

	private float lastSoundTime;

	private bool isFullyCharged;

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
		currentBuff.SetMultiplier(1f * buffMultiplier);
		if (useHandEffectModule)
		{
			handEffectModule.Initialize(p, firstTime);
		}
		if (fullyChargedParticle != null && instantiatedParticle == null)
		{
			instantiatedParticle = Object.Instantiate(fullyChargedParticle);
		}
	}

	public override void Update()
	{
		base.Update();
		float num = 0f;
		if (useHandEffectModule)
		{
			handEffectModule.Update();
		}
		switch (playerState)
		{
		case PlayerState.normal:
			num = ((!ENT_Player.GetPlayer().IsCrouching() && !ENT_Player.GetPlayer().IsGrounded() && !ENT_Player.GetPlayer().IsSprinting()) ? 1f : 0f);
			break;
		case PlayerState.grounded:
			num = ((!ENT_Player.GetPlayer().IsGrounded()) ? 0f : 1f);
			break;
		case PlayerState.notGrounded:
			num = ((!ENT_Player.GetPlayer().IsGrounded()) ? 1f : 0f);
			break;
		case PlayerState.crouching:
			num = ((!ENT_Player.GetPlayer().IsCrouching()) ? 0f : 1f);
			break;
		case PlayerState.sprinting:
			num = ((!ENT_Player.GetPlayer().IsSprinting()) ? 0f : 1f);
			break;
		case PlayerState.fullSprint:
			num = ((!ENT_Player.GetPlayer().IsInFullSprint() || ENT_Player.GetPlayer().IsHanging()) ? 0f : 1f);
			break;
		case PlayerState.healthPercent:
			num = ENT_Player.GetPlayer().health / ENT_Player.GetPlayer().maxHealth;
			break;
		case PlayerState.staminaPercent:
		{
			num = ENT_Player.GetPlayer().GetLowestGripStrength(out var handID) / ENT_Player.GetPlayer().GetCurrentGripStrengthTimer(handID);
			break;
		}
		}
		if (curBuffAmount < num)
		{
			curBuffAmount = Mathf.Lerp(curBuffAmount, num, buffChangeRate * Time.deltaTime * buffRaiseRateMult);
			if (curBuffAmount >= 0.95f && num == 1f && !isFullyCharged)
			{
				isFullyCharged = true;
				if (Time.time - lastSoundTime > 2f)
				{
					lastSoundTime = Time.time;
					if (buffMaxSound != null)
					{
						AudioManager.PlaySound(buffMaxSound, perk.player.transform, buffMaxSoundVolume);
					}
					if (instantiatedParticle != null)
					{
						instantiatedParticle.Play();
					}
				}
			}
			persistTimer = Mathf.Max(persistTimer, buildPersistTime);
		}
		else if (persistTimer <= 0f)
		{
			curBuffAmount = Mathf.Lerp(curBuffAmount, num, buffChangeRate * Time.deltaTime * (buffLowerRateMult / (decreaseLossRateWithStack ? perk.GetStackEvaluationMultiplier() : 1f)));
			if (curBuffAmount < 0.95f && num == 0f && isFullyCharged)
			{
				isFullyCharged = false;
			}
		}
		if (instantiatedParticle != null)
		{
			instantiatedParticle.transform.position = perk.player.transform.position;
		}
		if (persistTime > 0f || buildPersistTime > 0f)
		{
			if (curBuffAmount >= 0.95f && num == 1f)
			{
				persistTimer = persistTime;
			}
			else
			{
				persistTimer -= Time.deltaTime;
			}
		}
		float num2 = curBuffAmount;
		if (useCurve)
		{
			num2 = curve.Evaluate(curBuffAmount);
		}
		if (useHandEffectModule)
		{
			if (num2 > 0.5f)
			{
				handEffectModule.active = true;
			}
			else
			{
				handEffectModule.active = false;
			}
		}
		currentBuff.SetMultiplier(num2 * buffMultiplier * (float)perk.GetStackAmount());
	}

	public override void OnDestroy(Perk p)
	{
		p.player.curBuffs.RemoveBuffContainer(buff.id);
		if (useHandEffectModule)
		{
			handEffectModule.OnDestroy(p);
		}
		if (instantiatedParticle != null)
		{
			Object.Destroy(instantiatedParticle.gameObject);
		}
		base.OnDestroy(p);
	}
}
