public class PerkModule_MassController : PerkModule
{
	public float massMult;

	public override void Update()
	{
		base.Update();
		if (DEN_DeathFloor.instance != null)
		{
			DEN_DeathFloor.instance.SetUpdateSpeedMultiplier(massMult);
		}
		DEN_Face.SetGlobalUpdateSpeedMultiplier(massMult);
	}
}
