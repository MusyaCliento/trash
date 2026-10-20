using UnityEngine;

public class UT_SeededEnable : MonoBehaviour
{
	public bool enableOnCustomSeed = true;

	private void OnEnable()
	{
		CheckStatus();
	}

	public void CheckStatus()
	{
		if (enableOnCustomSeed ? (!WorldLoader.customSeed) : WorldLoader.customSeed)
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
