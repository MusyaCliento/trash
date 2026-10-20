using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class UT_Toggle : MonoBehaviour, Activatable
{
	public bool active;

	private bool startState;

	public bool locked;

	public UnityEvent activateEvent;

	public UnityEvent deactivateEvent;

	public bool resetOnEnable;

	public bool triggerCurrentStateEventsOnEnable;

	public bool runOnStart;

	private void Awake()
	{
		startState = active;
	}

	private void Start()
	{
		StartCoroutine(WaitOneFrame());
		IEnumerator WaitOneFrame()
		{
			yield return null;
			if (runOnStart)
			{
				if (active)
				{
					activateEvent.Invoke();
				}
				else
				{
					deactivateEvent.Invoke();
				}
			}
		}
	}

	private void OnEnable()
	{
		if (!locked)
		{
			if (resetOnEnable)
			{
				SetState(startState);
			}
			if (triggerCurrentStateEventsOnEnable)
			{
				SetState(active);
			}
		}
	}

	public void Toggle()
	{
		if (!locked)
		{
			active = !active;
			if (active)
			{
				activateEvent.Invoke();
			}
			else
			{
				deactivateEvent.Invoke();
			}
		}
	}

	public void SetState(bool b)
	{
		if (!locked)
		{
			active = b;
			if (active)
			{
				activateEvent.Invoke();
			}
			else
			{
				deactivateEvent.Invoke();
			}
		}
	}

	public void SetLocked(bool b)
	{
		locked = b;
	}

	public void Deactivate()
	{
		SetState(b: false);
	}

	public void Activate()
	{
		SetState(b: true);
	}

	public void ToggleActivated()
	{
		Toggle();
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}
}
