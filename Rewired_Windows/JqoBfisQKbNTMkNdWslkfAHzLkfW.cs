using System;
using Rewired;
using Rewired.Utils;

internal static class JqoBfisQKbNTMkNdWslkfAHzLkfW
{
	public enum XcOkqwrbTtgWlIVcjIfeKlsQNDJTA
	{
		None = 0,
		CombinedTriggers = 1,
		SplitTriggers = 2
	}

	private struct QNrofIWDGVwXZnyYUAuOpFqavFrA
	{
		public enum SqWAUQhzQPYjklWyJyAYBYpIaqHvA
		{
			Deny = 0,
			Allow = 1
		}

		public enum OwQlcpyGfRXKDKdWhKhwzxmiHJTN
		{
			MatchAnyProperty = 0,
			MatchAllProperties = 1,
			IgnoreProperties = 2
		}

		public SqWAUQhzQPYjklWyJyAYBYpIaqHvA zFEfyFbaEUfZVIDOrvvJQqMoaJSR;

		public InputSource[] ADstVUqTpUMLHFuKkqsVFEWpbOfdA;

		public PidVid QDVFuGavNmAVNIHINOKaCLrDTQgEA;

		public IQBialDLMBiObHdTIbjQIuoQHpxo SrRRrbeBUTvyXpXAexCBzJNqaUnM;

		public OwQlcpyGfRXKDKdWhKhwzxmiHJTN XMraCyCuWqiyImxYIaXxOkCobiNrA;

		public QNrofIWDGVwXZnyYUAuOpFqavFrA(SqWAUQhzQPYjklWyJyAYBYpIaqHvA P_0, InputSource[] P_1, PidVid P_2, IQBialDLMBiObHdTIbjQIuoQHpxo P_3, OwQlcpyGfRXKDKdWhKhwzxmiHJTN P_4)
		{
			zFEfyFbaEUfZVIDOrvvJQqMoaJSR = P_0;
			ADstVUqTpUMLHFuKkqsVFEWpbOfdA = P_1;
			QDVFuGavNmAVNIHINOKaCLrDTQgEA = P_2;
			SrRRrbeBUTvyXpXAexCBzJNqaUnM = P_3;
			XMraCyCuWqiyImxYIaXxOkCobiNrA = P_4;
		}

		public bool rnMuYJXNQEbdbIbMXYmmJKLPDTGJ(InputSource P_0, ushort P_1, ushort P_2, IQBialDLMBiObHdTIbjQIuoQHpxo P_3)
		{
			if (ADstVUqTpUMLHFuKkqsVFEWpbOfdA != null && !ArrayTools.Contains(ADstVUqTpUMLHFuKkqsVFEWpbOfdA, P_0))
			{
				return false;
			}
			if (QDVFuGavNmAVNIHINOKaCLrDTQgEA.vendorId != P_1)
			{
				return false;
			}
			if (QDVFuGavNmAVNIHINOKaCLrDTQgEA.productId != P_2)
			{
				return false;
			}
			return XMraCyCuWqiyImxYIaXxOkCobiNrA switch
			{
				OwQlcpyGfRXKDKdWhKhwzxmiHJTN.MatchAnyProperty => (SrRRrbeBUTvyXpXAexCBzJNqaUnM & P_3) != 0, 
				OwQlcpyGfRXKDKdWhKhwzxmiHJTN.MatchAllProperties => SrRRrbeBUTvyXpXAexCBzJNqaUnM == P_3, 
				OwQlcpyGfRXKDKdWhKhwzxmiHJTN.IgnoreProperties => true, 
				_ => throw new NotImplementedException(), 
			};
		}
	}

	public enum IQBialDLMBiObHdTIbjQIuoQHpxo
	{
		None = 0,
		Bluetooth = 1,
		USB = 2,
		UsesCustomDriver = 4
	}

	private static Guid[] HueGBAvjgaiXkcCZPIpJxwwYYBhy = new Guid[6]
	{
		new Guid("02D1045E-0000-0000-0000-504944564944"),
		new Guid("02DD045E-0000-0000-0000-504944564944"),
		new Guid("02E3045E-0000-0000-0000-504944564944"),
		new Guid("DEEF045E-0000-0000-0000-504944564944"),
		new Guid("02e0045e-0000-0000-0000-504944564944"),
		new Guid("02ff045e-0000-0000-0000-504944564944")
	};

	private static string[] ibclXcfjSlrFqqaCjIAXphLMhkFX = new string[4] { "Controller (XBOX One For Windows)", "XBOX One For Windows (Controller)", "XBOX One Controller", "Xbox Bluetooth Gamepad" };

	private const string EryjOkbCqdmwIIegwBdzwILaVOjS = ".*xbox[ \\-]one.*";

	private static QNrofIWDGVwXZnyYUAuOpFqavFrA[] RFykkQUWsoCrpWIuelTeeieypAdi;

	private static QNrofIWDGVwXZnyYUAuOpFqavFrA[] mvGKBdrEuXFRZUfKTWcmuKtnKyRQ
	{
		get
		{
			if (RFykkQUWsoCrpWIuelTeeieypAdi == null)
			{
				InputSource[] array = new InputSource[2]
				{
					InputSource.RawInput,
					InputSource.DirectInput
				};
				RFykkQUWsoCrpWIuelTeeieypAdi = new QNrofIWDGVwXZnyYUAuOpFqavFrA[2]
				{
					new QNrofIWDGVwXZnyYUAuOpFqavFrA(QNrofIWDGVwXZnyYUAuOpFqavFrA.SqWAUQhzQPYjklWyJyAYBYpIaqHvA.Allow, array, new PidVid(8201, 1406), IQBialDLMBiObHdTIbjQIuoQHpxo.UsesCustomDriver, QNrofIWDGVwXZnyYUAuOpFqavFrA.OwQlcpyGfRXKDKdWhKhwzxmiHJTN.MatchAnyProperty),
					new QNrofIWDGVwXZnyYUAuOpFqavFrA(QNrofIWDGVwXZnyYUAuOpFqavFrA.SqWAUQhzQPYjklWyJyAYBYpIaqHvA.Deny, array, new PidVid(8201, 1406), (IQBialDLMBiObHdTIbjQIuoQHpxo)3, QNrofIWDGVwXZnyYUAuOpFqavFrA.OwQlcpyGfRXKDKdWhKhwzxmiHJTN.MatchAnyProperty)
				};
			}
			return RFykkQUWsoCrpWIuelTeeieypAdi;
		}
	}

	public static string qeSsqmKLpFsMTLWPbRhxnqBEIese(yBATXoBSRnHIKCFttVvSrbcAKezC P_0, Guid P_1, string P_2, string P_3)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		return zPoPLkmwfqyGcMcFqwuvpaDexivF(P_0.WkndDbQKxUDTUGUDxapJBerOcalY, P_1, P_2, P_3) switch
		{
			XcOkqwrbTtgWlIVcjIfeKlsQNDJTA.CombinedTriggers => "[CombinedTriggers]", 
			XcOkqwrbTtgWlIVcjIfeKlsQNDJTA.SplitTriggers => "[SplitTriggers]", 
			_ => string.Empty, 
		};
	}

	public static XcOkqwrbTtgWlIVcjIfeKlsQNDJTA zPoPLkmwfqyGcMcFqwuvpaDexivF(nyKEGqIoaJkcvwlUxeRaXWfkcuizA[] P_0, Guid P_1, string P_2, string P_3)
	{
		if (!WzImSDjIpMFMSDsXYZoZYwaIeAfP(P_1, P_2, P_3))
		{
			return XcOkqwrbTtgWlIVcjIfeKlsQNDJTA.None;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i].ImiYdubghueuZAsQpoqPiOgRlHMjA == 1 && !P_0[i].JQYthxSbOAuewhAfhjyhSpUrfeJj && P_0[i].TsPqBeKCxbIwKNqIMEUAFXuBxxHC.NhpjJKwLbYtQxAQsxrOFuFjalpAM == 53)
			{
				return XcOkqwrbTtgWlIVcjIfeKlsQNDJTA.SplitTriggers;
			}
		}
		return XcOkqwrbTtgWlIVcjIfeKlsQNDJTA.CombinedTriggers;
	}

	public static bool WzImSDjIpMFMSDsXYZoZYwaIeAfP(Guid P_0, string P_1, string P_2)
	{
		if (Array.IndexOf(HueGBAvjgaiXkcCZPIpJxwwYYBhy, P_0) >= 0)
		{
			return true;
		}
		if (eqedPWBevmgEbwaJgFbhtEJaPcPhb(P_1))
		{
			return true;
		}
		if (eqedPWBevmgEbwaJgFbhtEJaPcPhb(P_2))
		{
			return true;
		}
		return false;
	}

	private static bool eqedPWBevmgEbwaJgFbhtEJaPcPhb(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		for (int i = 0; i < ibclXcfjSlrFqqaCjIAXphLMhkFX.Length; i++)
		{
			if (ibclXcfjSlrFqqaCjIAXphLMhkFX[i].Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}

	public static bool MZNYCCCfmgcBgckrXQqebPUNffxnA(InputSource P_0, ushort P_1, ushort P_2, IQBialDLMBiObHdTIbjQIuoQHpxo P_3)
	{
		for (int i = 0; i < mvGKBdrEuXFRZUfKTWcmuKtnKyRQ.Length; i++)
		{
			if (mvGKBdrEuXFRZUfKTWcmuKtnKyRQ[i].rnMuYJXNQEbdbIbMXYmmJKLPDTGJ(P_0, P_1, P_2, P_3))
			{
				return mvGKBdrEuXFRZUfKTWcmuKtnKyRQ[i].zFEfyFbaEUfZVIDOrvvJQqMoaJSR switch
				{
					QNrofIWDGVwXZnyYUAuOpFqavFrA.SqWAUQhzQPYjklWyJyAYBYpIaqHvA.Allow => true, 
					QNrofIWDGVwXZnyYUAuOpFqavFrA.SqWAUQhzQPYjklWyJyAYBYpIaqHvA.Deny => false, 
					_ => throw new NotImplementedException(), 
				};
			}
		}
		return true;
	}
}
