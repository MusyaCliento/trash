using UnityEngine;

public class UT_FadeController : MonoBehaviour
{
	public void Flash(string fadeName)
	{
		CL_UIManager.instance.FlashVignette(fadeName);
	}
}
