using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class App_Facility_Card : MonoBehaviour, ISelectHandler, IEventSystemHandler, ISubmitHandler, IPointerClickHandler, IDeselectHandler, ICancelHandler, IPointerEnterHandler, IPointerExitHandler
{
	public int width = 3;

	public int height = 2;

	public TMP_Text titleText;

	public OS_Tooltip tooltip;

	public Image art;

	public TMP_Text costText;

	public GameObject purchasedObject;

	public GameObject lockedObject;

	public TMP_Text lockedText;

	private FacilityUpgrade upgrade;

	private StatManager.SaveData.Facility facility;

	private bool selected;

	private bool hovered;

	private Vector3 startLocalPosition;

	private bool locked;

	private App_FacilitySlotHolder slotHolder;

	internal bool selectable = true;

	public GameObject loadingObject;

	private void Awake()
	{
		Facility.onPurchaseUpgrade = (Action)Delegate.Combine(Facility.onPurchaseUpgrade, new Action(CheckLock));
	}

	private void OnDestroy()
	{
		Facility.onPurchaseUpgrade = (Action)Delegate.Remove(Facility.onPurchaseUpgrade, new Action(CheckLock));
	}

	public void Initialize(FacilityUpgrade up, StatManager.SaveData.Facility fac, App_FacilitySlotHolder holder)
	{
		GetComponent<RectTransform>().sizeDelta = new Vector2(width * 32 - 1, height * 32 - 1);
		facility = fac;
		this.upgrade = up;
		slotHolder = holder;
		titleText.text = this.upgrade.cardName;
		tooltip.tip = this.upgrade.description;
		if (this.upgrade.cardArt != null)
		{
			art.sprite = this.upgrade.cardArt;
		}
		costText.text = this.upgrade.GetCost(fac.id).ToString();
		StatManager.SaveData.Facility.Upgrade upgrade = facility.GetUpgrade(this.upgrade.id);
		if (upgrade != null && upgrade.owned)
		{
			purchasedObject.SetActive(value: true);
		}
		startLocalPosition = base.transform.localPosition;
		CheckLock();
	}

	public void CheckLock()
	{
		bool flag = false;
		if (!string.IsNullOrEmpty(upgrade.unlockFlag) && !CL_GameManager.HasActiveFlag(upgrade.unlockFlag, useUnlockAll: true))
		{
			flag = true;
		}
		if (upgrade.prerequisiteUpgrade != null && !facility.HasUpgrade(upgrade.prerequisiteUpgrade.id))
		{
			flag = true;
		}
		if (flag)
		{
			lockedObject.SetActive(value: true);
			tooltip.tip = "<color=red>LOCKED\n" + upgrade.unlockDesc + "</color>\n" + upgrade.description;
			locked = true;
		}
		else
		{
			lockedObject.SetActive(value: false);
			tooltip.tip = upgrade.description;
			locked = false;
		}
	}

	public void PurchaseUpgrade()
	{
		StatManager.SaveData.Facility.Upgrade upgrade = facility.GetUpgrade(this.upgrade.id);
		if (locked)
		{
			Message_Manager.Message_Packet message_Packet = new Message_Manager.Message_Packet();
			message_Packet.type = "default";
			message_Packet.closeText = "Close";
			message_Packet.message = "<color=red>Upgrade is locked\n" + this.upgrade.unlockDesc;
			message_Packet.screenPos = new Vector2(0f, 0f);
			OS_Manager.GetCurrentOS().messageManager.CreateMessage(message_Packet);
		}
		else if (upgrade != null && upgrade.owned)
		{
			Message_Manager.Message_Packet message_Packet2 = new Message_Manager.Message_Packet();
			message_Packet2.type = "default";
			message_Packet2.closeText = "Close";
			message_Packet2.message = "Upgrade already owned.";
			message_Packet2.screenPos = new Vector2(0f, 0f);
			OS_Manager.GetCurrentOS().messageManager.CreateMessage(message_Packet2);
		}
		else if (CL_GameManager.GetCombinedRoaches() >= this.upgrade.GetCost(facility.id))
		{
			int num = 0;
			int num2 = this.upgrade.GetCost(facility.id);
			if (CL_GameManager.GetRoaches(global: true) < num2)
			{
				int num3 = this.upgrade.GetCost(facility.id) - CL_GameManager.GetRoaches(global: true);
				num2 = CL_GameManager.GetRoaches(global: true);
				num = num3;
			}
			string message = $"Purchase {this.upgrade.cardName} for:\n<color=red><sprite=\"os_text_icons\" name=\"credits\">{this.upgrade.GetCost(facility.id)} Facility Credits</color>?";
			if (num > 0)
			{
				message = $"Purchase {this.upgrade.cardName} for:\n<color=red><sprite=\"os_text_icons\" name=\"credits\">{num2} Facility Credits</color>\n<color=yellow><sprite=\"os_text_icons\" name=\"roach\">{num} Banked Roaches</color>?";
			}
			Message_Manager.Message_Packet message_Packet3 = new Message_Manager.Message_Packet();
			message_Packet3.type = "default";
			message_Packet3.closeText = "Buy";
			message_Packet3.aText = "Cancel";
			message_Packet3.closeFunction = FinishPurchase;
			message_Packet3.optionAFunction = Cancel;
			message_Packet3.message = message;
			message_Packet3.screenPos = new Vector2(0f, 0f);
			OS_Manager.GetCurrentOS().messageManager.CreateMessage(message_Packet3);
		}
		else
		{
			Message_Manager.Message_Packet message_Packet4 = new Message_Manager.Message_Packet();
			message_Packet4.type = "default";
			message_Packet4.closeText = "Close";
			message_Packet4.message = "You have insufficient funds to purchase this.";
			message_Packet4.screenPos = new Vector2(0f, 0f);
			OS_Manager.GetCurrentOS().messageManager.CreateMessage(message_Packet4);
		}
		static void Cancel()
		{
		}
		void FinishPurchase()
		{
			this.upgrade.Purchase(facility);
			slotHolder.OnPurchaseUpgrade(this);
			purchasedObject.SetActive(value: true);
		}
	}

	public void Select()
	{
		OS_Manager.activeComputer.audioClipHandler.PlaySound("perk:highlight");
		HoverEnter();
		selected = true;
	}

	public void LoadAnimation(float delay = 0f)
	{
		Color endValue = Color.black;
		if (locked)
		{
			endValue = Color.grey;
		}
		else if (art.sprite != null)
		{
			endValue = Color.white;
		}
		art.color = Color.black;
		loadingObject.SetActive(value: true);
		art.DOColor(endValue, 0.25f).SetDelay(delay).OnComplete(delegate
		{
			loadingObject.SetActive(value: false);
		});
	}

	public void HoverEnter()
	{
		if (selectable)
		{
			if (!hovered)
			{
				base.transform.DOComplete();
				base.transform.DOLocalMove(startLocalPosition + Vector3.up * 1f, 0.25f);
				art.color = Color.red;
			}
			hovered = true;
		}
	}

	private void HoverLeave()
	{
		if (!selectable)
		{
			return;
		}
		if (hovered)
		{
			base.transform.DOComplete();
			base.transform.DOLocalMove(startLocalPosition, 0.25f);
			if (locked)
			{
				art.color = Color.grey;
			}
			else if (art.sprite != null)
			{
				art.color = Color.white;
			}
			else
			{
				art.color = Color.black;
			}
		}
		hovered = false;
	}

	public void Deselect()
	{
		HoverLeave();
		selected = false;
	}

	public void Submit()
	{
		OS_Manager.activeComputer.audioClipHandler.PlaySound("perk:select");
		PurchaseUpgrade();
		selected = true;
	}

	void ISubmitHandler.OnSubmit(BaseEventData eventData)
	{
		Submit();
	}

	public void OnSelect(BaseEventData eventData)
	{
		Select();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Submit();
	}

	public void OnDeselect(BaseEventData eventData)
	{
		Deselect();
	}

	public void OnCancel(BaseEventData eventData)
	{
		Deselect();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		HoverEnter();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		HoverLeave();
	}
}
