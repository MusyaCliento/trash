using System.Collections.Generic;
using UnityEngine;

public class UT_PlaySoundOnStart : MonoBehaviour
{
	public AudioClip clip;

	public List<AudioClip> clips;

	[Range(0f, 1f)]
	public float volume = 1f;

	[Range(0f, 1f)]
	public float spacialBlend = 1f;

	[Range(-3f, 3f)]
	public float pitch = 1f;

	public float pitchVariance;

	public bool runOnce = true;

	private bool hasRun;

	public bool useSubtitles;

	public bool subtitleAmbient = true;

	public string subtitleGroup = "sound";

	public string subtitleId = "";

	public float subtitleRadius = 15f;

	private void Start()
	{
		PlaySound();
	}

	private void PlaySound()
	{
		if (hasRun && runOnce)
		{
			return;
		}
		hasRun = true;
		AudioClip audioClip = clips[Random.Range(0, clips.Count)];
		AudioManager.PlaySound(audioClip, base.transform.position, volume, pitch + Random.Range(0f - pitchVariance, pitchVariance), spacialBlend);
		if (useSubtitles)
		{
			CL_UIManager.SubtitleId id = CL_UIManager.SubtitleCreate(CL_LocalizationManager.currentLocalization.GetLine(subtitleGroup, (subtitleId == "") ? audioClip.name : subtitleId), "");
			CL_UIManager.SubtitleFlags subtitleFlags = CL_UIManager.SubtitleFlags.Default;
			if (subtitleAmbient)
			{
				subtitleFlags |= CL_UIManager.SubtitleFlags.Ambient;
			}
			CL_UIManager.SubtitleFlagsSet(id, subtitleFlags);
			CL_UIManager.SubtitleSpace(id, base.transform, Vector3.zero, subtitleRadius);
		}
	}
}
