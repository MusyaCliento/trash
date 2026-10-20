using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public abstract class ControllerMapWithAxes : ControllerMap
	{
		private sealed class HrdqbmlPYcAHCWtBPvRYBPibDvFhA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int tNpSEtckmBuWGvFKrMamQXzzDPQK;

			private ActionElementMap YiddnBhwFwmrVFAVQNPqwsHpdTky;

			private int ZhbFvydyUTwaHlfQAjPIGhLplWpbb;

			public ControllerMapWithAxes QeWKoaBCXrvBmAIQxtcGPiLlBDsjA;

			private int hCLnufocEWGPKWMBRCvMpsAoNmzh;

			public int AYsXlVGBdyNjygIBRKpWrkeXFDJkA;

			private bool HYqkCtlGUTetLMNeuwfxbBfPdlfK;

			public bool YsEMuljodrLtYUqVqrldGBddVuJF;

			private IEnumerator<ActionElementMap> laYQQtqfYPgUEmkBapcopAMKmxFF;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return YiddnBhwFwmrVFAVQNPqwsHpdTky;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return YiddnBhwFwmrVFAVQNPqwsHpdTky;
				}
			}

			[DebuggerHidden]
			public HrdqbmlPYcAHCWtBPvRYBPibDvFhA(int P_0)
			{
				tNpSEtckmBuWGvFKrMamQXzzDPQK = P_0;
				ZhbFvydyUTwaHlfQAjPIGhLplWpbb = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = tNpSEtckmBuWGvFKrMamQXzzDPQK;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						ZLhptCTPgXHHwhelaQRqJrSEecRz();
					}
				}
				laYQQtqfYPgUEmkBapcopAMKmxFF = null;
				tNpSEtckmBuWGvFKrMamQXzzDPQK = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = tNpSEtckmBuWGvFKrMamQXzzDPQK;
					ControllerMapWithAxes qeWKoaBCXrvBmAIQxtcGPiLlBDsjA = QeWKoaBCXrvBmAIQxtcGPiLlBDsjA;
					switch (num)
					{
					default:
						return false;
					case 0:
						tNpSEtckmBuWGvFKrMamQXzzDPQK = -1;
						if (ReInput._id != qeWKoaBCXrvBmAIQxtcGPiLlBDsjA.HGKnnYgsStSHzmTMXitKKPatJYAf)
						{
							ReInput.CheckInitialized(qeWKoaBCXrvBmAIQxtcGPiLlBDsjA.HGKnnYgsStSHzmTMXitKKPatJYAf);
							return false;
						}
						if (hCLnufocEWGPKWMBRCvMpsAoNmzh < 0)
						{
							return false;
						}
						laYQQtqfYPgUEmkBapcopAMKmxFF = qeWKoaBCXrvBmAIQxtcGPiLlBDsjA.AxisMaps.GetEnumerator();
						tNpSEtckmBuWGvFKrMamQXzzDPQK = -3;
						break;
					case 1:
						tNpSEtckmBuWGvFKrMamQXzzDPQK = -3;
						break;
					}
					while (laYQQtqfYPgUEmkBapcopAMKmxFF.MoveNext())
					{
						ActionElementMap current = laYQQtqfYPgUEmkBapcopAMKmxFF.Current;
						if (current._actionId == hCLnufocEWGPKWMBRCvMpsAoNmzh && (!HYqkCtlGUTetLMNeuwfxbBfPdlfK || current.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
						{
							YiddnBhwFwmrVFAVQNPqwsHpdTky = current;
							tNpSEtckmBuWGvFKrMamQXzzDPQK = 1;
							return true;
						}
					}
					ZLhptCTPgXHHwhelaQRqJrSEecRz();
					laYQQtqfYPgUEmkBapcopAMKmxFF = null;
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

			private void ZLhptCTPgXHHwhelaQRqJrSEecRz()
			{
				tNpSEtckmBuWGvFKrMamQXzzDPQK = -1;
				if (laYQQtqfYPgUEmkBapcopAMKmxFF != null)
				{
					laYQQtqfYPgUEmkBapcopAMKmxFF.Dispose();
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
				HrdqbmlPYcAHCWtBPvRYBPibDvFhA hrdqbmlPYcAHCWtBPvRYBPibDvFhA;
				if (tNpSEtckmBuWGvFKrMamQXzzDPQK == -2 && ZhbFvydyUTwaHlfQAjPIGhLplWpbb == Environment.CurrentManagedThreadId)
				{
					tNpSEtckmBuWGvFKrMamQXzzDPQK = 0;
					hrdqbmlPYcAHCWtBPvRYBPibDvFhA = this;
				}
				else
				{
					hrdqbmlPYcAHCWtBPvRYBPibDvFhA = new HrdqbmlPYcAHCWtBPvRYBPibDvFhA(0);
					hrdqbmlPYcAHCWtBPvRYBPibDvFhA.QeWKoaBCXrvBmAIQxtcGPiLlBDsjA = QeWKoaBCXrvBmAIQxtcGPiLlBDsjA;
				}
				hrdqbmlPYcAHCWtBPvRYBPibDvFhA.hCLnufocEWGPKWMBRCvMpsAoNmzh = AYsXlVGBdyNjygIBRKpWrkeXFDJkA;
				hrdqbmlPYcAHCWtBPvRYBPibDvFhA.HYqkCtlGUTetLMNeuwfxbBfPdlfK = YsEMuljodrLtYUqVqrldGBddVuJF;
				return hrdqbmlPYcAHCWtBPvRYBPibDvFhA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class HUwKBoVpJdedVImkYLAARbSgngoS : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int ZxOmbhuLIStRlzyFJVUyPsTjCklq;

			private ElementAssignmentConflictInfo syoLGPqXTCTFolXovRYZWewNZrLj;

			private int QkQOeFzRKDVsmKMOdemeWMNrxrsf;

			public ControllerMapWithAxes LGmrutGIiGNegvLqMsNZpkNEqXZJ;

			private ControllerMap xlEUCOrgUcJOkoSiXRviKgMOXgZy;

			public ControllerMap MsWGjKdPBwONfiIxHhkwKyHZGaWK;

			private bool BbLEtoeDZrVdVDXfNSNZxtcXLLsd;

			public bool apEwEdNgZTGqqjEghWLNwnDSuhBC;

			private IList<ActionElementMap> WPXizsYxAGEAsGiURVJqwMoJrxpD;

			private int HnvckxcFnBUIuDfUecPHJzkfncfn;

			private IEnumerator<ElementAssignmentConflictInfo> JkBAGmUetPpIqnsDlEcCZKhGVBst;

			private int qhCMGgkJHtBMcXuyUzybgyGGpuEx;

			private ActionElementMap kQOiBBVSIwWLIWwSxBlSnEkncHgl;

			private int AeRzKjTCgeXDKSnSBlKJPDqrmvPR;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return syoLGPqXTCTFolXovRYZWewNZrLj;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return syoLGPqXTCTFolXovRYZWewNZrLj;
				}
			}

			[DebuggerHidden]
			public HUwKBoVpJdedVImkYLAARbSgngoS(int P_0)
			{
				ZxOmbhuLIStRlzyFJVUyPsTjCklq = P_0;
				QkQOeFzRKDVsmKMOdemeWMNrxrsf = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int zxOmbhuLIStRlzyFJVUyPsTjCklq = ZxOmbhuLIStRlzyFJVUyPsTjCklq;
				if (zxOmbhuLIStRlzyFJVUyPsTjCklq == -3 || zxOmbhuLIStRlzyFJVUyPsTjCklq == 1)
				{
					try
					{
					}
					finally
					{
						ARSCIpiQBcPLdZfuPraNAeJrrEGbA();
					}
				}
				WPXizsYxAGEAsGiURVJqwMoJrxpD = null;
				JkBAGmUetPpIqnsDlEcCZKhGVBst = null;
				kQOiBBVSIwWLIWwSxBlSnEkncHgl = null;
				ZxOmbhuLIStRlzyFJVUyPsTjCklq = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int zxOmbhuLIStRlzyFJVUyPsTjCklq = ZxOmbhuLIStRlzyFJVUyPsTjCklq;
					ControllerMapWithAxes lGmrutGIiGNegvLqMsNZpkNEqXZJ = LGmrutGIiGNegvLqMsNZpkNEqXZJ;
					switch (zxOmbhuLIStRlzyFJVUyPsTjCklq)
					{
					default:
						return false;
					case 0:
						ZxOmbhuLIStRlzyFJVUyPsTjCklq = -1;
						if (ReInput._id != lGmrutGIiGNegvLqMsNZpkNEqXZJ.HGKnnYgsStSHzmTMXitKKPatJYAf)
						{
							ReInput.CheckInitialized(lGmrutGIiGNegvLqMsNZpkNEqXZJ.HGKnnYgsStSHzmTMXitKKPatJYAf);
							return false;
						}
						if (xlEUCOrgUcJOkoSiXRviKgMOXgZy == null)
						{
							return false;
						}
						JkBAGmUetPpIqnsDlEcCZKhGVBst = ((ControllerMap)lGmrutGIiGNegvLqMsNZpkNEqXZJ).ElementAssignmentConflicts(xlEUCOrgUcJOkoSiXRviKgMOXgZy, BbLEtoeDZrVdVDXfNSNZxtcXLLsd).GetEnumerator();
						ZxOmbhuLIStRlzyFJVUyPsTjCklq = -3;
						goto IL_00af;
					case 1:
						ZxOmbhuLIStRlzyFJVUyPsTjCklq = -3;
						goto IL_00af;
					case 2:
						{
							ZxOmbhuLIStRlzyFJVUyPsTjCklq = -1;
							goto IL_0232;
						}
						IL_0244:
						if (AeRzKjTCgeXDKSnSBlKJPDqrmvPR < HnvckxcFnBUIuDfUecPHJzkfncfn)
						{
							ActionElementMap actionElementMap = WPXizsYxAGEAsGiURVJqwMoJrxpD[AeRzKjTCgeXDKSnSBlKJPDqrmvPR];
							if ((!BbLEtoeDZrVdVDXfNSNZxtcXLLsd || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && kQOiBBVSIwWLIWwSxBlSnEkncHgl.CheckForAssignmentConflict(actionElementMap))
							{
								syoLGPqXTCTFolXovRYZWewNZrLj = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(lGmrutGIiGNegvLqMsNZpkNEqXZJ._categoryId).userAssignable, -1, lGmrutGIiGNegvLqMsNZpkNEqXZJ._controllerType, lGmrutGIiGNegvLqMsNZpkNEqXZJ._controllerId, lGmrutGIiGNegvLqMsNZpkNEqXZJ._id, kQOiBBVSIwWLIWwSxBlSnEkncHgl.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc, kQOiBBVSIwWLIWwSxBlSnEkncHgl._actionId, kQOiBBVSIwWLIWwSxBlSnEkncHgl._elementType, kQOiBBVSIwWLIWwSxBlSnEkncHgl._elementIdentifierId, kQOiBBVSIwWLIWwSxBlSnEkncHgl.keyCode, kQOiBBVSIwWLIWwSxBlSnEkncHgl.modifierKeyFlags);
								ZxOmbhuLIStRlzyFJVUyPsTjCklq = 2;
								return true;
							}
							goto IL_0232;
						}
						kQOiBBVSIwWLIWwSxBlSnEkncHgl = null;
						goto IL_025c;
						IL_0232:
						AeRzKjTCgeXDKSnSBlKJPDqrmvPR++;
						goto IL_0244;
						IL_026e:
						if (qhCMGgkJHtBMcXuyUzybgyGGpuEx < lGmrutGIiGNegvLqMsNZpkNEqXZJ.zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count)
						{
							kQOiBBVSIwWLIWwSxBlSnEkncHgl = lGmrutGIiGNegvLqMsNZpkNEqXZJ.zEtbpEyhzOiPlpuftFgbNZUUgkZN[qhCMGgkJHtBMcXuyUzybgyGGpuEx];
							if (!BbLEtoeDZrVdVDXfNSNZxtcXLLsd || kQOiBBVSIwWLIWwSxBlSnEkncHgl.KDuOcDwQLQHhwDRrYdOMFXnFZITxA)
							{
								AeRzKjTCgeXDKSnSBlKJPDqrmvPR = 0;
								goto IL_0244;
							}
							goto IL_025c;
						}
						return false;
						IL_00af:
						if (JkBAGmUetPpIqnsDlEcCZKhGVBst.MoveNext())
						{
							ElementAssignmentConflictInfo current = JkBAGmUetPpIqnsDlEcCZKhGVBst.Current;
							syoLGPqXTCTFolXovRYZWewNZrLj = current;
							ZxOmbhuLIStRlzyFJVUyPsTjCklq = 1;
							return true;
						}
						ARSCIpiQBcPLdZfuPraNAeJrrEGbA();
						JkBAGmUetPpIqnsDlEcCZKhGVBst = null;
						if (!(xlEUCOrgUcJOkoSiXRviKgMOXgZy is ControllerMapWithAxes controllerMapWithAxes))
						{
							return false;
						}
						if (BbLEtoeDZrVdVDXfNSNZxtcXLLsd && (!lGmrutGIiGNegvLqMsNZpkNEqXZJ._enabled || !controllerMapWithAxes._enabled))
						{
							return false;
						}
						WPXizsYxAGEAsGiURVJqwMoJrxpD = controllerMapWithAxes.AxisMaps;
						if (WPXizsYxAGEAsGiURVJqwMoJrxpD == null)
						{
							return false;
						}
						HnvckxcFnBUIuDfUecPHJzkfncfn = WPXizsYxAGEAsGiURVJqwMoJrxpD.Count;
						qhCMGgkJHtBMcXuyUzybgyGGpuEx = 0;
						goto IL_026e;
						IL_025c:
						qhCMGgkJHtBMcXuyUzybgyGGpuEx++;
						goto IL_026e;
					}
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

			private void ARSCIpiQBcPLdZfuPraNAeJrrEGbA()
			{
				ZxOmbhuLIStRlzyFJVUyPsTjCklq = -1;
				if (JkBAGmUetPpIqnsDlEcCZKhGVBst != null)
				{
					JkBAGmUetPpIqnsDlEcCZKhGVBst.Dispose();
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
				HUwKBoVpJdedVImkYLAARbSgngoS hUwKBoVpJdedVImkYLAARbSgngoS;
				if (ZxOmbhuLIStRlzyFJVUyPsTjCklq == -2 && QkQOeFzRKDVsmKMOdemeWMNrxrsf == Environment.CurrentManagedThreadId)
				{
					ZxOmbhuLIStRlzyFJVUyPsTjCklq = 0;
					hUwKBoVpJdedVImkYLAARbSgngoS = this;
				}
				else
				{
					hUwKBoVpJdedVImkYLAARbSgngoS = new HUwKBoVpJdedVImkYLAARbSgngoS(0);
					hUwKBoVpJdedVImkYLAARbSgngoS.LGmrutGIiGNegvLqMsNZpkNEqXZJ = LGmrutGIiGNegvLqMsNZpkNEqXZJ;
				}
				hUwKBoVpJdedVImkYLAARbSgngoS.xlEUCOrgUcJOkoSiXRviKgMOXgZy = MsWGjKdPBwONfiIxHhkwKyHZGaWK;
				hUwKBoVpJdedVImkYLAARbSgngoS.BbLEtoeDZrVdVDXfNSNZxtcXLLsd = apEwEdNgZTGqqjEghWLNwnDSuhBC;
				return hUwKBoVpJdedVImkYLAARbSgngoS;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class UPvKDLHFxyWUscIFtrJDJlVshoZH : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int nBuARKcOPxaPNhbIIJRISPVmYNrj;

			private ElementAssignmentConflictInfo FwRYCGdRnmgGAuIKjedbYZtZrKWD;

			private int QuTCBovKSnPmqSPYidVXDwSqwQCH;

			public ControllerMapWithAxes slXrPDpJXBBBzGLKutNmIAAtiABA;

			private ActionElementMap AycBPmwUkkGsvPJypOQRHVzIJplf;

			public ActionElementMap sRgyNDQpgtiXGFirasCQpDzYZUaeA;

			private bool fiZZfwunseUDCwrOIjWqCqBPGESh;

			public bool jMXWmDTpzWNpKQNmxmsLxKQAasn;

			private IEnumerator<ElementAssignmentConflictInfo> EuplrNqhJEDwLceIWChhXcJNcLWL;

			private int zQJOKEDtXHdWhmNPMpGMtiTxHiPU;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return FwRYCGdRnmgGAuIKjedbYZtZrKWD;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return FwRYCGdRnmgGAuIKjedbYZtZrKWD;
				}
			}

			[DebuggerHidden]
			public UPvKDLHFxyWUscIFtrJDJlVshoZH(int P_0)
			{
				nBuARKcOPxaPNhbIIJRISPVmYNrj = P_0;
				QuTCBovKSnPmqSPYidVXDwSqwQCH = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = nBuARKcOPxaPNhbIIJRISPVmYNrj;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						WHUcxvlUIIEqCjLRWRmDYdmmcgmg();
					}
				}
				EuplrNqhJEDwLceIWChhXcJNcLWL = null;
				nBuARKcOPxaPNhbIIJRISPVmYNrj = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = nBuARKcOPxaPNhbIIJRISPVmYNrj;
					ControllerMapWithAxes controllerMapWithAxes = slXrPDpJXBBBzGLKutNmIAAtiABA;
					switch (num)
					{
					default:
						return false;
					case 0:
						nBuARKcOPxaPNhbIIJRISPVmYNrj = -1;
						if (ReInput._id != controllerMapWithAxes.HGKnnYgsStSHzmTMXitKKPatJYAf)
						{
							ReInput.CheckInitialized(controllerMapWithAxes.HGKnnYgsStSHzmTMXitKKPatJYAf);
							return false;
						}
						if (AycBPmwUkkGsvPJypOQRHVzIJplf == null)
						{
							return false;
						}
						EuplrNqhJEDwLceIWChhXcJNcLWL = ((ControllerMap)controllerMapWithAxes).ElementAssignmentConflicts(AycBPmwUkkGsvPJypOQRHVzIJplf, fiZZfwunseUDCwrOIjWqCqBPGESh).GetEnumerator();
						nBuARKcOPxaPNhbIIJRISPVmYNrj = -3;
						goto IL_00ad;
					case 1:
						nBuARKcOPxaPNhbIIJRISPVmYNrj = -3;
						goto IL_00ad;
					case 2:
						{
							nBuARKcOPxaPNhbIIJRISPVmYNrj = -1;
							goto IL_01a9;
						}
						IL_00ad:
						if (EuplrNqhJEDwLceIWChhXcJNcLWL.MoveNext())
						{
							ElementAssignmentConflictInfo current = EuplrNqhJEDwLceIWChhXcJNcLWL.Current;
							FwRYCGdRnmgGAuIKjedbYZtZrKWD = current;
							nBuARKcOPxaPNhbIIJRISPVmYNrj = 1;
							return true;
						}
						WHUcxvlUIIEqCjLRWRmDYdmmcgmg();
						EuplrNqhJEDwLceIWChhXcJNcLWL = null;
						if (fiZZfwunseUDCwrOIjWqCqBPGESh && (!controllerMapWithAxes._enabled || !AycBPmwUkkGsvPJypOQRHVzIJplf.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
						{
							return false;
						}
						if (controllerMapWithAxes.zEtbpEyhzOiPlpuftFgbNZUUgkZN == null)
						{
							return false;
						}
						zQJOKEDtXHdWhmNPMpGMtiTxHiPU = 0;
						goto IL_01bb;
						IL_01bb:
						if (zQJOKEDtXHdWhmNPMpGMtiTxHiPU < controllerMapWithAxes.zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count)
						{
							ActionElementMap actionElementMap = controllerMapWithAxes.zEtbpEyhzOiPlpuftFgbNZUUgkZN[zQJOKEDtXHdWhmNPMpGMtiTxHiPU];
							if ((!fiZZfwunseUDCwrOIjWqCqBPGESh || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && actionElementMap.CheckForAssignmentConflict(AycBPmwUkkGsvPJypOQRHVzIJplf))
							{
								FwRYCGdRnmgGAuIKjedbYZtZrKWD = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMapWithAxes._categoryId).userAssignable, -1, controllerMapWithAxes._controllerType, controllerMapWithAxes._controllerId, controllerMapWithAxes._id, actionElementMap.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
								nBuARKcOPxaPNhbIIJRISPVmYNrj = 2;
								return true;
							}
							goto IL_01a9;
						}
						return false;
						IL_01a9:
						zQJOKEDtXHdWhmNPMpGMtiTxHiPU++;
						goto IL_01bb;
					}
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

			private void WHUcxvlUIIEqCjLRWRmDYdmmcgmg()
			{
				nBuARKcOPxaPNhbIIJRISPVmYNrj = -1;
				if (EuplrNqhJEDwLceIWChhXcJNcLWL != null)
				{
					EuplrNqhJEDwLceIWChhXcJNcLWL.Dispose();
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
				UPvKDLHFxyWUscIFtrJDJlVshoZH uPvKDLHFxyWUscIFtrJDJlVshoZH;
				if (nBuARKcOPxaPNhbIIJRISPVmYNrj == -2 && QuTCBovKSnPmqSPYidVXDwSqwQCH == Environment.CurrentManagedThreadId)
				{
					nBuARKcOPxaPNhbIIJRISPVmYNrj = 0;
					uPvKDLHFxyWUscIFtrJDJlVshoZH = this;
				}
				else
				{
					uPvKDLHFxyWUscIFtrJDJlVshoZH = new UPvKDLHFxyWUscIFtrJDJlVshoZH(0);
					uPvKDLHFxyWUscIFtrJDJlVshoZH.slXrPDpJXBBBzGLKutNmIAAtiABA = slXrPDpJXBBBzGLKutNmIAAtiABA;
				}
				uPvKDLHFxyWUscIFtrJDJlVshoZH.AycBPmwUkkGsvPJypOQRHVzIJplf = sRgyNDQpgtiXGFirasCQpDzYZUaeA;
				uPvKDLHFxyWUscIFtrJDJlVshoZH.fiZZfwunseUDCwrOIjWqCqBPGESh = jMXWmDTpzWNpKQNmxmsLxKQAasn;
				return uPvKDLHFxyWUscIFtrJDJlVshoZH;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class svEHmFnMUXBcEGHlNfBotcYGeJWdA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int eGiyoMANQcFyvWKsOOPdPBazKGdH;

			private ElementAssignmentConflictInfo ljNxxuqrVUuDPdbRzFUqZpuuMYfo;

			private int czViQOmWPCwMQfQyWIqcbxYONMPt;

			public ControllerMapWithAxes RgaBxpHTySXEVlZinpkFKzKIGTFCA;

			private ElementAssignmentConflictCheck hEmaQIuuWXEkZgZbTteithFWMrdS;

			public ElementAssignmentConflictCheck zYsvZuGbfeXsSnCJwBaCOdUYRMbi;

			private bool NMSYMeMhijTOBOkfOrXYhlZdkFte;

			public bool XhgDSrSHETgtrgUPikmSgnEDDnJy;

			private ElementAssignment xlZeeqGcdTJFubipCaCSLYIXvHwvB;

			private IEnumerator<ElementAssignmentConflictInfo> pvPpKjWIwdoKWwKtmVFrOixJAroT;

			private int tyiMCkohoEwVZsimAMbwsPeDnBYB;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return ljNxxuqrVUuDPdbRzFUqZpuuMYfo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ljNxxuqrVUuDPdbRzFUqZpuuMYfo;
				}
			}

			[DebuggerHidden]
			public svEHmFnMUXBcEGHlNfBotcYGeJWdA(int P_0)
			{
				eGiyoMANQcFyvWKsOOPdPBazKGdH = P_0;
				czViQOmWPCwMQfQyWIqcbxYONMPt = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = eGiyoMANQcFyvWKsOOPdPBazKGdH;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						yuMtmhWnMAaLhtpeNeaOBWdhgIVY();
					}
				}
				pvPpKjWIwdoKWwKtmVFrOixJAroT = null;
				eGiyoMANQcFyvWKsOOPdPBazKGdH = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = eGiyoMANQcFyvWKsOOPdPBazKGdH;
					ControllerMapWithAxes rgaBxpHTySXEVlZinpkFKzKIGTFCA = RgaBxpHTySXEVlZinpkFKzKIGTFCA;
					switch (num)
					{
					default:
						return false;
					case 0:
						eGiyoMANQcFyvWKsOOPdPBazKGdH = -1;
						if (ReInput._id != rgaBxpHTySXEVlZinpkFKzKIGTFCA.HGKnnYgsStSHzmTMXitKKPatJYAf)
						{
							ReInput.CheckInitialized(rgaBxpHTySXEVlZinpkFKzKIGTFCA.HGKnnYgsStSHzmTMXitKKPatJYAf);
							return false;
						}
						pvPpKjWIwdoKWwKtmVFrOixJAroT = ((ControllerMap)rgaBxpHTySXEVlZinpkFKzKIGTFCA).ElementAssignmentConflicts(hEmaQIuuWXEkZgZbTteithFWMrdS, NMSYMeMhijTOBOkfOrXYhlZdkFte).GetEnumerator();
						eGiyoMANQcFyvWKsOOPdPBazKGdH = -3;
						goto IL_009e;
					case 1:
						eGiyoMANQcFyvWKsOOPdPBazKGdH = -3;
						goto IL_009e;
					case 2:
						{
							eGiyoMANQcFyvWKsOOPdPBazKGdH = -1;
							goto IL_01b5;
						}
						IL_01c7:
						if (tyiMCkohoEwVZsimAMbwsPeDnBYB < rgaBxpHTySXEVlZinpkFKzKIGTFCA.zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count)
						{
							ActionElementMap actionElementMap = rgaBxpHTySXEVlZinpkFKzKIGTFCA.zEtbpEyhzOiPlpuftFgbNZUUgkZN[tyiMCkohoEwVZsimAMbwsPeDnBYB];
							if ((!NMSYMeMhijTOBOkfOrXYhlZdkFte || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && actionElementMap.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc != hEmaQIuuWXEkZgZbTteithFWMrdS.elementMapId && actionElementMap.CheckForAssignmentConflict(xlZeeqGcdTJFubipCaCSLYIXvHwvB))
							{
								ljNxxuqrVUuDPdbRzFUqZpuuMYfo = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(rgaBxpHTySXEVlZinpkFKzKIGTFCA._categoryId).userAssignable, -1, rgaBxpHTySXEVlZinpkFKzKIGTFCA._controllerType, rgaBxpHTySXEVlZinpkFKzKIGTFCA._controllerId, rgaBxpHTySXEVlZinpkFKzKIGTFCA._id, actionElementMap.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
								eGiyoMANQcFyvWKsOOPdPBazKGdH = 2;
								return true;
							}
							goto IL_01b5;
						}
						return false;
						IL_009e:
						if (pvPpKjWIwdoKWwKtmVFrOixJAroT.MoveNext())
						{
							ElementAssignmentConflictInfo current = pvPpKjWIwdoKWwKtmVFrOixJAroT.Current;
							ljNxxuqrVUuDPdbRzFUqZpuuMYfo = current;
							eGiyoMANQcFyvWKsOOPdPBazKGdH = 1;
							return true;
						}
						yuMtmhWnMAaLhtpeNeaOBWdhgIVY();
						pvPpKjWIwdoKWwKtmVFrOixJAroT = null;
						if (NMSYMeMhijTOBOkfOrXYhlZdkFte && !rgaBxpHTySXEVlZinpkFKzKIGTFCA._enabled)
						{
							return false;
						}
						if (rgaBxpHTySXEVlZinpkFKzKIGTFCA.zEtbpEyhzOiPlpuftFgbNZUUgkZN == null)
						{
							return false;
						}
						xlZeeqGcdTJFubipCaCSLYIXvHwvB = hEmaQIuuWXEkZgZbTteithFWMrdS.ToElementAssignment();
						tyiMCkohoEwVZsimAMbwsPeDnBYB = 0;
						goto IL_01c7;
						IL_01b5:
						tyiMCkohoEwVZsimAMbwsPeDnBYB++;
						goto IL_01c7;
					}
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

			private void yuMtmhWnMAaLhtpeNeaOBWdhgIVY()
			{
				eGiyoMANQcFyvWKsOOPdPBazKGdH = -1;
				if (pvPpKjWIwdoKWwKtmVFrOixJAroT != null)
				{
					pvPpKjWIwdoKWwKtmVFrOixJAroT.Dispose();
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
				svEHmFnMUXBcEGHlNfBotcYGeJWdA svEHmFnMUXBcEGHlNfBotcYGeJWdA2;
				if (eGiyoMANQcFyvWKsOOPdPBazKGdH == -2 && czViQOmWPCwMQfQyWIqcbxYONMPt == Environment.CurrentManagedThreadId)
				{
					eGiyoMANQcFyvWKsOOPdPBazKGdH = 0;
					svEHmFnMUXBcEGHlNfBotcYGeJWdA2 = this;
				}
				else
				{
					svEHmFnMUXBcEGHlNfBotcYGeJWdA2 = new svEHmFnMUXBcEGHlNfBotcYGeJWdA(0);
					svEHmFnMUXBcEGHlNfBotcYGeJWdA2.RgaBxpHTySXEVlZinpkFKzKIGTFCA = RgaBxpHTySXEVlZinpkFKzKIGTFCA;
				}
				svEHmFnMUXBcEGHlNfBotcYGeJWdA2.hEmaQIuuWXEkZgZbTteithFWMrdS = zYsvZuGbfeXsSnCJwBaCOdUYRMbi;
				svEHmFnMUXBcEGHlNfBotcYGeJWdA2.NMSYMeMhijTOBOkfOrXYhlZdkFte = XhgDSrSHETgtrgUPikmSgnEDDnJy;
				return svEHmFnMUXBcEGHlNfBotcYGeJWdA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private readonly IList<ActionElementMap> zEtbpEyhzOiPlpuftFgbNZUUgkZN;

		private readonly ReadOnlyCollection<ActionElementMap> NMhBprGOhnJBpHhQyokSlGNAuFuh;

		public int axisMapCount
		{
			get
			{
				if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
					return 0;
				}
				if (zEtbpEyhzOiPlpuftFgbNZUUgkZN == null)
				{
					return 0;
				}
				return zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count;
			}
		}

		public IList<ActionElementMap> AxisMaps
		{
			get
			{
				if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return NMhBprGOhnJBpHhQyokSlGNAuFuh;
			}
		}

		internal AList<ActionElementMap> VIwCRfOqTkHNlTBczwmjQPsfbVkv => (AList<ActionElementMap>)zEtbpEyhzOiPlpuftFgbNZUUgkZN;

		public ControllerMapWithAxes()
		{
			zEtbpEyhzOiPlpuftFgbNZUUgkZN = new AList<ActionElementMap>();
			NMhBprGOhnJBpHhQyokSlGNAuFuh = new ReadOnlyCollection<ActionElementMap>(zEtbpEyhzOiPlpuftFgbNZUUgkZN);
		}

		public ControllerMapWithAxes(ControllerMapWithAxes P_0)
			: base(P_0)
		{
			zEtbpEyhzOiPlpuftFgbNZUUgkZN = new AList<ActionElementMap>();
			NMhBprGOhnJBpHhQyokSlGNAuFuh = new ReadOnlyCollection<ActionElementMap>(zEtbpEyhzOiPlpuftFgbNZUUgkZN);
			ControllerMap.lRmYCoCSmOckdAxZaAzbXHOzxRbC();
			if (P_0.zEtbpEyhzOiPlpuftFgbNZUUgkZN != null)
			{
				int count = P_0.zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count;
				for (int i = 0; i < count; i++)
				{
					fjZuiuYPbmujFZHnQzJzBqINjdgH(new ActionElementMap(P_0.zEtbpEyhzOiPlpuftFgbNZUUgkZN[i]));
				}
			}
			ControllerMap.GHMgTTbTNZrCoRvrTvpOrmMMxTwr();
		}

		public override bool ContainsAction(int actionId)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return false;
			}
			if (base.ContainsAction(actionId))
			{
				return true;
			}
			if (zEtbpEyhzOiPlpuftFgbNZUUgkZN == null)
			{
				return false;
			}
			int count = zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count;
			for (int i = 0; i < count; i++)
			{
				if (zEtbpEyhzOiPlpuftFgbNZUUgkZN[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		public override bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				result = null;
				return false;
			}
			if (base.CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!szpwtDafjgIRFJCIdmuRRhwGzyuo(elementType))
			{
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange, invert);
			BakeElementMap(actionElementMap);
			fjZuiuYPbmujFZHnQzJzBqINjdgH(actionElementMap);
			result = actionElementMap;
			return true;
		}

		public override bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				result = null;
				return false;
			}
			if (base.ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!szpwtDafjgIRFJCIdmuRRhwGzyuo(elementType))
			{
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				return false;
			}
			if (!szpwtDafjgIRFJCIdmuRRhwGzyuo(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap.elementType = ControllerElementType.Axis;
				fjZuiuYPbmujFZHnQzJzBqINjdgH(elementMap);
			}
			if (iOnHwCxnwsvTUyBzkhoCxBRTNjVD(elementMapId) < 0)
			{
				return false;
			}
			ControllerMap.lOevVLipIpvXFMfnghcFUOdDBQveA(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			BakeElementMap(elementMap);
			result = elementMap;
			wqUbVrvNAvlRNTnEOwsqHTzxozGC();
			return true;
		}

		public override bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return false;
			}
			if (base.DeleteElementMap(elementMapId))
			{
				return true;
			}
			int num = iOnHwCxnwsvTUyBzkhoCxBRTNjVD(elementMapId);
			if (num < 0)
			{
				return false;
			}
			PBtViDvPkFAEREKMYWaNOSrfJEIib(elementMapId, num);
			return true;
		}

		public override bool DeleteElementMapsWithAction(string actionName)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return false;
			}
			return DeleteElementMapsWithAction(ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName));
		}

		public override bool DeleteElementMapsWithAction(int actionId)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return false;
			}
			return base.DeleteElementMapsWithAction(actionId) | DeleteAxisMapsWithAction(actionId);
		}

		public override ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			ActionElementMap elementMap = base.GetElementMap(elementMapId);
			if (elementMap != null)
			{
				return elementMap;
			}
			if (zEtbpEyhzOiPlpuftFgbNZUUgkZN == null)
			{
				return null;
			}
			int count = zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count;
			for (int i = 0; i < count; i++)
			{
				if (zEtbpEyhzOiPlpuftFgbNZUUgkZN[i].ZwmcQAFJNCcNOFRJeAGabSeBNAxXc == elementMapId)
				{
					return zEtbpEyhzOiPlpuftFgbNZUUgkZN[i];
				}
			}
			return null;
		}

		public override ActionElementMap GetFirstElementMapWithAction(int actionId)
		{
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps: false);
		}

		public override ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			if (actionId < 0)
			{
				return null;
			}
			ActionElementMap firstElementMapWithAction = base.GetFirstElementMapWithAction(actionId, skipDisabledMaps);
			if (firstElementMapWithAction != null)
			{
				return firstElementMapWithAction;
			}
			int count = zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = zEtbpEyhzOiPlpuftFgbNZUUgkZN[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		internal virtual ActionElementMap kMVMXZkxQRCKHgfDIkSOvcdcEFpAA(Predicate<ActionElementMap> P_0, bool P_1)
		{
			ActionElementMap actionElementMap = base.NSrZjJPDZBduYBMKyAFTNUXLREhHA(P_0, P_1);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			return MEDYRwKbwRaNnNEDuEVqrehpuFTS(P_0, P_1);
		}

		internal virtual int dhrSynFNuBIxAMQAatipbeOXWpZm(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return base.ViQqHmWScxNhOhnEHAXOSVscwawX(P_0, P_1, P_2, P_3) + RxmEChjkuxkMmLAuITGUFPIWnCgCA(P_0, P_1, P_2, true);
		}

		public override void ClearElementMaps()
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return;
			}
			base.ClearElementMaps();
			zEtbpEyhzOiPlpuftFgbNZUUgkZN.Clear();
		}

		public ActionElementMap GetAxisMap(int index)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			if (zEtbpEyhzOiPlpuftFgbNZUUgkZN == null || index < 0 || index >= zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count)
			{
				return null;
			}
			return zEtbpEyhzOiPlpuftFgbNZUUgkZN[index];
		}

		public ActionElementMap[] GetAxisMaps()
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMaps(skipDisabledMaps: false);
		}

		public ActionElementMap[] GetAxisMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return EmptyObjects<ActionElementMap>.array;
			}
			if (!skipDisabledMaps)
			{
				return ListTools.ToArray(zEtbpEyhzOiPlpuftFgbNZUUgkZN);
			}
			int num = axisMapCount;
			List<ActionElementMap> list = new List<ActionElementMap>(num);
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = zEtbpEyhzOiPlpuftFgbNZUUgkZN[i];
				if (actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		public int GetAxisMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			return KQYFWuhfztJzkuxBXitSyvildIzT(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetAxisMapsWithAction(string actionName)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.vMoFsVlrywxRswyFZUiwaCMiXuhJ(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMapsWithAction(inputAction.id);
		}

		public ActionElementMap[] GetAxisMapsWithAction(int actionId)
		{
			return GetAxisMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetAxisMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.vMoFsVlrywxRswyFZUiwaCMiXuhJ(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetAxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return EmptyObjects<ActionElementMap>.array;
			}
			if (actionId < 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = axisMapCount;
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = zEtbpEyhzOiPlpuftFgbNZUUgkZN[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
				{
					num2++;
				}
			}
			if (num2 == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			ActionElementMap[] array = new ActionElementMap[num2];
			int num3 = 0;
			for (int j = 0; j < num; j++)
			{
				ActionElementMap actionElementMap2 = zEtbpEyhzOiPlpuftFgbNZUUgkZN[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
				{
					array[num3] = actionElementMap2;
					num3++;
				}
			}
			return array;
		}

		public int GetAxisMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			InputAction inputAction = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.vMoFsVlrywxRswyFZUiwaCMiXuhJ(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				return 0;
			}
			return GetAxisMapsWithAction(inputAction.id, results);
		}

		public int GetAxisMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetAxisMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetAxisMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			InputAction inputAction = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.vMoFsVlrywxRswyFZUiwaCMiXuhJ(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				return 0;
			}
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			return zBsMPUoxyhorlaxaYJdHqcIpmvQg(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			return AxisMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId)
		{
			return AxisMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			return AxisMapsWithAction(actionId, skipDisabledMaps);
		}

		[IteratorStateMachine(typeof(HrdqbmlPYcAHCWtBPvRYBPibDvFhA))]
		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new HrdqbmlPYcAHCWtBPvRYBPibDvFhA(-2)
			{
				QeWKoaBCXrvBmAIQxtcGPiLlBDsjA = this,
				AYsXlVGBdyNjygIBRKpWrkeXFDJkA = actionId,
				YsEMuljodrLtYUqVqrldGBddVuJF = skipDisabledMaps
			};
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			return GetFirstAxisMapWithAction(actionId);
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			if (actionId < 0)
			{
				return null;
			}
			IList<ActionElementMap> axisMaps = AxisMaps;
			int count = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = axisMaps[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstAxisMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			return MEDYRwKbwRaNnNEDuEVqrehpuFTS(predicate, false);
		}

		internal ActionElementMap MEDYRwKbwRaNnNEDuEVqrehpuFTS(Predicate<ActionElementMap> P_0, bool P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			IList<ActionElementMap> axisMaps = AxisMaps;
			int num = axisMapCount;
			try
			{
				for (int i = 0; i < num; i++)
				{
					ActionElementMap actionElementMap = axisMaps[i];
					if ((!P_1 || actionElementMap.enabled) && P_0(actionElementMap))
					{
						return actionElementMap;
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetFirstAxisMapMatch", exception);
			}
			return null;
		}

		public int GetAxisMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			return RxmEChjkuxkMmLAuITGUFPIWnCgCA(predicate, false, results, false);
		}

		internal int RxmEChjkuxkMmLAuITGUFPIWnCgCA(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			if (P_2 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = 0;
			if (!P_3)
			{
				P_2.Clear();
			}
			else
			{
				num = P_2.Count;
			}
			IList<ActionElementMap> axisMaps = AxisMaps;
			int num2 = axisMapCount;
			try
			{
				for (int i = 0; i < num2; i++)
				{
					ActionElementMap actionElementMap = axisMaps[i];
					if ((!P_1 || actionElementMap.enabled) && P_0(actionElementMap))
					{
						P_2.Add(actionElementMap);
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetAxisMapMatches", exception);
			}
			return P_2.Count - num;
		}

		public void ForEachAxisMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return;
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			int count = zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = zEtbpEyhzOiPlpuftFgbNZUUgkZN[i];
					if (predicate(obj))
					{
						actionToPerform(obj);
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.ForEachAxisMapMatch", exception);
			}
		}

		public bool DeleteAxisMapsWithAction(string actionName)
		{
			return DeleteAxisMapsWithAction(ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName));
		}

		public bool DeleteAxisMapsWithAction(int actionId)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return false;
			}
			if (actionId < 0)
			{
				return false;
			}
			int num = axisMapCount;
			if (num == 0)
			{
				return false;
			}
			bool result = false;
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				if (zEtbpEyhzOiPlpuftFgbNZUUgkZN[num2] != null && zEtbpEyhzOiPlpuftFgbNZUUgkZN[num2]._actionId == actionId)
				{
					PBtViDvPkFAEREKMYWaNOSrfJEIib(zEtbpEyhzOiPlpuftFgbNZUUgkZN[num2].ZwmcQAFJNCcNOFRJeAGabSeBNAxXc, num2);
					result = true;
				}
			}
			return result;
		}

		public int SetAllAxisMapsEnabled(bool state)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			int num = 0;
			int count = zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = zEtbpEyhzOiPlpuftFgbNZUUgkZN[i];
				if (actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA != state)
				{
					actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA = state;
					num++;
				}
			}
			return num;
		}

		public override bool DoesElementAssignmentConflict(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return false;
			}
			if (controllerMap == null)
			{
				return false;
			}
			if (base.DoesElementAssignmentConflict(controllerMap, skipDisabledMaps))
			{
				return true;
			}
			if (!(controllerMap is ControllerMapWithAxes controllerMapWithAxes))
			{
				return false;
			}
			if (skipDisabledMaps && (!_enabled || !controllerMapWithAxes._enabled))
			{
				return false;
			}
			if (zEtbpEyhzOiPlpuftFgbNZUUgkZN == null)
			{
				return false;
			}
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			if (axisMaps == null)
			{
				return false;
			}
			int count = zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = zEtbpEyhzOiPlpuftFgbNZUUgkZN[i];
				if (skipDisabledMaps && !actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA)
				{
					continue;
				}
				for (int j = 0; j < count2; j++)
				{
					ActionElementMap actionElementMap2 = axisMaps[j];
					if ((!skipDisabledMaps || actionElementMap2.KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public override bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return false;
			}
			if (actionElementMap == null)
			{
				return false;
			}
			if (base.DoesElementAssignmentConflict(actionElementMap, skipDisabledMaps))
			{
				return true;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
			{
				return false;
			}
			if (zEtbpEyhzOiPlpuftFgbNZUUgkZN == null)
			{
				return false;
			}
			for (int i = 0; i < zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count; i++)
			{
				ActionElementMap actionElementMap2 = zEtbpEyhzOiPlpuftFgbNZUUgkZN[i];
				if ((!skipDisabledMaps || actionElementMap2.KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		public override bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return false;
			}
			if (base.DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps))
			{
				return true;
			}
			if (skipDisabledMaps && !_enabled)
			{
				return false;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.FullAxis && conflictCheck.elementAssignmentType != ElementAssignmentType.SplitAxis)
			{
				return false;
			}
			if (zEtbpEyhzOiPlpuftFgbNZUUgkZN == null)
			{
				return false;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			for (int i = 0; i < zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count; i++)
			{
				ActionElementMap actionElementMap = zEtbpEyhzOiPlpuftFgbNZUUgkZN[i];
				if ((!skipDisabledMaps || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && actionElementMap.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(HUwKBoVpJdedVImkYLAARbSgngoS))]
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			return new HUwKBoVpJdedVImkYLAARbSgngoS(-2)
			{
				LGmrutGIiGNegvLqMsNZpkNEqXZJ = this,
				MsWGjKdPBwONfiIxHhkwKyHZGaWK = controllerMap,
				apEwEdNgZTGqqjEghWLNwnDSuhBC = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(UPvKDLHFxyWUscIFtrJDJlVshoZH))]
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			return new UPvKDLHFxyWUscIFtrJDJlVshoZH(-2)
			{
				slXrPDpJXBBBzGLKutNmIAAtiABA = this,
				sRgyNDQpgtiXGFirasCQpDzYZUaeA = actionElementMap,
				jMXWmDTpzWNpKQNmxmsLxKQAasn = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(svEHmFnMUXBcEGHlNfBotcYGeJWdA))]
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			return new svEHmFnMUXBcEGHlNfBotcYGeJWdA(-2)
			{
				RgaBxpHTySXEVlZinpkFKzKIGTFCA = this,
				zYsvZuGbfeXsSnCJwBaCOdUYRMbi = conflictCheck,
				XhgDSrSHETgtrgUPikmSgnEDDnJy = skipDisabledMaps
			};
		}

		public override int RemoveElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			if (controllerMap == null)
			{
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(controllerMap, skipDisabledMaps);
			if (!(controllerMap is ControllerMapWithAxes controllerMapWithAxes))
			{
				return num;
			}
			if (skipDisabledMaps && (!_enabled || !controllerMapWithAxes._enabled))
			{
				return num;
			}
			if (zEtbpEyhzOiPlpuftFgbNZUUgkZN == null)
			{
				return num;
			}
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			if (axisMaps == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			_ = zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count;
			int count = axisMaps.Count;
			for (int num2 = zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = zEtbpEyhzOiPlpuftFgbNZUUgkZN[num2];
				if (!skipDisabledMaps || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA)
				{
					for (int i = 0; i < count; i++)
					{
						ActionElementMap actionElementMap2 = axisMaps[i];
						if ((!skipDisabledMaps || actionElementMap2.KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
						{
							PBtViDvPkFAEREKMYWaNOSrfJEIib(actionElementMap.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc, num2);
							num++;
							break;
						}
					}
				}
			}
			return num;
		}

		public override int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(actionElementMap, skipDisabledMaps);
			if (skipDisabledMaps && (!_enabled || !actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			if (zEtbpEyhzOiPlpuftFgbNZUUgkZN == null)
			{
				return num;
			}
			for (int num2 = zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = zEtbpEyhzOiPlpuftFgbNZUUgkZN[num2];
				if ((!skipDisabledMaps || actionElementMap2.KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					PBtViDvPkFAEREKMYWaNOSrfJEIib(actionElementMap2.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc, num2);
					num++;
				}
			}
			return num;
		}

		public override int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps);
			if (skipDisabledMaps && !_enabled)
			{
				return num;
			}
			if (zEtbpEyhzOiPlpuftFgbNZUUgkZN == null)
			{
				return num;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.FullAxis && conflictCheck.elementAssignmentType != ElementAssignmentType.SplitAxis)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			for (int num2 = zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = zEtbpEyhzOiPlpuftFgbNZUUgkZN[num2];
				if ((!skipDisabledMaps || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && actionElementMap.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					PBtViDvPkFAEREKMYWaNOSrfJEIib(actionElementMap.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc, num2);
					num++;
				}
			}
			return num;
		}

		internal virtual int rakhLIRaeSmxhbtFFpMMLlCsNbew(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.SJDSKtDjzvpmHSjUMqbaQhsuKinu(P_0, P_1, P_2, P_3);
			if (!(P_0 is ControllerMapWithAxes controllerMapWithAxes))
			{
				return num;
			}
			if (P_1 && (!_enabled || !controllerMapWithAxes._enabled))
			{
				return num;
			}
			if (zEtbpEyhzOiPlpuftFgbNZUUgkZN == null)
			{
				return num;
			}
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			if (axisMaps == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int count = zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = zEtbpEyhzOiPlpuftFgbNZUUgkZN[i];
				if (!actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA)
				{
					continue;
				}
				for (int j = 0; j < count2; j++)
				{
					ActionElementMap actionElementMap2 = axisMaps[j];
					if ((!P_1 || actionElementMap2.KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						actionElementMap.enabled = false;
						P_2?.Add(actionElementMap);
						num++;
						break;
					}
				}
			}
			return num;
		}

		internal virtual int BngVHdIVTdSpaWbDuAeucPBAMAzvA(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.ENwaWcDXgcpQoycGjOSWKYNmEVtP(P_0, P_1, P_2, P_3);
			if (P_0 == null)
			{
				return num;
			}
			if (P_1 && (!_enabled || !P_0.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
			{
				return num;
			}
			if (P_0.elementIdentifierId < 0)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			int num2 = axisMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = zEtbpEyhzOiPlpuftFgbNZUUgkZN[i];
				if (actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA && P_0.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual int oOMvulaLHteaLCCmHJUmsAPnknhq(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.mVGdaCFqXulnKnVLNgZpLfBpQtJL(P_0, P_1, P_2, P_3);
			if (P_1 && !_enabled)
			{
				return num;
			}
			if (zEtbpEyhzOiPlpuftFgbNZUUgkZN == null)
			{
				return num;
			}
			if (P_0.elementAssignmentType != ElementAssignmentType.FullAxis && P_0.elementAssignmentType != ElementAssignmentType.SplitAxis)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			ElementAssignment elementAssignment = P_0.ToElementAssignment();
			int count = zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = zEtbpEyhzOiPlpuftFgbNZUUgkZN[i];
				if (actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA && actionElementMap.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		public string[] GetAxisNames()
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return EmptyObjects<string>.array;
			}
			int num = axisMapCount;
			if (num == 0)
			{
				return null;
			}
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = zEtbpEyhzOiPlpuftFgbNZUUgkZN[i].elementIdentifierName;
			}
			return array;
		}

		internal virtual bool XNPGqyKIMRgDuHBMUQQcouQcwlPd(ActionElementMap P_0)
		{
			if (base.sDqHEWbyPiYMwKMUolFtvnYYDxDXA(P_0))
			{
				return true;
			}
			ControllerElementType elementType = P_0._elementType;
			if (!szpwtDafjgIRFJCIdmuRRhwGzyuo(elementType))
			{
				return false;
			}
			fjZuiuYPbmujFZHnQzJzBqINjdgH(P_0);
			return true;
		}

		internal virtual int nrZTLkfGkdSZfIHZXSTaIjFaTPgy(List<ActionElementMap> P_0, bool P_1)
		{
			base.KYJJlQDnUQbhhyWAENYGgqlpAjSV(P_0, P_1);
			int count = P_0.Count;
			int count2 = zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!P_1 || zEtbpEyhzOiPlpuftFgbNZUUgkZN[i].KDuOcDwQLQHhwDRrYdOMFXnFZITxA)
				{
					P_0.Add(zEtbpEyhzOiPlpuftFgbNZUUgkZN[i]);
				}
			}
			return P_0.Count - count;
		}

		internal virtual ActionElementMap NsBAcIkVrohtWEomVaIDgnRoftMhA(int P_0, int P_1, ControllerElementType P_2)
		{
			ActionElementMap actionElementMap = base.fHnnHlRyOPPhnWZLTlCeIMSdLTrN(P_0, P_1, P_2);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (!szpwtDafjgIRFJCIdmuRRhwGzyuo(P_2))
			{
				return null;
			}
			int num = PMvJdwYtrfXnfRfpjohzKsuAgGLb(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				return zEtbpEyhzOiPlpuftFgbNZUUgkZN[num];
			}
			throw new NotImplementedException();
		}

		internal virtual int FhhKBKENGLNISuRBNWYxxIdeqjyb(int P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = (P_2 ? P_1.Count : 0);
			base.OUCEFNZhJSbeOjpjdiBRJzjTybueA(P_0, P_1, P_2);
			if (zEtbpEyhzOiPlpuftFgbNZUUgkZN == null)
			{
				return P_1.Count - num;
			}
			int count = zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count;
			for (int i = 0; i < count; i++)
			{
				if (zEtbpEyhzOiPlpuftFgbNZUUgkZN[i]._elementIdentifierId == P_0)
				{
					P_1.Add(zEtbpEyhzOiPlpuftFgbNZUUgkZN[i]);
				}
			}
			return P_1.Count - num;
		}

		internal virtual bool FHCIVWwQfyMairbijHhEDIELSoVH(int P_0, int P_1, ControllerElementType P_2)
		{
			if (base.JpGLLusuFDLYAJzsZIVOLaoFuptb(P_0, P_1, P_2))
			{
				return true;
			}
			if (!szpwtDafjgIRFJCIdmuRRhwGzyuo(P_2))
			{
				return false;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count;
				for (int i = 0; i < count; i++)
				{
					if (zEtbpEyhzOiPlpuftFgbNZUUgkZN[i]._elementIdentifierId == P_0 && zEtbpEyhzOiPlpuftFgbNZUUgkZN[i]._actionId == P_1)
					{
						return true;
					}
				}
				return false;
			}
			throw new NotImplementedException();
		}

		internal virtual int DNOyZITfvYJfGUzpjRVnDYLvnAjd(int P_0, int P_1, ControllerElementType P_2)
		{
			int num = base.PMvJdwYtrfXnfRfpjohzKsuAgGLb(P_0, P_1, P_2);
			if (num >= 0)
			{
				return num;
			}
			if (!szpwtDafjgIRFJCIdmuRRhwGzyuo(P_2))
			{
				return -1;
			}
			if (zEtbpEyhzOiPlpuftFgbNZUUgkZN == null)
			{
				return -1;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count;
				for (int i = 0; i < count; i++)
				{
					if (zEtbpEyhzOiPlpuftFgbNZUUgkZN[i]._elementIdentifierId == P_0 && zEtbpEyhzOiPlpuftFgbNZUUgkZN[i]._actionId == P_1)
					{
						return i;
					}
				}
				return -1;
			}
			throw new NotImplementedException();
		}

		internal int iOnHwCxnwsvTUyBzkhoCxBRTNjVD(int P_0)
		{
			if (zEtbpEyhzOiPlpuftFgbNZUUgkZN == null)
			{
				return -1;
			}
			int count = zEtbpEyhzOiPlpuftFgbNZUUgkZN.Count;
			for (int i = 0; i < count; i++)
			{
				if (zEtbpEyhzOiPlpuftFgbNZUUgkZN[i].ZwmcQAFJNCcNOFRJeAGabSeBNAxXc == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal int KQYFWuhfztJzkuxBXitSyvildIzT(bool P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_2)
			{
				P_1.Clear();
			}
			int num = axisMapCount;
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = zEtbpEyhzOiPlpuftFgbNZUUgkZN[i];
				if (!P_0 || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA)
				{
					P_1.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal int zBsMPUoxyhorlaxaYJdHqcIpmvQg(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			int num = axisMapCount;
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = zEtbpEyhzOiPlpuftFgbNZUUgkZN[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
				{
					P_2.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal virtual int aaYelKVjMCrZCEHhwVYnNZsksOHp(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.cAwvQRajuNSdcVfCIbMQuiDVTnmt(P_0, P_1, P_2, P_3);
			if (P_0 < 0)
			{
				return num;
			}
			int num2 = axisMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = zEtbpEyhzOiPlpuftFgbNZUUgkZN[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
				{
					P_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual ActionElementMap HLjrPubKCeuxRQGfkLAbCkulGxTaA(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			ActionElementMap actionElementMap = base.rLYedBCsdtfUPGpuxQjkUgoLtSyKA(P_0, P_1, P_2, P_3, out P_4);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (P_4)
			{
				return null;
			}
			if (!szpwtDafjgIRFJCIdmuRRhwGzyuo(P_0.elementType))
			{
				return null;
			}
			int num = axisMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num; i++)
			{
				if ((!P_1 || zEtbpEyhzOiPlpuftFgbNZUUgkZN[i]._actionId == P_2) && (!P_3 || zEtbpEyhzOiPlpuftFgbNZUUgkZN[i].KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && zEtbpEyhzOiPlpuftFgbNZUUgkZN[i].IsTarget(P_0))
				{
					return zEtbpEyhzOiPlpuftFgbNZUUgkZN[i];
				}
			}
			return null;
		}

		internal virtual int JEgHHrRdSJBgLAreBKkhhNnDGdHCb(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
		{
			int num = base.GkqChYlZGQOzIisFIMtpFCNiEOLd(P_0, P_1, P_2, P_3, P_4, P_5, out P_6);
			if (P_6)
			{
				return num;
			}
			if (!szpwtDafjgIRFJCIdmuRRhwGzyuo(P_0.elementType))
			{
				return num;
			}
			int num2 = axisMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num2; i++)
			{
				if ((!P_1 || zEtbpEyhzOiPlpuftFgbNZUUgkZN[i]._actionId == P_2) && (!P_3 || zEtbpEyhzOiPlpuftFgbNZUUgkZN[i].KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && zEtbpEyhzOiPlpuftFgbNZUUgkZN[i].IsTarget(P_0))
				{
					P_4.Add(zEtbpEyhzOiPlpuftFgbNZUUgkZN[i]);
					num++;
				}
			}
			return num;
		}

		internal virtual bool WuGWNqEviUoyedEyGlTPdykpVFRU(ActionElementMap P_0)
		{
			if (base.peOcNMbNqkWzcKHHCLVaSANBAxWAA(P_0))
			{
				return true;
			}
			if (P_0 == null)
			{
				return false;
			}
			if (!szpwtDafjgIRFJCIdmuRRhwGzyuo(P_0._elementType))
			{
				return false;
			}
			zEtbpEyhzOiPlpuftFgbNZUUgkZN.Add(P_0);
			dqdTKZnNqADmqKijgGQugOoGVLjIA(P_0);
			return true;
		}

		private bool szpwtDafjgIRFJCIdmuRRhwGzyuo(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Axis)
			{
				return false;
			}
			return true;
		}

		private void PBtViDvPkFAEREKMYWaNOSrfJEIib(int P_0, int P_1)
		{
			vkdkLIdgkmqhzclcMPgXqkmXpnNL(P_0);
			if (P_1 >= 0 && P_1 < axisMapCount)
			{
				zEtbpEyhzOiPlpuftFgbNZUUgkZN.RemoveAt(P_1);
			}
		}

		private void fjZuiuYPbmujFZHnQzJzBqINjdgH(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				zEtbpEyhzOiPlpuftFgbNZUUgkZN.Add(P_0);
				dqdTKZnNqADmqKijgGQugOoGVLjIA(P_0);
			}
		}

		private void hysvwprLvXorieFGXfuiSdSDFRkjA(ActionElementMap P_0, int P_1)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < axisMapCount)
			{
				HktKLlwzinhTipeznBGSbGPmJtafb(zEtbpEyhzOiPlpuftFgbNZUUgkZN[P_1].ZwmcQAFJNCcNOFRJeAGabSeBNAxXc, P_0);
				zEtbpEyhzOiPlpuftFgbNZUUgkZN[P_1] = P_0;
			}
		}

		internal virtual void oclBqZnltzcDCiELvAVJuBBTEJpq(SerializedObject P_0)
		{
			base.TjYYzAvYaCXBvfPYwRHuiHnMpIU(P_0);
			int num = axisMapCount;
			List<object> list = new List<object>();
			P_0.Add("axisMaps", list);
			for (int i = 0; i < num; i++)
			{
				if (zEtbpEyhzOiPlpuftFgbNZUUgkZN[i] != null)
				{
					list.Add(zEtbpEyhzOiPlpuftFgbNZUUgkZN[i].RcsRHzgGloagFZmXHxLUSERKfrzZ());
				}
			}
		}

		internal virtual bool cypZVpWHnwPWWnHyQSATYddFZTOb(SerializedObject P_0)
		{
			bool flag = base.mzuFctNdLWIzjUTtnfaDPZneMaWd(P_0);
			if (!flag)
			{
				ClearElementMaps();
				flag = true;
			}
			SerializedObject value = null;
			if (P_0.TryGetDeserializedValueByRef("axisMaps", ref value) && value != null)
			{
				for (int i = 0; i < value.count; i++)
				{
					if (value.TryGetDeserializedValue<SerializedObject>(i, out var value2) || value2 == null)
					{
						ActionElementMap actionElementMap = new ActionElementMap();
						actionElementMap.ZNvvGNYySdbNFoPsGmVngIzJvSeR(value2);
						if (ActionElementMap.VdmsOtoEsMwzdRcQfykDcBXVxTkW(actionElementMap))
						{
							fjZuiuYPbmujFZHnQzJzBqINjdgH(actionElementMap);
						}
					}
				}
			}
			wqUbVrvNAvlRNTnEOwsqHTzxozGC();
			return flag;
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> XjlSuWVeDhungirTNuOukbCHTLv(ControllerMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> gNopMCpLywNuvLDplcmKgsEMWuTj(ActionElementMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> qsvcpVkSDSSSUzbukKoHdvKOPBBS(ElementAssignmentConflictCheck P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}
	}
}
