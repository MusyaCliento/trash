using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandholdModule_Damage : HandholdModule
{
	public float maxHoldTime;

	public float damage = 1f;

	public string damageType = "handhold-sharp";

	public List<string> damageTags = new List<string> { "handhold" };

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

	public override void Update()
	{
		base.Update();
		if (handhold.GetHolding())
		{
			if (handhold.hands.Count <= 0)
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
				for (int i = 0; i < handhold.hands.Count; i++)
				{
					_ = handHoldTime[handhold.hands[i]];
					_ = maxHoldTime;
					handHoldTime[handhold.hands[i]] += Time.deltaTime;
				}
				if (totalHoldTime > maxHoldTime)
				{
					for (int j = 0; j < handhold.hands.Count; j++)
					{
						handhold.hands[j].ShakeHand(handShakeAmount * Time.deltaTime);
					}
					CL_CameraControl.Shake(0.0005f);
					if (flag)
					{
						ENT_Player.playerObject.Damage(Damageable.DamageInfo.CreateDamageInfo(damage, damageType, damageTags));
						for (int k = 0; k < handhold.hands.Count; k++)
						{
							handhold.hands[k].DamageGripStrength(handStrainDamage);
						}
					}
				}
				if (!(totalHoldTime > maxHoldTime && flag))
				{
					return;
				}
				if (damageSound != null)
				{
					AudioManager.PlaySound(damageSound, handhold.hands[0].handModel.position);
				}
				if (dropOnDamage)
				{
					for (int num = handhold.hands.Count - 1; num >= 0; num--)
					{
						handhold.hands[num].AddHandWait(dropGripWait);
						handhold.hands[num].DropHand();
					}
					damageTime = maxHoldTime;
				}
				damageEvent.Invoke();
				return;
			}
			for (int l = 0; l < handhold.hands.Count; l++)
			{
				if (!handHoldTime.ContainsKey(handhold.hands[l]))
				{
					continue;
				}
				_ = handHoldTime[handhold.hands[l]];
				_ = maxHoldTime;
				handHoldTime[handhold.hands[l]] += Time.deltaTime;
				if (handHoldTime[handhold.hands[l]] > maxHoldTime)
				{
					handhold.hands[l].ShakeHand(handShakeAmount * Time.deltaTime);
					CL_CameraControl.Shake(0.0005f);
				}
				if (!(handHoldTime[handhold.hands[l]] > maxHoldTime && flag))
				{
					continue;
				}
				if (damageSound != null)
				{
					AudioManager.PlaySound(damageSound, handhold.hands[0].handModel.position);
				}
				if (dropOnDamage)
				{
					for (int num2 = handhold.hands.Count - 1; num2 >= 0; num2--)
					{
						handhold.hands[num2].AddHandWait(dropGripWait);
						handhold.hands[num2].DropHand();
					}
					damageTime = maxHoldTime;
				}
				damageEvent.Invoke();
				if (flag)
				{
					ENT_Player.playerObject.Damage(Damageable.DamageInfo.CreateDamageInfo(damage, damageType, damageTags));
					for (int m = 0; m < handhold.hands.Count; m++)
					{
						handhold.hands[m].DamageGripStrength(handStrainDamage);
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

	public override void OnGrab(ENT_Player p, ENT_Player.Hand hand, Clickable.InteractionInfo info = null)
	{
		if (!handHoldTime.ContainsKey(info.hand))
		{
			handHoldTime.Add(info.hand, 0f);
		}
		base.OnGrab(p, hand, info);
		Vector3 holdPosition = info.hand.GetHoldPosition();
		info.hand.SetHoldPosition(holdPosition);
	}

	public override void OnRelease(ENT_Player p, ENT_Player.Hand hand)
	{
		base.OnRelease(p, hand);
		if (handHoldTime.ContainsKey(hand))
		{
			handHoldTime.Remove(hand);
		}
		base.OnRelease(p, hand);
	}
}
