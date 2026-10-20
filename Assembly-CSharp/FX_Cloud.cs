using System;
using UnityEngine;

public class FX_Cloud : MonoBehaviour
{
	public bool force;

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
		if (SettingsManager.settings.cloudQuality >= 2)
		{
			base.gameObject.SetActive(value: true);
		}
		else if (SettingsManager.settings.cloudQuality == 1)
		{
			if (!force)
			{
				base.gameObject.SetActive(rand > 0.5f);
			}
			else
			{
				base.gameObject.SetActive(value: true);
			}
		}
		else if (SettingsManager.settings.cloudQuality == 0)
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
