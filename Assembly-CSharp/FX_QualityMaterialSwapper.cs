using System;
using UnityEngine;

public class FX_QualityMaterialSwapper : MonoBehaviour
{
	public string settingName;

	public bool disableOnActive;

	private Renderer renderer;

	public Material activeMaterial;

	public Material inactiveMaterial;

	private void Start()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Combine(SettingsManager._OnRefreshAllSettings, new Action(QualityCheck));
		renderer = GetComponent<Renderer>();
		QualityCheck();
	}

	private void OnDestroy()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Remove(SettingsManager._OnRefreshAllSettings, new Action(QualityCheck));
	}

	public void QualityCheck()
	{
		bool flag = bool.Parse(SettingsManager.GetSetting(settingName));
		if (disableOnActive)
		{
			base.gameObject.SetActive(!flag);
		}
		else
		{
			renderer.material = (flag ? activeMaterial : inactiveMaterial);
		}
	}
}
