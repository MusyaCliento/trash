using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class App_FacilitySlotHolder : MonoBehaviourGizmos
{
	public class UpgradePage
	{
		public SlotSystem slotSystem;

		public List<App_Facility_Card> upgradeCards;
	}

	public Transform slotOrigin;

	public float slotSize = 32f;

	private List<FacilityUpgrade> upgrades;

	private List<FacilityUpgrade> globalUpgrades;

	public App_Facility_Card facilityCardAsset;

	public Facility globalFacility;

	private Facility facilityAsset;

	private OS_Window window;

	private OS_Manager os;

	public SlotSystem slotSystem;

	public Transform globalUpgradePageRoot;

	public Transform sectorUpgradePageRoot;

	private List<UpgradePage> globalUpgradePages;

	private List<UpgradePage> sectorUpgradePages;

	private int sectorPage;

	private int globalPage;

	public GameObject globalUpgradeArrowRoot;

	public GameObject sectorUpgradeArrowRoot;

	public TMP_Text globalTitle;

	public TMP_Text sectorTitle;

	public AudioClip installUpgradeSound;

	public AudioClip installLoadSound;

	public UnityEvent onUpgradeInstalled;

	public GameObject upgradeFinishPopup;

	private UpgradePage currentPage;

	private void Awake()
	{
		window = GetComponent<OS_Window>();
		OS_Window oS_Window = window;
		oS_Window.openAction = (Action)Delegate.Combine(oS_Window.openAction, new Action(OnOpen));
	}

	private void Start()
	{
		os = window.os;
		upgradeFinishPopup.SetActive(value: false);
		slotSystem.Initialize();
		facilityAsset = CL_AssetManager.GetFacilityAsset(os.worldInterface.facilityID);
		if (facilityAsset == null)
		{
			Debug.LogError("No Facility Found with ID: " + os.worldInterface.facilityID);
			return;
		}
		upgrades = facilityAsset.GetUpgrades();
		globalUpgrades = globalFacility.GetUpgrades();
		FillPagesWithUpgrade(upgrades, ref sectorUpgradePages, sectorUpgradePageRoot, facilityAsset);
		SetPage(sectorUpgradePages, ref sectorPage, sectorTitle, "Sector");
		FillPagesWithUpgrade(globalUpgrades, ref globalUpgradePages, globalUpgradePageRoot, globalFacility);
		if (sectorUpgradePages.Count > 1)
		{
			sectorUpgradeArrowRoot.SetActive(value: true);
		}
		else
		{
			sectorUpgradeArrowRoot.SetActive(value: false);
		}
		if (globalUpgradePages.Count > 1)
		{
			globalUpgradeArrowRoot.SetActive(value: true);
		}
		else
		{
			globalUpgradeArrowRoot.SetActive(value: false);
		}
		SetPage(globalUpgradePages, ref globalPage, globalTitle, "Global");
	}

	private void OnOpen()
	{
		CheckCompetitive();
	}

	private void CheckCompetitive()
	{
		if (CL_GameManager.gamemode.IsCompetitive())
		{
			Message_Manager.Message_Packet message_Packet = new Message_Manager.Message_Packet();
			message_Packet.type = "default";
			message_Packet.closeText = "Quit";
			message_Packet.closeFunction = window.CloseApp;
			message_Packet.message = "You are playing in COMPETITIVE mode. All facility upgrades are unlocked.";
			message_Packet.screenPos = new Vector2(0f, 0f);
			window.os.messageManager.CreateMessage(message_Packet);
		}
		else if (CL_GameManager.GetBaseGamemode().HasActiveSetting("unlimited"))
		{
			Message_Manager.Message_Packet message_Packet2 = new Message_Manager.Message_Packet();
			message_Packet2.type = "default";
			message_Packet2.closeText = "Quit";
			message_Packet2.closeFunction = window.CloseApp;
			message_Packet2.message = "You are playing in UNLIMITED mode. You cannot purchase Facility Upgrades.";
			message_Packet2.screenPos = new Vector2(0f, 0f);
			window.os.messageManager.CreateMessage(message_Packet2);
		}
	}

	public void FillPagesWithUpgrade(List<FacilityUpgrade> pageUpgrades, ref List<UpgradePage> pageList, Transform parent, Facility facility)
	{
		if (pageList == null)
		{
			pageList = new List<UpgradePage>();
		}
		if (pageList.Count == 0)
		{
			pageList.Add(new UpgradePage());
			pageList[0].slotSystem = new SlotSystem();
			pageList[0].slotSystem.width = slotSystem.width;
			pageList[0].slotSystem.height = slotSystem.height;
			pageList[0].slotSystem.Initialize();
			pageList[0].upgradeCards = new List<App_Facility_Card>();
		}
		UpgradePage upgradePage = pageList[pageList.Count - 1];
		foreach (FacilityUpgrade pageUpgrade in pageUpgrades)
		{
			bool flag = false;
			if (pageUpgrade == null)
			{
				continue;
			}
			int num = pageUpgrade.maxWidth - pageUpgrade.minWidth;
			int num2 = pageUpgrade.maxHeight - pageUpgrade.minHeight;
			Debug.Log("Attempting to place " + pageUpgrade.name);
			int num3 = 0;
			while (!flag && num3 < 50)
			{
				num3++;
				for (int i = 0; i <= num; i++)
				{
					if (flag)
					{
						break;
					}
					for (int j = 0; j <= num2; j++)
					{
						if (flag)
						{
							break;
						}
						int num4 = pageUpgrade.maxWidth - i;
						int num5 = pageUpgrade.maxHeight - j;
						if (upgradePage.slotSystem.TryFindFreeRect(num4, num5, out var foundX, out var foundY))
						{
							App_Facility_Card app_Facility_Card = UnityEngine.Object.Instantiate(facilityCardAsset, base.transform.position, Quaternion.identity, slotOrigin);
							upgradePage.upgradeCards.Add(app_Facility_Card);
							flag = true;
							app_Facility_Card.width = num4;
							app_Facility_Card.height = num5;
							PlaceCard(foundX, foundY, app_Facility_Card, pageUpgrade, upgradePage.slotSystem);
							app_Facility_Card.transform.localPosition += Vector3.right * num4 * 32f / 2f + Vector3.up * num5 * 32f / 2f;
							app_Facility_Card.transform.parent = parent;
							app_Facility_Card.Initialize(pageUpgrade, StatManager.saveData.GetFacility(facility.id), this);
							break;
						}
						Debug.Log($"Cannot find spot for {pageUpgrade.name} + {num4} {num5}");
					}
				}
				if (!flag)
				{
					Debug.Log("Failed to Place Upgrade, creating new page.");
					pageList.Add(new UpgradePage());
					pageList[pageList.Count - 1].slotSystem = new SlotSystem();
					pageList[pageList.Count - 1].slotSystem.width = slotSystem.width;
					pageList[pageList.Count - 1].slotSystem.height = slotSystem.height;
					pageList[pageList.Count - 1].slotSystem.Initialize();
					pageList[pageList.Count - 1].upgradeCards = new List<App_Facility_Card>();
					upgradePage = pageList[pageList.Count - 1];
				}
			}
		}
	}

	public void AnimatePageLoad(UpgradePage page)
	{
		Debug.Log("Animating Cards: " + page.upgradeCards.Count);
		StartCoroutine(PageAnimation());
		IEnumerator PageAnimation()
		{
			for (int i = 0; i < page.upgradeCards.Count; i++)
			{
				App_Facility_Card app_Facility_Card = page.upgradeCards[i];
				if (app_Facility_Card.gameObject.activeInHierarchy)
				{
					app_Facility_Card.selectable = false;
					app_Facility_Card.transform.localScale = new Vector3(1f, 0f, 1f);
				}
			}
			for (int j = 0; j < page.upgradeCards.Count; j++)
			{
				App_Facility_Card upgradeCard = page.upgradeCards[j];
				if (upgradeCard.gameObject.activeInHierarchy)
				{
					upgradeCard.transform.DOScale(Vector3.one, 0.15f).SetDelay((float)j * 0.05f).OnComplete(delegate
					{
						upgradeCard.selectable = true;
					});
					upgradeCard.LoadAnimation((float)j * 0.05f + 0.01f);
				}
			}
			yield return null;
		}
	}

	public void OnChangeTab()
	{
		if (globalUpgradePageRoot.gameObject.activeInHierarchy)
		{
			AnimatePageLoad(globalUpgradePages[globalPage]);
		}
		else
		{
			AnimatePageLoad(sectorUpgradePages[sectorPage]);
		}
	}

	public void PlaceCard(int x, int y, App_Facility_Card card, FacilityUpgrade upgrade, SlotSystem sS)
	{
		foreach (SlotSystem.Slot slot in sS.GetSlots(x, y, card.width, card.height))
		{
			slot.filled = true;
		}
		card.transform.parent = sectorUpgradePageRoot;
		card.transform.position = GetSlotPosition(x, y) - Vector3.one * 16f;
	}

	public Vector3 GetSlotPosition(int x, int y)
	{
		Vector3 vector = new Vector3(slotSize / 2f, slotSize / 2f, 0f);
		vector += sectorUpgradePageRoot.right * slotSize * x;
		vector += sectorUpgradePageRoot.up * slotSize * y;
		vector = sectorUpgradePageRoot.TransformVector(vector);
		return vector + sectorUpgradePageRoot.position;
	}

	public override void DrawGizmos()
	{
		Draw.SphereOutline(base.transform.position, 0.2f, Color.yellow);
		if (!(sectorUpgradePageRoot != null))
		{
			return;
		}
		for (int i = 0; i < slotSystem.width; i++)
		{
			for (int j = 0; j < slotSystem.height; j++)
			{
				Draw.WirePlane(GetSlotPosition(i, j), sectorUpgradePageRoot.forward, slotSize, Color.green);
			}
		}
	}

	public void SetPage(List<UpgradePage> pageList, ref int pageNumber, TMP_Text titleObject, string title)
	{
		if (pageList != null && pageList.Count > 0)
		{
			if (pageNumber >= pageList.Count)
			{
				pageNumber = 0;
			}
			if (pageNumber < 0)
			{
				pageNumber = pageList.Count - 1;
			}
			for (int i = 0; i < pageList.Count; i++)
			{
				foreach (App_Facility_Card upgradeCard in pageList[i].upgradeCards)
				{
					if (i == pageNumber)
					{
						upgradeCard.gameObject.SetActive(value: true);
						currentPage = pageList[i];
					}
					else
					{
						upgradeCard.gameObject.SetActive(value: false);
					}
				}
				pageList[i].upgradeCards[0].GetComponent<Selectable>().Select();
			}
			AnimatePageLoad(currentPage);
			if (pageList.Count > 1)
			{
				titleObject.text = $"{title} ({pageNumber + 1}/{pageList.Count})";
			}
			else
			{
				titleObject.text = title;
			}
		}
		else
		{
			titleObject.text = title;
		}
	}

	public void OnPurchaseUpgrade(App_Facility_Card card)
	{
		Message_Manager.Message_Packet message_Packet = new Message_Manager.Message_Packet();
		message_Packet.type = "loading";
		message_Packet.closeText = "OK";
		message_Packet.message = "Installing..";
		message_Packet.screenPos = new Vector2(0f, 0f);
		message_Packet.data = new List<string> { "1" };
		message_Packet.closeFunction = Finish;
		window.os.messageManager.CreateMessage(message_Packet);
		AudioManager.PlayUISound(installLoadSound);
		void Finish()
		{
			AudioManager.PlayUISound(installUpgradeSound);
			onUpgradeInstalled.Invoke();
			upgradeFinishPopup.SetActive(value: true);
			DOTween.Complete(upgradeFinishPopup.transform);
			upgradeFinishPopup.transform.DOPunchScale(Vector3.one * 0.1f, 0.5f);
		}
	}

	public void ChangeSectorPage(int i)
	{
		sectorPage += i;
		SetPage(sectorUpgradePages, ref sectorPage, sectorTitle, "Sector");
	}

	public void ChangeGlobalPage(int i)
	{
		globalPage += i;
		SetPage(globalUpgradePages, ref globalPage, globalTitle, "Global");
	}

	public void SelectFirstCard()
	{
	}
}
