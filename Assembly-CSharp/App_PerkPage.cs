using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class App_PerkPage : MonoBehaviour
{
	public enum PerkPageType
	{
		regular = 0,
		unstable = 1
	}

	public PerkPageType perkPageType;

	public List<Perk> perks;

	public List<string> requiredPerkTags = new List<string> { "standard" };

	public App_PerkPage_Card cardAsset;

	public Transform cardParent;

	public GameObject perksNotAvailableScreen;

	public Image iconAsset;

	public Transform iconParent;

	public int minCards = 1;

	public int maxCards = 3;

	private List<App_PerkPage_Card> cards;

	private App_PerkPage_Card selectedCard;

	public Button purchaseButton;

	public OS_Window fulfillmentWindow;

	private OS_Window window;

	private string id;

	private OS_Manager os;

	private int lastRoaches;

	private bool fullfilled;

	public int refreshCost = 5;

	public GameObject outOfPerksRoot;

	public GameObject reloadSettingsRoot;

	private System.Random rng;

	private void Start()
	{
		window = GetComponent<OS_Window>();
		os = window.os;
		id = Guid.NewGuid().ToString();
		cards = new List<App_PerkPage_Card>();
		lastRoaches = CL_GameManager.GetRoaches();
		Dictionary<string, string> dictionary = DarkMachineFunctions.ParseKeyValueString(window.file.fileInfo.data);
		if (dictionary.ContainsKey("perkTags"))
		{
			List<string> list = DarkMachineFunctions.ParseStringArray(dictionary["perkTags"]);
			if (list != null && list.Count > 0)
			{
				requiredPerkTags = list;
			}
			foreach (string item in list)
			{
				Debug.Log("Required Perk Tag: " + item);
			}
		}
		if (os.worldInterface.GetSeed() != -1)
		{
			rng = new System.Random(os.worldInterface.GetSeed());
		}
		else
		{
			rng = new System.Random();
		}
		GenerateCards();
		CheckIronKnuckle();
	}

	private void OnEnable()
	{
		GenerateIcons();
		CheckIronKnuckle();
	}

	private void CheckIronKnuckle()
	{
		if (CL_GameManager.IsIronKnuckle())
		{
			Message_Manager.Message_Packet message_Packet = new Message_Manager.Message_Packet();
			message_Packet.type = "default";
			message_Packet.closeText = "Quit";
			message_Packet.closeFunction = window.CloseApp;
			message_Packet.message = "You are playing in IRON KNUCKLE mode. No perks for you!";
			message_Packet.screenPos = new Vector2(0f, 0f);
			window.os.messageManager.CreateMessage(message_Packet);
		}
		else if (CL_GameManager.HasActiveFlag("blockperks"))
		{
			Message_Manager.Message_Packet message_Packet2 = new Message_Manager.Message_Packet();
			message_Packet2.type = "default";
			message_Packet2.closeText = "Quit";
			message_Packet2.closeFunction = window.CloseApp;
			message_Packet2.message = "Perks are unavailable, please contact your local authority admin for support.";
			message_Packet2.screenPos = new Vector2(0f, 0f);
			window.os.messageManager.CreateMessage(message_Packet2);
		}
	}

	private void Update()
	{
		if (fullfilled || lastRoaches == CL_GameManager.GetRoaches() || cards.Count <= 0)
		{
			return;
		}
		selectedCard = cards[0];
		for (int i = 0; i < cards.Count; i++)
		{
			App_PerkPage_Card app_PerkPage_Card = cards[i];
			if (i == 0)
			{
				app_PerkPage_Card.SelectCard();
			}
			else
			{
				app_PerkPage_Card.DeselectCard();
			}
			app_PerkPage_Card.UpdateCard();
		}
		lastRoaches = CL_GameManager.GetRoaches();
	}

	private void GenerateCards(bool refresh = false)
	{
		List<string> list = new List<string>();
		if (cards.Count > 0)
		{
			for (int num = cards.Count - 1; num >= 0; num--)
			{
				if (refresh)
				{
					list.Add(cards[num].perk.id);
				}
				UnityEngine.Object.Destroy(cards[num].gameObject);
			}
			cards.Clear();
		}
		CL_GameManager.SessionFlag gameFlag = CL_GameManager.GetGameFlag("recieved-" + os.worldInterface.computerID + "-perk");
		if (gameFlag != null && gameFlag.state)
		{
			outOfPerksRoot.SetActive(value: true);
			reloadSettingsRoot.SetActive(value: false);
			return;
		}
		int num2 = rng.Next(minCards, maxCards + 1);
		List<Perk> list2 = new List<Perk>();
		list2.AddRange(CL_AssetManager.GetFullCombinedAssetDatabase().perkAssets);
		for (int num3 = list2.Count - 1; num3 >= 0; num3--)
		{
			if (perkPageType == PerkPageType.regular)
			{
				if (list2[num3].spawnPool != Perk.PerkPool.standard)
				{
					list2.RemoveAt(num3);
					continue;
				}
			}
			else if (perkPageType == PerkPageType.unstable && list2[num3].spawnPool != Perk.PerkPool.unstable)
			{
				list2.RemoveAt(num3);
				continue;
			}
			if (requiredPerkTags != null && requiredPerkTags.Count > 0)
			{
				Debug.Log("Has Required Tags");
				bool flag = false;
				foreach (string requiredPerkTag in requiredPerkTags)
				{
					if (list2[num3].tags.Contains(requiredPerkTag))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list2.RemoveAt(num3);
				}
			}
			if (refresh && list2.Count > maxCards && list != null && list.Contains(list2[num3].id))
			{
				Debug.Log("Removing Perk: " + list2[num3].id);
				list2.RemoveAt(num3);
			}
		}
		for (int i = 0; i < num2; i++)
		{
			App_PerkPage_Card component = UnityEngine.Object.Instantiate(cardAsset, cardParent.position, Quaternion.identity, cardParent).GetComponent<App_PerkPage_Card>();
			Perk perk = null;
			Facility facilityFromID = Facility.GetFacilityFromID(os.worldInterface.facilityID);
			int num4 = 1;
			if (facilityFromID != null)
			{
				num4 = facilityFromID.highValuePerks;
			}
			if (CL_GameManager.GetBaseGamemode().IsCompetitive())
			{
				num4 = 2;
			}
			List<Perk> list3 = new List<Perk>();
			foreach (Perk item in list2)
			{
				if (!item.CanSpawn())
				{
					Debug.Log("Found perk which can't spawn." + item.name);
				}
				else
				{
					if (CL_GameManager.GetBaseGamemode().IsCompetitive() && !item.competitive)
					{
						continue;
					}
					if (perkPageType == PerkPageType.unstable)
					{
						list3.Add(item);
						continue;
					}
					if (i < num2 - num4 && item.cost == 0)
					{
						list3.Add(item);
					}
					if (i >= num2 - num4 && item.cost > 0)
					{
						list3.Add(item);
					}
				}
			}
			perk = GetRandomPerk(list3);
			list2.Remove(perk);
			perk = UnityEngine.Object.Instantiate(perk);
			int num5 = 0;
			if (CL_GameManager.GetBaseGamemode().HasTag("endless") && CL_GameManager.gMan.GetPlayerBestTravelDistance() > 2000f)
			{
				num5 = Mathf.RoundToInt((CL_GameManager.gMan.GetPlayerBestTravelDistance() - 2000f) / 400f);
			}
			else if (i > 0 && facilityFromID != null)
			{
				num5 = facilityFromID.perkCostModifier;
			}
			perk.cost += num5;
			perk.cost = Mathf.Min(perk.cost, 99);
			component.Initialize(this, perk);
			cards.Add(component);
		}
		SubmitCard(cards[0]);
	}

	public Perk GetRandomPerk(List<Perk> perkList)
	{
		if (perkList == null || perkList.Count == 0)
		{
			Debug.LogWarning("Perk table is empty!");
			return null;
		}
		float num = 0f;
		foreach (Perk perk in perkList)
		{
			Debug.Log(perk.name + " :: " + perk.spawnSettings.GetEffectiveSpawnChance());
			num += perk.spawnSettings.GetEffectiveSpawnChance();
		}
		float num2 = (float)(rng.NextDouble() * (double)num);
		float num3 = 0f;
		foreach (Perk perk2 in perkList)
		{
			num3 += perk2.spawnSettings.GetEffectiveSpawnChance();
			if (num2 <= num3)
			{
				perk2.spawnSettings.OnSpawn();
				return perk2;
			}
		}
		return null;
	}

	private void GenerateIcons()
	{
		foreach (Transform item in iconParent.transform)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
		List<Perk> list = CL_GameManager.gMan.localPlayer.perks;
		if (list.Count == 0)
		{
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			Image image = UnityEngine.Object.Instantiate(iconAsset, iconParent.position, Quaternion.identity, iconParent);
			image.sprite = list[i].icon;
			image.GetComponent<OS_Tooltip>().tip = $"{list[i].GetTitle(includeColor: true)}<color=#C7C7C7> ({list[i].stackAmount}x)\n<color=\"grey\">{list[i].GetDescription(adjusted: true, total: true)}</color>";
			if (list[i].GetStackAmount() > 1)
			{
				image.GetComponentInChildren<TMP_Text>().text = $"x{list[i].GetStackAmount()}";
			}
		}
	}

	public void SelectCard(App_PerkPage_Card selection)
	{
		foreach (App_PerkPage_Card card in cards)
		{
			if (card != selection)
			{
				if (card != selectedCard)
				{
					card.DeselectCard();
				}
			}
			else if (card != selectedCard)
			{
				card.SelectCard();
			}
			card.UpdateCard();
		}
	}

	public void SubmitCard(App_PerkPage_Card selection)
	{
		foreach (App_PerkPage_Card card in cards)
		{
			if (card != selection)
			{
				card.DeselectCard();
			}
			else
			{
				card.SubmitCard();
				selectedCard = selection;
			}
			card.UpdateCard();
		}
	}

	public void PurchaseSelected()
	{
		if (selectedCard == null || CL_GameManager.IsIronKnuckle() || !selectedCard.CanAfford())
		{
			return;
		}
		fullfilled = true;
		reloadSettingsRoot.SetActive(value: false);
		foreach (App_PerkPage_Card card in cards)
		{
			if (card != selectedCard)
			{
				card.DisableCard();
			}
			else
			{
				card.BuyCard();
			}
			card.LockCard();
			card.UpdateCard();
		}
		purchaseButton.interactable = false;
		if (os.worldInterface.computerID != "")
		{
			CL_GameManager.SetGameFlag("recieved-" + os.worldInterface.computerID + "-perk", state: true);
		}
		if (perkPageType == PerkPageType.regular)
		{
			StartCoroutine(StandardPurchaseSequence());
			os.audioClipHandler.PlaySound("perk:buy");
		}
		else if (perkPageType == PerkPageType.unstable)
		{
			StartCoroutine(UnstablePurchaseSequence());
		}
	}

	private IEnumerator StandardPurchaseSequence()
	{
		os.audioClipHandler.PlaySound("os:error");
		OS_Window purchaseWindow = os.CreateAppWindow(fulfillmentWindow, window.id + "-purchase");
		while (purchaseWindow != null)
		{
			yield return null;
		}
		os.cameraControl.EndTakeover();
		os.SetInteractable(b: false);
		while (os.cameraControl.isTakingOver)
		{
			yield return null;
		}
		ENT_Player.playerObject.Lock();
		ENT_Player.playerObject.UnlockCamera();
		ENT_Player.playerObject.hands[0].SetLocked(b: true);
		ENT_Player.playerObject.hands[1].SetLocked(b: false);
		os.canControl = false;
		os.worldInterface.lever.SetInteractable(b: true);
		ENT_Player.playerObject.SetInteractWhitelist(new List<string> { "Injection-Lever" });
		while (!os.worldInterface.systemData.leverPulled)
		{
			ENT_Player.playerObject.hands[0].MoveTo(os.worldInterface.handPositions[0].position, Vector3.one * 0.65f);
			ENT_Player.playerObject.hands[0].SetSprite(ENT_Player.playerObject.hands[0].GetPoseSprite("normal"));
			yield return null;
		}
		Debug.Log(os.worldInterface.systemData.leverPulled);
		ENT_Player.playerObject.hands[1].SetLocked(b: true);
		float timer = 0f;
		while (timer < 0.5f)
		{
			ENT_Player.playerObject.hands[0].MoveTo(os.worldInterface.handPositions[0].position, Vector3.one * 0.65f);
			ENT_Player.playerObject.hands[0].SetSprite(ENT_Player.playerObject.hands[0].GetPoseSprite("normal"));
			ENT_Player.playerObject.hands[1].MoveTo(os.worldInterface.lever.transform.GetChild(0).transform.position, Vector3.one * 0.65f);
			ENT_Player.playerObject.hands[1].SetSprite(ENT_Player.playerObject.hands[0].GetPoseSprite("grab"));
			timer += Time.deltaTime;
			yield return null;
		}
		os.worldInterface.lever.SetInteractable(b: false);
		os.worldInterface.lever.SetState(b: false);
		ENT_Player.playerObject.StopInteractWhitelist();
		window.os.audioClipHandler.PlaySound("perk:inject");
		CL_GameManager.gMan.localPlayer.Damage(Damageable.DamageInfo.CreateDamageInfo(5f, "nonlethal"));
		CL_GameManager.gMan.localPlayer.hands[0].SetGripStrength(0.5f);
		CL_GameManager.gMan.localPlayer.AddPerk(UnityEngine.Object.Instantiate(selectedCard.perk));
		BuffContainer newBuff = new BuffContainer();
		newBuff.loseOverTime = true;
		newBuff.loseRate = 0.05f;
		newBuff.buffs = new List<BuffContainer.Buff>();
		newBuff.buffs.Add(new BuffContainer.Buff
		{
			id = "pilled",
			maxAmount = 0.5f
		});
		newBuff.SetMultiplier(1f);
		newBuff.Initialize();
		os.worldInterface.GetEventController().PlayEvent("injector-plunge");
		CL_UIManager.instance.SetVignette("bloodied", 1f);
		ENT_Player.GetPlayer().SplatterScreenBlood(5);
		for (timer = 0f; timer < 0.5f; timer += Time.deltaTime)
		{
			ENT_Player.playerObject.hands[0].MoveTo(os.worldInterface.handPositions[0].position, Vector3.one * 0.65f);
			ENT_Player.playerObject.hands[0].SetSprite(ENT_Player.playerObject.hands[0].GetPoseSprite("open"));
			ENT_Player.playerObject.hands[1].MoveTo(os.worldInterface.lever.transform.GetChild(0).transform.position, Vector3.one * 0.65f);
			ENT_Player.playerObject.hands[1].SetSprite(ENT_Player.playerObject.hands[0].GetPoseSprite("grab"));
			yield return null;
		}
		timer = 0f;
		while (timer < 0.5f)
		{
			ENT_Player.playerObject.hands[0].MoveTo(os.worldInterface.handPositions[0].position, Vector3.one * 0.65f);
			ENT_Player.playerObject.hands[0].SetSprite(ENT_Player.playerObject.hands[0].GetPoseSprite("normal"));
			ENT_Player.playerObject.hands[1].MoveTo(os.worldInterface.lever.transform.GetChild(0).transform.position, Vector3.one * 0.65f);
			ENT_Player.playerObject.hands[1].SetSprite(ENT_Player.playerObject.hands[0].GetPoseSprite("grab"));
			timer += Time.deltaTime;
			yield return null;
		}
		ENT_Player.playerObject.hands[0].SetLocked(b: false);
		ENT_Player.playerObject.hands[1].SetLocked(b: false);
		CL_GameManager.gMan.localPlayer.curBuffs.AddBuff(newBuff);
		GenerateIcons();
		yield return new WaitForSeconds(0.5f);
		CL_UIManager.instance.SetVignetteTarget("bloodied", 0f);
		CL_AchievementManager.SetAchievementValue("ACH_GETPERK", b: true);
		os.Deactivate();
	}

	private IEnumerator UnstablePurchaseSequence()
	{
		os.SetInteractable(b: false);
		yield return new WaitForSeconds(0.1f);
		os.audioClipHandler.PlaySound("os:error");
		CL_AchievementManager.SetAchievementValue("ACH_GETUNSTABLEPERK", b: true);
		yield return new WaitForSeconds(0.1f);
		window.os.audioClipHandler.PlaySound("perk:unstable-inject");
		CL_GameManager.gMan.localPlayer.AddPerk(UnityEngine.Object.Instantiate(selectedCard.perk));
		BuffContainer buffContainer = new BuffContainer();
		buffContainer.loseOverTime = true;
		buffContainer.loseRate = 0.05f;
		buffContainer.buffs = new List<BuffContainer.Buff>();
		buffContainer.buffs.Add(new BuffContainer.Buff
		{
			id = "pilled",
			maxAmount = 0.5f
		});
		buffContainer.SetMultiplier(1f);
		buffContainer.Initialize();
		os.worldInterface.GetEventController().PlayEvent("buy-perk");
		CL_UIManager.instance.SetVignette("bloodied", 1f);
		CL_GameManager.gMan.localPlayer.curBuffs.AddBuff(buffContainer);
		GenerateIcons();
		yield return new WaitForSeconds(0.5f);
		CL_UIManager.instance.SetVignetteTarget("bloodied", 0f);
		os.SetInteractable(b: true);
		os.Deactivate();
	}

	public void PurchaseRefresh()
	{
		if (!fullfilled && CL_GameManager.GetRoaches() >= refreshCost)
		{
			CL_GameManager.AddRoaches(-refreshCost);
			GenerateCards(refresh: true);
		}
	}
}
