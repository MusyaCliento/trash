using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Config;
using Rewired.Platforms;
using Rewired.Platforms.Custom;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;

namespace Rewired.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class ConfigVars : IConfigVars_Internal
	{
		private static class AfBjxceRSpGctKdcYvMUtStjVSJMA
		{
			public const string hNnfbhOYzxgcpBhoyRrKPjLgivU = "updateLoop";

			public const string DhfsNvVaFZxnCOcXmFAVdiGKduYL = "alwaysUseUnityInput";

			public const string eOgPsjxpjztdvXAvHquZpwqnBeli = "windowsStandalonePrimaryInputSource";

			public const string ZOepstkVPMfcjvVwlzFPSenHzjcc = "osx_primaryInputSource";

			public const string AzdHWbVVuNdJYesBVvRVdeOOSqbw = "linux_primaryInputSource";

			public const string CHEbHyEdTsUhIfehWhzWfnzIxCfy = "windowsUWP_primaryInputSource";

			public const string OMlahVOsMPPTVXZiCQtgjdBvUXcE = "gameCoreXboxOne_primaryInputSource";

			public const string cagDMlLgKIhkovXIMvipdUdkOOGU = "gameCoreScarlett_primaryInputSource";

			public const string SFMrUSAeRLtjqHliSEoBbGwQnlfEb = "ps4_primaryInputSource";

			public const string ZbBZFLTGLLzRxzFGgHWdbCLCYhRO = "ps5_primaryInputSource";

			public const string UvuctlmayWAaZBwRywDhxXKXetAv = "webGL_primaryInputSource";

			public const string CMZdtIKWUMYsGLxLXmAnekaOgTvu = "android_primaryInputSource";

			public const string QePfbGSQyZsjMQcEOfsLkHzYFljT = "ios_primaryInputSource";

			public const string viiojMgBHVWVIvkIBGJYjJxxTOxqA = "tvos_primaryInputSource";

			public const string BlrzuYorpyBKkajuNJEHGgAuyQgC = "useXInput";

			public const string gWnWlTzUlkOYrhUktpLPJrOLbKsi = "windowsStandalone_useSteamRawInputControllerWorkaround";

			public const string TttKEKhkbTtPPSLOujXsiMJmyALhA = "osxStandalone_useEnhancedDeviceSupport";

			public const string PYHePaJSpKfMTWFvMTrcfqpGSCMHA = "android_supportUnknownGamepads";

			public const string SetsTPoQlIBLzEoAjxUywxDBpkCw = "ps4_assignJoysticksByPS4JoyId";

			public const string PEkPWVtxhhSsfeoLhetJlMonFiVb = "useSteamControllerSupport";

			public const string aNehuEulORCwlsjRynvGCgUkQnMC = "logToScreen";

			public const string hbGWLqPEVaczlevKIIfwBbKDKshSB = "runInEditMode";

			public const string ucnVcMhIgxExRbxTnSaElCZUItXo = "allowInputInEditorSceneView";

			public const string POAxAfngHuwvLjinBZFCcfFupJtu = "usePhysicalKeys";

			public const string nQiwOsKMPAeZxTworNKgPsuesThA = "showSystemKeyLabels";

			public const string RBYoiHXsQxjAcDNGxtEtiJzeuLnD = "maxJoysticksPerPlayer";

			public const string RZenkqNugMNtSFyGPppyYMvksLyg = "autoAssignJoysticks";

			public const string JcGiKwIpGjsnnASaLaDOWHJlOQhm = "assignJoysticksToPlayingPlayersOnly";

			public const string SKEUheYItLttftBzwIpnAAgjeDyiA = "distributeJoysticksEvenly";

			public const string JmtYPAOBvddKLGUwwijawzVvqcGn = "reassignJoystickToPreviousOwnerOnReconnect";

			public const string PNecVWBZivMyAbPjCRnieyXqvESK = "defaultJoystickAxis2DDeadZoneType";

			public const string NfXzJbbCoKjojvDprvlDEQSpdLxW = "defaultJoystickAxis2DSensitivityType";

			public const string vBbeoWpiqRHtTkhqOgRmBbegvbvg = "defaultAxisSensitivityType";

			public const string rcLIZrLmABcwCNUKORaNiTbWHTUN = "force4WayHats";

			public const string ifAsGGQotFPfVrXDhsXRHGbVkHSk = "throttleCalibrationMode";

			public const string zqIKoDfBkYJmQlaHACbmbelBUZVfA = "activateActionButtonsOnNegativeValue";

			public const string mebsersICmwjEPtKduQghLkLCdlAA = "deferControllerConnectedEventsOnStart";

			public const string uHgCObFHEXfNoOfSxgPtwbtIdEBt = "logLevel";

			public const string dnKmqrGfXnzwanoUMMOkdqxNWjof = "fallbackInputSource";

			public const string ukRtFuREnLdTpbFvooHKtCbPlsdjA = "disableKeyboard";

			public const string gUsNtGHuIDqgbHmnipQGwvpMDSoV = "disableMouse";

			public const string bHoBwJHmuKzkVDylaeBrNGyXDssFb = "ignoreInputWhenAppNotInFocus";

			public const string BRrezmstksXXBABajBSxHrAhEnfHA = "useEnhancedDeviceSupport";

			public const string dbkQXihnlPDxzJQRhyglxMuJmJML = "useNativeMouse";

			public const string WuRYFEDJRKtKeiYkacRqWMUEfKfp = "useNativeKeyboard";

			public const string pyCtYkKSLSeRMkAyKQBUByrevSjd = "joystickRefreshRate";

			public const string NcKMgWgIcZLQFWfzfdnuElQlftVU = "assignJoysticksBySystemId";

			public const string PMVSILEsjGDUEVVWiVAxvlMartTg = "supportXRControllers";
		}

		[Serializable]
		public class PlatformVars
		{
			public bool disableKeyboard;

			public bool disableMouse;

			public bool ignoreInputWhenAppNotInFocus = true;
		}

		[Serializable]
		public class PlatformVars_WindowsStandalone : PlatformVars
		{
			public bool useNativeKeyboard = true;

			public int joystickRefreshRate = 240;

			public bool useWindowsGamingInput;

			public List<EnhancedDeviceSupportDeviceType> enhancedDeviceSupportExcludedDeviceTypes;

			public bool supportXRControllers;
		}

		[Serializable]
		public class PlatformVars_OSXStandalone : PlatformVars
		{
			public bool useAppleGameController;

			public bool assignJoysticksByUserId;

			public List<EnhancedDeviceSupportDeviceType> enhancedDeviceSupportExcludedDeviceTypes;

			public bool supportXRControllers;
		}

		[Serializable]
		public class PlatformVars_LinuxStandalone : PlatformVars
		{
			public bool useEnhancedDeviceSupport = true;

			public List<EnhancedDeviceSupportDeviceType> enhancedDeviceSupportExcludedDeviceTypes;

			public bool supportXRControllers;
		}

		[Serializable]
		public class PlatformVars_WindowsUWP : PlatformVars
		{
			public bool useGamepadAPI = true;

			public bool useHIDAPI = true;

			public bool supportXRControllers;
		}

		[Serializable]
		public class PlatformVars_iOS : PlatformVars
		{
			public bool assignJoysticksByUserId;
		}

		[Serializable]
		public class PlatformVars_tvOS : PlatformVars
		{
			public bool assignJoysticksByUserId;

			public bool useAbsoluteRemoteTouchpadMode;

			public bool allowRemoteDPadRotation;

			public bool enableBackButtonReturnsHome;

			[CustomObfuscation(rename = false)]
			internal event Action ValueChangedEvent;

			internal void lTwUVYvPwGglPmMfbaiQDbSOZVOn()
			{
				this.ValueChangedEvent?.Invoke();
			}
		}

		[Serializable]
		public class PlatformVars_GameCoreXboxOne : PlatformVars
		{
			public bool assignJoysticksByUserId;
		}

		[Serializable]
		public class PlatformVars_GameCoreScarlett : PlatformVars
		{
			public bool assignJoysticksByUserId;
		}

		[Serializable]
		public class PlatformVars_PS5 : PlatformVars
		{
			public bool assignJoysticksByPS5JoyId = true;
		}

		[Serializable]
		public sealed class EditorVars
		{
			public bool exportConsts_useParentClass;

			public string exportConsts_parentClassName = "RewiredConsts";

			public bool exportConsts_useNamespace = true;

			public string exportConsts_namespace = "RewiredConsts";

			public bool exportConsts_actions = true;

			public string exportConsts_actionsClassName = "Action";

			public bool exportConsts_actionsIncludeActionCategory;

			public bool exportConsts_actionsCreateClassesForActionCategories;

			public bool exportConsts_mapCategories = true;

			public string exportConsts_mapCategoriesClassName = "Category";

			public bool exportConsts_layouts = true;

			public string exportConsts_layoutsClassName = "Layout";

			public bool exportConsts_players = true;

			public string exportConsts_playersClassName = "Player";

			public bool exportConsts_inputBehaviors;

			public string exportConsts_inputBehaviorsClassName = "InputBehavior";

			public bool exportConsts_customControllers = true;

			public string exportConsts_customControllersClassName = "CustomController";

			public string exportConsts_customControllersAxesClassName = "Axis";

			public string exportConsts_customControllersButtonsClassName = "Button";

			public bool exportConsts_layoutManagerRuleSets = true;

			public string exportConsts_layoutManagerRuleSetsClassName = "LayoutManagerRuleSet";

			public bool exportConsts_mapEnablerRuleSets = true;

			public string exportConsts_mapEnablerRuleSetsClassName = "MapEnablerRuleSet";

			public bool exportConsts_allCapsConstantNames;
		}

		private class SSAvBXGpDRxtChfmISGBpOuZcadz
		{
			public Func<PlatformVars> LmDOPlrKAhGhwnZFCfubIRWWQqwu;

			public string XGCYlrvHXmgPNwdQWfTpHmvDTcjkA;

			public SSAvBXGpDRxtChfmISGBpOuZcadz(Func<PlatformVars> P_0, string P_1)
			{
				LmDOPlrKAhGhwnZFCfubIRWWQqwu = P_0;
				XGCYlrvHXmgPNwdQWfTpHmvDTcjkA = P_1;
			}
		}

		private class XaVAnpFPdzcDCnZEAhAybtyENnMFb
		{
			public Func<Platform, object> zlZbAzgYTpBJoPhHuelbyUepLHteA;

			public Action<Platform, object> brrGkKlXvIWyTVvxaymDquvfdkFc;

			public XaVAnpFPdzcDCnZEAhAybtyENnMFb(Func<Platform, object> P_0, Action<Platform, object> P_1)
			{
				zlZbAzgYTpBJoPhHuelbyUepLHteA = P_0;
				brrGkKlXvIWyTVvxaymDquvfdkFc = P_1;
			}
		}

		[CustomObfuscation(rename = false)]
		internal enum AllPlatformVar
		{
			[CustomObfuscation(rename = false)]
			DisableKeyboard = 0,
			[CustomObfuscation(rename = false)]
			IgnoreInputWhenAppNotInFocus = 1,
			[CustomObfuscation(rename = false)]
			DisableMouse = 2
		}

		public UpdateMode updateMode;

		public UpdateLoopSetting updateLoop = UpdateLoopSetting.Update;

		public bool alwaysUseUnityInput;

		public WindowsStandalonePrimaryInputSource windowsStandalonePrimaryInputSource;

		public MacOSStandalonePrimaryInputSource osx_primaryInputSource;

		public LinuxStandalonePrimaryInputSource linux_primaryInputSource;

		public WindowsUWPPrimaryInputSource windowsUWP_primaryInputSource;

		public GameCoreXboxOnePrimaryInputSource gameCoreXboxOne_primaryInputSource;

		public GameCoreScarlettPrimaryInputSource gameCoreScarlett_primaryInputSource;

		public PS4PrimaryInputSource ps4_primaryInputSource;

		public PS5PrimaryInputSource ps5_primaryInputSource;

		public WebGLPrimaryInputSource webGL_primaryInputSource;

		public AndroidPrimaryInputSource android_primaryInputSource = AndroidPrimaryInputSource.UnityInputManager;

		public IOSPrimaryInputSource ios_primaryInputSource = IOSPrimaryInputSource.UnityInputManager;

		public TVOSPrimaryInputSource tvos_primaryInputSource = TVOSPrimaryInputSource.UnityInputManager;

		public bool useXInput = true;

		public bool useNativeMouse = true;

		public bool useEnhancedDeviceSupport = true;

		public bool osxStandalone_useEnhancedDeviceSupport = true;

		public bool android_supportUnknownGamepads = true;

		public bool ps4_assignJoysticksByPS4JoyId = true;

		public bool useSteamControllerSupport = true;

		public bool logToScreen;

		public bool runInEditMode;

		public bool allowInputInEditorSceneView;

		public bool unityUsePhysicalKeys;

		public bool showSystemKeyLabels;

		public KeyCombinationOverrideMode keyCombinationOverrideMode = KeyCombinationOverrideMode.Pause;

		public bool generateKeyEventsOnKeyCombinationOverride;

		public PlatformVars_WindowsStandalone platformVars_windowsStandalone;

		public PlatformVars_LinuxStandalone platformVars_linuxStandalone;

		public PlatformVars_OSXStandalone platformVars_osxStandalone;

		public PlatformVars_WindowsUWP platformVars_windowsUWP;

		public PlatformVars_iOS platformVars_iOS;

		public PlatformVars_tvOS platformVars_tvOS;

		public PlatformVars platformVars_android;

		public PlatformVars platformVars_ps4;

		public PlatformVars_PS5 platformVars_ps5;

		public PlatformVars platformVars_psVita;

		public PlatformVars platformVars_xboxOne;

		public PlatformVars_GameCoreXboxOne platformVars_gameCoreXboxOne;

		public PlatformVars_GameCoreScarlett platformVars_gameCoreScarlett;

		public PlatformVars platformVars_switch;

		public PlatformVars platformVars_switch2;

		public PlatformVars platformVars_webGL;

		[NonSerialized]
		private PlatformVars platformVars_unknown;

		public int maxJoysticksPerPlayer = 1;

		public bool autoAssignJoysticks = true;

		public bool assignJoysticksToPlayingPlayersOnly;

		public bool distributeJoysticksEvenly = true;

		public bool reassignJoystickToPreviousOwnerOnReconnect = true;

		public DeadZone2DType defaultJoystickAxis2DDeadZoneType = DeadZone2DType.Radial;

		public AxisSensitivity2DType defaultJoystickAxis2DSensitivityType;

		public AxisSensitivityType defaultAxisSensitivityType;

		public bool force4WayHats;

		public ThrottleCalibrationMode throttleCalibrationMode;

		public bool activateActionButtonsOnNegativeValue;

		public bool deferControllerConnectedEventsOnStart;

		public LogLevelFlags logLevel = LogLevelFlags.Info | LogLevelFlags.Warning | LogLevelFlags.Error;

		public UnityInputSourceType fallbackInputSource;

		public bool disableAxis2dClamping;

		public EditorVars editorSettings;

		private Dictionary<int, SSAvBXGpDRxtChfmISGBpOuZcadz> __platformVarsDict;

		private Dictionary<int, XaVAnpFPdzcDCnZEAhAybtyENnMFb> __getSetPlatformVariableDict;

		private KeyedGetSetValueStore<string> __configVarsValues;

		private Dictionary<string, object> __valueDelegates;

		private Dictionary<int, SSAvBXGpDRxtChfmISGBpOuZcadz> platformVarsDict
		{
			get
			{
				Dictionary<int, SSAvBXGpDRxtChfmISGBpOuZcadz> dictionary = __platformVarsDict;
				if (dictionary == null)
				{
					Dictionary<int, SSAvBXGpDRxtChfmISGBpOuZcadz> obj = new Dictionary<int, SSAvBXGpDRxtChfmISGBpOuZcadz>
					{
						{
							1,
							new SSAvBXGpDRxtChfmISGBpOuZcadz(() => GetOrCreatePlatformVars(ref platformVars_windowsStandalone), "platformVars_windowsStandalone")
						},
						{
							29,
							new SSAvBXGpDRxtChfmISGBpOuZcadz(() => GetOrCreatePlatformVars(ref platformVars_windowsUWP), "platformVars_windowsUWP")
						},
						{
							6,
							new SSAvBXGpDRxtChfmISGBpOuZcadz(() => GetOrCreatePlatformVars(ref platformVars_linuxStandalone), "platformVars_linuxStandalone")
						},
						{
							4,
							new SSAvBXGpDRxtChfmISGBpOuZcadz(() => GetOrCreatePlatformVars(ref platformVars_osxStandalone), "platformVars_osxStandalone")
						},
						{
							5,
							new SSAvBXGpDRxtChfmISGBpOuZcadz(() => GetOrCreatePlatformVars(ref platformVars_iOS), "platformVars_iOS")
						},
						{
							28,
							new SSAvBXGpDRxtChfmISGBpOuZcadz(() => GetOrCreatePlatformVars(ref platformVars_tvOS), "platformVars_tvOS")
						},
						{
							13,
							new SSAvBXGpDRxtChfmISGBpOuZcadz(() => GetOrCreatePlatformVars(ref platformVars_ps4), "platformVars_ps4")
						},
						{
							106,
							new SSAvBXGpDRxtChfmISGBpOuZcadz(() => GetOrCreatePlatformVars(ref platformVars_ps5), "platformVars_ps5")
						},
						{
							15,
							new SSAvBXGpDRxtChfmISGBpOuZcadz(() => GetOrCreatePlatformVars(ref platformVars_psVita), "platformVars_psVita")
						},
						{
							14,
							new SSAvBXGpDRxtChfmISGBpOuZcadz(() => GetOrCreatePlatformVars(ref platformVars_psVita), "platformVars_psVita")
						},
						{
							32,
							new SSAvBXGpDRxtChfmISGBpOuZcadz(() => GetOrCreatePlatformVars(ref platformVars_switch), "platformVars_switch")
						},
						{
							33,
							new SSAvBXGpDRxtChfmISGBpOuZcadz(() => GetOrCreatePlatformVars(ref platformVars_switch2), "platformVars_switch2")
						},
						{
							11,
							new SSAvBXGpDRxtChfmISGBpOuZcadz(() => GetOrCreatePlatformVars(ref platformVars_xboxOne), "platformVars_xboxOne")
						},
						{
							104,
							new SSAvBXGpDRxtChfmISGBpOuZcadz(() => GetOrCreatePlatformVars(ref platformVars_gameCoreXboxOne), "platformVars_gameCoreXboxOne")
						},
						{
							105,
							new SSAvBXGpDRxtChfmISGBpOuZcadz(() => GetOrCreatePlatformVars(ref platformVars_gameCoreScarlett), "platformVars_gameCoreScarlett")
						},
						{
							19,
							new SSAvBXGpDRxtChfmISGBpOuZcadz(() => GetOrCreatePlatformVars(ref platformVars_webGL), "platformVars_webGL")
						},
						{
							7,
							new SSAvBXGpDRxtChfmISGBpOuZcadz(() => GetOrCreatePlatformVars(ref platformVars_android), "platformVars_android")
						}
					};
					Dictionary<int, SSAvBXGpDRxtChfmISGBpOuZcadz> dictionary2 = obj;
					__platformVarsDict = obj;
					dictionary = dictionary2;
				}
				return dictionary;
			}
		}

		private Dictionary<int, XaVAnpFPdzcDCnZEAhAybtyENnMFb> getSetPlatformVariableDict
		{
			get
			{
				Dictionary<int, XaVAnpFPdzcDCnZEAhAybtyENnMFb> dictionary = __getSetPlatformVariableDict;
				if (dictionary == null)
				{
					Dictionary<int, XaVAnpFPdzcDCnZEAhAybtyENnMFb> obj = new Dictionary<int, XaVAnpFPdzcDCnZEAhAybtyENnMFb>
					{
						{
							0,
							new XaVAnpFPdzcDCnZEAhAybtyENnMFb((Platform p) => GetPlatformVars(p).disableKeyboard, delegate(Platform platform, object value)
							{
								GetPlatformVars(platform).disableKeyboard = (bool)value;
							})
						},
						{
							2,
							new XaVAnpFPdzcDCnZEAhAybtyENnMFb((Platform p) => GetPlatformVars(p).disableMouse, delegate(Platform platform, object value)
							{
								GetPlatformVars(platform).disableMouse = (bool)value;
							})
						},
						{
							1,
							new XaVAnpFPdzcDCnZEAhAybtyENnMFb((Platform platform) => GetPlatformVars(platform).ignoreInputWhenAppNotInFocus, delegate(Platform platform, object value)
							{
								GetPlatformVars(platform).ignoreInputWhenAppNotInFocus = (bool)value;
							})
						}
					};
					Dictionary<int, XaVAnpFPdzcDCnZEAhAybtyENnMFb> dictionary2 = obj;
					__getSetPlatformVariableDict = obj;
					dictionary = dictionary2;
				}
				return dictionary;
			}
		}

		KeyedGetSetValueStore<string> IConfigVars_Internal.values
		{
			get
			{
				if (__configVarsValues == null)
				{
					__configVarsValues = new KeyedGetSetValueStore<string>(valueDelegates, true);
				}
				return __configVarsValues;
			}
		}

		private Dictionary<string, object> valueDelegates
		{
			get
			{
				if (__valueDelegates == null)
				{
					__valueDelegates = new Dictionary<string, object>
					{
						{
							"updateLoop",
							new GetSetValue<UpdateLoopSetting>(() => updateLoop, delegate(UpdateLoopSetting x)
							{
								updateLoop = x;
							})
						},
						{
							"alwaysUseUnityInput",
							new GetSetValue<bool>(() => alwaysUseUnityInput, delegate(bool x)
							{
								alwaysUseUnityInput = x;
							})
						},
						{
							"windowsStandalonePrimaryInputSource",
							new GetSetValue<WindowsStandalonePrimaryInputSource>(() => windowsStandalonePrimaryInputSource, delegate(WindowsStandalonePrimaryInputSource x)
							{
								windowsStandalonePrimaryInputSource = x;
							})
						},
						{
							"osx_primaryInputSource",
							new GetSetValue<MacOSStandalonePrimaryInputSource>(() => osx_primaryInputSource, delegate(MacOSStandalonePrimaryInputSource x)
							{
								osx_primaryInputSource = x;
							})
						},
						{
							"linux_primaryInputSource",
							new GetSetValue<LinuxStandalonePrimaryInputSource>(() => linux_primaryInputSource, delegate(LinuxStandalonePrimaryInputSource x)
							{
								linux_primaryInputSource = x;
							})
						},
						{
							"windowsUWP_primaryInputSource",
							new GetSetValue<WindowsUWPPrimaryInputSource>(() => windowsUWP_primaryInputSource, delegate(WindowsUWPPrimaryInputSource x)
							{
								windowsUWP_primaryInputSource = x;
							})
						},
						{
							"gameCoreXboxOne_primaryInputSource",
							new GetSetValue<GameCoreXboxOnePrimaryInputSource>(() => gameCoreXboxOne_primaryInputSource, delegate(GameCoreXboxOnePrimaryInputSource x)
							{
								gameCoreXboxOne_primaryInputSource = x;
							})
						},
						{
							"gameCoreScarlett_primaryInputSource",
							new GetSetValue<GameCoreScarlettPrimaryInputSource>(() => gameCoreScarlett_primaryInputSource, delegate(GameCoreScarlettPrimaryInputSource x)
							{
								gameCoreScarlett_primaryInputSource = x;
							})
						},
						{
							"ps4_primaryInputSource",
							new GetSetValue<PS4PrimaryInputSource>(() => ps4_primaryInputSource, delegate(PS4PrimaryInputSource x)
							{
								ps4_primaryInputSource = x;
							})
						},
						{
							"ps5_primaryInputSource",
							new GetSetValue<PS5PrimaryInputSource>(() => ps5_primaryInputSource, delegate(PS5PrimaryInputSource x)
							{
								ps5_primaryInputSource = x;
							})
						},
						{
							"webGL_primaryInputSource",
							new GetSetValue<WebGLPrimaryInputSource>(() => webGL_primaryInputSource, delegate(WebGLPrimaryInputSource x)
							{
								webGL_primaryInputSource = x;
							})
						},
						{
							"android_primaryInputSource",
							new GetSetValue<AndroidPrimaryInputSource>(() => GetAndroidPrimaryInputSource(), delegate(AndroidPrimaryInputSource x)
							{
								android_primaryInputSource = x;
							})
						},
						{
							"ios_primaryInputSource",
							new GetSetValue<IOSPrimaryInputSource>(() => GetIOSPrimaryInputSource(), delegate(IOSPrimaryInputSource x)
							{
								ios_primaryInputSource = x;
							})
						},
						{
							"tvos_primaryInputSource",
							new GetSetValue<TVOSPrimaryInputSource>(() => GetTVOSPrimaryInputSource(), delegate(TVOSPrimaryInputSource x)
							{
								tvos_primaryInputSource = x;
							})
						},
						{
							"useXInput",
							new GetSetValue<bool>(() => useXInput, delegate(bool x)
							{
								useXInput = x;
							})
						},
						{
							"osxStandalone_useEnhancedDeviceSupport",
							new GetSetValue<bool>(() => osxStandalone_useEnhancedDeviceSupport, delegate(bool x)
							{
								osxStandalone_useEnhancedDeviceSupport = x;
							})
						},
						{
							"android_supportUnknownGamepads",
							new GetSetValue<bool>(() => android_supportUnknownGamepads, delegate(bool x)
							{
								android_supportUnknownGamepads = x;
							})
						},
						{
							"ps4_assignJoysticksByPS4JoyId",
							new GetSetValue<bool>(() => ps4_assignJoysticksByPS4JoyId, delegate(bool x)
							{
								ps4_assignJoysticksByPS4JoyId = x;
							})
						},
						{
							"useSteamControllerSupport",
							new GetSetValue<bool>(() => useSteamControllerSupport, delegate(bool x)
							{
								useSteamControllerSupport = x;
							})
						},
						{
							"logToScreen",
							new GetSetValue<bool>(() => logToScreen, delegate(bool x)
							{
								logToScreen = x;
							})
						},
						{
							"runInEditMode",
							new GetSetValue<bool>(() => runInEditMode, delegate(bool x)
							{
								runInEditMode = x;
							})
						},
						{
							"allowInputInEditorSceneView",
							new GetSetValue<bool>(() => allowInputInEditorSceneView, delegate(bool x)
							{
								allowInputInEditorSceneView = x;
							})
						},
						{
							"usePhysicalKeys",
							new GetSetValue<bool>(() => unityUsePhysicalKeys, delegate(bool x)
							{
								unityUsePhysicalKeys = x;
							})
						},
						{
							"showSystemKeyLabels",
							new GetSetValue<bool>(() => showSystemKeyLabels, delegate(bool x)
							{
								showSystemKeyLabels = x;
							})
						},
						{
							"maxJoysticksPerPlayer",
							new GetSetValue<int>(() => maxJoysticksPerPlayer, delegate(int x)
							{
								maxJoysticksPerPlayer = x;
							})
						},
						{
							"autoAssignJoysticks",
							new GetSetValue<bool>(() => autoAssignJoysticks, delegate(bool x)
							{
								autoAssignJoysticks = x;
							})
						},
						{
							"assignJoysticksToPlayingPlayersOnly",
							new GetSetValue<bool>(() => assignJoysticksToPlayingPlayersOnly, delegate(bool x)
							{
								assignJoysticksToPlayingPlayersOnly = x;
							})
						},
						{
							"distributeJoysticksEvenly",
							new GetSetValue<bool>(() => distributeJoysticksEvenly, delegate(bool x)
							{
								distributeJoysticksEvenly = x;
							})
						},
						{
							"reassignJoystickToPreviousOwnerOnReconnect",
							new GetSetValue<bool>(() => reassignJoystickToPreviousOwnerOnReconnect, delegate(bool x)
							{
								reassignJoystickToPreviousOwnerOnReconnect = x;
							})
						},
						{
							"defaultJoystickAxis2DDeadZoneType",
							new GetSetValue<DeadZone2DType>(() => defaultJoystickAxis2DDeadZoneType, delegate(DeadZone2DType x)
							{
								defaultJoystickAxis2DDeadZoneType = x;
							})
						},
						{
							"defaultJoystickAxis2DSensitivityType",
							new GetSetValue<AxisSensitivity2DType>(() => defaultJoystickAxis2DSensitivityType, delegate(AxisSensitivity2DType x)
							{
								defaultJoystickAxis2DSensitivityType = x;
							})
						},
						{
							"defaultAxisSensitivityType",
							new GetSetValue<AxisSensitivityType>(() => defaultAxisSensitivityType, delegate(AxisSensitivityType x)
							{
								defaultAxisSensitivityType = x;
							})
						},
						{
							"force4WayHats",
							new GetSetValue<bool>(() => force4WayHats, delegate(bool x)
							{
								force4WayHats = x;
							})
						},
						{
							"throttleCalibrationMode",
							new GetSetValue<ThrottleCalibrationMode>(() => throttleCalibrationMode, delegate(ThrottleCalibrationMode x)
							{
								throttleCalibrationMode = x;
							})
						},
						{
							"activateActionButtonsOnNegativeValue",
							new GetSetValue<bool>(() => activateActionButtonsOnNegativeValue, delegate(bool x)
							{
								activateActionButtonsOnNegativeValue = x;
							})
						},
						{
							"deferControllerConnectedEventsOnStart",
							new GetSetValue<bool>(() => deferControllerConnectedEventsOnStart, delegate(bool x)
							{
								deferControllerConnectedEventsOnStart = x;
							})
						},
						{
							"logLevel",
							new GetSetValue<LogLevelFlags>(() => logLevel, delegate(LogLevelFlags x)
							{
								logLevel = x;
							})
						},
						{
							"fallbackInputSource",
							new GetSetValue<UnityInputSourceType>(() => GetFallbackUnityInputType(), delegate(UnityInputSourceType x)
							{
								fallbackInputSource = x;
							})
						},
						{
							"disableKeyboard",
							new GetSetValue<bool>(() => GetPlatformVar_disableKeyboard(), delegate(bool x)
							{
								SetPlatformVar_disableKeyboard(x);
							})
						},
						{
							"disableMouse",
							new GetSetValue<bool>(() => GetPlatformVar_disableMouse(), delegate(bool x)
							{
								SetPlatformVar_disableMouse(x);
							})
						},
						{
							"ignoreInputWhenAppNotInFocus",
							new GetSetValue<bool>(() => GetPlatformVar_ignoreInputWhenAppNotInFocus(), delegate(bool x)
							{
								SetPlatformVar_ignoreInputWhenAppNotInFocus(x);
							})
						},
						{
							"useEnhancedDeviceSupport",
							new GetSetValue<bool>(() => GetPlatformVar_useEnhancedDeviceSupport(), delegate(bool x)
							{
								SetPlatformVar_useEnhancedDeviceSupport(x);
							})
						},
						{
							"useNativeMouse",
							new GetSetValue<bool>(() => GetPlatformVar_useNativeMouse(), delegate(bool x)
							{
								SetPlatformVar_useNativeMouse(x);
							})
						},
						{
							"useNativeKeyboard",
							new GetSetValue<bool>(() => GetPlatformVar_useNativeKeyboard(), delegate(bool x)
							{
								SetPlatformVar_useNativeKeyboard(x);
							})
						},
						{
							"joystickRefreshRate",
							new GetSetValue<int>(() => GetPlatformVar_joystickRefreshRate(), delegate(int x)
							{
								SetPlatformVar_joystickRefreshRate(x);
							})
						},
						{
							"assignJoysticksBySystemId",
							new GetSetValue<bool>(() => GetPlatformVar_assignJoysticksBySystemId(), delegate(bool x)
							{
								SetPlatformVar_assignJoysticksBySystemId(x);
							})
						},
						{
							"supportXRControllers",
							new GetSetValue<bool>(() => GetPlatformVar_supportXRControllers(), delegate(bool x)
							{
								SetPlatformVar_supportXRControllers(x);
							})
						}
					};
				}
				return __valueDelegates;
			}
		}

		[Preserve]
		public ConfigVars()
		{
		}

		internal bool IsPrimaryInputSourceUnityInputManager(Platform platform, WebplayerPlatform webplayerPlatform, bool isEditor)
		{
			if (alwaysUseUnityInput && GetFallbackUnityInputType() == UnityInputSourceType.InputManager)
			{
				return true;
			}
			if (!isEditor && webplayerPlatform != WebplayerPlatform.None)
			{
				return true;
			}
			switch (platform)
			{
			case Platform.Windows:
				return windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.UnityInputManager;
			case Platform.OSX:
				return osx_primaryInputSource == MacOSStandalonePrimaryInputSource.UnityInputManager;
			case Platform.Linux:
				return linux_primaryInputSource == LinuxStandalonePrimaryInputSource.UnityInputManager;
			case Platform.iOS:
				return GetIOSPrimaryInputSource() == IOSPrimaryInputSource.UnityInputManager;
			case Platform.tvOS:
				return GetTVOSPrimaryInputSource() == TVOSPrimaryInputSource.UnityInputManager;
			default:
				if (UnityTools.fMJBBdGcIQIZWgCBcREeBOMATWCvE(platform))
				{
					return GetAndroidPrimaryInputSource() == AndroidPrimaryInputSource.UnityInputManager;
				}
				return false;
			}
		}

		internal bool IsPrimaryInputSourceUnityInputSystem(Platform platform, WebplayerPlatform webplayerPlatform, bool isEditor)
		{
			if (alwaysUseUnityInput && GetFallbackUnityInputType() == UnityInputSourceType.InputSystem)
			{
				return true;
			}
			if (!isEditor && webplayerPlatform != WebplayerPlatform.None)
			{
				return false;
			}
			switch (platform)
			{
			case Platform.Windows:
				return windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.UnityInputSystem;
			case Platform.OSX:
				return osx_primaryInputSource == MacOSStandalonePrimaryInputSource.UnityInputSystem;
			case Platform.Linux:
				return linux_primaryInputSource == LinuxStandalonePrimaryInputSource.UnityInputSystem;
			case Platform.WindowsUWP:
				return windowsUWP_primaryInputSource == WindowsUWPPrimaryInputSource.UnityInputSystem;
			case Platform.iOS:
				return GetIOSPrimaryInputSource() == IOSPrimaryInputSource.UnityInputSystem;
			case Platform.tvOS:
				return GetTVOSPrimaryInputSource() == TVOSPrimaryInputSource.UnityInputSystem;
			case Platform.WebGL:
				return webGL_primaryInputSource == WebGLPrimaryInputSource.UnityInputSystem;
			default:
				if (UnityTools.fMJBBdGcIQIZWgCBcREeBOMATWCvE(platform))
				{
					return GetAndroidPrimaryInputSource() == AndroidPrimaryInputSource.UnityInputSystem;
				}
				return false;
			}
		}

		internal string GetDebugConfigSettings()
		{
			string text = "";
			if (alwaysUseUnityInput)
			{
				text += "Native Input is disabled.\n";
				text = text + "Preferred Unity Input Source: " + fallbackInputSource.ToString() + "\n";
			}
			else
			{
				switch (UnityTools.effectivePlatform)
				{
				case Platform.Windows:
					text = text + "Primary input source: " + windowsStandalonePrimaryInputSource.ToString() + "\n";
					text = text + "Use Windows Gaming Input: " + GetPlatformVar_useWindowsGamingInput() + "\n";
					text = text + "Use XInput: " + useXInput + "\n";
					text = text + "Enhanced Device Support: " + GetPlatformVar_useEnhancedDeviceSupport() + "\n";
					text = text + "Support XR Controllers: " + GetPlatformVar_supportXRControllers() + "\n";
					break;
				case Platform.OSX:
					text = text + "Primary input source: " + osx_primaryInputSource.ToString() + "\n";
					text = text + "Use Apple Game Controller Framework: " + GetPlatformVar_useAppleGameController() + "\n";
					text = text + "Enhanced Device Support: " + GetPlatformVar_useEnhancedDeviceSupport() + "\n";
					text = text + "Support XR Controllers: " + GetPlatformVar_supportXRControllers() + "\n";
					break;
				case Platform.Linux:
					text = text + "Primary input source: " + linux_primaryInputSource.ToString() + "\n";
					text = text + "Enhanced Device Support: " + GetPlatformVar_useEnhancedDeviceSupport() + "\n";
					text = text + "Support XR Controllers: " + GetPlatformVar_supportXRControllers() + "\n";
					break;
				case Platform.WindowsUWP:
					text = text + "Primary input source: " + windowsUWP_primaryInputSource.ToString() + "\n";
					text = text + "Support XR Controllers: " + GetPlatformVar_supportXRControllers() + "\n";
					break;
				case Platform.GameCoreXboxOne:
					text = text + "Primary input source: " + gameCoreXboxOne_primaryInputSource.ToString() + "\n";
					break;
				case Platform.GameCoreScarlett:
					text = text + "Primary input source: " + gameCoreScarlett_primaryInputSource.ToString() + "\n";
					break;
				case Platform.PS4:
					text = text + "Primary input source: " + ps4_primaryInputSource.ToString() + "\n";
					break;
				case Platform.PS5:
					text = text + "Primary input source: " + ps5_primaryInputSource.ToString() + "\n";
					break;
				case Platform.WebGL:
					text = text + "Primary input source: " + webGL_primaryInputSource.ToString() + "\n";
					break;
				}
				text = text + "Native Mouse Handling: " + GetPlatformVar_useNativeMouse() + "\n";
				text = text + "Native Keyboard Handling: " + GetPlatformVar_useNativeKeyboard() + "\n";
				if (UnityTools.isAndroidPlatform && android_primaryInputSource == AndroidPrimaryInputSource.UnityInputManager)
				{
					text = text + "Android: Support Unknown Gamepads: " + android_supportUnknownGamepads + "\n";
				}
			}
			return text;
		}

		[CustomObfuscation(rename = false)]
		internal string GetPlatformVarsRelPath(Platform platform)
		{
			if (platformVarsDict.ContainsKey((int)platform))
			{
				return platformVarsDict[(int)platform].XGCYlrvHXmgPNwdQWfTpHmvDTcjkA;
			}
			throw new NotImplementedException();
		}

		[CustomObfuscation(rename = false)]
		internal PlatformVars GetPlatformVars(Platform platform)
		{
			PlatformVars platformVars = ((platform == Platform.Custom && XKZBcbGtoHHVfKdsghmQDHfhSpIfA.uiJzvtjjXxeMafDzRvVcrucZLjqaA) ? XKZBcbGtoHHVfKdsghmQDHfhSpIfA.RjFADaZbihEZlbXiAtlxCsmPdABB() : ((!platformVarsDict.ContainsKey((int)platform)) ? GetOrCreatePlatformVars(ref platformVars_unknown) : platformVarsDict[(int)platform].LmDOPlrKAhGhwnZFCfubIRWWQqwu()));
			if (platformVars == null)
			{
				platformVars = new PlatformVars();
			}
			return platformVars;
		}

		[CustomObfuscation(rename = false)]
		internal T Editor_GetAllSerializedPlatformVar<T>(AllPlatformVar var)
		{
			if ((object)typeof(T) == typeof(MultiBoolValue))
			{
				return (T)(object)GetAllSerializedPlatformVar_multiBool(var);
			}
			throw new NotImplementedException();
		}

		[CustomObfuscation(rename = false)]
		internal void Editor_SetAllSerializedPlatformVar(AllPlatformVar var, object value)
		{
			foreach (KeyValuePair<int, SSAvBXGpDRxtChfmISGBpOuZcadz> item in platformVarsDict)
			{
				if (getSetPlatformVariableDict.ContainsKey((int)var))
				{
					getSetPlatformVariableDict[(int)var].brrGkKlXvIWyTVvxaymDquvfdkFc((Platform)item.Key, value);
				}
			}
		}

		internal bool GetPlatformVar_disableKeyboard()
		{
			return GetPlatformVars().disableKeyboard;
		}

		internal bool SetPlatformVar_disableKeyboard(bool value)
		{
			return GetPlatformVars().disableKeyboard = value;
		}

		internal bool GetPlatformVar_disableMouse()
		{
			return GetPlatformVars().disableMouse;
		}

		internal bool SetPlatformVar_disableMouse(bool value)
		{
			return GetPlatformVars().disableMouse = value;
		}

		internal bool GetPlatformVar_ignoreInputWhenAppNotInFocus()
		{
			return GetPlatformVars().ignoreInputWhenAppNotInFocus;
		}

		internal bool GetPlatformVar_useEnhancedDeviceSupport()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (!IsEnhancedDeviceSupportAllowed(effectivePlatform))
			{
				return false;
			}
			switch (effectivePlatform)
			{
			case Platform.Windows:
				return useEnhancedDeviceSupport;
			case Platform.OSX:
				return osxStandalone_useEnhancedDeviceSupport;
			case Platform.Linux:
				if (!(platformVars is PlatformVars_LinuxStandalone))
				{
					return false;
				}
				return (platformVars as PlatformVars_LinuxStandalone).useEnhancedDeviceSupport;
			default:
				return false;
			}
		}

		internal bool GetPlatformVar_useNativeMouse()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			if (!IsNativeMouseAllowed(effectivePlatform))
			{
				return false;
			}
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			switch (effectivePlatform)
			{
			case Platform.Windows:
				return useNativeMouse;
			case Platform.Custom:
				if (!(platformVars is CustomPlatformConfigVars))
				{
					return true;
				}
				return (platformVars as CustomPlatformConfigVars).useNativeMouse;
			default:
				return false;
			}
		}

		internal bool GetPlatformVar_useNativeKeyboard()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			if (!IsNativeKeyboardAllowed(effectivePlatform, unityUsePhysicalKeys))
			{
				return false;
			}
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			switch (effectivePlatform)
			{
			case Platform.Windows:
				if (!(platformVars is PlatformVars_WindowsStandalone))
				{
					return true;
				}
				return (platformVars as PlatformVars_WindowsStandalone).useNativeKeyboard;
			case Platform.Custom:
				if (!(platformVars is CustomPlatformConfigVars))
				{
					return true;
				}
				return (platformVars as CustomPlatformConfigVars).useNativeKeyboard;
			default:
				return false;
			}
		}

		internal int GetPlatformVar_joystickRefreshRate()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return 240;
			}
			if (effectivePlatform == Platform.Windows)
			{
				if (!(platformVars is PlatformVars_WindowsStandalone))
				{
					return 240;
				}
				return (platformVars as PlatformVars_WindowsStandalone).joystickRefreshRate;
			}
			return 240;
		}

		internal bool GetPlatformVar_assignJoysticksBySystemId()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			switch (effectivePlatform)
			{
			case Platform.PS4:
				return ps4_assignJoysticksByPS4JoyId;
			case Platform.PS5:
				if (!(platformVars is PlatformVars_PS5))
				{
					return false;
				}
				return (platformVars as PlatformVars_PS5).assignJoysticksByPS5JoyId;
			case Platform.GameCoreXboxOne:
				if (!(platformVars is PlatformVars_GameCoreXboxOne))
				{
					return false;
				}
				return (platformVars as PlatformVars_GameCoreXboxOne).assignJoysticksByUserId;
			case Platform.GameCoreScarlett:
				if (!(platformVars is PlatformVars_GameCoreScarlett))
				{
					return false;
				}
				return (platformVars as PlatformVars_GameCoreScarlett).assignJoysticksByUserId;
			case Platform.OSX:
				if (!(platformVars is PlatformVars_OSXStandalone))
				{
					return false;
				}
				return (platformVars as PlatformVars_OSXStandalone).assignJoysticksByUserId;
			case Platform.iOS:
				if (!(platformVars is PlatformVars_iOS))
				{
					return false;
				}
				return (platformVars as PlatformVars_iOS).assignJoysticksByUserId;
			case Platform.tvOS:
				if (!(platformVars is PlatformVars_tvOS))
				{
					return false;
				}
				return (platformVars as PlatformVars_tvOS).assignJoysticksByUserId;
			default:
				return false;
			}
		}

		internal bool GetPlatformVar_useAppleGameController()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			if (!IsAppleGameControllerFrameworkAllowed(effectivePlatform))
			{
				return false;
			}
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			if (effectivePlatform == Platform.OSX)
			{
				if (!(platformVars is PlatformVars_OSXStandalone))
				{
					return false;
				}
				return (platformVars as PlatformVars_OSXStandalone).useAppleGameController;
			}
			return false;
		}

		internal bool GetPlatformVar_useWindowsGamingInput()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			if (!IsWindowsGamingInputAllowed(effectivePlatform))
			{
				return false;
			}
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			if (effectivePlatform == Platform.Windows)
			{
				if (!(platformVars is PlatformVars_WindowsStandalone))
				{
					return false;
				}
				return (platformVars as PlatformVars_WindowsStandalone).useWindowsGamingInput;
			}
			return false;
		}

		internal IList<EnhancedDeviceSupportDeviceType> GetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return EmptyObjects<EnhancedDeviceSupportDeviceType>.EmptyReadOnlyIListT;
			}
			List<EnhancedDeviceSupportDeviceType> list = null;
			switch (effectivePlatform)
			{
			case Platform.Windows:
				if (platformVars is PlatformVars_WindowsStandalone)
				{
					list = (platformVars as PlatformVars_WindowsStandalone).enhancedDeviceSupportExcludedDeviceTypes;
				}
				break;
			case Platform.OSX:
				if (platformVars is PlatformVars_OSXStandalone)
				{
					list = (platformVars as PlatformVars_OSXStandalone).enhancedDeviceSupportExcludedDeviceTypes;
				}
				break;
			case Platform.Linux:
				if (platformVars is PlatformVars_LinuxStandalone)
				{
					list = (platformVars as PlatformVars_LinuxStandalone).enhancedDeviceSupportExcludedDeviceTypes;
				}
				break;
			}
			if (list != null)
			{
				return new ReadOnlyCollection<EnhancedDeviceSupportDeviceType>(list);
			}
			return EmptyObjects<EnhancedDeviceSupportDeviceType>.EmptyReadOnlyIListT;
		}

		internal bool GetPlatformVar_supportXRControllers()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			switch (effectivePlatform)
			{
			case Platform.Windows:
				if (platformVars is PlatformVars_WindowsStandalone)
				{
					return (platformVars as PlatformVars_WindowsStandalone).supportXRControllers;
				}
				break;
			case Platform.OSX:
				if (platformVars is PlatformVars_OSXStandalone)
				{
					return (platformVars as PlatformVars_OSXStandalone).supportXRControllers;
				}
				break;
			case Platform.Linux:
				if (platformVars is PlatformVars_LinuxStandalone)
				{
					return (platformVars as PlatformVars_LinuxStandalone).supportXRControllers;
				}
				break;
			case Platform.WindowsUWP:
				if (platformVars is PlatformVars_WindowsUWP)
				{
					return (platformVars as PlatformVars_WindowsUWP).supportXRControllers;
				}
				break;
			}
			return false;
		}

		internal bool SetPlatformVar_ignoreInputWhenAppNotInFocus(bool value)
		{
			if (GetPlatformVars().ignoreInputWhenAppNotInFocus == value)
			{
				return false;
			}
			GetPlatformVars().ignoreInputWhenAppNotInFocus = value;
			return true;
		}

		internal bool SetPlatformVar_useEnhancedDeviceSupport(bool value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (!IsEnhancedDeviceSupportAllowed(effectivePlatform))
			{
				return false;
			}
			switch (effectivePlatform)
			{
			case Platform.Windows:
				if (useEnhancedDeviceSupport == value)
				{
					return false;
				}
				useEnhancedDeviceSupport = value;
				return true;
			case Platform.OSX:
				if (osxStandalone_useEnhancedDeviceSupport == value)
				{
					return false;
				}
				osxStandalone_useEnhancedDeviceSupport = value;
				return true;
			case Platform.Linux:
				if (platformVars is PlatformVars_LinuxStandalone)
				{
					(platformVars as PlatformVars_LinuxStandalone).useEnhancedDeviceSupport = value;
				}
				return true;
			default:
				return false;
			}
		}

		internal bool SetPlatformVar_useNativeMouse(bool value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			if (!IsNativeMouseAllowed(effectivePlatform))
			{
				return false;
			}
			switch (effectivePlatform)
			{
			case Platform.Windows:
				if (useNativeMouse == value)
				{
					return false;
				}
				useNativeMouse = value;
				return true;
			case Platform.Custom:
				if (XKZBcbGtoHHVfKdsghmQDHfhSpIfA.uiJzvtjjXxeMafDzRvVcrucZLjqaA)
				{
					XKZBcbGtoHHVfKdsghmQDHfhSpIfA.RjFADaZbihEZlbXiAtlxCsmPdABB().useNativeMouse = value;
					return true;
				}
				return false;
			default:
				return false;
			}
		}

		internal bool SetPlatformVar_useNativeKeyboard(bool value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			if (!IsNativeKeyboardAllowed(effectivePlatform, unityUsePhysicalKeys))
			{
				return false;
			}
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			switch (effectivePlatform)
			{
			case Platform.Windows:
				if (platformVars is PlatformVars_WindowsStandalone)
				{
					(platformVars as PlatformVars_WindowsStandalone).useNativeKeyboard = value;
				}
				return true;
			case Platform.Custom:
				if (XKZBcbGtoHHVfKdsghmQDHfhSpIfA.uiJzvtjjXxeMafDzRvVcrucZLjqaA)
				{
					XKZBcbGtoHHVfKdsghmQDHfhSpIfA.RjFADaZbihEZlbXiAtlxCsmPdABB().useNativeKeyboard = value;
					return true;
				}
				return false;
			default:
				return false;
			}
		}

		internal bool SetPlatformVar_joystickRefreshRate(int value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			if (effectivePlatform == Platform.Windows)
			{
				if (platformVars is PlatformVars_WindowsStandalone)
				{
					(platformVars as PlatformVars_WindowsStandalone).joystickRefreshRate = value;
				}
				return true;
			}
			return false;
		}

		internal bool SetPlatformVar_assignJoysticksBySystemId(bool value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			switch (effectivePlatform)
			{
			case Platform.PS4:
				ps4_assignJoysticksByPS4JoyId = value;
				return true;
			case Platform.PS5:
				if (platformVars is PlatformVars_PS5)
				{
					(platformVars as PlatformVars_PS5).assignJoysticksByPS5JoyId = value;
				}
				return true;
			case Platform.GameCoreXboxOne:
				if (platformVars is PlatformVars_GameCoreXboxOne)
				{
					(platformVars as PlatformVars_GameCoreXboxOne).assignJoysticksByUserId = value;
				}
				return false;
			case Platform.GameCoreScarlett:
				if (platformVars is PlatformVars_GameCoreScarlett)
				{
					(platformVars as PlatformVars_GameCoreScarlett).assignJoysticksByUserId = value;
				}
				return true;
			case Platform.OSX:
				if (platformVars is PlatformVars_OSXStandalone)
				{
					(platformVars as PlatformVars_OSXStandalone).assignJoysticksByUserId = value;
				}
				return true;
			case Platform.iOS:
				if (platformVars is PlatformVars_iOS)
				{
					(platformVars as PlatformVars_iOS).assignJoysticksByUserId = value;
				}
				return true;
			case Platform.tvOS:
				if (platformVars is PlatformVars_tvOS)
				{
					(platformVars as PlatformVars_tvOS).assignJoysticksByUserId = value;
				}
				return true;
			default:
				return false;
			}
		}

		internal bool SetPlatformVar_useAppleGameController(bool value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			if (!IsAppleGameControllerFrameworkAllowed(effectivePlatform))
			{
				return false;
			}
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			if (effectivePlatform == Platform.OSX)
			{
				if (platformVars is PlatformVars_OSXStandalone)
				{
					(platformVars as PlatformVars_OSXStandalone).useAppleGameController = value;
				}
				return true;
			}
			return false;
		}

		internal bool SetPlatformVar_useWindowsGamingInput(bool value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			if (effectivePlatform == Platform.Windows)
			{
				if (platformVars is PlatformVars_WindowsStandalone)
				{
					(platformVars as PlatformVars_WindowsStandalone).useWindowsGamingInput = value;
				}
				return true;
			}
			return false;
		}

		internal bool SetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes(IList<EnhancedDeviceSupportDeviceType> value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			switch (effectivePlatform)
			{
			case Platform.Windows:
				if (platformVars is PlatformVars_WindowsStandalone)
				{
					(platformVars as PlatformVars_WindowsStandalone).enhancedDeviceSupportExcludedDeviceTypes = ((value != null) ? new List<EnhancedDeviceSupportDeviceType>(value) : new List<EnhancedDeviceSupportDeviceType>());
				}
				return true;
			case Platform.OSX:
				if (platformVars is PlatformVars_OSXStandalone)
				{
					(platformVars as PlatformVars_OSXStandalone).enhancedDeviceSupportExcludedDeviceTypes = ((value != null) ? new List<EnhancedDeviceSupportDeviceType>(value) : new List<EnhancedDeviceSupportDeviceType>());
				}
				return true;
			case Platform.Linux:
				if (platformVars is PlatformVars_LinuxStandalone)
				{
					(platformVars as PlatformVars_LinuxStandalone).enhancedDeviceSupportExcludedDeviceTypes = ((value != null) ? new List<EnhancedDeviceSupportDeviceType>(value) : new List<EnhancedDeviceSupportDeviceType>());
				}
				return true;
			default:
				return false;
			}
		}

		internal bool SetPlatformVar_supportXRControllers(bool value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			switch (effectivePlatform)
			{
			case Platform.Windows:
				if (platformVars is PlatformVars_WindowsStandalone)
				{
					(platformVars as PlatformVars_WindowsStandalone).supportXRControllers = value;
					return true;
				}
				break;
			case Platform.OSX:
				if (platformVars is PlatformVars_OSXStandalone)
				{
					(platformVars as PlatformVars_OSXStandalone).supportXRControllers = value;
					return true;
				}
				break;
			case Platform.Linux:
				if (platformVars is PlatformVars_LinuxStandalone)
				{
					(platformVars as PlatformVars_LinuxStandalone).supportXRControllers = value;
					return true;
				}
				break;
			case Platform.WindowsUWP:
				if (platformVars is PlatformVars_WindowsUWP)
				{
					(platformVars as PlatformVars_WindowsUWP).supportXRControllers = value;
					return true;
				}
				break;
			}
			return false;
		}

		private PlatformVars GetPlatformVars()
		{
			Platform platform = UnityTools.effectivePlatform;
			if (!UnityTools.isEditor && UnityTools.isAndroidPlatform)
			{
				platform = Platform.Android;
			}
			return GetPlatformVars(platform);
		}

		private T GetOrCreatePlatformVars<T>(ref T var) where T : PlatformVars, new()
		{
			if (var == null)
			{
				var = new T();
			}
			return var;
		}

		private MultiBoolValue GetAllSerializedPlatformVar_multiBool(AllPlatformVar var)
		{
			bool flag = false;
			bool flag2 = true;
			foreach (KeyValuePair<int, SSAvBXGpDRxtChfmISGBpOuZcadz> item in platformVarsDict)
			{
				if (!getSetPlatformVariableDict.ContainsKey((int)var))
				{
					continue;
				}
				object obj = getSetPlatformVariableDict[(int)var].zlZbAzgYTpBJoPhHuelbyUepLHteA((Platform)item.Key);
				if (obj == null)
				{
					continue;
				}
				if ((object)obj.GetType() != typeof(bool))
				{
					Logger.LogWarning("Incorrect type. Expecting bool, got " + obj.GetType().Name);
					continue;
				}
				bool flag3 = (bool)obj;
				if (flag2)
				{
					flag = flag3;
					flag2 = false;
				}
				else if (flag3 != flag)
				{
					return MultiBoolValue.Mixed;
				}
			}
			if (!flag)
			{
				return MultiBoolValue.Off;
			}
			return MultiBoolValue.On;
		}

		internal bool IsEditModeInputSupported(ControllerType controllerType, EditorPlatform editorPlatform)
		{
			if (alwaysUseUnityInput)
			{
				return false;
			}
			switch (controllerType)
			{
			case ControllerType.Keyboard:
			case ControllerType.Mouse:
				switch (editorPlatform)
				{
				case EditorPlatform.OSX:
				case EditorPlatform.Linux:
					return false;
				case EditorPlatform.Windows:
					if (windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.RawInput || windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.DirectInput || windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
					{
						if (controllerType != ControllerType.Keyboard)
						{
							return useNativeMouse;
						}
						return platformVars_windowsStandalone.useNativeKeyboard;
					}
					return false;
				default:
					return false;
				}
			case ControllerType.Joystick:
				switch (editorPlatform)
				{
				case EditorPlatform.Linux:
					if (linux_primaryInputSource != LinuxStandalonePrimaryInputSource.Native && linux_primaryInputSource != LinuxStandalonePrimaryInputSource.SDL2)
					{
						return linux_primaryInputSource == LinuxStandalonePrimaryInputSource.SDL3;
					}
					return true;
				case EditorPlatform.OSX:
					if (osx_primaryInputSource != MacOSStandalonePrimaryInputSource.Native && osx_primaryInputSource != MacOSStandalonePrimaryInputSource.GameController && osx_primaryInputSource != MacOSStandalonePrimaryInputSource.SDL2)
					{
						return osx_primaryInputSource == MacOSStandalonePrimaryInputSource.SDL3;
					}
					return true;
				case EditorPlatform.Windows:
					if (windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput && windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.XInput && windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.SDL2)
					{
						return windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.SDL3;
					}
					return true;
				default:
					return false;
				}
			default:
				return false;
			}
		}

		internal bool IsNativeMouseAllowed(Platform platform)
		{
			switch (platform)
			{
			case Platform.Windows:
				if (windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput && windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.XInput)
				{
					return windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput;
				}
				return true;
			case Platform.Custom:
				return true;
			default:
				return false;
			}
		}

		internal bool IsNativeKeyboardAllowed(Platform platform)
		{
			switch (platform)
			{
			case Platform.Windows:
				if (windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput && windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.XInput)
				{
					return windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput;
				}
				return true;
			case Platform.Custom:
				return true;
			default:
				return false;
			}
		}

		private bool IsNativeKeyboardAllowed(Platform platform, bool unityUsePhysicalKeys)
		{
			if (!IsNativeKeyboardAllowed(platform))
			{
				return false;
			}
			_ = 10000;
			return true;
		}

		internal bool IsWindowsGamingInputAllowed(Platform platform)
		{
			if (platform == Platform.Windows)
			{
				if (windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput)
				{
					return windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.RawInput;
				}
				return true;
			}
			return false;
		}

		internal bool IsXInputAllowed(Platform platform)
		{
			if (platform == Platform.Windows)
			{
				if (windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput && windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.WindowsGamingInput)
				{
					return windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput;
				}
				return true;
			}
			return false;
		}

		internal bool IsEnhancedDeviceSupportAllowed(Platform platform)
		{
			return platform switch
			{
				Platform.Windows => windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.RawInput, 
				Platform.OSX => osx_primaryInputSource == MacOSStandalonePrimaryInputSource.Native, 
				Platform.Linux => linux_primaryInputSource == LinuxStandalonePrimaryInputSource.Native, 
				_ => false, 
			};
		}

		internal bool IsSupportXRControllersAllowed(Platform platform)
		{
			switch (platform)
			{
			case Platform.Windows:
				if (windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput)
				{
					return windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.DirectInput;
				}
				return true;
			case Platform.OSX:
				return osx_primaryInputSource == MacOSStandalonePrimaryInputSource.Native;
			case Platform.Linux:
				return linux_primaryInputSource == LinuxStandalonePrimaryInputSource.Native;
			case Platform.WindowsUWP:
				return windowsUWP_primaryInputSource == WindowsUWPPrimaryInputSource.Native;
			default:
				return false;
			}
		}

		internal bool IsAppleGameControllerFrameworkAllowed(Platform platform)
		{
			if (platform == Platform.OSX)
			{
				if (osx_primaryInputSource != MacOSStandalonePrimaryInputSource.Native)
				{
					return osx_primaryInputSource == MacOSStandalonePrimaryInputSource.GameController;
				}
				return true;
			}
			return false;
		}

		internal bool DoesAnyPlatformUseUnityInputSystem(bool isPS4PluginInstalled, bool isPS5PluginInstalled)
		{
			if (windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.UnityInputSystem)
			{
				return true;
			}
			if (osx_primaryInputSource == MacOSStandalonePrimaryInputSource.UnityInputSystem)
			{
				return true;
			}
			if (linux_primaryInputSource == LinuxStandalonePrimaryInputSource.UnityInputSystem)
			{
				return true;
			}
			if (windowsUWP_primaryInputSource == WindowsUWPPrimaryInputSource.UnityInputSystem)
			{
				return true;
			}
			if (GetAndroidPrimaryInputSource() == AndroidPrimaryInputSource.UnityInputSystem)
			{
				return true;
			}
			if (GetIOSPrimaryInputSource() == IOSPrimaryInputSource.UnityInputSystem)
			{
				return true;
			}
			if (GetTVOSPrimaryInputSource() == TVOSPrimaryInputSource.UnityInputSystem)
			{
				return true;
			}
			if (webGL_primaryInputSource == WebGLPrimaryInputSource.UnityInputSystem)
			{
				return true;
			}
			if (isPS4PluginInstalled && ps4_primaryInputSource == PS4PrimaryInputSource.PS4UnityInputSystem)
			{
				return true;
			}
			if (isPS5PluginInstalled && ps5_primaryInputSource == PS5PrimaryInputSource.PS5UnityInputSystem)
			{
				return true;
			}
			return false;
		}

		internal bool DoesAnyPlatformUseUnityInputManager(bool isPS4PluginInstalled, bool isPS5PluginInstalled)
		{
			if (alwaysUseUnityInput && GetFallbackUnityInputType() == UnityInputSourceType.InputManager)
			{
				return true;
			}
			if (windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.UnityInputManager)
			{
				return true;
			}
			if (osx_primaryInputSource == MacOSStandalonePrimaryInputSource.UnityInputManager)
			{
				return true;
			}
			if (linux_primaryInputSource == LinuxStandalonePrimaryInputSource.UnityInputManager)
			{
				return true;
			}
			if (isPS4PluginInstalled && ps4_primaryInputSource == PS4PrimaryInputSource.PS4UnityInputManager)
			{
				return true;
			}
			if (isPS5PluginInstalled && ps5_primaryInputSource == PS5PrimaryInputSource.PS5UnityInputManager)
			{
				return true;
			}
			if (GetAndroidPrimaryInputSource() == AndroidPrimaryInputSource.UnityInputManager)
			{
				return true;
			}
			if (GetIOSPrimaryInputSource() == IOSPrimaryInputSource.UnityInputManager)
			{
				return true;
			}
			if (GetTVOSPrimaryInputSource() == TVOSPrimaryInputSource.UnityInputManager)
			{
				return true;
			}
			return false;
		}

		internal UnityPrimaryInputSource GetUnityInputSourceDependency(Platform platform)
		{
			switch (platform)
			{
			case Platform.Windows:
				if (windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.UnityInputManager)
				{
					if (windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.UnityInputSystem)
					{
						return UnityPrimaryInputSource.None;
					}
					return UnityPrimaryInputSource.InputSystem;
				}
				return UnityPrimaryInputSource.InputManager;
			case Platform.OSX:
				if (osx_primaryInputSource != MacOSStandalonePrimaryInputSource.UnityInputManager)
				{
					if (osx_primaryInputSource != MacOSStandalonePrimaryInputSource.UnityInputSystem)
					{
						return UnityPrimaryInputSource.None;
					}
					return UnityPrimaryInputSource.InputSystem;
				}
				return UnityPrimaryInputSource.InputManager;
			case Platform.Linux:
				if (linux_primaryInputSource != LinuxStandalonePrimaryInputSource.UnityInputManager)
				{
					if (linux_primaryInputSource != LinuxStandalonePrimaryInputSource.UnityInputSystem)
					{
						return UnityPrimaryInputSource.None;
					}
					return UnityPrimaryInputSource.InputSystem;
				}
				return UnityPrimaryInputSource.InputManager;
			case Platform.WindowsUWP:
				if (windowsUWP_primaryInputSource != WindowsUWPPrimaryInputSource.UnityInputSystem)
				{
					return UnityPrimaryInputSource.None;
				}
				return UnityPrimaryInputSource.InputSystem;
			case Platform.PS4:
				if (ps4_primaryInputSource != PS4PrimaryInputSource.PS4UnityInputManager)
				{
					if (ps4_primaryInputSource != PS4PrimaryInputSource.PS4UnityInputSystem)
					{
						return UnityPrimaryInputSource.None;
					}
					return UnityPrimaryInputSource.InputSystem;
				}
				return UnityPrimaryInputSource.InputManager;
			case Platform.PS5:
				if (ps5_primaryInputSource != PS5PrimaryInputSource.PS5UnityInputManager)
				{
					if (ps5_primaryInputSource != PS5PrimaryInputSource.PS5UnityInputSystem)
					{
						return UnityPrimaryInputSource.None;
					}
					return UnityPrimaryInputSource.InputSystem;
				}
				return UnityPrimaryInputSource.InputManager;
			case Platform.iOS:
				if (GetIOSPrimaryInputSource() != IOSPrimaryInputSource.UnityInputManager)
				{
					if (GetIOSPrimaryInputSource() != IOSPrimaryInputSource.UnityInputSystem)
					{
						return UnityPrimaryInputSource.None;
					}
					return UnityPrimaryInputSource.InputSystem;
				}
				return UnityPrimaryInputSource.InputManager;
			case Platform.tvOS:
				if (GetTVOSPrimaryInputSource() != TVOSPrimaryInputSource.UnityInputManager)
				{
					if (GetTVOSPrimaryInputSource() != TVOSPrimaryInputSource.UnityInputSystem)
					{
						return UnityPrimaryInputSource.None;
					}
					return UnityPrimaryInputSource.InputSystem;
				}
				return UnityPrimaryInputSource.InputManager;
			case Platform.WebGL:
				if (webGL_primaryInputSource != WebGLPrimaryInputSource.UnityInputSystem)
				{
					return UnityPrimaryInputSource.None;
				}
				return UnityPrimaryInputSource.InputSystem;
			default:
				if (UnityTools.fMJBBdGcIQIZWgCBcREeBOMATWCvE(platform))
				{
					if (GetAndroidPrimaryInputSource() != AndroidPrimaryInputSource.UnityInputManager)
					{
						if (GetAndroidPrimaryInputSource() != AndroidPrimaryInputSource.UnityInputSystem)
						{
							return UnityPrimaryInputSource.None;
						}
						return UnityPrimaryInputSource.InputSystem;
					}
					return UnityPrimaryInputSource.InputManager;
				}
				return UnityPrimaryInputSource.None;
			}
		}

		internal static bool SupportsUnityInputSourceType(Platform platform, UnityInputSourceType unityInputSourceType)
		{
			if (UnityTools.fMJBBdGcIQIZWgCBcREeBOMATWCvE(platform))
			{
				return true;
			}
			switch (platform)
			{
			case Platform.WebGL:
			case Platform.WindowsUWP:
				return unityInputSourceType == UnityInputSourceType.InputSystem;
			case Platform.Windows:
			case Platform.OSX:
			case Platform.iOS:
			case Platform.Linux:
			case Platform.tvOS:
			case Platform.VisionOS:
			case Platform.Custom:
				return true;
			case Platform.XboxOne:
			case Platform.PS4:
			case Platform.Switch:
			case Platform.Switch2:
			case Platform.GameCoreXboxOne:
			case Platform.GameCoreScarlett:
			case Platform.PS5:
				return false;
			default:
				return false;
			}
		}

		internal static bool RequiresPlugin(Platform platform)
		{
			if (platform == Platform.PS4 || (uint)(platform - 32) <= 1u || (uint)(platform - 104) <= 2u)
			{
				return true;
			}
			return false;
		}

		internal AndroidPrimaryInputSource GetAndroidPrimaryInputSource()
		{
			if (android_primaryInputSource == (AndroidPrimaryInputSource)102)
			{
				return GetFallbackUnityInputType() switch
				{
					UnityInputSourceType.InputManager => AndroidPrimaryInputSource.UnityInputManager, 
					UnityInputSourceType.InputSystem => AndroidPrimaryInputSource.UnityInputSystem, 
					_ => throw new NotImplementedException(), 
				};
			}
			return android_primaryInputSource;
		}

		internal IOSPrimaryInputSource GetIOSPrimaryInputSource()
		{
			if (ios_primaryInputSource == (IOSPrimaryInputSource)102)
			{
				return GetFallbackUnityInputType() switch
				{
					UnityInputSourceType.InputManager => IOSPrimaryInputSource.UnityInputManager, 
					UnityInputSourceType.InputSystem => IOSPrimaryInputSource.UnityInputSystem, 
					_ => throw new NotImplementedException(), 
				};
			}
			return ios_primaryInputSource;
		}

		internal TVOSPrimaryInputSource GetTVOSPrimaryInputSource()
		{
			if (tvos_primaryInputSource == (TVOSPrimaryInputSource)102)
			{
				return GetFallbackUnityInputType() switch
				{
					UnityInputSourceType.InputManager => TVOSPrimaryInputSource.UnityInputManager, 
					UnityInputSourceType.InputSystem => TVOSPrimaryInputSource.UnityInputSystem, 
					_ => throw new NotImplementedException(), 
				};
			}
			return tvos_primaryInputSource;
		}

		internal UnityInputSourceType GetFallbackUnityInputType()
		{
			if (UnityTools.supportsUnityInputSystem)
			{
				if (UnityTools.isUnityInputSystemEnabled)
				{
					if (UnityTools.isUnityInputManagerEnabled)
					{
						return fallbackInputSource;
					}
					return UnityInputSourceType.InputSystem;
				}
				_ = UnityTools.isUnityInputManagerEnabled;
				return UnityInputSourceType.InputManager;
			}
			return UnityInputSourceType.InputManager;
		}
	}
}
