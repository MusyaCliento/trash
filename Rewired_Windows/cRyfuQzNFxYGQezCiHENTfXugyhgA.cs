using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Platforms.Windows.DirectInput;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class cRyfuQzNFxYGQezCiHENTfXugyhgA : PlatformInputManager, XxcRWDacxPwaZuelhLPGabtEumyQ
{
	private class sRWhguxFTduLiFMWjcVdhYcRFInQA : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int lVrdIvidbMTDVwImaqFQxAZZCESgA;

		private int ESdOuOAgHyKOAleFOQgAfuSpsFlX;

		public Guid gOjciFjQoNUisNojPkskSojSdMspA;

		public string DrEFCDDkWIfUBatXCbxvywnkoNuHB;

		public readonly GoJaFByXFoZTGNocjTiOVrXyHFHL LEhKMDCzIjquVNmJvymqRHMMWifX;

		public UTyQEMVineRQmjtixsdHzIMSbUZe MvPVDnlBWoKSHHDgvQAtQRcRTWuj;

		public ZSovmlhoZKTNRcDjddXShKrptrEEA ECbQVeJFuMsdgjquINtRyanKvbWb;

		public string LyPjjoyYbFqZzaOyZYPALZWTCYiB;

		public string kdVHsgqAFwmFQXnhgRaVDELiKnzC;

		public int JdFBDPxbYWufPZDTuiqIfjBXdKCdA;

		public Guid xHrxrbiVNNrvRQEBxypJwgTRgIJS;

		public Guid XoGqGUJoMrNVRXlJrtRoQAmuEAFp;

		public Guid lyAgFGdIgZPjctjcvktMApKBBqlYb;

		public int NTPQNZKSPdJyeDkKhWBRWCaCeKUBA;

		public bool mvMSNzRJmiwRoenbTArzzjFuKifE;

		public string XrYtFEBYJvRVGjJoLgKeQTOEhtZS;

		public string BVxCYjiutEJjufEgJmLVXSIICyDyB;

		public int ZgjWPEkPAbcGkqRqLWPXqJWPHeQX;

		public int sqiiNLTNLSgznBlKKlSuudwIOLqdA;

		public int xYtxjvGiDblMLazxSNoxuZeFGhdo;

		public int xPHraTegAQkZKJrJSesorPOqjVNDA;

		public int oOgOpJMTHvLxBTmQYOBaWbPGVsrj;

		public bool BNOftdEcQnhgGcDfbZBdbKAlVXzDA;

		public Controller.Extension xlmTdfKZCDokkVelKFHzgEYBOJoyA;

		private float[] EkcTmIfwJwBvpcRmnFYjImNdGQLN;

		private bool[] jvFokQRqRrDIuDuiFKwDfnYYjpttA;

		private HardwareJoystickMap_InputManager XfDBWjoCosYvoTVfZsfDKsouIvPN;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> EIyyOPTJSYGTXrOymTBxmWkZoEWC;

		private bool eyCMcoLsgvgdRCDcjeBfdjHHePRp;

		private bool SZYDrhhojcukOYAXmgsXClkEUroM;

		private bool GguZprEGJwnDYlDjlYOkjraiIBjF;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return lVrdIvidbMTDVwImaqFQxAZZCESgA;
			}
			set
			{
				lVrdIvidbMTDVwImaqFQxAZZCESgA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return ESdOuOAgHyKOAleFOQgAfuSpsFlX;
			}
			set
			{
				ESdOuOAgHyKOAleFOQgAfuSpsFlX = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name => DrEFCDDkWIfUBatXCbxvywnkoNuHB;

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (ESdOuOAgHyKOAleFOQgAfuSpsFlX < 0)
				{
					return null;
				}
				return ESdOuOAgHyKOAleFOQgAfuSpsFlX;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension => xlmTdfKZCDokkVelKFHzgEYBOJoyA;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => xHrxrbiVNNrvRQEBxypJwgTRgIJS;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public sRWhguxFTduLiFMWjcVdhYcRFInQA(GoJaFByXFoZTGNocjTiOVrXyHFHL P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1)
		{
			LEhKMDCzIjquVNmJvymqRHMMWifX = P_0;
			EIyyOPTJSYGTXrOymTBxmWkZoEWC = P_1;
			ESdOuOAgHyKOAleFOQgAfuSpsFlX = -1;
			lVrdIvidbMTDVwImaqFQxAZZCESgA = -1;
		}

		public void NePpfUgiQEmSHBTSVMgPUmsQwQQC()
		{
			string text = kdVHsgqAFwmFQXnhgRaVDELiKnzC;
			Guid xoGqGUJoMrNVRXlJrtRoQAmuEAFp = XoGqGUJoMrNVRXlJrtRoQAmuEAFp;
			lyAgFGdIgZPjctjcvktMApKBBqlYb = MiscTools.CreateGuidHashSHA1(text + xoGqGUJoMrNVRXlJrtRoQAmuEAFp.ToString());
			ZgjWPEkPAbcGkqRqLWPXqJWPHeQX = xYtxjvGiDblMLazxSNoxuZeFGhdo;
			sqiiNLTNLSgznBlKKlSuudwIOLqdA = xPHraTegAQkZKJrJSesorPOqjVNDA + oOgOpJMTHvLxBTmQYOBaWbPGVsrj * 8;
			aIYFEumZFvBpuUSrJCjJqWnKXpRD();
			gOjciFjQoNUisNojPkskSojSdMspA = XfDBWjoCosYvoTVfZsfDKsouIvPN.hardwareMapIdentifier.guid;
			DrEFCDDkWIfUBatXCbxvywnkoNuHB = XfDBWjoCosYvoTVfZsfDKsouIvPN.controllerName;
			if (DrEFCDDkWIfUBatXCbxvywnkoNuHB == "Unknown Controller")
			{
				if (mvMSNzRJmiwRoenbTArzzjFuKifE && !string.IsNullOrEmpty(XrYtFEBYJvRVGjJoLgKeQTOEhtZS))
				{
					DrEFCDDkWIfUBatXCbxvywnkoNuHB = XrYtFEBYJvRVGjJoLgKeQTOEhtZS;
				}
				else if (!string.IsNullOrEmpty(kdVHsgqAFwmFQXnhgRaVDELiKnzC))
				{
					DrEFCDDkWIfUBatXCbxvywnkoNuHB = kdVHsgqAFwmFQXnhgRaVDELiKnzC;
				}
			}
			eyCMcoLsgvgdRCDcjeBfdjHHePRp = gOjciFjQoNUisNojPkskSojSdMspA == Guid.Empty;
			EkcTmIfwJwBvpcRmnFYjImNdGQLN = new float[ZgjWPEkPAbcGkqRqLWPXqJWPHeQX];
			jvFokQRqRrDIuDuiFKwDfnYYjpttA = new bool[sqiiNLTNLSgznBlKKlSuudwIOLqdA];
			LEhKMDCzIjquVNmJvymqRHMMWifX.wSGnpDrtAPRHWexmkGiofroVzojF();
			Update();
		}

		public void qEeBDOrDIFcYbVMGeYumABKSHCVAA(sRWhguxFTduLiFMWjcVdhYcRFInQA P_0)
		{
			if (P_0 != null)
			{
				ESdOuOAgHyKOAleFOQgAfuSpsFlX = P_0.ESdOuOAgHyKOAleFOQgAfuSpsFlX;
				lVrdIvidbMTDVwImaqFQxAZZCESgA = P_0.lVrdIvidbMTDVwImaqFQxAZZCESgA;
				for (int i = 0; i < MathTools.Min(jvFokQRqRrDIuDuiFKwDfnYYjpttA.Length, P_0.jvFokQRqRrDIuDuiFKwDfnYYjpttA.Length); i++)
				{
					jvFokQRqRrDIuDuiFKwDfnYYjpttA[i] = P_0.jvFokQRqRrDIuDuiFKwDfnYYjpttA[i];
				}
				for (int j = 0; j < MathTools.Min(EkcTmIfwJwBvpcRmnFYjImNdGQLN.Length, P_0.EkcTmIfwJwBvpcRmnFYjImNdGQLN.Length); j++)
				{
					EkcTmIfwJwBvpcRmnFYjImNdGQLN[j] = P_0.EkcTmIfwJwBvpcRmnFYjImNdGQLN[j];
				}
				SZYDrhhojcukOYAXmgsXClkEUroM = P_0.SZYDrhhojcukOYAXmgsXClkEUroM;
				LEhKMDCzIjquVNmJvymqRHMMWifX.sZMeMoeguLEVduAVERYlGGUGmECRA(P_0.LEhKMDCzIjquVNmJvymqRHMMWifX);
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			LEhKMDCzIjquVNmJvymqRHMMWifX.PSXQSsxFGdFIgAFvgXgBOOPVquuI();
			bool[] array = LEhKMDCzIjquVNmJvymqRHMMWifX.flVRgRfgUSnpujKJECfCfnBIxjDJ;
			int[] yuPUmDiBSRBZcVVgoZXjtNoPngXq = LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.yuPUmDiBSRBZcVVgoZXjtNoPngXq;
			zQRriuRrDWlJHhogXsQlZdUKaXqBA(array, yuPUmDiBSRBZcVVgoZXjtNoPngXq);
			aBQCUaoIAZRqeGNKcbLfXDxQwgcr(array, yuPUmDiBSRBZcVVgoZXjtNoPngXq);
			LEhKMDCzIjquVNmJvymqRHMMWifX.ntbhBJevgmYBQjIRyOSNYUSEIYSK();
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (ZgjWPEkPAbcGkqRqLWPXqJWPHeQX != dataUpdater.axisCount || sqiiNLTNLSgznBlKKlSuudwIOLqdA != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < ZgjWPEkPAbcGkqRqLWPXqJWPHeQX; i++)
			{
				dataUpdater.axisValues[i] = EkcTmIfwJwBvpcRmnFYjImNdGQLN[i];
			}
			for (int j = 0; j < sqiiNLTNLSgznBlKKlSuudwIOLqdA; j++)
			{
				dataUpdater.buttonValues[j] = jvFokQRqRrDIuDuiFKwDfnYYjpttA[j];
			}
			if (SZYDrhhojcukOYAXmgsXClkEUroM && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int MYNEgUiFzAzYachDdQnoWiANidlP(sRWhguxFTduLiFMWjcVdhYcRFInQA P_0)
		{
			if (P_0.lVrdIvidbMTDVwImaqFQxAZZCESgA == lVrdIvidbMTDVwImaqFQxAZZCESgA)
			{
				return 2;
			}
			if (xYtxjvGiDblMLazxSNoxuZeFGhdo != P_0.xYtxjvGiDblMLazxSNoxuZeFGhdo)
			{
				return 0;
			}
			if (xPHraTegAQkZKJrJSesorPOqjVNDA != P_0.xPHraTegAQkZKJrJSesorPOqjVNDA)
			{
				return 0;
			}
			if (oOgOpJMTHvLxBTmQYOBaWbPGVsrj != P_0.oOgOpJMTHvLxBTmQYOBaWbPGVsrj)
			{
				return 0;
			}
			if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid)
			{
				return 2;
			}
			if (P_0.lyAgFGdIgZPjctjcvktMApKBBqlYb == lyAgFGdIgZPjctjcvktMApKBBqlYb)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo hVogBWRzqttBpZdPVRbnpjNXwJJG()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			uyCvHYwqOiyRzwJnNnIikiMzgxJcA(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			bAZiLoLtXbKxDnfWJTozHVTSeceY(bridgedController);
			return bridgedController;
		}

		BridgedController IInputManagerJoystick.ToBridgedController()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToBridgedController
			return this.ToBridgedController();
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(lVrdIvidbMTDVwImaqFQxAZZCESgA);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		public bool DhrJtKCAwUfVKoSlSdFAGeepgdmcb()
		{
			try
			{
				LEhKMDCzIjquVNmJvymqRHMMWifX.owFVkJQkkPDmjBRaHbMOjwVbxEvyb.XJaFxZCxuebhnvwBZpJdHiocfHSp();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void uUzXtRRdCXEBXewBRydYsEtMAbjVA()
		{
			try
			{
				if (LEhKMDCzIjquVNmJvymqRHMMWifX.owFVkJQkkPDmjBRaHbMOjwVbxEvyb != null)
				{
					LEhKMDCzIjquVNmJvymqRHMMWifX.owFVkJQkkPDmjBRaHbMOjwVbxEvyb.lKudTReqXTqfadBHhkYChczUaimMB();
				}
			}
			catch
			{
			}
		}

		public void FUzBoenJKOoPfZeUGTZxKnrgIdBm()
		{
			try
			{
				if (LEhKMDCzIjquVNmJvymqRHMMWifX.owFVkJQkkPDmjBRaHbMOjwVbxEvyb != null)
				{
					LEhKMDCzIjquVNmJvymqRHMMWifX.owFVkJQkkPDmjBRaHbMOjwVbxEvyb.IwNWsmpJozXysImeieINzhgLqjiS();
				}
			}
			catch
			{
			}
		}

		private void zQRriuRrDWlJHhogXsQlZdUKaXqBA(bool[] P_0, int[] P_1)
		{
			if (ZgjWPEkPAbcGkqRqLWPXqJWPHeQX <= 0)
			{
				return;
			}
			switch (XfDBWjoCosYvoTVfZsfDKsouIvPN.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)XfDBWjoCosYvoTVfZsfDKsouIvPN.map).Axes_orig;
				if (axes_orig2 != null)
				{
					for (int j = 0; j < axes_orig2.Length; j++)
					{
						ZSbilqNQIAHhOLoNFdjvkUTZDwVI(axes_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)XfDBWjoCosYvoTVfZsfDKsouIvPN.map).Axes_orig;
				if (axes_orig != null)
				{
					for (int i = 0; i < axes_orig.Length; i++)
					{
						ZSbilqNQIAHhOLoNFdjvkUTZDwVI(axes_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void aBQCUaoIAZRqeGNKcbLfXDxQwgcr(bool[] P_0, int[] P_1)
		{
			if (sqiiNLTNLSgznBlKKlSuudwIOLqdA <= 0)
			{
				return;
			}
			switch (XfDBWjoCosYvoTVfZsfDKsouIvPN.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)XfDBWjoCosYvoTVfZsfDKsouIvPN.map).Buttons_orig;
				if (buttons_orig2 != null)
				{
					for (int j = 0; j < buttons_orig2.Length; j++)
					{
						qSncOkCxHZQcEnnASKxIaNtLbboH(buttons_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)XfDBWjoCosYvoTVfZsfDKsouIvPN.map).Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						qSncOkCxHZQcEnnASKxIaNtLbboH(buttons_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void ZSbilqNQIAHhOLoNFdjvkUTZDwVI(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= ZgjWPEkPAbcGkqRqLWPXqJWPHeQX)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			EkcTmIfwJwBvpcRmnFYjImNdGQLN[P_1] = iZErEaGnBwXbMKmUwZwcKpcNoEw(P_0, P_2, P_3);
			if (!SZYDrhhojcukOYAXmgsXClkEUroM && EkcTmIfwJwBvpcRmnFYjImNdGQLN[P_1] != 0f)
			{
				SZYDrhhojcukOYAXmgsXClkEUroM = true;
			}
		}

		private void qSncOkCxHZQcEnnASKxIaNtLbboH(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= sqiiNLTNLSgznBlKKlSuudwIOLqdA)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			jvFokQRqRrDIuDuiFKwDfnYYjpttA[P_1] = nWUGbODVwpdTeCecdoLfqfidhqJFD(P_0, P_2, P_3);
			if (!SZYDrhhojcukOYAXmgsXClkEUroM && jvFokQRqRrDIuDuiFKwDfnYYjpttA[P_1])
			{
				SZYDrhhojcukOYAXmgsXClkEUroM = true;
			}
		}

		private float iZErEaGnBwXbMKmUwZwcKpcNoEw(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis <= 0 || P_0.sourceAxis >= 32)
				{
					return 0f;
				}
				return SOQfxTJqohQJwVrKOjVmvpjpCLLjA((DirectInputAxis)P_0.sourceAxis);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= xPHraTegAQkZKJrJSesorPOqjVNDA || sourceButton >= 128)
				{
					return 0f;
				}
				if (!P_1[sourceButton])
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= oOgOpJMTHvLxBTmQYOBaWbPGVsrj || sourceHat >= 4)
				{
					return 0f;
				}
				int num = P_2[sourceHat];
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = tElrmKwgAYEFMhVoMIMaiciRKQeZ(num, AxisDirection.Horizontal);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num2 < 0f)
							{
								return 0f;
							}
						}
						else if (num2 > 0f)
						{
							return 0f;
						}
					}
				}
				else
				{
					num2 = tElrmKwgAYEFMhVoMIMaiciRKQeZ(num, AxisDirection.Vertical);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num2 < 0f)
							{
								return 0f;
							}
						}
						else if (num2 > 0f)
						{
							return 0f;
						}
					}
				}
				if (P_0.invert)
				{
					num2 *= -1f;
				}
				return num2;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Custom)
			{
				CustomCalculation customCalculation = P_0.customCalculation;
				if (customCalculation == null)
				{
					return 0f;
				}
				if (customCalculation.ResultType != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
				if (customCalculationSourceData == null)
				{
					return 0f;
				}
				for (int i = 0; i < customCalculationSourceData.Length; i++)
				{
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && kIPZJVsYecSOzMhWNTbBOjVhMMel(customCalculationSourceData[i], out var item))
					{
						customCalculation.AddData(item);
					}
				}
				if (!customCalculation.Process())
				{
					return 0f;
				}
				if (customCalculation.Result.type != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				return customCalculation.Result;
			}
			return 0f;
		}

		private float SOQfxTJqohQJwVrKOjVmvpjpCLLjA(DirectInputAxis P_0)
		{
			return P_0 switch
			{
				DirectInputAxis.X => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.EYXAGlKJOxVBnSgbSNRFFFtODGReA, 
				DirectInputAxis.Y => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.xLXTJNZjUUvVMkIpmQTKFPHiiDam, 
				DirectInputAxis.Z => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.mKIjfrzYxARcHDfviKpXMCAgKFQH, 
				DirectInputAxis.RotationX => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.GLNvQzcYCCtsoiyIDrAGYBJHgTgQ, 
				DirectInputAxis.RotationY => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.nlYFoBiwRDwHMCbauUmDONkqJRwN, 
				DirectInputAxis.RotationZ => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.WqLMZUjXRMQQjhzNubXSxbEuwvyo, 
				DirectInputAxis.Slider0 => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.tAQemkVJOIpxHmzuMNgzSPHJCZph[0], 
				DirectInputAxis.Slider1 => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.tAQemkVJOIpxHmzuMNgzSPHJCZph[1], 
				DirectInputAxis.VelocityX => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.fIbpvlrFZsJzubdDKbRhECHvlUbT, 
				DirectInputAxis.VelocityY => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.MkVEHeTRmKONUrrFjwKlNPHSjmBl, 
				DirectInputAxis.VelocityZ => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.WQPjanQSzyFBmlffzIzXIipTtUKM, 
				DirectInputAxis.AngularVelocityX => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.oUmeZHBNOfGpdcxwKLRNqPuBXylu, 
				DirectInputAxis.AngularVelocityY => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.YqigXbCMSOMBkiDzVBPREoXJVPCQB, 
				DirectInputAxis.AngularVelocityZ => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.bIbnzgqMrMsNInYvARTioDTGlxTj, 
				DirectInputAxis.VelocitySlider0 => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.sKRfQBapODETsEDlHvaIVLViZLeiA[0], 
				DirectInputAxis.VelocitySlider1 => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.sKRfQBapODETsEDlHvaIVLViZLeiA[1], 
				DirectInputAxis.AccelerationX => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.LaTsLRyNLEHPPALLRBJugqqdIuQJc, 
				DirectInputAxis.AccelerationY => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.PkBErREOzjaWNgRtigclesqbGzhTd, 
				DirectInputAxis.AccelerationZ => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.yudiXScBKRTPxPSeUddTbgtwDYCi, 
				DirectInputAxis.AngularAccelerationX => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.MQyKIuLXSyckSQexbYBHbGVFtisF, 
				DirectInputAxis.AngularAccelerationY => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.ucsXMcYvGpSVQRkjgTrjfSoRjDQh, 
				DirectInputAxis.AngularAccelerationZ => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.AOedkHIgsYKyRzbYTMAkHjazHJlWA, 
				DirectInputAxis.AccelerationSlider0 => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.zXHPdFqgNhGDRxiuElpcvcQMoYLr[0], 
				DirectInputAxis.AccelerationSlider1 => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.zXHPdFqgNhGDRxiuElpcvcQMoYLr[1], 
				DirectInputAxis.ForceX => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.lwIhyIKIubotrdDQRBPUZMEqSEAM, 
				DirectInputAxis.ForceY => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.njXXOIpVPErutkPXErmMvwzVNItA, 
				DirectInputAxis.ForceZ => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.MqRIvbTOxVyjBeBWwBtVcTVVTOOk, 
				DirectInputAxis.TorqueX => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.uyhPAmImBFvTBgOmyPCSskRcqeuP, 
				DirectInputAxis.TorqueY => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.ymsgIvGpwCSOTbDzqSPnYonpUHfg, 
				DirectInputAxis.TorqueZ => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.UZhingMzjTlEokbvGkdxgRwfHuWJ, 
				DirectInputAxis.ForceSlider0 => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.HPcbZHhnsANhPHiqioWvEDWmMHfS[0], 
				DirectInputAxis.ForceSlider1 => LEhKMDCzIjquVNmJvymqRHMMWifX.SyMGIWmCpxWposkWWaiepokrrZlm.HPcbZHhnsANhPHiqioWvEDWmMHfS[1], 
				_ => 0f, 
			};
		}

		private bool nWUGbODVwpdTeCecdoLfqfidhqJFD(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (P_1[P_0.ignoreIfButtonsActiveButtons[i]])
						{
							return false;
						}
					}
				}
				if (P_0.requireMultipleButtons)
				{
					bool flag = false;
					for (int j = 0; j < P_0.requiredButtons.Length; j++)
					{
						if (!P_1[P_0.requiredButtons[j]])
						{
							return false;
						}
						flag = true;
					}
					if (flag)
					{
						return true;
					}
					return false;
				}
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= xPHraTegAQkZKJrJSesorPOqjVNDA || sourceButton >= 128)
				{
					return false;
				}
				return P_1[sourceButton];
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis <= 0 || P_0.sourceAxis > 32)
				{
					return false;
				}
				float num = SOQfxTJqohQJwVrKOjVmvpjpCLLjA((DirectInputAxis)P_0.sourceAxis);
				if (MathTools.Abs(num) <= P_0.axisDeadZone)
				{
					return false;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
				{
					if (num < 0f)
					{
						return false;
					}
				}
				else if (num > 0f)
				{
					return false;
				}
				return true;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= oOgOpJMTHvLxBTmQYOBaWbPGVsrj || sourceHat >= 4)
				{
					return false;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return vuHniulLdsaDvqksYhTarJlKkgKk(P_2[sourceHat], 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return vuHniulLdsaDvqksYhTarJlKkgKk(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return vuHniulLdsaDvqksYhTarJlKkgKk(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return vuHniulLdsaDvqksYhTarJlKkgKk(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return vuHniulLdsaDvqksYhTarJlKkgKk(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return vuHniulLdsaDvqksYhTarJlKkgKk(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return vuHniulLdsaDvqksYhTarJlKkgKk(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return vuHniulLdsaDvqksYhTarJlKkgKk(P_2[sourceHat], 7, P_0.sourceHatType);
				}
			}
			else if (P_0.sourceType == HardwareElementSourceTypeWithHat.Custom)
			{
				CustomCalculation customCalculation = P_0.customCalculation;
				if (customCalculation == null)
				{
					return false;
				}
				if (customCalculation.ResultType != TypeWrapper.DataType.Single)
				{
					return false;
				}
				HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
				if (customCalculationSourceData == null)
				{
					return false;
				}
				for (int k = 0; k < customCalculationSourceData.Length; k++)
				{
					if (customCalculationSourceData[k] == null)
					{
						continue;
					}
					switch ((HardwareElementSourceTypeWithHat)customCalculationSourceData[k].sourceType)
					{
					case HardwareElementSourceTypeWithHat.Button:
					{
						if (AdpQhcEoBqCHpbAescIpbOEDDRmCA(customCalculationSourceData[k], P_1, out var flag2))
						{
							customCalculation.AddData(flag2 ? 1f : 0f);
						}
						break;
					}
					case HardwareElementSourceTypeWithHat.Axis:
					{
						if (kIPZJVsYecSOzMhWNTbBOjVhMMel(customCalculationSourceData[k], out var num2))
						{
							customCalculation.AddData((num2 != 0f) ? 1f : 0f);
						}
						break;
					}
					}
				}
				if (!customCalculation.Process())
				{
					return false;
				}
				if (customCalculation.Result.type != TypeWrapper.DataType.Single)
				{
					return false;
				}
				return (float)customCalculation.Result != 0f;
			}
			return false;
		}

		private bool vuHniulLdsaDvqksYhTarJlKkgKk(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (XfDBWjoCosYvoTVfZsfDKsouIvPN.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				return false;
			}
			int num = 4500 * P_1;
			if (P_2 == HatType.EightWay && P_0 != num)
			{
				return false;
			}
			int num2;
			int num3;
			if (P_2 == HatType.EightWay)
			{
				num2 = 31500;
				num3 = 4500;
			}
			else
			{
				num2 = 27000;
				num3 = 9000;
			}
			if (P_1 == 0 && P_0 > num2)
			{
				P_0 -= 36000;
			}
			if (P_0 < num + num3 && P_0 > num - num3)
			{
				return true;
			}
			return false;
		}

		private float tElrmKwgAYEFMhVoMIMaiciRKQeZ(int P_0, AxisDirection P_1)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (P_1 == AxisDirection.Vertical)
			{
				if (P_0 > 27000 || P_0 < 9000)
				{
					return 1f;
				}
				if (P_0 < 27000 && P_0 > 9000)
				{
					return -1f;
				}
				return 0f;
			}
			if (P_0 > 0 && P_0 < 18000)
			{
				return 1f;
			}
			if (P_0 > 18000)
			{
				return -1f;
			}
			return 0f;
		}

		private bool AdpQhcEoBqCHpbAescIpbOEDDRmCA(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, bool[] P_1, out bool P_2)
		{
			P_2 = false;
			if (P_0.sourceType != 0)
			{
				return false;
			}
			int sourceButton = P_0.sourceButton;
			if (sourceButton < 0 || sourceButton >= xPHraTegAQkZKJrJSesorPOqjVNDA || sourceButton >= 128)
			{
				return false;
			}
			P_2 = P_1[sourceButton];
			return true;
		}

		private bool kIPZJVsYecSOzMhWNTbBOjVhMMel(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, out float P_1)
		{
			P_1 = 0f;
			if (P_0.sourceType != 1)
			{
				return false;
			}
			if (P_0.sourceAxis <= 0 || P_0.sourceAxis >= 32)
			{
				return false;
			}
			P_1 = SOQfxTJqohQJwVrKOjVmvpjpCLLjA((DirectInputAxis)P_0.sourceAxis);
			switch (P_0.sourceAxisRange)
			{
			case AxisRange.Negative:
				if (P_1 > 0f)
				{
					P_1 = 0f;
				}
				break;
			case AxisRange.Positive:
				if (P_1 < 0f)
				{
					P_1 = 0f;
				}
				break;
			}
			if (P_0.axisCalibrationType == AxisCalibrationType.Default)
			{
				P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, -1f, 1f, P_0.axisDeadZone, P_0.axisUpperDeadZone, P_0.invert, applySensitivity: false, AxisSensitivityType.Multiplier, 1f, null);
			}
			else if (P_0.axisCalibrationType == AxisCalibrationType.Custom)
			{
				P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, P_0.axisMin, P_0.axisMax, P_0.axisDeadZone, P_0.axisUpperDeadZone, P_0.invert, applySensitivity: false, AxisSensitivityType.Multiplier, 1f, null);
			}
			else if (P_0.axisCalibrationType == AxisCalibrationType.Uncalibrated && P_0.axisDeadZone > 0f && MathTools.Abs(P_1) <= P_0.axisDeadZone)
			{
				P_1 = 0f;
			}
			return true;
		}

		private ControlDeviceType DqiRTyRWABKBizBEnGPMiWzBktsC(ZSovmlhoZKTNRcDjddXShKrptrEEA P_0)
		{
			return P_0 switch
			{
				ZSovmlhoZKTNRcDjddXShKrptrEEA.Keyboard => ControlDeviceType.Keyboard, 
				ZSovmlhoZKTNRcDjddXShKrptrEEA.Joystick => ControlDeviceType.Joystick, 
				ZSovmlhoZKTNRcDjddXShKrptrEEA.Gamepad => ControlDeviceType.Gamepad, 
				ZSovmlhoZKTNRcDjddXShKrptrEEA.Mouse => ControlDeviceType.Mouse, 
				ZSovmlhoZKTNRcDjddXShKrptrEEA.Flight => ControlDeviceType.Flight, 
				ZSovmlhoZKTNRcDjddXShKrptrEEA.Driving => ControlDeviceType.Wheel, 
				_ => ControlDeviceType.Unknown, 
			};
		}

		private void aIYFEumZFvBpuUSrJCjJqWnKXpRD()
		{
			XfDBWjoCosYvoTVfZsfDKsouIvPN = EIyyOPTJSYGTXrOymTBxmWkZoEWC(hVogBWRzqttBpZdPVRbnpjNXwJJG());
			if (XfDBWjoCosYvoTVfZsfDKsouIvPN == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			ZgjWPEkPAbcGkqRqLWPXqJWPHeQX = XfDBWjoCosYvoTVfZsfDKsouIvPN.axisCount;
			sqiiNLTNLSgznBlKKlSuudwIOLqdA = XfDBWjoCosYvoTVfZsfDKsouIvPN.buttonCount;
		}

		private void GkMYvEvHsmnVPhgsViSFpWbExVnS()
		{
		}

		private string ZaKStsUgUHKtUiOaeqcjUpkslPOv()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}{4}", ReInput.currentPlatform.ToString(), InputSource.DirectInput, (mvMSNzRJmiwRoenbTArzzjFuKifE && !string.IsNullOrEmpty(XrYtFEBYJvRVGjJoLgKeQTOEhtZS)) ? XrYtFEBYJvRVGjJoLgKeQTOEhtZS : kdVHsgqAFwmFQXnhgRaVDELiKnzC, JdFBDPxbYWufPZDTuiqIfjBXdKCdA.ToString("X4"), new PidVid(XoGqGUJoMrNVRXlJrtRoQAmuEAFp).vendorId.ToString("X4")));
		}

		private void uyCvHYwqOiyRzwJnNnIikiMzgxJcA(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.DirectInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = DqiRTyRWABKBizBEnGPMiWzBktsC(ECbQVeJFuMsdgjquINtRyanKvbWb);
			P_0.hardwareIdentifier = ZaKStsUgUHKtUiOaeqcjUpkslPOv();
			P_0.hardwareAxisCount = xYtxjvGiDblMLazxSNoxuZeFGhdo;
			P_0.hardwareButtonCount = xPHraTegAQkZKJrJSesorPOqjVNDA;
			P_0.hardwareHatCount = oOgOpJMTHvLxBTmQYOBaWbPGVsrj;
			P_0.hw_productName = kdVHsgqAFwmFQXnhgRaVDELiKnzC;
			P_0.hw_deviceGuid = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
			P_0.hw_productId = JdFBDPxbYWufPZDTuiqIfjBXdKCdA;
			P_0.hw_pidVid = new PidVid(XoGqGUJoMrNVRXlJrtRoQAmuEAFp);
			P_0.hw_isBluetoothDevice = mvMSNzRJmiwRoenbTArzzjFuKifE;
			P_0.hw_bluetoothDeviceName = ((!string.IsNullOrEmpty(XrYtFEBYJvRVGjJoLgKeQTOEhtZS)) ? XrYtFEBYJvRVGjJoLgKeQTOEhtZS : string.Empty);
			P_0.definitionMatchTag = BVxCYjiutEJjufEgJmLVXSIICyDyB;
		}

		private void bAZiLoLtXbKxDnfWJTozHVTSeceY(BridgedController P_0)
		{
			uyCvHYwqOiyRzwJnNnIikiMzgxJcA(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = XfDBWjoCosYvoTVfZsfDKsouIvPN.ToGameHardwareControllerMap();
			P_0.instanceName = LyPjjoyYbFqZzaOyZYPALZWTCYiB;
			P_0.productName = kdVHsgqAFwmFQXnhgRaVDELiKnzC;
			P_0.isXInputDevice = BNOftdEcQnhgGcDfbZBdbKAlVXzDA;
			P_0.axisCount = ZgjWPEkPAbcGkqRqLWPXqJWPHeQX;
			P_0.buttonCount = sqiiNLTNLSgznBlKKlSuudwIOLqdA;
			P_0.unknownControllerHats = QuLbjVzTDLiCeQRjMaCRAWqykjwPA();
			P_0.controllerTypeGuid = gOjciFjQoNUisNojPkskSojSdMspA;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		private void jKZSuTXGfJjAfAhYNtViqOCtQoWvA()
		{
			for (int i = 0; i < sqiiNLTNLSgznBlKKlSuudwIOLqdA; i++)
			{
				jvFokQRqRrDIuDuiFKwDfnYYjpttA[i] = false;
			}
			for (int j = 0; j < ZgjWPEkPAbcGkqRqLWPXqJWPHeQX; j++)
			{
				EkcTmIfwJwBvpcRmnFYjImNdGQLN[j] = 0f;
			}
		}

		private UnknownControllerHat[] QuLbjVzTDLiCeQRjMaCRAWqykjwPA()
		{
			if (!eyCMcoLsgvgdRCDcjeBfdjHHePRp)
			{
				return null;
			}
			UnknownControllerHat[] array = new UnknownControllerHat[2];
			for (int i = 0; i < 2; i++)
			{
				int num = 128 + i * 8;
				UnknownControllerHat.HatButtons hatButtons = new UnknownControllerHat.HatButtons(new int[8]
				{
					num,
					num + 1,
					num + 2,
					num + 3,
					num + 4,
					num + 5,
					num + 6,
					num + 7
				});
				array[i] = new UnknownControllerHat(hatButtons);
			}
			return array;
		}

		public void TxOAEXFpROagqefiitDqiiVidAAMe()
		{
			fBeuROEBNstGFGqIFuvinfOOFZvDA(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void kwnupBXhLtyhpZTXZCdxceFREcnCA()
		{
			try
			{
				fBeuROEBNstGFGqIFuvinfOOFZvDA(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void fBeuROEBNstGFGqIFuvinfOOFZvDA(bool P_0)
		{
			if (!GguZprEGJwnDYlDjlYOkjraiIBjF)
			{
				if (P_0 && LEhKMDCzIjquVNmJvymqRHMMWifX != null)
				{
					LEhKMDCzIjquVNmJvymqRHMMWifX.Dispose();
				}
				GguZprEGJwnDYlDjlYOkjraiIBjF = true;
			}
		}

		public static int DTRunQGmGQuzYtENRhUbHfCjEahQ(sRWhguxFTduLiFMWjcVdhYcRFInQA P_0, sRWhguxFTduLiFMWjcVdhYcRFInQA P_1)
		{
			if (P_0.ESdOuOAgHyKOAleFOQgAfuSpsFlX < P_1.ESdOuOAgHyKOAleFOQgAfuSpsFlX)
			{
				return -1;
			}
			if (P_0.ESdOuOAgHyKOAleFOQgAfuSpsFlX > P_1.ESdOuOAgHyKOAleFOQgAfuSpsFlX)
			{
				return 1;
			}
			return 0;
		}

		public static int MaHNPbukMvhNsjiKXynApvxdIHwb(sRWhguxFTduLiFMWjcVdhYcRFInQA P_0, sRWhguxFTduLiFMWjcVdhYcRFInQA P_1)
		{
			if (P_0.NTPQNZKSPdJyeDkKhWBRWCaCeKUBA < P_1.NTPQNZKSPdJyeDkKhWBRWCaCeKUBA)
			{
				return -1;
			}
			if (P_0.NTPQNZKSPdJyeDkKhWBRWCaCeKUBA > P_1.NTPQNZKSPdJyeDkKhWBRWCaCeKUBA)
			{
				return 1;
			}
			return 0;
		}
	}

	private class GoJaFByXFoZTGNocjTiOVrXyHFHL : IDisposable
	{
		public class CGPImzcAXEHQVVlIqOBekWwSznCF
		{
			public float EYXAGlKJOxVBnSgbSNRFFFtODGReA;

			public float xLXTJNZjUUvVMkIpmQTKFPHiiDam;

			public float mKIjfrzYxARcHDfviKpXMCAgKFQH;

			public float GLNvQzcYCCtsoiyIDrAGYBJHgTgQ;

			public float nlYFoBiwRDwHMCbauUmDONkqJRwN;

			public float WqLMZUjXRMQQjhzNubXSxbEuwvyo;

			public float[] tAQemkVJOIpxHmzuMNgzSPHJCZph;

			public readonly int[] yuPUmDiBSRBZcVVgoZXjtNoPngXq;

			public readonly bool[] YOxtstyOnrItMiAimtKBQXSsuCvY;

			public float fIbpvlrFZsJzubdDKbRhECHvlUbT;

			public float MkVEHeTRmKONUrrFjwKlNPHSjmBl;

			public float WQPjanQSzyFBmlffzIzXIipTtUKM;

			public float oUmeZHBNOfGpdcxwKLRNqPuBXylu;

			public float YqigXbCMSOMBkiDzVBPREoXJVPCQB;

			public float bIbnzgqMrMsNInYvARTioDTGlxTj;

			public readonly float[] sKRfQBapODETsEDlHvaIVLViZLeiA;

			public float LaTsLRyNLEHPPALLRBJugqqdIuQJc;

			public float PkBErREOzjaWNgRtigclesqbGzhTd;

			public float yudiXScBKRTPxPSeUddTbgtwDYCi;

			public float MQyKIuLXSyckSQexbYBHbGVFtisF;

			public float ucsXMcYvGpSVQRkjgTrjfSoRjDQh;

			public float AOedkHIgsYKyRzbYTMAkHjazHJlWA;

			public readonly float[] zXHPdFqgNhGDRxiuElpcvcQMoYLr;

			public float lwIhyIKIubotrdDQRBPUZMEqSEAM;

			public float njXXOIpVPErutkPXErmMvwzVNItA;

			public float MqRIvbTOxVyjBeBWwBtVcTVVTOOk;

			public float uyhPAmImBFvTBgOmyPCSskRcqeuP;

			public float ymsgIvGpwCSOTbDzqSPnYonpUHfg;

			public float UZhingMzjTlEokbvGkdxgRwfHuWJ;

			public readonly float[] HPcbZHhnsANhPHiqioWvEDWmMHfS;

			public CGPImzcAXEHQVVlIqOBekWwSznCF()
			{
				tAQemkVJOIpxHmzuMNgzSPHJCZph = new float[2];
				yuPUmDiBSRBZcVVgoZXjtNoPngXq = new int[4];
				YOxtstyOnrItMiAimtKBQXSsuCvY = new bool[128];
				sKRfQBapODETsEDlHvaIVLViZLeiA = new float[2];
				zXHPdFqgNhGDRxiuElpcvcQMoYLr = new float[2];
				HPcbZHhnsANhPHiqioWvEDWmMHfS = new float[2];
			}

			public void EEMABzKfLdrTQZzLTgTZpEvczYqj()
			{
				EYXAGlKJOxVBnSgbSNRFFFtODGReA = 0f;
				xLXTJNZjUUvVMkIpmQTKFPHiiDam = 0f;
				mKIjfrzYxARcHDfviKpXMCAgKFQH = 0f;
				GLNvQzcYCCtsoiyIDrAGYBJHgTgQ = 0f;
				nlYFoBiwRDwHMCbauUmDONkqJRwN = 0f;
				WqLMZUjXRMQQjhzNubXSxbEuwvyo = 0f;
				for (int i = 0; i < tAQemkVJOIpxHmzuMNgzSPHJCZph.Length; i++)
				{
					tAQemkVJOIpxHmzuMNgzSPHJCZph[i] = 0f;
				}
				for (int j = 0; j < yuPUmDiBSRBZcVVgoZXjtNoPngXq.Length; j++)
				{
					yuPUmDiBSRBZcVVgoZXjtNoPngXq[j] = 0;
				}
				for (int k = 0; k < YOxtstyOnrItMiAimtKBQXSsuCvY.Length; k++)
				{
					YOxtstyOnrItMiAimtKBQXSsuCvY[k] = false;
				}
				fIbpvlrFZsJzubdDKbRhECHvlUbT = 0f;
				MkVEHeTRmKONUrrFjwKlNPHSjmBl = 0f;
				WQPjanQSzyFBmlffzIzXIipTtUKM = 0f;
				oUmeZHBNOfGpdcxwKLRNqPuBXylu = 0f;
				YqigXbCMSOMBkiDzVBPREoXJVPCQB = 0f;
				bIbnzgqMrMsNInYvARTioDTGlxTj = 0f;
				for (int l = 0; l < sKRfQBapODETsEDlHvaIVLViZLeiA.Length; l++)
				{
					sKRfQBapODETsEDlHvaIVLViZLeiA[l] = 0f;
				}
				LaTsLRyNLEHPPALLRBJugqqdIuQJc = 0f;
				PkBErREOzjaWNgRtigclesqbGzhTd = 0f;
				yudiXScBKRTPxPSeUddTbgtwDYCi = 0f;
				MQyKIuLXSyckSQexbYBHbGVFtisF = 0f;
				ucsXMcYvGpSVQRkjgTrjfSoRjDQh = 0f;
				AOedkHIgsYKyRzbYTMAkHjazHJlWA = 0f;
				for (int m = 0; m < zXHPdFqgNhGDRxiuElpcvcQMoYLr.Length; m++)
				{
					zXHPdFqgNhGDRxiuElpcvcQMoYLr[m] = 0f;
				}
				lwIhyIKIubotrdDQRBPUZMEqSEAM = 0f;
				njXXOIpVPErutkPXErmMvwzVNItA = 0f;
				MqRIvbTOxVyjBeBWwBtVcTVVTOOk = 0f;
				uyhPAmImBFvTBgOmyPCSskRcqeuP = 0f;
				ymsgIvGpwCSOTbDzqSPnYonpUHfg = 0f;
				UZhingMzjTlEokbvGkdxgRwfHuWJ = 0f;
				for (int n = 0; n < HPcbZHhnsANhPHiqioWvEDWmMHfS.Length; n++)
				{
					HPcbZHhnsANhPHiqioWvEDWmMHfS[n] = 0f;
				}
			}

			public void ewpujMNnuRqEADAeKMbLwxDgfEMI(CGPImzcAXEHQVVlIqOBekWwSznCF P_0)
			{
				EYXAGlKJOxVBnSgbSNRFFFtODGReA = P_0.EYXAGlKJOxVBnSgbSNRFFFtODGReA;
				xLXTJNZjUUvVMkIpmQTKFPHiiDam = P_0.xLXTJNZjUUvVMkIpmQTKFPHiiDam;
				mKIjfrzYxARcHDfviKpXMCAgKFQH = P_0.mKIjfrzYxARcHDfviKpXMCAgKFQH;
				GLNvQzcYCCtsoiyIDrAGYBJHgTgQ = P_0.GLNvQzcYCCtsoiyIDrAGYBJHgTgQ;
				nlYFoBiwRDwHMCbauUmDONkqJRwN = P_0.nlYFoBiwRDwHMCbauUmDONkqJRwN;
				WqLMZUjXRMQQjhzNubXSxbEuwvyo = P_0.WqLMZUjXRMQQjhzNubXSxbEuwvyo;
				for (int i = 0; i < tAQemkVJOIpxHmzuMNgzSPHJCZph.Length; i++)
				{
					tAQemkVJOIpxHmzuMNgzSPHJCZph[i] = P_0.tAQemkVJOIpxHmzuMNgzSPHJCZph[i];
				}
				for (int j = 0; j < yuPUmDiBSRBZcVVgoZXjtNoPngXq.Length; j++)
				{
					yuPUmDiBSRBZcVVgoZXjtNoPngXq[j] = P_0.yuPUmDiBSRBZcVVgoZXjtNoPngXq[j];
				}
				for (int k = 0; k < YOxtstyOnrItMiAimtKBQXSsuCvY.Length; k++)
				{
					YOxtstyOnrItMiAimtKBQXSsuCvY[k] = P_0.YOxtstyOnrItMiAimtKBQXSsuCvY[k];
				}
				fIbpvlrFZsJzubdDKbRhECHvlUbT = P_0.fIbpvlrFZsJzubdDKbRhECHvlUbT;
				MkVEHeTRmKONUrrFjwKlNPHSjmBl = P_0.MkVEHeTRmKONUrrFjwKlNPHSjmBl;
				WQPjanQSzyFBmlffzIzXIipTtUKM = P_0.WQPjanQSzyFBmlffzIzXIipTtUKM;
				oUmeZHBNOfGpdcxwKLRNqPuBXylu = P_0.oUmeZHBNOfGpdcxwKLRNqPuBXylu;
				YqigXbCMSOMBkiDzVBPREoXJVPCQB = P_0.YqigXbCMSOMBkiDzVBPREoXJVPCQB;
				bIbnzgqMrMsNInYvARTioDTGlxTj = P_0.bIbnzgqMrMsNInYvARTioDTGlxTj;
				for (int l = 0; l < sKRfQBapODETsEDlHvaIVLViZLeiA.Length; l++)
				{
					sKRfQBapODETsEDlHvaIVLViZLeiA[l] = P_0.sKRfQBapODETsEDlHvaIVLViZLeiA[l];
				}
				LaTsLRyNLEHPPALLRBJugqqdIuQJc = P_0.LaTsLRyNLEHPPALLRBJugqqdIuQJc;
				PkBErREOzjaWNgRtigclesqbGzhTd = P_0.PkBErREOzjaWNgRtigclesqbGzhTd;
				yudiXScBKRTPxPSeUddTbgtwDYCi = P_0.yudiXScBKRTPxPSeUddTbgtwDYCi;
				MQyKIuLXSyckSQexbYBHbGVFtisF = P_0.MQyKIuLXSyckSQexbYBHbGVFtisF;
				ucsXMcYvGpSVQRkjgTrjfSoRjDQh = P_0.ucsXMcYvGpSVQRkjgTrjfSoRjDQh;
				AOedkHIgsYKyRzbYTMAkHjazHJlWA = P_0.AOedkHIgsYKyRzbYTMAkHjazHJlWA;
				for (int m = 0; m < zXHPdFqgNhGDRxiuElpcvcQMoYLr.Length; m++)
				{
					zXHPdFqgNhGDRxiuElpcvcQMoYLr[m] = P_0.zXHPdFqgNhGDRxiuElpcvcQMoYLr[m];
				}
				lwIhyIKIubotrdDQRBPUZMEqSEAM = P_0.lwIhyIKIubotrdDQRBPUZMEqSEAM;
				njXXOIpVPErutkPXErmMvwzVNItA = P_0.njXXOIpVPErutkPXErmMvwzVNItA;
				MqRIvbTOxVyjBeBWwBtVcTVVTOOk = P_0.MqRIvbTOxVyjBeBWwBtVcTVVTOOk;
				uyhPAmImBFvTBgOmyPCSskRcqeuP = P_0.uyhPAmImBFvTBgOmyPCSskRcqeuP;
				ymsgIvGpwCSOTbDzqSPnYonpUHfg = P_0.ymsgIvGpwCSOTbDzqSPnYonpUHfg;
				UZhingMzjTlEokbvGkdxgRwfHuWJ = P_0.UZhingMzjTlEokbvGkdxgRwfHuWJ;
				for (int n = 0; n < HPcbZHhnsANhPHiqioWvEDWmMHfS.Length; n++)
				{
					HPcbZHhnsANhPHiqioWvEDWmMHfS[n] = P_0.HPcbZHhnsANhPHiqioWvEDWmMHfS[n];
				}
			}

			public unsafe void uSqauOsACflayMBWaLMInyukctBU(ref LowLevelInputEvent P_0)
			{
				for (int i = 0; i < 4; i++)
				{
					int num = *(int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_buttonsStart + i * 4);
					for (int j = 0; j < 32; j++)
					{
						YOxtstyOnrItMiAimtKBQXSsuCvY[i * 32 + j] = (num & (1 << j)) != 0;
					}
				}
				float* ptr = (float*)((byte*)(void*)P_0._buffer + P_0.byteIndex_axesStart);
				for (int k = 0; k < 2; k++)
				{
					zXHPdFqgNhGDRxiuElpcvcQMoYLr[k] = *ptr;
					ptr++;
				}
				LaTsLRyNLEHPPALLRBJugqqdIuQJc = *ptr;
				ptr++;
				PkBErREOzjaWNgRtigclesqbGzhTd = *ptr;
				ptr++;
				yudiXScBKRTPxPSeUddTbgtwDYCi = *ptr;
				ptr++;
				MQyKIuLXSyckSQexbYBHbGVFtisF = *ptr;
				ptr++;
				ucsXMcYvGpSVQRkjgTrjfSoRjDQh = *ptr;
				ptr++;
				AOedkHIgsYKyRzbYTMAkHjazHJlWA = *ptr;
				ptr++;
				oUmeZHBNOfGpdcxwKLRNqPuBXylu = *ptr;
				ptr++;
				YqigXbCMSOMBkiDzVBPREoXJVPCQB = *ptr;
				ptr++;
				bIbnzgqMrMsNInYvARTioDTGlxTj = *ptr;
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					HPcbZHhnsANhPHiqioWvEDWmMHfS[l] = *ptr;
					ptr++;
				}
				lwIhyIKIubotrdDQRBPUZMEqSEAM = *ptr;
				ptr++;
				njXXOIpVPErutkPXErmMvwzVNItA = *ptr;
				ptr++;
				MqRIvbTOxVyjBeBWwBtVcTVVTOOk = *ptr;
				ptr++;
				GLNvQzcYCCtsoiyIDrAGYBJHgTgQ = *ptr;
				ptr++;
				nlYFoBiwRDwHMCbauUmDONkqJRwN = *ptr;
				ptr++;
				WqLMZUjXRMQQjhzNubXSxbEuwvyo = *ptr;
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					tAQemkVJOIpxHmzuMNgzSPHJCZph[m] = *ptr;
					ptr++;
				}
				uyhPAmImBFvTBgOmyPCSskRcqeuP = *ptr;
				ptr++;
				ymsgIvGpwCSOTbDzqSPnYonpUHfg = *ptr;
				ptr++;
				UZhingMzjTlEokbvGkdxgRwfHuWJ = *ptr;
				ptr++;
				for (int n = 0; n < 2; n++)
				{
					sKRfQBapODETsEDlHvaIVLViZLeiA[n] = *ptr;
					ptr++;
				}
				fIbpvlrFZsJzubdDKbRhECHvlUbT = *ptr;
				ptr++;
				MkVEHeTRmKONUrrFjwKlNPHSjmBl = *ptr;
				ptr++;
				WQPjanQSzyFBmlffzIzXIipTtUKM = *ptr;
				ptr++;
				EYXAGlKJOxVBnSgbSNRFFFtODGReA = *ptr;
				ptr++;
				xLXTJNZjUUvVMkIpmQTKFPHiiDam = *ptr;
				ptr++;
				mKIjfrzYxARcHDfviKpXMCAgKFQH = *ptr;
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_hatsStart);
				for (int num2 = 0; num2 < 2; num2++)
				{
					yuPUmDiBSRBZcVVgoZXjtNoPngXq[num2] = *ptr2;
					ptr2++;
				}
			}

			public unsafe static void wMhlrAZUfmDAvPiVAkSywZjOBdbB(uQPOritqCmojDTcNoDHVMaAqBRZQ P_0, double P_1, LowLevelInputEvent P_2)
			{
				int[] array = P_0.oFDYAZcHldFNjIFjijejzJqPrzCPA;
				int[] array2 = P_0.JUerymjoyAwhqxKjQefCqXjcGiQl;
				int[] array3 = P_0.YQEEstMEFhgtAgwkQDgoOToGnVyE;
				int[] array4 = P_0.qZpwwOtRpwXllTHZcGrBCdcEaSqHA;
				int[] array5 = P_0.poZcfEtGCZChDNVxmfNEHOoNVYWQA;
				*(double*)((byte*)(void*)P_2._buffer + 4) = P_1;
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				for (int i = 0; i < 128; i++)
				{
					if (P_0.CdhkqlrkrWueANTWqCEaOOzCmWKF[i])
					{
						num |= 1 << num3;
					}
					num3++;
					if (num3 == 32)
					{
						*(int*)((byte*)(void*)P_2._buffer + P_2.byteIndex_buttonsStart + num2 * 4) = num;
						num3 = 0;
						num = 0;
						num2++;
					}
				}
				float* ptr = (float*)((byte*)(void*)P_2._buffer + P_2.byteIndex_axesStart);
				for (int j = 0; j < 2; j++)
				{
					*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(array2[j]);
					ptr++;
				}
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.lRTpTXAnSmiCSxhLaXMDIbraayrq);
				ptr++;
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.mHSMliolUBWrVEqesbllbUSAOJge);
				ptr++;
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.waJZKjyrpoGHxCxwMXyznRMaHbND);
				ptr++;
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.vhdwZkNCVwNWJfzflFzWMCcaAIru);
				ptr++;
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.mbGPdmpAqQHhmnCqGgEDYeKaWvXy);
				ptr++;
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.uUmGDvxSgKziyzRGNQohUtVdRFJF);
				ptr++;
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.jArYLmMiCXiGYkeRZdLrZuoEcOJLA);
				ptr++;
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.ugwxtaatqqOcJYODjjOqhctNmwQFb);
				ptr++;
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.vBjqnlSkdGBAonhKRbWAGfEvMpGQA);
				ptr++;
				for (int k = 0; k < 2; k++)
				{
					*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(array3[k]);
					ptr++;
				}
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.RCFpQWVhDhDqNLfwoQctigBQBHRE);
				ptr++;
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.xhSmsazaJqgphccFefmmxllOarGR);
				ptr++;
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.PaeJGnumCcUJNYcVTpTnHDjhHzbH);
				ptr++;
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.CdejOEsUiDlvdAxJTEPADcPFlAYd);
				ptr++;
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.QxrUYIkNCeyPRxhXPyDlavhweHrJ);
				ptr++;
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.TZNIgSgUITkRGNpeGEVNgBaSLNuS);
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(array4[l]);
					ptr++;
				}
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.mxhYyxVfoYdSQzjfNFYCBdwDEFae);
				ptr++;
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.HlRvwjKSOtpzZJRsqbAowzBPHgTW);
				ptr++;
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.RVZZhhhVtzQEXDPVpGLFaALTklPK);
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(array5[m]);
					ptr++;
				}
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.HDYLFfrHEfqhlmPSMlHNSykLuBuW);
				ptr++;
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.fXaahwNwEZTqPHoGXTXUhTbdfwjb);
				ptr++;
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.sGsrexbBEiqNKrKODQoOnllciJAq);
				ptr++;
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.obTmgmDpublknGtnIrTsamUKkoKj);
				ptr++;
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.ZvUFnBtLzCKMoXfPmGkXgSEulsBY);
				ptr++;
				*ptr = VKbgkWNaPiLLLMFtymBoneCOcslJA(P_0.IpCfPtGJfFKLqRFFZlZPCnKIPLCiA);
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_2._buffer + P_2.byteIndex_hatsStart);
				for (int n = 0; n < 2; n++)
				{
					*ptr2 = array[n];
					ptr2++;
				}
			}
		}

		private const int jnoGlGOhSCUBNMTmRiEbKdyECaG = 2;

		private const int CpvBeWciabOEkopdAKXkCKrWrvcVA = 2;

		private const int MDWNpfkzBYgxlvubZSMQFJtnXzKp = 128;

		private const int mXBeQPHxppwdTWileMfRZZiVkGgi = 32;

		private const int DbigZbCeXhWUkZzvCaYDawkecMiM = 0;

		private const int SLjqVJkUNJhTuNlHbOaKwUkzSKuv = 264;

		private const int eYEEvwzzKMHSBsYgpAYQSffCYyFB = 272;

		private readonly int dgjqmqMhgQMqjBDMYJqaTBoBIgXeA;

		private readonly ButtonLoopSet nLBDIYLQQMxtnZjzOzlKBagfnoAu;

		private readonly DualThreadLowLevelInputEventQueue XszVSnjAorDZCAzdrGDIpZqJumGcA;

		private fCItkoTJoexslPjmCpAXmJzbNmWS ypFNgxuRZhlKqoTEqlrmudtyxCqj;

		private readonly uQPOritqCmojDTcNoDHVMaAqBRZQ bPmBBmTMTttZkKkKkgzvAXaXhAqv;

		private readonly uQPOritqCmojDTcNoDHVMaAqBRZQ NocBdJfxDOMhUayoCqGgPJLklALMA;

		private readonly object udSJYuUulqfEGHKrTsjkDMInhEmT;

		private bool OfykCYKCUggCaLpklXMLNXQrsYXb;

		public readonly IJySsOxfJZoqgcJpcZGpRDTPCFrG owFVkJQkkPDmjBRaHbMOjwVbxEvyb;

		private readonly CGPImzcAXEHQVVlIqOBekWwSznCF MCRJdrSmYgeUXdWPWBOcqSwIVMG;

		private bool lahXNRlhRtPqJmJKSmUYLOZRpWyE;

		public bool[] flVRgRfgUSnpujKJECfCfnBIxjDJ => nLBDIYLQQMxtnZjzOzlKBagfnoAu.Current.effectiveValue;

		public CGPImzcAXEHQVVlIqOBekWwSznCF SyMGIWmCpxWposkWWaiepokrrZlm => MCRJdrSmYgeUXdWPWBOcqSwIVMG;

		public GoJaFByXFoZTGNocjTiOVrXyHFHL(IJySsOxfJZoqgcJpcZGpRDTPCFrG P_0, UpdateLoopSetting P_1)
		{
			owFVkJQkkPDmjBRaHbMOjwVbxEvyb = P_0;
			dgjqmqMhgQMqjBDMYJqaTBoBIgXeA = P_0.rhVSTskoAdAkZabCrrGFhBOPTGZGA.qSvsSCNmzWuFgnRvwrEmcRuuvYVj;
			nLBDIYLQQMxtnZjzOzlKBagfnoAu = new ButtonLoopSet(P_1, dgjqmqMhgQMqjBDMYJqaTBoBIgXeA);
			XszVSnjAorDZCAzdrGDIpZqJumGcA = new DualThreadLowLevelInputEventQueue((int)((float)VpydvvgAmkTUcjFPOCjeqVyqydEE.FouUkwuOnOhmqjkVSnyhOgtAiHCbA * 0.25f), 128, 32, 2);
			MCRJdrSmYgeUXdWPWBOcqSwIVMG = new CGPImzcAXEHQVVlIqOBekWwSznCF();
			bPmBBmTMTttZkKkKkgzvAXaXhAqv = new uQPOritqCmojDTcNoDHVMaAqBRZQ();
			NocBdJfxDOMhUayoCqGgPJLklALMA = new uQPOritqCmojDTcNoDHVMaAqBRZQ();
			udSJYuUulqfEGHKrTsjkDMInhEmT = new object();
			if (VpydvvgAmkTUcjFPOCjeqVyqydEE.hnQVuLpGsuJSzHbTZzTrIVUjPmfM != null)
			{
				VpydvvgAmkTUcjFPOCjeqVyqydEE.hnQVuLpGsuJSzHbTZzTrIVUjPmfM.ThreadUpdateEvent += cQvMNLNVPpFyyDaKBhluOafLiRTKA;
			}
		}

		public void PSXQSsxFGdFIgAFvgXgBOOPVquuI()
		{
			nLBDIYLQQMxtnZjzOzlKBagfnoAu.SetUpdateLoop(ReInput.currentUpdateLoop);
			FFueovkOpnrziHmTLeQIGQuWpWJk();
		}

		public void ntbhBJevgmYBQjIRyOSNYUSEIYSK()
		{
			nLBDIYLQQMxtnZjzOzlKBagfnoAu.Current.ClearWasTrueThisFrame();
		}

		public void wSGnpDrtAPRHWexmkGiofroVzojF()
		{
			kPvXpgnkbdBNGcasKDWUHspNuQPOA();
			OfykCYKCUggCaLpklXMLNXQrsYXb = true;
		}

		public void DgSkkDGCHeePhDeClLphjkNFqDLZ()
		{
			OfykCYKCUggCaLpklXMLNXQrsYXb = false;
			kPvXpgnkbdBNGcasKDWUHspNuQPOA();
		}

		public void sZMeMoeguLEVduAVERYlGGUGmECRA(GoJaFByXFoZTGNocjTiOVrXyHFHL P_0)
		{
			if (P_0 == null || P_0 == this || P_0.dgjqmqMhgQMqjBDMYJqaTBoBIgXeA != dgjqmqMhgQMqjBDMYJqaTBoBIgXeA)
			{
				return;
			}
			_ = ReInput.realTime;
			lock (udSJYuUulqfEGHKrTsjkDMInhEmT)
			{
				lock (P_0.udSJYuUulqfEGHKrTsjkDMInhEmT)
				{
					nLBDIYLQQMxtnZjzOzlKBagfnoAu.Import(P_0.nLBDIYLQQMxtnZjzOzlKBagfnoAu);
					MCRJdrSmYgeUXdWPWBOcqSwIVMG.ewpujMNnuRqEADAeKMbLwxDgfEMI(P_0.MCRJdrSmYgeUXdWPWBOcqSwIVMG);
					bPmBBmTMTttZkKkKkgzvAXaXhAqv.AtPORbWyPEnMoScDgMQyDGKcLaiv(P_0.bPmBBmTMTttZkKkKkgzvAXaXhAqv);
					NocBdJfxDOMhUayoCqGgPJLklALMA.AtPORbWyPEnMoScDgMQyDGKcLaiv(P_0.NocBdJfxDOMhUayoCqGgPJLklALMA);
					if (XszVSnjAorDZCAzdrGDIpZqJumGcA.capacityBytes == P_0.XszVSnjAorDZCAzdrGDIpZqJumGcA.capacityBytes)
					{
						XszVSnjAorDZCAzdrGDIpZqJumGcA.ImportAll(P_0.XszVSnjAorDZCAzdrGDIpZqJumGcA);
					}
					ypFNgxuRZhlKqoTEqlrmudtyxCqj = fCItkoTJoexslPjmCpAXmJzbNmWS.rvXjGKPJwQFXFHBpDQDgOUNcqNRzA(P_0.ypFNgxuRZhlKqoTEqlrmudtyxCqj, bPmBBmTMTttZkKkKkgzvAXaXhAqv);
					OfykCYKCUggCaLpklXMLNXQrsYXb = P_0.OfykCYKCUggCaLpklXMLNXQrsYXb;
				}
			}
		}

		public void BLMdMbUhiaIuTviYKGKwaHDJolJf(int P_0, int P_1, int P_2, float P_3)
		{
			lock (udSJYuUulqfEGHKrTsjkDMInhEmT)
			{
				ypFNgxuRZhlKqoTEqlrmudtyxCqj = new fCItkoTJoexslPjmCpAXmJzbNmWS(bPmBBmTMTttZkKkKkgzvAXaXhAqv, P_0, P_1, P_2, P_3);
			}
		}

		private void cQvMNLNVPpFyyDaKBhluOafLiRTKA()
		{
			if (!OfykCYKCUggCaLpklXMLNXQrsYXb)
			{
				return;
			}
			double realTime;
			try
			{
				owFVkJQkkPDmjBRaHbMOjwVbxEvyb.EkjkLOUOkrFGGeEyDmrJbYLVPcAKA(bPmBBmTMTttZkKkKkgzvAXaXhAqv);
				realTime = ReInput.realTime;
			}
			catch
			{
				return;
			}
			lock (udSJYuUulqfEGHKrTsjkDMInhEmT)
			{
				if (ypFNgxuRZhlKqoTEqlrmudtyxCqj != null)
				{
					ypFNgxuRZhlKqoTEqlrmudtyxCqj.wUjEwwPFUuQfdMbVmJmxcrwYOrye(realTime);
				}
				if (!bPmBBmTMTttZkKkKkgzvAXaXhAqv.iGvonpaToAwRkEoRmYLXBIRRdMOO(NocBdJfxDOMhUayoCqGgPJLklALMA))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = XszVSnjAorDZCAzdrGDIpZqJumGcA.T_CreateEvent())
					{
						CGPImzcAXEHQVVlIqOBekWwSznCF.wMhlrAZUfmDAvPiVAkSywZjOBdbB(bPmBBmTMTttZkKkKkgzvAXaXhAqv, realTime, newEventWrapper.Event);
					}
					NocBdJfxDOMhUayoCqGgPJLklALMA.AtPORbWyPEnMoScDgMQyDGKcLaiv(bPmBBmTMTttZkKkKkgzvAXaXhAqv);
				}
			}
		}

		private void FFueovkOpnrziHmTLeQIGQuWpWJk()
		{
			while (XszVSnjAorDZCAzdrGDIpZqJumGcA.ProcessNewEvents())
			{
				MCRJdrSmYgeUXdWPWBOcqSwIVMG.uSqauOsACflayMBWaLMInyukctBU(ref XszVSnjAorDZCAzdrGDIpZqJumGcA.currentEvent);
				for (int i = 0; i < dgjqmqMhgQMqjBDMYJqaTBoBIgXeA; i++)
				{
					nLBDIYLQQMxtnZjzOzlKBagfnoAu.SetValue(i, MCRJdrSmYgeUXdWPWBOcqSwIVMG.YOxtstyOnrItMiAimtKBQXSsuCvY[i], XszVSnjAorDZCAzdrGDIpZqJumGcA.currentEvent.GetTimestamp());
				}
			}
		}

		private void kPvXpgnkbdBNGcasKDWUHspNuQPOA()
		{
			MCRJdrSmYgeUXdWPWBOcqSwIVMG.EEMABzKfLdrTQZzLTgTZpEvczYqj();
			lock (udSJYuUulqfEGHKrTsjkDMInhEmT)
			{
				bPmBBmTMTttZkKkKkgzvAXaXhAqv.LflKPUrcNWQEFBLLULgQamNgfFDEA();
				NocBdJfxDOMhUayoCqGgPJLklALMA.LflKPUrcNWQEFBLLULgQamNgfFDEA();
				XszVSnjAorDZCAzdrGDIpZqJumGcA.Clear();
			}
			nLBDIYLQQMxtnZjzOzlKBagfnoAu.Clear();
		}

		public void Dispose()
		{
			dhgbOSeDxRetzLMLRYpghygdLrxB(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void iYpczEBqqjPfZAtndFEmyrFuNFmjB()
		{
			try
			{
				dhgbOSeDxRetzLMLRYpghygdLrxB(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void dhgbOSeDxRetzLMLRYpghygdLrxB(bool P_0)
		{
			if (!lahXNRlhRtPqJmJKSmUYLOZRpWyE)
			{
				if (P_0)
				{
					DgSkkDGCHeePhDeClLphjkNFqDLZ();
					XszVSnjAorDZCAzdrGDIpZqJumGcA.Dispose();
				}
				if (VpydvvgAmkTUcjFPOCjeqVyqydEE.hnQVuLpGsuJSzHbTZzTrIVUjPmfM != null)
				{
					VpydvvgAmkTUcjFPOCjeqVyqydEE.hnQVuLpGsuJSzHbTZzTrIVUjPmfM.ThreadUpdateEvent -= cQvMNLNVPpFyyDaKBhluOafLiRTKA;
				}
				lahXNRlhRtPqJmJKSmUYLOZRpWyE = true;
			}
		}

		private static float VKbgkWNaPiLLLMFtymBoneCOcslJA(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}
	}

	private class fCItkoTJoexslPjmCpAXmJzbNmWS
	{
		private uQPOritqCmojDTcNoDHVMaAqBRZQ pMslGiycUnXlzlRELNKXvqFUxujh;

		private WmtjalqGZwmczfxxWtyGNCbHNzLv nScNMcoHjBCdaODPtiPzXtOpesPA;

		private int iYBohnuCTDEnnAdcHhybqJuqCPlr;

		private int oHKytibJAuGeTQVnJKKaDgkPxEum;

		private int fcCcxlcBKtCDYjTCKHBDdPyPFEahb;

		private float NOvtUjRmHGClvbQKtnLvjoWiNLKEc;

		public uQPOritqCmojDTcNoDHVMaAqBRZQ TXeqQkjVzMAfEBZqrRsGYQuGtttm => pMslGiycUnXlzlRELNKXvqFUxujh;

		public static fCItkoTJoexslPjmCpAXmJzbNmWS rvXjGKPJwQFXFHBpDQDgOUNcqNRzA(fCItkoTJoexslPjmCpAXmJzbNmWS P_0, uQPOritqCmojDTcNoDHVMaAqBRZQ P_1)
		{
			if (P_0 == null || P_1 == null)
			{
				return null;
			}
			return new fCItkoTJoexslPjmCpAXmJzbNmWS(P_0, P_1);
		}

		public fCItkoTJoexslPjmCpAXmJzbNmWS(uQPOritqCmojDTcNoDHVMaAqBRZQ P_0, int P_1, int P_2, int P_3, float P_4)
			: this(P_1, P_2, P_3, P_4)
		{
			nScNMcoHjBCdaODPtiPzXtOpesPA = new WmtjalqGZwmczfxxWtyGNCbHNzLv(P_0);
			pMslGiycUnXlzlRELNKXvqFUxujh = new uQPOritqCmojDTcNoDHVMaAqBRZQ();
		}

		private fCItkoTJoexslPjmCpAXmJzbNmWS(fCItkoTJoexslPjmCpAXmJzbNmWS P_0, uQPOritqCmojDTcNoDHVMaAqBRZQ P_1)
			: this(P_1, P_0.iYBohnuCTDEnnAdcHhybqJuqCPlr, P_0.oHKytibJAuGeTQVnJKKaDgkPxEum, P_0.fcCcxlcBKtCDYjTCKHBDdPyPFEahb, P_0.NOvtUjRmHGClvbQKtnLvjoWiNLKEc)
		{
			yfnGTQTDyDBLubMjUITLbRzXJBJk(P_0);
		}

		private fCItkoTJoexslPjmCpAXmJzbNmWS(int P_0, int P_1, int P_2, float P_3)
		{
			iYBohnuCTDEnnAdcHhybqJuqCPlr = P_0;
			oHKytibJAuGeTQVnJKKaDgkPxEum = P_1;
			fcCcxlcBKtCDYjTCKHBDdPyPFEahb = P_2;
			NOvtUjRmHGClvbQKtnLvjoWiNLKEc = P_3;
		}

		public void wUjEwwPFUuQfdMbVmJmxcrwYOrye(double P_0)
		{
			nScNMcoHjBCdaODPtiPzXtOpesPA.mcIYxbvvfNZGOWrXfNRWCLZQiudb(P_0);
			if (!nScNMcoHjBCdaODPtiPzXtOpesPA.cuCSNUXgnysvJTmQPEDsAxAInaLgA)
			{
				if (P_0 >= nScNMcoHjBCdaODPtiPzXtOpesPA.bjHDrjTOwqsIOeHnfuDbjSaDExLFA + (double)NOvtUjRmHGClvbQKtnLvjoWiNLKEc)
				{
					pMslGiycUnXlzlRELNKXvqFUxujh.LflKPUrcNWQEFBLLULgQamNgfFDEA();
				}
				return;
			}
			uQPOritqCmojDTcNoDHVMaAqBRZQ uQPOritqCmojDTcNoDHVMaAqBRZQ2 = nScNMcoHjBCdaODPtiPzXtOpesPA.swxrNCkhokkLVZXQPRsTYPpKKEqA;
			uQPOritqCmojDTcNoDHVMaAqBRZQ uQPOritqCmojDTcNoDHVMaAqBRZQ3 = nScNMcoHjBCdaODPtiPzXtOpesPA.PaMonfqwyfVsgTiRVFIjnPeULhgb;
			pMslGiycUnXlzlRELNKXvqFUxujh.obTmgmDpublknGtnIrTsamUKkoKj = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.obTmgmDpublknGtnIrTsamUKkoKj);
			pMslGiycUnXlzlRELNKXvqFUxujh.ZvUFnBtLzCKMoXfPmGkXgSEulsBY = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.ZvUFnBtLzCKMoXfPmGkXgSEulsBY);
			pMslGiycUnXlzlRELNKXvqFUxujh.IpCfPtGJfFKLqRFFZlZPCnKIPLCiA = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.IpCfPtGJfFKLqRFFZlZPCnKIPLCiA);
			pMslGiycUnXlzlRELNKXvqFUxujh.CdejOEsUiDlvdAxJTEPADcPFlAYd = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.CdejOEsUiDlvdAxJTEPADcPFlAYd);
			pMslGiycUnXlzlRELNKXvqFUxujh.QxrUYIkNCeyPRxhXPyDlavhweHrJ = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.QxrUYIkNCeyPRxhXPyDlavhweHrJ);
			pMslGiycUnXlzlRELNKXvqFUxujh.TZNIgSgUITkRGNpeGEVNgBaSLNuS = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.TZNIgSgUITkRGNpeGEVNgBaSLNuS);
			for (int i = 0; i < pMslGiycUnXlzlRELNKXvqFUxujh.qZpwwOtRpwXllTHZcGrBCdcEaSqHA.Length; i++)
			{
				pMslGiycUnXlzlRELNKXvqFUxujh.qZpwwOtRpwXllTHZcGrBCdcEaSqHA[i] = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.qZpwwOtRpwXllTHZcGrBCdcEaSqHA[i]);
			}
			for (int j = 0; j < pMslGiycUnXlzlRELNKXvqFUxujh.oFDYAZcHldFNjIFjijejzJqPrzCPA.Length; j++)
			{
				pMslGiycUnXlzlRELNKXvqFUxujh.oFDYAZcHldFNjIFjijejzJqPrzCPA[j] = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.oFDYAZcHldFNjIFjijejzJqPrzCPA[j]);
			}
			for (int k = 0; k < pMslGiycUnXlzlRELNKXvqFUxujh.CdhkqlrkrWueANTWqCEaOOzCmWKF.Length; k++)
			{
				pMslGiycUnXlzlRELNKXvqFUxujh.CdhkqlrkrWueANTWqCEaOOzCmWKF[k] = uQPOritqCmojDTcNoDHVMaAqBRZQ3.CdhkqlrkrWueANTWqCEaOOzCmWKF[k];
			}
			pMslGiycUnXlzlRELNKXvqFUxujh.HDYLFfrHEfqhlmPSMlHNSykLuBuW = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.HDYLFfrHEfqhlmPSMlHNSykLuBuW);
			pMslGiycUnXlzlRELNKXvqFUxujh.fXaahwNwEZTqPHoGXTXUhTbdfwjb = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.fXaahwNwEZTqPHoGXTXUhTbdfwjb);
			pMslGiycUnXlzlRELNKXvqFUxujh.sGsrexbBEiqNKrKODQoOnllciJAq = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.sGsrexbBEiqNKrKODQoOnllciJAq);
			pMslGiycUnXlzlRELNKXvqFUxujh.jArYLmMiCXiGYkeRZdLrZuoEcOJLA = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.jArYLmMiCXiGYkeRZdLrZuoEcOJLA);
			pMslGiycUnXlzlRELNKXvqFUxujh.ugwxtaatqqOcJYODjjOqhctNmwQFb = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.ugwxtaatqqOcJYODjjOqhctNmwQFb);
			pMslGiycUnXlzlRELNKXvqFUxujh.vBjqnlSkdGBAonhKRbWAGfEvMpGQA = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.vBjqnlSkdGBAonhKRbWAGfEvMpGQA);
			for (int l = 0; l < pMslGiycUnXlzlRELNKXvqFUxujh.poZcfEtGCZChDNVxmfNEHOoNVYWQA.Length; l++)
			{
				pMslGiycUnXlzlRELNKXvqFUxujh.poZcfEtGCZChDNVxmfNEHOoNVYWQA[l] = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.poZcfEtGCZChDNVxmfNEHOoNVYWQA[l]);
			}
			pMslGiycUnXlzlRELNKXvqFUxujh.lRTpTXAnSmiCSxhLaXMDIbraayrq = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.lRTpTXAnSmiCSxhLaXMDIbraayrq);
			pMslGiycUnXlzlRELNKXvqFUxujh.mHSMliolUBWrVEqesbllbUSAOJge = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.mHSMliolUBWrVEqesbllbUSAOJge);
			pMslGiycUnXlzlRELNKXvqFUxujh.waJZKjyrpoGHxCxwMXyznRMaHbND = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.waJZKjyrpoGHxCxwMXyznRMaHbND);
			pMslGiycUnXlzlRELNKXvqFUxujh.vhdwZkNCVwNWJfzflFzWMCcaAIru = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.vhdwZkNCVwNWJfzflFzWMCcaAIru);
			pMslGiycUnXlzlRELNKXvqFUxujh.mbGPdmpAqQHhmnCqGgEDYeKaWvXy = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.mbGPdmpAqQHhmnCqGgEDYeKaWvXy);
			pMslGiycUnXlzlRELNKXvqFUxujh.uUmGDvxSgKziyzRGNQohUtVdRFJF = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.uUmGDvxSgKziyzRGNQohUtVdRFJF);
			for (int m = 0; m < pMslGiycUnXlzlRELNKXvqFUxujh.JUerymjoyAwhqxKjQefCqXjcGiQl.Length; m++)
			{
				pMslGiycUnXlzlRELNKXvqFUxujh.JUerymjoyAwhqxKjQefCqXjcGiQl[m] = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.JUerymjoyAwhqxKjQefCqXjcGiQl[m]);
			}
			pMslGiycUnXlzlRELNKXvqFUxujh.RCFpQWVhDhDqNLfwoQctigBQBHRE = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.RCFpQWVhDhDqNLfwoQctigBQBHRE);
			pMslGiycUnXlzlRELNKXvqFUxujh.xhSmsazaJqgphccFefmmxllOarGR = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.xhSmsazaJqgphccFefmmxllOarGR);
			pMslGiycUnXlzlRELNKXvqFUxujh.PaeJGnumCcUJNYcVTpTnHDjhHzbH = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.PaeJGnumCcUJNYcVTpTnHDjhHzbH);
			pMslGiycUnXlzlRELNKXvqFUxujh.mxhYyxVfoYdSQzjfNFYCBdwDEFae = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.mxhYyxVfoYdSQzjfNFYCBdwDEFae);
			pMslGiycUnXlzlRELNKXvqFUxujh.HlRvwjKSOtpzZJRsqbAowzBPHgTW = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.HlRvwjKSOtpzZJRsqbAowzBPHgTW);
			pMslGiycUnXlzlRELNKXvqFUxujh.RVZZhhhVtzQEXDPVpGLFaALTklPK = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.RVZZhhhVtzQEXDPVpGLFaALTklPK);
			for (int n = 0; n < pMslGiycUnXlzlRELNKXvqFUxujh.YQEEstMEFhgtAgwkQDgoOToGnVyE.Length; n++)
			{
				pMslGiycUnXlzlRELNKXvqFUxujh.YQEEstMEFhgtAgwkQDgoOToGnVyE[n] = jprxhJlZPUJQeGElhFpHyXbmysBc(uQPOritqCmojDTcNoDHVMaAqBRZQ2.YQEEstMEFhgtAgwkQDgoOToGnVyE[n]);
			}
		}

		public void yfnGTQTDyDBLubMjUITLbRzXJBJk(fCItkoTJoexslPjmCpAXmJzbNmWS P_0)
		{
			pMslGiycUnXlzlRELNKXvqFUxujh.AtPORbWyPEnMoScDgMQyDGKcLaiv(P_0.pMslGiycUnXlzlRELNKXvqFUxujh);
			nScNMcoHjBCdaODPtiPzXtOpesPA.XqRyfMuvTDXtoTNvOvNepFSlePvQ(P_0.nScNMcoHjBCdaODPtiPzXtOpesPA);
			iYBohnuCTDEnnAdcHhybqJuqCPlr = P_0.iYBohnuCTDEnnAdcHhybqJuqCPlr;
			oHKytibJAuGeTQVnJKKaDgkPxEum = P_0.oHKytibJAuGeTQVnJKKaDgkPxEum;
			fcCcxlcBKtCDYjTCKHBDdPyPFEahb = P_0.fcCcxlcBKtCDYjTCKHBDdPyPFEahb;
			NOvtUjRmHGClvbQKtnLvjoWiNLKEc = P_0.NOvtUjRmHGClvbQKtnLvjoWiNLKEc;
		}

		private int jprxhJlZPUJQeGElhFpHyXbmysBc(int P_0)
		{
			return MathTools.ValueInNewRange(P_0, iYBohnuCTDEnnAdcHhybqJuqCPlr, oHKytibJAuGeTQVnJKKaDgkPxEum, -65535, 65535);
		}
	}

	private class WmtjalqGZwmczfxxWtyGNCbHNzLv
	{
		private double nVVbptitBxtfoDIxXqclFsxwOFED;

		private uQPOritqCmojDTcNoDHVMaAqBRZQ pHTHAOkdzDRjIhbsZsrQjSeaXuVC;

		private uQPOritqCmojDTcNoDHVMaAqBRZQ wyiKgWjuUeqGNfzDCCGLlqnEEzeD;

		private uQPOritqCmojDTcNoDHVMaAqBRZQ SvBgqPctQxGFyewWWmaDKejOThXAA;

		private bool NoZXUEvsrUASwtrOSzlJBBYvtHXR;

		private double XWEpavbqyLikWsTFkQNONuHnNnZK;

		public uQPOritqCmojDTcNoDHVMaAqBRZQ PaMonfqwyfVsgTiRVFIjnPeULhgb => pHTHAOkdzDRjIhbsZsrQjSeaXuVC;

		public uQPOritqCmojDTcNoDHVMaAqBRZQ swxrNCkhokkLVZXQPRsTYPpKKEqA => SvBgqPctQxGFyewWWmaDKejOThXAA;

		public bool cuCSNUXgnysvJTmQPEDsAxAInaLgA => NoZXUEvsrUASwtrOSzlJBBYvtHXR;

		public double bjHDrjTOwqsIOeHnfuDbjSaDExLFA => XWEpavbqyLikWsTFkQNONuHnNnZK;

		public WmtjalqGZwmczfxxWtyGNCbHNzLv(uQPOritqCmojDTcNoDHVMaAqBRZQ P_0)
		{
			pHTHAOkdzDRjIhbsZsrQjSeaXuVC = P_0;
			wyiKgWjuUeqGNfzDCCGLlqnEEzeD = new uQPOritqCmojDTcNoDHVMaAqBRZQ();
			SvBgqPctQxGFyewWWmaDKejOThXAA = new uQPOritqCmojDTcNoDHVMaAqBRZQ();
		}

		public void mcIYxbvvfNZGOWrXfNRWCLZQiudb(double P_0)
		{
			nVVbptitBxtfoDIxXqclFsxwOFED = P_0;
			SvBgqPctQxGFyewWWmaDKejOThXAA.obTmgmDpublknGtnIrTsamUKkoKj = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.obTmgmDpublknGtnIrTsamUKkoKj - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.obTmgmDpublknGtnIrTsamUKkoKj;
			SvBgqPctQxGFyewWWmaDKejOThXAA.ZvUFnBtLzCKMoXfPmGkXgSEulsBY = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.ZvUFnBtLzCKMoXfPmGkXgSEulsBY - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.ZvUFnBtLzCKMoXfPmGkXgSEulsBY;
			SvBgqPctQxGFyewWWmaDKejOThXAA.IpCfPtGJfFKLqRFFZlZPCnKIPLCiA = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.IpCfPtGJfFKLqRFFZlZPCnKIPLCiA - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.IpCfPtGJfFKLqRFFZlZPCnKIPLCiA;
			SvBgqPctQxGFyewWWmaDKejOThXAA.CdejOEsUiDlvdAxJTEPADcPFlAYd = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.CdejOEsUiDlvdAxJTEPADcPFlAYd - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.CdejOEsUiDlvdAxJTEPADcPFlAYd;
			SvBgqPctQxGFyewWWmaDKejOThXAA.QxrUYIkNCeyPRxhXPyDlavhweHrJ = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.QxrUYIkNCeyPRxhXPyDlavhweHrJ - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.QxrUYIkNCeyPRxhXPyDlavhweHrJ;
			SvBgqPctQxGFyewWWmaDKejOThXAA.TZNIgSgUITkRGNpeGEVNgBaSLNuS = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.TZNIgSgUITkRGNpeGEVNgBaSLNuS - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.TZNIgSgUITkRGNpeGEVNgBaSLNuS;
			for (int i = 0; i < pHTHAOkdzDRjIhbsZsrQjSeaXuVC.qZpwwOtRpwXllTHZcGrBCdcEaSqHA.Length; i++)
			{
				SvBgqPctQxGFyewWWmaDKejOThXAA.qZpwwOtRpwXllTHZcGrBCdcEaSqHA[i] = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.qZpwwOtRpwXllTHZcGrBCdcEaSqHA[i] - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.qZpwwOtRpwXllTHZcGrBCdcEaSqHA[i];
			}
			for (int j = 0; j < pHTHAOkdzDRjIhbsZsrQjSeaXuVC.oFDYAZcHldFNjIFjijejzJqPrzCPA.Length; j++)
			{
				SvBgqPctQxGFyewWWmaDKejOThXAA.oFDYAZcHldFNjIFjijejzJqPrzCPA[j] = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.oFDYAZcHldFNjIFjijejzJqPrzCPA[j] - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.oFDYAZcHldFNjIFjijejzJqPrzCPA[j];
			}
			for (int k = 0; k < pHTHAOkdzDRjIhbsZsrQjSeaXuVC.CdhkqlrkrWueANTWqCEaOOzCmWKF.Length; k++)
			{
				SvBgqPctQxGFyewWWmaDKejOThXAA.CdhkqlrkrWueANTWqCEaOOzCmWKF[k] = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.CdhkqlrkrWueANTWqCEaOOzCmWKF[k] != wyiKgWjuUeqGNfzDCCGLlqnEEzeD.CdhkqlrkrWueANTWqCEaOOzCmWKF[k];
			}
			SvBgqPctQxGFyewWWmaDKejOThXAA.HDYLFfrHEfqhlmPSMlHNSykLuBuW = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.HDYLFfrHEfqhlmPSMlHNSykLuBuW - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.HDYLFfrHEfqhlmPSMlHNSykLuBuW;
			SvBgqPctQxGFyewWWmaDKejOThXAA.fXaahwNwEZTqPHoGXTXUhTbdfwjb = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.fXaahwNwEZTqPHoGXTXUhTbdfwjb - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.fXaahwNwEZTqPHoGXTXUhTbdfwjb;
			SvBgqPctQxGFyewWWmaDKejOThXAA.sGsrexbBEiqNKrKODQoOnllciJAq = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.sGsrexbBEiqNKrKODQoOnllciJAq - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.sGsrexbBEiqNKrKODQoOnllciJAq;
			SvBgqPctQxGFyewWWmaDKejOThXAA.jArYLmMiCXiGYkeRZdLrZuoEcOJLA = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.jArYLmMiCXiGYkeRZdLrZuoEcOJLA - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.jArYLmMiCXiGYkeRZdLrZuoEcOJLA;
			SvBgqPctQxGFyewWWmaDKejOThXAA.ugwxtaatqqOcJYODjjOqhctNmwQFb = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.ugwxtaatqqOcJYODjjOqhctNmwQFb - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.ugwxtaatqqOcJYODjjOqhctNmwQFb;
			SvBgqPctQxGFyewWWmaDKejOThXAA.vBjqnlSkdGBAonhKRbWAGfEvMpGQA = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.vBjqnlSkdGBAonhKRbWAGfEvMpGQA - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.vBjqnlSkdGBAonhKRbWAGfEvMpGQA;
			for (int l = 0; l < pHTHAOkdzDRjIhbsZsrQjSeaXuVC.poZcfEtGCZChDNVxmfNEHOoNVYWQA.Length; l++)
			{
				SvBgqPctQxGFyewWWmaDKejOThXAA.poZcfEtGCZChDNVxmfNEHOoNVYWQA[l] = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.poZcfEtGCZChDNVxmfNEHOoNVYWQA[l] - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.poZcfEtGCZChDNVxmfNEHOoNVYWQA[l];
			}
			SvBgqPctQxGFyewWWmaDKejOThXAA.lRTpTXAnSmiCSxhLaXMDIbraayrq = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.lRTpTXAnSmiCSxhLaXMDIbraayrq - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.lRTpTXAnSmiCSxhLaXMDIbraayrq;
			SvBgqPctQxGFyewWWmaDKejOThXAA.mHSMliolUBWrVEqesbllbUSAOJge = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.mHSMliolUBWrVEqesbllbUSAOJge - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.mHSMliolUBWrVEqesbllbUSAOJge;
			SvBgqPctQxGFyewWWmaDKejOThXAA.waJZKjyrpoGHxCxwMXyznRMaHbND = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.waJZKjyrpoGHxCxwMXyznRMaHbND - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.waJZKjyrpoGHxCxwMXyznRMaHbND;
			SvBgqPctQxGFyewWWmaDKejOThXAA.vhdwZkNCVwNWJfzflFzWMCcaAIru = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.vhdwZkNCVwNWJfzflFzWMCcaAIru - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.vhdwZkNCVwNWJfzflFzWMCcaAIru;
			SvBgqPctQxGFyewWWmaDKejOThXAA.mbGPdmpAqQHhmnCqGgEDYeKaWvXy = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.mbGPdmpAqQHhmnCqGgEDYeKaWvXy - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.mbGPdmpAqQHhmnCqGgEDYeKaWvXy;
			SvBgqPctQxGFyewWWmaDKejOThXAA.uUmGDvxSgKziyzRGNQohUtVdRFJF = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.uUmGDvxSgKziyzRGNQohUtVdRFJF - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.uUmGDvxSgKziyzRGNQohUtVdRFJF;
			for (int m = 0; m < pHTHAOkdzDRjIhbsZsrQjSeaXuVC.JUerymjoyAwhqxKjQefCqXjcGiQl.Length; m++)
			{
				SvBgqPctQxGFyewWWmaDKejOThXAA.JUerymjoyAwhqxKjQefCqXjcGiQl[m] = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.JUerymjoyAwhqxKjQefCqXjcGiQl[m] - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.JUerymjoyAwhqxKjQefCqXjcGiQl[m];
			}
			SvBgqPctQxGFyewWWmaDKejOThXAA.RCFpQWVhDhDqNLfwoQctigBQBHRE = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.RCFpQWVhDhDqNLfwoQctigBQBHRE - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.RCFpQWVhDhDqNLfwoQctigBQBHRE;
			SvBgqPctQxGFyewWWmaDKejOThXAA.xhSmsazaJqgphccFefmmxllOarGR = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.xhSmsazaJqgphccFefmmxllOarGR - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.xhSmsazaJqgphccFefmmxllOarGR;
			SvBgqPctQxGFyewWWmaDKejOThXAA.PaeJGnumCcUJNYcVTpTnHDjhHzbH = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.PaeJGnumCcUJNYcVTpTnHDjhHzbH - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.PaeJGnumCcUJNYcVTpTnHDjhHzbH;
			SvBgqPctQxGFyewWWmaDKejOThXAA.mxhYyxVfoYdSQzjfNFYCBdwDEFae = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.mxhYyxVfoYdSQzjfNFYCBdwDEFae - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.mxhYyxVfoYdSQzjfNFYCBdwDEFae;
			SvBgqPctQxGFyewWWmaDKejOThXAA.HlRvwjKSOtpzZJRsqbAowzBPHgTW = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.HlRvwjKSOtpzZJRsqbAowzBPHgTW - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.HlRvwjKSOtpzZJRsqbAowzBPHgTW;
			SvBgqPctQxGFyewWWmaDKejOThXAA.RVZZhhhVtzQEXDPVpGLFaALTklPK = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.RVZZhhhVtzQEXDPVpGLFaALTklPK - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.RVZZhhhVtzQEXDPVpGLFaALTklPK;
			for (int n = 0; n < pHTHAOkdzDRjIhbsZsrQjSeaXuVC.YQEEstMEFhgtAgwkQDgoOToGnVyE.Length; n++)
			{
				SvBgqPctQxGFyewWWmaDKejOThXAA.YQEEstMEFhgtAgwkQDgoOToGnVyE[n] = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.YQEEstMEFhgtAgwkQDgoOToGnVyE[n] - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.YQEEstMEFhgtAgwkQDgoOToGnVyE[n];
			}
			NoZXUEvsrUASwtrOSzlJBBYvtHXR = RIOxHWIilRXPrdSaNFYNLTPLrenN();
			if (NoZXUEvsrUASwtrOSzlJBBYvtHXR)
			{
				XWEpavbqyLikWsTFkQNONuHnNnZK = P_0;
				wyiKgWjuUeqGNfzDCCGLlqnEEzeD.AtPORbWyPEnMoScDgMQyDGKcLaiv(pHTHAOkdzDRjIhbsZsrQjSeaXuVC);
			}
		}

		public void XqRyfMuvTDXtoTNvOvNepFSlePvQ(WmtjalqGZwmczfxxWtyGNCbHNzLv P_0)
		{
			nVVbptitBxtfoDIxXqclFsxwOFED = P_0.nVVbptitBxtfoDIxXqclFsxwOFED;
			wyiKgWjuUeqGNfzDCCGLlqnEEzeD.AtPORbWyPEnMoScDgMQyDGKcLaiv(P_0.wyiKgWjuUeqGNfzDCCGLlqnEEzeD);
			SvBgqPctQxGFyewWWmaDKejOThXAA.AtPORbWyPEnMoScDgMQyDGKcLaiv(P_0.SvBgqPctQxGFyewWWmaDKejOThXAA);
		}

		private bool RIOxHWIilRXPrdSaNFYNLTPLrenN()
		{
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.ZvUFnBtLzCKMoXfPmGkXgSEulsBY != 0)
			{
				return true;
			}
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.IpCfPtGJfFKLqRFFZlZPCnKIPLCiA != 0)
			{
				return true;
			}
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.CdejOEsUiDlvdAxJTEPADcPFlAYd != 0)
			{
				return true;
			}
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.QxrUYIkNCeyPRxhXPyDlavhweHrJ != 0)
			{
				return true;
			}
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.TZNIgSgUITkRGNpeGEVNgBaSLNuS != 0)
			{
				return true;
			}
			for (int i = 0; i < pHTHAOkdzDRjIhbsZsrQjSeaXuVC.qZpwwOtRpwXllTHZcGrBCdcEaSqHA.Length; i++)
			{
				if (SvBgqPctQxGFyewWWmaDKejOThXAA.qZpwwOtRpwXllTHZcGrBCdcEaSqHA[i] != 0)
				{
					return true;
				}
			}
			for (int j = 0; j < pHTHAOkdzDRjIhbsZsrQjSeaXuVC.oFDYAZcHldFNjIFjijejzJqPrzCPA.Length; j++)
			{
				if (SvBgqPctQxGFyewWWmaDKejOThXAA.oFDYAZcHldFNjIFjijejzJqPrzCPA[j] != 0)
				{
					return true;
				}
			}
			for (int k = 0; k < pHTHAOkdzDRjIhbsZsrQjSeaXuVC.CdhkqlrkrWueANTWqCEaOOzCmWKF.Length; k++)
			{
				if (SvBgqPctQxGFyewWWmaDKejOThXAA.CdhkqlrkrWueANTWqCEaOOzCmWKF[k])
				{
					return true;
				}
			}
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.HDYLFfrHEfqhlmPSMlHNSykLuBuW != 0)
			{
				return true;
			}
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.fXaahwNwEZTqPHoGXTXUhTbdfwjb != 0)
			{
				return true;
			}
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.sGsrexbBEiqNKrKODQoOnllciJAq != 0)
			{
				return true;
			}
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.jArYLmMiCXiGYkeRZdLrZuoEcOJLA != 0)
			{
				return true;
			}
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.ugwxtaatqqOcJYODjjOqhctNmwQFb != 0)
			{
				return true;
			}
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.vBjqnlSkdGBAonhKRbWAGfEvMpGQA != 0)
			{
				return true;
			}
			for (int l = 0; l < pHTHAOkdzDRjIhbsZsrQjSeaXuVC.poZcfEtGCZChDNVxmfNEHOoNVYWQA.Length; l++)
			{
				if (SvBgqPctQxGFyewWWmaDKejOThXAA.poZcfEtGCZChDNVxmfNEHOoNVYWQA[l] != 0)
				{
					return true;
				}
			}
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.lRTpTXAnSmiCSxhLaXMDIbraayrq != 0)
			{
				return true;
			}
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.mHSMliolUBWrVEqesbllbUSAOJge != 0)
			{
				return true;
			}
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.waJZKjyrpoGHxCxwMXyznRMaHbND != 0)
			{
				return true;
			}
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.vhdwZkNCVwNWJfzflFzWMCcaAIru != 0)
			{
				return true;
			}
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.mbGPdmpAqQHhmnCqGgEDYeKaWvXy != 0)
			{
				return true;
			}
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.uUmGDvxSgKziyzRGNQohUtVdRFJF != 0)
			{
				return true;
			}
			for (int m = 0; m < pHTHAOkdzDRjIhbsZsrQjSeaXuVC.JUerymjoyAwhqxKjQefCqXjcGiQl.Length; m++)
			{
				SvBgqPctQxGFyewWWmaDKejOThXAA.JUerymjoyAwhqxKjQefCqXjcGiQl[m] = pHTHAOkdzDRjIhbsZsrQjSeaXuVC.JUerymjoyAwhqxKjQefCqXjcGiQl[m] - wyiKgWjuUeqGNfzDCCGLlqnEEzeD.JUerymjoyAwhqxKjQefCqXjcGiQl[m];
			}
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.RCFpQWVhDhDqNLfwoQctigBQBHRE != 0)
			{
				return true;
			}
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.xhSmsazaJqgphccFefmmxllOarGR != 0)
			{
				return true;
			}
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.PaeJGnumCcUJNYcVTpTnHDjhHzbH != 0)
			{
				return true;
			}
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.mxhYyxVfoYdSQzjfNFYCBdwDEFae != 0)
			{
				return true;
			}
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.HlRvwjKSOtpzZJRsqbAowzBPHgTW != 0)
			{
				return true;
			}
			if (SvBgqPctQxGFyewWWmaDKejOThXAA.RVZZhhhVtzQEXDPVpGLFaALTklPK != 0)
			{
				return true;
			}
			for (int n = 0; n < pHTHAOkdzDRjIhbsZsrQjSeaXuVC.YQEEstMEFhgtAgwkQDgoOToGnVyE.Length; n++)
			{
				if (SvBgqPctQxGFyewWWmaDKejOThXAA.YQEEstMEFhgtAgwkQDgoOToGnVyE[n] != 0)
				{
					return true;
				}
			}
			return false;
		}
	}

	private class GXOIDzdmNbFcAUakNJOCqLeoabiIA
	{
		public enum geTeHZdFgVspURilkonNERpBTdkuA
		{
			Exact = 0,
			Approximate = 1
		}

		public class WImaMAlLjNLgNoSkaFbyfizQlBAI
		{
			public int oIOoYvxHGXBgNloMifwuRPqXxHED;

			public Guid aSIlOpULSSGxsBGxFGaYCpMlKRsdb;

			public Guid ssmvaiQzGhUvivCCOjXWbjWqRyhJ;

			public int jBTsiwtECjADvCeprmlnxneXtOgaA;

			public int wLmKrOkAYrIGjzKKDIGuNvrCAHsA;

			public int LPhBAsrIHMEFydjnnEOHaRVvqjld;

			public int wYauevZnnOLZxSqhiTnwRAHrrKUn;

			public bool jiHbhKEmpvLfosjKlcMoxDaWboyY(sRWhguxFTduLiFMWjcVdhYcRFInQA P_0, geTeHZdFgVspURilkonNERpBTdkuA P_1)
			{
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == oIOoYvxHGXBgNloMifwuRPqXxHED)
				{
					return true;
				}
				if (wLmKrOkAYrIGjzKKDIGuNvrCAHsA != P_0.xYtxjvGiDblMLazxSNoxuZeFGhdo)
				{
					return false;
				}
				if (LPhBAsrIHMEFydjnnEOHaRVvqjld != P_0.xPHraTegAQkZKJrJSesorPOqjVNDA)
				{
					return false;
				}
				if (wYauevZnnOLZxSqhiTnwRAHrrKUn != P_0.oOgOpJMTHvLxBTmQYOBaWbPGVsrj)
				{
					return false;
				}
				return P_1 switch
				{
					geTeHZdFgVspURilkonNERpBTdkuA.Exact => aSIlOpULSSGxsBGxFGaYCpMlKRsdb == P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, 
					geTeHZdFgVspURilkonNERpBTdkuA.Approximate => ssmvaiQzGhUvivCCOjXWbjWqRyhJ == P_0.lyAgFGdIgZPjctjcvktMApKBBqlYb, 
					_ => throw new NotImplementedException(), 
				};
			}

			public virtual string ceXwszsJwJDwhbaOAbqjXEVaqxfYA()
			{
				string text = "" + "rewiredId = " + oIOoYvxHGXBgNloMifwuRPqXxHED + "\n";
				Guid guid = aSIlOpULSSGxsBGxFGaYCpMlKRsdb;
				string text2 = text + "instanceGuid = " + guid.ToString() + "\n";
				guid = ssmvaiQzGhUvivCCOjXWbjWqRyhJ;
				return string.Concat(string.Concat(string.Concat(string.Concat(text2 + "typeIdentifierGuid = " + guid.ToString() + "\n", "lastInputManagerId = ", jBTsiwtECjADvCeprmlnxneXtOgaA.ToString(), "\n"), "hardwareAxisCount = ", wLmKrOkAYrIGjzKKDIGuNvrCAHsA.ToString(), "\n"), "hardwareButtonCount = ", LPhBAsrIHMEFydjnnEOHaRVvqjld.ToString(), "\n"), "hardwareHatCount = ", wYauevZnnOLZxSqhiTnwRAHrrKUn.ToString(), "\n");
			}
		}

		private sealed class cJlkAMsfzvCEZLhtZwHoQLVAQcsl : IEnumerable<WImaMAlLjNLgNoSkaFbyfizQlBAI>, IEnumerable, IEnumerator<WImaMAlLjNLgNoSkaFbyfizQlBAI>, IEnumerator, IDisposable
		{
			private int qahawuCBLOIalXwfjtFBLvwHnddB;

			private WImaMAlLjNLgNoSkaFbyfizQlBAI qJwvyqcIBacKuevMSUUsNgOyMxXn;

			private int zldHMDtVHbHEoMtDcjPBlEFscEBt;

			public GXOIDzdmNbFcAUakNJOCqLeoabiIA VLXcEzsWhBxpEnHzhWJSLsUuIAul;

			private sRWhguxFTduLiFMWjcVdhYcRFInQA jPJaKgjTvdftVdgeNTRaAlLEOPeqB;

			public sRWhguxFTduLiFMWjcVdhYcRFInQA GUOfNPigFbFwdfWqNQoUgafCAeWNB;

			private geTeHZdFgVspURilkonNERpBTdkuA cczpIHXLTXIBvqcUfPCQqNDctYom;

			public geTeHZdFgVspURilkonNERpBTdkuA beSiNkcPdMILldWQhDsGKxOKsMaQA;

			private int tbnORyEtKhMuVeSAZrvkkGJDKIlq;

			private int CihIcXzzoTMrcfhBNloJfNgHYYwB;

			WImaMAlLjNLgNoSkaFbyfizQlBAI IEnumerator<WImaMAlLjNLgNoSkaFbyfizQlBAI>.Current
			{
				[DebuggerHidden]
				get
				{
					return qJwvyqcIBacKuevMSUUsNgOyMxXn;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return qJwvyqcIBacKuevMSUUsNgOyMxXn;
				}
			}

			[DebuggerHidden]
			public cJlkAMsfzvCEZLhtZwHoQLVAQcsl(int P_0)
			{
				qahawuCBLOIalXwfjtFBLvwHnddB = P_0;
				zldHMDtVHbHEoMtDcjPBlEFscEBt = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				qahawuCBLOIalXwfjtFBLvwHnddB = -2;
			}

			private bool MoveNext()
			{
				int num = qahawuCBLOIalXwfjtFBLvwHnddB;
				GXOIDzdmNbFcAUakNJOCqLeoabiIA vLXcEzsWhBxpEnHzhWJSLsUuIAul = VLXcEzsWhBxpEnHzhWJSLsUuIAul;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					qahawuCBLOIalXwfjtFBLvwHnddB = -1;
					goto IL_0083;
				}
				qahawuCBLOIalXwfjtFBLvwHnddB = -1;
				tbnORyEtKhMuVeSAZrvkkGJDKIlq = vLXcEzsWhBxpEnHzhWJSLsUuIAul.xHxKuFLthuPxDKptAXhykGFfduOD.Count;
				CihIcXzzoTMrcfhBNloJfNgHYYwB = 0;
				goto IL_0093;
				IL_0083:
				CihIcXzzoTMrcfhBNloJfNgHYYwB++;
				goto IL_0093;
				IL_0093:
				if (CihIcXzzoTMrcfhBNloJfNgHYYwB < tbnORyEtKhMuVeSAZrvkkGJDKIlq)
				{
					if (vLXcEzsWhBxpEnHzhWJSLsUuIAul.xHxKuFLthuPxDKptAXhykGFfduOD[CihIcXzzoTMrcfhBNloJfNgHYYwB].jiHbhKEmpvLfosjKlcMoxDaWboyY(jPJaKgjTvdftVdgeNTRaAlLEOPeqB, cczpIHXLTXIBvqcUfPCQqNDctYom))
					{
						qJwvyqcIBacKuevMSUUsNgOyMxXn = vLXcEzsWhBxpEnHzhWJSLsUuIAul.xHxKuFLthuPxDKptAXhykGFfduOD[CihIcXzzoTMrcfhBNloJfNgHYYwB];
						qahawuCBLOIalXwfjtFBLvwHnddB = 1;
						return true;
					}
					goto IL_0083;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<WImaMAlLjNLgNoSkaFbyfizQlBAI> IEnumerable<WImaMAlLjNLgNoSkaFbyfizQlBAI>.GetEnumerator()
			{
				cJlkAMsfzvCEZLhtZwHoQLVAQcsl cJlkAMsfzvCEZLhtZwHoQLVAQcsl2;
				if (qahawuCBLOIalXwfjtFBLvwHnddB == -2 && zldHMDtVHbHEoMtDcjPBlEFscEBt == Environment.CurrentManagedThreadId)
				{
					qahawuCBLOIalXwfjtFBLvwHnddB = 0;
					cJlkAMsfzvCEZLhtZwHoQLVAQcsl2 = this;
				}
				else
				{
					cJlkAMsfzvCEZLhtZwHoQLVAQcsl2 = new cJlkAMsfzvCEZLhtZwHoQLVAQcsl(0);
					cJlkAMsfzvCEZLhtZwHoQLVAQcsl2.VLXcEzsWhBxpEnHzhWJSLsUuIAul = VLXcEzsWhBxpEnHzhWJSLsUuIAul;
				}
				cJlkAMsfzvCEZLhtZwHoQLVAQcsl2.jPJaKgjTvdftVdgeNTRaAlLEOPeqB = GUOfNPigFbFwdfWqNQoUgafCAeWNB;
				cJlkAMsfzvCEZLhtZwHoQLVAQcsl2.cczpIHXLTXIBvqcUfPCQqNDctYom = beSiNkcPdMILldWQhDsGKxOKsMaQA;
				return cJlkAMsfzvCEZLhtZwHoQLVAQcsl2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<WImaMAlLjNLgNoSkaFbyfizQlBAI>)this).GetEnumerator();
			}
		}

		private List<WImaMAlLjNLgNoSkaFbyfizQlBAI> xHxKuFLthuPxDKptAXhykGFfduOD;

		public GXOIDzdmNbFcAUakNJOCqLeoabiIA()
		{
			xHxKuFLthuPxDKptAXhykGFfduOD = new List<WImaMAlLjNLgNoSkaFbyfizQlBAI>();
		}

		public void kkrDGBiDxIrcbQXrAkEcvrJfUchH(sRWhguxFTduLiFMWjcVdhYcRFInQA P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = xHxKuFLthuPxDKptAXhykGFfduOD.Count;
			for (int i = 0; i < count; i++)
			{
				if (xHxKuFLthuPxDKptAXhykGFfduOD[i].jiHbhKEmpvLfosjKlcMoxDaWboyY(P_0, geTeHZdFgVspURilkonNERpBTdkuA.Exact))
				{
					xHxKuFLthuPxDKptAXhykGFfduOD[i].oIOoYvxHGXBgNloMifwuRPqXxHED = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					xHxKuFLthuPxDKptAXhykGFfduOD[i].aSIlOpULSSGxsBGxFGaYCpMlKRsdb = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
					xHxKuFLthuPxDKptAXhykGFfduOD[i].ssmvaiQzGhUvivCCOjXWbjWqRyhJ = P_0.lyAgFGdIgZPjctjcvktMApKBBqlYb;
					xHxKuFLthuPxDKptAXhykGFfduOD[i].jBTsiwtECjADvCeprmlnxneXtOgaA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					xHxKuFLthuPxDKptAXhykGFfduOD[i].wLmKrOkAYrIGjzKKDIGuNvrCAHsA = P_0.xYtxjvGiDblMLazxSNoxuZeFGhdo;
					xHxKuFLthuPxDKptAXhykGFfduOD[i].LPhBAsrIHMEFydjnnEOHaRVvqjld = P_0.xPHraTegAQkZKJrJSesorPOqjVNDA;
					xHxKuFLthuPxDKptAXhykGFfduOD[i].wYauevZnnOLZxSqhiTnwRAHrrKUn = P_0.oOgOpJMTHvLxBTmQYOBaWbPGVsrj;
					mUFMTjlXNbENkRReANQXYsgeZNiC(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, i);
					return;
				}
			}
			xHxKuFLthuPxDKptAXhykGFfduOD.Add(new WImaMAlLjNLgNoSkaFbyfizQlBAI
			{
				oIOoYvxHGXBgNloMifwuRPqXxHED = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				aSIlOpULSSGxsBGxFGaYCpMlKRsdb = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid,
				ssmvaiQzGhUvivCCOjXWbjWqRyhJ = P_0.lyAgFGdIgZPjctjcvktMApKBBqlYb,
				jBTsiwtECjADvCeprmlnxneXtOgaA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				wLmKrOkAYrIGjzKKDIGuNvrCAHsA = P_0.xYtxjvGiDblMLazxSNoxuZeFGhdo,
				LPhBAsrIHMEFydjnnEOHaRVvqjld = P_0.xPHraTegAQkZKJrJSesorPOqjVNDA,
				wYauevZnnOLZxSqhiTnwRAHrrKUn = P_0.oOgOpJMTHvLxBTmQYOBaWbPGVsrj
			});
			mUFMTjlXNbENkRReANQXYsgeZNiC(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, xHxKuFLthuPxDKptAXhykGFfduOD.Count - 1);
		}

		public bool dLVyHSJXMksIxaGbYfkLdQLDJBMr(sRWhguxFTduLiFMWjcVdhYcRFInQA P_0, geTeHZdFgVspURilkonNERpBTdkuA P_1)
		{
			int count = xHxKuFLthuPxDKptAXhykGFfduOD.Count;
			for (int i = 0; i < count; i++)
			{
				if (xHxKuFLthuPxDKptAXhykGFfduOD[i].jiHbhKEmpvLfosjKlcMoxDaWboyY(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(cJlkAMsfzvCEZLhtZwHoQLVAQcsl))]
		public IEnumerable<WImaMAlLjNLgNoSkaFbyfizQlBAI> OJNETAjTiPjhBCULvdSUsDpJmwBH(sRWhguxFTduLiFMWjcVdhYcRFInQA P_0, geTeHZdFgVspURilkonNERpBTdkuA P_1)
		{
			return new cJlkAMsfzvCEZLhtZwHoQLVAQcsl(-2)
			{
				VLXcEzsWhBxpEnHzhWJSLsUuIAul = this,
				GUOfNPigFbFwdfWqNQoUgafCAeWNB = P_0,
				beSiNkcPdMILldWQhDsGKxOKsMaQA = P_1
			};
		}

		private void mUFMTjlXNbENkRReANQXYsgeZNiC(int P_0, Guid P_1, int P_2)
		{
			for (int num = xHxKuFLthuPxDKptAXhykGFfduOD.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (xHxKuFLthuPxDKptAXhykGFfduOD[num].oIOoYvxHGXBgNloMifwuRPqXxHED == P_0 || xHxKuFLthuPxDKptAXhykGFfduOD[num].aSIlOpULSSGxsBGxFGaYCpMlKRsdb == P_1))
				{
					xHxKuFLthuPxDKptAXhykGFfduOD.RemoveAt(num);
				}
			}
		}

		public virtual string SpxxYJLPfZhBOzzkUmgynmPvifHkA()
		{
			string text = "";
			text = text + "Joystick records: " + xHxKuFLthuPxDKptAXhykGFfduOD.Count + "\n";
			for (int i = 0; i < xHxKuFLthuPxDKptAXhykGFfduOD.Count; i++)
			{
				text = text + "Record " + i + ":\n";
				text = text + xHxKuFLthuPxDKptAXhykGFfduOD[i].ToString() + "\n\n";
			}
			return text;
		}
	}

	private class UMUepdaKdkdtNySEjpdHJaUZqWOBA
	{
		public sRWhguxFTduLiFMWjcVdhYcRFInQA MckLyxGfPwPIGZyqtqBTEKZVSWKf;

		public UTyQEMVineRQmjtixsdHzIMSbUZe GJqyoACsBXxnGKZMzgnxaDNRgEGN;

		public bool NgnhJCDZlPGbJlMmKRAkgIoNfGJq
		{
			get
			{
				if (MckLyxGfPwPIGZyqtqBTEKZVSWKf != null)
				{
					return GJqyoACsBXxnGKZMzgnxaDNRgEGN != null;
				}
				return false;
			}
		}

		public UMUepdaKdkdtNySEjpdHJaUZqWOBA(sRWhguxFTduLiFMWjcVdhYcRFInQA P_0, UTyQEMVineRQmjtixsdHzIMSbUZe P_1)
		{
			MckLyxGfPwPIGZyqtqBTEKZVSWKf = P_0;
			GJqyoACsBXxnGKZMzgnxaDNRgEGN = P_1;
		}

		public static List<UTyQEMVineRQmjtixsdHzIMSbUZe> EcLMgpwJDHQpEOgDyqysmnDBrDNT(List<UMUepdaKdkdtNySEjpdHJaUZqWOBA> P_0)
		{
			if (P_0 == null)
			{
				return new List<UTyQEMVineRQmjtixsdHzIMSbUZe>();
			}
			List<UTyQEMVineRQmjtixsdHzIMSbUZe> list = new List<UTyQEMVineRQmjtixsdHzIMSbUZe>();
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i].NgnhJCDZlPGbJlMmKRAkgIoNfGJq)
				{
					list.Add(P_0[i].GJqyoACsBXxnGKZMzgnxaDNRgEGN);
				}
			}
			return list;
		}
	}

	private class DLdGpFiyZZVpBQWrAaplwUDfLANab
	{
		public IJySsOxfJZoqgcJpcZGpRDTPCFrG kZTakRCYDRszcTFopEAaHDFWvTvPA;

		public DLdGpFiyZZVpBQWrAaplwUDfLANab(IJySsOxfJZoqgcJpcZGpRDTPCFrG P_0)
		{
			kZTakRCYDRszcTFopEAaHDFWvTvPA = P_0;
		}
	}

	private class lswZnEVrukiaFvmjeZglAfZazCEg
	{
		private AYveqpKvYlqUCBIbxzOWrzCaoxLAA.cDSBVMVNMrTziqWDrNuTXJbrNAAv DzkENvquKAOEALfMfVTwEYTHPMme;

		private AYveqpKvYlqUCBIbxzOWrzCaoxLAA.HtrlVIBazcDPxJFWekDZVpYqwBsY JWKQqyRxysmatgCQaJWMKvdjjGKj;

		private NativeBuffer hsKvNarHcyFaIkoBGRVpkvLLWgvnA;

		private int UmEwlRqptsGAMiKDuGKhoTsAJCqmA;

		public lswZnEVrukiaFvmjeZglAfZazCEg()
		{
			DzkENvquKAOEALfMfVTwEYTHPMme = new AYveqpKvYlqUCBIbxzOWrzCaoxLAA.cDSBVMVNMrTziqWDrNuTXJbrNAAv
			{
				cdPfjwUaXXyEkDdILpVUlUCKfypE = (uint)Marshal.SizeOf(typeof(AYveqpKvYlqUCBIbxzOWrzCaoxLAA.cDSBVMVNMrTziqWDrNuTXJbrNAAv)),
				gVVDcLBqlfceBBocUUatxZcqtEWk = true,
				qmAOdVLNrgSQinpAGqBiOOoPWqoK = true,
				uuSAtFWxRgqLiWvFrwnxBmQJEaYO = false,
				uhvyanoFMFncIuQgMwrJKantENSbA = true,
				jTwpnPOLVdDpHdWhkdXwdMUDRWtbc = IntPtr.Zero
			};
			JWKQqyRxysmatgCQaJWMKvdjjGKj = AYveqpKvYlqUCBIbxzOWrzCaoxLAA.HtrlVIBazcDPxJFWekDZVpYqwBsY.MSfwaUGlXMpRWVAixPEANcwMavTi();
			hsKvNarHcyFaIkoBGRVpkvLLWgvnA = new NativeBuffer((int)JWKQqyRxysmatgCQaJWMKvdjjGKj.bjVZHJtEpvRSLWqVsjfGPqGYcdBR);
			hsKvNarHcyFaIkoBGRVpkvLLWgvnA.Write(JWKQqyRxysmatgCQaJWMKvdjjGKj.bjVZHJtEpvRSLWqVsjfGPqGYcdBR, 0);
		}

		public bool pVlQJawNFpUUfwyZVgGouycQGUMI()
		{
			int num = IDLUcgYXOMgGSAmIWbcaHSAiiOevA();
			if (num == UmEwlRqptsGAMiKDuGKhoTsAJCqmA)
			{
				return false;
			}
			UmEwlRqptsGAMiKDuGKhoTsAJCqmA = num;
			return true;
		}

		public void rtwMPTzWhYVIhLcKjaKorafNjiSj(int P_0)
		{
			UmEwlRqptsGAMiKDuGKhoTsAJCqmA = P_0;
		}

		private int IDLUcgYXOMgGSAmIWbcaHSAiiOevA()
		{
			try
			{
				return RciGSOAIVzSFNUsWuoeDdCDjeMbbc.COJFgXJyByCqYeujWDmloFUJPnyBb(ref DzkENvquKAOEALfMfVTwEYTHPMme, hsKvNarHcyFaIkoBGRVpkvLLWgvnA);
			}
			catch
			{
				return 0;
			}
		}
	}

	private enum ZSovmlhoZKTNRcDjddXShKrptrEEA
	{
		Device = 17,
		Mouse = 18,
		Keyboard = 19,
		Joystick = 20,
		Gamepad = 21,
		Driving = 22,
		Flight = 23,
		FirstPerson = 24,
		ControlDevice = 25,
		ScreenPointer = 26,
		Remote = 27,
		Supplemental = 28
	}

	private const cOhhDjZBePQFVLMIFaodEQtjsqZJA yqMFUFSHrpDqVbmqbPOjyAaciIKUA = cOhhDjZBePQFVLMIFaodEQtjsqZJA.GameControl;

	private const OJZMDLzBRIdZoAVPTbqRprFJTssS AAqyMGTBgsCsoVuqBiFJihhpsyli = OJZMDLzBRIdZoAVPTbqRprFJTssS.AttachedOnly;

	private IntPtr CtdJOYEwhxjrpRQeawTCaFreRfme;

	private PuzDJRCxXcZXBmquMyeKTHoPUks whwuTJYaLgxeZAfnAEucFFrjvBULA;

	private List<sRWhguxFTduLiFMWjcVdhYcRFInQA> ZHzZYihtnFSsxyDkozkNTJvuWhcG;

	private int xMEalByuJuVkiiLUjsoNHUDKmwsm;

	private GXOIDzdmNbFcAUakNJOCqLeoabiIA FJppIHudvgmvNdFWNZbgFBUqXXNT;

	private bool nXxddzEtcsAotCnVlnqXqIhshooZ;

	private NmANKYQYjJJatXyTLQutNfBhTrds UTVqBcoeQiTBgMqKSXvVLiGGPXuV;

	private UpdateLoopSetting zEHnUaZkeTgfFOGLdHJkHGtsJNuWA;

	private Action<int, ControllerDataUpdater> jmpPJQawCDjKbvIlMHZQoDzjBzWY;

	private PlatformInputManager dvTcqFURMhEgLdexykcnXKPcSWBZ;

	private TimerRealTime BLaLpKNLbGHEGMHVbDqqHAWfPXZK;

	private global::qNmehkleTfcBTeRaeVPEWTMAtwnsA<bool> FggehqducMfBXQoMJhQglcPWdrgrA;

	private lswZnEVrukiaFvmjeZglAfZazCEg HqCbeqLToJfsvdEWCPUViweidGMDA;

	private int tmhkvuKhFlRJovziggLsMVkBZrqH;

	private int qOzZIntLkvYISSNuPeKaENsgOPnSA;

	private global::qNmehkleTfcBTeRaeVPEWTMAtwnsA<List<UMUepdaKdkdtNySEjpdHJaUZqWOBA>> SgThyzipPeacTHmoeFlIZhUNCUrf;

	private readonly object CBQnUOOlgOcflOrdNpEIMEhzsZJV = new object();

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> oHJnhAkiajYFYWtpEqMaFQxxAxzaA;

	private Func<int> BkidUCzjOLEuGhmYoVrAAfUVmqCtA;

	NmANKYQYjJJatXyTLQutNfBhTrds XxcRWDacxPwaZuelhLPGabtEumyQ.YogAZbtYYniRhKJTUxmdWNvJBxiaA
	{
		get
		{
			return UTVqBcoeQiTBgMqKSXvVLiGGPXuV;
		}
		set
		{
			UTVqBcoeQiTBgMqKSXvVLiGGPXuV = uTVqBcoeQiTBgMqKSXvVLiGGPXuV;
		}
	}

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => xMEalByuJuVkiiLUjsoNHUDKmwsm;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => dvTcqFURMhEgLdexykcnXKPcSWBZ;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => new InputSourceWrapper<PuzDJRCxXcZXBmquMyeKTHoPUks>(whwuTJYaLgxeZAfnAEucFFrjvBULA);

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.DirectInput;

	public cRyfuQzNFxYGQezCiHENTfXugyhgA(UpdateLoopSetting P_0, NmANKYQYjJJatXyTLQutNfBhTrds P_1, IntPtr P_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_3, Func<int> P_4)
	{
		try
		{
			zEHnUaZkeTgfFOGLdHJkHGtsJNuWA = P_0;
			UTVqBcoeQiTBgMqKSXvVLiGGPXuV = P_1;
			CtdJOYEwhxjrpRQeawTCaFreRfme = P_2;
			oHJnhAkiajYFYWtpEqMaFQxxAxzaA = P_3;
			BkidUCzjOLEuGhmYoVrAAfUVmqCtA = P_4;
			dvTcqFURMhEgLdexykcnXKPcSWBZ = this;
			whwuTJYaLgxeZAfnAEucFFrjvBULA = new PuzDJRCxXcZXBmquMyeKTHoPUks();
			jmpPJQawCDjKbvIlMHZQoDzjBzWY = UpdateControllerData;
			HqCbeqLToJfsvdEWCPUViweidGMDA = new lswZnEVrukiaFvmjeZglAfZazCEg();
			FggehqducMfBXQoMJhQglcPWdrgrA = new global::qNmehkleTfcBTeRaeVPEWTMAtwnsA<bool>(true, KIxlraCEXZXUlAPYaBmFDjMybqGS);
			SgThyzipPeacTHmoeFlIZhUNCUrf = new global::qNmehkleTfcBTeRaeVPEWTMAtwnsA<List<UMUepdaKdkdtNySEjpdHJaUZqWOBA>>(true, () => XrJHHBzfBqYLqHRIvMMBXVUIkned());
			BsvzduDyWICowlvigOabRcEZkQRh();
		}
		catch (Exception)
		{
			OnDestroy();
			throw;
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		FJppIHudvgmvNdFWNZbgFBUqXXNT = new GXOIDzdmNbFcAUakNJOCqLeoabiIA();
		BLaLpKNLbGHEGMHVbDqqHAWfPXZK = new TimerRealTime(1.0);
		BLaLpKNLbGHEGMHVbDqqHAWfPXZK.Start();
		tZAjRGSldlfLcsiejFLojqVqrPTNA();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		oKoXZZigDpvdCjHvodbIslSnGprDA();
		NfIYspzzEbqBQSdIVBCweyLgtoVTA();
		MnzvUSKuKYjVLQTESKWIDfyThUXP();
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (SgThyzipPeacTHmoeFlIZhUNCUrf != null)
		{
			SgThyzipPeacTHmoeFlIZhUNCUrf.INBczqSosoXHntgpZStpJliJdQBM();
		}
		if (FggehqducMfBXQoMJhQglcPWdrgrA != null)
		{
			FggehqducMfBXQoMJhQglcPWdrgrA.INBczqSosoXHntgpZStpJliJdQBM();
		}
		if (ZHzZYihtnFSsxyDkozkNTJvuWhcG == null)
		{
			return;
		}
		lock (CBQnUOOlgOcflOrdNpEIMEhzsZJV)
		{
			for (int i = 0; i < ZHzZYihtnFSsxyDkozkNTJvuWhcG.Count; i++)
			{
				if (ZHzZYihtnFSsxyDkozkNTJvuWhcG[i] != null)
				{
					ZHzZYihtnFSsxyDkozkNTJvuWhcG[i].FUzBoenJKOoPfZeUGTZxKnrgIdBm();
					ZHzZYihtnFSsxyDkozkNTJvuWhcG[i].TxOAEXFpROagqefiitDqiiVidAAMe();
				}
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return jmpPJQawCDjKbvIlMHZQoDzjBzWY;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		lock (CBQnUOOlgOcflOrdNpEIMEhzsZJV)
		{
			for (int i = 0; i < xMEalByuJuVkiiLUjsoNHUDKmwsm; i++)
			{
				if (ZHzZYihtnFSsxyDkozkNTJvuWhcG[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
				{
					ZHzZYihtnFSsxyDkozkNTJvuWhcG[i].FillData(data);
					return;
				}
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		nXxddzEtcsAotCnVlnqXqIhshooZ = true;
		BLaLpKNLbGHEGMHVbDqqHAWfPXZK.Start();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		nXxddzEtcsAotCnVlnqXqIhshooZ = true;
		BLaLpKNLbGHEGMHVbDqqHAWfPXZK.Start();
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return null;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return null;
	}

	private void oKoXZZigDpvdCjHvodbIslSnGprDA()
	{
		if (FggehqducMfBXQoMJhQglcPWdrgrA.TPoeWwEYcJhWohaeHjOgcVjxblcSA)
		{
			if (FggehqducMfBXQoMJhQglcPWdrgrA.VWKJlWBJsiHHmQEXkCqAcjYYeDisA() && !BLaLpKNLbGHEGMHVbDqqHAWfPXZK.running && !SgThyzipPeacTHmoeFlIZhUNCUrf.TPoeWwEYcJhWohaeHjOgcVjxblcSA)
			{
				if (FggehqducMfBXQoMJhQglcPWdrgrA.FFWjswuhFTDsWeZHbKPsbmwJBlek)
				{
					nXxddzEtcsAotCnVlnqXqIhshooZ = true;
				}
				BLaLpKNLbGHEGMHVbDqqHAWfPXZK.Start();
			}
		}
		else if (!BLaLpKNLbGHEGMHVbDqqHAWfPXZK.running)
		{
			BLaLpKNLbGHEGMHVbDqqHAWfPXZK.Start();
		}
		else if (BLaLpKNLbGHEGMHVbDqqHAWfPXZK.Update())
		{
			FggehqducMfBXQoMJhQglcPWdrgrA.tGmkFOBGLIStwNoiokXgtfxSMCi();
		}
	}

	private List<UMUepdaKdkdtNySEjpdHJaUZqWOBA> XrJHHBzfBqYLqHRIvMMBXVUIkned()
	{
		List<UMUepdaKdkdtNySEjpdHJaUZqWOBA> list = new List<UMUepdaKdkdtNySEjpdHJaUZqWOBA>();
		IList<UTyQEMVineRQmjtixsdHzIMSbUZe> list2 = eEWjrHkpGgHFbpVbZjMhYriFiBXT();
		int count = list2.Count;
		for (int i = 0; i < count; i++)
		{
			if (list2[i] == null)
			{
				continue;
			}
			try
			{
				UTyQEMVineRQmjtixsdHzIMSbUZe uTyQEMVineRQmjtixsdHzIMSbUZe = list2[i];
				Guid gPdNFUoLpXnWxHqaioqXdBJsVuWK = uTyQEMVineRQmjtixsdHzIMSbUZe.gPdNFUoLpXnWxHqaioqXdBJsVuWK;
				IJySsOxfJZoqgcJpcZGpRDTPCFrG jySsOxfJZoqgcJpcZGpRDTPCFrG = new IJySsOxfJZoqgcJpcZGpRDTPCFrG(whwuTJYaLgxeZAfnAEucFFrjvBULA, gPdNFUoLpXnWxHqaioqXdBJsVuWK);
				zBNHOAiqFlvGvZvPcFAbGpCWxqMN zBNHOAiqFlvGvZvPcFAbGpCWxqMN2 = jySsOxfJZoqgcJpcZGpRDTPCFrG.ZVHWpcVAPAcfasMqWKZyxBQxZmuU;
				if (UTVqBcoeQiTBgMqKSXvVLiGGPXuV == null)
				{
					goto IL_00bd;
				}
				string text = uTyQEMVineRQmjtixsdHzIMSbUZe.KGqdhBHUknswGuNHWGWgROAtaLGuA.ToString();
				if (!UTVqBcoeQiTBgMqKSXvVLiGGPXuV.zwFWuhpNGpaYHTeMbZLtTuxNKNtm(zBNHOAiqFlvGvZvPcFAbGpCWxqMN2.VLTgKPRWXpYtQNFGpcIQkAFzxfyK, StringTools.SanitizeDeviceString(uTyQEMVineRQmjtixsdHzIMSbUZe.FeYNFHLhgUivGWxojyZVZwwJgvsj), string.Empty, new PidVid(Convert.ToUInt16(text.Substring(0, 4), 16), Convert.ToUInt16(text.Substring(4, 4), 16))))
				{
					goto IL_00bd;
				}
				goto end_IL_0028;
				IL_00bd:
				if (!JqoBfisQKbNTMkNdWslkfAHzLkfW.MZNYCCCfmgcBgckrXQqebPUNffxnA(InputSource.DirectInput, (ushort)zBNHOAiqFlvGvZvPcFAbGpCWxqMN2.wlEVOpJLteSEIhAOUIIkDMwszDqu, (ushort)zBNHOAiqFlvGvZvPcFAbGpCWxqMN2.zdfuVksFXiQtCHPlhGPiXWmpEMBKA, (JqoBfisQKbNTMkNdWslkfAHzLkfW.IQBialDLMBiObHdTIbjQIuoQHpxo)3))
				{
					continue;
				}
				Guid guid = ((!string.IsNullOrEmpty(zBNHOAiqFlvGvZvPcFAbGpCWxqMN2.VLTgKPRWXpYtQNFGpcIQkAFzxfyK)) ? MiscTools.CreateGuidHashSHA256(zBNHOAiqFlvGvZvPcFAbGpCWxqMN2.VLTgKPRWXpYtQNFGpcIQkAFzxfyK) : uTyQEMVineRQmjtixsdHzIMSbUZe.gPdNFUoLpXnWxHqaioqXdBJsVuWK);
				bool flag = false;
				lock (CBQnUOOlgOcflOrdNpEIMEhzsZJV)
				{
					if (ZHzZYihtnFSsxyDkozkNTJvuWhcG != null)
					{
						for (int j = 0; j < ZHzZYihtnFSsxyDkozkNTJvuWhcG.Count; j++)
						{
							if (ZHzZYihtnFSsxyDkozkNTJvuWhcG[j] != null && ZHzZYihtnFSsxyDkozkNTJvuWhcG[j].xHrxrbiVNNrvRQEBxypJwgTRgIJS == guid)
							{
								jySsOxfJZoqgcJpcZGpRDTPCFrG = ZHzZYihtnFSsxyDkozkNTJvuWhcG[j].LEhKMDCzIjquVNmJvymqRHMMWifX.owFVkJQkkPDmjBRaHbMOjwVbxEvyb;
								flag = true;
								break;
							}
						}
					}
				}
				sRWhguxFTduLiFMWjcVdhYcRFInQA sRWhguxFTduLiFMWjcVdhYcRFInQA2 = new sRWhguxFTduLiFMWjcVdhYcRFInQA(new GoJaFByXFoZTGNocjTiOVrXyHFHL(jySsOxfJZoqgcJpcZGpRDTPCFrG, zEHnUaZkeTgfFOGLdHJkHGtsJNuWA), oHJnhAkiajYFYWtpEqMaFQxxAxzaA);
				sRWhguxFTduLiFMWjcVdhYcRFInQA2.MvPVDnlBWoKSHHDgvQAtQRcRTWuj = uTyQEMVineRQmjtixsdHzIMSbUZe;
				sRWhguxFTduLiFMWjcVdhYcRFInQA2.LyPjjoyYbFqZzaOyZYPALZWTCYiB = uTyQEMVineRQmjtixsdHzIMSbUZe.DufTLnFXNFNaIAeZbzrKABWvzZRk;
				sRWhguxFTduLiFMWjcVdhYcRFInQA2.xHrxrbiVNNrvRQEBxypJwgTRgIJS = guid;
				sRWhguxFTduLiFMWjcVdhYcRFInQA2.kdVHsgqAFwmFQXnhgRaVDELiKnzC = StringTools.SanitizeDeviceString(uTyQEMVineRQmjtixsdHzIMSbUZe.FeYNFHLhgUivGWxojyZVZwwJgvsj);
				sRWhguxFTduLiFMWjcVdhYcRFInQA2.XoGqGUJoMrNVRXlJrtRoQAmuEAFp = uTyQEMVineRQmjtixsdHzIMSbUZe.KGqdhBHUknswGuNHWGWgROAtaLGuA;
				sRWhguxFTduLiFMWjcVdhYcRFInQA2.ECbQVeJFuMsdgjquINtRyanKvbWb = (ZSovmlhoZKTNRcDjddXShKrptrEEA)uTyQEMVineRQmjtixsdHzIMSbUZe.wJjWoUWIsYyuiGJuBmiAlBQeDNmD;
				WNNmwcNLOEUFiejOlBNPjZMGAxcA wNNmwcNLOEUFiejOlBNPjZMGAxcA = jySsOxfJZoqgcJpcZGpRDTPCFrG.rhVSTskoAdAkZabCrrGFhBOPTGZGA;
				sRWhguxFTduLiFMWjcVdhYcRFInQA2.JdFBDPxbYWufPZDTuiqIfjBXdKCdA = zBNHOAiqFlvGvZvPcFAbGpCWxqMN2.zdfuVksFXiQtCHPlhGPiXWmpEMBKA;
				sRWhguxFTduLiFMWjcVdhYcRFInQA2.BNOftdEcQnhgGcDfbZBdbKAlVXzDA = false;
				try
				{
					sRWhguxFTduLiFMWjcVdhYcRFInQA2.NTPQNZKSPdJyeDkKhWBRWCaCeKUBA = zBNHOAiqFlvGvZvPcFAbGpCWxqMN2.QLEEWiasqjIkNrXoovyLnYZJtFLGA;
				}
				catch (Exception)
				{
					sRWhguxFTduLiFMWjcVdhYcRFInQA2.NTPQNZKSPdJyeDkKhWBRWCaCeKUBA = 0;
				}
				sRWhguxFTduLiFMWjcVdhYcRFInQA2.xYtxjvGiDblMLazxSNoxuZeFGhdo = wNNmwcNLOEUFiejOlBNPjZMGAxcA.arvVDjjfCaXxPtzAkNFMDquUblCb;
				sRWhguxFTduLiFMWjcVdhYcRFInQA2.xPHraTegAQkZKJrJSesorPOqjVNDA = wNNmwcNLOEUFiejOlBNPjZMGAxcA.qSvsSCNmzWuFgnRvwrEmcRuuvYVj;
				sRWhguxFTduLiFMWjcVdhYcRFInQA2.oOgOpJMTHvLxBTmQYOBaWbPGVsrj = wNNmwcNLOEUFiejOlBNPjZMGAxcA.PugBAzAuoucVkJqyOpqMFTzvKhZnA;
				sRWhguxFTduLiFMWjcVdhYcRFInQA2.xlmTdfKZCDokkVelKFHzgEYBOJoyA = new DirectInputControllerExtension(uTyQEMVineRQmjtixsdHzIMSbUZe, jySsOxfJZoqgcJpcZGpRDTPCFrG);
				GWjCBAFuoVLnuGDRLggLtHsjeaYyA(sRWhguxFTduLiFMWjcVdhYcRFInQA2, zBNHOAiqFlvGvZvPcFAbGpCWxqMN2, out sRWhguxFTduLiFMWjcVdhYcRFInQA2.BVxCYjiutEJjufEgJmLVXSIICyDyB);
				try
				{
					string text2;
					try
					{
						text2 = zBNHOAiqFlvGvZvPcFAbGpCWxqMN2.rrbeItDPswvFJuhRZTgGHluLJkcq;
					}
					catch
					{
						text2 = sRWhguxFTduLiFMWjcVdhYcRFInQA2.kdVHsgqAFwmFQXnhgRaVDELiKnzC;
					}
					if (fnVZJGXiEGrAxUQBPRjCjNznMngi.ndfpBRNPOJCrRFKqMKVbSEbfDRVyA((ushort)zBNHOAiqFlvGvZvPcFAbGpCWxqMN2.wlEVOpJLteSEIhAOUIIkDMwszDqu, (ushort)zBNHOAiqFlvGvZvPcFAbGpCWxqMN2.zdfuVksFXiQtCHPlhGPiXWmpEMBKA, text2) && fnVZJGXiEGrAxUQBPRjCjNznMngi.lXjKPysUECVPhNjyuEGhYxkeChOcA((ushort)zBNHOAiqFlvGvZvPcFAbGpCWxqMN2.wlEVOpJLteSEIhAOUIIkDMwszDqu, (ushort)zBNHOAiqFlvGvZvPcFAbGpCWxqMN2.zdfuVksFXiQtCHPlhGPiXWmpEMBKA, text2, out var num, out var num2, out var num3))
					{
						sRWhguxFTduLiFMWjcVdhYcRFInQA2.LEhKMDCzIjquVNmJvymqRHMMWifX.BLMdMbUhiaIuTviYKGKwaHDJolJf(num, num2, num3, fnVZJGXiEGrAxUQBPRjCjNznMngi.SOaeaqcDbodCpWwHTKCmtJWDrtoi((ushort)zBNHOAiqFlvGvZvPcFAbGpCWxqMN2.wlEVOpJLteSEIhAOUIIkDMwszDqu, (ushort)zBNHOAiqFlvGvZvPcFAbGpCWxqMN2.zdfuVksFXiQtCHPlhGPiXWmpEMBKA, text2));
					}
				}
				catch (Exception)
				{
				}
				if (!flag)
				{
					IList<dWyxBkIUPMORAuPdNMABdUWdAyFH> list3 = jySsOxfJZoqgcJpcZGpRDTPCFrG.GAnDYhdhuSOtDqrWkjAZgNebRjyYB();
					if (list3 != null)
					{
						for (int k = 0; k < list3.Count; k++)
						{
							if ((list3[k].VnCKjhlZjGjKyshitkQBEwpkEqYr.VNUwtRupLmFpCYlBzOWAwSxmRjMG & JBcFUjjKPNSJZpmwjTspczQHewI.Axis) != JBcFUjjKPNSJZpmwjTspczQHewI.All)
							{
								jySsOxfJZoqgcJpcZGpRDTPCFrG.ZVHWpcVAPAcfasMqWKZyxBQxZmuU.WVKkuUZceXyeWsplLFNIdUMcypvhA = new eUjSHhffpbkQhyNTubjChIsBwUjoA(-65535, 65535);
							}
						}
					}
					jySsOxfJZoqgcJpcZGpRDTPCFrG.ZVHWpcVAPAcfasMqWKZyxBQxZmuU.iUiSHlEwBCTtkvjyzsPSAdMgLJJW = qDwpdtTfRkhdnGDIHALbGofolwYWA.Absolute;
					jySsOxfJZoqgcJpcZGpRDTPCFrG.zZGNrjFLuoODfJcClPGrwgFNiidr(CtdJOYEwhxjrpRQeawTCaFreRfme, FuopIwTCHdMUYdIhayaGZsrVbKor.NonExclusive | FuopIwTCHdMUYdIhayaGZsrVbKor.Background);
					jySsOxfJZoqgcJpcZGpRDTPCFrG.lKudTReqXTqfadBHhkYChczUaimMB();
				}
				list.Add(new UMUepdaKdkdtNySEjpdHJaUZqWOBA(sRWhguxFTduLiFMWjcVdhYcRFInQA2, uTyQEMVineRQmjtixsdHzIMSbUZe));
				end_IL_0028:;
			}
			catch (Exception)
			{
			}
		}
		return list;
	}

	private void tZAjRGSldlfLcsiejFLojqVqrPTNA()
	{
		JUrckYfjnGExHbzIPmfyeFmeEVNJc(XrJHHBzfBqYLqHRIvMMBXVUIkned());
	}

	private void JUrckYfjnGExHbzIPmfyeFmeEVNJc(List<UMUepdaKdkdtNySEjpdHJaUZqWOBA> P_0)
	{
		List<sRWhguxFTduLiFMWjcVdhYcRFInQA> list = new List<sRWhguxFTduLiFMWjcVdhYcRFInQA>();
		tmhkvuKhFlRJovziggLsMVkBZrqH = 0;
		int num = P_0?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			if (P_0[i] == null || !P_0[i].NgnhJCDZlPGbJlMmKRAkgIoNfGJq)
			{
				continue;
			}
			try
			{
				sRWhguxFTduLiFMWjcVdhYcRFInQA mckLyxGfPwPIGZyqtqBTEKZVSWKf = P_0[i].MckLyxGfPwPIGZyqtqBTEKZVSWKf;
				mckLyxGfPwPIGZyqtqBTEKZVSWKf.NePpfUgiQEmSHBTSVMgPUmsQwQQC();
				if (mckLyxGfPwPIGZyqtqBTEKZVSWKf.mvMSNzRJmiwRoenbTArzzjFuKifE)
				{
					tmhkvuKhFlRJovziggLsMVkBZrqH++;
				}
				list.Add(mckLyxGfPwPIGZyqtqBTEKZVSWKf);
			}
			catch (Exception)
			{
			}
		}
		HqCbeqLToJfsvdEWCPUViweidGMDA.rtwMPTzWhYVIhLcKjaKorafNjiSj(tmhkvuKhFlRJovziggLsMVkBZrqH);
		lock (CBQnUOOlgOcflOrdNpEIMEhzsZJV)
		{
			List<sRWhguxFTduLiFMWjcVdhYcRFInQA> zHzZYihtnFSsxyDkozkNTJvuWhcG = ZHzZYihtnFSsxyDkozkNTJvuWhcG;
			int num2 = xMEalByuJuVkiiLUjsoNHUDKmwsm;
			int count = list.Count;
			tSqhEkupdYycLqZrOhaojwTMtfbI(num2, count, zHzZYihtnFSsxyDkozkNTJvuWhcG, list);
			for (int j = 0; j < count; j++)
			{
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(list[j]));
				}
			}
			nNlOsqWmDpgVJLIyywLsmgjhZRN(zHzZYihtnFSsxyDkozkNTJvuWhcG, list, false);
			nNlOsqWmDpgVJLIyywLsmgjhZRN(list, zHzZYihtnFSsxyDkozkNTJvuWhcG, true);
			gVjvCelOeDrGnajryfzAAgocmWJIA(list, zHzZYihtnFSsxyDkozkNTJvuWhcG);
			ZHzZYihtnFSsxyDkozkNTJvuWhcG = list;
			xMEalByuJuVkiiLUjsoNHUDKmwsm = list.Count;
		}
	}

	private void GWjCBAFuoVLnuGDRLggLtHsjeaYyA(sRWhguxFTduLiFMWjcVdhYcRFInQA P_0, zBNHOAiqFlvGvZvPcFAbGpCWxqMN P_1, out string P_2)
	{
		P_2 = string.Empty;
		if (P_0 == null || P_1 == null)
		{
			return;
		}
		string text = isCygitBHPQRrMjESfQLjRwkTPGNA.TldUsuGQbBmoJvOLgIqpoURbHFHl(P_1.VLTgKPRWXpYtQNFGpcIQkAFzxfyK);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		try
		{
			SIYuejvQjndRFJfAYGpZwmWjVrTh sIYuejvQjndRFJfAYGpZwmWjVrTh = RciGSOAIVzSFNUsWuoeDdCDjeMbbc.XdzHDJqVVCfFvvGHqtrjAILmCqBp(text.ToLower(CultureInfo.InvariantCulture));
			if (sIYuejvQjndRFJfAYGpZwmWjVrTh != null)
			{
				P_0.mvMSNzRJmiwRoenbTArzzjFuKifE = sIYuejvQjndRFJfAYGpZwmWjVrTh.UOsRCkLusRFOaQvLUafVGsFIkXzU;
				P_0.XrYtFEBYJvRVGjJoLgKeQTOEhtZS = sIYuejvQjndRFJfAYGpZwmWjVrTh.MTwhczrOWjxUMrNMBtosGjhrMsHd;
				P_2 = JqoBfisQKbNTMkNdWslkfAHzLkfW.qeSsqmKLpFsMTLWPbRhxnqBEIese(sIYuejvQjndRFJfAYGpZwmWjVrTh, P_0.XoGqGUJoMrNVRXlJrtRoQAmuEAFp, P_0.kdVHsgqAFwmFQXnhgRaVDELiKnzC, P_0.XrYtFEBYJvRVGjJoLgKeQTOEhtZS);
				sIYuejvQjndRFJfAYGpZwmWjVrTh.Dispose();
			}
		}
		catch (Exception)
		{
		}
	}

	private void MnzvUSKuKYjVLQTESKWIDfyThUXP()
	{
		lock (CBQnUOOlgOcflOrdNpEIMEhzsZJV)
		{
			for (int i = 0; i < xMEalByuJuVkiiLUjsoNHUDKmwsm; i++)
			{
				try
				{
					sRWhguxFTduLiFMWjcVdhYcRFInQA sRWhguxFTduLiFMWjcVdhYcRFInQA2 = ZHzZYihtnFSsxyDkozkNTJvuWhcG[i];
					if (sRWhguxFTduLiFMWjcVdhYcRFInQA2 != null && sRWhguxFTduLiFMWjcVdhYcRFInQA2.DhrJtKCAwUfVKoSlSdFAGeepgdmcb() && (YogAZbtYYniRhKJTUxmdWNvJBxiaA == null || !sRWhguxFTduLiFMWjcVdhYcRFInQA2.BNOftdEcQnhgGcDfbZBdbKAlVXzDA))
					{
						sRWhguxFTduLiFMWjcVdhYcRFInQA2.Update();
					}
				}
				catch
				{
				}
			}
		}
	}

	private IList<UTyQEMVineRQmjtixsdHzIMSbUZe> eEWjrHkpGgHFbpVbZjMhYriFiBXT()
	{
		try
		{
			IList<UTyQEMVineRQmjtixsdHzIMSbUZe> list = whwuTJYaLgxeZAfnAEucFFrjvBULA.yyUZqaQkYUtCDGgAKGpXlflpfnLGA(cOhhDjZBePQFVLMIFaodEQtjsqZJA.GameControl, OJZMDLzBRIdZoAVPTbqRprFJTssS.AttachedOnly);
			qOzZIntLkvYISSNuPeKaENsgOPnSA = list?.Count ?? 0;
			return list;
		}
		catch
		{
			Logger.LogError("Error getting devices from Direct Input!");
			qOzZIntLkvYISSNuPeKaENsgOPnSA = 0;
			return EmptyObjects<UTyQEMVineRQmjtixsdHzIMSbUZe>.EmptyReadOnlyIListT;
		}
	}

	private void BsvzduDyWICowlvigOabRcEZkQRh()
	{
		whwuTJYaLgxeZAfnAEucFFrjvBULA.QKJAIoPFdeHlylwrDmKifuZEFCLM();
	}

	private void tSqhEkupdYycLqZrOhaojwTMtfbI(int P_0, int P_1, List<sRWhguxFTduLiFMWjcVdhYcRFInQA> P_2, List<sRWhguxFTduLiFMWjcVdhYcRFInQA> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(sRWhguxFTduLiFMWjcVdhYcRFInQA.MaHNPbukMvhNsjiKXynApvxdIHwb);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			MxrMPRAYmPNolqtEdgFnhfdlPBGL(P_1, P_3, P_0, P_2, GXOIDzdmNbFcAUakNJOCqLeoabiIA.geTeHZdFgVspURilkonNERpBTdkuA.Exact);
		}
		exzikOzkLxhRrJrTUjonIsxDJGikA(P_1, P_3, GXOIDzdmNbFcAUakNJOCqLeoabiIA.geTeHZdFgVspURilkonNERpBTdkuA.Exact);
		for (int i = 0; i < P_1; i++)
		{
			sRWhguxFTduLiFMWjcVdhYcRFInQA sRWhguxFTduLiFMWjcVdhYcRFInQA2 = P_3[i];
			if (sRWhguxFTduLiFMWjcVdhYcRFInQA2 != null && sRWhguxFTduLiFMWjcVdhYcRFInQA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				sRWhguxFTduLiFMWjcVdhYcRFInQA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = VYimXBgkPpqtalTesQDCSwoEBOTt(P_3);
				sRWhguxFTduLiFMWjcVdhYcRFInQA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = BkidUCzjOLEuGhmYoVrAAfUVmqCtA();
				FJppIHudvgmvNdFWNZbgFBUqXXNT.kkrDGBiDxIrcbQXrAkEcvrJfUchH(sRWhguxFTduLiFMWjcVdhYcRFInQA2);
			}
		}
		P_3.Sort(sRWhguxFTduLiFMWjcVdhYcRFInQA.DTRunQGmGQuzYtENRhUbHfCjEahQ);
	}

	private void pkrFAGlNGWWrkMoDmymHnkIdTRkU(List<sRWhguxFTduLiFMWjcVdhYcRFInQA> P_0, int P_1, int P_2)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (i != P_1 && P_0[i] != null && P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == P_2)
			{
				P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = -1;
			}
		}
	}

	private bool WWbCyeGpIcYwNxtMZVseyeaobiNl(List<sRWhguxFTduLiFMWjcVdhYcRFInQA> P_0, int P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == P_1)
			{
				return false;
			}
		}
		return true;
	}

	private int VYimXBgkPpqtalTesQDCSwoEBOTt(List<sRWhguxFTduLiFMWjcVdhYcRFInQA> P_0)
	{
		int num = 0;
		while (true)
		{
			bool flag = false;
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == num)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				break;
			}
			num++;
		}
		return num;
	}

	private bool uAwIFIBnxGbxOwIQWeRqPvHcbDIB(List<sRWhguxFTduLiFMWjcVdhYcRFInQA> P_0, int P_1)
	{
		if (P_0 == null)
		{
			return false;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void MxrMPRAYmPNolqtEdgFnhfdlPBGL(int P_0, List<sRWhguxFTduLiFMWjcVdhYcRFInQA> P_1, int P_2, List<sRWhguxFTduLiFMWjcVdhYcRFInQA> P_3, GXOIDzdmNbFcAUakNJOCqLeoabiIA.geTeHZdFgVspURilkonNERpBTdkuA P_4)
	{
		int num = ((P_4 != GXOIDzdmNbFcAUakNJOCqLeoabiIA.geTeHZdFgVspURilkonNERpBTdkuA.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			sRWhguxFTduLiFMWjcVdhYcRFInQA sRWhguxFTduLiFMWjcVdhYcRFInQA2 = P_1[i];
			if (sRWhguxFTduLiFMWjcVdhYcRFInQA2 == null || sRWhguxFTduLiFMWjcVdhYcRFInQA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				sRWhguxFTduLiFMWjcVdhYcRFInQA sRWhguxFTduLiFMWjcVdhYcRFInQA3 = P_3[j];
				if (sRWhguxFTduLiFMWjcVdhYcRFInQA3 != null && !uAwIFIBnxGbxOwIQWeRqPvHcbDIB(P_1, sRWhguxFTduLiFMWjcVdhYcRFInQA3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && sRWhguxFTduLiFMWjcVdhYcRFInQA2.MYNEgUiFzAzYachDdQnoWiANidlP(sRWhguxFTduLiFMWjcVdhYcRFInQA3) >= num)
				{
					sRWhguxFTduLiFMWjcVdhYcRFInQA2.qEeBDOrDIFcYbVMGeYumABKSHCVAA(sRWhguxFTduLiFMWjcVdhYcRFInQA3);
					FJppIHudvgmvNdFWNZbgFBUqXXNT.kkrDGBiDxIrcbQXrAkEcvrJfUchH(sRWhguxFTduLiFMWjcVdhYcRFInQA2);
				}
			}
		}
	}

	private void exzikOzkLxhRrJrTUjonIsxDJGikA(int P_0, List<sRWhguxFTduLiFMWjcVdhYcRFInQA> P_1, GXOIDzdmNbFcAUakNJOCqLeoabiIA.geTeHZdFgVspURilkonNERpBTdkuA P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			sRWhguxFTduLiFMWjcVdhYcRFInQA sRWhguxFTduLiFMWjcVdhYcRFInQA2 = P_1[i];
			if (sRWhguxFTduLiFMWjcVdhYcRFInQA2 == null || sRWhguxFTduLiFMWjcVdhYcRFInQA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			GXOIDzdmNbFcAUakNJOCqLeoabiIA.WImaMAlLjNLgNoSkaFbyfizQlBAI wImaMAlLjNLgNoSkaFbyfizQlBAI = null;
			foreach (GXOIDzdmNbFcAUakNJOCqLeoabiIA.WImaMAlLjNLgNoSkaFbyfizQlBAI item in FJppIHudvgmvNdFWNZbgFBUqXXNT.OJNETAjTiPjhBCULvdSUsDpJmwBH(sRWhguxFTduLiFMWjcVdhYcRFInQA2, P_2))
			{
				if (!uAwIFIBnxGbxOwIQWeRqPvHcbDIB(P_1, item.oIOoYvxHGXBgNloMifwuRPqXxHED) && item.jBTsiwtECjADvCeprmlnxneXtOgaA >= 0)
				{
					wImaMAlLjNLgNoSkaFbyfizQlBAI = item;
					break;
				}
			}
			if (wImaMAlLjNLgNoSkaFbyfizQlBAI != null)
			{
				int num = wImaMAlLjNLgNoSkaFbyfizQlBAI.jBTsiwtECjADvCeprmlnxneXtOgaA;
				if (!WWbCyeGpIcYwNxtMZVseyeaobiNl(P_1, num))
				{
					num = (wImaMAlLjNLgNoSkaFbyfizQlBAI.jBTsiwtECjADvCeprmlnxneXtOgaA = VYimXBgkPpqtalTesQDCSwoEBOTt(P_1));
				}
				sRWhguxFTduLiFMWjcVdhYcRFInQA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				sRWhguxFTduLiFMWjcVdhYcRFInQA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = wImaMAlLjNLgNoSkaFbyfizQlBAI.oIOoYvxHGXBgNloMifwuRPqXxHED;
				FJppIHudvgmvNdFWNZbgFBUqXXNT.kkrDGBiDxIrcbQXrAkEcvrJfUchH(sRWhguxFTduLiFMWjcVdhYcRFInQA2);
			}
		}
	}

	private void NfIYspzzEbqBQSdIVBCweyLgtoVTA()
	{
		if (nXxddzEtcsAotCnVlnqXqIhshooZ)
		{
			XDHwtrOmcdglfzprMPPyisWDrWKJ();
		}
		if (SgThyzipPeacTHmoeFlIZhUNCUrf.TPoeWwEYcJhWohaeHjOgcVjxblcSA && SgThyzipPeacTHmoeFlIZhUNCUrf.VWKJlWBJsiHHmQEXkCqAcjYYeDisA())
		{
			mvaiujfAmteqWhIFjXFAFplxkBPB(SgThyzipPeacTHmoeFlIZhUNCUrf.FFWjswuhFTDsWeZHbKPsbmwJBlek);
		}
	}

	private void XDHwtrOmcdglfzprMPPyisWDrWKJ()
	{
		nXxddzEtcsAotCnVlnqXqIhshooZ = false;
		if (!SgThyzipPeacTHmoeFlIZhUNCUrf.TPoeWwEYcJhWohaeHjOgcVjxblcSA)
		{
			SgThyzipPeacTHmoeFlIZhUNCUrf.tGmkFOBGLIStwNoiokXgtfxSMCi();
		}
	}

	private void mvaiujfAmteqWhIFjXFAFplxkBPB(List<UMUepdaKdkdtNySEjpdHJaUZqWOBA> P_0)
	{
		if (hsEvrJoctkqqFHAzgPqyhuGepWDg(UMUepdaKdkdtNySEjpdHJaUZqWOBA.EcLMgpwJDHQpEOgDyqysmnDBrDNT(P_0)))
		{
			JUrckYfjnGExHbzIPmfyeFmeEVNJc(P_0);
		}
	}

	private bool hsEvrJoctkqqFHAzgPqyhuGepWDg(IList<UTyQEMVineRQmjtixsdHzIMSbUZe> P_0)
	{
		lock (CBQnUOOlgOcflOrdNpEIMEhzsZJV)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && !dmVOjBTmkszQSlOGkhgKBBPQkfdq(P_0[i].gPdNFUoLpXnWxHqaioqXdBJsVuWK))
				{
					return true;
				}
			}
			int count2 = ZHzZYihtnFSsxyDkozkNTJvuWhcG.Count;
			for (int j = 0; j < count2; j++)
			{
				if (ZHzZYihtnFSsxyDkozkNTJvuWhcG[j] != null && !wPpCPTBAmwjcldLnsjwbiIHuihSFA(P_0, ZHzZYihtnFSsxyDkozkNTJvuWhcG[j].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool dmVOjBTmkszQSlOGkhgKBBPQkfdq(Guid P_0)
	{
		lock (CBQnUOOlgOcflOrdNpEIMEhzsZJV)
		{
			int count = ZHzZYihtnFSsxyDkozkNTJvuWhcG.Count;
			for (int i = 0; i < count; i++)
			{
				if (ZHzZYihtnFSsxyDkozkNTJvuWhcG[i] != null && ZHzZYihtnFSsxyDkozkNTJvuWhcG[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == P_0)
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool wPpCPTBAmwjcldLnsjwbiIHuihSFA(IList<UTyQEMVineRQmjtixsdHzIMSbUZe> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].gPdNFUoLpXnWxHqaioqXdBJsVuWK == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void nNlOsqWmDpgVJLIyywLsmgjhZRN(List<sRWhguxFTduLiFMWjcVdhYcRFInQA> P_0, List<sRWhguxFTduLiFMWjcVdhYcRFInQA> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			sRWhguxFTduLiFMWjcVdhYcRFInQA sRWhguxFTduLiFMWjcVdhYcRFInQA2 = P_0[i];
			if (sRWhguxFTduLiFMWjcVdhYcRFInQA2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					sRWhguxFTduLiFMWjcVdhYcRFInQA sRWhguxFTduLiFMWjcVdhYcRFInQA3 = P_1[j];
					if (sRWhguxFTduLiFMWjcVdhYcRFInQA3 != null && sRWhguxFTduLiFMWjcVdhYcRFInQA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == sRWhguxFTduLiFMWjcVdhYcRFInQA3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				pDUQGYHzqWgtVvQyuIjVerqREkyc(P_0[i], P_2);
			}
		}
	}

	private void pDUQGYHzqWgtVvQyuIjVerqREkyc(sRWhguxFTduLiFMWjcVdhYcRFInQA P_0, bool P_1)
	{
		if (P_1)
		{
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0.ToBridgedController());
			}
		}
		else if (_DeviceDisconnectedEvent != null)
		{
			_DeviceDisconnectedEvent(P_0.ToControllerDisconnectedEventArgs());
		}
	}

	private bool KIxlraCEXZXUlAPYaBmFDjMybqGS()
	{
		int num = whwuTJYaLgxeZAfnAEucFFrjvBULA.upqnBoQPZJgbrHEIukWrKpnKwcPk(cOhhDjZBePQFVLMIFaodEQtjsqZJA.GameControl, OJZMDLzBRIdZoAVPTbqRprFJTssS.AttachedOnly);
		if (qOzZIntLkvYISSNuPeKaENsgOPnSA != num)
		{
			qOzZIntLkvYISSNuPeKaENsgOPnSA = num;
			return true;
		}
		if (tmhkvuKhFlRJovziggLsMVkBZrqH > 0 && HqCbeqLToJfsvdEWCPUViweidGMDA.pVlQJawNFpUUfwyZVgGouycQGUMI())
		{
			return true;
		}
		return false;
	}

	private void gVjvCelOeDrGnajryfzAAgocmWJIA(List<sRWhguxFTduLiFMWjcVdhYcRFInQA> P_0, List<sRWhguxFTduLiFMWjcVdhYcRFInQA> P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		for (int i = 0; i < P_1.Count; i++)
		{
			if (P_1[i] != null && (P_0 == null || !P_0.Contains(P_1[i])))
			{
				P_1[i].TxOAEXFpROagqefiitDqiiVidAAMe();
			}
		}
	}

	[Conditional("DEBUGTHIS")]
	private void RsrloodCxNfoJktqjWRcscjVLopzA(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private List<UMUepdaKdkdtNySEjpdHJaUZqWOBA> yqIASSdNspQjQvicIioybNXAQTvW()
	{
		return XrJHHBzfBqYLqHRIvMMBXVUIkned();
	}
}
