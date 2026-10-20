using TMPro;
using UnityEngine;

public class UT_RoachTextCounter : MonoBehaviour
{
	public string textFormat = "{runRoaches}";

	[Tooltip("For use with {runRoaches}")]
	public string roachFormat = "";

	[Tooltip("For use with {globalRoaches}")]
	public string globalRoachFormat = "D4";

	[Tooltip("For use with {combinedRoaches}")]
	public string combinedRoachFormat = "D4";

	private TMP_Text text;

	private int lastSeenRoaches;

	private int lastSeenGlobalRoaches;

	private void Start()
	{
		text = GetComponent<TMP_Text>();
		UpdateText();
	}

	private void Update()
	{
		int roaches = CL_GameManager.GetRoaches();
		int roaches2 = CL_GameManager.GetRoaches(global: true);
		if (roaches != lastSeenRoaches || roaches2 != lastSeenGlobalRoaches)
		{
			UpdateText();
		}
	}

	private void UpdateText()
	{
		string text = textFormat;
		int roaches = CL_GameManager.GetRoaches();
		int num = CL_GameManager.GetRoaches(global: true);
		if (CL_GameManager.GetCurrentGamemode().IsCompetitive())
		{
			num = 9999;
		}
		string newValue = roaches.ToString(roachFormat);
		string newValue2 = num.ToString(globalRoachFormat);
		string newValue3 = CL_GameManager.GetCombinedRoaches().ToString(combinedRoachFormat);
		text = text.Replace("{runRoaches}", newValue);
		text = text.Replace("{globalRoaches}", newValue2);
		text = text.Replace("{combinedRoaches}", newValue3);
		this.text.text = text;
		lastSeenRoaches = roaches;
		lastSeenGlobalRoaches = num;
	}
}
