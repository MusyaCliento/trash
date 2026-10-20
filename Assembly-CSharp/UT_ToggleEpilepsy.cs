using UnityEngine;
using UnityEngine.Events;

public class UT_ToggleEpilepsy : MonoBehaviour
{
	public bool active;

	public UnityEvent epilepsyEnabled;

	public UnityEvent epilepsyDisabled;

	public UnityEvent toggleDisabled;

	private bool wasEpilepsyEnabled;

	private void OnEnable()
	{
		bool epilepsy = SettingsManager.settings.epilepsy;
		if (active && epilepsy)
		{
			epilepsyEnabled.Invoke();
		}
		if (active && !epilepsy)
		{
			epilepsyDisabled.Invoke();
		}
		if (active)
		{
			wasEpilepsyEnabled = epilepsy;
		}
	}

	private void OnDisable()
	{
		toggleDisabled.Invoke();
	}

	private void Update()
	{
		if (active && !CL_GameManager.gMan.isPaused)
		{
			bool epilepsy = SettingsManager.settings.epilepsy;
			if (!wasEpilepsyEnabled && epilepsy)
			{
				epilepsyEnabled.Invoke();
			}
			if (wasEpilepsyEnabled && !epilepsy)
			{
				epilepsyDisabled.Invoke();
			}
			wasEpilepsyEnabled = epilepsy;
		}
	}

	public void SetActive(bool state)
	{
		if (state != active)
		{
			bool epilepsy = SettingsManager.settings.epilepsy;
			if (!state && wasEpilepsyEnabled)
			{
				toggleDisabled.Invoke();
			}
			if (state && epilepsy)
			{
				epilepsyEnabled.Invoke();
			}
			if (state && !epilepsy)
			{
				epilepsyDisabled.Invoke();
			}
			active = state;
			wasEpilepsyEnabled = state && epilepsy;
		}
	}
}
