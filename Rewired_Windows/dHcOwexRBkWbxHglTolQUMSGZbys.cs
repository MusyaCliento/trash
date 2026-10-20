using System;
using Rewired.Utils.Classes.Data;

internal class dHcOwexRBkWbxHglTolQUMSGZbys : VJJORtyhxtIZFDAvjUdtXgBUbPYD
{
	public readonly float[] WuxcudBBVzHNVwoaaucXfPaFfSOU;

	public double UwdPDVljMyjJhPVCGQkCkvfsleAq;

	public readonly int XLQqfQnSYLtjziJzACIRzDPlXBhT;

	private readonly byte[] lMuBrfYvKLHpHrEHdMdfrqXwrJhJ;

	private readonly int hmJxKSRAKRNGSzciaeJDdgCGdkXQA;

	private readonly int dtCQUMetoXyLNJaluznfUhjVQxsH;

	private readonly Action<byte[], float[]> DpiUloFMrObmBjAvRloMryhjsSPO;

	public dHcOwexRBkWbxHglTolQUMSGZbys(byte P_0, HIDInfo P_1, int P_2, Action<byte[], float[]> P_3)
		: base(P_0, P_1)
	{
		XLQqfQnSYLtjziJzACIRzDPlXBhT = P_2;
		DpiUloFMrObmBjAvRloMryhjsSPO = P_3;
		hmJxKSRAKRNGSzciaeJDdgCGdkXQA = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
		dtCQUMetoXyLNJaluznfUhjVQxsH = P_1.dataIndex;
		lMuBrfYvKLHpHrEHdMdfrqXwrJhJ = new byte[hmJxKSRAKRNGSzciaeJDdgCGdkXQA];
		WuxcudBBVzHNVwoaaucXfPaFfSOU = new float[P_2];
	}

	public virtual void RXHHSBbkkpaaPLdaRabbxrBcaPYR(NativeBuffer P_0, double P_1)
	{
		if (P_0 != null && P_0[0] == vKgAOBqhKKHeEXCKnijETKCeeaEg)
		{
			UwdPDVljMyjJhPVCGQkCkvfsleAq = P_1;
			for (int i = 0; i < hmJxKSRAKRNGSzciaeJDdgCGdkXQA; i++)
			{
				lMuBrfYvKLHpHrEHdMdfrqXwrJhJ[i] = P_0[dtCQUMetoXyLNJaluznfUhjVQxsH + i];
			}
			if (DpiUloFMrObmBjAvRloMryhjsSPO != null)
			{
				DpiUloFMrObmBjAvRloMryhjsSPO(lMuBrfYvKLHpHrEHdMdfrqXwrJhJ, WuxcudBBVzHNVwoaaucXfPaFfSOU);
			}
		}
	}

	public void lCMbVdYrRDsZEXRotgPWhTFVklyO(float[] P_0, double P_1)
	{
		UwdPDVljMyjJhPVCGQkCkvfsleAq = P_1;
		for (int i = 0; i < XLQqfQnSYLtjziJzACIRzDPlXBhT; i++)
		{
			WuxcudBBVzHNVwoaaucXfPaFfSOU[i] = P_0[i];
		}
	}
}
