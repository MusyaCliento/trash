using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Libraries.SharpDX.XInput;
using Rewired.Platforms;
using Rewired.Platforms.Windows.XInput;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class BdmVZBfayIRaEoZyauttTYQvabrH : PlatformInputManager, NmANKYQYjJJatXyTLQutNfBhTrds
{
	private class KeZhSdfkYmGguaxwpyFcSLwyOiiG : IInputManagerJoystick, IInputManagerJoystickPublic, ITryGetLocalizedName, IDisposable
	{
		private bool JzhoQyVXinfMiURrtsxdncsKSrLM;

		private int iQGoOJwEFdGChONKrCSmzqNQrmXk;

		private readonly int PWLkGylPKrEgTlxTTpHKlXjRLNBr;

		public Guid CadifvpIqlazUGVAzegSzfflPDSlA;

		public string TwLHFHMeesDklNPAiJBfaayODfko;

		public string NYuoKTToieYDLUYunDkrmcmmbfoZ;

		public Guid ZKsKgRHpnOevfXxsgwnRCoVQZnvr;

		public Rewired.Libraries.SharpDX.XInput.DeviceType AMdOcXaLnbHSyrFHPfcldPRcQBtq;

		public XInputDeviceSubType rISmKGdgJSkRiBrydmAxedQDCsWAA;

		public bool EIUrerWeqlvGcWNDaunUpqfabvzs;

		public bool JacRdgPTNStLVRsHFxlMepampiOM;

		public bool IjniXuQUcfgfpioXCKyVhKyjuGjf;

		public bool WNdtKVAWQInvmYKcklozwNTjcsVHA;

		private int tGPfYMGqweqYGkcuaoTmVQarmFqQA;

		private int syoFSFMIwERRsNArpGUvZyRJMNol;

		private int TlcbsAeLMPzbwTAcrSpCWqaMjkwq;

		private int SMePedLwcuRMYhsfeCGSKIilmwOG;

		private readonly float[] EeaCgbWGeMpGhaauHgfIfkpCNhSgA;

		private readonly bool[] OFMaMEukhLuOpTsjlbdnRIStmRUi;

		private HardwareJoystickMap_InputManager aCPYIpUIRpAhUPxjEHSQayuJaFYN;

		public readonly EdAdrvqVjdvmYwSrfMeUtepFgJWn GFvNQcsBufIrzKhYgmzqTDHdCRvkA;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> rdTfWwVuSOxNoGHgfdiphbgKaoIvA;

		private Action GZwWEWTagflSlkdVGoRUFaNQOymT;

		private readonly LocalizedString VDPInrTGtLKvHxCphExqHglWuMSG;

		private bool wYVdRZaidKmuJoZtGawrZcIUgilD;

		private bool oSEbdKjgWaPoRoUebtknBHiEQiTp;

		private bool ENsreFlrUdMNgCNZSiLSmLnVcPpAA;

		public string EgdFcDlgbqCbmSYgdAkPLGuZsxdh
		{
			get
			{
				string text = oHalzAkfoBkryaAPPEMGFOvVThLB;
				if (text == string.Empty)
				{
					return string.Empty;
				}
				int pWLkGylPKrEgTlxTTpHKlXjRLNBr = PWLkGylPKrEgTlxTTpHKlXjRLNBr;
				return text + " " + pWLkGylPKrEgTlxTTpHKlXjRLNBr;
			}
		}

		public string oHalzAkfoBkryaAPPEMGFOvVThLB
		{
			get
			{
				if (!rDoLcGInZokeprIbBJZTqLGiuqGg)
				{
					return string.Empty;
				}
				return rISmKGdgJSkRiBrydmAxedQDCsWAA.ToString();
			}
		}

		public bool rDoLcGInZokeprIbBJZTqLGiuqGg
		{
			get
			{
				if (GFvNQcsBufIrzKhYgmzqTDHdCRvkA == null || !WNdtKVAWQInvmYKcklozwNTjcsVHA)
				{
					return false;
				}
				if (wYVdRZaidKmuJoZtGawrZcIUgilD && !CWdXDAnKHRkFNMUHzirZBuhjFtid(FyNifoPLIjINdzHQISzaijMlhBfF.Asynchronous))
				{
					vZJELKhkKPMwfraBDRUwaZgvqNRvA();
				}
				return wYVdRZaidKmuJoZtGawrZcIUgilD;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return iQGoOJwEFdGChONKrCSmzqNQrmXk;
			}
			set
			{
				iQGoOJwEFdGChONKrCSmzqNQrmXk = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId => PWLkGylPKrEgTlxTTpHKlXjRLNBr;

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name => NYuoKTToieYDLUYunDkrmcmmbfoZ;

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId => PWLkGylPKrEgTlxTTpHKlXjRLNBr;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension
		{
			get
			{
				if (GFvNQcsBufIrzKhYgmzqTDHdCRvkA == null)
				{
					return null;
				}
				return GFvNQcsBufIrzKhYgmzqTDHdCRvkA.LulfleeqSRYIlhoLpMcHpKsdJaNu;
			}
		}

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => ZKsKgRHpnOevfXxsgwnRCoVQZnvr;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			GFvNQcsBufIrzKhYgmzqTDHdCRvkA.fvYoCLATSCoVBXpvlXBrdrXQsJrI(amount, motorIndex);
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			GFvNQcsBufIrzKhYgmzqTDHdCRvkA.dRqHnmxCGlgxQlvAvmIkPEaaDYSR();
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
		{
			if ((LocalizationManager.GetAndUpdateLocalizedString(VDPInrTGtLKvHxCphExqHglWuMSG, aCPYIpUIRpAhUPxjEHSQayuJaFYN.deviceLocalizationInfo.parentKeys, "controller", TwLHFHMeesDklNPAiJBfaayODfko, out value) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
			{
				value = $"{value} {(PWLkGylPKrEgTlxTTpHKlXjRLNBr + 1).ToString()}";
				VDPInrTGtLKvHxCphExqHglWuMSG.cachedValue = value;
			}
			return true;
		}

		public KeZhSdfkYmGguaxwpyFcSLwyOiiG(int P_0, bool P_1, EdAdrvqVjdvmYwSrfMeUtepFgJWn P_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_3, Action P_4)
		{
			GFvNQcsBufIrzKhYgmzqTDHdCRvkA = P_2;
			JzhoQyVXinfMiURrtsxdncsKSrLM = P_1;
			PWLkGylPKrEgTlxTTpHKlXjRLNBr = P_0;
			rdTfWwVuSOxNoGHgfdiphbgKaoIvA = P_3;
			GZwWEWTagflSlkdVGoRUFaNQOymT = P_4;
			iQGoOJwEFdGChONKrCSmzqNQrmXk = -1;
			tGPfYMGqweqYGkcuaoTmVQarmFqQA = 6;
			syoFSFMIwERRsNArpGUvZyRJMNol = 15;
			TlcbsAeLMPzbwTAcrSpCWqaMjkwq = tGPfYMGqweqYGkcuaoTmVQarmFqQA;
			SMePedLwcuRMYhsfeCGSKIilmwOG = syoFSFMIwERRsNArpGUvZyRJMNol;
			EeaCgbWGeMpGhaauHgfIfkpCNhSgA = new float[tGPfYMGqweqYGkcuaoTmVQarmFqQA];
			OFMaMEukhLuOpTsjlbdnRIStmRUi = new bool[syoFSFMIwERRsNArpGUvZyRJMNol];
			VDPInrTGtLKvHxCphExqHglWuMSG = new LocalizedString();
			TjLfUdhhVhXDwiLRdqsdBfGHkYEqc();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			GFvNQcsBufIrzKhYgmzqTDHdCRvkA.onsZbFdAbjbPxJHUygwagWqlyvfoA();
			bool[] array = GFvNQcsBufIrzKhYgmzqTDHdCRvkA.CoJgtwHPqHwMvOlSRrrfRzvuJvKX;
			RGYfXoZSkuZJRVICbLZttQVYzPeH(array, ref GFvNQcsBufIrzKhYgmzqTDHdCRvkA.IxxpGBrWkathxXkzNZivlwkpmdmR);
			tbjbiPgFpPsBCWgdTHeLaGUJEOrzb(array, ref GFvNQcsBufIrzKhYgmzqTDHdCRvkA.IxxpGBrWkathxXkzNZivlwkpmdmR);
			GFvNQcsBufIrzKhYgmzqTDHdCRvkA.FqnrPSKbqCgfbHwtOAsOZGbCtnQBA();
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public void QMJaIzaiIqOzjqbxjSJwisfFJaKCb(bool P_0)
		{
			if (GFvNQcsBufIrzKhYgmzqTDHdCRvkA != null)
			{
				IjniXuQUcfgfpioXCKyVhKyjuGjf = P_0;
			}
		}

		public bool CWdXDAnKHRkFNMUHzirZBuhjFtid(FyNifoPLIjINdzHQISzaijMlhBfF P_0)
		{
			CKBklJbOYHQqXjBLQpWNINhkiIj(AwTnTKPTyjNFLzIOZKzUrdOXcQADA(P_0));
			return wYVdRZaidKmuJoZtGawrZcIUgilD;
		}

		public bool AwTnTKPTyjNFLzIOZKzUrdOXcQADA(FyNifoPLIjINdzHQISzaijMlhBfF P_0)
		{
			if (GFvNQcsBufIrzKhYgmzqTDHdCRvkA == null)
			{
				return false;
			}
			return GFvNQcsBufIrzKhYgmzqTDHdCRvkA.BLTOJyWbycAQqiLEcQYXmnJkuEwGA(P_0);
		}

		public void CKBklJbOYHQqXjBLQpWNINhkiIj(bool P_0)
		{
			wYVdRZaidKmuJoZtGawrZcIUgilD = P_0;
		}

		public void ZpMkwJepKfmLUnNriuCcHzEHJark()
		{
			if (!WNdtKVAWQInvmYKcklozwNTjcsVHA || cAsekuXCIUCIjXPwXEewEfvfMYYY())
			{
				TjLfUdhhVhXDwiLRdqsdBfGHkYEqc();
			}
			if (WNdtKVAWQInvmYKcklozwNTjcsVHA && wYVdRZaidKmuJoZtGawrZcIUgilD)
			{
				GFvNQcsBufIrzKhYgmzqTDHdCRvkA.sNQcpKdteCQptbKwgQbbGbZmeGDLb();
			}
		}

		public void EqwCQYzpYuZRymEzyjjDNeSkxDpL()
		{
			iQGoOJwEFdGChONKrCSmzqNQrmXk = -1;
			WNdtKVAWQInvmYKcklozwNTjcsVHA = false;
			GFvNQcsBufIrzKhYgmzqTDHdCRvkA.WxQkoTVtksqSSgqPUlHiJJMynIx();
			Array.Clear(EeaCgbWGeMpGhaauHgfIfkpCNhSgA, 0, EeaCgbWGeMpGhaauHgfIfkpCNhSgA.Length);
			Array.Clear(OFMaMEukhLuOpTsjlbdnRIStmRUi, 0, OFMaMEukhLuOpTsjlbdnRIStmRUi.Length);
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (tGPfYMGqweqYGkcuaoTmVQarmFqQA != dataUpdater.axisCount || syoFSFMIwERRsNArpGUvZyRJMNol != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < tGPfYMGqweqYGkcuaoTmVQarmFqQA; i++)
			{
				dataUpdater.axisValues[i] = EeaCgbWGeMpGhaauHgfIfkpCNhSgA[i];
			}
			for (int j = 0; j < syoFSFMIwERRsNArpGUvZyRJMNol; j++)
			{
				dataUpdater.buttonValues[j] = OFMaMEukhLuOpTsjlbdnRIStmRUi[j];
			}
			if (oSEbdKjgWaPoRoUebtknBHiEQiTp && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public BridgedControllerHWInfo WHMyuTghCpdCWmogLeNCnGFjBgpFA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			AroFfqZbJkESvOMPoHbqmwHMbGyQ(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			nDIsFWtrGQhNgThgVBkiVJJWDVfhA(bridgedController);
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
			return new ControllerDisconnectedEventArgs(iQGoOJwEFdGChONKrCSmzqNQrmXk);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void TjLfUdhhVhXDwiLRdqsdBfGHkYEqc()
		{
			if (GFvNQcsBufIrzKhYgmzqTDHdCRvkA == null || !CWdXDAnKHRkFNMUHzirZBuhjFtid(FyNifoPLIjINdzHQISzaijMlhBfF.Synchronous))
			{
				return;
			}
			try
			{
				RJkbJYnZbNKGlcKLbSPobKGOdGhE();
				kLVKSgSTPAtymWLTsHpBaWkOwOnI kLVKSgSTPAtymWLTsHpBaWkOwOnI2 = GFvNQcsBufIrzKhYgmzqTDHdCRvkA.oBzNpRuvBnfNMUuIdImMpXSxHOTj.kMLCYSWqrbdWnHgzzCqooIvxVAQDA(HTmUSdjjloDLLeXwWcZCmgewsKtR.Any);
				AMdOcXaLnbHSyrFHPfcldPRcQBtq = kLVKSgSTPAtymWLTsHpBaWkOwOnI2.ZxUschgOBYxJjoqutgZCgxRHDONIA;
				rISmKGdgJSkRiBrydmAxedQDCsWAA = (XInputDeviceSubType)kLVKSgSTPAtymWLTsHpBaWkOwOnI2.oczyOVIGQzCnKAvekzEGfHsnQeCh;
				if (GFvNQcsBufIrzKhYgmzqTDHdCRvkA.oBzNpRuvBnfNMUuIdImMpXSxHOTj.gfdfyICEFaRKbuhXhTYckHdQmvicA(default(seSCKmPhVOaOdbrRYdsdcvubRfnXA)).CdUQUdeMcIYJygTSiOKcWCGCFUtl)
				{
					EIUrerWeqlvGcWNDaunUpqfabvzs = true;
				}
				JacRdgPTNStLVRsHFxlMepampiOM = (kLVKSgSTPAtymWLTsHpBaWkOwOnI2.doaFUVijJNeyFOVlXNUwdWDtFkSwA & CbUeKRBHgIQDxcKAWIpaIbXbHykmc.VoiceSupported) == CbUeKRBHgIQDxcKAWIpaIbXbHykmc.VoiceSupported;
				zvvJJypsGGqUKeBYVznrRlfMAjMq();
				CadifvpIqlazUGVAzegSzfflPDSlA = aCPYIpUIRpAhUPxjEHSQayuJaFYN.hardwareMapIdentifier.guid;
				if (JzhoQyVXinfMiURrtsxdncsKSrLM)
				{
					TwLHFHMeesDklNPAiJBfaayODfko = StringTools.AddSpacesToCamelCase(rISmKGdgJSkRiBrydmAxedQDCsWAA.ToString());
				}
				else
				{
					TwLHFHMeesDklNPAiJBfaayODfko = "XInput " + rISmKGdgJSkRiBrydmAxedQDCsWAA;
				}
				NYuoKTToieYDLUYunDkrmcmmbfoZ = $"{TwLHFHMeesDklNPAiJBfaayODfko} {(PWLkGylPKrEgTlxTTpHKlXjRLNBr + 1).ToString()}";
				string additionalIdentifyingInformation = LocalizationManager.FormatKey(rISmKGdgJSkRiBrydmAxedQDCsWAA.ToString());
				aCPYIpUIRpAhUPxjEHSQayuJaFYN.deviceLocalizationInfo.additionalIdentifyingInformation = additionalIdentifyingInformation;
				VDPInrTGtLKvHxCphExqHglWuMSG.Clear();
				GFvNQcsBufIrzKhYgmzqTDHdCRvkA.sNQcpKdteCQptbKwgQbbGbZmeGDLb();
				ZKsKgRHpnOevfXxsgwnRCoVQZnvr = MiscTools.CreateGuidHashSHA1(string.Concat(AMdOcXaLnbHSyrFHPfcldPRcQBtq, rISmKGdgJSkRiBrydmAxedQDCsWAA, PWLkGylPKrEgTlxTTpHKlXjRLNBr));
				WNdtKVAWQInvmYKcklozwNTjcsVHA = true;
			}
			catch (Exception)
			{
				WNdtKVAWQInvmYKcklozwNTjcsVHA = false;
				wYVdRZaidKmuJoZtGawrZcIUgilD = false;
				ZKsKgRHpnOevfXxsgwnRCoVQZnvr = Guid.Empty;
			}
		}

		private bool cAsekuXCIUCIjXPwXEewEfvfMYYY()
		{
			try
			{
				if (rISmKGdgJSkRiBrydmAxedQDCsWAA != (XInputDeviceSubType)GFvNQcsBufIrzKhYgmzqTDHdCRvkA.oBzNpRuvBnfNMUuIdImMpXSxHOTj.kMLCYSWqrbdWnHgzzCqooIvxVAQDA(HTmUSdjjloDLLeXwWcZCmgewsKtR.Any).oczyOVIGQzCnKAvekzEGfHsnQeCh)
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		private void RJkbJYnZbNKGlcKLbSPobKGOdGhE()
		{
			JacRdgPTNStLVRsHFxlMepampiOM = false;
			EIUrerWeqlvGcWNDaunUpqfabvzs = false;
			IjniXuQUcfgfpioXCKyVhKyjuGjf = false;
			WNdtKVAWQInvmYKcklozwNTjcsVHA = false;
		}

		private void vZJELKhkKPMwfraBDRUwaZgvqNRvA()
		{
			if (GZwWEWTagflSlkdVGoRUFaNQOymT != null)
			{
				GZwWEWTagflSlkdVGoRUFaNQOymT();
			}
			GFvNQcsBufIrzKhYgmzqTDHdCRvkA.WxQkoTVtksqSSgqPUlHiJJMynIx();
		}

		private void RGYfXoZSkuZJRVICbLZttQVYzPeH(bool[] P_0, ref RDPIvgZmETOFlXaaJChnAXLAtWjJ P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_XInput_Base)aCPYIpUIRpAhUPxjEHSQayuJaFYN.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (i >= tGPfYMGqweqYGkcuaoTmVQarmFqQA)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				EeaCgbWGeMpGhaauHgfIfkpCNhSgA[i] = vaDBsyDhmPtpFEcbJQffwWyDcAaHb(axes_orig[i], P_0, ref P_1);
				if (!oSEbdKjgWaPoRoUebtknBHiEQiTp && EeaCgbWGeMpGhaauHgfIfkpCNhSgA[i] != 0f)
				{
					oSEbdKjgWaPoRoUebtknBHiEQiTp = true;
				}
			}
		}

		private void tbjbiPgFpPsBCWgdTHeLaGUJEOrzb(bool[] P_0, ref RDPIvgZmETOFlXaaJChnAXLAtWjJ P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_XInput_Base)aCPYIpUIRpAhUPxjEHSQayuJaFYN.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= syoFSFMIwERRsNArpGUvZyRJMNol)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				OFMaMEukhLuOpTsjlbdnRIStmRUi[i] = LoZYHwPpHCNatodLfVBCopbzTWnv(buttons_orig[i], P_0, ref P_1);
				if (!oSEbdKjgWaPoRoUebtknBHiEQiTp && OFMaMEukhLuOpTsjlbdnRIStmRUi[i])
				{
					oSEbdKjgWaPoRoUebtknBHiEQiTp = true;
				}
			}
		}

		private float vaDBsyDhmPtpFEcbJQffwWyDcAaHb(HardwareJoystickMap.Platform_XInput_Base.Axis P_0, bool[] P_1, ref RDPIvgZmETOFlXaaJChnAXLAtWjJ P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return 0f;
				}
				return VnVdDWZAPBXhXfJtLrBsPQcgUPny(P_0.sourceAxis, ref P_2);
			}
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return 0f;
				}
				if (!zLxbhWFWxTawtvxZmeQdIDJOVvZrA(P_0.sourceButton, P_1))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			}
			return 0f;
		}

		private float VnVdDWZAPBXhXfJtLrBsPQcgUPny(XInputAxis P_0, ref RDPIvgZmETOFlXaaJChnAXLAtWjJ P_1)
		{
			return P_0 switch
			{
				XInputAxis.LeftThumbX => EdAdrvqVjdvmYwSrfMeUtepFgJWn.ZvNqppOFFTWNQcLxFcXDKXcBdsVg(P_1.mkAFymYTAqRAHvKZVgNgwDKMbcpK), 
				XInputAxis.LeftThumbY => EdAdrvqVjdvmYwSrfMeUtepFgJWn.ZvNqppOFFTWNQcLxFcXDKXcBdsVg(P_1.ZUXoSqUhLyjQUUfujcVtJwyntyOe), 
				XInputAxis.RightThumbX => EdAdrvqVjdvmYwSrfMeUtepFgJWn.ZvNqppOFFTWNQcLxFcXDKXcBdsVg(P_1.emVGlEYuIVcugQBFZmjrdenVSrdD), 
				XInputAxis.RightThumbY => EdAdrvqVjdvmYwSrfMeUtepFgJWn.ZvNqppOFFTWNQcLxFcXDKXcBdsVg(P_1.OAYaUkixWLlzyrSdfZYzqnxsmCywA), 
				XInputAxis.LeftTrigger => EdAdrvqVjdvmYwSrfMeUtepFgJWn.qBRBDgRJkUynPRKsTLaZthzPgAJG(P_1.eUmeuQACKlQrHjdyiAvcFgThIACB), 
				XInputAxis.RightTrigger => EdAdrvqVjdvmYwSrfMeUtepFgJWn.qBRBDgRJkUynPRKsTLaZthzPgAJG(P_1.dGLyUzQfbaglrFpfdrKFeEzCimJE), 
				_ => 0f, 
			};
		}

		private bool LoZYHwPpHCNatodLfVBCopbzTWnv(HardwareJoystickMap.Platform_XInput_Base.Button P_0, bool[] P_1, ref RDPIvgZmETOFlXaaJChnAXLAtWjJ P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return false;
				}
				return zLxbhWFWxTawtvxZmeQdIDJOVvZrA(P_0.sourceButton, P_1);
			}
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return false;
				}
				float num = VnVdDWZAPBXhXfJtLrBsPQcgUPny(P_0.sourceAxis, ref P_2);
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
			return false;
		}

		private bool zLxbhWFWxTawtvxZmeQdIDJOVvZrA(XInputButton P_0, bool[] P_1)
		{
			return P_0 switch
			{
				XInputButton.DPadUp => P_1[0], 
				XInputButton.DPadDown => P_1[1], 
				XInputButton.DPadLeft => P_1[2], 
				XInputButton.DPadRight => P_1[3], 
				XInputButton.Start => P_1[4], 
				XInputButton.Back => P_1[5], 
				XInputButton.LeftThumb => P_1[6], 
				XInputButton.RightThumb => P_1[7], 
				XInputButton.LeftShoulder => P_1[8], 
				XInputButton.RightShoulder => P_1[9], 
				XInputButton.Guide => P_1[10], 
				XInputButton.A => P_1[11], 
				XInputButton.B => P_1[12], 
				XInputButton.X => P_1[13], 
				XInputButton.Y => P_1[14], 
				_ => false, 
			};
		}

		private void zvvJJypsGGqUKeBYVznrRlfMAjMq()
		{
			aCPYIpUIRpAhUPxjEHSQayuJaFYN = rdTfWwVuSOxNoGHgfdiphbgKaoIvA(WHMyuTghCpdCWmogLeNCnGFjBgpFA());
			if (aCPYIpUIRpAhUPxjEHSQayuJaFYN == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			tGPfYMGqweqYGkcuaoTmVQarmFqQA = aCPYIpUIRpAhUPxjEHSQayuJaFYN.axisCount;
			syoFSFMIwERRsNArpGUvZyRJMNol = aCPYIpUIRpAhUPxjEHSQayuJaFYN.buttonCount;
		}

		private bool JGIQhZZYflBhnwltZeryCxEsXYgQA(ref seSCKmPhVOaOdbrRYdsdcvubRfnXA P_0)
		{
			if (P_0.qEMPUGAVlexpkyfczHctHmTSEBcBA > 0 || P_0.fmgMOAAjzomtgSpNZwLyktFapOtC > 0)
			{
				return true;
			}
			return false;
		}

		private void rJeSDrdEtmDGQKyhorLQCeEJzsDU(ref seSCKmPhVOaOdbrRYdsdcvubRfnXA P_0)
		{
			P_0.qEMPUGAVlexpkyfczHctHmTSEBcBA = 0;
			P_0.fmgMOAAjzomtgSpNZwLyktFapOtC = 0;
		}

		private void WBagOrgNcCgxzWMJMvFweEQBmujM(ref seSCKmPhVOaOdbrRYdsdcvubRfnXA P_0, ref seSCKmPhVOaOdbrRYdsdcvubRfnXA P_1)
		{
			P_1.qEMPUGAVlexpkyfczHctHmTSEBcBA = P_0.qEMPUGAVlexpkyfczHctHmTSEBcBA;
			P_1.fmgMOAAjzomtgSpNZwLyktFapOtC = P_0.fmgMOAAjzomtgSpNZwLyktFapOtC;
		}

		private string gxenIjjOaQtBDcizPNGjnPAOTGDT()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.XInput.ToString()}{AMdOcXaLnbHSyrFHPfcldPRcQBtq.ToString()}{rISmKGdgJSkRiBrydmAxedQDCsWAA.ToString()}");
		}

		private void AroFfqZbJkESvOMPoHbqmwHMbGyQ(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.XInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = ControlDeviceType.Unknown;
			P_0.hardwareIdentifier = gxenIjjOaQtBDcizPNGjnPAOTGDT();
			P_0.hardwareAxisCount = TlcbsAeLMPzbwTAcrSpCWqaMjkwq;
			P_0.hardwareButtonCount = SMePedLwcuRMYhsfeCGSKIilmwOG;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = oHalzAkfoBkryaAPPEMGFOvVThLB;
			P_0.hw_supportsVoice = JacRdgPTNStLVRsHFxlMepampiOM;
			P_0.hw_supportsVibration = EIUrerWeqlvGcWNDaunUpqfabvzs;
			P_0.hw_localVibrationMotorCount = (EIUrerWeqlvGcWNDaunUpqfabvzs ? 2 : 0);
			P_0.hw_xInputSubType = rISmKGdgJSkRiBrydmAxedQDCsWAA;
		}

		private void nDIsFWtrGQhNgThgVBkiVJJWDVfhA(BridgedController P_0)
		{
			AroFfqZbJkESvOMPoHbqmwHMbGyQ(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = aCPYIpUIRpAhUPxjEHSQayuJaFYN.ToGameHardwareControllerMap();
			P_0.instanceName = "XInput " + EgdFcDlgbqCbmSYgdAkPLGuZsxdh;
			P_0.productName = "XInput " + oHalzAkfoBkryaAPPEMGFOvVThLB;
			P_0.isXInputDevice = true;
			P_0.axisCount = tGPfYMGqweqYGkcuaoTmVQarmFqQA;
			P_0.buttonCount = syoFSFMIwERRsNArpGUvZyRJMNol;
			P_0.controllerTypeGuid = CadifvpIqlazUGVAzegSzfflPDSlA;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		public void Dispose()
		{
			LUPiZRjlnmjPCWTYcsTQfMabwuHI(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void UbyYeqFoPddiJwQxLqGTyqoZIdvDA()
		{
			try
			{
				LUPiZRjlnmjPCWTYcsTQfMabwuHI(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void LUPiZRjlnmjPCWTYcsTQfMabwuHI(bool P_0)
		{
			if (ENsreFlrUdMNgCNZSiLSmLnVcPpAA)
			{
				return;
			}
			if (P_0)
			{
				if (rDoLcGInZokeprIbBJZTqLGiuqGg)
				{
					GFvNQcsBufIrzKhYgmzqTDHdCRvkA.mFnHcTeYBJAcDDmaHWuwYzhemyslA();
				}
				if (GFvNQcsBufIrzKhYgmzqTDHdCRvkA != null)
				{
					GFvNQcsBufIrzKhYgmzqTDHdCRvkA.Dispose();
				}
			}
			ENsreFlrUdMNgCNZSiLSmLnVcPpAA = true;
		}
	}

	private class UeSlEvHuiHLmzJTHgLpGYlDhZBnd
	{
		private class mAtQcZendeFouDBZcLLCNBElNfXtA
		{
			public bool cJKFBBCtlUPSXPyqlPYKmOLCcFjRA;

			public int ZeHfgVosyMgDGDgBrZLaanHADQFcA;

			public XInputDeviceSubType WEsASGRLsVieRRxmHAvFuNHHJAib;

			public void lOnAeykWItnJaFkljsTDtthcjkAO(KeZhSdfkYmGguaxwpyFcSLwyOiiG P_0, bool P_1)
			{
				cJKFBBCtlUPSXPyqlPYKmOLCcFjRA = P_1;
				ZeHfgVosyMgDGDgBrZLaanHADQFcA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
				WEsASGRLsVieRRxmHAvFuNHHJAib = P_0.rISmKGdgJSkRiBrydmAxedQDCsWAA;
			}

			public mAtQcZendeFouDBZcLLCNBElNfXtA(int P_0, XInputDeviceSubType P_1)
			{
				ZeHfgVosyMgDGDgBrZLaanHADQFcA = P_0;
				WEsASGRLsVieRRxmHAvFuNHHJAib = P_1;
			}
		}

		private List<mAtQcZendeFouDBZcLLCNBElNfXtA> OjoPwJkyJDxDDRQtqJxdmNgHLzWE;

		public UeSlEvHuiHLmzJTHgLpGYlDhZBnd()
		{
			OjoPwJkyJDxDDRQtqJxdmNgHLzWE = new List<mAtQcZendeFouDBZcLLCNBElNfXtA>();
		}

		public void xcFyewKhZjsLVqIPjtOoOgOjtRlw(KeZhSdfkYmGguaxwpyFcSLwyOiiG P_0, bool P_1)
		{
			if (VNYEVBgctqnTjyIDUlfNNkvriitJA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.rISmKGdgJSkRiBrydmAxedQDCsWAA, true) < 0)
			{
				mAtQcZendeFouDBZcLLCNBElNfXtA mAtQcZendeFouDBZcLLCNBElNfXtA2 = new mAtQcZendeFouDBZcLLCNBElNfXtA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.rISmKGdgJSkRiBrydmAxedQDCsWAA);
				mAtQcZendeFouDBZcLLCNBElNfXtA2.cJKFBBCtlUPSXPyqlPYKmOLCcFjRA = P_1;
				OjoPwJkyJDxDDRQtqJxdmNgHLzWE.Add(mAtQcZendeFouDBZcLLCNBElNfXtA2);
			}
		}

		public void qLcNjSMuoOEwjtdsOouKoqxzdCSn(int P_0, KeZhSdfkYmGguaxwpyFcSLwyOiiG P_1, bool P_2)
		{
			if (P_0 >= 0 && P_0 < OjoPwJkyJDxDDRQtqJxdmNgHLzWE.Count)
			{
				OjoPwJkyJDxDDRQtqJxdmNgHLzWE[P_0].lOnAeykWItnJaFkljsTDtthcjkAO(P_1, P_2);
			}
		}

		public int SrxtiMpjNGBTJfRpVAcCNpgwPqqLA(XInputDeviceSubType P_0, bool P_1)
		{
			int count = OjoPwJkyJDxDDRQtqJxdmNgHLzWE.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_1 || !OjoPwJkyJDxDDRQtqJxdmNgHLzWE[i].cJKFBBCtlUPSXPyqlPYKmOLCcFjRA) && OjoPwJkyJDxDDRQtqJxdmNgHLzWE[i].WEsASGRLsVieRRxmHAvFuNHHJAib == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		public int VNYEVBgctqnTjyIDUlfNNkvriitJA(int P_0, XInputDeviceSubType P_1, bool P_2)
		{
			int count = OjoPwJkyJDxDDRQtqJxdmNgHLzWE.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_2 || !OjoPwJkyJDxDDRQtqJxdmNgHLzWE[i].cJKFBBCtlUPSXPyqlPYKmOLCcFjRA) && OjoPwJkyJDxDDRQtqJxdmNgHLzWE[i].ZeHfgVosyMgDGDgBrZLaanHADQFcA == P_0 && OjoPwJkyJDxDDRQtqJxdmNgHLzWE[i].WEsASGRLsVieRRxmHAvFuNHHJAib == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		public int CFAclxaspILpJniHEuVmczmKfIAn(int P_0)
		{
			if (P_0 < 0 || P_0 >= OjoPwJkyJDxDDRQtqJxdmNgHLzWE.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return OjoPwJkyJDxDDRQtqJxdmNgHLzWE[P_0].ZeHfgVosyMgDGDgBrZLaanHADQFcA;
		}

		public void JprHjdHwkBACWhjiuPdnAbMNGWPj(int P_0, bool P_1)
		{
			if (P_0 >= 0 && P_0 < OjoPwJkyJDxDDRQtqJxdmNgHLzWE.Count)
			{
				OjoPwJkyJDxDDRQtqJxdmNgHLzWE[P_0].cJKFBBCtlUPSXPyqlPYKmOLCcFjRA = P_1;
			}
		}
	}

	private class wfWInpiEUTRKKVPXxiEKMvFjofdfb
	{
		public bool EioEwUHllXNRBRRhdypcmqXghtFoA;

		private double SteEXijHolZsKXOEPyTaYHaPTTbP;

		public float ptfqbyHFBYgLFLpYGeSoJMycSVLgA;

		public wfWInpiEUTRKKVPXxiEKMvFjofdfb()
		{
		}

		public wfWInpiEUTRKKVPXxiEKMvFjofdfb(float P_0)
		{
			ptfqbyHFBYgLFLpYGeSoJMycSVLgA = P_0;
		}

		public void bAkbEeGhGZLmAJKLDNMZIzvvNvsbB()
		{
			EioEwUHllXNRBRRhdypcmqXghtFoA = true;
			SteEXijHolZsKXOEPyTaYHaPTTbP = (double)ptfqbyHFBYgLFLpYGeSoJMycSVLgA + ReInput.unscaledTime;
		}

		public void aUjKhgFasBVhWBfJXuNLgLPrlGww(float P_0)
		{
			EioEwUHllXNRBRRhdypcmqXghtFoA = true;
			ptfqbyHFBYgLFLpYGeSoJMycSVLgA = P_0;
			SteEXijHolZsKXOEPyTaYHaPTTbP = (double)ptfqbyHFBYgLFLpYGeSoJMycSVLgA + ReInput.unscaledTime;
		}

		public bool EPEHVRVojyCdyIyETkiGJbAtVyINA()
		{
			if (!EioEwUHllXNRBRRhdypcmqXghtFoA)
			{
				return false;
			}
			if (ReInput.unscaledTime >= SteEXijHolZsKXOEPyTaYHaPTTbP)
			{
				EioEwUHllXNRBRRhdypcmqXghtFoA = false;
				return true;
			}
			return false;
		}

		public void FmtebXZfVtZouusUKSZeJqyAPdgD()
		{
			EioEwUHllXNRBRRhdypcmqXghtFoA = false;
			SteEXijHolZsKXOEPyTaYHaPTTbP = 0.0;
		}

		public void vAebzPiatqXizIEHPwzTibsOBjbo(float P_0)
		{
			ptfqbyHFBYgLFLpYGeSoJMycSVLgA = P_0;
		}

		public wfWInpiEUTRKKVPXxiEKMvFjofdfb aNFEWeQpUCcjDvglhFyJeUanYadF()
		{
			return (wfWInpiEUTRKKVPXxiEKMvFjofdfb)MemberwiseClone();
		}
	}

	public class EdAdrvqVjdvmYwSrfMeUtepFgJWn : IDisposable
	{
		public readonly ZjJDogCKWncTkpnbZlYHYUxqpNNOA oBzNpRuvBnfNMUuIdImMpXSxHOTj;

		private readonly Controller.Extension cIBHtsAGdXGAYkpUdLuDahpfbmjuB;

		public RDPIvgZmETOFlXaaJChnAXLAtWjJ IxxpGBrWkathxXkzNZivlwkpmdmR;

		private bool eHcmZiulkeEQxplybojItTlJgbFx;

		private readonly ButtonLoopSet PxWCdZBOuuUZLrzXRXMgfdtPQEKj;

		private RDPIvgZmETOFlXaaJChnAXLAtWjJ LxsslOhkrmZJJubJsOIqqHvuDEGDA;

		private bool NxvORUbwflwwpWcIJhFBNAKnzcAP;

		private DualThreadLowLevelInputEventQueue kYLfrkKZNqcwvVizDEnhveRgAmNjb;

		private readonly object IbCaWiOATCQsYbvcKfLaUWBPNJex;

		private RingBuffer<seSCKmPhVOaOdbrRYdsdcvubRfnXA> BcPFKmcJuRKfglGvBuOEjkluiOdM = new RingBuffer<seSCKmPhVOaOdbrRYdsdcvubRfnXA>(5);

		private RingBuffer<seSCKmPhVOaOdbrRYdsdcvubRfnXA> nxQYfvSgCdZoSCnfbfMieTdFcOZo = new RingBuffer<seSCKmPhVOaOdbrRYdsdcvubRfnXA>(5);

		private readonly object bmVYQibxuYhDZTMvKcCLEtJphOiu = new object();

		private readonly object MIwcOLDldlIPNQVLoqVzHKzrAlKf = new object();

		private seSCKmPhVOaOdbrRYdsdcvubRfnXA aZCizEsiyAReUrOYtVyEWbiqAAuw;

		private double sXSaQqhTxqiVRrmUomKOqyocvhPkA;

		private bool TEdZYYGmfGsrdZKjZoaNcPeazUsH;

		public Controller.Extension LulfleeqSRYIlhoLpMcHpKsdJaNu => cIBHtsAGdXGAYkpUdLuDahpfbmjuB;

		public bool[] CoJgtwHPqHwMvOlSRrrfRzvuJvKX => PxWCdZBOuuUZLrzXRXMgfdtPQEKj.Current.effectiveValue;

		public EdAdrvqVjdvmYwSrfMeUtepFgJWn(int P_0, UpdateLoopSetting P_1)
		{
			oBzNpRuvBnfNMUuIdImMpXSxHOTj = new ZjJDogCKWncTkpnbZlYHYUxqpNNOA((pVTRRmhnSXqCYnQKulaDVEIsFFHF)P_0);
			PxWCdZBOuuUZLrzXRXMgfdtPQEKj = new ButtonLoopSet(P_1, 15);
			IbCaWiOATCQsYbvcKfLaUWBPNJex = new object();
			kYLfrkKZNqcwvVizDEnhveRgAmNjb = new DualThreadLowLevelInputEventQueue((int)((float)VpydvvgAmkTUcjFPOCjeqVyqydEE.FouUkwuOnOhmqjkVSnyhOgtAiHCbA * 0.25f), 15, 6, 0);
			cIBHtsAGdXGAYkpUdLuDahpfbmjuB = new XInputControllerExtension(this);
		}

		public void onsZbFdAbjbPxJHUygwagWqlyvfoA()
		{
			PxWCdZBOuuUZLrzXRXMgfdtPQEKj.SetUpdateLoop(ReInput.currentUpdateLoop);
			RXLkPzFlMDnndwVsUfybweVPhcLA(ref IxxpGBrWkathxXkzNZivlwkpmdmR);
		}

		public void FqnrPSKbqCgfbHwtOAsOZGbCtnQBA()
		{
			eeeVSrGfgwQmgKvLbzSuQdHBpyah();
			PxWCdZBOuuUZLrzXRXMgfdtPQEKj.Current.ClearWasTrueThisFrame();
		}

		public void sNQcpKdteCQptbKwgQbbGbZmeGDLb()
		{
			aMrtwMjdQQajFlSxFFXSOwSGcKeJA();
			eHcmZiulkeEQxplybojItTlJgbFx = true;
			NxvORUbwflwwpWcIJhFBNAKnzcAP = oBzNpRuvBnfNMUuIdImMpXSxHOTj.drpHxmfYOORbPSLATqPSCtCmRpSA;
		}

		public void WxQkoTVtksqSSgqPUlHiJJMynIx()
		{
			eHcmZiulkeEQxplybojItTlJgbFx = false;
			NxvORUbwflwwpWcIJhFBNAKnzcAP = false;
			aMrtwMjdQQajFlSxFFXSOwSGcKeJA();
		}

		public bool BLTOJyWbycAQqiLEcQYXmnJkuEwGA(FyNifoPLIjINdzHQISzaijMlhBfF P_0)
		{
			return P_0 switch
			{
				FyNifoPLIjINdzHQISzaijMlhBfF.Synchronous => NxvORUbwflwwpWcIJhFBNAKnzcAP = oBzNpRuvBnfNMUuIdImMpXSxHOTj.drpHxmfYOORbPSLATqPSCtCmRpSA, 
				FyNifoPLIjINdzHQISzaijMlhBfF.Asynchronous => NxvORUbwflwwpWcIJhFBNAKnzcAP, 
				_ => throw new NotImplementedException(), 
			};
		}

		public void fvYoCLATSCoVBXpvlXBrdrXQsJrI(float P_0, int P_1)
		{
			switch (P_1)
			{
			case 0:
				aZCizEsiyAReUrOYtVyEWbiqAAuw.qEMPUGAVlexpkyfczHctHmTSEBcBA = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			case 1:
				aZCizEsiyAReUrOYtVyEWbiqAAuw.fmgMOAAjzomtgSpNZwLyktFapOtC = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			}
			SHjJBoccWCSRgWXHlkpdigOfpUHi();
		}

		public void dRqHnmxCGlgxQlvAvmIkPEaaDYSR()
		{
			aZCizEsiyAReUrOYtVyEWbiqAAuw.qEMPUGAVlexpkyfczHctHmTSEBcBA = 0;
			aZCizEsiyAReUrOYtVyEWbiqAAuw.fmgMOAAjzomtgSpNZwLyktFapOtC = 0;
			SHjJBoccWCSRgWXHlkpdigOfpUHi();
		}

		public void mFnHcTeYBJAcDDmaHWuwYzhemyslA()
		{
			aZCizEsiyAReUrOYtVyEWbiqAAuw.qEMPUGAVlexpkyfczHctHmTSEBcBA = 0;
			aZCizEsiyAReUrOYtVyEWbiqAAuw.fmgMOAAjzomtgSpNZwLyktFapOtC = 0;
			lock (MIwcOLDldlIPNQVLoqVzHKzrAlKf)
			{
				lock (bmVYQibxuYhDZTMvKcCLEtJphOiu)
				{
					BcPFKmcJuRKfglGvBuOEjkluiOdM.Clear();
					nxQYfvSgCdZoSCnfbfMieTdFcOZo.Clear();
					NoKEcSFPWlIaMAdaFxEMbTwGgfIBe(oBzNpRuvBnfNMUuIdImMpXSxHOTj, aZCizEsiyAReUrOYtVyEWbiqAAuw, ref sXSaQqhTxqiVRrmUomKOqyocvhPkA);
				}
			}
		}

		public void tboXYQBhFvPBAwBUmnyKJGwLjpVh()
		{
			if (!eHcmZiulkeEQxplybojItTlJgbFx || !NxvORUbwflwwpWcIJhFBNAKnzcAP)
			{
				return;
			}
			fcgaDiUuQjslatnxWTYHEvWxgQbd fcgaDiUuQjslatnxWTYHEvWxgQbd2;
			double realTime;
			try
			{
				if (!oBzNpRuvBnfNMUuIdImMpXSxHOTj.xsInjvhPxJcswGrWUOlYpKPZIsZI(out fcgaDiUuQjslatnxWTYHEvWxgQbd2))
				{
					NxvORUbwflwwpWcIJhFBNAKnzcAP = false;
					return;
				}
				realTime = ReInput.realTime;
			}
			catch
			{
				NxvORUbwflwwpWcIJhFBNAKnzcAP = false;
				return;
			}
			lock (IbCaWiOATCQsYbvcKfLaUWBPNJex)
			{
				if (!JIsSJBlEkMpqeiAMoDVxObCDirSx(fcgaDiUuQjslatnxWTYHEvWxgQbd2.PEYgaXyYrwMEKmyJemHisWVsQplp, LxsslOhkrmZJJubJsOIqqHvuDEGDA))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = kYLfrkKZNqcwvVizDEnhveRgAmNjb.T_CreateEvent())
					{
						vbpgJVcwCtfZhRLufgpvbUtAnKiWB(ref fcgaDiUuQjslatnxWTYHEvWxgQbd2.PEYgaXyYrwMEKmyJemHisWVsQplp, realTime, newEventWrapper.Event);
					}
					LxsslOhkrmZJJubJsOIqqHvuDEGDA = fcgaDiUuQjslatnxWTYHEvWxgQbd2.PEYgaXyYrwMEKmyJemHisWVsQplp;
				}
			}
		}

		public void fjoQqDOtCUAqmdJgNeGhGRwBPyRo()
		{
			if (!eHcmZiulkeEQxplybojItTlJgbFx || !NxvORUbwflwwpWcIJhFBNAKnzcAP || ReInput.realTime < sXSaQqhTxqiVRrmUomKOqyocvhPkA + 0.009999999776482582)
			{
				return;
			}
			lock (MIwcOLDldlIPNQVLoqVzHKzrAlKf)
			{
				lock (bmVYQibxuYhDZTMvKcCLEtJphOiu)
				{
					MiscTools.Swap(ref BcPFKmcJuRKfglGvBuOEjkluiOdM, ref nxQYfvSgCdZoSCnfbfMieTdFcOZo);
				}
				pFwFLbgbAcNtQSaPzfPTEVRdGpRg(nxQYfvSgCdZoSCnfbfMieTdFcOZo, oBzNpRuvBnfNMUuIdImMpXSxHOTj, ref sXSaQqhTxqiVRrmUomKOqyocvhPkA);
			}
		}

		private void eeeVSrGfgwQmgKvLbzSuQdHBpyah()
		{
			jwptSkTSPyOrPSCIBJJzfZntxbNNA();
		}

		private void jwptSkTSPyOrPSCIBJJzfZntxbNNA()
		{
			if (!(ReInput.realTime < sXSaQqhTxqiVRrmUomKOqyocvhPkA + 1.5) && (!Mathf.Approximately((int)aZCizEsiyAReUrOYtVyEWbiqAAuw.qEMPUGAVlexpkyfczHctHmTSEBcBA, 0f) || !Mathf.Approximately((int)aZCizEsiyAReUrOYtVyEWbiqAAuw.fmgMOAAjzomtgSpNZwLyktFapOtC, 0f)))
			{
				SHjJBoccWCSRgWXHlkpdigOfpUHi();
			}
		}

		private void SHjJBoccWCSRgWXHlkpdigOfpUHi()
		{
			lock (bmVYQibxuYhDZTMvKcCLEtJphOiu)
			{
				BcPFKmcJuRKfglGvBuOEjkluiOdM.Enqueue(aZCizEsiyAReUrOYtVyEWbiqAAuw);
			}
		}

		private static void pFwFLbgbAcNtQSaPzfPTEVRdGpRg(RingBuffer<seSCKmPhVOaOdbrRYdsdcvubRfnXA> P_0, ZjJDogCKWncTkpnbZlYHYUxqpNNOA P_1, ref double P_2)
		{
			if (P_0.Count > 0)
			{
				NoKEcSFPWlIaMAdaFxEMbTwGgfIBe(P_1, P_0[P_0.Count - 1], ref P_2);
				P_0.Clear();
			}
		}

		private static void NoKEcSFPWlIaMAdaFxEMbTwGgfIBe(ZjJDogCKWncTkpnbZlYHYUxqpNNOA P_0, seSCKmPhVOaOdbrRYdsdcvubRfnXA P_1, ref double P_2)
		{
			try
			{
				P_0.gfdfyICEFaRKbuhXhTYckHdQmvicA(P_1);
			}
			catch
			{
			}
			P_2 = ReInput.realTime;
		}

		private void RXLkPzFlMDnndwVsUfybweVPhcLA(ref RDPIvgZmETOFlXaaJChnAXLAtWjJ P_0)
		{
			while (kYLfrkKZNqcwvVizDEnhveRgAmNjb.ProcessNewEvents())
			{
				huABmJNLTGRPHjLUTrtPrIUBhhgcA(ref P_0, ref kYLfrkKZNqcwvVizDEnhveRgAmNjb.currentEvent);
				for (int i = 0; i < 15; i++)
				{
					PxWCdZBOuuUZLrzXRXMgfdtPQEKj.SetValue(i, buqAFEAfpuQlDqYhHFHshPDKOfUp((int)P_0.AyGIRFakIqkiTfAtRaoakETIjpoY, i), kYLfrkKZNqcwvVizDEnhveRgAmNjb.currentEvent.GetTimestamp());
				}
			}
		}

		private void vbpgJVcwCtfZhRLufgpvbUtAnKiWB(ref RDPIvgZmETOFlXaaJChnAXLAtWjJ P_0, double P_1, LowLevelInputEvent P_2)
		{
			P_2.SetTimestamp(P_1);
			int ayGIRFakIqkiTfAtRaoakETIjpoY = (int)P_0.AyGIRFakIqkiTfAtRaoakETIjpoY;
			P_2.SetButtonsBitMask((ayGIRFakIqkiTfAtRaoakETIjpoY & 0x7FF) | ((ayGIRFakIqkiTfAtRaoakETIjpoY & (ayGIRFakIqkiTfAtRaoakETIjpoY & -4096)) >> 1), 0);
			P_2.SetAxisValue(0, ZvNqppOFFTWNQcLxFcXDKXcBdsVg(P_0.mkAFymYTAqRAHvKZVgNgwDKMbcpK));
			P_2.SetAxisValue(1, ZvNqppOFFTWNQcLxFcXDKXcBdsVg(P_0.ZUXoSqUhLyjQUUfujcVtJwyntyOe));
			P_2.SetAxisValue(2, ZvNqppOFFTWNQcLxFcXDKXcBdsVg(P_0.emVGlEYuIVcugQBFZmjrdenVSrdD));
			P_2.SetAxisValue(3, ZvNqppOFFTWNQcLxFcXDKXcBdsVg(P_0.OAYaUkixWLlzyrSdfZYzqnxsmCywA));
			P_2.SetAxisValue(4, qBRBDgRJkUynPRKsTLaZthzPgAJG(P_0.eUmeuQACKlQrHjdyiAvcFgThIACB));
			P_2.SetAxisValue(5, qBRBDgRJkUynPRKsTLaZthzPgAJG(P_0.dGLyUzQfbaglrFpfdrKFeEzCimJE));
		}

		private void huABmJNLTGRPHjLUTrtPrIUBhhgcA(ref RDPIvgZmETOFlXaaJChnAXLAtWjJ P_0, ref LowLevelInputEvent P_1)
		{
			int buttonsBitMask = P_1.GetButtonsBitMask(0);
			P_0.AyGIRFakIqkiTfAtRaoakETIjpoY = (GQVACDzpkPSjXlWGzWlDmraMJAsV)((buttonsBitMask & 0x7FF) | ((buttonsBitMask & (buttonsBitMask & -2048)) << 1));
			P_0.mkAFymYTAqRAHvKZVgNgwDKMbcpK = (short)(P_1.GetAxisValue(0) * 32768f);
			P_0.ZUXoSqUhLyjQUUfujcVtJwyntyOe = (short)(P_1.GetAxisValue(1) * 32768f);
			P_0.emVGlEYuIVcugQBFZmjrdenVSrdD = (short)(P_1.GetAxisValue(2) * 32768f);
			P_0.OAYaUkixWLlzyrSdfZYzqnxsmCywA = (short)(P_1.GetAxisValue(3) * 32768f);
			P_0.eUmeuQACKlQrHjdyiAvcFgThIACB = (byte)(P_1.GetAxisValue(4) * 255f);
			P_0.dGLyUzQfbaglrFpfdrKFeEzCimJE = (byte)(P_1.GetAxisValue(5) * 255f);
		}

		private static bool buqAFEAfpuQlDqYhHFHshPDKOfUp(int P_0, int P_1)
		{
			if (P_1 > 10)
			{
				P_1++;
			}
			return (P_0 & (1 << P_1)) != 0;
		}

		private void aMrtwMjdQQajFlSxFFXSOwSGcKeJA()
		{
			lock (IbCaWiOATCQsYbvcKfLaUWBPNJex)
			{
				IxxpGBrWkathxXkzNZivlwkpmdmR = default(RDPIvgZmETOFlXaaJChnAXLAtWjJ);
				LxsslOhkrmZJJubJsOIqqHvuDEGDA = default(RDPIvgZmETOFlXaaJChnAXLAtWjJ);
				PxWCdZBOuuUZLrzXRXMgfdtPQEKj.Clear();
				kYLfrkKZNqcwvVizDEnhveRgAmNjb.Clear();
			}
		}

		public void Dispose()
		{
			LAtHpjBMySIleYcQAYCOLeFsLuCO(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void sqzArhYMlPQMcDnndlDpBsJMIMJW()
		{
			try
			{
				LAtHpjBMySIleYcQAYCOLeFsLuCO(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void LAtHpjBMySIleYcQAYCOLeFsLuCO(bool P_0)
		{
			if (!TEdZYYGmfGsrdZKjZoaNcPeazUsH)
			{
				if (P_0)
				{
					kYLfrkKZNqcwvVizDEnhveRgAmNjb.Dispose();
				}
				TEdZYYGmfGsrdZKjZoaNcPeazUsH = true;
			}
		}

		public static float ZvNqppOFFTWNQcLxFcXDKXcBdsVg(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 32768f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		public static float qBRBDgRJkUynPRKsTLaZthzPgAJG(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 255f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private static bool JIsSJBlEkMpqeiAMoDVxObCDirSx(RDPIvgZmETOFlXaaJChnAXLAtWjJ P_0, RDPIvgZmETOFlXaaJChnAXLAtWjJ P_1)
		{
			if (P_0.AyGIRFakIqkiTfAtRaoakETIjpoY == P_1.AyGIRFakIqkiTfAtRaoakETIjpoY && P_0.eUmeuQACKlQrHjdyiAvcFgThIACB == P_1.eUmeuQACKlQrHjdyiAvcFgThIACB && P_0.dGLyUzQfbaglrFpfdrKFeEzCimJE == P_1.dGLyUzQfbaglrFpfdrKFeEzCimJE && P_0.mkAFymYTAqRAHvKZVgNgwDKMbcpK == P_1.mkAFymYTAqRAHvKZVgNgwDKMbcpK && P_0.ZUXoSqUhLyjQUUfujcVtJwyntyOe == P_1.ZUXoSqUhLyjQUUfujcVtJwyntyOe && P_0.emVGlEYuIVcugQBFZmjrdenVSrdD == P_1.emVGlEYuIVcugQBFZmjrdenVSrdD)
			{
				return P_0.OAYaUkixWLlzyrSdfZYzqnxsmCywA == P_1.OAYaUkixWLlzyrSdfZYzqnxsmCywA;
			}
			return false;
		}
	}

	public enum FyNifoPLIjINdzHQISzaijMlhBfF
	{
		Synchronous = 0,
		Asynchronous = 1
	}

	public const int GndCEvfsudEORmbNyVwgcnukyAde = 4;

	public const int orhcbiApYkYfSckYYtezpiqCkFQZA = 32768;

	public const int kHTBPAebmNWgKnjxOCDWLePUNTOD = -32768;

	public const int nNfoGonBtqNiaoQWyYDWzOglbDvFA = 255;

	public const int AtQNrSebHdwAbCpBNarJFgVxAeNXA = 0;

	public const int leSJZVYykIRTZbgZuQDenZpTfpmA = 18;

	public const int mvbstzsCTYOKIOmGHhbPUVIaJIPH = 14;

	public const int bswfMcKrtFQvUEJiMXyiFQQCaWUH = 6;

	public const int QoPcsCeeWRkQtUcnlyVGtmwtjPdfb = 15;

	private KeZhSdfkYmGguaxwpyFcSLwyOiiG[] nXCESACPpSOmOaFmoNKzLCssfqiCb;

	private bool iTbIxJwJYAdgHhvVnhXTrEFNjqEW;

	private wfWInpiEUTRKKVPXxiEKMvFjofdfb QMYvkzkkbnCSYimbIUSOJROhzZCT;

	private UeSlEvHuiHLmzJTHgLpGYlDhZBnd kvFvvHldTxvPERnzhTUhUiOGLYyj;

	private global::qNmehkleTfcBTeRaeVPEWTMAtwnsA<bool> sUswEpJlIJIFhbBPuCxWZnZEoCWl;

	private bool[] CNKAFodIOlfqpsOXimgAKfPZScOM;

	private bool[] OAMjiGOwsBaGBkVKWkynhEXUilWo;

	private bool kouSuWdzyWhLHYLtZdFysWfyKHdo;

	private readonly bool nGrbStItIpbxcDezdCoizoEoFladc;

	private readonly UpdateLoopSetting GupFIkGNnUZlpMaqMFGHeNssiIYiA;

	private UpdateLoopType cmJdRJJzsudLVIMZfrrSRpNjJMJV;

	private UpdateLoopType vyRhFaJVShjmGkfmWTkNIydHZULE;

	private Action<int, ControllerDataUpdater> arWTQIbOLCdrqhrLteeuMnbqmwRlA;

	private bool DtTqCwpIGbsbfwMhxDGNTzpKaQbq;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> jyZTrXvJMKnwQYEYYzwUSWlpoPUA;

	private Func<int> QwjHcfpbTYJIiywiRJsNueXSASbG;

	private Func<PidVid, bool> LSuXInrhABvkfziklcIcCbWKLoHO;

	private static Guid[] NQwMzHgYqYimGnOknlaCXjRsXxIf;

	private static string[] ZTMtsyUxDhIRiJPAwFMEvradqeLp;

	private static string[] KGnBtRuBwCaPpBWrNLlOilojMEQeA;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				if (nXCESACPpSOmOaFmoNKzLCssfqiCb[i].rDoLcGInZokeprIbBJZTqLGiuqGg)
				{
					num++;
				}
			}
			return num;
		}
	}

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => this;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => null;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.XInput;

	tlpaVkWHWgDxCHYLZUjdpPaUJdWMA NmANKYQYjJJatXyTLQutNfBhTrds.tbuITOFCrXgnJEyCfUTBdRCCXdGBE => tlpaVkWHWgDxCHYLZUjdpPaUJdWMA.XInput;

	public BdmVZBfayIRaEoZyauttTYQvabrH(bool P_0, UpdateLoopSetting P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3, Func<PidVid, bool> P_4)
	{
		nGrbStItIpbxcDezdCoizoEoFladc = P_0;
		GupFIkGNnUZlpMaqMFGHeNssiIYiA = P_1;
		LSuXInrhABvkfziklcIcCbWKLoHO = P_4;
		DtTqCwpIGbsbfwMhxDGNTzpKaQbq = true;
		try
		{
			if (!iolROZkhgUsqlGCDPnonhVToqats.puOUCsmcjVyUeYbAWfEqcDVTXXkO(out var oDtYYlLJTqHqVwpPAdrQUZZNofoG2, out var text, out var _))
			{
				throw new Exception("XInput is not available.");
			}
			if (oDtYYlLJTqHqVwpPAdrQUZZNofoG2 < oDtYYlLJTqHqVwpPAdrQUZZNofoG.XINPUT_1_3)
			{
				Rewired.Logger.LogWarning("The version of XInput (" + text + ") detected on your system is out of date. Please update to the latest version of XInput. Input will still function, but all features may not be available. See the documentation for required dependencies.");
			}
			else
			{
				_ = 4;
			}
			jyZTrXvJMKnwQYEYYzwUSWlpoPUA = P_2;
			QwjHcfpbTYJIiywiRJsNueXSASbG = P_3;
			kouSuWdzyWhLHYLtZdFysWfyKHdo = UnityTools.platform == Platform.WindowsAppStore;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(GupFIkGNnUZlpMaqMFGHeNssiIYiA, list);
				vyRhFaJVShjmGkfmWTkNIydHZULE = list[0];
			}
			sUswEpJlIJIFhbBPuCxWZnZEoCWl = new global::qNmehkleTfcBTeRaeVPEWTMAtwnsA<bool>(true, xCwjlFCAszeqjlKceONAJAPTetgxA);
			CNKAFodIOlfqpsOXimgAKfPZScOM = new bool[4];
			OAMjiGOwsBaGBkVKWkynhEXUilWo = new bool[4];
			arWTQIbOLCdrqhrLteeuMnbqmwRlA = UpdateControllerData;
			if (kouSuWdzyWhLHYLtZdFysWfyKHdo)
			{
				NpHBLlAubtvQuSckJWGsqHuCDycU();
			}
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
		if (DtTqCwpIGbsbfwMhxDGNTzpKaQbq)
		{
			QMYvkzkkbnCSYimbIUSOJROhzZCT = new wfWInpiEUTRKKVPXxiEKMvFjofdfb(1f);
		}
		kvFvvHldTxvPERnzhTUhUiOGLYyj = new UeSlEvHuiHLmzJTHgLpGYlDhZBnd();
		if (nXCESACPpSOmOaFmoNKzLCssfqiCb == null)
		{
			nXCESACPpSOmOaFmoNKzLCssfqiCb = new KeZhSdfkYmGguaxwpyFcSLwyOiiG[4];
			for (int i = 0; i < 4; i++)
			{
				EdAdrvqVjdvmYwSrfMeUtepFgJWn edAdrvqVjdvmYwSrfMeUtepFgJWn = new EdAdrvqVjdvmYwSrfMeUtepFgJWn(i, GupFIkGNnUZlpMaqMFGHeNssiIYiA);
				VpydvvgAmkTUcjFPOCjeqVyqydEE.hnQVuLpGsuJSzHbTZzTrIVUjPmfM.ThreadUpdateEvent += edAdrvqVjdvmYwSrfMeUtepFgJWn.tboXYQBhFvPBAwBUmnyKJGwLjpVh;
				VpydvvgAmkTUcjFPOCjeqVyqydEE.ehOnSWgRdmIwRYhdEneGjxefKKyo.ThreadUpdateEvent += edAdrvqVjdvmYwSrfMeUtepFgJWn.fjoQqDOtCUAqmdJgNeGhGRwBPyRo;
				nXCESACPpSOmOaFmoNKzLCssfqiCb[i] = new KeZhSdfkYmGguaxwpyFcSLwyOiiG(i, kouSuWdzyWhLHYLtZdFysWfyKHdo, edAdrvqVjdvmYwSrfMeUtepFgJWn, jyZTrXvJMKnwQYEYYzwUSWlpoPUA, SystemDeviceDisconnected);
			}
		}
		JHZBdHyTsiZZxJNrtXVGzHJSKdeS(true);
		Update(UpdateLoopType.Update);
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType currentUpdateLoop)
	{
		cmJdRJJzsudLVIMZfrrSRpNjJMJV = currentUpdateLoop;
		KjzDfHgqbICtlkEmxFisVsEVelSsA();
		for (int i = 0; i < 4; i++)
		{
			if (nXCESACPpSOmOaFmoNKzLCssfqiCb[i] != null && nXCESACPpSOmOaFmoNKzLCssfqiCb[i].rDoLcGInZokeprIbBJZTqLGiuqGg)
			{
				nXCESACPpSOmOaFmoNKzLCssfqiCb[i].Update();
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (sUswEpJlIJIFhbBPuCxWZnZEoCWl != null)
		{
			sUswEpJlIJIFhbBPuCxWZnZEoCWl.INBczqSosoXHntgpZStpJliJdQBM();
		}
		if (nXCESACPpSOmOaFmoNKzLCssfqiCb != null)
		{
			for (int i = 0; i < 4; i++)
			{
				if (nXCESACPpSOmOaFmoNKzLCssfqiCb[i] != null)
				{
					if (VpydvvgAmkTUcjFPOCjeqVyqydEE.hnQVuLpGsuJSzHbTZzTrIVUjPmfM != null)
					{
						VpydvvgAmkTUcjFPOCjeqVyqydEE.hnQVuLpGsuJSzHbTZzTrIVUjPmfM.ThreadUpdateEvent -= nXCESACPpSOmOaFmoNKzLCssfqiCb[i].GFvNQcsBufIrzKhYgmzqTDHdCRvkA.tboXYQBhFvPBAwBUmnyKJGwLjpVh;
					}
					if (VpydvvgAmkTUcjFPOCjeqVyqydEE.ehOnSWgRdmIwRYhdEneGjxefKKyo != null)
					{
						VpydvvgAmkTUcjFPOCjeqVyqydEE.ehOnSWgRdmIwRYhdEneGjxefKKyo.ThreadUpdateEvent -= nXCESACPpSOmOaFmoNKzLCssfqiCb[i].GFvNQcsBufIrzKhYgmzqTDHdCRvkA.fjoQqDOtCUAqmdJgNeGhGRwBPyRo;
					}
					nXCESACPpSOmOaFmoNKzLCssfqiCb[i].Dispose();
				}
			}
		}
		iolROZkhgUsqlGCDPnonhVToqats.cIGGFwXWVbjnYUmYkCvXENdkfGOib();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return arWTQIbOLCdrqhrLteeuMnbqmwRlA;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		nXCESACPpSOmOaFmoNKzLCssfqiCb[assignedControllerId].FillData(data);
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		JHZBdHyTsiZZxJNrtXVGzHJSKdeS(true);
		FubNISuNSNytsXrhruIJyZpMhmSM();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		JHZBdHyTsiZZxJNrtXVGzHJSKdeS(true);
		FubNISuNSNytsXrhruIJyZpMhmSM();
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

	bool NmANKYQYjJJatXyTLQutNfBhTrds.MT_HandlesController(string devicePath, string productName, string bluetoothName, PidVid pidVid)
	{
		if (LSuXInrhABvkfziklcIcCbWKLoHO(pidVid))
		{
			return false;
		}
		return ZNjbvKaYNFQZlcJAGAEfyBlelTBt(devicePath, productName, bluetoothName, MiscTools.CreateHIDProductGuid(pidVid.vendorId, pidVid.productId));
	}

	private bool zCFZZnpglcxRNYpQysTkKEDDFmedA()
	{
		if (cmJdRJJzsudLVIMZfrrSRpNjJMJV != vyRhFaJVShjmGkfmWTkNIydHZULE)
		{
			return false;
		}
		bool num = QMYvkzkkbnCSYimbIUSOJROhzZCT.EPEHVRVojyCdyIyETkiGJbAtVyINA();
		if (num)
		{
			JHZBdHyTsiZZxJNrtXVGzHJSKdeS(true);
		}
		return num;
	}

	private void JHZBdHyTsiZZxJNrtXVGzHJSKdeS(bool P_0)
	{
		iTbIxJwJYAdgHhvVnhXTrEFNjqEW = P_0;
		if (DtTqCwpIGbsbfwMhxDGNTzpKaQbq)
		{
			QMYvkzkkbnCSYimbIUSOJROhzZCT.bAkbEeGhGZLmAJKLDNMZIzvvNvsbB();
		}
	}

	private void FubNISuNSNytsXrhruIJyZpMhmSM()
	{
		if (sUswEpJlIJIFhbBPuCxWZnZEoCWl != null)
		{
			sUswEpJlIJIFhbBPuCxWZnZEoCWl.BkqktNKahOeytCbRroMuYcZtGFWK();
		}
	}

	private void NpHBLlAubtvQuSckJWGsqHuCDycU()
	{
		_ = new ZjJDogCKWncTkpnbZlYHYUxqpNNOA().drpHxmfYOORbPSLATqPSCtCmRpSA;
	}

	private void KjzDfHgqbICtlkEmxFisVsEVelSsA()
	{
		bool flag = false;
		if (DtTqCwpIGbsbfwMhxDGNTzpKaQbq)
		{
			flag = zCFZZnpglcxRNYpQysTkKEDDFmedA();
		}
		if (!flag && iTbIxJwJYAdgHhvVnhXTrEFNjqEW)
		{
			OKpwFLvjaykWJgmUkUVWdABseVxI(GJWLrGrEPCARqfJVmgIEBuxWcFBTA());
			JHZBdHyTsiZZxJNrtXVGzHJSKdeS(false);
			FubNISuNSNytsXrhruIJyZpMhmSM();
			return;
		}
		if (iTbIxJwJYAdgHhvVnhXTrEFNjqEW)
		{
			feIWxVidnrjAtfVJSKEUnofoASaJA();
		}
		if (sUswEpJlIJIFhbBPuCxWZnZEoCWl.TPoeWwEYcJhWohaeHjOgcVjxblcSA && sUswEpJlIJIFhbBPuCxWZnZEoCWl.VWKJlWBJsiHHmQEXkCqAcjYYeDisA())
		{
			fSivAtXvLBZqAKYaXFviikpPTmmh();
		}
	}

	private void feIWxVidnrjAtfVJSKEUnofoASaJA()
	{
		iTbIxJwJYAdgHhvVnhXTrEFNjqEW = false;
		if (!sUswEpJlIJIFhbBPuCxWZnZEoCWl.TPoeWwEYcJhWohaeHjOgcVjxblcSA)
		{
			sUswEpJlIJIFhbBPuCxWZnZEoCWl.tGmkFOBGLIStwNoiokXgtfxSMCi();
		}
	}

	private void fSivAtXvLBZqAKYaXFviikpPTmmh()
	{
		lock (CNKAFodIOlfqpsOXimgAKfPZScOM)
		{
			Array.Copy(CNKAFodIOlfqpsOXimgAKfPZScOM, OAMjiGOwsBaGBkVKWkynhEXUilWo, 4);
		}
		OKpwFLvjaykWJgmUkUVWdABseVxI(OAMjiGOwsBaGBkVKWkynhEXUilWo);
	}

	private bool xCwjlFCAszeqjlKceONAJAPTetgxA()
	{
		lock (CNKAFodIOlfqpsOXimgAKfPZScOM)
		{
			for (int i = 0; i < 4; i++)
			{
				if (nXCESACPpSOmOaFmoNKzLCssfqiCb[i] != null)
				{
					CNKAFodIOlfqpsOXimgAKfPZScOM[i] = nXCESACPpSOmOaFmoNKzLCssfqiCb[i].AwTnTKPTyjNFLzIOZKzUrdOXcQADA(FyNifoPLIjINdzHQISzaijMlhBfF.Synchronous);
				}
			}
		}
		return true;
	}

	private bool[] GJWLrGrEPCARqfJVmgIEBuxWcFBTA()
	{
		for (int i = 0; i < 4; i++)
		{
			OAMjiGOwsBaGBkVKWkynhEXUilWo[i] = nXCESACPpSOmOaFmoNKzLCssfqiCb[i].AwTnTKPTyjNFLzIOZKzUrdOXcQADA(FyNifoPLIjINdzHQISzaijMlhBfF.Synchronous);
		}
		return OAMjiGOwsBaGBkVKWkynhEXUilWo;
	}

	private void OKpwFLvjaykWJgmUkUVWdABseVxI(bool[] P_0)
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (nXCESACPpSOmOaFmoNKzLCssfqiCb[i] != null && nXCESACPpSOmOaFmoNKzLCssfqiCb[i].IjniXuQUcfgfpioXCKyVhKyjuGjf)
			{
				bool flag = P_0[i];
				nXCESACPpSOmOaFmoNKzLCssfqiCb[i].CKBklJbOYHQqXjBLQpWNINhkiIj(flag);
				if (!flag)
				{
					aVhiPiNHnegcflRWMtCvFLLDNVx(nXCESACPpSOmOaFmoNKzLCssfqiCb[i], false);
				}
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (nXCESACPpSOmOaFmoNKzLCssfqiCb[j] != null && !nXCESACPpSOmOaFmoNKzLCssfqiCb[j].IjniXuQUcfgfpioXCKyVhKyjuGjf)
			{
				bool flag2 = P_0[j];
				nXCESACPpSOmOaFmoNKzLCssfqiCb[j].CKBklJbOYHQqXjBLQpWNINhkiIj(flag2);
				if (flag2 && !aVhiPiNHnegcflRWMtCvFLLDNVx(nXCESACPpSOmOaFmoNKzLCssfqiCb[j], true))
				{
					num |= ((j == 0) ? 1 : (1 << j));
				}
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (nXCESACPpSOmOaFmoNKzLCssfqiCb[k] != null)
			{
				int num2 = ((k == 0) ? 1 : (1 << k));
				if ((num & num2) != 1 << k)
				{
					nXCESACPpSOmOaFmoNKzLCssfqiCb[k].QMJaIzaiIqOzjqbxjSJwisfFJaKCb(P_0[k]);
				}
			}
		}
	}

	private bool aVhiPiNHnegcflRWMtCvFLLDNVx(KeZhSdfkYmGguaxwpyFcSLwyOiiG P_0, bool P_1)
	{
		if (P_1)
		{
			P_0.ZpMkwJepKfmLUnNriuCcHzEHJark();
			if (!P_0.WNdtKVAWQInvmYKcklozwNTjcsVHA)
			{
				return false;
			}
			int num = kvFvvHldTxvPERnzhTUhUiOGLYyj.SrxtiMpjNGBTJfRpVAcCNpgwPqqLA(P_0.rISmKGdgJSkRiBrydmAxedQDCsWAA, false);
			if (num >= 0)
			{
				P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = kvFvvHldTxvPERnzhTUhUiOGLYyj.CFAclxaspILpJniHEuVmczmKfIAn(num);
				kvFvvHldTxvPERnzhTUhUiOGLYyj.qLcNjSMuoOEwjtdsOouKoqxzdCSn(num, P_0, true);
			}
			else
			{
				P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = QwjHcfpbTYJIiywiRJsNueXSASbG();
				kvFvvHldTxvPERnzhTUhUiOGLYyj.xcFyewKhZjsLVqIPjtOoOgOjtRlw(P_0, true);
			}
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(P_0));
			}
			BridgedController obj = P_0.ToBridgedController();
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(obj);
			}
		}
		else
		{
			int num2 = kvFvvHldTxvPERnzhTUhUiOGLYyj.VNYEVBgctqnTjyIDUlfNNkvriitJA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.rISmKGdgJSkRiBrydmAxedQDCsWAA, true);
			if (num2 >= 0)
			{
				kvFvvHldTxvPERnzhTUhUiOGLYyj.JprHjdHwkBACWhjiuPdnAbMNGWPj(num2, false);
			}
			ControllerDisconnectedEventArgs obj2 = P_0.ToControllerDisconnectedEventArgs();
			P_0.EqwCQYzpYuZRymEzyjjDNeSkxDpL();
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(obj2);
			}
		}
		return true;
	}

	static BdmVZBfayIRaEoZyauttTYQvabrH()
	{
		NQwMzHgYqYimGnOknlaCXjRsXxIf = new Guid[2]
		{
			new Guid("72100955-0000-0000-0000-504944564944"),
			new Guid("02e0045e-0000-0000-0000-504944564944")
		};
		ZTMtsyUxDhIRiJPAwFMEvradqeLp = new string[1] { "Xbox Bluetooth Gamepad" };
		KGnBtRuBwCaPpBWrNLlOilojMEQeA = new string[1] { "Xbox Wireless Controller.*" };
	}

	public static bool ZNjbvKaYNFQZlcJAGAEfyBlelTBt(string P_0, string P_1, string P_2, Guid P_3)
	{
		if (ArrayTools.Contains(NQwMzHgYqYimGnOknlaCXjRsXxIf, P_3))
		{
			return true;
		}
		if (!string.IsNullOrEmpty(P_1))
		{
			for (int i = 0; i < ZTMtsyUxDhIRiJPAwFMEvradqeLp.Length; i++)
			{
				if (P_1.Equals(ZTMtsyUxDhIRiJPAwFMEvradqeLp[i], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
		}
		if (!string.IsNullOrEmpty(P_2))
		{
			for (int j = 0; j < KGnBtRuBwCaPpBWrNLlOilojMEQeA.Length; j++)
			{
				if (Regex.IsMatch(P_2, KGnBtRuBwCaPpBWrNLlOilojMEQeA[j], RegexOptions.IgnoreCase))
				{
					return true;
				}
			}
		}
		P_0 = P_0.ToLower();
		int num = P_0.IndexOf("vid_");
		if (num < 0)
		{
			return false;
		}
		if (P_0.IndexOf("ig_") < num)
		{
			return false;
		}
		return true;
	}
}
