using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Platforms.Custom;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Interfaces;

namespace Rewired.InputManagers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class CustomInputManager : PlatformInputManager
	{
		protected class CbgigjeudOPmLfZNuhuMkoQNUqTC : IInputManagerJoystick, IInputManagerJoystickPublic, ITryGetLocalizedName, IGetValues<Controller.Extension>
		{
			private readonly InputSource naYSRKdUNWaJgQvKFgWQWoVroDwg;

			private readonly CustomInputSource LSPKATkuHUIFWKSUlqeCTgDRfiEq;

			private readonly List<Controller.Extension> WpzGSmfturJwDHUWcoOOYTWYOLNoA;

			private readonly ReadOnlyCollection<Controller.Extension> OoryMTZzMyAgjmOkiJcQRsDULzBr;

			private int yVmqzAcMXLLJFpfHzljJbbyNKKdF;

			private int iRhxqTVTUQLaRVhvLXXyuPoFxagk;

			private long? IrjahPAIuYRZYLklgLARGDYWPEOe;

			private int tjMelJPOuJEJrFdycoEIkYqDeRJyA;

			private Guid AsEdLpjpdmbRwIqRxmjUWlJMFGtL;

			private string UpIFdnIykTfyxObpRdXIRxOagjSp;

			private string BnnAwWSKaOptBlLjUGFSsDEPjpXEA;

			private int UmqKxYUlaXwNOwINMfNfNCYiINik;

			private int hmzTdXqBXwsZPGIJELBxntYGQjz;

			private float[] JkrRjLzMpwCDwalNbJhPYjTZmmXHA;

			private bool[] fQqdsePNJPkQftdBgBnXbUCSLjTs;

			private float[] OWHMweApHNigwXnYNTrZDnOjZtUp;

			private bool[] dXuMVBiDdUcDAchsSIARafdEuCnOc;

			private bool[] WHEtlnfugciHCTAAVmxLlLFUOYfk;

			private HardwareJoystickMap_InputManager vQpPEBldWgQNirtwCEAgZhrDzAaO;

			private readonly CustomInputSource.Joystick KeTiPvoBRVAZezfEDPXYnCnnQfpD;

			private bool IkeYRzPSBGRzAxRxCuyWjTsARpbi;

			private readonly mqusMwHkfhDRLHITITBRIMoovQtdA uYnKKjmGUeNRXpypmdaDaXvyBNjq;

			private readonly LocalizedString SdcETeiLHFVwTlTQmkwjMlOKWuTi;

			private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> ZxeGIVUDsWYfGIJQDXDlpPhtfbaJA;

			public CustomInputSource.Joystick lUjsNcGuvYseubpLUWuFSiYBWRZV => KeTiPvoBRVAZezfEDPXYnCnnQfpD;

			public Guid crSDptxkOPhgOIZsnwsIARuzdPVXA => AsEdLpjpdmbRwIqRxmjUWlJMFGtL;

			public string djcQKLbbWCqIcZsRmuxaEnGmlcNX => UpIFdnIykTfyxObpRdXIRxOagjSp;

			public string hOLHdAIaHqhwTYpKjKdydattrrje => BnnAwWSKaOptBlLjUGFSsDEPjpXEA;

			public int RtdatRyKnDrIgymJSuejuZvBKxnV
			{
				get
				{
					if (KeTiPvoBRVAZezfEDPXYnCnnQfpD == null)
					{
						return 0;
					}
					return KeTiPvoBRVAZezfEDPXYnCnnQfpD.buttonCount;
				}
			}

			public int WkFooduAZChlNDhAbFRyPxoDsTeF
			{
				get
				{
					if (KeTiPvoBRVAZezfEDPXYnCnnQfpD == null)
					{
						return 0;
					}
					return KeTiPvoBRVAZezfEDPXYnCnnQfpD.axisCount;
				}
			}

			[CustomObfuscation(rename = false)]
			int IInputManagerJoystickPublic.rewiredId
			{
				get
				{
					return yVmqzAcMXLLJFpfHzljJbbyNKKdF;
				}
				set
				{
					yVmqzAcMXLLJFpfHzljJbbyNKKdF = value;
				}
			}

			[CustomObfuscation(rename = false)]
			int IInputManagerJoystickPublic.inputManagerId
			{
				get
				{
					return iRhxqTVTUQLaRVhvLXXyuPoFxagk;
				}
				set
				{
					iRhxqTVTUQLaRVhvLXXyuPoFxagk = value;
				}
			}

			[CustomObfuscation(rename = false)]
			virtual string IInputManagerJoystickPublic.name
			{
				get
				{
					string text = ((!string.IsNullOrEmpty(KeTiPvoBRVAZezfEDPXYnCnnQfpD.customName)) ? KeTiPvoBRVAZezfEDPXYnCnnQfpD.customName : UpIFdnIykTfyxObpRdXIRxOagjSp);
					if (text == "Unknown Controller")
					{
						text = BnnAwWSKaOptBlLjUGFSsDEPjpXEA;
					}
					return text;
				}
			}

			[CustomObfuscation(rename = false)]
			long? IInputManagerJoystickPublic.systemId => IrjahPAIuYRZYLklgLARGDYWPEOe;

			[CustomObfuscation(rename = false)]
			int IInputManagerJoystickPublic.unityId => tjMelJPOuJEJrFdycoEIkYqDeRJyA;

			[CustomObfuscation(rename = false)]
			virtual Guid IInputManagerJoystickPublic.instanceGuid
			{
				get
				{
					if (!IrjahPAIuYRZYLklgLARGDYWPEOe.HasValue)
					{
						return Guid.Empty;
					}
					return MiscTools.CreateGuidHashSHA1(Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename + "_" + IrjahPAIuYRZYLklgLARGDYWPEOe);
				}
			}

			[CustomObfuscation(rename = false)]
			Guid IInputManagerJoystickPublic.persistentGuid
			{
				get
				{
					if (uYnKKjmGUeNRXpypmdaDaXvyBNjq == mqusMwHkfhDRLHITITBRIMoovQtdA.UnityInputManager)
					{
						return MiscTools.CreateGuidHashSHA1($"{BnnAwWSKaOptBlLjUGFSsDEPjpXEA}_{tjMelJPOuJEJrFdycoEIkYqDeRJyA}");
					}
					return KeTiPvoBRVAZezfEDPXYnCnnQfpD.deviceInstanceGuid;
				}
			}

			[CustomObfuscation(rename = false)]
			Controller.Extension IInputManagerJoystickPublic.extension
			{
				get
				{
					if (WpzGSmfturJwDHUWcoOOYTWYOLNoA.Count <= 0)
					{
						return null;
					}
					return WpzGSmfturJwDHUWcoOOYTWYOLNoA[0];
				}
			}

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

			int IGetValues<Controller.Extension>.GetValues(IList<Controller.Extension> results)
			{
				if (results == null)
				{
					return 0;
				}
				int count = results.Count;
				int count2 = WpzGSmfturJwDHUWcoOOYTWYOLNoA.Count;
				for (int i = 0; i < count2; i++)
				{
					results.Add(WpzGSmfturJwDHUWcoOOYTWYOLNoA[i]);
				}
				return results.Count - count;
			}

			public CbgigjeudOPmLfZNuhuMkoQNUqTC(CustomInputSource P_0, long? P_1, int P_2, CustomInputSource.Joystick P_3, InputSource P_4, IList<Controller.Extension> P_5, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_6)
			{
				if (P_0.GaOvguNDPSzOuoeCWEAmXpkVOoKq == InputSource.PS4 || P_0.GaOvguNDPSzOuoeCWEAmXpkVOoKq == InputSource.PS5)
				{
					uYnKKjmGUeNRXpypmdaDaXvyBNjq = mqusMwHkfhDRLHITITBRIMoovQtdA.UnityInputManager;
				}
				else if ((UnityTools.platform == Platform.PS4 || UnityTools.platform == Platform.PS5) && P_0.GaOvguNDPSzOuoeCWEAmXpkVOoKq == InputSource.UnityInputSystem)
				{
					uYnKKjmGUeNRXpypmdaDaXvyBNjq = mqusMwHkfhDRLHITITBRIMoovQtdA.UnityInputSystem;
				}
				else
				{
					uYnKKjmGUeNRXpypmdaDaXvyBNjq = mqusMwHkfhDRLHITITBRIMoovQtdA.None;
				}
				SdcETeiLHFVwTlTQmkwjMlOKWuTi = new LocalizedString();
				WpzGSmfturJwDHUWcoOOYTWYOLNoA = new List<Controller.Extension>();
				OoryMTZzMyAgjmOkiJcQRsDULzBr = new ReadOnlyCollection<Controller.Extension>(WpzGSmfturJwDHUWcoOOYTWYOLNoA);
				LSPKATkuHUIFWKSUlqeCTgDRfiEq = P_0;
				naYSRKdUNWaJgQvKFgWQWoVroDwg = P_4;
				IrjahPAIuYRZYLklgLARGDYWPEOe = P_1;
				KeTiPvoBRVAZezfEDPXYnCnnQfpD = P_3;
				tjMelJPOuJEJrFdycoEIkYqDeRJyA = P_2;
				if (P_5 != null)
				{
					for (int i = 0; i < P_5.Count; i++)
					{
						if (P_5[i] != null && !WpzGSmfturJwDHUWcoOOYTWYOLNoA.Contains(P_5[i]))
						{
							WpzGSmfturJwDHUWcoOOYTWYOLNoA.Add(P_5[i]);
						}
					}
				}
				ZxeGIVUDsWYfGIJQDXDlpPhtfbaJA = P_6;
				iRhxqTVTUQLaRVhvLXXyuPoFxagk = -1;
				yVmqzAcMXLLJFpfHzljJbbyNKKdF = -1;
				SCnjyWHAoiRcPvuVlkCotpcDAXdT();
				hmzTdXqBXwsZPGIJELBxntYGQjz = P_3.buttonCount;
				UmqKxYUlaXwNOwINMfNfNCYiINik = P_3.axisCount;
				AIPtkZGbwfCGfQZwmcmTTqchLFNi();
				AsEdLpjpdmbRwIqRxmjUWlJMFGtL = vQpPEBldWgQNirtwCEAgZhrDzAaO.hardwareMapIdentifier.guid;
				UpIFdnIykTfyxObpRdXIRxOagjSp = vQpPEBldWgQNirtwCEAgZhrDzAaO.controllerName;
				JkrRjLzMpwCDwalNbJhPYjTZmmXHA = new float[UmqKxYUlaXwNOwINMfNfNCYiINik];
				fQqdsePNJPkQftdBgBnXbUCSLjTs = new bool[hmzTdXqBXwsZPGIJELBxntYGQjz];
				OWHMweApHNigwXnYNTrZDnOjZtUp = new float[hmzTdXqBXwsZPGIJELBxntYGQjz];
				dXuMVBiDdUcDAchsSIARafdEuCnOc = new bool[hmzTdXqBXwsZPGIJELBxntYGQjz];
				HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)vQpPEBldWgQNirtwCEAgZhrDzAaO.map).Buttons;
				if (buttons != null)
				{
					int num = MathTools.Min(buttons.Length, hmzTdXqBXwsZPGIJELBxntYGQjz);
					for (int j = 0; j < num; j++)
					{
						if (buttons[j] != null && buttons[j].buttonInfo != null)
						{
							dXuMVBiDdUcDAchsSIARafdEuCnOc[j] = buttons[j].buttonInfo.isPressureSensitive;
						}
					}
				}
				WHEtlnfugciHCTAAVmxLlLFUOYfk = new bool[UmqKxYUlaXwNOwINMfNfNCYiINik];
				Update();
			}

			public virtual void SCnjyWHAoiRcPvuVlkCotpcDAXdT()
			{
				BnnAwWSKaOptBlLjUGFSsDEPjpXEA = KeTiPvoBRVAZezfEDPXYnCnnQfpD.deviceName;
			}

			[CustomObfuscation(rename = false)]
			public virtual void Update()
			{
				if (KeTiPvoBRVAZezfEDPXYnCnnQfpD.isConnected)
				{
					tgElTVlLtyXyXCjMAUSsuEeHLlkJ();
					VhbBYibMcHJPeUrDaqXdVGGPNZCcA();
				}
			}

			void IInputManagerJoystick.Update()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Update
				this.Update();
			}

			public virtual int MZApUgUEaRdYLGGhKAoDcpsEKexU(CbgigjeudOPmLfZNuhuMkoQNUqTC P_0)
			{
				if (P_0.BnnAwWSKaOptBlLjUGFSsDEPjpXEA == BnnAwWSKaOptBlLjUGFSsDEPjpXEA && P_0.IrjahPAIuYRZYLklgLARGDYWPEOe == IrjahPAIuYRZYLklgLARGDYWPEOe)
				{
					return 2;
				}
				if (P_0.BnnAwWSKaOptBlLjUGFSsDEPjpXEA == BnnAwWSKaOptBlLjUGFSsDEPjpXEA)
				{
					return 1;
				}
				return 0;
			}

			protected virtual void jAKzatuLzrDEodtkEIAjPLPqkbsEb(BridgedControllerHWInfo P_0)
			{
				P_0.inputManagerSource = naYSRKdUNWaJgQvKFgWQWoVroDwg;
				P_0.inputSource = naYSRKdUNWaJgQvKFgWQWoVroDwg;
				P_0.hardwareIdentifier = ICSiJDSBXKfbZIlawJMlLJvtvdGSA();
				P_0.hardwareAxisCount = UmqKxYUlaXwNOwINMfNfNCYiINik;
				P_0.hardwareButtonCount = hmzTdXqBXwsZPGIJELBxntYGQjz;
				P_0.hardwareHatCount = 0;
				P_0.hw_productName = BnnAwWSKaOptBlLjUGFSsDEPjpXEA;
				P_0.hw_supportsVibration = KeTiPvoBRVAZezfEDPXYnCnnQfpD.supportsVibration;
				P_0.userCustomIdentifier = KeTiPvoBRVAZezfEDPXYnCnnQfpD.customIdentifier;
				P_0.tags = KeTiPvoBRVAZezfEDPXYnCnnQfpD.MatchingTags;
			}

			protected virtual void EfikEPkNLsgKiyroyECUYrVGjEbm(BridgedController P_0)
			{
				jAKzatuLzrDEodtkEIAjPLPqkbsEb(P_0);
				P_0.sourceJoystick = this;
				P_0.gameHardwareMap = vQpPEBldWgQNirtwCEAgZhrDzAaO.ToGameHardwareControllerMap();
				P_0.instanceName = BnnAwWSKaOptBlLjUGFSsDEPjpXEA;
				P_0.productName = BnnAwWSKaOptBlLjUGFSsDEPjpXEA;
				P_0.isXInputDevice = false;
				P_0.axisCount = UmqKxYUlaXwNOwINMfNfNCYiINik;
				P_0.buttonCount = hmzTdXqBXwsZPGIJELBxntYGQjz;
				P_0.controllerTypeGuid = AsEdLpjpdmbRwIqRxmjUWlJMFGtL;
				P_0.customInputSource = LSPKATkuHUIFWKSUlqeCTgDRfiEq;
				P_0.controllerExtensions = OoryMTZzMyAgjmOkiJcQRsDULzBr;
				P_0.isButtonPressureSensitive = new bool[dXuMVBiDdUcDAchsSIARafdEuCnOc.Length];
				for (int i = 0; i < dXuMVBiDdUcDAchsSIARafdEuCnOc.Length; i++)
				{
					P_0.isButtonPressureSensitive[i] = dXuMVBiDdUcDAchsSIARafdEuCnOc[i];
				}
			}

			[CustomObfuscation(rename = false)]
			public virtual void FillData(ControllerDataUpdater dataUpdater)
			{
				if (UmqKxYUlaXwNOwINMfNfNCYiINik != dataUpdater.axisCount || hmzTdXqBXwsZPGIJELBxntYGQjz != dataUpdater.buttonCount)
				{
					throw new Exception("This controller signature does not match the data object!");
				}
				for (int i = 0; i < UmqKxYUlaXwNOwINMfNfNCYiINik; i++)
				{
					dataUpdater.axisValues[i] = JkrRjLzMpwCDwalNbJhPYjTZmmXHA[i];
					if (dataUpdater.axisHasBeenPressedOSXLinux[i] != WHEtlnfugciHCTAAVmxLlLFUOYfk[i])
					{
						dataUpdater.axisHasBeenPressedOSXLinux[i] = WHEtlnfugciHCTAAVmxLlLFUOYfk[i];
					}
				}
				for (int j = 0; j < hmzTdXqBXwsZPGIJELBxntYGQjz; j++)
				{
					if (dXuMVBiDdUcDAchsSIARafdEuCnOc[j])
					{
						dataUpdater.buttonPressureValues[j] = OWHMweApHNigwXnYNTrZDnOjZtUp[j];
					}
					dataUpdater.buttonValues[j] = fQqdsePNJPkQftdBgBnXbUCSLjTs[j];
				}
				if (IkeYRzPSBGRzAxRxCuyWjTsARpbi && !dataUpdater.hasReceivedInput)
				{
					dataUpdater.hasReceivedInput = true;
				}
			}

			void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
			{
				//ILSpy generated this explicit interface implementation from .override directive in FillData
				this.FillData(dataUpdater);
			}

			private BridgedControllerHWInfo egsHIaWXNiHHrHNOsCYvFQhYxPTzA()
			{
				BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
				jAKzatuLzrDEodtkEIAjPLPqkbsEb(bridgedControllerHWInfo);
				return bridgedControllerHWInfo;
			}

			[CustomObfuscation(rename = false)]
			public virtual BridgedController ToBridgedController()
			{
				BridgedController bridgedController = new BridgedController();
				EfikEPkNLsgKiyroyECUYrVGjEbm(bridgedController);
				return bridgedController;
			}

			BridgedController IInputManagerJoystick.ToBridgedController()
			{
				//ILSpy generated this explicit interface implementation from .override directive in ToBridgedController
				return this.ToBridgedController();
			}

			[CustomObfuscation(rename = false)]
			public virtual ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
			{
				return new ControllerDisconnectedEventArgs(yVmqzAcMXLLJFpfHzljJbbyNKKdF);
			}

			ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
			{
				//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
				return this.ToControllerDisconnectedEventArgs();
			}

			protected virtual void tgElTVlLtyXyXCjMAUSsuEeHLlkJ()
			{
				HardwareJoystickMap.Platform_Custom.Axis[] axes = ((HardwareJoystickMap.Platform_Custom)vQpPEBldWgQNirtwCEAgZhrDzAaO.map).Axes;
				if (axes == null)
				{
					return;
				}
				for (int i = 0; i < axes.Length; i++)
				{
					if (axes[i] == null)
					{
						continue;
					}
					if (i >= UmqKxYUlaXwNOwINMfNfNCYiINik)
					{
						throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
					}
					JkrRjLzMpwCDwalNbJhPYjTZmmXHA[i] = RHWXiTfqrltvvLkivLWIMwVZJVdY(axes[i]);
					if (!WHEtlnfugciHCTAAVmxLlLFUOYfk[i])
					{
						if (axes[i].sourceType == 1)
						{
							WHEtlnfugciHCTAAVmxLlLFUOYfk[i] = DpVEPrtBPSGjyujKATqgqqMhMlvw(axes[i].sourceAxis) != 0f;
						}
						else
						{
							WHEtlnfugciHCTAAVmxLlLFUOYfk[i] = true;
						}
					}
					if (!IkeYRzPSBGRzAxRxCuyWjTsARpbi && JkrRjLzMpwCDwalNbJhPYjTZmmXHA[i] != 0f)
					{
						IkeYRzPSBGRzAxRxCuyWjTsARpbi = true;
					}
				}
			}

			protected virtual void VhbBYibMcHJPeUrDaqXdVGGPNZCcA()
			{
				HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)vQpPEBldWgQNirtwCEAgZhrDzAaO.map).Buttons;
				if (buttons == null)
				{
					return;
				}
				for (int i = 0; i < buttons.Length; i++)
				{
					if (i >= hmzTdXqBXwsZPGIJELBxntYGQjz)
					{
						throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
					}
					fQqdsePNJPkQftdBgBnXbUCSLjTs[i] = PoHmbUzaWFuBXRcvuIdFzglPAUobA(buttons[i], out OWHMweApHNigwXnYNTrZDnOjZtUp[i]);
					if (!IkeYRzPSBGRzAxRxCuyWjTsARpbi && (fQqdsePNJPkQftdBgBnXbUCSLjTs[i] || (dXuMVBiDdUcDAchsSIARafdEuCnOc[i] && OWHMweApHNigwXnYNTrZDnOjZtUp[i] != 0f)))
					{
						IkeYRzPSBGRzAxRxCuyWjTsARpbi = true;
					}
				}
			}

			protected virtual bool PoHmbUzaWFuBXRcvuIdFzglPAUobA(HardwareJoystickMap.Platform_Custom.Button P_0, out float P_1)
			{
				if (P_0.sourceType == 0)
				{
					bool result = LtjaKHmtPYWZdizzhcEBHjhcPPTd(P_0.sourceButton, out P_1);
					if (MathTools.Abs(P_1) <= P_0.axisDeadZone)
					{
						P_1 = 0f;
					}
					return result;
				}
				if (P_0.sourceType == 1)
				{
					P_1 = 0f;
					float num = DpVEPrtBPSGjyujKATqgqqMhMlvw(P_0.sourceAxis);
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
					if (num < 0f)
					{
						num *= -1f;
					}
					if (num > 1f)
					{
						num = 1f;
					}
					P_1 = num;
					return true;
				}
				if (P_0.sourceType == 100)
				{
					P_1 = 0f;
					CustomCalculation customCalculation = P_0.customCalculation;
					if (customCalculation == null)
					{
						return false;
					}
					if (customCalculation.ResultType != TypeWrapper.DataType.Single)
					{
						return false;
					}
					HardwareJoystickMap.Platform_Custom.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
					if (customCalculationSourceData == null)
					{
						return false;
					}
					for (int i = 0; i < customCalculationSourceData.Length; i++)
					{
						if (customCalculationSourceData[i] == null)
						{
							continue;
						}
						switch ((HardwareElementSourceTypeWithHat)customCalculationSourceData[i].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Button:
						{
							if (tvmgOpkpPbvESiuUUjEoBSJkUYGcc(customCalculationSourceData[i], out var _, out var item2))
							{
								customCalculation.AddData(item2);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Axis:
						{
							if (etnftomAQjAjJBtRiejTWtpCdMQJ(customCalculationSourceData[i], out var item))
							{
								customCalculation.AddData(item);
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
					P_1 = customCalculation.Result;
					return P_1 > 0f;
				}
				P_1 = 0f;
				return false;
			}

			protected virtual float RHWXiTfqrltvvLkivLWIMwVZJVdY(HardwareJoystickMap.Platform_Custom.Axis P_0)
			{
				if (P_0.sourceType == 1)
				{
					return DpVEPrtBPSGjyujKATqgqqMhMlvw(P_0.sourceAxis);
				}
				if (P_0.sourceType == 0)
				{
					bool num = PtDaTeIzhVydASjEjoANreORUVgA(P_0.sourceButton);
					float num2;
					bool flag = LtjaKHmtPYWZdizzhcEBHjhcPPTd(P_0.sourceButton, out num2);
					if (num)
					{
						if (num2 < 0f)
						{
							num2 = 0f;
						}
						if (P_0.buttonAxisContribution == Pole.Negative)
						{
							num2 *= -1f;
						}
					}
					else
					{
						if (!flag)
						{
							return 0f;
						}
						num2 = ((P_0.buttonAxisContribution != Pole.Positive) ? (-1f) : 1f);
					}
					return num2;
				}
				if (P_0.sourceType == 100)
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
					HardwareJoystickMap.Platform_Custom.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
					if (customCalculationSourceData == null)
					{
						return 0f;
					}
					for (int i = 0; i < customCalculationSourceData.Length; i++)
					{
						if (customCalculationSourceData[i] == null)
						{
							continue;
						}
						switch ((HardwareElementSourceTypeWithHat)customCalculationSourceData[i].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Button:
						{
							if (tvmgOpkpPbvESiuUUjEoBSJkUYGcc(customCalculationSourceData[i], out var _, out var item2))
							{
								customCalculation.AddData(item2);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Axis:
						{
							if (etnftomAQjAjJBtRiejTWtpCdMQJ(customCalculationSourceData[i], out var item))
							{
								customCalculation.AddData(item);
							}
							break;
						}
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
				throw new NotImplementedException();
			}

			protected virtual float DpVEPrtBPSGjyujKATqgqqMhMlvw(int P_0)
			{
				return KeTiPvoBRVAZezfEDPXYnCnnQfpD.GetAxisValue(P_0);
			}

			protected virtual bool LtjaKHmtPYWZdizzhcEBHjhcPPTd(int P_0, out float P_1)
			{
				KeTiPvoBRVAZezfEDPXYnCnnQfpD.DTOFtSrBjOzJoQqGgxAfQNpcOszS(P_0, out var result, out P_1);
				return result;
			}

			private bool PtDaTeIzhVydASjEjoANreORUVgA(int P_0)
			{
				return KeTiPvoBRVAZezfEDPXYnCnnQfpD.GetElement<CustomInputSource.Button>(P_0)?.isPressureSensitive ?? false;
			}

			protected virtual CustomInputSource.Element yTvdtzPZbaisVIVSqHCOpQhocllg(HardwareJoystickMap.Platform_Custom.Button P_0)
			{
				if (P_0 == null)
				{
					return null;
				}
				if (P_0.sourceType == 0)
				{
					int sourceButton = P_0.sourceButton;
					if ((uint)sourceButton >= (uint)KeTiPvoBRVAZezfEDPXYnCnnQfpD.buttonCount)
					{
						return null;
					}
					return KeTiPvoBRVAZezfEDPXYnCnnQfpD.Buttons[sourceButton];
				}
				if (P_0.sourceType == 1)
				{
					int sourceAxis = P_0.sourceAxis;
					if ((uint)sourceAxis >= (uint)KeTiPvoBRVAZezfEDPXYnCnnQfpD.axisCount)
					{
						return null;
					}
					return KeTiPvoBRVAZezfEDPXYnCnnQfpD.Axes[sourceAxis];
				}
				return null;
			}

			protected virtual CustomInputSource.Element KENdahHHmLIcvxzdkPvlivCksdUWA(HardwareJoystickMap.Platform_Custom.Axis P_0)
			{
				if (P_0 == null)
				{
					return null;
				}
				if (P_0.sourceType == 1)
				{
					int sourceAxis = P_0.sourceAxis;
					if ((uint)sourceAxis >= (uint)KeTiPvoBRVAZezfEDPXYnCnnQfpD.axisCount)
					{
						return null;
					}
					return KeTiPvoBRVAZezfEDPXYnCnnQfpD.Axes[sourceAxis];
				}
				if (P_0.sourceType == 0)
				{
					int sourceButton = P_0.sourceButton;
					if ((uint)sourceButton >= (uint)KeTiPvoBRVAZezfEDPXYnCnnQfpD.buttonCount)
					{
						return null;
					}
					return KeTiPvoBRVAZezfEDPXYnCnnQfpD.Buttons[sourceButton];
				}
				return null;
			}

			private bool tvmgOpkpPbvESiuUUjEoBSJkUYGcc(HardwareJoystickMap.Platform_Custom.CustomCalculationSourceData P_0, out bool P_1, out float P_2)
			{
				P_1 = false;
				if (P_0.sourceType != 0)
				{
					P_2 = 0f;
					return false;
				}
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= KeTiPvoBRVAZezfEDPXYnCnnQfpD.buttonCount)
				{
					P_2 = 0f;
					return false;
				}
				P_1 = KeTiPvoBRVAZezfEDPXYnCnnQfpD.GetButtonValue(sourceButton);
				P_2 = KeTiPvoBRVAZezfEDPXYnCnnQfpD.GetButtonFloatValue(sourceButton);
				return true;
			}

			private bool etnftomAQjAjJBtRiejTWtpCdMQJ(HardwareJoystickMap.Platform_Custom.CustomCalculationSourceData P_0, out float P_1)
			{
				P_1 = 0f;
				if (P_0.sourceType != 1)
				{
					return false;
				}
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= KeTiPvoBRVAZezfEDPXYnCnnQfpD.axisCount)
				{
					return false;
				}
				P_1 = KeTiPvoBRVAZezfEDPXYnCnnQfpD.GetAxisValue(sourceAxis);
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
					P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, -1f, 1f, P_0.axisDeadZone, 0f, P_0.invert, applySensitivity: false, AxisSensitivityType.Multiplier, 1f, null);
				}
				else if (P_0.axisCalibrationType == AxisCalibrationType.Custom)
				{
					P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, P_0.axisMin, P_0.axisMax, P_0.axisDeadZone, 0f, P_0.invert, applySensitivity: false, AxisSensitivityType.Multiplier, 1f, null);
				}
				else if (P_0.axisCalibrationType == AxisCalibrationType.Uncalibrated && P_0.axisDeadZone > 0f && MathTools.Abs(P_1) <= P_0.axisDeadZone)
				{
					P_1 = 0f;
				}
				return true;
			}

			private void AIPtkZGbwfCGfQZwmcmTTqchLFNi()
			{
				vQpPEBldWgQNirtwCEAgZhrDzAaO = ZxeGIVUDsWYfGIJQDXDlpPhtfbaJA(egsHIaWXNiHHrHNOsCYvFQhYxPTzA());
				if (vQpPEBldWgQNirtwCEAgZhrDzAaO != null)
				{
					HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)vQpPEBldWgQNirtwCEAgZhrDzAaO.map).Buttons;
					if (buttons != null)
					{
						for (int i = 0; i < buttons.Length; i++)
						{
							if (buttons[i] != null && buttons[i].buttonInfo != null)
							{
								CustomInputSource.Element element = yTvdtzPZbaisVIVSqHCOpQhocllg(buttons[i]);
								if (element != null && element.excludeFromPolling)
								{
									buttons[i].buttonInfo.excludeFromPolling = true;
								}
							}
						}
					}
					HardwareJoystickMap.Platform_Custom.Axis[] axes = ((HardwareJoystickMap.Platform_Custom)vQpPEBldWgQNirtwCEAgZhrDzAaO.map).Axes;
					if (axes != null)
					{
						for (int j = 0; j < axes.Length; j++)
						{
							if (axes[j] != null && axes[j].axisInfo != null)
							{
								CustomInputSource.Element element = KENdahHHmLIcvxzdkPvlivCksdUWA(axes[j]);
								if (element != null && element.excludeFromPolling)
								{
									axes[j].axisInfo.excludeFromPolling = true;
								}
							}
						}
					}
				}
				chOHGtfvuAQaudAfJIvMZxfTxRhM(vQpPEBldWgQNirtwCEAgZhrDzAaO);
				if (vQpPEBldWgQNirtwCEAgZhrDzAaO == null)
				{
					Logger.LogError("Default hardware map not found!");
					return;
				}
				if (KeTiPvoBRVAZezfEDPXYnCnnQfpD is IInputManagerHardwareJoystickMapHandler)
				{
					try
					{
						((IInputManagerHardwareJoystickMapHandler)KeTiPvoBRVAZezfEDPXYnCnnQfpD).InitializeHardwareJoystickMap(vQpPEBldWgQNirtwCEAgZhrDzAaO);
					}
					catch
					{
					}
				}
				UmqKxYUlaXwNOwINMfNfNCYiINik = vQpPEBldWgQNirtwCEAgZhrDzAaO.axisCount;
				hmzTdXqBXwsZPGIJELBxntYGQjz = vQpPEBldWgQNirtwCEAgZhrDzAaO.buttonCount;
			}

			protected virtual void chOHGtfvuAQaudAfJIvMZxfTxRhM(HardwareJoystickMap_InputManager P_0)
			{
			}

			protected virtual string ICSiJDSBXKfbZIlawJMlLJvtvdGSA()
			{
				string text = BnnAwWSKaOptBlLjUGFSsDEPjpXEA;
				if (uYnKKjmGUeNRXpypmdaDaXvyBNjq != mqusMwHkfhDRLHITITBRIMoovQtdA.None)
				{
					MatchCollection matchCollection = Regex.Matches(text, "^(.*) ([0-9]+)$");
					if (matchCollection.Count > 0 && matchCollection[0].Groups != null && matchCollection[0].Groups.Count > 2)
					{
						text = matchCollection[0].Groups[1].Value;
					}
				}
				if (ReInput.currentPlatform == Platform.Webplayer)
				{
					return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{naYSRKdUNWaJgQvKFgWQWoVroDwg.ToString()}{text}");
				}
				if (XKZBcbGtoHHVfKdsghmQDHfhSpIfA.uiJzvtjjXxeMafDzRvVcrucZLjqaA)
				{
					return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{XKZBcbGtoHHVfKdsghmQDHfhSpIfA.dFNhGsqxezFQICCacMqUaSkfXRCuB()}{text}");
				}
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{naYSRKdUNWaJgQvKFgWQWoVroDwg.ToString()}{text}");
			}

			protected virtual bool TryGetLocalizedName(out string value)
			{
				if (!(KeTiPvoBRVAZezfEDPXYnCnnQfpD is ITryGetLocalizedName))
				{
					if (uYnKKjmGUeNRXpypmdaDaXvyBNjq != mqusMwHkfhDRLHITITBRIMoovQtdA.None)
					{
						if ((LocalizationManager.GetAndUpdateLocalizedString(SdcETeiLHFVwTlTQmkwjMlOKWuTi, vQpPEBldWgQNirtwCEAgZhrDzAaO.deviceLocalizationInfo.parentKeys, "controller", Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename, out value) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
						{
							string text = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename;
							string text2 = null;
							MatchCollection matchCollection = Regex.Matches(text, "^(.*) ([0-9]+)$");
							if (matchCollection.Count > 0 && matchCollection[0].Groups != null && matchCollection[0].Groups.Count > 2)
							{
								text = matchCollection[0].Groups[1].Value;
								text2 = matchCollection[0].Groups[2].Value;
							}
							if (!string.IsNullOrEmpty(text2))
							{
								value = $"{text} {text2}";
							}
							SdcETeiLHFVwTlTQmkwjMlOKWuTi.cachedValue = value;
						}
						return true;
					}
					value = null;
					return false;
				}
				return ((ITryGetLocalizedName)KeTiPvoBRVAZezfEDPXYnCnnQfpD).TryGetLocalizedName(out value);
			}

			bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
			{
				return TryGetLocalizedName(out value);
			}

			public static int uvvJFBgBxjErYmokFLmnBKLeWgjJ(CbgigjeudOPmLfZNuhuMkoQNUqTC P_0, CbgigjeudOPmLfZNuhuMkoQNUqTC P_1)
			{
				if (P_0.iRhxqTVTUQLaRVhvLXXyuPoFxagk < P_1.iRhxqTVTUQLaRVhvLXXyuPoFxagk)
				{
					return -1;
				}
				if (P_0.iRhxqTVTUQLaRVhvLXXyuPoFxagk > P_1.iRhxqTVTUQLaRVhvLXXyuPoFxagk)
				{
					return 1;
				}
				return 0;
			}

			public static int wuLJnMCVwshJfqUXSwaYeUxYsaCD(CbgigjeudOPmLfZNuhuMkoQNUqTC P_0, CbgigjeudOPmLfZNuhuMkoQNUqTC P_1)
			{
				if (P_0.IrjahPAIuYRZYLklgLARGDYWPEOe < P_1.IrjahPAIuYRZYLklgLARGDYWPEOe)
				{
					return -1;
				}
				if (P_0.IrjahPAIuYRZYLklgLARGDYWPEOe > P_1.IrjahPAIuYRZYLklgLARGDYWPEOe)
				{
					return 1;
				}
				return 0;
			}
		}

		private class cGAokODTyUtikxOCDPmRbEISvHRC
		{
			public enum BehBVQGYUTmsadtRIkaRdGStSZLgb
			{
				Exact = 0,
				Approximate = 1
			}

			public class YAMxaNjZtHfRYiSOoltQlDObUnMq
			{
				public int yeeiBCVbIzECXdvWdeqghFNwvGnjA;

				public long? iejsNcrYsQTTbRNDIlfkHdjuBBsX;

				public string otxaoxgzihTAOCsrFcPTFPXHEzEQB;

				public int BtlbnWwncHUmCjWyOEFZBVrrONBV;

				public int QKTFlGeGnjWeqsKkNCAryRAUQDmDb;

				public int PCGydfEbKHaDjGsZVuSuKnyKIwmXA;

				public YAMxaNjZtHfRYiSOoltQlDObUnMq(int P_0, long? P_1, string P_2, int P_3, int P_4, int P_5)
				{
					yeeiBCVbIzECXdvWdeqghFNwvGnjA = P_0;
					iejsNcrYsQTTbRNDIlfkHdjuBBsX = P_1;
					otxaoxgzihTAOCsrFcPTFPXHEzEQB = P_2;
					BtlbnWwncHUmCjWyOEFZBVrrONBV = P_3;
					QKTFlGeGnjWeqsKkNCAryRAUQDmDb = P_4;
					PCGydfEbKHaDjGsZVuSuKnyKIwmXA = P_5;
				}

				public bool SITQIUTCmRaoVvPjKmrcgigthTYl(CbgigjeudOPmLfZNuhuMkoQNUqTC P_0, BehBVQGYUTmsadtRIkaRdGStSZLgb P_1)
				{
					if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == yeeiBCVbIzECXdvWdeqghFNwvGnjA)
					{
						return true;
					}
					if (P_0.RtdatRyKnDrIgymJSuejuZvBKxnV != QKTFlGeGnjWeqsKkNCAryRAUQDmDb)
					{
						return false;
					}
					if (P_0.WkFooduAZChlNDhAbFRyPxoDsTeF != PCGydfEbKHaDjGsZVuSuKnyKIwmXA)
					{
						return false;
					}
					switch (P_1)
					{
					case BehBVQGYUTmsadtRIkaRdGStSZLgb.Exact:
						if (iejsNcrYsQTTbRNDIlfkHdjuBBsX == P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId)
						{
							return otxaoxgzihTAOCsrFcPTFPXHEzEQB == P_0.hOLHdAIaHqhwTYpKjKdydattrrje;
						}
						return false;
					case BehBVQGYUTmsadtRIkaRdGStSZLgb.Approximate:
						return otxaoxgzihTAOCsrFcPTFPXHEzEQB == P_0.hOLHdAIaHqhwTYpKjKdydattrrje;
					default:
						throw new NotImplementedException();
					}
				}
			}

			private sealed class VlNUMkaooEaxbBPReAxHPhfSqQiBA : IEnumerable<YAMxaNjZtHfRYiSOoltQlDObUnMq>, IEnumerable, IEnumerator<YAMxaNjZtHfRYiSOoltQlDObUnMq>, IEnumerator, IDisposable
			{
				private int qASjgUOJNaSQDlLCThpTiWcgLmvOA;

				private YAMxaNjZtHfRYiSOoltQlDObUnMq ktZhHURANqQomtDjwqwMIkkflsMC;

				private int XoGjyeHUGfKhIhoOemmDpCtxgubr;

				public cGAokODTyUtikxOCDPmRbEISvHRC jhcVsWUJDLQfSHOSOkLRJKIweTWeA;

				private CbgigjeudOPmLfZNuhuMkoQNUqTC wUExLdDOCdqSpFRGvPgkAwDNkhhs;

				public CbgigjeudOPmLfZNuhuMkoQNUqTC CSrDfzkqgwqFNHARcAkJhreLdHwC;

				private BehBVQGYUTmsadtRIkaRdGStSZLgb oXKCICEgOQUcZPPKUpqsgdScNTPqA;

				public BehBVQGYUTmsadtRIkaRdGStSZLgb qJlukVideZITXlTwpzYkeDajiNYz;

				private int hHjnJSMiOtvNMkFZopKyNdGFCzCFA;

				private int OUvIMENNjQrWbSaKemoAzvbjfMmr;

				YAMxaNjZtHfRYiSOoltQlDObUnMq IEnumerator<YAMxaNjZtHfRYiSOoltQlDObUnMq>.Current
				{
					[DebuggerHidden]
					get
					{
						return ktZhHURANqQomtDjwqwMIkkflsMC;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ktZhHURANqQomtDjwqwMIkkflsMC;
					}
				}

				[DebuggerHidden]
				public VlNUMkaooEaxbBPReAxHPhfSqQiBA(int P_0)
				{
					qASjgUOJNaSQDlLCThpTiWcgLmvOA = P_0;
					XoGjyeHUGfKhIhoOemmDpCtxgubr = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					qASjgUOJNaSQDlLCThpTiWcgLmvOA = -2;
				}

				private bool MoveNext()
				{
					int num = qASjgUOJNaSQDlLCThpTiWcgLmvOA;
					cGAokODTyUtikxOCDPmRbEISvHRC cGAokODTyUtikxOCDPmRbEISvHRC2 = jhcVsWUJDLQfSHOSOkLRJKIweTWeA;
					if (num != 0)
					{
						if (num != 1)
						{
							return false;
						}
						qASjgUOJNaSQDlLCThpTiWcgLmvOA = -1;
						goto IL_0083;
					}
					qASjgUOJNaSQDlLCThpTiWcgLmvOA = -1;
					hHjnJSMiOtvNMkFZopKyNdGFCzCFA = cGAokODTyUtikxOCDPmRbEISvHRC2.uvyhKWZbtpUDSLfIdgBwiZrjytRoA.Count;
					OUvIMENNjQrWbSaKemoAzvbjfMmr = 0;
					goto IL_0093;
					IL_0083:
					OUvIMENNjQrWbSaKemoAzvbjfMmr++;
					goto IL_0093;
					IL_0093:
					if (OUvIMENNjQrWbSaKemoAzvbjfMmr < hHjnJSMiOtvNMkFZopKyNdGFCzCFA)
					{
						if (cGAokODTyUtikxOCDPmRbEISvHRC2.uvyhKWZbtpUDSLfIdgBwiZrjytRoA[OUvIMENNjQrWbSaKemoAzvbjfMmr].SITQIUTCmRaoVvPjKmrcgigthTYl(wUExLdDOCdqSpFRGvPgkAwDNkhhs, oXKCICEgOQUcZPPKUpqsgdScNTPqA))
						{
							ktZhHURANqQomtDjwqwMIkkflsMC = cGAokODTyUtikxOCDPmRbEISvHRC2.uvyhKWZbtpUDSLfIdgBwiZrjytRoA[OUvIMENNjQrWbSaKemoAzvbjfMmr];
							qASjgUOJNaSQDlLCThpTiWcgLmvOA = 1;
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
				IEnumerator<YAMxaNjZtHfRYiSOoltQlDObUnMq> IEnumerable<YAMxaNjZtHfRYiSOoltQlDObUnMq>.GetEnumerator()
				{
					VlNUMkaooEaxbBPReAxHPhfSqQiBA vlNUMkaooEaxbBPReAxHPhfSqQiBA;
					if (qASjgUOJNaSQDlLCThpTiWcgLmvOA == -2 && XoGjyeHUGfKhIhoOemmDpCtxgubr == Environment.CurrentManagedThreadId)
					{
						qASjgUOJNaSQDlLCThpTiWcgLmvOA = 0;
						vlNUMkaooEaxbBPReAxHPhfSqQiBA = this;
					}
					else
					{
						vlNUMkaooEaxbBPReAxHPhfSqQiBA = new VlNUMkaooEaxbBPReAxHPhfSqQiBA(0);
						vlNUMkaooEaxbBPReAxHPhfSqQiBA.jhcVsWUJDLQfSHOSOkLRJKIweTWeA = jhcVsWUJDLQfSHOSOkLRJKIweTWeA;
					}
					vlNUMkaooEaxbBPReAxHPhfSqQiBA.wUExLdDOCdqSpFRGvPgkAwDNkhhs = CSrDfzkqgwqFNHARcAkJhreLdHwC;
					vlNUMkaooEaxbBPReAxHPhfSqQiBA.oXKCICEgOQUcZPPKUpqsgdScNTPqA = qJlukVideZITXlTwpzYkeDajiNYz;
					return vlNUMkaooEaxbBPReAxHPhfSqQiBA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<YAMxaNjZtHfRYiSOoltQlDObUnMq>)this).GetEnumerator();
				}
			}

			private List<YAMxaNjZtHfRYiSOoltQlDObUnMq> uvyhKWZbtpUDSLfIdgBwiZrjytRoA;

			public int pQZQDlASSEUqfpWQHOYMEtOvEMEs => uvyhKWZbtpUDSLfIdgBwiZrjytRoA.Count;

			public cGAokODTyUtikxOCDPmRbEISvHRC()
			{
				uvyhKWZbtpUDSLfIdgBwiZrjytRoA = new List<YAMxaNjZtHfRYiSOoltQlDObUnMq>();
			}

			public void xmUddNwcTANOZUIVAnWJuFAtwRBh(CbgigjeudOPmLfZNuhuMkoQNUqTC P_0)
			{
				if (P_0 == null)
				{
					return;
				}
				int count = uvyhKWZbtpUDSLfIdgBwiZrjytRoA.Count;
				for (int i = 0; i < count; i++)
				{
					if (uvyhKWZbtpUDSLfIdgBwiZrjytRoA[i].SITQIUTCmRaoVvPjKmrcgigthTYl(P_0, BehBVQGYUTmsadtRIkaRdGStSZLgb.Exact))
					{
						uvyhKWZbtpUDSLfIdgBwiZrjytRoA[i].yeeiBCVbIzECXdvWdeqghFNwvGnjA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
						uvyhKWZbtpUDSLfIdgBwiZrjytRoA[i].iejsNcrYsQTTbRNDIlfkHdjuBBsX = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId;
						uvyhKWZbtpUDSLfIdgBwiZrjytRoA[i].otxaoxgzihTAOCsrFcPTFPXHEzEQB = P_0.hOLHdAIaHqhwTYpKjKdydattrrje;
						uvyhKWZbtpUDSLfIdgBwiZrjytRoA[i].BtlbnWwncHUmCjWyOEFZBVrrONBV = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
						uvyhKWZbtpUDSLfIdgBwiZrjytRoA[i].QKTFlGeGnjWeqsKkNCAryRAUQDmDb = P_0.RtdatRyKnDrIgymJSuejuZvBKxnV;
						uvyhKWZbtpUDSLfIdgBwiZrjytRoA[i].PCGydfEbKHaDjGsZVuSuKnyKIwmXA = P_0.WkFooduAZChlNDhAbFRyPxoDsTeF;
						hPJwxoKHwGZWIxFEmJOJJazoFGgc(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, i);
						return;
					}
				}
				uvyhKWZbtpUDSLfIdgBwiZrjytRoA.Add(new YAMxaNjZtHfRYiSOoltQlDObUnMq(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId, P_0.hOLHdAIaHqhwTYpKjKdydattrrje, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId, P_0.RtdatRyKnDrIgymJSuejuZvBKxnV, P_0.WkFooduAZChlNDhAbFRyPxoDsTeF));
				hPJwxoKHwGZWIxFEmJOJJazoFGgc(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, uvyhKWZbtpUDSLfIdgBwiZrjytRoA.Count - 1);
			}

			public bool ywdDYtuWCOvdXhFPvYUZwLhItXDV(CbgigjeudOPmLfZNuhuMkoQNUqTC P_0, BehBVQGYUTmsadtRIkaRdGStSZLgb P_1)
			{
				int count = uvyhKWZbtpUDSLfIdgBwiZrjytRoA.Count;
				for (int i = 0; i < count; i++)
				{
					if (uvyhKWZbtpUDSLfIdgBwiZrjytRoA[i].SITQIUTCmRaoVvPjKmrcgigthTYl(P_0, P_1))
					{
						return true;
					}
				}
				return false;
			}

			[IteratorStateMachine(typeof(VlNUMkaooEaxbBPReAxHPhfSqQiBA))]
			public IEnumerable<YAMxaNjZtHfRYiSOoltQlDObUnMq> dvnPUBNOBjVuwhQVqrjzRCTEBORw(CbgigjeudOPmLfZNuhuMkoQNUqTC P_0, BehBVQGYUTmsadtRIkaRdGStSZLgb P_1)
			{
				return new VlNUMkaooEaxbBPReAxHPhfSqQiBA(-2)
				{
					jhcVsWUJDLQfSHOSOkLRJKIweTWeA = this,
					CSrDfzkqgwqFNHARcAkJhreLdHwC = P_0,
					qJlukVideZITXlTwpzYkeDajiNYz = P_1
				};
			}

			public int cHbYByEglyDnHpIUkQHFeCneEMmN(YAMxaNjZtHfRYiSOoltQlDObUnMq P_0)
			{
				int count = uvyhKWZbtpUDSLfIdgBwiZrjytRoA.Count;
				for (int i = 0; i < count; i++)
				{
					if (uvyhKWZbtpUDSLfIdgBwiZrjytRoA[i] == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			private void hPJwxoKHwGZWIxFEmJOJJazoFGgc(int P_0, int P_1)
			{
				for (int num = uvyhKWZbtpUDSLfIdgBwiZrjytRoA.Count - 1; num >= 0; num--)
				{
					if (num != P_1 && uvyhKWZbtpUDSLfIdgBwiZrjytRoA[num].yeeiBCVbIzECXdvWdeqghFNwvGnjA == P_0)
					{
						uvyhKWZbtpUDSLfIdgBwiZrjytRoA.RemoveAt(num);
					}
				}
			}
		}

		private enum mqusMwHkfhDRLHITITBRIMoovQtdA
		{
			None = 0,
			UnityInputManager = 1,
			UnityInputSystem = 2
		}

		private List<CbgigjeudOPmLfZNuhuMkoQNUqTC> AGFTZyOFvxpYzlVitTemPpYilxth;

		private int LLhdyNDnBKosasqAkQBnmyWsRVEo;

		private cGAokODTyUtikxOCDPmRbEISvHRC kPggIFAFqMpzHKMhHCBEOzQYJfEpA;

		private UpdateLoopType SzhBmLpAIdvCYCAKLUJSCZMJzuoF;

		private Action<int, ControllerDataUpdater> wwGXAvSUdCEYRVaINOqwyoaCHvDb;

		private PlatformInputManager QiuNyZpXobtXvcLudzBiKEoPlsiH;

		private CustomInputSource ElobbaujeOrsPDIfgiecHDeZFCSbb;

		private bool AdharyBflVXbDfbHPaORNoIjsUEc;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> uKnVBTCvQaqvnqonumVXKDcidgeH;

		private Func<int> qxIjVdRAWDzysOAUqFEWjsnqADdwA;

		[CustomObfuscation(rename = false)]
		int PlatformInputManager.deviceCount => LLhdyNDnBKosasqAkQBnmyWsRVEo;

		[CustomObfuscation(rename = false)]
		PlatformInputManager PlatformInputManager.primaryInputManager => QiuNyZpXobtXvcLudzBiKEoPlsiH;

		[CustomObfuscation(rename = false)]
		IInputSource PlatformInputManager.inputSource => ElobbaujeOrsPDIfgiecHDeZFCSbb;

		[CustomObfuscation(rename = false)]
		InputSource PlatformInputManager.inputSourceType => ElobbaujeOrsPDIfgiecHDeZFCSbb.GaOvguNDPSzOuoeCWEAmXpkVOoKq;

		public CustomInputManager(CustomInputSource P_0, UpdateLoopSetting P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3)
		{
			if (P_0 == null || P_2 == null || P_3 == null)
			{
				throw new ArgumentNullException();
			}
			ElobbaujeOrsPDIfgiecHDeZFCSbb = P_0;
			uKnVBTCvQaqvnqonumVXKDcidgeH = P_2;
			qxIjVdRAWDzysOAUqFEWjsnqADdwA = P_3;
			QiuNyZpXobtXvcLudzBiKEoPlsiH = this;
			try
			{
				wwGXAvSUdCEYRVaINOqwyoaCHvDb = UpdateControllerData;
				P_0.eneFMtGrXzTfoFfYJWiijkYpdOIGA += SystemDeviceConnected;
				P_0.EcvITUCCieqPtwuoqVbDhkSIWhql += SystemDeviceDisconnected;
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
			kPggIFAFqMpzHKMhHCBEOzQYJfEpA = new cGAokODTyUtikxOCDPmRbEISvHRC();
			AGFTZyOFvxpYzlVitTemPpYilxth = new List<CbgigjeudOPmLfZNuhuMkoQNUqTC>();
			AdharyBflVXbDfbHPaORNoIjsUEc = true;
			ElobbaujeOrsPDIfgiecHDeZFCSbb.xwgFJSCCAtKsEYtsyekkPgdVaXbwA();
		}

		[CustomObfuscation(rename = false)]
		public override void Update(UpdateLoopType updateLoop)
		{
			SzhBmLpAIdvCYCAKLUJSCZMJzuoF = updateLoop;
			if (ElobbaujeOrsPDIfgiecHDeZFCSbb.isReady)
			{
				ElobbaujeOrsPDIfgiecHDeZFCSbb.YlwcWyFkDedgcqrVQCGbFDnSyMsU();
				ElobbaujeOrsPDIfgiecHDeZFCSbb.Update();
				ElobbaujeOrsPDIfgiecHDeZFCSbb.TvmBXyQxUFceAUiYBUGpNotNkQRK();
				if (AdharyBflVXbDfbHPaORNoIjsUEc)
				{
					PPAXWFrCQIAulKecXJDuYyjPeGki();
				}
				oLXMuuVljMjKPdUdKPUJBiOKlxgjb();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void OnDestroy()
		{
			if (ElobbaujeOrsPDIfgiecHDeZFCSbb != null)
			{
				ElobbaujeOrsPDIfgiecHDeZFCSbb.Dispose();
			}
		}

		[CustomObfuscation(rename = false)]
		public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
		{
			return wwGXAvSUdCEYRVaINOqwyoaCHvDb;
		}

		[CustomObfuscation(rename = false)]
		public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
		{
			for (int i = 0; i < LLhdyNDnBKosasqAkQBnmyWsRVEo; i++)
			{
				if (AGFTZyOFvxpYzlVitTemPpYilxth[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
				{
					AGFTZyOFvxpYzlVitTemPpYilxth[i].FillData(data);
					return;
				}
			}
			Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceConnected()
		{
			AdharyBflVXbDfbHPaORNoIjsUEc = true;
			if (_SystemDeviceConnectedEvent != null)
			{
				_SystemDeviceConnectedEvent();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceDisconnected()
		{
			AdharyBflVXbDfbHPaORNoIjsUEc = true;
			if (_SystemDeviceDisconnectedEvent != null)
			{
				_SystemDeviceDisconnectedEvent();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void SetUnityJoystickId(int joystickId, int unityJoystickIndex)
		{
		}

		[CustomObfuscation(rename = false)]
		public override IUnifiedMouseSource GetUnifiedMouseSource()
		{
			return ElobbaujeOrsPDIfgiecHDeZFCSbb.fzeVNVbjdoenzXBHzdVDVEiBmWjg();
		}

		[CustomObfuscation(rename = false)]
		public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
		{
			return ElobbaujeOrsPDIfgiecHDeZFCSbb.kNkiwkCGFNGsPxUIStjGksYSXuwC();
		}

		protected virtual CbgigjeudOPmLfZNuhuMkoQNUqTC CreateInputManagerJoystick(CustomInputSource customInputSource, long? systemJoystickId, int unityJoystickId, CustomInputSource.Joystick joystick, InputSource inputSource, IList<Controller.Extension> controllerExtensions, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager)
		{
			return new CbgigjeudOPmLfZNuhuMkoQNUqTC(customInputSource, systemJoystickId, unityJoystickId, joystick, inputSource, controllerExtensions, getHardwareJoystickMap_InputManager);
		}

		private void vvasTjbWlzqpuWeZrPEEZgdVMdJm(CustomInputSource.Joystick[] P_0)
		{
			int num = 0;
			List<CbgigjeudOPmLfZNuhuMkoQNUqTC> aGFTZyOFvxpYzlVitTemPpYilxth = AGFTZyOFvxpYzlVitTemPpYilxth;
			int lLhdyNDnBKosasqAkQBnmyWsRVEo = LLhdyNDnBKosasqAkQBnmyWsRVEo;
			AGFTZyOFvxpYzlVitTemPpYilxth = new List<CbgigjeudOPmLfZNuhuMkoQNUqTC>();
			for (int i = 0; i < P_0.Length; i++)
			{
				if (P_0[i] != null)
				{
					CbgigjeudOPmLfZNuhuMkoQNUqTC item = CreateInputManagerJoystick(ElobbaujeOrsPDIfgiecHDeZFCSbb, P_0[i].systemId, P_0[i].unityId, P_0[i], ElobbaujeOrsPDIfgiecHDeZFCSbb.GaOvguNDPSzOuoeCWEAmXpkVOoKq, P_0[i].Extensions, uKnVBTCvQaqvnqonumVXKDcidgeH);
					AGFTZyOFvxpYzlVitTemPpYilxth.Add(item);
					num++;
				}
			}
			LLhdyNDnBKosasqAkQBnmyWsRVEo = num;
			BIyHrbGzYMTKMYPYvtcjhogumKyB(lLhdyNDnBKosasqAkQBnmyWsRVEo, num, aGFTZyOFvxpYzlVitTemPpYilxth, AGFTZyOFvxpYzlVitTemPpYilxth);
			for (int j = 0; j < num; j++)
			{
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(AGFTZyOFvxpYzlVitTemPpYilxth[j]));
				}
			}
			QHsheyWljvFtRrXYROLMCpFKlJHI(aGFTZyOFvxpYzlVitTemPpYilxth, AGFTZyOFvxpYzlVitTemPpYilxth, false);
			QHsheyWljvFtRrXYROLMCpFKlJHI(AGFTZyOFvxpYzlVitTemPpYilxth, aGFTZyOFvxpYzlVitTemPpYilxth, true);
		}

		private void oLXMuuVljMjKPdUdKPUJBiOKlxgjb()
		{
			for (int i = 0; i < LLhdyNDnBKosasqAkQBnmyWsRVEo; i++)
			{
				AGFTZyOFvxpYzlVitTemPpYilxth[i].Update();
			}
		}

		private void BIyHrbGzYMTKMYPYvtcjhogumKyB(int P_0, int P_1, List<CbgigjeudOPmLfZNuhuMkoQNUqTC> P_2, List<CbgigjeudOPmLfZNuhuMkoQNUqTC> P_3)
		{
			if (P_1 > 0)
			{
				P_3.Sort(CbgigjeudOPmLfZNuhuMkoQNUqTC.wuLJnMCVwshJfqUXSwaYeUxYsaCD);
			}
			if (P_0 > 0 && P_1 > 0)
			{
				siRWBwhJfZmtatXmjblpjanLlbyS(P_1, P_3, P_0, P_2, cGAokODTyUtikxOCDPmRbEISvHRC.BehBVQGYUTmsadtRIkaRdGStSZLgb.Exact);
				if (ElobbaujeOrsPDIfgiecHDeZFCSbb.useApproximateMatching)
				{
					siRWBwhJfZmtatXmjblpjanLlbyS(P_1, P_3, P_0, P_2, cGAokODTyUtikxOCDPmRbEISvHRC.BehBVQGYUTmsadtRIkaRdGStSZLgb.Approximate);
				}
			}
			iPUjvdPaEKzmJcYrAVALXiJXLhZR(P_1, P_3, cGAokODTyUtikxOCDPmRbEISvHRC.BehBVQGYUTmsadtRIkaRdGStSZLgb.Exact);
			if (ElobbaujeOrsPDIfgiecHDeZFCSbb.useApproximateMatching)
			{
				iPUjvdPaEKzmJcYrAVALXiJXLhZR(P_1, P_3, cGAokODTyUtikxOCDPmRbEISvHRC.BehBVQGYUTmsadtRIkaRdGStSZLgb.Approximate);
			}
			for (int i = 0; i < P_1; i++)
			{
				CbgigjeudOPmLfZNuhuMkoQNUqTC cbgigjeudOPmLfZNuhuMkoQNUqTC = P_3[i];
				if (cbgigjeudOPmLfZNuhuMkoQNUqTC != null && cbgigjeudOPmLfZNuhuMkoQNUqTC.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
				{
					cbgigjeudOPmLfZNuhuMkoQNUqTC.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = mRFJESNRWAwuDCdAtisxnZBdsJc(P_3);
					cbgigjeudOPmLfZNuhuMkoQNUqTC.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = ReInput.GetNewJoystickId();
					kPggIFAFqMpzHKMhHCBEOzQYJfEpA.xmUddNwcTANOZUIVAnWJuFAtwRBh(cbgigjeudOPmLfZNuhuMkoQNUqTC);
				}
			}
			P_3.Sort(CbgigjeudOPmLfZNuhuMkoQNUqTC.uvvJFBgBxjErYmokFLmnBKLeWgjJ);
		}

		private void PJOeDKRCeWBswVNfIDkoZRJSEDnbA(List<CbgigjeudOPmLfZNuhuMkoQNUqTC> P_0, int P_1, int P_2)
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

		private bool AtHjLlpimxsPfsEmqBcoawruKnZL(List<CbgigjeudOPmLfZNuhuMkoQNUqTC> P_0, int P_1)
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

		private int mRFJESNRWAwuDCdAtisxnZBdsJc(List<CbgigjeudOPmLfZNuhuMkoQNUqTC> P_0)
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

		private bool rUgyFhsJSRoiRIhiWAwfIsEYvBGk(List<CbgigjeudOPmLfZNuhuMkoQNUqTC> P_0, int P_1)
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

		private void siRWBwhJfZmtatXmjblpjanLlbyS(int P_0, List<CbgigjeudOPmLfZNuhuMkoQNUqTC> P_1, int P_2, List<CbgigjeudOPmLfZNuhuMkoQNUqTC> P_3, cGAokODTyUtikxOCDPmRbEISvHRC.BehBVQGYUTmsadtRIkaRdGStSZLgb P_4)
		{
			int num = ((P_4 != cGAokODTyUtikxOCDPmRbEISvHRC.BehBVQGYUTmsadtRIkaRdGStSZLgb.Exact) ? 1 : 2);
			for (int i = 0; i < P_0; i++)
			{
				CbgigjeudOPmLfZNuhuMkoQNUqTC cbgigjeudOPmLfZNuhuMkoQNUqTC = P_1[i];
				if (cbgigjeudOPmLfZNuhuMkoQNUqTC == null || cbgigjeudOPmLfZNuhuMkoQNUqTC.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
				{
					continue;
				}
				for (int j = 0; j < P_2; j++)
				{
					CbgigjeudOPmLfZNuhuMkoQNUqTC cbgigjeudOPmLfZNuhuMkoQNUqTC2 = P_3[j];
					if (cbgigjeudOPmLfZNuhuMkoQNUqTC2 != null && !rUgyFhsJSRoiRIhiWAwfIsEYvBGk(P_1, cbgigjeudOPmLfZNuhuMkoQNUqTC2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && cbgigjeudOPmLfZNuhuMkoQNUqTC.MZApUgUEaRdYLGGhKAoDcpsEKexU(cbgigjeudOPmLfZNuhuMkoQNUqTC2) >= num)
					{
						cbgigjeudOPmLfZNuhuMkoQNUqTC.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = cbgigjeudOPmLfZNuhuMkoQNUqTC2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
						cbgigjeudOPmLfZNuhuMkoQNUqTC.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = cbgigjeudOPmLfZNuhuMkoQNUqTC2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
						kPggIFAFqMpzHKMhHCBEOzQYJfEpA.xmUddNwcTANOZUIVAnWJuFAtwRBh(cbgigjeudOPmLfZNuhuMkoQNUqTC);
					}
				}
			}
		}

		private void iPUjvdPaEKzmJcYrAVALXiJXLhZR(int P_0, List<CbgigjeudOPmLfZNuhuMkoQNUqTC> P_1, cGAokODTyUtikxOCDPmRbEISvHRC.BehBVQGYUTmsadtRIkaRdGStSZLgb P_2)
		{
			for (int i = 0; i < P_0; i++)
			{
				CbgigjeudOPmLfZNuhuMkoQNUqTC cbgigjeudOPmLfZNuhuMkoQNUqTC = P_1[i];
				if (cbgigjeudOPmLfZNuhuMkoQNUqTC == null || cbgigjeudOPmLfZNuhuMkoQNUqTC.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
				{
					continue;
				}
				cGAokODTyUtikxOCDPmRbEISvHRC.YAMxaNjZtHfRYiSOoltQlDObUnMq yAMxaNjZtHfRYiSOoltQlDObUnMq = null;
				foreach (cGAokODTyUtikxOCDPmRbEISvHRC.YAMxaNjZtHfRYiSOoltQlDObUnMq item in kPggIFAFqMpzHKMhHCBEOzQYJfEpA.dvnPUBNOBjVuwhQVqrjzRCTEBORw(cbgigjeudOPmLfZNuhuMkoQNUqTC, P_2))
				{
					if (!rUgyFhsJSRoiRIhiWAwfIsEYvBGk(P_1, item.yeeiBCVbIzECXdvWdeqghFNwvGnjA) && item.BtlbnWwncHUmCjWyOEFZBVrrONBV >= 0)
					{
						yAMxaNjZtHfRYiSOoltQlDObUnMq = item;
						break;
					}
				}
				if (yAMxaNjZtHfRYiSOoltQlDObUnMq != null)
				{
					int num = yAMxaNjZtHfRYiSOoltQlDObUnMq.BtlbnWwncHUmCjWyOEFZBVrrONBV;
					if (!AtHjLlpimxsPfsEmqBcoawruKnZL(P_1, num))
					{
						num = (yAMxaNjZtHfRYiSOoltQlDObUnMq.BtlbnWwncHUmCjWyOEFZBVrrONBV = mRFJESNRWAwuDCdAtisxnZBdsJc(P_1));
					}
					cbgigjeudOPmLfZNuhuMkoQNUqTC.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
					cbgigjeudOPmLfZNuhuMkoQNUqTC.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = yAMxaNjZtHfRYiSOoltQlDObUnMq.yeeiBCVbIzECXdvWdeqghFNwvGnjA;
					kPggIFAFqMpzHKMhHCBEOzQYJfEpA.xmUddNwcTANOZUIVAnWJuFAtwRBh(cbgigjeudOPmLfZNuhuMkoQNUqTC);
				}
			}
		}

		private void PPAXWFrCQIAulKecXJDuYyjPeGki()
		{
			CustomInputSource.Joystick[] array = ElobbaujeOrsPDIfgiecHDeZFCSbb.mosvsSxQCYQKCtUYwtjJKdPSAIxP();
			if (aSXjAEspgiHbvZiBOmveWVDCoVRk(array))
			{
				vvasTjbWlzqpuWeZrPEEZgdVMdJm(array);
			}
			AdharyBflVXbDfbHPaORNoIjsUEc = false;
		}

		private bool aSXjAEspgiHbvZiBOmveWVDCoVRk(CustomInputSource.Joystick[] P_0)
		{
			int num = P_0.Length;
			int count = AGFTZyOFvxpYzlVitTemPpYilxth.Count;
			if (num != count)
			{
				return true;
			}
			for (int i = 0; i < num; i++)
			{
				if (P_0[i] == null)
				{
					continue;
				}
				long? systemId = P_0[i].systemId;
				bool flag = false;
				for (int j = 0; j < count; j++)
				{
					if (AGFTZyOFvxpYzlVitTemPpYilxth[j] != null && systemId == AGFTZyOFvxpYzlVitTemPpYilxth[j].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return true;
				}
			}
			for (int k = 0; k < count; k++)
			{
				if (AGFTZyOFvxpYzlVitTemPpYilxth[k] == null)
				{
					continue;
				}
				long? num2 = AGFTZyOFvxpYzlVitTemPpYilxth[k].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId;
				bool flag2 = false;
				for (int l = 0; l < num; l++)
				{
					if (P_0[l] != null && num2 == P_0[l].systemId)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					return true;
				}
			}
			return false;
		}

		private void QHsheyWljvFtRrXYROLMCpFKlJHI(List<CbgigjeudOPmLfZNuhuMkoQNUqTC> P_0, List<CbgigjeudOPmLfZNuhuMkoQNUqTC> P_1, bool P_2)
		{
			if (P_0 == null)
			{
				return;
			}
			int num = P_0?.Count ?? 0;
			int num2 = P_1?.Count ?? 0;
			for (int i = 0; i < num; i++)
			{
				CbgigjeudOPmLfZNuhuMkoQNUqTC cbgigjeudOPmLfZNuhuMkoQNUqTC = P_0[i];
				if (cbgigjeudOPmLfZNuhuMkoQNUqTC == null)
				{
					continue;
				}
				bool flag = false;
				if (P_1 != null)
				{
					for (int j = 0; j < num2; j++)
					{
						CbgigjeudOPmLfZNuhuMkoQNUqTC cbgigjeudOPmLfZNuhuMkoQNUqTC2 = P_1[j];
						if (cbgigjeudOPmLfZNuhuMkoQNUqTC2 != null && cbgigjeudOPmLfZNuhuMkoQNUqTC.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == cbgigjeudOPmLfZNuhuMkoQNUqTC2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					ngWkrWiEBHAgqVMkvPIrKzVpBDEv(P_0[i], P_2);
				}
			}
		}

		private void ngWkrWiEBHAgqVMkvPIrKzVpBDEv(CbgigjeudOPmLfZNuhuMkoQNUqTC P_0, bool P_1)
		{
			if (P_1)
			{
				P_0.SCnjyWHAoiRcPvuVlkCotpcDAXdT();
			}
			zZXMlegOYvBTHarUwVTQezjAzAyf(P_0, P_1);
		}

		private void zZXMlegOYvBTHarUwVTQezjAzAyf(CbgigjeudOPmLfZNuhuMkoQNUqTC P_0, bool P_1)
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
}
