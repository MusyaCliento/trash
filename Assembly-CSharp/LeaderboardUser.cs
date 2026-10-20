public struct LeaderboardUser
{
	public ulong handle;

	public string name;

	public readonly LeaderboardUser invalid => default(LeaderboardUser);

	public static bool operator ==(LeaderboardUser lhs, LeaderboardUser rhs)
	{
		return lhs.handle == rhs.handle;
	}

	public static bool operator !=(LeaderboardUser lhs, LeaderboardUser rhs)
	{
		return !(lhs == rhs);
	}
}
