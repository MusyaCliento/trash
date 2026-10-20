using System;
using Rewired.Utils;

internal class NtFLRVDnENYMXbtywMQbIfXwjuwG : IDisposable
{
	private readonly TLjofzBmfBMLdKYQRjtOpIYGxOeK fkMBZinlDDhBCeSwJjDvFDDQUfTJA;

	private readonly int IuDvoSyZjDCfbjswmYsrvUIyxBFg;

	private long mILGRoBWHvZycSFHxgXlORTJTiIMA;

	private long EHEAogfOPBNtGZkViBXYRsxZigXeb;

	private int AOosCZSLQOGzNVawkdQlFnuVqjNP;

	private bool TtMoWopPhldplhtkwdkASaDWWacU;

	private uint mBbEdLWepuJhXqLPfeisSltSDeUg;

	private bool XXzLjBezghroJxQvaPtlmCwYyfyi;

	public int wrlSCGNZEJuLBAzLpEfLaNmeFQib => IuDvoSyZjDCfbjswmYsrvUIyxBFg;

	public int hbtELaaaSUAlaDlwAirqwnIvrsyWB => AOosCZSLQOGzNVawkdQlFnuVqjNP;

	public bool niymEjVgGegJPSdsfHbBeRBzVcbs => TtMoWopPhldplhtkwdkASaDWWacU;

	public NtFLRVDnENYMXbtywMQbIfXwjuwG(int P_0)
	{
		IuDvoSyZjDCfbjswmYsrvUIyxBFg = P_0;
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("sizeInBytes");
		}
		fkMBZinlDDhBCeSwJjDvFDDQUfTJA = new TLjofzBmfBMLdKYQRjtOpIYGxOeK(P_0);
	}

	public unsafe int tNIHKTGTupNAxnUWTlzwYiePfUhi(byte* P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		P_3 = (int)mILGRoBWHvZycSFHxgXlORTJTiIMA;
		P_4 = mBbEdLWepuJhXqLPfeisSltSDeUg;
		if (P_0 == null || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		int num = fkMBZinlDDhBCeSwJjDvFDDQUfTJA.ytDpsKkOvAFyxPUYzDsevFVOnogk(P_0, P_1, P_2, (int)mILGRoBWHvZycSFHxgXlORTJTiIMA);
		if (num == 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += fkMBZinlDDhBCeSwJjDvFDDQUfTJA.ytDpsKkOvAFyxPUYzDsevFVOnogk(P_0 + num, P_1 - num, P_2 - num);
		}
		vNbqDrhNIalFUIHfpKHQLUfZMwpN(num);
		return num;
	}

	public unsafe int pxTYOFqKCfPWlZBJXTDFkCUcixnV(IntPtr P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			P_3 = (int)mILGRoBWHvZycSFHxgXlORTJTiIMA;
			P_4 = mBbEdLWepuJhXqLPfeisSltSDeUg;
			return 0;
		}
		return tNIHKTGTupNAxnUWTlzwYiePfUhi((byte*)(void*)P_0, P_1, P_2, out P_3, out P_4);
	}

	public unsafe int DoLvrZVKJgSppufYyFeMlbDgcfcj(byte[] P_0, int P_1, out int P_2, out uint P_3)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = (int)mILGRoBWHvZycSFHxgXlORTJTiIMA;
			P_3 = mBbEdLWepuJhXqLPfeisSltSDeUg;
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return tNIHKTGTupNAxnUWTlzwYiePfUhi(ptr, P_0.Length, P_1, out P_2, out P_3);
		}
	}

	public unsafe int vgwUDHevwiFPDFEbZVnAYnQDHNOn(byte* P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return tNIHKTGTupNAxnUWTlzwYiePfUhi(P_0, P_1, P_2, out num, out num2);
	}

	public int XrPNYcOJSApBKyzzOMUaDwGYnmpe(IntPtr P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return pxTYOFqKCfPWlZBJXTDFkCUcixnV(P_0, P_1, P_2, out num, out num2);
	}

	public int njZihpIlvDquKjaAfjaaBkPTSiSVA(byte[] P_0, int P_1)
	{
		int num;
		uint num2;
		return DoLvrZVKJgSppufYyFeMlbDgcfcj(P_0, P_1, out num, out num2);
	}

	public unsafe int xCHeAPJZGqgFVCWrcDiHVtJtlzZAb(byte* P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || AOosCZSLQOGzNVawkdQlFnuVqjNP == 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > AOosCZSLQOGzNVawkdQlFnuVqjNP)
		{
			P_2 = AOosCZSLQOGzNVawkdQlFnuVqjNP;
		}
		int num = fkMBZinlDDhBCeSwJjDvFDDQUfTJA.uAaSWFMKrhpHYbOdUCQVMrdijnKN(P_0, P_1, P_2, (int)EHEAogfOPBNtGZkViBXYRsxZigXeb);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += fkMBZinlDDhBCeSwJjDvFDDQUfTJA.uAaSWFMKrhpHYbOdUCQVMrdijnKN(P_0 + num, P_1 - num, P_2 - num);
		}
		snkGeeBQjnmmviVoWcuncSManGMOc(num);
		return num;
	}

	public unsafe int qjVodHYpJRiskeBlUtqNAmgUjzZR(byte[] P_0, int P_1)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return xCHeAPJZGqgFVCWrcDiHVtJtlzZAb(ptr, P_0.Length, P_1);
		}
	}

	public unsafe int omLXwdMIToHWGxSmFFfpCTqOIYYe(IntPtr P_0, int P_1, int P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		return xCHeAPJZGqgFVCWrcDiHVtJtlzZAb((byte*)(void*)P_0, P_1, P_2);
	}

	public unsafe int BcCVEJIcipvuAqtYecbFURMKHTvK(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || AOosCZSLQOGzNVawkdQlFnuVqjNP == 0 || P_3 < 0 || P_3 >= IuDvoSyZjDCfbjswmYsrvUIyxBFg)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > AOosCZSLQOGzNVawkdQlFnuVqjNP)
		{
			P_2 = AOosCZSLQOGzNVawkdQlFnuVqjNP;
		}
		int num = fkMBZinlDDhBCeSwJjDvFDDQUfTJA.uAaSWFMKrhpHYbOdUCQVMrdijnKN(P_0, P_1, P_2, P_3);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += fkMBZinlDDhBCeSwJjDvFDDQUfTJA.uAaSWFMKrhpHYbOdUCQVMrdijnKN(P_0 + num, P_1 - num, P_2 - num);
		}
		return num;
	}

	public unsafe int GqTQatWyFzvrmXQtzAeTWlOmczSs(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return BcCVEJIcipvuAqtYecbFURMKHTvK(ptr, P_0.Length, P_1, P_2);
		}
	}

	public unsafe int THiBtgGrnkPDiyPbIiYsBsccLqKdb(IntPtr P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_3 <= 0)
		{
			return 0;
		}
		return BcCVEJIcipvuAqtYecbFURMKHTvK((byte*)(void*)P_0, P_1, P_2, P_3);
	}

	public bool ahRGJnxcUMQiWOwPfqCtgDbdBAUFA(int P_0, uint P_1)
	{
		if (P_0 < 0 || P_0 >= IuDvoSyZjDCfbjswmYsrvUIyxBFg)
		{
			return false;
		}
		if (P_0 < mILGRoBWHvZycSFHxgXlORTJTiIMA)
		{
			if (P_1 == mBbEdLWepuJhXqLPfeisSltSDeUg)
			{
				return true;
			}
		}
		else if (P_0 >= mILGRoBWHvZycSFHxgXlORTJTiIMA)
		{
			if (mBbEdLWepuJhXqLPfeisSltSDeUg == 0)
			{
				return false;
			}
			if (mBbEdLWepuJhXqLPfeisSltSDeUg - 1 == P_1)
			{
				return true;
			}
		}
		return false;
	}

	public void NKcDSPzpTNiOGojxflTNwSfCPkJU()
	{
		mILGRoBWHvZycSFHxgXlORTJTiIMA = 0L;
		EHEAogfOPBNtGZkViBXYRsxZigXeb = 0L;
		AOosCZSLQOGzNVawkdQlFnuVqjNP = 0;
		TtMoWopPhldplhtkwdkASaDWWacU = false;
		mBbEdLWepuJhXqLPfeisSltSDeUg = 0u;
	}

	private void vNbqDrhNIalFUIHfpKHQLUfZMwpN(int P_0)
	{
		if (P_0 <= 0)
		{
			return;
		}
		int num = (int)mILGRoBWHvZycSFHxgXlORTJTiIMA;
		mILGRoBWHvZycSFHxgXlORTJTiIMA += P_0;
		bool flag = false;
		if (num < EHEAogfOPBNtGZkViBXYRsxZigXeb)
		{
			if (mILGRoBWHvZycSFHxgXlORTJTiIMA > EHEAogfOPBNtGZkViBXYRsxZigXeb)
			{
				flag = true;
			}
		}
		else if (num > EHEAogfOPBNtGZkViBXYRsxZigXeb)
		{
			if (mILGRoBWHvZycSFHxgXlORTJTiIMA - IuDvoSyZjDCfbjswmYsrvUIyxBFg > EHEAogfOPBNtGZkViBXYRsxZigXeb)
			{
				flag = true;
			}
		}
		else if (AOosCZSLQOGzNVawkdQlFnuVqjNP > 0)
		{
			flag = true;
		}
		if (flag)
		{
			TtMoWopPhldplhtkwdkASaDWWacU = true;
			EHEAogfOPBNtGZkViBXYRsxZigXeb = mILGRoBWHvZycSFHxgXlORTJTiIMA;
			if (EHEAogfOPBNtGZkViBXYRsxZigXeb >= IuDvoSyZjDCfbjswmYsrvUIyxBFg)
			{
				EHEAogfOPBNtGZkViBXYRsxZigXeb -= IuDvoSyZjDCfbjswmYsrvUIyxBFg;
			}
		}
		if (mILGRoBWHvZycSFHxgXlORTJTiIMA >= IuDvoSyZjDCfbjswmYsrvUIyxBFg)
		{
			mILGRoBWHvZycSFHxgXlORTJTiIMA -= IuDvoSyZjDCfbjswmYsrvUIyxBFg;
			uVfFnFVUtJfnrqJSxFNrfJAlSeYg();
		}
		AOosCZSLQOGzNVawkdQlFnuVqjNP = (int)MathTools.Clamp((long)AOosCZSLQOGzNVawkdQlFnuVqjNP + (long)P_0, 0L, IuDvoSyZjDCfbjswmYsrvUIyxBFg);
	}

	private void snkGeeBQjnmmviVoWcuncSManGMOc(int P_0)
	{
		if (P_0 > 0)
		{
			if (TtMoWopPhldplhtkwdkASaDWWacU)
			{
				TtMoWopPhldplhtkwdkASaDWWacU = false;
			}
			EHEAogfOPBNtGZkViBXYRsxZigXeb += P_0;
			if (EHEAogfOPBNtGZkViBXYRsxZigXeb >= IuDvoSyZjDCfbjswmYsrvUIyxBFg)
			{
				EHEAogfOPBNtGZkViBXYRsxZigXeb -= IuDvoSyZjDCfbjswmYsrvUIyxBFg;
			}
			long num = (long)AOosCZSLQOGzNVawkdQlFnuVqjNP - (long)P_0;
			AOosCZSLQOGzNVawkdQlFnuVqjNP = (int)((num >= 0) ? num : 0);
		}
	}

	private void uVfFnFVUtJfnrqJSxFNrfJAlSeYg()
	{
		if (mBbEdLWepuJhXqLPfeisSltSDeUg == uint.MaxValue)
		{
			mBbEdLWepuJhXqLPfeisSltSDeUg = 0u;
		}
		else
		{
			mBbEdLWepuJhXqLPfeisSltSDeUg++;
		}
	}

	public void Dispose()
	{
		yzpbvYIuGiGBpGqRNwJENEEDKpzyA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void RsWuowKierTiZZAQlfmLqzyuaRli()
	{
		try
		{
			yzpbvYIuGiGBpGqRNwJENEEDKpzyA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void yzpbvYIuGiGBpGqRNwJENEEDKpzyA(bool P_0)
	{
		if (!XXzLjBezghroJxQvaPtlmCwYyfyi)
		{
			if (P_0 && fkMBZinlDDhBCeSwJjDvFDDQUfTJA != null)
			{
				fkMBZinlDDhBCeSwJjDvFDDQUfTJA.Dispose();
			}
			XXzLjBezghroJxQvaPtlmCwYyfyi = true;
		}
	}
}
