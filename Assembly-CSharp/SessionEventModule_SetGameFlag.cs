using System;

[Serializable]
public class SessionEventModule_SetGameFlag : SessionEventModule
{
	public string gameFlagID;

	public bool gameFlagState = true;

	public string data;

	public bool saveFlag;

	public override void Initialize(SessionEvent s)
	{
		base.Initialize(s);
		CL_GameManager.SetGameFlag(gameFlagID, gameFlagState, data, saveFlag);
	}
}
