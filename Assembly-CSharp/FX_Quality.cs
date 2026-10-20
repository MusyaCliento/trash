using System;
using UnityEngine;

public class FX_Quality : MonoBehaviour
{
	public bool hideOnLowQuality = true;

	public int quality;

	private float rand;

	private void Start()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Combine(SettingsManager._OnRefreshAllSettings, new Action(QualityCheck));
		rand = UnityEngine.Random.value;
		QualityCheck();
	}

	private void OnDestroy()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Remove(SettingsManager._OnRefreshAllSettings, new Action(QualityCheck));
	}

	public void QualityCheck()
	{
		if (SettingsManager.settings.effectQuality >= 2)
		{
			if (hideOnLowQuality)
			{
				base.gameObject.SetActive(value: true);
			}
		}
		else if (SettingsManager.settings.effectQuality == 1)
		{
			if (hideOnLowQuality)
			{
				base.gameObject.SetActive(quality < SettingsManager.settings.effectQuality);
			}
		}
		else if (SettingsManager.settings.effectQuality == 0 && hideOnLowQuality)
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
