using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Internal.Localization;
using Rewired.Utils;
using Rewired.Utils.Classes;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public sealed class Player : BMeYXymsuXMDMyjfaaClzmryYLZG
	{
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ControllerHelper
		{
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class WhCPDvpSEUSZxMsoXTNcGvIvgXCo : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int fpfUXAoZcUFNDROSxPENibcjuEqA;

					private ElementAssignmentConflictInfo CYTXUpmNZXCmjAEKvnHjhjFgePwqb;

					private int PXYTSAfGVDxlYSGVjxSCgvbIdlWc;

					private int biZvcekMLKgzIdjpSIrNiITgHEbyA;

					public int mQjaTAutvweDlIncJXJFbFiUsMqjA;

					private CustomControllerMap dTcqcXWChsoeuOEpWMgGiJipxCpy;

					public CustomControllerMap RURrlCltMetytVPzWokVttnzSlXu;

					public ConflictCheckingHelper iULRcIAPISarKCTPMrCprRUXMungA;

					private bool NjskZurNofEQXGEEmkdCAwqtHzRe;

					public bool tYmWFmnvoLVLFYouosobqhdnadIEA;

					private bool HvWAhfyjpLNmjZgwCNbeivsdelxo;

					public bool ajetXPyspFLRirLCuhwKAZEJeMjS;

					private int GoJWdlHZRBwCDACFhRGKZDQaNUog;

					private IEnumerator<ElementAssignmentConflictInfo> CuFBImFqUWhYaaTdcaTKqMJCscwac;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return CYTXUpmNZXCmjAEKvnHjhjFgePwqb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return CYTXUpmNZXCmjAEKvnHjhjFgePwqb;
						}
					}

					[DebuggerHidden]
					public WhCPDvpSEUSZxMsoXTNcGvIvgXCo(int P_0)
					{
						fpfUXAoZcUFNDROSxPENibcjuEqA = P_0;
						PXYTSAfGVDxlYSGVjxSCgvbIdlWc = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = fpfUXAoZcUFNDROSxPENibcjuEqA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								dvoeMHLVwvgWOVfZMrgEQNDBRFIJ();
							}
						}
						CuFBImFqUWhYaaTdcaTKqMJCscwac = null;
						fpfUXAoZcUFNDROSxPENibcjuEqA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = fpfUXAoZcUFNDROSxPENibcjuEqA;
							ConflictCheckingHelper conflictCheckingHelper = iULRcIAPISarKCTPMrCprRUXMungA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								fpfUXAoZcUFNDROSxPENibcjuEqA = -3;
								goto IL_00eb;
							}
							fpfUXAoZcUFNDROSxPENibcjuEqA = -1;
							if (biZvcekMLKgzIdjpSIrNiITgHEbyA < 0 || dTcqcXWChsoeuOEpWMgGiJipxCpy == null)
							{
								return false;
							}
							GoJWdlHZRBwCDACFhRGKZDQaNUog = 0;
							goto IL_0117;
							IL_00eb:
							if (CuFBImFqUWhYaaTdcaTKqMJCscwac.MoveNext())
							{
								ElementAssignmentConflictInfo current = CuFBImFqUWhYaaTdcaTKqMJCscwac.Current;
								CYTXUpmNZXCmjAEKvnHjhjFgePwqb = current;
								fpfUXAoZcUFNDROSxPENibcjuEqA = 1;
								return true;
							}
							dvoeMHLVwvgWOVfZMrgEQNDBRFIJ();
							CuFBImFqUWhYaaTdcaTKqMJCscwac = null;
							goto IL_0105;
							IL_0117:
							if (GoJWdlHZRBwCDACFhRGKZDQaNUog < conflictCheckingHelper.oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.tXrSkfcScZdadhIEmSRyjQoYKHYaA())
							{
								if (conflictCheckingHelper.oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(GoJWdlHZRBwCDACFhRGKZDQaNUog).jShzJcgXohXkJgAjbKdTzokqckTE.id == biZvcekMLKgzIdjpSIrNiITgHEbyA)
								{
									CuFBImFqUWhYaaTdcaTKqMJCscwac = conflictCheckingHelper.BkahyuxuzBdgwXAIEhEREhbdekGFb(ControllerType.Custom, biZvcekMLKgzIdjpSIrNiITgHEbyA, dTcqcXWChsoeuOEpWMgGiJipxCpy, NjskZurNofEQXGEEmkdCAwqtHzRe, HvWAhfyjpLNmjZgwCNbeivsdelxo, conflictCheckingHelper.oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(GoJWdlHZRBwCDACFhRGKZDQaNUog).oNEqVoyniAQxhPXQGcMENGIkPfMg).GetEnumerator();
									fpfUXAoZcUFNDROSxPENibcjuEqA = -3;
									goto IL_00eb;
								}
								goto IL_0105;
							}
							return false;
							IL_0105:
							GoJWdlHZRBwCDACFhRGKZDQaNUog++;
							goto IL_0117;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void dvoeMHLVwvgWOVfZMrgEQNDBRFIJ()
					{
						fpfUXAoZcUFNDROSxPENibcjuEqA = -1;
						if (CuFBImFqUWhYaaTdcaTKqMJCscwac != null)
						{
							CuFBImFqUWhYaaTdcaTKqMJCscwac.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						WhCPDvpSEUSZxMsoXTNcGvIvgXCo whCPDvpSEUSZxMsoXTNcGvIvgXCo;
						if (fpfUXAoZcUFNDROSxPENibcjuEqA == -2 && PXYTSAfGVDxlYSGVjxSCgvbIdlWc == Environment.CurrentManagedThreadId)
						{
							fpfUXAoZcUFNDROSxPENibcjuEqA = 0;
							whCPDvpSEUSZxMsoXTNcGvIvgXCo = this;
						}
						else
						{
							whCPDvpSEUSZxMsoXTNcGvIvgXCo = new WhCPDvpSEUSZxMsoXTNcGvIvgXCo(0);
							whCPDvpSEUSZxMsoXTNcGvIvgXCo.iULRcIAPISarKCTPMrCprRUXMungA = iULRcIAPISarKCTPMrCprRUXMungA;
						}
						whCPDvpSEUSZxMsoXTNcGvIvgXCo.biZvcekMLKgzIdjpSIrNiITgHEbyA = mQjaTAutvweDlIncJXJFbFiUsMqjA;
						whCPDvpSEUSZxMsoXTNcGvIvgXCo.dTcqcXWChsoeuOEpWMgGiJipxCpy = RURrlCltMetytVPzWokVttnzSlXu;
						whCPDvpSEUSZxMsoXTNcGvIvgXCo.NjskZurNofEQXGEEmkdCAwqtHzRe = tYmWFmnvoLVLFYouosobqhdnadIEA;
						whCPDvpSEUSZxMsoXTNcGvIvgXCo.HvWAhfyjpLNmjZgwCNbeivsdelxo = ajetXPyspFLRirLCuhwKAZEJeMjS;
						return whCPDvpSEUSZxMsoXTNcGvIvgXCo;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class KKvEkxrvksWGVoDTXHpQukozxZBG : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int NsepieMbPoltKCyoWpuIXdeySNSF;

					private ElementAssignmentConflictInfo AbVoYbMIWEgwKeisYSHNTByqwJXr;

					private int VzzLDGOfFqWYhulcXHrbwpbBbZTV;

					private int SZRpimbiIrfjEnefOyiWdhIPRwYh;

					public int LnXAFAJkNuqKdnCMnziPtqoJYcZJ;

					private ActionElementMap ZiqPRVnVlTyWqovjBnicujwkSNGI;

					public ActionElementMap yYBqPgKzKVUHyCwrVMpPYeRZwojP;

					public ConflictCheckingHelper PUjqImyeHWrpkhoKRjqkLBCNwkwl;

					private CustomControllerMap oUgLawoFvaEAhhyaShiloOSqZdfSA;

					public CustomControllerMap upkSjLGsKigQQuLUFGaVqqjSvcmW;

					private bool rIIimXpDNCVrMRKBaXFEzvnriDLF;

					public bool kglyAOlIpzEnCJqTNldwCmkEGjbLc;

					private bool AUGTRfHEvUEArnuJTpDuIgfiNHSi;

					public bool vAHosrHGfZvEIJzHnKDSREfYghJG;

					private int WuxClUDMAcqvzOktyDQEcYoXohYtA;

					private IEnumerator<ElementAssignmentConflictInfo> SJXvTAhHCZdHQVUMWfmEhdVqGIPtA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return AbVoYbMIWEgwKeisYSHNTByqwJXr;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return AbVoYbMIWEgwKeisYSHNTByqwJXr;
						}
					}

					[DebuggerHidden]
					public KKvEkxrvksWGVoDTXHpQukozxZBG(int P_0)
					{
						NsepieMbPoltKCyoWpuIXdeySNSF = P_0;
						VzzLDGOfFqWYhulcXHrbwpbBbZTV = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int nsepieMbPoltKCyoWpuIXdeySNSF = NsepieMbPoltKCyoWpuIXdeySNSF;
						if (nsepieMbPoltKCyoWpuIXdeySNSF == -3 || nsepieMbPoltKCyoWpuIXdeySNSF == 1)
						{
							try
							{
							}
							finally
							{
								ainayruEErqFwgppZvroXTIaEoiR();
							}
						}
						SJXvTAhHCZdHQVUMWfmEhdVqGIPtA = null;
						NsepieMbPoltKCyoWpuIXdeySNSF = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int nsepieMbPoltKCyoWpuIXdeySNSF = NsepieMbPoltKCyoWpuIXdeySNSF;
							ConflictCheckingHelper pUjqImyeHWrpkhoKRjqkLBCNwkwl = PUjqImyeHWrpkhoKRjqkLBCNwkwl;
							if (nsepieMbPoltKCyoWpuIXdeySNSF != 0)
							{
								if (nsepieMbPoltKCyoWpuIXdeySNSF != 1)
								{
									return false;
								}
								NsepieMbPoltKCyoWpuIXdeySNSF = -3;
								goto IL_00f1;
							}
							NsepieMbPoltKCyoWpuIXdeySNSF = -1;
							if (SZRpimbiIrfjEnefOyiWdhIPRwYh < 0 || ZiqPRVnVlTyWqovjBnicujwkSNGI == null)
							{
								return false;
							}
							WuxClUDMAcqvzOktyDQEcYoXohYtA = 0;
							goto IL_011d;
							IL_00f1:
							if (SJXvTAhHCZdHQVUMWfmEhdVqGIPtA.MoveNext())
							{
								ElementAssignmentConflictInfo current = SJXvTAhHCZdHQVUMWfmEhdVqGIPtA.Current;
								AbVoYbMIWEgwKeisYSHNTByqwJXr = current;
								NsepieMbPoltKCyoWpuIXdeySNSF = 1;
								return true;
							}
							ainayruEErqFwgppZvroXTIaEoiR();
							SJXvTAhHCZdHQVUMWfmEhdVqGIPtA = null;
							goto IL_010b;
							IL_011d:
							if (WuxClUDMAcqvzOktyDQEcYoXohYtA < pUjqImyeHWrpkhoKRjqkLBCNwkwl.oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.tXrSkfcScZdadhIEmSRyjQoYKHYaA())
							{
								if (pUjqImyeHWrpkhoKRjqkLBCNwkwl.oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(WuxClUDMAcqvzOktyDQEcYoXohYtA).jShzJcgXohXkJgAjbKdTzokqckTE.id == SZRpimbiIrfjEnefOyiWdhIPRwYh)
								{
									SJXvTAhHCZdHQVUMWfmEhdVqGIPtA = pUjqImyeHWrpkhoKRjqkLBCNwkwl.brzWRkOKAySfYuGWMdVCrDFfbTIEA(ControllerType.Custom, SZRpimbiIrfjEnefOyiWdhIPRwYh, oUgLawoFvaEAhhyaShiloOSqZdfSA, ZiqPRVnVlTyWqovjBnicujwkSNGI, rIIimXpDNCVrMRKBaXFEzvnriDLF, AUGTRfHEvUEArnuJTpDuIgfiNHSi, pUjqImyeHWrpkhoKRjqkLBCNwkwl.oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(WuxClUDMAcqvzOktyDQEcYoXohYtA).oNEqVoyniAQxhPXQGcMENGIkPfMg).GetEnumerator();
									NsepieMbPoltKCyoWpuIXdeySNSF = -3;
									goto IL_00f1;
								}
								goto IL_010b;
							}
							return false;
							IL_010b:
							WuxClUDMAcqvzOktyDQEcYoXohYtA++;
							goto IL_011d;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void ainayruEErqFwgppZvroXTIaEoiR()
					{
						NsepieMbPoltKCyoWpuIXdeySNSF = -1;
						if (SJXvTAhHCZdHQVUMWfmEhdVqGIPtA != null)
						{
							SJXvTAhHCZdHQVUMWfmEhdVqGIPtA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						KKvEkxrvksWGVoDTXHpQukozxZBG kKvEkxrvksWGVoDTXHpQukozxZBG;
						if (NsepieMbPoltKCyoWpuIXdeySNSF == -2 && VzzLDGOfFqWYhulcXHrbwpbBbZTV == Environment.CurrentManagedThreadId)
						{
							NsepieMbPoltKCyoWpuIXdeySNSF = 0;
							kKvEkxrvksWGVoDTXHpQukozxZBG = this;
						}
						else
						{
							kKvEkxrvksWGVoDTXHpQukozxZBG = new KKvEkxrvksWGVoDTXHpQukozxZBG(0);
							kKvEkxrvksWGVoDTXHpQukozxZBG.PUjqImyeHWrpkhoKRjqkLBCNwkwl = PUjqImyeHWrpkhoKRjqkLBCNwkwl;
						}
						kKvEkxrvksWGVoDTXHpQukozxZBG.SZRpimbiIrfjEnefOyiWdhIPRwYh = LnXAFAJkNuqKdnCMnziPtqoJYcZJ;
						kKvEkxrvksWGVoDTXHpQukozxZBG.oUgLawoFvaEAhhyaShiloOSqZdfSA = upkSjLGsKigQQuLUFGaVqqjSvcmW;
						kKvEkxrvksWGVoDTXHpQukozxZBG.ZiqPRVnVlTyWqovjBnicujwkSNGI = yYBqPgKzKVUHyCwrVMpPYeRZwojP;
						kKvEkxrvksWGVoDTXHpQukozxZBG.rIIimXpDNCVrMRKBaXFEzvnriDLF = kglyAOlIpzEnCJqTNldwCmkEGjbLc;
						kKvEkxrvksWGVoDTXHpQukozxZBG.AUGTRfHEvUEArnuJTpDuIgfiNHSi = vAHosrHGfZvEIJzHnKDSREfYghJG;
						return kKvEkxrvksWGVoDTXHpQukozxZBG;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class UQItgdhtIihsnOLIbokwMlOYgPdp : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int lIDoVBiznKsDEXOgDhBqGcsAcIOv;

					private ElementAssignmentConflictInfo SFBbHBLPDYvwHRrTmpgtiUAgJKnM;

					private int UsbKIqoZOndZOZobphRxeBuRuFGd;

					private ElementAssignmentConflictCheck btJkhFHYRxripOlkiwKyKbumfnBL;

					public ElementAssignmentConflictCheck fmPiwdQAHNgSKHmzZMpqcnshLOBxA;

					public ConflictCheckingHelper GqRJIWeeLVBPwJkpkRXZAmzlFRBAA;

					private bool MmbooOwSZWDjMtpShAjyXDPvEAEk;

					public bool zjfGaFERpAHeQuNIeLuqoaMOBxHKA;

					private bool vWFITMoGggKqANbySHwaudTlbdmV;

					public bool cjlPOQlTgzmNHUgacsDocgIVbjvn;

					private int tOYDikZjqBcaUbJGQBdYdhjaJlxvB;

					private IEnumerator<ElementAssignmentConflictInfo> xkDtSvsCvLGMUrsjaDzAeFxnqtxAb;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return SFBbHBLPDYvwHRrTmpgtiUAgJKnM;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return SFBbHBLPDYvwHRrTmpgtiUAgJKnM;
						}
					}

					[DebuggerHidden]
					public UQItgdhtIihsnOLIbokwMlOYgPdp(int P_0)
					{
						lIDoVBiznKsDEXOgDhBqGcsAcIOv = P_0;
						UsbKIqoZOndZOZobphRxeBuRuFGd = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = lIDoVBiznKsDEXOgDhBqGcsAcIOv;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								djbYAXQaBdioIdbspFBsaXYWaQPgb();
							}
						}
						xkDtSvsCvLGMUrsjaDzAeFxnqtxAb = null;
						lIDoVBiznKsDEXOgDhBqGcsAcIOv = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = lIDoVBiznKsDEXOgDhBqGcsAcIOv;
							ConflictCheckingHelper gqRJIWeeLVBPwJkpkRXZAmzlFRBAA = GqRJIWeeLVBPwJkpkRXZAmzlFRBAA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								lIDoVBiznKsDEXOgDhBqGcsAcIOv = -3;
								goto IL_00f3;
							}
							lIDoVBiznKsDEXOgDhBqGcsAcIOv = -1;
							if (btJkhFHYRxripOlkiwKyKbumfnBL.controllerId < 0 || btJkhFHYRxripOlkiwKyKbumfnBL.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							tOYDikZjqBcaUbJGQBdYdhjaJlxvB = 0;
							goto IL_011f;
							IL_00f3:
							if (xkDtSvsCvLGMUrsjaDzAeFxnqtxAb.MoveNext())
							{
								ElementAssignmentConflictInfo current = xkDtSvsCvLGMUrsjaDzAeFxnqtxAb.Current;
								SFBbHBLPDYvwHRrTmpgtiUAgJKnM = current;
								lIDoVBiznKsDEXOgDhBqGcsAcIOv = 1;
								return true;
							}
							djbYAXQaBdioIdbspFBsaXYWaQPgb();
							xkDtSvsCvLGMUrsjaDzAeFxnqtxAb = null;
							goto IL_010d;
							IL_011f:
							if (tOYDikZjqBcaUbJGQBdYdhjaJlxvB < gqRJIWeeLVBPwJkpkRXZAmzlFRBAA.oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.tXrSkfcScZdadhIEmSRyjQoYKHYaA())
							{
								if (gqRJIWeeLVBPwJkpkRXZAmzlFRBAA.oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(tOYDikZjqBcaUbJGQBdYdhjaJlxvB).jShzJcgXohXkJgAjbKdTzokqckTE.id == btJkhFHYRxripOlkiwKyKbumfnBL.controllerId)
								{
									xkDtSvsCvLGMUrsjaDzAeFxnqtxAb = gqRJIWeeLVBPwJkpkRXZAmzlFRBAA.EkHrwdNDPDFbHHONPuXdOmuqkCgqA(btJkhFHYRxripOlkiwKyKbumfnBL, MmbooOwSZWDjMtpShAjyXDPvEAEk, vWFITMoGggKqANbySHwaudTlbdmV, gqRJIWeeLVBPwJkpkRXZAmzlFRBAA.oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(tOYDikZjqBcaUbJGQBdYdhjaJlxvB).oNEqVoyniAQxhPXQGcMENGIkPfMg).GetEnumerator();
									lIDoVBiznKsDEXOgDhBqGcsAcIOv = -3;
									goto IL_00f3;
								}
								goto IL_010d;
							}
							return false;
							IL_010d:
							tOYDikZjqBcaUbJGQBdYdhjaJlxvB++;
							goto IL_011f;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void djbYAXQaBdioIdbspFBsaXYWaQPgb()
					{
						lIDoVBiznKsDEXOgDhBqGcsAcIOv = -1;
						if (xkDtSvsCvLGMUrsjaDzAeFxnqtxAb != null)
						{
							xkDtSvsCvLGMUrsjaDzAeFxnqtxAb.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						UQItgdhtIihsnOLIbokwMlOYgPdp uQItgdhtIihsnOLIbokwMlOYgPdp;
						if (lIDoVBiznKsDEXOgDhBqGcsAcIOv == -2 && UsbKIqoZOndZOZobphRxeBuRuFGd == Environment.CurrentManagedThreadId)
						{
							lIDoVBiznKsDEXOgDhBqGcsAcIOv = 0;
							uQItgdhtIihsnOLIbokwMlOYgPdp = this;
						}
						else
						{
							uQItgdhtIihsnOLIbokwMlOYgPdp = new UQItgdhtIihsnOLIbokwMlOYgPdp(0);
							uQItgdhtIihsnOLIbokwMlOYgPdp.GqRJIWeeLVBPwJkpkRXZAmzlFRBAA = GqRJIWeeLVBPwJkpkRXZAmzlFRBAA;
						}
						uQItgdhtIihsnOLIbokwMlOYgPdp.btJkhFHYRxripOlkiwKyKbumfnBL = fmPiwdQAHNgSKHmzZMpqcnshLOBxA;
						uQItgdhtIihsnOLIbokwMlOYgPdp.MmbooOwSZWDjMtpShAjyXDPvEAEk = zjfGaFERpAHeQuNIeLuqoaMOBxHKA;
						uQItgdhtIihsnOLIbokwMlOYgPdp.vWFITMoGggKqANbySHwaudTlbdmV = cjlPOQlTgzmNHUgacsDocgIVbjvn;
						return uQItgdhtIihsnOLIbokwMlOYgPdp;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class bHuCiUGmxLZzLKvUeadzsLWOJiuz<_0001> : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int GeehEmYGVdmXOqurvWHcdCXgqapK;

					private ElementAssignmentConflictInfo BfffIWdDulJKhaLbMUiqLCTHKwWr;

					private int toIBTmdcpwoBTCjMTefyywNfxkEUA;

					private global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0001> VcrZkfaasqjqAOLOZhZKfRrldrXl;

					public global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0001> qHSauAFuybkjbNYXyKYUuKQLGCicA;

					private _0001 opaKrwUCwFgUxAuzctGUBpFyWfWj;

					public _0001 NeeGUrWZDRPJueDkbOEzezvHcuZV;

					private bool EggiKmEoCbTAHJxwvBvkkBzzSRgh;

					public bool qbQdtPwyAGUpdbLkJTZcUdHjDnqM;

					private bool PDMilfaMtZSDcNuZVVTErIjojQuH;

					public bool zpPqJRqvbKVLzbXWxXdJwgYCPktf;

					public ConflictCheckingHelper TXtZqQOlfkvjuygmrRKTxYkfbIIk;

					private ControllerType qoMdCJjeJMfgkVNfImBwIkQcErXC;

					public ControllerType bMaoVfaGEhdcZKjsyRflqCesqtrw;

					private int HYJOKPZZbcPCJIWBKCWQDPNmsAOA;

					public int KnfjkVIFvDYYcbDkEAeGEqfUqDSab;

					private InputMapCategory PtYeSVIRbRVnORTtAYTKeUOiEThrA;

					private int vHZvWKJevhfrXRsdhhmQdfpOSAJEA;

					private IEnumerator<ElementAssignmentConflictInfo> IUVoNRkqNJIERItwrOIoaZufajHB;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return BfffIWdDulJKhaLbMUiqLCTHKwWr;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return BfffIWdDulJKhaLbMUiqLCTHKwWr;
						}
					}

					[DebuggerHidden]
					public bHuCiUGmxLZzLKvUeadzsLWOJiuz(int P_0)
					{
						GeehEmYGVdmXOqurvWHcdCXgqapK = P_0;
						toIBTmdcpwoBTCjMTefyywNfxkEUA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int geehEmYGVdmXOqurvWHcdCXgqapK = GeehEmYGVdmXOqurvWHcdCXgqapK;
						if (geehEmYGVdmXOqurvWHcdCXgqapK == -3 || geehEmYGVdmXOqurvWHcdCXgqapK == 1)
						{
							try
							{
							}
							finally
							{
								myMxVqBQgiwMzQcKcjRVhZccodrQA();
							}
						}
						PtYeSVIRbRVnORTtAYTKeUOiEThrA = null;
						IUVoNRkqNJIERItwrOIoaZufajHB = null;
						GeehEmYGVdmXOqurvWHcdCXgqapK = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int geehEmYGVdmXOqurvWHcdCXgqapK = GeehEmYGVdmXOqurvWHcdCXgqapK;
							ConflictCheckingHelper tXtZqQOlfkvjuygmrRKTxYkfbIIk = TXtZqQOlfkvjuygmrRKTxYkfbIIk;
							if (geehEmYGVdmXOqurvWHcdCXgqapK != 0)
							{
								if (geehEmYGVdmXOqurvWHcdCXgqapK != 1)
								{
									return false;
								}
								GeehEmYGVdmXOqurvWHcdCXgqapK = -3;
								goto IL_014a;
							}
							GeehEmYGVdmXOqurvWHcdCXgqapK = -1;
							if (VcrZkfaasqjqAOLOZhZKfRrldrXl == null || opaKrwUCwFgUxAuzctGUBpFyWfWj == null)
							{
								return false;
							}
							PtYeSVIRbRVnORTtAYTKeUOiEThrA = ReInput.mapping.GetMapCategory(opaKrwUCwFgUxAuzctGUBpFyWfWj.categoryId);
							if (PtYeSVIRbRVnORTtAYTKeUOiEThrA == null)
							{
								return false;
							}
							vHZvWKJevhfrXRsdhhmQdfpOSAJEA = 0;
							goto IL_0176;
							IL_0176:
							if (vHZvWKJevhfrXRsdhhmQdfpOSAJEA < VcrZkfaasqjqAOLOZhZKfRrldrXl.uwAUgkekzffIxggNtXkaazjLDUnI())
							{
								ControllerMap controllerMap = VcrZkfaasqjqAOLOZhZKfRrldrXl.dqSBzdtORLozVFHTanNDwzTffYco(vHZvWKJevhfrXRsdhhmQdfpOSAJEA);
								if ((!EggiKmEoCbTAHJxwvBvkkBzzSRgh || controllerMap.enabled) && (PDMilfaMtZSDcNuZVVTErIjojQuH || !tXtZqQOlfkvjuygmrRKTxYkfbIIk.juUtjedcddFaMqLKagzresIfWVxH(PtYeSVIRbRVnORTtAYTKeUOiEThrA, controllerMap)))
								{
									IUVoNRkqNJIERItwrOIoaZufajHB = controllerMap.ElementAssignmentConflicts(opaKrwUCwFgUxAuzctGUBpFyWfWj, EggiKmEoCbTAHJxwvBvkkBzzSRgh).GetEnumerator();
									GeehEmYGVdmXOqurvWHcdCXgqapK = -3;
									goto IL_014a;
								}
								goto IL_0164;
							}
							return false;
							IL_014a:
							if (IUVoNRkqNJIERItwrOIoaZufajHB.MoveNext())
							{
								ElementAssignmentConflictInfo current = IUVoNRkqNJIERItwrOIoaZufajHB.Current;
								ElementAssignmentConflictInfo bfffIWdDulJKhaLbMUiqLCTHKwWr = new ElementAssignmentConflictInfo(current);
								bfffIWdDulJKhaLbMUiqLCTHKwWr.playerId = tXtZqQOlfkvjuygmrRKTxYkfbIIk.JCkZmEAandhUIcbaUtyGDuIxqVBbb.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								bfffIWdDulJKhaLbMUiqLCTHKwWr.controllerType = qoMdCJjeJMfgkVNfImBwIkQcErXC;
								bfffIWdDulJKhaLbMUiqLCTHKwWr.controllerId = HYJOKPZZbcPCJIWBKCWQDPNmsAOA;
								BfffIWdDulJKhaLbMUiqLCTHKwWr = bfffIWdDulJKhaLbMUiqLCTHKwWr;
								GeehEmYGVdmXOqurvWHcdCXgqapK = 1;
								return true;
							}
							myMxVqBQgiwMzQcKcjRVhZccodrQA();
							IUVoNRkqNJIERItwrOIoaZufajHB = null;
							goto IL_0164;
							IL_0164:
							vHZvWKJevhfrXRsdhhmQdfpOSAJEA++;
							goto IL_0176;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void myMxVqBQgiwMzQcKcjRVhZccodrQA()
					{
						GeehEmYGVdmXOqurvWHcdCXgqapK = -1;
						if (IUVoNRkqNJIERItwrOIoaZufajHB != null)
						{
							IUVoNRkqNJIERItwrOIoaZufajHB.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						bHuCiUGmxLZzLKvUeadzsLWOJiuz<_0001> bHuCiUGmxLZzLKvUeadzsLWOJiuz2;
						if (GeehEmYGVdmXOqurvWHcdCXgqapK == -2 && toIBTmdcpwoBTCjMTefyywNfxkEUA == Environment.CurrentManagedThreadId)
						{
							GeehEmYGVdmXOqurvWHcdCXgqapK = 0;
							bHuCiUGmxLZzLKvUeadzsLWOJiuz2 = this;
						}
						else
						{
							bHuCiUGmxLZzLKvUeadzsLWOJiuz2 = new bHuCiUGmxLZzLKvUeadzsLWOJiuz<_0001>(0);
							bHuCiUGmxLZzLKvUeadzsLWOJiuz2.TXtZqQOlfkvjuygmrRKTxYkfbIIk = TXtZqQOlfkvjuygmrRKTxYkfbIIk;
						}
						bHuCiUGmxLZzLKvUeadzsLWOJiuz2.qoMdCJjeJMfgkVNfImBwIkQcErXC = bMaoVfaGEhdcZKjsyRflqCesqtrw;
						bHuCiUGmxLZzLKvUeadzsLWOJiuz2.HYJOKPZZbcPCJIWBKCWQDPNmsAOA = KnfjkVIFvDYYcbDkEAeGEqfUqDSab;
						bHuCiUGmxLZzLKvUeadzsLWOJiuz2.opaKrwUCwFgUxAuzctGUBpFyWfWj = NeeGUrWZDRPJueDkbOEzezvHcuZV;
						bHuCiUGmxLZzLKvUeadzsLWOJiuz2.EggiKmEoCbTAHJxwvBvkkBzzSRgh = qbQdtPwyAGUpdbLkJTZcUdHjDnqM;
						bHuCiUGmxLZzLKvUeadzsLWOJiuz2.PDMilfaMtZSDcNuZVVTErIjojQuH = zpPqJRqvbKVLzbXWxXdJwgYCPktf;
						bHuCiUGmxLZzLKvUeadzsLWOJiuz2.VcrZkfaasqjqAOLOZhZKfRrldrXl = qHSauAFuybkjbNYXyKYUuKQLGCicA;
						return bHuCiUGmxLZzLKvUeadzsLWOJiuz2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class IakafsqfHzHMcjmszSVSisFWMAScb<_0001> : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int pYPyXvzFwzDbUdyaWFVEXBkHVzVm;

					private ElementAssignmentConflictInfo woAWEUrSyEuqjbNqWuLroBNyqapW;

					private int dwUdjUKsqWJszgfjefihNkRNOwAu;

					private global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0001> JbUisifpjZdWsLBtXmCdDrKVAySuA;

					public global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0001> EEnFvMEEHrzKKmRjDVwGjdMqNDsfb;

					private ActionElementMap fRhbyxDoJDcWagboKsktMyatUEpmb;

					public ActionElementMap NCLycBEgRGFgOWBUXBJbGfjgmULNA;

					private _0001 NrRhvHoYNILNWMVHVZFXGcYcEiyv;

					public _0001 VWZFFznKhdTWViDmrvgMwYEDYzhG;

					private bool AnUsiwDSBpOWInPcbhMGyRqaahwV;

					public bool xTjkCnolvbvwCRGhwPhzjGmWLxJo;

					private bool OxVYkwhtKPsGWoqbhCGoMhYIESbaA;

					public bool YuFXAZnURXJPcMJWOXvvkmzVaVoA;

					public ConflictCheckingHelper edMHhKHVCTODPTqKShMEzbkXQEEpA;

					private ControllerType CZlOMzzdZXIQQOnPUmOUyEJjrRNO;

					public ControllerType soRCntyfunrbaQGPmpgZxBHfqKay;

					private int xEGZYzGhpjiYazGPFVmBUVSTibLS;

					public int seotJQJNrIdQDMBVOxCFOxCNlkxt;

					private InputMapCategory HNBsTYVgDEQOghfPpbvTKoOfuQmW;

					private int IyaMywgTkIyFrgFvfhqTVFZmeiOJ;

					private IEnumerator<ElementAssignmentConflictInfo> UeeTXgBEXIoeynnfjFouNPcTUTxm;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return woAWEUrSyEuqjbNqWuLroBNyqapW;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return woAWEUrSyEuqjbNqWuLroBNyqapW;
						}
					}

					[DebuggerHidden]
					public IakafsqfHzHMcjmszSVSisFWMAScb(int P_0)
					{
						pYPyXvzFwzDbUdyaWFVEXBkHVzVm = P_0;
						dwUdjUKsqWJszgfjefihNkRNOwAu = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = pYPyXvzFwzDbUdyaWFVEXBkHVzVm;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								QRLBGXdYNEqTvvTiykTzvODbjCYBA();
							}
						}
						HNBsTYVgDEQOghfPpbvTKoOfuQmW = null;
						UeeTXgBEXIoeynnfjFouNPcTUTxm = null;
						pYPyXvzFwzDbUdyaWFVEXBkHVzVm = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = pYPyXvzFwzDbUdyaWFVEXBkHVzVm;
							ConflictCheckingHelper conflictCheckingHelper = edMHhKHVCTODPTqKShMEzbkXQEEpA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								pYPyXvzFwzDbUdyaWFVEXBkHVzVm = -3;
								goto IL_0141;
							}
							pYPyXvzFwzDbUdyaWFVEXBkHVzVm = -1;
							if (JbUisifpjZdWsLBtXmCdDrKVAySuA == null || fRhbyxDoJDcWagboKsktMyatUEpmb == null)
							{
								return false;
							}
							HNBsTYVgDEQOghfPpbvTKoOfuQmW = ((NrRhvHoYNILNWMVHVZFXGcYcEiyv != null) ? ReInput.mapping.GetMapCategory(NrRhvHoYNILNWMVHVZFXGcYcEiyv.categoryId) : null);
							IyaMywgTkIyFrgFvfhqTVFZmeiOJ = 0;
							goto IL_016d;
							IL_016d:
							if (IyaMywgTkIyFrgFvfhqTVFZmeiOJ < JbUisifpjZdWsLBtXmCdDrKVAySuA.uwAUgkekzffIxggNtXkaazjLDUnI())
							{
								ControllerMap controllerMap = JbUisifpjZdWsLBtXmCdDrKVAySuA.dqSBzdtORLozVFHTanNDwzTffYco(IyaMywgTkIyFrgFvfhqTVFZmeiOJ);
								if ((!AnUsiwDSBpOWInPcbhMGyRqaahwV || controllerMap.enabled) && (OxVYkwhtKPsGWoqbhCGoMhYIESbaA || !conflictCheckingHelper.juUtjedcddFaMqLKagzresIfWVxH(HNBsTYVgDEQOghfPpbvTKoOfuQmW, controllerMap)))
								{
									UeeTXgBEXIoeynnfjFouNPcTUTxm = controllerMap.ElementAssignmentConflicts(fRhbyxDoJDcWagboKsktMyatUEpmb, AnUsiwDSBpOWInPcbhMGyRqaahwV).GetEnumerator();
									pYPyXvzFwzDbUdyaWFVEXBkHVzVm = -3;
									goto IL_0141;
								}
								goto IL_015b;
							}
							return false;
							IL_015b:
							IyaMywgTkIyFrgFvfhqTVFZmeiOJ++;
							goto IL_016d;
							IL_0141:
							if (UeeTXgBEXIoeynnfjFouNPcTUTxm.MoveNext())
							{
								ElementAssignmentConflictInfo current = UeeTXgBEXIoeynnfjFouNPcTUTxm.Current;
								ElementAssignmentConflictInfo elementAssignmentConflictInfo = new ElementAssignmentConflictInfo(current);
								elementAssignmentConflictInfo.playerId = conflictCheckingHelper.JCkZmEAandhUIcbaUtyGDuIxqVBbb.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								elementAssignmentConflictInfo.controllerType = CZlOMzzdZXIQQOnPUmOUyEJjrRNO;
								elementAssignmentConflictInfo.controllerId = xEGZYzGhpjiYazGPFVmBUVSTibLS;
								woAWEUrSyEuqjbNqWuLroBNyqapW = elementAssignmentConflictInfo;
								pYPyXvzFwzDbUdyaWFVEXBkHVzVm = 1;
								return true;
							}
							QRLBGXdYNEqTvvTiykTzvODbjCYBA();
							UeeTXgBEXIoeynnfjFouNPcTUTxm = null;
							goto IL_015b;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void QRLBGXdYNEqTvvTiykTzvODbjCYBA()
					{
						pYPyXvzFwzDbUdyaWFVEXBkHVzVm = -1;
						if (UeeTXgBEXIoeynnfjFouNPcTUTxm != null)
						{
							UeeTXgBEXIoeynnfjFouNPcTUTxm.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						IakafsqfHzHMcjmszSVSisFWMAScb<_0001> iakafsqfHzHMcjmszSVSisFWMAScb;
						if (pYPyXvzFwzDbUdyaWFVEXBkHVzVm == -2 && dwUdjUKsqWJszgfjefihNkRNOwAu == Environment.CurrentManagedThreadId)
						{
							pYPyXvzFwzDbUdyaWFVEXBkHVzVm = 0;
							iakafsqfHzHMcjmszSVSisFWMAScb = this;
						}
						else
						{
							iakafsqfHzHMcjmszSVSisFWMAScb = new IakafsqfHzHMcjmszSVSisFWMAScb<_0001>(0);
							iakafsqfHzHMcjmszSVSisFWMAScb.edMHhKHVCTODPTqKShMEzbkXQEEpA = edMHhKHVCTODPTqKShMEzbkXQEEpA;
						}
						iakafsqfHzHMcjmszSVSisFWMAScb.CZlOMzzdZXIQQOnPUmOUyEJjrRNO = soRCntyfunrbaQGPmpgZxBHfqKay;
						iakafsqfHzHMcjmszSVSisFWMAScb.xEGZYzGhpjiYazGPFVmBUVSTibLS = seotJQJNrIdQDMBVOxCFOxCNlkxt;
						iakafsqfHzHMcjmszSVSisFWMAScb.NrRhvHoYNILNWMVHVZFXGcYcEiyv = VWZFFznKhdTWViDmrvgMwYEDYzhG;
						iakafsqfHzHMcjmszSVSisFWMAScb.fRhbyxDoJDcWagboKsktMyatUEpmb = NCLycBEgRGFgOWBUXBJbGfjgmULNA;
						iakafsqfHzHMcjmszSVSisFWMAScb.AnUsiwDSBpOWInPcbhMGyRqaahwV = xTjkCnolvbvwCRGhwPhzjGmWLxJo;
						iakafsqfHzHMcjmszSVSisFWMAScb.OxVYkwhtKPsGWoqbhCGoMhYIESbaA = YuFXAZnURXJPcMJWOXvvkmzVaVoA;
						iakafsqfHzHMcjmszSVSisFWMAScb.JbUisifpjZdWsLBtXmCdDrKVAySuA = EEnFvMEEHrzKKmRjDVwGjdMqNDsfb;
						return iakafsqfHzHMcjmszSVSisFWMAScb;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class rVwaFKdbQKTRtNVSrqQJavlhHpgPc<_0001> : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int HEYpEPUfOLgmfcueeeFwDXPVjlMC;

					private ElementAssignmentConflictInfo uuOYUcQJBELFvYRzprKuADsIzoxB;

					private int esZfGQehtDnOKRHpXfzHEBfsvtQA;

					private global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0001> dAQhfEaShpZOrkjMVINwwalHMoBT;

					public global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0001> OuFalqIZQxtxYVIvWUfNFTyuheZP;

					private ElementAssignmentConflictCheck ATtUTTDjIGpPBJcCuehmNVAwXBDT;

					public ElementAssignmentConflictCheck AiOiwgvPQkFbjhxGFjyZZADnFGqr;

					private bool wEOJbVEFbMAhAjkJnwJNKMXZztWfA;

					public bool duTGtrFlBXxefMYZhVXbwPFJhLmj;

					private bool zRByWIMdvBIOZFiffvPTAFcAIrVh;

					public bool JSNBMTDSYnJmfNMWsOQTMepAiFgm;

					public ConflictCheckingHelper xelXfDXShRFnmkScFPReCdigCEkkA;

					private InputMapCategory QBSMVtrlJYclOZEUtYidXdRaXPId;

					private int OlkqirjxXVIXGrKSWGdBAZEJlqgS;

					private IEnumerator<ElementAssignmentConflictInfo> JPxoZReJahprHzNiQiNVGgmcLcId;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return uuOYUcQJBELFvYRzprKuADsIzoxB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return uuOYUcQJBELFvYRzprKuADsIzoxB;
						}
					}

					[DebuggerHidden]
					public rVwaFKdbQKTRtNVSrqQJavlhHpgPc(int P_0)
					{
						HEYpEPUfOLgmfcueeeFwDXPVjlMC = P_0;
						esZfGQehtDnOKRHpXfzHEBfsvtQA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int hEYpEPUfOLgmfcueeeFwDXPVjlMC = HEYpEPUfOLgmfcueeeFwDXPVjlMC;
						if (hEYpEPUfOLgmfcueeeFwDXPVjlMC == -3 || hEYpEPUfOLgmfcueeeFwDXPVjlMC == 1)
						{
							try
							{
							}
							finally
							{
								eyWUhhRZVAjcAhMZFchnFGvQxLkS();
							}
						}
						QBSMVtrlJYclOZEUtYidXdRaXPId = null;
						JPxoZReJahprHzNiQiNVGgmcLcId = null;
						HEYpEPUfOLgmfcueeeFwDXPVjlMC = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int hEYpEPUfOLgmfcueeeFwDXPVjlMC = HEYpEPUfOLgmfcueeeFwDXPVjlMC;
							ConflictCheckingHelper conflictCheckingHelper = xelXfDXShRFnmkScFPReCdigCEkkA;
							if (hEYpEPUfOLgmfcueeeFwDXPVjlMC != 0)
							{
								if (hEYpEPUfOLgmfcueeeFwDXPVjlMC != 1)
								{
									return false;
								}
								HEYpEPUfOLgmfcueeeFwDXPVjlMC = -3;
								goto IL_01ab;
							}
							HEYpEPUfOLgmfcueeeFwDXPVjlMC = -1;
							if (dAQhfEaShpZOrkjMVINwwalHMoBT == null)
							{
								return false;
							}
							Player player = ReInput.players.GetPlayer(ATtUTTDjIGpPBJcCuehmNVAwXBDT.playerId);
							if (player == null)
							{
								return false;
							}
							ControllerMap map = player.controllers.maps.GetMap(ATtUTTDjIGpPBJcCuehmNVAwXBDT.controllerType, ATtUTTDjIGpPBJcCuehmNVAwXBDT.controllerId, ATtUTTDjIGpPBJcCuehmNVAwXBDT.controllerMapId);
							QBSMVtrlJYclOZEUtYidXdRaXPId = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(ATtUTTDjIGpPBJcCuehmNVAwXBDT.controllerMapCategoryId));
							if (QBSMVtrlJYclOZEUtYidXdRaXPId == null)
							{
								return false;
							}
							OlkqirjxXVIXGrKSWGdBAZEJlqgS = 0;
							goto IL_01d7;
							IL_01ab:
							if (JPxoZReJahprHzNiQiNVGgmcLcId.MoveNext())
							{
								ElementAssignmentConflictInfo current = JPxoZReJahprHzNiQiNVGgmcLcId.Current;
								ElementAssignmentConflictInfo elementAssignmentConflictInfo = new ElementAssignmentConflictInfo(current);
								elementAssignmentConflictInfo.playerId = conflictCheckingHelper.JCkZmEAandhUIcbaUtyGDuIxqVBbb.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								elementAssignmentConflictInfo.controllerType = ATtUTTDjIGpPBJcCuehmNVAwXBDT.controllerType;
								elementAssignmentConflictInfo.controllerId = ATtUTTDjIGpPBJcCuehmNVAwXBDT.controllerId;
								uuOYUcQJBELFvYRzprKuADsIzoxB = elementAssignmentConflictInfo;
								HEYpEPUfOLgmfcueeeFwDXPVjlMC = 1;
								return true;
							}
							eyWUhhRZVAjcAhMZFchnFGvQxLkS();
							JPxoZReJahprHzNiQiNVGgmcLcId = null;
							goto IL_01c5;
							IL_01d7:
							if (OlkqirjxXVIXGrKSWGdBAZEJlqgS < dAQhfEaShpZOrkjMVINwwalHMoBT.uwAUgkekzffIxggNtXkaazjLDUnI())
							{
								ControllerMap controllerMap = dAQhfEaShpZOrkjMVINwwalHMoBT.dqSBzdtORLozVFHTanNDwzTffYco(OlkqirjxXVIXGrKSWGdBAZEJlqgS);
								if ((!wEOJbVEFbMAhAjkJnwJNKMXZztWfA || controllerMap.enabled) && (zRByWIMdvBIOZFiffvPTAFcAIrVh || !conflictCheckingHelper.juUtjedcddFaMqLKagzresIfWVxH(QBSMVtrlJYclOZEUtYidXdRaXPId, controllerMap)))
								{
									JPxoZReJahprHzNiQiNVGgmcLcId = controllerMap.ElementAssignmentConflicts(ATtUTTDjIGpPBJcCuehmNVAwXBDT, wEOJbVEFbMAhAjkJnwJNKMXZztWfA).GetEnumerator();
									HEYpEPUfOLgmfcueeeFwDXPVjlMC = -3;
									goto IL_01ab;
								}
								goto IL_01c5;
							}
							return false;
							IL_01c5:
							OlkqirjxXVIXGrKSWGdBAZEJlqgS++;
							goto IL_01d7;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void eyWUhhRZVAjcAhMZFchnFGvQxLkS()
					{
						HEYpEPUfOLgmfcueeeFwDXPVjlMC = -1;
						if (JPxoZReJahprHzNiQiNVGgmcLcId != null)
						{
							JPxoZReJahprHzNiQiNVGgmcLcId.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						rVwaFKdbQKTRtNVSrqQJavlhHpgPc<_0001> rVwaFKdbQKTRtNVSrqQJavlhHpgPc2;
						if (HEYpEPUfOLgmfcueeeFwDXPVjlMC == -2 && esZfGQehtDnOKRHpXfzHEBfsvtQA == Environment.CurrentManagedThreadId)
						{
							HEYpEPUfOLgmfcueeeFwDXPVjlMC = 0;
							rVwaFKdbQKTRtNVSrqQJavlhHpgPc2 = this;
						}
						else
						{
							rVwaFKdbQKTRtNVSrqQJavlhHpgPc2 = new rVwaFKdbQKTRtNVSrqQJavlhHpgPc<_0001>(0);
							rVwaFKdbQKTRtNVSrqQJavlhHpgPc2.xelXfDXShRFnmkScFPReCdigCEkkA = xelXfDXShRFnmkScFPReCdigCEkkA;
						}
						rVwaFKdbQKTRtNVSrqQJavlhHpgPc2.ATtUTTDjIGpPBJcCuehmNVAwXBDT = AiOiwgvPQkFbjhxGFjyZZADnFGqr;
						rVwaFKdbQKTRtNVSrqQJavlhHpgPc2.wEOJbVEFbMAhAjkJnwJNKMXZztWfA = duTGtrFlBXxefMYZhVXbwPFJhLmj;
						rVwaFKdbQKTRtNVSrqQJavlhHpgPc2.zRByWIMdvBIOZFiffvPTAFcAIrVh = JSNBMTDSYnJmfNMWsOQTMepAiFgm;
						rVwaFKdbQKTRtNVSrqQJavlhHpgPc2.dAQhfEaShpZOrkjMVINwwalHMoBT = OuFalqIZQxtxYVIvWUfNFTyuheZP;
						return rVwaFKdbQKTRtNVSrqQJavlhHpgPc2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class ywTNMvHMBdtcxvReRNgtVLdfcqjr : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int aCyaRGkmyXpzdWvYmulXJIAfbEfHb;

					private ElementAssignmentConflictInfo GYSbOWkdvJdGntwzXXpfrIPqrfyU;

					private int omMHiiuvYnNmJthQRLOZBVHDEqHC;

					private int QPEztRPwMrfYixeGOKbdcbOlBdMKA;

					public int BDmogXioQOdKfFlOgPFPBVzwhAWW;

					private JoystickMap qhLQcstiNPGhVaPGOWqkIdmGaXxB;

					public JoystickMap MaIWmufJWhzqIqctdfVugNTbpOBc;

					public ConflictCheckingHelper roEBzqkciUAtfAPOiOgZPTHeAeau;

					private bool PhjGgFWRcnBrAOwMTLOkhCoogvwhA;

					public bool lUsTjuPxEHnqkFnFLPMTEwLdnFwo;

					private bool WPMlRAOdFwBbcArxRBgOcUVgHpJAA;

					public bool qshUgNXjHeHWlONxHmilpQPxtWnR;

					private int YsJvuKojcvGFlUWBqcVqskGibuzaA;

					private IEnumerator<ElementAssignmentConflictInfo> HHNopjTmtAgZJenZHWCdmqlEBzMYA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return GYSbOWkdvJdGntwzXXpfrIPqrfyU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return GYSbOWkdvJdGntwzXXpfrIPqrfyU;
						}
					}

					[DebuggerHidden]
					public ywTNMvHMBdtcxvReRNgtVLdfcqjr(int P_0)
					{
						aCyaRGkmyXpzdWvYmulXJIAfbEfHb = P_0;
						omMHiiuvYnNmJthQRLOZBVHDEqHC = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = aCyaRGkmyXpzdWvYmulXJIAfbEfHb;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								zfWuGWHtPVJNHpcxvVseWTXrInqM();
							}
						}
						HHNopjTmtAgZJenZHWCdmqlEBzMYA = null;
						aCyaRGkmyXpzdWvYmulXJIAfbEfHb = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = aCyaRGkmyXpzdWvYmulXJIAfbEfHb;
							ConflictCheckingHelper conflictCheckingHelper = roEBzqkciUAtfAPOiOgZPTHeAeau;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								aCyaRGkmyXpzdWvYmulXJIAfbEfHb = -3;
								goto IL_00ea;
							}
							aCyaRGkmyXpzdWvYmulXJIAfbEfHb = -1;
							if (QPEztRPwMrfYixeGOKbdcbOlBdMKA < 0 || qhLQcstiNPGhVaPGOWqkIdmGaXxB == null)
							{
								return false;
							}
							YsJvuKojcvGFlUWBqcVqskGibuzaA = 0;
							goto IL_0116;
							IL_00ea:
							if (HHNopjTmtAgZJenZHWCdmqlEBzMYA.MoveNext())
							{
								ElementAssignmentConflictInfo current = HHNopjTmtAgZJenZHWCdmqlEBzMYA.Current;
								GYSbOWkdvJdGntwzXXpfrIPqrfyU = current;
								aCyaRGkmyXpzdWvYmulXJIAfbEfHb = 1;
								return true;
							}
							zfWuGWHtPVJNHpcxvVseWTXrInqM();
							HHNopjTmtAgZJenZHWCdmqlEBzMYA = null;
							goto IL_0104;
							IL_0116:
							if (YsJvuKojcvGFlUWBqcVqskGibuzaA < conflictCheckingHelper.oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.tXrSkfcScZdadhIEmSRyjQoYKHYaA())
							{
								if (conflictCheckingHelper.oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(YsJvuKojcvGFlUWBqcVqskGibuzaA).jShzJcgXohXkJgAjbKdTzokqckTE.id == QPEztRPwMrfYixeGOKbdcbOlBdMKA)
								{
									HHNopjTmtAgZJenZHWCdmqlEBzMYA = conflictCheckingHelper.BkahyuxuzBdgwXAIEhEREhbdekGFb(ControllerType.Joystick, QPEztRPwMrfYixeGOKbdcbOlBdMKA, qhLQcstiNPGhVaPGOWqkIdmGaXxB, PhjGgFWRcnBrAOwMTLOkhCoogvwhA, WPMlRAOdFwBbcArxRBgOcUVgHpJAA, conflictCheckingHelper.oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(YsJvuKojcvGFlUWBqcVqskGibuzaA).oNEqVoyniAQxhPXQGcMENGIkPfMg).GetEnumerator();
									aCyaRGkmyXpzdWvYmulXJIAfbEfHb = -3;
									goto IL_00ea;
								}
								goto IL_0104;
							}
							return false;
							IL_0104:
							YsJvuKojcvGFlUWBqcVqskGibuzaA++;
							goto IL_0116;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void zfWuGWHtPVJNHpcxvVseWTXrInqM()
					{
						aCyaRGkmyXpzdWvYmulXJIAfbEfHb = -1;
						if (HHNopjTmtAgZJenZHWCdmqlEBzMYA != null)
						{
							HHNopjTmtAgZJenZHWCdmqlEBzMYA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						ywTNMvHMBdtcxvReRNgtVLdfcqjr ywTNMvHMBdtcxvReRNgtVLdfcqjr2;
						if (aCyaRGkmyXpzdWvYmulXJIAfbEfHb == -2 && omMHiiuvYnNmJthQRLOZBVHDEqHC == Environment.CurrentManagedThreadId)
						{
							aCyaRGkmyXpzdWvYmulXJIAfbEfHb = 0;
							ywTNMvHMBdtcxvReRNgtVLdfcqjr2 = this;
						}
						else
						{
							ywTNMvHMBdtcxvReRNgtVLdfcqjr2 = new ywTNMvHMBdtcxvReRNgtVLdfcqjr(0);
							ywTNMvHMBdtcxvReRNgtVLdfcqjr2.roEBzqkciUAtfAPOiOgZPTHeAeau = roEBzqkciUAtfAPOiOgZPTHeAeau;
						}
						ywTNMvHMBdtcxvReRNgtVLdfcqjr2.QPEztRPwMrfYixeGOKbdcbOlBdMKA = BDmogXioQOdKfFlOgPFPBVzwhAWW;
						ywTNMvHMBdtcxvReRNgtVLdfcqjr2.qhLQcstiNPGhVaPGOWqkIdmGaXxB = MaIWmufJWhzqIqctdfVugNTbpOBc;
						ywTNMvHMBdtcxvReRNgtVLdfcqjr2.PhjGgFWRcnBrAOwMTLOkhCoogvwhA = lUsTjuPxEHnqkFnFLPMTEwLdnFwo;
						ywTNMvHMBdtcxvReRNgtVLdfcqjr2.WPMlRAOdFwBbcArxRBgOcUVgHpJAA = qshUgNXjHeHWlONxHmilpQPxtWnR;
						return ywTNMvHMBdtcxvReRNgtVLdfcqjr2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class iLjGhgfMkLRTSPwJWiSCSGvvmVvtA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int AfOdBSUPmXNgvAHSeDmnbxbQvvlJA;

					private ElementAssignmentConflictInfo VbabfNxRGgTvfGyEvMUDsbIIEpAY;

					private int hqycBLULEtUNBKIKcZUDhKElFFks;

					private int TsxDafUtcLAIQybMSnRQJkKWCqqV;

					public int treXlcuqCMVXHiZWPaKaAqxsftfbA;

					private ActionElementMap pCfJoqYhRmXDurPbahCQWuDRZkxQ;

					public ActionElementMap PHfgKIOEPkxXzVEJhlQreNLudKtIA;

					public ConflictCheckingHelper MiJvfvKffoFClirNTVmMweJumFpqA;

					private JoystickMap dhuMZVuOwDNjtFOKsytPJNwNQtlS;

					public JoystickMap JgLFRYcJjJGgOlRQQsYmDraXRSjh;

					private bool kFFfDHjOSeHbSYssLNobnbIDlfXp;

					public bool DyWJQpjYkWqMzkQSSxgTzHfgillF;

					private bool QvKuqrGeuTYPgwRkXuBSCILHDEwl;

					public bool ShgbPnUMnhuIXTtbctEmVWDciZLJ;

					private int dNXInfMAmWntCYhsOhJBaSFftuvc;

					private IEnumerator<ElementAssignmentConflictInfo> dcQJJieuejZTvEGkkboWhshDXyyg;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return VbabfNxRGgTvfGyEvMUDsbIIEpAY;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return VbabfNxRGgTvfGyEvMUDsbIIEpAY;
						}
					}

					[DebuggerHidden]
					public iLjGhgfMkLRTSPwJWiSCSGvvmVvtA(int P_0)
					{
						AfOdBSUPmXNgvAHSeDmnbxbQvvlJA = P_0;
						hqycBLULEtUNBKIKcZUDhKElFFks = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int afOdBSUPmXNgvAHSeDmnbxbQvvlJA = AfOdBSUPmXNgvAHSeDmnbxbQvvlJA;
						if (afOdBSUPmXNgvAHSeDmnbxbQvvlJA == -3 || afOdBSUPmXNgvAHSeDmnbxbQvvlJA == 1)
						{
							try
							{
							}
							finally
							{
								rIEkZZJqmnLZBXEgWCHLmLCEZZfF();
							}
						}
						dcQJJieuejZTvEGkkboWhshDXyyg = null;
						AfOdBSUPmXNgvAHSeDmnbxbQvvlJA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int afOdBSUPmXNgvAHSeDmnbxbQvvlJA = AfOdBSUPmXNgvAHSeDmnbxbQvvlJA;
							ConflictCheckingHelper miJvfvKffoFClirNTVmMweJumFpqA = MiJvfvKffoFClirNTVmMweJumFpqA;
							if (afOdBSUPmXNgvAHSeDmnbxbQvvlJA != 0)
							{
								if (afOdBSUPmXNgvAHSeDmnbxbQvvlJA != 1)
								{
									return false;
								}
								AfOdBSUPmXNgvAHSeDmnbxbQvvlJA = -3;
								goto IL_00f0;
							}
							AfOdBSUPmXNgvAHSeDmnbxbQvvlJA = -1;
							if (TsxDafUtcLAIQybMSnRQJkKWCqqV < 0 || pCfJoqYhRmXDurPbahCQWuDRZkxQ == null)
							{
								return false;
							}
							dNXInfMAmWntCYhsOhJBaSFftuvc = 0;
							goto IL_011c;
							IL_00f0:
							if (dcQJJieuejZTvEGkkboWhshDXyyg.MoveNext())
							{
								ElementAssignmentConflictInfo current = dcQJJieuejZTvEGkkboWhshDXyyg.Current;
								VbabfNxRGgTvfGyEvMUDsbIIEpAY = current;
								AfOdBSUPmXNgvAHSeDmnbxbQvvlJA = 1;
								return true;
							}
							rIEkZZJqmnLZBXEgWCHLmLCEZZfF();
							dcQJJieuejZTvEGkkboWhshDXyyg = null;
							goto IL_010a;
							IL_011c:
							if (dNXInfMAmWntCYhsOhJBaSFftuvc < miJvfvKffoFClirNTVmMweJumFpqA.oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.tXrSkfcScZdadhIEmSRyjQoYKHYaA())
							{
								if (miJvfvKffoFClirNTVmMweJumFpqA.oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(dNXInfMAmWntCYhsOhJBaSFftuvc).jShzJcgXohXkJgAjbKdTzokqckTE.id == TsxDafUtcLAIQybMSnRQJkKWCqqV)
								{
									dcQJJieuejZTvEGkkboWhshDXyyg = miJvfvKffoFClirNTVmMweJumFpqA.brzWRkOKAySfYuGWMdVCrDFfbTIEA(ControllerType.Joystick, TsxDafUtcLAIQybMSnRQJkKWCqqV, dhuMZVuOwDNjtFOKsytPJNwNQtlS, pCfJoqYhRmXDurPbahCQWuDRZkxQ, kFFfDHjOSeHbSYssLNobnbIDlfXp, QvKuqrGeuTYPgwRkXuBSCILHDEwl, miJvfvKffoFClirNTVmMweJumFpqA.oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(dNXInfMAmWntCYhsOhJBaSFftuvc).oNEqVoyniAQxhPXQGcMENGIkPfMg).GetEnumerator();
									AfOdBSUPmXNgvAHSeDmnbxbQvvlJA = -3;
									goto IL_00f0;
								}
								goto IL_010a;
							}
							return false;
							IL_010a:
							dNXInfMAmWntCYhsOhJBaSFftuvc++;
							goto IL_011c;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void rIEkZZJqmnLZBXEgWCHLmLCEZZfF()
					{
						AfOdBSUPmXNgvAHSeDmnbxbQvvlJA = -1;
						if (dcQJJieuejZTvEGkkboWhshDXyyg != null)
						{
							dcQJJieuejZTvEGkkboWhshDXyyg.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						iLjGhgfMkLRTSPwJWiSCSGvvmVvtA iLjGhgfMkLRTSPwJWiSCSGvvmVvtA2;
						if (AfOdBSUPmXNgvAHSeDmnbxbQvvlJA == -2 && hqycBLULEtUNBKIKcZUDhKElFFks == Environment.CurrentManagedThreadId)
						{
							AfOdBSUPmXNgvAHSeDmnbxbQvvlJA = 0;
							iLjGhgfMkLRTSPwJWiSCSGvvmVvtA2 = this;
						}
						else
						{
							iLjGhgfMkLRTSPwJWiSCSGvvmVvtA2 = new iLjGhgfMkLRTSPwJWiSCSGvvmVvtA(0);
							iLjGhgfMkLRTSPwJWiSCSGvvmVvtA2.MiJvfvKffoFClirNTVmMweJumFpqA = MiJvfvKffoFClirNTVmMweJumFpqA;
						}
						iLjGhgfMkLRTSPwJWiSCSGvvmVvtA2.TsxDafUtcLAIQybMSnRQJkKWCqqV = treXlcuqCMVXHiZWPaKaAqxsftfbA;
						iLjGhgfMkLRTSPwJWiSCSGvvmVvtA2.dhuMZVuOwDNjtFOKsytPJNwNQtlS = JgLFRYcJjJGgOlRQQsYmDraXRSjh;
						iLjGhgfMkLRTSPwJWiSCSGvvmVvtA2.pCfJoqYhRmXDurPbahCQWuDRZkxQ = PHfgKIOEPkxXzVEJhlQreNLudKtIA;
						iLjGhgfMkLRTSPwJWiSCSGvvmVvtA2.kFFfDHjOSeHbSYssLNobnbIDlfXp = DyWJQpjYkWqMzkQSSxgTzHfgillF;
						iLjGhgfMkLRTSPwJWiSCSGvvmVvtA2.QvKuqrGeuTYPgwRkXuBSCILHDEwl = ShgbPnUMnhuIXTtbctEmVWDciZLJ;
						return iLjGhgfMkLRTSPwJWiSCSGvvmVvtA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class vEZzYkESOCbXLfziVSXlWygpNJru : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int RTVtEYhMKvnOHCmbiKPQtneUKXjs;

					private ElementAssignmentConflictInfo WJrBBmcdIiUObzaDIdftimJgBbwo;

					private int rxDjPUvhEDVLLqoExmzQBWPwREaO;

					private ElementAssignmentConflictCheck yelNIZxhMtbWldDjIVKrfMQUOqAP;

					public ElementAssignmentConflictCheck sNgHFlqjNoAFkqEIETnhnjkxeqHu;

					public ConflictCheckingHelper piGvzNGSMlfHrHaFpMDABmYKuHFM;

					private bool ATTBPOcdTbKxTaiOFQnykWWiJyWS;

					public bool juufTShkOTSsTPuErQGZzmtLVHIS;

					private bool jUCFWADDRaIUcxrMizMxsKAkExpO;

					public bool uLXcruBBmjJbEYuYcjvYJfPHEETr;

					private int zrVFajaWvmwYITsSomgbfavjSLotb;

					private IEnumerator<ElementAssignmentConflictInfo> iuZevBdTxhMPOfYXTirstWrsGSzg;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WJrBBmcdIiUObzaDIdftimJgBbwo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WJrBBmcdIiUObzaDIdftimJgBbwo;
						}
					}

					[DebuggerHidden]
					public vEZzYkESOCbXLfziVSXlWygpNJru(int P_0)
					{
						RTVtEYhMKvnOHCmbiKPQtneUKXjs = P_0;
						rxDjPUvhEDVLLqoExmzQBWPwREaO = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int rTVtEYhMKvnOHCmbiKPQtneUKXjs = RTVtEYhMKvnOHCmbiKPQtneUKXjs;
						if (rTVtEYhMKvnOHCmbiKPQtneUKXjs == -3 || rTVtEYhMKvnOHCmbiKPQtneUKXjs == 1)
						{
							try
							{
							}
							finally
							{
								ZhAhulXFnOVNbhedkgejkyVpNmdoA();
							}
						}
						iuZevBdTxhMPOfYXTirstWrsGSzg = null;
						RTVtEYhMKvnOHCmbiKPQtneUKXjs = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int rTVtEYhMKvnOHCmbiKPQtneUKXjs = RTVtEYhMKvnOHCmbiKPQtneUKXjs;
							ConflictCheckingHelper conflictCheckingHelper = piGvzNGSMlfHrHaFpMDABmYKuHFM;
							if (rTVtEYhMKvnOHCmbiKPQtneUKXjs != 0)
							{
								if (rTVtEYhMKvnOHCmbiKPQtneUKXjs != 1)
								{
									return false;
								}
								RTVtEYhMKvnOHCmbiKPQtneUKXjs = -3;
								goto IL_00f3;
							}
							RTVtEYhMKvnOHCmbiKPQtneUKXjs = -1;
							if (yelNIZxhMtbWldDjIVKrfMQUOqAP.controllerId < 0 || yelNIZxhMtbWldDjIVKrfMQUOqAP.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							zrVFajaWvmwYITsSomgbfavjSLotb = 0;
							goto IL_011f;
							IL_00f3:
							if (iuZevBdTxhMPOfYXTirstWrsGSzg.MoveNext())
							{
								ElementAssignmentConflictInfo current = iuZevBdTxhMPOfYXTirstWrsGSzg.Current;
								WJrBBmcdIiUObzaDIdftimJgBbwo = current;
								RTVtEYhMKvnOHCmbiKPQtneUKXjs = 1;
								return true;
							}
							ZhAhulXFnOVNbhedkgejkyVpNmdoA();
							iuZevBdTxhMPOfYXTirstWrsGSzg = null;
							goto IL_010d;
							IL_011f:
							if (zrVFajaWvmwYITsSomgbfavjSLotb < conflictCheckingHelper.oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.tXrSkfcScZdadhIEmSRyjQoYKHYaA())
							{
								if (conflictCheckingHelper.oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(zrVFajaWvmwYITsSomgbfavjSLotb).jShzJcgXohXkJgAjbKdTzokqckTE.id == yelNIZxhMtbWldDjIVKrfMQUOqAP.controllerId)
								{
									iuZevBdTxhMPOfYXTirstWrsGSzg = conflictCheckingHelper.EkHrwdNDPDFbHHONPuXdOmuqkCgqA(yelNIZxhMtbWldDjIVKrfMQUOqAP, ATTBPOcdTbKxTaiOFQnykWWiJyWS, jUCFWADDRaIUcxrMizMxsKAkExpO, conflictCheckingHelper.oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(zrVFajaWvmwYITsSomgbfavjSLotb).oNEqVoyniAQxhPXQGcMENGIkPfMg).GetEnumerator();
									RTVtEYhMKvnOHCmbiKPQtneUKXjs = -3;
									goto IL_00f3;
								}
								goto IL_010d;
							}
							return false;
							IL_010d:
							zrVFajaWvmwYITsSomgbfavjSLotb++;
							goto IL_011f;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void ZhAhulXFnOVNbhedkgejkyVpNmdoA()
					{
						RTVtEYhMKvnOHCmbiKPQtneUKXjs = -1;
						if (iuZevBdTxhMPOfYXTirstWrsGSzg != null)
						{
							iuZevBdTxhMPOfYXTirstWrsGSzg.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						vEZzYkESOCbXLfziVSXlWygpNJru vEZzYkESOCbXLfziVSXlWygpNJru2;
						if (RTVtEYhMKvnOHCmbiKPQtneUKXjs == -2 && rxDjPUvhEDVLLqoExmzQBWPwREaO == Environment.CurrentManagedThreadId)
						{
							RTVtEYhMKvnOHCmbiKPQtneUKXjs = 0;
							vEZzYkESOCbXLfziVSXlWygpNJru2 = this;
						}
						else
						{
							vEZzYkESOCbXLfziVSXlWygpNJru2 = new vEZzYkESOCbXLfziVSXlWygpNJru(0);
							vEZzYkESOCbXLfziVSXlWygpNJru2.piGvzNGSMlfHrHaFpMDABmYKuHFM = piGvzNGSMlfHrHaFpMDABmYKuHFM;
						}
						vEZzYkESOCbXLfziVSXlWygpNJru2.yelNIZxhMtbWldDjIVKrfMQUOqAP = sNgHFlqjNoAFkqEIETnhnjkxeqHu;
						vEZzYkESOCbXLfziVSXlWygpNJru2.ATTBPOcdTbKxTaiOFQnykWWiJyWS = juufTShkOTSsTPuErQGZzmtLVHIS;
						vEZzYkESOCbXLfziVSXlWygpNJru2.jUCFWADDRaIUcxrMizMxsKAkExpO = uLXcruBBmjJbEYuYcjvYJfPHEETr;
						return vEZzYkESOCbXLfziVSXlWygpNJru2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private readonly Player JCkZmEAandhUIcbaUtyGDuIxqVBbb;

				private readonly ControllerHelper oEiBTKxSOMeZXgHvRqcHuOhQHDgwA;

				private readonly int LHIAvBhoXrmvJFUPgaCZasngBuqnb;

				internal ConflictCheckingHelper(Player P_0, ControllerHelper P_1)
				{
					LHIAvBhoXrmvJFUPgaCZasngBuqnb = ReInput.id;
					JCkZmEAandhUIcbaUtyGDuIxqVBbb = P_0;
					oEiBTKxSOMeZXgHvRqcHuOhQHDgwA = P_1;
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
				{
					return DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps)
				{
					return DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != LHIAvBhoXrmvJFUPgaCZasngBuqnb)
					{
						ReInput.CheckInitialized(LHIAvBhoXrmvJFUPgaCZasngBuqnb);
						return false;
					}
					if (controllerMap == null)
					{
						return false;
					}
					return controllerType switch
					{
						ControllerType.Joystick => MACUwkSqPsDDOdCvdLugDiavSaVP(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => csSHiCKjbCXhPfPFMVSihtLvfsjn(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => uRxnmAsXoFpzyVWAtIxEmdmtTefv(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => LVmjbsCBjRGOBfrEwcqvwNjucZHW(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != LHIAvBhoXrmvJFUPgaCZasngBuqnb)
					{
						ReInput.CheckInitialized(LHIAvBhoXrmvJFUPgaCZasngBuqnb);
						return false;
					}
					if (controllerMap == null || elementMap == null)
					{
						return false;
					}
					return controllerType switch
					{
						ControllerType.Joystick => RoBvzhRCYuSomtjEnfzkTCXFjncG(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => CuXESaFMfLNbrIxSuhkRoMmCHgKvA(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => fwijJjenXvbVVqgeJvVbsoBJTFfM(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => zRdJItMeBTlvKLAywTfGJqeCkQaX(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck)
				{
					return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != LHIAvBhoXrmvJFUPgaCZasngBuqnb)
					{
						ReInput.CheckInitialized(LHIAvBhoXrmvJFUPgaCZasngBuqnb);
						return false;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return ioWkGQHdTkjmCZysBGAQANRCOOAF(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return OoNLpNoWLXOKwwZHvhSzcaaDSIzt(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return uAhIwHDrDrwhrzQsZGOsefwPNbaL(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return GzZmAwaUdHAYXJmXsjkJUTewkdLt(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
				{
					return ElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps)
				{
					return ElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != LHIAvBhoXrmvJFUPgaCZasngBuqnb)
					{
						ReInput.CheckInitialized(LHIAvBhoXrmvJFUPgaCZasngBuqnb);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (controllerMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return controllerType switch
					{
						ControllerType.Joystick => JVVGZCcTajtgApeeatKlfVKHqiUfb(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => JQzKaUcyWCrVCSDeuOrKFuWeCVvL(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => BSeCJnueAnKfGcdDubLfAUVlIgts(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => QLwGaZXXhuGAVkJWZEyVtdJztWTD(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return ElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return ElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != LHIAvBhoXrmvJFUPgaCZasngBuqnb)
					{
						ReInput.CheckInitialized(LHIAvBhoXrmvJFUPgaCZasngBuqnb);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (controllerMap == null || elementMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return controllerType switch
					{
						ControllerType.Joystick => izSvtpgJWqKCdmgteDdpawRbvnwvA(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => LVMBRGcAbcjAafcGoipliBxEvrcfB(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => sDpIbgybrpTFeWRgbXCWQdTyrXgl(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => jzPZLccoCdhYKDaPofPzMcbDuINnA(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != LHIAvBhoXrmvJFUPgaCZasngBuqnb)
					{
						ReInput.CheckInitialized(LHIAvBhoXrmvJFUPgaCZasngBuqnb);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return jMLBUbOmWwAqRyVLduZeKfNOaqJB(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return dncbqvvDGGKFHxEsicQLiaBdmeFz(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return IRsxatRnkcIZzSGohdrOxrxcIouF(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return atDXfvQkNSUptZjFcZETgpXrdHhq(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
				{
					return RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipRemovedMaps: false, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipRemovedMaps)
				{
					return RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipRemovedMaps, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipRemovedMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != LHIAvBhoXrmvJFUPgaCZasngBuqnb)
					{
						ReInput.CheckInitialized(LHIAvBhoXrmvJFUPgaCZasngBuqnb);
						return 0;
					}
					if (controllerMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => eBlOtndErtNqxDyKWdDNpSeraPyj(controllerId, controllerMap as JoystickMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => axIarEPVhzEPMCorictiaZtUMnXd(controllerMap as KeyboardMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Mouse => gECxaaPyiTRRJUqvCHlhAqeqHTIi(controllerMap as MouseMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Custom => VHAGJUbHFvencuVdacinKmHsoTKs(controllerId, controllerMap as CustomControllerMap, skipRemovedMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipRemovedMaps: false, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipRemovedMaps)
				{
					return RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipRemovedMaps, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipRemovedMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != LHIAvBhoXrmvJFUPgaCZasngBuqnb)
					{
						ReInput.CheckInitialized(LHIAvBhoXrmvJFUPgaCZasngBuqnb);
						return 0;
					}
					if (controllerMap == null || elementMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => mtvQjGkTHjoBWFeVnANHAmEoQrZT(controllerId, controllerMap as JoystickMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => NbjsKmHtrDqSrsOVBjOKqtOdqCwl(controllerMap as KeyboardMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Mouse => LcBkGbzTJRcdLKXyYQXOtqkOJmlm(controllerMap as MouseMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Custom => ysnNVppywnVImoFdIGsRjMvDLdCC(controllerId, controllerMap as CustomControllerMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return RemoveElementAssignmentConflicts(conflictCheck, skipRemovedMaps: false, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipRemovedMaps)
				{
					return RemoveElementAssignmentConflicts(conflictCheck, skipRemovedMaps, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipRemovedMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != LHIAvBhoXrmvJFUPgaCZasngBuqnb)
					{
						ReInput.CheckInitialized(LHIAvBhoXrmvJFUPgaCZasngBuqnb);
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return TVgKEpXwiuUBpxHtOioLsKZMdPjIA(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return RdCGdteXoSLWojQopRYyBsXbUdSVA(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return GtDHlWiRFeocVciBtFgyzVbfmIZJ(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return qtXfpTXdOigbSIFBZaWAAwHCVGFIc(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
				{
					return DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps)
				{
					return DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != LHIAvBhoXrmvJFUPgaCZasngBuqnb)
					{
						ReInput.CheckInitialized(LHIAvBhoXrmvJFUPgaCZasngBuqnb);
						return 0;
					}
					if (controllerMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => OiNJLDeBCaNrQZZPTjYCHUqfLsmp(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => IZrTSZHYissJwxAnpaVFUHdNDdOx(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => VuaQPgSzMdojhmNkEeTAADQnekrBA(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => gXiAdjprgmIApHCAGyjcMUbhoglYA(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != LHIAvBhoXrmvJFUPgaCZasngBuqnb)
					{
						ReInput.CheckInitialized(LHIAvBhoXrmvJFUPgaCZasngBuqnb);
						return 0;
					}
					if (controllerMap == null || elementMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => SgsCrLnAZOCNSlCWQBpDEEyihUqK(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => XTObzJsHUJgFSCRrSNZBWbKqqflEA(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => vCokRWWpNibwRvIVzgcVIzGPWVpN(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => RtETmkWFFRfUGBGdYpZhbolKPCGhb(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != LHIAvBhoXrmvJFUPgaCZasngBuqnb)
					{
						ReInput.CheckInitialized(LHIAvBhoXrmvJFUPgaCZasngBuqnb);
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return kbaHspEybmnCmbRMQMlGYsBWPxscb(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return FOUumRIVviaRlWuHXCYlTpLtTRlS(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return hcHypQmOztbXiybrvlPnGbsTNVPK(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return rLQcPNCDXWNoUfLdFzRRyAbMdizX(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				private bool MACUwkSqPsDDOdCvdLugDiavSaVP(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return false;
					}
					for (int i = 0; i < oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.tXrSkfcScZdadhIEmSRyjQoYKHYaA(); i++)
					{
						if (oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).jShzJcgXohXkJgAjbKdTzokqckTE.id == P_0 && cNZfPWOvLtlORlChCccGsKSCsnQi(ControllerType.Joystick, P_0, P_1, P_2, P_3, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).oNEqVoyniAQxhPXQGcMENGIkPfMg))
						{
							return true;
						}
					}
					return false;
				}

				private bool RoBvzhRCYuSomtjEnfzkTCXFjncG(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					for (int i = 0; i < oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.tXrSkfcScZdadhIEmSRyjQoYKHYaA(); i++)
					{
						if (oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).jShzJcgXohXkJgAjbKdTzokqckTE.id == P_0 && iVYoYOiFmVVYwwkWdRnlqyhUlYdQ(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).oNEqVoyniAQxhPXQGcMENGIkPfMg))
						{
							return true;
						}
					}
					return false;
				}

				private bool ioWkGQHdTkjmCZysBGAQANRCOOAF(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					for (int i = 0; i < oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.tXrSkfcScZdadhIEmSRyjQoYKHYaA(); i++)
					{
						if (oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).jShzJcgXohXkJgAjbKdTzokqckTE.id == P_0.controllerId && JhoNWZAgvZAujQsPCmUjBPgxzepo(P_0, P_1, P_2, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).oNEqVoyniAQxhPXQGcMENGIkPfMg))
						{
							return true;
						}
					}
					return false;
				}

				private bool csSHiCKjbCXhPfPFMVSihtLvfsjn(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return cNZfPWOvLtlORlChCccGsKSCsnQi(ControllerType.Keyboard, 0, P_0, P_1, P_2, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.eQuLUmKldncNSRwQykDfVdXjpNIX);
				}

				private bool CuXESaFMfLNbrIxSuhkRoMmCHgKvA(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return iVYoYOiFmVVYwwkWdRnlqyhUlYdQ(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.eQuLUmKldncNSRwQykDfVdXjpNIX);
				}

				private bool OoNLpNoWLXOKwwZHvhSzcaaDSIzt(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					return JhoNWZAgvZAujQsPCmUjBPgxzepo(P_0, P_1, P_2, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.eQuLUmKldncNSRwQykDfVdXjpNIX);
				}

				private bool uRxnmAsXoFpzyVWAtIxEmdmtTefv(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return cNZfPWOvLtlORlChCccGsKSCsnQi(ControllerType.Mouse, 0, P_0, P_1, P_2, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.FzbVyEOvvgfTkhXYXDFdoDEfmCxE);
				}

				private bool fwijJjenXvbVVqgeJvVbsoBJTFfM(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return iVYoYOiFmVVYwwkWdRnlqyhUlYdQ(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.FzbVyEOvvgfTkhXYXDFdoDEfmCxE);
				}

				private bool uAhIwHDrDrwhrzQsZGOsefwPNbaL(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					return JhoNWZAgvZAujQsPCmUjBPgxzepo(P_0, P_1, P_2, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.FzbVyEOvvgfTkhXYXDFdoDEfmCxE);
				}

				private bool LVmjbsCBjRGOBfrEwcqvwNjucZHW(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return false;
					}
					for (int i = 0; i < oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.tXrSkfcScZdadhIEmSRyjQoYKHYaA(); i++)
					{
						if (oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).jShzJcgXohXkJgAjbKdTzokqckTE.id == P_0 && cNZfPWOvLtlORlChCccGsKSCsnQi(ControllerType.Custom, P_0, P_1, P_2, P_3, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).oNEqVoyniAQxhPXQGcMENGIkPfMg))
						{
							return true;
						}
					}
					return false;
				}

				private bool zRdJItMeBTlvKLAywTfGJqeCkQaX(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					for (int i = 0; i < oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.tXrSkfcScZdadhIEmSRyjQoYKHYaA(); i++)
					{
						if (oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).jShzJcgXohXkJgAjbKdTzokqckTE.id == P_0 && iVYoYOiFmVVYwwkWdRnlqyhUlYdQ(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).oNEqVoyniAQxhPXQGcMENGIkPfMg))
						{
							return true;
						}
					}
					return false;
				}

				private bool GzZmAwaUdHAYXJmXsjkJUTewkdLt(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					for (int i = 0; i < oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.tXrSkfcScZdadhIEmSRyjQoYKHYaA(); i++)
					{
						if (oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).jShzJcgXohXkJgAjbKdTzokqckTE.id == P_0.controllerId && JhoNWZAgvZAujQsPCmUjBPgxzepo(P_0, P_1, P_2, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).oNEqVoyniAQxhPXQGcMENGIkPfMg))
						{
							return true;
						}
					}
					return false;
				}

				[IteratorStateMachine(typeof(ywTNMvHMBdtcxvReRNgtVLdfcqjr))]
				private IEnumerable<ElementAssignmentConflictInfo> JVVGZCcTajtgApeeatKlfVKHqiUfb(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return new ywTNMvHMBdtcxvReRNgtVLdfcqjr(-2)
					{
						roEBzqkciUAtfAPOiOgZPTHeAeau = this,
						BDmogXioQOdKfFlOgPFPBVzwhAWW = P_0,
						MaIWmufJWhzqIqctdfVugNTbpOBc = P_1,
						lUsTjuPxEHnqkFnFLPMTEwLdnFwo = P_2,
						qshUgNXjHeHWlONxHmilpQPxtWnR = P_3
					};
				}

				[IteratorStateMachine(typeof(iLjGhgfMkLRTSPwJWiSCSGvvmVvtA))]
				private IEnumerable<ElementAssignmentConflictInfo> izSvtpgJWqKCdmgteDdpawRbvnwvA(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					return new iLjGhgfMkLRTSPwJWiSCSGvvmVvtA(-2)
					{
						MiJvfvKffoFClirNTVmMweJumFpqA = this,
						treXlcuqCMVXHiZWPaKaAqxsftfbA = P_0,
						JgLFRYcJjJGgOlRQQsYmDraXRSjh = P_1,
						PHfgKIOEPkxXzVEJhlQreNLudKtIA = P_2,
						DyWJQpjYkWqMzkQSSxgTzHfgillF = P_3,
						ShgbPnUMnhuIXTtbctEmVWDciZLJ = P_4
					};
				}

				[IteratorStateMachine(typeof(vEZzYkESOCbXLfziVSXlWygpNJru))]
				private IEnumerable<ElementAssignmentConflictInfo> jMLBUbOmWwAqRyVLduZeKfNOaqJB(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					return new vEZzYkESOCbXLfziVSXlWygpNJru(-2)
					{
						piGvzNGSMlfHrHaFpMDABmYKuHFM = this,
						sNgHFlqjNoAFkqEIETnhnjkxeqHu = P_0,
						juufTShkOTSsTPuErQGZzmtLVHIS = P_1,
						uLXcruBBmjJbEYuYcjvYJfPHEETr = P_2
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> JQzKaUcyWCrVCSDeuOrKFuWeCVvL(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return BkahyuxuzBdgwXAIEhEREhbdekGFb(ControllerType.Keyboard, 0, P_0, P_1, P_2, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.eQuLUmKldncNSRwQykDfVdXjpNIX);
				}

				private IEnumerable<ElementAssignmentConflictInfo> LVMBRGcAbcjAafcGoipliBxEvrcfB(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return brzWRkOKAySfYuGWMdVCrDFfbTIEA(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.eQuLUmKldncNSRwQykDfVdXjpNIX);
				}

				private IEnumerable<ElementAssignmentConflictInfo> dncbqvvDGGKFHxEsicQLiaBdmeFz(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return EkHrwdNDPDFbHHONPuXdOmuqkCgqA(P_0, P_1, P_2, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.eQuLUmKldncNSRwQykDfVdXjpNIX);
				}

				private IEnumerable<ElementAssignmentConflictInfo> BSeCJnueAnKfGcdDubLfAUVlIgts(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return BkahyuxuzBdgwXAIEhEREhbdekGFb(ControllerType.Mouse, 0, P_0, P_1, P_2, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.FzbVyEOvvgfTkhXYXDFdoDEfmCxE);
				}

				private IEnumerable<ElementAssignmentConflictInfo> sDpIbgybrpTFeWRgbXCWQdTyrXgl(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return brzWRkOKAySfYuGWMdVCrDFfbTIEA(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.FzbVyEOvvgfTkhXYXDFdoDEfmCxE);
				}

				private IEnumerable<ElementAssignmentConflictInfo> IRsxatRnkcIZzSGohdrOxrxcIouF(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return EkHrwdNDPDFbHHONPuXdOmuqkCgqA(P_0, P_1, P_2, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.FzbVyEOvvgfTkhXYXDFdoDEfmCxE);
				}

				[IteratorStateMachine(typeof(WhCPDvpSEUSZxMsoXTNcGvIvgXCo))]
				private IEnumerable<ElementAssignmentConflictInfo> QLwGaZXXhuGAVkJWZEyVtdJztWTD(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return new WhCPDvpSEUSZxMsoXTNcGvIvgXCo(-2)
					{
						iULRcIAPISarKCTPMrCprRUXMungA = this,
						mQjaTAutvweDlIncJXJFbFiUsMqjA = P_0,
						RURrlCltMetytVPzWokVttnzSlXu = P_1,
						tYmWFmnvoLVLFYouosobqhdnadIEA = P_2,
						ajetXPyspFLRirLCuhwKAZEJeMjS = P_3
					};
				}

				[IteratorStateMachine(typeof(KKvEkxrvksWGVoDTXHpQukozxZBG))]
				private IEnumerable<ElementAssignmentConflictInfo> jzPZLccoCdhYKDaPofPzMcbDuINnA(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					return new KKvEkxrvksWGVoDTXHpQukozxZBG(-2)
					{
						PUjqImyeHWrpkhoKRjqkLBCNwkwl = this,
						LnXAFAJkNuqKdnCMnziPtqoJYcZJ = P_0,
						upkSjLGsKigQQuLUFGaVqqjSvcmW = P_1,
						yYBqPgKzKVUHyCwrVMpPYeRZwojP = P_2,
						kglyAOlIpzEnCJqTNldwCmkEGjbLc = P_3,
						vAHosrHGfZvEIJzHnKDSREfYghJG = P_4
					};
				}

				[IteratorStateMachine(typeof(UQItgdhtIihsnOLIbokwMlOYgPdp))]
				private IEnumerable<ElementAssignmentConflictInfo> atDXfvQkNSUptZjFcZETgpXrdHhq(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					return new UQItgdhtIihsnOLIbokwMlOYgPdp(-2)
					{
						GqRJIWeeLVBPwJkpkRXZAmzlFRBAA = this,
						fmPiwdQAHNgSKHmzZMpqcnshLOBxA = P_0,
						zjfGaFERpAHeQuNIeLuqoaMOBxHKA = P_1,
						cjlPOQlTgzmNHUgacsDocgIVbjvn = P_2
					};
				}

				private int eBlOtndErtNqxDyKWdDNpSeraPyj(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.tXrSkfcScZdadhIEmSRyjQoYKHYaA(); i++)
					{
						if (oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).jShzJcgXohXkJgAjbKdTzokqckTE.id == P_0)
						{
							num += kkbGwBwjoxdqaarRIWyiKHVVdCxkA(ControllerType.Joystick, P_0, P_1, P_2, P_3, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).oNEqVoyniAQxhPXQGcMENGIkPfMg);
						}
					}
					return num;
				}

				private int mtvQjGkTHjoBWFeVnANHAmEoQrZT(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.tXrSkfcScZdadhIEmSRyjQoYKHYaA(); i++)
					{
						if (oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).jShzJcgXohXkJgAjbKdTzokqckTE.id == P_0)
						{
							num += iVPrZqWcGmAcpuCujOqoTSgKnvAF(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).oNEqVoyniAQxhPXQGcMENGIkPfMg);
						}
					}
					return num;
				}

				private int TVgKEpXwiuUBpxHtOioLsKZMdPjIA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.tXrSkfcScZdadhIEmSRyjQoYKHYaA(); i++)
					{
						if (oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).jShzJcgXohXkJgAjbKdTzokqckTE.id == P_0.controllerId)
						{
							num += DvoAWSEoMDNHINHaheMEfESxSerd(P_0, P_1, P_2, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).oNEqVoyniAQxhPXQGcMENGIkPfMg);
						}
					}
					return num;
				}

				private int axIarEPVhzEPMCorictiaZtUMnXd(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return kkbGwBwjoxdqaarRIWyiKHVVdCxkA(ControllerType.Keyboard, 0, P_0, P_1, P_2, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.eQuLUmKldncNSRwQykDfVdXjpNIX);
				}

				private int NbjsKmHtrDqSrsOVBjOKqtOdqCwl(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return iVPrZqWcGmAcpuCujOqoTSgKnvAF(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.eQuLUmKldncNSRwQykDfVdXjpNIX);
				}

				private int RdCGdteXoSLWojQopRYyBsXbUdSVA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return DvoAWSEoMDNHINHaheMEfESxSerd(P_0, P_1, P_2, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.eQuLUmKldncNSRwQykDfVdXjpNIX);
				}

				private int gECxaaPyiTRRJUqvCHlhAqeqHTIi(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return kkbGwBwjoxdqaarRIWyiKHVVdCxkA(ControllerType.Mouse, 0, P_0, P_1, P_2, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.FzbVyEOvvgfTkhXYXDFdoDEfmCxE);
				}

				private int LcBkGbzTJRcdLKXyYQXOtqkOJmlm(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return iVPrZqWcGmAcpuCujOqoTSgKnvAF(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.FzbVyEOvvgfTkhXYXDFdoDEfmCxE);
				}

				private int GtDHlWiRFeocVciBtFgyzVbfmIZJ(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return DvoAWSEoMDNHINHaheMEfESxSerd(P_0, P_1, P_2, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.FzbVyEOvvgfTkhXYXDFdoDEfmCxE);
				}

				private int VHAGJUbHFvencuVdacinKmHsoTKs(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.tXrSkfcScZdadhIEmSRyjQoYKHYaA(); i++)
					{
						if (oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).jShzJcgXohXkJgAjbKdTzokqckTE.id == P_0)
						{
							num += kkbGwBwjoxdqaarRIWyiKHVVdCxkA(ControllerType.Custom, P_0, P_1, P_2, P_3, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).oNEqVoyniAQxhPXQGcMENGIkPfMg);
						}
					}
					return num;
				}

				private int ysnNVppywnVImoFdIGsRjMvDLdCC(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.tXrSkfcScZdadhIEmSRyjQoYKHYaA(); i++)
					{
						if (oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).jShzJcgXohXkJgAjbKdTzokqckTE.id == P_0)
						{
							num += iVPrZqWcGmAcpuCujOqoTSgKnvAF(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).oNEqVoyniAQxhPXQGcMENGIkPfMg);
						}
					}
					return num;
				}

				private int qtXfpTXdOigbSIFBZaWAAwHCVGFIc(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.tXrSkfcScZdadhIEmSRyjQoYKHYaA(); i++)
					{
						if (oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).jShzJcgXohXkJgAjbKdTzokqckTE.id == P_0.controllerId)
						{
							num += DvoAWSEoMDNHINHaheMEfESxSerd(P_0, P_1, P_2, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).oNEqVoyniAQxhPXQGcMENGIkPfMg);
						}
					}
					return num;
				}

				private int OiNJLDeBCaNrQZZPTjYCHUqfLsmp(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.tXrSkfcScZdadhIEmSRyjQoYKHYaA(); i++)
					{
						if (oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).jShzJcgXohXkJgAjbKdTzokqckTE.id == P_0)
						{
							num += YKGcjJJFrWfbJxzJPHQsMZHKguZLA(ControllerType.Joystick, P_0, P_1, P_2, P_3, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).oNEqVoyniAQxhPXQGcMENGIkPfMg, P_4);
						}
					}
					return num;
				}

				private int SgsCrLnAZOCNSlCWQBpDEEyihUqK(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, List<ActionElementMap> P_5 = null)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.tXrSkfcScZdadhIEmSRyjQoYKHYaA(); i++)
					{
						if (oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).jShzJcgXohXkJgAjbKdTzokqckTE.id == P_0)
						{
							num += JAAuBKEJJjNhLOIOtnyTWiNiEjdp(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).oNEqVoyniAQxhPXQGcMENGIkPfMg, P_5);
						}
					}
					return num;
				}

				private int kbaHspEybmnCmbRMQMlGYsBWPxscb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.tXrSkfcScZdadhIEmSRyjQoYKHYaA(); i++)
					{
						if (oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).jShzJcgXohXkJgAjbKdTzokqckTE.id == P_0.controllerId)
						{
							num += tUNAdVaCkFJWBfdAYwEiGrWVtRZB(P_0, P_1, P_2, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.nrlxRpyPglGccrqNtakOClEIBShgA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).oNEqVoyniAQxhPXQGcMENGIkPfMg, P_3);
						}
					}
					return num;
				}

				private int IZrTSZHYissJwxAnpaVFUHdNDdOx(KeyboardMap P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					return YKGcjJJFrWfbJxzJPHQsMZHKguZLA(ControllerType.Keyboard, 0, P_0, P_1, P_2, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.eQuLUmKldncNSRwQykDfVdXjpNIX, P_3);
				}

				private int XTObzJsHUJgFSCRrSNZBWbKqqflEA(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					return JAAuBKEJJjNhLOIOtnyTWiNiEjdp(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.eQuLUmKldncNSRwQykDfVdXjpNIX, P_4);
				}

				private int FOUumRIVviaRlWuHXCYlTpLtTRlS(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return tUNAdVaCkFJWBfdAYwEiGrWVtRZB(P_0, P_1, P_2, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.eQuLUmKldncNSRwQykDfVdXjpNIX, P_3);
				}

				private int VuaQPgSzMdojhmNkEeTAADQnekrBA(MouseMap P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					return YKGcjJJFrWfbJxzJPHQsMZHKguZLA(ControllerType.Mouse, 0, P_0, P_1, P_2, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.FzbVyEOvvgfTkhXYXDFdoDEfmCxE, P_3);
				}

				private int vCokRWWpNibwRvIVzgcVIzGPWVpN(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					return JAAuBKEJJjNhLOIOtnyTWiNiEjdp(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.FzbVyEOvvgfTkhXYXDFdoDEfmCxE, P_4);
				}

				private int hcHypQmOztbXiybrvlPnGbsTNVPK(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return tUNAdVaCkFJWBfdAYwEiGrWVtRZB(P_0, P_1, P_2, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.FzbVyEOvvgfTkhXYXDFdoDEfmCxE, P_3);
				}

				private int gXiAdjprgmIApHCAGyjcMUbhoglYA(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.tXrSkfcScZdadhIEmSRyjQoYKHYaA(); i++)
					{
						if (oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).jShzJcgXohXkJgAjbKdTzokqckTE.id == P_0)
						{
							num += YKGcjJJFrWfbJxzJPHQsMZHKguZLA(ControllerType.Custom, P_0, P_1, P_2, P_3, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).oNEqVoyniAQxhPXQGcMENGIkPfMg, P_4);
						}
					}
					return num;
				}

				private int RtETmkWFFRfUGBGdYpZhbolKPCGhb(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, List<ActionElementMap> P_5 = null)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.tXrSkfcScZdadhIEmSRyjQoYKHYaA(); i++)
					{
						if (oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).jShzJcgXohXkJgAjbKdTzokqckTE.id == P_0)
						{
							num += JAAuBKEJJjNhLOIOtnyTWiNiEjdp(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).oNEqVoyniAQxhPXQGcMENGIkPfMg, P_5);
						}
					}
					return num;
				}

				private int rLQcPNCDXWNoUfLdFzRRyAbMdizX(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.tXrSkfcScZdadhIEmSRyjQoYKHYaA(); i++)
					{
						if (oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).jShzJcgXohXkJgAjbKdTzokqckTE.id == P_0.controllerId)
						{
							num += tUNAdVaCkFJWBfdAYwEiGrWVtRZB(P_0, P_1, P_2, oEiBTKxSOMeZXgHvRqcHuOhQHDgwA.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i).oNEqVoyniAQxhPXQGcMENGIkPfMg, P_3);
						}
					}
					return num;
				}

				private bool cNZfPWOvLtlORlChCccGsKSCsnQi<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0001> P_5) where _0001 : ControllerMap
				{
					if (P_5 == null || P_2 == null)
					{
						return false;
					}
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_2.categoryId);
					if (mapCategory == null)
					{
						return false;
					}
					for (int i = 0; i < P_5.uwAUgkekzffIxggNtXkaazjLDUnI(); i++)
					{
						ControllerMap controllerMap = P_5.dqSBzdtORLozVFHTanNDwzTffYco(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !juUtjedcddFaMqLKagzresIfWVxH(mapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_2, P_3))
						{
							return true;
						}
					}
					return false;
				}

				private bool iVYoYOiFmVVYwwkWdRnlqyhUlYdQ<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0001> P_6) where _0001 : ControllerMap
				{
					if (P_6 == null || P_3 == null)
					{
						return false;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					for (int i = 0; i < P_6.uwAUgkekzffIxggNtXkaazjLDUnI(); i++)
					{
						ControllerMap controllerMap = P_6.dqSBzdtORLozVFHTanNDwzTffYco(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !juUtjedcddFaMqLKagzresIfWVxH(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool JhoNWZAgvZAujQsPCmUjBPgxzepo<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0001> P_3) where _0001 : ControllerMap
				{
					if (P_3 == null)
					{
						return false;
					}
					Player player = ReInput.players.GetPlayer(P_0.playerId);
					if (player == null)
					{
						return false;
					}
					ControllerMap map = player.controllers.maps.GetMap(P_0.controllerType, P_0.controllerId, P_0.controllerMapId);
					InputMapCategory inputMapCategory = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(P_0.controllerMapCategoryId));
					if (inputMapCategory == null)
					{
						return false;
					}
					for (int i = 0; i < P_3.uwAUgkekzffIxggNtXkaazjLDUnI(); i++)
					{
						ControllerMap controllerMap = P_3.dqSBzdtORLozVFHTanNDwzTffYco(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !juUtjedcddFaMqLKagzresIfWVxH(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_0, P_1))
						{
							return true;
						}
					}
					return false;
				}

				[IteratorStateMachine(typeof(bHuCiUGmxLZzLKvUeadzsLWOJiuz))]
				private IEnumerable<ElementAssignmentConflictInfo> BkahyuxuzBdgwXAIEhEREhbdekGFb<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0001> P_5) where _0001 : ControllerMap
				{
					return new bHuCiUGmxLZzLKvUeadzsLWOJiuz<_0001>(-2)
					{
						TXtZqQOlfkvjuygmrRKTxYkfbIIk = this,
						bMaoVfaGEhdcZKjsyRflqCesqtrw = P_0,
						KnfjkVIFvDYYcbDkEAeGEqfUqDSab = P_1,
						NeeGUrWZDRPJueDkbOEzezvHcuZV = P_2,
						qbQdtPwyAGUpdbLkJTZcUdHjDnqM = P_3,
						zpPqJRqvbKVLzbXWxXdJwgYCPktf = P_4,
						qHSauAFuybkjbNYXyKYUuKQLGCicA = P_5
					};
				}

				[IteratorStateMachine(typeof(IakafsqfHzHMcjmszSVSisFWMAScb))]
				private IEnumerable<ElementAssignmentConflictInfo> brzWRkOKAySfYuGWMdVCrDFfbTIEA<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0001> P_6) where _0001 : ControllerMap
				{
					return new IakafsqfHzHMcjmszSVSisFWMAScb<_0001>(-2)
					{
						edMHhKHVCTODPTqKShMEzbkXQEEpA = this,
						soRCntyfunrbaQGPmpgZxBHfqKay = P_0,
						seotJQJNrIdQDMBVOxCFOxCNlkxt = P_1,
						VWZFFznKhdTWViDmrvgMwYEDYzhG = P_2,
						NCLycBEgRGFgOWBUXBJbGfjgmULNA = P_3,
						xTjkCnolvbvwCRGhwPhzjGmWLxJo = P_4,
						YuFXAZnURXJPcMJWOXvvkmzVaVoA = P_5,
						EEnFvMEEHrzKKmRjDVwGjdMqNDsfb = P_6
					};
				}

				[IteratorStateMachine(typeof(rVwaFKdbQKTRtNVSrqQJavlhHpgPc))]
				private IEnumerable<ElementAssignmentConflictInfo> EkHrwdNDPDFbHHONPuXdOmuqkCgqA<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0001> P_3) where _0001 : ControllerMap
				{
					return new rVwaFKdbQKTRtNVSrqQJavlhHpgPc<_0001>(-2)
					{
						xelXfDXShRFnmkScFPReCdigCEkkA = this,
						AiOiwgvPQkFbjhxGFjyZZADnFGqr = P_0,
						duTGtrFlBXxefMYZhVXbwPFJhLmj = P_1,
						JSNBMTDSYnJmfNMWsOQTMepAiFgm = P_2,
						OuFalqIZQxtxYVIvWUfNFTyuheZP = P_3
					};
				}

				private int kkbGwBwjoxdqaarRIWyiKHVVdCxkA<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0001> P_5) where _0001 : ControllerMap
				{
					if (P_5 == null || P_2 == null)
					{
						return 0;
					}
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_2.categoryId);
					if (mapCategory == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_5.uwAUgkekzffIxggNtXkaazjLDUnI(); i++)
					{
						ControllerMap controllerMap = P_5.dqSBzdtORLozVFHTanNDwzTffYco(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !juUtjedcddFaMqLKagzresIfWVxH(mapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_2, P_3);
						}
					}
					return num;
				}

				private int iVPrZqWcGmAcpuCujOqoTSgKnvAF<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0001> P_6) where _0001 : ControllerMap
				{
					if (P_6 == null || P_3 == null)
					{
						return 0;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					int num = 0;
					for (int i = 0; i < P_6.uwAUgkekzffIxggNtXkaazjLDUnI(); i++)
					{
						ControllerMap controllerMap = P_6.dqSBzdtORLozVFHTanNDwzTffYco(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !juUtjedcddFaMqLKagzresIfWVxH(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_3, P_4);
						}
					}
					return num;
				}

				private int DvoAWSEoMDNHINHaheMEfESxSerd<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0001> P_3) where _0001 : ControllerMap
				{
					if (P_3 == null)
					{
						return 0;
					}
					Player player = ReInput.players.GetPlayer(P_0.playerId);
					if (player == null)
					{
						return 0;
					}
					ControllerMap map = player.controllers.maps.GetMap(P_0.controllerType, P_0.controllerId, P_0.controllerMapId);
					InputMapCategory inputMapCategory = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(P_0.controllerMapCategoryId));
					if (inputMapCategory == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_3.uwAUgkekzffIxggNtXkaazjLDUnI(); i++)
					{
						ControllerMap controllerMap = P_3.dqSBzdtORLozVFHTanNDwzTffYco(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !juUtjedcddFaMqLKagzresIfWVxH(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_0, P_1);
						}
					}
					return num;
				}

				private int YKGcjJJFrWfbJxzJPHQsMZHKguZLA<_0001>(ControllerType P_0, int P_1, _0001 P_2, bool P_3, bool P_4, global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0001> P_5, List<ActionElementMap> P_6 = null) where _0001 : ControllerMap
				{
					P_6?.Clear();
					if (P_5 == null || P_2 == null)
					{
						return 0;
					}
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_2.categoryId);
					if (mapCategory == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_5.uwAUgkekzffIxggNtXkaazjLDUnI(); i++)
					{
						ControllerMap controllerMap = P_5.dqSBzdtORLozVFHTanNDwzTffYco(i);
						if ((!P_3 || controllerMap.enabled) && (P_4 || !juUtjedcddFaMqLKagzresIfWVxH(mapCategory, controllerMap)))
						{
							num += controllerMap.SJDSKtDjzvpmHSjUMqbaQhsuKinu(P_2, P_3, P_6, true);
						}
					}
					return num;
				}

				private int JAAuBKEJJjNhLOIOtnyTWiNiEjdp<_0001>(ControllerType P_0, int P_1, _0001 P_2, ActionElementMap P_3, bool P_4, bool P_5, global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0001> P_6, List<ActionElementMap> P_7 = null) where _0001 : ControllerMap
				{
					P_7?.Clear();
					if (P_6 == null || P_3 == null)
					{
						return 0;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					int num = 0;
					for (int i = 0; i < P_6.uwAUgkekzffIxggNtXkaazjLDUnI(); i++)
					{
						ControllerMap controllerMap = P_6.dqSBzdtORLozVFHTanNDwzTffYco(i);
						if ((!P_4 || controllerMap.enabled) && (P_5 || !juUtjedcddFaMqLKagzresIfWVxH(inputMapCategory, controllerMap)))
						{
							num += controllerMap.ENwaWcDXgcpQoycGjOSWKYNmEVtP(P_3, P_4, P_7, true);
						}
					}
					return num;
				}

				private int tUNAdVaCkFJWBfdAYwEiGrWVtRZB<_0001>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0001> P_3, List<ActionElementMap> P_4 = null) where _0001 : ControllerMap
				{
					P_4?.Clear();
					if (P_3 == null)
					{
						return 0;
					}
					Player player = ReInput.players.GetPlayer(P_0.playerId);
					if (player == null)
					{
						return 0;
					}
					ControllerMap map = player.controllers.maps.GetMap(P_0.controllerType, P_0.controllerId, P_0.controllerMapId);
					InputMapCategory inputMapCategory = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(P_0.controllerMapCategoryId));
					if (inputMapCategory == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_3.uwAUgkekzffIxggNtXkaazjLDUnI(); i++)
					{
						ControllerMap controllerMap = P_3.dqSBzdtORLozVFHTanNDwzTffYco(i);
						if ((!P_1 || controllerMap.enabled) && (P_2 || !juUtjedcddFaMqLKagzresIfWVxH(inputMapCategory, controllerMap)))
						{
							num += controllerMap.mVGdaCFqXulnKnVLNgZpLfBpQtJL(P_0, P_1, P_4, true);
						}
					}
					return num;
				}

				private bool juUtjedcddFaMqLKagzresIfWVxH(InputMapCategory P_0, ControllerMap P_1)
				{
					if (P_0 == null || P_1 == null)
					{
						return false;
					}
					if (P_0.checkConflictsWithAllCategories)
					{
						return false;
					}
					IList<int> checkConflictsCategoryIds = P_0.checkConflictsCategoryIds;
					if (checkConflictsCategoryIds == null)
					{
						return true;
					}
					for (int i = 0; i < checkConflictsCategoryIds.Count; i++)
					{
						if (checkConflictsCategoryIds[i] == P_1.categoryId)
						{
							return false;
						}
					}
					return true;
				}
			}

			[DefaultMember("Item")]
			internal interface FcTbzUBLOriYHtrisAslcxMVjwzbA
			{
				KtryiWwbdBImLIPzGurzVKouGTieb QtRYrSkOXNhzBhmUIwCpfXmcijQk { get; }

				ControllerType mbfHDcGTnKKwgQEZclBXulCaqXzkA { get; }

				int RkJWsNlHTmrNlRDEKklNpYTEPhDh { get; }

				bool eyMHgHVWrIISKfSESSumlCPPcflM(Controller P_0);

				bool wDYbJNEdgGiSlUtXLVsemvtiInIn(int P_0);

				void NToHCxKAspbjVweMWxbRxHZUYrGm(int P_0);

				void KZgBXnMXFmFJzcIlFNpBSgigMKCK(Controller P_0);

				void uiEBAYIuBvXSDbulMPCgHWCxYYoV(int P_0);

				Controller LcbdObQweMOzvtgfAlLZhYKcFOOx(int P_0);

				Controller WdqAVQEwSPpsdOjbRVGLNSOcKcqS(string P_0);

				int wsJyfeGQGUgtKCPPMnqclVZcaMpzA(Controller P_0);

				int ZFBzTFwswXrvsclNBdTpeSiMzSsH(int P_0);

				int vwPWTIMUciAhVrbQvIhVXyQpkWHq(string P_0);

				void SUZiPCaLTTKwDqgQsUcDNKprsUQB();

				KtryiWwbdBImLIPzGurzVKouGTieb YacHzxfeOlVQUomSEcSTDHYQttOQA(int P_0);

				KtryiWwbdBImLIPzGurzVKouGTieb xikRtqzHNsOgfdlwxRoZWZxEUFqw(Controller P_0);

				void yjcdZxDsJoGYywkOEcTxeUbsRGdLA(KtryiWwbdBImLIPzGurzVKouGTieb P_0);
			}

			internal interface KtryiWwbdBImLIPzGurzVKouGTieb
			{
				PQaFgQVynoEJfalLJXDCcVZTEKyx ahBHvaaFKqjYqOJIXAFDIKodzptCA { get; }

				Controller zrbrkQliupAqJogtCsiVGfsiiisW { get; }

				double oEAAsWXyTImdfNewNOlMQToOqqnd { get; }
			}

			[DefaultMember("Item")]
			internal sealed class BugNwVeIKhVzIDUOvQkABeSlylki<_0001, _0002> : FcTbzUBLOriYHtrisAslcxMVjwzbA where _0001 : Controller where _0002 : ControllerMap
			{
				public class QZjxExmeBWRuJGYTHbiqqUqGIllt : KtryiWwbdBImLIPzGurzVKouGTieb
				{
					public _0001 jShzJcgXohXkJgAjbKdTzokqckTE;

					public global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0002> oNEqVoyniAQxhPXQGcMENGIkPfMg;

					public double lUXIlsZdrAIjNzaveEnDFTlFbEBJ;

					Controller KtryiWwbdBImLIPzGurzVKouGTieb.vZHSfbTDzMoygCVsYPZcDqlTlho => jShzJcgXohXkJgAjbKdTzokqckTE;

					PQaFgQVynoEJfalLJXDCcVZTEKyx KtryiWwbdBImLIPzGurzVKouGTieb.oiMFgSpnRtTNUyBdcAOijvQIIpQaA => oNEqVoyniAQxhPXQGcMENGIkPfMg;

					double KtryiWwbdBImLIPzGurzVKouGTieb.ayefBgKtHGOWjrfZLVrYSpgvpqXxA => lUXIlsZdrAIjNzaveEnDFTlFbEBJ;

					public QZjxExmeBWRuJGYTHbiqqUqGIllt(_0001 P_0, global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0002> P_1)
					{
						jShzJcgXohXkJgAjbKdTzokqckTE = P_0;
						oNEqVoyniAQxhPXQGcMENGIkPfMg = P_1;
					}

					public void QpqLMCANEqkpFoWzTArgxdzSKocd()
					{
						lUXIlsZdrAIjNzaveEnDFTlFbEBJ = ReInput.unscaledTime;
					}
				}

				private List<QZjxExmeBWRuJGYTHbiqqUqGIllt> YGwPMQYRCWRLcrQSJAQlBstvIsimA;

				private List<_0001> eagAnhpCpPaQqbcdQyiAbARMMHkk;

				private ReadOnlyCollection<_0001> mbBQTqsmDjjBTYccSmBkFHPHiURbA;

				private readonly ControllerType LVjUPYPPmkwtaOxPrmMAqqowjtfj;

				int FcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh => YGwPMQYRCWRLcrQSJAQlBstvIsimA.Count;

				public IList<_0001> xMPzVHlWLmYQdGOQbmSeMmfOpemj => mbBQTqsmDjjBTYccSmBkFHPHiURbA;

				public QZjxExmeBWRuJGYTHbiqqUqGIllt RHQEODBwnApcHmzBxYpaGvmZfnAU => YGwPMQYRCWRLcrQSJAQlBstvIsimA[P_0];

				ControllerType FcTbzUBLOriYHtrisAslcxMVjwzbA.mbfHDcGTnKKwgQEZclBXulCaqXzkA => LVjUPYPPmkwtaOxPrmMAqqowjtfj;

				KtryiWwbdBImLIPzGurzVKouGTieb FcTbzUBLOriYHtrisAslcxMVjwzbA.BYpmmxYGadymftHUYdBxjuMuNREFb => YGwPMQYRCWRLcrQSJAQlBstvIsimA[index];

				public BugNwVeIKhVzIDUOvQkABeSlylki()
				{
					if ((object)GHPcAvLGyrhUIIuLWeQoyFTYgunBA.oTcaUziKMEEoCeZlCRihHXAogDQab<_0001>() != typeof(_0002))
					{
						throw new Exception(typeof(_0001).Name + " cannot be used with a map of type " + typeof(_0002).Name);
					}
					LVjUPYPPmkwtaOxPrmMAqqowjtfj = GHPcAvLGyrhUIIuLWeQoyFTYgunBA.vbedocIRTmjtTKQwvrJkKsiINImLA(typeof(_0001));
					YGwPMQYRCWRLcrQSJAQlBstvIsimA = new List<QZjxExmeBWRuJGYTHbiqqUqGIllt>();
					eagAnhpCpPaQqbcdQyiAbARMMHkk = new List<_0001>();
					mbBQTqsmDjjBTYccSmBkFHPHiURbA = new ReadOnlyCollection<_0001>(eagAnhpCpPaQqbcdQyiAbARMMHkk);
				}

				public QZjxExmeBWRuJGYTHbiqqUqGIllt BxbbQhaHqnNxUSNGXTQDLaBDaANl(int P_0)
				{
					if (LVjUPYPPmkwtaOxPrmMAqqowjtfj == ControllerType.Keyboard || LVjUPYPPmkwtaOxPrmMAqqowjtfj == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					int num = TkjKWNjmiTXxrUmrSspDKhKKaDzQ(P_0);
					if (num < 0)
					{
						return null;
					}
					return YGwPMQYRCWRLcrQSJAQlBstvIsimA[num];
				}

				public QZjxExmeBWRuJGYTHbiqqUqGIllt rPlpEepMMjFKzKeklSLnajwTkDpy(_0001 P_0)
				{
					if (P_0 == null)
					{
						return null;
					}
					return BxbbQhaHqnNxUSNGXTQDLaBDaANl(P_0.id);
				}

				public void lTbsqncCnRTrlDjHjPwlZIjVVVOA(QZjxExmeBWRuJGYTHbiqqUqGIllt P_0)
				{
					if (P_0 != null)
					{
						YGwPMQYRCWRLcrQSJAQlBstvIsimA.Add(P_0);
						eagAnhpCpPaQqbcdQyiAbARMMHkk.Add(P_0.jShzJcgXohXkJgAjbKdTzokqckTE);
					}
				}

				public void rXwerxxWsUXQVZkriANkAkzTubgoA(int P_0)
				{
					if (LVjUPYPPmkwtaOxPrmMAqqowjtfj == ControllerType.Keyboard || LVjUPYPPmkwtaOxPrmMAqqowjtfj == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (TkjKWNjmiTXxrUmrSspDKhKKaDzQ(P_0) < 0)
					{
						return;
					}
					for (int i = 0; i < YGwPMQYRCWRLcrQSJAQlBstvIsimA.Count; i++)
					{
						if (YGwPMQYRCWRLcrQSJAQlBstvIsimA[i].jShzJcgXohXkJgAjbKdTzokqckTE.id == P_0)
						{
							UoIGNoyqqpHFXTkNQImJZiNgcAVR(i);
							break;
						}
					}
				}

				void FcTbzUBLOriYHtrisAslcxMVjwzbA.NToHCxKAspbjVweMWxbRxHZUYrGm(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in rXwerxxWsUXQVZkriANkAkzTubgoA
					this.rXwerxxWsUXQVZkriANkAkzTubgoA(P_0);
				}

				public void ewZbGAjLXKUZbTLjDgRCfyzcSZwXb(_0001 P_0)
				{
					if (P_0 != null && P_0.type == LVjUPYPPmkwtaOxPrmMAqqowjtfj)
					{
						rXwerxxWsUXQVZkriANkAkzTubgoA(P_0.id);
					}
				}

				public void UoIGNoyqqpHFXTkNQImJZiNgcAVR(int P_0)
				{
					if (P_0 >= 0 && P_0 < YGwPMQYRCWRLcrQSJAQlBstvIsimA.Count)
					{
						YGwPMQYRCWRLcrQSJAQlBstvIsimA.RemoveAt(P_0);
						eagAnhpCpPaQqbcdQyiAbARMMHkk.RemoveAt(P_0);
					}
				}

				void FcTbzUBLOriYHtrisAslcxMVjwzbA.uiEBAYIuBvXSDbulMPCgHWCxYYoV(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in UoIGNoyqqpHFXTkNQImJZiNgcAVR
					this.UoIGNoyqqpHFXTkNQImJZiNgcAVR(P_0);
				}

				public _0001 QPbwEzurbQskXsrZQCvuwTpGtHyA(int P_0)
				{
					if (LVjUPYPPmkwtaOxPrmMAqqowjtfj == ControllerType.Keyboard || LVjUPYPPmkwtaOxPrmMAqqowjtfj == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					int num = TkjKWNjmiTXxrUmrSspDKhKKaDzQ(P_0);
					if (num < 0)
					{
						return null;
					}
					return YGwPMQYRCWRLcrQSJAQlBstvIsimA[num].jShzJcgXohXkJgAjbKdTzokqckTE;
				}

				public bool nzOCAtaoZvyKKQCAVxPZiCXFBplVA(int P_0)
				{
					if (LVjUPYPPmkwtaOxPrmMAqqowjtfj == ControllerType.Keyboard || LVjUPYPPmkwtaOxPrmMAqqowjtfj == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (P_0 < 0)
					{
						return false;
					}
					for (int i = 0; i < YGwPMQYRCWRLcrQSJAQlBstvIsimA.Count; i++)
					{
						if (YGwPMQYRCWRLcrQSJAQlBstvIsimA[i].jShzJcgXohXkJgAjbKdTzokqckTE.id == P_0)
						{
							return true;
						}
					}
					return false;
				}

				bool FcTbzUBLOriYHtrisAslcxMVjwzbA.wDYbJNEdgGiSlUtXLVsemvtiInIn(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in nzOCAtaoZvyKKQCAVxPZiCXFBplVA
					return this.nzOCAtaoZvyKKQCAVxPZiCXFBplVA(P_0);
				}

				public bool TbyGsNjoHqvyDJqIgSVhkzyCBucB(_0001 P_0)
				{
					if (P_0 == null)
					{
						return false;
					}
					if (P_0.type != LVjUPYPPmkwtaOxPrmMAqqowjtfj)
					{
						return false;
					}
					return nzOCAtaoZvyKKQCAVxPZiCXFBplVA(P_0.id);
				}

				public int TkjKWNjmiTXxrUmrSspDKhKKaDzQ(int P_0)
				{
					if (LVjUPYPPmkwtaOxPrmMAqqowjtfj == ControllerType.Keyboard || LVjUPYPPmkwtaOxPrmMAqqowjtfj == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (P_0 < 0)
					{
						return -1;
					}
					for (int i = 0; i < YGwPMQYRCWRLcrQSJAQlBstvIsimA.Count; i++)
					{
						if (YGwPMQYRCWRLcrQSJAQlBstvIsimA[i].jShzJcgXohXkJgAjbKdTzokqckTE.id == P_0)
						{
							return i;
						}
					}
					return -1;
				}

				int FcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in TkjKWNjmiTXxrUmrSspDKhKKaDzQ
					return this.TkjKWNjmiTXxrUmrSspDKhKKaDzQ(P_0);
				}

				public int tuQfuJcnLeahImYFXOKvJKsuBjvO(_0001 P_0)
				{
					if (P_0 == null)
					{
						return -1;
					}
					if (P_0.type != LVjUPYPPmkwtaOxPrmMAqqowjtfj)
					{
						return -1;
					}
					return TkjKWNjmiTXxrUmrSspDKhKKaDzQ(P_0.id);
				}

				public int sTmXdwEFhEmGuuVlsHVPSFwuLhTQ(string P_0)
				{
					if (P_0 == null || P_0 == string.Empty)
					{
						return -1;
					}
					for (int i = 0; i < YGwPMQYRCWRLcrQSJAQlBstvIsimA.Count; i++)
					{
						if (YGwPMQYRCWRLcrQSJAQlBstvIsimA[i].jShzJcgXohXkJgAjbKdTzokqckTE.tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				int FcTbzUBLOriYHtrisAslcxMVjwzbA.vwPWTIMUciAhVrbQvIhVXyQpkWHq(string P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in sTmXdwEFhEmGuuVlsHVPSFwuLhTQ
					return this.sTmXdwEFhEmGuuVlsHVPSFwuLhTQ(P_0);
				}

				public void rPFawZfBtKjJEGbkhDjwAzTwSqfNb()
				{
					YGwPMQYRCWRLcrQSJAQlBstvIsimA.Clear();
					eagAnhpCpPaQqbcdQyiAbARMMHkk.Clear();
				}

				void FcTbzUBLOriYHtrisAslcxMVjwzbA.SUZiPCaLTTKwDqgQsUcDNKprsUQB()
				{
					//ILSpy generated this explicit interface implementation from .override directive in rPFawZfBtKjJEGbkhDjwAzTwSqfNb
					this.rPFawZfBtKjJEGbkhDjwAzTwSqfNb();
				}

				KtryiWwbdBImLIPzGurzVKouGTieb FcTbzUBLOriYHtrisAslcxMVjwzbA.GetEntry(int controllerId)
				{
					return BxbbQhaHqnNxUSNGXTQDLaBDaANl(controllerId);
				}

				KtryiWwbdBImLIPzGurzVKouGTieb FcTbzUBLOriYHtrisAslcxMVjwzbA.GetEntry(Controller controller)
				{
					if (controller as _0001 == null)
					{
						return null;
					}
					return rPlpEepMMjFKzKeklSLnajwTkDpy(controller as _0001);
				}

				void FcTbzUBLOriYHtrisAslcxMVjwzbA.AddEntry(KtryiWwbdBImLIPzGurzVKouGTieb entry)
				{
					lTbsqncCnRTrlDjHjPwlZIjVVVOA((QZjxExmeBWRuJGYTHbiqqUqGIllt)entry);
				}

				void FcTbzUBLOriYHtrisAslcxMVjwzbA.RemoveController(Controller controller)
				{
					ewZbGAjLXKUZbTLjDgRCfyzcSZwXb(controller as _0001);
				}

				Controller FcTbzUBLOriYHtrisAslcxMVjwzbA.GetController(int controllerId)
				{
					return QPbwEzurbQskXsrZQCvuwTpGtHyA(controllerId);
				}

				bool FcTbzUBLOriYHtrisAslcxMVjwzbA.Contains(Controller controller)
				{
					return TbyGsNjoHqvyDJqIgSVhkzyCBucB(controller as _0001);
				}

				int FcTbzUBLOriYHtrisAslcxMVjwzbA.IndexOf(Controller controller)
				{
					return tuQfuJcnLeahImYFXOKvJKsuBjvO(controller as _0001);
				}

				Controller FcTbzUBLOriYHtrisAslcxMVjwzbA.GetControllerWithTag(string tag)
				{
					int num = sTmXdwEFhEmGuuVlsHVPSFwuLhTQ(tag);
					if (num < 0)
					{
						return null;
					}
					return YGwPMQYRCWRLcrQSJAQlBstvIsimA[num].jShzJcgXohXkJgAjbKdTzokqckTE;
				}
			}

			internal class NgGecrMhKOkBnKfvwcKnhrEwErRtA
			{
				public readonly int EWwWlDdWcqJQmgAiLeFBWdVumGMb;

				private ControllerType[] cgWttDbhCjPaJHeXZeJGcWYMOPckA;

				private FcTbzUBLOriYHtrisAslcxMVjwzbA[] pMrDMKJhCelvbCSQjeGBJHwQuMNJc;

				public FcTbzUBLOriYHtrisAslcxMVjwzbA YPeyRKgKWPSqEsMokJyVccifhDpb(int P_0)
				{
					return pMrDMKJhCelvbCSQjeGBJHwQuMNJc[P_0];
				}

				public ControllerType VJVCoQkCdAkunrOcVfvCSHrGWrFxA(int P_0)
				{
					return cgWttDbhCjPaJHeXZeJGcWYMOPckA[P_0];
				}

				public NgGecrMhKOkBnKfvwcKnhrEwErRtA(int P_0)
				{
					EWwWlDdWcqJQmgAiLeFBWdVumGMb = MathTools.Max(0, P_0);
					cgWttDbhCjPaJHeXZeJGcWYMOPckA = new ControllerType[P_0];
					pMrDMKJhCelvbCSQjeGBJHwQuMNJc = new FcTbzUBLOriYHtrisAslcxMVjwzbA[P_0];
				}

				public FcTbzUBLOriYHtrisAslcxMVjwzbA KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType P_0)
				{
					for (int i = 0; i < EWwWlDdWcqJQmgAiLeFBWdVumGMb; i++)
					{
						if (P_0 == cgWttDbhCjPaJHeXZeJGcWYMOPckA[i])
						{
							return pMrDMKJhCelvbCSQjeGBJHwQuMNJc[i];
						}
					}
					throw new Exception("Value is not in the set.");
				}

				public void wzIflOjNECtRtWMEtoqHKCaIyqPr(int P_0, ControllerType P_1, FcTbzUBLOriYHtrisAslcxMVjwzbA P_2)
				{
					cgWttDbhCjPaJHeXZeJGcWYMOPckA[P_0] = P_1;
					pMrDMKJhCelvbCSQjeGBJHwQuMNJc[P_0] = P_2;
				}
			}

			private class MXjbWOahTaUnsydvZFHZuVPKnVfY
			{
				public class eraNxtfKkmuEkUJzwpIOdRgDJgEv
				{
					public int MalOZSpmjsjpjhaiChLLtGzJtbjl;

					public global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<JoystickMap> tffAjZGjLYRcEzyFuVdRAndjKqRQ;

					public double AxTAnxEQvRPkzjeGKjMYlJyBEGmvB;

					public eraNxtfKkmuEkUJzwpIOdRgDJgEv(int P_0, global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<JoystickMap> P_1, double P_2)
					{
						MalOZSpmjsjpjhaiChLLtGzJtbjl = P_0;
						tffAjZGjLYRcEzyFuVdRAndjKqRQ = P_1;
						AxTAnxEQvRPkzjeGKjMYlJyBEGmvB = P_2;
					}
				}

				private readonly List<eraNxtfKkmuEkUJzwpIOdRgDJgEv> BeCgAASgqIFPnipcqPtZXcAtBfZR;

				private readonly Player wheqWfaKcxqcdumGTHuQHtKEhRxX;

				public MXjbWOahTaUnsydvZFHZuVPKnVfY(Player P_0)
				{
					wheqWfaKcxqcdumGTHuQHtKEhRxX = P_0;
					BeCgAASgqIFPnipcqPtZXcAtBfZR = new List<eraNxtfKkmuEkUJzwpIOdRgDJgEv>();
				}

				public void aiZdAeAOoyJNvKivFtcqNaFpDdCe(Joystick P_0, global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<JoystickMap> P_1)
				{
					for (int i = 0; i < BeCgAASgqIFPnipcqPtZXcAtBfZR.Count; i++)
					{
						eraNxtfKkmuEkUJzwpIOdRgDJgEv eraNxtfKkmuEkUJzwpIOdRgDJgEv2 = BeCgAASgqIFPnipcqPtZXcAtBfZR[i];
						if (eraNxtfKkmuEkUJzwpIOdRgDJgEv2.MalOZSpmjsjpjhaiChLLtGzJtbjl == P_0.id)
						{
							eraNxtfKkmuEkUJzwpIOdRgDJgEv2.tffAjZGjLYRcEzyFuVdRAndjKqRQ = P_1;
							eraNxtfKkmuEkUJzwpIOdRgDJgEv2.AxTAnxEQvRPkzjeGKjMYlJyBEGmvB = ReInput.realTime;
							return;
						}
					}
					eraNxtfKkmuEkUJzwpIOdRgDJgEv item = new eraNxtfKkmuEkUJzwpIOdRgDJgEv(P_0.id, P_1, ReInput.realTime);
					BeCgAASgqIFPnipcqPtZXcAtBfZR.Add(item);
				}

				public void ubabJkSidYKCyvvsdtISFejQjgYh(BugNwVeIKhVzIDUOvQkABeSlylki<Joystick, JoystickMap>.QZjxExmeBWRuJGYTHbiqqUqGIllt P_0)
				{
					aiZdAeAOoyJNvKivFtcqNaFpDdCe(P_0.jShzJcgXohXkJgAjbKdTzokqckTE, P_0.oNEqVoyniAQxhPXQGcMENGIkPfMg);
				}

				public void oaaMVQRLSWarnnVtuOwBsvgOfkTO()
				{
					for (int i = 0; i < BeCgAASgqIFPnipcqPtZXcAtBfZR.Count; i++)
					{
						if (!wheqWfaKcxqcdumGTHuQHtKEhRxX.controllers.ContainsController(ControllerType.Joystick, BeCgAASgqIFPnipcqPtZXcAtBfZR[i].MalOZSpmjsjpjhaiChLLtGzJtbjl))
						{
							BeCgAASgqIFPnipcqPtZXcAtBfZR[i].tffAjZGjLYRcEzyFuVdRAndjKqRQ = null;
						}
					}
				}

				public eraNxtfKkmuEkUJzwpIOdRgDJgEv vdMYiqdQrjusRyVLELfGGDftLHdp(int P_0)
				{
					int num = wGUHiCzDQdLujveOwwEDVuXgQuIl(P_0);
					if (num < 0)
					{
						return null;
					}
					return BeCgAASgqIFPnipcqPtZXcAtBfZR[num];
				}

				public bool FMvLDPsZVXiryVCQbNypdVmJlrMx(int P_0)
				{
					for (int i = 0; i < BeCgAASgqIFPnipcqPtZXcAtBfZR.Count; i++)
					{
						if (BeCgAASgqIFPnipcqPtZXcAtBfZR[i].MalOZSpmjsjpjhaiChLLtGzJtbjl == P_0)
						{
							return true;
						}
					}
					return false;
				}

				public int wGUHiCzDQdLujveOwwEDVuXgQuIl(int P_0)
				{
					for (int i = 0; i < BeCgAASgqIFPnipcqPtZXcAtBfZR.Count; i++)
					{
						if (BeCgAASgqIFPnipcqPtZXcAtBfZR[i].MalOZSpmjsjpjhaiChLLtGzJtbjl == P_0)
						{
							return i;
						}
					}
					return -1;
				}

				public void qhQBUNfBHvqmTHVNUKHWpFvQhGMDb()
				{
					BeCgAASgqIFPnipcqPtZXcAtBfZR.Clear();
				}
			}

			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class MapHelper : CodeHelper
			{
				private sealed class lRKFPzAsTZCKcqrEnlLyAPxEnYsk : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int UdrGWjbrCwKZmFZTyFeeMTYIdDSL;

					private ActionElementMap kXlTEzoULoHpdfEnmDPSuccyDWbe;

					private int jJTaxQYOlCSRlDaDZqpGkGVzcpfN;

					public MapHelper bcaOPuxDmuUKkJRXJWiSPFWSIKN;

					private int vWVvGMbgxXdYpcHDWHWLiRiFeYrM;

					public int ZlOnTKacwnhSIuYPfdQsozQIpPDo;

					private bool NZffclKcEeQUMqTyyyxkNHlufIXS;

					public bool vhnakjTUAbOcktswwbsuWARrSvOK;

					private int LkXRsfZiEKnlspfNmRDJRYNKBXTV;

					private int MqvrATAQnDckWhpFeNjgcgKLseCjA;

					private FcTbzUBLOriYHtrisAslcxMVjwzbA keKOIkvUeYbykNshgjWXpvtYsVhJ;

					private int nqhNtJQCmEQzIjBQGxvaoHaiIwZx;

					private int ZYNLQMXLaOIYZqkfbiOWhQYuqtbUA;

					private PQaFgQVynoEJfalLJXDCcVZTEKyx LaQNhWAhcgxAjulxphqcAJRLEIIi;

					private int xDrJsKKmSUSKUSqYJciPwyZkgYlD;

					private int bZNeksCpHhnZYaFOJRaZeWIKPBgCc;

					private IEnumerator<ActionElementMap> mmCPZWXnKmiDZZhtShXdYWUvSazN;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return kXlTEzoULoHpdfEnmDPSuccyDWbe;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return kXlTEzoULoHpdfEnmDPSuccyDWbe;
						}
					}

					[DebuggerHidden]
					public lRKFPzAsTZCKcqrEnlLyAPxEnYsk(int P_0)
					{
						UdrGWjbrCwKZmFZTyFeeMTYIdDSL = P_0;
						jJTaxQYOlCSRlDaDZqpGkGVzcpfN = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int udrGWjbrCwKZmFZTyFeeMTYIdDSL = UdrGWjbrCwKZmFZTyFeeMTYIdDSL;
						if (udrGWjbrCwKZmFZTyFeeMTYIdDSL == -3 || udrGWjbrCwKZmFZTyFeeMTYIdDSL == 1)
						{
							try
							{
							}
							finally
							{
								HdpDloWXqBqrKXKacVfYafDvayZg();
							}
						}
						keKOIkvUeYbykNshgjWXpvtYsVhJ = null;
						LaQNhWAhcgxAjulxphqcAJRLEIIi = null;
						mmCPZWXnKmiDZZhtShXdYWUvSazN = null;
						UdrGWjbrCwKZmFZTyFeeMTYIdDSL = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int udrGWjbrCwKZmFZTyFeeMTYIdDSL = UdrGWjbrCwKZmFZTyFeeMTYIdDSL;
							MapHelper mapHelper = bcaOPuxDmuUKkJRXJWiSPFWSIKN;
							if (udrGWjbrCwKZmFZTyFeeMTYIdDSL != 0)
							{
								if (udrGWjbrCwKZmFZTyFeeMTYIdDSL != 1)
								{
									return false;
								}
								UdrGWjbrCwKZmFZTyFeeMTYIdDSL = -3;
								goto IL_0177;
							}
							UdrGWjbrCwKZmFZTyFeeMTYIdDSL = -1;
							if (ReInput._id != mapHelper.ygQbVjvWgDxIBqyAhSVKpNzECBhf)
							{
								ReInput.CheckInitialized(mapHelper.ygQbVjvWgDxIBqyAhSVKpNzECBhf);
								return false;
							}
							if (vWVvGMbgxXdYpcHDWHWLiRiFeYrM < 0)
							{
								return false;
							}
							LkXRsfZiEKnlspfNmRDJRYNKBXTV = mapHelper.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb;
							MqvrATAQnDckWhpFeNjgcgKLseCjA = 0;
							goto IL_01f7;
							IL_0177:
							if (mmCPZWXnKmiDZZhtShXdYWUvSazN.MoveNext())
							{
								ActionElementMap current = mmCPZWXnKmiDZZhtShXdYWUvSazN.Current;
								kXlTEzoULoHpdfEnmDPSuccyDWbe = current;
								UdrGWjbrCwKZmFZTyFeeMTYIdDSL = 1;
								return true;
							}
							HdpDloWXqBqrKXKacVfYafDvayZg();
							mmCPZWXnKmiDZZhtShXdYWUvSazN = null;
							goto IL_0191;
							IL_0191:
							bZNeksCpHhnZYaFOJRaZeWIKPBgCc++;
							goto IL_01a3;
							IL_01cd:
							if (ZYNLQMXLaOIYZqkfbiOWhQYuqtbUA < nqhNtJQCmEQzIjBQGxvaoHaiIwZx)
							{
								LaQNhWAhcgxAjulxphqcAJRLEIIi = keKOIkvUeYbykNshgjWXpvtYsVhJ.uZavhtXKHVxiCdRnShETRMwAdKdM(ZYNLQMXLaOIYZqkfbiOWhQYuqtbUA).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
								xDrJsKKmSUSKUSqYJciPwyZkgYlD = LaQNhWAhcgxAjulxphqcAJRLEIIi.IdaghgVqdKwQFNEtDYEijJdcbVHeA;
								bZNeksCpHhnZYaFOJRaZeWIKPBgCc = 0;
								goto IL_01a3;
							}
							keKOIkvUeYbykNshgjWXpvtYsVhJ = null;
							MqvrATAQnDckWhpFeNjgcgKLseCjA++;
							goto IL_01f7;
							IL_01a3:
							if (bZNeksCpHhnZYaFOJRaZeWIKPBgCc < xDrJsKKmSUSKUSqYJciPwyZkgYlD)
							{
								if (LaQNhWAhcgxAjulxphqcAJRLEIIi.AZcUeIZqjwMekNcHfENpgGyCRDcAA(bZNeksCpHhnZYaFOJRaZeWIKPBgCc) is ControllerMapWithAxes controllerMapWithAxes && (!NZffclKcEeQUMqTyyyxkNHlufIXS || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(vWVvGMbgxXdYpcHDWHWLiRiFeYrM))
								{
									mmCPZWXnKmiDZZhtShXdYWUvSazN = controllerMapWithAxes.AxisMapsWithAction(vWVvGMbgxXdYpcHDWHWLiRiFeYrM, NZffclKcEeQUMqTyyyxkNHlufIXS).GetEnumerator();
									UdrGWjbrCwKZmFZTyFeeMTYIdDSL = -3;
									goto IL_0177;
								}
								goto IL_0191;
							}
							LaQNhWAhcgxAjulxphqcAJRLEIIi = null;
							ZYNLQMXLaOIYZqkfbiOWhQYuqtbUA++;
							goto IL_01cd;
							IL_01f7:
							if (MqvrATAQnDckWhpFeNjgcgKLseCjA < LkXRsfZiEKnlspfNmRDJRYNKBXTV)
							{
								keKOIkvUeYbykNshgjWXpvtYsVhJ = mapHelper.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.YPeyRKgKWPSqEsMokJyVccifhDpb(MqvrATAQnDckWhpFeNjgcgKLseCjA);
								nqhNtJQCmEQzIjBQGxvaoHaiIwZx = keKOIkvUeYbykNshgjWXpvtYsVhJ.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
								ZYNLQMXLaOIYZqkfbiOWhQYuqtbUA = 0;
								goto IL_01cd;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void HdpDloWXqBqrKXKacVfYafDvayZg()
					{
						UdrGWjbrCwKZmFZTyFeeMTYIdDSL = -1;
						if (mmCPZWXnKmiDZZhtShXdYWUvSazN != null)
						{
							mmCPZWXnKmiDZZhtShXdYWUvSazN.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						lRKFPzAsTZCKcqrEnlLyAPxEnYsk lRKFPzAsTZCKcqrEnlLyAPxEnYsk2;
						if (UdrGWjbrCwKZmFZTyFeeMTYIdDSL == -2 && jJTaxQYOlCSRlDaDZqpGkGVzcpfN == Environment.CurrentManagedThreadId)
						{
							UdrGWjbrCwKZmFZTyFeeMTYIdDSL = 0;
							lRKFPzAsTZCKcqrEnlLyAPxEnYsk2 = this;
						}
						else
						{
							lRKFPzAsTZCKcqrEnlLyAPxEnYsk2 = new lRKFPzAsTZCKcqrEnlLyAPxEnYsk(0);
							lRKFPzAsTZCKcqrEnlLyAPxEnYsk2.bcaOPuxDmuUKkJRXJWiSPFWSIKN = bcaOPuxDmuUKkJRXJWiSPFWSIKN;
						}
						lRKFPzAsTZCKcqrEnlLyAPxEnYsk2.vWVvGMbgxXdYpcHDWHWLiRiFeYrM = ZlOnTKacwnhSIuYPfdQsozQIpPDo;
						lRKFPzAsTZCKcqrEnlLyAPxEnYsk2.NZffclKcEeQUMqTyyyxkNHlufIXS = vhnakjTUAbOcktswwbsuWARrSvOK;
						return lRKFPzAsTZCKcqrEnlLyAPxEnYsk2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class mdwyZrlspLbtwaabtYnvqJkIaeQN : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int RqqWvadKfUhQGvRkAHVuvmSCmuMR;

					private ActionElementMap apoyVUaTSvrYMQdBDbnvjjLtlFAGA;

					private int YcrshsoQXHbGKtRXYWHpEfRmcvcK;

					public MapHelper rlYcvkzhBgFGmVfjoOfoexhqWUlP;

					private int jBlsQDPiSMzdvlalsMtnpixTpFft;

					public int tOQGqVEcMDFSaGkHhsvSNAevokRTb;

					private bool hObdpMaSrOpBOEvqBLVYLXJLRsvs;

					public bool RzbfOFrLSykjPHuQCLzWdAeXxeFD;

					private int GRsxOnDFTelklWQJBrElxZbaWEVk;

					private int PgJQMQPocFnBcvkmTcPJhUbTbdRcb;

					private FcTbzUBLOriYHtrisAslcxMVjwzbA WSMBMFKitEcIEdTqkzQtVvKBSkHLc;

					private int FfiuhBRomBJIcKqPWUOkwanyZrEB;

					private int zKlFdxNmIvCSJdzjJVZerKmZeywSA;

					private PQaFgQVynoEJfalLJXDCcVZTEKyx jbbcltFhzUtZhEBgnknoGVCGbaekc;

					private int utVRBSuqruliEMkkVHiIxEMmnXlj;

					private int RmFWQucaBDkVxjhWzuEopsNcSlD;

					private IEnumerator<ActionElementMap> rxSQBDrGjCGcSDrQmCurPqJvNGKbb;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return apoyVUaTSvrYMQdBDbnvjjLtlFAGA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return apoyVUaTSvrYMQdBDbnvjjLtlFAGA;
						}
					}

					[DebuggerHidden]
					public mdwyZrlspLbtwaabtYnvqJkIaeQN(int P_0)
					{
						RqqWvadKfUhQGvRkAHVuvmSCmuMR = P_0;
						YcrshsoQXHbGKtRXYWHpEfRmcvcK = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int rqqWvadKfUhQGvRkAHVuvmSCmuMR = RqqWvadKfUhQGvRkAHVuvmSCmuMR;
						if (rqqWvadKfUhQGvRkAHVuvmSCmuMR == -3 || rqqWvadKfUhQGvRkAHVuvmSCmuMR == 1)
						{
							try
							{
							}
							finally
							{
								mvTfgKRRZpaKxDQSLLqdPNNPCHLmA();
							}
						}
						WSMBMFKitEcIEdTqkzQtVvKBSkHLc = null;
						jbbcltFhzUtZhEBgnknoGVCGbaekc = null;
						rxSQBDrGjCGcSDrQmCurPqJvNGKbb = null;
						RqqWvadKfUhQGvRkAHVuvmSCmuMR = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int rqqWvadKfUhQGvRkAHVuvmSCmuMR = RqqWvadKfUhQGvRkAHVuvmSCmuMR;
							MapHelper mapHelper = rlYcvkzhBgFGmVfjoOfoexhqWUlP;
							if (rqqWvadKfUhQGvRkAHVuvmSCmuMR != 0)
							{
								if (rqqWvadKfUhQGvRkAHVuvmSCmuMR != 1)
								{
									return false;
								}
								RqqWvadKfUhQGvRkAHVuvmSCmuMR = -3;
								goto IL_016c;
							}
							RqqWvadKfUhQGvRkAHVuvmSCmuMR = -1;
							if (ReInput._id != mapHelper.ygQbVjvWgDxIBqyAhSVKpNzECBhf)
							{
								ReInput.CheckInitialized(mapHelper.ygQbVjvWgDxIBqyAhSVKpNzECBhf);
								return false;
							}
							if (jBlsQDPiSMzdvlalsMtnpixTpFft < 0)
							{
								return false;
							}
							GRsxOnDFTelklWQJBrElxZbaWEVk = mapHelper.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb;
							PgJQMQPocFnBcvkmTcPJhUbTbdRcb = 0;
							goto IL_01ec;
							IL_016c:
							if (rxSQBDrGjCGcSDrQmCurPqJvNGKbb.MoveNext())
							{
								ActionElementMap current = rxSQBDrGjCGcSDrQmCurPqJvNGKbb.Current;
								apoyVUaTSvrYMQdBDbnvjjLtlFAGA = current;
								RqqWvadKfUhQGvRkAHVuvmSCmuMR = 1;
								return true;
							}
							mvTfgKRRZpaKxDQSLLqdPNNPCHLmA();
							rxSQBDrGjCGcSDrQmCurPqJvNGKbb = null;
							goto IL_0186;
							IL_0186:
							RmFWQucaBDkVxjhWzuEopsNcSlD++;
							goto IL_0198;
							IL_01c2:
							if (zKlFdxNmIvCSJdzjJVZerKmZeywSA < FfiuhBRomBJIcKqPWUOkwanyZrEB)
							{
								jbbcltFhzUtZhEBgnknoGVCGbaekc = WSMBMFKitEcIEdTqkzQtVvKBSkHLc.uZavhtXKHVxiCdRnShETRMwAdKdM(zKlFdxNmIvCSJdzjJVZerKmZeywSA).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
								utVRBSuqruliEMkkVHiIxEMmnXlj = jbbcltFhzUtZhEBgnknoGVCGbaekc.IdaghgVqdKwQFNEtDYEijJdcbVHeA;
								RmFWQucaBDkVxjhWzuEopsNcSlD = 0;
								goto IL_0198;
							}
							WSMBMFKitEcIEdTqkzQtVvKBSkHLc = null;
							PgJQMQPocFnBcvkmTcPJhUbTbdRcb++;
							goto IL_01ec;
							IL_0198:
							if (RmFWQucaBDkVxjhWzuEopsNcSlD < utVRBSuqruliEMkkVHiIxEMmnXlj)
							{
								ControllerMap controllerMap = jbbcltFhzUtZhEBgnknoGVCGbaekc.AZcUeIZqjwMekNcHfENpgGyCRDcAA(RmFWQucaBDkVxjhWzuEopsNcSlD);
								if ((!hObdpMaSrOpBOEvqBLVYLXJLRsvs || controllerMap.enabled) && controllerMap.ContainsAction(jBlsQDPiSMzdvlalsMtnpixTpFft))
								{
									rxSQBDrGjCGcSDrQmCurPqJvNGKbb = controllerMap.ButtonMapsWithAction(jBlsQDPiSMzdvlalsMtnpixTpFft, hObdpMaSrOpBOEvqBLVYLXJLRsvs).GetEnumerator();
									RqqWvadKfUhQGvRkAHVuvmSCmuMR = -3;
									goto IL_016c;
								}
								goto IL_0186;
							}
							jbbcltFhzUtZhEBgnknoGVCGbaekc = null;
							zKlFdxNmIvCSJdzjJVZerKmZeywSA++;
							goto IL_01c2;
							IL_01ec:
							if (PgJQMQPocFnBcvkmTcPJhUbTbdRcb < GRsxOnDFTelklWQJBrElxZbaWEVk)
							{
								WSMBMFKitEcIEdTqkzQtVvKBSkHLc = mapHelper.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.YPeyRKgKWPSqEsMokJyVccifhDpb(PgJQMQPocFnBcvkmTcPJhUbTbdRcb);
								FfiuhBRomBJIcKqPWUOkwanyZrEB = WSMBMFKitEcIEdTqkzQtVvKBSkHLc.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
								zKlFdxNmIvCSJdzjJVZerKmZeywSA = 0;
								goto IL_01c2;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void mvTfgKRRZpaKxDQSLLqdPNNPCHLmA()
					{
						RqqWvadKfUhQGvRkAHVuvmSCmuMR = -1;
						if (rxSQBDrGjCGcSDrQmCurPqJvNGKbb != null)
						{
							rxSQBDrGjCGcSDrQmCurPqJvNGKbb.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						mdwyZrlspLbtwaabtYnvqJkIaeQN mdwyZrlspLbtwaabtYnvqJkIaeQN2;
						if (RqqWvadKfUhQGvRkAHVuvmSCmuMR == -2 && YcrshsoQXHbGKtRXYWHpEfRmcvcK == Environment.CurrentManagedThreadId)
						{
							RqqWvadKfUhQGvRkAHVuvmSCmuMR = 0;
							mdwyZrlspLbtwaabtYnvqJkIaeQN2 = this;
						}
						else
						{
							mdwyZrlspLbtwaabtYnvqJkIaeQN2 = new mdwyZrlspLbtwaabtYnvqJkIaeQN(0);
							mdwyZrlspLbtwaabtYnvqJkIaeQN2.rlYcvkzhBgFGmVfjoOfoexhqWUlP = rlYcvkzhBgFGmVfjoOfoexhqWUlP;
						}
						mdwyZrlspLbtwaabtYnvqJkIaeQN2.jBlsQDPiSMzdvlalsMtnpixTpFft = tOQGqVEcMDFSaGkHhsvSNAevokRTb;
						mdwyZrlspLbtwaabtYnvqJkIaeQN2.hObdpMaSrOpBOEvqBLVYLXJLRsvs = RzbfOFrLSykjPHuQCLzWdAeXxeFD;
						return mdwyZrlspLbtwaabtYnvqJkIaeQN2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class jTviTuNodvCfJbjGydQSUbFyjtjab : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int AsQcWBgETNfnIBaIgLbokgsXrwvbc;

					private ActionElementMap VaCODIOqihjMCBLVYjlKqxNSpPAZ;

					private int iMJILduzTGfmcrRsoxIqvRsTADjE;

					private int TeMIckoznaiieJxZBScGKcRjtfoU;

					public int RVRjtbQSFCtxKqnNzHekfFzXncKO;

					public MapHelper stRzMUDvtXsLqXRNvIgWvgHJvcE;

					private ControllerType VZtfxWhXHCuGrgyNcvwzMtHRrtdk;

					public ControllerType WCCwqvQunDWAQeUBLEKtifWSyuDw;

					private bool qOgLmWtjCTqcCtMPCQkPXGrfFZYG;

					public bool jwpWubyXEubVcCQFaMrXcBTEclKFA;

					private FcTbzUBLOriYHtrisAslcxMVjwzbA vNjemGPUwWsaRXbRmBxHCJLaAhJL;

					private int OlkuJXBOyTZBvTYUzHdPNifJNMNk;

					private IList<ControllerMap> VYLaHmubokobtmDoPhSedWrFcyvFb;

					private int oGhbedamTRrOjWgAluNTsRipxfvgA;

					private IEnumerator<ActionElementMap> hoKakpfJmYttDRsbVlVMxNAagCRuA;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return VaCODIOqihjMCBLVYjlKqxNSpPAZ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return VaCODIOqihjMCBLVYjlKqxNSpPAZ;
						}
					}

					[DebuggerHidden]
					public jTviTuNodvCfJbjGydQSUbFyjtjab(int P_0)
					{
						AsQcWBgETNfnIBaIgLbokgsXrwvbc = P_0;
						iMJILduzTGfmcrRsoxIqvRsTADjE = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int asQcWBgETNfnIBaIgLbokgsXrwvbc = AsQcWBgETNfnIBaIgLbokgsXrwvbc;
						if (asQcWBgETNfnIBaIgLbokgsXrwvbc == -3 || asQcWBgETNfnIBaIgLbokgsXrwvbc == 1)
						{
							try
							{
							}
							finally
							{
								HAlMQyMMgFPAGRcXCvVQXOnbHhOg();
							}
						}
						vNjemGPUwWsaRXbRmBxHCJLaAhJL = null;
						VYLaHmubokobtmDoPhSedWrFcyvFb = null;
						hoKakpfJmYttDRsbVlVMxNAagCRuA = null;
						AsQcWBgETNfnIBaIgLbokgsXrwvbc = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int asQcWBgETNfnIBaIgLbokgsXrwvbc = AsQcWBgETNfnIBaIgLbokgsXrwvbc;
							MapHelper mapHelper = stRzMUDvtXsLqXRNvIgWvgHJvcE;
							if (asQcWBgETNfnIBaIgLbokgsXrwvbc != 0)
							{
								if (asQcWBgETNfnIBaIgLbokgsXrwvbc != 1)
								{
									return false;
								}
								AsQcWBgETNfnIBaIgLbokgsXrwvbc = -3;
								goto IL_0150;
							}
							AsQcWBgETNfnIBaIgLbokgsXrwvbc = -1;
							if (TeMIckoznaiieJxZBScGKcRjtfoU < 0)
							{
								return false;
							}
							vNjemGPUwWsaRXbRmBxHCJLaAhJL = mapHelper.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(VZtfxWhXHCuGrgyNcvwzMtHRrtdk);
							OlkuJXBOyTZBvTYUzHdPNifJNMNk = 0;
							goto IL_01ab;
							IL_0150:
							if (hoKakpfJmYttDRsbVlVMxNAagCRuA.MoveNext())
							{
								ActionElementMap current = hoKakpfJmYttDRsbVlVMxNAagCRuA.Current;
								VaCODIOqihjMCBLVYjlKqxNSpPAZ = current;
								AsQcWBgETNfnIBaIgLbokgsXrwvbc = 1;
								return true;
							}
							HAlMQyMMgFPAGRcXCvVQXOnbHhOg();
							hoKakpfJmYttDRsbVlVMxNAagCRuA = null;
							goto IL_016a;
							IL_017c:
							if (oGhbedamTRrOjWgAluNTsRipxfvgA < VYLaHmubokobtmDoPhSedWrFcyvFb.Count)
							{
								if (!(VYLaHmubokobtmDoPhSedWrFcyvFb[oGhbedamTRrOjWgAluNTsRipxfvgA] is ControllerMapWithAxes))
								{
									return false;
								}
								if ((!qOgLmWtjCTqcCtMPCQkPXGrfFZYG || VYLaHmubokobtmDoPhSedWrFcyvFb[oGhbedamTRrOjWgAluNTsRipxfvgA].enabled) && VYLaHmubokobtmDoPhSedWrFcyvFb[oGhbedamTRrOjWgAluNTsRipxfvgA].ContainsAction(TeMIckoznaiieJxZBScGKcRjtfoU))
								{
									hoKakpfJmYttDRsbVlVMxNAagCRuA = (VYLaHmubokobtmDoPhSedWrFcyvFb[oGhbedamTRrOjWgAluNTsRipxfvgA] as ControllerMapWithAxes).AxisMapsWithAction(TeMIckoznaiieJxZBScGKcRjtfoU, qOgLmWtjCTqcCtMPCQkPXGrfFZYG).GetEnumerator();
									AsQcWBgETNfnIBaIgLbokgsXrwvbc = -3;
									goto IL_0150;
								}
								goto IL_016a;
							}
							VYLaHmubokobtmDoPhSedWrFcyvFb = null;
							OlkuJXBOyTZBvTYUzHdPNifJNMNk++;
							goto IL_01ab;
							IL_016a:
							oGhbedamTRrOjWgAluNTsRipxfvgA++;
							goto IL_017c;
							IL_01ab:
							if (OlkuJXBOyTZBvTYUzHdPNifJNMNk < vNjemGPUwWsaRXbRmBxHCJLaAhJL.RkJWsNlHTmrNlRDEKklNpYTEPhDh)
							{
								VYLaHmubokobtmDoPhSedWrFcyvFb = vNjemGPUwWsaRXbRmBxHCJLaAhJL.uZavhtXKHVxiCdRnShETRMwAdKdM(OlkuJXBOyTZBvTYUzHdPNifJNMNk).ahBHvaaFKqjYqOJIXAFDIKodzptCA.iBWakmwJlExbdlnUxGRNeGbUfhQo;
								oGhbedamTRrOjWgAluNTsRipxfvgA = 0;
								goto IL_017c;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void HAlMQyMMgFPAGRcXCvVQXOnbHhOg()
					{
						AsQcWBgETNfnIBaIgLbokgsXrwvbc = -1;
						if (hoKakpfJmYttDRsbVlVMxNAagCRuA != null)
						{
							hoKakpfJmYttDRsbVlVMxNAagCRuA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						jTviTuNodvCfJbjGydQSUbFyjtjab jTviTuNodvCfJbjGydQSUbFyjtjab2;
						if (AsQcWBgETNfnIBaIgLbokgsXrwvbc == -2 && iMJILduzTGfmcrRsoxIqvRsTADjE == Environment.CurrentManagedThreadId)
						{
							AsQcWBgETNfnIBaIgLbokgsXrwvbc = 0;
							jTviTuNodvCfJbjGydQSUbFyjtjab2 = this;
						}
						else
						{
							jTviTuNodvCfJbjGydQSUbFyjtjab2 = new jTviTuNodvCfJbjGydQSUbFyjtjab(0);
							jTviTuNodvCfJbjGydQSUbFyjtjab2.stRzMUDvtXsLqXRNvIgWvgHJvcE = stRzMUDvtXsLqXRNvIgWvgHJvcE;
						}
						jTviTuNodvCfJbjGydQSUbFyjtjab2.VZtfxWhXHCuGrgyNcvwzMtHRrtdk = WCCwqvQunDWAQeUBLEKtifWSyuDw;
						jTviTuNodvCfJbjGydQSUbFyjtjab2.TeMIckoznaiieJxZBScGKcRjtfoU = RVRjtbQSFCtxKqnNzHekfFzXncKO;
						jTviTuNodvCfJbjGydQSUbFyjtjab2.qOgLmWtjCTqcCtMPCQkPXGrfFZYG = jwpWubyXEubVcCQFaMrXcBTEclKFA;
						return jTviTuNodvCfJbjGydQSUbFyjtjab2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class bnSDPFdRwecPeJfbnnoQBEuOQcdWA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int PeEbaoKCEdQAqrrAfBdxXcnrpwaI;

					private ActionElementMap iipnhlLhDSrtdPyUvYZviuyhydBA;

					private int WHcDqZlwzSybJKuLjZgpBhUeAfno;

					private int ipIhfZTfigzRLfpSlXuPAbgzAAoc;

					public int tIhfqMxcMonOUvyWdGXiBtOkaKMB;

					public MapHelper CcbgHoavOZYCLtutIXnOPDrilOIHb;

					private ControllerType DtMYDgdJInIiNGTnlhtFufgrjlmKA;

					public ControllerType mcuRvaMbeZOVcJubRuKFyLvfUPtK;

					private int GOowCCvdRlzWzQIJJJLJzLjGIHkW;

					public int XFZgbccKxogDHgyyniPAQyNYTJDE;

					private bool XTrFBPDuDsSdCfgrbBdEKmWHHrBtE;

					public bool yxTgBOHvHfMZNvQabNXNZGjgLcwWA;

					private IList<ControllerMap> HcuXmkTiJnIdRBdmfssWSQwcUyqmA;

					private int TFgNYvEwMsuHYvWwUIxkAbXnPqsl;

					private IEnumerator<ActionElementMap> PldJhyebggDgTdmrUnDACQagiCYb;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return iipnhlLhDSrtdPyUvYZviuyhydBA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return iipnhlLhDSrtdPyUvYZviuyhydBA;
						}
					}

					[DebuggerHidden]
					public bnSDPFdRwecPeJfbnnoQBEuOQcdWA(int P_0)
					{
						PeEbaoKCEdQAqrrAfBdxXcnrpwaI = P_0;
						WHcDqZlwzSybJKuLjZgpBhUeAfno = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int peEbaoKCEdQAqrrAfBdxXcnrpwaI = PeEbaoKCEdQAqrrAfBdxXcnrpwaI;
						if (peEbaoKCEdQAqrrAfBdxXcnrpwaI == -3 || peEbaoKCEdQAqrrAfBdxXcnrpwaI == 1)
						{
							try
							{
							}
							finally
							{
								UUzxcYiFawjowGsCEKPWLvewhDpg();
							}
						}
						HcuXmkTiJnIdRBdmfssWSQwcUyqmA = null;
						PldJhyebggDgTdmrUnDACQagiCYb = null;
						PeEbaoKCEdQAqrrAfBdxXcnrpwaI = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int peEbaoKCEdQAqrrAfBdxXcnrpwaI = PeEbaoKCEdQAqrrAfBdxXcnrpwaI;
							MapHelper ccbgHoavOZYCLtutIXnOPDrilOIHb = CcbgHoavOZYCLtutIXnOPDrilOIHb;
							if (peEbaoKCEdQAqrrAfBdxXcnrpwaI != 0)
							{
								if (peEbaoKCEdQAqrrAfBdxXcnrpwaI != 1)
								{
									return false;
								}
								PeEbaoKCEdQAqrrAfBdxXcnrpwaI = -3;
								goto IL_014f;
							}
							PeEbaoKCEdQAqrrAfBdxXcnrpwaI = -1;
							if (ipIhfZTfigzRLfpSlXuPAbgzAAoc < 0)
							{
								return false;
							}
							FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = ccbgHoavOZYCLtutIXnOPDrilOIHb.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(DtMYDgdJInIiNGTnlhtFufgrjlmKA);
							int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(GOowCCvdRlzWzQIJJJLJzLjGIHkW);
							if (num < 0)
							{
								return false;
							}
							HcuXmkTiJnIdRBdmfssWSQwcUyqmA = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.iBWakmwJlExbdlnUxGRNeGbUfhQo;
							TFgNYvEwMsuHYvWwUIxkAbXnPqsl = 0;
							goto IL_017b;
							IL_014f:
							if (PldJhyebggDgTdmrUnDACQagiCYb.MoveNext())
							{
								ActionElementMap current = PldJhyebggDgTdmrUnDACQagiCYb.Current;
								iipnhlLhDSrtdPyUvYZviuyhydBA = current;
								PeEbaoKCEdQAqrrAfBdxXcnrpwaI = 1;
								return true;
							}
							UUzxcYiFawjowGsCEKPWLvewhDpg();
							PldJhyebggDgTdmrUnDACQagiCYb = null;
							goto IL_0169;
							IL_017b:
							if (TFgNYvEwMsuHYvWwUIxkAbXnPqsl < HcuXmkTiJnIdRBdmfssWSQwcUyqmA.Count)
							{
								if (!(HcuXmkTiJnIdRBdmfssWSQwcUyqmA[TFgNYvEwMsuHYvWwUIxkAbXnPqsl] is ControllerMapWithAxes))
								{
									return false;
								}
								if ((!XTrFBPDuDsSdCfgrbBdEKmWHHrBtE || HcuXmkTiJnIdRBdmfssWSQwcUyqmA[TFgNYvEwMsuHYvWwUIxkAbXnPqsl].enabled) && HcuXmkTiJnIdRBdmfssWSQwcUyqmA[TFgNYvEwMsuHYvWwUIxkAbXnPqsl].ContainsAction(ipIhfZTfigzRLfpSlXuPAbgzAAoc))
								{
									PldJhyebggDgTdmrUnDACQagiCYb = (HcuXmkTiJnIdRBdmfssWSQwcUyqmA[TFgNYvEwMsuHYvWwUIxkAbXnPqsl] as ControllerMapWithAxes).AxisMapsWithAction(ipIhfZTfigzRLfpSlXuPAbgzAAoc, XTrFBPDuDsSdCfgrbBdEKmWHHrBtE).GetEnumerator();
									PeEbaoKCEdQAqrrAfBdxXcnrpwaI = -3;
									goto IL_014f;
								}
								goto IL_0169;
							}
							return false;
							IL_0169:
							TFgNYvEwMsuHYvWwUIxkAbXnPqsl++;
							goto IL_017b;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void UUzxcYiFawjowGsCEKPWLvewhDpg()
					{
						PeEbaoKCEdQAqrrAfBdxXcnrpwaI = -1;
						if (PldJhyebggDgTdmrUnDACQagiCYb != null)
						{
							PldJhyebggDgTdmrUnDACQagiCYb.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						bnSDPFdRwecPeJfbnnoQBEuOQcdWA bnSDPFdRwecPeJfbnnoQBEuOQcdWA2;
						if (PeEbaoKCEdQAqrrAfBdxXcnrpwaI == -2 && WHcDqZlwzSybJKuLjZgpBhUeAfno == Environment.CurrentManagedThreadId)
						{
							PeEbaoKCEdQAqrrAfBdxXcnrpwaI = 0;
							bnSDPFdRwecPeJfbnnoQBEuOQcdWA2 = this;
						}
						else
						{
							bnSDPFdRwecPeJfbnnoQBEuOQcdWA2 = new bnSDPFdRwecPeJfbnnoQBEuOQcdWA(0);
							bnSDPFdRwecPeJfbnnoQBEuOQcdWA2.CcbgHoavOZYCLtutIXnOPDrilOIHb = CcbgHoavOZYCLtutIXnOPDrilOIHb;
						}
						bnSDPFdRwecPeJfbnnoQBEuOQcdWA2.DtMYDgdJInIiNGTnlhtFufgrjlmKA = mcuRvaMbeZOVcJubRuKFyLvfUPtK;
						bnSDPFdRwecPeJfbnnoQBEuOQcdWA2.GOowCCvdRlzWzQIJJJLJzLjGIHkW = XFZgbccKxogDHgyyniPAQyNYTJDE;
						bnSDPFdRwecPeJfbnnoQBEuOQcdWA2.ipIhfZTfigzRLfpSlXuPAbgzAAoc = tIhfqMxcMonOUvyWdGXiBtOkaKMB;
						bnSDPFdRwecPeJfbnnoQBEuOQcdWA2.XTrFBPDuDsSdCfgrbBdEKmWHHrBtE = yxTgBOHvHfMZNvQabNXNZGjgLcwWA;
						return bnSDPFdRwecPeJfbnnoQBEuOQcdWA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class edDarBbPSVOOraILYXTbWVXlLTsm : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int SHeaSCsTYqGAXaLgxmfcvliVuGaGA;

					private ActionElementMap kjVFUzhFfxYLXPRKHKCYlmZGmiUfA;

					private int QMoYnqIUFSGwPJPQGDCjjECGIZFR;

					private int FOdicRPKkxCWWXpkesFpwjDTncTf;

					public int dugrWkUHJXSMjkvIetcdWkIfroxC;

					public MapHelper TLsJaAHtyaqKAUEmSYzNCoaweqBb;

					private ControllerType rDRbaofxnpmGJqpFGZAIlQNlZpqUA;

					public ControllerType WSDqVvFTvicTLXEhyFQmpVxHgGSl;

					private bool HkHIueHANwhCEPDWybMVbmDheKxJA;

					public bool TXNWhAuJYGEkyrCoIIzufegQDacV;

					private FcTbzUBLOriYHtrisAslcxMVjwzbA StZtFaIKmbZcSZGVgSNomotwoIbc;

					private int NBoQEAgRgzCMDdfbulpfHEKXQcnP;

					private IList<ControllerMap> PwqKaQxpOuUhkviyIuLeqduHZgWP;

					private int AsKoKztpoHfNPtotiUOMBvTDFuNE;

					private IEnumerator<ActionElementMap> sURMHKxNBPyhSVflDjkPmDKDUTui;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return kjVFUzhFfxYLXPRKHKCYlmZGmiUfA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return kjVFUzhFfxYLXPRKHKCYlmZGmiUfA;
						}
					}

					[DebuggerHidden]
					public edDarBbPSVOOraILYXTbWVXlLTsm(int P_0)
					{
						SHeaSCsTYqGAXaLgxmfcvliVuGaGA = P_0;
						QMoYnqIUFSGwPJPQGDCjjECGIZFR = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int sHeaSCsTYqGAXaLgxmfcvliVuGaGA = SHeaSCsTYqGAXaLgxmfcvliVuGaGA;
						if (sHeaSCsTYqGAXaLgxmfcvliVuGaGA == -3 || sHeaSCsTYqGAXaLgxmfcvliVuGaGA == 1)
						{
							try
							{
							}
							finally
							{
								ijfkdPVzGEfzUottjLHdJBaJSlad();
							}
						}
						StZtFaIKmbZcSZGVgSNomotwoIbc = null;
						PwqKaQxpOuUhkviyIuLeqduHZgWP = null;
						sURMHKxNBPyhSVflDjkPmDKDUTui = null;
						SHeaSCsTYqGAXaLgxmfcvliVuGaGA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int sHeaSCsTYqGAXaLgxmfcvliVuGaGA = SHeaSCsTYqGAXaLgxmfcvliVuGaGA;
							MapHelper tLsJaAHtyaqKAUEmSYzNCoaweqBb = TLsJaAHtyaqKAUEmSYzNCoaweqBb;
							if (sHeaSCsTYqGAXaLgxmfcvliVuGaGA != 0)
							{
								if (sHeaSCsTYqGAXaLgxmfcvliVuGaGA != 1)
								{
									return false;
								}
								SHeaSCsTYqGAXaLgxmfcvliVuGaGA = -3;
								goto IL_012c;
							}
							SHeaSCsTYqGAXaLgxmfcvliVuGaGA = -1;
							if (FOdicRPKkxCWWXpkesFpwjDTncTf < 0)
							{
								return false;
							}
							StZtFaIKmbZcSZGVgSNomotwoIbc = tLsJaAHtyaqKAUEmSYzNCoaweqBb.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(rDRbaofxnpmGJqpFGZAIlQNlZpqUA);
							NBoQEAgRgzCMDdfbulpfHEKXQcnP = 0;
							goto IL_0187;
							IL_012c:
							if (sURMHKxNBPyhSVflDjkPmDKDUTui.MoveNext())
							{
								ActionElementMap current = sURMHKxNBPyhSVflDjkPmDKDUTui.Current;
								kjVFUzhFfxYLXPRKHKCYlmZGmiUfA = current;
								SHeaSCsTYqGAXaLgxmfcvliVuGaGA = 1;
								return true;
							}
							ijfkdPVzGEfzUottjLHdJBaJSlad();
							sURMHKxNBPyhSVflDjkPmDKDUTui = null;
							goto IL_0146;
							IL_0158:
							if (AsKoKztpoHfNPtotiUOMBvTDFuNE < PwqKaQxpOuUhkviyIuLeqduHZgWP.Count)
							{
								if ((!HkHIueHANwhCEPDWybMVbmDheKxJA || PwqKaQxpOuUhkviyIuLeqduHZgWP[AsKoKztpoHfNPtotiUOMBvTDFuNE].enabled) && PwqKaQxpOuUhkviyIuLeqduHZgWP[AsKoKztpoHfNPtotiUOMBvTDFuNE].ContainsAction(FOdicRPKkxCWWXpkesFpwjDTncTf))
								{
									sURMHKxNBPyhSVflDjkPmDKDUTui = PwqKaQxpOuUhkviyIuLeqduHZgWP[AsKoKztpoHfNPtotiUOMBvTDFuNE].ButtonMapsWithAction(FOdicRPKkxCWWXpkesFpwjDTncTf, HkHIueHANwhCEPDWybMVbmDheKxJA).GetEnumerator();
									SHeaSCsTYqGAXaLgxmfcvliVuGaGA = -3;
									goto IL_012c;
								}
								goto IL_0146;
							}
							PwqKaQxpOuUhkviyIuLeqduHZgWP = null;
							NBoQEAgRgzCMDdfbulpfHEKXQcnP++;
							goto IL_0187;
							IL_0146:
							AsKoKztpoHfNPtotiUOMBvTDFuNE++;
							goto IL_0158;
							IL_0187:
							if (NBoQEAgRgzCMDdfbulpfHEKXQcnP < StZtFaIKmbZcSZGVgSNomotwoIbc.RkJWsNlHTmrNlRDEKklNpYTEPhDh)
							{
								PwqKaQxpOuUhkviyIuLeqduHZgWP = StZtFaIKmbZcSZGVgSNomotwoIbc.uZavhtXKHVxiCdRnShETRMwAdKdM(NBoQEAgRgzCMDdfbulpfHEKXQcnP).ahBHvaaFKqjYqOJIXAFDIKodzptCA.iBWakmwJlExbdlnUxGRNeGbUfhQo;
								AsKoKztpoHfNPtotiUOMBvTDFuNE = 0;
								goto IL_0158;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void ijfkdPVzGEfzUottjLHdJBaJSlad()
					{
						SHeaSCsTYqGAXaLgxmfcvliVuGaGA = -1;
						if (sURMHKxNBPyhSVflDjkPmDKDUTui != null)
						{
							sURMHKxNBPyhSVflDjkPmDKDUTui.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						edDarBbPSVOOraILYXTbWVXlLTsm edDarBbPSVOOraILYXTbWVXlLTsm2;
						if (SHeaSCsTYqGAXaLgxmfcvliVuGaGA == -2 && QMoYnqIUFSGwPJPQGDCjjECGIZFR == Environment.CurrentManagedThreadId)
						{
							SHeaSCsTYqGAXaLgxmfcvliVuGaGA = 0;
							edDarBbPSVOOraILYXTbWVXlLTsm2 = this;
						}
						else
						{
							edDarBbPSVOOraILYXTbWVXlLTsm2 = new edDarBbPSVOOraILYXTbWVXlLTsm(0);
							edDarBbPSVOOraILYXTbWVXlLTsm2.TLsJaAHtyaqKAUEmSYzNCoaweqBb = TLsJaAHtyaqKAUEmSYzNCoaweqBb;
						}
						edDarBbPSVOOraILYXTbWVXlLTsm2.rDRbaofxnpmGJqpFGZAIlQNlZpqUA = WSDqVvFTvicTLXEhyFQmpVxHgGSl;
						edDarBbPSVOOraILYXTbWVXlLTsm2.FOdicRPKkxCWWXpkesFpwjDTncTf = dugrWkUHJXSMjkvIetcdWkIfroxC;
						edDarBbPSVOOraILYXTbWVXlLTsm2.HkHIueHANwhCEPDWybMVbmDheKxJA = TXNWhAuJYGEkyrCoIIzufegQDacV;
						return edDarBbPSVOOraILYXTbWVXlLTsm2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class XvYAtNkrcDnLxkBFJfRIWDCHFRMk : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int ZdQIEXIaTKzDugTRlZwDJjfaHqMzA;

					private ActionElementMap ONXMtWTdCMoQBLCffIIVJqOIvhdCA;

					private int xZkmPrGcBCiUmCFDlpIUhvDgLGiXA;

					private int gGaHJlUNeJJmrmfzszGjUkjGRhsJ;

					public int lEpzodbuoIIZadomStnsqItPCcQp;

					public MapHelper SDfrmRsBINvFpAkujWuPhNyyuUfI;

					private ControllerType GQcbPtrmzkUDvTLwfdoLdgIopPaNA;

					public ControllerType XScDMuNzriulKdZnFWLCTuxEImAF;

					private int oObZITkOoMGStvutfFeMacBHckWfb;

					public int YVmgPGDUJGALWagNBGjRKFKkNMYxA;

					private bool AfmbJnIgvsFlNxHYcspYEwbOzExS;

					public bool NujtdQGKNNYMaTKLhuIkpFyMrctQ;

					private IList<ControllerMap> OzuDRUNhUEcBlOgRBsgTaFeDQdKP;

					private int PYdnLqJOmCzuUWufIhTgmkxEFzlq;

					private IEnumerator<ActionElementMap> MPwDkViBweUrKlvaxmUdsGxmecde;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return ONXMtWTdCMoQBLCffIIVJqOIvhdCA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ONXMtWTdCMoQBLCffIIVJqOIvhdCA;
						}
					}

					[DebuggerHidden]
					public XvYAtNkrcDnLxkBFJfRIWDCHFRMk(int P_0)
					{
						ZdQIEXIaTKzDugTRlZwDJjfaHqMzA = P_0;
						xZkmPrGcBCiUmCFDlpIUhvDgLGiXA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int zdQIEXIaTKzDugTRlZwDJjfaHqMzA = ZdQIEXIaTKzDugTRlZwDJjfaHqMzA;
						if (zdQIEXIaTKzDugTRlZwDJjfaHqMzA == -3 || zdQIEXIaTKzDugTRlZwDJjfaHqMzA == 1)
						{
							try
							{
							}
							finally
							{
								rNlOcMIBrXRWSHcpASmrtiLhDjEP();
							}
						}
						OzuDRUNhUEcBlOgRBsgTaFeDQdKP = null;
						MPwDkViBweUrKlvaxmUdsGxmecde = null;
						ZdQIEXIaTKzDugTRlZwDJjfaHqMzA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int zdQIEXIaTKzDugTRlZwDJjfaHqMzA = ZdQIEXIaTKzDugTRlZwDJjfaHqMzA;
							MapHelper sDfrmRsBINvFpAkujWuPhNyyuUfI = SDfrmRsBINvFpAkujWuPhNyyuUfI;
							if (zdQIEXIaTKzDugTRlZwDJjfaHqMzA != 0)
							{
								if (zdQIEXIaTKzDugTRlZwDJjfaHqMzA != 1)
								{
									return false;
								}
								ZdQIEXIaTKzDugTRlZwDJjfaHqMzA = -3;
								goto IL_012b;
							}
							ZdQIEXIaTKzDugTRlZwDJjfaHqMzA = -1;
							if (gGaHJlUNeJJmrmfzszGjUkjGRhsJ < 0)
							{
								return false;
							}
							FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sDfrmRsBINvFpAkujWuPhNyyuUfI.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(GQcbPtrmzkUDvTLwfdoLdgIopPaNA);
							int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(oObZITkOoMGStvutfFeMacBHckWfb);
							if (num < 0)
							{
								return false;
							}
							OzuDRUNhUEcBlOgRBsgTaFeDQdKP = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.iBWakmwJlExbdlnUxGRNeGbUfhQo;
							PYdnLqJOmCzuUWufIhTgmkxEFzlq = 0;
							goto IL_0157;
							IL_012b:
							if (MPwDkViBweUrKlvaxmUdsGxmecde.MoveNext())
							{
								ActionElementMap current = MPwDkViBweUrKlvaxmUdsGxmecde.Current;
								ONXMtWTdCMoQBLCffIIVJqOIvhdCA = current;
								ZdQIEXIaTKzDugTRlZwDJjfaHqMzA = 1;
								return true;
							}
							rNlOcMIBrXRWSHcpASmrtiLhDjEP();
							MPwDkViBweUrKlvaxmUdsGxmecde = null;
							goto IL_0145;
							IL_0157:
							if (PYdnLqJOmCzuUWufIhTgmkxEFzlq < OzuDRUNhUEcBlOgRBsgTaFeDQdKP.Count)
							{
								if ((!AfmbJnIgvsFlNxHYcspYEwbOzExS || OzuDRUNhUEcBlOgRBsgTaFeDQdKP[PYdnLqJOmCzuUWufIhTgmkxEFzlq].enabled) && OzuDRUNhUEcBlOgRBsgTaFeDQdKP[PYdnLqJOmCzuUWufIhTgmkxEFzlq].ContainsAction(gGaHJlUNeJJmrmfzszGjUkjGRhsJ))
								{
									MPwDkViBweUrKlvaxmUdsGxmecde = OzuDRUNhUEcBlOgRBsgTaFeDQdKP[PYdnLqJOmCzuUWufIhTgmkxEFzlq].ButtonMapsWithAction(gGaHJlUNeJJmrmfzszGjUkjGRhsJ, AfmbJnIgvsFlNxHYcspYEwbOzExS).GetEnumerator();
									ZdQIEXIaTKzDugTRlZwDJjfaHqMzA = -3;
									goto IL_012b;
								}
								goto IL_0145;
							}
							return false;
							IL_0145:
							PYdnLqJOmCzuUWufIhTgmkxEFzlq++;
							goto IL_0157;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void rNlOcMIBrXRWSHcpASmrtiLhDjEP()
					{
						ZdQIEXIaTKzDugTRlZwDJjfaHqMzA = -1;
						if (MPwDkViBweUrKlvaxmUdsGxmecde != null)
						{
							MPwDkViBweUrKlvaxmUdsGxmecde.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						XvYAtNkrcDnLxkBFJfRIWDCHFRMk xvYAtNkrcDnLxkBFJfRIWDCHFRMk;
						if (ZdQIEXIaTKzDugTRlZwDJjfaHqMzA == -2 && xZkmPrGcBCiUmCFDlpIUhvDgLGiXA == Environment.CurrentManagedThreadId)
						{
							ZdQIEXIaTKzDugTRlZwDJjfaHqMzA = 0;
							xvYAtNkrcDnLxkBFJfRIWDCHFRMk = this;
						}
						else
						{
							xvYAtNkrcDnLxkBFJfRIWDCHFRMk = new XvYAtNkrcDnLxkBFJfRIWDCHFRMk(0);
							xvYAtNkrcDnLxkBFJfRIWDCHFRMk.SDfrmRsBINvFpAkujWuPhNyyuUfI = SDfrmRsBINvFpAkujWuPhNyyuUfI;
						}
						xvYAtNkrcDnLxkBFJfRIWDCHFRMk.GQcbPtrmzkUDvTLwfdoLdgIopPaNA = XScDMuNzriulKdZnFWLCTuxEImAF;
						xvYAtNkrcDnLxkBFJfRIWDCHFRMk.oObZITkOoMGStvutfFeMacBHckWfb = YVmgPGDUJGALWagNBGjRKFKkNMYxA;
						xvYAtNkrcDnLxkBFJfRIWDCHFRMk.gGaHJlUNeJJmrmfzszGjUkjGRhsJ = lEpzodbuoIIZadomStnsqItPCcQp;
						xvYAtNkrcDnLxkBFJfRIWDCHFRMk.AfmbJnIgvsFlNxHYcspYEwbOzExS = NujtdQGKNNYMaTKLhuIkpFyMrctQ;
						return xvYAtNkrcDnLxkBFJfRIWDCHFRMk;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class BuRZxIZIxCcaSlsUDkNagjmhUUTQ : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int MihXKwEMshglMhnEpoPoKPgJpTKdA;

					private ActionElementMap ejseTqjpvnOftjntFcFPqVfsMzPiA;

					private int kQzAcKctlKQIeOrWmphaxTxkzMyaA;

					private int fKXhfZqxpYkQUnvobwqdIvrpfIYn;

					public int ANdJgINhIYbBbrrTnBhcIvQkIZuNA;

					public MapHelper VfigwIfdYFBHwvLFRSsXYcDDavld;

					private ControllerType dUBWgxnkNHwKJZyCsXAwgPNxByxF;

					public ControllerType vQTJQWSESYvvmBnmEmIWetpOdcnO;

					private bool fPydSEdeBjxSmBTuNvGnCzlYoqMr;

					public bool QEyVOkyggZnZJVLWqmHnbpMrRAaX;

					private FcTbzUBLOriYHtrisAslcxMVjwzbA mkOpFPUSIvFElsGTbcErZmnxiiMbA;

					private int uqVYqqpEslhAPPKYpojDczlrPDsM;

					private IList<ControllerMap> mqrYfARtJymcReBYSpinbwAwIOEN;

					private int JTMMYYWUblWerQQsTcdYtFjWGGljA;

					private IEnumerator<ActionElementMap> IhxEosrmMhlUQZdmFjaCjSVisYQu;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return ejseTqjpvnOftjntFcFPqVfsMzPiA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ejseTqjpvnOftjntFcFPqVfsMzPiA;
						}
					}

					[DebuggerHidden]
					public BuRZxIZIxCcaSlsUDkNagjmhUUTQ(int P_0)
					{
						MihXKwEMshglMhnEpoPoKPgJpTKdA = P_0;
						kQzAcKctlKQIeOrWmphaxTxkzMyaA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int mihXKwEMshglMhnEpoPoKPgJpTKdA = MihXKwEMshglMhnEpoPoKPgJpTKdA;
						if (mihXKwEMshglMhnEpoPoKPgJpTKdA == -3 || mihXKwEMshglMhnEpoPoKPgJpTKdA == 1)
						{
							try
							{
							}
							finally
							{
								LBwAKsnYrPrMvDLaALTxrAvhiHuN();
							}
						}
						mkOpFPUSIvFElsGTbcErZmnxiiMbA = null;
						mqrYfARtJymcReBYSpinbwAwIOEN = null;
						IhxEosrmMhlUQZdmFjaCjSVisYQu = null;
						MihXKwEMshglMhnEpoPoKPgJpTKdA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int mihXKwEMshglMhnEpoPoKPgJpTKdA = MihXKwEMshglMhnEpoPoKPgJpTKdA;
							MapHelper vfigwIfdYFBHwvLFRSsXYcDDavld = VfigwIfdYFBHwvLFRSsXYcDDavld;
							if (mihXKwEMshglMhnEpoPoKPgJpTKdA != 0)
							{
								if (mihXKwEMshglMhnEpoPoKPgJpTKdA != 1)
								{
									return false;
								}
								MihXKwEMshglMhnEpoPoKPgJpTKdA = -3;
								goto IL_012c;
							}
							MihXKwEMshglMhnEpoPoKPgJpTKdA = -1;
							if (fKXhfZqxpYkQUnvobwqdIvrpfIYn < 0)
							{
								return false;
							}
							mkOpFPUSIvFElsGTbcErZmnxiiMbA = vfigwIfdYFBHwvLFRSsXYcDDavld.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(dUBWgxnkNHwKJZyCsXAwgPNxByxF);
							uqVYqqpEslhAPPKYpojDczlrPDsM = 0;
							goto IL_0187;
							IL_012c:
							if (IhxEosrmMhlUQZdmFjaCjSVisYQu.MoveNext())
							{
								ActionElementMap current = IhxEosrmMhlUQZdmFjaCjSVisYQu.Current;
								ejseTqjpvnOftjntFcFPqVfsMzPiA = current;
								MihXKwEMshglMhnEpoPoKPgJpTKdA = 1;
								return true;
							}
							LBwAKsnYrPrMvDLaALTxrAvhiHuN();
							IhxEosrmMhlUQZdmFjaCjSVisYQu = null;
							goto IL_0146;
							IL_0158:
							if (JTMMYYWUblWerQQsTcdYtFjWGGljA < mqrYfARtJymcReBYSpinbwAwIOEN.Count)
							{
								if ((!fPydSEdeBjxSmBTuNvGnCzlYoqMr || mqrYfARtJymcReBYSpinbwAwIOEN[JTMMYYWUblWerQQsTcdYtFjWGGljA].enabled) && mqrYfARtJymcReBYSpinbwAwIOEN[JTMMYYWUblWerQQsTcdYtFjWGGljA].ContainsAction(fKXhfZqxpYkQUnvobwqdIvrpfIYn))
								{
									IhxEosrmMhlUQZdmFjaCjSVisYQu = mqrYfARtJymcReBYSpinbwAwIOEN[JTMMYYWUblWerQQsTcdYtFjWGGljA].ElementMapsWithAction(fKXhfZqxpYkQUnvobwqdIvrpfIYn, fPydSEdeBjxSmBTuNvGnCzlYoqMr).GetEnumerator();
									MihXKwEMshglMhnEpoPoKPgJpTKdA = -3;
									goto IL_012c;
								}
								goto IL_0146;
							}
							mqrYfARtJymcReBYSpinbwAwIOEN = null;
							uqVYqqpEslhAPPKYpojDczlrPDsM++;
							goto IL_0187;
							IL_0146:
							JTMMYYWUblWerQQsTcdYtFjWGGljA++;
							goto IL_0158;
							IL_0187:
							if (uqVYqqpEslhAPPKYpojDczlrPDsM < mkOpFPUSIvFElsGTbcErZmnxiiMbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh)
							{
								mqrYfARtJymcReBYSpinbwAwIOEN = mkOpFPUSIvFElsGTbcErZmnxiiMbA.uZavhtXKHVxiCdRnShETRMwAdKdM(uqVYqqpEslhAPPKYpojDczlrPDsM).ahBHvaaFKqjYqOJIXAFDIKodzptCA.iBWakmwJlExbdlnUxGRNeGbUfhQo;
								JTMMYYWUblWerQQsTcdYtFjWGGljA = 0;
								goto IL_0158;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void LBwAKsnYrPrMvDLaALTxrAvhiHuN()
					{
						MihXKwEMshglMhnEpoPoKPgJpTKdA = -1;
						if (IhxEosrmMhlUQZdmFjaCjSVisYQu != null)
						{
							IhxEosrmMhlUQZdmFjaCjSVisYQu.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						BuRZxIZIxCcaSlsUDkNagjmhUUTQ buRZxIZIxCcaSlsUDkNagjmhUUTQ;
						if (MihXKwEMshglMhnEpoPoKPgJpTKdA == -2 && kQzAcKctlKQIeOrWmphaxTxkzMyaA == Environment.CurrentManagedThreadId)
						{
							MihXKwEMshglMhnEpoPoKPgJpTKdA = 0;
							buRZxIZIxCcaSlsUDkNagjmhUUTQ = this;
						}
						else
						{
							buRZxIZIxCcaSlsUDkNagjmhUUTQ = new BuRZxIZIxCcaSlsUDkNagjmhUUTQ(0);
							buRZxIZIxCcaSlsUDkNagjmhUUTQ.VfigwIfdYFBHwvLFRSsXYcDDavld = VfigwIfdYFBHwvLFRSsXYcDDavld;
						}
						buRZxIZIxCcaSlsUDkNagjmhUUTQ.dUBWgxnkNHwKJZyCsXAwgPNxByxF = vQTJQWSESYvvmBnmEmIWetpOdcnO;
						buRZxIZIxCcaSlsUDkNagjmhUUTQ.fKXhfZqxpYkQUnvobwqdIvrpfIYn = ANdJgINhIYbBbrrTnBhcIvQkIZuNA;
						buRZxIZIxCcaSlsUDkNagjmhUUTQ.fPydSEdeBjxSmBTuNvGnCzlYoqMr = QEyVOkyggZnZJVLWqmHnbpMrRAaX;
						return buRZxIZIxCcaSlsUDkNagjmhUUTQ;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class uXGvhCUGqVfqjJeCBlBEVRHfPBjIA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int ngxcFwyJbkjHnsWhiaSkAuFxjBQe;

					private ActionElementMap DaeDBBvVNiwCjmViVZCyYyZDKJjh;

					private int dFgfaJxUfxJyruYLAxrwUckJICJc;

					private int hNgDGyQgNXvrXlooARmGsRZzoXXK;

					public int zATQUERSfGQcQIYeeRmgcEgYtkaf;

					public MapHelper BSbqIASJETkEGyEkNWAaaJjeletf;

					private ControllerType ZVEThbyCfBEgIHunRdLlamQeHZLxb;

					public ControllerType faygocFEcTjpQnexhkEtEzUWuqHDb;

					private int FjQTDSLnhWafVNbPRCclmtpleWbz;

					public int EvdRArwLCjIiriVQTCClvlmmJJyw;

					private bool rOoEgcRuLcKVCCimNZbHUhqUnPQQ;

					public bool GsFdKtGZXVKCnBYfPwFmPmdTsJTiA;

					private IList<ControllerMap> LwEHfzEJmPBeOHLZzZJUXcTmSCkD;

					private int ONztNgPHxAmgQxiwyolCLGrGwqWs;

					private IEnumerator<ActionElementMap> pmKrCCyHbzEjxbiyzkVSTfISMKVLA;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return DaeDBBvVNiwCjmViVZCyYyZDKJjh;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return DaeDBBvVNiwCjmViVZCyYyZDKJjh;
						}
					}

					[DebuggerHidden]
					public uXGvhCUGqVfqjJeCBlBEVRHfPBjIA(int P_0)
					{
						ngxcFwyJbkjHnsWhiaSkAuFxjBQe = P_0;
						dFgfaJxUfxJyruYLAxrwUckJICJc = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = ngxcFwyJbkjHnsWhiaSkAuFxjBQe;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								QerjjcgYkesHVGjjUqkvFzmRexBPA();
							}
						}
						LwEHfzEJmPBeOHLZzZJUXcTmSCkD = null;
						pmKrCCyHbzEjxbiyzkVSTfISMKVLA = null;
						ngxcFwyJbkjHnsWhiaSkAuFxjBQe = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = ngxcFwyJbkjHnsWhiaSkAuFxjBQe;
							MapHelper bSbqIASJETkEGyEkNWAaaJjeletf = BSbqIASJETkEGyEkNWAaaJjeletf;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								ngxcFwyJbkjHnsWhiaSkAuFxjBQe = -3;
								goto IL_012b;
							}
							ngxcFwyJbkjHnsWhiaSkAuFxjBQe = -1;
							if (hNgDGyQgNXvrXlooARmGsRZzoXXK < 0)
							{
								return false;
							}
							FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = bSbqIASJETkEGyEkNWAaaJjeletf.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ZVEThbyCfBEgIHunRdLlamQeHZLxb);
							int num2 = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(FjQTDSLnhWafVNbPRCclmtpleWbz);
							if (num2 < 0)
							{
								return false;
							}
							LwEHfzEJmPBeOHLZzZJUXcTmSCkD = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num2).ahBHvaaFKqjYqOJIXAFDIKodzptCA.iBWakmwJlExbdlnUxGRNeGbUfhQo;
							ONztNgPHxAmgQxiwyolCLGrGwqWs = 0;
							goto IL_0157;
							IL_012b:
							if (pmKrCCyHbzEjxbiyzkVSTfISMKVLA.MoveNext())
							{
								ActionElementMap current = pmKrCCyHbzEjxbiyzkVSTfISMKVLA.Current;
								DaeDBBvVNiwCjmViVZCyYyZDKJjh = current;
								ngxcFwyJbkjHnsWhiaSkAuFxjBQe = 1;
								return true;
							}
							QerjjcgYkesHVGjjUqkvFzmRexBPA();
							pmKrCCyHbzEjxbiyzkVSTfISMKVLA = null;
							goto IL_0145;
							IL_0157:
							if (ONztNgPHxAmgQxiwyolCLGrGwqWs < LwEHfzEJmPBeOHLZzZJUXcTmSCkD.Count)
							{
								if ((!rOoEgcRuLcKVCCimNZbHUhqUnPQQ || LwEHfzEJmPBeOHLZzZJUXcTmSCkD[ONztNgPHxAmgQxiwyolCLGrGwqWs].enabled) && LwEHfzEJmPBeOHLZzZJUXcTmSCkD[ONztNgPHxAmgQxiwyolCLGrGwqWs].ContainsAction(hNgDGyQgNXvrXlooARmGsRZzoXXK))
								{
									pmKrCCyHbzEjxbiyzkVSTfISMKVLA = LwEHfzEJmPBeOHLZzZJUXcTmSCkD[ONztNgPHxAmgQxiwyolCLGrGwqWs].ElementMapsWithAction(hNgDGyQgNXvrXlooARmGsRZzoXXK, rOoEgcRuLcKVCCimNZbHUhqUnPQQ).GetEnumerator();
									ngxcFwyJbkjHnsWhiaSkAuFxjBQe = -3;
									goto IL_012b;
								}
								goto IL_0145;
							}
							return false;
							IL_0145:
							ONztNgPHxAmgQxiwyolCLGrGwqWs++;
							goto IL_0157;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void QerjjcgYkesHVGjjUqkvFzmRexBPA()
					{
						ngxcFwyJbkjHnsWhiaSkAuFxjBQe = -1;
						if (pmKrCCyHbzEjxbiyzkVSTfISMKVLA != null)
						{
							pmKrCCyHbzEjxbiyzkVSTfISMKVLA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						uXGvhCUGqVfqjJeCBlBEVRHfPBjIA uXGvhCUGqVfqjJeCBlBEVRHfPBjIA2;
						if (ngxcFwyJbkjHnsWhiaSkAuFxjBQe == -2 && dFgfaJxUfxJyruYLAxrwUckJICJc == Environment.CurrentManagedThreadId)
						{
							ngxcFwyJbkjHnsWhiaSkAuFxjBQe = 0;
							uXGvhCUGqVfqjJeCBlBEVRHfPBjIA2 = this;
						}
						else
						{
							uXGvhCUGqVfqjJeCBlBEVRHfPBjIA2 = new uXGvhCUGqVfqjJeCBlBEVRHfPBjIA(0);
							uXGvhCUGqVfqjJeCBlBEVRHfPBjIA2.BSbqIASJETkEGyEkNWAaaJjeletf = BSbqIASJETkEGyEkNWAaaJjeletf;
						}
						uXGvhCUGqVfqjJeCBlBEVRHfPBjIA2.ZVEThbyCfBEgIHunRdLlamQeHZLxb = faygocFEcTjpQnexhkEtEzUWuqHDb;
						uXGvhCUGqVfqjJeCBlBEVRHfPBjIA2.FjQTDSLnhWafVNbPRCclmtpleWbz = EvdRArwLCjIiriVQTCClvlmmJJyw;
						uXGvhCUGqVfqjJeCBlBEVRHfPBjIA2.hNgDGyQgNXvrXlooARmGsRZzoXXK = zATQUERSfGQcQIYeeRmgcEgYtkaf;
						uXGvhCUGqVfqjJeCBlBEVRHfPBjIA2.rOoEgcRuLcKVCCimNZbHUhqUnPQQ = GsFdKtGZXVKCnBYfPwFmPmdTsJTiA;
						return uXGvhCUGqVfqjJeCBlBEVRHfPBjIA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class tPwObtbIdxvJAKnYUfQMUYGhASBJ : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int IcIzCBXoUxnHKjQYYmbYIKfLkUfg;

					private ControllerMap nsdAhoviFtpXehKmixVBHFaQWNcC;

					private int pKWJTqVoZJuhBMgqiSVjoDwHcmUG;

					public MapHelper ivojNPXkJeqPpAfKIrluYxeplohH;

					private ControllerType WaMxwcwnAnDNUkrbtiAdbEWOKVmq;

					public ControllerType WktBBIYtjfWoFauGYgafQOkJcPGcA;

					private int PlhvhNRCARHYGzkJDuUrKaamvoYV;

					public int OwNniYwdGQGdNIBxnjhkcoZCHLvib;

					private int bonWYOxtlOiTuUBaYFqbvBNHNTiP;

					public int GSRFzudxXNScvBfjIfoOkdFAFMmZ;

					private IList<ControllerMap> BPPhsSWsFCcsDxkrQCDvBmJisgCKA;

					private int ULhDUbbfPpQbNMbhVAQkSVdUDpHzA;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return nsdAhoviFtpXehKmixVBHFaQWNcC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return nsdAhoviFtpXehKmixVBHFaQWNcC;
						}
					}

					[DebuggerHidden]
					public tPwObtbIdxvJAKnYUfQMUYGhASBJ(int P_0)
					{
						IcIzCBXoUxnHKjQYYmbYIKfLkUfg = P_0;
						pKWJTqVoZJuhBMgqiSVjoDwHcmUG = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						BPPhsSWsFCcsDxkrQCDvBmJisgCKA = null;
						IcIzCBXoUxnHKjQYYmbYIKfLkUfg = -2;
					}

					private bool MoveNext()
					{
						int icIzCBXoUxnHKjQYYmbYIKfLkUfg = IcIzCBXoUxnHKjQYYmbYIKfLkUfg;
						MapHelper mapHelper = ivojNPXkJeqPpAfKIrluYxeplohH;
						if (icIzCBXoUxnHKjQYYmbYIKfLkUfg != 0)
						{
							if (icIzCBXoUxnHKjQYYmbYIKfLkUfg != 1)
							{
								return false;
							}
							IcIzCBXoUxnHKjQYYmbYIKfLkUfg = -1;
							goto IL_00b0;
						}
						IcIzCBXoUxnHKjQYYmbYIKfLkUfg = -1;
						FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = mapHelper.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(WaMxwcwnAnDNUkrbtiAdbEWOKVmq);
						int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(PlhvhNRCARHYGzkJDuUrKaamvoYV);
						if (num < 0)
						{
							return false;
						}
						BPPhsSWsFCcsDxkrQCDvBmJisgCKA = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.iBWakmwJlExbdlnUxGRNeGbUfhQo;
						ULhDUbbfPpQbNMbhVAQkSVdUDpHzA = 0;
						goto IL_00c2;
						IL_00c2:
						if (ULhDUbbfPpQbNMbhVAQkSVdUDpHzA < BPPhsSWsFCcsDxkrQCDvBmJisgCKA.Count)
						{
							if (BPPhsSWsFCcsDxkrQCDvBmJisgCKA[ULhDUbbfPpQbNMbhVAQkSVdUDpHzA].categoryId == bonWYOxtlOiTuUBaYFqbvBNHNTiP)
							{
								nsdAhoviFtpXehKmixVBHFaQWNcC = BPPhsSWsFCcsDxkrQCDvBmJisgCKA[ULhDUbbfPpQbNMbhVAQkSVdUDpHzA];
								IcIzCBXoUxnHKjQYYmbYIKfLkUfg = 1;
								return true;
							}
							goto IL_00b0;
						}
						return false;
						IL_00b0:
						ULhDUbbfPpQbNMbhVAQkSVdUDpHzA++;
						goto IL_00c2;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
					{
						tPwObtbIdxvJAKnYUfQMUYGhASBJ tPwObtbIdxvJAKnYUfQMUYGhASBJ2;
						if (IcIzCBXoUxnHKjQYYmbYIKfLkUfg == -2 && pKWJTqVoZJuhBMgqiSVjoDwHcmUG == Environment.CurrentManagedThreadId)
						{
							IcIzCBXoUxnHKjQYYmbYIKfLkUfg = 0;
							tPwObtbIdxvJAKnYUfQMUYGhASBJ2 = this;
						}
						else
						{
							tPwObtbIdxvJAKnYUfQMUYGhASBJ2 = new tPwObtbIdxvJAKnYUfQMUYGhASBJ(0);
							tPwObtbIdxvJAKnYUfQMUYGhASBJ2.ivojNPXkJeqPpAfKIrluYxeplohH = ivojNPXkJeqPpAfKIrluYxeplohH;
						}
						tPwObtbIdxvJAKnYUfQMUYGhASBJ2.WaMxwcwnAnDNUkrbtiAdbEWOKVmq = WktBBIYtjfWoFauGYgafQOkJcPGcA;
						tPwObtbIdxvJAKnYUfQMUYGhASBJ2.PlhvhNRCARHYGzkJDuUrKaamvoYV = OwNniYwdGQGdNIBxnjhkcoZCHLvib;
						tPwObtbIdxvJAKnYUfQMUYGhASBJ2.bonWYOxtlOiTuUBaYFqbvBNHNTiP = GSRFzudxXNScvBfjIfoOkdFAFMmZ;
						return tPwObtbIdxvJAKnYUfQMUYGhASBJ2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class STWKSkmSjsuDWEyfvBQXzbhJrrhU<_0001> : IEnumerable<_0001>, IEnumerable, IEnumerator<_0001>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int gdSmeFoElKdUXVRmtqQstFhVmayW;

					private _0001 AJjVhRpyEqjLPiyUaKjfsDGCbsikA;

					private int ByEnkfXcNpgHsRkYWjwixtHUKYsr;

					public MapHelper ZfiEmRewPkmmxafSvcPvmPySXDrY;

					private int tQvuKqhwtMILCqLmQcmJGSBqEeLB;

					public int sHrChsivVWSBTKcqDJzOCDCSxyJEb;

					private int dJJwYUxEppaBvjBdFjMZkYTTWDSEA;

					public int jOTkrlPKluLhbIEngnHDVdMcGRKd;

					private IList<_0001> jwhENbgsZdxAyDjagUMBNTKegkrL;

					private int NgYlFvBaqSORvGepijhLAaLudnbYA;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return AJjVhRpyEqjLPiyUaKjfsDGCbsikA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return AJjVhRpyEqjLPiyUaKjfsDGCbsikA;
						}
					}

					[DebuggerHidden]
					public STWKSkmSjsuDWEyfvBQXzbhJrrhU(int P_0)
					{
						gdSmeFoElKdUXVRmtqQstFhVmayW = P_0;
						ByEnkfXcNpgHsRkYWjwixtHUKYsr = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						jwhENbgsZdxAyDjagUMBNTKegkrL = null;
						gdSmeFoElKdUXVRmtqQstFhVmayW = -2;
					}

					private bool MoveNext()
					{
						int num = gdSmeFoElKdUXVRmtqQstFhVmayW;
						MapHelper zfiEmRewPkmmxafSvcPvmPySXDrY = ZfiEmRewPkmmxafSvcPvmPySXDrY;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							gdSmeFoElKdUXVRmtqQstFhVmayW = -1;
							goto IL_00b9;
						}
						gdSmeFoElKdUXVRmtqQstFhVmayW = -1;
						ControllerType controllerType = GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<_0001>();
						FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = zfiEmRewPkmmxafSvcPvmPySXDrY.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType);
						int num2 = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(tQvuKqhwtMILCqLmQcmJGSBqEeLB);
						if (num2 < 0)
						{
							return false;
						}
						jwhENbgsZdxAyDjagUMBNTKegkrL = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num2).ahBHvaaFKqjYqOJIXAFDIKodzptCA.xGdWoIVtuYrQWDwxqcDfPVcUawiR<_0001>();
						NgYlFvBaqSORvGepijhLAaLudnbYA = 0;
						goto IL_00cb;
						IL_00cb:
						if (NgYlFvBaqSORvGepijhLAaLudnbYA < jwhENbgsZdxAyDjagUMBNTKegkrL.Count)
						{
							if (jwhENbgsZdxAyDjagUMBNTKegkrL[NgYlFvBaqSORvGepijhLAaLudnbYA].categoryId == dJJwYUxEppaBvjBdFjMZkYTTWDSEA)
							{
								AJjVhRpyEqjLPiyUaKjfsDGCbsikA = jwhENbgsZdxAyDjagUMBNTKegkrL[NgYlFvBaqSORvGepijhLAaLudnbYA];
								gdSmeFoElKdUXVRmtqQstFhVmayW = 1;
								return true;
							}
							goto IL_00b9;
						}
						return false;
						IL_00b9:
						NgYlFvBaqSORvGepijhLAaLudnbYA++;
						goto IL_00cb;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<_0001> IEnumerable<_0001>.GetEnumerator()
					{
						STWKSkmSjsuDWEyfvBQXzbhJrrhU<_0001> sTWKSkmSjsuDWEyfvBQXzbhJrrhU;
						if (gdSmeFoElKdUXVRmtqQstFhVmayW == -2 && ByEnkfXcNpgHsRkYWjwixtHUKYsr == Environment.CurrentManagedThreadId)
						{
							gdSmeFoElKdUXVRmtqQstFhVmayW = 0;
							sTWKSkmSjsuDWEyfvBQXzbhJrrhU = this;
						}
						else
						{
							sTWKSkmSjsuDWEyfvBQXzbhJrrhU = new STWKSkmSjsuDWEyfvBQXzbhJrrhU<_0001>(0);
							sTWKSkmSjsuDWEyfvBQXzbhJrrhU.ZfiEmRewPkmmxafSvcPvmPySXDrY = ZfiEmRewPkmmxafSvcPvmPySXDrY;
						}
						sTWKSkmSjsuDWEyfvBQXzbhJrrhU.tQvuKqhwtMILCqLmQcmJGSBqEeLB = sHrChsivVWSBTKcqDJzOCDCSxyJEb;
						sTWKSkmSjsuDWEyfvBQXzbhJrrhU.dJJwYUxEppaBvjBdFjMZkYTTWDSEA = jOTkrlPKluLhbIEngnHDVdMcGRKd;
						return sTWKSkmSjsuDWEyfvBQXzbhJrrhU;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class MoiejmkhIgRlpZwlniBbzoKBgNSW : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int EcBnSCDiTTaCGbbMvjzZzjbPkYGI;

					private ActionElementMap aLSsyqZddeGyWznSCTdJjmqRBHGZ;

					private int aJLiFFbQSerdUTvOJqRHLhjYXdYn;

					public MapHelper WbjOlfDitGWaeHENSGJtwbUXrntV;

					private int AqyCdzNKISLmsxzNmqpNjnJEORhD;

					public int zGdHZIesGgWmPGJmdamxUxpGHYiY;

					private bool rsPgHlxcUGOLqOSsgbkcPBqrpFXy;

					public bool osJuLbkaTcAVoBgwdaAzoQvWCyNR;

					private int xrgCbmfoIVLxQtnKKjnFMoCwcDcAb;

					private int vCRExdSRTNTtAlGfyonHrdBCwJAf;

					private FcTbzUBLOriYHtrisAslcxMVjwzbA AYZqNesdmQXAZnyIOVULWeXNJgzr;

					private int XtndmLEMlnumpovbesvBRLgXydmLA;

					private int tLSbLjbUgVwRwwuezYxLmOLVDIzgb;

					private PQaFgQVynoEJfalLJXDCcVZTEKyx OEZTCsNdrwVuqaxVVbPVAMeGKSEm;

					private int HIwTPKohOsJlNQTesddKomHMNrsJ;

					private int yiditJsozNbyzxEVvGhUANSsDSkb;

					private IEnumerator<ActionElementMap> eTeIYZEWBrtlELSLQsDAvMRvdvmI;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return aLSsyqZddeGyWznSCTdJjmqRBHGZ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aLSsyqZddeGyWznSCTdJjmqRBHGZ;
						}
					}

					[DebuggerHidden]
					public MoiejmkhIgRlpZwlniBbzoKBgNSW(int P_0)
					{
						EcBnSCDiTTaCGbbMvjzZzjbPkYGI = P_0;
						aJLiFFbQSerdUTvOJqRHLhjYXdYn = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int ecBnSCDiTTaCGbbMvjzZzjbPkYGI = EcBnSCDiTTaCGbbMvjzZzjbPkYGI;
						if (ecBnSCDiTTaCGbbMvjzZzjbPkYGI == -3 || ecBnSCDiTTaCGbbMvjzZzjbPkYGI == 1)
						{
							try
							{
							}
							finally
							{
								SatwjFeLXvINuZVStsvkzYBQCEcS();
							}
						}
						AYZqNesdmQXAZnyIOVULWeXNJgzr = null;
						OEZTCsNdrwVuqaxVVbPVAMeGKSEm = null;
						eTeIYZEWBrtlELSLQsDAvMRvdvmI = null;
						EcBnSCDiTTaCGbbMvjzZzjbPkYGI = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int ecBnSCDiTTaCGbbMvjzZzjbPkYGI = EcBnSCDiTTaCGbbMvjzZzjbPkYGI;
							MapHelper wbjOlfDitGWaeHENSGJtwbUXrntV = WbjOlfDitGWaeHENSGJtwbUXrntV;
							if (ecBnSCDiTTaCGbbMvjzZzjbPkYGI != 0)
							{
								if (ecBnSCDiTTaCGbbMvjzZzjbPkYGI != 1)
								{
									return false;
								}
								EcBnSCDiTTaCGbbMvjzZzjbPkYGI = -3;
								goto IL_016c;
							}
							EcBnSCDiTTaCGbbMvjzZzjbPkYGI = -1;
							if (ReInput._id != wbjOlfDitGWaeHENSGJtwbUXrntV.ygQbVjvWgDxIBqyAhSVKpNzECBhf)
							{
								ReInput.CheckInitialized(wbjOlfDitGWaeHENSGJtwbUXrntV.ygQbVjvWgDxIBqyAhSVKpNzECBhf);
								return false;
							}
							if (AqyCdzNKISLmsxzNmqpNjnJEORhD < 0)
							{
								return false;
							}
							xrgCbmfoIVLxQtnKKjnFMoCwcDcAb = wbjOlfDitGWaeHENSGJtwbUXrntV.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb;
							vCRExdSRTNTtAlGfyonHrdBCwJAf = 0;
							goto IL_01ec;
							IL_016c:
							if (eTeIYZEWBrtlELSLQsDAvMRvdvmI.MoveNext())
							{
								ActionElementMap current = eTeIYZEWBrtlELSLQsDAvMRvdvmI.Current;
								aLSsyqZddeGyWznSCTdJjmqRBHGZ = current;
								EcBnSCDiTTaCGbbMvjzZzjbPkYGI = 1;
								return true;
							}
							SatwjFeLXvINuZVStsvkzYBQCEcS();
							eTeIYZEWBrtlELSLQsDAvMRvdvmI = null;
							goto IL_0186;
							IL_0186:
							yiditJsozNbyzxEVvGhUANSsDSkb++;
							goto IL_0198;
							IL_01c2:
							if (tLSbLjbUgVwRwwuezYxLmOLVDIzgb < XtndmLEMlnumpovbesvBRLgXydmLA)
							{
								OEZTCsNdrwVuqaxVVbPVAMeGKSEm = AYZqNesdmQXAZnyIOVULWeXNJgzr.uZavhtXKHVxiCdRnShETRMwAdKdM(tLSbLjbUgVwRwwuezYxLmOLVDIzgb).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
								HIwTPKohOsJlNQTesddKomHMNrsJ = OEZTCsNdrwVuqaxVVbPVAMeGKSEm.IdaghgVqdKwQFNEtDYEijJdcbVHeA;
								yiditJsozNbyzxEVvGhUANSsDSkb = 0;
								goto IL_0198;
							}
							AYZqNesdmQXAZnyIOVULWeXNJgzr = null;
							vCRExdSRTNTtAlGfyonHrdBCwJAf++;
							goto IL_01ec;
							IL_0198:
							if (yiditJsozNbyzxEVvGhUANSsDSkb < HIwTPKohOsJlNQTesddKomHMNrsJ)
							{
								ControllerMap controllerMap = OEZTCsNdrwVuqaxVVbPVAMeGKSEm.AZcUeIZqjwMekNcHfENpgGyCRDcAA(yiditJsozNbyzxEVvGhUANSsDSkb);
								if ((!rsPgHlxcUGOLqOSsgbkcPBqrpFXy || controllerMap.enabled) && controllerMap.ContainsAction(AqyCdzNKISLmsxzNmqpNjnJEORhD))
								{
									eTeIYZEWBrtlELSLQsDAvMRvdvmI = controllerMap.ElementMapsWithAction(AqyCdzNKISLmsxzNmqpNjnJEORhD, rsPgHlxcUGOLqOSsgbkcPBqrpFXy).GetEnumerator();
									EcBnSCDiTTaCGbbMvjzZzjbPkYGI = -3;
									goto IL_016c;
								}
								goto IL_0186;
							}
							OEZTCsNdrwVuqaxVVbPVAMeGKSEm = null;
							tLSbLjbUgVwRwwuezYxLmOLVDIzgb++;
							goto IL_01c2;
							IL_01ec:
							if (vCRExdSRTNTtAlGfyonHrdBCwJAf < xrgCbmfoIVLxQtnKKjnFMoCwcDcAb)
							{
								AYZqNesdmQXAZnyIOVULWeXNJgzr = wbjOlfDitGWaeHENSGJtwbUXrntV.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.YPeyRKgKWPSqEsMokJyVccifhDpb(vCRExdSRTNTtAlGfyonHrdBCwJAf);
								XtndmLEMlnumpovbesvBRLgXydmLA = AYZqNesdmQXAZnyIOVULWeXNJgzr.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
								tLSbLjbUgVwRwwuezYxLmOLVDIzgb = 0;
								goto IL_01c2;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void SatwjFeLXvINuZVStsvkzYBQCEcS()
					{
						EcBnSCDiTTaCGbbMvjzZzjbPkYGI = -1;
						if (eTeIYZEWBrtlELSLQsDAvMRvdvmI != null)
						{
							eTeIYZEWBrtlELSLQsDAvMRvdvmI.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						MoiejmkhIgRlpZwlniBbzoKBgNSW moiejmkhIgRlpZwlniBbzoKBgNSW;
						if (EcBnSCDiTTaCGbbMvjzZzjbPkYGI == -2 && aJLiFFbQSerdUTvOJqRHLhjYXdYn == Environment.CurrentManagedThreadId)
						{
							EcBnSCDiTTaCGbbMvjzZzjbPkYGI = 0;
							moiejmkhIgRlpZwlniBbzoKBgNSW = this;
						}
						else
						{
							moiejmkhIgRlpZwlniBbzoKBgNSW = new MoiejmkhIgRlpZwlniBbzoKBgNSW(0);
							moiejmkhIgRlpZwlniBbzoKBgNSW.WbjOlfDitGWaeHENSGJtwbUXrntV = WbjOlfDitGWaeHENSGJtwbUXrntV;
						}
						moiejmkhIgRlpZwlniBbzoKBgNSW.AqyCdzNKISLmsxzNmqpNjnJEORhD = zGdHZIesGgWmPGJmdamxUxpGHYiY;
						moiejmkhIgRlpZwlniBbzoKBgNSW.rsPgHlxcUGOLqOSsgbkcPBqrpFXy = osJuLbkaTcAVoBgwdaAzoQvWCyNR;
						return moiejmkhIgRlpZwlniBbzoKBgNSW;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class bStLWNEdlYfhlHfttEnpIxsnAJfT : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
				{
					private int udzqVZeMiFVTjFlRsgKsoUaKtNtJ;

					private ActionElementMap JmkBtthvKMQwrpWdKzXSRFATfNQf;

					private int LFevsArDSXSExvpCsTJrwHEzCDGk;

					private IControllerElementTarget SUROGTQMRbdMVSnjShPsXixnNikX;

					public IControllerElementTarget xocSMZIJqkZXfCpXOJrdFHdoPjkl;

					public MapHelper gerBYzyMZYaTXhdLDKemFhvJoiMnb;

					private bool EXLBNIohbXpnwDPRVDDRBOQgyEkfA;

					public bool XHprJhZPMQCjgaBDAsFnkyqKKwLb;

					private bool QogTdPcrcAfwQpBXxRaFYJgbOIEf;

					public bool xrcRxYJrstdlpVXLNZuXdwyMhybe;

					private int dUgzbgTYxDppvzqjaxaoCGwOxoFL;

					public int JJramCpqTweshXdKVgPslEWgjNTb;

					private FcTbzUBLOriYHtrisAslcxMVjwzbA rwtnOgrMMpVytnyAThWbHbLVhEPM;

					private int AFogvZfMvCrLtagpVlGKCYhHkeNTB;

					private int dgbpIgSReiaodtEGqFTdDhkDiSDk;

					private IList<ControllerMap> xPjdynnmxjFelcpxcDUNHRjibMup;

					private int yqbFJMCaSIFKeWCfsnuXbvFyMvwzA;

					private int SWNsGwLszecJFSoOARucRshiVNEc;

					private TempListPool.TList<ActionElementMap> gBxFLmDoHgtTeDuYkIqUMDKizOmU;

					private List<ActionElementMap>.Enumerator StjlqsDlhghiiNpflyfxufCvcEAd;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return JmkBtthvKMQwrpWdKzXSRFATfNQf;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return JmkBtthvKMQwrpWdKzXSRFATfNQf;
						}
					}

					[DebuggerHidden]
					public bStLWNEdlYfhlHfttEnpIxsnAJfT(int P_0)
					{
						udzqVZeMiFVTjFlRsgKsoUaKtNtJ = P_0;
						LFevsArDSXSExvpCsTJrwHEzCDGk = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = udzqVZeMiFVTjFlRsgKsoUaKtNtJ;
						if ((uint)(num - -4) <= 1u || num == 1)
						{
							try
							{
								if (num == -4 || num == 1)
								{
									try
									{
									}
									finally
									{
										GGshnDKkYDDBWrGQXddSYUUeZKhw();
									}
								}
							}
							finally
							{
								ROdVmIJrMggjUJJwyYqxlCvVSpAj();
							}
						}
						rwtnOgrMMpVytnyAThWbHbLVhEPM = null;
						xPjdynnmxjFelcpxcDUNHRjibMup = null;
						gBxFLmDoHgtTeDuYkIqUMDKizOmU = null;
						StjlqsDlhghiiNpflyfxufCvcEAd = default(List<ActionElementMap>.Enumerator);
						udzqVZeMiFVTjFlRsgKsoUaKtNtJ = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = udzqVZeMiFVTjFlRsgKsoUaKtNtJ;
							MapHelper mapHelper = gerBYzyMZYaTXhdLDKemFhvJoiMnb;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								udzqVZeMiFVTjFlRsgKsoUaKtNtJ = -4;
								goto IL_017c;
							}
							udzqVZeMiFVTjFlRsgKsoUaKtNtJ = -1;
							if (SUROGTQMRbdMVSnjShPsXixnNikX == null)
							{
								return false;
							}
							Controller controller = SUROGTQMRbdMVSnjShPsXixnNikX.controller;
							if (controller == null)
							{
								return false;
							}
							rwtnOgrMMpVytnyAThWbHbLVhEPM = mapHelper.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controller.type);
							AFogvZfMvCrLtagpVlGKCYhHkeNTB = rwtnOgrMMpVytnyAThWbHbLVhEPM.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
							dgbpIgSReiaodtEGqFTdDhkDiSDk = 0;
							goto IL_01e4;
							IL_017c:
							if (StjlqsDlhghiiNpflyfxufCvcEAd.MoveNext())
							{
								ActionElementMap current = StjlqsDlhghiiNpflyfxufCvcEAd.Current;
								JmkBtthvKMQwrpWdKzXSRFATfNQf = current;
								udzqVZeMiFVTjFlRsgKsoUaKtNtJ = 1;
								return true;
							}
							GGshnDKkYDDBWrGQXddSYUUeZKhw();
							StjlqsDlhghiiNpflyfxufCvcEAd = default(List<ActionElementMap>.Enumerator);
							ROdVmIJrMggjUJJwyYqxlCvVSpAj();
							gBxFLmDoHgtTeDuYkIqUMDKizOmU = null;
							goto IL_01a8;
							IL_01e4:
							if (dgbpIgSReiaodtEGqFTdDhkDiSDk < AFogvZfMvCrLtagpVlGKCYhHkeNTB)
							{
								PQaFgQVynoEJfalLJXDCcVZTEKyx pQaFgQVynoEJfalLJXDCcVZTEKyx = rwtnOgrMMpVytnyAThWbHbLVhEPM.uZavhtXKHVxiCdRnShETRMwAdKdM(dgbpIgSReiaodtEGqFTdDhkDiSDk).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
								_ = pQaFgQVynoEJfalLJXDCcVZTEKyx.IdaghgVqdKwQFNEtDYEijJdcbVHeA;
								xPjdynnmxjFelcpxcDUNHRjibMup = pQaFgQVynoEJfalLJXDCcVZTEKyx.iBWakmwJlExbdlnUxGRNeGbUfhQo;
								yqbFJMCaSIFKeWCfsnuXbvFyMvwzA = xPjdynnmxjFelcpxcDUNHRjibMup.Count;
								SWNsGwLszecJFSoOARucRshiVNEc = 0;
								goto IL_01ba;
							}
							return false;
							IL_01ba:
							if (SWNsGwLszecJFSoOARucRshiVNEc < yqbFJMCaSIFKeWCfsnuXbvFyMvwzA)
							{
								ControllerMap controllerMap = xPjdynnmxjFelcpxcDUNHRjibMup[SWNsGwLszecJFSoOARucRshiVNEc];
								if (!EXLBNIohbXpnwDPRVDDRBOQgyEkfA || controllerMap.enabled)
								{
									gBxFLmDoHgtTeDuYkIqUMDKizOmU = TempListPool.GetTList<ActionElementMap>();
									udzqVZeMiFVTjFlRsgKsoUaKtNtJ = -3;
									List<ActionElementMap> list = gBxFLmDoHgtTeDuYkIqUMDKizOmU.list;
									controllerMap.GkqChYlZGQOzIisFIMtpFCNiEOLd(SUROGTQMRbdMVSnjShPsXixnNikX, QogTdPcrcAfwQpBXxRaFYJgbOIEf, dUgzbgTYxDppvzqjaxaoCGwOxoFL, EXLBNIohbXpnwDPRVDDRBOQgyEkfA, list, true, out var _);
									StjlqsDlhghiiNpflyfxufCvcEAd = list.GetEnumerator();
									udzqVZeMiFVTjFlRsgKsoUaKtNtJ = -4;
									goto IL_017c;
								}
								goto IL_01a8;
							}
							xPjdynnmxjFelcpxcDUNHRjibMup = null;
							dgbpIgSReiaodtEGqFTdDhkDiSDk++;
							goto IL_01e4;
							IL_01a8:
							SWNsGwLszecJFSoOARucRshiVNEc++;
							goto IL_01ba;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void ROdVmIJrMggjUJJwyYqxlCvVSpAj()
					{
						udzqVZeMiFVTjFlRsgKsoUaKtNtJ = -1;
						if (gBxFLmDoHgtTeDuYkIqUMDKizOmU != null)
						{
							((IDisposable)gBxFLmDoHgtTeDuYkIqUMDKizOmU).Dispose();
						}
					}

					private void GGshnDKkYDDBWrGQXddSYUUeZKhw()
					{
						udzqVZeMiFVTjFlRsgKsoUaKtNtJ = -3;
						((IDisposable)StjlqsDlhghiiNpflyfxufCvcEAd/*cast due to .constrained prefix*/).Dispose();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						bStLWNEdlYfhlHfttEnpIxsnAJfT bStLWNEdlYfhlHfttEnpIxsnAJfT2;
						if (udzqVZeMiFVTjFlRsgKsoUaKtNtJ == -2 && LFevsArDSXSExvpCsTJrwHEzCDGk == Environment.CurrentManagedThreadId)
						{
							udzqVZeMiFVTjFlRsgKsoUaKtNtJ = 0;
							bStLWNEdlYfhlHfttEnpIxsnAJfT2 = this;
						}
						else
						{
							bStLWNEdlYfhlHfttEnpIxsnAJfT2 = new bStLWNEdlYfhlHfttEnpIxsnAJfT(0);
							bStLWNEdlYfhlHfttEnpIxsnAJfT2.gerBYzyMZYaTXhdLDKemFhvJoiMnb = gerBYzyMZYaTXhdLDKemFhvJoiMnb;
						}
						bStLWNEdlYfhlHfttEnpIxsnAJfT2.SUROGTQMRbdMVSnjShPsXixnNikX = xocSMZIJqkZXfCpXOJrdFHdoPjkl;
						bStLWNEdlYfhlHfttEnpIxsnAJfT2.QogTdPcrcAfwQpBXxRaFYJgbOIEf = xrcRxYJrstdlpVXLNZuXdwyMhybe;
						bStLWNEdlYfhlHfttEnpIxsnAJfT2.dUgzbgTYxDppvzqjaxaoCGwOxoFL = JJramCpqTweshXdKVgPslEWgjNTb;
						bStLWNEdlYfhlHfttEnpIxsnAJfT2.EXLBNIohbXpnwDPRVDDRBOQgyEkfA = XHprJhZPMQCjgaBDAsFnkyqKKwLb;
						return bStLWNEdlYfhlHfttEnpIxsnAJfT2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}
				}

				private sealed class oSCMYPviskACZIRJvEWvxoiAdODg : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int RGxDDZiXwAyOkethYjHMpdkZSCeVA;

					private ControllerMap LuFWVpguovHFrOnqJtCgCIjCwVVd;

					private int AJAhlmeeOTPxizfVGBsFNtrFEFdQ;

					public MapHelper cBJyPHGWmFauVrBgrGtrgpCPzJumA;

					private int fgkCxNETlXoqcKJUSWdMWVrLjlWG;

					private int OmBeVQXBpihJQGSkEoAYVPqhnFjAb;

					private FcTbzUBLOriYHtrisAslcxMVjwzbA IupfhkccqdWkUTUdGyhjkVyGCbWmA;

					private int GfxHTrdeMGFNkbyUZPOeOwsYUbOOA;

					private int AtEShQKUrQvqwMLroLPgtIVUemUk;

					private PQaFgQVynoEJfalLJXDCcVZTEKyx SQObAVZBEyEKoSwwpdaCGrOWTphlA;

					private int kqFtPQiUOrsjlgaxFxvBVBuIzlHs;

					private int EudJONccZGaEsfQzTUjfIpaCDyJB;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return LuFWVpguovHFrOnqJtCgCIjCwVVd;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return LuFWVpguovHFrOnqJtCgCIjCwVVd;
						}
					}

					[DebuggerHidden]
					public oSCMYPviskACZIRJvEWvxoiAdODg(int P_0)
					{
						RGxDDZiXwAyOkethYjHMpdkZSCeVA = P_0;
						AJAhlmeeOTPxizfVGBsFNtrFEFdQ = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						IupfhkccqdWkUTUdGyhjkVyGCbWmA = null;
						SQObAVZBEyEKoSwwpdaCGrOWTphlA = null;
						RGxDDZiXwAyOkethYjHMpdkZSCeVA = -2;
					}

					private bool MoveNext()
					{
						int rGxDDZiXwAyOkethYjHMpdkZSCeVA = RGxDDZiXwAyOkethYjHMpdkZSCeVA;
						MapHelper mapHelper = cBJyPHGWmFauVrBgrGtrgpCPzJumA;
						if (rGxDDZiXwAyOkethYjHMpdkZSCeVA != 0)
						{
							if (rGxDDZiXwAyOkethYjHMpdkZSCeVA != 1)
							{
								return false;
							}
							RGxDDZiXwAyOkethYjHMpdkZSCeVA = -1;
							EudJONccZGaEsfQzTUjfIpaCDyJB++;
							goto IL_0104;
						}
						RGxDDZiXwAyOkethYjHMpdkZSCeVA = -1;
						if (ReInput._id != mapHelper.ygQbVjvWgDxIBqyAhSVKpNzECBhf)
						{
							ReInput.CheckInitialized(mapHelper.ygQbVjvWgDxIBqyAhSVKpNzECBhf);
							return false;
						}
						fgkCxNETlXoqcKJUSWdMWVrLjlWG = mapHelper.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb;
						OmBeVQXBpihJQGSkEoAYVPqhnFjAb = 0;
						goto IL_0151;
						IL_0104:
						if (EudJONccZGaEsfQzTUjfIpaCDyJB < kqFtPQiUOrsjlgaxFxvBVBuIzlHs)
						{
							LuFWVpguovHFrOnqJtCgCIjCwVVd = SQObAVZBEyEKoSwwpdaCGrOWTphlA.AZcUeIZqjwMekNcHfENpgGyCRDcAA(EudJONccZGaEsfQzTUjfIpaCDyJB);
							RGxDDZiXwAyOkethYjHMpdkZSCeVA = 1;
							return true;
						}
						SQObAVZBEyEKoSwwpdaCGrOWTphlA = null;
						AtEShQKUrQvqwMLroLPgtIVUemUk++;
						goto IL_0129;
						IL_0129:
						if (AtEShQKUrQvqwMLroLPgtIVUemUk < GfxHTrdeMGFNkbyUZPOeOwsYUbOOA)
						{
							SQObAVZBEyEKoSwwpdaCGrOWTphlA = IupfhkccqdWkUTUdGyhjkVyGCbWmA.uZavhtXKHVxiCdRnShETRMwAdKdM(AtEShQKUrQvqwMLroLPgtIVUemUk).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
							kqFtPQiUOrsjlgaxFxvBVBuIzlHs = SQObAVZBEyEKoSwwpdaCGrOWTphlA.IdaghgVqdKwQFNEtDYEijJdcbVHeA;
							EudJONccZGaEsfQzTUjfIpaCDyJB = 0;
							goto IL_0104;
						}
						IupfhkccqdWkUTUdGyhjkVyGCbWmA = null;
						OmBeVQXBpihJQGSkEoAYVPqhnFjAb++;
						goto IL_0151;
						IL_0151:
						if (OmBeVQXBpihJQGSkEoAYVPqhnFjAb < fgkCxNETlXoqcKJUSWdMWVrLjlWG)
						{
							IupfhkccqdWkUTUdGyhjkVyGCbWmA = mapHelper.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.YPeyRKgKWPSqEsMokJyVccifhDpb(OmBeVQXBpihJQGSkEoAYVPqhnFjAb);
							GfxHTrdeMGFNkbyUZPOeOwsYUbOOA = IupfhkccqdWkUTUdGyhjkVyGCbWmA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
							AtEShQKUrQvqwMLroLPgtIVUemUk = 0;
							goto IL_0129;
						}
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
					{
						oSCMYPviskACZIRJvEWvxoiAdODg oSCMYPviskACZIRJvEWvxoiAdODg2;
						if (RGxDDZiXwAyOkethYjHMpdkZSCeVA == -2 && AJAhlmeeOTPxizfVGBsFNtrFEFdQ == Environment.CurrentManagedThreadId)
						{
							RGxDDZiXwAyOkethYjHMpdkZSCeVA = 0;
							oSCMYPviskACZIRJvEWvxoiAdODg2 = this;
						}
						else
						{
							oSCMYPviskACZIRJvEWvxoiAdODg2 = new oSCMYPviskACZIRJvEWvxoiAdODg(0);
							oSCMYPviskACZIRJvEWvxoiAdODg2.cBJyPHGWmFauVrBgrGtrgpCPzJumA = cBJyPHGWmFauVrBgrGtrgpCPzJumA;
						}
						return oSCMYPviskACZIRJvEWvxoiAdODg2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class fVTODejFodpBghdpcOgSYhGUfAQV<_0001> : IEnumerable<_0001>, IEnumerable, IEnumerator<_0001>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int WXjbYCpYXASudqQKlZdzBckuUhgV;

					private _0001 SljfReqcCFIVMonbXBnoFqTEmNlcA;

					private int HwZdUEEsBbjwaaAYAdBBKNgdKqne;

					public MapHelper IPHAFDelqiLMEuOZucMwenhhQwvC;

					private FcTbzUBLOriYHtrisAslcxMVjwzbA pjzWjgDzqwQuEYOgnjSoGJagCdZT;

					private int oQFtqLdsVBodPwCRJEwgOQtBBPagA;

					private int vmFKnUqJUYgJtDnIfcXwAtRLWxmB;

					private PQaFgQVynoEJfalLJXDCcVZTEKyx EDPrqMIXhJaaBWnPLcqhjRWQrqEI;

					private int BnlBWbQrgNDMPzHIIVqFmhSfhHaA;

					private int StwUABvFpJtoutduRiHHULinvYYL;

					private int YmiBwXXNJrKsOcVZjBHYvyuvQnWd;

					private int ClkRjiwoTWCaSgKogBQETstiDjVP;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return SljfReqcCFIVMonbXBnoFqTEmNlcA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return SljfReqcCFIVMonbXBnoFqTEmNlcA;
						}
					}

					[DebuggerHidden]
					public fVTODejFodpBghdpcOgSYhGUfAQV(int P_0)
					{
						WXjbYCpYXASudqQKlZdzBckuUhgV = P_0;
						HwZdUEEsBbjwaaAYAdBBKNgdKqne = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						pjzWjgDzqwQuEYOgnjSoGJagCdZT = null;
						EDPrqMIXhJaaBWnPLcqhjRWQrqEI = null;
						WXjbYCpYXASudqQKlZdzBckuUhgV = -2;
					}

					private bool MoveNext()
					{
						int wXjbYCpYXASudqQKlZdzBckuUhgV = WXjbYCpYXASudqQKlZdzBckuUhgV;
						MapHelper iPHAFDelqiLMEuOZucMwenhhQwvC = IPHAFDelqiLMEuOZucMwenhhQwvC;
						switch (wXjbYCpYXASudqQKlZdzBckuUhgV)
						{
						default:
							return false;
						case 0:
						{
							WXjbYCpYXASudqQKlZdzBckuUhgV = -1;
							if (ReInput._id != iPHAFDelqiLMEuOZucMwenhhQwvC.ygQbVjvWgDxIBqyAhSVKpNzECBhf)
							{
								ReInput.CheckInitialized(iPHAFDelqiLMEuOZucMwenhhQwvC.ygQbVjvWgDxIBqyAhSVKpNzECBhf);
								return false;
							}
							if (GHPcAvLGyrhUIIuLWeQoyFTYgunBA.aWYfWZqScAuOOIyDChJOpWMiEjFC<_0001>(out var controllerType))
							{
								pjzWjgDzqwQuEYOgnjSoGJagCdZT = iPHAFDelqiLMEuOZucMwenhhQwvC.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType);
								oQFtqLdsVBodPwCRJEwgOQtBBPagA = pjzWjgDzqwQuEYOgnjSoGJagCdZT.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
								vmFKnUqJUYgJtDnIfcXwAtRLWxmB = 0;
								goto IL_011b;
							}
							oQFtqLdsVBodPwCRJEwgOQtBBPagA = iPHAFDelqiLMEuOZucMwenhhQwvC.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb;
							vmFKnUqJUYgJtDnIfcXwAtRLWxmB = 0;
							goto IL_0264;
						}
						case 1:
							WXjbYCpYXASudqQKlZdzBckuUhgV = -1;
							StwUABvFpJtoutduRiHHULinvYYL++;
							goto IL_00f6;
						case 2:
							{
								WXjbYCpYXASudqQKlZdzBckuUhgV = -1;
								goto IL_0207;
							}
							IL_0207:
							ClkRjiwoTWCaSgKogBQETstiDjVP++;
							goto IL_0217;
							IL_0264:
							if (vmFKnUqJUYgJtDnIfcXwAtRLWxmB >= oQFtqLdsVBodPwCRJEwgOQtBBPagA)
							{
								break;
							}
							pjzWjgDzqwQuEYOgnjSoGJagCdZT = iPHAFDelqiLMEuOZucMwenhhQwvC.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.YPeyRKgKWPSqEsMokJyVccifhDpb(vmFKnUqJUYgJtDnIfcXwAtRLWxmB);
							BnlBWbQrgNDMPzHIIVqFmhSfhHaA = pjzWjgDzqwQuEYOgnjSoGJagCdZT.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
							StwUABvFpJtoutduRiHHULinvYYL = 0;
							goto IL_023c;
							IL_011b:
							if (vmFKnUqJUYgJtDnIfcXwAtRLWxmB < oQFtqLdsVBodPwCRJEwgOQtBBPagA)
							{
								EDPrqMIXhJaaBWnPLcqhjRWQrqEI = pjzWjgDzqwQuEYOgnjSoGJagCdZT.uZavhtXKHVxiCdRnShETRMwAdKdM(vmFKnUqJUYgJtDnIfcXwAtRLWxmB).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
								BnlBWbQrgNDMPzHIIVqFmhSfhHaA = EDPrqMIXhJaaBWnPLcqhjRWQrqEI.IdaghgVqdKwQFNEtDYEijJdcbVHeA;
								StwUABvFpJtoutduRiHHULinvYYL = 0;
								goto IL_00f6;
							}
							pjzWjgDzqwQuEYOgnjSoGJagCdZT = null;
							break;
							IL_0217:
							if (ClkRjiwoTWCaSgKogBQETstiDjVP < YmiBwXXNJrKsOcVZjBHYvyuvQnWd)
							{
								if (EDPrqMIXhJaaBWnPLcqhjRWQrqEI.AZcUeIZqjwMekNcHfENpgGyCRDcAA(ClkRjiwoTWCaSgKogBQETstiDjVP) is _0001 sljfReqcCFIVMonbXBnoFqTEmNlcA)
								{
									SljfReqcCFIVMonbXBnoFqTEmNlcA = sljfReqcCFIVMonbXBnoFqTEmNlcA;
									WXjbYCpYXASudqQKlZdzBckuUhgV = 2;
									return true;
								}
								goto IL_0207;
							}
							EDPrqMIXhJaaBWnPLcqhjRWQrqEI = null;
							StwUABvFpJtoutduRiHHULinvYYL++;
							goto IL_023c;
							IL_023c:
							if (StwUABvFpJtoutduRiHHULinvYYL < BnlBWbQrgNDMPzHIIVqFmhSfhHaA)
							{
								EDPrqMIXhJaaBWnPLcqhjRWQrqEI = pjzWjgDzqwQuEYOgnjSoGJagCdZT.uZavhtXKHVxiCdRnShETRMwAdKdM(StwUABvFpJtoutduRiHHULinvYYL).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
								YmiBwXXNJrKsOcVZjBHYvyuvQnWd = EDPrqMIXhJaaBWnPLcqhjRWQrqEI.IdaghgVqdKwQFNEtDYEijJdcbVHeA;
								ClkRjiwoTWCaSgKogBQETstiDjVP = 0;
								goto IL_0217;
							}
							pjzWjgDzqwQuEYOgnjSoGJagCdZT = null;
							vmFKnUqJUYgJtDnIfcXwAtRLWxmB++;
							goto IL_0264;
							IL_00f6:
							if (StwUABvFpJtoutduRiHHULinvYYL < BnlBWbQrgNDMPzHIIVqFmhSfhHaA)
							{
								SljfReqcCFIVMonbXBnoFqTEmNlcA = (_0001)EDPrqMIXhJaaBWnPLcqhjRWQrqEI.AZcUeIZqjwMekNcHfENpgGyCRDcAA(StwUABvFpJtoutduRiHHULinvYYL);
								WXjbYCpYXASudqQKlZdzBckuUhgV = 1;
								return true;
							}
							EDPrqMIXhJaaBWnPLcqhjRWQrqEI = null;
							vmFKnUqJUYgJtDnIfcXwAtRLWxmB++;
							goto IL_011b;
						}
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<_0001> IEnumerable<_0001>.GetEnumerator()
					{
						fVTODejFodpBghdpcOgSYhGUfAQV<_0001> fVTODejFodpBghdpcOgSYhGUfAQV2;
						if (WXjbYCpYXASudqQKlZdzBckuUhgV == -2 && HwZdUEEsBbjwaaAYAdBBKNgdKqne == Environment.CurrentManagedThreadId)
						{
							WXjbYCpYXASudqQKlZdzBckuUhgV = 0;
							fVTODejFodpBghdpcOgSYhGUfAQV2 = this;
						}
						else
						{
							fVTODejFodpBghdpcOgSYhGUfAQV2 = new fVTODejFodpBghdpcOgSYhGUfAQV<_0001>(0);
							fVTODejFodpBghdpcOgSYhGUfAQV2.IPHAFDelqiLMEuOZucMwenhhQwvC = IPHAFDelqiLMEuOZucMwenhhQwvC;
						}
						return fVTODejFodpBghdpcOgSYhGUfAQV2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class JHLFNjDcczgwaAbqyuFIdXjnxObE : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int jRdECqllSgXbmkMddtFeAXeZWkaM;

					private ControllerMap aMSjDUZtCDdhZgnkqiHqDkCKTJuHA;

					private int uIUGsvGSSgKLqtWXXhxikUuFSaifA;

					public MapHelper NZXeeXbGUwKMhACHggQTgpfqZoOHB;

					private ControllerType HPZtAIIeIrGVfgGugDBDEdcfPqzq;

					public ControllerType IYFstRiyQKjFqkOWVxsWxCbHRmaH;

					private FcTbzUBLOriYHtrisAslcxMVjwzbA CIvOsumRWHEHFPCzRYpeKmCOICVe;

					private int PwgVwbAbpREojUWKUOUCKLLZpOWK;

					private int OuLevHzVAhPiUMLniSvDCRNHMIRm;

					private PQaFgQVynoEJfalLJXDCcVZTEKyx zGwCwpLESMGXTkwXDYBDzknGqrrK;

					private int fNXyMypOrunvzsXNOoNKUCllTyJB;

					private int YeJBARAGDgRHmiuqDTzuIoCBOTmWA;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return aMSjDUZtCDdhZgnkqiHqDkCKTJuHA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aMSjDUZtCDdhZgnkqiHqDkCKTJuHA;
						}
					}

					[DebuggerHidden]
					public JHLFNjDcczgwaAbqyuFIdXjnxObE(int P_0)
					{
						jRdECqllSgXbmkMddtFeAXeZWkaM = P_0;
						uIUGsvGSSgKLqtWXXhxikUuFSaifA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						CIvOsumRWHEHFPCzRYpeKmCOICVe = null;
						zGwCwpLESMGXTkwXDYBDzknGqrrK = null;
						jRdECqllSgXbmkMddtFeAXeZWkaM = -2;
					}

					private bool MoveNext()
					{
						int num = jRdECqllSgXbmkMddtFeAXeZWkaM;
						MapHelper nZXeeXbGUwKMhACHggQTgpfqZoOHB = NZXeeXbGUwKMhACHggQTgpfqZoOHB;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							jRdECqllSgXbmkMddtFeAXeZWkaM = -1;
							YeJBARAGDgRHmiuqDTzuIoCBOTmWA++;
							goto IL_00e2;
						}
						jRdECqllSgXbmkMddtFeAXeZWkaM = -1;
						if (ReInput._id != nZXeeXbGUwKMhACHggQTgpfqZoOHB.ygQbVjvWgDxIBqyAhSVKpNzECBhf)
						{
							ReInput.CheckInitialized(nZXeeXbGUwKMhACHggQTgpfqZoOHB.ygQbVjvWgDxIBqyAhSVKpNzECBhf);
							return false;
						}
						CIvOsumRWHEHFPCzRYpeKmCOICVe = nZXeeXbGUwKMhACHggQTgpfqZoOHB.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(HPZtAIIeIrGVfgGugDBDEdcfPqzq);
						PwgVwbAbpREojUWKUOUCKLLZpOWK = CIvOsumRWHEHFPCzRYpeKmCOICVe.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
						OuLevHzVAhPiUMLniSvDCRNHMIRm = 0;
						goto IL_0107;
						IL_00e2:
						if (YeJBARAGDgRHmiuqDTzuIoCBOTmWA < fNXyMypOrunvzsXNOoNKUCllTyJB)
						{
							aMSjDUZtCDdhZgnkqiHqDkCKTJuHA = zGwCwpLESMGXTkwXDYBDzknGqrrK.AZcUeIZqjwMekNcHfENpgGyCRDcAA(YeJBARAGDgRHmiuqDTzuIoCBOTmWA);
							jRdECqllSgXbmkMddtFeAXeZWkaM = 1;
							return true;
						}
						zGwCwpLESMGXTkwXDYBDzknGqrrK = null;
						OuLevHzVAhPiUMLniSvDCRNHMIRm++;
						goto IL_0107;
						IL_0107:
						if (OuLevHzVAhPiUMLniSvDCRNHMIRm < PwgVwbAbpREojUWKUOUCKLLZpOWK)
						{
							zGwCwpLESMGXTkwXDYBDzknGqrrK = CIvOsumRWHEHFPCzRYpeKmCOICVe.uZavhtXKHVxiCdRnShETRMwAdKdM(OuLevHzVAhPiUMLniSvDCRNHMIRm).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
							fNXyMypOrunvzsXNOoNKUCllTyJB = zGwCwpLESMGXTkwXDYBDzknGqrrK.IdaghgVqdKwQFNEtDYEijJdcbVHeA;
							YeJBARAGDgRHmiuqDTzuIoCBOTmWA = 0;
							goto IL_00e2;
						}
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
					{
						JHLFNjDcczgwaAbqyuFIdXjnxObE jHLFNjDcczgwaAbqyuFIdXjnxObE;
						if (jRdECqllSgXbmkMddtFeAXeZWkaM == -2 && uIUGsvGSSgKLqtWXXhxikUuFSaifA == Environment.CurrentManagedThreadId)
						{
							jRdECqllSgXbmkMddtFeAXeZWkaM = 0;
							jHLFNjDcczgwaAbqyuFIdXjnxObE = this;
						}
						else
						{
							jHLFNjDcczgwaAbqyuFIdXjnxObE = new JHLFNjDcczgwaAbqyuFIdXjnxObE(0);
							jHLFNjDcczgwaAbqyuFIdXjnxObE.NZXeeXbGUwKMhACHggQTgpfqZoOHB = NZXeeXbGUwKMhACHggQTgpfqZoOHB;
						}
						jHLFNjDcczgwaAbqyuFIdXjnxObE.HPZtAIIeIrGVfgGugDBDEdcfPqzq = IYFstRiyQKjFqkOWVxsWxCbHRmaH;
						return jHLFNjDcczgwaAbqyuFIdXjnxObE;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class QBkGGBBmNyOaJaOsbQKAmtRiFXXpA : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int sAnchciZOumdluivHxJJRypSRfKI;

					private ControllerMap jkQFLJgAVrdJJwsaiPUUJFjgJMZdb;

					private int ohGGnDhXXHzCvTkDaujPxCntiErb;

					public MapHelper hcwtAERXQSAtpojloBiqOXhWbtFF;

					private int NPMxTsEBefQvjGcUcmayvbaHVgiv;

					public int dmCGTtgMrORzZYkEgRyoDdzvMPaY;

					private int uelzEzKHBUxxoLKOjLqkeCCKwgzQ;

					private int GGyTxrTLNhtyPDAIKJRmGBAIKFgr;

					private FcTbzUBLOriYHtrisAslcxMVjwzbA DwEIuTRjmDivoDbWidgIufxXJZRf;

					private int keXjDLIisCjXjBqMRWKEGmrIJAQJ;

					private int VxfmmeEqORihQaUEVbTmEFUXKxaNA;

					private PQaFgQVynoEJfalLJXDCcVZTEKyx boiNvIxArySIPlyOlQRFOFIyBAqhA;

					private int dhRfDkbkcmwiviqtrUANzQmicGZg;

					private int AunGACjzBzslXFcEpqhuBtHgIKDoB;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return jkQFLJgAVrdJJwsaiPUUJFjgJMZdb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return jkQFLJgAVrdJJwsaiPUUJFjgJMZdb;
						}
					}

					[DebuggerHidden]
					public QBkGGBBmNyOaJaOsbQKAmtRiFXXpA(int P_0)
					{
						sAnchciZOumdluivHxJJRypSRfKI = P_0;
						ohGGnDhXXHzCvTkDaujPxCntiErb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						DwEIuTRjmDivoDbWidgIufxXJZRf = null;
						boiNvIxArySIPlyOlQRFOFIyBAqhA = null;
						sAnchciZOumdluivHxJJRypSRfKI = -2;
					}

					private bool MoveNext()
					{
						int num = sAnchciZOumdluivHxJJRypSRfKI;
						MapHelper mapHelper = hcwtAERXQSAtpojloBiqOXhWbtFF;
						if (num != 0)
						{
							if (num != 1)
							{
								return false;
							}
							sAnchciZOumdluivHxJJRypSRfKI = -1;
							goto IL_0104;
						}
						sAnchciZOumdluivHxJJRypSRfKI = -1;
						if (ReInput._id != mapHelper.ygQbVjvWgDxIBqyAhSVKpNzECBhf)
						{
							ReInput.CheckInitialized(mapHelper.ygQbVjvWgDxIBqyAhSVKpNzECBhf);
							return false;
						}
						uelzEzKHBUxxoLKOjLqkeCCKwgzQ = mapHelper.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb;
						GGyTxrTLNhtyPDAIKJRmGBAIKFgr = 0;
						goto IL_0161;
						IL_0104:
						AunGACjzBzslXFcEpqhuBtHgIKDoB++;
						goto IL_0114;
						IL_0161:
						if (GGyTxrTLNhtyPDAIKJRmGBAIKFgr < uelzEzKHBUxxoLKOjLqkeCCKwgzQ)
						{
							DwEIuTRjmDivoDbWidgIufxXJZRf = mapHelper.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.YPeyRKgKWPSqEsMokJyVccifhDpb(GGyTxrTLNhtyPDAIKJRmGBAIKFgr);
							keXjDLIisCjXjBqMRWKEGmrIJAQJ = DwEIuTRjmDivoDbWidgIufxXJZRf.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
							VxfmmeEqORihQaUEVbTmEFUXKxaNA = 0;
							goto IL_0139;
						}
						return false;
						IL_0114:
						if (AunGACjzBzslXFcEpqhuBtHgIKDoB < dhRfDkbkcmwiviqtrUANzQmicGZg)
						{
							ControllerMap controllerMap = boiNvIxArySIPlyOlQRFOFIyBAqhA.AZcUeIZqjwMekNcHfENpgGyCRDcAA(AunGACjzBzslXFcEpqhuBtHgIKDoB);
							if (controllerMap.categoryId == NPMxTsEBefQvjGcUcmayvbaHVgiv)
							{
								jkQFLJgAVrdJJwsaiPUUJFjgJMZdb = controllerMap;
								sAnchciZOumdluivHxJJRypSRfKI = 1;
								return true;
							}
							goto IL_0104;
						}
						boiNvIxArySIPlyOlQRFOFIyBAqhA = null;
						VxfmmeEqORihQaUEVbTmEFUXKxaNA++;
						goto IL_0139;
						IL_0139:
						if (VxfmmeEqORihQaUEVbTmEFUXKxaNA < keXjDLIisCjXjBqMRWKEGmrIJAQJ)
						{
							boiNvIxArySIPlyOlQRFOFIyBAqhA = DwEIuTRjmDivoDbWidgIufxXJZRf.uZavhtXKHVxiCdRnShETRMwAdKdM(VxfmmeEqORihQaUEVbTmEFUXKxaNA).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
							dhRfDkbkcmwiviqtrUANzQmicGZg = boiNvIxArySIPlyOlQRFOFIyBAqhA.IdaghgVqdKwQFNEtDYEijJdcbVHeA;
							AunGACjzBzslXFcEpqhuBtHgIKDoB = 0;
							goto IL_0114;
						}
						DwEIuTRjmDivoDbWidgIufxXJZRf = null;
						GGyTxrTLNhtyPDAIKJRmGBAIKFgr++;
						goto IL_0161;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
					{
						QBkGGBBmNyOaJaOsbQKAmtRiFXXpA qBkGGBBmNyOaJaOsbQKAmtRiFXXpA;
						if (sAnchciZOumdluivHxJJRypSRfKI == -2 && ohGGnDhXXHzCvTkDaujPxCntiErb == Environment.CurrentManagedThreadId)
						{
							sAnchciZOumdluivHxJJRypSRfKI = 0;
							qBkGGBBmNyOaJaOsbQKAmtRiFXXpA = this;
						}
						else
						{
							qBkGGBBmNyOaJaOsbQKAmtRiFXXpA = new QBkGGBBmNyOaJaOsbQKAmtRiFXXpA(0);
							qBkGGBBmNyOaJaOsbQKAmtRiFXXpA.hcwtAERXQSAtpojloBiqOXhWbtFF = hcwtAERXQSAtpojloBiqOXhWbtFF;
						}
						qBkGGBBmNyOaJaOsbQKAmtRiFXXpA.NPMxTsEBefQvjGcUcmayvbaHVgiv = dmCGTtgMrORzZYkEgRyoDdzvMPaY;
						return qBkGGBBmNyOaJaOsbQKAmtRiFXXpA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private sealed class OgRPCEyOCIYvDxrTegSIqaiTjQWI<_0001> : IEnumerable<_0001>, IEnumerable, IEnumerator<_0001>, IEnumerator, IDisposable where _0001 : ControllerMap
				{
					private int oBloewYaSnECPPNmMRQROdSWCgKkA;

					private _0001 YnxrqXHBwhDgHfoaVNUNRNuEpMxn;

					private int vBEEPeBiHuErANizCSUUKLpVncmq;

					public MapHelper nxkPWXjanhfIYOeQJCvHAlydCLwbb;

					private int skUzlBhKAgIHGAOKQgWRBtLkYCAfb;

					public int EaFzKxpxvogfZbqfKiiEvxXXfARHA;

					private FcTbzUBLOriYHtrisAslcxMVjwzbA OwdPldeEpDwYxZZisOIIncnJOZNt;

					private int OAzCYvtrCCgQtwIPkmyRzCEgIKv;

					private int UFkLdCZCPYCdrSlVCrvQNRbGABig;

					private PQaFgQVynoEJfalLJXDCcVZTEKyx qsFhZWArruDTAaJzMRIKypQbMMzh;

					private int rEOKbhkrWOrZAKXJEVVrMvpowYNC;

					private int QCfqBDNmLRtShyIzfrSFkRuEfWpO;

					private int NLLzvuhbwOGqjJSnzzvVSTjWxHcj;

					private int ATsDhxQWgTQFwVfHqfnTBqlZNIHcA;

					_0001 IEnumerator<_0001>.Current
					{
						[DebuggerHidden]
						get
						{
							return YnxrqXHBwhDgHfoaVNUNRNuEpMxn;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return YnxrqXHBwhDgHfoaVNUNRNuEpMxn;
						}
					}

					[DebuggerHidden]
					public OgRPCEyOCIYvDxrTegSIqaiTjQWI(int P_0)
					{
						oBloewYaSnECPPNmMRQROdSWCgKkA = P_0;
						vBEEPeBiHuErANizCSUUKLpVncmq = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						OwdPldeEpDwYxZZisOIIncnJOZNt = null;
						qsFhZWArruDTAaJzMRIKypQbMMzh = null;
						oBloewYaSnECPPNmMRQROdSWCgKkA = -2;
					}

					private bool MoveNext()
					{
						int num = oBloewYaSnECPPNmMRQROdSWCgKkA;
						MapHelper mapHelper = nxkPWXjanhfIYOeQJCvHAlydCLwbb;
						switch (num)
						{
						default:
							return false;
						case 0:
						{
							oBloewYaSnECPPNmMRQROdSWCgKkA = -1;
							if (ReInput._id != mapHelper.ygQbVjvWgDxIBqyAhSVKpNzECBhf)
							{
								ReInput.CheckInitialized(mapHelper.ygQbVjvWgDxIBqyAhSVKpNzECBhf);
								return false;
							}
							if (GHPcAvLGyrhUIIuLWeQoyFTYgunBA.aWYfWZqScAuOOIyDChJOpWMiEjFC<_0001>(out var _))
							{
								OwdPldeEpDwYxZZisOIIncnJOZNt = mapHelper.zzRfMCXrJAAZIhKRwDfufvjgrfEqb<_0001>();
								OAzCYvtrCCgQtwIPkmyRzCEgIKv = OwdPldeEpDwYxZZisOIIncnJOZNt.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
								UFkLdCZCPYCdrSlVCrvQNRbGABig = 0;
								goto IL_0124;
							}
							OAzCYvtrCCgQtwIPkmyRzCEgIKv = mapHelper.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb;
							UFkLdCZCPYCdrSlVCrvQNRbGABig = 0;
							goto IL_0287;
						}
						case 1:
							oBloewYaSnECPPNmMRQROdSWCgKkA = -1;
							goto IL_00eb;
						case 2:
							{
								oBloewYaSnECPPNmMRQROdSWCgKkA = -1;
								goto IL_0224;
							}
							IL_0224:
							ATsDhxQWgTQFwVfHqfnTBqlZNIHcA++;
							goto IL_0236;
							IL_00eb:
							QCfqBDNmLRtShyIzfrSFkRuEfWpO++;
							goto IL_00fd;
							IL_0124:
							if (UFkLdCZCPYCdrSlVCrvQNRbGABig < OAzCYvtrCCgQtwIPkmyRzCEgIKv)
							{
								qsFhZWArruDTAaJzMRIKypQbMMzh = OwdPldeEpDwYxZZisOIIncnJOZNt.uZavhtXKHVxiCdRnShETRMwAdKdM(UFkLdCZCPYCdrSlVCrvQNRbGABig).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
								rEOKbhkrWOrZAKXJEVVrMvpowYNC = qsFhZWArruDTAaJzMRIKypQbMMzh.IdaghgVqdKwQFNEtDYEijJdcbVHeA;
								QCfqBDNmLRtShyIzfrSFkRuEfWpO = 0;
								goto IL_00fd;
							}
							OwdPldeEpDwYxZZisOIIncnJOZNt = null;
							break;
							IL_0287:
							if (UFkLdCZCPYCdrSlVCrvQNRbGABig >= OAzCYvtrCCgQtwIPkmyRzCEgIKv)
							{
								break;
							}
							OwdPldeEpDwYxZZisOIIncnJOZNt = mapHelper.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.YPeyRKgKWPSqEsMokJyVccifhDpb(UFkLdCZCPYCdrSlVCrvQNRbGABig);
							rEOKbhkrWOrZAKXJEVVrMvpowYNC = OwdPldeEpDwYxZZisOIIncnJOZNt.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
							QCfqBDNmLRtShyIzfrSFkRuEfWpO = 0;
							goto IL_025d;
							IL_0236:
							if (ATsDhxQWgTQFwVfHqfnTBqlZNIHcA < NLLzvuhbwOGqjJSnzzvVSTjWxHcj)
							{
								if (qsFhZWArruDTAaJzMRIKypQbMMzh.AZcUeIZqjwMekNcHfENpgGyCRDcAA(ATsDhxQWgTQFwVfHqfnTBqlZNIHcA) is _0001 val && val.categoryId == skUzlBhKAgIHGAOKQgWRBtLkYCAfb)
								{
									YnxrqXHBwhDgHfoaVNUNRNuEpMxn = val;
									oBloewYaSnECPPNmMRQROdSWCgKkA = 2;
									return true;
								}
								goto IL_0224;
							}
							qsFhZWArruDTAaJzMRIKypQbMMzh = null;
							QCfqBDNmLRtShyIzfrSFkRuEfWpO++;
							goto IL_025d;
							IL_00fd:
							if (QCfqBDNmLRtShyIzfrSFkRuEfWpO < rEOKbhkrWOrZAKXJEVVrMvpowYNC)
							{
								ControllerMap controllerMap = qsFhZWArruDTAaJzMRIKypQbMMzh.AZcUeIZqjwMekNcHfENpgGyCRDcAA(QCfqBDNmLRtShyIzfrSFkRuEfWpO);
								if (controllerMap.categoryId == skUzlBhKAgIHGAOKQgWRBtLkYCAfb)
								{
									YnxrqXHBwhDgHfoaVNUNRNuEpMxn = (_0001)controllerMap;
									oBloewYaSnECPPNmMRQROdSWCgKkA = 1;
									return true;
								}
								goto IL_00eb;
							}
							qsFhZWArruDTAaJzMRIKypQbMMzh = null;
							UFkLdCZCPYCdrSlVCrvQNRbGABig++;
							goto IL_0124;
							IL_025d:
							if (QCfqBDNmLRtShyIzfrSFkRuEfWpO < rEOKbhkrWOrZAKXJEVVrMvpowYNC)
							{
								qsFhZWArruDTAaJzMRIKypQbMMzh = OwdPldeEpDwYxZZisOIIncnJOZNt.uZavhtXKHVxiCdRnShETRMwAdKdM(QCfqBDNmLRtShyIzfrSFkRuEfWpO).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
								NLLzvuhbwOGqjJSnzzvVSTjWxHcj = qsFhZWArruDTAaJzMRIKypQbMMzh.IdaghgVqdKwQFNEtDYEijJdcbVHeA;
								ATsDhxQWgTQFwVfHqfnTBqlZNIHcA = 0;
								goto IL_0236;
							}
							OwdPldeEpDwYxZZisOIIncnJOZNt = null;
							UFkLdCZCPYCdrSlVCrvQNRbGABig++;
							goto IL_0287;
						}
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<_0001> IEnumerable<_0001>.GetEnumerator()
					{
						OgRPCEyOCIYvDxrTegSIqaiTjQWI<_0001> ogRPCEyOCIYvDxrTegSIqaiTjQWI;
						if (oBloewYaSnECPPNmMRQROdSWCgKkA == -2 && vBEEPeBiHuErANizCSUUKLpVncmq == Environment.CurrentManagedThreadId)
						{
							oBloewYaSnECPPNmMRQROdSWCgKkA = 0;
							ogRPCEyOCIYvDxrTegSIqaiTjQWI = this;
						}
						else
						{
							ogRPCEyOCIYvDxrTegSIqaiTjQWI = new OgRPCEyOCIYvDxrTegSIqaiTjQWI<_0001>(0);
							ogRPCEyOCIYvDxrTegSIqaiTjQWI.nxkPWXjanhfIYOeQJCvHAlydCLwbb = nxkPWXjanhfIYOeQJCvHAlydCLwbb;
						}
						ogRPCEyOCIYvDxrTegSIqaiTjQWI.skUzlBhKAgIHGAOKQgWRBtLkYCAfb = EaFzKxpxvogfZbqfKiiEvxXXfARHA;
						return ogRPCEyOCIYvDxrTegSIqaiTjQWI;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<_0001>)this).GetEnumerator();
					}
				}

				private sealed class kMOFEVjgpwCpcwdiLHvifMqEaKCDc : IEnumerable<ControllerMap>, IEnumerable, IEnumerator<ControllerMap>, IEnumerator, IDisposable
				{
					private int OAdApIKAkxjCZJNOZjJzHTxgRFVkc;

					private ControllerMap XpzmaXIqSUJBgNnqrkmmOsRZQHmn;

					private int zLmBeteILKBcxcnsQjQNuclRkhHpA;

					public MapHelper zPCSwwRcMXkmcXtwNmvsqDlnXucy;

					private ControllerType DDILrGMtzFCADlEFPlTgyRMSwBSq;

					public ControllerType LDWYJwzqdpmlznGzcgGzNDtluEtU;

					private int DToEtWyWbMfDEhxVOOKsxuOqnPID;

					public int IRiFHufJMhASSwTmRSYfdJbKfNBlA;

					private FcTbzUBLOriYHtrisAslcxMVjwzbA enPThSBgcoqyfXVFRguPOPPsPjDX;

					private int KOkqBsALmUocXErmOrlbTSSihPAW;

					private int UjGvqDztcxBDGIHpaKIEgkTUYrbq;

					private PQaFgQVynoEJfalLJXDCcVZTEKyx wINvhbYQRrKdUiJWQCNbuvWtuGsA;

					private int eIZLtMIvXDpYahekjqxUWDhZGAVK;

					private int rdLMFEvDKUjbqgRENodXEtPBpambA;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return XpzmaXIqSUJBgNnqrkmmOsRZQHmn;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return XpzmaXIqSUJBgNnqrkmmOsRZQHmn;
						}
					}

					[DebuggerHidden]
					public kMOFEVjgpwCpcwdiLHvifMqEaKCDc(int P_0)
					{
						OAdApIKAkxjCZJNOZjJzHTxgRFVkc = P_0;
						zLmBeteILKBcxcnsQjQNuclRkhHpA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						enPThSBgcoqyfXVFRguPOPPsPjDX = null;
						wINvhbYQRrKdUiJWQCNbuvWtuGsA = null;
						OAdApIKAkxjCZJNOZjJzHTxgRFVkc = -2;
					}

					private bool MoveNext()
					{
						int oAdApIKAkxjCZJNOZjJzHTxgRFVkc = OAdApIKAkxjCZJNOZjJzHTxgRFVkc;
						MapHelper mapHelper = zPCSwwRcMXkmcXtwNmvsqDlnXucy;
						if (oAdApIKAkxjCZJNOZjJzHTxgRFVkc != 0)
						{
							if (oAdApIKAkxjCZJNOZjJzHTxgRFVkc != 1)
							{
								return false;
							}
							OAdApIKAkxjCZJNOZjJzHTxgRFVkc = -1;
							goto IL_00e2;
						}
						OAdApIKAkxjCZJNOZjJzHTxgRFVkc = -1;
						if (ReInput._id != mapHelper.ygQbVjvWgDxIBqyAhSVKpNzECBhf)
						{
							ReInput.CheckInitialized(mapHelper.ygQbVjvWgDxIBqyAhSVKpNzECBhf);
							return false;
						}
						enPThSBgcoqyfXVFRguPOPPsPjDX = mapHelper.sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(DDILrGMtzFCADlEFPlTgyRMSwBSq);
						KOkqBsALmUocXErmOrlbTSSihPAW = enPThSBgcoqyfXVFRguPOPPsPjDX.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
						UjGvqDztcxBDGIHpaKIEgkTUYrbq = 0;
						goto IL_0117;
						IL_00f2:
						if (rdLMFEvDKUjbqgRENodXEtPBpambA < eIZLtMIvXDpYahekjqxUWDhZGAVK)
						{
							ControllerMap controllerMap = wINvhbYQRrKdUiJWQCNbuvWtuGsA.AZcUeIZqjwMekNcHfENpgGyCRDcAA(rdLMFEvDKUjbqgRENodXEtPBpambA);
							if (controllerMap.categoryId == DToEtWyWbMfDEhxVOOKsxuOqnPID)
							{
								XpzmaXIqSUJBgNnqrkmmOsRZQHmn = controllerMap;
								OAdApIKAkxjCZJNOZjJzHTxgRFVkc = 1;
								return true;
							}
							goto IL_00e2;
						}
						wINvhbYQRrKdUiJWQCNbuvWtuGsA = null;
						UjGvqDztcxBDGIHpaKIEgkTUYrbq++;
						goto IL_0117;
						IL_00e2:
						rdLMFEvDKUjbqgRENodXEtPBpambA++;
						goto IL_00f2;
						IL_0117:
						if (UjGvqDztcxBDGIHpaKIEgkTUYrbq < KOkqBsALmUocXErmOrlbTSSihPAW)
						{
							wINvhbYQRrKdUiJWQCNbuvWtuGsA = enPThSBgcoqyfXVFRguPOPPsPjDX.uZavhtXKHVxiCdRnShETRMwAdKdM(UjGvqDztcxBDGIHpaKIEgkTUYrbq).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
							eIZLtMIvXDpYahekjqxUWDhZGAVK = wINvhbYQRrKdUiJWQCNbuvWtuGsA.IdaghgVqdKwQFNEtDYEijJdcbVHeA;
							rdLMFEvDKUjbqgRENodXEtPBpambA = 0;
							goto IL_00f2;
						}
						return false;
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
					{
						kMOFEVjgpwCpcwdiLHvifMqEaKCDc kMOFEVjgpwCpcwdiLHvifMqEaKCDc2;
						if (OAdApIKAkxjCZJNOZjJzHTxgRFVkc == -2 && zLmBeteILKBcxcnsQjQNuclRkhHpA == Environment.CurrentManagedThreadId)
						{
							OAdApIKAkxjCZJNOZjJzHTxgRFVkc = 0;
							kMOFEVjgpwCpcwdiLHvifMqEaKCDc2 = this;
						}
						else
						{
							kMOFEVjgpwCpcwdiLHvifMqEaKCDc2 = new kMOFEVjgpwCpcwdiLHvifMqEaKCDc(0);
							kMOFEVjgpwCpcwdiLHvifMqEaKCDc2.zPCSwwRcMXkmcXtwNmvsqDlnXucy = zPCSwwRcMXkmcXtwNmvsqDlnXucy;
						}
						kMOFEVjgpwCpcwdiLHvifMqEaKCDc2.DToEtWyWbMfDEhxVOOKsxuOqnPID = IRiFHufJMhASSwTmRSYfdJbKfNBlA;
						kMOFEVjgpwCpcwdiLHvifMqEaKCDc2.DDILrGMtzFCADlEFPlTgyRMSwBSq = LDWYJwzqdpmlznGzcgGzNDtluEtU;
						return kMOFEVjgpwCpcwdiLHvifMqEaKCDc2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}
				}

				private readonly otOYRXLzSgwvWYlVzCPuFfegHCpP NchDOXbJasBJCrgtwaskPSBiouAfb;

				private Player ZKMrjqYqwUrfHWNFWcobmvVsFUqS;

				private ControllerHelper sFNpRqSpUDBhuJIUMZgKMkxjutaR;

				private readonly ControllerMapEnabler dneQVUpzGvnFlqrJPOIfmhiPLEMH;

				private readonly ControllerMapLayoutManager pkQVoppqQwryypmtZAPXxUwieeZv;

				private readonly int ygQbVjvWgDxIBqyAhSVKpNzECBhf;

				public ControllerMapLayoutManager layoutManager => pkQVoppqQwryypmtZAPXxUwieeZv;

				public ControllerMapEnabler mapEnabler => dneQVUpzGvnFlqrJPOIfmhiPLEMH;

				public IList<InputBehavior> InputBehaviors
				{
					get
					{
						if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
						{
							ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
							return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
						}
						return ZKMrjqYqwUrfHWNFWcobmvVsFUqS.bEDLzXIxpNJGCtcHNVEXWnpWvKtD.gGgZBtkCabfbYKBSTdKVeifYdvGMA(ZKMrjqYqwUrfHWNFWcobmvVsFUqS.CbVfyyZWPLaMXAAoIrIHBSMHYdnm);
					}
				}

				internal MapHelper(Player P_0, ControllerHelper P_1, otOYRXLzSgwvWYlVzCPuFfegHCpP P_2, ControllerMapLayoutManager.oEtaEetdhfQbAaNWSJSoqrbYDmNj P_3, ControllerMapEnabler.oRSewQBaBCPGsFqbLXrIpktlDkb P_4)
				{
					ygQbVjvWgDxIBqyAhSVKpNzECBhf = ReInput.id;
					ZKMrjqYqwUrfHWNFWcobmvVsFUqS = P_0;
					sFNpRqSpUDBhuJIUMZgKMkxjutaR = P_1;
					NchDOXbJasBJCrgtwaskPSBiouAfb = P_2;
					dneQVUpzGvnFlqrJPOIfmhiPLEMH = new ControllerMapEnabler(P_0, P_4);
					pkQVoppqQwryypmtZAPXxUwieeZv = new ControllerMapLayoutManager(P_0, P_3);
					pkQVoppqQwryypmtZAPXxUwieeZv.GIIFVnrcwnVdSRwKJkusEpxLTURy += dneQVUpzGvnFlqrJPOIfmhiPLEMH.Apply;
				}

				public void LoadMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					HhXKccUyLdIJwPwoZlrXHrNTRokI<T>(controllerId, categoryId, layoutId, BoolOption.Default);
				}

				public void LoadMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					LSDSWZPIpbExvyIlidpuuuJxclMe<T>(controllerId, categoryName, layoutName, BoolOption.Default);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					GRCDMjrAzJXSZecBkTPMIaKTrdxu(controllerType, controllerId, categoryId, layoutId, BoolOption.Default);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					vfamvMMtbgsJAqdadqlLiyxkogpw(controllerType, controllerId, categoryName, layoutName, BoolOption.Default);
				}

				public void LoadMap<T>(int controllerId, int categoryId, int layoutId, bool startEnabled) where T : ControllerMap
				{
					HhXKccUyLdIJwPwoZlrXHrNTRokI<T>(controllerId, categoryId, layoutId, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap<T>(int controllerId, string categoryName, string layoutName, bool startEnabled) where T : ControllerMap
				{
					LSDSWZPIpbExvyIlidpuuuJxclMe<T>(controllerId, categoryName, layoutName, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId, bool startEnabled)
				{
					GRCDMjrAzJXSZecBkTPMIaKTrdxu(controllerType, controllerId, categoryId, layoutId, startEnabled ? BoolOption.True : BoolOption.False);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName, bool startEnabled)
				{
					vfamvMMtbgsJAqdadqlLiyxkogpw(controllerType, controllerId, categoryName, layoutName, startEnabled ? BoolOption.True : BoolOption.False);
				}

				private void HhXKccUyLdIJwPwoZlrXHrNTRokI<_0001>(int P_0, int P_1, int P_2, BoolOption P_3) where _0001 : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else
					{
						ijoNMxJArDFCHDaMfEgEIhxHIRRVA(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<_0001>(), P_0, P_1, P_2, P_3);
					}
				}

				private void LSDSWZPIpbExvyIlidpuuuJxclMe<_0001>(int P_0, string P_1, string P_2, BoolOption P_3) where _0001 : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else
					{
						pZpsAJionNaphkeKDJWtzhFTGagqA(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<_0001>(), P_0, P_1, P_2, P_3);
					}
				}

				private void GRCDMjrAzJXSZecBkTPMIaKTrdxu(ControllerType P_0, int P_1, int P_2, int P_3, BoolOption P_4)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else
					{
						ijoNMxJArDFCHDaMfEgEIhxHIRRVA(P_0, P_1, P_2, P_3, P_4);
					}
				}

				private void vfamvMMtbgsJAqdadqlLiyxkogpw(ControllerType P_0, int P_1, string P_2, string P_3, BoolOption P_4)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else
					{
						pZpsAJionNaphkeKDJWtzhFTGagqA(P_0, P_1, P_2, P_3, P_4);
					}
				}

				[IteratorStateMachine(typeof(oSCMYPviskACZIRJvEWvxoiAdODg))]
				public IEnumerable<ControllerMap> GetAllMaps()
				{
					return new oSCMYPviskACZIRJvEWvxoiAdODg(-2)
					{
						cBJyPHGWmFauVrBgrGtrgpCPzJumA = this
					};
				}

				public int GetAllMaps(List<ControllerMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					int eWwWlDdWcqJQmgAiLeFBWdVumGMb = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb;
					for (int i = 0; i < eWwWlDdWcqJQmgAiLeFBWdVumGMb; i++)
					{
						FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.YPeyRKgKWPSqEsMokJyVccifhDpb(i);
						int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
						for (int j = 0; j < num; j++)
						{
							fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(j).ahBHvaaFKqjYqOJIXAFDIKodzptCA.HiCRpwAxYCKrcBOVZssvflHSCROfA(results, true);
						}
					}
					return results.Count;
				}

				[IteratorStateMachine(typeof(fVTODejFodpBghdpcOgSYhGUfAQV))]
				public IEnumerable<T> GetAllMaps<T>() where T : ControllerMap
				{
					return new fVTODejFodpBghdpcOgSYhGUfAQV<T>(-2)
					{
						IPHAFDelqiLMEuOZucMwenhhQwvC = this
					};
				}

				public int GetAllMaps<T>(List<T> results) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (GHPcAvLGyrhUIIuLWeQoyFTYgunBA.aWYfWZqScAuOOIyDChJOpWMiEjFC<T>(out var controllerType))
					{
						FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType);
						int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
						for (int i = 0; i < num; i++)
						{
							fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA.COWSLbmVLAVIihWScnIwdlCsBBaS(results, true);
						}
					}
					else
					{
						int eWwWlDdWcqJQmgAiLeFBWdVumGMb = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb;
						for (int j = 0; j < eWwWlDdWcqJQmgAiLeFBWdVumGMb; j++)
						{
							FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA2 = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.YPeyRKgKWPSqEsMokJyVccifhDpb(j);
							int num2 = fcTbzUBLOriYHtrisAslcxMVjwzbA2.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
							for (int k = 0; k < num2; k++)
							{
								fcTbzUBLOriYHtrisAslcxMVjwzbA2.uZavhtXKHVxiCdRnShETRMwAdKdM(k).ahBHvaaFKqjYqOJIXAFDIKodzptCA.COWSLbmVLAVIihWScnIwdlCsBBaS(results, true);
							}
						}
					}
					return results.Count;
				}

				[IteratorStateMachine(typeof(JHLFNjDcczgwaAbqyuFIdXjnxObE))]
				public IEnumerable<ControllerMap> GetAllMaps(ControllerType controllerType)
				{
					return new JHLFNjDcczgwaAbqyuFIdXjnxObE(-2)
					{
						NZXeeXbGUwKMhACHggQTgpfqZoOHB = this,
						IYFstRiyQKjFqkOWVxsWxCbHRmaH = controllerType
					};
				}

				public int GetAllMaps(ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
					for (int i = 0; i < num; i++)
					{
						fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA.HiCRpwAxYCKrcBOVZssvflHSCROfA(results, true);
					}
					return results.Count;
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return new List<ControllerMap>();
					}
					return GetAllMapsInCategory(mapCategoryId);
				}

				[IteratorStateMachine(typeof(QBkGGBBmNyOaJaOsbQKAmtRiFXXpA))]
				public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId)
				{
					return new QBkGGBBmNyOaJaOsbQKAmtRiFXXpA(-2)
					{
						hcwtAERXQSAtpojloBiqOXhWbtFF = this,
						dmCGTtgMrORzZYkEgRyoDdzvMPaY = categoryId
					};
				}

				public IEnumerable<T> GetAllMapsInCategory<T>(string categoryName) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return GetAllMapsInCategory<T>(mapCategoryId);
				}

				[IteratorStateMachine(typeof(OgRPCEyOCIYvDxrTegSIqaiTjQWI))]
				public IEnumerable<T> GetAllMapsInCategory<T>(int categoryId) where T : ControllerMap
				{
					return new OgRPCEyOCIYvDxrTegSIqaiTjQWI<T>(-2)
					{
						nxkPWXjanhfIYOeQJCvHAlydCLwbb = this,
						EaFzKxpxvogfZbqfKiiEvxXXfARHA = categoryId
					};
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName, ControllerType controllerType)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return new List<ControllerMap>();
					}
					return GetAllMapsInCategory(mapCategoryId, controllerType);
				}

				[IteratorStateMachine(typeof(kMOFEVjgpwCpcwdiLHvifMqEaKCDc))]
				public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId, ControllerType controllerType)
				{
					return new kMOFEVjgpwCpcwdiLHvifMqEaKCDc(-2)
					{
						zPCSwwRcMXkmcXtwNmvsqDlnXucy = this,
						IRiFHufJMhASSwTmRSYfdJbKfNBlA = categoryId,
						LDWYJwzqdpmlznGzcgGzNDtluEtU = controllerType
					};
				}

				public int GetAllMapsInCategory(string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetAllMapsInCategory(mapCategoryId, results);
				}

				public int GetAllMapsInCategory(int categoryId, List<ControllerMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					int eWwWlDdWcqJQmgAiLeFBWdVumGMb = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb;
					for (int i = 0; i < eWwWlDdWcqJQmgAiLeFBWdVumGMb; i++)
					{
						FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.YPeyRKgKWPSqEsMokJyVccifhDpb(i);
						int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
						for (int j = 0; j < num; j++)
						{
							fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(j).ahBHvaaFKqjYqOJIXAFDIKodzptCA.RNbMgXJLQHPCpwfrdRyerhEBaXbk(categoryId, results, true);
						}
					}
					return results.Count;
				}

				public int GetAllMapsInCategory<T>(string categoryName, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetAllMapsInCategory(mapCategoryId, results);
				}

				public int GetAllMapsInCategory<T>(int categoryId, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					if (GHPcAvLGyrhUIIuLWeQoyFTYgunBA.aWYfWZqScAuOOIyDChJOpWMiEjFC<T>(out var controllerType))
					{
						FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType);
						int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
						for (int i = 0; i < num; i++)
						{
							fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA.cQUOINWjxIHcICPAjBFLwtADFqibA(categoryId, results, true);
						}
					}
					else
					{
						int eWwWlDdWcqJQmgAiLeFBWdVumGMb = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb;
						for (int j = 0; j < eWwWlDdWcqJQmgAiLeFBWdVumGMb; j++)
						{
							FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA2 = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.YPeyRKgKWPSqEsMokJyVccifhDpb(j);
							int num2 = fcTbzUBLOriYHtrisAslcxMVjwzbA2.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
							for (int k = 0; k < num2; k++)
							{
								fcTbzUBLOriYHtrisAslcxMVjwzbA2.uZavhtXKHVxiCdRnShETRMwAdKdM(k).ahBHvaaFKqjYqOJIXAFDIKodzptCA.cQUOINWjxIHcICPAjBFLwtADFqibA(categoryId, results, true);
							}
						}
					}
					return results.Count;
				}

				public int GetAllMapsInCategory(string categoryName, ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetAllMapsInCategory(mapCategoryId, controllerType, results);
				}

				public int GetAllMapsInCategory(int categoryId, ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
					for (int i = 0; i < num; i++)
					{
						fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA.RNbMgXJLQHPCpwfrdRyerhEBaXbk(categoryId, results, true);
					}
					return results.Count;
				}

				public IList<T> GetMaps<T>(int controllerId) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return ThsCixkqaWAvoCzIMTPZiYsavIZvA<T>(controllerId);
				}

				public IList<ControllerMap> GetMaps(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return rgZBjBkuYOaKLbFInMxILeUMMLCq(controllerType, controllerId);
				}

				public IList<ControllerMap> GetMaps(Controller controller)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return GetMaps(controller.type, controller.id);
				}

				public IEnumerable<ControllerMap> GetMapsInCategory(ControllerType controllerType, int controllerId, int categoryId)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (controllerId < 0 || categoryId < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return LIyvtLYDtXyNcyIIcoUqGEaVmaMf(controllerType, controllerId, categoryId);
				}

				public IEnumerable<ControllerMap> GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return GetMapsInCategory(controllerType, controllerId, mapCategoryId);
				}

				public IEnumerable<ControllerMap> GetMapsInCategory(Controller controller, int categoryId)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return GetMapsInCategory(controller.type, controller.id, categoryId);
				}

				public IEnumerable<ControllerMap> GetMapsInCategory(Controller controller, string categoryName)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return GetMapsInCategory(controller.type, controller.id, mapCategoryId);
				}

				public int GetMapsInCategory(ControllerType controllerType, int controllerId, int categoryId, List<ControllerMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					ListTools.TryClear(results);
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					if (controllerId < 0 || categoryId < 0)
					{
						return 0;
					}
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					return sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType).YacHzxfeOlVQUomSEcSTDHYQttOQA(controllerId)?.ahBHvaaFKqjYqOJIXAFDIKodzptCA.RNbMgXJLQHPCpwfrdRyerhEBaXbk(categoryId, results, false) ?? 0;
				}

				public int GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					ListTools.TryClear(results);
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetMapsInCategory(controllerType, controllerId, mapCategoryId, results);
				}

				public int GetMapsInCategory(Controller controller, int categoryId, List<ControllerMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					ListTools.TryClear(results);
					if (controller == null)
					{
						return 0;
					}
					return GetMapsInCategory(controller.type, controller.id, categoryId, results);
				}

				public int GetMapsInCategory(Controller controller, string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					ListTools.TryClear(results);
					if (controller == null)
					{
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetMapsInCategory(controller.type, controller.id, mapCategoryId, results);
				}

				public IEnumerable<T> GetMapsInCategory<T>(int controllerId, int categoryId) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return omcaWcYHDLFWbzkFybHRFmggtSYFA<T>(controllerId, categoryId);
				}

				public IEnumerable<T> GetMapsInCategory<T>(int controllerId, string categoryName) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return GetMapsInCategory<T>(controllerId, mapCategoryId);
				}

				public int GetMapsInCategory<T>(int controllerId, int categoryId, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					KtryiWwbdBImLIPzGurzVKouGTieb ktryiWwbdBImLIPzGurzVKouGTieb = zzRfMCXrJAAZIhKRwDfufvjgrfEqb<T>().YacHzxfeOlVQUomSEcSTDHYQttOQA(controllerId);
					if (ktryiWwbdBImLIPzGurzVKouGTieb == null)
					{
						return 0;
					}
					ktryiWwbdBImLIPzGurzVKouGTieb.ahBHvaaFKqjYqOJIXAFDIKodzptCA.cQUOINWjxIHcICPAjBFLwtADFqibA(categoryId, results, true);
					return results.Count;
				}

				public int GetMapsInCategory<T>(int controllerId, string categoryName, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					ListTools.TryClear(results);
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetMapsInCategory(controllerId, mapCategoryId, results);
				}

				public T GetMap<T>(int controllerId, int mapId) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					return (T)aPYFMEhwBULlykemBfcrFdwhtQUw(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), controllerId, mapId);
				}

				public T GetMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return (T)dnfOFRDFMkDkawdymPPNchMuYnhi(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), controllerId, categoryId, layoutId);
				}

				public T GetMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					return (T)URVJMcnNESPbXXPPGRhDqswQaNMg(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), controllerId, categoryName, layoutName);
				}

				public ControllerMap GetMap(int mapId)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					int eWwWlDdWcqJQmgAiLeFBWdVumGMb = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb;
					for (int i = 0; i < eWwWlDdWcqJQmgAiLeFBWdVumGMb; i++)
					{
						FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.YPeyRKgKWPSqEsMokJyVccifhDpb(i);
						int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
						for (int j = 0; j < num; j++)
						{
							ControllerMap controllerMap = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(j).ahBHvaaFKqjYqOJIXAFDIKodzptCA.OzQvFluJYEaucOhJVdhJHwGQlDnW(mapId);
							if (controllerMap != null)
							{
								return controllerMap;
							}
						}
					}
					return null;
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, int mapId)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					return aPYFMEhwBULlykemBfcrFdwhtQUw(controllerType, controllerId, mapId);
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return dnfOFRDFMkDkawdymPPNchMuYnhi(controllerType, controllerId, categoryId, layoutId);
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					return URVJMcnNESPbXXPPGRhDqswQaNMg(controllerType, controllerId, categoryName, layoutName);
				}

				public ControllerMap GetMap(Controller controller, int mapId)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return GetMap(controller.type, controller.id, mapId);
				}

				public ControllerMap GetMap(Controller controller, int categoryId, int layoutId)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return GetMap(controller.type, controller.id, categoryId, layoutId);
				}

				public ControllerMap GetMap(Controller controller, string categoryName, string layoutName)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return GetMap(controller.type, controller.id, categoryName, layoutName);
				}

				public T GetFirstMapInCategory<T>(int controllerId, string categoryName) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return null;
					}
					return GetFirstMapInCategory<T>(controllerId, mapCategoryId);
				}

				public T GetFirstMapInCategory<T>(int controllerId, int categoryId) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					if (categoryId < 0)
					{
						return null;
					}
					return (T)oMnClbQndFtryIBpLEhwzafWimqW(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), controllerId, categoryId);
				}

				public ControllerMap GetFirstMapInCategory(ControllerType controllerType, int controllerId, string categoryName)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return null;
					}
					return GetFirstMapInCategory(controllerType, controllerId, mapCategoryId);
				}

				public ControllerMap GetFirstMapInCategory(ControllerType controllerType, int controllerId, int categoryId)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					if (categoryId < 0)
					{
						return null;
					}
					return oMnClbQndFtryIBpLEhwzafWimqW(controllerType, controllerId, categoryId);
				}

				public ControllerMap GetFirstMapInCategory(Controller controller, string categoryName)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return GetFirstMapInCategory(controller.type, controller.id, categoryName);
				}

				public ControllerMap GetFirstMapInCategory(Controller controller, int categoryId)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return GetFirstMapInCategory(controller.type, controller.id, categoryId);
				}

				public void AddMap<T>(int controllerId, ControllerMap map) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else
					{
						sCIJhjofuDsjLPxjntqYArjoPmPS(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), controllerId, map, BoolOption.Default);
					}
				}

				public void AddMap(Controller controller, ControllerMap map)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else
					{
						duApfNGHelKuGYUcfAbjinuIFTZjA(controller, map, BoolOption.Default);
					}
				}

				public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else
					{
						sCIJhjofuDsjLPxjntqYArjoPmPS(controllerType, controllerId, map, BoolOption.Default);
					}
				}

				public void AddMap<T>(int controllerId, ControllerMap map, bool startEnabled) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else
					{
						sCIJhjofuDsjLPxjntqYArjoPmPS(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), controllerId, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public void AddMap(Controller controller, ControllerMap map, bool startEnabled)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else
					{
						duApfNGHelKuGYUcfAbjinuIFTZjA(controller, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map, bool startEnabled)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else
					{
						sCIJhjofuDsjLPxjntqYArjoPmPS(controllerType, controllerId, map, startEnabled ? BoolOption.True : BoolOption.False);
					}
				}

				public bool AddMapFromXml<T>(int controllerId, string xmlString) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return false;
					}
					return cpulJVGdBTsbFlMstsiZiYJpSKjS(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), controllerId, xmlString);
				}

				public bool AddMapFromXml(ControllerType controllerType, int controllerId, string xmlString)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return false;
					}
					return cpulJVGdBTsbFlMstsiZiYJpSKjS(controllerType, controllerId, xmlString);
				}

				public int AddMapsFromXml<T>(int controllerId, List<string> xmlStrings) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (xmlStrings == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < xmlStrings.Count; i++)
					{
						if (AddMapFromXml<T>(controllerId, xmlStrings[i]))
						{
							num++;
						}
					}
					return num;
				}

				public int AddMapsFromXml(ControllerType controllerType, int controllerId, List<string> xmlStrings)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (xmlStrings == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < xmlStrings.Count; i++)
					{
						if (AddMapFromXml(controllerType, controllerId, xmlStrings[i]))
						{
							num++;
						}
					}
					return num;
				}

				public bool AddMapFromJson<T>(int controllerId, string jsonString) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return false;
					}
					return jpwwtIHBPSXvyjsvKWRnLbBIOWCe(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), controllerId, jsonString);
				}

				public bool AddMapFromJson(ControllerType controllerType, int controllerId, string jsonString)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return false;
					}
					return jpwwtIHBPSXvyjsvKWRnLbBIOWCe(controllerType, controllerId, jsonString);
				}

				public int AddMapsFromJson<T>(int controllerId, List<string> jsonStrings) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (jsonStrings == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < jsonStrings.Count; i++)
					{
						if (AddMapFromJson<T>(controllerId, jsonStrings[i]))
						{
							num++;
						}
					}
					return num;
				}

				public int AddMapsFromJson(ControllerType controllerType, int controllerId, List<string> jsonStrings)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (jsonStrings == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < jsonStrings.Count; i++)
					{
						if (AddMapFromJson(controllerType, controllerId, jsonStrings[i]))
						{
							num++;
						}
					}
					return num;
				}

				public void AddEmptyMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else
					{
						lSstlOktijKHCtfZnbAYTieOEtRt(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), controllerId, categoryId, layoutId);
					}
				}

				public void AddEmptyMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else
					{
						tSMWpnmBQQtTfBpIuGhtsgyUFiBhA(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), controllerId, categoryName, layoutName);
					}
				}

				public void AddEmptyMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else
					{
						lSstlOktijKHCtfZnbAYTieOEtRt(controllerType, controllerId, categoryId, layoutId);
					}
				}

				public void AddEmptyMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						AddEmptyMap(controllerType, controllerId, mapCategoryId, layoutId);
					}
				}

				public void RemoveMap<T>(int controllerId, int mapId) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else if (mapId >= 0)
					{
						AXkOcYmoLydodiDyYyXXQhXWiyIvA(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), controllerId, mapId);
					}
				}

				public void RemoveMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else if (categoryId >= 0 && layoutId >= 0)
					{
						CUSkOuMwPcAzutlaFbDUuRPnTYfK(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), controllerId, categoryId, layoutId);
					}
				}

				public void RemoveMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else
					{
						qubMwBihcZojjkINvOyCeboXONXL(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), controllerId, categoryName, layoutName);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, int mapId)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else if (mapId >= 0)
					{
						AXkOcYmoLydodiDyYyXXQhXWiyIvA(controllerType, controllerId, mapId);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else if (categoryId >= 0 && layoutId >= 0)
					{
						CUSkOuMwPcAzutlaFbDUuRPnTYfK(controllerType, controllerId, categoryId, layoutId);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else
					{
						qubMwBihcZojjkINvOyCeboXONXL(controllerType, controllerId, categoryName, layoutName);
					}
				}

				public void ClearMaps<T>(bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else
					{
						ClearMaps(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), userAssignableOnly);
					}
				}

				public void ClearMaps(ControllerType controllerType, bool userAssignableOnly)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return;
					}
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType);
					for (int i = 0; i < fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh; i++)
					{
						fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA.vqriEKUZZEuKAkfTItcvlOTtKAJX(userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(int categoryId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else
					{
						ClearMapsInCategory(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(string categoryName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						ClearMapsInCategory<T>(mapCategoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(int categoryId, int layoutId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else
					{
						ClearMapsInCategory(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), categoryId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(string categoryName, string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						int layoutId = ReInput.mapping.GetLayoutId(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), layoutName);
						if (layoutId >= 0)
						{
							ClearMapsInCategory<T>(mapCategoryId, layoutId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInCategory(int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return;
					}
					int eWwWlDdWcqJQmgAiLeFBWdVumGMb = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb;
					for (int i = 0; i < eWwWlDdWcqJQmgAiLeFBWdVumGMb; i++)
					{
						FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.VJVCoQkCdAkunrOcVfvCSHrGWrFxA(i));
						for (int j = 0; j < fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh; j++)
						{
							fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(j).ahBHvaaFKqjYqOJIXAFDIKodzptCA.qntOlRQLkxJANDOFKnPEQdFwFgWG(categoryId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInCategory(string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						ClearMapsInCategory(mapCategoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return;
					}
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType);
					for (int i = 0; i < fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh; i++)
					{
						fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA.qntOlRQLkxJANDOFKnPEQdFwFgWG(categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						ClearMapsInCategory(controllerType, mapCategoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, int categoryId, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return;
					}
					InputCategory mapCategory = ReInput.mapping.GetMapCategory(categoryId);
					if (mapCategory != null && (!userAssignableOnly || mapCategory.userAssignable))
					{
						FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType);
						for (int i = 0; i < fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh; i++)
						{
							fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA.kvFNncpbGNHESQXIziOLAFguhWClA(categoryId, layoutId);
						}
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, string categoryName, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
						if (layoutId >= 0)
						{
							ClearMapsInCategory(controllerType, mapCategoryId, layoutId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInLayout<T>(int layoutId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else
					{
						ClearMapsInLayout(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout<T>(string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), layoutName);
					if (layoutId >= 0)
					{
						ClearMapsInLayout<T>(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout(ControllerType controllerType, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return;
					}
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType);
					for (int i = 0; i < fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh; i++)
					{
						fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA.ZxNpVkHFqMAUWhBoSnLTxGSqjcDsA(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout(ControllerType controllerType, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (layoutId >= 0)
					{
						ClearMapsInLayout(controllerType, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else
					{
						ClearMapsForController(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), controllerId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, int categoryId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else
					{
						ClearMapsForController(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), controllerId, categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, string categoryName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						ClearMapsForController<T>(controllerId, mapCategoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, bool userAssignableOnly)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return;
					}
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(controllerId);
					if (num >= 0)
					{
						fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.vqriEKUZZEuKAkfTItcvlOTtKAJX(userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return;
					}
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(controllerId);
					if (num >= 0)
					{
						fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.qntOlRQLkxJANDOFKnPEQdFwFgWG(categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						ClearMapsForController(controllerType, controllerId, mapCategoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout<T>(int controllerId, int layoutId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
					}
					else
					{
						ClearMapsForControllerInLayout(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout<T>(int controllerId, string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<T>(), layoutName);
					if (layoutId >= 0)
					{
						ClearMapsForControllerInLayout<T>(controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return;
					}
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(controllerId);
					if (num >= 0)
					{
						fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.ZxNpVkHFqMAUWhBoSnLTxGSqjcDsA(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (layoutId >= 0)
					{
						ClearMapsForControllerInLayout(controllerType, controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearAllMaps(bool userAssignableOnly)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return;
					}
					for (int i = 0; i < sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb; i++)
					{
						ClearMaps(sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.VJVCoQkCdAkunrOcVfvCSHrGWrFxA(i), userAssignableOnly);
					}
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return GetFirstButtonMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return GetFirstButtonMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return qwVDIMebyXAKZOoRFvcMcuOJbfWFb(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return GetFirstButtonMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					return cskerdsFOHjwoNKPEDcNHwIQmAPhA(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return GetFirstButtonMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb; i++)
					{
						ActionElementMap actionElementMap = cskerdsFOHjwoNKPEDcNHwIQmAPhA(sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.VJVCoQkCdAkunrOcVfvCSHrGWrFxA(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstButtonMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return GetFirstButtonMapWithAction(actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return ButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return ButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return FwtZiQCpLuVBwIAKIjFAuyFuLcHu(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return ButtonMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return zfNzpKzDCKQfUSLnuNSMfALmfafF(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return ButtonMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				[IteratorStateMachine(typeof(mdwyZrlspLbtwaabtYnvqJkIaeQN))]
				public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new mdwyZrlspLbtwaabtYnvqJkIaeQN(-2)
					{
						rlYcvkzhBgFGmVfjoOfoexhqWUlP = this,
						tOQGqVEcMDFSaGkHhsvSNAevokRTb = actionId,
						RzbfOFrLSykjPHuQCLzWdAeXxeFD = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return ButtonMapsWithAction(actionId, skipDisabledMaps);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					if (controller == null)
					{
						results.Clear();
						return 0;
					}
					return jNvzeTmGvvorxesVphFCvEbeRajJ(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return GetButtonMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					return MDYuQoWKxibzbpJmVJzGfZpcPwTU(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return GetButtonMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return hWZOkklkXXIDzPSAHVTSimFfgtWi(actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return GetButtonMapsWithAction(actionId, skipDisabledMaps, results);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return GetFirstAxisMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return GetFirstAxisMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return IhDFiuknbFQVVjyNsXRcxkTkWHcHA(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return GetFirstAxisMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					return OpOUOWBbiIFSMYNBzRIYwEnDiiib(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return GetFirstAxisMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb; i++)
					{
						ActionElementMap actionElementMap = OpOUOWBbiIFSMYNBzRIYwEnDiiib(sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.VJVCoQkCdAkunrOcVfvCSHrGWrFxA(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return GetFirstAxisMapWithAction(actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return AxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return AxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return TXrFgAcSjfoKrSQmCAjeXmQxtOdr(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return AxisMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return dSwRcYYQhwQZbflQdaDlJPFYIMXn(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return AxisMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				[IteratorStateMachine(typeof(lRKFPzAsTZCKcqrEnlLyAPxEnYsk))]
				public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new lRKFPzAsTZCKcqrEnlLyAPxEnYsk(-2)
					{
						bcaOPuxDmuUKkJRXJWiSPFWSIKN = this,
						ZlOnTKacwnhSIuYPfdQsozQIpPDo = actionId,
						vhnakjTUAbOcktswwbsuWARrSvOK = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return AxisMapsWithAction(actionId, skipDisabledMaps);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetAxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetAxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return DDVHHpOyHKCAVryYUQMIIQbtShWh(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return GetAxisMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					return kMwSsgHQJlHQQOiNiOaTqAnPZHoJ(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return GetAxisMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return bNyKfFVTPAGUNWJdcclRYQsTsuAc(actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return GetAxisMapsWithAction(actionId, skipDisabledMaps, results);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return GetFirstElementMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return GetFirstElementMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return eDGpZZhYukcaHsGDabadkBUqMFrlA(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return GetFirstElementMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					return aDwydSUVmaXjDIpeyDauwdByNjXI(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return GetFirstElementMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb; i++)
					{
						ActionElementMap actionElementMap = aDwydSUVmaXjDIpeyDauwdByNjXI(sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.VJVCoQkCdAkunrOcVfvCSHrGWrFxA(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return GetFirstElementMapWithAction(actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return ElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return ElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return VMlahaXIbabWECrPyGKDFjqcmsOGA(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return ElementMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return RpgfaRxATWbKDtzmzFmrjTqsyOmD(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return ElementMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				[IteratorStateMachine(typeof(MoiejmkhIgRlpZwlniBbzoKBgNSW))]
				public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					return new MoiejmkhIgRlpZwlniBbzoKBgNSW(-2)
					{
						WbjOlfDitGWaeHENSGJtwbUXrntV = this,
						zGdHZIesGgWmPGJmdamxUxpGHYiY = actionId,
						osJuLbkaTcAVoBgwdaAzoQvWCyNR = skipDisabledMaps
					};
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return ElementMapsWithAction(actionId, skipDisabledMaps);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return DJBptTNiYWepbkKtodQPzArNxmKDA(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return GetElementMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					return gQTQcBQkJqFrVgOpTEhNNWYgxKNmA(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return GetElementMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return mLosgPYyPZVjLnJfLhrRwBwzctDC(actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					oFieiUIUewVeTJqZtmiJuPDLbluKA oFieiUIUewVeTJqZtmiJuPDLbluKA2 = oFieiUIUewVeTJqZtmiJuPDLbluKA.WKwdftlTADcIDJLOQftQVPMcNeXb(elementTarget);
					IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(oFieiUIUewVeTJqZtmiJuPDLbluKA2, skipDisabledMaps);
					oFieiUIUewVeTJqZtmiJuPDLbluKA.DnnhidOkRREqyIBofCvNmttxJQEjA(oFieiUIUewVeTJqZtmiJuPDLbluKA2);
					return result;
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					return LaWOayNBzYPeseUdFMMKbpbNmmhe(elementTarget, false, -1, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					oFieiUIUewVeTJqZtmiJuPDLbluKA oFieiUIUewVeTJqZtmiJuPDLbluKA2 = oFieiUIUewVeTJqZtmiJuPDLbluKA.WKwdftlTADcIDJLOQftQVPMcNeXb(elementTarget);
					IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(oFieiUIUewVeTJqZtmiJuPDLbluKA2, actionId, skipDisabledMaps);
					oFieiUIUewVeTJqZtmiJuPDLbluKA.DnnhidOkRREqyIBofCvNmttxJQEjA(oFieiUIUewVeTJqZtmiJuPDLbluKA2);
					return result;
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					return LaWOayNBzYPeseUdFMMKbpbNmmhe(elementTarget, true, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					oFieiUIUewVeTJqZtmiJuPDLbluKA oFieiUIUewVeTJqZtmiJuPDLbluKA2 = oFieiUIUewVeTJqZtmiJuPDLbluKA.WKwdftlTADcIDJLOQftQVPMcNeXb(elementTarget);
					ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(oFieiUIUewVeTJqZtmiJuPDLbluKA2, skipDisabledMaps);
					oFieiUIUewVeTJqZtmiJuPDLbluKA.DnnhidOkRREqyIBofCvNmttxJQEjA(oFieiUIUewVeTJqZtmiJuPDLbluKA2);
					return firstElementMapWithElementTarget;
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					return minnnPERqyKFxFMZGGvefsjEcMLU(elementTarget, false, -1, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					oFieiUIUewVeTJqZtmiJuPDLbluKA oFieiUIUewVeTJqZtmiJuPDLbluKA2 = oFieiUIUewVeTJqZtmiJuPDLbluKA.WKwdftlTADcIDJLOQftQVPMcNeXb(elementTarget);
					ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(oFieiUIUewVeTJqZtmiJuPDLbluKA2, actionId, skipDisabledMaps);
					oFieiUIUewVeTJqZtmiJuPDLbluKA.DnnhidOkRREqyIBofCvNmttxJQEjA(oFieiUIUewVeTJqZtmiJuPDLbluKA2);
					return firstElementMapWithElementTarget;
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					return minnnPERqyKFxFMZGGvefsjEcMLU(elementTarget, true, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					oFieiUIUewVeTJqZtmiJuPDLbluKA oFieiUIUewVeTJqZtmiJuPDLbluKA2 = oFieiUIUewVeTJqZtmiJuPDLbluKA.WKwdftlTADcIDJLOQftQVPMcNeXb(elementTarget);
					int elementMapsWithElementTarget = GetElementMapsWithElementTarget(oFieiUIUewVeTJqZtmiJuPDLbluKA2, skipDisabledMaps, results);
					oFieiUIUewVeTJqZtmiJuPDLbluKA.DnnhidOkRREqyIBofCvNmttxJQEjA(oFieiUIUewVeTJqZtmiJuPDLbluKA2);
					return elementMapsWithElementTarget;
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return KuXTxJCOSbPRIcrFIUEsMUHlUaXW(elementTarget, false, -1, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					oFieiUIUewVeTJqZtmiJuPDLbluKA oFieiUIUewVeTJqZtmiJuPDLbluKA2 = oFieiUIUewVeTJqZtmiJuPDLbluKA.WKwdftlTADcIDJLOQftQVPMcNeXb(elementTarget);
					int elementMapsWithElementTarget = GetElementMapsWithElementTarget(oFieiUIUewVeTJqZtmiJuPDLbluKA2, actionId, skipDisabledMaps, results);
					oFieiUIUewVeTJqZtmiJuPDLbluKA.DnnhidOkRREqyIBofCvNmttxJQEjA(oFieiUIUewVeTJqZtmiJuPDLbluKA2);
					return elementMapsWithElementTarget;
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return KuXTxJCOSbPRIcrFIUEsMUHlUaXW(elementTarget, true, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
					return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
				}

				public T[] GetMapSaveData<T>(int controllerId, bool userAssignableMapsOnly) where T : ControllerMapSaveData
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<T>.array;
					}
					return UKNzxErKMBVybXSyCCXKIrWDbLMf<T>(controllerId, userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetMapSaveData(ControllerType controllerType, int controllerId, bool userAssignableMapsOnly)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					return yANcKSsBWeIbuAbQckkaAhXmfLujA(controllerType, controllerId, userAssignableMapsOnly);
				}

				public T[] GetAllMapSaveData<T>(bool userAssignableMapsOnly) where T : ControllerMapSaveData
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<T>.array;
					}
					return DPeefuhTDtVjGIpLfmbtCcsmbCBRA<T>(userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetAllMapSaveData(ControllerType controllerType, bool userAssignableMapsOnly)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					return zAtMhysdhSMqXBeXgIbdFidceyhk(controllerType, userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetAllMapSaveData(bool userAssignableMapsOnly)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					ControllerMapSaveData[] array = null;
					for (int i = 0; i < sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb; i++)
					{
						ArrayTools.Combine(ref array, zAtMhysdhSMqXBeXgIbdFidceyhk(sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.VJVCoQkCdAkunrOcVfvCSHrGWrFxA(i), userAssignableMapsOnly));
					}
					return array;
				}

				public int SetAllMapsEnabled(bool state)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					int num = 0;
					int eWwWlDdWcqJQmgAiLeFBWdVumGMb = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb;
					for (int i = 0; i < eWwWlDdWcqJQmgAiLeFBWdVumGMb; i++)
					{
						FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.YPeyRKgKWPSqEsMokJyVccifhDpb(i);
						int num2 = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
						for (int j = 0; j < num2; j++)
						{
							num += fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(j).ahBHvaaFKqjYqOJIXAFDIKodzptCA.yYgvPXpVxjnIamLnVcNGqIIXXhys(state);
						}
					}
					return num;
				}

				public int SetAllMapsEnabled(bool state, ControllerType controllerType)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					int num = 0;
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType);
					int num2 = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
					for (int i = 0; i < num2; i++)
					{
						num += fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA.yYgvPXpVxjnIamLnVcNGqIIXXhys(state);
					}
					return num;
				}

				public int SetAllMapsEnabled(bool state, Controller controller)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return SetAllMapsEnabled(state, controller.type, controller.id);
				}

				public int SetAllMapsEnabled(bool state, ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					return sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType).YacHzxfeOlVQUomSEcSTDHYQttOQA(controllerId)?.ahBHvaaFKqjYqOJIXAFDIKodzptCA.yYgvPXpVxjnIamLnVcNGqIIXXhys(state) ?? 0;
				}

				public int SetMapsEnabled(bool state, int categoryId)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					int num = 0;
					int eWwWlDdWcqJQmgAiLeFBWdVumGMb = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb;
					for (int i = 0; i < eWwWlDdWcqJQmgAiLeFBWdVumGMb; i++)
					{
						FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.YPeyRKgKWPSqEsMokJyVccifhDpb(i);
						int num2 = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
						for (int j = 0; j < num2; j++)
						{
							num += fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(j).ahBHvaaFKqjYqOJIXAFDIKodzptCA.IkAxNXDPDFomjLGBYGcZbIqpTMgb(state, categoryId);
						}
					}
					return num;
				}

				public int SetMapsEnabled(bool state, string categoryName)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return SetMapsEnabled(state, mapCategoryId);
				}

				public int SetMapsEnabled(bool state, string categoryName, string layoutName)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					int num = 0;
					int eWwWlDdWcqJQmgAiLeFBWdVumGMb = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb;
					for (int i = 0; i < eWwWlDdWcqJQmgAiLeFBWdVumGMb; i++)
					{
						ControllerType controllerType = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.VJVCoQkCdAkunrOcVfvCSHrGWrFxA(i);
						int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
						if (layoutId >= 0)
						{
							num += SetMapsEnabled(state, controllerType, mapCategoryId, layoutId);
						}
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, int categoryId)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					int num = 0;
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType);
					int num2 = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
					for (int i = 0; i < num2; i++)
					{
						num += fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA.IkAxNXDPDFomjLGBYGcZbIqpTMgb(state, categoryId);
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return SetMapsEnabled(state, controllerType, mapCategoryId);
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, int categoryId, int layoutId)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return 0;
					}
					int num = 0;
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType);
					int num2 = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
					for (int i = 0; i < num2; i++)
					{
						num += fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA.lFwOvwrNBikHuDWkMXRXEIqgfMMF(state, categoryId, layoutId);
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName, string layoutName)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (layoutId < 0)
					{
						return 0;
					}
					return SetMapsEnabled(state, controllerType, mapCategoryId, layoutId);
				}

				public int SetMapsEnabled(bool state, Controller controller, int categoryId)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					return sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controller.type).YacHzxfeOlVQUomSEcSTDHYQttOQA(controller.id)?.ahBHvaaFKqjYqOJIXAFDIKodzptCA.IkAxNXDPDFomjLGBYGcZbIqpTMgb(state, categoryId) ?? 0;
				}

				public int SetMapsEnabled(bool state, Controller controller, int categoryId, int layoutId)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					if (layoutId < 0)
					{
						return 0;
					}
					return sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controller.type).YacHzxfeOlVQUomSEcSTDHYQttOQA(controller.id)?.ahBHvaaFKqjYqOJIXAFDIKodzptCA.lFwOvwrNBikHuDWkMXRXEIqgfMMF(state, categoryId, layoutId) ?? 0;
				}

				public int SetMapsEnabled(bool state, Controller controller, string categoryName)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return SetMapsEnabled(state, controller, mapCategoryId);
				}

				public int SetMapsEnabled(bool state, Controller controller, string categoryName, string layoutName)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					int layoutId = ReInput.mapping.GetLayoutId(controller.type, layoutName);
					if (layoutId < 0)
					{
						return 0;
					}
					return SetMapsEnabled(state, controller, mapCategoryId, layoutId);
				}

				public void LoadDefaultMaps(ControllerType controllerType)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						ijHakGHSIDiDKPpFXNvfPVMCWGWcA(false);
						break;
					case ControllerType.Keyboard:
						kLXCSUbcyTWqvfJGJmRKBESPnzbQA(false);
						break;
					case ControllerType.Mouse:
						mjacdxVZKTQCTPFXeDxVgPryfFut(false);
						break;
					case ControllerType.Custom:
						SEcXlgPEfHBmnEXMcWdcmMiTejXzA(false);
						break;
					default:
						throw new NotImplementedException();
					}
				}

				public bool ContainsMapInCategory(InputMapCategory category)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return false;
					}
					if (category == null)
					{
						return false;
					}
					return ContainsMapInCategory(category.id);
				}

				public bool ContainsMapInCategory(int categoryId)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return false;
					}
					if (categoryId < 0)
					{
						return false;
					}
					int eWwWlDdWcqJQmgAiLeFBWdVumGMb = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb;
					for (int i = 0; i < eWwWlDdWcqJQmgAiLeFBWdVumGMb; i++)
					{
						FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.YPeyRKgKWPSqEsMokJyVccifhDpb(i);
						int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
						for (int j = 0; j < num; j++)
						{
							if (fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(j).ahBHvaaFKqjYqOJIXAFDIKodzptCA.xHvHPcNIoCEawikAHzqxjjjqvAAe(categoryId))
							{
								return true;
							}
						}
					}
					return false;
				}

				public bool ContainsMapInCategory(string categoryName)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return false;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return false;
					}
					return ContainsMapInCategory(mapCategoryId);
				}

				public bool ContainsMapInCategory(ControllerType controllerType, int categoryId)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return false;
					}
					if (categoryId < 0)
					{
						return false;
					}
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
					for (int i = 0; i < num; i++)
					{
						if (fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA.xHvHPcNIoCEawikAHzqxjjjqvAAe(categoryId))
						{
							return true;
						}
					}
					return false;
				}

				public InputBehavior GetInputBehavior(int behaviorId)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					return ZKMrjqYqwUrfHWNFWcobmvVsFUqS.bEDLzXIxpNJGCtcHNVEXWnpWvKtD.aBmCPIjIQipDXvJzizuGNfyaNgx(ZKMrjqYqwUrfHWNFWcobmvVsFUqS.CbVfyyZWPLaMXAAoIrIHBSMHYdnm, behaviorId);
				}

				public InputBehavior GetInputBehavior(string behaviorName)
				{
					if (ReInput._id != ygQbVjvWgDxIBqyAhSVKpNzECBhf)
					{
						ReInput.CheckInitialized(ygQbVjvWgDxIBqyAhSVKpNzECBhf);
						return null;
					}
					return ZKMrjqYqwUrfHWNFWcobmvVsFUqS.bEDLzXIxpNJGCtcHNVEXWnpWvKtD.fGrbcxUbqLPGHwfPLCPGEIILpayh(ZKMrjqYqwUrfHWNFWcobmvVsFUqS.CbVfyyZWPLaMXAAoIrIHBSMHYdnm, behaviorName);
				}

				internal void bTqVxrcNUNIlflNpQbltIgBQaJiZA()
				{
					dneQVUpzGvnFlqrJPOIfmhiPLEMH.LoadDefaults();
					pkQVoppqQwryypmtZAPXxUwieeZv.LoadDefaults();
				}

				internal void ijHakGHSIDiDKPpFXNvfPVMCWGWcA(bool P_0)
				{
					if (NchDOXbJasBJCrgtwaskPSBiouAfb.oAGGudHeBrHOjZOMSoPMdwHzQpNkA == null)
					{
						return;
					}
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Joystick);
					sFNpRqSpUDBhuJIUMZgKMkxjutaR.pRqOhIQKigQoocBjtcSkXzVEpacG.oaaMVQRLSWarnnVtuOwBsvgOfkTO();
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
					for (int i = 0; i < num; i++)
					{
						BugNwVeIKhVzIDUOvQkABeSlylki<Joystick, JoystickMap>.QZjxExmeBWRuJGYTHbiqqUqGIllt qZjxExmeBWRuJGYTHbiqqUqGIllt = (BugNwVeIKhVzIDUOvQkABeSlylki<Joystick, JoystickMap>.QZjxExmeBWRuJGYTHbiqqUqGIllt)fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i);
						bool[] array = null;
						if (!P_0)
						{
							int num2 = qZjxExmeBWRuJGYTHbiqqUqGIllt.oNEqVoyniAQxhPXQGcMENGIkPfMg.uwAUgkekzffIxggNtXkaazjLDUnI();
							array = new bool[num2];
							for (int j = 0; j < num2; j++)
							{
								array[j] = qZjxExmeBWRuJGYTHbiqqUqGIllt.oNEqVoyniAQxhPXQGcMENGIkPfMg.dqSBzdtORLozVFHTanNDwzTffYco(j).enabled;
							}
						}
						qZjxExmeBWRuJGYTHbiqqUqGIllt.oNEqVoyniAQxhPXQGcMENGIkPfMg.FBvfSnDKUbayXpTjLfkyMKaMDbKB(false);
						for (int k = 0; k < NchDOXbJasBJCrgtwaskPSBiouAfb.oAGGudHeBrHOjZOMSoPMdwHzQpNkA.Length; k++)
						{
							DjoFfPVXpHIjcCqNLOtXaobftsmFA(qZjxExmeBWRuJGYTHbiqqUqGIllt.jShzJcgXohXkJgAjbKdTzokqckTE, qZjxExmeBWRuJGYTHbiqqUqGIllt.oNEqVoyniAQxhPXQGcMENGIkPfMg, NchDOXbJasBJCrgtwaskPSBiouAfb.oAGGudHeBrHOjZOMSoPMdwHzQpNkA[k], P_0);
						}
						if (!P_0)
						{
							int num3 = MathTools.Min(array.Length, qZjxExmeBWRuJGYTHbiqqUqGIllt.oNEqVoyniAQxhPXQGcMENGIkPfMg.uwAUgkekzffIxggNtXkaazjLDUnI());
							for (int l = 0; l < num3; l++)
							{
								qZjxExmeBWRuJGYTHbiqqUqGIllt.oNEqVoyniAQxhPXQGcMENGIkPfMg.dqSBzdtORLozVFHTanNDwzTffYco(l).enabled = array[l];
							}
						}
					}
					bool loadFromUserDataStore = pkQVoppqQwryypmtZAPXxUwieeZv.loadFromUserDataStore;
					pkQVoppqQwryypmtZAPXxUwieeZv.loadFromUserDataStore = false;
					pkQVoppqQwryypmtZAPXxUwieeZv.Apply();
					pkQVoppqQwryypmtZAPXxUwieeZv.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void kLXCSUbcyTWqvfJGJmRKBESPnzbQA(bool P_0)
				{
					if (NchDOXbJasBJCrgtwaskPSBiouAfb.eKWQFAciUiGDGSXjYljMqIVtWKxf == null)
					{
						return;
					}
					PQaFgQVynoEJfalLJXDCcVZTEKyx pQaFgQVynoEJfalLJXDCcVZTEKyx = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Keyboard).YacHzxfeOlVQUomSEcSTDHYQttOQA(0).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
					bool[] array = null;
					if (!P_0)
					{
						int num = pQaFgQVynoEJfalLJXDCcVZTEKyx.IdaghgVqdKwQFNEtDYEijJdcbVHeA;
						array = new bool[num];
						for (int i = 0; i < num; i++)
						{
							array[i] = pQaFgQVynoEJfalLJXDCcVZTEKyx.AZcUeIZqjwMekNcHfENpgGyCRDcAA(i).enabled;
						}
					}
					pQaFgQVynoEJfalLJXDCcVZTEKyx.vqriEKUZZEuKAkfTItcvlOTtKAJX(false);
					for (int j = 0; j < NchDOXbJasBJCrgtwaskPSBiouAfb.eKWQFAciUiGDGSXjYljMqIVtWKxf.Length; j++)
					{
						uaweSOKpQsMHsFdOWxAIaxBwmKwA uaweSOKpQsMHsFdOWxAIaxBwmKwA2 = NchDOXbJasBJCrgtwaskPSBiouAfb.eKWQFAciUiGDGSXjYljMqIVtWKxf[j];
						if (uaweSOKpQsMHsFdOWxAIaxBwmKwA2.TpmTSdDlxExHFxhzcGuDQDpEcpLm >= 0 && uaweSOKpQsMHsFdOWxAIaxBwmKwA2.yGasbGInDrPuQkhPyjbSFrxraSGO >= 0)
						{
							KeyboardMap keyboardMap = ReInput.UserData.FindKeyboardMap_Game(ReInput.controllers.Keyboard, uaweSOKpQsMHsFdOWxAIaxBwmKwA2.TpmTSdDlxExHFxhzcGuDQDpEcpLm, uaweSOKpQsMHsFdOWxAIaxBwmKwA2.yGasbGInDrPuQkhPyjbSFrxraSGO);
							if (P_0)
							{
								keyboardMap.enabled = uaweSOKpQsMHsFdOWxAIaxBwmKwA2.fHplnWXJvQSFkbmMruQhCRaensdR;
							}
							sCIJhjofuDsjLPxjntqYArjoPmPS(ControllerType.Keyboard, 0, keyboardMap, BoolOption.Default);
						}
					}
					if (!P_0)
					{
						int num2 = MathTools.Min(array.Length, pQaFgQVynoEJfalLJXDCcVZTEKyx.IdaghgVqdKwQFNEtDYEijJdcbVHeA);
						for (int k = 0; k < num2; k++)
						{
							pQaFgQVynoEJfalLJXDCcVZTEKyx.AZcUeIZqjwMekNcHfENpgGyCRDcAA(k).enabled = array[k];
						}
					}
					bool loadFromUserDataStore = pkQVoppqQwryypmtZAPXxUwieeZv.loadFromUserDataStore;
					pkQVoppqQwryypmtZAPXxUwieeZv.loadFromUserDataStore = false;
					pkQVoppqQwryypmtZAPXxUwieeZv.Apply();
					pkQVoppqQwryypmtZAPXxUwieeZv.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void mjacdxVZKTQCTPFXeDxVgPryfFut(bool P_0)
				{
					if (NchDOXbJasBJCrgtwaskPSBiouAfb.iRlCOkwRoMTXMmcTLFjbctRjuPxbA == null)
					{
						return;
					}
					PQaFgQVynoEJfalLJXDCcVZTEKyx pQaFgQVynoEJfalLJXDCcVZTEKyx = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Mouse).YacHzxfeOlVQUomSEcSTDHYQttOQA(0).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
					bool[] array = null;
					if (!P_0)
					{
						int num = pQaFgQVynoEJfalLJXDCcVZTEKyx.IdaghgVqdKwQFNEtDYEijJdcbVHeA;
						array = new bool[num];
						for (int i = 0; i < num; i++)
						{
							array[i] = pQaFgQVynoEJfalLJXDCcVZTEKyx.AZcUeIZqjwMekNcHfENpgGyCRDcAA(i).enabled;
						}
					}
					pQaFgQVynoEJfalLJXDCcVZTEKyx.vqriEKUZZEuKAkfTItcvlOTtKAJX(false);
					for (int j = 0; j < NchDOXbJasBJCrgtwaskPSBiouAfb.iRlCOkwRoMTXMmcTLFjbctRjuPxbA.Length; j++)
					{
						uaweSOKpQsMHsFdOWxAIaxBwmKwA uaweSOKpQsMHsFdOWxAIaxBwmKwA2 = NchDOXbJasBJCrgtwaskPSBiouAfb.iRlCOkwRoMTXMmcTLFjbctRjuPxbA[j];
						if (uaweSOKpQsMHsFdOWxAIaxBwmKwA2.TpmTSdDlxExHFxhzcGuDQDpEcpLm >= 0 && uaweSOKpQsMHsFdOWxAIaxBwmKwA2.yGasbGInDrPuQkhPyjbSFrxraSGO >= 0)
						{
							MouseMap mouseMap = ReInput.UserData.FindMouseMap_Game(ReInput.controllers.Mouse, uaweSOKpQsMHsFdOWxAIaxBwmKwA2.TpmTSdDlxExHFxhzcGuDQDpEcpLm, uaweSOKpQsMHsFdOWxAIaxBwmKwA2.yGasbGInDrPuQkhPyjbSFrxraSGO);
							if (P_0)
							{
								mouseMap.enabled = uaweSOKpQsMHsFdOWxAIaxBwmKwA2.fHplnWXJvQSFkbmMruQhCRaensdR;
							}
							sCIJhjofuDsjLPxjntqYArjoPmPS(ControllerType.Mouse, 0, mouseMap, BoolOption.Default);
						}
					}
					if (!P_0)
					{
						int num2 = MathTools.Min(array.Length, pQaFgQVynoEJfalLJXDCcVZTEKyx.IdaghgVqdKwQFNEtDYEijJdcbVHeA);
						for (int k = 0; k < num2; k++)
						{
							pQaFgQVynoEJfalLJXDCcVZTEKyx.AZcUeIZqjwMekNcHfENpgGyCRDcAA(k).enabled = array[k];
						}
					}
					bool loadFromUserDataStore = pkQVoppqQwryypmtZAPXxUwieeZv.loadFromUserDataStore;
					pkQVoppqQwryypmtZAPXxUwieeZv.loadFromUserDataStore = false;
					pkQVoppqQwryypmtZAPXxUwieeZv.Apply();
					pkQVoppqQwryypmtZAPXxUwieeZv.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void SEcXlgPEfHBmnEXMcWdcmMiTejXzA(bool P_0)
				{
					if (NchDOXbJasBJCrgtwaskPSBiouAfb.SqEGNKpgqQcXWloFdOhbXmLCqJpw == null)
					{
						return;
					}
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Custom);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
					for (int i = 0; i < num; i++)
					{
						BugNwVeIKhVzIDUOvQkABeSlylki<CustomController, CustomControllerMap>.QZjxExmeBWRuJGYTHbiqqUqGIllt qZjxExmeBWRuJGYTHbiqqUqGIllt = (BugNwVeIKhVzIDUOvQkABeSlylki<CustomController, CustomControllerMap>.QZjxExmeBWRuJGYTHbiqqUqGIllt)fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i);
						bool[] array = null;
						if (!P_0)
						{
							int num2 = qZjxExmeBWRuJGYTHbiqqUqGIllt.oNEqVoyniAQxhPXQGcMENGIkPfMg.uwAUgkekzffIxggNtXkaazjLDUnI();
							array = new bool[num2];
							for (int j = 0; j < num2; j++)
							{
								array[j] = qZjxExmeBWRuJGYTHbiqqUqGIllt.oNEqVoyniAQxhPXQGcMENGIkPfMg.dqSBzdtORLozVFHTanNDwzTffYco(j).enabled;
							}
						}
						qZjxExmeBWRuJGYTHbiqqUqGIllt.oNEqVoyniAQxhPXQGcMENGIkPfMg.FBvfSnDKUbayXpTjLfkyMKaMDbKB(false);
						for (int k = 0; k < NchDOXbJasBJCrgtwaskPSBiouAfb.SqEGNKpgqQcXWloFdOhbXmLCqJpw.Length; k++)
						{
							ocKuTamsoOYjtzwedGOcgbojkVkL(qZjxExmeBWRuJGYTHbiqqUqGIllt.jShzJcgXohXkJgAjbKdTzokqckTE, qZjxExmeBWRuJGYTHbiqqUqGIllt.oNEqVoyniAQxhPXQGcMENGIkPfMg, NchDOXbJasBJCrgtwaskPSBiouAfb.SqEGNKpgqQcXWloFdOhbXmLCqJpw[k], P_0);
						}
						if (!P_0)
						{
							int num3 = MathTools.Min(array.Length, qZjxExmeBWRuJGYTHbiqqUqGIllt.oNEqVoyniAQxhPXQGcMENGIkPfMg.uwAUgkekzffIxggNtXkaazjLDUnI());
							for (int l = 0; l < num3; l++)
							{
								qZjxExmeBWRuJGYTHbiqqUqGIllt.oNEqVoyniAQxhPXQGcMENGIkPfMg.dqSBzdtORLozVFHTanNDwzTffYco(l).enabled = array[l];
							}
						}
					}
					bool loadFromUserDataStore = pkQVoppqQwryypmtZAPXxUwieeZv.loadFromUserDataStore;
					pkQVoppqQwryypmtZAPXxUwieeZv.loadFromUserDataStore = false;
					pkQVoppqQwryypmtZAPXxUwieeZv.Apply();
					pkQVoppqQwryypmtZAPXxUwieeZv.loadFromUserDataStore = loadFromUserDataStore;
				}

				private FcTbzUBLOriYHtrisAslcxMVjwzbA zzRfMCXrJAAZIhKRwDfufvjgrfEqb<_0001>() where _0001 : ControllerMap
				{
					return sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.hctjVmRrxyLYqOIHBQxgQcoNfXiQ<_0001>());
				}

				internal global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<JoystickMap> rxCnIuiCdugeBhxBbXVaMZpPlXcPA(Joystick P_0, bool P_1)
				{
					if (P_0 == null || NchDOXbJasBJCrgtwaskPSBiouAfb.oAGGudHeBrHOjZOMSoPMdwHzQpNkA == null)
					{
						return null;
					}
					global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<JoystickMap> fwhFsFHQpVSqhlnVxqzYARYfqIXqb2 = new global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<JoystickMap>(P_0.id);
					for (int i = 0; i < NchDOXbJasBJCrgtwaskPSBiouAfb.oAGGudHeBrHOjZOMSoPMdwHzQpNkA.Length; i++)
					{
						DjoFfPVXpHIjcCqNLOtXaobftsmFA(P_0, fwhFsFHQpVSqhlnVxqzYARYfqIXqb2, NchDOXbJasBJCrgtwaskPSBiouAfb.oAGGudHeBrHOjZOMSoPMdwHzQpNkA[i], P_1);
					}
					if (fwhFsFHQpVSqhlnVxqzYARYfqIXqb2.uwAUgkekzffIxggNtXkaazjLDUnI() == 0)
					{
						return null;
					}
					return fwhFsFHQpVSqhlnVxqzYARYfqIXqb2;
				}

				private void DjoFfPVXpHIjcCqNLOtXaobftsmFA(Joystick P_0, global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<JoystickMap> P_1, uaweSOKpQsMHsFdOWxAIaxBwmKwA P_2, bool P_3)
				{
					if (P_0 != null && P_2 != null && P_2.TpmTSdDlxExHFxhzcGuDQDpEcpLm >= 0 && P_2.yGasbGInDrPuQkhPyjbSFrxraSGO >= 0)
					{
						JoystickMap joystickMap = ReInput.UserData.TMFORpelFDlBYkjQHYfeVwSIdqrR(P_0, P_2.TpmTSdDlxExHFxhzcGuDQDpEcpLm, P_2.yGasbGInDrPuQkhPyjbSFrxraSGO);
						jGdOJWyhNAdAkaugcQVcNgUAVgjDA(P_0, joystickMap);
						BoolOption boolOption = BoolOption.Default;
						if (P_3)
						{
							boolOption = (P_2.fHplnWXJvQSFkbmMruQhCRaensdR ? BoolOption.True : BoolOption.False);
						}
						P_1.MPClhUOnOJDGGbvtZQIOVkdIwzoz(joystickMap, boolOption);
					}
				}

				internal global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<CustomControllerMap> AipKrlBEYsyOafKCVaFzcbOiuBbGA(CustomController P_0, bool P_1)
				{
					if (P_0 == null || NchDOXbJasBJCrgtwaskPSBiouAfb.SqEGNKpgqQcXWloFdOhbXmLCqJpw == null)
					{
						return null;
					}
					global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<CustomControllerMap> fwhFsFHQpVSqhlnVxqzYARYfqIXqb2 = new global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<CustomControllerMap>(P_0.id);
					for (int i = 0; i < NchDOXbJasBJCrgtwaskPSBiouAfb.SqEGNKpgqQcXWloFdOhbXmLCqJpw.Length; i++)
					{
						ocKuTamsoOYjtzwedGOcgbojkVkL(P_0, fwhFsFHQpVSqhlnVxqzYARYfqIXqb2, NchDOXbJasBJCrgtwaskPSBiouAfb.SqEGNKpgqQcXWloFdOhbXmLCqJpw[i], P_1);
					}
					if (fwhFsFHQpVSqhlnVxqzYARYfqIXqb2.uwAUgkekzffIxggNtXkaazjLDUnI() == 0)
					{
						return null;
					}
					return fwhFsFHQpVSqhlnVxqzYARYfqIXqb2;
				}

				private void ocKuTamsoOYjtzwedGOcgbojkVkL(CustomController P_0, global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<CustomControllerMap> P_1, uaweSOKpQsMHsFdOWxAIaxBwmKwA P_2, bool P_3)
				{
					if (P_0 != null && P_2 != null && P_2.TpmTSdDlxExHFxhzcGuDQDpEcpLm >= 0 && P_2.yGasbGInDrPuQkhPyjbSFrxraSGO >= 0)
					{
						CustomControllerMap customControllerMap = ReInput.UserData.kTOdclpIebPuPOcvLBmyBSJyAHcAA(P_2.TpmTSdDlxExHFxhzcGuDQDpEcpLm, P_0.sourceControllerId, P_2.yGasbGInDrPuQkhPyjbSFrxraSGO);
						jGdOJWyhNAdAkaugcQVcNgUAVgjDA(P_0, customControllerMap);
						BoolOption boolOption = BoolOption.Default;
						if (P_3)
						{
							boolOption = (P_2.fHplnWXJvQSFkbmMruQhCRaensdR ? BoolOption.True : BoolOption.False);
						}
						P_1.MPClhUOnOJDGGbvtZQIOVkdIwzoz(customControllerMap, boolOption);
					}
				}

				internal void jGdOJWyhNAdAkaugcQVcNgUAVgjDA(Controller P_0, ControllerMap P_1)
				{
					if (P_0 != null && P_1 != null)
					{
						P_1.playerId = ZKMrjqYqwUrfHWNFWcobmvVsFUqS.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
						P_0.fsGAmSubJncncJCvyCKmjBAMAvWb(P_1);
					}
				}

				private IList<_0001> ThsCixkqaWAvoCzIMTPZiYsavIZvA<_0001>(int P_0) where _0001 : ControllerMap
				{
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = zzRfMCXrJAAZIhKRwDfufvjgrfEqb<_0001>();
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_0);
					if (num < 0)
					{
						return EmptyObjects<_0001>.EmptyReadOnlyIListT;
					}
					return fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.xGdWoIVtuYrQWDwxqcDfPVcUawiR<_0001>();
				}

				private IList<_0001> zwbukfmDwXHaCXRNVgOXKEcmIfbP<_0001>(Controller P_0) where _0001 : ControllerMap
				{
					return zzRfMCXrJAAZIhKRwDfufvjgrfEqb<_0001>().xikRtqzHNsOgfdlwxRoZWZxEUFqw(P_0)?.ahBHvaaFKqjYqOJIXAFDIKodzptCA.xGdWoIVtuYrQWDwxqcDfPVcUawiR<_0001>();
				}

				private IList<ControllerMap> rgZBjBkuYOaKLbFInMxILeUMMLCq(ControllerType P_0, int P_1)
				{
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_1);
					if (num < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.iBWakmwJlExbdlnUxGRNeGbUfhQo;
				}

				private IList<ControllerMap> zwbukfmDwXHaCXRNVgOXKEcmIfbP(Controller P_0)
				{
					return rgZBjBkuYOaKLbFInMxILeUMMLCq(P_0.type, P_0.id);
				}

				private void ePQeHmrIgePaFyhWbZxSHFizJbhd(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					ijoNMxJArDFCHDaMfEgEIhxHIRRVA(P_0, P_1, P_2, P_3, BoolOption.Default);
				}

				private void ZAAfeqdGScZzcBizKeSyBynHNDSm(Controller P_0, int P_1, int P_2)
				{
					tKtnZRIUJTwHLsNzFFQfpTyLxMPn(P_0, P_1, P_2, BoolOption.Default);
				}

				private void VjMAuoWTjzcNllBmJqxgOfifyAoq(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					pZpsAJionNaphkeKDJWtzhFTGagqA(P_0, P_1, P_2, P_3, BoolOption.Default);
				}

				private void tjRYHnxYEPYGwTmXhsxuHSgQVkzI(Controller P_0, string P_1, string P_2)
				{
					nKvBbMpgSLEGafexxIzkhztFSDQrA(P_0, P_1, P_2, BoolOption.Default);
				}

				private void ijoNMxJArDFCHDaMfEgEIhxHIRRVA(ControllerType P_0, int P_1, int P_2, int P_3, BoolOption P_4)
				{
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_1);
					if (num >= 0)
					{
						Controller controller = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).zrbrkQliupAqJogtCsiVGfsiiisW;
						ControllerMap controllerMap = ReInput.UserData.ScJIWgmKdhdnDAaTcyxOrBDAtCamA(controller, P_2, P_3);
						sCIJhjofuDsjLPxjntqYArjoPmPS(controller.type, controller.id, controllerMap, P_4);
					}
				}

				private void tKtnZRIUJTwHLsNzFFQfpTyLxMPn(Controller P_0, int P_1, int P_2, BoolOption P_3)
				{
					ijoNMxJArDFCHDaMfEgEIhxHIRRVA(P_0.type, P_0.id, P_1, P_2, P_3);
				}

				private void pZpsAJionNaphkeKDJWtzhFTGagqA(ControllerType P_0, int P_1, string P_2, string P_3, BoolOption P_4)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						ijoNMxJArDFCHDaMfEgEIhxHIRRVA(P_0, P_1, mapCategoryId, layoutId, P_4);
					}
				}

				private void nKvBbMpgSLEGafexxIzkhztFSDQrA(Controller P_0, string P_1, string P_2, BoolOption P_3)
				{
					pZpsAJionNaphkeKDJWtzhFTGagqA(P_0.type, P_0.id, P_1, P_2, P_3);
				}

				private void duApfNGHelKuGYUcfAbjinuIFTZjA(Controller P_0, ControllerMap P_1, BoolOption P_2)
				{
					if (P_0 != null && P_1 != null)
					{
						FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0.type);
						int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_0.id);
						if (num >= 0)
						{
							jGdOJWyhNAdAkaugcQVcNgUAVgjDA(P_0, P_1);
							fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.ANUPwUpIfZCOYLXqiRbqniMPIdeQ(P_1, P_2);
							dneQVUpzGvnFlqrJPOIfmhiPLEMH.Apply();
						}
					}
				}

				private void sCIJhjofuDsjLPxjntqYArjoPmPS(ControllerType P_0, int P_1, ControllerMap P_2, BoolOption P_3)
				{
					Controller controller = ReInput.controllers.GetController(P_0, P_1);
					if (controller != null)
					{
						duApfNGHelKuGYUcfAbjinuIFTZjA(controller, P_2, P_3);
					}
				}

				private bool cpulJVGdBTsbFlMstsiZiYJpSKjS(ControllerType P_0, int P_1, string P_2)
				{
					if (P_2 == null || P_2 == string.Empty)
					{
						return false;
					}
					if (sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0).ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_1) < 0)
					{
						return false;
					}
					ControllerMap controllerMap = ControllerMap.JEyMkYAwWgEipyvdoVluCMXeWMM(P_0);
					try
					{
						ControllerMap.lRmYCoCSmOckdAxZaAzbXHOzxRbC();
						if (!controllerMap.aFXcxTdtoLrAHgjbWpeHHiLAEmAjc(P_2))
						{
							return false;
						}
					}
					finally
					{
						ControllerMap.GHMgTTbTNZrCoRvrTvpOrmMMxTwr();
					}
					sCIJhjofuDsjLPxjntqYArjoPmPS(P_0, P_1, controllerMap, BoolOption.Default);
					return true;
				}

				private int OrbEwnhxMwnlveKFODNnOgrohxjfA(ControllerType P_0, int P_1, List<string> P_2)
				{
					if (P_2 == null || P_2.Count == 0)
					{
						return 0;
					}
					if (sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0).ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_1) < 0)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_2.Count; i++)
					{
						if (cpulJVGdBTsbFlMstsiZiYJpSKjS(P_0, P_1, P_2[i]))
						{
							num++;
						}
					}
					return num;
				}

				private bool jpwwtIHBPSXvyjsvKWRnLbBIOWCe(ControllerType P_0, int P_1, string P_2)
				{
					if (P_2 == null || P_2 == string.Empty)
					{
						return false;
					}
					if (sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0).ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_1) < 0)
					{
						return false;
					}
					ControllerMap controllerMap = ControllerMap.JEyMkYAwWgEipyvdoVluCMXeWMM(P_0);
					try
					{
						ControllerMap.lRmYCoCSmOckdAxZaAzbXHOzxRbC();
						if (!controllerMap.ZJYcZKuCueWpSBHqwGmVwGhyAMPB(P_2))
						{
							return false;
						}
					}
					finally
					{
						ControllerMap.GHMgTTbTNZrCoRvrTvpOrmMMxTwr();
					}
					sCIJhjofuDsjLPxjntqYArjoPmPS(P_0, P_1, controllerMap, BoolOption.Default);
					return true;
				}

				private int GPpXMVWXrOxqYsPDxMLYrVsyRbQK(ControllerType P_0, int P_1, List<string> P_2)
				{
					if (P_2 == null || P_2.Count == 0)
					{
						return 0;
					}
					if (sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0).ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_1) < 0)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_2.Count; i++)
					{
						if (jpwwtIHBPSXvyjsvKWRnLbBIOWCe(P_0, P_1, P_2[i]))
						{
							num++;
						}
					}
					return num;
				}

				private void lSstlOktijKHCtfZnbAYTieOEtRt(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_1);
					if (num >= 0)
					{
						Controller controller = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).zrbrkQliupAqJogtCsiVGfsiiisW;
						ControllerMap controllerMap = ControllerMap.iunHkujkyKtGOyVzXXcDBqMRPdDd(controller, P_2, P_3);
						sCIJhjofuDsjLPxjntqYArjoPmPS(controller.type, controller.id, controllerMap, BoolOption.Default);
					}
				}

				private void NpqvosGaRJVZmOglKoGsKhDrYaMT(Controller P_0, int P_1, int P_2)
				{
					lSstlOktijKHCtfZnbAYTieOEtRt(P_0.type, P_0.id, P_1, P_2);
				}

				private void tSMWpnmBQQtTfBpIuGhtsgyUFiBhA(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						lSstlOktijKHCtfZnbAYTieOEtRt(P_0, P_1, mapCategoryId, layoutId);
					}
				}

				private void pTcKflgdoIKjcIaRhsMINXdwMiCc(Controller P_0, string P_1, string P_2)
				{
					tSMWpnmBQQtTfBpIuGhtsgyUFiBhA(P_0.type, P_0.id, P_1, P_2);
				}

				private void AXkOcYmoLydodiDyYyXXQhXWiyIvA(ControllerType P_0, int P_1, int P_2)
				{
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_1);
					if (num >= 0)
					{
						fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.tZZeJcYeztVNtTpbsYoFBSKlrGCB(P_2);
					}
				}

				private void ippTKuegUzpeLNLDWpNuzNnQLXTn(Controller P_0, int P_1)
				{
					AXkOcYmoLydodiDyYyXXQhXWiyIvA(P_0.type, P_0.id, P_1);
				}

				private void fgYnvgCyakVnXZqsKvCpQhWBPrSL(ControllerType P_0, int P_1, ControllerMap P_2)
				{
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_1);
					if (num >= 0)
					{
						fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.zjgYpUmKZdjMuCcHDQMISbFZYKwH(P_2);
					}
				}

				private void FIifqfdWrFPgOybvqrNbFKpGMAOq(Controller P_0, ControllerMap P_1)
				{
					AXkOcYmoLydodiDyYyXXQhXWiyIvA(P_0.type, P_0.id, P_1.id);
				}

				private void CUSkOuMwPcAzutlaFbDUuRPnTYfK(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_1);
					if (num >= 0)
					{
						fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.kvFNncpbGNHESQXIziOLAFguhWClA(P_2, P_3);
					}
				}

				private void QwmqIONaYWdGHXggjIuQKNxabTRZ(Controller P_0, int P_1, int P_2)
				{
					CUSkOuMwPcAzutlaFbDUuRPnTYfK(P_0.type, P_0.id, P_1, P_2);
				}

				private void qubMwBihcZojjkINvOyCeboXONXL(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_1);
					if (num >= 0)
					{
						int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
						int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
						if (mapCategoryId >= 0 && layoutId >= 0)
						{
							fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.kvFNncpbGNHESQXIziOLAFguhWClA(mapCategoryId, layoutId);
						}
					}
				}

				private void GYOTVDOzLtPPZFnCraNnfvCnOFjH(Controller P_0, string P_1, string P_2)
				{
					qubMwBihcZojjkINvOyCeboXONXL(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap aPYFMEhwBULlykemBfcrFdwhtQUw(ControllerType P_0, int P_1, int P_2)
				{
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_1);
					if (num < 0)
					{
						return null;
					}
					return fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.OzQvFluJYEaucOhJVdhJHwGQlDnW(P_2);
				}

				private ControllerMap FsGIpPbHRKAAuItKbUhEurYjwLqBA(Controller P_0, int P_1)
				{
					return aPYFMEhwBULlykemBfcrFdwhtQUw(P_0.type, P_0.id, P_1);
				}

				private ControllerMap dnfOFRDFMkDkawdymPPNchMuYnhi(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_1);
					if (num < 0)
					{
						return null;
					}
					return fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.GCAABIZhDIBygDINLvHOQdXnCGaf(P_2, P_3);
				}

				private ControllerMap syUXrXpbrBsYfDNghaZQMCTNumDv(Controller P_0, int P_1, int P_2)
				{
					return dnfOFRDFMkDkawdymPPNchMuYnhi(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap URVJMcnNESPbXXPPGRhDqswQaNMg(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return dnfOFRDFMkDkawdymPPNchMuYnhi(P_0, P_1, mapCategoryId, layoutId);
				}

				private ControllerMap bUMVxtQJkKoAgPocSiYsnPqCnFju(Controller P_0, string P_1, string P_2)
				{
					return URVJMcnNESPbXXPPGRhDqswQaNMg(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap oMnClbQndFtryIBpLEhwzafWimqW(ControllerType P_0, int P_1, int P_2)
				{
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_1);
					if (num < 0)
					{
						return null;
					}
					return fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.PksAiGlfuhsjRVYLoTdjxRjratMv(P_2);
				}

				private ControllerMap lTVdIaltzbXiHyhiEYsnrGXWQese(Controller P_0, int P_1)
				{
					return oMnClbQndFtryIBpLEhwzafWimqW(P_0.type, P_0.id, P_1);
				}

				private ControllerMap YrqNSCJljASSuzgXLBaPktWWAZn(ControllerType P_0, int P_1, string P_2)
				{
					int mapCategoryId = ReInput.UserData.GetMapCategoryId(P_2);
					if (mapCategoryId < 0)
					{
						return null;
					}
					return oMnClbQndFtryIBpLEhwzafWimqW(P_0, P_1, mapCategoryId);
				}

				private ControllerMap HKFhfIcsXnIHcJdmkaSmnnPUogqM(Controller P_0, string P_1)
				{
					return YrqNSCJljASSuzgXLBaPktWWAZn(P_0.type, P_0.id, P_1);
				}

				private ControllerMap[] srMhLGcDrYgWMkTKibtwqARaPClr(ControllerType P_0)
				{
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					int num = 0;
					for (int i = 0; i < fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh; i++)
					{
						num += fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA.IdaghgVqdKwQFNEtDYEijJdcbVHeA;
					}
					ControllerMap[] array = new ControllerMap[num];
					num = 0;
					for (int j = 0; j < fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh; j++)
					{
						PQaFgQVynoEJfalLJXDCcVZTEKyx pQaFgQVynoEJfalLJXDCcVZTEKyx = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(j).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
						for (int k = 0; k < pQaFgQVynoEJfalLJXDCcVZTEKyx.IdaghgVqdKwQFNEtDYEijJdcbVHeA; k++)
						{
							array[num] = pQaFgQVynoEJfalLJXDCcVZTEKyx.AZcUeIZqjwMekNcHfENpgGyCRDcAA(k);
							num++;
						}
					}
					return array;
				}

				private ControllerMapSaveData[] yANcKSsBWeIbuAbQckkaAhXmfLujA(ControllerType P_0, int P_1, bool P_2)
				{
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_1);
					if (num < 0)
					{
						return null;
					}
					List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
					PQaFgQVynoEJfalLJXDCcVZTEKyx pQaFgQVynoEJfalLJXDCcVZTEKyx = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
					for (int i = 0; i < pQaFgQVynoEJfalLJXDCcVZTEKyx.IdaghgVqdKwQFNEtDYEijJdcbVHeA; i++)
					{
						ControllerMap controllerMap = pQaFgQVynoEJfalLJXDCcVZTEKyx.AZcUeIZqjwMekNcHfENpgGyCRDcAA(i);
						if (P_2)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory != null && !mapCategory.userAssignable)
							{
								continue;
							}
						}
						Controller controller = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).zrbrkQliupAqJogtCsiVGfsiiisW;
						list.Add(ControllerMapSaveData.wFcFdmtZLmndqIKPgEotGhuzzhffA(controller, controllerMap));
					}
					return list.ToArray();
				}

				private _0001[] UKNzxErKMBVybXSyCCXKIrWDbLMf<_0001>(int P_0, bool P_1) where _0001 : ControllerMapSaveData
				{
					ControllerType controllerType = GHPcAvLGyrhUIIuLWeQoyFTYgunBA.PItNjOQjniDZauGGSDuPNPFFfofDA<_0001>();
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_0);
					if (num < 0)
					{
						return null;
					}
					List<_0001> list = new List<_0001>();
					PQaFgQVynoEJfalLJXDCcVZTEKyx pQaFgQVynoEJfalLJXDCcVZTEKyx = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
					for (int i = 0; i < pQaFgQVynoEJfalLJXDCcVZTEKyx.IdaghgVqdKwQFNEtDYEijJdcbVHeA; i++)
					{
						ControllerMap controllerMap = pQaFgQVynoEJfalLJXDCcVZTEKyx.AZcUeIZqjwMekNcHfENpgGyCRDcAA(i);
						if (P_1)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory != null && !mapCategory.userAssignable)
							{
								continue;
							}
						}
						Controller controller = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).zrbrkQliupAqJogtCsiVGfsiiisW;
						list.Add(ControllerMapSaveData.wFcFdmtZLmndqIKPgEotGhuzzhffA<_0001>(controller, controllerMap));
					}
					return list.ToArray();
				}

				private ControllerMapSaveData[] zAtMhysdhSMqXBeXgIbdFidceyhk(ControllerType P_0, bool P_1)
				{
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
					for (int i = 0; i < fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh; i++)
					{
						PQaFgQVynoEJfalLJXDCcVZTEKyx pQaFgQVynoEJfalLJXDCcVZTEKyx = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
						for (int j = 0; j < pQaFgQVynoEJfalLJXDCcVZTEKyx.IdaghgVqdKwQFNEtDYEijJdcbVHeA; j++)
						{
							ControllerMap controllerMap = pQaFgQVynoEJfalLJXDCcVZTEKyx.AZcUeIZqjwMekNcHfENpgGyCRDcAA(j);
							if (P_1)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
								if (mapCategory != null && !mapCategory.userAssignable)
								{
									continue;
								}
							}
							Controller controller = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).zrbrkQliupAqJogtCsiVGfsiiisW;
							list.Add(ControllerMapSaveData.wFcFdmtZLmndqIKPgEotGhuzzhffA(controller, controllerMap));
						}
					}
					return list.ToArray();
				}

				private _0001[] DPeefuhTDtVjGIpLfmbtCcsmbCBRA<_0001>(bool P_0) where _0001 : ControllerMapSaveData
				{
					ControllerType controllerType = GHPcAvLGyrhUIIuLWeQoyFTYgunBA.PItNjOQjniDZauGGSDuPNPFFfofDA<_0001>();
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType);
					List<_0001> list = new List<_0001>();
					for (int i = 0; i < fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh; i++)
					{
						PQaFgQVynoEJfalLJXDCcVZTEKyx pQaFgQVynoEJfalLJXDCcVZTEKyx = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
						for (int j = 0; j < pQaFgQVynoEJfalLJXDCcVZTEKyx.IdaghgVqdKwQFNEtDYEijJdcbVHeA; j++)
						{
							ControllerMap controllerMap = pQaFgQVynoEJfalLJXDCcVZTEKyx.AZcUeIZqjwMekNcHfENpgGyCRDcAA(j);
							if (P_0)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
								if (mapCategory != null && !mapCategory.userAssignable)
								{
									continue;
								}
							}
							Controller controller = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).zrbrkQliupAqJogtCsiVGfsiiisW;
							list.Add(ControllerMapSaveData.wFcFdmtZLmndqIKPgEotGhuzzhffA<_0001>(controller, controllerMap));
						}
					}
					return list.ToArray();
				}

				private int UiJwOZlIbyyPignOOuUVYjEGTvyp(ControllerType P_0, int P_1, int P_2, List<ControllerMap> P_3)
				{
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_1);
					if (num < 0)
					{
						return 0;
					}
					return fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.RNbMgXJLQHPCpwfrdRyerhEBaXbk(P_2, P_3, false);
				}

				private int JuJrvUaGsoioCNodvSMYraEuiBdc(Controller P_0, int P_1, List<ControllerMap> P_2)
				{
					return UiJwOZlIbyyPignOOuUVYjEGTvyp(P_0.type, P_0.id, P_1, P_2);
				}

				private int XtQxYJtIhmZQpRlBdZXLcFTVXsVd(ControllerType P_0, int P_1, string P_2, List<ControllerMap> P_3)
				{
					int mapCategoryId = ReInput.UserData.GetMapCategoryId(P_2);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return UiJwOZlIbyyPignOOuUVYjEGTvyp(P_0, P_1, mapCategoryId, P_3);
				}

				private int wOJWWULDtRgLukgPTOKATiIUfUgrA(Controller P_0, string P_1, List<ControllerMap> P_2)
				{
					return XtQxYJtIhmZQpRlBdZXLcFTVXsVd(P_0.type, P_0.id, P_1, P_2);
				}

				[IteratorStateMachine(typeof(tPwObtbIdxvJAKnYUfQMUYGhASBJ))]
				private IEnumerable<ControllerMap> LIyvtLYDtXyNcyIIcoUqGEaVmaMf(ControllerType P_0, int P_1, int P_2)
				{
					return new tPwObtbIdxvJAKnYUfQMUYGhASBJ(-2)
					{
						ivojNPXkJeqPpAfKIrluYxeplohH = this,
						WktBBIYtjfWoFauGYgafQOkJcPGcA = P_0,
						OwNniYwdGQGdNIBxnjhkcoZCHLvib = P_1,
						GSRFzudxXNScvBfjIfoOkdFAFMmZ = P_2
					};
				}

				[IteratorStateMachine(typeof(STWKSkmSjsuDWEyfvBQXzbhJrrhU))]
				private IEnumerable<_0001> omcaWcYHDLFWbzkFybHRFmggtSYFA<_0001>(int P_0, int P_1) where _0001 : ControllerMap
				{
					return new STWKSkmSjsuDWEyfvBQXzbhJrrhU<_0001>(-2)
					{
						ZfiEmRewPkmmxafSvcPvmPySXDrY = this,
						sHrChsivVWSBTKcqDJzOCDCSxyJEb = P_0,
						jOTkrlPKluLhbIEngnHDVdMcGRKd = P_1
					};
				}

				private ActionElementMap cskerdsFOHjwoNKPEDcNHwIQmAPhA(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					for (int i = 0; i < fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh; i++)
					{
						IList<ControllerMap> list = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA.iBWakmwJlExbdlnUxGRNeGbUfhQo;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								ActionElementMap firstButtonMapWithAction = list[j].GetFirstButtonMapWithAction(P_1, P_2);
								if (firstButtonMapWithAction != null)
								{
									return firstButtonMapWithAction;
								}
							}
						}
					}
					return null;
				}

				private ActionElementMap BawjCBHsQckxsgQmaUDZJwpxrWAzA(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_1);
					return cskerdsFOHjwoNKPEDcNHwIQmAPhA(P_0, num, P_2);
				}

				[IteratorStateMachine(typeof(edDarBbPSVOOraILYXTbWVXlLTsm))]
				private IEnumerable<ActionElementMap> zfNzpKzDCKQfUSLnuNSMfALmfafF(ControllerType P_0, int P_1, bool P_2)
				{
					return new edDarBbPSVOOraILYXTbWVXlLTsm(-2)
					{
						TLsJaAHtyaqKAUEmSYzNCoaweqBb = this,
						WSDqVvFTvicTLXEhyFQmpVxHgGSl = P_0,
						dugrWkUHJXSMjkvIetcdWkIfroxC = P_1,
						TXNWhAuJYGEkyrCoIIzufegQDacV = P_2
					};
				}

				private IEnumerable<ActionElementMap> bZggXrmKtdZzDKIHHAzmqFHawrIp(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_1);
					return zfNzpKzDCKQfUSLnuNSMfALmfafF(P_0, num, P_2);
				}

				private ActionElementMap OpOUOWBbiIFSMYNBzRIYwEnDiiib(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					for (int i = 0; i < fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh; i++)
					{
						IList<ControllerMap> list = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA.iBWakmwJlExbdlnUxGRNeGbUfhQo;
						for (int j = 0; j < list.Count; j++)
						{
							if (!(list[j] is ControllerMapWithAxes))
							{
								return null;
							}
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								ActionElementMap firstAxisMapWithAction = (list[j] as ControllerMapWithAxes).GetFirstAxisMapWithAction(P_1, P_2);
								if (firstAxisMapWithAction != null)
								{
									return firstAxisMapWithAction;
								}
							}
						}
					}
					return null;
				}

				private ActionElementMap ryGmBtFfmPDgngDgXhJXaFhygLjg(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_1);
					return OpOUOWBbiIFSMYNBzRIYwEnDiiib(P_0, num, P_2);
				}

				[IteratorStateMachine(typeof(jTviTuNodvCfJbjGydQSUbFyjtjab))]
				private IEnumerable<ActionElementMap> dSwRcYYQhwQZbflQdaDlJPFYIMXn(ControllerType P_0, int P_1, bool P_2)
				{
					return new jTviTuNodvCfJbjGydQSUbFyjtjab(-2)
					{
						stRzMUDvtXsLqXRNvIgWvgHJvcE = this,
						WCCwqvQunDWAQeUBLEKtifWSyuDw = P_0,
						RVRjtbQSFCtxKqnNzHekfFzXncKO = P_1,
						jwpWubyXEubVcCQFaMrXcBTEclKFA = P_2
					};
				}

				private IEnumerable<ActionElementMap> nVMvGwWggJDurDjqsZUZwnaBucLm(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_1);
					return dSwRcYYQhwQZbflQdaDlJPFYIMXn(P_0, num, P_2);
				}

				private ActionElementMap aDwydSUVmaXjDIpeyDauwdByNjXI(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					for (int i = 0; i < fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh; i++)
					{
						IList<ControllerMap> list = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA.iBWakmwJlExbdlnUxGRNeGbUfhQo;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								ActionElementMap firstElementMapWithAction = list[j].GetFirstElementMapWithAction(P_1, P_2);
								if (firstElementMapWithAction != null)
								{
									return firstElementMapWithAction;
								}
							}
						}
					}
					return null;
				}

				private ActionElementMap sXCtdNtaxArbQqSpflQdxxIDWdgw(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_1);
					return aDwydSUVmaXjDIpeyDauwdByNjXI(P_0, num, P_2);
				}

				[IteratorStateMachine(typeof(BuRZxIZIxCcaSlsUDkNagjmhUUTQ))]
				private IEnumerable<ActionElementMap> RpgfaRxATWbKDtzmzFmrjTqsyOmD(ControllerType P_0, int P_1, bool P_2)
				{
					return new BuRZxIZIxCcaSlsUDkNagjmhUUTQ(-2)
					{
						VfigwIfdYFBHwvLFRSsXYcDDavld = this,
						vQTJQWSESYvvmBnmEmIWetpOdcnO = P_0,
						ANdJgINhIYbBbrrTnBhcIvQkIZuNA = P_1,
						QEyVOkyggZnZJVLWqmHnbpMrRAaX = P_2
					};
				}

				private IEnumerable<ActionElementMap> iXvfphQwQVUWoJulwiAPNfIhwZnU(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_1);
					return RpgfaRxATWbKDtzmzFmrjTqsyOmD(P_0, num, P_2);
				}

				private int hWZOkklkXXIDzPSAHVTSimFfgtWi(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
				{
					if (P_2 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_3)
					{
						P_2.Clear();
					}
					if (P_0 < 0)
					{
						return 0;
					}
					int num = 0;
					int eWwWlDdWcqJQmgAiLeFBWdVumGMb = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb;
					for (int i = 0; i < eWwWlDdWcqJQmgAiLeFBWdVumGMb; i++)
					{
						FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.YPeyRKgKWPSqEsMokJyVccifhDpb(i);
						int num2 = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
						for (int j = 0; j < num2; j++)
						{
							PQaFgQVynoEJfalLJXDCcVZTEKyx pQaFgQVynoEJfalLJXDCcVZTEKyx = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(j).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
							int num3 = pQaFgQVynoEJfalLJXDCcVZTEKyx.IdaghgVqdKwQFNEtDYEijJdcbVHeA;
							for (int k = 0; k < num3; k++)
							{
								ControllerMap controllerMap = pQaFgQVynoEJfalLJXDCcVZTEKyx.AZcUeIZqjwMekNcHfENpgGyCRDcAA(k);
								if ((!P_1 || controllerMap.enabled) && controllerMap.ContainsAction(P_0))
								{
									num += controllerMap.MeahSXUNzyzWOIzpZetqJqQqRvGA(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int bNyKfFVTPAGUNWJdcclRYQsTsuAc(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
				{
					if (P_2 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_3)
					{
						P_2.Clear();
					}
					if (P_0 < 0)
					{
						return 0;
					}
					int num = 0;
					int eWwWlDdWcqJQmgAiLeFBWdVumGMb = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb;
					for (int i = 0; i < eWwWlDdWcqJQmgAiLeFBWdVumGMb; i++)
					{
						FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.YPeyRKgKWPSqEsMokJyVccifhDpb(i);
						int num2 = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
						for (int j = 0; j < num2; j++)
						{
							PQaFgQVynoEJfalLJXDCcVZTEKyx pQaFgQVynoEJfalLJXDCcVZTEKyx = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(j).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
							int num3 = pQaFgQVynoEJfalLJXDCcVZTEKyx.IdaghgVqdKwQFNEtDYEijJdcbVHeA;
							for (int k = 0; k < num3; k++)
							{
								if (pQaFgQVynoEJfalLJXDCcVZTEKyx.AZcUeIZqjwMekNcHfENpgGyCRDcAA(k) is ControllerMapWithAxes controllerMapWithAxes && (!P_1 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(P_0))
								{
									num += controllerMapWithAxes.zBsMPUoxyhorlaxaYJdHqcIpmvQg(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int mLosgPYyPZVjLnJfLhrRwBwzctDC(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
				{
					if (P_2 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_3)
					{
						P_2.Clear();
					}
					if (P_0 < 0)
					{
						return 0;
					}
					int num = 0;
					int eWwWlDdWcqJQmgAiLeFBWdVumGMb = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb;
					for (int i = 0; i < eWwWlDdWcqJQmgAiLeFBWdVumGMb; i++)
					{
						FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.YPeyRKgKWPSqEsMokJyVccifhDpb(i);
						int num2 = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
						for (int j = 0; j < num2; j++)
						{
							PQaFgQVynoEJfalLJXDCcVZTEKyx pQaFgQVynoEJfalLJXDCcVZTEKyx = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(j).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
							int num3 = pQaFgQVynoEJfalLJXDCcVZTEKyx.IdaghgVqdKwQFNEtDYEijJdcbVHeA;
							for (int k = 0; k < num3; k++)
							{
								ControllerMap controllerMap = pQaFgQVynoEJfalLJXDCcVZTEKyx.AZcUeIZqjwMekNcHfENpgGyCRDcAA(k);
								if ((!P_1 || controllerMap.enabled) && controllerMap.ContainsAction(P_0))
								{
									num += controllerMap.cAwvQRajuNSdcVfCIbMQuiDVTnmt(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int MDYuQoWKxibzbpJmVJzGfZpcPwTU(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					if (P_3 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_4)
					{
						P_3.Clear();
					}
					if (P_1 < 0)
					{
						return 0;
					}
					int num = 0;
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					for (int i = 0; i < fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh; i++)
					{
						IList<ControllerMap> list = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA.iBWakmwJlExbdlnUxGRNeGbUfhQo;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += list[j].MeahSXUNzyzWOIzpZetqJqQqRvGA(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int wMTyJpkZtnIVZwltPGIHkHVENlOiA(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_1);
					return MDYuQoWKxibzbpJmVJzGfZpcPwTU(P_0, num, P_2, P_3, P_4);
				}

				private int kMwSsgHQJlHQQOiNiOaTqAnPZHoJ(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					if (P_3 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_4)
					{
						P_3.Clear();
					}
					if (P_1 < 0)
					{
						return 0;
					}
					int num = 0;
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					for (int i = 0; i < fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh; i++)
					{
						IList<ControllerMap> list = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA.iBWakmwJlExbdlnUxGRNeGbUfhQo;
						for (int j = 0; j < list.Count; j++)
						{
							if (!(list[j] is ControllerMapWithAxes))
							{
								return P_3.Count;
							}
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += (list[j] as ControllerMapWithAxes).zBsMPUoxyhorlaxaYJdHqcIpmvQg(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int mcIclLTwXMeFcSJKhkIBvicAgkzj(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_1);
					return kMwSsgHQJlHQQOiNiOaTqAnPZHoJ(P_0, num, P_2, P_3, P_4);
				}

				private int gQTQcBQkJqFrVgOpTEhNNWYgxKNmA(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					if (P_3 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_4)
					{
						P_3.Clear();
					}
					if (P_1 < 0)
					{
						return 0;
					}
					int num = 0;
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					for (int i = 0; i < fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh; i++)
					{
						IList<ControllerMap> list = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA.iBWakmwJlExbdlnUxGRNeGbUfhQo;
						for (int j = 0; j < list.Count; j++)
						{
							if ((!P_2 || list[j].enabled) && list[j].ContainsAction(P_1))
							{
								num += list[j].cAwvQRajuNSdcVfCIbMQuiDVTnmt(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int cmxktkvZDCSFUbzMyQDbTUlYAFdU(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_1);
					return gQTQcBQkJqFrVgOpTEhNNWYgxKNmA(P_0, num, P_2, P_3, P_4);
				}

				private ActionElementMap qwVDIMebyXAKZOoRFvcMcuOJbfWFb(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.iBWakmwJlExbdlnUxGRNeGbUfhQo;
					for (int i = 0; i < list.Count; i++)
					{
						if ((!P_3 || list[i].enabled) && list[i].ContainsAction(P_2))
						{
							ActionElementMap firstButtonMapWithAction = list[i].GetFirstButtonMapWithAction(P_2, P_3);
							if (firstButtonMapWithAction != null)
							{
								return firstButtonMapWithAction;
							}
						}
					}
					return null;
				}

				private ActionElementMap qsFwHTEjzzGmbuaAwVeAQkLutwxT(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_2);
					return qwVDIMebyXAKZOoRFvcMcuOJbfWFb(P_0, P_1, num, P_3);
				}

				[IteratorStateMachine(typeof(XvYAtNkrcDnLxkBFJfRIWDCHFRMk))]
				private IEnumerable<ActionElementMap> FwtZiQCpLuVBwIAKIjFAuyFuLcHu(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new XvYAtNkrcDnLxkBFJfRIWDCHFRMk(-2)
					{
						SDfrmRsBINvFpAkujWuPhNyyuUfI = this,
						XScDMuNzriulKdZnFWLCTuxEImAF = P_0,
						YVmgPGDUJGALWagNBGjRKFKkNMYxA = P_1,
						lEpzodbuoIIZadomStnsqItPCcQp = P_2,
						NujtdQGKNNYMaTKLhuIkpFyMrctQ = P_3
					};
				}

				private IEnumerable<ActionElementMap> cXfIeyQWTkKlZpfZQsCtygmgTAqt(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_2);
					return FwtZiQCpLuVBwIAKIjFAuyFuLcHu(P_0, P_1, num, P_3);
				}

				private ActionElementMap IhDFiuknbFQVVjyNsXRcxkTkWHcHA(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.iBWakmwJlExbdlnUxGRNeGbUfhQo;
					for (int i = 0; i < list.Count; i++)
					{
						if (!(list[i] is ControllerMapWithAxes))
						{
							return null;
						}
						if ((!P_3 || list[i].enabled) && list[i].ContainsAction(P_2))
						{
							ActionElementMap firstAxisMapWithAction = (list[i] as ControllerMapWithAxes).GetFirstAxisMapWithAction(P_2, P_3);
							if (firstAxisMapWithAction != null)
							{
								return firstAxisMapWithAction;
							}
						}
					}
					return null;
				}

				private ActionElementMap YNTvSqddHwFfNiQrIMxugEPJsZLcA(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_2);
					return IhDFiuknbFQVVjyNsXRcxkTkWHcHA(P_0, P_1, num, P_3);
				}

				[IteratorStateMachine(typeof(bnSDPFdRwecPeJfbnnoQBEuOQcdWA))]
				private IEnumerable<ActionElementMap> TXrFgAcSjfoKrSQmCAjeXmQxtOdr(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new bnSDPFdRwecPeJfbnnoQBEuOQcdWA(-2)
					{
						CcbgHoavOZYCLtutIXnOPDrilOIHb = this,
						mcuRvaMbeZOVcJubRuKFyLvfUPtK = P_0,
						XFZgbccKxogDHgyyniPAQyNYTJDE = P_1,
						tIhfqMxcMonOUvyWdGXiBtOkaKMB = P_2,
						yxTgBOHvHfMZNvQabNXNZGjgLcwWA = P_3
					};
				}

				private IEnumerable<ActionElementMap> TLFjhiwfVcUmGRbhaYNnsgEjhygW(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_2);
					return TXrFgAcSjfoKrSQmCAjeXmQxtOdr(P_0, P_1, num, P_3);
				}

				private ActionElementMap eDGpZZhYukcaHsGDabadkBUqMFrlA(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> list = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.iBWakmwJlExbdlnUxGRNeGbUfhQo;
					for (int i = 0; i < list.Count; i++)
					{
						if ((!P_3 || list[i].enabled) && list[i].ContainsAction(P_2))
						{
							ActionElementMap firstElementMapWithAction = list[i].GetFirstElementMapWithAction(P_2, P_3);
							if (firstElementMapWithAction != null)
							{
								return firstElementMapWithAction;
							}
						}
					}
					return null;
				}

				private ActionElementMap MuTXKAPPIDPQFaOYUEzAeawBrhHFA(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_2);
					return eDGpZZhYukcaHsGDabadkBUqMFrlA(P_0, P_1, num, P_3);
				}

				[IteratorStateMachine(typeof(uXGvhCUGqVfqjJeCBlBEVRHfPBjIA))]
				private IEnumerable<ActionElementMap> VMlahaXIbabWECrPyGKDFjqcmsOGA(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					return new uXGvhCUGqVfqjJeCBlBEVRHfPBjIA(-2)
					{
						BSbqIASJETkEGyEkNWAaaJjeletf = this,
						faygocFEcTjpQnexhkEtEzUWuqHDb = P_0,
						EvdRArwLCjIiriVQTCClvlmmJJyw = P_1,
						zATQUERSfGQcQIYeeRmgcEgYtkaf = P_2,
						GsFdKtGZXVKCnBYfPwFmPmdTsJTiA = P_3
					};
				}

				private IEnumerable<ActionElementMap> OXlAuDhUyIrQzBnUrBGvMEUCrskM(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_2);
					return VMlahaXIbabWECrPyGKDFjqcmsOGA(P_0, P_1, num, P_3);
				}

				private int jNvzeTmGvvorxesVphFCvEbeRajJ(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					if (P_4 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_5)
					{
						P_4.Clear();
					}
					if (P_2 < 0)
					{
						return 0;
					}
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.iBWakmwJlExbdlnUxGRNeGbUfhQo;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerMap controllerMap = list[i];
						if ((!P_3 || controllerMap.enabled) && controllerMap.ContainsAction(P_2))
						{
							num2 += controllerMap.MeahSXUNzyzWOIzpZetqJqQqRvGA(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int glNAbaUfPOVaHDrGzaJaaGeLPnHL(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_2);
					return jNvzeTmGvvorxesVphFCvEbeRajJ(P_0, P_1, num, P_3, P_4, P_5);
				}

				private int DDVHHpOyHKCAVryYUQMIIQbtShWh(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					if (P_4 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_5)
					{
						P_4.Clear();
					}
					if (P_2 < 0)
					{
						return 0;
					}
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.iBWakmwJlExbdlnUxGRNeGbUfhQo;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerMapWithAxes controllerMapWithAxes = list[i] as ControllerMapWithAxes;
						if (list == null)
						{
							return num2;
						}
						if ((!P_3 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(P_2))
						{
							num2 += controllerMapWithAxes.zBsMPUoxyhorlaxaYJdHqcIpmvQg(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int FHyxJCbYLLHyNwaWxAmqjsRdanVoA(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_2);
					return DDVHHpOyHKCAVryYUQMIIQbtShWh(P_0, P_1, num, P_3, P_4, P_5);
				}

				private int DJBptTNiYWepbkKtodQPzArNxmKDA(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					if (P_4 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_5)
					{
						P_4.Clear();
					}
					if (P_2 < 0)
					{
						return 0;
					}
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.ZFBzTFwswXrvsclNBdTpeSiMzSsH(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> list = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).ahBHvaaFKqjYqOJIXAFDIKodzptCA.iBWakmwJlExbdlnUxGRNeGbUfhQo;
					for (int i = 0; i < list.Count; i++)
					{
						if ((!P_3 || list[i].enabled) && list[i].ContainsAction(P_2))
						{
							num2 += list[i].cAwvQRajuNSdcVfCIbMQuiDVTnmt(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int ByxIAsbtXpJXFKqOCFXTWPlPWnjG(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(P_2);
					return DJBptTNiYWepbkKtodQPzArNxmKDA(P_0, P_1, num, P_3, P_4, P_5);
				}

				private ActionElementMap minnnPERqyKFxFMZGGvefsjEcMLU(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3)
				{
					if (P_0 == null)
					{
						return null;
					}
					Controller controller = P_0.controller;
					if (controller == null)
					{
						return null;
					}
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controller.type);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
					for (int i = 0; i < num; i++)
					{
						PQaFgQVynoEJfalLJXDCcVZTEKyx pQaFgQVynoEJfalLJXDCcVZTEKyx = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
						_ = pQaFgQVynoEJfalLJXDCcVZTEKyx.IdaghgVqdKwQFNEtDYEijJdcbVHeA;
						IList<ControllerMap> list = pQaFgQVynoEJfalLJXDCcVZTEKyx.iBWakmwJlExbdlnUxGRNeGbUfhQo;
						int count = list.Count;
						for (int j = 0; j < count; j++)
						{
							ControllerMap controllerMap = list[j];
							if (!P_3 || controllerMap.enabled)
							{
								bool flag;
								ActionElementMap actionElementMap = controllerMap.rLYedBCsdtfUPGpuxQjkUgoLtSyKA(P_0, P_1, P_2, P_3, out flag);
								if (actionElementMap != null)
								{
									return actionElementMap;
								}
							}
						}
					}
					return null;
				}

				[IteratorStateMachine(typeof(bStLWNEdlYfhlHfttEnpIxsnAJfT))]
				private IEnumerable<ActionElementMap> LaWOayNBzYPeseUdFMMKbpbNmmhe(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3)
				{
					return new bStLWNEdlYfhlHfttEnpIxsnAJfT(-2)
					{
						gerBYzyMZYaTXhdLDKemFhvJoiMnb = this,
						xocSMZIJqkZXfCpXOJrdFHdoPjkl = P_0,
						xrcRxYJrstdlpVXLNZuXdwyMhybe = P_1,
						JJramCpqTweshXdKVgPslEWgjNTb = P_2,
						XHprJhZPMQCjgaBDAsFnkyqKKwLb = P_3
					};
				}

				private int KuXTxJCOSbPRIcrFIUEsMUHlUaXW(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					if (P_4 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_5)
					{
						P_4.Clear();
					}
					if (P_0 == null)
					{
						return 0;
					}
					Controller controller = P_0.controller;
					if (controller == null)
					{
						return 0;
					}
					FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = sFNpRqSpUDBhuJIUMZgKMkxjutaR.IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controller.type);
					int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
					int num2 = 0;
					for (int i = 0; i < num; i++)
					{
						PQaFgQVynoEJfalLJXDCcVZTEKyx pQaFgQVynoEJfalLJXDCcVZTEKyx = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
						_ = pQaFgQVynoEJfalLJXDCcVZTEKyx.IdaghgVqdKwQFNEtDYEijJdcbVHeA;
						IList<ControllerMap> list = pQaFgQVynoEJfalLJXDCcVZTEKyx.iBWakmwJlExbdlnUxGRNeGbUfhQo;
						int count = list.Count;
						for (int j = 0; j < count; j++)
						{
							ControllerMap controllerMap = list[j];
							if (!P_3 || controllerMap.enabled)
							{
								num2 += controllerMap.GkqChYlZGQOzIisFIMtpFCNiEOLd(P_0, P_1, P_2, P_3, P_4, P_5, out var _);
							}
						}
					}
					return num2;
				}
			}

			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class PollingHelper : CodeHelper
			{
				private sealed class gsQTrRuyrBsDJpkQIfxrhYVYPDYG : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int xzSWAQhWDCkicaGAUvbwfiIYdaTt;

					private ControllerPollingInfo VQfTOJAvLUVUPSqqRewnDJBRfINr;

					private int BsNtfupLLIDCgdjiPthLtdCBPkTlA;

					public PollingHelper YlzmHKcMmQzEZQiVUarVXZMWNTHS;

					private IList<CustomController> eJnCvgXtmxERgEcvaOqAARGNcBGQ;

					private int QBIiKPbPazADilLiyQjBTKTYeWGaA;

					private int tdeQxJuFZVmJCsNhQESPSaRfEOVg;

					private IEnumerator<ControllerPollingInfo> XqxqhJxUZlKiiwgVYvzKQrkkQwlp;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return VQfTOJAvLUVUPSqqRewnDJBRfINr;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return VQfTOJAvLUVUPSqqRewnDJBRfINr;
						}
					}

					[DebuggerHidden]
					public gsQTrRuyrBsDJpkQIfxrhYVYPDYG(int P_0)
					{
						xzSWAQhWDCkicaGAUvbwfiIYdaTt = P_0;
						BsNtfupLLIDCgdjiPthLtdCBPkTlA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = xzSWAQhWDCkicaGAUvbwfiIYdaTt;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								aSTOeNKcbvQGeasehOULvARRdjKZ();
							}
						}
						eJnCvgXtmxERgEcvaOqAARGNcBGQ = null;
						XqxqhJxUZlKiiwgVYvzKQrkkQwlp = null;
						xzSWAQhWDCkicaGAUvbwfiIYdaTt = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = xzSWAQhWDCkicaGAUvbwfiIYdaTt;
							PollingHelper ylzmHKcMmQzEZQiVUarVXZMWNTHS = YlzmHKcMmQzEZQiVUarVXZMWNTHS;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								xzSWAQhWDCkicaGAUvbwfiIYdaTt = -3;
								goto IL_00c5;
							}
							xzSWAQhWDCkicaGAUvbwfiIYdaTt = -1;
							eJnCvgXtmxERgEcvaOqAARGNcBGQ = ylzmHKcMmQzEZQiVUarVXZMWNTHS.iXXnBJLcWnzTqSgqWZdYDvDcOgNG.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.xMPzVHlWLmYQdGOQbmSeMmfOpemj;
							QBIiKPbPazADilLiyQjBTKTYeWGaA = eJnCvgXtmxERgEcvaOqAARGNcBGQ.Count;
							tdeQxJuFZVmJCsNhQESPSaRfEOVg = 0;
							goto IL_00f1;
							IL_00c5:
							if (XqxqhJxUZlKiiwgVYvzKQrkkQwlp.MoveNext())
							{
								ControllerPollingInfo current = XqxqhJxUZlKiiwgVYvzKQrkkQwlp.Current;
								ControllerPollingInfo vQfTOJAvLUVUPSqqRewnDJBRfINr = new ControllerPollingInfo(current);
								vQfTOJAvLUVUPSqqRewnDJBRfINr.playerId = ylzmHKcMmQzEZQiVUarVXZMWNTHS.qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								VQfTOJAvLUVUPSqqRewnDJBRfINr = vQfTOJAvLUVUPSqqRewnDJBRfINr;
								xzSWAQhWDCkicaGAUvbwfiIYdaTt = 1;
								return true;
							}
							aSTOeNKcbvQGeasehOULvARRdjKZ();
							XqxqhJxUZlKiiwgVYvzKQrkkQwlp = null;
							tdeQxJuFZVmJCsNhQESPSaRfEOVg++;
							goto IL_00f1;
							IL_00f1:
							if (tdeQxJuFZVmJCsNhQESPSaRfEOVg < QBIiKPbPazADilLiyQjBTKTYeWGaA)
							{
								XqxqhJxUZlKiiwgVYvzKQrkkQwlp = eJnCvgXtmxERgEcvaOqAARGNcBGQ[tdeQxJuFZVmJCsNhQESPSaRfEOVg].PollForAllAxes().GetEnumerator();
								xzSWAQhWDCkicaGAUvbwfiIYdaTt = -3;
								goto IL_00c5;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void aSTOeNKcbvQGeasehOULvARRdjKZ()
					{
						xzSWAQhWDCkicaGAUvbwfiIYdaTt = -1;
						if (XqxqhJxUZlKiiwgVYvzKQrkkQwlp != null)
						{
							XqxqhJxUZlKiiwgVYvzKQrkkQwlp.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						gsQTrRuyrBsDJpkQIfxrhYVYPDYG gsQTrRuyrBsDJpkQIfxrhYVYPDYG2;
						if (xzSWAQhWDCkicaGAUvbwfiIYdaTt == -2 && BsNtfupLLIDCgdjiPthLtdCBPkTlA == Environment.CurrentManagedThreadId)
						{
							xzSWAQhWDCkicaGAUvbwfiIYdaTt = 0;
							gsQTrRuyrBsDJpkQIfxrhYVYPDYG2 = this;
						}
						else
						{
							gsQTrRuyrBsDJpkQIfxrhYVYPDYG2 = new gsQTrRuyrBsDJpkQIfxrhYVYPDYG(0);
							gsQTrRuyrBsDJpkQIfxrhYVYPDYG2.YlzmHKcMmQzEZQiVUarVXZMWNTHS = YlzmHKcMmQzEZQiVUarVXZMWNTHS;
						}
						return gsQTrRuyrBsDJpkQIfxrhYVYPDYG2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class IAhCIoteMhfrvZvFqjvjkjPXwODb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int yOHjIjTWRZizUuBhesglTFltMZPk;

					private ControllerPollingInfo vDqSblXoRDEUzJGxKfoehohjAPpkA;

					private int fNgLbarclrIPRaLaywrJsUjUFbOVA;

					public PollingHelper OfIVNyRjCxqtUJqeNpwoxEvkipuf;

					private IList<CustomController> yGBgOmSCJgEhPjpUaZVdsKhtNTOyA;

					private int IPijdlgvObgDDqntlgvIOKOSIMXcA;

					private int eldhUFdBHZgCDOtCuYaKfXepUmHbA;

					private IEnumerator<ControllerPollingInfo> VgFMoJJLJIhoVyYsjEKROtGCBfJq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vDqSblXoRDEUzJGxKfoehohjAPpkA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vDqSblXoRDEUzJGxKfoehohjAPpkA;
						}
					}

					[DebuggerHidden]
					public IAhCIoteMhfrvZvFqjvjkjPXwODb(int P_0)
					{
						yOHjIjTWRZizUuBhesglTFltMZPk = P_0;
						fNgLbarclrIPRaLaywrJsUjUFbOVA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = yOHjIjTWRZizUuBhesglTFltMZPk;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								kwAClayGivsrSNYKpklzhNSiGFM();
							}
						}
						yGBgOmSCJgEhPjpUaZVdsKhtNTOyA = null;
						VgFMoJJLJIhoVyYsjEKROtGCBfJq = null;
						yOHjIjTWRZizUuBhesglTFltMZPk = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = yOHjIjTWRZizUuBhesglTFltMZPk;
							PollingHelper ofIVNyRjCxqtUJqeNpwoxEvkipuf = OfIVNyRjCxqtUJqeNpwoxEvkipuf;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								yOHjIjTWRZizUuBhesglTFltMZPk = -3;
								goto IL_00c5;
							}
							yOHjIjTWRZizUuBhesglTFltMZPk = -1;
							yGBgOmSCJgEhPjpUaZVdsKhtNTOyA = ofIVNyRjCxqtUJqeNpwoxEvkipuf.iXXnBJLcWnzTqSgqWZdYDvDcOgNG.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.xMPzVHlWLmYQdGOQbmSeMmfOpemj;
							IPijdlgvObgDDqntlgvIOKOSIMXcA = yGBgOmSCJgEhPjpUaZVdsKhtNTOyA.Count;
							eldhUFdBHZgCDOtCuYaKfXepUmHbA = 0;
							goto IL_00f1;
							IL_00c5:
							if (VgFMoJJLJIhoVyYsjEKROtGCBfJq.MoveNext())
							{
								ControllerPollingInfo current = VgFMoJJLJIhoVyYsjEKROtGCBfJq.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = ofIVNyRjCxqtUJqeNpwoxEvkipuf.qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								vDqSblXoRDEUzJGxKfoehohjAPpkA = controllerPollingInfo;
								yOHjIjTWRZizUuBhesglTFltMZPk = 1;
								return true;
							}
							kwAClayGivsrSNYKpklzhNSiGFM();
							VgFMoJJLJIhoVyYsjEKROtGCBfJq = null;
							eldhUFdBHZgCDOtCuYaKfXepUmHbA++;
							goto IL_00f1;
							IL_00f1:
							if (eldhUFdBHZgCDOtCuYaKfXepUmHbA < IPijdlgvObgDDqntlgvIOKOSIMXcA)
							{
								VgFMoJJLJIhoVyYsjEKROtGCBfJq = yGBgOmSCJgEhPjpUaZVdsKhtNTOyA[eldhUFdBHZgCDOtCuYaKfXepUmHbA].PollForAllButtons().GetEnumerator();
								yOHjIjTWRZizUuBhesglTFltMZPk = -3;
								goto IL_00c5;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void kwAClayGivsrSNYKpklzhNSiGFM()
					{
						yOHjIjTWRZizUuBhesglTFltMZPk = -1;
						if (VgFMoJJLJIhoVyYsjEKROtGCBfJq != null)
						{
							VgFMoJJLJIhoVyYsjEKROtGCBfJq.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						IAhCIoteMhfrvZvFqjvjkjPXwODb ahCIoteMhfrvZvFqjvjkjPXwODb;
						if (yOHjIjTWRZizUuBhesglTFltMZPk == -2 && fNgLbarclrIPRaLaywrJsUjUFbOVA == Environment.CurrentManagedThreadId)
						{
							yOHjIjTWRZizUuBhesglTFltMZPk = 0;
							ahCIoteMhfrvZvFqjvjkjPXwODb = this;
						}
						else
						{
							ahCIoteMhfrvZvFqjvjkjPXwODb = new IAhCIoteMhfrvZvFqjvjkjPXwODb(0);
							ahCIoteMhfrvZvFqjvjkjPXwODb.OfIVNyRjCxqtUJqeNpwoxEvkipuf = OfIVNyRjCxqtUJqeNpwoxEvkipuf;
						}
						return ahCIoteMhfrvZvFqjvjkjPXwODb;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ZhTaSaFOSmfpOYvUWKAJLzVCJEFDA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int SUQcdKpmreApZGHuSNexHJxzdMymA;

					private ControllerPollingInfo HgCqmfdmuNMBrSywCOsZfoWgNPDX;

					private int FjcaPtoVvDyEsUJmiRvjfqHGRzBl;

					public PollingHelper VAVpODMSqkUZNmKcqHeyxEPfFjmr;

					private IList<CustomController> kyozMMakuRKDcCQowwvbvTypmRQW;

					private int GyzNUsyZxqkWaPROZXfrRBVZctgD;

					private int mMPaUdAPlEZFhTFNymNbhuJhsUTZB;

					private IEnumerator<ControllerPollingInfo> TltgwqHSbZvaqDTleDJcckwgInlhb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return HgCqmfdmuNMBrSywCOsZfoWgNPDX;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return HgCqmfdmuNMBrSywCOsZfoWgNPDX;
						}
					}

					[DebuggerHidden]
					public ZhTaSaFOSmfpOYvUWKAJLzVCJEFDA(int P_0)
					{
						SUQcdKpmreApZGHuSNexHJxzdMymA = P_0;
						FjcaPtoVvDyEsUJmiRvjfqHGRzBl = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int sUQcdKpmreApZGHuSNexHJxzdMymA = SUQcdKpmreApZGHuSNexHJxzdMymA;
						if (sUQcdKpmreApZGHuSNexHJxzdMymA == -3 || sUQcdKpmreApZGHuSNexHJxzdMymA == 1)
						{
							try
							{
							}
							finally
							{
								SacEznBsGrIAMLiCazZfTPakZchD();
							}
						}
						kyozMMakuRKDcCQowwvbvTypmRQW = null;
						TltgwqHSbZvaqDTleDJcckwgInlhb = null;
						SUQcdKpmreApZGHuSNexHJxzdMymA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int sUQcdKpmreApZGHuSNexHJxzdMymA = SUQcdKpmreApZGHuSNexHJxzdMymA;
							PollingHelper vAVpODMSqkUZNmKcqHeyxEPfFjmr = VAVpODMSqkUZNmKcqHeyxEPfFjmr;
							if (sUQcdKpmreApZGHuSNexHJxzdMymA != 0)
							{
								if (sUQcdKpmreApZGHuSNexHJxzdMymA != 1)
								{
									return false;
								}
								SUQcdKpmreApZGHuSNexHJxzdMymA = -3;
								goto IL_00c5;
							}
							SUQcdKpmreApZGHuSNexHJxzdMymA = -1;
							kyozMMakuRKDcCQowwvbvTypmRQW = vAVpODMSqkUZNmKcqHeyxEPfFjmr.iXXnBJLcWnzTqSgqWZdYDvDcOgNG.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.xMPzVHlWLmYQdGOQbmSeMmfOpemj;
							GyzNUsyZxqkWaPROZXfrRBVZctgD = kyozMMakuRKDcCQowwvbvTypmRQW.Count;
							mMPaUdAPlEZFhTFNymNbhuJhsUTZB = 0;
							goto IL_00f1;
							IL_00c5:
							if (TltgwqHSbZvaqDTleDJcckwgInlhb.MoveNext())
							{
								ControllerPollingInfo current = TltgwqHSbZvaqDTleDJcckwgInlhb.Current;
								ControllerPollingInfo hgCqmfdmuNMBrSywCOsZfoWgNPDX = new ControllerPollingInfo(current);
								hgCqmfdmuNMBrSywCOsZfoWgNPDX.playerId = vAVpODMSqkUZNmKcqHeyxEPfFjmr.qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								HgCqmfdmuNMBrSywCOsZfoWgNPDX = hgCqmfdmuNMBrSywCOsZfoWgNPDX;
								SUQcdKpmreApZGHuSNexHJxzdMymA = 1;
								return true;
							}
							SacEznBsGrIAMLiCazZfTPakZchD();
							TltgwqHSbZvaqDTleDJcckwgInlhb = null;
							mMPaUdAPlEZFhTFNymNbhuJhsUTZB++;
							goto IL_00f1;
							IL_00f1:
							if (mMPaUdAPlEZFhTFNymNbhuJhsUTZB < GyzNUsyZxqkWaPROZXfrRBVZctgD)
							{
								TltgwqHSbZvaqDTleDJcckwgInlhb = kyozMMakuRKDcCQowwvbvTypmRQW[mMPaUdAPlEZFhTFNymNbhuJhsUTZB].PollForAllButtonsDown().GetEnumerator();
								SUQcdKpmreApZGHuSNexHJxzdMymA = -3;
								goto IL_00c5;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void SacEznBsGrIAMLiCazZfTPakZchD()
					{
						SUQcdKpmreApZGHuSNexHJxzdMymA = -1;
						if (TltgwqHSbZvaqDTleDJcckwgInlhb != null)
						{
							TltgwqHSbZvaqDTleDJcckwgInlhb.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						ZhTaSaFOSmfpOYvUWKAJLzVCJEFDA zhTaSaFOSmfpOYvUWKAJLzVCJEFDA;
						if (SUQcdKpmreApZGHuSNexHJxzdMymA == -2 && FjcaPtoVvDyEsUJmiRvjfqHGRzBl == Environment.CurrentManagedThreadId)
						{
							SUQcdKpmreApZGHuSNexHJxzdMymA = 0;
							zhTaSaFOSmfpOYvUWKAJLzVCJEFDA = this;
						}
						else
						{
							zhTaSaFOSmfpOYvUWKAJLzVCJEFDA = new ZhTaSaFOSmfpOYvUWKAJLzVCJEFDA(0);
							zhTaSaFOSmfpOYvUWKAJLzVCJEFDA.VAVpODMSqkUZNmKcqHeyxEPfFjmr = VAVpODMSqkUZNmKcqHeyxEPfFjmr;
						}
						return zhTaSaFOSmfpOYvUWKAJLzVCJEFDA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class wUdchMECrdNTFuinfWVKOMygtOwn : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int vXOcrFekcsjtWmGukOBrfBvEYwMG;

					private ControllerPollingInfo GDXmuuiNpHzHbMioQpQzAMBxvamE;

					private int ofHAnpVqRmruCbwMBWugAEMPHxOA;

					public PollingHelper IBtuCPHKFizomTrSKWjInLUqfnfl;

					private IList<CustomController> FWrgxLbjeGDMRCGACYQsmXEjKlaGb;

					private int lHEvyBjcgwdhAFVNiuvhCJfnUncM;

					private int kFOvDQofkLVaqLXsMqdvKbVXBoRBA;

					private IEnumerator<ControllerPollingInfo> zcamRrEMFYYFvnilOSJYQJGfjyRc;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return GDXmuuiNpHzHbMioQpQzAMBxvamE;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return GDXmuuiNpHzHbMioQpQzAMBxvamE;
						}
					}

					[DebuggerHidden]
					public wUdchMECrdNTFuinfWVKOMygtOwn(int P_0)
					{
						vXOcrFekcsjtWmGukOBrfBvEYwMG = P_0;
						ofHAnpVqRmruCbwMBWugAEMPHxOA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = vXOcrFekcsjtWmGukOBrfBvEYwMG;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								mcVzuFpnwRQoPDSWMHGpHzWrLECN();
							}
						}
						FWrgxLbjeGDMRCGACYQsmXEjKlaGb = null;
						zcamRrEMFYYFvnilOSJYQJGfjyRc = null;
						vXOcrFekcsjtWmGukOBrfBvEYwMG = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = vXOcrFekcsjtWmGukOBrfBvEYwMG;
							PollingHelper iBtuCPHKFizomTrSKWjInLUqfnfl = IBtuCPHKFizomTrSKWjInLUqfnfl;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								vXOcrFekcsjtWmGukOBrfBvEYwMG = -3;
								goto IL_00c5;
							}
							vXOcrFekcsjtWmGukOBrfBvEYwMG = -1;
							FWrgxLbjeGDMRCGACYQsmXEjKlaGb = iBtuCPHKFizomTrSKWjInLUqfnfl.iXXnBJLcWnzTqSgqWZdYDvDcOgNG.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.xMPzVHlWLmYQdGOQbmSeMmfOpemj;
							lHEvyBjcgwdhAFVNiuvhCJfnUncM = FWrgxLbjeGDMRCGACYQsmXEjKlaGb.Count;
							kFOvDQofkLVaqLXsMqdvKbVXBoRBA = 0;
							goto IL_00f1;
							IL_00c5:
							if (zcamRrEMFYYFvnilOSJYQJGfjyRc.MoveNext())
							{
								ControllerPollingInfo current = zcamRrEMFYYFvnilOSJYQJGfjyRc.Current;
								ControllerPollingInfo gDXmuuiNpHzHbMioQpQzAMBxvamE = new ControllerPollingInfo(current);
								gDXmuuiNpHzHbMioQpQzAMBxvamE.playerId = iBtuCPHKFizomTrSKWjInLUqfnfl.qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								GDXmuuiNpHzHbMioQpQzAMBxvamE = gDXmuuiNpHzHbMioQpQzAMBxvamE;
								vXOcrFekcsjtWmGukOBrfBvEYwMG = 1;
								return true;
							}
							mcVzuFpnwRQoPDSWMHGpHzWrLECN();
							zcamRrEMFYYFvnilOSJYQJGfjyRc = null;
							kFOvDQofkLVaqLXsMqdvKbVXBoRBA++;
							goto IL_00f1;
							IL_00f1:
							if (kFOvDQofkLVaqLXsMqdvKbVXBoRBA < lHEvyBjcgwdhAFVNiuvhCJfnUncM)
							{
								zcamRrEMFYYFvnilOSJYQJGfjyRc = FWrgxLbjeGDMRCGACYQsmXEjKlaGb[kFOvDQofkLVaqLXsMqdvKbVXBoRBA].PollForAllElements().GetEnumerator();
								vXOcrFekcsjtWmGukOBrfBvEYwMG = -3;
								goto IL_00c5;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void mcVzuFpnwRQoPDSWMHGpHzWrLECN()
					{
						vXOcrFekcsjtWmGukOBrfBvEYwMG = -1;
						if (zcamRrEMFYYFvnilOSJYQJGfjyRc != null)
						{
							zcamRrEMFYYFvnilOSJYQJGfjyRc.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						wUdchMECrdNTFuinfWVKOMygtOwn wUdchMECrdNTFuinfWVKOMygtOwn2;
						if (vXOcrFekcsjtWmGukOBrfBvEYwMG == -2 && ofHAnpVqRmruCbwMBWugAEMPHxOA == Environment.CurrentManagedThreadId)
						{
							vXOcrFekcsjtWmGukOBrfBvEYwMG = 0;
							wUdchMECrdNTFuinfWVKOMygtOwn2 = this;
						}
						else
						{
							wUdchMECrdNTFuinfWVKOMygtOwn2 = new wUdchMECrdNTFuinfWVKOMygtOwn(0);
							wUdchMECrdNTFuinfWVKOMygtOwn2.IBtuCPHKFizomTrSKWjInLUqfnfl = IBtuCPHKFizomTrSKWjInLUqfnfl;
						}
						return wUdchMECrdNTFuinfWVKOMygtOwn2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class nSBSJQjECxciuKicnjrsddNskTHbb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int nJEikglAtemRFimTSinXEhzCiJmf;

					private ControllerPollingInfo JuYTbwKyJGqvQjNgWtGaBsORTOQL;

					private int orUsJPTkGNIjYcqblldltbiXEABS;

					public PollingHelper EvKLjpUrpsSDcXhVZblYFaBAhcpp;

					private IList<CustomController> GrbOTQACBTrIuCRaqFPyhWPwtnpw;

					private int gEqixiTknnlJbmUNsoDSZJcUCflM;

					private int LThsEFoYnnTYwHdHnVdwwMCzoypI;

					private IEnumerator<ControllerPollingInfo> qoGgfwxNtCnjvcVglUycJtgwURmg;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return JuYTbwKyJGqvQjNgWtGaBsORTOQL;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return JuYTbwKyJGqvQjNgWtGaBsORTOQL;
						}
					}

					[DebuggerHidden]
					public nSBSJQjECxciuKicnjrsddNskTHbb(int P_0)
					{
						nJEikglAtemRFimTSinXEhzCiJmf = P_0;
						orUsJPTkGNIjYcqblldltbiXEABS = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = nJEikglAtemRFimTSinXEhzCiJmf;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								aITCrSdDxNIyTSvVhFaWddjjMmwUb();
							}
						}
						GrbOTQACBTrIuCRaqFPyhWPwtnpw = null;
						qoGgfwxNtCnjvcVglUycJtgwURmg = null;
						nJEikglAtemRFimTSinXEhzCiJmf = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = nJEikglAtemRFimTSinXEhzCiJmf;
							PollingHelper evKLjpUrpsSDcXhVZblYFaBAhcpp = EvKLjpUrpsSDcXhVZblYFaBAhcpp;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								nJEikglAtemRFimTSinXEhzCiJmf = -3;
								goto IL_00c5;
							}
							nJEikglAtemRFimTSinXEhzCiJmf = -1;
							GrbOTQACBTrIuCRaqFPyhWPwtnpw = evKLjpUrpsSDcXhVZblYFaBAhcpp.iXXnBJLcWnzTqSgqWZdYDvDcOgNG.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.xMPzVHlWLmYQdGOQbmSeMmfOpemj;
							gEqixiTknnlJbmUNsoDSZJcUCflM = GrbOTQACBTrIuCRaqFPyhWPwtnpw.Count;
							LThsEFoYnnTYwHdHnVdwwMCzoypI = 0;
							goto IL_00f1;
							IL_00c5:
							if (qoGgfwxNtCnjvcVglUycJtgwURmg.MoveNext())
							{
								ControllerPollingInfo current = qoGgfwxNtCnjvcVglUycJtgwURmg.Current;
								ControllerPollingInfo juYTbwKyJGqvQjNgWtGaBsORTOQL = new ControllerPollingInfo(current);
								juYTbwKyJGqvQjNgWtGaBsORTOQL.playerId = evKLjpUrpsSDcXhVZblYFaBAhcpp.qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								JuYTbwKyJGqvQjNgWtGaBsORTOQL = juYTbwKyJGqvQjNgWtGaBsORTOQL;
								nJEikglAtemRFimTSinXEhzCiJmf = 1;
								return true;
							}
							aITCrSdDxNIyTSvVhFaWddjjMmwUb();
							qoGgfwxNtCnjvcVglUycJtgwURmg = null;
							LThsEFoYnnTYwHdHnVdwwMCzoypI++;
							goto IL_00f1;
							IL_00f1:
							if (LThsEFoYnnTYwHdHnVdwwMCzoypI < gEqixiTknnlJbmUNsoDSZJcUCflM)
							{
								qoGgfwxNtCnjvcVglUycJtgwURmg = GrbOTQACBTrIuCRaqFPyhWPwtnpw[LThsEFoYnnTYwHdHnVdwwMCzoypI].PollForAllElementsDown().GetEnumerator();
								nJEikglAtemRFimTSinXEhzCiJmf = -3;
								goto IL_00c5;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void aITCrSdDxNIyTSvVhFaWddjjMmwUb()
					{
						nJEikglAtemRFimTSinXEhzCiJmf = -1;
						if (qoGgfwxNtCnjvcVglUycJtgwURmg != null)
						{
							qoGgfwxNtCnjvcVglUycJtgwURmg.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						nSBSJQjECxciuKicnjrsddNskTHbb nSBSJQjECxciuKicnjrsddNskTHbb2;
						if (nJEikglAtemRFimTSinXEhzCiJmf == -2 && orUsJPTkGNIjYcqblldltbiXEABS == Environment.CurrentManagedThreadId)
						{
							nJEikglAtemRFimTSinXEhzCiJmf = 0;
							nSBSJQjECxciuKicnjrsddNskTHbb2 = this;
						}
						else
						{
							nSBSJQjECxciuKicnjrsddNskTHbb2 = new nSBSJQjECxciuKicnjrsddNskTHbb(0);
							nSBSJQjECxciuKicnjrsddNskTHbb2.EvKLjpUrpsSDcXhVZblYFaBAhcpp = EvKLjpUrpsSDcXhVZblYFaBAhcpp;
						}
						return nSBSJQjECxciuKicnjrsddNskTHbb2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class tMhiSRRktkzawMcaJZMcQGMVJTqF : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int fKmnkvehEpecCsHhsgqUkgtYypEHA;

					private ControllerPollingInfo MjyQMDypdYLbgmGkAtgvPzMRpmLM;

					private int UaRUHKOMVjBBELYKQJwFIjfDQsXu;

					public PollingHelper EmtdHAQQfvNDhzQFKLQYHFmnLJD;

					private IList<Joystick> jHKGjnQvmjyWzzERkPSzxeGoRctP;

					private int vcfBNAnfSldDboGdIBONKXfxRHrkA;

					private int QuTfncjjBgOHEcLwngEbFSWnIVTX;

					private IEnumerator<ControllerPollingInfo> turqxtTKJDfDSWQHSGTCNfoigroFA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return MjyQMDypdYLbgmGkAtgvPzMRpmLM;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return MjyQMDypdYLbgmGkAtgvPzMRpmLM;
						}
					}

					[DebuggerHidden]
					public tMhiSRRktkzawMcaJZMcQGMVJTqF(int P_0)
					{
						fKmnkvehEpecCsHhsgqUkgtYypEHA = P_0;
						UaRUHKOMVjBBELYKQJwFIjfDQsXu = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = fKmnkvehEpecCsHhsgqUkgtYypEHA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								qHBPQsZSUbpxzSNOmQucsIOdvkav();
							}
						}
						jHKGjnQvmjyWzzERkPSzxeGoRctP = null;
						turqxtTKJDfDSWQHSGTCNfoigroFA = null;
						fKmnkvehEpecCsHhsgqUkgtYypEHA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = fKmnkvehEpecCsHhsgqUkgtYypEHA;
							PollingHelper emtdHAQQfvNDhzQFKLQYHFmnLJD = EmtdHAQQfvNDhzQFKLQYHFmnLJD;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								fKmnkvehEpecCsHhsgqUkgtYypEHA = -3;
								goto IL_00c5;
							}
							fKmnkvehEpecCsHhsgqUkgtYypEHA = -1;
							jHKGjnQvmjyWzzERkPSzxeGoRctP = emtdHAQQfvNDhzQFKLQYHFmnLJD.iXXnBJLcWnzTqSgqWZdYDvDcOgNG.nrlxRpyPglGccrqNtakOClEIBShgA.xMPzVHlWLmYQdGOQbmSeMmfOpemj;
							vcfBNAnfSldDboGdIBONKXfxRHrkA = jHKGjnQvmjyWzzERkPSzxeGoRctP.Count;
							QuTfncjjBgOHEcLwngEbFSWnIVTX = 0;
							goto IL_00f1;
							IL_00c5:
							if (turqxtTKJDfDSWQHSGTCNfoigroFA.MoveNext())
							{
								ControllerPollingInfo current = turqxtTKJDfDSWQHSGTCNfoigroFA.Current;
								ControllerPollingInfo mjyQMDypdYLbgmGkAtgvPzMRpmLM = new ControllerPollingInfo(current);
								mjyQMDypdYLbgmGkAtgvPzMRpmLM.playerId = emtdHAQQfvNDhzQFKLQYHFmnLJD.qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								MjyQMDypdYLbgmGkAtgvPzMRpmLM = mjyQMDypdYLbgmGkAtgvPzMRpmLM;
								fKmnkvehEpecCsHhsgqUkgtYypEHA = 1;
								return true;
							}
							qHBPQsZSUbpxzSNOmQucsIOdvkav();
							turqxtTKJDfDSWQHSGTCNfoigroFA = null;
							QuTfncjjBgOHEcLwngEbFSWnIVTX++;
							goto IL_00f1;
							IL_00f1:
							if (QuTfncjjBgOHEcLwngEbFSWnIVTX < vcfBNAnfSldDboGdIBONKXfxRHrkA)
							{
								turqxtTKJDfDSWQHSGTCNfoigroFA = jHKGjnQvmjyWzzERkPSzxeGoRctP[QuTfncjjBgOHEcLwngEbFSWnIVTX].PollForAllAxes().GetEnumerator();
								fKmnkvehEpecCsHhsgqUkgtYypEHA = -3;
								goto IL_00c5;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void qHBPQsZSUbpxzSNOmQucsIOdvkav()
					{
						fKmnkvehEpecCsHhsgqUkgtYypEHA = -1;
						if (turqxtTKJDfDSWQHSGTCNfoigroFA != null)
						{
							turqxtTKJDfDSWQHSGTCNfoigroFA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						tMhiSRRktkzawMcaJZMcQGMVJTqF tMhiSRRktkzawMcaJZMcQGMVJTqF2;
						if (fKmnkvehEpecCsHhsgqUkgtYypEHA == -2 && UaRUHKOMVjBBELYKQJwFIjfDQsXu == Environment.CurrentManagedThreadId)
						{
							fKmnkvehEpecCsHhsgqUkgtYypEHA = 0;
							tMhiSRRktkzawMcaJZMcQGMVJTqF2 = this;
						}
						else
						{
							tMhiSRRktkzawMcaJZMcQGMVJTqF2 = new tMhiSRRktkzawMcaJZMcQGMVJTqF(0);
							tMhiSRRktkzawMcaJZMcQGMVJTqF2.EmtdHAQQfvNDhzQFKLQYHFmnLJD = EmtdHAQQfvNDhzQFKLQYHFmnLJD;
						}
						return tMhiSRRktkzawMcaJZMcQGMVJTqF2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class PSDrqzrTmHBpIGSUNbmAMNzKKzRC : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int XcPWCfSZENlDLwSpTWUdKTIWLuNV;

					private ControllerPollingInfo AhSmRmWXenmdkyBQsBTjREhPyauI;

					private int BpbstMmfXIAPpjetEJUDSuWZhRSWA;

					public PollingHelper obCzFRwEXiEehabnEjIZrUFgengQA;

					private IList<Joystick> qBBhSfpRTWKkDDyGywJtsaYGzMQn;

					private int DjBpxgngBKcxwJfEdMwnXFKajoYw;

					private int RwWiOPskukusDqUjPJthklBQHCzi;

					private IEnumerator<ControllerPollingInfo> JTSGfgUNKXDQFqNUsJjUexYQoyyG;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return AhSmRmWXenmdkyBQsBTjREhPyauI;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return AhSmRmWXenmdkyBQsBTjREhPyauI;
						}
					}

					[DebuggerHidden]
					public PSDrqzrTmHBpIGSUNbmAMNzKKzRC(int P_0)
					{
						XcPWCfSZENlDLwSpTWUdKTIWLuNV = P_0;
						BpbstMmfXIAPpjetEJUDSuWZhRSWA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int xcPWCfSZENlDLwSpTWUdKTIWLuNV = XcPWCfSZENlDLwSpTWUdKTIWLuNV;
						if (xcPWCfSZENlDLwSpTWUdKTIWLuNV == -3 || xcPWCfSZENlDLwSpTWUdKTIWLuNV == 1)
						{
							try
							{
							}
							finally
							{
								kHnHSUfFUffagjEUWmJMZpAKTjZj();
							}
						}
						qBBhSfpRTWKkDDyGywJtsaYGzMQn = null;
						JTSGfgUNKXDQFqNUsJjUexYQoyyG = null;
						XcPWCfSZENlDLwSpTWUdKTIWLuNV = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int xcPWCfSZENlDLwSpTWUdKTIWLuNV = XcPWCfSZENlDLwSpTWUdKTIWLuNV;
							PollingHelper pollingHelper = obCzFRwEXiEehabnEjIZrUFgengQA;
							if (xcPWCfSZENlDLwSpTWUdKTIWLuNV != 0)
							{
								if (xcPWCfSZENlDLwSpTWUdKTIWLuNV != 1)
								{
									return false;
								}
								XcPWCfSZENlDLwSpTWUdKTIWLuNV = -3;
								goto IL_00c5;
							}
							XcPWCfSZENlDLwSpTWUdKTIWLuNV = -1;
							qBBhSfpRTWKkDDyGywJtsaYGzMQn = pollingHelper.iXXnBJLcWnzTqSgqWZdYDvDcOgNG.nrlxRpyPglGccrqNtakOClEIBShgA.xMPzVHlWLmYQdGOQbmSeMmfOpemj;
							DjBpxgngBKcxwJfEdMwnXFKajoYw = qBBhSfpRTWKkDDyGywJtsaYGzMQn.Count;
							RwWiOPskukusDqUjPJthklBQHCzi = 0;
							goto IL_00f1;
							IL_00c5:
							if (JTSGfgUNKXDQFqNUsJjUexYQoyyG.MoveNext())
							{
								ControllerPollingInfo current = JTSGfgUNKXDQFqNUsJjUexYQoyyG.Current;
								ControllerPollingInfo ahSmRmWXenmdkyBQsBTjREhPyauI = new ControllerPollingInfo(current);
								ahSmRmWXenmdkyBQsBTjREhPyauI.playerId = pollingHelper.qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								AhSmRmWXenmdkyBQsBTjREhPyauI = ahSmRmWXenmdkyBQsBTjREhPyauI;
								XcPWCfSZENlDLwSpTWUdKTIWLuNV = 1;
								return true;
							}
							kHnHSUfFUffagjEUWmJMZpAKTjZj();
							JTSGfgUNKXDQFqNUsJjUexYQoyyG = null;
							RwWiOPskukusDqUjPJthklBQHCzi++;
							goto IL_00f1;
							IL_00f1:
							if (RwWiOPskukusDqUjPJthklBQHCzi < DjBpxgngBKcxwJfEdMwnXFKajoYw)
							{
								JTSGfgUNKXDQFqNUsJjUexYQoyyG = qBBhSfpRTWKkDDyGywJtsaYGzMQn[RwWiOPskukusDqUjPJthklBQHCzi].PollForAllButtons().GetEnumerator();
								XcPWCfSZENlDLwSpTWUdKTIWLuNV = -3;
								goto IL_00c5;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void kHnHSUfFUffagjEUWmJMZpAKTjZj()
					{
						XcPWCfSZENlDLwSpTWUdKTIWLuNV = -1;
						if (JTSGfgUNKXDQFqNUsJjUexYQoyyG != null)
						{
							JTSGfgUNKXDQFqNUsJjUexYQoyyG.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						PSDrqzrTmHBpIGSUNbmAMNzKKzRC pSDrqzrTmHBpIGSUNbmAMNzKKzRC;
						if (XcPWCfSZENlDLwSpTWUdKTIWLuNV == -2 && BpbstMmfXIAPpjetEJUDSuWZhRSWA == Environment.CurrentManagedThreadId)
						{
							XcPWCfSZENlDLwSpTWUdKTIWLuNV = 0;
							pSDrqzrTmHBpIGSUNbmAMNzKKzRC = this;
						}
						else
						{
							pSDrqzrTmHBpIGSUNbmAMNzKKzRC = new PSDrqzrTmHBpIGSUNbmAMNzKKzRC(0);
							pSDrqzrTmHBpIGSUNbmAMNzKKzRC.obCzFRwEXiEehabnEjIZrUFgengQA = obCzFRwEXiEehabnEjIZrUFgengQA;
						}
						return pSDrqzrTmHBpIGSUNbmAMNzKKzRC;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class cNZpxtcBQfHjDuBqubvaKdgqDOAc : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int EgqdXovwYAPVbBvlNqGKjYTLvooc;

					private ControllerPollingInfo rnBaFKyNgHcikbXGBJQABOHhgSdPA;

					private int gxeIdTtfujGMcELZPhnsILEBIvxib;

					public PollingHelper aVERlctIVPaHMdktbjaldkeEiFrP;

					private IList<Joystick> MxcRBfTuLqgrHQijfPRKNboDnIZf;

					private int JLOOAPpoIRTVRDDYpLUZgvowLKlK;

					private int agckqIAbTtniSVMdefhWOmqJdgReA;

					private IEnumerator<ControllerPollingInfo> ZGjRNLMbtoQLhaLVMfnjBnwkvFNA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return rnBaFKyNgHcikbXGBJQABOHhgSdPA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return rnBaFKyNgHcikbXGBJQABOHhgSdPA;
						}
					}

					[DebuggerHidden]
					public cNZpxtcBQfHjDuBqubvaKdgqDOAc(int P_0)
					{
						EgqdXovwYAPVbBvlNqGKjYTLvooc = P_0;
						gxeIdTtfujGMcELZPhnsILEBIvxib = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int egqdXovwYAPVbBvlNqGKjYTLvooc = EgqdXovwYAPVbBvlNqGKjYTLvooc;
						if (egqdXovwYAPVbBvlNqGKjYTLvooc == -3 || egqdXovwYAPVbBvlNqGKjYTLvooc == 1)
						{
							try
							{
							}
							finally
							{
								CBhobJlnEvSDdcNfGusVNOMouJVF();
							}
						}
						MxcRBfTuLqgrHQijfPRKNboDnIZf = null;
						ZGjRNLMbtoQLhaLVMfnjBnwkvFNA = null;
						EgqdXovwYAPVbBvlNqGKjYTLvooc = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int egqdXovwYAPVbBvlNqGKjYTLvooc = EgqdXovwYAPVbBvlNqGKjYTLvooc;
							PollingHelper pollingHelper = aVERlctIVPaHMdktbjaldkeEiFrP;
							if (egqdXovwYAPVbBvlNqGKjYTLvooc != 0)
							{
								if (egqdXovwYAPVbBvlNqGKjYTLvooc != 1)
								{
									return false;
								}
								EgqdXovwYAPVbBvlNqGKjYTLvooc = -3;
								goto IL_00c5;
							}
							EgqdXovwYAPVbBvlNqGKjYTLvooc = -1;
							MxcRBfTuLqgrHQijfPRKNboDnIZf = pollingHelper.iXXnBJLcWnzTqSgqWZdYDvDcOgNG.nrlxRpyPglGccrqNtakOClEIBShgA.xMPzVHlWLmYQdGOQbmSeMmfOpemj;
							JLOOAPpoIRTVRDDYpLUZgvowLKlK = MxcRBfTuLqgrHQijfPRKNboDnIZf.Count;
							agckqIAbTtniSVMdefhWOmqJdgReA = 0;
							goto IL_00f1;
							IL_00c5:
							if (ZGjRNLMbtoQLhaLVMfnjBnwkvFNA.MoveNext())
							{
								ControllerPollingInfo current = ZGjRNLMbtoQLhaLVMfnjBnwkvFNA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								rnBaFKyNgHcikbXGBJQABOHhgSdPA = controllerPollingInfo;
								EgqdXovwYAPVbBvlNqGKjYTLvooc = 1;
								return true;
							}
							CBhobJlnEvSDdcNfGusVNOMouJVF();
							ZGjRNLMbtoQLhaLVMfnjBnwkvFNA = null;
							agckqIAbTtniSVMdefhWOmqJdgReA++;
							goto IL_00f1;
							IL_00f1:
							if (agckqIAbTtniSVMdefhWOmqJdgReA < JLOOAPpoIRTVRDDYpLUZgvowLKlK)
							{
								ZGjRNLMbtoQLhaLVMfnjBnwkvFNA = MxcRBfTuLqgrHQijfPRKNboDnIZf[agckqIAbTtniSVMdefhWOmqJdgReA].PollForAllButtonsDown().GetEnumerator();
								EgqdXovwYAPVbBvlNqGKjYTLvooc = -3;
								goto IL_00c5;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void CBhobJlnEvSDdcNfGusVNOMouJVF()
					{
						EgqdXovwYAPVbBvlNqGKjYTLvooc = -1;
						if (ZGjRNLMbtoQLhaLVMfnjBnwkvFNA != null)
						{
							ZGjRNLMbtoQLhaLVMfnjBnwkvFNA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						cNZpxtcBQfHjDuBqubvaKdgqDOAc cNZpxtcBQfHjDuBqubvaKdgqDOAc2;
						if (EgqdXovwYAPVbBvlNqGKjYTLvooc == -2 && gxeIdTtfujGMcELZPhnsILEBIvxib == Environment.CurrentManagedThreadId)
						{
							EgqdXovwYAPVbBvlNqGKjYTLvooc = 0;
							cNZpxtcBQfHjDuBqubvaKdgqDOAc2 = this;
						}
						else
						{
							cNZpxtcBQfHjDuBqubvaKdgqDOAc2 = new cNZpxtcBQfHjDuBqubvaKdgqDOAc(0);
							cNZpxtcBQfHjDuBqubvaKdgqDOAc2.aVERlctIVPaHMdktbjaldkeEiFrP = aVERlctIVPaHMdktbjaldkeEiFrP;
						}
						return cNZpxtcBQfHjDuBqubvaKdgqDOAc2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class EIMgBzHEbXypbpBWMzPnwfXJSQfTA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int XTsbRDAFUzpKoHXRhvAkiusKiCzSA;

					private ControllerPollingInfo OXbKeXfEiJWCwohHaPCFIczLQuoS;

					private int RmgaWwIkKUtKLKmjLChTJuPgVlgA;

					public PollingHelper SXyfvjAtWiWJAbqeqTCKJxTTKvDV;

					private IList<Joystick> PZOWjcAJuYSkcUahzCOFjhCIoghI;

					private int zkPzOTDqwfgDNpzmwxtIugJBEUIQ;

					private int mtmuOqtRotrVySKPRGkaXaVcvxLq;

					private IEnumerator<ControllerPollingInfo> usoQtJkrcVVRTDDtnmGxFonXEDNw;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return OXbKeXfEiJWCwohHaPCFIczLQuoS;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return OXbKeXfEiJWCwohHaPCFIczLQuoS;
						}
					}

					[DebuggerHidden]
					public EIMgBzHEbXypbpBWMzPnwfXJSQfTA(int P_0)
					{
						XTsbRDAFUzpKoHXRhvAkiusKiCzSA = P_0;
						RmgaWwIkKUtKLKmjLChTJuPgVlgA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int xTsbRDAFUzpKoHXRhvAkiusKiCzSA = XTsbRDAFUzpKoHXRhvAkiusKiCzSA;
						if (xTsbRDAFUzpKoHXRhvAkiusKiCzSA == -3 || xTsbRDAFUzpKoHXRhvAkiusKiCzSA == 1)
						{
							try
							{
							}
							finally
							{
								ZRYvdOXpSsOgtGeXPaBZiZUUnOEBA();
							}
						}
						PZOWjcAJuYSkcUahzCOFjhCIoghI = null;
						usoQtJkrcVVRTDDtnmGxFonXEDNw = null;
						XTsbRDAFUzpKoHXRhvAkiusKiCzSA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int xTsbRDAFUzpKoHXRhvAkiusKiCzSA = XTsbRDAFUzpKoHXRhvAkiusKiCzSA;
							PollingHelper sXyfvjAtWiWJAbqeqTCKJxTTKvDV = SXyfvjAtWiWJAbqeqTCKJxTTKvDV;
							if (xTsbRDAFUzpKoHXRhvAkiusKiCzSA != 0)
							{
								if (xTsbRDAFUzpKoHXRhvAkiusKiCzSA != 1)
								{
									return false;
								}
								XTsbRDAFUzpKoHXRhvAkiusKiCzSA = -3;
								goto IL_00c5;
							}
							XTsbRDAFUzpKoHXRhvAkiusKiCzSA = -1;
							PZOWjcAJuYSkcUahzCOFjhCIoghI = sXyfvjAtWiWJAbqeqTCKJxTTKvDV.iXXnBJLcWnzTqSgqWZdYDvDcOgNG.nrlxRpyPglGccrqNtakOClEIBShgA.xMPzVHlWLmYQdGOQbmSeMmfOpemj;
							zkPzOTDqwfgDNpzmwxtIugJBEUIQ = PZOWjcAJuYSkcUahzCOFjhCIoghI.Count;
							mtmuOqtRotrVySKPRGkaXaVcvxLq = 0;
							goto IL_00f1;
							IL_00c5:
							if (usoQtJkrcVVRTDDtnmGxFonXEDNw.MoveNext())
							{
								ControllerPollingInfo current = usoQtJkrcVVRTDDtnmGxFonXEDNw.Current;
								ControllerPollingInfo oXbKeXfEiJWCwohHaPCFIczLQuoS = new ControllerPollingInfo(current);
								oXbKeXfEiJWCwohHaPCFIczLQuoS.playerId = sXyfvjAtWiWJAbqeqTCKJxTTKvDV.qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								OXbKeXfEiJWCwohHaPCFIczLQuoS = oXbKeXfEiJWCwohHaPCFIczLQuoS;
								XTsbRDAFUzpKoHXRhvAkiusKiCzSA = 1;
								return true;
							}
							ZRYvdOXpSsOgtGeXPaBZiZUUnOEBA();
							usoQtJkrcVVRTDDtnmGxFonXEDNw = null;
							mtmuOqtRotrVySKPRGkaXaVcvxLq++;
							goto IL_00f1;
							IL_00f1:
							if (mtmuOqtRotrVySKPRGkaXaVcvxLq < zkPzOTDqwfgDNpzmwxtIugJBEUIQ)
							{
								usoQtJkrcVVRTDDtnmGxFonXEDNw = PZOWjcAJuYSkcUahzCOFjhCIoghI[mtmuOqtRotrVySKPRGkaXaVcvxLq].PollForAllElements().GetEnumerator();
								XTsbRDAFUzpKoHXRhvAkiusKiCzSA = -3;
								goto IL_00c5;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void ZRYvdOXpSsOgtGeXPaBZiZUUnOEBA()
					{
						XTsbRDAFUzpKoHXRhvAkiusKiCzSA = -1;
						if (usoQtJkrcVVRTDDtnmGxFonXEDNw != null)
						{
							usoQtJkrcVVRTDDtnmGxFonXEDNw.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						EIMgBzHEbXypbpBWMzPnwfXJSQfTA eIMgBzHEbXypbpBWMzPnwfXJSQfTA;
						if (XTsbRDAFUzpKoHXRhvAkiusKiCzSA == -2 && RmgaWwIkKUtKLKmjLChTJuPgVlgA == Environment.CurrentManagedThreadId)
						{
							XTsbRDAFUzpKoHXRhvAkiusKiCzSA = 0;
							eIMgBzHEbXypbpBWMzPnwfXJSQfTA = this;
						}
						else
						{
							eIMgBzHEbXypbpBWMzPnwfXJSQfTA = new EIMgBzHEbXypbpBWMzPnwfXJSQfTA(0);
							eIMgBzHEbXypbpBWMzPnwfXJSQfTA.SXyfvjAtWiWJAbqeqTCKJxTTKvDV = SXyfvjAtWiWJAbqeqTCKJxTTKvDV;
						}
						return eIMgBzHEbXypbpBWMzPnwfXJSQfTA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class mlyVCVZSSkQygyzJrlPwjkOihudF : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int xnarvyJqcRAuZCSUzokipvmjQgDf;

					private ControllerPollingInfo VdTOqtIUuXjjCeoOvdMojjUVDtDd;

					private int CmHvLMQJzEhfPnOoZrKNvVxDjLxT;

					public PollingHelper gmYSTIThFvsrENtjkDLBvOIyvaSQ;

					private IList<Joystick> cbBWemyNlUFNFuEcibWYHqDvcRjlA;

					private int PzYArQzAgRjlJLWGtiHcVpBJSIFw;

					private int CHjJOengOpshByQynSsnkaEJVGpC;

					private IEnumerator<ControllerPollingInfo> tvUiQDQpfUAvdbVfACSpxLIsZGGMA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return VdTOqtIUuXjjCeoOvdMojjUVDtDd;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return VdTOqtIUuXjjCeoOvdMojjUVDtDd;
						}
					}

					[DebuggerHidden]
					public mlyVCVZSSkQygyzJrlPwjkOihudF(int P_0)
					{
						xnarvyJqcRAuZCSUzokipvmjQgDf = P_0;
						CmHvLMQJzEhfPnOoZrKNvVxDjLxT = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = xnarvyJqcRAuZCSUzokipvmjQgDf;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								tYhlulLlqwbDShmPdSEAbdWhtgcUA();
							}
						}
						cbBWemyNlUFNFuEcibWYHqDvcRjlA = null;
						tvUiQDQpfUAvdbVfACSpxLIsZGGMA = null;
						xnarvyJqcRAuZCSUzokipvmjQgDf = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = xnarvyJqcRAuZCSUzokipvmjQgDf;
							PollingHelper pollingHelper = gmYSTIThFvsrENtjkDLBvOIyvaSQ;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								xnarvyJqcRAuZCSUzokipvmjQgDf = -3;
								goto IL_00c5;
							}
							xnarvyJqcRAuZCSUzokipvmjQgDf = -1;
							cbBWemyNlUFNFuEcibWYHqDvcRjlA = pollingHelper.iXXnBJLcWnzTqSgqWZdYDvDcOgNG.nrlxRpyPglGccrqNtakOClEIBShgA.xMPzVHlWLmYQdGOQbmSeMmfOpemj;
							PzYArQzAgRjlJLWGtiHcVpBJSIFw = cbBWemyNlUFNFuEcibWYHqDvcRjlA.Count;
							CHjJOengOpshByQynSsnkaEJVGpC = 0;
							goto IL_00f1;
							IL_00c5:
							if (tvUiQDQpfUAvdbVfACSpxLIsZGGMA.MoveNext())
							{
								ControllerPollingInfo current = tvUiQDQpfUAvdbVfACSpxLIsZGGMA.Current;
								ControllerPollingInfo vdTOqtIUuXjjCeoOvdMojjUVDtDd = new ControllerPollingInfo(current);
								vdTOqtIUuXjjCeoOvdMojjUVDtDd.playerId = pollingHelper.qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								VdTOqtIUuXjjCeoOvdMojjUVDtDd = vdTOqtIUuXjjCeoOvdMojjUVDtDd;
								xnarvyJqcRAuZCSUzokipvmjQgDf = 1;
								return true;
							}
							tYhlulLlqwbDShmPdSEAbdWhtgcUA();
							tvUiQDQpfUAvdbVfACSpxLIsZGGMA = null;
							CHjJOengOpshByQynSsnkaEJVGpC++;
							goto IL_00f1;
							IL_00f1:
							if (CHjJOengOpshByQynSsnkaEJVGpC < PzYArQzAgRjlJLWGtiHcVpBJSIFw)
							{
								tvUiQDQpfUAvdbVfACSpxLIsZGGMA = cbBWemyNlUFNFuEcibWYHqDvcRjlA[CHjJOengOpshByQynSsnkaEJVGpC].PollForAllElementsDown().GetEnumerator();
								xnarvyJqcRAuZCSUzokipvmjQgDf = -3;
								goto IL_00c5;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void tYhlulLlqwbDShmPdSEAbdWhtgcUA()
					{
						xnarvyJqcRAuZCSUzokipvmjQgDf = -1;
						if (tvUiQDQpfUAvdbVfACSpxLIsZGGMA != null)
						{
							tvUiQDQpfUAvdbVfACSpxLIsZGGMA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						mlyVCVZSSkQygyzJrlPwjkOihudF mlyVCVZSSkQygyzJrlPwjkOihudF2;
						if (xnarvyJqcRAuZCSUzokipvmjQgDf == -2 && CmHvLMQJzEhfPnOoZrKNvVxDjLxT == Environment.CurrentManagedThreadId)
						{
							xnarvyJqcRAuZCSUzokipvmjQgDf = 0;
							mlyVCVZSSkQygyzJrlPwjkOihudF2 = this;
						}
						else
						{
							mlyVCVZSSkQygyzJrlPwjkOihudF2 = new mlyVCVZSSkQygyzJrlPwjkOihudF(0);
							mlyVCVZSSkQygyzJrlPwjkOihudF2.gmYSTIThFvsrENtjkDLBvOIyvaSQ = gmYSTIThFvsrENtjkDLBvOIyvaSQ;
						}
						return mlyVCVZSSkQygyzJrlPwjkOihudF2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class VnumVuHcpGTTJNcSVVtJiozSBpHB : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int jTnOkqmExVAJSNQEfrMOoUQIHnbG;

					private ControllerPollingInfo YhnoeSefXtRAiKSyTxfhtgnXhPOT;

					private int CrSADjTZHsdxphNvwTGogkaGHYrE;

					private int nlFjNGchjKCuZSXmaCkNANPOxGQH;

					public int rMzJmLBnDycikRTkzfzYWqbrjqky;

					public PollingHelper tjFYArJKNWblyacfnbELsqeqhIdq;

					private IEnumerator<ControllerPollingInfo> ZhRYQIYjljCVbiccZDbyxuRPzCZM;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return YhnoeSefXtRAiKSyTxfhtgnXhPOT;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return YhnoeSefXtRAiKSyTxfhtgnXhPOT;
						}
					}

					[DebuggerHidden]
					public VnumVuHcpGTTJNcSVVtJiozSBpHB(int P_0)
					{
						jTnOkqmExVAJSNQEfrMOoUQIHnbG = P_0;
						CrSADjTZHsdxphNvwTGogkaGHYrE = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = jTnOkqmExVAJSNQEfrMOoUQIHnbG;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								jtzKLOejAEwalitjxIEFtfCObcCM();
							}
						}
						ZhRYQIYjljCVbiccZDbyxuRPzCZM = null;
						jTnOkqmExVAJSNQEfrMOoUQIHnbG = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = jTnOkqmExVAJSNQEfrMOoUQIHnbG;
							PollingHelper pollingHelper = tjFYArJKNWblyacfnbELsqeqhIdq;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								jTnOkqmExVAJSNQEfrMOoUQIHnbG = -1;
								if (nlFjNGchjKCuZSXmaCkNANPOxGQH < 0)
								{
									return false;
								}
								CustomController customController = pollingHelper.iXXnBJLcWnzTqSgqWZdYDvDcOgNG.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.QPbwEzurbQskXsrZQCvuwTpGtHyA(nlFjNGchjKCuZSXmaCkNANPOxGQH);
								if (customController == null)
								{
									return false;
								}
								ZhRYQIYjljCVbiccZDbyxuRPzCZM = customController.PollForAllAxes().GetEnumerator();
								jTnOkqmExVAJSNQEfrMOoUQIHnbG = -3;
								break;
							}
							case 1:
								jTnOkqmExVAJSNQEfrMOoUQIHnbG = -3;
								break;
							}
							if (ZhRYQIYjljCVbiccZDbyxuRPzCZM.MoveNext())
							{
								ControllerPollingInfo current = ZhRYQIYjljCVbiccZDbyxuRPzCZM.Current;
								ControllerPollingInfo yhnoeSefXtRAiKSyTxfhtgnXhPOT = new ControllerPollingInfo(current);
								yhnoeSefXtRAiKSyTxfhtgnXhPOT.playerId = pollingHelper.qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								YhnoeSefXtRAiKSyTxfhtgnXhPOT = yhnoeSefXtRAiKSyTxfhtgnXhPOT;
								jTnOkqmExVAJSNQEfrMOoUQIHnbG = 1;
								return true;
							}
							jtzKLOejAEwalitjxIEFtfCObcCM();
							ZhRYQIYjljCVbiccZDbyxuRPzCZM = null;
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void jtzKLOejAEwalitjxIEFtfCObcCM()
					{
						jTnOkqmExVAJSNQEfrMOoUQIHnbG = -1;
						if (ZhRYQIYjljCVbiccZDbyxuRPzCZM != null)
						{
							ZhRYQIYjljCVbiccZDbyxuRPzCZM.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						VnumVuHcpGTTJNcSVVtJiozSBpHB vnumVuHcpGTTJNcSVVtJiozSBpHB;
						if (jTnOkqmExVAJSNQEfrMOoUQIHnbG == -2 && CrSADjTZHsdxphNvwTGogkaGHYrE == Environment.CurrentManagedThreadId)
						{
							jTnOkqmExVAJSNQEfrMOoUQIHnbG = 0;
							vnumVuHcpGTTJNcSVVtJiozSBpHB = this;
						}
						else
						{
							vnumVuHcpGTTJNcSVVtJiozSBpHB = new VnumVuHcpGTTJNcSVVtJiozSBpHB(0);
							vnumVuHcpGTTJNcSVVtJiozSBpHB.tjFYArJKNWblyacfnbELsqeqhIdq = tjFYArJKNWblyacfnbELsqeqhIdq;
						}
						vnumVuHcpGTTJNcSVVtJiozSBpHB.nlFjNGchjKCuZSXmaCkNANPOxGQH = rMzJmLBnDycikRTkzfzYWqbrjqky;
						return vnumVuHcpGTTJNcSVVtJiozSBpHB;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class jueKXEWszdIzhVFugoSAYyNJgVzK : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int bnoMaDauEKlMyigFWcBvSdGctiXF;

					private ControllerPollingInfo AOUxbhPQfqCAXEvACfcUKmHZttfx;

					private int mAZEZHLhOUDeKJjZBZkTalBsxgaIA;

					private int BYoHViYDGRWGQuqQIbIaFOJdtBleA;

					public int FbJgFpiNwnNAKdhkxOWqvtUssiwdA;

					public PollingHelper LNIrdeDGTseajGhxBQhvTzWaLaMKA;

					private IEnumerator<ControllerPollingInfo> TJiMeUEXrKGNiNQnKbWJILyBVvBI;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return AOUxbhPQfqCAXEvACfcUKmHZttfx;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return AOUxbhPQfqCAXEvACfcUKmHZttfx;
						}
					}

					[DebuggerHidden]
					public jueKXEWszdIzhVFugoSAYyNJgVzK(int P_0)
					{
						bnoMaDauEKlMyigFWcBvSdGctiXF = P_0;
						mAZEZHLhOUDeKJjZBZkTalBsxgaIA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = bnoMaDauEKlMyigFWcBvSdGctiXF;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								aQVBsnVQSqcFKhwhgIEjTYpKZCYX();
							}
						}
						TJiMeUEXrKGNiNQnKbWJILyBVvBI = null;
						bnoMaDauEKlMyigFWcBvSdGctiXF = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = bnoMaDauEKlMyigFWcBvSdGctiXF;
							PollingHelper lNIrdeDGTseajGhxBQhvTzWaLaMKA = LNIrdeDGTseajGhxBQhvTzWaLaMKA;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								bnoMaDauEKlMyigFWcBvSdGctiXF = -1;
								if (BYoHViYDGRWGQuqQIbIaFOJdtBleA < 0)
								{
									return false;
								}
								CustomController customController = lNIrdeDGTseajGhxBQhvTzWaLaMKA.iXXnBJLcWnzTqSgqWZdYDvDcOgNG.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.QPbwEzurbQskXsrZQCvuwTpGtHyA(BYoHViYDGRWGQuqQIbIaFOJdtBleA);
								if (customController == null)
								{
									return false;
								}
								TJiMeUEXrKGNiNQnKbWJILyBVvBI = customController.PollForAllButtons().GetEnumerator();
								bnoMaDauEKlMyigFWcBvSdGctiXF = -3;
								break;
							}
							case 1:
								bnoMaDauEKlMyigFWcBvSdGctiXF = -3;
								break;
							}
							if (TJiMeUEXrKGNiNQnKbWJILyBVvBI.MoveNext())
							{
								ControllerPollingInfo current = TJiMeUEXrKGNiNQnKbWJILyBVvBI.Current;
								ControllerPollingInfo aOUxbhPQfqCAXEvACfcUKmHZttfx = new ControllerPollingInfo(current);
								aOUxbhPQfqCAXEvACfcUKmHZttfx.playerId = lNIrdeDGTseajGhxBQhvTzWaLaMKA.qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								AOUxbhPQfqCAXEvACfcUKmHZttfx = aOUxbhPQfqCAXEvACfcUKmHZttfx;
								bnoMaDauEKlMyigFWcBvSdGctiXF = 1;
								return true;
							}
							aQVBsnVQSqcFKhwhgIEjTYpKZCYX();
							TJiMeUEXrKGNiNQnKbWJILyBVvBI = null;
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void aQVBsnVQSqcFKhwhgIEjTYpKZCYX()
					{
						bnoMaDauEKlMyigFWcBvSdGctiXF = -1;
						if (TJiMeUEXrKGNiNQnKbWJILyBVvBI != null)
						{
							TJiMeUEXrKGNiNQnKbWJILyBVvBI.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						jueKXEWszdIzhVFugoSAYyNJgVzK jueKXEWszdIzhVFugoSAYyNJgVzK2;
						if (bnoMaDauEKlMyigFWcBvSdGctiXF == -2 && mAZEZHLhOUDeKJjZBZkTalBsxgaIA == Environment.CurrentManagedThreadId)
						{
							bnoMaDauEKlMyigFWcBvSdGctiXF = 0;
							jueKXEWszdIzhVFugoSAYyNJgVzK2 = this;
						}
						else
						{
							jueKXEWszdIzhVFugoSAYyNJgVzK2 = new jueKXEWszdIzhVFugoSAYyNJgVzK(0);
							jueKXEWszdIzhVFugoSAYyNJgVzK2.LNIrdeDGTseajGhxBQhvTzWaLaMKA = LNIrdeDGTseajGhxBQhvTzWaLaMKA;
						}
						jueKXEWszdIzhVFugoSAYyNJgVzK2.BYoHViYDGRWGQuqQIbIaFOJdtBleA = FbJgFpiNwnNAKdhkxOWqvtUssiwdA;
						return jueKXEWszdIzhVFugoSAYyNJgVzK2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class KjDnkepfksqcrlNKVmWwKnLELKte : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int ihRuQAlrWozmQlqCYlEXvDTMiOeO;

					private ControllerPollingInfo wcbJvQCVsBHtJZLjEWkYbvFlYYmgA;

					private int EfOnkCFuGKBSctZqFPmfyCpicovb;

					private int ZGTytfxHDatsRJBaRXwxpdPBWNgX;

					public int WPmdmjXWZPnQTLgInBlJfqNSGlgNA;

					public PollingHelper YsrBDiBxnvjJILkTRmovmFwblojWA;

					private IEnumerator<ControllerPollingInfo> xEPiPAKAPuZJUCPCIknkEPcUMmnaA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return wcbJvQCVsBHtJZLjEWkYbvFlYYmgA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return wcbJvQCVsBHtJZLjEWkYbvFlYYmgA;
						}
					}

					[DebuggerHidden]
					public KjDnkepfksqcrlNKVmWwKnLELKte(int P_0)
					{
						ihRuQAlrWozmQlqCYlEXvDTMiOeO = P_0;
						EfOnkCFuGKBSctZqFPmfyCpicovb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = ihRuQAlrWozmQlqCYlEXvDTMiOeO;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								ZEtaFJSQYaVPCLfvMouTNsUabjSh();
							}
						}
						xEPiPAKAPuZJUCPCIknkEPcUMmnaA = null;
						ihRuQAlrWozmQlqCYlEXvDTMiOeO = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = ihRuQAlrWozmQlqCYlEXvDTMiOeO;
							PollingHelper ysrBDiBxnvjJILkTRmovmFwblojWA = YsrBDiBxnvjJILkTRmovmFwblojWA;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								ihRuQAlrWozmQlqCYlEXvDTMiOeO = -1;
								if (ZGTytfxHDatsRJBaRXwxpdPBWNgX < 0)
								{
									return false;
								}
								CustomController customController = ysrBDiBxnvjJILkTRmovmFwblojWA.iXXnBJLcWnzTqSgqWZdYDvDcOgNG.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.QPbwEzurbQskXsrZQCvuwTpGtHyA(ZGTytfxHDatsRJBaRXwxpdPBWNgX);
								if (customController == null)
								{
									return false;
								}
								xEPiPAKAPuZJUCPCIknkEPcUMmnaA = customController.PollForAllButtonsDown().GetEnumerator();
								ihRuQAlrWozmQlqCYlEXvDTMiOeO = -3;
								break;
							}
							case 1:
								ihRuQAlrWozmQlqCYlEXvDTMiOeO = -3;
								break;
							}
							if (xEPiPAKAPuZJUCPCIknkEPcUMmnaA.MoveNext())
							{
								ControllerPollingInfo current = xEPiPAKAPuZJUCPCIknkEPcUMmnaA.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = ysrBDiBxnvjJILkTRmovmFwblojWA.qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								wcbJvQCVsBHtJZLjEWkYbvFlYYmgA = controllerPollingInfo;
								ihRuQAlrWozmQlqCYlEXvDTMiOeO = 1;
								return true;
							}
							ZEtaFJSQYaVPCLfvMouTNsUabjSh();
							xEPiPAKAPuZJUCPCIknkEPcUMmnaA = null;
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void ZEtaFJSQYaVPCLfvMouTNsUabjSh()
					{
						ihRuQAlrWozmQlqCYlEXvDTMiOeO = -1;
						if (xEPiPAKAPuZJUCPCIknkEPcUMmnaA != null)
						{
							xEPiPAKAPuZJUCPCIknkEPcUMmnaA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						KjDnkepfksqcrlNKVmWwKnLELKte kjDnkepfksqcrlNKVmWwKnLELKte;
						if (ihRuQAlrWozmQlqCYlEXvDTMiOeO == -2 && EfOnkCFuGKBSctZqFPmfyCpicovb == Environment.CurrentManagedThreadId)
						{
							ihRuQAlrWozmQlqCYlEXvDTMiOeO = 0;
							kjDnkepfksqcrlNKVmWwKnLELKte = this;
						}
						else
						{
							kjDnkepfksqcrlNKVmWwKnLELKte = new KjDnkepfksqcrlNKVmWwKnLELKte(0);
							kjDnkepfksqcrlNKVmWwKnLELKte.YsrBDiBxnvjJILkTRmovmFwblojWA = YsrBDiBxnvjJILkTRmovmFwblojWA;
						}
						kjDnkepfksqcrlNKVmWwKnLELKte.ZGTytfxHDatsRJBaRXwxpdPBWNgX = WPmdmjXWZPnQTLgInBlJfqNSGlgNA;
						return kjDnkepfksqcrlNKVmWwKnLELKte;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class AtSlOLJnyIgkoldwbqlqnfAHUlDV : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int pCWhrACQTtsWkPHXSiOVUCvSBiXdA;

					private ControllerPollingInfo TXfjzCUyeZInFcoeZidaKmJcmHwGb;

					private int xtNZSMnWMzhRbOvabeToFlFcVPNF;

					private int ccHwGDqqnGUEvvPHLzAblLdpQqCb;

					public int cwjgAEEGCsTHPsSAXMacUEZZgQCVA;

					public PollingHelper SPwsnYMtFoSzPsMJGfgviTIIMzok;

					private IEnumerator<ControllerPollingInfo> dWNCXpAGuYknEOBJLdeVmbommDSC;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return TXfjzCUyeZInFcoeZidaKmJcmHwGb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return TXfjzCUyeZInFcoeZidaKmJcmHwGb;
						}
					}

					[DebuggerHidden]
					public AtSlOLJnyIgkoldwbqlqnfAHUlDV(int P_0)
					{
						pCWhrACQTtsWkPHXSiOVUCvSBiXdA = P_0;
						xtNZSMnWMzhRbOvabeToFlFcVPNF = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = pCWhrACQTtsWkPHXSiOVUCvSBiXdA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								iFRdqgBAeHytiExxYdAqdxpchQWl();
							}
						}
						dWNCXpAGuYknEOBJLdeVmbommDSC = null;
						pCWhrACQTtsWkPHXSiOVUCvSBiXdA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = pCWhrACQTtsWkPHXSiOVUCvSBiXdA;
							PollingHelper sPwsnYMtFoSzPsMJGfgviTIIMzok = SPwsnYMtFoSzPsMJGfgviTIIMzok;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								pCWhrACQTtsWkPHXSiOVUCvSBiXdA = -1;
								if (ccHwGDqqnGUEvvPHLzAblLdpQqCb < 0)
								{
									return false;
								}
								CustomController customController = sPwsnYMtFoSzPsMJGfgviTIIMzok.iXXnBJLcWnzTqSgqWZdYDvDcOgNG.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.QPbwEzurbQskXsrZQCvuwTpGtHyA(ccHwGDqqnGUEvvPHLzAblLdpQqCb);
								if (customController == null)
								{
									return false;
								}
								dWNCXpAGuYknEOBJLdeVmbommDSC = customController.PollForAllElements().GetEnumerator();
								pCWhrACQTtsWkPHXSiOVUCvSBiXdA = -3;
								break;
							}
							case 1:
								pCWhrACQTtsWkPHXSiOVUCvSBiXdA = -3;
								break;
							}
							if (dWNCXpAGuYknEOBJLdeVmbommDSC.MoveNext())
							{
								ControllerPollingInfo current = dWNCXpAGuYknEOBJLdeVmbommDSC.Current;
								ControllerPollingInfo tXfjzCUyeZInFcoeZidaKmJcmHwGb = new ControllerPollingInfo(current);
								tXfjzCUyeZInFcoeZidaKmJcmHwGb.playerId = sPwsnYMtFoSzPsMJGfgviTIIMzok.qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								TXfjzCUyeZInFcoeZidaKmJcmHwGb = tXfjzCUyeZInFcoeZidaKmJcmHwGb;
								pCWhrACQTtsWkPHXSiOVUCvSBiXdA = 1;
								return true;
							}
							iFRdqgBAeHytiExxYdAqdxpchQWl();
							dWNCXpAGuYknEOBJLdeVmbommDSC = null;
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void iFRdqgBAeHytiExxYdAqdxpchQWl()
					{
						pCWhrACQTtsWkPHXSiOVUCvSBiXdA = -1;
						if (dWNCXpAGuYknEOBJLdeVmbommDSC != null)
						{
							dWNCXpAGuYknEOBJLdeVmbommDSC.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						AtSlOLJnyIgkoldwbqlqnfAHUlDV atSlOLJnyIgkoldwbqlqnfAHUlDV;
						if (pCWhrACQTtsWkPHXSiOVUCvSBiXdA == -2 && xtNZSMnWMzhRbOvabeToFlFcVPNF == Environment.CurrentManagedThreadId)
						{
							pCWhrACQTtsWkPHXSiOVUCvSBiXdA = 0;
							atSlOLJnyIgkoldwbqlqnfAHUlDV = this;
						}
						else
						{
							atSlOLJnyIgkoldwbqlqnfAHUlDV = new AtSlOLJnyIgkoldwbqlqnfAHUlDV(0);
							atSlOLJnyIgkoldwbqlqnfAHUlDV.SPwsnYMtFoSzPsMJGfgviTIIMzok = SPwsnYMtFoSzPsMJGfgviTIIMzok;
						}
						atSlOLJnyIgkoldwbqlqnfAHUlDV.ccHwGDqqnGUEvvPHLzAblLdpQqCb = cwjgAEEGCsTHPsSAXMacUEZZgQCVA;
						return atSlOLJnyIgkoldwbqlqnfAHUlDV;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class VXDQhJjWGnWjWwcYHJUHHHROemgm : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int JcwudjdMimbGvDGhMVRVnrgXSdZd;

					private ControllerPollingInfo yLrfeQyjjysnirordmEVfsYLrbnu;

					private int eeSBduJSHbajoqDgOPnWkiwmyWyL;

					private int tdCJLpwxPsTuRlIjHCHHehJTLStAA;

					public int LCNPFFkWGhChYOchJKSCDYQvOJBr;

					public PollingHelper OIodSbtDnKayvitzeULvVfacKVPab;

					private IEnumerator<ControllerPollingInfo> iWQFwlNokPReVuqMpTysXoYjapbP;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return yLrfeQyjjysnirordmEVfsYLrbnu;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return yLrfeQyjjysnirordmEVfsYLrbnu;
						}
					}

					[DebuggerHidden]
					public VXDQhJjWGnWjWwcYHJUHHHROemgm(int P_0)
					{
						JcwudjdMimbGvDGhMVRVnrgXSdZd = P_0;
						eeSBduJSHbajoqDgOPnWkiwmyWyL = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int jcwudjdMimbGvDGhMVRVnrgXSdZd = JcwudjdMimbGvDGhMVRVnrgXSdZd;
						if (jcwudjdMimbGvDGhMVRVnrgXSdZd == -3 || jcwudjdMimbGvDGhMVRVnrgXSdZd == 1)
						{
							try
							{
							}
							finally
							{
								AtgqikfZuONfldKDftatBszGEqLC();
							}
						}
						iWQFwlNokPReVuqMpTysXoYjapbP = null;
						JcwudjdMimbGvDGhMVRVnrgXSdZd = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int jcwudjdMimbGvDGhMVRVnrgXSdZd = JcwudjdMimbGvDGhMVRVnrgXSdZd;
							PollingHelper oIodSbtDnKayvitzeULvVfacKVPab = OIodSbtDnKayvitzeULvVfacKVPab;
							switch (jcwudjdMimbGvDGhMVRVnrgXSdZd)
							{
							default:
								return false;
							case 0:
							{
								JcwudjdMimbGvDGhMVRVnrgXSdZd = -1;
								if (tdCJLpwxPsTuRlIjHCHHehJTLStAA < 0)
								{
									return false;
								}
								CustomController customController = oIodSbtDnKayvitzeULvVfacKVPab.iXXnBJLcWnzTqSgqWZdYDvDcOgNG.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.QPbwEzurbQskXsrZQCvuwTpGtHyA(tdCJLpwxPsTuRlIjHCHHehJTLStAA);
								if (customController == null)
								{
									return false;
								}
								iWQFwlNokPReVuqMpTysXoYjapbP = customController.PollForAllElementsDown().GetEnumerator();
								JcwudjdMimbGvDGhMVRVnrgXSdZd = -3;
								break;
							}
							case 1:
								JcwudjdMimbGvDGhMVRVnrgXSdZd = -3;
								break;
							}
							if (iWQFwlNokPReVuqMpTysXoYjapbP.MoveNext())
							{
								ControllerPollingInfo current = iWQFwlNokPReVuqMpTysXoYjapbP.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = oIodSbtDnKayvitzeULvVfacKVPab.qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								yLrfeQyjjysnirordmEVfsYLrbnu = controllerPollingInfo;
								JcwudjdMimbGvDGhMVRVnrgXSdZd = 1;
								return true;
							}
							AtgqikfZuONfldKDftatBszGEqLC();
							iWQFwlNokPReVuqMpTysXoYjapbP = null;
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void AtgqikfZuONfldKDftatBszGEqLC()
					{
						JcwudjdMimbGvDGhMVRVnrgXSdZd = -1;
						if (iWQFwlNokPReVuqMpTysXoYjapbP != null)
						{
							iWQFwlNokPReVuqMpTysXoYjapbP.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						VXDQhJjWGnWjWwcYHJUHHHROemgm vXDQhJjWGnWjWwcYHJUHHHROemgm;
						if (JcwudjdMimbGvDGhMVRVnrgXSdZd == -2 && eeSBduJSHbajoqDgOPnWkiwmyWyL == Environment.CurrentManagedThreadId)
						{
							JcwudjdMimbGvDGhMVRVnrgXSdZd = 0;
							vXDQhJjWGnWjWwcYHJUHHHROemgm = this;
						}
						else
						{
							vXDQhJjWGnWjWwcYHJUHHHROemgm = new VXDQhJjWGnWjWwcYHJUHHHROemgm(0);
							vXDQhJjWGnWjWwcYHJUHHHROemgm.OIodSbtDnKayvitzeULvVfacKVPab = OIodSbtDnKayvitzeULvVfacKVPab;
						}
						vXDQhJjWGnWjWwcYHJUHHHROemgm.tdCJLpwxPsTuRlIjHCHHehJTLStAA = LCNPFFkWGhChYOchJKSCDYQvOJBr;
						return vXDQhJjWGnWjWwcYHJUHHHROemgm;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ndyMNJSZizkRQAlDKhJcnvzRXBzB : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int ndYXozfFNzQJnFOWmcqIxRecahoDA;

					private ControllerPollingInfo tpDNTgDbFkFayHrzlajnnLrUKVwZA;

					private int iBhhUOXpQiuCeFgHJfAXDGgTFSIyA;

					private int KixgSrcrZQJjNRkpythvZDbYlbGg;

					public int DbEoGpuflIhVBWtPcVUHaPWwzaEe;

					public PollingHelper GErlHAUGOsKZgfVCQECGFmUZOfwd;

					private IEnumerator<ControllerPollingInfo> wPaOgNzHHdgpaAZXGlIkWAkCZINI;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return tpDNTgDbFkFayHrzlajnnLrUKVwZA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return tpDNTgDbFkFayHrzlajnnLrUKVwZA;
						}
					}

					[DebuggerHidden]
					public ndyMNJSZizkRQAlDKhJcnvzRXBzB(int P_0)
					{
						ndYXozfFNzQJnFOWmcqIxRecahoDA = P_0;
						iBhhUOXpQiuCeFgHJfAXDGgTFSIyA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = ndYXozfFNzQJnFOWmcqIxRecahoDA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								HEWbLWXEIpiBgMNnlbsIyNXgnsCr();
							}
						}
						wPaOgNzHHdgpaAZXGlIkWAkCZINI = null;
						ndYXozfFNzQJnFOWmcqIxRecahoDA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = ndYXozfFNzQJnFOWmcqIxRecahoDA;
							PollingHelper gErlHAUGOsKZgfVCQECGFmUZOfwd = GErlHAUGOsKZgfVCQECGFmUZOfwd;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								ndYXozfFNzQJnFOWmcqIxRecahoDA = -1;
								if (KixgSrcrZQJjNRkpythvZDbYlbGg < 0)
								{
									return false;
								}
								Joystick joystick = gErlHAUGOsKZgfVCQECGFmUZOfwd.iXXnBJLcWnzTqSgqWZdYDvDcOgNG.nrlxRpyPglGccrqNtakOClEIBShgA.QPbwEzurbQskXsrZQCvuwTpGtHyA(KixgSrcrZQJjNRkpythvZDbYlbGg);
								if (joystick == null)
								{
									return false;
								}
								wPaOgNzHHdgpaAZXGlIkWAkCZINI = joystick.PollForAllAxes().GetEnumerator();
								ndYXozfFNzQJnFOWmcqIxRecahoDA = -3;
								break;
							}
							case 1:
								ndYXozfFNzQJnFOWmcqIxRecahoDA = -3;
								break;
							}
							if (wPaOgNzHHdgpaAZXGlIkWAkCZINI.MoveNext())
							{
								ControllerPollingInfo current = wPaOgNzHHdgpaAZXGlIkWAkCZINI.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = gErlHAUGOsKZgfVCQECGFmUZOfwd.qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								tpDNTgDbFkFayHrzlajnnLrUKVwZA = controllerPollingInfo;
								ndYXozfFNzQJnFOWmcqIxRecahoDA = 1;
								return true;
							}
							HEWbLWXEIpiBgMNnlbsIyNXgnsCr();
							wPaOgNzHHdgpaAZXGlIkWAkCZINI = null;
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void HEWbLWXEIpiBgMNnlbsIyNXgnsCr()
					{
						ndYXozfFNzQJnFOWmcqIxRecahoDA = -1;
						if (wPaOgNzHHdgpaAZXGlIkWAkCZINI != null)
						{
							wPaOgNzHHdgpaAZXGlIkWAkCZINI.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						ndyMNJSZizkRQAlDKhJcnvzRXBzB ndyMNJSZizkRQAlDKhJcnvzRXBzB2;
						if (ndYXozfFNzQJnFOWmcqIxRecahoDA == -2 && iBhhUOXpQiuCeFgHJfAXDGgTFSIyA == Environment.CurrentManagedThreadId)
						{
							ndYXozfFNzQJnFOWmcqIxRecahoDA = 0;
							ndyMNJSZizkRQAlDKhJcnvzRXBzB2 = this;
						}
						else
						{
							ndyMNJSZizkRQAlDKhJcnvzRXBzB2 = new ndyMNJSZizkRQAlDKhJcnvzRXBzB(0);
							ndyMNJSZizkRQAlDKhJcnvzRXBzB2.GErlHAUGOsKZgfVCQECGFmUZOfwd = GErlHAUGOsKZgfVCQECGFmUZOfwd;
						}
						ndyMNJSZizkRQAlDKhJcnvzRXBzB2.KixgSrcrZQJjNRkpythvZDbYlbGg = DbEoGpuflIhVBWtPcVUHaPWwzaEe;
						return ndyMNJSZizkRQAlDKhJcnvzRXBzB2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class idiHURGaMwcjWbVIiZIXdOgoKRKBc : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int lLbkiABUuASLHmfsDAykIjRFmzWC;

					private ControllerPollingInfo oRjlDWdTYjLJjFYyyAhqrcOgPeEr;

					private int ygEIAdDjOSfstrUeaEkjUlsGgxVN;

					private int BtseKtJOhPHTTNylLHifJppZQaQw;

					public int BviZDnWnTCaOiCiMeGfkIXaeNVJw;

					public PollingHelper juWxJcSjtCyOmKbflEhTKUCtgine;

					private IEnumerator<ControllerPollingInfo> knjJKYPCJWwmxcdyJulgYMOUaVKD;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return oRjlDWdTYjLJjFYyyAhqrcOgPeEr;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return oRjlDWdTYjLJjFYyyAhqrcOgPeEr;
						}
					}

					[DebuggerHidden]
					public idiHURGaMwcjWbVIiZIXdOgoKRKBc(int P_0)
					{
						lLbkiABUuASLHmfsDAykIjRFmzWC = P_0;
						ygEIAdDjOSfstrUeaEkjUlsGgxVN = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = lLbkiABUuASLHmfsDAykIjRFmzWC;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								sOyRqVQiISmlHMiRXFtqNSkvpHej();
							}
						}
						knjJKYPCJWwmxcdyJulgYMOUaVKD = null;
						lLbkiABUuASLHmfsDAykIjRFmzWC = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = lLbkiABUuASLHmfsDAykIjRFmzWC;
							PollingHelper pollingHelper = juWxJcSjtCyOmKbflEhTKUCtgine;
							switch (num)
							{
							default:
								return false;
							case 0:
							{
								lLbkiABUuASLHmfsDAykIjRFmzWC = -1;
								if (BtseKtJOhPHTTNylLHifJppZQaQw < 0)
								{
									return false;
								}
								Joystick joystick = pollingHelper.iXXnBJLcWnzTqSgqWZdYDvDcOgNG.nrlxRpyPglGccrqNtakOClEIBShgA.QPbwEzurbQskXsrZQCvuwTpGtHyA(BtseKtJOhPHTTNylLHifJppZQaQw);
								if (joystick == null)
								{
									return false;
								}
								knjJKYPCJWwmxcdyJulgYMOUaVKD = joystick.PollForAllButtons().GetEnumerator();
								lLbkiABUuASLHmfsDAykIjRFmzWC = -3;
								break;
							}
							case 1:
								lLbkiABUuASLHmfsDAykIjRFmzWC = -3;
								break;
							}
							if (knjJKYPCJWwmxcdyJulgYMOUaVKD.MoveNext())
							{
								ControllerPollingInfo current = knjJKYPCJWwmxcdyJulgYMOUaVKD.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								oRjlDWdTYjLJjFYyyAhqrcOgPeEr = controllerPollingInfo;
								lLbkiABUuASLHmfsDAykIjRFmzWC = 1;
								return true;
							}
							sOyRqVQiISmlHMiRXFtqNSkvpHej();
							knjJKYPCJWwmxcdyJulgYMOUaVKD = null;
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void sOyRqVQiISmlHMiRXFtqNSkvpHej()
					{
						lLbkiABUuASLHmfsDAykIjRFmzWC = -1;
						if (knjJKYPCJWwmxcdyJulgYMOUaVKD != null)
						{
							knjJKYPCJWwmxcdyJulgYMOUaVKD.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						idiHURGaMwcjWbVIiZIXdOgoKRKBc idiHURGaMwcjWbVIiZIXdOgoKRKBc2;
						if (lLbkiABUuASLHmfsDAykIjRFmzWC == -2 && ygEIAdDjOSfstrUeaEkjUlsGgxVN == Environment.CurrentManagedThreadId)
						{
							lLbkiABUuASLHmfsDAykIjRFmzWC = 0;
							idiHURGaMwcjWbVIiZIXdOgoKRKBc2 = this;
						}
						else
						{
							idiHURGaMwcjWbVIiZIXdOgoKRKBc2 = new idiHURGaMwcjWbVIiZIXdOgoKRKBc(0);
							idiHURGaMwcjWbVIiZIXdOgoKRKBc2.juWxJcSjtCyOmKbflEhTKUCtgine = juWxJcSjtCyOmKbflEhTKUCtgine;
						}
						idiHURGaMwcjWbVIiZIXdOgoKRKBc2.BtseKtJOhPHTTNylLHifJppZQaQw = BviZDnWnTCaOiCiMeGfkIXaeNVJw;
						return idiHURGaMwcjWbVIiZIXdOgoKRKBc2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class DAlFVMUWRyaDFmUgBakhwbrzpDVi : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int IwFbKOlbkLCeUDomKIwGBtLUBnzHA;

					private ControllerPollingInfo ecfHiOjTgugbtdqakEjGBoXazXBfE;

					private int TfIWopZmuBjXVHmcScYogMMjHGrx;

					private int DEPUkmmJwgIEhLNBrKeNIRsIUctn;

					public int pNYvOUpGOaDoAoRBXquYcprAzNNF;

					public PollingHelper bIzTMarsDGAgsjsPIfzXSvptLrbDA;

					private IEnumerator<ControllerPollingInfo> xQQMJOTuHHqQXGhlftMhGfWcoGEt;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ecfHiOjTgugbtdqakEjGBoXazXBfE;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ecfHiOjTgugbtdqakEjGBoXazXBfE;
						}
					}

					[DebuggerHidden]
					public DAlFVMUWRyaDFmUgBakhwbrzpDVi(int P_0)
					{
						IwFbKOlbkLCeUDomKIwGBtLUBnzHA = P_0;
						TfIWopZmuBjXVHmcScYogMMjHGrx = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int iwFbKOlbkLCeUDomKIwGBtLUBnzHA = IwFbKOlbkLCeUDomKIwGBtLUBnzHA;
						if (iwFbKOlbkLCeUDomKIwGBtLUBnzHA == -3 || iwFbKOlbkLCeUDomKIwGBtLUBnzHA == 1)
						{
							try
							{
							}
							finally
							{
								mDDYqanrhyrIQBDnOGuyVsfbFCNJA();
							}
						}
						xQQMJOTuHHqQXGhlftMhGfWcoGEt = null;
						IwFbKOlbkLCeUDomKIwGBtLUBnzHA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int iwFbKOlbkLCeUDomKIwGBtLUBnzHA = IwFbKOlbkLCeUDomKIwGBtLUBnzHA;
							PollingHelper pollingHelper = bIzTMarsDGAgsjsPIfzXSvptLrbDA;
							switch (iwFbKOlbkLCeUDomKIwGBtLUBnzHA)
							{
							default:
								return false;
							case 0:
							{
								IwFbKOlbkLCeUDomKIwGBtLUBnzHA = -1;
								if (DEPUkmmJwgIEhLNBrKeNIRsIUctn < 0)
								{
									return false;
								}
								Joystick joystick = pollingHelper.iXXnBJLcWnzTqSgqWZdYDvDcOgNG.nrlxRpyPglGccrqNtakOClEIBShgA.QPbwEzurbQskXsrZQCvuwTpGtHyA(DEPUkmmJwgIEhLNBrKeNIRsIUctn);
								if (joystick == null)
								{
									return false;
								}
								xQQMJOTuHHqQXGhlftMhGfWcoGEt = joystick.PollForAllButtonsDown().GetEnumerator();
								IwFbKOlbkLCeUDomKIwGBtLUBnzHA = -3;
								break;
							}
							case 1:
								IwFbKOlbkLCeUDomKIwGBtLUBnzHA = -3;
								break;
							}
							if (xQQMJOTuHHqQXGhlftMhGfWcoGEt.MoveNext())
							{
								ControllerPollingInfo current = xQQMJOTuHHqQXGhlftMhGfWcoGEt.Current;
								ControllerPollingInfo controllerPollingInfo = new ControllerPollingInfo(current);
								controllerPollingInfo.playerId = pollingHelper.qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								ecfHiOjTgugbtdqakEjGBoXazXBfE = controllerPollingInfo;
								IwFbKOlbkLCeUDomKIwGBtLUBnzHA = 1;
								return true;
							}
							mDDYqanrhyrIQBDnOGuyVsfbFCNJA();
							xQQMJOTuHHqQXGhlftMhGfWcoGEt = null;
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void mDDYqanrhyrIQBDnOGuyVsfbFCNJA()
					{
						IwFbKOlbkLCeUDomKIwGBtLUBnzHA = -1;
						if (xQQMJOTuHHqQXGhlftMhGfWcoGEt != null)
						{
							xQQMJOTuHHqQXGhlftMhGfWcoGEt.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						DAlFVMUWRyaDFmUgBakhwbrzpDVi dAlFVMUWRyaDFmUgBakhwbrzpDVi;
						if (IwFbKOlbkLCeUDomKIwGBtLUBnzHA == -2 && TfIWopZmuBjXVHmcScYogMMjHGrx == Environment.CurrentManagedThreadId)
						{
							IwFbKOlbkLCeUDomKIwGBtLUBnzHA = 0;
							dAlFVMUWRyaDFmUgBakhwbrzpDVi = this;
						}
						else
						{
							dAlFVMUWRyaDFmUgBakhwbrzpDVi = new DAlFVMUWRyaDFmUgBakhwbrzpDVi(0);
							dAlFVMUWRyaDFmUgBakhwbrzpDVi.bIzTMarsDGAgsjsPIfzXSvptLrbDA = bIzTMarsDGAgsjsPIfzXSvptLrbDA;
						}
						dAlFVMUWRyaDFmUgBakhwbrzpDVi.DEPUkmmJwgIEhLNBrKeNIRsIUctn = pNYvOUpGOaDoAoRBXquYcprAzNNF;
						return dAlFVMUWRyaDFmUgBakhwbrzpDVi;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class znSKDeHQqCAfNFJMFLducHwcOSmnb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int UijmgwdHYwfxhDoqqNAyWOATwOLAA;

					private ControllerPollingInfo ERZmMtgsyoFcOMTfzpWbRCkhCQtU;

					private int gBzcDkADqlYEmltAvXSeUOgTDyrNA;

					private int zMTamxlWDoNYYBrLeCeioRauHTi;

					public int rLIempboENpeJHEUpGXAXgnDNvqo;

					public PollingHelper MErTOuXGzeOoxNolbnPmiyRKTeAo;

					private IEnumerator<ControllerPollingInfo> MBDJNRRRCgsZEwIYcJDGccwgqfXW;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ERZmMtgsyoFcOMTfzpWbRCkhCQtU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ERZmMtgsyoFcOMTfzpWbRCkhCQtU;
						}
					}

					[DebuggerHidden]
					public znSKDeHQqCAfNFJMFLducHwcOSmnb(int P_0)
					{
						UijmgwdHYwfxhDoqqNAyWOATwOLAA = P_0;
						gBzcDkADqlYEmltAvXSeUOgTDyrNA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int uijmgwdHYwfxhDoqqNAyWOATwOLAA = UijmgwdHYwfxhDoqqNAyWOATwOLAA;
						if (uijmgwdHYwfxhDoqqNAyWOATwOLAA == -3 || uijmgwdHYwfxhDoqqNAyWOATwOLAA == 1)
						{
							try
							{
							}
							finally
							{
								BSyFAuOVKEUOSqdXJFFvobrxAjSgA();
							}
						}
						MBDJNRRRCgsZEwIYcJDGccwgqfXW = null;
						UijmgwdHYwfxhDoqqNAyWOATwOLAA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int uijmgwdHYwfxhDoqqNAyWOATwOLAA = UijmgwdHYwfxhDoqqNAyWOATwOLAA;
							PollingHelper mErTOuXGzeOoxNolbnPmiyRKTeAo = MErTOuXGzeOoxNolbnPmiyRKTeAo;
							switch (uijmgwdHYwfxhDoqqNAyWOATwOLAA)
							{
							default:
								return false;
							case 0:
							{
								UijmgwdHYwfxhDoqqNAyWOATwOLAA = -1;
								if (zMTamxlWDoNYYBrLeCeioRauHTi < 0)
								{
									return false;
								}
								Joystick joystick = mErTOuXGzeOoxNolbnPmiyRKTeAo.iXXnBJLcWnzTqSgqWZdYDvDcOgNG.nrlxRpyPglGccrqNtakOClEIBShgA.QPbwEzurbQskXsrZQCvuwTpGtHyA(zMTamxlWDoNYYBrLeCeioRauHTi);
								if (joystick == null)
								{
									return false;
								}
								MBDJNRRRCgsZEwIYcJDGccwgqfXW = joystick.PollForAllElements().GetEnumerator();
								UijmgwdHYwfxhDoqqNAyWOATwOLAA = -3;
								break;
							}
							case 1:
								UijmgwdHYwfxhDoqqNAyWOATwOLAA = -3;
								break;
							}
							if (MBDJNRRRCgsZEwIYcJDGccwgqfXW.MoveNext())
							{
								ControllerPollingInfo current = MBDJNRRRCgsZEwIYcJDGccwgqfXW.Current;
								ControllerPollingInfo eRZmMtgsyoFcOMTfzpWbRCkhCQtU = new ControllerPollingInfo(current);
								eRZmMtgsyoFcOMTfzpWbRCkhCQtU.playerId = mErTOuXGzeOoxNolbnPmiyRKTeAo.qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								ERZmMtgsyoFcOMTfzpWbRCkhCQtU = eRZmMtgsyoFcOMTfzpWbRCkhCQtU;
								UijmgwdHYwfxhDoqqNAyWOATwOLAA = 1;
								return true;
							}
							BSyFAuOVKEUOSqdXJFFvobrxAjSgA();
							MBDJNRRRCgsZEwIYcJDGccwgqfXW = null;
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void BSyFAuOVKEUOSqdXJFFvobrxAjSgA()
					{
						UijmgwdHYwfxhDoqqNAyWOATwOLAA = -1;
						if (MBDJNRRRCgsZEwIYcJDGccwgqfXW != null)
						{
							MBDJNRRRCgsZEwIYcJDGccwgqfXW.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						znSKDeHQqCAfNFJMFLducHwcOSmnb znSKDeHQqCAfNFJMFLducHwcOSmnb2;
						if (UijmgwdHYwfxhDoqqNAyWOATwOLAA == -2 && gBzcDkADqlYEmltAvXSeUOgTDyrNA == Environment.CurrentManagedThreadId)
						{
							UijmgwdHYwfxhDoqqNAyWOATwOLAA = 0;
							znSKDeHQqCAfNFJMFLducHwcOSmnb2 = this;
						}
						else
						{
							znSKDeHQqCAfNFJMFLducHwcOSmnb2 = new znSKDeHQqCAfNFJMFLducHwcOSmnb(0);
							znSKDeHQqCAfNFJMFLducHwcOSmnb2.MErTOuXGzeOoxNolbnPmiyRKTeAo = MErTOuXGzeOoxNolbnPmiyRKTeAo;
						}
						znSKDeHQqCAfNFJMFLducHwcOSmnb2.zMTamxlWDoNYYBrLeCeioRauHTi = rLIempboENpeJHEUpGXAXgnDNvqo;
						return znSKDeHQqCAfNFJMFLducHwcOSmnb2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class alCHUjaFkCiTOKTwLWgwgzHTCHGQ : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int RixxlsvDpuqUsNAPjGvfVkMxInho;

					private ControllerPollingInfo TnItkGuawckltSBJFASKMGLtMBUO;

					private int HsoKyJVsHTiVPlqGGIJiXbMziogc;

					private int PpRmtrgbyRhinDxZLIGpsCZrAQlP;

					public int EPGgAHkaMtEvfIwluqrLvBRuJVBO;

					public PollingHelper uCuKeaJHafIiaVHqZBSCaHrTkNDy;

					private IEnumerator<ControllerPollingInfo> RGtJnpBeuCJzEmWIIuWGBCudwgho;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return TnItkGuawckltSBJFASKMGLtMBUO;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return TnItkGuawckltSBJFASKMGLtMBUO;
						}
					}

					[DebuggerHidden]
					public alCHUjaFkCiTOKTwLWgwgzHTCHGQ(int P_0)
					{
						RixxlsvDpuqUsNAPjGvfVkMxInho = P_0;
						HsoKyJVsHTiVPlqGGIJiXbMziogc = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int rixxlsvDpuqUsNAPjGvfVkMxInho = RixxlsvDpuqUsNAPjGvfVkMxInho;
						if (rixxlsvDpuqUsNAPjGvfVkMxInho == -3 || rixxlsvDpuqUsNAPjGvfVkMxInho == 1)
						{
							try
							{
							}
							finally
							{
								aVnigOjqtkEcPRckLzLuTqddDIzcA();
							}
						}
						RGtJnpBeuCJzEmWIIuWGBCudwgho = null;
						RixxlsvDpuqUsNAPjGvfVkMxInho = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int rixxlsvDpuqUsNAPjGvfVkMxInho = RixxlsvDpuqUsNAPjGvfVkMxInho;
							PollingHelper pollingHelper = uCuKeaJHafIiaVHqZBSCaHrTkNDy;
							switch (rixxlsvDpuqUsNAPjGvfVkMxInho)
							{
							default:
								return false;
							case 0:
							{
								RixxlsvDpuqUsNAPjGvfVkMxInho = -1;
								if (PpRmtrgbyRhinDxZLIGpsCZrAQlP < 0)
								{
									return false;
								}
								Joystick joystick = pollingHelper.iXXnBJLcWnzTqSgqWZdYDvDcOgNG.nrlxRpyPglGccrqNtakOClEIBShgA.QPbwEzurbQskXsrZQCvuwTpGtHyA(PpRmtrgbyRhinDxZLIGpsCZrAQlP);
								if (joystick == null)
								{
									return false;
								}
								RGtJnpBeuCJzEmWIIuWGBCudwgho = joystick.PollForAllElementsDown().GetEnumerator();
								RixxlsvDpuqUsNAPjGvfVkMxInho = -3;
								break;
							}
							case 1:
								RixxlsvDpuqUsNAPjGvfVkMxInho = -3;
								break;
							}
							if (RGtJnpBeuCJzEmWIIuWGBCudwgho.MoveNext())
							{
								ControllerPollingInfo current = RGtJnpBeuCJzEmWIIuWGBCudwgho.Current;
								ControllerPollingInfo tnItkGuawckltSBJFASKMGLtMBUO = new ControllerPollingInfo(current);
								tnItkGuawckltSBJFASKMGLtMBUO.playerId = pollingHelper.qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
								TnItkGuawckltSBJFASKMGLtMBUO = tnItkGuawckltSBJFASKMGLtMBUO;
								RixxlsvDpuqUsNAPjGvfVkMxInho = 1;
								return true;
							}
							aVnigOjqtkEcPRckLzLuTqddDIzcA();
							RGtJnpBeuCJzEmWIIuWGBCudwgho = null;
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void aVnigOjqtkEcPRckLzLuTqddDIzcA()
					{
						RixxlsvDpuqUsNAPjGvfVkMxInho = -1;
						if (RGtJnpBeuCJzEmWIIuWGBCudwgho != null)
						{
							RGtJnpBeuCJzEmWIIuWGBCudwgho.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						alCHUjaFkCiTOKTwLWgwgzHTCHGQ alCHUjaFkCiTOKTwLWgwgzHTCHGQ2;
						if (RixxlsvDpuqUsNAPjGvfVkMxInho == -2 && HsoKyJVsHTiVPlqGGIJiXbMziogc == Environment.CurrentManagedThreadId)
						{
							RixxlsvDpuqUsNAPjGvfVkMxInho = 0;
							alCHUjaFkCiTOKTwLWgwgzHTCHGQ2 = this;
						}
						else
						{
							alCHUjaFkCiTOKTwLWgwgzHTCHGQ2 = new alCHUjaFkCiTOKTwLWgwgzHTCHGQ(0);
							alCHUjaFkCiTOKTwLWgwgzHTCHGQ2.uCuKeaJHafIiaVHqZBSCaHrTkNDy = uCuKeaJHafIiaVHqZBSCaHrTkNDy;
						}
						alCHUjaFkCiTOKTwLWgwgzHTCHGQ2.PpRmtrgbyRhinDxZLIGpsCZrAQlP = EPGgAHkaMtEvfIwluqrLvBRuJVBO;
						return alCHUjaFkCiTOKTwLWgwgzHTCHGQ2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private readonly Player qMDeSZPYnkkHNIfpFLCNLEmsbLRs;

				private readonly ControllerHelper iXXnBJLcWnzTqSgqWZdYDvDcOgNG;

				private readonly int xcTrnIlfvQDoPhqGtavJFPqEppzqc;

				internal PollingHelper(Player P_0, ControllerHelper P_1)
				{
					xcTrnIlfvQDoPhqGtavJFPqEppzqc = ReInput.id;
					qMDeSZPYnkkHNIfpFLCNLEmsbLRs = P_0;
					iXXnBJLcWnzTqSgqWZdYDvDcOgNG = P_1;
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != xcTrnIlfvQDoPhqGtavJFPqEppzqc)
					{
						ReInput.CheckInitialized(xcTrnIlfvQDoPhqGtavJFPqEppzqc);
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => oIMDKCYYooLFPJaKBtIrHSDwPnQr(), 
						ControllerType.Joystick => IydiTMnShwrixbRNranMxFsaBkru(controllerId), 
						ControllerType.Mouse => YDMekPzwmfjRhEdqrKzAqIXIDfGpA(), 
						ControllerType.Custom => sweUWCjRhSdZfyNHeDfNcOnKsfKj(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != xcTrnIlfvQDoPhqGtavJFPqEppzqc)
					{
						ReInput.CheckInitialized(xcTrnIlfvQDoPhqGtavJFPqEppzqc);
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => IjWmhdWgbIEysgkholUYirddAjAV(), 
						ControllerType.Joystick => CjQBKlNFCbsRnaqOBufQtAqqOKFe(controllerId), 
						ControllerType.Mouse => jTFDKvlIOGnVULvrnSyNkSXUGsNv(), 
						ControllerType.Custom => qthENTpyTajJAablKhWCBhOyMbegA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != xcTrnIlfvQDoPhqGtavJFPqEppzqc)
					{
						ReInput.CheckInitialized(xcTrnIlfvQDoPhqGtavJFPqEppzqc);
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => oIMDKCYYooLFPJaKBtIrHSDwPnQr(), 
						ControllerType.Joystick => YjSYLfMvbBQSfCMaWmTvlkGwoIDV(controllerId), 
						ControllerType.Mouse => hiTlFLxsqdzkathufXrrYBMYXkfh(), 
						ControllerType.Custom => KPfOnDGQZpSJgujVtAFGVpNYjeKg(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != xcTrnIlfvQDoPhqGtavJFPqEppzqc)
					{
						ReInput.CheckInitialized(xcTrnIlfvQDoPhqGtavJFPqEppzqc);
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => IjWmhdWgbIEysgkholUYirddAjAV(), 
						ControllerType.Joystick => QGuRTOwnEOoswQQbGmttNIncANfo(controllerId), 
						ControllerType.Mouse => ytQtAIAbUwxuILEIWbJfWOoKAoihA(), 
						ControllerType.Custom => BNwzfCcruwGwnToymciyFTVEEEOEA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != xcTrnIlfvQDoPhqGtavJFPqEppzqc)
					{
						ReInput.CheckInitialized(xcTrnIlfvQDoPhqGtavJFPqEppzqc);
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU(), 
						ControllerType.Joystick => gkPypTsoaIJAHjUOyoqdsGHEWHDL(controllerId), 
						ControllerType.Mouse => wcOBrhFbdFtghitqHbjmnafihPpNA(), 
						ControllerType.Custom => ltfvcKlaXOacLupgseYWmFcByMFH(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != xcTrnIlfvQDoPhqGtavJFPqEppzqc)
					{
						ReInput.CheckInitialized(xcTrnIlfvQDoPhqGtavJFPqEppzqc);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => vxuuSHQTtFBRslVFnygxhtWyxRPi(), 
						ControllerType.Joystick => BjfGiChuandzBAmkJKxZPTlhtygN(controllerId), 
						ControllerType.Mouse => sXPtbeCbdphshaFCgtOKVCePqNfj(), 
						ControllerType.Custom => cQiyStqqdPIDSegPUllsqxoaajcBb(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElementsDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != xcTrnIlfvQDoPhqGtavJFPqEppzqc)
					{
						ReInput.CheckInitialized(xcTrnIlfvQDoPhqGtavJFPqEppzqc);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => EttWBTZGZVOtoiUMhmRNUMaxSTZG(), 
						ControllerType.Joystick => xmtkupafGljcLDoNIWhfhrnAnxjAA(controllerId), 
						ControllerType.Mouse => abVDkGEjXQcghNHXqtYzbQXevYmB(), 
						ControllerType.Custom => oqIWTjUPTbeeXkqhmiJIYZHZUpgp(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtons(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != xcTrnIlfvQDoPhqGtavJFPqEppzqc)
					{
						ReInput.CheckInitialized(xcTrnIlfvQDoPhqGtavJFPqEppzqc);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => vxuuSHQTtFBRslVFnygxhtWyxRPi(), 
						ControllerType.Joystick => cfcXRDcInnacPgaEmBUhbrGsKHLcb(controllerId), 
						ControllerType.Mouse => vWBecSnWIXbzKjRanipooYLSmhjy(), 
						ControllerType.Custom => vFRcRvYcaEkLCjQEYYaxWMSIeMKh(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtonsDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != xcTrnIlfvQDoPhqGtavJFPqEppzqc)
					{
						ReInput.CheckInitialized(xcTrnIlfvQDoPhqGtavJFPqEppzqc);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => EttWBTZGZVOtoiUMhmRNUMaxSTZG(), 
						ControllerType.Joystick => LBKfliHQeqzXnGKWIBUaqJDUPUTCA(controllerId), 
						ControllerType.Mouse => EjzBjjAgSGhpWqBiKuuLawpCPJId(), 
						ControllerType.Custom => aRqmuglhAzanzdpBpchQLoSvJCWh(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllAxes(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != xcTrnIlfvQDoPhqGtavJFPqEppzqc)
					{
						ReInput.CheckInitialized(xcTrnIlfvQDoPhqGtavJFPqEppzqc);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Joystick => jsCYYJggoplNUhacnlKStgLadIbg(controllerId), 
						ControllerType.Mouse => JctyBgDRoQmnaJdzJXUhEkdkqakk(), 
						ControllerType.Custom => OyouFLnYNcAJvsORukuHFHFvjRht(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (ReInput._id != xcTrnIlfvQDoPhqGtavJFPqEppzqc)
					{
						ReInput.CheckInitialized(xcTrnIlfvQDoPhqGtavJFPqEppzqc);
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => oIMDKCYYooLFPJaKBtIrHSDwPnQr(), 
						ControllerType.Joystick => OLNFPggxCiQcjcUjjvUMJodRfYCGb(), 
						ControllerType.Mouse => YDMekPzwmfjRhEdqrKzAqIXIDfGpA(), 
						ControllerType.Custom => auAiKqaDlIDdKfkPNGGpboEbpsBAc(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (ReInput._id != xcTrnIlfvQDoPhqGtavJFPqEppzqc)
					{
						ReInput.CheckInitialized(xcTrnIlfvQDoPhqGtavJFPqEppzqc);
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => oIMDKCYYooLFPJaKBtIrHSDwPnQr(), 
						ControllerType.Joystick => GkuhPicyyxbgtNqMgIxpBeCdBaXX(), 
						ControllerType.Mouse => hiTlFLxsqdzkathufXrrYBMYXkfh(), 
						ControllerType.Custom => TTOrdItpovVVOcNpiyKBmpWNtUuG(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (ReInput._id != xcTrnIlfvQDoPhqGtavJFPqEppzqc)
					{
						ReInput.CheckInitialized(xcTrnIlfvQDoPhqGtavJFPqEppzqc);
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => IjWmhdWgbIEysgkholUYirddAjAV(), 
						ControllerType.Joystick => dGmipokqtveHhxQGMLlCNaMucDtjA(), 
						ControllerType.Mouse => ytQtAIAbUwxuILEIWbJfWOoKAoihA(), 
						ControllerType.Custom => cmqaNCGmutKFjqmfEFfzjuSQqzVBA(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (ReInput._id != xcTrnIlfvQDoPhqGtavJFPqEppzqc)
					{
						ReInput.CheckInitialized(xcTrnIlfvQDoPhqGtavJFPqEppzqc);
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU(), 
						ControllerType.Joystick => vobudHGkhSrgSTpssylsPcZThkbF(), 
						ControllerType.Mouse => wcOBrhFbdFtghitqHbjmnafihPpNA(), 
						ControllerType.Custom => lIggmvdzZWSZUJOudIZPnSrOxyNFA(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElements(ControllerType controllerType)
				{
					if (ReInput._id != xcTrnIlfvQDoPhqGtavJFPqEppzqc)
					{
						ReInput.CheckInitialized(xcTrnIlfvQDoPhqGtavJFPqEppzqc);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => vxuuSHQTtFBRslVFnygxhtWyxRPi(), 
						ControllerType.Joystick => cuCrWvBvIlhoVyTNzeuStJtuUVqc(), 
						ControllerType.Mouse => sXPtbeCbdphshaFCgtOKVCePqNfj(), 
						ControllerType.Custom => uzTVPzCJcyePsbeIGoWMmCSqDRk(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElementsDown(ControllerType controllerType)
				{
					if (ReInput._id != xcTrnIlfvQDoPhqGtavJFPqEppzqc)
					{
						ReInput.CheckInitialized(xcTrnIlfvQDoPhqGtavJFPqEppzqc);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => EttWBTZGZVOtoiUMhmRNUMaxSTZG(), 
						ControllerType.Joystick => SUgPlnrpPmuAUXxFImuFXyJLvxRK(), 
						ControllerType.Mouse => abVDkGEjXQcghNHXqtYzbQXevYmB(), 
						ControllerType.Custom => kMYNgmGeCRdZjEabZDPVtGKPVzbGA(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtons(ControllerType controllerType)
				{
					if (ReInput._id != xcTrnIlfvQDoPhqGtavJFPqEppzqc)
					{
						ReInput.CheckInitialized(xcTrnIlfvQDoPhqGtavJFPqEppzqc);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => vxuuSHQTtFBRslVFnygxhtWyxRPi(), 
						ControllerType.Joystick => yXvDoKodwltFIpoyUFNnpOdoeebY(), 
						ControllerType.Mouse => vWBecSnWIXbzKjRanipooYLSmhjy(), 
						ControllerType.Custom => VtsPrVxCPnntwPdYFrSXmJHealHd(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtonsDown(ControllerType controllerType)
				{
					if (ReInput._id != xcTrnIlfvQDoPhqGtavJFPqEppzqc)
					{
						ReInput.CheckInitialized(xcTrnIlfvQDoPhqGtavJFPqEppzqc);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => EttWBTZGZVOtoiUMhmRNUMaxSTZG(), 
						ControllerType.Joystick => OAeWWekliuHXtmsTvsAIKvQuvchq(), 
						ControllerType.Mouse => EjzBjjAgSGhpWqBiKuuLawpCPJId(), 
						ControllerType.Custom => oKCmFSPZMfQhqDtMhosFPResXCTv(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllAxes(ControllerType controllerType)
				{
					if (ReInput._id != xcTrnIlfvQDoPhqGtavJFPqEppzqc)
					{
						ReInput.CheckInitialized(xcTrnIlfvQDoPhqGtavJFPqEppzqc);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Joystick => ZBLrscTQJwHgNIxOqxVjHzoXNTNc(), 
						ControllerType.Mouse => JctyBgDRoQmnaJdzJXUhEkdkqakk(), 
						ControllerType.Custom => scfAoIoRuBdTEzGvvyClmYRerADJ(), 
						_ => throw new NotImplementedException(), 
					};
				}

				private ControllerPollingInfo IydiTMnShwrixbRNranMxFsaBkru(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					Joystick joystick = iXXnBJLcWnzTqSgqWZdYDvDcOgNG.nrlxRpyPglGccrqNtakOClEIBShgA.QPbwEzurbQskXsrZQCvuwTpGtHyA(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					ControllerPollingInfo result = joystick.PollForFirstElement();
					if (result.success)
					{
						result.playerId = qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
					}
					return result;
				}

				private ControllerPollingInfo CjQBKlNFCbsRnaqOBufQtAqqOKFe(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					Joystick joystick = iXXnBJLcWnzTqSgqWZdYDvDcOgNG.nrlxRpyPglGccrqNtakOClEIBShgA.QPbwEzurbQskXsrZQCvuwTpGtHyA(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					ControllerPollingInfo result = joystick.PollForFirstElementDown();
					if (result.success)
					{
						result.playerId = qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
					}
					return result;
				}

				private ControllerPollingInfo YjSYLfMvbBQSfCMaWmTvlkGwoIDV(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					Joystick joystick = iXXnBJLcWnzTqSgqWZdYDvDcOgNG.nrlxRpyPglGccrqNtakOClEIBShgA.QPbwEzurbQskXsrZQCvuwTpGtHyA(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					ControllerPollingInfo result = joystick.PollForFirstButton();
					if (result.success)
					{
						result.playerId = qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
					}
					return result;
				}

				private ControllerPollingInfo QGuRTOwnEOoswQQbGmttNIncANfo(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					Joystick joystick = iXXnBJLcWnzTqSgqWZdYDvDcOgNG.nrlxRpyPglGccrqNtakOClEIBShgA.QPbwEzurbQskXsrZQCvuwTpGtHyA(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					ControllerPollingInfo result = joystick.PollForFirstButtonDown();
					if (result.success)
					{
						result.playerId = qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
					}
					return result;
				}

				private ControllerPollingInfo gkPypTsoaIJAHjUOyoqdsGHEWHDL(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					Joystick joystick = iXXnBJLcWnzTqSgqWZdYDvDcOgNG.nrlxRpyPglGccrqNtakOClEIBShgA.QPbwEzurbQskXsrZQCvuwTpGtHyA(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					ControllerPollingInfo result = joystick.PollForFirstAxis();
					if (result.success)
					{
						result.playerId = qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
					}
					return result;
				}

				[IteratorStateMachine(typeof(znSKDeHQqCAfNFJMFLducHwcOSmnb))]
				private IEnumerable<ControllerPollingInfo> BjfGiChuandzBAmkJKxZPTlhtygN(int P_0)
				{
					return new znSKDeHQqCAfNFJMFLducHwcOSmnb(-2)
					{
						MErTOuXGzeOoxNolbnPmiyRKTeAo = this,
						rLIempboENpeJHEUpGXAXgnDNvqo = P_0
					};
				}

				[IteratorStateMachine(typeof(alCHUjaFkCiTOKTwLWgwgzHTCHGQ))]
				private IEnumerable<ControllerPollingInfo> xmtkupafGljcLDoNIWhfhrnAnxjAA(int P_0)
				{
					return new alCHUjaFkCiTOKTwLWgwgzHTCHGQ(-2)
					{
						uCuKeaJHafIiaVHqZBSCaHrTkNDy = this,
						EPGgAHkaMtEvfIwluqrLvBRuJVBO = P_0
					};
				}

				[IteratorStateMachine(typeof(idiHURGaMwcjWbVIiZIXdOgoKRKBc))]
				private IEnumerable<ControllerPollingInfo> cfcXRDcInnacPgaEmBUhbrGsKHLcb(int P_0)
				{
					return new idiHURGaMwcjWbVIiZIXdOgoKRKBc(-2)
					{
						juWxJcSjtCyOmKbflEhTKUCtgine = this,
						BviZDnWnTCaOiCiMeGfkIXaeNVJw = P_0
					};
				}

				[IteratorStateMachine(typeof(DAlFVMUWRyaDFmUgBakhwbrzpDVi))]
				private IEnumerable<ControllerPollingInfo> LBKfliHQeqzXnGKWIBUaqJDUPUTCA(int P_0)
				{
					return new DAlFVMUWRyaDFmUgBakhwbrzpDVi(-2)
					{
						bIzTMarsDGAgsjsPIfzXSvptLrbDA = this,
						pNYvOUpGOaDoAoRBXquYcprAzNNF = P_0
					};
				}

				[IteratorStateMachine(typeof(ndyMNJSZizkRQAlDKhJcnvzRXBzB))]
				private IEnumerable<ControllerPollingInfo> jsCYYJggoplNUhacnlKStgLadIbg(int P_0)
				{
					return new ndyMNJSZizkRQAlDKhJcnvzRXBzB(-2)
					{
						GErlHAUGOsKZgfVCQECGFmUZOfwd = this,
						DbEoGpuflIhVBWtPcVUHaPWwzaEe = P_0
					};
				}

				private ControllerPollingInfo OLNFPggxCiQcjcUjjvUMJodRfYCGb()
				{
					IList<Joystick> list = iXXnBJLcWnzTqSgqWZdYDvDcOgNG.nrlxRpyPglGccrqNtakOClEIBShgA.xMPzVHlWLmYQdGOQbmSeMmfOpemj;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							result.playerId = qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
							return result;
						}
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo hhXJltdEnomuFBTaenfLcshslFkw()
				{
					IList<Joystick> list = iXXnBJLcWnzTqSgqWZdYDvDcOgNG.nrlxRpyPglGccrqNtakOClEIBShgA.xMPzVHlWLmYQdGOQbmSeMmfOpemj;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							result.playerId = qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
							return result;
						}
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo GkuhPicyyxbgtNqMgIxpBeCdBaXX()
				{
					IList<Joystick> list = iXXnBJLcWnzTqSgqWZdYDvDcOgNG.nrlxRpyPglGccrqNtakOClEIBShgA.xMPzVHlWLmYQdGOQbmSeMmfOpemj;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							result.playerId = qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
							return result;
						}
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo dGmipokqtveHhxQGMLlCNaMucDtjA()
				{
					IList<Joystick> list = iXXnBJLcWnzTqSgqWZdYDvDcOgNG.nrlxRpyPglGccrqNtakOClEIBShgA.xMPzVHlWLmYQdGOQbmSeMmfOpemj;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							result.playerId = qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
							return result;
						}
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo vobudHGkhSrgSTpssylsPcZThkbF()
				{
					IList<Joystick> list = iXXnBJLcWnzTqSgqWZdYDvDcOgNG.nrlxRpyPglGccrqNtakOClEIBShgA.xMPzVHlWLmYQdGOQbmSeMmfOpemj;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							result.playerId = qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
							return result;
						}
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				[IteratorStateMachine(typeof(EIMgBzHEbXypbpBWMzPnwfXJSQfTA))]
				private IEnumerable<ControllerPollingInfo> cuCrWvBvIlhoVyTNzeuStJtuUVqc()
				{
					return new EIMgBzHEbXypbpBWMzPnwfXJSQfTA(-2)
					{
						SXyfvjAtWiWJAbqeqTCKJxTTKvDV = this
					};
				}

				[IteratorStateMachine(typeof(mlyVCVZSSkQygyzJrlPwjkOihudF))]
				private IEnumerable<ControllerPollingInfo> SUgPlnrpPmuAUXxFImuFXyJLvxRK()
				{
					return new mlyVCVZSSkQygyzJrlPwjkOihudF(-2)
					{
						gmYSTIThFvsrENtjkDLBvOIyvaSQ = this
					};
				}

				[IteratorStateMachine(typeof(PSDrqzrTmHBpIGSUNbmAMNzKKzRC))]
				private IEnumerable<ControllerPollingInfo> yXvDoKodwltFIpoyUFNnpOdoeebY()
				{
					return new PSDrqzrTmHBpIGSUNbmAMNzKKzRC(-2)
					{
						obCzFRwEXiEehabnEjIZrUFgengQA = this
					};
				}

				[IteratorStateMachine(typeof(cNZpxtcBQfHjDuBqubvaKdgqDOAc))]
				private IEnumerable<ControllerPollingInfo> OAeWWekliuHXtmsTvsAIKvQuvchq()
				{
					return new cNZpxtcBQfHjDuBqubvaKdgqDOAc(-2)
					{
						aVERlctIVPaHMdktbjaldkeEiFrP = this
					};
				}

				[IteratorStateMachine(typeof(tMhiSRRktkzawMcaJZMcQGMVJTqF))]
				private IEnumerable<ControllerPollingInfo> ZBLrscTQJwHgNIxOqxVjHzoXNTNc()
				{
					return new tMhiSRRktkzawMcaJZMcQGMVJTqF(-2)
					{
						EmtdHAQQfvNDhzQFKLQYHFmnLJD = this
					};
				}

				private ControllerPollingInfo oIMDKCYYooLFPJaKBtIrHSDwPnQr()
				{
					if (!iXXnBJLcWnzTqSgqWZdYDvDcOgNG.BUnwASYRryhjaxBuWmrBhHREPzFi)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return iXXnBJLcWnzTqSgqWZdYDvDcOgNG.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo IjWmhdWgbIEysgkholUYirddAjAV()
				{
					if (!iXXnBJLcWnzTqSgqWZdYDvDcOgNG.BUnwASYRryhjaxBuWmrBhHREPzFi)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return iXXnBJLcWnzTqSgqWZdYDvDcOgNG.Keyboard.PollForFirstKeyDown();
				}

				private IEnumerable<ControllerPollingInfo> vxuuSHQTtFBRslVFnygxhtWyxRPi()
				{
					if (!iXXnBJLcWnzTqSgqWZdYDvDcOgNG.BUnwASYRryhjaxBuWmrBhHREPzFi)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return iXXnBJLcWnzTqSgqWZdYDvDcOgNG.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> EttWBTZGZVOtoiUMhmRNUMaxSTZG()
				{
					if (!iXXnBJLcWnzTqSgqWZdYDvDcOgNG.BUnwASYRryhjaxBuWmrBhHREPzFi)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return iXXnBJLcWnzTqSgqWZdYDvDcOgNG.Keyboard.PollForAllKeysDown();
				}

				private ControllerPollingInfo YDMekPzwmfjRhEdqrKzAqIXIDfGpA()
				{
					if (!iXXnBJLcWnzTqSgqWZdYDvDcOgNG.xLShTxicuIwFgBuXyMuCkqzTkmNx)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return iXXnBJLcWnzTqSgqWZdYDvDcOgNG.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo jTFDKvlIOGnVULvrnSyNkSXUGsNv()
				{
					if (!iXXnBJLcWnzTqSgqWZdYDvDcOgNG.xLShTxicuIwFgBuXyMuCkqzTkmNx)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return iXXnBJLcWnzTqSgqWZdYDvDcOgNG.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo hiTlFLxsqdzkathufXrrYBMYXkfh()
				{
					if (!iXXnBJLcWnzTqSgqWZdYDvDcOgNG.xLShTxicuIwFgBuXyMuCkqzTkmNx)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return iXXnBJLcWnzTqSgqWZdYDvDcOgNG.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo ytQtAIAbUwxuILEIWbJfWOoKAoihA()
				{
					if (!iXXnBJLcWnzTqSgqWZdYDvDcOgNG.xLShTxicuIwFgBuXyMuCkqzTkmNx)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return iXXnBJLcWnzTqSgqWZdYDvDcOgNG.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo wcOBrhFbdFtghitqHbjmnafihPpNA()
				{
					if (!iXXnBJLcWnzTqSgqWZdYDvDcOgNG.xLShTxicuIwFgBuXyMuCkqzTkmNx)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return iXXnBJLcWnzTqSgqWZdYDvDcOgNG.Mouse.PollForFirstAxis();
				}

				private IEnumerable<ControllerPollingInfo> sXPtbeCbdphshaFCgtOKVCePqNfj()
				{
					if (!iXXnBJLcWnzTqSgqWZdYDvDcOgNG.xLShTxicuIwFgBuXyMuCkqzTkmNx)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return iXXnBJLcWnzTqSgqWZdYDvDcOgNG.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> abVDkGEjXQcghNHXqtYzbQXevYmB()
				{
					if (!iXXnBJLcWnzTqSgqWZdYDvDcOgNG.xLShTxicuIwFgBuXyMuCkqzTkmNx)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return iXXnBJLcWnzTqSgqWZdYDvDcOgNG.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> vWBecSnWIXbzKjRanipooYLSmhjy()
				{
					if (!iXXnBJLcWnzTqSgqWZdYDvDcOgNG.xLShTxicuIwFgBuXyMuCkqzTkmNx)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return iXXnBJLcWnzTqSgqWZdYDvDcOgNG.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> EjzBjjAgSGhpWqBiKuuLawpCPJId()
				{
					if (!iXXnBJLcWnzTqSgqWZdYDvDcOgNG.xLShTxicuIwFgBuXyMuCkqzTkmNx)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return iXXnBJLcWnzTqSgqWZdYDvDcOgNG.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> JctyBgDRoQmnaJdzJXUhEkdkqakk()
				{
					if (!iXXnBJLcWnzTqSgqWZdYDvDcOgNG.xLShTxicuIwFgBuXyMuCkqzTkmNx)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return iXXnBJLcWnzTqSgqWZdYDvDcOgNG.Mouse.PollForAllAxes();
				}

				private ControllerPollingInfo sweUWCjRhSdZfyNHeDfNcOnKsfKj(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					CustomController customController = iXXnBJLcWnzTqSgqWZdYDvDcOgNG.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.QPbwEzurbQskXsrZQCvuwTpGtHyA(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					ControllerPollingInfo result = customController.PollForFirstElement();
					if (result.success)
					{
						result.playerId = qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
					}
					return result;
				}

				private ControllerPollingInfo qthENTpyTajJAablKhWCBhOyMbegA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					CustomController customController = iXXnBJLcWnzTqSgqWZdYDvDcOgNG.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.QPbwEzurbQskXsrZQCvuwTpGtHyA(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					ControllerPollingInfo result = customController.PollForFirstElementDown();
					if (result.success)
					{
						result.playerId = qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
					}
					return result;
				}

				private ControllerPollingInfo KPfOnDGQZpSJgujVtAFGVpNYjeKg(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					CustomController customController = iXXnBJLcWnzTqSgqWZdYDvDcOgNG.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.QPbwEzurbQskXsrZQCvuwTpGtHyA(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					ControllerPollingInfo result = customController.PollForFirstButton();
					if (result.success)
					{
						result.playerId = qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
					}
					return result;
				}

				private ControllerPollingInfo BNwzfCcruwGwnToymciyFTVEEEOEA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					CustomController customController = iXXnBJLcWnzTqSgqWZdYDvDcOgNG.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.QPbwEzurbQskXsrZQCvuwTpGtHyA(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					ControllerPollingInfo result = customController.PollForFirstButtonDown();
					if (result.success)
					{
						result.playerId = qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
					}
					return result;
				}

				private ControllerPollingInfo ltfvcKlaXOacLupgseYWmFcByMFH(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					CustomController customController = iXXnBJLcWnzTqSgqWZdYDvDcOgNG.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.QPbwEzurbQskXsrZQCvuwTpGtHyA(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					ControllerPollingInfo result = customController.PollForFirstAxis();
					if (result.success)
					{
						result.playerId = qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
					}
					return result;
				}

				[IteratorStateMachine(typeof(AtSlOLJnyIgkoldwbqlqnfAHUlDV))]
				private IEnumerable<ControllerPollingInfo> cQiyStqqdPIDSegPUllsqxoaajcBb(int P_0)
				{
					return new AtSlOLJnyIgkoldwbqlqnfAHUlDV(-2)
					{
						SPwsnYMtFoSzPsMJGfgviTIIMzok = this,
						cwjgAEEGCsTHPsSAXMacUEZZgQCVA = P_0
					};
				}

				[IteratorStateMachine(typeof(VXDQhJjWGnWjWwcYHJUHHHROemgm))]
				private IEnumerable<ControllerPollingInfo> oqIWTjUPTbeeXkqhmiJIYZHZUpgp(int P_0)
				{
					return new VXDQhJjWGnWjWwcYHJUHHHROemgm(-2)
					{
						OIodSbtDnKayvitzeULvVfacKVPab = this,
						LCNPFFkWGhChYOchJKSCDYQvOJBr = P_0
					};
				}

				[IteratorStateMachine(typeof(jueKXEWszdIzhVFugoSAYyNJgVzK))]
				private IEnumerable<ControllerPollingInfo> vFRcRvYcaEkLCjQEYYaxWMSIeMKh(int P_0)
				{
					return new jueKXEWszdIzhVFugoSAYyNJgVzK(-2)
					{
						LNIrdeDGTseajGhxBQhvTzWaLaMKA = this,
						FbJgFpiNwnNAKdhkxOWqvtUssiwdA = P_0
					};
				}

				[IteratorStateMachine(typeof(KjDnkepfksqcrlNKVmWwKnLELKte))]
				private IEnumerable<ControllerPollingInfo> aRqmuglhAzanzdpBpchQLoSvJCWh(int P_0)
				{
					return new KjDnkepfksqcrlNKVmWwKnLELKte(-2)
					{
						YsrBDiBxnvjJILkTRmovmFwblojWA = this,
						WPmdmjXWZPnQTLgInBlJfqNSGlgNA = P_0
					};
				}

				[IteratorStateMachine(typeof(VnumVuHcpGTTJNcSVVtJiozSBpHB))]
				private IEnumerable<ControllerPollingInfo> OyouFLnYNcAJvsORukuHFHFvjRht(int P_0)
				{
					return new VnumVuHcpGTTJNcSVVtJiozSBpHB(-2)
					{
						tjFYArJKNWblyacfnbELsqeqhIdq = this,
						rMzJmLBnDycikRTkzfzYWqbrjqky = P_0
					};
				}

				private ControllerPollingInfo auAiKqaDlIDdKfkPNGGpboEbpsBAc()
				{
					IList<CustomController> list = iXXnBJLcWnzTqSgqWZdYDvDcOgNG.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.xMPzVHlWLmYQdGOQbmSeMmfOpemj;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							result.playerId = qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
							return result;
						}
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo WbpizUKzNlrrgrdugwWDxGKgAwJK()
				{
					IList<CustomController> list = iXXnBJLcWnzTqSgqWZdYDvDcOgNG.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.xMPzVHlWLmYQdGOQbmSeMmfOpemj;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							result.playerId = qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
							return result;
						}
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo TTOrdItpovVVOcNpiyKBmpWNtUuG()
				{
					IList<CustomController> list = iXXnBJLcWnzTqSgqWZdYDvDcOgNG.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.xMPzVHlWLmYQdGOQbmSeMmfOpemj;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							result.playerId = qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
							return result;
						}
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo cmqaNCGmutKFjqmfEFfzjuSQqzVBA()
				{
					IList<CustomController> list = iXXnBJLcWnzTqSgqWZdYDvDcOgNG.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.xMPzVHlWLmYQdGOQbmSeMmfOpemj;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							result.playerId = qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
							return result;
						}
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo lIggmvdzZWSZUJOudIZPnSrOxyNFA()
				{
					IList<CustomController> list = iXXnBJLcWnzTqSgqWZdYDvDcOgNG.EIUmKtKVTnSXOePrSWXLdDuiBIqfA.xMPzVHlWLmYQdGOQbmSeMmfOpemj;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							result.playerId = qMDeSZPYnkkHNIfpFLCNLEmsbLRs.CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
							return result;
						}
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				[IteratorStateMachine(typeof(wUdchMECrdNTFuinfWVKOMygtOwn))]
				private IEnumerable<ControllerPollingInfo> uzTVPzCJcyePsbeIGoWMmCSqDRk()
				{
					return new wUdchMECrdNTFuinfWVKOMygtOwn(-2)
					{
						IBtuCPHKFizomTrSKWjInLUqfnfl = this
					};
				}

				[IteratorStateMachine(typeof(nSBSJQjECxciuKicnjrsddNskTHbb))]
				private IEnumerable<ControllerPollingInfo> kMYNgmGeCRdZjEabZDPVtGKPVzbGA()
				{
					return new nSBSJQjECxciuKicnjrsddNskTHbb(-2)
					{
						EvKLjpUrpsSDcXhVZblYFaBAhcpp = this
					};
				}

				[IteratorStateMachine(typeof(IAhCIoteMhfrvZvFqjvjkjPXwODb))]
				private IEnumerable<ControllerPollingInfo> VtsPrVxCPnntwPdYFrSXmJHealHd()
				{
					return new IAhCIoteMhfrvZvFqjvjkjPXwODb(-2)
					{
						OfIVNyRjCxqtUJqeNpwoxEvkipuf = this
					};
				}

				[IteratorStateMachine(typeof(ZhTaSaFOSmfpOYvUWKAJLzVCJEFDA))]
				private IEnumerable<ControllerPollingInfo> oKCmFSPZMfQhqDtMhosFPResXCTv()
				{
					return new ZhTaSaFOSmfpOYvUWKAJLzVCJEFDA(-2)
					{
						VAVpODMSqkUZNmKcqHeyxEPfFjmr = this
					};
				}

				[IteratorStateMachine(typeof(gsQTrRuyrBsDJpkQIfxrhYVYPDYG))]
				private IEnumerable<ControllerPollingInfo> scfAoIoRuBdTEzGvvyClmYRerADJ()
				{
					return new gsQTrRuyrBsDJpkQIfxrhYVYPDYG(-2)
					{
						YlzmHKcMmQzEZQiVUarVXZMWNTHS = this
					};
				}
			}

			[Serializable]
			private sealed class GqTompPKHhFHPIxFZjCSQNOKtfQoA
			{
				public static readonly GqTompPKHhFHPIxFZjCSQNOKtfQoA _003C_003E9 = new GqTompPKHhFHPIxFZjCSQNOKtfQoA();

				public static Action<Exception> _003C_003E9__26_0;

				public static Action<Exception> _003C_003E9__26_1;

				internal void eGDAFxRvQjcCtUUzCUPqYxUbRdmS(Exception P_0)
				{
					ReInput.HandleCallbackException("Player.ControllerHelper.ControllerAddedEvent", P_0);
				}

				internal void mjevDsXADSCDujKBCvmsACeLchUz(Exception P_0)
				{
					ReInput.HandleCallbackException("Player.ControllerHelper.ControllerRemovedEvent", P_0);
				}
			}

			private sealed class sizCXKIeWFhmWihbJUxzEUqtdgA : IEnumerable<Controller>, IEnumerable, IEnumerator<Controller>, IEnumerator, IDisposable
			{
				private int xvaECyhlbjqWwSKBJRaarQwrbJXg;

				private Controller GqJaOjKjKpQhrMuoCVQHVusLPrsz;

				private int oiXQTiILLpIHZFRGpjzGPZmvggRM;

				public ControllerHelper WNTtghwzFJwkBpCSrcPNEYAgrwyKA;

				private int ByZFHRxixwwTIyRziqPnvtDyYDqi;

				private IList<Joystick> TLvENPrNZMlpiPrFhXZPaEbDnGoF;

				private int MelVSrMshvJJLnYkpTGycdhMylzb;

				private IList<CustomController> aKxpnGmlAXxhSkpqLGLGYIHewOEI;

				private int MvmKCtAeKEehIWyMFvdNBFWPBFwA;

				Controller IEnumerator<Controller>.Current
				{
					[DebuggerHidden]
					get
					{
						return GqJaOjKjKpQhrMuoCVQHVusLPrsz;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return GqJaOjKjKpQhrMuoCVQHVusLPrsz;
					}
				}

				[DebuggerHidden]
				public sizCXKIeWFhmWihbJUxzEUqtdgA(int P_0)
				{
					xvaECyhlbjqWwSKBJRaarQwrbJXg = P_0;
					oiXQTiILLpIHZFRGpjzGPZmvggRM = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					TLvENPrNZMlpiPrFhXZPaEbDnGoF = null;
					aKxpnGmlAXxhSkpqLGLGYIHewOEI = null;
					xvaECyhlbjqWwSKBJRaarQwrbJXg = -2;
				}

				private bool MoveNext()
				{
					int num = xvaECyhlbjqWwSKBJRaarQwrbJXg;
					ControllerHelper wNTtghwzFJwkBpCSrcPNEYAgrwyKA = WNTtghwzFJwkBpCSrcPNEYAgrwyKA;
					switch (num)
					{
					default:
						return false;
					case 0:
						xvaECyhlbjqWwSKBJRaarQwrbJXg = -1;
						if (ReInput._id != wNTtghwzFJwkBpCSrcPNEYAgrwyKA.qTfdcxTWyorroOBltCgfHqlllFKdb)
						{
							ReInput.CheckInitialized(wNTtghwzFJwkBpCSrcPNEYAgrwyKA.qTfdcxTWyorroOBltCgfHqlllFKdb);
							return false;
						}
						if (wNTtghwzFJwkBpCSrcPNEYAgrwyKA.xLShTxicuIwFgBuXyMuCkqzTkmNx)
						{
							GqJaOjKjKpQhrMuoCVQHVusLPrsz = wNTtghwzFJwkBpCSrcPNEYAgrwyKA.Mouse;
							xvaECyhlbjqWwSKBJRaarQwrbJXg = 1;
							return true;
						}
						goto IL_0070;
					case 1:
						xvaECyhlbjqWwSKBJRaarQwrbJXg = -1;
						goto IL_0070;
					case 2:
						xvaECyhlbjqWwSKBJRaarQwrbJXg = -1;
						goto IL_0094;
					case 3:
						xvaECyhlbjqWwSKBJRaarQwrbJXg = -1;
						MvmKCtAeKEehIWyMFvdNBFWPBFwA++;
						goto IL_00ec;
					case 4:
						{
							xvaECyhlbjqWwSKBJRaarQwrbJXg = -1;
							MvmKCtAeKEehIWyMFvdNBFWPBFwA++;
							break;
						}
						IL_0094:
						ByZFHRxixwwTIyRziqPnvtDyYDqi = wNTtghwzFJwkBpCSrcPNEYAgrwyKA.joystickCount;
						TLvENPrNZMlpiPrFhXZPaEbDnGoF = wNTtghwzFJwkBpCSrcPNEYAgrwyKA.Joysticks;
						MvmKCtAeKEehIWyMFvdNBFWPBFwA = 0;
						goto IL_00ec;
						IL_00ec:
						if (MvmKCtAeKEehIWyMFvdNBFWPBFwA < ByZFHRxixwwTIyRziqPnvtDyYDqi)
						{
							GqJaOjKjKpQhrMuoCVQHVusLPrsz = TLvENPrNZMlpiPrFhXZPaEbDnGoF[MvmKCtAeKEehIWyMFvdNBFWPBFwA];
							xvaECyhlbjqWwSKBJRaarQwrbJXg = 3;
							return true;
						}
						MelVSrMshvJJLnYkpTGycdhMylzb = wNTtghwzFJwkBpCSrcPNEYAgrwyKA.customControllerCount;
						aKxpnGmlAXxhSkpqLGLGYIHewOEI = wNTtghwzFJwkBpCSrcPNEYAgrwyKA.CustomControllers;
						MvmKCtAeKEehIWyMFvdNBFWPBFwA = 0;
						break;
						IL_0070:
						if (wNTtghwzFJwkBpCSrcPNEYAgrwyKA.BUnwASYRryhjaxBuWmrBhHREPzFi)
						{
							GqJaOjKjKpQhrMuoCVQHVusLPrsz = wNTtghwzFJwkBpCSrcPNEYAgrwyKA.Keyboard;
							xvaECyhlbjqWwSKBJRaarQwrbJXg = 2;
							return true;
						}
						goto IL_0094;
					}
					if (MvmKCtAeKEehIWyMFvdNBFWPBFwA < MelVSrMshvJJLnYkpTGycdhMylzb)
					{
						GqJaOjKjKpQhrMuoCVQHVusLPrsz = aKxpnGmlAXxhSkpqLGLGYIHewOEI[MvmKCtAeKEehIWyMFvdNBFWPBFwA];
						xvaECyhlbjqWwSKBJRaarQwrbJXg = 4;
						return true;
					}
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<Controller> IEnumerable<Controller>.GetEnumerator()
				{
					sizCXKIeWFhmWihbJUxzEUqtdgA sizCXKIeWFhmWihbJUxzEUqtdgA2;
					if (xvaECyhlbjqWwSKBJRaarQwrbJXg == -2 && oiXQTiILLpIHZFRGpjzGPZmvggRM == Environment.CurrentManagedThreadId)
					{
						xvaECyhlbjqWwSKBJRaarQwrbJXg = 0;
						sizCXKIeWFhmWihbJUxzEUqtdgA2 = this;
					}
					else
					{
						sizCXKIeWFhmWihbJUxzEUqtdgA2 = new sizCXKIeWFhmWihbJUxzEUqtdgA(0);
						sizCXKIeWFhmWihbJUxzEUqtdgA2.WNTtghwzFJwkBpCSrcPNEYAgrwyKA = WNTtghwzFJwkBpCSrcPNEYAgrwyKA;
					}
					return sizCXKIeWFhmWihbJUxzEUqtdgA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Controller>)this).GetEnumerator();
				}
			}

			private readonly NgGecrMhKOkBnKfvwcKnhrEwErRtA IbydFgCDHfKWDBbtCKTfRwHOHYkn;

			private bool xLShTxicuIwFgBuXyMuCkqzTkmNx;

			private bool BUnwASYRryhjaxBuWmrBhHREPzFi;

			private bool byqllvwlQDrfiJdMuEIifljYypgD;

			private double ODjAeaMUwkvlDKQdYRbrqssWtARf;

			private double WccVKUnrSKjLXmhApgCgBkBXIiFlA;

			private double BnjIKvmyVMIUKYMkohciCNNqPJpeA;

			private ControllerType ezbZTXdkidNDavCOKsWfXInnvoeS;

			private int oZIbdrTKSqplcltMwzBuQATFbJVJ = -1;

			private SafeAction<ControllerAssignmentChangedEventArgs> FCzgnxtefOCfVKONzLkYlWvgBKVY = new SafeAction<ControllerAssignmentChangedEventArgs>(GqTompPKHhFHPIxFZjCSQNOKtfQoA._003C_003E9.eGDAFxRvQjcCtUUzCUPqYxUbRdmS);

			private SafeAction<ControllerAssignmentChangedEventArgs> xQnEXdVUtrXxNPpcmFECrEoksMBo = new SafeAction<ControllerAssignmentChangedEventArgs>(GqTompPKHhFHPIxFZjCSQNOKtfQoA._003C_003E9.mjevDsXADSCDujKBCvmsACeLchUz);

			private readonly MXjbWOahTaUnsydvZFHZuVPKnVfY pRqOhIQKigQoocBjtcSkXzVEpacG;

			private readonly Player tdGjdCGuLAvlseyaulsBSplVuGohA;

			private readonly fIKoOjsUVwLfLYGsxsHqEoHWjzbJ OZIWIejsafJflHQQormyeoaJABcC;

			private readonly int qTfdcxTWyorroOBltCgfHqlllFKdb;

			public readonly MapHelper maps;

			public readonly ConflictCheckingHelper conflictChecking;

			public readonly PollingHelper polling;

			private BugNwVeIKhVzIDUOvQkABeSlylki<Joystick, JoystickMap> nrlxRpyPglGccrqNtakOClEIBShgA => (BugNwVeIKhVzIDUOvQkABeSlylki<Joystick, JoystickMap>)IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Joystick);

			private global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<KeyboardMap> eQuLUmKldncNSRwQykDfVdXjpNIX => (global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<KeyboardMap>)IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Keyboard).YacHzxfeOlVQUomSEcSTDHYQttOQA(0).ahBHvaaFKqjYqOJIXAFDIKodzptCA;

			private global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<MouseMap> FzbVyEOvvgfTkhXYXDFdoDEfmCxE => (global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<MouseMap>)IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Mouse).YacHzxfeOlVQUomSEcSTDHYQttOQA(0).ahBHvaaFKqjYqOJIXAFDIKodzptCA;

			private BugNwVeIKhVzIDUOvQkABeSlylki<CustomController, CustomControllerMap> EIUmKtKVTnSXOePrSWXLdDuiBIqfA => (BugNwVeIKhVzIDUOvQkABeSlylki<CustomController, CustomControllerMap>)IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Custom);

			public bool hasMouse
			{
				get
				{
					if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
					{
						ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
						return false;
					}
					return xLShTxicuIwFgBuXyMuCkqzTkmNx;
				}
				set
				{
					if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
					{
						ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					}
					else
					{
						if (xLShTxicuIwFgBuXyMuCkqzTkmNx == value)
						{
							return;
						}
						xLShTxicuIwFgBuXyMuCkqzTkmNx = value;
						if (value)
						{
							OZIWIejsafJflHQQormyeoaJABcC.LPYvDZQlHJmSBLNPWIwEIpLEAtRv(Mouse);
						}
						else
						{
							OZIWIejsafJflHQQormyeoaJABcC.cKhLpzZdxbLRWdRHngLGhLGhgriC(Mouse);
						}
						if (value)
						{
							maps.layoutManager.Apply();
							if (FCzgnxtefOCfVKONzLkYlWvgBKVY.Count > 0)
							{
								FCzgnxtefOCfVKONzLkYlWvgBKVY.Invoke(new ControllerAssignmentChangedEventArgs(tdGjdCGuLAvlseyaulsBSplVuGohA.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
							}
						}
						else if (xQnEXdVUtrXxNPpcmFECrEoksMBo.Count > 0)
						{
							xQnEXdVUtrXxNPpcmFECrEoksMBo.Invoke(new ControllerAssignmentChangedEventArgs(tdGjdCGuLAvlseyaulsBSplVuGohA.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
						}
					}
				}
			}

			public bool hasKeyboard
			{
				get
				{
					if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
					{
						ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
						return false;
					}
					return BUnwASYRryhjaxBuWmrBhHREPzFi;
				}
				set
				{
					if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
					{
						ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					}
					else
					{
						if (BUnwASYRryhjaxBuWmrBhHREPzFi == value)
						{
							return;
						}
						BUnwASYRryhjaxBuWmrBhHREPzFi = value;
						if (value)
						{
							OZIWIejsafJflHQQormyeoaJABcC.LPYvDZQlHJmSBLNPWIwEIpLEAtRv(Keyboard);
						}
						else
						{
							OZIWIejsafJflHQQormyeoaJABcC.cKhLpzZdxbLRWdRHngLGhLGhgriC(Keyboard);
						}
						if (value)
						{
							maps.layoutManager.Apply();
							if (FCzgnxtefOCfVKONzLkYlWvgBKVY.Count > 0)
							{
								FCzgnxtefOCfVKONzLkYlWvgBKVY.Invoke(new ControllerAssignmentChangedEventArgs(tdGjdCGuLAvlseyaulsBSplVuGohA.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
							}
						}
						else if (xQnEXdVUtrXxNPpcmFECrEoksMBo.Count > 0)
						{
							xQnEXdVUtrXxNPpcmFECrEoksMBo.Invoke(new ControllerAssignmentChangedEventArgs(tdGjdCGuLAvlseyaulsBSplVuGohA.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
						}
					}
				}
			}

			public bool excludeFromControllerAutoAssignment
			{
				get
				{
					if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
					{
						ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
						return false;
					}
					return byqllvwlQDrfiJdMuEIifljYypgD;
				}
				set
				{
					if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
					{
						ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					}
					else
					{
						byqllvwlQDrfiJdMuEIifljYypgD = value;
					}
				}
			}

			public Keyboard Keyboard
			{
				get
				{
					if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
					{
						ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
						return null;
					}
					return ReInput.controllers.Keyboard;
				}
			}

			public Mouse Mouse
			{
				get
				{
					if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
					{
						ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
						return null;
					}
					return ReInput.controllers.Mouse;
				}
			}

			public int joystickCount
			{
				get
				{
					if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
					{
						ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
						return 0;
					}
					return IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Joystick).RkJWsNlHTmrNlRDEKklNpYTEPhDh;
				}
			}

			public IList<Joystick> Joysticks
			{
				get
				{
					if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
					{
						ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
						return EmptyObjects<Joystick>.EmptyReadOnlyIListT;
					}
					return (IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Joystick) as BugNwVeIKhVzIDUOvQkABeSlylki<Joystick, JoystickMap>).xMPzVHlWLmYQdGOQbmSeMmfOpemj;
				}
			}

			public int customControllerCount
			{
				get
				{
					if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
					{
						ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
						return 0;
					}
					return IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Custom).RkJWsNlHTmrNlRDEKklNpYTEPhDh;
				}
			}

			public IList<CustomController> CustomControllers
			{
				get
				{
					if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
					{
						ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
						return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
					}
					return (IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Custom) as BugNwVeIKhVzIDUOvQkABeSlylki<CustomController, CustomControllerMap>).xMPzVHlWLmYQdGOQbmSeMmfOpemj;
				}
			}

			public IEnumerable<Controller> Controllers
			{
				[IteratorStateMachine(typeof(sizCXKIeWFhmWihbJUxzEUqtdgA))]
				get
				{
					return new sizCXKIeWFhmWihbJUxzEUqtdgA(-2)
					{
						WNTtghwzFJwkBpCSrcPNEYAgrwyKA = this
					};
				}
			}

			public event Action<ControllerAssignmentChangedEventArgs> ControllerAddedEvent
			{
				add
				{
					FCzgnxtefOCfVKONzLkYlWvgBKVY.AddDelegate(value);
				}
				remove
				{
					FCzgnxtefOCfVKONzLkYlWvgBKVY.RemoveDelegate(value);
				}
			}

			public event Action<ControllerAssignmentChangedEventArgs> ControllerRemovedEvent
			{
				add
				{
					xQnEXdVUtrXxNPpcmFECrEoksMBo.AddDelegate(value);
				}
				remove
				{
					xQnEXdVUtrXxNPpcmFECrEoksMBo.RemoveDelegate(value);
				}
			}

			internal ControllerHelper(Player P_0, otOYRXLzSgwvWYlVzCPuFfegHCpP P_1, ControllerMapLayoutManager.oEtaEetdhfQbAaNWSJSoqrbYDmNj P_2, ControllerMapEnabler.oRSewQBaBCPGsFqbLXrIpktlDkb P_3)
			{
				qTfdcxTWyorroOBltCgfHqlllFKdb = ReInput.id;
				tdGjdCGuLAvlseyaulsBSplVuGohA = P_0;
				maps = new MapHelper(P_0, this, P_1, P_2, P_3);
				polling = new PollingHelper(P_0, this);
				conflictChecking = new ConflictCheckingHelper(P_0, this);
				IbydFgCDHfKWDBbtCKTfRwHOHYkn = new NgGecrMhKOkBnKfvwcKnhrEwErRtA(4);
				IbydFgCDHfKWDBbtCKTfRwHOHYkn.wzIflOjNECtRtWMEtoqHKCaIyqPr(0, ControllerType.Joystick, new BugNwVeIKhVzIDUOvQkABeSlylki<Joystick, JoystickMap>());
				IbydFgCDHfKWDBbtCKTfRwHOHYkn.wzIflOjNECtRtWMEtoqHKCaIyqPr(1, ControllerType.Keyboard, new BugNwVeIKhVzIDUOvQkABeSlylki<Keyboard, KeyboardMap>());
				IbydFgCDHfKWDBbtCKTfRwHOHYkn.wzIflOjNECtRtWMEtoqHKCaIyqPr(2, ControllerType.Mouse, new BugNwVeIKhVzIDUOvQkABeSlylki<Mouse, MouseMap>());
				IbydFgCDHfKWDBbtCKTfRwHOHYkn.wzIflOjNECtRtWMEtoqHKCaIyqPr(3, ControllerType.Custom, new BugNwVeIKhVzIDUOvQkABeSlylki<CustomController, CustomControllerMap>());
				pRqOhIQKigQoocBjtcSkXzVEpacG = new MXjbWOahTaUnsydvZFHZuVPKnVfY(P_0);
				OZIWIejsafJflHQQormyeoaJABcC = new fIKoOjsUVwLfLYGsxsHqEoHWjzbJ(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
			}

			public T GetController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
				{
					ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					return null;
				}
				return (T)IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.SnWpeORragsqurEXzaGiBBEonYcy<T>()).LcbdObQweMOzvtgfAlLZhYKcFOOx(controllerId);
			}

			public Controller GetController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
				{
					ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					return null;
				}
				return IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType).LcbdObQweMOzvtgfAlLZhYKcFOOx(controllerId);
			}

			public T GetControllerWithTag<T>(string tag) where T : Controller
			{
				if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
				{
					ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					return null;
				}
				return (T)IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.SnWpeORragsqurEXzaGiBBEonYcy<T>()).WdqAVQEwSPpsdOjbRVGLNSOcKcqS(tag);
			}

			public Controller GetControllerWithTag(ControllerType controllerType, string tag)
			{
				if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
				{
					ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					return null;
				}
				return IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(controllerType).WdqAVQEwSPpsdOjbRVGLNSOcKcqS(tag);
			}

			public void AddController<T>(int controllerId, bool removeFromOtherPlayers) where T : Controller
			{
				if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
				{
					ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					juZdvzhSEdqyBLqPowqOBVzeuMjF(controllerId, removeFromOtherPlayers);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					AddController(ControllerType.Keyboard, controllerId, removeFromOtherPlayers);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					AddController(ControllerType.Mouse, controllerId, removeFromOtherPlayers);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					UckJDHgqmuctFIKLIeITUvkXVfCk(controllerId, removeFromOtherPlayers);
					return;
				}
				throw new NotImplementedException();
			}

			public void AddController(Controller controller, bool removeFromOtherPlayers)
			{
				if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
				{
					ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
				}
				else if (controller != null)
				{
					switch (controller.type)
					{
					case ControllerType.Joystick:
						FtmabeAAdRObeErBfTKdnIdzpFvcb(controller as Joystick, removeFromOtherPlayers);
						break;
					case ControllerType.Keyboard:
						AddController(controller.type, controller.id, removeFromOtherPlayers);
						break;
					case ControllerType.Mouse:
						AddController(controller.type, controller.id, removeFromOtherPlayers);
						break;
					case ControllerType.Custom:
						AHYhGcLLXfDPhJHdzQkZUnJzyJdr(controller as CustomController, removeFromOtherPlayers);
						break;
					default:
						throw new NotImplementedException();
					}
				}
			}

			public void AddController(ControllerType controllerType, int controllerId, bool removeFromOtherPlayers)
			{
				if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
				{
					ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					FtmabeAAdRObeErBfTKdnIdzpFvcb(ReInput.controllers.GetController(controllerType, controllerId) as Joystick, removeFromOtherPlayers);
					break;
				case ControllerType.Keyboard:
					if (removeFromOtherPlayers)
					{
						ReInput.controllers.RemoveControllerFromAllPlayers(controllerType, controllerId);
					}
					hasKeyboard = true;
					break;
				case ControllerType.Mouse:
					if (removeFromOtherPlayers)
					{
						ReInput.controllers.RemoveControllerFromAllPlayers(controllerType, controllerId);
					}
					hasMouse = true;
					break;
				case ControllerType.Custom:
					AHYhGcLLXfDPhJHdzQkZUnJzyJdr(ReInput.controllers.GetController(controllerType, controllerId) as CustomController, removeFromOtherPlayers);
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void RemoveController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
				{
					ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					HTFXXtWVdrspmlsbCRVZZbvIQtqs(controllerId);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					RemoveController(ControllerType.Keyboard, 0);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					RemoveController(ControllerType.Mouse, 0);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					fJEpPAdGkOFxBxIEPPRrupuLbjnkA(controllerId);
					return;
				}
				throw new NotImplementedException();
			}

			public void RemoveController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
				{
					ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					HTFXXtWVdrspmlsbCRVZZbvIQtqs(controllerId);
					break;
				case ControllerType.Keyboard:
					hasKeyboard = false;
					break;
				case ControllerType.Mouse:
					hasMouse = false;
					break;
				case ControllerType.Custom:
					fJEpPAdGkOFxBxIEPPRrupuLbjnkA(controllerId);
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void RemoveController(Controller controller)
			{
				if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
				{
					ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
				}
				else if (controller != null)
				{
					switch (controller.type)
					{
					case ControllerType.Joystick:
						aHFAMnbjyAowwBukPyjNYSfmLcWh(controller as Joystick);
						break;
					case ControllerType.Keyboard:
						hasKeyboard = false;
						break;
					case ControllerType.Mouse:
						hasMouse = false;
						break;
					case ControllerType.Custom:
						QcaiiuIXYWbOznOWcOallnBYzihwA(controller as CustomController);
						break;
					default:
						throw new NotImplementedException();
					}
				}
			}

			public bool ContainsController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
				{
					ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					return false;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					return ContainsController(ControllerType.Joystick, controllerId);
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					return BUnwASYRryhjaxBuWmrBhHREPzFi;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return xLShTxicuIwFgBuXyMuCkqzTkmNx;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return ContainsController(ControllerType.Custom, controllerId);
				}
				throw new NotImplementedException();
			}

			public bool ContainsController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
				{
					ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					return false;
				}
				return controllerType switch
				{
					ControllerType.Joystick => IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Joystick).wDYbJNEdgGiSlUtXLVsemvtiInIn(controllerId), 
					ControllerType.Keyboard => BUnwASYRryhjaxBuWmrBhHREPzFi, 
					ControllerType.Mouse => xLShTxicuIwFgBuXyMuCkqzTkmNx, 
					ControllerType.Custom => IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Custom).wDYbJNEdgGiSlUtXLVsemvtiInIn(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public bool ContainsController(Controller controller)
			{
				if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
				{
					ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					return false;
				}
				if (controller == null)
				{
					return false;
				}
				return ContainsController(controller.type, controller.id);
			}

			public void ClearControllersOfType<T>() where T : Controller
			{
				if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
				{
					ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					lFZTpfXruzZTldNPHLkixzSjgAEw();
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					hasKeyboard = false;
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					hasMouse = false;
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					YRZgJhTVLRyOwCsLnvxHPvbCgcqW();
					return;
				}
				if ((object)typeFromHandle == typeof(Controller))
				{
					ClearAllControllers();
					return;
				}
				throw new NotImplementedException();
			}

			public void ClearControllersOfType(ControllerType controllerType)
			{
				if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
				{
					ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					lFZTpfXruzZTldNPHLkixzSjgAEw();
					break;
				case ControllerType.Keyboard:
					hasKeyboard = false;
					break;
				case ControllerType.Mouse:
					hasMouse = false;
					break;
				case ControllerType.Custom:
					YRZgJhTVLRyOwCsLnvxHPvbCgcqW();
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void ClearAllControllers()
			{
				if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
				{
					ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					return;
				}
				lFZTpfXruzZTldNPHLkixzSjgAEw();
				YRZgJhTVLRyOwCsLnvxHPvbCgcqW();
				hasMouse = false;
				hasKeyboard = false;
			}

			public Controller GetLastActiveController()
			{
				if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
				{
					ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					return null;
				}
				Controller result = null;
				double num = 0.0;
				JuCzjcDaMxvHvUgjiPrphHrkBIPiA(ControllerType.Joystick, ref result, ref num);
				if (xLShTxicuIwFgBuXyMuCkqzTkmNx && ODjAeaMUwkvlDKQdYRbrqssWtARf > num)
				{
					result = Mouse;
					num = ODjAeaMUwkvlDKQdYRbrqssWtARf;
				}
				if (BUnwASYRryhjaxBuWmrBhHREPzFi && WccVKUnrSKjLXmhApgCgBkBXIiFlA > num)
				{
					result = Keyboard;
					num = WccVKUnrSKjLXmhApgCgBkBXIiFlA;
				}
				JuCzjcDaMxvHvUgjiPrphHrkBIPiA(ControllerType.Custom, ref result, ref num);
				if (oZIbdrTKSqplcltMwzBuQATFbJVJ >= 0)
				{
					Controller controller = GetController(ezbZTXdkidNDavCOKsWfXInnvoeS, oZIbdrTKSqplcltMwzBuQATFbJVJ);
					if (controller != null && BnjIKvmyVMIUKYMkohciCNNqPJpeA >= num)
					{
						result = controller;
						num = BnjIKvmyVMIUKYMkohciCNNqPJpeA;
					}
				}
				return result;
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
				{
					ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					return null;
				}
				Controller result = null;
				double num = 0.0;
				switch (controllerType)
				{
				case ControllerType.Joystick:
				case ControllerType.Custom:
					JuCzjcDaMxvHvUgjiPrphHrkBIPiA(controllerType, ref result, ref num);
					break;
				case ControllerType.Keyboard:
					if (BUnwASYRryhjaxBuWmrBhHREPzFi && WccVKUnrSKjLXmhApgCgBkBXIiFlA > 0.0)
					{
						result = Keyboard;
					}
					break;
				case ControllerType.Mouse:
					if (xLShTxicuIwFgBuXyMuCkqzTkmNx && ODjAeaMUwkvlDKQdYRbrqssWtARf > 0.0)
					{
						result = Mouse;
					}
					break;
				default:
					throw new NotImplementedException();
				}
				if (oZIbdrTKSqplcltMwzBuQATFbJVJ >= 0 && controllerType == ezbZTXdkidNDavCOKsWfXInnvoeS)
				{
					Controller controller = GetController(ezbZTXdkidNDavCOKsWfXInnvoeS, oZIbdrTKSqplcltMwzBuQATFbJVJ);
					if (controller != null && BnjIKvmyVMIUKYMkohciCNNqPJpeA >= num)
					{
						result = controller;
						num = BnjIKvmyVMIUKYMkohciCNNqPJpeA;
					}
				}
				return result;
			}

			public bool SetLastActiveController(Controller controller)
			{
				if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
				{
					ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					return false;
				}
				if (controller == null)
				{
					return false;
				}
				if (!ContainsController(controller))
				{
					return false;
				}
				oZIbdrTKSqplcltMwzBuQATFbJVJ = controller.id;
				ezbZTXdkidNDavCOKsWfXInnvoeS = controller.type;
				BnjIKvmyVMIUKYMkohciCNNqPJpeA = ReInput.unscaledTime;
				return true;
			}

			private void JuCzjcDaMxvHvUgjiPrphHrkBIPiA(ControllerType P_0, ref Controller P_1, ref double P_2)
			{
				FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
				int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh;
				for (int i = 0; i < num; i++)
				{
					double num2 = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).oEAAsWXyTImdfNewNOlMQToOqqnd;
					if (!(num2 <= P_2))
					{
						P_1 = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(i).zrbrkQliupAqJogtCsiVGfsiiisW;
						P_2 = num2;
					}
				}
			}

			public Controller GetLastActiveController<T>() where T : Controller
			{
				return GetLastActiveController(GHPcAvLGyrhUIIuLWeQoyFTYgunBA.SnWpeORragsqurEXzaGiBBEonYcy<T>());
			}

			public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
					{
						ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					}
					else
					{
						tdGjdCGuLAvlseyaulsBSplVuGohA.bEDLzXIxpNJGCtcHNVEXWnpWvKtD.kItNvsztfCLiCwKpEaQlrGrvCqET(tdGjdCGuLAvlseyaulsBSplVuGohA.CbVfyyZWPLaMXAAoIrIHBSMHYdnm, callback);
					}
				}
			}

			public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
					{
						ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					}
					else
					{
						tdGjdCGuLAvlseyaulsBSplVuGohA.bEDLzXIxpNJGCtcHNVEXWnpWvKtD.HCWzIyYxjAPfJxGJceitFyBWkGUT(tdGjdCGuLAvlseyaulsBSplVuGohA.CbVfyyZWPLaMXAAoIrIHBSMHYdnm, callback, controllerType);
					}
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
					{
						ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					}
					else
					{
						tdGjdCGuLAvlseyaulsBSplVuGohA.bEDLzXIxpNJGCtcHNVEXWnpWvKtD.xxwvPwFhmkkYRmXmWJpCfIFRCwvp(tdGjdCGuLAvlseyaulsBSplVuGohA.CbVfyyZWPLaMXAAoIrIHBSMHYdnm, callback);
					}
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
					{
						ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					}
					else
					{
						tdGjdCGuLAvlseyaulsBSplVuGohA.bEDLzXIxpNJGCtcHNVEXWnpWvKtD.vypSSlmVDFnXkzySpdHqTFAkhfHC(tdGjdCGuLAvlseyaulsBSplVuGohA.CbVfyyZWPLaMXAAoIrIHBSMHYdnm, callback, controllerType);
					}
				}
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
					{
						ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					}
					else
					{
						tdGjdCGuLAvlseyaulsBSplVuGohA.bEDLzXIxpNJGCtcHNVEXWnpWvKtD.umhjZkCLWUHNEAduNFudIlIwMITb(tdGjdCGuLAvlseyaulsBSplVuGohA.CbVfyyZWPLaMXAAoIrIHBSMHYdnm);
					}
				}
			}

			public Controller GetFirstControllerWithTemplate(Guid templateTypeGuid)
			{
				if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
				{
					ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					return null;
				}
				int eWwWlDdWcqJQmgAiLeFBWdVumGMb = IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb;
				for (int i = 0; i < eWwWlDdWcqJQmgAiLeFBWdVumGMb; i++)
				{
					Controller controller = RukclnLeeVpjnSftnCISeCKYUFQDA(IbydFgCDHfKWDBbtCKTfRwHOHYkn.YPeyRKgKWPSqEsMokJyVccifhDpb(i).mbfHDcGTnKKwgQEZclBXulCaqXzkA, Controller.jZUOBFvBIMVRtLTJXmRUKUzOItjN, templateTypeGuid);
					if (controller != null)
					{
						return controller;
					}
				}
				return null;
			}

			public Controller GetFirstControllerWithTemplate(Type templateType)
			{
				if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
				{
					ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					return null;
				}
				int eWwWlDdWcqJQmgAiLeFBWdVumGMb = IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb;
				for (int i = 0; i < eWwWlDdWcqJQmgAiLeFBWdVumGMb; i++)
				{
					Controller controller = RukclnLeeVpjnSftnCISeCKYUFQDA(IbydFgCDHfKWDBbtCKTfRwHOHYkn.YPeyRKgKWPSqEsMokJyVccifhDpb(i).mbfHDcGTnKKwgQEZclBXulCaqXzkA, Controller.AuGsDAmpqetvxCgGqHfuTNlLHQWcA, templateType);
					if (controller != null)
					{
						return controller;
					}
				}
				return null;
			}

			public Controller GetFirstControllerWithTemplate<T>() where T : class
			{
				return GetFirstControllerWithTemplate(typeof(T));
			}

			public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
			{
				if (ReInput._id != qTfdcxTWyorroOBltCgfHqlllFKdb)
				{
					ReInput.CheckInitialized(qTfdcxTWyorroOBltCgfHqlllFKdb);
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return OZIWIejsafJflHQQormyeoaJABcC.pUbgQJGJJLcmIloEyGrUBDcSjNAY<TInterface>();
			}

			private Controller RukclnLeeVpjnSftnCISeCKYUFQDA<_0001>(ControllerType P_0, Func<Controller, _0001, bool> P_1, _0001 P_2)
			{
				switch (P_0)
				{
				case ControllerType.Joystick:
				{
					int num2 = joystickCount;
					IList<Joystick> joysticks = Joysticks;
					for (int j = 0; j < num2; j++)
					{
						if (P_1(joysticks[j], P_2))
						{
							return joysticks[j];
						}
					}
					return null;
				}
				case ControllerType.Keyboard:
					if (BUnwASYRryhjaxBuWmrBhHREPzFi && P_1(Keyboard, P_2))
					{
						return Keyboard;
					}
					return null;
				case ControllerType.Mouse:
					if (xLShTxicuIwFgBuXyMuCkqzTkmNx && P_1(Mouse, P_2))
					{
						return Mouse;
					}
					return null;
				case ControllerType.Custom:
				{
					int num = customControllerCount;
					IList<CustomController> customControllers = CustomControllers;
					for (int i = 0; i < num; i++)
					{
						if (P_1(customControllers[i], P_2))
						{
							return customControllers[i];
						}
					}
					return null;
				}
				default:
					throw new NotImplementedException();
				}
			}

			internal void aNemEsLTmjfyzpbpdsSkgbyDSlGv()
			{
				for (int i = 0; i < IbydFgCDHfKWDBbtCKTfRwHOHYkn.EWwWlDdWcqJQmgAiLeFBWdVumGMb; i++)
				{
					IbydFgCDHfKWDBbtCKTfRwHOHYkn.YPeyRKgKWPSqEsMokJyVccifhDpb(i).SUZiPCaLTTKwDqgQsUcDNKprsUQB();
				}
				IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Keyboard).yjcdZxDsJoGYywkOEcTxeUbsRGdLA(new BugNwVeIKhVzIDUOvQkABeSlylki<Keyboard, KeyboardMap>.QZjxExmeBWRuJGYTHbiqqUqGIllt(ReInput.jFidDAJTYMYSSrBGXbdjHWSiLLLfB.dqlVbgwiwbhfyZlhzyrqssSByBAe, new global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<KeyboardMap>(0)));
				IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Mouse).yjcdZxDsJoGYywkOEcTxeUbsRGdLA(new BugNwVeIKhVzIDUOvQkABeSlylki<Mouse, MouseMap>.QZjxExmeBWRuJGYTHbiqqUqGIllt(ReInput.jFidDAJTYMYSSrBGXbdjHWSiLLLfB.tAQmtNcIHgKfFSRzKoZtyWPabvG, new global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<MouseMap>(0)));
				pRqOhIQKigQoocBjtcSkXzVEpacG.qhQBUNfBHvqmTHVNUKHWpFvQhGMDb();
				WccVKUnrSKjLXmhApgCgBkBXIiFlA = 0.0;
				ODjAeaMUwkvlDKQdYRbrqssWtARf = 0.0;
				maps.bTqVxrcNUNIlflNpQbltIgBQaJiZA();
			}

			internal double GHaZGerwcIHFwzTTUjcUdQzRhkXj(int P_0)
			{
				return pRqOhIQKigQoocBjtcSkXzVEpacG.vdMYiqdQrjusRyVLELfGGDftLHdp(P_0)?.AxTAnxEQvRPkzjeGKjMYlJyBEGmvB ?? (-1.0);
			}

			internal void FtmabeAAdRObeErBfTKdnIdzpFvcb(Joystick P_0, bool P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Joystick);
				if (fcTbzUBLOriYHtrisAslcxMVjwzbA.wDYbJNEdgGiSlUtXLVsemvtiInIn(P_0.id))
				{
					return;
				}
				if (P_1)
				{
					ReInput.controllers.RemoveJoystickFromAllPlayers(P_0);
				}
				MXjbWOahTaUnsydvZFHZuVPKnVfY.eraNxtfKkmuEkUJzwpIOdRgDJgEv eraNxtfKkmuEkUJzwpIOdRgDJgEv = pRqOhIQKigQoocBjtcSkXzVEpacG.vdMYiqdQrjusRyVLELfGGDftLHdp(P_0.id);
				BugNwVeIKhVzIDUOvQkABeSlylki<Joystick, JoystickMap>.QZjxExmeBWRuJGYTHbiqqUqGIllt qZjxExmeBWRuJGYTHbiqqUqGIllt;
				if (eraNxtfKkmuEkUJzwpIOdRgDJgEv != null && eraNxtfKkmuEkUJzwpIOdRgDJgEv.tffAjZGjLYRcEzyFuVdRAndjKqRQ != null)
				{
					qZjxExmeBWRuJGYTHbiqqUqGIllt = new BugNwVeIKhVzIDUOvQkABeSlylki<Joystick, JoystickMap>.QZjxExmeBWRuJGYTHbiqqUqGIllt(P_0, eraNxtfKkmuEkUJzwpIOdRgDJgEv.tffAjZGjLYRcEzyFuVdRAndjKqRQ);
				}
				else
				{
					global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<JoystickMap> fwhFsFHQpVSqhlnVxqzYARYfqIXqb2 = maps.rxCnIuiCdugeBhxBbXVaMZpPlXcPA(P_0, true);
					if (fwhFsFHQpVSqhlnVxqzYARYfqIXqb2 == null)
					{
						fwhFsFHQpVSqhlnVxqzYARYfqIXqb2 = new global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<JoystickMap>(P_0.id);
					}
					qZjxExmeBWRuJGYTHbiqqUqGIllt = new BugNwVeIKhVzIDUOvQkABeSlylki<Joystick, JoystickMap>.QZjxExmeBWRuJGYTHbiqqUqGIllt(P_0, fwhFsFHQpVSqhlnVxqzYARYfqIXqb2);
				}
				fcTbzUBLOriYHtrisAslcxMVjwzbA.yjcdZxDsJoGYywkOEcTxeUbsRGdLA(qZjxExmeBWRuJGYTHbiqqUqGIllt);
				pRqOhIQKigQoocBjtcSkXzVEpacG.ubabJkSidYKCyvvsdtISFejQjgYh(qZjxExmeBWRuJGYTHbiqqUqGIllt);
				OZIWIejsafJflHQQormyeoaJABcC.LPYvDZQlHJmSBLNPWIwEIpLEAtRv(P_0);
				maps.layoutManager.Apply();
				if (FCzgnxtefOCfVKONzLkYlWvgBKVY.Count > 0)
				{
					FCzgnxtefOCfVKONzLkYlWvgBKVY.Invoke(new ControllerAssignmentChangedEventArgs(tdGjdCGuLAvlseyaulsBSplVuGohA.id, P_0.id, ControllerType.Joystick, true));
				}
			}

			internal void juZdvzhSEdqyBLqPowqOBVzeuMjF(int P_0, bool P_1)
			{
				Joystick joystick = ReInput.controllers.GetJoystick(P_0);
				if (joystick != null)
				{
					FtmabeAAdRObeErBfTKdnIdzpFvcb(joystick, P_1);
				}
			}

			internal void HTFXXtWVdrspmlsbCRVZZbvIQtqs(int P_0)
			{
				FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Joystick);
				if (fcTbzUBLOriYHtrisAslcxMVjwzbA.wDYbJNEdgGiSlUtXLVsemvtiInIn(P_0))
				{
					if (fcTbzUBLOriYHtrisAslcxMVjwzbA.YacHzxfeOlVQUomSEcSTDHYQttOQA(P_0) is BugNwVeIKhVzIDUOvQkABeSlylki<Joystick, JoystickMap>.QZjxExmeBWRuJGYTHbiqqUqGIllt qZjxExmeBWRuJGYTHbiqqUqGIllt)
					{
						pRqOhIQKigQoocBjtcSkXzVEpacG.ubabJkSidYKCyvvsdtISFejQjgYh(qZjxExmeBWRuJGYTHbiqqUqGIllt);
					}
					fcTbzUBLOriYHtrisAslcxMVjwzbA.NToHCxKAspbjVweMWxbRxHZUYrGm(P_0);
					Joystick joystick = ReInput.controllers.GetJoystick(P_0);
					OZIWIejsafJflHQQormyeoaJABcC.cKhLpzZdxbLRWdRHngLGhLGhgriC(joystick);
					if (xQnEXdVUtrXxNPpcmFECrEoksMBo.Count > 0)
					{
						xQnEXdVUtrXxNPpcmFECrEoksMBo.Invoke(new ControllerAssignmentChangedEventArgs(tdGjdCGuLAvlseyaulsBSplVuGohA.id, joystick.id, ControllerType.Joystick, false));
					}
				}
			}

			internal void aHFAMnbjyAowwBukPyjNYSfmLcWh(Joystick P_0)
			{
				if (P_0 != null)
				{
					HTFXXtWVdrspmlsbCRVZZbvIQtqs(P_0.id);
				}
			}

			internal void lFZTpfXruzZTldNPHLkixzSjgAEw()
			{
				FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Joystick);
				for (int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh - 1; num >= 0; num--)
				{
					pRqOhIQKigQoocBjtcSkXzVEpacG.ubabJkSidYKCyvvsdtISFejQjgYh(fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num) as BugNwVeIKhVzIDUOvQkABeSlylki<Joystick, JoystickMap>.QZjxExmeBWRuJGYTHbiqqUqGIllt);
					OZIWIejsafJflHQQormyeoaJABcC.cKhLpzZdxbLRWdRHngLGhLGhgriC(fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).zrbrkQliupAqJogtCsiVGfsiiisW);
					int id = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).zrbrkQliupAqJogtCsiVGfsiiisW.id;
					fcTbzUBLOriYHtrisAslcxMVjwzbA.uiEBAYIuBvXSDbulMPCgHWCxYYoV(num);
					if (xQnEXdVUtrXxNPpcmFECrEoksMBo.Count > 0)
					{
						xQnEXdVUtrXxNPpcmFECrEoksMBo.Invoke(new ControllerAssignmentChangedEventArgs(tdGjdCGuLAvlseyaulsBSplVuGohA.id, id, ControllerType.Joystick, false));
					}
				}
				fcTbzUBLOriYHtrisAslcxMVjwzbA.SUZiPCaLTTKwDqgQsUcDNKprsUQB();
			}

			internal void AHYhGcLLXfDPhJHdzQkZUnJzyJdr(CustomController P_0, bool P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Custom);
				if (!fcTbzUBLOriYHtrisAslcxMVjwzbA.wDYbJNEdgGiSlUtXLVsemvtiInIn(P_0.id))
				{
					if (P_1)
					{
						ReInput.controllers.RemoveCustomControllerFromAllPlayers(P_0);
					}
					global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<CustomControllerMap> fwhFsFHQpVSqhlnVxqzYARYfqIXqb2 = maps.AipKrlBEYsyOafKCVaFzcbOiuBbGA(P_0, true);
					if (fwhFsFHQpVSqhlnVxqzYARYfqIXqb2 == null)
					{
						fwhFsFHQpVSqhlnVxqzYARYfqIXqb2 = new global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<CustomControllerMap>(P_0.id);
					}
					BugNwVeIKhVzIDUOvQkABeSlylki<CustomController, CustomControllerMap>.QZjxExmeBWRuJGYTHbiqqUqGIllt qZjxExmeBWRuJGYTHbiqqUqGIllt = new BugNwVeIKhVzIDUOvQkABeSlylki<CustomController, CustomControllerMap>.QZjxExmeBWRuJGYTHbiqqUqGIllt(P_0, fwhFsFHQpVSqhlnVxqzYARYfqIXqb2);
					fcTbzUBLOriYHtrisAslcxMVjwzbA.yjcdZxDsJoGYywkOEcTxeUbsRGdLA(qZjxExmeBWRuJGYTHbiqqUqGIllt);
					OZIWIejsafJflHQQormyeoaJABcC.LPYvDZQlHJmSBLNPWIwEIpLEAtRv(P_0);
					maps.layoutManager.Apply();
					if (FCzgnxtefOCfVKONzLkYlWvgBKVY.Count > 0)
					{
						FCzgnxtefOCfVKONzLkYlWvgBKVY.Invoke(new ControllerAssignmentChangedEventArgs(tdGjdCGuLAvlseyaulsBSplVuGohA.id, P_0.id, ControllerType.Custom, true));
					}
				}
			}

			internal void UckJDHgqmuctFIKLIeITUvkXVfCk(int P_0, bool P_1)
			{
				CustomController customController = ReInput.controllers.GetCustomController(P_0);
				if (customController != null)
				{
					AHYhGcLLXfDPhJHdzQkZUnJzyJdr(customController, P_1);
				}
			}

			internal void fJEpPAdGkOFxBxIEPPRrupuLbjnkA(int P_0)
			{
				FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Custom);
				if (fcTbzUBLOriYHtrisAslcxMVjwzbA.wDYbJNEdgGiSlUtXLVsemvtiInIn(P_0))
				{
					fcTbzUBLOriYHtrisAslcxMVjwzbA.YacHzxfeOlVQUomSEcSTDHYQttOQA(P_0);
					fcTbzUBLOriYHtrisAslcxMVjwzbA.NToHCxKAspbjVweMWxbRxHZUYrGm(P_0);
					CustomController customController = ReInput.controllers.GetCustomController(P_0);
					OZIWIejsafJflHQQormyeoaJABcC.cKhLpzZdxbLRWdRHngLGhLGhgriC(customController);
					if (xQnEXdVUtrXxNPpcmFECrEoksMBo.Count > 0)
					{
						xQnEXdVUtrXxNPpcmFECrEoksMBo.Invoke(new ControllerAssignmentChangedEventArgs(tdGjdCGuLAvlseyaulsBSplVuGohA.id, customController.id, ControllerType.Custom, false));
					}
				}
			}

			internal void QcaiiuIXYWbOznOWcOallnBYzihwA(CustomController P_0)
			{
				if (P_0 != null)
				{
					fJEpPAdGkOFxBxIEPPRrupuLbjnkA(P_0.id);
				}
			}

			internal void YRZgJhTVLRyOwCsLnvxHPvbCgcqW()
			{
				FcTbzUBLOriYHtrisAslcxMVjwzbA fcTbzUBLOriYHtrisAslcxMVjwzbA = IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Custom);
				for (int num = fcTbzUBLOriYHtrisAslcxMVjwzbA.RkJWsNlHTmrNlRDEKklNpYTEPhDh - 1; num >= 0; num--)
				{
					OZIWIejsafJflHQQormyeoaJABcC.cKhLpzZdxbLRWdRHngLGhLGhgriC(fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).zrbrkQliupAqJogtCsiVGfsiiisW);
					int id = fcTbzUBLOriYHtrisAslcxMVjwzbA.uZavhtXKHVxiCdRnShETRMwAdKdM(num).zrbrkQliupAqJogtCsiVGfsiiisW.id;
					fcTbzUBLOriYHtrisAslcxMVjwzbA.uiEBAYIuBvXSDbulMPCgHWCxYYoV(num);
					if (xQnEXdVUtrXxNPpcmFECrEoksMBo.Count > 0)
					{
						xQnEXdVUtrXxNPpcmFECrEoksMBo.Invoke(new ControllerAssignmentChangedEventArgs(tdGjdCGuLAvlseyaulsBSplVuGohA.id, id, ControllerType.Custom, false));
					}
				}
				fcTbzUBLOriYHtrisAslcxMVjwzbA.SUZiPCaLTTKwDqgQsUcDNKprsUQB();
			}

			internal CustomController GVWEPCfECWnDrENbGJtgnxIzTRNt(int P_0)
			{
				CustomController customController = tdGjdCGuLAvlseyaulsBSplVuGohA.bEDLzXIxpNJGCtcHNVEXWnpWvKtD.wdCMlfofKsEmCXsYcusWVzNpaPIt(P_0);
				if (customController == null)
				{
					return null;
				}
				AHYhGcLLXfDPhJHdzQkZUnJzyJdr(customController, false);
				return customController;
			}

			internal void PLGyjixFHHBkuOJvmdxVErQHNJye(Action<bool, int, int> P_0)
			{
				bGXqrrefjNOQYUbWYvhLwxbmWqID<Joystick, JoystickMap>(ControllerType.Joystick, P_0);
			}

			internal void ibwEHkGGoEoDdmxeltZwKqrDfsBMA(Keyboard P_0, MOwUUKuNTbUFoXIYrTFqUJUvwxIO P_1, Action<bool, int, int> P_2)
			{
				if (!BUnwASYRryhjaxBuWmrBhHREPzFi || !P_0.enabled)
				{
					return;
				}
				jBYQKkIcQGWHdlisQWWAjEwdDMoA hrHarRljohHLgVtjmovtCGBGMHRv = ULWotIhqUFBdhwlfsIksjyZhzzXLA.hrHarRljohHLgVtjmovtCGBGMHRv;
				bool flag = false;
				PQaFgQVynoEJfalLJXDCcVZTEKyx pQaFgQVynoEJfalLJXDCcVZTEKyx = IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Keyboard).YacHzxfeOlVQUomSEcSTDHYQttOQA(0).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
				int num = pQaFgQVynoEJfalLJXDCcVZTEKyx.IdaghgVqdKwQFNEtDYEijJdcbVHeA;
				KeyCombinationOverrideMode keyCombinationOverrideMode = ReInput.configVars.keyCombinationOverrideMode;
				bool flag2 = keyCombinationOverrideMode == KeyCombinationOverrideMode.None;
				MOwUUKuNTbUFoXIYrTFqUJUvwxIO.pegrKMqWuwkKbVPKmUfNxzVOesxr pegrKMqWuwkKbVPKmUfNxzVOesxr = ((keyCombinationOverrideMode == KeyCombinationOverrideMode.Overlap) ? MOwUUKuNTbUFoXIYrTFqUJUvwxIO.pegrKMqWuwkKbVPKmUfNxzVOesxr.OverlapModifiers : MOwUUKuNTbUFoXIYrTFqUJUvwxIO.pegrKMqWuwkKbVPKmUfNxzVOesxr.Normal);
				uDKoXqSXFZtewSqluDiWfCjusTEj.MkAmdZszAJaeeqjLvEGWKNeYDRxO mkAmdZszAJaeeqjLvEGWKNeYDRxO = new uDKoXqSXFZtewSqluDiWfCjusTEj.MkAmdZszAJaeeqjLvEGWKNeYDRxO
				{
					gIPGDpEAkGlndsbKEBRKzifuRqWPA = ReInput.configVars.generateKeyEventsOnKeyCombinationOverride
				};
				for (int i = 0; i < num; i++)
				{
					KeyboardMap keyboardMap = (KeyboardMap)pQaFgQVynoEJfalLJXDCcVZTEKyx.AZcUeIZqjwMekNcHfENpgGyCRDcAA(i);
					if (!keyboardMap.enabled)
					{
						continue;
					}
					AList<ActionElementMap> aList = keyboardMap.hHYkHiBucOeDZcWyVzqWCcJcDXyr;
					int count = aList._count;
					for (int j = 0; j < count; j++)
					{
						ActionElementMap actionElementMap = aList._items[j];
						if (!actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA)
						{
							continue;
						}
						int actionId = actionElementMap._actionId;
						KeyboardKeyCode keyboardKeyCode = actionElementMap._keyboardKeyCode;
						ModifierKeyFlags modifierKeyFlags = actionElementMap.modifierKeyFlags;
						bool flag3 = false;
						bool flag4;
						if (modifierKeyFlags != ModifierKeyFlags.None)
						{
							ButtonStateFlags buttonStateFlags = (P_0.PdKAJaicAwdctwWcWxcaCpJYUmyK(keyboardKeyCode, modifierKeyFlags) ? ButtonStateFlags.On : ButtonStateFlags.Off);
							flag4 = buttonStateFlags != ButtonStateFlags.Off;
							if (!flag4)
							{
								uDKoXqSXFZtewSqluDiWfCjusTEj uDKoXqSXFZtewSqluDiWfCjusTEj2 = uDKoXqSXFZtewSqluDiWfCjusTEj.VLHuJvQzgCEmDCsqmQeoCEKNYomp(actionElementMap.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc);
								if (uDKoXqSXFZtewSqluDiWfCjusTEj2 != null && uDKoXqSXFZtewSqluDiWfCjusTEj2.VKkpXRIRVAnJYOgLIxoNNDjxsoHK(true) != ButtonStateFlags.Off)
								{
									flag4 = true;
								}
							}
						}
						else
						{
							ButtonStateFlags buttonStateFlags = P_0.TnONrQsOBfOBjJPGMiYehCJcLhfqA(actionElementMap.QCgFyaezumPcbmlbbJQsmzAMuLVpA);
							flag4 = buttonStateFlags != ButtonStateFlags.Off;
						}
						if (flag4 && !flag2 && !P_1.eBdCYvYThhfvEcDgXfiOBfvBgSLBB(keyboardKeyCode, modifierKeyFlags, pegrKMqWuwkKbVPKmUfNxzVOesxr, out flag3))
						{
							P_1.PPWlpFxVisHOWVwRAVpwMycTfoxU(keyboardKeyCode, modifierKeyFlags);
						}
					}
				}
				for (int k = 0; k < num; k++)
				{
					KeyboardMap keyboardMap = (KeyboardMap)pQaFgQVynoEJfalLJXDCcVZTEKyx.AZcUeIZqjwMekNcHfENpgGyCRDcAA(k);
					if (!keyboardMap.enabled)
					{
						continue;
					}
					AList<ActionElementMap> aList = keyboardMap.hHYkHiBucOeDZcWyVzqWCcJcDXyr;
					int count = aList._count;
					for (int j = 0; j < count; j++)
					{
						ActionElementMap actionElementMap = aList._items[j];
						if (!actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA)
						{
							continue;
						}
						int actionId = actionElementMap._actionId;
						KeyboardKeyCode keyboardKeyCode = actionElementMap._keyboardKeyCode;
						ModifierKeyFlags modifierKeyFlags = actionElementMap.modifierKeyFlags;
						bool flag5 = false;
						bool flag3 = false;
						ButtonStateFlags buttonStateFlags;
						bool flag4;
						if (modifierKeyFlags != ModifierKeyFlags.None)
						{
							buttonStateFlags = (P_0.PdKAJaicAwdctwWcWxcaCpJYUmyK(keyboardKeyCode, modifierKeyFlags) ? ButtonStateFlags.On : ButtonStateFlags.Off);
							flag4 = buttonStateFlags != ButtonStateFlags.Off;
							if (!flag4)
							{
								uDKoXqSXFZtewSqluDiWfCjusTEj uDKoXqSXFZtewSqluDiWfCjusTEj2 = uDKoXqSXFZtewSqluDiWfCjusTEj.VLHuJvQzgCEmDCsqmQeoCEKNYomp(actionElementMap.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc);
								if (uDKoXqSXFZtewSqluDiWfCjusTEj2 != null && uDKoXqSXFZtewSqluDiWfCjusTEj2.VKkpXRIRVAnJYOgLIxoNNDjxsoHK(true) != ButtonStateFlags.Off)
								{
									flag4 = true;
								}
							}
						}
						else
						{
							buttonStateFlags = P_0.TnONrQsOBfOBjJPGMiYehCJcLhfqA(actionElementMap.QCgFyaezumPcbmlbbJQsmzAMuLVpA);
							flag4 = buttonStateFlags != ButtonStateFlags.Off;
						}
						if (flag4)
						{
							if (!flag2)
							{
								flag5 = P_1.eBdCYvYThhfvEcDgXfiOBfvBgSLBB(keyboardKeyCode, modifierKeyFlags, pegrKMqWuwkKbVPKmUfNxzVOesxr, out flag3);
							}
							if (flag3 || modifierKeyFlags != ModifierKeyFlags.None)
							{
								mkAmdZszAJaeeqjLvEGWKNeYDRxO.foRaMVKlyBLsIbDkVuGTEjomBNcU = flag5;
								uDKoXqSXFZtewSqluDiWfCjusTEj uDKoXqSXFZtewSqluDiWfCjusTEj2 = uDKoXqSXFZtewSqluDiWfCjusTEj.xyBNkSDsBdBssqCdfkZCzVtBjKNR(actionElementMap.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc, mkAmdZszAJaeeqjLvEGWKNeYDRxO);
								if (keyCombinationOverrideMode == KeyCombinationOverrideMode.Pause)
								{
									uDKoXqSXFZtewSqluDiWfCjusTEj2.UlNfLxjyciuQROdOBntLKLzYzJIQA = flag5;
								}
								else if (flag5)
								{
									uDKoXqSXFZtewSqluDiWfCjusTEj2.UlNfLxjyciuQROdOBntLKLzYzJIQA = true;
								}
								uDKoXqSXFZtewSqluDiWfCjusTEj2.bIPLegpiaGftMsrjrewpGFnjpqiNA(ReInput.currentUpdateLoop, buttonStateFlags, true);
								buttonStateFlags = uDKoXqSXFZtewSqluDiWfCjusTEj2.VKkpXRIRVAnJYOgLIxoNNDjxsoHK(true);
							}
						}
						if (buttonStateFlags != ButtonStateFlags.Off)
						{
							zPpJaBCTbPogeUTPZAfJyUQEJrgq(P_0, keyboardMap, actionElementMap, hrHarRljohHLgVtjmovtCGBGMHRv, buttonStateFlags);
							P_2(arg1: true, tdGjdCGuLAvlseyaulsBSplVuGohA.CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId);
							flag = true;
							continue;
						}
						if (hrHarRljohHLgVtjmovtCGBGMHRv.QiDTfdXIAYDzxFpBlgKIFLrCfQVF != 0f)
						{
							hrHarRljohHLgVtjmovtCGBGMHRv.QiDTfdXIAYDzxFpBlgKIFLrCfQVF = 0f;
						}
						if (hrHarRljohHLgVtjmovtCGBGMHRv.UiDWHofMxZMaMapQCDYKfWnwdPpsA != ButtonStateFlags.Off)
						{
							hrHarRljohHLgVtjmovtCGBGMHRv.UiDWHofMxZMaMapQCDYKfWnwdPpsA = ButtonStateFlags.Off;
						}
						P_2(arg1: false, tdGjdCGuLAvlseyaulsBSplVuGohA.CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId);
					}
				}
				if (flag)
				{
					WccVKUnrSKjLXmhApgCgBkBXIiFlA = ReInput.unscaledTime;
				}
			}

			private static void zPpJaBCTbPogeUTPZAfJyUQEJrgq(Keyboard P_0, ControllerMap P_1, ActionElementMap P_2, jBYQKkIcQGWHdlisQWWAjEwdDMoA P_3, ButtonStateFlags P_4)
			{
				float num = (((P_4 & ButtonStateFlags.On) != ButtonStateFlags.Off) ? 1f : 0f);
				if (num != 0f && P_2._axisContribution == Pole.Negative)
				{
					num *= -1f;
				}
				P_3.QiDTfdXIAYDzxFpBlgKIFLrCfQVF = num;
				P_3.UiDWHofMxZMaMapQCDYKfWnwdPpsA = P_4;
				P_3.TpBOoQzSivUNzspGbKewEnGVHRLe = P_0;
				P_3.nqOwKgOENkJqziSCBBHkfcYzkwTc = ControllerType.Keyboard;
				P_3.ByUqSsndIgvrnFHnQaRSazvSbHKB = ControllerElementType.Button;
				P_3.NXwWJeDJsEeTgxVuxRZIEqgUvrpH = P_2;
				P_3.MxHJLdgRCwJroktYIZkkiehaYKp = P_1;
				if (P_3.VIrFeCXTozbvrGyDLEbJSRwuECNG)
				{
					P_3.VIrFeCXTozbvrGyDLEbJSRwuECNG = false;
				}
				if (P_3.zQmcVmpjcGYAWpnOZjjydhmdoTJs)
				{
					P_3.zQmcVmpjcGYAWpnOZjjydhmdoTJs = false;
				}
			}

			internal void eammjAsuAbKGclDduvqewxJshqQk(Mouse P_0, Action<bool, int, int> P_1)
			{
				if (!xLShTxicuIwFgBuXyMuCkqzTkmNx || !P_0.enabled)
				{
					return;
				}
				PQaFgQVynoEJfalLJXDCcVZTEKyx pQaFgQVynoEJfalLJXDCcVZTEKyx = IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(ControllerType.Mouse).YacHzxfeOlVQUomSEcSTDHYQttOQA(0).ahBHvaaFKqjYqOJIXAFDIKodzptCA;
				jBYQKkIcQGWHdlisQWWAjEwdDMoA hrHarRljohHLgVtjmovtCGBGMHRv = ULWotIhqUFBdhwlfsIksjyZhzzXLA.hrHarRljohHLgVtjmovtCGBGMHRv;
				bool flag = false;
				int num = pQaFgQVynoEJfalLJXDCcVZTEKyx.IdaghgVqdKwQFNEtDYEijJdcbVHeA;
				for (int i = 0; i < num; i++)
				{
					MouseMap mouseMap = (MouseMap)pQaFgQVynoEJfalLJXDCcVZTEKyx.AZcUeIZqjwMekNcHfENpgGyCRDcAA(i);
					if (!mouseMap.enabled)
					{
						continue;
					}
					AList<ActionElementMap> aList = mouseMap.VIwCRfOqTkHNlTBczwmjQPsfbVkv;
					if (aList != null)
					{
						int count = aList._count;
						for (int j = 0; j < count; j++)
						{
							ActionElementMap actionElementMap = aList._items[j];
							if (!actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA || actionElementMap._elementType != ControllerElementType.Axis)
							{
								continue;
							}
							int actionId = actionElementMap._actionId;
							if (!P_0.PhoMBvolLEbZJWAGyfxxZzSHscGn(actionElementMap, actionId, true, false, out var num2))
							{
								continue;
							}
							if (num2 == 0f)
							{
								P_0.PhoMBvolLEbZJWAGyfxxZzSHscGn(actionElementMap, actionId, true, true, out var num3);
								if (num3 == 0f)
								{
									P_1(arg1: false, tdGjdCGuLAvlseyaulsBSplVuGohA.CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId);
									continue;
								}
							}
							hrHarRljohHLgVtjmovtCGBGMHRv.QiDTfdXIAYDzxFpBlgKIFLrCfQVF = num2;
							hrHarRljohHLgVtjmovtCGBGMHRv.TpBOoQzSivUNzspGbKewEnGVHRLe = P_0;
							hrHarRljohHLgVtjmovtCGBGMHRv.nqOwKgOENkJqziSCBBHkfcYzkwTc = ControllerType.Mouse;
							hrHarRljohHLgVtjmovtCGBGMHRv.ByUqSsndIgvrnFHnQaRSazvSbHKB = ControllerElementType.Axis;
							hrHarRljohHLgVtjmovtCGBGMHRv.NXwWJeDJsEeTgxVuxRZIEqgUvrpH = actionElementMap;
							hrHarRljohHLgVtjmovtCGBGMHRv.MxHJLdgRCwJroktYIZkkiehaYKp = mouseMap;
							if (hrHarRljohHLgVtjmovtCGBGMHRv.zQmcVmpjcGYAWpnOZjjydhmdoTJs)
							{
								hrHarRljohHLgVtjmovtCGBGMHRv.zQmcVmpjcGYAWpnOZjjydhmdoTJs = false;
							}
							if (hrHarRljohHLgVtjmovtCGBGMHRv.XGBcktPliZcVUKHCMFlsrPgryiMo != AxisCoordinateMode.Relative)
							{
								hrHarRljohHLgVtjmovtCGBGMHRv.XGBcktPliZcVUKHCMFlsrPgryiMo = AxisCoordinateMode.Relative;
							}
							P_1(arg1: true, tdGjdCGuLAvlseyaulsBSplVuGohA.CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId);
							flag = true;
						}
					}
					AList<ActionElementMap> aList2 = mouseMap.hHYkHiBucOeDZcWyVzqWCcJcDXyr;
					if (aList2 == null)
					{
						continue;
					}
					int count2 = aList2._count;
					for (int k = 0; k < count2; k++)
					{
						ActionElementMap actionElementMap2 = aList2._items[k];
						if (!actionElementMap2.KDuOcDwQLQHhwDRrYdOMFXnFZITxA || actionElementMap2._elementType != ControllerElementType.Button)
						{
							continue;
						}
						int actionId2 = actionElementMap2._actionId;
						if (!P_0.dAxaRiAAocDAlfxZGDsyWKSLbPxA(actionElementMap2, actionId2, out var qiDTfdXIAYDzxFpBlgKIFLrCfQVF, out hrHarRljohHLgVtjmovtCGBGMHRv.VIrFeCXTozbvrGyDLEbJSRwuECNG))
						{
							continue;
						}
						ButtonStateFlags buttonStateFlags = P_0.TnONrQsOBfOBjJPGMiYehCJcLhfqA(actionElementMap2.QCgFyaezumPcbmlbbJQsmzAMuLVpA);
						if (buttonStateFlags == ButtonStateFlags.Off)
						{
							P_1(arg1: false, tdGjdCGuLAvlseyaulsBSplVuGohA.CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId2);
							continue;
						}
						hrHarRljohHLgVtjmovtCGBGMHRv.QiDTfdXIAYDzxFpBlgKIFLrCfQVF = qiDTfdXIAYDzxFpBlgKIFLrCfQVF;
						hrHarRljohHLgVtjmovtCGBGMHRv.UiDWHofMxZMaMapQCDYKfWnwdPpsA = buttonStateFlags;
						hrHarRljohHLgVtjmovtCGBGMHRv.TpBOoQzSivUNzspGbKewEnGVHRLe = P_0;
						hrHarRljohHLgVtjmovtCGBGMHRv.nqOwKgOENkJqziSCBBHkfcYzkwTc = ControllerType.Mouse;
						hrHarRljohHLgVtjmovtCGBGMHRv.ByUqSsndIgvrnFHnQaRSazvSbHKB = ControllerElementType.Button;
						hrHarRljohHLgVtjmovtCGBGMHRv.NXwWJeDJsEeTgxVuxRZIEqgUvrpH = actionElementMap2;
						hrHarRljohHLgVtjmovtCGBGMHRv.MxHJLdgRCwJroktYIZkkiehaYKp = mouseMap;
						if (hrHarRljohHLgVtjmovtCGBGMHRv.VIrFeCXTozbvrGyDLEbJSRwuECNG)
						{
							hrHarRljohHLgVtjmovtCGBGMHRv.VIrFeCXTozbvrGyDLEbJSRwuECNG = false;
						}
						if (hrHarRljohHLgVtjmovtCGBGMHRv.zQmcVmpjcGYAWpnOZjjydhmdoTJs)
						{
							hrHarRljohHLgVtjmovtCGBGMHRv.zQmcVmpjcGYAWpnOZjjydhmdoTJs = false;
						}
						P_1(arg1: true, tdGjdCGuLAvlseyaulsBSplVuGohA.CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId2);
						flag = true;
					}
				}
				if (flag)
				{
					ODjAeaMUwkvlDKQdYRbrqssWtARf = ReInput.unscaledTime;
				}
			}

			internal void epeWeAWEMmperuTmgoNPDoUhOxSv(Action<bool, int, int> P_0)
			{
				bGXqrrefjNOQYUbWYvhLwxbmWqID<CustomController, CustomControllerMap>(ControllerType.Custom, P_0);
			}

			private void bGXqrrefjNOQYUbWYvhLwxbmWqID<_0001, _0002>(ControllerType P_0, Action<bool, int, int> P_1) where _0001 : ControllerWithAxes where _0002 : ControllerMapWithAxes
			{
				BugNwVeIKhVzIDUOvQkABeSlylki<_0001, _0002> bugNwVeIKhVzIDUOvQkABeSlylki = (BugNwVeIKhVzIDUOvQkABeSlylki<_0001, _0002>)IbydFgCDHfKWDBbtCKTfRwHOHYkn.KoTRkfiyMGtUlrssiEcDBZwRQgTs(P_0);
				jBYQKkIcQGWHdlisQWWAjEwdDMoA hrHarRljohHLgVtjmovtCGBGMHRv = ULWotIhqUFBdhwlfsIksjyZhzzXLA.hrHarRljohHLgVtjmovtCGBGMHRv;
				int num = bugNwVeIKhVzIDUOvQkABeSlylki.tXrSkfcScZdadhIEmSRyjQoYKHYaA();
				for (int i = 0; i < num; i++)
				{
					BugNwVeIKhVzIDUOvQkABeSlylki<_0001, _0002>.QZjxExmeBWRuJGYTHbiqqUqGIllt qZjxExmeBWRuJGYTHbiqqUqGIllt = bugNwVeIKhVzIDUOvQkABeSlylki.EkvJMuoBUqPuwIhirjBTLBhzCiTG(i);
					_0001 jShzJcgXohXkJgAjbKdTzokqckTE = qZjxExmeBWRuJGYTHbiqqUqGIllt.jShzJcgXohXkJgAjbKdTzokqckTE;
					if (!jShzJcgXohXkJgAjbKdTzokqckTE.enabled)
					{
						continue;
					}
					global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0002> oNEqVoyniAQxhPXQGcMENGIkPfMg = qZjxExmeBWRuJGYTHbiqqUqGIllt.oNEqVoyniAQxhPXQGcMENGIkPfMg;
					bool flag = false;
					int num2 = oNEqVoyniAQxhPXQGcMENGIkPfMg.uwAUgkekzffIxggNtXkaazjLDUnI();
					for (int j = 0; j < num2; j++)
					{
						_0002 val = oNEqVoyniAQxhPXQGcMENGIkPfMg.dqSBzdtORLozVFHTanNDwzTffYco(j);
						if (!val.enabled)
						{
							continue;
						}
						AList<ActionElementMap> aList = val.VIwCRfOqTkHNlTBczwmjQPsfbVkv;
						if (aList != null)
						{
							int count = aList._count;
							for (int k = 0; k < count; k++)
							{
								ActionElementMap actionElementMap = aList._items[k];
								if (!actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA || actionElementMap._elementType != ControllerElementType.Axis)
								{
									continue;
								}
								int actionId = actionElementMap._actionId;
								if (!jShzJcgXohXkJgAjbKdTzokqckTE.PhoMBvolLEbZJWAGyfxxZzSHscGn(actionElementMap, actionId, false, false, out var num3))
								{
									continue;
								}
								if (num3 == 0f)
								{
									jShzJcgXohXkJgAjbKdTzokqckTE.PhoMBvolLEbZJWAGyfxxZzSHscGn(actionElementMap, actionId, false, true, out var num4);
									if (num4 == 0f)
									{
										P_1(arg1: false, tdGjdCGuLAvlseyaulsBSplVuGohA.CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId);
										continue;
									}
								}
								hrHarRljohHLgVtjmovtCGBGMHRv.QiDTfdXIAYDzxFpBlgKIFLrCfQVF = num3;
								hrHarRljohHLgVtjmovtCGBGMHRv.TpBOoQzSivUNzspGbKewEnGVHRLe = jShzJcgXohXkJgAjbKdTzokqckTE;
								hrHarRljohHLgVtjmovtCGBGMHRv.nqOwKgOENkJqziSCBBHkfcYzkwTc = P_0;
								hrHarRljohHLgVtjmovtCGBGMHRv.ByUqSsndIgvrnFHnQaRSazvSbHKB = ControllerElementType.Axis;
								hrHarRljohHLgVtjmovtCGBGMHRv.NXwWJeDJsEeTgxVuxRZIEqgUvrpH = actionElementMap;
								hrHarRljohHLgVtjmovtCGBGMHRv.MxHJLdgRCwJroktYIZkkiehaYKp = val;
								hrHarRljohHLgVtjmovtCGBGMHRv.zQmcVmpjcGYAWpnOZjjydhmdoTJs = jShzJcgXohXkJgAjbKdTzokqckTE.calibrationMap.Axes[actionElementMap.QCgFyaezumPcbmlbbJQsmzAMuLVpA].applyRangeCalibration;
								hrHarRljohHLgVtjmovtCGBGMHRv.XGBcktPliZcVUKHCMFlsrPgryiMo = jShzJcgXohXkJgAjbKdTzokqckTE.Axes[actionElementMap.elementIndex].VjHSioMESUvcoZNTLZGzLmnuVlxf?._dataFormat ?? AxisCoordinateMode.Absolute;
								P_1(arg1: true, tdGjdCGuLAvlseyaulsBSplVuGohA.CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId);
								flag = true;
							}
						}
						AList<ActionElementMap> aList2 = val.hHYkHiBucOeDZcWyVzqWCcJcDXyr;
						if (aList2 != null)
						{
							int count2 = aList2._count;
							for (int l = 0; l < count2; l++)
							{
								ActionElementMap actionElementMap2 = aList2._items[l];
								if (!actionElementMap2.KDuOcDwQLQHhwDRrYdOMFXnFZITxA || actionElementMap2._elementType != ControllerElementType.Button)
								{
									continue;
								}
								int actionId2 = actionElementMap2._actionId;
								float qiDTfdXIAYDzxFpBlgKIFLrCfQVF = 0f;
								int qCgFyaezumPcbmlbbJQsmzAMuLVpA = actionElementMap2.QCgFyaezumPcbmlbbJQsmzAMuLVpA;
								if (!DKpvMXRxgnNUMbechiHVUsIhfjxg(jShzJcgXohXkJgAjbKdTzokqckTE, i, qCgFyaezumPcbmlbbJQsmzAMuLVpA, actionElementMap2, oNEqVoyniAQxhPXQGcMENGIkPfMg, actionId2, ref qiDTfdXIAYDzxFpBlgKIFLrCfQVF) && !jShzJcgXohXkJgAjbKdTzokqckTE.dAxaRiAAocDAlfxZGDsyWKSLbPxA(actionElementMap2, actionId2, out qiDTfdXIAYDzxFpBlgKIFLrCfQVF, out hrHarRljohHLgVtjmovtCGBGMHRv.VIrFeCXTozbvrGyDLEbJSRwuECNG))
								{
									continue;
								}
								ButtonStateFlags buttonStateFlags = jShzJcgXohXkJgAjbKdTzokqckTE.TnONrQsOBfOBjJPGMiYehCJcLhfqA(actionElementMap2.QCgFyaezumPcbmlbbJQsmzAMuLVpA);
								if (buttonStateFlags == ButtonStateFlags.Off)
								{
									P_1(arg1: false, tdGjdCGuLAvlseyaulsBSplVuGohA.CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId2);
									continue;
								}
								hrHarRljohHLgVtjmovtCGBGMHRv.QiDTfdXIAYDzxFpBlgKIFLrCfQVF = qiDTfdXIAYDzxFpBlgKIFLrCfQVF;
								hrHarRljohHLgVtjmovtCGBGMHRv.UiDWHofMxZMaMapQCDYKfWnwdPpsA = buttonStateFlags;
								hrHarRljohHLgVtjmovtCGBGMHRv.TpBOoQzSivUNzspGbKewEnGVHRLe = jShzJcgXohXkJgAjbKdTzokqckTE;
								hrHarRljohHLgVtjmovtCGBGMHRv.nqOwKgOENkJqziSCBBHkfcYzkwTc = P_0;
								hrHarRljohHLgVtjmovtCGBGMHRv.ByUqSsndIgvrnFHnQaRSazvSbHKB = ControllerElementType.Button;
								hrHarRljohHLgVtjmovtCGBGMHRv.NXwWJeDJsEeTgxVuxRZIEqgUvrpH = actionElementMap2;
								hrHarRljohHLgVtjmovtCGBGMHRv.MxHJLdgRCwJroktYIZkkiehaYKp = val;
								if (hrHarRljohHLgVtjmovtCGBGMHRv.zQmcVmpjcGYAWpnOZjjydhmdoTJs)
								{
									hrHarRljohHLgVtjmovtCGBGMHRv.zQmcVmpjcGYAWpnOZjjydhmdoTJs = false;
								}
								P_1(arg1: true, tdGjdCGuLAvlseyaulsBSplVuGohA.CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId2);
								flag = true;
							}
						}
						if (flag)
						{
							qZjxExmeBWRuJGYTHbiqqUqGIllt.QpqLMCANEqkpFoWzTArgxdzSKocd();
						}
					}
				}
			}

			private bool DKpvMXRxgnNUMbechiHVUsIhfjxg<_0001>(ControllerWithAxes P_0, int P_1, int P_2, ActionElementMap P_3, global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0001> P_4, int P_5, ref float P_6) where _0001 : ControllerMapWithAxes
			{
				if (!P_0.ONcPOmEPPyOeIZfvFoSEEYgzfzdq.IsUnknownHatCardinal(P_2))
				{
					return false;
				}
				UnknownControllerHat.HatButtons unknownHatButtons = P_0.ONcPOmEPPyOeIZfvFoSEEYgzfzdq.GetUnknownHatButtons(P_2);
				if (bwGJUKHUXYXTELckbrFrECnjhbRB(unknownHatButtons, P_1, P_4))
				{
					unknownHatButtons.GetNeighbors(P_2, out var neighbor, out var neighbor2);
					if (P_0.GetButton(neighbor) || P_0.GetButton(neighbor2))
					{
						if (!P_0.FlTlruFcIfzQAHqgsXlUuWRqAJzc(P_3, P_5, true, out P_6))
						{
							return false;
						}
						return true;
					}
				}
				return false;
			}

			private bool bwGJUKHUXYXTELckbrFrECnjhbRB<_0001>(UnknownControllerHat.HatButtons P_0, int P_1, global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0001> P_2) where _0001 : ControllerMapWithAxes
			{
				if (P_0 == null)
				{
					return false;
				}
				if (ReInput.configVars.force4WayHats)
				{
					return true;
				}
				if (VVTcunAEbHHqzHQtlrDbldrqhFMRA(P_0, P_1, P_2))
				{
					return false;
				}
				return true;
			}

			private bool VVTcunAEbHHqzHQtlrDbldrqhFMRA<_0001>(UnknownControllerHat.HatButtons P_0, int P_1, global::fwhFsFHQpVSqhlnVxqzYARYfqIXqb<_0001> P_2) where _0001 : ControllerMapWithAxes
			{
				if (P_2 == null)
				{
					return false;
				}
				int num = P_2.uwAUgkekzffIxggNtXkaazjLDUnI();
				for (int i = 0; i < num; i++)
				{
					IList<ActionElementMap> buttonMaps = P_2.dqSBzdtORLozVFHTanNDwzTffYco(i).ButtonMaps;
					if (buttonMaps == null)
					{
						continue;
					}
					int count = buttonMaps.Count;
					for (int j = 0; j < count; j++)
					{
						int qCgFyaezumPcbmlbbJQsmzAMuLVpA = buttonMaps[j].QCgFyaezumPcbmlbbJQsmzAMuLVpA;
						if (buttonMaps[j]._actionId >= 0 && P_0.IsCorner(qCgFyaezumPcbmlbbJQsmzAMuLVpA))
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		private const string GszIPMgEIoRdcJGkHOXzdcvzCZOQ = "player";

		private readonly ruLXWgGHNYKBNoYhWlYmLdtbexbY bEDLzXIxpNJGCtcHNVEXWnpWvKtD;

		private bool JaKxIpMeLhEoFhjOAnHtuWjpaHanA;

		private int CbVfyyZWPLaMXAAoIrIHBSMHYdnm;

		private string woLTXxtTsGIsYYCXalGyARpdNOJe;

		private string TDqzlCvsCwxQgliwPpiqIUafbnnE;

		private readonly string vipfkqqQLNwwzgYbkxhMZIobBXwr;

		private bool lKjvibcBriEoVQiRNkqxhvdKOaDf;

		private readonly int qzWGoAnnfStvBiKovJSdtFndfFvV;

		private readonly SPMTiKUCwsRqljCIHClsxjXsIRtS aywjnJYJKTbVnAmyqllElfnCFCNiA;

		private int ziAgHiaEJroWPfCMDNzyRuWODLNjb;

		public readonly ControllerHelper controllers;

		public int id
		{
			get
			{
				if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
				{
					ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
					return -1;
				}
				return CbVfyyZWPLaMXAAoIrIHBSMHYdnm;
			}
			internal set
			{
				CbVfyyZWPLaMXAAoIrIHBSMHYdnm = cbVfyyZWPLaMXAAoIrIHBSMHYdnm;
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
				{
					ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
					return string.Empty;
				}
				return woLTXxtTsGIsYYCXalGyARpdNOJe;
			}
			internal set
			{
				woLTXxtTsGIsYYCXalGyARpdNOJe = text;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
				{
					ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
					return string.Empty;
				}
				if (!LocalizationManager.isEnabled)
				{
					return TDqzlCvsCwxQgliwPpiqIUafbnnE;
				}
				return aywjnJYJKTbVnAmyqllElfnCFCNiA.aWxJJrCnpmeqmclTDPTQjepbcypsA;
			}
			internal set
			{
				nonLocalizedDescriptiveName = text;
			}
		}

		public bool isPlaying
		{
			get
			{
				if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
				{
					ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
					return false;
				}
				return lKjvibcBriEoVQiRNkqxhvdKOaDf;
			}
			set
			{
				lKjvibcBriEoVQiRNkqxhvdKOaDf = value;
			}
		}

		internal string nonLocalizedDescriptiveName
		{
			get
			{
				return TDqzlCvsCwxQgliwPpiqIUafbnnE;
			}
			set
			{
				TDqzlCvsCwxQgliwPpiqIUafbnnE = value;
				aywjnJYJKTbVnAmyqllElfnCFCNiA.cwUahnpqwmWpOYgoibmoVeKGCqrw();
			}
		}

		string BMeYXymsuXMDMyjfaaClzmryYLZG.keyCategory => "player";

		string BMeYXymsuXMDMyjfaaClzmryYLZG.scriptingName => woLTXxtTsGIsYYCXalGyARpdNOJe;

		string BMeYXymsuXMDMyjfaaClzmryYLZG.nonLocalizedDescriptiveName
		{
			get
			{
				return TDqzlCvsCwxQgliwPpiqIUafbnnE;
			}
			set
			{
				TDqzlCvsCwxQgliwPpiqIUafbnnE = value;
			}
		}

		string BMeYXymsuXMDMyjfaaClzmryYLZG.key => vipfkqqQLNwwzgYbkxhMZIobBXwr;

		int BMeYXymsuXMDMyjfaaClzmryYLZG.autoGeneratedValueFlags
		{
			get
			{
				return ziAgHiaEJroWPfCMDNzyRuWODLNjb;
			}
			set
			{
				ziAgHiaEJroWPfCMDNzyRuWODLNjb = value;
			}
		}

		internal Player(bool P_0, int P_1, string P_2, string P_3, string P_4, otOYRXLzSgwvWYlVzCPuFfegHCpP P_5, ControllerMapLayoutManager.oEtaEetdhfQbAaNWSJSoqrbYDmNj P_6, ControllerMapEnabler.oRSewQBaBCPGsFqbLXrIpktlDkb P_7)
		{
			JaKxIpMeLhEoFhjOAnHtuWjpaHanA = P_0;
			CbVfyyZWPLaMXAAoIrIHBSMHYdnm = P_1;
			woLTXxtTsGIsYYCXalGyARpdNOJe = P_2;
			TDqzlCvsCwxQgliwPpiqIUafbnnE = P_3;
			vipfkqqQLNwwzgYbkxhMZIobBXwr = P_4;
			qzWGoAnnfStvBiKovJSdtFndfFvV = ReInput.id;
			aywjnJYJKTbVnAmyqllElfnCFCNiA = SPMTiKUCwsRqljCIHClsxjXsIRtS.wSAuMAiJgaVkfzHhKDNRukSwzTCi(this);
			controllers = new ControllerHelper(this, P_5, P_6, P_7);
			bEDLzXIxpNJGCtcHNVEXWnpWvKtD = ReInput.jFidDAJTYMYSSrBGXbdjHWSiLLLfB;
			yEMNQVyObZonGbpuaezOlWvHwtNx();
		}

		public PlayerSaveData GetSaveData(bool userAssignableMapsOnly)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return default(PlayerSaveData);
			}
			return new PlayerSaveData(controllers.maps.GetAllMapSaveData<JoystickMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<KeyboardMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<MouseMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<CustomControllerMapSaveData>(userAssignableMapsOnly), ReInput.mapping.GetInputBehaviors(CbVfyyZWPLaMXAAoIrIHBSMHYdnm));
		}

		public bool GetButton(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.bboVUHBkbaSOWIdiLlywxyMWUUnP() ?? false;
		}

		public bool GetButton(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.bboVUHBkbaSOWIdiLlywxyMWUUnP() ?? false;
		}

		public bool GetButtonDown(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.MVRdnxXGZCsBJEWZdnMOyOTlrrdu() ?? false;
		}

		public bool GetButtonDown(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.MVRdnxXGZCsBJEWZdnMOyOTlrrdu() ?? false;
		}

		public bool GetButtonUp(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.UfRoNrLsJHhqSsAsVeuTJufLfJRFA() ?? false;
		}

		public bool GetButtonUp(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.UfRoNrLsJHhqSsAsVeuTJufLfJRFA() ?? false;
		}

		public bool GetButtonPrev(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.CQCGDxvIRQaxxsKVThUacYtWsqMg() ?? false;
		}

		public bool GetButtonPrev(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.CQCGDxvIRQaxxsKVThUacYtWsqMg() ?? false;
		}

		public bool GetButtonSinglePressHold(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.jDEDYlcVsDKQOgLXoPHwjvssMsLx() ?? false;
		}

		public bool GetButtonSinglePressHold(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.jDEDYlcVsDKQOgLXoPHwjvssMsLx() ?? false;
		}

		public bool GetButtonSinglePressDown(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.lGFalaDqLWAcEovncHQOYVhwYsDh() ?? false;
		}

		public bool GetButtonSinglePressDown(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.lGFalaDqLWAcEovncHQOYVhwYsDh() ?? false;
		}

		public bool GetButtonSinglePressUp(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.tuXKlFxzwhWBmtiDmoXKHFdhhbgy() ?? false;
		}

		public bool GetButtonSinglePressUp(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.tuXKlFxzwhWBmtiDmoXKHFdhhbgy() ?? false;
		}

		public bool GetButtonDoublePressHold(string actionName, float speed)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.ApZadUCrymGHNuAoYDoAgNoCOZeMA(speed) ?? false;
		}

		public bool GetButtonDoublePressHold(int actionId, float speed)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.ApZadUCrymGHNuAoYDoAgNoCOZeMA(speed) ?? false;
		}

		public bool GetButtonDoublePressHold(string actionName)
		{
			return GetButtonDoublePressHold(actionName, 0f);
		}

		public bool GetButtonDoublePressHold(int actionId)
		{
			return GetButtonDoublePressHold(actionId, 0f);
		}

		public bool GetButtonDoublePressDown(string actionName, float speed)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.DJzBbBuISPamiJudWtFJCaoGdPnJ(speed) ?? false;
		}

		public bool GetButtonDoublePressDown(int actionId, float speed)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.DJzBbBuISPamiJudWtFJCaoGdPnJ(speed) ?? false;
		}

		public bool GetButtonDoublePressDown(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return GetButtonDoublePressDown(actionName, 0f);
		}

		public bool GetButtonDoublePressDown(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return GetButtonDoublePressDown(actionId, 0f);
		}

		public bool GetButtonDoublePressUp(string actionName, float speed)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.tpXRjTJLkVEZEdTZpjFKkWSvzIHfA(speed) ?? false;
		}

		public bool GetButtonDoublePressUp(int actionId, float speed)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.tpXRjTJLkVEZEdTZpjFKkWSvzIHfA(speed) ?? false;
		}

		public bool GetButtonDoublePressUp(string actionName)
		{
			return GetButtonDoublePressUp(actionName, 0f);
		}

		public bool GetButtonDoublePressUp(int actionId)
		{
			return GetButtonDoublePressUp(actionId, 0f);
		}

		public bool GetButtonTimedPress(string actionName, float time)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.NaPCjdrIJcSfkZiikNdrmJAwjLAHA(time, 0f) ?? false;
		}

		public bool GetButtonTimedPress(int actionId, float time)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.NaPCjdrIJcSfkZiikNdrmJAwjLAHA(time, 0f) ?? false;
		}

		public bool GetButtonTimedPress(string actionName, float time, float expireIn)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.NaPCjdrIJcSfkZiikNdrmJAwjLAHA(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPress(int actionId, float time, float expireIn)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.NaPCjdrIJcSfkZiikNdrmJAwjLAHA(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPressDown(string actionName, float time)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.QLEKrtklSFifzxsxWvEETkrPBuAb(time) ?? false;
		}

		public bool GetButtonTimedPressDown(int actionId, float time)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.QLEKrtklSFifzxsxWvEETkrPBuAb(time) ?? false;
		}

		public bool GetButtonTimedPressUp(string actionName, float time)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.dXQEAMKAEsFutkqBjFbRclxBVvdJ(time, 0f) ?? false;
		}

		public bool GetButtonTimedPressUp(int actionId, float time)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.dXQEAMKAEsFutkqBjFbRclxBVvdJ(time, 0f) ?? false;
		}

		public bool GetButtonTimedPressUp(string actionName, float time, float expireIn)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.dXQEAMKAEsFutkqBjFbRclxBVvdJ(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPressUp(int actionId, float time, float expireIn)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.dXQEAMKAEsFutkqBjFbRclxBVvdJ(time, expireIn) ?? false;
		}

		public bool GetButtonShortPress(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.zraMvrVyidNbGhjFGwgZujuZuXaU() ?? false;
		}

		public bool GetButtonShortPress(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.zraMvrVyidNbGhjFGwgZujuZuXaU() ?? false;
		}

		public bool GetButtonShortPressDown(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.dEQGvKELxDgVpXQGVhPDfgZSZMSU() ?? false;
		}

		public bool GetButtonShortPressDown(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.dEQGvKELxDgVpXQGVhPDfgZSZMSU() ?? false;
		}

		public bool GetButtonShortPressUp(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.DJeBsuTLpsCVTRdNwinlenTthwUuA() ?? false;
		}

		public bool GetButtonShortPressUp(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.DJeBsuTLpsCVTRdNwinlenTthwUuA() ?? false;
		}

		public bool GetButtonLongPress(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.giTXpMnAgicGmuBsPYIRxdDrTham() ?? false;
		}

		public bool GetButtonLongPress(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.giTXpMnAgicGmuBsPYIRxdDrTham() ?? false;
		}

		public bool GetButtonLongPressDown(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.UDfVaJDtQrhGOKciQpwVOCFQeTHE() ?? false;
		}

		public bool GetButtonLongPressDown(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.UDfVaJDtQrhGOKciQpwVOCFQeTHE() ?? false;
		}

		public bool GetButtonLongPressUp(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.BiYEsqBWejuYrZgXseujMSiWCjnM() ?? false;
		}

		public bool GetButtonLongPressUp(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.BiYEsqBWejuYrZgXseujMSiWCjnM() ?? false;
		}

		public bool GetButtonRepeating(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.XMDvGyhgdKGQIdcjGhtGyaBkOPiG() ?? false;
		}

		public bool GetButtonRepeating(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.XMDvGyhgdKGQIdcjGhtGyaBkOPiG() ?? false;
		}

		public bool GetAnyButton()
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.BRYiiIQkZMutWWvDgcSbWDyPsIOb(CbVfyyZWPLaMXAAoIrIHBSMHYdnm);
		}

		public bool GetAnyButtonDown()
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.RxmPsONHJStsMyyJRmjfONdxyTKc(CbVfyyZWPLaMXAAoIrIHBSMHYdnm);
		}

		public bool GetAnyButtonUp()
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.YRYEmpqxfSFWRyuTtLQyFpMSCehj(CbVfyyZWPLaMXAAoIrIHBSMHYdnm);
		}

		public bool GetAnyButtonPrev()
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.OkSaHVcjeqwywYgmchHiuTKVwPOr(CbVfyyZWPLaMXAAoIrIHBSMHYdnm);
		}

		public double GetButtonTimePressed(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0.0;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.QdAcIunoOckgdoMPrhwHOoNNfSUO() ?? 0.0;
		}

		public double GetButtonTimePressed(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0.0;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.QdAcIunoOckgdoMPrhwHOoNNfSUO() ?? 0.0;
		}

		public double GetButtonTimeUnpressed(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0.0;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.horbMJjoDewyvjBMwrtIjASukmRA() ?? 0.0;
		}

		public double GetButtonTimeUnpressed(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0.0;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.horbMJjoDewyvjBMwrtIjASukmRA() ?? 0.0;
		}

		public bool GetNegativeButton(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.xGqLYAhmrlKApcDsGylXNoGhsHKJ() ?? false;
		}

		public bool GetNegativeButton(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.xGqLYAhmrlKApcDsGylXNoGhsHKJ() ?? false;
		}

		public bool GetNegativeButtonDown(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.zQqegsuPBZQcPDbgYgCvXbzrMSjA() ?? false;
		}

		public bool GetNegativeButtonDown(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.zQqegsuPBZQcPDbgYgCvXbzrMSjA() ?? false;
		}

		public bool GetNegativeButtonUp(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.uYGNTCcasDFipFwcGgdlFErqqgJJ() ?? false;
		}

		public bool GetNegativeButtonUp(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.uYGNTCcasDFipFwcGgdlFErqqgJJ() ?? false;
		}

		public bool GetNegativeButtonPrev(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.LYHnxgyyuAPbCHIZzEjJDWjwOENI() ?? false;
		}

		public bool GetNegativeButtonPrev(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.LYHnxgyyuAPbCHIZzEjJDWjwOENI() ?? false;
		}

		public bool GetNegativeButtonSinglePressHold(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.WUJMhQZeuqzfgCKfWsXMFupPmxfm() ?? false;
		}

		public bool GetNegativeButtonSinglePressHold(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.WUJMhQZeuqzfgCKfWsXMFupPmxfm() ?? false;
		}

		public bool GetNegativeButtonSinglePressDown(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.eeXJZJVPbpcuVHGWOaKCSebvHxBCA() ?? false;
		}

		public bool GetNegativeButtonSinglePressDown(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.eeXJZJVPbpcuVHGWOaKCSebvHxBCA() ?? false;
		}

		public bool GetNegativeButtonSinglePressUp(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.mpdpbqFKATJtDTxpatBaDNKMCbMo() ?? false;
		}

		public bool GetNegativeButtonSinglePressUp(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.mpdpbqFKATJtDTxpatBaDNKMCbMo() ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(string actionName, float speed)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.heyGfqAPgFxDrCgfAbGoKLgXBHhFb(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(int actionId, float speed)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.heyGfqAPgFxDrCgfAbGoKLgXBHhFb(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(string actionName)
		{
			return GetNegativeButtonDoublePressHold(actionName, 0f);
		}

		public bool GetNegativeButtonDoublePressHold(int actionId)
		{
			return GetNegativeButtonDoublePressHold(actionId, 0f);
		}

		public bool GetNegativeButtonDoublePressDown(string actionName, float speed)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.vSyntcCkHSgbfGmhBzBEOsmJGqnX(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressDown(int actionId, float speed)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.vSyntcCkHSgbfGmhBzBEOsmJGqnX(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressDown(string actionName)
		{
			return GetNegativeButtonDoublePressDown(actionName, 0f);
		}

		public bool GetNegativeButtonDoublePressDown(int actionId)
		{
			return GetNegativeButtonDoublePressDown(actionId, 0f);
		}

		public bool GetNegativeButtonDoublePressUp(string actionName, float speed)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.RpzRrNGkLingEfckjyDKwxtspnaM(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressUp(int actionId, float speed)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.RpzRrNGkLingEfckjyDKwxtspnaM(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressUp(string actionName)
		{
			return GetNegativeButtonDoublePressUp(actionName, 0f);
		}

		public bool GetNegativeButtonDoublePressUp(int actionId)
		{
			return GetNegativeButtonDoublePressUp(actionId, 0f);
		}

		public bool GetNegativeButtonTimedPress(string actionName, float time)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.dYGtIpGbSsflWejomAvoduwnMjChA(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPress(int actionId, float time)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.dYGtIpGbSsflWejomAvoduwnMjChA(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPress(string actionName, float time, float expireIn)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.dYGtIpGbSsflWejomAvoduwnMjChA(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPress(int actionId, float time, float expireIn)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.dYGtIpGbSsflWejomAvoduwnMjChA(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPressDown(string actionName, float time)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.AHrgyVdSLVlvnNQDoRnHGYJJpNNN(time) ?? false;
		}

		public bool GetNegativeButtonTimedPressDown(int actionId, float time)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.AHrgyVdSLVlvnNQDoRnHGYJJpNNN(time) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(string actionName, float time)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.vXonRjPEkrVikgyzgdXEYTvbdPWx(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(int actionId, float time)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.vXonRjPEkrVikgyzgdXEYTvbdPWx(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(string actionName, float time, float expireIn)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.vXonRjPEkrVikgyzgdXEYTvbdPWx(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(int actionId, float time, float expireIn)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.vXonRjPEkrVikgyzgdXEYTvbdPWx(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonShortPress(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.MpAFpCpNFUaOLyHVQiFYqaRwGzoe() ?? false;
		}

		public bool GetNegativeButtonShortPress(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.MpAFpCpNFUaOLyHVQiFYqaRwGzoe() ?? false;
		}

		public bool GetNegativeButtonShortPressDown(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.CVtupeQxjEDuzxsvZVOrRmOvXdzG() ?? false;
		}

		public bool GetNegativeButtonShortPressDown(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.CVtupeQxjEDuzxsvZVOrRmOvXdzG() ?? false;
		}

		public bool GetNegativeButtonShortPressUp(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.jWOqYvLJMLNeLLOzCODqOXPPFAnE() ?? false;
		}

		public bool GetNegativeButtonShortPressUp(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.jWOqYvLJMLNeLLOzCODqOXPPFAnE() ?? false;
		}

		public bool GetNegativeButtonLongPress(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.myrlYebIerlIodVAiRhvRbLatyOD() ?? false;
		}

		public bool GetNegativeButtonLongPress(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.myrlYebIerlIodVAiRhvRbLatyOD() ?? false;
		}

		public bool GetNegativeButtonLongPressDown(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.UyimVoRwJsWgnMHvTcHJxZwEHMmW() ?? false;
		}

		public bool GetNegativeButtonLongPressDown(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.UyimVoRwJsWgnMHvTcHJxZwEHMmW() ?? false;
		}

		public bool GetNegativeButtonLongPressUp(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.zsBxRASPJkUYKCmFixqRgRgzShLM() ?? false;
		}

		public bool GetNegativeButtonLongPressUp(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.zsBxRASPJkUYKCmFixqRgRgzShLM() ?? false;
		}

		public bool GetNegativeButtonRepeating(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.KneBRatlfpcdHGsuxqXiuYPYithsA() ?? false;
		}

		public bool GetNegativeButtonRepeating(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.KneBRatlfpcdHGsuxqXiuYPYithsA() ?? false;
		}

		public bool GetAnyNegativeButton()
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.GjRQMnnTJZcXCTEPvjDmSzFhefJg(CbVfyyZWPLaMXAAoIrIHBSMHYdnm);
		}

		public bool GetAnyNegativeButtonDown()
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PcwdgKAGFNtHdoGUIrnrYcUdaJIA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm);
		}

		public bool GetAnyNegativeButtonUp()
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.DYAgYeTWORjITkfpOjKmVooPWKimA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm);
		}

		public bool GetAnyNegativeButtonPrev()
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.ivBYFTnkRjdBNWGrXjaSdDfAcGbH(CbVfyyZWPLaMXAAoIrIHBSMHYdnm);
		}

		public double GetNegativeButtonTimePressed(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0.0;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.QbRAtpgoFNDflvgdtpbgXUlHTxRuA() ?? 0.0;
		}

		public double GetNegativeButtonTimePressed(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0.0;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.QbRAtpgoFNDflvgdtpbgXUlHTxRuA() ?? 0.0;
		}

		public double GetNegativeButtonTimeUnpressed(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0.0;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.iwQkjDHgkVNHIsCqLKiHuVYAjVif() ?? 0.0;
		}

		public double GetNegativeButtonTimeUnpressed(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0.0;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.iwQkjDHgkVNHIsCqLKiHuVYAjVif() ?? 0.0;
		}

		public float GetAxis(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0f;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.vEPVoQqEOgbOhOGSJBikhSYMLdUiA() ?? 0f;
		}

		public float GetAxis(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0f;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.vEPVoQqEOgbOhOGSJBikhSYMLdUiA() ?? 0f;
		}

		public float GetAxisRaw(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0f;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.gQdCFfFDgtrNHvBHCVyIGNeWpcHOA() ?? 0f;
		}

		public float GetAxisRaw(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0f;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.gQdCFfFDgtrNHvBHCVyIGNeWpcHOA() ?? 0f;
		}

		public float GetAxisPrev(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0f;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.NpyCDcSwegLArthAMKSGhuXhkFop() ?? 0f;
		}

		public float GetAxisPrev(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0f;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.NpyCDcSwegLArthAMKSGhuXhkFop() ?? 0f;
		}

		public float GetAxisRawPrev(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0f;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.lvZydZRdNFBODAntQjlArfmnHsfu() ?? 0f;
		}

		public float GetAxisRawPrev(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0f;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.lvZydZRdNFBODAntQjlArfmnHsfu() ?? 0f;
		}

		public float GetAxisDelta(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0f;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.nnUukRDClTvjtVHilqoEFawpkjxH() ?? 0f;
		}

		public float GetAxisDelta(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0f;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.nnUukRDClTvjtVHilqoEFawpkjxH() ?? 0f;
		}

		public float GetAxisRawDelta(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0f;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.yRRQzoykJlGlPXlaScpkkNhQqklw() ?? 0f;
		}

		public float GetAxisRawDelta(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0f;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.yRRQzoykJlGlPXlaScpkkNhQqklw() ?? 0f;
		}

		public Vector2 GetAxis2D(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			ULWotIhqUFBdhwlfsIksjyZhzzXLA uLWotIhqUFBdhwlfsIksjyZhzzXLA = bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, xAxisActionName, true);
			if (uLWotIhqUFBdhwlfsIksjyZhzzXLA != null)
			{
				result.x = uLWotIhqUFBdhwlfsIksjyZhzzXLA.vEPVoQqEOgbOhOGSJBikhSYMLdUiA();
			}
			uLWotIhqUFBdhwlfsIksjyZhzzXLA = bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, yAxisActionName, true);
			if (uLWotIhqUFBdhwlfsIksjyZhzzXLA != null)
			{
				result.y = uLWotIhqUFBdhwlfsIksjyZhzzXLA.vEPVoQqEOgbOhOGSJBikhSYMLdUiA();
			}
			return result;
		}

		public Vector2 GetAxis2D(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			ULWotIhqUFBdhwlfsIksjyZhzzXLA uLWotIhqUFBdhwlfsIksjyZhzzXLA = bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, xAxisActionId, true);
			if (uLWotIhqUFBdhwlfsIksjyZhzzXLA != null)
			{
				result.x = uLWotIhqUFBdhwlfsIksjyZhzzXLA.vEPVoQqEOgbOhOGSJBikhSYMLdUiA();
			}
			uLWotIhqUFBdhwlfsIksjyZhzzXLA = bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, yAxisActionId, true);
			if (uLWotIhqUFBdhwlfsIksjyZhzzXLA != null)
			{
				result.y = uLWotIhqUFBdhwlfsIksjyZhzzXLA.vEPVoQqEOgbOhOGSJBikhSYMLdUiA();
			}
			return result;
		}

		public Vector2 GetAxis2DPrev(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			ULWotIhqUFBdhwlfsIksjyZhzzXLA uLWotIhqUFBdhwlfsIksjyZhzzXLA = bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, xAxisActionName, true);
			if (uLWotIhqUFBdhwlfsIksjyZhzzXLA != null)
			{
				result.x = uLWotIhqUFBdhwlfsIksjyZhzzXLA.NpyCDcSwegLArthAMKSGhuXhkFop();
			}
			uLWotIhqUFBdhwlfsIksjyZhzzXLA = bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, yAxisActionName, true);
			if (uLWotIhqUFBdhwlfsIksjyZhzzXLA != null)
			{
				result.y = uLWotIhqUFBdhwlfsIksjyZhzzXLA.NpyCDcSwegLArthAMKSGhuXhkFop();
			}
			return result;
		}

		public Vector2 GetAxis2DPrev(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			ULWotIhqUFBdhwlfsIksjyZhzzXLA uLWotIhqUFBdhwlfsIksjyZhzzXLA = bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, xAxisActionId, true);
			if (uLWotIhqUFBdhwlfsIksjyZhzzXLA != null)
			{
				result.x = uLWotIhqUFBdhwlfsIksjyZhzzXLA.NpyCDcSwegLArthAMKSGhuXhkFop();
			}
			uLWotIhqUFBdhwlfsIksjyZhzzXLA = bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, yAxisActionId, true);
			if (uLWotIhqUFBdhwlfsIksjyZhzzXLA != null)
			{
				result.y = uLWotIhqUFBdhwlfsIksjyZhzzXLA.NpyCDcSwegLArthAMKSGhuXhkFop();
			}
			return result;
		}

		public Vector2 GetAxis2DRaw(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			ULWotIhqUFBdhwlfsIksjyZhzzXLA uLWotIhqUFBdhwlfsIksjyZhzzXLA = bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, xAxisActionName, true);
			if (uLWotIhqUFBdhwlfsIksjyZhzzXLA != null)
			{
				result.x = uLWotIhqUFBdhwlfsIksjyZhzzXLA.gQdCFfFDgtrNHvBHCVyIGNeWpcHOA();
			}
			uLWotIhqUFBdhwlfsIksjyZhzzXLA = bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, yAxisActionName, true);
			if (uLWotIhqUFBdhwlfsIksjyZhzzXLA != null)
			{
				result.y = uLWotIhqUFBdhwlfsIksjyZhzzXLA.gQdCFfFDgtrNHvBHCVyIGNeWpcHOA();
			}
			return result;
		}

		public Vector2 GetAxis2DRaw(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			ULWotIhqUFBdhwlfsIksjyZhzzXLA uLWotIhqUFBdhwlfsIksjyZhzzXLA = bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, xAxisActionId, true);
			if (uLWotIhqUFBdhwlfsIksjyZhzzXLA != null)
			{
				result.x = uLWotIhqUFBdhwlfsIksjyZhzzXLA.gQdCFfFDgtrNHvBHCVyIGNeWpcHOA();
			}
			uLWotIhqUFBdhwlfsIksjyZhzzXLA = bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, yAxisActionId, true);
			if (uLWotIhqUFBdhwlfsIksjyZhzzXLA != null)
			{
				result.y = uLWotIhqUFBdhwlfsIksjyZhzzXLA.gQdCFfFDgtrNHvBHCVyIGNeWpcHOA();
			}
			return result;
		}

		public Vector2 GetAxis2DRawPrev(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			ULWotIhqUFBdhwlfsIksjyZhzzXLA uLWotIhqUFBdhwlfsIksjyZhzzXLA = bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, xAxisActionName, true);
			if (uLWotIhqUFBdhwlfsIksjyZhzzXLA != null)
			{
				result.x = uLWotIhqUFBdhwlfsIksjyZhzzXLA.lvZydZRdNFBODAntQjlArfmnHsfu();
			}
			uLWotIhqUFBdhwlfsIksjyZhzzXLA = bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, yAxisActionName, true);
			if (uLWotIhqUFBdhwlfsIksjyZhzzXLA != null)
			{
				result.y = uLWotIhqUFBdhwlfsIksjyZhzzXLA.lvZydZRdNFBODAntQjlArfmnHsfu();
			}
			return result;
		}

		public Vector2 GetAxis2DRawPrev(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			ULWotIhqUFBdhwlfsIksjyZhzzXLA uLWotIhqUFBdhwlfsIksjyZhzzXLA = bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, xAxisActionId, true);
			if (uLWotIhqUFBdhwlfsIksjyZhzzXLA != null)
			{
				result.x = uLWotIhqUFBdhwlfsIksjyZhzzXLA.lvZydZRdNFBODAntQjlArfmnHsfu();
			}
			uLWotIhqUFBdhwlfsIksjyZhzzXLA = bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, yAxisActionId, true);
			if (uLWotIhqUFBdhwlfsIksjyZhzzXLA != null)
			{
				result.y = uLWotIhqUFBdhwlfsIksjyZhzzXLA.lvZydZRdNFBODAntQjlArfmnHsfu();
			}
			return result;
		}

		public double GetAxisTimeActive(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0.0;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.cWfCnZVHEdQjaWhMBAgewfNvJoCL() ?? 0.0;
		}

		public double GetAxisTimeActive(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0.0;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.cWfCnZVHEdQjaWhMBAgewfNvJoCL() ?? 0.0;
		}

		public double GetAxisTimeInactive(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0.0;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.mijqNPtAOYiOZHWwhIlwfzuSGzWH() ?? 0.0;
		}

		public double GetAxisTimeInactive(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0.0;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.mijqNPtAOYiOZHWwhIlwfzuSGzWH() ?? 0.0;
		}

		public double GetAxisRawTimeActive(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0.0;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.jREmhbbNuOZvJIQdOnErHHkvtwot() ?? 0.0;
		}

		public double GetAxisRawTimeActive(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0.0;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.jREmhbbNuOZvJIQdOnErHHkvtwot() ?? 0.0;
		}

		public double GetAxisRawTimeInactive(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0.0;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.YAgCIbYjNfOsCRfUgepbbGhjtHTk() ?? 0.0;
		}

		public double GetAxisRawTimeInactive(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0.0;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.YAgCIbYjNfOsCRfUgepbbGhjtHTk() ?? 0.0;
		}

		public AxisCoordinateMode GetAxisCoordinateMode(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return AxisCoordinateMode.Absolute;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.sdRlwsRLwFnOjXwxxIrdSGwYltQD() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateMode(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return AxisCoordinateMode.Absolute;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.sdRlwsRLwFnOjXwxxIrdSGwYltQD() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return AxisCoordinateMode.Absolute;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.MrXHpsmIauxPutwZxNYjzqAgdIvq() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return AxisCoordinateMode.Absolute;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.MrXHpsmIauxPutwZxNYjzqAgdIvq() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return AxisCoordinateMode.Absolute;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.yHzpllAfcqdWadizBLzCEiSTGGZs() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return AxisCoordinateMode.Absolute;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.yHzpllAfcqdWadizBLzCEiSTGGZs() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return AxisCoordinateMode.Absolute;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.GZUiQQFRngGWEfLnOmWnfQIrTtJk() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return AxisCoordinateMode.Absolute;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.GZUiQQFRngGWEfLnOmWnfQIrTtJk() ?? AxisCoordinateMode.Absolute;
		}

		public IList<InputActionSourceData> GetCurrentInputSources(string actionName)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.VnbCPJercdswrBMdncGxCZajfOsb();
		}

		public IList<InputActionSourceData> GetCurrentInputSources(int actionId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.VnbCPJercdswrBMdncGxCZajfOsb();
		}

		public bool IsCurrentInputSource(string actionName, ControllerType controllerType)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.WRrtgpyUumnwVrDvtBIZfZUmiYeeA(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, ControllerType controllerType)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.WRrtgpyUumnwVrDvtBIZfZUmiYeeA(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(string actionName, ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.CyjoBakWIHmjrgYSgUmzeIyDVYVr(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.CyjoBakWIHmjrgYSgUmzeIyDVYVr(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(string actionName, Controller controller)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.PXhKbkfGYpgcekUEIUnUesoydMCuA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionName, true)?.VQItsXmFlydCXeUuNurzfpGUvmlgA(controller) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, Controller controller)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return false;
			}
			return bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zUiRzVjDrtXdtCfESwaiFcTXGjlK(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, actionId, true)?.VQItsXmFlydCXeUuNurzfpGUvmlgA(controller) ?? false;
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
				{
					ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				}
				else
				{
					bEDLzXIxpNJGCtcHNVEXWnpWvKtD.ZELESJItxBVDblGJuCmLvkYBJnzwA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, callback, updateLoop);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
				{
					ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				}
				else
				{
					bEDLzXIxpNJGCtcHNVEXWnpWvKtD.xmXyeEjDmQjYkGqkIUaqVeDQGnEgA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, callback, updateLoop, actionId);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return;
			}
			int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			if (num >= 0)
			{
				AddInputEventDelegate(callback, updateLoop, num);
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType)
		{
			AddInputEventDelegate(callback, updateLoop, eventType, (object[])null);
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId)
		{
			AddInputEventDelegate(callback, updateLoop, eventType, actionId, null);
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName)
		{
			AddInputEventDelegate(callback, updateLoop, eventType, actionName, null);
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, object[] arguments)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
				{
					ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				}
				else
				{
					bEDLzXIxpNJGCtcHNVEXWnpWvKtD.xwziLmPNfzwGKtRmcVNlawwrTIzH(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, callback, updateLoop, eventType, arguments);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId, object[] arguments)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
				{
					ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				}
				else
				{
					bEDLzXIxpNJGCtcHNVEXWnpWvKtD.wUwdHkvIqQKRHpcJwwBrOyxsoQEd(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, callback, updateLoop, eventType, actionId, arguments);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName, object[] arguments)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return;
			}
			int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName, true);
			if (num >= 0)
			{
				AddInputEventDelegate(callback, updateLoop, eventType, num, arguments);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
				{
					ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				}
				else
				{
					bEDLzXIxpNJGCtcHNVEXWnpWvKtD.lWkbaGEYswBRHabNrpECQroplben(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, callback);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
				{
					ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				}
				else
				{
					bEDLzXIxpNJGCtcHNVEXWnpWvKtD.zIIFpRMNaxdJvogZeyNkbtvniIRX(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, callback, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return;
			}
			int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
				{
					ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				}
				else
				{
					bEDLzXIxpNJGCtcHNVEXWnpWvKtD.DIEEcZWmzMTuReGTSgKzJuSckCHc(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, callback, updateLoop);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
				{
					ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				}
				else
				{
					bEDLzXIxpNJGCtcHNVEXWnpWvKtD.CLplVWlknHBRvJgAtTiPeuzCpENVA(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, callback, eventType);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
				{
					ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				}
				else
				{
					bEDLzXIxpNJGCtcHNVEXWnpWvKtD.anGvIhGhMOhzilJHAVdykNyKPYAE(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, callback, updateLoop, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return;
			}
			int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, updateLoop, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
				{
					ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				}
				else
				{
					bEDLzXIxpNJGCtcHNVEXWnpWvKtD.AkxFkhBvpWCVLyBjitOOkozYfvCt(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, callback, eventType, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return;
			}
			int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, eventType, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
				{
					ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				}
				else
				{
					bEDLzXIxpNJGCtcHNVEXWnpWvKtD.MVEqfATTddDMDQlfWEFYDioLNuaAb(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, callback, updateLoop, eventType);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
				{
					ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				}
				else
				{
					bEDLzXIxpNJGCtcHNVEXWnpWvKtD.AALLUIengqmiyADIaRruZWREAEUn(CbVfyyZWPLaMXAAoIrIHBSMHYdnm, callback, updateLoop, eventType, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return;
			}
			int num = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, updateLoop, eventType, num);
			}
		}

		public void ClearInputEventDelegates()
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
				{
					ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				}
				else
				{
					bEDLzXIxpNJGCtcHNVEXWnpWvKtD.ajOAkAZfyzjWVhZsjDPbJfnnklFO(CbVfyyZWPLaMXAAoIrIHBSMHYdnm);
				}
			}
		}

		public void SetVibration(int motorIndex, float motorLevel)
		{
			SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors: false);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration)
		{
			SetVibration(motorIndex, motorLevel, duration, stopOtherMotors: false);
		}

		public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
			SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return;
			}
			IList<Joystick> joysticks = controllers.Joysticks;
			int count = joysticks.Count;
			for (int i = 0; i < count; i++)
			{
				Joystick joystick = joysticks[i];
				if (joystick.supportsVibration)
				{
					joystick.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
				}
			}
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return 0f;
			}
			IList<Joystick> joysticks = controllers.Joysticks;
			int count = joysticks.Count;
			float num = 0f;
			for (int i = 0; i < count; i++)
			{
				Joystick joystick = joysticks[i];
				if (joystick.supportsVibration)
				{
					num = MathTools.Max(joystick.GetVibration(motorIndex), num);
				}
			}
			return num;
		}

		public void StopVibration()
		{
			if (ReInput._id != qzWGoAnnfStvBiKovJSdtFndfFvV)
			{
				ReInput.CheckInitialized(qzWGoAnnfStvBiKovJSdtFndfFvV);
				return;
			}
			IList<Joystick> joysticks = controllers.Joysticks;
			int count = joysticks.Count;
			for (int i = 0; i < count; i++)
			{
				Joystick joystick = joysticks[i];
				if (joystick.supportsVibration)
				{
					joystick.StopVibration();
				}
			}
		}

		internal void UmTMOSpJLeUKtzStKGOtpnwadYKBA()
		{
			yEMNQVyObZonGbpuaezOlWvHwtNx();
		}

		private void yEMNQVyObZonGbpuaezOlWvHwtNx()
		{
			controllers.aNemEsLTmjfyzpbpdsSkgbyDSlGv();
			lKjvibcBriEoVQiRNkqxhvdKOaDf = false;
		}
	}
}
