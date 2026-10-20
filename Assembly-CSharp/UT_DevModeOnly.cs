using UnityEngine;

public class UT_DevModeOnly : MonoBehaviour
{
	public bool devOnly = true;

	public bool boothOnly;

	private void Start()
	{
		if (devOnly)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void OnEnable()
	{
		if (boothOnly)
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
