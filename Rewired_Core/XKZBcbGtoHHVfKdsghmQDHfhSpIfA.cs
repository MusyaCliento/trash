using System;
using Rewired.Platforms.Custom;

internal static class XKZBcbGtoHHVfKdsghmQDHfhSpIfA
{
	private static CustomPlatformInitOptions AriDShepoKPOvovdSxQpwZuSigLtA;

	public static int sxzxGgFFdLpgJcYxojKdunKbzLov
	{
		get
		{
			if (AriDShepoKPOvovdSxQpwZuSigLtA == null)
			{
				return -1;
			}
			return AriDShepoKPOvovdSxQpwZuSigLtA.platformId;
		}
	}

	public static bool uiJzvtjjXxeMafDzRvVcrucZLjqaA => sxzxGgFFdLpgJcYxojKdunKbzLov != -1;

	public static void ASHOODGilyBECGFESwuuceCIVuaO(CustomPlatformInitOptions P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("options");
		}
		if (uiJzvtjjXxeMafDzRvVcrucZLjqaA)
		{
			throw new Exception("Already initialized");
		}
		KyrDVwdbJrMSRfhmGEsEKRwlHxxAA(P_0);
		AriDShepoKPOvovdSxQpwZuSigLtA = P_0;
	}

	public static void NtebgqJhSVCMKQSCmajbGTMaajAfB()
	{
		AriDShepoKPOvovdSxQpwZuSigLtA = null;
	}

	internal static int dylKnCZPugHlSZyBBaipqrXncOoy()
	{
		if (AriDShepoKPOvovdSxQpwZuSigLtA == null)
		{
			return -1;
		}
		return AriDShepoKPOvovdSxQpwZuSigLtA.platformId;
	}

	internal static string dFNhGsqxezFQICCacMqUaSkfXRCuB()
	{
		if (AriDShepoKPOvovdSxQpwZuSigLtA == null)
		{
			return null;
		}
		return AriDShepoKPOvovdSxQpwZuSigLtA.platformIdentifierString;
	}

	internal static IHardwareJoystickMapCustomPlatformMapProvider SwAlnjjHJrFDtTkaIMvdIjFIphik()
	{
		if (AriDShepoKPOvovdSxQpwZuSigLtA == null)
		{
			return null;
		}
		return AriDShepoKPOvovdSxQpwZuSigLtA.hardwareJoystickMapCustomPlatformMapProvider;
	}

	internal static CustomInputSource wEhwhzLmBhdhiFuacBYMoDnsnHyhb()
	{
		if (AriDShepoKPOvovdSxQpwZuSigLtA == null)
		{
			return null;
		}
		return AriDShepoKPOvovdSxQpwZuSigLtA.inputSource;
	}

	internal static CustomPlatformConfigVars RjFADaZbihEZlbXiAtlxCsmPdABB()
	{
		if (AriDShepoKPOvovdSxQpwZuSigLtA == null)
		{
			return null;
		}
		return AriDShepoKPOvovdSxQpwZuSigLtA.configVars;
	}

	private static void KyrDVwdbJrMSRfhmGEsEKRwlHxxAA(CustomPlatformInitOptions P_0)
	{
		if (P_0.platformId == -1)
		{
			throw new Exception("customPlatformId is invalid.");
		}
		if (string.IsNullOrEmpty(P_0.platformIdentifierString))
		{
			throw new Exception("platformIdentifierString is invalid.");
		}
		if (P_0.inputSource == null)
		{
			throw new Exception("inputSource cannot be null.");
		}
		if (P_0.hardwareJoystickMapCustomPlatformMapProvider == null)
		{
			throw new Exception("hardwareJoystickMapCustomPlatformMapProvider cannot be null.");
		}
	}
}
