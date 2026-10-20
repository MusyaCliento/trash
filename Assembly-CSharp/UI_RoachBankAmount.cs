using System;
using TMPro;
using UnityEngine;

public class UI_RoachBankAmount : MonoBehaviour
{
	public string roachBankID;

	private TMP_Text text;

	private void Awake()
	{
		text = GetComponent<TMP_Text>();
	}

	private void OnEnable()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Combine(SettingsManager._OnRefreshAllSettings, new Action(Refresh));
		Refresh();
	}

	private void OnDisable()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Remove(SettingsManager._OnRefreshAllSettings, new Action(Refresh));
	}

	public void Refresh()
	{
		text.text = StatManager.saveData.GetRoachBankByID(roachBankID).value.ToString();
	}
}
