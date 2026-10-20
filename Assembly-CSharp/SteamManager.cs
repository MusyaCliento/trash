using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Steamworks;
using Steamworks.Data;
using Steamworks.Ugc;
using UnityEngine;

public class SteamManager : MonoBehaviour
{
	private class SteamLeaderboardApi : LeaderboardApi
	{
		public LeaderboardUser UserCurrent => new LeaderboardUser
		{
			handle = SteamClient.SteamId.Value,
			name = SteamClient.Name
		};

		public bool UserCanOpenPage => true;

		public async Task<(bool scoreChanged, Task detailsUploadFinished)> PlaceScore(LeaderboardUser user, List<LeaderboardSubmission> submissions, List<(string ident, byte[] data)> details, CancellationToken ct)
		{
			Task<bool>[] array = new Task<bool>[submissions.Count];
			for (int i = 0; i < submissions.Count; i++)
			{
				int temp = i;
				array[i] = Task.Run(async delegate
				{
					LeaderboardSubmission sub = submissions[temp];
					Leaderboard? leaderboard = await SteamUserStats.FindLeaderboardAsync(sub.leaderboardId);
					if (ct.IsCancellationRequested)
					{
						return false;
					}
					if (!leaderboard.HasValue)
					{
						UnityEngine.Debug.LogWarning("Could not find leaderboard " + sub.leaderboardId + "!");
						return false;
					}
					int[] details2 = new int[1] { sub.flags };
					LeaderboardUpdate? leaderboardUpdate = await leaderboard.Value.SubmitScoreAsync(sub.score, details2);
					return !ct.IsCancellationRequested && leaderboardUpdate.HasValue && leaderboardUpdate.Value.Changed;
				});
			}
			bool[] changed = await Task.WhenAll(array);
			if (!changed.Any((bool a) => a))
			{
				return (scoreChanged: false, detailsUploadFinished: Task.CompletedTask);
			}
			return (scoreChanged: true, detailsUploadFinished: SubmitDetails());
			async Task SubmitDetails()
			{
				SteamId me = SteamClient.SteamId;
				foreach (var detail in details)
				{
					string identifier = detail.ident;
					byte[] data = detail.data;
					ResultPage? resultPage = await Query.GameManagedItems.WithTag(identifier).WhereUserPublished(me).GetPageAsync(1);
					Steamworks.Ugc.Item? existingItem = ((resultPage.HasValue && resultPage.Value.ResultCount > 0) ? new Steamworks.Ugc.Item?(resultPage.Value.Entries.First()) : ((Steamworks.Ugc.Item?)null));
					string dataDir = null;
					if (existingItem.HasValue)
					{
						if (await SteamUGC.DownloadAsync(existingItem.Value.Id))
						{
							dataDir = existingItem.Value.Directory;
						}
						else
						{
							UnityEngine.Debug.Log("Failed to re-download workshop item!");
						}
					}
					else
					{
						UnityEngine.Debug.Log("Creating temporary workshop file.");
						dataDir = Path.Combine(Application.temporaryCachePath, "Temp_" + identifier);
						if (Directory.Exists(dataDir))
						{
							Directory.Delete(dataDir, recursive: true);
						}
						Directory.CreateDirectory(dataDir);
					}
					if (dataDir != null)
					{
						for (int j = 0; j < submissions.Count; j++)
						{
							if (changed[j])
							{
								await File.WriteAllBytesAsync(Path.Combine(dataDir, submissions[j].leaderboardId + ".json"), data);
							}
						}
					}
					if (dataDir != null && existingItem.HasValue)
					{
						PublishResult publishResult = await existingItem.Value.Edit().WithContent(dataDir).SubmitAsync();
						if (publishResult.NeedsWorkshopAgreement)
						{
							UnityEngine.Debug.Log("Edited leaderboard workshop item requires approval!");
							SteamFriends.OpenWebOverlay($"steam://url/CommunityFilePage/{publishResult.FileId}");
						}
						if (publishResult.Success)
						{
							UnityEngine.Debug.Log($"Successfully updated leaderboard workshop item! Id: {publishResult.FileId}");
						}
						else
						{
							UnityEngine.Debug.LogError("Failed to update leaderboard workshop item!");
						}
					}
					if (dataDir != null && !existingItem.HasValue)
					{
						string text = "Leaderboard Score " + Guid.NewGuid().ToString();
						UnityEngine.Debug.Log("Submitting new item named " + text + " with tag " + identifier + " folder in directory " + dataDir);
						PublishResult publishResult2 = await Editor.NewGameManagedFile.WithTitle(text).WithTag(identifier).WithContent(dataDir)
							.WithPublicVisibility()
							.SubmitAsync();
						if (publishResult2.NeedsWorkshopAgreement)
						{
							UnityEngine.Debug.Log("Blank leaderboard workshop item requires approval!");
							SteamFriends.OpenWebOverlay($"steam://url/CommunityFilePage/{publishResult2.FileId}");
						}
						if (publishResult2.Success)
						{
							UnityEngine.Debug.Log($"Successfully uploaded blank leaderboard workshop item! Id: {publishResult2.FileId}");
						}
						else
						{
							UnityEngine.Debug.LogError("Failed to upload blank leaderboard workshop item!");
						}
						Directory.Delete(dataDir, recursive: true);
					}
				}
			}
		}

		public async Task<Texture2D> UserAvatar(LeaderboardUser user, CancellationToken ct)
		{
			Image? image = await SteamFriends.GetMediumAvatarAsync(user.handle);
			if (!image.HasValue)
			{
				UnityEngine.Debug.Log($"Could not find avatar for {user.handle}!");
				return null;
			}
			if (ct.IsCancellationRequested)
			{
				return null;
			}
			return ConvertSteamIcon(image.Value);
		}

		public async Task<byte[]> QueryDetails(string leaderboardId, LeaderboardUser user, string ident, CancellationToken ct)
		{
			ulong num = 0uL;
			UnityEngine.Debug.Log($"Found associated workshop item id {num} for {user.handle}");
			ResultPage? resultPage = null;
			if (!ct.IsCancellationRequested)
			{
				Stopwatch stopwatch = Stopwatch.StartNew();
				resultPage = await Query.All.WithTag(ident).WhereUserPublished(user.handle).GetPageAsync(1);
				stopwatch.Stop();
				UnityEngine.Debug.Log($"Page query took: {stopwatch.ElapsedMilliseconds}ms");
			}
			string dir = null;
			if (!ct.IsCancellationRequested && resultPage.HasValue && resultPage.Value.ResultCount > 0)
			{
				Steamworks.Ugc.Item item = resultPage.Value.Entries.First();
				Stopwatch stopwatch = Stopwatch.StartNew();
				bool num2 = await SteamUGC.DownloadAsync(item.Id, null, 60, ct);
				stopwatch.Stop();
				UnityEngine.Debug.Log($"Item download took: {stopwatch.ElapsedMilliseconds}ms");
				if (num2)
				{
					dir = item.Directory;
					UnityEngine.Debug.Log($"Successfully downloaded workshop item leaderboard info for {user.handle}!");
				}
				if (!num2)
				{
					UnityEngine.Debug.Log($"Failed to download workshop item leaderboard info for {user.handle}!");
				}
			}
			else
			{
				UnityEngine.Debug.Log($"No associated workshop item leaderboard info found for {user.handle}!");
			}
			byte[] result = Array.Empty<byte>();
			if (!ct.IsCancellationRequested && dir != null)
			{
				string path = Path.Combine(dir, leaderboardId + ".json");
				if (File.Exists(path))
				{
					result = await File.ReadAllBytesAsync(path, ct);
				}
				else
				{
					UnityEngine.Debug.Log("User has no score details submitted for this leaderboard!");
				}
			}
			return result;
		}

		public async Task<LeaderboardEntry[]> QueryRange(string leaderboardId, int count, int offset = 0, CancellationToken ct = default(CancellationToken))
		{
			Leaderboard? leaderboard = await SteamUserStats.FindLeaderboardAsync(leaderboardId);
			if (!leaderboard.HasValue)
			{
				UnityEngine.Debug.LogError("Could not find leaderboard " + leaderboardId + "!");
				return Array.Empty<LeaderboardEntry>();
			}
			if (ct.IsCancellationRequested)
			{
				return Array.Empty<LeaderboardEntry>();
			}
			return SteamEntriesToGeneric(await leaderboard.Value.GetScoresAsync(count, offset + 1));
		}

		public async Task<LeaderboardEntry[]> QueryFriends(string leaderboardId, CancellationToken ct = default(CancellationToken))
		{
			Leaderboard? leaderboard = await SteamUserStats.FindLeaderboardAsync(leaderboardId);
			if (!leaderboard.HasValue)
			{
				UnityEngine.Debug.LogError("Could not find leaderboard " + leaderboardId + "!");
				return Array.Empty<LeaderboardEntry>();
			}
			if (ct.IsCancellationRequested)
			{
				return Array.Empty<LeaderboardEntry>();
			}
			return SteamEntriesToGeneric(await leaderboard.Value.GetScoresFromFriendsAsync());
		}

		public async Task<LeaderboardEntry[]> QuerySurrounding(string leaderboardId, int from, int to, CancellationToken ct = default(CancellationToken))
		{
			Leaderboard? leaderboard = await SteamUserStats.FindLeaderboardAsync(leaderboardId);
			if (!leaderboard.HasValue)
			{
				UnityEngine.Debug.LogError("Could not find leaderboard " + leaderboardId + "!");
				return Array.Empty<LeaderboardEntry>();
			}
			if (ct.IsCancellationRequested)
			{
				return Array.Empty<LeaderboardEntry>();
			}
			return SteamEntriesToGeneric(await leaderboard.Value.GetScoresAroundUserAsync(from, to));
		}

		private LeaderboardEntry[] SteamEntriesToGeneric(Span<Steamworks.Data.LeaderboardEntry> steamEntries)
		{
			LeaderboardEntry[] array = new LeaderboardEntry[steamEntries.Length];
			for (int i = 0; i < array.Length; i++)
			{
				int flags = 0;
				if (steamEntries[i].Details != null && steamEntries[i].Details.Length != 0)
				{
					flags = steamEntries[i].Details[0];
				}
				array[i].score = steamEntries[i].Score;
				array[i].placement = steamEntries[i].GlobalRank;
				array[i].flags = flags;
				array[i].user = new LeaderboardUser
				{
					handle = steamEntries[i].User.Id.Value,
					name = steamEntries[i].User.Name
				};
			}
			return array;
		}

		public void UserOpenPageExternally(LeaderboardUser user)
		{
			SteamFriends.OpenUserOverlay(user.handle, "steamid");
		}
	}

	public static bool initialized;

	public static SteamManager instance;

	public static bool hasShutdown;

	public static bool connected;

	private List<Task> leaderboardUploadTasks = new List<Task>();

	private HashSet<string> givenAchievements = new HashSet<string>();

	private List<string> queuedAchievements = new List<string>();

	private int lastRichPresenceVersion;

	private void Awake()
	{
		if (instance != null && instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		instance = this;
		initialized = true;
		try
		{
			SteamClient.Init(3195790u);
			connected = true;
		}
		catch (Exception ex)
		{
			connected = false;
			UnityEngine.Debug.Log(ex.Message);
		}
		SteamUGC.OnDownloadItemResult += delegate(Result res)
		{
			UnityEngine.Debug.Log($"Download item result: {res}");
		};
		CL_Leaderboard.leaderboardApi = new SteamLeaderboardApi();
	}

	private void Update()
	{
		SteamClient.RunCallbacks();
		int count = leaderboardUploadTasks.Count;
		while (count-- > 0)
		{
			Task task = leaderboardUploadTasks[count];
			bool flag = false;
			if (task.IsCompleted)
			{
				UnityEngine.Debug.Log("Leaderboard upload succeeded!");
				flag = true;
			}
			if (task.IsCanceled)
			{
				UnityEngine.Debug.Log("Leaderboard upload was cancelled!");
				flag = true;
			}
			if (task.IsFaulted)
			{
				UnityEngine.Debug.Log("Got exception during leaderboard score upload.");
				UnityEngine.Debug.Log("Message: " + task.Exception.Message);
				UnityEngine.Debug.Log("Stack Trace: " + task.Exception.StackTrace);
				flag = true;
			}
			if (flag)
			{
				leaderboardUploadTasks.RemoveAt(count);
			}
		}
		ProcessAchievements();
		UpdateRichPresence();
	}

	private void OnDestroy()
	{
		ProcessAchievements();
		if (instance == this)
		{
			Shutdown();
		}
	}

	private void ProcessAchievements()
	{
		if (!connected || queuedAchievements.Count == 0 || !SteamClient.IsValid || !SteamClient.IsLoggedOn)
		{
			return;
		}
		for (int i = 0; i < queuedAchievements.Count; i++)
		{
			try
			{
				string text = queuedAchievements[i];
				new Achievement(text).Trigger();
			}
			catch (Exception)
			{
				throw;
			}
		}
		queuedAchievements.Clear();
	}

	private void UpdateRichPresence()
	{
		if (!connected)
		{
			return;
		}
		int num = CL_GameManager.RichPresenceVersion();
		if (num != lastRichPresenceVersion)
		{
			lastRichPresenceVersion = num;
			SteamFriends.ClearRichPresence();
			string value = CL_GameManager.RichPresenceStringifyEn(CL_GameManager.RichPresencePeek());
			if (!string.IsNullOrEmpty(value))
			{
				SteamFriends.SetRichPresence("steam_display", "#custom");
				SteamFriends.SetRichPresence("custom_text", value);
			}
			else
			{
				SteamFriends.ClearRichPresence();
			}
		}
	}

	public static void Shutdown()
	{
		if (!hasShutdown)
		{
			hasShutdown = true;
			SteamFriends.ClearRichPresence();
			SteamClient.RunCallbacks();
		}
	}

	public static Texture2D ConvertSteamIcon(Image image)
	{
		Texture2D texture2D = new Texture2D((int)image.Width, (int)image.Height, TextureFormat.ARGB32, mipChain: false);
		texture2D.filterMode = FilterMode.Trilinear;
		for (int i = 0; i < image.Width; i++)
		{
			for (int j = 0; j < image.Height; j++)
			{
				Steamworks.Data.Color pixel = image.GetPixel(i, j);
				texture2D.SetPixel(i, (int)image.Height - j, new UnityEngine.Color((float)(int)pixel.r / 255f, (float)(int)pixel.g / 255f, (float)(int)pixel.b / 255f, (float)(int)pixel.a / 255f));
			}
		}
		texture2D.Apply();
		return texture2D;
	}

	public static async Task<Image?> GetAvatar(SteamId targetID)
	{
		try
		{
			return await SteamFriends.GetLargeAvatarAsync(targetID);
		}
		catch (Exception message)
		{
			UnityEngine.Debug.Log(message);
			return null;
		}
	}

	public static void OpenProfile(SteamId id)
	{
		SteamFriends.OpenUserOverlay(id, "steamid");
	}

	public void UploadGamemodeResults(string steamLeaderboardName, M_Gamemode gamemode, bool hasFinished, float score, float leaderboardTime, CL_Leaderboard.WK_Leaderboard_UserData data)
	{
		Task item = UploadInternal();
		leaderboardUploadTasks.Add(item);
		async Task UploadInternal()
		{
			string text = (gamemode.useGlobalSteamLeaderboardVersion ? "ea-v08-" : "") + CL_GameManager.gamemode.steamLeaderboardName;
			bool flag = gamemode.IsIronKnuckle() && gamemode.scoreLeaderboardIronKnuckle;
			bool flag2 = gamemode.scoreLeaderboardHard && CL_GameManager.IsHardmode();
			int runType = DarkMachineFunctions.PackBools(new bool[4]
			{
				flag,
				flag2,
				CL_GameManager.GetBaseGamemode().IsCompetitive(),
				false
			});
			string text2 = "";
			List<GamemodeSetting> activeSettings = gamemode.GetActiveSettings();
			bool flag3 = true;
			if (activeSettings.Count > 0)
			{
				foreach (GamemodeSetting gamemodeSetting in gamemode.gamemodeSettings)
				{
					for (int i = 0; i < activeSettings.Count; i++)
					{
						if (gamemodeSetting.id == activeSettings[i].id)
						{
							text2 = text2 + "-" + activeSettings[i].leaderboardAppendID;
							if (!activeSettings[i].allowDownstream)
							{
								flag3 = false;
							}
						}
					}
				}
			}
			UnityEngine.Debug.Log("Submitting to leaderboard: " + text + text2);
			string leaderboardSuffixScore = "-score";
			string leaderboardSuffixTime = "-time";
			HashSet<(string name, bool isTime)> submittingToLeaderboards = new HashSet<(string, bool)>();
			if (gamemode.IsCompetitive() || !flag3)
			{
				AddToLeaderboard(text + text2);
			}
			else if (flag3)
			{
				string text3 = "";
				AddToLeaderboard(text + text3);
				if (flag2)
				{
					text3 += "-hard";
					AddToLeaderboard(text + text3);
				}
				if (flag)
				{
					text3 += "-ik";
					AddToLeaderboard(text + "-ik");
					AddToLeaderboard(text + text3);
				}
			}
			string versioningTag = "userData_1";
			string dataDir = null;
			Steamworks.Ugc.Item? existingItem = null;
			ResultPage? resultPage = await Query.GameManagedItems.WithTag(versioningTag).WhereUserPublished(SteamClient.SteamId).GetPageAsync(1);
			bool uploadedToMain = false;
			ulong userData = 0uL;
			HashSet<string> knownUpdatedLeaderboads = new HashSet<string>();
			if (dataDir == null && resultPage.HasValue && resultPage.Value.ResultCount > 0)
			{
				UnityEngine.Debug.Log("Reusing existing workshop item for leaderboard");
				Steamworks.Ugc.Item value = resultPage.Value.Entries.First();
				existingItem = value;
				userData = value.Id;
			}
			if (userData != 0L && !uploadedToMain)
			{
				knownUpdatedLeaderboads = await UploadToLeaderboard();
				uploadedToMain = true;
			}
			if (dataDir == null && existingItem.HasValue)
			{
				bool num = await SteamUGC.DownloadAsync(existingItem.Value.Id);
				if (num)
				{
					dataDir = existingItem.Value.Directory;
				}
				if (!num)
				{
					UnityEngine.Debug.Log("Failed to re-download workshop item!");
				}
			}
			if (dataDir == null)
			{
				UnityEngine.Debug.Log("Creating temporary workshop file.");
				dataDir = Path.Combine(Application.temporaryCachePath, "TempLeaderboardWorkshopDir");
				if (Directory.Exists(dataDir))
				{
					Directory.Delete(dataDir, recursive: true);
				}
				Directory.CreateDirectory(dataDir);
			}
			if (dataDir != null && (gamemode.scoreLeaderboardScore || (gamemode.scoreLeaderboardTime && hasFinished)))
			{
				bool hasToResubmit = false;
				string dataString = null;
				string dir = dataDir;
				SteamId[] user = new SteamId[1] { SteamClient.SteamId };
				foreach (var (leaderboard, isTime) in submittingToLeaderboards)
				{
					UnityEngine.Debug.Log("Re-checking submission for: " + leaderboard);
					string filePath = Path.Combine(dir, leaderboard + ".json");
					bool overwriteThis = false;
					Steamworks.Data.LeaderboardEntry[] entry = null;
					Leaderboard? leaderboard2 = null;
					if (!uploadedToMain)
					{
						leaderboard2 = await SteamUserStats.FindLeaderboardAsync(leaderboard);
					}
					if (leaderboard2.HasValue)
					{
						UnityEngine.Debug.Log("Found leaderboard");
						entry = await leaderboard2.Value.GetScoresForUsersAsync(user);
					}
					float num2 = (isTime ? float.PositiveInfinity : float.NegativeInfinity);
					float num3 = (isTime ? leaderboardTime : score);
					if (entry != null && entry.Length != 0)
					{
						num2 = entry[0].Score;
						UnityEngine.Debug.Log("Existing leaderboard score: " + num2);
					}
					bool flag4 = num3 < num2;
					if (!uploadedToMain && flag4 == isTime)
					{
						UnityEngine.Debug.Log($"New record on leaderboard: {leaderboard} (from {num2} to {num3})");
						overwriteThis = true;
					}
					if (knownUpdatedLeaderboads.Contains(leaderboard))
					{
						UnityEngine.Debug.Log("Leaderboard: " + leaderboard + " is known to have been updated");
						overwriteThis = true;
					}
					if (overwriteThis && dataString == null)
					{
						dataString = JsonConvert.SerializeObject(data);
						UnityEngine.Debug.Log("Deserialized userdata to: " + dataString);
					}
					if (overwriteThis && dataString != null)
					{
						UnityEngine.Debug.Log("Storing userdata to: " + filePath);
						await File.WriteAllTextAsync(filePath, dataString);
					}
					hasToResubmit = hasToResubmit || overwriteThis;
				}
				int retryTotalCount = 1;
				int retryAttempts = 0;
				ulong modifiedItem = 0uL;
				while (modifiedItem == 0 && hasToResubmit && retryAttempts < retryTotalCount)
				{
					UnityEngine.Debug.Log($"Attempting to upload UGC item. Attempt {retryAttempts}/{retryTotalCount}");
					if (!existingItem.HasValue)
					{
						string text4 = "Leaderboard Score " + Guid.NewGuid().ToString();
						UnityEngine.Debug.Log("Submitting new item named " + text4 + " with tag " + versioningTag + " folder in directory " + dir);
						PublishResult publishResult = await Editor.NewGameManagedFile.WithTitle(text4).WithTag(versioningTag).WithContent(dir)
							.WithPublicVisibility()
							.SubmitAsync();
						if (publishResult.NeedsWorkshopAgreement)
						{
							UnityEngine.Debug.Log("Blank leaderboard workshop item requires approval!");
							SteamFriends.OpenWebOverlay($"steam://url/CommunityFilePage/{publishResult.FileId}");
						}
						if (publishResult.Success)
						{
							UnityEngine.Debug.Log($"Successfully uploaded blank leaderboard workshop item! Id: {publishResult.FileId}");
							modifiedItem = publishResult.FileId;
						}
						else
						{
							UnityEngine.Debug.LogError("Failed to upload blank leaderboard workshop item!");
						}
						Directory.Delete(dir, recursive: true);
					}
					if (existingItem.HasValue)
					{
						PublishResult publishResult2 = await existingItem.Value.Edit().WithContent(dir).SubmitAsync();
						if (publishResult2.NeedsWorkshopAgreement)
						{
							UnityEngine.Debug.Log("Edited leaderboard workshop item requires approval!");
							SteamFriends.OpenWebOverlay($"steam://url/CommunityFilePage/{publishResult2.FileId}");
						}
						if (publishResult2.Success)
						{
							UnityEngine.Debug.Log($"Successfully updated leaderboard workshop item! Id: {publishResult2.FileId}");
							modifiedItem = publishResult2.FileId;
						}
						else
						{
							UnityEngine.Debug.LogError("Failed to update leaderboard workshop item!");
						}
					}
					retryAttempts++;
				}
				if (hasToResubmit && modifiedItem == 0L)
				{
					UnityEngine.Debug.Log($"Failed to submit leaderboard details in {retryTotalCount} attempts!");
				}
				if (hasToResubmit && modifiedItem != 0L)
				{
					UnityEngine.Debug.Log($"Successfully submitted leaderboard details in {retryAttempts}/{retryTotalCount} attempts!");
					userData = modifiedItem;
				}
				if (!hasToResubmit)
				{
					UnityEngine.Debug.Log("No leaderboard workshop item update required!");
				}
			}
			if (!uploadedToMain)
			{
				await UploadToLeaderboard();
			}
			void AddToLeaderboard(string name)
			{
				if (gamemode.scoreLeaderboardScore)
				{
					submittingToLeaderboards.Add((name + leaderboardSuffixScore, false));
				}
				if (gamemode.scoreLeaderboardTime && hasFinished)
				{
					submittingToLeaderboards.Add((name + leaderboardSuffixTime, true));
				}
			}
			async Task<HashSet<string>> UploadToLeaderboard()
			{
				(int, int) tuple2 = DarkMachineFunctions.UlongToInts(userData);
				int item2 = tuple2.Item1;
				int item3 = tuple2.Item2;
				int[] runData = new int[5]
				{
					runType,
					(int)score,
					(int)leaderboardTime,
					item2,
					item3
				};
				(string name, bool isTime)[] submittingToLeaderboardsArray = submittingToLeaderboards.ToArray();
				bool[] array = await Task.WhenAll(submittingToLeaderboardsArray.Select(((string name, bool isTime) t) => UploadToFinal(t.name, t.isTime)).ToArray());
				HashSet<string> hashSet = new HashSet<string>();
				for (int num4 = 0; num4 < array.Length; num4++)
				{
					if (array[num4])
					{
						hashSet.Add(submittingToLeaderboardsArray[num4].name);
					}
				}
				if (hashSet.Count > 0)
				{
					Leaderboard_Panel._RefreshLeaderboards?.Invoke();
				}
				return hashSet;
				async Task<bool> UploadToFinal(string text5, bool flag5)
				{
					bool ret = false;
					UnityEngine.Debug.Log("Attempting to save on Leaderboard: " + text5);
					Leaderboard? leaderboard3 = await SteamUserStats.FindLeaderboardAsync(text5);
					if (leaderboard3.HasValue)
					{
						UnityEngine.Debug.Log("Saving on Leaderboard: " + text5);
						float num5 = (flag5 ? leaderboardTime : score);
						LeaderboardUpdate? leaderboardUpdate = await leaderboard3.Value.SubmitScoreAsync((int)num5, runData);
						if (leaderboardUpdate.HasValue)
						{
							ret = leaderboardUpdate.Value.Changed;
						}
					}
					if (ret)
					{
						UnityEngine.Debug.Log("Placement changed on " + text5 + "!");
					}
					return ret;
				}
			}
		}
	}

	public static void GiveSteamAchievement(string id)
	{
		if (!(instance == null) && instance.givenAchievements.Add(id))
		{
			instance.queuedAchievements.Add(id);
		}
	}
}
