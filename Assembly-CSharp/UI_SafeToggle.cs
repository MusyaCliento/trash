using UnityEngine;

public class UI_SafeToggle : MonoBehaviour
{
	public enum SafeToggleType
	{
		onSafe = 0,
		onHasSession = 1
	}

	public SafeToggleType type;

	public GameObject toggleObject;

	public bool invertCheck;

	private void OnEnable()
	{
		if (type == SafeToggleType.onSafe)
		{
			toggleObject.SetActive(CL_GameManager.IsSafe() ? (!invertCheck) : invertCheck);
			return;
		}
		bool flag = CL_SaveManager.GetMostRecentSaveStateWithFlag("session", contains: true) != null;
		bool active = ((CL_SaveManager.GetMostRecentSaveStateWithFlag("disk") != null) ? (!invertCheck) : invertCheck);
		Debug.Log("Safe Toggle: " + toggleObject?.ToString() + " : " + active + " Has Session: " + flag);
		toggleObject.SetActive(active);
	}
}
