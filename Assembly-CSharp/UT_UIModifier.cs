using UnityEngine;

public class UT_UIModifier : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	public void SetStatusBarProgress(float f)
	{
		FX_ProgressBar.SetBarValue(f);
	}
}
