using System;
using System.Collections.Generic;
using UnityEngine;

public class CL_ProgressionManager : MonoBehaviour
{
	[Serializable]
	public class ProgressionUnlockOld
	{
		public enum RequirementType
		{
			experience = 0,
			achievement = 1
		}

		public string name;

		public RequirementType requirement;

		public int unlockExperience;

		public string unlockAchievement;

		public bool state;

		[Header("Unlock Details")]
		public Sprite unlockIcon;

		public string unlockTitle;

		[TextArea]
		public string unlockDescription;
	}

	public class PopupInfo
	{
		public Sprite icon;

		public string title;

		public string desc;
	}

	public List<ProgressionUnlock> unlockList;

	public static CL_ProgressionManager instance;

	private static Dictionary<string, ProgressionUnlock> progressionDict;

	public static int playerExperience = 0;

	private bool initialized;

	public UI_ProgressionPopup popupAsset;

	public UI_ProgressionUnlockList deathList;

	private static List<ProgressionUnlock> sessionUnlocks = new List<ProgressionUnlock>();

	public static List<PopupInfo> sessionPopups = new List<PopupInfo>();

	private float randomCheckTime;

	private void Awake()
	{
		Initialize();
	}

	internal void Initialize()
	{
		sessionUnlocks = new List<ProgressionUnlock>();
		sessionPopups = new List<PopupInfo>();
		if (initialized)
		{
			return;
		}
		if (instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		instance = this;
		progressionDict = new Dictionary<string, ProgressionUnlock>();
		foreach (ProgressionUnlock unlock in unlockList)
		{
			unlock.TryUpgrade();
			if (SettingsManager.settings.unlockAll)
			{
				unlock.state = true;
			}
			else
			{
				unlock.state = false;
			}
			progressionDict.Add(unlock.id, unlock);
		}
		RefreshExperience();
		initialized = true;
	}

	private void Update()
	{
		randomCheckTime -= Time.deltaTime;
		if (randomCheckTime < 0f)
		{
			randomCheckTime = 10f;
			UpdateUnlocks(showPopups: true);
		}
	}

	private void OnDestroy()
	{
		if (instance == this)
		{
			instance = null;
		}
	}

	public static bool HasProgressionUnlock(string unlockName)
	{
		if (progressionDict == null)
		{
			return false;
		}
		if (progressionDict.ContainsKey(unlockName))
		{
			return progressionDict[unlockName].state;
		}
		return false;
	}

	public static void UpdateUnlocks(bool showPopups = false)
	{
		foreach (ProgressionUnlock unlock in instance.unlockList)
		{
			if (!unlock.state && unlock.CheckUnlock())
			{
				if (!CL_GameManager.GetCurrentGamemode().IsCompetitive() && showPopups)
				{
					ShowUnlockPopup(unlock);
				}
			}
			else if (!unlock.state && unlock.showProgression && unlock.showProgressionPopup && unlock.GetLastProgress() < unlock.GetProgress() && showPopups && !CL_GameManager.GetCurrentGamemode().IsCompetitive())
			{
				ShowUnlockProgress(unlock.unlockIcon, unlock.unlockTitle, "Progress: " + unlock.GetProgressString() + " " + unlock.progressionString);
			}
		}
	}

	public static void AddExperience(int i)
	{
		playerExperience += i;
		StatManager.sessionStats.SetStatistic("progression-experience", playerExperience, StatManager.Statistic.DataType.Int);
		DebugMenu.UpdateDebugText("player-experience", "<color=yellow>Player Experience: " + playerExperience);
	}

	public static void RefreshExperience()
	{
		playerExperience = StatManager.GetStatisticInt(StatManager.saveData.gameStats, "progression-experience");
		UpdateUnlocks();
		DebugMenu.UpdateDebugText("player-experience", "<color=yellow>Player Experience: " + playerExperience);
	}

	public static void ShowUnlockPopup(ProgressionUnlock unlock)
	{
		ShowUnlockPopup(unlock.unlockIcon, unlock.unlockTitle, unlock.unlockDescription, unlock.glowColor, unlock.unlockClip);
	}

	public static void ShowUnlockPopup(Sprite icon, string title, string desc, Color glowColor, AudioClip clip = null, bool addToSession = true)
	{
		if (!(instance == null) && !(instance.popupAsset == null))
		{
			PopupInfo item = new PopupInfo
			{
				icon = icon,
				title = title,
				desc = desc
			};
			if (addToSession)
			{
				sessionPopups.Add(item);
			}
			instance.popupAsset.Popup(icon, title, desc, glowColor, clip);
		}
	}

	public static void ShowUnlockProgress(Sprite icon, string title, string desc)
	{
		if (!(instance == null) && !(instance.popupAsset == null))
		{
			new PopupInfo
			{
				icon = icon,
				title = title,
				desc = desc
			};
			instance.popupAsset.Popup(icon, title, desc, Color.clear);
		}
	}

	public static List<ProgressionUnlock> GetUnlockList()
	{
		return instance.unlockList;
	}

	internal static ProgressionUnlock GetProgressionUnlock(string n)
	{
		if (progressionDict == null)
		{
			return null;
		}
		if (progressionDict.ContainsKey(n))
		{
			return progressionDict[n];
		}
		return null;
	}
}
