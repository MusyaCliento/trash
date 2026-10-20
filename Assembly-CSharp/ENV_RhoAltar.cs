using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ENV_RhoAltar : MonoBehaviour
{
	[Serializable]
	public class SacrificeTag
	{
		public string name;

		public string itemTag;

		public int value = 1;

		public List<GameObject> directPayment;

		public UnityEvent payEvent;

		public string sacrificeStat = "";

		public int sacrificeStatAmount = 1;

		public string sacrificeFlag = "";
	}

	[Serializable]
	public class SacrificeReward
	{
		public enum RewardType
		{
			spawnTable = 0,
			gameObject = 1,
			perk = 2,
			sessionEvent = 3
		}

		public string name;

		public int value;

		public bool allowInIK = true;

		public int tradeCount = 1;

		public RewardType rewardType;

		public SpawnTable spawnTable;

		public List<GameObject> paymentObject;

		public List<Perk> paymentPerk;

		public List<SessionEvent> sessionEvents;

		public UnityEvent tradeEvent;
	}

	public List<SacrificeTag> sacrifices;

	public List<SacrificeReward> rewards;

	public string useFlag;

	public int maxTrades = 1;

	private int currentTrades;

	private int currentValue;

	private float rewardCountdown;

	public Transform spawnPosition;

	public AudioClip recieveSound;

	public AudioClip acceptSound;

	public AudioClip denySound;

	public UnityEvent placeEvent;

	public UnityEvent recieveEvent;

	public UnityEvent denyEvent;

	public UnityEvent tradeEvent;

	private List<GameObject> ignoreList = new List<GameObject>();

	private void Start()
	{
		if (!string.IsNullOrEmpty(useFlag))
		{
			CL_GameManager.SessionFlag gameFlag = CL_GameManager.GetGameFlag("altar-" + useFlag);
			if (gameFlag != null)
			{
				currentTrades = int.Parse(gameFlag.data);
			}
		}
	}

	public void CheckTransform(Transform collision)
	{
		Item_Object component = collision.gameObject.GetComponent<Item_Object>();
		if (component != null)
		{
			CheckItemObject(component);
		}
	}

	public void CheckItemObject(Item_Object item)
	{
		if (currentTrades >= maxTrades || ignoreList.Contains(item.gameObject))
		{
			return;
		}
		rewardCountdown = 5f;
		foreach (SacrificeTag sacrifice in sacrifices)
		{
			SacrificeTag s = sacrifice;
			if (item.itemData.HasTag(s.itemTag))
			{
				item.canPickup = false;
				ignoreList.Add(item.gameObject);
				placeEvent.Invoke();
				StartCoroutine(WaitToTake());
				return;
			}
			IEnumerator WaitToTake()
			{
				yield return new WaitForSeconds(0.6f);
				AudioManager.PlaySound(recieveSound, base.transform.position);
				bool flag = true;
				if (s.value > 0 && ENT_Player.GetPlayer().HasPerk("Perk_Binding_NoShops"))
				{
					CL_UIManager.instance.highscoreHeader.ShowText("Sol..d. out. You..r luck. is bou.nd..");
					flag = false;
					item.canPickup = true;
				}
				if (flag)
				{
					currentValue += s.value;
					if (s.sacrificeStat != "")
					{
						StatManager.sessionStats.UpdateStatistic(s.sacrificeStat, s.sacrificeStatAmount, StatManager.Statistic.DataType.Int, StatManager.Statistic.ModType.Add);
					}
					if (s.sacrificeFlag != "")
					{
						CL_GameManager.SetGameFlag(s.sacrificeFlag, state: true);
					}
				}
				if (s.directPayment != null && s.directPayment.Count > 0)
				{
					ignoreList.Add(UnityEngine.Object.Instantiate(s.directPayment[UnityEngine.Random.Range(0, s.directPayment.Count)], item.transform.position, item.transform.rotation, spawnPosition));
				}
				if (flag)
				{
					UnityEngine.Object.Destroy(item.gameObject);
					s.payEvent.Invoke();
					recieveEvent.Invoke();
				}
			}
		}
		AudioManager.PlaySound(denySound, base.transform.position);
	}

	private void Update()
	{
		if (currentValue > 0)
		{
			rewardCountdown -= Time.deltaTime;
			if (rewardCountdown <= 0f)
			{
				Trade();
			}
		}
	}

	public void Trade()
	{
		SacrificeReward sacrificeReward = null;
		foreach (SacrificeReward reward in rewards)
		{
			if ((reward.allowInIK || !CL_GameManager.GetBaseGamemode().IsIronKnuckle()) && (!ENT_Player.GetPlayer().HasPerk("Perk_Binding_NoPerks") || reward.rewardType != SacrificeReward.RewardType.perk) && currentValue >= reward.value)
			{
				if (sacrificeReward == null)
				{
					sacrificeReward = reward;
				}
				else if (reward.value > sacrificeReward.value)
				{
					sacrificeReward = reward;
				}
			}
		}
		if (sacrificeReward == null && ENT_Player.GetPlayer().HasPerk("Perk_Binding_PitonsAndBeans"))
		{
			sacrificeReward = new SacrificeReward
			{
				allowInIK = true,
				rewardType = SacrificeReward.RewardType.gameObject,
				paymentObject = new List<GameObject>(),
				tradeEvent = new UnityEvent()
			};
			sacrificeReward.paymentObject.Add(CL_AssetManager.GetItemObjectPrefab("Item_Beans").gameObject);
		}
		if (sacrificeReward == null)
		{
			rewardCountdown = 5f;
			return;
		}
		currentTrades += sacrificeReward.tradeCount;
		if (!string.IsNullOrEmpty(useFlag))
		{
			CL_GameManager.SetGameFlag("altar-" + useFlag, state: true, currentTrades.ToString());
		}
		sacrificeReward.tradeEvent.Invoke();
		AudioManager.PlaySound(acceptSound, base.transform.position);
		if (sacrificeReward.rewardType == SacrificeReward.RewardType.spawnTable)
		{
			foreach (GameObject prefab in sacrificeReward.spawnTable.GetRandomSpawnObject().prefabs)
			{
				ignoreList.Add(UnityEngine.Object.Instantiate(prefab.gameObject, spawnPosition.position, spawnPosition.rotation, spawnPosition));
			}
		}
		else if (sacrificeReward.rewardType == SacrificeReward.RewardType.gameObject)
		{
			if (sacrificeReward.paymentObject != null && sacrificeReward.paymentObject.Count > 0)
			{
				ignoreList.Add(UnityEngine.Object.Instantiate(sacrificeReward.paymentObject[UnityEngine.Random.Range(0, sacrificeReward.paymentObject.Count)], spawnPosition.position, spawnPosition.rotation, spawnPosition));
			}
		}
		else if (sacrificeReward.rewardType == SacrificeReward.RewardType.perk && sacrificeReward.paymentPerk.Count > 0)
		{
			ENT_Player.GetPlayer().AddPerk(sacrificeReward.paymentPerk[UnityEngine.Random.Range(0, sacrificeReward.paymentPerk.Count)]);
		}
		else if (sacrificeReward.rewardType == SacrificeReward.RewardType.sessionEvent && sacrificeReward.sessionEvents.Count > 0)
		{
			CL_EventManager.StartEvent(sacrificeReward.sessionEvents[UnityEngine.Random.Range(0, sacrificeReward.sessionEvents.Count)]);
		}
		tradeEvent.Invoke();
		currentValue = 0;
		rewardCountdown = 5f;
	}
}
