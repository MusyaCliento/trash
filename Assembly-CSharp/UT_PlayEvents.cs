using UnityEngine;
using UnityEngine.Events;

public class UT_PlayEvents : MonoBehaviour
{
	public UnityEvent playEvent;

	public bool playOnStart;

	public bool playOnEnable;

	private void Awake()
	{
		if (playOnStart)
		{
			PlayEvent();
		}
	}

	private void OnEnable()
	{
		if (playOnEnable)
		{
			PlayEvent();
		}
	}

	public void PlayEvent()
	{
		playEvent.Invoke();
	}
}
