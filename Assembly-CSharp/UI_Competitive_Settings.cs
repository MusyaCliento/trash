using System;
using System.Collections.Generic;
using UnityEngine;

public class UI_Competitive_Settings : MonoBehaviour
{
	[Serializable]
	public class LockerItemOptions
	{
		public Sprite lockerSprite;

		public string lockerItemID;

		internal UI_IconPicker currentIcon;

		[TextArea(2, 3)]
		public string tooltip;
	}

	[Serializable]
	public class LockerSetting
	{
		public List<LockerItemOptions> lockerItemOptions;

		public Transform lockerItemRoot;

		internal LockerItemOptions currentSelection;
	}

	public List<LockerSetting> lockers;

	public UI_IconPicker iconPickerAsset;

	private void OnEnable()
	{
		for (int i = 0; i < lockers.Count; i++)
		{
			PopulateItems(lockers[i], i);
		}
	}

	public void PopulateItems(LockerSetting locker, int id)
	{
		foreach (Transform item in locker.lockerItemRoot)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
		if (locker.lockerItemOptions == null || locker.lockerItemOptions.Count == 0)
		{
			return;
		}
		if (SettingsManager.settings.competitiveSettings == null)
		{
			SettingsManager.settings.competitiveSettings = new SettingsManager.GameSettings.CompetitiveSettings();
			SettingsManager.settings.competitiveSettings.lockerItems = new List<string>();
		}
		if (SettingsManager.settings.competitiveSettings.lockerItems == null || SettingsManager.settings.competitiveSettings.lockerItems.Count < lockers.Count)
		{
			SettingsManager.settings.competitiveSettings.lockerItems = new List<string> { "Item_Injector", "Item_Pillbottle" };
		}
		Debug.Log(SettingsManager.settings.competitiveSettings.lockerItems.Count);
		string text = SettingsManager.settings.competitiveSettings.lockerItems[id];
		foreach (LockerItemOptions lockerItemOption in locker.lockerItemOptions)
		{
			UI_IconPicker uI_IconPicker = UnityEngine.Object.Instantiate(iconPickerAsset, locker.lockerItemRoot);
			uI_IconPicker.onSelect = (Action<UI_IconPicker>)Delegate.Combine(uI_IconPicker.onSelect, new Action<UI_IconPicker>(OnSelect));
			lockerItemOption.currentIcon = uI_IconPicker;
			uI_IconPicker.Initialize(lockerItemOption.lockerSprite, this);
			uI_IconPicker.GetComponent<OS_Tooltip>().tip = lockerItemOption.tooltip;
			if (text == lockerItemOption.lockerItemID)
			{
				uI_IconPicker.Activate();
			}
			else
			{
				uI_IconPicker.Deactivate();
			}
		}
	}

	public void OnSelect(UI_IconPicker icon)
	{
		int num = -1;
		for (int i = 0; i < lockers.Count; i++)
		{
			foreach (LockerItemOptions lockerItemOption in lockers[i].lockerItemOptions)
			{
				if (lockerItemOption.currentIcon == icon)
				{
					num = i;
					break;
				}
			}
		}
		if (num == -1)
		{
			return;
		}
		foreach (LockerItemOptions lockerItemOption2 in lockers[num].lockerItemOptions)
		{
			if (lockerItemOption2.currentIcon == icon)
			{
				lockerItemOption2.currentIcon.Activate();
				SettingsManager.settings.competitiveSettings.lockerItems[num] = lockerItemOption2.lockerItemID;
			}
			else
			{
				lockerItemOption2.currentIcon.Deactivate();
			}
		}
	}
}
