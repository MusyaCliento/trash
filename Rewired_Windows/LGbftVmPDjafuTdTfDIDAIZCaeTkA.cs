using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class LGbftVmPDjafuTdTfDIDAIZCaeTkA : IDisposable
{
	private readonly byte[] liBwCCxdlFtjrqHtEFjnFxqswpxnA;

	public readonly int bfVAyCEKJmhTitpvgEUfFFmWJYiV;

	private GCHandle dVjNknnNTUmEfYCMoOQkeBEIZaDc;

	private bool gIdXasrhXsUWRcMKuRcYrSOmkqmF;

	public bool suEKDwqvidPMgmMcIGTZdUiJybWSA => dVjNknnNTUmEfYCMoOQkeBEIZaDc.IsAllocated;

	public byte hEEqipIGvAOylBNvomHVyZaIdRNb
	{
		get
		{
			return liBwCCxdlFtjrqHtEFjnFxqswpxnA[P_0];
		}
		set
		{
			liBwCCxdlFtjrqHtEFjnFxqswpxnA[num] = b;
		}
	}

	public LGbftVmPDjafuTdTfDIDAIZCaeTkA(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size must be > 0");
		}
		bfVAyCEKJmhTitpvgEUfFFmWJYiV = P_0;
		liBwCCxdlFtjrqHtEFjnFxqswpxnA = new byte[P_0];
	}

	public IntPtr fdfKNlwaFJTSkhhcxRGISGLvksZw()
	{
		if (dVjNknnNTUmEfYCMoOQkeBEIZaDc.IsAllocated)
		{
			return dVjNknnNTUmEfYCMoOQkeBEIZaDc.AddrOfPinnedObject();
		}
		dVjNknnNTUmEfYCMoOQkeBEIZaDc = GCHandle.Alloc(liBwCCxdlFtjrqHtEFjnFxqswpxnA, GCHandleType.Pinned);
		return dVjNknnNTUmEfYCMoOQkeBEIZaDc.AddrOfPinnedObject();
	}

	public void XYYxUhOvtVuwOvOKGrMINsmyqFKS()
	{
		if (dVjNknnNTUmEfYCMoOQkeBEIZaDc.IsAllocated)
		{
			dVjNknnNTUmEfYCMoOQkeBEIZaDc.Free();
		}
	}

	public string gDjTDGiAYuELyDyhWKmAMtefPRDx()
	{
		string text = "";
		for (int i = 0; i < bfVAyCEKJmhTitpvgEUfFFmWJYiV; i++)
		{
			text = text + liBwCCxdlFtjrqHtEFjnFxqswpxnA[i].ToString("x2") + " ";
		}
		return text;
	}

	public bool kooksotfSRTOemZzbXZWrdICFejf(int P_0, byte P_1)
	{
		if (1 + P_0 > bfVAyCEKJmhTitpvgEUfFFmWJYiV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (liBwCCxdlFtjrqHtEFjnFxqswpxnA[P_0] & (1 << (int)P_1)) != 0;
	}

	public byte vxOSeWpEBdDZcRFlsamtSMOkOwgQ(int P_0)
	{
		if (1 + P_0 > bfVAyCEKJmhTitpvgEUfFFmWJYiV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return liBwCCxdlFtjrqHtEFjnFxqswpxnA[P_0];
	}

	public unsafe short hnWjSXVakdUppTlVCyEZzrqqKKiT(int P_0)
	{
		if (2 + P_0 > bfVAyCEKJmhTitpvgEUfFFmWJYiV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = liBwCCxdlFtjrqHtEFjnFxqswpxnA)
		{
			return *(short*)(ptr + P_0);
		}
	}

	public unsafe ushort IVxIQfVnJMzuXOwegLzweTAwYclf(int P_0)
	{
		if (2 + P_0 > bfVAyCEKJmhTitpvgEUfFFmWJYiV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = liBwCCxdlFtjrqHtEFjnFxqswpxnA)
		{
			return *(ushort*)(ptr + P_0);
		}
	}

	public unsafe int zaSZKEshUwbGuqRdEFPTBTtFMrrZ(int P_0)
	{
		if (4 + P_0 > bfVAyCEKJmhTitpvgEUfFFmWJYiV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = liBwCCxdlFtjrqHtEFjnFxqswpxnA)
		{
			return *(int*)(ptr + P_0);
		}
	}

	public unsafe uint tZxgSLKzbZzhPYJMmVebYlrZKKqr(int P_0)
	{
		if (4 + P_0 > bfVAyCEKJmhTitpvgEUfFFmWJYiV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = liBwCCxdlFtjrqHtEFjnFxqswpxnA)
		{
			return *(uint*)(ptr + P_0);
		}
	}

	public unsafe long rMslGvwxIOMhysTGMrqexkHKcTTg(int P_0)
	{
		if (8 + P_0 > bfVAyCEKJmhTitpvgEUfFFmWJYiV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = liBwCCxdlFtjrqHtEFjnFxqswpxnA)
		{
			return *(long*)(ptr + P_0);
		}
	}

	public unsafe ulong mGXFwaklHYbJZdLrmPTxQZbecuTh(int P_0)
	{
		if (8 + P_0 > bfVAyCEKJmhTitpvgEUfFFmWJYiV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = liBwCCxdlFtjrqHtEFjnFxqswpxnA)
		{
			return *(ulong*)(ptr + P_0);
		}
	}

	public void bAKVZGjrcJoKBiNalhYuGSafCLHqA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("bytes");
		}
		int num = P_0.Length;
		if (num <= 0)
		{
			throw new ArgumentOutOfRangeException("bytes.Length must be > 0.");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be > 0");
		}
		if (P_1 > num)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be <= bufferLength.");
		}
		if (P_1 > bfVAyCEKJmhTitpvgEUfFFmWJYiV)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be <= Length.");
		}
		if (P_3 >= num)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be < bufferLength.");
		}
		if (P_3 < 0)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
		}
		if (P_2 >= bfVAyCEKJmhTitpvgEUfFFmWJYiV)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be < Length.");
		}
		if (P_2 < 0)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
		}
		if (P_3 + P_1 > num)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex + numBytesToRead must be < bufferLength.");
		}
		if (P_1 + P_2 > bfVAyCEKJmhTitpvgEUfFFmWJYiV)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		Array.Copy(liBwCCxdlFtjrqHtEFjnFxqswpxnA, P_2, P_0, P_3, P_1);
	}

	public void QXmOBsjmGJEMTjVEOwoJKMwEoIXeA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			throw new ArgumentNullException("bytes");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("bufferLength must be > 0.");
		}
		if (P_2 <= 0)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be > 0");
		}
		if (P_2 > P_1)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be <= bufferLength.");
		}
		if (P_2 > bfVAyCEKJmhTitpvgEUfFFmWJYiV)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be <= Length.");
		}
		if (P_4 >= P_1)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be < bufferLength.");
		}
		if (P_4 < 0)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
		}
		if (P_3 >= bfVAyCEKJmhTitpvgEUfFFmWJYiV)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be < Length.");
		}
		if (P_3 < 0)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
		}
		if (P_4 + P_2 > P_1)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex + numBytesToRead must be < bufferLength.");
		}
		if (P_2 + P_3 > bfVAyCEKJmhTitpvgEUfFFmWJYiV)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(liBwCCxdlFtjrqHtEFjnFxqswpxnA, P_0, P_3, P_4, P_2);
	}

	public int EqndrCuikdqdVYJVsFQjsAvEeQxh(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0)
		{
			return 0;
		}
		if (P_2 >= bfVAyCEKJmhTitpvgEUfFFmWJYiV)
		{
			return 0;
		}
		if (P_3 >= num)
		{
			return 0;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_2 + P_1 > bfVAyCEKJmhTitpvgEUfFFmWJYiV)
		{
			P_1 = bfVAyCEKJmhTitpvgEUfFFmWJYiV - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		Array.Copy(liBwCCxdlFtjrqHtEFjnFxqswpxnA, P_2, P_0, P_3, P_1);
		return P_1;
	}

	public int leiGOnYhAZDRQlLVNkxFMalUlTsA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= bfVAyCEKJmhTitpvgEUfFFmWJYiV)
		{
			return 0;
		}
		if (P_4 >= P_1)
		{
			return 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_4 < 0)
		{
			P_4 = 0;
		}
		if (P_3 + P_2 > bfVAyCEKJmhTitpvgEUfFFmWJYiV)
		{
			P_2 = bfVAyCEKJmhTitpvgEUfFFmWJYiV - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		NativeTools.CopyMemory(liBwCCxdlFtjrqHtEFjnFxqswpxnA, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public void MldajIKYwdkMOHRrQbZvEIqTESAU(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > bfVAyCEKJmhTitpvgEUfFFmWJYiV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			liBwCCxdlFtjrqHtEFjnFxqswpxnA[P_0] |= (byte)(1 << (int)P_1);
		}
		else
		{
			liBwCCxdlFtjrqHtEFjnFxqswpxnA[P_0] &= (byte)(~(1 << (int)P_1));
		}
	}

	public void qoclHsjTaQFvqzoIArCNIrkdOgzK(byte P_0, int P_1)
	{
		if (1 + P_1 > bfVAyCEKJmhTitpvgEUfFFmWJYiV || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		liBwCCxdlFtjrqHtEFjnFxqswpxnA[P_1] = P_0;
	}

	public unsafe void bxwOeGblVQfKxuqXfaqdBPHTPgcK(short P_0, int P_1)
	{
		if (2 + P_1 > bfVAyCEKJmhTitpvgEUfFFmWJYiV || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = liBwCCxdlFtjrqHtEFjnFxqswpxnA)
		{
			*(short*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void xaTwMYLgQFxHEmNjdeNNkpPiQJqb(ushort P_0, int P_1)
	{
		if (2 + P_1 > bfVAyCEKJmhTitpvgEUfFFmWJYiV || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = liBwCCxdlFtjrqHtEFjnFxqswpxnA)
		{
			*(ushort*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void TNkbPoheDHzVEEGXcAIoKrBlXYTHA(int P_0, int P_1)
	{
		if (4 + P_1 > bfVAyCEKJmhTitpvgEUfFFmWJYiV || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = liBwCCxdlFtjrqHtEFjnFxqswpxnA)
		{
			*(int*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void ICNTEqRUIrlxOzdnZitJFWfwciehA(uint P_0, int P_1)
	{
		if (4 + P_1 > bfVAyCEKJmhTitpvgEUfFFmWJYiV || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = liBwCCxdlFtjrqHtEFjnFxqswpxnA)
		{
			*(uint*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void cMNZSLTdrkHQIEaEDDUfKtkXyVmk(long P_0, int P_1)
	{
		if (8 + P_1 > bfVAyCEKJmhTitpvgEUfFFmWJYiV || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = liBwCCxdlFtjrqHtEFjnFxqswpxnA)
		{
			*(long*)(ptr + P_1) = P_0;
		}
	}

	public unsafe void FbeitZLYVZCdvYLlaphdJDjuwiCA(ulong P_0, int P_1)
	{
		if (8 + P_1 > bfVAyCEKJmhTitpvgEUfFFmWJYiV || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* ptr = liBwCCxdlFtjrqHtEFjnFxqswpxnA)
		{
			*(ulong*)(ptr + P_1) = P_0;
		}
	}

	public void CZnwtIRbwjZxSOagzkreSNKIPMTm(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("bytes");
		}
		int num = P_0.Length;
		if (num <= 0)
		{
			throw new ArgumentOutOfRangeException("bytes.Length must be > 0.");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be > 0");
		}
		if (P_1 > num)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be <= bufferLength.");
		}
		if (P_1 > bfVAyCEKJmhTitpvgEUfFFmWJYiV)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be <= Length.");
		}
		if (P_3 >= num)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be < bufferLength.");
		}
		if (P_3 < 0)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
		}
		if (P_2 >= bfVAyCEKJmhTitpvgEUfFFmWJYiV)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be < Length.");
		}
		if (P_2 < 0)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
		}
		if (P_3 + P_1 > num)
		{
			throw new ArgumentOutOfRangeException("readStartIndex + numBytesToWrite must be < bufferLength.");
		}
		if (P_1 + P_2 > bfVAyCEKJmhTitpvgEUfFFmWJYiV)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		Array.Copy(P_0, P_3, liBwCCxdlFtjrqHtEFjnFxqswpxnA, P_2, P_1);
	}

	public void YNMwUxYjnagTUaOaunfqcqXGSWKcB(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			throw new ArgumentNullException("bytes");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("bufferLength must be > 0.");
		}
		if (P_2 <= 0)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be > 0");
		}
		if (P_2 > P_1)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be <= bufferLength.");
		}
		if (P_2 > bfVAyCEKJmhTitpvgEUfFFmWJYiV)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be <= Length.");
		}
		if (P_4 >= P_1)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be < bufferLength.");
		}
		if (P_4 < 0)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
		}
		if (P_3 >= bfVAyCEKJmhTitpvgEUfFFmWJYiV)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be < Length.");
		}
		if (P_3 < 0)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
		}
		if (P_4 + P_2 > P_1)
		{
			throw new ArgumentOutOfRangeException("readStartIndex + numBytesToWrite must be < bufferLength.");
		}
		if (P_2 + P_3 > bfVAyCEKJmhTitpvgEUfFFmWJYiV)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, liBwCCxdlFtjrqHtEFjnFxqswpxnA, P_4, P_3, P_2);
	}

	public int kTmsQpKciYgHcGfoHBSjEdYivsRYB(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= bfVAyCEKJmhTitpvgEUfFFmWJYiV)
		{
			return 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 + P_2 > bfVAyCEKJmhTitpvgEUfFFmWJYiV)
		{
			P_1 = bfVAyCEKJmhTitpvgEUfFFmWJYiV - P_2;
		}
		Array.Copy(P_0, P_3, liBwCCxdlFtjrqHtEFjnFxqswpxnA, P_2, P_1);
		return P_1;
	}

	public int UCLjffozbfsrAhsSPrNnmbcdgKHFA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= bfVAyCEKJmhTitpvgEUfFFmWJYiV)
		{
			return 0;
		}
		if (P_4 < 0)
		{
			P_4 = 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		if (P_2 + P_3 > bfVAyCEKJmhTitpvgEUfFFmWJYiV)
		{
			P_2 = bfVAyCEKJmhTitpvgEUfFFmWJYiV - P_3;
		}
		NativeTools.CopyMemory(P_0, liBwCCxdlFtjrqHtEFjnFxqswpxnA, P_4, P_3, P_2);
		return P_2;
	}

	public void TKEFzrjdwNrGlFFHMBrbIICbpiGQ()
	{
		Array.Clear(liBwCCxdlFtjrqHtEFjnFxqswpxnA, 0, bfVAyCEKJmhTitpvgEUfFFmWJYiV);
	}

	public virtual string gmDIysfEFxwsiiBmwsLJLUumLJQs()
	{
		string text = "";
		for (int i = 0; i < bfVAyCEKJmhTitpvgEUfFFmWJYiV; i++)
		{
			text = text + this.KpiwyzHRucDZFwFCxEzcwZySbwHd(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		LOZcjVskNkwWnMsRVuSJxOjtgPdb(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void zgvKpobSzYtFWxjlRkxYdJxHGuqe()
	{
		try
		{
			LOZcjVskNkwWnMsRVuSJxOjtgPdb(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void LOZcjVskNkwWnMsRVuSJxOjtgPdb(bool P_0)
	{
		if (!gIdXasrhXsUWRcMKuRcYrSOmkqmF)
		{
			if (dVjNknnNTUmEfYCMoOQkeBEIZaDc.IsAllocated)
			{
				dVjNknnNTUmEfYCMoOQkeBEIZaDc.Free();
			}
			gIdXasrhXsUWRcMKuRcYrSOmkqmF = true;
		}
	}

	public static void jGqddRkSjVSYOJnXZmOIjLUjTfhxb(LGbftVmPDjafuTdTfDIDAIZCaeTkA P_0, LGbftVmPDjafuTdTfDIDAIZCaeTkA P_1, int P_2)
	{
		Array.Copy(P_0.liBwCCxdlFtjrqHtEFjnFxqswpxnA, P_1.liBwCCxdlFtjrqHtEFjnFxqswpxnA, P_2);
	}

	public static void HIUdCUVejtAiEbvqWDtZQMHEBRTX(LGbftVmPDjafuTdTfDIDAIZCaeTkA P_0, int P_1, LGbftVmPDjafuTdTfDIDAIZCaeTkA P_2, int P_3, int P_4)
	{
		Array.Copy(P_0.liBwCCxdlFtjrqHtEFjnFxqswpxnA, P_1, P_2.liBwCCxdlFtjrqHtEFjnFxqswpxnA, P_3, P_4);
	}
}
