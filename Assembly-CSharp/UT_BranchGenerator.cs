using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UT_BranchGenerator : MonoBehaviour
{
	public List<M_GenerationBranch> branch;

	public M_Level currentLevel;

	public Transform startTransform;

	private M_GenerationBranch selectedBranch;

	public bool switchToBranchAfterGenerating = true;

	public bool deleteRootBranch;

	public bool teleportPlayerIntoBranch;

	public bool deleteRootLevelAfterTeleporting;

	public bool unparentAndDestroyAfterSwitch;

	public void Generate()
	{
		if (!(WorldLoader.instance == null))
		{
			selectedBranch = Object.Instantiate(branch[Random.Range(0, branch.Count)]);
			selectedBranch.id += Time.frameCount;
			selectedBranch.currentLevel = currentLevel;
			if (currentLevel != null)
			{
				Debug.Log($"BRANCH GENERATOR - {currentLevel} | {currentLevel.region} | {currentLevel.subRegion}");
			}
			WorldLoader.instance.GenerateBranchFromLevel(currentLevel, startTransform, selectedBranch, selectedBranch);
			StartCoroutine(DelayedBranchSwitch());
		}
		IEnumerator DelayedBranchSwitch()
		{
			if (unparentAndDestroyAfterSwitch)
			{
				base.transform.parent = null;
			}
			yield return new WaitForSeconds(0.3f);
			while (CL_GameManager.IsLoading())
			{
				yield return null;
			}
			if (teleportPlayerIntoBranch)
			{
				WorldLoader.instance.ChangeBranch(selectedBranch.id);
				WorldLoader.instance.currentBranch.levelTracker[0].GetLevel().SetAsCurrentLevel();
				ENT_Player.playerObject.Teleport(WorldLoader.instance.currentBranch.levelTracker[0].GetLevel().GetSpawnPosition(), WorldLoader.instance.currentBranch.levelTracker[0].GetLevel().GetSpawnPositionTransform().rotation);
			}
			if (switchToBranchAfterGenerating)
			{
				if (deleteRootBranch)
				{
					WorldLoader.instance.DeleteOtherBranches(selectedBranch.id);
				}
				MovePlayerIntoBranch();
			}
			if (deleteRootLevelAfterTeleporting && currentLevel != null)
			{
				WorldLoader.instance.DeleteOtherBranches();
				WorldLoader.instance.currentBranch.levelTracker[0].GetLevel().SetAsCurrentLevel();
				WorldLoader.instance.UnloadPreviousLevels();
				WorldLoader.SkyboxManager.UnloadSkyboxes();
			}
			yield return new WaitForSeconds(0.3f);
			if (unparentAndDestroyAfterSwitch)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}

	public void MovePlayerIntoBranch()
	{
		WorldLoader.instance.ChangeBranch(selectedBranch.id);
	}
}
