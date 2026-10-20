using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerTemplate : IControllerTemplate, IControllerTemplate_Internal, BMeYXymsuXMDMyjfaaClzmryYLZG
	{
		internal abstract class tkKGeIGfCGinmnoNBPOdYHhFkyoDA : IControllerTemplateElement, IControllerTemplateElement_Internal
		{
			private readonly IControllerTemplate QZdfxgLfFRddMXinkPeTpHRtRqMN;

			private readonly int FEGuoAtRZdChRXLiOFaBdPVlmBzfA;

			private readonly ControllerTemplateElementType HZhygezkTphzSYvkzknxsWyRpbWO;

			protected readonly int WnfZzuOhNJACIKODilWvbmtmuHvB;

			protected readonly zFxewYcdsnklzPlkSKWylcOJCubnA DkxZcpfUfaThNuePukJGlAcSNkWP;

			int IControllerTemplateElement.id
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return -1;
					}
					return FEGuoAtRZdChRXLiOFaBdPVlmBzfA;
				}
			}

			string IControllerTemplateElement.descriptiveName
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return DkxZcpfUfaThNuePukJGlAcSNkWP.HkkGPLVCcmuqWtKjDEfmdgyBbpxO;
				}
			}

			internal string VQPfrBhGrJkQBEPJcBIsgvqyNNGTA => DkxZcpfUfaThNuePukJGlAcSNkWP.nonLocalizedDescriptiveName;

			ControllerTemplateElementType IControllerTemplateElement.type
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return ControllerTemplateElementType.Axis;
					}
					return HZhygezkTphzSYvkzknxsWyRpbWO;
				}
			}

			IControllerTemplate IControllerTemplateElement_Internal.parent => QZdfxgLfFRddMXinkPeTpHRtRqMN;

			public abstract int elementCount { get; }

			public abstract IControllerTemplateElementSource source { get; }

			public abstract bool exists { get; }

			protected tkKGeIGfCGinmnoNBPOdYHhFkyoDA(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, zFxewYcdsnklzPlkSKWylcOJCubnA P_3)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (P_3 == null)
				{
					throw new ArgumentNullException("localizedElement");
				}
				QZdfxgLfFRddMXinkPeTpHRtRqMN = P_0;
				FEGuoAtRZdChRXLiOFaBdPVlmBzfA = P_1;
				HZhygezkTphzSYvkzknxsWyRpbWO = P_2;
				WnfZzuOhNJACIKODilWvbmtmuHvB = ReInput.id;
				DkxZcpfUfaThNuePukJGlAcSNkWP = P_3;
			}

			public abstract IControllerTemplateElement GetElement(int index);

			public abstract int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list);

			protected static zFxewYcdsnklzPlkSKWylcOJCubnA LLxQkwkbjhrajnasWaKwEPUmNkzuA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3)
			{
				return JmONvkcactDGGnRvPaoPCJLywnri.fkwGGVMWJGKkxnmUmrMLnoeBdTKm(new zFxewYcdsnklzPlkSKWylcOJCubnA(NqaAtWhVcBTdRnkbTxNjbPXVJAxdb.YxvGTedEpZWQCplWqJpWiphVxLqsA(QYJjXxsVdyEaAjTsqvDHkTMqFyjf.ControllerTemplate, rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh.Unknown, rwVLDpDqxWJPlwdrjLQNpZOFNoCM.jgYXfxdxpkTgDbqAHkfiZaHWlWIS.None, P_1, P_0.deviceLocalizationInfo), "controller/template", string.Empty, P_2, P_3));
			}
		}

		internal abstract class jcJRDPdazpqDuTrDWlidbVWieGbX : tkKGeIGfCGinmnoNBPOdYHhFkyoDA
		{
			protected readonly int SXHKBUcpBlFzHODnidpOJnevGBlcA;

			protected readonly AFAiEcEMrQadeSEkjLdZgrdTYyjQA[] fGpLNCKGzahscfzaXUeYeEgOkUap;

			bool tkKGeIGfCGinmnoNBPOdYHhFkyoDA.exists
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return false;
					}
					if (fGpLNCKGzahscfzaXUeYeEgOkUap == null)
					{
						return false;
					}
					for (int i = 0; i < fGpLNCKGzahscfzaXUeYeEgOkUap.Length; i++)
					{
						if (fGpLNCKGzahscfzaXUeYeEgOkUap[i].LGDHClejRrKRqsmbziwXaflmNIyO != null)
						{
							return true;
						}
					}
					return false;
				}
			}

			protected jcJRDPdazpqDuTrDWlidbVWieGbX(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, IList<AFAiEcEMrQadeSEkjLdZgrdTYyjQA> P_3, zFxewYcdsnklzPlkSKWylcOJCubnA P_4)
				: base(P_0, P_1, P_2, P_4)
			{
				fGpLNCKGzahscfzaXUeYeEgOkUap = ((P_3 != null) ? ListTools.ToArray(P_3) : null);
				SXHKBUcpBlFzHODnidpOJnevGBlcA = ((fGpLNCKGzahscfzaXUeYeEgOkUap != null) ? fGpLNCKGzahscfzaXUeYeEgOkUap.Length : 0);
			}
		}

		internal abstract class lSPxnJedJzfeqgIWxVWepxRjinRcA : jcJRDPdazpqDuTrDWlidbVWieGbX, IControllerTemplateAxis, IControllerTemplateElement, IControllerTemplateButton
		{
			private ZjsvgUMHkMFRcjnXfMJoZEAVgouqA ddVGFuMQbxDwBgGvxQpcLmcrkuPL;

			public float jXCVuvpgUTxlGlTHfAAzdVwInwVk
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return 0f;
					}
					if (SXHKBUcpBlFzHODnidpOJnevGBlcA == 1)
					{
						return fGpLNCKGzahscfzaXUeYeEgOkUap[0].YrNsSVAqhhWoRXVNjqBMftNAjTCW;
					}
					if (SXHKBUcpBlFzHODnidpOJnevGBlcA == 2)
					{
						float num = fGpLNCKGzahscfzaXUeYeEgOkUap[0].YrNsSVAqhhWoRXVNjqBMftNAjTCW;
						float num2 = fGpLNCKGzahscfzaXUeYeEgOkUap[1].YrNsSVAqhhWoRXVNjqBMftNAjTCW;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public float pxCOZgtALVnhLToZRYeYIPPjDywcA
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return 0f;
					}
					if (SXHKBUcpBlFzHODnidpOJnevGBlcA == 1)
					{
						return fGpLNCKGzahscfzaXUeYeEgOkUap[0].kTDpessCbLBxbasWkHpRhMoTPvah;
					}
					if (SXHKBUcpBlFzHODnidpOJnevGBlcA == 2)
					{
						float num = fGpLNCKGzahscfzaXUeYeEgOkUap[0].kTDpessCbLBxbasWkHpRhMoTPvah;
						float num2 = fGpLNCKGzahscfzaXUeYeEgOkUap[1].kTDpessCbLBxbasWkHpRhMoTPvah;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public bool LlFYIXmpoMRWusSNbHmlvqfvtFqc
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return false;
					}
					if (SXHKBUcpBlFzHODnidpOJnevGBlcA == 1)
					{
						return fGpLNCKGzahscfzaXUeYeEgOkUap[0].YltnJMPgOkrQJNuTpskidbQIhPeI;
					}
					if (SXHKBUcpBlFzHODnidpOJnevGBlcA == 2)
					{
						if (!fGpLNCKGzahscfzaXUeYeEgOkUap[0].YltnJMPgOkrQJNuTpskidbQIhPeI)
						{
							return fGpLNCKGzahscfzaXUeYeEgOkUap[1].YltnJMPgOkrQJNuTpskidbQIhPeI;
						}
						return true;
					}
					return false;
				}
			}

			public bool gFaIkGArVLoMWsxCwzUaUvvcydjo
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return false;
					}
					if (SXHKBUcpBlFzHODnidpOJnevGBlcA == 1)
					{
						return fGpLNCKGzahscfzaXUeYeEgOkUap[0].SHOFoPpnICXGtgFlVEaQKfTmZoqvA;
					}
					if (SXHKBUcpBlFzHODnidpOJnevGBlcA == 2)
					{
						if (!fGpLNCKGzahscfzaXUeYeEgOkUap[0].SHOFoPpnICXGtgFlVEaQKfTmZoqvA)
						{
							return fGpLNCKGzahscfzaXUeYeEgOkUap[1].SHOFoPpnICXGtgFlVEaQKfTmZoqvA;
						}
						return true;
					}
					return false;
				}
			}

			string IControllerTemplateAxis.positiveDescriptiveName
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return HYEUwLVhmNHUUvPMpKdOVWochURb.vRlGKZyDHtikKWKioFCnuyfERenC;
				}
			}

			string IControllerTemplateAxis.negativeDescriptiveName
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return HYEUwLVhmNHUUvPMpKdOVWochURb.FcHrehovuonqIUbPVbJXsccLuMhM;
				}
			}

			float IControllerTemplateAxis.value
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return 0f;
					}
					return jXCVuvpgUTxlGlTHfAAzdVwInwVk;
				}
			}

			float IControllerTemplateAxis.valuePrev
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return 0f;
					}
					return pxCOZgtALVnhLToZRYeYIPPjDywcA;
				}
			}

			IControllerTemplateAxisSource IControllerTemplateAxis.source
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return ddVGFuMQbxDwBgGvxQpcLmcrkuPL;
				}
			}

			bool IControllerTemplateButton.value
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return false;
					}
					return LlFYIXmpoMRWusSNbHmlvqfvtFqc;
				}
			}

			bool IControllerTemplateButton.valuePrev
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return false;
					}
					return gFaIkGArVLoMWsxCwzUaUvvcydjo;
				}
			}

			bool IControllerTemplateButton.justPressed
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return false;
					}
					if (SXHKBUcpBlFzHODnidpOJnevGBlcA == 1)
					{
						return fGpLNCKGzahscfzaXUeYeEgOkUap[0].dcnZqMdjjJTXKsbryGebIQHNCLwm;
					}
					if (SXHKBUcpBlFzHODnidpOJnevGBlcA == 2)
					{
						if (!fGpLNCKGzahscfzaXUeYeEgOkUap[0].dcnZqMdjjJTXKsbryGebIQHNCLwm || fGpLNCKGzahscfzaXUeYeEgOkUap[1].SHOFoPpnICXGtgFlVEaQKfTmZoqvA)
						{
							if (fGpLNCKGzahscfzaXUeYeEgOkUap[1].dcnZqMdjjJTXKsbryGebIQHNCLwm)
							{
								return !fGpLNCKGzahscfzaXUeYeEgOkUap[0].SHOFoPpnICXGtgFlVEaQKfTmZoqvA;
							}
							return false;
						}
						return true;
					}
					return false;
				}
			}

			bool IControllerTemplateButton.justReleased
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return false;
					}
					if (SXHKBUcpBlFzHODnidpOJnevGBlcA == 1)
					{
						return fGpLNCKGzahscfzaXUeYeEgOkUap[0].SNcDHINeUgaGEeuHnjRCzfSFWDZfA;
					}
					if (SXHKBUcpBlFzHODnidpOJnevGBlcA == 2)
					{
						if (!fGpLNCKGzahscfzaXUeYeEgOkUap[0].SNcDHINeUgaGEeuHnjRCzfSFWDZfA || fGpLNCKGzahscfzaXUeYeEgOkUap[1].YltnJMPgOkrQJNuTpskidbQIhPeI)
						{
							if (fGpLNCKGzahscfzaXUeYeEgOkUap[1].SNcDHINeUgaGEeuHnjRCzfSFWDZfA)
							{
								return !fGpLNCKGzahscfzaXUeYeEgOkUap[0].YltnJMPgOkrQJNuTpskidbQIhPeI;
							}
							return false;
						}
						return true;
					}
					return false;
				}
			}

			bool IControllerTemplateButton.justChangedState
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return false;
					}
					return LlFYIXmpoMRWusSNbHmlvqfvtFqc != gFaIkGArVLoMWsxCwzUaUvvcydjo;
				}
			}

			float IControllerTemplateButton.pressure
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return 0f;
					}
					return jXCVuvpgUTxlGlTHfAAzdVwInwVk;
				}
			}

			float IControllerTemplateButton.pressurePrev
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return 0f;
					}
					return pxCOZgtALVnhLToZRYeYIPPjDywcA;
				}
			}

			IControllerTemplateButtonSource IControllerTemplateButton.source
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return ddVGFuMQbxDwBgGvxQpcLmcrkuPL;
				}
			}

			IControllerTemplateElementSource tkKGeIGfCGinmnoNBPOdYHhFkyoDA.source
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return ddVGFuMQbxDwBgGvxQpcLmcrkuPL;
				}
			}

			int tkKGeIGfCGinmnoNBPOdYHhFkyoDA.elementCount => 0;

			IControllerTemplateAxis IControllerTemplateButton.AsAxis
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return this;
				}
			}

			IControllerTemplateButton IControllerTemplateAxis.AsButton
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return this;
				}
			}

			protected jTLujqPXjYiPiTOGRXdNNhzrgCQs HYEUwLVhmNHUUvPMpKdOVWochURb => (jTLujqPXjYiPiTOGRXdNNhzrgCQs)DkxZcpfUfaThNuePukJGlAcSNkWP;

			protected lSPxnJedJzfeqgIWxVWepxRjinRcA(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, ZjsvgUMHkMFRcjnXfMJoZEAVgouqA P_3, IList<AFAiEcEMrQadeSEkjLdZgrdTYyjQA> P_4, jTLujqPXjYiPiTOGRXdNNhzrgCQs P_5)
				: base(P_0, P_1, P_2, P_4, P_5)
			{
				if (P_4 != null && P_4.Count > 2)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
				}
				if (P_3 == null)
				{
					throw new ArgumentNullException("target");
				}
				ddVGFuMQbxDwBgGvxQpcLmcrkuPL = P_3;
			}

			string IControllerTemplateAxis.GetDescriptiveName(AxisRange axisRange)
			{
				if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
				{
					ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
					return null;
				}
				return axisRange switch
				{
					AxisRange.Full => base.Rewired_002EIControllerTemplateElement_002EdescriptiveName, 
					AxisRange.Positive => ((IControllerTemplateAxis)this).positiveDescriptiveName, 
					AxisRange.Negative => ((IControllerTemplateAxis)this).negativeDescriptiveName, 
					_ => throw new NotImplementedException(), 
				};
			}

			public override IControllerTemplateElement GetElement(int index)
			{
				return null;
			}

			public override int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list)
			{
				if (find.elementIdentifierId < 0)
				{
					return 0;
				}
				int num = 0;
				switch (base.Rewired_002EIControllerTemplateElement_002Etype)
				{
				case ControllerTemplateElementType.Axis:
				{
					IControllerTemplateAxisSource controllerTemplateAxisSource = ddVGFuMQbxDwBgGvxQpcLmcrkuPL;
					if (controllerTemplateAxisSource.splitAxis)
					{
						if (qWGRmlhbqXZCXmHThICyoCFpGZEn(find, controllerTemplateAxisSource.positiveTarget))
						{
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Positive));
							num++;
						}
						if (qWGRmlhbqXZCXmHThICyoCFpGZEn(find, controllerTemplateAxisSource.negativeTarget))
						{
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Negative));
							num++;
						}
					}
					else if (qWGRmlhbqXZCXmHThICyoCFpGZEn(find, controllerTemplateAxisSource.fullTarget))
					{
						ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, find.axisRange));
						num++;
					}
					break;
				}
				case ControllerTemplateElementType.Button:
					if (qWGRmlhbqXZCXmHThICyoCFpGZEn(find, ((IControllerTemplateButtonSource)ddVGFuMQbxDwBgGvxQpcLmcrkuPL).target))
					{
						ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Full));
						num++;
					}
					break;
				default:
					throw new NotImplementedException();
				}
				return num;
			}

			private static bool qWGRmlhbqXZCXmHThICyoCFpGZEn(ControllerElementTarget P_0, IControllerElementTarget P_1)
			{
				if (P_1.elementIdentifierId != P_0.elementIdentifierId)
				{
					return false;
				}
				switch (P_1.elementType)
				{
				case ControllerElementType.Axis:
				{
					AxisRange axisRange = P_1.axisRange;
					if (axisRange == AxisRange.Full)
					{
						return true;
					}
					if (axisRange == P_0.axisRange)
					{
						return true;
					}
					return false;
				}
				case ControllerElementType.Button:
					return true;
				default:
					throw new NotImplementedException();
				}
			}
		}

		internal sealed class OnDxEcZLyLuAeoIOMGNbMNpapNEU : lSPxnJedJzfeqgIWxVWepxRjinRcA
		{
			public OnDxEcZLyLuAeoIOMGNbMNpapNEU(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, string P_4, string P_5, string P_6, string P_7, ZjsvgUMHkMFRcjnXfMJoZEAVgouqA P_8, IList<AFAiEcEMrQadeSEkjLdZgrdTYyjQA> P_9)
				: base(P_0, P_1, ControllerTemplateElementType.Axis, P_8, P_9, (jTLujqPXjYiPiTOGRXdNNhzrgCQs)JmONvkcactDGGnRvPaoPCJLywnri.fkwGGVMWJGKkxnmUmrMLnoeBdTKm(new jTLujqPXjYiPiTOGRXdNNhzrgCQs(HMtLwHHjltZtNIbnthVxPUFsBHUt.efcQTUUIFHdVLOupjuksxpHMSjY(QYJjXxsVdyEaAjTsqvDHkTMqFyjf.ControllerTemplate, rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh.Axis, rwVLDpDqxWJPlwdrjLQNpZOFNoCM.jgYXfxdxpkTgDbqAHkfiZaHWlWIS.None, P_1, P_0.deviceLocalizationInfo), "controller/template", string.Empty, P_2, P_3, P_4, P_5, P_6, P_7)))
			{
				if (P_9 != null && P_9.Count > 2)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
				}
			}

			internal static OnDxEcZLyLuAeoIOMGNbMNpapNEU VKcMAptVqnbtYOfwOZGdBJKzFkZF(IControllerTemplate_Internal P_0)
			{
				return new OnDxEcZLyLuAeoIOMGNbMNpapNEU(P_0, -1, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, ZjsvgUMHkMFRcjnXfMJoZEAVgouqA.UgJqQFedtMXhSrKVrFdnnDIAlKxe(ControllerTemplateElementType.Axis), null);
			}
		}

		internal sealed class dHnyrrYRTDRQvvQOBXaRpadbunPl : lSPxnJedJzfeqgIWxVWepxRjinRcA
		{
			public dHnyrrYRTDRQvvQOBXaRpadbunPl(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, string P_4, string P_5, string P_6, string P_7, ZjsvgUMHkMFRcjnXfMJoZEAVgouqA P_8, IList<AFAiEcEMrQadeSEkjLdZgrdTYyjQA> P_9)
				: base(P_0, P_1, ControllerTemplateElementType.Button, P_8, P_9, (jTLujqPXjYiPiTOGRXdNNhzrgCQs)JmONvkcactDGGnRvPaoPCJLywnri.fkwGGVMWJGKkxnmUmrMLnoeBdTKm(new jTLujqPXjYiPiTOGRXdNNhzrgCQs(HMtLwHHjltZtNIbnthVxPUFsBHUt.efcQTUUIFHdVLOupjuksxpHMSjY(QYJjXxsVdyEaAjTsqvDHkTMqFyjf.ControllerTemplate, rwVLDpDqxWJPlwdrjLQNpZOFNoCM.KMtjipaOdFdYovyjrhBVREbSUYnh.Button, rwVLDpDqxWJPlwdrjLQNpZOFNoCM.jgYXfxdxpkTgDbqAHkfiZaHWlWIS.None, P_1, P_0.deviceLocalizationInfo), "controller/template", string.Empty, P_2, P_3, P_4, P_5, P_6, P_7)))
			{
				if (P_9 != null && P_9.Count > 1)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 1.");
				}
			}

			internal static dHnyrrYRTDRQvvQOBXaRpadbunPl sVEeWXGJySMDfDIwDGHORuUTQImrA(IControllerTemplate_Internal P_0)
			{
				return new dHnyrrYRTDRQvvQOBXaRpadbunPl(P_0, -1, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, ZjsvgUMHkMFRcjnXfMJoZEAVgouqA.UgJqQFedtMXhSrKVrFdnnDIAlKxe(ControllerTemplateElementType.Button), null);
			}
		}

		internal abstract class HFdwUseEUeEcibzQTEsUPRxtkoRzA : tkKGeIGfCGinmnoNBPOdYHhFkyoDA
		{
			protected readonly int eNDCuoALQdHkPejZeQPxbJwPhJBMA;

			protected readonly tkKGeIGfCGinmnoNBPOdYHhFkyoDA[] ykWiIUdMtRyEJxDJAGHlanXNAImtA;

			bool tkKGeIGfCGinmnoNBPOdYHhFkyoDA.exists
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return false;
					}
					for (int i = 0; i < eNDCuoALQdHkPejZeQPxbJwPhJBMA; i++)
					{
						if (ykWiIUdMtRyEJxDJAGHlanXNAImtA[i].exists)
						{
							return true;
						}
					}
					return false;
				}
			}

			IControllerTemplateElementSource tkKGeIGfCGinmnoNBPOdYHhFkyoDA.source
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return null;
				}
			}

			int tkKGeIGfCGinmnoNBPOdYHhFkyoDA.elementCount => eNDCuoALQdHkPejZeQPxbJwPhJBMA;

			protected HFdwUseEUeEcibzQTEsUPRxtkoRzA(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, tkKGeIGfCGinmnoNBPOdYHhFkyoDA[] P_3, zFxewYcdsnklzPlkSKWylcOJCubnA P_4)
				: base(P_0, P_1, P_2, P_4)
			{
				if (P_3 == null)
				{
					throw new ArgumentNullException("elements");
				}
				if (P_3.Length == 0)
				{
					throw new ArgumentException("elements.Length is zero.");
				}
				for (int i = 0; i < P_3.Length; i++)
				{
					if (P_3[i] == null)
					{
						throw new ArgumentNullException("elements contains a null entry.");
					}
				}
				ykWiIUdMtRyEJxDJAGHlanXNAImtA = P_3;
				eNDCuoALQdHkPejZeQPxbJwPhJBMA = P_3.Length;
			}

			public virtual IControllerTemplateElement qthDedfaqrZwYefjerFUuQWxgrvu(int P_0)
			{
				return ykWiIUdMtRyEJxDJAGHlanXNAImtA[P_0];
			}

			public virtual int AkgNrdspVYfzZqDPmlszLWdUtzmN(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
			{
				int num = 0;
				for (int i = 0; i < ykWiIUdMtRyEJxDJAGHlanXNAImtA.Length; i++)
				{
					num += ykWiIUdMtRyEJxDJAGHlanXNAImtA[i].GetElementTargets(P_0, ref P_1);
				}
				return num;
			}
		}

		internal abstract class jiOyySpCaPXjRLoefYmMhTrOunbp : HFdwUseEUeEcibzQTEsUPRxtkoRzA, IControllerTemplateAxis2D, IControllerTemplateElement
		{
			protected const int jgEWtJBUQkwqvTwwXQalOwZcBNzX = 0;

			protected const int SgyNzHcxsKticBEnWlTnIcCNuHZo = 1;

			protected const int fszwMNfxfKiDWMJidnJXsNfcUbVl = 2;

			Vector2 IControllerTemplateAxis2D.value
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return Vector2.zero;
					}
					return new Vector2((eNDCuoALQdHkPejZeQPxbJwPhJBMA > 0) ? ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[0]).jXCVuvpgUTxlGlTHfAAzdVwInwVk : 0f, (eNDCuoALQdHkPejZeQPxbJwPhJBMA > 1) ? ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[1]).jXCVuvpgUTxlGlTHfAAzdVwInwVk : 0f);
				}
			}

			Vector2 IControllerTemplateAxis2D.valuePrev
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return Vector2.zero;
					}
					return new Vector2((eNDCuoALQdHkPejZeQPxbJwPhJBMA > 0) ? ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[0]).pxCOZgtALVnhLToZRYeYIPPjDywcA : 0f, (eNDCuoALQdHkPejZeQPxbJwPhJBMA > 1) ? ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[1]).pxCOZgtALVnhLToZRYeYIPPjDywcA : 0f);
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis2D.horizontal
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateAxis)ykWiIUdMtRyEJxDJAGHlanXNAImtA[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis2D.vertical
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateAxis)ykWiIUdMtRyEJxDJAGHlanXNAImtA[1];
				}
			}

			protected jiOyySpCaPXjRLoefYmMhTrOunbp(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, tkKGeIGfCGinmnoNBPOdYHhFkyoDA[] P_3, zFxewYcdsnklzPlkSKWylcOJCubnA P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal abstract class nZGtYvBJPvifcyunddizjUHDSWEj : HFdwUseEUeEcibzQTEsUPRxtkoRzA, IControllerTemplateAxis3D, IControllerTemplateElement
		{
			protected const int aTPqAiEAENqKHJJjNeyJCcwsjJjr = 0;

			protected const int GEfDPOkHPBuvfjaJrWJJDdVqEJQhb = 1;

			protected const int chiEBFNpIKnOEBpHoPTSpspzhdVj = 2;

			protected const int nBbGOTlPbEhwQCkHPjlfkChrLycTA = 3;

			Vector3 IControllerTemplateAxis3D.value
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return Vector3.zero;
					}
					return new Vector3((eNDCuoALQdHkPejZeQPxbJwPhJBMA > 0) ? ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[0]).jXCVuvpgUTxlGlTHfAAzdVwInwVk : 0f, (eNDCuoALQdHkPejZeQPxbJwPhJBMA > 1) ? ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[1]).jXCVuvpgUTxlGlTHfAAzdVwInwVk : 0f, (eNDCuoALQdHkPejZeQPxbJwPhJBMA > 2) ? ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[2]).jXCVuvpgUTxlGlTHfAAzdVwInwVk : 0f);
				}
			}

			Vector3 IControllerTemplateAxis3D.valuePrev
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return Vector3.zero;
					}
					return new Vector3((eNDCuoALQdHkPejZeQPxbJwPhJBMA > 0) ? ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[0]).pxCOZgtALVnhLToZRYeYIPPjDywcA : 0f, (eNDCuoALQdHkPejZeQPxbJwPhJBMA > 1) ? ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[1]).pxCOZgtALVnhLToZRYeYIPPjDywcA : 0f, (eNDCuoALQdHkPejZeQPxbJwPhJBMA > 2) ? ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[2]).pxCOZgtALVnhLToZRYeYIPPjDywcA : 0f);
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis3D.horizontal
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateAxis)ykWiIUdMtRyEJxDJAGHlanXNAImtA[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis3D.vertical
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateAxis)ykWiIUdMtRyEJxDJAGHlanXNAImtA[1];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis3D.depth
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateAxis)ykWiIUdMtRyEJxDJAGHlanXNAImtA[2];
				}
			}

			protected nZGtYvBJPvifcyunddizjUHDSWEj(IControllerTemplate_Internal P_0, int P_1, ControllerTemplateElementType P_2, tkKGeIGfCGinmnoNBPOdYHhFkyoDA[] P_3, zFxewYcdsnklzPlkSKWylcOJCubnA P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal abstract class FZiDmnGcCVDgcbftEUMGihQarTKQE : HFdwUseEUeEcibzQTEsUPRxtkoRzA, IControllerTemplateAxis6D, IControllerTemplateElement
		{
			protected const int YcrQbNikWrjEmRHBSfnsIDnzMMLs = 0;

			protected const int ptVrstERcghJQmeNktpspVMUDecA = 1;

			protected const int PnmELHuSJgkWGeBWKdCkynxGFZxG = 2;

			protected const int qzoLjDvrTNryCGagERlwoCsJsLhd = 3;

			protected const int bEsTyuYAlOgQCfqhdpPEicmgJcIxB = 4;

			protected const int msBAZoXCexKZfzNyRKkCOLxFPWmt = 5;

			protected const int GaeCGXInPHiqmxtnLLMDMGobNwDC = 6;

			Vector3 IControllerTemplateAxis6D.position
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return Vector3.zero;
					}
					return new Vector3((eNDCuoALQdHkPejZeQPxbJwPhJBMA > 0) ? ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[0]).jXCVuvpgUTxlGlTHfAAzdVwInwVk : 0f, (eNDCuoALQdHkPejZeQPxbJwPhJBMA > 1) ? ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[1]).jXCVuvpgUTxlGlTHfAAzdVwInwVk : 0f, (eNDCuoALQdHkPejZeQPxbJwPhJBMA > 2) ? ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[2]).jXCVuvpgUTxlGlTHfAAzdVwInwVk : 0f);
				}
			}

			Vector3 IControllerTemplateAxis6D.positionPrev
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return Vector3.zero;
					}
					return new Vector3((eNDCuoALQdHkPejZeQPxbJwPhJBMA > 0) ? ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[0]).pxCOZgtALVnhLToZRYeYIPPjDywcA : 0f, (eNDCuoALQdHkPejZeQPxbJwPhJBMA > 1) ? ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[1]).pxCOZgtALVnhLToZRYeYIPPjDywcA : 0f, (eNDCuoALQdHkPejZeQPxbJwPhJBMA > 2) ? ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[2]).pxCOZgtALVnhLToZRYeYIPPjDywcA : 0f);
				}
			}

			Vector3 IControllerTemplateAxis6D.rotation
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return Vector3.zero;
					}
					return new Vector3((eNDCuoALQdHkPejZeQPxbJwPhJBMA > 3) ? ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[3]).jXCVuvpgUTxlGlTHfAAzdVwInwVk : 0f, (eNDCuoALQdHkPejZeQPxbJwPhJBMA > 4) ? ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[4]).jXCVuvpgUTxlGlTHfAAzdVwInwVk : 0f, (eNDCuoALQdHkPejZeQPxbJwPhJBMA > 5) ? ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[5]).jXCVuvpgUTxlGlTHfAAzdVwInwVk : 0f);
				}
			}

			Vector3 IControllerTemplateAxis6D.rotationPrev
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return Vector3.zero;
					}
					return new Vector3((eNDCuoALQdHkPejZeQPxbJwPhJBMA > 3) ? ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[3]).pxCOZgtALVnhLToZRYeYIPPjDywcA : 0f, (eNDCuoALQdHkPejZeQPxbJwPhJBMA > 4) ? ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[4]).pxCOZgtALVnhLToZRYeYIPPjDywcA : 0f, (eNDCuoALQdHkPejZeQPxbJwPhJBMA > 5) ? ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[5]).pxCOZgtALVnhLToZRYeYIPPjDywcA : 0f);
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.positionX
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateAxis)ykWiIUdMtRyEJxDJAGHlanXNAImtA[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.positionY
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateAxis)ykWiIUdMtRyEJxDJAGHlanXNAImtA[1];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.positionZ
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateAxis)ykWiIUdMtRyEJxDJAGHlanXNAImtA[2];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.rotationX
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateAxis)ykWiIUdMtRyEJxDJAGHlanXNAImtA[3];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.rotationY
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateAxis)ykWiIUdMtRyEJxDJAGHlanXNAImtA[4];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.rotationZ
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateAxis)ykWiIUdMtRyEJxDJAGHlanXNAImtA[5];
				}
			}

			protected FZiDmnGcCVDgcbftEUMGihQarTKQE(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, tkKGeIGfCGinmnoNBPOdYHhFkyoDA[] P_3, zFxewYcdsnklzPlkSKWylcOJCubnA P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal sealed class FgeaBzuPdrtrcOeQswxMIkpmBaNs : nZGtYvBJPvifcyunddizjUHDSWEj, IControllerTemplateStick, IControllerTemplateElement
		{
			private const int eoxceWahhOYTrQZPlfjmCscpsKCY = 3;

			IControllerTemplateAxis IControllerTemplateStick.rotation
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateAxis)ykWiIUdMtRyEJxDJAGHlanXNAImtA[2];
				}
			}

			private FgeaBzuPdrtrcOeQswxMIkpmBaNs(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, tkKGeIGfCGinmnoNBPOdYHhFkyoDA[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Stick, P_4, tkKGeIGfCGinmnoNBPOdYHhFkyoDA.LLxQkwkbjhrajnasWaKwEPUmNkzuA(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			public FgeaBzuPdrtrcOeQswxMIkpmBaNs(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, lSPxnJedJzfeqgIWxVWepxRjinRcA P_4, lSPxnJedJzfeqgIWxVWepxRjinRcA P_5, lSPxnJedJzfeqgIWxVWepxRjinRcA P_6)
				: this(P_0, P_1, P_2, P_3, new tkKGeIGfCGinmnoNBPOdYHhFkyoDA[3] { P_4, P_5, P_6 })
			{
			}
		}

		internal sealed class EXDccTEEMMbFYFltXVCDbNIDzpgLB : jiOyySpCaPXjRLoefYmMhTrOunbp, IControllerTemplateThumbStick, IControllerTemplateElement
		{
			private const int xtoddHLMIsrvtKmlYjhnAIjWzTQo = 2;

			private const int rwGFhYbxNeYFPMtqVFeMLGanIemGA = 3;

			IControllerTemplateButton IControllerTemplateThumbStick.press
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateButton)ykWiIUdMtRyEJxDJAGHlanXNAImtA[2];
				}
			}

			private EXDccTEEMMbFYFltXVCDbNIDzpgLB(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, tkKGeIGfCGinmnoNBPOdYHhFkyoDA[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.ThumbStick, P_4, tkKGeIGfCGinmnoNBPOdYHhFkyoDA.LLxQkwkbjhrajnasWaKwEPUmNkzuA(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			internal EXDccTEEMMbFYFltXVCDbNIDzpgLB(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, lSPxnJedJzfeqgIWxVWepxRjinRcA P_4, lSPxnJedJzfeqgIWxVWepxRjinRcA P_5, lSPxnJedJzfeqgIWxVWepxRjinRcA P_6)
				: this(P_0, P_1, P_2, P_3, new tkKGeIGfCGinmnoNBPOdYHhFkyoDA[3] { P_4, P_5, P_6 })
			{
			}
		}

		internal sealed class ihgxkCjSfNCEvBpYlxlUWASErXiX : HFdwUseEUeEcibzQTEsUPRxtkoRzA, IControllerTemplateDPad, IControllerTemplateElement
		{
			private const int PMxSYfgaZbBMGvsvCoUCuIbAOcMc = 0;

			private const int RmdjfqrCBwxCOJRMzdluEMbXAkLGA = 1;

			private const int pCrjmakFEwyTRAHvYEmKaRjtGpvvA = 2;

			private const int ybCNJNEIvEQJDJYLxrAuVowQzNHK = 3;

			private const int RYHvhSadudrtwHpePSROpfFCwlfy = 4;

			private const int QkHdfZvthJPLToHiRVoMhbGsCoKs = 5;

			Vector2 IControllerTemplateDPad.value
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[0]).jXCVuvpgUTxlGlTHfAAzdVwInwVk + ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[2]).jXCVuvpgUTxlGlTHfAAzdVwInwVk * -1f, -1f, 1f), MathTools.Clamp(((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[3]).jXCVuvpgUTxlGlTHfAAzdVwInwVk * -1f + ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[1]).jXCVuvpgUTxlGlTHfAAzdVwInwVk, -1f, 1f));
				}
			}

			Vector2 IControllerTemplateDPad.valuePrev
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[0]).pxCOZgtALVnhLToZRYeYIPPjDywcA + ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[2]).pxCOZgtALVnhLToZRYeYIPPjDywcA * -1f, -1f, 1f), MathTools.Clamp(((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[3]).pxCOZgtALVnhLToZRYeYIPPjDywcA * -1f + ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[1]).pxCOZgtALVnhLToZRYeYIPPjDywcA, -1f, 1f));
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.up
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateButton)ykWiIUdMtRyEJxDJAGHlanXNAImtA[0];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.right
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateButton)ykWiIUdMtRyEJxDJAGHlanXNAImtA[1];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.down
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateButton)ykWiIUdMtRyEJxDJAGHlanXNAImtA[2];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.left
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateButton)ykWiIUdMtRyEJxDJAGHlanXNAImtA[3];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.press
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateButton)ykWiIUdMtRyEJxDJAGHlanXNAImtA[4];
				}
			}

			private ihgxkCjSfNCEvBpYlxlUWASErXiX(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, tkKGeIGfCGinmnoNBPOdYHhFkyoDA[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.DPad, P_4, tkKGeIGfCGinmnoNBPOdYHhFkyoDA.LLxQkwkbjhrajnasWaKwEPUmNkzuA(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 5)
				{
					throw new ArgumentException("elements.Length must be " + 5);
				}
			}

			internal ihgxkCjSfNCEvBpYlxlUWASErXiX(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, lSPxnJedJzfeqgIWxVWepxRjinRcA P_4, lSPxnJedJzfeqgIWxVWepxRjinRcA P_5, lSPxnJedJzfeqgIWxVWepxRjinRcA P_6, lSPxnJedJzfeqgIWxVWepxRjinRcA P_7, lSPxnJedJzfeqgIWxVWepxRjinRcA P_8)
				: this(P_0, P_1, P_2, P_3, new tkKGeIGfCGinmnoNBPOdYHhFkyoDA[5] { P_4, P_5, P_6, P_7, P_8 })
			{
			}
		}

		internal sealed class fYOtxocvVXzpIDPwRJeJHiHQKuCQ : HFdwUseEUeEcibzQTEsUPRxtkoRzA, IControllerTemplateThrottle, IControllerTemplateElement
		{
			private const int TyRedpeuZLbJMyQICWAyJSlKqjkVA = 0;

			private const int JKcNlJBOvYsPdDJGCdTNZjDxdydK = 1;

			private const int DzmIMsnHElNfpOZiosJfyYNRFbdS = 2;

			float IControllerTemplateThrottle.value
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return 0f;
					}
					return ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[0]).jXCVuvpgUTxlGlTHfAAzdVwInwVk;
				}
			}

			float IControllerTemplateThrottle.valuePrev
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return 0f;
					}
					return ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[0]).pxCOZgtALVnhLToZRYeYIPPjDywcA;
				}
			}

			IControllerTemplateAxis IControllerTemplateThrottle.throttle
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateAxis)ykWiIUdMtRyEJxDJAGHlanXNAImtA[0];
				}
			}

			IControllerTemplateButton IControllerTemplateThrottle.minDetent
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateButton)ykWiIUdMtRyEJxDJAGHlanXNAImtA[1];
				}
			}

			private fYOtxocvVXzpIDPwRJeJHiHQKuCQ(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, tkKGeIGfCGinmnoNBPOdYHhFkyoDA[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Throttle, P_4, tkKGeIGfCGinmnoNBPOdYHhFkyoDA.LLxQkwkbjhrajnasWaKwEPUmNkzuA(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 2)
				{
					throw new ArgumentException("elements.Length must be " + 2);
				}
			}

			internal fYOtxocvVXzpIDPwRJeJHiHQKuCQ(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, lSPxnJedJzfeqgIWxVWepxRjinRcA P_4, lSPxnJedJzfeqgIWxVWepxRjinRcA P_5)
				: this(P_0, P_1, P_2, P_3, new tkKGeIGfCGinmnoNBPOdYHhFkyoDA[2] { P_4, P_5 })
			{
			}
		}

		internal sealed class AdcfIcNjJfgWTiaOWeBkvoRBUYej : HFdwUseEUeEcibzQTEsUPRxtkoRzA, IControllerTemplateHat, IControllerTemplateElement
		{
			private const int QEHImcmmwXMoHRPXJShKOhsoeWGEA = 0;

			private const int yskJIhrlMcraOjSRafovTepEnpoq = 1;

			private const int ctoHafnNgSCwqnZnhaMvVocGJtxJ = 2;

			private const int hlSVZTZbYeetDHhBauBotmWvkykOA = 3;

			private const int BLVDWsHSdpIKeVLPYezrDPrgWUOWb = 4;

			private const int feWOLAmvsSNQgJdraDYuOVPxvpsh = 5;

			private const int rgpHYtVBwCgSnITxADKWFzEOYkpF = 6;

			private const int UJRdpXJfMArrYFTKPDtwXljBglFDb = 7;

			private const int xDNRomAvzMUoaXvDieGTvBbKPKiI = 8;

			Vector2 IControllerTemplateHat.value
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[0]).jXCVuvpgUTxlGlTHfAAzdVwInwVk;
					result.x += ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[2]).jXCVuvpgUTxlGlTHfAAzdVwInwVk;
					result.y -= ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[4]).jXCVuvpgUTxlGlTHfAAzdVwInwVk;
					result.x -= ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[6]).jXCVuvpgUTxlGlTHfAAzdVwInwVk;
					float num = ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[1]).jXCVuvpgUTxlGlTHfAAzdVwInwVk;
					float num2 = ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[3]).jXCVuvpgUTxlGlTHfAAzdVwInwVk;
					float num3 = ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[5]).jXCVuvpgUTxlGlTHfAAzdVwInwVk;
					float num4 = ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[7]).jXCVuvpgUTxlGlTHfAAzdVwInwVk;
					result.x += num + num2 - num3 - num4;
					result.y += num + num4 - num2 - num3;
					result.x = MathTools.Clamp(result.x, -1f, 1f);
					result.y = MathTools.Clamp(result.y, -1f, 1f);
					return result;
				}
			}

			Vector2 IControllerTemplateHat.valuePrev
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[0]).pxCOZgtALVnhLToZRYeYIPPjDywcA;
					result.x += ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[2]).pxCOZgtALVnhLToZRYeYIPPjDywcA;
					result.y -= ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[4]).pxCOZgtALVnhLToZRYeYIPPjDywcA;
					result.x -= ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[6]).pxCOZgtALVnhLToZRYeYIPPjDywcA;
					float num = ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[1]).pxCOZgtALVnhLToZRYeYIPPjDywcA;
					float num2 = ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[3]).pxCOZgtALVnhLToZRYeYIPPjDywcA;
					float num3 = ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[5]).pxCOZgtALVnhLToZRYeYIPPjDywcA;
					float num4 = ((lSPxnJedJzfeqgIWxVWepxRjinRcA)ykWiIUdMtRyEJxDJAGHlanXNAImtA[7]).pxCOZgtALVnhLToZRYeYIPPjDywcA;
					result.x += num + num2 - num3 - num4;
					result.y += num + num4 - num2 - num3;
					result.x = MathTools.Clamp(result.x, -1f, 1f);
					result.y = MathTools.Clamp(result.y, -1f, 1f);
					return result;
				}
			}

			IControllerTemplateButton IControllerTemplateHat.up
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateButton)ykWiIUdMtRyEJxDJAGHlanXNAImtA[0];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.upRight
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateButton)ykWiIUdMtRyEJxDJAGHlanXNAImtA[1];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.right
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateButton)ykWiIUdMtRyEJxDJAGHlanXNAImtA[2];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.downRight
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateButton)ykWiIUdMtRyEJxDJAGHlanXNAImtA[3];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.down
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateButton)ykWiIUdMtRyEJxDJAGHlanXNAImtA[4];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.downLeft
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateButton)ykWiIUdMtRyEJxDJAGHlanXNAImtA[5];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.left
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateButton)ykWiIUdMtRyEJxDJAGHlanXNAImtA[6];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.upLeft
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateButton)ykWiIUdMtRyEJxDJAGHlanXNAImtA[7];
				}
			}

			private AdcfIcNjJfgWTiaOWeBkvoRBUYej(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, tkKGeIGfCGinmnoNBPOdYHhFkyoDA[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Hat, P_4, tkKGeIGfCGinmnoNBPOdYHhFkyoDA.LLxQkwkbjhrajnasWaKwEPUmNkzuA(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 8)
				{
					throw new ArgumentException("elements.Length must be " + 8);
				}
			}

			internal AdcfIcNjJfgWTiaOWeBkvoRBUYej(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, lSPxnJedJzfeqgIWxVWepxRjinRcA P_4, lSPxnJedJzfeqgIWxVWepxRjinRcA P_5, lSPxnJedJzfeqgIWxVWepxRjinRcA P_6, lSPxnJedJzfeqgIWxVWepxRjinRcA P_7, lSPxnJedJzfeqgIWxVWepxRjinRcA P_8, lSPxnJedJzfeqgIWxVWepxRjinRcA P_9, lSPxnJedJzfeqgIWxVWepxRjinRcA P_10, lSPxnJedJzfeqgIWxVWepxRjinRcA P_11)
				: this(P_0, P_1, P_2, P_3, new tkKGeIGfCGinmnoNBPOdYHhFkyoDA[8] { P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11 })
			{
			}
		}

		internal sealed class KtzngPXqskzfOGhQlZDwJrGHuYFQ : jiOyySpCaPXjRLoefYmMhTrOunbp, IControllerTemplateYoke, IControllerTemplateElement
		{
			private const int XsmYFeRDGOaMjewcKbvfXLwPLDZkA = 2;

			IControllerTemplateAxis IControllerTemplateYoke.rotation
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateAxis)ykWiIUdMtRyEJxDJAGHlanXNAImtA[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateYoke.pushPull
			{
				get
				{
					if (ReInput._id != WnfZzuOhNJACIKODilWvbmtmuHvB)
					{
						ReInput.CheckInitialized(WnfZzuOhNJACIKODilWvbmtmuHvB);
						return null;
					}
					return (IControllerTemplateAxis)ykWiIUdMtRyEJxDJAGHlanXNAImtA[1];
				}
			}

			private KtzngPXqskzfOGhQlZDwJrGHuYFQ(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, tkKGeIGfCGinmnoNBPOdYHhFkyoDA[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Yoke, P_4, tkKGeIGfCGinmnoNBPOdYHhFkyoDA.LLxQkwkbjhrajnasWaKwEPUmNkzuA(P_0, P_1, P_2, P_3))
			{
			}

			internal KtzngPXqskzfOGhQlZDwJrGHuYFQ(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, lSPxnJedJzfeqgIWxVWepxRjinRcA P_4, lSPxnJedJzfeqgIWxVWepxRjinRcA P_5)
				: this(P_0, P_1, P_2, P_3, new tkKGeIGfCGinmnoNBPOdYHhFkyoDA[2] { P_4, P_5 })
			{
			}
		}

		internal sealed class keJKAXtrLAGAmLhnfGvhXurQnQab : FZiDmnGcCVDgcbftEUMGihQarTKQE, IControllerTemplateStick6D, IControllerTemplateElement
		{
			private const int luOaDAmRfTeUfAYtDtJkTIubXGwAA = 6;

			private keJKAXtrLAGAmLhnfGvhXurQnQab(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, tkKGeIGfCGinmnoNBPOdYHhFkyoDA[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Stick6D, P_4, tkKGeIGfCGinmnoNBPOdYHhFkyoDA.LLxQkwkbjhrajnasWaKwEPUmNkzuA(P_0, P_1, P_2, P_3))
			{
			}

			internal keJKAXtrLAGAmLhnfGvhXurQnQab(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, lSPxnJedJzfeqgIWxVWepxRjinRcA P_4, lSPxnJedJzfeqgIWxVWepxRjinRcA P_5, lSPxnJedJzfeqgIWxVWepxRjinRcA P_6, lSPxnJedJzfeqgIWxVWepxRjinRcA P_7, lSPxnJedJzfeqgIWxVWepxRjinRcA P_8, lSPxnJedJzfeqgIWxVWepxRjinRcA P_9)
				: this(P_0, P_1, P_2, P_3, new tkKGeIGfCGinmnoNBPOdYHhFkyoDA[6] { P_4, P_5, P_6, P_7, P_8, P_9 })
			{
			}
		}

		internal class AFAiEcEMrQadeSEkjLdZgrdTYyjQA
		{
			public readonly Controller.Element LGDHClejRrKRqsmbziwXaflmNIyO;

			public readonly IControllerElementTarget MtiIvxpEpXnGMdDGjGMjCxyrtltWA;

			public bool YltnJMPgOkrQJNuTpskidbQIhPeI
			{
				get
				{
					if (LGDHClejRrKRqsmbziwXaflmNIyO == null)
					{
						return false;
					}
					switch (LGDHClejRrKRqsmbziwXaflmNIyO.type)
					{
					case ControllerElementType.Button:
						return (LGDHClejRrKRqsmbziwXaflmNIyO as Controller.Button).value;
					case ControllerElementType.Axis:
					{
						float value = (LGDHClejRrKRqsmbziwXaflmNIyO as Controller.Axis).value;
						switch (MtiIvxpEpXnGMdDGjGMjCxyrtltWA.axisRange)
						{
						case AxisRange.Full:
							if (value > 0.01f)
							{
								return true;
							}
							if (value < -0.01f)
							{
								return true;
							}
							break;
						case AxisRange.Positive:
							if (value > 0.01f)
							{
								return true;
							}
							break;
						case AxisRange.Negative:
							if (value < -0.01f)
							{
								return true;
							}
							break;
						}
						break;
					}
					}
					return false;
				}
			}

			public bool SHOFoPpnICXGtgFlVEaQKfTmZoqvA
			{
				get
				{
					if (LGDHClejRrKRqsmbziwXaflmNIyO == null)
					{
						return false;
					}
					switch (LGDHClejRrKRqsmbziwXaflmNIyO.type)
					{
					case ControllerElementType.Button:
						return (LGDHClejRrKRqsmbziwXaflmNIyO as Controller.Button).valuePrev;
					case ControllerElementType.Axis:
					{
						float valuePrev = (LGDHClejRrKRqsmbziwXaflmNIyO as Controller.Axis).valuePrev;
						switch (MtiIvxpEpXnGMdDGjGMjCxyrtltWA.axisRange)
						{
						case AxisRange.Full:
							if (valuePrev > 0.01f)
							{
								return true;
							}
							if (valuePrev < -0.01f)
							{
								return true;
							}
							break;
						case AxisRange.Positive:
							if (valuePrev > 0.01f)
							{
								return true;
							}
							break;
						case AxisRange.Negative:
							if (valuePrev < -0.01f)
							{
								return true;
							}
							break;
						}
						break;
					}
					}
					return false;
				}
			}

			public bool dcnZqMdjjJTXKsbryGebIQHNCLwm
			{
				get
				{
					if (LGDHClejRrKRqsmbziwXaflmNIyO == null)
					{
						return false;
					}
					switch (LGDHClejRrKRqsmbziwXaflmNIyO.type)
					{
					case ControllerElementType.Button:
						return (LGDHClejRrKRqsmbziwXaflmNIyO as Controller.Button).justPressed;
					case ControllerElementType.Axis:
						if (MathTools.Abs(YrNsSVAqhhWoRXVNjqBMftNAjTCW) > 0.01f && MathTools.Abs(kTDpessCbLBxbasWkHpRhMoTPvah) <= 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public bool SNcDHINeUgaGEeuHnjRCzfSFWDZfA
			{
				get
				{
					if (LGDHClejRrKRqsmbziwXaflmNIyO == null)
					{
						return false;
					}
					switch (LGDHClejRrKRqsmbziwXaflmNIyO.type)
					{
					case ControllerElementType.Button:
						return (LGDHClejRrKRqsmbziwXaflmNIyO as Controller.Button).justReleased;
					case ControllerElementType.Axis:
						if (MathTools.Abs(YrNsSVAqhhWoRXVNjqBMftNAjTCW) <= 0.01f && MathTools.Abs(kTDpessCbLBxbasWkHpRhMoTPvah) > 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public float YrNsSVAqhhWoRXVNjqBMftNAjTCW
			{
				get
				{
					if (LGDHClejRrKRqsmbziwXaflmNIyO == null)
					{
						return 0f;
					}
					switch (LGDHClejRrKRqsmbziwXaflmNIyO.type)
					{
					case ControllerElementType.Button:
						if (!(LGDHClejRrKRqsmbziwXaflmNIyO as Controller.Button).value)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
					{
						float value = (LGDHClejRrKRqsmbziwXaflmNIyO as Controller.Axis).value;
						switch (MtiIvxpEpXnGMdDGjGMjCxyrtltWA.axisRange)
						{
						case AxisRange.Full:
							return value;
						case AxisRange.Positive:
							if (value > 0f)
							{
								return value;
							}
							break;
						case AxisRange.Negative:
							if (value < 0f)
							{
								return value;
							}
							break;
						}
						break;
					}
					}
					return 0f;
				}
			}

			public float kTDpessCbLBxbasWkHpRhMoTPvah
			{
				get
				{
					if (LGDHClejRrKRqsmbziwXaflmNIyO == null)
					{
						return 0f;
					}
					switch (LGDHClejRrKRqsmbziwXaflmNIyO.type)
					{
					case ControllerElementType.Button:
						if (!(LGDHClejRrKRqsmbziwXaflmNIyO as Controller.Button).valuePrev)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
					{
						float valuePrev = (LGDHClejRrKRqsmbziwXaflmNIyO as Controller.Axis).valuePrev;
						switch (MtiIvxpEpXnGMdDGjGMjCxyrtltWA.axisRange)
						{
						case AxisRange.Full:
							return valuePrev;
						case AxisRange.Positive:
							if (valuePrev > 0f)
							{
								return valuePrev;
							}
							break;
						case AxisRange.Negative:
							if (valuePrev < 0f)
							{
								return valuePrev;
							}
							break;
						}
						break;
					}
					}
					return 0f;
				}
			}

			public AFAiEcEMrQadeSEkjLdZgrdTYyjQA(IControllerElementTarget P_0, Controller.Element P_1)
			{
				LGDHClejRrKRqsmbziwXaflmNIyO = P_1;
				MtiIvxpEpXnGMdDGjGMjCxyrtltWA = P_0;
			}

			public static AFAiEcEMrQadeSEkjLdZgrdTYyjQA lXdSzPvKqIViqQOsWFcJDVLqqviwA()
			{
				return new AFAiEcEMrQadeSEkjLdZgrdTYyjQA(oFieiUIUewVeTJqZtmiJuPDLbluKA.qXUNZZuijDscRtCotpGpTMLihHXH(), null);
			}
		}

		internal class uvKuvgzFdRvOQKoZxeZZdONpEudx
		{
			public readonly Controller kMsDcYjKyuMjRzcRErFomfXCJYLY;

			public readonly IHardwareControllerTemplateMap_Internal ZWZoIxNsIxXHQOAGWMLjoIQlimZe;

			public uvKuvgzFdRvOQKoZxeZZdONpEudx(Controller P_0, IHardwareControllerTemplateMap_Internal P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("controller");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("templateMap");
				}
				kMsDcYjKyuMjRzcRErFomfXCJYLY = P_0;
				ZWZoIxNsIxXHQOAGWMLjoIQlimZe = P_1;
			}
		}

		private sealed class JmONvkcactDGGnRvPaoPCJLywnri
		{
			[Serializable]
			private sealed class LxmhlNWDCuzGJdCzgQWcryobNKVG
			{
				public static readonly LxmhlNWDCuzGJdCzgQWcryobNKVG _003C_003E9 = new LxmhlNWDCuzGJdCzgQWcryobNKVG();

				public static Func<zFxewYcdsnklzPlkSKWylcOJCubnA, zFxewYcdsnklzPlkSKWylcOJCubnA, bool> _003C_003E9__4_0;

				internal bool nBxagiIeRUrLXlSIuXHKtMinUZsdA(zFxewYcdsnklzPlkSKWylcOJCubnA P_0, zFxewYcdsnklzPlkSKWylcOJCubnA P_1)
				{
					if (P_0 == null || P_1 == null)
					{
						return false;
					}
					return P_0.jzkCIkAVYmrXkeyOSOOvJsYqsIIL(P_1, false);
				}
			}

			private static JmONvkcactDGGnRvPaoPCJLywnri ZtlssNRvECMkvTwqPekxiQjfPzbM;

			private readonly global::xHnZWDhFGbiJownHBijvjqoTlMxEb<zFxewYcdsnklzPlkSKWylcOJCubnA> KjCcmpPvQBnnxRfmdhYWtOrcfqpb;

			private static JmONvkcactDGGnRvPaoPCJLywnri JCdxKLQwjaUjyvgFiOYSoVHYGXgt
			{
				get
				{
					if (ZtlssNRvECMkvTwqPekxiQjfPzbM != null)
					{
						return ZtlssNRvECMkvTwqPekxiQjfPzbM;
					}
					ZtlssNRvECMkvTwqPekxiQjfPzbM = new JmONvkcactDGGnRvPaoPCJLywnri();
					ZtlssNRvECMkvTwqPekxiQjfPzbM.oBjIEnugPjDidbfeHFHTSMfXvWjA();
					return ZtlssNRvECMkvTwqPekxiQjfPzbM;
				}
			}

			private JmONvkcactDGGnRvPaoPCJLywnri()
			{
				KjCcmpPvQBnnxRfmdhYWtOrcfqpb = new global::xHnZWDhFGbiJownHBijvjqoTlMxEb<zFxewYcdsnklzPlkSKWylcOJCubnA>(LxmhlNWDCuzGJdCzgQWcryobNKVG._003C_003E9.nBxagiIeRUrLXlSIuXHKtMinUZsdA);
			}

			private void oBjIEnugPjDidbfeHFHTSMfXvWjA()
			{
				ReInput.ShutDownEvent += ZtlssNRvECMkvTwqPekxiQjfPzbM.RMCFOktBNDhYMbmwKLPEwLLzJFsrA;
			}

			private void RMCFOktBNDhYMbmwKLPEwLLzJFsrA()
			{
				if (ZtlssNRvECMkvTwqPekxiQjfPzbM == this)
				{
					ZtlssNRvECMkvTwqPekxiQjfPzbM = null;
				}
				ReInput.ShutDownEvent -= RMCFOktBNDhYMbmwKLPEwLLzJFsrA;
			}

			public static zFxewYcdsnklzPlkSKWylcOJCubnA fkwGGVMWJGKkxnmUmrMLnoeBdTKm(zFxewYcdsnklzPlkSKWylcOJCubnA P_0)
			{
				Bytes20 bytes = ((P_0.oamKCxmhMbMqPVakuvihqBxQRmvO is IKSacKLVyLBPnEFekyTvBVRtjkNe iKSacKLVyLBPnEFekyTvBVRtjkNe) ? iKSacKLVyLBPnEFekyTvBVRtjkNe.zLLhpYIXxjXosNBqIwKAIcSZIvLU.hash : default(Bytes20));
				return JCdxKLQwjaUjyvgFiOYSoVHYGXgt.KjCcmpPvQBnnxRfmdhYWtOrcfqpb.EYMpOyiRjmedkBfSviPFfZqDTlAb(bytes, P_0);
			}

			public static bool dAcQQJqmoajIBoYnQFOKfzEGcobJ(zFxewYcdsnklzPlkSKWylcOJCubnA P_0, out zFxewYcdsnklzPlkSKWylcOJCubnA P_1)
			{
				Bytes20 bytes = ((P_0.oamKCxmhMbMqPVakuvihqBxQRmvO is IKSacKLVyLBPnEFekyTvBVRtjkNe iKSacKLVyLBPnEFekyTvBVRtjkNe) ? iKSacKLVyLBPnEFekyTvBVRtjkNe.zLLhpYIXxjXosNBqIwKAIcSZIvLU.hash : default(Bytes20));
				return JCdxKLQwjaUjyvgFiOYSoVHYGXgt.KjCcmpPvQBnnxRfmdhYWtOrcfqpb.qrFrqzPWIsDJMlbgkLpFmaHheneF(bytes, P_0, out P_1);
			}

			public static void ZjqdUOJtKXAIEEieefqKfNobWCKFB(zFxewYcdsnklzPlkSKWylcOJCubnA P_0)
			{
				Bytes20 bytes = ((P_0.oamKCxmhMbMqPVakuvihqBxQRmvO is IKSacKLVyLBPnEFekyTvBVRtjkNe iKSacKLVyLBPnEFekyTvBVRtjkNe) ? iKSacKLVyLBPnEFekyTvBVRtjkNe.zLLhpYIXxjXosNBqIwKAIcSZIvLU.hash : default(Bytes20));
				JCdxKLQwjaUjyvgFiOYSoVHYGXgt.KjCcmpPvQBnnxRfmdhYWtOrcfqpb.NXHLFpCwANwzyGWhCrhPkhelfuym(bytes, P_0);
			}
		}

		private const string YcQdeabAyEdzjaWyHxdTXqbJDjfcc = "controller/template";

		private string aLQCsCRhxCRENwmCXfqhhgLURhoe;

		private string qvrNAwpoeMVsYMWolQLDhaqakLrc;

		private int LMJvVQZCifzoUQpCXsluFNOfkKYC;

		private readonly Guid OKncDwjoZJsOnkkeNxOTdynOYYoq;

		private readonly DeviceLocalizationInfo BoGFpQBcZLlrLGhVefTBBvaEvgzVc;

		private readonly Controller KrfjmmePfMQpwTWGonZuelmAonBm;

		private readonly ADictionary<int, IControllerTemplateElement> mvIUoCzRqHIhWfOxajzgZviqGrLV;

		private readonly ADictionary<string, IControllerTemplateElement> RkxZdIacafGIBPPFnxJXlsdjAvog;

		private IControllerTemplateElement[] KMvCQyBMVyFlQqABfvFyELRrDvFI;

		private ReadOnlyCollection<IControllerTemplateElement> wnfsGLeHFcpEEJShRGlGcQpxjEWB;

		private readonly SPMTiKUCwsRqljCIHClsxjXsIRtS qZPaxChMmsTzdAHiLghzFCkhWFoTb;

		private readonly int pRhxtazhXTmaGwhVLGBxbhbLHktmA;

		internal DeviceLocalizationInfo tyQsbHsTdcXjXKbvWhHcSYkMTwXt => BoGFpQBcZLlrLGhVefTBBvaEvgzVc;

		DeviceLocalizationInfo IControllerTemplate_Internal.deviceLocalizationInfo => BoGFpQBcZLlrLGhVefTBBvaEvgzVc;

		Controller IControllerTemplate.controller
		{
			get
			{
				if (ReInput._id != pRhxtazhXTmaGwhVLGBxbhbLHktmA)
				{
					ReInput.CheckInitialized(pRhxtazhXTmaGwhVLGBxbhbLHktmA);
					return null;
				}
				return KrfjmmePfMQpwTWGonZuelmAonBm;
			}
		}

		string IControllerTemplate.name
		{
			get
			{
				if (ReInput._id != pRhxtazhXTmaGwhVLGBxbhbLHktmA)
				{
					ReInput.CheckInitialized(pRhxtazhXTmaGwhVLGBxbhbLHktmA);
					return null;
				}
				if (!LocalizationManager.isEnabled)
				{
					return aLQCsCRhxCRENwmCXfqhhgLURhoe;
				}
				return qZPaxChMmsTzdAHiLghzFCkhWFoTb.aWxJJrCnpmeqmclTDPTQjepbcypsA;
			}
		}

		Guid IControllerTemplate.typeGuid
		{
			get
			{
				if (ReInput._id != pRhxtazhXTmaGwhVLGBxbhbLHktmA)
				{
					ReInput.CheckInitialized(pRhxtazhXTmaGwhVLGBxbhbLHktmA);
					return Guid.Empty;
				}
				return OKncDwjoZJsOnkkeNxOTdynOYYoq;
			}
		}

		IList<IControllerTemplateElement> IControllerTemplate.elements
		{
			get
			{
				if (ReInput._id != pRhxtazhXTmaGwhVLGBxbhbLHktmA)
				{
					ReInput.CheckInitialized(pRhxtazhXTmaGwhVLGBxbhbLHktmA);
					return null;
				}
				return wnfsGLeHFcpEEJShRGlGcQpxjEWB;
			}
		}

		int IControllerTemplate.elementCount
		{
			get
			{
				if (ReInput._id != pRhxtazhXTmaGwhVLGBxbhbLHktmA)
				{
					ReInput.CheckInitialized(pRhxtazhXTmaGwhVLGBxbhbLHktmA);
					return 0;
				}
				return KMvCQyBMVyFlQqABfvFyELRrDvFI.Length;
			}
		}

		string BMeYXymsuXMDMyjfaaClzmryYLZG.keyCategory => "controller/template";

		string BMeYXymsuXMDMyjfaaClzmryYLZG.scriptingName => string.Empty;

		string BMeYXymsuXMDMyjfaaClzmryYLZG.nonLocalizedDescriptiveName
		{
			get
			{
				return aLQCsCRhxCRENwmCXfqhhgLURhoe;
			}
			set
			{
				aLQCsCRhxCRENwmCXfqhhgLURhoe = value;
			}
		}

		string BMeYXymsuXMDMyjfaaClzmryYLZG.key => qvrNAwpoeMVsYMWolQLDhaqakLrc;

		int BMeYXymsuXMDMyjfaaClzmryYLZG.autoGeneratedValueFlags
		{
			get
			{
				return LMJvVQZCifzoUQpCXsluFNOfkKYC;
			}
			set
			{
				LMJvVQZCifzoUQpCXsluFNOfkKYC = value;
			}
		}

		protected ControllerTemplate(object P_0)
			: this((uvKuvgzFdRvOQKoZxeZZdONpEudx)P_0)
		{
		}

		private ControllerTemplate(uvKuvgzFdRvOQKoZxeZZdONpEudx P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initializer");
			}
			if (P_0.kMsDcYjKyuMjRzcRErFomfXCJYLY == null)
			{
				throw new ArgumentNullException("initializer.controller");
			}
			if (P_0.ZWZoIxNsIxXHQOAGWMLjoIQlimZe == null)
			{
				throw new ArgumentNullException("initializer.templateMap");
			}
			pRhxtazhXTmaGwhVLGBxbhbLHktmA = ReInput.id;
			KrfjmmePfMQpwTWGonZuelmAonBm = P_0.kMsDcYjKyuMjRzcRErFomfXCJYLY;
			IHardwareControllerTemplateMap_Internal zWZoIxNsIxXHQOAGWMLjoIQlimZe = P_0.ZWZoIxNsIxXHQOAGWMLjoIQlimZe;
			aLQCsCRhxCRENwmCXfqhhgLURhoe = zWZoIxNsIxXHQOAGWMLjoIQlimZe.name;
			qvrNAwpoeMVsYMWolQLDhaqakLrc = zWZoIxNsIxXHQOAGWMLjoIQlimZe.typeKey;
			OKncDwjoZJsOnkkeNxOTdynOYYoq = zWZoIxNsIxXHQOAGWMLjoIQlimZe.typeGuid;
			BoGFpQBcZLlrLGhVefTBBvaEvgzVc = new DeviceLocalizationInfo(KrfjmmePfMQpwTWGonZuelmAonBm.type, true, OKncDwjoZJsOnkkeNxOTdynOYYoq, new List<string> { zWZoIxNsIxXHQOAGWMLjoIQlimZe.typeKey }, null);
			BoGFpQBcZLlrLGhVefTBBvaEvgzVc.FinishRuntimeSetup();
			qZPaxChMmsTzdAHiLghzFCkhWFoTb = SPMTiKUCwsRqljCIHClsxjXsIRtS.wSAuMAiJgaVkfzHhKDNRukSwzTCi(this);
			int elementIdentifierCount = zWZoIxNsIxXHQOAGWMLjoIQlimZe.GetElementIdentifierCount();
			ADictionary<int, IControllerTemplateElement> aDictionary = new ADictionary<int, IControllerTemplateElement>();
			List<IControllerTemplateElement> list = new List<IControllerTemplateElement>();
			List<IControllerTemplateAxis> list2 = new List<IControllerTemplateAxis>();
			List<IControllerTemplateButton> list3 = new List<IControllerTemplateButton>();
			List<IControllerTemplateElement> list4 = new List<IControllerTemplateElement>();
			for (int i = 0; i < elementIdentifierCount; i++)
			{
				IControllerTemplateElementIdentifier templateElementIdentifier = zWZoIxNsIxXHQOAGWMLjoIQlimZe.GetTemplateElementIdentifier(i);
				if (templateElementIdentifier != null && InputTools.IsMappableType(templateElementIdentifier.elementType))
				{
					switch (templateElementIdentifier.elementType)
					{
					case ControllerTemplateElementType.Axis:
					{
						ZjsvgUMHkMFRcjnXfMJoZEAVgouqA zjsvgUMHkMFRcjnXfMJoZEAVgouqA2 = zWZoIxNsIxXHQOAGWMLjoIQlimZe.GetAxisTarget(KrfjmmePfMQpwTWGonZuelmAonBm, templateElementIdentifier.id) ?? ZjsvgUMHkMFRcjnXfMJoZEAVgouqA.UgJqQFedtMXhSrKVrFdnnDIAlKxe(ControllerTemplateElementType.Axis);
						OnDxEcZLyLuAeoIOMGNbMNpapNEU item2 = new OnDxEcZLyLuAeoIOMGNbMNpapNEU(this, templateElementIdentifier.id, templateElementIdentifier.nonLocalizedName, (!templateElementIdentifier.isNonLocalizedPositiveNameAutoGenerated) ? templateElementIdentifier.nonLocalizedPositiveName : string.Empty, (!templateElementIdentifier.isNonLocalizedNegativeNameAutoGenerated) ? templateElementIdentifier.nonLocalizedNegativeName : string.Empty, templateElementIdentifier.key, (!templateElementIdentifier.isPositiveKeyAutoGenerated) ? templateElementIdentifier.positiveKey : string.Empty, (!templateElementIdentifier.isNegativeKeyAutoGenerated) ? templateElementIdentifier.negativeKey : string.Empty, zjsvgUMHkMFRcjnXfMJoZEAVgouqA2, oqIPlJtRipwkDnGLMXJlWYhASqEE(KrfjmmePfMQpwTWGonZuelmAonBm, zjsvgUMHkMFRcjnXfMJoZEAVgouqA2));
						list2.Add(item2);
						break;
					}
					case ControllerTemplateElementType.Button:
					{
						ZjsvgUMHkMFRcjnXfMJoZEAVgouqA zjsvgUMHkMFRcjnXfMJoZEAVgouqA = zWZoIxNsIxXHQOAGWMLjoIQlimZe.GetButtonTarget(KrfjmmePfMQpwTWGonZuelmAonBm, templateElementIdentifier.id) ?? ZjsvgUMHkMFRcjnXfMJoZEAVgouqA.UgJqQFedtMXhSrKVrFdnnDIAlKxe(ControllerTemplateElementType.Button);
						dHnyrrYRTDRQvvQOBXaRpadbunPl item = new dHnyrrYRTDRQvvQOBXaRpadbunPl(this, templateElementIdentifier.id, templateElementIdentifier.nonLocalizedName, (!templateElementIdentifier.isNonLocalizedPositiveNameAutoGenerated) ? templateElementIdentifier.nonLocalizedPositiveName : string.Empty, (!templateElementIdentifier.isNonLocalizedNegativeNameAutoGenerated) ? templateElementIdentifier.nonLocalizedNegativeName : string.Empty, templateElementIdentifier.key, (!templateElementIdentifier.isPositiveKeyAutoGenerated) ? templateElementIdentifier.positiveKey : string.Empty, (!templateElementIdentifier.isNegativeKeyAutoGenerated) ? templateElementIdentifier.negativeKey : string.Empty, zjsvgUMHkMFRcjnXfMJoZEAVgouqA, pGMOAeLHKkbWUrdylryGZPvJPyYL(KrfjmmePfMQpwTWGonZuelmAonBm, zjsvgUMHkMFRcjnXfMJoZEAVgouqA));
						list3.Add(item);
						break;
					}
					default:
						throw new NotImplementedException();
					}
				}
			}
			for (int j = 0; j < list2.Count; j++)
			{
				list.Add(list2[j]);
			}
			for (int k = 0; k < list3.Count; k++)
			{
				list.Add(list3[k]);
			}
			for (int l = 0; l < list.Count; l++)
			{
				aDictionary.Add(list[l].id, list[l]);
			}
			for (int m = 0; m < elementIdentifierCount; m++)
			{
				IControllerTemplateElementIdentifier templateElementIdentifier2 = zWZoIxNsIxXHQOAGWMLjoIQlimZe.GetTemplateElementIdentifier(m);
				if (templateElementIdentifier2 == null || InputTools.IsMappableType(templateElementIdentifier2.elementType))
				{
					continue;
				}
				IControllerTemplateMapSpecialElement_Internal specialTemplateElementByElementIdentifierId = zWZoIxNsIxXHQOAGWMLjoIQlimZe.GetSpecialTemplateElementByElementIdentifierId(templateElementIdentifier2.id);
				tkKGeIGfCGinmnoNBPOdYHhFkyoDA tkKGeIGfCGinmnoNBPOdYHhFkyoDA2;
				switch (templateElementIdentifier2.elementType)
				{
				case ControllerTemplateElementType.ThumbStick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateThumbStickMapping mapping5 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThumbStickMapping>();
					tkKGeIGfCGinmnoNBPOdYHhFkyoDA2 = new EXDccTEEMMbFYFltXVCDbNIDzpgLB(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping5 != null) ? FuheRDltgzOBGADhZstlaZiAigCA(this, aDictionary, mapping5.eid_axisX) : OnDxEcZLyLuAeoIOMGNbMNpapNEU.VKcMAptVqnbtYOfwOZGdBJKzFkZF(this), (mapping5 != null) ? FuheRDltgzOBGADhZstlaZiAigCA(this, aDictionary, mapping5.eid_axisY) : OnDxEcZLyLuAeoIOMGNbMNpapNEU.VKcMAptVqnbtYOfwOZGdBJKzFkZF(this), (mapping5 != null) ? zkMtxdpzJINVTKkNfvHCzAqEtTZt(this, aDictionary, mapping5.eid_button) : dHnyrrYRTDRQvvQOBXaRpadbunPl.sVEeWXGJySMDfDIwDGHORuUTQImrA(this));
					break;
				}
				case ControllerTemplateElementType.DPad:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateDPadMapping mapping3 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateDPadMapping>();
					tkKGeIGfCGinmnoNBPOdYHhFkyoDA2 = new ihgxkCjSfNCEvBpYlxlUWASErXiX(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping3 != null) ? zkMtxdpzJINVTKkNfvHCzAqEtTZt(this, aDictionary, mapping3.eid_up) : dHnyrrYRTDRQvvQOBXaRpadbunPl.sVEeWXGJySMDfDIwDGHORuUTQImrA(this), (mapping3 != null) ? zkMtxdpzJINVTKkNfvHCzAqEtTZt(this, aDictionary, mapping3.eid_right) : dHnyrrYRTDRQvvQOBXaRpadbunPl.sVEeWXGJySMDfDIwDGHORuUTQImrA(this), (mapping3 != null) ? zkMtxdpzJINVTKkNfvHCzAqEtTZt(this, aDictionary, mapping3.eid_down) : dHnyrrYRTDRQvvQOBXaRpadbunPl.sVEeWXGJySMDfDIwDGHORuUTQImrA(this), (mapping3 != null) ? zkMtxdpzJINVTKkNfvHCzAqEtTZt(this, aDictionary, mapping3.eid_left) : dHnyrrYRTDRQvvQOBXaRpadbunPl.sVEeWXGJySMDfDIwDGHORuUTQImrA(this), (mapping3 != null) ? zkMtxdpzJINVTKkNfvHCzAqEtTZt(this, aDictionary, mapping3.eid_press) : dHnyrrYRTDRQvvQOBXaRpadbunPl.sVEeWXGJySMDfDIwDGHORuUTQImrA(this));
					break;
				}
				case ControllerTemplateElementType.Stick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateStickMapping mapping2 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStickMapping>();
					tkKGeIGfCGinmnoNBPOdYHhFkyoDA2 = new FgeaBzuPdrtrcOeQswxMIkpmBaNs(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping2 != null) ? FuheRDltgzOBGADhZstlaZiAigCA(this, aDictionary, mapping2.eid_axisX) : OnDxEcZLyLuAeoIOMGNbMNpapNEU.VKcMAptVqnbtYOfwOZGdBJKzFkZF(this), (mapping2 != null) ? FuheRDltgzOBGADhZstlaZiAigCA(this, aDictionary, mapping2.eid_axisY) : OnDxEcZLyLuAeoIOMGNbMNpapNEU.VKcMAptVqnbtYOfwOZGdBJKzFkZF(this), (mapping2 != null) ? FuheRDltgzOBGADhZstlaZiAigCA(this, aDictionary, mapping2.eid_axisZ) : OnDxEcZLyLuAeoIOMGNbMNpapNEU.VKcMAptVqnbtYOfwOZGdBJKzFkZF(this));
					break;
				}
				case ControllerTemplateElementType.Throttle:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateThrottleMapping mapping6 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThrottleMapping>();
					tkKGeIGfCGinmnoNBPOdYHhFkyoDA2 = new fYOtxocvVXzpIDPwRJeJHiHQKuCQ(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping6 != null) ? FuheRDltgzOBGADhZstlaZiAigCA(this, aDictionary, mapping6.eid_axis) : OnDxEcZLyLuAeoIOMGNbMNpapNEU.VKcMAptVqnbtYOfwOZGdBJKzFkZF(this), (mapping6 != null) ? zkMtxdpzJINVTKkNfvHCzAqEtTZt(this, aDictionary, mapping6.eid_minDetent) : dHnyrrYRTDRQvvQOBXaRpadbunPl.sVEeWXGJySMDfDIwDGHORuUTQImrA(this));
					break;
				}
				case ControllerTemplateElementType.Hat:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateHatMapping mapping7 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateHatMapping>();
					tkKGeIGfCGinmnoNBPOdYHhFkyoDA2 = new AdcfIcNjJfgWTiaOWeBkvoRBUYej(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping7 != null) ? zkMtxdpzJINVTKkNfvHCzAqEtTZt(this, aDictionary, mapping7.eid_up) : dHnyrrYRTDRQvvQOBXaRpadbunPl.sVEeWXGJySMDfDIwDGHORuUTQImrA(this), (mapping7 != null) ? zkMtxdpzJINVTKkNfvHCzAqEtTZt(this, aDictionary, mapping7.eid_upRight) : dHnyrrYRTDRQvvQOBXaRpadbunPl.sVEeWXGJySMDfDIwDGHORuUTQImrA(this), (mapping7 != null) ? zkMtxdpzJINVTKkNfvHCzAqEtTZt(this, aDictionary, mapping7.eid_right) : dHnyrrYRTDRQvvQOBXaRpadbunPl.sVEeWXGJySMDfDIwDGHORuUTQImrA(this), (mapping7 != null) ? zkMtxdpzJINVTKkNfvHCzAqEtTZt(this, aDictionary, mapping7.eid_downRight) : dHnyrrYRTDRQvvQOBXaRpadbunPl.sVEeWXGJySMDfDIwDGHORuUTQImrA(this), (mapping7 != null) ? zkMtxdpzJINVTKkNfvHCzAqEtTZt(this, aDictionary, mapping7.eid_down) : dHnyrrYRTDRQvvQOBXaRpadbunPl.sVEeWXGJySMDfDIwDGHORuUTQImrA(this), (mapping7 != null) ? zkMtxdpzJINVTKkNfvHCzAqEtTZt(this, aDictionary, mapping7.eid_downLeft) : dHnyrrYRTDRQvvQOBXaRpadbunPl.sVEeWXGJySMDfDIwDGHORuUTQImrA(this), (mapping7 != null) ? zkMtxdpzJINVTKkNfvHCzAqEtTZt(this, aDictionary, mapping7.eid_left) : dHnyrrYRTDRQvvQOBXaRpadbunPl.sVEeWXGJySMDfDIwDGHORuUTQImrA(this), (mapping7 != null) ? zkMtxdpzJINVTKkNfvHCzAqEtTZt(this, aDictionary, mapping7.eid_upLeft) : dHnyrrYRTDRQvvQOBXaRpadbunPl.sVEeWXGJySMDfDIwDGHORuUTQImrA(this));
					break;
				}
				case ControllerTemplateElementType.Yoke:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateYokeMapping mapping4 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateYokeMapping>();
					tkKGeIGfCGinmnoNBPOdYHhFkyoDA2 = new KtzngPXqskzfOGhQlZDwJrGHuYFQ(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping4 != null) ? FuheRDltgzOBGADhZstlaZiAigCA(this, aDictionary, mapping4.eid_axisX) : OnDxEcZLyLuAeoIOMGNbMNpapNEU.VKcMAptVqnbtYOfwOZGdBJKzFkZF(this), (mapping4 != null) ? FuheRDltgzOBGADhZstlaZiAigCA(this, aDictionary, mapping4.eid_axisZ) : OnDxEcZLyLuAeoIOMGNbMNpapNEU.VKcMAptVqnbtYOfwOZGdBJKzFkZF(this));
					break;
				}
				case ControllerTemplateElementType.Stick6D:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateStick6DMapping mapping = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStick6DMapping>();
					tkKGeIGfCGinmnoNBPOdYHhFkyoDA2 = new keJKAXtrLAGAmLhnfGvhXurQnQab(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping != null) ? FuheRDltgzOBGADhZstlaZiAigCA(this, aDictionary, mapping.eid_positionX) : OnDxEcZLyLuAeoIOMGNbMNpapNEU.VKcMAptVqnbtYOfwOZGdBJKzFkZF(this), (mapping != null) ? FuheRDltgzOBGADhZstlaZiAigCA(this, aDictionary, mapping.eid_positionY) : OnDxEcZLyLuAeoIOMGNbMNpapNEU.VKcMAptVqnbtYOfwOZGdBJKzFkZF(this), (mapping != null) ? FuheRDltgzOBGADhZstlaZiAigCA(this, aDictionary, mapping.eid_positionZ) : OnDxEcZLyLuAeoIOMGNbMNpapNEU.VKcMAptVqnbtYOfwOZGdBJKzFkZF(this), (mapping != null) ? FuheRDltgzOBGADhZstlaZiAigCA(this, aDictionary, mapping.eid_rotationX) : OnDxEcZLyLuAeoIOMGNbMNpapNEU.VKcMAptVqnbtYOfwOZGdBJKzFkZF(this), (mapping != null) ? FuheRDltgzOBGADhZstlaZiAigCA(this, aDictionary, mapping.eid_rotationY) : OnDxEcZLyLuAeoIOMGNbMNpapNEU.VKcMAptVqnbtYOfwOZGdBJKzFkZF(this), (mapping != null) ? FuheRDltgzOBGADhZstlaZiAigCA(this, aDictionary, mapping.eid_rotationZ) : OnDxEcZLyLuAeoIOMGNbMNpapNEU.VKcMAptVqnbtYOfwOZGdBJKzFkZF(this));
					break;
				}
				default:
					throw new NotImplementedException();
				}
				if (tkKGeIGfCGinmnoNBPOdYHhFkyoDA2 != null)
				{
					list4.Add(tkKGeIGfCGinmnoNBPOdYHhFkyoDA2);
				}
			}
			for (int n = 0; n < list4.Count; n++)
			{
				list.Add(list4[n]);
				aDictionary.Add(list4[n].id, list4[n]);
			}
			KMvCQyBMVyFlQqABfvFyELRrDvFI = list.ToArray();
			mvIUoCzRqHIhWfOxajzgZviqGrLV = aDictionary;
			RkxZdIacafGIBPPFnxJXlsdjAvog = new ADictionary<string, IControllerTemplateElement>();
			for (int num = 0; num < KMvCQyBMVyFlQqABfvFyELRrDvFI.Length; num++)
			{
				if (!(zWZoIxNsIxXHQOAGWMLjoIQlimZe.GetTemplateElementIdentifierById(KMvCQyBMVyFlQqABfvFyELRrDvFI[num].id) is IControllerTemplateElementIdentifier_Editor controllerTemplateElementIdentifier_Editor))
				{
					continue;
				}
				for (int num2 = 0; num2 < 2; num2++)
				{
					string text = ((num2 != 0) ? controllerTemplateElementIdentifier_Editor.alternateScriptingName : controllerTemplateElementIdentifier_Editor.scriptingName);
					if (!string.IsNullOrEmpty(text))
					{
						try
						{
							RkxZdIacafGIBPPFnxJXlsdjAvog.Add(text, KMvCQyBMVyFlQqABfvFyELRrDvFI[num]);
						}
						catch
						{
							Logger.LogError("A duplicate Controller Template element scripting name (" + text + ") was found in template " + aLQCsCRhxCRENwmCXfqhhgLURhoe + ". This element should be renamed to a unique name.");
						}
					}
				}
			}
			wnfsGLeHFcpEEJShRGlGcQpxjEWB = new ReadOnlyCollection<IControllerTemplateElement>(KMvCQyBMVyFlQqABfvFyELRrDvFI);
		}

		protected IControllerTemplateElement GetElement(int id)
		{
			if (!mvIUoCzRqHIhWfOxajzgZviqGrLV.TryGetValue(id, out var value))
			{
				Logger.LogWarning("There is no element with the id \"" + id + "\" in the " + GetType().ToString() + ".");
			}
			return value;
		}

		protected T GetElement<T>(int id) where T : class, IControllerTemplateElement
		{
			return GetElement(id) as T;
		}

		IControllerTemplateElement IControllerTemplate.GetElement(int id)
		{
			if (ReInput._id != pRhxtazhXTmaGwhVLGBxbhbLHktmA)
			{
				ReInput.CheckInitialized(pRhxtazhXTmaGwhVLGBxbhbLHktmA);
				return null;
			}
			return GetElement(id);
		}

		T IControllerTemplate.GetElement<T>(int id)
		{
			if (ReInput._id != pRhxtazhXTmaGwhVLGBxbhbLHktmA)
			{
				ReInput.CheckInitialized(pRhxtazhXTmaGwhVLGBxbhbLHktmA);
				return null;
			}
			return GetElement<T>(id);
		}

		int IControllerTemplate.GetElementTargets(ControllerElementTarget find, IList<ControllerTemplateElementTarget> results)
		{
			if (ReInput._id != pRhxtazhXTmaGwhVLGBxbhbLHktmA)
			{
				ReInput.CheckInitialized(pRhxtazhXTmaGwhVLGBxbhbLHktmA);
				return 0;
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			return GetElementTargets(find, ref results);
		}

		private int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> results)
		{
			if (results != null)
			{
				results.Clear();
			}
			int num = 0;
			for (int i = 0; i < KMvCQyBMVyFlQqABfvFyELRrDvFI.Length; i++)
			{
				if (InputTools.IsMappableType(KMvCQyBMVyFlQqABfvFyELRrDvFI[i].type))
				{
					num += (KMvCQyBMVyFlQqABfvFyELRrDvFI[i] as IControllerTemplateElement_Internal).GetElementTargets(find, ref results);
				}
			}
			return num;
		}

		[CustomObfuscation(rename = false)]
		internal static Type GetInterfaceType(ControllerTemplateElementType elementType)
		{
			return elementType switch
			{
				ControllerTemplateElementType.Axis => typeof(IControllerTemplateAxis), 
				ControllerTemplateElementType.Button => typeof(IControllerTemplateButton), 
				ControllerTemplateElementType.ThumbStick => typeof(IControllerTemplateThumbStick), 
				ControllerTemplateElementType.DPad => typeof(IControllerTemplateDPad), 
				ControllerTemplateElementType.Stick => typeof(IControllerTemplateStick), 
				ControllerTemplateElementType.Throttle => typeof(IControllerTemplateThrottle), 
				ControllerTemplateElementType.Hat => typeof(IControllerTemplateHat), 
				ControllerTemplateElementType.Yoke => typeof(IControllerTemplateYoke), 
				ControllerTemplateElementType.Stick6D => typeof(IControllerTemplateStick6D), 
				_ => throw new NotImplementedException(), 
			};
		}

		private static IList<AFAiEcEMrQadeSEkjLdZgrdTYyjQA> oqIPlJtRipwkDnGLMXJlWYhASqEE(Controller P_0, IControllerTemplateAxisSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			if (P_1.splitAxis)
			{
				IList<AFAiEcEMrQadeSEkjLdZgrdTYyjQA> list = null;
				bool flag = false;
				if (P_1.positiveTarget != null)
				{
					Controller.Element elementById = P_0.GetElementById(P_1.positiveTarget.elementIdentifierId);
					if (elementById != null)
					{
						ListTools.AddAndCreateList(ref list, new AFAiEcEMrQadeSEkjLdZgrdTYyjQA(P_1.positiveTarget, elementById));
						flag = true;
					}
				}
				if (!flag)
				{
					ListTools.AddAndCreateList(ref list, AFAiEcEMrQadeSEkjLdZgrdTYyjQA.lXdSzPvKqIViqQOsWFcJDVLqqviwA());
				}
				flag = false;
				if (P_1.negativeTarget != null)
				{
					Controller.Element elementById2 = P_0.GetElementById(P_1.negativeTarget.elementIdentifierId);
					if (elementById2 != null)
					{
						ListTools.AddAndCreateList(ref list, new AFAiEcEMrQadeSEkjLdZgrdTYyjQA(P_1.negativeTarget, elementById2));
						flag = true;
					}
				}
				if (!flag)
				{
					ListTools.AddAndCreateList(ref list, AFAiEcEMrQadeSEkjLdZgrdTYyjQA.lXdSzPvKqIViqQOsWFcJDVLqqviwA());
				}
				return list;
			}
			return WylLBDUiBWhBCpUwthZxuRGXwMxf(P_0, P_1.fullTarget);
		}

		private static IList<AFAiEcEMrQadeSEkjLdZgrdTYyjQA> pGMOAeLHKkbWUrdylryGZPvJPyYL(Controller P_0, IControllerTemplateButtonSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			return WylLBDUiBWhBCpUwthZxuRGXwMxf(P_0, P_1.target);
		}

		private static IList<AFAiEcEMrQadeSEkjLdZgrdTYyjQA> WylLBDUiBWhBCpUwthZxuRGXwMxf(Controller P_0, IControllerElementTarget P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			Controller.Element elementById = P_0.GetElementById(P_1.elementIdentifierId);
			if (elementById == null)
			{
				return null;
			}
			return new List<AFAiEcEMrQadeSEkjLdZgrdTYyjQA>
			{
				new AFAiEcEMrQadeSEkjLdZgrdTYyjQA(P_1, elementById)
			};
		}

		private static IControllerTemplateElement vxEJtaOauYmoRFQFvNwjfLBUGNCS(List<IControllerTemplateElement> P_0, int P_1)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i].id == P_1)
				{
					return P_0[i];
				}
			}
			return null;
		}

		private static lSPxnJedJzfeqgIWxVWepxRjinRcA FuheRDltgzOBGADhZstlaZiAigCA(IControllerTemplate_Internal P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is lSPxnJedJzfeqgIWxVWepxRjinRcA result))
			{
				return OnDxEcZLyLuAeoIOMGNbMNpapNEU.VKcMAptVqnbtYOfwOZGdBJKzFkZF(P_0);
			}
			return result;
		}

		private static lSPxnJedJzfeqgIWxVWepxRjinRcA zkMtxdpzJINVTKkNfvHCzAqEtTZt(IControllerTemplate_Internal P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is lSPxnJedJzfeqgIWxVWepxRjinRcA result))
			{
				return dHnyrrYRTDRQvvQOBXaRpadbunPl.sVEeWXGJySMDfDIwDGHORuUTQImrA(P_0);
			}
			return result;
		}
	}
}
