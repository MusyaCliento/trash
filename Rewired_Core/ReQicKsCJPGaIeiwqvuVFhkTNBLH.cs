using System;
using Rewired.Internal;
using Rewired.Internal.Glyphs;
using Rewired.Utils.Classes.Data;

internal sealed class ReQicKsCJPGaIeiwqvuVFhkTNBLH : IPrefetch, IDisposable
{
	private Action qqlnVJXpGJtGaNyZMurbmppAMXRG;

	private Id AAAFgjUIPbZByNRlVEZyrQBGtYQE;

	private bool fKVOvyRlWZmwnjFtOOzsKtaASRbb;

	public ReQicKsCJPGaIeiwqvuVFhkTNBLH(Action P_0)
	{
		qqlnVJXpGJtGaNyZMurbmppAMXRG = P_0;
		AAAFgjUIPbZByNRlVEZyrQBGtYQE = 0u;
		GlyphManager.Add(this, ref AAAFgjUIPbZByNRlVEZyrQBGtYQE);
	}

	void IPrefetch.Prefetch()
	{
		qqlnVJXpGJtGaNyZMurbmppAMXRG();
	}

	private void iOMeytfgMdHahTwYvixWHDOKgqBn(bool P_0)
	{
		if (!fKVOvyRlWZmwnjFtOOzsKtaASRbb)
		{
			if (P_0)
			{
				GlyphManager.Remove(ref AAAFgjUIPbZByNRlVEZyrQBGtYQE);
			}
			fKVOvyRlWZmwnjFtOOzsKtaASRbb = true;
		}
	}

	public void Dispose()
	{
		iOMeytfgMdHahTwYvixWHDOKgqBn(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}
}
