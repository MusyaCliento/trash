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
	public abstract class ControllerMap
	{
		private class wWWhYpqIlazmCqqnQjIAokOnxeml : IComparer<ActionElementMap>
		{
			public static wWWhYpqIlazmCqqnQjIAokOnxeml dpWZpVuGixgUdJBnEjgqSiSQkXbL;

			public static wWWhYpqIlazmCqqnQjIAokOnxeml cYlBujxUeNFdEBngsbNrfseJPwZqA => dpWZpVuGixgUdJBnEjgqSiSQkXbL ?? (dpWZpVuGixgUdJBnEjgqSiSQkXbL = new wWWhYpqIlazmCqqnQjIAokOnxeml());

			public int Compare(ActionElementMap x, ActionElementMap y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				if (y == null)
				{
					return 1;
				}
				if (x._elementType == y._elementType)
				{
					return x.id.CompareTo(y.id);
				}
				if (x._elementType switch
				{
					ControllerElementType.Button => 0, 
					ControllerElementType.Axis => 1, 
					ControllerElementType.CompoundElement => 2, 
					_ => throw new NotImplementedException(), 
				} <= y._elementType switch
				{
					ControllerElementType.Button => 0, 
					ControllerElementType.Axis => 1, 
					ControllerElementType.CompoundElement => 2, 
					_ => throw new NotImplementedException(), 
				})
				{
					return -1;
				}
				return 1;
			}

			int IComparer<ActionElementMap>.Compare(ActionElementMap x, ActionElementMap y)
			{
				//ILSpy generated this explicit interface implementation from .override directive in Compare
				return this.Compare(x, y);
			}
		}

		private sealed class uxPYvBxbUSfMUcHCSbaahWOjKpYv : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int XHZypMLpmkuxwsnFZjtxWNwsvtMs;

			private ActionElementMap nyClhheUVArUHnqImyLREBPjkMaE;

			private int PqsadtFfftQVjvtplqpjinSrIzpIA;

			public ControllerMap dOLgJqSgUjvOFsNJnFNyVQgapUDF;

			private int kScLyaANNnOsDrprvdQEgrZqNesIA;

			public int THtAItBEdFOZsSxbCTpOVixSDTQsA;

			private bool VWdToSazKCiJxWwWgReFvryahxjM;

			public bool JKMrkYLdDNtDUeAYuGcVatJHVLPOA;

			private IList<ActionElementMap> jfVTSAbvElvTKTNyEEepvQqvCDvb;

			private int yuONJCjYSdnWQbOFCpKKRWlCEsAX;

			private int yvHyFoxOqzOstMcakkHFrpPvHzPe;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return nyClhheUVArUHnqImyLREBPjkMaE;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return nyClhheUVArUHnqImyLREBPjkMaE;
				}
			}

			[DebuggerHidden]
			public uxPYvBxbUSfMUcHCSbaahWOjKpYv(int P_0)
			{
				XHZypMLpmkuxwsnFZjtxWNwsvtMs = P_0;
				PqsadtFfftQVjvtplqpjinSrIzpIA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				jfVTSAbvElvTKTNyEEepvQqvCDvb = null;
				XHZypMLpmkuxwsnFZjtxWNwsvtMs = -2;
			}

			private bool MoveNext()
			{
				int xHZypMLpmkuxwsnFZjtxWNwsvtMs = XHZypMLpmkuxwsnFZjtxWNwsvtMs;
				ControllerMap controllerMap = dOLgJqSgUjvOFsNJnFNyVQgapUDF;
				if (xHZypMLpmkuxwsnFZjtxWNwsvtMs != 0)
				{
					if (xHZypMLpmkuxwsnFZjtxWNwsvtMs != 1)
					{
						return false;
					}
					XHZypMLpmkuxwsnFZjtxWNwsvtMs = -1;
					goto IL_00af;
				}
				XHZypMLpmkuxwsnFZjtxWNwsvtMs = -1;
				if (ReInput._id != controllerMap.HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(controllerMap.HGKnnYgsStSHzmTMXitKKPatJYAf);
					return false;
				}
				if (kScLyaANNnOsDrprvdQEgrZqNesIA < 0)
				{
					return false;
				}
				jfVTSAbvElvTKTNyEEepvQqvCDvb = controllerMap.ButtonMaps;
				yuONJCjYSdnWQbOFCpKKRWlCEsAX = controllerMap.buttonMapCount;
				yvHyFoxOqzOstMcakkHFrpPvHzPe = 0;
				goto IL_00bf;
				IL_00bf:
				if (yvHyFoxOqzOstMcakkHFrpPvHzPe < yuONJCjYSdnWQbOFCpKKRWlCEsAX)
				{
					ActionElementMap actionElementMap = jfVTSAbvElvTKTNyEEepvQqvCDvb[yvHyFoxOqzOstMcakkHFrpPvHzPe];
					if (actionElementMap._actionId == kScLyaANNnOsDrprvdQEgrZqNesIA && (!VWdToSazKCiJxWwWgReFvryahxjM || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
					{
						nyClhheUVArUHnqImyLREBPjkMaE = actionElementMap;
						XHZypMLpmkuxwsnFZjtxWNwsvtMs = 1;
						return true;
					}
					goto IL_00af;
				}
				return false;
				IL_00af:
				yvHyFoxOqzOstMcakkHFrpPvHzPe++;
				goto IL_00bf;
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
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				uxPYvBxbUSfMUcHCSbaahWOjKpYv uxPYvBxbUSfMUcHCSbaahWOjKpYv2;
				if (XHZypMLpmkuxwsnFZjtxWNwsvtMs == -2 && PqsadtFfftQVjvtplqpjinSrIzpIA == Environment.CurrentManagedThreadId)
				{
					XHZypMLpmkuxwsnFZjtxWNwsvtMs = 0;
					uxPYvBxbUSfMUcHCSbaahWOjKpYv2 = this;
				}
				else
				{
					uxPYvBxbUSfMUcHCSbaahWOjKpYv2 = new uxPYvBxbUSfMUcHCSbaahWOjKpYv(0);
					uxPYvBxbUSfMUcHCSbaahWOjKpYv2.dOLgJqSgUjvOFsNJnFNyVQgapUDF = dOLgJqSgUjvOFsNJnFNyVQgapUDF;
				}
				uxPYvBxbUSfMUcHCSbaahWOjKpYv2.kScLyaANNnOsDrprvdQEgrZqNesIA = THtAItBEdFOZsSxbCTpOVixSDTQsA;
				uxPYvBxbUSfMUcHCSbaahWOjKpYv2.VWdToSazKCiJxWwWgReFvryahxjM = JKMrkYLdDNtDUeAYuGcVatJHVLPOA;
				return uxPYvBxbUSfMUcHCSbaahWOjKpYv2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class besLTDxtowbfinFMHdIenMLjtBkT : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int UmYXKosiTKObwHWdvSStFFrrZvJC;

			private ElementAssignmentConflictInfo oTJRDZLEgfnUsZqDKdvbHWUCOBAP;

			private int wOTIKCFxEDqWQzeDMmDNkfiBrixK;

			public ControllerMap wGEWhgBFQZAgkiFJMPcenOYzlKRW;

			private ControllerMap FEXonGagLffHAcBgfBOHblgWrnbP;

			public ControllerMap EvbjBIrSlKAMehBSYqXMJBCpBKOE;

			private bool fxExfgNFRyWpxucKcBmoIRDopcyvA;

			public bool eDqiwueYtDVkyRUUqFrVxsBgtMzJA;

			private IList<ActionElementMap> gwCWubfkWmeMgbDoKEoaqvjNKNaOA;

			private int xcjayeERBRwepqEVZBqXCIwtAjyr;

			private int oCexGEpGsvFKWzkyFwDDqVYNCHhe;

			private ActionElementMap cqwcPGgAWLvFrvYhbAbRGiMFRYuRB;

			private int mtnEToDdeIpAZtMdGOxZMTbrzzhM;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return oTJRDZLEgfnUsZqDKdvbHWUCOBAP;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return oTJRDZLEgfnUsZqDKdvbHWUCOBAP;
				}
			}

			[DebuggerHidden]
			public besLTDxtowbfinFMHdIenMLjtBkT(int P_0)
			{
				UmYXKosiTKObwHWdvSStFFrrZvJC = P_0;
				wOTIKCFxEDqWQzeDMmDNkfiBrixK = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				gwCWubfkWmeMgbDoKEoaqvjNKNaOA = null;
				cqwcPGgAWLvFrvYhbAbRGiMFRYuRB = null;
				UmYXKosiTKObwHWdvSStFFrrZvJC = -2;
			}

			private bool MoveNext()
			{
				int umYXKosiTKObwHWdvSStFFrrZvJC = UmYXKosiTKObwHWdvSStFFrrZvJC;
				ControllerMap controllerMap = wGEWhgBFQZAgkiFJMPcenOYzlKRW;
				if (umYXKosiTKObwHWdvSStFFrrZvJC != 0)
				{
					if (umYXKosiTKObwHWdvSStFFrrZvJC != 1)
					{
						return false;
					}
					UmYXKosiTKObwHWdvSStFFrrZvJC = -1;
					goto IL_019c;
				}
				UmYXKosiTKObwHWdvSStFFrrZvJC = -1;
				if (ReInput._id != controllerMap.HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(controllerMap.HGKnnYgsStSHzmTMXitKKPatJYAf);
					return false;
				}
				if (FEXonGagLffHAcBgfBOHblgWrnbP == null || controllerMap.xhimarnxTkdcASkSXJKYCZuEUIAA == null)
				{
					return false;
				}
				if (fxExfgNFRyWpxucKcBmoIRDopcyvA && (!controllerMap._enabled || !FEXonGagLffHAcBgfBOHblgWrnbP._enabled))
				{
					return false;
				}
				gwCWubfkWmeMgbDoKEoaqvjNKNaOA = FEXonGagLffHAcBgfBOHblgWrnbP.ButtonMaps;
				if (gwCWubfkWmeMgbDoKEoaqvjNKNaOA == null)
				{
					return false;
				}
				xcjayeERBRwepqEVZBqXCIwtAjyr = gwCWubfkWmeMgbDoKEoaqvjNKNaOA.Count;
				oCexGEpGsvFKWzkyFwDDqVYNCHhe = 0;
				goto IL_01d4;
				IL_01d4:
				if (oCexGEpGsvFKWzkyFwDDqVYNCHhe < controllerMap.xhimarnxTkdcASkSXJKYCZuEUIAA.Count)
				{
					cqwcPGgAWLvFrvYhbAbRGiMFRYuRB = controllerMap.xhimarnxTkdcASkSXJKYCZuEUIAA[oCexGEpGsvFKWzkyFwDDqVYNCHhe];
					if (!fxExfgNFRyWpxucKcBmoIRDopcyvA || cqwcPGgAWLvFrvYhbAbRGiMFRYuRB.KDuOcDwQLQHhwDRrYdOMFXnFZITxA)
					{
						mtnEToDdeIpAZtMdGOxZMTbrzzhM = 0;
						goto IL_01ac;
					}
					goto IL_01c4;
				}
				return false;
				IL_01ac:
				if (mtnEToDdeIpAZtMdGOxZMTbrzzhM < xcjayeERBRwepqEVZBqXCIwtAjyr)
				{
					ActionElementMap actionElementMap = gwCWubfkWmeMgbDoKEoaqvjNKNaOA[mtnEToDdeIpAZtMdGOxZMTbrzzhM];
					if ((!fxExfgNFRyWpxucKcBmoIRDopcyvA || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && cqwcPGgAWLvFrvYhbAbRGiMFRYuRB.CheckForAssignmentConflict(actionElementMap))
					{
						oTJRDZLEgfnUsZqDKdvbHWUCOBAP = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMap._categoryId).userAssignable, -1, controllerMap._controllerType, controllerMap._controllerId, controllerMap._id, cqwcPGgAWLvFrvYhbAbRGiMFRYuRB.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc, cqwcPGgAWLvFrvYhbAbRGiMFRYuRB._actionId, cqwcPGgAWLvFrvYhbAbRGiMFRYuRB._elementType, cqwcPGgAWLvFrvYhbAbRGiMFRYuRB._elementIdentifierId, cqwcPGgAWLvFrvYhbAbRGiMFRYuRB.keyCode, cqwcPGgAWLvFrvYhbAbRGiMFRYuRB.modifierKeyFlags);
						UmYXKosiTKObwHWdvSStFFrrZvJC = 1;
						return true;
					}
					goto IL_019c;
				}
				cqwcPGgAWLvFrvYhbAbRGiMFRYuRB = null;
				goto IL_01c4;
				IL_01c4:
				oCexGEpGsvFKWzkyFwDDqVYNCHhe++;
				goto IL_01d4;
				IL_019c:
				mtnEToDdeIpAZtMdGOxZMTbrzzhM++;
				goto IL_01ac;
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
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				besLTDxtowbfinFMHdIenMLjtBkT besLTDxtowbfinFMHdIenMLjtBkT2;
				if (UmYXKosiTKObwHWdvSStFFrrZvJC == -2 && wOTIKCFxEDqWQzeDMmDNkfiBrixK == Environment.CurrentManagedThreadId)
				{
					UmYXKosiTKObwHWdvSStFFrrZvJC = 0;
					besLTDxtowbfinFMHdIenMLjtBkT2 = this;
				}
				else
				{
					besLTDxtowbfinFMHdIenMLjtBkT2 = new besLTDxtowbfinFMHdIenMLjtBkT(0);
					besLTDxtowbfinFMHdIenMLjtBkT2.wGEWhgBFQZAgkiFJMPcenOYzlKRW = wGEWhgBFQZAgkiFJMPcenOYzlKRW;
				}
				besLTDxtowbfinFMHdIenMLjtBkT2.FEXonGagLffHAcBgfBOHblgWrnbP = EvbjBIrSlKAMehBSYqXMJBCpBKOE;
				besLTDxtowbfinFMHdIenMLjtBkT2.fxExfgNFRyWpxucKcBmoIRDopcyvA = eDqiwueYtDVkyRUUqFrVxsBgtMzJA;
				return besLTDxtowbfinFMHdIenMLjtBkT2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class swgCaFQLBFZzkGJaIAMgboOzeKhT : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int gLEFIbYqgDmDQTjORGucaYbGcQvbb;

			private ElementAssignmentConflictInfo GgvDaaZjZelPUCRtiUVYFygzeIIr;

			private int tgMXChsASmCnMMHQevTpDySfgdEo;

			public ControllerMap ZlvUuUBUkOEYcXythTBxSMSBJiVm;

			private ActionElementMap cRqCWCFRxwMJTGlrPpyJZMlWecmU;

			public ActionElementMap uIgkKavoqYEJYfwYFCUfygXTxtBt;

			private bool WivCFJIpdAtgjQCBslzoZXptEmnqA;

			public bool XrDEfTCPQKBxoORvKDMjJcAcUigu;

			private int UfImkvpEGsgWPifDkTUeHwvnsjnFA;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return GgvDaaZjZelPUCRtiUVYFygzeIIr;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return GgvDaaZjZelPUCRtiUVYFygzeIIr;
				}
			}

			[DebuggerHidden]
			public swgCaFQLBFZzkGJaIAMgboOzeKhT(int P_0)
			{
				gLEFIbYqgDmDQTjORGucaYbGcQvbb = P_0;
				tgMXChsASmCnMMHQevTpDySfgdEo = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				gLEFIbYqgDmDQTjORGucaYbGcQvbb = -2;
			}

			private bool MoveNext()
			{
				int num = gLEFIbYqgDmDQTjORGucaYbGcQvbb;
				ControllerMap zlvUuUBUkOEYcXythTBxSMSBJiVm = ZlvUuUBUkOEYcXythTBxSMSBJiVm;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					gLEFIbYqgDmDQTjORGucaYbGcQvbb = -1;
					goto IL_0111;
				}
				gLEFIbYqgDmDQTjORGucaYbGcQvbb = -1;
				if (ReInput._id != zlvUuUBUkOEYcXythTBxSMSBJiVm.HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(zlvUuUBUkOEYcXythTBxSMSBJiVm.HGKnnYgsStSHzmTMXitKKPatJYAf);
					return false;
				}
				if (cRqCWCFRxwMJTGlrPpyJZMlWecmU == null || zlvUuUBUkOEYcXythTBxSMSBJiVm.xhimarnxTkdcASkSXJKYCZuEUIAA == null)
				{
					return false;
				}
				if (WivCFJIpdAtgjQCBslzoZXptEmnqA && (!zlvUuUBUkOEYcXythTBxSMSBJiVm._enabled || !cRqCWCFRxwMJTGlrPpyJZMlWecmU.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
				{
					return false;
				}
				UfImkvpEGsgWPifDkTUeHwvnsjnFA = 0;
				goto IL_0121;
				IL_0111:
				UfImkvpEGsgWPifDkTUeHwvnsjnFA++;
				goto IL_0121;
				IL_0121:
				if (UfImkvpEGsgWPifDkTUeHwvnsjnFA < zlvUuUBUkOEYcXythTBxSMSBJiVm.xhimarnxTkdcASkSXJKYCZuEUIAA.Count)
				{
					ActionElementMap actionElementMap = zlvUuUBUkOEYcXythTBxSMSBJiVm.xhimarnxTkdcASkSXJKYCZuEUIAA[UfImkvpEGsgWPifDkTUeHwvnsjnFA];
					if ((!WivCFJIpdAtgjQCBslzoZXptEmnqA || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && actionElementMap.CheckForAssignmentConflict(cRqCWCFRxwMJTGlrPpyJZMlWecmU))
					{
						GgvDaaZjZelPUCRtiUVYFygzeIIr = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(zlvUuUBUkOEYcXythTBxSMSBJiVm._categoryId).userAssignable, -1, zlvUuUBUkOEYcXythTBxSMSBJiVm._controllerType, zlvUuUBUkOEYcXythTBxSMSBJiVm._controllerId, zlvUuUBUkOEYcXythTBxSMSBJiVm._id, actionElementMap.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
						gLEFIbYqgDmDQTjORGucaYbGcQvbb = 1;
						return true;
					}
					goto IL_0111;
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
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				swgCaFQLBFZzkGJaIAMgboOzeKhT swgCaFQLBFZzkGJaIAMgboOzeKhT2;
				if (gLEFIbYqgDmDQTjORGucaYbGcQvbb == -2 && tgMXChsASmCnMMHQevTpDySfgdEo == Environment.CurrentManagedThreadId)
				{
					gLEFIbYqgDmDQTjORGucaYbGcQvbb = 0;
					swgCaFQLBFZzkGJaIAMgboOzeKhT2 = this;
				}
				else
				{
					swgCaFQLBFZzkGJaIAMgboOzeKhT2 = new swgCaFQLBFZzkGJaIAMgboOzeKhT(0);
					swgCaFQLBFZzkGJaIAMgboOzeKhT2.ZlvUuUBUkOEYcXythTBxSMSBJiVm = ZlvUuUBUkOEYcXythTBxSMSBJiVm;
				}
				swgCaFQLBFZzkGJaIAMgboOzeKhT2.cRqCWCFRxwMJTGlrPpyJZMlWecmU = uIgkKavoqYEJYfwYFCUfygXTxtBt;
				swgCaFQLBFZzkGJaIAMgboOzeKhT2.WivCFJIpdAtgjQCBslzoZXptEmnqA = XrDEfTCPQKBxoORvKDMjJcAcUigu;
				return swgCaFQLBFZzkGJaIAMgboOzeKhT2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class QiAbfsASEtwWMzhiJaOPXSYmMwdD : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int LGwRrQjjArLCSXkbGsgievfvvNN;

			private ElementAssignmentConflictInfo KPkRqUaLhiuhAtjyKQUHgGNWJvkb;

			private int uBaBeWgmOukqiFuhmNCznhNDlfoUA;

			public ControllerMap XwXjqZcYNFkPIBLJRBTwmCAGCRVw;

			private bool rMcpzoAdqMpRfTKOpeguIrHrfkuD;

			public bool SrZxYOZhMZeLboBojdjKUgaUZvBK;

			private ElementAssignmentConflictCheck pBxlmZQkqruVdiDniEeJFYpqaUKeA;

			public ElementAssignmentConflictCheck FepmEafZjvJkgeOnTdQjDJyLbUJEb;

			private ElementAssignment nhBCgmJdPOtjNubOxPKfbQlzVuKTA;

			private int BEWpiqjFQycXOFniHpAjsyqmxDUL;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return KPkRqUaLhiuhAtjyKQUHgGNWJvkb;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return KPkRqUaLhiuhAtjyKQUHgGNWJvkb;
				}
			}

			[DebuggerHidden]
			public QiAbfsASEtwWMzhiJaOPXSYmMwdD(int P_0)
			{
				LGwRrQjjArLCSXkbGsgievfvvNN = P_0;
				uBaBeWgmOukqiFuhmNCznhNDlfoUA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				LGwRrQjjArLCSXkbGsgievfvvNN = -2;
			}

			private bool MoveNext()
			{
				int lGwRrQjjArLCSXkbGsgievfvvNN = LGwRrQjjArLCSXkbGsgievfvvNN;
				ControllerMap xwXjqZcYNFkPIBLJRBTwmCAGCRVw = XwXjqZcYNFkPIBLJRBTwmCAGCRVw;
				if (lGwRrQjjArLCSXkbGsgievfvvNN != 0)
				{
					if (lGwRrQjjArLCSXkbGsgievfvvNN != 1)
					{
						return false;
					}
					LGwRrQjjArLCSXkbGsgievfvvNN = -1;
					goto IL_0123;
				}
				LGwRrQjjArLCSXkbGsgievfvvNN = -1;
				if (ReInput._id != xwXjqZcYNFkPIBLJRBTwmCAGCRVw.HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(xwXjqZcYNFkPIBLJRBTwmCAGCRVw.HGKnnYgsStSHzmTMXitKKPatJYAf);
					return false;
				}
				if (rMcpzoAdqMpRfTKOpeguIrHrfkuD && !xwXjqZcYNFkPIBLJRBTwmCAGCRVw._enabled)
				{
					return false;
				}
				if (xwXjqZcYNFkPIBLJRBTwmCAGCRVw.xhimarnxTkdcASkSXJKYCZuEUIAA == null)
				{
					return false;
				}
				nhBCgmJdPOtjNubOxPKfbQlzVuKTA = pBxlmZQkqruVdiDniEeJFYpqaUKeA.ToElementAssignment();
				BEWpiqjFQycXOFniHpAjsyqmxDUL = 0;
				goto IL_0133;
				IL_0133:
				if (BEWpiqjFQycXOFniHpAjsyqmxDUL < xwXjqZcYNFkPIBLJRBTwmCAGCRVw.xhimarnxTkdcASkSXJKYCZuEUIAA.Count)
				{
					ActionElementMap actionElementMap = xwXjqZcYNFkPIBLJRBTwmCAGCRVw.xhimarnxTkdcASkSXJKYCZuEUIAA[BEWpiqjFQycXOFniHpAjsyqmxDUL];
					if ((!rMcpzoAdqMpRfTKOpeguIrHrfkuD || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && actionElementMap.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc != pBxlmZQkqruVdiDniEeJFYpqaUKeA.elementMapId && actionElementMap.CheckForAssignmentConflict(nhBCgmJdPOtjNubOxPKfbQlzVuKTA))
					{
						KPkRqUaLhiuhAtjyKQUHgGNWJvkb = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(xwXjqZcYNFkPIBLJRBTwmCAGCRVw._categoryId).userAssignable, -1, xwXjqZcYNFkPIBLJRBTwmCAGCRVw._controllerType, xwXjqZcYNFkPIBLJRBTwmCAGCRVw._controllerId, xwXjqZcYNFkPIBLJRBTwmCAGCRVw._id, actionElementMap.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
						LGwRrQjjArLCSXkbGsgievfvvNN = 1;
						return true;
					}
					goto IL_0123;
				}
				return false;
				IL_0123:
				BEWpiqjFQycXOFniHpAjsyqmxDUL++;
				goto IL_0133;
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
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				QiAbfsASEtwWMzhiJaOPXSYmMwdD qiAbfsASEtwWMzhiJaOPXSYmMwdD;
				if (LGwRrQjjArLCSXkbGsgievfvvNN == -2 && uBaBeWgmOukqiFuhmNCznhNDlfoUA == Environment.CurrentManagedThreadId)
				{
					LGwRrQjjArLCSXkbGsgievfvvNN = 0;
					qiAbfsASEtwWMzhiJaOPXSYmMwdD = this;
				}
				else
				{
					qiAbfsASEtwWMzhiJaOPXSYmMwdD = new QiAbfsASEtwWMzhiJaOPXSYmMwdD(0);
					qiAbfsASEtwWMzhiJaOPXSYmMwdD.XwXjqZcYNFkPIBLJRBTwmCAGCRVw = XwXjqZcYNFkPIBLJRBTwmCAGCRVw;
				}
				qiAbfsASEtwWMzhiJaOPXSYmMwdD.pBxlmZQkqruVdiDniEeJFYpqaUKeA = FepmEafZjvJkgeOnTdQjDJyLbUJEb;
				qiAbfsASEtwWMzhiJaOPXSYmMwdD.rMcpzoAdqMpRfTKOpeguIrHrfkuD = SrZxYOZhMZeLboBojdjKUgaUZvBK;
				return qiAbfsASEtwWMzhiJaOPXSYmMwdD;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class qfAESAMgvUOiSdnZrEtrqsXguBNs : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int HovhOsAVolHlrglCxujIUJiGvxgh;

			private ActionElementMap lWTUMdoHaugzEhpJJGrtFXksasyn;

			private int SHeBAZUYcTjMPbjVkUJXNKzBgQUcA;

			public ControllerMap sWLEQLEFzjqoKlYOajOPxEnBYRkf;

			private int KIXQcDcOWNYHcSGfAHjWjZyUQGCX;

			public int QHMIwaWnVHdhKLrwOegbQhTHsiiA;

			private bool HOnnzmWavrDSjRyIzrAqfnOCMyAO;

			public bool iwVslxFfONJvvUeWJbPuQVyxGNGhA;

			private IEnumerator<ActionElementMap> rhOsmhSWjhDtVSpEuFrNIqtsLwLz;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return lWTUMdoHaugzEhpJJGrtFXksasyn;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return lWTUMdoHaugzEhpJJGrtFXksasyn;
				}
			}

			[DebuggerHidden]
			public qfAESAMgvUOiSdnZrEtrqsXguBNs(int P_0)
			{
				HovhOsAVolHlrglCxujIUJiGvxgh = P_0;
				SHeBAZUYcTjMPbjVkUJXNKzBgQUcA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int hovhOsAVolHlrglCxujIUJiGvxgh = HovhOsAVolHlrglCxujIUJiGvxgh;
				if (hovhOsAVolHlrglCxujIUJiGvxgh == -3 || hovhOsAVolHlrglCxujIUJiGvxgh == 1)
				{
					try
					{
					}
					finally
					{
						MFNcdQJLZVeACDViCqBHdXhBvbZEA();
					}
				}
				rhOsmhSWjhDtVSpEuFrNIqtsLwLz = null;
				HovhOsAVolHlrglCxujIUJiGvxgh = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int hovhOsAVolHlrglCxujIUJiGvxgh = HovhOsAVolHlrglCxujIUJiGvxgh;
					ControllerMap controllerMap = sWLEQLEFzjqoKlYOajOPxEnBYRkf;
					switch (hovhOsAVolHlrglCxujIUJiGvxgh)
					{
					default:
						return false;
					case 0:
						HovhOsAVolHlrglCxujIUJiGvxgh = -1;
						if (ReInput._id != controllerMap.HGKnnYgsStSHzmTMXitKKPatJYAf)
						{
							ReInput.CheckInitialized(controllerMap.HGKnnYgsStSHzmTMXitKKPatJYAf);
							return false;
						}
						rhOsmhSWjhDtVSpEuFrNIqtsLwLz = controllerMap.AllMaps.GetEnumerator();
						HovhOsAVolHlrglCxujIUJiGvxgh = -3;
						break;
					case 1:
						HovhOsAVolHlrglCxujIUJiGvxgh = -3;
						break;
					}
					while (rhOsmhSWjhDtVSpEuFrNIqtsLwLz.MoveNext())
					{
						ActionElementMap current = rhOsmhSWjhDtVSpEuFrNIqtsLwLz.Current;
						if (current._actionId == KIXQcDcOWNYHcSGfAHjWjZyUQGCX && (!HOnnzmWavrDSjRyIzrAqfnOCMyAO || current.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
						{
							lWTUMdoHaugzEhpJJGrtFXksasyn = current;
							HovhOsAVolHlrglCxujIUJiGvxgh = 1;
							return true;
						}
					}
					MFNcdQJLZVeACDViCqBHdXhBvbZEA();
					rhOsmhSWjhDtVSpEuFrNIqtsLwLz = null;
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

			private void MFNcdQJLZVeACDViCqBHdXhBvbZEA()
			{
				HovhOsAVolHlrglCxujIUJiGvxgh = -1;
				if (rhOsmhSWjhDtVSpEuFrNIqtsLwLz != null)
				{
					rhOsmhSWjhDtVSpEuFrNIqtsLwLz.Dispose();
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
				qfAESAMgvUOiSdnZrEtrqsXguBNs qfAESAMgvUOiSdnZrEtrqsXguBNs2;
				if (HovhOsAVolHlrglCxujIUJiGvxgh == -2 && SHeBAZUYcTjMPbjVkUJXNKzBgQUcA == Environment.CurrentManagedThreadId)
				{
					HovhOsAVolHlrglCxujIUJiGvxgh = 0;
					qfAESAMgvUOiSdnZrEtrqsXguBNs2 = this;
				}
				else
				{
					qfAESAMgvUOiSdnZrEtrqsXguBNs2 = new qfAESAMgvUOiSdnZrEtrqsXguBNs(0);
					qfAESAMgvUOiSdnZrEtrqsXguBNs2.sWLEQLEFzjqoKlYOajOPxEnBYRkf = sWLEQLEFzjqoKlYOajOPxEnBYRkf;
				}
				qfAESAMgvUOiSdnZrEtrqsXguBNs2.KIXQcDcOWNYHcSGfAHjWjZyUQGCX = QHMIwaWnVHdhKLrwOegbQhTHsiiA;
				qfAESAMgvUOiSdnZrEtrqsXguBNs2.HOnnzmWavrDSjRyIzrAqfnOCMyAO = iwVslxFfONJvvUeWJbPuQVyxGNGhA;
				return qfAESAMgvUOiSdnZrEtrqsXguBNs2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class eRoHYaLFHJrnJjdFcrSEeSsGcwHBA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int asLbyOAWbrafCGkfcTbQKMaawKRab;

			private ActionElementMap fgilMmeVStAUbpovHdUoFwQmEXOv;

			private int zokbxWcbZKMNQcEbXSNSFVOvDSkJ;

			public ControllerMap yQicUCWrDFknxUxmFBYIDPJyreiC;

			private IControllerElementTarget tFAAODFMLeqokkmytLfRDrUyPWUbb;

			public IControllerElementTarget QVmvmGJUNXThoDFpsOrkRMGyoiqU;

			private bool ChVgKvUeSuCytzXCYjNWgttILBqib;

			public bool HjRHqLXYjlsBDFMmWLUCSeiDhlpp;

			private TempListPool.TList<ActionElementMap> DVWRhQPNdkmmBrYxuGmSMZyXCXsc;

			private List<ActionElementMap>.Enumerator AvUnBSovbyraXVYiyCuwJIVICkiE;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return fgilMmeVStAUbpovHdUoFwQmEXOv;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return fgilMmeVStAUbpovHdUoFwQmEXOv;
				}
			}

			[DebuggerHidden]
			public eRoHYaLFHJrnJjdFcrSEeSsGcwHBA(int P_0)
			{
				asLbyOAWbrafCGkfcTbQKMaawKRab = P_0;
				zokbxWcbZKMNQcEbXSNSFVOvDSkJ = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = asLbyOAWbrafCGkfcTbQKMaawKRab;
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
								XZwcgwHdZUROkEcacIbvJKhDuhze();
							}
						}
					}
					finally
					{
						SheLNjxsONQxHAyfUpvWtiHiYhpT();
					}
				}
				DVWRhQPNdkmmBrYxuGmSMZyXCXsc = null;
				AvUnBSovbyraXVYiyCuwJIVICkiE = default(List<ActionElementMap>.Enumerator);
				asLbyOAWbrafCGkfcTbQKMaawKRab = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = asLbyOAWbrafCGkfcTbQKMaawKRab;
					ControllerMap controllerMap = yQicUCWrDFknxUxmFBYIDPJyreiC;
					switch (num)
					{
					default:
						return false;
					case 0:
					{
						asLbyOAWbrafCGkfcTbQKMaawKRab = -1;
						if (ReInput._id != controllerMap.HGKnnYgsStSHzmTMXitKKPatJYAf)
						{
							ReInput.CheckInitialized(controllerMap.HGKnnYgsStSHzmTMXitKKPatJYAf);
							return false;
						}
						DVWRhQPNdkmmBrYxuGmSMZyXCXsc = TempListPool.GetTList<ActionElementMap>();
						asLbyOAWbrafCGkfcTbQKMaawKRab = -3;
						List<ActionElementMap> list = DVWRhQPNdkmmBrYxuGmSMZyXCXsc.list;
						controllerMap.GkqChYlZGQOzIisFIMtpFCNiEOLd(tFAAODFMLeqokkmytLfRDrUyPWUbb, false, -1, ChVgKvUeSuCytzXCYjNWgttILBqib, list, false, out var _);
						AvUnBSovbyraXVYiyCuwJIVICkiE = list.GetEnumerator();
						asLbyOAWbrafCGkfcTbQKMaawKRab = -4;
						break;
					}
					case 1:
						asLbyOAWbrafCGkfcTbQKMaawKRab = -4;
						break;
					}
					if (AvUnBSovbyraXVYiyCuwJIVICkiE.MoveNext())
					{
						ActionElementMap current = AvUnBSovbyraXVYiyCuwJIVICkiE.Current;
						fgilMmeVStAUbpovHdUoFwQmEXOv = current;
						asLbyOAWbrafCGkfcTbQKMaawKRab = 1;
						return true;
					}
					XZwcgwHdZUROkEcacIbvJKhDuhze();
					AvUnBSovbyraXVYiyCuwJIVICkiE = default(List<ActionElementMap>.Enumerator);
					SheLNjxsONQxHAyfUpvWtiHiYhpT();
					DVWRhQPNdkmmBrYxuGmSMZyXCXsc = null;
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

			private void SheLNjxsONQxHAyfUpvWtiHiYhpT()
			{
				asLbyOAWbrafCGkfcTbQKMaawKRab = -1;
				if (DVWRhQPNdkmmBrYxuGmSMZyXCXsc != null)
				{
					((IDisposable)DVWRhQPNdkmmBrYxuGmSMZyXCXsc).Dispose();
				}
			}

			private void XZwcgwHdZUROkEcacIbvJKhDuhze()
			{
				asLbyOAWbrafCGkfcTbQKMaawKRab = -3;
				((IDisposable)AvUnBSovbyraXVYiyCuwJIVICkiE/*cast due to .constrained prefix*/).Dispose();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				eRoHYaLFHJrnJjdFcrSEeSsGcwHBA eRoHYaLFHJrnJjdFcrSEeSsGcwHBA2;
				if (asLbyOAWbrafCGkfcTbQKMaawKRab == -2 && zokbxWcbZKMNQcEbXSNSFVOvDSkJ == Environment.CurrentManagedThreadId)
				{
					asLbyOAWbrafCGkfcTbQKMaawKRab = 0;
					eRoHYaLFHJrnJjdFcrSEeSsGcwHBA2 = this;
				}
				else
				{
					eRoHYaLFHJrnJjdFcrSEeSsGcwHBA2 = new eRoHYaLFHJrnJjdFcrSEeSsGcwHBA(0);
					eRoHYaLFHJrnJjdFcrSEeSsGcwHBA2.yQicUCWrDFknxUxmFBYIDPJyreiC = yQicUCWrDFknxUxmFBYIDPJyreiC;
				}
				eRoHYaLFHJrnJjdFcrSEeSsGcwHBA2.tFAAODFMLeqokkmytLfRDrUyPWUbb = QVmvmGJUNXThoDFpsOrkRMGyoiqU;
				eRoHYaLFHJrnJjdFcrSEeSsGcwHBA2.ChVgKvUeSuCytzXCYjNWgttILBqib = HjRHqLXYjlsBDFMmWLUCSeiDhlpp;
				return eRoHYaLFHJrnJjdFcrSEeSsGcwHBA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class KFzSNrJTMaqtBIYRyWBhxfGrhffC : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int IXwNDAMHmpfqxtQGCuGTefDwAzoW;

			private ActionElementMap TNbutvmLbZbKaJqtqOhnjpHCMxcWb;

			private int yCVKfObgwjcbcvMOOXXRoceDNPnU;

			public ControllerMap zCPOhwMQLLnfhvFYRsNhfGpcfRPG;

			private IControllerElementTarget jpcJrHgIupumzJhIuAFCzWyiIHif;

			public IControllerElementTarget ebxgOdHrfImpQSDxQVFgLCaqIJgR;

			private int vJpCFKgKSkrDnVLaFlIBihabgITMc;

			public int nfUHqIECJCFlJrvVyftwIzeLXzDW;

			private bool yUGieCTNjZSZLxhBCocZlsCJUkIK;

			public bool pYCeEqkebYRaMOJrItYfHMKZCeqr;

			private TempListPool.TList<ActionElementMap> wZWTHXsmkWfeIdGOSNYZvDiQPXSv;

			private List<ActionElementMap>.Enumerator bRWwjHEaXTRTDWcnbLERMgAsEXPC;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return TNbutvmLbZbKaJqtqOhnjpHCMxcWb;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return TNbutvmLbZbKaJqtqOhnjpHCMxcWb;
				}
			}

			[DebuggerHidden]
			public KFzSNrJTMaqtBIYRyWBhxfGrhffC(int P_0)
			{
				IXwNDAMHmpfqxtQGCuGTefDwAzoW = P_0;
				yCVKfObgwjcbcvMOOXXRoceDNPnU = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int iXwNDAMHmpfqxtQGCuGTefDwAzoW = IXwNDAMHmpfqxtQGCuGTefDwAzoW;
				if ((uint)(iXwNDAMHmpfqxtQGCuGTefDwAzoW - -4) <= 1u || iXwNDAMHmpfqxtQGCuGTefDwAzoW == 1)
				{
					try
					{
						if (iXwNDAMHmpfqxtQGCuGTefDwAzoW == -4 || iXwNDAMHmpfqxtQGCuGTefDwAzoW == 1)
						{
							try
							{
							}
							finally
							{
								SCUBDVBJBLIArVedmzWwHMElKUdxA();
							}
						}
					}
					finally
					{
						PaCbzHULuecIndHhMtQibDDoPqQMA();
					}
				}
				wZWTHXsmkWfeIdGOSNYZvDiQPXSv = null;
				bRWwjHEaXTRTDWcnbLERMgAsEXPC = default(List<ActionElementMap>.Enumerator);
				IXwNDAMHmpfqxtQGCuGTefDwAzoW = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int iXwNDAMHmpfqxtQGCuGTefDwAzoW = IXwNDAMHmpfqxtQGCuGTefDwAzoW;
					ControllerMap controllerMap = zCPOhwMQLLnfhvFYRsNhfGpcfRPG;
					switch (iXwNDAMHmpfqxtQGCuGTefDwAzoW)
					{
					default:
						return false;
					case 0:
					{
						IXwNDAMHmpfqxtQGCuGTefDwAzoW = -1;
						if (ReInput._id != controllerMap.HGKnnYgsStSHzmTMXitKKPatJYAf)
						{
							ReInput.CheckInitialized(controllerMap.HGKnnYgsStSHzmTMXitKKPatJYAf);
							return false;
						}
						wZWTHXsmkWfeIdGOSNYZvDiQPXSv = TempListPool.GetTList<ActionElementMap>();
						IXwNDAMHmpfqxtQGCuGTefDwAzoW = -3;
						List<ActionElementMap> list = wZWTHXsmkWfeIdGOSNYZvDiQPXSv.list;
						controllerMap.GkqChYlZGQOzIisFIMtpFCNiEOLd(jpcJrHgIupumzJhIuAFCzWyiIHif, true, vJpCFKgKSkrDnVLaFlIBihabgITMc, yUGieCTNjZSZLxhBCocZlsCJUkIK, list, false, out var _);
						bRWwjHEaXTRTDWcnbLERMgAsEXPC = list.GetEnumerator();
						IXwNDAMHmpfqxtQGCuGTefDwAzoW = -4;
						break;
					}
					case 1:
						IXwNDAMHmpfqxtQGCuGTefDwAzoW = -4;
						break;
					}
					if (bRWwjHEaXTRTDWcnbLERMgAsEXPC.MoveNext())
					{
						ActionElementMap current = bRWwjHEaXTRTDWcnbLERMgAsEXPC.Current;
						TNbutvmLbZbKaJqtqOhnjpHCMxcWb = current;
						IXwNDAMHmpfqxtQGCuGTefDwAzoW = 1;
						return true;
					}
					SCUBDVBJBLIArVedmzWwHMElKUdxA();
					bRWwjHEaXTRTDWcnbLERMgAsEXPC = default(List<ActionElementMap>.Enumerator);
					PaCbzHULuecIndHhMtQibDDoPqQMA();
					wZWTHXsmkWfeIdGOSNYZvDiQPXSv = null;
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

			private void PaCbzHULuecIndHhMtQibDDoPqQMA()
			{
				IXwNDAMHmpfqxtQGCuGTefDwAzoW = -1;
				if (wZWTHXsmkWfeIdGOSNYZvDiQPXSv != null)
				{
					((IDisposable)wZWTHXsmkWfeIdGOSNYZvDiQPXSv).Dispose();
				}
			}

			private void SCUBDVBJBLIArVedmzWwHMElKUdxA()
			{
				IXwNDAMHmpfqxtQGCuGTefDwAzoW = -3;
				((IDisposable)bRWwjHEaXTRTDWcnbLERMgAsEXPC/*cast due to .constrained prefix*/).Dispose();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				KFzSNrJTMaqtBIYRyWBhxfGrhffC kFzSNrJTMaqtBIYRyWBhxfGrhffC;
				if (IXwNDAMHmpfqxtQGCuGTefDwAzoW == -2 && yCVKfObgwjcbcvMOOXXRoceDNPnU == Environment.CurrentManagedThreadId)
				{
					IXwNDAMHmpfqxtQGCuGTefDwAzoW = 0;
					kFzSNrJTMaqtBIYRyWBhxfGrhffC = this;
				}
				else
				{
					kFzSNrJTMaqtBIYRyWBhxfGrhffC = new KFzSNrJTMaqtBIYRyWBhxfGrhffC(0);
					kFzSNrJTMaqtBIYRyWBhxfGrhffC.zCPOhwMQLLnfhvFYRsNhfGpcfRPG = zCPOhwMQLLnfhvFYRsNhfGpcfRPG;
				}
				kFzSNrJTMaqtBIYRyWBhxfGrhffC.jpcJrHgIupumzJhIuAFCzWyiIHif = ebxgOdHrfImpQSDxQVFgLCaqIJgR;
				kFzSNrJTMaqtBIYRyWBhxfGrhffC.vJpCFKgKSkrDnVLaFlIBihabgITMc = nfUHqIECJCFlJrvVyftwIzeLXzDW;
				kFzSNrJTMaqtBIYRyWBhxfGrhffC.yUGieCTNjZSZLxhBCocZlsCJUkIK = pYCeEqkebYRaMOJrItYfHMKZCeqr;
				return kFzSNrJTMaqtBIYRyWBhxfGrhffC;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		protected int _id;

		protected int _sourceMapId;

		protected int _categoryId;

		protected int _layoutId;

		protected string _name = string.Empty;

		protected Guid _hardwareGuid;

		protected bool _enabled;

		internal readonly int HGKnnYgsStSHzmTMXitKKPatJYAf;

		private double UUCBrsqhEGpknwYUTCVeYJuDUoat;

		private readonly AList<ActionElementMap> xhimarnxTkdcASkSXJKYCZuEUIAA;

		private readonly ReadOnlyCollection<ActionElementMap> swSlOpxSDTaMiySzxTgEMEnEhkeh;

		private readonly AList<ActionElementMap> OAYBwuRSJSWeyXnFUPwzAefBWTzV;

		private readonly ReadOnlyCollection<ActionElementMap> LksieOEiONLGPeWIbbxsuquEQoAh;

		protected int _playerId = -1;

		protected int _controllerId = -1;

		protected ControllerType _controllerType;

		private static int npuJAAioIqetaHHDksJlZxpOkAIvA;

		private static int cmDFcveJLeaxwaRaGoTSFVQlmiTnb;

		private static int yNjVEouitEVwRTLaIrpsoPdOyTRF
		{
			get
			{
				int result = npuJAAioIqetaHHDksJlZxpOkAIvA;
				if (npuJAAioIqetaHHDksJlZxpOkAIvA == int.MaxValue)
				{
					npuJAAioIqetaHHDksJlZxpOkAIvA = 0;
					return result;
				}
				npuJAAioIqetaHHDksJlZxpOkAIvA++;
				return result;
			}
		}

		internal static bool IlXcdaRlNSFIvcdRoZnDHsAGLAGs => cmDFcveJLeaxwaRaGoTSFVQlmiTnb > 0;

		public int id
		{
			get
			{
				if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
					return -1;
				}
				return _id;
			}
		}

		public int sourceMapId
		{
			get
			{
				if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
					return -1;
				}
				return _sourceMapId;
			}
			internal set
			{
				_sourceMapId = num;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
					return -1;
				}
				return _categoryId;
			}
			internal set
			{
				_categoryId = num;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
					return -1;
				}
				return _layoutId;
			}
			internal set
			{
				_layoutId = num;
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
					return string.Empty;
				}
				return _name;
			}
			internal set
			{
				_name = text;
			}
		}

		public Guid hardwareGuid
		{
			get
			{
				if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
					return Guid.Empty;
				}
				return _hardwareGuid;
			}
			internal set
			{
				_hardwareGuid = guid;
			}
		}

		public bool enabled
		{
			get
			{
				if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
					return false;
				}
				return _enabled;
			}
			set
			{
				_enabled = value;
			}
		}

		public int playerId
		{
			get
			{
				if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
					return -1;
				}
				return _playerId;
			}
			internal set
			{
				_playerId = num;
			}
		}

		public int controllerId
		{
			get
			{
				if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
					return -1;
				}
				return _controllerId;
			}
			internal set
			{
				_controllerId = num;
			}
		}

		public Controller controller
		{
			get
			{
				if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
					return null;
				}
				return ReInput.controllers.GetController(_controllerType, _controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
					return ControllerType.Keyboard;
				}
				return _controllerType;
			}
		}

		public Player player
		{
			get
			{
				if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
					return null;
				}
				return ReInput.players.GetPlayer(_playerId);
			}
		}

		public int elementMapCount
		{
			get
			{
				if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
					return 0;
				}
				return OAYBwuRSJSWeyXnFUPwzAefBWTzV.Count;
			}
		}

		public int buttonMapCount
		{
			get
			{
				if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
					return 0;
				}
				return xhimarnxTkdcASkSXJKYCZuEUIAA.Count;
			}
		}

		public IList<ActionElementMap> AllMaps
		{
			get
			{
				if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return LksieOEiONLGPeWIbbxsuquEQoAh;
			}
		}

		public IList<ActionElementMap> ElementMaps
		{
			get
			{
				if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return LksieOEiONLGPeWIbbxsuquEQoAh;
			}
		}

		public IList<ActionElementMap> ButtonMaps
		{
			get
			{
				if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
				{
					ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return swSlOpxSDTaMiySzxTgEMEnEhkeh;
			}
		}

		public double modifiedTime
		{
			get
			{
				int count = OAYBwuRSJSWeyXnFUPwzAefBWTzV.Count;
				double uUCBrsqhEGpknwYUTCVeYJuDUoat = UUCBrsqhEGpknwYUTCVeYJuDUoat;
				for (int i = 0; i < count; i++)
				{
					if (OAYBwuRSJSWeyXnFUPwzAefBWTzV[i] != null && OAYBwuRSJSWeyXnFUPwzAefBWTzV[i].modifiedTime > uUCBrsqhEGpknwYUTCVeYJuDUoat)
					{
						uUCBrsqhEGpknwYUTCVeYJuDUoat = OAYBwuRSJSWeyXnFUPwzAefBWTzV[i].modifiedTime;
					}
				}
				return uUCBrsqhEGpknwYUTCVeYJuDUoat;
			}
		}

		public bool isModified
		{
			get
			{
				if (UUCBrsqhEGpknwYUTCVeYJuDUoat > 0.0)
				{
					return true;
				}
				int count = OAYBwuRSJSWeyXnFUPwzAefBWTzV.Count;
				for (int i = 0; i < count; i++)
				{
					if (OAYBwuRSJSWeyXnFUPwzAefBWTzV[i] != null && OAYBwuRSJSWeyXnFUPwzAefBWTzV[i].isModified)
					{
						return true;
					}
				}
				return false;
			}
			set
			{
				if (value)
				{
					UUCBrsqhEGpknwYUTCVeYJuDUoat = ReInput.realTime;
					return;
				}
				UUCBrsqhEGpknwYUTCVeYJuDUoat = 0.0;
				int count = OAYBwuRSJSWeyXnFUPwzAefBWTzV.Count;
				_ = UUCBrsqhEGpknwYUTCVeYJuDUoat;
				for (int i = 0; i < count; i++)
				{
					if (OAYBwuRSJSWeyXnFUPwzAefBWTzV[i] != null)
					{
						OAYBwuRSJSWeyXnFUPwzAefBWTzV[i].isModified = value;
					}
				}
			}
		}

		internal AList<ActionElementMap> hHYkHiBucOeDZcWyVzqWCcJcDXyr => xhimarnxTkdcASkSXJKYCZuEUIAA;

		public ControllerMap()
		{
			_id = yNjVEouitEVwRTLaIrpsoPdOyTRF;
			_sourceMapId = -1;
			xhimarnxTkdcASkSXJKYCZuEUIAA = new AList<ActionElementMap>();
			swSlOpxSDTaMiySzxTgEMEnEhkeh = new ReadOnlyCollection<ActionElementMap>(xhimarnxTkdcASkSXJKYCZuEUIAA);
			OAYBwuRSJSWeyXnFUPwzAefBWTzV = new AList<ActionElementMap>();
			LksieOEiONLGPeWIbbxsuquEQoAh = new ReadOnlyCollection<ActionElementMap>(OAYBwuRSJSWeyXnFUPwzAefBWTzV);
			HGKnnYgsStSHzmTMXitKKPatJYAf = ReInput.id;
		}

		public ControllerMap(ControllerMap P_0)
			: this()
		{
			_id = yNjVEouitEVwRTLaIrpsoPdOyTRF;
			_sourceMapId = P_0._sourceMapId;
			_categoryId = P_0._categoryId;
			_layoutId = P_0._layoutId;
			_name = P_0._name;
			_hardwareGuid = P_0._hardwareGuid;
			_enabled = P_0._enabled;
			_playerId = P_0._playerId;
			_controllerId = P_0._controllerId;
			_controllerType = P_0._controllerType;
			lRmYCoCSmOckdAxZaAzbXHOzxRbC();
			if (P_0.xhimarnxTkdcASkSXJKYCZuEUIAA != null)
			{
				int count = P_0.xhimarnxTkdcASkSXJKYCZuEUIAA.Count;
				for (int i = 0; i < count; i++)
				{
					pPbRvnhAQENFdreHzRuIhtwkuRMN(new ActionElementMap(P_0.xhimarnxTkdcASkSXJKYCZuEUIAA[i]));
				}
			}
			GHMgTTbTNZrCoRvrTvpOrmMMxTwr();
			UUCBrsqhEGpknwYUTCVeYJuDUoat = P_0.UUCBrsqhEGpknwYUTCVeYJuDUoat;
		}

		public bool ContainsAction(string actionName)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return false;
			}
			InputAction inputAction = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.vMoFsVlrywxRswyFZUiwaCMiXuhJ(actionName, true);
			if (inputAction == null)
			{
				return false;
			}
			return ContainsAction(inputAction.id);
		}

		public virtual bool ContainsAction(int actionId)
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
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (xhimarnxTkdcASkSXJKYCZuEUIAA[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementIdentifier(int elementIdentifierId)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return false;
			}
			AList<ActionElementMap> oAYBwuRSJSWeyXnFUPwzAefBWTzV = OAYBwuRSJSWeyXnFUPwzAefBWTzV;
			for (int i = 0; i < oAYBwuRSJSWeyXnFUPwzAefBWTzV.Count; i++)
			{
				if (OAYBwuRSJSWeyXnFUPwzAefBWTzV[i].elementIdentifierId == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsKeyboardKey(KeyboardKeyCode keyCode, ModifierKeyFlags modifierKeys)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return false;
			}
			AList<ActionElementMap> oAYBwuRSJSWeyXnFUPwzAefBWTzV = OAYBwuRSJSWeyXnFUPwzAefBWTzV;
			for (int i = 0; i < oAYBwuRSJSWeyXnFUPwzAefBWTzV.Count; i++)
			{
				if (OAYBwuRSJSWeyXnFUPwzAefBWTzV[i].keyCode == keyCode && OAYBwuRSJSWeyXnFUPwzAefBWTzV[i].modifierKeyFlags == modifierKeys)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementMap(ActionElementMap elementMap)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return false;
			}
			if (elementMap == null)
			{
				return false;
			}
			AList<ActionElementMap> oAYBwuRSJSWeyXnFUPwzAefBWTzV = OAYBwuRSJSWeyXnFUPwzAefBWTzV;
			for (int i = 0; i < oAYBwuRSJSWeyXnFUPwzAefBWTzV.Count; i++)
			{
				if (OAYBwuRSJSWeyXnFUPwzAefBWTzV[i].ZwmcQAFJNCcNOFRJeAGabSeBNAxXc == elementMap.id)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementMap(int elementMapId)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return false;
			}
			AList<ActionElementMap> oAYBwuRSJSWeyXnFUPwzAefBWTzV = OAYBwuRSJSWeyXnFUPwzAefBWTzV;
			for (int i = 0; i < oAYBwuRSJSWeyXnFUPwzAefBWTzV.Count; i++)
			{
				if (OAYBwuRSJSWeyXnFUPwzAefBWTzV[i].ZwmcQAFJNCcNOFRJeAGabSeBNAxXc == elementMapId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return false;
			}
			ActionElementMap result;
			return ReplaceOrCreateElementMap(elementAssignment, out result);
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				result = null;
				return false;
			}
			if (GetElementMap(elementAssignment.elementMapId) == null)
			{
				return CreateElementMap(elementAssignment, out result);
			}
			return ReplaceElementMap(elementAssignment, out result);
		}

		public bool CreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return false;
			}
			ActionElementMap result;
			return CreateElementMap(elementAssignment, out result);
		}

		public bool CreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, GHPcAvLGyrhUIIuLWeQoyFTYgunBA.YcYTilAPBvSfzMelopUiRgKqPOCx(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
			}
			throw new NotImplementedException();
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyboardKeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, keyCode, modifierKey1, modifierKey2, modifierKey3, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyboardKeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3, out ActionElementMap result)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, ControllerElementType.Button, axisContribution, keyCode, modifierKey1, modifierKey2, modifierKey3);
			ReInput.controllers.Keyboard.duSGjNZdSxSjezvmjyDBFGtlyxPL(this, actionElementMap);
			pPbRvnhAQENFdreHzRuIhtwkuRMN(actionElementMap);
			result = actionElementMap;
			return true;
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyboardKeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, keyCode, modifierKeyFlags, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyboardKeyCode keyCode, ModifierKeyFlags modifierKeyFlags, out ActionElementMap result)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				result = null;
				return false;
			}
			eZzfdwqZyuUzjYPZsjwXXEekwhTl eZzfdwqZyuUzjYPZsjwXXEekwhTl2 = eZzfdwqZyuUzjYPZsjwXXEekwhTl.lIkgcbiWVfbZlDtacWOineyqoNyM(modifierKeyFlags);
			return CreateElementMap(actionId, axisContribution, keyCode, eZzfdwqZyuUzjYPZsjwXXEekwhTl2.jyaDOENppllrRqGJdSYrvDpcALGu, eZzfdwqZyuUzjYPZsjwXXEekwhTl2.ACXPfxhxjzjqcIPdDHMFtcPgNyAH, eZzfdwqZyuUzjYPZsjwXXEekwhTl2.rAROzgepZrkcdFSabHpfrCMHgxh, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				result = null;
				return false;
			}
			if (!eKPaNbzFEdgcAfZtdyuYwxQtUgwD(elementType))
			{
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange);
			BakeElementMap(actionElementMap);
			pPbRvnhAQENFdreHzRuIhtwkuRMN(actionElementMap);
			result = actionElementMap;
			return true;
		}

		public bool ReplaceElementMap(ElementAssignment elementAssignment)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementAssignment, out result);
		}

		public bool ReplaceElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, GHPcAvLGyrhUIIuLWeQoyFTYgunBA.YcYTilAPBvSfzMelopUiRgKqPOCx(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
			}
			throw new NotImplementedException();
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyboardKeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, modifierKey1, modifierKey2, modifierKey3, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyboardKeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3, out ActionElementMap result)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				result = null;
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				result = null;
				return false;
			}
			if (kDNRqFtgVPhutFhtIdXafjtoiZXD(elementMapId) < 0)
			{
				DeleteElementMap(elementMapId);
				elementMap.elementType = ControllerElementType.Button;
				pPbRvnhAQENFdreHzRuIhtwkuRMN(elementMap);
			}
			if (kDNRqFtgVPhutFhtIdXafjtoiZXD(elementMapId) < 0)
			{
				result = null;
				return false;
			}
			elementMap.FeaKSxXPUexcOObMrHqzNwEaFjbB();
			elementMap._actionId = actionId;
			elementMap._elementType = ControllerElementType.Button;
			elementMap._axisContribution = axisContribution;
			elementMap._keyboardKeyCode = keyCode;
			elementMap._modifierKey1 = modifierKey1;
			elementMap._modifierKey2 = modifierKey2;
			elementMap._modifierKey3 = modifierKey3;
			elementMap.GRbJLLzUgxIUuVqccrTRTBklfgP();
			ReInput.controllers.Keyboard.duSGjNZdSxSjezvmjyDBFGtlyxPL(this, elementMap);
			result = elementMap;
			wqUbVrvNAvlRNTnEOwsqHTzxozGC();
			return true;
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyboardKeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, modifierKeyFlags, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyboardKeyCode keyCode, ModifierKeyFlags modifierKeyFlags, out ActionElementMap result)
		{
			eZzfdwqZyuUzjYPZsjwXXEekwhTl eZzfdwqZyuUzjYPZsjwXXEekwhTl2 = eZzfdwqZyuUzjYPZsjwXXEekwhTl.lIkgcbiWVfbZlDtacWOineyqoNyM(modifierKeyFlags);
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, eZzfdwqZyuUzjYPZsjwXXEekwhTl2.jyaDOENppllrRqGJdSYrvDpcALGu, eZzfdwqZyuUzjYPZsjwXXEekwhTl2.ACXPfxhxjzjqcIPdDHMFtcPgNyAH, eZzfdwqZyuUzjYPZsjwXXEekwhTl2.rAROzgepZrkcdFSabHpfrCMHgxh, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				result = null;
				return false;
			}
			if (!eKPaNbzFEdgcAfZtdyuYwxQtUgwD(elementType))
			{
				result = null;
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				result = null;
				return false;
			}
			if (!eKPaNbzFEdgcAfZtdyuYwxQtUgwD(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap.elementType = ControllerElementType.Button;
				pPbRvnhAQENFdreHzRuIhtwkuRMN(elementMap);
			}
			if (kDNRqFtgVPhutFhtIdXafjtoiZXD(elementMapId) < 0)
			{
				result = null;
				return false;
			}
			lOevVLipIpvXFMfnghcFUOdDBQveA(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			BakeElementMap(elementMap);
			result = elementMap;
			wqUbVrvNAvlRNTnEOwsqHTzxozGC();
			return true;
		}

		public virtual bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return false;
			}
			int num = kDNRqFtgVPhutFhtIdXafjtoiZXD(elementMapId);
			if (num < 0)
			{
				return false;
			}
			lVRoitXnzttxGnqFTUnaAYkPBxWo(elementMapId, num);
			return true;
		}

		public virtual bool DeleteElementMapsWithAction(string actionName)
		{
			return DeleteElementMapsWithAction(ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName));
		}

		public virtual bool DeleteElementMapsWithAction(int actionId)
		{
			return DeleteButtonMapsWithAction(actionId);
		}

		public virtual ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			if (elementMapId < 0)
			{
				return null;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (xhimarnxTkdcASkSXJKYCZuEUIAA[i].ZwmcQAFJNCcNOFRJeAGabSeBNAxXc == elementMapId)
				{
					return xhimarnxTkdcASkSXJKYCZuEUIAA[i];
				}
			}
			return null;
		}

		public ActionElementMap[] GetElementMaps()
		{
			return GetElementMaps(skipDisabledMaps: false);
		}

		public ActionElementMap[] GetElementMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = elementMapCount;
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			List<ActionElementMap> list = new List<ActionElementMap>(num);
			foreach (ActionElementMap allMap in AllMaps)
			{
				if (!skipDisabledMaps || allMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA)
				{
					list.Add(allMap);
				}
			}
			return list.ToArray();
		}

		public int GetElementMaps(List<ActionElementMap> results)
		{
			return GetElementMaps(skipDisabledMaps: false, results);
		}

		public int GetElementMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			return KYJJlQDnUQbhhyWAENYGgqlpAjSV(results, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			return GetElementMapsWithAction(actionId);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId, bool skipDisabledMaps)
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
			if (elementMapCount == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = 0;
			foreach (ActionElementMap allMap in AllMaps)
			{
				if (allMap._actionId == actionId && (!skipDisabledMaps || allMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
				{
					num++;
				}
			}
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			ActionElementMap[] array = new ActionElementMap[num];
			int num2 = 0;
			foreach (ActionElementMap allMap2 in AllMaps)
			{
				if (allMap2._actionId == actionId && (!skipDisabledMaps || allMap2.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
				{
					array[num2] = allMap2;
					num2++;
				}
			}
			return array;
		}

		public int GetElementMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			return GetElementMapsWithAction(actionId, results);
		}

		public int GetElementMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			return cAwvQRajuNSdcVfCIbMQuiDVTnmt(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			return ElementMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId)
		{
			return ElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			return ElementMapsWithAction(actionId, skipDisabledMaps);
		}

		[IteratorStateMachine(typeof(qfAESAMgvUOiSdnZrEtrqsXguBNs))]
		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new qfAESAMgvUOiSdnZrEtrqsXguBNs(-2)
			{
				sWLEQLEFzjqoKlYOajOPxEnBYRkf = this,
				QHMIwaWnVHdhKLrwOegbQhTHsiiA = actionId,
				iwVslxFfONJvvUeWJbPuQVyxGNGhA = skipDisabledMaps
			};
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId)
		{
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps: false);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(string actionName)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			return GetFirstElementMapWithAction(actionId);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
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
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (xhimarnxTkdcASkSXJKYCZuEUIAA[i]._actionId == actionId && (!skipDisabledMaps || xhimarnxTkdcASkSXJKYCZuEUIAA[i].KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
				{
					return xhimarnxTkdcASkSXJKYCZuEUIAA[i];
				}
			}
			return null;
		}

		public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			oFieiUIUewVeTJqZtmiJuPDLbluKA oFieiUIUewVeTJqZtmiJuPDLbluKA2 = oFieiUIUewVeTJqZtmiJuPDLbluKA.WKwdftlTADcIDJLOQftQVPMcNeXb(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(oFieiUIUewVeTJqZtmiJuPDLbluKA2, skipDisabledMaps);
			oFieiUIUewVeTJqZtmiJuPDLbluKA.DnnhidOkRREqyIBofCvNmttxJQEjA(oFieiUIUewVeTJqZtmiJuPDLbluKA2);
			return result;
		}

		[IteratorStateMachine(typeof(eRoHYaLFHJrnJjdFcrSEeSsGcwHBA))]
		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			return new eRoHYaLFHJrnJjdFcrSEeSsGcwHBA(-2)
			{
				yQicUCWrDFknxUxmFBYIDPJyreiC = this,
				QVmvmGJUNXThoDFpsOrkRMGyoiqU = elementTarget,
				HjRHqLXYjlsBDFMmWLUCSeiDhlpp = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			oFieiUIUewVeTJqZtmiJuPDLbluKA oFieiUIUewVeTJqZtmiJuPDLbluKA2 = oFieiUIUewVeTJqZtmiJuPDLbluKA.WKwdftlTADcIDJLOQftQVPMcNeXb(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(oFieiUIUewVeTJqZtmiJuPDLbluKA2, actionId, skipDisabledMaps);
			oFieiUIUewVeTJqZtmiJuPDLbluKA.DnnhidOkRREqyIBofCvNmttxJQEjA(oFieiUIUewVeTJqZtmiJuPDLbluKA2);
			return result;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		[IteratorStateMachine(typeof(KFzSNrJTMaqtBIYRyWBhxfGrhffC))]
		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			return new KFzSNrJTMaqtBIYRyWBhxfGrhffC(-2)
			{
				zCPOhwMQLLnfhvFYRsNhfGpcfRPG = this,
				ebxgOdHrfImpQSDxQVFgLCaqIJgR = elementTarget,
				nfUHqIECJCFlJrvVyftwIzeLXzDW = actionId,
				pYCeEqkebYRaMOJrItYfHMKZCeqr = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			oFieiUIUewVeTJqZtmiJuPDLbluKA oFieiUIUewVeTJqZtmiJuPDLbluKA2 = oFieiUIUewVeTJqZtmiJuPDLbluKA.WKwdftlTADcIDJLOQftQVPMcNeXb(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(oFieiUIUewVeTJqZtmiJuPDLbluKA2, skipDisabledMaps);
			oFieiUIUewVeTJqZtmiJuPDLbluKA.DnnhidOkRREqyIBofCvNmttxJQEjA(oFieiUIUewVeTJqZtmiJuPDLbluKA2);
			return firstElementMapWithElementTarget;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			bool flag;
			return rLYedBCsdtfUPGpuxQjkUgoLtSyKA(elementTarget, false, -1, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			oFieiUIUewVeTJqZtmiJuPDLbluKA oFieiUIUewVeTJqZtmiJuPDLbluKA2 = oFieiUIUewVeTJqZtmiJuPDLbluKA.WKwdftlTADcIDJLOQftQVPMcNeXb(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(oFieiUIUewVeTJqZtmiJuPDLbluKA2, actionId, skipDisabledMaps);
			oFieiUIUewVeTJqZtmiJuPDLbluKA.DnnhidOkRREqyIBofCvNmttxJQEjA(oFieiUIUewVeTJqZtmiJuPDLbluKA2);
			return firstElementMapWithElementTarget;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			bool flag;
			return rLYedBCsdtfUPGpuxQjkUgoLtSyKA(elementTarget, true, actionId, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			oFieiUIUewVeTJqZtmiJuPDLbluKA oFieiUIUewVeTJqZtmiJuPDLbluKA2 = oFieiUIUewVeTJqZtmiJuPDLbluKA.WKwdftlTADcIDJLOQftQVPMcNeXb(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(oFieiUIUewVeTJqZtmiJuPDLbluKA2, skipDisabledMaps, results);
			oFieiUIUewVeTJqZtmiJuPDLbluKA.DnnhidOkRREqyIBofCvNmttxJQEjA(oFieiUIUewVeTJqZtmiJuPDLbluKA2);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			bool flag;
			return GkqChYlZGQOzIisFIMtpFCNiEOLd(elementTarget, false, -1, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			oFieiUIUewVeTJqZtmiJuPDLbluKA oFieiUIUewVeTJqZtmiJuPDLbluKA2 = oFieiUIUewVeTJqZtmiJuPDLbluKA.WKwdftlTADcIDJLOQftQVPMcNeXb(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(oFieiUIUewVeTJqZtmiJuPDLbluKA2, actionId, skipDisabledMaps, results);
			oFieiUIUewVeTJqZtmiJuPDLbluKA.DnnhidOkRREqyIBofCvNmttxJQEjA(oFieiUIUewVeTJqZtmiJuPDLbluKA2);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			bool flag;
			return GkqChYlZGQOzIisFIMtpFCNiEOLd(elementTarget, true, actionId, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public ActionElementMap GetFirstElementMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			return NSrZjJPDZBduYBMKyAFTNUXLREhHA(predicate, false);
		}

		internal virtual ActionElementMap NSrZjJPDZBduYBMKyAFTNUXLREhHA(Predicate<ActionElementMap> P_0, bool P_1)
		{
			return ftVYFAbrcDDSPOUcHefghadpBybf(P_0, P_1);
		}

		public int GetElementMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			return ViQqHmWScxNhOhnEHAXOSVscwawX(predicate, false, results, false);
		}

		internal virtual int ViQqHmWScxNhOhnEHAXOSVscwawX(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return alYeQRaRnBhtvnomQunQKOdNIuVZ(P_0, P_1, P_2, P_3);
		}

		public void ForEachElementMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
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
			int count = OAYBwuRSJSWeyXnFUPwzAefBWTzV.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = OAYBwuRSJSWeyXnFUPwzAefBWTzV[i];
					if (predicate(obj))
					{
						actionToPerform(obj);
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.ForEachElementMapMatch", exception);
			}
		}

		public virtual void ClearElementMaps()
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return;
			}
			xhimarnxTkdcASkSXJKYCZuEUIAA.Clear();
			OAYBwuRSJSWeyXnFUPwzAefBWTzV.Clear();
			wqUbVrvNAvlRNTnEOwsqHTzxozGC();
		}

		public int SetAllElementMapsEnabled(bool state)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			int num = 0;
			int count = OAYBwuRSJSWeyXnFUPwzAefBWTzV.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = OAYBwuRSJSWeyXnFUPwzAefBWTzV[i];
				if (actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA != state)
				{
					actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA = state;
					num++;
				}
			}
			return num;
		}

		public ActionElementMap GetButtonMap(int index)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			if (xhimarnxTkdcASkSXJKYCZuEUIAA == null || index < 0 || index >= xhimarnxTkdcASkSXJKYCZuEUIAA.Count)
			{
				return null;
			}
			return xhimarnxTkdcASkSXJKYCZuEUIAA[index];
		}

		public ActionElementMap[] GetButtonMaps()
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return EmptyObjects<ActionElementMap>.array;
			}
			return ListTools.ToArray(xhimarnxTkdcASkSXJKYCZuEUIAA);
		}

		public ActionElementMap[] GetButtonMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return EmptyObjects<ActionElementMap>.array;
			}
			int count = xhimarnxTkdcASkSXJKYCZuEUIAA.Count;
			List<ActionElementMap> list = new List<ActionElementMap>(count);
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = xhimarnxTkdcASkSXJKYCZuEUIAA[i];
				if (!skipDisabledMaps || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		public int GetButtonMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			return CusgORhNpBELKKSSCJxAZzWlquUM(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetButtonMapsWithAction(string actionName)
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
			return GetButtonMapsWithAction(inputAction.id);
		}

		public ActionElementMap[] GetButtonMapsWithAction(int actionId)
		{
			return GetButtonMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetButtonMapsWithAction(string actionName, bool skipDisabledMaps)
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
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = buttonMapCount;
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = xhimarnxTkdcASkSXJKYCZuEUIAA[i];
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
				ActionElementMap actionElementMap2 = xhimarnxTkdcASkSXJKYCZuEUIAA[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
				{
					array[num3] = actionElementMap2;
					num3++;
				}
			}
			return array;
		}

		public int GetButtonMapsWithAction(string actionName, List<ActionElementMap> results)
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
			return GetButtonMapsWithAction(inputAction.id, results);
		}

		public int GetButtonMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetButtonMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetButtonMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
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
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			return MeahSXUNzyzWOIzpZetqJqQqRvGA(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId)
		{
			return ButtonMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			return ButtonMapsWithAction(actionId);
		}

		[IteratorStateMachine(typeof(uxPYvBxbUSfMUcHCSbaahWOjKpYv))]
		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new uxPYvBxbUSfMUcHCSbaahWOjKpYv(-2)
			{
				dOLgJqSgUjvOFsNJnFNyVQgapUDF = this,
				THtAItBEdFOZsSxbCTpOVixSDTQsA = actionId,
				JKMrkYLdDNtDUeAYuGcVatJHVLPOA = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			return ButtonMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId)
		{
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstButtonMapWithAction(string actionName)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			return GetFirstButtonMapWithAction(actionId);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
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
			IList<ActionElementMap> buttonMaps = ButtonMaps;
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = buttonMaps[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.enabled))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		public ActionElementMap GetFirstButtonMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			int actionId = ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName);
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			return ftVYFAbrcDDSPOUcHefghadpBybf(predicate, false);
		}

		internal ActionElementMap ftVYFAbrcDDSPOUcHefghadpBybf(Predicate<ActionElementMap> P_0, bool P_1)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			IList<ActionElementMap> buttonMaps = ButtonMaps;
			int num = buttonMapCount;
			try
			{
				for (int i = 0; i < num; i++)
				{
					ActionElementMap actionElementMap = buttonMaps[i];
					if ((!P_1 || actionElementMap.enabled) && P_0(actionElementMap))
					{
						return actionElementMap;
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetFirstButtonMapMatch", exception);
			}
			return null;
		}

		public int GetButtonMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			return alYeQRaRnBhtvnomQunQKOdNIuVZ(predicate, false, results, false);
		}

		internal int alYeQRaRnBhtvnomQunQKOdNIuVZ(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			IList<ActionElementMap> buttonMaps = ButtonMaps;
			int num2 = buttonMapCount;
			try
			{
				for (int i = 0; i < num2; i++)
				{
					ActionElementMap actionElementMap = buttonMaps[i];
					if ((!P_1 || actionElementMap.enabled) && P_0(actionElementMap))
					{
						P_2.Add(actionElementMap);
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetButtonMapMatches", exception);
			}
			return P_2.Count - num;
		}

		public void ForEachButtonMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
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
			int count = xhimarnxTkdcASkSXJKYCZuEUIAA.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = xhimarnxTkdcASkSXJKYCZuEUIAA[i];
					if (predicate(obj))
					{
						actionToPerform(obj);
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetButtonMapMatches", exception);
			}
		}

		public bool DeleteButtonMapsWithAction(string actionName)
		{
			return DeleteButtonMapsWithAction(ReInput.QYXTlPbvvfyHDodSqaxHRoHhFdw.EztnLVitSeSeSlWCFMTQNjrSGAec(actionName));
		}

		public bool DeleteButtonMapsWithAction(int actionId)
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
			int num = buttonMapCount;
			if (num == 0)
			{
				return false;
			}
			bool result = false;
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = xhimarnxTkdcASkSXJKYCZuEUIAA[num2];
				if (actionElementMap != null && actionElementMap._actionId == actionId)
				{
					lVRoitXnzttxGnqFTUnaAYkPBxWo(actionElementMap.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc, num2);
					result = true;
				}
			}
			return result;
		}

		public int SetAllButtonMapsEnabled(bool state)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			int num = 0;
			int count = xhimarnxTkdcASkSXJKYCZuEUIAA.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = xhimarnxTkdcASkSXJKYCZuEUIAA[i];
				if (actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA != state)
				{
					actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA = state;
					num++;
				}
			}
			return num;
		}

		public bool DoesElementAssignmentConflict(ControllerMap controllerMap)
		{
			return DoesElementAssignmentConflict(controllerMap, skipDisabledMaps: false);
		}

		public bool DoesElementAssignmentConflict(ActionElementMap actionElementMap)
		{
			return DoesElementAssignmentConflict(actionElementMap, skipDisabledMaps: false);
		}

		public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck)
		{
			return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps: false);
		}

		public virtual bool DoesElementAssignmentConflict(ControllerMap controllerMap, bool skipDisabledMaps)
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
			if (skipDisabledMaps && (!_enabled || !controllerMap._enabled))
			{
				return false;
			}
			if (xhimarnxTkdcASkSXJKYCZuEUIAA == null)
			{
				return false;
			}
			IList<ActionElementMap> buttonMaps = controllerMap.ButtonMaps;
			if (buttonMaps == null)
			{
				return false;
			}
			int num = buttonMapCount;
			int count = buttonMaps.Count;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = xhimarnxTkdcASkSXJKYCZuEUIAA[i];
				if (skipDisabledMaps && !actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA)
				{
					continue;
				}
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap2 = buttonMaps[j];
					if ((!skipDisabledMaps || actionElementMap2.KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && actionElementMap != actionElementMap2 && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return false;
			}
			if (actionElementMap == null || xhimarnxTkdcASkSXJKYCZuEUIAA == null)
			{
				return false;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
			{
				return false;
			}
			for (int i = 0; i < xhimarnxTkdcASkSXJKYCZuEUIAA.Count; i++)
			{
				ActionElementMap actionElementMap2 = xhimarnxTkdcASkSXJKYCZuEUIAA[i];
				if ((!skipDisabledMaps || actionElementMap2.KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && actionElementMap2 != actionElementMap && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return false;
			}
			if (xhimarnxTkdcASkSXJKYCZuEUIAA == null)
			{
				return false;
			}
			if (skipDisabledMaps && !_enabled)
			{
				return false;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				return false;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			for (int i = 0; i < xhimarnxTkdcASkSXJKYCZuEUIAA.Count; i++)
			{
				ActionElementMap actionElementMap = xhimarnxTkdcASkSXJKYCZuEUIAA[i];
				if ((!skipDisabledMaps || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && actionElementMap.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					return true;
				}
			}
			return false;
		}

		public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap)
		{
			return ElementAssignmentConflicts(controllerMap, skipDisabledMaps: false);
		}

		public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			return ElementAssignmentConflicts(actionElementMap, skipDisabledMaps: false);
		}

		public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false);
		}

		[IteratorStateMachine(typeof(besLTDxtowbfinFMHdIenMLjtBkT))]
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			return new besLTDxtowbfinFMHdIenMLjtBkT(-2)
			{
				wGEWhgBFQZAgkiFJMPcenOYzlKRW = this,
				EvbjBIrSlKAMehBSYqXMJBCpBKOE = controllerMap,
				eDqiwueYtDVkyRUUqFrVxsBgtMzJA = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(swgCaFQLBFZzkGJaIAMgboOzeKhT))]
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			return new swgCaFQLBFZzkGJaIAMgboOzeKhT(-2)
			{
				ZlvUuUBUkOEYcXythTBxSMSBJiVm = this,
				uIgkKavoqYEJYfwYFCUfygXTxtBt = actionElementMap,
				XrDEfTCPQKBxoORvKDMjJcAcUigu = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(QiAbfsASEtwWMzhiJaOPXSYmMwdD))]
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			return new QiAbfsASEtwWMzhiJaOPXSYmMwdD(-2)
			{
				XwXjqZcYNFkPIBLJRBTwmCAGCRVw = this,
				FepmEafZjvJkgeOnTdQjDJyLbUJEb = conflictCheck,
				SrZxYOZhMZeLboBojdjKUgaUZvBK = skipDisabledMaps
			};
		}

		public int RemoveElementAssignmentConflicts(ControllerMap controllerMap)
		{
			return RemoveElementAssignmentConflicts(controllerMap, skipDisabledMaps: false);
		}

		public int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			return RemoveElementAssignmentConflicts(actionElementMap, skipDisabledMaps: false);
		}

		public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			return RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false);
		}

		public virtual int RemoveElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
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
			if (skipDisabledMaps && (!_enabled || !controllerMap._enabled))
			{
				return 0;
			}
			int num = 0;
			if (xhimarnxTkdcASkSXJKYCZuEUIAA == null)
			{
				return num;
			}
			IList<ActionElementMap> list = controllerMap.xhimarnxTkdcASkSXJKYCZuEUIAA;
			if (list == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			_ = buttonMapCount;
			int count = list.Count;
			for (int num2 = xhimarnxTkdcASkSXJKYCZuEUIAA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = xhimarnxTkdcASkSXJKYCZuEUIAA[num2];
				if (!skipDisabledMaps || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA)
				{
					for (int i = 0; i < count; i++)
					{
						if ((!skipDisabledMaps || list[i].KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && actionElementMap.CheckForAssignmentConflict(list[i]))
						{
							lVRoitXnzttxGnqFTUnaAYkPBxWo(actionElementMap.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc, num2);
							num++;
							break;
						}
					}
				}
			}
			return num;
		}

		public virtual int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
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
			if (skipDisabledMaps && (!_enabled || !actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
			{
				return 0;
			}
			int num = 0;
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			if (xhimarnxTkdcASkSXJKYCZuEUIAA == null)
			{
				return num;
			}
			for (int num2 = xhimarnxTkdcASkSXJKYCZuEUIAA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = xhimarnxTkdcASkSXJKYCZuEUIAA[num2];
				if ((!skipDisabledMaps || actionElementMap2.KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					lVRoitXnzttxGnqFTUnaAYkPBxWo(actionElementMap2.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc, num2);
					num++;
				}
			}
			return num;
		}

		public virtual int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			if (skipDisabledMaps && !_enabled)
			{
				return 0;
			}
			if (xhimarnxTkdcASkSXJKYCZuEUIAA == null)
			{
				return 0;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				return 0;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return 0;
			}
			if (!mapCategory.userAssignable)
			{
				return 0;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			int num = 0;
			for (int num2 = xhimarnxTkdcASkSXJKYCZuEUIAA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = xhimarnxTkdcASkSXJKYCZuEUIAA[num2];
				if ((!skipDisabledMaps || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && actionElementMap.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					lVRoitXnzttxGnqFTUnaAYkPBxWo(actionElementMap.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc, num2);
					num++;
				}
			}
			return num;
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			return SJDSKtDjzvpmHSjUMqbaQhsuKinu(controllerMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			return ENwaWcDXgcpQoycGjOSWKYNmEVtP(actionElementMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			return mVGdaCFqXulnKnVLNgZpLfBpQtJL(conflictCheck, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			return SJDSKtDjzvpmHSjUMqbaQhsuKinu(controllerMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			return ENwaWcDXgcpQoycGjOSWKYNmEVtP(actionElementMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			return mVGdaCFqXulnKnVLNgZpLfBpQtJL(conflictCheck, skipDisabledMaps, null, false);
		}

		internal virtual int SJDSKtDjzvpmHSjUMqbaQhsuKinu(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_0 == null)
			{
				return 0;
			}
			if (P_1 && (!_enabled || !P_0._enabled))
			{
				return 0;
			}
			int num = 0;
			if (xhimarnxTkdcASkSXJKYCZuEUIAA == null)
			{
				return num;
			}
			IList<ActionElementMap> list = P_0.xhimarnxTkdcASkSXJKYCZuEUIAA;
			if (list == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int num2 = buttonMapCount;
			int count = list.Count;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = xhimarnxTkdcASkSXJKYCZuEUIAA[i];
				if (!actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA)
				{
					continue;
				}
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap2 = list[j];
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

		internal virtual int ENwaWcDXgcpQoycGjOSWKYNmEVtP(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_0 == null)
			{
				return 0;
			}
			if (P_1 && (!_enabled || !P_0.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
			{
				return 0;
			}
			int num = 0;
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
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = xhimarnxTkdcASkSXJKYCZuEUIAA[i];
				if (actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA && P_0.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual int mVGdaCFqXulnKnVLNgZpLfBpQtJL(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_1 && !_enabled)
			{
				return 0;
			}
			if (xhimarnxTkdcASkSXJKYCZuEUIAA == null)
			{
				return 0;
			}
			if (P_0.elementAssignmentType != ElementAssignmentType.Button && P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				return 0;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return 0;
			}
			if (!mapCategory.userAssignable)
			{
				return 0;
			}
			ElementAssignment elementAssignment = P_0.ToElementAssignment();
			int num = 0;
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = xhimarnxTkdcASkSXJKYCZuEUIAA[i];
				if (actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA && actionElementMap.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		public int ForEachElementAssignmentConflict(ControllerMap controllerMap, Action<ActionElementMap> actionToPerform)
		{
			return ForEachElementAssignmentConflict(controllerMap, actionToPerform, skipDisabledMaps: false);
		}

		public int ForEachElementAssignmentConflict(ActionElementMap actionElementMap, Action<ActionElementMap> actionToPerform)
		{
			return ForEachElementAssignmentConflict(actionElementMap, actionToPerform, skipDisabledMaps: false);
		}

		public int ForEachElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, Action<ActionElementMap> actionToPerform)
		{
			return ForEachElementAssignmentConflict(conflictCheck, actionToPerform, skipDisabledMaps: false);
		}

		public int ForEachElementAssignmentConflict(ControllerMap controllerMap, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			if (controllerMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!_enabled || !controllerMap._enabled))
			{
				return 0;
			}
			int num = 0;
			if (OAYBwuRSJSWeyXnFUPwzAefBWTzV == null)
			{
				return num;
			}
			IList<ActionElementMap> oAYBwuRSJSWeyXnFUPwzAefBWTzV = controllerMap.OAYBwuRSJSWeyXnFUPwzAefBWTzV;
			if (oAYBwuRSJSWeyXnFUPwzAefBWTzV == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int count = oAYBwuRSJSWeyXnFUPwzAefBWTzV.Count;
			for (int num2 = OAYBwuRSJSWeyXnFUPwzAefBWTzV.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = OAYBwuRSJSWeyXnFUPwzAefBWTzV[num2];
				if (!skipDisabledMaps || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA)
				{
					for (int i = 0; i < count; i++)
					{
						if ((!skipDisabledMaps || oAYBwuRSJSWeyXnFUPwzAefBWTzV[i].KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && actionElementMap.CheckForAssignmentConflict(oAYBwuRSJSWeyXnFUPwzAefBWTzV[i]))
						{
							try
							{
								actionToPerform(actionElementMap);
							}
							catch (Exception exception)
							{
								ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
								return num;
							}
							num++;
							break;
						}
					}
				}
			}
			return num;
		}

		public int ForEachElementAssignmentConflict(ActionElementMap actionElementMap, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
			{
				return 0;
			}
			int num = 0;
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			if (OAYBwuRSJSWeyXnFUPwzAefBWTzV == null)
			{
				return num;
			}
			for (int num2 = OAYBwuRSJSWeyXnFUPwzAefBWTzV.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = OAYBwuRSJSWeyXnFUPwzAefBWTzV[num2];
				if ((!skipDisabledMaps || actionElementMap2.KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					try
					{
						actionToPerform(actionElementMap2);
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
						return num;
					}
					num++;
				}
			}
			return num;
		}

		public int ForEachElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return 0;
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			if (skipDisabledMaps && !_enabled)
			{
				return 0;
			}
			if (OAYBwuRSJSWeyXnFUPwzAefBWTzV == null)
			{
				return 0;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				return 0;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return 0;
			}
			if (!mapCategory.userAssignable)
			{
				return 0;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			int num = 0;
			for (int num2 = OAYBwuRSJSWeyXnFUPwzAefBWTzV.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = OAYBwuRSJSWeyXnFUPwzAefBWTzV[num2];
				if ((!skipDisabledMaps || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && actionElementMap.ZwmcQAFJNCcNOFRJeAGabSeBNAxXc != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					try
					{
						actionToPerform(actionElementMap);
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
						return num;
					}
					num++;
				}
			}
			return num;
		}

		public string[] GetButtonNames()
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return EmptyObjects<string>.array;
			}
			int num = buttonMapCount;
			if (num == 0)
			{
				return new string[0];
			}
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = xhimarnxTkdcASkSXJKYCZuEUIAA[i].elementIdentifierName;
			}
			return array;
		}

		public string ToXmlString()
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return string.Empty;
			}
			try
			{
				return ZLXWGtXDztRmPBFRSzAGqTZGcWJf().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return string.Empty;
			}
			try
			{
				return ZLXWGtXDztRmPBFRSzAGqTZGcWJf().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerTemplateMap ToControllerTemplateMap(Guid templateTypeGuid)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			if (controller == null)
			{
				Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", requiredThreadSafety: true);
				return null;
			}
			IControllerTemplate controllerTemplate = controller.GetTemplate(templateTypeGuid) ?? (controller.GetTemplate(templateTypeGuid) as ControllerTemplate);
			if (controllerTemplate == null)
			{
				yEMXOGECwzMVyBoTWRRwImnnslF yEMXOGECwzMVyBoTWRRwImnnslF2 = ReInput.TnoFTDOTIhrtqdBSnqaAenKTnBzK(templateTypeGuid);
				string text = ((yEMXOGECwzMVyBoTWRRwImnnslF2 != null) ? yEMXOGECwzMVyBoTWRRwImnnslF2.UGtDpZJobIRXKMYZuTpxgiAqjMTCA : templateTypeGuid.ToString());
				Logger.LogError("The Controller does not implement " + text + ".", requiredThreadSafety: true);
				return null;
			}
			return ControllerTemplateMap.YYXtioexYoyfWsWVuvvZfObLhQbJ(controllerTemplate, this);
		}

		public ControllerTemplateMap ToControllerTemplateMap<T>() where T : class
		{
			return ToControllerTemplateMap(typeof(T));
		}

		public ControllerTemplateMap ToControllerTemplateMap(Type templateInterfaceType)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			if (templateInterfaceType == null)
			{
				throw new ArgumentNullException("templateInterfaceType");
			}
			if (controller == null)
			{
				Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", requiredThreadSafety: true);
				return null;
			}
			IControllerTemplate controllerTemplate = controller.GetTemplate(templateInterfaceType) ?? (controller.GetTemplate(templateInterfaceType) as ControllerTemplate);
			if (controllerTemplate == null)
			{
				Logger.LogError("The Controller does not implement " + templateInterfaceType.Name + ".", requiredThreadSafety: true);
				return null;
			}
			return ControllerTemplateMap.YYXtioexYoyfWsWVuvvZfObLhQbJ(controllerTemplate, this);
		}

		private ControllerTemplateMap pNZlGyxSvxXuQpahVbbOvIxhdDOA(IControllerTemplate P_0)
		{
			if (ReInput._id != HGKnnYgsStSHzmTMXitKKPatJYAf)
			{
				ReInput.CheckInitialized(HGKnnYgsStSHzmTMXitKKPatJYAf);
				return null;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			return ControllerTemplateMap.YYXtioexYoyfWsWVuvvZfObLhQbJ(P_0, this);
		}

		internal virtual bool sDqHEWbyPiYMwKMUolFtvnYYDxDXA(ActionElementMap P_0)
		{
			if (!eKPaNbzFEdgcAfZtdyuYwxQtUgwD(P_0._elementType))
			{
				return false;
			}
			pPbRvnhAQENFdreHzRuIhtwkuRMN(P_0);
			return true;
		}

		internal virtual int KYJJlQDnUQbhhyWAENYGgqlpAjSV(List<ActionElementMap> P_0, bool P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("results");
			}
			int count = P_0.Count;
			int count2 = xhimarnxTkdcASkSXJKYCZuEUIAA.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!P_1 || xhimarnxTkdcASkSXJKYCZuEUIAA[i].KDuOcDwQLQHhwDRrYdOMFXnFZITxA)
				{
					P_0.Add(xhimarnxTkdcASkSXJKYCZuEUIAA[i]);
				}
			}
			return P_0.Count - count;
		}

		internal virtual ActionElementMap fHnnHlRyOPPhnWZLTlCeIMSdLTrN(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!eKPaNbzFEdgcAfZtdyuYwxQtUgwD(P_2))
			{
				return null;
			}
			int num = PMvJdwYtrfXnfRfpjohzKsuAgGLb(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			return xhimarnxTkdcASkSXJKYCZuEUIAA[num];
		}

		internal virtual int OUCEFNZhJSbeOjpjdiBRJzjTybueA(int P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = 0;
			if (!P_2)
			{
				P_1.Clear();
			}
			else
			{
				num = P_1.Count;
			}
			if (xhimarnxTkdcASkSXJKYCZuEUIAA == null)
			{
				return 0;
			}
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				if (xhimarnxTkdcASkSXJKYCZuEUIAA[i]._elementIdentifierId == P_0)
				{
					P_1.Add(xhimarnxTkdcASkSXJKYCZuEUIAA[i]);
				}
			}
			return P_1.Count - num;
		}

		internal virtual bool JpGLLusuFDLYAJzsZIVOLaoFuptb(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!eKPaNbzFEdgcAfZtdyuYwxQtUgwD(P_2))
			{
				return false;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (xhimarnxTkdcASkSXJKYCZuEUIAA[i]._elementIdentifierId == P_0 && xhimarnxTkdcASkSXJKYCZuEUIAA[i]._actionId == P_1)
				{
					return true;
				}
			}
			return false;
		}

		internal virtual int PMvJdwYtrfXnfRfpjohzKsuAgGLb(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!eKPaNbzFEdgcAfZtdyuYwxQtUgwD(P_2))
			{
				return -1;
			}
			if (xhimarnxTkdcASkSXJKYCZuEUIAA == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (xhimarnxTkdcASkSXJKYCZuEUIAA[i]._elementIdentifierId == P_0 && xhimarnxTkdcASkSXJKYCZuEUIAA[i]._actionId == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		internal int kDNRqFtgVPhutFhtIdXafjtoiZXD(int P_0)
		{
			if (xhimarnxTkdcASkSXJKYCZuEUIAA == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (xhimarnxTkdcASkSXJKYCZuEUIAA[i].ZwmcQAFJNCcNOFRJeAGabSeBNAxXc == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal int CusgORhNpBELKKSSCJxAZzWlquUM(bool P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_2)
			{
				P_1.Clear();
			}
			int num = buttonMapCount;
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = xhimarnxTkdcASkSXJKYCZuEUIAA[i];
				if (!P_0 || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA)
				{
					P_1.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal int MeahSXUNzyzWOIzpZetqJqQqRvGA(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_3)
			{
				P_2.Clear();
			}
			int num = buttonMapCount;
			if (num == 0)
			{
				return 0;
			}
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = xhimarnxTkdcASkSXJKYCZuEUIAA[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
				{
					P_2.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal virtual int cAwvQRajuNSdcVfCIbMQuiDVTnmt(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = xhimarnxTkdcASkSXJKYCZuEUIAA[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.KDuOcDwQLQHhwDRrYdOMFXnFZITxA))
				{
					P_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual ActionElementMap rLYedBCsdtfUPGpuxQjkUgoLtSyKA(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			P_4 = false;
			if (P_1 && P_2 < 0)
			{
				P_4 = true;
				return null;
			}
			if (!cAICslKkFgWNZLdLaKdZlhxjIHclA(P_0))
			{
				P_4 = true;
				return null;
			}
			if (!eKPaNbzFEdgcAfZtdyuYwxQtUgwD(P_0.elementType))
			{
				return null;
			}
			int num = buttonMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num; i++)
			{
				if ((!P_1 || xhimarnxTkdcASkSXJKYCZuEUIAA[i]._actionId == P_2) && (!P_3 || xhimarnxTkdcASkSXJKYCZuEUIAA[i].KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && xhimarnxTkdcASkSXJKYCZuEUIAA[i].IsTarget(P_0))
				{
					return xhimarnxTkdcASkSXJKYCZuEUIAA[i];
				}
			}
			return null;
		}

		internal virtual int GkqChYlZGQOzIisFIMtpFCNiEOLd(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
		{
			if (P_4 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = 0;
			if (!P_5)
			{
				P_4.Clear();
			}
			P_6 = false;
			if (P_1 && P_2 < 0)
			{
				P_6 = true;
				return num;
			}
			if (!cAICslKkFgWNZLdLaKdZlhxjIHclA(P_0))
			{
				P_6 = true;
				return num;
			}
			if (!eKPaNbzFEdgcAfZtdyuYwxQtUgwD(P_0.elementType))
			{
				return num;
			}
			int num2 = buttonMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num2; i++)
			{
				if ((!P_1 || xhimarnxTkdcASkSXJKYCZuEUIAA[i]._actionId == P_2) && (!P_3 || xhimarnxTkdcASkSXJKYCZuEUIAA[i].KDuOcDwQLQHhwDRrYdOMFXnFZITxA) && xhimarnxTkdcASkSXJKYCZuEUIAA[i].IsTarget(P_0))
				{
					P_4.Add(xhimarnxTkdcASkSXJKYCZuEUIAA[i]);
					num++;
				}
			}
			return num;
		}

		internal void lSVtRFqqPHdHEwrQYYNUzAfHnTgK(int P_0, ControllerElementType P_1)
		{
			ActionElementMap elementMap = GetElementMap(P_0);
			if (elementMap != null && elementMap._elementType != P_1)
			{
				elementMap._elementType = P_1;
				if (P_1 == ControllerElementType.Button)
				{
					elementMap._axisRange = AxisRange.Full;
					elementMap._invert = false;
				}
				DeleteElementMap(P_0);
				peOcNMbNqkWzcKHHCLVaSANBAxWAA(elementMap);
			}
		}

		internal virtual bool peOcNMbNqkWzcKHHCLVaSANBAxWAA(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (!eKPaNbzFEdgcAfZtdyuYwxQtUgwD(P_0._elementType))
			{
				return false;
			}
			xhimarnxTkdcASkSXJKYCZuEUIAA.Add(P_0);
			dqdTKZnNqADmqKijgGQugOoGVLjIA(P_0);
			return true;
		}

		internal bool cAICslKkFgWNZLdLaKdZlhxjIHclA(IControllerElementTarget P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			Controller controller = P_0.controller;
			if (controller == null || controller.type != _controllerType || controller.id != _controllerId)
			{
				return false;
			}
			return true;
		}

		internal bool aFXcxTdtoLrAHgjbWpeHHiLAEmAjc(string P_0)
		{
			try
			{
				mzuFctNdLWIzjUTtnfaDPZneMaWd(SerializedObject.FromXml(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from XML. " + ex.Message);
				return false;
			}
		}

		internal bool ZJYcZKuCueWpSBHqwGmVwGhyAMPB(string P_0)
		{
			try
			{
				mzuFctNdLWIzjUTtnfaDPZneMaWd(SerializedObject.FromJson(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from JSON. " + ex.Message);
				return false;
			}
		}

		internal void dqdTKZnNqADmqKijgGQugOoGVLjIA(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				OAYBwuRSJSWeyXnFUPwzAefBWTzV.Add(P_0);
				OAYBwuRSJSWeyXnFUPwzAefBWTzV.Sort(wWWhYpqIlazmCqqnQjIAokOnxeml.cYlBujxUeNFdEBngsbNrfseJPwZqA);
				wqUbVrvNAvlRNTnEOwsqHTzxozGC();
			}
		}

		internal void vkdkLIdgkmqhzclcMPgXqkmXpnNL(int P_0)
		{
			int num = ykwstMeJwPGMrqTBnUAeUQOAeitp(P_0);
			if (num >= 0)
			{
				OAYBwuRSJSWeyXnFUPwzAefBWTzV.RemoveAt(num);
				wqUbVrvNAvlRNTnEOwsqHTzxozGC();
			}
		}

		internal void HktKLlwzinhTipeznBGSbGPmJtafb(int P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				int num = ykwstMeJwPGMrqTBnUAeUQOAeitp(P_0);
				if (num >= 0)
				{
					OAYBwuRSJSWeyXnFUPwzAefBWTzV[num] = P_1;
					OAYBwuRSJSWeyXnFUPwzAefBWTzV.Sort(wWWhYpqIlazmCqqnQjIAokOnxeml.cYlBujxUeNFdEBngsbNrfseJPwZqA);
					wqUbVrvNAvlRNTnEOwsqHTzxozGC();
				}
			}
		}

		internal static void lOevVLipIpvXFMfnghcFUOdDBQveA(ActionElementMap P_0, int P_1, Pole P_2, int P_3, ControllerElementType P_4, AxisRange P_5, bool P_6)
		{
			P_0.FeaKSxXPUexcOObMrHqzNwEaFjbB();
			P_0._actionId = P_1;
			P_0._elementType = P_4;
			P_0._elementIdentifierId = P_3;
			P_0._axisContribution = P_2;
			P_0._axisRange = P_5;
			if (P_4 == ControllerElementType.Axis)
			{
				P_0._invert = P_6;
			}
			P_0.GRbJLLzUgxIUuVqccrTRTBklfgP();
		}

		protected void BakeElementMap(ActionElementMap map)
		{
			if (map != null)
			{
				ReInput.controllers.GetController(_controllerType, _controllerId)?.duSGjNZdSxSjezvmjyDBFGtlyxPL(this, map);
			}
		}

		internal virtual bool mzuFctNdLWIzjUTtnfaDPZneMaWd(SerializedObject P_0)
		{
			bool flag = false;
			_sourceMapId = -1;
			_categoryId = -1;
			_layoutId = -1;
			_name = string.Empty;
			_hardwareGuid = Guid.Empty;
			_enabled = true;
			P_0.TryGetDeserializedValueByRef("sourceMapId", ref _sourceMapId);
			P_0.TryGetDeserializedValueByRef("categoryId", ref _categoryId);
			P_0.TryGetDeserializedValueByRef("layoutId", ref _layoutId);
			P_0.TryGetDeserializedValueByRef("name", ref _name);
			P_0.TryGetDeserializedValueByRef("hardwareGuid", ref _hardwareGuid);
			P_0.TryGetDeserializedValueByRef("enabled", ref _enabled);
			if (!flag)
			{
				ClearElementMaps();
				flag = true;
			}
			SerializedObject value = null;
			if (P_0.TryGetDeserializedValueByRef("buttonMaps", ref value) && value != null)
			{
				for (int i = 0; i < value.count; i++)
				{
					if (value.TryGetDeserializedValue<SerializedObject>(i, out var value2) || value2 == null)
					{
						ActionElementMap actionElementMap = new ActionElementMap();
						actionElementMap.ZNvvGNYySdbNFoPsGmVngIzJvSeR(value2);
						if (ActionElementMap.VdmsOtoEsMwzdRcQfykDcBXVxTkW(actionElementMap))
						{
							pPbRvnhAQENFdreHzRuIhtwkuRMN(actionElementMap);
						}
					}
				}
			}
			wqUbVrvNAvlRNTnEOwsqHTzxozGC();
			return flag;
		}

		internal virtual void TjYYzAvYaCXBvfPYwRHuiHnMpIU(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
			}
			P_0.Add("dataVersion", 2, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.zyMcqofvUObnbwctwMfJTHVAopqx
			{
				ErrnmJxSDTWdHuymqJxfqXJFoSMv = "dataVersion",
				LBGjqqZxEPBjvHqNhMVicOdoqakWA = 2.ToString()
			});
			if ((object)GetType() == typeof(JoystickMap))
			{
				Joystick joystick = ReInput.controllers.GetJoystick(_controllerId);
				Guid guid = joystick?.hardwareTypeGuid ?? Guid.Empty;
				string lBGjqqZxEPBjvHqNhMVicOdoqakWA = ((joystick != null) ? SerializationTools.CleanInvalidXmlChars(joystick.hardwareName) : "Unknown");
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.zyMcqofvUObnbwctwMfJTHVAopqx
				{
					ErrnmJxSDTWdHuymqJxfqXJFoSMv = "hardwareGuid",
					LBGjqqZxEPBjvHqNhMVicOdoqakWA = guid.ToString()
				});
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.zyMcqofvUObnbwctwMfJTHVAopqx
				{
					ErrnmJxSDTWdHuymqJxfqXJFoSMv = "hardwareName",
					LBGjqqZxEPBjvHqNhMVicOdoqakWA = lBGjqqZxEPBjvHqNhMVicOdoqakWA
				});
			}
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.zyMcqofvUObnbwctwMfJTHVAopqx
			{
				rIDwIrwPWptYvehlvTmbuztcaWmR = "xmlns",
				ErrnmJxSDTWdHuymqJxfqXJFoSMv = "xsi",
				oELDSJjGHqeiaFEdgDPOLYTSXoPLb = null,
				LBGjqqZxEPBjvHqNhMVicOdoqakWA = "http://www.w3.org/2001/XMLSchema-instance"
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.zyMcqofvUObnbwctwMfJTHVAopqx
			{
				rIDwIrwPWptYvehlvTmbuztcaWmR = "xsi",
				ErrnmJxSDTWdHuymqJxfqXJFoSMv = "schemaLocation",
				oELDSJjGHqeiaFEdgDPOLYTSXoPLb = null,
				LBGjqqZxEPBjvHqNhMVicOdoqakWA = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.1", "/", GetType().Name, ".xsd")
			});
			P_0.Add("sourceMapId", _sourceMapId);
			P_0.Add("categoryId", _categoryId);
			P_0.Add("layoutId", _layoutId);
			P_0.Add("name", _name);
			P_0.Add("hardwareGuid", _hardwareGuid);
			P_0.Add("enabled", _enabled);
			int num = buttonMapCount;
			List<object> list = new List<object>();
			P_0.Add("buttonMaps", list);
			for (int i = 0; i < num; i++)
			{
				if (xhimarnxTkdcASkSXJKYCZuEUIAA[i] != null)
				{
					list.Add(xhimarnxTkdcASkSXJKYCZuEUIAA[i].RcsRHzgGloagFZmXHxLUSERKfrzZ());
				}
			}
		}

		private bool eKPaNbzFEdgcAfZtdyuYwxQtUgwD(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Button)
			{
				return false;
			}
			return true;
		}

		private void lVRoitXnzttxGnqFTUnaAYkPBxWo(int P_0, int P_1)
		{
			vkdkLIdgkmqhzclcMPgXqkmXpnNL(P_0);
			if (P_1 >= 0 && P_1 < buttonMapCount)
			{
				xhimarnxTkdcASkSXJKYCZuEUIAA.RemoveAt(P_1);
			}
		}

		private void pPbRvnhAQENFdreHzRuIhtwkuRMN(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				xhimarnxTkdcASkSXJKYCZuEUIAA.Add(P_0);
				dqdTKZnNqADmqKijgGQugOoGVLjIA(P_0);
			}
		}

		private void GDjefjFlAGHmxxbQaSsEKBgMgEkgb(ActionElementMap P_0, int P_1)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < buttonMapCount)
			{
				HktKLlwzinhTipeznBGSbGPmJtafb(xhimarnxTkdcASkSXJKYCZuEUIAA[P_1].ZwmcQAFJNCcNOFRJeAGabSeBNAxXc, P_0);
				xhimarnxTkdcASkSXJKYCZuEUIAA[P_1] = P_0;
			}
		}

		private int ykwstMeJwPGMrqTBnUAeUQOAeitp(int P_0)
		{
			if (OAYBwuRSJSWeyXnFUPwzAefBWTzV == null)
			{
				return -1;
			}
			int count = OAYBwuRSJSWeyXnFUPwzAefBWTzV.Count;
			for (int i = 0; i < count; i++)
			{
				if (OAYBwuRSJSWeyXnFUPwzAefBWTzV[i].ZwmcQAFJNCcNOFRJeAGabSeBNAxXc == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private SerializedObject ZLXWGtXDztRmPBFRSzAGqTZGcWJf()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			TjYYzAvYaCXBvfPYwRHuiHnMpIU(serializedObject);
			return serializedObject;
		}

		internal void wqUbVrvNAvlRNTnEOwsqHTzxozGC()
		{
			if (!IlXcdaRlNSFIvcdRoZnDHsAGLAGs)
			{
				UUCBrsqhEGpknwYUTCVeYJuDUoat = ReInput.realTime;
			}
		}

		public static ControllerMap Create(Controller controller, int categoryId, int layoutId)
		{
			return iunHkujkyKtGOyVzXXcDBqMRPdDd(controller, categoryId, layoutId);
		}

		internal static ControllerMap JEyMkYAwWgEipyvdoVluCMXeWMM(ControllerType P_0)
		{
			return P_0 switch
			{
				ControllerType.Keyboard => new KeyboardMap(), 
				ControllerType.Mouse => new MouseMap(), 
				ControllerType.Joystick => new JoystickMap(), 
				ControllerType.Custom => new CustomControllerMap(), 
				_ => throw new NotImplementedException(), 
			};
		}

		internal static ControllerMap iunHkujkyKtGOyVzXXcDBqMRPdDd(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return P_0.type switch
			{
				ControllerType.Keyboard => KeyboardMap.jVEWWCHzhLiHJGXxrFWjdHOMwbmr(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Mouse => MouseMap.vYSpCjXbylhiPqMqIhAsPjENAnFX(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Joystick => JoystickMap.xUbaCbIBivOhfJHPSRGOnyonQDpiA(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Custom => CustomControllerMap.yYPdeDaWFrpDakaAECckYYKAjEwp(P_0.hardwareTypeGuid, ((CustomController)P_0).sourceControllerId, P_1, P_2), 
				_ => throw new NotImplementedException(), 
			};
		}

		public static ControllerMap CreateFromXml(ControllerType controllerType, string xmlString)
		{
			if (string.IsNullOrEmpty(xmlString))
			{
				return null;
			}
			ControllerMap controllerMap = JEyMkYAwWgEipyvdoVluCMXeWMM(controllerType);
			try
			{
				lRmYCoCSmOckdAxZaAzbXHOzxRbC();
				controllerMap.aFXcxTdtoLrAHgjbWpeHHiLAEmAjc(xmlString);
				return controllerMap;
			}
			catch
			{
				return null;
			}
			finally
			{
				GHMgTTbTNZrCoRvrTvpOrmMMxTwr();
			}
		}

		public static ControllerMap CreateFromJson(ControllerType controllerType, string jsonString)
		{
			if (string.IsNullOrEmpty(jsonString))
			{
				return null;
			}
			ControllerMap controllerMap = JEyMkYAwWgEipyvdoVluCMXeWMM(controllerType);
			try
			{
				lRmYCoCSmOckdAxZaAzbXHOzxRbC();
				controllerMap.ZJYcZKuCueWpSBHqwGmVwGhyAMPB(jsonString);
				return controllerMap;
			}
			catch
			{
				return null;
			}
			finally
			{
				GHMgTTbTNZrCoRvrTvpOrmMMxTwr();
			}
		}

		internal static void lRmYCoCSmOckdAxZaAzbXHOzxRbC()
		{
			cmDFcveJLeaxwaRaGoTSFVQlmiTnb++;
		}

		internal static void GHMgTTbTNZrCoRvrTvpOrmMMxTwr()
		{
			cmDFcveJLeaxwaRaGoTSFVQlmiTnb--;
			if (cmDFcveJLeaxwaRaGoTSFVQlmiTnb < 0)
			{
				cmDFcveJLeaxwaRaGoTSFVQlmiTnb = 0;
				Logger.LogError("Too many calls to disable internal modify mode!");
			}
		}
	}
}
