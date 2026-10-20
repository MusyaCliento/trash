using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Internal;
using Rewired.Internal.Glyphs;
using Rewired.Utils.Classes.Data;

internal abstract class xQlsIcCwfwtDhbfaGWVFWIidEBvAA : IPrefetch
{
	protected struct vyLTyBkERNfgKeFdGQSJomvVkowAb : IEquatable<vyLTyBkERNfgKeFdGQSJomvVkowAb>
	{
		public KeyedGlyph FZwUsMaLuWooVApyzsUbIaCaJqmL;

		public int lfJhztFhiIbXTxHaNHlxbPMAkGRPb;

		public vyLTyBkERNfgKeFdGQSJomvVkowAb(KeyedGlyph P_0, int P_1)
		{
			FZwUsMaLuWooVApyzsUbIaCaJqmL = P_0;
			lfJhztFhiIbXTxHaNHlxbPMAkGRPb = P_1;
		}

		public bool mWeAVmhkqKEgPiVjWHIrDHTTxrahA(object P_0)
		{
			if (!(P_0 is vyLTyBkERNfgKeFdGQSJomvVkowAb vyLTyBkERNfgKeFdGQSJomvVkowAb2))
			{
				return false;
			}
			if (vyLTyBkERNfgKeFdGQSJomvVkowAb2.FZwUsMaLuWooVApyzsUbIaCaJqmL == FZwUsMaLuWooVApyzsUbIaCaJqmL)
			{
				return vyLTyBkERNfgKeFdGQSJomvVkowAb2.lfJhztFhiIbXTxHaNHlxbPMAkGRPb == lfJhztFhiIbXTxHaNHlxbPMAkGRPb;
			}
			return false;
		}

		public int dERhHePcSdBTsHISfEAgpKTBiDdFb()
		{
			return (17 * 29 + FZwUsMaLuWooVApyzsUbIaCaJqmL.GetHashCode()) * 29 + lfJhztFhiIbXTxHaNHlxbPMAkGRPb.GetHashCode();
		}

		public bool Equals(vyLTyBkERNfgKeFdGQSJomvVkowAb other)
		{
			if (FZwUsMaLuWooVApyzsUbIaCaJqmL == other.FZwUsMaLuWooVApyzsUbIaCaJqmL)
			{
				return lfJhztFhiIbXTxHaNHlxbPMAkGRPb == other.lfJhztFhiIbXTxHaNHlxbPMAkGRPb;
			}
			return false;
		}

		bool IEquatable<vyLTyBkERNfgKeFdGQSJomvVkowAb>.Equals(vyLTyBkERNfgKeFdGQSJomvVkowAb other)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Equals
			return this.Equals(other);
		}

		[SpecialName]
		public static bool HOBgWHDupFHbMiPDEaEuCReIAVTyA(vyLTyBkERNfgKeFdGQSJomvVkowAb P_0, vyLTyBkERNfgKeFdGQSJomvVkowAb P_1)
		{
			return P_0.Equals(P_1);
		}

		[SpecialName]
		public static bool bpYfltXhVErhQazhwPqsbhePCRkU(vyLTyBkERNfgKeFdGQSJomvVkowAb P_0, vyLTyBkERNfgKeFdGQSJomvVkowAb P_1)
		{
			return !P_0.Equals(P_1);
		}
	}

	private hxyHkVRkANnbOzerwOAYbNkvukwJ zcvClRNFXOEJubhjLfkgaHIWfjcm;

	protected readonly KeyedGlyph hzJgCtsIGjeyEBAAammcuiuiwPDBA;

	private Id TXOJrRAFykzJTcWLFMvmPfLQmkoK;

	private readonly Dictionary<int, List<vyLTyBkERNfgKeFdGQSJomvVkowAb>> HSRXAgTpBqgCgcXvtBieOQJigqPC;

	private bool tkBfMdPKgjXHiyNPymReBTtEPzoj;

	protected bool PGeVTQCFwDWUBjgYpDuunPzjGWaEA => tkBfMdPKgjXHiyNPymReBTtEPzoj;

	public abstract object bhSBkAGjBkwrSuotBdJqikBDACFz { get; }

	public abstract string uqOSJTjgWeByxITpQQGTxpnSBQrr { get; }

	protected xQlsIcCwfwtDhbfaGWVFWIidEBvAA()
	{
		hzJgCtsIGjeyEBAAammcuiuiwPDBA = new KeyedGlyph();
		HSRXAgTpBqgCgcXvtBieOQJigqPC = new Dictionary<int, List<vyLTyBkERNfgKeFdGQSJomvVkowAb>>();
	}

	protected xQlsIcCwfwtDhbfaGWVFWIidEBvAA(hxyHkVRkANnbOzerwOAYbNkvukwJ P_0)
		: this()
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		zcvClRNFXOEJubhjLfkgaHIWfjcm = P_0;
	}

	public void hZFNNZUDMXdhhwTYhlmDBqcJGuJ()
	{
		mWtXVyinyXbSWDXrgvRaRuGQqNRA();
		if (GlyphManager.isEnabled && GlyphManager.autoPrefetch)
		{
			XeoygGMgwjnVGDtqjSFauDTrHWHu();
		}
	}

	protected virtual void mWtXVyinyXbSWDXrgvRaRuGQqNRA()
	{
		hslusQMbXbGhliOMVjIfZKRQPdOn();
		KGsenyEFufJFUEtbVJZFCirJOHJic();
		GlyphManager.Add(this, ref TXOJrRAFykzJTcWLFMvmPfLQmkoK);
		tkBfMdPKgjXHiyNPymReBTtEPzoj = true;
	}

	public virtual void hslusQMbXbGhliOMVjIfZKRQPdOn()
	{
		ZhCRvqRbWTIQaFGHPKRcSUegZqml();
		GlyphManager.Remove(ref TXOJrRAFykzJTcWLFMvmPfLQmkoK);
		tkBfMdPKgjXHiyNPymReBTtEPzoj = false;
	}

	public virtual void stYzIVDrfnQPSNHiTPHOLahYVJNJ(hxyHkVRkANnbOzerwOAYbNkvukwJ P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("value");
		}
		if (P_0 != zcvClRNFXOEJubhjLfkgaHIWfjcm)
		{
			if (zcvClRNFXOEJubhjLfkgaHIWfjcm != null)
			{
				ZhCRvqRbWTIQaFGHPKRcSUegZqml();
			}
			zcvClRNFXOEJubhjLfkgaHIWfjcm = P_0;
			hZFNNZUDMXdhhwTYhlmDBqcJGuJ();
		}
	}

	public virtual void RQFqhHjzQGBmelkJWFUyAibifRZH()
	{
		hzJgCtsIGjeyEBAAammcuiuiwPDBA.Clear();
	}

	public virtual bool CXJkVaaBQwBtoSsiiGBJSgOdOLHN(xQlsIcCwfwtDhbfaGWVFWIidEBvAA P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!object.Equals(GetType(), P_0.GetType()))
		{
			return false;
		}
		if (zcvClRNFXOEJubhjLfkgaHIWfjcm == null != (P_0.zcvClRNFXOEJubhjLfkgaHIWfjcm == null))
		{
			return false;
		}
		if (zcvClRNFXOEJubhjLfkgaHIWfjcm != null && (!string.Equals(zcvClRNFXOEJubhjLfkgaHIWfjcm.keyCategory, P_0.zcvClRNFXOEJubhjLfkgaHIWfjcm.keyCategory, StringComparison.Ordinal) || !string.Equals(zcvClRNFXOEJubhjLfkgaHIWfjcm.key, P_0.zcvClRNFXOEJubhjLfkgaHIWfjcm.key, StringComparison.Ordinal)))
		{
			return false;
		}
		return true;
	}

	protected virtual void ZhCRvqRbWTIQaFGHPKRcSUegZqml()
	{
		hzJgCtsIGjeyEBAAammcuiuiwPDBA.Clear();
		HSRXAgTpBqgCgcXvtBieOQJigqPC.Clear();
	}

	protected hxyHkVRkANnbOzerwOAYbNkvukwJ GEPkMuakPSEbGTumQpfhYKqMGUDz()
	{
		return zcvClRNFXOEJubhjLfkgaHIWfjcm;
	}

	protected virtual void XeoygGMgwjnVGDtqjSFauDTrHWHu()
	{
		_ = bhSBkAGjBkwrSuotBdJqikBDACFz;
	}

	void IPrefetch.Prefetch()
	{
		XeoygGMgwjnVGDtqjSFauDTrHWHu();
	}

	protected virtual void OLWTDzUqjBDWJICJvHgWuNAPeYcr(int P_0)
	{
	}

	protected virtual void KGsenyEFufJFUEtbVJZFCirJOHJic()
	{
	}

	protected virtual void DQauMzXXmTGMSucaPeMuetqWZabQ(int P_0, vyLTyBkERNfgKeFdGQSJomvVkowAb P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) != 0)
			{
				if (!HSRXAgTpBqgCgcXvtBieOQJigqPC.TryGetValue(num, out var value))
				{
					value = new List<vyLTyBkERNfgKeFdGQSJomvVkowAb>();
					HSRXAgTpBqgCgcXvtBieOQJigqPC[num] = value;
				}
				if (!value.Contains(P_1))
				{
					value.Add(P_1);
				}
			}
		}
	}

	protected virtual void pZDGbWcypJcVRkeoLToFKpsIAknj(int P_0, vyLTyBkERNfgKeFdGQSJomvVkowAb P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !HSRXAgTpBqgCgcXvtBieOQJigqPC.TryGetValue(num, out var value))
			{
				continue;
			}
			for (int num2 = value.Count - 1; num2 >= 0; num2--)
			{
				if (vyLTyBkERNfgKeFdGQSJomvVkowAb.HOBgWHDupFHbMiPDEaEuCReIAVTyA(value[num2], P_1))
				{
					value.RemoveAt(num2);
				}
			}
		}
	}

	protected virtual void uCTKiULgPPfHdhIvfZpdGbbfxaZb(int P_0)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !HSRXAgTpBqgCgcXvtBieOQJigqPC.TryGetValue(num, out var value))
			{
				continue;
			}
			int count = value.Count;
			for (int j = 0; j < count; j++)
			{
				if (value[j].lfJhztFhiIbXTxHaNHlxbPMAkGRPb != 0)
				{
					OLWTDzUqjBDWJICJvHgWuNAPeYcr(value[j].lfJhztFhiIbXTxHaNHlxbPMAkGRPb);
				}
				if (value[j].FZwUsMaLuWooVApyzsUbIaCaJqmL != null)
				{
					value[j].FZwUsMaLuWooVApyzsUbIaCaJqmL.Clear();
				}
			}
		}
	}
}
