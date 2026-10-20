using System;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Utils.Attributes;

internal class WJZtReuwXVvgbNQlSAhqiFNIylXi : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr pYbEiSkHBNHyHVQOURXzSZwPnkGA(int nCode, IntPtr wParam, IntPtr lParam);

	private struct iofjYQDiERKDvMKsbjJpKrnfEYYg
	{
		public IntPtr xvzavcsRcDszRIyMWubCdWrWcvCx;

		public IntPtr DvcLaSwLRKgEXzwcujsBUDGyZUTw;

		public uint bQbwKoDsNMSeWIqNkagAMrGiIhAd;

		public IntPtr PzCqPEhvgZIyfyePbLBPStPQClnW;
	}

	private const int gbkaIorQjmNpdKOfnvFGzJMZgddY = 4;

	private static WJZtReuwXVvgbNQlSAhqiFNIylXi GadKLGtEVdoFXBPOgDlNeswhvuxMA;

	private IntPtr UZwuBwuNMuwlUCNHFPbRIJhzTOAs = IntPtr.Zero;

	private pYbEiSkHBNHyHVQOURXzSZwPnkGA fgvGAFJNPrzccpGiEMItMNgobDubb;

	private Action<YxnauwvwzpbEuGCCcOwabzsfvwdbc, LzzDrSGBjXWyBBXOFCXFTEexBDId, uint, IntPtr> QuQVknkExNSQldIUOusdkaiaVSGw;

	private byte[] SpFdTfTtVlHEVCHwCKgLXqoPfAye;

	private readonly bool GFjrxaxmanmXysHAFBfZWOFYcrUh;

	private iofjYQDiERKDvMKsbjJpKrnfEYYg FTeczUWndOSbBLJjvAAMfDkGRxNt;

	private bool WQQpCsHeLomWcEQCMHPPevitfUoy;

	public WJZtReuwXVvgbNQlSAhqiFNIylXi()
	{
		if (GadKLGtEVdoFXBPOgDlNeswhvuxMA != null)
		{
			throw new Exception("Singleton instance already exists!");
		}
		GadKLGtEVdoFXBPOgDlNeswhvuxMA = this;
		GFjrxaxmanmXysHAFBfZWOFYcrUh = IntPtr.Size == 8;
		SpFdTfTtVlHEVCHwCKgLXqoPfAye = new byte[IntPtr.Size * 3 + 4];
	}

	public void DSqTpZuttvBIHocwkeYnVAqdXwWR(Action<YxnauwvwzpbEuGCCcOwabzsfvwdbc, LzzDrSGBjXWyBBXOFCXFTEexBDId, uint, IntPtr> P_0, bool P_1)
	{
		QuQVknkExNSQldIUOusdkaiaVSGw = P_0;
		fgvGAFJNPrzccpGiEMItMNgobDubb = iCsRWLKcCsrENpdPKGfJgVkqdtzJ;
		uint num = 0u;
		if (P_1)
		{
			num = isCygitBHPQRrMjESfQLjRwkTPGNA.OEpoDHmliVzAyFXQhxqQXGcoerAB();
		}
		UZwuBwuNMuwlUCNHFPbRIJhzTOAs = whlGjlDkRgSZPqkubgqnCPhKwbGLb(4, fgvGAFJNPrzccpGiEMItMNgobDubb, IntPtr.Zero, num);
		if (UZwuBwuNMuwlUCNHFPbRIJhzTOAs == IntPtr.Zero)
		{
			Logger.LogError("SetWindowsHookEx Failed");
		}
	}

	public void dPjRWdPOJgOXWqJcigbdyGWJiTOx()
	{
		if (!(UZwuBwuNMuwlUCNHFPbRIJhzTOAs == IntPtr.Zero))
		{
			if (!rHKyoVhLlAVuQZXVEmqkGqlaWsnI(UZwuBwuNMuwlUCNHFPbRIJhzTOAs))
			{
				Logger.LogError("UnhookWindowsHookEx Failed");
			}
			else
			{
				UZwuBwuNMuwlUCNHFPbRIJhzTOAs = IntPtr.Zero;
			}
		}
	}

	[MonoPInvokeCallback(typeof(pYbEiSkHBNHyHVQOURXzSZwPnkGA))]
	private static IntPtr iCsRWLKcCsrENpdPKGfJgVkqdtzJ(int P_0, IntPtr P_1, IntPtr P_2)
	{
		Marshal.Copy(P_2, GadKLGtEVdoFXBPOgDlNeswhvuxMA.SpFdTfTtVlHEVCHwCKgLXqoPfAye, 0, GadKLGtEVdoFXBPOgDlNeswhvuxMA.SpFdTfTtVlHEVCHwCKgLXqoPfAye.Length);
		int num = 0;
		GadKLGtEVdoFXBPOgDlNeswhvuxMA.FTeczUWndOSbBLJjvAAMfDkGRxNt.xvzavcsRcDszRIyMWubCdWrWcvCx = YxnauwvwzpbEuGCCcOwabzsfvwdbc.maVGGvYhadoOfJHgNbWYYTSZqtaH(YxnauwvwzpbEuGCCcOwabzsfvwdbc.fzXfIdHKOhKUYNFIWOUYxZWjjDFfA(GadKLGtEVdoFXBPOgDlNeswhvuxMA.SpFdTfTtVlHEVCHwCKgLXqoPfAye, num));
		num += YxnauwvwzpbEuGCCcOwabzsfvwdbc.SxGDBKfTUNFFvAzyyLAbsFETlQQf;
		GadKLGtEVdoFXBPOgDlNeswhvuxMA.FTeczUWndOSbBLJjvAAMfDkGRxNt.DvcLaSwLRKgEXzwcujsBUDGyZUTw = LzzDrSGBjXWyBBXOFCXFTEexBDId.zGbaiRbaONCcfBNvNWDQOPblzDjtA(LzzDrSGBjXWyBBXOFCXFTEexBDId.OnuEmrZpDlQHzYcABjMHbpTxJftL(GadKLGtEVdoFXBPOgDlNeswhvuxMA.SpFdTfTtVlHEVCHwCKgLXqoPfAye, num));
		num += LzzDrSGBjXWyBBXOFCXFTEexBDId.dfQGoKEbpKEBbdhifzRrGuLOVHjhc;
		GadKLGtEVdoFXBPOgDlNeswhvuxMA.FTeczUWndOSbBLJjvAAMfDkGRxNt.bQbwKoDsNMSeWIqNkagAMrGiIhAd = BitConverter.ToUInt32(GadKLGtEVdoFXBPOgDlNeswhvuxMA.SpFdTfTtVlHEVCHwCKgLXqoPfAye, num);
		num += 4;
		if (GadKLGtEVdoFXBPOgDlNeswhvuxMA.GFjrxaxmanmXysHAFBfZWOFYcrUh)
		{
			GadKLGtEVdoFXBPOgDlNeswhvuxMA.FTeczUWndOSbBLJjvAAMfDkGRxNt.PzCqPEhvgZIyfyePbLBPStPQClnW = new IntPtr(BitConverter.ToInt32(GadKLGtEVdoFXBPOgDlNeswhvuxMA.SpFdTfTtVlHEVCHwCKgLXqoPfAye, num + 4));
		}
		else
		{
			GadKLGtEVdoFXBPOgDlNeswhvuxMA.FTeczUWndOSbBLJjvAAMfDkGRxNt.PzCqPEhvgZIyfyePbLBPStPQClnW = new IntPtr(BitConverter.ToInt32(GadKLGtEVdoFXBPOgDlNeswhvuxMA.SpFdTfTtVlHEVCHwCKgLXqoPfAye, num));
		}
		if (P_0 >= 0)
		{
			GadKLGtEVdoFXBPOgDlNeswhvuxMA.QuQVknkExNSQldIUOusdkaiaVSGw(YxnauwvwzpbEuGCCcOwabzsfvwdbc.mRuhmGTfsoQHVLTfewsqXkAQfJjw(GadKLGtEVdoFXBPOgDlNeswhvuxMA.FTeczUWndOSbBLJjvAAMfDkGRxNt.xvzavcsRcDszRIyMWubCdWrWcvCx), LzzDrSGBjXWyBBXOFCXFTEexBDId.QVUcChqoseEMuHGeHNHIHmgaFLkZB(GadKLGtEVdoFXBPOgDlNeswhvuxMA.FTeczUWndOSbBLJjvAAMfDkGRxNt.DvcLaSwLRKgEXzwcujsBUDGyZUTw), GadKLGtEVdoFXBPOgDlNeswhvuxMA.FTeczUWndOSbBLJjvAAMfDkGRxNt.bQbwKoDsNMSeWIqNkagAMrGiIhAd, GadKLGtEVdoFXBPOgDlNeswhvuxMA.FTeczUWndOSbBLJjvAAMfDkGRxNt.PzCqPEhvgZIyfyePbLBPStPQClnW);
		}
		return EXgHKHhQhxhdfHdEUFBNvbMCeNId(GadKLGtEVdoFXBPOgDlNeswhvuxMA.UZwuBwuNMuwlUCNHFPbRIJhzTOAs, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		MHtyMBMwYrvOWiSsIqfRzOWuGAei(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void fgqKrHjERkAxDiRyRaAhlfSYGwymA()
	{
		try
		{
			MHtyMBMwYrvOWiSsIqfRzOWuGAei(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void MHtyMBMwYrvOWiSsIqfRzOWuGAei(bool P_0)
	{
		if (!WQQpCsHeLomWcEQCMHPPevitfUoy)
		{
			dPjRWdPOJgOXWqJcigbdyGWJiTOx();
			if (GadKLGtEVdoFXBPOgDlNeswhvuxMA == this)
			{
				GadKLGtEVdoFXBPOgDlNeswhvuxMA = null;
			}
			WQQpCsHeLomWcEQCMHPPevitfUoy = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr whlGjlDkRgSZPqkubgqnCPhKwbGLb(int P_0, pYbEiSkHBNHyHVQOURXzSZwPnkGA P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool rHKyoVhLlAVuQZXVEmqkGqlaWsnI(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr EXgHKHhQhxhdfHdEUFBNvbMCeNId(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
