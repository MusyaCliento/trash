public class SSM_HasWonChecker : SpawnSettingModule
{
	public float trueValue = 1f;

	public float falseValue;

	public override float Check()
	{
		if (CL_GameManager.GetCurrentGamemode() != null && CL_GameManager.GetCurrentGamemode().HasWonGamemode())
		{
			return trueValue;
		}
		return falseValue;
	}
}
