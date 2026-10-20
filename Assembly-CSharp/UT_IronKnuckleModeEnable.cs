using UnityEngine;
using UnityEngine.Events;

public class UT_IronKnuckleModeEnable : MonoBehaviour
{
	public bool disable;

	public UnityEvent onEnable;

	public UnityEvent onDisable;

	private void OnEnable()
	{
		CheckStatus();
	}

	public void CheckStatus()
	{
		if (CL_GameManager.GetBaseGamemode() == null)
		{
			base.gameObject.SetActive(value: false);
		}
		bool flag = (CL_GameManager.GetBaseGamemode().IsIronKnuckle() ? (!disable) : disable);
		if (flag)
		{
			onEnable?.Invoke();
		}
		else
		{
			onDisable?.Invoke();
		}
		base.gameObject.SetActive(flag);
	}
}
