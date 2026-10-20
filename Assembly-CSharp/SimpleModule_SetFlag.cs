public class SimpleModule_SetFlag : SimpleModule
{
	public string flag;

	public bool value;

	public bool saveFlag;

	public override void Activate()
	{
		base.Activate();
		CL_GameManager.SetGameFlag(flag, value, "", saveFlag);
	}

	public override void Deactivate()
	{
		base.Deactivate();
		CL_GameManager.SetGameFlag(flag, !value, "", saveFlag);
	}
}
