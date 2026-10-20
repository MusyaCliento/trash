using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

internal abstract class jFvndfajLIsLMxvEcfhFneFXVWss : ChutGPBICOllLFbDwaPETGCPjnpCA
{
	protected struct uQzNTOAEYNCKgRdubwQSHetIDLey : IEquatable<uQzNTOAEYNCKgRdubwQSHetIDLey>
	{
		public LocalizedString iboJCjeedqFKoTgBGjeSEwlFFyRD;

		public int HOwpHWtJqhGVyiIVFPjHzYVzoHMO;

		public uQzNTOAEYNCKgRdubwQSHetIDLey(LocalizedString P_0, int P_1)
		{
			iboJCjeedqFKoTgBGjeSEwlFFyRD = P_0;
			HOwpHWtJqhGVyiIVFPjHzYVzoHMO = P_1;
		}

		public bool fGzbIPplPHzSkTLPuDlVLYaGUfGO(object P_0)
		{
			if (!(P_0 is uQzNTOAEYNCKgRdubwQSHetIDLey uQzNTOAEYNCKgRdubwQSHetIDLey2))
			{
				return false;
			}
			if (uQzNTOAEYNCKgRdubwQSHetIDLey2.iboJCjeedqFKoTgBGjeSEwlFFyRD == iboJCjeedqFKoTgBGjeSEwlFFyRD)
			{
				return uQzNTOAEYNCKgRdubwQSHetIDLey2.HOwpHWtJqhGVyiIVFPjHzYVzoHMO == HOwpHWtJqhGVyiIVFPjHzYVzoHMO;
			}
			return false;
		}

		public int qOKiDJZwxKJCxfvQtEaackBMjEZ()
		{
			return (17 * 29 + iboJCjeedqFKoTgBGjeSEwlFFyRD.GetHashCode()) * 29 + HOwpHWtJqhGVyiIVFPjHzYVzoHMO.GetHashCode();
		}

		public bool Equals(uQzNTOAEYNCKgRdubwQSHetIDLey other)
		{
			if (iboJCjeedqFKoTgBGjeSEwlFFyRD == other.iboJCjeedqFKoTgBGjeSEwlFFyRD)
			{
				return HOwpHWtJqhGVyiIVFPjHzYVzoHMO == other.HOwpHWtJqhGVyiIVFPjHzYVzoHMO;
			}
			return false;
		}

		bool IEquatable<uQzNTOAEYNCKgRdubwQSHetIDLey>.Equals(uQzNTOAEYNCKgRdubwQSHetIDLey other)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Equals
			return this.Equals(other);
		}

		[SpecialName]
		public static bool gaxUEIJRzvNKcOchdgJsgcHjXoSfA(uQzNTOAEYNCKgRdubwQSHetIDLey P_0, uQzNTOAEYNCKgRdubwQSHetIDLey P_1)
		{
			return P_0.Equals(P_1);
		}

		[SpecialName]
		public static bool KpmSeQDoEnnNABNgTcwgOpTpTTiN(uQzNTOAEYNCKgRdubwQSHetIDLey P_0, uQzNTOAEYNCKgRdubwQSHetIDLey P_1)
		{
			return !P_0.Equals(P_1);
		}
	}

	private BMeYXymsuXMDMyjfaaClzmryYLZG mnSEMsAhFTnkQCjegWfFVLCiMcnOB;

	protected readonly LocalizedString GJDamLJnmQxyXObUvmZciZVlGxPjA;

	private Id LUZdZcdAhHdLdmnatKsqDDpisCdrA;

	private readonly Dictionary<int, List<uQzNTOAEYNCKgRdubwQSHetIDLey>> LVtCKNHtVWxRhkxRYGkTQWoyNtHhA;

	private bool TFmTWbCnObxbDkTeajtMHDxSJyIr;

	protected bool dGapOzTUMHUpIdKtHUvoXobNNlrv => TFmTWbCnObxbDkTeajtMHDxSJyIr;

	public abstract string aWxJJrCnpmeqmclTDPTQjepbcypsA { get; }

	protected jFvndfajLIsLMxvEcfhFneFXVWss()
	{
		GJDamLJnmQxyXObUvmZciZVlGxPjA = new LocalizedString();
		LVtCKNHtVWxRhkxRYGkTQWoyNtHhA = new Dictionary<int, List<uQzNTOAEYNCKgRdubwQSHetIDLey>>();
	}

	protected jFvndfajLIsLMxvEcfhFneFXVWss(BMeYXymsuXMDMyjfaaClzmryYLZG P_0)
		: this()
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		mnSEMsAhFTnkQCjegWfFVLCiMcnOB = P_0;
	}

	public void LXXnWsDVIgOSTwkzKCSaFgvWkxDIA()
	{
		vWJmbpvFeJzKUDwbFNlKSwonRyyo();
		if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
		{
			OJsACpVdvTakqIBwTXMtANrEPBBS();
		}
	}

	protected virtual void vWJmbpvFeJzKUDwbFNlKSwonRyyo()
	{
		podbBPaRMuOCDpklHQudVdSBrURO();
		SMvupJzMtAnsimKORrGNsRVPKmcX();
		LocalizationManager.Add(this, ref LUZdZcdAhHdLdmnatKsqDDpisCdrA);
		TFmTWbCnObxbDkTeajtMHDxSJyIr = true;
	}

	public virtual void podbBPaRMuOCDpklHQudVdSBrURO()
	{
		YpzmZuxhPasmCuJTsDwvvqRktbhd();
		LocalizationManager.Remove(ref LUZdZcdAhHdLdmnatKsqDDpisCdrA);
		TFmTWbCnObxbDkTeajtMHDxSJyIr = false;
	}

	public virtual void bpwAmVQtGwBGyOvtxiitKGNJnfRS(BMeYXymsuXMDMyjfaaClzmryYLZG P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("value");
		}
		if (P_0 != mnSEMsAhFTnkQCjegWfFVLCiMcnOB)
		{
			if (mnSEMsAhFTnkQCjegWfFVLCiMcnOB != null)
			{
				YpzmZuxhPasmCuJTsDwvvqRktbhd();
			}
			mnSEMsAhFTnkQCjegWfFVLCiMcnOB = P_0;
			LXXnWsDVIgOSTwkzKCSaFgvWkxDIA();
		}
	}

	public virtual void WFhSGNWPafnDBVFrKcYWKWWaVrjl()
	{
		GJDamLJnmQxyXObUvmZciZVlGxPjA.Clear();
	}

	public virtual void HeIcdCCpZhLydGytFlnbSIDefvCBb()
	{
		GJDamLJnmQxyXObUvmZciZVlGxPjA.Clear();
	}

	public virtual void cwUahnpqwmWpOYgoibmoVeKGCqrw()
	{
		GJDamLJnmQxyXObUvmZciZVlGxPjA.Clear();
	}

	public virtual bool xZrerYupDOdVXRUEcCKkbPBksnvpA(jFvndfajLIsLMxvEcfhFneFXVWss P_0, bool P_1)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!object.Equals(GetType(), P_0.GetType()))
		{
			return false;
		}
		if (mnSEMsAhFTnkQCjegWfFVLCiMcnOB == null != (P_0.mnSEMsAhFTnkQCjegWfFVLCiMcnOB == null))
		{
			return false;
		}
		if (mnSEMsAhFTnkQCjegWfFVLCiMcnOB != null)
		{
			if (!string.Equals(mnSEMsAhFTnkQCjegWfFVLCiMcnOB.keyCategory, P_0.mnSEMsAhFTnkQCjegWfFVLCiMcnOB.keyCategory, StringComparison.Ordinal) || !string.Equals(mnSEMsAhFTnkQCjegWfFVLCiMcnOB.scriptingName, P_0.mnSEMsAhFTnkQCjegWfFVLCiMcnOB.scriptingName, StringComparison.Ordinal) || !string.Equals(mnSEMsAhFTnkQCjegWfFVLCiMcnOB.key, P_0.mnSEMsAhFTnkQCjegWfFVLCiMcnOB.key, StringComparison.Ordinal))
			{
				return false;
			}
			if (P_1 && !string.Equals(mnSEMsAhFTnkQCjegWfFVLCiMcnOB.nonLocalizedDescriptiveName, P_0.mnSEMsAhFTnkQCjegWfFVLCiMcnOB.nonLocalizedDescriptiveName, StringComparison.Ordinal))
			{
				return false;
			}
		}
		return true;
	}

	protected virtual void YpzmZuxhPasmCuJTsDwvvqRktbhd()
	{
		GJDamLJnmQxyXObUvmZciZVlGxPjA.Clear();
		LVtCKNHtVWxRhkxRYGkTQWoyNtHhA.Clear();
	}

	protected BMeYXymsuXMDMyjfaaClzmryYLZG BMBXvRAQqSEcDAWEUIhxPASEJkSIb()
	{
		return mnSEMsAhFTnkQCjegWfFVLCiMcnOB;
	}

	protected virtual void OJsACpVdvTakqIBwTXMtANrEPBBS()
	{
		_ = aWxJJrCnpmeqmclTDPTQjepbcypsA;
	}

	void ChutGPBICOllLFbDwaPETGCPjnpCA.Localize()
	{
		OJsACpVdvTakqIBwTXMtANrEPBBS();
	}

	protected virtual void ZMFRLsiLxJwlABCAqCnahnNMoAlu(int P_0)
	{
	}

	protected virtual void SMvupJzMtAnsimKORrGNsRVPKmcX()
	{
	}

	protected void GgJIdjbrcTsxVbBNSBtCrqQLiCRBb(int P_0, uQzNTOAEYNCKgRdubwQSHetIDLey P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) != 0)
			{
				if (!LVtCKNHtVWxRhkxRYGkTQWoyNtHhA.TryGetValue(num, out var value))
				{
					value = new List<uQzNTOAEYNCKgRdubwQSHetIDLey>();
					LVtCKNHtVWxRhkxRYGkTQWoyNtHhA[num] = value;
				}
				if (!value.Contains(P_1))
				{
					value.Add(P_1);
				}
			}
		}
	}

	protected void GWJKEUEUtRsnyTwKtqgLlULJsHwi(int P_0, uQzNTOAEYNCKgRdubwQSHetIDLey P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !LVtCKNHtVWxRhkxRYGkTQWoyNtHhA.TryGetValue(num, out var value))
			{
				continue;
			}
			for (int num2 = value.Count - 1; num2 >= 0; num2--)
			{
				if (uQzNTOAEYNCKgRdubwQSHetIDLey.gaxUEIJRzvNKcOchdgJsgcHjXoSfA(value[num2], P_1))
				{
					value.RemoveAt(num2);
				}
			}
		}
	}

	protected void stIdSjGLgdmpdoKfxdFGeinstuIX(int P_0)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !LVtCKNHtVWxRhkxRYGkTQWoyNtHhA.TryGetValue(num, out var value))
			{
				continue;
			}
			int count = value.Count;
			for (int j = 0; j < count; j++)
			{
				if (value[j].HOwpHWtJqhGVyiIVFPjHzYVzoHMO != 0)
				{
					ZMFRLsiLxJwlABCAqCnahnNMoAlu(value[j].HOwpHWtJqhGVyiIVFPjHzYVzoHMO);
				}
				if (value[j].iboJCjeedqFKoTgBGjeSEwlFFyRD != null)
				{
					value[j].iboJCjeedqFKoTgBGjeSEwlFFyRD.Clear();
				}
			}
		}
	}
}
