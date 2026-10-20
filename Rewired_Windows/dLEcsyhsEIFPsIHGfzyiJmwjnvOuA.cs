using System;

internal class dLEcsyhsEIFPsIHGfzyiJmwjnvOuA : IDisposable
{
	private readonly TLjofzBmfBMLdKYQRjtOpIYGxOeK IRwbonMxAijXnbIbuTnCgmMvfqLQ;

	private bool[] gDcDilwiNkayYAKtmnqJgOlGWGkib;

	protected readonly int UbzVxOBclfYOjnMjZZpPPsDglhDc;

	protected readonly int KPPaedJmRWJKJNMkZBQlSWuXFSBD;

	private bool bfvCRIBNVSWIoHExqUWEzhYofsog;

	public int yOEgVAwDxXosZFBsCLLzFWGgVeAj => UbzVxOBclfYOjnMjZZpPPsDglhDc;

	public int ltXDwcoEqSCGohSYBFwmskZomOYb => KPPaedJmRWJKJNMkZBQlSWuXFSBD;

	public bool[] zllxyYzUSEsjEikbVCHisLFmgNmz => gDcDilwiNkayYAKtmnqJgOlGWGkib ?? (gDcDilwiNkayYAKtmnqJgOlGWGkib = new bool[UbzVxOBclfYOjnMjZZpPPsDglhDc]);

	public dLEcsyhsEIFPsIHGfzyiJmwjnvOuA(int P_0, int P_1)
	{
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("entryBitSize");
		}
		KPPaedJmRWJKJNMkZBQlSWuXFSBD = P_0;
		UbzVxOBclfYOjnMjZZpPPsDglhDc = P_1;
		int num = P_0 * P_1;
		int num2 = num / 8 + ((num % 8 != 0) ? 1 : 0);
		IRwbonMxAijXnbIbuTnCgmMvfqLQ = new TLjofzBmfBMLdKYQRjtOpIYGxOeK(num2);
	}

	public unsafe void UQTgOjivVMrunwUUzyCrcEbIYKjV(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= KPPaedJmRWJKJNMkZBQlSWuXFSBD)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_2 < UbzVxOBclfYOjnMjZZpPPsDglhDc)
		{
			int ubzVxOBclfYOjnMjZZpPPsDglhDc = UbzVxOBclfYOjnMjZZpPPsDglhDc;
			throw new Exception("Buffer is too small to hold the data. Must be at least " + ubzVxOBclfYOjnMjZZpPPsDglhDc + " bits.");
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < UbzVxOBclfYOjnMjZZpPPsDglhDc; i++)
		{
			iFslKwoAwRAkIVcEFKJXZeCHLtle(P_0, i, out var num3, out var b);
			P_1[i] = (IRwbonMxAijXnbIbuTnCgmMvfqLQ.jGNgIAAqAuDQstmCcIsACoiKYrfxB(num3, b) ? ((byte)(P_1[num] | (1 << num2))) : ((byte)(P_1[num] & ~(1 << num2))));
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void fbtAxVdapJRScYAhLhteZivZBgNJ(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		UQTgOjivVMrunwUUzyCrcEbIYKjV(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void igQRqOZtkifeRIcOsUYTpZllMBSI(int P_0, out byte P_1)
	{
		byte b = 0;
		byte* ptr = &b;
		UQTgOjivVMrunwUUzyCrcEbIYKjV(P_0, ptr, 64);
		P_1 = b;
	}

	public void tqJJRErcVIkKWREqxHYizJGOcmJO(int P_0, out sbyte P_1)
	{
		igQRqOZtkifeRIcOsUYTpZllMBSI(P_0, out var b);
		P_1 = (sbyte)b;
	}

	public unsafe void uPnPSyjFJKBCnbSXztVnzSfawXTn(int P_0, out short P_1)
	{
		short num = 0;
		byte* ptr = (byte*)(&num);
		UQTgOjivVMrunwUUzyCrcEbIYKjV(P_0, ptr, 64);
		P_1 = num;
	}

	public void xrnxPQFiNXpKlNfDziqGrDCTRvBp(int P_0, out ushort P_1)
	{
		uPnPSyjFJKBCnbSXztVnzSfawXTn(P_0, out var num);
		P_1 = (ushort)num;
	}

	public unsafe void QgkkUtfGAxPyuKEoVejOYfnAQJoK(int P_0, out int P_1)
	{
		int num = 0;
		byte* ptr = (byte*)(&num);
		UQTgOjivVMrunwUUzyCrcEbIYKjV(P_0, ptr, 64);
		P_1 = num;
	}

	public void OawPbeqqQHcxahMlqEzPVgWmMvcN(int P_0, out uint P_1)
	{
		QgkkUtfGAxPyuKEoVejOYfnAQJoK(P_0, out var num);
		P_1 = (uint)num;
	}

	public unsafe void aYtdJCDmJIvPcmvINxZsLTdTgKNrA(int P_0, out long P_1)
	{
		long num = 0L;
		byte* ptr = (byte*)(&num);
		UQTgOjivVMrunwUUzyCrcEbIYKjV(P_0, ptr, 64);
		P_1 = num;
	}

	public void CPEokqOqCWMBOilxXXqEQVdvGuuC(int P_0, out ulong P_1)
	{
		aYtdJCDmJIvPcmvINxZsLTdTgKNrA(P_0, out var num);
		P_1 = (ulong)num;
	}

	public void isjntAVbEBrJlWESxHGCfhwqzsec(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= KPPaedJmRWJKJNMkZBQlSWuXFSBD)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < UbzVxOBclfYOjnMjZZpPPsDglhDc)
		{
			int ubzVxOBclfYOjnMjZZpPPsDglhDc = UbzVxOBclfYOjnMjZZpPPsDglhDc;
			throw new Exception("valueBuffer.Length must be >= " + ubzVxOBclfYOjnMjZZpPPsDglhDc);
		}
		for (int i = 0; i < UbzVxOBclfYOjnMjZZpPPsDglhDc; i++)
		{
			iFslKwoAwRAkIVcEFKJXZeCHLtle(P_0, i, out var num, out var b);
			P_1[i] = IRwbonMxAijXnbIbuTnCgmMvfqLQ.jGNgIAAqAuDQstmCcIsACoiKYrfxB(num, b);
		}
	}

	public unsafe void lHaHVkbgZIxlYMgeQBOmrNWwGQDX(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= KPPaedJmRWJKJNMkZBQlSWuXFSBD)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_2 <= 0)
		{
			throw new Exception("bufferSize must be >= 0");
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < UbzVxOBclfYOjnMjZZpPPsDglhDc; i++)
		{
			iFslKwoAwRAkIVcEFKJXZeCHLtle(P_0, i, out var num3, out var b);
			bool flag = i < P_2 && (flag = (P_1[num] & (1 << num2)) != 0);
			IRwbonMxAijXnbIbuTnCgmMvfqLQ.hYkiqwMCsHYDuQmWsvECAAUWSLGn(num3, b, flag);
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void POODddIKLxKKaxKlgihlfLHbWMNCA(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		lHaHVkbgZIxlYMgeQBOmrNWwGQDX(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void NXiWoeAoKMfiHrtmiFFithkdWAqm(int P_0, byte P_1)
	{
		byte* ptr = &P_1;
		lHaHVkbgZIxlYMgeQBOmrNWwGQDX(P_0, ptr, 8);
	}

	public void hsNhlvvdvXATwWiewUtiDDrWcwve(int P_0, sbyte P_1)
	{
		NXiWoeAoKMfiHrtmiFFithkdWAqm(P_0, (byte)P_1);
	}

	public unsafe void FbcrguLcZTCNajLaoflzcPPDdwpBA(int P_0, short P_1)
	{
		byte* ptr = (byte*)(&P_1);
		lHaHVkbgZIxlYMgeQBOmrNWwGQDX(P_0, ptr, 16);
	}

	public void ewNEdfaNeoYyeRxtuOMnaBnSZuKaA(int P_0, ushort P_1)
	{
		FbcrguLcZTCNajLaoflzcPPDdwpBA(P_0, (short)P_1);
	}

	public unsafe void xFDsVjPHoFWagUqmfZWqBWfzAHIh(int P_0, int P_1)
	{
		byte* ptr = (byte*)(&P_1);
		lHaHVkbgZIxlYMgeQBOmrNWwGQDX(P_0, ptr, 32);
	}

	public void NdmWIEyaYAiouYgIzDUKhUIVtqUr(int P_0, uint P_1)
	{
		xFDsVjPHoFWagUqmfZWqBWfzAHIh(P_0, (int)P_1);
	}

	public unsafe void EaWHntnRpJexgcgFRocJiuyXSorCA(int P_0, long P_1)
	{
		byte* ptr = (byte*)(&P_1);
		lHaHVkbgZIxlYMgeQBOmrNWwGQDX(P_0, ptr, 64);
	}

	public void JXOAsKCVVHxFzraEctSkDyXlQvvyA(int P_0, ulong P_1)
	{
		EaWHntnRpJexgcgFRocJiuyXSorCA(P_0, (long)P_1);
	}

	public void JQpaqXeuQULpqtWCBpGzTbMLNzOvA(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= KPPaedJmRWJKJNMkZBQlSWuXFSBD)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < UbzVxOBclfYOjnMjZZpPPsDglhDc)
		{
			int ubzVxOBclfYOjnMjZZpPPsDglhDc = UbzVxOBclfYOjnMjZZpPPsDglhDc;
			throw new Exception("valueBuffer.Length must be >= " + ubzVxOBclfYOjnMjZZpPPsDglhDc);
		}
		for (int i = 0; i < UbzVxOBclfYOjnMjZZpPPsDglhDc; i++)
		{
			iFslKwoAwRAkIVcEFKJXZeCHLtle(P_0, i, out var num, out var b);
			IRwbonMxAijXnbIbuTnCgmMvfqLQ.hYkiqwMCsHYDuQmWsvECAAUWSLGn(num, b, P_1[i]);
		}
	}

	private void iFslKwoAwRAkIVcEFKJXZeCHLtle(int P_0, int P_1, out int P_2, out byte P_3)
	{
		if (P_0 < 0 || P_0 >= KPPaedJmRWJKJNMkZBQlSWuXFSBD)
		{
			throw new IndexOutOfRangeException("entryIndex");
		}
		if (P_1 < 0 || P_1 >= UbzVxOBclfYOjnMjZZpPPsDglhDc)
		{
			throw new ArgumentOutOfRangeException("bitOffset");
		}
		int num = P_0 * UbzVxOBclfYOjnMjZZpPPsDglhDc + P_1;
		P_2 = num / UbzVxOBclfYOjnMjZZpPPsDglhDc;
		P_3 = (byte)(num - P_2 * UbzVxOBclfYOjnMjZZpPPsDglhDc);
	}

	private int wkvzhLDGtVtJsHkTCdTagbIudqdgb(int P_0, out byte P_1)
	{
		if (P_0 < 0 || P_0 >= KPPaedJmRWJKJNMkZBQlSWuXFSBD * UbzVxOBclfYOjnMjZZpPPsDglhDc)
		{
			throw new IndexOutOfRangeException("bitIndex");
		}
		int num = P_0 / UbzVxOBclfYOjnMjZZpPPsDglhDc;
		P_1 = (byte)(P_0 - num * UbzVxOBclfYOjnMjZZpPPsDglhDc);
		return num;
	}

	public void Dispose()
	{
		GwdAjLQnBuKOiRiiCBkRQcPTFSPv(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void ElYfQLDYlRINwwehyhuJqNiJLIEfA()
	{
		try
		{
			GwdAjLQnBuKOiRiiCBkRQcPTFSPv(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void GwdAjLQnBuKOiRiiCBkRQcPTFSPv(bool P_0)
	{
		if (!bfvCRIBNVSWIoHExqUWEzhYofsog)
		{
			if (P_0 && IRwbonMxAijXnbIbuTnCgmMvfqLQ != null)
			{
				IRwbonMxAijXnbIbuTnCgmMvfqLQ.Dispose();
			}
			bfvCRIBNVSWIoHExqUWEzhYofsog = true;
		}
	}
}
