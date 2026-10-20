using UnityEngine;

public class UI_ProgressionLog : MonoBehaviour
{
	public ProgressionUnlock unlock;

	private UI_ProgressionPopup popup;

	public ProgressionUnlock prerequisite;

	public Sprite unknownIcon;

	private void Start()
	{
		popup = GetComponent<UI_ProgressionPopup>();
		bool flag = unlock.CheckUnlock();
		if (prerequisite != null && flag)
		{
			flag = prerequisite.CheckUnlock();
		}
		if (flag)
		{
			popup.UpdateInformation(unlock.unlockIcon, unlock.unlockLogDescription, "Unlocked");
		}
		else if (unlock.showProgression && unlock.GetProgress() > 0f)
		{
			popup.UpdateInformation(unknownIcon, "REDACTED", "Progress: " + unlock.GetProgressString() + " " + unlock.progressionString);
		}
		else
		{
			popup.UpdateInformation(unknownIcon, "REDACTED", unlock.unlockHint);
		}
	}
}
