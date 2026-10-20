using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

internal class OOfAIvbVERMYBhlUHQnhjdMGyRBrc
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal class CBwGWuyRDgvhJyfrfcbsFeauflBd
	{
		public int lMjMviXfjJSQqvksLFbNJDxqjJNjA;

		public int vvzqkyFxYPgZBpeAJRITLOrLldCv;

		public int UwvjRnLPRfZieuriMjsCkSIlPPQt;

		public int fLzfsHmBLjAxcgOcSsYHunsnoKGK;

		public int tdWBwAAAehvrxmCqmOrXMiacndPT;

		public byte QdbZPJNUmxbVAkwezJjVmRZDLXAR;

		public byte KmHApKkjuHAFfLtgtmgSuokMLehpA;

		public byte ceFRUsQqTdzHswiqNbGRAYEosYab;

		public byte EdmzXJpaaRozzYgIxMFQVyRQBExy;

		public byte mMiQGylHSqAUdqhWakEFMcQfEcQgA;

		public byte PeEMjKqnRaQxfsMVMXUaDduJGht;

		public byte RTPUqaZsMVtrSQkHsrYXwJeZpqFp;

		public byte rAyZEHMSGVpjDoxnFZNwRcXBFPTn;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string uFBBraKTpFiVZjEWBhtVOwsKnzre;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct jzHAvIAOSGFLLzpwpiRSrmPdpjcEA
	{
		public int NCcyHxWNqPYvjkNadCZnWRLuCALb;

		public int vSbTjBORinpguEkBRJBBFfIquUgK;

		public int ytmxWnnFmatuiSPKQYzOuAKgBgJkA;

		public int aRVmMuwTEQflBQtbdzIRGrbPqqPK;

		public int XDhBIwFNUAIPinCeWLXXdepDdXcmB;

		public int vPwVWrMWvoaKeTEqTwfaUIAtwYyL;

		public int gsYaKdbuiXDKRsjRiYiUXPegCfos;

		public int UEieZxXJQTlUZKUrdGTuEvAPSNHP;

		public int zQVdmHEyGMgXeNItaegGMiJDQXUq;

		public int MVVdFCFjKinYvoPxDIMPBUqqejPBb;

		public int mOVaxfXvEtbojUHFrGUjvIYRlgyH;

		public char hjjgvyamVCcwFCtqjfyikXWDTZiPb;

		public char DjyXVemMPsXYRosOwUfPloSlzukU;

		public char lXgRPFiTBRDbcrwlqEcDSidRmoso;

		public char EYtlIjIitURfPJfjWgckaeytvDqC;

		public byte fOcFmMFSEjIYsuuICUEQtQfWmDYf;

		public byte hrTKFbEkDgANFQDwsUCXQuzAbtQy;

		public byte KThmQFCAMHgwNofaMxoJdOQXpqmv;

		public byte wXvOuHylLrbZkzwFtCuGblkvDIUHA;

		public byte EZfXQoGEVKbfpWrAQCwvhrcNtKiNA;
	}

	internal enum huBlkSiEbRbpoEVainGQmVxZhUvG
	{
		WndProc = -4,
		HInstance = -6,
		HwndParent = -8,
		Style = -16,
		ExtendedStyle = -20,
		UserData = -21,
		Id = -12
	}

	internal delegate IntPtr aysrNDlwayWeGlChIovjJCuNfEiz(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

	private delegate bool GExvBaBAdIgcaKqRNgFxFPwwfvUO(IntPtr hwnd, IntPtr lParam);

	private static IntPtr IrQnYVFfWkgABlNcmPJZRhaHIZEc = IntPtr.Zero;

	private static List<IntPtr> djRgpvcxXOUkqJQtrjZAmRcBDDoJA;

	[DllImport("user32.dll", EntryPoint = "PeekMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int FIeGPugffVlpFuVgGEbOzgyeNQkp(out ZuKuUPooWLcDENFfAqPbzqXmTXIl P_0, IntPtr P_1, int P_2, int P_3, int P_4);

	[DllImport("user32.dll", EntryPoint = "GetMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int ffMHVYHbnjizRTtTSdLOkcJEUFGIA(out ZuKuUPooWLcDENFfAqPbzqXmTXIl P_0, IntPtr P_1, int P_2, int P_3);

	[DllImport("user32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int kPzknLlUmpPQctJZMTVzAJCjgbifA(ref ZuKuUPooWLcDENFfAqPbzqXmTXIl P_0);

	[DllImport("user32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int dnjTmlubWhInqNbkWHiXhRtFIqhg(ref ZuKuUPooWLcDENFfAqPbzqXmTXIl P_0);

	public static IntPtr DKYElLWXmXXMmWFkkJMcFHULTSkP(HandleRef P_0, huBlkSiEbRbpoEVainGQmVxZhUvG P_1)
	{
		if (IntPtr.Size == 4)
		{
			return MDdSSyQbIdCZueTaoRDZCECWyxEL(P_0, P_1);
		}
		return pXmFkVjXekKpBLjeaSqgpajsivnFA(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFocus")]
	public static extern IntPtr uJZAiOSPhpFISczqFIodlaokvjOoA();

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr MDdSSyQbIdCZueTaoRDZCECWyxEL(HandleRef P_0, huBlkSiEbRbpoEVainGQmVxZhUvG P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr pXmFkVjXekKpBLjeaSqgpajsivnFA(HandleRef P_0, huBlkSiEbRbpoEVainGQmVxZhUvG P_1);

	public static IntPtr LzpLzBjTGCwlWKjVMbNcXRURhXr(HandleRef P_0, huBlkSiEbRbpoEVainGQmVxZhUvG P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return VozcnqdmLgQPcrdCLAZUWYFblOksA(P_0, P_1, P_2);
		}
		return ZosDMQSrKkcrtGvzFohlDvjDZHUw(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetParent")]
	public static extern IntPtr qXlDwlwpHMqVtTwfuYHYaJHFBKEg(HandleRef P_0, IntPtr P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLong")]
	private static extern IntPtr VozcnqdmLgQPcrdCLAZUWYFblOksA(HandleRef P_0, huBlkSiEbRbpoEVainGQmVxZhUvG P_1, IntPtr P_2);

	public static bool FMaDPZaOJinVTfbQebeYpBqstZhzb(HandleRef P_0, bool P_1)
	{
		return BpPKSbwluWAapZTPDhLTcNdHcXcf(P_0, P_1 ? 1 : 0);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowWindow")]
	private static extern bool BpPKSbwluWAapZTPDhLTcNdHcXcf(HandleRef P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtr")]
	private static extern IntPtr ZosDMQSrKkcrtGvzFohlDvjDZHUw(HandleRef P_0, huBlkSiEbRbpoEVainGQmVxZhUvG P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	public static extern IntPtr wYQcVDycxgrlvlfKuelkGYurXegkA(IntPtr P_0, IntPtr P_1, int P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandle")]
	public static extern IntPtr JQuHoTAOzxDEuSpeWHvZGmxBUhzV(string P_0);

	public static IntPtr tEDmCrVKXPpTQHcQTGZadRWMxNNLA(IntPtr P_0, huBlkSiEbRbpoEVainGQmVxZhUvG P_1)
	{
		if (IntPtr.Size == 4)
		{
			return uEGDPLgCsAWADQrxezfUIQowPdWe(P_0, P_1);
		}
		return xrerOTGQbXxLkgZnMUwaorWzEbrg(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr uEGDPLgCsAWADQrxezfUIQowPdWe(IntPtr P_0, huBlkSiEbRbpoEVainGQmVxZhUvG P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr xrerOTGQbXxLkgZnMUwaorWzEbrg(IntPtr P_0, huBlkSiEbRbpoEVainGQmVxZhUvG P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	public static extern bool torhKpqcqGWKtnlZnAKTGqqLukMBA(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	private static extern IntPtr sSDxTvOnXQiapwOwwjYRIOXuxtnd();

	[DllImport("Kernel32", EntryPoint = "GetCurrentProcessId")]
	private static extern uint HpLAaXAalHpMAEMaxKTncWVgITVoA();

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	private static extern bool thXYDvpcWJhtZqdbHcBuDlsOMVnm(IntPtr P_0, IntPtr P_1);

	private static bool pBqPULbaEQiYTHCuxnHdAnCuZskqA(IntPtr P_0, IntPtr P_1)
	{
		lock (djRgpvcxXOUkqJQtrjZAmRcBDDoJA)
		{
			djRgpvcxXOUkqJQtrjZAmRcBDDoJA.Add(P_0);
		}
		return true;
	}

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	private static extern uint nDGeYxGrdCYuQzjhmCJFYXPdRiHn(IntPtr P_0, out uint P_1);

	public static IntPtr JMovYokrbURTZqTeusUkKSjunccG()
	{
		if (IrQnYVFfWkgABlNcmPJZRhaHIZEc != IntPtr.Zero)
		{
			return IrQnYVFfWkgABlNcmPJZRhaHIZEc;
		}
		djRgpvcxXOUkqJQtrjZAmRcBDDoJA = new List<IntPtr>();
		uint num = HpLAaXAalHpMAEMaxKTncWVgITVoA();
		GExvBaBAdIgcaKqRNgFxFPwwfvUO gExvBaBAdIgcaKqRNgFxFPwwfvUO = pBqPULbaEQiYTHCuxnHdAnCuZskqA;
		IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(gExvBaBAdIgcaKqRNgFxFPwwfvUO);
		thXYDvpcWJhtZqdbHcBuDlsOMVnm(functionPointerForDelegate, IntPtr.Zero);
		GC.KeepAlive(gExvBaBAdIgcaKqRNgFxFPwwfvUO);
		GC.KeepAlive(functionPointerForDelegate);
		for (int i = 0; i < djRgpvcxXOUkqJQtrjZAmRcBDDoJA.Count; i++)
		{
			if (torhKpqcqGWKtnlZnAKTGqqLukMBA(djRgpvcxXOUkqJQtrjZAmRcBDDoJA[i]))
			{
				nDGeYxGrdCYuQzjhmCJFYXPdRiHn(djRgpvcxXOUkqJQtrjZAmRcBDDoJA[i], out var num2);
				if (num2 == num)
				{
					IrQnYVFfWkgABlNcmPJZRhaHIZEc = djRgpvcxXOUkqJQtrjZAmRcBDDoJA[i];
					djRgpvcxXOUkqJQtrjZAmRcBDDoJA.Clear();
					return IrQnYVFfWkgABlNcmPJZRhaHIZEc;
				}
			}
		}
		return sSDxTvOnXQiapwOwwjYRIOXuxtnd();
	}
}
