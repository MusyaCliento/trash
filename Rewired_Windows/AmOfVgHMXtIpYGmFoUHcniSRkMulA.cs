using System;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils;

internal static class AmOfVgHMXtIpYGmFoUHcniSRkMulA
{
	private static IntPtr htTAFlkIyxuLxVcwBFzooomifbFrA = IntPtr.Zero;

	private static int grblDmSJADgAKRpmMIsXgegthMAWA;

	[DllImport("Kernel32.dll", EntryPoint = "GetLastError")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint hdxAhPuoPNBDjlEikFYeluOajNlGA();

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcess")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr OGZzaluViidxardaGoIAuHxwyZRT();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetCurrentThreadId")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint cllSdXgrVIssHPOanamWSfRCGKam();

	[DllImport("Kernel32.dll", EntryPoint = "IsWow64Process")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool szaZcZpUYEaZFNmKueDKeYjHQwNU(IntPtr P_0, out bool P_1);

	[DllImport("kernel32.dll", EntryPoint = "GetOverlappedResult", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern bool lDAVdcsTDpACUdXioTQJHSOSUzXE(IntPtr P_0, IntPtr P_1, out uint P_2, bool P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr ABaxBmCjXYCCaHlUDFKBXdiwfmHd();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetForegroundWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr MolCoBHyuLVDupYjlPzvmPaxEMSCA();

	public static IntPtr ncQnzzogZwHDsdFoyYwKEQygqpHK(IntPtr P_0, int P_1)
	{
		if (IntPtr.Size == 4)
		{
			return eRRzhkhHBKHroeqYFgelhiYdPBQsA(P_0, P_1);
		}
		return mBTHNAiCuIsMlAATMliSnNpaFHTqA(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr eRRzhkhHBKHroeqYFgelhiYdPBQsA(IntPtr P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr mBTHNAiCuIsMlAATMliSnNpaFHTqA(IntPtr P_0, int P_1);

	public static IntPtr oTVgYizhKwDewPkzUYjJsPfXHHSl(IntPtr P_0, int P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return vznlEMOQorUVwIANFOJEOoEXiuLq(P_0, P_1, P_2);
		}
		return OkwnSXxTRopxzjpMVinKseQwsWnR(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr OkwnSXxTRopxzjpMVinKseQwsWnR(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr vznlEMOQorUVwIANFOJEOoEXiuLq(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint SlBpWWvvDcqiBQMNqydVovKUDqqm(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint XWempgSHwkjvHqkPRNgqavHAoZHr(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint UqVlOgWbGRvoqVGfocEJFKomVocWA(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int KPAhjsAlupyTWCazAwaExlbWSzwi(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3, uint P_4);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int MWNTUqpTxFsDRVGstzIumOVPaRBdA(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "SystemParametersInfo")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool ZOkGWgDVPIeoemztbDJgjBJkkJOEA(uint P_0, uint P_1, ref int P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetSystemMetrics")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int qaNIikZIdIndIbOvcNEKVLUfFRhIA(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool xMzgaiupqzemUKoGmSkdLLOmdeyE(out aegcjjfGhQrJpMPvSdGYpolmEKHG P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "OpenInputDesktop")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr KKSFocsfIoPvSaRHKGrwlbmFENYj(uint P_0, bool P_1, uint P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short aJxqguVXLbHSJMoClFOZHMnXCeQK(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetAsyncKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short fYdDcnKbmXhXoLGKaoALTcdQJbVI(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool RuacZBejzVfrGPgvTDfXiYxAJHhsb(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "ClientToScreen")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool vwEDsUQbkXqVOdEPDIjlcpwgxlbuA(IntPtr P_0, out aegcjjfGhQrJpMPvSdGYpolmEKHG P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetClientRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool qPiUHIhhniaKjiHuVAVdQdLVBWJfA(IntPtr P_0, out bpvkjeXazKdJWfMibCYdUmSMzgsPA P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetWindowRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool SMQgDrgoxUhIpAHjwlfmurrcRMrRA(IntPtr P_0, out bpvkjeXazKdJWfMibCYdUmSMzgsPA P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint OTeBDvHwSkqKKXoWWaOAfYDogfbsA(uint P_0, uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardLayout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr RvFcKNgbGCBEVFiyhkIlpgtGKWlI(uint P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "GetKeyboardLayoutNameW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool fTFkjlzBHPppmMwoIBmrVoljTlOL(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "ToUnicode")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int KWsHKorpjypxMJfxnFzPurnFJovQ(uint P_0, uint P_1, IntPtr P_2, [Out][MarshalAs(UnmanagedType.LPWStr)] char[] P_3, int P_4, uint P_5);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "GetKeyNameTextW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int TNzDEEQTwJwzDpGThdZoZdbvBfzI(int P_0, [Out][MarshalAs(UnmanagedType.LPWStr)] char[] P_1, int P_2);

	[DllImport("msvcrt.dll", EntryPoint = "memcpy")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool PDcaGQwDgjKryvELYKpZfjZpcRoIA(void* P_0, void* P_1, UIntPtr P_2);

	public static IntPtr zuLdjdAFcPBZQRdAmrGSDZgpfcWab()
	{
		if (!UnityTools.isEditor && htTAFlkIyxuLxVcwBFzooomifbFrA != IntPtr.Zero)
		{
			return htTAFlkIyxuLxVcwBFzooomifbFrA;
		}
		return htTAFlkIyxuLxVcwBFzooomifbFrA = ABaxBmCjXYCCaHlUDFKBXdiwfmHd();
	}

	public static bool NJcYVdlPDKVXrMIcrmgQnnxhtzNK()
	{
		try
		{
			if (grblDmSJADgAKRpmMIsXgegthMAWA == 0)
			{
				bool flag;
				if (IntPtr.Size == 8)
				{
					grblDmSJADgAKRpmMIsXgegthMAWA = 2;
				}
				else if (szaZcZpUYEaZFNmKueDKeYjHQwNU(OGZzaluViidxardaGoIAuHxwyZRT(), out flag))
				{
					if (flag)
					{
						grblDmSJADgAKRpmMIsXgegthMAWA = 2;
					}
					else
					{
						grblDmSJADgAKRpmMIsXgegthMAWA = 1;
					}
				}
			}
		}
		catch
		{
			grblDmSJADgAKRpmMIsXgegthMAWA = 1;
		}
		return grblDmSJADgAKRpmMIsXgegthMAWA == 2;
	}
}
