using UnityEngine;

public class UT_BuildTypeToggler : MonoBehaviour
{
	public SettingsManager.BuildType enableType;

	private void Awake()
	{
		if (SettingsManager.buildType != enableType)
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
