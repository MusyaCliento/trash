using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class TLjofzBmfBMLdKYQRjtOpIYGxOeK : IDisposable
{
	private unsafe byte* DEiCJTKxSkPnUTeWhvSosMRAQbObb;

	private int QhWpNRkKJEXtevSduLNwxMzJDUko;

	private bool ycfdBTKoKlmRubYOlDliUFZgSJUL;

	public unsafe byte* WDBuTMlhTMGYwjsDtIQDjwdDWEQE => DEiCJTKxSkPnUTeWhvSosMRAQbObb;

	public unsafe IntPtr NviRYhMtJVuAvgdklGfnjFqczibp => (IntPtr)DEiCJTKxSkPnUTeWhvSosMRAQbObb;

	public int nvXPFTVmARaIHpkYDPfhnDqlBRyP => QhWpNRkKJEXtevSduLNwxMzJDUko;

	public unsafe byte BaNMceeSHCmVdudApRtcZpwJRLZy
	{
		get
		{
			if (P_0 < 0 || P_0 >= QhWpNRkKJEXtevSduLNwxMzJDUko)
			{
				throw new IndexOutOfRangeException();
			}
			return DEiCJTKxSkPnUTeWhvSosMRAQbObb[P_0];
		}
		set
		{
			if (num < 0 || num >= QhWpNRkKJEXtevSduLNwxMzJDUko)
			{
				throw new IndexOutOfRangeException();
			}
			DEiCJTKxSkPnUTeWhvSosMRAQbObb[num] = b;
		}
	}

	public TLjofzBmfBMLdKYQRjtOpIYGxOeK(int P_0)
	{
		lDuKZwKvpGlqjioOtykAwfYfmzeF(P_0);
	}

	public unsafe IntPtr fONwcrYFBPHZjPUSQgElKQueWHTN(int P_0 = 0)
	{
		if (P_0 == 0)
		{
			return (IntPtr)DEiCJTKxSkPnUTeWhvSosMRAQbObb;
		}
		if (P_0 < 0 || P_0 >= QhWpNRkKJEXtevSduLNwxMzJDUko)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)(DEiCJTKxSkPnUTeWhvSosMRAQbObb + P_0);
	}

	public unsafe string IWRGcbFBYKdylwkIGJdddxrChPGMb()
	{
		string text = "";
		for (int i = 0; i < QhWpNRkKJEXtevSduLNwxMzJDUko; i++)
		{
			text = text + DEiCJTKxSkPnUTeWhvSosMRAQbObb[i].ToString("x2") + " ";
		}
		return text;
	}

	public unsafe bool jGNgIAAqAuDQstmCcIsACoiKYrfxB(int P_0, byte P_1)
	{
		if (1 + P_0 > QhWpNRkKJEXtevSduLNwxMzJDUko || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (DEiCJTKxSkPnUTeWhvSosMRAQbObb[P_0] & (1 << (int)P_1)) != 0;
	}

	public unsafe byte mrBtMFaflKKnlhcMpnRxHrNpSpxd(int P_0)
	{
		if (1 + P_0 > QhWpNRkKJEXtevSduLNwxMzJDUko || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return DEiCJTKxSkPnUTeWhvSosMRAQbObb[P_0];
	}

	public unsafe short WGbrbRHFSTohdULjbgtrLIzlorcm(int P_0)
	{
		if (2 + P_0 > QhWpNRkKJEXtevSduLNwxMzJDUko || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(DEiCJTKxSkPnUTeWhvSosMRAQbObb + P_0);
	}

	public unsafe ushort usBCkFaDsqbbUDWyvfyWGuyEBeurc(int P_0)
	{
		if (2 + P_0 > QhWpNRkKJEXtevSduLNwxMzJDUko || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(DEiCJTKxSkPnUTeWhvSosMRAQbObb + P_0);
	}

	public unsafe int uwUuWVwGClZRvDBmCHXaJNFZhapC(int P_0)
	{
		if (4 + P_0 > QhWpNRkKJEXtevSduLNwxMzJDUko || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(DEiCJTKxSkPnUTeWhvSosMRAQbObb + P_0);
	}

	public unsafe uint hnziouvjLOFFrUhXEzaPAUfpgesj(int P_0)
	{
		if (4 + P_0 > QhWpNRkKJEXtevSduLNwxMzJDUko || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(DEiCJTKxSkPnUTeWhvSosMRAQbObb + P_0);
	}

	public unsafe long HuUZxPnngytSKPzImMskIdGQxAkG(int P_0)
	{
		if (8 + P_0 > QhWpNRkKJEXtevSduLNwxMzJDUko || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(DEiCJTKxSkPnUTeWhvSosMRAQbObb + P_0);
	}

	public unsafe ulong vdxixymxknMMVDzYwDocwNsFWtdW(int P_0)
	{
		if (8 + P_0 > QhWpNRkKJEXtevSduLNwxMzJDUko || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ulong*)(DEiCJTKxSkPnUTeWhvSosMRAQbObb + P_0);
	}

	public unsafe float xyXXoySJsycgCjsoMajDigSQpRpaA(int P_0)
	{
		if (4 + P_0 > QhWpNRkKJEXtevSduLNwxMzJDUko || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(float*)(DEiCJTKxSkPnUTeWhvSosMRAQbObb + P_0);
	}

	public unsafe double iEymuJPZMcMqbURvvuEJWvTEavnL(int P_0)
	{
		if (8 + P_0 > QhWpNRkKJEXtevSduLNwxMzJDUko || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(double*)(DEiCJTKxSkPnUTeWhvSosMRAQbObb + P_0);
	}

	public unsafe void pifZNQDvYekEJQYITzMPaUauzMLI(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > QhWpNRkKJEXtevSduLNwxMzJDUko)
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
		if (P_2 >= QhWpNRkKJEXtevSduLNwxMzJDUko)
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
		if (P_1 + P_2 > QhWpNRkKJEXtevSduLNwxMzJDUko)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)DEiCJTKxSkPnUTeWhvSosMRAQbObb, P_0, P_2, P_3, P_1);
	}

	public unsafe void KsVOojKrnQqBnnbrENOKttZofTXS(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > QhWpNRkKJEXtevSduLNwxMzJDUko)
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
		if (P_3 >= QhWpNRkKJEXtevSduLNwxMzJDUko)
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
		if (P_2 + P_3 > QhWpNRkKJEXtevSduLNwxMzJDUko)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		XtGMeZGVawiSiXBiWNwsFFHEKjXt.VtptHEGzauHBmzIgyIuCOhJjjdviA(DEiCJTKxSkPnUTeWhvSosMRAQbObb, P_0, P_3, P_4, P_2);
	}

	public unsafe void fepVGkPjMSSvVuLgjdHOagQdZwYF(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		KsVOojKrnQqBnnbrENOKttZofTXS((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int DIDiPjaKUWZgufLfHRZvMcqeSakw(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= QhWpNRkKJEXtevSduLNwxMzJDUko)
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
		if (P_2 + P_1 > QhWpNRkKJEXtevSduLNwxMzJDUko)
		{
			P_1 = QhWpNRkKJEXtevSduLNwxMzJDUko - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)DEiCJTKxSkPnUTeWhvSosMRAQbObb, P_0, P_2, P_3, P_1);
		return P_1;
	}

	public unsafe int uAaSWFMKrhpHYbOdUCQVMrdijnKN(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= QhWpNRkKJEXtevSduLNwxMzJDUko)
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
		if (P_3 + P_2 > QhWpNRkKJEXtevSduLNwxMzJDUko)
		{
			P_2 = QhWpNRkKJEXtevSduLNwxMzJDUko - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		XtGMeZGVawiSiXBiWNwsFFHEKjXt.VtptHEGzauHBmzIgyIuCOhJjjdviA(DEiCJTKxSkPnUTeWhvSosMRAQbObb, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int idRGpWewQheATQVQMPbvCSXgMgOGb(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0;
		}
		return uAaSWFMKrhpHYbOdUCQVMrdijnKN((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe void hYkiqwMCsHYDuQmWsvECAAUWSLGn(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > QhWpNRkKJEXtevSduLNwxMzJDUko || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			byte* num = DEiCJTKxSkPnUTeWhvSosMRAQbObb + P_0;
			*num |= (byte)(1 << (int)P_1);
		}
		else
		{
			byte* num2 = DEiCJTKxSkPnUTeWhvSosMRAQbObb + P_0;
			*num2 &= (byte)(~(1 << (int)P_1));
		}
	}

	public unsafe void wTBHUbksFdiTrqtFdFgViedUqlghA(byte P_0, int P_1)
	{
		if (1 + P_1 > QhWpNRkKJEXtevSduLNwxMzJDUko || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		DEiCJTKxSkPnUTeWhvSosMRAQbObb[P_1] = P_0;
	}

	public unsafe void rMxbkyJpEceCzNckgNPCRmbqSYapA(short P_0, int P_1)
	{
		if (2 + P_1 > QhWpNRkKJEXtevSduLNwxMzJDUko || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(DEiCJTKxSkPnUTeWhvSosMRAQbObb + P_1) = P_0;
	}

	public unsafe void LetcvylNKGdAfGcPBowdovqNtjAhA(ushort P_0, int P_1)
	{
		if (2 + P_1 > QhWpNRkKJEXtevSduLNwxMzJDUko || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ushort*)(DEiCJTKxSkPnUTeWhvSosMRAQbObb + P_1) = P_0;
	}

	public unsafe void cKYcmEmrMZJlUhwSQHCkSgqmPXkj(int P_0, int P_1)
	{
		if (4 + P_1 > QhWpNRkKJEXtevSduLNwxMzJDUko || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(DEiCJTKxSkPnUTeWhvSosMRAQbObb + P_1) = P_0;
	}

	public unsafe void EJWgJmgpQNYxDQohDgRwnWhUsHNI(uint P_0, int P_1)
	{
		if (4 + P_1 > QhWpNRkKJEXtevSduLNwxMzJDUko || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(uint*)(DEiCJTKxSkPnUTeWhvSosMRAQbObb + P_1) = P_0;
	}

	public unsafe void BYChowGnabQGDEQjXgCfTbEyoScx(long P_0, int P_1)
	{
		if (8 + P_1 > QhWpNRkKJEXtevSduLNwxMzJDUko || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(DEiCJTKxSkPnUTeWhvSosMRAQbObb + P_1) = P_0;
	}

	public unsafe void QfdgUJWUKDEjJgsNzCSmgigQOtvc(ulong P_0, int P_1)
	{
		if (8 + P_1 > QhWpNRkKJEXtevSduLNwxMzJDUko || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ulong*)(DEiCJTKxSkPnUTeWhvSosMRAQbObb + P_1) = P_0;
	}

	public unsafe void uURtSwPAvUbgEsYhCJrPnEjvMTLJ(float P_0, int P_1)
	{
		if (4 + P_1 > QhWpNRkKJEXtevSduLNwxMzJDUko || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(float*)(DEiCJTKxSkPnUTeWhvSosMRAQbObb + P_1) = P_0;
	}

	public unsafe void oTUEcDRWaOvVBCtxluTbnUaoajxc(double P_0, int P_1)
	{
		if (8 + P_1 > QhWpNRkKJEXtevSduLNwxMzJDUko || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(double*)(DEiCJTKxSkPnUTeWhvSosMRAQbObb + P_1) = P_0;
	}

	public unsafe void zlpMKtLDKmtALmmFkcYNfPLJJhKgA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > QhWpNRkKJEXtevSduLNwxMzJDUko)
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
		if (P_2 >= QhWpNRkKJEXtevSduLNwxMzJDUko)
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
		if (P_1 + P_2 > QhWpNRkKJEXtevSduLNwxMzJDUko)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, (IntPtr)DEiCJTKxSkPnUTeWhvSosMRAQbObb, P_3, P_2, P_1);
	}

	public unsafe void pcmIftrCtuQwgWHyafApTygcYGrK(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > QhWpNRkKJEXtevSduLNwxMzJDUko)
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
		if (P_3 >= QhWpNRkKJEXtevSduLNwxMzJDUko)
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
		if (P_2 + P_3 > QhWpNRkKJEXtevSduLNwxMzJDUko)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		XtGMeZGVawiSiXBiWNwsFFHEKjXt.VtptHEGzauHBmzIgyIuCOhJjjdviA(P_0, DEiCJTKxSkPnUTeWhvSosMRAQbObb, P_4, P_3, P_2);
	}

	public unsafe void UIirSiHUVtEilhGUkiXqZAvOWRKy(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		pcmIftrCtuQwgWHyafApTygcYGrK((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int MLNbrwabGTLXZqMYszLRYacnGeMC(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= QhWpNRkKJEXtevSduLNwxMzJDUko)
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
		if (P_1 + P_2 > QhWpNRkKJEXtevSduLNwxMzJDUko)
		{
			P_1 = QhWpNRkKJEXtevSduLNwxMzJDUko - P_2;
		}
		NativeTools.CopyMemory(P_0, (IntPtr)DEiCJTKxSkPnUTeWhvSosMRAQbObb, P_3, P_2, P_1);
		return P_1;
	}

	public unsafe int ytDpsKkOvAFyxPUYzDsevFVOnogk(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= QhWpNRkKJEXtevSduLNwxMzJDUko)
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
		if (P_2 + P_3 > QhWpNRkKJEXtevSduLNwxMzJDUko)
		{
			P_2 = QhWpNRkKJEXtevSduLNwxMzJDUko - P_3;
		}
		XtGMeZGVawiSiXBiWNwsFFHEKjXt.VtptHEGzauHBmzIgyIuCOhJjjdviA(P_0, DEiCJTKxSkPnUTeWhvSosMRAQbObb, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe int qrXLwbvgOWXyBWDNoLaGfQlhvSei(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		return ytDpsKkOvAFyxPUYzDsevFVOnogk((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool lDuKZwKvpGlqjioOtykAwfYfmzeF(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (QhWpNRkKJEXtevSduLNwxMzJDUko == P_0)
		{
			return true;
		}
		YuoEuJHtoKKXgeYaKKnPnojLmrpGb();
		if (P_0 == 0)
		{
			return true;
		}
		QhWpNRkKJEXtevSduLNwxMzJDUko = P_0;
		DEiCJTKxSkPnUTeWhvSosMRAQbObb = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		kpPGPPdushiozBCUikwEkojmJHinb();
		return true;
	}

	public unsafe void kpPGPPdushiozBCUikwEkojmJHinb()
	{
		if (QhWpNRkKJEXtevSduLNwxMzJDUko != 0)
		{
			XtGMeZGVawiSiXBiWNwsFFHEKjXt.oSiUCYIqBigyjDdAORRwEeuGhUBkB(DEiCJTKxSkPnUTeWhvSosMRAQbObb, QhWpNRkKJEXtevSduLNwxMzJDUko);
		}
	}

	public unsafe void YuoEuJHtoKKXgeYaKKnPnojLmrpGb()
	{
		if (QhWpNRkKJEXtevSduLNwxMzJDUko == 0)
		{
			return;
		}
		try
		{
			if (DEiCJTKxSkPnUTeWhvSosMRAQbObb != null)
			{
				Marshal.FreeHGlobal(NviRYhMtJVuAvgdklGfnjFqczibp);
			}
		}
		catch
		{
		}
		DEiCJTKxSkPnUTeWhvSosMRAQbObb = null;
		QhWpNRkKJEXtevSduLNwxMzJDUko = 0;
	}

	public virtual string HBwpurrvScmvUWCnvmaCnxJIMIAF()
	{
		string text = "";
		for (int i = 0; i < QhWpNRkKJEXtevSduLNwxMzJDUko; i++)
		{
			text = text + mrBtMFaflKKnlhcMpnRxHrNpSpxd(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		hBipItfBzPMuLasuOFsWnurnTTtg(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void MIlbkWcBTdDDCcmkJmWYHkvmsWiJA()
	{
		try
		{
			hBipItfBzPMuLasuOFsWnurnTTtg(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void hBipItfBzPMuLasuOFsWnurnTTtg(bool P_0)
	{
		if (!ycfdBTKoKlmRubYOlDliUFZgSJUL)
		{
			YuoEuJHtoKKXgeYaKKnPnojLmrpGb();
			ycfdBTKoKlmRubYOlDliUFZgSJUL = true;
		}
	}

	[SpecialName]
	public unsafe static IntPtr fKTDPQTczycLwwypUVKnJloxAtvd(TLjofzBmfBMLdKYQRjtOpIYGxOeK P_0)
	{
		if (P_0 == null)
		{
			return IntPtr.Zero;
		}
		return (IntPtr)P_0.DEiCJTKxSkPnUTeWhvSosMRAQbObb;
	}

	[SpecialName]
	public unsafe static void* fKTDPQTczycLwwypUVKnJloxAtvd(TLjofzBmfBMLdKYQRjtOpIYGxOeK P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return P_0.DEiCJTKxSkPnUTeWhvSosMRAQbObb;
	}

	public unsafe static bool zZXMmrkojFUDcQXXrTvRFdyAPYQM(TLjofzBmfBMLdKYQRjtOpIYGxOeK P_0, TLjofzBmfBMLdKYQRjtOpIYGxOeK P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.QhWpNRkKJEXtevSduLNwxMzJDUko == 0)
		{
			P_1.YuoEuJHtoKKXgeYaKKnPnojLmrpGb();
			return true;
		}
		if (P_1.lDuKZwKvpGlqjioOtykAwfYfmzeF(P_0.QhWpNRkKJEXtevSduLNwxMzJDUko))
		{
			P_1.pcmIftrCtuQwgWHyafApTygcYGrK(P_0.DEiCJTKxSkPnUTeWhvSosMRAQbObb, P_0.QhWpNRkKJEXtevSduLNwxMzJDUko, P_0.QhWpNRkKJEXtevSduLNwxMzJDUko);
			return true;
		}
		return false;
	}
}
