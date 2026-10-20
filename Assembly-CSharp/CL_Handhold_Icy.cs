using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CL_Handhold_Icy : CL_Handhold
{
	public float maxHoldTime = 3f;

	public float slipSpeed = 1f;

	public float handShakeHoldTime = 1f;

	public float handShakeAmount = 0.1f;

	[Space]
	[Header("Audio")]
	public AudioClip slipSound;

	public AudioClip shakeStartSound;

	public UnityEvent slipEvent;

	private Dictionary<ENT_Player.Hand, float> handHoldTime = new Dictionary<ENT_Player.Hand, float>();

	internal override void Update()
	{
		base.Update();
		if (!GetHolding() || hands.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < hands.Count; i++)
		{
			if (!handHoldTime.ContainsKey(hands[i]))
			{
				continue;
			}
			bool flag = handHoldTime[hands[i]] > handShakeHoldTime;
			handHoldTime[hands[i]] += Time.deltaTime;
			hands[i].OffsetHoldPosition(Vector3.down * Time.deltaTime * slipSpeed);
			if (handHoldTime[hands[i]] > handShakeHoldTime)
			{
				hands[i].ShakeHand(handShakeAmount * Time.deltaTime);
				CL_CameraControl.Shake(0.0005f);
				if (!flag && shakeStartSound != null)
				{
					AudioManager.PlaySound(shakeStartSound, base.transform.position);
				}
			}
			if (handHoldTime[hands[i]] > maxHoldTime)
			{
				hands[i].DropHand();
				if (slipSound != null)
				{
					AudioManager.PlaySound(slipSound, base.transform.position);
				}
				slipEvent.Invoke();
				break;
			}
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
		holdPosition.y = 0.2f;
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
