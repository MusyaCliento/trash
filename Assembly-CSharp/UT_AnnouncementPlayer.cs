using UnityEngine;

public class UT_AnnouncementPlayer : MonoBehaviour
{
	public AudioClip tone;

	public void ForceAnnouncement(AudioClip a)
	{
		AnnouncementController.instance.StartAnnouncement(a, tone, force: true);
	}

	public void PlayRandomAnnouncement()
	{
		AnnouncementController.instance.ZeroAnnouncementTimer();
	}
}
