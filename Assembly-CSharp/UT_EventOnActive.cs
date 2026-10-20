using UnityEngine;
using UnityEngine.Events;

public class UT_EventOnActive : MonoBehaviour
{
	public bool runOnce;

	public UnityEvent startEvent;

	private bool hasRun;

	public bool onEnable = true;

	private void Start()
	{
		if (!onEnable && (!runOnce || !hasRun))
		{
			startEvent.Invoke();
			if (runOnce)
			{
				hasRun = true;
			}
		}
	}

	private void OnEnable()
	{
		if (onEnable && (!runOnce || !hasRun))
		{
			startEvent.Invoke();
			if (runOnce)
			{
				hasRun = true;
			}
		}
	}
}
