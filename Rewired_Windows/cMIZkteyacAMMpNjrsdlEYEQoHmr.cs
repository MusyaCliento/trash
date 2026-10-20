using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal struct cMIZkteyacAMMpNjrsdlEYEQoHmr : IDisposable
{
	private unsafe byte* DmELgEiurTtKsZlRZbYxEBWmCZhBb;

	private int DRdDKUXllFbWvmEztpKNIZjZLGdd;

	private bool KmfstiZXiitxGAnHHVYSMWphotWe;

	public unsafe byte* sqZfMhYXvaePlXRyMdvISrMjhirt => DmELgEiurTtKsZlRZbYxEBWmCZhBb;

	public unsafe IntPtr dnjDQPbNBLdusFyadSmehnzgweap => (IntPtr)DmELgEiurTtKsZlRZbYxEBWmCZhBb;

	public int HSlgUqVwnaMSThkLUOmRuvQAHspQ => DRdDKUXllFbWvmEztpKNIZjZLGdd;

	public unsafe byte kHzDWAAFhPvlMlAPbSCtlyGwbeiBA
	{
		get
		{
			if (P_0 < 0 || P_0 >= DRdDKUXllFbWvmEztpKNIZjZLGdd)
			{
				throw new IndexOutOfRangeException();
			}
			return DmELgEiurTtKsZlRZbYxEBWmCZhBb[P_0];
		}
		set
		{
			if (num < 0 || num >= DRdDKUXllFbWvmEztpKNIZjZLGdd)
			{
				throw new IndexOutOfRangeException();
			}
			DmELgEiurTtKsZlRZbYxEBWmCZhBb[num] = b;
		}
	}

	public unsafe cMIZkteyacAMMpNjrsdlEYEQoHmr(int P_0)
	{
		DmELgEiurTtKsZlRZbYxEBWmCZhBb = null;
		DRdDKUXllFbWvmEztpKNIZjZLGdd = 0;
		KmfstiZXiitxGAnHHVYSMWphotWe = false;
		WYvGrmpJdtXHLblBeMyFatHZMwBN(P_0);
	}

	public unsafe IntPtr YdaIMwZBEsKpWVASqGXIDAqQfbXGA(int P_0 = 0)
	{
		if (P_0 == 0)
		{
			return (IntPtr)DmELgEiurTtKsZlRZbYxEBWmCZhBb;
		}
		if (P_0 < 0 || P_0 >= DRdDKUXllFbWvmEztpKNIZjZLGdd)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)(DmELgEiurTtKsZlRZbYxEBWmCZhBb + P_0);
	}

	public unsafe string FalHLukeqamTDgnoAAYfEvLPhpfwB()
	{
		string text = "";
		for (int i = 0; i < DRdDKUXllFbWvmEztpKNIZjZLGdd; i++)
		{
			text = text + DmELgEiurTtKsZlRZbYxEBWmCZhBb[i].ToString("x2") + " ";
		}
		return text;
	}

	public unsafe bool MUhAJozUwbXCfFBNgzFfvNiPpAZn(int P_0, byte P_1)
	{
		if (1 + P_0 > DRdDKUXllFbWvmEztpKNIZjZLGdd || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (DmELgEiurTtKsZlRZbYxEBWmCZhBb[P_0] & (1 << (int)P_1)) != 0;
	}

	public unsafe byte mxLAuTBxSnzMKgaULwEpcHqmyJAc(int P_0)
	{
		if (1 + P_0 > DRdDKUXllFbWvmEztpKNIZjZLGdd || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return DmELgEiurTtKsZlRZbYxEBWmCZhBb[P_0];
	}

	public unsafe short ZSNNpKclfFGMyhOpgrkQtcnhkvXK(int P_0)
	{
		if (2 + P_0 > DRdDKUXllFbWvmEztpKNIZjZLGdd || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(DmELgEiurTtKsZlRZbYxEBWmCZhBb + P_0);
	}

	public unsafe ushort oVQXvXoiLaSMjellVVIufplSoGxB(int P_0)
	{
		if (2 + P_0 > DRdDKUXllFbWvmEztpKNIZjZLGdd || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(DmELgEiurTtKsZlRZbYxEBWmCZhBb + P_0);
	}

	public unsafe int TtTeOneBeTXaescjXNVGGncCDBKr(int P_0)
	{
		if (4 + P_0 > DRdDKUXllFbWvmEztpKNIZjZLGdd || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(DmELgEiurTtKsZlRZbYxEBWmCZhBb + P_0);
	}

	public unsafe uint gQnQxRcYfvftYqMIKueFvKoaYDLO(int P_0)
	{
		if (4 + P_0 > DRdDKUXllFbWvmEztpKNIZjZLGdd || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(DmELgEiurTtKsZlRZbYxEBWmCZhBb + P_0);
	}

	public unsafe long skHqVDwjaKMITzamiOVWuxhQRtum(int P_0)
	{
		if (8 + P_0 > DRdDKUXllFbWvmEztpKNIZjZLGdd || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(DmELgEiurTtKsZlRZbYxEBWmCZhBb + P_0);
	}

	public unsafe ulong ZwXMjbJzdlcRSoRaoEkCZlqSEjpG(int P_0)
	{
		if (8 + P_0 > DRdDKUXllFbWvmEztpKNIZjZLGdd || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ulong*)(DmELgEiurTtKsZlRZbYxEBWmCZhBb + P_0);
	}

	public unsafe void IxkNPDMIStEOzZoVHYDELIoXQZlD(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > DRdDKUXllFbWvmEztpKNIZjZLGdd)
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
		if (P_2 >= DRdDKUXllFbWvmEztpKNIZjZLGdd)
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
		if (P_1 + P_2 > DRdDKUXllFbWvmEztpKNIZjZLGdd)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)DmELgEiurTtKsZlRZbYxEBWmCZhBb, P_0, P_2, P_3, P_1);
	}

	public unsafe void xTzQtHSKkWEcZWPGJXWuZjjtQrTV(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null)
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
		if (P_2 > DRdDKUXllFbWvmEztpKNIZjZLGdd)
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
		if (P_3 >= DRdDKUXllFbWvmEztpKNIZjZLGdd)
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
		if (P_2 + P_3 > DRdDKUXllFbWvmEztpKNIZjZLGdd)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		XtGMeZGVawiSiXBiWNwsFFHEKjXt.VtptHEGzauHBmzIgyIuCOhJjjdviA(DmELgEiurTtKsZlRZbYxEBWmCZhBb, P_0, P_3, P_4, P_2);
	}

	public unsafe void TMRpiUFSbZVPpkWGuTohxNqaOszk(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		xTzQtHSKkWEcZWPGJXWuZjjtQrTV((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int zimGAhaTbwTDpimQLNetHOGJyixk(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= DRdDKUXllFbWvmEztpKNIZjZLGdd)
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
		if (P_2 + P_1 > DRdDKUXllFbWvmEztpKNIZjZLGdd)
		{
			P_1 = DRdDKUXllFbWvmEztpKNIZjZLGdd - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)DmELgEiurTtKsZlRZbYxEBWmCZhBb, P_0, P_2, P_3, P_1);
		return P_1;
	}

	public unsafe int PMJfOABKDTapsEqIQxSFzcDADlmhA(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= DRdDKUXllFbWvmEztpKNIZjZLGdd)
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
		if (P_3 + P_2 > DRdDKUXllFbWvmEztpKNIZjZLGdd)
		{
			P_2 = DRdDKUXllFbWvmEztpKNIZjZLGdd - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		XtGMeZGVawiSiXBiWNwsFFHEKjXt.VtptHEGzauHBmzIgyIuCOhJjjdviA(DmELgEiurTtKsZlRZbYxEBWmCZhBb, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int AMVzMFTLVnMvSbCnDMcbOuTsUqak(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0;
		}
		return PMJfOABKDTapsEqIQxSFzcDADlmhA((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe void TfQEDOvvosdexGmrWzDkmIewOJQZA(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > DRdDKUXllFbWvmEztpKNIZjZLGdd || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			byte* num = DmELgEiurTtKsZlRZbYxEBWmCZhBb + P_0;
			*num |= (byte)(1 << (int)P_1);
		}
		else
		{
			byte* num2 = DmELgEiurTtKsZlRZbYxEBWmCZhBb + P_0;
			*num2 &= (byte)(~(1 << (int)P_1));
		}
	}

	public unsafe void oamLZEreJhZaiYvqWLZZvuGrchZk(byte P_0, int P_1)
	{
		if (1 + P_1 > DRdDKUXllFbWvmEztpKNIZjZLGdd || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		DmELgEiurTtKsZlRZbYxEBWmCZhBb[P_1] = P_0;
	}

	public unsafe void qQDdQbMiiQRiKylEPUtOwRrOALYg(short P_0, int P_1)
	{
		if (2 + P_1 > DRdDKUXllFbWvmEztpKNIZjZLGdd || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(DmELgEiurTtKsZlRZbYxEBWmCZhBb + P_1) = P_0;
	}

	public unsafe void vqQILwOAZfhxZcVoRpiXLxzHHiEv(ushort P_0, int P_1)
	{
		if (2 + P_1 > DRdDKUXllFbWvmEztpKNIZjZLGdd || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ushort*)(DmELgEiurTtKsZlRZbYxEBWmCZhBb + P_1) = P_0;
	}

	public unsafe void PwnFmTSjkrkezIKQRdJPJgWoCcODA(int P_0, int P_1)
	{
		if (4 + P_1 > DRdDKUXllFbWvmEztpKNIZjZLGdd || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(DmELgEiurTtKsZlRZbYxEBWmCZhBb + P_1) = P_0;
	}

	public unsafe void rMQebMAGDacMviQITaByDxkfzrCJb(uint P_0, int P_1)
	{
		if (4 + P_1 > DRdDKUXllFbWvmEztpKNIZjZLGdd || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(uint*)(DmELgEiurTtKsZlRZbYxEBWmCZhBb + P_1) = P_0;
	}

	public unsafe void cFoGFNLOjHnqnyHqlsKGrdmEbwQgA(long P_0, int P_1)
	{
		if (8 + P_1 > DRdDKUXllFbWvmEztpKNIZjZLGdd || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(DmELgEiurTtKsZlRZbYxEBWmCZhBb + P_1) = P_0;
	}

	public unsafe void vQZoLKxTHLPPzYcvaXqwRamvzmly(ulong P_0, int P_1)
	{
		if (8 + P_1 > DRdDKUXllFbWvmEztpKNIZjZLGdd || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ulong*)(DmELgEiurTtKsZlRZbYxEBWmCZhBb + P_1) = P_0;
	}

	public unsafe void agAkOkfeuYfzGhyBfMAOiYowytph(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > DRdDKUXllFbWvmEztpKNIZjZLGdd)
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
		if (P_2 >= DRdDKUXllFbWvmEztpKNIZjZLGdd)
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
		if (P_1 + P_2 > DRdDKUXllFbWvmEztpKNIZjZLGdd)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, (IntPtr)DmELgEiurTtKsZlRZbYxEBWmCZhBb, P_3, P_2, P_1);
	}

	public unsafe void hhidCWASoIGFidoYvFYACPdBsdBDA(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null)
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
		if (P_2 > DRdDKUXllFbWvmEztpKNIZjZLGdd)
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
		if (P_3 >= DRdDKUXllFbWvmEztpKNIZjZLGdd)
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
		if (P_2 + P_3 > DRdDKUXllFbWvmEztpKNIZjZLGdd)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		XtGMeZGVawiSiXBiWNwsFFHEKjXt.VtptHEGzauHBmzIgyIuCOhJjjdviA(P_0, DmELgEiurTtKsZlRZbYxEBWmCZhBb, P_4, P_3, P_2);
	}

	public unsafe void HRcQckITJVOddpJACLTKFeuxaEu(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		hhidCWASoIGFidoYvFYACPdBsdBDA((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int nUpkKkoQUyCIibcaQDyFAPooZRolA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= DRdDKUXllFbWvmEztpKNIZjZLGdd)
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
		if (P_1 + P_2 > DRdDKUXllFbWvmEztpKNIZjZLGdd)
		{
			P_1 = DRdDKUXllFbWvmEztpKNIZjZLGdd - P_2;
		}
		NativeTools.CopyMemory(P_0, (IntPtr)DmELgEiurTtKsZlRZbYxEBWmCZhBb, P_3, P_2, P_1);
		return P_1;
	}

	public unsafe int iwdaQWfBUUYmWBZkBTyyWJIJFkjGA(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= DRdDKUXllFbWvmEztpKNIZjZLGdd)
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
		if (P_2 + P_3 > DRdDKUXllFbWvmEztpKNIZjZLGdd)
		{
			P_2 = DRdDKUXllFbWvmEztpKNIZjZLGdd - P_3;
		}
		XtGMeZGVawiSiXBiWNwsFFHEKjXt.VtptHEGzauHBmzIgyIuCOhJjjdviA(P_0, DmELgEiurTtKsZlRZbYxEBWmCZhBb, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe int qjMFjzlrGOewiNJwwjgOoaXQjFGb(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		return iwdaQWfBUUYmWBZkBTyyWJIJFkjGA((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool WYvGrmpJdtXHLblBeMyFatHZMwBN(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (DRdDKUXllFbWvmEztpKNIZjZLGdd == P_0)
		{
			return true;
		}
		nwBfpmJRAqFAZMnmopwMfRwfuNxd();
		if (P_0 == 0)
		{
			return true;
		}
		DRdDKUXllFbWvmEztpKNIZjZLGdd = P_0;
		DmELgEiurTtKsZlRZbYxEBWmCZhBb = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		JimUXEZprsnPeWKMSKknrEZORPB();
		return true;
	}

	public unsafe void JimUXEZprsnPeWKMSKknrEZORPB()
	{
		if (DRdDKUXllFbWvmEztpKNIZjZLGdd != 0)
		{
			XtGMeZGVawiSiXBiWNwsFFHEKjXt.oSiUCYIqBigyjDdAORRwEeuGhUBkB(DmELgEiurTtKsZlRZbYxEBWmCZhBb, DRdDKUXllFbWvmEztpKNIZjZLGdd);
		}
	}

	public unsafe void nwBfpmJRAqFAZMnmopwMfRwfuNxd()
	{
		if (DRdDKUXllFbWvmEztpKNIZjZLGdd == 0)
		{
			return;
		}
		try
		{
			if (DmELgEiurTtKsZlRZbYxEBWmCZhBb != null)
			{
				Marshal.FreeHGlobal(dnjDQPbNBLdusFyadSmehnzgweap);
			}
		}
		catch
		{
		}
		DmELgEiurTtKsZlRZbYxEBWmCZhBb = null;
		DRdDKUXllFbWvmEztpKNIZjZLGdd = 0;
	}

	public string RLCeDpIHZwKrScDOKHoMwyZKidMFB()
	{
		string text = "";
		for (int i = 0; i < DRdDKUXllFbWvmEztpKNIZjZLGdd; i++)
		{
			text = text + mxLAuTBxSnzMKgaULwEpcHqmyJAc(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		YtZkhaBRhrBRjKGVRohXnnqJRNBaA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	private void YtZkhaBRhrBRjKGVRohXnnqJRNBaA(bool P_0)
	{
		if (!KmfstiZXiitxGAnHHVYSMWphotWe)
		{
			nwBfpmJRAqFAZMnmopwMfRwfuNxd();
			KmfstiZXiitxGAnHHVYSMWphotWe = true;
		}
	}

	[SpecialName]
	public unsafe static IntPtr EmKSzuRjaNlyxFVMTxOPuagJzOuJ(cMIZkteyacAMMpNjrsdlEYEQoHmr P_0)
	{
		return (IntPtr)P_0.DmELgEiurTtKsZlRZbYxEBWmCZhBb;
	}

	[SpecialName]
	public unsafe static void* EmKSzuRjaNlyxFVMTxOPuagJzOuJ(cMIZkteyacAMMpNjrsdlEYEQoHmr P_0)
	{
		return P_0.DmELgEiurTtKsZlRZbYxEBWmCZhBb;
	}

	public unsafe static bool rlIZlLUrpttIEeRPIvCsgjKUzedk(cMIZkteyacAMMpNjrsdlEYEQoHmr P_0, cMIZkteyacAMMpNjrsdlEYEQoHmr P_1)
	{
		if (P_0.DRdDKUXllFbWvmEztpKNIZjZLGdd == 0)
		{
			P_1.nwBfpmJRAqFAZMnmopwMfRwfuNxd();
			return true;
		}
		if (P_1.WYvGrmpJdtXHLblBeMyFatHZMwBN(P_0.DRdDKUXllFbWvmEztpKNIZjZLGdd))
		{
			P_1.hhidCWASoIGFidoYvFYACPdBsdBDA(P_0.DmELgEiurTtKsZlRZbYxEBWmCZhBb, P_0.DRdDKUXllFbWvmEztpKNIZjZLGdd, P_0.DRdDKUXllFbWvmEztpKNIZjZLGdd);
			return true;
		}
		return false;
	}
}
