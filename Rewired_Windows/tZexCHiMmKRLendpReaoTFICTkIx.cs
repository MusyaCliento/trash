using System.Collections.Generic;
using Rewired.Utils;

internal class tZexCHiMmKRLendpReaoTFICTkIx : HDBCccmhGrnyJeNxDcBEeidlIFlE
{
	private List<MnaHAmpYqtfMcXepIIeEBIgLxVTdA> RdhlYvLlylaxCMBSFGbqaAjcqpxIb;

	private MnaHAmpYqtfMcXepIIeEBIgLxVTdA[] hbdIOnKPdikyiKzKbcxPYZxmHoNhA;

	private bool rzRECNbqJrdpCeEdYGDRdJeqFISOA;

	public tZexCHiMmKRLendpReaoTFICTkIx()
	{
		RdhlYvLlylaxCMBSFGbqaAjcqpxIb = new List<MnaHAmpYqtfMcXepIIeEBIgLxVTdA>();
	}

	public virtual void ZbxjLSCCzzgIzakNjqEJYnMbXthgA(MnaHAmpYqtfMcXepIIeEBIgLxVTdA P_0)
	{
		RdhlYvLlylaxCMBSFGbqaAjcqpxIb.Add(P_0);
	}

	public float QjGFqvUpJysGPNpweKGAkRnYetOf(int P_0)
	{
		if (P_0 < 0 || P_0 >= hbdIOnKPdikyiKzKbcxPYZxmHoNhA.Length)
		{
			return 0f;
		}
		return fQiqdQAcMDNtvdegueOzjCDMbhgDA(hbdIOnKPdikyiKzKbcxPYZxmHoNhA[P_0].jEFlyDXIwwFDAiTgrhRxpmjLofKE);
	}

	public int fkqpteCWHcvxYVDRpxSyWoZYwAmu(int P_0)
	{
		if (P_0 < 0 || P_0 >= hbdIOnKPdikyiKzKbcxPYZxmHoNhA.Length)
		{
			return 0;
		}
		return (int)hbdIOnKPdikyiKzKbcxPYZxmHoNhA[P_0].wROXyNkwvamIBGsmbGPHLFCyKJUr;
	}

	public virtual void KhkIXcDBuJHxDgMXpilpzKgDMbGb()
	{
		if (!rzRECNbqJrdpCeEdYGDRdJeqFISOA)
		{
			rzRECNbqJrdpCeEdYGDRdJeqFISOA = true;
			hbdIOnKPdikyiKzKbcxPYZxmHoNhA = RdhlYvLlylaxCMBSFGbqaAjcqpxIb.ToArray();
			RdhlYvLlylaxCMBSFGbqaAjcqpxIb = null;
		}
	}

	private static float fQiqdQAcMDNtvdegueOzjCDMbhgDA(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
