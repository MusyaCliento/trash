using UnityEngine;

public class UI_AchievementText : MonoBehaviour
{
	private UT_TextScrawl scrawl;

	private void Start()
	{
		scrawl = GetComponent<UT_TextScrawl>();
		CL_AchievementManager.textInstance = this;
	}

	private void OnDestroy()
	{
		if (CL_AchievementManager.textInstance == this)
		{
			CL_AchievementManager.textInstance = null;
		}
	}

	public void ShowText(string text)
	{
		Debug.Log("Showing Text: " + text);
		if (scrawl != null)
		{
			scrawl.ShowText(text);
		}
	}
}
