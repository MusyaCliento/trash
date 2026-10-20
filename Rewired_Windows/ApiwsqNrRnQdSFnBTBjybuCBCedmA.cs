using System.Diagnostics;
using Rewired;

internal static class ApiwsqNrRnQdSFnBTBjybuCBCedmA
{
	[Conditional("STEAM_DEBUG")]
	public static void yfJlIgCKqaGYYsBKndyrZsUosyzR(object P_0)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
		}
		Logger.Log("[STEAMDEBUG] " + P_0);
	}

	[Conditional("STEAM_DEBUG")]
	public static void pPwdfgrytNHeYcbqLwRHMuOiFmyU(object P_0)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
		}
		Logger.LogWarning("[STEAMDEBUG] " + P_0);
	}

	[Conditional("STEAM_DEBUG")]
	public static void kWwkGSUKwbjqPvynkItXyCRTypaE(object P_0)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
		}
		Logger.LogError("[STEAMDEBUG] " + P_0);
	}
}
