using System;
using System.Runtime.CompilerServices;

internal struct BzvjmeKYOGnWYbWlpeNRiYsgnbel
{
	private int izHTTDqODLfkMLujTlVBPDOEqdsC;

	private long vjqlqGaipULNrhJmLEAiTANKywTV;

	private static readonly bool CwhnlLcHcOvEBlvdZMsexyQdsTUo;

	public static readonly int QcGdFBiOtDqMLGnylfZBkKFNnUHL;

	static BzvjmeKYOGnWYbWlpeNRiYsgnbel()
	{
		CwhnlLcHcOvEBlvdZMsexyQdsTUo = IntPtr.Size == 8;
		QcGdFBiOtDqMLGnylfZBkKFNnUHL = (CwhnlLcHcOvEBlvdZMsexyQdsTUo ? 8 : 4);
	}

	public static BzvjmeKYOGnWYbWlpeNRiYsgnbel sBxDXNqvZgukxzeRLLmaoSNHDcKF(byte[] P_0, int P_1)
	{
		BzvjmeKYOGnWYbWlpeNRiYsgnbel result = default(BzvjmeKYOGnWYbWlpeNRiYsgnbel);
		if (CwhnlLcHcOvEBlvdZMsexyQdsTUo)
		{
			result.vjqlqGaipULNrhJmLEAiTANKywTV = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.izHTTDqODLfkMLujTlVBPDOEqdsC = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static int bGYoyqhEMejnsqolLiNiykwrGZDB(BzvjmeKYOGnWYbWlpeNRiYsgnbel P_0)
	{
		if (CwhnlLcHcOvEBlvdZMsexyQdsTUo)
		{
			return (int)P_0.vjqlqGaipULNrhJmLEAiTANKywTV;
		}
		return P_0.izHTTDqODLfkMLujTlVBPDOEqdsC;
	}

	[SpecialName]
	public static long bGYoyqhEMejnsqolLiNiykwrGZDB(BzvjmeKYOGnWYbWlpeNRiYsgnbel P_0)
	{
		if (CwhnlLcHcOvEBlvdZMsexyQdsTUo)
		{
			return P_0.vjqlqGaipULNrhJmLEAiTANKywTV;
		}
		return P_0.izHTTDqODLfkMLujTlVBPDOEqdsC;
	}

	public string xgLqoJBnecyqMngmoSkFDwBSZQZI()
	{
		if (CwhnlLcHcOvEBlvdZMsexyQdsTUo)
		{
			return vjqlqGaipULNrhJmLEAiTANKywTV.ToString();
		}
		return izHTTDqODLfkMLujTlVBPDOEqdsC.ToString();
	}
}
