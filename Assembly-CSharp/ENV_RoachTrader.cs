using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ENV_RoachTrader : MonoBehaviour
{
	[Serializable]
	public class RoachTradeGroup
	{
		[Serializable]
		public class Trade
		{
			public SpawnTable.SpawnSettings spawnSettings;

			public Item_Object item;

			public List<Item_Object> bonusItems;

			public List<string> gamemodeTagWhitelist;

			public List<string> gamemodeTagBlacklist;
		}

		public List<Trade> trades;

		public List<Transform> spawnLocations;

		public void Spawn()
		{
			List<Trade> list = new List<Trade>();
			foreach (Trade trade2 in trades)
			{
				if ((trade2.gamemodeTagWhitelist == null || trade2.gamemodeTagWhitelist.Count <= 0 || CL_GameManager.GetBaseGamemode().HasAnyTag(trade2.gamemodeTagWhitelist)) && (trade2.gamemodeTagBlacklist == null || trade2.gamemodeTagBlacklist.Count <= 0 || !CL_GameManager.GetBaseGamemode().HasAnyTag(trade2.gamemodeTagBlacklist)) && trade2.spawnSettings.RandomCheck())
				{
					list.Add(trade2);
				}
			}
			bool flag = ENT_Player.GetPlayer().HasPerk("Perk_Binding_PitonsAndBeans");
			bool flag2 = ENT_Player.GetPlayer().HasPerk("Perk_PheromoneGlands");
			foreach (Transform spawnLocation in spawnLocations)
			{
				Trade trade = list[UnityEngine.Random.Range(0, list.Count)];
				if (list.Count > 1)
				{
					list.Remove(trade);
				}
				if (trade == null)
				{
					continue;
				}
				if (flag)
				{
					if (UnityEngine.Random.value > 0.5f)
					{
						trade.item = CL_AssetManager.GetItemObjectPrefab("Item_Beans");
					}
					else
					{
						trade.item = CL_AssetManager.GetItemObjectPrefab("Item_Piton");
					}
					trade.bonusItems = null;
				}
				Item clone = trade.item.itemData.GetClone();
				Item_Object dropObject = clone.GetDropObject();
				dropObject.transform.parent = spawnLocation;
				dropObject.gameObject.SetActive(value: true);
				dropObject.transform.localPosition = Vector3.zero;
				dropObject.transform.localRotation = Quaternion.identity;
				ObjectTagger component = dropObject.GetComponent<ObjectTagger>();
				if (component != null)
				{
					component.AddTag("ItemLocked");
					component.AddTag("Vended");
				}
				if (CL_GameManager.HasActiveFlag("roachmode"))
				{
					clone.worth = Mathf.CeilToInt((float)clone.worth * 0.8f);
				}
				if (CL_GameManager.HasActiveFlag("roachlover"))
				{
					clone.worth = Mathf.CeilToInt((float)clone.worth * 0.8f);
				}
				if (flag && flag2)
				{
					clone.worth = 0;
				}
				Rigidbody component2 = dropObject.GetComponent<Rigidbody>();
				if (component2 != null)
				{
					component2.isKinematic = true;
				}
				clone.itemTags.Add("unpurchased");
			}
		}
	}

	public Animator roachAnimator;

	public ENV_Barterer barterer;

	private UT_AudioClipHandler clipHandler;

	public List<RoachTradeGroup> roachTradeGroups;

	private bool playerHasShopItem;

	public UnityEvent eventOnPlayerHoldingShopItem;

	public UnityEvent eventOnPlayerDropShopItem;

	public Transform sweepItemTransform;

	public float sweepForce = 20f;

	private float lean;

	private float leanDir;

	private bool playerLookingAt;

	private bool heldup;

	private float barkTimer = 10f;

	private bool isPlayerRoach;

	private bool hasWelcomedPlayer;

	private List<Item_Object> sweepItems;

	private void Start()
	{
		foreach (RoachTradeGroup roachTradeGroup in roachTradeGroups)
		{
			roachTradeGroup.Spawn();
		}
		clipHandler = GetComponent<UT_AudioClipHandler>();
		roachAnimator.SetInteger("StartState", UnityEngine.Random.Range(0, 2));
	}

	private void Update()
	{
		bool flag = ENT_Player.GetPlayer().HasPerk("Perk_Binding_PitonsAndBeans");
		bool flag2 = ENT_Player.GetPlayer().HasPerk("Perk_PheromoneGlands");
		bool flag3 = ENT_Player.GetPlayer().HasPerk("Perk_U_T4_FunniestTimeline");
		isPlayerRoach = ENT_Player.GetPlayer().HasPerk("Perk_Binding_RoachMode");
		barkTimer -= Time.deltaTime;
		if (barkTimer < 0f)
		{
			barkTimer = UnityEngine.Random.Range(10, 20);
			if (isPlayerRoach)
			{
				if (hasWelcomedPlayer)
				{
					clipHandler.PlaySound("trader:bark");
					if (flag2)
					{
						if (flag)
						{
							if (flag3)
							{
								PlaySubtitle("bark-pitonandbeansgoodsmellfunniest");
							}
							else
							{
								PlaySubtitle("bark-pitonandbeansgoodsmell");
							}
						}
						else
						{
							PlaySubtitle("bark-goodsmell");
						}
					}
					else if (flag)
					{
						PlaySubtitle("bark-pitonandbeans");
					}
					else if (flag3)
					{
						PlaySubtitle("bark-funniest");
					}
					else
					{
						PlaySubtitle("bark");
					}
				}
				else if (roachAnimator.GetInteger("StartState") == 1)
				{
					barkTimer = UnityEngine.Random.Range(15, 40);
					clipHandler.PlaySound("trader:bark");
					PlaySubtitle("pet");
				}
			}
			else
			{
				clipHandler.PlaySound("trader:bark");
			}
		}
		if (!playerHasShopItem && Inventory.instance.HasItemWithTag("unpurchased"))
		{
			playerHasShopItem = true;
			eventOnPlayerHoldingShopItem.Invoke();
		}
		else if (playerHasShopItem && !Inventory.instance.HasItemWithTag("unpurchased"))
		{
			playerHasShopItem = false;
			eventOnPlayerDropShopItem.Invoke();
		}
		roachAnimator.SetFloat("LeanDir", Mathf.Lerp(roachAnimator.GetFloat("LeanDir"), leanDir, Time.deltaTime * 1f));
		roachAnimator.SetFloat("Lean", Mathf.Lerp(roachAnimator.GetFloat("Lean"), lean, Time.deltaTime * 1f));
		bool flag4 = Inventory.instance.HasItemWithTag("firearm", inHand: true);
		if (playerLookingAt)
		{
			if (flag4 && !heldup)
			{
				SetHoldup(b: true);
			}
			if (!flag4 && heldup)
			{
				SetHoldup(b: false);
			}
		}
		else if (heldup)
		{
			SetHoldup(b: false);
		}
	}

	public void Welcome()
	{
		barkTimer = UnityEngine.Random.Range(10, 20);
		clipHandler.PlaySound("trader:welcome");
		if (isPlayerRoach)
		{
			PlaySubtitle("welcome");
		}
		hasWelcomedPlayer = true;
	}

	public void OnPurchase(List<Item_Object> soldItems)
	{
		roachAnimator.SetTrigger("Accept");
		roachAnimator.SetTrigger("TakeItems");
		CL_AchievementManager.SetAchievementValue("ACH_BAZAAR", b: true);
		clipHandler.PlaySound("trader:success");
		if (isPlayerRoach)
		{
			PlaySubtitle("success");
		}
		sweepItems = soldItems;
		barkTimer = UnityEngine.Random.Range(10, 20);
		foreach (Item_Object soldItem in soldItems)
		{
			soldItem.canPickup = false;
		}
	}

	public void StartSweep()
	{
		StartCoroutine(Sweep());
		IEnumerator Sweep()
		{
			foreach (Item_Object sweepItem in sweepItems)
			{
				sweepItem.gameObject.layer = LayerMask.NameToLayer("Interactable Only World Collide");
			}
			float sweepTime = 0f;
			while (sweepTime < 1f)
			{
				sweepTime += Time.deltaTime;
				foreach (Item_Object sweepItem2 in sweepItems)
				{
					if (sweepItem2.GetComponent<Rigidbody>() != null)
					{
						sweepItem2.GetComponent<Rigidbody>().AddForce((sweepItemTransform.position - sweepItem2.transform.position) * sweepForce * Time.deltaTime, ForceMode.VelocityChange);
					}
					sweepItem2.transform.localScale = Vector3.one * (1f - sweepTime);
				}
				yield return null;
			}
			foreach (Item_Object sweepItem3 in sweepItems)
			{
				sweepItem3.itemData.Destroy();
			}
		}
	}

	public void DenyCheck()
	{
		if (!barterer.CanAfford() && !heldup && barterer.itemsInZone.Count > 0)
		{
			roachAnimator.SetTrigger("Deny");
			clipHandler.PlaySound("trader:deny");
			if (isPlayerRoach)
			{
				PlaySubtitle("deny");
			}
			barkTimer = UnityEngine.Random.Range(10, 20);
		}
	}

	public void Shutter()
	{
		roachAnimator.SetTrigger("Shutter");
		clipHandler.PlaySound("trader:close");
		if (isPlayerRoach)
		{
			PlaySubtitle("close");
		}
		barkTimer = 99999f;
	}

	public void SetLeanDirection(float l)
	{
		leanDir = l;
	}

	public void SetLean(float b)
	{
		lean = b;
	}

	public void SetHoldup(bool b)
	{
		roachAnimator.SetBool("Holdup", b);
		if (!heldup && b)
		{
			clipHandler.PlaySound("trader:threaten");
			if (isPlayerRoach)
			{
				PlaySubtitle("threaten");
			}
			barkTimer = UnityEngine.Random.Range(10, 20);
		}
		heldup = b;
	}

	public void SetPlayerLookingAt(bool b)
	{
		playerLookingAt = b;
	}

	public void PlaySubtitle(string s)
	{
		CL_UIManager.ShowSubtitle(CL_LocalizationManager.currentLocalization.GetLine("roachtrader", s), "<color=#ad8157>");
	}
}
