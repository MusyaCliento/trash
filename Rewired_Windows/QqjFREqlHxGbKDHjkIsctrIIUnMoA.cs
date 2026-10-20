using System;
using System.Runtime.CompilerServices;

internal struct QqjFREqlHxGbKDHjkIsctrIIUnMoA
{
	private uint InTVIIAFXUJHzIcXlJbCOWRTcWJq;

	private ulong uRsBGDhGKUPKFikijDYAfUReRBYeA;

	private static readonly bool xVBtbqYkHIneopDhrEGABUXvCVwl;

	public static readonly int DKAOzYYiGYSYJbPwNcTphpyLSawX;

	static QqjFREqlHxGbKDHjkIsctrIIUnMoA()
	{
		xVBtbqYkHIneopDhrEGABUXvCVwl = IntPtr.Size == 8;
		DKAOzYYiGYSYJbPwNcTphpyLSawX = (xVBtbqYkHIneopDhrEGABUXvCVwl ? 8 : 4);
	}

	public static QqjFREqlHxGbKDHjkIsctrIIUnMoA zEGnInKkMVNwoFBGJiktJyIGMQOWA(byte[] P_0, int P_1)
	{
		QqjFREqlHxGbKDHjkIsctrIIUnMoA result = default(QqjFREqlHxGbKDHjkIsctrIIUnMoA);
		if (xVBtbqYkHIneopDhrEGABUXvCVwl)
		{
			result.uRsBGDhGKUPKFikijDYAfUReRBYeA = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.InTVIIAFXUJHzIcXlJbCOWRTcWJq = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static uint VKPoPgrGjjarsdPDYMuABRSfECyFb(QqjFREqlHxGbKDHjkIsctrIIUnMoA P_0)
	{
		if (xVBtbqYkHIneopDhrEGABUXvCVwl)
		{
			return (uint)P_0.uRsBGDhGKUPKFikijDYAfUReRBYeA;
		}
		return P_0.InTVIIAFXUJHzIcXlJbCOWRTcWJq;
	}

	[SpecialName]
	public static ulong VKPoPgrGjjarsdPDYMuABRSfECyFb(QqjFREqlHxGbKDHjkIsctrIIUnMoA P_0)
	{
		if (xVBtbqYkHIneopDhrEGABUXvCVwl)
		{
			return P_0.uRsBGDhGKUPKFikijDYAfUReRBYeA;
		}
		return P_0.InTVIIAFXUJHzIcXlJbCOWRTcWJq;
	}

	public string uJXtCANPiKgOYKzXioMGEEaToFPE()
	{
		if (xVBtbqYkHIneopDhrEGABUXvCVwl)
		{
			return uRsBGDhGKUPKFikijDYAfUReRBYeA.ToString();
		}
		return InTVIIAFXUJHzIcXlJbCOWRTcWJq.ToString();
	}
}
