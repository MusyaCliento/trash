using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CL_Handhold_Damage : CL_Handhold
{
	public float maxHoldTime;

	public float damage = 1f;

	public string damageType = "handhold-sharp";

	public float handStrainDamage = 1f;

	public float damageRate = 1f;

	private float damageTime;

	public bool dropOnDamage;

	public float dropGripWait = 0.3f;

	public bool useTotalHoldTime;

	public bool drainTotalHoldTime;

	public float handShakeAmount = 0.1f;

	private float holdShakeTimer;

	[Space]
	[Header("Audio")]
	public AudioClip damageSound;

	public UnityEvent damageEvent;

	private Dictionary<ENT_Player.Hand, float> handHoldTime = new Dictionary<ENT_Player.Hand, float>();

	private float totalHoldTime;

	private Quaternion localRotation;

	public override void Start()
	{
		base.Start();
		localRotation = base.transform.localRotation;
	}

	internal override void Update()
	{
		base.Update();
		if (GetHolding())
		{
			if (hands.Count <= 0)
			{
				return;
			}
			damageTime -= Time.deltaTime;
			bool flag = false;
			if (damageTime <= 0f)
			{
				damageTime = damageRate;
				flag = true;
			}
			if (useTotalHoldTime)
			{
				totalHoldTime += Time.deltaTime;
				for (int i = 0; i < hands.Count; i++)
				{
					_ = handHoldTime[hands[i]];
					_ = maxHoldTime;
					handHoldTime[hands[i]] += Time.deltaTime;
				}
				if (totalHoldTime > maxHoldTime)
				{
					for (int j = 0; j < hands.Count; j++)
					{
						hands[j].ShakeHand(handShakeAmount * Time.deltaTime);
					}
					CL_CameraControl.Shake(0.0005f);
					if (flag)
					{
						ENT_Player.playerObject.Damage(Damageable.DamageInfo.CreateDamageInfo(damage, damageType));
						for (int k = 0; k < hands.Count; k++)
						{
							hands[k].AddGripStrength(handStrainDamage);
						}
					}
				}
				if (!(totalHoldTime > maxHoldTime && flag))
				{
					return;
				}
				if (damageSound != null)
				{
					AudioManager.PlaySound(damageSound, hands[0].handModel.position);
				}
				if (dropOnDamage)
				{
					for (int num = hands.Count - 1; num >= 0; num--)
					{
						hands[num].AddHandWait(dropGripWait);
						hands[num].DropHand();
					}
				}
				damageEvent.Invoke();
				return;
			}
			for (int l = 0; l < hands.Count; l++)
			{
				if (!handHoldTime.ContainsKey(hands[l]))
				{
					continue;
				}
				_ = handHoldTime[hands[l]];
				_ = maxHoldTime;
				handHoldTime[hands[l]] += Time.deltaTime;
				if (handHoldTime[hands[l]] > maxHoldTime)
				{
					hands[l].ShakeHand(handShakeAmount * Time.deltaTime);
					CL_CameraControl.Shake(0.0005f);
				}
				if (!(handHoldTime[hands[l]] > maxHoldTime && flag))
				{
					continue;
				}
				if (damageSound != null)
				{
					AudioManager.PlaySound(damageSound, hands[0].handModel.position);
				}
				if (dropOnDamage)
				{
					for (int num2 = hands.Count - 1; num2 >= 0; num2--)
					{
						hands[num2].AddHandWait(dropGripWait);
						hands[num2].DropHand();
					}
				}
				damageEvent.Invoke();
				if (flag)
				{
					ENT_Player.playerObject.Damage(Damageable.DamageInfo.CreateDamageInfo(damage, "handhold"));
					for (int m = 0; m < hands.Count; m++)
					{
						hands[l].AddGripStrength(handStrainDamage);
					}
				}
				break;
			}
		}
		else if (useTotalHoldTime && drainTotalHoldTime)
		{
			totalHoldTime = Mathf.Max(totalHoldTime - Time.deltaTime, 0f);
		}
	}

	public override void Interact(Clickable.InteractionInfo info)
	{
		if (!handHoldTime.ContainsKey(info.hand))
		{
			handHoldTime.Add(info.hand, 0f);
		}
		base.Interact(info);
		Vector3 holdPosition = info.hand.GetHoldPosition();
		info.hand.SetHoldPosition(holdPosition);
	}

	public override void StopInteract(ENT_Player p, ENT_Player.Hand dropHand, string s = "")
	{
		if (handHoldTime.ContainsKey(dropHand))
		{
			handHoldTime.Remove(dropHand);
		}
		base.StopInteract(p, dropHand, s);
	}
}
