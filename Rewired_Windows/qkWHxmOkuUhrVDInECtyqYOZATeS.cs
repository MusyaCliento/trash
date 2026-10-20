using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Platforms.UnityInputSystem;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Interfaces;

internal class qkWHxmOkuUhrVDInECtyqYOZATeS : PlatformInputManager, INativePlatformHelper
{
	private class hjOkpMNXCVOEXqiZESOyOmKfSfic
	{
		private class GniGuqsDUKdQbAbhIcCVRyyxyQIP
		{
			public int VgGSuTVdljhFErfqwUirwTSCYUQC;

			public int zphExlmahznMrgZdKVCCjpIpgiYr;

			public int UqYDqVFGoFKbizDoRSDeJvOCHpgBA;

			public InputSource dFiABpHtOdiMKQmQTAVJomjjccTCA;

			public GniGuqsDUKdQbAbhIcCVRyyxyQIP(int P_0, int P_1, int P_2, InputSource P_3)
			{
				VgGSuTVdljhFErfqwUirwTSCYUQC = P_0;
				zphExlmahznMrgZdKVCCjpIpgiYr = P_1;
				UqYDqVFGoFKbizDoRSDeJvOCHpgBA = P_2;
				dFiABpHtOdiMKQmQTAVJomjjccTCA = P_3;
			}

			public void CbtcCsDeezaFlhCHgCViuMDENwihB(int P_0)
			{
				zphExlmahznMrgZdKVCCjpIpgiYr = P_0;
			}

			public jGdBtjnfTyGBISVuamYbkGHgkejU BbNuIOtLoGbaWXFbKWrJCKezdraO()
			{
				return new jGdBtjnfTyGBISVuamYbkGHgkejU(VgGSuTVdljhFErfqwUirwTSCYUQC, zphExlmahznMrgZdKVCCjpIpgiYr, dFiABpHtOdiMKQmQTAVJomjjccTCA);
			}

			public static int mBfpILaVaSTUfRxZuMHlNsvosEdS(GniGuqsDUKdQbAbhIcCVRyyxyQIP P_0, GniGuqsDUKdQbAbhIcCVRyyxyQIP P_1)
			{
				if (P_0.VgGSuTVdljhFErfqwUirwTSCYUQC < P_1.VgGSuTVdljhFErfqwUirwTSCYUQC)
				{
					return -1;
				}
				if (P_0.VgGSuTVdljhFErfqwUirwTSCYUQC > P_1.VgGSuTVdljhFErfqwUirwTSCYUQC)
				{
					return 1;
				}
				return 0;
			}
		}

		public struct jGdBtjnfTyGBISVuamYbkGHgkejU
		{
			public int GDrGTDIHAEDrUJLaeBkgLTutKlcb;

			public int YVkNweHJLVrPPVeOsuKwFafNlTID;

			public InputSource VBBLcZAvXzjtfRdfKZgfpHzxLxaf;

			public jGdBtjnfTyGBISVuamYbkGHgkejU(int P_0, int P_1, InputSource P_2)
			{
				GDrGTDIHAEDrUJLaeBkgLTutKlcb = P_0;
				YVkNweHJLVrPPVeOsuKwFafNlTID = P_1;
				VBBLcZAvXzjtfRdfKZgfpHzxLxaf = P_2;
			}
		}

		public enum wsiisIwYCFpyMzuVVvcQyajDLGiL
		{
			Connected = 0,
			Disconnected = 1
		}

		private List<GniGuqsDUKdQbAbhIcCVRyyxyQIP> eAnWNkasyMkuHqQoXDAmGeRGtxq;

		private List<GniGuqsDUKdQbAbhIcCVRyyxyQIP> IFcpGFaBcFXFGMuaseGCRlbnXqtV;

		public int MzWxhuzzLmrjmgSgCSswJixhYxoR => IFcpGFaBcFXFGMuaseGCRlbnXqtV.Count;

		public hjOkpMNXCVOEXqiZESOyOmKfSfic()
		{
			IFcpGFaBcFXFGMuaseGCRlbnXqtV = new List<GniGuqsDUKdQbAbhIcCVRyyxyQIP>();
			eAnWNkasyMkuHqQoXDAmGeRGtxq = new List<GniGuqsDUKdQbAbhIcCVRyyxyQIP>();
		}

		public void qtpDUucwoIXqCtactSvamWeFanaZ(BridgedController P_0)
		{
			if (P_0 == null || P_0.sourceJoystick == null)
			{
				return;
			}
			IInputManagerJoystickPublic sourceJoystick = P_0.sourceJoystick;
			int num = AVvmRAQBfMWaFDpFsdQkDdrXidLs(sourceJoystick.rewiredId, wsiisIwYCFpyMzuVVvcQyajDLGiL.Connected);
			GniGuqsDUKdQbAbhIcCVRyyxyQIP gniGuqsDUKdQbAbhIcCVRyyxyQIP;
			if (num >= 0)
			{
				gniGuqsDUKdQbAbhIcCVRyyxyQIP = IFcpGFaBcFXFGMuaseGCRlbnXqtV[num];
				gniGuqsDUKdQbAbhIcCVRyyxyQIP.CbtcCsDeezaFlhCHgCViuMDENwihB(sourceJoystick.inputManagerId);
				P_0.sourceJoystick = new oJrgNncotVFoAcZllMfwwQSjmbto(sourceJoystick, gniGuqsDUKdQbAbhIcCVRyyxyQIP.VgGSuTVdljhFErfqwUirwTSCYUQC);
				return;
			}
			num = AVvmRAQBfMWaFDpFsdQkDdrXidLs(sourceJoystick.rewiredId, wsiisIwYCFpyMzuVVvcQyajDLGiL.Disconnected);
			if (num >= 0)
			{
				gniGuqsDUKdQbAbhIcCVRyyxyQIP = eAnWNkasyMkuHqQoXDAmGeRGtxq[num];
				eAnWNkasyMkuHqQoXDAmGeRGtxq.RemoveAt(num);
				int vgGSuTVdljhFErfqwUirwTSCYUQC = ICOSmMBattUgTKKFHbIVQWWktuDX(gniGuqsDUKdQbAbhIcCVRyyxyQIP.VgGSuTVdljhFErfqwUirwTSCYUQC);
				gniGuqsDUKdQbAbhIcCVRyyxyQIP.VgGSuTVdljhFErfqwUirwTSCYUQC = vgGSuTVdljhFErfqwUirwTSCYUQC;
			}
			else
			{
				gniGuqsDUKdQbAbhIcCVRyyxyQIP = new GniGuqsDUKdQbAbhIcCVRyyxyQIP(oREdICWlKHsidSHQFfdbBhYMsPWl(), sourceJoystick.inputManagerId, sourceJoystick.rewiredId, P_0.inputManagerSource);
			}
			P_0.sourceJoystick = new oJrgNncotVFoAcZllMfwwQSjmbto(sourceJoystick, gniGuqsDUKdQbAbhIcCVRyyxyQIP.VgGSuTVdljhFErfqwUirwTSCYUQC);
			IFcpGFaBcFXFGMuaseGCRlbnXqtV.Add(gniGuqsDUKdQbAbhIcCVRyyxyQIP);
			IFcpGFaBcFXFGMuaseGCRlbnXqtV.Sort(GniGuqsDUKdQbAbhIcCVRyyxyQIP.mBfpILaVaSTUfRxZuMHlNsvosEdS);
		}

		public void RrrAAjlHqPEqbBoRLElmeqQiZPLV(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				int num = AVvmRAQBfMWaFDpFsdQkDdrXidLs(P_0.rewiredId, wsiisIwYCFpyMzuVVvcQyajDLGiL.Connected);
				if (num < 0)
				{
					Logger.LogError("Device was not in connected list! Cannot remove!");
					return;
				}
				GniGuqsDUKdQbAbhIcCVRyyxyQIP item = IFcpGFaBcFXFGMuaseGCRlbnXqtV[num];
				IFcpGFaBcFXFGMuaseGCRlbnXqtV.RemoveAt(num);
				eAnWNkasyMkuHqQoXDAmGeRGtxq.Add(item);
			}
		}

		public void lVtKPhmnPbfJAMAhAMVWDenkCBzz(int P_0, int P_1)
		{
			int num = AVvmRAQBfMWaFDpFsdQkDdrXidLs(P_0, wsiisIwYCFpyMzuVVvcQyajDLGiL.Connected);
			if (num >= 0)
			{
				IFcpGFaBcFXFGMuaseGCRlbnXqtV[num].CbtcCsDeezaFlhCHgCViuMDENwihB(P_1);
				return;
			}
			num = AVvmRAQBfMWaFDpFsdQkDdrXidLs(P_0, wsiisIwYCFpyMzuVVvcQyajDLGiL.Disconnected);
			if (num >= 0)
			{
				eAnWNkasyMkuHqQoXDAmGeRGtxq[num].CbtcCsDeezaFlhCHgCViuMDENwihB(P_1);
			}
		}

		public bool LhOalXjvJqegVCjuCkjkUrfSiwyW(int P_0, wsiisIwYCFpyMzuVVvcQyajDLGiL P_1)
		{
			return AVvmRAQBfMWaFDpFsdQkDdrXidLs(P_0, P_1) >= 0;
		}

		public int AVvmRAQBfMWaFDpFsdQkDdrXidLs(int P_0, wsiisIwYCFpyMzuVVvcQyajDLGiL P_1)
		{
			switch (P_1)
			{
			case wsiisIwYCFpyMzuVVvcQyajDLGiL.Connected:
			{
				int count2 = IFcpGFaBcFXFGMuaseGCRlbnXqtV.Count;
				for (int j = 0; j < count2; j++)
				{
					if (IFcpGFaBcFXFGMuaseGCRlbnXqtV[j].UqYDqVFGoFKbizDoRSDeJvOCHpgBA == P_0)
					{
						return j;
					}
				}
				break;
			}
			case wsiisIwYCFpyMzuVVvcQyajDLGiL.Disconnected:
			{
				int count = eAnWNkasyMkuHqQoXDAmGeRGtxq.Count;
				for (int i = 0; i < count; i++)
				{
					if (eAnWNkasyMkuHqQoXDAmGeRGtxq[i].UqYDqVFGoFKbizDoRSDeJvOCHpgBA == P_0)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public int kmNolckWakJPCpnuxboSjBmsRqFr(int P_0, InputSource P_1, wsiisIwYCFpyMzuVVvcQyajDLGiL P_2)
		{
			switch (P_2)
			{
			case wsiisIwYCFpyMzuVVvcQyajDLGiL.Connected:
			{
				int count2 = IFcpGFaBcFXFGMuaseGCRlbnXqtV.Count;
				for (int j = 0; j < count2; j++)
				{
					if (IFcpGFaBcFXFGMuaseGCRlbnXqtV[j].VgGSuTVdljhFErfqwUirwTSCYUQC == P_0 && IFcpGFaBcFXFGMuaseGCRlbnXqtV[j].dFiABpHtOdiMKQmQTAVJomjjccTCA == P_1)
					{
						return j;
					}
				}
				break;
			}
			case wsiisIwYCFpyMzuVVvcQyajDLGiL.Disconnected:
			{
				int count = eAnWNkasyMkuHqQoXDAmGeRGtxq.Count;
				for (int i = 0; i < count; i++)
				{
					if (eAnWNkasyMkuHqQoXDAmGeRGtxq[i].VgGSuTVdljhFErfqwUirwTSCYUQC == P_0 && eAnWNkasyMkuHqQoXDAmGeRGtxq[i].dFiABpHtOdiMKQmQTAVJomjjccTCA == P_1)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public jGdBtjnfTyGBISVuamYbkGHgkejU HhwIJLKCjwNUteODjyScavJUbEeV(int P_0, wsiisIwYCFpyMzuVVvcQyajDLGiL P_1)
		{
			if (P_1 == wsiisIwYCFpyMzuVVvcQyajDLGiL.Connected)
			{
				if (P_0 < 0 || P_0 >= IFcpGFaBcFXFGMuaseGCRlbnXqtV.Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				return IFcpGFaBcFXFGMuaseGCRlbnXqtV[P_0].BbNuIOtLoGbaWXFbKWrJCKezdraO();
			}
			if (P_0 < 0 || P_0 >= eAnWNkasyMkuHqQoXDAmGeRGtxq.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return eAnWNkasyMkuHqQoXDAmGeRGtxq[P_0].BbNuIOtLoGbaWXFbKWrJCKezdraO();
		}

		public int SDtYAIjnBuapecizjiKatQOXrZgtA(int P_0, InputSource P_1, wsiisIwYCFpyMzuVVvcQyajDLGiL P_2)
		{
			int num = kmNolckWakJPCpnuxboSjBmsRqFr(P_0, P_1, P_2);
			if (num < 0)
			{
				return -1;
			}
			return P_2 switch
			{
				wsiisIwYCFpyMzuVVvcQyajDLGiL.Connected => IFcpGFaBcFXFGMuaseGCRlbnXqtV[num].zphExlmahznMrgZdKVCCjpIpgiYr, 
				wsiisIwYCFpyMzuVVvcQyajDLGiL.Disconnected => eAnWNkasyMkuHqQoXDAmGeRGtxq[num].zphExlmahznMrgZdKVCCjpIpgiYr, 
				_ => -1, 
			};
		}

		private int ICOSmMBattUgTKKFHbIVQWWktuDX(int P_0)
		{
			int count = IFcpGFaBcFXFGMuaseGCRlbnXqtV.Count;
			for (int i = 0; i < count; i++)
			{
				if (IFcpGFaBcFXFGMuaseGCRlbnXqtV[i].VgGSuTVdljhFErfqwUirwTSCYUQC == P_0)
				{
					return oREdICWlKHsidSHQFfdbBhYMsPWl();
				}
			}
			return P_0;
		}

		private int oREdICWlKHsidSHQFfdbBhYMsPWl()
		{
			int count = IFcpGFaBcFXFGMuaseGCRlbnXqtV.Count;
			int num = 0;
			while (true)
			{
				bool flag = false;
				for (int i = 0; i < count; i++)
				{
					if (IFcpGFaBcFXFGMuaseGCRlbnXqtV[i].VgGSuTVdljhFErfqwUirwTSCYUQC == num)
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
	}

	private class oJrgNncotVFoAcZllMfwwQSjmbto : IInputManagerJoystickPublic, ITryGetLocalizedName, IGetValues<Controller.Extension>
	{
		private IInputManagerJoystickPublic pULJTvwCJYIudCurPmbKbJXfKRSpA;

		private int tHeQmEhOCwGFAyATwYCPaudZJcI;

		int IInputManagerJoystickPublic.rewiredId => pULJTvwCJYIudCurPmbKbJXfKRSpA.rewiredId;

		int IInputManagerJoystickPublic.inputManagerId => tHeQmEhOCwGFAyATwYCPaudZJcI;

		string IInputManagerJoystickPublic.name => pULJTvwCJYIudCurPmbKbJXfKRSpA.name;

		long? IInputManagerJoystickPublic.systemId => pULJTvwCJYIudCurPmbKbJXfKRSpA.systemId;

		int IInputManagerJoystickPublic.unityId => pULJTvwCJYIudCurPmbKbJXfKRSpA.unityId;

		Guid IInputManagerJoystickPublic.instanceGuid => pULJTvwCJYIudCurPmbKbJXfKRSpA.instanceGuid;

		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		Controller.Extension IInputManagerJoystickPublic.extension => pULJTvwCJYIudCurPmbKbJXfKRSpA.extension;

		public oJrgNncotVFoAcZllMfwwQSjmbto(IInputManagerJoystickPublic P_0, int P_1)
		{
			pULJTvwCJYIudCurPmbKbJXfKRSpA = P_0;
			tHeQmEhOCwGFAyATwYCPaudZJcI = P_1;
		}

		public void SetVibration(float amount, int motorIndex)
		{
			pULJTvwCJYIudCurPmbKbJXfKRSpA.SetVibration(amount, motorIndex);
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		public void StopVibration()
		{
			pULJTvwCJYIudCurPmbKbJXfKRSpA.StopVibration();
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		int IGetValues<Controller.Extension>.GetValues(IList<Controller.Extension> results)
		{
			if (!(pULJTvwCJYIudCurPmbKbJXfKRSpA is IGetValues<Controller.Extension> getValues))
			{
				if (pULJTvwCJYIudCurPmbKbJXfKRSpA.extension != null)
				{
					results.Add(pULJTvwCJYIudCurPmbKbJXfKRSpA.extension);
					return 1;
				}
				return 0;
			}
			return getValues.GetValues(results);
		}

		bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
		{
			if (pULJTvwCJYIudCurPmbKbJXfKRSpA is ITryGetLocalizedName tryGetLocalizedName)
			{
				return tryGetLocalizedName.TryGetLocalizedName(out value);
			}
			value = null;
			return false;
		}
	}

	[Serializable]
	private sealed class ReDjRXdceOeuMsZREZvYkCwoWuZx
	{
		public static readonly ReDjRXdceOeuMsZREZvYkCwoWuZx _003C_003E9 = new ReDjRXdceOeuMsZREZvYkCwoWuZx();

		public static Func<PidVid, bool> _003C_003E9__11_0;

		internal bool EqRTQhUIErrseWFntiVRlnMiTpLj(PidVid P_0)
		{
			return false;
		}
	}

	private sealed class xxXpDtUywLCkmvsaTicmrWHuWDoj
	{
		public int iaPRHUKCZPeyytmpocStLxhKkJC;

		internal int qRFPAbeVjouHAdLNEkOfAzoWziIF()
		{
			return iaPRHUKCZPeyytmpocStLxhKkJC++;
		}
	}

	private bool qognkSxejVbUPaYdWtyfpHNboNyZA;

	private uNPOVSRRzFKaWaqNVryqwMJGuDMt IWxDgoKvxExEssSFmYQoCNdnCcNOA;

	private IndexedDictionary<int, PlatformInputManager> znNcxVzAOGMrEjHCuzbQrxJYaSeJ;

	private hjOkpMNXCVOEXqiZESOyOmKfSfic cThazbacZKLkmfgumVKuuVVKNHnHA;

	private Action<int, ControllerDataUpdater> cgNdUAGOnmnGGyTweADKPxdoTmRBA;

	private WindowsStandalonePrimaryInputSource cjcAijcdfNUFHogGaOirYllJPjWe;

	private PlatformInputManager HTBVhlBtJQrnzPMEMnWAqGbFyxqb;

	private bool kxPYzesHeqiwNgRMadCxWiOeKoKv;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> MgPcwqXjvdVurIqzDjWjjVlbkMJN;

	private Func<int> dJMaMLIBGPrulGCWafoWvsSaBFcC;

	private Func<PidVid, bool> lfigrTGWsEkTgWJKRfszwZmMtled;

	[CustomObfuscation(rename = false)]
	private int counter;

	bool INativePlatformHelper.isApplicationFocused
	{
		get
		{
			IntPtr intPtr = AmOfVgHMXtIpYGmFoUHcniSRkMulA.MolCoBHyuLVDupYjlPzvmPaxEMSCA();
			IntPtr intPtr2 = AmOfVgHMXtIpYGmFoUHcniSRkMulA.zuLdjdAFcPBZQRdAmrGSDZgpfcWab();
			if (intPtr2 != IntPtr.Zero)
			{
				return intPtr == intPtr2;
			}
			return false;
		}
	}

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => cThazbacZKLkmfgumVKuuVVKNHnHA.MzWxhuzzLmrjmgSgCSswJixhYxoR;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => HTBVhlBtJQrnzPMEMnWAqGbFyxqb;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => HTBVhlBtJQrnzPMEMnWAqGbFyxqb.inputSource;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType
	{
		get
		{
			if (HTBVhlBtJQrnzPMEMnWAqGbFyxqb == null)
			{
				return InputSource.None;
			}
			return HTBVhlBtJQrnzPMEMnWAqGbFyxqb.inputSourceType;
		}
	}

	public qkWHxmOkuUhrVDInECtyqYOZATeS(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2)
	{
		try
		{
			cjcAijcdfNUFHogGaOirYllJPjWe = P_0.windowsStandalonePrimaryInputSource;
			lfigrTGWsEkTgWJKRfszwZmMtled = ReDjRXdceOeuMsZREZvYkCwoWuZx._003C_003E9.EqRTQhUIErrseWFntiVRlnMiTpLj;
			bool flag = UnityTools.platform == Platform.WindowsAppStore || UnityTools.platform == Platform.Windows81Store || UnityTools.platform == Platform.WindowsPhone8;
			bool flag2 = UnityTools.platform == Platform.Windows && (cjcAijcdfNUFHogGaOirYllJPjWe == WindowsStandalonePrimaryInputSource.DirectInput || cjcAijcdfNUFHogGaOirYllJPjWe == WindowsStandalonePrimaryInputSource.RawInput);
			tlpaVkWHWgDxCHYLZUjdpPaUJdWMA tlpaVkWHWgDxCHYLZUjdpPaUJdWMA2 = tlpaVkWHWgDxCHYLZUjdpPaUJdWMA.None;
			if (flag2)
			{
				tlpaVkWHWgDxCHYLZUjdpPaUJdWMA2 = (P_0.GetPlatformVar_useWindowsGamingInput() ? tlpaVkWHWgDxCHYLZUjdpPaUJdWMA.WindowsGamingInput : (P_0.useXInput ? tlpaVkWHWgDxCHYLZUjdpPaUJdWMA.XInput : tlpaVkWHWgDxCHYLZUjdpPaUJdWMA.None));
			}
			bool flag3 = tlpaVkWHWgDxCHYLZUjdpPaUJdWMA2 == tlpaVkWHWgDxCHYLZUjdpPaUJdWMA.WindowsGamingInput || tlpaVkWHWgDxCHYLZUjdpPaUJdWMA2 == tlpaVkWHWgDxCHYLZUjdpPaUJdWMA.XInput || cjcAijcdfNUFHogGaOirYllJPjWe == WindowsStandalonePrimaryInputSource.XInput || cjcAijcdfNUFHogGaOirYllJPjWe == WindowsStandalonePrimaryInputSource.WindowsGamingInput;
			MgPcwqXjvdVurIqzDjWjjVlbkMJN = P_1;
			dJMaMLIBGPrulGCWafoWvsSaBFcC = P_2;
			bool flag4 = false;
			znNcxVzAOGMrEjHCuzbQrxJYaSeJ = new IndexedDictionary<int, PlatformInputManager>();
			PlatformInputManager platformInputManager = null;
			if (UnityTools.platform != Platform.WindowsAppStore)
			{
				try
				{
					VpydvvgAmkTUcjFPOCjeqVyqydEE.AQkHUHjpPPBQCDvHBizLHvPUSPqGA(flag3);
				}
				catch (Exception ex)
				{
					OnDestroy();
					Logger.LogWarning("Unable to initialize input source!\n" + ex.Message);
					throw;
				}
			}
			if (flag2)
			{
				switch (tlpaVkWHWgDxCHYLZUjdpPaUJdWMA2)
				{
				case tlpaVkWHWgDxCHYLZUjdpPaUJdWMA.XInput:
					if (eFpPNyyCSjBqMiIEZnTcTSqtaexf(P_0, false, out platformInputManager))
					{
						flag4 = true;
					}
					else
					{
						P_0.useXInput = false;
					}
					break;
				case tlpaVkWHWgDxCHYLZUjdpPaUJdWMA.WindowsGamingInput:
					if (pvfRIOjHICdKMNZFIWHikpipcBBbA(P_0, false, out platformInputManager))
					{
						break;
					}
					P_0.SetPlatformVar_useWindowsGamingInput(value: false);
					if (P_0.useXInput && !flag4)
					{
						Logger.Log("Attempting to fallback to XInput...");
						if (eFpPNyyCSjBqMiIEZnTcTSqtaexf(P_0, false, out platformInputManager))
						{
							flag4 = true;
							Logger.Log("XInput initialized.");
						}
						else
						{
							P_0.useXInput = false;
						}
					}
					break;
				}
			}
			if (flag)
			{
				if (!flag4 && !eFpPNyyCSjBqMiIEZnTcTSqtaexf(P_0, true, out HTBVhlBtJQrnzPMEMnWAqGbFyxqb))
				{
					throw new Exception();
				}
			}
			else if (UnityTools.platform != Platform.WindowsAppStore)
			{
				IWxDgoKvxExEssSFmYQoCNdnCcNOA = new uNPOVSRRzFKaWaqNVryqwMJGuDMt();
				bool flag5 = false;
				if (cjcAijcdfNUFHogGaOirYllJPjWe == WindowsStandalonePrimaryInputSource.DirectInput)
				{
					flag5 = rAoqYZoyTEkFAhyJGmzvgOykryBt(P_0, IWxDgoKvxExEssSFmYQoCNdnCcNOA, platformInputManager as NmANKYQYjJJatXyTLQutNfBhTrds);
					if (!flag5)
					{
						Logger.Log("Attempting to fallback to Raw Input...");
						flag5 = MJhFLABNhkhVFOYQJKJNMkoyGmTVA(P_0, IWxDgoKvxExEssSFmYQoCNdnCcNOA, platformInputManager as NmANKYQYjJJatXyTLQutNfBhTrds);
						if (flag5)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							cjcAijcdfNUFHogGaOirYllJPjWe = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized.");
						}
					}
				}
				else if (cjcAijcdfNUFHogGaOirYllJPjWe == WindowsStandalonePrimaryInputSource.RawInput)
				{
					flag5 = MJhFLABNhkhVFOYQJKJNMkoyGmTVA(P_0, IWxDgoKvxExEssSFmYQoCNdnCcNOA, platformInputManager as NmANKYQYjJJatXyTLQutNfBhTrds);
					if (!flag5)
					{
						Logger.Log("Attempting to fallback to Direct Input...");
						flag5 = rAoqYZoyTEkFAhyJGmzvgOykryBt(P_0, IWxDgoKvxExEssSFmYQoCNdnCcNOA, platformInputManager as NmANKYQYjJJatXyTLQutNfBhTrds);
						if (flag5)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.DirectInput;
							cjcAijcdfNUFHogGaOirYllJPjWe = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Direct Input initialized.");
						}
					}
				}
				else if (cjcAijcdfNUFHogGaOirYllJPjWe == WindowsStandalonePrimaryInputSource.XInput)
				{
					P_0.SetPlatformVar_useWindowsGamingInput(value: false);
					flag5 = eFpPNyyCSjBqMiIEZnTcTSqtaexf(P_0, true, out HTBVhlBtJQrnzPMEMnWAqGbFyxqb);
					flag4 = flag5;
					if (flag5)
					{
						hLiHMFVloWOfEjQsgwsYDMDiCNaJA(P_0, IWxDgoKvxExEssSFmYQoCNdnCcNOA);
					}
					else
					{
						P_0.useXInput = false;
						Logger.Log("Attempting to fallback to Raw Input...");
						flag5 = MJhFLABNhkhVFOYQJKJNMkoyGmTVA(P_0, IWxDgoKvxExEssSFmYQoCNdnCcNOA, null);
						if (flag5)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							cjcAijcdfNUFHogGaOirYllJPjWe = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized.");
						}
					}
				}
				else if (cjcAijcdfNUFHogGaOirYllJPjWe == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
				{
					bool flag6 = true;
					flag5 = pvfRIOjHICdKMNZFIWHikpipcBBbA(P_0, true, out HTBVhlBtJQrnzPMEMnWAqGbFyxqb);
					if (!flag5)
					{
						P_0.SetPlatformVar_useWindowsGamingInput(value: false);
						if (P_0.useXInput && !flag4)
						{
							Logger.Log("Attempting to fallback to XInput...");
							flag5 = eFpPNyyCSjBqMiIEZnTcTSqtaexf(P_0, true, out HTBVhlBtJQrnzPMEMnWAqGbFyxqb);
							flag4 = flag5;
							if (flag5)
							{
								P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.XInput;
								Logger.Log("XInput initialized.");
							}
							else
							{
								P_0.useXInput = false;
							}
						}
						if (!flag5)
						{
							Logger.Log("Attempting to fallback to Raw Input...");
							flag5 = MJhFLABNhkhVFOYQJKJNMkoyGmTVA(P_0, IWxDgoKvxExEssSFmYQoCNdnCcNOA, null);
							if (flag5)
							{
								flag6 = false;
								P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
								cjcAijcdfNUFHogGaOirYllJPjWe = P_0.windowsStandalonePrimaryInputSource;
								Logger.Log("Raw Input initialized.");
							}
						}
					}
					if (flag5 && flag6)
					{
						hLiHMFVloWOfEjQsgwsYDMDiCNaJA(P_0, IWxDgoKvxExEssSFmYQoCNdnCcNOA);
					}
				}
				if (!flag5)
				{
					throw new Exception();
				}
				EcFEgMXzNInCyCQWNcavWOukOqkN(P_0, out var _);
				IWxDgoKvxExEssSFmYQoCNdnCcNOA.bDftrehpvhnHasXrqaiGKnBZFLzh += WlvuFICFuCArGgdnexGFPmlsZwobA;
				IWxDgoKvxExEssSFmYQoCNdnCcNOA.fWoDsPglOGbaAsbBopxwbrLTEZBxA += sMLFyfTgfsrelUzjMpdVLuKChMgf;
			}
			if (HTBVhlBtJQrnzPMEMnWAqGbFyxqb == null)
			{
				throw new Exception("No primary input manager could be initialized.");
			}
			cgNdUAGOnmnGGyTweADKPxdoTmRBA = UpdateControllerData;
		}
		catch (Exception ex2)
		{
			OnDestroy();
			Logger.LogWarning("Unable to initialize input source!\n" + ex2.Message);
			throw;
		}
	}

	private bool rAoqYZoyTEkFAhyJGmzvgOykryBt(ConfigVars P_0, uNPOVSRRzFKaWaqNVryqwMJGuDMt P_1, NmANKYQYjJJatXyTLQutNfBhTrds P_2)
	{
		eiLWwlzVJeseqUWxMFDDBdBzIEdkA eiLWwlzVJeseqUWxMFDDBdBzIEdkA2 = null;
		cRyfuQzNFxYGQezCiHENTfXugyhgA cRyfuQzNFxYGQezCiHENTfXugyhgA2 = null;
		try
		{
			eiLWwlzVJeseqUWxMFDDBdBzIEdkA2 = new eiLWwlzVJeseqUWxMFDDBdBzIEdkA(P_0, null, null, null, false, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			cRyfuQzNFxYGQezCiHENTfXugyhgA2 = (cRyfuQzNFxYGQezCiHENTfXugyhgA)(HTBVhlBtJQrnzPMEMnWAqGbFyxqb = new cRyfuQzNFxYGQezCiHENTfXugyhgA(P_0.updateLoop, P_2, P_1.lRAhMebvzhsYXYkwLLygjwvMrUAC, MgPcwqXjvdVurIqzDjWjjVlbkMJN, dJMaMLIBGPrulGCWafoWvsSaBFcC));
			znNcxVzAOGMrEjHCuzbQrxJYaSeJ.Add(5, eiLWwlzVJeseqUWxMFDDBdBzIEdkA2);
			znNcxVzAOGMrEjHCuzbQrxJYaSeJ.Add(1, HTBVhlBtJQrnzPMEMnWAqGbFyxqb);
			P_1.CFdeBMNfzpYNnJRPAcKWhpMVxPJP += eiLWwlzVJeseqUWxMFDDBdBzIEdkA2.TKWxnaPYHCvJVorguRyireYDBvdL;
			eiLWwlzVJeseqUWxMFDDBdBzIEdkA2.DeviceConnectedEvent += FwrBTgjkghaDFbyWrsVyTnWwjKZr;
			eiLWwlzVJeseqUWxMFDDBdBzIEdkA2.DeviceDisconnectedEvent += LlxbAcDffbBzgtMgoibhZbddDZou;
			eiLWwlzVJeseqUWxMFDDBdBzIEdkA2.UpdateControllerInfoEvent += sulMKYhiCiiKCCKpfLwEfFbKHlXXB;
			cRyfuQzNFxYGQezCiHENTfXugyhgA2.DeviceConnectedEvent += FwrBTgjkghaDFbyWrsVyTnWwjKZr;
			cRyfuQzNFxYGQezCiHENTfXugyhgA2.DeviceDisconnectedEvent += LlxbAcDffbBzgtMgoibhZbddDZou;
			cRyfuQzNFxYGQezCiHENTfXugyhgA2.UpdateControllerInfoEvent += sulMKYhiCiiKCCKpfLwEfFbKHlXXB;
			return true;
		}
		catch (Exception)
		{
			cRyfuQzNFxYGQezCiHENTfXugyhgA2?.OnDestroy();
			eiLWwlzVJeseqUWxMFDDBdBzIEdkA2?.OnDestroy();
			Logger.LogWarning("Unable to initialize Direct Input! ");
		}
		return false;
	}

	private bool MJhFLABNhkhVFOYQJKJNMkoyGmTVA(ConfigVars P_0, uNPOVSRRzFKaWaqNVryqwMJGuDMt P_1, NmANKYQYjJJatXyTLQutNfBhTrds P_2)
	{
		eiLWwlzVJeseqUWxMFDDBdBzIEdkA eiLWwlzVJeseqUWxMFDDBdBzIEdkA2 = null;
		try
		{
			eiLWwlzVJeseqUWxMFDDBdBzIEdkA2 = new eiLWwlzVJeseqUWxMFDDBdBzIEdkA(P_0, P_2, MgPcwqXjvdVurIqzDjWjjVlbkMJN, dJMaMLIBGPrulGCWafoWvsSaBFcC, true, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			znNcxVzAOGMrEjHCuzbQrxJYaSeJ.Add(5, eiLWwlzVJeseqUWxMFDDBdBzIEdkA2);
			P_1.CFdeBMNfzpYNnJRPAcKWhpMVxPJP += eiLWwlzVJeseqUWxMFDDBdBzIEdkA2.TKWxnaPYHCvJVorguRyireYDBvdL;
			HTBVhlBtJQrnzPMEMnWAqGbFyxqb = eiLWwlzVJeseqUWxMFDDBdBzIEdkA2;
			eiLWwlzVJeseqUWxMFDDBdBzIEdkA2.DeviceConnectedEvent += FwrBTgjkghaDFbyWrsVyTnWwjKZr;
			eiLWwlzVJeseqUWxMFDDBdBzIEdkA2.DeviceDisconnectedEvent += LlxbAcDffbBzgtMgoibhZbddDZou;
			eiLWwlzVJeseqUWxMFDDBdBzIEdkA2.UpdateControllerInfoEvent += sulMKYhiCiiKCCKpfLwEfFbKHlXXB;
			return true;
		}
		catch (Exception)
		{
			Logger.LogWarning("Unable to initialize Raw Input! This error can be caused by running Unity sandboxed.");
			eiLWwlzVJeseqUWxMFDDBdBzIEdkA2?.OnDestroy();
		}
		return false;
	}

	private bool hLiHMFVloWOfEjQsgwsYDMDiCNaJA(ConfigVars P_0, uNPOVSRRzFKaWaqNVryqwMJGuDMt P_1)
	{
		bool platformVar_useNativeMouse = P_0.GetPlatformVar_useNativeMouse();
		bool platformVar_useNativeKeyboard = P_0.GetPlatformVar_useNativeKeyboard();
		if (!platformVar_useNativeMouse && !platformVar_useNativeKeyboard)
		{
			return false;
		}
		eiLWwlzVJeseqUWxMFDDBdBzIEdkA eiLWwlzVJeseqUWxMFDDBdBzIEdkA2 = null;
		try
		{
			eiLWwlzVJeseqUWxMFDDBdBzIEdkA2 = new eiLWwlzVJeseqUWxMFDDBdBzIEdkA(P_0, null, null, null, false, platformVar_useNativeMouse, platformVar_useNativeKeyboard, P_0.GetPlatformVar_useEnhancedDeviceSupport());
			P_1.CFdeBMNfzpYNnJRPAcKWhpMVxPJP += eiLWwlzVJeseqUWxMFDDBdBzIEdkA2.TKWxnaPYHCvJVorguRyireYDBvdL;
			znNcxVzAOGMrEjHCuzbQrxJYaSeJ.Add(5, eiLWwlzVJeseqUWxMFDDBdBzIEdkA2);
			eiLWwlzVJeseqUWxMFDDBdBzIEdkA2.DeviceConnectedEvent += FwrBTgjkghaDFbyWrsVyTnWwjKZr;
			eiLWwlzVJeseqUWxMFDDBdBzIEdkA2.DeviceDisconnectedEvent += LlxbAcDffbBzgtMgoibhZbddDZou;
			eiLWwlzVJeseqUWxMFDDBdBzIEdkA2.UpdateControllerInfoEvent += sulMKYhiCiiKCCKpfLwEfFbKHlXXB;
			return true;
		}
		catch
		{
			Logger.LogWarning("Unable to initialize Raw Input for native mouse handling! Unity mouse input will be used instead.");
			eiLWwlzVJeseqUWxMFDDBdBzIEdkA2?.OnDestroy();
			eiLWwlzVJeseqUWxMFDDBdBzIEdkA2 = null;
			return false;
		}
	}

	private bool eFpPNyyCSjBqMiIEZnTcTSqtaexf(ConfigVars P_0, bool P_1, out PlatformInputManager P_2)
	{
		UpdateLoopSetting updateLoop = P_0.updateLoop;
		bool flag = false;
		try
		{
			if (flag)
			{
				xxXpDtUywLCkmvsaTicmrWHuWDoj xxXpDtUywLCkmvsaTicmrWHuWDoj2 = new xxXpDtUywLCkmvsaTicmrWHuWDoj();
				xxXpDtUywLCkmvsaTicmrWHuWDoj2.iaPRHUKCZPeyytmpocStLxhKkJC = 0;
				P_2 = new BdmVZBfayIRaEoZyauttTYQvabrH(flag, updateLoop, MgPcwqXjvdVurIqzDjWjjVlbkMJN, xxXpDtUywLCkmvsaTicmrWHuWDoj2.qRFPAbeVjouHAdLNEkOfAzoWziIF, lfigrTGWsEkTgWJKRfszwZmMtled);
				znNcxVzAOGMrEjHCuzbQrxJYaSeJ.Add(2, P_2);
			}
			else
			{
				P_2 = new BdmVZBfayIRaEoZyauttTYQvabrH(flag, updateLoop, MgPcwqXjvdVurIqzDjWjjVlbkMJN, dJMaMLIBGPrulGCWafoWvsSaBFcC, lfigrTGWsEkTgWJKRfszwZmMtled);
				znNcxVzAOGMrEjHCuzbQrxJYaSeJ.Add(2, P_2);
				P_2.DeviceConnectedEvent += FwrBTgjkghaDFbyWrsVyTnWwjKZr;
				P_2.DeviceDisconnectedEvent += LlxbAcDffbBzgtMgoibhZbddDZou;
				P_2.UpdateControllerInfoEvent += sulMKYhiCiiKCCKpfLwEfFbKHlXXB;
			}
			return true;
		}
		catch
		{
			P_2 = null;
			if (P_1)
			{
				Logger.LogWarning("Unable to initialize XInput!");
			}
			else if (!flag)
			{
				P_0.useXInput = false;
				for (int i = 0; i < znNcxVzAOGMrEjHCuzbQrxJYaSeJ.Count; i++)
				{
					if (znNcxVzAOGMrEjHCuzbQrxJYaSeJ[i] != null && znNcxVzAOGMrEjHCuzbQrxJYaSeJ[i] is XxcRWDacxPwaZuelhLPGabtEumyQ { YogAZbtYYniRhKJTUxmdWNvJBxiaA: not null } xxcRWDacxPwaZuelhLPGabtEumyQ && xxcRWDacxPwaZuelhLPGabtEumyQ.YogAZbtYYniRhKJTUxmdWNvJBxiaA.jHseHqFlGTAPeZLlDaFTpbkwpiFlA == tlpaVkWHWgDxCHYLZUjdpPaUJdWMA.XInput)
					{
						xxcRWDacxPwaZuelhLPGabtEumyQ.YogAZbtYYniRhKJTUxmdWNvJBxiaA = null;
					}
				}
				Logger.LogWarning("Unable to initialize XInput! XInput controllers will be handled by " + cjcAijcdfNUFHogGaOirYllJPjWe.ToString() + " instead. Vibration is not supported and the L/R triggers are treated as a single axis and input cannot be detected when both are pressed simultaneously. ");
			}
			return false;
		}
	}

	private bool pvfRIOjHICdKMNZFIWHikpipcBBbA(ConfigVars P_0, bool P_1, out PlatformInputManager P_2)
	{
		_ = P_0.updateLoop;
		if (!(P_0.GetPlatformVar_useWindowsGamingInput() || P_1))
		{
			P_2 = null;
			return false;
		}
		try
		{
			P_2 = new ZtwlQHHxgmpZcwqmNMHvfcuHsGGC(P_0, MgPcwqXjvdVurIqzDjWjjVlbkMJN, dJMaMLIBGPrulGCWafoWvsSaBFcC, lfigrTGWsEkTgWJKRfszwZmMtled);
			if (P_1)
			{
				HTBVhlBtJQrnzPMEMnWAqGbFyxqb = P_2;
			}
			znNcxVzAOGMrEjHCuzbQrxJYaSeJ.Add(30, P_2);
			P_2.DeviceConnectedEvent += FwrBTgjkghaDFbyWrsVyTnWwjKZr;
			P_2.DeviceDisconnectedEvent += LlxbAcDffbBzgtMgoibhZbddDZou;
			P_2.UpdateControllerInfoEvent += sulMKYhiCiiKCCKpfLwEfFbKHlXXB;
			return true;
		}
		catch (Exception)
		{
			P_2 = null;
			if (!P_1)
			{
				P_0.SetPlatformVar_useWindowsGamingInput(value: false);
				for (int i = 0; i < znNcxVzAOGMrEjHCuzbQrxJYaSeJ.Count; i++)
				{
					if (znNcxVzAOGMrEjHCuzbQrxJYaSeJ[i] != null && znNcxVzAOGMrEjHCuzbQrxJYaSeJ[i] is XxcRWDacxPwaZuelhLPGabtEumyQ { YogAZbtYYniRhKJTUxmdWNvJBxiaA: not null } xxcRWDacxPwaZuelhLPGabtEumyQ && xxcRWDacxPwaZuelhLPGabtEumyQ.YogAZbtYYniRhKJTUxmdWNvJBxiaA.jHseHqFlGTAPeZLlDaFTpbkwpiFlA == tlpaVkWHWgDxCHYLZUjdpPaUJdWMA.WindowsGamingInput)
					{
						xxcRWDacxPwaZuelhLPGabtEumyQ.YogAZbtYYniRhKJTUxmdWNvJBxiaA = null;
					}
				}
			}
			Logger.LogWarning("Unable to initialize Windows Gaming Input! ");
			return false;
		}
	}

	private bool EcFEgMXzNInCyCQWNcavWOukOqkN(ConfigVars P_0, out PlatformInputManager P_1)
	{
		if (!UnityTools.supportsUnityInputSystem || !P_0.IsSupportXRControllersAllowed(Platform.Windows) || !P_0.GetPlatformVar_supportXRControllers() || !UnityTools.externalTools.isUnityInputSystemEnabled)
		{
			P_1 = null;
			return false;
		}
		_ = P_0.updateLoop;
		try
		{
			P_1 = UnityInputSystemInputManager.Create(new UnityInputSystemInputSourceInitOptions
			{
				xrDevicesOnlyMode = true
			}, MgPcwqXjvdVurIqzDjWjjVlbkMJN, dJMaMLIBGPrulGCWafoWvsSaBFcC);
			if (P_1 == null)
			{
				throw new Exception();
			}
			znNcxVzAOGMrEjHCuzbQrxJYaSeJ.Add(10, P_1);
			P_1.DeviceConnectedEvent += FwrBTgjkghaDFbyWrsVyTnWwjKZr;
			P_1.DeviceDisconnectedEvent += LlxbAcDffbBzgtMgoibhZbddDZou;
			P_1.UpdateControllerInfoEvent += sulMKYhiCiiKCCKpfLwEfFbKHlXXB;
			return true;
		}
		catch (Exception)
		{
			P_1 = null;
			return false;
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		qognkSxejVbUPaYdWtyfpHNboNyZA = true;
		cThazbacZKLkmfgumVKuuVVKNHnHA = new hjOkpMNXCVOEXqiZESOyOmKfSfic();
		for (int i = 0; i < znNcxVzAOGMrEjHCuzbQrxJYaSeJ.Count; i++)
		{
			znNcxVzAOGMrEjHCuzbQrxJYaSeJ[i].Initialize();
		}
	}

	public virtual void JDwSgXJoqgfHrInrZffBEHUKugDSb(UpdateLoopType P_0)
	{
		for (int i = 0; i < znNcxVzAOGMrEjHCuzbQrxJYaSeJ.Count; i++)
		{
			znNcxVzAOGMrEjHCuzbQrxJYaSeJ[i].Update(P_0);
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		for (int num = znNcxVzAOGMrEjHCuzbQrxJYaSeJ.Count - 1; num >= 0; num--)
		{
			znNcxVzAOGMrEjHCuzbQrxJYaSeJ[num].OnDestroy();
		}
		znNcxVzAOGMrEjHCuzbQrxJYaSeJ.Clear();
		if (IWxDgoKvxExEssSFmYQoCNdnCcNOA != null)
		{
			IWxDgoKvxExEssSFmYQoCNdnCcNOA.bylwAsNhYdGIGFfqJzGgrNXCTyBpA();
			IWxDgoKvxExEssSFmYQoCNdnCcNOA = null;
		}
		VpydvvgAmkTUcjFPOCjeqVyqydEE.endZyayddGujVRbbIrpfJSPrqGio();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return cgNdUAGOnmnGGyTweADKPxdoTmRBA;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int controllerId, ControllerDataUpdater data)
	{
		znNcxVzAOGMrEjHCuzbQrxJYaSeJ.GetValue((int)data.source).UpdateControllerData(cThazbacZKLkmfgumVKuuVVKNHnHA.SDtYAIjnBuapecizjiKatQOXrZgtA(controllerId, data.source, hjOkpMNXCVOEXqiZESOyOmKfSfic.wsiisIwYCFpyMzuVVvcQyajDLGiL.Connected), data);
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		for (int i = 0; i < znNcxVzAOGMrEjHCuzbQrxJYaSeJ.Count; i++)
		{
			IUnifiedMouseSource unifiedMouseSource = znNcxVzAOGMrEjHCuzbQrxJYaSeJ[i].GetUnifiedMouseSource();
			if (unifiedMouseSource != null)
			{
				return unifiedMouseSource;
			}
		}
		return null;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		for (int i = 0; i < znNcxVzAOGMrEjHCuzbQrxJYaSeJ.Count; i++)
		{
			IUnifiedKeyboardSource unifiedKeyboardSource = znNcxVzAOGMrEjHCuzbQrxJYaSeJ[i].GetUnifiedKeyboardSource();
			if (unifiedKeyboardSource != null)
			{
				return unifiedKeyboardSource;
			}
		}
		return null;
	}

	private void FwrBTgjkghaDFbyWrsVyTnWwjKZr(BridgedController P_0)
	{
		if (P_0 != null)
		{
			cThazbacZKLkmfgumVKuuVVKNHnHA.qtpDUucwoIXqCtactSvamWeFanaZ(P_0);
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0);
			}
		}
	}

	private void LlxbAcDffbBzgtMgoibhZbddDZou(ControllerDisconnectedEventArgs P_0)
	{
		if (P_0 != null)
		{
			cThazbacZKLkmfgumVKuuVVKNHnHA.RrrAAjlHqPEqbBoRLElmeqQiZPLV(P_0);
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(P_0);
			}
		}
	}

	private void WlvuFICFuCArGgdnexGFPmlsZwobA(EventArgs P_0)
	{
		if (qognkSxejVbUPaYdWtyfpHNboNyZA)
		{
			for (int i = 0; i < znNcxVzAOGMrEjHCuzbQrxJYaSeJ.Count; i++)
			{
				znNcxVzAOGMrEjHCuzbQrxJYaSeJ[i].SystemDeviceConnected();
			}
		}
	}

	private void sMLFyfTgfsrelUzjMpdVLuKChMgf(EventArgs P_0)
	{
		if (qognkSxejVbUPaYdWtyfpHNboNyZA)
		{
			for (int i = 0; i < znNcxVzAOGMrEjHCuzbQrxJYaSeJ.Count; i++)
			{
				znNcxVzAOGMrEjHCuzbQrxJYaSeJ[i].SystemDeviceDisconnected();
			}
		}
	}

	private void sulMKYhiCiiKCCKpfLwEfFbKHlXXB(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 == null || P_0.sourceJoystick == null)
		{
			return;
		}
		cThazbacZKLkmfgumVKuuVVKNHnHA.lVtKPhmnPbfJAMAhAMVWDenkCBzz(P_0.sourceJoystick.rewiredId, P_0.sourceJoystick.inputManagerId);
		hjOkpMNXCVOEXqiZESOyOmKfSfic.wsiisIwYCFpyMzuVVvcQyajDLGiL wsiisIwYCFpyMzuVVvcQyajDLGiL = hjOkpMNXCVOEXqiZESOyOmKfSfic.wsiisIwYCFpyMzuVVvcQyajDLGiL.Connected;
		int num = cThazbacZKLkmfgumVKuuVVKNHnHA.AVvmRAQBfMWaFDpFsdQkDdrXidLs(P_0.sourceJoystick.rewiredId, wsiisIwYCFpyMzuVVvcQyajDLGiL);
		if (num < 0)
		{
			wsiisIwYCFpyMzuVVvcQyajDLGiL = hjOkpMNXCVOEXqiZESOyOmKfSfic.wsiisIwYCFpyMzuVVvcQyajDLGiL.Disconnected;
			num = cThazbacZKLkmfgumVKuuVVKNHnHA.AVvmRAQBfMWaFDpFsdQkDdrXidLs(P_0.sourceJoystick.rewiredId, wsiisIwYCFpyMzuVVvcQyajDLGiL);
		}
		if (num >= 0)
		{
			hjOkpMNXCVOEXqiZESOyOmKfSfic.jGdBtjnfTyGBISVuamYbkGHgkejU jGdBtjnfTyGBISVuamYbkGHgkejU = cThazbacZKLkmfgumVKuuVVKNHnHA.HhwIJLKCjwNUteODjyScavJUbEeV(num, wsiisIwYCFpyMzuVVvcQyajDLGiL);
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(new oJrgNncotVFoAcZllMfwwQSjmbto(P_0.sourceJoystick, jGdBtjnfTyGBISVuamYbkGHgkejU.GDrGTDIHAEDrUJLaeBkgLTutKlcb)));
			}
		}
	}
}
