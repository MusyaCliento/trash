using Rewired.HID.Drivers;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class NintendoSwitchJoyConExtension : NintendoSwitchGamepadExtension, IControllerVibrator, IHIDControllerExtension, IAxisCalibrationIndexMap
	{
		private class WdquYOjSLIPxbEmNmRWOEXKBBnUl : ExtSource_Base
		{
			public IDriver_NintendoSwitchJoyCon chYeIikCLUqrFGirvwSAElvErHKnc => base.driver as IDriver_NintendoSwitchJoyCon;

			public WdquYOjSLIPxbEmNmRWOEXKBBnUl(IDriver_NintendoSwitchJoyCon P_0)
				: base(P_0)
			{
			}
		}

		private new WdquYOjSLIPxbEmNmRWOEXKBBnUl source => base.source as WdquYOjSLIPxbEmNmRWOEXKBBnUl;

		public NintendoSwitchJoyConType joyConType
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return NintendoSwitchJoyConType.Right;
				}
				if (!base.isValid)
				{
					return NintendoSwitchJoyConType.Left;
				}
				return source.chYeIikCLUqrFGirvwSAElvErHKnc.joyConType;
			}
		}

		public NintendoSwitchJoyConGripStyle joyConGripStyle
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return NintendoSwitchJoyConGripStyle.Horizontal;
				}
				if (!base.isValid)
				{
					return NintendoSwitchJoyConGripStyle.Horizontal;
				}
				return source.chYeIikCLUqrFGirvwSAElvErHKnc.joyConGripStyle;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (base.isValid)
				{
					source.chYeIikCLUqrFGirvwSAElvErHKnc.joyConGripStyle = value;
				}
			}
		}

		internal NintendoSwitchJoyConExtension(IDriver_NintendoSwitchJoyCon P_0)
			: base(new WdquYOjSLIPxbEmNmRWOEXKBBnUl(P_0))
		{
		}

		private NintendoSwitchJoyConExtension(NintendoSwitchJoyConExtension P_0)
			: base(P_0)
		{
		}

		private int xPWMbRBuejsSyBDuIVadNreehLfjA(int P_0)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return P_0;
			}
			if (!base.isValid)
			{
				return P_0;
			}
			return source.chYeIikCLUqrFGirvwSAElvErHKnc.GetMappedAxisIndex(P_0);
		}

		int IAxisCalibrationIndexMap.GetMappedAxisIndex(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in xPWMbRBuejsSyBDuIVadNreehLfjA
			return this.xPWMbRBuejsSyBDuIVadNreehLfjA(P_0);
		}

		internal override Controller.Extension Clone()
		{
			return new NintendoSwitchJoyConExtension(this);
		}
	}
}
