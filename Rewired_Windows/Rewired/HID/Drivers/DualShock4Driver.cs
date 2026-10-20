using System;
using System.Diagnostics;
using Rewired.ControllerExtensions;
using Rewired.ControllerExtensions.Internal;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualShock4Driver : HIDDeviceDriver, IDriver_DualShock4, IDualShock4ExtensionSource, IDualShock4DualSenseCommonExtensionSource, IControllerDriver, IHIDControllerExtension, IDisposable
	{
		private enum rjxSdBxkRLfLWqojqSJITshEpkGi
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum niWbanHLbQcITmYfYjTqBSOyEDDlA
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		private static class lkucmGgqPEPpwZuIiejyUcfVtfSZ
		{
			private const uint boidsvwSwNxNIbLmwoHucZcXhdtb = 3988292384u;

			public unsafe static uint vobqMaUGgpxvMaucSVUUEDbWPdfN(byte* P_0, int P_1, uint P_2)
			{
				return ~XCFjYxWVJqHknfOWlmZCYQeFLXhQ(XCFjYxWVJqHknfOWlmZCYQeFLXhQ(uint.MaxValue, (byte*)(&P_2), 1, 3988292384u), P_0, P_1, 3988292384u);
			}

			public unsafe static uint tOVYSceoDBalvKKfQuFiqmnIwnGQ(uint P_0, byte* P_1, int P_2)
			{
				return XCFjYxWVJqHknfOWlmZCYQeFLXhQ(P_0, P_1, P_2, 3988292384u);
			}

			private unsafe static uint XCFjYxWVJqHknfOWlmZCYQeFLXhQ(uint P_0, byte* P_1, int P_2, uint P_3)
			{
				for (int i = 0; i < P_2; i++)
				{
					P_0 ^= P_1[i];
					for (int j = 0; j < 8; j++)
					{
						P_0 = (P_0 >> 1) ^ (((P_0 & 1) != 0) ? P_3 : 0);
					}
				}
				return P_0;
			}
		}

		private enum VYDnkgwpyFVKerBadBaAAUlJXuSEA
		{
			Discharging = 0,
			Charging = 1,
			Full = 2,
			Unknown = 3
		}

		private const float juqtgzUObOjrkJMppBDtBPMSdvZ = 4f;

		private const int xoDCJcidyfEauqzSWHePdVLvSbqW = 14;

		private const int uppsJNPhxGgqMCSCaUWgIsjQFoQV = 2;

		private const int RCreLaEcRgCqnxcQtHjsxyCTmewKA = 0;

		private const int SOJgKStclvUJGoAGYOCrlUCdeZg = 1912;

		private const int tjiEeINDOcyKLCKcpHXdDLnnrUnX = 0;

		private const int oAGrYyCsUnUtjxcVUczGqikGdgKj = 941;

		private const bool ZcpbIhdVhxchbOisOXJLvimVoHTBA = false;

		private const bool bLPBvqGNDMOVqFBeFftOCFRAIzIZA = true;

		private const float PorlUGBlSYuECuMOxecWahJlsoSNA = 2.5f;

		private const int ehzejGLUTxWNIMehaNLdumsGmVKG = 0;

		private const int rQKegFlfLcbZGcKsluCITKXegepg = 0;

		private const int RNCylRFanUCHUqklmYlWzLHBgsx = 1;

		private const int lfGJroTHdZWQKYCpDkunUFTeMnJM = 0;

		private const int DJTnfBDJMMEKVnodImSZwpVuKsVv = 0;

		private const int YJcaApIiBiZsyDKUEQbGPVbgZSUI = 0;

		private const int YGvFOrHOqHZJwuYJDWOFnzyciSWeA = 1;

		private const int HeeFECCyPHcCgPOyKIOhGwKepoVAc = 17;

		private const int ZezcOUHzDpvDAUtgkhqgtQBTnqWOA = 0;

		private const int sBfhZVcWGbkgWwaqYLokCgsSdajVA = 2;

		private const int VSufziuREOALlHcZWnSdKiDUdcJn = 64;

		private const int iTvtjUYKEZItMebDTSQKBOxNxalzA = 78;

		private const byte OSyERPAtmafvCtfaYYwsKsBjtNGNA = 17;

		private const byte obmJGZpqWvhrFqXPOuBKwricgMwF = 5;

		private const byte WlKYnGCyqFfBgVdABdoYUhXkJAdQ = 2;

		private const byte NeiHwOgrXkPiWwcuZQlXVjbdEsxK = 37;

		private const byte fvQfjwolYLlDbpIcoaFsKUlDpXMgA = 5;

		private const byte cmhXDDCjfDGtCkCeiABiSeGBCSXcA = 41;

		private const byte CCgAsPvoLamkbfhXATXdOHYGkRQm = 163;

		private const byte PgMRmZHLfnhoOdejHyMuZIcnGnUO = 49;

		private const byte iughFGfpidLAdLEMyyJzFewviCQV = 18;

		private const byte RfTdSHpXYPLlSPsheReHxglqEHHJ = 16;

		private const byte knAszaDAfEasZpsXFcJMpIsdzRgg = 161;

		private const byte EsFoORnonmOPDZMAcxBbRHqDiktj = 162;

		private const byte zsYMErLeuBBKNoxOxqOqgOngXBmt = 163;

		private const int yfNSMtctWbnFNyxdqoPkLkMoSjbw = 1;

		private const int baQiWbOduxAZERgxhpScidwojiQs = 2;

		private const int cOfQkxOdTeVNqLSLbiAaaEKKFFdDA = 3;

		private const int HFVCMEeXwTqSlFipvIVbbupIGGic = 4;

		private const int pbETzmvEXeafgQlVYddDHNpJClXAb = 8;

		private const int TPnmrVYRlBLPjCGbuhzfAtjLphSiA = 9;

		private const int RIEEOdlLgRXHtOibMjtmBVGUVNErA = 5;

		private const int HHwUdXObfHEHkabwvYlgIFXSJWEPA = 19;

		private const int KoOdgyhaaFRVPwugxNNiglwklE = 13;

		private const int iidcyzADHIesXYlEIOQjZAJUhsmE = 35;

		private const int LIqWCczCqsCxSlXgwKAiXlqbKKjO = 5;

		private const int vEmMcuiPeExqncGUzfbfkrPMkjgS = 6;

		private const int kdJOkejvKxeRRbOyfcsSksJnHFkZA = 7;

		private const int mHobjjKUXYXFtkkWgZHqfilDBOWS = 10;

		private const int iOJNGWqYcHOjpALXvOFrFIYNjcWu = 30;

		private const int jVAXXueEEtTBEqGPIHyWARjRKtwT = 27;

		private const byte jLlLVZVBKOHzBxTnMDPIsSpFoxnA = 200;

		private const byte gqCFPkuYFMVviPEksjExDySJuezhA = 53;

		private const byte jVcjaFXLSpiYTZbneZCLuqibJnjd = byte.MaxValue;

		private const byte xGRJLgvPqgrSorCzdyfeuvdTVSEo = 0;

		private const int bqEmJOxLtaSVafnDXwzDnZZESGln = 60;

		private const int nbBegXBGwIMlIcOQswFaCfueCKLZ = 60;

		private const int TirhYfmjrtnwAFvxRljBvCimtwZK = 187500;

		private const float ExtEhNydwPgXxkInDrYYUbhdaaXr = 8192f;

		private const float jnMxMpScpBUJNocRTCPdzwvZeNBY = 0.0010652969f;

		private const float UxPsjAWhiaECKbtsjArXAcmLcJyU = 0.06103702f;

		private const float jLQkhkRZyKLUpDXqJQaBkPPmGkREA = 4096f;

		private const float GgHVLFXZmFhkDvbFqFmABkUhUbIqA = 16384f;

		private const float zblRBgwtiIWNOauRRNGsKzWaptpB = 16777216f;

		private const float xwqRTBGgDRgISrMMHKwQMBQbMdTA = 268435460f;

		private const float MPYBKeeKnZzbbXuUQeHacXGCsVUw = 0.01999998f;

		private const float cFhNbeoObltLyLJYiZWhuOVrIVyj = 8192f;

		private const float CGIZAXlmVvFuhmIuPBbMtiYLyLyS = 0.98f;

		private const float GZFLUdkFBMVgGquRRpPqfEIomOtj = 45f;

		private const float TpAPzoBJhvEoZRFkWBsvcCCPpFHi = 20f;

		private readonly IHIDDevice qyWazeVNFACMUWpGTreEaLxEoFOb;

		private readonly HIDProperties OsjWhFbheOIlXvMdmjyBBCGBXAhHA;

		private readonly bool nTnnpwneIEiRpCLjEYrHBlKFweBwA;

		private readonly OzbKZwmCsAMtNgCdYlCwZEMUUFwG AXyjxcvirVTpwlnxRedtPBFdbXJx;

		private readonly int DcJUJFkrqcCMKskRvurbNuqImaTQ;

		private readonly int uQMGlkESjbJMNkrEfANOvmBooQgv;

		private bool EcsRyBeyimSceFrAxGTxZjdmdSlGA;

		private byte erHFbYqWsffXPOwUfaOXCRkknvxxA;

		private int bSLpbdOKlkWkZlNKWAAghalOwmle;

		private int NnOmPtQCZhVCcKHxWEXxchmSqTJbA;

		private int kXCGrjQpMuzHPDBxYYjuoPlzlAnh;

		private int KuJvinLQmuiNJXKvrEalBwjwPYqb;

		private readonly NativeBuffer YdrqCFbpCNIgNdKctjWwBjECBXAlc;

		private readonly NativeBuffer mIYNdtRPAIXzVoojRSvvSoKGHNTQ;

		private svXcjurRenDjMJrGFPPkrmozhhdx vPxOasXnuccyLAWJhEFqBsmaFsgFA;

		private readonly byte[] VsjgvaxXoFIrmIIZchYNQSXdDlYV = new byte[1] { 162 };

		private bool pRrLBPohnRoyJZUTsbTsBbbCkSk;

		private bool dJUBuGJotfzpsNtcMOqDIILMsPDM;

		private double hOcqOdteLYwOdaLWrOQYpeFPifBm;

		private int JSrCYVOLCUdKntDytjJTLighFhNeA;

		private VYDnkgwpyFVKerBadBaAAUlJXuSEA hTSldXDhUmSpbcexzjvjxjmiKOPR = VYDnkgwpyFVKerBadBaAAUlJXuSEA.Unknown;

		private Quaternion XmfCjHptiKwRkzSDmBPOhNDhVUwn = Quaternion.identity;

		private ushort bmIFvcwvAgjZFqQjvqaYUbeqsRHI;

		private float HEjqhuUjbtMHbJteqRnsbGIyQKGS;

		private double bPgnrAdfRFUYGZkvfasdEykXuDSJ;

		private float ifJJeCoUDivlbOTyvHLrTLFGzWoE;

		private bool ImBWMuxCpPsRsApayyBJTkfcnHuk;

		private bool ruaXeLshkHXITbZSAcutMNCoFSto;

		private bool pGYWENUFUWVeOwergGjjUSQAUuUS;

		private bool ewsdXqJfQTqFSMXpvudcmseIcQkE;

		private byte grLiLjpvQQtSgUQYqbdqcStUAgOP;

		private byte QTzGBsRtVpWysyubbAcHkiPspQkT;

		private Quaternion ogiOPCjXAMncvzFHzVruCoVZhduo = Quaternion.identity;

		private Quaternion yBqrJbsiEXBwWCHqIOYhPDeEPSrq = Quaternion.identity;

		private bool RzJkUWNwhPDpMjoXDFdWbpeyXPeS;

		private int xdeiJKWbvmNqhGmSCgiyMeJjkHmb;

		private int[] UvVuSUVMdVyyLEQIGrZIGoNxEOyw = new int[2];

		private int[] NmdzWFAbDefJiESpgZZyumFsmacj = new int[2];

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

		float IDualShock4DualSenseCommonExtensionSource.batteryLevel => JSrCYVOLCUdKntDytjJTLighFhNeA;

		bool IDualShock4DualSenseCommonExtensionSource.batteryCharging => hTSldXDhUmSpbcexzjvjxjmiKOPR == VYDnkgwpyFVKerBadBaAAUlJXuSEA.Charging;

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
				return (int)grLiLjpvQQtSgUQYqbdqcStUAgOP;
			}
			set
			{
				grLiLjpvQQtSgUQYqbdqcStUAgOP = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				hWnjCmhmfirSRyvDouAqiANfoDEU();
				if (grLiLjpvQQtSgUQYqbdqcStUAgOP == 0 && QTzGBsRtVpWysyubbAcHkiPspQkT == 0)
				{
					dJUBuGJotfzpsNtcMOqDIILMsPDM = true;
				}
			}
		}

		float IDualShock4DualSenseCommonExtensionSource.lightFlashOffDuration
		{
			get
			{
				return (int)QTzGBsRtVpWysyubbAcHkiPspQkT;
			}
			set
			{
				QTzGBsRtVpWysyubbAcHkiPspQkT = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				hWnjCmhmfirSRyvDouAqiANfoDEU();
				if (grLiLjpvQQtSgUQYqbdqcStUAgOP == 0 && QTzGBsRtVpWysyubbAcHkiPspQkT == 0)
				{
					dJUBuGJotfzpsNtcMOqDIILMsPDM = true;
				}
			}
		}

		Vector3 IDualShock4DualSenseCommonExtensionSource.accelerometerValue => UfsGrJbjAHQInFbgFbCRnEXnWfPM(accelerometers[0].WuxcudBBVzHNVwoaaucXfPaFfSOU);

		Vector3 IDualShock4DualSenseCommonExtensionSource.accelerometerValueRaw => new Vector3(accelerometers[0].WuxcudBBVzHNVwoaaucXfPaFfSOU[0], accelerometers[0].WuxcudBBVzHNVwoaaucXfPaFfSOU[1], accelerometers[0].WuxcudBBVzHNVwoaaucXfPaFfSOU[2]);

		Vector3 IDualShock4DualSenseCommonExtensionSource.gyroscopeValue => EzUeGYBAIckUelIvfnzReaaPyIDAA(gyroscopes[0].eTrgYsFlPQxbSPEyqbAXOGmMXzVD);

		Vector3 IDualShock4DualSenseCommonExtensionSource.gyroscopeValueRaw => new Vector3(gyroscopes[0].YZhnygGArvWYHTgbFoiNYQuaNTyS[0], gyroscopes[0].YZhnygGArvWYHTgbFoiNYQuaNTyS[1], gyroscopes[0].YZhnygGArvWYHTgbFoiNYQuaNTyS[2]);

		Vector3 IDualShock4DualSenseCommonExtensionSource.lastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].FOFdTvxaVfzjKuXtYfOzBSpyuzjD[0], gyroscopes[0].FOFdTvxaVfzjKuXtYfOzBSpyuzjD[1], gyroscopes[0].FOFdTvxaVfzjKuXtYfOzBSpyuzjD[2]);
				return laWHmZcGqNmEPWGTTNyFdeGQwOMX(vector, HEjqhuUjbtMHbJteqRnsbGIyQKGS);
			}
		}

		Vector3 IDualShock4DualSenseCommonExtensionSource.lastGyroscopeValueRaw => new Vector3(gyroscopes[0].FOFdTvxaVfzjKuXtYfOzBSpyuzjD[0], gyroscopes[0].FOFdTvxaVfzjKuXtYfOzBSpyuzjD[1], gyroscopes[0].FOFdTvxaVfzjKuXtYfOzBSpyuzjD[2]);

		Quaternion IDualShock4DualSenseCommonExtensionSource.orientation => XmfCjHptiKwRkzSDmBPOhNDhVUwn;

		int IDualShock4DualSenseCommonExtensionSource.maxTouches => 2;

		ushort IHIDControllerExtension.vendorId => OsjWhFbheOIlXvMdmjyBBCGBXAhHA.vendorId;

		ushort IHIDControllerExtension.productId => OsjWhFbheOIlXvMdmjyBBCGBXAhHA.productId;

		string IHIDControllerExtension.productName => OsjWhFbheOIlXvMdmjyBBCGBXAhHA.productName;

		string IHIDControllerExtension.manufacturer => OsjWhFbheOIlXvMdmjyBBCGBXAhHA.manufacturer;

		ushort IHIDControllerExtension.usagePage => OsjWhFbheOIlXvMdmjyBBCGBXAhHA.usagePage;

		ushort IHIDControllerExtension.usage => OsjWhFbheOIlXvMdmjyBBCGBXAhHA.usage;

		public void ResetOrientation()
		{
			XmfCjHptiKwRkzSDmBPOhNDhVUwn = Quaternion.identity;
			RzJkUWNwhPDpMjoXDFdWbpeyXPeS = false;
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
			grLiLjpvQQtSgUQYqbdqcStUAgOP = 0;
			QTzGBsRtVpWysyubbAcHkiPspQkT = 0;
			pRrLBPohnRoyJZUTsbTsBbbCkSk = true;
			dJUBuGJotfzpsNtcMOqDIILMsPDM = true;
			pGYWENUFUWVeOwergGjjUSQAUuUS = true;
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

		public DualShock4Driver(InitArgs P_0)
			: base(P_0)
		{
			qyWazeVNFACMUWpGTreEaLxEoFOb = P_0.hidDevice;
			OsjWhFbheOIlXvMdmjyBBCGBXAhHA = qyWazeVNFACMUWpGTreEaLxEoFOb.properties;
			DcJUJFkrqcCMKskRvurbNuqImaTQ = P_0.hatZeroValue;
			uQMGlkESjbJMNkrEfANOvmBooQgv = P_0.hatSpan;
			AXyjxcvirVTpwlnxRedtPBFdbXJx = P_0.connectionType;
			nTnnpwneIEiRpCLjEYrHBlKFweBwA = AXyjxcvirVTpwlnxRedtPBFdbXJx == OzbKZwmCsAMtNgCdYlCwZEMUUFwG.Bluetooth;
			if (nTnnpwneIEiRpCLjEYrHBlKFweBwA)
			{
				OsjWhFbheOIlXvMdmjyBBCGBXAhHA.maxOutputReportLength = 78;
			}
			if (OsjWhFbheOIlXvMdmjyBBCGBXAhHA.maxOutputReportLength < 23)
			{
				OsjWhFbheOIlXvMdmjyBBCGBXAhHA.maxOutputReportLength = 23;
			}
			YdrqCFbpCNIgNdKctjWwBjECBXAlc = new NativeBuffer(64);
			mIYNdtRPAIXzVoojRSvvSoKGHNTQ = new NativeBuffer(OsjWhFbheOIlXvMdmjyBBCGBXAhHA.maxOutputReportLength);
			vPxOasXnuccyLAWJhEFqBsmaFsgFA = new svXcjurRenDjMJrGFPPkrmozhhdx(mIYNdtRPAIXzVoojRSvvSoKGHNTQ.Pointer, mIYNdtRPAIXzVoojRSvvSoKGHNTQ.Length, OsjWhFbheOIlXvMdmjyBBCGBXAhHA.maxOutputReportLength);
			lights = new nmpBQAovYKAFTjYpVLxEGKXmVudz[1]
			{
				new nmpBQAovYKAFTjYpVLxEGKXmVudz(11, 24, 28)
			};
			lights[0].MLtUdFrKUcdYvCKPAcoFdFnKMjWRA += dLvgPYaNisYCciPkXCezhEuALVf;
			ruaXeLshkHXITbZSAcutMNCoFSto = true;
			vibrationMotors = new uctGEmIAndGsnBPlyPlnhlfoOqoG[2]
			{
				new uctGEmIAndGsnBPlyPlnhlfoOqoG(0, 255),
				new uctGEmIAndGsnBPlyPlnhlfoOqoG(0, 255)
			};
			vibrationMotors[0].FxFPDwUFaZlttspQRrgthdlYGjxL += gTKFsiXGpRntbvdcEbkelaQBrzZG;
			vibrationMotors[1].FxFPDwUFaZlttspQRrgthdlYGjxL += gTKFsiXGpRntbvdcEbkelaQBrzZG;
		}

		protected override void OnInitialize()
		{
			if (qyWazeVNFACMUWpGTreEaLxEoFOb.GetHidFeatureData(2, 37, 1000, 3) == null)
			{
				throw new Exception();
			}
			ewsdXqJfQTqFSMXpvudcmseIcQkE = true;
			if (nTnnpwneIEiRpCLjEYrHBlKFweBwA)
			{
				EcsRyBeyimSceFrAxGTxZjdmdSlGA = true;
				vPxOasXnuccyLAWJhEFqBsmaFsgFA.troAmoGhctcOyAOTedaJVtjAjwrMc |= eKiggKxGFedvgdyyrDINBkJifCvqB.WriteDirect;
				EcsRyBeyimSceFrAxGTxZjdmdSlGA = UVmTPIbXtmgTrgpZRaVhdmaFdWzVA(PaswCStrAkmQpcZYWcZPEJHLfUmk.Synchronous);
				if (!EcsRyBeyimSceFrAxGTxZjdmdSlGA)
				{
					vPxOasXnuccyLAWJhEFqBsmaFsgFA.troAmoGhctcOyAOTedaJVtjAjwrMc &= ~eKiggKxGFedvgdyyrDINBkJifCvqB.WriteDirect;
				}
			}
			else
			{
				EcsRyBeyimSceFrAxGTxZjdmdSlGA = UVmTPIbXtmgTrgpZRaVhdmaFdWzVA(PaswCStrAkmQpcZYWcZPEJHLfUmk.Synchronous);
			}
			if (!EcsRyBeyimSceFrAxGTxZjdmdSlGA)
			{
				throw new Exception();
			}
			erHFbYqWsffXPOwUfaOXCRkknvxxA = 1;
			bSLpbdOKlkWkZlNKWAAghalOwmle = 0;
			if (nTnnpwneIEiRpCLjEYrHBlKFweBwA && EcsRyBeyimSceFrAxGTxZjdmdSlGA)
			{
				erHFbYqWsffXPOwUfaOXCRkknvxxA = 17;
				bSLpbdOKlkWkZlNKWAAghalOwmle = 2;
			}
			NnOmPtQCZhVCcKHxWEXxchmSqTJbA = 5 + bSLpbdOKlkWkZlNKWAAghalOwmle;
			kXCGrjQpMuzHPDBxYYjuoPlzlAnh = 6 + bSLpbdOKlkWkZlNKWAAghalOwmle;
			KuJvinLQmuiNJXKvrEalBwjwPYqb = 7 + bSLpbdOKlkWkZlNKWAAghalOwmle;
			buttons = new JdXatRCvdrGKOPnZjOPQbsdPzHroA[14];
			for (int i = 0; i < 14; i++)
			{
				buttons[i] = new JdXatRCvdrGKOPnZjOPQbsdPzHroA(erHFbYqWsffXPOwUfaOXCRkknvxxA, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new okLUGVdjnOaHkqUoOikOkGMRQUCY[6]
			{
				new okLUGVdjnOaHkqUoOikOkGMRQUCY(erHFbYqWsffXPOwUfaOXCRkknvxxA, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + bSLpbdOKlkWkZlNKWAAghalOwmle,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new okLUGVdjnOaHkqUoOikOkGMRQUCY(erHFbYqWsffXPOwUfaOXCRkknvxxA, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + bSLpbdOKlkWkZlNKWAAghalOwmle,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new okLUGVdjnOaHkqUoOikOkGMRQUCY(erHFbYqWsffXPOwUfaOXCRkknvxxA, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + bSLpbdOKlkWkZlNKWAAghalOwmle,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new okLUGVdjnOaHkqUoOikOkGMRQUCY(erHFbYqWsffXPOwUfaOXCRkknvxxA, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + bSLpbdOKlkWkZlNKWAAghalOwmle,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new okLUGVdjnOaHkqUoOikOkGMRQUCY(erHFbYqWsffXPOwUfaOXCRkknvxxA, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 8 + bSLpbdOKlkWkZlNKWAAghalOwmle,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0),
				new okLUGVdjnOaHkqUoOikOkGMRQUCY(erHFbYqWsffXPOwUfaOXCRkknvxxA, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 9 + bSLpbdOKlkWkZlNKWAAghalOwmle,
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
				new GEIDFkFhuurDROYbxKEnrCaVcLKaA(erHFbYqWsffXPOwUfaOXCRkknvxxA, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 5 + bSLpbdOKlkWkZlNKWAAghalOwmle,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20u,
					unitsExp = 0u
				}, TAAeVrLIaVWBXIgCPScwsDFBcmYX)
			};
			accelerometers = new dHcOwexRBkWbxHglTolQUMSGZbys[1]
			{
				new dHcOwexRBkWbxHglTolQUMSGZbys(erHFbYqWsffXPOwUfaOXCRkknvxxA, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					dataIndex = 19 + bSLpbdOKlkWkZlNKWAAghalOwmle,
					bitSize = 48
				}, 3, WaqFstUCtTgxKnPhQZtifQAiDTnP)
			};
			gyroscopes = new jntvuWnVLbBPQuLLgPmMmaPxgSGi[1]
			{
				new jntvuWnVLbBPQuLLgPmMmaPxgSGi(base.initArgs.updateLoopSetting, erHFbYqWsffXPOwUfaOXCRkknvxxA, new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					dataIndex = 13 + bSLpbdOKlkWkZlNKWAAghalOwmle,
					bitSize = 48
				}, 3, 60, VoGEgVaSbrRCZdaqCjbfbPfjuXfhB, iUPDKyqdsucAaCnaSgGpigZKFehHA)
			};
			touchpads = new NaCRucjlkvXgCSkUJCtQCAeoSdInA[1]
			{
				new NaCRucjlkvXgCSkUJCtQCAeoSdInA(erHFbYqWsffXPOwUfaOXCRkknvxxA, new NaCRucjlkvXgCSkUJCtQCAeoSdInA.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new VJJORtyhxtIZFDAvjUdtXgBUbPYD.HIDInfo
				{
					usagePage = 1,
					dataIndex = 35 + bSLpbdOKlkWkZlNKWAAghalOwmle,
					bitSize = 48
				}, 60, ImmbWpruhzohfAdqjBRjLJdExHuH)
			};
			bPgnrAdfRFUYGZkvfasdEykXuDSJ = ReInput.realTime;
			InitializationFinished(initialized: true);
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			bGGyQUJvxlCIybubgQXmFrbtRLAh();
			VACEnLoaKGBJFkcgMOvxVGSgHUHvA(PaswCStrAkmQpcZYWcZPEJHLfUmk.Asynchronous);
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < YdrqCFbpCNIgNdKctjWwBjECBXAlc.Length)
			{
				return false;
			}
			ifJJeCoUDivlbOTyvHLrTLFGzWoE = (float)(timestamp - bPgnrAdfRFUYGZkvfasdEykXuDSJ);
			bPgnrAdfRFUYGZkvfasdEykXuDSJ = timestamp;
			YdrqCFbpCNIgNdKctjWwBjECBXAlc.Write(inputReportPtr, inputReportLength, YdrqCFbpCNIgNdKctjWwBjECBXAlc.Length);
			KdCwNbaLzVaVEStvbZXCxbugdDYcA(YdrqCFbpCNIgNdKctjWwBjECBXAlc);
			QeaJbRgJNsuqGxXzbJjiMoyEtpIbA(YdrqCFbpCNIgNdKctjWwBjECBXAlc, timestamp);
			VJJORtyhxtIZFDAvjUdtXgBUbPYD[] array = axes;
			mQKTGAElpghfAHrscWSqmdIZjaaib(array, YdrqCFbpCNIgNdKctjWwBjECBXAlc, timestamp);
			array = hats;
			mQKTGAElpghfAHrscWSqmdIZjaaib(array, YdrqCFbpCNIgNdKctjWwBjECBXAlc, timestamp);
			array = accelerometers;
			mQKTGAElpghfAHrscWSqmdIZjaaib(array, YdrqCFbpCNIgNdKctjWwBjECBXAlc, timestamp);
			array = gyroscopes;
			mQKTGAElpghfAHrscWSqmdIZjaaib(array, YdrqCFbpCNIgNdKctjWwBjECBXAlc, timestamp);
			array = touchpads;
			mQKTGAElpghfAHrscWSqmdIZjaaib(array, YdrqCFbpCNIgNdKctjWwBjECBXAlc, timestamp);
			byte num = YdrqCFbpCNIgNdKctjWwBjECBXAlc[30 + bSLpbdOKlkWkZlNKWAAghalOwmle];
			byte b = (byte)(num & 0xF);
			if ((num & 0x10) != 0)
			{
				if (b <= 10)
				{
					JSrCYVOLCUdKntDytjJTLighFhNeA = MathTools.Clamp(b * 10 + 5, 0, 100);
					hTSldXDhUmSpbcexzjvjxjmiKOPR = VYDnkgwpyFVKerBadBaAAUlJXuSEA.Charging;
				}
				else
				{
					switch (b)
					{
					case 11:
						JSrCYVOLCUdKntDytjJTLighFhNeA = 100;
						hTSldXDhUmSpbcexzjvjxjmiKOPR = VYDnkgwpyFVKerBadBaAAUlJXuSEA.Full;
						break;
					case 14:
						JSrCYVOLCUdKntDytjJTLighFhNeA = 0;
						hTSldXDhUmSpbcexzjvjxjmiKOPR = VYDnkgwpyFVKerBadBaAAUlJXuSEA.Charging;
						break;
					default:
						JSrCYVOLCUdKntDytjJTLighFhNeA = 0;
						hTSldXDhUmSpbcexzjvjxjmiKOPR = VYDnkgwpyFVKerBadBaAAUlJXuSEA.Unknown;
						break;
					}
				}
			}
			else
			{
				switch (MathTools.Clamp((int)b, 0, 8))
				{
				case 0:
					JSrCYVOLCUdKntDytjJTLighFhNeA = 5;
					break;
				case 1:
					JSrCYVOLCUdKntDytjJTLighFhNeA = 20;
					break;
				case 2:
					JSrCYVOLCUdKntDytjJTLighFhNeA = 30;
					break;
				case 3:
					JSrCYVOLCUdKntDytjJTLighFhNeA = 45;
					break;
				case 4:
					JSrCYVOLCUdKntDytjJTLighFhNeA = 55;
					break;
				case 5:
					JSrCYVOLCUdKntDytjJTLighFhNeA = 70;
					break;
				case 6:
					JSrCYVOLCUdKntDytjJTLighFhNeA = 80;
					break;
				case 7:
					JSrCYVOLCUdKntDytjJTLighFhNeA = 95;
					break;
				case 8:
					JSrCYVOLCUdKntDytjJTLighFhNeA = 100;
					break;
				}
				hTSldXDhUmSpbcexzjvjxjmiKOPR = VYDnkgwpyFVKerBadBaAAUlJXuSEA.Discharging;
			}
			iQHUVqfADasAbhNVFhDWTbEkMcxD();
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualShock4Extension(this);
		}

		private void VACEnLoaKGBJFkcgMOvxVGSgHUHvA(PaswCStrAkmQpcZYWcZPEJHLfUmk P_0)
		{
			if (pRrLBPohnRoyJZUTsbTsBbbCkSk)
			{
				UVmTPIbXtmgTrgpZRaVhdmaFdWzVA(P_0);
				pRrLBPohnRoyJZUTsbTsBbbCkSk = false;
			}
		}

		private bool UVmTPIbXtmgTrgpZRaVhdmaFdWzVA(PaswCStrAkmQpcZYWcZPEJHLfUmk P_0)
		{
			xllgJkgBSgXpZjGEBvAXqSokcbDH();
			bool result = OfhrWMncpYLWZWPqynkvOMogPYWN(P_0);
			if (dJUBuGJotfzpsNtcMOqDIILMsPDM)
			{
				result = OfhrWMncpYLWZWPqynkvOMogPYWN(P_0);
				dJUBuGJotfzpsNtcMOqDIILMsPDM = false;
			}
			return result;
		}

		private unsafe void xllgJkgBSgXpZjGEBvAXqSokcbDH()
		{
			byte b = 0;
			b |= 1;
			ImBWMuxCpPsRsApayyBJTkfcnHuk = false;
			b |= 2;
			ruaXeLshkHXITbZSAcutMNCoFSto = false;
			b |= 4;
			pGYWENUFUWVeOwergGjjUSQAUuUS = false;
			byte b2 = 128;
			if (nTnnpwneIEiRpCLjEYrHBlKFweBwA)
			{
				b2 |= 0x40;
			}
			if (ewsdXqJfQTqFSMXpvudcmseIcQkE)
			{
				b2 |= 4;
				ewsdXqJfQTqFSMXpvudcmseIcQkE = false;
			}
			if (nTnnpwneIEiRpCLjEYrHBlKFweBwA && EcsRyBeyimSceFrAxGTxZjdmdSlGA)
			{
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[0] = 17;
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[1] = b2;
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[2] = 0;
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[3] = b;
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[4] = 0;
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[5] = 0;
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[6] = (byte)vibrationMotors[1].BxdGSwjSxTfTpGjIDKQRyBcYsxwM;
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[7] = (byte)vibrationMotors[0].BxdGSwjSxTfTpGjIDKQRyBcYsxwM;
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[8] = lights[0].bEzAGzsHHfekaYwhxhcDonjBuqcg;
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[9] = lights[0].hZXJuNriHzKJCDxVdGLgjNrguVQp;
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[10] = lights[0].BwttozAvbTHzdAzaYaOeFdxCDjiY;
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[11] = grLiLjpvQQtSgUQYqbdqcStUAgOP;
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[12] = QTzGBsRtVpWysyubbAcHkiPspQkT;
				int eRwKsEbMnPafsEWrYjGCkGlIkCDmA = vPxOasXnuccyLAWJhEFqBsmaFsgFA.ERwKsEbMnPafsEWrYjGCkGlIkCDmA;
				uint bytes = lkucmGgqPEPpwZuIiejyUcfVtfSZ.vobqMaUGgpxvMaucSVUUEDbWPdfN((byte*)(void*)mIYNdtRPAIXzVoojRSvvSoKGHNTQ.Pointer, eRwKsEbMnPafsEWrYjGCkGlIkCDmA - 4, 162u);
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ.Write(bytes, eRwKsEbMnPafsEWrYjGCkGlIkCDmA - 4);
			}
			else
			{
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[0] = 5;
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[1] = b;
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[2] = 0;
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[4] = (byte)vibrationMotors[1].BxdGSwjSxTfTpGjIDKQRyBcYsxwM;
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[5] = (byte)vibrationMotors[0].BxdGSwjSxTfTpGjIDKQRyBcYsxwM;
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[6] = lights[0].bEzAGzsHHfekaYwhxhcDonjBuqcg;
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[7] = lights[0].hZXJuNriHzKJCDxVdGLgjNrguVQp;
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[8] = lights[0].BwttozAvbTHzdAzaYaOeFdxCDjiY;
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[9] = grLiLjpvQQtSgUQYqbdqcStUAgOP;
				mIYNdtRPAIXzVoojRSvvSoKGHNTQ[10] = QTzGBsRtVpWysyubbAcHkiPspQkT;
			}
		}

		private bool OfhrWMncpYLWZWPqynkvOMogPYWN(PaswCStrAkmQpcZYWcZPEJHLfUmk P_0)
		{
			hOcqOdteLYwOdaLWrOQYpeFPifBm = ReInput.realTime + 4.0;
			switch (P_0)
			{
			case PaswCStrAkmQpcZYWcZPEJHLfUmk.Synchronous:
				return qyWazeVNFACMUWpGTreEaLxEoFOb.WriteSync(vPxOasXnuccyLAWJhEFqBsmaFsgFA, 0);
			case PaswCStrAkmQpcZYWcZPEJHLfUmk.Asynchronous:
				qyWazeVNFACMUWpGTreEaLxEoFOb.WriteAsync(vPxOasXnuccyLAWJhEFqBsmaFsgFA, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void QeaJbRgJNsuqGxXzbJjiMoyEtpIbA(NativeBuffer P_0, double P_1)
		{
			byte b = P_0[NnOmPtQCZhVCcKHxWEXxchmSqTJbA];
			buttons[0].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 0x10) != 0, P_1);
			buttons[1].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 0x20) != 0, P_1);
			buttons[2].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 0x40) != 0, P_1);
			buttons[3].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 0x80) != 0, P_1);
			b = P_0[kXCGrjQpMuzHPDBxYYjuoPlzlAnh];
			buttons[4].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 1) != 0, P_1);
			buttons[5].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 2) != 0, P_1);
			buttons[6].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 4) != 0, P_1);
			buttons[7].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 8) != 0, P_1);
			buttons[8].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 0x10) != 0, P_1);
			buttons[9].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 0x20) != 0, P_1);
			buttons[10].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 0x40) != 0, P_1);
			buttons[11].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 0x80) != 0, P_1);
			b = P_0[KuJvinLQmuiNJXKvrEalBwjwPYqb];
			buttons[12].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 1) != 0, P_1);
			buttons[13].PogUzVVLnPzYuPCLsIgJOvBnYfcB((b & 2) != 0, P_1);
		}

		private void mQKTGAElpghfAHrscWSqmdIZjaaib(VJJORtyhxtIZFDAvjUdtXgBUbPYD[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].kIKDSuiibFIJviyHCLnqsKOSMCInA(P_1, P_2);
			}
		}

		private void bGGyQUJvxlCIybubgQXmFrbtRLAh()
		{
			if (isVibrating && ReInput.realTime >= hOcqOdteLYwOdaLWrOQYpeFPifBm)
			{
				pRrLBPohnRoyJZUTsbTsBbbCkSk = true;
				ImBWMuxCpPsRsApayyBJTkfcnHuk = true;
			}
		}

		private void KdCwNbaLzVaVEStvbZXCxbugdDYcA(NativeBuffer P_0)
		{
			if (EcsRyBeyimSceFrAxGTxZjdmdSlGA)
			{
				ushort num = YdrqCFbpCNIgNdKctjWwBjECBXAlc.ReadUShort(10 + bSLpbdOKlkWkZlNKWAAghalOwmle);
				float hEjqhuUjbtMHbJteqRnsbGIyQKGS;
				if (num != bmIFvcwvAgjZFqQjvqaYUbeqsRHI)
				{
					int num2 = ((num >= bmIFvcwvAgjZFqQjvqaYUbeqsRHI) ? (num - bmIFvcwvAgjZFqQjvqaYUbeqsRHI) : (num + 65535 - bmIFvcwvAgjZFqQjvqaYUbeqsRHI));
					hEjqhuUjbtMHbJteqRnsbGIyQKGS = (float)num2 / 187500f;
				}
				else
				{
					int num2 = 0;
					hEjqhuUjbtMHbJteqRnsbGIyQKGS = 0f;
				}
				bmIFvcwvAgjZFqQjvqaYUbeqsRHI = num;
				HEjqhuUjbtMHbJteqRnsbGIyQKGS = hEjqhuUjbtMHbJteqRnsbGIyQKGS;
			}
		}

		private void iQHUVqfADasAbhNVFhDWTbEkMcxD()
		{
			if (EcsRyBeyimSceFrAxGTxZjdmdSlGA)
			{
				_ = HEjqhuUjbtMHbJteqRnsbGIyQKGS;
				_ = 0f;
				Vector3 vector = laWHmZcGqNmEPWGTTNyFdeGQwOMX(new Vector3(gyroscopes[0].FOFdTvxaVfzjKuXtYfOzBSpyuzjD[0], gyroscopes[0].FOFdTvxaVfzjKuXtYfOzBSpyuzjD[1], gyroscopes[0].FOFdTvxaVfzjKuXtYfOzBSpyuzjD[2]), HEjqhuUjbtMHbJteqRnsbGIyQKGS);
				fayJuHGijHAyOGnWAUSHlUVYKekT(ref vector);
				Vector3 vector2 = new Vector3(accelerometers[0].WuxcudBBVzHNVwoaaucXfPaFfSOU[0] * -1f, accelerometers[0].WuxcudBBVzHNVwoaaucXfPaFfSOU[1] * -1f, accelerometers[0].WuxcudBBVzHNVwoaaucXfPaFfSOU[2] * -1f);
				fpKxtojtTwhwhzlMuZHUXNqMGJHG(vector2, vector);
			}
		}

		private static bool fayJuHGijHAyOGnWAUSHlUVYKekT(ref Vector3 P_0)
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

		private void fpKxtojtTwhwhzlMuZHUXNqMGJHG(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && OgEpCKDLhCvdmeXnQHDPIHklcdvS(P_0, out var niWbanHLbQcITmYfYjTqBSOyEDDlA2))
			{
				Quaternion a = XmfCjHptiKwRkzSDmBPOhNDhVUwn * quaternion;
				if (!RzJkUWNwhPDpMjoXDFdWbpeyXPeS)
				{
					RzJkUWNwhPDpMjoXDFdWbpeyXPeS = true;
					ogiOPCjXAMncvzFHzVruCoVZhduo = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					yBqrJbsiEXBwWCHqIOYhPDeEPSrq = XmfCjHptiKwRkzSDmBPOhNDhVUwn;
				}
				ogiOPCjXAMncvzFHzVruCoVZhduo *= quaternion;
				yBqrJbsiEXBwWCHqIOYhPDeEPSrq *= quaternion;
				Quaternion b;
				if ((niWbanHLbQcITmYfYjTqBSOyEDDlA2 & niWbanHLbQcITmYfYjTqBSOyEDDlA.XZ) != niWbanHLbQcITmYfYjTqBSOyEDDlA.None)
				{
					b = uGlCsvalRbXgoFvvENgNjULcDQHEc(P_0, a.eulerAngles.y);
				}
				else if ((niWbanHLbQcITmYfYjTqBSOyEDDlA2 & niWbanHLbQcITmYfYjTqBSOyEDDlA.Y) != niWbanHLbQcITmYfYjTqBSOyEDDlA.None)
				{
					b = sgrizEdAikFgrhePFqvafzxAwnSVB(P_0);
					Vector3 vector = yBqrJbsiEXBwWCHqIOYhPDeEPSrq * Vector3.right;
					float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					b = Quaternion.Euler(0f, y, 0f) * b;
				}
				else
				{
					b = Quaternion.identity;
				}
				XmfCjHptiKwRkzSDmBPOhNDhVUwn = Quaternion.Lerp(a, b, 0.01999998f);
			}
			else
			{
				XmfCjHptiKwRkzSDmBPOhNDhVUwn *= quaternion;
				if (RzJkUWNwhPDpMjoXDFdWbpeyXPeS)
				{
					RzJkUWNwhPDpMjoXDFdWbpeyXPeS = false;
				}
			}
		}

		private static Quaternion dUXwRxILGWuxYylHyERQbuHMpQJm(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = QDMQKWBgmaWoJGlSDUtDXgluJiAP(new Vector3(P_0.x, P_0.y, P_0.z), P_1);
			return new Quaternion(vector.x, vector.y, vector.z, P_0.w);
		}

		private static Vector3 QDMQKWBgmaWoJGlSDUtDXgluJiAP(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion NwyjplbVBnsMQMNpXdWVDDnBLdNR(Quaternion P_0, rjxSdBxkRLfLWqojqSJITshEpkGi P_1)
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

		private float kwKJzddziETvjvOEfuQjcdrJUmfH(float P_0, float P_1)
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

		private Vector3 IpudvvLWFlDcEJVwoZxgpwFsCdiEb(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return new Vector3(x, P_1, z);
		}

		private Quaternion uGlCsvalRbXgoFvvENgNjULcDQHEc(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return Quaternion.Euler(x, P_1, z);
		}

		private Quaternion sgrizEdAikFgrhePFqvafzxAwnSVB(Vector3 P_0, float P_1 = 0f)
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

		private float XfdqaAJOWSXKFYHxSXIXZHVcxGxc(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool TRFckMNiTrfNoTUWzozTDkiFZMpK(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool OgEpCKDLhCvdmeXnQHDPIHklcdvS(Vector3 P_0, out niWbanHLbQcITmYfYjTqBSOyEDDlA P_1)
		{
			P_0.Normalize();
			P_1 = niWbanHLbQcITmYfYjTqBSOyEDDlA.None;
			bool result = false;
			if (VzOyhPxECIRvgqkKBhZMUZJPPwjf(P_0))
			{
				result = true;
				P_1 |= niWbanHLbQcITmYfYjTqBSOyEDDlA.XZ;
			}
			if (UVvGfKhADJvTaYOQMnntQHlTDqod(P_0))
			{
				result = true;
				P_1 |= niWbanHLbQcITmYfYjTqBSOyEDDlA.Y;
			}
			return result;
		}

		private bool VzOyhPxECIRvgqkKBhZMUZJPPwjf(Vector3 P_0)
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

		private bool UVvGfKhADJvTaYOQMnntQHlTDqod(Vector3 P_0)
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

		private Vector3 UfsGrJbjAHQInFbgFbCRnEXnWfPM(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 EzUeGYBAIckUelIvfnzReaaPyIDAA(RingBuffer<jntvuWnVLbBPQuLLgPmMmaPxgSGi.xJZoNJvwOYuCkuguqxILWyKPVNLg> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				jntvuWnVLbBPQuLLgPmMmaPxgSGi.xJZoNJvwOYuCkuguqxILWyKPVNLg xJZoNJvwOYuCkuguqxILWyKPVNLg = P_0[i];
				result += laWHmZcGqNmEPWGTTNyFdeGQwOMX(xJZoNJvwOYuCkuguqxILWyKPVNLg.DvHdJsiOpQCMusadeasERFNqfxYj, xJZoNJvwOYuCkuguqxILWyKPVNLg.xXpuLfPLSjTeMlQUaganZAUGZSHq);
			}
			return result;
		}

		private Vector3 laWHmZcGqNmEPWGTTNyFdeGQwOMX(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.06103702f * P_1;
		}

		private int TAAeVrLIaVWBXIgCPScwsDFBcmYX(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void WaqFstUCtTgxKnPhQZtifQAiDTnP(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void VoGEgVaSbrRCZdaqCjbfbPfjuXfhB(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private float iUPDKyqdsucAaCnaSgGpigZKFehHA()
		{
			return HEjqhuUjbtMHbJteqRnsbGIyQKGS;
		}

		private void ImmbWpruhzohfAdqjBRjLJdExHuH(NativeBuffer P_0, NaCRucjlkvXgCSkUJCtQCAeoSdInA.TouchData[] P_1)
		{
			int num = 35 + bSLpbdOKlkWkZlNKWAAghalOwmle;
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
			P_1[0].touchId = VEOAaUtMgWogdmRbDGnBRFaIECIV(0, flag, num3);
			P_1[0].positionRawX = positionRawX;
			P_1[0].positionRawY = positionRawY;
			P_1[1].isTouching = flag2;
			P_1[1].touchId = VEOAaUtMgWogdmRbDGnBRFaIECIV(1, flag2, num4);
			P_1[1].positionRawX = positionRawX2;
			P_1[1].positionRawY = positionRawY2;
		}

		private int VEOAaUtMgWogdmRbDGnBRFaIECIV(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				UvVuSUVMdVyyLEQIGrZIGoNxEOyw[P_0] = -1;
				NmdzWFAbDefJiESpgZZyumFsmacj[P_0] = P_2;
				return -1;
			}
			if (P_2 != NmdzWFAbDefJiESpgZZyumFsmacj[P_0])
			{
				int num = xdeiJKWbvmNqhGmSCgiyMeJjkHmb;
				if (xdeiJKWbvmNqhGmSCgiyMeJjkHmb == int.MaxValue)
				{
					xdeiJKWbvmNqhGmSCgiyMeJjkHmb = 0;
				}
				else
				{
					xdeiJKWbvmNqhGmSCgiyMeJjkHmb++;
				}
				NmdzWFAbDefJiESpgZZyumFsmacj[P_0] = P_2;
				UvVuSUVMdVyyLEQIGrZIGoNxEOyw[P_0] = num;
				return num;
			}
			return UvVuSUVMdVyyLEQIGrZIGoNxEOyw[P_0];
		}

		private void dLvgPYaNisYCciPkXCezhEuALVf()
		{
			ruaXeLshkHXITbZSAcutMNCoFSto = true;
			UCeBBxkoYyCwKjBUtcmhqgUPczTgA();
		}

		private void hWnjCmhmfirSRyvDouAqiANfoDEU()
		{
			pGYWENUFUWVeOwergGjjUSQAUuUS = true;
			UCeBBxkoYyCwKjBUtcmhqgUPczTgA();
		}

		private void gTKFsiXGpRntbvdcEbkelaQBrzZG()
		{
			ImBWMuxCpPsRsApayyBJTkfcnHuk = true;
			UCeBBxkoYyCwKjBUtcmhqgUPczTgA();
		}

		private void UCeBBxkoYyCwKjBUtcmhqgUPczTgA()
		{
			pRrLBPohnRoyJZUTsbTsBbbCkSk = true;
		}

		~DualShock4Driver()
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
				VACEnLoaKGBJFkcgMOvxVGSgHUHvA(PaswCStrAkmQpcZYWcZPEJHLfUmk.Synchronous);
				if (YdrqCFbpCNIgNdKctjWwBjECBXAlc != null)
				{
					YdrqCFbpCNIgNdKctjWwBjECBXAlc.Dispose();
				}
				if (mIYNdtRPAIXzVoojRSvvSoKGHNTQ != null)
				{
					mIYNdtRPAIXzVoojRSvvSoKGHNTQ.Dispose();
				}
			}
		}

		public static bool Matches(int vid, int pid)
		{
			for (int i = 0; i < Consts.pidVids_sony_dualShock4.Count; i++)
			{
				if (Consts.pidVids_sony_dualShock4[i].vendorId == vid && Consts.pidVids_sony_dualShock4[i].productId == pid)
				{
					return true;
				}
			}
			return false;
		}

		[Conditional("DEBUG_THIS")]
		private static void cpwFZcmZUOjCVSnNshPOLjsaUBKh(object P_0)
		{
			Logger.Log(P_0, requiredThreadSafety: true);
		}
	}
}
