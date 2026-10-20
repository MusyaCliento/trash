using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class UFMwUCLEfPnrBMPpCgGEEzdhAbbFA
{
	public unsafe static int GpMFqnAeNnATBURhDXNmQXIMDkwBb(int P_0, int P_1, out BnaAtIcSEWVTXkQzNGqwcGdCWhUv P_2)
	{
		if (iolROZkhgUsqlGCDPnonhVToqats.ADOXnkaCtFrrZrAjIyNNpcDUWEUB >= oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_4)
		{
			P_2 = default(BnaAtIcSEWVTXkQzNGqwcGdCWhUv);
			return 0;
		}
		P_2 = default(BnaAtIcSEWVTXkQzNGqwcGdCWhUv);
		int result;
		fixed (BnaAtIcSEWVTXkQzNGqwcGdCWhUv* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = rKDHFTXDbkSpQQHTTPxBdcTJfeRz(P_0, P_1, ptr2);
		}
		return result;
	}

	private unsafe static int rKDHFTXDbkSpQQHTTPxBdcTJfeRz(int P_0, int P_1, void* P_2)
	{
		return iolROZkhgUsqlGCDPnonhVToqats.ADOXnkaCtFrrZrAjIyNNpcDUWEUB switch
		{
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_3 => StCFMyROsPNpjzAAzEWSPPEdcJYZ(P_0, P_1, P_2), 
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_2 => uKSNQewtJdVdKVfsRuraIhAXBtcC(P_0, P_1, P_2), 
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_1 => NaorDgMBkKyhRilGddmNeHEHsSGcA(P_0, P_1, P_2), 
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_9_1_0 => yzMvjVhnsplOGXMqqMDqdsFsoBJB(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int yzMvjVhnsplOGXMqqMDqdsFsoBJB(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int NaorDgMBkKyhRilGddmNeHEHsSGcA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int uKSNQewtJdVdKVfsRuraIhAXBtcC(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int StCFMyROsPNpjzAAzEWSPPEdcJYZ(int P_0, int P_1, void* P_2);

	public unsafe static int YYhNElRagQzJdHgfCZdcfUnArvzx(int P_0, seSCKmPhVOaOdbrRYdsdcvubRfnXA P_1)
	{
		return duJlBQNJvyYrGFGQgfPRIZeEFCxC(P_0, &P_1);
	}

	private unsafe static int duJlBQNJvyYrGFGQgfPRIZeEFCxC(int P_0, void* P_1)
	{
		return iolROZkhgUsqlGCDPnonhVToqats.ADOXnkaCtFrrZrAjIyNNpcDUWEUB switch
		{
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_4 => wUeehUKuGBhBpnwUwzrPFWkBzGzkA(P_0, P_1), 
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_3 => OcbFoHQDwOENvWOVXmQWzzzNqIKB(P_0, P_1), 
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_2 => ZLegAyTNgksGBSFlukScyjWyqlhI(P_0, P_1), 
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_1 => qUDwssUKrpFWDMPHFwGOsfRFlKaM(P_0, P_1), 
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_9_1_0 => qRWLhzEpMwlWjoqrYrXgpRghQjIP(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int qRWLhzEpMwlWjoqrYrXgpRghQjIP(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int qUDwssUKrpFWDMPHFwGOsfRFlKaM(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ZLegAyTNgksGBSFlukScyjWyqlhI(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int OcbFoHQDwOENvWOVXmQWzzzNqIKB(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int wUeehUKuGBhBpnwUwzrPFWkBzGzkA(int P_0, void* P_1);

	public unsafe static int gryFsKbuIamKRYWuEegtwyupUsvB(int P_0, out Guid P_1, out Guid P_2)
	{
		P_1 = default(Guid);
		P_2 = default(Guid);
		int result;
		fixed (Guid* ptr = &P_1)
		{
			void* ptr2 = ptr;
			fixed (Guid* ptr3 = &P_2)
			{
				void* ptr4 = ptr3;
				result = ELbCiPzDKdLQkaaBIUiGsHhCjZry(P_0, ptr2, ptr4);
			}
		}
		return result;
	}

	private unsafe static int ELbCiPzDKdLQkaaBIUiGsHhCjZry(int P_0, void* P_1, void* P_2)
	{
		return iolROZkhgUsqlGCDPnonhVToqats.ADOXnkaCtFrrZrAjIyNNpcDUWEUB switch
		{
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_3 => dgMtiSjPtVGjqEnMmCRpJiabHvWK(P_0, P_1, P_2), 
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_2 => NxeYMszvAjlMipkekFNFHaaNpxDMA(P_0, P_1, P_2), 
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_1 => vllcOfKKJXMzuutXSNHjEMFrVmYLA(P_0, P_1, P_2), 
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_9_1_0 => wfdLSjMLWVARYcOditdNdeXWqYMWA(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int wfdLSjMLWVARYcOditdNdeXWqYMWA(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int vllcOfKKJXMzuutXSNHjEMFrVmYLA(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int NxeYMszvAjlMipkekFNFHaaNpxDMA(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int dgMtiSjPtVGjqEnMmCRpJiabHvWK(int P_0, void* P_1, void* P_2);

	[SuppressUnmanagedCodeSecurity]
	public unsafe static int yVeMgxrsATAUNodAdnFBtGHxhYjC(int P_0, out fcgaDiUuQjslatnxWTYHEvWxgQbd P_1)
	{
		P_1 = default(fcgaDiUuQjslatnxWTYHEvWxgQbd);
		int result;
		fixed (fcgaDiUuQjslatnxWTYHEvWxgQbd* ptr = &P_1)
		{
			void* ptr2 = ptr;
			result = LoLsgYjhDubCvdRQTLZCqDIqnGLFb(P_0, ptr2);
		}
		return result;
	}

	private unsafe static int LoLsgYjhDubCvdRQTLZCqDIqnGLFb(int P_0, void* P_1)
	{
		if (iolROZkhgUsqlGCDPnonhVToqats.uCmrcqHAVMYMnunSkvZpBRcDuJmP && iolROZkhgUsqlGCDPnonhVToqats.mUSnbJtrXFemCnSUgevHNOLxCmUW != null)
		{
			return iolROZkhgUsqlGCDPnonhVToqats.mUSnbJtrXFemCnSUgevHNOLxCmUW(P_0, P_1);
		}
		return iolROZkhgUsqlGCDPnonhVToqats.ADOXnkaCtFrrZrAjIyNNpcDUWEUB switch
		{
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_4 => tjzCbSUbUGECvIGKPMggMmDnGSYuA(P_0, P_1), 
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_3 => HZLMNgPoBwapxDRbeaaiIEDFljzmB(P_0, P_1), 
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_2 => pvzOwpsaLzehXkOaywMISCKiPNtvA(P_0, P_1), 
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_1 => xvdSTHeQLTIUXcqyxkQguSXXKyBsA(P_0, P_1), 
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_9_1_0 => RwfIMgOPBJxNniklGSGcGPTNFojF(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int RwfIMgOPBJxNniklGSGcGPTNFojF(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int xvdSTHeQLTIUXcqyxkQguSXXKyBsA(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int pvzOwpsaLzehXkOaywMISCKiPNtvA(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int HZLMNgPoBwapxDRbeaaiIEDFljzmB(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int tjzCbSUbUGECvIGKPMggMmDnGSYuA(int P_0, void* P_1);

	public unsafe static int cGyluZcPOcjBiHbQYaCqaSVKjecLB(int P_0, HTmUSdjjloDLLeXwWcZCmgewsKtR P_1, out kLVKSgSTPAtymWLTsHpBaWkOwOnI P_2)
	{
		P_2 = default(kLVKSgSTPAtymWLTsHpBaWkOwOnI);
		int result;
		fixed (kLVKSgSTPAtymWLTsHpBaWkOwOnI* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = MRehtmmHlcHAkOpXjjErodpcDDQl(P_0, (int)P_1, ptr2);
		}
		return result;
	}

	private unsafe static int MRehtmmHlcHAkOpXjjErodpcDDQl(int P_0, int P_1, void* P_2)
	{
		return iolROZkhgUsqlGCDPnonhVToqats.ADOXnkaCtFrrZrAjIyNNpcDUWEUB switch
		{
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_4 => vPafjWcLEBpBhpMaanbEMCpDxDvB(P_0, P_1, P_2), 
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_3 => HkRbsXAEnDvLAbOFEvQfRCntdEjEA(P_0, P_1, P_2), 
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_2 => MLBwilJQWUWRHpFkcKgpNaOdqppq(P_0, P_1, P_2), 
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_1 => UPOGjbxJpEWToCXLxtRSurafaJwh(P_0, P_1, P_2), 
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_9_1_0 => jfzcmFBbeyGxjEAuFzAmNRPJGFooA(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int jfzcmFBbeyGxjEAuFzAmNRPJGFooA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int UPOGjbxJpEWToCXLxtRSurafaJwh(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int MLBwilJQWUWRHpFkcKgpNaOdqppq(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int HkRbsXAEnDvLAbOFEvQfRCntdEjEA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int vPafjWcLEBpBhpMaanbEMCpDxDvB(int P_0, int P_1, void* P_2);

	public unsafe static int rpeCcpGxhoNmgBCXspZjMGkdMAVQA(int P_0, yKuDhVfAyKrnqCyQeRBMtLuiqAWA P_1, out vKGizRJyqwDsgPRDaltypLsobuAy P_2)
	{
		P_2 = default(vKGizRJyqwDsgPRDaltypLsobuAy);
		int result;
		fixed (vKGizRJyqwDsgPRDaltypLsobuAy* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = tXPUmHyPdkLpcrowGogEslOgqIHA(P_0, (int)P_1, ptr2);
		}
		return result;
	}

	private unsafe static int tXPUmHyPdkLpcrowGogEslOgqIHA(int P_0, int P_1, void* P_2)
	{
		return iolROZkhgUsqlGCDPnonhVToqats.ADOXnkaCtFrrZrAjIyNNpcDUWEUB switch
		{
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_3 => oduynimDEuFEWAmhWBUGfaZHZzMac(P_0, P_1, P_2), 
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_2 => AbVSrIbCLLnzIWGCjCiJuJNwLuBm(P_0, P_1, P_2), 
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_1 => NrQDIsfayISAxLvWJQWnTWCkQWnb(P_0, P_1, P_2), 
			oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_9_1_0 => weDSFnCIsETFnKkzikYrHaxToQLg(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int weDSFnCIsETFnKkzikYrHaxToQLg(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int NrQDIsfayISAxLvWJQWnTWCkQWnb(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int AbVSrIbCLLnzIWGCjCiJuJNwLuBm(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int oduynimDEuFEWAmhWBUGfaZHZzMac(int P_0, int P_1, void* P_2);

	public static void uzWSBNwOxnHpdgHAfHNxjeJfmiVib(YtZbTuQWOhHtiIzeVCefDxzcOtoOc P_0)
	{
		TjuiiPrPXOqsVgBUJrlzCNnZBNst(P_0);
	}

	private static void TjuiiPrPXOqsVgBUJrlzCNnZBNst(YtZbTuQWOhHtiIzeVCefDxzcOtoOc P_0)
	{
		switch (iolROZkhgUsqlGCDPnonhVToqats.ADOXnkaCtFrrZrAjIyNNpcDUWEUB)
		{
		case oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_3:
			cOKadzrbvxSDyBEdPOANByMGEMmM(P_0);
			break;
		case oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_2:
			aLowtoOSyHmZrBbHPXsSzYXpmBWK(P_0);
			break;
		case oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_1:
			vFPXkMJCcFDgJFzcvjQmBRwgqHXV(P_0);
			break;
		case oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_9_1_0:
			bMDlZQrqbgquOWgDMXtaAOWhKdhI(P_0);
			break;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void bMDlZQrqbgquOWgDMXtaAOWhKdhI(YtZbTuQWOhHtiIzeVCefDxzcOtoOc P_0);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void vFPXkMJCcFDgJFzcvjQmBRwgqHXV(YtZbTuQWOhHtiIzeVCefDxzcOtoOc P_0);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void aLowtoOSyHmZrBbHPXsSzYXpmBWK(YtZbTuQWOhHtiIzeVCefDxzcOtoOc P_0);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void cOKadzrbvxSDyBEdPOANByMGEMmM(YtZbTuQWOhHtiIzeVCefDxzcOtoOc P_0);
}
