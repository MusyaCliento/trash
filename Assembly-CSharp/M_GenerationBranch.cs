using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;

[CreateAssetMenu(fileName = "New Generation Branch", menuName = "White Knuckle/World/Generation Branch", order = 0)]
public class M_GenerationBranch : ScriptableObject, WorldGenerator
{
	public enum GenerationType
	{
		standard = 0,
		levelPlaylist = 1,
		shuffledLevelPlaylist = 2,
		endlessLevelPlaylist = 3,
		singleLevel = 4,
		singleRegion = 5,
		shuffledRegionPlaylist = 6
	}

	public enum BranchEnd
	{
		skipRegion = 0,
		continueRegion = 1,
		repeatBranch = 2,
		otherBranch = 3,
		end = 4
	}

	public string id;

	public string desc;

	public BranchEnd branchEnd;

	public List<M_Level.LevelAssetHolder> nextBranch;

	public int levelsToGenerate = 4;

	public GenerationType generationType;

	public List<M_Level> playlistLevels;

	public List<M_Level.LevelAssetHolder> playlistLevelAssets;

	public List<M_Region> regions;

	public M_Level currentLevel;

	public List<M_Level.LevelAssetHolder> GetGenerationList(M_Region lastRegion = null, M_Region regionToGenerate = null, M_Subregion startAfterSubregion = null)
	{
		List<M_Level.LevelAssetHolder> levelGenerationList = new List<M_Level.LevelAssetHolder>();
		if (generationType == GenerationType.singleLevel)
		{
			levelGenerationList = new List<M_Level.LevelAssetHolder>();
			levelGenerationList.Add(playlistLevelAssets[0]);
		}
		else if (generationType == GenerationType.levelPlaylist)
		{
			levelGenerationList.AddRange(playlistLevelAssets);
		}
		else
		{
			if (regionToGenerate != null)
			{
				List<M_Level.LevelAssetHolder> regionLevels = GetRegionLevels(regionToGenerate, lastRegion, startAfterSubregion);
				levelGenerationList.AddRange(regionLevels);
				if (levelGenerationList.Count > levelsToGenerate)
				{
					levelGenerationList.SetLength(levelsToGenerate);
					FinalizeLevelList(ref levelGenerationList, lastRegion, regionToGenerate);
					return levelGenerationList;
				}
				lastRegion = regionToGenerate;
			}
			List<M_Region> list = new List<M_Region>();
			if (lastRegion == null || regions.Count == 1 || lastRegion == regions[regions.Count - 1])
			{
				list.AddRange(regions);
			}
			else
			{
				bool flag = false;
				for (int i = 0; i < regions.Count; i++)
				{
					if (flag)
					{
						list.Add(regions[i]);
					}
					else if (!flag && regions[i] == lastRegion)
					{
						flag = true;
					}
					if (i == regions.Count - 1)
					{
						list.AddRange(regions);
					}
				}
			}
			while (levelGenerationList.Count < levelsToGenerate)
			{
				for (int j = 0; j < list.Count; j++)
				{
					M_Region m_Region = list[j];
					if (list.Count <= 1 || !(m_Region == lastRegion))
					{
						List<M_Level.LevelAssetHolder> regionLevels2 = GetRegionLevels(m_Region, lastRegion, startAfterSubregion);
						levelGenerationList.AddRange(regionLevels2);
						if (levelGenerationList.Count > levelsToGenerate || generationType == GenerationType.singleRegion)
						{
							FinalizeLevelList(ref levelGenerationList, lastRegion, m_Region);
							return levelGenerationList;
						}
						lastRegion = m_Region;
						if (j == list.Count - 1)
						{
							list = regions;
						}
					}
				}
			}
		}
		FinalizeLevelList(ref levelGenerationList, lastRegion);
		return levelGenerationList;
	}

	private void FinalizeLevelList(ref List<M_Level.LevelAssetHolder> levelGenerationList, M_Region lastRegion = null, M_Region currentRegion = null)
	{
		if (branchEnd == BranchEnd.skipRegion)
		{
			List<WorldLoader.BranchInfo.LevelId> levelIdsAfterRegion = WorldLoader.instance.currentBranch.GetLevelIdsAfterRegion(lastRegion.name);
			bool flag = false;
			for (int i = 0; i < levelIdsAfterRegion.Count; i++)
			{
				WorldLoader.BranchInfo.LevelId levelId = levelIdsAfterRegion[i];
				M_Level.LevelAssetHolder levelAsset = CL_AssetManager.GetLevelAsset(levelId.level);
				if (levelAsset == null)
				{
					continue;
				}
				Debug.Log(levelAsset.id);
				if ((i == 0 || flag) && levelAsset.tags.Contains("transition") && currentRegion != null)
				{
					if (flag)
					{
						continue;
					}
					List<M_Level.LevelAssetHolder> transitionLevels = CL_AssetManager.GetRegionAsset(levelId.region).GetTransitionLevels(currentRegion);
					if (transitionLevels == null)
					{
						continue;
					}
					foreach (M_Level.LevelAssetHolder item in transitionLevels)
					{
						item.region = CL_AssetManager.GetRegionAsset(levelId.region);
						item.subregion = CL_AssetManager.GetSubregionAsset(levelId.subRegion);
					}
					levelGenerationList.AddRange(transitionLevels);
					flag = true;
				}
				else if ((i < 2 || flag) && levelAsset.tags.Contains("saferoom"))
				{
					flag = true;
				}
				else
				{
					flag = false;
					levelAsset.region = CL_AssetManager.GetRegionAsset(levelId.region);
					levelAsset.subregion = CL_AssetManager.GetSubregionAsset(levelId.subRegion);
					levelGenerationList.Add(levelAsset);
				}
			}
		}
		else if (branchEnd == BranchEnd.continueRegion)
		{
			List<WorldLoader.BranchInfo.LevelId> levelIdsAfterLevel = WorldLoader.instance.currentBranch.GetLevelIdsAfterLevel(currentLevel);
			for (int j = 0; j < levelIdsAfterLevel.Count; j++)
			{
				WorldLoader.BranchInfo.LevelId levelId2 = levelIdsAfterLevel[j];
				M_Level.LevelAssetHolder levelAsset2 = CL_AssetManager.GetLevelAsset(levelId2.level);
				if (levelAsset2 != null)
				{
					levelAsset2.region = CL_AssetManager.GetRegionAsset(levelId2.region);
					levelAsset2.subregion = CL_AssetManager.GetSubregionAsset(levelId2.subRegion);
					levelGenerationList.Add(levelAsset2);
				}
			}
		}
		if (branchEnd == BranchEnd.end)
		{
			levelGenerationList[levelGenerationList.Count - 1].isPausingGeneration = true;
		}
		else if (!levelGenerationList[levelGenerationList.Count - 1].pauseGeneration)
		{
			levelGenerationList[levelGenerationList.Count - 1].isPausingGeneration = false;
		}
	}

	private List<M_Level.LevelAssetHolder> GetRegionLevels(M_Region region, M_Region lastRegion = null, M_Subregion lastSubregion = null)
	{
		List<M_Level.LevelAssetHolder> levels = region.GetLevels(lastRegion, lastSubregion);
		foreach (M_Level.LevelAssetHolder item in levels)
		{
			if (item != null)
			{
				item.region = region;
			}
		}
		for (int num = levels.Count - 1; num >= 0; num--)
		{
			if (levels[num] == null)
			{
				levels.RemoveAt(num);
			}
		}
		return levels;
	}
}
