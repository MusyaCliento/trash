using System;
using System.Collections.Generic;
using System.Reflection;
using Rewired;
using Rewired.Data;
using Rewired.Utils;

internal static class WONgWgQUCwUJmKvTejTnbODTMdJK
{
	private const string vQadvpPIfKDwJQErSEQzjhtdkjLz = "Rewired.InputManagers.Initializer";

	private static List<Assembly> WvylBwCCnJIXSMfaqypuPgmxvRcB;

	public static object DmEbKMkljisZGCmuTbBruRqBtICC(string P_0, List<Assembly> P_1, ConfigVars P_2)
	{
		WvylBwCCnJIXSMfaqypuPgmxvRcB = P_1;
		int num = P_1?.Count ?? 0;
		if (num == 0)
		{
			if (!(UnityTools.externalTools.GetPlatformInitializer() is PlatformInitializer platformInitializer))
			{
				return null;
			}
			return platformInitializer.Initialize(P_2);
		}
		for (int i = 0; i < num; i++)
		{
			Assembly assembly = P_1[i];
			if (!(assembly == null) && assembly.FullName.StartsWith(P_0, StringComparison.OrdinalIgnoreCase))
			{
				Type type = assembly.GetType("Rewired.InputManagers.Initializer");
				if (!(type == null))
				{
					return UGgsGMNiAHFIHUWdtnaVXqjrLMyC(type)?.Initialize(P_2);
				}
			}
		}
		return null;
	}

	public static object FDTKfimtkoQZzcaIMSzkhmvPtWqK(string P_0, string P_1)
	{
		List<Assembly> wvylBwCCnJIXSMfaqypuPgmxvRcB = WvylBwCCnJIXSMfaqypuPgmxvRcB;
		int num = wvylBwCCnJIXSMfaqypuPgmxvRcB?.Count ?? 0;
		if (num == 0)
		{
			if (!(UnityTools.externalTools.GetPlatformInitializer() is PlatformInitializer platformInitializer))
			{
				return null;
			}
			return platformInitializer.CreateTool(P_1);
		}
		for (int i = 0; i < num; i++)
		{
			Assembly assembly = wvylBwCCnJIXSMfaqypuPgmxvRcB[i];
			if (!(assembly == null) && assembly.FullName.StartsWith(P_0, StringComparison.OrdinalIgnoreCase))
			{
				Type type = assembly.GetType("Rewired.InputManagers.Initializer");
				if (!(type == null))
				{
					return UGgsGMNiAHFIHUWdtnaVXqjrLMyC(type)?.CreateTool(P_1);
				}
			}
		}
		return null;
	}

	public static PlatformInitializer UGgsGMNiAHFIHUWdtnaVXqjrLMyC(Type P_0)
	{
		try
		{
			return P_0.InvokeMember("GetPlatformInitializer", BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod, null, null, null) as PlatformInitializer;
		}
		catch
		{
			return null;
		}
	}
}
