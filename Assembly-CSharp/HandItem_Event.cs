using UnityEngine;
using UnityEngine.Events;

public class HandItem_Event : HandItem
{
	public UnityEvent useEvent;

	public UnityEvent onStopUse;

	public UnityEvent chargeEvent;

	public UnityEvent chargeFailEvent;

	public float chargeEventTime = 1f;

	private float chargeStartTime;

	private bool charging;

	public override void Use()
	{
		base.Use();
		chargeStartTime = Time.time;
		charging = true;
		useEvent.Invoke();
	}

	public override void StopUse()
	{
		if (charging)
		{
			charging = false;
			if (Time.time - chargeStartTime > chargeEventTime)
			{
				chargeEvent.Invoke();
			}
			else
			{
				chargeFailEvent.Invoke();
			}
			chargeStartTime = float.PositiveInfinity;
		}
		onStopUse.Invoke();
		base.StopUse();
	}
}
