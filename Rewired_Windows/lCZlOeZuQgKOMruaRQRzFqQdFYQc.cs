using System;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class lCZlOeZuQgKOMruaRQRzFqQdFYQc : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate IntPtr OiKcDEKKHWHxgIPEXfYkDcqgUUPb(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct dQQBvfmSjMPJuWhcOJUdhxxGFDjo
	{
		public uint SsYDGFelugxAUQWFvKaniGDkQKDeb;

		public IntPtr ihkqgIGtdordfZlKjrqewrGWcQkF;

		public int yPPbfTLlnMZUYKvzPJlmGaPLDidaA;

		public int wXiAFzdrHljAyFyogLmLlBqRQmBj;

		public IntPtr ZmNXCGPNANGTaaHSjBdemimgNZEdb;

		public IntPtr EEYddBuISykNHEgOKxdKKQgQtXuA;

		public IntPtr qhQwIRgaRrdlkzziXKSOWPFlCBfn;

		public IntPtr SQkqHGTCYteTmampsNINRBXGXxrSA;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string YaHFNGGHpFQEEwEfcqWexVsUBBRHb;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string VyzLobxAaObjevfGuNYekHDkqcXR;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct GlAkWvfkCHBdGjZMDyUIrwCtfxdF
	{
		public IntPtr kNGkPoIQIJvOktPMtqHrsNfXHNUN;

		public IntPtr lVKwHUSzfmFGioPRwEVqaPSFvzRsA;

		public IntPtr ITuZFgbkChByghaQkiONwHSisCLAA;

		public IntPtr mSGjmmWijGdUZjktQmSlreuddlMHA;

		public int boaTKMPCmZBvCmDOPFBccVxemRuC;

		public int IdUlNwQEecmDTluBJRZGMCeGFUZeA;

		public int rQWdjCGHmamgoVZFWBzgVkKNADocb;

		public int GiOniwbjcIVBrpZISksjvXKeLMzB;

		public int GfoDtEljgaMhZCbUQagmadCAOOqhA;

		public IntPtr PGKFGIKEbYiSgsWyudiwLbmoAvvC;

		public IntPtr WQtAOmeIgNiQMnaypDyIyOrgqEnVA;

		public uint BFMEfYJsypdkHWwhCiRhfnIgbSCDb;
	}

	private const int zzPdFakrcPDYejTuFeeIcHQvjNVcA = 20;

	private const int hNfWILzfMgxsZqzdLrSojldmZDsB = 1410;

	private readonly ushort KZrawSDDSofzCZuIDVnvsCdNhCtU;

	private readonly string XnSsGmCPTMSqZqHVXDmrIFEacTcY;

	private bool fUoJhPJbmrfgLKKPtxPHTUxKCApX;

	private IntPtr WAucACtSppDMwADmaFaTMqCcvuvNA;

	private int naUqgTEQTUfUEctKKhPSimEHfTGmb;

	private uint fXbcpiqMHkdvjuSPsgqLsjOJZnyn;

	private OiKcDEKKHWHxgIPEXfYkDcqgUUPb wPeBvTALVkhorpKRmmbmqUEjjyjXA;

	private OiKcDEKKHWHxgIPEXfYkDcqgUUPb vugCsMTJkAHFlMxgunaKMpUtoHPH;

	public IntPtr uygGSOvrgquYuHFKJHvZOuXNANcE => WAucACtSppDMwADmaFaTMqCcvuvNA;

	public uint OaLjzYchJIRcfohwWmoySqfauLgnA => fXbcpiqMHkdvjuSPsgqLsjOJZnyn;

	public bool UkoahhrgyYJnNKYSbMLyJLzJNXbv
	{
		get
		{
			if (!(WAucACtSppDMwADmaFaTMqCcvuvNA != IntPtr.Zero))
			{
				return false;
			}
			return DVxZIkfHziKGXdPlggLCgVTxDxGe(WAucACtSppDMwADmaFaTMqCcvuvNA);
		}
	}

	[DllImport("user32.dll", EntryPoint = "RegisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern ushort EoXSJufVctdnCWhgbHZTynFptqcY([In] ref dQQBvfmSjMPJuWhcOJUdhxxGFDjo P_0);

	[DllImport("user32.dll", EntryPoint = "UnregisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool iDuKUxpqCTUoAETCgudnRdvFSmcj([MarshalAs(UnmanagedType.LPWStr)] string P_0, IntPtr P_1);

	[DllImport("user32.dll", EntryPoint = "CreateWindowExW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr IDsZVJWgsUGVFgwZDTGyQyWtRZoq(uint P_0, [MarshalAs(UnmanagedType.LPWStr)] string P_1, [MarshalAs(UnmanagedType.LPWStr)] string P_2, uint P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr AoUTUCUUBdTSFoiKUqDiDmmEzYuQ(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool QfyrObKDYOcoXSZAEVrhFPIwhBcF(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "IsWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool DVxZIkfHziKGXdPlggLCgVTxDxGe(IntPtr P_0);

	public void Dispose()
	{
		sBgdPSwJpDkTyrSEGbovfLhaDCsKA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void LqohCayxamDnBkzqOPVgVybtXbJl()
	{
		try
		{
			sBgdPSwJpDkTyrSEGbovfLhaDCsKA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void sBgdPSwJpDkTyrSEGbovfLhaDCsKA(bool P_0)
	{
		if (!fUoJhPJbmrfgLKKPtxPHTUxKCApX)
		{
			if (P_0)
			{
				ObjectInstanceTracker.Default.Unregister(fXbcpiqMHkdvjuSPsgqLsjOJZnyn);
			}
			if (WAucACtSppDMwADmaFaTMqCcvuvNA != IntPtr.Zero)
			{
				QfyrObKDYOcoXSZAEVrhFPIwhBcF(WAucACtSppDMwADmaFaTMqCcvuvNA);
				WAucACtSppDMwADmaFaTMqCcvuvNA = IntPtr.Zero;
			}
			if (KZrawSDDSofzCZuIDVnvsCdNhCtU != 0 && !string.IsNullOrEmpty(XnSsGmCPTMSqZqHVXDmrIFEacTcY))
			{
				iDuKUxpqCTUoAETCgudnRdvFSmcj(XnSsGmCPTMSqZqHVXDmrIFEacTcY, IntPtr.Zero);
			}
			fUoJhPJbmrfgLKKPtxPHTUxKCApX = true;
		}
	}

	public lCZlOeZuQgKOMruaRQRzFqQdFYQc(string P_0, bool P_1, OiKcDEKKHWHxgIPEXfYkDcqgUUPb P_2)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("className");
		}
		if (P_2 == null)
		{
			throw new ArgumentNullException("staticCustomWndProcDelegate");
		}
		fXbcpiqMHkdvjuSPsgqLsjOJZnyn = ObjectInstanceTracker.Default.Register(this);
		XnSsGmCPTMSqZqHVXDmrIFEacTcY = P_0;
		wPeBvTALVkhorpKRmmbmqUEjjyjXA = TcmihKlsKcgTNBgGRjGGglJhbqdiB;
		vugCsMTJkAHFlMxgunaKMpUtoHPH = P_2;
		naUqgTEQTUfUEctKKhPSimEHfTGmb = 0;
		dQQBvfmSjMPJuWhcOJUdhxxGFDjo dQQBvfmSjMPJuWhcOJUdhxxGFDjo2 = new dQQBvfmSjMPJuWhcOJUdhxxGFDjo
		{
			ihkqgIGtdordfZlKjrqewrGWcQkF = Marshal.GetFunctionPointerForDelegate(wPeBvTALVkhorpKRmmbmqUEjjyjXA)
		};
		while (KZrawSDDSofzCZuIDVnvsCdNhCtU == 0 && naUqgTEQTUfUEctKKhPSimEHfTGmb < 20)
		{
			dQQBvfmSjMPJuWhcOJUdhxxGFDjo2.VyzLobxAaObjevfGuNYekHDkqcXR = P_0;
			KZrawSDDSofzCZuIDVnvsCdNhCtU = EoXSJufVctdnCWhgbHZTynFptqcY(ref dQQBvfmSjMPJuWhcOJUdhxxGFDjo2);
			if (KZrawSDDSofzCZuIDVnvsCdNhCtU != 0)
			{
				break;
			}
			naUqgTEQTUfUEctKKhPSimEHfTGmb++;
			P_0 = XnSsGmCPTMSqZqHVXDmrIFEacTcY + naUqgTEQTUfUEctKKhPSimEHfTGmb;
		}
		if (KZrawSDDSofzCZuIDVnvsCdNhCtU == 0)
		{
			throw new Exception("Could not register window class!");
		}
		if (XnSsGmCPTMSqZqHVXDmrIFEacTcY != P_0)
		{
			XnSsGmCPTMSqZqHVXDmrIFEacTcY = P_0;
		}
		if (P_1)
		{
			WAucACtSppDMwADmaFaTMqCcvuvNA = EWYRQuAukPogjJvhVhftVlPmcIrI(P_0, new IntPtr((int)fXbcpiqMHkdvjuSPsgqLsjOJZnyn));
		}
		else
		{
			WAucACtSppDMwADmaFaTMqCcvuvNA = TDpPTwvSAvjcoYqRQTSDctJRbmtx(P_0, new IntPtr((int)fXbcpiqMHkdvjuSPsgqLsjOJZnyn));
		}
	}

	private IntPtr TDpPTwvSAvjcoYqRQTSDctJRbmtx(string P_0, IntPtr P_1)
	{
		return IDsZVJWgsUGVFgwZDTGyQyWtRZoq(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	private IntPtr EWYRQuAukPogjJvhVhftVlPmcIrI(string P_0, IntPtr P_1)
	{
		return IDsZVJWgsUGVFgwZDTGyQyWtRZoq(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, eWeEhNdWXFKKoUYVUXekPSNqerKDA.iUzbAxPrEcfqurDYMEsrksXHcQwdA, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	[MonoPInvokeCallback(typeof(OiKcDEKKHWHxgIPEXfYkDcqgUUPb))]
	private unsafe static IntPtr TcmihKlsKcgTNBgGRjGGglJhbqdiB(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (P_0 == IntPtr.Zero)
		{
			return AoUTUCUUBdTSFoiKUqDiDmmEzYuQ(P_0, P_1, P_2, P_3);
		}
		bool flag = false;
		uint num = 0u;
		if (P_1 == 1)
		{
			GlAkWvfkCHBdGjZMDyUIrwCtfxdF* ptr = (GlAkWvfkCHBdGjZMDyUIrwCtfxdF*)(void*)P_3;
			if (ptr->kNGkPoIQIJvOktPMtqHrsNfXHNUN != IntPtr.Zero)
			{
				AmOfVgHMXtIpYGmFoUHcniSRkMulA.oTVgYizhKwDewPkzUYjJsPfXHHSl(P_0, -21, ptr->kNGkPoIQIJvOktPMtqHrsNfXHNUN);
			}
		}
		else
		{
			num = (uint)AmOfVgHMXtIpYGmFoUHcniSRkMulA.ncQnzzogZwHDsdFoyYwKEQygqpHK(P_0, -21).ToInt64();
			flag = true;
		}
		if (flag && ObjectInstanceTracker.Default.TryGetInstance<lCZlOeZuQgKOMruaRQRzFqQdFYQc>(num, out var instance))
		{
			instance.vugCsMTJkAHFlMxgunaKMpUtoHPH(P_0, P_1, P_2, P_3);
		}
		return AoUTUCUUBdTSFoiKUqDiDmmEzYuQ(P_0, P_1, P_2, P_3);
	}

	public void KWOcGJdNPkvXpCtzwlypHVVCEwFpA(OiKcDEKKHWHxgIPEXfYkDcqgUUPb P_0)
	{
		vugCsMTJkAHFlMxgunaKMpUtoHPH = P_0;
	}
}
