using System;
using System.Runtime.InteropServices;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct LowLevelInputEvent
	{
		private const int IQxecgSfLmWuOeJqBKaYgnYfAwkBA = 4;

		private const int snqCpZhVvjgYmOVTPZDsFrihFNAx = 8;

		private const int axZTMZFHXmOZyLdMDeFKAqWnrzmiA = 12;

		public const int buttonsPerPage = 32;

		public const int bytesPerButtonPage = 4;

		private const int KWhnMrCveUTAIiircDlScirYBbxbb = 4;

		private const int IFDDsvndrwzJfrOcZhdSNWcfdakE = 4;

		public const int byteIndex_id = 0;

		public const int byteIndex_timestamp = 4;

		public const int byteIndex_elementsStart = 12;

		public IntPtr _buffer;

		private int mjUyjDRmUnPDNloneTLdQFPoDTihA;

		private int ezoqGoqyuQoFLMfdVcWHjVymZXuv;

		private int GorJbcddlDMSeOIokHSpgBoaFjDnA;

		private int egNKmBdsXVbsYnMivBKdbfpklhrdb;

		private int kQoSRJkdOnFcfcUapcFskzzgkKSHA;

		private int JpgxGCFGGWBkvczrKvNGJZpLqGqz;

		public bool isValid => _buffer != IntPtr.Zero;

		public int buttonCount => ezoqGoqyuQoFLMfdVcWHjVymZXuv;

		public int axisCount => GorJbcddlDMSeOIokHSpgBoaFjDnA;

		public int byteIndex_axesStart => egNKmBdsXVbsYnMivBKdbfpklhrdb;

		public int byteIndex_buttonsStart => kQoSRJkdOnFcfcUapcFskzzgkKSHA;

		public int byteIndex_hatsStart => JpgxGCFGGWBkvczrKvNGJZpLqGqz;

		public LowLevelInputEvent(IntPtr P_0, int P_1, int P_2, int P_3)
		{
			if (P_1 == 0 && P_2 == 0)
			{
				throw new ArgumentOutOfRangeException("No elements defined in event.");
			}
			_buffer = P_0;
			ezoqGoqyuQoFLMfdVcWHjVymZXuv = P_1;
			GorJbcddlDMSeOIokHSpgBoaFjDnA = P_2;
			kQoSRJkdOnFcfcUapcFskzzgkKSHA = 12;
			egNKmBdsXVbsYnMivBKdbfpklhrdb = kQoSRJkdOnFcfcUapcFskzzgkKSHA + ((P_1 > 0) ? (((P_1 - 1) / 32 + 1) * 4) : 0);
			JpgxGCFGGWBkvczrKvNGJZpLqGqz = egNKmBdsXVbsYnMivBKdbfpklhrdb + P_2 * 4;
			mjUyjDRmUnPDNloneTLdQFPoDTihA = GetReportSize(P_1, P_2, P_3);
		}

		public void SetButtonsBitMask(int bitMask, int startButtonIndex)
		{
			if (mjUyjDRmUnPDNloneTLdQFPoDTihA > 0)
			{
				if (startButtonIndex % 32 != 0)
				{
					throw new Exception("startIndex must be divisible by 32.");
				}
				Marshal.WriteInt32(_buffer, kQoSRJkdOnFcfcUapcFskzzgkKSHA + startButtonIndex / 4, bitMask);
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (mjUyjDRmUnPDNloneTLdQFPoDTihA > 0)
			{
				Marshal.WriteInt32(_buffer, egNKmBdsXVbsYnMivBKdbfpklhrdb + index * 4, new QmFFArXNhUTHoISKdWgGnBiasQCf(value).tdTDQfnvbUkOwJuHqLkgSMdzjCdV);
			}
		}

		public void SetId(uint id)
		{
			if (mjUyjDRmUnPDNloneTLdQFPoDTihA > 0)
			{
				Marshal.WriteInt32(_buffer, 0, (int)id);
			}
		}

		public void SetTimestamp(double value)
		{
			if (mjUyjDRmUnPDNloneTLdQFPoDTihA > 0)
			{
				Marshal.WriteInt64(_buffer, 4, new ZHRqeSulxFzCOhBvhVQGKJjGCpbIA(value).zmJFVTqNCffYgMBmjytxXdLrEWXGA);
			}
		}

		public bool GetButtonValue(int index)
		{
			if (mjUyjDRmUnPDNloneTLdQFPoDTihA <= 0)
			{
				return false;
			}
			if (buttonCount == 0)
			{
				return false;
			}
			int num = index / 32;
			int num2 = (index - num * 32) / 8;
			int num3 = index % 8;
			return (Marshal.ReadByte(_buffer, kQoSRJkdOnFcfcUapcFskzzgkKSHA + num * 4 + num2) & (1 << num3)) != 0;
		}

		public int GetButtonsBitMask(int startButtonIndex)
		{
			if (mjUyjDRmUnPDNloneTLdQFPoDTihA <= 0)
			{
				return 0;
			}
			if (startButtonIndex % 32 != 0)
			{
				throw new Exception("startIndex must be divisible by 32.");
			}
			return Marshal.ReadInt32(_buffer, kQoSRJkdOnFcfcUapcFskzzgkKSHA + startButtonIndex / 4);
		}

		public float GetAxisValue(int index)
		{
			if (mjUyjDRmUnPDNloneTLdQFPoDTihA <= 0)
			{
				return 0f;
			}
			return new QmFFArXNhUTHoISKdWgGnBiasQCf(Marshal.ReadInt32(_buffer, egNKmBdsXVbsYnMivBKdbfpklhrdb + index * 4)).JZRjhpiukwsanEiXeaIABjfiCiaGb;
		}

		public uint GetId()
		{
			if (mjUyjDRmUnPDNloneTLdQFPoDTihA <= 0)
			{
				return 0u;
			}
			return (uint)Marshal.ReadInt32(_buffer, 0);
		}

		public double GetTimestamp()
		{
			if (mjUyjDRmUnPDNloneTLdQFPoDTihA <= 0)
			{
				return 0.0;
			}
			return new ZHRqeSulxFzCOhBvhVQGKJjGCpbIA(Marshal.ReadInt64(_buffer, 4)).qFoQYmCOCPotYHkAEBlAOjpEqeQK;
		}

		public static int GetReportSize(int buttonCount, int axisCount, int hatCount)
		{
			return 12 + ((buttonCount > 0) ? (((buttonCount - 1) / 32 + 1) * 4) : 0) + axisCount * 4 + hatCount * 4;
		}
	}
}
