using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FacilityMenu : MonoBehaviour
{
	public Facility globalFacility;

	public UI_FacilityMenu_Button upgradeButtonAsset;

	public Transform upgradeRoot;

	private List<UI_FacilityMenu_Button> upgradeButtons = new List<UI_FacilityMenu_Button>();

	public GameObject installCompletePopup;

	public AudioClip installStartAudio;

	public AudioClip installFinishAudio;

	private void Start()
	{
		installCompletePopup.gameObject.SetActive(value: false);
		FillUpgrades();
	}

	public void FillUpgrades()
	{
		foreach (FacilityUpgrade upgrade in globalFacility.upgrades)
		{
			UI_FacilityMenu_Button uI_FacilityMenu_Button = Object.Instantiate(upgradeButtonAsset, upgradeRoot);
			uI_FacilityMenu_Button.Initialize(upgrade, this, globalFacility);
			upgradeButtons.Add(uI_FacilityMenu_Button);
		}
	}

	internal void PurchaseUpgrade(FacilityUpgrade upgrade)
	{
		Message_Manager.Message_Packet message_Packet = new Message_Manager.Message_Packet();
		message_Packet.type = "loading";
		message_Packet.closeText = "OK";
		message_Packet.message = "Installing..";
		message_Packet.screenPos = new Vector2(0f, 0f);
		message_Packet.data = new List<string> { "1" };
		message_Packet.closeFunction = Finish;
		CL_OverlayUIManager.instance.messageManager.CreateMessage(message_Packet);
		AudioManager.PlayUISound(installStartAudio, 0.8f);
		void Finish()
		{
			installCompletePopup.SetActive(value: true);
			GetComponent<CanvasGroup>().interactable = false;
			installCompletePopup.transform.DOPunchScale(Vector3.one * 0.05f, 0.5f);
			AudioManager.PlayUISound(installFinishAudio, 0.8f);
			StatManager.saveData.GetRoachBankByID("campaign").value -= upgrade.cost;
			StatManager.saveData.GetRoachBankByID("campaign").value = Mathf.Max(StatManager.saveData.GetRoachBankByID("campaign").value, 0);
			upgrade.Purchase(globalFacility.id);
			SettingsManager._OnRefreshAllSettings?.Invoke();
			foreach (UI_FacilityMenu_Button upgradeButton in upgradeButtons)
			{
				upgradeButton.Refresh();
			}
			CL_ProgressionManager.UpdateUnlocks();
		}
	}

	public void OnClose()
	{
		if (OS_Tooltip_Manager.currentOSTooltip != null)
		{
			OS_Tooltip_Manager.currentOSTooltip.HideTip();
		}
		else if (OS_Tooltip_Manager.currentUITooltip != null)
		{
			OS_Tooltip_Manager.currentUITooltip.HideTip();
		}
	}
}
