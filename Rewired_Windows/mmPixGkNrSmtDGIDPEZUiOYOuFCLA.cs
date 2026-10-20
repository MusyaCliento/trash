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
using Rewired.InputSources.SDL;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal abstract class mmPixGkNrSmtDGIDPEZUiOYOuFCLA : PlatformInputManager
{
	private class mCsctSLCnXZKhIoDZOaHDHKsdCoL : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private class wNLEsxGzCAVEkWfsOmGxierlOSKvA
		{
			private class dhsglJjZemgaDPLSlFEIGreJnYSYB
			{
				private string[] hmnxRXNLFXLzvLMBvgPRhXkNFlbs;

				public dhsglJjZemgaDPLSlFEIGreJnYSYB(params string[] P_0)
				{
					hmnxRXNLFXLzvLMBvgPRhXkNFlbs = P_0;
				}

				public bool ljoWoMUwFdolkHahGEKqJweKYvSA(string P_0)
				{
					if (string.IsNullOrEmpty(P_0))
					{
						return true;
					}
					P_0 = P_0.ToLower();
					for (int i = 0; i < hmnxRXNLFXLzvLMBvgPRhXkNFlbs.Length; i++)
					{
						if (Regex.IsMatch(P_0, hmnxRXNLFXLzvLMBvgPRhXkNFlbs[i]))
						{
							return true;
						}
					}
					return false;
				}
			}

			private static wNLEsxGzCAVEkWfsOmGxierlOSKvA RzAIcrKcPdGkawBBicUoxYHfbIeQ;

			private ADictionary<Guid, dhsglJjZemgaDPLSlFEIGreJnYSYB> OCozKcfGDKtZbOXnBrvbOpQGqfRd;

			public static wNLEsxGzCAVEkWfsOmGxierlOSKvA XmjYGVeRXomwisyJaBXyEALpNjwQ => RzAIcrKcPdGkawBBicUoxYHfbIeQ ?? (RzAIcrKcPdGkawBBicUoxYHfbIeQ = new wNLEsxGzCAVEkWfsOmGxierlOSKvA());

			private wNLEsxGzCAVEkWfsOmGxierlOSKvA()
			{
				OCozKcfGDKtZbOXnBrvbOpQGqfRd = new ADictionary<Guid, dhsglJjZemgaDPLSlFEIGreJnYSYB>
				{
					{
						Consts.joystickGuid_SonyDualShock2,
						new dhsglJjZemgaDPLSlFEIGreJnYSYB("ps2 controller", ".*dualshock[® ]*2.*")
					},
					{
						Consts.joystickGuid_SonyDualShock3,
						new dhsglJjZemgaDPLSlFEIGreJnYSYB("ps3 controller", ".*dualshock[® ]*3.*")
					},
					{
						Consts.joystickGuid_SonyDualShock4,
						new dhsglJjZemgaDPLSlFEIGreJnYSYB("ps4 controller", ".*dualshock[® ]*4.*", "wireless controller")
					},
					{
						Consts.joystickGuid_SonyDualSense,
						new dhsglJjZemgaDPLSlFEIGreJnYSYB("ps5 controller", ".*dual[ ]*sense*")
					},
					{
						Consts.joystickGuid_Xbox360Controller,
						new dhsglJjZemgaDPLSlFEIGreJnYSYB("xbox 360 controller")
					},
					{
						Consts.joystickGuid_XboxOneController,
						new dhsglJjZemgaDPLSlFEIGreJnYSYB("xbox controller", "xbox one controller", "xbox series controller", "xbox series x controller")
					},
					{
						Consts.joystickGuid_NintendoSwitchProController,
						new dhsglJjZemgaDPLSlFEIGreJnYSYB("nintendo switch pro controller", "nintendo switch controller")
					},
					{
						Consts.joystickGuid_NintendoSwitch2ProController,
						new dhsglJjZemgaDPLSlFEIGreJnYSYB("nintendo switch 2 pro controller")
					},
					{
						Consts.joystickGuid_NintendoSwitchJoyConL,
						new dhsglJjZemgaDPLSlFEIGreJnYSYB(".*joy-con \\(l\\)", ".*left joy-con")
					},
					{
						Consts.joystickGuid_NintendoSwitchJoyConR,
						new dhsglJjZemgaDPLSlFEIGreJnYSYB(".*joy-con \\(r\\)", ".*right joy-con")
					},
					{
						Consts.joystickGuid_NintendoSwitchJoyConDual,
						new dhsglJjZemgaDPLSlFEIGreJnYSYB(".*joy-con \\(l/r\\)", ".*combined joy-cons")
					}
				};
			}

			public bool EBSWQgLGENCLpMTrZgXfcNKotgWIA(Guid P_0, string P_1)
			{
				if (!OCozKcfGDKtZbOXnBrvbOpQGqfRd.TryGetValue(P_0, out var value))
				{
					return false;
				}
				return value.ljoWoMUwFdolkHahGEKqJweKYvSA(P_1);
			}
		}

		public readonly InputSource DPMfoPclzmTkfdLdzTMfffxmcfNqA;

		private int uTXeqceegAszZNvhFXIkAQgEDssA;

		private int KKrDqSPVUzgMcuzMJeenbpIUAOKbA;

		private Guid UxyxaBJfYYSfbEReWVyoFDhmxZmd;

		private string UvZAWGWAeiTPlEyDISvqovuNfmGo;

		public readonly YUhbQhiLFKRAUFwRWqBNoTItxqmB ojbnSvfVZePeVgfClgTHkaCaQumP;

		public readonly SDLDeviceType IQfImqsIOAbNcuaAQqHtapYOuNj;

		public readonly string dTBdfwIOQulFopOoaXPUPQGBrdzFA;

		public readonly string vpcROcymxOZVXQTwGNhrFShnBoCL;

		public readonly int khKdNzbKECQwIazvbCjQDxGEfipmA;

		public readonly int DDkHnJgEuvvfdlotQDjsgllGsRTkb;

		public readonly Guid cgsLplvGJqOXrgiUuOsdWMGZzVxg;

		public readonly Guid XgjPBQjBsFxZhFEpyHTajsILJHJFb;

		public readonly PidVid dKRBwLPOzOkKiaqLMLHeuBkoIKWAA;

		private Guid whfGDRBZZICsvDPxJeyaULHJKBZD;

		public readonly int WuBKivBoNEHKfZlYIjAhIanifjmm;

		private int eHyTgaCPbbCkuJPiamHLxZdeVDQVA;

		private int apPtZdfCmnItPAZuannwVaBEmRrt;

		public readonly int NhtWkFDuBlFaqypjpGVdSvIsjeQEA;

		public readonly int hfXANhkMAsVCZnIytFgeCKHvSlIN;

		public readonly int EHkDuXRXKIajIfuPWUrwjaayjBSIA;

		public readonly int aroZejvKiaBjuTCfmrbVsLSNRLNo;

		public readonly int CEAGLsTVDydhRtEwYiULWuWFPgEm;

		public readonly int tWeFAhiehQIejGrkaKbsAlIAXDfhB;

		public readonly bool lYaaOseSbcosbSOwPzlNpXEwJAoc;

		public readonly bool TFoFlDEnPraJSVIaednwSXrHnnzoA;

		public readonly int xYuuNeuGJtKdAqBvZKpFJJYrZbYW;

		private float[] ZgLwPPgKRobnLlAZmxdkKlUoNbPB;

		private bool[] aDkCgKToQdtqbTTdqhhSjFyjndsV;

		private HardwareJoystickMap_InputManager vlvljYXTglljaKuxgtnSXyPycrOg;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> gWhtYJQtPsVBxndNNIqeJZsQeSKy;

		private bool VrYXxavBMsNhSNRyEnfyWJtUqXdi;

		private bool SJkkxvijSKhPSddVgAeiWfuIzhLG;

		[CompilerGenerated]
		private Controller.Extension lDUfqMKIGpDtllRwilmqicfYClNV;

		public Guid kTaukStHAvHcyecvotnqENJrtydf => UxyxaBJfYYSfbEReWVyoFDhmxZmd;

		public string tGsaQNgVNBAPbCAOPJlJFORWcLbZ => UvZAWGWAeiTPlEyDISvqovuNfmGo;

		public Guid khYoouxFxoNXqTTJsYgbtEdjAQdQ => whfGDRBZZICsvDPxJeyaULHJKBZD;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return uTXeqceegAszZNvhFXIkAQgEDssA;
			}
			set
			{
				uTXeqceegAszZNvhFXIkAQgEDssA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return KKrDqSPVUzgMcuzMJeenbpIUAOKbA;
			}
			set
			{
				KKrDqSPVUzgMcuzMJeenbpIUAOKbA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name => UvZAWGWAeiTPlEyDISvqovuNfmGo;

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (KKrDqSPVUzgMcuzMJeenbpIUAOKbA < 0)
				{
					return null;
				}
				return KKrDqSPVUzgMcuzMJeenbpIUAOKbA;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => cgsLplvGJqOXrgiUuOsdWMGZzVxg;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => XgjPBQjBsFxZhFEpyHTajsILJHJFb;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension
		{
			[CompilerGenerated]
			get
			{
				return lDUfqMKIGpDtllRwilmqicfYClNV;
			}
			[CompilerGenerated]
			set
			{
				lDUfqMKIGpDtllRwilmqicfYClNV = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			ojbnSvfVZePeVgfClgTHkaCaQumP.XODLAQcDSeqnqYXPpFHPxhievRiB(motorIndex, amount, false);
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			ojbnSvfVZePeVgfClgTHkaCaQumP.zJNwGHMSLyPHPkNrKtBMXPnNZqat();
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public mCsctSLCnXZKhIoDZOaHDHKsdCoL(InputSource P_0, YUhbQhiLFKRAUFwRWqBNoTItxqmB P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2)
		{
			DPMfoPclzmTkfdLdzTMfffxmcfNqA = P_0;
			ojbnSvfVZePeVgfClgTHkaCaQumP = P_1;
			cgsLplvGJqOXrgiUuOsdWMGZzVxg = P_1.yhicbDjyGKhUgYmbAOJdueUvjYqM;
			XgjPBQjBsFxZhFEpyHTajsILJHJFb = P_1.gUpPbnUasTsiRKgUmHIVAiMpiBmy;
			dTBdfwIOQulFopOoaXPUPQGBrdzFA = P_1.daoSvnTfYTUAaCJXGklyVPSSbAmL;
			vpcROcymxOZVXQTwGNhrFShnBoCL = P_1.BPAxDChUYBXKQedgnnuPMNjGlXOG;
			dKRBwLPOzOkKiaqLMLHeuBkoIKWAA = P_1.qtaMmMJdCHVLpnFhWSJFQyJUgzlq;
			khKdNzbKECQwIazvbCjQDxGEfipmA = P_1.OVQKsdpbdMzmshGknASsTZkRsrRK;
			DDkHnJgEuvvfdlotQDjsgllGsRTkb = P_1.BhxIldEqUyqbetLRaeOhGmTOJbLJA;
			IQfImqsIOAbNcuaAQqHtapYOuNj = P_1.ItnCYRLJnKBmnpgFmcQWidYUVwVk;
			WuBKivBoNEHKfZlYIjAhIanifjmm = P_1.DPNRMiWFaBVRBukAOePqPzTkdmkf;
			aroZejvKiaBjuTCfmrbVsLSNRLNo = P_1.AcyBhZIsGMjxlZeMJKbUKUVxrNLkA;
			CEAGLsTVDydhRtEwYiULWuWFPgEm = P_1.SRVuCLhCpZdMYEgpAkVXiLKJPlHwA;
			tWeFAhiehQIejGrkaKbsAlIAXDfhB = P_1.gBQAhHZqEhmzzZdatQzUBwwjxfQG;
			NhtWkFDuBlFaqypjpGVdSvIsjeQEA = P_1.VCSrMqGhkXwhyzceIIHOMztZZsld;
			hfXANhkMAsVCZnIytFgeCKHvSlIN = P_1.yFvlsWgHwliaKHPFCBOqdDAmQWIZ;
			EHkDuXRXKIajIfuPWUrwjaayjBSIA = P_1.SlETggxFmtZKNrhpkGUsIavgapwu;
			lYaaOseSbcosbSOwPzlNpXEwJAoc = P_1.dexsMRpLwKOUSoLocjETHHnwoAZBA;
			TFoFlDEnPraJSVIaednwSXrHnnzoA = P_1.fwVIWEXEfTLBgbnhxdSbgKyNtLMIA;
			xYuuNeuGJtKdAqBvZKpFJJYrZbYW = P_1.NTqOpHFbvHuyLbLaEdmbjLPuKsdI;
			Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension = P_1.flgGTUACKfEinCMqZxZeKpBriOgAb;
			gWhtYJQtPsVBxndNNIqeJZsQeSKy = P_2;
			KKrDqSPVUzgMcuzMJeenbpIUAOKbA = -1;
			uTXeqceegAszZNvhFXIkAQgEDssA = -1;
		}

		public void tojanAEmPakVkyMNNlOlcvkvAAeRA()
		{
			whfGDRBZZICsvDPxJeyaULHJKBZD = MiscTools.CreateGuidHashSHA1(dTBdfwIOQulFopOoaXPUPQGBrdzFA + dKRBwLPOzOkKiaqLMLHeuBkoIKWAA.ToProductGuid().ToString());
			eHyTgaCPbbCkuJPiamHLxZdeVDQVA = NhtWkFDuBlFaqypjpGVdSvIsjeQEA;
			apPtZdfCmnItPAZuannwVaBEmRrt = hfXANhkMAsVCZnIytFgeCKHvSlIN + EHkDuXRXKIajIfuPWUrwjaayjBSIA * 8;
			tQyHdWmCmBfokCapwPhkmzItexbu();
			UxyxaBJfYYSfbEReWVyoFDhmxZmd = vlvljYXTglljaKuxgtnSXyPycrOg.hardwareMapIdentifier.guid;
			UvZAWGWAeiTPlEyDISvqovuNfmGo = vlvljYXTglljaKuxgtnSXyPycrOg.controllerName;
			VrYXxavBMsNhSNRyEnfyWJtUqXdi = kTaukStHAvHcyecvotnqENJrtydf == Guid.Empty;
			ZgLwPPgKRobnLlAZmxdkKlUoNbPB = new float[eHyTgaCPbbCkuJPiamHLxZdeVDQVA];
			aDkCgKToQdtqbTTdqhhSjFyjndsV = new bool[apPtZdfCmnItPAZuannwVaBEmRrt];
			Update();
		}

		public void xsHIYqVsjeEFvOgCmWTXbDeAqQwg(mCsctSLCnXZKhIoDZOaHDHKsdCoL P_0)
		{
			if (P_0 != null)
			{
				KKrDqSPVUzgMcuzMJeenbpIUAOKbA = P_0.KKrDqSPVUzgMcuzMJeenbpIUAOKbA;
				uTXeqceegAszZNvhFXIkAQgEDssA = P_0.uTXeqceegAszZNvhFXIkAQgEDssA;
				for (int i = 0; i < MathTools.Min(aDkCgKToQdtqbTTdqhhSjFyjndsV.Length, P_0.aDkCgKToQdtqbTTdqhhSjFyjndsV.Length); i++)
				{
					aDkCgKToQdtqbTTdqhhSjFyjndsV[i] = P_0.aDkCgKToQdtqbTTdqhhSjFyjndsV[i];
				}
				for (int j = 0; j < MathTools.Min(ZgLwPPgKRobnLlAZmxdkKlUoNbPB.Length, P_0.ZgLwPPgKRobnLlAZmxdkKlUoNbPB.Length); j++)
				{
					ZgLwPPgKRobnLlAZmxdkKlUoNbPB[j] = P_0.ZgLwPPgKRobnLlAZmxdkKlUoNbPB[j];
				}
				SJkkxvijSKhPSddVgAeiWfuIzhLG = P_0.SJkkxvijSKhPSddVgAeiWfuIzhLG;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			arIudxJZDyjHkocXJhwFgEgaYqxk();
			yGuEOoBTtkxNqrVLbixFBBbGtSFxb();
			if (!SJkkxvijSKhPSddVgAeiWfuIzhLG && ojbnSvfVZePeVgfClgTHkaCaQumP.PGmCjwePvzGkYdUmefDbkSXMIPtW)
			{
				SJkkxvijSKhPSddVgAeiWfuIzhLG = true;
			}
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (eHyTgaCPbbCkuJPiamHLxZdeVDQVA != dataUpdater.axisCount || apPtZdfCmnItPAZuannwVaBEmRrt != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < eHyTgaCPbbCkuJPiamHLxZdeVDQVA; i++)
			{
				dataUpdater.axisValues[i] = ZgLwPPgKRobnLlAZmxdkKlUoNbPB[i];
			}
			for (int j = 0; j < apPtZdfCmnItPAZuannwVaBEmRrt; j++)
			{
				dataUpdater.buttonValues[j] = aDkCgKToQdtqbTTdqhhSjFyjndsV[j];
			}
			if (SJkkxvijSKhPSddVgAeiWfuIzhLG && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int eVTVtAKEmOnmjuTdLwnlxMkdYFlA(mCsctSLCnXZKhIoDZOaHDHKsdCoL P_0)
		{
			if (P_0.uTXeqceegAszZNvhFXIkAQgEDssA == uTXeqceegAszZNvhFXIkAQgEDssA)
			{
				return 2;
			}
			if (aroZejvKiaBjuTCfmrbVsLSNRLNo != P_0.aroZejvKiaBjuTCfmrbVsLSNRLNo)
			{
				return 0;
			}
			if (CEAGLsTVDydhRtEwYiULWuWFPgEm != P_0.CEAGLsTVDydhRtEwYiULWuWFPgEm)
			{
				return 0;
			}
			if (tWeFAhiehQIejGrkaKbsAlIAXDfhB != P_0.tWeFAhiehQIejGrkaKbsAlIAXDfhB)
			{
				return 0;
			}
			if (P_0.cgsLplvGJqOXrgiUuOsdWMGZzVxg == cgsLplvGJqOXrgiUuOsdWMGZzVxg)
			{
				return 2;
			}
			if (P_0.khYoouxFxoNXqTTJsYgbtEdjAQdQ == khYoouxFxoNXqTTJsYgbtEdjAQdQ)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo AlhAqGfNcuxoQmsXyFBMtgOqoYVr()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			mJcSPfDBrGhxAEiKZlagejEseqwP(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			fTbyFTyZayBNQeTYvYfzAkxyAqLE(bridgedController);
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
			return new ControllerDisconnectedEventArgs(uTXeqceegAszZNvhFXIkAQgEDssA);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void arIudxJZDyjHkocXJhwFgEgaYqxk()
		{
			if (eHyTgaCPbbCkuJPiamHLxZdeVDQVA <= 0 || vlvljYXTglljaKuxgtnSXyPycrOg.map.platform != InputPlatform.SDL)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_SDL_Base)vlvljYXTglljaKuxgtnSXyPycrOg.map).Axes_orig;
			if (axes_orig != null)
			{
				for (int i = 0; i < axes_orig.Length; i++)
				{
					dwdehCYfLLzLRlaFTpCEvTsVzZDJ(axes_orig[i], i);
				}
			}
		}

		private void yGuEOoBTtkxNqrVLbixFBBbGtSFxb()
		{
			if (apPtZdfCmnItPAZuannwVaBEmRrt <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_SDL_Base)vlvljYXTglljaKuxgtnSXyPycrOg.map).Buttons_orig;
			if (buttons_orig != null)
			{
				for (int i = 0; i < buttons_orig.Length; i++)
				{
					MwjpMlshaLNKdPFyhPYnZHQIDlzg(buttons_orig[i], i);
				}
			}
		}

		private void dwdehCYfLLzLRlaFTpCEvTsVzZDJ(HardwareJoystickMap.Platform_SDL_Base.Axis P_0, int P_1)
		{
			if (P_1 >= eHyTgaCPbbCkuJPiamHLxZdeVDQVA)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			ZgLwPPgKRobnLlAZmxdkKlUoNbPB[P_1] = louYSQMLrzZoCZziSLotQKRDTUKh(P_0);
		}

		private void MwjpMlshaLNKdPFyhPYnZHQIDlzg(HardwareJoystickMap.Platform_SDL_Base.Button P_0, int P_1)
		{
			if (P_1 >= apPtZdfCmnItPAZuannwVaBEmRrt)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			aDkCgKToQdtqbTTdqhhSjFyjndsV[P_1] = ArWxzNSuswiVqWIfsqitMhDMOIvO(P_0);
		}

		private float louYSQMLrzZoCZziSLotQKRDTUKh(HardwareJoystickMap.Platform_SDL_Base.Axis P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= NhtWkFDuBlFaqypjpGVdSvIsjeQEA || sourceAxis >= 56)
				{
					return 0f;
				}
				return ojbnSvfVZePeVgfClgTHkaCaQumP.esPPzTqcpnuQWEfhfrMGLsUqEhCh(sourceAxis);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= hfXANhkMAsVCZnIytFgeCKHvSlIN || sourceButton >= 256)
				{
					return 0f;
				}
				if (!ojbnSvfVZePeVgfClgTHkaCaQumP.zHldmjeUCpWmYMLuFdiOabeGgUQDB(sourceButton))
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
				if (sourceHat < 0 || sourceHat >= EHkDuXRXKIajIfuPWUrwjaayjBSIA || sourceHat >= 4)
				{
					return 0f;
				}
				int num = ojbnSvfVZePeVgfClgTHkaCaQumP.ERSfDsbkkVLoiGcHdodUPHGwspFFB(sourceHat);
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = zLuQXobrtVplwzoWeMCvKzWfxnxf(num, AxisDirection.Horizontal);
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
					num2 = zLuQXobrtVplwzoWeMCvKzWfxnxf(num, AxisDirection.Vertical);
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

		private bool ArWxzNSuswiVqWIfsqitMhDMOIvO(HardwareJoystickMap.Platform_SDL_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (ojbnSvfVZePeVgfClgTHkaCaQumP.zHldmjeUCpWmYMLuFdiOabeGgUQDB(P_0.ignoreIfButtonsActiveButtons[i]))
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
						if (!ojbnSvfVZePeVgfClgTHkaCaQumP.zHldmjeUCpWmYMLuFdiOabeGgUQDB(P_0.requiredButtons[j]))
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
				if (sourceButton < 0 || sourceButton >= hfXANhkMAsVCZnIytFgeCKHvSlIN || sourceButton >= 256)
				{
					return false;
				}
				return ojbnSvfVZePeVgfClgTHkaCaQumP.zHldmjeUCpWmYMLuFdiOabeGgUQDB(sourceButton);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis <= 0 || sourceAxis >= NhtWkFDuBlFaqypjpGVdSvIsjeQEA || sourceAxis >= 56)
				{
					return false;
				}
				float num = ojbnSvfVZePeVgfClgTHkaCaQumP.esPPzTqcpnuQWEfhfrMGLsUqEhCh(sourceAxis);
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
				if (sourceHat < 0 || sourceHat >= EHkDuXRXKIajIfuPWUrwjaayjBSIA || sourceHat >= 4)
				{
					return false;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return zDDkMYivKbxIuWmhbpkSjcXGXkUB(ojbnSvfVZePeVgfClgTHkaCaQumP.ERSfDsbkkVLoiGcHdodUPHGwspFFB(sourceHat), 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return zDDkMYivKbxIuWmhbpkSjcXGXkUB(ojbnSvfVZePeVgfClgTHkaCaQumP.ERSfDsbkkVLoiGcHdodUPHGwspFFB(sourceHat), 1, P_0.sourceHatType);
				case HatDirection.Right:
					return zDDkMYivKbxIuWmhbpkSjcXGXkUB(ojbnSvfVZePeVgfClgTHkaCaQumP.ERSfDsbkkVLoiGcHdodUPHGwspFFB(sourceHat), 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return zDDkMYivKbxIuWmhbpkSjcXGXkUB(ojbnSvfVZePeVgfClgTHkaCaQumP.ERSfDsbkkVLoiGcHdodUPHGwspFFB(sourceHat), 3, P_0.sourceHatType);
				case HatDirection.Down:
					return zDDkMYivKbxIuWmhbpkSjcXGXkUB(ojbnSvfVZePeVgfClgTHkaCaQumP.ERSfDsbkkVLoiGcHdodUPHGwspFFB(sourceHat), 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return zDDkMYivKbxIuWmhbpkSjcXGXkUB(ojbnSvfVZePeVgfClgTHkaCaQumP.ERSfDsbkkVLoiGcHdodUPHGwspFFB(sourceHat), 5, P_0.sourceHatType);
				case HatDirection.Left:
					return zDDkMYivKbxIuWmhbpkSjcXGXkUB(ojbnSvfVZePeVgfClgTHkaCaQumP.ERSfDsbkkVLoiGcHdodUPHGwspFFB(sourceHat), 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return zDDkMYivKbxIuWmhbpkSjcXGXkUB(ojbnSvfVZePeVgfClgTHkaCaQumP.ERSfDsbkkVLoiGcHdodUPHGwspFFB(sourceHat), 7, P_0.sourceHatType);
				}
			}
			return false;
		}

		private bool zDDkMYivKbxIuWmhbpkSjcXGXkUB(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (vlvljYXTglljaKuxgtnSXyPycrOg.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
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

		private float zLuQXobrtVplwzoWeMCvKzWfxnxf(int P_0, AxisDirection P_1)
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

		private ControlDeviceType VqutjntGdCToLtZJsDfPRZGTiswg(SDLDeviceType P_0)
		{
			return P_0 switch
			{
				SDLDeviceType.Joystick => ControlDeviceType.Joystick, 
				SDLDeviceType.Gamepad => ControlDeviceType.Gamepad, 
				SDLDeviceType.Keyboard => ControlDeviceType.Keyboard, 
				SDLDeviceType.Mouse => ControlDeviceType.Mouse, 
				_ => ControlDeviceType.Unknown, 
			};
		}

		private void tQyHdWmCmBfokCapwPhkmzItexbu()
		{
			vlvljYXTglljaKuxgtnSXyPycrOg = gWhtYJQtPsVBxndNNIqeJZsQeSKy(AlhAqGfNcuxoQmsXyFBMtgOqoYVr());
			if (vlvljYXTglljaKuxgtnSXyPycrOg == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			if (vlvljYXTglljaKuxgtnSXyPycrOg.useSystemName || vlvljYXTglljaKuxgtnSXyPycrOg.hardwareMapIdentifier.guid == Consts.joystickGuid_standardizedGamepad)
			{
				string text = wTsfJsmOlHBFsbGpBBMLdjBHbXdsB();
				if (!string.IsNullOrEmpty(text))
				{
					text = Regex.Replace(text, "\\s+", " ");
					text = text.Trim();
					if (!string.IsNullOrEmpty(text))
					{
						vlvljYXTglljaKuxgtnSXyPycrOg.controllerName = text;
					}
				}
				if (vlvljYXTglljaKuxgtnSXyPycrOg.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(vlvljYXTglljaKuxgtnSXyPycrOg.deviceLocalizationInfo.parentKeys[0]))
				{
					string a = vlvljYXTglljaKuxgtnSXyPycrOg.deviceLocalizationInfo.parentKeys[0];
					string text2 = string.Format("{0}:{1}", ojbnSvfVZePeVgfClgTHkaCaQumP.qtaMmMJdCHVLpnFhWSJFQyJUgzlq.vendorId.ToString("x4"), ojbnSvfVZePeVgfClgTHkaCaQumP.qtaMmMJdCHVLpnFhWSJFQyJUgzlq.productId.ToString("x4"));
					vlvljYXTglljaKuxgtnSXyPycrOg.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(a, text2));
					if (!string.IsNullOrEmpty(ojbnSvfVZePeVgfClgTHkaCaQumP.daoSvnTfYTUAaCJXGklyVPSSbAmL))
					{
						vlvljYXTglljaKuxgtnSXyPycrOg.deviceLocalizationInfo.InsertParentKey(1, LocalizationManager.AppendToKeyAsPath(a, ojbnSvfVZePeVgfClgTHkaCaQumP.daoSvnTfYTUAaCJXGklyVPSSbAmL));
					}
					if (!string.IsNullOrEmpty(ojbnSvfVZePeVgfClgTHkaCaQumP.daoSvnTfYTUAaCJXGklyVPSSbAmL))
					{
						vlvljYXTglljaKuxgtnSXyPycrOg.deviceLocalizationInfo.additionalIdentifyingInformation = $"{ojbnSvfVZePeVgfClgTHkaCaQumP.daoSvnTfYTUAaCJXGklyVPSSbAmL} [{text2}]";
					}
					else
					{
						vlvljYXTglljaKuxgtnSXyPycrOg.deviceLocalizationInfo.additionalIdentifyingInformation = $"[{text2}]";
					}
				}
			}
			else if (vlvljYXTglljaKuxgtnSXyPycrOg.hardwareMapIdentifier.guid == Guid.Empty || !wNLEsxGzCAVEkWfsOmGxierlOSKvA.XmjYGVeRXomwisyJaBXyEALpNjwQ.EBSWQgLGENCLpMTrZgXfcNKotgWIA(vlvljYXTglljaKuxgtnSXyPycrOg.hardwareMapIdentifier.guid, wTsfJsmOlHBFsbGpBBMLdjBHbXdsB()))
			{
				string text3 = wTsfJsmOlHBFsbGpBBMLdjBHbXdsB();
				if (!string.IsNullOrEmpty(text3))
				{
					text3 = Regex.Replace(text3, "\\s+", " ");
					text3 = text3.Trim();
					if (!string.IsNullOrEmpty(text3))
					{
						vlvljYXTglljaKuxgtnSXyPycrOg.controllerName = text3;
					}
				}
			}
			eHyTgaCPbbCkuJPiamHLxZdeVDQVA = vlvljYXTglljaKuxgtnSXyPycrOg.axisCount;
			apPtZdfCmnItPAZuannwVaBEmRrt = vlvljYXTglljaKuxgtnSXyPycrOg.buttonCount;
		}

		private string wTsfJsmOlHBFsbGpBBMLdjBHbXdsB()
		{
			if (string.IsNullOrEmpty(vpcROcymxOZVXQTwGNhrFShnBoCL))
			{
				if (string.IsNullOrEmpty(dTBdfwIOQulFopOoaXPUPQGBrdzFA))
				{
					return null;
				}
				return dTBdfwIOQulFopOoaXPUPQGBrdzFA;
			}
			return vpcROcymxOZVXQTwGNhrFShnBoCL;
		}

		private string adkLKvoLPajEaZHouUcqrseyCjnb()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ojbnSvfVZePeVgfClgTHkaCaQumP.InputSource}{dTBdfwIOQulFopOoaXPUPQGBrdzFA}{khKdNzbKECQwIazvbCjQDxGEfipmA}{dKRBwLPOzOkKiaqLMLHeuBkoIKWAA.ToProductGuid()}");
		}

		private void mJcSPfDBrGhxAEiKZlagejEseqwP(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = DPMfoPclzmTkfdLdzTMfffxmcfNqA;
			P_0.inputSource = ojbnSvfVZePeVgfClgTHkaCaQumP.InputSource;
			P_0.deviceType = VqutjntGdCToLtZJsDfPRZGTiswg(IQfImqsIOAbNcuaAQqHtapYOuNj);
			P_0.hardwareIdentifier = adkLKvoLPajEaZHouUcqrseyCjnb();
			P_0.hardwareAxisCount = aroZejvKiaBjuTCfmrbVsLSNRLNo;
			P_0.hardwareButtonCount = CEAGLsTVDydhRtEwYiULWuWFPgEm;
			P_0.hardwareHatCount = tWeFAhiehQIejGrkaKbsAlIAXDfhB;
			P_0.hw_productName = dTBdfwIOQulFopOoaXPUPQGBrdzFA;
			P_0.hw_deviceGuid = cgsLplvGJqOXrgiUuOsdWMGZzVxg;
			P_0.hw_productId = khKdNzbKECQwIazvbCjQDxGEfipmA;
			P_0.hw_pidVid = dKRBwLPOzOkKiaqLMLHeuBkoIKWAA;
			P_0.hw_isBluetoothDevice = lYaaOseSbcosbSOwPzlNpXEwJAoc;
			P_0.hw_bluetoothDeviceName = dTBdfwIOQulFopOoaXPUPQGBrdzFA;
			P_0.hw_systemDeviceName = dTBdfwIOQulFopOoaXPUPQGBrdzFA;
			P_0.hw_supportsVibration = TFoFlDEnPraJSVIaednwSXrHnnzoA;
			P_0.hw_isSDL2Gamepad = ojbnSvfVZePeVgfClgTHkaCaQumP.ItnCYRLJnKBmnpgFmcQWidYUVwVk == SDLDeviceType.Gamepad;
			P_0.hw_localVibrationMotorCount = xYuuNeuGJtKdAqBvZKpFJJYrZbYW;
			P_0.userCustomIdentifier = new HardwareJoystickMap.Platform_SDL_Base.MatchingCriteria.SDLDeviceMatchingProperties
			{
				deviceType = (int)IQfImqsIOAbNcuaAQqHtapYOuNj
			};
		}

		private void fTbyFTyZayBNQeTYvYfzAkxyAqLE(BridgedController P_0)
		{
			mJcSPfDBrGhxAEiKZlagejEseqwP(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = vlvljYXTglljaKuxgtnSXyPycrOg.ToGameHardwareControllerMap();
			P_0.instanceName = dTBdfwIOQulFopOoaXPUPQGBrdzFA;
			P_0.productName = dTBdfwIOQulFopOoaXPUPQGBrdzFA;
			P_0.axisCount = eHyTgaCPbbCkuJPiamHLxZdeVDQVA;
			P_0.buttonCount = apPtZdfCmnItPAZuannwVaBEmRrt;
			P_0.unknownControllerHats = FPCOOEsvMPoPrnuIobLpfzEzPuyW();
			P_0.controllerTypeGuid = kTaukStHAvHcyecvotnqENJrtydf;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		private void xcCeoVgATvWytlEwBPUIbGYiIKRYA()
		{
			for (int i = 0; i < apPtZdfCmnItPAZuannwVaBEmRrt; i++)
			{
				aDkCgKToQdtqbTTdqhhSjFyjndsV[i] = false;
			}
			for (int j = 0; j < eHyTgaCPbbCkuJPiamHLxZdeVDQVA; j++)
			{
				ZgLwPPgKRobnLlAZmxdkKlUoNbPB[j] = 0f;
			}
		}

		private UnknownControllerHat[] FPCOOEsvMPoPrnuIobLpfzEzPuyW()
		{
			if (!VrYXxavBMsNhSNRyEnfyWJtUqXdi)
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

		public static int tTqXQiFJerDINsRpkcDyGBuJFxJsA(mCsctSLCnXZKhIoDZOaHDHKsdCoL P_0, mCsctSLCnXZKhIoDZOaHDHKsdCoL P_1)
		{
			if (P_0.KKrDqSPVUzgMcuzMJeenbpIUAOKbA < P_1.KKrDqSPVUzgMcuzMJeenbpIUAOKbA)
			{
				return -1;
			}
			if (P_0.KKrDqSPVUzgMcuzMJeenbpIUAOKbA > P_1.KKrDqSPVUzgMcuzMJeenbpIUAOKbA)
			{
				return 1;
			}
			return 0;
		}

		public static int CLXUBRLBLgSYjdvXBPUBiCUjtsyx(mCsctSLCnXZKhIoDZOaHDHKsdCoL P_0, mCsctSLCnXZKhIoDZOaHDHKsdCoL P_1)
		{
			if (P_0.WuBKivBoNEHKfZlYIjAhIanifjmm < P_1.WuBKivBoNEHKfZlYIjAhIanifjmm)
			{
				return -1;
			}
			if (P_0.WuBKivBoNEHKfZlYIjAhIanifjmm > P_1.WuBKivBoNEHKfZlYIjAhIanifjmm)
			{
				return 1;
			}
			return 0;
		}
	}

	private class uKYmdwRKKKBnCbSjfVLKvNKjNXTY
	{
		public enum dBwVdbAGbFpwmBsjyDInNSlJNAaR
		{
			Exact = 0,
			Approximate = 1
		}

		public class soFtPSddzwupyTpmYHBwdQTHzFlE
		{
			public int atENQldkRBLXOcNwDBFVUvqwqlrM;

			public Guid AqfCpOcmRbNFkJxLBZlhKRlxcTEWA;

			public Guid XOUedThtaOcVURXdFOjEWNiveypRA;

			public int WzQXNkKMevYJcVTKXcJiYmmePQZu;

			public int JqGwykNwOebtatgsZxeeiBogEUUm;

			public int EUAEubKvXdzyQNLpgIEvHfMLhFQu;

			public int fkXUKXlyaEZrxzzYzIkVOtccadQE;

			public bool lktqkxVntbOOWTSBUWZBEAlrjbEEA(mCsctSLCnXZKhIoDZOaHDHKsdCoL P_0, dBwVdbAGbFpwmBsjyDInNSlJNAaR P_1)
			{
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == atENQldkRBLXOcNwDBFVUvqwqlrM)
				{
					return true;
				}
				if (JqGwykNwOebtatgsZxeeiBogEUUm != P_0.aroZejvKiaBjuTCfmrbVsLSNRLNo)
				{
					return false;
				}
				if (EUAEubKvXdzyQNLpgIEvHfMLhFQu != P_0.CEAGLsTVDydhRtEwYiULWuWFPgEm)
				{
					return false;
				}
				if (fkXUKXlyaEZrxzzYzIkVOtccadQE != P_0.tWeFAhiehQIejGrkaKbsAlIAXDfhB)
				{
					return false;
				}
				return P_1 switch
				{
					dBwVdbAGbFpwmBsjyDInNSlJNAaR.Exact => AqfCpOcmRbNFkJxLBZlhKRlxcTEWA == P_0.XgjPBQjBsFxZhFEpyHTajsILJHJFb, 
					dBwVdbAGbFpwmBsjyDInNSlJNAaR.Approximate => XOUedThtaOcVURXdFOjEWNiveypRA == P_0.khYoouxFxoNXqTTJsYgbtEdjAQdQ, 
					_ => throw new NotImplementedException(), 
				};
			}
		}

		private sealed class ndOfuGcEsfgDLKKCrBzeAGtxrGYCA : IEnumerable<soFtPSddzwupyTpmYHBwdQTHzFlE>, IEnumerable, IEnumerator<soFtPSddzwupyTpmYHBwdQTHzFlE>, IEnumerator, IDisposable
		{
			private int CKRPQOjduPhDKDGSYtEwqXmzJETM;

			private soFtPSddzwupyTpmYHBwdQTHzFlE agUPAiekmunThuzxcwVdUkGUAnJC;

			private int VrTelnrWDafSMIDPHHniqYIROdIs;

			public uKYmdwRKKKBnCbSjfVLKvNKjNXTY kHghYKaKWreiUeGesHbtHHqWomCL;

			private mCsctSLCnXZKhIoDZOaHDHKsdCoL lXgCbDjxsLzbgKFbJRWhFNeGyPJTB;

			public mCsctSLCnXZKhIoDZOaHDHKsdCoL nTZYOjKaJhyaHeUNCeUDWrDCMVwu;

			private dBwVdbAGbFpwmBsjyDInNSlJNAaR voDPNnddokDqPoHGpiRuEiqQNaCGA;

			public dBwVdbAGbFpwmBsjyDInNSlJNAaR QrdxQOHkXTDZHZzMIXIqJBjMwvel;

			private int dnGqWSurxqbdmzQQQTKvrdZMEURhA;

			private int AaVaEIxtwjLAPRDfuBijyPGiFEKZ;

			soFtPSddzwupyTpmYHBwdQTHzFlE IEnumerator<soFtPSddzwupyTpmYHBwdQTHzFlE>.Current
			{
				[DebuggerHidden]
				get
				{
					return agUPAiekmunThuzxcwVdUkGUAnJC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return agUPAiekmunThuzxcwVdUkGUAnJC;
				}
			}

			[DebuggerHidden]
			public ndOfuGcEsfgDLKKCrBzeAGtxrGYCA(int P_0)
			{
				CKRPQOjduPhDKDGSYtEwqXmzJETM = P_0;
				VrTelnrWDafSMIDPHHniqYIROdIs = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				CKRPQOjduPhDKDGSYtEwqXmzJETM = -2;
			}

			private bool MoveNext()
			{
				int cKRPQOjduPhDKDGSYtEwqXmzJETM = CKRPQOjduPhDKDGSYtEwqXmzJETM;
				uKYmdwRKKKBnCbSjfVLKvNKjNXTY uKYmdwRKKKBnCbSjfVLKvNKjNXTY2 = kHghYKaKWreiUeGesHbtHHqWomCL;
				if (cKRPQOjduPhDKDGSYtEwqXmzJETM != 0)
				{
					if (cKRPQOjduPhDKDGSYtEwqXmzJETM != 1)
					{
						return false;
					}
					CKRPQOjduPhDKDGSYtEwqXmzJETM = -1;
					goto IL_0083;
				}
				CKRPQOjduPhDKDGSYtEwqXmzJETM = -1;
				dnGqWSurxqbdmzQQQTKvrdZMEURhA = uKYmdwRKKKBnCbSjfVLKvNKjNXTY2.rehzbHoblOjwuFqeOWUIiDZcGVRpA.Count;
				AaVaEIxtwjLAPRDfuBijyPGiFEKZ = 0;
				goto IL_0093;
				IL_0083:
				AaVaEIxtwjLAPRDfuBijyPGiFEKZ++;
				goto IL_0093;
				IL_0093:
				if (AaVaEIxtwjLAPRDfuBijyPGiFEKZ < dnGqWSurxqbdmzQQQTKvrdZMEURhA)
				{
					if (uKYmdwRKKKBnCbSjfVLKvNKjNXTY2.rehzbHoblOjwuFqeOWUIiDZcGVRpA[AaVaEIxtwjLAPRDfuBijyPGiFEKZ].lktqkxVntbOOWTSBUWZBEAlrjbEEA(lXgCbDjxsLzbgKFbJRWhFNeGyPJTB, voDPNnddokDqPoHGpiRuEiqQNaCGA))
					{
						agUPAiekmunThuzxcwVdUkGUAnJC = uKYmdwRKKKBnCbSjfVLKvNKjNXTY2.rehzbHoblOjwuFqeOWUIiDZcGVRpA[AaVaEIxtwjLAPRDfuBijyPGiFEKZ];
						CKRPQOjduPhDKDGSYtEwqXmzJETM = 1;
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
			IEnumerator<soFtPSddzwupyTpmYHBwdQTHzFlE> IEnumerable<soFtPSddzwupyTpmYHBwdQTHzFlE>.GetEnumerator()
			{
				ndOfuGcEsfgDLKKCrBzeAGtxrGYCA ndOfuGcEsfgDLKKCrBzeAGtxrGYCA2;
				if (CKRPQOjduPhDKDGSYtEwqXmzJETM == -2 && VrTelnrWDafSMIDPHHniqYIROdIs == Environment.CurrentManagedThreadId)
				{
					CKRPQOjduPhDKDGSYtEwqXmzJETM = 0;
					ndOfuGcEsfgDLKKCrBzeAGtxrGYCA2 = this;
				}
				else
				{
					ndOfuGcEsfgDLKKCrBzeAGtxrGYCA2 = new ndOfuGcEsfgDLKKCrBzeAGtxrGYCA(0);
					ndOfuGcEsfgDLKKCrBzeAGtxrGYCA2.kHghYKaKWreiUeGesHbtHHqWomCL = kHghYKaKWreiUeGesHbtHHqWomCL;
				}
				ndOfuGcEsfgDLKKCrBzeAGtxrGYCA2.lXgCbDjxsLzbgKFbJRWhFNeGyPJTB = nTZYOjKaJhyaHeUNCeUDWrDCMVwu;
				ndOfuGcEsfgDLKKCrBzeAGtxrGYCA2.voDPNnddokDqPoHGpiRuEiqQNaCGA = QrdxQOHkXTDZHZzMIXIqJBjMwvel;
				return ndOfuGcEsfgDLKKCrBzeAGtxrGYCA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<soFtPSddzwupyTpmYHBwdQTHzFlE>)this).GetEnumerator();
			}
		}

		private List<soFtPSddzwupyTpmYHBwdQTHzFlE> rehzbHoblOjwuFqeOWUIiDZcGVRpA;

		public uKYmdwRKKKBnCbSjfVLKvNKjNXTY()
		{
			rehzbHoblOjwuFqeOWUIiDZcGVRpA = new List<soFtPSddzwupyTpmYHBwdQTHzFlE>();
		}

		public void lEpdnuaQSefHQfEKUAlHrzcYEbQcA(mCsctSLCnXZKhIoDZOaHDHKsdCoL P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = rehzbHoblOjwuFqeOWUIiDZcGVRpA.Count;
			for (int i = 0; i < count; i++)
			{
				if (rehzbHoblOjwuFqeOWUIiDZcGVRpA[i].lktqkxVntbOOWTSBUWZBEAlrjbEEA(P_0, dBwVdbAGbFpwmBsjyDInNSlJNAaR.Exact))
				{
					rehzbHoblOjwuFqeOWUIiDZcGVRpA[i].atENQldkRBLXOcNwDBFVUvqwqlrM = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					rehzbHoblOjwuFqeOWUIiDZcGVRpA[i].AqfCpOcmRbNFkJxLBZlhKRlxcTEWA = P_0.XgjPBQjBsFxZhFEpyHTajsILJHJFb;
					rehzbHoblOjwuFqeOWUIiDZcGVRpA[i].XOUedThtaOcVURXdFOjEWNiveypRA = P_0.khYoouxFxoNXqTTJsYgbtEdjAQdQ;
					rehzbHoblOjwuFqeOWUIiDZcGVRpA[i].WzQXNkKMevYJcVTKXcJiYmmePQZu = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					rehzbHoblOjwuFqeOWUIiDZcGVRpA[i].JqGwykNwOebtatgsZxeeiBogEUUm = P_0.aroZejvKiaBjuTCfmrbVsLSNRLNo;
					rehzbHoblOjwuFqeOWUIiDZcGVRpA[i].EUAEubKvXdzyQNLpgIEvHfMLhFQu = P_0.CEAGLsTVDydhRtEwYiULWuWFPgEm;
					rehzbHoblOjwuFqeOWUIiDZcGVRpA[i].fkXUKXlyaEZrxzzYzIkVOtccadQE = P_0.tWeFAhiehQIejGrkaKbsAlIAXDfhB;
					tZWNSsgUvhlNfKaSAVUAkqWkyblu(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.XgjPBQjBsFxZhFEpyHTajsILJHJFb, i);
					return;
				}
			}
			rehzbHoblOjwuFqeOWUIiDZcGVRpA.Add(new soFtPSddzwupyTpmYHBwdQTHzFlE
			{
				atENQldkRBLXOcNwDBFVUvqwqlrM = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				AqfCpOcmRbNFkJxLBZlhKRlxcTEWA = P_0.XgjPBQjBsFxZhFEpyHTajsILJHJFb,
				XOUedThtaOcVURXdFOjEWNiveypRA = P_0.khYoouxFxoNXqTTJsYgbtEdjAQdQ,
				WzQXNkKMevYJcVTKXcJiYmmePQZu = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				JqGwykNwOebtatgsZxeeiBogEUUm = P_0.aroZejvKiaBjuTCfmrbVsLSNRLNo,
				EUAEubKvXdzyQNLpgIEvHfMLhFQu = P_0.CEAGLsTVDydhRtEwYiULWuWFPgEm,
				fkXUKXlyaEZrxzzYzIkVOtccadQE = P_0.tWeFAhiehQIejGrkaKbsAlIAXDfhB
			});
			tZWNSsgUvhlNfKaSAVUAkqWkyblu(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.XgjPBQjBsFxZhFEpyHTajsILJHJFb, rehzbHoblOjwuFqeOWUIiDZcGVRpA.Count - 1);
		}

		public bool ybmBCAcuspGLPhoVKbKokFTvcFJnb(mCsctSLCnXZKhIoDZOaHDHKsdCoL P_0, dBwVdbAGbFpwmBsjyDInNSlJNAaR P_1)
		{
			int count = rehzbHoblOjwuFqeOWUIiDZcGVRpA.Count;
			for (int i = 0; i < count; i++)
			{
				if (rehzbHoblOjwuFqeOWUIiDZcGVRpA[i].lktqkxVntbOOWTSBUWZBEAlrjbEEA(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(ndOfuGcEsfgDLKKCrBzeAGtxrGYCA))]
		public IEnumerable<soFtPSddzwupyTpmYHBwdQTHzFlE> tcjOntdMewfimFMeMmKkfgXHOReBB(mCsctSLCnXZKhIoDZOaHDHKsdCoL P_0, dBwVdbAGbFpwmBsjyDInNSlJNAaR P_1)
		{
			return new ndOfuGcEsfgDLKKCrBzeAGtxrGYCA(-2)
			{
				kHghYKaKWreiUeGesHbtHHqWomCL = this,
				nTZYOjKaJhyaHeUNCeUDWrDCMVwu = P_0,
				QrdxQOHkXTDZHZzMIXIqJBjMwvel = P_1
			};
		}

		private void tZWNSsgUvhlNfKaSAVUAkqWkyblu(int P_0, Guid P_1, int P_2)
		{
			for (int num = rehzbHoblOjwuFqeOWUIiDZcGVRpA.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (rehzbHoblOjwuFqeOWUIiDZcGVRpA[num].atENQldkRBLXOcNwDBFVUvqwqlrM == P_0 || rehzbHoblOjwuFqeOWUIiDZcGVRpA[num].AqfCpOcmRbNFkJxLBZlhKRlxcTEWA == P_1))
				{
					rehzbHoblOjwuFqeOWUIiDZcGVRpA.RemoveAt(num);
				}
			}
		}
	}

	internal const bool PWxHIzkWNnOBVNyaIbGxvyHKFXHg = true;

	private IInputSource RQKUfHlXoTMYbdSCAsFDRIBRZVVn;

	private List<mCsctSLCnXZKhIoDZOaHDHKsdCoL> aDGHdmmtlAOjDwCrTUhDPhTEJVsw;

	private int TQuZrEtvuuFuGwnchIACNSKMPfuh;

	private uKYmdwRKKKBnCbSjfVLKvNKjNXTY UnWhqSBCSADTcDyzSFyDFoJCUAMsA;

	private bool jnMokVOBthXrwwjyrRQMvuYnqPYu;

	private Action<int, ControllerDataUpdater> BxHhmIzNZJoCebffvwdfFfIZwHyU;

	private PlatformInputManager xMbKLaCGuEbKMBvCgzLnCelOFesiA;

	private readonly bool bbUMUfNASXFZqAFXxxunChiGsIfv;

	private readonly bool LPWzZDFuCGenRXOecpHiORtNVXbm;

	private readonly bool qYelGGpuhzjpuHinHZzFMQDpOfKT;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> VuYbkndBJbjsMyCLKBKphtvAsXGHB;

	private readonly Func<int> AYhFZnZLwQTqsIGqlblJGcweUWDnA;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => TQuZrEtvuuFuGwnchIACNSKMPfuh;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => xMbKLaCGuEbKMBvCgzLnCelOFesiA;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => RQKUfHlXoTMYbdSCAsFDRIBRZVVn;

	protected abstract IInputSource SsibOHKXnHmjiqrREMDvanCfhaqyB(UpdateLoopSetting P_0, bool P_1, bool P_2, bool P_3, bool P_4);

	public mmPixGkNrSmtDGIDPEZUiOYOuFCLA(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2, bool P_3, bool P_4, bool P_5)
	{
		try
		{
			VuYbkndBJbjsMyCLKBKphtvAsXGHB = P_1;
			AYhFZnZLwQTqsIGqlblJGcweUWDnA = P_2;
			bbUMUfNASXFZqAFXxxunChiGsIfv = P_3;
			LPWzZDFuCGenRXOecpHiORtNVXbm = P_4;
			qYelGGpuhzjpuHinHZzFMQDpOfKT = P_5;
			xMbKLaCGuEbKMBvCgzLnCelOFesiA = this;
			RQKUfHlXoTMYbdSCAsFDRIBRZVVn = SsibOHKXnHmjiqrREMDvanCfhaqyB(P_0.updateLoop, P_3, P_3, P_4, P_5);
			BxHhmIzNZJoCebffvwdfFfIZwHyU = UpdateControllerData;
			RQKUfHlXoTMYbdSCAsFDRIBRZVVn.DeviceChangedEvent += KxuXLwJHEdIwiKFFrvpVgSvfkRMp;
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
		if (bbUMUfNASXFZqAFXxxunChiGsIfv)
		{
			UnWhqSBCSADTcDyzSFyDFoJCUAMsA = new uKYmdwRKKKBnCbSjfVLKvNKjNXTY();
			hNQdZbXHIDUnpGwOlMwuWdZMdbJcA();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (RQKUfHlXoTMYbdSCAsFDRIBRZVVn != null)
		{
			RQKUfHlXoTMYbdSCAsFDRIBRZVVn.Update();
		}
		if (bbUMUfNASXFZqAFXxxunChiGsIfv)
		{
			if (jnMokVOBthXrwwjyrRQMvuYnqPYu)
			{
				BIHtrCqhjKvWKnZhmzWoblKeOaXH();
			}
			if (RQKUfHlXoTMYbdSCAsFDRIBRZVVn != null)
			{
				for (int i = 0; i < TQuZrEtvuuFuGwnchIACNSKMPfuh; i++)
				{
					aDGHdmmtlAOjDwCrTUhDPhTEJVsw[i]?.ojbnSvfVZePeVgfClgTHkaCaQumP.sXVAnovXmYbxhiVlNwYlutHPvlrKA(updateLoop);
				}
				RQKUfHlXoTMYbdSCAsFDRIBRZVVn.UpdateDevices(updateLoop);
			}
			AONExblFCAiiBSXkMFyDIzEiJjZx();
			if (RQKUfHlXoTMYbdSCAsFDRIBRZVVn != null)
			{
				RQKUfHlXoTMYbdSCAsFDRIBRZVVn.UpdateFinished();
				for (int j = 0; j < TQuZrEtvuuFuGwnchIACNSKMPfuh; j++)
				{
					aDGHdmmtlAOjDwCrTUhDPhTEJVsw[j]?.ojbnSvfVZePeVgfClgTHkaCaQumP.FatOghjuifHTjFnmyPZSiiVppVWq();
				}
			}
		}
		_ = LPWzZDFuCGenRXOecpHiORtNVXbm;
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (aDGHdmmtlAOjDwCrTUhDPhTEJVsw != null)
		{
			int count = aDGHdmmtlAOjDwCrTUhDPhTEJVsw.Count;
			for (int i = 0; i < count; i++)
			{
				if (aDGHdmmtlAOjDwCrTUhDPhTEJVsw[i] != null)
				{
					aDGHdmmtlAOjDwCrTUhDPhTEJVsw[i].ojbnSvfVZePeVgfClgTHkaCaQumP?.OtBYnsNLCIUaYAtMOLtKsdzIqPmG();
				}
			}
		}
		if (RQKUfHlXoTMYbdSCAsFDRIBRZVVn != null)
		{
			RQKUfHlXoTMYbdSCAsFDRIBRZVVn.Dispose();
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return BxHhmIzNZJoCebffvwdfFfIZwHyU;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		if (!bbUMUfNASXFZqAFXxxunChiGsIfv)
		{
			return;
		}
		for (int i = 0; i < TQuZrEtvuuFuGwnchIACNSKMPfuh; i++)
		{
			if (aDGHdmmtlAOjDwCrTUhDPhTEJVsw[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
			{
				aDGHdmmtlAOjDwCrTUhDPhTEJVsw[i].FillData(data);
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		if (bbUMUfNASXFZqAFXxxunChiGsIfv)
		{
			jnMokVOBthXrwwjyrRQMvuYnqPYu = true;
		}
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		if (bbUMUfNASXFZqAFXxxunChiGsIfv)
		{
			jnMokVOBthXrwwjyrRQMvuYnqPYu = true;
		}
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		_ = bbUMUfNASXFZqAFXxxunChiGsIfv;
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

	private void hNQdZbXHIDUnpGwOlMwuWdZMdbJcA()
	{
		PCGqozSSejVRmxggyRbcKWUcqbLs(TJuOWirEdXRzrClPpGybspZFAMPg());
	}

	private void PCGqozSSejVRmxggyRbcKWUcqbLs(IList<YUhbQhiLFKRAUFwRWqBNoTItxqmB> P_0)
	{
		int num = 0;
		List<mCsctSLCnXZKhIoDZOaHDHKsdCoL> list = aDGHdmmtlAOjDwCrTUhDPhTEJVsw;
		int tQuZrEtvuuFuGwnchIACNSKMPfuh = TQuZrEtvuuFuGwnchIACNSKMPfuh;
		aDGHdmmtlAOjDwCrTUhDPhTEJVsw = new List<mCsctSLCnXZKhIoDZOaHDHKsdCoL>();
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null)
			{
				YUhbQhiLFKRAUFwRWqBNoTItxqmB yUhbQhiLFKRAUFwRWqBNoTItxqmB = P_0[i];
				mCsctSLCnXZKhIoDZOaHDHKsdCoL mCsctSLCnXZKhIoDZOaHDHKsdCoL2 = new mCsctSLCnXZKhIoDZOaHDHKsdCoL(inputSourceType, yUhbQhiLFKRAUFwRWqBNoTItxqmB, VuYbkndBJbjsMyCLKBKphtvAsXGHB);
				yUhbQhiLFKRAUFwRWqBNoTItxqmB.uyVfLNISqYmeUOjSLTtsWhEiDJYDA();
				mCsctSLCnXZKhIoDZOaHDHKsdCoL2.tojanAEmPakVkyMNNlOlcvkvAAeRA();
				aDGHdmmtlAOjDwCrTUhDPhTEJVsw.Add(mCsctSLCnXZKhIoDZOaHDHKsdCoL2);
				num++;
			}
		}
		TQuZrEtvuuFuGwnchIACNSKMPfuh = num;
		UOzVhDfQbwgqNVcEjFfRwCscUKQk(tQuZrEtvuuFuGwnchIACNSKMPfuh, num, list, aDGHdmmtlAOjDwCrTUhDPhTEJVsw);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(aDGHdmmtlAOjDwCrTUhDPhTEJVsw[j]));
			}
		}
		KdcmjFyvQDfFqsHbgeKeoLENyqYf(list, aDGHdmmtlAOjDwCrTUhDPhTEJVsw, false);
		KdcmjFyvQDfFqsHbgeKeoLENyqYf(aDGHdmmtlAOjDwCrTUhDPhTEJVsw, list, true);
	}

	private void AONExblFCAiiBSXkMFyDIzEiJjZx()
	{
		for (int i = 0; i < TQuZrEtvuuFuGwnchIACNSKMPfuh; i++)
		{
			aDGHdmmtlAOjDwCrTUhDPhTEJVsw[i]?.Update();
		}
	}

	private bool PaQfHDjZYFWIDbRIQEBdEIjvOWriA(qsgekoIkSLKHNvSvhDyqzbhlTpKd P_0)
	{
		try
		{
			return P_0.rEybbyoLWHwQTcvIdpCuAsswrlWx();
		}
		catch
		{
			return false;
		}
	}

	private IList<YUhbQhiLFKRAUFwRWqBNoTItxqmB> TJuOWirEdXRzrClPpGybspZFAMPg()
	{
		return RQKUfHlXoTMYbdSCAsFDRIBRZVVn.GetJoysticks<YUhbQhiLFKRAUFwRWqBNoTItxqmB>();
	}

	private void UOzVhDfQbwgqNVcEjFfRwCscUKQk(int P_0, int P_1, List<mCsctSLCnXZKhIoDZOaHDHKsdCoL> P_2, List<mCsctSLCnXZKhIoDZOaHDHKsdCoL> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(mCsctSLCnXZKhIoDZOaHDHKsdCoL.CLXUBRLBLgSYjdvXBPUBiCUjtsyx);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			NaMcgEmSecrIqQeGwBjzNUGkFbMgA(P_1, P_3, P_0, P_2, uKYmdwRKKKBnCbSjfVLKvNKjNXTY.dBwVdbAGbFpwmBsjyDInNSlJNAaR.Exact);
			NaMcgEmSecrIqQeGwBjzNUGkFbMgA(P_1, P_3, P_0, P_2, uKYmdwRKKKBnCbSjfVLKvNKjNXTY.dBwVdbAGbFpwmBsjyDInNSlJNAaR.Approximate);
		}
		ugxpxnCLkfumGBSHGBtpENMDCTNW(P_1, P_3, uKYmdwRKKKBnCbSjfVLKvNKjNXTY.dBwVdbAGbFpwmBsjyDInNSlJNAaR.Exact);
		ugxpxnCLkfumGBSHGBtpENMDCTNW(P_1, P_3, uKYmdwRKKKBnCbSjfVLKvNKjNXTY.dBwVdbAGbFpwmBsjyDInNSlJNAaR.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			mCsctSLCnXZKhIoDZOaHDHKsdCoL mCsctSLCnXZKhIoDZOaHDHKsdCoL2 = P_3[i];
			if (mCsctSLCnXZKhIoDZOaHDHKsdCoL2 != null && mCsctSLCnXZKhIoDZOaHDHKsdCoL2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				mCsctSLCnXZKhIoDZOaHDHKsdCoL2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = aqUhDitJilXwQyyXROLgLZTbUMGr(P_3);
				mCsctSLCnXZKhIoDZOaHDHKsdCoL2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = AYhFZnZLwQTqsIGqlblJGcweUWDnA();
				UnWhqSBCSADTcDyzSFyDFoJCUAMsA.lEpdnuaQSefHQfEKUAlHrzcYEbQcA(mCsctSLCnXZKhIoDZOaHDHKsdCoL2);
			}
		}
		P_3.Sort(mCsctSLCnXZKhIoDZOaHDHKsdCoL.tTqXQiFJerDINsRpkcDyGBuJFxJsA);
	}

	private void kDaSLPiGEKPcILAIoZTUmtPRDmTG(List<mCsctSLCnXZKhIoDZOaHDHKsdCoL> P_0, int P_1, int P_2)
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

	private bool qvggdXtPdIoJjQzdzicCxYBcAjcq(List<mCsctSLCnXZKhIoDZOaHDHKsdCoL> P_0, int P_1)
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

	private int aqUhDitJilXwQyyXROLgLZTbUMGr(List<mCsctSLCnXZKhIoDZOaHDHKsdCoL> P_0)
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

	private bool UKzlPVVWmaxkYofllZqOhuNtBpFI(List<mCsctSLCnXZKhIoDZOaHDHKsdCoL> P_0, int P_1)
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

	private void NaMcgEmSecrIqQeGwBjzNUGkFbMgA(int P_0, List<mCsctSLCnXZKhIoDZOaHDHKsdCoL> P_1, int P_2, List<mCsctSLCnXZKhIoDZOaHDHKsdCoL> P_3, uKYmdwRKKKBnCbSjfVLKvNKjNXTY.dBwVdbAGbFpwmBsjyDInNSlJNAaR P_4)
	{
		int num = ((P_4 != uKYmdwRKKKBnCbSjfVLKvNKjNXTY.dBwVdbAGbFpwmBsjyDInNSlJNAaR.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			mCsctSLCnXZKhIoDZOaHDHKsdCoL mCsctSLCnXZKhIoDZOaHDHKsdCoL2 = P_1[i];
			if (mCsctSLCnXZKhIoDZOaHDHKsdCoL2 == null || mCsctSLCnXZKhIoDZOaHDHKsdCoL2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				mCsctSLCnXZKhIoDZOaHDHKsdCoL mCsctSLCnXZKhIoDZOaHDHKsdCoL3 = P_3[j];
				if (mCsctSLCnXZKhIoDZOaHDHKsdCoL3 != null && !UKzlPVVWmaxkYofllZqOhuNtBpFI(P_1, mCsctSLCnXZKhIoDZOaHDHKsdCoL3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && mCsctSLCnXZKhIoDZOaHDHKsdCoL2.eVTVtAKEmOnmjuTdLwnlxMkdYFlA(mCsctSLCnXZKhIoDZOaHDHKsdCoL3) >= num)
				{
					mCsctSLCnXZKhIoDZOaHDHKsdCoL2.xsHIYqVsjeEFvOgCmWTXbDeAqQwg(mCsctSLCnXZKhIoDZOaHDHKsdCoL3);
					UnWhqSBCSADTcDyzSFyDFoJCUAMsA.lEpdnuaQSefHQfEKUAlHrzcYEbQcA(mCsctSLCnXZKhIoDZOaHDHKsdCoL2);
				}
			}
		}
	}

	private void ugxpxnCLkfumGBSHGBtpENMDCTNW(int P_0, List<mCsctSLCnXZKhIoDZOaHDHKsdCoL> P_1, uKYmdwRKKKBnCbSjfVLKvNKjNXTY.dBwVdbAGbFpwmBsjyDInNSlJNAaR P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			mCsctSLCnXZKhIoDZOaHDHKsdCoL mCsctSLCnXZKhIoDZOaHDHKsdCoL2 = P_1[i];
			if (mCsctSLCnXZKhIoDZOaHDHKsdCoL2 == null || mCsctSLCnXZKhIoDZOaHDHKsdCoL2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			uKYmdwRKKKBnCbSjfVLKvNKjNXTY.soFtPSddzwupyTpmYHBwdQTHzFlE soFtPSddzwupyTpmYHBwdQTHzFlE = null;
			foreach (uKYmdwRKKKBnCbSjfVLKvNKjNXTY.soFtPSddzwupyTpmYHBwdQTHzFlE item in UnWhqSBCSADTcDyzSFyDFoJCUAMsA.tcjOntdMewfimFMeMmKkfgXHOReBB(mCsctSLCnXZKhIoDZOaHDHKsdCoL2, P_2))
			{
				if (!UKzlPVVWmaxkYofllZqOhuNtBpFI(P_1, item.atENQldkRBLXOcNwDBFVUvqwqlrM) && item.WzQXNkKMevYJcVTKXcJiYmmePQZu >= 0)
				{
					soFtPSddzwupyTpmYHBwdQTHzFlE = item;
					break;
				}
			}
			if (soFtPSddzwupyTpmYHBwdQTHzFlE != null)
			{
				int num = soFtPSddzwupyTpmYHBwdQTHzFlE.WzQXNkKMevYJcVTKXcJiYmmePQZu;
				if (!qvggdXtPdIoJjQzdzicCxYBcAjcq(P_1, num))
				{
					num = (soFtPSddzwupyTpmYHBwdQTHzFlE.WzQXNkKMevYJcVTKXcJiYmmePQZu = aqUhDitJilXwQyyXROLgLZTbUMGr(P_1));
				}
				mCsctSLCnXZKhIoDZOaHDHKsdCoL2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				mCsctSLCnXZKhIoDZOaHDHKsdCoL2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = soFtPSddzwupyTpmYHBwdQTHzFlE.atENQldkRBLXOcNwDBFVUvqwqlrM;
				UnWhqSBCSADTcDyzSFyDFoJCUAMsA.lEpdnuaQSefHQfEKUAlHrzcYEbQcA(mCsctSLCnXZKhIoDZOaHDHKsdCoL2);
			}
		}
	}

	private void BIHtrCqhjKvWKnZhmzWoblKeOaXH()
	{
		IList<YUhbQhiLFKRAUFwRWqBNoTItxqmB> list = TJuOWirEdXRzrClPpGybspZFAMPg();
		PCGqozSSejVRmxggyRbcKWUcqbLs(list);
		jnMokVOBthXrwwjyrRQMvuYnqPYu = false;
	}

	private bool XckjOxwouEcvMSybTocTKLxEcgCaA(IList<YUhbQhiLFKRAUFwRWqBNoTItxqmB> P_0)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && !LiKwDKQUcuoMDYGfVOUBleCgthnq(P_0[i].yhicbDjyGKhUgYmbAOJdueUvjYqM))
			{
				return true;
			}
		}
		int count2 = aDGHdmmtlAOjDwCrTUhDPhTEJVsw.Count;
		for (int j = 0; j < count2; j++)
		{
			if (aDGHdmmtlAOjDwCrTUhDPhTEJVsw[j] != null && !fGzXudAvwKWWbFymIrILMGgJqExK(P_0, aDGHdmmtlAOjDwCrTUhDPhTEJVsw[j].cgsLplvGJqOXrgiUuOsdWMGZzVxg))
			{
				return true;
			}
		}
		return false;
	}

	private bool LiKwDKQUcuoMDYGfVOUBleCgthnq(Guid P_0)
	{
		int count = aDGHdmmtlAOjDwCrTUhDPhTEJVsw.Count;
		for (int i = 0; i < count; i++)
		{
			if (aDGHdmmtlAOjDwCrTUhDPhTEJVsw[i] != null && aDGHdmmtlAOjDwCrTUhDPhTEJVsw[i].cgsLplvGJqOXrgiUuOsdWMGZzVxg == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool fGzXudAvwKWWbFymIrILMGgJqExK(IList<YUhbQhiLFKRAUFwRWqBNoTItxqmB> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].yhicbDjyGKhUgYmbAOJdueUvjYqM == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void KdcmjFyvQDfFqsHbgeKeoLENyqYf(List<mCsctSLCnXZKhIoDZOaHDHKsdCoL> P_0, List<mCsctSLCnXZKhIoDZOaHDHKsdCoL> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			mCsctSLCnXZKhIoDZOaHDHKsdCoL mCsctSLCnXZKhIoDZOaHDHKsdCoL2 = P_0[i];
			if (mCsctSLCnXZKhIoDZOaHDHKsdCoL2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					mCsctSLCnXZKhIoDZOaHDHKsdCoL mCsctSLCnXZKhIoDZOaHDHKsdCoL3 = P_1[j];
					if (mCsctSLCnXZKhIoDZOaHDHKsdCoL3 != null && mCsctSLCnXZKhIoDZOaHDHKsdCoL2.cgsLplvGJqOXrgiUuOsdWMGZzVxg == mCsctSLCnXZKhIoDZOaHDHKsdCoL3.cgsLplvGJqOXrgiUuOsdWMGZzVxg)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				CYkdOYBbSjmNheaiebLqcAfmSDbyb(P_0[i], P_2);
			}
		}
	}

	private void CYkdOYBbSjmNheaiebLqcAfmSDbyb(mCsctSLCnXZKhIoDZOaHDHKsdCoL P_0, bool P_1)
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

	private void KxuXLwJHEdIwiKFFrvpVgSvfkRMp()
	{
		if (bbUMUfNASXFZqAFXxxunChiGsIfv)
		{
			jnMokVOBthXrwwjyrRQMvuYnqPYu = true;
		}
		SystemDeviceConnected();
	}
}
