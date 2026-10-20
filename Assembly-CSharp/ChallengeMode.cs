public class ChallengeMode
{
	public static int GetMedalRankFromGamemode(M_Gamemode mode)
	{
		if (mode.GetGamemodeSaveData() == null)
		{
			return 0;
		}
		if (mode.gamemodeModule != null && mode.gamemodeModule.GetType() == typeof(GamemodeModule_Challenge))
		{
			GamemodeModule_Challenge obj = (GamemodeModule_Challenge)mode.gamemodeModule;
			float statisticFloat = StatManager.GetStatisticFloat(mode.GetGamemodeSaveData().stats, "score");
			return obj.GetMedalRankFromScore(statisticFloat);
		}
		return 0;
	}

	public static GamemodeModule_Challenge.Medal GetMedalFromGamemode(M_Gamemode mode, int rank)
	{
		if (mode.gamemodeModule.GetType() != typeof(GamemodeModule_Challenge))
		{
			return null;
		}
		return ((GamemodeModule_Challenge)mode.gamemodeModule).medals[rank];
	}

	public static int GetTotalMedalsForRank(int rank)
	{
		int num = 0;
		foreach (M_Gamemode gamemodeAsset in CL_AssetManager.GetFullCombinedAssetDatabase().gamemodeAssets)
		{
			if (GetMedalRankFromGamemode(gamemodeAsset) == rank)
			{
				num++;
			}
		}
		return num;
	}

	public static int GetTotalMedalsAtOrAboveRank(int rank)
	{
		int num = 0;
		for (int i = rank; i <= 4; i++)
		{
			num += GetTotalMedalsForRank(i);
		}
		return num;
	}

	public static void CheckChallengeAchievements()
	{
		if (GetTotalMedalsAtOrAboveRank(3) >= 5)
		{
			CL_AchievementManager.SetAchievementValue("ACH_CHA_GOLD_5", b: true);
		}
		if (GetTotalMedalsAtOrAboveRank(4) >= 5)
		{
			CL_AchievementManager.SetAchievementValue("ACH_CHA_PLAT_5", b: true);
		}
	}
}
