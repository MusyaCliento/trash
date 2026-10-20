using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class NintendoSwitchProControllerDriver : NintendoSwitchGamepadDriver, IDriver_NintendoSwitchProController, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension
	{
		private const int ttzSqnBUcJvHEIgjZhQDGVucwkOc = 18;

		private const int ugOWoYAWvDHQOMrDQGDQlGioXAbM = 4;

		private const int cuzNQUZGAFYiAvBWMDuFqEyIwzHt = 2;

		private const int ZhdVaZhisqyjYzYdJTIjGusbPJFe = 3;

		private const int vHQQNEXaNPeCuzOogaNIAeSODEXjb = 6;

		private const int bcMIhaFIsgESisqFWbLgDgnYskOm = 1;

		private const int uHAsrtPKefzxecLnKvbVfIppHTvg = 3;

		private const int ULkvyXoxUWhUOpsvkgaCeKbGmFRy = 5;

		private const int uqoBtOKYVnLzkSlGqltsRINhHAli = 7;

		private readonly byte[] JDXMjLeokPVkRZljPCBzglEIGkgHb = new byte[6];

		private readonly NativeBuffer LuQNJAwRxukRtndiYWjUwuxbTGhE;

		public NintendoSwitchProControllerDriver(InitArgs P_0)
			: base(P_0, UkwlHqTHSgAsSUZxuAmREwAFjXVk.ProController, 18, 4, 2)
		{
			LuQNJAwRxukRtndiYWjUwuxbTGhE = new NativeBuffer(9);
			axes = new okLUGVdjnOaHkqUoOikOkGMRQUCY[4]
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
				}, false, 32767),
				new okLUGVdjnOaHkqUoOikOkGMRQUCY(48, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 5,
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
					usage = 53,
					dataIndex = 7,
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

		public override void Update(UpdateLoopType updateLoop)
		{
			base.Update(updateLoop);
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new NintendoSwitchProControllerExtension(this);
		}

		protected override void UpdateButtons(NativeBuffer inputReport, double timestamp)
		{
			inputReport.Read(JDXMjLeokPVkRZljPCBzglEIGkgHb, 3, 3);
			buttons[0].PogUzVVLnPzYuPCLsIgJOvBnYfcB((JDXMjLeokPVkRZljPCBzglEIGkgHb[0] & 4) != 0, timestamp);
			buttons[1].PogUzVVLnPzYuPCLsIgJOvBnYfcB((JDXMjLeokPVkRZljPCBzglEIGkgHb[0] & 8) != 0, timestamp);
			buttons[2].PogUzVVLnPzYuPCLsIgJOvBnYfcB((JDXMjLeokPVkRZljPCBzglEIGkgHb[0] & 1) != 0, timestamp);
			buttons[3].PogUzVVLnPzYuPCLsIgJOvBnYfcB((JDXMjLeokPVkRZljPCBzglEIGkgHb[0] & 2) != 0, timestamp);
			buttons[4].PogUzVVLnPzYuPCLsIgJOvBnYfcB((JDXMjLeokPVkRZljPCBzglEIGkgHb[2] & 0x40) != 0, timestamp);
			buttons[5].PogUzVVLnPzYuPCLsIgJOvBnYfcB((JDXMjLeokPVkRZljPCBzglEIGkgHb[0] & 0x40) != 0, timestamp);
			buttons[6].PogUzVVLnPzYuPCLsIgJOvBnYfcB((JDXMjLeokPVkRZljPCBzglEIGkgHb[2] & 0x80) != 0, timestamp);
			buttons[7].PogUzVVLnPzYuPCLsIgJOvBnYfcB((JDXMjLeokPVkRZljPCBzglEIGkgHb[0] & 0x80) != 0, timestamp);
			buttons[8].PogUzVVLnPzYuPCLsIgJOvBnYfcB((JDXMjLeokPVkRZljPCBzglEIGkgHb[1] & 1) != 0, timestamp);
			buttons[9].PogUzVVLnPzYuPCLsIgJOvBnYfcB((JDXMjLeokPVkRZljPCBzglEIGkgHb[1] & 2) != 0, timestamp);
			buttons[10].PogUzVVLnPzYuPCLsIgJOvBnYfcB((JDXMjLeokPVkRZljPCBzglEIGkgHb[1] & 0x20) != 0, timestamp);
			buttons[11].PogUzVVLnPzYuPCLsIgJOvBnYfcB((JDXMjLeokPVkRZljPCBzglEIGkgHb[1] & 0x10) != 0, timestamp);
			buttons[12].PogUzVVLnPzYuPCLsIgJOvBnYfcB((JDXMjLeokPVkRZljPCBzglEIGkgHb[1] & 8) != 0, timestamp);
			buttons[13].PogUzVVLnPzYuPCLsIgJOvBnYfcB((JDXMjLeokPVkRZljPCBzglEIGkgHb[1] & 4) != 0, timestamp);
			buttons[14].PogUzVVLnPzYuPCLsIgJOvBnYfcB((JDXMjLeokPVkRZljPCBzglEIGkgHb[2] & 2) != 0, timestamp);
			buttons[15].PogUzVVLnPzYuPCLsIgJOvBnYfcB((JDXMjLeokPVkRZljPCBzglEIGkgHb[2] & 4) != 0, timestamp);
			buttons[16].PogUzVVLnPzYuPCLsIgJOvBnYfcB((JDXMjLeokPVkRZljPCBzglEIGkgHb[2] & 1) != 0, timestamp);
			buttons[17].PogUzVVLnPzYuPCLsIgJOvBnYfcB((JDXMjLeokPVkRZljPCBzglEIGkgHb[2] & 8) != 0, timestamp);
		}

		protected override void UpdateElements(VJJORtyhxtIZFDAvjUdtXgBUbPYD[] elements, NativeBuffer inputReport, double timestamp)
		{
			inputReport.Read(JDXMjLeokPVkRZljPCBzglEIGkgHb, 6, 6);
			byte[] jDXMjLeokPVkRZljPCBzglEIGkgHb = JDXMjLeokPVkRZljPCBzglEIGkgHb;
			int num = 0;
			ushort valueX = (ushort)(jDXMjLeokPVkRZljPCBzglEIGkgHb[num] | ((jDXMjLeokPVkRZljPCBzglEIGkgHb[1 + num] & 0xF) << 8));
			ushort valueY = (ushort)((jDXMjLeokPVkRZljPCBzglEIGkgHb[1 + num] >> 4) | (jDXMjLeokPVkRZljPCBzglEIGkgHb[2 + num] << 4));
			num = 3;
			ushort valueX2 = (ushort)(jDXMjLeokPVkRZljPCBzglEIGkgHb[num] | ((jDXMjLeokPVkRZljPCBzglEIGkgHb[1 + num] & 0xF) << 8));
			ushort valueY2 = (ushort)((jDXMjLeokPVkRZljPCBzglEIGkgHb[1 + num] >> 4) | (jDXMjLeokPVkRZljPCBzglEIGkgHb[2 + num] << 4));
			GetCalibratedStickValue(valueX, valueY, GetAxisCalibration(0), GetAxisCalibration(1), out var calibratedX, out var calibratedY);
			GetCalibratedStickValue(valueX2, valueY2, GetAxisCalibration(2), GetAxisCalibration(3), out var calibratedX2, out var calibratedY2);
			LuQNJAwRxukRtndiYWjUwuxbTGhE.Write((byte)48, 0);
			LuQNJAwRxukRtndiYWjUwuxbTGhE.Write(calibratedX, 1);
			LuQNJAwRxukRtndiYWjUwuxbTGhE.Write(calibratedY, 3);
			LuQNJAwRxukRtndiYWjUwuxbTGhE.Write(calibratedX2, 5);
			LuQNJAwRxukRtndiYWjUwuxbTGhE.Write(calibratedY2, 7);
			for (int i = 0; i < elements.Length; i++)
			{
				elements[i].kIKDSuiibFIJviyHCLnqsKOSMCInA(LuQNJAwRxukRtndiYWjUwuxbTGhE, timestamp);
			}
		}

		~NintendoSwitchProControllerDriver()
		{
			Dispose(disposing: false);
		}

		protected override void Dispose(bool disposing)
		{
			if (!base.disposed)
			{
				if (disposing && LuQNJAwRxukRtndiYWjUwuxbTGhE != null)
				{
					LuQNJAwRxukRtndiYWjUwuxbTGhE.Dispose();
				}
				base.Dispose(disposing);
			}
		}

		public static bool Matches(int vid, int pid)
		{
			if (vid == 1406)
			{
				return pid == 8201;
			}
			return false;
		}
	}
}
