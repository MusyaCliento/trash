public class SSM_CompetitiveChecker : SpawnSettingModule
{
	public float trueValue = 1f;

	public float falseValue;

	public override float Check()
	{
		if (CL_GameManager.GetBaseGamemode().IsCompetitive())
		{
			return trueValue;
		}
		return falseValue;
	}
}
