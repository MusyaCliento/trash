using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class dvxDkRlePMCtCJlqJbdVpkEYIOEX : IDisposable
{
	private class jvdPaRgOVEGUnABAVdLnDGNeqHnIB
	{
		public int SHhOGIBFzVEIcjORFfrXjXquJFStA;

		public int OrPEPOFLcBCfEnJHYgWrbfHIvTozB;

		public uint dnPBJNcPgbJWLZAqreuUhiTaOSuiA;

		public object hvlQYLwblCDKHcilYdbgHwucvWedA;

		public void uVTPUmjaXFYpRkpgXNjgMiSFbmEk(int P_0, int P_1, uint P_2, object P_3)
		{
			SHhOGIBFzVEIcjORFfrXjXquJFStA = P_0;
			OrPEPOFLcBCfEnJHYgWrbfHIvTozB = P_1;
			dnPBJNcPgbJWLZAqreuUhiTaOSuiA = P_2;
			hvlQYLwblCDKHcilYdbgHwucvWedA = P_3;
		}

		public void lOYlNMdiKvxzTAUUKqFbYcRMubrP()
		{
			hvlQYLwblCDKHcilYdbgHwucvWedA = null;
		}
	}

	[Serializable]
	private sealed class WkpaHYHeFjajrPaEUScOHxdYHAWK
	{
		public static readonly WkpaHYHeFjajrPaEUScOHxdYHAWK _003C_003E9 = new WkpaHYHeFjajrPaEUScOHxdYHAWK();

		public static Func<jvdPaRgOVEGUnABAVdLnDGNeqHnIB> _003C_003E9__6_0;

		public static Action<jvdPaRgOVEGUnABAVdLnDGNeqHnIB> _003C_003E9__6_1;

		internal jvdPaRgOVEGUnABAVdLnDGNeqHnIB wUnEPORyNoSkcHbGyhKxVpVefZEy()
		{
			return new jvdPaRgOVEGUnABAVdLnDGNeqHnIB();
		}

		internal void awHxzkpshRqxVfcUmcWjsmdtTJKj(jvdPaRgOVEGUnABAVdLnDGNeqHnIB P_0)
		{
			P_0.lOYlNMdiKvxzTAUUKqFbYcRMubrP();
		}
	}

	private NtFLRVDnENYMXbtywMQbIfXwjuwG gHBnQvnMfgDfgJgZOhnaBAICVcbW;

	private ObjectPool<jvdPaRgOVEGUnABAVdLnDGNeqHnIB> KBhbxkhctlybmusSLbNRvtarjcDIA;

	private Queue<jvdPaRgOVEGUnABAVdLnDGNeqHnIB> zeAdHQuCjmAYkhadBknyoxDXafRhb;

	private Action<object> FkDCsmBOqkqPeqLjgaducAquEIWBA;

	private bool iGsbZOEGaVERIDiCdIFyeNNkcOPnc;

	public bool nmnfDFhbcUsKSJaSLIIiWSGmHqCUA => eRBHCzAXfnljbysIrFhJhmdMmhWvA();

	public dvxDkRlePMCtCJlqJbdVpkEYIOEX(int P_0, int P_1, Action<object> P_2 = null)
	{
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("capacity");
		}
		gHBnQvnMfgDfgJgZOhnaBAICVcbW = new NtFLRVDnENYMXbtywMQbIfXwjuwG(P_0);
		KBhbxkhctlybmusSLbNRvtarjcDIA = new ObjectPool<jvdPaRgOVEGUnABAVdLnDGNeqHnIB>(P_1, WkpaHYHeFjajrPaEUScOHxdYHAWK._003C_003E9.wUnEPORyNoSkcHbGyhKxVpVefZEy, WkpaHYHeFjajrPaEUScOHxdYHAWK._003C_003E9.awHxzkpshRqxVfcUmcWjsmdtTJKj);
		zeAdHQuCjmAYkhadBknyoxDXafRhb = new Queue<jvdPaRgOVEGUnABAVdLnDGNeqHnIB>(P_1);
		FkDCsmBOqkqPeqLjgaducAquEIWBA = P_2;
	}

	public unsafe bool cbmCkJASmLqNPCHONcfUclujgcZoA(byte* P_0, int P_1, object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return false;
		}
		if (gHBnQvnMfgDfgJgZOhnaBAICVcbW.tNIHKTGTupNAxnUWTlzwYiePfUhi(P_0, P_1, P_1, out var num, out var num2) < P_1)
		{
			return false;
		}
		jvdPaRgOVEGUnABAVdLnDGNeqHnIB jvdPaRgOVEGUnABAVdLnDGNeqHnIB2 = KBhbxkhctlybmusSLbNRvtarjcDIA.Get();
		jvdPaRgOVEGUnABAVdLnDGNeqHnIB2.uVTPUmjaXFYpRkpgXNjgMiSFbmEk(num, P_1, num2, P_2);
		zeAdHQuCjmAYkhadBknyoxDXafRhb.Enqueue(jvdPaRgOVEGUnABAVdLnDGNeqHnIB2);
		return true;
	}

	public unsafe bool ZAIDIxImAlqvGjYCTaGXZdGkppTjb(byte* P_0, int P_1)
	{
		return cbmCkJASmLqNPCHONcfUclujgcZoA(P_0, P_1, null);
	}

	public unsafe bool bDeuVZSUYMdjUBuTkQokACkpkFQi(IntPtr P_0, int P_1, object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			return false;
		}
		return cbmCkJASmLqNPCHONcfUclujgcZoA((byte*)(void*)P_0, P_1, P_2);
	}

	public bool eZNngxWbJyjRmZjgrGvlkBLYdQyIA(IntPtr P_0, int P_1)
	{
		return bDeuVZSUYMdjUBuTkQokACkpkFQi(P_0, P_1, null);
	}

	public unsafe bool ajZNOIStIQDIJGIAOHiYKYnFIHhf(byte[] P_0, int P_1, object P_2, int P_3 = 0)
	{
		if (P_0 == null || P_1 > P_0.Length)
		{
			return false;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_3 + P_1 > P_0.Length)
		{
			return false;
		}
		fixed (byte* ptr = P_0)
		{
			byte* ptr2 = ptr + P_3;
			return cbmCkJASmLqNPCHONcfUclujgcZoA(ptr2, P_1, P_2);
		}
	}

	public bool dGABfqLvtBwVzxAemVInMOXwEmhb(byte[] P_0, int P_1, int P_2 = 0)
	{
		return ajZNOIStIQDIJGIAOHiYKYnFIHhf(P_0, P_1, null, P_2);
	}

	public unsafe int ASOCLyiqFEPZpGodLRCaJYnoypRV(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		jvdPaRgOVEGUnABAVdLnDGNeqHnIB jvdPaRgOVEGUnABAVdLnDGNeqHnIB2 = arJGEaKRrewGscnOvbielkLYuwYn(false);
		if (jvdPaRgOVEGUnABAVdLnDGNeqHnIB2 == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < jvdPaRgOVEGUnABAVdLnDGNeqHnIB2.OrPEPOFLcBCfEnJHYgWrbfHIvTozB)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Peek to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			return -1;
		}
		int num = gHBnQvnMfgDfgJgZOhnaBAICVcbW.BcCVEJIcipvuAqtYecbFURMKHTvK(P_0, P_1, jvdPaRgOVEGUnABAVdLnDGNeqHnIB2.OrPEPOFLcBCfEnJHYgWrbfHIvTozB, jvdPaRgOVEGUnABAVdLnDGNeqHnIB2.SHhOGIBFzVEIcjORFfrXjXquJFStA);
		if (num != jvdPaRgOVEGUnABAVdLnDGNeqHnIB2.OrPEPOFLcBCfEnJHYgWrbfHIvTozB)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			num = 0;
			P_2 = null;
			return -1;
		}
		P_2 = jvdPaRgOVEGUnABAVdLnDGNeqHnIB2.hvlQYLwblCDKHcilYdbgHwucvWedA;
		return num;
	}

	public unsafe int WIHNdeMqusRDnNQJFdrwbfuRhXLs(byte* P_0, int P_1)
	{
		object obj;
		return ASOCLyiqFEPZpGodLRCaJYnoypRV(P_0, P_1, out obj);
	}

	public unsafe int OBxQWlixpxJSLuzlbNVSZcPAmKCA(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return ASOCLyiqFEPZpGodLRCaJYnoypRV((byte*)(void*)P_0, P_1, out P_2);
	}

	public int cCwnuoMJTgnMRGfbAnFGBZdkrheA(IntPtr P_0, int P_1)
	{
		object obj;
		return OBxQWlixpxJSLuzlbNVSZcPAmKCA(P_0, P_1, out obj);
	}

	public unsafe int IbFPnxWoeJGKAQLrpcPCUDIOsEtQ(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return ASOCLyiqFEPZpGodLRCaJYnoypRV(ptr, P_0.Length, out P_1);
		}
	}

	public int eNUDjUQGmuaPliXHenDqKZiWRZvMA(byte[] P_0)
	{
		object obj;
		return IbFPnxWoeJGKAQLrpcPCUDIOsEtQ(P_0, out obj);
	}

	public int MhFuxAOmckVPlhpmOfLkiXDSbKaNA()
	{
		return arJGEaKRrewGscnOvbielkLYuwYn(false)?.OrPEPOFLcBCfEnJHYgWrbfHIvTozB ?? (-1);
	}

	public unsafe int WhgSElpIxAYZUEMHlbXsfUXsRPdf(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		jvdPaRgOVEGUnABAVdLnDGNeqHnIB jvdPaRgOVEGUnABAVdLnDGNeqHnIB2 = arJGEaKRrewGscnOvbielkLYuwYn(true);
		if (jvdPaRgOVEGUnABAVdLnDGNeqHnIB2 == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < jvdPaRgOVEGUnABAVdLnDGNeqHnIB2.OrPEPOFLcBCfEnJHYgWrbfHIvTozB)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Dequeue to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			mOXIQljtGlMbBUUSNGNcuFkoSzpA(jvdPaRgOVEGUnABAVdLnDGNeqHnIB2, true);
			return -1;
		}
		int num = gHBnQvnMfgDfgJgZOhnaBAICVcbW.BcCVEJIcipvuAqtYecbFURMKHTvK(P_0, P_1, jvdPaRgOVEGUnABAVdLnDGNeqHnIB2.OrPEPOFLcBCfEnJHYgWrbfHIvTozB, jvdPaRgOVEGUnABAVdLnDGNeqHnIB2.SHhOGIBFzVEIcjORFfrXjXquJFStA);
		if (num != jvdPaRgOVEGUnABAVdLnDGNeqHnIB2.OrPEPOFLcBCfEnJHYgWrbfHIvTozB)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			P_2 = null;
			mOXIQljtGlMbBUUSNGNcuFkoSzpA(jvdPaRgOVEGUnABAVdLnDGNeqHnIB2, true);
			return -1;
		}
		P_2 = jvdPaRgOVEGUnABAVdLnDGNeqHnIB2.hvlQYLwblCDKHcilYdbgHwucvWedA;
		mOXIQljtGlMbBUUSNGNcuFkoSzpA(jvdPaRgOVEGUnABAVdLnDGNeqHnIB2, false);
		return num;
	}

	public unsafe int ojrrxEchCjEcAvgwzoRdtlslJZYv(byte* P_0, int P_1)
	{
		object obj;
		return WhgSElpIxAYZUEMHlbXsfUXsRPdf(P_0, P_1, out obj);
	}

	public unsafe int mcVckLQZAiABiQaTsuTwMhYjhQGk(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return WhgSElpIxAYZUEMHlbXsfUXsRPdf((byte*)(void*)P_0, P_1, out P_2);
	}

	public int ThWBQxrTUlXMYhJaNBzVcZOXViDb(IntPtr P_0, int P_1)
	{
		object obj;
		return mcVckLQZAiABiQaTsuTwMhYjhQGk(P_0, P_1, out obj);
	}

	public unsafe int yzmCIwSopNeKDXeqdqXBtDvYlXUF(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return WhgSElpIxAYZUEMHlbXsfUXsRPdf(ptr, P_0.Length, out P_1);
		}
	}

	public int apORJTKXHNqAPqKHlemMhdpdTyDDA(byte[] P_0)
	{
		object obj;
		return yzmCIwSopNeKDXeqdqXBtDvYlXUF(P_0, out obj);
	}

	public void WStsccmBusWXbhAHJMedKKuDZxse()
	{
		gHBnQvnMfgDfgJgZOhnaBAICVcbW.NKcDSPzpTNiOGojxflTNwSfCPkJU();
		while (zeAdHQuCjmAYkhadBknyoxDXafRhb.Count > 0)
		{
			mOXIQljtGlMbBUUSNGNcuFkoSzpA(zeAdHQuCjmAYkhadBknyoxDXafRhb.Dequeue(), true);
		}
	}

	private jvdPaRgOVEGUnABAVdLnDGNeqHnIB arJGEaKRrewGscnOvbielkLYuwYn(bool P_0)
	{
		while (zeAdHQuCjmAYkhadBknyoxDXafRhb.Count > 0)
		{
			jvdPaRgOVEGUnABAVdLnDGNeqHnIB jvdPaRgOVEGUnABAVdLnDGNeqHnIB2 = (P_0 ? zeAdHQuCjmAYkhadBknyoxDXafRhb.Dequeue() : zeAdHQuCjmAYkhadBknyoxDXafRhb.Peek());
			if (gHBnQvnMfgDfgJgZOhnaBAICVcbW.ahRGJnxcUMQiWOwPfqCtgDbdBAUFA(jvdPaRgOVEGUnABAVdLnDGNeqHnIB2.SHhOGIBFzVEIcjORFfrXjXquJFStA, jvdPaRgOVEGUnABAVdLnDGNeqHnIB2.dnPBJNcPgbJWLZAqreuUhiTaOSuiA))
			{
				return jvdPaRgOVEGUnABAVdLnDGNeqHnIB2;
			}
			if (!P_0)
			{
				jvdPaRgOVEGUnABAVdLnDGNeqHnIB2 = zeAdHQuCjmAYkhadBknyoxDXafRhb.Dequeue();
			}
			mOXIQljtGlMbBUUSNGNcuFkoSzpA(jvdPaRgOVEGUnABAVdLnDGNeqHnIB2, true);
		}
		return null;
	}

	private bool eRBHCzAXfnljbysIrFhJhmdMmhWvA()
	{
		return arJGEaKRrewGscnOvbielkLYuwYn(false) != null;
	}

	private void mOXIQljtGlMbBUUSNGNcuFkoSzpA(jvdPaRgOVEGUnABAVdLnDGNeqHnIB P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1 && FkDCsmBOqkqPeqLjgaducAquEIWBA != null && P_0.hvlQYLwblCDKHcilYdbgHwucvWedA != null)
			{
				FkDCsmBOqkqPeqLjgaducAquEIWBA(P_0.hvlQYLwblCDKHcilYdbgHwucvWedA);
			}
			KBhbxkhctlybmusSLbNRvtarjcDIA.Return(P_0);
		}
	}

	public void Dispose()
	{
		TrUBBOMOEAyYktWbBrFYdqOVYKkp(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void csJbMohblUonxxXmehnnlGNGPTwyA()
	{
		try
		{
			TrUBBOMOEAyYktWbBrFYdqOVYKkp(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void TrUBBOMOEAyYktWbBrFYdqOVYKkp(bool P_0)
	{
		if (iGsbZOEGaVERIDiCdIFyeNNkcOPnc)
		{
			return;
		}
		if (P_0)
		{
			WStsccmBusWXbhAHJMedKKuDZxse();
			if (gHBnQvnMfgDfgJgZOhnaBAICVcbW != null)
			{
				gHBnQvnMfgDfgJgZOhnaBAICVcbW.Dispose();
			}
		}
		iGsbZOEGaVERIDiCdIFyeNNkcOPnc = true;
	}

	public static bool QRlTdcgkkdjxNcZoWoZUPJbtrFeWA(dvxDkRlePMCtCJlqJbdVpkEYIOEX P_0, dvxDkRlePMCtCJlqJbdVpkEYIOEX P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		MiscTools.Swap(ref P_0.gHBnQvnMfgDfgJgZOhnaBAICVcbW, ref P_1.gHBnQvnMfgDfgJgZOhnaBAICVcbW);
		MiscTools.Swap(ref P_0.KBhbxkhctlybmusSLbNRvtarjcDIA, ref P_1.KBhbxkhctlybmusSLbNRvtarjcDIA);
		MiscTools.Swap(ref P_0.zeAdHQuCjmAYkhadBknyoxDXafRhb, ref P_1.zeAdHQuCjmAYkhadBknyoxDXafRhb);
		return true;
	}
}
