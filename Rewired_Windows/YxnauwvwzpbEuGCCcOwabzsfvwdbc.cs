using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct YxnauwvwzpbEuGCCcOwabzsfvwdbc
{
	[FieldOffset(0)]
	private int YoxeFOyQWCSPnPhUrtlgitHSLfDn;

	[FieldOffset(0)]
	private long PUSxjGulrObZjtENDlYdazsSnoci;

	[FieldOffset(0)]
	private IntPtr usNBGaJNjYwRwSTeQbFdCSyBeNXfb;

	private static readonly bool fVDECbHltausEWkUltxsEBdsqiaY;

	public static readonly int SxGDBKfTUNFFvAzyyLAbsFETlQQf;

	static YxnauwvwzpbEuGCCcOwabzsfvwdbc()
	{
		SxGDBKfTUNFFvAzyyLAbsFETlQQf = IntPtr.Size;
		fVDECbHltausEWkUltxsEBdsqiaY = SxGDBKfTUNFFvAzyyLAbsFETlQQf == 8;
	}

	public static YxnauwvwzpbEuGCCcOwabzsfvwdbc fzXfIdHKOhKUYNFIWOUYxZWjjDFfA(byte[] P_0, int P_1)
	{
		YxnauwvwzpbEuGCCcOwabzsfvwdbc result = default(YxnauwvwzpbEuGCCcOwabzsfvwdbc);
		if (fVDECbHltausEWkUltxsEBdsqiaY)
		{
			result.PUSxjGulrObZjtENDlYdazsSnoci = BitConverter.ToInt64(P_0, P_1);
			result.usNBGaJNjYwRwSTeQbFdCSyBeNXfb = new IntPtr(result.PUSxjGulrObZjtENDlYdazsSnoci);
		}
		else
		{
			result.YoxeFOyQWCSPnPhUrtlgitHSLfDn = BitConverter.ToInt32(P_0, P_1);
			result.usNBGaJNjYwRwSTeQbFdCSyBeNXfb = new IntPtr(result.YoxeFOyQWCSPnPhUrtlgitHSLfDn);
		}
		return result;
	}

	[SpecialName]
	public static YxnauwvwzpbEuGCCcOwabzsfvwdbc mRuhmGTfsoQHVLTfewsqXkAQfJjw(IntPtr P_0)
	{
		YxnauwvwzpbEuGCCcOwabzsfvwdbc result = new YxnauwvwzpbEuGCCcOwabzsfvwdbc
		{
			usNBGaJNjYwRwSTeQbFdCSyBeNXfb = P_0
		};
		if (fVDECbHltausEWkUltxsEBdsqiaY)
		{
			result.PUSxjGulrObZjtENDlYdazsSnoci = P_0.ToInt64();
		}
		else
		{
			result.YoxeFOyQWCSPnPhUrtlgitHSLfDn = P_0.ToInt32();
		}
		return result;
	}

	[SpecialName]
	public static IntPtr maVGGvYhadoOfJHgNbWYYTSZqtaH(YxnauwvwzpbEuGCCcOwabzsfvwdbc P_0)
	{
		return P_0.usNBGaJNjYwRwSTeQbFdCSyBeNXfb;
	}

	public string KwkpYwMVYAHGmeANDzeEsReyAIvL()
	{
		if (fVDECbHltausEWkUltxsEBdsqiaY)
		{
			return PUSxjGulrObZjtENDlYdazsSnoci.ToString();
		}
		return YoxeFOyQWCSPnPhUrtlgitHSLfDn.ToString();
	}
}
