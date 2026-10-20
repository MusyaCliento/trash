using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;

internal class txkYxYNaRvrSmvcVDfwGAFpPOGfs : PlatformInputManager
{
	private class BVliuJdLfdooYvdWMHmHubexOWi : IInputManagerJoystick, IInputManagerJoystickPublic, IDisposable
	{
		private int DiPgnGbKpiTtQtaPiEtkUjmjISVbA;

		private int ThDEFltqPmtloXArdTRZcrDhFdrp;

		public Guid BggxxnajPLRuIQWRXydAOxhlqHBL;

		public string IFJitOvZColSBLJyPNEHrEmbjXXH;

		public GYSwgkbaVYVjtqJQdbyLjufrdwPAA ByYHJvvsNLikExQDcIHpeVPVcYkcA;

		public string ZKaaPAemsyKazeuSOoxPOyHjsgeuA;

		public string smNfgIlOwmGJmfxFpTXHtAsRNuwt;

		public Guid FpmcirpiXejnlFAoZivEeqcHbefdA;

		public PidVid mkOsgBeedYGmUkdxOcZdYvPNAMRi;

		public Guid YlBMcaLUkWRbMCskKuAefgQdCKWQ;

		public int KDMfqEtGXlFPquKztxXlInERgcrX;

		public int OTUmCzphqKstsoMvUgtNRBWvqUsF;

		public int sEzbOJIlwDIUjmkdIHuAEFGGxjgMB;

		public int HssfhtgDSvcpsBhVBMNEkfJEFIDWC;

		public int tCYzitdXbAUxFAvNwrEMIiPHzYqk;

		public int SQKLRALcBaAlEhWanovFhgcFAuHxA;

		public bool OXYZxYptIBmsbhkYRjQbVtPgOaAY;

		public int LnFPJwegfOhEVUmaIcotDLBdWvFI;

		private float[] QpfkIvcNxMexqFAQlxTBKTvnvWdb;

		private float[] CMDkPRTYJHPltzNhOBlqJxCdNHMHA;

		private bool[] bCeHRUuHflEjRooGyjTCreyLnNBv;

		private HardwareJoystickMap_InputManager hjUBfbQrHAwCBfbMEdDuInWXPJRdA;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> KpQAyLdOCmXLHYjEdQsuAKpJjmtQ;

		private bool AuvqmGRPtKtpmoQdoUpBYXCuiWFb;

		private bool sFZLPfKaCXvCjrnapRWgwPMasLlf;

		[CompilerGenerated]
		private Controller.Extension KFtihoLKmRyKPqAWceitvOAZcELCA;

		private bool KTLBEtUreGOoHuTgvdfBTHaikGbm;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return DiPgnGbKpiTtQtaPiEtkUjmjISVbA;
			}
			set
			{
				DiPgnGbKpiTtQtaPiEtkUjmjISVbA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return ThDEFltqPmtloXArdTRZcrDhFdrp;
			}
			set
			{
				ThDEFltqPmtloXArdTRZcrDhFdrp = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (!(IFJitOvZColSBLJyPNEHrEmbjXXH != "Unknown Controller"))
				{
					return smNfgIlOwmGJmfxFpTXHtAsRNuwt;
				}
				return IFJitOvZColSBLJyPNEHrEmbjXXH;
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (ThDEFltqPmtloXArdTRZcrDhFdrp < 0)
				{
					return null;
				}
				return ThDEFltqPmtloXArdTRZcrDhFdrp;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => FpmcirpiXejnlFAoZivEeqcHbefdA;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid
		{
			get
			{
				if (ByYHJvvsNLikExQDcIHpeVPVcYkcA == null)
				{
					return Guid.Empty;
				}
				return ByYHJvvsNLikExQDcIHpeVPVcYkcA.gyGjaFSlGkIKYHpoMPbNAwJQdyKBA;
			}
		}

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension
		{
			[CompilerGenerated]
			get
			{
				return KFtihoLKmRyKPqAWceitvOAZcELCA;
			}
			[CompilerGenerated]
			set
			{
				KFtihoLKmRyKPqAWceitvOAZcELCA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			if (OXYZxYptIBmsbhkYRjQbVtPgOaAY)
			{
				ByYHJvvsNLikExQDcIHpeVPVcYkcA.ykWDOOWBAQlmsCdWkbbFAvbhRegT(motorIndex, amount, false);
			}
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			if (OXYZxYptIBmsbhkYRjQbVtPgOaAY)
			{
				ByYHJvvsNLikExQDcIHpeVPVcYkcA.opUJeQawNrCPXsYIxoJCEeuXrAys();
			}
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public BVliuJdLfdooYvdWMHmHubexOWi(Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_0)
		{
			KpQAyLdOCmXLHYjEdQsuAKpJjmtQ = P_0;
			ThDEFltqPmtloXArdTRZcrDhFdrp = -1;
			DiPgnGbKpiTtQtaPiEtkUjmjISVbA = -1;
		}

		public void skPSyTCIJJfVJgwkPIIgAmqCPphA()
		{
			YlBMcaLUkWRbMCskKuAefgQdCKWQ = MiscTools.CreateGuidHashSHA1(smNfgIlOwmGJmfxFpTXHtAsRNuwt + mkOsgBeedYGmUkdxOcZdYvPNAMRi.ToProductGuid().ToString());
			OTUmCzphqKstsoMvUgtNRBWvqUsF = HssfhtgDSvcpsBhVBMNEkfJEFIDWC;
			sEzbOJIlwDIUjmkdIHuAEFGGxjgMB = tCYzitdXbAUxFAvNwrEMIiPHzYqk + SQKLRALcBaAlEhWanovFhgcFAuHxA * 8;
			FcWigqHnNDadJBozAsDjvnLnBHOVB();
			BggxxnajPLRuIQWRXydAOxhlqHBL = hjUBfbQrHAwCBfbMEdDuInWXPJRdA.hardwareMapIdentifier.guid;
			IFJitOvZColSBLJyPNEHrEmbjXXH = hjUBfbQrHAwCBfbMEdDuInWXPJRdA.controllerName;
			AuvqmGRPtKtpmoQdoUpBYXCuiWFb = BggxxnajPLRuIQWRXydAOxhlqHBL == Guid.Empty;
			QpfkIvcNxMexqFAQlxTBKTvnvWdb = new float[OTUmCzphqKstsoMvUgtNRBWvqUsF];
			CMDkPRTYJHPltzNhOBlqJxCdNHMHA = new float[sEzbOJIlwDIUjmkdIHuAEFGGxjgMB];
			bCeHRUuHflEjRooGyjTCreyLnNBv = new bool[sEzbOJIlwDIUjmkdIHuAEFGGxjgMB];
			if (sEzbOJIlwDIUjmkdIHuAEFGGxjgMB > 0)
			{
				HardwareJoystickMap.Platform_WindowsWGI_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)hjUBfbQrHAwCBfbMEdDuInWXPJRdA.map).Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						bCeHRUuHflEjRooGyjTCreyLnNBv[i] = buttons_orig[i].buttonInfo.isPressureSensitive;
					}
				}
			}
			Update();
		}

		public void jmbcAGyeGluOuJTRrupriLjCDKyaA(BVliuJdLfdooYvdWMHmHubexOWi P_0)
		{
			if (P_0 != null)
			{
				ThDEFltqPmtloXArdTRZcrDhFdrp = P_0.ThDEFltqPmtloXArdTRZcrDhFdrp;
				DiPgnGbKpiTtQtaPiEtkUjmjISVbA = P_0.DiPgnGbKpiTtQtaPiEtkUjmjISVbA;
				for (int i = 0; i < MathTools.Min(CMDkPRTYJHPltzNhOBlqJxCdNHMHA.Length, P_0.CMDkPRTYJHPltzNhOBlqJxCdNHMHA.Length); i++)
				{
					CMDkPRTYJHPltzNhOBlqJxCdNHMHA[i] = P_0.CMDkPRTYJHPltzNhOBlqJxCdNHMHA[i];
				}
				for (int j = 0; j < MathTools.Min(bCeHRUuHflEjRooGyjTCreyLnNBv.Length, P_0.bCeHRUuHflEjRooGyjTCreyLnNBv.Length); j++)
				{
					bCeHRUuHflEjRooGyjTCreyLnNBv[j] = P_0.bCeHRUuHflEjRooGyjTCreyLnNBv[j];
				}
				for (int k = 0; k < MathTools.Min(QpfkIvcNxMexqFAQlxTBKTvnvWdb.Length, P_0.QpfkIvcNxMexqFAQlxTBKTvnvWdb.Length); k++)
				{
					QpfkIvcNxMexqFAQlxTBKTvnvWdb[k] = P_0.QpfkIvcNxMexqFAQlxTBKTvnvWdb[k];
				}
				sFZLPfKaCXvCjrnapRWgwPMasLlf = P_0.sFZLPfKaCXvCjrnapRWgwPMasLlf;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			bjecIaywiKqGKlXLUgbveghGNvbB();
			vLlnWyJpxnrvVYAPKGkMwDpDaMTI();
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (OTUmCzphqKstsoMvUgtNRBWvqUsF != dataUpdater.axisCount || sEzbOJIlwDIUjmkdIHuAEFGGxjgMB != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < OTUmCzphqKstsoMvUgtNRBWvqUsF; i++)
			{
				dataUpdater.axisValues[i] = QpfkIvcNxMexqFAQlxTBKTvnvWdb[i];
			}
			for (int j = 0; j < sEzbOJIlwDIUjmkdIHuAEFGGxjgMB; j++)
			{
				if (bCeHRUuHflEjRooGyjTCreyLnNBv[j])
				{
					dataUpdater.buttonPressureValues[j] = CMDkPRTYJHPltzNhOBlqJxCdNHMHA[j];
				}
				else
				{
					dataUpdater.buttonValues[j] = CMDkPRTYJHPltzNhOBlqJxCdNHMHA[j] > 0f;
				}
			}
			if (sFZLPfKaCXvCjrnapRWgwPMasLlf && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int vWWBqOFPbjsiAPnvYVyPmRBLQItSA(BVliuJdLfdooYvdWMHmHubexOWi P_0)
		{
			if (P_0.DiPgnGbKpiTtQtaPiEtkUjmjISVbA == DiPgnGbKpiTtQtaPiEtkUjmjISVbA)
			{
				return 2;
			}
			if (HssfhtgDSvcpsBhVBMNEkfJEFIDWC != P_0.HssfhtgDSvcpsBhVBMNEkfJEFIDWC)
			{
				return 0;
			}
			if (tCYzitdXbAUxFAvNwrEMIiPHzYqk != P_0.tCYzitdXbAUxFAvNwrEMIiPHzYqk)
			{
				return 0;
			}
			if (SQKLRALcBaAlEhWanovFhgcFAuHxA != P_0.SQKLRALcBaAlEhWanovFhgcFAuHxA)
			{
				return 0;
			}
			if (P_0.FpmcirpiXejnlFAoZivEeqcHbefdA == FpmcirpiXejnlFAoZivEeqcHbefdA)
			{
				return 2;
			}
			if (P_0.YlBMcaLUkWRbMCskKuAefgQdCKWQ == YlBMcaLUkWRbMCskKuAefgQdCKWQ)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo qanTXgNNqlsCZobWUIBEtDThDJTE()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			mPtqAPUizRnNyGeDjPewzfBREWFz(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			HEDzODxwlRtNSDsDmilJVKIgkbPk(bridgedController);
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
			return new ControllerDisconnectedEventArgs(DiPgnGbKpiTtQtaPiEtkUjmjISVbA);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void bjecIaywiKqGKlXLUgbveghGNvbB()
		{
			if (OTUmCzphqKstsoMvUgtNRBWvqUsF <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_WindowsWGI_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)hjUBfbQrHAwCBfbMEdDuInWXPJRdA.map).Axes_orig;
			if (axes_orig != null)
			{
				for (int i = 0; i < axes_orig.Length; i++)
				{
					jVyVSmnAnoTwyaUwGCQWBrhBydWg(axes_orig[i], i);
				}
			}
		}

		private void vLlnWyJpxnrvVYAPKGkMwDpDaMTI()
		{
			if (sEzbOJIlwDIUjmkdIHuAEFGGxjgMB <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_WindowsWGI_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)hjUBfbQrHAwCBfbMEdDuInWXPJRdA.map).Buttons_orig;
			if (buttons_orig != null)
			{
				for (int i = 0; i < buttons_orig.Length; i++)
				{
					unPDusSZTQaLEjLjIgBJCCibEhyLA(buttons_orig[i], i);
				}
			}
		}

		private void jVyVSmnAnoTwyaUwGCQWBrhBydWg(HardwareJoystickMap.Platform_WindowsWGI_Base.Axis P_0, int P_1)
		{
			if (P_1 >= OTUmCzphqKstsoMvUgtNRBWvqUsF)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			QpfkIvcNxMexqFAQlxTBKTvnvWdb[P_1] = iJKmilQBjDiUjcEJhVFgKABdgdkTA(P_0);
			if (!sFZLPfKaCXvCjrnapRWgwPMasLlf && QpfkIvcNxMexqFAQlxTBKTvnvWdb[P_1] != 0f)
			{
				sFZLPfKaCXvCjrnapRWgwPMasLlf = true;
			}
		}

		private void unPDusSZTQaLEjLjIgBJCCibEhyLA(HardwareJoystickMap.Platform_WindowsWGI_Base.Button P_0, int P_1)
		{
			if (P_1 >= sEzbOJIlwDIUjmkdIHuAEFGGxjgMB)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			CMDkPRTYJHPltzNhOBlqJxCdNHMHA[P_1] = wTKDcVISrpDQYJLEnltCEigSXFUW(P_0);
			if (!sFZLPfKaCXvCjrnapRWgwPMasLlf && CMDkPRTYJHPltzNhOBlqJxCdNHMHA[P_1] != 0f)
			{
				sFZLPfKaCXvCjrnapRWgwPMasLlf = true;
			}
		}

		private float iJKmilQBjDiUjcEJhVFgKABdgdkTA(HardwareJoystickMap.Platform_WindowsWGI_Base.Axis P_0)
		{
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0)
				{
					return 0f;
				}
				return BISQdMffUQkhSUWPyOjMRIqawXso(sourceAxis);
			}
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= tCYzitdXbAUxFAvNwrEMIiPHzYqk || sourceButton >= 256)
				{
					return 0f;
				}
				if (!ByYHJvvsNLikExQDcIHpeVPVcYkcA.kWQvonyAXhZxZdQbkYAODgDnhkZb(sourceButton))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			}
			if (P_0.sourceType == 2)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= SQKLRALcBaAlEhWanovFhgcFAuHxA || sourceHat >= 4)
				{
					return 0f;
				}
				int num = ByYHJvvsNLikExQDcIHpeVPVcYkcA.dxtHutHxyjJjhPOUSYhOKexWAsln(sourceHat);
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = cHHRTrKXOgjAhNjfFIkSioankfsab(num, AxisDirection.Horizontal);
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
					num2 = cHHRTrKXOgjAhNjfFIkSioankfsab(num, AxisDirection.Vertical);
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
			return 0f;
		}

		private float BISQdMffUQkhSUWPyOjMRIqawXso(int P_0)
		{
			if (P_0 < 0 || P_0 >= ByYHJvvsNLikExQDcIHpeVPVcYkcA.rCcXGUApoEJROjFiVxYNHCMObaGHA)
			{
				return 0f;
			}
			return ByYHJvvsNLikExQDcIHpeVPVcYkcA.AzVoIklerCSmwIiVRrfDYOGxwnLA(P_0);
		}

		private float wTKDcVISrpDQYJLEnltCEigSXFUW(HardwareJoystickMap.Platform_WindowsWGI_Base.Button P_0)
		{
			if (P_0.sourceType == 0)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (ByYHJvvsNLikExQDcIHpeVPVcYkcA.kWQvonyAXhZxZdQbkYAODgDnhkZb(P_0.ignoreIfButtonsActiveButtons[i]))
						{
							return 0f;
						}
					}
				}
				if (P_0.requireMultipleButtons)
				{
					bool flag = false;
					for (int j = 0; j < P_0.requiredButtons.Length; j++)
					{
						if (!ByYHJvvsNLikExQDcIHpeVPVcYkcA.kWQvonyAXhZxZdQbkYAODgDnhkZb(P_0.requiredButtons[j]))
						{
							return 0f;
						}
						flag = true;
					}
					if (flag)
					{
						return 1f;
					}
					return 0f;
				}
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= tCYzitdXbAUxFAvNwrEMIiPHzYqk || sourceButton >= 256)
				{
					return 0f;
				}
				if (!ByYHJvvsNLikExQDcIHpeVPVcYkcA.kWQvonyAXhZxZdQbkYAODgDnhkZb(sourceButton))
				{
					return 0f;
				}
				return 1f;
			}
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0)
				{
					return 0f;
				}
				float num = BISQdMffUQkhSUWPyOjMRIqawXso(sourceAxis);
				float num2 = MathTools.Abs(num);
				if (num2 <= P_0.axisDeadZone)
				{
					return 0f;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
				{
					if (num < 0f)
					{
						return 0f;
					}
				}
				else if (num > 0f)
				{
					return 0f;
				}
				return num2;
			}
			if (P_0.sourceType == 2)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= SQKLRALcBaAlEhWanovFhgcFAuHxA || sourceHat >= 4)
				{
					return 0f;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return UvFGiiiuREtTmQEFUzLLQEKzituP(ByYHJvvsNLikExQDcIHpeVPVcYkcA.dxtHutHxyjJjhPOUSYhOKexWAsln(sourceHat), 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return UvFGiiiuREtTmQEFUzLLQEKzituP(ByYHJvvsNLikExQDcIHpeVPVcYkcA.dxtHutHxyjJjhPOUSYhOKexWAsln(sourceHat), 1, P_0.sourceHatType);
				case HatDirection.Right:
					return UvFGiiiuREtTmQEFUzLLQEKzituP(ByYHJvvsNLikExQDcIHpeVPVcYkcA.dxtHutHxyjJjhPOUSYhOKexWAsln(sourceHat), 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return UvFGiiiuREtTmQEFUzLLQEKzituP(ByYHJvvsNLikExQDcIHpeVPVcYkcA.dxtHutHxyjJjhPOUSYhOKexWAsln(sourceHat), 3, P_0.sourceHatType);
				case HatDirection.Down:
					return UvFGiiiuREtTmQEFUzLLQEKzituP(ByYHJvvsNLikExQDcIHpeVPVcYkcA.dxtHutHxyjJjhPOUSYhOKexWAsln(sourceHat), 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return UvFGiiiuREtTmQEFUzLLQEKzituP(ByYHJvvsNLikExQDcIHpeVPVcYkcA.dxtHutHxyjJjhPOUSYhOKexWAsln(sourceHat), 5, P_0.sourceHatType);
				case HatDirection.Left:
					return UvFGiiiuREtTmQEFUzLLQEKzituP(ByYHJvvsNLikExQDcIHpeVPVcYkcA.dxtHutHxyjJjhPOUSYhOKexWAsln(sourceHat), 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return UvFGiiiuREtTmQEFUzLLQEKzituP(ByYHJvvsNLikExQDcIHpeVPVcYkcA.dxtHutHxyjJjhPOUSYhOKexWAsln(sourceHat), 7, P_0.sourceHatType);
				}
			}
			return 0f;
		}

		private float UvFGiiiuREtTmQEFUzLLQEKzituP(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (hjUBfbQrHAwCBfbMEdDuInWXPJRdA.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				return 0f;
			}
			int num = 4500 * P_1;
			if (P_2 == HatType.EightWay && P_0 != num)
			{
				return 0f;
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
				return 1f;
			}
			return 0f;
		}

		private float cHHRTrKXOgjAhNjfFIkSioankfsab(int P_0, AxisDirection P_1)
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

		private void FcWigqHnNDadJBozAsDjvnLnBHOVB()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = qanTXgNNqlsCZobWUIBEtDThDJTE();
			hjUBfbQrHAwCBfbMEdDuInWXPJRdA = KpQAyLdOCmXLHYjEdQsuAKpJjmtQ(bridgedControllerHWInfo);
			bool flag = false;
			bool flag2 = false;
			if (hjUBfbQrHAwCBfbMEdDuInWXPJRdA == null || hjUBfbQrHAwCBfbMEdDuInWXPJRdA.hardwareMapIdentifier.guid == Consts.joystickGuid_unknownController)
			{
				if (ByYHJvvsNLikExQDcIHpeVPVcYkcA.wdgGzAiFeFfdwCWXhtKcauHcRIjNe)
				{
					bridgedControllerHWInfo.hw_pidVid = new PidVid(4607, 10462);
					bridgedControllerHWInfo.hw_productId = bridgedControllerHWInfo.hw_pidVid.productId;
					bridgedControllerHWInfo.hw_vendorId = bridgedControllerHWInfo.hw_pidVid.vendorId;
					hjUBfbQrHAwCBfbMEdDuInWXPJRdA = KpQAyLdOCmXLHYjEdQsuAKpJjmtQ(bridgedControllerHWInfo);
					flag2 = true;
				}
				if (hjUBfbQrHAwCBfbMEdDuInWXPJRdA == null || hjUBfbQrHAwCBfbMEdDuInWXPJRdA.hardwareMapIdentifier.guid == Consts.joystickGuid_unknownController)
				{
					bridgedControllerHWInfo.hw_pidVid = new PidVid(736, 1118);
					bridgedControllerHWInfo.hw_productId = bridgedControllerHWInfo.hw_pidVid.productId;
					bridgedControllerHWInfo.hw_vendorId = bridgedControllerHWInfo.hw_pidVid.vendorId;
					bridgedControllerHWInfo.definitionMatchTag = string.Empty;
					hjUBfbQrHAwCBfbMEdDuInWXPJRdA = KpQAyLdOCmXLHYjEdQsuAKpJjmtQ(bridgedControllerHWInfo);
					flag = true;
				}
			}
			if (hjUBfbQrHAwCBfbMEdDuInWXPJRdA == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			if (flag)
			{
				string text = string.Format("{0}:{1}", ByYHJvvsNLikExQDcIHpeVPVcYkcA.TSJYXEZNXMWoZQNpmHRZexREYzvc.vendorId.ToString("x4"), ByYHJvvsNLikExQDcIHpeVPVcYkcA.TSJYXEZNXMWoZQNpmHRZexREYzvc.productId.ToString("x4"));
				string key = LocalizationManager.AppendToKeyAsPath("windows_gaming_input_gamepad", text);
				hjUBfbQrHAwCBfbMEdDuInWXPJRdA.deviceLocalizationInfo.InsertParentKey(0, key);
				hjUBfbQrHAwCBfbMEdDuInWXPJRdA.deviceLocalizationInfo.InsertParentKey(1, "windows_gaming_input_gamepad");
				hjUBfbQrHAwCBfbMEdDuInWXPJRdA.deviceLocalizationInfo.additionalIdentifyingInformation = $"[{text}]";
			}
			else if (ByYHJvvsNLikExQDcIHpeVPVcYkcA.wdgGzAiFeFfdwCWXhtKcauHcRIjNe && (flag2 || hjUBfbQrHAwCBfbMEdDuInWXPJRdA.hardwareMapIdentifier.guid == Consts.joystickGuid_steamController))
			{
				string text2 = string.Format("{0}:{1}", ByYHJvvsNLikExQDcIHpeVPVcYkcA.TSJYXEZNXMWoZQNpmHRZexREYzvc.vendorId.ToString("x4"), ByYHJvvsNLikExQDcIHpeVPVcYkcA.TSJYXEZNXMWoZQNpmHRZexREYzvc.productId.ToString("x4"));
				string key2 = LocalizationManager.AppendToKeyAsPath((hjUBfbQrHAwCBfbMEdDuInWXPJRdA.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(hjUBfbQrHAwCBfbMEdDuInWXPJRdA.deviceLocalizationInfo.parentKeys[0])) ? hjUBfbQrHAwCBfbMEdDuInWXPJRdA.deviceLocalizationInfo.parentKeys[0] : "steam_controller", text2);
				hjUBfbQrHAwCBfbMEdDuInWXPJRdA.deviceLocalizationInfo.InsertParentKey(0, key2);
				hjUBfbQrHAwCBfbMEdDuInWXPJRdA.deviceLocalizationInfo.additionalIdentifyingInformation = $"[{text2}]";
			}
			OTUmCzphqKstsoMvUgtNRBWvqUsF = hjUBfbQrHAwCBfbMEdDuInWXPJRdA.axisCount;
			sEzbOJIlwDIUjmkdIHuAEFGGxjgMB = hjUBfbQrHAwCBfbMEdDuInWXPJRdA.buttonCount;
		}

		private string PmoONkkuImvCsYWYpIcOvFJbgFIbA()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.WindowsGamingInput}{ByYHJvvsNLikExQDcIHpeVPVcYkcA.vxWAOXKtrIlNsYDtpXttCwLCymuJ}{smNfgIlOwmGJmfxFpTXHtAsRNuwt}{mkOsgBeedYGmUkdxOcZdYvPNAMRi.ToString()}");
		}

		private void mPtqAPUizRnNyGeDjPewzfBREWFz(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.WindowsGamingInput;
			P_0.inputSource = ByYHJvvsNLikExQDcIHpeVPVcYkcA.NdNfEXbyQSbpWBPgMAfmEcNAbXDy;
			P_0.deviceType = (ControlDeviceType)ByYHJvvsNLikExQDcIHpeVPVcYkcA.vxWAOXKtrIlNsYDtpXttCwLCymuJ;
			P_0.hardwareIdentifier = PmoONkkuImvCsYWYpIcOvFJbgFIbA();
			P_0.hardwareAxisCount = HssfhtgDSvcpsBhVBMNEkfJEFIDWC;
			P_0.hardwareButtonCount = tCYzitdXbAUxFAvNwrEMIiPHzYqk;
			P_0.hardwareHatCount = SQKLRALcBaAlEhWanovFhgcFAuHxA;
			if (ByYHJvvsNLikExQDcIHpeVPVcYkcA.wdgGzAiFeFfdwCWXhtKcauHcRIjNe)
			{
				P_0.definitionMatchTag = "[STEAMCONFIGURED]";
			}
			P_0.hw_productName = smNfgIlOwmGJmfxFpTXHtAsRNuwt;
			P_0.hw_deviceGuid = FpmcirpiXejnlFAoZivEeqcHbefdA;
			P_0.hw_productId = mkOsgBeedYGmUkdxOcZdYvPNAMRi.productId;
			P_0.hw_vendorId = mkOsgBeedYGmUkdxOcZdYvPNAMRi.vendorId;
			P_0.hw_pidVid = mkOsgBeedYGmUkdxOcZdYvPNAMRi;
			P_0.hw_isBluetoothDevice = false;
			P_0.hw_bluetoothDeviceName = smNfgIlOwmGJmfxFpTXHtAsRNuwt;
			P_0.hw_supportsVibration = OXYZxYptIBmsbhkYRjQbVtPgOaAY;
			P_0.hw_localVibrationMotorCount = LnFPJwegfOhEVUmaIcotDLBdWvFI;
		}

		private void HEDzODxwlRtNSDsDmilJVKIgkbPk(BridgedController P_0)
		{
			mPtqAPUizRnNyGeDjPewzfBREWFz(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = hjUBfbQrHAwCBfbMEdDuInWXPJRdA.ToGameHardwareControllerMap();
			P_0.instanceName = ZKaaPAemsyKazeuSOoxPOyHjsgeuA;
			P_0.productName = smNfgIlOwmGJmfxFpTXHtAsRNuwt;
			P_0.axisCount = OTUmCzphqKstsoMvUgtNRBWvqUsF;
			P_0.buttonCount = sEzbOJIlwDIUjmkdIHuAEFGGxjgMB;
			P_0.isButtonPressureSensitive = new bool[sEzbOJIlwDIUjmkdIHuAEFGGxjgMB];
			Array.Copy(bCeHRUuHflEjRooGyjTCreyLnNBv, P_0.isButtonPressureSensitive, sEzbOJIlwDIUjmkdIHuAEFGGxjgMB);
			P_0.unknownControllerHats = iBAZBVBjvpevLcgTZDcEaHpOVQEC();
			P_0.controllerTypeGuid = BggxxnajPLRuIQWRXydAOxhlqHBL;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		private void LMnUhFFJsrySkPqwLeXvoVLJGsue()
		{
			for (int i = 0; i < sEzbOJIlwDIUjmkdIHuAEFGGxjgMB; i++)
			{
				CMDkPRTYJHPltzNhOBlqJxCdNHMHA[i] = 0f;
			}
			for (int j = 0; j < OTUmCzphqKstsoMvUgtNRBWvqUsF; j++)
			{
				QpfkIvcNxMexqFAQlxTBKTvnvWdb[j] = 0f;
			}
		}

		private UnknownControllerHat[] iBAZBVBjvpevLcgTZDcEaHpOVQEC()
		{
			if (!AuvqmGRPtKtpmoQdoUpBYXCuiWFb)
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

		public void Dispose()
		{
			BVtIGvcsxnTWjEEQIiLbySBkOHWt(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void KUpZJAtMSVGHmJAfDrpTIAawUHiX()
		{
			try
			{
				BVtIGvcsxnTWjEEQIiLbySBkOHWt(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void BVtIGvcsxnTWjEEQIiLbySBkOHWt(bool P_0)
		{
			if (!KTLBEtUreGOoHuTgvdfBTHaikGbm)
			{
				if (P_0 && ByYHJvvsNLikExQDcIHpeVPVcYkcA != null)
				{
					ByYHJvvsNLikExQDcIHpeVPVcYkcA.Dispose();
				}
				KTLBEtUreGOoHuTgvdfBTHaikGbm = true;
			}
		}

		public static int zGceiCQprwrDlcHDgFnTFAECSLcD(BVliuJdLfdooYvdWMHmHubexOWi P_0, BVliuJdLfdooYvdWMHmHubexOWi P_1)
		{
			if (P_0.ThDEFltqPmtloXArdTRZcrDhFdrp < P_1.ThDEFltqPmtloXArdTRZcrDhFdrp)
			{
				return -1;
			}
			if (P_0.ThDEFltqPmtloXArdTRZcrDhFdrp > P_1.ThDEFltqPmtloXArdTRZcrDhFdrp)
			{
				return 1;
			}
			return 0;
		}

		public static int UTriSPncUIEBGYixfuIyyPrTuKsW(BVliuJdLfdooYvdWMHmHubexOWi P_0, BVliuJdLfdooYvdWMHmHubexOWi P_1)
		{
			if (P_0.KDMfqEtGXlFPquKztxXlInERgcrX < P_1.KDMfqEtGXlFPquKztxXlInERgcrX)
			{
				return -1;
			}
			if (P_0.KDMfqEtGXlFPquKztxXlInERgcrX > P_1.KDMfqEtGXlFPquKztxXlInERgcrX)
			{
				return 1;
			}
			return 0;
		}
	}

	private class nwzfRfPOFebEYEXejrVvRWfFjfHdA
	{
		public enum ZDoDJVBKKBDmJvkxdtTMDtGOAHmdA
		{
			Exact = 0,
			Approximate = 1
		}

		public class vAGEyaEheFNNiXpMETnxXWPXLcbX
		{
			public int mWxCDZcUevEdKEwFKwWOTLidTull;

			public Guid jMyrshgNCOgvdHFPJfovaCVftVzCB;

			public Guid BwoRGiPMnjgpzCqfGHcMpUYDCFnvA;

			public int sNXmHgItwowJPYHUsANFxRJpYOUb;

			public int FjejOKBspZrQZyfqICGYFkbOILFm;

			public int vuaYVipLtiArYEfDsNZEGmTgXvVWb;

			public int GXXDxEOtzrCJZTFPoAsGgyKwCEOGA;

			public int fbTuALgMQQkbkIrNhLjgZpySbWXr;

			public int xFDLmHOVKtbtmeLtaAciqNNaFJzN;

			public bool LffwSeEllogoZhywDJJonRgdoByk(BVliuJdLfdooYvdWMHmHubexOWi P_0, ZDoDJVBKKBDmJvkxdtTMDtGOAHmdA P_1)
			{
				if (FjejOKBspZrQZyfqICGYFkbOILFm != P_0.HssfhtgDSvcpsBhVBMNEkfJEFIDWC)
				{
					return false;
				}
				if (vuaYVipLtiArYEfDsNZEGmTgXvVWb != P_0.tCYzitdXbAUxFAvNwrEMIiPHzYqk)
				{
					return false;
				}
				if (GXXDxEOtzrCJZTFPoAsGgyKwCEOGA != P_0.SQKLRALcBaAlEhWanovFhgcFAuHxA)
				{
					return false;
				}
				if (fbTuALgMQQkbkIrNhLjgZpySbWXr != P_0.sEzbOJIlwDIUjmkdIHuAEFGGxjgMB)
				{
					return false;
				}
				if (xFDLmHOVKtbtmeLtaAciqNNaFJzN != P_0.OTUmCzphqKstsoMvUgtNRBWvqUsF)
				{
					return false;
				}
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == mWxCDZcUevEdKEwFKwWOTLidTull)
				{
					return true;
				}
				return P_1 switch
				{
					ZDoDJVBKKBDmJvkxdtTMDtGOAHmdA.Exact => jMyrshgNCOgvdHFPJfovaCVftVzCB == P_0.FpmcirpiXejnlFAoZivEeqcHbefdA, 
					ZDoDJVBKKBDmJvkxdtTMDtGOAHmdA.Approximate => BwoRGiPMnjgpzCqfGHcMpUYDCFnvA == P_0.YlBMcaLUkWRbMCskKuAefgQdCKWQ, 
					_ => throw new NotImplementedException(), 
				};
			}
		}

		private sealed class ZBpVGilTYvhrqrTmkBnkFNLWZxzv : IEnumerable<vAGEyaEheFNNiXpMETnxXWPXLcbX>, IEnumerable, IEnumerator<vAGEyaEheFNNiXpMETnxXWPXLcbX>, IEnumerator, IDisposable
		{
			private int mpjRuEGnNUvPGFODMFhlxoUEaUXY;

			private vAGEyaEheFNNiXpMETnxXWPXLcbX DWKwIUkwOmgtfMvhUVSgXQLSfgsq;

			private int CRnUamNKZdwuQUqsjLHLYAikhGgGA;

			public nwzfRfPOFebEYEXejrVvRWfFjfHdA totmGtGqTKmFZhCXpjkbtqZnnMwX;

			private BVliuJdLfdooYvdWMHmHubexOWi ffcPTuKlwqsApjOevajwZEzSawds;

			public BVliuJdLfdooYvdWMHmHubexOWi GSWBTcvBZCcpvjEvaNSPBDJUAqPY;

			private ZDoDJVBKKBDmJvkxdtTMDtGOAHmdA CBZttxKjFpFppucLUGSPJthqddpdA;

			public ZDoDJVBKKBDmJvkxdtTMDtGOAHmdA poGcBwGajpheUuNIZKbwJVlYeZAo;

			private int lemmFTpjCMDbjIPMGBySBStMaDiW;

			private int lMzqfCCFPaOkLiLgTAVzpeyVwwDc;

			vAGEyaEheFNNiXpMETnxXWPXLcbX IEnumerator<vAGEyaEheFNNiXpMETnxXWPXLcbX>.Current
			{
				[DebuggerHidden]
				get
				{
					return DWKwIUkwOmgtfMvhUVSgXQLSfgsq;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return DWKwIUkwOmgtfMvhUVSgXQLSfgsq;
				}
			}

			[DebuggerHidden]
			public ZBpVGilTYvhrqrTmkBnkFNLWZxzv(int P_0)
			{
				mpjRuEGnNUvPGFODMFhlxoUEaUXY = P_0;
				CRnUamNKZdwuQUqsjLHLYAikhGgGA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				mpjRuEGnNUvPGFODMFhlxoUEaUXY = -2;
			}

			private bool MoveNext()
			{
				int num = mpjRuEGnNUvPGFODMFhlxoUEaUXY;
				nwzfRfPOFebEYEXejrVvRWfFjfHdA nwzfRfPOFebEYEXejrVvRWfFjfHdA2 = totmGtGqTKmFZhCXpjkbtqZnnMwX;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					mpjRuEGnNUvPGFODMFhlxoUEaUXY = -1;
					goto IL_0083;
				}
				mpjRuEGnNUvPGFODMFhlxoUEaUXY = -1;
				lemmFTpjCMDbjIPMGBySBStMaDiW = nwzfRfPOFebEYEXejrVvRWfFjfHdA2.ZzRaJtBYXdCKlasLFsHwWHSNkZlvB.Count;
				lMzqfCCFPaOkLiLgTAVzpeyVwwDc = 0;
				goto IL_0093;
				IL_0083:
				lMzqfCCFPaOkLiLgTAVzpeyVwwDc++;
				goto IL_0093;
				IL_0093:
				if (lMzqfCCFPaOkLiLgTAVzpeyVwwDc < lemmFTpjCMDbjIPMGBySBStMaDiW)
				{
					if (nwzfRfPOFebEYEXejrVvRWfFjfHdA2.ZzRaJtBYXdCKlasLFsHwWHSNkZlvB[lMzqfCCFPaOkLiLgTAVzpeyVwwDc].LffwSeEllogoZhywDJJonRgdoByk(ffcPTuKlwqsApjOevajwZEzSawds, CBZttxKjFpFppucLUGSPJthqddpdA))
					{
						DWKwIUkwOmgtfMvhUVSgXQLSfgsq = nwzfRfPOFebEYEXejrVvRWfFjfHdA2.ZzRaJtBYXdCKlasLFsHwWHSNkZlvB[lMzqfCCFPaOkLiLgTAVzpeyVwwDc];
						mpjRuEGnNUvPGFODMFhlxoUEaUXY = 1;
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
			IEnumerator<vAGEyaEheFNNiXpMETnxXWPXLcbX> IEnumerable<vAGEyaEheFNNiXpMETnxXWPXLcbX>.GetEnumerator()
			{
				ZBpVGilTYvhrqrTmkBnkFNLWZxzv zBpVGilTYvhrqrTmkBnkFNLWZxzv;
				if (mpjRuEGnNUvPGFODMFhlxoUEaUXY == -2 && CRnUamNKZdwuQUqsjLHLYAikhGgGA == Environment.CurrentManagedThreadId)
				{
					mpjRuEGnNUvPGFODMFhlxoUEaUXY = 0;
					zBpVGilTYvhrqrTmkBnkFNLWZxzv = this;
				}
				else
				{
					zBpVGilTYvhrqrTmkBnkFNLWZxzv = new ZBpVGilTYvhrqrTmkBnkFNLWZxzv(0);
					zBpVGilTYvhrqrTmkBnkFNLWZxzv.totmGtGqTKmFZhCXpjkbtqZnnMwX = totmGtGqTKmFZhCXpjkbtqZnnMwX;
				}
				zBpVGilTYvhrqrTmkBnkFNLWZxzv.ffcPTuKlwqsApjOevajwZEzSawds = GSWBTcvBZCcpvjEvaNSPBDJUAqPY;
				zBpVGilTYvhrqrTmkBnkFNLWZxzv.CBZttxKjFpFppucLUGSPJthqddpdA = poGcBwGajpheUuNIZKbwJVlYeZAo;
				return zBpVGilTYvhrqrTmkBnkFNLWZxzv;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<vAGEyaEheFNNiXpMETnxXWPXLcbX>)this).GetEnumerator();
			}
		}

		private List<vAGEyaEheFNNiXpMETnxXWPXLcbX> ZzRaJtBYXdCKlasLFsHwWHSNkZlvB;

		public nwzfRfPOFebEYEXejrVvRWfFjfHdA()
		{
			ZzRaJtBYXdCKlasLFsHwWHSNkZlvB = new List<vAGEyaEheFNNiXpMETnxXWPXLcbX>();
		}

		public void sQBDCFGaCAilbJdIsPEtGZxhfXYU(BVliuJdLfdooYvdWMHmHubexOWi P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = ZzRaJtBYXdCKlasLFsHwWHSNkZlvB.Count;
			for (int i = 0; i < count; i++)
			{
				if (ZzRaJtBYXdCKlasLFsHwWHSNkZlvB[i].LffwSeEllogoZhywDJJonRgdoByk(P_0, ZDoDJVBKKBDmJvkxdtTMDtGOAHmdA.Exact))
				{
					ZzRaJtBYXdCKlasLFsHwWHSNkZlvB[i].mWxCDZcUevEdKEwFKwWOTLidTull = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					ZzRaJtBYXdCKlasLFsHwWHSNkZlvB[i].jMyrshgNCOgvdHFPJfovaCVftVzCB = P_0.FpmcirpiXejnlFAoZivEeqcHbefdA;
					ZzRaJtBYXdCKlasLFsHwWHSNkZlvB[i].BwoRGiPMnjgpzCqfGHcMpUYDCFnvA = P_0.YlBMcaLUkWRbMCskKuAefgQdCKWQ;
					ZzRaJtBYXdCKlasLFsHwWHSNkZlvB[i].sNXmHgItwowJPYHUsANFxRJpYOUb = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					ZzRaJtBYXdCKlasLFsHwWHSNkZlvB[i].FjejOKBspZrQZyfqICGYFkbOILFm = P_0.HssfhtgDSvcpsBhVBMNEkfJEFIDWC;
					ZzRaJtBYXdCKlasLFsHwWHSNkZlvB[i].vuaYVipLtiArYEfDsNZEGmTgXvVWb = P_0.tCYzitdXbAUxFAvNwrEMIiPHzYqk;
					ZzRaJtBYXdCKlasLFsHwWHSNkZlvB[i].GXXDxEOtzrCJZTFPoAsGgyKwCEOGA = P_0.SQKLRALcBaAlEhWanovFhgcFAuHxA;
					ZzRaJtBYXdCKlasLFsHwWHSNkZlvB[i].fbTuALgMQQkbkIrNhLjgZpySbWXr = P_0.sEzbOJIlwDIUjmkdIHuAEFGGxjgMB;
					ZzRaJtBYXdCKlasLFsHwWHSNkZlvB[i].xFDLmHOVKtbtmeLtaAciqNNaFJzN = P_0.OTUmCzphqKstsoMvUgtNRBWvqUsF;
					VirhNLmhjoEISRZdkSbgpSZDiuax(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.FpmcirpiXejnlFAoZivEeqcHbefdA, i);
					return;
				}
			}
			ZzRaJtBYXdCKlasLFsHwWHSNkZlvB.Add(new vAGEyaEheFNNiXpMETnxXWPXLcbX
			{
				mWxCDZcUevEdKEwFKwWOTLidTull = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				jMyrshgNCOgvdHFPJfovaCVftVzCB = P_0.FpmcirpiXejnlFAoZivEeqcHbefdA,
				BwoRGiPMnjgpzCqfGHcMpUYDCFnvA = P_0.YlBMcaLUkWRbMCskKuAefgQdCKWQ,
				sNXmHgItwowJPYHUsANFxRJpYOUb = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				FjejOKBspZrQZyfqICGYFkbOILFm = P_0.HssfhtgDSvcpsBhVBMNEkfJEFIDWC,
				vuaYVipLtiArYEfDsNZEGmTgXvVWb = P_0.tCYzitdXbAUxFAvNwrEMIiPHzYqk,
				GXXDxEOtzrCJZTFPoAsGgyKwCEOGA = P_0.SQKLRALcBaAlEhWanovFhgcFAuHxA,
				fbTuALgMQQkbkIrNhLjgZpySbWXr = P_0.sEzbOJIlwDIUjmkdIHuAEFGGxjgMB,
				xFDLmHOVKtbtmeLtaAciqNNaFJzN = P_0.OTUmCzphqKstsoMvUgtNRBWvqUsF
			});
			VirhNLmhjoEISRZdkSbgpSZDiuax(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.FpmcirpiXejnlFAoZivEeqcHbefdA, ZzRaJtBYXdCKlasLFsHwWHSNkZlvB.Count - 1);
		}

		public bool nWXbXuGdBdQHmMOrzFVLhtFlGHISA(BVliuJdLfdooYvdWMHmHubexOWi P_0, ZDoDJVBKKBDmJvkxdtTMDtGOAHmdA P_1)
		{
			int count = ZzRaJtBYXdCKlasLFsHwWHSNkZlvB.Count;
			for (int i = 0; i < count; i++)
			{
				if (ZzRaJtBYXdCKlasLFsHwWHSNkZlvB[i].LffwSeEllogoZhywDJJonRgdoByk(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(ZBpVGilTYvhrqrTmkBnkFNLWZxzv))]
		public IEnumerable<vAGEyaEheFNNiXpMETnxXWPXLcbX> xVjJfezQvCvJFLGYYEDsKbLkBQnd(BVliuJdLfdooYvdWMHmHubexOWi P_0, ZDoDJVBKKBDmJvkxdtTMDtGOAHmdA P_1)
		{
			return new ZBpVGilTYvhrqrTmkBnkFNLWZxzv(-2)
			{
				totmGtGqTKmFZhCXpjkbtqZnnMwX = this,
				GSWBTcvBZCcpvjEvaNSPBDJUAqPY = P_0,
				poGcBwGajpheUuNIZKbwJVlYeZAo = P_1
			};
		}

		private void VirhNLmhjoEISRZdkSbgpSZDiuax(int P_0, Guid P_1, int P_2)
		{
			for (int num = ZzRaJtBYXdCKlasLFsHwWHSNkZlvB.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (ZzRaJtBYXdCKlasLFsHwWHSNkZlvB[num].mWxCDZcUevEdKEwFKwWOTLidTull == P_0 || ZzRaJtBYXdCKlasLFsHwWHSNkZlvB[num].jMyrshgNCOgvdHFPJfovaCVftVzCB == P_1))
				{
					ZzRaJtBYXdCKlasLFsHwWHSNkZlvB.RemoveAt(num);
				}
			}
		}
	}

	private static bool PQeopZOzPsbkbMTDphwenWoteJRs = true;

	private qHidpjGFjalqPglhJrYfYDNNXiKhA zvtqPbhsiGyoruxKupwbkoKemczC;

	private List<BVliuJdLfdooYvdWMHmHubexOWi> yLMNpTDNZEuLYUjzneyUGOqrqawpA;

	private int miZaNUKhYMinGfxkfoIcBqkOIGMF;

	private nwzfRfPOFebEYEXejrVvRWfFjfHdA izkGtPGrPAImgIEIdpvwtKUEBDJi;

	private bool fRGguVdXHzRjPtXINOUhHPbLAPog;

	private ConfigVars EyVfCOmRXDDNWiCnctzUbKKltHCD;

	private Action<int, ControllerDataUpdater> NNKCPrikPziiJiJAhuoMBXGaJyEdD;

	private PlatformInputManager xNpwExCeRPtocLTszBAdIMqAcUyEA;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> HFOCmHNSMajHicUJYSRWtkpaBYZs;

	private readonly Func<int> cwHFMjKazPFteQPOAosTBljzHGpab;

	private Func<PidVid, bool> afbDuQdWutadGsHgaJPGIYgOFOdT;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => miZaNUKhYMinGfxkfoIcBqkOIGMF;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => xNpwExCeRPtocLTszBAdIMqAcUyEA;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => zvtqPbhsiGyoruxKupwbkoKemczC;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.WindowsGamingInput;

	protected qHidpjGFjalqPglhJrYfYDNNXiKhA alJUEFDKoDLJwTXxZhGZtNXCGclz => zvtqPbhsiGyoruxKupwbkoKemczC;

	public txkYxYNaRvrSmvcVDfwGAFpPOGfs(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2, Func<PidVid, bool> P_3)
	{
		try
		{
			EyVfCOmRXDDNWiCnctzUbKKltHCD = P_0;
			HFOCmHNSMajHicUJYSRWtkpaBYZs = P_1;
			cwHFMjKazPFteQPOAosTBljzHGpab = P_2;
			afbDuQdWutadGsHgaJPGIYgOFOdT = P_3;
			xNpwExCeRPtocLTszBAdIMqAcUyEA = this;
			zvtqPbhsiGyoruxKupwbkoKemczC = new qHidpjGFjalqPglhJrYfYDNNXiKhA(P_0, PQeopZOzPsbkbMTDphwenWoteJRs, false, false);
			zvtqPbhsiGyoruxKupwbkoKemczC.Rewired_002EInterfaces_002EIInputSource_002EDeviceChangedEvent += SystemDeviceConnected;
			NNKCPrikPziiJiJAhuoMBXGaJyEdD = UpdateControllerData;
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
		if (PQeopZOzPsbkbMTDphwenWoteJRs)
		{
			izkGtPGrPAImgIEIdpvwtKUEBDJi = new nwzfRfPOFebEYEXejrVvRWfFjfHdA();
			zvtqPbhsiGyoruxKupwbkoKemczC.buaArESrHYuVyvPGpGrGBtjGigOOA();
			aqycAlhxpGSRWJRtUuVkeIcuTgpM();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (zvtqPbhsiGyoruxKupwbkoKemczC != null)
		{
			zvtqPbhsiGyoruxKupwbkoKemczC.Update();
		}
		if (PQeopZOzPsbkbMTDphwenWoteJRs)
		{
			if (fRGguVdXHzRjPtXINOUhHPbLAPog)
			{
				zDfXBOPMMReIfbheuztdULyHoTUIA();
			}
			if (zvtqPbhsiGyoruxKupwbkoKemczC != null)
			{
				zvtqPbhsiGyoruxKupwbkoKemczC.UpdateDevices(updateLoop);
			}
			afWxpDBVhhHmHIwDqBeRIHdHKxDJ();
			if (zvtqPbhsiGyoruxKupwbkoKemczC != null)
			{
				zvtqPbhsiGyoruxKupwbkoKemczC.UpdateFinished();
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (yLMNpTDNZEuLYUjzneyUGOqrqawpA != null)
		{
			int count = yLMNpTDNZEuLYUjzneyUGOqrqawpA.Count;
			for (int i = 0; i < count; i++)
			{
				if (yLMNpTDNZEuLYUjzneyUGOqrqawpA[i] != null)
				{
					yLMNpTDNZEuLYUjzneyUGOqrqawpA[i].Dispose();
				}
			}
		}
		if (zvtqPbhsiGyoruxKupwbkoKemczC != null)
		{
			zvtqPbhsiGyoruxKupwbkoKemczC.Dispose();
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return NNKCPrikPziiJiJAhuoMBXGaJyEdD;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		if (!PQeopZOzPsbkbMTDphwenWoteJRs)
		{
			return;
		}
		for (int i = 0; i < miZaNUKhYMinGfxkfoIcBqkOIGMF; i++)
		{
			if (yLMNpTDNZEuLYUjzneyUGOqrqawpA[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
			{
				yLMNpTDNZEuLYUjzneyUGOqrqawpA[i].FillData(data);
				return;
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		if (PQeopZOzPsbkbMTDphwenWoteJRs)
		{
			fRGguVdXHzRjPtXINOUhHPbLAPog = true;
		}
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		if (PQeopZOzPsbkbMTDphwenWoteJRs)
		{
			fRGguVdXHzRjPtXINOUhHPbLAPog = true;
		}
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		_ = PQeopZOzPsbkbMTDphwenWoteJRs;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return zvtqPbhsiGyoruxKupwbkoKemczC.ZCzNuxWaZFOsAYYAtIGcjJXYvIyD;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return zvtqPbhsiGyoruxKupwbkoKemczC.IYUlAHHdOrdATQMjbijocfecvrkP;
	}

	protected bool bjPVvaIGzcnMAUtknQjnqhepmXYv(PidVid P_0)
	{
		return afbDuQdWutadGsHgaJPGIYgOFOdT(P_0);
	}

	private void aqycAlhxpGSRWJRtUuVkeIcuTgpM()
	{
		gvYKLQosISdaluPzjtIsehIiABKo(wFkBazHYqgwQuiJFtkAeROYMlqdFb());
	}

	private void gvYKLQosISdaluPzjtIsehIiABKo(IList<GYSwgkbaVYVjtqJQdbyLjufrdwPAA> P_0)
	{
		int num = 0;
		List<BVliuJdLfdooYvdWMHmHubexOWi> list = yLMNpTDNZEuLYUjzneyUGOqrqawpA;
		int num2 = miZaNUKhYMinGfxkfoIcBqkOIGMF;
		yLMNpTDNZEuLYUjzneyUGOqrqawpA = new List<BVliuJdLfdooYvdWMHmHubexOWi>();
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null)
			{
				GYSwgkbaVYVjtqJQdbyLjufrdwPAA gYSwgkbaVYVjtqJQdbyLjufrdwPAA = P_0[i];
				BVliuJdLfdooYvdWMHmHubexOWi bVliuJdLfdooYvdWMHmHubexOWi = new BVliuJdLfdooYvdWMHmHubexOWi(HFOCmHNSMajHicUJYSRWtkpaBYZs);
				bVliuJdLfdooYvdWMHmHubexOWi.ByYHJvvsNLikExQDcIHpeVPVcYkcA = gYSwgkbaVYVjtqJQdbyLjufrdwPAA;
				bVliuJdLfdooYvdWMHmHubexOWi.FpmcirpiXejnlFAoZivEeqcHbefdA = gYSwgkbaVYVjtqJQdbyLjufrdwPAA.UczRmMphKIjxibxeycGOHPLgBLhWB;
				bVliuJdLfdooYvdWMHmHubexOWi.ZKaaPAemsyKazeuSOoxPOyHjsgeuA = gYSwgkbaVYVjtqJQdbyLjufrdwPAA.zsqqRgVbCZUvlcLtmNrbcrDQoXOO;
				bVliuJdLfdooYvdWMHmHubexOWi.smNfgIlOwmGJmfxFpTXHtAsRNuwt = gYSwgkbaVYVjtqJQdbyLjufrdwPAA.zsqqRgVbCZUvlcLtmNrbcrDQoXOO;
				bVliuJdLfdooYvdWMHmHubexOWi.mkOsgBeedYGmUkdxOcZdYvPNAMRi = gYSwgkbaVYVjtqJQdbyLjufrdwPAA.TSJYXEZNXMWoZQNpmHRZexREYzvc;
				bVliuJdLfdooYvdWMHmHubexOWi.KDMfqEtGXlFPquKztxXlInERgcrX = gYSwgkbaVYVjtqJQdbyLjufrdwPAA.NULQqqYqRiAwCnHNbYNkJhffFlxgA;
				bVliuJdLfdooYvdWMHmHubexOWi.HssfhtgDSvcpsBhVBMNEkfJEFIDWC = gYSwgkbaVYVjtqJQdbyLjufrdwPAA.rCcXGUApoEJROjFiVxYNHCMObaGHA;
				bVliuJdLfdooYvdWMHmHubexOWi.tCYzitdXbAUxFAvNwrEMIiPHzYqk = gYSwgkbaVYVjtqJQdbyLjufrdwPAA.xxzJHSYcTcDbBuYGXGsqzpUOHLLm;
				bVliuJdLfdooYvdWMHmHubexOWi.SQKLRALcBaAlEhWanovFhgcFAuHxA = gYSwgkbaVYVjtqJQdbyLjufrdwPAA.doTmghHpboxUvVDZjmlTKzVhaXnV;
				bVliuJdLfdooYvdWMHmHubexOWi.OXYZxYptIBmsbhkYRjQbVtPgOaAY = gYSwgkbaVYVjtqJQdbyLjufrdwPAA.wEAjJEGBUCWOVlPVIzdDujAGoGEVA;
				bVliuJdLfdooYvdWMHmHubexOWi.LnFPJwegfOhEVUmaIcotDLBdWvFI = gYSwgkbaVYVjtqJQdbyLjufrdwPAA.EhEvKsTSwMpbeVrQiYdcpDDSvfen;
				bVliuJdLfdooYvdWMHmHubexOWi.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension = gYSwgkbaVYVjtqJQdbyLjufrdwPAA.fruCHOVagEbTbJNEenPvFdQFqaIBB;
				bVliuJdLfdooYvdWMHmHubexOWi.ByYHJvvsNLikExQDcIHpeVPVcYkcA = gYSwgkbaVYVjtqJQdbyLjufrdwPAA;
				bVliuJdLfdooYvdWMHmHubexOWi.skPSyTCIJJfVJgwkPIIgAmqCPphA();
				yLMNpTDNZEuLYUjzneyUGOqrqawpA.Add(bVliuJdLfdooYvdWMHmHubexOWi);
				num++;
			}
		}
		miZaNUKhYMinGfxkfoIcBqkOIGMF = num;
		lAglupZZkHAkUGTbRVvmhILPkkeH(num2, num, list, yLMNpTDNZEuLYUjzneyUGOqrqawpA);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(yLMNpTDNZEuLYUjzneyUGOqrqawpA[j]));
			}
		}
		AygRHVjjtiOyVKgJXIhsvNqrGGEc(list, yLMNpTDNZEuLYUjzneyUGOqrqawpA, false);
		AygRHVjjtiOyVKgJXIhsvNqrGGEc(yLMNpTDNZEuLYUjzneyUGOqrqawpA, list, true);
	}

	private void afWxpDBVhhHmHIwDqBeRIHdHKxDJ()
	{
		for (int i = 0; i < miZaNUKhYMinGfxkfoIcBqkOIGMF; i++)
		{
			yLMNpTDNZEuLYUjzneyUGOqrqawpA[i]?.Update();
		}
	}

	private IList<GYSwgkbaVYVjtqJQdbyLjufrdwPAA> wFkBazHYqgwQuiJFtkAeROYMlqdFb()
	{
		return zvtqPbhsiGyoruxKupwbkoKemczC.GetJoysticks<GYSwgkbaVYVjtqJQdbyLjufrdwPAA>();
	}

	private void lAglupZZkHAkUGTbRVvmhILPkkeH(int P_0, int P_1, List<BVliuJdLfdooYvdWMHmHubexOWi> P_2, List<BVliuJdLfdooYvdWMHmHubexOWi> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(BVliuJdLfdooYvdWMHmHubexOWi.UTriSPncUIEBGYixfuIyyPrTuKsW);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			oxSFTHNRDVafDNTnsdlmifXijsHs(P_1, P_3, P_0, P_2, nwzfRfPOFebEYEXejrVvRWfFjfHdA.ZDoDJVBKKBDmJvkxdtTMDtGOAHmdA.Exact);
			oxSFTHNRDVafDNTnsdlmifXijsHs(P_1, P_3, P_0, P_2, nwzfRfPOFebEYEXejrVvRWfFjfHdA.ZDoDJVBKKBDmJvkxdtTMDtGOAHmdA.Approximate);
		}
		TmaaYKFIvUeEpgibKnQmmzvJkPjC(P_1, P_3, nwzfRfPOFebEYEXejrVvRWfFjfHdA.ZDoDJVBKKBDmJvkxdtTMDtGOAHmdA.Exact);
		TmaaYKFIvUeEpgibKnQmmzvJkPjC(P_1, P_3, nwzfRfPOFebEYEXejrVvRWfFjfHdA.ZDoDJVBKKBDmJvkxdtTMDtGOAHmdA.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			BVliuJdLfdooYvdWMHmHubexOWi bVliuJdLfdooYvdWMHmHubexOWi = P_3[i];
			if (bVliuJdLfdooYvdWMHmHubexOWi != null && bVliuJdLfdooYvdWMHmHubexOWi.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				bVliuJdLfdooYvdWMHmHubexOWi.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = qDoMDFrIJRnAfqzRzWVsBdHMhOocA(P_3);
				bVliuJdLfdooYvdWMHmHubexOWi.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = cwHFMjKazPFteQPOAosTBljzHGpab();
				izkGtPGrPAImgIEIdpvwtKUEBDJi.sQBDCFGaCAilbJdIsPEtGZxhfXYU(bVliuJdLfdooYvdWMHmHubexOWi);
			}
		}
		P_3.Sort(BVliuJdLfdooYvdWMHmHubexOWi.zGceiCQprwrDlcHDgFnTFAECSLcD);
	}

	private void oVMTwBdapjtOnmaQJgebQAJyHNbDA(List<BVliuJdLfdooYvdWMHmHubexOWi> P_0, int P_1, int P_2)
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

	private bool kJymBaYbwCMFNksExLPcjlYUOuDp(List<BVliuJdLfdooYvdWMHmHubexOWi> P_0, int P_1)
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

	private int qDoMDFrIJRnAfqzRzWVsBdHMhOocA(List<BVliuJdLfdooYvdWMHmHubexOWi> P_0)
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

	private bool fAdiQlXhqvNXDuZKMxWMYIFkDNfh(List<BVliuJdLfdooYvdWMHmHubexOWi> P_0, int P_1)
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

	private void oxSFTHNRDVafDNTnsdlmifXijsHs(int P_0, List<BVliuJdLfdooYvdWMHmHubexOWi> P_1, int P_2, List<BVliuJdLfdooYvdWMHmHubexOWi> P_3, nwzfRfPOFebEYEXejrVvRWfFjfHdA.ZDoDJVBKKBDmJvkxdtTMDtGOAHmdA P_4)
	{
		int num = ((P_4 != nwzfRfPOFebEYEXejrVvRWfFjfHdA.ZDoDJVBKKBDmJvkxdtTMDtGOAHmdA.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			BVliuJdLfdooYvdWMHmHubexOWi bVliuJdLfdooYvdWMHmHubexOWi = P_1[i];
			if (bVliuJdLfdooYvdWMHmHubexOWi == null || bVliuJdLfdooYvdWMHmHubexOWi.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				BVliuJdLfdooYvdWMHmHubexOWi bVliuJdLfdooYvdWMHmHubexOWi2 = P_3[j];
				if (bVliuJdLfdooYvdWMHmHubexOWi2 != null && !fAdiQlXhqvNXDuZKMxWMYIFkDNfh(P_1, bVliuJdLfdooYvdWMHmHubexOWi2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && bVliuJdLfdooYvdWMHmHubexOWi.vWWBqOFPbjsiAPnvYVyPmRBLQItSA(bVliuJdLfdooYvdWMHmHubexOWi2) >= num)
				{
					bVliuJdLfdooYvdWMHmHubexOWi.jmbcAGyeGluOuJTRrupriLjCDKyaA(bVliuJdLfdooYvdWMHmHubexOWi2);
					izkGtPGrPAImgIEIdpvwtKUEBDJi.sQBDCFGaCAilbJdIsPEtGZxhfXYU(bVliuJdLfdooYvdWMHmHubexOWi);
				}
			}
		}
	}

	private void TmaaYKFIvUeEpgibKnQmmzvJkPjC(int P_0, List<BVliuJdLfdooYvdWMHmHubexOWi> P_1, nwzfRfPOFebEYEXejrVvRWfFjfHdA.ZDoDJVBKKBDmJvkxdtTMDtGOAHmdA P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			BVliuJdLfdooYvdWMHmHubexOWi bVliuJdLfdooYvdWMHmHubexOWi = P_1[i];
			if (bVliuJdLfdooYvdWMHmHubexOWi == null || bVliuJdLfdooYvdWMHmHubexOWi.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			nwzfRfPOFebEYEXejrVvRWfFjfHdA.vAGEyaEheFNNiXpMETnxXWPXLcbX vAGEyaEheFNNiXpMETnxXWPXLcbX = null;
			foreach (nwzfRfPOFebEYEXejrVvRWfFjfHdA.vAGEyaEheFNNiXpMETnxXWPXLcbX item in izkGtPGrPAImgIEIdpvwtKUEBDJi.xVjJfezQvCvJFLGYYEDsKbLkBQnd(bVliuJdLfdooYvdWMHmHubexOWi, P_2))
			{
				if (!fAdiQlXhqvNXDuZKMxWMYIFkDNfh(P_1, item.mWxCDZcUevEdKEwFKwWOTLidTull) && item.sNXmHgItwowJPYHUsANFxRJpYOUb >= 0)
				{
					vAGEyaEheFNNiXpMETnxXWPXLcbX = item;
					break;
				}
			}
			if (vAGEyaEheFNNiXpMETnxXWPXLcbX != null)
			{
				int num = vAGEyaEheFNNiXpMETnxXWPXLcbX.sNXmHgItwowJPYHUsANFxRJpYOUb;
				if (!kJymBaYbwCMFNksExLPcjlYUOuDp(P_1, num))
				{
					num = (vAGEyaEheFNNiXpMETnxXWPXLcbX.sNXmHgItwowJPYHUsANFxRJpYOUb = qDoMDFrIJRnAfqzRzWVsBdHMhOocA(P_1));
				}
				bVliuJdLfdooYvdWMHmHubexOWi.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				bVliuJdLfdooYvdWMHmHubexOWi.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = vAGEyaEheFNNiXpMETnxXWPXLcbX.mWxCDZcUevEdKEwFKwWOTLidTull;
				izkGtPGrPAImgIEIdpvwtKUEBDJi.sQBDCFGaCAilbJdIsPEtGZxhfXYU(bVliuJdLfdooYvdWMHmHubexOWi);
			}
		}
	}

	private void zDfXBOPMMReIfbheuztdULyHoTUIA()
	{
		zvtqPbhsiGyoruxKupwbkoKemczC.buaArESrHYuVyvPGpGrGBtjGigOOA();
		IList<GYSwgkbaVYVjtqJQdbyLjufrdwPAA> list = wFkBazHYqgwQuiJFtkAeROYMlqdFb();
		if (dIQdiYCTeWCLZTserezeAlJlWneLA(list))
		{
			gvYKLQosISdaluPzjtIsehIiABKo(list);
		}
		fRGguVdXHzRjPtXINOUhHPbLAPog = false;
	}

	private bool dIQdiYCTeWCLZTserezeAlJlWneLA(IList<GYSwgkbaVYVjtqJQdbyLjufrdwPAA> P_0)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && !cgPPmrwvRlLuQsUFBNcZcgMNZkDv(P_0[i].UczRmMphKIjxibxeycGOHPLgBLhWB))
			{
				return true;
			}
		}
		int count2 = yLMNpTDNZEuLYUjzneyUGOqrqawpA.Count;
		for (int j = 0; j < count2; j++)
		{
			if (yLMNpTDNZEuLYUjzneyUGOqrqawpA[j] != null && !CzRRJAPkmDiYZCScUFyUfZinLBlrA(P_0, yLMNpTDNZEuLYUjzneyUGOqrqawpA[j].FpmcirpiXejnlFAoZivEeqcHbefdA))
			{
				return true;
			}
		}
		return false;
	}

	private bool cgPPmrwvRlLuQsUFBNcZcgMNZkDv(Guid P_0)
	{
		int count = yLMNpTDNZEuLYUjzneyUGOqrqawpA.Count;
		for (int i = 0; i < count; i++)
		{
			if (yLMNpTDNZEuLYUjzneyUGOqrqawpA[i] != null && yLMNpTDNZEuLYUjzneyUGOqrqawpA[i].FpmcirpiXejnlFAoZivEeqcHbefdA == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool CzRRJAPkmDiYZCScUFyUfZinLBlrA(IList<GYSwgkbaVYVjtqJQdbyLjufrdwPAA> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].UczRmMphKIjxibxeycGOHPLgBLhWB == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void AygRHVjjtiOyVKgJXIhsvNqrGGEc(List<BVliuJdLfdooYvdWMHmHubexOWi> P_0, List<BVliuJdLfdooYvdWMHmHubexOWi> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			BVliuJdLfdooYvdWMHmHubexOWi bVliuJdLfdooYvdWMHmHubexOWi = P_0[i];
			if (bVliuJdLfdooYvdWMHmHubexOWi == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					BVliuJdLfdooYvdWMHmHubexOWi bVliuJdLfdooYvdWMHmHubexOWi2 = P_1[j];
					if (bVliuJdLfdooYvdWMHmHubexOWi2 != null && bVliuJdLfdooYvdWMHmHubexOWi.FpmcirpiXejnlFAoZivEeqcHbefdA == bVliuJdLfdooYvdWMHmHubexOWi2.FpmcirpiXejnlFAoZivEeqcHbefdA)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				LuKgjcbkjUUEmbiwALYPNUkspwmoA(P_0[i], P_2);
			}
		}
	}

	private void LuKgjcbkjUUEmbiwALYPNUkspwmoA(BVliuJdLfdooYvdWMHmHubexOWi P_0, bool P_1)
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
}
