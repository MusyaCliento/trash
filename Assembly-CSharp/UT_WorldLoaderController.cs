using UnityEngine;

public class UT_WorldLoaderController : MonoBehaviour
{
	public WorldLoader.GenerationParameters generationParameters;

	public bool removePreviousLevels;

	public bool removeCurrentLevels;

	public bool removeFutureLevels = true;

	public void SendToWorldLoader()
	{
		if (removeCurrentLevels && removePreviousLevels)
		{
			WorldLoader.instance.RestartGenerationFromLevelList(generationParameters);
		}
	}

	public void UnloadPreviousLevels()
	{
		WorldLoader.instance.UnloadPreviousLevels(0);
	}

	public void DeleteOtherBranches()
	{
		WorldLoader.instance.DeleteOtherBranches();
	}

	public void ClearSkyboxes()
	{
		WorldLoader.SkyboxManager.UnloadSkyboxes();
	}
}
