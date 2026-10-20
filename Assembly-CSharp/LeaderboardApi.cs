using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public interface LeaderboardApi
{
	LeaderboardUser UserCurrent { get; }

	bool UserCanOpenPage { get; }

	Task<Texture2D> UserAvatar(LeaderboardUser user, CancellationToken ct);

	void UserOpenPageExternally(LeaderboardUser user);

	Task<(bool scoreChanged, Task detailsUploadFinished)> PlaceScore(LeaderboardUser user, List<LeaderboardSubmission> submissions, List<(string ident, byte[] data)> details, CancellationToken ct);

	Task<LeaderboardEntry[]> QueryRange(string leaderboardId, int count, int offset = 0, CancellationToken ct = default(CancellationToken));

	Task<LeaderboardEntry[]> QuerySurrounding(string leaderboardId, int from, int to, CancellationToken ct = default(CancellationToken));

	Task<LeaderboardEntry[]> QueryFriends(string leaderboardId, CancellationToken ct = default(CancellationToken));

	Task<byte[]> QueryDetails(string leaderboardId, LeaderboardUser user, string ident, CancellationToken ct);
}
