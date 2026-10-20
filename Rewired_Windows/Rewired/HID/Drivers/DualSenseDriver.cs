using System;
using System.Diagnostics;
using System.Linq;
using Rewired.ControllerExtensions;
using Rewired.ControllerExtensions.Internal;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualSenseDriver : HIDDeviceDriver, IDriver_DualSense, IDualSenseExtensionSource, IDualShock4DualSenseCommonExtensionSource, IControllerDriver, IHIDControllerExtension, IDisposable
	{
		private enum jvCCMRhQntIEpbMOcApIvfdKjRMdb
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum bPrHhSOObwJuICMJYqAOfGedgTlR
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		private enum FVIxTwIDPRsHLerOoPYjVLgTfrWk : byte
		{
			Off = 0,
			Feedback = 1,
			Weapon = 2,
			Vibration = 3,
			SlopeFeedback = 4
		}

		private enum cpqWrtsPtNOnBBfVkOKYxZBtrxBm : byte
		{
			High = 0,
			Medium = 1,
			Low = 2
		}

		private enum jVHpZuPGTUgXiWEJXBDCFmSDsAVp : byte
		{
			Discharging = 0,
			Charging = 1,
			Full = 2,
			TemperatureOutOfRange = 10,
			TemperatureError = 11,
			ChargingError = 15
		}

		private enum FPQDYBiQbktagctHnzerPCIUamegA
		{
			NotCharging = 0,
			Discharging = 1,
			Charging = 2,
			Full = 3,
			Unknown = 4
		}

		private enum GLfeGDteHeqvIIhBMgaRCLUfqaDK : byte
		{
			None = 0,
			CompatibleVibrationMode1 = 1,
			HapticsSelect = 2,
			RightTriggerEffect = 4,
			LeftTriggerEffect = 8,
			AudioVolume = 0x10,
			ToggleInternalSpeaker = 0x20,
			MicrophoneVolume = 0x40,
			ToggleInternalMicOrExternalSpeaker = 0x80
		}

		private enum bmJMarTHaOhNYcwJIKKXNGnHiqUhA : byte
		{
			None = 0,
			MicrophoneLEDControl = 1,
			PowerSaveControl = 2,
			LightbarControl = 4,
			TurnOffLEDs = 8,
			PlayerIndicatorLEDControl = 0x10,
			Unknown1 = 0x20,
			ChangeOverallMotorEffectPower = 0x40,
			Unknown2 = 0x80
		}

		private enum AHPvaZCdHCyQBJkPUpKjjBGcCciX : byte
		{
			None = 0,
			OtherLightBrightnessControl = 1,
			LightbarSetupControl = 2,
			CompatibleVibrationMode2 = 4
		}

		private struct jDDXOetxueLeUSOjoFIvMmnHGcFDA
		{
			private const string OOoDmphgkrChixOngAwQukzojERr = "Value must be between 0 and 16.";

			public byte hSwFnjsbhqPeyqMHRyUiXjfphxQeA;

			public byte lvBhscymuoRhzWlIMNAkTfoMrhSX
			{
				get
				{
					return (byte)(hSwFnjsbhqPeyqMHRyUiXjfphxQeA & 0xF);
				}
				set
				{
					if (b >= 16)
					{
						throw new ArithmeticException("Value must be between 0 and 16.");
					}
					hSwFnjsbhqPeyqMHRyUiXjfphxQeA = (byte)((XTggCgJQMcuSlWatCBrPHmPazPgWA << 4) | (b & 0xF));
				}
			}

			public byte XTggCgJQMcuSlWatCBrPHmPazPgWA
			{
				get
				{
					return (byte)(hSwFnjsbhqPeyqMHRyUiXjfphxQeA >> 4);
				}
				set
				{
					if (b >= 16)
					{
						throw new ArithmeticException("Value must be between 0 and 16.");
					}
					hSwFnjsbhqPeyqMHRyUiXjfphxQeA = (byte)((b << 4) | lvBhscymuoRhzWlIMNAkTfoMrhSX);
				}
			}

			public jDDXOetxueLeUSOjoFIvMmnHGcFDA(byte P_0)
			{
				hSwFnjsbhqPeyqMHRyUiXjfphxQeA = P_0;
			}

			public jDDXOetxueLeUSOjoFIvMmnHGcFDA(byte P_0, byte P_1)
			{
				if (P_0 >= 16 || P_1 >= 16)
				{
					throw new ArithmeticException("Value must be between 0 and 16.");
				}
				hSwFnjsbhqPeyqMHRyUiXjfphxQeA = (byte)((P_1 << 4) | P_0);
			}
		}

		private static class YPprZfeslPExlCXjBQKuKsuVpyLQ
		{
			public enum IkEBDgJuwDNzHckZzkRLtuIbfbJwA : byte
			{
				Off = 5,
				Feedback = 33,
				Weapon = 37,
				Vibration = 38,
				Bow = 34,
				Galloping = 35,
				Machine = 39,
				Simple_Feedback = 1,
				Simple_Weapon = 2,
				Simple_Vibration = 6,
				Limited_Feedback = 17,
				Limited_Weapon = 18,
				DebugFC = 252,
				DebugFD = 253,
				DebugFE = 254
			}

			public static class ScDdYllCJCAhKxibBmrZXldgGELEA
			{
				public static class aEYzhJboQcgOOCJvFWWBakFEmlCib
				{
					public static bool ggpuNpOQclZheyfCtNQgXjNDRzdc(byte[] P_0, int P_1)
					{
						return WAkiPIhngiNoRggFkGCHPaAZRZfab(P_0, P_1);
					}

					public static bool svEHJPLeUAmBouLOxOceLfsXbqObA(byte[] P_0, int P_1, float P_2, float P_3)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 8f);
						return kaqSeWtDQvfYreHtcpwTBFPizYkB(P_0, P_1, (byte)P_2, (byte)P_3);
					}

					public static bool vYLKdsUmIEEoJNJlffmKDpEDoZOPA(byte[] P_0, int P_1, float P_2, float P_3, float P_4)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 9f);
						P_4 = (float)Math.Round(P_4 * 8f);
						return yDDDDbXKNWwpbpPKANEapGGDvcFb(P_0, P_1, (byte)P_2, (byte)P_3, (byte)P_4);
					}

					public static bool rsxSodFmfEmBKcQreDZPGFStFiIFA(byte[] P_0, int P_1, float P_2, float P_3, float P_4)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 8f);
						P_4 = (float)Math.Round(P_4 * 255f);
						return MhsuwuZcoYABaOJDEaXIfuQlXYIQ(P_0, P_1, (byte)P_2, (byte)P_3, (byte)P_4);
					}

					public static bool xtPSGEyWCiGHEcHxLzKetBxwULae(byte[] P_0, int P_1, float[] P_2)
					{
						if (P_2.Length != 10)
						{
							return false;
						}
						byte[] array = new byte[10];
						for (int i = 0; i < 10; i++)
						{
							array[i] = (byte)Math.Round(P_2[i] * 8f);
						}
						return qEPrVdAwhntBQJpMLDJSJdmwPEvfA(P_0, P_1, array);
					}

					public static bool nmSEYHGJjbzUWAQFgzbNpQniNxHq(byte[] P_0, int P_1, float P_2, float P_3, float P_4, float P_5)
					{
						P_2 = (float)Math.Round(P_2 * 9f);
						P_3 = (float)Math.Round(P_3 * 9f);
						P_4 = (float)Math.Round(P_4 * 8f);
						P_5 = (float)Math.Round(P_5 * 8f);
						return qcfAfjCAJEWWxrRClNnCeTmbDDKGA(P_0, P_1, (byte)P_2, (byte)P_3, (byte)P_4, (byte)P_5);
					}

					public static bool vxdUrrEmAmGJHRMUENohzKItVViV(byte[] P_0, int P_1, float[] P_2, float P_3)
					{
						if (P_2.Length != 10)
						{
							return false;
						}
						P_3 = (float)Math.Round(P_3 * 255f);
						byte[] array = new byte[10];
						for (int i = 0; i < 10; i++)
						{
							array[i] = (byte)Math.Round(P_2[i] * 8f);
						}
						return YhiBhfaBQAZHayYNPlaqVkzNfPeE(P_0, P_1, (byte)P_3, array);
					}
				}

				[Serializable]
				private sealed class WEFIRXllkulIIwjEAaxMMMXFqXuG
				{
					public static readonly WEFIRXllkulIIwjEAaxMMMXFqXuG _003C_003E9 = new WEFIRXllkulIIwjEAaxMMMXFqXuG();

					public static Func<byte, bool> _003C_003E9__4_0;

					public static Func<byte, bool> _003C_003E9__6_0;

					internal bool HTDTuKWkxvlrYhVCqWQnZCpvOgbn(byte P_0)
					{
						return P_0 > 0;
					}

					internal bool OdzwuXACcAEycfIxvejLqlMxkNnl(byte P_0)
					{
						return P_0 > 0;
					}
				}

				public static bool WAkiPIhngiNoRggFkGCHPaAZRZfab(byte[] P_0, int P_1)
				{
					P_0[P_1] = 5;
					P_0[P_1 + 1] = 0;
					P_0[P_1 + 2] = 0;
					P_0[P_1 + 3] = 0;
					P_0[P_1 + 4] = 0;
					P_0[P_1 + 5] = 0;
					P_0[P_1 + 6] = 0;
					P_0[P_1 + 7] = 0;
					P_0[P_1 + 8] = 0;
					P_0[P_1 + 9] = 0;
					P_0[P_1 + 10] = 0;
					return true;
				}

				public static bool kaqSeWtDQvfYreHtcpwTBFPizYkB(byte[] P_0, int P_1, byte P_2, byte P_3)
				{
					if (P_2 > 9)
					{
						return false;
					}
					if (P_3 > 8)
					{
						return false;
					}
					if (P_3 > 0)
					{
						byte b = (byte)((P_3 - 1) & 7);
						uint num = 0u;
						ushort num2 = 0;
						for (int i = P_2; i < 10; i++)
						{
							num |= (uint)(b << 3 * i);
							num2 |= (ushort)(1 << i);
						}
						P_0[P_1] = 33;
						P_0[P_1 + 1] = (byte)(num2 & 0xFF);
						P_0[P_1 + 2] = (byte)((num2 >> 8) & 0xFF);
						P_0[P_1 + 3] = (byte)(num & 0xFF);
						P_0[P_1 + 4] = (byte)((num >> 8) & 0xFF);
						P_0[P_1 + 5] = (byte)((num >> 16) & 0xFF);
						P_0[P_1 + 6] = (byte)((num >> 24) & 0xFF);
						P_0[P_1 + 7] = 0;
						P_0[P_1 + 8] = 0;
						P_0[P_1 + 9] = 0;
						P_0[P_1 + 10] = 0;
						return true;
					}
					return WAkiPIhngiNoRggFkGCHPaAZRZfab(P_0, P_1);
				}

				public static bool yDDDDbXKNWwpbpPKANEapGGDvcFb(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					if (P_2 > 7 || P_2 < 2)
					{
						return false;
					}
					if (P_3 > 8)
					{
						return false;
					}
					if (P_3 <= P_2)
					{
						return false;
					}
					if (P_4 > 8)
					{
						return false;
					}
					if (P_4 > 0)
					{
						ushort num = (ushort)((1 << (int)P_2) | (1 << (int)P_3));
						P_0[P_1] = 37;
						P_0[P_1 + 1] = (byte)(num & 0xFF);
						P_0[P_1 + 2] = (byte)((num >> 8) & 0xFF);
						P_0[P_1 + 3] = (byte)(P_4 - 1);
						P_0[P_1 + 4] = 0;
						P_0[P_1 + 5] = 0;
						P_0[P_1 + 6] = 0;
						P_0[P_1 + 7] = 0;
						P_0[P_1 + 8] = 0;
						P_0[P_1 + 9] = 0;
						P_0[P_1 + 10] = 0;
						return true;
					}
					return WAkiPIhngiNoRggFkGCHPaAZRZfab(P_0, P_1);
				}

				public static bool MhsuwuZcoYABaOJDEaXIfuQlXYIQ(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					if (P_2 > 9)
					{
						return false;
					}
					if (P_3 > 8)
					{
						return false;
					}
					if (P_3 > 0 && P_4 > 0)
					{
						byte b = (byte)((P_3 - 1) & 7);
						uint num = 0u;
						ushort num2 = 0;
						for (int i = P_2; i < 10; i++)
						{
							num |= (uint)(b << 3 * i);
							num2 |= (ushort)(1 << i);
						}
						P_0[P_1] = 38;
						P_0[P_1 + 1] = (byte)(num2 & 0xFF);
						P_0[P_1 + 2] = (byte)((num2 >> 8) & 0xFF);
						P_0[P_1 + 3] = (byte)(num & 0xFF);
						P_0[P_1 + 4] = (byte)((num >> 8) & 0xFF);
						P_0[P_1 + 5] = (byte)((num >> 16) & 0xFF);
						P_0[P_1 + 6] = (byte)((num >> 24) & 0xFF);
						P_0[P_1 + 7] = 0;
						P_0[P_1 + 8] = 0;
						P_0[P_1 + 9] = P_4;
						P_0[P_1 + 10] = 0;
						return true;
					}
					return WAkiPIhngiNoRggFkGCHPaAZRZfab(P_0, P_1);
				}

				public static bool qEPrVdAwhntBQJpMLDJSJdmwPEvfA(byte[] P_0, int P_1, byte[] P_2)
				{
					if (P_2.Length != 10)
					{
						return false;
					}
					if (P_2.Any(WEFIRXllkulIIwjEAaxMMMXFqXuG._003C_003E9.HTDTuKWkxvlrYhVCqWQnZCpvOgbn))
					{
						uint num = 0u;
						ushort num2 = 0;
						for (int i = 0; i < 10; i++)
						{
							if (P_2[i] > 0)
							{
								byte b = (byte)((P_2[i] - 1) & 7);
								num |= (uint)(b << 3 * i);
								num2 |= (ushort)(1 << i);
							}
						}
						P_0[P_1] = 33;
						P_0[P_1 + 1] = (byte)(num2 & 0xFF);
						P_0[P_1 + 2] = (byte)((num2 >> 8) & 0xFF);
						P_0[P_1 + 3] = (byte)(num & 0xFF);
						P_0[P_1 + 4] = (byte)((num >> 8) & 0xFF);
						P_0[P_1 + 5] = (byte)((num >> 16) & 0xFF);
						P_0[P_1 + 6] = (byte)((num >> 24) & 0xFF);
						P_0[P_1 + 7] = 0;
						P_0[P_1 + 8] = 0;
						P_0[P_1 + 9] = 0;
						P_0[P_1 + 10] = 0;
						return true;
					}
					return WAkiPIhngiNoRggFkGCHPaAZRZfab(P_0, P_1);
				}

				public static bool qcfAfjCAJEWWxrRClNnCeTmbDDKGA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5)
				{
					if (P_2 > 8 || P_2 < 0)
					{
						return false;
					}
					if (P_3 > 9)
					{
						return false;
					}
					if (P_3 <= P_2)
					{
						return false;
					}
					if (P_4 > 8)
					{
						return false;
					}
					if (P_4 < 1)
					{
						return false;
					}
					if (P_5 > 8)
					{
						return false;
					}
					if (P_5 < 1)
					{
						return false;
					}
					byte[] array = new byte[10];
					float num = 1f * (float)(P_5 - P_4) / (float)(P_3 - P_2);
					for (int i = P_2; i < 10; i++)
					{
						if (i <= P_3)
						{
							array[i] = (byte)Math.Round((float)(int)P_4 + num * (float)(i - P_2));
						}
						else
						{
							array[i] = P_5;
						}
					}
					return qEPrVdAwhntBQJpMLDJSJdmwPEvfA(P_0, P_1, array);
				}

				public static bool YhiBhfaBQAZHayYNPlaqVkzNfPeE(byte[] P_0, int P_1, byte P_2, byte[] P_3)
				{
					if (P_3.Length != 10)
					{
						return false;
					}
					if (P_2 > 0 && P_3.Any(WEFIRXllkulIIwjEAaxMMMXFqXuG._003C_003E9.OdzwuXACcAEycfIxvejLqlMxkNnl))
					{
						uint num = 0u;
						ushort num2 = 0;
						for (int i = 0; i < 10; i++)
						{
							if (P_3[i] > 0)
							{
								byte b = (byte)((P_3[i] - 1) & 7);
								num |= (uint)(b << 3 * i);
								num2 |= (ushort)(1 << i);
							}
						}
						P_0[P_1] = 38;
						P_0[P_1 + 1] = (byte)(num2 & 0xFF);
						P_0[P_1 + 2] = (byte)((num2 >> 8) & 0xFF);
						P_0[P_1 + 3] = (byte)(num & 0xFF);
						P_0[P_1 + 4] = (byte)((num >> 8) & 0xFF);
						P_0[P_1 + 5] = (byte)((num >> 16) & 0xFF);
						P_0[P_1 + 6] = (byte)((num >> 24) & 0xFF);
						P_0[P_1 + 7] = 0;
						P_0[P_1 + 8] = 0;
						P_0[P_1 + 9] = P_2;
						P_0[P_1 + 10] = 0;
						return true;
					}
					return WAkiPIhngiNoRggFkGCHPaAZRZfab(P_0, P_1);
				}

				public static bool gjopCadLDmuzxBWpLgyJLImUyaVL(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5)
				{
					if (P_2 > 8)
					{
						return false;
					}
					if (P_3 > 8)
					{
						return false;
					}
					if (P_2 >= P_3)
					{
						return false;
					}
					if (P_4 > 8)
					{
						return false;
					}
					if (P_5 > 8)
					{
						return false;
					}
					if (P_3 > 0 && P_4 > 0 && P_5 > 0)
					{
						ushort num = (ushort)((1 << (int)P_2) | (1 << (int)P_3));
						uint num2 = (uint)(((P_4 - 1) & 7) | (((P_5 - 1) & 7) << 3));
						P_0[P_1] = 34;
						P_0[P_1 + 1] = (byte)(num & 0xFF);
						P_0[P_1 + 2] = (byte)((num >> 8) & 0xFF);
						P_0[P_1 + 3] = (byte)(num2 & 0xFF);
						P_0[P_1 + 4] = (byte)((num2 >> 8) & 0xFF);
						P_0[P_1 + 5] = 0;
						P_0[P_1 + 6] = 0;
						P_0[P_1 + 7] = 0;
						P_0[P_1 + 8] = 0;
						P_0[P_1 + 9] = 0;
						P_0[P_1 + 10] = 0;
						return true;
					}
					return WAkiPIhngiNoRggFkGCHPaAZRZfab(P_0, P_1);
				}

				public static bool IYXGzZIREzeXbeCCnkoKESlYofWTA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5, byte P_6)
				{
					if (P_2 > 8)
					{
						return false;
					}
					if (P_3 > 9)
					{
						return false;
					}
					if (P_2 >= P_3)
					{
						return false;
					}
					if (P_5 > 7)
					{
						return false;
					}
					if (P_4 > 6)
					{
						return false;
					}
					if (P_4 >= P_5)
					{
						return false;
					}
					if (P_6 > 0)
					{
						ushort num = (ushort)((1 << (int)P_2) | (1 << (int)P_3));
						uint num2 = (uint)((P_5 & 7) | ((P_4 & 7) << 3));
						P_0[P_1] = 35;
						P_0[P_1 + 1] = (byte)(num & 0xFF);
						P_0[P_1 + 2] = (byte)((num >> 8) & 0xFF);
						P_0[P_1 + 3] = (byte)(num2 & 0xFF);
						P_0[P_1 + 4] = P_6;
						P_0[P_1 + 5] = 0;
						P_0[P_1 + 6] = 0;
						P_0[P_1 + 7] = 0;
						P_0[P_1 + 8] = 0;
						P_0[P_1 + 9] = 0;
						P_0[P_1 + 10] = 0;
						return true;
					}
					return WAkiPIhngiNoRggFkGCHPaAZRZfab(P_0, P_1);
				}

				public static bool KgaZuKzgozGHHztWQnsAfjivTBaW(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5, byte P_6, byte P_7)
				{
					if (P_2 > 8)
					{
						return false;
					}
					if (P_3 > 9)
					{
						return false;
					}
					if (P_3 <= P_2)
					{
						return false;
					}
					if (P_4 > 7)
					{
						return false;
					}
					if (P_5 > 7)
					{
						return false;
					}
					if (P_6 > 0)
					{
						ushort num = (ushort)((1 << (int)P_2) | (1 << (int)P_3));
						uint num2 = (uint)((P_4 & 7) | ((P_5 & 7) << 3));
						P_0[P_1] = 39;
						P_0[P_1 + 1] = (byte)(num & 0xFF);
						P_0[P_1 + 2] = (byte)((num >> 8) & 0xFF);
						P_0[P_1 + 3] = (byte)(num2 & 0xFF);
						P_0[P_1 + 4] = P_6;
						P_0[P_1 + 5] = P_7;
						P_0[P_1 + 6] = 0;
						P_0[P_1 + 7] = 0;
						P_0[P_1 + 8] = 0;
						P_0[P_1 + 9] = 0;
						P_0[P_1 + 10] = 0;
						return true;
					}
					return WAkiPIhngiNoRggFkGCHPaAZRZfab(P_0, P_1);
				}

				public static bool DEsjiABPBcYVulgZzevhVxWBrozE(byte[] P_0, int P_1, byte P_2, byte P_3)
				{
					P_0[P_1] = 1;
					P_0[P_1 + 1] = P_2;
					P_0[P_1 + 2] = P_3;
					P_0[P_1 + 3] = 0;
					P_0[P_1 + 4] = 0;
					P_0[P_1 + 5] = 0;
					P_0[P_1 + 6] = 0;
					P_0[P_1 + 7] = 0;
					P_0[P_1 + 8] = 0;
					P_0[P_1 + 9] = 0;
					P_0[P_1 + 10] = 0;
					return true;
				}

				public static bool RZShhmnbWRDTcIkpGrRfWaWQAetg(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					P_0[P_1] = 2;
					P_0[P_1 + 1] = P_2;
					P_0[P_1 + 2] = P_3;
					P_0[P_1 + 3] = P_4;
					P_0[P_1 + 4] = 0;
					P_0[P_1 + 5] = 0;
					P_0[P_1 + 6] = 0;
					P_0[P_1 + 7] = 0;
					P_0[P_1 + 8] = 0;
					P_0[P_1 + 9] = 0;
					P_0[P_1 + 10] = 0;
					return true;
				}

				public static bool RUcwkafjAuKfVUOlsxnqPpBAFwYj(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					if (P_4 > 0 && P_3 > 0)
					{
						P_0[P_1] = 6;
						P_0[P_1 + 1] = P_4;
						P_0[P_1 + 2] = P_3;
						P_0[P_1 + 3] = P_2;
						P_0[P_1 + 4] = 0;
						P_0[P_1 + 5] = 0;
						P_0[P_1 + 6] = 0;
						P_0[P_1 + 7] = 0;
						P_0[P_1 + 8] = 0;
						P_0[P_1 + 9] = 0;
						P_0[P_1 + 10] = 0;
						return true;
					}
					return WAkiPIhngiNoRggFkGCHPaAZRZfab(P_0, P_1);
				}

				public static bool VbgFkKfrgHgekFOKArHlcJcxOtdg(byte[] P_0, int P_1, byte P_2, byte P_3)
				{
					if (P_3 > 10)
					{
						return false;
					}
					if (P_3 > 0)
					{
						P_0[P_1] = 17;
						P_0[P_1 + 1] = P_2;
						P_0[P_1 + 2] = P_3;
						P_0[P_1 + 3] = 0;
						P_0[P_1 + 4] = 0;
						P_0[P_1 + 5] = 0;
						P_0[P_1 + 6] = 0;
						P_0[P_1 + 7] = 0;
						P_0[P_1 + 8] = 0;
						P_0[P_1 + 9] = 0;
						P_0[P_1 + 10] = 0;
						return true;
					}
					return WAkiPIhngiNoRggFkGCHPaAZRZfab(P_0, P_1);
				}

				public static bool NtCeYXoRtJkwHjyJHrzBYhLbhyQE(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
				{
					if (P_2 < 16)
					{
						return false;
					}
					if (P_3 < P_2 || P_2 + 100 < P_3)
					{
						return false;
					}
					if (P_4 > 10)
					{
						return false;
					}
					if (P_4 > 0)
					{
						P_0[P_1] = 18;
						P_0[P_1 + 1] = P_2;
						P_0[P_1 + 2] = P_3;
						P_0[P_1 + 3] = P_4;
						P_0[P_1 + 4] = 0;
						P_0[P_1 + 5] = 0;
						P_0[P_1 + 6] = 0;
						P_0[P_1 + 7] = 0;
						P_0[P_1 + 8] = 0;
						P_0[P_1 + 9] = 0;
						P_0[P_1 + 10] = 0;
						return true;
					}
					return WAkiPIhngiNoRggFkGCHPaAZRZfab(P_0, P_1);
				}
			}
		}

		private const float sqVQFRwBXVsesHNscTUuIkPhPunJ = 4f;

		private const int kODwMmdJKfJTcbfwVtfgtjpEbOss = 15;

		private const int AaVgfaZYBIEEwEDYbXffpsyayTwK = 2;

		private const int rTZJWftRJSDUqJyGXQnWsmpoBuPJ = 0;

		private const int cFmxPynWAaiqmWabbTYKsuJqFCkf = 1912;

		private const int cAFFLKBciglCvFkZnwtFiwAUAKxs = 0;

		private const int FySiueimzwRzLfHQUdJfdMGPCQvkA = 941;

		private const bool TPyAfEvECyKgllnbUzPHQNHXDObd = false;

		private const bool AMHSZMXSijNpWPkXaKzIDcMcosYQ = true;

		private const float juLxsVulAxImnjJUrCoKdthHzrHNB = 2.5f;

		private const int rAeBEwhtRUpjXrEcEljoEcfHbYNpB = 0;

		private const int iHtKHmxjMLVOXenGLTmnhOlFLdzC = 0;

		private const int zXgcHTSKxkuPLKLgkzhfEnWBhTMt = 1;

		private const int ChyCiJanFxffRroHoAspfJgnInGxA = 0;

		private const int CQrcMlONctNMqquqbUcyUzdJLXPJ = 0;

		private const int LwqreFVaNbIxiCYBQAvxbNjniDpR = 0;

		private const int ekzztBgalHAwPntjdFZTlIUEmRBl = 1;

		private const int DbrCGWCdTLpFwINABdfVtgOqlBKLA = 49;

		private const int bgUDajdbjftfKFlQKLClIqPrOZaoA = 0;

		private const int OidyqBRHmqsqnRjMDEpAawXywvir = 1;

		private const int jClJyldKSEEdkKtyXiEcGoiJldVd = 64;

		private const int hnQAFZJYRDkezSCrosQHFIyXcMlUA = 48;

		private const int DZBtARCCeqqvzNxhhxbheEUxcSCJ = 78;

		private const int dFsDyostOdJeinYIAqTpPpbMHnYO = 5;

		private const int XgkkrGRDvePbcuCowdMFweQpkKjT = 41;

		private const byte CTnppzBqRppHQarlCGXgAjevMgr = 1;

		private const byte ahqUzUukKtdunyOnweZfHeMxnSZgb = 2;

		private const int gfYOnFPuKCQOenhQVcfMeIykakyr = 1;

		private const int FnbrnetKCgiHqjpxUGqgRQyGjWfG = 2;

		private const int uriSqQzSLzCkNNRcZLUkIiEBdhvi = 3;

		private const int SLsNMKifgQbEwcNYmAOKTxRoqlAEA = 4;

		private const int DrbTXJQTXMrGzFHgdaPOxccFXUZ = 5;

		private const int AJYFxmcnINlCIHoKRGJDdWDxuUGR = 6;

		private const int hVnnxUIiYSMcEwVaiWyZxBnAAtuHA = 8;

		private const int DEcPMIVfWZsNgNWRganwKEeljknFA = 22;

		private const int bxAYXyKpJBlphRhUcrNQSPeWhjieA = 16;

		private const int iCZyMMamqtjqqnazYuUIvOuRhZwl = 33;

		private const int JUWPaGaNrwwrSzZgJjealEKTirrbA = 8;

		private const int vqvuMgFTCnKMbpMJQBXuaSYblCtjA = 9;

		private const int RPzPYZuGcbdJAJYWGuziuhXsQGGo = 10;

		private const int uABUMvhOJIcOOUTJVFcYfEoSKOGGA = 28;

		private const int nZplikNaynBsoVVtAcJxQflgiZlM = 53;

		private const int qixAhHTqAiHsaJuYqQwvlxJXVqJNA = 54;

		private const int lfJxVGrhoswlkMsdvHrJUQCgFXlp = 43;

		private const int ibAVipHvqyuqhkRCrdmvJRYhEuPo = 42;

		private const int QmgycIBWOEgsmkBLsTYcgvCDztLI = 48;

		private const int OzSLSqECiXaUYzXafZVlzAKYktKB = 60;

		private const int wBbNTgXBqvJVRgPlDGAugauBgoQd = 60;

		private const int qplsMbzPAKMtocFkIfEHgjUSAGxkA = 3000000;

		private const float BsGeKsJjUzZtwOnQoxEJVkffXxVm = 8192f;

		private const float tHzXfsAlXSIuunErDGKuEFPAEvTU = 0.0010652969f;

		private const float aReYEkXVpICCHvGtTzvmHtpbuviC = 0.06103702f;

		private const float KzRwMtJuBeLveajonEAcPISqaOyJ = 4096f;

		private const float EPFAaitPEIeUQTTXKUZAGuJrvVSA = 16384f;

		private const float LCQDQELUZPtNOJaOWCEjHMtrqWry = 16777216f;

		private const float IGedFSJxdYmghIYzdwjDudLtOMfEA = 268435460f;

		private const float bgfiVNxCWSOqnAgBHmojPhMpBsIc = 0.01999998f;

		private const float fsfGVubvJyPmSTRUzbRbgIYnRvJfb = 8192f;

		private const float cSdaapmrbhgJPTrJPwczXPKfdXsj = 0.98f;

		private const float TiLFFlgytPhwxaQLDfwxVLYkuMcdA = 45f;

		private const float TXKYXaDTyZJkyexLZoaPSSOGyXCd = 20f;

		private const DualSenseVibrationMode GnKzWrBDemVVWPCCEGdHCimdyefWA = DualSenseVibrationMode.Compatible2;

		private readonly IHIDDevice HCzjlNzxoLaYKBoZDcSCwGkJMHwd;

		private readonly HIDProperties pNGxHeIiFlbDnbbGjytAnCjChyPjA;

		private readonly bool BJBidUQBRSalLAQcFPAOYouIvDDV;

		private readonly int QemLPaSJkzesLXrSMjjSbVuszgbE;

		private readonly int UpWkLyCkHgEDxEiuRlyhRQEcglBlA;

		private bool caEdEHcdLWnhFiCKkcQFlidIbiBTB;

		private byte MWREcheyvvqKYnyiBGnYIwgJtCbb;

		private int gqisxEApmoernUmTGCaQCOdqbLPAA;

		private int SxlzTciKBbzraWIFTUhRmEEHWNcP;

		private int XdZhfuDozPMYMKJblFKkwkfbNOCe;

		private int gvZRwiuqkQhsOrRQEEIPzjfWNUVD;

		private readonly NativeBuffer bbZoWffYSwoAXQixxeZoBpCXeCnjA;

		private readonly NativeBuffer mPrAjmkxguVnSOrwAJpbRiqYrnMNA;

		private svXcjurRenDjMJrGFPPkrmozhhdx piWcAhFnVjNKQEgInbWBLvHoFBhVA;

		private int KXxnCnpDHqcpOjWYKRGlwTUrCjbq;

		private bool FgXXevNeFHCAwKKUgIWGPvcwVHHD;

		private bool KqxEylFvEAUAtmHUoyFQAEGrliVe;

		private double fYWzYbeEAntlbiHyKfFjMoymBVBaA;

		private int hJWhZHFfzLIWGwQxqBkUtOTBaaHiA;

		private FPQDYBiQbktagctHnzerPCIUamegA yUckxIxnUcFjoBrjYOSCpbzVvHzw;

		private bool mmEGthNhiQibeRdXOsFxdaIObLNCA;

		private Quaternion YhjcAcwqBbcrpekrJXcOxKthfIuo = Quaternion.identity;

		private DualSenseMicrophoneLightMode vgFyqzZQeCsTdIrdEfMShbiVCWxAA;

		private cpqWrtsPtNOnBBfVkOKYxZBtrxBm FGXAgAhMoCrxoSppQnUjeRwuDJcL;

		private DualSensePlayerLightFlags OkyrTKRQCyJagLCVirKYRNtdkqFh;

		private bool NLdtjAmvnyhMoSLEwfReJGeucYEGA;

		private uint zygOfFtVjaQvAPuJZAaBcTBXSuFG;

		private float vxJhAkJDyzSGbIOSBNpmzcIvkfhi;

		private double IzAqMwXIWFCglXMhiGBUCaWFDKZab;

		private float ndruCbacqngUloWbohYibYqntATJ;

		private readonly IDualSenseTriggerEffect[] kVvkSeRckXyHxkiFVkJoyCmsGRTw = new IDualSenseTriggerEffect[2];

		private readonly byte[] FuKVOBLfxlTfzHNTMmDYkbCnpUJF = new byte[10];

		private readonly byte[] rYmlJjKmavRTnXWXyZmKbjWXBZsN = new byte[11];

		private DualSenseTriggerEffectState[] RIqnScqptksdFekjSRdbHkndJbFR = new DualSenseTriggerEffectState[2];

		private DualSenseVibrationMode FNSzymISNXQCkOJTsWKVDqjMaQXU;

		private byte snkTWRSIJTSncKDHlBATydjMwzxg;

		private bool EtTurOMtwezTzCpaWCmPbAkgEffx;

		private bool ZJTcdgnwLtpMDRVSbKjgsdEYAGTp;

		private bool VdrCIeCAgmElBQhATnBhDZUinazeB;

		private bool UjfEClKAxlOOQxKztaxruFNZlHwMA;

		private bool CQIeIgnkDIGTjczBdXwqHkBgVMWi;

		private bool hgyNCcrpvcduSQxXjstEWxDlkHoy;

		private bool bxKFZuOiZnMblUsgDGpetcPQtcOt;

		private bool DKLFkukhcVwOVKooLAWRPYIOfrIlA;

		private bool UpaDKbDTPdKEfOCtURwKShyItTgv;

		private byte LPighMHmbNDAcVasJkjBYtCiqOxjA;

		private byte nRhRwPRDiviaBcLnszIUmOJwTTPe;

		private Quaternion RvRCRxKoBniNBDpSodbjQtszAGHRA = Quaternion.identity;

		private Quaternion fgIfdHInaCRkOJUYrwDKMCsmBHY = Quaternion.identity;

		private bool dqTEQsTHpxPOFQHQefCHyInLWKoO;

		private int ejRmjerPAQtTJOJhHdtIAGfLNQhf;

		private int[] EKUXdikBkPmfMkQshbLzEnEWgFSq = new int[2];

		private int[] nfzvwqFOuzPcHwmCNUZIrGCpnMYx = new int[2];

		private static uint[] pMPBQKFEnHezBzjxGraHltrIdYLQ = new uint[256]
		{
			3523407757u, 2768625435u, 1007455905u, 1259060791u, 3580832660u, 2724731650u, 996231864u, 1281784366u, 3705235391u, 2883475241u,
			852952723u, 1171273221u, 3686048678u, 2897449776u, 901431946u, 1119744540u, 3484811241u, 3098726271u, 565944005u, 1455205971u,
			3369614320u, 3219065702u, 651582172u, 1372678730u, 3245242331u, 3060352845u, 794826487u, 1483155041u, 3322131394u, 2969862996u,
			671994606u, 1594548856u, 3916222277u, 2657877971u, 123907689u, 1885708031u, 3993045852u, 2567322570u, 1010288u, 1997036262u,
			3887548279u, 2427484129u, 163128923u, 2126386893u, 3772416878u, 2547889144u, 248832578u, 2043925204u, 4108050209u, 2212294583u,
			450215437u, 1842515611u, 4088798008u, 2226203566u, 498629140u, 1790921346u, 4194326291u, 2366072709u, 336475711u, 1661535913u,
			4251816714u, 2322244508u, 325317158u, 1684325040u, 2766056989u, 3554254475u, 1255198513u, 1037565863u, 2746444292u, 3568589458u,
			1304234792u, 985283518u, 2852464175u, 3707901625u, 1141589763u, 856455061u, 2909332022u, 3664761504u, 1130791706u, 878818188u,
			3110715001u, 3463352047u, 1466425173u, 543223747u, 3187964512u, 3372436214u, 1342839628u, 655174618u, 3081909835u, 3233089245u,
			1505515367u, 784033777u, 2967466578u, 3352871620u, 1590793086u, 701932520u, 2679148245u, 3904355907u, 1908338681u, 112844655u,
			2564639436u, 4024072794u, 1993550816u, 30677878u, 2439710439u, 3865851505u, 2137352139u, 140662621u, 2517025534u, 3775001192u,
			2013832146u, 252678980u, 2181537457u, 4110462503u, 1812594589u, 453955339u, 2238339752u, 4067256894u, 1801730948u, 476252946u,
			2363233923u, 4225443349u, 1657960367u, 366298937u, 2343686810u, 4239843852u, 1707062198u, 314082080u, 1069182125u, 1220369467u,
			3518238081u, 2796764439u, 953657524u, 1339070498u, 3604597144u, 2715744526u, 828499103u, 1181144073u, 3748627891u, 2825434405u,
			906764422u, 1091244048u, 3624026538u, 2936369468u, 571309257u, 1426738271u, 3422756325u, 3137613171u, 627095760u, 1382516806u,
			3413039612u, 3161057642u, 752284923u, 1540473965u, 3268974039u, 3051332929u, 733688034u, 1555824756u, 3316994510u, 2998034776u,
			81022053u, 1943239923u, 3940166985u, 2648514015u, 62490748u, 1958656234u, 3988253008u, 2595281350u, 168805463u, 2097738945u,
			3825313147u, 2466682349u, 224526414u, 2053451992u, 3815530850u, 2490061300u, 425942017u, 1852075159u, 4151131437u, 2154433979u,
			504272920u, 1762240654u, 4026595636u, 2265434530u, 397988915u, 1623188645u, 4189500703u, 2393998729u, 282398762u, 1741824188u,
			4275794182u, 2312913296u, 1231433021u, 1046551979u, 2808630289u, 3496967303u, 1309403428u, 957143474u, 2684717064u, 3607279774u,
			1203610895u, 817534361u, 2847130659u, 3736401077u, 1087398166u, 936857984u, 2933784634u, 3654889644u, 1422998873u, 601230799u,
			3135200373u, 3453512931u, 1404893504u, 616286678u, 3182598252u, 3400902906u, 1510651243u, 755860989u, 3020215367u, 3271812305u,
			1567060338u, 710951396u, 3010007134u, 3295551688u, 1913130485u, 84884835u, 2617666777u, 3942734927u, 1969605100u, 40040826u,
			2607524032u, 3966539862u, 2094237127u, 198489425u, 2464015595u, 3856323709u, 2076066270u, 213479752u, 2511347954u, 3803648100u,
			1874795921u, 414723335u, 2175892669u, 4139142187u, 1758648712u, 534112542u, 2262612132u, 4057696306u, 1633981859u, 375629109u,
			2406151311u, 4167943193u, 1711886778u, 286155052u, 2282172566u, 4278190080u
		};

		private const uint BnXfmdRQqICsaAHlfBOxQlqXUrNF = 3940166985u;

		private bool isVibrating
		{
			get
			{
				for (int i = 0; i < base.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EVibrationMotorCount; i++)
				{
					if (vibrationMotors[i].BxdGSwjSxTfTpGjIDKQRyBcYsxwM > 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		float IDualShock4DualSenseCommonExtensionSource.batteryLevel => hJWhZHFfzLIWGwQxqBkUtOTBaaHiA;

		bool IDualShock4DualSenseCommonExtensionSource.batteryCharging => yUckxIxnUcFjoBrjYOSCpbzVvHzw == FPQDYBiQbktagctHnzerPCIUamegA.Charging;

		DualSenseVibrationMode IDualSenseExtensionSource.vibrationMode
		{
			get
			{
				return FNSzymISNXQCkOJTsWKVDqjMaQXU;
			}
			set
			{
				FNSzymISNXQCkOJTsWKVDqjMaQXU = value;
				IXCSBWaZseeZaCWujIUiTRZRfVYl();
			}
		}

		float IDualShock4DualSenseCommonExtensionSource.leftMotor
		{
			get
			{
				return vibrationMotors[0].YqehZNHYymBOIHmEqdEdyQFwXHSt;
			}
			set
			{
				vibrationMotors[0].YqehZNHYymBOIHmEqdEdyQFwXHSt = value;
			}
		}

		float IDualShock4DualSenseCommonExtensionSource.rightMotor
		{
			get
			{
				return vibrationMotors[1].YqehZNHYymBOIHmEqdEdyQFwXHSt;
			}
			set
			{
				vibrationMotors[1].YqehZNHYymBOIHmEqdEdyQFwXHSt = value;
			}
		}

		float IDualShock4DualSenseCommonExtensionSource.lightColorR
		{
			get
			{
				return lights[0].gxJCEupKQiTeAkVzrtpTDcOnkNHK;
			}
			set
			{
				lights[0].gxJCEupKQiTeAkVzrtpTDcOnkNHK = value;
			}
		}

		float IDualShock4DualSenseCommonExtensionSource.lightColorG
		{
			get
			{
				return lights[0].jjyHPxghAMhDboCnrydFOAVTYroP;
			}
			set
			{
				lights[0].jjyHPxghAMhDboCnrydFOAVTYroP = value;
			}
		}

		float IDualShock4DualSenseCommonExtensionSource.lightColorB
		{
			get
			{
				return lights[0].DgsukjedRAdkEjThvNBMDeJoXbZhA;
			}
			set
			{
				lights[0].DgsukjedRAdkEjThvNBMDeJoXbZhA = value;
			}
		}

		float IDualShock4DualSenseCommonExtensionSource.lightFlashOnDuration
		{
			get
			{
				return (int)LPighMHmbNDAcVasJkjBYtCiqOxjA;
			}
			set
			{
				LPighMHmbNDAcVasJkjBYtCiqOxjA = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				HBxSXWGAyEljLSbnbhdlCXXcUgoqA();
				if (LPighMHmbNDAcVasJkjBYtCiqOxjA == 0 && nRhRwPRDiviaBcLnszIUmOJwTTPe == 0)
				{
					KqxEylFvEAUAtmHUoyFQAEGrliVe = true;
				}
			}
		}

		float IDualShock4DualSenseCommonExtensionSource.lightFlashOffDuration
		{
			get
			{
				return (int)nRhRwPRDiviaBcLnszIUmOJwTTPe;
			}
			set
			{
				nRhRwPRDiviaBcLnszIUmOJwTTPe = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				HBxSXWGAyEljLSbnbhdlCXXcUgoqA();
				if (LPighMHmbNDAcVasJkjBYtCiqOxjA == 0 && nRhRwPRDiviaBcLnszIUmOJwTTPe == 0)
				{
					KqxEylFvEAUAtmHUoyFQAEGrliVe = true;
				}
			}
		}

		DualSenseMicrophoneLightMode IDualSenseExtensionSource.microphoneLightMode
		{
			get
			{
				return vgFyqzZQeCsTdIrdEfMShbiVCWxAA;
			}
			set
			{
				vgFyqzZQeCsTdIrdEfMShbiVCWxAA = value;
				IXCSBWaZseeZaCWujIUiTRZRfVYl();
				UjfEClKAxlOOQxKztaxruFNZlHwMA = true;
			}
		}

		DualSenseOtherLightBrightness IDualSenseExtensionSource.otherLightBrightness
		{
			get
			{
				return ZMydlyAwUlSnblTDuUopsaQYmWgc(FGXAgAhMoCrxoSppQnUjeRwuDJcL);
			}
			set
			{
				FGXAgAhMoCrxoSppQnUjeRwuDJcL = sqCAnTSXKZSWYStsAirZatjIAtrL(value);
				IXCSBWaZseeZaCWujIUiTRZRfVYl();
				hgyNCcrpvcduSQxXjstEWxDlkHoy = true;
			}
		}

		DualSensePlayerLightFlags IDualSenseExtensionSource.playerLights
		{
			get
			{
				return OkyrTKRQCyJagLCVirKYRNtdkqFh;
			}
			set
			{
				OkyrTKRQCyJagLCVirKYRNtdkqFh = value;
				IXCSBWaZseeZaCWujIUiTRZRfVYl();
				CQIeIgnkDIGTjczBdXwqHkBgVMWi = true;
			}
		}

		Vector3 IDualShock4DualSenseCommonExtensionSource.accelerometerValue => qXTrtvDwYPbMHGyrkOolzhCLNRdA(accelerometers[0].WuxcudBBVzHNVwoaaucXfPaFfSOU);

		Vector3 IDualShock4DualSenseCommonExtensionSource.accelerometerValueRaw => new Vector3(accelerometers[0].WuxcudBBVzHNVwoaaucXfPaFfSOU[0], accelerometers[0].WuxcudBBVzHNVwoaaucXfPaFfSOU[1], accelerometers[0].WuxcudBBVzHNVwoaaucXfPaFfSOU[2]);

		Vector3 IDualShock4DualSenseCommonExtensionSource.gyroscopeValue => PbulnhgpfGIraRbnpHktdNBRyCAiA(gyroscopes[0].eTrgYsFlPQxbSPEyqbAXOGmMXzVD);

		Vector3 IDualShock4DualSenseCommonExtensionSource.gyroscopeValueRaw => new Vector3(gyroscopes[0].YZhnygGArvWYHTgbFoiNYQuaNTyS[0], gyroscopes[0].YZhnygGArvWYHTgbFoiNYQuaNTyS[1], gyroscopes[0].YZhnygGArvWYHTgbFoiNYQuaNTyS[2]);

		Vector3 IDualShock4DualSenseCommonExtensionSource.lastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].FOFdTvxaVfzjKuXtYfOzBSpyuzjD[0], gyroscopes[0].FOFdTvxaVfzjKuXtYfOzBSpyuzjD[1], gyroscopes[0].FOFdTvxaVfzjKuXtYfOzBSpyuzjD[2]);
				return gZjANlKLAvMViHKWxmivncALesyI(vector, vxJhAkJDyzSGbIOSBNpmzcIvkfhi);
			}
		}

		Vector3 IDualShock4DualSenseCommonExtensionSource.lastGyroscopeValueRaw => new Vector3(gyroscopes[0].FOFdTvxaVfzjKuXtYfOzBSpyuzjD[0], gyroscopes[0].FOFdTvxaVfzjKuXtYfOzBSpyuzjD[1], gyroscopes[0].FOFdTvxaVfzjKuXtYfOzBSpyuzjD[2]);

		Quaternion IDualShock4DualSenseCommonExtensionSource.orientation => YhjcAcwqBbcrpekrJXcOxKthfIuo;

		int IDualShock4DualSenseCommonExtensionSource.maxTouches => 2;

		ushort IHIDControllerExtension.vendorId => pNGxHeIiFlbDnbbGjytAnCjChyPjA.vendorId;

		ushort IHIDControllerExtension.productId => pNGxHeIiFlbDnbbGjytAnCjChyPjA.productId;

		string IHIDControllerExtension.productName => pNGxHeIiFlbDnbbGjytAnCjChyPjA.productName;

		string IHIDControllerExtension.manufacturer => pNGxHeIiFlbDnbbGjytAnCjChyPjA.manufacturer;

		ushort IHIDControllerExtension.usagePage => pNGxHeIiFlbDnbbGjytAnCjChyPjA.usagePage;

		ushort IHIDControllerExtension.usage => pNGxHeIiFlbDnbbGjytAnCjChyPjA.usage;

		public void ResetOrientation()
		{
			YhjcAcwqBbcrpekrJXcOxKthfIuo = Quaternion.identity;
			dqTEQsTHpxPOFQHQefCHyInLWKoO = false;
		}

		void IDualShock4DualSenseCommonExtensionSource.ResetOrientation()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ResetOrientation
			this.ResetOrientation();
		}

		public int GetTouchCount()
		{
			int num = 0;
			for (int i = 0; i < 2; i++)
			{
				if (touchpads[0].KUQBOGfLZVeZToGzEycJtsYzolPab[i].isTouching)
				{
					num++;
				}
			}
			return num;
		}

		int IDualShock4DualSenseCommonExtensionSource.GetTouchCount()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchCount
			return this.GetTouchCount();
		}

		public bool IsTouchingAtIndex(int index)
		{
			if (index < 0 || index >= 2)
			{
				return false;
			}
			return touchpads[0].KUQBOGfLZVeZToGzEycJtsYzolPab[index].isTouching;
		}

		bool IDualShock4DualSenseCommonExtensionSource.IsTouchingAtIndex(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsTouchingAtIndex
			return this.IsTouchingAtIndex(index);
		}

		public bool IsTouchingAtTouchId(int touchId)
		{
			return touchpads[0].NKWCgdlFAhYRGtzEYBcTkWuDbbZI(touchId);
		}

		bool IDualShock4DualSenseCommonExtensionSource.IsTouchingAtTouchId(int touchId)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsTouchingAtTouchId
			return this.IsTouchingAtTouchId(touchId);
		}

		public int GetTouchIdAtIndex(int index)
		{
			if (index < 0 || index >= 2)
			{
				return -1;
			}
			return touchpads[0].KUQBOGfLZVeZToGzEycJtsYzolPab[index].touchId;
		}

		int IDualShock4DualSenseCommonExtensionSource.GetTouchIdAtIndex(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchIdAtIndex
			return this.GetTouchIdAtIndex(index);
		}

		public bool GetTouchPositionByIndex(int index, out Vector2 position)
		{
			position = default(Vector2);
			if (index < 0 || index >= 2)
			{
				return false;
			}
			NaCRucjlkvXgCSkUJCtQCAeoSdInA.TouchData[] kUQBOGfLZVeZToGzEycJtsYzolPab = touchpads[0].KUQBOGfLZVeZToGzEycJtsYzolPab;
			if (!kUQBOGfLZVeZToGzEycJtsYzolPab[index].isTouching)
			{
				return false;
			}
			position.x = kUQBOGfLZVeZToGzEycJtsYzolPab[index].positionX;
			position.y = kUQBOGfLZVeZToGzEycJtsYzolPab[index].positionY;
			return true;
		}

		bool IDualShock4DualSenseCommonExtensionSource.GetTouchPositionByIndex(int index, out Vector2 position)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionByIndex
			return this.GetTouchPositionByIndex(index, out position);
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			position = default(Vector2);
			if (!touchpads[0].NKWCgdlFAhYRGtzEYBcTkWuDbbZI(touchId))
			{
				return false;
			}
			NaCRucjlkvXgCSkUJCtQCAeoSdInA.TouchData[] kUQBOGfLZVeZToGzEycJtsYzolPab = touchpads[0].KUQBOGfLZVeZToGzEycJtsYzolPab;
			for (int i = 0; i < kUQBOGfLZVeZToGzEycJtsYzolPab.Length; i++)
			{
				if (kUQBOGfLZVeZToGzEycJtsYzolPab[i].isTouching)
				{
					position.x = kUQBOGfLZVeZToGzEycJtsYzolPab[i].positionX;
					position.y = kUQBOGfLZVeZToGzEycJtsYzolPab[i].positionY;
				}
			}
			return true;
		}

		bool IDualShock4DualSenseCommonExtensionSource.GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionByTouchId
			return this.GetTouchPositionByTouchId(touchId, out position);
		}

		public bool GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY)
		{
			positionX = 0;
			positionY = 0;
			if (index < 0 || index >= 2)
			{
				return false;
			}
			NaCRucjlkvXgCSkUJCtQCAeoSdInA.TouchData[] kUQBOGfLZVeZToGzEycJtsYzolPab = touchpads[0].KUQBOGfLZVeZToGzEycJtsYzolPab;
			if (!kUQBOGfLZVeZToGzEycJtsYzolPab[index].isTouching)
			{
				return false;
			}
			positionX = kUQBOGfLZVeZToGzEycJtsYzolPab[index].positionAbsX;
			positionY = kUQBOGfLZVeZToGzEycJtsYzolPab[index].positionAbsY;
			return true;
		}

		bool IDualShock4DualSenseCommonExtensionSource.GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionAbsoluteByIndex
			return this.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
		}

		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
		{
			positionX = 0;
			positionY = 0;
			if (!touchpads[0].NKWCgdlFAhYRGtzEYBcTkWuDbbZI(touchId))
			{
				return false;
			}
			NaCRucjlkvXgCSkUJCtQCAeoSdInA.TouchData[] kUQBOGfLZVeZToGzEycJtsYzolPab = touchpads[0].KUQBOGfLZVeZToGzEycJtsYzolPab;
			for (int i = 0; i < kUQBOGfLZVeZToGzEycJtsYzolPab.Length; i++)
			{
				if (kUQBOGfLZVeZToGzEycJtsYzolPab[i].isTouching)
				{
					positionX = kUQBOGfLZVeZToGzEycJtsYzolPab[i].positionAbsX;
					positionY = kUQBOGfLZVeZToGzEycJtsYzolPab[i].positionAbsY;
				}
			}
			return true;
		}

		bool IDualShock4DualSenseCommonExtensionSource.GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionAbsoluteByTouchId
			return this.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
		}

		public void StopLightFlash()
		{
			LPighMHmbNDAcVasJkjBYtCiqOxjA = 0;
			nRhRwPRDiviaBcLnszIUmOJwTTPe = 0;
			IXCSBWaZseeZaCWujIUiTRZRfVYl();
			KqxEylFvEAUAtmHUoyFQAEGrliVe = true;
			bxKFZuOiZnMblUsgDGpetcPQtcOt = true;
		}

		void IDualShock4DualSenseCommonExtensionSource.StopLightFlash()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopLightFlash
			this.StopLightFlash();
		}

		public void StopVibration()
		{
			int num = base.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EVibrationMotorCount;
			for (int i = 0; i < num; i++)
			{
				vibrationMotors[i].BxdGSwjSxTfTpGjIDKQRyBcYsxwM = 0;
			}
		}

		void IDualShock4DualSenseCommonExtensionSource.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public bool SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect)
		{
			switch (trigger)
			{
			case DualSenseTriggerType.Left:
				kVvkSeRckXyHxkiFVkJoyCmsGRTw[0] = effect;
				IXCSBWaZseeZaCWujIUiTRZRfVYl();
				ZJTcdgnwLtpMDRVSbKjgsdEYAGTp = true;
				return true;
			case DualSenseTriggerType.Right:
				kVvkSeRckXyHxkiFVkJoyCmsGRTw[1] = effect;
				IXCSBWaZseeZaCWujIUiTRZRfVYl();
				VdrCIeCAgmElBQhATnBhDZUinazeB = true;
				return true;
			default:
				return false;
			}
		}

		bool IDualSenseExtensionSource.SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetTriggerEffect
			return this.SetTriggerEffect(trigger, effect);
		}

		public DualSenseTriggerEffectStates GetTriggerEffectStates()
		{
			return new DualSenseTriggerEffectStates
			{
				leftTrigger = RIqnScqptksdFekjSRdbHkndJbFR[0],
				rightTrigger = RIqnScqptksdFekjSRdbHkndJbFR[1]
			};
		}

		DualSenseTriggerEffectStates IDualSenseExtensionSource.GetTriggerEffectStates()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTriggerEffectStates
			return this.GetTriggerEffectStates();
		}

		public DualSenseDriver(InitArgs P_0)
			: base(P_0)
		{
			HCzjlNzxoLaYKBoZDcSCwGkJMHwd = P_0.hidDevice;
			pNGxHeIiFlbDnbbGjytAnCjChyPjA = HCzjlNzxoLaYKBoZDcSCwGkJMHwd.properties;
			QemLPaSJkzesLXrSMjjSbVuszgbE = P_0.hatZeroValue;
			UpWkLyCkHgEDxEiuRlyhRQEcglBlA = P_0.hatSpan;
			BJBidUQBRSalLAQcFPAOYouIvDDV = P_0.connectionType == OzbKZwmCsAMtNgCdYlCwZEMUUFwG.Bluetooth;
			if (BJBidUQBRSalLAQcFPAOYouIvDDV)
			{
				KXxnCnpDHqcpOjWYKRGlwTUrCjbq = 78;
			}
			else
			{
				KXxnCnpDHqcpOjWYKRGlwTUrCjbq = 48;
			}
			bbZoWffYSwoAXQixxeZoBpCXeCnjA = new NativeBuffer(64);
			mPrAjmkxguVnSOrwAJpbRiqYrnMNA = new NativeBuffer(KXxnCnpDHqcpOjWYKRGlwTUrCjbq);
			piWcAhFnVjNKQEgInbWBLvHoFBhVA = new svXcjurRenDjMJrGFPPkrmozhhdx(mPrAjmkxguVnSOrwAJpbRiqYrnMNA.Pointer, mPrAjmkxguVnSOrwAJpbRiqYrnMNA.Length, KXxnCnpDHqcpOjWYKRGlwTUrCjbq);
			lights = new nmpBQAovYKAFTjYpVLxEGKXmVudz[1]
			{
				new nmpBQAovYKAFTjYpVLxEGKXmVudz(11, 24, 28)
			};
			lights[0].MLtUdFrKUcdYvCKPAcoFdFnKMjWRA += lEbyvHFFCZfCnsrQkbrFvkIDBRPIA;
			vibrationMotors = new uctGEmIAndGsnBPlyPlnhlfoOqoG[2]
			{
				new uctGEmIAndGsnBPlyPlnhlfoOqoG(0, 255),
				new uctGEmIAndGsnBPlyPlnhlfoOqoG(0, 255)
			};
			vibrationMotors[0].FxFPDwUFaZlttspQRrgthdlYGjxL += giZeAXjSkShmjGwEWmHrhgcTBzrBA;
			vibrationMotors[1].FxFPDwUFaZlttspQRrgthdlYGjxL += giZeAXjSkShmjGwEWmHrhgcTBzrBA;
			FNSzymISNXQCkOJTsWKVDqjMaQXU = DualSenseVibrationMode.Compatible2;
			EtTurOMtwezTzCpaWCmPbAkgEffx = true;
			ZJTcdgnwLtpMDRVSbKjgsdEYAGTp = true;
			VdrCIeCAgmElBQhATnBhDZUinazeB = true;
			UjfEClKAxlOOQxKztaxruFNZlHwMA = true;
			CQIeIgnkDIGTjczBdXwqHkBgVMWi = true;
			hgyNCcrpvcduSQxXjstEWxDlkHoy = true;
			bxKFZuOiZnMblUsgDGpetcPQtcOt = true;
			DKLFkukhcVwOVKooLAWRPYIOfrIlA = true;
			UpaDKbDTPdKEfOCtURwKShyItTgv = true;
			snkTWRSIJTSncKDHlBATydjMwzxg = 2;
		}

		protected override void OnInitialize()
		{
			if (BJBidUQBRSalLAQcFPAOYouIvDDV)
			{
				byte[] hidFeatureData = HCzjlNzxoLaYKBoZDcSCwGkJMHwd.GetHidFeatureData(5, 41, 1000, 3);
				caEdEHcdLWnhFiCKkcQFlidIbiBTB = hidFeatureData != null && hidFeatureData.Length != 0;
				if (caEdEHcdLWnhFiCKkcQFlidIbiBTB)
				{
					wvGWdKqTzWnzYLDdhalQYRiyDKpz(PaswCStrAkmQpcZYWcZPEJHLfUmk.Synchronous);
				}
			}
			else
			{
				caEdEHcdLWnhFiCKkcQFlidIbiBTB = true;
				caEdEHcdLWnhFiCKkcQFlidIbiBTB = wvGWdKqTzWnzYLDdhalQYRiyDKpz(PaswCStrAkmQpcZYWcZPEJHLfUmk.Synchronous);
			}
			if (!caEdEHcdLWnhFiCKkcQFlidIbiBTB)
			{
				throw new Exception("Special features not supported so just treat this as a standard HID device.");
			}
			MWREcheyvvqKYnyiBGnYIwgJtCbb = 1;
			gqisxEApmoernUmTGCaQCOdqbLPAA = 0;
			if (BJBidUQBRSalLAQcFPAOYouIvDDV && caEdEHcdLWnhFiCKkcQFlidIbiBTB)
			{
				MWREcheyvvqKYnyiBGnYIwgJtCbb = 49;
				gqisxEApmoernUmTGCaQCOdqbLPAA = 1;
			}
			SxlzTciKBbzraWIFTUhRmEEHWNcP = 8 + gqisxEApmoernUmTGCaQCOdqbLPAA;
			XdZhfuDozPMYMKJblFKkwkfbNOCe = 9 + gqisxEApmoernUmTGCaQCOdqbLPAA;
			gvZRwiuqkQhsOrRQEEIPzjfWNUVD = 10 + gqisxEApmoernUmTGCaQCOdqbLPAA;
			buttons = new JdXatRCvdrGKOPnZjOPQbsdPzHroA[15];
			for (int i = 0; i < 15; i++)
			{
				buttons[i] = new JdXatRCvdrGKOPnZjOPQbsdPzHroA(MWREcheyvvqKYnyiBGnYIwgJtCbb, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new okLUGVdjnOaHkqUoOikOkGMRQUCY[6]
			{
				new okLUGVdjnOaHkqUoOikOkGMRQUCY(MWREcheyvvqKYnyiBGnYIwgJtCbb, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + gqisxEApmoernUmTGCaQCOdqbLPAA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new okLUGVdjnOaHkqUoOikOkGMRQUCY(MWREcheyvvqKYnyiBGnYIwgJtCbb, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + gqisxEApmoernUmTGCaQCOdqbLPAA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new okLUGVdjnOaHkqUoOikOkGMRQUCY(MWREcheyvvqKYnyiBGnYIwgJtCbb, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + gqisxEApmoernUmTGCaQCOdqbLPAA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new okLUGVdjnOaHkqUoOikOkGMRQUCY(MWREcheyvvqKYnyiBGnYIwgJtCbb, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + gqisxEApmoernUmTGCaQCOdqbLPAA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new okLUGVdjnOaHkqUoOikOkGMRQUCY(MWREcheyvvqKYnyiBGnYIwgJtCbb, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 5 + gqisxEApmoernUmTGCaQCOdqbLPAA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0),
				new okLUGVdjnOaHkqUoOikOkGMRQUCY(MWREcheyvvqKYnyiBGnYIwgJtCbb, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 6 + gqisxEApmoernUmTGCaQCOdqbLPAA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0)
			};
			hats = new GEIDFkFhuurDROYbxKEnrCaVcLKaA[1]
			{
				new GEIDFkFhuurDROYbxKEnrCaVcLKaA(MWREcheyvvqKYnyiBGnYIwgJtCbb, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 8 + gqisxEApmoernUmTGCaQCOdqbLPAA,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20u,
					unitsExp = 0u
				}, GskMKpIprxTIFBZvwKJvFuHcHsoI)
			};
			accelerometers = new dHcOwexRBkWbxHglTolQUMSGZbys[1]
			{
				new dHcOwexRBkWbxHglTolQUMSGZbys(MWREcheyvvqKYnyiBGnYIwgJtCbb, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					dataIndex = 22 + gqisxEApmoernUmTGCaQCOdqbLPAA,
					bitSize = 48
				}, 3, zqoytiGGRYxFVqFXJzQgZJFBEcnc)
			};
			gyroscopes = new jntvuWnVLbBPQuLLgPmMmaPxgSGi[1]
			{
				new jntvuWnVLbBPQuLLgPmMmaPxgSGi(base.initArgs.updateLoopSetting, MWREcheyvvqKYnyiBGnYIwgJtCbb, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					dataIndex = 16 + gqisxEApmoernUmTGCaQCOdqbLPAA,
					bitSize = 48
				}, 3, 60, fpjIasBPlUdijaZLSzatvOyVEdwAb, fSXgcHkrcdpqikXarpSCsTdxnToDb)
			};
			touchpads = new NaCRucjlkvXgCSkUJCtQCAeoSdInA[1]
			{
				new NaCRucjlkvXgCSkUJCtQCAeoSdInA(MWREcheyvvqKYnyiBGnYIwgJtCbb, new NaCRucjlkvXgCSkUJCtQCAeoSdInA.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					dataIndex = 33 + gqisxEApmoernUmTGCaQCOdqbLPAA,
					bitSize = 48
				}, 60, dUYmImwJxSvvVjerBppxapNzByMF)
			};
			IzAqMwXIWFCglXMhiGBUCaWFDKZab = ReInput.realTime;
			InitializationFinished(initialized: true);
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			mQXuFMfFQVjNFdZGpTOPVrfvEhMk();
			AvbXJkhinuNlNYrVyNffzCRUKvSS(PaswCStrAkmQpcZYWcZPEJHLfUmk.Asynchronous);
		}

		public unsafe override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < bbZoWffYSwoAXQixxeZoBpCXeCnjA.Length)
			{
				return false;
			}
			if (BJBidUQBRSalLAQcFPAOYouIvDDV && caEdEHcdLWnhFiCKkcQFlidIbiBTB && *(byte*)(void*)inputReportPtr == 1)
			{
				return false;
			}
			ndruCbacqngUloWbohYibYqntATJ = (float)(timestamp - IzAqMwXIWFCglXMhiGBUCaWFDKZab);
			IzAqMwXIWFCglXMhiGBUCaWFDKZab = timestamp;
			bbZoWffYSwoAXQixxeZoBpCXeCnjA.Write(inputReportPtr, inputReportLength, bbZoWffYSwoAXQixxeZoBpCXeCnjA.Length);
			UyuIrBGQzYhyTdXTPCShdDfgzwsB(bbZoWffYSwoAXQixxeZoBpCXeCnjA);
			iNGCxmwfGrdUepXTEAJdDagrpCzBA(bbZoWffYSwoAXQixxeZoBpCXeCnjA, timestamp);
			VJJORtyhxtIZFDAvjUdtXgBUbPYD[] array = axes;
			PzIEUnPFHKyjNdssfoAvBjHDlnWr(array, bbZoWffYSwoAXQixxeZoBpCXeCnjA, timestamp);
			array = hats;
			PzIEUnPFHKyjNdssfoAvBjHDlnWr(array, bbZoWffYSwoAXQixxeZoBpCXeCnjA, timestamp);
			array = accelerometers;
			PzIEUnPFHKyjNdssfoAvBjHDlnWr(array, bbZoWffYSwoAXQixxeZoBpCXeCnjA, timestamp);
			array = gyroscopes;
			PzIEUnPFHKyjNdssfoAvBjHDlnWr(array, bbZoWffYSwoAXQixxeZoBpCXeCnjA, timestamp);
			array = touchpads;
			PzIEUnPFHKyjNdssfoAvBjHDlnWr(array, bbZoWffYSwoAXQixxeZoBpCXeCnjA, timestamp);
			byte b = bbZoWffYSwoAXQixxeZoBpCXeCnjA[53 + gqisxEApmoernUmTGCaQCOdqbLPAA];
			jVHpZuPGTUgXiWEJXBDCFmSDsAVp jVHpZuPGTUgXiWEJXBDCFmSDsAVp2 = (jVHpZuPGTUgXiWEJXBDCFmSDsAVp)((b & 0xF0) >> 4);
			if (jVHpZuPGTUgXiWEJXBDCFmSDsAVp2 <= jVHpZuPGTUgXiWEJXBDCFmSDsAVp.Full)
			{
				if (jVHpZuPGTUgXiWEJXBDCFmSDsAVp2 > jVHpZuPGTUgXiWEJXBDCFmSDsAVp.Charging)
				{
					if (jVHpZuPGTUgXiWEJXBDCFmSDsAVp2 != jVHpZuPGTUgXiWEJXBDCFmSDsAVp.Full)
					{
						goto IL_0171;
					}
					hJWhZHFfzLIWGwQxqBkUtOTBaaHiA = 100;
					yUckxIxnUcFjoBrjYOSCpbzVvHzw = FPQDYBiQbktagctHnzerPCIUamegA.Full;
				}
				else
				{
					hJWhZHFfzLIWGwQxqBkUtOTBaaHiA = MathTools.Clamp((b & 0xF) * 10 + 5, 0, 100);
					yUckxIxnUcFjoBrjYOSCpbzVvHzw = ((jVHpZuPGTUgXiWEJXBDCFmSDsAVp2 != jVHpZuPGTUgXiWEJXBDCFmSDsAVp.Charging) ? FPQDYBiQbktagctHnzerPCIUamegA.Discharging : FPQDYBiQbktagctHnzerPCIUamegA.Charging);
				}
			}
			else
			{
				if (jVHpZuPGTUgXiWEJXBDCFmSDsAVp2 - 10 > jVHpZuPGTUgXiWEJXBDCFmSDsAVp.Charging)
				{
					if (jVHpZuPGTUgXiWEJXBDCFmSDsAVp2 == jVHpZuPGTUgXiWEJXBDCFmSDsAVp.ChargingError)
					{
					}
					goto IL_0171;
				}
				hJWhZHFfzLIWGwQxqBkUtOTBaaHiA = 0;
				yUckxIxnUcFjoBrjYOSCpbzVvHzw = FPQDYBiQbktagctHnzerPCIUamegA.Charging;
			}
			goto IL_017f;
			IL_0171:
			hJWhZHFfzLIWGwQxqBkUtOTBaaHiA = 0;
			yUckxIxnUcFjoBrjYOSCpbzVvHzw = FPQDYBiQbktagctHnzerPCIUamegA.Unknown;
			goto IL_017f;
			IL_017f:
			mmEGthNhiQibeRdXOsFxdaIObLNCA = (bbZoWffYSwoAXQixxeZoBpCXeCnjA[54 + gqisxEApmoernUmTGCaQCOdqbLPAA] & 1) != 0;
			RIqnScqptksdFekjSRdbHkndJbFR[0] = tCijcsMdVgscWOxjxNGISBTcpLaX(DualSenseTriggerType.Left, bbZoWffYSwoAXQixxeZoBpCXeCnjA[43 + gqisxEApmoernUmTGCaQCOdqbLPAA], bbZoWffYSwoAXQixxeZoBpCXeCnjA[48 + gqisxEApmoernUmTGCaQCOdqbLPAA]);
			RIqnScqptksdFekjSRdbHkndJbFR[1] = tCijcsMdVgscWOxjxNGISBTcpLaX(DualSenseTriggerType.Right, bbZoWffYSwoAXQixxeZoBpCXeCnjA[42 + gqisxEApmoernUmTGCaQCOdqbLPAA], bbZoWffYSwoAXQixxeZoBpCXeCnjA[48 + gqisxEApmoernUmTGCaQCOdqbLPAA]);
			PptOqWLNsEumoAKMUZoYSgiFHGSS();
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualSenseExtension(this);
		}

		private void AvbXJkhinuNlNYrVyNffzCRUKvSS(PaswCStrAkmQpcZYWcZPEJHLfUmk P_0)
		{
			if (FgXXevNeFHCAwKKUgIWGPvcwVHHD)
			{
				wvGWdKqTzWnzYLDdhalQYRiyDKpz(P_0);
				FgXXevNeFHCAwKKUgIWGPvcwVHHD = false;
			}
		}

		private bool wvGWdKqTzWnzYLDdhalQYRiyDKpz(PaswCStrAkmQpcZYWcZPEJHLfUmk P_0)
		{
			JdPhRCThXDzcvPqlQgOaUViKCRdfA();
			bool result = LpQxpBPiURqommovdYSyORuPAsET(P_0);
			if (KqxEylFvEAUAtmHUoyFQAEGrliVe)
			{
				result = LpQxpBPiURqommovdYSyORuPAsET(P_0);
				KqxEylFvEAUAtmHUoyFQAEGrliVe = false;
			}
			return result;
		}

		private void JdPhRCThXDzcvPqlQgOaUViKCRdfA()
		{
			if (BJBidUQBRSalLAQcFPAOYouIvDDV && caEdEHcdLWnhFiCKkcQFlidIbiBTB)
			{
				mPrAjmkxguVnSOrwAJpbRiqYrnMNA[0] = 49;
				mPrAjmkxguVnSOrwAJpbRiqYrnMNA[1] = 2;
				kJMRNIgBORvpoOBdshEBZldNBEEl(mPrAjmkxguVnSOrwAJpbRiqYrnMNA, 2);
				uint num = SoybfAunbysWnPXduaOXOGBljsqm(mPrAjmkxguVnSOrwAJpbRiqYrnMNA, 74);
				mPrAjmkxguVnSOrwAJpbRiqYrnMNA[74] = (byte)(num & 0xFF);
				mPrAjmkxguVnSOrwAJpbRiqYrnMNA[75] = (byte)((num & 0xFF00) >> 8);
				mPrAjmkxguVnSOrwAJpbRiqYrnMNA[76] = (byte)((num & 0xFF0000) >> 16);
				mPrAjmkxguVnSOrwAJpbRiqYrnMNA[77] = (byte)((num & 0xFF000000u) >> 24);
			}
			else
			{
				mPrAjmkxguVnSOrwAJpbRiqYrnMNA[0] = 2;
				kJMRNIgBORvpoOBdshEBZldNBEEl(mPrAjmkxguVnSOrwAJpbRiqYrnMNA, 1);
			}
		}

		private void kJMRNIgBORvpoOBdshEBZldNBEEl(NativeBuffer P_0, int P_1)
		{
			GLfeGDteHeqvIIhBMgaRCLUfqaDK gLfeGDteHeqvIIhBMgaRCLUfqaDK = GLfeGDteHeqvIIhBMgaRCLUfqaDK.None;
			bmJMarTHaOhNYcwJIKKXNGnHiqUhA bmJMarTHaOhNYcwJIKKXNGnHiqUhA2 = bmJMarTHaOhNYcwJIKKXNGnHiqUhA.None;
			gLfeGDteHeqvIIhBMgaRCLUfqaDK |= GLfeGDteHeqvIIhBMgaRCLUfqaDK.HapticsSelect;
			if (FNSzymISNXQCkOJTsWKVDqjMaQXU == DualSenseVibrationMode.Compatible)
			{
				gLfeGDteHeqvIIhBMgaRCLUfqaDK |= GLfeGDteHeqvIIhBMgaRCLUfqaDK.CompatibleVibrationMode1;
			}
			EtTurOMtwezTzCpaWCmPbAkgEffx = false;
			gLfeGDteHeqvIIhBMgaRCLUfqaDK |= GLfeGDteHeqvIIhBMgaRCLUfqaDK.LeftTriggerEffect;
			ZJTcdgnwLtpMDRVSbKjgsdEYAGTp = false;
			gLfeGDteHeqvIIhBMgaRCLUfqaDK |= GLfeGDteHeqvIIhBMgaRCLUfqaDK.RightTriggerEffect;
			VdrCIeCAgmElBQhATnBhDZUinazeB = false;
			bmJMarTHaOhNYcwJIKKXNGnHiqUhA2 |= bmJMarTHaOhNYcwJIKKXNGnHiqUhA.MicrophoneLEDControl;
			UjfEClKAxlOOQxKztaxruFNZlHwMA = false;
			bmJMarTHaOhNYcwJIKKXNGnHiqUhA2 |= bmJMarTHaOhNYcwJIKKXNGnHiqUhA.PlayerIndicatorLEDControl;
			CQIeIgnkDIGTjczBdXwqHkBgVMWi = false;
			bmJMarTHaOhNYcwJIKKXNGnHiqUhA2 |= bmJMarTHaOhNYcwJIKKXNGnHiqUhA.LightbarControl;
			bxKFZuOiZnMblUsgDGpetcPQtcOt = false;
			bmJMarTHaOhNYcwJIKKXNGnHiqUhA2 |= bmJMarTHaOhNYcwJIKKXNGnHiqUhA.ChangeOverallMotorEffectPower;
			UpaDKbDTPdKEfOCtURwKShyItTgv = false;
			P_0[P_1] = (byte)gLfeGDteHeqvIIhBMgaRCLUfqaDK;
			P_0[1 + P_1] = (byte)bmJMarTHaOhNYcwJIKKXNGnHiqUhA2;
			P_0[2 + P_1] = (byte)vibrationMotors[1].BxdGSwjSxTfTpGjIDKQRyBcYsxwM;
			P_0[3 + P_1] = (byte)vibrationMotors[0].BxdGSwjSxTfTpGjIDKQRyBcYsxwM;
			P_0[8 + P_1] = (byte)vgFyqzZQeCsTdIrdEfMShbiVCWxAA;
			AHPvaZCdHCyQBJkPUpKjjBGcCciX aHPvaZCdHCyQBJkPUpKjjBGcCciX = AHPvaZCdHCyQBJkPUpKjjBGcCciX.None;
			aHPvaZCdHCyQBJkPUpKjjBGcCciX |= AHPvaZCdHCyQBJkPUpKjjBGcCciX.OtherLightBrightnessControl;
			hgyNCcrpvcduSQxXjstEWxDlkHoy = false;
			if (FNSzymISNXQCkOJTsWKVDqjMaQXU == DualSenseVibrationMode.Compatible2)
			{
				aHPvaZCdHCyQBJkPUpKjjBGcCciX |= AHPvaZCdHCyQBJkPUpKjjBGcCciX.CompatibleVibrationMode2;
			}
			aHPvaZCdHCyQBJkPUpKjjBGcCciX |= AHPvaZCdHCyQBJkPUpKjjBGcCciX.LightbarSetupControl;
			DKLFkukhcVwOVKooLAWRPYIOfrIlA = false;
			P_0[38 + P_1] = (byte)aHPvaZCdHCyQBJkPUpKjjBGcCciX;
			P_0[41 + P_1] = snkTWRSIJTSncKDHlBATydjMwzxg;
			P_0[42 + P_1] = (byte)FGXAgAhMoCrxoSppQnUjeRwuDJcL;
			P_0[43 + P_1] = (byte)OkyrTKRQCyJagLCVirKYRNtdkqFh;
			if (NLdtjAmvnyhMoSLEwfReJGeucYEGA)
			{
				P_0[43 + P_1] = (byte)(P_0[43 + P_1] & -33);
			}
			else
			{
				P_0[43 + P_1] |= 32;
			}
			P_0[44 + P_1] = lights[0].bEzAGzsHHfekaYwhxhcDonjBuqcg;
			P_0[45 + P_1] = lights[0].hZXJuNriHzKJCDxVdGLgjNrguVQp;
			P_0[46 + P_1] = lights[0].BwttozAvbTHzdAzaYaOeFdxCDjiY;
			SHDpbKgHKEcHxaPaFXBNlxMCfgAh(ref kVvkSeRckXyHxkiFVkJoyCmsGRTw[1], P_0, 10 + P_1);
			SHDpbKgHKEcHxaPaFXBNlxMCfgAh(ref kVvkSeRckXyHxkiFVkJoyCmsGRTw[0], P_0, 21 + P_1);
			P_0[36 + P_1] = 0;
		}

		private void SHDpbKgHKEcHxaPaFXBNlxMCfgAh(ref IDualSenseTriggerEffect P_0, NativeBuffer P_1, int P_2)
		{
			if (P_0 == null)
			{
				P_1[P_2] = 0;
				return;
			}
			switch (P_0.triggerEffectType)
			{
			case DualSenseTriggerEffectType.Off:
				YPprZfeslPExlCXjBQKuKsuVpyLQ.ScDdYllCJCAhKxibBmrZXldgGELEA.WAkiPIhngiNoRggFkGCHPaAZRZfab(rYmlJjKmavRTnXWXyZmKbjWXBZsN, 0);
				break;
			case DualSenseTriggerEffectType.Feedback:
			{
				DualSenseTriggerEffectFeedback dualSenseTriggerEffectFeedback = (DualSenseTriggerEffectFeedback)(object)P_0;
				YPprZfeslPExlCXjBQKuKsuVpyLQ.ScDdYllCJCAhKxibBmrZXldgGELEA.kaqSeWtDQvfYreHtcpwTBFPizYkB(rYmlJjKmavRTnXWXyZmKbjWXBZsN, 0, dualSenseTriggerEffectFeedback.position, dualSenseTriggerEffectFeedback.strength);
				break;
			}
			case DualSenseTriggerEffectType.Weapon:
			{
				DualSenseTriggerEffectWeapon dualSenseTriggerEffectWeapon = (DualSenseTriggerEffectWeapon)(object)P_0;
				YPprZfeslPExlCXjBQKuKsuVpyLQ.ScDdYllCJCAhKxibBmrZXldgGELEA.yDDDDbXKNWwpbpPKANEapGGDvcFb(rYmlJjKmavRTnXWXyZmKbjWXBZsN, 0, dualSenseTriggerEffectWeapon.startPosition, dualSenseTriggerEffectWeapon.endPosition, dualSenseTriggerEffectWeapon.strength);
				break;
			}
			case DualSenseTriggerEffectType.Vibration:
			{
				DualSenseTriggerEffectVibration dualSenseTriggerEffectVibration = (DualSenseTriggerEffectVibration)(object)P_0;
				YPprZfeslPExlCXjBQKuKsuVpyLQ.ScDdYllCJCAhKxibBmrZXldgGELEA.MhsuwuZcoYABaOJDEaXIfuQlXYIQ(rYmlJjKmavRTnXWXyZmKbjWXBZsN, 0, dualSenseTriggerEffectVibration.position, dualSenseTriggerEffectVibration.amplitude, dualSenseTriggerEffectVibration.frequency);
				break;
			}
			case DualSenseTriggerEffectType.MultiplePositionFeedback:
				((DualSenseTriggerEffectMultiplePositionFeedback)(object)P_0).strength.CopyTo(FuKVOBLfxlTfzHNTMmDYkbCnpUJF);
				YPprZfeslPExlCXjBQKuKsuVpyLQ.ScDdYllCJCAhKxibBmrZXldgGELEA.qEPrVdAwhntBQJpMLDJSJdmwPEvfA(rYmlJjKmavRTnXWXyZmKbjWXBZsN, 0, FuKVOBLfxlTfzHNTMmDYkbCnpUJF);
				break;
			case DualSenseTriggerEffectType.SlopeFeedback:
			{
				DualSenseTriggerEffectSlopeFeedback dualSenseTriggerEffectSlopeFeedback = (DualSenseTriggerEffectSlopeFeedback)(object)P_0;
				YPprZfeslPExlCXjBQKuKsuVpyLQ.ScDdYllCJCAhKxibBmrZXldgGELEA.qcfAfjCAJEWWxrRClNnCeTmbDDKGA(rYmlJjKmavRTnXWXyZmKbjWXBZsN, 0, dualSenseTriggerEffectSlopeFeedback.startPosition, dualSenseTriggerEffectSlopeFeedback.endPosition, dualSenseTriggerEffectSlopeFeedback.startStrength, dualSenseTriggerEffectSlopeFeedback.endStrength);
				break;
			}
			case DualSenseTriggerEffectType.MultiplePositionVibration:
			{
				DualSenseTriggerEffectMultiplePositionVibration dualSenseTriggerEffectMultiplePositionVibration = (DualSenseTriggerEffectMultiplePositionVibration)(object)P_0;
				dualSenseTriggerEffectMultiplePositionVibration.amplitude.CopyTo(FuKVOBLfxlTfzHNTMmDYkbCnpUJF);
				YPprZfeslPExlCXjBQKuKsuVpyLQ.ScDdYllCJCAhKxibBmrZXldgGELEA.YhiBhfaBQAZHayYNPlaqVkzNfPeE(rYmlJjKmavRTnXWXyZmKbjWXBZsN, 0, dualSenseTriggerEffectMultiplePositionVibration.frequency, FuKVOBLfxlTfzHNTMmDYkbCnpUJF);
				break;
			}
			default:
				Logger.LogWarning("Unknown trigger effect type: 0x" + ((byte)P_0.triggerEffectType).ToString("x2"));
				return;
			}
			P_1.Write(rYmlJjKmavRTnXWXyZmKbjWXBZsN, rYmlJjKmavRTnXWXyZmKbjWXBZsN.Length, P_2);
		}

		private bool LpQxpBPiURqommovdYSyORuPAsET(PaswCStrAkmQpcZYWcZPEJHLfUmk P_0)
		{
			fYWzYbeEAntlbiHyKfFjMoymBVBaA = ReInput.realTime + 4.0;
			switch (P_0)
			{
			case PaswCStrAkmQpcZYWcZPEJHLfUmk.Synchronous:
				return HCzjlNzxoLaYKBoZDcSCwGkJMHwd.WriteSync(piWcAhFnVjNKQEgInbWBLvHoFBhVA, 0);
			case PaswCStrAkmQpcZYWcZPEJHLfUmk.Asynchronous:
				HCzjlNzxoLaYKBoZDcSCwGkJMHwd.WriteAsync(piWcAhFnVjNKQEgInbWBLvHoFBhVA, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void iNGCxmwfGrdUepXTEAJdDagrpCzBA(NativeBuffer P_0, double P_1)
		{
			byte b = P_0[SxlzTciKBbzraWIFTUhRmEEHWNcP];
			buttons[0].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 0x10) != 0, P_1);
			buttons[1].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 0x20) != 0, P_1);
			buttons[2].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 0x40) != 0, P_1);
			buttons[3].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 0x80) != 0, P_1);
			b = P_0[XdZhfuDozPMYMKJblFKkwkfbNOCe];
			buttons[4].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 1) != 0, P_1);
			buttons[5].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 2) != 0, P_1);
			buttons[6].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 4) != 0, P_1);
			buttons[7].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 8) != 0, P_1);
			buttons[8].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 0x10) != 0, P_1);
			buttons[9].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 0x20) != 0, P_1);
			buttons[10].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 0x40) != 0, P_1);
			buttons[11].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 0x80) != 0, P_1);
			b = P_0[gvZRwiuqkQhsOrRQEEIPzjfWNUVD];
			buttons[12].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 1) != 0, P_1);
			buttons[13].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 2) != 0, P_1);
			if (caEdEHcdLWnhFiCKkcQFlidIbiBTB)
			{
				buttons[14].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 4) != 0, P_1);
			}
		}

		private void PzIEUnPFHKyjNdssfoAvBjHDlnWr(VJJORtyhxtIZFDAvjUdtXgBUbPYD[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].kIKDSuiibFIJviyHCLnqsKOSMCInA(P_1, P_2);
			}
		}

		private void mQXuFMfFQVjNFdZGpTOPVrfvEhMk()
		{
			if (isVibrating && ReInput.realTime >= fYWzYbeEAntlbiHyKfFjMoymBVBaA)
			{
				IXCSBWaZseeZaCWujIUiTRZRfVYl();
				EtTurOMtwezTzCpaWCmPbAkgEffx = true;
			}
		}

		private void UyuIrBGQzYhyTdXTPCShdDfgzwsB(NativeBuffer P_0)
		{
			if (caEdEHcdLWnhFiCKkcQFlidIbiBTB)
			{
				uint num = bbZoWffYSwoAXQixxeZoBpCXeCnjA.ReadUInt(28 + gqisxEApmoernUmTGCaQCOdqbLPAA);
				float num3;
				if (num != zygOfFtVjaQvAPuJZAaBcTBXSuFG)
				{
					uint num2 = (uint)((num >= zygOfFtVjaQvAPuJZAaBcTBXSuFG) ? (num - zygOfFtVjaQvAPuJZAaBcTBXSuFG) : ((long)num + 4294967295L - zygOfFtVjaQvAPuJZAaBcTBXSuFG));
					num3 = (float)num2 / 3000000f;
				}
				else
				{
					uint num2 = 0u;
					num3 = 0f;
				}
				zygOfFtVjaQvAPuJZAaBcTBXSuFG = num;
				vxJhAkJDyzSGbIOSBNpmzcIvkfhi = num3;
			}
		}

		private void PptOqWLNsEumoAKMUZoYSgiFHGSS()
		{
			if (caEdEHcdLWnhFiCKkcQFlidIbiBTB && !(vxJhAkJDyzSGbIOSBNpmzcIvkfhi <= 0f))
			{
				Vector3 vector = gZjANlKLAvMViHKWxmivncALesyI(new Vector3(gyroscopes[0].FOFdTvxaVfzjKuXtYfOzBSpyuzjD[0], gyroscopes[0].FOFdTvxaVfzjKuXtYfOzBSpyuzjD[1], gyroscopes[0].FOFdTvxaVfzjKuXtYfOzBSpyuzjD[2]), vxJhAkJDyzSGbIOSBNpmzcIvkfhi);
				MRgJUJdoACtLBiKoIQrlOWiAaklA(ref vector);
				Vector3 vector2 = new Vector3(accelerometers[0].WuxcudBBVzHNVwoaaucXfPaFfSOU[0] * -1f, accelerometers[0].WuxcudBBVzHNVwoaaucXfPaFfSOU[1] * -1f, accelerometers[0].WuxcudBBVzHNVwoaaucXfPaFfSOU[2] * -1f);
				mDQUJoMouLdGpvauiFhLJRuwjViP(vector2, vector);
			}
		}

		private static bool MRgJUJdoACtLBiKoIQrlOWiAaklA(ref Vector3 P_0)
		{
			if (P_0.magnitude < 0.004f)
			{
				P_0.x = 0f;
				P_0.y = 0f;
				P_0.z = 0f;
				return false;
			}
			return true;
		}

		private void mDQUJoMouLdGpvauiFhLJRuwjViP(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && ecSvCGkMdCjxcIRbRyVLJivhDomh(P_0, out var bPrHhSOObwJuICMJYqAOfGedgTlR2))
			{
				Quaternion a = YhjcAcwqBbcrpekrJXcOxKthfIuo * quaternion;
				if (!dqTEQsTHpxPOFQHQefCHyInLWKoO)
				{
					dqTEQsTHpxPOFQHQefCHyInLWKoO = true;
					RvRCRxKoBniNBDpSodbjQtszAGHRA = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					fgIfdHInaCRkOJUYrwDKMCsmBHY = YhjcAcwqBbcrpekrJXcOxKthfIuo;
				}
				RvRCRxKoBniNBDpSodbjQtszAGHRA *= quaternion;
				fgIfdHInaCRkOJUYrwDKMCsmBHY *= quaternion;
				Quaternion b;
				if ((bPrHhSOObwJuICMJYqAOfGedgTlR2 & bPrHhSOObwJuICMJYqAOfGedgTlR.XZ) != bPrHhSOObwJuICMJYqAOfGedgTlR.None)
				{
					b = ujstPrVZWGlBGnSkahsZCuAOkjoN(P_0, a.eulerAngles.y);
				}
				else if ((bPrHhSOObwJuICMJYqAOfGedgTlR2 & bPrHhSOObwJuICMJYqAOfGedgTlR.Y) != bPrHhSOObwJuICMJYqAOfGedgTlR.None)
				{
					b = jobFUjejxQfEMgLeBrIJwOEEyBebB(P_0);
					Vector3 vector = fgIfdHInaCRkOJUYrwDKMCsmBHY * Vector3.right;
					float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					b = Quaternion.Euler(0f, y, 0f) * b;
				}
				else
				{
					b = Quaternion.identity;
				}
				YhjcAcwqBbcrpekrJXcOxKthfIuo = Quaternion.Lerp(a, b, 0.01999998f);
			}
			else
			{
				YhjcAcwqBbcrpekrJXcOxKthfIuo *= quaternion;
				if (dqTEQsTHpxPOFQHQefCHyInLWKoO)
				{
					dqTEQsTHpxPOFQHQefCHyInLWKoO = false;
				}
			}
		}

		private static Quaternion TTRxvzYkcfVuzfjtgAOJydCogfLP(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = gcynGFYloafbuCoBaoXiWrOxQuekA(new Vector3(P_0.x, P_0.y, P_0.z), P_1);
			return new Quaternion(vector.x, vector.y, vector.z, P_0.w);
		}

		private static Vector3 gcynGFYloafbuCoBaoXiWrOxQuekA(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion VNCfkDIvuymCARGvesumeXIKGrSS(Quaternion P_0, jvCCMRhQntIEpbMOcApIvfdKjRMdb P_1)
		{
			Vector4 vector = default(Vector4);
			if (MathTools.Approximately(P_0.w, 0f) && MathTools.Approximately(P_0[(int)P_1], 0f))
			{
				P_0 = Quaternion.identity;
			}
			else
			{
				float num = P_0[(int)P_1];
				float num2 = MathTools.Sqrt(P_0.w * P_0.w + num * num);
				vector[3] = P_0.w / num2;
				vector[(int)P_1] = num / num2;
				P_0 = new Quaternion(vector[0], vector[1], vector[2], vector[3]);
			}
			return P_0;
		}

		public static Quaternion Inverse(Quaternion quaternion)
		{
			float num = quaternion.x * quaternion.x + quaternion.y * quaternion.y + quaternion.z * quaternion.z + quaternion.w * quaternion.w;
			float num2 = 1f / num;
			Quaternion result = default(Quaternion);
			result.x = (0f - quaternion.x) * num2;
			result.y = (0f - quaternion.y) * num2;
			result.z = (0f - quaternion.z) * num2;
			result.w = quaternion.w * num2;
			return result;
		}

		private float WPoPDpTyoFCPhldjSVfpCalsTzHt(float P_0, float P_1)
		{
			P_0 = MathTools.ClampAngle360(P_0);
			P_1 = MathTools.ClampAngle360(P_1);
			if (P_0 == P_1)
			{
				return 0f;
			}
			if (P_0 >= 180f)
			{
				P_0 -= 360f;
			}
			if (P_1 >= 180f)
			{
				P_1 -= 360f;
			}
			return P_0 - P_1;
		}

		private Vector3 HfJILrFYJXHPaoapGFHFuJRAFxEEA(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return new Vector3(x, P_1, z);
		}

		private Quaternion ujstPrVZWGlBGnSkahsZCuAOkjoN(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return Quaternion.Euler(x, P_1, z);
		}

		private Quaternion jobFUjejxQfEMgLeBrIJwOEEyBebB(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float x = MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f));
			float num2 = MathTools.Atan2(P_0.x, x);
			float x2 = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			Quaternion quaternion = Quaternion.Euler(0f, 0f, z) * Quaternion.Euler(x2, 0f, 0f);
			if (P_1 != 0f)
			{
				return quaternion * Quaternion.Euler(0f, P_1, 0f);
			}
			return quaternion;
		}

		private float TFsXbfnEtgrLVPyvsyDsEIMeRtsb(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool GYymskjDohZDYuZDIHeEzSSjnkYl(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool ecSvCGkMdCjxcIRbRyVLJivhDomh(Vector3 P_0, out bPrHhSOObwJuICMJYqAOfGedgTlR P_1)
		{
			P_0.Normalize();
			P_1 = bPrHhSOObwJuICMJYqAOfGedgTlR.None;
			bool result = false;
			if (iNuUoSQPcZiXWCBEBoprqtYjyIiuA(P_0))
			{
				result = true;
				P_1 |= bPrHhSOObwJuICMJYqAOfGedgTlR.XZ;
			}
			if (kSLXyENEcqYSXgketbOxbhxhQWDY(P_0))
			{
				result = true;
				P_1 |= bPrHhSOObwJuICMJYqAOfGedgTlR.Y;
			}
			return result;
		}

		private bool iNuUoSQPcZiXWCBEBoprqtYjyIiuA(Vector3 P_0)
		{
			if (P_0.y > 0f)
			{
				return false;
			}
			if (Vector3.Angle(Vector3.down, P_0) > 45f)
			{
				return false;
			}
			return true;
		}

		private bool kSLXyENEcqYSXgketbOxbhxhQWDY(Vector3 P_0)
		{
			if (P_0.z < 0f)
			{
				return false;
			}
			if (Vector3.Angle(new Vector3(0f, 0f, 1f), P_0) > 20f)
			{
				return false;
			}
			return true;
		}

		private Vector3 qXTrtvDwYPbMHGyrkOolzhCLNRdA(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 PbulnhgpfGIraRbnpHktdNBRyCAiA(RingBuffer<jntvuWnVLbBPQuLLgPmMmaPxgSGi.xJZoNJvwOYuCkuguqxILWyKPVNLg> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				jntvuWnVLbBPQuLLgPmMmaPxgSGi.xJZoNJvwOYuCkuguqxILWyKPVNLg xJZoNJvwOYuCkuguqxILWyKPVNLg = P_0[i];
				result += gZjANlKLAvMViHKWxmivncALesyI(xJZoNJvwOYuCkuguqxILWyKPVNLg.DvHdJsiOpQCMusadeasERFNqfxYj, xJZoNJvwOYuCkuguqxILWyKPVNLg.xXpuLfPLSjTeMlQUaganZAUGZSHq);
			}
			return result;
		}

		private Vector3 gZjANlKLAvMViHKWxmivncALesyI(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.06103702f * P_1;
		}

		private int GskMKpIprxTIFBZvwKJvFuHcHsoI(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void zqoytiGGRYxFVqFXJzQgZJFBEcnc(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void fpjIasBPlUdijaZLSzatvOyVEdwAb(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private float fSXgcHkrcdpqikXarpSCsTdxnToDb()
		{
			return vxJhAkJDyzSGbIOSBNpmzcIvkfhi;
		}

		private void dUYmImwJxSvvVjerBppxapNzByMF(NativeBuffer P_0, NaCRucjlkvXgCSkUJCtQCAeoSdInA.TouchData[] P_1)
		{
			int num = 33 + gqisxEApmoernUmTGCaQCOdqbLPAA;
			int positionRawX = P_0[1 + num] + (P_0[2 + num] & 0xF) * 255;
			int positionRawY = ((P_0[2 + num] & 0xF0) >> 4) + P_0[3 + num] * 16;
			int positionRawX2 = P_0[5 + num] + (P_0[6 + num] & 0xF) * 255;
			int positionRawY2 = ((P_0[6 + num] & 0xF0) >> 4) + P_0[7 + num] * 16;
			byte b = P_0[num];
			bool flag = b < 128;
			byte num2 = P_0[num + 4];
			bool flag2 = num2 < 128;
			int num3 = b & 0x7F;
			int num4 = num2 & 0x7F;
			P_1[0].isTouching = flag;
			P_1[0].touchId = FdKkNkPlAycWaMeNRyWHOOgwpgjy(0, flag, num3);
			P_1[0].positionRawX = positionRawX;
			P_1[0].positionRawY = positionRawY;
			P_1[1].isTouching = flag2;
			P_1[1].touchId = FdKkNkPlAycWaMeNRyWHOOgwpgjy(1, flag2, num4);
			P_1[1].positionRawX = positionRawX2;
			P_1[1].positionRawY = positionRawY2;
		}

		private int FdKkNkPlAycWaMeNRyWHOOgwpgjy(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				EKUXdikBkPmfMkQshbLzEnEWgFSq[P_0] = -1;
				nfzvwqFOuzPcHwmCNUZIrGCpnMYx[P_0] = P_2;
				return -1;
			}
			if (P_2 != nfzvwqFOuzPcHwmCNUZIrGCpnMYx[P_0])
			{
				int num = ejRmjerPAQtTJOJhHdtIAGfLNQhf;
				if (ejRmjerPAQtTJOJhHdtIAGfLNQhf == int.MaxValue)
				{
					ejRmjerPAQtTJOJhHdtIAGfLNQhf = 0;
				}
				else
				{
					ejRmjerPAQtTJOJhHdtIAGfLNQhf++;
				}
				nfzvwqFOuzPcHwmCNUZIrGCpnMYx[P_0] = P_2;
				EKUXdikBkPmfMkQshbLzEnEWgFSq[P_0] = num;
				return num;
			}
			return EKUXdikBkPmfMkQshbLzEnEWgFSq[P_0];
		}

		private void lEbyvHFFCZfCnsrQkbrFvkIDBRPIA()
		{
			bxKFZuOiZnMblUsgDGpetcPQtcOt = true;
			IXCSBWaZseeZaCWujIUiTRZRfVYl();
		}

		private void HBxSXWGAyEljLSbnbhdlCXXcUgoqA()
		{
			bxKFZuOiZnMblUsgDGpetcPQtcOt = true;
			IXCSBWaZseeZaCWujIUiTRZRfVYl();
		}

		private void giZeAXjSkShmjGwEWmHrhgcTBzrBA()
		{
			EtTurOMtwezTzCpaWCmPbAkgEffx = true;
			IXCSBWaZseeZaCWujIUiTRZRfVYl();
		}

		private void IXCSBWaZseeZaCWujIUiTRZRfVYl()
		{
			FgXXevNeFHCAwKKUgIWGPvcwVHHD = true;
		}

		~DualSenseDriver()
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
				StopVibration();
				AvbXJkhinuNlNYrVyNffzCRUKvSS(PaswCStrAkmQpcZYWcZPEJHLfUmk.Synchronous);
				if (bbZoWffYSwoAXQixxeZoBpCXeCnjA != null)
				{
					bbZoWffYSwoAXQixxeZoBpCXeCnjA.Dispose();
				}
				if (mPrAjmkxguVnSOrwAJpbRiqYrnMNA != null)
				{
					mPrAjmkxguVnSOrwAJpbRiqYrnMNA.Dispose();
				}
			}
		}

		public static bool Matches(int vid, int pid)
		{
			for (int i = 0; i < Consts.pidVids_sony_dualSense.Count; i++)
			{
				if (Consts.pidVids_sony_dualSense[i].vendorId == vid && Consts.pidVids_sony_dualSense[i].productId == pid)
				{
					return true;
				}
			}
			return false;
		}

		private static uint SoybfAunbysWnPXduaOXOGBljsqm(NativeBuffer P_0, int P_1)
		{
			uint num = 3940166985u;
			for (int i = 0; i < P_1; i++)
			{
				num = pMPBQKFEnHezBzjxGraHltrIdYLQ[(byte)num ^ P_0[i]] ^ (num >> 8);
			}
			return num;
		}

		private static cpqWrtsPtNOnBBfVkOKYxZBtrxBm sqCAnTSXKZSWYStsAirZatjIAtrL(DualSenseOtherLightBrightness P_0)
		{
			return P_0 switch
			{
				DualSenseOtherLightBrightness.High => cpqWrtsPtNOnBBfVkOKYxZBtrxBm.High, 
				DualSenseOtherLightBrightness.Medium => cpqWrtsPtNOnBBfVkOKYxZBtrxBm.Medium, 
				DualSenseOtherLightBrightness.Low => cpqWrtsPtNOnBBfVkOKYxZBtrxBm.Low, 
				_ => throw new NotImplementedException(), 
			};
		}

		private static DualSenseOtherLightBrightness ZMydlyAwUlSnblTDuUopsaQYmWgc(cpqWrtsPtNOnBBfVkOKYxZBtrxBm P_0)
		{
			return P_0 switch
			{
				cpqWrtsPtNOnBBfVkOKYxZBtrxBm.High => DualSenseOtherLightBrightness.High, 
				cpqWrtsPtNOnBBfVkOKYxZBtrxBm.Medium => DualSenseOtherLightBrightness.Medium, 
				cpqWrtsPtNOnBBfVkOKYxZBtrxBm.Low => DualSenseOtherLightBrightness.Low, 
				_ => throw new NotImplementedException(), 
			};
		}

		private static FVIxTwIDPRsHLerOoPYjVLgTfrWk EzsqtOvnhafeYwIZfoBIhvBvpJiT(DualSenseTriggerType P_0, byte P_1)
		{
			byte b;
			switch (P_0)
			{
			case DualSenseTriggerType.Left:
				b = new jDDXOetxueLeUSOjoFIvMmnHGcFDA(P_1).XTggCgJQMcuSlWatCBrPHmPazPgWA;
				break;
			case DualSenseTriggerType.Right:
				b = new jDDXOetxueLeUSOjoFIvMmnHGcFDA(P_1).lvBhscymuoRhzWlIMNAkTfoMrhSX;
				break;
			default:
				return FVIxTwIDPRsHLerOoPYjVLgTfrWk.Off;
			}
			return b switch
			{
				0 => FVIxTwIDPRsHLerOoPYjVLgTfrWk.Off, 
				1 => FVIxTwIDPRsHLerOoPYjVLgTfrWk.Feedback, 
				2 => FVIxTwIDPRsHLerOoPYjVLgTfrWk.Weapon, 
				3 => FVIxTwIDPRsHLerOoPYjVLgTfrWk.Vibration, 
				4 => FVIxTwIDPRsHLerOoPYjVLgTfrWk.SlopeFeedback, 
				_ => FVIxTwIDPRsHLerOoPYjVLgTfrWk.Off, 
			};
		}

		private static DualSenseTriggerEffectState tCijcsMdVgscWOxjxNGISBTcpLaX(DualSenseTriggerType P_0, byte P_1, byte P_2)
		{
			byte b = new jDDXOetxueLeUSOjoFIvMmnHGcFDA(P_1).XTggCgJQMcuSlWatCBrPHmPazPgWA;
			return EzsqtOvnhafeYwIZfoBIhvBvpJiT(P_0, P_2) switch
			{
				FVIxTwIDPRsHLerOoPYjVLgTfrWk.Off => DualSenseTriggerEffectState.Off, 
				FVIxTwIDPRsHLerOoPYjVLgTfrWk.Feedback => b switch
				{
					0 => DualSenseTriggerEffectState.FeedbackIdle, 
					1 => DualSenseTriggerEffectState.FeedbackApplyingForce, 
					_ => DualSenseTriggerEffectState.FeedbackIdle, 
				}, 
				FVIxTwIDPRsHLerOoPYjVLgTfrWk.Weapon => b switch
				{
					0 => DualSenseTriggerEffectState.WeaponIdle, 
					1 => DualSenseTriggerEffectState.WeaponFiring, 
					2 => DualSenseTriggerEffectState.WeaponFired, 
					_ => DualSenseTriggerEffectState.WeaponIdle, 
				}, 
				FVIxTwIDPRsHLerOoPYjVLgTfrWk.Vibration => b switch
				{
					0 => DualSenseTriggerEffectState.VibrationIdle, 
					1 => DualSenseTriggerEffectState.VibrationVibrating, 
					_ => DualSenseTriggerEffectState.VibrationIdle, 
				}, 
				FVIxTwIDPRsHLerOoPYjVLgTfrWk.SlopeFeedback => b switch
				{
					0 => (DualSenseTriggerEffectState)8, 
					1 => (DualSenseTriggerEffectState)9, 
					2 => (DualSenseTriggerEffectState)10, 
					_ => (DualSenseTriggerEffectState)8, 
				}, 
				_ => DualSenseTriggerEffectState.Off, 
			};
		}

		[Conditional("DEBUG_THIS")]
		protected static void DLog(object msg)
		{
			if (msg != null)
			{
				Logger.Log("DualSenseDriver: " + msg);
			}
		}
	}
}
