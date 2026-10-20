using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class UKcGCZmMjdBnlJzaymVijbBweZUZ : IEnumerable<byte>, IEnumerable, IDisposable
{
	private struct oGtNRcEmfFOCTYKxOtbBhMXiugSF : IEnumerator<byte>, IEnumerator, IDisposable
	{
		private UKcGCZmMjdBnlJzaymVijbBweZUZ fVUeuTXPVEJJaeIANIitjchRiqnZA;

		private int YAWzDgfGsjjCOQxUzHLwnJkHgsqI;

		byte IEnumerator<byte>.Current => fVUeuTXPVEJJaeIANIitjchRiqnZA.tfsWhvneARqAerbAkSLYSRmmLzTI(YAWzDgfGsjjCOQxUzHLwnJkHgsqI);

		object IEnumerator.Current => fVUeuTXPVEJJaeIANIitjchRiqnZA.tfsWhvneARqAerbAkSLYSRmmLzTI(YAWzDgfGsjjCOQxUzHLwnJkHgsqI);

		public oGtNRcEmfFOCTYKxOtbBhMXiugSF(UKcGCZmMjdBnlJzaymVijbBweZUZ P_0)
		{
			fVUeuTXPVEJJaeIANIitjchRiqnZA = P_0;
			YAWzDgfGsjjCOQxUzHLwnJkHgsqI = -1;
		}

		public void Dispose()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		public bool MoveNext()
		{
			if (YAWzDgfGsjjCOQxUzHLwnJkHgsqI >= fVUeuTXPVEJJaeIANIitjchRiqnZA.FwbpZbuVgTEPHpVUtROxDZuhPecD - 1)
			{
				return false;
			}
			YAWzDgfGsjjCOQxUzHLwnJkHgsqI++;
			return true;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		public void Reset()
		{
			YAWzDgfGsjjCOQxUzHLwnJkHgsqI = 0;
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Reset
			this.Reset();
		}
	}

	private int FwbpZbuVgTEPHpVUtROxDZuhPecD;

	private unsafe byte* ftAYpJOHaojlglmmVhjNbhsjoynSA;

	public int mDpIOFxLwRcqgyzZRJoEWlPavZJr => FwbpZbuVgTEPHpVUtROxDZuhPecD;

	public unsafe bool CPtFymiwxrsLpyXyfJcumMJhEhJw
	{
		get
		{
			if (FwbpZbuVgTEPHpVUtROxDZuhPecD <= 0)
			{
				return true;
			}
			return ftAYpJOHaojlglmmVhjNbhsjoynSA != null;
		}
	}

	public unsafe byte mOztBjNfWAtYQiGUXCjTapPmcbqDA
	{
		get
		{
			if (P_0 < 0 || P_0 >= FwbpZbuVgTEPHpVUtROxDZuhPecD)
			{
				throw new IndexOutOfRangeException();
			}
			return ftAYpJOHaojlglmmVhjNbhsjoynSA[P_0];
		}
		set
		{
			if (num < 0 || num >= FwbpZbuVgTEPHpVUtROxDZuhPecD)
			{
				throw new IndexOutOfRangeException();
			}
			ftAYpJOHaojlglmmVhjNbhsjoynSA[num] = b;
		}
	}

	public UKcGCZmMjdBnlJzaymVijbBweZUZ(int P_0)
	{
		UJJSCwuwSWgtKekhWEUNpgPhBPSQ(P_0);
	}

	public unsafe UKcGCZmMjdBnlJzaymVijbBweZUZ(params byte[] P_0)
		: this(P_0.Length)
	{
		Marshal.Copy(P_0, 0, (IntPtr)ftAYpJOHaojlglmmVhjNbhsjoynSA, P_0.Length);
	}

	public UKcGCZmMjdBnlJzaymVijbBweZUZ(UKcGCZmMjdBnlJzaymVijbBweZUZ P_0)
		: this(P_0.FwbpZbuVgTEPHpVUtROxDZuhPecD)
	{
		P_0.rKmwTOQSNTxBvmfMuKntoLTzBjNP(this, 0, P_0.FwbpZbuVgTEPHpVUtROxDZuhPecD);
	}

	public unsafe UKcGCZmMjdBnlJzaymVijbBweZUZ(byte* P_0, int P_1)
		: this(P_1)
	{
		XtGMeZGVawiSiXBiWNwsFFHEKjXt.VtptHEGzauHBmzIgyIuCOhJjjdviA(P_0, ftAYpJOHaojlglmmVhjNbhsjoynSA, 0, 0, P_1);
	}

	public unsafe bool PYvfhGirtHDuuQHPeNDNPhkLizODb(byte* P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= FwbpZbuVgTEPHpVUtROxDZuhPecD || P_2 >= P_1)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 <= 0 || P_3 > FwbpZbuVgTEPHpVUtROxDZuhPecD || P_3 > P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_3 + P_2;
		if (num >= FwbpZbuVgTEPHpVUtROxDZuhPecD || num >= P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return XtGMeZGVawiSiXBiWNwsFFHEKjXt.VtptHEGzauHBmzIgyIuCOhJjjdviA(ftAYpJOHaojlglmmVhjNbhsjoynSA, P_0, P_2, P_2, P_3);
	}

	public unsafe bool rKmwTOQSNTxBvmfMuKntoLTzBjNP(UKcGCZmMjdBnlJzaymVijbBweZUZ P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return PYvfhGirtHDuuQHPeNDNPhkLizODb(P_0.ftAYpJOHaojlglmmVhjNbhsjoynSA, P_0.FwbpZbuVgTEPHpVUtROxDZuhPecD, P_1, P_2, P_3);
	}

	public unsafe bool uXFqycCHhGJNZnvucXaGgGOOpqaf(byte[] P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= FwbpZbuVgTEPHpVUtROxDZuhPecD || P_1 >= P_0.Length)
		{
			if (P_3)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_2 <= 0 || P_2 > FwbpZbuVgTEPHpVUtROxDZuhPecD || P_2 > P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_2 + P_1;
		if (num >= FwbpZbuVgTEPHpVUtROxDZuhPecD || num >= P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)ftAYpJOHaojlglmmVhjNbhsjoynSA, P_0, P_1, P_1, P_2, P_3);
	}

	public unsafe bool HqmdbrDozFTpkzKJhYWgeHlVhhKD(byte* P_0, int P_1, int P_2, int P_3, int P_4, bool P_5 = true)
	{
		if (P_0 == null)
		{
			if (P_5)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= FwbpZbuVgTEPHpVUtROxDZuhPecD)
		{
			if (P_5)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 < 0 || P_3 >= P_1)
		{
			if (P_5)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_4 <= 0 || P_4 > FwbpZbuVgTEPHpVUtROxDZuhPecD || P_4 > P_1)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_4 + P_2 >= FwbpZbuVgTEPHpVUtROxDZuhPecD)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("sourceStartIndex + length must be < source.Length");
			}
			return false;
		}
		if (P_4 + P_3 >= P_1)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("destinationStartIndex + length must be < destination.Length");
			}
			return false;
		}
		return XtGMeZGVawiSiXBiWNwsFFHEKjXt.VtptHEGzauHBmzIgyIuCOhJjjdviA(ftAYpJOHaojlglmmVhjNbhsjoynSA, P_0, P_2, P_3, P_4);
	}

	public unsafe bool tnxcpGRSldpMkRrnePYebYhBXpuH(UKcGCZmMjdBnlJzaymVijbBweZUZ P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return HqmdbrDozFTpkzKJhYWgeHlVhhKD(P_0.ftAYpJOHaojlglmmVhjNbhsjoynSA, P_0.FwbpZbuVgTEPHpVUtROxDZuhPecD, P_1, P_2, P_3, P_4);
	}

	public unsafe bool McvvBSuVlZptuaUvemKDsSoBQrEq(byte[] P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= FwbpZbuVgTEPHpVUtROxDZuhPecD)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= P_0.Length)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 <= 0 || P_3 > FwbpZbuVgTEPHpVUtROxDZuhPecD || P_3 > P_0.Length)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_3 + P_1 >= FwbpZbuVgTEPHpVUtROxDZuhPecD)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("sourceStartIndex + length must be < source.Length");
			}
			return false;
		}
		if (P_3 + P_2 >= P_0.Length)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("destinationStartIndex + length must be < destination.Length");
			}
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)ftAYpJOHaojlglmmVhjNbhsjoynSA, P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool zSJmuZtKAJMQsryJeujOZAXsqBLd(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= FwbpZbuVgTEPHpVUtROxDZuhPecD || P_2 >= P_1)
		{
			return false;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		int num = P_3 + P_2;
		if (num >= FwbpZbuVgTEPHpVUtROxDZuhPecD)
		{
			P_3 = FwbpZbuVgTEPHpVUtROxDZuhPecD - P_2;
		}
		if (num >= P_1)
		{
			P_3 = P_1 - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return XtGMeZGVawiSiXBiWNwsFFHEKjXt.VtptHEGzauHBmzIgyIuCOhJjjdviA(ftAYpJOHaojlglmmVhjNbhsjoynSA, P_0, P_2, P_2, P_3);
	}

	public unsafe bool tFNjkolyeXtiUxGieRnvWtEAxnoU(UKcGCZmMjdBnlJzaymVijbBweZUZ P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		return zSJmuZtKAJMQsryJeujOZAXsqBLd(P_0.ftAYpJOHaojlglmmVhjNbhsjoynSA, P_0.FwbpZbuVgTEPHpVUtROxDZuhPecD, P_1, P_2);
	}

	public unsafe bool MVSCwWfPBOqCsaOrdyqkRlbxqtZE(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= FwbpZbuVgTEPHpVUtROxDZuhPecD || P_1 >= P_0.Length)
		{
			return false;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		int num = P_2 + P_1;
		if (num >= FwbpZbuVgTEPHpVUtROxDZuhPecD)
		{
			P_2 = FwbpZbuVgTEPHpVUtROxDZuhPecD - P_1;
		}
		if (num >= P_0.Length)
		{
			P_2 = P_0.Length - P_1;
		}
		if (P_2 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)ftAYpJOHaojlglmmVhjNbhsjoynSA, P_0, P_1, P_1, P_2, throwOnError: false);
	}

	public unsafe bool XNGfsNJahnbcJFAeTupbjTNBgpPjA(byte* P_0, int P_1, int P_2, int P_3, int P_4)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= FwbpZbuVgTEPHpVUtROxDZuhPecD)
		{
			return false;
		}
		if (P_3 >= P_1)
		{
			return false;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_4 + P_2 >= FwbpZbuVgTEPHpVUtROxDZuhPecD)
		{
			P_4 = FwbpZbuVgTEPHpVUtROxDZuhPecD - P_2;
		}
		if (P_4 + P_3 >= P_1)
		{
			P_4 = P_1 - P_3;
		}
		if (P_4 <= 0)
		{
			return false;
		}
		return XtGMeZGVawiSiXBiWNwsFFHEKjXt.VtptHEGzauHBmzIgyIuCOhJjjdviA(ftAYpJOHaojlglmmVhjNbhsjoynSA, P_0, P_2, P_3, P_4);
	}

	public unsafe bool sldZauUcMHvDqYBNjMHxwNmWeyRx(UKcGCZmMjdBnlJzaymVijbBweZUZ P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		return XNGfsNJahnbcJFAeTupbjTNBgpPjA(P_0.ftAYpJOHaojlglmmVhjNbhsjoynSA, P_0.FwbpZbuVgTEPHpVUtROxDZuhPecD, P_1, P_2, P_3);
	}

	public unsafe bool zfacYRudZeSEgWbSFKMLqmgyJUif(byte[] P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= FwbpZbuVgTEPHpVUtROxDZuhPecD)
		{
			return false;
		}
		if (P_2 >= P_0.Length)
		{
			return false;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_3 + P_1 >= FwbpZbuVgTEPHpVUtROxDZuhPecD)
		{
			P_3 = FwbpZbuVgTEPHpVUtROxDZuhPecD - P_1;
		}
		if (P_3 + P_2 >= P_0.Length)
		{
			P_3 = P_0.Length - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)ftAYpJOHaojlglmmVhjNbhsjoynSA, P_0, P_1, P_2, P_3, throwOnError: false);
	}

	public void XVorWRXgtlGZoCHldUmeEbaCNDyx(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("length must be >= 0");
		}
		if (FwbpZbuVgTEPHpVUtROxDZuhPecD != P_0)
		{
			UJJSCwuwSWgtKekhWEUNpgPhBPSQ(P_0);
		}
	}

	public unsafe void FWvepEXZPsVynlZQCvxlgaIBFXLdA()
	{
		if (FwbpZbuVgTEPHpVUtROxDZuhPecD != 0 && ftAYpJOHaojlglmmVhjNbhsjoynSA != null)
		{
			XtGMeZGVawiSiXBiWNwsFFHEKjXt.oSiUCYIqBigyjDdAORRwEeuGhUBkB(ftAYpJOHaojlglmmVhjNbhsjoynSA, FwbpZbuVgTEPHpVUtROxDZuhPecD);
		}
	}

	private unsafe void UJJSCwuwSWgtKekhWEUNpgPhBPSQ(int P_0)
	{
		if (P_0 == FwbpZbuVgTEPHpVUtROxDZuhPecD)
		{
			FWvepEXZPsVynlZQCvxlgaIBFXLdA();
			return;
		}
		if (FwbpZbuVgTEPHpVUtROxDZuhPecD > 0)
		{
			YqzSHHVGgunrTMXQINwmoGGJyygf();
		}
		ftAYpJOHaojlglmmVhjNbhsjoynSA = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		if (ftAYpJOHaojlglmmVhjNbhsjoynSA == null)
		{
			throw new Exception("Could not allocate memory for array.");
		}
		FwbpZbuVgTEPHpVUtROxDZuhPecD = P_0;
		FWvepEXZPsVynlZQCvxlgaIBFXLdA();
	}

	private unsafe void YqzSHHVGgunrTMXQINwmoGGJyygf()
	{
		if (ftAYpJOHaojlglmmVhjNbhsjoynSA != null)
		{
			Marshal.FreeHGlobal((IntPtr)ftAYpJOHaojlglmmVhjNbhsjoynSA);
		}
		ftAYpJOHaojlglmmVhjNbhsjoynSA = null;
		FwbpZbuVgTEPHpVUtROxDZuhPecD = 0;
	}

	public void Dispose()
	{
		IrrpPhHpVrynnqfLjkNaflTVkmNE(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void TdYRfpaUJXamleBJMewVBRmzbQaW()
	{
		try
		{
			IrrpPhHpVrynnqfLjkNaflTVkmNE(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void IrrpPhHpVrynnqfLjkNaflTVkmNE(bool P_0)
	{
		YqzSHHVGgunrTMXQINwmoGGJyygf();
	}

	public IEnumerator<byte> GetEnumerator()
	{
		return new oGtNRcEmfFOCTYKxOtbBhMXiugSF(this);
	}

	IEnumerator<byte> IEnumerable<byte>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
		return this.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new oGtNRcEmfFOCTYKxOtbBhMXiugSF(this);
	}
}
