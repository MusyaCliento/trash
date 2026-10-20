using System;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

internal sealed class XrjMaBYihmCVuHIhKxfdMqrzBSpBb : ChutGPBICOllLFbDwaPETGCPjnpCA, IDisposable
{
	private Action SxjEeLgZarCddqrhlYSBhmnlPghHA;

	private Id xevTxKLzkFmvVsgvluGHrRlIzXAA;

	private bool OfvSXkhdMsIHGFodjftcLbVmWWLp;

	public XrjMaBYihmCVuHIhKxfdMqrzBSpBb(Action P_0)
	{
		SxjEeLgZarCddqrhlYSBhmnlPghHA = P_0;
		xevTxKLzkFmvVsgvluGHrRlIzXAA = 0u;
		LocalizationManager.Add(this, ref xevTxKLzkFmvVsgvluGHrRlIzXAA);
	}

	void ChutGPBICOllLFbDwaPETGCPjnpCA.Localize()
	{
		SxjEeLgZarCddqrhlYSBhmnlPghHA();
	}

	private void mPvvWwygqhlHiPyhcjOyduGFhptG(bool P_0)
	{
		if (!OfvSXkhdMsIHGFodjftcLbVmWWLp)
		{
			if (P_0)
			{
				LocalizationManager.Remove(ref xevTxKLzkFmvVsgvluGHrRlIzXAA);
			}
			OfvSXkhdMsIHGFodjftcLbVmWWLp = true;
		}
	}

	public void Dispose()
	{
		mPvvWwygqhlHiPyhcjOyduGFhptG(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}
}
