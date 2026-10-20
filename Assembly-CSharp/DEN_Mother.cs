using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DEN_Mother : Denizen
{
	[Serializable]
	public class TradeReward
	{
		[Serializable]
		public class PartialReward
		{
			public int partialRewardTradeCount;

			public string partialRewardDialogue;

			public UnityEvent partialRewardEvent;

			public string partialRewardAchievement;

			public string partialRewardFlag;

			public bool hasRecieved;
		}

		public string name;

		public int value;

		public bool allowInIK = true;

		public List<string> tags;

		public int tradeCount;

		public int tradeTarget = 1;

		public List<Perk> paymentPerk;

		public UnityEvent tradeEvent;

		public UnityEvent tradeFailureEvent;

		public string postTradeDialogue;

		public Item_Object rewardItem;

		public bool returnObject;

		public bool lockAfterFinish = true;

		public bool locked;

		public List<PartialReward> partialRewards;

		public bool Trade(Item item, DEN_Mother mother)
		{
			if (locked)
			{
				return false;
			}
			if (HasMetRequirements())
			{
				tradeCount = 0;
			}
			tradeCount++;
			foreach (PartialReward partialReward in partialRewards)
			{
				if (!partialReward.hasRecieved && tradeCount >= partialReward.partialRewardTradeCount)
				{
					partialReward.hasRecieved = true;
					if (partialReward.partialRewardAchievement != "")
					{
						CL_AchievementManager.SetAchievementValue(partialReward.partialRewardAchievement, b: true);
					}
					if (partialReward.partialRewardFlag != "")
					{
						CL_GameManager.SetGameFlag(partialReward.partialRewardFlag, state: true);
					}
					partialReward.partialRewardEvent.Invoke();
					if (partialReward.partialRewardDialogue != "")
					{
						mother.psychicCommunicator.PlayString(partialReward.partialRewardDialogue);
					}
				}
			}
			if (tradeCount >= tradeTarget)
			{
				if (paymentPerk != null && paymentPerk.Count > 0)
				{
					ENT_Player.GetPlayer().AddPerk(paymentPerk[UnityEngine.Random.Range(0, paymentPerk.Count)]);
				}
				tradeEvent.Invoke();
				if (lockAfterFinish)
				{
					locked = true;
				}
				return true;
			}
			tradeFailureEvent.Invoke();
			return false;
		}

		public bool HasMetRequirements()
		{
			return tradeCount > tradeTarget;
		}
	}

	public static DEN_Mother instance;

	public Animator animator;

	public bool canTrade;

	private bool hasItem;

	private bool trading;

	public bool canAnger;

	public bool focused = true;

	public bool angry;

	private Item heldItem;

	public UT_ItemInteractor itemInteractor;

	private TradeReward currentReward;

	public Transform giftParentLocator;

	public UT_PsychicCommunicator psychicCommunicator;

	public Transform tradeSpot;

	public UnityEvent angerEvent;

	public UnityEvent tradeEvent;

	public UnityEvent damageEvent;

	public static float motherGiveTime;

	public List<TradeReward> trades;

	private int hits;

	public override void Start()
	{
		base.Start();
		itemInteractor.gameObject.SetActive(value: false);
		instance = this;
		if (!focused)
		{
			EndFocus();
		}
		else
		{
			StartFocus();
		}
		motherGiveTime = 0f;
	}

	public override void Update()
	{
		base.Update();
		if (focused)
		{
			return;
		}
		float num = Vector3.Distance(tradeSpot.position, ENT_Player.GetPlayer().transform.position);
		if (!trading)
		{
			if (canTrade && num < 4f && ENT_Player.GetPlayer().HasItemInAnyHand())
			{
				animator.SetBool("ExtendHand", value: true);
				itemInteractor.gameObject.SetActive(value: true);
			}
			else
			{
				animator.SetBool("ExtendHand", value: false);
				itemInteractor.transform.parent.gameObject.SetActive(value: false);
			}
		}
	}

	public void ReadyToGrabItem()
	{
		if (canTrade && !trading)
		{
			itemInteractor.transform.parent.gameObject.SetActive(value: true);
		}
	}

	public void GrabItem(Item item)
	{
		heldItem = item;
		item.GetDropObject().canPickup = false;
		Rigidbody component = heldItem.GetDropObject().GetComponent<Rigidbody>();
		if (component != null)
		{
			component.isKinematic = true;
		}
		Denizen component2 = heldItem.GetDropObject().GetComponent<Denizen>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		item._OnPickupAction = (Action<Item>)Delegate.Combine(item._OnPickupAction, new Action<Item>(RemoveItem));
		Trade();
		trading = true;
		itemInteractor.transform.parent.gameObject.SetActive(value: false);
		motherGiveTime = Time.time;
	}

	public void RemoveItem(Item item)
	{
		heldItem = null;
		item._OnPickupAction = (Action<Item>)Delegate.Remove(item._OnPickupAction, new Action<Item>(RemoveItem));
		animator.SetBool("ExtendHand", value: false);
		animator.SetBool("Examine", value: false);
		trading = false;
	}

	public void ExamineItem()
	{
		if (heldItem != null)
		{
			string localization = CL_LocalizationManager.GetLocalization("mother", "ex:" + heldItem.prefabName);
			if (localization != "")
			{
				psychicCommunicator.PlayString(localization);
			}
		}
	}

	public void SetCanTrade(bool b)
	{
		canTrade = b;
	}

	public void Trade()
	{
		if (heldItem == null)
		{
			return;
		}
		tradeEvent.Invoke();
		bool flag = true;
		foreach (TradeReward trade in trades)
		{
			if (!heldItem.HasTagInList(trade.tags))
			{
				continue;
			}
			if (!ENT_Player.GetPlayer().HasPerk("Perk_Binding_NoShops"))
			{
				if (trade.Trade(heldItem, this) && trade.rewardItem != null)
				{
					animator.SetTrigger("GiveItem");
				}
				currentReward = trade;
			}
			else
			{
				psychicCommunicator.PlayString("{lang:mother:noshops}");
				flag = false;
			}
			if (!trade.returnObject)
			{
				flag = false;
			}
			break;
		}
		if (flag)
		{
			heldItem.GetDropObject().canPickup = true;
			animator.SetTrigger("Reject");
			animator.SetBool("ExtendHand", value: true);
		}
		else
		{
			animator.SetTrigger("Accept");
			animator.SetBool("ExtendHand", value: false);
		}
		animator.SetBool("Examine", value: false);
	}

	public void GiveTradeReward()
	{
		if (currentReward != null && currentReward.rewardItem != null)
		{
			DestroyItem();
			Item clone = currentReward.rewardItem.itemData.GetClone();
			clone.GetDropObject().transform.parent = giftParentLocator;
			clone.GetDropObject().transform.localPosition = Vector3.zero;
			clone.GetDropObject().transform.localRotation = Quaternion.identity;
			clone._OnPickupAction = (Action<Item>)Delegate.Combine(clone._OnPickupAction, new Action<Item>(RemoveItem));
			clone.GetDropObject().gameObject.SetActive(value: true);
			Rigidbody component = clone.GetDropObject().GetComponent<Rigidbody>();
			if (component != null)
			{
				component.isKinematic = true;
			}
			if (currentReward.postTradeDialogue != "")
			{
				psychicCommunicator.PlayString(currentReward.postTradeDialogue);
			}
			heldItem = clone;
			trading = true;
			animator.SetBool("ExtendHand", value: true);
		}
	}

	public void DestroyItem()
	{
		if (heldItem != null)
		{
			heldItem.Destroy();
		}
		trading = false;
	}

	public void EndFocus()
	{
		animator.SetBool("Focused", value: false);
		focused = false;
	}

	public void StartFocus()
	{
		animator.SetBool("Focused", value: true);
		focused = true;
	}

	public override bool Damage(Damageable.DamageInfo info)
	{
		if (angry)
		{
			return false;
		}
		if (info.sourceEntity != ENT_Player.GetPlayer())
		{
			return false;
		}
		damageEvent.Invoke();
		hits++;
		if (hits >= 3)
		{
			Kill("", info);
			return false;
		}
		animator.SetTrigger("Hit");
		if (!base.Damage(info))
		{
			psychicCommunicator.PlayString(CL_LocalizationManager.currentLocalization.GetLine("mother", "player-hurt"));
		}
		return false;
	}

	public override void Kill(string type = "", Damageable.DamageInfo info = null)
	{
		if (info != null && info.sourceEntity == ENT_Player.GetPlayer())
		{
			Enrage();
		}
	}

	public void Enrage(bool crush = true)
	{
		if (focused || !canAnger)
		{
			return;
		}
		animator.SetBool("Angry", value: true);
		if (!angry)
		{
			angry = true;
			if (crush)
			{
				angerEvent.Invoke();
				clipHandler.PlaySound("mother:killEvent");
				string line = CL_LocalizationManager.currentLocalization.GetLine("mother", "player-grubcrush");
				if (line != "")
				{
					psychicCommunicator.PlayString(line);
				}
				StartCoroutine(KillPlayer());
			}
		}
		trading = false;
		canTrade = false;
		IEnumerator KillPlayer()
		{
			yield return new WaitForSeconds(4f);
			psychicCommunicator.PlayString(CL_LocalizationManager.currentLocalization.GetLine("mother", "player-kill"));
			yield return new WaitForSeconds(2f);
			animator.SetTrigger("Crush");
		}
	}

	public void KillPlayer()
	{
		ENT_Player.GetPlayer().Kill("mother");
		CL_AchievementManager.SetAchievementValue("ACH_MOTHERSWRATH", b: true);
	}

	public void SetCanAnger(bool b)
	{
		canAnger = b;
	}
}
