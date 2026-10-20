using UnityEngine;

public class AnnouncementSource : MonoBehaviour
{
	private AudioSource aud;

	public bool blockAnnouncements;

	public float reverbAdjust;

	private void OnEnable()
	{
		if (AnnouncementController.instance != null)
		{
			AnnouncementController.instance.AddAnnouncer(this);
		}
	}

	private void OnDisable()
	{
		if (AnnouncementController.instance != null)
		{
			AnnouncementController.instance.RemoveAnnouncer(this);
		}
	}

	private void Start()
	{
		aud = GetComponent<AudioSource>();
		if (aud == null)
		{
			string text = DarkMachineFunctions.GameObjectFullPath(base.gameObject);
			Debug.LogError("Announcement source \"" + text + "\" does not have sibling audio source component!");
		}
	}

	public void PlayAnnouncement(AudioClip clip, float volume = 1f, bool showSubtitle = true, bool force = false)
	{
		if (!(aud == null) && (!blockAnnouncements || force) && (!aud.isPlaying || force))
		{
			if (AnnouncementController.currentAnnouncerSource != null && AnnouncementController.currentAnnouncerSource != this)
			{
				AnnouncementController.currentAnnouncerSource.StopAnnouncement();
			}
			AnnouncementController.currentAnnouncerSource = this;
			aud.clip = clip;
			aud.Play();
			AudioManager.instance?.mixer?.SetFloat("AnnouncerReverb", reverbAdjust);
			if (showSubtitle)
			{
				CL_UIManager.ShowSubtitle(CL_LocalizationManager.currentLocalization.GetLine("announcements", clip.name));
			}
		}
	}

	public void ForceAnnouncementIfNotPlaying(AudioClip clip)
	{
		if (!(aud == null) && !aud.isPlaying)
		{
			ForceAnnouncement(clip);
		}
	}

	public void StopAnnouncement()
	{
		if (!(aud == null))
		{
			aud.Stop();
		}
	}

	public void ForceAnnouncement(AudioClip clip)
	{
		if (!(aud == null))
		{
			aud.clip = clip;
			aud.Play();
			CL_UIManager.ShowSubtitle(CL_LocalizationManager.currentLocalization.GetLine("announcements", clip.name));
			AudioManager.instance?.mixer?.SetFloat("AnnouncerReverb", reverbAdjust);
		}
	}

	public void StopAnnouncementSystem()
	{
		AnnouncementController.instance.active = false;
	}

	public void ResumeAnnouncementSystem()
	{
		AnnouncementController.instance.active = true;
	}
}
