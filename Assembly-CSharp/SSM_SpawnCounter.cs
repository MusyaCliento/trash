using UnityEngine;

public class SSM_SpawnCounter : SpawnSettingModule
{
	public string flagName;

	public int countAddOnSpawn;

	public int maxCount = 10;

	public AnimationCurve spawnCurve = AnimationCurve.Linear(0f, 1f, 1f, 0f);

	public override float Check()
	{
		CL_GameManager.SessionFlag gameFlag = CL_GameManager.GetGameFlag(flagName);
		float time = 0f;
		if (gameFlag != null && int.TryParse(gameFlag.data, out var result))
		{
			time = (float)result / (float)maxCount;
		}
		return spawnCurve.Evaluate(time);
	}

	public override void OnSpawn()
	{
		CL_GameManager.SessionFlag gameFlag = CL_GameManager.GetGameFlag(flagName);
		int result;
		if (gameFlag == null)
		{
			CL_GameManager.SetGameFlag(flagName, state: false, countAddOnSpawn.ToString());
		}
		else if (int.TryParse(gameFlag.data, out result))
		{
			CL_GameManager.SetGameFlag(flagName, state: false, (result + countAddOnSpawn).ToString());
		}
		else
		{
			CL_GameManager.SetGameFlag(flagName, state: false, countAddOnSpawn.ToString());
		}
		base.OnSpawn();
	}
}
