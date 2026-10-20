using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct YtZbTuQWOhHtiIzeVCefDxzcOtoOc : IEquatable<YtZbTuQWOhHtiIzeVCefDxzcOtoOc>
{
	private int wuGrDwAoAGJgPFSrzMNQgMogUfpq;

	public YtZbTuQWOhHtiIzeVCefDxzcOtoOc(bool P_0)
	{
		wuGrDwAoAGJgPFSrzMNQgMogUfpq = (P_0 ? 1 : 0);
	}

	public bool Equals(YtZbTuQWOhHtiIzeVCefDxzcOtoOc other)
	{
		return wuGrDwAoAGJgPFSrzMNQgMogUfpq == other.wuGrDwAoAGJgPFSrzMNQgMogUfpq;
	}

	bool IEquatable<YtZbTuQWOhHtiIzeVCefDxzcOtoOc>.Equals(YtZbTuQWOhHtiIzeVCefDxzcOtoOc other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool wTUgVkuDKNjawxiuqHengzUNQHEu(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0 is YtZbTuQWOhHtiIzeVCefDxzcOtoOc)
		{
			return Equals((YtZbTuQWOhHtiIzeVCefDxzcOtoOc)P_0);
		}
		return false;
	}

	public int XnruGIGPkfQXlHlqXTcGvLFhAODV()
	{
		return wuGrDwAoAGJgPFSrzMNQgMogUfpq;
	}

	[SpecialName]
	public static bool qCFFTTLHSxthUqdnTqqOMHjMIAcfA(YtZbTuQWOhHtiIzeVCefDxzcOtoOc P_0, YtZbTuQWOhHtiIzeVCefDxzcOtoOc P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool MwdPFcWsALSqfBGlJIOYuizOFUFHA(YtZbTuQWOhHtiIzeVCefDxzcOtoOc P_0, YtZbTuQWOhHtiIzeVCefDxzcOtoOc P_1)
	{
		return !P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool fBCTUbsqykzHDPaRFbUnEPtozeKk(YtZbTuQWOhHtiIzeVCefDxzcOtoOc P_0)
	{
		return P_0.wuGrDwAoAGJgPFSrzMNQgMogUfpq != 0;
	}

	[SpecialName]
	public static YtZbTuQWOhHtiIzeVCefDxzcOtoOc abgkPoAGFXVDJIKrRAPmWTWudiKs(bool P_0)
	{
		return new YtZbTuQWOhHtiIzeVCefDxzcOtoOc(P_0);
	}

	public string xxKzakPJxAhvjCOOpHAZsawDzdQD()
	{
		return $"{wuGrDwAoAGJgPFSrzMNQgMogUfpq != 0}";
	}
}
