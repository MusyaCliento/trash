using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired;
using Rewired.Platforms.Microsoft.WindowsGamingInput;
using Rewired.Utils.Attributes;

internal class VgwvWxNdcHfXWFTgEsEQLMdlOXEy : wcLbzbaqKXDXEVJrRiPYBzwACofyb
{
	private static bool ZMaCnghtFBrVMZLQechNaquECBIIA;

	private static PidVid[] EsfGeYIGYtXDyfdnjGBpIZLkSEqkA;

	[CompilerGenerated]
	private static Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> m_dBRKfQUuPZjqCUIyIDpPRPbvfEZHA;

	[CompilerGenerated]
	private static Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> m_DTDhADdXRCjgAeCnaFwJVPxSnTHm;

	private static PidVid[] uSUOPecgIxEcJiXQqqGgEEQIAgqw
	{
		get
		{
			if (EsfGeYIGYtXDyfdnjGBpIZLkSEqkA == null)
			{
				List<PidVid> list = new List<PidVid>
				{
					new PidVid(8201, 1406)
				};
				for (int i = 0; i < Consts.pidVids_sony_dualShock4.Count; i++)
				{
					list.Add(Consts.pidVids_sony_dualShock4[i]);
				}
				for (int j = 0; j < Consts.pidVids_sony_dualSense.Count; j++)
				{
					list.Add(Consts.pidVids_sony_dualSense[j]);
				}
				EsfGeYIGYtXDyfdnjGBpIZLkSEqkA = list.ToArray();
			}
			return EsfGeYIGYtXDyfdnjGBpIZLkSEqkA;
		}
	}

	public vhBtsabzPKkijgkLYIuaKiuzvryy noCGNIduvKiDQhHGzRPqhMxwQzIpA
	{
		get
		{
			vhBtsabzPKkijgkLYIuaKiuzvryy result = default(vhBtsabzPKkijgkLYIuaKiuzvryy);
			if (!txqxGWvgbIFBXSvhVfsjWiujImUh.IxUxRwOiJoafdfFhKIRVDBneDEiwA)
			{
				return result;
			}
			udoDNkHycCgefDIWsbDcIfcDLILLB.KEnpIiGzABVuByifdIaFWOHLbtRL(sBjgzLwqPhprfslfghRWQAGrbkct.HDKgZIguMTsBLnCfoxyrYUiJjXs(txqxGWvgbIFBXSvhVfsjWiujImUh), ref result);
			return result;
		}
		set
		{
			if (txqxGWvgbIFBXSvhVfsjWiujImUh.IxUxRwOiJoafdfFhKIRVDBneDEiwA)
			{
				udoDNkHycCgefDIWsbDcIfcDLILLB.RCoTRzorSSpGdqggFFZuHNXVQpCkA(sBjgzLwqPhprfslfghRWQAGrbkct.HDKgZIguMTsBLnCfoxyrYUiJjXs(txqxGWvgbIFBXSvhVfsjWiujImUh), vhBtsabzPKkijgkLYIuaKiuzvryy2);
			}
		}
	}

	public THVaKaaaPPtLYMxiOdtmdFaFYMLdA ZLRydbajtcIQyInJzDgGWxANYype
	{
		get
		{
			if (!txqxGWvgbIFBXSvhVfsjWiujImUh.IxUxRwOiJoafdfFhKIRVDBneDEiwA)
			{
				return null;
			}
			return udoDNkHycCgefDIWsbDcIfcDLILLB.QWwlmzYddOCJvLByUfiDHmgdYCPpA(sBjgzLwqPhprfslfghRWQAGrbkct.HDKgZIguMTsBLnCfoxyrYUiJjXs(txqxGWvgbIFBXSvhVfsjWiujImUh));
		}
	}

	public static event Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> dBRKfQUuPZjqCUIyIDpPRPbvfEZHA
	{
		[CompilerGenerated]
		add
		{
			Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> action = VgwvWxNdcHfXWFTgEsEQLMdlOXEy.m_dBRKfQUuPZjqCUIyIDpPRPbvfEZHA;
			Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> action2;
			do
			{
				action2 = action;
				Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> value2 = (Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy>)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref VgwvWxNdcHfXWFTgEsEQLMdlOXEy.m_dBRKfQUuPZjqCUIyIDpPRPbvfEZHA, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> action = VgwvWxNdcHfXWFTgEsEQLMdlOXEy.m_dBRKfQUuPZjqCUIyIDpPRPbvfEZHA;
			Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> action2;
			do
			{
				action2 = action;
				Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> value2 = (Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy>)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref VgwvWxNdcHfXWFTgEsEQLMdlOXEy.m_dBRKfQUuPZjqCUIyIDpPRPbvfEZHA, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static event Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> DTDhADdXRCjgAeCnaFwJVPxSnTHm
	{
		[CompilerGenerated]
		add
		{
			Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> action = VgwvWxNdcHfXWFTgEsEQLMdlOXEy.m_DTDhADdXRCjgAeCnaFwJVPxSnTHm;
			Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> action2;
			do
			{
				action2 = action;
				Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> value2 = (Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy>)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref VgwvWxNdcHfXWFTgEsEQLMdlOXEy.m_DTDhADdXRCjgAeCnaFwJVPxSnTHm, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> action = VgwvWxNdcHfXWFTgEsEQLMdlOXEy.m_DTDhADdXRCjgAeCnaFwJVPxSnTHm;
			Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> action2;
			do
			{
				action2 = action;
				Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> value2 = (Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy>)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref VgwvWxNdcHfXWFTgEsEQLMdlOXEy.m_DTDhADdXRCjgAeCnaFwJVPxSnTHm, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static void GlAaPqrCkDjoeBQrBbxgNaEMuWuO()
	{
		if (ZMaCnghtFBrVMZLQechNaquECBIIA)
		{
			throw new Exception(typeof(VgwvWxNdcHfXWFTgEsEQLMdlOXEy)?.ToString() + " already initialized.");
		}
		try
		{
			udoDNkHycCgefDIWsbDcIfcDLILLB.XWoseGYSZGpcdIGNSnKutamyKHUb(mojKGtpXPZNjIgfmkVyszWmKLSxx);
			udoDNkHycCgefDIWsbDcIfcDLILLB.mziMHeyKvglRGRAAtsANRHtrOeAI(JYwSumSeMhPtPPMWKeQrhYYESNlN);
			udoDNkHycCgefDIWsbDcIfcDLILLB.mvaLjAKjcvQDGLTVEabWtpAzfodbA();
		}
		catch (Exception)
		{
			try
			{
				udoDNkHycCgefDIWsbDcIfcDLILLB.DQbeJhbfdMBYPWSAYLpDAvRgbAjTA();
				udoDNkHycCgefDIWsbDcIfcDLILLB.XWoseGYSZGpcdIGNSnKutamyKHUb(null);
				udoDNkHycCgefDIWsbDcIfcDLILLB.mziMHeyKvglRGRAAtsANRHtrOeAI(null);
			}
			catch
			{
			}
			throw;
		}
		ZMaCnghtFBrVMZLQechNaquECBIIA = true;
	}

	public static void sBFthxVVsfvKFlxXCYUHzwaxpzKH()
	{
		if (ZMaCnghtFBrVMZLQechNaquECBIIA)
		{
			VgwvWxNdcHfXWFTgEsEQLMdlOXEy.dBRKfQUuPZjqCUIyIDpPRPbvfEZHA = null;
			VgwvWxNdcHfXWFTgEsEQLMdlOXEy.DTDhADdXRCjgAeCnaFwJVPxSnTHm = null;
			try
			{
				udoDNkHycCgefDIWsbDcIfcDLILLB.DQbeJhbfdMBYPWSAYLpDAvRgbAjTA();
			}
			catch (Exception)
			{
			}
			try
			{
				udoDNkHycCgefDIWsbDcIfcDLILLB.XWoseGYSZGpcdIGNSnKutamyKHUb(null);
			}
			catch (Exception)
			{
			}
			try
			{
				udoDNkHycCgefDIWsbDcIfcDLILLB.mziMHeyKvglRGRAAtsANRHtrOeAI(null);
			}
			catch (Exception)
			{
			}
			ZMaCnghtFBrVMZLQechNaquECBIIA = false;
		}
	}

	public static void LOYnAvyHzJtHyqedTlbeEDFfpeLN(List<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> P_0)
	{
		P_0.Clear();
		sBjgzLwqPhprfslfghRWQAGrbkct sBjgzLwqPhprfslfghRWQAGrbkct2 = new sBjgzLwqPhprfslfghRWQAGrbkct(udoDNkHycCgefDIWsbDcIfcDLILLB.ZzSQSWNDHhlInmYDeLbdKnqAkcDr());
		if (sBjgzLwqPhprfslfghRWQAGrbkct2.IxUxRwOiJoafdfFhKIRVDBneDEiwA)
		{
			int num = (int)udoDNkHycCgefDIWsbDcIfcDLILLB.INpkoKRwOrVaJveqJcRMRpPTimocA(sBjgzLwqPhprfslfghRWQAGrbkct.HDKgZIguMTsBLnCfoxyrYUiJjXs(sBjgzLwqPhprfslfghRWQAGrbkct2));
			for (int i = 0; i < num; i++)
			{
				sBjgzLwqPhprfslfghRWQAGrbkct sBjgzLwqPhprfslfghRWQAGrbkct3 = new sBjgzLwqPhprfslfghRWQAGrbkct(udoDNkHycCgefDIWsbDcIfcDLILLB.NgWSrQfKtHISVHQyFNHIIjRyuvbK(sBjgzLwqPhprfslfghRWQAGrbkct.HDKgZIguMTsBLnCfoxyrYUiJjXs(sBjgzLwqPhprfslfghRWQAGrbkct2), (uint)i));
				if (!sBjgzLwqPhprfslfghRWQAGrbkct3.IxUxRwOiJoafdfFhKIRVDBneDEiwA)
				{
					continue;
				}
				VgwvWxNdcHfXWFTgEsEQLMdlOXEy vgwvWxNdcHfXWFTgEsEQLMdlOXEy = new VgwvWxNdcHfXWFTgEsEQLMdlOXEy(sBjgzLwqPhprfslfghRWQAGrbkct3);
				TOCLTWwqQtaVfGwWTuwtZvfMRilP tOCLTWwqQtaVfGwWTuwtZvfMRilP = TOCLTWwqQtaVfGwWTuwtZvfMRilP.vRLmsSJsJmStxxuODNiQougNievR(vgwvWxNdcHfXWFTgEsEQLMdlOXEy);
				if (tOCLTWwqQtaVfGwWTuwtZvfMRilP != null)
				{
					PidVid value = new PidVid(tOCLTWwqQtaVfGwWTuwtZvfMRilP.TuCPzUBKERBcoFdMkczlIMdiDDPc, tOCLTWwqQtaVfGwWTuwtZvfMRilP.pJbIaXTntMUUnAoRXtyOToUaUktx);
					tOCLTWwqQtaVfGwWTuwtZvfMRilP.keQIIDyPbblqAlAdcGQFTVBTOtzV();
					if (uSUOPecgIxEcJiXQqqGgEEQIAgqw.Contains(value))
					{
						vgwvWxNdcHfXWFTgEsEQLMdlOXEy.keQIIDyPbblqAlAdcGQFTVBTOtzV();
						continue;
					}
				}
				P_0.Add(vgwvWxNdcHfXWFTgEsEQLMdlOXEy);
			}
		}
		sBjgzLwqPhprfslfghRWQAGrbkct2.cDWdAzbrcFPRKMCKxCPBCEwRufKH();
	}

	public static bool RuNhmcJnbFzucuwBRqwkPhNWEDRl(ushort P_0, ushort P_1)
	{
		if (uSUOPecgIxEcJiXQqqGgEEQIAgqw.Contains(new PidVid(P_1, P_0)))
		{
			return false;
		}
		sBjgzLwqPhprfslfghRWQAGrbkct sBjgzLwqPhprfslfghRWQAGrbkct2 = new sBjgzLwqPhprfslfghRWQAGrbkct(udoDNkHycCgefDIWsbDcIfcDLILLB.ZzSQSWNDHhlInmYDeLbdKnqAkcDr());
		if (!sBjgzLwqPhprfslfghRWQAGrbkct2.IxUxRwOiJoafdfFhKIRVDBneDEiwA)
		{
			return false;
		}
		int num = (int)udoDNkHycCgefDIWsbDcIfcDLILLB.INpkoKRwOrVaJveqJcRMRpPTimocA(sBjgzLwqPhprfslfghRWQAGrbkct.HDKgZIguMTsBLnCfoxyrYUiJjXs(sBjgzLwqPhprfslfghRWQAGrbkct2));
		bool flag = false;
		for (int i = 0; i < num; i++)
		{
			sBjgzLwqPhprfslfghRWQAGrbkct sBjgzLwqPhprfslfghRWQAGrbkct3 = new sBjgzLwqPhprfslfghRWQAGrbkct(udoDNkHycCgefDIWsbDcIfcDLILLB.NgWSrQfKtHISVHQyFNHIIjRyuvbK(sBjgzLwqPhprfslfghRWQAGrbkct.HDKgZIguMTsBLnCfoxyrYUiJjXs(sBjgzLwqPhprfslfghRWQAGrbkct2), (uint)i));
			if (sBjgzLwqPhprfslfghRWQAGrbkct3.IxUxRwOiJoafdfFhKIRVDBneDEiwA)
			{
				TOCLTWwqQtaVfGwWTuwtZvfMRilP tOCLTWwqQtaVfGwWTuwtZvfMRilP = TOCLTWwqQtaVfGwWTuwtZvfMRilP.vRLmsSJsJmStxxuODNiQougNievR(new VgwvWxNdcHfXWFTgEsEQLMdlOXEy(sBjgzLwqPhprfslfghRWQAGrbkct3));
				if (tOCLTWwqQtaVfGwWTuwtZvfMRilP.RRsrrdRchoGrHeChnGXLmAcftAkf)
				{
					flag = YzZPNVqJuMouNqYoppjQWcGaCOqg(P_0, P_1, tOCLTWwqQtaVfGwWTuwtZvfMRilP);
					tOCLTWwqQtaVfGwWTuwtZvfMRilP.keQIIDyPbblqAlAdcGQFTVBTOtzV();
				}
				sBjgzLwqPhprfslfghRWQAGrbkct3.cDWdAzbrcFPRKMCKxCPBCEwRufKH();
				if (flag)
				{
					break;
				}
			}
		}
		sBjgzLwqPhprfslfghRWQAGrbkct2.cDWdAzbrcFPRKMCKxCPBCEwRufKH();
		return flag;
	}

	private static bool YzZPNVqJuMouNqYoppjQWcGaCOqg(ushort P_0, ushort P_1, TOCLTWwqQtaVfGwWTuwtZvfMRilP P_2)
	{
		if (sqgEUGxUqPKzzfaRNHiOezIAgCrn(P_0, P_1, P_2.pJbIaXTntMUUnAoRXtyOToUaUktx, P_2.TuCPzUBKERBcoFdMkczlIMdiDDPc))
		{
			return true;
		}
		if (P_2.cUvdCUeEBtUNrxNXEZSHveClEbad(out var pidVid) && sqgEUGxUqPKzzfaRNHiOezIAgCrn(P_0, P_1, pidVid.vendorId, pidVid.productId))
		{
			return true;
		}
		return false;
	}

	private static bool sqgEUGxUqPKzzfaRNHiOezIAgCrn(ushort P_0, ushort P_1, ushort P_2, ushort P_3)
	{
		if (P_0 != P_2)
		{
			return false;
		}
		if (P_1 == P_3)
		{
			return true;
		}
		if (P_0 == 1118 && P_3 == 0)
		{
			return true;
		}
		return false;
	}

	public static VgwvWxNdcHfXWFTgEsEQLMdlOXEy lLxfCdFCsOnOpqPEHeycIDdfaEUe(wcLbzbaqKXDXEVJrRiPYBzwACofyb P_0)
	{
		try
		{
			RwLabsEOzFsRaihcrFeZHujcOJgIB rwLabsEOzFsRaihcrFeZHujcOJgIB = udoDNkHycCgefDIWsbDcIfcDLILLB.ELTChFwGPwMYUbyoKaXIfmUGjsvq(P_0.zISDdSoWaniQeKVDOAGThAdVAouJ);
			if (!rwLabsEOzFsRaihcrFeZHujcOJgIB.WKKwrdISJWnQZgbgkplzNJDekgPB)
			{
				return null;
			}
			return new VgwvWxNdcHfXWFTgEsEQLMdlOXEy(new sBjgzLwqPhprfslfghRWQAGrbkct(rwLabsEOzFsRaihcrFeZHujcOJgIB));
		}
		catch (Exception)
		{
			return null;
		}
	}

	private static void AyThAeNBptPahEYhlbZpESiJdThL()
	{
		if (!ZMaCnghtFBrVMZLQechNaquECBIIA)
		{
			throw new Exception(typeof(VgwvWxNdcHfXWFTgEsEQLMdlOXEy)?.ToString() + " not initialized.");
		}
	}

	[MonoPInvokeCallback(typeof(udoDNkHycCgefDIWsbDcIfcDLILLB.QoaArKCmBergUuuCcKzGHbxMbuRbb))]
	private static void mojKGtpXPZNjIgfmkVyszWmKLSxx(RwLabsEOzFsRaihcrFeZHujcOJgIB P_0)
	{
		if (P_0.WKKwrdISJWnQZgbgkplzNJDekgPB)
		{
			Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> action = VgwvWxNdcHfXWFTgEsEQLMdlOXEy.dBRKfQUuPZjqCUIyIDpPRPbvfEZHA;
			if (action != null)
			{
				udoDNkHycCgefDIWsbDcIfcDLILLB.YAXSwcstKHMlBVZtbnbYWqsYzwum(P_0.jevDQjnotINyDxVirVbZgNIRcpst);
				action(new VgwvWxNdcHfXWFTgEsEQLMdlOXEy(new sBjgzLwqPhprfslfghRWQAGrbkct(P_0)));
			}
		}
	}

	[MonoPInvokeCallback(typeof(udoDNkHycCgefDIWsbDcIfcDLILLB.tpyWFonmfzbDlWhHiUdmqhcgTXrK))]
	private static void JYwSumSeMhPtPPMWKeQrhYYESNlN(RwLabsEOzFsRaihcrFeZHujcOJgIB P_0)
	{
		if (P_0.WKKwrdISJWnQZgbgkplzNJDekgPB)
		{
			Action<VgwvWxNdcHfXWFTgEsEQLMdlOXEy> dTDhADdXRCjgAeCnaFwJVPxSnTHm = VgwvWxNdcHfXWFTgEsEQLMdlOXEy.DTDhADdXRCjgAeCnaFwJVPxSnTHm;
			if (dTDhADdXRCjgAeCnaFwJVPxSnTHm != null)
			{
				udoDNkHycCgefDIWsbDcIfcDLILLB.YAXSwcstKHMlBVZtbnbYWqsYzwum(P_0.jevDQjnotINyDxVirVbZgNIRcpst);
				dTDhADdXRCjgAeCnaFwJVPxSnTHm(new VgwvWxNdcHfXWFTgEsEQLMdlOXEy(new sBjgzLwqPhprfslfghRWQAGrbkct(P_0)));
			}
		}
	}

	public VgwvWxNdcHfXWFTgEsEQLMdlOXEy(sBjgzLwqPhprfslfghRWQAGrbkct P_0)
		: base(P_0)
	{
	}

	public atgIFQpkSifJQdHTdmSHWzSyatSg SrIEwbDFXUTJOOKhCzLeTtHrAcxz()
	{
		atgIFQpkSifJQdHTdmSHWzSyatSg result = default(atgIFQpkSifJQdHTdmSHWzSyatSg);
		if (!txqxGWvgbIFBXSvhVfsjWiujImUh.IxUxRwOiJoafdfFhKIRVDBneDEiwA)
		{
			return result;
		}
		udoDNkHycCgefDIWsbDcIfcDLILLB.enaJmmVzgELkhqkhzHereUHbYFQO(sBjgzLwqPhprfslfghRWQAGrbkct.HDKgZIguMTsBLnCfoxyrYUiJjXs(txqxGWvgbIFBXSvhVfsjWiujImUh), ref result);
		return result;
	}

	public DQULNtajDVdsYULTiraYeWDVvfxy NGcPtDtTYTnfvbkZssRdnSMWdbFX(GamepadButtons P_0)
	{
		if (!txqxGWvgbIFBXSvhVfsjWiujImUh.IxUxRwOiJoafdfFhKIRVDBneDEiwA)
		{
			return DQULNtajDVdsYULTiraYeWDVvfxy.None;
		}
		return udoDNkHycCgefDIWsbDcIfcDLILLB.toPChVkZftRurgufSidacFABeSjPB(sBjgzLwqPhprfslfghRWQAGrbkct.HDKgZIguMTsBLnCfoxyrYUiJjXs(txqxGWvgbIFBXSvhVfsjWiujImUh), P_0);
	}

	public virtual bool pOrBREgAzaFRhSsuJlSNumHoDJuW(object P_0)
	{
		VgwvWxNdcHfXWFTgEsEQLMdlOXEy vgwvWxNdcHfXWFTgEsEQLMdlOXEy = P_0 as VgwvWxNdcHfXWFTgEsEQLMdlOXEy;
		if (DCFGiOgMhDSZOrmIIIYCstyDEyzaA(vgwvWxNdcHfXWFTgEsEQLMdlOXEy, null))
		{
			return false;
		}
		return sBjgzLwqPhprfslfghRWQAGrbkct.JHuPNvMSERZGazVrJFMzqJqcIQoj(txqxGWvgbIFBXSvhVfsjWiujImUh, vgwvWxNdcHfXWFTgEsEQLMdlOXEy.txqxGWvgbIFBXSvhVfsjWiujImUh);
	}

	public virtual int uFIpCfZFPWgQwaZkdAuLfWXFnDpSB()
	{
		return base.GetHashCode();
	}

	public bool qwxMXnXRFzbtEXhjrnWlkZeaSMDf(VgwvWxNdcHfXWFTgEsEQLMdlOXEy P_0)
	{
		if (DCFGiOgMhDSZOrmIIIYCstyDEyzaA(P_0, null) || !P_0.txqxGWvgbIFBXSvhVfsjWiujImUh.IxUxRwOiJoafdfFhKIRVDBneDEiwA)
		{
			return false;
		}
		return txqxGWvgbIFBXSvhVfsjWiujImUh.HyhCCFmSVaXfWiePWFGKValCXKcm == P_0.txqxGWvgbIFBXSvhVfsjWiujImUh.HyhCCFmSVaXfWiePWFGKValCXKcm;
	}

	[SpecialName]
	public static bool DCFGiOgMhDSZOrmIIIYCstyDEyzaA(VgwvWxNdcHfXWFTgEsEQLMdlOXEy P_0, VgwvWxNdcHfXWFTgEsEQLMdlOXEy P_1)
	{
		return P_0?.qwxMXnXRFzbtEXhjrnWlkZeaSMDf(P_1) ?? (P_1 == null);
	}

	[SpecialName]
	public static bool QVhJmXthbeyEqmVSbPmgUNlWEFsjA(VgwvWxNdcHfXWFTgEsEQLMdlOXEy P_0, VgwvWxNdcHfXWFTgEsEQLMdlOXEy P_1)
	{
		if (P_0 == null)
		{
			return P_1 != null;
		}
		return !P_0.qwxMXnXRFzbtEXhjrnWlkZeaSMDf(P_1);
	}
}
