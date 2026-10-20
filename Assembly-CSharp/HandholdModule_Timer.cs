using UnityEngine;
using UnityEngine.Events;

public class HandholdModule_Timer : HandholdModule
{
	public float timer;

	private float currentTime;

	private bool timerRunning;

	public bool onlyRunWhenHolding;

	public bool resetWhenNotHolding;

	public UnityEvent timerFinishEvent;

	public override void Initialize(CL_Handhold h)
	{
		base.Initialize(h);
		currentTime = timer;
	}

	public override void OnGrab(ENT_Player p, ENT_Player.Hand hand, Clickable.InteractionInfo info = null)
	{
		base.OnGrab(p, hand, info);
		if (!timerRunning && currentTime > 0f)
		{
			currentTime = timer;
			timerRunning = true;
		}
	}

	public override void Update()
	{
		base.Update();
		if (resetWhenNotHolding && handhold.hands.Count == 0)
		{
			currentTime = timer;
		}
		if (timerRunning)
		{
			if (!onlyRunWhenHolding || handhold.hands.Count > 0)
			{
				currentTime -= Time.deltaTime;
			}
			if (currentTime <= 0f)
			{
				timerRunning = false;
				timerFinishEvent.Invoke();
			}
		}
	}
}
