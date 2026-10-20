using System;

[Serializable]
public class SessionEventModule_BasicControls : SessionEventModule
{
	public float screenShake;

	public override void Initialize(SessionEvent s)
	{
		base.Initialize(s);
		if (screenShake > 0f)
		{
			CL_CameraControl.Shake(screenShake);
		}
	}
}
