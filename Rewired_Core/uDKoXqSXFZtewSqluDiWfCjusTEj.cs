using System;
using Rewired;
using Rewired.Utils.Classes.Utility;

internal class uDKoXqSXFZtewSqluDiWfCjusTEj
{
	private class xrKhQsaTZWOECqVpCNlmVqhLDTThA
	{
		private ButtonStateFlags yyvBrpfnDDRlTxcjZWjKEUvKbSRF;

		private ButtonStateFlags vKYFaDRXPqfwRrjAlBXViclnjxpD;

		private ButtonStateFlags zWkXAfUSjlTWeLlNHZbTScbBiHHH;

		private ButtonStateFlags dZKcubeySsImeChvrQcsnFlCjyjP;

		private uint VrJPUcnAgUYVLEBRGVQkRjLiAMTc;

		private bool GvSEkGdKCgtJInnXUSPUuzpWcECWA;

		private bool fkAXPtYxWQjoVMAWZkPOZbuKsUwr;

		private bool odBjwWhErWZlgUbRYaQKkULCJphV;

		private MkAmdZszAJaeeqjLvEGWKNeYDRxO DrQohXHheTgcHFcxOwoZhMlClkhH;

		public bool LxdDppKfbPEvcAIYzsnTTByKagTsA => GvSEkGdKCgtJInnXUSPUuzpWcECWA;

		public bool OEiNYRvxLDcrcoxsTxwwVBqKUUaA
		{
			get
			{
				return fkAXPtYxWQjoVMAWZkPOZbuKsUwr;
			}
			set
			{
				fkAXPtYxWQjoVMAWZkPOZbuKsUwr = flag;
			}
		}

		public ButtonStateFlags jtGcrIllNTXtJHWtVthdbCfAZcck(bool P_0)
		{
			bool flag;
			bool flag2;
			ButtonStateFlags buttonStateFlags;
			if (P_0)
			{
				flag = (yyvBrpfnDDRlTxcjZWjKEUvKbSRF & ButtonStateFlags.On) != 0;
				flag2 = (vKYFaDRXPqfwRrjAlBXViclnjxpD & ButtonStateFlags.On) != 0;
				buttonStateFlags = ((!fkAXPtYxWQjoVMAWZkPOZbuKsUwr) ? yyvBrpfnDDRlTxcjZWjKEUvKbSRF : ButtonStateFlags.Off);
			}
			else
			{
				flag = (zWkXAfUSjlTWeLlNHZbTScbBiHHH & ButtonStateFlags.On) != 0;
				flag2 = (dZKcubeySsImeChvrQcsnFlCjyjP & ButtonStateFlags.On) != 0;
				buttonStateFlags = ((!fkAXPtYxWQjoVMAWZkPOZbuKsUwr) ? zWkXAfUSjlTWeLlNHZbTScbBiHHH : ButtonStateFlags.Off);
			}
			if (flag)
			{
				if (fkAXPtYxWQjoVMAWZkPOZbuKsUwr)
				{
					if (flag2 && !odBjwWhErWZlgUbRYaQKkULCJphV && DrQohXHheTgcHFcxOwoZhMlClkhH.gIPGDpEAkGlndsbKEBRKzifuRqWPA)
					{
						buttonStateFlags = ButtonStateFlags.Up;
					}
					return buttonStateFlags;
				}
				if (odBjwWhErWZlgUbRYaQKkULCJphV && DrQohXHheTgcHFcxOwoZhMlClkhH.gIPGDpEAkGlndsbKEBRKzifuRqWPA)
				{
					buttonStateFlags |= ButtonStateFlags.Down;
				}
				if (!flag2)
				{
					buttonStateFlags |= ButtonStateFlags.Down;
				}
			}
			else if (flag2 && !fkAXPtYxWQjoVMAWZkPOZbuKsUwr && !odBjwWhErWZlgUbRYaQKkULCJphV)
			{
				buttonStateFlags |= ButtonStateFlags.Up;
			}
			return buttonStateFlags;
		}

		public void ycOKQTcWtrQdSduQpGUkiSoaQmFe()
		{
			vKYFaDRXPqfwRrjAlBXViclnjxpD = yyvBrpfnDDRlTxcjZWjKEUvKbSRF;
			dZKcubeySsImeChvrQcsnFlCjyjP = zWkXAfUSjlTWeLlNHZbTScbBiHHH;
			odBjwWhErWZlgUbRYaQKkULCJphV = fkAXPtYxWQjoVMAWZkPOZbuKsUwr;
			yyvBrpfnDDRlTxcjZWjKEUvKbSRF = ButtonStateFlags.Off;
			zWkXAfUSjlTWeLlNHZbTScbBiHHH = ButtonStateFlags.Off;
		}

		public void mnVCHcbfXHSEakQNVDSZjcBXzIKx(uint P_0)
		{
			if (VrJPUcnAgUYVLEBRGVQkRjLiAMTc < P_0 - 1)
			{
				GvSEkGdKCgtJInnXUSPUuzpWcECWA = false;
			}
		}

		public void GABGCGkzgWtxPKZPdKjANiitmKiFb(bool P_0)
		{
			PinMNZdgQrbeGGUDrlUUsINSGhdcA((P_0 ? yyvBrpfnDDRlTxcjZWjKEUvKbSRF : zWkXAfUSjlTWeLlNHZbTScbBiHHH) | ButtonStateFlags.On, P_0);
		}

		public void PinMNZdgQrbeGGUDrlUUsINSGhdcA(ButtonStateFlags P_0, bool P_1)
		{
			if (P_1)
			{
				yyvBrpfnDDRlTxcjZWjKEUvKbSRF = P_0;
			}
			else
			{
				zWkXAfUSjlTWeLlNHZbTScbBiHHH = P_0;
			}
			VrJPUcnAgUYVLEBRGVQkRjLiAMTc = ReInput.currentFrame;
			if (!GvSEkGdKCgtJInnXUSPUuzpWcECWA)
			{
				GvSEkGdKCgtJInnXUSPUuzpWcECWA = true;
			}
		}

		public void mwZcfoAnglHPRxkvlvdTFlKYAMtjA(ref MkAmdZszAJaeeqjLvEGWKNeYDRxO P_0)
		{
			DrQohXHheTgcHFcxOwoZhMlClkhH = P_0;
			fkAXPtYxWQjoVMAWZkPOZbuKsUwr = P_0.foRaMVKlyBLsIbDkVuGTEjomBNcU;
			odBjwWhErWZlgUbRYaQKkULCJphV = P_0.foRaMVKlyBLsIbDkVuGTEjomBNcU;
		}

		public void ehxQWupaUSpaeGyKGrKAOFmMTApI()
		{
			yyvBrpfnDDRlTxcjZWjKEUvKbSRF = ButtonStateFlags.Off;
			vKYFaDRXPqfwRrjAlBXViclnjxpD = ButtonStateFlags.Off;
			zWkXAfUSjlTWeLlNHZbTScbBiHHH = ButtonStateFlags.Off;
			dZKcubeySsImeChvrQcsnFlCjyjP = ButtonStateFlags.Off;
			VrJPUcnAgUYVLEBRGVQkRjLiAMTc = 0u;
			GvSEkGdKCgtJInnXUSPUuzpWcECWA = false;
			fkAXPtYxWQjoVMAWZkPOZbuKsUwr = false;
			odBjwWhErWZlgUbRYaQKkULCJphV = false;
		}
	}

	public struct MkAmdZszAJaeeqjLvEGWKNeYDRxO
	{
		public bool gIPGDpEAkGlndsbKEBRKzifuRqWPA;

		public bool foRaMVKlyBLsIbDkVuGTEjomBNcU;

		public static MkAmdZszAJaeeqjLvEGWKNeYDRxO PqEQzuzCAaRxVVvmUYKYMHVMrFW => default(MkAmdZszAJaeeqjLvEGWKNeYDRxO);
	}

	[Serializable]
	private sealed class kiAmOWmfvREDOHGOIGUOefCOGidQA
	{
		public static readonly kiAmOWmfvREDOHGOIGUOefCOGidQA _003C_003E9 = new kiAmOWmfvREDOHGOIGUOefCOGidQA();

		public static Func<xrKhQsaTZWOECqVpCNlmVqhLDTThA> _003C_003E9__22_0;

		internal uDKoXqSXFZtewSqluDiWfCjusTEj uEgdhXHlyhyEemKVHpJShFYoDRgwA()
		{
			return new uDKoXqSXFZtewSqluDiWfCjusTEj();
		}

		internal void IHXnUmMrfEhpNQVHBhAVuELiikuG(uDKoXqSXFZtewSqluDiWfCjusTEj P_0)
		{
			P_0.xzvJaPhwuVNeEWZjQDpbEPfUtqQI();
		}

		internal xrKhQsaTZWOECqVpCNlmVqhLDTThA TfKIlFZoSTfwcbxnkMNMauVLHqRyA()
		{
			return new xrKhQsaTZWOECqVpCNlmVqhLDTThA();
		}
	}

	private const int DpQeCXmxhaKORQOxFFLzpJGUSOkE = 20;

	private const int cyhYjDPvqMNdnrIsFcRnygIdGxtaA = 10;

	private static ObjectPool<uDKoXqSXFZtewSqluDiWfCjusTEj> VeTcKUNORhTaKRDaxCJzBzWlCieQA;

	private static uDKoXqSXFZtewSqluDiWfCjusTEj[] BxvdoCGMKXVfsKJuMOEYCORHzlFbc;

	private static int EdXxEiPldAzkSwlpzyaCYJTqsBQV;

	public int gSGBFXiVWXNmNmKsDLicUTJnFqyX;

	private UpdateLoopDataSet<xrKhQsaTZWOECqVpCNlmVqhLDTThA> BwiFIODMMAkjyesBZnqWdVyfBGumB;

	public bool ZpsuCDaqAStotzUOgTMfzFHheVSF
	{
		get
		{
			int count = BwiFIODMMAkjyesBZnqWdVyfBGumB.Count;
			for (int i = 0; i < count; i++)
			{
				if (BwiFIODMMAkjyesBZnqWdVyfBGumB[i].LxdDppKfbPEvcAIYzsnTTByKagTsA)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool UlNfLxjyciuQROdOBntLKLzYzJIQA
	{
		get
		{
			return BwiFIODMMAkjyesBZnqWdVyfBGumB.Current.OEiNYRvxLDcrcoxsTxwwVBqKUUaA;
		}
		set
		{
			BwiFIODMMAkjyesBZnqWdVyfBGumB.Current.OEiNYRvxLDcrcoxsTxwwVBqKUUaA = flag;
		}
	}

	static uDKoXqSXFZtewSqluDiWfCjusTEj()
	{
		VeTcKUNORhTaKRDaxCJzBzWlCieQA = new ObjectPool<uDKoXqSXFZtewSqluDiWfCjusTEj>(20, kiAmOWmfvREDOHGOIGUOefCOGidQA._003C_003E9.uEgdhXHlyhyEemKVHpJShFYoDRgwA, kiAmOWmfvREDOHGOIGUOefCOGidQA._003C_003E9.IHXnUmMrfEhpNQVHBhAVuELiikuG);
		BxvdoCGMKXVfsKJuMOEYCORHzlFbc = new uDKoXqSXFZtewSqluDiWfCjusTEj[20];
	}

	public static void sWlZZXjeurEtztaMtqpZyVcdBddG()
	{
		EdXxEiPldAzkSwlpzyaCYJTqsBQV = 0;
		Array.Clear(BxvdoCGMKXVfsKJuMOEYCORHzlFbc, 0, BxvdoCGMKXVfsKJuMOEYCORHzlFbc.Length);
		VeTcKUNORhTaKRDaxCJzBzWlCieQA.Clear();
	}

	public static uDKoXqSXFZtewSqluDiWfCjusTEj VLHuJvQzgCEmDCsqmQeoCEKNYomp(int P_0)
	{
		for (int i = 0; i < EdXxEiPldAzkSwlpzyaCYJTqsBQV; i++)
		{
			if (BxvdoCGMKXVfsKJuMOEYCORHzlFbc[i] != null && BxvdoCGMKXVfsKJuMOEYCORHzlFbc[i].gSGBFXiVWXNmNmKsDLicUTJnFqyX == P_0)
			{
				return BxvdoCGMKXVfsKJuMOEYCORHzlFbc[i];
			}
		}
		return null;
	}

	public static uDKoXqSXFZtewSqluDiWfCjusTEj xyBNkSDsBdBssqCdfkZCzVtBjKNR(int P_0, MkAmdZszAJaeeqjLvEGWKNeYDRxO P_1)
	{
		uDKoXqSXFZtewSqluDiWfCjusTEj uDKoXqSXFZtewSqluDiWfCjusTEj2 = VLHuJvQzgCEmDCsqmQeoCEKNYomp(P_0);
		if (uDKoXqSXFZtewSqluDiWfCjusTEj2 != null)
		{
			return uDKoXqSXFZtewSqluDiWfCjusTEj2;
		}
		uDKoXqSXFZtewSqluDiWfCjusTEj2 = VeTcKUNORhTaKRDaxCJzBzWlCieQA.Get();
		uDKoXqSXFZtewSqluDiWfCjusTEj2.rLngMtSIeZKCtsUICwmNlqogyToc(P_0);
		uDKoXqSXFZtewSqluDiWfCjusTEj2.RZdQgQWKOPLqCQLLhmDqqWZtUdkk(ref P_1);
		uDKoXqSXFZtewSqluDiWfCjusTEj2.BwiFIODMMAkjyesBZnqWdVyfBGumB.SetUpdateLoop(ReInput.currentUpdateLoop);
		AzMoPHDMeyLJPSDIFPuJxSkyFbfI(uDKoXqSXFZtewSqluDiWfCjusTEj2);
		return uDKoXqSXFZtewSqluDiWfCjusTEj2;
	}

	public static void luiDXSazuIFJFBdLDyHrBcmMOuyF(UpdateLoopType P_0)
	{
		for (int i = 0; i < EdXxEiPldAzkSwlpzyaCYJTqsBQV; i++)
		{
			if (BxvdoCGMKXVfsKJuMOEYCORHzlFbc[i] != null)
			{
				BxvdoCGMKXVfsKJuMOEYCORHzlFbc[i].qYMBsXJrIGllUxsVVvcRnofvDgaI(P_0);
			}
		}
	}

	public static void ryVGNmPzjHDafpSESbtmksbJEypNA(UpdateLoopType P_0, uint P_1)
	{
		for (int num = EdXxEiPldAzkSwlpzyaCYJTqsBQV - 1; num >= 0; num--)
		{
			if (BxvdoCGMKXVfsKJuMOEYCORHzlFbc[num] == null)
			{
				if (num == EdXxEiPldAzkSwlpzyaCYJTqsBQV - 1)
				{
					EdXxEiPldAzkSwlpzyaCYJTqsBQV--;
				}
			}
			else
			{
				BxvdoCGMKXVfsKJuMOEYCORHzlFbc[num].KMJgjZCgUOYjCGxtsreUmiXZRsOd(P_1);
				if (!BxvdoCGMKXVfsKJuMOEYCORHzlFbc[num].ZpsuCDaqAStotzUOgTMfzFHheVSF)
				{
					JrouVitsCXPKBZNdEoISZCCyCPih(num);
				}
			}
		}
	}

	private static void AzMoPHDMeyLJPSDIFPuJxSkyFbfI(uDKoXqSXFZtewSqluDiWfCjusTEj P_0)
	{
		int num = nFEumdaRnZfOVZLggOVpNgSTUWmt();
		if (num < 0)
		{
			if (EdXxEiPldAzkSwlpzyaCYJTqsBQV == BxvdoCGMKXVfsKJuMOEYCORHzlFbc.Length)
			{
				uDKoXqSXFZtewSqluDiWfCjusTEj[] bxvdoCGMKXVfsKJuMOEYCORHzlFbc = BxvdoCGMKXVfsKJuMOEYCORHzlFbc;
				BxvdoCGMKXVfsKJuMOEYCORHzlFbc = new uDKoXqSXFZtewSqluDiWfCjusTEj[BxvdoCGMKXVfsKJuMOEYCORHzlFbc.Length + 10];
				Array.Copy(bxvdoCGMKXVfsKJuMOEYCORHzlFbc, BxvdoCGMKXVfsKJuMOEYCORHzlFbc, bxvdoCGMKXVfsKJuMOEYCORHzlFbc.Length);
			}
			num = EdXxEiPldAzkSwlpzyaCYJTqsBQV;
			EdXxEiPldAzkSwlpzyaCYJTqsBQV++;
		}
		BxvdoCGMKXVfsKJuMOEYCORHzlFbc[num] = P_0;
	}

	private static void JrouVitsCXPKBZNdEoISZCCyCPih(int P_0)
	{
		if (P_0 >= 0 && P_0 < EdXxEiPldAzkSwlpzyaCYJTqsBQV)
		{
			uDKoXqSXFZtewSqluDiWfCjusTEj uDKoXqSXFZtewSqluDiWfCjusTEj2 = BxvdoCGMKXVfsKJuMOEYCORHzlFbc[P_0];
			if (uDKoXqSXFZtewSqluDiWfCjusTEj2 != null)
			{
				VeTcKUNORhTaKRDaxCJzBzWlCieQA.Return(uDKoXqSXFZtewSqluDiWfCjusTEj2);
				BxvdoCGMKXVfsKJuMOEYCORHzlFbc[P_0] = null;
			}
			if (P_0 == EdXxEiPldAzkSwlpzyaCYJTqsBQV - 1)
			{
				EdXxEiPldAzkSwlpzyaCYJTqsBQV--;
			}
		}
	}

	private static int nFEumdaRnZfOVZLggOVpNgSTUWmt()
	{
		for (int i = 0; i < EdXxEiPldAzkSwlpzyaCYJTqsBQV; i++)
		{
			if (BxvdoCGMKXVfsKJuMOEYCORHzlFbc[i] == null)
			{
				return i;
			}
		}
		if (EdXxEiPldAzkSwlpzyaCYJTqsBQV >= BxvdoCGMKXVfsKJuMOEYCORHzlFbc.Length)
		{
			return -1;
		}
		int edXxEiPldAzkSwlpzyaCYJTqsBQV = EdXxEiPldAzkSwlpzyaCYJTqsBQV;
		EdXxEiPldAzkSwlpzyaCYJTqsBQV++;
		return edXxEiPldAzkSwlpzyaCYJTqsBQV;
	}

	public ButtonStateFlags VKkpXRIRVAnJYOgLIxoNNDjxsoHK(bool P_0)
	{
		return BwiFIODMMAkjyesBZnqWdVyfBGumB.Current.jtGcrIllNTXtJHWtVthdbCfAZcck(P_0);
	}

	public uDKoXqSXFZtewSqluDiWfCjusTEj()
	{
		BwiFIODMMAkjyesBZnqWdVyfBGumB = new UpdateLoopDataSet<xrKhQsaTZWOECqVpCNlmVqhLDTThA>(ReInput.UserData.ConfigVars.updateLoop, kiAmOWmfvREDOHGOIGUOefCOGidQA._003C_003E9.TfKIlFZoSTfwcbxnkMNMauVLHqRyA);
		xzvJaPhwuVNeEWZjQDpbEPfUtqQI();
	}

	public void qYMBsXJrIGllUxsVVvcRnofvDgaI(UpdateLoopType P_0)
	{
		BwiFIODMMAkjyesBZnqWdVyfBGumB.SetUpdateLoop(P_0);
		BwiFIODMMAkjyesBZnqWdVyfBGumB.Current.ycOKQTcWtrQdSduQpGUkiSoaQmFe();
	}

	public void KMJgjZCgUOYjCGxtsreUmiXZRsOd(uint P_0)
	{
		BwiFIODMMAkjyesBZnqWdVyfBGumB.Current.mnVCHcbfXHSEakQNVDSZjcBXzIKx(P_0);
	}

	public void azOAmVbSCBLbfMFIiSbbJYUGpGSe(UpdateLoopType P_0, bool P_1)
	{
		BwiFIODMMAkjyesBZnqWdVyfBGumB.Current.GABGCGkzgWtxPKZPdKjANiitmKiFb(P_1);
	}

	public void bIPLegpiaGftMsrjrewpGFnjpqiNA(UpdateLoopType P_0, ButtonStateFlags P_1, bool P_2)
	{
		BwiFIODMMAkjyesBZnqWdVyfBGumB.Current.PinMNZdgQrbeGGUDrlUUsINSGhdcA(P_1, P_2);
	}

	private void RZdQgQWKOPLqCQLLhmDqqWZtUdkk(ref MkAmdZszAJaeeqjLvEGWKNeYDRxO P_0)
	{
		int count = BwiFIODMMAkjyesBZnqWdVyfBGumB.Count;
		for (int i = 0; i < count; i++)
		{
			BwiFIODMMAkjyesBZnqWdVyfBGumB[i].mwZcfoAnglHPRxkvlvdTFlKYAMtjA(ref P_0);
		}
	}

	private void rLngMtSIeZKCtsUICwmNlqogyToc(int P_0)
	{
		gSGBFXiVWXNmNmKsDLicUTJnFqyX = P_0;
	}

	private void xzvJaPhwuVNeEWZjQDpbEPfUtqQI()
	{
		gSGBFXiVWXNmNmKsDLicUTJnFqyX = -1;
		int count = BwiFIODMMAkjyesBZnqWdVyfBGumB.Count;
		for (int i = 0; i < count; i++)
		{
			BwiFIODMMAkjyesBZnqWdVyfBGumB[i].ehxQWupaUSpaeGyKGrKAOFmMTApI();
		}
	}
}
