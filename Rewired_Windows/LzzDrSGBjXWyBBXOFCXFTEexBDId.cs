using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct LzzDrSGBjXWyBBXOFCXFTEexBDId
{
	[FieldOffset(0)]
	private uint QJtbWJmsQvDTuheRkjugdFEZlqzPA;

	[FieldOffset(0)]
	private ulong ZYSgEJJhHOVtDDvNvytsaoguTfvtA;

	[FieldOffset(0)]
	private IntPtr wezedOqExNUjfBXUHDCAQBWebRXo;

	private static readonly bool QCIGAIKgPbRirXFtNWDLfqeSRFXw;

	public static readonly int dfQGoKEbpKEBbdhifzRrGuLOVHjhc;

	static LzzDrSGBjXWyBBXOFCXFTEexBDId()
	{
		dfQGoKEbpKEBbdhifzRrGuLOVHjhc = IntPtr.Size;
		QCIGAIKgPbRirXFtNWDLfqeSRFXw = dfQGoKEbpKEBbdhifzRrGuLOVHjhc == 8;
	}

	public static LzzDrSGBjXWyBBXOFCXFTEexBDId OnuEmrZpDlQHzYcABjMHbpTxJftL(byte[] P_0, int P_1)
	{
		LzzDrSGBjXWyBBXOFCXFTEexBDId result = default(LzzDrSGBjXWyBBXOFCXFTEexBDId);
		if (QCIGAIKgPbRirXFtNWDLfqeSRFXw)
		{
			result.ZYSgEJJhHOVtDDvNvytsaoguTfvtA = BitConverter.ToUInt64(P_0, P_1);
			result.wezedOqExNUjfBXUHDCAQBWebRXo = new IntPtr((long)result.ZYSgEJJhHOVtDDvNvytsaoguTfvtA);
		}
		else
		{
			result.QJtbWJmsQvDTuheRkjugdFEZlqzPA = BitConverter.ToUInt32(P_0, P_1);
			result.wezedOqExNUjfBXUHDCAQBWebRXo = new IntPtr((int)result.QJtbWJmsQvDTuheRkjugdFEZlqzPA);
		}
		return result;
	}

	[SpecialName]
	public static IntPtr zGbaiRbaONCcfBNvNWDQOPblzDjtA(LzzDrSGBjXWyBBXOFCXFTEexBDId P_0)
	{
		return P_0.wezedOqExNUjfBXUHDCAQBWebRXo;
	}

	[SpecialName]
	public static LzzDrSGBjXWyBBXOFCXFTEexBDId QVUcChqoseEMuHGeHNHIHmgaFLkZB(IntPtr P_0)
	{
		LzzDrSGBjXWyBBXOFCXFTEexBDId result = new LzzDrSGBjXWyBBXOFCXFTEexBDId
		{
			wezedOqExNUjfBXUHDCAQBWebRXo = P_0
		};
		if (QCIGAIKgPbRirXFtNWDLfqeSRFXw)
		{
			result.ZYSgEJJhHOVtDDvNvytsaoguTfvtA = (ulong)P_0.ToInt64();
		}
		else
		{
			result.QJtbWJmsQvDTuheRkjugdFEZlqzPA = (uint)P_0.ToInt32();
		}
		return result;
	}

	public string KcuRrzbHzWPTIYcXHWvOkhTPODtc()
	{
		if (QCIGAIKgPbRirXFtNWDLfqeSRFXw)
		{
			return ZYSgEJJhHOVtDDvNvytsaoguTfvtA.ToString();
		}
		return QJtbWJmsQvDTuheRkjugdFEZlqzPA.ToString();
	}

	public int EjpWnxzcZDYqWwYlGcrfQzWsDkVi()
	{
		if (QCIGAIKgPbRirXFtNWDLfqeSRFXw)
		{
			return (int)ZYSgEJJhHOVtDDvNvytsaoguTfvtA;
		}
		return (int)QJtbWJmsQvDTuheRkjugdFEZlqzPA;
	}
}
