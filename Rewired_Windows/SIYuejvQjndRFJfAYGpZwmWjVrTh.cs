using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal sealed class SIYuejvQjndRFJfAYGpZwmWjVrTh : yBATXoBSRnHIKCFttVvSrbcAKezC, IDisposable
{
	private delegate kVithYYhMeLfekTMwHMRdNImqONf LWamiSpmfDTlttUBQwwASjazeffm(int timeout);

	private delegate FBeIUTFrlhTJFSAsreiwBOJDNwHNb rIylkXahFqdPccAGIOScSiQiXKou(int timeout);

	private delegate bool zGmUUWFIfgfcCEwrslrIGysVRPQZ(byte[] data, int timeout);

	private delegate bool OUjkunRSPBrTBywxlwrxlRdOBqc(byte[] data, int timeout, bool setOutputReportDirectly);

	private delegate bool yoKQcBaidFkrSBdSEeTssuoFvxaI(FBeIUTFrlhTJFSAsreiwBOJDNwHNb report, int timeout);

	private enum qixPgHqeAIfnDNnwggJUwnoyHIcE
	{
		Closed = 0,
		Read = 1,
		Write = 2
	}

	private enum dZPfwnlJZNgPMFFwapjBnSzCVBDgA
	{
		Success = 0,
		ReadError = 1,
		BufferTooSmall = 2,
		DeviceNotOpen = 3
	}

	private struct BGoCHfoddDezdVDoYSaMckxkcxKCA
	{
		public bool flKYoeCRgkVmpgZJSSOcioMIfLKn;

		public int AyxLLhDGYLdwVauztVfiSiOdGUOgb;

		public int WKsNHFopZzVwfkmXpMUvUXRJdAAj;
	}

	public const int BhyDlOAMFGbpKtaMNBjuwMBPIPjjA = 255;

	[CompilerGenerated]
	private zPRaNdHFpdBLMUFdfputpFbceSLl DujpSBNnoNkevNYqbrjwsozbDSsc;

	[CompilerGenerated]
	private eztSqtgTosFYtwpQGKbeoujpVAPU iIlLhRnEEDLSBesiOpBbYtzIWVuF;

	private readonly string IHPzEJqIbRbNEelzVMDXNbCTDTkxA;

	private readonly string VlbAsfIhHHuGWdBiHFCWaYywLWmc;

	private readonly string BCXPkoEcSOCkOgTGpgQHbXyJDBSGb;

	private readonly string ufSZknsdcIAbrCiTIWSWxurWZART;

	private readonly ZIQGfvvtwXgDvGscqSxZnSMsIetv diOFFmRkeRwDHbobkdHLvXKhmtlA;

	private readonly string vDnagjgiOrRsdsnkvJANbGmyLpjaA;

	private readonly int DsxoWPNoGcQWIbZpNUlQdtoEvKYo;

	private readonly int MStlYYBfEcrATaQxTjwooNtwKMMm;

	private readonly bool pOKeHZIsClHRhdgtAhbguVaFHUjA;

	private readonly string lghRvarBFLdsFlTQeGmSMKxJvXPB;

	private readonly uint SoNDdHkJOMHxgzCoccZnIuhBTWTC;

	private readonly vTaEkysGrJbjIGXiCYzkVFcdegGY iKwbvhgrUhHRCYWQaohhIhBwSqeU;

	private readonly IdGKZPGlBMdjGcVcHUAhCeMTbpNDA[] aldBbhlQogZBdddqxQlPRDZsQCss;

	private readonly nyKEGqIoaJkcvwlUxeRaXWfkcuizA[] EDJXNIYBwHcAVVwOsIstJTdjddydb;

	private KRlBBVNENHhjaxVLrSwqLDZMBPEO LIOErkgsHvGhqXwjItdOcLjLIyGgb;

	private KRlBBVNENHhjaxVLrSwqLDZMBPEO kcBGzDTgxHCFRYIiurLLEComqnLp;

	private VQXgTjBnGHNJmJPzKCMciSKedVQMc WGceNqZUWCallKvutomtCgNpMqadA = VQXgTjBnGHNJmJPzKCMciSKedVQMc.ShareRead | VQXgTjBnGHNJmJPzKCMciSKedVQMc.ShareWrite;

	private readonly vyDFwzhvWXCEDIBYFQszqfEDCyGcA HSoRxFlSSZrlUrQsFdaEtAvkwfUN;

	private bool vrNCXHaCigchKadqAfobXksUgfgh;

	private global::cIJgGCEhUppLKdHxZeqoRkTiKnWb<edmPFVQXZAgSMnagypaqNIebBPiI.JwgIOxgNqXCCHDLDRRLKxPiwnlfS> SDTfVsFcrgrDNDDxyLVnObljqsoM;

	private global::cIJgGCEhUppLKdHxZeqoRkTiKnWb<edmPFVQXZAgSMnagypaqNIebBPiI.yIAkmGDKNBTAeODUKEvafjOatpYwA> jTwilfqbvezjcCQcEDaJNApcbvEZ;

	private readonly Rewired.Utils.Classes.Utility.SpinLock LqDqMlfSnIblEMLnHgbARpubUtCS = new Rewired.Utils.Classes.Utility.SpinLock();

	private readonly Rewired.Utils.Classes.Utility.SpinLock oSobtejrOAABDHFnzPEYrATvqunE = new Rewired.Utils.Classes.Utility.SpinLock();

	private IntPtr YbLwYOdytdciykhyeFJYiypmYGfq;

	private IntPtr lsSpcuSVuhmvSRPjyQeIPkZoqkTI;

	private qixPgHqeAIfnDNnwggJUwnoyHIcE ydNyOdgSAXDdrlCnVcQBKGlVsXRSA;

	private bool ZVmnLqaCkaDqheuDleILiVEGukMS;

	IntPtr yBATXoBSRnHIKCFttVvSrbcAKezC.TbIhnNJzSpWiqjSMyhHsQPjClOgG => YbLwYOdytdciykhyeFJYiypmYGfq;

	IntPtr yBATXoBSRnHIKCFttVvSrbcAKezC.SWoSvNUbYEHcrqgPsywbepPCvXpQ => lsSpcuSVuhmvSRPjyQeIPkZoqkTI;

	bool yBATXoBSRnHIKCFttVvSrbcAKezC.TzMSKwDntoDtTDphHPUogQsGfgKG
	{
		get
		{
			using (LqDqMlfSnIblEMLnHgbARpubUtCS.Lock())
			{
				using (oSobtejrOAABDHFnzPEYrATvqunE.Lock())
				{
					return ydNyOdgSAXDdrlCnVcQBKGlVsXRSA != qixPgHqeAIfnDNnwggJUwnoyHIcE.Closed;
				}
			}
		}
	}

	bool yBATXoBSRnHIKCFttVvSrbcAKezC.ianaxFwEykpKvoSpIFUxoagvBKbm => RciGSOAIVzSFNUsWuoeDdCDjeMbbc.bZPCVCkEklgiBIxvXmWuAfnvdadbb(VlbAsfIhHHuGWdBiHFCWaYywLWmc);

	string yBATXoBSRnHIKCFttVvSrbcAKezC.okITMMlaEYkrmDZWncZJIBSjgmLQ => IHPzEJqIbRbNEelzVMDXNbCTDTkxA;

	vTaEkysGrJbjIGXiCYzkVFcdegGY yBATXoBSRnHIKCFttVvSrbcAKezC.YYzFmtrEAtiRNtPjhZbbbhzJBxoo => iKwbvhgrUhHRCYWQaohhIhBwSqeU;

	IdGKZPGlBMdjGcVcHUAhCeMTbpNDA[] yBATXoBSRnHIKCFttVvSrbcAKezC.vfZBXSKMHtBNYkQobbwkufFXofNb => aldBbhlQogZBdddqxQlPRDZsQCss;

	nyKEGqIoaJkcvwlUxeRaXWfkcuizA[] yBATXoBSRnHIKCFttVvSrbcAKezC.WkndDbQKxUDTUGUDxapJBerOcalY => EDJXNIYBwHcAVVwOsIstJTdjddydb;

	ZIQGfvvtwXgDvGscqSxZnSMsIetv yBATXoBSRnHIKCFttVvSrbcAKezC.gVrebRKaUUSNFbSkxkRvqtYcLJvGb => diOFFmRkeRwDHbobkdHLvXKhmtlA;

	string yBATXoBSRnHIKCFttVvSrbcAKezC.RsQMxqgZDSDzVtlFwLKirMUYRqPG => VlbAsfIhHHuGWdBiHFCWaYywLWmc;

	string yBATXoBSRnHIKCFttVvSrbcAKezC.BCKkerdvYlZwwuEHApOehwylScam => BCXPkoEcSOCkOgTGpgQHbXyJDBSGb;

	string yBATXoBSRnHIKCFttVvSrbcAKezC.xBMIpxAaKDkRBpomErAuGhPXdszl => ufSZknsdcIAbrCiTIWSWxurWZART;

	string yBATXoBSRnHIKCFttVvSrbcAKezC.mfscQpeZvErbobMNlcgwIreELTGMB => vDnagjgiOrRsdsnkvJANbGmyLpjaA;

	int yBATXoBSRnHIKCFttVvSrbcAKezC.WLpfWCwgPbFLaGTzegZdqfSZTzLg => DsxoWPNoGcQWIbZpNUlQdtoEvKYo;

	int yBATXoBSRnHIKCFttVvSrbcAKezC.kkrAAsDIHqyBvwRnPPhPCsbWOpWh => MStlYYBfEcrATaQxTjwooNtwKMMm;

	bool yBATXoBSRnHIKCFttVvSrbcAKezC.UOsRCkLusRFOaQvLUafVGsFIkXzU => pOKeHZIsClHRhdgtAhbguVaFHUjA;

	string yBATXoBSRnHIKCFttVvSrbcAKezC.MTwhczrOWjxUMrNMBtosGjhrMsHd => lghRvarBFLdsFlTQeGmSMKxJvXPB;

	bool yBATXoBSRnHIKCFttVvSrbcAKezC.evvSiiLcMteQjGxxoXvJtnCKttwtA
	{
		get
		{
			if (MStlYYBfEcrATaQxTjwooNtwKMMm >= 0)
			{
				return DsxoWPNoGcQWIbZpNUlQdtoEvKYo >= 0;
			}
			return false;
		}
	}

	bool yBATXoBSRnHIKCFttVvSrbcAKezC.cRndjhBUSBovEjlcZfPmmqfzZQAKA
	{
		get
		{
			return vrNCXHaCigchKadqAfobXksUgfgh;
		}
		set
		{
			if (flag & !vrNCXHaCigchKadqAfobXksUgfgh)
			{
				HSoRxFlSSZrlUrQsFdaEtAvkwfUN.mfLeSmfCqVrXVuCLvCvDXoOsbJts();
			}
			vrNCXHaCigchKadqAfobXksUgfgh = flag;
		}
	}

	event zPRaNdHFpdBLMUFdfputpFbceSLl yBATXoBSRnHIKCFttVvSrbcAKezC.IORvocoGKUjDdFNeDHRamUKaegKaA
	{
		[CompilerGenerated]
		add
		{
			zPRaNdHFpdBLMUFdfputpFbceSLl zPRaNdHFpdBLMUFdfputpFbceSLl2 = DujpSBNnoNkevNYqbrjwsozbDSsc;
			zPRaNdHFpdBLMUFdfputpFbceSLl zPRaNdHFpdBLMUFdfputpFbceSLl3;
			do
			{
				zPRaNdHFpdBLMUFdfputpFbceSLl3 = zPRaNdHFpdBLMUFdfputpFbceSLl2;
				zPRaNdHFpdBLMUFdfputpFbceSLl value2 = (zPRaNdHFpdBLMUFdfputpFbceSLl)Delegate.Combine(zPRaNdHFpdBLMUFdfputpFbceSLl3, b);
				zPRaNdHFpdBLMUFdfputpFbceSLl2 = Interlocked.CompareExchange(ref DujpSBNnoNkevNYqbrjwsozbDSsc, value2, zPRaNdHFpdBLMUFdfputpFbceSLl3);
			}
			while ((object)zPRaNdHFpdBLMUFdfputpFbceSLl2 != zPRaNdHFpdBLMUFdfputpFbceSLl3);
		}
		[CompilerGenerated]
		remove
		{
			zPRaNdHFpdBLMUFdfputpFbceSLl zPRaNdHFpdBLMUFdfputpFbceSLl2 = DujpSBNnoNkevNYqbrjwsozbDSsc;
			zPRaNdHFpdBLMUFdfputpFbceSLl zPRaNdHFpdBLMUFdfputpFbceSLl3;
			do
			{
				zPRaNdHFpdBLMUFdfputpFbceSLl3 = zPRaNdHFpdBLMUFdfputpFbceSLl2;
				zPRaNdHFpdBLMUFdfputpFbceSLl value2 = (zPRaNdHFpdBLMUFdfputpFbceSLl)Delegate.Remove(zPRaNdHFpdBLMUFdfputpFbceSLl3, value3);
				zPRaNdHFpdBLMUFdfputpFbceSLl2 = Interlocked.CompareExchange(ref DujpSBNnoNkevNYqbrjwsozbDSsc, value2, zPRaNdHFpdBLMUFdfputpFbceSLl3);
			}
			while ((object)zPRaNdHFpdBLMUFdfputpFbceSLl2 != zPRaNdHFpdBLMUFdfputpFbceSLl3);
		}
	}

	event eztSqtgTosFYtwpQGKbeoujpVAPU yBATXoBSRnHIKCFttVvSrbcAKezC.SLAcbwFQnSaQugCRTPDvJnOeGPGAb
	{
		[CompilerGenerated]
		add
		{
			eztSqtgTosFYtwpQGKbeoujpVAPU eztSqtgTosFYtwpQGKbeoujpVAPU2 = iIlLhRnEEDLSBesiOpBbYtzIWVuF;
			eztSqtgTosFYtwpQGKbeoujpVAPU eztSqtgTosFYtwpQGKbeoujpVAPU3;
			do
			{
				eztSqtgTosFYtwpQGKbeoujpVAPU3 = eztSqtgTosFYtwpQGKbeoujpVAPU2;
				eztSqtgTosFYtwpQGKbeoujpVAPU value2 = (eztSqtgTosFYtwpQGKbeoujpVAPU)Delegate.Combine(eztSqtgTosFYtwpQGKbeoujpVAPU3, b);
				eztSqtgTosFYtwpQGKbeoujpVAPU2 = Interlocked.CompareExchange(ref iIlLhRnEEDLSBesiOpBbYtzIWVuF, value2, eztSqtgTosFYtwpQGKbeoujpVAPU3);
			}
			while ((object)eztSqtgTosFYtwpQGKbeoujpVAPU2 != eztSqtgTosFYtwpQGKbeoujpVAPU3);
		}
		[CompilerGenerated]
		remove
		{
			eztSqtgTosFYtwpQGKbeoujpVAPU eztSqtgTosFYtwpQGKbeoujpVAPU2 = iIlLhRnEEDLSBesiOpBbYtzIWVuF;
			eztSqtgTosFYtwpQGKbeoujpVAPU eztSqtgTosFYtwpQGKbeoujpVAPU3;
			do
			{
				eztSqtgTosFYtwpQGKbeoujpVAPU3 = eztSqtgTosFYtwpQGKbeoujpVAPU2;
				eztSqtgTosFYtwpQGKbeoujpVAPU value2 = (eztSqtgTosFYtwpQGKbeoujpVAPU)Delegate.Remove(eztSqtgTosFYtwpQGKbeoujpVAPU3, value3);
				eztSqtgTosFYtwpQGKbeoujpVAPU2 = Interlocked.CompareExchange(ref iIlLhRnEEDLSBesiOpBbYtzIWVuF, value2, eztSqtgTosFYtwpQGKbeoujpVAPU3);
			}
			while ((object)eztSqtgTosFYtwpQGKbeoujpVAPU2 != eztSqtgTosFYtwpQGKbeoujpVAPU3);
		}
	}

	[CustomObfuscation(rename = false)]
	private SIYuejvQjndRFJfAYGpZwmWjVrTh()
	{
		SoNDdHkJOMHxgzCoccZnIuhBTWTC = ObjectInstanceTracker.Default.Register(this);
		jTwilfqbvezjcCQcEDaJNApcbvEZ = new global::cIJgGCEhUppLKdHxZeqoRkTiKnWb<edmPFVQXZAgSMnagypaqNIebBPiI.yIAkmGDKNBTAeODUKEvafjOatpYwA>();
		SDTfVsFcrgrDNDDxyLVnObljqsoM = new global::cIJgGCEhUppLKdHxZeqoRkTiKnWb<edmPFVQXZAgSMnagypaqNIebBPiI.JwgIOxgNqXCCHDLDRRLKxPiwnlfS>();
	}

	[CustomObfuscation(rename = false)]
	internal SIYuejvQjndRFJfAYGpZwmWjVrTh(string P_0, string P_1, string P_2, string P_3, int P_4, int P_5, bool P_6, string P_7)
		: this()
	{
		HSoRxFlSSZrlUrQsFdaEtAvkwfUN = new vyDFwzhvWXCEDIBYFQszqfEDCyGcA(this);
		HSoRxFlSSZrlUrQsFdaEtAvkwfUN.gowSaKfLYbhaFbJCfYMPfswNTTTHA += mTrxlhGsSWLKvjSESOFLFyaiayNq;
		HSoRxFlSSZrlUrQsFdaEtAvkwfUN.hPiyagTkxoCeXxJOgBfGBsVUdhCzA += thAkJSqnceiwYKGipcVvOVHbIUei;
		VlbAsfIhHHuGWdBiHFCWaYywLWmc = P_0;
		BCXPkoEcSOCkOgTGpgQHbXyJDBSGb = isCygitBHPQRrMjESfQLjRwkTPGNA.TldUsuGQbBmoJvOLgIqpoURbHFHl(P_0);
		ufSZknsdcIAbrCiTIWSWxurWZART = P_1;
		IHPzEJqIbRbNEelzVMDXNbCTDTkxA = StringTools.SanitizeDeviceString(P_2);
		vDnagjgiOrRsdsnkvJANbGmyLpjaA = StringTools.SanitizeDeviceString(P_3);
		DsxoWPNoGcQWIbZpNUlQdtoEvKYo = P_4;
		MStlYYBfEcrATaQxTjwooNtwKMMm = P_5;
		pOKeHZIsClHRhdgtAhbguVaFHUjA = P_6;
		lghRvarBFLdsFlTQeGmSMKxJvXPB = StringTools.SanitizeDeviceString(P_7);
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = KnKRkIbplaylLYnvvutFgSMbPTWI(VlbAsfIhHHuGWdBiHFCWaYywLWmc, LIOErkgsHvGhqXwjItdOcLjLIyGgb, 0u, WGceNqZUWCallKvutomtCgNpMqadA);
			diOFFmRkeRwDHbobkdHLvXKhmtlA = XoNBWaTqeXeDPhdDLFlXnXSpmnSvA(intPtr);
			iKwbvhgrUhHRCYWQaohhIhBwSqeU = tveDIpJoiuaOdgqOkIUnmNInNLWdb(intPtr);
			aldBbhlQogZBdddqxQlPRDZsQCss = LJOVSRioEJXsCwTqQrRkNkzzgODB(intPtr, 0, iKwbvhgrUhHRCYWQaohhIhBwSqeU.ZjVktcRIBuWmIhGUEeliBzgLXyaS);
			EDJXNIYBwHcAVVwOsIstJTdjddydb = YqYowXgSRdfjiyiNyxlbfEjZTvoc(intPtr, 0, iKwbvhgrUhHRCYWQaohhIhBwSqeU.cZQdKKhBZnyWfBRdMhQomfCKrIsM);
			ZxsgpNvFFQdELlTlvHLpYgfgdsUH(intPtr);
			intPtr = IntPtr.Zero;
		}
		catch (Exception ex)
		{
			throw new Exception($"Error querying HID device \"{P_0}\" at location {intPtr}.\nException Message: {ex.Message}\nStack Trace: {ex.StackTrace}", ex);
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				try
				{
					ZxsgpNvFFQdELlTlvHLpYgfgdsUH(intPtr);
				}
				catch
				{
				}
			}
		}
	}

	private SIYuejvQjndRFJfAYGpZwmWjVrTh(ZIQGfvvtwXgDvGscqSxZnSMsIetv P_0, vTaEkysGrJbjIGXiCYzkVFcdegGY P_1, IdGKZPGlBMdjGcVcHUAhCeMTbpNDA[] P_2, nyKEGqIoaJkcvwlUxeRaXWfkcuizA[] P_3)
		: this()
	{
		string text = "SIMULATED DEVICE";
		string text2 = "MANUFACTURER";
		string text3 = "SIMULATED";
		string text4 = "SIMULATED";
		VlbAsfIhHHuGWdBiHFCWaYywLWmc = text3;
		BCXPkoEcSOCkOgTGpgQHbXyJDBSGb = isCygitBHPQRrMjESfQLjRwkTPGNA.TldUsuGQbBmoJvOLgIqpoURbHFHl(text3);
		ufSZknsdcIAbrCiTIWSWxurWZART = text4;
		IHPzEJqIbRbNEelzVMDXNbCTDTkxA = StringTools.SanitizeDeviceString(text);
		vDnagjgiOrRsdsnkvJANbGmyLpjaA = StringTools.SanitizeDeviceString(text2);
		DsxoWPNoGcQWIbZpNUlQdtoEvKYo = 0;
		MStlYYBfEcrATaQxTjwooNtwKMMm = 0;
		pOKeHZIsClHRhdgtAhbguVaFHUjA = false;
		lghRvarBFLdsFlTQeGmSMKxJvXPB = StringTools.SanitizeDeviceString(text);
		diOFFmRkeRwDHbobkdHLvXKhmtlA = P_0;
		iKwbvhgrUhHRCYWQaohhIhBwSqeU = P_1;
		aldBbhlQogZBdddqxQlPRDZsQCss = P_2;
		EDJXNIYBwHcAVVwOsIstJTdjddydb = P_3;
	}

	public bool nhRtoSUpvOWcOMbHlKyThqeFQozC(bool P_0, KRlBBVNENHhjaxVLrSwqLDZMBPEO P_1, bool P_2, KRlBBVNENHhjaxVLrSwqLDZMBPEO P_3, VQXgTjBnGHNJmJPzKCMciSKedVQMc P_4)
	{
		using (LqDqMlfSnIblEMLnHgbARpubUtCS.Lock())
		{
			using (oSobtejrOAABDHFnzPEYrATvqunE.Lock())
			{
				if (!P_0 && !P_2)
				{
					jqyBGflKbUaCKBxXhvhHUVjkZjzv();
					return false;
				}
				if (ydNyOdgSAXDdrlCnVcQBKGlVsXRSA != qixPgHqeAIfnDNnwggJUwnoyHIcE.Closed)
				{
					if ((ydNyOdgSAXDdrlCnVcQBKGlVsXRSA & qixPgHqeAIfnDNnwggJUwnoyHIcE.Read) != 0 == P_0 && (ydNyOdgSAXDdrlCnVcQBKGlVsXRSA & qixPgHqeAIfnDNnwggJUwnoyHIcE.Write) != 0 == P_2 && LIOErkgsHvGhqXwjItdOcLjLIyGgb == P_1 && kcBGzDTgxHCFRYIiurLLEComqnLp == P_3 && WGceNqZUWCallKvutomtCgNpMqadA == P_4)
					{
						return true;
					}
					jqyBGflKbUaCKBxXhvhHUVjkZjzv();
				}
				LIOErkgsHvGhqXwjItdOcLjLIyGgb = P_1;
				kcBGzDTgxHCFRYIiurLLEComqnLp = P_3;
				WGceNqZUWCallKvutomtCgNpMqadA = P_4;
				if (P_0)
				{
					try
					{
						YbLwYOdytdciykhyeFJYiypmYGfq = KnKRkIbplaylLYnvvutFgSMbPTWI(VlbAsfIhHHuGWdBiHFCWaYywLWmc, P_1, 2147483648u, P_4);
						if ((int)YbLwYOdytdciykhyeFJYiypmYGfq.ToInt64() == -1)
						{
							YbLwYOdytdciykhyeFJYiypmYGfq = IntPtr.Zero;
							throw new Exception("Invalid File Handle");
						}
						ydNyOdgSAXDdrlCnVcQBKGlVsXRSA |= qixPgHqeAIfnDNnwggJUwnoyHIcE.Read;
					}
					catch (Exception innerException)
					{
						ydNyOdgSAXDdrlCnVcQBKGlVsXRSA &= (qixPgHqeAIfnDNnwggJUwnoyHIcE)(-2);
						jqyBGflKbUaCKBxXhvhHUVjkZjzv();
						throw new Exception("Error opening HID device for reading.", innerException);
					}
				}
				if (P_2)
				{
					try
					{
						lsSpcuSVuhmvSRPjyQeIPkZoqkTI = KnKRkIbplaylLYnvvutFgSMbPTWI(VlbAsfIhHHuGWdBiHFCWaYywLWmc, P_3, 1073741824u, P_4);
						if ((int)lsSpcuSVuhmvSRPjyQeIPkZoqkTI.ToInt64() == -1)
						{
							lsSpcuSVuhmvSRPjyQeIPkZoqkTI = IntPtr.Zero;
							throw new Exception("Invalid File Handle");
						}
						ydNyOdgSAXDdrlCnVcQBKGlVsXRSA |= qixPgHqeAIfnDNnwggJUwnoyHIcE.Write;
					}
					catch (Exception innerException2)
					{
						ydNyOdgSAXDdrlCnVcQBKGlVsXRSA &= (qixPgHqeAIfnDNnwggJUwnoyHIcE)(-3);
						jqyBGflKbUaCKBxXhvhHUVjkZjzv();
						throw new Exception("Error opening HID device for writing.", innerException2);
					}
				}
				return true;
			}
		}
	}

	bool yBATXoBSRnHIKCFttVvSrbcAKezC.MUXkERhkEpNXOQoqzrlOSMtjIFNf(bool P_0, KRlBBVNENHhjaxVLrSwqLDZMBPEO P_1, bool P_2, KRlBBVNENHhjaxVLrSwqLDZMBPEO P_3, VQXgTjBnGHNJmJPzKCMciSKedVQMc P_4)
	{
		//ILSpy generated this explicit interface implementation from .override directive in nhRtoSUpvOWcOMbHlKyThqeFQozC
		return this.nhRtoSUpvOWcOMbHlKyThqeFQozC(P_0, P_1, P_2, P_3, P_4);
	}

	public void VxLAopHEqaQYDOHsNwAdWJCAcIYJ()
	{
		using (LqDqMlfSnIblEMLnHgbARpubUtCS.Lock())
		{
			using (oSobtejrOAABDHFnzPEYrATvqunE.Lock())
			{
				jqyBGflKbUaCKBxXhvhHUVjkZjzv();
			}
		}
	}

	void yBATXoBSRnHIKCFttVvSrbcAKezC.pBAxwVeaUHRreKXxJGkZMZlMLarT()
	{
		//ILSpy generated this explicit interface implementation from .override directive in VxLAopHEqaQYDOHsNwAdWJCAcIYJ
		this.VxLAopHEqaQYDOHsNwAdWJCAcIYJ();
	}

	private void jqyBGflKbUaCKBxXhvhHUVjkZjzv()
	{
		if (ydNyOdgSAXDdrlCnVcQBKGlVsXRSA != qixPgHqeAIfnDNnwggJUwnoyHIcE.Closed)
		{
			if (YbLwYOdytdciykhyeFJYiypmYGfq != IntPtr.Zero)
			{
				ZxsgpNvFFQdELlTlvHLpYgfgdsUH(YbLwYOdytdciykhyeFJYiypmYGfq);
				YbLwYOdytdciykhyeFJYiypmYGfq = IntPtr.Zero;
			}
			if (lsSpcuSVuhmvSRPjyQeIPkZoqkTI != IntPtr.Zero)
			{
				ZxsgpNvFFQdELlTlvHLpYgfgdsUH(lsSpcuSVuhmvSRPjyQeIPkZoqkTI);
				lsSpcuSVuhmvSRPjyQeIPkZoqkTI = IntPtr.Zero;
			}
			ydNyOdgSAXDdrlCnVcQBKGlVsXRSA = qixPgHqeAIfnDNnwggJUwnoyHIcE.Closed;
		}
	}

	public kVithYYhMeLfekTMwHMRdNImqONf BuBQCZvMQiZTMyXwKUkNdKebootE()
	{
		return NfIuVLVFjQbOZTsQvBMAfJPLMSal(0);
	}

	kVithYYhMeLfekTMwHMRdNImqONf yBATXoBSRnHIKCFttVvSrbcAKezC.JSmuXjoPzcVSqGgPkhlxhXeKiGZv()
	{
		//ILSpy generated this explicit interface implementation from .override directive in BuBQCZvMQiZTMyXwKUkNdKebootE
		return this.BuBQCZvMQiZTMyXwKUkNdKebootE();
	}

	public kVithYYhMeLfekTMwHMRdNImqONf NfIuVLVFjQbOZTsQvBMAfJPLMSal(int P_0)
	{
		kVithYYhMeLfekTMwHMRdNImqONf kVithYYhMeLfekTMwHMRdNImqONf2 = new kVithYYhMeLfekTMwHMRdNImqONf(xwtSNCMlFemaubnxTEsldtbrUZyM(), kVithYYhMeLfekTMwHMRdNImqONf.sBLoYjvVRqtuQpjsjyQjeqgXtDov.NoDataRead);
		gmtWpVFITYexysMMMyVQdkBbvucg(kVithYYhMeLfekTMwHMRdNImqONf2, P_0);
		return kVithYYhMeLfekTMwHMRdNImqONf2;
	}

	kVithYYhMeLfekTMwHMRdNImqONf yBATXoBSRnHIKCFttVvSrbcAKezC.ENuTVdqjqTflqBYZDWDpjBrEiVFM(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in NfIuVLVFjQbOZTsQvBMAfJPLMSal
		return this.NfIuVLVFjQbOZTsQvBMAfJPLMSal(P_0);
	}

	public unsafe bool gmtWpVFITYexysMMMyVQdkBbvucg(kVithYYhMeLfekTMwHMRdNImqONf P_0, int P_1)
	{
		try
		{
			byte[] array = P_0.iKbsEcTHWqeSBhuCfAXYWgQhKUZeb;
			fixed (byte* ptr = array)
			{
				kVithYYhMeLfekTMwHMRdNImqONf.sBLoYjvVRqtuQpjsjyQjeqgXtDov sBLoYjvVRqtuQpjsjyQjeqgXtDov;
				return AGfSxEjldgPBVmIXOSLPovNEeQwL((IntPtr)ptr, array.Length, P_1, out sBLoYjvVRqtuQpjsjyQjeqgXtDov) == dZPfwnlJZNgPMFFwapjBnSzCVBDgA.Success;
			}
		}
		catch (Exception)
		{
			P_0.rTmaoUdPTqPtKETJYaNcVCBdGTTyA(P_0.iKbsEcTHWqeSBhuCfAXYWgQhKUZeb, kVithYYhMeLfekTMwHMRdNImqONf.sBLoYjvVRqtuQpjsjyQjeqgXtDov.ReadError);
			return false;
		}
	}

	bool yBATXoBSRnHIKCFttVvSrbcAKezC.VWEOmgOuoqBXgBdBPkSUczCSuaNF(kVithYYhMeLfekTMwHMRdNImqONf P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in gmtWpVFITYexysMMMyVQdkBbvucg
		return this.gmtWpVFITYexysMMMyVQdkBbvucg(P_0, P_1);
	}

	public bool chPecHmjRWjAQRDgqoXVpOIdNbsl(out byte[] P_0, int P_1, byte P_2 = 0)
	{
		if (P_1 <= 0)
		{
			P_0 = EmptyObjects<byte>.array;
			return false;
		}
		using (LqDqMlfSnIblEMLnHgbARpubUtCS.Lock())
		{
			if ((ydNyOdgSAXDdrlCnVcQBKGlVsXRSA & qixPgHqeAIfnDNnwggJUwnoyHIcE.Read) == 0)
			{
				P_0 = EmptyObjects<byte>.array;
				return false;
			}
			P_0 = new byte[P_1];
			byte[] array = lzGeJBQCxMDgEcrtgPodiMDmQWZj(P_1);
			array[0] = P_2;
			bool flag = false;
			try
			{
				flag = edmPFVQXZAgSMnagypaqNIebBPiI.WZAzADiExwGFuJaHRcdPAYmaLOlbc(YbLwYOdytdciykhyeFJYiypmYGfq, array, array.Length);
				if (flag)
				{
					Array.Copy(array, 0, P_0, 0, Math.Min(P_0.Length, P_1));
				}
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{VlbAsfIhHHuGWdBiHFCWaYywLWmc}'.", innerException);
			}
			return flag;
		}
	}

	bool yBATXoBSRnHIKCFttVvSrbcAKezC.zQITCFxIAkYmYIFIJJnESxZzaIxg(out byte[] P_0, int P_1, byte P_2 = 0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in chPecHmjRWjAQRDgqoXVpOIdNbsl
		return this.chPecHmjRWjAQRDgqoXVpOIdNbsl(out P_0, P_1, P_2);
	}

	public string UNtCQVIolyBYprmGAUnbpviSAuVQ()
	{
		try
		{
			if (!eDNLINQKvZWQzZqekCtMpBheFJZFA(out var bytes))
			{
				return string.Empty;
			}
			return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
		}
		catch (Exception)
		{
			return string.Empty;
		}
	}

	string yBATXoBSRnHIKCFttVvSrbcAKezC.KBncbmUyuUuggqyiqOLXReBMpKYC()
	{
		//ILSpy generated this explicit interface implementation from .override directive in UNtCQVIolyBYprmGAUnbpviSAuVQ
		return this.UNtCQVIolyBYprmGAUnbpviSAuVQ();
	}

	public unsafe bool eDNLINQKvZWQzZqekCtMpBheFJZFA(out byte[] P_0)
	{
		using (LqDqMlfSnIblEMLnHgbARpubUtCS.Lock())
		{
			if ((ydNyOdgSAXDdrlCnVcQBKGlVsXRSA & qixPgHqeAIfnDNnwggJUwnoyHIcE.Read) == 0)
			{
				P_0 = EmptyObjects<byte>.array;
				return false;
			}
			P_0 = new byte[255];
			bool result = false;
			try
			{
				fixed (byte* ptr = P_0)
				{
					void* ptr2 = ptr;
					result = edmPFVQXZAgSMnagypaqNIebBPiI.RYrEkdGwztDixyHefEPsVrstCSzVA(YbLwYOdytdciykhyeFJYiypmYGfq, (IntPtr)ptr2, P_0.Length);
				}
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{VlbAsfIhHHuGWdBiHFCWaYywLWmc}'.", innerException);
			}
			return result;
		}
	}

	bool yBATXoBSRnHIKCFttVvSrbcAKezC.iddoYMhYJQtvFilYnfKPjJmfcFuV(out byte[] P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in eDNLINQKvZWQzZqekCtMpBheFJZFA
		return this.eDNLINQKvZWQzZqekCtMpBheFJZFA(out P_0);
	}

	public string MTGkGeRzTrrvRgNhbclmglyjpLcab()
	{
		VjCRVjsPjUwZnNeMdnhoyXTQByeF(out var bytes);
		return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
	}

	string yBATXoBSRnHIKCFttVvSrbcAKezC.uBKpZXOtGhosxdINzCJUZYEjpoFK()
	{
		//ILSpy generated this explicit interface implementation from .override directive in MTGkGeRzTrrvRgNhbclmglyjpLcab
		return this.MTGkGeRzTrrvRgNhbclmglyjpLcab();
	}

	public bool VjCRVjsPjUwZnNeMdnhoyXTQByeF(out byte[] P_0)
	{
		using (LqDqMlfSnIblEMLnHgbARpubUtCS.Lock())
		{
			if ((ydNyOdgSAXDdrlCnVcQBKGlVsXRSA & qixPgHqeAIfnDNnwggJUwnoyHIcE.Read) == 0)
			{
				P_0 = EmptyObjects<byte>.array;
				return false;
			}
			P_0 = new byte[255];
			bool flag = false;
			try
			{
				GCHandle gCHandle = GCHandle.Alloc(P_0, GCHandleType.Pinned);
				flag = edmPFVQXZAgSMnagypaqNIebBPiI.YDAUjDjTXXRQqbDNFdQicTpZHWiy(YbLwYOdytdciykhyeFJYiypmYGfq, gCHandle.AddrOfPinnedObject(), P_0.Length);
				GC.KeepAlive(gCHandle);
				gCHandle.Free();
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{VlbAsfIhHHuGWdBiHFCWaYywLWmc}'.", innerException);
			}
			return flag;
		}
	}

	bool yBATXoBSRnHIKCFttVvSrbcAKezC.KIMcYmsBSdApFRQSSAsJBjmNOuNF(out byte[] P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in VjCRVjsPjUwZnNeMdnhoyXTQByeF
		return this.VjCRVjsPjUwZnNeMdnhoyXTQByeF(out P_0);
	}

	public string cBxKjwISXmMqVZHdEckrznvAZCes()
	{
		tqIgWmGQMaQXKZGUoaqICQpCuKvsb(out var bytes);
		return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
	}

	string yBATXoBSRnHIKCFttVvSrbcAKezC.zclQeZKkczjwAACdBcgpzBrhKJjb()
	{
		//ILSpy generated this explicit interface implementation from .override directive in cBxKjwISXmMqVZHdEckrznvAZCes
		return this.cBxKjwISXmMqVZHdEckrznvAZCes();
	}

	public bool tqIgWmGQMaQXKZGUoaqICQpCuKvsb(out byte[] P_0)
	{
		using (LqDqMlfSnIblEMLnHgbARpubUtCS.Lock())
		{
			if ((ydNyOdgSAXDdrlCnVcQBKGlVsXRSA & qixPgHqeAIfnDNnwggJUwnoyHIcE.Read) == 0)
			{
				P_0 = EmptyObjects<byte>.array;
				return false;
			}
			bool flag = false;
			try
			{
				flag = bhYzQSwJwRZWsnDfcEkeDfORsnpdA(YbLwYOdytdciykhyeFJYiypmYGfq, out P_0);
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{VlbAsfIhHHuGWdBiHFCWaYywLWmc}'.", innerException);
			}
			return flag;
		}
	}

	bool yBATXoBSRnHIKCFttVvSrbcAKezC.ikHgbPDqGpXLbvSUFSkPzdWMEABEA(out byte[] P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in tqIgWmGQMaQXKZGUoaqICQpCuKvsb
		return this.tqIgWmGQMaQXKZGUoaqICQpCuKvsb(out P_0);
	}

	public string tWIgVAbyJddzXFutzfxugtiaGChLb()
	{
		VILGPaitSrYRnzsxRJdkOCMomeDX(out var bytes);
		return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
	}

	string yBATXoBSRnHIKCFttVvSrbcAKezC.GlrLNbBccFGjqzxqFdXwHzCixTMX()
	{
		//ILSpy generated this explicit interface implementation from .override directive in tWIgVAbyJddzXFutzfxugtiaGChLb
		return this.tWIgVAbyJddzXFutzfxugtiaGChLb();
	}

	public bool VILGPaitSrYRnzsxRJdkOCMomeDX(out byte[] P_0)
	{
		using (LqDqMlfSnIblEMLnHgbARpubUtCS.Lock())
		{
			if ((ydNyOdgSAXDdrlCnVcQBKGlVsXRSA & qixPgHqeAIfnDNnwggJUwnoyHIcE.Read) == 0)
			{
				P_0 = EmptyObjects<byte>.array;
				return false;
			}
			P_0 = new byte[255];
			bool flag = false;
			try
			{
				GCHandle gCHandle = GCHandle.Alloc(P_0, GCHandleType.Pinned);
				flag = edmPFVQXZAgSMnagypaqNIebBPiI.stOCknsPoRkziPTRKFsXgfQWrEMC(YbLwYOdytdciykhyeFJYiypmYGfq, gCHandle.AddrOfPinnedObject(), (uint)P_0.Length);
				GC.KeepAlive(gCHandle);
				gCHandle.Free();
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{VlbAsfIhHHuGWdBiHFCWaYywLWmc}'.", innerException);
			}
			return flag;
		}
	}

	bool yBATXoBSRnHIKCFttVvSrbcAKezC.cDCtIIVcVWzBdligTwaXGtPEEeOC(out byte[] P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in VILGPaitSrYRnzsxRJdkOCMomeDX
		return this.VILGPaitSrYRnzsxRJdkOCMomeDX(out P_0);
	}

	public bool dQYZOESKtcmYjlOLGMIaNAuwTHYq(byte[] P_0)
	{
		return luWOwVTklEutFgBAWfpABxLnhLaO(P_0, 0);
	}

	bool yBATXoBSRnHIKCFttVvSrbcAKezC.ivGyaGZzqxXoHlzHFRcVglvsUPhA(byte[] P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in dQYZOESKtcmYjlOLGMIaNAuwTHYq
		return this.dQYZOESKtcmYjlOLGMIaNAuwTHYq(P_0);
	}

	public unsafe bool luWOwVTklEutFgBAWfpABxLnhLaO(byte[] P_0, int P_1)
	{
		fixed (byte* ptr = P_0)
		{
			return laWFzAuHZAAifBabjoNiiOpfzKItb((IntPtr)ptr, P_0.Length, P_1, eKiggKxGFedvgdyyrDINBkJifCvqB.None, false);
		}
	}

	bool yBATXoBSRnHIKCFttVvSrbcAKezC.GZEDNmomafFMTIiRpwEjxwDPCXogA(byte[] P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in luWOwVTklEutFgBAWfpABxLnhLaO
		return this.luWOwVTklEutFgBAWfpABxLnhLaO(P_0, P_1);
	}

	public bool ZCDQYJZAISIvWaPRZuULJgWGIacJ(IntPtr P_0, int P_1, int P_2, eKiggKxGFedvgdyyrDINBkJifCvqB P_3)
	{
		return laWFzAuHZAAifBabjoNiiOpfzKItb(P_0, P_1, P_2, P_3, true);
	}

	public bool DZDbyNiZRGdjJeVdTLSNSGaotBMSA(svXcjurRenDjMJrGFPPkrmozhhdx P_0, int P_1)
	{
		return ZCDQYJZAISIvWaPRZuULJgWGIacJ(P_0.yKnTPoXWkVqXWlhtccdKjeEFJtST, P_0.ERwKsEbMnPafsEWrYjGCkGlIkCDmA, P_1, P_0.troAmoGhctcOyAOTedaJVtjAjwrMc);
	}

	bool yBATXoBSRnHIKCFttVvSrbcAKezC.bdGjiVUMEIWtoiHmlIHNRTZkrTvJ(svXcjurRenDjMJrGFPPkrmozhhdx P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in DZDbyNiZRGdjJeVdTLSNSGaotBMSA
		return this.DZDbyNiZRGdjJeVdTLSNSGaotBMSA(P_0, P_1);
	}

	public FBeIUTFrlhTJFSAsreiwBOJDNwHNb XATWrKGazpaeTHjsoTgOQlputejvA()
	{
		return new FBeIUTFrlhTJFSAsreiwBOJDNwHNb(((yBATXoBSRnHIKCFttVvSrbcAKezC)this).YYzFmtrEAtiRNtPjhZbbbhzJBxoo.fMIUAbMNkghlJOGkRpnCCmzsCXIaA);
	}

	FBeIUTFrlhTJFSAsreiwBOJDNwHNb yBATXoBSRnHIKCFttVvSrbcAKezC.WpaDjShPHGAadJcFRKWNMkkbRdsDA()
	{
		//ILSpy generated this explicit interface implementation from .override directive in XATWrKGazpaeTHjsoTgOQlputejvA
		return this.XATWrKGazpaeTHjsoTgOQlputejvA();
	}

	public bool WgHDyKCmMYPfVlWvFnvcSSFrViGt(byte[] P_0, int P_1)
	{
		using (oSobtejrOAABDHFnzPEYrATvqunE.Lock())
		{
			if ((ydNyOdgSAXDdrlCnVcQBKGlVsXRSA & qixPgHqeAIfnDNnwggJUwnoyHIcE.Write) == 0)
			{
				return false;
			}
			if (iKwbvhgrUhHRCYWQaohhIhBwSqeU.OGZvOUpmMtFvUuHREKJpovBZOkrW <= 0)
			{
				return false;
			}
			byte[] array = lzGeJBQCxMDgEcrtgPodiMDmQWZj(P_1);
			Array.Copy(P_0, 0, array, 0, Math.Min(P_0.Length, P_1));
			try
			{
				return edmPFVQXZAgSMnagypaqNIebBPiI.LvqqdHviCvgQGgNASDcOOEQQxheG(lsSpcuSVuhmvSRPjyQeIPkZoqkTI, array, P_1);
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{VlbAsfIhHHuGWdBiHFCWaYywLWmc}'.", innerException);
			}
		}
	}

	bool yBATXoBSRnHIKCFttVvSrbcAKezC.NlsFPRahIpczBEDnOKdMZrIunQytA(byte[] P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in WgHDyKCmMYPfVlWvFnvcSSFrViGt
		return this.WgHDyKCmMYPfVlWvFnvcSSFrViGt(P_0, P_1);
	}

	private byte[] xwtSNCMlFemaubnxTEsldtbrUZyM()
	{
		return HpHGKXoOwBbrayIMriiBdqUMMYus(((yBATXoBSRnHIKCFttVvSrbcAKezC)this).YYzFmtrEAtiRNtPjhZbbbhzJBxoo.rNXCubcSOYfjuHNeilTiGfvgXoFCc - 1);
	}

	private byte[] IMqadNaIFKDBsnJmRQzRuLvzRiDe()
	{
		return HpHGKXoOwBbrayIMriiBdqUMMYus(((yBATXoBSRnHIKCFttVvSrbcAKezC)this).YYzFmtrEAtiRNtPjhZbbbhzJBxoo.fMIUAbMNkghlJOGkRpnCCmzsCXIaA - 1);
	}

	private static byte[] lzGeJBQCxMDgEcrtgPodiMDmQWZj(int P_0)
	{
		return HpHGKXoOwBbrayIMriiBdqUMMYus(P_0 - 1);
	}

	private unsafe kVithYYhMeLfekTMwHMRdNImqONf fJBkSxAochqOwyCEaFXWOrLZiDiq(int P_0)
	{
		byte[] array = xwtSNCMlFemaubnxTEsldtbrUZyM();
		kVithYYhMeLfekTMwHMRdNImqONf.sBLoYjvVRqtuQpjsjyQjeqgXtDov sBLoYjvVRqtuQpjsjyQjeqgXtDov;
		fixed (byte* ptr = array)
		{
			AGfSxEjldgPBVmIXOSLPovNEeQwL((IntPtr)ptr, array.Length, P_0, out sBLoYjvVRqtuQpjsjyQjeqgXtDov);
		}
		return new kVithYYhMeLfekTMwHMRdNImqONf(array, sBLoYjvVRqtuQpjsjyQjeqgXtDov);
	}

	private dZPfwnlJZNgPMFFwapjBnSzCVBDgA AGfSxEjldgPBVmIXOSLPovNEeQwL(IntPtr P_0, int P_1, int P_2, out kVithYYhMeLfekTMwHMRdNImqONf.sBLoYjvVRqtuQpjsjyQjeqgXtDov P_3)
	{
		using (LqDqMlfSnIblEMLnHgbARpubUtCS.Lock())
		{
			if ((ydNyOdgSAXDdrlCnVcQBKGlVsXRSA & qixPgHqeAIfnDNnwggJUwnoyHIcE.Read) == 0)
			{
				P_3 = kVithYYhMeLfekTMwHMRdNImqONf.sBLoYjvVRqtuQpjsjyQjeqgXtDov.NotConnected;
				return dZPfwnlJZNgPMFFwapjBnSzCVBDgA.DeviceNotOpen;
			}
			P_3 = kVithYYhMeLfekTMwHMRdNImqONf.sBLoYjvVRqtuQpjsjyQjeqgXtDov.NoDataRead;
			if (P_0 == IntPtr.Zero || P_1 < ((yBATXoBSRnHIKCFttVvSrbcAKezC)this).YYzFmtrEAtiRNtPjhZbbbhzJBxoo.rNXCubcSOYfjuHNeilTiGfvgXoFCc)
			{
				return dZPfwnlJZNgPMFFwapjBnSzCVBDgA.BufferTooSmall;
			}
			if (iKwbvhgrUhHRCYWQaohhIhBwSqeU.rNXCubcSOYfjuHNeilTiGfvgXoFCc > 0)
			{
				uint num = 0u;
				if (LIOErkgsHvGhqXwjItdOcLjLIyGgb == KRlBBVNENHhjaxVLrSwqLDZMBPEO.Overlapped)
				{
					int num2 = ((P_2 <= 0) ? 65535 : P_2);
					edmPFVQXZAgSMnagypaqNIebBPiI.JwgIOxgNqXCCHDLDRRLKxPiwnlfS jwgIOxgNqXCCHDLDRRLKxPiwnlfS = new edmPFVQXZAgSMnagypaqNIebBPiI.JwgIOxgNqXCCHDLDRRLKxPiwnlfS
					{
						uxNbLzYSELHDNrhiSgCZNIgvaGpw = IntPtr.Zero,
						zAyFhZmCnKNOtUYxjmyvdZNOWwIO = true,
						lVKNgfdnvooThauNKoHqFzpxVJJs = edmPFVQXZAgSMnagypaqNIebBPiI.JwgIOxgNqXCCHDLDRRLKxPiwnlfS.JlVTkHOYlNWsXpgsjJQgOZPwDPQS
					};
					SDTfVsFcrgrDNDDxyLVnObljqsoM.QkYCmYRuXflOvGNGbdVbrlDqToex = jwgIOxgNqXCCHDLDRRLKxPiwnlfS;
					IntPtr intPtr = edmPFVQXZAgSMnagypaqNIebBPiI.qWuCAmBCuXNnzyqBumkHdydYqDxjb(TLjofzBmfBMLdKYQRjtOpIYGxOeK.fKTDPQTczycLwwypUVKnJloxAtvd(SDTfVsFcrgrDNDDxyLVnObljqsoM.oJsyFKLPSMlekgCzKCXFHmehEQXpA), 0, 1, IntPtr.Zero);
					if (intPtr == IntPtr.Zero)
					{
						return dZPfwnlJZNgPMFFwapjBnSzCVBDgA.ReadError;
					}
					edmPFVQXZAgSMnagypaqNIebBPiI.yIAkmGDKNBTAeODUKEvafjOatpYwA yIAkmGDKNBTAeODUKEvafjOatpYwA = new edmPFVQXZAgSMnagypaqNIebBPiI.yIAkmGDKNBTAeODUKEvafjOatpYwA
					{
						zNJoUDXobzeELMxatlkCmCGEatUeA = 0,
						oQrUHEsVKCgCtlSJAjXGETimnyMg = 0,
						hRNCKQafqMcZywIuKByzzVZhElRt = intPtr
					};
					jTwilfqbvezjcCQcEDaJNApcbvEZ.QkYCmYRuXflOvGNGbdVbrlDqToex = yIAkmGDKNBTAeODUKEvafjOatpYwA;
					try
					{
						if (edmPFVQXZAgSMnagypaqNIebBPiI.DKslJOXQKfDPsdlUDeWqJfrzIIpW(YbLwYOdytdciykhyeFJYiypmYGfq, P_0, (uint)P_1, out num, TLjofzBmfBMLdKYQRjtOpIYGxOeK.fKTDPQTczycLwwypUVKnJloxAtvd(jTwilfqbvezjcCQcEDaJNApcbvEZ.oJsyFKLPSMlekgCzKCXFHmehEQXpA)))
						{
							P_3 = kVithYYhMeLfekTMwHMRdNImqONf.sBLoYjvVRqtuQpjsjyQjeqgXtDov.Success;
						}
						else if ((long)Marshal.GetLastWin32Error() == 997)
						{
							switch (edmPFVQXZAgSMnagypaqNIebBPiI.LOlbodJrRQxrHNhrxbJoBpOzBOjib(jTwilfqbvezjcCQcEDaJNApcbvEZ.QkYCmYRuXflOvGNGbdVbrlDqToex.hRNCKQafqMcZywIuKByzzVZhElRt, num2))
							{
							case 0u:
							case 192u:
								if (AmOfVgHMXtIpYGmFoUHcniSRkMulA.lDAVdcsTDpACUdXioTQJHSOSUzXE(YbLwYOdytdciykhyeFJYiypmYGfq, TLjofzBmfBMLdKYQRjtOpIYGxOeK.fKTDPQTczycLwwypUVKnJloxAtvd(jTwilfqbvezjcCQcEDaJNApcbvEZ.oJsyFKLPSMlekgCzKCXFHmehEQXpA), out num, false))
								{
									if (num != 0)
									{
										P_3 = kVithYYhMeLfekTMwHMRdNImqONf.sBLoYjvVRqtuQpjsjyQjeqgXtDov.Success;
									}
									else
									{
										P_3 = kVithYYhMeLfekTMwHMRdNImqONf.sBLoYjvVRqtuQpjsjyQjeqgXtDov.NoDataRead;
									}
								}
								else
								{
									P_3 = kVithYYhMeLfekTMwHMRdNImqONf.sBLoYjvVRqtuQpjsjyQjeqgXtDov.ReadError;
								}
								break;
							case 258u:
								P_3 = kVithYYhMeLfekTMwHMRdNImqONf.sBLoYjvVRqtuQpjsjyQjeqgXtDov.WaitTimedOut;
								break;
							case uint.MaxValue:
								P_3 = kVithYYhMeLfekTMwHMRdNImqONf.sBLoYjvVRqtuQpjsjyQjeqgXtDov.WaitFail;
								break;
							case 128u:
								P_3 = kVithYYhMeLfekTMwHMRdNImqONf.sBLoYjvVRqtuQpjsjyQjeqgXtDov.WaitAbandoned;
								break;
							default:
								P_3 = kVithYYhMeLfekTMwHMRdNImqONf.sBLoYjvVRqtuQpjsjyQjeqgXtDov.NoDataRead;
								break;
							}
						}
						else
						{
							P_3 = kVithYYhMeLfekTMwHMRdNImqONf.sBLoYjvVRqtuQpjsjyQjeqgXtDov.ReadError;
						}
					}
					catch
					{
						P_3 = kVithYYhMeLfekTMwHMRdNImqONf.sBLoYjvVRqtuQpjsjyQjeqgXtDov.ReadError;
					}
					finally
					{
						edmPFVQXZAgSMnagypaqNIebBPiI.cnriKgJSvbMBwweLDHAiOCjIABbfA(YbLwYOdytdciykhyeFJYiypmYGfq);
						IntPtr hRNCKQafqMcZywIuKByzzVZhElRt = jTwilfqbvezjcCQcEDaJNApcbvEZ.QkYCmYRuXflOvGNGbdVbrlDqToex.hRNCKQafqMcZywIuKByzzVZhElRt;
						if (hRNCKQafqMcZywIuKByzzVZhElRt != IntPtr.Zero)
						{
							qFcohiQnPEYzFSQaSrJhiNUDKeYr(hRNCKQafqMcZywIuKByzzVZhElRt);
						}
					}
				}
				else
				{
					try
					{
						if (edmPFVQXZAgSMnagypaqNIebBPiI.DKslJOXQKfDPsdlUDeWqJfrzIIpW(YbLwYOdytdciykhyeFJYiypmYGfq, P_0, (uint)P_1, out num, IntPtr.Zero))
						{
							P_3 = kVithYYhMeLfekTMwHMRdNImqONf.sBLoYjvVRqtuQpjsjyQjeqgXtDov.Success;
						}
						else
						{
							P_3 = kVithYYhMeLfekTMwHMRdNImqONf.sBLoYjvVRqtuQpjsjyQjeqgXtDov.Success;
							P_3 = kVithYYhMeLfekTMwHMRdNImqONf.sBLoYjvVRqtuQpjsjyQjeqgXtDov.ReadError;
						}
					}
					catch
					{
						P_3 = kVithYYhMeLfekTMwHMRdNImqONf.sBLoYjvVRqtuQpjsjyQjeqgXtDov.ReadError;
					}
				}
			}
			return (P_3 != kVithYYhMeLfekTMwHMRdNImqONf.sBLoYjvVRqtuQpjsjyQjeqgXtDov.Success) ? dZPfwnlJZNgPMFFwapjBnSzCVBDgA.ReadError : dZPfwnlJZNgPMFFwapjBnSzCVBDgA.Success;
		}
	}

	private bool laWFzAuHZAAifBabjoNiiOpfzKItb(IntPtr P_0, int P_1, int P_2, eKiggKxGFedvgdyyrDINBkJifCvqB P_3, bool P_4)
	{
		using (oSobtejrOAABDHFnzPEYrATvqunE.Lock())
		{
			if ((ydNyOdgSAXDdrlCnVcQBKGlVsXRSA & qixPgHqeAIfnDNnwggJUwnoyHIcE.Write) == 0)
			{
				return false;
			}
			if (P_0 == IntPtr.Zero || P_1 <= 0)
			{
				return false;
			}
			if (!P_4)
			{
				if (iKwbvhgrUhHRCYWQaohhIhBwSqeU.fMIUAbMNkghlJOGkRpnCCmzsCXIaA <= 0)
				{
					return false;
				}
				P_1 = Math.Min(P_1, iKwbvhgrUhHRCYWQaohhIhBwSqeU.fMIUAbMNkghlJOGkRpnCCmzsCXIaA);
			}
			uint num = 0u;
			if (kcBGzDTgxHCFRYIiurLLEComqnLp == KRlBBVNENHhjaxVLrSwqLDZMBPEO.Overlapped)
			{
				try
				{
					if ((P_3 & eKiggKxGFedvgdyyrDINBkJifCvqB.WriteDirect) != eKiggKxGFedvgdyyrDINBkJifCvqB.None)
					{
						return edmPFVQXZAgSMnagypaqNIebBPiI.RvTRBqkPiaHpEACKBJFOmdJNpJyBb(lsSpcuSVuhmvSRPjyQeIPkZoqkTI, P_0, P_1);
					}
				}
				catch (Exception)
				{
					return false;
				}
				int num2 = ((P_2 <= 0) ? 65535 : P_2);
				edmPFVQXZAgSMnagypaqNIebBPiI.JwgIOxgNqXCCHDLDRRLKxPiwnlfS jwgIOxgNqXCCHDLDRRLKxPiwnlfS = new edmPFVQXZAgSMnagypaqNIebBPiI.JwgIOxgNqXCCHDLDRRLKxPiwnlfS
				{
					uxNbLzYSELHDNrhiSgCZNIgvaGpw = IntPtr.Zero,
					zAyFhZmCnKNOtUYxjmyvdZNOWwIO = true,
					lVKNgfdnvooThauNKoHqFzpxVJJs = edmPFVQXZAgSMnagypaqNIebBPiI.JwgIOxgNqXCCHDLDRRLKxPiwnlfS.JlVTkHOYlNWsXpgsjJQgOZPwDPQS
				};
				SDTfVsFcrgrDNDDxyLVnObljqsoM.QkYCmYRuXflOvGNGbdVbrlDqToex = jwgIOxgNqXCCHDLDRRLKxPiwnlfS;
				IntPtr intPtr = edmPFVQXZAgSMnagypaqNIebBPiI.qWuCAmBCuXNnzyqBumkHdydYqDxjb(TLjofzBmfBMLdKYQRjtOpIYGxOeK.fKTDPQTczycLwwypUVKnJloxAtvd(SDTfVsFcrgrDNDDxyLVnObljqsoM.oJsyFKLPSMlekgCzKCXFHmehEQXpA), 0, 1, IntPtr.Zero);
				if (intPtr == IntPtr.Zero)
				{
					return false;
				}
				edmPFVQXZAgSMnagypaqNIebBPiI.yIAkmGDKNBTAeODUKEvafjOatpYwA yIAkmGDKNBTAeODUKEvafjOatpYwA = new edmPFVQXZAgSMnagypaqNIebBPiI.yIAkmGDKNBTAeODUKEvafjOatpYwA
				{
					zNJoUDXobzeELMxatlkCmCGEatUeA = 0,
					oQrUHEsVKCgCtlSJAjXGETimnyMg = 0,
					hRNCKQafqMcZywIuKByzzVZhElRt = intPtr
				};
				jTwilfqbvezjcCQcEDaJNApcbvEZ.QkYCmYRuXflOvGNGbdVbrlDqToex = yIAkmGDKNBTAeODUKEvafjOatpYwA;
				try
				{
					if (edmPFVQXZAgSMnagypaqNIebBPiI.cGzEJDcnLEjTddesgLKWTzyjltlBb(lsSpcuSVuhmvSRPjyQeIPkZoqkTI, P_0, (uint)P_1, IntPtr.Zero, TLjofzBmfBMLdKYQRjtOpIYGxOeK.fKTDPQTczycLwwypUVKnJloxAtvd(jTwilfqbvezjcCQcEDaJNApcbvEZ.oJsyFKLPSMlekgCzKCXFHmehEQXpA)))
					{
						return true;
					}
					if ((long)Marshal.GetLastWin32Error() == 997)
					{
						switch (edmPFVQXZAgSMnagypaqNIebBPiI.LOlbodJrRQxrHNhrxbJoBpOzBOjib(jTwilfqbvezjcCQcEDaJNApcbvEZ.QkYCmYRuXflOvGNGbdVbrlDqToex.hRNCKQafqMcZywIuKByzzVZhElRt, num2))
						{
						case 0u:
						case 192u:
							if (AmOfVgHMXtIpYGmFoUHcniSRkMulA.lDAVdcsTDpACUdXioTQJHSOSUzXE(lsSpcuSVuhmvSRPjyQeIPkZoqkTI, TLjofzBmfBMLdKYQRjtOpIYGxOeK.fKTDPQTczycLwwypUVKnJloxAtvd(jTwilfqbvezjcCQcEDaJNApcbvEZ.oJsyFKLPSMlekgCzKCXFHmehEQXpA), out num, false))
							{
								return true;
							}
							return false;
						case 258u:
							return false;
						case uint.MaxValue:
							return false;
						case 128u:
							return false;
						default:
							return false;
						}
					}
					return false;
				}
				catch
				{
					return false;
				}
				finally
				{
					edmPFVQXZAgSMnagypaqNIebBPiI.cnriKgJSvbMBwweLDHAiOCjIABbfA(lsSpcuSVuhmvSRPjyQeIPkZoqkTI);
					IntPtr hRNCKQafqMcZywIuKByzzVZhElRt = jTwilfqbvezjcCQcEDaJNApcbvEZ.QkYCmYRuXflOvGNGbdVbrlDqToex.hRNCKQafqMcZywIuKByzzVZhElRt;
					if (hRNCKQafqMcZywIuKByzzVZhElRt != IntPtr.Zero)
					{
						qFcohiQnPEYzFSQaSrJhiNUDKeYr(hRNCKQafqMcZywIuKByzzVZhElRt);
					}
				}
			}
			try
			{
				if ((P_3 & eKiggKxGFedvgdyyrDINBkJifCvqB.WriteDirect) != eKiggKxGFedvgdyyrDINBkJifCvqB.None)
				{
					return edmPFVQXZAgSMnagypaqNIebBPiI.RvTRBqkPiaHpEACKBJFOmdJNpJyBb(lsSpcuSVuhmvSRPjyQeIPkZoqkTI, P_0, P_1);
				}
				return edmPFVQXZAgSMnagypaqNIebBPiI.LCpYOoMOTLrmmvlAwmQjWEZsBBRf(lsSpcuSVuhmvSRPjyQeIPkZoqkTI, P_0, (uint)P_1, out num, IntPtr.Zero);
			}
			catch (Exception)
			{
				return false;
			}
		}
	}

	private void mTrxlhGsSWLKvjSESOFLFyaiayNq()
	{
	}

	private void thAkJSqnceiwYKGipcVvOVHbIUei()
	{
		using (LqDqMlfSnIblEMLnHgbARpubUtCS.Lock())
		{
			using (oSobtejrOAABDHFnzPEYrATvqunE.Lock())
			{
				jqyBGflKbUaCKBxXhvhHUVjkZjzv();
				if (iIlLhRnEEDLSBesiOpBbYtzIWVuF != null)
				{
					iIlLhRnEEDLSBesiOpBbYtzIWVuF();
				}
			}
		}
	}

	public void Dispose()
	{
		vwiEPFScsMLkwLYZhounYfOIvFXm(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected void YInkWrGMBvmNevJTmuNrqAaSNPeL()
	{
		try
		{
			vwiEPFScsMLkwLYZhounYfOIvFXm(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void vwiEPFScsMLkwLYZhounYfOIvFXm(bool P_0)
	{
		if (ZVmnLqaCkaDqheuDleILiVEGukMS)
		{
			return;
		}
		using (LqDqMlfSnIblEMLnHgbARpubUtCS.Lock())
		{
			using (oSobtejrOAABDHFnzPEYrATvqunE.Lock())
			{
				if (((yBATXoBSRnHIKCFttVvSrbcAKezC)this).cRndjhBUSBovEjlcZfPmmqfzZQAKA)
				{
					((yBATXoBSRnHIKCFttVvSrbcAKezC)this).cRndjhBUSBovEjlcZfPmmqfzZQAKA = false;
				}
				if (ydNyOdgSAXDdrlCnVcQBKGlVsXRSA != qixPgHqeAIfnDNnwggJUwnoyHIcE.Closed)
				{
					jqyBGflKbUaCKBxXhvhHUVjkZjzv();
				}
				ObjectInstanceTracker.Default.Unregister(SoNDdHkJOMHxgzCoccZnIuhBTWTC);
				if (jTwilfqbvezjcCQcEDaJNApcbvEZ != null)
				{
					jTwilfqbvezjcCQcEDaJNApcbvEZ.Dispose();
				}
				if (SDTfVsFcrgrDNDDxyLVnObljqsoM != null)
				{
					SDTfVsFcrgrDNDDxyLVnObljqsoM.Dispose();
				}
			}
		}
		ZVmnLqaCkaDqheuDleILiVEGukMS = true;
	}

	public static bool bhYzQSwJwRZWsnDfcEkeDfORsnpdA(IntPtr P_0, out byte[] P_1)
	{
		P_1 = new byte[255];
		_ = string.Empty;
		bool flag = false;
		GCHandle gCHandle = GCHandle.Alloc(P_1, GCHandleType.Pinned);
		try
		{
			flag = edmPFVQXZAgSMnagypaqNIebBPiI.YxhjeBzCadQYFStkmYwqokQvpGnC(P_0, gCHandle.AddrOfPinnedObject(), P_1.Length);
			GC.KeepAlive(gCHandle);
			if (flag)
			{
				StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(P_1));
			}
		}
		catch (Exception innerException)
		{
			throw new Exception($"Error accessing HID device at handle '{P_0}'.", innerException);
		}
		finally
		{
			gCHandle.Free();
		}
		return flag;
	}

	public static string WiGeBFECixVQerIPQYgntjVZSCSM(IntPtr P_0)
	{
		bhYzQSwJwRZWsnDfcEkeDfORsnpdA(P_0, out var bytes);
		return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
	}

	public static bool AvKLjCqjMEhifDeWwVzjPjueUmoPA(IntPtr P_0, IntPtr P_1, int P_2)
	{
		if (P_2 < 255)
		{
			throw new Exception("Buffer length must be at least " + 255 + " bytes!");
		}
		try
		{
			return edmPFVQXZAgSMnagypaqNIebBPiI.YxhjeBzCadQYFStkmYwqokQvpGnC(P_0, P_1, P_2);
		}
		catch (Exception innerException)
		{
			throw new Exception($"Error accessing HID device at handle '{P_0}'.", innerException);
		}
	}

	public static IntPtr KnKRkIbplaylLYnvvutFgSMbPTWI(string P_0, KRlBBVNENHhjaxVLrSwqLDZMBPEO P_1, uint P_2, VQXgTjBnGHNJmJPzKCMciSKedVQMc P_3)
	{
		edmPFVQXZAgSMnagypaqNIebBPiI.JwgIOxgNqXCCHDLDRRLKxPiwnlfS jwgIOxgNqXCCHDLDRRLKxPiwnlfS = default(edmPFVQXZAgSMnagypaqNIebBPiI.JwgIOxgNqXCCHDLDRRLKxPiwnlfS);
		int num = 0;
		if (P_1 == KRlBBVNENHhjaxVLrSwqLDZMBPEO.Overlapped)
		{
			num = 1073741824;
		}
		jwgIOxgNqXCCHDLDRRLKxPiwnlfS.uxNbLzYSELHDNrhiSgCZNIgvaGpw = IntPtr.Zero;
		jwgIOxgNqXCCHDLDRRLKxPiwnlfS.zAyFhZmCnKNOtUYxjmyvdZNOWwIO = true;
		jwgIOxgNqXCCHDLDRRLKxPiwnlfS.lVKNgfdnvooThauNKoHqFzpxVJJs = edmPFVQXZAgSMnagypaqNIebBPiI.JwgIOxgNqXCCHDLDRRLKxPiwnlfS.JlVTkHOYlNWsXpgsjJQgOZPwDPQS;
		return edmPFVQXZAgSMnagypaqNIebBPiI.CEkaEAJJHujgkOedcSxKbCrmhPGs(P_0, P_2, (int)P_3, ref jwgIOxgNqXCCHDLDRRLKxPiwnlfS, 3, num, 0);
	}

	public static void ZxsgpNvFFQdELlTlvHLpYgfgdsUH(IntPtr P_0)
	{
		PCKelxQvtvDJFfGdRMpUbhvAbjmcA(P_0);
		edmPFVQXZAgSMnagypaqNIebBPiI.pMIrwoENqkbQSRKhiyUFQmBIvFyN(P_0);
	}

	public static void PCKelxQvtvDJFfGdRMpUbhvAbjmcA(IntPtr P_0)
	{
		if (Environment.OSVersion.Version.Major > 5)
		{
			edmPFVQXZAgSMnagypaqNIebBPiI.EYBJWeoEEiSqjpzomvzoIHRnPWPB(P_0, IntPtr.Zero);
		}
		else
		{
			edmPFVQXZAgSMnagypaqNIebBPiI.cnriKgJSvbMBwweLDHAiOCjIABbfA(P_0);
		}
	}

	private static void qFcohiQnPEYzFSQaSrJhiNUDKeYr(IntPtr P_0)
	{
		edmPFVQXZAgSMnagypaqNIebBPiI.cnriKgJSvbMBwweLDHAiOCjIABbfA(P_0);
		edmPFVQXZAgSMnagypaqNIebBPiI.pMIrwoENqkbQSRKhiyUFQmBIvFyN(P_0);
	}

	internal static SIYuejvQjndRFJfAYGpZwmWjVrTh IUgAWcHKtFseQiNrQUcskhdoiyTH(int P_0, int P_1, int P_2, int P_3, int P_4)
	{
		IdGKZPGlBMdjGcVcHUAhCeMTbpNDA[] array = new IdGKZPGlBMdjGcVcHUAhCeMTbpNDA[P_3];
		for (int i = 0; i < P_3; i++)
		{
			edmPFVQXZAgSMnagypaqNIebBPiI.xVQCyjaDGiEBpNFngcwRrOjqKDr.WOPOuyfkRiqXTJRjopJBLMGtZaqP sCBlSrzssygaygoytNFxGUJvqEkj = new edmPFVQXZAgSMnagypaqNIebBPiI.xVQCyjaDGiEBpNFngcwRrOjqKDr.WOPOuyfkRiqXTJRjopJBLMGtZaqP
			{
				FvMOmuYGNRBuSSOmoyuhNGQpjgTP = new ushort[8]
			};
			sCBlSrzssygaygoytNFxGUJvqEkj.FvMOmuYGNRBuSSOmoyuhNGQpjgTP[0] = (ushort)i;
			array[i] = new IdGKZPGlBMdjGcVcHUAhCeMTbpNDA(new edmPFVQXZAgSMnagypaqNIebBPiI.xVQCyjaDGiEBpNFngcwRrOjqKDr
			{
				QbCzNxVtDddYdKfIBaMzmcUNfxlu = 9,
				sCBlSrzssygaygoytNFxGUJvqEkj = sCBlSrzssygaygoytNFxGUJvqEkj
			});
		}
		int num = P_2 + P_4;
		nyKEGqIoaJkcvwlUxeRaXWfkcuizA[] array2 = new nyKEGqIoaJkcvwlUxeRaXWfkcuizA[num];
		for (int j = 0; j < num; j++)
		{
			edmPFVQXZAgSMnagypaqNIebBPiI.MyuRJZBCRFDMOWtHTXQtbaRGxplK.TCzDrxgxRAJnkTQXttBWsLJFNMbk yDwbBLLdBPQfQIiBaIXyDjTPgzyaA = new edmPFVQXZAgSMnagypaqNIebBPiI.MyuRJZBCRFDMOWtHTXQtbaRGxplK.TCzDrxgxRAJnkTQXttBWsLJFNMbk
			{
				vAOEAHVgVTHrIIqrnfTmBkkfqUmgA = new ushort[8]
			};
			if (j < P_2)
			{
				yDwbBLLdBPQfQIiBaIXyDjTPgzyaA.vAOEAHVgVTHrIIqrnfTmBkkfqUmgA[0] = 48;
			}
			else
			{
				yDwbBLLdBPQfQIiBaIXyDjTPgzyaA.vAOEAHVgVTHrIIqrnfTmBkkfqUmgA[0] = 57;
			}
			array2[j] = new nyKEGqIoaJkcvwlUxeRaXWfkcuizA(new edmPFVQXZAgSMnagypaqNIebBPiI.MyuRJZBCRFDMOWtHTXQtbaRGxplK
			{
				naEduOndYDVHeRyUvIfjJxUGUkNA = 1,
				YDwbBLLdBPQfQIiBaIXyDjTPgzyaA = yDwbBLLdBPQfQIiBaIXyDjTPgzyaA
			});
		}
		return new SIYuejvQjndRFJfAYGpZwmWjVrTh(new ZIQGfvvtwXgDvGscqSxZnSMsIetv(new edmPFVQXZAgSMnagypaqNIebBPiI.sBqvGnBhMGHWzdMBUsvwZpHWISvcb
		{
			mPtEIPsUNLHzSZXIhTbZaJxGRndb = (ushort)P_1,
			JVeDWvheRtHYxHgnxwWgLZSDqljU = (ushort)P_0
		}), new vTaEkysGrJbjIGXiCYzkVFcdegGY(new edmPFVQXZAgSMnagypaqNIebBPiI.CrLzmHgDLWGhHlmFtECNwqQvjfSW
		{
			ILNOwyspALtRCzePQSrsTmSjwmQ = (short)P_3,
			HWyUkYHKsLqAKHklzFwqEmMzflcK = (short)P_2
		}), array, array2);
	}

	private static byte[] HpHGKXoOwBbrayIMriiBdqUMMYus(int P_0)
	{
		byte[] array = null;
		Array.Resize(ref array, P_0 + 1);
		return array;
	}

	public static ZIQGfvvtwXgDvGscqSxZnSMsIetv XoNBWaTqeXeDPhdDLFlXnXSpmnSvA(IntPtr P_0)
	{
		edmPFVQXZAgSMnagypaqNIebBPiI.sBqvGnBhMGHWzdMBUsvwZpHWISvcb sBqvGnBhMGHWzdMBUsvwZpHWISvcb = default(edmPFVQXZAgSMnagypaqNIebBPiI.sBqvGnBhMGHWzdMBUsvwZpHWISvcb);
		sBqvGnBhMGHWzdMBUsvwZpHWISvcb.qWScFtMpYGyKRuSlPgJyqWpnDKmK = Marshal.SizeOf(sBqvGnBhMGHWzdMBUsvwZpHWISvcb);
		edmPFVQXZAgSMnagypaqNIebBPiI.LfuyYuBesdbrwJfsEwbqcFQwDrpt(P_0, ref sBqvGnBhMGHWzdMBUsvwZpHWISvcb);
		return new ZIQGfvvtwXgDvGscqSxZnSMsIetv(sBqvGnBhMGHWzdMBUsvwZpHWISvcb);
	}

	public static vTaEkysGrJbjIGXiCYzkVFcdegGY tveDIpJoiuaOdgqOkIUnmNInNLWdb(IntPtr P_0)
	{
		edmPFVQXZAgSMnagypaqNIebBPiI.CrLzmHgDLWGhHlmFtECNwqQvjfSW crLzmHgDLWGhHlmFtECNwqQvjfSW = default(edmPFVQXZAgSMnagypaqNIebBPiI.CrLzmHgDLWGhHlmFtECNwqQvjfSW);
		IntPtr zero = IntPtr.Zero;
		try
		{
			if (edmPFVQXZAgSMnagypaqNIebBPiI.IpBqooSnDvGOJkQKFQGmEjNKEBQp(P_0, ref zero))
			{
				edmPFVQXZAgSMnagypaqNIebBPiI.hduBAPXHcFuMPJjwHzWZPaJGUOf(zero, ref crLzmHgDLWGhHlmFtECNwqQvjfSW);
			}
		}
		catch
		{
		}
		finally
		{
			try
			{
				if (zero != IntPtr.Zero)
				{
					edmPFVQXZAgSMnagypaqNIebBPiI.XggZFWKzOyUDimsgQHDuDovkFWlD(zero);
				}
			}
			catch
			{
			}
		}
		return new vTaEkysGrJbjIGXiCYzkVFcdegGY(crLzmHgDLWGhHlmFtECNwqQvjfSW);
	}

	public static IdGKZPGlBMdjGcVcHUAhCeMTbpNDA[] LJOVSRioEJXsCwTqQrRkNkzzgODB(IntPtr P_0, short P_1, short P_2)
	{
		IdGKZPGlBMdjGcVcHUAhCeMTbpNDA[] array = new IdGKZPGlBMdjGcVcHUAhCeMTbpNDA[P_2];
		if (P_2 <= 0)
		{
			return array;
		}
		short num = P_2;
		IntPtr zero = IntPtr.Zero;
		try
		{
			if (edmPFVQXZAgSMnagypaqNIebBPiI.IpBqooSnDvGOJkQKFQGmEjNKEBQp(P_0, ref zero))
			{
				int num2 = 72 * P_2;
				IntPtr intPtr = IntPtr.Zero;
				try
				{
					intPtr = Marshal.AllocHGlobal(num2);
					IntPtr intPtr2 = intPtr;
					edmPFVQXZAgSMnagypaqNIebBPiI.VPEXHoQIOJhvadAUHIKvuHyxZFmU(intPtr, num2);
					edmPFVQXZAgSMnagypaqNIebBPiI.OiSArLkCwXUkyujLJSCRinbvnSvV(P_1, intPtr, ref num, zero);
					if (num > 0)
					{
						edmPFVQXZAgSMnagypaqNIebBPiI.xVQCyjaDGiEBpNFngcwRrOjqKDr[] array2 = new edmPFVQXZAgSMnagypaqNIebBPiI.xVQCyjaDGiEBpNFngcwRrOjqKDr[num];
						for (int i = 0; i < num; i++)
						{
							array2[i] = (edmPFVQXZAgSMnagypaqNIebBPiI.xVQCyjaDGiEBpNFngcwRrOjqKDr)Marshal.PtrToStructure(intPtr2, typeof(edmPFVQXZAgSMnagypaqNIebBPiI.xVQCyjaDGiEBpNFngcwRrOjqKDr));
							intPtr2 = NativeTools.OffsetIntPtr(intPtr2, 72);
							array[i] = new IdGKZPGlBMdjGcVcHUAhCeMTbpNDA(array2[i]);
						}
					}
				}
				catch
				{
					throw;
				}
				finally
				{
					if (intPtr != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}
		}
		catch
		{
		}
		finally
		{
			try
			{
				if (zero != IntPtr.Zero)
				{
					edmPFVQXZAgSMnagypaqNIebBPiI.XggZFWKzOyUDimsgQHDuDovkFWlD(zero);
				}
			}
			catch
			{
			}
		}
		for (int j = 0; j < P_2; j++)
		{
			if (array[j] == null)
			{
				array[j] = null;
			}
		}
		return array;
	}

	public static nyKEGqIoaJkcvwlUxeRaXWfkcuizA[] YqYowXgSRdfjiyiNyxlbfEjZTvoc(IntPtr P_0, short P_1, short P_2)
	{
		nyKEGqIoaJkcvwlUxeRaXWfkcuizA[] array = new nyKEGqIoaJkcvwlUxeRaXWfkcuizA[P_2];
		if (P_2 <= 0)
		{
			return array;
		}
		short num = P_2;
		IntPtr zero = IntPtr.Zero;
		try
		{
			if (edmPFVQXZAgSMnagypaqNIebBPiI.IpBqooSnDvGOJkQKFQGmEjNKEBQp(P_0, ref zero))
			{
				int num2 = 72 * P_2;
				IntPtr intPtr = IntPtr.Zero;
				try
				{
					intPtr = Marshal.AllocHGlobal(num2);
					IntPtr intPtr2 = intPtr;
					edmPFVQXZAgSMnagypaqNIebBPiI.VPEXHoQIOJhvadAUHIKvuHyxZFmU(intPtr, num2);
					edmPFVQXZAgSMnagypaqNIebBPiI.QIDSQfRoNlImiJmEDQHHBqIMWSFPA(P_1, intPtr, ref num, zero);
					if (num > 0)
					{
						edmPFVQXZAgSMnagypaqNIebBPiI.MyuRJZBCRFDMOWtHTXQtbaRGxplK[] array2 = new edmPFVQXZAgSMnagypaqNIebBPiI.MyuRJZBCRFDMOWtHTXQtbaRGxplK[num];
						for (int i = 0; i < num; i++)
						{
							array2[i] = (edmPFVQXZAgSMnagypaqNIebBPiI.MyuRJZBCRFDMOWtHTXQtbaRGxplK)Marshal.PtrToStructure(intPtr2, typeof(edmPFVQXZAgSMnagypaqNIebBPiI.MyuRJZBCRFDMOWtHTXQtbaRGxplK));
							intPtr2 = NativeTools.OffsetIntPtr(intPtr2, 72);
							array[i] = new nyKEGqIoaJkcvwlUxeRaXWfkcuizA(array2[i]);
						}
					}
				}
				catch
				{
					throw;
				}
				finally
				{
					if (intPtr != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}
		}
		catch
		{
		}
		finally
		{
			try
			{
				if (zero != IntPtr.Zero)
				{
					edmPFVQXZAgSMnagypaqNIebBPiI.XggZFWKzOyUDimsgQHDuDovkFWlD(zero);
				}
			}
			catch
			{
			}
		}
		for (int j = 0; j < P_2; j++)
		{
			if (array[j] == null)
			{
				array[j] = null;
			}
		}
		return array;
	}
}
