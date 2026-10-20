using System;

[Serializable]
public class SessionEventModule_StartEvent : SessionEventModule
{
	public SessionEvent newEvent;

	public override void Initialize(SessionEvent s)
	{
		base.Initialize(s);
		Activate();
	}

	public override void Activate()
	{
		base.Activate();
		CL_EventManager.StartEvent(newEvent);
	}
}
