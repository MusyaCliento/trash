using System;
using System.Runtime.CompilerServices;

internal struct cFIhkPDgFlbMcicZnVWnYJgfJlYJA : IEquatable<cFIhkPDgFlbMcicZnVWnYJgfJlYJA>
{
	public static readonly cFIhkPDgFlbMcicZnVWnYJgfJlYJA QtofZcUtjbteRqhYHCCbKJXnclnd = new cFIhkPDgFlbMcicZnVWnYJgfJlYJA(0, 0);

	public int sOPzDtIfxUcOsDVyZhKtvizrLDceb;

	public int tVqhOsXYqUTVLqHcWBprDvpsvDmc;

	public cFIhkPDgFlbMcicZnVWnYJgfJlYJA(int P_0, int P_1)
	{
		sOPzDtIfxUcOsDVyZhKtvizrLDceb = P_0;
		tVqhOsXYqUTVLqHcWBprDvpsvDmc = P_1;
	}

	public bool Equals(cFIhkPDgFlbMcicZnVWnYJgfJlYJA other)
	{
		if (other.sOPzDtIfxUcOsDVyZhKtvizrLDceb == sOPzDtIfxUcOsDVyZhKtvizrLDceb)
		{
			return other.tVqhOsXYqUTVLqHcWBprDvpsvDmc == tVqhOsXYqUTVLqHcWBprDvpsvDmc;
		}
		return false;
	}

	bool IEquatable<cFIhkPDgFlbMcicZnVWnYJgfJlYJA>.Equals(cFIhkPDgFlbMcicZnVWnYJgfJlYJA other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool AuYhdhrktGqnTbWKGLZIKCEWojZo(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(cFIhkPDgFlbMcicZnVWnYJgfJlYJA))
		{
			return false;
		}
		return Equals((cFIhkPDgFlbMcicZnVWnYJgfJlYJA)P_0);
	}

	public int pkVCdEmHfjjjgzJydayOCDLyBQnq()
	{
		return (sOPzDtIfxUcOsDVyZhKtvizrLDceb * 397) ^ tVqhOsXYqUTVLqHcWBprDvpsvDmc;
	}

	[SpecialName]
	public static bool piwAQDKzFYkTpnlsicGQwLhmebKab(cFIhkPDgFlbMcicZnVWnYJgfJlYJA P_0, cFIhkPDgFlbMcicZnVWnYJgfJlYJA P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool FowDBtQxclOmYhyYbdTeEIsKVbNW(cFIhkPDgFlbMcicZnVWnYJgfJlYJA P_0, cFIhkPDgFlbMcicZnVWnYJgfJlYJA P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string mEaADDTbcMRhoSIFnxfeJPQIlyIT()
	{
		return $"({sOPzDtIfxUcOsDVyZhKtvizrLDceb},{tVqhOsXYqUTVLqHcWBprDvpsvDmc})";
	}
}
