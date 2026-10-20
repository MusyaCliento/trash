using System;
using DarkMachine.UI;
using UnityEngine;
using UnityEngine.UI;

public class SliderSettingBinder : MonoBehaviour
{
	public string settingName;

	private Slider slider;

	private SubmitSlider submitSlider;

	private float lastValue;

	public bool updateOnValueChanged = true;

	public int roundDigits = 2;

	private void Start()
	{
		slider = GetComponent<Slider>();
		submitSlider = GetComponent<SubmitSlider>();
		PullSetting();
		if (slider != null)
		{
			slider.onValueChanged.AddListener(delegate
			{
				UpdateOnValueChanged();
			});
		}
		else
		{
			submitSlider.onValueChanged.AddListener(delegate
			{
				UpdateOnValueChanged();
			});
		}
	}

	private void PullSetting()
	{
		string setting = SettingsManager.GetSetting(settingName);
		if (slider != null)
		{
			Math.Round(slider.value, 2);
			if (setting != null && !(slider == null))
			{
				slider.value = float.Parse(setting);
			}
		}
		else
		{
			Math.Round(submitSlider.value, 2);
			if (setting != null && !(submitSlider == null))
			{
				submitSlider.value = float.Parse(setting);
			}
		}
	}

	public void UpdateOnValueChanged()
	{
		if (updateOnValueChanged)
		{
			UpdateSetting();
		}
	}

	public void UpdateSetting()
	{
		float num = 0f;
		num = ((!(slider != null)) ? ((float)Math.Round(submitSlider.value, roundDigits)) : ((float)Math.Round(slider.value, roundDigits)));
		if (Mathf.Abs(num - lastValue) > Mathf.Epsilon)
		{
			lastValue = num;
			SettingsManager.SetSetting(new string[2]
			{
				settingName,
				num.ToString()
			});
			SettingsManager.RefreshSettings(settingName);
		}
	}
}
