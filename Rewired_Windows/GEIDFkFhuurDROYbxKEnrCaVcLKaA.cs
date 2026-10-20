using System;
using Rewired.Utils.Classes.Data;

internal class GEIDFkFhuurDROYbxKEnrCaVcLKaA : VJJORtyhxtIZFDAvjUdtXgBUbPYD
{
	public enum MojVwRbdDOrHgSvKhguoolgHBdNJ
	{
		Default = 0,
		Custom = 1
	}

	public int ojdUFvHjVMRgcxFnkxPIwdrsHUUm;

	public double ZxGZSjVajvLXNJtBcsttVeRbzRKy;

	public readonly int AqtTIDqjBERKUIqlSOUdfPVXxBfj;

	public readonly int bHeBOzcDjuFhXMZZoazGOSeXYPRy;

	public readonly MojVwRbdDOrHgSvKhguoolgHBdNJ ZvbdnQcvzmUmHAwHlTuSZazBNFqw;

	private Func<int, int> FxFwsoDZdvCMzINGlhkDeMCNfJXB;

	public GEIDFkFhuurDROYbxKEnrCaVcLKaA(byte P_0, HIDInfo P_1, MojVwRbdDOrHgSvKhguoolgHBdNJ P_2)
		: base(P_0, P_1)
	{
		ZvbdnQcvzmUmHAwHlTuSZazBNFqw = P_2;
		AqtTIDqjBERKUIqlSOUdfPVXxBfj = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
		bHeBOzcDjuFhXMZZoazGOSeXYPRy = P_1.dataIndex;
	}

	public GEIDFkFhuurDROYbxKEnrCaVcLKaA(byte P_0, HIDInfo P_1, Func<int, int> P_2)
		: this(P_0, P_1, MojVwRbdDOrHgSvKhguoolgHBdNJ.Custom)
	{
		FxFwsoDZdvCMzINGlhkDeMCNfJXB = P_2;
	}

	public virtual void fnCvAuoliQpoGAxASndrKdYfUiUq(NativeBuffer P_0, double P_1)
	{
		if (P_0 == null || P_0[0] != vKgAOBqhKKHeEXCKnijETKCeeaEg)
		{
			return;
		}
		ZxGZSjVajvLXNJtBcsttVeRbzRKy = P_1;
		if (AqtTIDqjBERKUIqlSOUdfPVXxBfj == 1)
		{
			ojdUFvHjVMRgcxFnkxPIwdrsHUUm = P_0[bHeBOzcDjuFhXMZZoazGOSeXYPRy];
		}
		else
		{
			ojdUFvHjVMRgcxFnkxPIwdrsHUUm = 0;
			for (int i = 0; i < AqtTIDqjBERKUIqlSOUdfPVXxBfj; i++)
			{
				ojdUFvHjVMRgcxFnkxPIwdrsHUUm |= P_0[bHeBOzcDjuFhXMZZoazGOSeXYPRy + i] << 8 * i;
			}
		}
		if (ZvbdnQcvzmUmHAwHlTuSZazBNFqw == MojVwRbdDOrHgSvKhguoolgHBdNJ.Custom && FxFwsoDZdvCMzINGlhkDeMCNfJXB != null)
		{
			ojdUFvHjVMRgcxFnkxPIwdrsHUUm = FxFwsoDZdvCMzINGlhkDeMCNfJXB(ojdUFvHjVMRgcxFnkxPIwdrsHUUm);
		}
	}
}
