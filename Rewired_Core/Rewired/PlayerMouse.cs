using System;
using System.Collections.Generic;
using Rewired.UI;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public sealed class PlayerMouse : PlayerController, IPlayerMouse, IPlayerController, IMouseInputSource
	{
		public new sealed class Definition : PlayerController.Definition
		{
			public bool defaultToCenter = true;

			public bool clampToMovementArea = true;

			public ScreenRect movementArea = cqYCagaZTNxSoKaLcWDDkKgKtVqv;

			public MovementAreaUnit movementAreaUnit;

			public float pointerSpeed = 1f;

			public bool useHardwarePointerPosition = true;

			internal Definition()
			{
			}
		}

		public new static class Factory
		{
			public static PlayerMouse Create()
			{
				return nAdpzjaDZQKkVinOMPFTtMtYBDtr(3, 3);
			}

			private static PlayerMouse nAdpzjaDZQKkVinOMPFTtMtYBDtr(int P_0, int P_1)
			{
				if (P_0 < 0)
				{
					P_0 = 0;
				}
				if (P_1 < 0)
				{
					P_1 = 0;
				}
				List<Element.Definition> list = new List<Element.Definition>(P_0 + P_1);
				if (P_1 >= 1)
				{
					list.Add(new MouseAxis2D.Definition
					{
						name = "Movement",
						xAxis = new MouseAxis.Definition
						{
							name = "Horizontal"
						},
						yAxis = new MouseAxis.Definition
						{
							name = "Vertical"
						}
					});
				}
				if (P_1 >= 3)
				{
					list.Add(new MouseWheel.Definition
					{
						name = "Wheel",
						xAxis = new MouseWheelAxis.Definition
						{
							name = "Wheel Horizontal"
						},
						yAxis = new MouseWheelAxis.Definition
						{
							name = "Wheel Vertical"
						}
					});
				}
				for (int i = 4; i < P_1; i++)
				{
					list.Add(new Axis.Definition
					{
						coordinateMode = AxisCoordinateMode.Relative
					});
				}
				if (P_0 >= 1)
				{
					list.Add(new Button.Definition
					{
						name = "Left Button"
					});
				}
				if (P_0 >= 2)
				{
					list.Add(new Button.Definition
					{
						name = "Right Button"
					});
				}
				if (P_0 >= 3)
				{
					list.Add(new Button.Definition
					{
						name = "Middle Button"
					});
				}
				for (int j = 3; j < P_0; j++)
				{
					list.Add(new Button.Definition());
				}
				return new PlayerMouse(new Definition
				{
					elements = list
				});
			}

			public static PlayerMouse Create(Definition definition)
			{
				return new PlayerMouse(definition);
			}
		}

		public enum MovementAreaUnit
		{
			Screen = 0,
			Pixel = 1
		}

		[Serializable]
		private sealed class YPLWUwtSVwazlsAhNToZgFvCfzRS
		{
			public static readonly YPLWUwtSVwazlsAhNToZgFvCfzRS _003C_003E9 = new YPLWUwtSVwazlsAhNToZgFvCfzRS();

			public static Predicate<Axis> _003C_003E9__18_0;

			public static Predicate<Axis> _003C_003E9__18_1;

			internal bool GOxRIrDzjcxzGbjxzIRijpBYDSVGA(Axis P_0)
			{
				if ((object)P_0.GetType() == typeof(MouseWheelAxis))
				{
					return !P_0.witGigCupAMPlWQDDorgBZKeIMHA;
				}
				return false;
			}

			internal bool zzEiwrWDLrdaIANWMQyViMdKaMaDA(Axis P_0)
			{
				if ((object)P_0.GetType() == typeof(MouseWheelAxis))
				{
					return !P_0.witGigCupAMPlWQDDorgBZKeIMHA;
				}
				return false;
			}
		}

		internal const bool PzXeexaTjUKSxwEZUfVPTKiqQQkGA = true;

		internal const float yVMPRpeJcbBRXMbQITvigVkQhdQX = 1f;

		internal const bool wGCQqwGkaKqNXthWHFUcWCDsVAiH = true;

		internal const bool MzXwomYihusFZKICPTUHlZAAOhdR = true;

		internal const MovementAreaUnit eQGEePBzcBMhwcMjtJjrFsdApUGtB = MovementAreaUnit.Screen;

		internal static readonly ScreenRect cqYCagaZTNxSoKaLcWDDkKgKtVqv = new ScreenRect(0f, 0f, 1f, 1f);

		private const int vlMcrwDQQyNvnkFhWQyUACBLlUaP = 3;

		private const int IlGCRAgfkOPbbdnqbpIQfcDDumAfB = 3;

		internal const string uyWgTQAnVQHGYsodcTpqOXELAxCGA = "Movement";

		internal const string TpbLVltPODFRPGiISlLkQBOSaGpOA = "Horizontal";

		internal const string tqSGpkpPjflUqzhMYSMNoUqitAJO = "Vertical";

		internal const string HAFESjArVJLIpKfwlAOtBQRmeEGv = "Wheel";

		internal const string gyRRJWpQOtBohwPQvkucESjjVhsF = "Wheel Horizontal";

		internal const string ywxcfGGbWfluAiJCpAefsyFvAEXSA = "Wheel Vertical";

		internal const string isZefvDMTojArLxxODcFTupiFAcCA = "Left Button";

		internal const string LzgFgmxyNnJtGktDmVhmHtwBMgid = "Right Button";

		internal const string GvzjgRZaQNBinMprPUIicgrNiMnd = "Middle Button";

		private readonly int BaJmKmZNIoqpKwAgfBybsHzsdtmiA = -1;

		private readonly int kKSeakBQmxHoxVBFFJlYnfBqWHXi = -1;

		private readonly int nKxnVgOnBUdpCQsPsrkhvEedvzoj = -1;

		private readonly int HwyvhAiehRSBiHDmxFXBaliUCbsD = -1;

		private readonly int TaIBuZwmylflDoJqgAHECbdSqCfz = -1;

		private readonly int levMRhcBXUiUpDdOzBGLVfBFIcFHA = -1;

		private bool CcGcPKEomXECfdTkDYQdolgxRsigB;

		private Vector2 bNdMHdAvntxYfBMMrUaHodPfaXbG;

		private Vector2 wPOlKDIIUeNBvyQxAMsztxuIDlMQ;

		private Vector2 JQaKrnYcCWhZBzPgCTbcPEovDINJ;

		private Vector2 zISdpLQApJdDlzjSLXkvsYAPkKRV;

		private Vector2 tkKrMnFQMJfADxbiTCBVFYVFHYe;

		private float RqdwXpIEzfkQBvKhnPoQDgzNEdmgA;

		private bool dLXNlAgJBbfFdVzHypPBoPxGvSYn;

		private Action<Vector2> jBkUfXhfeycetDYVzLqRlWMfEUOgA;

		private bool FnvQZiHnEUAoHefXjWJMraoFcvYdA;

		private ScreenRect ofIfiTyPCtlLyLqDxcsfYgiHKsTU;

		private bool HEGesIIHzLSqSSeaJYuZGJllMIxcA;

		private MovementAreaUnit ZuqglUXBVNDHrKKkIJBoYfUjEsYfA;

		bool IPlayerMouse.defaultToCenter
		{
			get
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return false;
				}
				return FnvQZiHnEUAoHefXjWJMraoFcvYdA;
			}
			set
			{
				FnvQZiHnEUAoHefXjWJMraoFcvYdA = value;
			}
		}

		public bool clampToMovementArea
		{
			get
			{
				return HEGesIIHzLSqSSeaJYuZGJllMIxcA;
			}
			set
			{
				HEGesIIHzLSqSSeaJYuZGJllMIxcA = value;
			}
		}

		ScreenRect IPlayerMouse.movementArea
		{
			get
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return default(ScreenRect);
				}
				return ofIfiTyPCtlLyLqDxcsfYgiHKsTU;
			}
			set
			{
				ofIfiTyPCtlLyLqDxcsfYgiHKsTU = value;
			}
		}

		MovementAreaUnit IPlayerMouse.movementAreaUnit
		{
			get
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return MovementAreaUnit.Screen;
				}
				return ZuqglUXBVNDHrKKkIJBoYfUjEsYfA;
			}
			set
			{
				ZuqglUXBVNDHrKKkIJBoYfUjEsYfA = value;
			}
		}

		Vector2 IPlayerMouse.screenPosition
		{
			get
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return Vector2.zero;
				}
				if (!base.Rewired_002EIPlayerController_002Eenabled)
				{
					return Vector2.zero;
				}
				return JQaKrnYcCWhZBzPgCTbcPEovDINJ;
			}
			set
			{
				ZMfkAfoCtvlaEExavSValPKyhxjGA(value);
			}
		}

		Vector2 IPlayerMouse.screenPositionPrev
		{
			get
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return Vector2.zero;
				}
				if (!base.Rewired_002EIPlayerController_002Eenabled)
				{
					return Vector2.zero;
				}
				return zISdpLQApJdDlzjSLXkvsYAPkKRV;
			}
		}

		Vector2 IPlayerMouse.screenPositionDelta
		{
			get
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return Vector2.zero;
				}
				if (!base.Rewired_002EIPlayerController_002Eenabled)
				{
					return Vector2.zero;
				}
				return tkKrMnFQMJfADxbiTCBVFYVFHYe;
			}
		}

		MouseAxis IPlayerMouse.xAxis
		{
			get
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return null;
				}
				if (kKSeakBQmxHoxVBFFJlYnfBqWHXi < 0)
				{
					return null;
				}
				return (MouseAxis)base.Rewired_002EIPlayerController_002Eaxes[kKSeakBQmxHoxVBFFJlYnfBqWHXi];
			}
		}

		MouseAxis IPlayerMouse.yAxis
		{
			get
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return null;
				}
				if (nKxnVgOnBUdpCQsPsrkhvEedvzoj < 0)
				{
					return null;
				}
				return (MouseAxis)base.Rewired_002EIPlayerController_002Eaxes[nKxnVgOnBUdpCQsPsrkhvEedvzoj];
			}
		}

		MouseWheel IPlayerMouse.wheel
		{
			get
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return null;
				}
				if (BaJmKmZNIoqpKwAgfBybsHzsdtmiA < 0)
				{
					return null;
				}
				return (MouseWheel)base.Rewired_002EIPlayerController_002Eelements[BaJmKmZNIoqpKwAgfBybsHzsdtmiA];
			}
		}

		Button IPlayerMouse.leftButton
		{
			get
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return null;
				}
				if (HwyvhAiehRSBiHDmxFXBaliUCbsD < 0)
				{
					return null;
				}
				return base.Rewired_002EIPlayerController_002Ebuttons[HwyvhAiehRSBiHDmxFXBaliUCbsD];
			}
		}

		Button IPlayerMouse.rightButton
		{
			get
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return null;
				}
				if (TaIBuZwmylflDoJqgAHECbdSqCfz < 0)
				{
					return null;
				}
				return base.Rewired_002EIPlayerController_002Ebuttons[TaIBuZwmylflDoJqgAHECbdSqCfz];
			}
		}

		Button IPlayerMouse.middleButton
		{
			get
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return null;
				}
				if (levMRhcBXUiUpDdOzBGLVfBFIcFHA < 0)
				{
					return null;
				}
				return base.Rewired_002EIPlayerController_002Ebuttons[levMRhcBXUiUpDdOzBGLVfBFIcFHA];
			}
		}

		float IPlayerMouse.pointerSpeed
		{
			get
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return 0f;
				}
				return RqdwXpIEzfkQBvKhnPoQDgzNEdmgA;
			}
			set
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return;
				}
				if (value < 0f)
				{
					value = 0f;
				}
				RqdwXpIEzfkQBvKhnPoQDgzNEdmgA = value;
			}
		}

		bool IPlayerMouse.useHardwarePointerPosition
		{
			get
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return false;
				}
				return dLXNlAgJBbfFdVzHypPBoPxGvSYn;
			}
			set
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
					return;
				}
				dLXNlAgJBbfFdVzHypPBoPxGvSYn = value;
				if (!value)
				{
					LABkWVGoWvdoSPMksXVchiGfKFbQ();
				}
			}
		}

		bool IMouseInputSource.enabled => base.Rewired_002EIPlayerController_002Eenabled;

		Vector2 IMouseInputSource.screenPosition => JQaKrnYcCWhZBzPgCTbcPEovDINJ;

		Vector2 IMouseInputSource.screenPositionDelta => tkKrMnFQMJfADxbiTCBVFYVFHYe;

		Vector2 IMouseInputSource.wheelDelta
		{
			get
			{
				if (((IPlayerMouse)this).wheel == null)
				{
					return Vector2.zero;
				}
				return ((IPlayerMouse)this).wheel.value;
			}
		}

		bool IMouseInputSource.locked => false;

		event Action<Vector2> IPlayerMouse.ScreenPositionChangedEvent
		{
			add
			{
				if (ReInput._id != gOVUDrtcXNqvkQTIYRMOHbOuODPg)
				{
					ReInput.CheckInitialized(gOVUDrtcXNqvkQTIYRMOHbOuODPg);
				}
				else
				{
					jBkUfXhfeycetDYVzLqRlWMfEUOgA = (Action<Vector2>)Delegate.Combine(jBkUfXhfeycetDYVzLqRlWMfEUOgA, value);
				}
			}
			remove
			{
				jBkUfXhfeycetDYVzLqRlWMfEUOgA = (Action<Vector2>)Delegate.Remove(jBkUfXhfeycetDYVzLqRlWMfEUOgA, value);
			}
		}

		private PlayerMouse(Definition P_0)
			: base(P_0)
		{
			FnvQZiHnEUAoHefXjWJMraoFcvYdA = P_0.defaultToCenter;
			HEGesIIHzLSqSSeaJYuZGJllMIxcA = P_0.clampToMovementArea;
			ofIfiTyPCtlLyLqDxcsfYgiHKsTU = P_0.movementArea;
			ZuqglUXBVNDHrKKkIJBoYfUjEsYfA = P_0.movementAreaUnit;
			RqdwXpIEzfkQBvKhnPoQDgzNEdmgA = P_0.pointerSpeed;
			dLXNlAgJBbfFdVzHypPBoPxGvSYn = P_0.useHardwarePointerPosition;
			int num = base.Rewired_002EIPlayerController_002EelementCount;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				if (num2 < 2 && (object)base.Rewired_002EIPlayerController_002Eelements[i].GetType() == typeof(MouseAxis))
				{
					if (num2 == 0)
					{
						kKSeakBQmxHoxVBFFJlYnfBqWHXi = base.Rewired_002EIPlayerController_002Eaxes.IndexOf((MouseAxis)base.Rewired_002EIPlayerController_002Eelements[i]);
					}
					else
					{
						nKxnVgOnBUdpCQsPsrkhvEedvzoj = base.Rewired_002EIPlayerController_002Eaxes.IndexOf((MouseAxis)base.Rewired_002EIPlayerController_002Eelements[i]);
					}
					num2++;
				}
				else if (BaJmKmZNIoqpKwAgfBybsHzsdtmiA < 0 && base.Rewired_002EIPlayerController_002Eelements[i] is MouseWheel)
				{
					BaJmKmZNIoqpKwAgfBybsHzsdtmiA = i;
				}
				else if (num3 < 3 && (object)base.Rewired_002EIPlayerController_002Eelements[i].GetType() == typeof(Button))
				{
					switch (num3)
					{
					case 0:
						HwyvhAiehRSBiHDmxFXBaliUCbsD = base.Rewired_002EIPlayerController_002Ebuttons.IndexOf((Button)base.Rewired_002EIPlayerController_002Eelements[i]);
						break;
					case 1:
						TaIBuZwmylflDoJqgAHECbdSqCfz = base.Rewired_002EIPlayerController_002Ebuttons.IndexOf((Button)base.Rewired_002EIPlayerController_002Eelements[i]);
						break;
					case 2:
						levMRhcBXUiUpDdOzBGLVfBFIcFHA = base.Rewired_002EIPlayerController_002Ebuttons.IndexOf((Button)base.Rewired_002EIPlayerController_002Eelements[i]);
						break;
					}
					num3++;
				}
			}
			if (BaJmKmZNIoqpKwAgfBybsHzsdtmiA < 0)
			{
				int num4 = PlayerController.KBRKboVVekChYIfgWzbAJQdQRsFn(base.Rewired_002EIPlayerController_002Eaxes, YPLWUwtSVwazlsAhNToZgFvCfzRS._003C_003E9.GOxRIrDzjcxzGbjxzIRijpBYDSVGA, 1);
				int num5 = PlayerController.KBRKboVVekChYIfgWzbAJQdQRsFn(base.Rewired_002EIPlayerController_002Eaxes, YPLWUwtSVwazlsAhNToZgFvCfzRS._003C_003E9.zzEiwrWDLrdaIANWMQyViMdKaMaDA, 2);
				if (num4 >= 0 || num5 >= 0)
				{
					MouseWheel mouseWheel = new MouseWheel(this, new MouseWheel.Definition
					{
						name = "Wheel"
					});
					AgFYxPwvfNmkvXsiOVykSvfpowRr(mouseWheel);
					BaJmKmZNIoqpKwAgfBybsHzsdtmiA = base.Rewired_002EIPlayerController_002Eelements.Count - 1;
					if (num4 < 0 || num5 < 0)
					{
						Element element = new MouseWheelAxis(this, new MouseWheelAxis.Definition
						{
							name = "Wheel Horizontal",
							coordinateMode = AxisCoordinateMode.Relative
						});
						AgFYxPwvfNmkvXsiOVykSvfpowRr(element);
						mouseWheel.ShDGCzCEOwWhDGDdlniCsvrmVnED(element);
						mouseWheel.ShDGCzCEOwWhDGDdlniCsvrmVnED((num4 < 0) ? base.Rewired_002EIPlayerController_002Eaxes[num5] : base.Rewired_002EIPlayerController_002Eaxes[num4]);
					}
					else
					{
						mouseWheel.ShDGCzCEOwWhDGDdlniCsvrmVnED(base.Rewired_002EIPlayerController_002Eaxes[num4]);
						mouseWheel.ShDGCzCEOwWhDGDdlniCsvrmVnED(base.Rewired_002EIPlayerController_002Eaxes[num5]);
					}
				}
			}
			if (FnvQZiHnEUAoHefXjWJMraoFcvYdA)
			{
				ScreenRect screenRect = qAgHAUAnHneznUqcTiREVxJwnGXTA();
				JQaKrnYcCWhZBzPgCTbcPEovDINJ = new Vector2(screenRect.center.x, screenRect.center.y);
			}
			else
			{
				JQaKrnYcCWhZBzPgCTbcPEovDINJ = Vector2.zero;
			}
		}

		protected override bool Update(UpdateLoopType updateLoop)
		{
			if (!base.Update(updateLoop))
			{
				return false;
			}
			if (updateLoop != UpdateLoopType.Update)
			{
				return false;
			}
			if (kKSeakBQmxHoxVBFFJlYnfBqWHXi >= 0)
			{
				JQaKrnYcCWhZBzPgCTbcPEovDINJ.x = OLTSWZqJtUBRlDjkSsHduiJoRuYk(base.Rewired_002EIPlayerController_002Eaxes[kKSeakBQmxHoxVBFFJlYnfBqWHXi], JQaKrnYcCWhZBzPgCTbcPEovDINJ.x, RqdwXpIEzfkQBvKhnPoQDgzNEdmgA);
			}
			if (nKxnVgOnBUdpCQsPsrkhvEedvzoj >= 0)
			{
				JQaKrnYcCWhZBzPgCTbcPEovDINJ.y = OLTSWZqJtUBRlDjkSsHduiJoRuYk(base.Rewired_002EIPlayerController_002Eaxes[nKxnVgOnBUdpCQsPsrkhvEedvzoj], JQaKrnYcCWhZBzPgCTbcPEovDINJ.y, RqdwXpIEzfkQBvKhnPoQDgzNEdmgA);
			}
			Player player;
			if (dLXNlAgJBbfFdVzHypPBoPxGvSYn && (player = base.uRHlXwXpyQnNeDKkeJiaPfQPdYgbA) != null)
			{
				if (!player.controllers.hasMouse)
				{
					LABkWVGoWvdoSPMksXVchiGfKFbQ();
				}
				else
				{
					bNdMHdAvntxYfBMMrUaHodPfaXbG = ReInput.controllers.Mouse.screenPosition;
					if (bNdMHdAvntxYfBMMrUaHodPfaXbG.x != wPOlKDIIUeNBvyQxAMsztxuIDlMQ.x || bNdMHdAvntxYfBMMrUaHodPfaXbG.y != wPOlKDIIUeNBvyQxAMsztxuIDlMQ.y)
					{
						JQaKrnYcCWhZBzPgCTbcPEovDINJ.x = bNdMHdAvntxYfBMMrUaHodPfaXbG.x;
						JQaKrnYcCWhZBzPgCTbcPEovDINJ.y = bNdMHdAvntxYfBMMrUaHodPfaXbG.y;
					}
					wPOlKDIIUeNBvyQxAMsztxuIDlMQ.x = bNdMHdAvntxYfBMMrUaHodPfaXbG.x;
					wPOlKDIIUeNBvyQxAMsztxuIDlMQ.y = bNdMHdAvntxYfBMMrUaHodPfaXbG.y;
				}
			}
			ZMfkAfoCtvlaEExavSValPKyhxjGA(JQaKrnYcCWhZBzPgCTbcPEovDINJ);
			tkKrMnFQMJfADxbiTCBVFYVFHYe.x = JQaKrnYcCWhZBzPgCTbcPEovDINJ.x - zISdpLQApJdDlzjSLXkvsYAPkKRV.x;
			tkKrMnFQMJfADxbiTCBVFYVFHYe.y = JQaKrnYcCWhZBzPgCTbcPEovDINJ.y - zISdpLQApJdDlzjSLXkvsYAPkKRV.y;
			CcGcPKEomXECfdTkDYQdolgxRsigB = JQaKrnYcCWhZBzPgCTbcPEovDINJ.x != zISdpLQApJdDlzjSLXkvsYAPkKRV.x || JQaKrnYcCWhZBzPgCTbcPEovDINJ.y != zISdpLQApJdDlzjSLXkvsYAPkKRV.y;
			zISdpLQApJdDlzjSLXkvsYAPkKRV.x = JQaKrnYcCWhZBzPgCTbcPEovDINJ.x;
			zISdpLQApJdDlzjSLXkvsYAPkKRV.y = JQaKrnYcCWhZBzPgCTbcPEovDINJ.y;
			return true;
		}

		protected override void UpdateFinished()
		{
			base.UpdateFinished();
			if (CcGcPKEomXECfdTkDYQdolgxRsigB && jBkUfXhfeycetDYVzLqRlWMfEUOgA != null)
			{
				try
				{
					jBkUfXhfeycetDYVzLqRlWMfEUOgA(JQaKrnYcCWhZBzPgCTbcPEovDINJ);
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred in a listener of ScreenPositionChangedEvent. This means an exception was thrown by your code.\n" + ex);
				}
				CcGcPKEomXECfdTkDYQdolgxRsigB = false;
			}
		}

		protected override void ClearVars()
		{
			base.ClearVars();
			zISdpLQApJdDlzjSLXkvsYAPkKRV = JQaKrnYcCWhZBzPgCTbcPEovDINJ;
			tkKrMnFQMJfADxbiTCBVFYVFHYe = Vector2.zero;
			LABkWVGoWvdoSPMksXVchiGfKFbQ();
			CcGcPKEomXECfdTkDYQdolgxRsigB = false;
		}

		private void ZMfkAfoCtvlaEExavSValPKyhxjGA(Vector2 P_0)
		{
			if (!HEGesIIHzLSqSSeaJYuZGJllMIxcA)
			{
				JQaKrnYcCWhZBzPgCTbcPEovDINJ = P_0;
				return;
			}
			if (ZuqglUXBVNDHrKKkIJBoYfUjEsYfA == MovementAreaUnit.Screen)
			{
				float num = Screen.width;
				float num2 = Screen.height;
				JQaKrnYcCWhZBzPgCTbcPEovDINJ.x = Mathf.Clamp(P_0.x, ofIfiTyPCtlLyLqDxcsfYgiHKsTU.xMin * num, ofIfiTyPCtlLyLqDxcsfYgiHKsTU.xMax * num);
				JQaKrnYcCWhZBzPgCTbcPEovDINJ.y = Mathf.Clamp(P_0.y, ofIfiTyPCtlLyLqDxcsfYgiHKsTU.yMin * num2, ofIfiTyPCtlLyLqDxcsfYgiHKsTU.yMax * num2);
				return;
			}
			if (ZuqglUXBVNDHrKKkIJBoYfUjEsYfA == MovementAreaUnit.Pixel)
			{
				JQaKrnYcCWhZBzPgCTbcPEovDINJ.x = Mathf.Clamp(P_0.x, ofIfiTyPCtlLyLqDxcsfYgiHKsTU.xMin, ofIfiTyPCtlLyLqDxcsfYgiHKsTU.xMax);
				JQaKrnYcCWhZBzPgCTbcPEovDINJ.y = Mathf.Clamp(P_0.y, ofIfiTyPCtlLyLqDxcsfYgiHKsTU.yMin, ofIfiTyPCtlLyLqDxcsfYgiHKsTU.yMax);
				return;
			}
			throw new NotImplementedException();
		}

		private ScreenRect qAgHAUAnHneznUqcTiREVxJwnGXTA()
		{
			if (ZuqglUXBVNDHrKKkIJBoYfUjEsYfA == MovementAreaUnit.Screen)
			{
				return new ScreenRect(ofIfiTyPCtlLyLqDxcsfYgiHKsTU.xMin * (float)Screen.width, ofIfiTyPCtlLyLqDxcsfYgiHKsTU.yMin * (float)Screen.height, ofIfiTyPCtlLyLqDxcsfYgiHKsTU.width * (float)Screen.width, ofIfiTyPCtlLyLqDxcsfYgiHKsTU.height * (float)Screen.height);
			}
			if (ZuqglUXBVNDHrKKkIJBoYfUjEsYfA == MovementAreaUnit.Pixel)
			{
				return ofIfiTyPCtlLyLqDxcsfYgiHKsTU;
			}
			throw new NotImplementedException();
		}

		private void LABkWVGoWvdoSPMksXVchiGfKFbQ()
		{
			bNdMHdAvntxYfBMMrUaHodPfaXbG = Vector2.zero;
			wPOlKDIIUeNBvyQxAMsztxuIDlMQ = Vector2.zero;
		}

		private static float OLTSWZqJtUBRlDjkSsHduiJoRuYk(Axis P_0, float P_1, float P_2)
		{
			if (P_0 == null)
			{
				return P_1;
			}
			return P_0.coordinateMode switch
			{
				AxisCoordinateMode.Absolute => P_0.value, 
				AxisCoordinateMode.Relative => P_1 + P_0.value * P_2, 
				_ => throw new NotImplementedException(), 
			};
		}

		bool IMouseInputSource.GetButtonDown(int button)
		{
			return GetButtonDown(button);
		}

		bool IMouseInputSource.GetButtonUp(int button)
		{
			return GetButtonUp(button);
		}

		bool IMouseInputSource.GetButton(int button)
		{
			return GetButton(button);
		}
	}
}
