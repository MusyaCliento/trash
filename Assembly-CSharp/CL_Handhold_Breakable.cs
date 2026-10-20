using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CL_Handhold_Breakable : CL_Handhold, Damageable
{
	public float maxHoldTime = 3f;

	public bool useTotalHoldTime;

	public bool drainTotalHoldTime;

	public float slipSpeed = 1f;

	public float handShakeHoldTime = 1f;

	public float handShakeAmount = 0.1f;

	public float holdShakeAmount = 1f;

	public float holdShakeRate = 0.2f;

	private float holdShakeTimer;

	private float holdShakeSoundTimer;

	[Space]
	[Header("Audio")]
	public AudioClip slipSound;

	public List<AudioClip> slipSounds;

	public AudioClip shakeStartSound;

	public List<AudioClip> shakeStartSounds;

	public UnityEvent slipEvent;

	private Dictionary<ENT_Player.Hand, float> handHoldTime = new Dictionary<ENT_Player.Hand, float>();

	private float totalHoldTime;

	public List<Transform> visualShakeTransforms = new List<Transform>();

	private List<Quaternion> localRotations = new List<Quaternion>();

	public bool hideOnBreak = true;

	public override void Start()
	{
		base.Start();
		if (visualShakeTransforms.Count == 0)
		{
			visualShakeTransforms.Add(base.transform);
		}
		foreach (Transform visualShakeTransform in visualShakeTransforms)
		{
			localRotations.Add(visualShakeTransform.localRotation);
		}
	}

	internal override void Update()
	{
		base.Update();
		if (useTotalHoldTime)
		{
			if (holdShakeTimer <= 0f)
			{
				for (int i = 0; i < visualShakeTransforms.Count; i++)
				{
					visualShakeTransforms[i].localRotation = localRotations[i] * Quaternion.Euler(Random.insideUnitSphere * totalHoldTime * holdShakeAmount);
				}
				holdShakeTimer = holdShakeRate;
			}
			holdShakeTimer -= Time.deltaTime;
			if (holdShakeSoundTimer <= 0f)
			{
				if (shakeStartSounds != null && totalHoldTime > handShakeHoldTime && shakeStartSounds.Count > 0)
				{
					AudioManager.PlaySound(shakeStartSounds[Random.Range(0, shakeStartSounds.Count)], base.transform.position, totalHoldTime / maxHoldTime);
					holdShakeSoundTimer = shakeStartSounds.Count;
				}
			}
			else
			{
				holdShakeSoundTimer -= Time.deltaTime;
			}
		}
		if (GetHolding())
		{
			if (hands.Count <= 0)
			{
				return;
			}
			if (useTotalHoldTime)
			{
				totalHoldTime += Time.deltaTime;
				bool flag = false;
				for (int j = 0; j < hands.Count; j++)
				{
					flag = handHoldTime[hands[j]] > handShakeHoldTime;
					handHoldTime[hands[j]] += Time.deltaTime;
					hands[j].OffsetHoldPosition(Vector3.down * Time.deltaTime * slipSpeed);
				}
				if (totalHoldTime > handShakeHoldTime)
				{
					for (int k = 0; k < hands.Count; k++)
					{
						hands[k].ShakeHand(handShakeAmount * Time.deltaTime);
					}
					CL_CameraControl.Shake(0.0005f);
					if (!flag)
					{
						_ = shakeStartSound != null;
					}
				}
				if (totalHoldTime > maxHoldTime)
				{
					Break();
				}
				return;
			}
			for (int l = 0; l < hands.Count; l++)
			{
				if (!handHoldTime.ContainsKey(hands[l]))
				{
					continue;
				}
				bool flag2 = handHoldTime[hands[l]] > handShakeHoldTime;
				handHoldTime[hands[l]] += Time.deltaTime;
				hands[l].OffsetHoldPosition(Vector3.down * Time.deltaTime * slipSpeed);
				if (handHoldTime[hands[l]] > handShakeHoldTime)
				{
					hands[l].ShakeHand(handShakeAmount * Time.deltaTime);
					CL_CameraControl.Shake(0.0005f);
					if (!flag2 && shakeStartSound != null)
					{
						AudioManager.PlaySound(shakeStartSounds[Random.Range(0, shakeStartSounds.Count)], base.transform.position);
					}
				}
				if (handHoldTime[hands[l]] > maxHoldTime)
				{
					Break();
					break;
				}
			}
		}
		else if (useTotalHoldTime && drainTotalHoldTime)
		{
			totalHoldTime = Mathf.Max(totalHoldTime - Time.deltaTime, 0f);
		}
	}

	public void Break()
	{
		if (hands != null && hands.Count > 0)
		{
			for (int num = hands.Count - 1; num >= 0; num--)
			{
				hands[num].DropHand();
			}
		}
		if (slipSound != null)
		{
			AudioManager.PlaySound(slipSound, base.transform.position);
		}
		if (slipSounds != null && slipSounds.Count > 0)
		{
			AudioManager.PlaySound(slipSounds[Random.Range(0, slipSounds.Count)], base.transform.position);
		}
		slipEvent.Invoke();
		if (hideOnBreak)
		{
			base.gameObject.SetActive(value: false);
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

	public bool Damage(Damageable.DamageInfo info)
	{
		Break();
		return false;
	}
}
