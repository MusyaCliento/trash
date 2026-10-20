using System;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UI_LeaderboardEntryDetailWindow : MonoBehaviour
{
	public TMP_Text nameText;

	public TMP_Text gamemodeText;

	public TMP_Text statText;

	public TMP_Text scoreText;

	public UI_Perk_Icon perkIconPrefab;

	public Transform perkIconHolder;

	public GameObject loadRoot;

	public GameObject infoRoot;

	public UnityEvent eventOnShow;

	public UnityEvent eventOnHide;

	private LeaderboardUser user;

	public Leaderboard_Panel leaderboardPanel;

	private bool active;

	public void SetUser(LeaderboardUser u)
	{
		user = u;
	}

	public void Show()
	{
		GetComponent<UI_LerpOpen>().Show();
		StartLoad();
		eventOnShow.Invoke();
		active = true;
	}

	public void Hide()
	{
		GetComponent<UI_LerpOpen>().Hide();
		eventOnHide.Invoke();
		active = false;
	}

	public void StartLoad()
	{
		foreach (Transform item in perkIconHolder)
		{
			if (item != perkIconHolder)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
		}
		loadRoot.SetActive(value: true);
		infoRoot.SetActive(value: false);
	}

	internal void ShowDetails(LeaderboardEntry scoreInfo, CL_Leaderboard.WK_Leaderboard_UserData data)
	{
		user = scoreInfo.user;
		loadRoot.SetActive(value: false);
		infoRoot.SetActive(value: true);
		nameText.text = $"{scoreInfo.user.name} #{scoreInfo.placement}";
		gamemodeText.text = CL_GameManager.GetBaseGamemode().GetGamemodeName();
		string text = "";
		if (data.runData != null && data.runData.Count > 0)
		{
			foreach (string runDatum in data.runData)
			{
				string[] array = runDatum.Split(':');
				float result = 0f;
				if (array.Length <= 1)
				{
					continue;
				}
				if (float.TryParse(array[1], out result))
				{
					result = (float)Math.Round(result, 2);
				}
				switch (array[0])
				{
				case "score":
					text = text + "<color=red><size=24>Score: " + $"{Mathf.FloorToInt(result):#,0}" + "</size></color>\n";
					break;
				case "travel-distance":
					text += $"<color=yellow>Distance: {result}m</color>\n";
					break;
				case "game-time":
					text = text + "Run Playtime: " + DarkMachineFunctions.SecondsToTimeLeaderboardString(result) + "\n";
					break;
				case "travel-speed":
					text += $"Speed: {result}m/s\n";
					break;
				case "endtime":
				{
					if (long.TryParse(array[1], out var result2))
					{
						try
						{
							CultureInfo.CurrentCulture = CultureInfo.InstalledUICulture;
							TimeZoneInfo local = TimeZoneInfo.Local;
							DateTime dateTime = TimeZoneInfo.ConvertTimeFromUtc(new DateTime(result2), local);
							text += $"Date: {dateTime}\n";
						}
						finally
						{
							CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
						}
					}
					break;
				}
				}
			}
		}
		statText.text = text;
		string text2 = "";
		if (data.scoreData != null && data.scoreData.Count > 0)
		{
			foreach (string scoreDatum in data.scoreData)
			{
				string[] array2 = scoreDatum.Split(':');
				if (array2.Length > 4)
				{
					CL_ScoreManager.SessionScore.Score score = new CL_ScoreManager.SessionScore.Score();
					score.id = array2[0];
					score.title = array2[1];
					int.TryParse(array2[2], out score.count);
					float.TryParse(array2[3], out score.bonus);
					float.TryParse(array2[4], out score.multiplier);
					score.bonus = (float)Math.Round(score.bonus, 2);
					score.multiplier = (float)Math.Round(score.multiplier, 2);
					score.count = Mathf.Max(score.count, 1);
					text2 = ((score.multiplier == 1f) ? (text2 + $"{score.title} <color=grey>({score.count})</color>: {score.bonus}\n") : (text2 + $"{score.title} <color=grey>({score.count})</color>: {score.multiplier}x\n"));
				}
			}
		}
		scoreText.text = text2;
		foreach (Transform item in perkIconHolder)
		{
			if (item != perkIconHolder)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
		}
		if (data.perks == null || data.perks.Count <= 0)
		{
			return;
		}
		Dictionary<string, Perk> dictionary = new Dictionary<string, Perk>();
		foreach (string perk2 in data.perks)
		{
			Debug.Log(perk2);
			string[] array3 = perk2.Split(':');
			if (array3.Length <= 1)
			{
				continue;
			}
			Perk perk = UnityEngine.Object.Instantiate(CL_AssetManager.GetPerkAsset(array3[0]));
			int.TryParse(array3[1], out perk.stackAmount);
			if (!dictionary.ContainsKey(perk.id))
			{
				dictionary.Add(perk.id, perk);
				if (perk != null)
				{
					UnityEngine.Object.Instantiate(perkIconPrefab, perkIconHolder).SetPerk(perk);
				}
				continue;
			}
			if (dictionary[perk.id].stackAmount < perk.stackAmount)
			{
				dictionary[perk.id].stackAmount = perk.stackAmount;
			}
			if (dictionary[perk.id].stackAmount > perk.stackMax)
			{
				dictionary[perk.id].stackAmount = perk.stackMax;
			}
		}
	}

	internal void ShowNoEntryDetails(LeaderboardEntry scoreInfo)
	{
		user = scoreInfo.user;
		loadRoot.SetActive(value: false);
		infoRoot.SetActive(value: true);
		statText.text = "No Run Data Found.";
		scoreText.text = "No Score Data Found.";
		foreach (Transform item in perkIconHolder)
		{
			if (item != perkIconHolder)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
		}
		nameText.text = $"{user.name} #{scoreInfo.placement}";
		gamemodeText.text = CL_GameManager.GetBaseGamemode().GetGamemodeName();
	}

	public void OpenUserProfileExternally()
	{
		LeaderboardApi leaderboardApi = CL_Leaderboard.leaderboardApi;
		if (leaderboardApi.UserCanOpenPage)
		{
			leaderboardApi.UserOpenPageExternally(user);
		}
		else
		{
			Debug.LogWarning($"Attempted to open user profile for {user.handle} despite this not being supported!");
		}
	}
}
