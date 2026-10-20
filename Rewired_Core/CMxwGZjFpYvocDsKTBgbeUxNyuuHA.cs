using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Platforms.UnityInputManager;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class CMxwGZjFpYvocDsKTBgbeUxNyuuHA : PlatformInputManager
{
	private class VoOQpLoLKgCpKjxOPbvjRKkipUrbA : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int RBorSRtimpFMYhGrxqvHNdTtPTtKA;

		private int fGuAcWJWRWhAlwhFQIHsZEPobfPfb;

		private int zUphQPLvWUIMgfCFiAnbLGeGDtNk;

		public Guid vVofktphzRTClPhUqRXtxUNKERoW;

		public string LxNUwrsOyaLbSCktWsovNTBJPCVj;

		public int QjuwQrDOUEtPfUgKjSQBGnDmjfrv;

		public string gSdEeBAocoWvxPvcVbsEjiImGKAgb;

		public string SeGhXJiUUqIfxQjlilZWYGtRlYxhA;

		public string jVVTFHNnsaTSLBCOhBsDgdhtdMRiA;

		private bool KbUUxeCwsIolOnEKMtqlFRPZsyNl;

		private int hUqEYhczQVbsaxdLZhvTHsvGOwjW = 29;

		private int MlkAREanYIqlEYgKGyvbbnLMFrcJ = 20;

		private float[] EcaudSGIIlYzyTPKxtGJGKDSLvex;

		private bool[] LAxvzhSRZpYWoeYnZwENoDKvgLyv;

		private bool[] CnsdDzHsFprtFEKxbhdcPBatzhKOB;

		private float[] yJtZoxXGLYQgkSTqDRYVjBWydBaH;

		private bool[] sNQjdXXayWGtyKbRLSOLHJIsdNbcA;

		private HardwareJoystickMap_InputManager OWmxnyyqbDkFNTwwUnhQRXFdjFAj;

		private bool mWPdSIGOusPqxTPSqYHPpnaVeFdr;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return RBorSRtimpFMYhGrxqvHNdTtPTtKA;
			}
			set
			{
				RBorSRtimpFMYhGrxqvHNdTtPTtKA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return fGuAcWJWRWhAlwhFQIHsZEPobfPfb;
			}
			set
			{
				fGuAcWJWRWhAlwhFQIHsZEPobfPfb = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (!(LxNUwrsOyaLbSCktWsovNTBJPCVj != "Unknown Controller"))
				{
					return gSdEeBAocoWvxPvcVbsEjiImGKAgb;
				}
				return LxNUwrsOyaLbSCktWsovNTBJPCVj;
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (zUphQPLvWUIMgfCFiAnbLGeGDtNk < 1)
				{
					return null;
				}
				return zUphQPLvWUIMgfCFiAnbLGeGDtNk;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId
		{
			get
			{
				return zUphQPLvWUIMgfCFiAnbLGeGDtNk;
			}
			set
			{
				zUphQPLvWUIMgfCFiAnbLGeGDtNk = value;
			}
		}

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid
		{
			get
			{
				if ((ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull) || UnityTools.effectivePlatform == Platform.OSX)
				{
					return MiscTools.CreateGuidHashSHA1(Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename);
				}
				if (UnityTools.isIOSPlatform)
				{
					return MiscTools.CreateGuidHashSHA1(gSdEeBAocoWvxPvcVbsEjiImGKAgb);
				}
				return MiscTools.CreateGuidHashSHA1(Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename + "_" + zUphQPLvWUIMgfCFiAnbLGeGDtNk);
			}
		}

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension => null;

		public int IikyRUMHORYvNoluuenOLuHUGPKG => MlkAREanYIqlEYgKGyvbbnLMFrcJ;

		public int oOwIQtWSPqzHBTolYbpTEHzMYoeB => hUqEYhczQVbsaxdLZhvTHsvGOwjW;

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

		public VoOQpLoLKgCpKjxOPbvjRKkipUrbA()
		{
			fGuAcWJWRWhAlwhFQIHsZEPobfPfb = -1;
			RBorSRtimpFMYhGrxqvHNdTtPTtKA = -1;
			zUphQPLvWUIMgfCFiAnbLGeGDtNk = 0;
		}

		public void hrpxQJVNPbwxNBhVlcBMzGVBAgcu()
		{
			SQdDRvaDPwUxXduyqKVhwtqSLhEaA();
			vVofktphzRTClPhUqRXtxUNKERoW = OWmxnyyqbDkFNTwwUnhQRXFdjFAj.hardwareMapIdentifier.guid;
			LxNUwrsOyaLbSCktWsovNTBJPCVj = OWmxnyyqbDkFNTwwUnhQRXFdjFAj.controllerName;
			EcaudSGIIlYzyTPKxtGJGKDSLvex = new float[hUqEYhczQVbsaxdLZhvTHsvGOwjW];
			LAxvzhSRZpYWoeYnZwENoDKvgLyv = new bool[MlkAREanYIqlEYgKGyvbbnLMFrcJ];
			CnsdDzHsFprtFEKxbhdcPBatzhKOB = new bool[hUqEYhczQVbsaxdLZhvTHsvGOwjW];
			sNQjdXXayWGtyKbRLSOLHJIsdNbcA = new bool[29];
			yJtZoxXGLYQgkSTqDRYVjBWydBaH = new float[29];
			Update();
			if (UnityTools.platform == Platform.tvOS && KbUUxeCwsIolOnEKMtqlFRPZsyNl)
			{
				ConfigVars.PlatformVars_tvOS platformVars_tvOS = ReInput.configVars.platformVars_tvOS;
				if (platformVars_tvOS != null)
				{
					UnityTools.externalTools.tvOS_allowRemoteRotation = platformVars_tvOS.allowRemoteDPadRotation;
					UnityTools.externalTools.tvOS_remoteReportAbsoluteDpadValues = platformVars_tvOS.useAbsoluteRemoteTouchpadMode;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (zUphQPLvWUIMgfCFiAnbLGeGDtNk > 0)
			{
				NGsDDZcrBPcVXUdTUvbyMHwHDbLhb();
				XLNptFxQfEgbZEeQhslgMLMyoujA();
				ZxJNywsiZCbvamDClZFNODhFhVJgA();
			}
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public int lHHRWanCFNinYhDEBpEPumeIwbeBA(VoOQpLoLKgCpKjxOPbvjRKkipUrbA P_0)
		{
			if (IikyRUMHORYvNoluuenOLuHUGPKG != P_0.IikyRUMHORYvNoluuenOLuHUGPKG || oOwIQtWSPqzHBTolYbpTEHzMYoeB != P_0.oOwIQtWSPqzHBTolYbpTEHzMYoeB)
			{
				return 0;
			}
			if ((!string.IsNullOrEmpty(SeGhXJiUUqIfxQjlilZWYGtRlYxhA) || !string.IsNullOrEmpty(P_0.SeGhXJiUUqIfxQjlilZWYGtRlYxhA)) && !string.Equals(SeGhXJiUUqIfxQjlilZWYGtRlYxhA, P_0.SeGhXJiUUqIfxQjlilZWYGtRlYxhA, StringComparison.Ordinal))
			{
				return 0;
			}
			if (P_0.gSdEeBAocoWvxPvcVbsEjiImGKAgb == gSdEeBAocoWvxPvcVbsEjiImGKAgb && P_0.QjuwQrDOUEtPfUgKjSQBGnDmjfrv == QjuwQrDOUEtPfUgKjSQBGnDmjfrv)
			{
				return 2;
			}
			if (P_0.gSdEeBAocoWvxPvcVbsEjiImGKAgb == gSdEeBAocoWvxPvcVbsEjiImGKAgb)
			{
				return 1;
			}
			return 0;
		}

		private void GwlvBFnWUVtFIjqXtsaUSlCngewAA(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.Fallback;
			P_0.inputSource = QVoqPnGeibISqkcfPCgYAlAeyLFgB();
			P_0.hardwareIdentifier = cxpuBrGQPrDFkkDVlbyrAsGLMfHWA();
			P_0.hardwareAxisCount = 0;
			P_0.hardwareButtonCount = 0;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = gSdEeBAocoWvxPvcVbsEjiImGKAgb;
		}

		private void GPftHNLpDvIylrWRIEQVzwUwHAYE(BridgedController P_0)
		{
			GwlvBFnWUVtFIjqXtsaUSlCngewAA(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = OWmxnyyqbDkFNTwwUnhQRXFdjFAj.ToGameHardwareControllerMap();
			P_0.instanceName = gSdEeBAocoWvxPvcVbsEjiImGKAgb;
			P_0.productName = gSdEeBAocoWvxPvcVbsEjiImGKAgb;
			P_0.isXInputDevice = false;
			P_0.axisCount = hUqEYhczQVbsaxdLZhvTHsvGOwjW;
			P_0.buttonCount = MlkAREanYIqlEYgKGyvbbnLMFrcJ;
			P_0.controllerTypeGuid = vVofktphzRTClPhUqRXtxUNKERoW;
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (hUqEYhczQVbsaxdLZhvTHsvGOwjW != dataUpdater.axisCount || MlkAREanYIqlEYgKGyvbbnLMFrcJ != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			float[] axisValues = dataUpdater.axisValues;
			bool[] axisHasBeenPressedOSXLinux = dataUpdater.axisHasBeenPressedOSXLinux;
			for (int i = 0; i < hUqEYhczQVbsaxdLZhvTHsvGOwjW; i++)
			{
				if (axisValues[i] != EcaudSGIIlYzyTPKxtGJGKDSLvex[i])
				{
					axisValues[i] = EcaudSGIIlYzyTPKxtGJGKDSLvex[i];
					if (axisHasBeenPressedOSXLinux[i] != CnsdDzHsFprtFEKxbhdcPBatzhKOB[i])
					{
						axisHasBeenPressedOSXLinux[i] = CnsdDzHsFprtFEKxbhdcPBatzhKOB[i];
					}
				}
			}
			bool[] buttonValues = dataUpdater.buttonValues;
			for (int j = 0; j < MlkAREanYIqlEYgKGyvbbnLMFrcJ; j++)
			{
				if (buttonValues[j] != LAxvzhSRZpYWoeYnZwENoDKvgLyv[j])
				{
					buttonValues[j] = LAxvzhSRZpYWoeYnZwENoDKvgLyv[j];
				}
			}
			if (mWPdSIGOusPqxTPSqYHPpnaVeFdr && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public void zvtAEIwXhOwXvFnEuQbXMrCROGSE(int P_0)
		{
			if (P_0 >= 1 && P_0 <= 16)
			{
				Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId = P_0;
			}
		}

		public void XpRCQGfIfStTdkXRxfPFrOlKhkFd()
		{
			zUphQPLvWUIMgfCFiAnbLGeGDtNk = 0;
			nQJsHnqbSKlbouumHLCUGXNXNThl();
		}

		public BridgedControllerHWInfo QQCIsBpXUSpayvBAyQQBzDDXvDjm()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			GwlvBFnWUVtFIjqXtsaUSlCngewAA(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			GPftHNLpDvIylrWRIEQVzwUwHAYE(bridgedController);
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
			return new ControllerDisconnectedEventArgs(RBorSRtimpFMYhGrxqvHNdTtPTtKA);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void NGsDDZcrBPcVXUdTUvbyMHwHDbLhb()
		{
			for (int i = 0; i < 29; i++)
			{
				float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(zUphQPLvWUIMgfCFiAnbLGeGDtNk, i);
				if (yJtZoxXGLYQgkSTqDRYVjBWydBaH[i] != joystickAxisValueByJoystickId)
				{
					yJtZoxXGLYQgkSTqDRYVjBWydBaH[i] = joystickAxisValueByJoystickId;
					if (!sNQjdXXayWGtyKbRLSOLHJIsdNbcA[i] && joystickAxisValueByJoystickId != 0f)
					{
						sNQjdXXayWGtyKbRLSOLHJIsdNbcA[i] = true;
					}
				}
			}
		}

		private void XLNptFxQfEgbZEeQhslgMLMyoujA()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_Fallback_Base)OWmxnyyqbDkFNTwwUnhQRXFdjFAj.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (axes_orig[i] == null)
				{
					continue;
				}
				if (i >= hUqEYhczQVbsaxdLZhvTHsvGOwjW)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				float num = cRnloddLIJktumCSVYgaeRgnhqJK(axes_orig[i]);
				if (EcaudSGIIlYzyTPKxtGJGKDSLvex[i] == num)
				{
					continue;
				}
				EcaudSGIIlYzyTPKxtGJGKDSLvex[i] = num;
				if (!CnsdDzHsFprtFEKxbhdcPBatzhKOB[i])
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis)
					{
						float num2 = NviKkvAyywviTWbAAeQweBzkWick(axes_orig[i].sourceAxis);
						CnsdDzHsFprtFEKxbhdcPBatzhKOB[i] = num2 != 0f;
					}
					else
					{
						CnsdDzHsFprtFEKxbhdcPBatzhKOB[i] = true;
					}
				}
				if (!mWPdSIGOusPqxTPSqYHPpnaVeFdr && EcaudSGIIlYzyTPKxtGJGKDSLvex[i] != 0f)
				{
					mWPdSIGOusPqxTPSqYHPpnaVeFdr = true;
				}
			}
		}

		private void ZxJNywsiZCbvamDClZFNODhFhVJgA()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_Fallback_Base)OWmxnyyqbDkFNTwwUnhQRXFdjFAj.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= MlkAREanYIqlEYgKGyvbbnLMFrcJ)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				bool flag = howIadStXwQTcQukzAcUWbjqpMDW(buttons_orig[i]);
				if (LAxvzhSRZpYWoeYnZwENoDKvgLyv[i] != flag)
				{
					LAxvzhSRZpYWoeYnZwENoDKvgLyv[i] = flag;
					if (!mWPdSIGOusPqxTPSqYHPpnaVeFdr && LAxvzhSRZpYWoeYnZwENoDKvgLyv[i])
					{
						mWPdSIGOusPqxTPSqYHPpnaVeFdr = true;
					}
				}
			}
		}

		private bool howIadStXwQTcQukzAcUWbjqpMDW(HardwareJoystickMap.Platform_Fallback_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (bhKvJvvQJzOdzatmjwRrYseRjCLS(P_0.ignoreIfButtonsActiveButtons[i]))
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
						if (!bhKvJvvQJzOdzatmjwRrYseRjCLS(P_0.requiredButtons[j]))
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
				if (P_0.sourceButton == UnityButton.None)
				{
					return false;
				}
				return bhKvJvvQJzOdzatmjwRrYseRjCLS(P_0.sourceButton);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return false;
				}
				float num = NviKkvAyywviTWbAAeQweBzkWick(P_0.sourceAxis);
				if (MathTools.Abs(num) <= P_0.axisDeadZone)
				{
					return false;
				}
				if (P_0.sourceAxisPole == Pole.Positive && num < 0f)
				{
					return false;
				}
				if (P_0.sourceAxisPole == Pole.Negative && num > 0f)
				{
					return false;
				}
				return true;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				if (P_0.unityHat_sourceAxis1 == UnityAxis.None || P_0.unityHat_sourceAxis2 == UnityAxis.None)
				{
					return false;
				}
				UnityAxis unityHat_sourceAxis = P_0.unityHat_sourceAxis1;
				UnityAxis unityHat_sourceAxis2 = P_0.unityHat_sourceAxis2;
				float num2 = NviKkvAyywviTWbAAeQweBzkWick(unityHat_sourceAxis);
				float num3 = NviKkvAyywviTWbAAeQweBzkWick(unityHat_sourceAxis2);
				float x;
				float y;
				if (P_0.unityHat_checkNeverPressed)
				{
					if (xQFerQnSRVcAQJxTgxBJPmUuwfTVA(unityHat_sourceAxis) || xQFerQnSRVcAQJxTgxBJPmUuwfTVA(unityHat_sourceAxis2))
					{
						x = P_0.unityHat_zeroValues.x;
						y = P_0.unityHat_zeroValues.y;
					}
					else
					{
						x = P_0.unityHat_neverPressedZeroValues.x;
						y = P_0.unityHat_neverPressedZeroValues.y;
					}
				}
				else
				{
					x = P_0.unityHat_zeroValues.x;
					y = P_0.unityHat_zeroValues.y;
				}
				if (MathTools.Approximately(num2, x) && MathTools.Approximately(num3, y))
				{
					return false;
				}
				if (MPjLxZNqPAuPCgYcPJXVpHwNGNjF(P_0.unityHat_isActiveAxisValues1.x, num2) && MPjLxZNqPAuPCgYcPJXVpHwNGNjF(P_0.unityHat_isActiveAxisValues1.y, num3))
				{
					return true;
				}
				if (MPjLxZNqPAuPCgYcPJXVpHwNGNjF(P_0.unityHat_isActiveAxisValues2.x, num2) && MPjLxZNqPAuPCgYcPJXVpHwNGNjF(P_0.unityHat_isActiveAxisValues2.y, num3))
				{
					return true;
				}
				if (MPjLxZNqPAuPCgYcPJXVpHwNGNjF(P_0.unityHat_isActiveAxisValues3.x, num2) && MPjLxZNqPAuPCgYcPJXVpHwNGNjF(P_0.unityHat_isActiveAxisValues3.y, num3))
				{
					return true;
				}
			}
			else
			{
				if (P_0.sourceType == HardwareElementSourceTypeWithHat.Key)
				{
					if (P_0.sourceKeyCode == KeyboardKeyCode.None)
					{
						return false;
					}
					return UnityInputHelper.GetKey(P_0.sourceKeyCode);
				}
				if (P_0.sourceType == HardwareElementSourceTypeWithHat.Custom)
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
					HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
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
							if (CybGSDGsvQSCCiLRdHtrDgNvnAqGb(customCalculationSourceData[k], out var flag3))
							{
								customCalculation.AddData(flag3 ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Axis:
						{
							if (BCLRdYsOTYKezoDwknhOANUbgQFs(customCalculationSourceData[k], out var num4))
							{
								customCalculation.AddData((num4 != 0f) ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Key:
						{
							if (rYRDhqUNmtDfnVqxEknnRHtUwOmu(customCalculationSourceData[k], out var flag2))
							{
								customCalculation.AddData(flag2 ? 1f : 0f);
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
			}
			return false;
		}

		private bool MPjLxZNqPAuPCgYcPJXVpHwNGNjF(float P_0, float P_1)
		{
			return MathTools.IsNear(P_1, P_0, 0.1f);
		}

		private float cRnloddLIJktumCSVYgaeRgnhqJK(HardwareJoystickMap.Platform_Fallback_Base.Axis P_0)
		{
			switch (P_0.sourceType)
			{
			case HardwareElementSourceTypeWithHat.Axis:
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return 0f;
				}
				if (!xQFerQnSRVcAQJxTgxBJPmUuwfTVA(P_0.sourceAxis))
				{
					return 0f;
				}
				return NviKkvAyywviTWbAAeQweBzkWick(P_0.sourceAxis);
			case HardwareElementSourceTypeWithHat.Button:
				if (P_0.sourceButton == UnityButton.None)
				{
					return 0f;
				}
				if (!bhKvJvvQJzOdzatmjwRrYseRjCLS(P_0.sourceButton))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			case HardwareElementSourceTypeWithHat.Key:
				if (P_0.sourceKeyCode == KeyboardKeyCode.None)
				{
					return 0f;
				}
				if (!UnityInputHelper.GetKey(P_0.sourceKeyCode))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			case HardwareElementSourceTypeWithHat.Custom:
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
				HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
				if (customCalculationSourceData == null)
				{
					return 0f;
				}
				for (int i = 0; i < customCalculationSourceData.Length; i++)
				{
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && BCLRdYsOTYKezoDwknhOANUbgQFs(customCalculationSourceData[i], out var item))
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
			default:
				return 0f;
			}
		}

		private float NviKkvAyywviTWbAAeQweBzkWick(UnityAxis P_0)
		{
			if (P_0 == UnityAxis.None)
			{
				return 0f;
			}
			int num = (int)(P_0 - 1);
			return yJtZoxXGLYQgkSTqDRYVjBWydBaH[num];
		}

		private bool bhKvJvvQJzOdzatmjwRrYseRjCLS(UnityButton P_0)
		{
			int buttonIndex = (int)(P_0 - 1);
			return UnityInputHelper.GetJoystickButtonValueByJoystickId(zUphQPLvWUIMgfCFiAnbLGeGDtNk, buttonIndex);
		}

		private bool CybGSDGsvQSCCiLRdHtrDgNvnAqGb(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
		{
			P_1 = false;
			if (P_0.sourceType != 0)
			{
				return false;
			}
			UnityButton sourceElement = (UnityButton)P_0.sourceElement;
			if (sourceElement == UnityButton.None)
			{
				return false;
			}
			P_1 = bhKvJvvQJzOdzatmjwRrYseRjCLS(sourceElement);
			return true;
		}

		private bool rYRDhqUNmtDfnVqxEknnRHtUwOmu(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
		{
			P_1 = false;
			if (P_0.sourceType != 3)
			{
				return false;
			}
			KeyboardKeyCode sourceElement = (KeyboardKeyCode)P_0.sourceElement;
			if (sourceElement == KeyboardKeyCode.None)
			{
				return false;
			}
			P_1 = UnityInputHelper.GetKey(sourceElement);
			return true;
		}

		private bool BCLRdYsOTYKezoDwknhOANUbgQFs(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out float P_1)
		{
			P_1 = 0f;
			if (P_0.sourceType != 1)
			{
				return false;
			}
			UnityAxis sourceElement = (UnityAxis)P_0.sourceElement;
			if (sourceElement == UnityAxis.None)
			{
				return false;
			}
			P_1 = NviKkvAyywviTWbAAeQweBzkWick(sourceElement);
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
			if (P_0.deadzone > 0f && MathTools.Abs(P_1) <= P_0.deadzone)
			{
				P_1 = 0f;
			}
			if (P_0.invert)
			{
				P_1 *= -1f;
			}
			return true;
		}

		private bool xQFerQnSRVcAQJxTgxBJPmUuwfTVA(UnityAxis P_0)
		{
			int num = (int)(P_0 - 1);
			return sNQjdXXayWGtyKbRLSOLHJIsdNbcA[num];
		}

		private void SQdDRvaDPwUxXduyqKVhwtqSLhEaA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = QQCIsBpXUSpayvBAyQQBzDDXvDjm();
			if (UnityTools.isAndroidPlatform)
			{
				if (Regex.IsMatch(gSdEeBAocoWvxPvcVbsEjiImGKAgb, "Xbox Wireless Controller.*"))
				{
					UnityTools.externalTools.GetDeviceVIDPIDs(out var vids, out var pids);
					for (int i = 0; i < vids.Count; i++)
					{
						if (vids[i] == 1118 && pids[i] == 736)
						{
							bridgedControllerHWInfo.definitionMatchTag = "[FW1]";
							jVVTFHNnsaTSLBCOhBsDgdhtdMRiA = bridgedControllerHWInfo.definitionMatchTag;
							break;
						}
					}
				}
				else if (UnityTools.HGibNKTxgWTXsSSrCpyiwwxviScG != null)
				{
					IAndroidFallbackDS4Helper ds4Helper = UnityTools.HGibNKTxgWTXsSSrCpyiwwxviScG.ds4Helper;
					if (ds4Helper != null && ds4Helper.IsDS4(gSdEeBAocoWvxPvcVbsEjiImGKAgb))
					{
						if (ds4Helper.IsDS4KeyMapped(QjuwQrDOUEtPfUgKjSQBGnDmjfrv))
						{
							bridgedControllerHWInfo.definitionMatchTag = "[KEYMAP]";
						}
						else
						{
							bridgedControllerHWInfo.definitionMatchTag = "[NOKEYMAP]";
						}
						jVVTFHNnsaTSLBCOhBsDgdhtdMRiA = bridgedControllerHWInfo.definitionMatchTag;
					}
				}
			}
			if ((UnityTools.platform == Platform.tvOS || UnityTools.platform == Platform.iOS || UnityTools.platform == Platform.VisionOS) && Regex.IsMatch(gSdEeBAocoWvxPvcVbsEjiImGKAgb, "\\[basic,wireless\\] joystick [0-9]+ by Remote"))
			{
				bool flag = false;
				for (int j = 16; j < 28; j++)
				{
					if (!MathTools.ApproximatelyZero(UnityInputHelper.GetJoystickAxisValueByJoystickId(zUphQPLvWUIMgfCFiAnbLGeGDtNk, j)))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					jVVTFHNnsaTSLBCOhBsDgdhtdMRiA = "[SIRI_REMOTE_GEN1]";
					bridgedControllerHWInfo.definitionMatchTag = jVVTFHNnsaTSLBCOhBsDgdhtdMRiA;
				}
				else
				{
					jVVTFHNnsaTSLBCOhBsDgdhtdMRiA = "[SIRI_REMOTE_GEN2]";
					bridgedControllerHWInfo.definitionMatchTag = jVVTFHNnsaTSLBCOhBsDgdhtdMRiA;
				}
				KbUUxeCwsIolOnEKMtqlFRPZsyNl = true;
			}
			OWmxnyyqbDkFNTwwUnhQRXFdjFAj = ReInput.GetHardwareJoystickMap_InputManager(bridgedControllerHWInfo);
			if (OWmxnyyqbDkFNTwwUnhQRXFdjFAj == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			if (UnityTools.isIOSPlatform && OWmxnyyqbDkFNTwwUnhQRXFdjFAj.hardwareMapIdentifier.guid == Consts.joystickGuid_appleMFiController)
			{
				string text = kEZFNMTalBcYUHSDViqvqCQpDkKDA(gSdEeBAocoWvxPvcVbsEjiImGKAgb);
				if (!string.IsNullOrEmpty(text))
				{
					OWmxnyyqbDkFNTwwUnhQRXFdjFAj.controllerName = text;
					if (OWmxnyyqbDkFNTwwUnhQRXFdjFAj.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(OWmxnyyqbDkFNTwwUnhQRXFdjFAj.deviceLocalizationInfo.parentKeys[0]))
					{
						OWmxnyyqbDkFNTwwUnhQRXFdjFAj.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(OWmxnyyqbDkFNTwwUnhQRXFdjFAj.deviceLocalizationInfo.parentKeys[0], text));
					}
					OWmxnyyqbDkFNTwwUnhQRXFdjFAj.deviceLocalizationInfo.additionalIdentifyingInformation = text;
				}
			}
			else if (OWmxnyyqbDkFNTwwUnhQRXFdjFAj.useSystemName && !string.IsNullOrEmpty(gSdEeBAocoWvxPvcVbsEjiImGKAgb))
			{
				string text2 = Regex.Replace(gSdEeBAocoWvxPvcVbsEjiImGKAgb, "\\s+", " ");
				text2 = text2.Trim();
				if (!string.IsNullOrEmpty(text2))
				{
					OWmxnyyqbDkFNTwwUnhQRXFdjFAj.controllerName = text2;
					if (OWmxnyyqbDkFNTwwUnhQRXFdjFAj.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(OWmxnyyqbDkFNTwwUnhQRXFdjFAj.deviceLocalizationInfo.parentKeys[0]))
					{
						OWmxnyyqbDkFNTwwUnhQRXFdjFAj.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(OWmxnyyqbDkFNTwwUnhQRXFdjFAj.deviceLocalizationInfo.parentKeys[0], text2));
					}
					OWmxnyyqbDkFNTwwUnhQRXFdjFAj.deviceLocalizationInfo.additionalIdentifyingInformation = text2;
				}
			}
			hUqEYhczQVbsaxdLZhvTHsvGOwjW = OWmxnyyqbDkFNTwwUnhQRXFdjFAj.axisCount;
			MlkAREanYIqlEYgKGyvbbnLMFrcJ = OWmxnyyqbDkFNTwwUnhQRXFdjFAj.buttonCount;
		}

		private void nQJsHnqbSKlbouumHLCUGXNXNThl()
		{
			Array.Clear(LAxvzhSRZpYWoeYnZwENoDKvgLyv, 0, LAxvzhSRZpYWoeYnZwENoDKvgLyv.Length);
			Array.Clear(EcaudSGIIlYzyTPKxtGJGKDSLvex, 0, EcaudSGIIlYzyTPKxtGJGKDSLvex.Length);
		}

		private string cxpuBrGQPrDFkkDVlbyrAsGLMfHWA()
		{
			if (ReInput.currentPlatform == Platform.Webplayer)
			{
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{QVoqPnGeibISqkcfPCgYAlAeyLFgB().ToString()}{gSdEeBAocoWvxPvcVbsEjiImGKAgb}");
			}
			if (UnityTools.isIOSPlatform)
			{
				string arg = Regex.Replace(gSdEeBAocoWvxPvcVbsEjiImGKAgb, "joystick [0-9]+ by ", "");
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{QVoqPnGeibISqkcfPCgYAlAeyLFgB().ToString()}{arg}");
			}
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{QVoqPnGeibISqkcfPCgYAlAeyLFgB().ToString()}{gSdEeBAocoWvxPvcVbsEjiImGKAgb}");
		}

		private InputSource QVoqPnGeibISqkcfPCgYAlAeyLFgB()
		{
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(gSdEeBAocoWvxPvcVbsEjiImGKAgb))
			{
				return InputSource.Fallback_PreConfigured;
			}
			return InputSource.Fallback;
		}

		public static int DCkchXOScGdYtdtQDunMKHPFRzjBA(VoOQpLoLKgCpKjxOPbvjRKkipUrbA P_0, VoOQpLoLKgCpKjxOPbvjRKkipUrbA P_1)
		{
			if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < P_1.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId)
			{
				return -1;
			}
			if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId > P_1.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId)
			{
				return 1;
			}
			return 0;
		}

		public static int zCfGfxcPUlmJErynTOvAspRPlMce(VoOQpLoLKgCpKjxOPbvjRKkipUrbA P_0, VoOQpLoLKgCpKjxOPbvjRKkipUrbA P_1)
		{
			if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId < P_1.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId)
			{
				return -1;
			}
			if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId > P_1.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId)
			{
				return 1;
			}
			return 0;
		}

		private static string kEZFNMTalBcYUHSDViqvqCQpDkKDA(string P_0)
		{
			string input = Regex.Replace(P_0, "\\[.*\\] joystick [0-9]+ by ", "");
			input = Regex.Replace(input, "\\s+", " ");
			if (!string.IsNullOrEmpty(input))
			{
				input = input.Trim();
			}
			return input;
		}
	}

	private class jrCVjyGTadxVXfWHRmdEjsQtagmZ
	{
		public enum zmLRzvTHmlfAqzCyPpLZixfRPlwL
		{
			Exact = 0,
			Approximate = 1
		}

		public class UWgQQEaUflmejLoCOxKiQhkBHDjy
		{
			public int qeGGNAgiikqIfJhZCprhjgPFuzOsA;

			public int qLBDlZIYiOEcTzZWFGBUoAvhUKeV;

			public string BzCdKnjKWOGvCbOESNcsUjDrdovoA;

			public int XeoHXRXJczOsaeSBBPfslucYVTLs;

			public string XJvLFLKoBIUcoFHhUckyjDoxLtiu;

			public string rIJVHkadbhlpJApcHcDygiyzbICoA;

			public int inDfUwNXazBLsiagQLCRlkdvFaFf;

			public int vJmKbYAviZBqTYyPJaUQCSckBHnq;

			public UWgQQEaUflmejLoCOxKiQhkBHDjy(int P_0, int P_1, string P_2, int P_3, string P_4, string P_5, int P_6, int P_7)
			{
				qeGGNAgiikqIfJhZCprhjgPFuzOsA = P_0;
				qLBDlZIYiOEcTzZWFGBUoAvhUKeV = P_1;
				BzCdKnjKWOGvCbOESNcsUjDrdovoA = P_2;
				XeoHXRXJczOsaeSBBPfslucYVTLs = P_3;
				XJvLFLKoBIUcoFHhUckyjDoxLtiu = P_4;
				rIJVHkadbhlpJApcHcDygiyzbICoA = P_5;
				inDfUwNXazBLsiagQLCRlkdvFaFf = P_6;
				vJmKbYAviZBqTYyPJaUQCSckBHnq = P_7;
			}

			public bool jLfMHcwySCggXFiFomrUFAApOWkB(VoOQpLoLKgCpKjxOPbvjRKkipUrbA P_0, zmLRzvTHmlfAqzCyPpLZixfRPlwL P_1)
			{
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == qeGGNAgiikqIfJhZCprhjgPFuzOsA)
				{
					return true;
				}
				if (inDfUwNXazBLsiagQLCRlkdvFaFf != P_0.IikyRUMHORYvNoluuenOLuHUGPKG || vJmKbYAviZBqTYyPJaUQCSckBHnq != P_0.oOwIQtWSPqzHBTolYbpTEHzMYoeB)
				{
					return false;
				}
				if ((!string.IsNullOrEmpty(XJvLFLKoBIUcoFHhUckyjDoxLtiu) || !string.IsNullOrEmpty(P_0.SeGhXJiUUqIfxQjlilZWYGtRlYxhA)) && !string.Equals(XJvLFLKoBIUcoFHhUckyjDoxLtiu, P_0.SeGhXJiUUqIfxQjlilZWYGtRlYxhA, StringComparison.Ordinal))
				{
					return false;
				}
				if ((!string.IsNullOrEmpty(rIJVHkadbhlpJApcHcDygiyzbICoA) || !string.IsNullOrEmpty(P_0.jVVTFHNnsaTSLBCOhBsDgdhtdMRiA)) && !string.Equals(rIJVHkadbhlpJApcHcDygiyzbICoA, P_0.jVVTFHNnsaTSLBCOhBsDgdhtdMRiA, StringComparison.Ordinal))
				{
					return false;
				}
				switch (P_1)
				{
				case zmLRzvTHmlfAqzCyPpLZixfRPlwL.Exact:
					if (qLBDlZIYiOEcTzZWFGBUoAvhUKeV == P_0.QjuwQrDOUEtPfUgKjSQBGnDmjfrv)
					{
						return BzCdKnjKWOGvCbOESNcsUjDrdovoA == P_0.gSdEeBAocoWvxPvcVbsEjiImGKAgb;
					}
					return false;
				case zmLRzvTHmlfAqzCyPpLZixfRPlwL.Approximate:
					return BzCdKnjKWOGvCbOESNcsUjDrdovoA == P_0.gSdEeBAocoWvxPvcVbsEjiImGKAgb;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private sealed class pVoPkdLtAYZXZpDTWjUQPPHsPreM : IEnumerable<UWgQQEaUflmejLoCOxKiQhkBHDjy>, IEnumerable, IEnumerator<UWgQQEaUflmejLoCOxKiQhkBHDjy>, IEnumerator, IDisposable
		{
			private int VAoqOZFucYuOCOohnwagUoeDcwIX;

			private UWgQQEaUflmejLoCOxKiQhkBHDjy dobruWitPiLYCgakVDKDIqyljytBA;

			private int zpchUkFeNzGmzyuIJRocGjNldNVR;

			public jrCVjyGTadxVXfWHRmdEjsQtagmZ PjQOCZnjLqKOxaiPyuvunNZTxvPt;

			private VoOQpLoLKgCpKjxOPbvjRKkipUrbA YmsqPyZjAEaYeEnxeLSnUmXUIWOK;

			public VoOQpLoLKgCpKjxOPbvjRKkipUrbA HqoStOPpImZFYZVUPkrIDWaGMQGC;

			private zmLRzvTHmlfAqzCyPpLZixfRPlwL uKBdFwLpCxEYsrkcrqghkmGLFDOjA;

			public zmLRzvTHmlfAqzCyPpLZixfRPlwL LESyLcukEOlVMZaIzCOchUThDzCW;

			private int DoxbGWULBMDAnznlcGEoFCzXtFQIA;

			private int rFlflgXwFlbRfgpYLCAbHRqNiCUxA;

			UWgQQEaUflmejLoCOxKiQhkBHDjy IEnumerator<UWgQQEaUflmejLoCOxKiQhkBHDjy>.Current
			{
				[DebuggerHidden]
				get
				{
					return dobruWitPiLYCgakVDKDIqyljytBA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return dobruWitPiLYCgakVDKDIqyljytBA;
				}
			}

			[DebuggerHidden]
			public pVoPkdLtAYZXZpDTWjUQPPHsPreM(int P_0)
			{
				VAoqOZFucYuOCOohnwagUoeDcwIX = P_0;
				zpchUkFeNzGmzyuIJRocGjNldNVR = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				VAoqOZFucYuOCOohnwagUoeDcwIX = -2;
			}

			private bool MoveNext()
			{
				int vAoqOZFucYuOCOohnwagUoeDcwIX = VAoqOZFucYuOCOohnwagUoeDcwIX;
				jrCVjyGTadxVXfWHRmdEjsQtagmZ pjQOCZnjLqKOxaiPyuvunNZTxvPt = PjQOCZnjLqKOxaiPyuvunNZTxvPt;
				if (vAoqOZFucYuOCOohnwagUoeDcwIX != 0)
				{
					if (vAoqOZFucYuOCOohnwagUoeDcwIX != 1)
					{
						return false;
					}
					VAoqOZFucYuOCOohnwagUoeDcwIX = -1;
					goto IL_0083;
				}
				VAoqOZFucYuOCOohnwagUoeDcwIX = -1;
				DoxbGWULBMDAnznlcGEoFCzXtFQIA = pjQOCZnjLqKOxaiPyuvunNZTxvPt.uwTDlBYEQegNukIaLMeIJsAAJOkjb.Count;
				rFlflgXwFlbRfgpYLCAbHRqNiCUxA = 0;
				goto IL_0093;
				IL_0083:
				rFlflgXwFlbRfgpYLCAbHRqNiCUxA++;
				goto IL_0093;
				IL_0093:
				if (rFlflgXwFlbRfgpYLCAbHRqNiCUxA < DoxbGWULBMDAnznlcGEoFCzXtFQIA)
				{
					if (pjQOCZnjLqKOxaiPyuvunNZTxvPt.uwTDlBYEQegNukIaLMeIJsAAJOkjb[rFlflgXwFlbRfgpYLCAbHRqNiCUxA].jLfMHcwySCggXFiFomrUFAApOWkB(YmsqPyZjAEaYeEnxeLSnUmXUIWOK, uKBdFwLpCxEYsrkcrqghkmGLFDOjA))
					{
						dobruWitPiLYCgakVDKDIqyljytBA = pjQOCZnjLqKOxaiPyuvunNZTxvPt.uwTDlBYEQegNukIaLMeIJsAAJOkjb[rFlflgXwFlbRfgpYLCAbHRqNiCUxA];
						VAoqOZFucYuOCOohnwagUoeDcwIX = 1;
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
			IEnumerator<UWgQQEaUflmejLoCOxKiQhkBHDjy> IEnumerable<UWgQQEaUflmejLoCOxKiQhkBHDjy>.GetEnumerator()
			{
				pVoPkdLtAYZXZpDTWjUQPPHsPreM pVoPkdLtAYZXZpDTWjUQPPHsPreM2;
				if (VAoqOZFucYuOCOohnwagUoeDcwIX == -2 && zpchUkFeNzGmzyuIJRocGjNldNVR == Environment.CurrentManagedThreadId)
				{
					VAoqOZFucYuOCOohnwagUoeDcwIX = 0;
					pVoPkdLtAYZXZpDTWjUQPPHsPreM2 = this;
				}
				else
				{
					pVoPkdLtAYZXZpDTWjUQPPHsPreM2 = new pVoPkdLtAYZXZpDTWjUQPPHsPreM(0);
					pVoPkdLtAYZXZpDTWjUQPPHsPreM2.PjQOCZnjLqKOxaiPyuvunNZTxvPt = PjQOCZnjLqKOxaiPyuvunNZTxvPt;
				}
				pVoPkdLtAYZXZpDTWjUQPPHsPreM2.YmsqPyZjAEaYeEnxeLSnUmXUIWOK = HqoStOPpImZFYZVUPkrIDWaGMQGC;
				pVoPkdLtAYZXZpDTWjUQPPHsPreM2.uKBdFwLpCxEYsrkcrqghkmGLFDOjA = LESyLcukEOlVMZaIzCOchUThDzCW;
				return pVoPkdLtAYZXZpDTWjUQPPHsPreM2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<UWgQQEaUflmejLoCOxKiQhkBHDjy>)this).GetEnumerator();
			}
		}

		private List<UWgQQEaUflmejLoCOxKiQhkBHDjy> uwTDlBYEQegNukIaLMeIJsAAJOkjb;

		public int qXRgfRCJutlIhanjytpSqQnoEEvN => uwTDlBYEQegNukIaLMeIJsAAJOkjb.Count;

		public jrCVjyGTadxVXfWHRmdEjsQtagmZ()
		{
			uwTDlBYEQegNukIaLMeIJsAAJOkjb = new List<UWgQQEaUflmejLoCOxKiQhkBHDjy>();
		}

		public void QfkGSbysLyDEgnaSwUuulUTaMuXM(VoOQpLoLKgCpKjxOPbvjRKkipUrbA P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = uwTDlBYEQegNukIaLMeIJsAAJOkjb.Count;
			for (int i = 0; i < count; i++)
			{
				if (uwTDlBYEQegNukIaLMeIJsAAJOkjb[i].jLfMHcwySCggXFiFomrUFAApOWkB(P_0, zmLRzvTHmlfAqzCyPpLZixfRPlwL.Exact))
				{
					CfktenxpmgHWVsjLgpxOWPrOcMMu(uwTDlBYEQegNukIaLMeIJsAAJOkjb[i], P_0);
					return;
				}
			}
			uwTDlBYEQegNukIaLMeIJsAAJOkjb.Add(new UWgQQEaUflmejLoCOxKiQhkBHDjy(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.QjuwQrDOUEtPfUgKjSQBGnDmjfrv, P_0.gSdEeBAocoWvxPvcVbsEjiImGKAgb, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId, P_0.SeGhXJiUUqIfxQjlilZWYGtRlYxhA, P_0.jVVTFHNnsaTSLBCOhBsDgdhtdMRiA, P_0.IikyRUMHORYvNoluuenOLuHUGPKG, P_0.oOwIQtWSPqzHBTolYbpTEHzMYoeB));
			QSXAUmceybkUqnlooOoGYRTbTreoA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, uwTDlBYEQegNukIaLMeIJsAAJOkjb.Count - 1);
		}

		public void CfktenxpmgHWVsjLgpxOWPrOcMMu(UWgQQEaUflmejLoCOxKiQhkBHDjy P_0, VoOQpLoLKgCpKjxOPbvjRKkipUrbA P_1)
		{
			int num = uwTDlBYEQegNukIaLMeIJsAAJOkjb.IndexOf(P_0);
			if (num >= 0)
			{
				P_0.qeGGNAgiikqIfJhZCprhjgPFuzOsA = P_1.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
				P_0.BzCdKnjKWOGvCbOESNcsUjDrdovoA = P_1.gSdEeBAocoWvxPvcVbsEjiImGKAgb;
				P_0.qLBDlZIYiOEcTzZWFGBUoAvhUKeV = P_1.QjuwQrDOUEtPfUgKjSQBGnDmjfrv;
				P_0.XeoHXRXJczOsaeSBBPfslucYVTLs = P_1.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
				P_0.XJvLFLKoBIUcoFHhUckyjDoxLtiu = P_1.SeGhXJiUUqIfxQjlilZWYGtRlYxhA;
				P_0.rIJVHkadbhlpJApcHcDygiyzbICoA = P_1.jVVTFHNnsaTSLBCOhBsDgdhtdMRiA;
				P_0.inDfUwNXazBLsiagQLCRlkdvFaFf = P_1.IikyRUMHORYvNoluuenOLuHUGPKG;
				P_0.vJmKbYAviZBqTYyPJaUQCSckBHnq = P_1.oOwIQtWSPqzHBTolYbpTEHzMYoeB;
				QSXAUmceybkUqnlooOoGYRTbTreoA(P_1.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, num);
			}
		}

		public bool XHgMGGiQFIbCXdfSijgRJwLlHBQs(VoOQpLoLKgCpKjxOPbvjRKkipUrbA P_0, zmLRzvTHmlfAqzCyPpLZixfRPlwL P_1)
		{
			int count = uwTDlBYEQegNukIaLMeIJsAAJOkjb.Count;
			for (int i = 0; i < count; i++)
			{
				if (uwTDlBYEQegNukIaLMeIJsAAJOkjb[i].jLfMHcwySCggXFiFomrUFAApOWkB(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(pVoPkdLtAYZXZpDTWjUQPPHsPreM))]
		public IEnumerable<UWgQQEaUflmejLoCOxKiQhkBHDjy> xsYvuNArXIjRkWyVfhDiTOGPSuOW(VoOQpLoLKgCpKjxOPbvjRKkipUrbA P_0, zmLRzvTHmlfAqzCyPpLZixfRPlwL P_1)
		{
			return new pVoPkdLtAYZXZpDTWjUQPPHsPreM(-2)
			{
				PjQOCZnjLqKOxaiPyuvunNZTxvPt = this,
				HqoStOPpImZFYZVUPkrIDWaGMQGC = P_0,
				LESyLcukEOlVMZaIzCOchUThDzCW = P_1
			};
		}

		public int fDYGQYWiBGtqnrqtAJrywFQOPRSR(UWgQQEaUflmejLoCOxKiQhkBHDjy P_0)
		{
			int count = uwTDlBYEQegNukIaLMeIJsAAJOkjb.Count;
			for (int i = 0; i < count; i++)
			{
				if (uwTDlBYEQegNukIaLMeIJsAAJOkjb[i] == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private void QSXAUmceybkUqnlooOoGYRTbTreoA(int P_0, int P_1)
		{
			for (int num = uwTDlBYEQegNukIaLMeIJsAAJOkjb.Count - 1; num >= 0; num--)
			{
				if (num != P_1 && uwTDlBYEQegNukIaLMeIJsAAJOkjb[num].qeGGNAgiikqIfJhZCprhjgPFuzOsA == P_0)
				{
					uwTDlBYEQegNukIaLMeIJsAAJOkjb.RemoveAt(num);
				}
			}
		}
	}

	private List<VoOQpLoLKgCpKjxOPbvjRKkipUrbA> oCffFveONUuLHZgTchgsqtEOxMWj;

	private int pcKvXrNacqlJerfoRqbzACwSpiMI;

	private jrCVjyGTadxVXfWHRmdEjsQtagmZ PDORKhVEtGCaDsHbeiCADuTLSXlFA;

	private bool kiEMouOlTGQiTyoPBvEkmLGifovaA;

	private bool IqFOiuInKQdOHLSsyDThSMfXmDMh;

	private UpdateLoopType NSVRsDQJeNrVHqZOlxldIYQgiHXN;

	private UpdateLoopType QGzHQIryGfmKXVBAZgfQkCyLeCQg;

	private TimerAbs dMRGVScOSUrbxzAWCdqnlgZACTWd;

	private Action<int, ControllerDataUpdater> BMrEwzZCnyaoFRqYwgRBbRpUimwd;

	private PlatformInputManager WssSsRyRUqAKZQpfzBxlBTVfCXTYA;

	private readonly IUnifiedKeyboardSource kbOfYyRJNeWFJzyfNqUWvDeLnpVl;

	private readonly IUnifiedMouseSource wfcMkSLnnJtqBuxGXvJMHPKNCvnd;

	private readonly List<string> RSKUfwjwepZGgfggfeOmYUAOWjhq;

	private readonly List<string> LeORUWzrOfikzKALqTVekZZWbzHA;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => pcKvXrNacqlJerfoRqbzACwSpiMI;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => WssSsRyRUqAKZQpfzBxlBTVfCXTYA;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => null;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.Fallback;

	public CMxwGZjFpYvocDsKTBgbeUxNyuuHA(UpdateLoopSetting P_0)
	{
		WssSsRyRUqAKZQpfzBxlBTVfCXTYA = this;
		kbOfYyRJNeWFJzyfNqUWvDeLnpVl = new UnityUnifiedKeyboardSource();
		wfcMkSLnnJtqBuxGXvJMHPKNCvnd = new UnityUnifiedMouseSource();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			QGzHQIryGfmKXVBAZgfQkCyLeCQg = list[0];
		}
		oCffFveONUuLHZgTchgsqtEOxMWj = new List<VoOQpLoLKgCpKjxOPbvjRKkipUrbA>();
		RSKUfwjwepZGgfggfeOmYUAOWjhq = new List<string>();
		LeORUWzrOfikzKALqTVekZZWbzHA = new List<string>();
		BMrEwzZCnyaoFRqYwgRBbRpUimwd = UpdateControllerData;
		if (UnityTools.platform == Platform.tvOS)
		{
			ConfigVars.PlatformVars_tvOS platformVars_tvOS = ReInput.configVars.platformVars_tvOS;
			if (platformVars_tvOS != null)
			{
				UnityTools.externalTools.tvOS_allowExitToHome = platformVars_tvOS.enableBackButtonReturnsHome;
				platformVars_tvOS.ValueChangedEvent += SawbbDIUTsEqajEuNqcdhPplxpOQ;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.HGibNKTxgWTXsSSrCpyiwwxviScG != null)
		{
			UnityTools.HGibNKTxgWTXsSSrCpyiwwxviScG.DeviceChangedEvent += IsQISjiiJgMVWaLFjLPflHhPKxnb;
		}
		UnityInputManagerSettings.GfOeXtjAckQnvFFFAVnavhxrYkwC();
		UnityInputManagerSettings.wkSBvelwJOAgAtvQejrRTllIsvur = (Action)Delegate.Combine(UnityInputManagerSettings.wkSBvelwJOAgAtvQejrRTllIsvur, new Action(IsQISjiiJgMVWaLFjLPflHhPKxnb));
		dMRGVScOSUrbxzAWCdqnlgZACTWd = new TimerAbs(1.0);
		PDORKhVEtGCaDsHbeiCADuTLSXlFA = new jrCVjyGTadxVXfWHRmdEjsQtagmZ();
		ohFnuPQGPqNHAJQZFQvhaodttCCg();
		kiEMouOlTGQiTyoPBvEkmLGifovaA = true;
		dMRGVScOSUrbxzAWCdqnlgZACTWd.Start();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		NSVRsDQJeNrVHqZOlxldIYQgiHXN = updateLoop;
		KmArPLlwJvGMPnPcEeEqtpGHEeyDA();
		if (kiEMouOlTGQiTyoPBvEkmLGifovaA)
		{
			ohFnuPQGPqNHAJQZFQvhaodttCCg();
		}
		GNUabNQXejqUgGXcERKdFVsxNRkW(updateLoop);
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.HGibNKTxgWTXsSSrCpyiwwxviScG != null)
		{
			UnityTools.HGibNKTxgWTXsSSrCpyiwwxviScG.DeviceChangedEvent -= IsQISjiiJgMVWaLFjLPflHhPKxnb;
		}
		UnityInputManagerSettings.wkSBvelwJOAgAtvQejrRTllIsvur = (Action)Delegate.Remove(UnityInputManagerSettings.wkSBvelwJOAgAtvQejrRTllIsvur, new Action(IsQISjiiJgMVWaLFjLPflHhPKxnb));
		(kbOfYyRJNeWFJzyfNqUWvDeLnpVl as IDisposable).Dispose();
		(wfcMkSLnnJtqBuxGXvJMHPKNCvnd as IDisposable).Dispose();
		if (UnityTools.platform == Platform.tvOS)
		{
			ConfigVars.PlatformVars_tvOS platformVars_tvOS = ReInput.configVars.platformVars_tvOS;
			if (platformVars_tvOS != null)
			{
				platformVars_tvOS.ValueChangedEvent -= SawbbDIUTsEqajEuNqcdhPplxpOQ;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return BMrEwzZCnyaoFRqYwgRBbRpUimwd;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		for (int i = 0; i < pcKvXrNacqlJerfoRqbzACwSpiMI; i++)
		{
			if (oCffFveONUuLHZgTchgsqtEOxMWj[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == assignedControllerId)
			{
				oCffFveONUuLHZgTchgsqtEOxMWj[i].FillData(data);
				return;
			}
		}
		Logger.LogError("Invalid joystick Id " + assignedControllerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		kiEMouOlTGQiTyoPBvEkmLGifovaA = true;
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		kiEMouOlTGQiTyoPBvEkmLGifovaA = true;
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	private void IsQISjiiJgMVWaLFjLPflHhPKxnb()
	{
		kiEMouOlTGQiTyoPBvEkmLGifovaA = true;
		IqFOiuInKQdOHLSsyDThSMfXmDMh = true;
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		for (int i = 0; i < oCffFveONUuLHZgTchgsqtEOxMWj.Count; i++)
		{
			if (oCffFveONUuLHZgTchgsqtEOxMWj[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId == unityJoystickId)
			{
				oCffFveONUuLHZgTchgsqtEOxMWj[i].XpRCQGfIfStTdkXRxfPFrOlKhkFd();
			}
		}
		for (int j = 0; j < oCffFveONUuLHZgTchgsqtEOxMWj.Count; j++)
		{
			if (oCffFveONUuLHZgTchgsqtEOxMWj[j].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == joystickId)
			{
				oCffFveONUuLHZgTchgsqtEOxMWj[j].zvtAEIwXhOwXvFnEuQbXMrCROGSE(unityJoystickId);
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return wfcMkSLnnJtqBuxGXvJMHPKNCvnd;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return kbOfYyRJNeWFJzyfNqUWvDeLnpVl;
	}

	private void uHyiQhNUQnBppYZYQCGBeSbdajrAA(IList<string> P_0)
	{
		int num = 0;
		List<VoOQpLoLKgCpKjxOPbvjRKkipUrbA> list = oCffFveONUuLHZgTchgsqtEOxMWj;
		int num2 = pcKvXrNacqlJerfoRqbzACwSpiMI;
		oCffFveONUuLHZgTchgsqtEOxMWj = new List<VoOQpLoLKgCpKjxOPbvjRKkipUrbA>();
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			string text = StringTools.SanitizeDeviceString(P_0[i]);
			if (UnityTools.IsValidUnityJoystickName(text))
			{
				VoOQpLoLKgCpKjxOPbvjRKkipUrbA voOQpLoLKgCpKjxOPbvjRKkipUrbA = new VoOQpLoLKgCpKjxOPbvjRKkipUrbA();
				voOQpLoLKgCpKjxOPbvjRKkipUrbA.gSdEeBAocoWvxPvcVbsEjiImGKAgb = text;
				voOQpLoLKgCpKjxOPbvjRKkipUrbA.LxNUwrsOyaLbSCktWsovNTBJPCVj = text;
				voOQpLoLKgCpKjxOPbvjRKkipUrbA.QjuwQrDOUEtPfUgKjSQBGnDmjfrv = i;
				voOQpLoLKgCpKjxOPbvjRKkipUrbA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId = i + 1;
				if (UnityTools.isAndroidPlatform && UnityTools.HGibNKTxgWTXsSSrCpyiwwxviScG != null)
				{
					voOQpLoLKgCpKjxOPbvjRKkipUrbA.SeGhXJiUUqIfxQjlilZWYGtRlYxhA = UnityTools.HGibNKTxgWTXsSSrCpyiwwxviScG.GetUniqueDeviceIdentifier(text, i);
				}
				voOQpLoLKgCpKjxOPbvjRKkipUrbA.hrpxQJVNPbwxNBhVlcBMzGVBAgcu();
				oCffFveONUuLHZgTchgsqtEOxMWj.Add(voOQpLoLKgCpKjxOPbvjRKkipUrbA);
				num++;
			}
		}
		pcKvXrNacqlJerfoRqbzACwSpiMI = num;
		zVbGOYupfbKVxxVbZBVVMNLyPFnv(num2, num, list, oCffFveONUuLHZgTchgsqtEOxMWj);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(oCffFveONUuLHZgTchgsqtEOxMWj[j]));
			}
		}
		ghMTHdRMzrcgUFFJYjNdwmrIMjxCb(list, oCffFveONUuLHZgTchgsqtEOxMWj, false);
		ghMTHdRMzrcgUFFJYjNdwmrIMjxCb(oCffFveONUuLHZgTchgsqtEOxMWj, list, true);
		RSKUfwjwepZGgfggfeOmYUAOWjhq.Clear();
		RSKUfwjwepZGgfggfeOmYUAOWjhq.AddRange(P_0);
	}

	private void GNUabNQXejqUgGXcERKdFVsxNRkW(UpdateLoopType P_0)
	{
		int count = oCffFveONUuLHZgTchgsqtEOxMWj.Count;
		for (int i = 0; i < count; i++)
		{
			if (oCffFveONUuLHZgTchgsqtEOxMWj[i] != null)
			{
				oCffFveONUuLHZgTchgsqtEOxMWj[i].Update();
			}
		}
	}

	private void zVbGOYupfbKVxxVbZBVVMNLyPFnv(int P_0, int P_1, List<VoOQpLoLKgCpKjxOPbvjRKkipUrbA> P_2, List<VoOQpLoLKgCpKjxOPbvjRKkipUrbA> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(VoOQpLoLKgCpKjxOPbvjRKkipUrbA.zCfGfxcPUlmJErynTOvAspRPlMce);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			YugTJMekIgGKYFiWopILnRcCtKqn(P_1, P_3, P_0, P_2, jrCVjyGTadxVXfWHRmdEjsQtagmZ.zmLRzvTHmlfAqzCyPpLZixfRPlwL.Exact);
			YugTJMekIgGKYFiWopILnRcCtKqn(P_1, P_3, P_0, P_2, jrCVjyGTadxVXfWHRmdEjsQtagmZ.zmLRzvTHmlfAqzCyPpLZixfRPlwL.Approximate);
		}
		HgPtpEFNRlIDGnDBzxxbjmlxwCUV(P_1, P_3, jrCVjyGTadxVXfWHRmdEjsQtagmZ.zmLRzvTHmlfAqzCyPpLZixfRPlwL.Exact);
		HgPtpEFNRlIDGnDBzxxbjmlxwCUV(P_1, P_3, jrCVjyGTadxVXfWHRmdEjsQtagmZ.zmLRzvTHmlfAqzCyPpLZixfRPlwL.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			VoOQpLoLKgCpKjxOPbvjRKkipUrbA voOQpLoLKgCpKjxOPbvjRKkipUrbA = P_3[i];
			if (voOQpLoLKgCpKjxOPbvjRKkipUrbA != null && voOQpLoLKgCpKjxOPbvjRKkipUrbA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				voOQpLoLKgCpKjxOPbvjRKkipUrbA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = ijOSGIaGSXvSpXlIsVSMNGvQcJqt(P_3);
				voOQpLoLKgCpKjxOPbvjRKkipUrbA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = ReInput.GetNewJoystickId();
				PDORKhVEtGCaDsHbeiCADuTLSXlFA.QfkGSbysLyDEgnaSwUuulUTaMuXM(voOQpLoLKgCpKjxOPbvjRKkipUrbA);
			}
		}
		P_3.Sort(VoOQpLoLKgCpKjxOPbvjRKkipUrbA.DCkchXOScGdYtdtQDunMKHPFRzjBA);
	}

	private void uYzELkeQNmVYEkArDwyuONgWgtBPA(List<VoOQpLoLKgCpKjxOPbvjRKkipUrbA> P_0, int P_1, int P_2)
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

	private bool UZmnsoFBcuRiJXtoBAtWzFImHVJC(List<VoOQpLoLKgCpKjxOPbvjRKkipUrbA> P_0, int P_1)
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

	private int ijOSGIaGSXvSpXlIsVSMNGvQcJqt(List<VoOQpLoLKgCpKjxOPbvjRKkipUrbA> P_0)
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

	private bool GdNRjsmgYWnKjDgBkqfwzOLdSbEk(List<VoOQpLoLKgCpKjxOPbvjRKkipUrbA> P_0, int P_1)
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

	private void YugTJMekIgGKYFiWopILnRcCtKqn(int P_0, List<VoOQpLoLKgCpKjxOPbvjRKkipUrbA> P_1, int P_2, List<VoOQpLoLKgCpKjxOPbvjRKkipUrbA> P_3, jrCVjyGTadxVXfWHRmdEjsQtagmZ.zmLRzvTHmlfAqzCyPpLZixfRPlwL P_4)
	{
		int num = ((P_4 != jrCVjyGTadxVXfWHRmdEjsQtagmZ.zmLRzvTHmlfAqzCyPpLZixfRPlwL.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			VoOQpLoLKgCpKjxOPbvjRKkipUrbA voOQpLoLKgCpKjxOPbvjRKkipUrbA = P_1[i];
			if (voOQpLoLKgCpKjxOPbvjRKkipUrbA == null || voOQpLoLKgCpKjxOPbvjRKkipUrbA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				VoOQpLoLKgCpKjxOPbvjRKkipUrbA voOQpLoLKgCpKjxOPbvjRKkipUrbA2 = P_3[j];
				if (voOQpLoLKgCpKjxOPbvjRKkipUrbA2 != null && !GdNRjsmgYWnKjDgBkqfwzOLdSbEk(P_1, voOQpLoLKgCpKjxOPbvjRKkipUrbA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && voOQpLoLKgCpKjxOPbvjRKkipUrbA.lHHRWanCFNinYhDEBpEPumeIwbeBA(voOQpLoLKgCpKjxOPbvjRKkipUrbA2) >= num)
				{
					voOQpLoLKgCpKjxOPbvjRKkipUrbA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = voOQpLoLKgCpKjxOPbvjRKkipUrbA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					voOQpLoLKgCpKjxOPbvjRKkipUrbA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = voOQpLoLKgCpKjxOPbvjRKkipUrbA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					if (ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull)
					{
						voOQpLoLKgCpKjxOPbvjRKkipUrbA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId = voOQpLoLKgCpKjxOPbvjRKkipUrbA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId;
					}
					PDORKhVEtGCaDsHbeiCADuTLSXlFA.QfkGSbysLyDEgnaSwUuulUTaMuXM(voOQpLoLKgCpKjxOPbvjRKkipUrbA);
				}
			}
		}
	}

	private void HgPtpEFNRlIDGnDBzxxbjmlxwCUV(int P_0, List<VoOQpLoLKgCpKjxOPbvjRKkipUrbA> P_1, jrCVjyGTadxVXfWHRmdEjsQtagmZ.zmLRzvTHmlfAqzCyPpLZixfRPlwL P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			VoOQpLoLKgCpKjxOPbvjRKkipUrbA voOQpLoLKgCpKjxOPbvjRKkipUrbA = P_1[i];
			if (voOQpLoLKgCpKjxOPbvjRKkipUrbA == null || voOQpLoLKgCpKjxOPbvjRKkipUrbA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			jrCVjyGTadxVXfWHRmdEjsQtagmZ.UWgQQEaUflmejLoCOxKiQhkBHDjy uWgQQEaUflmejLoCOxKiQhkBHDjy = null;
			foreach (jrCVjyGTadxVXfWHRmdEjsQtagmZ.UWgQQEaUflmejLoCOxKiQhkBHDjy item in PDORKhVEtGCaDsHbeiCADuTLSXlFA.xsYvuNArXIjRkWyVfhDiTOGPSuOW(voOQpLoLKgCpKjxOPbvjRKkipUrbA, P_2))
			{
				if (!GdNRjsmgYWnKjDgBkqfwzOLdSbEk(P_1, item.qeGGNAgiikqIfJhZCprhjgPFuzOsA) && item.XeoHXRXJczOsaeSBBPfslucYVTLs >= 0)
				{
					uWgQQEaUflmejLoCOxKiQhkBHDjy = item;
					break;
				}
			}
			if (uWgQQEaUflmejLoCOxKiQhkBHDjy != null)
			{
				int num = uWgQQEaUflmejLoCOxKiQhkBHDjy.XeoHXRXJczOsaeSBBPfslucYVTLs;
				if (!UZmnsoFBcuRiJXtoBAtWzFImHVJC(P_1, num))
				{
					num = (uWgQQEaUflmejLoCOxKiQhkBHDjy.XeoHXRXJczOsaeSBBPfslucYVTLs = ijOSGIaGSXvSpXlIsVSMNGvQcJqt(P_1));
				}
				voOQpLoLKgCpKjxOPbvjRKkipUrbA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				voOQpLoLKgCpKjxOPbvjRKkipUrbA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = uWgQQEaUflmejLoCOxKiQhkBHDjy.qeGGNAgiikqIfJhZCprhjgPFuzOsA;
				PDORKhVEtGCaDsHbeiCADuTLSXlFA.CfktenxpmgHWVsjLgpxOWPrOcMMu(uWgQQEaUflmejLoCOxKiQhkBHDjy, voOQpLoLKgCpKjxOPbvjRKkipUrbA);
			}
		}
	}

	private void ohFnuPQGPqNHAJQZFQvhaodttCCg()
	{
		LeORUWzrOfikzKALqTVekZZWbzHA.Clear();
		UnityInputHelper.GetJoystickNames(LeORUWzrOfikzKALqTVekZZWbzHA);
		if (IqFOiuInKQdOHLSsyDThSMfXmDMh || VAbTpcjRShXserHVQbOKJjMRQBajA(LeORUWzrOfikzKALqTVekZZWbzHA))
		{
			uHyiQhNUQnBppYZYQCGBeSbdajrAA(LeORUWzrOfikzKALqTVekZZWbzHA);
		}
		kiEMouOlTGQiTyoPBvEkmLGifovaA = false;
		if (IqFOiuInKQdOHLSsyDThSMfXmDMh)
		{
			IqFOiuInKQdOHLSsyDThSMfXmDMh = false;
		}
	}

	private bool VAbTpcjRShXserHVQbOKJjMRQBajA(IList<string> P_0)
	{
		if (P_0.Count != RSKUfwjwepZGgfggfeOmYUAOWjhq.Count)
		{
			return true;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (!string.Equals(P_0[i], RSKUfwjwepZGgfggfeOmYUAOWjhq[i], StringComparison.Ordinal))
			{
				return true;
			}
		}
		return false;
	}

	private void ghMTHdRMzrcgUFFJYjNdwmrIMjxCb(List<VoOQpLoLKgCpKjxOPbvjRKkipUrbA> P_0, List<VoOQpLoLKgCpKjxOPbvjRKkipUrbA> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			VoOQpLoLKgCpKjxOPbvjRKkipUrbA voOQpLoLKgCpKjxOPbvjRKkipUrbA = P_0[i];
			if (voOQpLoLKgCpKjxOPbvjRKkipUrbA == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					VoOQpLoLKgCpKjxOPbvjRKkipUrbA voOQpLoLKgCpKjxOPbvjRKkipUrbA2 = P_1[j];
					if (voOQpLoLKgCpKjxOPbvjRKkipUrbA2 != null && voOQpLoLKgCpKjxOPbvjRKkipUrbA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == voOQpLoLKgCpKjxOPbvjRKkipUrbA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				SHdhKJDIABlpUbwwvEWNmfecmPKJA(P_0[i], P_2);
			}
		}
	}

	private void SHdhKJDIABlpUbwwvEWNmfecmPKJA(VoOQpLoLKgCpKjxOPbvjRKkipUrbA P_0, bool P_1)
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

	private void KmArPLlwJvGMPnPcEeEqtpGHEeyDA()
	{
		if (NSVRsDQJeNrVHqZOlxldIYQgiHXN == QGzHQIryGfmKXVBAZgfQkCyLeCQg && dMRGVScOSUrbxzAWCdqnlgZACTWd.Update())
		{
			kiEMouOlTGQiTyoPBvEkmLGifovaA = true;
			dMRGVScOSUrbxzAWCdqnlgZACTWd.Start();
		}
	}

	private static void SawbbDIUTsEqajEuNqcdhPplxpOQ()
	{
		if (UnityTools.platform == Platform.tvOS)
		{
			ConfigVars.PlatformVars_tvOS platformVars_tvOS = ReInput.configVars.platformVars_tvOS;
			if (platformVars_tvOS != null)
			{
				UnityTools.externalTools.tvOS_allowExitToHome = platformVars_tvOS.enableBackButtonReturnsHome;
				UnityTools.externalTools.tvOS_allowRemoteRotation = platformVars_tvOS.allowRemoteDPadRotation;
				UnityTools.externalTools.tvOS_remoteReportAbsoluteDpadValues = platformVars_tvOS.useAbsoluteRemoteTouchpadMode;
			}
		}
	}
}
