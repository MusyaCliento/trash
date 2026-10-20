using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct bQeeYnhekHKrLpkQnFvOzCLdkhgBb
{
	private int HlBuCHMIXJgIyxlmGoAnZUaSsDyo;

	private const int SsIXJKQbvGjSLHZhIdInHGXIcozcA = 65534;

	private const int zYVuxuEpgeGpEuyYEDCnRhPFOXtr = 16776960;

	public JBcFUjjKPNSJZpmwjTspczQHewI VNUwtRupLmFpCYlBzOWAwSxmRjMG => (JBcFUjjKPNSJZpmwjTspczQHewI)(HlBuCHMIXJgIyxlmGoAnZUaSsDyo & -16776961);

	public int TVblmQHJokpbakNLysjmgVHjRPQS => (HlBuCHMIXJgIyxlmGoAnZUaSsDyo >> 8) & 0xFFFF;

	public bQeeYnhekHKrLpkQnFvOzCLdkhgBb(JBcFUjjKPNSJZpmwjTspczQHewI P_0, int P_1)
	{
		this = default(bQeeYnhekHKrLpkQnFvOzCLdkhgBb);
		HlBuCHMIXJgIyxlmGoAnZUaSsDyo = (int)(P_0 & ~JBcFUjjKPNSJZpmwjTspczQHewI.AnyInstance) | ((!(P_1 < 0 || P_1 > 65534)) ? ((P_1 & 0xFFFF) << 8) : 0);
	}

	[SpecialName]
	public static int FUECnPukFDLHMdGhxZfdQRjgotlS(bQeeYnhekHKrLpkQnFvOzCLdkhgBb P_0)
	{
		return P_0.HlBuCHMIXJgIyxlmGoAnZUaSsDyo;
	}

	public bool BvzAhgbpUIMrJWzledJzRJrqLMiab(bQeeYnhekHKrLpkQnFvOzCLdkhgBb P_0)
	{
		return P_0.HlBuCHMIXJgIyxlmGoAnZUaSsDyo == HlBuCHMIXJgIyxlmGoAnZUaSsDyo;
	}

	public bool LKRTxxEMJHHsoHiroSUTJwsoTbvg(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(bQeeYnhekHKrLpkQnFvOzCLdkhgBb))
		{
			return false;
		}
		return BvzAhgbpUIMrJWzledJzRJrqLMiab((bQeeYnhekHKrLpkQnFvOzCLdkhgBb)P_0);
	}

	public int XkxGCaJqjnUZfkXSzHqaFmDjHPPqA()
	{
		return HlBuCHMIXJgIyxlmGoAnZUaSsDyo;
	}

	public string ZoCJpSmLBuBeeOtbknXPGCqqTzKm()
	{
		return string.Format(CultureInfo.InvariantCulture, "Flags: {0} InstanceNumber: {1} RawId: 0x{2:X8}", VNUwtRupLmFpCYlBzOWAwSxmRjMG, TVblmQHJokpbakNLysjmgVHjRPQS, HlBuCHMIXJgIyxlmGoAnZUaSsDyo);
	}
}
