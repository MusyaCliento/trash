using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class CL_Leaderboard
{
	public class WK_Leaderboard_Core
	{
		public const string leaderboardAppend = "ea-v08-";

		public static bool disableLeaderboards;
	}

	[Serializable]
	public class WK_Leaderboard_UserData
	{
		public string gamemodeID;

		public string seed;

		public List<string> gamemodeSettings = new List<string>();

		public List<string> activeTrinkets = new List<string>();

		public List<string> scoreData = new List<string>();

		public List<string> runData = new List<string>();

		public List<string> perks = new List<string>();
	}

	public class OfflineLeaderboard
	{
		[Serializable]
		public class LeaderboardEntry
		{
			public string name;

			public string id;

			public int rank;

			public int score;

			public bool isMe;
		}

		public static string curPlayerName = "test";

		public static string curPlayerID = "";

		public string leaderboardName;

		public List<LeaderboardEntry> currentEntries;

		public static OfflineLeaderboard GetOfflineLeaderboard(string lName)
		{
			OfflineLeaderboard offlineLeaderboard = null;
			string path = Path.Combine(Application.persistentDataPath, "Leaderboards/" + lName + "-save.json");
			if (File.Exists(path))
			{
				offlineLeaderboard = JsonUtility.FromJson<OfflineLeaderboard>(File.ReadAllText(path));
			}
			else
			{
				offlineLeaderboard = new OfflineLeaderboard();
				offlineLeaderboard.leaderboardName = lName;
				offlineLeaderboard.currentEntries = new List<LeaderboardEntry>();
			}
			return offlineLeaderboard;
		}

		internal LeaderboardEntry[] GetOfflineScores(int scoresToPull)
		{
			List<LeaderboardEntry> list = new List<LeaderboardEntry>();
			for (int i = 0; i < scoresToPull && i < currentEntries.Count; i++)
			{
				list.Add(currentEntries[i]);
			}
			return list.ToArray();
		}

		internal void SubmitOfflineScore(int score, bool ascending = true)
		{
			if (currentEntries == null)
			{
				currentEntries = new List<LeaderboardEntry>();
			}
			LeaderboardEntry leaderboardEntry = new LeaderboardEntry();
			leaderboardEntry.score = score;
			leaderboardEntry.name = curPlayerName;
			leaderboardEntry.id = curPlayerID;
			currentEntries.Add(leaderboardEntry);
			if (ascending)
			{
				currentEntries = currentEntries.OrderBy((LeaderboardEntry o) => -o.score).ToList();
			}
			else
			{
				currentEntries = currentEntries.OrderBy((LeaderboardEntry o) => o.score).ToList();
			}
			for (int num = 0; num < currentEntries.Count; num++)
			{
				currentEntries[num].rank = num + 1;
			}
			UpdateOfflineLeaderboardJson();
		}

		public void UpdateOfflineLeaderboardJson()
		{
			Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "Leaderboards/"));
			string path = Path.Combine(Application.persistentDataPath, "Leaderboards/" + leaderboardName + "-save.json");
			string contents = JsonUtility.ToJson(this, prettyPrint: true);
			File.WriteAllText(path, contents);
			Debug.Log("Writing Leaderboard");
		}

		public void UpdateOfflineLeaderboardPlayerName(string n)
		{
			curPlayerName = n;
			foreach (LeaderboardEntry currentEntry in currentEntries)
			{
				Debug.Log(currentEntry.id);
				if (currentEntry.id == curPlayerID)
				{
					currentEntry.name = curPlayerName;
					Debug.Log("Updating Name: " + n);
					break;
				}
			}
			Debug.Log("Updated Name!");
			UpdateOfflineLeaderboardJson();
		}
	}

	public static LeaderboardApi leaderboardApi;

	public static WK_Leaderboard_UserData CreateUserDataFromCurrentSession()
	{
		if (ENT_Player.GetPlayer() == null || WorldLoader.instance == null)
		{
			return null;
		}
		M_Gamemode baseGamemode = CL_GameManager.GetBaseGamemode();
		WK_Leaderboard_UserData wK_Leaderboard_UserData = new WK_Leaderboard_UserData
		{
			gamemodeID = baseGamemode.GetGamemodeName(),
			seed = $"{WorldLoader.instance.GetSeed()}"
		};
		wK_Leaderboard_UserData.gamemodeSettings = new List<string>();
		wK_Leaderboard_UserData.gamemodeSettings.AddRange(StatManager.saveData.GetGameMode(baseGamemode.gamemodeName).activeSettings);
		wK_Leaderboard_UserData.activeTrinkets.AddRange(StatManager.saveData.GetGamemodeTrinkets(baseGamemode.GetGamemodeName()));
		wK_Leaderboard_UserData.scoreData = new List<string>();
		foreach (CL_ScoreManager.SessionScore.Score score in CL_ScoreManager.sessionScore.scores)
		{
			wK_Leaderboard_UserData.scoreData.Add($"{score.id}:{score.title}:{score.count}:{score.bonus}:{score.multiplier + 1f}");
		}
		if (StatManager.sessionStats != null)
		{
			List<string> runData = new List<string>
			{
				string.Format("score:{0}", StatManager.sessionStats.GetStatistic("score").GetValue()),
				string.Format("travel-distance:{0}", StatManager.sessionStats.GetStatistic("travel-distance").GetValue()),
				string.Format("game-time:{0}", StatManager.sessionStats.GetStatistic("game-time").GetValue()),
				string.Format("travel-speed:{0}", StatManager.sessionStats.GetStatistic("travel-speed").GetValue()),
				string.Format("death-height:{0}", StatManager.sessionStats.GetStatistic("death-height").GetValue()),
				string.Format("bank-roaches:{0}", StatManager.sessionStats.GetStatistic("bank-roaches").GetValue()),
				string.Format("deaths:{0}", StatManager.sessionStats.GetStatistic("deaths").GetValue()),
				$"endtime:{DateTime.UtcNow.Ticks}"
			};
			wK_Leaderboard_UserData.runData = runData;
		}
		List<string> list = new List<string>();
		foreach (Perk oldPerk in ENT_Player.GetPlayer().GetOldPerks())
		{
			list.Add($"{oldPerk.id}:{oldPerk.stackAmount}");
		}
		wK_Leaderboard_UserData.perks = list;
		Debug.Log("Creating Leaderboard UserData");
		return wK_Leaderboard_UserData;
	}
}
