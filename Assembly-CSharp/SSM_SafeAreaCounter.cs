using UnityEngine;

public class SSM_SafeAreaCounter : SpawnSettingModule
{
	public int value = 3;

	public int min = 1;

	public int offset;

	public bool modulo = true;

	public M_Level parentLevel;

	[Range(0f, 1f)]
	public float trueValue = 1f;

	[Range(0f, 1f)]
	public float falseValue;

	public override float Check()
	{
		if (!WorldLoader.initialized)
		{
			return trueValue;
		}
		if (parentLevel == null)
		{
			parentLevel = WorldLoader.instance.GetCurrentLevel().GetLevel();
		}
		int num = parentLevel.GetSpawnRoomID() + offset;
		bool flag = num == value;
		if (modulo && num % value == 0)
		{
			flag = true;
		}
		if (num < min)
		{
			flag = false;
		}
		if (flag)
		{
			return trueValue;
		}
		return falseValue;
	}
}
