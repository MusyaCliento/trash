using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class NintendoSwitchJoyConDriver : NintendoSwitchGamepadDriver, IDriver_NintendoSwitchJoyCon, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension, IAxisCalibrationIndexMap
	{
		private const int SZeNZIUcYeAxDaveiHkIfxHCJjQJ = 11;

		private const int GPfYjscGRsHOkKEpYcgAemVXvFtr = 2;

		private const int pgcUycTjuKbnkEgNRNMLtAtnmlKK = 1;

		private const int CCoDsNAwAmxxMGVGpHXveXLbcevJ = 1;

		private const int MJVhsxlIbKWASwFcqKKSWxfAKWjb = 3;

		private readonly NativeBuffer FDAVgvxqztymtrghxguWjfimaerIA;

		private readonly NintendoSwitchJoyConType qtKWLTNNfOHiseRaUrlARFvlaAmF;

		private NintendoSwitchJoyConGripStyle bgLMUcFmhVFOLjjfJoUDucUoyTLU;

		private readonly byte[] HanfDFiITZCHWFznGRNlIhaHCavZ = new byte[3];

		protected byte[] buttonAxisReadBuffer => HanfDFiITZCHWFznGRNlIhaHCavZ;

		protected abstract int byteIndexStartSticks { get; }

		NintendoSwitchJoyConType IDriver_NintendoSwitchJoyCon.joyConType => qtKWLTNNfOHiseRaUrlARFvlaAmF;

		NintendoSwitchJoyConGripStyle IDriver_NintendoSwitchJoyCon.joyConGripStyle
		{
			get
			{
				return bgLMUcFmhVFOLjjfJoUDucUoyTLU;
			}
			set
			{
				bgLMUcFmhVFOLjjfJoUDucUoyTLU = value;
			}
		}

		int IAxisCalibrationIndexMap.GetMappedAxisIndex(int elementIndex)
		{
			if (elementIndex < 0 || elementIndex > 1)
			{
				return elementIndex;
			}
			if (bgLMUcFmhVFOLjjfJoUDucUoyTLU == NintendoSwitchJoyConGripStyle.Vertical)
			{
				if (elementIndex == 0)
				{
					return 1;
				}
				return 0;
			}
			return elementIndex;
		}

		protected NintendoSwitchJoyConDriver(InitArgs P_0, UkwlHqTHSgAsSUZxuAmREwAFjXVk P_1)
			: base(P_0, P_1, 11, 2, 1)
		{
			if (P_1 != UkwlHqTHSgAsSUZxuAmREwAFjXVk.JoyConLeft && P_1 != UkwlHqTHSgAsSUZxuAmREwAFjXVk.JoyConRight)
			{
				throw new ArgumentException("controllerType");
			}
			qtKWLTNNfOHiseRaUrlARFvlaAmF = ((P_1 != UkwlHqTHSgAsSUZxuAmREwAFjXVk.JoyConLeft) ? NintendoSwitchJoyConType.Right : NintendoSwitchJoyConType.Left);
			bgLMUcFmhVFOLjjfJoUDucUoyTLU = NintendoSwitchJoyConGripStyle.Horizontal;
			FDAVgvxqztymtrghxguWjfimaerIA = new NativeBuffer(5);
			axes = new okLUGVdjnOaHkqUoOikOkGMRQUCY[2]
			{
				new okLUGVdjnOaHkqUoOikOkGMRQUCY(48, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1,
					bitSize = 16,
					logicalMin = 0,
					logicalMax = 65535,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 32767),
				new okLUGVdjnOaHkqUoOikOkGMRQUCY(48, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 3,
					bitSize = 16,
					logicalMin = 0,
					logicalMax = 65535,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 32767)
			};
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new NintendoSwitchJoyConExtension(this);
		}

		protected override void UpdateElements(VJJORtyhxtIZFDAvjUdtXgBUbPYD[] elements, NativeBuffer inputReport, double timestamp)
		{
			byte[] hanfDFiITZCHWFznGRNlIhaHCavZ = HanfDFiITZCHWFznGRNlIhaHCavZ;
			inputReport.Read(hanfDFiITZCHWFznGRNlIhaHCavZ, 3, byteIndexStartSticks);
			ushort valueX = (ushort)(hanfDFiITZCHWFznGRNlIhaHCavZ[0] | ((hanfDFiITZCHWFznGRNlIhaHCavZ[1] & 0xF) << 8));
			ushort valueY = (ushort)((hanfDFiITZCHWFznGRNlIhaHCavZ[1] >> 4) | (hanfDFiITZCHWFznGRNlIhaHCavZ[2] << 4));
			GetCalibratedStickValue(valueX, valueY, GetAxisCalibration(0), GetAxisCalibration(1), out var calibratedX, out var calibratedY);
			HandleGripStyleStickAxisSwap(ref calibratedX, ref calibratedY);
			FDAVgvxqztymtrghxguWjfimaerIA.Write((byte)48, 0);
			FDAVgvxqztymtrghxguWjfimaerIA.Write(calibratedX, 1);
			FDAVgvxqztymtrghxguWjfimaerIA.Write(calibratedY, 3);
			for (int i = 0; i < elements.Length; i++)
			{
				elements[i].kIKDSuiibFIJviyHCLnqsKOSMCInA(FDAVgvxqztymtrghxguWjfimaerIA, timestamp);
			}
		}

		protected abstract void HandleGripStyleStickAxisSwap(ref ushort stickX, ref ushort stickY);

		~NintendoSwitchJoyConDriver()
		{
			Dispose(disposing: false);
		}

		protected override void Dispose(bool disposing)
		{
			if (!base.disposed)
			{
				if (disposing && FDAVgvxqztymtrghxguWjfimaerIA != null)
				{
					FDAVgvxqztymtrghxguWjfimaerIA.Dispose();
				}
				base.Dispose(disposing);
			}
		}
	}
}
