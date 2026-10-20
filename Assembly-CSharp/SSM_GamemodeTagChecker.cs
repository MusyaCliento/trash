using System.Collections.Generic;
using UnityEngine;

public class SSM_GamemodeTagChecker : SpawnSettingModule
{
	public List<string> gamemodeTags;

	[Range(0f, 1f)]
	public float trueValue = 1f;

	[Range(0f, 1f)]
	public float falseValue;

	public override float Check()
	{
		bool flag = false;
		if (CL_GameManager.GetCurrentGamemode().HasAnyTag(gamemodeTags))
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
