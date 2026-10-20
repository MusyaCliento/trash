using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_FacilityMenu_Button : MonoBehaviour
{
	public Image buttonOutline;

	public TMP_Text titleText;

	public Button mainButton;

	private bool isSelected;

	public bool selectAnimation = true;

	private FacilityMenu facilityMenu;

	private Facility facility;

	private FacilityUpgrade upgrade;

	public GameObject lockRoot;

	public GameObject purchasedRoot;

	public GameObject expensiveRoot;

	public TMP_Text lockText;

	public TMP_Text costText;

	public UnityEvent OnActivate;

	public UnityEvent OnDeactivate;

	public Image icon;

	private OS_Tooltip tooltip;

	private bool isLocked;

	private void Awake()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Combine(SettingsManager._OnRefreshAllSettings, new Action(Refresh));
		tooltip = mainButton.GetComponent<OS_Tooltip>();
	}

	private void OnDestroy()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Remove(SettingsManager._OnRefreshAllSettings, new Action(Refresh));
	}

	public void Initialize(FacilityUpgrade upg, FacilityMenu cM, Facility f)
	{
		upgrade = upg;
		facilityMenu = cM;
		facility = f;
		titleText.text = upgrade.cardName;
		costText.text = upgrade.cost.ToString();
		if (upg.cardArt != null)
		{
			icon.sprite = upg.cardArt;
		}
		else
		{
			icon.gameObject.SetActive(value: false);
		}
		Refresh();
	}

	private void OnEnable()
	{
		Refresh();
	}

	private void Update()
	{
	}

	public void Select()
	{
		SettingsManager.RefreshSettings();
		DOTween.Complete(base.transform);
		if (selectAnimation)
		{
			base.transform.DOPunchScale(Vector3.one * 0.05f, 0.4f, 6);
		}
	}

	public void Refresh()
	{
		if (tooltip == null || upgrade == null)
		{
			return;
		}
		isLocked = false;
		expensiveRoot.gameObject.SetActive(value: false);
		tooltip.tip = upgrade.description;
		if (!upgrade.IsLocked(facility.id))
		{
			lockRoot.SetActive(value: false);
		}
		else
		{
			lockRoot.SetActive(value: true);
			lockText.text = upgrade.unlockDesc;
			isLocked = true;
			tooltip.tip = "<color=red>LOCKED\n" + upgrade.unlockDesc + "</color>\n" + upgrade.description;
		}
		bool flag = isSelected;
		if (upgrade.IsOwned(facility.id))
		{
			isSelected = true;
			purchasedRoot.SetActive(value: true);
		}
		else
		{
			isSelected = false;
			purchasedRoot.SetActive(value: false);
			if (!isLocked)
			{
				int value = StatManager.saveData.GetRoachBankByID("campaign").value;
				if (upgrade.cost > value)
				{
					tooltip.tip = "<color=red>CANNOT AFFORD\n</color>\n" + upgrade.description;
					expensiveRoot.gameObject.SetActive(value: true);
					isLocked = true;
				}
			}
		}
		buttonOutline.color = Color.clear;
		if (flag && !isSelected)
		{
			OnDeactivate.Invoke();
		}
		else if (!flag && isSelected)
		{
			OnActivate.Invoke();
		}
	}

	public void Purchase()
	{
		if (!isLocked && !upgrade.IsOwned(facility.id))
		{
			facilityMenu.PurchaseUpgrade(upgrade);
		}
	}
}
