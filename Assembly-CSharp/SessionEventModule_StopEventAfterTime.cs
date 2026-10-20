using System;
using UnityEngine;

[Serializable]
public class SessionEventModule_StopEventAfterTime : SessionEventModule
{
	public float timer;

	private float timeRemaining;

	public override void Initialize(SessionEvent s)
	{
		timeRemaining = timer;
		base.Initialize(s);
	}

	public override void Update()
	{
		timeRemaining -= Time.deltaTime;
		base.Update();
		if (timeRemaining <= 0f && sessionEvent != null)
		{
			sessionEvent.StopEvent();
		}
	}
}
