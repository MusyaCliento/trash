using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sub-Region", menuName = "White Knuckle/Sub-Region")]
public class M_Subregion : ScriptableObject
{
	public enum SubregionOrder
	{
		standard = 0,
		single = 1,
		playlist = 2
	}

	[Serializable]
	public class LevelGroup
	{
		public string name;

		public List<M_Level.LevelAssetHolder> levelReferences;

		public int length;

		public bool endSubregion;
	}

	public string subregionName;

	public bool showIntroText = true;

	public string introText;

	public SubregionOrder subregionOrder;

	public List<LevelGroup> levelGroups;

	public List<M_Level.LevelAssetHolder> levelReferences;

	public List<M_Level.LevelAssetHolder> startLevelReferences;

	public List<M_Level.LevelAssetHolder> endLevelReferences;

	public bool useLevelCount;

	public int subregionMinLength = 2;

	public int subregionMaxLength = 5;

	public float subregionHeight = 250f;

	public List<SessionEventList> sessionEventLists;

	[Range(0f, 1f)]
	public float difficulty;

	[Range(0f, 2f)]
	public float chance = 1f;

	[Header("Generation Flags")]
	[Tooltip("World flags required before this will generate.")]
	public List<string> flagWhitelist;

	[Tooltip("World flags that will prevent this from generating.")]
	public List<string> flagBlacklist;

	public float massSpeedMult = 1f;

	public List<AnnouncementGroup> announcementGroups;

	public float spaceCompression = 1f;

	public List<TipList> tips;

	public List<ENV_RadioStation> radioStations;

	public float announcementTimerMult = 1f;

	public string richPresenceIdentifier;

	public void EnterSubregion()
	{
	}

	public void ExitSubregion()
	{
	}

	public void Update()
	{
	}

	public AnnouncementGroup GetRandomAnnouncementGroup()
	{
		if (announcementGroups == null || announcementGroups.Count == 0)
		{
			return null;
		}
		float num = 0f;
		foreach (AnnouncementGroup announcementGroup in announcementGroups)
		{
			num += (float)announcementGroup.announcements.Count;
		}
		float num2 = UnityEngine.Random.Range(0f, num);
		float num3 = 0f;
		foreach (AnnouncementGroup announcementGroup2 in announcementGroups)
		{
			num3 += (float)announcementGroup2.announcements.Count;
			if (num2 <= num3)
			{
				return announcementGroup2;
			}
		}
		return null;
	}

	public bool CanSpawn()
	{
		if (flagWhitelist.Count > 0)
		{
			foreach (string item in flagWhitelist)
			{
				if (!CL_GameManager.HasActiveFlag(item))
				{
					return false;
				}
			}
		}
		if (flagBlacklist.Count > 0)
		{
			foreach (string item2 in flagBlacklist)
			{
				if (CL_GameManager.HasActiveFlag(item2))
				{
					return false;
				}
			}
		}
		return true;
	}

	public List<M_Level.LevelAssetHolder> GetGenerationLevels()
	{
		List<M_Level.LevelAssetHolder> list = new List<M_Level.LevelAssetHolder>();
		bool hasReachedHeight = false;
		float curHeight = 0f;
		int targetSubregionLength = UnityEngine.Random.Range(subregionMinLength, subregionMaxLength + 1);
		float currentSubregionHeight = 0f;
		int levelCounter = 0;
		if (startLevelReferences != null && startLevelReferences.Count > 0)
		{
			list.AddRange(startLevelReferences);
		}
		list.AddRange(GenerateMidLevelList());
		if (endLevelReferences != null && endLevelReferences.Count > 0)
		{
			list.AddRange(endLevelReferences);
		}
		return list;
		List<M_Level.LevelAssetHolder> GenerateMidLevelList()
		{
			List<M_Level.LevelAssetHolder> levelPool = new List<M_Level.LevelAssetHolder>();
			int currentGroupID = -1;
			RefillPoolIfEmpty();
			List<M_Level.LevelAssetHolder> list2 = new List<M_Level.LevelAssetHolder>();
			while (!hasReachedHeight)
			{
				M_Level.LevelAssetHolder levelAssetHolder = null;
				RefillPoolIfEmpty();
				if (subregionOrder != SubregionOrder.playlist)
				{
					levelAssetHolder = PullRandomLevelFromPool();
				}
				else
				{
					if (levelPool.Count == 0)
					{
						RefillPoolIfEmpty();
					}
					levelPool[0].LoadLevel();
					levelAssetHolder = levelPool[0];
					levelPool.RemoveAt(0);
				}
				list2.Add(levelAssetHolder);
				curHeight += levelAssetHolder.length;
				bool flag = false;
				if (levelPool.Count == 0 && levelGroups[currentGroupID].endSubregion)
				{
					flag = true;
				}
				if (subregionOrder == SubregionOrder.single)
				{
					flag = true;
				}
				else if (!useLevelCount && currentSubregionHeight >= subregionHeight)
				{
					flag = true;
				}
				else if (useLevelCount && levelCounter + 1 >= targetSubregionLength)
				{
					flag = true;
				}
				levelCounter++;
				currentSubregionHeight += levelAssetHolder.length;
				if (flag)
				{
					return list2;
				}
			}
			return list2;
			M_Level.LevelAssetHolder PullRandomLevelFromPool()
			{
				if (levelPool.Count > 0)
				{
					M_Level.LevelAssetHolder levelAssetHolder2 = levelPool[UnityEngine.Random.Range(0, levelPool.Count)];
					levelPool.Remove(levelAssetHolder2);
					return levelAssetHolder2;
				}
				return null;
			}
			void RefillPoolIfEmpty()
			{
				if (levelPool.Count == 0)
				{
					if (currentGroupID < 0 || currentGroupID >= levelGroups.Count)
					{
						currentGroupID = 0;
					}
					else
					{
						currentGroupID++;
					}
					if (currentGroupID >= levelGroups.Count)
					{
						currentGroupID = 0;
					}
					if (levelGroups == null || levelGroups.Count == 0)
					{
						Debug.LogError("Level Group for " + base.name + " is empty.");
					}
					else
					{
						LevelGroup levelGroup = levelGroups[currentGroupID];
						List<M_Level.LevelAssetHolder> list3 = new List<M_Level.LevelAssetHolder>();
						if (levelGroup.length <= 0)
						{
							list3.AddRange(levelGroup.levelReferences);
							{
								foreach (M_Level.LevelAssetHolder item in list3)
								{
									if (item.GetLevel().spawnSettings.RandomCheck())
									{
										levelPool.Add(item);
									}
								}
								return;
							}
						}
						list3.AddRange(levelGroup.levelReferences);
						int num = 0;
						int num2 = 0;
						while (num < levelGroup.length)
						{
							int index = UnityEngine.Random.Range(0, list3.Count);
							if (list3.Count > 0 && list3[index].GetLevel() != null)
							{
								Debug.Log("GETTING RANDOM LEVEL: " + list3[index].GetLevel().name);
								if (list3[index].GetLevel().spawnSettings.RandomCheck())
								{
									levelPool.Add(list3[index]);
									list3.RemoveAt(index);
									num++;
								}
								else
								{
									Debug.Log("Failed.");
									list3.RemoveAt(index);
								}
								if (list3.Count == 0)
								{
									Debug.Log("No Rooms Left");
									break;
								}
							}
							else
							{
								Debug.Log("No Rooms Left But Worse.");
								if (list3.Count == 0)
								{
									break;
								}
								num2++;
								if (num2 > 100)
								{
									break;
								}
							}
						}
					}
				}
			}
		}
	}
}
