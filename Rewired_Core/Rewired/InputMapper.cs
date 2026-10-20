using System;
using System.Collections.Generic;
using System.Text;
using Rewired.Utils;

namespace Rewired
{
	public sealed class InputMapper
	{
		public class Context
		{
			private int RWeEyPfmepzVbhyYYkVIHzKCOiYKA = -1;

			private ControllerMap oJXgqROYTBEREkAxBMpgqfAHvFbn;

			private ActionElementMap oPQZrQesHSiPbqjQhNQbzlqXRwas;

			private AxisRange eOXCPTgJBBFYsjXqXvoidIJhVsYq = AxisRange.Positive;

			private bool hYqudYRnvGbxyHelsFVMBgEhckkGB;

			public int actionId
			{
				get
				{
					return RWeEyPfmepzVbhyYYkVIHzKCOiYKA;
				}
				set
				{
					if (!rhsvRaeSufnVAGDlTQvpFfxzqwGG())
					{
						RWeEyPfmepzVbhyYYkVIHzKCOiYKA = value;
					}
				}
			}

			public string actionName
			{
				get
				{
					InputAction action = ReInput.mapping.GetAction(RWeEyPfmepzVbhyYYkVIHzKCOiYKA);
					if (action == null)
					{
						return string.Empty;
					}
					return action.name;
				}
				set
				{
					if (!rhsvRaeSufnVAGDlTQvpFfxzqwGG())
					{
						InputAction action = ReInput.mapping.GetAction(value);
						if (action == null)
						{
							RWeEyPfmepzVbhyYYkVIHzKCOiYKA = -1;
							Logger.LogError("The Action \"" + value + "\" is not a valid Action and cannot be used!");
						}
						else
						{
							RWeEyPfmepzVbhyYYkVIHzKCOiYKA = action.id;
						}
					}
				}
			}

			public ControllerMap controllerMap
			{
				get
				{
					return oJXgqROYTBEREkAxBMpgqfAHvFbn;
				}
				set
				{
					if (!rhsvRaeSufnVAGDlTQvpFfxzqwGG())
					{
						oJXgqROYTBEREkAxBMpgqfAHvFbn = value;
					}
				}
			}

			public ActionElementMap actionElementMapToReplace
			{
				get
				{
					return oPQZrQesHSiPbqjQhNQbzlqXRwas;
				}
				set
				{
					if (!rhsvRaeSufnVAGDlTQvpFfxzqwGG())
					{
						oPQZrQesHSiPbqjQhNQbzlqXRwas = value;
					}
				}
			}

			public AxisRange actionRange
			{
				get
				{
					return eOXCPTgJBBFYsjXqXvoidIJhVsYq;
				}
				set
				{
					if (!rhsvRaeSufnVAGDlTQvpFfxzqwGG())
					{
						eOXCPTgJBBFYsjXqXvoidIJhVsYq = value;
					}
				}
			}

			public Context()
			{
			}

			private Context(Context P_0)
				: this()
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("source");
				}
				Copy(P_0, this);
			}

			public Context Clone()
			{
				return new Context(this);
			}

			internal void TiIAOxdGmoidnqDqaXqAMkZhbrdb()
			{
				hYqudYRnvGbxyHelsFVMBgEhckkGB = true;
			}

			private bool rhsvRaeSufnVAGDlTQvpFfxzqwGG()
			{
				if (hYqudYRnvGbxyHelsFVMBgEhckkGB)
				{
					Logger.LogError("Context is read-only and cannot be modified after Input Mapper has been started.");
					return true;
				}
				return false;
			}

			public static void Copy(Context source, Context destination)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				if (destination == null)
				{
					throw new ArgumentNullException("destination");
				}
				destination.RWeEyPfmepzVbhyYYkVIHzKCOiYKA = source.RWeEyPfmepzVbhyYYkVIHzKCOiYKA;
				destination.oJXgqROYTBEREkAxBMpgqfAHvFbn = source.oJXgqROYTBEREkAxBMpgqfAHvFbn;
				destination.oPQZrQesHSiPbqjQhNQbzlqXRwas = source.oPQZrQesHSiPbqjQhNQbzlqXRwas;
				destination.eOXCPTgJBBFYsjXqXvoidIJhVsYq = source.eOXCPTgJBBFYsjXqXvoidIJhVsYq;
			}
		}

		public enum ConflictResponse
		{
			Cancel = 0,
			Replace = 1,
			Add = 2,
			Ignore = 3,
			Swap = 4
		}

		public abstract class EventData
		{
			public readonly InputMapper inputMapper;

			internal EventData(InputMapper P_0)
			{
				inputMapper = P_0;
			}
		}

		public class InputMappedEventData : EventData
		{
			public readonly ActionElementMap actionElementMap;

			internal InputMappedEventData(InputMapper P_0, ActionElementMap P_1)
				: base(P_0)
			{
				actionElementMap = P_1;
			}
		}

		public class CanceledEventData : EventData
		{
			public readonly string message;

			internal CanceledEventData(InputMapper P_0, string P_1)
				: base(P_0)
			{
				message = P_1;
			}
		}

		public class ErrorEventData : EventData
		{
			public readonly string message;

			internal ErrorEventData(InputMapper P_0, string P_1)
				: base(P_0)
			{
				message = P_1;
			}
		}

		public class TimedOutEventData : EventData
		{
			internal TimedOutEventData(InputMapper P_0)
				: base(P_0)
			{
			}
		}

		public class StartedEventData : EventData
		{
			internal StartedEventData(InputMapper P_0)
				: base(P_0)
			{
			}
		}

		public class StoppedEventData : EventData
		{
			internal StoppedEventData(InputMapper P_0)
				: base(P_0)
			{
			}
		}

		public class ConflictFoundEventData : EventData
		{
			public readonly Action<ConflictResponse> responseCallback;

			public readonly ElementAssignmentInfo assignment;

			public readonly IList<ElementAssignmentConflictInfo> conflicts;

			public readonly bool isProtected;

			private readonly Func<int, bool> zGbwtMyJaRMjcCVEUGFaFwjqzuJh;

			public bool IsSwapAllowed(int maxInputFieldCount)
			{
				if (zGbwtMyJaRMjcCVEUGFaFwjqzuJh == null)
				{
					return false;
				}
				return zGbwtMyJaRMjcCVEUGFaFwjqzuJh(maxInputFieldCount);
			}

			internal ConflictFoundEventData(InputMapper P_0, Action<ConflictResponse> P_1, ElementAssignmentInfo P_2, IList<ElementAssignmentConflictInfo> P_3, bool P_4, Func<int, bool> P_5)
				: base(P_0)
			{
				responseCallback = P_1;
				assignment = P_2;
				conflicts = P_3;
				isProtected = P_4;
				zGbwtMyJaRMjcCVEUGFaFwjqzuJh = P_5;
			}
		}

		private enum nrSVreaeUUSzJfsiPQxGqFPknUyV
		{
			InputMapped = 0,
			Error = 1,
			Canceled = 2,
			TimedOut = 3,
			Started = 4,
			Stopped = 5,
			ConflictsFound = 6
		}

		public enum Status
		{
			Idle = 0,
			Listening = 1,
			AwaitingResponse = 2
		}

		private class CLQBOvyQdWcTKJsrEGowMZqttyFDA
		{
			private enum RQePePStVgEPOGVlzbbEopVBdBTGA
			{
				Quit = 0,
				Continue = 1
			}

			private enum fOKKhvLtkhAIjviISgVVHDcqbFLn
			{
				None = 0,
				ConflictChecking = 1
			}

			private class cyfGBylubRQloNlaULFMYrSAZUQB
			{
				private Player wDZDYBbWozZaOoqjqoLEIOqHEEsLc;

				private int TXLvficldtWJjqDcNMHXrJTOfhhs;

				private Context mwYniXRAqtVZgrxqYpdVeTpVStBU;

				private ControllerType AprFONDQsEmRYDOoABKYDiCSCNAjB;

				private int YhDjvAMNhZiEqkaaGJbgEQDhqNYPA;

				private ControllerPollingInfo elfISRqPGJaMheqjjJiizafDIvjq;

				private ModifierKeyFlags fDfKaAZaOHXSfaWbiNbuDCEBJavl;

				public Player SCvYJjPkVNKUfEygyVjdReeGUVtU => wDZDYBbWozZaOoqjqoLEIOqHEEsLc;

				public int doWovnxVvgcqUqfkVMnvirOypyrN => TXLvficldtWJjqDcNMHXrJTOfhhs;

				public Context yUvKsIuCzYeVNewOgtaQgsehnYpp => mwYniXRAqtVZgrxqYpdVeTpVStBU;

				public ControllerType PmTmfyWTPXEquBqunjlRGAXjEeQB => AprFONDQsEmRYDOoABKYDiCSCNAjB;

				public int TRjEUyrnWQCXeHopElGJOkFkMKQIb => YhDjvAMNhZiEqkaaGJbgEQDhqNYPA;

				public ControllerPollingInfo fDDqhZMjmnFMyegGgvaffqcutdZRA => elfISRqPGJaMheqjjJiizafDIvjq;

				public ModifierKeyFlags yDOeozCtaKZsCXFLcdqZajlbmQRab => fDfKaAZaOHXSfaWbiNbuDCEBJavl;

				public AxisRange gbyEsfrCVsvevyCOIaDYAyokeAEnA
				{
					get
					{
						AxisRange result = AxisRange.Positive;
						if (fDDqhZMjmnFMyegGgvaffqcutdZRA.elementType == ControllerElementType.Axis)
						{
							result = ((mwYniXRAqtVZgrxqYpdVeTpVStBU.actionRange != AxisRange.Full) ? ((fDDqhZMjmnFMyegGgvaffqcutdZRA.axisPole == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative) : AxisRange.Full);
						}
						return result;
					}
				}

				public string rklGFeBqmENxXJcMODLUCySPMOHw
				{
					get
					{
						if (PmTmfyWTPXEquBqunjlRGAXjEeQB == ControllerType.Keyboard && yDOeozCtaKZsCXFLcdqZajlbmQRab != ModifierKeyFlags.None)
						{
							return $"{Keyboard.ModifierKeyFlagsToString(yDOeozCtaKZsCXFLcdqZajlbmQRab)} + {fDDqhZMjmnFMyegGgvaffqcutdZRA.elementIdentifierName}";
						}
						string text = fDDqhZMjmnFMyegGgvaffqcutdZRA.elementIdentifierName;
						if (fDDqhZMjmnFMyegGgvaffqcutdZRA.elementType == ControllerElementType.Axis)
						{
							if (gbyEsfrCVsvevyCOIaDYAyokeAEnA == AxisRange.Positive)
							{
								text += " +";
							}
							else if (gbyEsfrCVsvevyCOIaDYAyokeAEnA == AxisRange.Negative)
							{
								text += " -";
							}
						}
						return text;
					}
				}

				public void YotynBVNufrnGaMJCqqxTOBmGxaM(Player P_0, Context P_1)
				{
					if (P_1.controllerMap == null)
					{
						throw new ArgumentNullException("controllerMap");
					}
					JaWxfpUIWIgHbMianebmiLhbDCaab();
					wDZDYBbWozZaOoqjqoLEIOqHEEsLc = P_0;
					TXLvficldtWJjqDcNMHXrJTOfhhs = P_1.actionId;
					AprFONDQsEmRYDOoABKYDiCSCNAjB = P_1.controllerMap.controllerType;
					YhDjvAMNhZiEqkaaGJbgEQDhqNYPA = P_1.controllerMap.controllerId;
					mwYniXRAqtVZgrxqYpdVeTpVStBU = P_1;
					AprFONDQsEmRYDOoABKYDiCSCNAjB = P_1.controllerMap.controllerType;
					YhDjvAMNhZiEqkaaGJbgEQDhqNYPA = P_1.controllerMap.controllerId;
					P_1.TiIAOxdGmoidnqDqaXqAMkZhbrdb();
				}

				public void JaWxfpUIWIgHbMianebmiLhbDCaab()
				{
					wDZDYBbWozZaOoqjqoLEIOqHEEsLc = null;
					TXLvficldtWJjqDcNMHXrJTOfhhs = -1;
					mwYniXRAqtVZgrxqYpdVeTpVStBU = null;
					AprFONDQsEmRYDOoABKYDiCSCNAjB = ControllerType.Keyboard;
					YhDjvAMNhZiEqkaaGJbgEQDhqNYPA = -1;
					elfISRqPGJaMheqjjJiizafDIvjq = default(ControllerPollingInfo);
					fDfKaAZaOHXSfaWbiNbuDCEBJavl = ModifierKeyFlags.None;
				}

				public ElementAssignment YwBAFcgdMXGcEECWOOcNbOllQagyA(ControllerPollingInfo P_0)
				{
					elfISRqPGJaMheqjjJiizafDIvjq = P_0;
					return TuIBOqWnbliuZGJsLQmEQSIeumkm();
				}

				public ElementAssignment gyArLGRMPqzBaQzrgEuihCAlhZkU(ControllerPollingInfo P_0, ModifierKeyFlags P_1)
				{
					elfISRqPGJaMheqjjJiizafDIvjq = P_0;
					fDfKaAZaOHXSfaWbiNbuDCEBJavl = P_1;
					return TuIBOqWnbliuZGJsLQmEQSIeumkm();
				}

				public ElementAssignment TuIBOqWnbliuZGJsLQmEQSIeumkm()
				{
					return new ElementAssignment(PmTmfyWTPXEquBqunjlRGAXjEeQB, elfISRqPGJaMheqjjJiizafDIvjq.elementType, elfISRqPGJaMheqjjJiizafDIvjq.elementIdentifierId, gbyEsfrCVsvevyCOIaDYAyokeAEnA, elfISRqPGJaMheqjjJiizafDIvjq.keyboardKey, fDfKaAZaOHXSfaWbiNbuDCEBJavl, TXLvficldtWJjqDcNMHXrJTOfhhs, (mwYniXRAqtVZgrxqYpdVeTpVStBU.actionRange == AxisRange.Negative) ? Pole.Negative : Pole.Positive, false, (mwYniXRAqtVZgrxqYpdVeTpVStBU.actionElementMapToReplace != null) ? mwYniXRAqtVZgrxqYpdVeTpVStBU.actionElementMapToReplace.id : (-1));
				}
			}

			private sealed class XKJzqLxuJqFFjQkSGJyyLYkeBdzy
			{
				public ActionElementMap vSZSYXhxAziGrVHuCCVaaudgbTtSA;

				internal bool ofTcesIVSlIBHmTWmABjScUAmXqE(ElementAssignmentConflictInfo P_0)
				{
					return P_0.elementMapId == vSZSYXhxAziGrVHuCCVaaudgbTtSA.id;
				}
			}

			private sealed class udnBDLfXYiBmmADAfMWOPsozTcKFb
			{
				public CLQBOvyQdWcTKJsrEGowMZqttyFDA QlTnFWppfzaMsddeVTOcIGRmhEomA;

				public ElementAssignmentInfo FEaOjFtObABUcrSfaeODrYHIDQiW;

				public IList<ElementAssignmentConflictInfo> PQjEvwnjroPjtrbrlUiRITDbEBlw;

				public bool nRkrXrxOttUKYtCoSOwHJsmPBuxF;

				internal bool ebGMJOwVTKLxQEtkegWNrrrmRHms(int P_0)
				{
					return QlTnFWppfzaMsddeVTOcIGRmhEomA.qrPlmJWIqDpqfWnQDEiKMNXtgqQkA(FEaOjFtObABUcrSfaeODrYHIDQiW, PQjEvwnjroPjtrbrlUiRITDbEBlw, nRkrXrxOttUKYtCoSOwHJsmPBuxF, P_0);
				}
			}

			private readonly InputMapper uiPFTaJClFCsRghrESQWJSLFjCskb;

			private readonly Options dfWjJxosMBgCJfxUEdrLYjXgQkakA = new Options();

			private readonly cyfGBylubRQloNlaULFMYrSAZUQB MelkSqgARHXcmLenCgGtTvMvaWuQ = new cyfGBylubRQloNlaULFMYrSAZUQB();

			private readonly Dictionary<nrSVreaeUUSzJfsiPQxGqFPknUyV, SafeDelegate> fzBywmunucopsdkWcJJYnYuFdBuP;

			private Status SyrGcZVRDZEzIeCgFZHjJxfPbncAb;

			private fOKKhvLtkhAIjviISgVVHDcqbFLn JmbPZTHjcwFLipLsZjHuOnHbCMzcA;

			private double ipqpIEXLsPYjNZeACLgEboyMEscS;

			private bool ElybFAGFdFiFuQCTJAmukQSgDLcgb;

			private List<Player> OkWbpEECLFRNmqnDVhObdWFyaAHI = new List<Player>();

			private readonly List<ControllerPollingInfo> MeZwlxHwyLqseftRiXnKCVAxdoTH = new List<ControllerPollingInfo>();

			private ElementAssignment PHFSyYhJDFViGLMgauGXBPgHdiAC;

			public Status pnwPahDBmJYvfZJBlkMIizmCExkD => SyrGcZVRDZEzIeCgFZHjJxfPbncAb;

			public float wkquWJciZEdfFloEzbeiOXESTJSX
			{
				get
				{
					if (SyrGcZVRDZEzIeCgFZHjJxfPbncAb == Status.Idle)
					{
						return 0f;
					}
					if (dfWjJxosMBgCJfxUEdrLYjXgQkakA.timeout <= 0f)
					{
						return 0f;
					}
					return (float)MathTools.Max(0.0, ipqpIEXLsPYjNZeACLgEboyMEscS + (double)dfWjJxosMBgCJfxUEdrLYjXgQkakA.timeout - ReInput.unscaledTime);
				}
			}

			public Context XSgJhspEneEznaYpOQoEgLjAMZsFA
			{
				get
				{
					if (SyrGcZVRDZEzIeCgFZHjJxfPbncAb == Status.Idle)
					{
						return null;
					}
					return MelkSqgARHXcmLenCgGtTvMvaWuQ.yUvKsIuCzYeVNewOgtaQgsehnYpp;
				}
			}

			private bool ymtHXvWlRhXlEmeCUAPUjDFuEegCA
			{
				get
				{
					if (ElybFAGFdFiFuQCTJAmukQSgDLcgb)
					{
						return false;
					}
					return dfWjJxosMBgCJfxUEdrLYjXgQkakA.timeout > 0f;
				}
			}

			public CLQBOvyQdWcTKJsrEGowMZqttyFDA(InputMapper P_0, Dictionary<nrSVreaeUUSzJfsiPQxGqFPknUyV, SafeDelegate> P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("events");
				}
				uiPFTaJClFCsRghrESQWJSLFjCskb = P_0;
				fzBywmunucopsdkWcJJYnYuFdBuP = P_1;
				xkbchgZsJRkRygOEwSQCqukEnQS();
			}

			protected virtual void kiOUrqEPRUOoRKHaSArDznoiCBXG()
			{
				try
				{
					mQZBCPqCpPGhuVyYSxqHJOZGSIMC();
				}
				finally
				{
					base.Finalize();
				}
			}

			public void XDbmXTtukATurUGuSvvZBqYOrrmG(Context P_0, Options P_1)
			{
				if (SyrGcZVRDZEzIeCgFZHjJxfPbncAb != Status.Idle)
				{
					jcgpiQBpNUereiAMZjpSDDscnGXN("User started a new listening session.");
				}
				if (P_0 == null)
				{
					throw new ArgumentNullException("context");
				}
				if (P_0.controllerMap == null)
				{
					throw new ArgumentNullException("controllerMap");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("options");
				}
				P_0 = P_0.Clone();
				Options.Copy(P_1, dfWjJxosMBgCJfxUEdrLYjXgQkakA);
				Player player = ReInput.players.GetPlayer(P_0.controllerMap.playerId);
				if (ReInput.mapping.GetAction(P_0.actionId) == null)
				{
					NZxSBrdjEXLemnlETfplKmWumWkk("No Action found for actionId: " + P_0.actionId);
					return;
				}
				MelkSqgARHXcmLenCgGtTvMvaWuQ.YotynBVNufrnGaMJCqqxTOBmGxaM(player, P_0);
				SyrGcZVRDZEzIeCgFZHjJxfPbncAb = Status.Listening;
				qKkjCVOEgRGXzbSNLUNnFMNQCzmA();
				OVADeSSVXhFpcHzdrQzWsNVpzpyJA();
				uRDVMkYjnsmnbqXjyJBwzMTTStYW();
				bDeiRlJGLjHzHlELVCsLsWDpdngZ();
			}

			public void srhQyEyhqfZpGOakSimQXwFDSIWG(string P_0)
			{
				if (SyrGcZVRDZEzIeCgFZHjJxfPbncAb != Status.Idle)
				{
					jcgpiQBpNUereiAMZjpSDDscnGXN(P_0);
				}
			}

			private void YwziZpUxUaaWxOfpjXmdNDlBgDNS(UpdateLoopType P_0)
			{
				if (P_0 == UpdateLoopType.Update && SyrGcZVRDZEzIeCgFZHjJxfPbncAb == Status.Listening)
				{
					ElementAssignment elementAssignment;
					if (ymtHXvWlRhXlEmeCUAPUjDFuEegCA && wkquWJciZEdfFloEzbeiOXESTJSX <= 0f)
					{
						YhnNFuoycpIhUqXVlnXaNcltDHab();
					}
					else if (ReInput.controllers.GetController(MelkSqgARHXcmLenCgGtTvMvaWuQ.PmTmfyWTPXEquBqunjlRGAXjEeQB, MelkSqgARHXcmLenCgGtTvMvaWuQ.TRjEUyrnWQCXeHopElGJOkFkMKQIb) == null)
					{
						NZxSBrdjEXLemnlETfplKmWumWkk("Controller not found for type: " + MelkSqgARHXcmLenCgGtTvMvaWuQ.PmTmfyWTPXEquBqunjlRGAXjEeQB.ToString() + " id: " + MelkSqgARHXcmLenCgGtTvMvaWuQ.TRjEUyrnWQCXeHopElGJOkFkMKQIb);
					}
					else if (qwEatyNbdtvzsWIbryNARCiCqoQB(out elementAssignment) != RQePePStVgEPOGVlzbbEopVBdBTGA.Quit && oofeXWPUxhDrafzCbcgdufccSQfz(elementAssignment) != RQePePStVgEPOGVlzbbEopVBdBTGA.Quit)
					{
						XnynshPIPKxmLKRuXRnMGdCtgxOO(elementAssignment);
					}
				}
			}

			private void lHaFcUZdvWMLZxrxbYyAxlRCxHCI()
			{
				if (SyrGcZVRDZEzIeCgFZHjJxfPbncAb != Status.Idle)
				{
					xkbchgZsJRkRygOEwSQCqukEnQS();
					mQZBCPqCpPGhuVyYSxqHJOZGSIMC();
					DZPmDJzjYEzMvAWDLSEFIwyIOJjb();
				}
			}

			private void xkbchgZsJRkRygOEwSQCqukEnQS()
			{
				SyrGcZVRDZEzIeCgFZHjJxfPbncAb = Status.Idle;
				ipqpIEXLsPYjNZeACLgEboyMEscS = 0.0;
				dfWjJxosMBgCJfxUEdrLYjXgQkakA.RxSBYHDsNZGKGxsOUYefEPpDbEhGb();
				MelkSqgARHXcmLenCgGtTvMvaWuQ.JaWxfpUIWIgHbMianebmiLhbDCaab();
				PHFSyYhJDFViGLMgauGXBPgHdiAC = default(ElementAssignment);
				JmbPZTHjcwFLipLsZjHuOnHbCMzcA = fOKKhvLtkhAIjviISgVVHDcqbFLn.None;
				ElybFAGFdFiFuQCTJAmukQSgDLcgb = false;
				OkWbpEECLFRNmqnDVhObdWFyaAHI.Clear();
			}

			private RQePePStVgEPOGVlzbbEopVBdBTGA qwEatyNbdtvzsWIbryNARCiCqoQB(out ElementAssignment P_0)
			{
				if (!lMvzQmZkcTICyJtiOGhRHDAQEedP(out var enumerable, out var modifierKeyFlags))
				{
					P_0 = default(ElementAssignment);
					return RQePePStVgEPOGVlzbbEopVBdBTGA.Quit;
				}
				ControllerPollingInfo controllerPollingInfo = default(ControllerPollingInfo);
				foreach (ControllerPollingInfo item in enumerable)
				{
					if (item.success && !ZLEXChDlmZGkwcgDrrClJjMbvebZ(item, dfWjJxosMBgCJfxUEdrLYjXgQkakA))
					{
						controllerPollingInfo = item;
						break;
					}
				}
				if (!controllerPollingInfo.success)
				{
					P_0 = default(ElementAssignment);
					return RQePePStVgEPOGVlzbbEopVBdBTGA.Quit;
				}
				if (!eOoNkojXtFsIJvcamnCPeeujHHVQ(MelkSqgARHXcmLenCgGtTvMvaWuQ, controllerPollingInfo, dfWjJxosMBgCJfxUEdrLYjXgQkakA))
				{
					P_0 = default(ElementAssignment);
					return RQePePStVgEPOGVlzbbEopVBdBTGA.Quit;
				}
				P_0 = MelkSqgARHXcmLenCgGtTvMvaWuQ.YwBAFcgdMXGcEECWOOcNbOllQagyA(controllerPollingInfo);
				P_0.modifierKeyFlags = modifierKeyFlags;
				return RQePePStVgEPOGVlzbbEopVBdBTGA.Continue;
			}

			private bool lMvzQmZkcTICyJtiOGhRHDAQEedP(out IEnumerable<ControllerPollingInfo> P_0, out ModifierKeyFlags P_1)
			{
				P_1 = ModifierKeyFlags.None;
				ControllerType controllerType = MelkSqgARHXcmLenCgGtTvMvaWuQ.PmTmfyWTPXEquBqunjlRGAXjEeQB;
				int controllerId = MelkSqgARHXcmLenCgGtTvMvaWuQ.TRjEUyrnWQCXeHopElGJOkFkMKQIb;
				if (controllerType == ControllerType.Keyboard)
				{
					P_0 = RKTgjecooXqinKwREbaEbwRhHWRxA(out P_1);
					return true;
				}
				if (dfWjJxosMBgCJfxUEdrLYjXgQkakA.allowAxes)
				{
					if (dfWjJxosMBgCJfxUEdrLYjXgQkakA.allowButtons)
					{
						if (MelkSqgARHXcmLenCgGtTvMvaWuQ.SCvYJjPkVNKUfEygyVjdReeGUVtU != null)
						{
							P_0 = MelkSqgARHXcmLenCgGtTvMvaWuQ.SCvYJjPkVNKUfEygyVjdReeGUVtU.controllers.polling.PollControllerForAllElementsDown(controllerType, controllerId);
						}
						else
						{
							P_0 = ReInput.controllers.polling.PollControllerForAllElementsDown(MelkSqgARHXcmLenCgGtTvMvaWuQ.PmTmfyWTPXEquBqunjlRGAXjEeQB, MelkSqgARHXcmLenCgGtTvMvaWuQ.TRjEUyrnWQCXeHopElGJOkFkMKQIb);
						}
					}
					else if (MelkSqgARHXcmLenCgGtTvMvaWuQ.SCvYJjPkVNKUfEygyVjdReeGUVtU != null)
					{
						P_0 = MelkSqgARHXcmLenCgGtTvMvaWuQ.SCvYJjPkVNKUfEygyVjdReeGUVtU.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
					}
				}
				else
				{
					if (!dfWjJxosMBgCJfxUEdrLYjXgQkakA.allowButtons)
					{
						NZxSBrdjEXLemnlETfplKmWumWkk("You must enable listening for at least one element type.");
						P_0 = null;
						return false;
					}
					if (MelkSqgARHXcmLenCgGtTvMvaWuQ.SCvYJjPkVNKUfEygyVjdReeGUVtU != null)
					{
						P_0 = MelkSqgARHXcmLenCgGtTvMvaWuQ.SCvYJjPkVNKUfEygyVjdReeGUVtU.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
					}
				}
				return true;
			}

			private IEnumerable<ControllerPollingInfo> RKTgjecooXqinKwREbaEbwRhHWRxA(out ModifierKeyFlags P_0)
			{
				P_0 = ModifierKeyFlags.None;
				MeZwlxHwyLqseftRiXnKCVAxdoTH.Clear();
				if (!dfWjJxosMBgCJfxUEdrLYjXgQkakA.allowButtons)
				{
					return MeZwlxHwyLqseftRiXnKCVAxdoTH;
				}
				MeZwlxHwyLqseftRiXnKCVAxdoTH.Add(BPGdaiBbQpvtcJpfqHvDRRUglsMN(dfWjJxosMBgCJfxUEdrLYjXgQkakA, out P_0));
				return MeZwlxHwyLqseftRiXnKCVAxdoTH;
			}

			private ControllerPollingInfo BPGdaiBbQpvtcJpfqHvDRRUglsMN(Options P_0, out ModifierKeyFlags P_1)
			{
				bool flag;
				string text;
				ControllerPollingInfo result = RcvGitdjikvRhdxmAcSoxQSzyIFk(P_0, out flag, out P_1, out text);
				if (flag)
				{
					qKkjCVOEgRGXzbSNLUNnFMNQCzmA();
				}
				return result;
			}

			private static ControllerPollingInfo RcvGitdjikvRhdxmAcSoxQSzyIFk(Options P_0, out bool P_1, out ModifierKeyFlags P_2, out string P_3)
			{
				P_3 = string.Empty;
				P_1 = false;
				P_2 = ModifierKeyFlags.None;
				int num = 0;
				ControllerPollingInfo result = default(ControllerPollingInfo);
				ControllerPollingInfo result2 = default(ControllerPollingInfo);
				ModifierKeyFlags modifierKeyFlags = ModifierKeyFlags.None;
				foreach (ControllerPollingInfo item in ReInput.controllers.Keyboard.PollForAllKeys())
				{
					KeyboardKeyCode keyboardKey = item.keyboardKey;
					if (keyboardKey == KeyboardKeyCode.AltGr)
					{
						continue;
					}
					if (Keyboard.IsModifierKey(item.keyboardKey))
					{
						if (num == 0)
						{
							result2 = item;
						}
						modifierKeyFlags |= Keyboard.KeyCodeToModifierKeyFlags(keyboardKey);
						num++;
					}
					else if (result.keyboardKey == KeyboardKeyCode.None)
					{
						result = item;
					}
				}
				if (result.keyboardKey != KeyboardKeyCode.None)
				{
					if (!ReInput.controllers.Keyboard.GetKeyDown(result.keyboardKey))
					{
						return default(ControllerPollingInfo);
					}
					if (num == 0 || !P_0.allowKeyboardKeysWithModifiers)
					{
						return result;
					}
					P_2 = modifierKeyFlags;
					return result;
				}
				if (num > 0)
				{
					P_1 = true;
					if (num == 1)
					{
						if (P_0.allowKeyboardModifierKeyAsPrimary)
						{
							if (!P_0.allowKeyboardKeysWithModifiers || P_0.holdDurationToMapKeyboardModifierKeyAsPrimary <= 0f)
							{
								if (!ReInput.controllers.Keyboard.GetKeyDown(result2.keyboardKey))
								{
									return default(ControllerPollingInfo);
								}
								return result2;
							}
							if (ReInput.controllers.Keyboard.GetKeyTimePressed(result2.keyboardKey) >= (double)P_0.holdDurationToMapKeyboardModifierKeyAsPrimary)
							{
								return result2;
							}
						}
						P_3 = Keyboard.GetKeyName(result2.keyboardKey);
					}
					else
					{
						P_3 = Keyboard.ModifierKeyFlagsToString(modifierKeyFlags, getShortName: false);
					}
				}
				return default(ControllerPollingInfo);
			}

			private static bool ZLEXChDlmZGkwcgDrrClJjMbvebZ(ControllerPollingInfo P_0, Options P_1)
			{
				if (!P_1.allowAxes && P_0.elementType == ControllerElementType.Axis)
				{
					return false;
				}
				if (!P_1.allowButtons && P_0.elementType == ControllerElementType.Button)
				{
					return false;
				}
				if (P_0.controllerType == ControllerType.Mouse && P_0.elementType == ControllerElementType.Axis)
				{
					switch (P_0.elementIndex)
					{
					case 0:
						if (P_1.ignoreMouseXAxis)
						{
							return true;
						}
						break;
					case 1:
						if (P_1.ignoreMouseYAxis)
						{
							return true;
						}
						break;
					}
				}
				SafePredicate<ControllerPollingInfo> safePredicate = P_1.YoHTALYSsSCoWEZrLqbQXQgMeyoS<SafePredicate<ControllerPollingInfo>>("isElementAllowed");
				if (safePredicate != null)
				{
					return !safePredicate.Invoke(P_0);
				}
				return false;
			}

			private static bool eOoNkojXtFsIJvcamnCPeeujHHVQ(cyfGBylubRQloNlaULFMYrSAZUQB P_0, ControllerPollingInfo P_1, Options P_2)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (P_2 == null)
				{
					return true;
				}
				if (P_0.gbyEsfrCVsvevyCOIaDYAyokeAEnA == AxisRange.Full && !P_2.allowButtonsOnFullAxisAssignment && P_1.elementType == ControllerElementType.Button)
				{
					return false;
				}
				return true;
			}

			private void OVADeSSVXhFpcHzdrQzWsNVpzpyJA()
			{
				if (!dfWjJxosMBgCJfxUEdrLYjXgQkakA.checkForConflicts)
				{
					return;
				}
				if (dfWjJxosMBgCJfxUEdrLYjXgQkakA.checkForConflictsWithSelf && MelkSqgARHXcmLenCgGtTvMvaWuQ.SCvYJjPkVNKUfEygyVjdReeGUVtU != null)
				{
					ListTools.AddIfUnique(OkWbpEECLFRNmqnDVhObdWFyaAHI, MelkSqgARHXcmLenCgGtTvMvaWuQ.SCvYJjPkVNKUfEygyVjdReeGUVtU);
				}
				if (dfWjJxosMBgCJfxUEdrLYjXgQkakA.checkForConflictsWithSystemPlayer)
				{
					ListTools.AddIfUnique(OkWbpEECLFRNmqnDVhObdWFyaAHI, ReInput.players.SystemPlayer);
				}
				if (dfWjJxosMBgCJfxUEdrLYjXgQkakA.checkForConflictsWithAllPlayers)
				{
					IList<Player> players = ReInput.players.Players;
					for (int i = 0; i < players.Count; i++)
					{
						ListTools.AddIfUnique(OkWbpEECLFRNmqnDVhObdWFyaAHI, players[i]);
					}
				}
				else
				{
					if (dfWjJxosMBgCJfxUEdrLYjXgQkakA.checkForConflictsWithPlayerIds == null)
					{
						return;
					}
					IList<Player> allPlayers = ReInput.players.AllPlayers;
					int count = allPlayers.Count;
					for (int j = 0; j < count; j++)
					{
						if (ArrayTools.Contains(dfWjJxosMBgCJfxUEdrLYjXgQkakA.checkForConflictsWithPlayerIds, allPlayers[j].id))
						{
							ListTools.AddIfUnique(OkWbpEECLFRNmqnDVhObdWFyaAHI, allPlayers[j]);
						}
					}
				}
			}

			private RQePePStVgEPOGVlzbbEopVBdBTGA oofeXWPUxhDrafzCbcgdufccSQfz(ElementAssignment P_0)
			{
				if (dfWjJxosMBgCJfxUEdrLYjXgQkakA.checkForConflicts && MelkSqgARHXcmLenCgGtTvMvaWuQ.SCvYJjPkVNKUfEygyVjdReeGUVtU != null && PfijIVbnhSCpKxuuNNDQckeCkiSGc(MelkSqgARHXcmLenCgGtTvMvaWuQ, P_0, OkWbpEECLFRNmqnDVhObdWFyaAHI))
				{
					return ewjOicXOpHyYxsYqIvxtJNXWrcBO(P_0);
				}
				return RQePePStVgEPOGVlzbbEopVBdBTGA.Continue;
			}

			private static bool PfijIVbnhSCpKxuuNNDQckeCkiSGc(cyfGBylubRQloNlaULFMYrSAZUQB P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.SCvYJjPkVNKUfEygyVjdReeGUVtU == null)
				{
					return false;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return false;
				}
				if (!JRCDSztmPUAnATMVMkailkRJWzPt(P_0, P_1, out var conflictCheck))
				{
					return false;
				}
				for (int i = 0; i < P_2.Count; i++)
				{
					if (P_2[i].controllers.conflictChecking.DoesElementAssignmentConflict(conflictCheck))
					{
						return true;
					}
				}
				return false;
			}

			private static bool uxfyhYybAdxEunlXyBhohYaWWAiFA(cyfGBylubRQloNlaULFMYrSAZUQB P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.SCvYJjPkVNKUfEygyVjdReeGUVtU == null)
				{
					return false;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return false;
				}
				if (!JRCDSztmPUAnATMVMkailkRJWzPt(P_0, P_1, out var conflictCheck))
				{
					return false;
				}
				for (int i = 0; i < P_2.Count; i++)
				{
					foreach (ElementAssignmentConflictInfo item in P_2[i].controllers.conflictChecking.ElementAssignmentConflicts(conflictCheck))
					{
						if (!item.isUserAssignable)
						{
							return true;
						}
					}
				}
				return false;
			}

			private static IList<ElementAssignmentConflictInfo> MVyakgGuQAeTVdWGDueqZFnfdPASb(cyfGBylubRQloNlaULFMYrSAZUQB P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.SCvYJjPkVNKUfEygyVjdReeGUVtU == null)
				{
					return null;
				}
				if (P_2 == null || P_2.Count == 0)
				{
					return null;
				}
				if (!JRCDSztmPUAnATMVMkailkRJWzPt(P_0, P_1, out var conflictCheck))
				{
					return null;
				}
				List<ElementAssignmentConflictInfo> list = new List<ElementAssignmentConflictInfo>();
				for (int i = 0; i < P_2.Count; i++)
				{
					foreach (ElementAssignmentConflictInfo item in P_2[i].controllers.conflictChecking.ElementAssignmentConflicts(conflictCheck))
					{
						list.Add(item);
					}
				}
				return list;
			}

			private static bool JRCDSztmPUAnATMVMkailkRJWzPt(cyfGBylubRQloNlaULFMYrSAZUQB P_0, ElementAssignment P_1, out ElementAssignmentConflictCheck P_2)
			{
				Player player;
				if (P_0 == null || (player = P_0.SCvYJjPkVNKUfEygyVjdReeGUVtU) == null)
				{
					P_2 = default(ElementAssignmentConflictCheck);
					return false;
				}
				P_2 = P_1.ToElementAssignmentConflictCheck();
				P_2.playerId = player.id;
				P_2.controllerType = P_0.PmTmfyWTPXEquBqunjlRGAXjEeQB;
				P_2.controllerId = P_0.TRjEUyrnWQCXeHopElGJOkFkMKQIb;
				P_2.controllerMapId = P_0.yUvKsIuCzYeVNewOgtaQgsehnYpp.controllerMap.id;
				P_2.controllerMapCategoryId = P_0.yUvKsIuCzYeVNewOgtaQgsehnYpp.controllerMap.categoryId;
				if (P_0.yUvKsIuCzYeVNewOgtaQgsehnYpp.actionElementMapToReplace != null)
				{
					P_2.elementMapId = P_0.yUvKsIuCzYeVNewOgtaQgsehnYpp.actionElementMapToReplace.id;
				}
				return true;
			}

			private static void TDrvvQNfCbeRFCztVzHYzkfwSiOB(cyfGBylubRQloNlaULFMYrSAZUQB P_0, ElementAssignment P_1, List<Player> P_2)
			{
				if (P_0 == null || P_0.SCvYJjPkVNKUfEygyVjdReeGUVtU == null)
				{
					return;
				}
				if (!JRCDSztmPUAnATMVMkailkRJWzPt(P_0, P_1, out var conflictCheck))
				{
					Logger.LogError("Error creating conflict check!");
					return;
				}
				for (int i = 0; i < P_2.Count; i++)
				{
					P_2[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(conflictCheck);
				}
			}

			private void uRDVMkYjnsmnbqXjyJBwzMTTStYW()
			{
				ReInput.UpdateEndedEvent -= YwziZpUxUaaWxOfpjXmdNDlBgDNS;
				ReInput.UpdateEndedEvent += YwziZpUxUaaWxOfpjXmdNDlBgDNS;
			}

			private void mQZBCPqCpPGhuVyYSxqHJOZGSIMC()
			{
				ReInput.UpdateEndedEvent -= YwziZpUxUaaWxOfpjXmdNDlBgDNS;
			}

			private bool MVhvGNRosWSrsyLHwXWhUYbwaCyq(nrSVreaeUUSzJfsiPQxGqFPknUyV P_0)
			{
				SafeDelegate safeDelegate = fzBywmunucopsdkWcJJYnYuFdBuP[P_0];
				if (safeDelegate != null)
				{
					return safeDelegate.Count > 0;
				}
				return false;
			}

			private void jMFTsTLBnKfgSgQxjFSmetNKsftqc<_0001>(nrSVreaeUUSzJfsiPQxGqFPknUyV P_0, _0001 P_1)
			{
				SafeAction<_0001> safeAction = (SafeAction<_0001>)fzBywmunucopsdkWcJJYnYuFdBuP[P_0];
				if (safeAction.Count != 0)
				{
					safeAction.Invoke(P_1);
				}
			}

			private void qKkjCVOEgRGXzbSNLUNnFMNQCzmA()
			{
				ipqpIEXLsPYjNZeACLgEboyMEscS = ReInput.unscaledTime;
			}

			private void yEuQnddYdeVVsJmTMqaaeYDjecME()
			{
				ElybFAGFdFiFuQCTJAmukQSgDLcgb = true;
			}

			private bool qrPlmJWIqDpqfWnQDEiKMNXtgqQkA(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2, int P_3)
			{
				if (P_3 < 0)
				{
					P_3 = 0;
				}
				if (P_0 == null || P_1 == null)
				{
					return false;
				}
				if (P_2)
				{
					return false;
				}
				ActionElementMap elementMap = P_0.elementMap;
				if (elementMap == null)
				{
					return false;
				}
				List<ElementAssignmentConflictInfo> list = new List<ElementAssignmentConflictInfo>();
				for (int i = 0; i < P_1.Count; i++)
				{
					if (P_1[i].playerId == P_0.player.id)
					{
						list.Add(P_1[i]);
					}
				}
				if (list.Count > 1)
				{
					return false;
				}
				ElementAssignmentConflictInfo elementAssignmentConflictInfo = list[0];
				if (elementAssignmentConflictInfo.elementMap == null)
				{
					return false;
				}
				if (!elementAssignmentConflictInfo.isConflict)
				{
					return false;
				}
				if (elementAssignmentConflictInfo.playerId != P_0.player.id)
				{
					return false;
				}
				int actionId = elementAssignmentConflictInfo.elementMap.actionId;
				Pole axisContribution = elementAssignmentConflictInfo.elementMap.axisContribution;
				AxisRange axisRange = elementMap.axisRange;
				ControllerElementType elementType = elementMap.elementType;
				if (elementType == elementAssignmentConflictInfo.elementMap.elementType && elementType == ControllerElementType.Axis)
				{
					if (axisRange != elementAssignmentConflictInfo.elementMap.axisRange)
					{
						if (axisRange == AxisRange.Full)
						{
							axisRange = AxisRange.Positive;
						}
						else if (elementAssignmentConflictInfo.elementMap.axisRange != AxisRange.Full)
						{
						}
					}
				}
				else if (elementType == ControllerElementType.Axis && (elementAssignmentConflictInfo.elementMap.elementType == ControllerElementType.Button || (elementAssignmentConflictInfo.elementMap.elementType == ControllerElementType.Axis && elementAssignmentConflictInfo.elementMap.axisRange != AxisRange.Full)) && axisRange == AxisRange.Full)
				{
					axisRange = AxisRange.Positive;
				}
				int num = 0;
				if (P_0.action.id == elementAssignmentConflictInfo.actionId && P_0.controllerMap == elementAssignmentConflictInfo.controllerMap)
				{
					Controller controller = ReInput.controllers.GetController(P_0.controllerType, P_0.controllerId);
					if (kLeLDqRPVHCShEjWibqgWNzmoPqSA(elementType, axisRange, axisContribution, controller.GetElementById(P_0.elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid).type, P_0.axisRange, P_0.axisContribution))
					{
						num++;
					}
				}
				using (IEnumerator<ActionElementMap> enumerator = elementAssignmentConflictInfo.controllerMap.ElementMapsWithAction(actionId).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						XKJzqLxuJqFFjQkSGJyyLYkeBdzy xKJzqLxuJqFFjQkSGJyyLYkeBdzy = new XKJzqLxuJqFFjQkSGJyyLYkeBdzy();
						xKJzqLxuJqFFjQkSGJyyLYkeBdzy.vSZSYXhxAziGrVHuCCVaaudgbTtSA = enumerator.Current;
						if (xKJzqLxuJqFFjQkSGJyyLYkeBdzy.vSZSYXhxAziGrVHuCCVaaudgbTtSA.id != elementMap.id && ListTools.FindIndex(list, xKJzqLxuJqFFjQkSGJyyLYkeBdzy.ofTcesIVSlIBHmTWmABjScUAmXqE) < 0 && kLeLDqRPVHCShEjWibqgWNzmoPqSA(elementType, axisRange, axisContribution, xKJzqLxuJqFFjQkSGJyyLYkeBdzy.vSZSYXhxAziGrVHuCCVaaudgbTtSA.elementType, xKJzqLxuJqFFjQkSGJyyLYkeBdzy.vSZSYXhxAziGrVHuCCVaaudgbTtSA.axisRange, xKJzqLxuJqFFjQkSGJyyLYkeBdzy.vSZSYXhxAziGrVHuCCVaaudgbTtSA.axisContribution))
						{
							num++;
						}
					}
				}
				return num < P_3;
			}

			private bool GNXJYhUIFFITlVeskGjKADRTBeKHb(cyfGBylubRQloNlaULFMYrSAZUQB P_0, ElementAssignment P_1, bool P_2, out string P_3)
			{
				if (P_0 == null)
				{
					P_3 = "Mapping is null reference.";
					return false;
				}
				List<Player> list = new List<Player> { P_0.SCvYJjPkVNKUfEygyVjdReeGUVtU };
				IList<ElementAssignmentConflictInfo> list2 = MVyakgGuQAeTVdWGDueqZFnfdPASb(P_0, P_1, list);
				int count = list2.Count;
				if (count == 0)
				{
					P_3 = "Swap was canceled because no conflicts were found.";
					return false;
				}
				if (count > 1)
				{
					P_3 = "Swap was canceled because more than one conflict was found.";
					return false;
				}
				if (P_2)
				{
					P_3 = "Swap was canceled due to a protected conflict that cannot be replaced.";
					return false;
				}
				if (P_0.yUvKsIuCzYeVNewOgtaQgsehnYpp.actionElementMapToReplace == null)
				{
					P_3 = "Swap was canceled because this is not a replacement assignment.";
					return false;
				}
				ElementAssignmentConflictInfo elementAssignmentConflictInfo = list2[0];
				if (!elementAssignmentConflictInfo.isConflict)
				{
					P_3 = "Swap was canceled because conflict was invalid.";
					return false;
				}
				ActionElementMap actionElementMap = new ActionElementMap(elementAssignmentConflictInfo.elementMap);
				if (actionElementMap == null)
				{
					P_3 = "Swap was canceled because conflict ActionElementMap was null.";
					return false;
				}
				ActionElementMap actionElementMap2 = new ActionElementMap(P_0.yUvKsIuCzYeVNewOgtaQgsehnYpp.actionElementMapToReplace);
				TDrvvQNfCbeRFCztVzHYzkfwSiOB(P_0, P_1, list);
				int actionId = actionElementMap.actionId;
				Pole axisContribution = actionElementMap.axisContribution;
				bool invert = actionElementMap.invert;
				AxisRange axisRange = actionElementMap2.axisRange;
				ControllerElementType elementType = actionElementMap2.elementType;
				int elementIdentifierId = actionElementMap2.elementIdentifierId;
				KeyboardKeyCode keyCode = actionElementMap2.keyCode;
				ModifierKeyFlags modifierKeyFlags = actionElementMap2.modifierKeyFlags;
				if (elementType == actionElementMap.elementType && elementType == ControllerElementType.Axis)
				{
					if (axisRange != actionElementMap.axisRange)
					{
						if (axisRange == AxisRange.Full)
						{
							axisRange = AxisRange.Positive;
						}
						else if (actionElementMap.axisRange != AxisRange.Full)
						{
						}
					}
				}
				else if (elementType == ControllerElementType.Axis && (actionElementMap.elementType == ControllerElementType.Button || (actionElementMap.elementType == ControllerElementType.Axis && actionElementMap.axisRange != AxisRange.Full)) && axisRange == AxisRange.Full)
				{
					axisRange = AxisRange.Positive;
				}
				if (elementType != ControllerElementType.Axis || axisRange != AxisRange.Full)
				{
					invert = false;
				}
				elementAssignmentConflictInfo.controllerMap.ReplaceOrCreateElementMap(ElementAssignment.CompleteAssignment(P_0.PmTmfyWTPXEquBqunjlRGAXjEeQB, elementType, elementIdentifierId, axisRange, keyCode, modifierKeyFlags, actionId, axisContribution, invert));
				P_3 = null;
				return true;
			}

			private static bool kLeLDqRPVHCShEjWibqgWNzmoPqSA(ControllerElementType P_0, AxisRange P_1, Pole P_2, ControllerElementType P_3, AxisRange P_4, Pole P_5)
			{
				if ((P_0 == ControllerElementType.Button || (P_0 == ControllerElementType.Axis && P_1 != AxisRange.Full)) && (P_3 == ControllerElementType.Button || (P_3 == ControllerElementType.Axis && P_4 != AxisRange.Full)) && P_5 == P_2)
				{
					return true;
				}
				if (P_0 == ControllerElementType.Axis && P_1 == AxisRange.Full && P_3 == ControllerElementType.Axis && P_4 == AxisRange.Full)
				{
					return true;
				}
				return false;
			}

			private void sEwFQEPegkfUWungdKdrhGxPwMmN(ActionElementMap P_0)
			{
				AtmyyUKyFAcWrYUVvRCGsoFgypBi(P_0);
				lHaFcUZdvWMLZxrxbYyAxlRCxHCI();
			}

			private void jcgpiQBpNUereiAMZjpSDDscnGXN(string P_0)
			{
				tURGcocReyqTJcZVewXoXyYFIuSxb(P_0);
				lHaFcUZdvWMLZxrxbYyAxlRCxHCI();
			}

			private RQePePStVgEPOGVlzbbEopVBdBTGA ewjOicXOpHyYxsYqIvxtJNXWrcBO(ElementAssignment P_0)
			{
				if (MVhvGNRosWSrsyLHwXWhUYbwaCyq(nrSVreaeUUSzJfsiPQxGqFPknUyV.ConflictsFound))
				{
					bool flag = uxfyhYybAdxEunlXyBhohYaWWAiFA(MelkSqgARHXcmLenCgGtTvMvaWuQ, P_0, OkWbpEECLFRNmqnDVhObdWFyaAHI);
					PHFSyYhJDFViGLMgauGXBPgHdiAC = P_0;
					IList<ElementAssignmentConflictInfo> list = MVyakgGuQAeTVdWGDueqZFnfdPASb(MelkSqgARHXcmLenCgGtTvMvaWuQ, P_0, OkWbpEECLFRNmqnDVhObdWFyaAHI);
					JmbPZTHjcwFLipLsZjHuOnHbCMzcA = fOKKhvLtkhAIjviISgVVHDcqbFLn.ConflictChecking;
					bzePWpGRVIplSOcuAxrIifesdvdZ();
					WzbspFeaXraiXbnGJICLGkoMRyYuA(new ElementAssignmentInfo(MelkSqgARHXcmLenCgGtTvMvaWuQ.yUvKsIuCzYeVNewOgtaQgsehnYpp.controllerMap, P_0), list, flag);
					return RQePePStVgEPOGVlzbbEopVBdBTGA.Quit;
				}
				return TqyPwOfrkmtnhsBhWkNfXRaAfuQh(dfWjJxosMBgCJfxUEdrLYjXgQkakA.defaultActionWhenConflictFound, P_0);
			}

			private RQePePStVgEPOGVlzbbEopVBdBTGA TqyPwOfrkmtnhsBhWkNfXRaAfuQh(ConflictResponse P_0, ElementAssignment P_1)
			{
				return dPOIvnsJyCFnODsKfktOQALFUDo(P_0, P_1, uxfyhYybAdxEunlXyBhohYaWWAiFA(MelkSqgARHXcmLenCgGtTvMvaWuQ, P_1, OkWbpEECLFRNmqnDVhObdWFyaAHI));
			}

			private RQePePStVgEPOGVlzbbEopVBdBTGA dPOIvnsJyCFnODsKfktOQALFUDo(ConflictResponse P_0, ElementAssignment P_1, bool P_2)
			{
				switch (P_0)
				{
				case ConflictResponse.Cancel:
					jcgpiQBpNUereiAMZjpSDDscnGXN("Mapping assignment was canceled due to a conflict.");
					return RQePePStVgEPOGVlzbbEopVBdBTGA.Quit;
				case ConflictResponse.Replace:
					if (P_2)
					{
						jcgpiQBpNUereiAMZjpSDDscnGXN("Mapping assignment was canceled due to a protected conflict that cannot be replaced.");
						return RQePePStVgEPOGVlzbbEopVBdBTGA.Quit;
					}
					TDrvvQNfCbeRFCztVzHYzkfwSiOB(MelkSqgARHXcmLenCgGtTvMvaWuQ, P_1, OkWbpEECLFRNmqnDVhObdWFyaAHI);
					return RQePePStVgEPOGVlzbbEopVBdBTGA.Continue;
				case ConflictResponse.Add:
					return RQePePStVgEPOGVlzbbEopVBdBTGA.Continue;
				case ConflictResponse.Ignore:
					oSBJpUmhwCLjCJXEqKeyPflONXaE();
					return RQePePStVgEPOGVlzbbEopVBdBTGA.Quit;
				case ConflictResponse.Swap:
				{
					if (!GNXJYhUIFFITlVeskGjKADRTBeKHb(MelkSqgARHXcmLenCgGtTvMvaWuQ, P_1, P_2, out var text))
					{
						jcgpiQBpNUereiAMZjpSDDscnGXN(text);
						return RQePePStVgEPOGVlzbbEopVBdBTGA.Quit;
					}
					return RQePePStVgEPOGVlzbbEopVBdBTGA.Continue;
				}
				default:
					throw new NotImplementedException();
				}
			}

			private void YhnNFuoycpIhUqXVlnXaNcltDHab()
			{
				ZDFgiTjNKhLjJAGhzAukODHBCcwl();
				lHaFcUZdvWMLZxrxbYyAxlRCxHCI();
			}

			private void NZxSBrdjEXLemnlETfplKmWumWkk(string P_0)
			{
				IJyNSVNBvlJOxgPRnAYmenfUodrIb(P_0);
				lHaFcUZdvWMLZxrxbYyAxlRCxHCI();
			}

			private void bzePWpGRVIplSOcuAxrIifesdvdZ()
			{
				yEuQnddYdeVVsJmTMqaaeYDjecME();
				mQZBCPqCpPGhuVyYSxqHJOZGSIMC();
				SyrGcZVRDZEzIeCgFZHjJxfPbncAb = Status.AwaitingResponse;
			}

			private void oSBJpUmhwCLjCJXEqKeyPflONXaE()
			{
				SyrGcZVRDZEzIeCgFZHjJxfPbncAb = Status.Listening;
				JmbPZTHjcwFLipLsZjHuOnHbCMzcA = fOKKhvLtkhAIjviISgVVHDcqbFLn.None;
				qKkjCVOEgRGXzbSNLUNnFMNQCzmA();
				uRDVMkYjnsmnbqXjyJBwzMTTStYW();
			}

			private void XnynshPIPKxmLKRuXRnMGdCtgxOO(ElementAssignment P_0)
			{
				if (MelkSqgARHXcmLenCgGtTvMvaWuQ.yUvKsIuCzYeVNewOgtaQgsehnYpp.controllerMap.ReplaceOrCreateElementMap(P_0, out var result))
				{
					sEwFQEPegkfUWungdKdrhGxPwMmN(result);
				}
				else
				{
					NZxSBrdjEXLemnlETfplKmWumWkk("Failed to create element assignment.");
				}
			}

			private void AtmyyUKyFAcWrYUVvRCGsoFgypBi(ActionElementMap P_0)
			{
				if (MVhvGNRosWSrsyLHwXWhUYbwaCyq(nrSVreaeUUSzJfsiPQxGqFPknUyV.InputMapped))
				{
					jMFTsTLBnKfgSgQxjFSmetNKsftqc(nrSVreaeUUSzJfsiPQxGqFPknUyV.InputMapped, new InputMappedEventData(uiPFTaJClFCsRghrESQWJSLFjCskb, P_0));
				}
			}

			private void ZDFgiTjNKhLjJAGhzAukODHBCcwl()
			{
				if (MVhvGNRosWSrsyLHwXWhUYbwaCyq(nrSVreaeUUSzJfsiPQxGqFPknUyV.TimedOut))
				{
					jMFTsTLBnKfgSgQxjFSmetNKsftqc(nrSVreaeUUSzJfsiPQxGqFPknUyV.TimedOut, new TimedOutEventData(uiPFTaJClFCsRghrESQWJSLFjCskb));
				}
			}

			private void IJyNSVNBvlJOxgPRnAYmenfUodrIb(string P_0)
			{
				if (MVhvGNRosWSrsyLHwXWhUYbwaCyq(nrSVreaeUUSzJfsiPQxGqFPknUyV.Error))
				{
					jMFTsTLBnKfgSgQxjFSmetNKsftqc(nrSVreaeUUSzJfsiPQxGqFPknUyV.Error, new ErrorEventData(uiPFTaJClFCsRghrESQWJSLFjCskb, P_0));
				}
			}

			private void tURGcocReyqTJcZVewXoXyYFIuSxb(string P_0)
			{
				if (MVhvGNRosWSrsyLHwXWhUYbwaCyq(nrSVreaeUUSzJfsiPQxGqFPknUyV.Canceled))
				{
					jMFTsTLBnKfgSgQxjFSmetNKsftqc(nrSVreaeUUSzJfsiPQxGqFPknUyV.Canceled, new CanceledEventData(uiPFTaJClFCsRghrESQWJSLFjCskb, P_0));
				}
			}

			private void WzbspFeaXraiXbnGJICLGkoMRyYuA(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2)
			{
				udnBDLfXYiBmmADAfMWOPsozTcKFb udnBDLfXYiBmmADAfMWOPsozTcKFb2 = new udnBDLfXYiBmmADAfMWOPsozTcKFb();
				udnBDLfXYiBmmADAfMWOPsozTcKFb2.QlTnFWppfzaMsddeVTOcIGRmhEomA = this;
				udnBDLfXYiBmmADAfMWOPsozTcKFb2.FEaOjFtObABUcrSfaeODrYHIDQiW = P_0;
				udnBDLfXYiBmmADAfMWOPsozTcKFb2.PQjEvwnjroPjtrbrlUiRITDbEBlw = P_1;
				udnBDLfXYiBmmADAfMWOPsozTcKFb2.nRkrXrxOttUKYtCoSOwHJsmPBuxF = P_2;
				if (MVhvGNRosWSrsyLHwXWhUYbwaCyq(nrSVreaeUUSzJfsiPQxGqFPknUyV.ConflictsFound))
				{
					jMFTsTLBnKfgSgQxjFSmetNKsftqc(nrSVreaeUUSzJfsiPQxGqFPknUyV.ConflictsFound, new ConflictFoundEventData(uiPFTaJClFCsRghrESQWJSLFjCskb, jQVFQsVFXoAwDBMtIghoMNMfhXti, udnBDLfXYiBmmADAfMWOPsozTcKFb2.FEaOjFtObABUcrSfaeODrYHIDQiW, udnBDLfXYiBmmADAfMWOPsozTcKFb2.PQjEvwnjroPjtrbrlUiRITDbEBlw, udnBDLfXYiBmmADAfMWOPsozTcKFb2.nRkrXrxOttUKYtCoSOwHJsmPBuxF, udnBDLfXYiBmmADAfMWOPsozTcKFb2.ebGMJOwVTKLxQEtkegWNrrrmRHms));
				}
			}

			private void bDeiRlJGLjHzHlELVCsLsWDpdngZ()
			{
				if (MVhvGNRosWSrsyLHwXWhUYbwaCyq(nrSVreaeUUSzJfsiPQxGqFPknUyV.Started))
				{
					jMFTsTLBnKfgSgQxjFSmetNKsftqc(nrSVreaeUUSzJfsiPQxGqFPknUyV.Started, new StartedEventData(uiPFTaJClFCsRghrESQWJSLFjCskb));
				}
			}

			private void DZPmDJzjYEzMvAWDLSEFIwyIOJjb()
			{
				if (MVhvGNRosWSrsyLHwXWhUYbwaCyq(nrSVreaeUUSzJfsiPQxGqFPknUyV.Stopped))
				{
					jMFTsTLBnKfgSgQxjFSmetNKsftqc(nrSVreaeUUSzJfsiPQxGqFPknUyV.Stopped, new StoppedEventData(uiPFTaJClFCsRghrESQWJSLFjCskb));
				}
			}

			public void jQVFQsVFXoAwDBMtIghoMNMfhXti(ConflictResponse P_0)
			{
				if (SyrGcZVRDZEzIeCgFZHjJxfPbncAb != Status.AwaitingResponse || JmbPZTHjcwFLipLsZjHuOnHbCMzcA != fOKKhvLtkhAIjviISgVVHDcqbFLn.ConflictChecking)
				{
					Logger.LogWarning("The Mapping Listener was not waiting for a conflict checking response. The response will be ignored.");
					return;
				}
				try
				{
					if (TqyPwOfrkmtnhsBhWkNfXRaAfuQh(P_0, PHFSyYhJDFViGLMgauGXBPgHdiAC) == RQePePStVgEPOGVlzbbEopVBdBTGA.Continue)
					{
						XnynshPIPKxmLKRuXRnMGdCtgxOO(PHFSyYhJDFViGLMgauGXBPgHdiAC);
					}
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred in the conflict check user response callback.\n" + ex);
				}
			}
		}

		public class Options
		{
			[Serializable]
			private sealed class CTEDThCjuRbPJoBSQBCQEzanAmbS
			{
				public static readonly CTEDThCjuRbPJoBSQBCQEzanAmbS _003C_003E9 = new CTEDThCjuRbPJoBSQBCQEzanAmbS();

				public static Action<Exception> _003C_003E9__64_0;

				internal void KAhlXWgGSaqmumDHGACuhJicligEb(Exception P_0)
				{
					ReInput.HandleCallbackException("InputMapper.Options.isElementAllowedCallback", P_0);
				}
			}

			private bool UVAGGbkjMpfSVVWgvhXOplVIlfiHb = true;

			private bool FSBBQiKyfEKTzATqefwzbpqEkZlyB = true;

			private bool rjcXgczCIdTMoSSCOSjqHnlGsnlJ = true;

			private float OSlhPqtMTTdLnejPnBAcFXcbdqJh;

			private bool sHsUCGqziAVgxDHxLcBlkgmRqGCr = true;

			private bool kXJfkmOcVJgjnfhHFBKzXAYixHoOA = true;

			private bool nQIMQWfeUrJfwVXENrwXysKzeeYv = true;

			private bool RYJjNBXFHuXizREDPKwNJDfYgrOU = true;

			private int[] yYEBPHusJySUXRgQcsUjWeWCZXDP;

			private ConflictResponse KqorhxBNYMrZLTROQQPxUqIjDpUH = ConflictResponse.Replace;

			private bool SWHkTJuUTmeTxIOhkdHAhVpArhyeA;

			private bool YaLIxEmgRgaRlCpnPqQtoGfTGwTG;

			private bool lNcKNgopIMoOkicInjlFBYsQYYtp = true;

			private bool mJzUSNcnvopAADRDDwpjgdPMoMql = true;

			private float uCUnaGybtGknvqDmyCuJENgWzXBC = 1f;

			internal const string fxvIMwQynGnSogCAbztWyNDmSaQr = "isElementAllowed";

			private readonly Dictionary<string, SafeDelegate> xMEZxYdTUdBOhzmKjaEkKgPaCfWGA = new Dictionary<string, SafeDelegate> { { "isElementAllowed", null } };

			public bool allowAxes
			{
				get
				{
					return UVAGGbkjMpfSVVWgvhXOplVIlfiHb;
				}
				set
				{
					UVAGGbkjMpfSVVWgvhXOplVIlfiHb = value;
				}
			}

			public bool allowButtons
			{
				get
				{
					return FSBBQiKyfEKTzATqefwzbpqEkZlyB;
				}
				set
				{
					FSBBQiKyfEKTzATqefwzbpqEkZlyB = value;
				}
			}

			public bool allowButtonsOnFullAxisAssignment
			{
				get
				{
					return rjcXgczCIdTMoSSCOSjqHnlGsnlJ;
				}
				set
				{
					rjcXgczCIdTMoSSCOSjqHnlGsnlJ = value;
				}
			}

			public float timeout
			{
				get
				{
					return OSlhPqtMTTdLnejPnBAcFXcbdqJh;
				}
				set
				{
					OSlhPqtMTTdLnejPnBAcFXcbdqJh = MathTools.Max(0f, value);
				}
			}

			public bool checkForConflicts
			{
				get
				{
					return sHsUCGqziAVgxDHxLcBlkgmRqGCr;
				}
				set
				{
					sHsUCGqziAVgxDHxLcBlkgmRqGCr = value;
				}
			}

			public bool checkForConflictsWithAllPlayers
			{
				get
				{
					return kXJfkmOcVJgjnfhHFBKzXAYixHoOA;
				}
				set
				{
					kXJfkmOcVJgjnfhHFBKzXAYixHoOA = value;
				}
			}

			public bool checkForConflictsWithSelf
			{
				get
				{
					return nQIMQWfeUrJfwVXENrwXysKzeeYv;
				}
				set
				{
					nQIMQWfeUrJfwVXENrwXysKzeeYv = value;
				}
			}

			public bool checkForConflictsWithSystemPlayer
			{
				get
				{
					return RYJjNBXFHuXizREDPKwNJDfYgrOU;
				}
				set
				{
					RYJjNBXFHuXizREDPKwNJDfYgrOU = value;
				}
			}

			public int[] checkForConflictsWithPlayerIds
			{
				get
				{
					return yYEBPHusJySUXRgQcsUjWeWCZXDP;
				}
				set
				{
					yYEBPHusJySUXRgQcsUjWeWCZXDP = value;
				}
			}

			public ConflictResponse defaultActionWhenConflictFound
			{
				get
				{
					return KqorhxBNYMrZLTROQQPxUqIjDpUH;
				}
				set
				{
					KqorhxBNYMrZLTROQQPxUqIjDpUH = value;
				}
			}

			public bool ignoreMouseXAxis
			{
				get
				{
					return SWHkTJuUTmeTxIOhkdHAhVpArhyeA;
				}
				set
				{
					SWHkTJuUTmeTxIOhkdHAhVpArhyeA = value;
				}
			}

			public bool ignoreMouseYAxis
			{
				get
				{
					return YaLIxEmgRgaRlCpnPqQtoGfTGwTG;
				}
				set
				{
					YaLIxEmgRgaRlCpnPqQtoGfTGwTG = value;
				}
			}

			public bool allowKeyboardKeysWithModifiers
			{
				get
				{
					return lNcKNgopIMoOkicInjlFBYsQYYtp;
				}
				set
				{
					lNcKNgopIMoOkicInjlFBYsQYYtp = value;
				}
			}

			public bool allowKeyboardModifierKeyAsPrimary
			{
				get
				{
					return mJzUSNcnvopAADRDDwpjgdPMoMql;
				}
				set
				{
					mJzUSNcnvopAADRDDwpjgdPMoMql = value;
				}
			}

			public float holdDurationToMapKeyboardModifierKeyAsPrimary
			{
				get
				{
					return uCUnaGybtGknvqDmyCuJENgWzXBC;
				}
				set
				{
					uCUnaGybtGknvqDmyCuJENgWzXBC = MathTools.Max(0f, value);
				}
			}

			public Predicate<ControllerPollingInfo> isElementAllowedCallback
			{
				get
				{
					return (SafePredicate<ControllerPollingInfo>)xMEZxYdTUdBOhzmKjaEkKgPaCfWGA["isElementAllowed"];
				}
				set
				{
					SafePredicate<ControllerPollingInfo> safePredicate = value;
					if (safePredicate != null)
					{
						safePredicate.ExceptionHandler = CTEDThCjuRbPJoBSQBCQEzanAmbS._003C_003E9.KAhlXWgGSaqmumDHGACuhJicligEb;
					}
					xMEZxYdTUdBOhzmKjaEkKgPaCfWGA["isElementAllowed"] = safePredicate;
				}
			}

			internal _0001 YoHTALYSsSCoWEZrLqbQXQgMeyoS<_0001>(string P_0) where _0001 : SafeDelegate
			{
				if (!xMEZxYdTUdBOhzmKjaEkKgPaCfWGA.TryGetValue(P_0, out var value))
				{
					return null;
				}
				return value as _0001;
			}

			public Options()
			{
				RxSBYHDsNZGKGxsOUYefEPpDbEhGb();
			}

			private Options(Options P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("source");
				}
				Copy(P_0, this);
			}

			public Options Clone()
			{
				return new Options(this);
			}

			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("Options:\n");
				stringBuilder.Append("allowAxes = " + UVAGGbkjMpfSVVWgvhXOplVIlfiHb + "\n");
				stringBuilder.Append("allowButtons = " + FSBBQiKyfEKTzATqefwzbpqEkZlyB + "\n");
				stringBuilder.Append("allowButtonsOnFullAxisAssignment = " + rjcXgczCIdTMoSSCOSjqHnlGsnlJ + "\n");
				stringBuilder.Append("timeout = " + OSlhPqtMTTdLnejPnBAcFXcbdqJh + "\n");
				stringBuilder.Append("checkForConflicts = " + sHsUCGqziAVgxDHxLcBlkgmRqGCr + "\n");
				stringBuilder.Append("checkForConflictsWithAllPlayers = " + kXJfkmOcVJgjnfhHFBKzXAYixHoOA + "\n");
				stringBuilder.Append("checkForConflictsWithSelf = " + nQIMQWfeUrJfwVXENrwXysKzeeYv + "\n");
				stringBuilder.Append("checkForConflictsWithSystemPlayer = " + RYJjNBXFHuXizREDPKwNJDfYgrOU + "\n");
				if (yYEBPHusJySUXRgQcsUjWeWCZXDP == null)
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = null\n");
				}
				else
				{
					stringBuilder.Append("_checkForConflictsWithPlayerIds = " + StringTools.ToString(yYEBPHusJySUXRgQcsUjWeWCZXDP) + "\n");
				}
				stringBuilder.Append("defaultActionWhenConflictFound = " + KqorhxBNYMrZLTROQQPxUqIjDpUH.ToString() + "\n");
				stringBuilder.Append("ignoreMouseXAxis = " + SWHkTJuUTmeTxIOhkdHAhVpArhyeA);
				stringBuilder.Append("ignoreMouseYAxis = " + YaLIxEmgRgaRlCpnPqQtoGfTGwTG);
				stringBuilder.Append("allowKeyboardKeysWithModifiers = " + lNcKNgopIMoOkicInjlFBYsQYYtp + "\n");
				stringBuilder.Append("allowKeyboardModifierAsPrimary = " + mJzUSNcnvopAADRDDwpjgdPMoMql + "\n");
				stringBuilder.Append("holdDurationToMapKeyboardModifierKeyAsPrimary = " + uCUnaGybtGknvqDmyCuJENgWzXBC + "\n");
				return stringBuilder.ToString();
			}

			internal void RxSBYHDsNZGKGxsOUYefEPpDbEhGb()
			{
				UVAGGbkjMpfSVVWgvhXOplVIlfiHb = true;
				FSBBQiKyfEKTzATqefwzbpqEkZlyB = true;
				rjcXgczCIdTMoSSCOSjqHnlGsnlJ = true;
				OSlhPqtMTTdLnejPnBAcFXcbdqJh = 0f;
				sHsUCGqziAVgxDHxLcBlkgmRqGCr = true;
				kXJfkmOcVJgjnfhHFBKzXAYixHoOA = true;
				nQIMQWfeUrJfwVXENrwXysKzeeYv = true;
				RYJjNBXFHuXizREDPKwNJDfYgrOU = true;
				yYEBPHusJySUXRgQcsUjWeWCZXDP = null;
				KqorhxBNYMrZLTROQQPxUqIjDpUH = ConflictResponse.Replace;
				SWHkTJuUTmeTxIOhkdHAhVpArhyeA = false;
				YaLIxEmgRgaRlCpnPqQtoGfTGwTG = false;
				lNcKNgopIMoOkicInjlFBYsQYYtp = true;
				mJzUSNcnvopAADRDDwpjgdPMoMql = true;
				uCUnaGybtGknvqDmyCuJENgWzXBC = 1f;
				foreach (string item in new List<string>(xMEZxYdTUdBOhzmKjaEkKgPaCfWGA.Keys))
				{
					xMEZxYdTUdBOhzmKjaEkKgPaCfWGA[item] = null;
				}
			}

			public static void Copy(Options source, Options destination)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				if (destination == null)
				{
					throw new ArgumentNullException("destination");
				}
				destination.UVAGGbkjMpfSVVWgvhXOplVIlfiHb = source.UVAGGbkjMpfSVVWgvhXOplVIlfiHb;
				destination.FSBBQiKyfEKTzATqefwzbpqEkZlyB = source.FSBBQiKyfEKTzATqefwzbpqEkZlyB;
				destination.rjcXgczCIdTMoSSCOSjqHnlGsnlJ = source.rjcXgczCIdTMoSSCOSjqHnlGsnlJ;
				destination.OSlhPqtMTTdLnejPnBAcFXcbdqJh = source.OSlhPqtMTTdLnejPnBAcFXcbdqJh;
				destination.sHsUCGqziAVgxDHxLcBlkgmRqGCr = source.sHsUCGqziAVgxDHxLcBlkgmRqGCr;
				destination.kXJfkmOcVJgjnfhHFBKzXAYixHoOA = source.kXJfkmOcVJgjnfhHFBKzXAYixHoOA;
				destination.nQIMQWfeUrJfwVXENrwXysKzeeYv = source.nQIMQWfeUrJfwVXENrwXysKzeeYv;
				destination.RYJjNBXFHuXizREDPKwNJDfYgrOU = source.RYJjNBXFHuXizREDPKwNJDfYgrOU;
				destination.yYEBPHusJySUXRgQcsUjWeWCZXDP = ArrayTools.ShallowCopy(source.yYEBPHusJySUXRgQcsUjWeWCZXDP);
				destination.KqorhxBNYMrZLTROQQPxUqIjDpUH = source.KqorhxBNYMrZLTROQQPxUqIjDpUH;
				destination.SWHkTJuUTmeTxIOhkdHAhVpArhyeA = source.SWHkTJuUTmeTxIOhkdHAhVpArhyeA;
				destination.YaLIxEmgRgaRlCpnPqQtoGfTGwTG = source.YaLIxEmgRgaRlCpnPqQtoGfTGwTG;
				destination.lNcKNgopIMoOkicInjlFBYsQYYtp = source.lNcKNgopIMoOkicInjlFBYsQYYtp;
				destination.mJzUSNcnvopAADRDDwpjgdPMoMql = source.mJzUSNcnvopAADRDDwpjgdPMoMql;
				destination.uCUnaGybtGknvqDmyCuJENgWzXBC = source.uCUnaGybtGknvqDmyCuJENgWzXBC;
				foreach (KeyValuePair<string, SafeDelegate> item in source.xMEZxYdTUdBOhzmKjaEkKgPaCfWGA)
				{
					destination.xMEZxYdTUdBOhzmKjaEkKgPaCfWGA[item.Key] = MiscTools.Clone(item.Value);
				}
			}
		}

		[Serializable]
		private sealed class GNgLegpjyrQItRPLnEXxtzvzqPqi
		{
			public static readonly GNgLegpjyrQItRPLnEXxtzvzqPqi _003C_003E9 = new GNgLegpjyrQItRPLnEXxtzvzqPqi();

			public static Action<Exception> _003C_003E9__54_0;

			public static Action<Exception> _003C_003E9__54_1;

			public static Action<Exception> _003C_003E9__54_2;

			public static Action<Exception> _003C_003E9__54_3;

			public static Action<Exception> _003C_003E9__54_4;

			public static Action<Exception> _003C_003E9__54_5;

			public static Action<Exception> _003C_003E9__54_6;

			internal void uPkgqqVfeYSoTinZyfoLmzgQZGFh(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.AssignedEvent", P_0);
			}

			internal void HOeeucFwSshsuOZXuqkQAHmabjIhA(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.ErrorEvent", P_0);
			}

			internal void xgxBVLblAESUvNLzUFYZMjAjkVTOA(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.CanceledEvent", P_0);
			}

			internal void UQziLxVDHtImDDxghRwbtFvSKQGE(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.TimedOutEvent", P_0);
			}

			internal void mdSpKjAALkfQSOaTsAiSgjgatqRQA(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.StartedEvent", P_0);
			}

			internal void pNPWmXJLKSiHagtckwTfnGLXodLgA(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.StoppedEvent", P_0);
			}

			internal void OGFeZGvIqlANiNOUjBeZAgXpaxhoA(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.ConflictFoundEvent", P_0);
			}
		}

		private static InputMapper BTaWnIetblmDvlrMNalgUUyVOBYh;

		private static int vPesbwjkfuRJDdqXKDXwGKJTpPFmA;

		private readonly int OphTQAFFDRiPvHwdplcwPrBbLRpHA;

		private readonly bool AMDErfJNVhbnaaVvMqSGLlqYtInP;

		private readonly CLQBOvyQdWcTKJsrEGowMZqttyFDA axDAhAKikPvbhgCeowWetUjRjTPq;

		private Options gOyOWThmpBHOEsVMFUnLMNZEgaOeA;

		private readonly Dictionary<nrSVreaeUUSzJfsiPQxGqFPknUyV, SafeDelegate> TDUzBAkNxuLngYIUXFVNTxHAEwOo = new Dictionary<nrSVreaeUUSzJfsiPQxGqFPknUyV, SafeDelegate>
		{
			{
				nrSVreaeUUSzJfsiPQxGqFPknUyV.InputMapped,
				new SafeAction<InputMappedEventData>(GNgLegpjyrQItRPLnEXxtzvzqPqi._003C_003E9.uPkgqqVfeYSoTinZyfoLmzgQZGFh)
			},
			{
				nrSVreaeUUSzJfsiPQxGqFPknUyV.Error,
				new SafeAction<ErrorEventData>(GNgLegpjyrQItRPLnEXxtzvzqPqi._003C_003E9.HOeeucFwSshsuOZXuqkQAHmabjIhA)
			},
			{
				nrSVreaeUUSzJfsiPQxGqFPknUyV.Canceled,
				new SafeAction<CanceledEventData>(GNgLegpjyrQItRPLnEXxtzvzqPqi._003C_003E9.xgxBVLblAESUvNLzUFYZMjAjkVTOA)
			},
			{
				nrSVreaeUUSzJfsiPQxGqFPknUyV.TimedOut,
				new SafeAction<TimedOutEventData>(GNgLegpjyrQItRPLnEXxtzvzqPqi._003C_003E9.UQziLxVDHtImDDxghRwbtFvSKQGE)
			},
			{
				nrSVreaeUUSzJfsiPQxGqFPknUyV.Started,
				new SafeAction<StartedEventData>(GNgLegpjyrQItRPLnEXxtzvzqPqi._003C_003E9.mdSpKjAALkfQSOaTsAiSgjgatqRQA)
			},
			{
				nrSVreaeUUSzJfsiPQxGqFPknUyV.Stopped,
				new SafeAction<StoppedEventData>(GNgLegpjyrQItRPLnEXxtzvzqPqi._003C_003E9.pNPWmXJLKSiHagtckwTfnGLXodLgA)
			},
			{
				nrSVreaeUUSzJfsiPQxGqFPknUyV.ConflictsFound,
				new SafeAction<ConflictFoundEventData>(GNgLegpjyrQItRPLnEXxtzvzqPqi._003C_003E9.OGFeZGvIqlANiNOUjBeZAgXpaxhoA)
			}
		};

		public static InputMapper Default => BTaWnIetblmDvlrMNalgUUyVOBYh ?? (BTaWnIetblmDvlrMNalgUUyVOBYh = new InputMapper(true));

		public Options options
		{
			get
			{
				Options obj = gOyOWThmpBHOEsVMFUnLMNZEgaOeA;
				if (obj == null)
				{
					if (!AMDErfJNVhbnaaVvMqSGLlqYtInP)
					{
						return gOyOWThmpBHOEsVMFUnLMNZEgaOeA = Default.options.Clone();
					}
					obj = (gOyOWThmpBHOEsVMFUnLMNZEgaOeA = new Options());
				}
				return obj;
			}
			set
			{
				gOyOWThmpBHOEsVMFUnLMNZEgaOeA = value;
			}
		}

		public Context mappingContext => axDAhAKikPvbhgCeowWetUjRjTPq.XSgJhspEneEznaYpOQoEgLjAMZsFA;

		public Status status => axDAhAKikPvbhgCeowWetUjRjTPq.pnwPahDBmJYvfZJBlkMIizmCExkD;

		public float timeRemaining => axDAhAKikPvbhgCeowWetUjRjTPq.wkquWJciZEdfFloEzbeiOXESTJSX;

		internal int jwNerjccCEbKReoWIUpUqGCHvGHDD => OphTQAFFDRiPvHwdplcwPrBbLRpHA;

		public event Action<InputMappedEventData> InputMappedEvent
		{
			add
			{
				if (value != null)
				{
					nrSVreaeUUSzJfsiPQxGqFPknUyV key = nrSVreaeUUSzJfsiPQxGqFPknUyV.InputMapped;
					TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] = (SafeAction<InputMappedEventData>)TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					nrSVreaeUUSzJfsiPQxGqFPknUyV key = nrSVreaeUUSzJfsiPQxGqFPknUyV.InputMapped;
					TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] = (SafeAction<InputMappedEventData>)TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] - value;
				}
			}
		}

		public event Action<ErrorEventData> ErrorEvent
		{
			add
			{
				if (value != null)
				{
					nrSVreaeUUSzJfsiPQxGqFPknUyV key = nrSVreaeUUSzJfsiPQxGqFPknUyV.Error;
					TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] = (SafeAction<ErrorEventData>)TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					nrSVreaeUUSzJfsiPQxGqFPknUyV key = nrSVreaeUUSzJfsiPQxGqFPknUyV.Error;
					TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] = (SafeAction<ErrorEventData>)TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] - value;
				}
			}
		}

		public event Action<CanceledEventData> CanceledEvent
		{
			add
			{
				if (value != null)
				{
					nrSVreaeUUSzJfsiPQxGqFPknUyV key = nrSVreaeUUSzJfsiPQxGqFPknUyV.Canceled;
					TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] = (SafeAction<CanceledEventData>)TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					nrSVreaeUUSzJfsiPQxGqFPknUyV key = nrSVreaeUUSzJfsiPQxGqFPknUyV.Canceled;
					TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] = (SafeAction<CanceledEventData>)TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] - value;
				}
			}
		}

		public event Action<TimedOutEventData> TimedOutEvent
		{
			add
			{
				if (value != null)
				{
					nrSVreaeUUSzJfsiPQxGqFPknUyV key = nrSVreaeUUSzJfsiPQxGqFPknUyV.TimedOut;
					TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] = (SafeAction<TimedOutEventData>)TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					nrSVreaeUUSzJfsiPQxGqFPknUyV key = nrSVreaeUUSzJfsiPQxGqFPknUyV.TimedOut;
					TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] = (SafeAction<TimedOutEventData>)TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] - value;
				}
			}
		}

		public event Action<StartedEventData> StartedEvent
		{
			add
			{
				if (value != null)
				{
					nrSVreaeUUSzJfsiPQxGqFPknUyV key = nrSVreaeUUSzJfsiPQxGqFPknUyV.Started;
					TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] = (SafeAction<StartedEventData>)TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					nrSVreaeUUSzJfsiPQxGqFPknUyV key = nrSVreaeUUSzJfsiPQxGqFPknUyV.Started;
					TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] = (SafeAction<StartedEventData>)TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] - value;
				}
			}
		}

		public event Action<StoppedEventData> StoppedEvent
		{
			add
			{
				if (value != null)
				{
					nrSVreaeUUSzJfsiPQxGqFPknUyV key = nrSVreaeUUSzJfsiPQxGqFPknUyV.Stopped;
					TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] = (SafeAction<StoppedEventData>)TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					nrSVreaeUUSzJfsiPQxGqFPknUyV key = nrSVreaeUUSzJfsiPQxGqFPknUyV.Stopped;
					TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] = (SafeAction<StoppedEventData>)TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] - value;
				}
			}
		}

		public event Action<ConflictFoundEventData> ConflictFoundEvent
		{
			add
			{
				if (value != null)
				{
					nrSVreaeUUSzJfsiPQxGqFPknUyV key = nrSVreaeUUSzJfsiPQxGqFPknUyV.ConflictsFound;
					TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] = (SafeAction<ConflictFoundEventData>)TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] + value;
				}
			}
			remove
			{
				if (value != null)
				{
					nrSVreaeUUSzJfsiPQxGqFPknUyV key = nrSVreaeUUSzJfsiPQxGqFPknUyV.ConflictsFound;
					TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] = (SafeAction<ConflictFoundEventData>)TDUzBAkNxuLngYIUXFVNTxHAEwOo[key] - value;
				}
			}
		}

		private static int MUmAxJHGaMQrPBIEEjaeeyjQfvhrA()
		{
			int result = vPesbwjkfuRJDdqXKDXwGKJTpPFmA;
			if (vPesbwjkfuRJDdqXKDXwGKJTpPFmA == int.MaxValue)
			{
				vPesbwjkfuRJDdqXKDXwGKJTpPFmA = 0;
				return result;
			}
			vPesbwjkfuRJDdqXKDXwGKJTpPFmA++;
			return result;
		}

		public InputMapper()
			: this(false)
		{
			OphTQAFFDRiPvHwdplcwPrBbLRpHA = MUmAxJHGaMQrPBIEEjaeeyjQfvhrA();
		}

		private InputMapper(bool P_0)
		{
			AMDErfJNVhbnaaVvMqSGLlqYtInP = P_0;
			if (AMDErfJNVhbnaaVvMqSGLlqYtInP)
			{
				gOyOWThmpBHOEsVMFUnLMNZEgaOeA = new Options();
			}
			axDAhAKikPvbhgCeowWetUjRjTPq = new CLQBOvyQdWcTKJsrEGowMZqttyFDA(this, TDUzBAkNxuLngYIUXFVNTxHAEwOo);
		}

		public void RemoveEventListeners(object listenerOrParent)
		{
			if (listenerOrParent == null)
			{
				return;
			}
			foreach (KeyValuePair<nrSVreaeUUSzJfsiPQxGqFPknUyV, SafeDelegate> item in TDUzBAkNxuLngYIUXFVNTxHAEwOo)
			{
				item.Value.RemoveDelegateOrAllDelegatesFromAnObject(listenerOrParent);
			}
		}

		public void RemoveAllEventListeners()
		{
			foreach (KeyValuePair<nrSVreaeUUSzJfsiPQxGqFPknUyV, SafeDelegate> item in TDUzBAkNxuLngYIUXFVNTxHAEwOo)
			{
				item.Value.Clear();
			}
		}

		internal void ZBWVcNFEDULwJVRkZXwHbCjBKXHu(object P_0)
		{
		}

		internal void YmpEGoPLHAbUudhUJMKVXbTOgqGr()
		{
		}

		public bool Start(Context mappingContext)
		{
			return gmDAmaaWmxNdCSXpECAGvknmouIMA(mappingContext, (gOyOWThmpBHOEsVMFUnLMNZEgaOeA != null) ? gOyOWThmpBHOEsVMFUnLMNZEgaOeA : Default.options);
		}

		public void Stop()
		{
			axDAhAKikPvbhgCeowWetUjRjTPq.srhQyEyhqfZpGOakSimQXwFDSIWG("User canceled.");
		}

		public void Clear()
		{
			Stop();
			RemoveAllEventListeners();
			YmpEGoPLHAbUudhUJMKVXbTOgqGr();
			gOyOWThmpBHOEsVMFUnLMNZEgaOeA = null;
		}

		private bool gmDAmaaWmxNdCSXpECAGvknmouIMA(Context P_0, Options P_1)
		{
			if (!ReInput.isReady)
			{
				return false;
			}
			if (P_0 == null)
			{
				Logger.LogError("The Context cannot be null.");
				return false;
			}
			if (P_0.controllerMap == null)
			{
				Logger.LogError("The Controller Map cannot be null.");
				return false;
			}
			if (P_0.actionElementMapToReplace != null && !P_0.controllerMap.ContainsElementMap(P_0.actionElementMapToReplace))
			{
				Logger.LogError("The Action Element Map must belong to the same Controller Map you are passing in.");
				return false;
			}
			try
			{
				axDAhAKikPvbhgCeowWetUjRjTPq.XDbmXTtukATurUGuSvvZBqYOrrmG(P_0, P_1);
				return true;
			}
			catch
			{
				axDAhAKikPvbhgCeowWetUjRjTPq.srhQyEyhqfZpGOakSimQXwFDSIWG("Failed to start due to an exception.");
				return false;
			}
		}
	}
}
