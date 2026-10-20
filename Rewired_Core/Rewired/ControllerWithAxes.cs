using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerWithAxes : ControllerWithMap
	{
		private sealed class OqjsoiJPrqDjTJBIqLBdmIHcwoPGA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int WXDCUIoKWRNUEXoVEpEHmYTbFwFt;

			private ControllerPollingInfo ypgZgpJuMXgOvqtvAdTGdIiIQrkQ;

			private int XuZvJsGHuORkfdKOEQIkfOcEFYJEA;

			public ControllerWithAxes mXMJqLsrsUnHfeCfqbaFbOIBqRPx;

			private int zrJrBadCIIbPDiXyzDMBZJjPqVodA;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return ypgZgpJuMXgOvqtvAdTGdIiIQrkQ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ypgZgpJuMXgOvqtvAdTGdIiIQrkQ;
				}
			}

			[DebuggerHidden]
			public OqjsoiJPrqDjTJBIqLBdmIHcwoPGA(int P_0)
			{
				WXDCUIoKWRNUEXoVEpEHmYTbFwFt = P_0;
				XuZvJsGHuORkfdKOEQIkfOcEFYJEA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				WXDCUIoKWRNUEXoVEpEHmYTbFwFt = -2;
			}

			private bool MoveNext()
			{
				int wXDCUIoKWRNUEXoVEpEHmYTbFwFt = WXDCUIoKWRNUEXoVEpEHmYTbFwFt;
				ControllerWithAxes controllerWithAxes = mXMJqLsrsUnHfeCfqbaFbOIBqRPx;
				if (wXDCUIoKWRNUEXoVEpEHmYTbFwFt != 0)
				{
					if (wXDCUIoKWRNUEXoVEpEHmYTbFwFt != 1)
					{
						return false;
					}
					WXDCUIoKWRNUEXoVEpEHmYTbFwFt = -1;
					goto IL_00a8;
				}
				WXDCUIoKWRNUEXoVEpEHmYTbFwFt = -1;
				if (ReInput._id != controllerWithAxes.sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(controllerWithAxes.sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return false;
				}
				controllerWithAxes.UpdatePollingFrameTracking();
				controllerWithAxes.lpeZuTsDMBpzcMllEItVPghBbngdA();
				zrJrBadCIIbPDiXyzDMBZJjPqVodA = 0;
				goto IL_00ba;
				IL_00ba:
				if (zrJrBadCIIbPDiXyzDMBZJjPqVodA < controllerWithAxes._axisCount)
				{
					if (controllerWithAxes.IsPolledAxisActive(zrJrBadCIIbPDiXyzDMBZJjPqVodA, out var pole, out var elementIdentifierId))
					{
						ypgZgpJuMXgOvqtvAdTGdIiIQrkQ = new ControllerPollingInfo(true, -1, controllerWithAxes.id, controllerWithAxes._name, controllerWithAxes._type, ControllerElementType.Axis, zrJrBadCIIbPDiXyzDMBZJjPqVodA, pole, controllerWithAxes.asJEgTisjEcLUALQMOtkJoREArlC.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyboardKeyCode.None);
						WXDCUIoKWRNUEXoVEpEHmYTbFwFt = 1;
						return true;
					}
					goto IL_00a8;
				}
				return false;
				IL_00a8:
				zrJrBadCIIbPDiXyzDMBZJjPqVodA++;
				goto IL_00ba;
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
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				OqjsoiJPrqDjTJBIqLBdmIHcwoPGA oqjsoiJPrqDjTJBIqLBdmIHcwoPGA;
				if (WXDCUIoKWRNUEXoVEpEHmYTbFwFt == -2 && XuZvJsGHuORkfdKOEQIkfOcEFYJEA == Environment.CurrentManagedThreadId)
				{
					WXDCUIoKWRNUEXoVEpEHmYTbFwFt = 0;
					oqjsoiJPrqDjTJBIqLBdmIHcwoPGA = this;
				}
				else
				{
					oqjsoiJPrqDjTJBIqLBdmIHcwoPGA = new OqjsoiJPrqDjTJBIqLBdmIHcwoPGA(0);
					oqjsoiJPrqDjTJBIqLBdmIHcwoPGA.mXMJqLsrsUnHfeCfqbaFbOIBqRPx = mXMJqLsrsUnHfeCfqbaFbOIBqRPx;
				}
				return oqjsoiJPrqDjTJBIqLBdmIHcwoPGA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class gmVBokitTJFerkEgAsTOSPGUwoRQ : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int syQsRzBcsGBYaCZbVovJPlAwTwsSA;

			private ControllerPollingInfo uycNijnMAHLrmWnkRbpScILXnADEA;

			private int CrdJogZbSveVuAQVfkGuOxrnhkpiA;

			public ControllerWithAxes UQJNnNzyrsJlRpHbBCQVUgVnexHf;

			private IEnumerator<ControllerPollingInfo> fKKAgWIAqlbsLwikdTxvazxTYQfe;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return uycNijnMAHLrmWnkRbpScILXnADEA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return uycNijnMAHLrmWnkRbpScILXnADEA;
				}
			}

			[DebuggerHidden]
			public gmVBokitTJFerkEgAsTOSPGUwoRQ(int P_0)
			{
				syQsRzBcsGBYaCZbVovJPlAwTwsSA = P_0;
				CrdJogZbSveVuAQVfkGuOxrnhkpiA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				switch (syQsRzBcsGBYaCZbVovJPlAwTwsSA)
				{
				case -3:
				case 1:
					try
					{
					}
					finally
					{
						nfAMGaZjiQGFVDFXWZiwAAImYvRTA();
					}
					break;
				case -4:
				case 2:
					try
					{
					}
					finally
					{
						KmCfwaEnUBNRwvIcJNzPBAQEMisIA();
					}
					break;
				}
				fKKAgWIAqlbsLwikdTxvazxTYQfe = null;
				syQsRzBcsGBYaCZbVovJPlAwTwsSA = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = syQsRzBcsGBYaCZbVovJPlAwTwsSA;
					ControllerWithAxes uQJNnNzyrsJlRpHbBCQVUgVnexHf = UQJNnNzyrsJlRpHbBCQVUgVnexHf;
					switch (num)
					{
					default:
						return false;
					case 0:
						syQsRzBcsGBYaCZbVovJPlAwTwsSA = -1;
						if (ReInput._id != uQJNnNzyrsJlRpHbBCQVUgVnexHf.sYoYcnbgceNmZCFbjxQoahCmBDVAA)
						{
							ReInput.CheckInitialized(uQJNnNzyrsJlRpHbBCQVUgVnexHf.sYoYcnbgceNmZCFbjxQoahCmBDVAA);
							return false;
						}
						fKKAgWIAqlbsLwikdTxvazxTYQfe = ((Controller)uQJNnNzyrsJlRpHbBCQVUgVnexHf).PollForAllElements().GetEnumerator();
						syQsRzBcsGBYaCZbVovJPlAwTwsSA = -3;
						goto IL_0092;
					case 1:
						syQsRzBcsGBYaCZbVovJPlAwTwsSA = -3;
						goto IL_0092;
					case 2:
						{
							syQsRzBcsGBYaCZbVovJPlAwTwsSA = -4;
							break;
						}
						IL_0092:
						if (fKKAgWIAqlbsLwikdTxvazxTYQfe.MoveNext())
						{
							ControllerPollingInfo current = fKKAgWIAqlbsLwikdTxvazxTYQfe.Current;
							uycNijnMAHLrmWnkRbpScILXnADEA = current;
							syQsRzBcsGBYaCZbVovJPlAwTwsSA = 1;
							return true;
						}
						nfAMGaZjiQGFVDFXWZiwAAImYvRTA();
						fKKAgWIAqlbsLwikdTxvazxTYQfe = null;
						fKKAgWIAqlbsLwikdTxvazxTYQfe = uQJNnNzyrsJlRpHbBCQVUgVnexHf.PollForAllAxes().GetEnumerator();
						syQsRzBcsGBYaCZbVovJPlAwTwsSA = -4;
						break;
					}
					if (fKKAgWIAqlbsLwikdTxvazxTYQfe.MoveNext())
					{
						ControllerPollingInfo current2 = fKKAgWIAqlbsLwikdTxvazxTYQfe.Current;
						uycNijnMAHLrmWnkRbpScILXnADEA = current2;
						syQsRzBcsGBYaCZbVovJPlAwTwsSA = 2;
						return true;
					}
					KmCfwaEnUBNRwvIcJNzPBAQEMisIA();
					fKKAgWIAqlbsLwikdTxvazxTYQfe = null;
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

			private void nfAMGaZjiQGFVDFXWZiwAAImYvRTA()
			{
				syQsRzBcsGBYaCZbVovJPlAwTwsSA = -1;
				if (fKKAgWIAqlbsLwikdTxvazxTYQfe != null)
				{
					fKKAgWIAqlbsLwikdTxvazxTYQfe.Dispose();
				}
			}

			private void KmCfwaEnUBNRwvIcJNzPBAQEMisIA()
			{
				syQsRzBcsGBYaCZbVovJPlAwTwsSA = -1;
				if (fKKAgWIAqlbsLwikdTxvazxTYQfe != null)
				{
					fKKAgWIAqlbsLwikdTxvazxTYQfe.Dispose();
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
				gmVBokitTJFerkEgAsTOSPGUwoRQ gmVBokitTJFerkEgAsTOSPGUwoRQ2;
				if (syQsRzBcsGBYaCZbVovJPlAwTwsSA == -2 && CrdJogZbSveVuAQVfkGuOxrnhkpiA == Environment.CurrentManagedThreadId)
				{
					syQsRzBcsGBYaCZbVovJPlAwTwsSA = 0;
					gmVBokitTJFerkEgAsTOSPGUwoRQ2 = this;
				}
				else
				{
					gmVBokitTJFerkEgAsTOSPGUwoRQ2 = new gmVBokitTJFerkEgAsTOSPGUwoRQ(0);
					gmVBokitTJFerkEgAsTOSPGUwoRQ2.UQJNnNzyrsJlRpHbBCQVUgVnexHf = UQJNnNzyrsJlRpHbBCQVUgVnexHf;
				}
				return gmVBokitTJFerkEgAsTOSPGUwoRQ2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class uwxGjgwnRYmWQsigyRKgZlBzVwBu : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int sJODUHsmQcsoDYsLvwOsgSdsCOXh;

			private ControllerPollingInfo LnRkqRFOGFNLpAETrpvrCDhjUTJE;

			private int TKwROeLewSfMpKiOqGosqhTgvxrqA;

			public ControllerWithAxes giKANQmlfCdXJpQJtiwHrcJsFPXd;

			private IEnumerator<ControllerPollingInfo> rUkOsCtDavsTeAiKFBfoOrlUAoqX;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return LnRkqRFOGFNLpAETrpvrCDhjUTJE;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return LnRkqRFOGFNLpAETrpvrCDhjUTJE;
				}
			}

			[DebuggerHidden]
			public uwxGjgwnRYmWQsigyRKgZlBzVwBu(int P_0)
			{
				sJODUHsmQcsoDYsLvwOsgSdsCOXh = P_0;
				TKwROeLewSfMpKiOqGosqhTgvxrqA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				switch (sJODUHsmQcsoDYsLvwOsgSdsCOXh)
				{
				case -3:
				case 1:
					try
					{
					}
					finally
					{
						XjPBysQrWELAigjQSsJARkRxNAeQ();
					}
					break;
				case -4:
				case 2:
					try
					{
					}
					finally
					{
						SRqsQHPSsZOJsAyBfRPsjuJINEVs();
					}
					break;
				}
				rUkOsCtDavsTeAiKFBfoOrlUAoqX = null;
				sJODUHsmQcsoDYsLvwOsgSdsCOXh = -2;
			}

			private bool MoveNext()
			{
				try
				{
					int num = sJODUHsmQcsoDYsLvwOsgSdsCOXh;
					ControllerWithAxes controllerWithAxes = giKANQmlfCdXJpQJtiwHrcJsFPXd;
					switch (num)
					{
					default:
						return false;
					case 0:
						sJODUHsmQcsoDYsLvwOsgSdsCOXh = -1;
						if (ReInput._id != controllerWithAxes.sYoYcnbgceNmZCFbjxQoahCmBDVAA)
						{
							ReInput.CheckInitialized(controllerWithAxes.sYoYcnbgceNmZCFbjxQoahCmBDVAA);
							return false;
						}
						rUkOsCtDavsTeAiKFBfoOrlUAoqX = ((Controller)controllerWithAxes).PollForAllElementsDown().GetEnumerator();
						sJODUHsmQcsoDYsLvwOsgSdsCOXh = -3;
						goto IL_0092;
					case 1:
						sJODUHsmQcsoDYsLvwOsgSdsCOXh = -3;
						goto IL_0092;
					case 2:
						{
							sJODUHsmQcsoDYsLvwOsgSdsCOXh = -4;
							break;
						}
						IL_0092:
						if (rUkOsCtDavsTeAiKFBfoOrlUAoqX.MoveNext())
						{
							ControllerPollingInfo current = rUkOsCtDavsTeAiKFBfoOrlUAoqX.Current;
							LnRkqRFOGFNLpAETrpvrCDhjUTJE = current;
							sJODUHsmQcsoDYsLvwOsgSdsCOXh = 1;
							return true;
						}
						XjPBysQrWELAigjQSsJARkRxNAeQ();
						rUkOsCtDavsTeAiKFBfoOrlUAoqX = null;
						rUkOsCtDavsTeAiKFBfoOrlUAoqX = controllerWithAxes.PollForAllAxes().GetEnumerator();
						sJODUHsmQcsoDYsLvwOsgSdsCOXh = -4;
						break;
					}
					if (rUkOsCtDavsTeAiKFBfoOrlUAoqX.MoveNext())
					{
						ControllerPollingInfo current2 = rUkOsCtDavsTeAiKFBfoOrlUAoqX.Current;
						LnRkqRFOGFNLpAETrpvrCDhjUTJE = current2;
						sJODUHsmQcsoDYsLvwOsgSdsCOXh = 2;
						return true;
					}
					SRqsQHPSsZOJsAyBfRPsjuJINEVs();
					rUkOsCtDavsTeAiKFBfoOrlUAoqX = null;
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

			private void XjPBysQrWELAigjQSsJARkRxNAeQ()
			{
				sJODUHsmQcsoDYsLvwOsgSdsCOXh = -1;
				if (rUkOsCtDavsTeAiKFBfoOrlUAoqX != null)
				{
					rUkOsCtDavsTeAiKFBfoOrlUAoqX.Dispose();
				}
			}

			private void SRqsQHPSsZOJsAyBfRPsjuJINEVs()
			{
				sJODUHsmQcsoDYsLvwOsgSdsCOXh = -1;
				if (rUkOsCtDavsTeAiKFBfoOrlUAoqX != null)
				{
					rUkOsCtDavsTeAiKFBfoOrlUAoqX.Dispose();
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
				uwxGjgwnRYmWQsigyRKgZlBzVwBu uwxGjgwnRYmWQsigyRKgZlBzVwBu2;
				if (sJODUHsmQcsoDYsLvwOsgSdsCOXh == -2 && TKwROeLewSfMpKiOqGosqhTgvxrqA == Environment.CurrentManagedThreadId)
				{
					sJODUHsmQcsoDYsLvwOsgSdsCOXh = 0;
					uwxGjgwnRYmWQsigyRKgZlBzVwBu2 = this;
				}
				else
				{
					uwxGjgwnRYmWQsigyRKgZlBzVwBu2 = new uwxGjgwnRYmWQsigyRKgZlBzVwBu(0);
					uwxGjgwnRYmWQsigyRKgZlBzVwBu2.giKANQmlfCdXJpQJtiwHrcJsFPXd = giKANQmlfCdXJpQJtiwHrcJsFPXd;
				}
				return uwxGjgwnRYmWQsigyRKgZlBzVwBu2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		protected readonly int _axisCount;

		protected readonly int _axis2DCount;

		protected readonly Axis[] axes;

		protected readonly ReadOnlyCollection<Axis> axes_readOnly;

		protected readonly Axis2D[] axes2D;

		protected readonly ReadOnlyCollection<Axis2D> axes2D_readOnly;

		protected readonly CalibrationMap _calibrationMap;

		private float[] idJbKSyGpZypBlRbzOLWnYzGqXvs;

		private uint lgniLUHbjUfRLdhPStzFSaoZbXyG = uint.MaxValue;

		private TimerAbs dBixiuaKxKsOQwswWqDEAdxDIdDM;

		private float[] TNeIUaQSJxQIIWknfctPilNEkhdE;

		private Func<int, int> xZRHDylztWVtSRfHwikurSxlSRvJ;

		public int axisCount
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return 0;
				}
				return _axisCount;
			}
		}

		public int axis2DCount
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return 0;
				}
				return _axis2DCount;
			}
		}

		public IList<Axis> Axes
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return EmptyObjects<Axis>.EmptyReadOnlyIListT;
				}
				return axes_readOnly;
			}
		}

		public IList<Axis2D> Axes2D
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return EmptyObjects<Axis2D>.EmptyReadOnlyIListT;
				}
				return axes2D_readOnly;
			}
		}

		public CalibrationMap calibrationMap
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return null;
				}
				return _calibrationMap;
			}
		}

		public IList<ControllerElementIdentifier> AxisElementIdentifiers
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return asJEgTisjEcLUALQMOtkJoREArlC.axisElementIdentifiers_readOnly;
			}
		}

		internal ControllerWithAxes(int P_0, InputSource P_1, string P_2, string P_3, string P_4, ControllerType P_5, Guid P_6, int P_7, int P_8, bool[] P_9, HardwareControllerMap_Game P_10, IList<Extension> P_11, ControllerDataUpdater P_12)
			: base(P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_8, P_9, P_10, P_11, P_12)
		{
			_axisCount = P_7;
			axes = new Axis[P_7];
			for (int i = 0; i < P_7; i++)
			{
				axes[i] = new Axis(this, P_10.axisElementIdentifierIds[i], "Axis " + i, P_10.hwAxisRanges[i], P_10.hwAxisInfo[i]);
				jbFNagqnoAaxdDTrNPdAIsxqeCudA(axes[i]);
			}
			axes_readOnly = new ReadOnlyCollection<Axis>(axes);
			Func<int, int> func = null;
			if (base.Extensions.Count > 0 && GetExtension<IAxisCalibrationIndexMap>() != null)
			{
				func = (int num2) => GetExtension<IAxisCalibrationIndexMap>()?.GetMappedAxisIndex(num2) ?? num2;
			}
			_calibrationMap = new CalibrationMap(P_10.hwAxisCalibrationData, P_10.hwAxis2DCalibrationData, func);
			_axis2DCount = P_10.axis2DCount;
			axes2D = new Axis2D[_axis2DCount];
			for (int num = 0; num < _axis2DCount; num++)
			{
				try
				{
					HardwareJoystickMap.CompoundElement axis2DData = P_10.GetAxis2DData(num);
					if (axis2DData == null)
					{
						Logger.LogError("Error creating Axis2D from hardware map! CompoundElement is null!");
						axes2D[num] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + num, null, null, 0, 0, 0, null);
						continue;
					}
					int axisIndex = P_10.GetAxisIndex(axis2DData.componentElementIdentifiers[0]);
					int axisIndex2 = P_10.GetAxisIndex(axis2DData.componentElementIdentifiers[1]);
					if (axisIndex < 0 || axisIndex >= _axisCount || axisIndex2 < 0 || axisIndex2 >= _axisCount)
					{
						axes2D[num] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + num, null, null, 0, 0, num, null);
					}
					else
					{
						axes2D[num] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + num, axes[axisIndex], axes[axisIndex2], axisIndex, axisIndex2, num, _calibrationMap);
					}
				}
				catch
				{
					Logger.LogError("Error creating Axis2D from hardware map! An exception was thrown.");
					axes2D[num] = new Axis2D(this, -1, "Axis 2D " + num, null, null, 0, 0, 0, null);
				}
				finally
				{
					QgistLJPkUBZJFNHMQHUkrpJtswfA(axes2D[num]);
				}
			}
			axes2D_readOnly = new ReadOnlyCollection<Axis2D>(axes2D);
			IzkvpPfdIIQMuQwHdBuiEcjXzTSc();
			xZRHDylztWVtSRfHwikurSxlSRvJ = P_10.GetAxisIndex;
		}

		public override Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return null;
			}
			if (asJEgTisjEcLUALQMOtkJoREArlC == null)
			{
				return null;
			}
			Element elementById = base.GetElementById(elementIdentifierId);
			if (elementById != null)
			{
				return elementById;
			}
			int axisIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0)
			{
				return null;
			}
			return axes[axisIndex];
		}

		public int GetAxisIndexById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return -1;
			}
			return asJEgTisjEcLUALQMOtkJoREArlC.GetAxisIndex(elementIdentifierId);
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0f;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0f;
			}
			return axes[index].value;
		}

		public float GetAxisPrev(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0f;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0f;
			}
			return axes[index].valuePrev;
		}

		public float GetAxisRaw(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0f;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0f;
			}
			return axes[index].valueRaw;
		}

		public float GetAxisRawPrev(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0f;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0f;
			}
			return axes[index].valueRawPrev;
		}

		public double GetAxisTimeActive(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].timeActive;
		}

		public double GetAxisTimeInactive(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].timeInactive;
		}

		public double GetAxisLastTimeActive(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].lastTimeActive;
		}

		public double GetAxisLastTimeInactive(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].lastTimeInactive;
		}

		public double GetAxisRawTimeActive(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].timeActiveRaw;
		}

		public double GetAxisRawTimeInactive(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].timeInactiveRaw;
		}

		public double GetAxisRawLastTimeActive(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].lastTimeActiveRaw;
		}

		public double GetAxisRawLastTimeInactive(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].lastTimeInactiveRaw;
		}

		public float GetAxisById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0f;
			}
			int axisIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].value;
		}

		public float GetAxisPrevById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0f;
			}
			int axisIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valuePrev;
		}

		public float GetAxisRawById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0f;
			}
			int axisIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRaw;
		}

		public float GetAxisRawPrevById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0f;
			}
			int axisIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRawPrev;
		}

		public double GetAxisTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			int axisIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActive;
		}

		public double GetAxisTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			int axisIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeInactive;
		}

		public double GetAxisLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			int axisIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActive;
		}

		public double GetAxisLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			int axisIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeInactive;
		}

		public double GetAxisRawTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			int axisIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActiveRaw;
		}

		public double GetAxisRawTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			int axisIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeInactiveRaw;
		}

		public double GetAxisRawLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			int axisIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActiveRaw;
		}

		public double GetAxisRawLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			int axisIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeInactiveRaw;
		}

		public Vector2 GetAxis2D(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return Vector2.zero;
			}
			if (index < 0 || index >= _axis2DCount)
			{
				return default(Vector2);
			}
			return axes2D[index].value;
		}

		public Vector2 GetAxis2DPrev(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return Vector2.zero;
			}
			if (index < 0 || index >= _axis2DCount)
			{
				return default(Vector2);
			}
			return axes2D[index].valuePrev;
		}

		public Vector2 GetAxis2DRaw(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return Vector2.zero;
			}
			if (index < 0 || index >= _axis2DCount)
			{
				return default(Vector2);
			}
			return axes2D[index].valueRaw;
		}

		public Vector2 GetAxis2DRawPrev(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return Vector2.zero;
			}
			if (index < 0 || index >= _axis2DCount)
			{
				return default(Vector2);
			}
			return axes2D[index].valueRawPrev;
		}

		public override double GetLastTimeActive()
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public override double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			return MathTools.Max(base.GetLastTimeActive(useRawValues), GetLastTimeAnyAxisActive(useRawValues));
		}

		public override double GetLastTimeAnyElementChanged()
		{
			return GetLastTimeAnyElementChanged(useRawValues: false);
		}

		public override double GetLastTimeAnyElementChanged(bool useRawValues)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			return MathTools.Max(base.GetLastTimeAnyElementChanged(useRawValues), GetLastTimeAnyAxisChanged(useRawValues));
		}

		public double GetLastTimeAnyAxisActive()
		{
			return GetLastTimeAnyAxisActive(useRawValues: false);
		}

		public double GetLastTimeAnyAxisActive(bool useRawValues)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			if (axes == null)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < axes.Length; i++)
			{
				double num2 = (useRawValues ? axes[i].lastTimeActiveRaw : axes[i].lastTimeActive);
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}

		public double GetLastTimeAnyAxisChanged()
		{
			return GetLastTimeAnyAxisChanged(useRawValues: false);
		}

		public double GetLastTimeAnyAxisChanged(bool useRawValues)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return 0.0;
			}
			if (axes == null)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < axes.Length; i++)
			{
				double num2 = (useRawValues ? axes[i].lastTimeValueChangedRaw : axes[i].lastTimeValueChanged);
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}

		public override ControllerPollingInfo PollForFirstElement()
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
			}
			ControllerPollingInfo result = base.PollForFirstElement();
			if (result.success)
			{
				return result;
			}
			return PollForFirstAxis();
		}

		public override ControllerPollingInfo PollForFirstElementDown()
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
			}
			ControllerPollingInfo result = base.PollForFirstElementDown();
			if (result.success)
			{
				return result;
			}
			return PollForFirstAxis();
		}

		public ControllerPollingInfo PollForFirstAxis()
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
			}
			UpdatePollingFrameTracking();
			lpeZuTsDMBpzcMllEItVPghBbngdA();
			for (int i = 0; i < _axisCount; i++)
			{
				if (IsPolledAxisActive(i, out var pole, out var elementIdentifierId))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Axis, i, pole, asJEgTisjEcLUALQMOtkJoREArlC.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyboardKeyCode.None);
				}
			}
			return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
		}

		[IteratorStateMachine(typeof(gmVBokitTJFerkEgAsTOSPGUwoRQ))]
		public override IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			return new gmVBokitTJFerkEgAsTOSPGUwoRQ(-2)
			{
				UQJNnNzyrsJlRpHbBCQVUgVnexHf = this
			};
		}

		[IteratorStateMachine(typeof(uwxGjgwnRYmWQsigyRKgZlBzVwBu))]
		public override IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			return new uwxGjgwnRYmWQsigyRKgZlBzVwBu(-2)
			{
				giKANQmlfCdXJpQJtiwHrcJsFPXd = this
			};
		}

		[IteratorStateMachine(typeof(OqjsoiJPrqDjTJBIqLBdmIHcwoPGA))]
		public IEnumerable<ControllerPollingInfo> PollForAllAxes()
		{
			return new OqjsoiJPrqDjTJBIqLBdmIHcwoPGA(-2)
			{
				mXMJqLsrsUnHfeCfqbaFbOIBqRPx = this
			};
		}

		private void lpeZuTsDMBpzcMllEItVPghBbngdA()
		{
			if (idJbKSyGpZypBlRbzOLWnYzGqXvs == null)
			{
				idJbKSyGpZypBlRbzOLWnYzGqXvs = new float[_axisCount];
			}
			if (wmyEcDvlYTFxLcUQeWvNSsYNfIPj != lgniLUHbjUfRLdhPStzFSaoZbXyG)
			{
				lgniLUHbjUfRLdhPStzFSaoZbXyG = wmyEcDvlYTFxLcUQeWvNSsYNfIPj;
				UpdateLoopType currentUpdateLoop = ReInput.currentUpdateLoop;
				for (int i = 0; i < _axisCount; i++)
				{
					idJbKSyGpZypBlRbzOLWnYzGqXvs[i] = axes[i].ceUsqmJJOrovtSaINrqXOOvWsTWO(currentUpdateLoop, _calibrationMap.GetAxis(i));
				}
			}
		}

		protected virtual bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (axes[index].excludeFromPolling)
			{
				return false;
			}
			float value;
			switch (axes[index].axisCoordinateMode)
			{
			case AxisCoordinateMode.Absolute:
				value = axes[index].ceUsqmJJOrovtSaINrqXOOvWsTWO(ReInput.currentUpdateLoop, _calibrationMap.GetAxis(index)) - idJbKSyGpZypBlRbzOLWnYzGqXvs[index];
				break;
			case AxisCoordinateMode.Relative:
				if (TNeIUaQSJxQIIWknfctPilNEkhdE == null)
				{
					TNeIUaQSJxQIIWknfctPilNEkhdE = new float[_axisCount];
				}
				if (dBixiuaKxKsOQwswWqDEAdxDIdDM == null)
				{
					dBixiuaKxKsOQwswWqDEAdxDIdDM = new TimerAbs(1.0);
				}
				if (dBixiuaKxKsOQwswWqDEAdxDIdDM.Update() || !dBixiuaKxKsOQwswWqDEAdxDIdDM.running)
				{
					dBixiuaKxKsOQwswWqDEAdxDIdDM.Start();
					Array.Clear(TNeIUaQSJxQIIWknfctPilNEkhdE, 0, TNeIUaQSJxQIIWknfctPilNEkhdE.Length);
				}
				TNeIUaQSJxQIIWknfctPilNEkhdE[index] += axes[index].valueRaw;
				value = TNeIUaQSJxQIIWknfctPilNEkhdE[index];
				break;
			default:
				throw new NotImplementedException();
			}
			if (MathTools.Abs(value) <= axes[index].zAQaZHyHWtIpzmySIDEsIphBotfe)
			{
				return false;
			}
			pole = ((!(MathTools.Sign(value) >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = asJEgTisjEcLUALQMOtkJoREArlC.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			return true;
		}

		public bool ImportCalibrationMapFromXmlString(string xmlString)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			return calibrationMap.ImportXmlString(xmlString);
		}

		public bool ImportCalibrationMapFromJsonString(string jsonString)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return false;
			}
			return calibrationMap.ImportJsonString(jsonString);
		}

		internal virtual void vyCpASKgznrSGjlXeDnKTYNUWDwT(UpdateLoopType P_0)
		{
			base.fGrfHqFKGdZHGoihFnGZOueFayKBb(P_0);
			bool flag = ReInput.IsInputAllowed(_type);
			bool flag2 = _type == ControllerType.Joystick || _type == ControllerType.Custom;
			bool flag3 = _type == ControllerType.Joystick && ReInput.checkNeverPressed;
			bool flag4 = _type == ControllerType.Joystick && !ONcPOmEPPyOeIZfvFoSEEYgzfzdq.hasReceivedInput;
			for (int i = 0; i < _axisCount; i++)
			{
				axes[i].NyVWQPUHaAuuRbPyueCITNrYwQMF(P_0);
				if (!flag || flag4 || (flag3 && !ONcPOmEPPyOeIZfvFoSEEYgzfzdq.axisHasBeenPressedOSXLinux[i]))
				{
					axes[i].valueRaw = _calibrationMap.GetAxis(i).calibratedZero;
					axes[i].wWlBDqxgNscdugUMonRQYErsRuJf();
					continue;
				}
				axes[i].valueRaw = ONcPOmEPPyOeIZfvFoSEEYgzfzdq.axisValues[i];
				if (flag2)
				{
					axes[i].rTFjSZVDHbNtSWEEBDvmVKKUfcDV(_calibrationMap.GetAxis(i));
				}
				else
				{
					axes[i].sprhmFXvaEpsQneCiMUrnITiCNkfA();
				}
			}
			for (int j = 0; j < _axis2DCount; j++)
			{
				axes2D[j].PmvFtRfUsCAPQopdePVDYwnwTaeH();
			}
			for (int k = 0; k < _axisCount; k++)
			{
				axes[k].LZbFcegdfzdLiDjISqACDquEWAiA();
			}
		}

		internal bool PhoMBvolLEbZJWAGyfxxZzSHscGn(ActionElementMap P_0, int P_1, bool P_2, bool P_3, out float P_4)
		{
			P_4 = 0f;
			ControllerElementType elementType = P_0._elementType;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int qCgFyaezumPcbmlbbJQsmzAMuLVpA = P_0.QCgFyaezumPcbmlbbJQsmzAMuLVpA;
			if (qCgFyaezumPcbmlbbJQsmzAMuLVpA < 0 || qCgFyaezumPcbmlbbJQsmzAMuLVpA >= _axisCount)
			{
				return false;
			}
			float num = ((!P_3) ? (P_2 ? axes[qCgFyaezumPcbmlbbJQsmzAMuLVpA].valueRaw : axes[qCgFyaezumPcbmlbbJQsmzAMuLVpA].value) : (P_2 ? axes[qCgFyaezumPcbmlbbJQsmzAMuLVpA].valueRawPrev : axes[qCgFyaezumPcbmlbbJQsmzAMuLVpA].valuePrev));
			if (MathTools.Approximately(num, 0f))
			{
				return true;
			}
			switch (elementType)
			{
			case ControllerElementType.Axis:
			{
				if (P_0._axisRange == AxisRange.Full)
				{
					if (P_0._invert)
					{
						num *= -1f;
					}
					break;
				}
				bool flag = MathTools.Sign(num) > 0f;
				if (flag && P_0._axisRange == AxisRange.Positive)
				{
					num = ((num >= 0f) ? num : 0f);
					if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
				else if (!flag && P_0._axisRange == AxisRange.Negative)
				{
					num = ((num <= 0f) ? num : 0f);
					if (P_0._axisContribution == Pole.Positive)
					{
						num *= -1f;
					}
				}
				else
				{
					num = 0f;
				}
				break;
			}
			case ControllerElementType.Button:
				if (P_0._axisContribution == Pole.Negative)
				{
					num *= -1f;
				}
				break;
			}
			P_4 = num;
			return true;
		}

		internal virtual void KFjfFhgUxKBlzmthrmQGlseCKzCAA(ControllerMap P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			if (!(P_0 is ControllerMapWithAxes controllerMapWithAxes))
			{
				Logger.LogWarning("Map type must inherit from ControllerMapWithAxes!");
				return;
			}
			try
			{
				ControllerMap.lRmYCoCSmOckdAxZaAzbXHOzxRbC();
				Controller.XzLbAEtxLCUfuNtSsrNvhyZGTluw(P_0, asJEgTisjEcLUALQMOtkJoREArlC);
				base.fsGAmSubJncncJCvyCKmjBAMAvWb(P_0);
				IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
				for (int i = 0; i < axisMaps.Count; i++)
				{
					duSGjNZdSxSjezvmjyDBFGtlyxPL(P_0, axisMaps[i]);
				}
				for (int num = axisMaps.Count - 1; num >= 0; num--)
				{
					if (axisMaps[num].elementIndex < 0)
					{
						P_0.DeleteElementMap(axisMaps[num].ZwmcQAFJNCcNOFRJeAGabSeBNAxXc);
					}
				}
			}
			finally
			{
				ControllerMap.GHMgTTbTNZrCoRvrTvpOrmMMxTwr();
			}
		}

		internal virtual void uGNMIMopNqmBBISqFkAqGDRDEYwGA(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				base.duSGjNZdSxSjezvmjyDBFGtlyxPL(P_0, P_1);
				if (P_1._elementType == ControllerElementType.Axis)
				{
					P_1.ycFFstKtkKsMsNxRhfBwJdLUnnwbA(P_0);
				}
			}
		}

		internal void IzkvpPfdIIQMuQwHdBuiEcjXzTSc()
		{
			for (int i = 0; i < axisCount; i++)
			{
				switch (axes[i].VjHSioMESUvcoZNTLZGzLmnuVlxf._specialAxisType)
				{
				case SpecialAxisType.None:
					_calibrationMap.Axes[i].calibrationMode = AlternateAxisCalibrationType.Default;
					break;
				case SpecialAxisType.Throttle:
					_calibrationMap.Axes[i].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(ReInput.configVars.throttleCalibrationMode);
					break;
				default:
					throw new NotImplementedException();
				}
			}
		}

		internal virtual void XIMdugOqsgGQtgPqQYXcFguOELdDb()
		{
			base.DupAFRZPigDCXHzKZjcpbnZzkuAX();
			if (dBixiuaKxKsOQwswWqDEAdxDIdDM != null)
			{
				dBixiuaKxKsOQwswWqDEAdxDIdDM.Clear();
			}
			for (int i = 0; i < _axisCount; i++)
			{
				if (axes[i] != null)
				{
					axes[i].Reset();
				}
			}
		}

		[CompilerGenerated]
		private int CsjuUgUnMJOgqpRAChMjcvOxEvkI(int P_0)
		{
			return GetExtension<IAxisCalibrationIndexMap>()?.GetMappedAxisIndex(P_0) ?? P_0;
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ControllerPollingInfo> bVwlKaQhCQkRcyrAUnyOUqaHcItH()
		{
			return base.PollForAllElements();
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ControllerPollingInfo> YsWWjGuGmVPsrWpVrMKXdGvxTUEe()
		{
			return base.PollForAllElementsDown();
		}
	}
}
