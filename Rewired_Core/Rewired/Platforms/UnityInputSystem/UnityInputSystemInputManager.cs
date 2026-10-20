using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.InputManagers;
using Rewired.Internal;
using Rewired.Platforms.Custom;
using Rewired.Utils;

namespace Rewired.Platforms.UnityInputSystem
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class UnityInputSystemInputManager : CustomInputManager
	{
		private class IbREnnkMoKDeFhHqIjYwEfeCCDESD : CbgigjeudOPmLfZNuhuMkoQNUqTC
		{
			private UnityInputSystemInputSourceBase.Joystick vznjJkRJRxSLNxmqOHmPQlouanVA => (UnityInputSystemInputSourceBase.Joystick)base.lUjsNcGuvYseubpLUWuFSiYBWRZV;

			public IbREnnkMoKDeFhHqIjYwEfeCCDESD(CustomInputSource P_0, long? P_1, int P_2, CustomInputSource.Joystick P_3, InputSource P_4, IList<Controller.Extension> P_5, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_6)
				: base(P_0, P_1, P_2, P_3, P_4, P_5, P_6)
			{
			}

			protected virtual void gIpXDYANdVlpLNhPxuOBDFAlwNzg(HardwareJoystickMap_InputManager P_0)
			{
				base.chOHGtfvuAQaudAfJIvMZxfTxRhM(P_0);
				if (P_0 == null || !(P_0.map is HardwareJoystickMap.Platform_UnityInputSystem_Base platform_UnityInputSystem_Base))
				{
					return;
				}
				if ((P_0.hardwareMapIdentifier.guid == Consts.joystickGuid_appleMFiController || P_0.hardwareMapIdentifier.guid == Consts.joystickGuid_standardizedGamepad) && !string.IsNullOrEmpty(vznjJkRJRxSLNxmqOHmPQlouanVA.deviceName))
				{
					vznjJkRJRxSLNxmqOHmPQlouanVA.xyvlLUUBjpBMPEWJHIxqQWjranefA(vznjJkRJRxSLNxmqOHmPQlouanVA.deviceName);
				}
				if (UnityTools.platform == Platform.tvOS && (P_0.hardwareMapIdentifier.guid == Consts.joystickGuid_appleSiriRemote2015 || P_0.hardwareMapIdentifier.guid == Consts.joystickGuid_appleSiriRemote2021))
				{
					ConfigVars.PlatformVars_tvOS platformVars_tvOS = ReInput.configVars.platformVars_tvOS;
					if (platformVars_tvOS != null)
					{
						UnityTools.externalTools.tvOS_allowRemoteRotation = platformVars_tvOS.allowRemoteDPadRotation;
						UnityTools.externalTools.tvOS_remoteReportAbsoluteDpadValues = platformVars_tvOS.useAbsoluteRemoteTouchpadMode;
					}
				}
				HardwareJoystickMap.Platform_UnityInputSystem_Base.Axis[] axes_orig = platform_UnityInputSystem_Base.Axes_orig;
				HardwareJoystickMap.Platform_UnityInputSystem_Base.Button[] buttons_orig = platform_UnityInputSystem_Base.Buttons_orig;
				for (int i = 0; i < axes_orig.Length; i++)
				{
					if (axes_orig[i] != null)
					{
						HhgsiOhDGPRBQVnPJvoDdHXvoTyt(axes_orig[i], axes_orig[i].sourcePath);
					}
				}
				for (int j = 0; j < buttons_orig.Length; j++)
				{
					if (buttons_orig[j] != null)
					{
						HhgsiOhDGPRBQVnPJvoDdHXvoTyt(buttons_orig[j], buttons_orig[j].sourcePath);
					}
				}
			}

			private bool HhgsiOhDGPRBQVnPJvoDdHXvoTyt(HardwareJoystickMap.Platform_Custom.Element P_0, string P_1)
			{
				if (P_0.sourceType != 99)
				{
					return false;
				}
				IList<UnityInputSystemInputSourceBase.ControllerElementInfo> list = vznjJkRJRxSLNxmqOHmPQlouanVA.WFhvoVMMEHLwIIbtYiLPyFvXEPdj;
				int count = list.Count;
				try
				{
					if (string.IsNullOrEmpty(P_1))
					{
						return false;
					}
					for (int i = 0; i < count; i++)
					{
						if (list[i].element != null && string.Equals(P_1, list[i].path, StringComparison.Ordinal) && (list[i].element is CustomInputSource.Button || list[i].element is CustomInputSource.Axis))
						{
							if (list[i].element is CustomInputSource.Button)
							{
								P_0.sourceType = 0;
								P_0.sourceButton = base.lUjsNcGuvYseubpLUWuFSiYBWRZV.Buttons.IndexOf(list[i].element as CustomInputSource.Button);
							}
							else
							{
								P_0.sourceType = 1;
								P_0.sourceAxis = base.lUjsNcGuvYseubpLUWuFSiYBWRZV.Axes.IndexOf(list[i].element as CustomInputSource.Axis);
							}
							return true;
						}
					}
				}
				finally
				{
					if (P_0.sourceType == 99)
					{
						if (P_0 is HardwareJoystickMap.Platform_Custom.Axis)
						{
							P_0.sourceType = 1;
							P_0.sourceAxis = -1;
						}
						else
						{
							P_0.sourceType = 0;
							P_0.sourceButton = -1;
						}
					}
				}
				return false;
			}

			protected virtual bool tQNhmVttIdJULekerXenlPEwOICI(HardwareJoystickMap.Platform_Custom.Button P_0, out float P_1)
			{
				if (P_0 != null && P_0.sourceType == 3)
				{
					bool key = vznjJkRJRxSLNxmqOHmPQlouanVA.GetKey((KeyboardKeyCode)P_0.sourceButton);
					P_1 = (key ? 1f : 0f);
					return key;
				}
				return base.PoHmbUzaWFuBXRcvuIdFzglPAUobA(P_0, out P_1);
			}

			protected virtual void ZeMBbIGfJlPEqBXoPaPigDICBayHA(BridgedControllerHWInfo P_0)
			{
				base.jAKzatuLzrDEodtkEIAjPLPqkbsEb(P_0);
				P_0.userCustomIdentifier = vznjJkRJRxSLNxmqOHmPQlouanVA.GetDeviceMatchingProperties();
			}
		}

		public static UnityInputSystemInputManager Create(Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
		{
			return Create(new UnityInputSystemInputSourceInitOptions
			{
				handleJoysticks = true,
				handleKeyboard = true,
				handleMouse = true
			}, getHardwareJoystickMap_InputManager, getNewJoystickId);
		}

		public static UnityInputSystemInputManager Create(UnityInputSystemInputSourceInitOptions initOptions, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
		{
			if (initOptions == null)
			{
				throw new ArgumentNullException("initOptions");
			}
			if (!GlobalObjectProvider.TryGetObject<UnityInputSystemInputSourceBase>("createInputSource", 10, initOptions, out var result))
			{
				throw new Exception();
			}
			return Create(result, getHardwareJoystickMap_InputManager, getNewJoystickId);
		}

		public static UnityInputSystemInputManager Create(UnityInputSystemInputSourceBase inputSource, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
		{
			if (inputSource == null)
			{
				throw new ArgumentNullException("inputSource");
			}
			return new UnityInputSystemInputManager(ReInput.configVars.updateLoop, inputSource, getHardwareJoystickMap_InputManager, getNewJoystickId);
		}

		private UnityInputSystemInputManager(UpdateLoopSetting P_0, UnityInputSystemInputSourceBase P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3)
			: base(P_1, P_0, P_2, P_3)
		{
			if (UnityTools.platform == Platform.tvOS)
			{
				ConfigVars.PlatformVars_tvOS platformVars_tvOS = ReInput.configVars.platformVars_tvOS;
				if (platformVars_tvOS != null)
				{
					UnityTools.externalTools.tvOS_allowExitToHome = platformVars_tvOS.enableBackButtonReturnsHome;
					platformVars_tvOS.ValueChangedEvent += UwWMldCebIoIvVBCQhMwfLlEbVk;
				}
			}
		}

		protected override CbgigjeudOPmLfZNuhuMkoQNUqTC CreateInputManagerJoystick(CustomInputSource customInputSource, long? systemJoystickId, int unityJoystickId, CustomInputSource.Joystick joystick, InputSource inputSource, IList<Controller.Extension> controllerExtensions, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager)
		{
			return new IbREnnkMoKDeFhHqIjYwEfeCCDESD(customInputSource, systemJoystickId, unityJoystickId, joystick, inputSource, controllerExtensions, getHardwareJoystickMap_InputManager);
		}

		[CustomObfuscation(rename = false)]
		public override void OnDestroy()
		{
			if (UnityTools.platform == Platform.tvOS)
			{
				ConfigVars.PlatformVars_tvOS platformVars_tvOS = ReInput.configVars.platformVars_tvOS;
				if (platformVars_tvOS != null)
				{
					platformVars_tvOS.ValueChangedEvent -= UwWMldCebIoIvVBCQhMwfLlEbVk;
				}
			}
			base.OnDestroy();
		}

		private static void UwWMldCebIoIvVBCQhMwfLlEbVk()
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
}
