using System;
using System.Runtime.CompilerServices;

internal struct ALeXJoxuTpodABrxyMLinkcQjXxgA : IEquatable<ALeXJoxuTpodABrxyMLinkcQjXxgA>
{
	public static readonly ALeXJoxuTpodABrxyMLinkcQjXxgA iZHKWlMiDPQNNdaPIGTyAwASxkoG = new ALeXJoxuTpodABrxyMLinkcQjXxgA(0f, 0f);

	public static readonly ALeXJoxuTpodABrxyMLinkcQjXxgA HRWzrltZFcCduEBijwdXipTXexUR = iZHKWlMiDPQNNdaPIGTyAwASxkoG;

	public float xgOgLdeMqzdafopQPkkZoTJWTQzbA;

	public float PdHjgQTzDGmfkGzXvYmAwMbrYRIh;

	public ALeXJoxuTpodABrxyMLinkcQjXxgA(float P_0, float P_1)
	{
		xgOgLdeMqzdafopQPkkZoTJWTQzbA = P_0;
		PdHjgQTzDGmfkGzXvYmAwMbrYRIh = P_1;
	}

	public bool Equals(ALeXJoxuTpodABrxyMLinkcQjXxgA other)
	{
		if (other.xgOgLdeMqzdafopQPkkZoTJWTQzbA == xgOgLdeMqzdafopQPkkZoTJWTQzbA)
		{
			return other.PdHjgQTzDGmfkGzXvYmAwMbrYRIh == PdHjgQTzDGmfkGzXvYmAwMbrYRIh;
		}
		return false;
	}

	bool IEquatable<ALeXJoxuTpodABrxyMLinkcQjXxgA>.Equals(ALeXJoxuTpodABrxyMLinkcQjXxgA other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool xRbLfXNVvCjuxXRmbuFRXdocdbkn(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(ALeXJoxuTpodABrxyMLinkcQjXxgA))
		{
			return false;
		}
		return Equals((ALeXJoxuTpodABrxyMLinkcQjXxgA)P_0);
	}

	public int iFgCTgqkxjxYotaZOFxhzzdQmMso()
	{
		return (xgOgLdeMqzdafopQPkkZoTJWTQzbA.GetHashCode() * 397) ^ PdHjgQTzDGmfkGzXvYmAwMbrYRIh.GetHashCode();
	}

	[SpecialName]
	public static bool TkdSdkzzoSGKDgHgDILfIzbXbFOI(ALeXJoxuTpodABrxyMLinkcQjXxgA P_0, ALeXJoxuTpodABrxyMLinkcQjXxgA P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool JHDEtvExXVeBwQAnlpylDtLvjPIGA(ALeXJoxuTpodABrxyMLinkcQjXxgA P_0, ALeXJoxuTpodABrxyMLinkcQjXxgA P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string lRFmZCvjCYlRhVbDBWhdgDvWtEhh()
	{
		return $"({xgOgLdeMqzdafopQPkkZoTJWTQzbA},{PdHjgQTzDGmfkGzXvYmAwMbrYRIh})";
	}
}
