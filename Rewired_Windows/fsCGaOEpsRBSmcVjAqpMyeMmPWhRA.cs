using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class fsCGaOEpsRBSmcVjAqpMyeMmPWhRA : IUnifiedMouseSource, IGetSetEnabled, IDisposable
{
	private class cwaUKJNgrzsixzqWYGPxETIoIImfA
	{
		private enum zcMZhNigpZIivZpSgbwrkKRHVNle
		{
			None = 0,
			Down = 1,
			Up = 2,
			DownAndUp = 3
		}

		private const int lCggMrjbHEOfjHzqtjAWcxWhRnbLB = 120;

		private const int PvXHzrfjLQiwvyCFFaQTVDoUyIWA = 2048;

		public readonly UpdateLoopType JrbBNdcfXeKWUyZElihSkJlygcYOA;

		public uint nNXfzREBnwICpHCyMHmKfwAGEIUGb;

		public uint lmhZjIJTcEXNmxQhEVJbaKFFfKJf;

		public JpWdbQEjoVtlDeVjQQcixjhQPKJkA dLKmJMjvTxBgWqVXEbrJNLHjfhrkA;

		public float icUDKVaBoieVGlTJPgmqSyhQDVRh;

		public float HTARqehkuJxbCzZyyrvZmzPjruPk;

		public float ZUrctrAdWRXeXofyuezaBJKcCBtTb;

		public float fRwgPEdbPphSVGUqHXUvXuplZClGc;

		private bool[] pftenWEvElEbtPWDcIbkRAheEuPT;

		private bool[] RWpcZohWhIupboCdYKYTRxJFugfpA;

		private dFDCbwiBZipHRyrkjzXONBtvgufi VGgcQHGhyDnoZkfQzqhduceaEgqGA;

		private uint pZwgykovCsFRdakNvHvrCftXSLLGA;

		private int YSIIRPqnjBXSwqqKjXBBeWaEEvrm;

		private int vgVTAHmNqCkXctaUtxlgwXRdCiMW;

		private bool pFOkfDIHNhgseGawXHUTmsJonWNVA;

		public cwaUKJNgrzsixzqWYGPxETIoIImfA(dFDCbwiBZipHRyrkjzXONBtvgufi P_0, UpdateLoopType P_1)
		{
			VGgcQHGhyDnoZkfQzqhduceaEgqGA = P_0;
			JrbBNdcfXeKWUyZElihSkJlygcYOA = P_1;
			pftenWEvElEbtPWDcIbkRAheEuPT = new bool[5];
			RWpcZohWhIupboCdYKYTRxJFugfpA = new bool[5];
		}

		public void ThuEYSagIxggonBCQNfLuZYZQIraA(JuQILPLnTzaUqPRUPoBEwsmAnFzt P_0)
		{
			QEjKIFWRPEHEYkJsrEVGbzkjfoVd qEjKIFWRPEHEYkJsrEVGbzkjfoVd = P_0.ojOQrszgKGAoRYHQfEitgVUFHVge;
			if (qEjKIFWRPEHEYkJsrEVGbzkjfoVd != QEjKIFWRPEHEYkJsrEVGbzkjfoVd.None)
			{
				if ((qEjKIFWRPEHEYkJsrEVGbzkjfoVd & QEjKIFWRPEHEYkJsrEVGbzkjfoVd.LeftButtonDown) != QEjKIFWRPEHEYkJsrEVGbzkjfoVd.None || (qEjKIFWRPEHEYkJsrEVGbzkjfoVd & QEjKIFWRPEHEYkJsrEVGbzkjfoVd.RightButtonDown) != QEjKIFWRPEHEYkJsrEVGbzkjfoVd.None)
				{
					IntPtr intPtr = AmOfVgHMXtIpYGmFoUHcniSRkMulA.zuLdjdAFcPBZQRdAmrGSDZgpfcWab();
					if (AmOfVgHMXtIpYGmFoUHcniSRkMulA.MolCoBHyuLVDupYjlPzvmPaxEMSCA() == intPtr && siclGXfsuKjVRXOSGiwkkwZVjwaE(intPtr))
					{
						qEjKIFWRPEHEYkJsrEVGbzkjfoVd &= ~QEjKIFWRPEHEYkJsrEVGbzkjfoVd.LeftButtonDown;
						qEjKIFWRPEHEYkJsrEVGbzkjfoVd &= ~QEjKIFWRPEHEYkJsrEVGbzkjfoVd.RightButtonDown;
					}
				}
				int num = (int)qEjKIFWRPEHEYkJsrEVGbzkjfoVd;
				if (VGgcQHGhyDnoZkfQzqhduceaEgqGA.mqazZFNmbPbXSlrrwoHLlhrnCrAe && VGgcQHGhyDnoZkfQzqhduceaEgqGA.tcDbCjLBauFTswezXJmWioTPmxaq)
				{
					wMpCXmfxJnVjKSJADugHbsmSFjwJA(1, num, 1, 2);
					wMpCXmfxJnVjKSJADugHbsmSFjwJA(0, num, 4, 8);
				}
				else
				{
					wMpCXmfxJnVjKSJADugHbsmSFjwJA(0, num, 1, 2);
					wMpCXmfxJnVjKSJADugHbsmSFjwJA(1, num, 4, 8);
				}
				wMpCXmfxJnVjKSJADugHbsmSFjwJA(2, num, 16, 32);
				wMpCXmfxJnVjKSJADugHbsmSFjwJA(3, num, 64, 128);
				wMpCXmfxJnVjKSJADugHbsmSFjwJA(4, num, 256, 512);
			}
			nNXfzREBnwICpHCyMHmKfwAGEIUGb = P_0.rEfFkEMNHkLONcIxRWIHpWbCbeeg;
			lmhZjIJTcEXNmxQhEVJbaKFFfKJf = P_0.TKmGtThdjxdkmMMMFdplHkHkvpaoB;
			JpWdbQEjoVtlDeVjQQcixjhQPKJkA jpWdbQEjoVtlDeVjQQcixjhQPKJkA = dLKmJMjvTxBgWqVXEbrJNLHjfhrkA;
			dLKmJMjvTxBgWqVXEbrJNLHjfhrkA = P_0.SACFGdiXeXrwTjqkGgkhSYOUrSSn;
			if (dLKmJMjvTxBgWqVXEbrJNLHjfhrkA != jpWdbQEjoVtlDeVjQQcixjhQPKJkA)
			{
				pFOkfDIHNhgseGawXHUTmsJonWNVA = false;
			}
			if (dLKmJMjvTxBgWqVXEbrJNLHjfhrkA == JpWdbQEjoVtlDeVjQQcixjhQPKJkA.MoveRelative)
			{
				icUDKVaBoieVGlTJPgmqSyhQDVRh += (float)P_0.MgxyZfeXJirZfMYwjUHXAWkQzxUj * 0.5f;
				HTARqehkuJxbCzZyyrvZmzPjruPk += (float)P_0.nrxARGgTKxHffmfOIamVvxDVgAKJ * 0.5f * -1f;
			}
			else if ((dLKmJMjvTxBgWqVXEbrJNLHjfhrkA & JpWdbQEjoVtlDeVjQQcixjhQPKJkA.MoveAbsolute) != JpWdbQEjoVtlDeVjQQcixjhQPKJkA.MoveRelative)
			{
				bool num2 = (dLKmJMjvTxBgWqVXEbrJNLHjfhrkA & JpWdbQEjoVtlDeVjQQcixjhQPKJkA.VirtualDesktop) != 0;
				int num3 = AmOfVgHMXtIpYGmFoUHcniSRkMulA.qaNIikZIdIndIbOvcNEKVLUfFRhIA(num2 ? eWeEhNdWXFKKoUYVUXekPSNqerKDA.fotEprJshhogtrTKwWCAVfcTngsGA : eWeEhNdWXFKKoUYVUXekPSNqerKDA.dozrJhwWIcgStwpQrcDqMyDWOIeg);
				int num4 = AmOfVgHMXtIpYGmFoUHcniSRkMulA.qaNIikZIdIndIbOvcNEKVLUfFRhIA(num2 ? eWeEhNdWXFKKoUYVUXekPSNqerKDA.yiKZVPttKvIbSgaziIhMAMmrZJMG : eWeEhNdWXFKKoUYVUXekPSNqerKDA.rUTRJtvUlVqohGjDOlvzfaLpJPck);
				int num5 = (int)((float)P_0.MgxyZfeXJirZfMYwjUHXAWkQzxUj / 65535f * (float)num3);
				int num6 = (int)((65535f - (float)P_0.nrxARGgTKxHffmfOIamVvxDVgAKJ) / 65535f * (float)num4);
				if (!pFOkfDIHNhgseGawXHUTmsJonWNVA)
				{
					YSIIRPqnjBXSwqqKjXBBeWaEEvrm = num5;
					vgVTAHmNqCkXctaUtxlgwXRdCiMW = num6;
					pFOkfDIHNhgseGawXHUTmsJonWNVA = true;
				}
				icUDKVaBoieVGlTJPgmqSyhQDVRh += num5 - YSIIRPqnjBXSwqqKjXBBeWaEEvrm;
				HTARqehkuJxbCzZyyrvZmzPjruPk += num6 - vgVTAHmNqCkXctaUtxlgwXRdCiMW;
				YSIIRPqnjBXSwqqKjXBBeWaEEvrm = num5;
				vgVTAHmNqCkXctaUtxlgwXRdCiMW = num6;
			}
			else
			{
				icUDKVaBoieVGlTJPgmqSyhQDVRh = P_0.MgxyZfeXJirZfMYwjUHXAWkQzxUj;
				HTARqehkuJxbCzZyyrvZmzPjruPk = P_0.nrxARGgTKxHffmfOIamVvxDVgAKJ;
			}
			if (P_0.vyzOryulRBQjQgkHWhEKiaPzGSuSA != 0)
			{
				int num7 = ((MathTools.Abs(P_0.vyzOryulRBQjQgkHWhEKiaPzGSuSA) < 120) ? MathTools.Sign(P_0.vyzOryulRBQjQgkHWhEKiaPzGSuSA) : (P_0.vyzOryulRBQjQgkHWhEKiaPzGSuSA / 120));
				if ((qEjKIFWRPEHEYkJsrEVGbzkjfoVd & QEjKIFWRPEHEYkJsrEVGbzkjfoVd.MouseWheel) != QEjKIFWRPEHEYkJsrEVGbzkjfoVd.None)
				{
					ZUrctrAdWRXeXofyuezaBJKcCBtTb += num7;
				}
				else if ((qEjKIFWRPEHEYkJsrEVGbzkjfoVd & (QEjKIFWRPEHEYkJsrEVGbzkjfoVd)2048) != QEjKIFWRPEHEYkJsrEVGbzkjfoVd.None)
				{
					fRwgPEdbPphSVGUqHXUvXuplZClGc += num7;
				}
			}
		}

		public void WgzkwmMLXzmLvECiwsIFiRzJJARw(ControllerDataUpdater P_0)
		{
			float[] axisValues = P_0.axisValues;
			axisValues[0] = icUDKVaBoieVGlTJPgmqSyhQDVRh;
			axisValues[1] = HTARqehkuJxbCzZyyrvZmzPjruPk;
			axisValues[2] = ZUrctrAdWRXeXofyuezaBJKcCBtTb;
			axisValues[3] = fRwgPEdbPphSVGUqHXUvXuplZClGc;
			bool[] buttonValues = P_0.buttonValues;
			for (int i = 0; i < 5; i++)
			{
				buttonValues[i] = pftenWEvElEbtPWDcIbkRAheEuPT[i] || RWpcZohWhIupboCdYKYTRxJFugfpA[i];
			}
			OyIfRlIVncelzCWZbcVpnJiSkEZCc();
		}

		public void qXErmneLHowViBAhMXpDJHhRpEhO()
		{
			OyIfRlIVncelzCWZbcVpnJiSkEZCc();
		}

		private void OyIfRlIVncelzCWZbcVpnJiSkEZCc()
		{
			if (pZwgykovCsFRdakNvHvrCftXSLLGA != ReInput.absFrame)
			{
				EtdvfXEKLNzxkdLocFqgFMaXMtSh();
				pZwgykovCsFRdakNvHvrCftXSLLGA = ReInput.absFrame;
			}
		}

		public void JbghqMrognnltUudQanCZOHOGHYK()
		{
			icUDKVaBoieVGlTJPgmqSyhQDVRh = 0f;
			HTARqehkuJxbCzZyyrvZmzPjruPk = 0f;
			lmhZjIJTcEXNmxQhEVJbaKFFfKJf = 0u;
			dLKmJMjvTxBgWqVXEbrJNLHjfhrkA = JpWdbQEjoVtlDeVjQQcixjhQPKJkA.MoveRelative;
			ZUrctrAdWRXeXofyuezaBJKcCBtTb = 0f;
			fRwgPEdbPphSVGUqHXUvXuplZClGc = 0f;
			Array.Clear(pftenWEvElEbtPWDcIbkRAheEuPT, 0, 5);
			Array.Clear(RWpcZohWhIupboCdYKYTRxJFugfpA, 0, 5);
			pFOkfDIHNhgseGawXHUTmsJonWNVA = false;
		}

		public void EtdvfXEKLNzxkdLocFqgFMaXMtSh()
		{
			icUDKVaBoieVGlTJPgmqSyhQDVRh = 0f;
			HTARqehkuJxbCzZyyrvZmzPjruPk = 0f;
			ZUrctrAdWRXeXofyuezaBJKcCBtTb = 0f;
			fRwgPEdbPphSVGUqHXUvXuplZClGc = 0f;
			Array.Clear(RWpcZohWhIupboCdYKYTRxJFugfpA, 0, 5);
		}

		private void wMpCXmfxJnVjKSJADugHbsmSFjwJA(int P_0, int P_1, int P_2, int P_3)
		{
			zcMZhNigpZIivZpSgbwrkKRHVNle zcMZhNigpZIivZpSgbwrkKRHVNle2 = amwHBESNaxNCdkeWCQFXbPUoTxAh(P_1, P_2, P_3);
			if (pftenWEvElEbtPWDcIbkRAheEuPT[P_0])
			{
				if (zcMZhNigpZIivZpSgbwrkKRHVNle2 == zcMZhNigpZIivZpSgbwrkKRHVNle.Up || zcMZhNigpZIivZpSgbwrkKRHVNle2 == zcMZhNigpZIivZpSgbwrkKRHVNle.DownAndUp)
				{
					pftenWEvElEbtPWDcIbkRAheEuPT[P_0] = false;
				}
			}
			else if (zcMZhNigpZIivZpSgbwrkKRHVNle2 == zcMZhNigpZIivZpSgbwrkKRHVNle.Down)
			{
				pftenWEvElEbtPWDcIbkRAheEuPT[P_0] = true;
			}
			if (zcMZhNigpZIivZpSgbwrkKRHVNle2 == zcMZhNigpZIivZpSgbwrkKRHVNle.Down || zcMZhNigpZIivZpSgbwrkKRHVNle2 == zcMZhNigpZIivZpSgbwrkKRHVNle.DownAndUp)
			{
				RWpcZohWhIupboCdYKYTRxJFugfpA[P_0] = true;
			}
		}

		private static zcMZhNigpZIivZpSgbwrkKRHVNle amwHBESNaxNCdkeWCQFXbPUoTxAh(int P_0, int P_1, int P_2)
		{
			if ((P_0 & P_1) == P_1)
			{
				if ((P_0 & P_2) == P_2)
				{
					return zcMZhNigpZIivZpSgbwrkKRHVNle.DownAndUp;
				}
				return zcMZhNigpZIivZpSgbwrkKRHVNle.Down;
			}
			if ((P_0 & P_2) == P_2)
			{
				return zcMZhNigpZIivZpSgbwrkKRHVNle.Up;
			}
			return zcMZhNigpZIivZpSgbwrkKRHVNle.None;
		}

		private static bool siclGXfsuKjVRXOSGiwkkwZVjwaE(IntPtr P_0)
		{
			if (AmOfVgHMXtIpYGmFoUHcniSRkMulA.KKSFocsfIoPvSaRHKGrwlbmFENYj(0u, false, 0u) == IntPtr.Zero)
			{
				return false;
			}
			if (!AmOfVgHMXtIpYGmFoUHcniSRkMulA.vwEDsUQbkXqVOdEPDIjlcpwgxlbuA(P_0, out var aegcjjfGhQrJpMPvSdGYpolmEKHG2))
			{
				return false;
			}
			if (!AmOfVgHMXtIpYGmFoUHcniSRkMulA.xMzgaiupqzemUKoGmSkdLLOmdeyE(out var aegcjjfGhQrJpMPvSdGYpolmEKHG3))
			{
				return false;
			}
			if (!AmOfVgHMXtIpYGmFoUHcniSRkMulA.qPiUHIhhniaKjiHuVAVdQdLVBWJfA(P_0, out var bpvkjeXazKdJWfMibCYdUmSMzgsPA2))
			{
				return false;
			}
			int num = aegcjjfGhQrJpMPvSdGYpolmEKHG3.hVCHwRqoQgyZEjMScnlFufuQAfKi - aegcjjfGhQrJpMPvSdGYpolmEKHG2.hVCHwRqoQgyZEjMScnlFufuQAfKi;
			int num2 = aegcjjfGhQrJpMPvSdGYpolmEKHG3.AkIGGwHsOGpiUQihQGotjYOYFqWbb - aegcjjfGhQrJpMPvSdGYpolmEKHG2.AkIGGwHsOGpiUQihQGotjYOYFqWbb;
			if (num >= 0 && num2 >= 0 && num <= bpvkjeXazKdJWfMibCYdUmSMzgsPA2.BWwDRGYSelDEMGOoBOiYScoSXOvR && num2 <= bpvkjeXazKdJWfMibCYdUmSMzgsPA2.YuErQEGBUjrsDEbLxPgGAVClxVpW)
			{
				return false;
			}
			if (!AmOfVgHMXtIpYGmFoUHcniSRkMulA.SMQgDrgoxUhIpAHjwlfmurrcRMrRA(P_0, out var bpvkjeXazKdJWfMibCYdUmSMzgsPA3))
			{
				return false;
			}
			if (aegcjjfGhQrJpMPvSdGYpolmEKHG3.hVCHwRqoQgyZEjMScnlFufuQAfKi >= bpvkjeXazKdJWfMibCYdUmSMzgsPA3.kODbKYcnlWZkOTHwmCeBwxqctmcTA && aegcjjfGhQrJpMPvSdGYpolmEKHG3.hVCHwRqoQgyZEjMScnlFufuQAfKi <= bpvkjeXazKdJWfMibCYdUmSMzgsPA3.BWwDRGYSelDEMGOoBOiYScoSXOvR && aegcjjfGhQrJpMPvSdGYpolmEKHG3.AkIGGwHsOGpiUQihQGotjYOYFqWbb >= bpvkjeXazKdJWfMibCYdUmSMzgsPA3.mcwjGseVpUAPpawUJOxHfVQbAzFVA)
			{
				return aegcjjfGhQrJpMPvSdGYpolmEKHG3.AkIGGwHsOGpiUQihQGotjYOYFqWbb <= bpvkjeXazKdJWfMibCYdUmSMzgsPA3.YuErQEGBUjrsDEbLxPgGAVClxVpW;
			}
			return false;
		}
	}

	private class dFDCbwiBZipHRyrkjzXONBtvgufi
	{
		private bool PClDVGciYUIZMBctLFhrwHfZFoRlA;

		private bool JZcdzQABkSPVfsAinkBicbNrEpqq;

		private bool dAdLoNOsnhdRRavycPDMMxZldXyq;

		private int KsyvTlUUezLYoEWciEeMYxKSnTAJ = 10;

		private readonly float jZTYiiOIjZoXVgiusclcDtKOuLnc;

		private double LNDwvqQWYELwAKDWivNyrQOQhQvQ;

		public bool mqazZFNmbPbXSlrrwoHLlhrnCrAe
		{
			get
			{
				return PClDVGciYUIZMBctLFhrwHfZFoRlA;
			}
			set
			{
				if (flag != PClDVGciYUIZMBctLFhrwHfZFoRlA)
				{
					PDNawfqtepINFSGTvJsPTWjIviXw(true);
				}
			}
		}

		public bool tcDbCjLBauFTswezXJmWioTPmxaq => JZcdzQABkSPVfsAinkBicbNrEpqq;

		public bool zPrvDdouhpiKpWrfIcJffpkxszYP
		{
			get
			{
				return dAdLoNOsnhdRRavycPDMMxZldXyq;
			}
			set
			{
				if (dAdLoNOsnhdRRavycPDMMxZldXyq != flag)
				{
					dAdLoNOsnhdRRavycPDMMxZldXyq = flag;
					PDNawfqtepINFSGTvJsPTWjIviXw(true);
				}
			}
		}

		public int IBIHFkpDbtSnEpJyCZQzYVMMKoeh => KsyvTlUUezLYoEWciEeMYxKSnTAJ;

		public dFDCbwiBZipHRyrkjzXONBtvgufi(bool P_0, float P_1)
		{
			PClDVGciYUIZMBctLFhrwHfZFoRlA = P_0;
			jZTYiiOIjZoXVgiusclcDtKOuLnc = P_1;
			PDNawfqtepINFSGTvJsPTWjIviXw(false);
		}

		public void bqcQpEnLhufDoRbxKjMJcnhfpTjA()
		{
			if (PClDVGciYUIZMBctLFhrwHfZFoRlA && !(ReInput.realTime < LNDwvqQWYELwAKDWivNyrQOQhQvQ))
			{
				PDNawfqtepINFSGTvJsPTWjIviXw(true);
			}
		}

		private void PDNawfqtepINFSGTvJsPTWjIviXw(bool P_0)
		{
			if (dAdLoNOsnhdRRavycPDMMxZldXyq)
			{
				AmOfVgHMXtIpYGmFoUHcniSRkMulA.ZOkGWgDVPIeoemztbDJgjBJkkJOEA(112u, 0u, ref KsyvTlUUezLYoEWciEeMYxKSnTAJ, 0u);
			}
			JZcdzQABkSPVfsAinkBicbNrEpqq = AmOfVgHMXtIpYGmFoUHcniSRkMulA.qaNIikZIdIndIbOvcNEKVLUfFRhIA(eWeEhNdWXFKKoUYVUXekPSNqerKDA.qgarUeILctcsBKbmbBJfAaSaccyfB) > 0;
			if (P_0)
			{
				LNDwvqQWYELwAKDWivNyrQOQhQvQ = ReInput.realTime + (double)jZTYiiOIjZoXVgiusclcDtKOuLnc;
			}
		}
	}

	private const int KGuyskTmlixwARQIihfgJjzyPNUu = 5;

	private const int ImClvXZGWaVBmTamRSUEcfCTpTkl = 4;

	private readonly SpinLock fsEXjbCJYsBrOFpXiCpepMgfXUMmA = new SpinLock();

	private UpdateLoopDataSet<cwaUKJNgrzsixzqWYGPxETIoIImfA> FhOEQNLXzCPtpDmMUEJYczuIeQdy;

	private HardwareControllerMap_Game XEaqEwxcueoMmyvABReheRkGrsdE;

	private dFDCbwiBZipHRyrkjzXONBtvgufi eeqlcHSAVWCFERNgXwkYwyajGeHR;

	private bool zryjDCDmNHheMEoPrxYARnXMPklPA;

	private int EAEWrTwMUKFvENGjnIyxohoMPItM;

	private bool DXGDmTDHHeijEbJhIelgIDEheKQk;

	private const bool kLHJpcljPKGpaEKxmbaHbEdqNYXZA = true;

	private const float zRQhcHdbeTEFWasTXmsKaeXNQovcA = 2f;

	private bool vGdIlXzffiifXmPIWGeFRNdKodmk;

	bool IGetSetEnabled.enabled
	{
		get
		{
			return DXGDmTDHHeijEbJhIelgIDEheKQk;
		}
		set
		{
			if (DXGDmTDHHeijEbJhIelgIDEheKQk != value)
			{
				DXGDmTDHHeijEbJhIelgIDEheKQk = value;
				Clear();
				ThreadSafeUnityInput.mouse.Monitor(value);
			}
		}
	}

	InputSource IUnifiedMouseSource.inputSource => InputSource.RawInput;

	HardwareControllerMap_Game IUnifiedMouseSource.hardwareMap
	{
		get
		{
			if (XEaqEwxcueoMmyvABReheRkGrsdE == null)
			{
				XEaqEwxcueoMmyvABReheRkGrsdE = zTUenxDEgZlZCESdRAiQfjvfEDDjc();
			}
			return XEaqEwxcueoMmyvABReheRkGrsdE;
		}
	}

	int IUnifiedMouseSource.buttonCount => 5;

	int IUnifiedMouseSource.axisCount => 4;

	Vector2 IUnifiedMouseSource.mousePosition
	{
		get
		{
			if (!DXGDmTDHHeijEbJhIelgIDEheKQk)
			{
				return default(Vector2);
			}
			return ThreadSafeUnityInput.mouse.mousePosition;
		}
	}

	Controller.Extension IUnifiedMouseSource.controllerExtension => null;

	public fsCGaOEpsRBSmcVjAqpMyeMmPWhRA(UpdateLoopSetting P_0)
	{
		IuCNBkZkfBGsoEhNSktreLNVGLeH();
		eeqlcHSAVWCFERNgXwkYwyajGeHR = new dFDCbwiBZipHRyrkjzXONBtvgufi(true, 2f);
		FhOEQNLXzCPtpDmMUEJYczuIeQdy = new UpdateLoopDataSet<cwaUKJNgrzsixzqWYGPxETIoIImfA>(P_0);
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				FhOEQNLXzCPtpDmMUEJYczuIeQdy[i] = new cwaUKJNgrzsixzqWYGPxETIoIImfA(eeqlcHSAVWCFERNgXwkYwyajGeHR, list[i]);
			}
		}
		zryjDCDmNHheMEoPrxYARnXMPklPA = ReInput.IsInputAllowed(ControllerType.Mouse);
		ReInput.ApplicationFocusChangedEvent += cAqkJZFCrfaiudBsgsbgtSwiykNoA;
		ReInput.ApplicationPauseChangedEvent += SWfqUJEMfjpNgqGgtlNjkLThBJjiA;
		Rewired_002EInterfaces_002EIGetSetEnabled_002Eenabled = true;
		ReInput.EditorPauseChangedEvent += xIqgQejZFllfqHUtqjvjszhqBoIBb;
		ReInput.TimeScalePauseChangedEvent += JvyjcqJQtxOGHeZvjbONjrnFwMTg;
		ReInput.UpdateEndedEvent += GeNFCXCkKSNjObSogMCGlzbNWHfEb;
	}

	public void biEhSJFaMvujHmTYEFoLsRjmXQFE(UpdateLoopType P_0)
	{
		FhOEQNLXzCPtpDmMUEJYczuIeQdy.SetUpdateLoop(P_0);
		eeqlcHSAVWCFERNgXwkYwyajGeHR.bqcQpEnLhufDoRbxKjMJcnhfpTjA();
		zryjDCDmNHheMEoPrxYARnXMPklPA = ReInput.IsInputAllowed(ControllerType.Mouse);
	}

	public void BXfxyzXaqaNkejJjiidNtIynqViK(JuQILPLnTzaUqPRUPoBEwsmAnFzt P_0)
	{
		if (!zryjDCDmNHheMEoPrxYARnXMPklPA)
		{
			return;
		}
		using (fsEXjbCJYsBrOFpXiCpepMgfXUMmA.Lock())
		{
			int count = FhOEQNLXzCPtpDmMUEJYczuIeQdy.Count;
			for (int i = 0; i < count; i++)
			{
				FhOEQNLXzCPtpDmMUEJYczuIeQdy[i].ThuEYSagIxggonBCQNfLuZYZQIraA(P_0);
			}
		}
	}

	public void nLcpshATdTCQoDOKCaMCfhEekLDtA(bool P_0)
	{
		sqELOQEhWaETGkHPCLfHaYBMgqeFb();
	}

	public void nsfoMBOPpBZpWgbEqHOIvOEoryni(bool P_0)
	{
		if (IuCNBkZkfBGsoEhNSktreLNVGLeH() < 0)
		{
			sqELOQEhWaETGkHPCLfHaYBMgqeFb();
		}
	}

	private int IuCNBkZkfBGsoEhNSktreLNVGLeH()
	{
		int eAEWrTwMUKFvENGjnIyxohoMPItM = EAEWrTwMUKFvENGjnIyxohoMPItM;
		if (CAMKjWWITLmVKNQaIYUpYBAnWcXD.vuAZHbZIAJZwCKAMyAtnNbsadYDgA(mPOQOSVPBoHEVSsvmRnefPJMUbqp.Mouse, out var eAEWrTwMUKFvENGjnIyxohoMPItM2))
		{
			EAEWrTwMUKFvENGjnIyxohoMPItM = eAEWrTwMUKFvENGjnIyxohoMPItM2;
		}
		else
		{
			EAEWrTwMUKFvENGjnIyxohoMPItM = ((AmOfVgHMXtIpYGmFoUHcniSRkMulA.qaNIikZIdIndIbOvcNEKVLUfFRhIA(eWeEhNdWXFKKoUYVUXekPSNqerKDA.xGjbtKrmPxgMhLIfDCSNmpLXMMMb) != 0) ? 1 : 0);
		}
		return EAEWrTwMUKFvENGjnIyxohoMPItM - eAEWrTwMUKFvENGjnIyxohoMPItM;
	}

	private void cAqkJZFCrfaiudBsgsbgtSwiykNoA(bool P_0)
	{
		zryjDCDmNHheMEoPrxYARnXMPklPA = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!P_0 && !zryjDCDmNHheMEoPrxYARnXMPklPA)
		{
			sqELOQEhWaETGkHPCLfHaYBMgqeFb();
		}
	}

	private void SWfqUJEMfjpNgqGgtlNjkLThBJjiA(bool P_0)
	{
		zryjDCDmNHheMEoPrxYARnXMPklPA = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!zryjDCDmNHheMEoPrxYARnXMPklPA)
		{
			sqELOQEhWaETGkHPCLfHaYBMgqeFb();
		}
	}

	private void xIqgQejZFllfqHUtqjvjszhqBoIBb(bool P_0)
	{
	}

	private void JvyjcqJQtxOGHeZvjbONjrnFwMTg(bool P_0)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == 0)
		{
			return;
		}
		zryjDCDmNHheMEoPrxYARnXMPklPA = ReInput.IsInputAllowed(ControllerType.Mouse);
		using (fsEXjbCJYsBrOFpXiCpepMgfXUMmA.Lock())
		{
			FhOEQNLXzCPtpDmMUEJYczuIeQdy[FhOEQNLXzCPtpDmMUEJYczuIeQdy.fixedUpdateSetIndex].EtdvfXEKLNzxkdLocFqgFMaXMtSh();
		}
	}

	private void GeNFCXCkKSNjObSogMCGlzbNWHfEb(UpdateLoopType P_0)
	{
		using (fsEXjbCJYsBrOFpXiCpepMgfXUMmA.Lock())
		{
			FhOEQNLXzCPtpDmMUEJYczuIeQdy.Get(P_0).qXErmneLHowViBAhMXpDJHhRpEhO();
		}
	}

	private void sqELOQEhWaETGkHPCLfHaYBMgqeFb()
	{
		using (fsEXjbCJYsBrOFpXiCpepMgfXUMmA.Lock())
		{
			int count = FhOEQNLXzCPtpDmMUEJYczuIeQdy.Count;
			for (int i = 0; i < count; i++)
			{
				FhOEQNLXzCPtpDmMUEJYczuIeQdy[i].JbghqMrognnltUudQanCZOHOGHYK();
			}
		}
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		FhOEQNLXzCPtpDmMUEJYczuIeQdy.Current.WgzkwmMLXzmLvECiwsIFiRzJJARw(dataUpdater);
	}

	void IUnifiedMouseSource.UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateInputData
		this.UpdateInputData(dataUpdater);
	}

	public void Clear()
	{
		sqELOQEhWaETGkHPCLfHaYBMgqeFb();
	}

	void IUnifiedMouseSource.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clear
		this.Clear();
	}

	private HardwareControllerMap_Game zTUenxDEgZlZCESdRAiQfjvfEDDjc()
	{
		ControllerElementIdentifier[] array = new ControllerElementIdentifier[Consts.rawInputUnifiedMouseElementIdentifiers.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new ControllerElementIdentifier(Consts.rawInputUnifiedMouseElementIdentifiers[i]);
		}
		int[] array2 = new int[5];
		int[] array3 = new int[4];
		int num = 0;
		int num2 = 0;
		for (int j = 0; j < array.Length; j++)
		{
			if (array[j].elementType == ControllerElementType.Axis)
			{
				array3[num2++] = array[j].id;
			}
			else if (array[j].elementType == ControllerElementType.Button)
			{
				array2[num++] = array[j].id;
			}
		}
		AxisCalibrationData[] array4 = new AxisCalibrationData[4];
		AxisRange[] array5 = new AxisRange[4];
		HardwareAxisInfo[] array6 = new HardwareAxisInfo[4];
		HardwareButtonInfo[] array7 = new HardwareButtonInfo[5];
		for (int k = 0; k < 4; k++)
		{
			array4[k] = AxisCalibrationData.Raw;
			array5[k] = AxisRange.Full;
			float num3 = (((uint)k > 1u) ? 2f : 100f);
			array6[k] = new HardwareAxisInfo(AxisCoordinateMode.Relative, false, num3, SpecialAxisType.None);
		}
		for (int l = 0; l < 5; l++)
		{
			array7[l] = new HardwareButtonInfo();
		}
		HardwareJoystickMap.CompoundElement[] array8 = new HardwareJoystickMap.CompoundElement[Consts.unifiedMouseCompoundElements_readOnly.Count];
		for (int m = 0; m < Consts.unifiedMouseCompoundElements_readOnly.Count; m++)
		{
			array8[m] = new HardwareJoystickMap.CompoundElement(Consts.unifiedMouseCompoundElements_readOnly[m]);
		}
		return new HardwareControllerMap_Game("Mouse", default(HardwareControllerMapIdentifier), array, array2, array3, array4, array5, array6, array7, array8);
	}

	public void Dispose()
	{
		QNoURANokrxsWidnzEPGCYJxBboY(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void QrNKFNaFNVDWfDkLFKsqWbCnHnEL()
	{
		try
		{
			QNoURANokrxsWidnzEPGCYJxBboY(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void QNoURANokrxsWidnzEPGCYJxBboY(bool P_0)
	{
		if (!vGdIlXzffiifXmPIWGeFRNdKodmk)
		{
			ReInput.ApplicationFocusChangedEvent -= cAqkJZFCrfaiudBsgsbgtSwiykNoA;
			ReInput.ApplicationPauseChangedEvent -= SWfqUJEMfjpNgqGgtlNjkLThBJjiA;
			ReInput.EditorPauseChangedEvent -= xIqgQejZFllfqHUtqjvjszhqBoIBb;
			ReInput.TimeScalePauseChangedEvent -= JvyjcqJQtxOGHeZvjbONjrnFwMTg;
			ReInput.UpdateEndedEvent -= GeNFCXCkKSNjObSogMCGlzbNWHfEb;
			if (P_0 && DXGDmTDHHeijEbJhIelgIDEheKQk)
			{
				ThreadSafeUnityInput.mouse.Monitor(state: false);
			}
			vGdIlXzffiifXmPIWGeFRNdKodmk = true;
		}
	}
}
