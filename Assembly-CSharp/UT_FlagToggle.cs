using UnityEngine;

public class UT_FlagToggle : MonoBehaviour
{
	public string flag;

	public bool hideIfTrue;

	public bool useUnlockAll;

	private void OnEnable()
	{
		if (hideIfTrue)
		{
			base.gameObject.SetActive(!CL_GameManager.HasActiveFlag(flag, useUnlockAll));
		}
		else
		{
			base.gameObject.SetActive(CL_GameManager.HasActiveFlag(flag, useUnlockAll));
		}
	}
}
