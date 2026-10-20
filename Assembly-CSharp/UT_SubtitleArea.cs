using UnityEngine;

public class UT_SubtitleArea : MonoBehaviour
{
	public string line;

	public string style;

	public float radius;

	public int priority;

	public CL_UIManager.SubtitleFlags overflow;

	private CL_UIManager.SubtitleId active;

	public bool playOnEnable = true;

	private bool isPlaying;

	private void OnEnable()
	{
		if (playOnEnable)
		{
			Play();
		}
	}

	public void Play()
	{
		active = CL_UIManager.SubtitleCreate(CL_LocalizationManager.GetLocalization(line), style);
		CL_UIManager.SubtitleSpace(active, base.transform, Vector3.zero, radius);
		CL_UIManager.SubtitlePriority(active, priority);
		CL_UIManager.SubtitleFlagsSet(active, overflow);
		isPlaying = true;
	}

	private void OnDisable()
	{
		if (isPlaying)
		{
			CL_UIManager.SubtitleDestroy(active, instant: true);
			isPlaying = false;
		}
	}
}
