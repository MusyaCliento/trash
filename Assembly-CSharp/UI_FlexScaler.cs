using UnityEngine;

public class UI_FlexScaler : MonoBehaviour
{
	public float minimumAspectRatio = 2.32f;

	public float scaleAmount = 0.25f;

	private void Update()
	{
		if ((float)Screen.width / (float)Screen.height < minimumAspectRatio)
		{
			float num = 1f - (minimumAspectRatio - (float)Screen.width / (float)Screen.height) * scaleAmount;
			base.transform.localScale = Vector3.one * num;
		}
		else
		{
			base.transform.localScale = Vector3.one;
		}
	}
}
