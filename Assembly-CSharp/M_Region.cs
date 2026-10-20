using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Region", menuName = "White Knuckle/Region")]
public class M_Region : ScriptableObject
{
	public enum RegionOrder
	{
		shuffle = 0,
		playlist = 1,
		shuffleAfterGameStart = 2,
		shuffleAfterFirst = 3
	}

	[Serializable]
	public class TransitionLevels
	{
		public string name;

		public string fromRegion;

		public List<M_Level> levels;

		public M_Region transitionRegion;

		public M_Subregion transitionSubRegion;

		public bool useAllLevels;

		public List<M_Level.LevelAssetHolder> levelReferences;
	}

	[Serializable]
	public class SubregionGroup
	{
		public string name;

		public List<M_Subregion> subregions;

		public M_Subregion GetSubregion()
		{
			List<M_Subregion> list = new List<M_Subregion>();
			foreach (M_Subregion subregion in subregions)
			{
				if (subregion.CanSpawn())
				{
					list.Add(subregion);
				}
			}
			if (list.Count == 0)
			{
				return null;
			}
			return list[UnityEngine.Random.Range(0, list.Count)];
		}
	}

	public string regionName;

	public string introText;

	public bool useRegionHeight = true;

	public float regionHeight = 500f;

	public RegionOrder regionOrder;

	[Space]
	[Tooltip("Force the start level to always spawn.")]
	public bool forceStartLevel;

	[Tooltip("Start Level for the region, used if there are no prior regions. Chosen at random.")]
	public List<M_Level> startLevels;

	public List<M_Level.LevelAssetHolder> startLevelReferences;

	public List<SubregionGroup> subregionGroups;

	[Space]
	public M_Region nextRegion;

	public List<SessionEventList> sessionEventLists;

	public List<ENV_RadioStation> radioStations;

	public string richPresenceIdentifier;

	private List<M_Level.LevelAssetHolder> levelOrdering = new List<M_Level.LevelAssetHolder>();

	private Dictionary<string, M_Level.LevelAssetHolder> levelDict = new Dictionary<string, M_Level.LevelAssetHolder>();

	private Dictionary<string, M_Level.LevelAssetHolder> levelOrderingDict = new Dictionary<string, M_Level.LevelAssetHolder>();

	private List<M_Level.LevelAssetHolder> allLevels = new List<M_Level.LevelAssetHolder>();

	public bool useCustomFXSettings = true;

	public FXManager.FXData fxData = new FXManager.FXData();

	public Color fogColor;

	public int ditherLevels = 36;

	public List<TransitionLevels> transitionLevels;

	private Dictionary<string, TransitionLevels> transitionLevelDictionary;

	public List<M_Level.LevelAssetHolder> GetLevels(M_Region lastRegion, M_Subregion lastSubregion = null)
	{
		List<M_Subregion> list = new List<M_Subregion>();
		List<M_Subregion> list2 = new List<M_Subregion>();
		foreach (SubregionGroup subregionGroup in subregionGroups)
		{
			M_Subregion subregion = subregionGroup.GetSubregion();
			if (!(subregion == null))
			{
				list2.Add(subregion);
			}
		}
		Queue<M_Subregion> subregionQueue = GetSubregionQueue(list2, lastSubregion, lastRegion);
		for (int i = 0; i < list2.Count + 1; i++)
		{
			if (subregionQueue.Count == 0)
			{
				subregionQueue = GetSubregionQueue(list2, list[i - 1], lastRegion);
			}
			list.Add(subregionQueue.Dequeue());
		}
		List<M_Level.LevelAssetHolder> list3 = new List<M_Level.LevelAssetHolder>();
		bool flag = false;
		float num = 0f;
		float num2 = 0f;
		int num3 = 0;
		int num4 = 0;
		if (lastRegion == null || forceStartLevel)
		{
			if (startLevelReferences.Count > 0)
			{
				list3.Add(startLevelReferences[UnityEngine.Random.Range(0, startLevelReferences.Count)]);
				if (!list3[0].setCustomRegionInfo)
				{
					list3[0].region = this;
					list3[0].subregion = list[num4];
				}
			}
		}
		else if (transitionLevels.Count > 0)
		{
			List<M_Level.LevelAssetHolder> list4 = GetTransitionLevels(lastRegion);
			if (list4 != null)
			{
				list3.AddRange(list4);
			}
		}
		bool flag2 = false;
		int num5 = 0;
		while (!flag)
		{
			num5++;
			M_Subregion m_Subregion = list[num4];
			List<M_Level.LevelAssetHolder> generationLevels = m_Subregion.GetGenerationLevels();
			int num6 = 0;
			foreach (M_Level.LevelAssetHolder item in generationLevels)
			{
				bool flag3 = num6 == generationLevels.Count - 1;
				item.region = this;
				item.subregion = m_Subregion;
				list3.Add(item);
				num += item.length;
				item.region = this;
				if (num > regionHeight && useRegionHeight)
				{
					flag = true;
					return list3;
				}
				if (flag3)
				{
					num3 = 0;
					num2 = 0f;
					num4++;
					if (num4 > list2.Count - 1)
					{
						flag2 = true;
						num4 = 0;
					}
				}
				if (!useRegionHeight && flag2)
				{
					return list3;
				}
				num3++;
				num2 += item.length;
				num6++;
			}
			if (num5 > 50)
			{
				return list3;
			}
		}
		return list3;
	}

	private M_Level.LevelAssetHolder GetRandomLevel()
	{
		if (levelOrdering.Count == 0)
		{
			return null;
		}
		M_Level.LevelAssetHolder levelAssetHolder = levelOrdering[UnityEngine.Random.Range(0, levelOrdering.Count)];
		levelOrdering.Remove(levelAssetHolder);
		return levelAssetHolder;
	}

	private Queue<M_Subregion> GetSubregionQueue(List<M_Subregion> subregions, M_Subregion lastSubregion = null, M_Region lastRegion = null)
	{
		List<M_Subregion> list = new List<M_Subregion>();
		list.AddRange(subregions);
		Queue<M_Subregion> queue = new Queue<M_Subregion>();
		bool flag = regionOrder == RegionOrder.shuffleAfterGameStart || regionOrder == RegionOrder.shuffleAfterFirst || regionOrder == RegionOrder.shuffle;
		if (regionOrder == RegionOrder.shuffleAfterGameStart || regionOrder == RegionOrder.shuffleAfterFirst)
		{
			if (regionOrder == RegionOrder.shuffleAfterFirst)
			{
				if (list.Count > 1 && list.Contains(subregions[0]))
				{
					list.Remove(subregions[0]);
				}
				queue.Enqueue(subregions[0]);
			}
			else
			{
				if (lastSubregion != null && list.Count > 1 && list.Contains(lastSubregion))
				{
					list.Remove(lastSubregion);
				}
				if (lastRegion == null)
				{
					queue.Enqueue(subregions[0]);
				}
			}
		}
		else if (regionOrder == RegionOrder.playlist)
		{
			for (int i = 0; i < subregions.Count; i++)
			{
				queue.Enqueue(subregions[i]);
			}
		}
		while (list.Count > 0)
		{
			M_Subregion item = ((!flag) ? list[list.Count - 1] : ((!(lastRegion == null) || list.Count <= 1 || regionOrder == RegionOrder.shuffle) ? list[UnityEngine.Random.Range(0, list.Count)] : list[UnityEngine.Random.Range(1, list.Count)]));
			queue.Enqueue(item);
			list.Remove(item);
		}
		return queue;
	}

	public List<M_Level.LevelAssetHolder> GetTransitionLevels(M_Region regionFrom)
	{
		if (transitionLevelDictionary == null)
		{
			transitionLevelDictionary = new Dictionary<string, TransitionLevels>();
			foreach (TransitionLevels transitionLevel in transitionLevels)
			{
				transitionLevelDictionary.Add(transitionLevel.fromRegion, transitionLevel);
			}
		}
		Debug.Log("a");
		if (!transitionLevelDictionary.ContainsKey(regionFrom.regionName))
		{
			return null;
		}
		if (transitionLevelDictionary[regionFrom.regionName].transitionRegion != null)
		{
			List<M_Level.LevelAssetHolder> list = new List<M_Level.LevelAssetHolder>();
			list.AddRange(transitionLevelDictionary[regionFrom.regionName].transitionRegion.GetLevels(regionFrom));
			return list;
		}
		if (transitionLevelDictionary[regionFrom.regionName].transitionSubRegion != null)
		{
			List<M_Level.LevelAssetHolder> list2 = new List<M_Level.LevelAssetHolder>();
			list2.AddRange(transitionLevelDictionary[regionFrom.regionName].transitionSubRegion.GetGenerationLevels());
			return list2;
		}
		if (transitionLevelDictionary[regionFrom.regionName].levels.Count > 0)
		{
			List<M_Level.LevelAssetHolder> list3 = new List<M_Level.LevelAssetHolder>();
			List<M_Level.LevelAssetHolder> list4 = new List<M_Level.LevelAssetHolder>();
			foreach (M_Level.LevelAssetHolder levelReference in transitionLevelDictionary[regionFrom.regionName].levelReferences)
			{
				if (levelReference.GetLevel().spawnSettings.RandomCheck())
				{
					list4.Add(levelReference);
				}
			}
			if (list4.Count == 0)
			{
				list4.Add(transitionLevelDictionary[regionFrom.regionName].levelReferences[0]);
			}
			if (transitionLevelDictionary[regionFrom.regionName].useAllLevels)
			{
				list3.AddRange(list4);
			}
			else
			{
				list3.Add(list4[UnityEngine.Random.Range(0, list4.Count)]);
			}
			return list3;
		}
		return null;
	}
}
