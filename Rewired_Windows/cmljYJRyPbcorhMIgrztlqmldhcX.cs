using System;
using System.Runtime.CompilerServices;

internal class cmljYJRyPbcorhMIgrztlqmldhcX : IEquatable<cmljYJRyPbcorhMIgrztlqmldhcX>
{
	private IntPtr cQByPXHktOEEQcWHiomfNOAhovnBA;

	public IntPtr LBdxFigkJISeQizMgNUsybljbbQt => cQByPXHktOEEQcWHiomfNOAhovnBA;

	public bool HCeMhgRrCpdMqQkPrjiFkSEDtfFy => cQByPXHktOEEQcWHiomfNOAhovnBA != IntPtr.Zero;

	public cmljYJRyPbcorhMIgrztlqmldhcX(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			throw new ArgumentException("srcPtr cannot be IntPtr.Zero");
		}
		cQByPXHktOEEQcWHiomfNOAhovnBA = P_0;
	}

	public virtual bool TUUhwhNohplaiUEiVCDOdHDBWioE(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!(P_0 is cmljYJRyPbcorhMIgrztlqmldhcX))
		{
			return false;
		}
		return ((cmljYJRyPbcorhMIgrztlqmldhcX)P_0).cQByPXHktOEEQcWHiomfNOAhovnBA == cQByPXHktOEEQcWHiomfNOAhovnBA;
	}

	public virtual int gfrYsXTKLdJSorvPpvATTQSMrJqv()
	{
		return base.GetHashCode();
	}

	public bool Equals(cmljYJRyPbcorhMIgrztlqmldhcX other)
	{
		if (other == null)
		{
			return false;
		}
		return cQByPXHktOEEQcWHiomfNOAhovnBA == other.cQByPXHktOEEQcWHiomfNOAhovnBA;
	}

	bool IEquatable<cmljYJRyPbcorhMIgrztlqmldhcX>.Equals(cmljYJRyPbcorhMIgrztlqmldhcX other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	[SpecialName]
	public static bool ItHwyJowHJDNDjHACcwOyJeyBjJhA(cmljYJRyPbcorhMIgrztlqmldhcX P_0, cmljYJRyPbcorhMIgrztlqmldhcX P_1)
	{
		if (P_0 == null && P_1 == null)
		{
			return true;
		}
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool rBptxgEPFpRnMSNkjABqtOBKdADiA(cmljYJRyPbcorhMIgrztlqmldhcX P_0, cmljYJRyPbcorhMIgrztlqmldhcX P_1)
	{
		if (P_0 == null && P_1 == null)
		{
			return false;
		}
		if (P_0 == null || P_1 == null)
		{
			return true;
		}
		return !P_0.Equals(P_1);
	}
}
