using System;
using System.Runtime.CompilerServices;

internal struct zpkwaJVePPJNMwjsaYpXIzwlGrzC : IEquatable<zpkwaJVePPJNMwjsaYpXIzwlGrzC>
{
	public static readonly zpkwaJVePPJNMwjsaYpXIzwlGrzC TXQuDXTNPzLYqPppSrsffCippILy = new zpkwaJVePPJNMwjsaYpXIzwlGrzC(0, 0);

	public static readonly zpkwaJVePPJNMwjsaYpXIzwlGrzC rNPoNwNVXnZLPBBLlbDfAXnNAnaB = TXQuDXTNPzLYqPppSrsffCippILy;

	public int LHMFafEpnFBLxxPCGNGVMlvCEtfZA;

	public int kMyiWbbalDjaedocnMnagRbgrcdgA;

	public zpkwaJVePPJNMwjsaYpXIzwlGrzC(int P_0, int P_1)
	{
		LHMFafEpnFBLxxPCGNGVMlvCEtfZA = P_0;
		kMyiWbbalDjaedocnMnagRbgrcdgA = P_1;
	}

	public bool Equals(zpkwaJVePPJNMwjsaYpXIzwlGrzC other)
	{
		if (other.LHMFafEpnFBLxxPCGNGVMlvCEtfZA == LHMFafEpnFBLxxPCGNGVMlvCEtfZA)
		{
			return other.kMyiWbbalDjaedocnMnagRbgrcdgA == kMyiWbbalDjaedocnMnagRbgrcdgA;
		}
		return false;
	}

	bool IEquatable<zpkwaJVePPJNMwjsaYpXIzwlGrzC>.Equals(zpkwaJVePPJNMwjsaYpXIzwlGrzC other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool zTVaFLPsAmMhMWwUjCAVOXTxdNQp(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(zpkwaJVePPJNMwjsaYpXIzwlGrzC))
		{
			return false;
		}
		return Equals((zpkwaJVePPJNMwjsaYpXIzwlGrzC)P_0);
	}

	public int LsjGWGbbbCYLXpLWLBwqduaGIMwRA()
	{
		return (LHMFafEpnFBLxxPCGNGVMlvCEtfZA * 397) ^ kMyiWbbalDjaedocnMnagRbgrcdgA;
	}

	[SpecialName]
	public static bool SPMGfEJgyVyUYTvKilJbQWtHiwAB(zpkwaJVePPJNMwjsaYpXIzwlGrzC P_0, zpkwaJVePPJNMwjsaYpXIzwlGrzC P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool FuzGpqbSQefsbeXhGEzlmDBsprjNB(zpkwaJVePPJNMwjsaYpXIzwlGrzC P_0, zpkwaJVePPJNMwjsaYpXIzwlGrzC P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string POcqXHXbjCoGPMDPFmbCauQVXESK()
	{
		return $"({LHMFafEpnFBLxxPCGNGVMlvCEtfZA},{kMyiWbbalDjaedocnMnagRbgrcdgA})";
	}
}
