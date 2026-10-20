using System;
using System.Runtime.CompilerServices;

internal struct WwduCBiKJyCZpdQUUEBBostnTeBx
{
	private int wVdRudOgZtECqEqYOToPFaaUlhoxA;

	private long xqzRiBRScZmuiVjSmRtVxpdKylJH;

	private static readonly bool UwjbdlpaKQpucXQTrFZsoRDNfeuhA;

	public static readonly int zSPXcVPTIfvIzltzDnIiYwvhBCbE;

	static WwduCBiKJyCZpdQUUEBBostnTeBx()
	{
		UwjbdlpaKQpucXQTrFZsoRDNfeuhA = IntPtr.Size == 8;
		zSPXcVPTIfvIzltzDnIiYwvhBCbE = (UwjbdlpaKQpucXQTrFZsoRDNfeuhA ? 8 : 4);
	}

	public static WwduCBiKJyCZpdQUUEBBostnTeBx dzydsCLRBxfhqJxGFKkIfcJTknRWA(byte[] P_0, int P_1)
	{
		WwduCBiKJyCZpdQUUEBBostnTeBx result = default(WwduCBiKJyCZpdQUUEBBostnTeBx);
		if (UwjbdlpaKQpucXQTrFZsoRDNfeuhA)
		{
			result.xqzRiBRScZmuiVjSmRtVxpdKylJH = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.wVdRudOgZtECqEqYOToPFaaUlhoxA = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static int aZvaHJPTXsbcQkAjPQPaskpTjGqr(WwduCBiKJyCZpdQUUEBBostnTeBx P_0)
	{
		if (UwjbdlpaKQpucXQTrFZsoRDNfeuhA)
		{
			return (int)P_0.xqzRiBRScZmuiVjSmRtVxpdKylJH;
		}
		return P_0.wVdRudOgZtECqEqYOToPFaaUlhoxA;
	}

	[SpecialName]
	public static long aZvaHJPTXsbcQkAjPQPaskpTjGqr(WwduCBiKJyCZpdQUUEBBostnTeBx P_0)
	{
		if (UwjbdlpaKQpucXQTrFZsoRDNfeuhA)
		{
			return P_0.xqzRiBRScZmuiVjSmRtVxpdKylJH;
		}
		return P_0.wVdRudOgZtECqEqYOToPFaaUlhoxA;
	}

	public string jIKWjylrzgnIvzlSSYaUOsfkVmUH()
	{
		if (UwjbdlpaKQpucXQTrFZsoRDNfeuhA)
		{
			return xqzRiBRScZmuiVjSmRtVxpdKylJH.ToString();
		}
		return wVdRudOgZtECqEqYOToPFaaUlhoxA.ToString();
	}
}
