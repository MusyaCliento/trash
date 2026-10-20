using System;
using System.Collections.Generic;
using UnityEngine;

public class DEN_DeathwallManager : MonoBehaviour
{
	private class PerLevel : IComparable<PerLevel>
	{
		public DEN_DeathwallManager deathwall;

		public M_Level level;

		public int CompareTo(PerLevel obj)
		{
			if (level == null && obj.level == null)
			{
				return 0;
			}
			if (level == null || obj.level == null)
			{
				if (!(level == null))
				{
					return 1;
				}
				return -1;
			}
			return level.transform.GetSiblingIndex().CompareTo(obj.level.transform.GetSiblingIndex());
		}
	}

	private class Shared
	{
		public int lastUpdatedFrame = -1;

		public List<PerLevel> perLevel = new List<PerLevel>();
	}

	public List<DEN_Deathwall> startingDeathwalls;

	private readonly List<DEN_Deathwall> runningDeathwalls = new List<DEN_Deathwall>();

	private PerLevel perLevel;

	private void OnEnable()
	{
		Shared shared = GetShared();
		if (perLevel == null)
		{
			int num = FindInShared(shared);
			perLevel = ((num != -1) ? shared.perLevel[num] : null);
		}
		if (perLevel != null)
		{
			return;
		}
		perLevel = new PerLevel
		{
			deathwall = this
		};
		Transform parent = base.transform;
		while (parent != null)
		{
			if (parent.TryGetComponent<M_Level>(out var component))
			{
				perLevel.level = component;
				break;
			}
			parent = parent.parent;
		}
		if (perLevel.level != null)
		{
			shared.perLevel.Add(perLevel);
			shared.perLevel.Sort();
		}
	}

	private void OnDestroy()
	{
		Shared shared = GetShared();
		int num = FindInShared(shared);
		if (num != -1)
		{
			shared.perLevel.RemoveAt(num);
		}
	}

	private void Update()
	{
		if (perLevel.level == null)
		{
			float speedMult = 1f;
			UpdateDeathwallsInLevel(perLevel, speedMult);
		}
		else
		{
			UpdateShared();
		}
	}

	private void UpdateShared()
	{
		int frameCount = Time.frameCount;
		Shared shared = GetShared();
		if (shared.lastUpdatedFrame == frameCount)
		{
			return;
		}
		shared.lastUpdatedFrame = frameCount;
		for (int i = 0; i < shared.perLevel.Count; i++)
		{
			PerLevel perLevel = shared.perLevel[i];
			bool num = perLevel.deathwall.runningDeathwalls.Count > 0;
			float speedMult = 1f;
			UpdateDeathwallsInLevel(perLevel, speedMult);
			bool flag = perLevel.deathwall.runningDeathwalls.Count > 0;
			bool flag2 = i + 1 < shared.perLevel.Count && shared.perLevel[i].level.transform.GetSiblingIndex() + 1 == shared.perLevel[i + 1].level.transform.GetSiblingIndex();
			if (num && !flag && flag2)
			{
				shared.perLevel[i + 1].deathwall.StartIfNoneActive();
			}
		}
	}

	private void UpdateDeathwallsInLevel(PerLevel perLevel, float speedMult)
	{
		float deltaTime = Time.deltaTime;
		for (int i = 0; i < perLevel.deathwall.runningDeathwalls.Count; i++)
		{
			DEN_Deathwall dEN_Deathwall = perLevel.deathwall.runningDeathwalls[i];
			while (dEN_Deathwall.points.Count > 0)
			{
				DEN_Deathwall.PathPoint pathPoint = dEN_Deathwall.points[0];
				Transform transform = dEN_Deathwall.transform;
				Vector3 position = pathPoint.transform.position;
				float maxDistanceDelta = speedMult * dEN_Deathwall.speed * pathPoint.speedMult * deltaTime;
				Vector3 vector = Vector3.MoveTowards(transform.position, position, maxDistanceDelta);
				bool num = (vector - position).sqrMagnitude < 0.01f;
				transform.position = vector;
				if (!num)
				{
					break;
				}
				dEN_Deathwall.points.RemoveAt(0);
				for (int j = 0; j < pathPoint.nextDeathwalls.Count; j++)
				{
					perLevel.deathwall.runningDeathwalls.Add(pathPoint.nextDeathwalls[j]);
				}
				pathPoint.onReached?.Invoke();
			}
			if (dEN_Deathwall.points.Count == 0)
			{
				perLevel.deathwall.runningDeathwalls.RemoveAt(i--);
			}
		}
	}

	public void StartIfNoneActive()
	{
		Shared shared = GetShared();
		int num = FindInShared(shared);
		if (num == -1)
		{
			this.perLevel.deathwall.runningDeathwalls.AddRange(startingDeathwalls);
			return;
		}
		bool flag = false;
		int num2 = num - 1;
		while (num2 >= 0)
		{
			PerLevel perLevel = shared.perLevel[num2];
			PerLevel perLevel2 = shared.perLevel[num2 + 1];
			int siblingIndex = perLevel.level.transform.GetSiblingIndex();
			int siblingIndex2 = perLevel2.level.transform.GetSiblingIndex();
			if (siblingIndex + 1 != siblingIndex2)
			{
				break;
			}
			if (perLevel.deathwall.runningDeathwalls.Count > 0)
			{
				flag = true;
				break;
			}
			num--;
		}
		if (!flag)
		{
			for (int i = 0; i < startingDeathwalls.Count; i++)
			{
				runningDeathwalls.Add(startingDeathwalls[i]);
			}
		}
	}

	private Shared GetShared()
	{
		return CL_GameManager.GetPerRunData<Shared>();
	}

	private int FindInShared(Shared shared)
	{
		for (int i = 0; i < shared.perLevel.Count; i++)
		{
			if (shared.perLevel[i].deathwall == this)
			{
				return i;
			}
		}
		return -1;
	}
}
