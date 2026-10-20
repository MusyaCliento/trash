using UnityEngine;

internal static class KYjkEufYsQNmOQcstFccAMaPZuAm
{
	private static int ZwpRilzwtPmaguAIjGOMfhDqEwbRA;

	private static int cWecQbwkKycDAjBimgpwesveNYRp;

	private static double[] ToMRMPHjZtlWkeCFjhUNiGNmQRiw;

	private static int UNwBuQGEzRBHJkGVThuNTpeRfFiFA;

	private static double ZzDfnNIDpSyQgmdBsJoefBKCkKLQ;

	private static int JOZSuNBKsOfECxMusKbDBgPSQJhu;

	public static double WtflBxAzVETPHGBjbBlHkTiPlzbo => ZzDfnNIDpSyQgmdBsJoefBKCkKLQ;

	public static int FpCUblMAWwNMwUzrxZODAyOUUFFG
	{
		get
		{
			return ZwpRilzwtPmaguAIjGOMfhDqEwbRA;
		}
		set
		{
			if (num <= 0)
			{
				num = 1;
			}
			if (num != ZwpRilzwtPmaguAIjGOMfhDqEwbRA)
			{
				ZwpRilzwtPmaguAIjGOMfhDqEwbRA = num;
				BBQsvCRFjUoPXESmcPuuxBGniRlEA();
			}
		}
	}

	static KYjkEufYsQNmOQcstFccAMaPZuAm()
	{
		ZwpRilzwtPmaguAIjGOMfhDqEwbRA = 30;
		BBQsvCRFjUoPXESmcPuuxBGniRlEA();
	}

	public static void yFkxUdHRekQXhSBtwDNqfSOaoEvuA()
	{
		int frameCount = Time.frameCount;
		if (JOZSuNBKsOfECxMusKbDBgPSQJhu < frameCount)
		{
			ToMRMPHjZtlWkeCFjhUNiGNmQRiw[cWecQbwkKycDAjBimgpwesveNYRp] = Time.deltaTime;
			if (UNwBuQGEzRBHJkGVThuNTpeRfFiFA < ZwpRilzwtPmaguAIjGOMfhDqEwbRA)
			{
				UNwBuQGEzRBHJkGVThuNTpeRfFiFA++;
			}
			double num = 0.0;
			for (int i = 0; i < UNwBuQGEzRBHJkGVThuNTpeRfFiFA; i++)
			{
				num += ToMRMPHjZtlWkeCFjhUNiGNmQRiw[i];
			}
			ZzDfnNIDpSyQgmdBsJoefBKCkKLQ = num / (double)UNwBuQGEzRBHJkGVThuNTpeRfFiFA;
			cWecQbwkKycDAjBimgpwesveNYRp++;
			if (cWecQbwkKycDAjBimgpwesveNYRp >= ZwpRilzwtPmaguAIjGOMfhDqEwbRA)
			{
				cWecQbwkKycDAjBimgpwesveNYRp = 0;
			}
			JOZSuNBKsOfECxMusKbDBgPSQJhu = frameCount;
		}
	}

	public static void BBQsvCRFjUoPXESmcPuuxBGniRlEA()
	{
		if (ToMRMPHjZtlWkeCFjhUNiGNmQRiw == null || ToMRMPHjZtlWkeCFjhUNiGNmQRiw.Length != ZwpRilzwtPmaguAIjGOMfhDqEwbRA)
		{
			ToMRMPHjZtlWkeCFjhUNiGNmQRiw = new double[ZwpRilzwtPmaguAIjGOMfhDqEwbRA];
		}
		UNwBuQGEzRBHJkGVThuNTpeRfFiFA = 0;
		cWecQbwkKycDAjBimgpwesveNYRp = 0;
		JOZSuNBKsOfECxMusKbDBgPSQJhu = 0;
	}
}
