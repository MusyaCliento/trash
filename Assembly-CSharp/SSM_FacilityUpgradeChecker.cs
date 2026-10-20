public class SSM_FacilityUpgradeChecker : SpawnSettingModule
{
	public FacilityUpgrade upgrade;

	public Facility facility;

	public float trueValue = 1f;

	public float falseValue;

	public override float Check()
	{
		bool flag = false;
		flag = (upgrade.IsOwned(facility.id) ? true : false);
		if (CL_GameManager.GetCurrentGamemode().IsCompetitive())
		{
			flag = true;
		}
		if (flag)
		{
			return trueValue;
		}
		return falseValue;
	}
}
