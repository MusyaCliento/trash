using System;

namespace Rewired
{
	public sealed class ElementAssignmentInfo
	{
		private readonly ControllerMap xLehfslahJMXaPNRoKfCErsxbqrCA;

		private readonly ControllerElementType MWtOvURgYkUFbmRceEULrKGxlDcR;

		private readonly int xbAeoOqAQpxwrtmlviagBWdgRSnU;

		private readonly int FfIGDvwTVlJNKRCbnjRPUSqCXOGS;

		private readonly AxisRange ELaZsTZdgbdmDVbsmetuYduTZPwQ;

		private readonly KeyboardKeyCode WiLseQyrQPTpszNJYvAtjEbNQydc;

		private readonly ModifierKeyFlags cWdeJgBEvnwWpToWzFgjYgNAdbnBA;

		private readonly int YlDjzFoXtaAWQnYwtMXfzOJkpExy;

		private readonly Pole xhXbIYvKbpjtMximyUMmDGLhiagc;

		private readonly bool NLWABMwDanxyvwqftpkQOCzsyJBW;

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				if (xLehfslahJMXaPNRoKfCErsxbqrCA == null)
				{
					return null;
				}
				return xLehfslahJMXaPNRoKfCErsxbqrCA.player;
			}
		}

		public InputAction action
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.mapping.GetAction(YlDjzFoXtaAWQnYwtMXfzOJkpExy);
			}
		}

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				if (xLehfslahJMXaPNRoKfCErsxbqrCA == null)
				{
					return null;
				}
				return ReInput.controllers.GetController(xLehfslahJMXaPNRoKfCErsxbqrCA.controllerType, xLehfslahJMXaPNRoKfCErsxbqrCA.controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (!ReInput.isReady || xLehfslahJMXaPNRoKfCErsxbqrCA == null)
				{
					return ControllerType.Keyboard;
				}
				return xLehfslahJMXaPNRoKfCErsxbqrCA.controllerType;
			}
		}

		public int controllerId
		{
			get
			{
				if (!ReInput.isReady || xLehfslahJMXaPNRoKfCErsxbqrCA == null)
				{
					return -1;
				}
				return xLehfslahJMXaPNRoKfCErsxbqrCA.controllerId;
			}
		}

		public ControllerMap controllerMap => xLehfslahJMXaPNRoKfCErsxbqrCA;

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (controller == null)
				{
					return null;
				}
				return controller.GetElementIdentifierById(FfIGDvwTVlJNKRCbnjRPUSqCXOGS);
			}
		}

		public ActionElementMap elementMap
		{
			get
			{
				if (xLehfslahJMXaPNRoKfCErsxbqrCA == null)
				{
					return null;
				}
				return xLehfslahJMXaPNRoKfCErsxbqrCA.GetElementMap(xbAeoOqAQpxwrtmlviagBWdgRSnU);
			}
		}

		public ControllerElementType elementType => MWtOvURgYkUFbmRceEULrKGxlDcR;

		public Pole axisContribution => xhXbIYvKbpjtMximyUMmDGLhiagc;

		public AxisRange axisRange => ELaZsTZdgbdmDVbsmetuYduTZPwQ;

		public bool invert => NLWABMwDanxyvwqftpkQOCzsyJBW;

		public KeyboardKeyCode keyCode => WiLseQyrQPTpszNJYvAtjEbNQydc;

		public ModifierKeyFlags modifierKeyFlags => cWdeJgBEvnwWpToWzFgjYgNAdbnBA;

		public string elementDisplayName
		{
			get
			{
				if (xLehfslahJMXaPNRoKfCErsxbqrCA == null)
				{
					return string.Empty;
				}
				if (controllerType == ControllerType.Keyboard)
				{
					return Keyboard.GetKeyName(keyCode, modifierKeyFlags);
				}
				Controller controller = this.controller;
				if (controller == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(FfIGDvwTVlJNKRCbnjRPUSqCXOGS);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				if (MWtOvURgYkUFbmRceEULrKGxlDcR == ControllerElementType.Axis)
				{
					if (ELaZsTZdgbdmDVbsmetuYduTZPwQ == AxisRange.Full)
					{
						return elementIdentifierById.XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename;
					}
					if (ELaZsTZdgbdmDVbsmetuYduTZPwQ == AxisRange.Positive)
					{
						return elementIdentifierById.XAukkdYkRkAZDxUWBprlnhBlowWG_002EpositiveName;
					}
					if (ELaZsTZdgbdmDVbsmetuYduTZPwQ == AxisRange.Negative)
					{
						return elementIdentifierById.XAukkdYkRkAZDxUWBprlnhBlowWG_002EnegativeName;
					}
				}
				return elementIdentifierById.XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename;
			}
		}

		internal ElementAssignmentInfo(ControllerMap P_0, ElementAssignment P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerMap");
			}
			YlDjzFoXtaAWQnYwtMXfzOJkpExy = P_1.actionId;
			xLehfslahJMXaPNRoKfCErsxbqrCA = P_0;
			xbAeoOqAQpxwrtmlviagBWdgRSnU = P_1.elementMapId;
			FfIGDvwTVlJNKRCbnjRPUSqCXOGS = P_1.elementIdentifierId;
			WiLseQyrQPTpszNJYvAtjEbNQydc = P_1.keyboardKey;
			cWdeJgBEvnwWpToWzFgjYgNAdbnBA = P_1.modifierKeyFlags;
			NLWABMwDanxyvwqftpkQOCzsyJBW = P_1.invert;
			MWtOvURgYkUFbmRceEULrKGxlDcR = GHPcAvLGyrhUIIuLWeQoyFTYgunBA.YcYTilAPBvSfzMelopUiRgKqPOCx(P_1.type);
			xhXbIYvKbpjtMximyUMmDGLhiagc = P_1.axisContribution;
			ELaZsTZdgbdmDVbsmetuYduTZPwQ = P_1.axisRange;
			if (xLehfslahJMXaPNRoKfCErsxbqrCA.controllerType == ControllerType.Keyboard)
			{
				Keyboard.obvPPlbCkQRkCeHBEthsFUqbJGvK(ref FfIGDvwTVlJNKRCbnjRPUSqCXOGS, ref WiLseQyrQPTpszNJYvAtjEbNQydc);
			}
		}
	}
}
