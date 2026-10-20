using System;

[Serializable]
public class SessionEventModule_StopThisEvent : SessionEventModule
{
	public bool onInitialization = true;

	public override void Initialize(SessionEvent s)
	{
		base.Initialize(s);
		if (onInitialization)
		{
			s.StopEvent();
		}
	}

	public override void Activate()
	{
		base.Activate();
		sessionEvent.StopEvent();
	}
}
