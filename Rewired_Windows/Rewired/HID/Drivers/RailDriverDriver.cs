using System;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class RailDriverDriver : HIDDeviceDriver, IDisposable, IDriver_RailDriver, IControllerDriver, IHIDControllerExtension
	{
		private enum fpnupfMbvRbIzhaCDelEiUFAPVHCc
		{
			Speaker = 0,
			LED = 1
		}

		private const int GPyZQsmFhzojERTNFlVEbmRrWgjo = 1523;

		private const int qZwDlmGYCnWastteaDCbqUmycFgM = 210;

		private const int ceRudsXXIuUHzwxjolijPxJuCacC = 50;

		private const int SHNGukwNUBEttShcBXbsWuCowlys = 44;

		private const int JkugNZZjIPCcEaBbrpVVozwruVjJ = 6;

		private const int icljatamOPJcqzVgomFdEKYjbiGAA = 44;

		private const int AxCPxezrSFAwPNFppLrXzALAJHXU = 45;

		private const int pvVoeKLlnNDhHByDVUIMBCXPYkaL = 46;

		private const int bzXFNFqMymYamcFQUhDYxekMeirAA = 47;

		private const int xqBwLtOSXyJSMiNWBlxkKEIXVtZI = 48;

		private const int pdmPFbakXLcJQaNxWutmpkVQdKVsA = 49;

		private const int mKuvUhCBEFyBThpczzepYLASKVcE = 0;

		private const int veWEmeDNnglGRAaQGmecmMRdCixxB = 15;

		private const int UWXNWCchcZMWUyRlXFTWnyRbgfKG = 9;

		private const int wFQdyVAPfJmkCjkvjecUkSCCeZcec = 1;

		private const int OFrkBKxlUofTLyEVlJfbxKBkdSyM = 2;

		private const int elmppxnDZIAwPKjiDfTmDyxpdAqb = 3;

		private const int QgrfosFkxdPbefHODVVBAwoCBxEqB = 4;

		private const int eHmjWtYmIGdiQEksBUSibXLzDTxs = 5;

		private const int FcBvglBEAYohinbpJKxVaLsstdtu = 6;

		private const int GNYiCqLiMcOAFaEZUfCGZTqksTBR = 7;

		private const int CqeOurROScaRMhfChvEesAfSxcfX = 8;

		private const int SgevuAHttIbNXFGZqgFfIWsCKNpe = 14;

		private const int YejxYZKIyCCSLprlxcDDidGbMRGc = 3;

		private const int YJSCPlfLGnqKNzumMQAOwwPdhPipA = 7;

		private readonly NativeBuffer yhQfAgeKtzIpyiWJAPKvMItCawaB;

		private readonly NativeBuffer ClHBwpGSlZMhjpPdqXnqWYjebbhl;

		private bool aEbHSDewTBrDdZcaRKFVNuFTbwOo;

		private byte[] khbdMNdPEwwBVAWISijhxcINyQNq = new byte[3];

		private readonly IHIDDevice bqmxdaUaFKcGXTlKnqOyPSpGLrWL;

		private readonly HIDProperties NKuCoiplAFcOPDsKysKDQNXRwhMhA;

		private readonly svXcjurRenDjMJrGFPPkrmozhhdx YofoAnechoxMojBRxrWftSfqFvrq;

		bool IDriver_RailDriver.SpeakerEnabled
		{
			get
			{
				return aEbHSDewTBrDdZcaRKFVNuFTbwOo;
			}
			set
			{
				aEbHSDewTBrDdZcaRKFVNuFTbwOo = value;
				istFPshItYrzcTadrAsvpgfsNYWFA(fpnupfMbvRbIzhaCDelEiUFAPVHCc.Speaker, PaswCStrAkmQpcZYWcZPEJHLfUmk.Synchronous);
			}
		}

		ushort IHIDControllerExtension.vendorId => NKuCoiplAFcOPDsKysKDQNXRwhMhA.vendorId;

		ushort IHIDControllerExtension.productId => NKuCoiplAFcOPDsKysKDQNXRwhMhA.productId;

		string IHIDControllerExtension.productName => NKuCoiplAFcOPDsKysKDQNXRwhMhA.productName;

		string IHIDControllerExtension.manufacturer => NKuCoiplAFcOPDsKysKDQNXRwhMhA.manufacturer;

		ushort IHIDControllerExtension.usagePage => NKuCoiplAFcOPDsKysKDQNXRwhMhA.usagePage;

		ushort IHIDControllerExtension.usage => NKuCoiplAFcOPDsKysKDQNXRwhMhA.usage;

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			if (digitIndex >= 0 && digitIndex < 3)
			{
				khbdMNdPEwwBVAWISijhxcINyQNq[digitIndex] = digitBitValues;
				istFPshItYrzcTadrAsvpgfsNYWFA(fpnupfMbvRbIzhaCDelEiUFAPVHCc.LED, PaswCStrAkmQpcZYWcZPEJHLfUmk.Synchronous);
			}
		}

		void IDriver_RailDriver.SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetLEDDisplay
			this.SetLEDDisplay(digitIndex, digitBitValues);
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			khbdMNdPEwwBVAWISijhxcINyQNq[0] = digit1BitValues;
			khbdMNdPEwwBVAWISijhxcINyQNq[1] = digit2BitValues;
			khbdMNdPEwwBVAWISijhxcINyQNq[2] = digit3BitValues;
			istFPshItYrzcTadrAsvpgfsNYWFA(fpnupfMbvRbIzhaCDelEiUFAPVHCc.LED, PaswCStrAkmQpcZYWcZPEJHLfUmk.Synchronous);
		}

		void IDriver_RailDriver.SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetLEDDisplay
			this.SetLEDDisplay(digit1BitValues, digit2BitValues, digit3BitValues);
		}

		public RailDriverDriver(InitArgs P_0)
			: base(P_0)
		{
			bqmxdaUaFKcGXTlKnqOyPSpGLrWL = P_0.hidDevice;
			NKuCoiplAFcOPDsKysKDQNXRwhMhA = bqmxdaUaFKcGXTlKnqOyPSpGLrWL.properties;
			yhQfAgeKtzIpyiWJAPKvMItCawaB = new NativeBuffer(15);
			ClHBwpGSlZMhjpPdqXnqWYjebbhl = new NativeBuffer(9);
			YofoAnechoxMojBRxrWftSfqFvrq = new svXcjurRenDjMJrGFPPkrmozhhdx(ClHBwpGSlZMhjpPdqXnqWYjebbhl.Pointer, ClHBwpGSlZMhjpPdqXnqWYjebbhl.Length, 9);
			buttons = new JdXatRCvdrGKOPnZjOPQbsdPzHroA[50];
			for (int i = 0; i < 50; i++)
			{
				buttons[i] = new JdXatRCvdrGKOPnZjOPQbsdPzHroA(0, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new okLUGVdjnOaHkqUoOikOkGMRQUCY[4]
			{
				new okLUGVdjnOaHkqUoOikOkGMRQUCY(0, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new okLUGVdjnOaHkqUoOikOkGMRQUCY(0, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new okLUGVdjnOaHkqUoOikOkGMRQUCY(0, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 3,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new okLUGVdjnOaHkqUoOikOkGMRQUCY(0, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 4,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127)
			};
		}

		protected override void OnInitialize()
		{
			InitializationFinished(initialized: true);
		}

		public override void Update(UpdateLoopType updateLoop)
		{
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < yhQfAgeKtzIpyiWJAPKvMItCawaB.Length)
			{
				return false;
			}
			yhQfAgeKtzIpyiWJAPKvMItCawaB.Write(inputReportPtr, inputReportLength, yhQfAgeKtzIpyiWJAPKvMItCawaB.Length);
			jaVfmemKXYbdWdYzaudKxAfIpRZW(yhQfAgeKtzIpyiWJAPKvMItCawaB, timestamp);
			VJJORtyhxtIZFDAvjUdtXgBUbPYD[] array = axes;
			aVLfqeWXbgdStIoWqgPUejEyeowp(array, yhQfAgeKtzIpyiWJAPKvMItCawaB, timestamp);
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new RailDriverExtension(this);
		}

		private bool istFPshItYrzcTadrAsvpgfsNYWFA(fpnupfMbvRbIzhaCDelEiUFAPVHCc P_0, PaswCStrAkmQpcZYWcZPEJHLfUmk P_1)
		{
			UEerVXgnKYPOLPLQuAdYiQDbpqEDA(P_0);
			return DFgJsezGfMgGBlzTKCblXZMwYitH(P_1);
		}

		private void UEerVXgnKYPOLPLQuAdYiQDbpqEDA(fpnupfMbvRbIzhaCDelEiUFAPVHCc P_0)
		{
			switch (P_0)
			{
			case fpnupfMbvRbIzhaCDelEiUFAPVHCc.Speaker:
				ClHBwpGSlZMhjpPdqXnqWYjebbhl.Clear();
				ClHBwpGSlZMhjpPdqXnqWYjebbhl[1] = 133;
				ClHBwpGSlZMhjpPdqXnqWYjebbhl[7] = (aEbHSDewTBrDdZcaRKFVNuFTbwOo ? ((byte)1) : ((byte)0));
				break;
			case fpnupfMbvRbIzhaCDelEiUFAPVHCc.LED:
				ClHBwpGSlZMhjpPdqXnqWYjebbhl.Clear();
				ClHBwpGSlZMhjpPdqXnqWYjebbhl[1] = 134;
				ClHBwpGSlZMhjpPdqXnqWYjebbhl[2] = khbdMNdPEwwBVAWISijhxcINyQNq[0];
				ClHBwpGSlZMhjpPdqXnqWYjebbhl[3] = khbdMNdPEwwBVAWISijhxcINyQNq[1];
				ClHBwpGSlZMhjpPdqXnqWYjebbhl[4] = khbdMNdPEwwBVAWISijhxcINyQNq[2];
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private bool DFgJsezGfMgGBlzTKCblXZMwYitH(PaswCStrAkmQpcZYWcZPEJHLfUmk P_0)
		{
			switch (P_0)
			{
			case PaswCStrAkmQpcZYWcZPEJHLfUmk.Synchronous:
				return bqmxdaUaFKcGXTlKnqOyPSpGLrWL.WriteSync(YofoAnechoxMojBRxrWftSfqFvrq, 0);
			case PaswCStrAkmQpcZYWcZPEJHLfUmk.Asynchronous:
				bqmxdaUaFKcGXTlKnqOyPSpGLrWL.WriteAsync(YofoAnechoxMojBRxrWftSfqFvrq, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void jaVfmemKXYbdWdYzaudKxAfIpRZW(NativeBuffer P_0, double P_1)
		{
			for (int i = 0; i < 6; i++)
			{
				byte b = P_0[8 + i];
				int num = i * 8;
				for (int j = 0; j < 8; j++)
				{
					int num2 = num + j;
					if (num2 >= 44)
					{
						break;
					}
					buttons[num2].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & (1 << j)) != 0, P_1);
				}
			}
			byte b2 = P_0[6];
			buttons[44].PogUzVVLnPzYuPCLsIgJOvBnYfcB(b2 < 95, P_1);
			buttons[45].PogUzVVLnPzYuPCLsIgJOvBnYfcB(b2 >= 95 && b2 < 161, P_1);
			buttons[46].PogUzVVLnPzYuPCLsIgJOvBnYfcB(b2 >= 161, P_1);
			b2 = P_0[7];
			buttons[47].PogUzVVLnPzYuPCLsIgJOvBnYfcB(b2 < 95, P_1);
			buttons[48].PogUzVVLnPzYuPCLsIgJOvBnYfcB(b2 >= 95 && b2 < 161, P_1);
			buttons[49].PogUzVVLnPzYuPCLsIgJOvBnYfcB(b2 >= 161, P_1);
		}

		private void aVLfqeWXbgdStIoWqgPUejEyeowp(VJJORtyhxtIZFDAvjUdtXgBUbPYD[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].kIKDSuiibFIJviyHCLnqsKOSMCInA(P_1, P_2);
			}
		}

		~RailDriverDriver()
		{
			Dispose(disposing: false);
		}

		protected override void Dispose(bool disposing)
		{
			if (base.disposed)
			{
				return;
			}
			base.Dispose(disposing);
			if (disposing)
			{
				if (yhQfAgeKtzIpyiWJAPKvMItCawaB != null)
				{
					yhQfAgeKtzIpyiWJAPKvMItCawaB.Dispose();
				}
				if (ClHBwpGSlZMhjpPdqXnqWYjebbhl != null)
				{
					ClHBwpGSlZMhjpPdqXnqWYjebbhl.Dispose();
				}
			}
		}

		public static bool Matches(int vid, int pid)
		{
			if (1523 == vid)
			{
				return 210 == pid;
			}
			return false;
		}
	}
}
