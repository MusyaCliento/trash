using System;

[Serializable]
public class SessionEventModule_AddCustomElement : SessionEventModule
{
	public HUD_CustomElement element;

	public override void Initialize(SessionEvent s)
	{
		base.Initialize(s);
		Activate();
	}

	public override void Activate()
	{
		base.Activate();
		Play();
	}

	public void Play()
	{
	}
}
