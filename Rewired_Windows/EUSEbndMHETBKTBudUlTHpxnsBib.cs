using System;
using System.Runtime.InteropServices;

internal class EUSEbndMHETBKTBudUlTHpxnsBib : IDisposable
{
	private int BFzZGfRgELRsvHjEUxljSPahoNiU;

	private uint XrIpEsfKeppplaIJojHeqCvyEusw;

	private IntPtr sSWunPqqmhSjDvShrLmKKjwYDCvR;

	private bool BBPdcgfQHnsrxJSNizFZsyarmrvCA;

	public EUSEbndMHETBKTBudUlTHpxnsBib(uint P_0)
	{
		if (P_0 == 0)
		{
			throw new Exception("size must be > 0!");
		}
		XrIpEsfKeppplaIJojHeqCvyEusw = P_0;
		BFzZGfRgELRsvHjEUxljSPahoNiU = 0;
		try
		{
			sSWunPqqmhSjDvShrLmKKjwYDCvR = Marshal.AllocHGlobal((int)P_0);
			if (sSWunPqqmhSjDvShrLmKKjwYDCvR == IntPtr.Zero)
			{
				throw new Exception("Could not allocate native memory.");
			}
		}
		catch
		{
			throw;
		}
	}

	public unsafe IntPtr PBKzICnWJccGLqnMnPJhqoaMCNos(uint P_0, void* P_1)
	{
		if (BBPdcgfQHnsrxJSNizFZsyarmrvCA)
		{
			return IntPtr.Zero;
		}
		if (P_0 == 0)
		{
			return IntPtr.Zero;
		}
		if (P_0 > XrIpEsfKeppplaIJojHeqCvyEusw)
		{
			return IntPtr.Zero;
		}
		if (BFzZGfRgELRsvHjEUxljSPahoNiU + P_0 >= XrIpEsfKeppplaIJojHeqCvyEusw)
		{
			BFzZGfRgELRsvHjEUxljSPahoNiU = 0;
		}
		IntPtr intPtr = new IntPtr(sSWunPqqmhSjDvShrLmKKjwYDCvR.ToInt64() + BFzZGfRgELRsvHjEUxljSPahoNiU);
		hcMaCRtwBzdJHDcBWkFuWcAHRQLtA.LoGxypjLRcGaXLdHUzHpqphkLtMN(intPtr, (IntPtr)P_1, (int)P_0);
		BFzZGfRgELRsvHjEUxljSPahoNiU += (int)P_0;
		return intPtr;
	}

	public void Dispose()
	{
		wzCscjhOqvdwqKkidnsnSyuIbZpE(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void ruMmwbmadPHeXpvZyzgXqORUEBLj()
	{
		try
		{
			wzCscjhOqvdwqKkidnsnSyuIbZpE(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void wzCscjhOqvdwqKkidnsnSyuIbZpE(bool P_0)
	{
		if (!BBPdcgfQHnsrxJSNizFZsyarmrvCA)
		{
			BBPdcgfQHnsrxJSNizFZsyarmrvCA = true;
			if (sSWunPqqmhSjDvShrLmKKjwYDCvR != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(sSWunPqqmhSjDvShrLmKKjwYDCvR);
			}
		}
	}
}
