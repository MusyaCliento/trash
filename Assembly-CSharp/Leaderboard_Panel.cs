using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class Leaderboard_Panel : MonoBehaviour
{
	public enum LeaderboardType
	{
		top = 0,
		friendsOnly = 1,
		surrounding = 2
	}

	public enum ScoreType
	{
		score = 0,
		time = 1
	}

	public bool refreshOnEnable = true;

	public Transform scoreRoot;

	public Leaderboard_Score scorePrefab;

	public TMP_Text title;

	public TMP_Text scoreTypeText;

	public LeaderboardType defaultType;

	public M_Gamemode.LeaderboardCategories scoreType;

	public int scoresToPull = 10;

	private List<Leaderboard_Score> scoreObjects;

	public Color isMeColor = Color.red;

	public UI_LeaderboardEntryDetailWindow entryDetailWindow;

	private Task updateScoreTask;

	private CancellationTokenSource detailsDownloadCt;

	private float detailsDownloadTimeoutSec = 5f;

	private float detailsDownloadStartTime;

	private int offsetFromPlayer;

	private LeaderboardEntry detailsLastScoreEntry;

	public static Action _RefreshLeaderboards;

	private LeaderboardEntry[] scores;

	private int prevScoreOffset;

	private CancellationTokenSource currentCancellationTokenSource;

	private void Awake()
	{
		CreateScoreObjects();
		if (entryDetailWindow != null)
		{
			entryDetailWindow.leaderboardPanel = this;
		}
	}

	private void Update()
	{
		if (entryDetailWindow != null && detailsDownloadCt != null && !detailsDownloadCt.IsCancellationRequested && detailsDownloadStartTime + detailsDownloadTimeoutSec < Time.time)
		{
			detailsDownloadCt.Cancel();
			Debug.Log($"Cancelling previous details download because of timeout ({detailsDownloadTimeoutSec} seconds).");
			entryDetailWindow.ShowNoEntryDetails(detailsLastScoreEntry);
		}
	}

	private void OnEnable()
	{
		if (refreshOnEnable)
		{
			Refresh();
		}
		offsetFromPlayer = 0;
		scores = null;
		prevScoreOffset = -1;
		_RefreshLeaderboards = (Action)Delegate.Combine(_RefreshLeaderboards, new Action(Refresh));
	}

	private void OnDisable()
	{
		_RefreshLeaderboards = (Action)Delegate.Remove(_RefreshLeaderboards, new Action(Refresh));
	}

	public void Refresh()
	{
		for (int i = 0; i < scoreObjects.Count; i++)
		{
			if (scoreObjects[i] != null)
			{
				scoreObjects[i].gameObject.SetActive(value: false);
			}
		}
		int num = DarkMachineFunctions.FirstOneBit((uint)CL_GameManager.gamemode.leaderboardCategories);
		if (num == -1)
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		base.gameObject.SetActive(value: true);
		scoreType = (M_Gamemode.LeaderboardCategories)(1 << num);
		scoreTypeText.text = LeaderboardCategoryToString(scoreType);
		UpdateScores(null);
	}

	public void SwitchScore()
	{
		offsetFromPlayer = 0;
		M_Gamemode.LeaderboardCategories leaderboardCategories = CL_GameManager.gamemode.leaderboardCategories;
		int num = (int)scoreType;
		num |= num - 1;
		int num2 = DarkMachineFunctions.FirstOneBit((uint)leaderboardCategories & (uint)(~num));
		if (num2 == -1)
		{
			num2 = DarkMachineFunctions.FirstOneBit((uint)leaderboardCategories);
		}
		if (num2 == -1)
		{
			Debug.LogError("wtf why no one bits?");
		}
		scoreType = (M_Gamemode.LeaderboardCategories)(1 << num2);
		scoreTypeText.text = LeaderboardCategoryToString(scoreType);
		UpdateScores(null);
	}

	private string LeaderboardCategoryToString(M_Gamemode.LeaderboardCategories cat)
	{
		char[] array = cat.ToString().ToCharArray();
		array[0] = char.ToUpper(array[0]);
		return new string(array);
	}

	public void SwitchType()
	{
		defaultType = (LeaderboardType)((int)(++defaultType) % 3);
		offsetFromPlayer = 0;
		Debug.Log(defaultType);
		switch (defaultType)
		{
		case LeaderboardType.top:
			title.text = "Leaderboard - Top";
			break;
		case LeaderboardType.friendsOnly:
			title.text = "Leaderboard - Friends";
			break;
		case LeaderboardType.surrounding:
			title.text = "Leaderboard - Global";
			break;
		}
		UpdateScores(null);
	}

	public void OffsetFromPlayerReset()
	{
		offsetFromPlayer = 0;
		UpdateScores(null);
	}

	public void OffsetFromPlayerAdd(int amount)
	{
		offsetFromPlayer += amount;
		if (defaultType == LeaderboardType.top)
		{
			offsetFromPlayer = Mathf.Max(offsetFromPlayer, 0);
		}
		UpdateScores(amount);
	}

	private void UpdateScores(int? onlyAdjustingPositionAmount)
	{
		StartUpdateScore(onlyAdjustingPositionAmount);
	}

	private void CreateScoreObjects()
	{
		scoreObjects = new List<Leaderboard_Score>();
		for (int i = 0; i < scoresToPull; i++)
		{
			Leaderboard_Score item = UnityEngine.Object.Instantiate(scorePrefab, scoreRoot);
			scoreObjects.Add(item);
		}
	}

	private void StartUpdateScore(int? onlyAdjustingPositionAmount)
	{
		if (currentCancellationTokenSource != null && !currentCancellationTokenSource.IsCancellationRequested)
		{
			currentCancellationTokenSource.Cancel();
		}
		currentCancellationTokenSource = new CancellationTokenSource();
		updateScoreTask = UpdateScore(GetCurrentLeaderboardID(), onlyAdjustingPositionAmount, currentCancellationTokenSource.Token);
	}

	public async Task UpdateScore(string leaderboardId, int? onlyAdjustingPositionAmount, CancellationToken ct)
	{
		for (int i = 0; i < scoreObjects.Count; i++)
		{
			if (scoreObjects[i] != null)
			{
				scoreObjects[i].gameObject.SetActive(value: false);
			}
		}
		M_Gamemode gamemode = CL_GameManager.GetCurrentGamemode();
		LeaderboardApi leaderboardApi = CL_Leaderboard.leaderboardApi;
		LeaderboardUser currentUser = leaderboardApi.UserCurrent;
		LeaderboardEntry[] oldScores = scores;
		if (ct.IsCancellationRequested)
		{
			return;
		}
		if (defaultType == LeaderboardType.top)
		{
			scores = await leaderboardApi.QueryRange(leaderboardId, scoresToPull, offsetFromPlayer * scoresToPull, ct);
		}
		else if (defaultType == LeaderboardType.friendsOnly)
		{
			scores = await leaderboardApi.QueryFriends(leaderboardId, ct);
		}
		else if (defaultType == LeaderboardType.surrounding)
		{
			scores = await leaderboardApi.QuerySurrounding(leaderboardId, -scoresToPull / 2 + offsetFromPlayer * scoresToPull, scoresToPull / 2 + offsetFromPlayer * scoresToPull, ct);
			if (scores == null || scores.Length == 0)
			{
				scores = await leaderboardApi.QueryRange(leaderboardId, scoresToPull, offsetFromPlayer * scoresToPull, ct);
			}
		}
		if (ct.IsCancellationRequested)
		{
			return;
		}
		if (onlyAdjustingPositionAmount.HasValue && defaultType != LeaderboardType.friendsOnly && oldScores != null && scores != null && oldScores.Length != 0 && scores.Length != 0 && (oldScores[0].user == scores[0].user || oldScores[^1].user == scores[^1].user))
		{
			offsetFromPlayer -= onlyAdjustingPositionAmount.GetValueOrDefault();
		}
		int num = -1;
		int num2 = 0;
		while (scores != null && num2 < scores.Length)
		{
			if (scores[num2].user == currentUser)
			{
				num = num2;
				break;
			}
			num2++;
		}
		int scoreOffset = 0;
		if (num != -1 && scoreObjects.Count > 0 && num >= scoreObjects.Count && defaultType != LeaderboardType.top)
		{
			scoreOffset = num - scoreObjects.Count + 1;
		}
		if (defaultType == LeaderboardType.friendsOnly)
		{
			scoreOffset += offsetFromPlayer * scoresToPull;
		}
		scoreOffset = Mathf.Clamp(scoreOffset, 0, scoreObjects.Count - 1);
		if (onlyAdjustingPositionAmount.HasValue && defaultType == LeaderboardType.friendsOnly && scoreOffset == prevScoreOffset)
		{
			offsetFromPlayer -= onlyAdjustingPositionAmount.GetValueOrDefault();
		}
		prevScoreOffset = scoreOffset;
		for (int j = 0; j < scoreObjects.Count && j < scores.Length; j++)
		{
			int scoreID = scoreOffset + j;
			if (scores == null || scoreID >= scores.Length)
			{
				scoreObjects[j].gameObject.SetActive(value: false);
				continue;
			}
			scoreObjects[j].gameObject.SetActive(value: true);
			scoreObjects[j].positionText.text = $"<mspace=''>{scores[scoreID].placement}</mspace>";
			scoreObjects[j].SetNameText(scores[scoreID].user.name ?? "");
			scoreObjects[j].scoreInfo = scores[scoreID];
			scoreObjects[j].OnSelect = UpdateScoreDetails;
			bool[] array = DarkMachineFunctions.UnpackBools(scores[scoreID].flags, 4);
			bool active = array[0];
			bool active2 = array[1];
			scoreObjects[j].ikIcon.gameObject.SetActive(active);
			scoreObjects[j].hmIcon.gameObject.SetActive(active2);
			if (scoreType == M_Gamemode.LeaderboardCategories.time)
			{
				TimeSpan timeSpan = TimeSpan.FromSeconds(scores[scoreID].score);
				if (gamemode.timeMeasure == M_Gamemode.TimeScoreMeasure.centiseconds)
				{
					timeSpan = TimeSpan.FromSeconds((float)scores[scoreID].score / 100f);
					scoreObjects[j].scoreText.text = $"{timeSpan:mm\\:ss\\.ff}";
				}
				else
				{
					scoreObjects[j].scoreText.text = $"{timeSpan:hh\\:mm\\:ss}";
				}
			}
			else
			{
				scoreObjects[j].scoreText.text = $"{scores[scoreID].score:#,0}";
			}
			Texture2D texture = await leaderboardApi.UserAvatar(scores[scoreID].user, ct);
			if (ct.IsCancellationRequested)
			{
				break;
			}
			scoreObjects[j].profile.texture = texture;
			if (scores[scoreID].user == currentUser)
			{
				scoreObjects[j].positionText.color = isMeColor;
				scoreObjects[j].nameText.color = isMeColor;
				scoreObjects[j].scoreText.color = isMeColor;
			}
			else
			{
				scoreObjects[j].positionText.color = Color.white;
				scoreObjects[j].nameText.color = Color.white;
				scoreObjects[j].scoreText.color = Color.white;
			}
		}
	}

	public void UpdateScoreOffline()
	{
		for (int i = 0; i < scoreObjects.Count; i++)
		{
			scoreObjects[i].gameObject.SetActive(value: false);
		}
		string text = "-score";
		if (scoreType == M_Gamemode.LeaderboardCategories.time)
		{
			text = "-time";
		}
		string text2 = "";
		if (CL_GameManager.GetCurrentGamemode().IsHardMode())
		{
			text2 += "-hard";
		}
		if (CL_GameManager.GetCurrentGamemode().IsIronKnuckle())
		{
			text2 += "-ik";
		}
		if (CL_GameManager.GetCurrentGamemode().IsCompetitive())
		{
			text2 += "-competitive";
		}
		CL_Leaderboard.OfflineLeaderboard offlineLeaderboard = CL_Leaderboard.OfflineLeaderboard.GetOfflineLeaderboard(CL_GameManager.gamemode.steamLeaderboardName + text2 + text);
		CL_Leaderboard.OfflineLeaderboard.LeaderboardEntry[] array = null;
		array = offlineLeaderboard.GetOfflineScores(scoresToPull);
		for (int j = 0; j < scoreObjects.Count; j++)
		{
			if (j >= array.Length)
			{
				scoreObjects[j].gameObject.SetActive(value: false);
				continue;
			}
			scoreObjects[j].gameObject.SetActive(value: true);
			scoreObjects[j].positionText.text = $"<mspace=''>{array[j].rank}</mspace>";
			scoreObjects[j].SetNameText(array[j].name ?? "");
			if (scoreType == M_Gamemode.LeaderboardCategories.time)
			{
				TimeSpan timeSpan = TimeSpan.FromSeconds(array[j].score);
				scoreObjects[j].scoreText.text = $"{timeSpan:hh\\:mm\\:ss}";
			}
			else
			{
				scoreObjects[j].scoreText.text = $"{array[j].score}";
			}
			if (array[j].id == CL_Leaderboard.OfflineLeaderboard.curPlayerID)
			{
				scoreObjects[j].positionText.color = isMeColor;
				scoreObjects[j].nameText.color = isMeColor;
				scoreObjects[j].scoreText.color = isMeColor;
			}
			else
			{
				scoreObjects[j].positionText.color = Color.white;
				scoreObjects[j].nameText.color = Color.white;
				scoreObjects[j].scoreText.color = Color.white;
			}
		}
	}

	public void UpdateLeaderboardName(string n)
	{
		string text = "-score";
		if (scoreType == M_Gamemode.LeaderboardCategories.time)
		{
			text = "-time";
		}
		string text2 = "";
		if (CL_GameManager.GetBaseGamemode().IsHardMode())
		{
			text2 += "-hard";
		}
		if (CL_GameManager.GetBaseGamemode().IsIronKnuckle())
		{
			text2 += "-ik";
		}
		CL_Leaderboard.OfflineLeaderboard.GetOfflineLeaderboard(CL_GameManager.gamemode.steamLeaderboardName + text2 + text).UpdateOfflineLeaderboardPlayerName(n);
	}

	private void UpdateScoreDetails(LeaderboardEntry scoreInfo)
	{
		if (detailsDownloadCt != null && !detailsDownloadCt.IsCancellationRequested)
		{
			Debug.Log("Cancelling previous details download because new request came in.");
			detailsDownloadCt.Cancel();
		}
		entryDetailWindow.Show();
		entryDetailWindow.StartLoad();
		entryDetailWindow.SetUser(scoreInfo.user);
		detailsDownloadCt = new CancellationTokenSource();
		detailsDownloadStartTime = Time.time;
		detailsLastScoreEntry = scoreInfo;
		OpenScoreDetails(GetCurrentLeaderboardID(), scoreInfo, detailsDownloadCt.Token);
	}

	private async void OpenScoreDetails(string leaderboardId, LeaderboardEntry scoreInfo, CancellationToken ct)
	{
		CL_GameManager.GetCurrentGamemode();
		byte[] bytes = await CL_Leaderboard.leaderboardApi.QueryDetails(leaderboardId, scoreInfo.user, "userData_1", ct);
		CL_Leaderboard.WK_Leaderboard_UserData wK_Leaderboard_UserData = JsonConvert.DeserializeObject<CL_Leaderboard.WK_Leaderboard_UserData>(Encoding.UTF8.GetString(bytes));
		detailsDownloadCt = null;
		if (wK_Leaderboard_UserData != null)
		{
			entryDetailWindow.ShowDetails(scoreInfo, wK_Leaderboard_UserData);
			return;
		}
		entryDetailWindow.ShowNoEntryDetails(scoreInfo);
		Debug.Log($"No associated leaderbaord entry on {leaderboardId} for {scoreInfo.user.handle}!");
	}

	public string GetCurrentLeaderboardBaseID()
	{
		M_Gamemode currentGamemode = CL_GameManager.GetCurrentGamemode();
		string leaderboardSettingAffix = currentGamemode.GetLeaderboardSettingAffix();
		return (currentGamemode.useGlobalSteamLeaderboardVersion ? "ea-v08-" : "") + currentGamemode.steamLeaderboardName + leaderboardSettingAffix;
	}

	public string GetCurrentLeaderboardID()
	{
		return GetCurrentLeaderboardBaseID() + "-" + scoreType;
	}
}
