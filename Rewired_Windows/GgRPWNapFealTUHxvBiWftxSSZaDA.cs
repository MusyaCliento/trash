using System;
using System.Runtime.InteropServices;

internal class GgRPWNapFealTUHxvBiWftxSSZaDA : IDisposable
{
	internal enum oLykKeSCtDipzfgyPwaypeTLQYor
	{
		Current = 0,
		All = 1
	}

	private delegate IntPtr pKEDbSqbQnpinGvOOkyFRfMMhZpEA(int nCode, IntPtr wParam, IntPtr lParam);

	private const int ZVkTvPDcktyBvLJvXxxwOuTjubXx = 4;

	private IntPtr qrYaxkcztIkcGpYDGueKqIzgRYty = IntPtr.Zero;

	private pKEDbSqbQnpinGvOOkyFRfMMhZpEA PZjvIyalkZbpVvMlBjEodGSoylKw;

	private Action<IntPtr, IntPtr, uint, uint> tcbxlePlExpmYKgxMQFiWDsIsKyT;

	private bool tbCpMEbsGwmMRSHHwoFUzYdyrQlA;

	public void nJbZdkNDKSqTklwUhXaIxDFrjDiy(Action<IntPtr, IntPtr, uint, uint> P_0, oLykKeSCtDipzfgyPwaypeTLQYor P_1)
	{
		tcbxlePlExpmYKgxMQFiWDsIsKyT = P_0;
		PZjvIyalkZbpVvMlBjEodGSoylKw = KyIFZQawteNNQVshrgJoXcWnToVWA;
		uint num = 0u;
		if (P_1 == oLykKeSCtDipzfgyPwaypeTLQYor.Current)
		{
			num = isCygitBHPQRrMjESfQLjRwkTPGNA.OEpoDHmliVzAyFXQhxqQXGcoerAB();
		}
		qrYaxkcztIkcGpYDGueKqIzgRYty = jwKsjRjXZmreKzrlWBaiSqiniHZHA(4, PZjvIyalkZbpVvMlBjEodGSoylKw, IntPtr.Zero, num);
		_ = qrYaxkcztIkcGpYDGueKqIzgRYty == IntPtr.Zero;
	}

	public void lQPDAbiRYapqhISFiBIpnTvaBGctA()
	{
		if (!(qrYaxkcztIkcGpYDGueKqIzgRYty == IntPtr.Zero) && WbETkdOkDLlxftVlfcUmeFvndajm(qrYaxkcztIkcGpYDGueKqIzgRYty))
		{
			qrYaxkcztIkcGpYDGueKqIzgRYty = IntPtr.Zero;
		}
	}

	private IntPtr KyIFZQawteNNQVshrgJoXcWnToVWA(int P_0, IntPtr P_1, IntPtr P_2)
	{
		if (P_0 >= 0)
		{
			int num = 0;
			IntPtr arg = Marshal.ReadIntPtr(P_2, num);
			num += IntPtr.Size;
			IntPtr arg2 = Marshal.ReadIntPtr(P_2, num);
			num += IntPtr.Size;
			uint arg3 = (uint)Marshal.ReadInt32(P_2, num);
			num += 4;
			if (IntPtr.Size == 8)
			{
				num += 4;
			}
			uint arg4 = (uint)Marshal.ReadInt32(P_2, num);
			tcbxlePlExpmYKgxMQFiWDsIsKyT(arg, arg2, arg3, arg4);
		}
		return MscFqRMlvFXEXDppMWAWKgTSweKE(qrYaxkcztIkcGpYDGueKqIzgRYty, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		eiIIQvKWBnCbUNPUoJpRekkjcPBfA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void PMswRukoiqaauHyNtnKiNcOWaHRfA()
	{
		try
		{
			eiIIQvKWBnCbUNPUoJpRekkjcPBfA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void eiIIQvKWBnCbUNPUoJpRekkjcPBfA(bool P_0)
	{
		if (!tbCpMEbsGwmMRSHHwoFUzYdyrQlA)
		{
			lQPDAbiRYapqhISFiBIpnTvaBGctA();
			tbCpMEbsGwmMRSHHwoFUzYdyrQlA = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr jwKsjRjXZmreKzrlWBaiSqiniHZHA(int P_0, pKEDbSqbQnpinGvOOkyFRfMMhZpEA P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool WbETkdOkDLlxftVlfcUmeFvndajm(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr MscFqRMlvFXEXDppMWAWKgTSweKE(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
