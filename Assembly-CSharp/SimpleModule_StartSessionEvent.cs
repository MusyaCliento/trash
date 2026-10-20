public class SimpleModule_StartSessionEvent : SimpleModule
{
	public SessionEvent sessionEvent;

	public bool canStopEvent;

	public override void Activate()
	{
		base.Activate();
		CL_EventManager.StartEvent(sessionEvent);
	}

	public override void Deactivate()
	{
		base.Deactivate();
		if (canStopEvent)
		{
			CL_EventManager.RemoveEvent(sessionEvent.id);
		}
	}
}
