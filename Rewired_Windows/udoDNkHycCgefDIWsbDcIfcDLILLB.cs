using System;
using System.Runtime.InteropServices;
using Rewired.Platforms.Microsoft.WindowsGamingInput;

internal static class udoDNkHycCgefDIWsbDcIfcDLILLB
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void QoaArKCmBergUuuCcKzGHbxMbuRbb(RwLabsEOzFsRaihcrFeZHujcOJgIB pGamepad);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void tpyWFonmfzbDlWhHiUdmqhcgTXrK(RwLabsEOzFsRaihcrFeZHujcOJgIB pGamepad);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void WCgTDJoGFcQjBFYPHaVowGvgvEGP(RwLabsEOzFsRaihcrFeZHujcOJgIB pRawGameController);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void MoQyBvJgAJCOGoJtPrmJWRSfrQNR(RwLabsEOzFsRaihcrFeZHujcOJgIB pRawGameController);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void UZeFcVdrGnDaDKfdMNUzQSvopDwuA(RwLabsEOzFsRaihcrFeZHujcOJgIB coreWindow, RwLabsEOzFsRaihcrFeZHujcOJgIB keyEventArgs);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void dzsrdbPtIDNVSEriPtdFFIGHEjkgA(RwLabsEOzFsRaihcrFeZHujcOJgIB coreDispatcher, RwLabsEOzFsRaihcrFeZHujcOJgIB acceleratorKeyEventArgs);

	public const string ENYpNbqZEmIGDTCwIhMhctZUnaHj = "Rewired_WindowsGamingInput";

	private const CallingConvention AmfGtheGyRybKqNAhPePKoaohoODA = CallingConvention.StdCall;

	private const CallingConvention pwWOLJExEySGwgPUlpeokvsiRbJi = CallingConvention.StdCall;

	private const UnmanagedType DVWiBhnEnXlIpWToOMmaLyIyfgEJ = UnmanagedType.LPWStr;

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "IUnknown_Release")]
	private static extern ulong kcBuDOJiJDCoABREggaLGKOOwzGE(IntPtr P_0);

	public static ulong yxmbcKgIBpwTwioMtxbIuNqYOZYWA(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0uL;
		}
		return kcBuDOJiJDCoABREggaLGKOOwzGE(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "IUnknown_AddRef")]
	private static extern ulong PMxoOlOlgSbNpLwisGByzEHhgoLdA(IntPtr P_0);

	public static ulong YAXSwcstKHMlBVZtbnbYWqsYzwum(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0uL;
		}
		return PMxoOlOlgSbNpLwisGByzEHhgoLdA(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Core_IsAPISupported")]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool zZlLOCYfcJXCdvDnxyvWswTWTdid();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Core_GetMinimumRequiredWindowsVersionString")]
	private static extern IntPtr bavQIWdBbvIeNEkiJvtDBuYHXPGr();

	public static string DiIPgOQxLrgkwnBgHYxaoPlmRcfn()
	{
		IntPtr intPtr = bavQIWdBbvIeNEkiJvtDBuYHXPGr();
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepads")]
	public static extern RwLabsEOzFsRaihcrFeZHujcOJgIB ZzSQSWNDHhlInmYDeLbdKnqAkcDr();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepadCount")]
	public static extern uint INpkoKRwOrVaJveqJcRMRpPTimocA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepad")]
	public static extern RwLabsEOzFsRaihcrFeZHujcOJgIB NgWSrQfKtHISVHQyFNHIIjRyuvbK(IntPtr P_0, uint P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetCurrentReading")]
	public static extern bool enaJmmVzgELkhqkhzHereUHbYFQO(IntPtr P_0, ref atgIFQpkSifJQdHTdmSHWzSyatSg P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetVibration")]
	public static extern bool KEnpIiGzABVuByifdIaFWOHLbtRL(IntPtr P_0, ref vhBtsabzPKkijgkLYIuaKiuzvryy P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetVibration")]
	public static extern void RCoTRzorSSpGdqggFFZuHNXVQpCkA(IntPtr P_0, [In][MarshalAs(UnmanagedType.Struct)] vhBtsabzPKkijgkLYIuaKiuzvryy P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetUser")]
	private static extern IntPtr AhUBZcWtjylVHprCpfUayCwbaGjn(IntPtr P_0);

	public static THVaKaaaPPtLYMxiOdtmdFaFYMLdA QWwlmzYddOCJvLByUfiDHmgdYCPpA(IntPtr P_0)
	{
		IntPtr intPtr = AhUBZcWtjylVHprCpfUayCwbaGjn(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return new THVaKaaaPPtLYMxiOdtmdFaFYMLdA(new sBjgzLwqPhprfslfghRWQAGrbkct(intPtr));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_IsGamepad")]
	public static extern bool oXuIkmTGAUBIhXmNcyWgtDrDGJBfA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_FromGameController")]
	public static extern RwLabsEOzFsRaihcrFeZHujcOJgIB ELTChFwGPwMYUbyoKaXIfmUGjsvq(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetButtonLabel")]
	public static extern DQULNtajDVdsYULTiraYeWDVvfxy toPChVkZftRurgufSidacFABeSjPB(IntPtr P_0, GamepadButtons P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_ListenForEvents")]
	public static extern void mvaLjAKjcvQDGLTVEabWtpAzfodbA();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_StopListeningForEvents")]
	public static extern void DQbeJhbfdMBYPWSAYLpDAvRgbAjTA();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetEventListener_GamepadAdded")]
	public static extern void XWoseGYSZGpcdIGNSnKutamyKHUb(QoaArKCmBergUuuCcKzGHbxMbuRbb P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetEventListener_GamepadRemoved")]
	public static extern void mziMHeyKvglRGRAAtsANRHtrOeAI(tpyWFonmfzbDlWhHiUdmqhcgTXrK P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameControllerCount")]
	public static extern uint lfZEduPxDOgSxhDYhJsxhKglZrns(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameControllers")]
	public static extern RwLabsEOzFsRaihcrFeZHujcOJgIB ZgtbJitSLdducCDNrcHAMgsNBceJ();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameController")]
	public static extern RwLabsEOzFsRaihcrFeZHujcOJgIB qlspqYpZncLKGupzUjeItOPJCTXz(IntPtr P_0, uint P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetCurrentReading")]
	private static extern ulong KdDMbHSdCWAGkXrKDLRXLyzLHZBu(IntPtr P_0, bool[] P_1, uint P_2, lWcCKOkdiybayGybKFVVYgyKjLGP[] P_3, uint P_4, double[] P_5, uint P_6);

	public static ulong NRNyKLPTIvbFpkkqqJBQqIZlGRKM(IntPtr P_0, bool[] P_1, lWcCKOkdiybayGybKFVVYgyKjLGP[] P_2, double[] P_3)
	{
		return KdDMbHSdCWAGkXrKDLRXLyzLHZBu(P_0, P_1, (uint)P_1.Length, P_2, (uint)P_2.Length, P_3, (uint)P_3.Length);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetIsWireless")]
	public static extern bool UpyOeyHilaWxlNnrdGQSybDudnId(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSimpleHapticsControllers")]
	public static extern RwLabsEOzFsRaihcrFeZHujcOJgIB RqpgDAFQRrNWPHdlQqwbpcLnOfOeA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSimpleHapticsControllerCount")]
	public static extern uint LGWFzEaqhWqlkUADPccXfVpDwHueA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetUser")]
	public static extern RwLabsEOzFsRaihcrFeZHujcOJgIB nYaHlZPFbndjPaoeaJHJLQMNNqQL(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetButtonCount")]
	public static extern int QtupdITDUxgxyCtMgdFmfBTRxGqbb(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSwitchCount")]
	public static extern int aYOdOkgbUdsHHtBrMbNvVsUdWCvc(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetAxisCount")]
	public static extern int WGQARuqrtASdUMHHpkvdVDTyEOqAA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetDisplayName")]
	private static extern IntPtr ZFkexmbHTgzkRJPfOlYWGpXhyztz(IntPtr P_0);

	public static string ZMjofqMFkSxDWjqopnkIyWvfqdHE(IntPtr P_0)
	{
		IntPtr intPtr = ZFkexmbHTgzkRJPfOlYWGpXhyztz(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetForceFeedbackMotors")]
	public static extern RwLabsEOzFsRaihcrFeZHujcOJgIB MtNDDmCayonhdoufbSttDzRGZxvuA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetForceFeedbackMotorCount")]
	public static extern uint WZDpoLiaywMSYOITRCbPiJkWVVzk(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetButtonLabel")]
	public static extern DQULNtajDVdsYULTiraYeWDVvfxy KGSGemnfLnJFgzWHFwlzekXkoAWU(IntPtr P_0, int P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSwitchKind")]
	public static extern ANlWBaCSpCdHREACGKppiFCRdvmj qXoCHXbpIxgokcjvdysLllpvOkXOA(IntPtr P_0, int P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHardwareVendorId")]
	public static extern ushort XsNEOaEPSptotKktOgQgIJTtNTeGA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHardwareProductId")]
	public static extern ushort bvpIJkEHktiFoFPTPjVnVOTAlVgLA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_TryGetBatteryReport")]
	public static extern RwLabsEOzFsRaihcrFeZHujcOJgIB QNcJDCMcEJUPJPXzlSAJPCGmTint(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetNonRoamableId")]
	public static extern IntPtr wQfPRrMDMkcnhlFnXHZXYWpNFxVX(IntPtr P_0);

	public static string uOmHPiTpweAKyXPBGctYvuTQBRin(IntPtr P_0)
	{
		IntPtr intPtr = wQfPRrMDMkcnhlFnXHZXYWpNFxVX(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHeadset")]
	public static extern RwLabsEOzFsRaihcrFeZHujcOJgIB qbcTrHQhzENCtaqAcoYbvtyRtlhQ(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_IsRawGameController")]
	public static extern bool dWEqPRqOaWHtOHUKpVEPACCpElvH(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_FromGameController")]
	public static extern RwLabsEOzFsRaihcrFeZHujcOJgIB vLqcozhGotKmBwFMRphoGfAeUenhA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_ListenForEvents")]
	public static extern void STZWurVfjnIsuhtUctzgtWBnNkEA();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_StopListeningForEvents")]
	public static extern void yzrMaeZhEAfnDhzLyZIWgJYtqJSAA();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_SetEventListener_RawGameControllerAdded")]
	public static extern void euUItqRGrjrazbsRemzEecSehaeo(WCgTDJoGFcQjBFYPHaVowGvgvEGP P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_SetEventListener_RawGameControllerRemoved")]
	public static extern void uUqdirPJJdjSirGewSTGBigedsTJ(MoQyBvJgAJCOGoJtPrmJWRSfrQNR P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "User_GetType")]
	private static extern int IYOMReWgdRzkxGAkpTDOEexoeQYU(IntPtr P_0);

	public static jBwrvJapLdtwgvzwJJwLtITOslMI xCPSkNqqMcvJTowxpxiVoaJzHvRg(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return jBwrvJapLdtwgvzwJJwLtITOslMI.LocalUser;
		}
		return (jBwrvJapLdtwgvzwJJwLtITOslMI)IYOMReWgdRzkxGAkpTDOEexoeQYU(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "User_GetNonRoamableId")]
	private static extern IntPtr TYmBTwkgqAdfiFrpAfSGHWLaBWiIE(IntPtr P_0);

	public static string tnNobHPxhntzWGoVOINyaNNQHaYC(IntPtr P_0)
	{
		IntPtr intPtr = TYmBTwkgqAdfiFrpAfSGHWLaBWiIE(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_GetMainCoreWindow")]
	private static extern RwLabsEOzFsRaihcrFeZHujcOJgIB vLlwVAnFTbiyawFanKSxdayZFZCo();

	public static RwLabsEOzFsRaihcrFeZHujcOJgIB cNfEjPmDlocvOgzspWYnXxyfffsu()
	{
		return vLlwVAnFTbiyawFanKSxdayZFZCo();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_AddEventListener_KeyUp")]
	private static extern IntPtr DFVeFxdaZmeHtvYHqPvvEqEqtckCA(IntPtr P_0);

	public static yNkUBxmRevJKGAdbHZHAGKyXNjml AgqHwvaobvcVoAUsowMvIbLwrTYfb(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return null;
		}
		try
		{
			IntPtr intPtr = DFVeFxdaZmeHtvYHqPvvEqEqtckCA(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new yNkUBxmRevJKGAdbHZHAGKyXNjml(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_AddEventListener_KeyDown")]
	private static extern IntPtr dlUyEXApjrDkKKtPITsWfEvQxgJA(IntPtr P_0);

	public static yNkUBxmRevJKGAdbHZHAGKyXNjml qMFrGBwfnydytJvwcoNethxGkEFS(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return null;
		}
		try
		{
			IntPtr intPtr = dlUyEXApjrDkKKtPITsWfEvQxgJA(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new yNkUBxmRevJKGAdbHZHAGKyXNjml(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_RemoveEventListener_KeyUp")]
	private static extern void fmHdYdiRnRAlQCHJUpDQqaeGZdY(IntPtr P_0, IntPtr P_1);

	public static void ARoLCAHvIhBrxHFNSMvcYNacDbKH(IntPtr P_0, yNkUBxmRevJKGAdbHZHAGKyXNjml P_1)
	{
		if (!(P_0 == IntPtr.Zero) && !cmljYJRyPbcorhMIgrztlqmldhcX.ItHwyJowHJDNDjHACcwOyJeyBjJhA(P_1, null))
		{
			fmHdYdiRnRAlQCHJUpDQqaeGZdY(P_0, P_1.LBdxFigkJISeQizMgNUsybljbbQt);
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_RemoveEventListener_KeyDown")]
	private static extern void bXDMrWgGwyzdBzLNveevGfrOrtoK(IntPtr P_0, IntPtr P_1);

	public static void zDFgpPkqfubVeeBJqnJbNrORxHjxA(IntPtr P_0, yNkUBxmRevJKGAdbHZHAGKyXNjml P_1)
	{
		if (!(P_0 == IntPtr.Zero) && !cmljYJRyPbcorhMIgrztlqmldhcX.ItHwyJowHJDNDjHACcwOyJeyBjJhA(P_1, null))
		{
			bXDMrWgGwyzdBzLNveevGfrOrtoK(P_0, P_1.LBdxFigkJISeQizMgNUsybljbbQt);
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_SetUniversalEventListener_KeyUp")]
	private static extern void FHZDvICglpbdPvqzuZmdLLYsEABKA(UZeFcVdrGnDaDKfdMNUzQSvopDwuA P_0);

	public static void aqiaSuqyJQGYkEKTkCaOiORDiCan(UZeFcVdrGnDaDKfdMNUzQSvopDwuA P_0)
	{
		FHZDvICglpbdPvqzuZmdLLYsEABKA(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_ClearUniversalEventListener_KeyUp")]
	private static extern void lsdRLdMuSFgDEvJXEOZXFjhsZkwG();

	public static void diZhqOfTASNJEyICDILhhIWfXrJkA()
	{
		lsdRLdMuSFgDEvJXEOZXFjhsZkwG();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_SetUniversalEventListener_KeyDown")]
	private static extern void tmOAHsPTrYkdlmaUmckSaAAQmltD(UZeFcVdrGnDaDKfdMNUzQSvopDwuA P_0);

	public static void HDrUBpJsiAHLIbkErdXcDLFirkdbA(UZeFcVdrGnDaDKfdMNUzQSvopDwuA P_0)
	{
		tmOAHsPTrYkdlmaUmckSaAAQmltD(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_ClearUniversalEventListener_KeyDown")]
	private static extern void VoZtaHkDCgRqRIwbjZwASAkuAasl();

	public static void jrxrpzxthRvsWcJsuIJroYaprlHh()
	{
		VoZtaHkDCgRqRIwbjZwASAkuAasl();
	}

	public static CPsmBTeugjYeoUzIvtsduEHENVvd sKFgENsCiFqguLmktZtDCSNtYOXt(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(CPsmBTeugjYeoUzIvtsduEHENVvd);
		}
		return new CPsmBTeugjYeoUzIvtsduEHENVvd(yPFJrhKDolfwtQUbXGAAYszIxsly(P_0), rPKLmyWdbgUxNTRMLsXsWSbiGCcO(P_0), tgoPzZWBaidPXCpDuwnvvfyYSEhwA(P_0));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetHandled")]
	private static extern bool yPFJrhKDolfwtQUbXGAAYszIxsly(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetVirtualKey")]
	private static extern lABdNVPRVXEfXAWmakHVSWvqZrHc tgoPzZWBaidPXCpDuwnvvfyYSEhwA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetKeyStatus")]
	private static extern IntPtr rQCstKLlTDdHlvaXDPxiMZqCWTaM(IntPtr P_0);

	private static YbOdVUhsiosMkGjAZfHaSybYPAWz rPKLmyWdbgUxNTRMLsXsWSbiGCcO(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(YbOdVUhsiosMkGjAZfHaSybYPAWz);
		}
		IntPtr intPtr = rQCstKLlTDdHlvaXDPxiMZqCWTaM(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return default(YbOdVUhsiosMkGjAZfHaSybYPAWz);
		}
		YbOdVUhsiosMkGjAZfHaSybYPAWz result = jfyQrJAecQNZXsauiPJNALUUhZRH(intPtr);
		EkljqnpvQtbpsvhYmutcjMTyoGUD(intPtr);
		return result;
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_GetMainCoreDispatcher")]
	private static extern RwLabsEOzFsRaihcrFeZHujcOJgIB FCXCZfEpcilrjAOldbmavrXZCmZn();

	public static RwLabsEOzFsRaihcrFeZHujcOJgIB lIlKNvVPERcqRNBeqMwiHVwvssfQ()
	{
		return FCXCZfEpcilrjAOldbmavrXZCmZn();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_AddEventListener_AcceleratorKeyActivated")]
	private static extern IntPtr TRgbpNMATIVtXYULKNqpWPtzFoqI(IntPtr P_0);

	public static yNkUBxmRevJKGAdbHZHAGKyXNjml EOeGGPkoaByUvoglJmQgpMWOfmwwA(IntPtr P_0)
	{
		try
		{
			IntPtr intPtr = TRgbpNMATIVtXYULKNqpWPtzFoqI(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new yNkUBxmRevJKGAdbHZHAGKyXNjml(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_RemoveEventListener_AcceleratorKeyActivated")]
	private static extern void EjjyjrHfJUelQikPKkKYFpauOAgqA(IntPtr P_0, IntPtr P_1);

	public static void RcSAJSjjgYOOKzeGkdskQbyATtUhA(IntPtr P_0, yNkUBxmRevJKGAdbHZHAGKyXNjml P_1)
	{
		if (!cmljYJRyPbcorhMIgrztlqmldhcX.ItHwyJowHJDNDjHACcwOyJeyBjJhA(P_1, null))
		{
			EjjyjrHfJUelQikPKkKYFpauOAgqA(P_0, P_1.LBdxFigkJISeQizMgNUsybljbbQt);
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_SetUniversalEventListener_AcceleratorKeyActivated")]
	private static extern void XaQygNqBqIUTeaOHdIprsKWXSaOS(dzsrdbPtIDNVSEriPtdFFIGHEjkgA P_0);

	public static void seHxdwcxxEKNErLcLBugensjWzrv(dzsrdbPtIDNVSEriPtdFFIGHEjkgA P_0)
	{
		XaQygNqBqIUTeaOHdIprsKWXSaOS(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_ClearUniversalEventListener_AcceleratorKeyActivated")]
	private static extern void cpBEFUPdNHIWpHgNOIuCcievMCjB();

	public static void pryXNpGEjCRIHnEwgmDPKWnNPztr()
	{
		cpBEFUPdNHIWpHgNOIuCcievMCjB();
	}

	public static zcloqgxRNwplkstNWyyPLhiUiTDF GmOxscWtjGuYOEPNFOzqwsEkHkQA(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(zcloqgxRNwplkstNWyyPLhiUiTDF);
		}
		return new zcloqgxRNwplkstNWyyPLhiUiTDF(nEHjSFajQOOhxbIIcqswLYIGJRGOC(P_0), zPhNJsUgzlJkdgRhiPqekGcJhjhG(P_0), nljQkLLlmrWdMvTBeSTAdkzmkDAe(P_0), GhsmWCCsAbsedGrjyGnEExwyIjOt(P_0));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetEventType")]
	private static extern bKKjgLKivFOPIZAFXOZUblYttlk nEHjSFajQOOhxbIIcqswLYIGJRGOC(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetHandled")]
	private static extern bool zPhNJsUgzlJkdgRhiPqekGcJhjhG(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetVirtualKey")]
	private static extern lABdNVPRVXEfXAWmakHVSWvqZrHc GhsmWCCsAbsedGrjyGnEExwyIjOt(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetKeyStatus")]
	private static extern IntPtr CkaDPrCTWGVcKPZhziqnSSgJFuxaA(IntPtr P_0);

	private static YbOdVUhsiosMkGjAZfHaSybYPAWz nljQkLLlmrWdMvTBeSTAdkzmkDAe(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(YbOdVUhsiosMkGjAZfHaSybYPAWz);
		}
		IntPtr intPtr = CkaDPrCTWGVcKPZhziqnSSgJFuxaA(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return default(YbOdVUhsiosMkGjAZfHaSybYPAWz);
		}
		YbOdVUhsiosMkGjAZfHaSybYPAWz result = jfyQrJAecQNZXsauiPJNALUUhZRH(intPtr);
		EkljqnpvQtbpsvhYmutcjMTyoGUD(intPtr);
		return result;
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "SCorePhysicalKeyStatus_Free")]
	private static extern RwLabsEOzFsRaihcrFeZHujcOJgIB EkljqnpvQtbpsvhYmutcjMTyoGUD(IntPtr P_0);

	private static YbOdVUhsiosMkGjAZfHaSybYPAWz jfyQrJAecQNZXsauiPJNALUUhZRH(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(YbOdVUhsiosMkGjAZfHaSybYPAWz);
		}
		return new YbOdVUhsiosMkGjAZfHaSybYPAWz
		{
			QafdBiBvjeTmnUHScUhuachDxydR = (Marshal.ReadByte(P_0, 0) > 0),
			bxLrCAFaUdrEFeUlOqxxTirRJxHm = (Marshal.ReadByte(P_0, 1) > 0),
			TNMFdWihKMTAAuVKcGUkGKoDChSJB = (Marshal.ReadByte(P_0, 2) > 0),
			QGicyfnppFOkSHgruVoxJgPxqbRN = (uint)Marshal.ReadInt32(P_0, 4),
			eRydeVuipEiKAaCBUIYYVLQPCgwqA = (uint)Marshal.ReadInt32(P_0, 8),
			nAERdJUhepoVCvtWMsZvEdXVVQNj = (Marshal.ReadByte(P_0, 12) > 0)
		};
	}
}
