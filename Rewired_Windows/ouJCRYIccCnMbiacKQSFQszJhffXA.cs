using System;

internal static class ouJCRYIccCnMbiacKQSFQszJhffXA
{
	public const float XyozIuNnDYHbgzPopAdgGRLUfZzm = 1E-06f;

	public const float lRFxLINDltNKfzWDRpcdgPrIYlUg = MathF.PI;

	public const float QhtARWoFykGwFfXFyzSLGvtXGhXu = MathF.PI * 2f;

	public const float yfkOwZTwzbKvknnTLhvLnZTRCUqF = MathF.PI / 2f;

	public const float nwNmEuAKBWTKnnciqrARlUscjFB = MathF.PI / 4f;

	public unsafe static bool kGhGZCfRPoeZOUTDrSlAIYbbbTxsB(float P_0, float P_1)
	{
		if (bGzvKloDlABPmAOojrQQWohMsSvp(P_0 - P_1))
		{
			return true;
		}
		int num = *(int*)(&P_0);
		int num2 = *(int*)(&P_1);
		if (num < 0 != num2 < 0)
		{
			return false;
		}
		return Math.Abs(num - num2) <= 4;
	}

	public static bool bGzvKloDlABPmAOojrQQWohMsSvp(float P_0)
	{
		return Math.Abs(P_0) < 1E-06f;
	}

	public static bool PGURyPPwOiBMXlGmQyUwoKuKlXpK(float P_0)
	{
		return bGzvKloDlABPmAOojrQQWohMsSvp(P_0 - 1f);
	}

	public static bool bLGXEdmndVGjIoNDmTCWyWtyxhHI(float P_0, float P_1, float P_2)
	{
		float num = P_0 - P_1;
		if (0f - P_2 <= num)
		{
			return num <= P_2;
		}
		return false;
	}

	public static float EzfkngYlbpsgvEAkBadbJvWhREpp(float P_0)
	{
		return P_0 * 360f;
	}

	public static float THoeNuPXTWfjJJLqjgPmhigSnVPY(float P_0)
	{
		return P_0 * (MathF.PI * 2f);
	}

	public static float pEMdIsdtiVfyPzukkjOHwLzMlbISA(float P_0)
	{
		return P_0 * 400f;
	}

	public static float vcRCdhOxhDaLYPxUhdLnaWWoxCcxA(float P_0)
	{
		return P_0 / 360f;
	}

	public static float enQVHFMmFcBFYCNHTHJUSTkROvEdA(float P_0)
	{
		return P_0 * (MathF.PI / 180f);
	}

	public static float rXjQhYqBaGKSReOFiXHmZZibgtV(float P_0)
	{
		return P_0 / (MathF.PI * 2f);
	}

	public static float PFNdEGVGVTIApPdVRbuCuzrukEWm(float P_0)
	{
		return P_0 * (200f / MathF.PI);
	}

	public static float bozkmFWQEMcwjteaXmRLglAtEbhe(float P_0)
	{
		return P_0 / 400f;
	}

	public static float oxPKSLAezoVQRmyySoGNdLBHxuht(float P_0)
	{
		return P_0 * 0.9f;
	}

	public static float rTMKMRCkNDACmInhYxaNEjRdOpdX(float P_0)
	{
		return P_0 * (MathF.PI / 200f);
	}

	public static float sQDmmIJMgzetjAGHntkaeAZPDRIM(float P_0)
	{
		return P_0 * (180f / MathF.PI);
	}

	public static float fMRVmQTcjobFlhznXBKpBuNlvtri(float P_0, float P_1, float P_2)
	{
		if (!(P_0 < P_1))
		{
			if (!(P_0 > P_2))
			{
				return P_0;
			}
			return P_2;
		}
		return P_1;
	}

	public static int fQoLBQIOlEDcmzNMStQmqXtikwML(int P_0, int P_1, int P_2)
	{
		if (P_0 >= P_1)
		{
			if (P_0 <= P_2)
			{
				return P_0;
			}
			return P_2;
		}
		return P_1;
	}

	public static double TdkaPbzgVEDUoBgHEOrMGrwBsRxJB(double P_0, double P_1, double P_2)
	{
		return (1.0 - P_2) * P_0 + P_2 * P_1;
	}

	public static float JyACZAAShLnZwBIoNKsAdPJKpcfNc(float P_0, float P_1, float P_2)
	{
		return (1f - P_2) * P_0 + P_2 * P_1;
	}

	public static byte ebsEdHCeQyshClfSCebkBriUnCVcA(byte P_0, byte P_1, float P_2)
	{
		return (byte)JyACZAAShLnZwBIoNKsAdPJKpcfNc((int)P_0, (int)P_1, P_2);
	}

	public static float zpSAILIFhfZCNEqOTKbyRxXcGnKV(float P_0)
	{
		if (!(P_0 <= 0f))
		{
			if (!(P_0 >= 1f))
			{
				return P_0 * P_0 * (3f - 2f * P_0);
			}
			return 1f;
		}
		return 0f;
	}

	public static float rnGSUwqoSEaBoIcTaaQlZkfdqrdMA(float P_0)
	{
		if (!(P_0 <= 0f))
		{
			if (!(P_0 >= 1f))
			{
				return P_0 * P_0 * P_0 * (P_0 * (P_0 * 6f - 15f) + 10f);
			}
			return 1f;
		}
		return 0f;
	}

	public static float fVJRkHJyhtlOTlSvgcTSWhACEdYA(float P_0, float P_1)
	{
		if (P_1 == 0f)
		{
			return P_0;
		}
		return P_0 % P_1;
	}

	public static float ZRsXGhyJZpEcWEFtbToiLaKdYYSAA(float P_0)
	{
		return fVJRkHJyhtlOTlSvgcTSWhACEdYA(P_0, MathF.PI * 2f);
	}

	public static int suMnYvnanYCocIeesEJPocZbedKjA(int P_0, int P_1, int P_2)
	{
		if (P_1 > P_2)
		{
			throw new ArgumentException($"min {P_1} should be less than or equal to max {P_2}", "min");
		}
		int num = P_2 - P_1 + 1;
		if (P_0 < P_1)
		{
			P_0 += num * ((P_1 - P_0) / num + 1);
		}
		return P_1 + (P_0 - P_1) % num;
	}

	public static float pCODghmQrXFsjGCgUbFLrJFgPLRj(float P_0, float P_1, float P_2)
	{
		if (kGhGZCfRPoeZOUTDrSlAIYbbbTxsB(P_1, P_2))
		{
			return P_1;
		}
		double num = P_1;
		double num2 = P_2;
		double num3 = P_0;
		if (num > num2)
		{
			throw new ArgumentException($"min {P_1} should be less than or equal to max {P_2}", "min");
		}
		double num4 = num2 - num;
		return (float)(num + (num3 - num) - num4 * Math.Floor((num3 - num) / num4));
	}

	public static float DebJEILtjXvNBtyoPrjVcjeVnzDQ(float P_0, float P_1, float P_2, float P_3, float P_4, float P_5, float P_6)
	{
		return (float)VRyCDySKRrqySPdiPYVeTStbfBTX(P_0, P_1, P_2, P_3, P_4, P_5, P_6);
	}

	public static double VRyCDySKRrqySPdiPYVeTStbfBTX(double P_0, double P_1, double P_2, double P_3, double P_4, double P_5, double P_6)
	{
		return P_0 * Math.E - (Math.Pow(P_1 - P_3 / 2.0, 2.0) / (2.0 * Math.Pow(P_5, 2.0)) + Math.Pow(P_2 - P_4 / 2.0, 2.0) / (2.0 * Math.Pow(P_6, 2.0)));
	}
}
