using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spawn Table", menuName = "White Knuckle/Spawning/Spawn Table")]
public class SpawnTable : ScriptableObject
{
	[Serializable]
	public class SpawnSettings
	{
		[Serializable]
		public class StatCheck
		{
			public enum Evaluation
			{
				equals = 0,
				lesserThan = 1,
				greaterThan = 2
			}

			public string statName;

			public bool session = true;

			public Evaluation evaluation;

			public int evaluationInteger;

			public bool invertFlag;
		}

		[Range(0f, 2f)]
		public float spawnChance = 1f;

		public float chanceMultiplier = 1f;

		[Header("Adjustments")]
		[Space]
		public bool useProgressionUnlock;

		public string unlockName;

		public bool useXP;

		public float xpMin;

		public float xpMax = 1f;

		public AnimationCurve xpSpawnModifier;

		public bool useDifficulty;

		public float difficultyMin;

		public float difficultyMax = 1f;

		public AnimationCurve difficultySpawnModifier;

		public bool useAscent;

		public float ascentMin;

		public float ascentMax = 1f;

		public AnimationCurve ascentSpawnModifier;

		public bool useFlags;

		public List<string> flagWhitelist;

		public List<string> flagBlacklist;

		public bool flagUsesUnlockAll;

		public bool useStats;

		public string sessionStat;

		public float sessionStatMin;

		public float sessionStatMax = 1f;

		public AnimationCurve sessionStatModifier;

		public bool checkStatList;

		public List<StatCheck> statCheckers;

		public bool useHardMode;

		public bool hardModeOnly;

		public float hardModeMult = 1f;

		public float hardModeMin;

		public bool forceIfUnlockAll;

		[SerializeReference]
		public List<SpawnSettingModule> settingModules;

		public float GetEffectiveSpawnChance()
		{
			float num = spawnChance * chanceMultiplier;
			if (forceIfUnlockAll && (CL_GameManager.GetCurrentGamemode().IsCompetitive() || SettingsManager.settings.unlockAll))
			{
				return 1f;
			}
			if (useProgressionUnlock && !CL_ProgressionManager.HasProgressionUnlock(unlockName))
			{
				return 0f;
			}
			if (useFlags)
			{
				foreach (string item in flagBlacklist)
				{
					if (CL_GameManager.HasActiveFlag(item))
					{
						return 0f;
					}
				}
				if (flagWhitelist.Count > 0)
				{
					bool flag = false;
					foreach (string item2 in flagWhitelist)
					{
						if (CL_GameManager.HasActiveFlag(item2, flagUsesUnlockAll))
						{
							flag = true;
						}
					}
					if (!flag)
					{
						return 0f;
					}
				}
			}
			if (useDifficulty)
			{
				float num2 = Mathf.Clamp01((CL_GameManager.currentDifficulty - difficultyMin) / (difficultyMax - difficultyMin));
				num *= num2;
			}
			if (useStats)
			{
				float time = Mathf.Clamp01(((float)StatManager.GetStatisticInt(StatManager.sessionStats, sessionStat) - sessionStatMin) / (sessionStatMax - sessionStatMin));
				num *= sessionStatModifier.Evaluate(time);
			}
			if (useHardMode)
			{
				if (CL_GameManager.IsHardmode())
				{
					num *= hardModeMult;
				}
				else if (hardModeOnly)
				{
					return 0f;
				}
			}
			if (checkStatList)
			{
				foreach (StatCheck statChecker in statCheckers)
				{
					if (!CheckStat(statChecker))
					{
						return 0f;
					}
				}
			}
			float time2 = Mathf.Clamp01((CL_GameManager.gMan.GetPlayerBestTravelDistance() - ascentMin) / (ascentMax - ascentMin));
			num *= (useAscent ? ascentSpawnModifier.Evaluate(time2) : 1f);
			if (settingModules != null && settingModules.Count > 0)
			{
				foreach (SpawnSettingModule settingModule in settingModules)
				{
					num *= settingModule.Check();
				}
			}
			if (CL_GameManager.IsHardmode())
			{
				num = Mathf.Max(num, hardModeMin);
			}
			return num;
		}

		public bool RandomCheck(bool runOnSpawn = true, float chanceMult = 1f)
		{
			float value = UnityEngine.Random.value;
			if (GetEffectiveSpawnChance() * chanceMult > value)
			{
				if (runOnSpawn)
				{
					OnSpawn();
				}
				return true;
			}
			return false;
		}

		public bool CheckStat(StatCheck check)
		{
			int num = 0;
			bool flag = false;
			num = ((!check.session) ? StatManager.GetTotalStatisticInt(check.statName) : StatManager.GetStatisticInt(StatManager.sessionStats, check.statName));
			if (check.evaluation == StatCheck.Evaluation.equals)
			{
				if (num == check.evaluationInteger)
				{
					flag = true;
				}
			}
			else if (check.evaluation == StatCheck.Evaluation.greaterThan)
			{
				if (num > check.evaluationInteger)
				{
					flag = true;
				}
			}
			else if (check.evaluation == StatCheck.Evaluation.lesserThan && num < check.evaluationInteger)
			{
				flag = true;
			}
			if (check.invertFlag)
			{
				flag = !flag;
			}
			return flag;
		}

		public void OnSpawn()
		{
			if (settingModules == null)
			{
				return;
			}
			foreach (SpawnSettingModule settingModule in settingModules)
			{
				settingModule.OnSpawn();
			}
		}
	}

	[Serializable]
	public class SpawnTableAsset
	{
		public string name;

		public List<string> tags;

		public List<GameObject> prefabs;

		public SpawnSettings spawnSettings;

		[TextArea(4, 15)]
		public List<string> data;

		public float GetEffectiveSpawnChance()
		{
			return spawnSettings.GetEffectiveSpawnChance();
		}

		public GameObject GetRandomPrefab()
		{
			if (prefabs == null || prefabs.Count == 0)
			{
				return null;
			}
			return prefabs[UnityEngine.Random.Range(0, prefabs.Count)];
		}
	}

	public List<SpawnTableAsset> spawnList;

	public SpawnTableAsset GetRandomSpawnObject()
	{
		if (spawnList == null || spawnList.Count == 0)
		{
			Debug.LogWarning("Spawn table is empty!");
			return null;
		}
		float num = 0f;
		foreach (SpawnTableAsset spawn in spawnList)
		{
			num += spawn.GetEffectiveSpawnChance();
		}
		float num2 = UnityEngine.Random.Range(0f, num);
		float num3 = 0f;
		foreach (SpawnTableAsset spawn2 in spawnList)
		{
			num3 += spawn2.GetEffectiveSpawnChance();
			if (num2 <= num3)
			{
				spawn2.spawnSettings.OnSpawn();
				return spawn2;
			}
		}
		return null;
	}

	public SpawnTableAsset GetSpawnObject(string name)
	{
		foreach (SpawnTableAsset spawn in spawnList)
		{
			if (spawn.name == name)
			{
				return spawn;
			}
		}
		return null;
	}

	public string GetSpawnTableString()
	{
		string text = "\n";
		float num = 0f;
		foreach (SpawnTableAsset spawn in spawnList)
		{
			num += spawn.spawnSettings.spawnChance * spawn.spawnSettings.chanceMultiplier;
		}
		foreach (SpawnTableAsset spawn2 in spawnList)
		{
			float num2 = (float)Math.Round(spawn2.spawnSettings.spawnChance * spawn2.spawnSettings.chanceMultiplier / num, 2);
			text += $"  {spawn2.name.ToUpper()} : {num2 * 100f}%\n";
		}
		return text;
	}
}
