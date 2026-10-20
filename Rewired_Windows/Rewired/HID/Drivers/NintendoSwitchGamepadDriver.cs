using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Rewired.ControllerExtensions;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class NintendoSwitchGamepadDriver : HIDDeviceDriver, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension, IDisposable
	{
		private enum gatGSYfjvpvEkCmeWorSElRmVCjwA
		{
			None = 0,
			Success = 1,
			Fail = 2,
			Ready = 3
		}

		private class NqwGnkcjGovKeUBLmgtBglJRwzyl : Exception
		{
		}

		private enum OytVNqdatKzQmEKZRiedzsMxGWbc
		{
			GetUsbStatus = 1
		}

		private delegate bool zCoeuqJvPRWZgayItRnxhDkGixdX(uint responseTimeoutMs);

		protected enum UkwlHqTHSgAsSUZxuAmREwAFjXVk
		{
			ProController = 0,
			JoyConLeft = 1,
			JoyConRight = 2
		}

		protected class uvVtdVuVbAxyQaowfnveTcqgPwCb
		{
			private uctGEmIAndGsnBPlyPlnhlfoOqoG PwTtgEsTLXiPRIHSHlmvSCxkHmTu;

			private qOFDFXISabmOPIMpaIMOBofHGKWtB uIkVtOXZOqxMjmTPdMjfIMhCfdDl;

			private float yHXybgRCyAvnRtldGTzMVPrhUGiD;

			private double stSqdkfIqIHKDJApESorOKyXyWig;

			public qOFDFXISabmOPIMpaIMOBofHGKWtB BijxwCZQiOSKWCydHlChhWyBxXLg => uIkVtOXZOqxMjmTPdMjfIMhCfdDl;

			public bool RSsPFKdephtbWwICJlKcqUfTjOAN => PwTtgEsTLXiPRIHSHlmvSCxkHmTu.BxdGSwjSxTfTpGjIDKQRyBcYsxwM > 0;

			public uvVtdVuVbAxyQaowfnveTcqgPwCb(uctGEmIAndGsnBPlyPlnhlfoOqoG P_0)
			{
				PwTtgEsTLXiPRIHSHlmvSCxkHmTu = P_0;
				yjgaQjFhQYdpmdCwehhGDnwUFTyi();
			}

			public void pDmNAzYXRdNJSYjLqlLXpsiEdSBL(float P_0, float P_1, float P_2, float P_3, float P_4)
			{
				if (P_4 < 0f)
				{
					P_4 = 0f;
				}
				yHXybgRCyAvnRtldGTzMVPrhUGiD = P_4;
				uIkVtOXZOqxMjmTPdMjfIMhCfdDl.MoKmwwdefJklsqySSjpGmJCsckDiA = MathTools.Clamp01(P_0);
				uIkVtOXZOqxMjmTPdMjfIMhCfdDl.ppdLtlnDtXcOPAAKTNseGbvdPyWab = MathTools.Clamp(P_1, 40.875885f, 626.28613f);
				uIkVtOXZOqxMjmTPdMjfIMhCfdDl.hTzpWYUBnGFJhpQWJLwVELrCWhXj = MathTools.Clamp01(P_2);
				uIkVtOXZOqxMjmTPdMjfIMhCfdDl.UZjKXxemFhDZFtyPiunUZMEOoJfE = MathTools.Clamp(P_3, 81.75177f, 1252.5723f);
				PwTtgEsTLXiPRIHSHlmvSCxkHmTu.YqehZNHYymBOIHmEqdEdyQFwXHSt = Math.Max(uIkVtOXZOqxMjmTPdMjfIMhCfdDl.MoKmwwdefJklsqySSjpGmJCsckDiA, uIkVtOXZOqxMjmTPdMjfIMhCfdDl.hTzpWYUBnGFJhpQWJLwVELrCWhXj);
				stSqdkfIqIHKDJApESorOKyXyWig = ReInput.realTime;
			}

			public bool zdcIglaUBwmYzFTKwEeqiACERsKjB(double P_0)
			{
				if ((uIkVtOXZOqxMjmTPdMjfIMhCfdDl.MoKmwwdefJklsqySSjpGmJCsckDiA > 0f || uIkVtOXZOqxMjmTPdMjfIMhCfdDl.hTzpWYUBnGFJhpQWJLwVELrCWhXj > 0f) && yHXybgRCyAvnRtldGTzMVPrhUGiD > 0f && P_0 >= stSqdkfIqIHKDJApESorOKyXyWig + (double)yHXybgRCyAvnRtldGTzMVPrhUGiD)
				{
					sqeZkQldjHvSBVtljlhXKdJWjeNi();
					return true;
				}
				return false;
			}

			public void sqeZkQldjHvSBVtljlhXKdJWjeNi()
			{
				uIkVtOXZOqxMjmTPdMjfIMhCfdDl.hTzpWYUBnGFJhpQWJLwVELrCWhXj = 0f;
				uIkVtOXZOqxMjmTPdMjfIMhCfdDl.MoKmwwdefJklsqySSjpGmJCsckDiA = 0f;
				PwTtgEsTLXiPRIHSHlmvSCxkHmTu.BxdGSwjSxTfTpGjIDKQRyBcYsxwM = 0;
				yHXybgRCyAvnRtldGTzMVPrhUGiD = 0f;
				stSqdkfIqIHKDJApESorOKyXyWig = ReInput.realTime;
			}

			public void yjgaQjFhQYdpmdCwehhGDnwUFTyi()
			{
				uIkVtOXZOqxMjmTPdMjfIMhCfdDl = qOFDFXISabmOPIMpaIMOBofHGKWtB.wdxYMhqgvNaZObVqJOIryvparkJKA();
				PwTtgEsTLXiPRIHSHlmvSCxkHmTu.BxdGSwjSxTfTpGjIDKQRyBcYsxwM = 0;
				yHXybgRCyAvnRtldGTzMVPrhUGiD = 0f;
				stSqdkfIqIHKDJApESorOKyXyWig = 0.0;
			}
		}

		protected struct qOFDFXISabmOPIMpaIMOBofHGKWtB
		{
			public const int WgoBIYhxuREKqDGVLjrAritHDaWYA = 160;

			public const int hUrriLpklgVRrfNRyoMPqnNpMHLe = 320;

			public float MoKmwwdefJklsqySSjpGmJCsckDiA;

			public float ppdLtlnDtXcOPAAKTNseGbvdPyWab;

			public float hTzpWYUBnGFJhpQWJLwVELrCWhXj;

			public float UZjKXxemFhDZFtyPiunUZMEOoJfE;

			internal qOFDFXISabmOPIMpaIMOBofHGKWtB(float P_0, float P_1, float P_2, float P_3)
			{
				if (P_0 < 0f)
				{
					P_0 = 0f;
				}
				if (P_0 > 1f)
				{
					P_0 = 1f;
				}
				if (P_1 < 0f)
				{
					P_1 = 0f;
				}
				if (P_2 < 0f)
				{
					P_2 = 0f;
				}
				if (P_2 > 1f)
				{
					P_2 = 1f;
				}
				if (P_3 < 0f)
				{
					P_3 = 0f;
				}
				MoKmwwdefJklsqySSjpGmJCsckDiA = P_0;
				ppdLtlnDtXcOPAAKTNseGbvdPyWab = P_1;
				hTzpWYUBnGFJhpQWJLwVELrCWhXj = P_2;
				UZjKXxemFhDZFtyPiunUZMEOoJfE = P_3;
			}

			public static qOFDFXISabmOPIMpaIMOBofHGKWtB wdxYMhqgvNaZObVqJOIryvparkJKA()
			{
				return new qOFDFXISabmOPIMpaIMOBofHGKWtB(0f, 160f, 0f, 320f);
			}

			public string zjxwvTlNNgKHQEUHIVaCAidzZEaI()
			{
				return "amplitudeLow: " + MoKmwwdefJklsqySSjpGmJCsckDiA + ", frequencyLow: " + ppdLtlnDtXcOPAAKTNseGbvdPyWab + ", amplitudeHigh: " + hTzpWYUBnGFJhpQWJLwVELrCWhXj + ", frequencyHigh: " + UZjKXxemFhDZFtyPiunUZMEOoJfE;
			}
		}

		private struct NlYVXsgbidZTvjzHSMoloYfZTvFc
		{
			public byte GhrdfXkEqKHxVVHhmNemBsSLrsKKA;

			public byte[] RyugQnzojOvubokiREOvHNdYshCP;

			public int RRZYzFuITRGrwlalxmrMgEkDNduq;

			public NlYVXsgbidZTvjzHSMoloYfZTvFc(byte P_0, byte[] P_1, int P_2)
			{
				GhrdfXkEqKHxVVHhmNemBsSLrsKKA = P_0;
				RyugQnzojOvubokiREOvHNdYshCP = P_1;
				RRZYzFuITRGrwlalxmrMgEkDNduq = P_2;
			}
		}

		protected class FeXSNHroWFXzJtxVUafBPWTVIyoE
		{
			public ushort zoIPiyIPOGmBxrflxjsulJoSZBTH;

			public ushort aBwJDRuKfxTjkBmAbnOQYjqAQlpj;

			public ushort HgFeJckLDhfKbpmXAirjHmeYzzY;

			public ushort ftcQlmBHuxPlQLXEhpGzYFBmUaLl;

			public virtual string rjXgzGeIhjmMlQyLgpRoWVtBqQHt()
			{
				return "min: " + zoIPiyIPOGmBxrflxjsulJoSZBTH + ", max: " + aBwJDRuKfxTjkBmAbnOQYjqAQlpj + ", zero: " + HgFeJckLDhfKbpmXAirjHmeYzzY + ", deadzone: " + ftcQlmBHuxPlQLXEhpGzYFBmUaLl;
			}
		}

		private const uint TsPltPalJMlJQTaBiZBtgRuVbIvk = 40u;

		private const float boNJUdGsUTCZQeFABlVzRSYDtUOeA = 0.025f;

		protected const byte INPUT_REPORT_ID_DEFAULT = 48;

		protected const byte INPUT_REPORT_ID_RESPONSE = 33;

		protected const byte OUTPUT_REPORT_COMMAND_GET_INPUT = 31;

		protected const byte OUTPUT_RUMBLE_AND_SUBCMD = 1;

		protected const byte OUTPUT_FW_UPDATE_PKT = 3;

		protected const byte OUTPUT_RUMBLE_ONLY = 16;

		protected const byte OUTPUT_MCU_DATA = 17;

		protected const byte OUTPUT_USB_CMD = 128;

		protected const byte SUBCMD_STATE = 0;

		protected const byte SUBCMD_MANUAL_BT_PAIRING = 1;

		protected const byte SUBCMD_REQ_DEV_INFO = 2;

		protected const byte SUBCMD_SET_REPORT_MODE = 3;

		protected const byte SUBCMD_TRIGGERS_ELAPSED = 4;

		protected const byte SUBCMD_GET_PAGE_LIST_STATE = 5;

		protected const byte SUBCMD_SET_HCI_STATE = 6;

		protected const byte SUBCMD_RESET_PAIRING_INFO = 7;

		protected const byte SUBCMD_LOW_POWER_MODE = 8;

		protected const byte SUBCMD_SPI_FLASH_READ = 16;

		protected const byte SUBCMD_SPI_FLASH_WRITE = 17;

		protected const byte SUBCMD_RESET_MCU = 32;

		protected const byte SUBCMD_SET_MCU_CONFIG = 33;

		protected const byte SUBCMD_SET_MCU_STATE = 34;

		protected const byte SUBCMD_SET_PLAYER_LIGHTS = 48;

		protected const byte SUBCMD_GET_PLAYER_LIGHTS = 49;

		protected const byte SUBCMD_SET_HOME_LIGHT = 56;

		protected const byte SUBCMD_ENABLE_IMU = 64;

		protected const byte SUBCMD_SET_IMU_SENSITIVITY = 65;

		protected const byte SUBCMD_WRITE_IMU_REG = 66;

		protected const byte SUBCMD_READ_IMU_REG = 67;

		protected const byte SUBCMD_ENABLE_VIBRATION = 72;

		protected const byte SUBCMD_GET_REGULATED_VOLTAGE = 80;

		protected const byte INPUT_BUTTON_EVENT = 63;

		protected const byte INPUT_SUBCMD_REPLY = 33;

		protected const byte INPUT_IMU_DATA = 48;

		protected const byte INPUT_MCU_DATA = 49;

		protected const byte INPUT_USB_RESPONSE = 129;

		protected const byte FEATURE_LAST_SUBCMD = 2;

		protected const byte FEATURE_OTA_FW_UPGRADE = 112;

		protected const byte FEATURE_SETUP_MEM_READ = 113;

		protected const byte FEATURE_MEM_READ = 114;

		protected const byte FEATURE_ERASE_MEM_SECTOR = 115;

		protected const byte FEATURE_MEM_WRITE = 116;

		protected const byte FEATURE_LAUNCH = 117;

		protected const byte USB_CMD_CONN_STATUS = 1;

		protected const byte USB_CMD_HANDSHAKE = 2;

		protected const byte USB_CMD_BAUDRATE_3M = 3;

		protected const byte USB_CMD_NO_TIMEOUT = 4;

		protected const byte USB_CMD_EN_TIMEOUT = 5;

		protected const byte USB_RESET = 6;

		protected const byte USB_PRE_HANDSHAKE = 145;

		protected const byte USB_SEND_UART = 146;

		protected const ushort CAL_DATA_START = 24637;

		protected const ushort CAL_DATA_END = 24654;

		protected const ushort CAL_DATA_SIZE = 18;

		protected const int MIN_INPUT_REPORT_SIZE = 49;

		protected const int SUBCOMMAND_INPUT_REPORT_SIZE = 49;

		protected const float VIBRATION_FREQUENCY_LOW_MIN = 40.875885f;

		protected const float VIBRATION_FREQUENCY_LOW_MAX = 626.28613f;

		protected const float VIBRATION_FREQUENCY_HIGH_MIN = 81.75177f;

		protected const float VIBRATION_FREQUENCY_HIGH_MAX = 1252.5723f;

		protected const float NOINPUTREPORT_REINIT_HACK_TIMEOUT_SEC = 1f;

		protected const int DEVICE_POLL_RATE_HZ = 66;

		protected const int HID_AXIS_MIN_VALUE = 0;

		protected const int HID_AXIS_MAX_VALUE = 65535;

		protected const int HID_AXIS_ZERO_VALUE = 32767;

		protected const int HID_AXIS_BITS = 16;

		protected const int HID_AXIS_BYTES = 2;

		private const int kMiBMSmlJwKveBQKZAuRBLwBDVCE = 4;

		private const string fMkirfvoAEDkNaSxpmiWASNWAGoTA = "Failed to allocate memory.";

		private const int TmtOXlAaJCueJclwtNCJoKViwNNu = 3;

		private int QgHBkDnqXeCJpCIXDwhlndhgBsPL;

		private const int DLunUpJzlllaQfnJFyLXWfsXYrwk = 3;

		private int WfHKTncIvOBdnfnWeJzeSIHgYuwO;

		protected readonly UkwlHqTHSgAsSUZxuAmREwAFjXVk _controllerType;

		protected readonly int _buttonCount;

		protected readonly int _axisCount;

		protected readonly int _vibrationMotorCount;

		private readonly IHIDDevice fIbGWIgWXILYfqPXNsNMaDWsEtrdb;

		private readonly HIDProperties lvsbSMTbMCLCClBubfdFwysLCCyf;

		private readonly bool gFVzUMOgHibUwBNOlWUYiwmtTodn;

		private readonly NativeBuffer tdUFWqhRpUGwBVwSHfxlFnIpKhyUA;

		private readonly NativeBuffer hjvKLUNgtJocnGbwTqePCdtHXqMQ;

		private readonly NativeBuffer vhaqmYJYZxsHOZCcvRgwTOHlmjNQ;

		private readonly byte[] AFJguxslXGpZACaIRCTbkZzcAZqF;

		private readonly NativeBuffer WYRByCbTQASIjUUfUBGyDsuxKCCb;

		private readonly NativeBuffer JcFBwNZYVlmFoHVMxhjnFlJpHPpjA;

		private svXcjurRenDjMJrGFPPkrmozhhdx RElKfsCnHjpjysolqwGsFicyRoAE;

		private byte uRoBxpTYkxKPFrknWfRRamwzOGeWA;

		private bool ApgDPhjGpCscXbyXNHUWTBiFOoQi;

		private uvVtdVuVbAxyQaowfnveTcqgPwCb[] LfokpdlawAGIwbjOdrbSBwSoSbHV;

		private FeXSNHroWFXzJtxVUafBPWTVIyoE[] SxInuuHiksuPekdiNXBfBbIMSBKG;

		private double nUgJImJqjDhMRCiCzRmlAbFGbbUeb;

		private ManualResetEvent iCCoPKWqBxskiDifdKZUIcGeOtEL;

		private gatGSYfjvpvEkCmeWorSElRmVCjwA KhZectbnTGTYTncqykDPbTKDMrMjB;

		private const int bfktgdUIuhrZvzwMHahwtHTCssQF = 100;

		private Dictionary<int, zCoeuqJvPRWZgayItRnxhDkGixdX> kMPpTNdZYKtSTZYeRMnQUbcQglOO;

		int IDriver_NintendoSwitchController.vibrationMotorCount => _vibrationMotorCount;

		ushort IHIDControllerExtension.vendorId => lvsbSMTbMCLCClBubfdFwysLCCyf.vendorId;

		ushort IHIDControllerExtension.productId => lvsbSMTbMCLCClBubfdFwysLCCyf.productId;

		string IHIDControllerExtension.productName => lvsbSMTbMCLCClBubfdFwysLCCyf.productName;

		string IHIDControllerExtension.manufacturer => lvsbSMTbMCLCClBubfdFwysLCCyf.manufacturer;

		ushort IHIDControllerExtension.usagePage => lvsbSMTbMCLCClBubfdFwysLCCyf.usagePage;

		ushort IHIDControllerExtension.usage => lvsbSMTbMCLCClBubfdFwysLCCyf.usage;

		private Dictionary<int, zCoeuqJvPRWZgayItRnxhDkGixdX> initializationCommands
		{
			get
			{
				if (kMPpTNdZYKtSTZYeRMnQUbcQglOO == null)
				{
					kMPpTNdZYKtSTZYeRMnQUbcQglOO = new Dictionary<int, zCoeuqJvPRWZgayItRnxhDkGixdX> { { 1, SqOdivBYscmNzmYdPTonkIGgZYZU } };
				}
				return kMPpTNdZYKtSTZYeRMnQUbcQglOO;
			}
		}

		public void GetVibration(int motorIndex, out float amplitudeLow, out float frequencyLow, out float amplitudeHigh, out float frequencyHigh)
		{
			if (motorIndex < 0 || motorIndex >= _vibrationMotorCount)
			{
				amplitudeLow = 0f;
				frequencyLow = 0f;
				amplitudeHigh = 0f;
				frequencyHigh = 0f;
			}
			else
			{
				qOFDFXISabmOPIMpaIMOBofHGKWtB qOFDFXISabmOPIMpaIMOBofHGKWtB2 = LfokpdlawAGIwbjOdrbSBwSoSbHV[motorIndex].BijxwCZQiOSKWCydHlChhWyBxXLg;
				amplitudeLow = qOFDFXISabmOPIMpaIMOBofHGKWtB2.MoKmwwdefJklsqySSjpGmJCsckDiA;
				frequencyLow = qOFDFXISabmOPIMpaIMOBofHGKWtB2.ppdLtlnDtXcOPAAKTNseGbvdPyWab;
				amplitudeHigh = qOFDFXISabmOPIMpaIMOBofHGKWtB2.hTzpWYUBnGFJhpQWJLwVELrCWhXj;
				frequencyHigh = qOFDFXISabmOPIMpaIMOBofHGKWtB2.UZjKXxemFhDZFtyPiunUZMEOoJfE;
			}
		}

		void IDriver_NintendoSwitchController.GetVibration(int motorIndex, out float amplitudeLow, out float frequencyLow, out float amplitudeHigh, out float frequencyHigh)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetVibration
			this.GetVibration(motorIndex, out amplitudeLow, out frequencyLow, out amplitudeHigh, out frequencyHigh);
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh)
		{
			SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, 0f, stopOtherMotors: false);
		}

		void IDriver_NintendoSwitchController.SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh);
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, bool stopOtherMotors)
		{
			SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, 0f, stopOtherMotors);
		}

		void IDriver_NintendoSwitchController.SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, bool stopOtherMotors)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, stopOtherMotors);
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration)
		{
			SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration, stopOtherMotors: false);
		}

		void IDriver_NintendoSwitchController.SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration);
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration, bool stopOtherMotors)
		{
			if (motorIndex >= 0 && motorIndex < _vibrationMotorCount)
			{
				if (stopOtherMotors)
				{
					IuqzICHmdMYQGCPFtwKViahwVBbo(motorIndex);
				}
				LfokpdlawAGIwbjOdrbSBwSoSbHV[motorIndex].pDmNAzYXRdNJSYjLqlLXpsiEdSBL(amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration);
				POjOiVobAbvPqXJyIOYYuplJJqSe(PaswCStrAkmQpcZYWcZPEJHLfUmk.Asynchronous);
			}
		}

		void IDriver_NintendoSwitchController.SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration, bool stopOtherMotors)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration, stopOtherMotors);
		}

		public void StopVibration(int motorIndex)
		{
			if (motorIndex >= 0 && motorIndex < _vibrationMotorCount)
			{
				LfokpdlawAGIwbjOdrbSBwSoSbHV[motorIndex].sqeZkQldjHvSBVtljlhXKdJWjeNi();
				POjOiVobAbvPqXJyIOYYuplJJqSe(PaswCStrAkmQpcZYWcZPEJHLfUmk.Asynchronous);
			}
		}

		void IDriver_NintendoSwitchController.StopVibration(int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration(motorIndex);
		}

		public void StopVibration()
		{
			StopVibration(PaswCStrAkmQpcZYWcZPEJHLfUmk.Asynchronous);
		}

		void IDriver_NintendoSwitchController.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		private void StopVibration(PaswCStrAkmQpcZYWcZPEJHLfUmk asyncMode)
		{
			for (int i = 0; i < _vibrationMotorCount; i++)
			{
				LfokpdlawAGIwbjOdrbSBwSoSbHV[i].sqeZkQldjHvSBVtljlhXKdJWjeNi();
			}
			POjOiVobAbvPqXJyIOYYuplJJqSe(asyncMode);
		}

		private void IuqzICHmdMYQGCPFtwKViahwVBbo(int P_0)
		{
			for (int i = 0; i < LfokpdlawAGIwbjOdrbSBwSoSbHV.Length; i++)
			{
				if (i != P_0)
				{
					LfokpdlawAGIwbjOdrbSBwSoSbHV[i].sqeZkQldjHvSBVtljlhXKdJWjeNi();
				}
			}
		}

		protected NintendoSwitchGamepadDriver(InitArgs P_0, UkwlHqTHSgAsSUZxuAmREwAFjXVk P_1, int P_2, int P_3, int P_4)
			: base(P_0)
		{
			_controllerType = P_1;
			_buttonCount = P_2;
			_axisCount = P_3;
			_vibrationMotorCount = P_4;
			fIbGWIgWXILYfqPXNsNMaDWsEtrdb = P_0.hidDevice;
			lvsbSMTbMCLCClBubfdFwysLCCyf = P_0.hidDevice.properties;
			gFVzUMOgHibUwBNOlWUYiwmtTodn = P_0.connectionType == OzbKZwmCsAMtNgCdYlCwZEMUUFwG.Bluetooth;
			if (lvsbSMTbMCLCClBubfdFwysLCCyf.maxOutputReportLength < 2)
			{
				throw new ArgumentException("Output report buffer is too small.");
			}
			tdUFWqhRpUGwBVwSHfxlFnIpKhyUA = LvNZYdMlEyAWQQVfsKosysbpFyaN(lvsbSMTbMCLCClBubfdFwysLCCyf.maxInputReportLength);
			hjvKLUNgtJocnGbwTqePCdtHXqMQ = LvNZYdMlEyAWQQVfsKosysbpFyaN(lvsbSMTbMCLCClBubfdFwysLCCyf.maxOutputReportLength);
			vhaqmYJYZxsHOZCcvRgwTOHlmjNQ = LvNZYdMlEyAWQQVfsKosysbpFyaN(32);
			AFJguxslXGpZACaIRCTbkZzcAZqF = new byte[lvsbSMTbMCLCClBubfdFwysLCCyf.maxInputReportLength];
			WYRByCbTQASIjUUfUBGyDsuxKCCb = LvNZYdMlEyAWQQVfsKosysbpFyaN(lvsbSMTbMCLCClBubfdFwysLCCyf.maxOutputReportLength);
			JcFBwNZYVlmFoHVMxhjnFlJpHPpjA = LvNZYdMlEyAWQQVfsKosysbpFyaN(49);
			RElKfsCnHjpjysolqwGsFicyRoAE = new svXcjurRenDjMJrGFPPkrmozhhdx(hjvKLUNgtJocnGbwTqePCdtHXqMQ.Pointer, hjvKLUNgtJocnGbwTqePCdtHXqMQ.Length, hjvKLUNgtJocnGbwTqePCdtHXqMQ.Length);
			ReInput.ApplicationPauseChangedEvent += UHGtunwIccIQAHxpkMyAFUkKWOuAA;
			buttons = new JdXatRCvdrGKOPnZjOPQbsdPzHroA[P_2];
			for (int i = 0; i < P_2; i++)
			{
				buttons[i] = new JdXatRCvdrGKOPnZjOPQbsdPzHroA(48, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			SxInuuHiksuPekdiNXBfBbIMSBKG = new FeXSNHroWFXzJtxVUafBPWTVIyoE[_axisCount];
			vibrationMotors = new uctGEmIAndGsnBPlyPlnhlfoOqoG[P_4];
			for (int j = 0; j < vibrationMotors.Length; j++)
			{
				vibrationMotors[j] = new uctGEmIAndGsnBPlyPlnhlfoOqoG(0, 255);
			}
			LfokpdlawAGIwbjOdrbSBwSoSbHV = new uvVtdVuVbAxyQaowfnveTcqgPwCb[P_4];
			for (int k = 0; k < LfokpdlawAGIwbjOdrbSBwSoSbHV.Length; k++)
			{
				LfokpdlawAGIwbjOdrbSBwSoSbHV[k] = new uvVtdVuVbAxyQaowfnveTcqgPwCb(vibrationMotors[k]);
			}
		}

		protected override void OnInitialize()
		{
			KhZectbnTGTYTncqykDPbTKDMrMjB = gatGSYfjvpvEkCmeWorSElRmVCjwA.None;
			iCCoPKWqBxskiDifdKZUIcGeOtEL = new ManualResetEvent(initialState: false);
			try
			{
				new Thread((ThreadStart)delegate
				{
					try
					{
						KhZectbnTGTYTncqykDPbTKDMrMjB = wkBEbSkkeiAHsgRwDwILbCjLRxww();
					}
					catch
					{
						KhZectbnTGTYTncqykDPbTKDMrMjB = gatGSYfjvpvEkCmeWorSElRmVCjwA.Fail;
					}
					iCCoPKWqBxskiDifdKZUIcGeOtEL.Set();
				}).Start();
			}
			catch
			{
				iCCoPKWqBxskiDifdKZUIcGeOtEL.Set();
			}
		}

		private gatGSYfjvpvEkCmeWorSElRmVCjwA wkBEbSkkeiAHsgRwDwILbCjLRxww()
		{
			Action action = delegate
			{
				if (ApgDPhjGpCscXbyXNHUWTBiFOoQi)
				{
					throw new NqwGnkcjGovKeUBLmgtBglJRwzyl();
				}
			};
			int num = 0;
			while (num < 3)
			{
				action();
				try
				{
					hjvKLUNgtJocnGbwTqePCdtHXqMQ.Clear();
					if (!gFVzUMOgHibUwBNOlWUYiwmtTodn)
					{
						NativeBuffer nativeBuffer = hjvKLUNgtJocnGbwTqePCdtHXqMQ;
						action();
						UBFEiDMbElLTPDfjWTWiRhIDMkwR(OytVNqdatKzQmEKZRiedzsMxGWbc.GetUsbStatus, 5u, 500u);
						action();
						nativeBuffer[0] = 128;
						nativeBuffer[1] = 2;
						if (!ScXuvcwuJCENbaGPIfcLdsLqANEAb(PaswCStrAkmQpcZYWcZPEJHLfUmk.Synchronous))
						{
							throw new Exception();
						}
						action();
						nativeBuffer[0] = 128;
						nativeBuffer[1] = 3;
						if (!ScXuvcwuJCENbaGPIfcLdsLqANEAb(PaswCStrAkmQpcZYWcZPEJHLfUmk.Synchronous))
						{
							throw new Exception();
						}
						action();
						nativeBuffer[0] = 128;
						nativeBuffer[1] = 2;
						if (!ScXuvcwuJCENbaGPIfcLdsLqANEAb(PaswCStrAkmQpcZYWcZPEJHLfUmk.Synchronous))
						{
							throw new Exception();
						}
						action();
						nativeBuffer[0] = 128;
						nativeBuffer[1] = 4;
						if (!ScXuvcwuJCENbaGPIfcLdsLqANEAb(PaswCStrAkmQpcZYWcZPEJHLfUmk.Synchronous))
						{
							throw new Exception();
						}
					}
					action();
					if (!GpRtVFmMIMgqrLoNJpxRiMkdAihA(new NlYVXsgbidZTvjzHSMoloYfZTvFc(72, new byte[1] { 1 }, 1), AFJguxslXGpZACaIRCTbkZzcAZqF, action))
					{
						throw new Exception();
					}
					action();
					if (!GpRtVFmMIMgqrLoNJpxRiMkdAihA(new NlYVXsgbidZTvjzHSMoloYfZTvFc(3, new byte[1] { 48 }, 1), AFJguxslXGpZACaIRCTbkZzcAZqF, action))
					{
						throw new Exception();
					}
					action();
					VWXHlxooiOFmdGhtHPEomxZgUuJX(action);
					action();
					if (!rupWDwclWRzpPYwnqNMNTtHTljds(action))
					{
						throw new Exception();
					}
					return gatGSYfjvpvEkCmeWorSElRmVCjwA.Success;
				}
				catch (NqwGnkcjGovKeUBLmgtBglJRwzyl)
				{
					return gatGSYfjvpvEkCmeWorSElRmVCjwA.Fail;
				}
				catch
				{
					num++;
				}
			}
			throw new Exception();
		}

		private bool UBFEiDMbElLTPDfjWTWiRhIDMkwR(OytVNqdatKzQmEKZRiedzsMxGWbc P_0, uint P_1, uint P_2)
		{
			if (!initializationCommands.TryGetValue((int)P_0, out var value))
			{
				throw new Exception();
			}
			uint num = 0u;
			do
			{
				if (value(P_2))
				{
					return true;
				}
				num++;
			}
			while (num <= P_1);
			throw new Exception();
		}

		private bool SqOdivBYscmNzmYdPTonkIGgZYZU(uint P_0)
		{
			NativeBuffer nativeBuffer = hjvKLUNgtJocnGbwTqePCdtHXqMQ;
			nativeBuffer.Clear();
			nativeBuffer[0] = 128;
			nativeBuffer[1] = 1;
			if (!ScXuvcwuJCENbaGPIfcLdsLqANEAb(PaswCStrAkmQpcZYWcZPEJHLfUmk.Synchronous))
			{
				return false;
			}
			double num = ReInput.realTime + (double)((float)P_0 * 0.001f);
			do
			{
				IL_0069:
				if (fIbGWIgWXILYfqPXNsNMaDWsEtrdb.ReadSync(JcFBwNZYVlmFoHVMxhjnFlJpHPpjA, JcFBwNZYVlmFoHVMxhjnFlJpHPpjA.Length, 100))
				{
					if (JcFBwNZYVlmFoHVMxhjnFlJpHPpjA[0] == 129 && JcFBwNZYVlmFoHVMxhjnFlJpHPpjA[1] == 1)
					{
						return true;
					}
					if (!(ReInput.realTime >= num))
					{
						goto IL_0069;
					}
				}
			}
			while (ReInput.realTime < num);
			return false;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			switch (KhZectbnTGTYTncqykDPbTKDMrMjB)
			{
			case gatGSYfjvpvEkCmeWorSElRmVCjwA.Success:
				KhZectbnTGTYTncqykDPbTKDMrMjB = gatGSYfjvpvEkCmeWorSElRmVCjwA.Ready;
				InitializationFinished(initialized: true);
				break;
			case gatGSYfjvpvEkCmeWorSElRmVCjwA.Fail:
				if (!base.disposed)
				{
					InitializationFinished(initialized: false);
					Dispose();
					Error(MiNaIzDPKzaXZdztgHayeKZcnRCwb.AsyncInitialization);
				}
				break;
			}
			if (!base.disposed && QgHBkDnqXeCJpCIXDwhlndhgBsPL >= 3)
			{
				if (WfHKTncIvOBdnfnWeJzeSIHgYuwO < 3)
				{
					QgHBkDnqXeCJpCIXDwhlndhgBsPL = 0;
					KhZectbnTGTYTncqykDPbTKDMrMjB = gatGSYfjvpvEkCmeWorSElRmVCjwA.None;
					WfHKTncIvOBdnfnWeJzeSIHgYuwO++;
					OnInitialize();
				}
				else
				{
					KhZectbnTGTYTncqykDPbTKDMrMjB = gatGSYfjvpvEkCmeWorSElRmVCjwA.Fail;
					Dispose();
					Error(MiNaIzDPKzaXZdztgHayeKZcnRCwb.AsyncInitialization);
				}
			}
			if (KhZectbnTGTYTncqykDPbTKDMrMjB != gatGSYfjvpvEkCmeWorSElRmVCjwA.Ready)
			{
				return;
			}
			double realTime = ReInput.realTime;
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < LfokpdlawAGIwbjOdrbSBwSoSbHV.Length; i++)
			{
				if (LfokpdlawAGIwbjOdrbSBwSoSbHV[i].zdcIglaUBwmYzFTKwEeqiACERsKjB(realTime))
				{
					flag = true;
				}
				if (LfokpdlawAGIwbjOdrbSBwSoSbHV[i].RSsPFKdephtbWwICJlKcqUfTjOAN)
				{
					flag2 = true;
				}
			}
			if (flag || (flag2 && realTime >= nUgJImJqjDhMRCiCzRmlAbFGbbUeb + 0.02500000037252903))
			{
				POjOiVobAbvPqXJyIOYYuplJJqSe(PaswCStrAkmQpcZYWcZPEJHLfUmk.Asynchronous);
			}
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (KhZectbnTGTYTncqykDPbTKDMrMjB != gatGSYfjvpvEkCmeWorSElRmVCjwA.Ready)
			{
				return false;
			}
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (tdUFWqhRpUGwBVwSHfxlFnIpKhyUA.Length < 49)
			{
				return false;
			}
			switch (Marshal.ReadByte(inputReportPtr, 0))
			{
			case 63:
				QgHBkDnqXeCJpCIXDwhlndhgBsPL++;
				return false;
			default:
				return false;
			case 33:
			case 48:
			{
				if (QgHBkDnqXeCJpCIXDwhlndhgBsPL > 0)
				{
					QgHBkDnqXeCJpCIXDwhlndhgBsPL = 0;
					WfHKTncIvOBdnfnWeJzeSIHgYuwO = 0;
				}
				int numBytesToWrite = Math.Min(inputReportLength, tdUFWqhRpUGwBVwSHfxlFnIpKhyUA.Length);
				tdUFWqhRpUGwBVwSHfxlFnIpKhyUA.Write(inputReportPtr, inputReportLength, numBytesToWrite);
				tdUFWqhRpUGwBVwSHfxlFnIpKhyUA.Write((byte)48, 0);
				UpdateButtons(tdUFWqhRpUGwBVwSHfxlFnIpKhyUA, timestamp);
				VJJORtyhxtIZFDAvjUdtXgBUbPYD[] elements = axes;
				UpdateElements(elements, tdUFWqhRpUGwBVwSHfxlFnIpKhyUA, timestamp);
				return true;
			}
			}
		}

		protected abstract void UpdateButtons(NativeBuffer inputReport, double timestamp);

		protected abstract void UpdateElements(VJJORtyhxtIZFDAvjUdtXgBUbPYD[] elements, NativeBuffer inputReport, double timestamp);

		private bool GpRtVFmMIMgqrLoNJpxRiMkdAihA(NlYVXsgbidZTvjzHSMoloYfZTvFc P_0, byte[] P_1, Action P_2)
		{
			try
			{
				P_2();
				if (P_0.RyugQnzojOvubokiREOvHNdYshCP.Length + 11 > WYRByCbTQASIjUUfUBGyDsuxKCCb.Length)
				{
					return false;
				}
				xNbGrrCuZrbAIHzDCkdCoOLtLquX(WYRByCbTQASIjUUfUBGyDsuxKCCb);
				WYRByCbTQASIjUUfUBGyDsuxKCCb[10] = P_0.GhrdfXkEqKHxVVHhmNemBsSLrsKKA;
				WYRByCbTQASIjUUfUBGyDsuxKCCb.TryWriteBytes(P_0.RyugQnzojOvubokiREOvHNdYshCP, P_0.RRZYzFuITRGrwlalxmrMgEkDNduq, 11);
				int num = 3;
				bool flag = false;
				int num2 = 0;
				double num3 = 0.0;
				while (fIbGWIgWXILYfqPXNsNMaDWsEtrdb.ReadSync(JcFBwNZYVlmFoHVMxhjnFlJpHPpjA, JcFBwNZYVlmFoHVMxhjnFlJpHPpjA.Length, 1))
				{
					P_2();
				}
				for (int i = 0; i < num; i++)
				{
					P_2();
					Array.Clear(P_1, 0, P_1.Length);
					JcFBwNZYVlmFoHVMxhjnFlJpHPpjA.Clear();
					FjezuZXbowGsjhBFOnITJsjMwPuh(WYRByCbTQASIjUUfUBGyDsuxKCCb, P_0.GhrdfXkEqKHxVVHhmNemBsSLrsKKA);
					num3 = ReInput.realTime;
					if (i == 0)
					{
						_ = ReInput.realTime;
					}
					int num4 = 0;
					int num5 = 0;
					int num6 = 0;
					while (true)
					{
						P_2();
						if (ReInput.realTime >= num3 + 1.0)
						{
							break;
						}
						if (fIbGWIgWXILYfqPXNsNMaDWsEtrdb.ReadSync(JcFBwNZYVlmFoHVMxhjnFlJpHPpjA, JcFBwNZYVlmFoHVMxhjnFlJpHPpjA.Length, 200))
						{
							num6++;
							if (JcFBwNZYVlmFoHVMxhjnFlJpHPpjA[0] == 33)
							{
								if (JcFBwNZYVlmFoHVMxhjnFlJpHPpjA[14] == P_0.GhrdfXkEqKHxVVHhmNemBsSLrsKKA)
								{
									flag = true;
									_ = ReInput.realTime;
									break;
								}
								num4++;
								num2++;
							}
						}
						else
						{
							num5++;
						}
					}
					if (flag)
					{
						break;
					}
				}
				if (flag)
				{
					JcFBwNZYVlmFoHVMxhjnFlJpHPpjA.Read(P_1, JcFBwNZYVlmFoHVMxhjnFlJpHPpjA.Length);
				}
				return flag;
			}
			catch (NqwGnkcjGovKeUBLmgtBglJRwzyl)
			{
				throw;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private bool FjezuZXbowGsjhBFOnITJsjMwPuh(NativeBuffer P_0, byte P_1)
		{
			if (!fIbGWIgWXILYfqPXNsNMaDWsEtrdb.WriteSync(new svXcjurRenDjMJrGFPPkrmozhhdx(P_0, P_0.Length, P_0.Length), 1000))
			{
				return false;
			}
			return true;
		}

		private void xNbGrrCuZrbAIHzDCkdCoOLtLquX(NativeBuffer P_0)
		{
			P_0.Clear();
			P_0[0] = 1;
			P_0[1] = OTTLhOwGtqaLrKVtvBpTxuhCtJPeA();
			ajNuJfIcHrBOaYuJhEivxkQBnidf(P_0, 2);
		}

		private void ajNuJfIcHrBOaYuJhEivxkQBnidf(NativeBuffer P_0, int P_1)
		{
			if (_controllerType == UkwlHqTHSgAsSUZxuAmREwAFjXVk.JoyConRight)
			{
				P_1 += 4;
			}
			for (int i = 0; i < LfokpdlawAGIwbjOdrbSBwSoSbHV.Length; i++)
			{
				WvkSIOhbXpsQavruHIiWoaacrwtj(P_0, P_1, LfokpdlawAGIwbjOdrbSBwSoSbHV[i].BijxwCZQiOSKWCydHlChhWyBxXLg);
				P_1 += 4;
			}
		}

		private static void WvkSIOhbXpsQavruHIiWoaacrwtj(NativeBuffer P_0, int P_1, qOFDFXISabmOPIMpaIMOBofHGKWtB P_2)
		{
			if (P_1 + 4 >= P_0.Length)
			{
				return;
			}
			if (P_2.MoKmwwdefJklsqySSjpGmJCsckDiA == 0f && P_2.hTzpWYUBnGFJhpQWJLwVELrCWhXj == 0f)
			{
				P_0[P_1] = 0;
				P_0[1 + P_1] = 1;
				P_0[2 + P_1] = 64;
				P_0[3 + P_1] = 64;
				return;
			}
			ushort num = (ushort)((Math.Round(32.0 * Math.Log(P_2.UZjKXxemFhDZFtyPiunUZMEOoJfE * 0.1f, 2.0)) - 96.0) * 4.0);
			byte b = (byte)(Math.Round(32.0 * Math.Log(P_2.ppdLtlnDtXcOPAAKTNseGbvdPyWab * 0.1f, 2.0)) - 64.0);
			byte b2 = CtDTEfVYSLrrEEDQAnrUckDJfpcJA(P_2.hTzpWYUBnGFJhpQWJLwVELrCWhXj);
			ushort num2 = (ushort)(Math.Round((double)(int)CtDTEfVYSLrrEEDQAnrUckDJfpcJA(P_2.MoKmwwdefJklsqySSjpGmJCsckDiA)) * 0.5);
			byte num3 = (byte)(num2 % 2);
			if (num3 > 0)
			{
				num2--;
			}
			num2 >>= 1;
			num2 += 64;
			if (num3 > 0)
			{
				num2 |= 0x8000;
			}
			b2 = (byte)(b2 - b2 % 2);
			P_0[P_1] = (byte)(num & 0xFF);
			P_0[1 + P_1] = (byte)(((num >> 8) & 0xFF) + b2);
			P_0[2 + P_1] = (byte)(((num2 >> 8) & 0xFF) + b);
			P_0[3 + P_1] = (byte)(num2 & 0xFF);
		}

		private static byte CtDTEfVYSLrrEEDQAnrUckDJfpcJA(float P_0)
		{
			if (P_0 < 0.01f)
			{
				return 0;
			}
			if ((double)P_0 < 0.117)
			{
				return (byte)((Math.Log(P_0 * 1000f, 2.0) * 32.0 - 96.0) / (5.0 - Math.Pow(P_0, 2.0)) - 1.0);
			}
			if ((double)P_0 < 0.23)
			{
				return (byte)(Math.Log(P_0 * 1000f, 2.0) * 32.0 - 96.0 - 92.0);
			}
			return (byte)((Math.Log(P_0 * 1000f, 2.0) * 32.0 - 96.0) * 2.0 - 246.0);
		}

		private void POjOiVobAbvPqXJyIOYYuplJJqSe(PaswCStrAkmQpcZYWcZPEJHLfUmk P_0)
		{
			if (hjvKLUNgtJocnGbwTqePCdtHXqMQ.Length >= 2 + LfokpdlawAGIwbjOdrbSBwSoSbHV.Length * 4)
			{
				hjvKLUNgtJocnGbwTqePCdtHXqMQ.Clear();
				hjvKLUNgtJocnGbwTqePCdtHXqMQ[0] = 16;
				hjvKLUNgtJocnGbwTqePCdtHXqMQ[1] = OTTLhOwGtqaLrKVtvBpTxuhCtJPeA();
				ajNuJfIcHrBOaYuJhEivxkQBnidf(hjvKLUNgtJocnGbwTqePCdtHXqMQ, 2);
				if (ScXuvcwuJCENbaGPIfcLdsLqANEAb(P_0))
				{
					nUgJImJqjDhMRCiCzRmlAbFGbbUeb = ReInput.realTime;
				}
			}
		}

		private bool VWXHlxooiOFmdGhtHPEomxZgUuJX(Action P_0)
		{
			byte[] array = new byte[25];
			ArrayTools.Fill(array, byte.MaxValue);
			array[0] = 24;
			array[1] = 1;
			return GpRtVFmMIMgqrLoNJpxRiMkdAihA(new NlYVXsgbidZTvjzHSMoloYfZTvFc(56, array, 25), AFJguxslXGpZACaIRCTbkZzcAZqF, P_0);
		}

		private bool igtAHhRIzhZYXzHQInsQTbhiioKI(bool P_0, Action P_1)
		{
			byte[] array = new byte[25];
			ArrayTools.Fill(array, byte.MaxValue);
			if (P_0)
			{
				array[0] = 31;
				array[1] = 240;
			}
			else
			{
				array[0] = 16;
				array[1] = 1;
			}
			return GpRtVFmMIMgqrLoNJpxRiMkdAihA(new NlYVXsgbidZTvjzHSMoloYfZTvFc(56, array, 25), AFJguxslXGpZACaIRCTbkZzcAZqF, P_1);
		}

		private bool sYJRVoWsbQeRXDzAQujTxesRpvlg(byte P_0, byte P_1, byte P_2, byte[] P_3, Action P_4)
		{
			byte[] array = new byte[5] { P_1, P_0, 0, 0, P_2 };
			bool flag = false;
			for (int i = 0; i < 10; i++)
			{
				if (GpRtVFmMIMgqrLoNJpxRiMkdAihA(new NlYVXsgbidZTvjzHSMoloYfZTvFc(16, array, array.Length), P_3, P_4) && P_3[15] == P_1 && P_3[16] == P_0)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
			Array.Copy(P_3, 20, P_3, 0, P_2);
			ArrayTools.Fill(P_3, (byte)0, (int)P_2, P_3.Length - P_2);
			return true;
		}

		private bool ScXuvcwuJCENbaGPIfcLdsLqANEAb(PaswCStrAkmQpcZYWcZPEJHLfUmk P_0)
		{
			switch (P_0)
			{
			case PaswCStrAkmQpcZYWcZPEJHLfUmk.Synchronous:
				return fIbGWIgWXILYfqPXNsNMaDWsEtrdb.WriteSync(RElKfsCnHjpjysolqwGsFicyRoAE, 0);
			case PaswCStrAkmQpcZYWcZPEJHLfUmk.Asynchronous:
				fIbGWIgWXILYfqPXNsNMaDWsEtrdb.WriteAsync(RElKfsCnHjpjysolqwGsFicyRoAE, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private byte OTTLhOwGtqaLrKVtvBpTxuhCtJPeA()
		{
			if (uRoBxpTYkxKPFrknWfRRamwzOGeWA == 15)
			{
				uRoBxpTYkxKPFrknWfRRamwzOGeWA = 0;
			}
			else
			{
				uRoBxpTYkxKPFrknWfRRamwzOGeWA++;
			}
			return uRoBxpTYkxKPFrknWfRRamwzOGeWA;
		}

		private bool rupWDwclWRzpPYwnqNMNTtHTljds(Action P_0)
		{
			bool flag = false;
			bool flag2 = _controllerType == UkwlHqTHSgAsSUZxuAmREwAFjXVk.JoyConLeft || _controllerType == UkwlHqTHSgAsSUZxuAmREwAFjXVk.ProController;
			Array.Clear(SxInuuHiksuPekdiNXBfBbIMSBKG, 0, SxInuuHiksuPekdiNXBfBbIMSBKG.Length);
			bool flag3 = false;
			if (sYJRVoWsbQeRXDzAQujTxesRpvlg(128, (byte)(flag2 ? 18 : 29), 9, AFJguxslXGpZACaIRCTbkZzcAZqF, P_0))
			{
				for (int i = 0; i < 9; i++)
				{
					if (AFJguxslXGpZACaIRCTbkZzcAZqF[i] != byte.MaxValue)
					{
						flag3 = true;
					}
				}
			}
			if (!flag3 && sYJRVoWsbQeRXDzAQujTxesRpvlg(96, (byte)(flag2 ? 61 : 70), 9, AFJguxslXGpZACaIRCTbkZzcAZqF, P_0))
			{
				flag3 = true;
			}
			if (flag3)
			{
				FeXSNHroWFXzJtxVUafBPWTVIyoE feXSNHroWFXzJtxVUafBPWTVIyoE = new FeXSNHroWFXzJtxVUafBPWTVIyoE();
				FeXSNHroWFXzJtxVUafBPWTVIyoE feXSNHroWFXzJtxVUafBPWTVIyoE2 = new FeXSNHroWFXzJtxVUafBPWTVIyoE();
				yIkQLUcTWmHbOxPOAitUNVCTAmucA(AFJguxslXGpZACaIRCTbkZzcAZqF, feXSNHroWFXzJtxVUafBPWTVIyoE, feXSNHroWFXzJtxVUafBPWTVIyoE2, flag2);
				SxInuuHiksuPekdiNXBfBbIMSBKG[0] = feXSNHroWFXzJtxVUafBPWTVIyoE;
				SxInuuHiksuPekdiNXBfBbIMSBKG[1] = feXSNHroWFXzJtxVUafBPWTVIyoE2;
				flag = true;
				if (sYJRVoWsbQeRXDzAQujTxesRpvlg(96, (byte)(flag2 ? 134 : 152), 16, AFJguxslXGpZACaIRCTbkZzcAZqF, P_0))
				{
					EZzCbDtwNpGXWAOqFSozEKNNILrqA(AFJguxslXGpZACaIRCTbkZzcAZqF, feXSNHroWFXzJtxVUafBPWTVIyoE, feXSNHroWFXzJtxVUafBPWTVIyoE2);
				}
			}
			else
			{
				flag = false;
			}
			if (_controllerType == UkwlHqTHSgAsSUZxuAmREwAFjXVk.ProController)
			{
				bool flag4 = false;
				if (sYJRVoWsbQeRXDzAQujTxesRpvlg(128, (byte)((!flag2) ? 18 : 29), 9, AFJguxslXGpZACaIRCTbkZzcAZqF, P_0))
				{
					for (int j = 0; j < 9; j++)
					{
						if (AFJguxslXGpZACaIRCTbkZzcAZqF[j] != byte.MaxValue)
						{
							flag4 = true;
						}
					}
				}
				if (!flag4 && sYJRVoWsbQeRXDzAQujTxesRpvlg(96, (byte)((!flag2) ? 61 : 70), 9, AFJguxslXGpZACaIRCTbkZzcAZqF, P_0))
				{
					flag4 = true;
				}
				if (flag4)
				{
					FeXSNHroWFXzJtxVUafBPWTVIyoE feXSNHroWFXzJtxVUafBPWTVIyoE3 = new FeXSNHroWFXzJtxVUafBPWTVIyoE();
					FeXSNHroWFXzJtxVUafBPWTVIyoE feXSNHroWFXzJtxVUafBPWTVIyoE4 = new FeXSNHroWFXzJtxVUafBPWTVIyoE();
					yIkQLUcTWmHbOxPOAitUNVCTAmucA(AFJguxslXGpZACaIRCTbkZzcAZqF, feXSNHroWFXzJtxVUafBPWTVIyoE3, feXSNHroWFXzJtxVUafBPWTVIyoE4, !flag2);
					SxInuuHiksuPekdiNXBfBbIMSBKG[2] = feXSNHroWFXzJtxVUafBPWTVIyoE3;
					SxInuuHiksuPekdiNXBfBbIMSBKG[3] = feXSNHroWFXzJtxVUafBPWTVIyoE4;
					flag = true;
					if (sYJRVoWsbQeRXDzAQujTxesRpvlg(96, (byte)((!flag2) ? 134 : 152), 16, AFJguxslXGpZACaIRCTbkZzcAZqF, P_0))
					{
						EZzCbDtwNpGXWAOqFSozEKNNILrqA(AFJguxslXGpZACaIRCTbkZzcAZqF, feXSNHroWFXzJtxVUafBPWTVIyoE3, feXSNHroWFXzJtxVUafBPWTVIyoE4);
					}
				}
				else
				{
					flag = false;
				}
			}
			return flag;
		}

		private static void yIkQLUcTWmHbOxPOAitUNVCTAmucA(byte[] P_0, FeXSNHroWFXzJtxVUafBPWTVIyoE P_1, FeXSNHroWFXzJtxVUafBPWTVIyoE P_2, bool P_3)
		{
			ushort num = (ushort)(((P_0[1] << 8) & 0xF00) | P_0[0]);
			ushort num2 = (ushort)((P_0[2] << 4) | (P_0[1] >> 4));
			ushort num3 = (ushort)(((P_0[4] << 8) & 0xF00) | P_0[3]);
			ushort num4 = (ushort)((P_0[5] << 4) | (P_0[4] >> 4));
			ushort num5 = (ushort)(((P_0[7] << 8) & 0xF00) | P_0[6]);
			ushort num6 = (ushort)((P_0[8] << 4) | (P_0[7] >> 4));
			if (P_3)
			{
				P_1.aBwJDRuKfxTjkBmAbnOQYjqAQlpj = num;
				P_2.aBwJDRuKfxTjkBmAbnOQYjqAQlpj = num2;
				P_1.HgFeJckLDhfKbpmXAirjHmeYzzY = num3;
				P_2.HgFeJckLDhfKbpmXAirjHmeYzzY = num4;
				P_1.zoIPiyIPOGmBxrflxjsulJoSZBTH = num5;
				P_2.zoIPiyIPOGmBxrflxjsulJoSZBTH = num6;
			}
			else
			{
				P_1.HgFeJckLDhfKbpmXAirjHmeYzzY = num;
				P_2.HgFeJckLDhfKbpmXAirjHmeYzzY = num2;
				P_1.zoIPiyIPOGmBxrflxjsulJoSZBTH = num3;
				P_2.zoIPiyIPOGmBxrflxjsulJoSZBTH = num4;
				P_1.aBwJDRuKfxTjkBmAbnOQYjqAQlpj = num5;
				P_2.aBwJDRuKfxTjkBmAbnOQYjqAQlpj = num6;
			}
		}

		private static void EZzCbDtwNpGXWAOqFSozEKNNILrqA(byte[] P_0, FeXSNHroWFXzJtxVUafBPWTVIyoE P_1, FeXSNHroWFXzJtxVUafBPWTVIyoE P_2)
		{
			P_1.ftcQlmBHuxPlQLXEhpGzYFBmUaLl = (ushort)(((P_0[4] << 8) & 0xF00) | P_0[3]);
			P_2.ftcQlmBHuxPlQLXEhpGzYFBmUaLl = P_1.ftcQlmBHuxPlQLXEhpGzYFBmUaLl;
		}

		protected bool GetCalibratedStickValue(ushort valueX, ushort valueY, FeXSNHroWFXzJtxVUafBPWTVIyoE calX, FeXSNHroWFXzJtxVUafBPWTVIyoE calY, out ushort calibratedX, out ushort calibratedY)
		{
			calibratedX = 32767;
			calibratedY = 32767;
			if (calX == null || calY == null)
			{
				return false;
			}
			ushort num = MathTools.Max(calX.ftcQlmBHuxPlQLXEhpGzYFBmUaLl, calY.ftcQlmBHuxPlQLXEhpGzYFBmUaLl);
			int num2 = valueX - calX.HgFeJckLDhfKbpmXAirjHmeYzzY;
			int num3 = valueY - calY.HgFeJckLDhfKbpmXAirjHmeYzzY;
			if (Math.Abs(num2 * num2 + num3 * num3) <= num * num)
			{
				return false;
			}
			Vector2 vector = new Vector2(InputTools.TransformAxis2DComponentValue((int)valueX, (int)calX.HgFeJckLDhfKbpmXAirjHmeYzzY, calX.HgFeJckLDhfKbpmXAirjHmeYzzY - calX.zoIPiyIPOGmBxrflxjsulJoSZBTH, calX.HgFeJckLDhfKbpmXAirjHmeYzzY + calX.aBwJDRuKfxTjkBmAbnOQYjqAQlpj, 0f, -1f, 1f, clamp: false), InputTools.TransformAxis2DComponentValue((int)valueY, (int)calY.HgFeJckLDhfKbpmXAirjHmeYzzY, calY.HgFeJckLDhfKbpmXAirjHmeYzzY - calY.zoIPiyIPOGmBxrflxjsulJoSZBTH, calY.HgFeJckLDhfKbpmXAirjHmeYzzY + calY.aBwJDRuKfxTjkBmAbnOQYjqAQlpj, 0f, -1f, 1f, clamp: false));
			float num4 = (float)(calX.zoIPiyIPOGmBxrflxjsulJoSZBTH + calX.aBwJDRuKfxTjkBmAbnOQYjqAQlpj + calY.zoIPiyIPOGmBxrflxjsulJoSZBTH + calY.aBwJDRuKfxTjkBmAbnOQYjqAQlpj) * 0.5f;
			float lowerDeadzone = (float)(int)num / (num4 * 0.5f);
			vector = InputTools.ApplyRadialDeadZone(vector.x, vector.y, lowerDeadzone, 0f, 1f, InputTools.ClampAxis2D.None);
			calibratedX = (ushort)MathTools.ValueInNewRange(vector.x, -1f, 1f, 0f, 65535f);
			calibratedY = (ushort)MathTools.ValueInNewRange(vector.y, -1f, 1f, 0f, 65535f);
			return true;
		}

		protected FeXSNHroWFXzJtxVUafBPWTVIyoE GetAxisCalibration(int index)
		{
			return SxInuuHiksuPekdiNXBfBbIMSBKG[index];
		}

		private void UHGtunwIccIQAHxpkMyAFUkKWOuAA(bool P_0)
		{
		}

		~NintendoSwitchGamepadDriver()
		{
			Dispose(disposing: false);
		}

		protected override void Dispose(bool disposing)
		{
			if (base.disposed)
			{
				return;
			}
			ApgDPhjGpCscXbyXNHUWTBiFOoQi = true;
			if (iCCoPKWqBxskiDifdKZUIcGeOtEL != null)
			{
				iCCoPKWqBxskiDifdKZUIcGeOtEL.WaitOne();
			}
			if (disposing)
			{
				ReInput.ApplicationPauseChangedEvent -= UHGtunwIccIQAHxpkMyAFUkKWOuAA;
				if (KhZectbnTGTYTncqykDPbTKDMrMjB != gatGSYfjvpvEkCmeWorSElRmVCjwA.Ready)
				{
					try
					{
						StopVibration(PaswCStrAkmQpcZYWcZPEJHLfUmk.Synchronous);
					}
					catch (Exception)
					{
					}
				}
				if (!gFVzUMOgHibUwBNOlWUYiwmtTodn && hjvKLUNgtJocnGbwTqePCdtHXqMQ != null)
				{
					hjvKLUNgtJocnGbwTqePCdtHXqMQ.Clear();
					hjvKLUNgtJocnGbwTqePCdtHXqMQ[0] = 128;
					hjvKLUNgtJocnGbwTqePCdtHXqMQ[1] = 5;
					try
					{
						fIbGWIgWXILYfqPXNsNMaDWsEtrdb.WriteSync(RElKfsCnHjpjysolqwGsFicyRoAE, 0);
					}
					catch
					{
					}
					hjvKLUNgtJocnGbwTqePCdtHXqMQ.Clear();
					hjvKLUNgtJocnGbwTqePCdtHXqMQ[0] = 128;
					hjvKLUNgtJocnGbwTqePCdtHXqMQ[1] = 6;
					try
					{
						fIbGWIgWXILYfqPXNsNMaDWsEtrdb.WriteSync(RElKfsCnHjpjysolqwGsFicyRoAE, 0);
					}
					catch
					{
					}
				}
				if (tdUFWqhRpUGwBVwSHfxlFnIpKhyUA != null)
				{
					tdUFWqhRpUGwBVwSHfxlFnIpKhyUA.Dispose();
				}
				if (hjvKLUNgtJocnGbwTqePCdtHXqMQ != null)
				{
					hjvKLUNgtJocnGbwTqePCdtHXqMQ.Dispose();
				}
				if (WYRByCbTQASIjUUfUBGyDsuxKCCb != null)
				{
					WYRByCbTQASIjUUfUBGyDsuxKCCb.Dispose();
				}
				if (JcFBwNZYVlmFoHVMxhjnFlJpHPpjA != null)
				{
					JcFBwNZYVlmFoHVMxhjnFlJpHPpjA.Dispose();
				}
				if (vhaqmYJYZxsHOZCcvRgwTOHlmjNQ == null)
				{
					vhaqmYJYZxsHOZCcvRgwTOHlmjNQ.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private static NativeBuffer LvNZYdMlEyAWQQVfsKosysbpFyaN(int P_0)
		{
			NativeBuffer nativeBuffer = new NativeBuffer(P_0);
			if (nativeBuffer.Length != P_0)
			{
				throw new Exception("Failed to allocate memory.");
			}
			return nativeBuffer;
		}

		[Conditional("DEBUG_THIS")]
		protected static void DLog(object msg)
		{
			if (msg != null)
			{
				Logger.Log("SwitchGamepadDriverBase: " + msg);
			}
		}

		[Conditional("DEBUG_THIS")]
		protected static void DLogWarning(object msg)
		{
			if (msg != null)
			{
				Logger.LogWarning("SwitchGamepadDriverBase: " + msg, requiredThreadSafety: true);
			}
		}

		[Conditional("DEBUG_THIS")]
		protected static void DLogError(object msg)
		{
			if (msg != null)
			{
				Logger.LogError("SwitchGamepadDriverBase: " + msg, requiredThreadSafety: true);
			}
		}

		[Conditional("DEBUG_THIS_DISPOSE")]
		protected static void DDisposeLog(object msg)
		{
			if (msg != null)
			{
				Logger.Log("SwitchGamepadDriverBase: " + msg);
			}
		}

		[CompilerGenerated]
		private void UKrEqAaUSfnljaeLBhIkMENRuMiVB()
		{
			try
			{
				KhZectbnTGTYTncqykDPbTKDMrMjB = wkBEbSkkeiAHsgRwDwILbCjLRxww();
			}
			catch
			{
				KhZectbnTGTYTncqykDPbTKDMrMjB = gatGSYfjvpvEkCmeWorSElRmVCjwA.Fail;
			}
			iCCoPKWqBxskiDifdKZUIcGeOtEL.Set();
		}

		[CompilerGenerated]
		private void MbANlYeFnFEDDKjukTXbCtREYMVJA()
		{
			if (ApgDPhjGpCscXbyXNHUWTBiFOoQi)
			{
				throw new NqwGnkcjGovKeUBLmgtBglJRwzyl();
			}
		}
	}
}
