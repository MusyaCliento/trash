using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ToggleSettingsBinder : MonoBehaviour
{
	public string settingName;

	private Toggle toggle;

	public bool tiedToSetting;

	public bool invertTiedActive;

	public string tiedSetting;

	public UnityEvent onUpdateSetting;

	private void Start()
	{
		toggle = GetComponent<Toggle>();
		PullSetting();
		toggle.onValueChanged.AddListener(delegate
		{
			UpdateSetting();
		});
		RefreshInteractable();
	}

	private void OnEnable()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Combine(SettingsManager._OnRefreshAllSettings, new Action(OnSettingsChange));
	}

	private void OnDisable()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Remove(SettingsManager._OnRefreshAllSettings, new Action(OnSettingsChange));
	}

	private void PullSetting()
	{
		string setting = SettingsManager.GetSetting(settingName);
		toggle.SetIsOnWithoutNotify(bool.Parse(setting));
	}

	public void UpdateSetting()
	{
		SettingsManager.SetSetting(new string[2]
		{
			settingName,
			toggle.isOn.ToString()
		});
		SettingsManager.RefreshSettings(settingName);
		onUpdateSetting.Invoke();
	}

	public void OnSettingsChange()
	{
		RefreshInteractable();
	}

	public void RefreshInteractable()
	{
		if (toggle == null)
		{
			return;
		}
		if (tiedToSetting)
		{
			if (toggle == null)
			{
				return;
			}
			bool flag = bool.Parse(SettingsManager.GetSetting(tiedSetting));
			toggle.interactable = (invertTiedActive ? flag : (!flag));
		}
		bool result = false;
		bool.TryParse(SettingsManager.GetSetting(settingName), out result);
		if (result != toggle.isOn)
		{
			toggle.SetIsOnWithoutNotify(result);
		}
	}
}
