using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.InputManagers;
using Rewired.Interfaces;
using Rewired.Internal.Glyphs;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Platforms.Custom;
using Rewired.Platforms.UnityInputSystem;
using Rewired.Utils;
using Rewired.Utils.Classes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired
{
	public static class ReInput
	{
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class LocalizationHelper : CodeHelper
		{
			private static LocalizationHelper iBulTHqwYgMSCaHGpfpKaxWrvaxi;

			internal static LocalizationHelper BbDtvNZzjkwYPjUMWFeyUUWrqHFL => iBulTHqwYgMSCaHGpfpKaxWrvaxi ?? (iBulTHqwYgMSCaHGpfpKaxWrvaxi = new LocalizationHelper());

			public ILocalizedStringProvider localizedStringProvider
			{
				get
				{
					if (!CheckInitialized())
					{
						return null;
					}
					return LocalizationManager.localizedStringProvider;
				}
				set
				{
					if (CheckInitialized())
					{
						LocalizationManager.localizedStringProvider = value;
					}
				}
			}

			public bool prefetch
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return LocalizationManager.autoPrefetch;
				}
				set
				{
					if (CheckInitialized())
					{
						LocalizationManager.autoPrefetch = value;
					}
				}
			}

			private LocalizationHelper()
			{
			}

			internal static void fQGpbMxoARPlLuInATOMgapyYkC()
			{
				iBulTHqwYgMSCaHGpfpKaxWrvaxi = null;
			}

			public void Reload()
			{
				if (CheckInitialized())
				{
					LocalizationManager.Reload();
				}
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class GlyphHelper : CodeHelper
		{
			private static GlyphHelper oxyWVKfNWqlVyJJWYgxzCyiLLgCuA;

			internal static GlyphHelper XVvXDYLbvEAmVlwdhtTNnPjaUGV => oxyWVKfNWqlVyJJWYgxzCyiLLgCuA ?? (oxyWVKfNWqlVyJJWYgxzCyiLLgCuA = new GlyphHelper());

			public IGlyphProvider glyphProvider
			{
				get
				{
					if (!CheckInitialized())
					{
						return null;
					}
					return GlyphManager.glyphProvider;
				}
				set
				{
					if (CheckInitialized())
					{
						GlyphManager.glyphProvider = value;
					}
				}
			}

			public bool prefetch
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return GlyphManager.autoPrefetch;
				}
				set
				{
					if (CheckInitialized())
					{
						GlyphManager.autoPrefetch = value;
					}
				}
			}

			private GlyphHelper()
			{
			}

			internal static void LDheNbaWCcMShgGFVHcYmadUkBIiA()
			{
				oxyWVKfNWqlVyJJWYgxzCyiLLgCuA = null;
			}

			public void Reload()
			{
				if (CheckInitialized())
				{
					GlyphManager.Reload();
				}
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ConfigHelper : CodeHelper
		{
			private static ConfigHelper eVUAozeirokdnzoGioJfHEgTGYFXA;

			private float NCZecBLROqxBZemgewRHFkpfZtrV = 0.7f;

			private float VYtTvinxMAcKREjdHBgsubAkxAsQ = 100f;

			internal static ConfigHelper ZcYrKCkJuNJCAMGMyerfLChsULiL => eVUAozeirokdnzoGioJfHEgTGYFXA ?? (eVUAozeirokdnzoGioJfHEgTGYFXA = new ConfigHelper());

			public bool useXInput
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					if (UnityTools.effectivePlatform == Platform.WindowsUWP)
					{
						return windowsUWPSupportGamepads;
					}
					if (!CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.IsXInputAllowed(UnityTools.effectivePlatform))
					{
						return false;
					}
					if (UnityTools.effectivePlatform == Platform.Windows && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
					{
						return true;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.useXInput;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					if (UnityTools.effectivePlatform == Platform.WindowsUWP)
					{
						windowsUWPSupportGamepads = value;
					}
					else
					{
						if (CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.useXInput == value)
						{
							return;
						}
						if (value)
						{
							if (CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
							{
								return;
							}
							if (UnityTools.effectivePlatform == Platform.Windows && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.WindowsGamingInput)
							{
								Logger.LogWarning("XInput cannot be enabled with the current primary input source: " + CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.windowsStandalonePrimaryInputSource);
								return;
							}
						}
						else if (UnityTools.effectivePlatform == Platform.Windows && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
						{
							CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							Logger.LogWarning("XInput cannot be used with the current primary input source. The primary input source has been changed to Raw Input.");
						}
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.useXInput = value;
						if (SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
						{
							SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
						}
					}
				}
			}

			public bool useWindowsGamingInput
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					if (UnityTools.effectivePlatform == Platform.Windows && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
					{
						return true;
					}
					if (UnityTools.effectivePlatform == Platform.WindowsUWP)
					{
						return windowsUWPSupportGamepads;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.GetPlatformVar_useWindowsGamingInput();
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					if (UnityTools.effectivePlatform == Platform.WindowsUWP)
					{
						windowsUWPSupportGamepads = value;
					}
					else
					{
						if (CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.GetPlatformVar_useWindowsGamingInput() == value)
						{
							return;
						}
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.SetPlatformVar_useWindowsGamingInput(value);
						if (value)
						{
							if (CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
							{
								return;
							}
							if (UnityTools.effectivePlatform == Platform.Windows && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput)
							{
								Logger.LogWarning("Windows Gaming Input cannot be enabled with the current primary input source: " + CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.windowsStandalonePrimaryInputSource);
								return;
							}
						}
						else if (UnityTools.effectivePlatform == Platform.Windows && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
						{
							CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							Logger.LogWarning("Windows Gaming Input cannot be used with the current primary input source. The primary input source has been changed to Raw Input.");
						}
						if (SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
						{
							SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
						}
					}
				}
			}

			public UpdateMode updateMode
			{
				get
				{
					if (!CheckInitialized())
					{
						return UpdateMode.Automatic;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.updateMode;
				}
				set
				{
					if (CheckInitialized() && value != CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.updateMode)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.updateMode = value;
						if (SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
						{
							SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
						}
					}
				}
			}

			public UpdateLoopSetting updateLoop
			{
				get
				{
					if (!CheckInitialized())
					{
						return UpdateLoopSetting.Update;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.updateLoop;
				}
				set
				{
					if (CheckInitialized() && value != CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.updateLoop)
					{
						if ((value & UpdateLoopSetting.Update) == 0)
						{
							value |= UpdateLoopSetting.Update;
						}
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.updateLoop = value;
						if (SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
						{
							SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
						}
					}
				}
			}

			public WindowsStandalonePrimaryInputSource windowsStandalonePrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return WindowsStandalonePrimaryInputSource.RawInput;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.windowsStandalonePrimaryInputSource;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.windowsStandalonePrimaryInputSource != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.windowsStandalonePrimaryInputSource = value;
						if (UnityTools.effectivePlatform == Platform.Windows && value == WindowsStandalonePrimaryInputSource.XInput)
						{
							CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.useXInput = true;
						}
						if (SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
						{
							SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
						}
					}
				}
			}

			[Obsolete("Use macOSStandalonePrimaryInputSource instead.", false)]
			public OSXStandalonePrimaryInputSource osxStandalonePrimaryInputSource
			{
				get
				{
					return (OSXStandalonePrimaryInputSource)macOSStandalonePrimaryInputSource;
				}
				set
				{
					macOSStandalonePrimaryInputSource = (MacOSStandalonePrimaryInputSource)value;
				}
			}

			public MacOSStandalonePrimaryInputSource macOSStandalonePrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return MacOSStandalonePrimaryInputSource.Native;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.osx_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.osx_primaryInputSource != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.osx_primaryInputSource = value;
						if (SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
						{
							SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
						}
					}
				}
			}

			public LinuxStandalonePrimaryInputSource linuxStandalonePrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return LinuxStandalonePrimaryInputSource.Native;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.linux_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.linux_primaryInputSource != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.linux_primaryInputSource = value;
						if (SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
						{
							SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
						}
					}
				}
			}

			public WindowsUWPPrimaryInputSource windowsUWPPrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return WindowsUWPPrimaryInputSource.Native;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.windowsUWP_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.windowsUWP_primaryInputSource != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.windowsUWP_primaryInputSource = value;
						if (SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
						{
							SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
						}
					}
				}
			}

			public bool windowsUWPSupportHIDDevices
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return (CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useHIDAPI;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					if (platformVars_WindowsUWP.useHIDAPI != value)
					{
						platformVars_WindowsUWP.useHIDAPI = value;
						if (SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
						{
							SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
						}
					}
				}
			}

			public bool windowsUWPSupportGamepads
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return (CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useGamepadAPI;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					if (platformVars_WindowsUWP.useGamepadAPI != value)
					{
						platformVars_WindowsUWP.useGamepadAPI = value;
						if (SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
						{
							SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
						}
					}
				}
			}

			public bool useAppleGameControllerFramework
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					if (UnityTools.effectivePlatform == Platform.OSX && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.osx_primaryInputSource == MacOSStandalonePrimaryInputSource.GameController)
					{
						return true;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.GetPlatformVar_useAppleGameController();
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.GetPlatformVar_useAppleGameController() != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.SetPlatformVar_useAppleGameController(value);
						if (SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
						{
							SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
						}
					}
				}
			}

			public PS4PrimaryInputSource ps4PrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return PS4PrimaryInputSource.PS4UnityInputManager;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.ps4_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.ps4_primaryInputSource != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.ps4_primaryInputSource = value;
						if (SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
						{
							SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
						}
					}
				}
			}

			public PS5PrimaryInputSource ps5PrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return PS5PrimaryInputSource.PS5UnityInputManager;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.ps5_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.ps5_primaryInputSource != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.ps5_primaryInputSource = value;
						if (SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
						{
							SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
						}
					}
				}
			}

			public WebGLPrimaryInputSource webGLPrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return WebGLPrimaryInputSource.Native;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.webGL_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.webGL_primaryInputSource != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.webGL_primaryInputSource = value;
						if (SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
						{
							SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
						}
					}
				}
			}

			public AndroidPrimaryInputSource androidPrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return AndroidPrimaryInputSource.UnityInputManager;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.GetAndroidPrimaryInputSource();
				}
				set
				{
					if (!CheckInitialized() || CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.GetAndroidPrimaryInputSource() == value)
					{
						return;
					}
					if (!UnityTools.supportsUnityInputSystem && value == AndroidPrimaryInputSource.UnityInputSystem)
					{
						Logger.LogWarning("Unity 2021.2+ is required to use Unity Input System.");
						return;
					}
					CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.android_primaryInputSource = value;
					if (SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
					{
						SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
					}
				}
			}

			public IOSPrimaryInputSource iOSPrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return IOSPrimaryInputSource.UnityInputManager;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.GetIOSPrimaryInputSource();
				}
				set
				{
					if (!CheckInitialized() || CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.GetIOSPrimaryInputSource() == value)
					{
						return;
					}
					if (!UnityTools.supportsUnityInputSystem && value == IOSPrimaryInputSource.UnityInputSystem)
					{
						Logger.LogWarning("Unity 2021.2+ is required to use Unity Input System.");
						return;
					}
					CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.ios_primaryInputSource = value;
					if (SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
					{
						SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
					}
				}
			}

			public TVOSPrimaryInputSource tvOSPrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return TVOSPrimaryInputSource.UnityInputManager;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.GetTVOSPrimaryInputSource();
				}
				set
				{
					if (!CheckInitialized() || CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.GetTVOSPrimaryInputSource() == value)
					{
						return;
					}
					if (!UnityTools.supportsUnityInputSystem && value == TVOSPrimaryInputSource.UnityInputSystem)
					{
						Logger.LogWarning("Unity 2021.2+ is required to use Unity Input System.");
						return;
					}
					CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.tvos_primaryInputSource = value;
					if (SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
					{
						SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
					}
				}
			}

			public bool alwaysUseUnityInput
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.alwaysUseUnityInput;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.alwaysUseUnityInput != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.alwaysUseUnityInput = value;
						if (SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
						{
							SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
						}
					}
				}
			}

			public bool disableNativeInput
			{
				get
				{
					return alwaysUseUnityInput;
				}
				set
				{
					alwaysUseUnityInput = value;
				}
			}

			public bool nativeMouseSupport
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.GetPlatformVar_useNativeMouse();
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.SetPlatformVar_useNativeMouse(value) && SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
					{
						SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
					}
				}
			}

			public bool nativeKeyboardSupport
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.GetPlatformVar_useNativeKeyboard();
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.SetPlatformVar_useNativeKeyboard(value) && SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
					{
						SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
					}
				}
			}

			public bool enhancedDeviceSupport
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.GetPlatformVar_useEnhancedDeviceSupport();
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.SetPlatformVar_useEnhancedDeviceSupport(value) && SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
					{
						SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
					}
				}
			}

			public int joystickRefreshRate
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.GetPlatformVar_joystickRefreshRate();
				}
				set
				{
					if (CheckInitialized())
					{
						value = MathTools.Clamp(value, 0, 2000);
						if (value == 0)
						{
							value = 240;
						}
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.SetPlatformVar_joystickRefreshRate(value);
					}
				}
			}

			public bool ignoreInputWhenAppNotInFocus
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.GetPlatformVar_ignoreInputWhenAppNotInFocus();
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.SetPlatformVar_ignoreInputWhenAppNotInFocus(value))
					{
						ULbEgoDZFDMZbbzkKZNWvvPyiQxg();
					}
				}
			}

			public bool android_supportUnknownGamepads
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.android_supportUnknownGamepads;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.android_supportUnknownGamepads != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.android_supportUnknownGamepads = value;
						if (SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
						{
							SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
						}
					}
				}
			}

			public DeadZone2DType defaultJoystickAxis2DDeadZoneType
			{
				get
				{
					if (!CheckInitialized())
					{
						return DeadZone2DType.Radial;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.defaultJoystickAxis2DDeadZoneType;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.defaultJoystickAxis2DDeadZoneType != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.defaultJoystickAxis2DDeadZoneType = value;
					}
				}
			}

			public AxisSensitivity2DType defaultJoystickAxis2DSensitivityType
			{
				get
				{
					if (!CheckInitialized())
					{
						return AxisSensitivity2DType.Radial;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.defaultJoystickAxis2DSensitivityType;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.defaultJoystickAxis2DSensitivityType != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.defaultJoystickAxis2DSensitivityType = value;
					}
				}
			}

			public AxisSensitivityType defaultAxisSensitivityType
			{
				get
				{
					if (!CheckInitialized())
					{
						return AxisSensitivityType.Multiplier;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.defaultAxisSensitivityType;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.defaultAxisSensitivityType != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.defaultAxisSensitivityType = value;
					}
				}
			}

			public bool force4WayHats
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.force4WayHats;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.force4WayHats != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.force4WayHats = value;
					}
				}
			}

			public float defaultAbsoluteAxisPollingDeadZone
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0.7f;
					}
					return NCZecBLROqxBZemgewRHFkpfZtrV;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 0f)
						{
							value = 0f;
						}
						if (NCZecBLROqxBZemgewRHFkpfZtrV != value)
						{
							NCZecBLROqxBZemgewRHFkpfZtrV = value;
						}
					}
				}
			}

			public float defaultRelativeAxisPollingDeadZone
			{
				get
				{
					if (!CheckInitialized())
					{
						return 100f;
					}
					return VYtTvinxMAcKREjdHBgsubAkxAsQ;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 0f)
						{
							value = 0f;
						}
						if (VYtTvinxMAcKREjdHBgsubAkxAsQ != value)
						{
							VYtTvinxMAcKREjdHBgsubAkxAsQ = value;
						}
					}
				}
			}

			public bool activateActionButtonsOnNegativeValue
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.activateActionButtonsOnNegativeValue;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.activateActionButtonsOnNegativeValue != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.activateActionButtonsOnNegativeValue = value;
					}
				}
			}

			public ThrottleCalibrationMode throttleCalibrationMode
			{
				get
				{
					if (!CheckInitialized())
					{
						return ThrottleCalibrationMode.ZeroToOne;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.throttleCalibrationMode;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.throttleCalibrationMode != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.throttleCalibrationMode = value;
						jFidDAJTYMYSSrBGXbdjHWSiLLLfB.FbKrVvakyqalEEZGRgQDiQMzkPFW(value);
					}
				}
			}

			public bool deferControllerConnectedEventsOnStart
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.deferControllerConnectedEventsOnStart;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.deferControllerConnectedEventsOnStart != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.deferControllerConnectedEventsOnStart = value;
					}
				}
			}

			public KeyCombinationOverrideMode keyCombinationOverrideMode
			{
				get
				{
					if (!CheckInitialized())
					{
						return KeyCombinationOverrideMode.Cancel;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.keyCombinationOverrideMode;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.keyCombinationOverrideMode != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.keyCombinationOverrideMode = value;
					}
				}
			}

			public bool generateKeyEventsOnKeyCombinationOverride
			{
				get
				{
					if (!CheckInitialized())
					{
						return true;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.generateKeyEventsOnKeyCombinationOverride;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.generateKeyEventsOnKeyCombinationOverride != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.generateKeyEventsOnKeyCombinationOverride = value;
					}
				}
			}

			public bool autoAssignJoysticks
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.autoAssignJoysticks;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.autoAssignJoysticks != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.autoAssignJoysticks = value;
					}
				}
			}

			public int maxJoysticksPerPlayer
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.maxJoysticksPerPlayer;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 1)
						{
							value = 1;
						}
						if (CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.maxJoysticksPerPlayer != value)
						{
							CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.maxJoysticksPerPlayer = value;
						}
					}
				}
			}

			public bool distributeJoysticksEvenly
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.distributeJoysticksEvenly;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.distributeJoysticksEvenly != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.distributeJoysticksEvenly = value;
					}
				}
			}

			public bool assignJoysticksToPlayingPlayersOnly
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.assignJoysticksToPlayingPlayersOnly;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.assignJoysticksToPlayingPlayersOnly != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.assignJoysticksToPlayingPlayersOnly = value;
					}
				}
			}

			public bool reassignJoystickToPreviousOwnerOnReconnect
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect = value;
					}
				}
			}

			public LogLevelFlags logLevel
			{
				get
				{
					if (!CheckInitialized())
					{
						return LogLevelFlags.Off;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.logLevel;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.logLevel != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.logLevel = value;
					}
				}
			}

			public List<EnhancedDeviceSupportDeviceType> enhancedDeviceSupportExcludedDeviceTypes
			{
				get
				{
					if (!CheckInitialized())
					{
						return new List<EnhancedDeviceSupportDeviceType>();
					}
					return new List<EnhancedDeviceSupportDeviceType>(CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.GetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes());
				}
				set
				{
					if (CheckInitialized())
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.SetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes(value);
						if (SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
						{
							SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
						}
					}
				}
			}

			public bool disableAxis2dClamping
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.disableAxis2dClamping;
				}
				set
				{
					if (CheckInitialized() && CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.disableAxis2dClamping != value)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.disableAxis2dClamping = value;
					}
				}
			}

			public bool supportXRControllers
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.GetPlatformVar_supportXRControllers();
				}
				set
				{
					if (CheckInitialized() && value != CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.GetPlatformVar_supportXRControllers())
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.SetPlatformVar_supportXRControllers(value);
						if (SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
						{
							SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
						}
					}
				}
			}

			public bool showSystemKeyLabels
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.showSystemKeyLabels;
				}
				set
				{
					if (CheckInitialized() && value != CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.showSystemKeyLabels)
					{
						CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.showSystemKeyLabels = value;
					}
				}
			}

			public bool tvOS_enableBackButtonReturnsHome
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.platformVars_tvOS?.enableBackButtonReturnsHome ?? false;
				}
				set
				{
					if (CheckInitialized())
					{
						ConfigVars.PlatformVars_tvOS platformVars_tvOS = CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.platformVars_tvOS;
						if (platformVars_tvOS != null && platformVars_tvOS.enableBackButtonReturnsHome != value)
						{
							platformVars_tvOS.enableBackButtonReturnsHome = value;
							platformVars_tvOS.lTwUVYvPwGglPmMfbaiQDbSOZVOn();
						}
					}
				}
			}

			public bool tvOS_useAbsoluteRemoteTouchpadMode
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.platformVars_tvOS?.useAbsoluteRemoteTouchpadMode ?? false;
				}
				set
				{
					if (CheckInitialized())
					{
						ConfigVars.PlatformVars_tvOS platformVars_tvOS = CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.platformVars_tvOS;
						if (platformVars_tvOS != null && platformVars_tvOS.useAbsoluteRemoteTouchpadMode != value)
						{
							platformVars_tvOS.useAbsoluteRemoteTouchpadMode = value;
							platformVars_tvOS.lTwUVYvPwGglPmMfbaiQDbSOZVOn();
						}
					}
				}
			}

			public bool tvOS_allowRemoteDPadRotation
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.platformVars_tvOS?.allowRemoteDPadRotation ?? false;
				}
				set
				{
					if (CheckInitialized())
					{
						ConfigVars.PlatformVars_tvOS platformVars_tvOS = CMuKNpKzoZWoovDXKkZgsiLlOCFy.ConfigVars.platformVars_tvOS;
						if (platformVars_tvOS != null && platformVars_tvOS.allowRemoteDPadRotation != value)
						{
							platformVars_tvOS.allowRemoteDPadRotation = value;
							platformVars_tvOS.lTwUVYvPwGglPmMfbaiQDbSOZVOn();
						}
					}
				}
			}

			private ConfigHelper()
			{
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ControllerHelper : CodeHelper
		{
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class PollingHelper : CodeHelper
			{
				private sealed class ddrDyoGQZTBDnEPlOsOcQtjBIXCAb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int YUfGUyEFJFpnGMgqaTPYlqThsdaCA;

					private ControllerPollingInfo ytgeJfHLuiNMDzRNoOhknnUWPyGj;

					private int EdGHPNiiBZZXAQqqQLPBNYgIwsaf;

					public PollingHelper FymidxZJdhZGcaxjjMyfifzDbhgBA;

					private IEnumerator<ControllerPollingInfo> zlNelhSiynFWwbFbejlgkzpDlRujA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ytgeJfHLuiNMDzRNoOhknnUWPyGj;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ytgeJfHLuiNMDzRNoOhknnUWPyGj;
						}
					}

					[DebuggerHidden]
					public ddrDyoGQZTBDnEPlOsOcQtjBIXCAb(int P_0)
					{
						YUfGUyEFJFpnGMgqaTPYlqThsdaCA = P_0;
						EdGHPNiiBZZXAQqqQLPBNYgIwsaf = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (YUfGUyEFJFpnGMgqaTPYlqThsdaCA)
						{
						case -3:
						case 1:
							try
							{
							}
							finally
							{
								eqIybZxLFoyFDJTMOZNWLJdNZRDj();
							}
							break;
						case -4:
						case 2:
							try
							{
							}
							finally
							{
								CcwWExWQWPtFGbGCNbPTDlTclZSqA();
							}
							break;
						case -5:
						case 3:
							try
							{
							}
							finally
							{
								LouAhciUaCKHpsqlgUTaCkDYXmMFA();
							}
							break;
						}
						zlNelhSiynFWwbFbejlgkzpDlRujA = null;
						YUfGUyEFJFpnGMgqaTPYlqThsdaCA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int yUfGUyEFJFpnGMgqaTPYlqThsdaCA = YUfGUyEFJFpnGMgqaTPYlqThsdaCA;
							PollingHelper fymidxZJdhZGcaxjjMyfifzDbhgBA = FymidxZJdhZGcaxjjMyfifzDbhgBA;
							switch (yUfGUyEFJFpnGMgqaTPYlqThsdaCA)
							{
							default:
								return false;
							case 0:
								YUfGUyEFJFpnGMgqaTPYlqThsdaCA = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								zlNelhSiynFWwbFbejlgkzpDlRujA = fymidxZJdhZGcaxjjMyfifzDbhgBA.zUQBHBBNjGDpxhSbFSYWoNpCJhFo().GetEnumerator();
								YUfGUyEFJFpnGMgqaTPYlqThsdaCA = -3;
								goto IL_0084;
							case 1:
								YUfGUyEFJFpnGMgqaTPYlqThsdaCA = -3;
								goto IL_0084;
							case 2:
								YUfGUyEFJFpnGMgqaTPYlqThsdaCA = -4;
								goto IL_00e4;
							case 3:
								{
									YUfGUyEFJFpnGMgqaTPYlqThsdaCA = -5;
									break;
								}
								IL_00e4:
								if (zlNelhSiynFWwbFbejlgkzpDlRujA.MoveNext())
								{
									ControllerPollingInfo current = zlNelhSiynFWwbFbejlgkzpDlRujA.Current;
									ytgeJfHLuiNMDzRNoOhknnUWPyGj = current;
									YUfGUyEFJFpnGMgqaTPYlqThsdaCA = 2;
									return true;
								}
								CcwWExWQWPtFGbGCNbPTDlTclZSqA();
								zlNelhSiynFWwbFbejlgkzpDlRujA = null;
								zlNelhSiynFWwbFbejlgkzpDlRujA = fymidxZJdhZGcaxjjMyfifzDbhgBA.llpmOicAesCFuMVMZfdpLHIdXQIj().GetEnumerator();
								YUfGUyEFJFpnGMgqaTPYlqThsdaCA = -5;
								break;
								IL_0084:
								if (zlNelhSiynFWwbFbejlgkzpDlRujA.MoveNext())
								{
									ControllerPollingInfo current2 = zlNelhSiynFWwbFbejlgkzpDlRujA.Current;
									ytgeJfHLuiNMDzRNoOhknnUWPyGj = current2;
									YUfGUyEFJFpnGMgqaTPYlqThsdaCA = 1;
									return true;
								}
								eqIybZxLFoyFDJTMOZNWLJdNZRDj();
								zlNelhSiynFWwbFbejlgkzpDlRujA = null;
								zlNelhSiynFWwbFbejlgkzpDlRujA = fymidxZJdhZGcaxjjMyfifzDbhgBA.tJZjzoYpuBSRYXOyYmtPKnaYgLk().GetEnumerator();
								YUfGUyEFJFpnGMgqaTPYlqThsdaCA = -4;
								goto IL_00e4;
							}
							if (zlNelhSiynFWwbFbejlgkzpDlRujA.MoveNext())
							{
								ControllerPollingInfo current3 = zlNelhSiynFWwbFbejlgkzpDlRujA.Current;
								ytgeJfHLuiNMDzRNoOhknnUWPyGj = current3;
								YUfGUyEFJFpnGMgqaTPYlqThsdaCA = 3;
								return true;
							}
							LouAhciUaCKHpsqlgUTaCkDYXmMFA();
							zlNelhSiynFWwbFbejlgkzpDlRujA = null;
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void eqIybZxLFoyFDJTMOZNWLJdNZRDj()
					{
						YUfGUyEFJFpnGMgqaTPYlqThsdaCA = -1;
						if (zlNelhSiynFWwbFbejlgkzpDlRujA != null)
						{
							zlNelhSiynFWwbFbejlgkzpDlRujA.Dispose();
						}
					}

					private void CcwWExWQWPtFGbGCNbPTDlTclZSqA()
					{
						YUfGUyEFJFpnGMgqaTPYlqThsdaCA = -1;
						if (zlNelhSiynFWwbFbejlgkzpDlRujA != null)
						{
							zlNelhSiynFWwbFbejlgkzpDlRujA.Dispose();
						}
					}

					private void LouAhciUaCKHpsqlgUTaCkDYXmMFA()
					{
						YUfGUyEFJFpnGMgqaTPYlqThsdaCA = -1;
						if (zlNelhSiynFWwbFbejlgkzpDlRujA != null)
						{
							zlNelhSiynFWwbFbejlgkzpDlRujA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						ddrDyoGQZTBDnEPlOsOcQtjBIXCAb ddrDyoGQZTBDnEPlOsOcQtjBIXCAb2;
						if (YUfGUyEFJFpnGMgqaTPYlqThsdaCA == -2 && EdGHPNiiBZZXAQqqQLPBNYgIwsaf == Environment.CurrentManagedThreadId)
						{
							YUfGUyEFJFpnGMgqaTPYlqThsdaCA = 0;
							ddrDyoGQZTBDnEPlOsOcQtjBIXCAb2 = this;
						}
						else
						{
							ddrDyoGQZTBDnEPlOsOcQtjBIXCAb2 = new ddrDyoGQZTBDnEPlOsOcQtjBIXCAb(0);
							ddrDyoGQZTBDnEPlOsOcQtjBIXCAb2.FymidxZJdhZGcaxjjMyfifzDbhgBA = FymidxZJdhZGcaxjjMyfifzDbhgBA;
						}
						return ddrDyoGQZTBDnEPlOsOcQtjBIXCAb2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ZlYFxvzSMSWeSdfSVchhIfPYNchxA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int TtyRDGCogdrPDsqBJWpVIRACdZaP;

					private ControllerPollingInfo UGQGyCDPMaiMbRbbVyYWeWloWNyqA;

					private int BxCdTmCSRdxVgBjoFaGjzhNCDmMW;

					public PollingHelper INGSfgxcbrEKfFwdMXjykqoSBfXfA;

					private IEnumerator<ControllerPollingInfo> tLSKUhLouqSymYPXFjoVjskutZOi;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return UGQGyCDPMaiMbRbbVyYWeWloWNyqA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return UGQGyCDPMaiMbRbbVyYWeWloWNyqA;
						}
					}

					[DebuggerHidden]
					public ZlYFxvzSMSWeSdfSVchhIfPYNchxA(int P_0)
					{
						TtyRDGCogdrPDsqBJWpVIRACdZaP = P_0;
						BxCdTmCSRdxVgBjoFaGjzhNCDmMW = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (TtyRDGCogdrPDsqBJWpVIRACdZaP)
						{
						case -3:
						case 1:
							try
							{
							}
							finally
							{
								iKmgrLksDmZqaupeaGPsMbYHWvPR();
							}
							break;
						case -4:
						case 2:
							try
							{
							}
							finally
							{
								SwxePoBiquaTGXIAhpJYCuOancqP();
							}
							break;
						case -5:
						case 3:
							try
							{
							}
							finally
							{
								TlIafHEkyjdnmWFruWkfeydvMxnd();
							}
							break;
						case -6:
						case 4:
							try
							{
							}
							finally
							{
								PQjkfZxbPztSSaGgXkBKeGrQCjvKA();
							}
							break;
						}
						tLSKUhLouqSymYPXFjoVjskutZOi = null;
						TtyRDGCogdrPDsqBJWpVIRACdZaP = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int ttyRDGCogdrPDsqBJWpVIRACdZaP = TtyRDGCogdrPDsqBJWpVIRACdZaP;
							PollingHelper iNGSfgxcbrEKfFwdMXjykqoSBfXfA = INGSfgxcbrEKfFwdMXjykqoSBfXfA;
							switch (ttyRDGCogdrPDsqBJWpVIRACdZaP)
							{
							default:
								return false;
							case 0:
								TtyRDGCogdrPDsqBJWpVIRACdZaP = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								tLSKUhLouqSymYPXFjoVjskutZOi = iNGSfgxcbrEKfFwdMXjykqoSBfXfA.VyTeiPwKWXisLVQVZWdvGZWIaqME().GetEnumerator();
								TtyRDGCogdrPDsqBJWpVIRACdZaP = -3;
								goto IL_0088;
							case 1:
								TtyRDGCogdrPDsqBJWpVIRACdZaP = -3;
								goto IL_0088;
							case 2:
								TtyRDGCogdrPDsqBJWpVIRACdZaP = -4;
								goto IL_00e8;
							case 3:
								TtyRDGCogdrPDsqBJWpVIRACdZaP = -5;
								goto IL_0148;
							case 4:
								{
									TtyRDGCogdrPDsqBJWpVIRACdZaP = -6;
									break;
								}
								IL_00e8:
								if (tLSKUhLouqSymYPXFjoVjskutZOi.MoveNext())
								{
									ControllerPollingInfo current = tLSKUhLouqSymYPXFjoVjskutZOi.Current;
									UGQGyCDPMaiMbRbbVyYWeWloWNyqA = current;
									TtyRDGCogdrPDsqBJWpVIRACdZaP = 2;
									return true;
								}
								SwxePoBiquaTGXIAhpJYCuOancqP();
								tLSKUhLouqSymYPXFjoVjskutZOi = null;
								tLSKUhLouqSymYPXFjoVjskutZOi = iNGSfgxcbrEKfFwdMXjykqoSBfXfA.IBmpVfvlUyAIvbkosTrDyeeLjCkU().GetEnumerator();
								TtyRDGCogdrPDsqBJWpVIRACdZaP = -5;
								goto IL_0148;
								IL_0088:
								if (tLSKUhLouqSymYPXFjoVjskutZOi.MoveNext())
								{
									ControllerPollingInfo current2 = tLSKUhLouqSymYPXFjoVjskutZOi.Current;
									UGQGyCDPMaiMbRbbVyYWeWloWNyqA = current2;
									TtyRDGCogdrPDsqBJWpVIRACdZaP = 1;
									return true;
								}
								iKmgrLksDmZqaupeaGPsMbYHWvPR();
								tLSKUhLouqSymYPXFjoVjskutZOi = null;
								tLSKUhLouqSymYPXFjoVjskutZOi = iNGSfgxcbrEKfFwdMXjykqoSBfXfA.sjsENOKkaaCwGaTVCsqaGVdCnuGEE().GetEnumerator();
								TtyRDGCogdrPDsqBJWpVIRACdZaP = -4;
								goto IL_00e8;
								IL_0148:
								if (tLSKUhLouqSymYPXFjoVjskutZOi.MoveNext())
								{
									ControllerPollingInfo current3 = tLSKUhLouqSymYPXFjoVjskutZOi.Current;
									UGQGyCDPMaiMbRbbVyYWeWloWNyqA = current3;
									TtyRDGCogdrPDsqBJWpVIRACdZaP = 3;
									return true;
								}
								TlIafHEkyjdnmWFruWkfeydvMxnd();
								tLSKUhLouqSymYPXFjoVjskutZOi = null;
								tLSKUhLouqSymYPXFjoVjskutZOi = iNGSfgxcbrEKfFwdMXjykqoSBfXfA.DFkYkfuETRGRTfKskUkCAOFJOBApA().GetEnumerator();
								TtyRDGCogdrPDsqBJWpVIRACdZaP = -6;
								break;
							}
							if (tLSKUhLouqSymYPXFjoVjskutZOi.MoveNext())
							{
								ControllerPollingInfo current4 = tLSKUhLouqSymYPXFjoVjskutZOi.Current;
								UGQGyCDPMaiMbRbbVyYWeWloWNyqA = current4;
								TtyRDGCogdrPDsqBJWpVIRACdZaP = 4;
								return true;
							}
							PQjkfZxbPztSSaGgXkBKeGrQCjvKA();
							tLSKUhLouqSymYPXFjoVjskutZOi = null;
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void iKmgrLksDmZqaupeaGPsMbYHWvPR()
					{
						TtyRDGCogdrPDsqBJWpVIRACdZaP = -1;
						if (tLSKUhLouqSymYPXFjoVjskutZOi != null)
						{
							tLSKUhLouqSymYPXFjoVjskutZOi.Dispose();
						}
					}

					private void SwxePoBiquaTGXIAhpJYCuOancqP()
					{
						TtyRDGCogdrPDsqBJWpVIRACdZaP = -1;
						if (tLSKUhLouqSymYPXFjoVjskutZOi != null)
						{
							tLSKUhLouqSymYPXFjoVjskutZOi.Dispose();
						}
					}

					private void TlIafHEkyjdnmWFruWkfeydvMxnd()
					{
						TtyRDGCogdrPDsqBJWpVIRACdZaP = -1;
						if (tLSKUhLouqSymYPXFjoVjskutZOi != null)
						{
							tLSKUhLouqSymYPXFjoVjskutZOi.Dispose();
						}
					}

					private void PQjkfZxbPztSSaGgXkBKeGrQCjvKA()
					{
						TtyRDGCogdrPDsqBJWpVIRACdZaP = -1;
						if (tLSKUhLouqSymYPXFjoVjskutZOi != null)
						{
							tLSKUhLouqSymYPXFjoVjskutZOi.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						ZlYFxvzSMSWeSdfSVchhIfPYNchxA zlYFxvzSMSWeSdfSVchhIfPYNchxA;
						if (TtyRDGCogdrPDsqBJWpVIRACdZaP == -2 && BxCdTmCSRdxVgBjoFaGjzhNCDmMW == Environment.CurrentManagedThreadId)
						{
							TtyRDGCogdrPDsqBJWpVIRACdZaP = 0;
							zlYFxvzSMSWeSdfSVchhIfPYNchxA = this;
						}
						else
						{
							zlYFxvzSMSWeSdfSVchhIfPYNchxA = new ZlYFxvzSMSWeSdfSVchhIfPYNchxA(0);
							zlYFxvzSMSWeSdfSVchhIfPYNchxA.INGSfgxcbrEKfFwdMXjykqoSBfXfA = INGSfgxcbrEKfFwdMXjykqoSBfXfA;
						}
						return zlYFxvzSMSWeSdfSVchhIfPYNchxA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class LxnJHdhDuZnXHoCiPIQkHLKJguesA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int BSnjGCJmzMwZBUIBPiduZoZSMXfI;

					private ControllerPollingInfo ShkxIqcPmKHtPFuOsjtlehREEurN;

					private int QDZVWItqnkuXZuCOPGNhmXLSEeHo;

					public PollingHelper mefnLrwghhkLDCfIldMzuRLhLkbU;

					private IEnumerator<ControllerPollingInfo> iwMcRdAIjVlciRmqLNDaEZIfEVJaB;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ShkxIqcPmKHtPFuOsjtlehREEurN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ShkxIqcPmKHtPFuOsjtlehREEurN;
						}
					}

					[DebuggerHidden]
					public LxnJHdhDuZnXHoCiPIQkHLKJguesA(int P_0)
					{
						BSnjGCJmzMwZBUIBPiduZoZSMXfI = P_0;
						QDZVWItqnkuXZuCOPGNhmXLSEeHo = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (BSnjGCJmzMwZBUIBPiduZoZSMXfI)
						{
						case -3:
						case 1:
							try
							{
							}
							finally
							{
								AsutndzQDeYyOuugbTWcCdpEVQcQ();
							}
							break;
						case -4:
						case 2:
							try
							{
							}
							finally
							{
								paAPHORnwEAefftfoOKqnAYabzEF();
							}
							break;
						case -5:
						case 3:
							try
							{
							}
							finally
							{
								fynBZKVvCfioVcLsqoAjPokEecyjA();
							}
							break;
						case -6:
						case 4:
							try
							{
							}
							finally
							{
								rsIFQvNAiSUlxnXiiubXIdVNisrg();
							}
							break;
						}
						iwMcRdAIjVlciRmqLNDaEZIfEVJaB = null;
						BSnjGCJmzMwZBUIBPiduZoZSMXfI = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int bSnjGCJmzMwZBUIBPiduZoZSMXfI = BSnjGCJmzMwZBUIBPiduZoZSMXfI;
							PollingHelper pollingHelper = mefnLrwghhkLDCfIldMzuRLhLkbU;
							switch (bSnjGCJmzMwZBUIBPiduZoZSMXfI)
							{
							default:
								return false;
							case 0:
								BSnjGCJmzMwZBUIBPiduZoZSMXfI = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								iwMcRdAIjVlciRmqLNDaEZIfEVJaB = pollingHelper.QsdXgtigUKxmjHJHIVPPniTGWrZv().GetEnumerator();
								BSnjGCJmzMwZBUIBPiduZoZSMXfI = -3;
								goto IL_0088;
							case 1:
								BSnjGCJmzMwZBUIBPiduZoZSMXfI = -3;
								goto IL_0088;
							case 2:
								BSnjGCJmzMwZBUIBPiduZoZSMXfI = -4;
								goto IL_00e8;
							case 3:
								BSnjGCJmzMwZBUIBPiduZoZSMXfI = -5;
								goto IL_0148;
							case 4:
								{
									BSnjGCJmzMwZBUIBPiduZoZSMXfI = -6;
									break;
								}
								IL_00e8:
								if (iwMcRdAIjVlciRmqLNDaEZIfEVJaB.MoveNext())
								{
									ControllerPollingInfo current = iwMcRdAIjVlciRmqLNDaEZIfEVJaB.Current;
									ShkxIqcPmKHtPFuOsjtlehREEurN = current;
									BSnjGCJmzMwZBUIBPiduZoZSMXfI = 2;
									return true;
								}
								paAPHORnwEAefftfoOKqnAYabzEF();
								iwMcRdAIjVlciRmqLNDaEZIfEVJaB = null;
								iwMcRdAIjVlciRmqLNDaEZIfEVJaB = pollingHelper.atfmcMmvjzEKihsNqEgdhPXBQGdV().GetEnumerator();
								BSnjGCJmzMwZBUIBPiduZoZSMXfI = -5;
								goto IL_0148;
								IL_0088:
								if (iwMcRdAIjVlciRmqLNDaEZIfEVJaB.MoveNext())
								{
									ControllerPollingInfo current2 = iwMcRdAIjVlciRmqLNDaEZIfEVJaB.Current;
									ShkxIqcPmKHtPFuOsjtlehREEurN = current2;
									BSnjGCJmzMwZBUIBPiduZoZSMXfI = 1;
									return true;
								}
								AsutndzQDeYyOuugbTWcCdpEVQcQ();
								iwMcRdAIjVlciRmqLNDaEZIfEVJaB = null;
								iwMcRdAIjVlciRmqLNDaEZIfEVJaB = pollingHelper.NNJUSIqUVoMSpNghqiIOavdDjkzB().GetEnumerator();
								BSnjGCJmzMwZBUIBPiduZoZSMXfI = -4;
								goto IL_00e8;
								IL_0148:
								if (iwMcRdAIjVlciRmqLNDaEZIfEVJaB.MoveNext())
								{
									ControllerPollingInfo current3 = iwMcRdAIjVlciRmqLNDaEZIfEVJaB.Current;
									ShkxIqcPmKHtPFuOsjtlehREEurN = current3;
									BSnjGCJmzMwZBUIBPiduZoZSMXfI = 3;
									return true;
								}
								fynBZKVvCfioVcLsqoAjPokEecyjA();
								iwMcRdAIjVlciRmqLNDaEZIfEVJaB = null;
								iwMcRdAIjVlciRmqLNDaEZIfEVJaB = pollingHelper.XCGCHiKtCdZekWgLQkUhaLndiVJTB().GetEnumerator();
								BSnjGCJmzMwZBUIBPiduZoZSMXfI = -6;
								break;
							}
							if (iwMcRdAIjVlciRmqLNDaEZIfEVJaB.MoveNext())
							{
								ControllerPollingInfo current4 = iwMcRdAIjVlciRmqLNDaEZIfEVJaB.Current;
								ShkxIqcPmKHtPFuOsjtlehREEurN = current4;
								BSnjGCJmzMwZBUIBPiduZoZSMXfI = 4;
								return true;
							}
							rsIFQvNAiSUlxnXiiubXIdVNisrg();
							iwMcRdAIjVlciRmqLNDaEZIfEVJaB = null;
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void AsutndzQDeYyOuugbTWcCdpEVQcQ()
					{
						BSnjGCJmzMwZBUIBPiduZoZSMXfI = -1;
						if (iwMcRdAIjVlciRmqLNDaEZIfEVJaB != null)
						{
							iwMcRdAIjVlciRmqLNDaEZIfEVJaB.Dispose();
						}
					}

					private void paAPHORnwEAefftfoOKqnAYabzEF()
					{
						BSnjGCJmzMwZBUIBPiduZoZSMXfI = -1;
						if (iwMcRdAIjVlciRmqLNDaEZIfEVJaB != null)
						{
							iwMcRdAIjVlciRmqLNDaEZIfEVJaB.Dispose();
						}
					}

					private void fynBZKVvCfioVcLsqoAjPokEecyjA()
					{
						BSnjGCJmzMwZBUIBPiduZoZSMXfI = -1;
						if (iwMcRdAIjVlciRmqLNDaEZIfEVJaB != null)
						{
							iwMcRdAIjVlciRmqLNDaEZIfEVJaB.Dispose();
						}
					}

					private void rsIFQvNAiSUlxnXiiubXIdVNisrg()
					{
						BSnjGCJmzMwZBUIBPiduZoZSMXfI = -1;
						if (iwMcRdAIjVlciRmqLNDaEZIfEVJaB != null)
						{
							iwMcRdAIjVlciRmqLNDaEZIfEVJaB.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						LxnJHdhDuZnXHoCiPIQkHLKJguesA lxnJHdhDuZnXHoCiPIQkHLKJguesA;
						if (BSnjGCJmzMwZBUIBPiduZoZSMXfI == -2 && QDZVWItqnkuXZuCOPGNhmXLSEeHo == Environment.CurrentManagedThreadId)
						{
							BSnjGCJmzMwZBUIBPiduZoZSMXfI = 0;
							lxnJHdhDuZnXHoCiPIQkHLKJguesA = this;
						}
						else
						{
							lxnJHdhDuZnXHoCiPIQkHLKJguesA = new LxnJHdhDuZnXHoCiPIQkHLKJguesA(0);
							lxnJHdhDuZnXHoCiPIQkHLKJguesA.mefnLrwghhkLDCfIldMzuRLhLkbU = mefnLrwghhkLDCfIldMzuRLhLkbU;
						}
						return lxnJHdhDuZnXHoCiPIQkHLKJguesA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class SeSPNqzNCXDUFBWYFoRVNCZhYpr : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int IRYCWUbHnKxAHxUgtVqcFKWyPJKOA;

					private ControllerPollingInfo ryXqoxBjUsaIrppOiwduOyyhQikO;

					private int PSvlDQWbxOkFpUNQJKmqzrwbeMav;

					public PollingHelper MvfQZmafMIVenXPloFrjsXiDgBEBA;

					private IEnumerator<ControllerPollingInfo> ecjRBYOfFQkuTgJiPYzwBbWfEeRw;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ryXqoxBjUsaIrppOiwduOyyhQikO;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ryXqoxBjUsaIrppOiwduOyyhQikO;
						}
					}

					[DebuggerHidden]
					public SeSPNqzNCXDUFBWYFoRVNCZhYpr(int P_0)
					{
						IRYCWUbHnKxAHxUgtVqcFKWyPJKOA = P_0;
						PSvlDQWbxOkFpUNQJKmqzrwbeMav = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (IRYCWUbHnKxAHxUgtVqcFKWyPJKOA)
						{
						case -3:
						case 1:
							try
							{
							}
							finally
							{
								KYriNCFGmAkESMJGgBpwGoVrMqYS();
							}
							break;
						case -4:
						case 2:
							try
							{
							}
							finally
							{
								TXxEzVbcREGtYQFdwDBBycQboAjUA();
							}
							break;
						case -5:
						case 3:
							try
							{
							}
							finally
							{
								KUPfjdFJzqBxCdPSjjGNPDqqAnJHc();
							}
							break;
						case -6:
						case 4:
							try
							{
							}
							finally
							{
								shbIdFaRsjdNuqsspIxpseamdtBE();
							}
							break;
						}
						ecjRBYOfFQkuTgJiPYzwBbWfEeRw = null;
						IRYCWUbHnKxAHxUgtVqcFKWyPJKOA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int iRYCWUbHnKxAHxUgtVqcFKWyPJKOA = IRYCWUbHnKxAHxUgtVqcFKWyPJKOA;
							PollingHelper mvfQZmafMIVenXPloFrjsXiDgBEBA = MvfQZmafMIVenXPloFrjsXiDgBEBA;
							switch (iRYCWUbHnKxAHxUgtVqcFKWyPJKOA)
							{
							default:
								return false;
							case 0:
								IRYCWUbHnKxAHxUgtVqcFKWyPJKOA = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								ecjRBYOfFQkuTgJiPYzwBbWfEeRw = mvfQZmafMIVenXPloFrjsXiDgBEBA.MHstpPwvTXAJncHPklBRdIaJPEns().GetEnumerator();
								IRYCWUbHnKxAHxUgtVqcFKWyPJKOA = -3;
								goto IL_0088;
							case 1:
								IRYCWUbHnKxAHxUgtVqcFKWyPJKOA = -3;
								goto IL_0088;
							case 2:
								IRYCWUbHnKxAHxUgtVqcFKWyPJKOA = -4;
								goto IL_00e8;
							case 3:
								IRYCWUbHnKxAHxUgtVqcFKWyPJKOA = -5;
								goto IL_0148;
							case 4:
								{
									IRYCWUbHnKxAHxUgtVqcFKWyPJKOA = -6;
									break;
								}
								IL_00e8:
								if (ecjRBYOfFQkuTgJiPYzwBbWfEeRw.MoveNext())
								{
									ControllerPollingInfo current = ecjRBYOfFQkuTgJiPYzwBbWfEeRw.Current;
									ryXqoxBjUsaIrppOiwduOyyhQikO = current;
									IRYCWUbHnKxAHxUgtVqcFKWyPJKOA = 2;
									return true;
								}
								TXxEzVbcREGtYQFdwDBBycQboAjUA();
								ecjRBYOfFQkuTgJiPYzwBbWfEeRw = null;
								ecjRBYOfFQkuTgJiPYzwBbWfEeRw = mvfQZmafMIVenXPloFrjsXiDgBEBA.imsVAvIeJiONJwriAYgFfsLKdIud().GetEnumerator();
								IRYCWUbHnKxAHxUgtVqcFKWyPJKOA = -5;
								goto IL_0148;
								IL_0088:
								if (ecjRBYOfFQkuTgJiPYzwBbWfEeRw.MoveNext())
								{
									ControllerPollingInfo current2 = ecjRBYOfFQkuTgJiPYzwBbWfEeRw.Current;
									ryXqoxBjUsaIrppOiwduOyyhQikO = current2;
									IRYCWUbHnKxAHxUgtVqcFKWyPJKOA = 1;
									return true;
								}
								KYriNCFGmAkESMJGgBpwGoVrMqYS();
								ecjRBYOfFQkuTgJiPYzwBbWfEeRw = null;
								ecjRBYOfFQkuTgJiPYzwBbWfEeRw = mvfQZmafMIVenXPloFrjsXiDgBEBA.sjsENOKkaaCwGaTVCsqaGVdCnuGEE().GetEnumerator();
								IRYCWUbHnKxAHxUgtVqcFKWyPJKOA = -4;
								goto IL_00e8;
								IL_0148:
								if (ecjRBYOfFQkuTgJiPYzwBbWfEeRw.MoveNext())
								{
									ControllerPollingInfo current3 = ecjRBYOfFQkuTgJiPYzwBbWfEeRw.Current;
									ryXqoxBjUsaIrppOiwduOyyhQikO = current3;
									IRYCWUbHnKxAHxUgtVqcFKWyPJKOA = 3;
									return true;
								}
								KUPfjdFJzqBxCdPSjjGNPDqqAnJHc();
								ecjRBYOfFQkuTgJiPYzwBbWfEeRw = null;
								ecjRBYOfFQkuTgJiPYzwBbWfEeRw = mvfQZmafMIVenXPloFrjsXiDgBEBA.gvMFHvaqOpTvXnyEBKquBopXUBsF().GetEnumerator();
								IRYCWUbHnKxAHxUgtVqcFKWyPJKOA = -6;
								break;
							}
							if (ecjRBYOfFQkuTgJiPYzwBbWfEeRw.MoveNext())
							{
								ControllerPollingInfo current4 = ecjRBYOfFQkuTgJiPYzwBbWfEeRw.Current;
								ryXqoxBjUsaIrppOiwduOyyhQikO = current4;
								IRYCWUbHnKxAHxUgtVqcFKWyPJKOA = 4;
								return true;
							}
							shbIdFaRsjdNuqsspIxpseamdtBE();
							ecjRBYOfFQkuTgJiPYzwBbWfEeRw = null;
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void KYriNCFGmAkESMJGgBpwGoVrMqYS()
					{
						IRYCWUbHnKxAHxUgtVqcFKWyPJKOA = -1;
						if (ecjRBYOfFQkuTgJiPYzwBbWfEeRw != null)
						{
							ecjRBYOfFQkuTgJiPYzwBbWfEeRw.Dispose();
						}
					}

					private void TXxEzVbcREGtYQFdwDBBycQboAjUA()
					{
						IRYCWUbHnKxAHxUgtVqcFKWyPJKOA = -1;
						if (ecjRBYOfFQkuTgJiPYzwBbWfEeRw != null)
						{
							ecjRBYOfFQkuTgJiPYzwBbWfEeRw.Dispose();
						}
					}

					private void KUPfjdFJzqBxCdPSjjGNPDqqAnJHc()
					{
						IRYCWUbHnKxAHxUgtVqcFKWyPJKOA = -1;
						if (ecjRBYOfFQkuTgJiPYzwBbWfEeRw != null)
						{
							ecjRBYOfFQkuTgJiPYzwBbWfEeRw.Dispose();
						}
					}

					private void shbIdFaRsjdNuqsspIxpseamdtBE()
					{
						IRYCWUbHnKxAHxUgtVqcFKWyPJKOA = -1;
						if (ecjRBYOfFQkuTgJiPYzwBbWfEeRw != null)
						{
							ecjRBYOfFQkuTgJiPYzwBbWfEeRw.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						SeSPNqzNCXDUFBWYFoRVNCZhYpr seSPNqzNCXDUFBWYFoRVNCZhYpr;
						if (IRYCWUbHnKxAHxUgtVqcFKWyPJKOA == -2 && PSvlDQWbxOkFpUNQJKmqzrwbeMav == Environment.CurrentManagedThreadId)
						{
							IRYCWUbHnKxAHxUgtVqcFKWyPJKOA = 0;
							seSPNqzNCXDUFBWYFoRVNCZhYpr = this;
						}
						else
						{
							seSPNqzNCXDUFBWYFoRVNCZhYpr = new SeSPNqzNCXDUFBWYFoRVNCZhYpr(0);
							seSPNqzNCXDUFBWYFoRVNCZhYpr.MvfQZmafMIVenXPloFrjsXiDgBEBA = MvfQZmafMIVenXPloFrjsXiDgBEBA;
						}
						return seSPNqzNCXDUFBWYFoRVNCZhYpr;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class yBzhqZGaIpvnznxgkwMJmRFJeGmHA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int bLszBRNLvAhdWGvQhlLDXxQmnnAx;

					private ControllerPollingInfo dEJsthiMLaYVivUmMgiweqLxGUYR;

					private int HVzaiXCODFSRjMRwHRaOagVrRoVw;

					public PollingHelper vPGJfPZtmPGJoohusNSWpoKsACRHA;

					private IEnumerator<ControllerPollingInfo> YlAIUPocgWmFZBhtrGVCZBmkAEgP;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return dEJsthiMLaYVivUmMgiweqLxGUYR;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return dEJsthiMLaYVivUmMgiweqLxGUYR;
						}
					}

					[DebuggerHidden]
					public yBzhqZGaIpvnznxgkwMJmRFJeGmHA(int P_0)
					{
						bLszBRNLvAhdWGvQhlLDXxQmnnAx = P_0;
						HVzaiXCODFSRjMRwHRaOagVrRoVw = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (bLszBRNLvAhdWGvQhlLDXxQmnnAx)
						{
						case -3:
						case 1:
							try
							{
							}
							finally
							{
								ksmcllnUPSCnfPQBRUQAjqQAsNGf();
							}
							break;
						case -4:
						case 2:
							try
							{
							}
							finally
							{
								zHaObXOVbjiDgTIriDzMgxTeXYEJ();
							}
							break;
						case -5:
						case 3:
							try
							{
							}
							finally
							{
								cQxWEcxbizaqUuGVqblTDRFIyyCqA();
							}
							break;
						case -6:
						case 4:
							try
							{
							}
							finally
							{
								nrAfcLSiagAACTWftjhxqHUMFIjfA();
							}
							break;
						}
						YlAIUPocgWmFZBhtrGVCZBmkAEgP = null;
						bLszBRNLvAhdWGvQhlLDXxQmnnAx = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = bLszBRNLvAhdWGvQhlLDXxQmnnAx;
							PollingHelper pollingHelper = vPGJfPZtmPGJoohusNSWpoKsACRHA;
							switch (num)
							{
							default:
								return false;
							case 0:
								bLszBRNLvAhdWGvQhlLDXxQmnnAx = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								YlAIUPocgWmFZBhtrGVCZBmkAEgP = pollingHelper.QOKUwKRwlfocuacmVzojCoBkfhMKA().GetEnumerator();
								bLszBRNLvAhdWGvQhlLDXxQmnnAx = -3;
								goto IL_0088;
							case 1:
								bLszBRNLvAhdWGvQhlLDXxQmnnAx = -3;
								goto IL_0088;
							case 2:
								bLszBRNLvAhdWGvQhlLDXxQmnnAx = -4;
								goto IL_00e8;
							case 3:
								bLszBRNLvAhdWGvQhlLDXxQmnnAx = -5;
								goto IL_0148;
							case 4:
								{
									bLszBRNLvAhdWGvQhlLDXxQmnnAx = -6;
									break;
								}
								IL_00e8:
								if (YlAIUPocgWmFZBhtrGVCZBmkAEgP.MoveNext())
								{
									ControllerPollingInfo current = YlAIUPocgWmFZBhtrGVCZBmkAEgP.Current;
									dEJsthiMLaYVivUmMgiweqLxGUYR = current;
									bLszBRNLvAhdWGvQhlLDXxQmnnAx = 2;
									return true;
								}
								zHaObXOVbjiDgTIriDzMgxTeXYEJ();
								YlAIUPocgWmFZBhtrGVCZBmkAEgP = null;
								YlAIUPocgWmFZBhtrGVCZBmkAEgP = pollingHelper.kCkYjmovYSNkgizFvvYoDUhXhZLV().GetEnumerator();
								bLszBRNLvAhdWGvQhlLDXxQmnnAx = -5;
								goto IL_0148;
								IL_0088:
								if (YlAIUPocgWmFZBhtrGVCZBmkAEgP.MoveNext())
								{
									ControllerPollingInfo current2 = YlAIUPocgWmFZBhtrGVCZBmkAEgP.Current;
									dEJsthiMLaYVivUmMgiweqLxGUYR = current2;
									bLszBRNLvAhdWGvQhlLDXxQmnnAx = 1;
									return true;
								}
								ksmcllnUPSCnfPQBRUQAjqQAsNGf();
								YlAIUPocgWmFZBhtrGVCZBmkAEgP = null;
								YlAIUPocgWmFZBhtrGVCZBmkAEgP = pollingHelper.NNJUSIqUVoMSpNghqiIOavdDjkzB().GetEnumerator();
								bLszBRNLvAhdWGvQhlLDXxQmnnAx = -4;
								goto IL_00e8;
								IL_0148:
								if (YlAIUPocgWmFZBhtrGVCZBmkAEgP.MoveNext())
								{
									ControllerPollingInfo current3 = YlAIUPocgWmFZBhtrGVCZBmkAEgP.Current;
									dEJsthiMLaYVivUmMgiweqLxGUYR = current3;
									bLszBRNLvAhdWGvQhlLDXxQmnnAx = 3;
									return true;
								}
								cQxWEcxbizaqUuGVqblTDRFIyyCqA();
								YlAIUPocgWmFZBhtrGVCZBmkAEgP = null;
								YlAIUPocgWmFZBhtrGVCZBmkAEgP = pollingHelper.iLPSFzAohkeBKBlYDfnZFwtRPSVN().GetEnumerator();
								bLszBRNLvAhdWGvQhlLDXxQmnnAx = -6;
								break;
							}
							if (YlAIUPocgWmFZBhtrGVCZBmkAEgP.MoveNext())
							{
								ControllerPollingInfo current4 = YlAIUPocgWmFZBhtrGVCZBmkAEgP.Current;
								dEJsthiMLaYVivUmMgiweqLxGUYR = current4;
								bLszBRNLvAhdWGvQhlLDXxQmnnAx = 4;
								return true;
							}
							nrAfcLSiagAACTWftjhxqHUMFIjfA();
							YlAIUPocgWmFZBhtrGVCZBmkAEgP = null;
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void ksmcllnUPSCnfPQBRUQAjqQAsNGf()
					{
						bLszBRNLvAhdWGvQhlLDXxQmnnAx = -1;
						if (YlAIUPocgWmFZBhtrGVCZBmkAEgP != null)
						{
							YlAIUPocgWmFZBhtrGVCZBmkAEgP.Dispose();
						}
					}

					private void zHaObXOVbjiDgTIriDzMgxTeXYEJ()
					{
						bLszBRNLvAhdWGvQhlLDXxQmnnAx = -1;
						if (YlAIUPocgWmFZBhtrGVCZBmkAEgP != null)
						{
							YlAIUPocgWmFZBhtrGVCZBmkAEgP.Dispose();
						}
					}

					private void cQxWEcxbizaqUuGVqblTDRFIyyCqA()
					{
						bLszBRNLvAhdWGvQhlLDXxQmnnAx = -1;
						if (YlAIUPocgWmFZBhtrGVCZBmkAEgP != null)
						{
							YlAIUPocgWmFZBhtrGVCZBmkAEgP.Dispose();
						}
					}

					private void nrAfcLSiagAACTWftjhxqHUMFIjfA()
					{
						bLszBRNLvAhdWGvQhlLDXxQmnnAx = -1;
						if (YlAIUPocgWmFZBhtrGVCZBmkAEgP != null)
						{
							YlAIUPocgWmFZBhtrGVCZBmkAEgP.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						yBzhqZGaIpvnznxgkwMJmRFJeGmHA yBzhqZGaIpvnznxgkwMJmRFJeGmHA2;
						if (bLszBRNLvAhdWGvQhlLDXxQmnnAx == -2 && HVzaiXCODFSRjMRwHRaOagVrRoVw == Environment.CurrentManagedThreadId)
						{
							bLszBRNLvAhdWGvQhlLDXxQmnnAx = 0;
							yBzhqZGaIpvnznxgkwMJmRFJeGmHA2 = this;
						}
						else
						{
							yBzhqZGaIpvnznxgkwMJmRFJeGmHA2 = new yBzhqZGaIpvnznxgkwMJmRFJeGmHA(0);
							yBzhqZGaIpvnznxgkwMJmRFJeGmHA2.vPGJfPZtmPGJoohusNSWpoKsACRHA = vPGJfPZtmPGJoohusNSWpoKsACRHA;
						}
						return yBzhqZGaIpvnznxgkwMJmRFJeGmHA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ixixnIWdJlWbibcjuDcatHsLtmPE : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int DLEThhTMIuQtKoXoouOUsfsSyANy;

					private ControllerPollingInfo bMmtNHRaduRQMAMWXgqOpxdNHcfjA;

					private int xFDAdbOkCCjRchFgrATQyTTpoehzA;

					private IList<CustomController> iOZdcGbUSTVAnXuZBdUmDIdqpVDlA;

					private int wKqaVmsoMDbZyhvwnNtmUlmZwOMw;

					private IEnumerator<ControllerPollingInfo> tFLiQffpUCQzrcTLdQVFmqLNNPAFA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return bMmtNHRaduRQMAMWXgqOpxdNHcfjA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return bMmtNHRaduRQMAMWXgqOpxdNHcfjA;
						}
					}

					[DebuggerHidden]
					public ixixnIWdJlWbibcjuDcatHsLtmPE(int P_0)
					{
						DLEThhTMIuQtKoXoouOUsfsSyANy = P_0;
						xFDAdbOkCCjRchFgrATQyTTpoehzA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int dLEThhTMIuQtKoXoouOUsfsSyANy = DLEThhTMIuQtKoXoouOUsfsSyANy;
						if (dLEThhTMIuQtKoXoouOUsfsSyANy == -3 || dLEThhTMIuQtKoXoouOUsfsSyANy == 1)
						{
							try
							{
							}
							finally
							{
								MdkzruMYwUCDLwlyCcCgOVrMpiQb();
							}
						}
						iOZdcGbUSTVAnXuZBdUmDIdqpVDlA = null;
						tFLiQffpUCQzrcTLdQVFmqLNNPAFA = null;
						DLEThhTMIuQtKoXoouOUsfsSyANy = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int dLEThhTMIuQtKoXoouOUsfsSyANy = DLEThhTMIuQtKoXoouOUsfsSyANy;
							if (dLEThhTMIuQtKoXoouOUsfsSyANy != 0)
							{
								if (dLEThhTMIuQtKoXoouOUsfsSyANy != 1)
								{
									return false;
								}
								DLEThhTMIuQtKoXoouOUsfsSyANy = -3;
								goto IL_0086;
							}
							DLEThhTMIuQtKoXoouOUsfsSyANy = -1;
							iOZdcGbUSTVAnXuZBdUmDIdqpVDlA = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.znuGFVHdakBIvysMReNIjKPHIQDfb;
							wKqaVmsoMDbZyhvwnNtmUlmZwOMw = 0;
							goto IL_00b0;
							IL_0086:
							if (tFLiQffpUCQzrcTLdQVFmqLNNPAFA.MoveNext())
							{
								ControllerPollingInfo current = tFLiQffpUCQzrcTLdQVFmqLNNPAFA.Current;
								bMmtNHRaduRQMAMWXgqOpxdNHcfjA = current;
								DLEThhTMIuQtKoXoouOUsfsSyANy = 1;
								return true;
							}
							MdkzruMYwUCDLwlyCcCgOVrMpiQb();
							tFLiQffpUCQzrcTLdQVFmqLNNPAFA = null;
							wKqaVmsoMDbZyhvwnNtmUlmZwOMw++;
							goto IL_00b0;
							IL_00b0:
							if (wKqaVmsoMDbZyhvwnNtmUlmZwOMw < iOZdcGbUSTVAnXuZBdUmDIdqpVDlA.Count)
							{
								tFLiQffpUCQzrcTLdQVFmqLNNPAFA = iOZdcGbUSTVAnXuZBdUmDIdqpVDlA[wKqaVmsoMDbZyhvwnNtmUlmZwOMw].PollForAllAxes().GetEnumerator();
								DLEThhTMIuQtKoXoouOUsfsSyANy = -3;
								goto IL_0086;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void MdkzruMYwUCDLwlyCcCgOVrMpiQb()
					{
						DLEThhTMIuQtKoXoouOUsfsSyANy = -1;
						if (tFLiQffpUCQzrcTLdQVFmqLNNPAFA != null)
						{
							tFLiQffpUCQzrcTLdQVFmqLNNPAFA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (DLEThhTMIuQtKoXoouOUsfsSyANy == -2 && xFDAdbOkCCjRchFgrATQyTTpoehzA == Environment.CurrentManagedThreadId)
						{
							DLEThhTMIuQtKoXoouOUsfsSyANy = 0;
							return this;
						}
						return new ixixnIWdJlWbibcjuDcatHsLtmPE(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class QYhfpqYQTGqttSUXAfnJWPVhPGUf : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int EKUmyyMXZUJakFIuAdCwbCRgQlmvA;

					private ControllerPollingInfo TsNFfiHuqsgkwHfiYiaPEeeFXWHgB;

					private int YWAsmjsuApKsVEieoqoQztoikPNS;

					private IList<CustomController> TiKYUvzewBejoATKfrBDlmgwHevfA;

					private int zUjazBdVpICNgBDqZayDbPshdgwQA;

					private IEnumerator<ControllerPollingInfo> qmpJWOkBrSFlpzaQStsNCbWDjaJC;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return TsNFfiHuqsgkwHfiYiaPEeeFXWHgB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return TsNFfiHuqsgkwHfiYiaPEeeFXWHgB;
						}
					}

					[DebuggerHidden]
					public QYhfpqYQTGqttSUXAfnJWPVhPGUf(int P_0)
					{
						EKUmyyMXZUJakFIuAdCwbCRgQlmvA = P_0;
						YWAsmjsuApKsVEieoqoQztoikPNS = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int eKUmyyMXZUJakFIuAdCwbCRgQlmvA = EKUmyyMXZUJakFIuAdCwbCRgQlmvA;
						if (eKUmyyMXZUJakFIuAdCwbCRgQlmvA == -3 || eKUmyyMXZUJakFIuAdCwbCRgQlmvA == 1)
						{
							try
							{
							}
							finally
							{
								wVDopfPkPHWZIYNZRLNGSuBnRwtQ();
							}
						}
						TiKYUvzewBejoATKfrBDlmgwHevfA = null;
						qmpJWOkBrSFlpzaQStsNCbWDjaJC = null;
						EKUmyyMXZUJakFIuAdCwbCRgQlmvA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int eKUmyyMXZUJakFIuAdCwbCRgQlmvA = EKUmyyMXZUJakFIuAdCwbCRgQlmvA;
							if (eKUmyyMXZUJakFIuAdCwbCRgQlmvA != 0)
							{
								if (eKUmyyMXZUJakFIuAdCwbCRgQlmvA != 1)
								{
									return false;
								}
								EKUmyyMXZUJakFIuAdCwbCRgQlmvA = -3;
								goto IL_0086;
							}
							EKUmyyMXZUJakFIuAdCwbCRgQlmvA = -1;
							TiKYUvzewBejoATKfrBDlmgwHevfA = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.znuGFVHdakBIvysMReNIjKPHIQDfb;
							zUjazBdVpICNgBDqZayDbPshdgwQA = 0;
							goto IL_00b0;
							IL_0086:
							if (qmpJWOkBrSFlpzaQStsNCbWDjaJC.MoveNext())
							{
								ControllerPollingInfo current = qmpJWOkBrSFlpzaQStsNCbWDjaJC.Current;
								TsNFfiHuqsgkwHfiYiaPEeeFXWHgB = current;
								EKUmyyMXZUJakFIuAdCwbCRgQlmvA = 1;
								return true;
							}
							wVDopfPkPHWZIYNZRLNGSuBnRwtQ();
							qmpJWOkBrSFlpzaQStsNCbWDjaJC = null;
							zUjazBdVpICNgBDqZayDbPshdgwQA++;
							goto IL_00b0;
							IL_00b0:
							if (zUjazBdVpICNgBDqZayDbPshdgwQA < TiKYUvzewBejoATKfrBDlmgwHevfA.Count)
							{
								qmpJWOkBrSFlpzaQStsNCbWDjaJC = TiKYUvzewBejoATKfrBDlmgwHevfA[zUjazBdVpICNgBDqZayDbPshdgwQA].PollForAllButtons().GetEnumerator();
								EKUmyyMXZUJakFIuAdCwbCRgQlmvA = -3;
								goto IL_0086;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void wVDopfPkPHWZIYNZRLNGSuBnRwtQ()
					{
						EKUmyyMXZUJakFIuAdCwbCRgQlmvA = -1;
						if (qmpJWOkBrSFlpzaQStsNCbWDjaJC != null)
						{
							qmpJWOkBrSFlpzaQStsNCbWDjaJC.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (EKUmyyMXZUJakFIuAdCwbCRgQlmvA == -2 && YWAsmjsuApKsVEieoqoQztoikPNS == Environment.CurrentManagedThreadId)
						{
							EKUmyyMXZUJakFIuAdCwbCRgQlmvA = 0;
							return this;
						}
						return new QYhfpqYQTGqttSUXAfnJWPVhPGUf(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class HGYZbwicUlfunQGUYtVDazSryoUF : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int lVROthPgkvQYslUIgbVIhyTNJSYk;

					private ControllerPollingInfo ZfuduuERenhEktOZFONlGPSKJPoEA;

					private int vnSxEHHqirTihGjerNUrGrUBhuvs;

					private IList<CustomController> fkjaAeKlrCHQslJceTwQTHNwqPTIA;

					private int CFcDbCJnNllUBhVNfYGJIbzvnQoO;

					private IEnumerator<ControllerPollingInfo> XHWbxFVMZKsIppJcKrAiFyeprOXP;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ZfuduuERenhEktOZFONlGPSKJPoEA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ZfuduuERenhEktOZFONlGPSKJPoEA;
						}
					}

					[DebuggerHidden]
					public HGYZbwicUlfunQGUYtVDazSryoUF(int P_0)
					{
						lVROthPgkvQYslUIgbVIhyTNJSYk = P_0;
						vnSxEHHqirTihGjerNUrGrUBhuvs = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = lVROthPgkvQYslUIgbVIhyTNJSYk;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								BNSUVokuoBvetkXbEnItAJrIlXmE();
							}
						}
						fkjaAeKlrCHQslJceTwQTHNwqPTIA = null;
						XHWbxFVMZKsIppJcKrAiFyeprOXP = null;
						lVROthPgkvQYslUIgbVIhyTNJSYk = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = lVROthPgkvQYslUIgbVIhyTNJSYk;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								lVROthPgkvQYslUIgbVIhyTNJSYk = -3;
								goto IL_0086;
							}
							lVROthPgkvQYslUIgbVIhyTNJSYk = -1;
							fkjaAeKlrCHQslJceTwQTHNwqPTIA = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.znuGFVHdakBIvysMReNIjKPHIQDfb;
							CFcDbCJnNllUBhVNfYGJIbzvnQoO = 0;
							goto IL_00b0;
							IL_0086:
							if (XHWbxFVMZKsIppJcKrAiFyeprOXP.MoveNext())
							{
								ControllerPollingInfo current = XHWbxFVMZKsIppJcKrAiFyeprOXP.Current;
								ZfuduuERenhEktOZFONlGPSKJPoEA = current;
								lVROthPgkvQYslUIgbVIhyTNJSYk = 1;
								return true;
							}
							BNSUVokuoBvetkXbEnItAJrIlXmE();
							XHWbxFVMZKsIppJcKrAiFyeprOXP = null;
							CFcDbCJnNllUBhVNfYGJIbzvnQoO++;
							goto IL_00b0;
							IL_00b0:
							if (CFcDbCJnNllUBhVNfYGJIbzvnQoO < fkjaAeKlrCHQslJceTwQTHNwqPTIA.Count)
							{
								XHWbxFVMZKsIppJcKrAiFyeprOXP = fkjaAeKlrCHQslJceTwQTHNwqPTIA[CFcDbCJnNllUBhVNfYGJIbzvnQoO].PollForAllButtonsDown().GetEnumerator();
								lVROthPgkvQYslUIgbVIhyTNJSYk = -3;
								goto IL_0086;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void BNSUVokuoBvetkXbEnItAJrIlXmE()
					{
						lVROthPgkvQYslUIgbVIhyTNJSYk = -1;
						if (XHWbxFVMZKsIppJcKrAiFyeprOXP != null)
						{
							XHWbxFVMZKsIppJcKrAiFyeprOXP.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (lVROthPgkvQYslUIgbVIhyTNJSYk == -2 && vnSxEHHqirTihGjerNUrGrUBhuvs == Environment.CurrentManagedThreadId)
						{
							lVROthPgkvQYslUIgbVIhyTNJSYk = 0;
							return this;
						}
						return new HGYZbwicUlfunQGUYtVDazSryoUF(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class yFRhhlGeGCgmwozIHOhVFxhYwIgBA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int ouXLGwppKXtmTfnOivgfYjYltFms;

					private ControllerPollingInfo PMuCCPlnmCjlmhpFUoHdZfTSwqptA;

					private int NzrmVuGqdxgsMzXDgHkOgZibDsigb;

					private IList<CustomController> IaOITVjvCPEBeErKmxBcEwSITiei;

					private int zfqrvEefAXLxKAgFpiQrbtodStfw;

					private IEnumerator<ControllerPollingInfo> tQdcAPiqJFCzAGQzMdoElxqGShnOA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return PMuCCPlnmCjlmhpFUoHdZfTSwqptA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return PMuCCPlnmCjlmhpFUoHdZfTSwqptA;
						}
					}

					[DebuggerHidden]
					public yFRhhlGeGCgmwozIHOhVFxhYwIgBA(int P_0)
					{
						ouXLGwppKXtmTfnOivgfYjYltFms = P_0;
						NzrmVuGqdxgsMzXDgHkOgZibDsigb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = ouXLGwppKXtmTfnOivgfYjYltFms;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								hXqhmBfrZzQCEVlhfSVydLFOYQMc();
							}
						}
						IaOITVjvCPEBeErKmxBcEwSITiei = null;
						tQdcAPiqJFCzAGQzMdoElxqGShnOA = null;
						ouXLGwppKXtmTfnOivgfYjYltFms = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = ouXLGwppKXtmTfnOivgfYjYltFms;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								ouXLGwppKXtmTfnOivgfYjYltFms = -3;
								goto IL_0086;
							}
							ouXLGwppKXtmTfnOivgfYjYltFms = -1;
							IaOITVjvCPEBeErKmxBcEwSITiei = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.znuGFVHdakBIvysMReNIjKPHIQDfb;
							zfqrvEefAXLxKAgFpiQrbtodStfw = 0;
							goto IL_00b0;
							IL_0086:
							if (tQdcAPiqJFCzAGQzMdoElxqGShnOA.MoveNext())
							{
								ControllerPollingInfo current = tQdcAPiqJFCzAGQzMdoElxqGShnOA.Current;
								PMuCCPlnmCjlmhpFUoHdZfTSwqptA = current;
								ouXLGwppKXtmTfnOivgfYjYltFms = 1;
								return true;
							}
							hXqhmBfrZzQCEVlhfSVydLFOYQMc();
							tQdcAPiqJFCzAGQzMdoElxqGShnOA = null;
							zfqrvEefAXLxKAgFpiQrbtodStfw++;
							goto IL_00b0;
							IL_00b0:
							if (zfqrvEefAXLxKAgFpiQrbtodStfw < IaOITVjvCPEBeErKmxBcEwSITiei.Count)
							{
								tQdcAPiqJFCzAGQzMdoElxqGShnOA = IaOITVjvCPEBeErKmxBcEwSITiei[zfqrvEefAXLxKAgFpiQrbtodStfw].PollForAllElements().GetEnumerator();
								ouXLGwppKXtmTfnOivgfYjYltFms = -3;
								goto IL_0086;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void hXqhmBfrZzQCEVlhfSVydLFOYQMc()
					{
						ouXLGwppKXtmTfnOivgfYjYltFms = -1;
						if (tQdcAPiqJFCzAGQzMdoElxqGShnOA != null)
						{
							tQdcAPiqJFCzAGQzMdoElxqGShnOA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (ouXLGwppKXtmTfnOivgfYjYltFms == -2 && NzrmVuGqdxgsMzXDgHkOgZibDsigb == Environment.CurrentManagedThreadId)
						{
							ouXLGwppKXtmTfnOivgfYjYltFms = 0;
							return this;
						}
						return new yFRhhlGeGCgmwozIHOhVFxhYwIgBA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class YsZwMlbLHWzWNIMBXKxOyoumOduO : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int mOcekrUAFNmwIjiHEtobTbwTnIob;

					private ControllerPollingInfo PkTxqJroNSkVYNMgzfyipkHNtxHH;

					private int CIegtXSgeuUsFMZoYEdKQdraCsWp;

					private IList<CustomController> PuhDkZfKqMjgWBdyCbEQKkPcrPgWC;

					private int XPCFaXLTvhorDUpFNgEVwngSMVDE;

					private IEnumerator<ControllerPollingInfo> mLSeRJvtEKEyBUbJNJtfjxlcTShP;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return PkTxqJroNSkVYNMgzfyipkHNtxHH;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return PkTxqJroNSkVYNMgzfyipkHNtxHH;
						}
					}

					[DebuggerHidden]
					public YsZwMlbLHWzWNIMBXKxOyoumOduO(int P_0)
					{
						mOcekrUAFNmwIjiHEtobTbwTnIob = P_0;
						CIegtXSgeuUsFMZoYEdKQdraCsWp = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = mOcekrUAFNmwIjiHEtobTbwTnIob;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								knEcCZGoDDgLsgbPYkcpKapIKZABb();
							}
						}
						PuhDkZfKqMjgWBdyCbEQKkPcrPgWC = null;
						mLSeRJvtEKEyBUbJNJtfjxlcTShP = null;
						mOcekrUAFNmwIjiHEtobTbwTnIob = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = mOcekrUAFNmwIjiHEtobTbwTnIob;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								mOcekrUAFNmwIjiHEtobTbwTnIob = -3;
								goto IL_0086;
							}
							mOcekrUAFNmwIjiHEtobTbwTnIob = -1;
							PuhDkZfKqMjgWBdyCbEQKkPcrPgWC = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.znuGFVHdakBIvysMReNIjKPHIQDfb;
							XPCFaXLTvhorDUpFNgEVwngSMVDE = 0;
							goto IL_00b0;
							IL_0086:
							if (mLSeRJvtEKEyBUbJNJtfjxlcTShP.MoveNext())
							{
								ControllerPollingInfo current = mLSeRJvtEKEyBUbJNJtfjxlcTShP.Current;
								PkTxqJroNSkVYNMgzfyipkHNtxHH = current;
								mOcekrUAFNmwIjiHEtobTbwTnIob = 1;
								return true;
							}
							knEcCZGoDDgLsgbPYkcpKapIKZABb();
							mLSeRJvtEKEyBUbJNJtfjxlcTShP = null;
							XPCFaXLTvhorDUpFNgEVwngSMVDE++;
							goto IL_00b0;
							IL_00b0:
							if (XPCFaXLTvhorDUpFNgEVwngSMVDE < PuhDkZfKqMjgWBdyCbEQKkPcrPgWC.Count)
							{
								mLSeRJvtEKEyBUbJNJtfjxlcTShP = PuhDkZfKqMjgWBdyCbEQKkPcrPgWC[XPCFaXLTvhorDUpFNgEVwngSMVDE].PollForAllElementsDown().GetEnumerator();
								mOcekrUAFNmwIjiHEtobTbwTnIob = -3;
								goto IL_0086;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void knEcCZGoDDgLsgbPYkcpKapIKZABb()
					{
						mOcekrUAFNmwIjiHEtobTbwTnIob = -1;
						if (mLSeRJvtEKEyBUbJNJtfjxlcTShP != null)
						{
							mLSeRJvtEKEyBUbJNJtfjxlcTShP.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (mOcekrUAFNmwIjiHEtobTbwTnIob == -2 && CIegtXSgeuUsFMZoYEdKQdraCsWp == Environment.CurrentManagedThreadId)
						{
							mOcekrUAFNmwIjiHEtobTbwTnIob = 0;
							return this;
						}
						return new YsZwMlbLHWzWNIMBXKxOyoumOduO(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class GlPjALVszuQuejuJjTRkYKSFfocIA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int xCpDFXeQyYbcHbGrSjmSUVQvlzIqA;

					private ControllerPollingInfo irBtaTOGDyjjKMezMLGLfuDHvbkk;

					private int cudcKTcLrojNuLuVYlsMfNLiWSrH;

					private IList<Joystick> EaeOKQokodcxgwtbhUExGUOlLZPn;

					private int hsmTjDnLtbmdDXDfQHltAHqlFgdTA;

					private IEnumerator<ControllerPollingInfo> kcjLEPfXDVUcrigftDCfOuECVSqM;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return irBtaTOGDyjjKMezMLGLfuDHvbkk;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return irBtaTOGDyjjKMezMLGLfuDHvbkk;
						}
					}

					[DebuggerHidden]
					public GlPjALVszuQuejuJjTRkYKSFfocIA(int P_0)
					{
						xCpDFXeQyYbcHbGrSjmSUVQvlzIqA = P_0;
						cudcKTcLrojNuLuVYlsMfNLiWSrH = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = xCpDFXeQyYbcHbGrSjmSUVQvlzIqA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								pNikNmdfFhiDiEcVfehAPLBTHWpJA();
							}
						}
						EaeOKQokodcxgwtbhUExGUOlLZPn = null;
						kcjLEPfXDVUcrigftDCfOuECVSqM = null;
						xCpDFXeQyYbcHbGrSjmSUVQvlzIqA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = xCpDFXeQyYbcHbGrSjmSUVQvlzIqA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								xCpDFXeQyYbcHbGrSjmSUVQvlzIqA = -3;
								goto IL_0086;
							}
							xCpDFXeQyYbcHbGrSjmSUVQvlzIqA = -1;
							EaeOKQokodcxgwtbhUExGUOlLZPn = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.FmfxwfhlxDwfpqdOLrqFojAgTbO;
							hsmTjDnLtbmdDXDfQHltAHqlFgdTA = 0;
							goto IL_00b0;
							IL_0086:
							if (kcjLEPfXDVUcrigftDCfOuECVSqM.MoveNext())
							{
								ControllerPollingInfo current = kcjLEPfXDVUcrigftDCfOuECVSqM.Current;
								irBtaTOGDyjjKMezMLGLfuDHvbkk = current;
								xCpDFXeQyYbcHbGrSjmSUVQvlzIqA = 1;
								return true;
							}
							pNikNmdfFhiDiEcVfehAPLBTHWpJA();
							kcjLEPfXDVUcrigftDCfOuECVSqM = null;
							hsmTjDnLtbmdDXDfQHltAHqlFgdTA++;
							goto IL_00b0;
							IL_00b0:
							if (hsmTjDnLtbmdDXDfQHltAHqlFgdTA < EaeOKQokodcxgwtbhUExGUOlLZPn.Count)
							{
								kcjLEPfXDVUcrigftDCfOuECVSqM = EaeOKQokodcxgwtbhUExGUOlLZPn[hsmTjDnLtbmdDXDfQHltAHqlFgdTA].PollForAllAxes().GetEnumerator();
								xCpDFXeQyYbcHbGrSjmSUVQvlzIqA = -3;
								goto IL_0086;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void pNikNmdfFhiDiEcVfehAPLBTHWpJA()
					{
						xCpDFXeQyYbcHbGrSjmSUVQvlzIqA = -1;
						if (kcjLEPfXDVUcrigftDCfOuECVSqM != null)
						{
							kcjLEPfXDVUcrigftDCfOuECVSqM.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (xCpDFXeQyYbcHbGrSjmSUVQvlzIqA == -2 && cudcKTcLrojNuLuVYlsMfNLiWSrH == Environment.CurrentManagedThreadId)
						{
							xCpDFXeQyYbcHbGrSjmSUVQvlzIqA = 0;
							return this;
						}
						return new GlPjALVszuQuejuJjTRkYKSFfocIA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class savHguxbtEvucuNCphEEhHYjNStH : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int LVHRLFVYqIITUrjEGxRTDeKipRmD;

					private ControllerPollingInfo PHlwcsSLLOwnYvnAvZLyxMmWbOJAA;

					private int KBJaVTlmdHcAiHIBvfgHBzdZbTkI;

					private IList<Joystick> yhycruFNEpvncpeTiRsfwgykuFpE;

					private int TIvhjytslLIpMzcRNXtKzoLrBFeaA;

					private IEnumerator<ControllerPollingInfo> XZITTJoaQuXamlQaNMnGIxpQpHXP;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return PHlwcsSLLOwnYvnAvZLyxMmWbOJAA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return PHlwcsSLLOwnYvnAvZLyxMmWbOJAA;
						}
					}

					[DebuggerHidden]
					public savHguxbtEvucuNCphEEhHYjNStH(int P_0)
					{
						LVHRLFVYqIITUrjEGxRTDeKipRmD = P_0;
						KBJaVTlmdHcAiHIBvfgHBzdZbTkI = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int lVHRLFVYqIITUrjEGxRTDeKipRmD = LVHRLFVYqIITUrjEGxRTDeKipRmD;
						if (lVHRLFVYqIITUrjEGxRTDeKipRmD == -3 || lVHRLFVYqIITUrjEGxRTDeKipRmD == 1)
						{
							try
							{
							}
							finally
							{
								KpcXJhkxOKiTapRsUtMdXtdRkwYR();
							}
						}
						yhycruFNEpvncpeTiRsfwgykuFpE = null;
						XZITTJoaQuXamlQaNMnGIxpQpHXP = null;
						LVHRLFVYqIITUrjEGxRTDeKipRmD = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int lVHRLFVYqIITUrjEGxRTDeKipRmD = LVHRLFVYqIITUrjEGxRTDeKipRmD;
							if (lVHRLFVYqIITUrjEGxRTDeKipRmD != 0)
							{
								if (lVHRLFVYqIITUrjEGxRTDeKipRmD != 1)
								{
									return false;
								}
								LVHRLFVYqIITUrjEGxRTDeKipRmD = -3;
								goto IL_0086;
							}
							LVHRLFVYqIITUrjEGxRTDeKipRmD = -1;
							yhycruFNEpvncpeTiRsfwgykuFpE = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.FmfxwfhlxDwfpqdOLrqFojAgTbO;
							TIvhjytslLIpMzcRNXtKzoLrBFeaA = 0;
							goto IL_00b0;
							IL_0086:
							if (XZITTJoaQuXamlQaNMnGIxpQpHXP.MoveNext())
							{
								ControllerPollingInfo current = XZITTJoaQuXamlQaNMnGIxpQpHXP.Current;
								PHlwcsSLLOwnYvnAvZLyxMmWbOJAA = current;
								LVHRLFVYqIITUrjEGxRTDeKipRmD = 1;
								return true;
							}
							KpcXJhkxOKiTapRsUtMdXtdRkwYR();
							XZITTJoaQuXamlQaNMnGIxpQpHXP = null;
							TIvhjytslLIpMzcRNXtKzoLrBFeaA++;
							goto IL_00b0;
							IL_00b0:
							if (TIvhjytslLIpMzcRNXtKzoLrBFeaA < yhycruFNEpvncpeTiRsfwgykuFpE.Count)
							{
								XZITTJoaQuXamlQaNMnGIxpQpHXP = yhycruFNEpvncpeTiRsfwgykuFpE[TIvhjytslLIpMzcRNXtKzoLrBFeaA].PollForAllButtons().GetEnumerator();
								LVHRLFVYqIITUrjEGxRTDeKipRmD = -3;
								goto IL_0086;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void KpcXJhkxOKiTapRsUtMdXtdRkwYR()
					{
						LVHRLFVYqIITUrjEGxRTDeKipRmD = -1;
						if (XZITTJoaQuXamlQaNMnGIxpQpHXP != null)
						{
							XZITTJoaQuXamlQaNMnGIxpQpHXP.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (LVHRLFVYqIITUrjEGxRTDeKipRmD == -2 && KBJaVTlmdHcAiHIBvfgHBzdZbTkI == Environment.CurrentManagedThreadId)
						{
							LVHRLFVYqIITUrjEGxRTDeKipRmD = 0;
							return this;
						}
						return new savHguxbtEvucuNCphEEhHYjNStH(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class XrltQPNcWGCJLhxFeQixAKVtvaQc : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int BNjkWTeCqDsOpTSTlsdvTIXDbxxt;

					private ControllerPollingInfo LARxcDiNgkWnuHaapJmfhhiQCpWt;

					private int ppbuUkYfEaRTctqbvxMpsrXNcFwn;

					private IList<Joystick> nJNtxnfJChRwKrTDEglEkWeSRZam;

					private int BMQEaRIrLqhPkdoAavuRGNImVzwpB;

					private IEnumerator<ControllerPollingInfo> SXMiSEOMJxTEoUNvyHuhyZuYErCJ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return LARxcDiNgkWnuHaapJmfhhiQCpWt;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return LARxcDiNgkWnuHaapJmfhhiQCpWt;
						}
					}

					[DebuggerHidden]
					public XrltQPNcWGCJLhxFeQixAKVtvaQc(int P_0)
					{
						BNjkWTeCqDsOpTSTlsdvTIXDbxxt = P_0;
						ppbuUkYfEaRTctqbvxMpsrXNcFwn = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int bNjkWTeCqDsOpTSTlsdvTIXDbxxt = BNjkWTeCqDsOpTSTlsdvTIXDbxxt;
						if (bNjkWTeCqDsOpTSTlsdvTIXDbxxt == -3 || bNjkWTeCqDsOpTSTlsdvTIXDbxxt == 1)
						{
							try
							{
							}
							finally
							{
								GsqWxmlxNKkakeOxpFnVHuuROMOCb();
							}
						}
						nJNtxnfJChRwKrTDEglEkWeSRZam = null;
						SXMiSEOMJxTEoUNvyHuhyZuYErCJ = null;
						BNjkWTeCqDsOpTSTlsdvTIXDbxxt = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int bNjkWTeCqDsOpTSTlsdvTIXDbxxt = BNjkWTeCqDsOpTSTlsdvTIXDbxxt;
							if (bNjkWTeCqDsOpTSTlsdvTIXDbxxt != 0)
							{
								if (bNjkWTeCqDsOpTSTlsdvTIXDbxxt != 1)
								{
									return false;
								}
								BNjkWTeCqDsOpTSTlsdvTIXDbxxt = -3;
								goto IL_0086;
							}
							BNjkWTeCqDsOpTSTlsdvTIXDbxxt = -1;
							nJNtxnfJChRwKrTDEglEkWeSRZam = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.FmfxwfhlxDwfpqdOLrqFojAgTbO;
							BMQEaRIrLqhPkdoAavuRGNImVzwpB = 0;
							goto IL_00b0;
							IL_0086:
							if (SXMiSEOMJxTEoUNvyHuhyZuYErCJ.MoveNext())
							{
								ControllerPollingInfo current = SXMiSEOMJxTEoUNvyHuhyZuYErCJ.Current;
								LARxcDiNgkWnuHaapJmfhhiQCpWt = current;
								BNjkWTeCqDsOpTSTlsdvTIXDbxxt = 1;
								return true;
							}
							GsqWxmlxNKkakeOxpFnVHuuROMOCb();
							SXMiSEOMJxTEoUNvyHuhyZuYErCJ = null;
							BMQEaRIrLqhPkdoAavuRGNImVzwpB++;
							goto IL_00b0;
							IL_00b0:
							if (BMQEaRIrLqhPkdoAavuRGNImVzwpB < nJNtxnfJChRwKrTDEglEkWeSRZam.Count)
							{
								SXMiSEOMJxTEoUNvyHuhyZuYErCJ = nJNtxnfJChRwKrTDEglEkWeSRZam[BMQEaRIrLqhPkdoAavuRGNImVzwpB].PollForAllButtonsDown().GetEnumerator();
								BNjkWTeCqDsOpTSTlsdvTIXDbxxt = -3;
								goto IL_0086;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void GsqWxmlxNKkakeOxpFnVHuuROMOCb()
					{
						BNjkWTeCqDsOpTSTlsdvTIXDbxxt = -1;
						if (SXMiSEOMJxTEoUNvyHuhyZuYErCJ != null)
						{
							SXMiSEOMJxTEoUNvyHuhyZuYErCJ.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (BNjkWTeCqDsOpTSTlsdvTIXDbxxt == -2 && ppbuUkYfEaRTctqbvxMpsrXNcFwn == Environment.CurrentManagedThreadId)
						{
							BNjkWTeCqDsOpTSTlsdvTIXDbxxt = 0;
							return this;
						}
						return new XrltQPNcWGCJLhxFeQixAKVtvaQc(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class hflpgzgPkuGaVrNzfEEwhyFKcqOfA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int qUOyaTqZDDLazSmjjfOHtoyXzDRM;

					private ControllerPollingInfo yfCUdaNlqtxYZjlqqsChOKcYntVl;

					private int UprKYTSmNZgwnQyVgARCerbbykRD;

					private IList<Joystick> OCnuoSvGZeajXHlDfYqVHxtaKivU;

					private int aisIPiECvwzATSOJBfPYNDBsMrSL;

					private IEnumerator<ControllerPollingInfo> CwsIzhTXNYLrJVvtcTcdZBILKlFA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return yfCUdaNlqtxYZjlqqsChOKcYntVl;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return yfCUdaNlqtxYZjlqqsChOKcYntVl;
						}
					}

					[DebuggerHidden]
					public hflpgzgPkuGaVrNzfEEwhyFKcqOfA(int P_0)
					{
						qUOyaTqZDDLazSmjjfOHtoyXzDRM = P_0;
						UprKYTSmNZgwnQyVgARCerbbykRD = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = qUOyaTqZDDLazSmjjfOHtoyXzDRM;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								WFbGOWdZfGDIVzKOnHszuVbKYEPpA();
							}
						}
						OCnuoSvGZeajXHlDfYqVHxtaKivU = null;
						CwsIzhTXNYLrJVvtcTcdZBILKlFA = null;
						qUOyaTqZDDLazSmjjfOHtoyXzDRM = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = qUOyaTqZDDLazSmjjfOHtoyXzDRM;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								qUOyaTqZDDLazSmjjfOHtoyXzDRM = -3;
								goto IL_0086;
							}
							qUOyaTqZDDLazSmjjfOHtoyXzDRM = -1;
							OCnuoSvGZeajXHlDfYqVHxtaKivU = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.FmfxwfhlxDwfpqdOLrqFojAgTbO;
							aisIPiECvwzATSOJBfPYNDBsMrSL = 0;
							goto IL_00b0;
							IL_0086:
							if (CwsIzhTXNYLrJVvtcTcdZBILKlFA.MoveNext())
							{
								ControllerPollingInfo current = CwsIzhTXNYLrJVvtcTcdZBILKlFA.Current;
								yfCUdaNlqtxYZjlqqsChOKcYntVl = current;
								qUOyaTqZDDLazSmjjfOHtoyXzDRM = 1;
								return true;
							}
							WFbGOWdZfGDIVzKOnHszuVbKYEPpA();
							CwsIzhTXNYLrJVvtcTcdZBILKlFA = null;
							aisIPiECvwzATSOJBfPYNDBsMrSL++;
							goto IL_00b0;
							IL_00b0:
							if (aisIPiECvwzATSOJBfPYNDBsMrSL < OCnuoSvGZeajXHlDfYqVHxtaKivU.Count)
							{
								CwsIzhTXNYLrJVvtcTcdZBILKlFA = OCnuoSvGZeajXHlDfYqVHxtaKivU[aisIPiECvwzATSOJBfPYNDBsMrSL].PollForAllElements().GetEnumerator();
								qUOyaTqZDDLazSmjjfOHtoyXzDRM = -3;
								goto IL_0086;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void WFbGOWdZfGDIVzKOnHszuVbKYEPpA()
					{
						qUOyaTqZDDLazSmjjfOHtoyXzDRM = -1;
						if (CwsIzhTXNYLrJVvtcTcdZBILKlFA != null)
						{
							CwsIzhTXNYLrJVvtcTcdZBILKlFA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (qUOyaTqZDDLazSmjjfOHtoyXzDRM == -2 && UprKYTSmNZgwnQyVgARCerbbykRD == Environment.CurrentManagedThreadId)
						{
							qUOyaTqZDDLazSmjjfOHtoyXzDRM = 0;
							return this;
						}
						return new hflpgzgPkuGaVrNzfEEwhyFKcqOfA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class hLmHwfKEvMCibmmRQqQTiIaPfFLCA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int cbxVKEVVSkCcUyXEgJZAQCauWuuk;

					private ControllerPollingInfo hUoHMUgUOCbWDvtNDwHbQFCSOUoA;

					private int qZdjHYdLOqnfDUrlKZRmKdENXebq;

					private IList<Joystick> lSeiGfzkhLafbVLOHNDnlaLVgcJL;

					private int pzQKEcizgQsvxRdeQDUPdIrSxZQLA;

					private IEnumerator<ControllerPollingInfo> PXqLXTOqhxLXNtzMuavtuFFwoWlE;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return hUoHMUgUOCbWDvtNDwHbQFCSOUoA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return hUoHMUgUOCbWDvtNDwHbQFCSOUoA;
						}
					}

					[DebuggerHidden]
					public hLmHwfKEvMCibmmRQqQTiIaPfFLCA(int P_0)
					{
						cbxVKEVVSkCcUyXEgJZAQCauWuuk = P_0;
						qZdjHYdLOqnfDUrlKZRmKdENXebq = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = cbxVKEVVSkCcUyXEgJZAQCauWuuk;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								PMemkYYvjAGikoSmSNgHTVQFJbgp();
							}
						}
						lSeiGfzkhLafbVLOHNDnlaLVgcJL = null;
						PXqLXTOqhxLXNtzMuavtuFFwoWlE = null;
						cbxVKEVVSkCcUyXEgJZAQCauWuuk = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = cbxVKEVVSkCcUyXEgJZAQCauWuuk;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								cbxVKEVVSkCcUyXEgJZAQCauWuuk = -3;
								goto IL_0086;
							}
							cbxVKEVVSkCcUyXEgJZAQCauWuuk = -1;
							lSeiGfzkhLafbVLOHNDnlaLVgcJL = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.FmfxwfhlxDwfpqdOLrqFojAgTbO;
							pzQKEcizgQsvxRdeQDUPdIrSxZQLA = 0;
							goto IL_00b0;
							IL_0086:
							if (PXqLXTOqhxLXNtzMuavtuFFwoWlE.MoveNext())
							{
								ControllerPollingInfo current = PXqLXTOqhxLXNtzMuavtuFFwoWlE.Current;
								hUoHMUgUOCbWDvtNDwHbQFCSOUoA = current;
								cbxVKEVVSkCcUyXEgJZAQCauWuuk = 1;
								return true;
							}
							PMemkYYvjAGikoSmSNgHTVQFJbgp();
							PXqLXTOqhxLXNtzMuavtuFFwoWlE = null;
							pzQKEcizgQsvxRdeQDUPdIrSxZQLA++;
							goto IL_00b0;
							IL_00b0:
							if (pzQKEcizgQsvxRdeQDUPdIrSxZQLA < lSeiGfzkhLafbVLOHNDnlaLVgcJL.Count)
							{
								PXqLXTOqhxLXNtzMuavtuFFwoWlE = lSeiGfzkhLafbVLOHNDnlaLVgcJL[pzQKEcizgQsvxRdeQDUPdIrSxZQLA].PollForAllElementsDown().GetEnumerator();
								cbxVKEVVSkCcUyXEgJZAQCauWuuk = -3;
								goto IL_0086;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void PMemkYYvjAGikoSmSNgHTVQFJbgp()
					{
						cbxVKEVVSkCcUyXEgJZAQCauWuuk = -1;
						if (PXqLXTOqhxLXNtzMuavtuFFwoWlE != null)
						{
							PXqLXTOqhxLXNtzMuavtuFFwoWlE.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (cbxVKEVVSkCcUyXEgJZAQCauWuuk == -2 && qZdjHYdLOqnfDUrlKZRmKdENXebq == Environment.CurrentManagedThreadId)
						{
							cbxVKEVVSkCcUyXEgJZAQCauWuuk = 0;
							return this;
						}
						return new hLmHwfKEvMCibmmRQqQTiIaPfFLCA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private static PollingHelper LGJiUkcQLLDdoXlizgPWIfyrIZriA;

				internal static PollingHelper EzrVIkbPYERbvnSfvkkSYaWcJufi => LGJiUkcQLLDdoXlizgPWIfyrIZriA ?? (LGJiUkcQLLDdoXlizgPWIfyrIZriA = new PollingHelper());

				private PollingHelper()
				{
				}

				public ControllerPollingInfo PollAllControllersForFirstElement()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					ControllerPollingInfo result = oJDEbhPYgkYJdxPZjnPajcMdfuAC();
					if (result.success)
					{
						return result;
					}
					result = QmfJmKFxJNgrxgekjkFXNHkQBzZdA();
					if (result.success)
					{
						return result;
					}
					result = ECQTbrvwHutciPaGlHZqiUnTbpdp();
					if (result.success)
					{
						return result;
					}
					result = LsgVEwPbnwzwyeTdIaVhlASgtMSu();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				public ControllerPollingInfo PollAllControllersForFirstElementDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					ControllerPollingInfo result = CGGDMcakMMUPzcIvkVQNTKhKaHzG();
					if (result.success)
					{
						return result;
					}
					result = yZuVnmwwdamdeUnTCOPoMfVYEHaDA();
					if (result.success)
					{
						return result;
					}
					result = AtSKGpbmtjIBTbqgTfEMyYdnFRhr();
					if (result.success)
					{
						return result;
					}
					result = ZVWgeAiIbLlRbygCKNNVfMnRGjbHA();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				public ControllerPollingInfo PollAllControllersForFirstButton()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					ControllerPollingInfo result = rsHvaSHLTkhzYUPVAnzGjkCJjZEh();
					if (result.success)
					{
						return result;
					}
					result = QmfJmKFxJNgrxgekjkFXNHkQBzZdA();
					if (result.success)
					{
						return result;
					}
					result = tSQWSlPqsuhQedsIyCnjaUwqchfv();
					if (result.success)
					{
						return result;
					}
					result = WlwzRjpnkpuUAXrAPydsJUbfSToy();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				public ControllerPollingInfo PollAllControllersForFirstButtonDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					ControllerPollingInfo result = YGIeeRCdAsIZXXWMqrmehokvvhHVA();
					if (result.success)
					{
						return result;
					}
					result = yZuVnmwwdamdeUnTCOPoMfVYEHaDA();
					if (result.success)
					{
						return result;
					}
					result = UbJShVedTdDLrjRCXQIaJVnSsCzX();
					if (result.success)
					{
						return result;
					}
					result = yaJMiICOIMevSozaSJbFMnjXHpBx();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				public ControllerPollingInfo PollAllControllersForFirstAxis()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					ControllerPollingInfo result = TbWldtHUmeGKMPpkriAjdcdemnTTA();
					if (result.success)
					{
						return result;
					}
					result = ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					if (result.success)
					{
						return result;
					}
					result = gpFMKPCMXadNHgZSxDkGfVXZeesbA();
					if (result.success)
					{
						return result;
					}
					result = YagHgRdcFpLDhJUUyDcBcanAptQyb();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return controllerType switch
					{
						ControllerType.Joystick => oJDEbhPYgkYJdxPZjnPajcMdfuAC(), 
						ControllerType.Keyboard => QmfJmKFxJNgrxgekjkFXNHkQBzZdA(), 
						ControllerType.Mouse => ECQTbrvwHutciPaGlHZqiUnTbpdp(), 
						ControllerType.Custom => LsgVEwPbnwzwyeTdIaVhlASgtMSu(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElementDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return controllerType switch
					{
						ControllerType.Joystick => CGGDMcakMMUPzcIvkVQNTKhKaHzG(), 
						ControllerType.Keyboard => yZuVnmwwdamdeUnTCOPoMfVYEHaDA(), 
						ControllerType.Mouse => AtSKGpbmtjIBTbqgTfEMyYdnFRhr(), 
						ControllerType.Custom => ZVWgeAiIbLlRbygCKNNVfMnRGjbHA(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return controllerType switch
					{
						ControllerType.Joystick => rsHvaSHLTkhzYUPVAnzGjkCJjZEh(), 
						ControllerType.Keyboard => QmfJmKFxJNgrxgekjkFXNHkQBzZdA(), 
						ControllerType.Mouse => tSQWSlPqsuhQedsIyCnjaUwqchfv(), 
						ControllerType.Custom => WlwzRjpnkpuUAXrAPydsJUbfSToy(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return controllerType switch
					{
						ControllerType.Joystick => YGIeeRCdAsIZXXWMqrmehokvvhHVA(), 
						ControllerType.Keyboard => yZuVnmwwdamdeUnTCOPoMfVYEHaDA(), 
						ControllerType.Mouse => UbJShVedTdDLrjRCXQIaJVnSsCzX(), 
						ControllerType.Custom => yaJMiICOIMevSozaSJbFMnjXHpBx(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return controllerType switch
					{
						ControllerType.Joystick => TbWldtHUmeGKMPpkriAjdcdemnTTA(), 
						ControllerType.Keyboard => ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU(), 
						ControllerType.Mouse => gpFMKPCMXadNHgZSxDkGfVXZeesbA(), 
						ControllerType.Custom => YagHgRdcFpLDhJUUyDcBcanAptQyb(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return controllerType switch
					{
						ControllerType.Joystick => aBsFyxEmjsFCjCxvhRJLjqcSdmnFb(controllerId), 
						ControllerType.Keyboard => QmfJmKFxJNgrxgekjkFXNHkQBzZdA(), 
						ControllerType.Mouse => ECQTbrvwHutciPaGlHZqiUnTbpdp(), 
						ControllerType.Custom => HPolpCdGmJggvJyllVIsRwRaTRJO(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return controllerType switch
					{
						ControllerType.Joystick => tjbBKrKOcXlhQelNDIDtEloIntEWC(controllerId), 
						ControllerType.Keyboard => yZuVnmwwdamdeUnTCOPoMfVYEHaDA(), 
						ControllerType.Mouse => AtSKGpbmtjIBTbqgTfEMyYdnFRhr(), 
						ControllerType.Custom => DDGIZqBtHKeArWXwwWoaIGHxPOfxA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return controllerType switch
					{
						ControllerType.Joystick => GdMVlEQGVCLSRPJNGYTUePaDBXgp(controllerId), 
						ControllerType.Keyboard => QmfJmKFxJNgrxgekjkFXNHkQBzZdA(), 
						ControllerType.Mouse => tSQWSlPqsuhQedsIyCnjaUwqchfv(), 
						ControllerType.Custom => rAGjbcrajLEHKfUyBbPrlwLeeJhw(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return controllerType switch
					{
						ControllerType.Joystick => iCKiVzgVrOSNBKUQAHAGjFneddhZ(controllerId), 
						ControllerType.Keyboard => yZuVnmwwdamdeUnTCOPoMfVYEHaDA(), 
						ControllerType.Mouse => UbJShVedTdDLrjRCXQIaJVnSsCzX(), 
						ControllerType.Custom => xeTyRrWRYDedkjGixCOQBrWeOLDDA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
					}
					return controllerType switch
					{
						ControllerType.Joystick => ytEfBbgVuVreXHEySgtPwPRQzpxHA(controllerId), 
						ControllerType.Keyboard => ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU(), 
						ControllerType.Mouse => gpFMKPCMXadNHgZSxDkGfVXZeesbA(), 
						ControllerType.Custom => gljszsnNIQWyZtihkuOVVijyrJYJ(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				[IteratorStateMachine(typeof(SeSPNqzNCXDUFBWYFoRVNCZhYpr))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElements()
				{
					return new SeSPNqzNCXDUFBWYFoRVNCZhYpr(-2)
					{
						MvfQZmafMIVenXPloFrjsXiDgBEBA = this
					};
				}

				[IteratorStateMachine(typeof(yBzhqZGaIpvnznxgkwMJmRFJeGmHA))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElementsDown()
				{
					return new yBzhqZGaIpvnznxgkwMJmRFJeGmHA(-2)
					{
						vPGJfPZtmPGJoohusNSWpoKsACRHA = this
					};
				}

				[IteratorStateMachine(typeof(ZlYFxvzSMSWeSdfSVchhIfPYNchxA))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtons()
				{
					return new ZlYFxvzSMSWeSdfSVchhIfPYNchxA(-2)
					{
						INGSfgxcbrEKfFwdMXjykqoSBfXfA = this
					};
				}

				[IteratorStateMachine(typeof(LxnJHdhDuZnXHoCiPIQkHLKJguesA))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtonsDown()
				{
					return new LxnJHdhDuZnXHoCiPIQkHLKJguesA(-2)
					{
						mefnLrwghhkLDCfIldMzuRLhLkbU = this
					};
				}

				[IteratorStateMachine(typeof(ddrDyoGQZTBDnEPlOsOcQtjBIXCAb))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllAxes()
				{
					return new ddrDyoGQZTBDnEPlOsOcQtjBIXCAb(-2)
					{
						FymidxZJdhZGcaxjjMyfifzDbhgBA = this
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Joystick => iUlTZjwGzTeAaqdCGFwjNtnzfEhM(controllerId), 
						ControllerType.Keyboard => sjsENOKkaaCwGaTVCsqaGVdCnuGEE(), 
						ControllerType.Mouse => imsVAvIeJiONJwriAYgFfsLKdIud(), 
						ControllerType.Custom => AXMDAybXLSWyMHEUlSZKojroUQSR(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElementsDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Joystick => GGMFLfqgmjcgJfPjEtQNMtktIvAGb(controllerId), 
						ControllerType.Keyboard => NNJUSIqUVoMSpNghqiIOavdDjkzB(), 
						ControllerType.Mouse => kCkYjmovYSNkgizFvvYoDUhXhZLV(), 
						ControllerType.Custom => jCQXhoXNgNwxLgEcohoaGpRanTOy(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtons(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Joystick => sUpjbUwriYgpHromTehMvUNqEgNaA(controllerId), 
						ControllerType.Keyboard => sjsENOKkaaCwGaTVCsqaGVdCnuGEE(), 
						ControllerType.Mouse => IBmpVfvlUyAIvbkosTrDyeeLjCkU(), 
						ControllerType.Custom => iscZovBPFiuZjvfmimhBzlPkxAbM(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtonsDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Joystick => sBcNKQNVCLKbbQojDMZRUIOwTrpl(controllerId), 
						ControllerType.Keyboard => NNJUSIqUVoMSpNghqiIOavdDjkzB(), 
						ControllerType.Mouse => atfmcMmvjzEKihsNqEgdhPXBQGdV(), 
						ControllerType.Custom => yLvEHFiwdVyUhOxsmcvPbgakkEhWA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllAxes(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Joystick => irwFEaBJuPZAEVkYHlEswrGrJDQu(controllerId), 
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Mouse => tJZjzoYpuBSRYXOyYmtPKnaYgLk(), 
						ControllerType.Custom => dLyFqvnYLrlhqDejSjUbHVWtSzpb(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				private ControllerPollingInfo oJDEbhPYgkYJdxPZjnPajcMdfuAC()
				{
					IList<Joystick> list = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.FmfxwfhlxDwfpqdOLrqFojAgTbO;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo CGGDMcakMMUPzcIvkVQNTKhKaHzG()
				{
					IList<Joystick> list = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.FmfxwfhlxDwfpqdOLrqFojAgTbO;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo rsHvaSHLTkhzYUPVAnzGjkCJjZEh()
				{
					IList<Joystick> list = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.FmfxwfhlxDwfpqdOLrqFojAgTbO;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo YGIeeRCdAsIZXXWMqrmehokvvhHVA()
				{
					IList<Joystick> list = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.FmfxwfhlxDwfpqdOLrqFojAgTbO;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo TbWldtHUmeGKMPpkriAjdcdemnTTA()
				{
					IList<Joystick> list = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.FmfxwfhlxDwfpqdOLrqFojAgTbO;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo aBsFyxEmjsFCjCxvhRJLjqcSdmnFb(int P_0)
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.GetJoystick(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo tjbBKrKOcXlhQelNDIDtEloIntEWC(int P_0)
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.GetJoystick(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo GdMVlEQGVCLSRPJNGYTUePaDBXgp(int P_0)
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.GetJoystick(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo iCKiVzgVrOSNBKUQAHAGjFneddhZ(int P_0)
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.GetJoystick(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo ytEfBbgVuVreXHEySgtPwPRQzpxHA(int P_0)
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.GetJoystick(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo QmfJmKFxJNgrxgekjkFXNHkQBzZdA()
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo yZuVnmwwdamdeUnTCOPoMfVYEHaDA()
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.Keyboard.PollForFirstKeyDown();
				}

				private ControllerPollingInfo ECQTbrvwHutciPaGlHZqiUnTbpdp()
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo AtSKGpbmtjIBTbqgTfEMyYdnFRhr()
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo tSQWSlPqsuhQedsIyCnjaUwqchfv()
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo UbJShVedTdDLrjRCXQIaJVnSsCzX()
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo gpFMKPCMXadNHgZSxDkGfVXZeesbA()
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.Mouse.PollForFirstAxis();
				}

				private ControllerPollingInfo LsgVEwPbnwzwyeTdIaVhlASgtMSu()
				{
					IList<CustomController> list = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.znuGFVHdakBIvysMReNIjKPHIQDfb;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo ZVWgeAiIbLlRbygCKNNVfMnRGjbHA()
				{
					IList<CustomController> list = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.znuGFVHdakBIvysMReNIjKPHIQDfb;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo WlwzRjpnkpuUAXrAPydsJUbfSToy()
				{
					IList<CustomController> list = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.znuGFVHdakBIvysMReNIjKPHIQDfb;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo yaJMiICOIMevSozaSJbFMnjXHpBx()
				{
					IList<CustomController> list = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.znuGFVHdakBIvysMReNIjKPHIQDfb;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo YagHgRdcFpLDhJUUyDcBcanAptQyb()
				{
					IList<CustomController> list = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.znuGFVHdakBIvysMReNIjKPHIQDfb;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo HPolpCdGmJggvJyllVIsRwRaTRJO(int P_0)
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.GetCustomController(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo DDGIZqBtHKeArWXwwWoaIGHxPOfxA(int P_0)
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.GetCustomController(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo rAGjbcrajLEHKfUyBbPrlwLeeJhw(int P_0)
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.GetCustomController(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo xeTyRrWRYDedkjGixCOQBrWeOLDDA(int P_0)
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.GetCustomController(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				private ControllerPollingInfo gljszsnNIQWyZtihkuOVVijyrJYJ(int P_0)
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.GetCustomController(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.sibYIoxcdAWUVcmislmwgFvCUlnU();
				}

				[IteratorStateMachine(typeof(hflpgzgPkuGaVrNzfEEwhyFKcqOfA))]
				private IEnumerable<ControllerPollingInfo> MHstpPwvTXAJncHPklBRdIaJPEns()
				{
					return new hflpgzgPkuGaVrNzfEEwhyFKcqOfA(-2);
				}

				[IteratorStateMachine(typeof(hLmHwfKEvMCibmmRQqQTiIaPfFLCA))]
				private IEnumerable<ControllerPollingInfo> QOKUwKRwlfocuacmVzojCoBkfhMKA()
				{
					return new hLmHwfKEvMCibmmRQqQTiIaPfFLCA(-2);
				}

				[IteratorStateMachine(typeof(savHguxbtEvucuNCphEEhHYjNStH))]
				private IEnumerable<ControllerPollingInfo> VyTeiPwKWXisLVQVZWdvGZWIaqME()
				{
					return new savHguxbtEvucuNCphEEhHYjNStH(-2);
				}

				[IteratorStateMachine(typeof(XrltQPNcWGCJLhxFeQixAKVtvaQc))]
				private IEnumerable<ControllerPollingInfo> QsdXgtigUKxmjHJHIVPPniTGWrZv()
				{
					return new XrltQPNcWGCJLhxFeQixAKVtvaQc(-2);
				}

				[IteratorStateMachine(typeof(GlPjALVszuQuejuJjTRkYKSFfocIA))]
				private IEnumerable<ControllerPollingInfo> zUQBHBBNjGDpxhSbFSYWoNpCJhFo()
				{
					return new GlPjALVszuQuejuJjTRkYKSFfocIA(-2);
				}

				private IEnumerable<ControllerPollingInfo> iUlTZjwGzTeAaqdCGFwjNtnzfEhM(int P_0)
				{
					Joystick joystick = pJDMGevuVCXoaIrbxyhEgKGtMfaJ.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> GGMFLfqgmjcgJfPjEtQNMtktIvAGb(int P_0)
				{
					Joystick joystick = pJDMGevuVCXoaIrbxyhEgKGtMfaJ.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> sUpjbUwriYgpHromTehMvUNqEgNaA(int P_0)
				{
					Joystick joystick = pJDMGevuVCXoaIrbxyhEgKGtMfaJ.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> sBcNKQNVCLKbbQojDMZRUIOwTrpl(int P_0)
				{
					Joystick joystick = pJDMGevuVCXoaIrbxyhEgKGtMfaJ.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> irwFEaBJuPZAEVkYHlEswrGrJDQu(int P_0)
				{
					Joystick joystick = pJDMGevuVCXoaIrbxyhEgKGtMfaJ.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllAxes();
				}

				private IEnumerable<ControllerPollingInfo> sjsENOKkaaCwGaTVCsqaGVdCnuGEE()
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> NNJUSIqUVoMSpNghqiIOavdDjkzB()
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.Keyboard.PollForAllKeysDown();
				}

				private IEnumerable<ControllerPollingInfo> imsVAvIeJiONJwriAYgFfsLKdIud()
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> kCkYjmovYSNkgizFvvYoDUhXhZLV()
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> IBmpVfvlUyAIvbkosTrDyeeLjCkU()
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> atfmcMmvjzEKihsNqEgdhPXBQGdV()
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> tJZjzoYpuBSRYXOyYmtPKnaYgLk()
				{
					return pJDMGevuVCXoaIrbxyhEgKGtMfaJ.Mouse.PollForAllAxes();
				}

				[IteratorStateMachine(typeof(yFRhhlGeGCgmwozIHOhVFxhYwIgBA))]
				private IEnumerable<ControllerPollingInfo> gvMFHvaqOpTvXnyEBKquBopXUBsF()
				{
					return new yFRhhlGeGCgmwozIHOhVFxhYwIgBA(-2);
				}

				[IteratorStateMachine(typeof(YsZwMlbLHWzWNIMBXKxOyoumOduO))]
				private IEnumerable<ControllerPollingInfo> iLPSFzAohkeBKBlYDfnZFwtRPSVN()
				{
					return new YsZwMlbLHWzWNIMBXKxOyoumOduO(-2);
				}

				[IteratorStateMachine(typeof(QYhfpqYQTGqttSUXAfnJWPVhPGUf))]
				private IEnumerable<ControllerPollingInfo> DFkYkfuETRGRTfKskUkCAOFJOBApA()
				{
					return new QYhfpqYQTGqttSUXAfnJWPVhPGUf(-2);
				}

				[IteratorStateMachine(typeof(HGYZbwicUlfunQGUYtVDazSryoUF))]
				private IEnumerable<ControllerPollingInfo> XCGCHiKtCdZekWgLQkUhaLndiVJTB()
				{
					return new HGYZbwicUlfunQGUYtVDazSryoUF(-2);
				}

				[IteratorStateMachine(typeof(ixixnIWdJlWbibcjuDcatHsLtmPE))]
				private IEnumerable<ControllerPollingInfo> llpmOicAesCFuMVMZfdpLHIdXQIj()
				{
					return new ixixnIWdJlWbibcjuDcatHsLtmPE(-2);
				}

				private IEnumerable<ControllerPollingInfo> AXMDAybXLSWyMHEUlSZKojroUQSR(int P_0)
				{
					CustomController customController = pJDMGevuVCXoaIrbxyhEgKGtMfaJ.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> jCQXhoXNgNwxLgEcohoaGpRanTOy(int P_0)
				{
					CustomController customController = pJDMGevuVCXoaIrbxyhEgKGtMfaJ.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> iscZovBPFiuZjvfmimhBzlPkxAbM(int P_0)
				{
					CustomController customController = pJDMGevuVCXoaIrbxyhEgKGtMfaJ.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> yLvEHFiwdVyUhOxsmcvPbgakkEhWA(int P_0)
				{
					CustomController customController = pJDMGevuVCXoaIrbxyhEgKGtMfaJ.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> dLyFqvnYLrlhqDejSjUbHVWtSzpb(int P_0)
				{
					CustomController customController = pJDMGevuVCXoaIrbxyhEgKGtMfaJ.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllAxes();
				}
			}

			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class QUgNDkajfGbyOrRyXJdzzXYZpMEs : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int INJHatUbvBeKhjlhykHjlspyPAszA;

					private ElementAssignmentConflictInfo qyWrmcRhyTgvtgNRQKLhnjKiTmEQA;

					private int GWsZEQWSwMiDYUfeNbYKFqbwLEhS;

					private int ArwJKVifJyPitqPWSBYCjpVPcqCN;

					public int YfWFqQDtkFTFqpxtiVPVoroKtctRA;

					private ActionElementMap XICPEGcEIHDAOALywxFFAfvCgngBb;

					public ActionElementMap dejbppiiXLbeSIiCKYGLCyYgyVjfb;

					private bool osQReqiFLuxiZOqfhbeBVfmVpbkv;

					public bool EZEGFkaDGAnCUIyMLMkSZsfcbqnE;

					private int xRKSrNcBhLJYRHOGsCHCkiLbLgcP;

					public int dkNcMEWaehhjyiyHinKdjGWvvpZAA;

					private CustomControllerMap egYYmwJPBOzKjJjmloOvBKCRthUN;

					public CustomControllerMap NzLNVUmpKmAmgRHFSibrumsmsalb;

					private bool LCLxxMBCvKDvVfPnExiRqFBMsQNwA;

					public bool YoIUwtWpZXLXkpBePhxYEmCZYulF;

					private bool KyCqzOsAYLOJChFgyeMsXkBheKYQ;

					public bool jnzDXFFBoYEAtoprSJCmrLTbaKGQA;

					private IList<Player> OlKtldoScOaMQyIXrjARLzcnfiRI;

					private int qhZyGqNScSEnMCMoMfmboNxBazTo;

					private IEnumerator<ElementAssignmentConflictInfo> jIyTcCLBKatMFkYVUFlwaBtwmMBv;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return qyWrmcRhyTgvtgNRQKLhnjKiTmEQA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return qyWrmcRhyTgvtgNRQKLhnjKiTmEQA;
						}
					}

					[DebuggerHidden]
					public QUgNDkajfGbyOrRyXJdzzXYZpMEs(int P_0)
					{
						INJHatUbvBeKhjlhykHjlspyPAszA = P_0;
						GWsZEQWSwMiDYUfeNbYKFqbwLEhS = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int iNJHatUbvBeKhjlhykHjlspyPAszA = INJHatUbvBeKhjlhykHjlspyPAszA;
						if (iNJHatUbvBeKhjlhykHjlspyPAszA == -3 || iNJHatUbvBeKhjlhykHjlspyPAszA == 1)
						{
							try
							{
							}
							finally
							{
								FuDXKVuFhNcVDHoamkvcjaaiSMeC();
							}
						}
						OlKtldoScOaMQyIXrjARLzcnfiRI = null;
						jIyTcCLBKatMFkYVUFlwaBtwmMBv = null;
						INJHatUbvBeKhjlhykHjlspyPAszA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int iNJHatUbvBeKhjlhykHjlspyPAszA = INJHatUbvBeKhjlhykHjlspyPAszA;
							if (iNJHatUbvBeKhjlhykHjlspyPAszA != 0)
							{
								if (iNJHatUbvBeKhjlhykHjlspyPAszA != 1)
								{
									return false;
								}
								INJHatUbvBeKhjlhykHjlspyPAszA = -3;
								goto IL_00e2;
							}
							INJHatUbvBeKhjlhykHjlspyPAszA = -1;
							if (ArwJKVifJyPitqPWSBYCjpVPcqCN < 0 || XICPEGcEIHDAOALywxFFAfvCgngBb == null)
							{
								return false;
							}
							OlKtldoScOaMQyIXrjARLzcnfiRI = (osQReqiFLuxiZOqfhbeBVfmVpbkv ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
							qhZyGqNScSEnMCMoMfmboNxBazTo = 0;
							goto IL_010c;
							IL_010c:
							if (qhZyGqNScSEnMCMoMfmboNxBazTo < OlKtldoScOaMQyIXrjARLzcnfiRI.Count)
							{
								jIyTcCLBKatMFkYVUFlwaBtwmMBv = OlKtldoScOaMQyIXrjARLzcnfiRI[qhZyGqNScSEnMCMoMfmboNxBazTo].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Custom, xRKSrNcBhLJYRHOGsCHCkiLbLgcP, egYYmwJPBOzKjJjmloOvBKCRthUN, XICPEGcEIHDAOALywxFFAfvCgngBb, LCLxxMBCvKDvVfPnExiRqFBMsQNwA, KyCqzOsAYLOJChFgyeMsXkBheKYQ).GetEnumerator();
								INJHatUbvBeKhjlhykHjlspyPAszA = -3;
								goto IL_00e2;
							}
							return false;
							IL_00e2:
							if (jIyTcCLBKatMFkYVUFlwaBtwmMBv.MoveNext())
							{
								ElementAssignmentConflictInfo current = jIyTcCLBKatMFkYVUFlwaBtwmMBv.Current;
								qyWrmcRhyTgvtgNRQKLhnjKiTmEQA = current;
								INJHatUbvBeKhjlhykHjlspyPAszA = 1;
								return true;
							}
							FuDXKVuFhNcVDHoamkvcjaaiSMeC();
							jIyTcCLBKatMFkYVUFlwaBtwmMBv = null;
							qhZyGqNScSEnMCMoMfmboNxBazTo++;
							goto IL_010c;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void FuDXKVuFhNcVDHoamkvcjaaiSMeC()
					{
						INJHatUbvBeKhjlhykHjlspyPAszA = -1;
						if (jIyTcCLBKatMFkYVUFlwaBtwmMBv != null)
						{
							jIyTcCLBKatMFkYVUFlwaBtwmMBv.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						QUgNDkajfGbyOrRyXJdzzXYZpMEs qUgNDkajfGbyOrRyXJdzzXYZpMEs;
						if (INJHatUbvBeKhjlhykHjlspyPAszA == -2 && GWsZEQWSwMiDYUfeNbYKFqbwLEhS == Environment.CurrentManagedThreadId)
						{
							INJHatUbvBeKhjlhykHjlspyPAszA = 0;
							qUgNDkajfGbyOrRyXJdzzXYZpMEs = this;
						}
						else
						{
							qUgNDkajfGbyOrRyXJdzzXYZpMEs = new QUgNDkajfGbyOrRyXJdzzXYZpMEs(0);
						}
						qUgNDkajfGbyOrRyXJdzzXYZpMEs.ArwJKVifJyPitqPWSBYCjpVPcqCN = YfWFqQDtkFTFqpxtiVPVoroKtctRA;
						qUgNDkajfGbyOrRyXJdzzXYZpMEs.xRKSrNcBhLJYRHOGsCHCkiLbLgcP = dkNcMEWaehhjyiyHinKdjGWvvpZAA;
						qUgNDkajfGbyOrRyXJdzzXYZpMEs.egYYmwJPBOzKjJjmloOvBKCRthUN = NzLNVUmpKmAmgRHFSibrumsmsalb;
						qUgNDkajfGbyOrRyXJdzzXYZpMEs.XICPEGcEIHDAOALywxFFAfvCgngBb = dejbppiiXLbeSIiCKYGLCyYgyVjfb;
						qUgNDkajfGbyOrRyXJdzzXYZpMEs.LCLxxMBCvKDvVfPnExiRqFBMsQNwA = YoIUwtWpZXLXkpBePhxYEmCZYulF;
						qUgNDkajfGbyOrRyXJdzzXYZpMEs.KyCqzOsAYLOJChFgyeMsXkBheKYQ = jnzDXFFBoYEAtoprSJCmrLTbaKGQA;
						qUgNDkajfGbyOrRyXJdzzXYZpMEs.osQReqiFLuxiZOqfhbeBVfmVpbkv = EZEGFkaDGAnCUIyMLMkSZsfcbqnE;
						return qUgNDkajfGbyOrRyXJdzzXYZpMEs;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class lgUlVkJOanakAASobNSgveexETiK : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int IxmTMYOMdSLqcJdeKmYiCNevmfgO;

					private ElementAssignmentConflictInfo SFYffAMMcmwDlxnDYfKdfETiIvUIA;

					private int hRufOkWzVrPnQjbvJsUbwtwhismF;

					private ElementAssignmentConflictCheck XbyLywSuzMfWwRLBZfcRglYsigzU;

					public ElementAssignmentConflictCheck reLhaihwfxSgicjVnrbOLRgKYEGs;

					private bool oUDhRqHnWVhZhnqIMphkaJAgZtrv;

					public bool BKtDYnpOvECwYtlRuYdkCmZhfvSS;

					private bool GxufpPGRRUwzDnjwMjohLYJOGKpx;

					public bool OUhwxnjRrBeLvZLNUAMhTWnqTcxQ;

					private bool IaXwmPuwaosemHNcrhzZgxLDKIWZ;

					public bool AezejuKgQuKIBVHsKLxaLDJuuRwo;

					private IList<Player> dkzrRZxGdGbvdHBKvjRolLOiBxQnA;

					private int kKrcOnEkWyqeUdCkMCtkFqudsimtb;

					private IEnumerator<ElementAssignmentConflictInfo> limqCFkHifTOraEXzusfCOysyuPI;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return SFYffAMMcmwDlxnDYfKdfETiIvUIA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return SFYffAMMcmwDlxnDYfKdfETiIvUIA;
						}
					}

					[DebuggerHidden]
					public lgUlVkJOanakAASobNSgveexETiK(int P_0)
					{
						IxmTMYOMdSLqcJdeKmYiCNevmfgO = P_0;
						hRufOkWzVrPnQjbvJsUbwtwhismF = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int ixmTMYOMdSLqcJdeKmYiCNevmfgO = IxmTMYOMdSLqcJdeKmYiCNevmfgO;
						if (ixmTMYOMdSLqcJdeKmYiCNevmfgO == -3 || ixmTMYOMdSLqcJdeKmYiCNevmfgO == 1)
						{
							try
							{
							}
							finally
							{
								CerANoYSBvyVzpghrDQKRWkdKjeN();
							}
						}
						dkzrRZxGdGbvdHBKvjRolLOiBxQnA = null;
						limqCFkHifTOraEXzusfCOysyuPI = null;
						IxmTMYOMdSLqcJdeKmYiCNevmfgO = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int ixmTMYOMdSLqcJdeKmYiCNevmfgO = IxmTMYOMdSLqcJdeKmYiCNevmfgO;
							if (ixmTMYOMdSLqcJdeKmYiCNevmfgO != 0)
							{
								if (ixmTMYOMdSLqcJdeKmYiCNevmfgO != 1)
								{
									return false;
								}
								IxmTMYOMdSLqcJdeKmYiCNevmfgO = -3;
								goto IL_00df;
							}
							IxmTMYOMdSLqcJdeKmYiCNevmfgO = -1;
							if (XbyLywSuzMfWwRLBZfcRglYsigzU.playerId < 0 || XbyLywSuzMfWwRLBZfcRglYsigzU.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							dkzrRZxGdGbvdHBKvjRolLOiBxQnA = (oUDhRqHnWVhZhnqIMphkaJAgZtrv ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
							kKrcOnEkWyqeUdCkMCtkFqudsimtb = 0;
							goto IL_0109;
							IL_0109:
							if (kKrcOnEkWyqeUdCkMCtkFqudsimtb < dkzrRZxGdGbvdHBKvjRolLOiBxQnA.Count)
							{
								limqCFkHifTOraEXzusfCOysyuPI = dkzrRZxGdGbvdHBKvjRolLOiBxQnA[kKrcOnEkWyqeUdCkMCtkFqudsimtb].controllers.conflictChecking.ElementAssignmentConflicts(XbyLywSuzMfWwRLBZfcRglYsigzU, GxufpPGRRUwzDnjwMjohLYJOGKpx, IaXwmPuwaosemHNcrhzZgxLDKIWZ).GetEnumerator();
								IxmTMYOMdSLqcJdeKmYiCNevmfgO = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (limqCFkHifTOraEXzusfCOysyuPI.MoveNext())
							{
								ElementAssignmentConflictInfo current = limqCFkHifTOraEXzusfCOysyuPI.Current;
								SFYffAMMcmwDlxnDYfKdfETiIvUIA = current;
								IxmTMYOMdSLqcJdeKmYiCNevmfgO = 1;
								return true;
							}
							CerANoYSBvyVzpghrDQKRWkdKjeN();
							limqCFkHifTOraEXzusfCOysyuPI = null;
							kKrcOnEkWyqeUdCkMCtkFqudsimtb++;
							goto IL_0109;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void CerANoYSBvyVzpghrDQKRWkdKjeN()
					{
						IxmTMYOMdSLqcJdeKmYiCNevmfgO = -1;
						if (limqCFkHifTOraEXzusfCOysyuPI != null)
						{
							limqCFkHifTOraEXzusfCOysyuPI.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						lgUlVkJOanakAASobNSgveexETiK lgUlVkJOanakAASobNSgveexETiK2;
						if (IxmTMYOMdSLqcJdeKmYiCNevmfgO == -2 && hRufOkWzVrPnQjbvJsUbwtwhismF == Environment.CurrentManagedThreadId)
						{
							IxmTMYOMdSLqcJdeKmYiCNevmfgO = 0;
							lgUlVkJOanakAASobNSgveexETiK2 = this;
						}
						else
						{
							lgUlVkJOanakAASobNSgveexETiK2 = new lgUlVkJOanakAASobNSgveexETiK(0);
						}
						lgUlVkJOanakAASobNSgveexETiK2.XbyLywSuzMfWwRLBZfcRglYsigzU = reLhaihwfxSgicjVnrbOLRgKYEGs;
						lgUlVkJOanakAASobNSgveexETiK2.GxufpPGRRUwzDnjwMjohLYJOGKpx = OUhwxnjRrBeLvZLNUAMhTWnqTcxQ;
						lgUlVkJOanakAASobNSgveexETiK2.IaXwmPuwaosemHNcrhzZgxLDKIWZ = AezejuKgQuKIBVHsKLxaLDJuuRwo;
						lgUlVkJOanakAASobNSgveexETiK2.oUDhRqHnWVhZhnqIMphkaJAgZtrv = BKtDYnpOvECwYtlRuYdkCmZhfvSS;
						return lgUlVkJOanakAASobNSgveexETiK2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class VAcmMolvhAHHTvCXsWDgbqbBuUXR : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int sEGGAsafTplsAKAvvMLgnjrIzgPZ;

					private ElementAssignmentConflictInfo OzrpsNLkqLaOuXvDcHHoSuGQZkpI;

					private int TqWZvCruYrEFvvoUUbnzQQHOwckV;

					private int KBoAtoJgDPKYcZMCriMNPydGblqSA;

					public int aTOJIUPNgEQkcQoApYCYArOlUAEA;

					private ActionElementMap HrOlpHTigHyndrJrRsMdpBjAZUXD;

					public ActionElementMap pUVGvboymeAGcbuytlXLmCztwfQr;

					private bool IuoEdhYPYpAHcONJeGmYHnirYOIUA;

					public bool eMGREDDxPnKESOeZtjgsxVMezmpJ;

					private int yOxAQKNLrVfNtaulnFEHobVncIHX;

					public int wZRTpTLscSglFNobfCWtrWZmWAIe;

					private JoystickMap WYDSzCovVSQAkrQKHOtMcjoTAPfjA;

					public JoystickMap vMPZYNdlNKxQbhGRLkwIlmzFnBoG;

					private bool jbBeegFUrLgRALCENPtEaGufILrUA;

					public bool oMATMyFcsSfUIvYeFaizCuLGzCZh;

					private bool ieOjkDdHPJehknhWrVVhxTBbHihM;

					public bool jClYaTPVhgUhOtCRgbjogdHYTWAr;

					private IList<Player> rouCPGysGdJaNKfDvqWOMoXTsgAF;

					private int lYSpmwjBBQMPtCbGWJooerZjTXdA;

					private IEnumerator<ElementAssignmentConflictInfo> mzLnNnLkvJWjsHkRqVQVyIHbqNdY;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return OzrpsNLkqLaOuXvDcHHoSuGQZkpI;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return OzrpsNLkqLaOuXvDcHHoSuGQZkpI;
						}
					}

					[DebuggerHidden]
					public VAcmMolvhAHHTvCXsWDgbqbBuUXR(int P_0)
					{
						sEGGAsafTplsAKAvvMLgnjrIzgPZ = P_0;
						TqWZvCruYrEFvvoUUbnzQQHOwckV = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = sEGGAsafTplsAKAvvMLgnjrIzgPZ;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								tLKpDKyFMBIQiHFWepTFCmjfoObqc();
							}
						}
						rouCPGysGdJaNKfDvqWOMoXTsgAF = null;
						mzLnNnLkvJWjsHkRqVQVyIHbqNdY = null;
						sEGGAsafTplsAKAvvMLgnjrIzgPZ = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = sEGGAsafTplsAKAvvMLgnjrIzgPZ;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								sEGGAsafTplsAKAvvMLgnjrIzgPZ = -3;
								goto IL_00e1;
							}
							sEGGAsafTplsAKAvvMLgnjrIzgPZ = -1;
							if (KBoAtoJgDPKYcZMCriMNPydGblqSA < 0 || HrOlpHTigHyndrJrRsMdpBjAZUXD == null)
							{
								return false;
							}
							rouCPGysGdJaNKfDvqWOMoXTsgAF = (IuoEdhYPYpAHcONJeGmYHnirYOIUA ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
							lYSpmwjBBQMPtCbGWJooerZjTXdA = 0;
							goto IL_010b;
							IL_010b:
							if (lYSpmwjBBQMPtCbGWJooerZjTXdA < rouCPGysGdJaNKfDvqWOMoXTsgAF.Count)
							{
								mzLnNnLkvJWjsHkRqVQVyIHbqNdY = rouCPGysGdJaNKfDvqWOMoXTsgAF[lYSpmwjBBQMPtCbGWJooerZjTXdA].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Joystick, yOxAQKNLrVfNtaulnFEHobVncIHX, WYDSzCovVSQAkrQKHOtMcjoTAPfjA, HrOlpHTigHyndrJrRsMdpBjAZUXD, jbBeegFUrLgRALCENPtEaGufILrUA, ieOjkDdHPJehknhWrVVhxTBbHihM).GetEnumerator();
								sEGGAsafTplsAKAvvMLgnjrIzgPZ = -3;
								goto IL_00e1;
							}
							return false;
							IL_00e1:
							if (mzLnNnLkvJWjsHkRqVQVyIHbqNdY.MoveNext())
							{
								ElementAssignmentConflictInfo current = mzLnNnLkvJWjsHkRqVQVyIHbqNdY.Current;
								OzrpsNLkqLaOuXvDcHHoSuGQZkpI = current;
								sEGGAsafTplsAKAvvMLgnjrIzgPZ = 1;
								return true;
							}
							tLKpDKyFMBIQiHFWepTFCmjfoObqc();
							mzLnNnLkvJWjsHkRqVQVyIHbqNdY = null;
							lYSpmwjBBQMPtCbGWJooerZjTXdA++;
							goto IL_010b;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void tLKpDKyFMBIQiHFWepTFCmjfoObqc()
					{
						sEGGAsafTplsAKAvvMLgnjrIzgPZ = -1;
						if (mzLnNnLkvJWjsHkRqVQVyIHbqNdY != null)
						{
							mzLnNnLkvJWjsHkRqVQVyIHbqNdY.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						VAcmMolvhAHHTvCXsWDgbqbBuUXR vAcmMolvhAHHTvCXsWDgbqbBuUXR;
						if (sEGGAsafTplsAKAvvMLgnjrIzgPZ == -2 && TqWZvCruYrEFvvoUUbnzQQHOwckV == Environment.CurrentManagedThreadId)
						{
							sEGGAsafTplsAKAvvMLgnjrIzgPZ = 0;
							vAcmMolvhAHHTvCXsWDgbqbBuUXR = this;
						}
						else
						{
							vAcmMolvhAHHTvCXsWDgbqbBuUXR = new VAcmMolvhAHHTvCXsWDgbqbBuUXR(0);
						}
						vAcmMolvhAHHTvCXsWDgbqbBuUXR.KBoAtoJgDPKYcZMCriMNPydGblqSA = aTOJIUPNgEQkcQoApYCYArOlUAEA;
						vAcmMolvhAHHTvCXsWDgbqbBuUXR.yOxAQKNLrVfNtaulnFEHobVncIHX = wZRTpTLscSglFNobfCWtrWZmWAIe;
						vAcmMolvhAHHTvCXsWDgbqbBuUXR.WYDSzCovVSQAkrQKHOtMcjoTAPfjA = vMPZYNdlNKxQbhGRLkwIlmzFnBoG;
						vAcmMolvhAHHTvCXsWDgbqbBuUXR.HrOlpHTigHyndrJrRsMdpBjAZUXD = pUVGvboymeAGcbuytlXLmCztwfQr;
						vAcmMolvhAHHTvCXsWDgbqbBuUXR.jbBeegFUrLgRALCENPtEaGufILrUA = oMATMyFcsSfUIvYeFaizCuLGzCZh;
						vAcmMolvhAHHTvCXsWDgbqbBuUXR.ieOjkDdHPJehknhWrVVhxTBbHihM = jClYaTPVhgUhOtCRgbjogdHYTWAr;
						vAcmMolvhAHHTvCXsWDgbqbBuUXR.IuoEdhYPYpAHcONJeGmYHnirYOIUA = eMGREDDxPnKESOeZtjgsxVMezmpJ;
						return vAcmMolvhAHHTvCXsWDgbqbBuUXR;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class khQrlZmclhcMjpOVTldFjTvbHmJJ : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int srSjElatYvXgIcHJVdVOVqWKJicj;

					private ElementAssignmentConflictInfo aRMeCAJYJAvCagBfXfYkFFMcjajec;

					private int yhfxoagUlYKxjYcsdEukmQcPgYfAA;

					private ElementAssignmentConflictCheck CEwEplcCGguLflqoLwTiLxZIEQggA;

					public ElementAssignmentConflictCheck olOJHpqfYvsNhmtWUprgOckJdvKO;

					private bool izvCeqlNOwAyfEvIqLThmiqFDGKq;

					public bool IYNlqsumwEUkyNdgJGLPIHAwBmCV;

					private bool runDNHUAoUooPKMLFhQWZxOIkcjf;

					public bool ufIaJseXvjigkVxviHxdPXswZPaIA;

					private bool fSqOhiMlsbuqpMPtJiAGTnlJEmdn;

					public bool FpywyyVYGmCJKWPYXbLgEiwXwHGfA;

					private IList<Player> UBCHTSdJrCZkJeQasvWWVbkuZrEK;

					private int ZWnTptELaFAfZwjPXmQtksGCGZJT;

					private IEnumerator<ElementAssignmentConflictInfo> WUJHvVZbRBESrpaFqfNThsnxvPicA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aRMeCAJYJAvCagBfXfYkFFMcjajec;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aRMeCAJYJAvCagBfXfYkFFMcjajec;
						}
					}

					[DebuggerHidden]
					public khQrlZmclhcMjpOVTldFjTvbHmJJ(int P_0)
					{
						srSjElatYvXgIcHJVdVOVqWKJicj = P_0;
						yhfxoagUlYKxjYcsdEukmQcPgYfAA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = srSjElatYvXgIcHJVdVOVqWKJicj;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								fFREvzlfwpfzVLTkwBHnTBOXPtvv();
							}
						}
						UBCHTSdJrCZkJeQasvWWVbkuZrEK = null;
						WUJHvVZbRBESrpaFqfNThsnxvPicA = null;
						srSjElatYvXgIcHJVdVOVqWKJicj = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = srSjElatYvXgIcHJVdVOVqWKJicj;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								srSjElatYvXgIcHJVdVOVqWKJicj = -3;
								goto IL_00df;
							}
							srSjElatYvXgIcHJVdVOVqWKJicj = -1;
							if (CEwEplcCGguLflqoLwTiLxZIEQggA.playerId < 0 || CEwEplcCGguLflqoLwTiLxZIEQggA.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							UBCHTSdJrCZkJeQasvWWVbkuZrEK = (izvCeqlNOwAyfEvIqLThmiqFDGKq ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
							ZWnTptELaFAfZwjPXmQtksGCGZJT = 0;
							goto IL_0109;
							IL_0109:
							if (ZWnTptELaFAfZwjPXmQtksGCGZJT < UBCHTSdJrCZkJeQasvWWVbkuZrEK.Count)
							{
								WUJHvVZbRBESrpaFqfNThsnxvPicA = UBCHTSdJrCZkJeQasvWWVbkuZrEK[ZWnTptELaFAfZwjPXmQtksGCGZJT].controllers.conflictChecking.ElementAssignmentConflicts(CEwEplcCGguLflqoLwTiLxZIEQggA, runDNHUAoUooPKMLFhQWZxOIkcjf, fSqOhiMlsbuqpMPtJiAGTnlJEmdn).GetEnumerator();
								srSjElatYvXgIcHJVdVOVqWKJicj = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (WUJHvVZbRBESrpaFqfNThsnxvPicA.MoveNext())
							{
								ElementAssignmentConflictInfo current = WUJHvVZbRBESrpaFqfNThsnxvPicA.Current;
								aRMeCAJYJAvCagBfXfYkFFMcjajec = current;
								srSjElatYvXgIcHJVdVOVqWKJicj = 1;
								return true;
							}
							fFREvzlfwpfzVLTkwBHnTBOXPtvv();
							WUJHvVZbRBESrpaFqfNThsnxvPicA = null;
							ZWnTptELaFAfZwjPXmQtksGCGZJT++;
							goto IL_0109;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void fFREvzlfwpfzVLTkwBHnTBOXPtvv()
					{
						srSjElatYvXgIcHJVdVOVqWKJicj = -1;
						if (WUJHvVZbRBESrpaFqfNThsnxvPicA != null)
						{
							WUJHvVZbRBESrpaFqfNThsnxvPicA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						khQrlZmclhcMjpOVTldFjTvbHmJJ khQrlZmclhcMjpOVTldFjTvbHmJJ2;
						if (srSjElatYvXgIcHJVdVOVqWKJicj == -2 && yhfxoagUlYKxjYcsdEukmQcPgYfAA == Environment.CurrentManagedThreadId)
						{
							srSjElatYvXgIcHJVdVOVqWKJicj = 0;
							khQrlZmclhcMjpOVTldFjTvbHmJJ2 = this;
						}
						else
						{
							khQrlZmclhcMjpOVTldFjTvbHmJJ2 = new khQrlZmclhcMjpOVTldFjTvbHmJJ(0);
						}
						khQrlZmclhcMjpOVTldFjTvbHmJJ2.CEwEplcCGguLflqoLwTiLxZIEQggA = olOJHpqfYvsNhmtWUprgOckJdvKO;
						khQrlZmclhcMjpOVTldFjTvbHmJJ2.runDNHUAoUooPKMLFhQWZxOIkcjf = ufIaJseXvjigkVxviHxdPXswZPaIA;
						khQrlZmclhcMjpOVTldFjTvbHmJJ2.fSqOhiMlsbuqpMPtJiAGTnlJEmdn = FpywyyVYGmCJKWPYXbLgEiwXwHGfA;
						khQrlZmclhcMjpOVTldFjTvbHmJJ2.izvCeqlNOwAyfEvIqLThmiqFDGKq = IYNlqsumwEUkyNdgJGLPIHAwBmCV;
						return khQrlZmclhcMjpOVTldFjTvbHmJJ2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class tKGgrwTzBjWgaBEkUfNMItvLimOO : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int WwMFUOHixaCgwJGiZHEcHnvguvznB;

					private ElementAssignmentConflictInfo FFhgUFERtXLtyvwcBAEFdMEjbAkqA;

					private int pxUSeCgIRcRHEUyORtgJCqXczMxL;

					private int WvhzoubbGriOwdWLMkTRlqUVrQqL;

					public int qHHJIFdMrFZKxOVzgPrONYNjEdsP;

					private ActionElementMap CFToYHtXqDSfwEQPmGZanIJmIWRQ;

					public ActionElementMap HyhcgSnsbjevHtSvCPUaMQMcPMjc;

					private bool xSudnTesaiFTyAfbFCCMtebILXTFA;

					public bool ZWLigYNPlohsNgKWjnqYcKwmAEGoA;

					private KeyboardMap NRlTKFfLUfKSKNIkChvqabHcLjhk;

					public KeyboardMap jjMFxDlvJiTkWHOdZYSGKUGahuRL;

					private bool envOonuaHZBTTwgtewyIcBSecKdIA;

					public bool ojPuiOsIduuHndRRgDArEbgQOEqu;

					private bool DELsthDtMMSaDMOQpiBpBzQdQJkA;

					public bool qHuEotIbGeQAgOqFrithFFubhBuub;

					private IList<Player> sulRUQVNWMNrlIqcCrAcmLMQIpgh;

					private int QnhhuuePBFRkESwzakhyWJgDHIVY;

					private IEnumerator<ElementAssignmentConflictInfo> bIqxaitSjTdlayGGBxfaQhhFXYcF;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return FFhgUFERtXLtyvwcBAEFdMEjbAkqA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return FFhgUFERtXLtyvwcBAEFdMEjbAkqA;
						}
					}

					[DebuggerHidden]
					public tKGgrwTzBjWgaBEkUfNMItvLimOO(int P_0)
					{
						WwMFUOHixaCgwJGiZHEcHnvguvznB = P_0;
						pxUSeCgIRcRHEUyORtgJCqXczMxL = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int wwMFUOHixaCgwJGiZHEcHnvguvznB = WwMFUOHixaCgwJGiZHEcHnvguvznB;
						if (wwMFUOHixaCgwJGiZHEcHnvguvznB == -3 || wwMFUOHixaCgwJGiZHEcHnvguvznB == 1)
						{
							try
							{
							}
							finally
							{
								BqqNwgqluSsLXJLndsaTeDsjepzAA();
							}
						}
						sulRUQVNWMNrlIqcCrAcmLMQIpgh = null;
						bIqxaitSjTdlayGGBxfaQhhFXYcF = null;
						WwMFUOHixaCgwJGiZHEcHnvguvznB = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int wwMFUOHixaCgwJGiZHEcHnvguvznB = WwMFUOHixaCgwJGiZHEcHnvguvznB;
							if (wwMFUOHixaCgwJGiZHEcHnvguvznB != 0)
							{
								if (wwMFUOHixaCgwJGiZHEcHnvguvznB != 1)
								{
									return false;
								}
								WwMFUOHixaCgwJGiZHEcHnvguvznB = -3;
								goto IL_00dc;
							}
							WwMFUOHixaCgwJGiZHEcHnvguvznB = -1;
							if (WvhzoubbGriOwdWLMkTRlqUVrQqL < 0 || CFToYHtXqDSfwEQPmGZanIJmIWRQ == null)
							{
								return false;
							}
							sulRUQVNWMNrlIqcCrAcmLMQIpgh = (xSudnTesaiFTyAfbFCCMtebILXTFA ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
							QnhhuuePBFRkESwzakhyWJgDHIVY = 0;
							goto IL_0106;
							IL_0106:
							if (QnhhuuePBFRkESwzakhyWJgDHIVY < sulRUQVNWMNrlIqcCrAcmLMQIpgh.Count)
							{
								bIqxaitSjTdlayGGBxfaQhhFXYcF = sulRUQVNWMNrlIqcCrAcmLMQIpgh[QnhhuuePBFRkESwzakhyWJgDHIVY].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Keyboard, 0, NRlTKFfLUfKSKNIkChvqabHcLjhk, CFToYHtXqDSfwEQPmGZanIJmIWRQ, envOonuaHZBTTwgtewyIcBSecKdIA, DELsthDtMMSaDMOQpiBpBzQdQJkA).GetEnumerator();
								WwMFUOHixaCgwJGiZHEcHnvguvznB = -3;
								goto IL_00dc;
							}
							return false;
							IL_00dc:
							if (bIqxaitSjTdlayGGBxfaQhhFXYcF.MoveNext())
							{
								ElementAssignmentConflictInfo current = bIqxaitSjTdlayGGBxfaQhhFXYcF.Current;
								FFhgUFERtXLtyvwcBAEFdMEjbAkqA = current;
								WwMFUOHixaCgwJGiZHEcHnvguvznB = 1;
								return true;
							}
							BqqNwgqluSsLXJLndsaTeDsjepzAA();
							bIqxaitSjTdlayGGBxfaQhhFXYcF = null;
							QnhhuuePBFRkESwzakhyWJgDHIVY++;
							goto IL_0106;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void BqqNwgqluSsLXJLndsaTeDsjepzAA()
					{
						WwMFUOHixaCgwJGiZHEcHnvguvznB = -1;
						if (bIqxaitSjTdlayGGBxfaQhhFXYcF != null)
						{
							bIqxaitSjTdlayGGBxfaQhhFXYcF.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						tKGgrwTzBjWgaBEkUfNMItvLimOO tKGgrwTzBjWgaBEkUfNMItvLimOO2;
						if (WwMFUOHixaCgwJGiZHEcHnvguvznB == -2 && pxUSeCgIRcRHEUyORtgJCqXczMxL == Environment.CurrentManagedThreadId)
						{
							WwMFUOHixaCgwJGiZHEcHnvguvznB = 0;
							tKGgrwTzBjWgaBEkUfNMItvLimOO2 = this;
						}
						else
						{
							tKGgrwTzBjWgaBEkUfNMItvLimOO2 = new tKGgrwTzBjWgaBEkUfNMItvLimOO(0);
						}
						tKGgrwTzBjWgaBEkUfNMItvLimOO2.WvhzoubbGriOwdWLMkTRlqUVrQqL = qHHJIFdMrFZKxOVzgPrONYNjEdsP;
						tKGgrwTzBjWgaBEkUfNMItvLimOO2.NRlTKFfLUfKSKNIkChvqabHcLjhk = jjMFxDlvJiTkWHOdZYSGKUGahuRL;
						tKGgrwTzBjWgaBEkUfNMItvLimOO2.CFToYHtXqDSfwEQPmGZanIJmIWRQ = HyhcgSnsbjevHtSvCPUaMQMcPMjc;
						tKGgrwTzBjWgaBEkUfNMItvLimOO2.envOonuaHZBTTwgtewyIcBSecKdIA = ojPuiOsIduuHndRRgDArEbgQOEqu;
						tKGgrwTzBjWgaBEkUfNMItvLimOO2.DELsthDtMMSaDMOQpiBpBzQdQJkA = qHuEotIbGeQAgOqFrithFFubhBuub;
						tKGgrwTzBjWgaBEkUfNMItvLimOO2.xSudnTesaiFTyAfbFCCMtebILXTFA = ZWLigYNPlohsNgKWjnqYcKwmAEGoA;
						return tKGgrwTzBjWgaBEkUfNMItvLimOO2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class IdxxMSmhtULNYqzFCMKfrzJEBdJk : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int YBtAqZDFXyaWxiycMCbHxkDTtqxp;

					private ElementAssignmentConflictInfo GGVnnXfbbHYvfoKFlAiZfzRGktNs;

					private int qTyoRClvDUVdgIlCRnOgLAtvBOrD;

					private ElementAssignmentConflictCheck vojEqmldCasbcAybLYliiEvyFrHF;

					public ElementAssignmentConflictCheck HxwzFgotkrbAvWoiGNjMdJojCwjW;

					private bool GOdZhcUqAsbxHOWJmmRkIhVdMfSS;

					public bool DPnppEPzADegPYkUmCaGvDFUHwrL;

					private bool PmjDzTUjqprgEHVBRcTfNroPDmegA;

					public bool PFDPduyfgUqNwrmqXgiijmWqKYqAb;

					private bool GcMRdedkPYRtnkgpVjGHvxGbjnfq;

					public bool tsEAPjZrtYrAquAgHNgdQDweaatM;

					private IList<Player> dmchWmDpcdlqSUhmCxRiClEZUOoH;

					private int AdaanikaofNiHJiTlIznvwObLCtSA;

					private IEnumerator<ElementAssignmentConflictInfo> ejIOnzLITjAidiTRlFIyZktYxAGI;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return GGVnnXfbbHYvfoKFlAiZfzRGktNs;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return GGVnnXfbbHYvfoKFlAiZfzRGktNs;
						}
					}

					[DebuggerHidden]
					public IdxxMSmhtULNYqzFCMKfrzJEBdJk(int P_0)
					{
						YBtAqZDFXyaWxiycMCbHxkDTtqxp = P_0;
						qTyoRClvDUVdgIlCRnOgLAtvBOrD = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int yBtAqZDFXyaWxiycMCbHxkDTtqxp = YBtAqZDFXyaWxiycMCbHxkDTtqxp;
						if (yBtAqZDFXyaWxiycMCbHxkDTtqxp == -3 || yBtAqZDFXyaWxiycMCbHxkDTtqxp == 1)
						{
							try
							{
							}
							finally
							{
								VBrPGsXkFPXsKHzxtVNlRXOlXPUc();
							}
						}
						dmchWmDpcdlqSUhmCxRiClEZUOoH = null;
						ejIOnzLITjAidiTRlFIyZktYxAGI = null;
						YBtAqZDFXyaWxiycMCbHxkDTtqxp = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int yBtAqZDFXyaWxiycMCbHxkDTtqxp = YBtAqZDFXyaWxiycMCbHxkDTtqxp;
							if (yBtAqZDFXyaWxiycMCbHxkDTtqxp != 0)
							{
								if (yBtAqZDFXyaWxiycMCbHxkDTtqxp != 1)
								{
									return false;
								}
								YBtAqZDFXyaWxiycMCbHxkDTtqxp = -3;
								goto IL_00df;
							}
							YBtAqZDFXyaWxiycMCbHxkDTtqxp = -1;
							if (vojEqmldCasbcAybLYliiEvyFrHF.playerId < 0 || vojEqmldCasbcAybLYliiEvyFrHF.elementAssignmentType != ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							dmchWmDpcdlqSUhmCxRiClEZUOoH = (GOdZhcUqAsbxHOWJmmRkIhVdMfSS ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
							AdaanikaofNiHJiTlIznvwObLCtSA = 0;
							goto IL_0109;
							IL_0109:
							if (AdaanikaofNiHJiTlIznvwObLCtSA < dmchWmDpcdlqSUhmCxRiClEZUOoH.Count)
							{
								ejIOnzLITjAidiTRlFIyZktYxAGI = dmchWmDpcdlqSUhmCxRiClEZUOoH[AdaanikaofNiHJiTlIznvwObLCtSA].controllers.conflictChecking.ElementAssignmentConflicts(vojEqmldCasbcAybLYliiEvyFrHF, PmjDzTUjqprgEHVBRcTfNroPDmegA, GcMRdedkPYRtnkgpVjGHvxGbjnfq).GetEnumerator();
								YBtAqZDFXyaWxiycMCbHxkDTtqxp = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (ejIOnzLITjAidiTRlFIyZktYxAGI.MoveNext())
							{
								ElementAssignmentConflictInfo current = ejIOnzLITjAidiTRlFIyZktYxAGI.Current;
								GGVnnXfbbHYvfoKFlAiZfzRGktNs = current;
								YBtAqZDFXyaWxiycMCbHxkDTtqxp = 1;
								return true;
							}
							VBrPGsXkFPXsKHzxtVNlRXOlXPUc();
							ejIOnzLITjAidiTRlFIyZktYxAGI = null;
							AdaanikaofNiHJiTlIznvwObLCtSA++;
							goto IL_0109;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void VBrPGsXkFPXsKHzxtVNlRXOlXPUc()
					{
						YBtAqZDFXyaWxiycMCbHxkDTtqxp = -1;
						if (ejIOnzLITjAidiTRlFIyZktYxAGI != null)
						{
							ejIOnzLITjAidiTRlFIyZktYxAGI.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						IdxxMSmhtULNYqzFCMKfrzJEBdJk idxxMSmhtULNYqzFCMKfrzJEBdJk;
						if (YBtAqZDFXyaWxiycMCbHxkDTtqxp == -2 && qTyoRClvDUVdgIlCRnOgLAtvBOrD == Environment.CurrentManagedThreadId)
						{
							YBtAqZDFXyaWxiycMCbHxkDTtqxp = 0;
							idxxMSmhtULNYqzFCMKfrzJEBdJk = this;
						}
						else
						{
							idxxMSmhtULNYqzFCMKfrzJEBdJk = new IdxxMSmhtULNYqzFCMKfrzJEBdJk(0);
						}
						idxxMSmhtULNYqzFCMKfrzJEBdJk.vojEqmldCasbcAybLYliiEvyFrHF = HxwzFgotkrbAvWoiGNjMdJojCwjW;
						idxxMSmhtULNYqzFCMKfrzJEBdJk.PmjDzTUjqprgEHVBRcTfNroPDmegA = PFDPduyfgUqNwrmqXgiijmWqKYqAb;
						idxxMSmhtULNYqzFCMKfrzJEBdJk.GcMRdedkPYRtnkgpVjGHvxGbjnfq = tsEAPjZrtYrAquAgHNgdQDweaatM;
						idxxMSmhtULNYqzFCMKfrzJEBdJk.GOdZhcUqAsbxHOWJmmRkIhVdMfSS = DPnppEPzADegPYkUmCaGvDFUHwrL;
						return idxxMSmhtULNYqzFCMKfrzJEBdJk;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class NxdHKAZwghFjApJbNqlLBtOnwnan : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int ygNCtNGGyxAXyiAydjpbKHzOHgliA;

					private ElementAssignmentConflictInfo XVGxHSgpNxskbgHrBxVSJcerMasX;

					private int HeBFjTIBCijhLoUzVKZPpJHfSGgv;

					private int xFsOWHCidElyMItiyUhCRqaKffQC;

					public int TLRRgBOjdPOXlnDYsfIwdrtQxHBh;

					private ActionElementMap yuybmGZDONAbBAJTgsbMpLLerniF;

					public ActionElementMap gQSwXpakQluRflOQmlIsqWDqHhKB;

					private bool ABFcGqZYmpOMWEAaUOQHnqllHzbO;

					public bool SSsoGWMJmudolEWnymMCPrCrkPTIA;

					private MouseMap HuCDSkXlvadJoeBEsOziFCXymMhK;

					public MouseMap gkcmRYasvoDbStDdHVZRGCXTASlaA;

					private bool LwcLCImiOnmzrGOyDvWEAnQizStj;

					public bool JbwwsOfIjFiEcbjGocckeEyjVDosb;

					private bool EtdKVUDTCGNdTemzWbhSuBGqQqKd;

					public bool rmGJvLcdBJWgtEmIUgtoIspAGIobb;

					private IList<Player> PBUQMhnboNNPgickEbuLyVRArTNL;

					private int nATcISwYNgABadZMShLBkLOfvQyb;

					private IEnumerator<ElementAssignmentConflictInfo> uRlmBMsyrdwZCyaWGboVVDjVuRVG;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return XVGxHSgpNxskbgHrBxVSJcerMasX;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return XVGxHSgpNxskbgHrBxVSJcerMasX;
						}
					}

					[DebuggerHidden]
					public NxdHKAZwghFjApJbNqlLBtOnwnan(int P_0)
					{
						ygNCtNGGyxAXyiAydjpbKHzOHgliA = P_0;
						HeBFjTIBCijhLoUzVKZPpJHfSGgv = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = ygNCtNGGyxAXyiAydjpbKHzOHgliA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								gBEyuxHeByxwdVAaAMQLFNLehdBaA();
							}
						}
						PBUQMhnboNNPgickEbuLyVRArTNL = null;
						uRlmBMsyrdwZCyaWGboVVDjVuRVG = null;
						ygNCtNGGyxAXyiAydjpbKHzOHgliA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = ygNCtNGGyxAXyiAydjpbKHzOHgliA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								ygNCtNGGyxAXyiAydjpbKHzOHgliA = -3;
								goto IL_00dc;
							}
							ygNCtNGGyxAXyiAydjpbKHzOHgliA = -1;
							if (xFsOWHCidElyMItiyUhCRqaKffQC < 0 || yuybmGZDONAbBAJTgsbMpLLerniF == null)
							{
								return false;
							}
							PBUQMhnboNNPgickEbuLyVRArTNL = (ABFcGqZYmpOMWEAaUOQHnqllHzbO ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
							nATcISwYNgABadZMShLBkLOfvQyb = 0;
							goto IL_0106;
							IL_0106:
							if (nATcISwYNgABadZMShLBkLOfvQyb < PBUQMhnboNNPgickEbuLyVRArTNL.Count)
							{
								uRlmBMsyrdwZCyaWGboVVDjVuRVG = PBUQMhnboNNPgickEbuLyVRArTNL[nATcISwYNgABadZMShLBkLOfvQyb].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Mouse, 0, HuCDSkXlvadJoeBEsOziFCXymMhK, yuybmGZDONAbBAJTgsbMpLLerniF, LwcLCImiOnmzrGOyDvWEAnQizStj, EtdKVUDTCGNdTemzWbhSuBGqQqKd).GetEnumerator();
								ygNCtNGGyxAXyiAydjpbKHzOHgliA = -3;
								goto IL_00dc;
							}
							return false;
							IL_00dc:
							if (uRlmBMsyrdwZCyaWGboVVDjVuRVG.MoveNext())
							{
								ElementAssignmentConflictInfo current = uRlmBMsyrdwZCyaWGboVVDjVuRVG.Current;
								XVGxHSgpNxskbgHrBxVSJcerMasX = current;
								ygNCtNGGyxAXyiAydjpbKHzOHgliA = 1;
								return true;
							}
							gBEyuxHeByxwdVAaAMQLFNLehdBaA();
							uRlmBMsyrdwZCyaWGboVVDjVuRVG = null;
							nATcISwYNgABadZMShLBkLOfvQyb++;
							goto IL_0106;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void gBEyuxHeByxwdVAaAMQLFNLehdBaA()
					{
						ygNCtNGGyxAXyiAydjpbKHzOHgliA = -1;
						if (uRlmBMsyrdwZCyaWGboVVDjVuRVG != null)
						{
							uRlmBMsyrdwZCyaWGboVVDjVuRVG.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						NxdHKAZwghFjApJbNqlLBtOnwnan nxdHKAZwghFjApJbNqlLBtOnwnan;
						if (ygNCtNGGyxAXyiAydjpbKHzOHgliA == -2 && HeBFjTIBCijhLoUzVKZPpJHfSGgv == Environment.CurrentManagedThreadId)
						{
							ygNCtNGGyxAXyiAydjpbKHzOHgliA = 0;
							nxdHKAZwghFjApJbNqlLBtOnwnan = this;
						}
						else
						{
							nxdHKAZwghFjApJbNqlLBtOnwnan = new NxdHKAZwghFjApJbNqlLBtOnwnan(0);
						}
						nxdHKAZwghFjApJbNqlLBtOnwnan.xFsOWHCidElyMItiyUhCRqaKffQC = TLRRgBOjdPOXlnDYsfIwdrtQxHBh;
						nxdHKAZwghFjApJbNqlLBtOnwnan.HuCDSkXlvadJoeBEsOziFCXymMhK = gkcmRYasvoDbStDdHVZRGCXTASlaA;
						nxdHKAZwghFjApJbNqlLBtOnwnan.yuybmGZDONAbBAJTgsbMpLLerniF = gQSwXpakQluRflOQmlIsqWDqHhKB;
						nxdHKAZwghFjApJbNqlLBtOnwnan.LwcLCImiOnmzrGOyDvWEAnQizStj = JbwwsOfIjFiEcbjGocckeEyjVDosb;
						nxdHKAZwghFjApJbNqlLBtOnwnan.EtdKVUDTCGNdTemzWbhSuBGqQqKd = rmGJvLcdBJWgtEmIUgtoIspAGIobb;
						nxdHKAZwghFjApJbNqlLBtOnwnan.ABFcGqZYmpOMWEAaUOQHnqllHzbO = SSsoGWMJmudolEWnymMCPrCrkPTIA;
						return nxdHKAZwghFjApJbNqlLBtOnwnan;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class ckJMXVjjSPlJPIfhXDQJgALCkgHLA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int eEjCXqJFpdhbISklcHoZvGSwFxhD;

					private ElementAssignmentConflictInfo yhqTerjJBSWzdyVzAMTWsgpPShmu;

					private int axRDluRREfkizACdBfTNqjLpUxBH;

					private ElementAssignmentConflictCheck JSHbpNEaohplxKmoKKkvyVhMuyUk;

					public ElementAssignmentConflictCheck MgcJZJpzoAJDRzQQRUGWySRqtvOr;

					private bool IenmbXYAKsHkfKDsUDCLlBSwDGRy;

					public bool iEqnQWIdiPRGBNwlTxzYUBCOhCwj;

					private bool UemNTQGCBgpaqHbxBbtnnrLkWIKG;

					public bool EQHUJxfcbCWpfKhxuzSsWiCgAFel;

					private bool yffLZYxfBpTSRSUOFcFIdTQbyHPF;

					public bool kaSDYPInOlHMWsbuQBULkmgjjehP;

					private IList<Player> lObKZDrCcYCZrdwIOUEfJUyaNgcR;

					private int SDjpiNQbeLZERbGcNAGumfRAEhac;

					private IEnumerator<ElementAssignmentConflictInfo> nkODmCIuDlMLuHkttkXfNEEUpzGJ;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return yhqTerjJBSWzdyVzAMTWsgpPShmu;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return yhqTerjJBSWzdyVzAMTWsgpPShmu;
						}
					}

					[DebuggerHidden]
					public ckJMXVjjSPlJPIfhXDQJgALCkgHLA(int P_0)
					{
						eEjCXqJFpdhbISklcHoZvGSwFxhD = P_0;
						axRDluRREfkizACdBfTNqjLpUxBH = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = eEjCXqJFpdhbISklcHoZvGSwFxhD;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								rKxEAzFjYVRpXwyZmZGmkbXODOTxA();
							}
						}
						lObKZDrCcYCZrdwIOUEfJUyaNgcR = null;
						nkODmCIuDlMLuHkttkXfNEEUpzGJ = null;
						eEjCXqJFpdhbISklcHoZvGSwFxhD = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = eEjCXqJFpdhbISklcHoZvGSwFxhD;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								eEjCXqJFpdhbISklcHoZvGSwFxhD = -3;
								goto IL_00df;
							}
							eEjCXqJFpdhbISklcHoZvGSwFxhD = -1;
							if (JSHbpNEaohplxKmoKKkvyVhMuyUk.playerId < 0 || JSHbpNEaohplxKmoKKkvyVhMuyUk.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							lObKZDrCcYCZrdwIOUEfJUyaNgcR = (IenmbXYAKsHkfKDsUDCLlBSwDGRy ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
							SDjpiNQbeLZERbGcNAGumfRAEhac = 0;
							goto IL_0109;
							IL_0109:
							if (SDjpiNQbeLZERbGcNAGumfRAEhac < lObKZDrCcYCZrdwIOUEfJUyaNgcR.Count)
							{
								nkODmCIuDlMLuHkttkXfNEEUpzGJ = lObKZDrCcYCZrdwIOUEfJUyaNgcR[SDjpiNQbeLZERbGcNAGumfRAEhac].controllers.conflictChecking.ElementAssignmentConflicts(JSHbpNEaohplxKmoKKkvyVhMuyUk, UemNTQGCBgpaqHbxBbtnnrLkWIKG, yffLZYxfBpTSRSUOFcFIdTQbyHPF).GetEnumerator();
								eEjCXqJFpdhbISklcHoZvGSwFxhD = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (nkODmCIuDlMLuHkttkXfNEEUpzGJ.MoveNext())
							{
								ElementAssignmentConflictInfo current = nkODmCIuDlMLuHkttkXfNEEUpzGJ.Current;
								yhqTerjJBSWzdyVzAMTWsgpPShmu = current;
								eEjCXqJFpdhbISklcHoZvGSwFxhD = 1;
								return true;
							}
							rKxEAzFjYVRpXwyZmZGmkbXODOTxA();
							nkODmCIuDlMLuHkttkXfNEEUpzGJ = null;
							SDjpiNQbeLZERbGcNAGumfRAEhac++;
							goto IL_0109;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void rKxEAzFjYVRpXwyZmZGmkbXODOTxA()
					{
						eEjCXqJFpdhbISklcHoZvGSwFxhD = -1;
						if (nkODmCIuDlMLuHkttkXfNEEUpzGJ != null)
						{
							nkODmCIuDlMLuHkttkXfNEEUpzGJ.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						ckJMXVjjSPlJPIfhXDQJgALCkgHLA ckJMXVjjSPlJPIfhXDQJgALCkgHLA2;
						if (eEjCXqJFpdhbISklcHoZvGSwFxhD == -2 && axRDluRREfkizACdBfTNqjLpUxBH == Environment.CurrentManagedThreadId)
						{
							eEjCXqJFpdhbISklcHoZvGSwFxhD = 0;
							ckJMXVjjSPlJPIfhXDQJgALCkgHLA2 = this;
						}
						else
						{
							ckJMXVjjSPlJPIfhXDQJgALCkgHLA2 = new ckJMXVjjSPlJPIfhXDQJgALCkgHLA(0);
						}
						ckJMXVjjSPlJPIfhXDQJgALCkgHLA2.JSHbpNEaohplxKmoKKkvyVhMuyUk = MgcJZJpzoAJDRzQQRUGWySRqtvOr;
						ckJMXVjjSPlJPIfhXDQJgALCkgHLA2.UemNTQGCBgpaqHbxBbtnnrLkWIKG = EQHUJxfcbCWpfKhxuzSsWiCgAFel;
						ckJMXVjjSPlJPIfhXDQJgALCkgHLA2.yffLZYxfBpTSRSUOFcFIdTQbyHPF = kaSDYPInOlHMWsbuQBULkmgjjehP;
						ckJMXVjjSPlJPIfhXDQJgALCkgHLA2.IenmbXYAKsHkfKDsUDCLlBSwDGRy = iEqnQWIdiPRGBNwlTxzYUBCOhCwj;
						return ckJMXVjjSPlJPIfhXDQJgALCkgHLA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private static ConflictCheckingHelper kgMiycxzpxCqfexoYblGLEaPjSVs;

				internal static ConflictCheckingHelper iIkflfhSfDFhblHeFlvJBwvcpIPw => kgMiycxzpxCqfexoYblGLEaPjSVs ?? (kgMiycxzpxCqfexoYblGLEaPjSVs = new ConflictCheckingHelper());

				private ConflictCheckingHelper()
				{
				}

				public bool DoesAnyElementAssignmentConflict()
				{
					return DoesAnyElementAssignmentConflict(skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public bool DoesAnyElementAssignmentConflict(bool skipDisabledMaps)
				{
					return DoesAnyElementAssignmentConflict(skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public bool DoesAnyElementAssignmentConflict(bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return DoesAnyElementAssignmentConflict(skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public bool DoesAnyElementAssignmentConflict(bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return false;
					}
					IList<Player> list = (includeSystemPlayer ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						Player player = list[i];
						int num = (forceCheckAllCategories ? i : 0);
						IList<Joystick> joysticks = player.controllers.Joysticks;
						for (int j = 0; j < joysticks.Count; j++)
						{
							Joystick joystick = joysticks[j];
							IList<JoystickMap> maps = player.controllers.maps.GetMaps<JoystickMap>(joystick.id);
							if (maps == null)
							{
								continue;
							}
							int count2 = maps.Count;
							for (int k = num; k < count; k++)
							{
								Player player2 = list[k];
								for (int l = 0; l < count2; l++)
								{
									if (player2.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, joystick.id, maps[l], skipDisabledMaps, forceCheckAllCategories))
									{
										return true;
									}
								}
							}
						}
						IList<KeyboardMap> maps2 = player.controllers.maps.GetMaps<KeyboardMap>(0);
						for (int m = 0; m < maps2.Count; m++)
						{
							for (int n = num; n < count; n++)
							{
								if (list[n].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, maps2[m], skipDisabledMaps, forceCheckAllCategories))
								{
									return true;
								}
							}
						}
						IList<MouseMap> maps3 = player.controllers.maps.GetMaps<MouseMap>(0);
						for (int num2 = 0; num2 < maps3.Count; num2++)
						{
							for (int num3 = num; num3 < count; num3++)
							{
								if (list[num3].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, maps3[num2], skipDisabledMaps, forceCheckAllCategories))
								{
									return true;
								}
							}
						}
						IList<CustomController> customControllers = player.controllers.CustomControllers;
						for (int num4 = 0; num4 < customControllers.Count; num4++)
						{
							CustomController customController = customControllers[num4];
							IList<CustomControllerMap> maps4 = player.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
							if (maps4 == null)
							{
								continue;
							}
							int count3 = maps4.Count;
							for (int num5 = num; num5 < count; num5++)
							{
								Player player3 = list[num5];
								for (int num6 = 0; num6 < count3; num6++)
								{
									if (player3.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, customController.id, maps4[num6], skipDisabledMaps, forceCheckAllCategories))
									{
										return true;
									}
								}
							}
						}
					}
					return false;
				}

				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return DoesElementAssignmentConflict(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return DoesElementAssignmentConflict(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return DoesElementAssignmentConflict(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return false;
					}
					if (playerId < 0 || elementMap == null)
					{
						return false;
					}
					return controllerType switch
					{
						ControllerType.Joystick => bHLBInJlvebmNLOmAScENrnCyjjh(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => lCGCDpkcDahhRunFsbJcJclKvwWfA(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => aqmcfurENtEkzbaLwEEshXotMnjZ(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => UtpvqqVNcsKNMJIJlcqCHFgMxbDy(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						_ => throw new NotImplementedException(), 
					};
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck)
				{
					return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return false;
					}
					if (conflictCheck.playerId < 0)
					{
						return false;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return YAZiNqNHrquyZjFlnASIOaALQhZm(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return fuqlNkQAKfsPUpexbdqMCaCmtPtj(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return unPgEdwfLbpABkrYQXEihxRoakSk(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return qNXDQJtXPtmvadRgTFRZiMQpMmkMA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private bool bHLBInJlvebmNLOmAScENrnCyjjh(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return false;
					}
					IList<Player> list = (P_6 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
					}
					return false;
				}

				private bool YAZiNqNHrquyZjFlnASIOaALQhZm(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool lCGCDpkcDahhRunFsbJcJclKvwWfA(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					IList<Player> list = (P_5 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool fuqlNkQAKfsPUpexbdqMCaCmtPtj(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool aqmcfurENtEkzbaLwEEshXotMnjZ(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					IList<Player> list = (P_5 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool unPgEdwfLbpABkrYQXEihxRoakSk(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool UtpvqqVNcsKNMJIJlcqCHFgMxbDy(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return false;
					}
					IList<Player> list = (P_6 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
					}
					return false;
				}

				private bool qNXDQJtXPtmvadRgTFRZiMQpMmkMA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return ElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return ElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return ElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (playerId < 0 || elementMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return controllerType switch
					{
						ControllerType.Joystick => AuVJvKTHUdqtkcCUscQPuqQYqxGh(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => sfaFpXWFnOthDkCnRjUFikMKKEws(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => WzPmAcKbcubrcIYoowyjreOMirQfA(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => fMlJEpoRjybtqdrJVigsZgXcZauv(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (conflictCheck.playerId < 0)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return PGdLyKGXyaqTncsJelsrUbVPHkFc(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return ppobFvvLlfKHMLQIIdQbknVXCRTZ(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return utrVHtQpuaUajvMcZsiYFmiqXwR(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return skKpsBPChjeMIbynQpgkumNrHfOn(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				[IteratorStateMachine(typeof(VAcmMolvhAHHTvCXsWDgbqbBuUXR))]
				private IEnumerable<ElementAssignmentConflictInfo> AuVJvKTHUdqtkcCUscQPuqQYqxGh(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return new VAcmMolvhAHHTvCXsWDgbqbBuUXR(-2)
					{
						aTOJIUPNgEQkcQoApYCYArOlUAEA = P_0,
						wZRTpTLscSglFNobfCWtrWZmWAIe = P_1,
						vMPZYNdlNKxQbhGRLkwIlmzFnBoG = P_2,
						pUVGvboymeAGcbuytlXLmCztwfQr = P_3,
						oMATMyFcsSfUIvYeFaizCuLGzCZh = P_4,
						jClYaTPVhgUhOtCRgbjogdHYTWAr = P_5,
						eMGREDDxPnKESOeZtjgsxVMezmpJ = P_6
					};
				}

				[IteratorStateMachine(typeof(khQrlZmclhcMjpOVTldFjTvbHmJJ))]
				private IEnumerable<ElementAssignmentConflictInfo> PGdLyKGXyaqTncsJelsrUbVPHkFc(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new khQrlZmclhcMjpOVTldFjTvbHmJJ(-2)
					{
						olOJHpqfYvsNhmtWUprgOckJdvKO = P_0,
						ufIaJseXvjigkVxviHxdPXswZPaIA = P_1,
						FpywyyVYGmCJKWPYXbLgEiwXwHGfA = P_2,
						IYNlqsumwEUkyNdgJGLPIHAwBmCV = P_3
					};
				}

				[IteratorStateMachine(typeof(tKGgrwTzBjWgaBEkUfNMItvLimOO))]
				private IEnumerable<ElementAssignmentConflictInfo> sfaFpXWFnOthDkCnRjUFikMKKEws(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return new tKGgrwTzBjWgaBEkUfNMItvLimOO(-2)
					{
						qHHJIFdMrFZKxOVzgPrONYNjEdsP = P_0,
						jjMFxDlvJiTkWHOdZYSGKUGahuRL = P_1,
						HyhcgSnsbjevHtSvCPUaMQMcPMjc = P_2,
						ojPuiOsIduuHndRRgDArEbgQOEqu = P_3,
						qHuEotIbGeQAgOqFrithFFubhBuub = P_4,
						ZWLigYNPlohsNgKWjnqYcKwmAEGoA = P_5
					};
				}

				[IteratorStateMachine(typeof(IdxxMSmhtULNYqzFCMKfrzJEBdJk))]
				private IEnumerable<ElementAssignmentConflictInfo> ppobFvvLlfKHMLQIIdQbknVXCRTZ(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new IdxxMSmhtULNYqzFCMKfrzJEBdJk(-2)
					{
						HxwzFgotkrbAvWoiGNjMdJojCwjW = P_0,
						PFDPduyfgUqNwrmqXgiijmWqKYqAb = P_1,
						tsEAPjZrtYrAquAgHNgdQDweaatM = P_2,
						DPnppEPzADegPYkUmCaGvDFUHwrL = P_3
					};
				}

				[IteratorStateMachine(typeof(NxdHKAZwghFjApJbNqlLBtOnwnan))]
				private IEnumerable<ElementAssignmentConflictInfo> WzPmAcKbcubrcIYoowyjreOMirQfA(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return new NxdHKAZwghFjApJbNqlLBtOnwnan(-2)
					{
						TLRRgBOjdPOXlnDYsfIwdrtQxHBh = P_0,
						gkcmRYasvoDbStDdHVZRGCXTASlaA = P_1,
						gQSwXpakQluRflOQmlIsqWDqHhKB = P_2,
						JbwwsOfIjFiEcbjGocckeEyjVDosb = P_3,
						rmGJvLcdBJWgtEmIUgtoIspAGIobb = P_4,
						SSsoGWMJmudolEWnymMCPrCrkPTIA = P_5
					};
				}

				[IteratorStateMachine(typeof(ckJMXVjjSPlJPIfhXDQJgALCkgHLA))]
				private IEnumerable<ElementAssignmentConflictInfo> utrVHtQpuaUajvMcZsiYFmiqXwR(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new ckJMXVjjSPlJPIfhXDQJgALCkgHLA(-2)
					{
						MgcJZJpzoAJDRzQQRUGWySRqtvOr = P_0,
						EQHUJxfcbCWpfKhxuzSsWiCgAFel = P_1,
						kaSDYPInOlHMWsbuQBULkmgjjehP = P_2,
						iEqnQWIdiPRGBNwlTxzYUBCOhCwj = P_3
					};
				}

				[IteratorStateMachine(typeof(QUgNDkajfGbyOrRyXJdzzXYZpMEs))]
				private IEnumerable<ElementAssignmentConflictInfo> fMlJEpoRjybtqdrJVigsZgXcZauv(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return new QUgNDkajfGbyOrRyXJdzzXYZpMEs(-2)
					{
						YfWFqQDtkFTFqpxtiVPVoroKtctRA = P_0,
						dkNcMEWaehhjyiyHinKdjGWvvpZAA = P_1,
						NzLNVUmpKmAmgRHFSibrumsmsalb = P_2,
						dejbppiiXLbeSIiCKYGLCyYgyVjfb = P_3,
						YoIUwtWpZXLXkpBePhxYEmCZYulF = P_4,
						jnzDXFFBoYEAtoprSJCmrLTbaKGQA = P_5,
						EZEGFkaDGAnCUIyMLMkSZsfcbqnE = P_6
					};
				}

				[IteratorStateMachine(typeof(lgUlVkJOanakAASobNSgveexETiK))]
				private IEnumerable<ElementAssignmentConflictInfo> skKpsBPChjeMIbynQpgkumNrHfOn(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new lgUlVkJOanakAASobNSgveexETiK(-2)
					{
						reLhaihwfxSgicjVnrbOLRgKYEGs = P_0,
						OUhwxnjRrBeLvZLNUAMhTWnqTcxQ = P_1,
						AezejuKgQuKIBVHsKLxaLDJuuRwo = P_2,
						BKtDYnpOvECwYtlRuYdkCmZhfvSS = P_3
					};
				}

				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return RemoveElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return RemoveElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return RemoveElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					if (playerId < 0 || elementMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => XFreVPeTaPlxUZYpGYwgnxKLDSmsA(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => HGkcDFNzSQJwXmRPLSqXDbeAisRG(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => vaNdGXaKEuCMPuxscvSTwUIRRgAT(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => sNgdZZyZDIGciWEQPtxiqJsnlkio(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						_ => throw new NotImplementedException(), 
					};
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					if (conflictCheck.playerId < 0)
					{
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return guXQwCRFxMioMOHdPwOdDZaKEQAl(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return IjyifOsOWVcZpeTzEBZKdUhkwZIRA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return NeUBdtiWprDqhcWejTNASxbapxIJA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return HSVPmWOQnkJnQLcVDAKaLQtdMdav(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int XFreVPeTaPlxUZYpGYwgnxKLDSmsA(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int guXQwCRFxMioMOHdPwOdDZaKEQAl(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int HGkcDFNzSQJwXmRPLSqXDbeAisRG(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int IjyifOsOWVcZpeTzEBZKdUhkwZIRA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int vaNdGXaKEuCMPuxscvSTwUIRRgAT(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int NeUBdtiWprDqhcWejTNASxbapxIJA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int sNgdZZyZDIGciWEQPtxiqJsnlkio(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int HSVPmWOQnkJnQLcVDAKaLQtdMdav(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return DisableElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return DisableElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return DisableElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					if (playerId < 0 || elementMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => YYGfTWhtgtWTTIBCPiwxddadQuBOc(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => rrBOiPBRlnhjtzxijEDkcxKLeWDR(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => TXHLVeOyjsNphBiSIOPtwfjZKVvq(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => jmiVzjUiVeFmSeODgOlhZXioLQCe(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						_ => throw new NotImplementedException(), 
					};
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					if (conflictCheck.playerId < 0)
					{
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return oMbZSAwnEOlaKdZEbikFzEAGQjMl(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return NhtbrPShNbEpyayDtmsbOXeNeMIEb(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return rbUKlrbaIwFBuNUUSprPSinqIlvV(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return gkoOlBOPJNIaZMCwyoRwOFOVhrWJ(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int YYGfTWhtgtWTTIBCPiwxddadQuBOc(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int oMbZSAwnEOlaKdZEbikFzEAGQjMl(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int rrBOiPBRlnhjtzxijEDkcxKLeWDR(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int NhtbrPShNbEpyayDtmsbOXeNeMIEb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int TXHLVeOyjsNphBiSIOPtwfjZKVvq(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int rbUKlrbaIwFBuNUUSprPSinqIlvV(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int jmiVzjUiVeFmSeODgOlhZXioLQCe(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int gkoOlBOPJNIaZMCwyoRwOFOVhrWJ(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd : kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}
			}

			private static ControllerHelper JwIcXTBwrUAStECgQaSYGwNAQDtcb;

			public readonly PollingHelper polling = PollingHelper.EzrVIkbPYERbvnSfvkkSYaWcJufi;

			public readonly ConflictCheckingHelper conflictChecking = ConflictCheckingHelper.iIkflfhSfDFhblHeFlvJBwvcpIPw;

			internal static ControllerHelper pJDMGevuVCXoaIrbxyhEgKGtMfaJ => JwIcXTBwrUAStECgQaSYGwNAQDtcb ?? (JwIcXTBwrUAStECgQaSYGwNAQDtcb = new ControllerHelper());

			public int controllerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.ItbHdsEnpbUQIbZQSBtDSiMsGsVcA;
				}
			}

			public IList<Controller> Controllers
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<Controller>.EmptyReadOnlyIListT;
					}
					return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.ABIjtGLogkGPxCWFMrrynAMFtiuWA;
				}
			}

			public Mouse Mouse
			{
				get
				{
					if (!CheckInitialized())
					{
						return null;
					}
					return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.tAQmtNcIHgKfFSRzKoZtyWPabvG;
				}
			}

			public Keyboard Keyboard
			{
				get
				{
					if (!CheckInitialized())
					{
						return null;
					}
					return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.dqlVbgwiwbhfyZlhzyrqssSByBAe;
				}
			}

			[Obsolete("Deprecated: Use Controller.enabled instead. For example, to disable keyboard input: ReInput.controllers.Keyboard.enabled = false.")]
			public bool keyboardEnabled
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return Keyboard.enabled;
				}
				set
				{
					if (CheckInitialized())
					{
						Keyboard.enabled = value;
					}
				}
			}

			public int joystickCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.BZmSVymcSLcbcCvESSRKrvmAIKVl;
				}
			}

			public IList<Joystick> Joysticks
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<Joystick>.EmptyReadOnlyIListT;
					}
					return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.FmfxwfhlxDwfpqdOLrqFojAgTbO;
				}
			}

			public int customControllerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.egKAiAdlTOlVwxeoUjfWqxVINyPOA;
				}
			}

			public IList<CustomController> CustomControllers
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
					}
					return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.znuGFVHdakBIvysMReNIjKPHIQDfb;
				}
			}

			private ControllerHelper()
			{
			}

			public T GetController<T>(int controllerId) where T : Controller
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (controllerId < 0)
				{
					return null;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					return GetJoystick(controllerId) as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.dqlVbgwiwbhfyZlhzyrqssSByBAe as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return GetCustomController(controllerId) as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.tAQmtNcIHgKfFSRzKoZtyWPabvG as T;
				}
				throw new NotImplementedException();
			}

			public int GetControllerCount(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return 0;
				}
				return controllerType switch
				{
					ControllerType.Joystick => joystickCount, 
					ControllerType.Keyboard => 1, 
					ControllerType.Mouse => 1, 
					ControllerType.Custom => customControllerCount, 
					_ => throw new NotImplementedException(), 
				};
			}

			public Controller GetController(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.uNJmTUUZIgxCnlFgJshQMfTyrJwA(controllerType, controllerId);
			}

			public Controller GetController(ControllerIdentifier controllerIdentifier)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.syLDSFbeEMfdqJIKtznpocztFhSL(controllerIdentifier);
			}

			public Controller[] GetControllers(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<Controller>.array;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.XnicoCZswdsvulrRKokJFUxFQzNE(controllerType);
			}

			public string[] GetControllerNames(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.LaygbBCrxnytQbTiQrAtovmkuWOE(controllerType);
			}

			public bool IsControllerAssigned(ControllerType controllerType, Controller controller)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return kaDCuNAiSdnlkLeWRajALqrXMggab.QIfGzEiDjiGxMmFvPoJAAAzvssci(controller);
			}

			public bool IsControllerAssigned(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return kaDCuNAiSdnlkLeWRajALqrXMggab.zDjimEwflDtJPtQqASNBDvpDHLIE(controllerType, controllerId);
			}

			public bool IsControllerAssignedToPlayer(ControllerType controllerType, int controllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return kaDCuNAiSdnlkLeWRajALqrXMggab.ypEbKxHuJPQkiWbTKjvDaodiIhYjb(controllerType, controllerId, playerId);
			}

			public void RemoveControllerFromAllPlayers(Controller controller, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					kaDCuNAiSdnlkLeWRajALqrXMggab.nhpscBeegJodNXacoEnxDuynjoNd(controller, includeSystemPlayer);
				}
			}

			public void RemoveControllerFromAllPlayers(ControllerType controllerType, int controllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					kaDCuNAiSdnlkLeWRajALqrXMggab.lutpUXGsNMJeTujnyfhDByxViDwu(controllerType, controllerId, includeSystemPlayer);
				}
			}

			public Joystick GetJoystick(int joystickId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.CjsxcJaHUvrHCwxyCGmMBABZwBpQ(joystickId);
			}

			public Joystick[] GetJoysticks()
			{
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.IBDzmhaSXJnVJPpLuikCeToDAVSK();
			}

			public string[] GetJoystickNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.LMfmohWbTMQrPwWsHQMJrnPApdxK();
			}

			public bool IsJoystickAssigned(Joystick joystick)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return kaDCuNAiSdnlkLeWRajALqrXMggab.UovWLyVJDiwSCrrMgEHSZKbDKQmf(joystick);
			}

			public bool IsJoystickAssigned(int joystickId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return kaDCuNAiSdnlkLeWRajALqrXMggab.memWDtvYvxCIQAmPxnpNCLiRtuKC(joystickId);
			}

			public bool IsJoystickAssignedToPlayer(int joystickId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return kaDCuNAiSdnlkLeWRajALqrXMggab.bNBPichMwzXCqFSFGPKjgFlVjGsg(joystickId, playerId);
			}

			public void RemoveJoystickFromAllPlayers(Joystick joystick, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					kaDCuNAiSdnlkLeWRajALqrXMggab.qtQJmrQaFrKDwJooWjGrJhsXLsUcb(joystick, includeSystemPlayer);
				}
			}

			public void RemoveJoystickFromAllPlayers(int joystickId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					kaDCuNAiSdnlkLeWRajALqrXMggab.wVVzMWuIxJNmuekWilzNcVSReWgV(joystickId, includeSystemPlayer);
				}
			}

			public int GetUnityJoystickIdFromAnyButtonPress()
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				if (!TxCplICMnTZpPiXwadmbEnzHOQTt)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				UuAdhDUFwaxsJnWcRMzWfBViaGtN();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (bbBBrcEkOraOJcDTQuujlYEFiVof.InsGeegDisMCsANPCojTVbPJRDbeA(i, j))
						{
							return i + 1;
						}
					}
				}
				return -1;
			}

			public int GetUnityJoystickIdFromAnyButtonOrAxisPress(float axisThreshold, bool positiveAxesOnly)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				if (!TxCplICMnTZpPiXwadmbEnzHOQTt)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				UuAdhDUFwaxsJnWcRMzWfBViaGtN();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (bbBBrcEkOraOJcDTQuujlYEFiVof.InsGeegDisMCsANPCojTVbPJRDbeA(i, j))
						{
							return i + 1;
						}
					}
					for (int k = 0; k < 29; k++)
					{
						if (bbBBrcEkOraOJcDTQuujlYEFiVof.urZFmhFEAUaukcfxsiGkfhnGLbqgB(i, k, positiveAxesOnly))
						{
							return i + 1;
						}
					}
				}
				return -1;
			}

			public void SetUnityJoystickId(int joystickId, int unityJoystickId)
			{
				if (CheckInitialized())
				{
					if (!TxCplICMnTZpPiXwadmbEnzHOQTt)
					{
						Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					}
					else
					{
						NeEVntlckjaQuIKbzjPdCmfDUwQhc.SetUnityJoystickId(joystickId, unityJoystickId);
					}
				}
			}

			public bool SetUnityJoystickIdFromAnyButtonPress(int joystickId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				int unityJoystickIdFromAnyButtonPress = GetUnityJoystickIdFromAnyButtonPress();
				if (unityJoystickIdFromAnyButtonPress < 1)
				{
					return false;
				}
				SetUnityJoystickId(joystickId, unityJoystickIdFromAnyButtonPress);
				return true;
			}

			public bool SetUnityJoystickIdFromAnyButtonOrAxisPress(int joystickId, float axisThreshold, bool positiveAxesOnly)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				int unityJoystickIdFromAnyButtonOrAxisPress = GetUnityJoystickIdFromAnyButtonOrAxisPress(axisThreshold, positiveAxesOnly);
				if (unityJoystickIdFromAnyButtonOrAxisPress < 1)
				{
					return false;
				}
				SetUnityJoystickId(joystickId, unityJoystickIdFromAnyButtonOrAxisPress);
				return true;
			}

			public CustomController GetCustomController(int customControllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.gRvhnlvVEKDYyGVCrunkdbetDKMp(customControllerId);
			}

			public CustomController[] GetCustomControllers()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.array;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.bItKhJSUzmOgUDkGJbwQLfyQJrfB();
			}

			public string[] GetCustomControllerNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.OIavYVmyEpLAEalwERrNYQUNoDJG();
			}

			public bool IsCustomControllerAssigned(CustomController customController)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return kaDCuNAiSdnlkLeWRajALqrXMggab.OLLRahvBaFwuZvcbECekbLWwfFqDb(customController);
			}

			public bool IsCustomControllerAssigned(int customControllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return kaDCuNAiSdnlkLeWRajALqrXMggab.AAIZWXkliOLRCIJnFxInUpQVaqZU(customControllerId);
			}

			public bool IsCustomControllerAssignedToPlayer(int customControllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return kaDCuNAiSdnlkLeWRajALqrXMggab.QWDDAirDPMdpXFlHcFfmTUsyfLxWA(customControllerId, playerId);
			}

			public void RemoveCustomControllerFromAllPlayers(CustomController customController, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					kaDCuNAiSdnlkLeWRajALqrXMggab.XPCGPKsGtPInwCJfZjULIPZOCLsAA(customController, includeSystemPlayer);
				}
			}

			public void RemoveCustomControllerFromAllPlayers(int customControllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					kaDCuNAiSdnlkLeWRajALqrXMggab.ZCKVjTFDuZJDvKBXzFLuBLZVTMLAA(customControllerId, includeSystemPlayer);
				}
			}

			public CustomController CreateCustomController(int sourceControllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.wdCMlfofKsEmCXsYcusWVzNpaPIt(sourceControllerId);
			}

			public CustomController CreateCustomController(int sourceControllerId, string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				CustomController customController = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.wdCMlfofKsEmCXsYcusWVzNpaPIt(sourceControllerId);
				if (customController == null)
				{
					return null;
				}
				customController.tag = tag;
				return customController;
			}

			public bool DestroyCustomController(CustomController customController)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				if (customController == null)
				{
					return false;
				}
				RemoveCustomControllerFromAllPlayers(customController);
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.LakYHFUCriIVxTqiqUXhkfNRzbuR(customController);
			}

			public CustomController GetFirstCustomControllerWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.XlcbWdvLRxQzVRjbLForkREwCjzs(sourceId);
			}

			public CustomController GetFirstCustomControllerWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.ouytoEJugSLQZoGtQxSqYGhJIRgq(tag);
			}

			public IEnumerable<CustomController> CustomControllersWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.WExjsbarhUCRSFXLjkdZjtaIHMJgB(sourceId);
			}

			public IEnumerable<CustomController> CustomControllersWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.JdMGNSqlWFhAtHtZadIbtzDzqrTc(tag);
			}

			public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.ohGovAyBeejNnliFDGftyOIllKAM<TInterface>();
			}

			public Controller GetLastActiveController()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.wGgMEpxCjvhhuISjQawEtoYwZOXn();
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.SqKxZkLdhnAslJoioHFriMCAilEub(controllerType);
			}

			public T GetLastActiveController<T>() where T : Controller
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.wGgMEpxCjvhhuISjQawEtoYwZOXn<T>();
			}

			public ControllerType GetLastActiveControllerType()
			{
				if (!CheckInitialized())
				{
					return ControllerType.Keyboard;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.WgkKZFCcEbXZwUTaqLGrJjeUUNOy();
			}

			public bool SetLastActiveController(Controller controller)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.fOFmHFQepZixSMRoZacUitUNUVeS(controller);
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					jFidDAJTYMYSSrBGXbdjHWSiLLLfB.KlqDiCqRMsjPOFHPzPaoUXYEgFzR(callback);
				}
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					jFidDAJTYMYSSrBGXbdjHWSiLLLfB.sFDUYkeQsmiZlgqybsiaxnxFhzTB(callback, controllerType);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					jFidDAJTYMYSSrBGXbdjHWSiLLLfB.byZbRperAgUbuSkGxkDTkpuWvysM(callback);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					jFidDAJTYMYSSrBGXbdjHWSiLLLfB.mOtnInayTXPStQTAObRbJHdBzIWH(callback, controllerType);
				}
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (CheckInitialized())
				{
					jFidDAJTYMYSSrBGXbdjHWSiLLLfB.GVqFuFAaZEbVUkwCrwQWFmdlHgyiA();
				}
			}

			public bool GetAnyButton()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.fBfVxNGNJukEUkgYzBQyjamUBcak();
			}

			public bool GetAnyButton(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.GjGeRgBAZotrAMokpmedeHrVebXz(controllerType);
			}

			public bool GetAnyButtonDown()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.OooincwdLCWhvHqzvNOtcwfwKZDp();
			}

			public bool GetAnyButtonDown(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.ThLKFptFBYXTwbTJlSCkJdQApBYB(controllerType);
			}

			public bool GetAnyButtonUp()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.vfGiLBdzesiJYQgVbMWVwXcwjJMeA();
			}

			public bool GetAnyButtonUp(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.FObTxupDRKdfnXHQHHITzCimAbeiA(controllerType);
			}

			public bool GetAnyButtonChanged()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.cWemPSxkiVYmoLVDVotzscyAWcst();
			}

			public bool GetAnyButtonChanged(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.vSWUdGcGPCsovkdUTjxwVgIglOgV(controllerType);
			}

			public bool GetAnyButtonPrev()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.TuAodslkIZrjpSosMGkHBpWqcaBgA();
			}

			public bool GetAnyButtonPrev(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.IfoZxEkXLVzqvynTjzBVOWqUZLqA(controllerType);
			}

			public bool AutoAssignJoystick(Joystick joystick)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				if (joystick == null)
				{
					return false;
				}
				if (IsJoystickAssigned(joystick))
				{
					return true;
				}
				kaDCuNAiSdnlkLeWRajALqrXMggab.MpNXiOFGtskEljmyyNCvnUcnLqPM(joystick);
				return IsJoystickAssigned(joystick);
			}

			public void AutoAssignJoysticks()
			{
				if (CheckInitialized())
				{
					int num = joystickCount;
					IList<Joystick> joysticks = Joysticks;
					for (int i = 0; i < num; i++)
					{
						AutoAssignJoystick(joysticks[i]);
					}
				}
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class MappingHelper : CodeHelper
		{
			private static MappingHelper zvQhuIfousadSqLVYlgLzzVHXTEf;

			internal static MappingHelper afbXnOENdMgXBEamUofpoAxsXAOl => zvQhuIfousadSqLVYlgLzzVHXTEf ?? (zvQhuIfousadSqLVYlgLzzVHXTEf = new MappingHelper());

			public IList<InputMapCategory> MapCategories
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.FipgqCjMcjkrijvORJhmaWVzOZIgA;
				}
			}

			public IEnumerable<InputMapCategory> UserAssignableMapCategories
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.VhchGLDYgLpBjEvGYpWVEuVqLyZEA;
				}
			}

			public IList<InputCategory> ActionCategories
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ebzZGJKfJpNnscyRdhoBrwNEjaYL;
				}
			}

			public IEnumerable<InputCategory> UserAssignableActionCategories
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.fOHoEpKqqDEmCjmzSgOYowxYcdyJA;
				}
			}

			public IList<InputLayout> JoystickLayouts
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.LIJrEcSiTrDdQDDpsrujKIBwYXsgA;
				}
			}

			public IList<InputLayout> KeyboardLayouts
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.rGaQuyGlgbwHmSYClPgheHLQLOTj;
				}
			}

			public IList<InputLayout> MouseLayouts
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.iNexhKoDOWOSnTaVoYisPmtBBadgA;
				}
			}

			public IList<InputLayout> CustomControllerLayouts
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.hMnwghkSDlwrrbGKxMUJewpksrtW;
				}
			}

			public IList<InputAction> Actions
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
					}
					return QYXTlPbvvfyHDodSqaxHRoHhFdw.ESPPucyzYlkSLFFzkQAwnJrIKGUm;
				}
			}

			public IEnumerable<InputAction> UserAssignableActions
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
					}
					return CMuKNpKzoZWoovDXKkZgsiLlOCFy.pGqkstGwieuWePYeuoZnjhFNgpJU;
				}
			}

			private MappingHelper()
			{
			}

			public InputMapCategory GetMapCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetMapCategoryById(mapCategoryId);
			}

			public InputMapCategory GetMapCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetMapCategory(name);
			}

			public int GetMapCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetMapCategoryId(name);
			}

			public IEnumerable<InputMapCategory> MapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.TEvJvtXzUfCzEWBPTmZwhGxRogLP(tag);
			}

			public IEnumerable<InputMapCategory> UserAssignableMapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.UpQXFELjWgodNZTdCXTWeBrQbTfb(tag);
			}

			public bool IsMapCategoryUserAssignable(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return GetMapCategory(mapCategoryId)?.userAssignable ?? false;
			}

			public InputCategory GetActionCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetActionCategoryById(mapCategoryId);
			}

			public InputCategory GetActionCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetActionCategory(name);
			}

			public int GetActionCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetActionCategoryId(name);
			}

			public IEnumerable<InputCategory> ActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.iSRGfsuUescbOEJZQuAnYjnaYcrn(tag);
			}

			public IEnumerable<InputCategory> UserAssignableActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.MzaieyWaCFVNxxCagpPRtsQluncN(tag);
			}

			public bool IsActionCategoryUserAssignable(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return GetActionCategory(mapCategoryId)?.userAssignable ?? false;
			}

			public InputLayout GetLayout(ControllerType controllerType, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return controllerType switch
				{
					ControllerType.Joystick => CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetJoystickLayoutById(layoutId), 
					ControllerType.Keyboard => CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetKeyboardLayoutById(layoutId), 
					ControllerType.Mouse => CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetMouseLayoutById(layoutId), 
					ControllerType.Custom => CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetCustomControllerLayoutById(layoutId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public InputLayout GetLayout(ControllerType controllerType, string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return controllerType switch
				{
					ControllerType.Joystick => CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetJoystickLayout(name), 
					ControllerType.Keyboard => CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetKeyboardLayout(name), 
					ControllerType.Mouse => CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetMouseLayout(name), 
					ControllerType.Custom => CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetCustomControllerLayout(name), 
					_ => throw new NotImplementedException(), 
				};
			}

			public int GetLayoutId(ControllerType controllerType, string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return controllerType switch
				{
					ControllerType.Joystick => CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetJoystickLayoutId(name), 
					ControllerType.Keyboard => CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetKeyboardLayoutId(name), 
					ControllerType.Mouse => CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetMouseLayoutId(name), 
					ControllerType.Custom => CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetCustomControllerLayoutId(name), 
					_ => throw new NotImplementedException(), 
				};
			}

			public InputLayout GetJoystickLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetJoystickLayoutById(layoutId);
			}

			public InputLayout GetJoystickLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetJoystickLayout(name);
			}

			public int GetJoystickLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetJoystickLayoutId(name);
			}

			public InputLayout GetKeyboardLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetKeyboardLayoutById(layoutId);
			}

			public InputLayout GetKeyboardLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetKeyboardLayout(name);
			}

			public int GetKeyboardLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetKeyboardLayoutId(name);
			}

			public InputLayout GetMouseLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetMouseLayoutById(layoutId);
			}

			public InputLayout GetMouseLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetMouseLayout(name);
			}

			public int GetMouseLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetMouseLayoutId(name);
			}

			public InputLayout GetCustomControllerLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetCustomControllerLayoutById(layoutId);
			}

			public InputLayout GetCustomControllerLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetCustomControllerLayout(name);
			}

			public int GetCustomControllerLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetCustomControllerLayoutId(name);
			}

			public IList<InputLayout> MapLayouts(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
				}
				return controllerType switch
				{
					ControllerType.Joystick => JoystickLayouts, 
					ControllerType.Keyboard => KeyboardLayouts, 
					ControllerType.Mouse => MouseLayouts, 
					ControllerType.Custom => CustomControllerLayouts, 
					_ => throw new NotImplementedException(), 
				};
			}

			public InputAction GetAction(int actionId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetActionById(actionId);
			}

			public InputAction GetAction(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetAction(name);
			}

			public int GetActionId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetActionId(name);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ktgmVGxmbchNMSKNAUarccGYGegt(mapCategoryName, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.ktgmVGxmbchNMSKNAUarccGYGegt(mapCategoryName, sort);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.UCocuAHZHWdgDRYkXKlGOYHARrUqA(mapCategoryId, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.UCocuAHZHWdgDRYkXKlGOYHARrUqA(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> ActionsInCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.LRKfvogtfHJPYmZRxfaymrqqFwil(tag);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.psAJubqSNLDlpAkwbkaZWjbOHFKHb(mapCategoryId, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.psAJubqSNLDlpAkwbkaZWjbOHFKHb(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.KqYnWXGqujzZytgDvyaJqhzuBQXM(mapCategoryName, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.KqYnWXGqujzZytgDvyaJqhzuBQXM(mapCategoryName, sort);
			}

			public IList<InputBehavior> GetInputBehaviors(int playerId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.gGgZBtkCabfbYKBSTdKVeifYdvGMA(playerId);
			}

			public IList<InputBehavior> GetSystemPlayerInputBehaviors()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.gGgZBtkCabfbYKBSTdKVeifYdvGMA(9999999);
			}

			public InputBehavior GetInputBehavior(int playerId, int behaviorId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.aBmCPIjIQipDXvJzizuGNfyaNgx(playerId, behaviorId);
			}

			public InputBehavior GetInputBehavior(int playerId, string behaviorName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.fGrbcxUbqLPGHwfPLCPGEIILpayh(playerId, behaviorName);
			}

			public InputBehavior GetSystemPlayerInputBehavior(int behaviorId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return GetInputBehavior(9999999, behaviorId);
			}

			public InputBehavior GetSystemPlayerInputBehavior(string behaviorName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return GetInputBehavior(9999999, behaviorName);
			}

			public int GetInputBehaviorId(string behaviorName)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetInputBehaviorId(behaviorName);
			}

			internal InputBehavior cqaTNphNmPNUjIpPIjpBjsKDaJZiA(int P_0)
			{
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetInputBehaviorById(P_0);
			}

			internal InputBehavior xObtasOAaoZBwxenTXQNvUWzWIrk(string P_0)
			{
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetInputBehavior(P_0);
			}

			public ControllerMap GetControllerMap(int id)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				IList<Player> allPlayers = players.AllPlayers;
				for (int i = 0; i < allPlayers.Count; i++)
				{
					ControllerMap map = allPlayers[i].controllers.maps.GetMap(id);
					if (map != null)
					{
						return map;
					}
				}
				return null;
			}

			public ActionElementMap GetActionElementMap(int id)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				IList<Player> allPlayers = players.AllPlayers;
				for (int i = 0; i < allPlayers.Count; i++)
				{
					foreach (ControllerMap allMap in allPlayers[i].controllers.maps.GetAllMaps())
					{
						if (allMap != null)
						{
							ActionElementMap elementMap = allMap.GetElementMap(id);
							if (elementMap != null)
							{
								return elementMap;
							}
						}
					}
				}
				return null;
			}

			public ControllerMap GetControllerMapInstance(Controller controller, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				return controller.type switch
				{
					ControllerType.Joystick => GetJoystickMapInstance((Joystick)controller, mapCategoryId, layoutId), 
					ControllerType.Keyboard => GetKeyboardMapInstance(mapCategoryId, layoutId), 
					ControllerType.Mouse => GetMouseMapInstance(mapCategoryId, layoutId), 
					ControllerType.Custom => GetCustomControllerMapInstance((CustomController)controller, mapCategoryId, layoutId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public ControllerMap GetControllerMapInstance(Controller controller, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(controller.type, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetControllerMapInstance(controller, mapCategoryId, layoutId);
			}

			public ControllerMap GetControllerMapInstance(ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(controllerIdentifier.controllerType, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetControllerMapInstance(controllerIdentifier, mapCategoryId, layoutId);
			}

			public ControllerMap GetControllerMapInstance(ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				Controller controller = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.syLDSFbeEMfdqJIKtznpocztFhSL(controllerIdentifier);
				if (controller != null)
				{
					return GetControllerMapInstance(controller, mapCategoryId, layoutId);
				}
				return controllerIdentifier.controllerType switch
				{
					ControllerType.Joystick => GetJoystickMapInstance(controllerIdentifier, mapCategoryId, layoutId), 
					ControllerType.Custom => GetCustomControllerMapInstance(controllerIdentifier, mapCategoryId, layoutId), 
					ControllerType.Keyboard => GetKeyboardMapInstance(mapCategoryId, layoutId), 
					ControllerType.Mouse => GetMouseMapInstance(mapCategoryId, layoutId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public JoystickMap GetJoystickMapInstance(Joystick joystick, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (joystick == null)
				{
					return null;
				}
				JoystickMap joystickMap = CMuKNpKzoZWoovDXKkZgsiLlOCFy.TMFORpelFDlBYkjQHYfeVwSIdqrR(joystick, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					joystick.fsGAmSubJncncJCvyCKmjBAMAvWb(joystickMap);
				}
				return joystickMap;
			}

			public JoystickMap GetJoystickMapInstance(Joystick joystick, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetJoystickMapInstance(joystick, mapCategoryId, layoutId);
			}

			public JoystickMap GetJoystickMapInstance(Guid joystickTypeGuid, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (joystickTypeGuid == Guid.Empty)
				{
					return null;
				}
				InputSource inputSourceType = NeEVntlckjaQuIKbzjPdCmfDUwQhc.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = hiPSsPHyqmWsHPcaZFVmfgZvUkXl.RIkFDKKrXktVmWPxJRtKdWgLsLgN(joystickTypeGuid, inputSourceType);
				if (hardwareJoystickMap_InputManager == null)
				{
					Logger.LogError("No hardware map found.");
					return null;
				}
				JoystickMap joystickMap = CMuKNpKzoZWoovDXKkZgsiLlOCFy.hHeEJnNucycDHDNXPcMfzPtZQcAlA(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					Controller.aDLiogQIHBJlBPBxqAjcLNigUgpx(joystickMap, hardwareJoystickMap_InputManager.ToGameHardwareControllerMap());
				}
				return joystickMap;
			}

			public JoystickMap GetJoystickMapInstance(Guid joystickTypeGuid, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (joystickTypeGuid == Guid.Empty)
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetJoystickMapInstance(joystickTypeGuid, mapCategoryId, layoutId);
			}

			public JoystickMap GetJoystickMapInstance(ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (controllerIdentifier.controllerType != ControllerType.Joystick)
				{
					return null;
				}
				if (jFidDAJTYMYSSrBGXbdjHWSiLLLfB.syLDSFbeEMfdqJIKtznpocztFhSL(controllerIdentifier) is Joystick joystick)
				{
					return GetJoystickMapInstance(joystick, mapCategoryId, layoutId);
				}
				return GetJoystickMapInstance(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
			}

			public JoystickMap GetJoystickMapInstance(ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetJoystickMapInstance(controllerIdentifier, mapCategoryId, layoutId);
			}

			public KeyboardMap GetKeyboardMapInstance(int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				KeyboardMap keyboardMap = CMuKNpKzoZWoovDXKkZgsiLlOCFy.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
				if (keyboardMap != null)
				{
					controllers.Keyboard.fsGAmSubJncncJCvyCKmjBAMAvWb(keyboardMap);
				}
				return keyboardMap;
			}

			public KeyboardMap GetKeyboardMapInstance(string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Keyboard, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetKeyboardMapInstance(mapCategoryId, layoutId);
			}

			public MouseMap GetMouseMapInstance(int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				MouseMap mouseMap = CMuKNpKzoZWoovDXKkZgsiLlOCFy.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
				if (mouseMap != null)
				{
					controllers.Mouse.fsGAmSubJncncJCvyCKmjBAMAvWb(mouseMap);
				}
				return mouseMap;
			}

			public MouseMap GetMouseMapInstance(string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Mouse, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetMouseMapInstance(mapCategoryId, layoutId);
			}

			public CustomControllerMap GetCustomControllerMapInstance(CustomController customController, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				CustomControllerMap customControllerMap = CMuKNpKzoZWoovDXKkZgsiLlOCFy.kTOdclpIebPuPOcvLBmyBSJyAHcAA(customController.sourceControllerId, mapCategoryId, layoutId);
				if (customControllerMap != null)
				{
					customController.fsGAmSubJncncJCvyCKmjBAMAvWb(customControllerMap);
				}
				return customControllerMap;
			}

			public CustomControllerMap GetCustomControllerMapInstance(CustomController customController, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Custom, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetCustomControllerMapInstance(customController, mapCategoryId, layoutId);
			}

			public CustomControllerMap GetCustomControllerMapInstance(ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (controllerIdentifier.controllerType != ControllerType.Custom)
				{
					return null;
				}
				if (jFidDAJTYMYSSrBGXbdjHWSiLLLfB.syLDSFbeEMfdqJIKtznpocztFhSL(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstance(customController, mapCategoryId, layoutId);
				}
				if (controllerIdentifier.hardwareTypeGuid == Guid.Empty)
				{
					return null;
				}
				CustomController_Editor customControllerByHardwareTypeGuid = CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
				if (customControllerByHardwareTypeGuid == null)
				{
					return null;
				}
				CustomControllerMap customControllerMap = CMuKNpKzoZWoovDXKkZgsiLlOCFy.tbQBIHPgvhvSTFBGHEHOdHvdMnsC(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
				if (customControllerMap != null)
				{
					HardwareControllerMap_Game hardwareControllerMap_Game = customControllerByHardwareTypeGuid.CreateGameHardwareMap();
					if (hardwareControllerMap_Game == null)
					{
						Logger.LogError("No hardware map found.");
						return null;
					}
					Controller.aDLiogQIHBJlBPBxqAjcLNigUgpx(customControllerMap, hardwareControllerMap_Game);
				}
				return customControllerMap;
			}

			public CustomControllerMap GetCustomControllerMapInstance(ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Custom, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetCustomControllerMapInstance(controllerIdentifier, mapCategoryId, layoutId);
			}

			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, Controller controller, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				ControllerMap controllerMap = null;
				if (userDataStore is IControllerMapStore controllerMapStore)
				{
					controllerMap = controllerMapStore.LoadControllerMap(playerId, controller.identifier, mapCategoryId, layoutId);
				}
				if (controllerMap == null)
				{
					controllerMap = CMuKNpKzoZWoovDXKkZgsiLlOCFy.ScJIWgmKdhdnDAaTcyxOrBDAtCamA(controller, mapCategoryId, layoutId);
				}
				if (controllerMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.jGdOJWyhNAdAkaugcQVcNgUAVgjDA(controller, controllerMap);
					}
					else
					{
						controller.fsGAmSubJncncJCvyCKmjBAMAvWb(controllerMap);
					}
				}
				return controllerMap;
			}

			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, Controller controller, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(controller.type, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetControllerMapInstanceSavedOrDefault(playerId, controller, mapCategoryId, layoutId);
			}

			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return controllerIdentifier.controllerType switch
				{
					ControllerType.Joystick => GetJoystickMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId), 
					ControllerType.Custom => GetCustomControllerMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId), 
					ControllerType.Keyboard => GetKeyboardMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId), 
					ControllerType.Mouse => GetMouseMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(controllerIdentifier.controllerType, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetControllerMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
			}

			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, Joystick joystick, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return GetControllerMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId) as JoystickMap;
			}

			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, Joystick joystick, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetJoystickMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId);
			}

			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (jFidDAJTYMYSSrBGXbdjHWSiLLLfB.syLDSFbeEMfdqJIKtznpocztFhSL(controllerIdentifier) is Joystick joystick)
				{
					return GetJoystickMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId);
				}
				InputSource inputSourceType = NeEVntlckjaQuIKbzjPdCmfDUwQhc.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = hiPSsPHyqmWsHPcaZFVmfgZvUkXl.RIkFDKKrXktVmWPxJRtKdWgLsLgN(controllerIdentifier.hardwareTypeGuid, inputSourceType);
				if (hardwareJoystickMap_InputManager == null)
				{
					Logger.LogError("No hardware map found.");
					return null;
				}
				JoystickMap joystickMap = null;
				if (userDataStore is IControllerMapStore controllerMapStore)
				{
					joystickMap = controllerMapStore.LoadControllerMap(playerId, controllerIdentifier, mapCategoryId, layoutId) as JoystickMap;
				}
				if (joystickMap == null)
				{
					joystickMap = CMuKNpKzoZWoovDXKkZgsiLlOCFy.hHeEJnNucycDHDNXPcMfzPtZQcAlA(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
				}
				if (joystickMap != null)
				{
					if (players.GetPlayer(playerId) != null)
					{
						joystickMap.playerId = playerId;
					}
					Controller.aDLiogQIHBJlBPBxqAjcLNigUgpx(joystickMap, hardwareJoystickMap_InputManager.ToGameHardwareControllerMap());
				}
				return joystickMap;
			}

			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetJoystickMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
			}

			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, CustomController customController, int mapCategoryId, int layoutId)
			{
				return GetControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId) as CustomControllerMap;
			}

			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, CustomController customController, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Custom, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetCustomControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId);
			}

			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (jFidDAJTYMYSSrBGXbdjHWSiLLLfB.syLDSFbeEMfdqJIKtznpocztFhSL(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId);
				}
				CustomController_Editor customControllerByHardwareTypeGuid = CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
				if (customControllerByHardwareTypeGuid == null)
				{
					return null;
				}
				CustomControllerMap customControllerMap = null;
				if (userDataStore is IControllerMapStore controllerMapStore)
				{
					customControllerMap = controllerMapStore.LoadControllerMap(playerId, controllerIdentifier, mapCategoryId, layoutId) as CustomControllerMap;
				}
				if (customControllerMap == null)
				{
					customControllerMap = CMuKNpKzoZWoovDXKkZgsiLlOCFy.tbQBIHPgvhvSTFBGHEHOdHvdMnsC(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
				}
				if (customControllerMap != null)
				{
					HardwareControllerMap_Game hardwareControllerMap_Game = customControllerByHardwareTypeGuid.CreateGameHardwareMap();
					if (hardwareControllerMap_Game == null)
					{
						Logger.LogError("No hardware map found.");
						return null;
					}
					if (players.GetPlayer(playerId) != null)
					{
						customControllerMap.playerId = playerId;
					}
					Controller.aDLiogQIHBJlBPBxqAjcLNigUgpx(customControllerMap, hardwareControllerMap_Game);
				}
				return customControllerMap;
			}

			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Custom, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetCustomControllerMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
			}

			public KeyboardMap GetKeyboardMapInstanceSavedOrDefault(int playerId, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				Controller keyboard = controllers.Keyboard;
				KeyboardMap keyboardMap = null;
				if (userDataStore is IControllerMapStore controllerMapStore)
				{
					keyboardMap = controllerMapStore.LoadControllerMap(playerId, keyboard.identifier, mapCategoryId, layoutId) as KeyboardMap;
				}
				if (keyboardMap == null)
				{
					keyboardMap = CMuKNpKzoZWoovDXKkZgsiLlOCFy.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
				}
				if (keyboardMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.jGdOJWyhNAdAkaugcQVcNgUAVgjDA(keyboard, keyboardMap);
					}
					else
					{
						keyboard.fsGAmSubJncncJCvyCKmjBAMAvWb(keyboardMap);
					}
				}
				return keyboardMap;
			}

			public KeyboardMap GetKeyboardMapInstanceSavedOrDefault(int playerId, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Keyboard, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetKeyboardMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId);
			}

			public MouseMap GetMouseMapInstanceSavedOrDefault(int playerId, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				Controller mouse = controllers.Mouse;
				MouseMap mouseMap = null;
				if (userDataStore is IControllerMapStore controllerMapStore)
				{
					mouseMap = controllerMapStore.LoadControllerMap(playerId, mouse.identifier, mapCategoryId, layoutId) as MouseMap;
				}
				if (mouseMap == null)
				{
					mouseMap = CMuKNpKzoZWoovDXKkZgsiLlOCFy.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
				}
				if (mouseMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.jGdOJWyhNAdAkaugcQVcNgUAVgjDA(mouse, mouseMap);
					}
					else
					{
						mouse.fsGAmSubJncncJCvyCKmjBAMAvWb(mouseMap);
					}
				}
				return mouseMap;
			}

			public MouseMap GetMouseMapInstanceSavedOrDefault(int playerId, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Mouse, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetMouseMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId);
			}

			[Obsolete("This method has been deprecated. Use the Controller Template system instead.", false)]
			public ControllerElementIdentifier GetFirstJoystickTemplateElementIdentifier(Joystick joystick, int joystickElementIdentifierId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (joystick == null)
				{
					return null;
				}
				return SJEOkCqIFWeoNmRarhMDGyNvRoheA(joystick.hardwareTypeGuid, joystickElementIdentifierId);
			}

			private ControllerElementIdentifier SJEOkCqIFWeoNmRarhMDGyNvRoheA(Guid P_0, int P_1)
			{
				HardwareJoystickMap hardwareControllerMap;
				return hiPSsPHyqmWsHPcaZFVmfgZvUkXl.PYOaXbKiLIhcNFnuWfVtFpWvTanIA(P_0, P_1, out hardwareControllerMap)?.ToControllerElementIdentifier(hardwareControllerMap);
			}

			internal int aJWFbIdtRibYNkTqoLoMqbkcXzfG(Guid P_0, Guid P_1, int P_2, List<HardwareControllerTemplateMap.FDkLHcyMJQXVwOVdNsLdHOXsVLxN> P_3)
			{
				return hiPSsPHyqmWsHPcaZFVmfgZvUkXl.RcWbCnARtNUdIfZHDyhSpaXGuReW(P_0, P_1, P_2, P_3);
			}

			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.zovzSzSMHKbKfrDUdqiTHmiHgMUgA(templateTypeGuid, mapCategoryId, layoutId);
			}

			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Custom, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetControllerTemplateMapInstance(templateTypeGuid, mapCategoryId, layoutId);
			}

			public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(int id)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetControllerMapLayoutManagerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapLayoutManagerRuleSetId = CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetControllerMapLayoutManagerRuleSetId(name);
				if (controllerMapLayoutManagerRuleSetId < 0)
				{
					return null;
				}
				return GetControllerMapLayoutManagerRuleSetInstance(controllerMapLayoutManagerRuleSetId);
			}

			public ControllerMapEnabler.RuleSet GetControllerMapEnablerRuleSetInstance(int id)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetControllerMapEnablerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapEnabler.RuleSet GetControllerMapEnablerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapEnablerRuleSetId = CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetControllerMapEnablerRuleSetId(name);
				if (controllerMapEnablerRuleSetId < 0)
				{
					return null;
				}
				return GetControllerMapEnablerRuleSetInstance(controllerMapEnablerRuleSetId);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class PlayerHelper : CodeHelper
		{
			private static PlayerHelper PpMGPOTaQuuHNynAOnXESPrpGEIK;

			internal static PlayerHelper XizyukbhlOxmCVRsQucvFuONrdIW => PpMGPOTaQuuHNynAOnXESPrpGEIK ?? (PpMGPOTaQuuHNynAOnXESPrpGEIK = new PlayerHelper());

			public int playerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return kaDCuNAiSdnlkLeWRajALqrXMggab.tpdryKsrOUTmelygFJMwPYWdGpuT;
				}
			}

			public int allPlayerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return kaDCuNAiSdnlkLeWRajALqrXMggab.DaNCZJGjdPEwEMMCNJKqAfZOlnrgA;
				}
			}

			public IList<Player> Players
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<Player>.EmptyReadOnlyIListT;
					}
					return kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB;
				}
			}

			public IList<Player> AllPlayers
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<Player>.EmptyReadOnlyIListT;
					}
					return kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd;
				}
			}

			public Player SystemPlayer
			{
				get
				{
					if (!CheckInitialized())
					{
						return null;
					}
					return kaDCuNAiSdnlkLeWRajALqrXMggab.cbWeSIcpBJHiLSZzDUKykXKZEoiKA();
				}
			}

			private PlayerHelper()
			{
			}

			public IList<Player> GetPlayers(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<Player>.EmptyReadOnlyIListT;
				}
				if (!includeSystemPlayer)
				{
					return kaDCuNAiSdnlkLeWRajALqrXMggab.NyLACShszzlNajcvDZloBEtKTIxhB;
				}
				return kaDCuNAiSdnlkLeWRajALqrXMggab.cpMYDNUjphXguEliLQiMZXNKTfhd;
			}

			public Player GetPlayer(int playerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return kaDCuNAiSdnlkLeWRajALqrXMggab.lDoHnmryxjmnpsBMkafFfmrvyKiB(playerId);
			}

			public Player GetPlayer(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return kaDCuNAiSdnlkLeWRajALqrXMggab.ZciXmoBKMNikBWUVsGGGhiowADRdA(name);
			}

			public Player GetSystemPlayer()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return kaDCuNAiSdnlkLeWRajALqrXMggab.cbWeSIcpBJHiLSZzDUKykXKZEoiKA();
			}

			public int GetPlayerId(string playerName)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return kaDCuNAiSdnlkLeWRajALqrXMggab.wMylPmbLIXbhOnodbjuYhpblRBbGA(playerName);
			}

			public string[] GetPlayerNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return kaDCuNAiSdnlkLeWRajALqrXMggab.iWoGAziiwWKEKjcyACCoTmeszdkW(includeSystemPlayer);
			}

			public string[] GetPlayerDescriptiveNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return kaDCuNAiSdnlkLeWRajALqrXMggab.HFotKGhpPubVyFbdgAmylkVWepgy(includeSystemPlayer);
			}

			public int[] GetPlayerIds(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<int>.array;
				}
				return kaDCuNAiSdnlkLeWRajALqrXMggab.znHaUcEMfJkLwHPKNmEazlexRIDhA(includeSystemPlayer);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class TimeHelper : CodeHelper
		{
			private static TimeHelper mpLlWQlTfUOSBBaPSSnbNLYxqJyy;

			internal static TimeHelper ULdESjaAHkIrXDdgHqOgFSYlIzBJB => mpLlWQlTfUOSBBaPSSnbNLYxqJyy ?? (mpLlWQlTfUOSBBaPSSnbNLYxqJyy = new TimeHelper());

			public float unscaledDeltaTime
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0f;
					}
					return (float)ZUxrPexAiNmADkUhVBcmMDJmGRUEA.emfDvbbSxlnXsGFtqTizdpuLuryvA;
				}
			}

			public double unscaledTime
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0.0;
					}
					return ZUxrPexAiNmADkUhVBcmMDJmGRUEA.hekDEYdHnfkgrcIszlvTKcHviLbFb;
				}
			}

			public uint currentFrame
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0u;
					}
					return ZUxrPexAiNmADkUhVBcmMDJmGRUEA.effiJVjGriUeUOzTPZUHUnfsyQLeA;
				}
			}

			public uint absFrame
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0u;
					}
					return ZUxrPexAiNmADkUhVBcmMDJmGRUEA.OnNUQTZAKdBQVGmowHkBHNBEqdrtB;
				}
			}

			private TimeHelper()
			{
			}
		}

		private class vPtPjlHynTaMHkqnhlwwFawlvjhN
		{
			private class cuyBfqEsMAzJgfJznKZSvcywtIjE
			{
				public readonly UpdateLoopType hHZJxZJsvWNGRUXdfkqnLVEZatoJ;

				private double slYAeZBZXOOmMEbrwNhkcCvvOkSgA;

				private double uKGXaBAdoIfpODrlyyRhalLwOCBK;

				private double tTcCIOJAHpfxKCdElbXOeNNaGHdoB;

				private double gxDPiiBfvCGjoHMJDLNoGFjaGGSqc;

				private uint gCLWsUKLAADIkPKtYWGpYOgZVGvF;

				private uint VlmplosSgsuXykJwSARWmdJcqflF;

				private float IFcFuWzulWqZllxXmnRgVFVvewoE;

				private float PTfalemvgcakNcndbVGDlVqGBVBe;

				public double abPGZslyIAfCxDgmLtFjuwRMRMJm => slYAeZBZXOOmMEbrwNhkcCvvOkSgA;

				public double meziIYzOeZdDrrCBYnZQtEEjDciu => uKGXaBAdoIfpODrlyyRhalLwOCBK;

				public double PDkcVBYRfyXYQqbTgYEnNmyRhPWo => tTcCIOJAHpfxKCdElbXOeNNaGHdoB;

				public uint evAWIknjhPSRorJEWZRStmfUCrag => gCLWsUKLAADIkPKtYWGpYOgZVGvF;

				public uint EgJvyJLOklbkaixmwsepXFgbWoAC => VlmplosSgsuXykJwSARWmdJcqflF;

				public float KnSvWEAweAxccBBNHLHfyWSekfDY => IFcFuWzulWqZllxXmnRgVFVvewoE;

				public float cTXebWedLjjeBFHoBcoOHWzRDmVsb => PTfalemvgcakNcndbVGDlVqGBVBe;

				public cuyBfqEsMAzJgfJznKZSvcywtIjE(UpdateLoopType P_0)
				{
					hHZJxZJsvWNGRUXdfkqnLVEZatoJ = P_0;
					gxDPiiBfvCGjoHMJDLNoGFjaGGSqc = Time.realtimeSinceStartup;
					gCLWsUKLAADIkPKtYWGpYOgZVGvF = 0u;
				}

				public void UqCAqWTMdyTPxZSYOFIBTyzMbQyE()
				{
					uKGXaBAdoIfpODrlyyRhalLwOCBK = slYAeZBZXOOmMEbrwNhkcCvvOkSgA;
					slYAeZBZXOOmMEbrwNhkcCvvOkSgA = realTime;
					if (gxDPiiBfvCGjoHMJDLNoGFjaGGSqc > slYAeZBZXOOmMEbrwNhkcCvvOkSgA)
					{
						gxDPiiBfvCGjoHMJDLNoGFjaGGSqc = 0.0;
					}
					tTcCIOJAHpfxKCdElbXOeNNaGHdoB = slYAeZBZXOOmMEbrwNhkcCvvOkSgA - gxDPiiBfvCGjoHMJDLNoGFjaGGSqc;
					gxDPiiBfvCGjoHMJDLNoGFjaGGSqc = slYAeZBZXOOmMEbrwNhkcCvvOkSgA;
					VlmplosSgsuXykJwSARWmdJcqflF = gCLWsUKLAADIkPKtYWGpYOgZVGvF;
					gCLWsUKLAADIkPKtYWGpYOgZVGvF = MiscTools.Tick(gCLWsUKLAADIkPKtYWGpYOgZVGvF);
					PTfalemvgcakNcndbVGDlVqGBVBe = IFcFuWzulWqZllxXmnRgVFVvewoE;
					IFcFuWzulWqZllxXmnRgVFVvewoE = AjbGBgLXkztJCVBHOXhAYDgxKGiW();
					previousFrame = VlmplosSgsuXykJwSARWmdJcqflF;
					currentFrame = gCLWsUKLAADIkPKtYWGpYOgZVGvF;
					unscaledTime = slYAeZBZXOOmMEbrwNhkcCvvOkSgA;
					unscaledTimePrev = uKGXaBAdoIfpODrlyyRhalLwOCBK;
					unscaledDeltaTime = tTcCIOJAHpfxKCdElbXOeNNaGHdoB;
				}
			}

			private static class DFfcwvPJSOzDnbSDjRTQyjurOgGo
			{
				public static StopwatchBase pPVHKWEGWmMJwzaFkNDjZOoHBC
				{
					get
					{
						if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
						{
							return UnityStopwatch.Global;
						}
						return Rewired.Utils.Classes.Utility.Stopwatch.Global;
					}
				}

				public static StopwatchBase IUQWAoqadoAUGVtWPgUkqVgTtjWe()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return new UnityStopwatch();
					}
					return new Rewired.Utils.Classes.Utility.Stopwatch();
				}

				public static StopwatchBase LHdjfUbDwwechGIblEruwQcJpBaMA()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return UnityStopwatch.StartNew();
					}
					return Rewired.Utils.Classes.Utility.Stopwatch.StartNew();
				}
			}

			private StopwatchBase dShYTjaBUAuJhaLUhbKhjrgjmYXmA;

			private double RLXRVcukKJhAlCxlvPUtsKRgOAMeA;

			private cuyBfqEsMAzJgfJznKZSvcywtIjE fPwdkQdCkLbjEcjsEvPAoDwrDIBib;

			private ADictionary<int, cuyBfqEsMAzJgfJznKZSvcywtIjE> MhlJlGLUnSjDdKPlKRJAeTHVSasi;

			private uint gaoIDHxwmdFiiBsSNAvIsDSKvYPjA;

			public double hekDEYdHnfkgrcIszlvTKcHviLbFb => fPwdkQdCkLbjEcjsEvPAoDwrDIBib.abPGZslyIAfCxDgmLtFjuwRMRMJm;

			public double rPEpWysgqPzwOYqMzvdYVVAfAwoh => fPwdkQdCkLbjEcjsEvPAoDwrDIBib.meziIYzOeZdDrrCBYnZQtEEjDciu;

			public double emfDvbbSxlnXsGFtqTizdpuLuryvA => fPwdkQdCkLbjEcjsEvPAoDwrDIBib.PDkcVBYRfyXYQqbTgYEnNmyRhPWo;

			public float fhOXJbKIWDSpQSCPcUtKHQNYUtSo => fPwdkQdCkLbjEcjsEvPAoDwrDIBib.KnSvWEAweAxccBBNHLHfyWSekfDY;

			public float wYgWLrAmBbBKeMvqISEkeuGghttU => fPwdkQdCkLbjEcjsEvPAoDwrDIBib.cTXebWedLjjeBFHoBcoOHWzRDmVsb;

			internal double rYNzwnlqcwjaWmZpmZjTyxspnfrG => dShYTjaBUAuJhaLUhbKhjrgjmYXmA.elapsedSeconds + RLXRVcukKJhAlCxlvPUtsKRgOAMeA;

			public uint effiJVjGriUeUOzTPZUHUnfsyQLeA => fPwdkQdCkLbjEcjsEvPAoDwrDIBib.evAWIknjhPSRorJEWZRStmfUCrag;

			public uint uXWrCnPQFetdBURIyLHHxFixNWki => fPwdkQdCkLbjEcjsEvPAoDwrDIBib.EgJvyJLOklbkaixmwsepXFgbWoAC;

			public uint OnNUQTZAKdBQVGmowHkBHNBEqdrtB => gaoIDHxwmdFiiBsSNAvIsDSKvYPjA;

			public vPtPjlHynTaMHkqnhlwwFawlvjhN()
			{
				dShYTjaBUAuJhaLUhbKhjrgjmYXmA = DFfcwvPJSOzDnbSDjRTQyjurOgGo.pPVHKWEGWmMJwzaFkNDjZOoHBC;
				RZchXaeaqraZPJdTGcIXiPnhlbOqb();
			}

			public void OMqpcgDMZdXDJuulrObiOHhqIcWm()
			{
				RLXRVcukKJhAlCxlvPUtsKRgOAMeA = Time.realtimeSinceStartup;
			}

			public void RZchXaeaqraZPJdTGcIXiPnhlbOqb()
			{
				fPwdkQdCkLbjEcjsEvPAoDwrDIBib = null;
				MhlJlGLUnSjDdKPlKRJAeTHVSasi = new ADictionary<int, cuyBfqEsMAzJgfJznKZSvcywtIjE>();
				using TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3);
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes((UpdateLoopSetting)(-1), list);
				for (int i = 0; i < list.Count; i++)
				{
					cuyBfqEsMAzJgfJznKZSvcywtIjE value = new cuyBfqEsMAzJgfJznKZSvcywtIjE(list[i]);
					MhlJlGLUnSjDdKPlKRJAeTHVSasi.Add((int)list[i], value);
					if (fPwdkQdCkLbjEcjsEvPAoDwrDIBib == null)
					{
						fPwdkQdCkLbjEcjsEvPAoDwrDIBib = value;
					}
				}
			}

			public void BeTRKigRknWaCEsUWXHMxZgafMzu(UpdateLoopType P_0)
			{
				if (fPwdkQdCkLbjEcjsEvPAoDwrDIBib.hHZJxZJsvWNGRUXdfkqnLVEZatoJ != P_0)
				{
					fPwdkQdCkLbjEcjsEvPAoDwrDIBib = MhlJlGLUnSjDdKPlKRJAeTHVSasi[(int)P_0];
				}
				if (P_0 != UpdateLoopType.OnGUI || Event.current.rawType == EventType.Layout)
				{
					fPwdkQdCkLbjEcjsEvPAoDwrDIBib.UqCAqWTMdyTPxZSYOFIBTyzMbQyE();
					gaoIDHxwmdFiiBsSNAvIsDSKvYPjA = MiscTools.Tick(gaoIDHxwmdFiiBsSNAvIsDSKvYPjA);
					absFrame = gaoIDHxwmdFiiBsSNAvIsDSKvYPjA;
				}
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class UnityTouch : CodeHelper
		{
			private static UnityTouch XqurHgWlcUboShMcwqsLNtYTQXx;

			internal static UnityTouch bYRFvehkIbyygUUNrYjJaMGIwPdr => XqurHgWlcUboShMcwqsLNtYTQXx ?? (XqurHgWlcUboShMcwqsLNtYTQXx = new UnityTouch());

			public bool touchSupported => UnityInputHelper.touchSupported;

			public int touchCount => UnityInputHelper.touchCount;

			public Rewired.UnityTouch[] touches => UnityInputHelper.touches;

			public bool simulateMouseWithTouches
			{
				get
				{
					return UnityInputHelper.simulateMouseWithTouches;
				}
				set
				{
					UnityInputHelper.simulateMouseWithTouches = value;
				}
			}

			public bool multiTouchEnabled
			{
				get
				{
					return UnityInputHelper.multiTouchEnabled;
				}
				set
				{
					UnityInputHelper.multiTouchEnabled = value;
				}
			}

			private UnityTouch()
			{
			}

			public Rewired.UnityTouch GetTouch(int index)
			{
				return UnityInputHelper.GetTouch(index);
			}
		}

		internal class SqccyWYBnZsgVjUSCBiSqdoenwLG
		{
			[Serializable]
			private sealed class PgaInGsdCgzKIaMgzxFjCLNRRrpo
			{
				public static readonly PgaInGsdCgzKIaMgzxFjCLNRRrpo _003C_003E9 = new PgaInGsdCgzKIaMgzxFjCLNRRrpo();

				public static Func<bool> _003C_003E9__12_1;

				public static Func<bool> _003C_003E9__12_2;

				public static Func<int> _003C_003E9__12_3;

				public static Func<float> _003C_003E9__12_4;

				public static Func<bool> _003C_003E9__12_5;

				public static Func<string> _003C_003E9__12_0;

				internal bool TCravmkGfSDalhmVLurcbxxgFflk()
				{
					return Screen.fullScreen;
				}

				internal bool mbAfDfIZgIDlSlmbAgQxsNMwJrjzA()
				{
					return Application.runInBackground;
				}

				internal int PEEijEsZtdMVDuxXqZrbyVvrnOzC()
				{
					return (int)Screen.fullScreenMode;
				}

				internal float VDtsdZeVJYsKiHzLGBjRSzrPIzmM()
				{
					return Time.unscaledDeltaTime;
				}

				internal bool KeiSFYVvyDFFRqrbUSZvDOaAahit()
				{
					return MathTools.ApproximatelyZero(Time.timeScale);
				}

				internal string dhkyOcNlzqdslEolAhYlkzdLXkgLA()
				{
					return UnityTools.externalTools.GetFocusedEditorWindowTitle();
				}
			}

			public readonly ValueWatcher<bool> ReBxGqZauQYfDMdMRzrynaBQqHgk;

			public readonly ValueWatcher<bool> ZErbmgGKzLFfTADIgkNdTOsxrHei;

			public readonly ValueWatcher<bool> lXlYlCwcWfqJtdFDRnkejMdSWZnu;

			public readonly ValueWatcher<bool> DKkoVeRlcTlrDfzlNfaSsWRFpacf;

			public readonly ValueWatcher<int> LMgWHMNUFnDWprFDywcqaOSejnnM;

			public readonly ValueWatcher<float> oEZzpviILlZbqsTiTmDWLXQQbtWK;

			public readonly ValueWatcher<string> woGCmidcCrKhdTyCdWyMCLJWwjhVA;

			public readonly ValueWatcher<bool> pmlAdSKskpmHDTCBQJwHHEiYeTVj;

			private int CBlhPLjdVdbAVGWGQfyoERJcOIToc;

			private readonly ValueWatcher[] fkeINHRXViYGXClNGdConyzLmFxA;

			public int bBosxDPUruIZPrYsvTuGmldoDEeEA => CBlhPLjdVdbAVGWGQfyoERJcOIToc;

			public SqccyWYBnZsgVjUSCBiSqdoenwLG()
			{
				bool flag = UnityTools.isEditor || Application.isFocused;
				List<ValueWatcher> list = new List<ValueWatcher>
				{
					(ReBxGqZauQYfDMdMRzrynaBQqHgk = new ValueWatcher<bool>(flag, false)),
					(ZErbmgGKzLFfTADIgkNdTOsxrHei = new ValueWatcher<bool>(false, false)),
					(lXlYlCwcWfqJtdFDRnkejMdSWZnu = new ValueWatcher<bool>(Screen.fullScreen, PgaInGsdCgzKIaMgzxFjCLNRRrpo._003C_003E9.TCravmkGfSDalhmVLurcbxxgFflk, false)),
					(DKkoVeRlcTlrDfzlNfaSsWRFpacf = new ValueWatcher<bool>(Application.runInBackground, PgaInGsdCgzKIaMgzxFjCLNRRrpo._003C_003E9.mbAfDfIZgIDlSlmbAgQxsNMwJrjzA, false)),
					(LMgWHMNUFnDWprFDywcqaOSejnnM = new ValueWatcher<int>((int)Screen.fullScreenMode, PgaInGsdCgzKIaMgzxFjCLNRRrpo._003C_003E9.PEEijEsZtdMVDuxXqZrbyVvrnOzC, false)),
					(oEZzpviILlZbqsTiTmDWLXQQbtWK = new ValueWatcher<float>(Time.unscaledDeltaTime, PgaInGsdCgzKIaMgzxFjCLNRRrpo._003C_003E9.VDtsdZeVJYsKiHzLGBjRSzrPIzmM, false)),
					(pmlAdSKskpmHDTCBQJwHHEiYeTVj = new ValueWatcher<bool>(MathTools.ApproximatelyZero(Time.timeScale), PgaInGsdCgzKIaMgzxFjCLNRRrpo._003C_003E9.KeiSFYVvyDFFRqrbUSZvDOaAahit, MathTools.ApproximatelyZero(Time.timeScale)))
				};
				if (editorPlatform != EditorPlatform.None)
				{
					list.Add(woGCmidcCrKhdTyCdWyMCLJWwjhVA = new ValueWatcher<string>(UnityTools.externalTools.GetFocusedEditorWindowTitle(), PgaInGsdCgzKIaMgzxFjCLNRRrpo._003C_003E9.dhkyOcNlzqdslEolAhYlkzdLXkgLA, false));
				}
				fkeINHRXViYGXClNGdConyzLmFxA = list.ToArray();
				LAjGlCkKbTWOciNbVfdMbbEtJvVi();
			}

			public void LAjGlCkKbTWOciNbVfdMbbEtJvVi()
			{
				for (int i = 0; i < fkeINHRXViYGXClNGdConyzLmFxA.Length; i++)
				{
					fkeINHRXViYGXClNGdConyzLmFxA[i].Update();
				}
				CBlhPLjdVdbAVGWGQfyoERJcOIToc = Time.frameCount;
			}

			public void mBwESeRIchBRYpavpRJmnCwWXkFR()
			{
				for (int i = 0; i < fkeINHRXViYGXClNGdConyzLmFxA.Length; i++)
				{
					fkeINHRXViYGXClNGdConyzLmFxA[i].TriggerEvent();
				}
			}
		}

		[Serializable]
		private sealed class uymibArYmfqrNrQqBtYwAqArflTX
		{
			public static readonly uymibArYmfqrNrQqBtYwAqArflTX _003C_003E9 = new uymibArYmfqrNrQqBtYwAqArflTX();

			public static Func<bool> _003C_003E9__241_0;

			internal void WTgGlpCIVpnRzZKMjFvwumtUAAqe(Exception P_0)
			{
				HandleCallbackException("", P_0);
			}

			internal void MHJEefRZlaAKeHBDniycdHXJjpOx(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerConnectedEvent", P_0);
			}

			internal void hAdnbhKkBLkGfFDcbqjFHKSeSzb(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerPreDisconnectEvent", P_0);
			}

			internal void PhDBumrinkKwgeMXOsvlEKTnKrDl(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerDisconnectedEvent", P_0);
			}

			internal void qnfkSyjRROLLmDjhmSxVEAGPcMqK(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.InputSourceUpdateEvent", P_0);
			}

			internal void YELbmxalBVovKCfoiVaMLGpIBZEOB(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.EditorRecompileEvent", P_0);
			}

			internal void bGciilELSVVdkUkmpKTVvYoNHXkJ(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.PreShutDownEvent", P_0);
			}

			internal void lZjEbhkhMwYnMXOOqNYUSpbjKsZE(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ShutDownEvent", P_0);
			}

			internal void VtHLeVWqnQIjtpOkyJswuIYHrXMK(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.InitializedEvent", P_0);
			}

			internal bool bNXmmBnosxSRvUmENcwHUNKvZzVV()
			{
				if (isUnityEditorFocused)
				{
					return isAllowedEditorWindowFocused;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal const int programVersion1 = 1;

		[CustomObfuscation(rename = false)]
		internal const int programVersion2 = 1;

		[CustomObfuscation(rename = false)]
		internal const int programVersion3 = 64;

		[CustomObfuscation(rename = false)]
		internal const int programVersion4 = 1;

		[CustomObfuscation(rename = false)]
		internal const int dataVersion = 1;

		[CustomObfuscation(rename = false)]
		internal const bool isTrial = false;

		[CustomObfuscation(rename = false)]
		internal const string majorBranch = "U2022";

		private static InputManager_Base SiXOGfYAfmKJkNWCcNWqoXmYteDF;

		private static PlatformInputManager NeEVntlckjaQuIKbzjPdCmfDUwQhc;

		internal static tJoKaBpeixEcmjlcjTQCbZQpjqFR QYXTlPbvvfyHDodSqaxHRoHhFdw;

		internal static ruLXWgGHNYKBNoYhWlYmLdtbexbY jFidDAJTYMYSSrBGXbdjHWSiLLLfB;

		internal static XCvMDQBADcmACIDQJmYqAKqBfrW kaDCuNAiSdnlkLeWRajALqrXMggab;

		private static ControllerDataFiles hiPSsPHyqmWsHPcaZFVmfgZvUkXl;

		private static UserData CMuKNpKzoZWoovDXKkZgsiLlOCFy;

		private static bool WugjmBgLTJdXmPxOcjVoTkTTUlEC;

		private static ConfigVars wzlteJdDPZYmtywPXjGXrWAAIKvJ;

		private static UpdateLoopType DpzeCDeMaNUxfpjNsyZnwPPsigHi;

		private static bool TxCplICMnTZpPiXwadmbEnzHOQTt;

		private static Platform yYubrrhmzcQeEpBSLvzpxyvmkALy;

		private static WebplayerPlatform RnABkzMQAOJCrSsDFjSEarshMOcm;

		private static EditorPlatform jVrMZpwBfxvSHnqDpPQGNDMVTIIx;

		private static bool xfZNQVtjBKMSfoeOsEPUkXdEqgniA;

		private static TimerAbs YpCSnSudifTSMpgspQIKIrvkDhjD;

		private static vPtPjlHynTaMHkqnhlwwFawlvjhN ZUxrPexAiNmADkUhVBcmMDJmGRUEA;

		private static string uNuydNmiuTSHDwqDgoEYnqmXBfFu;

		private static bool oLNgxlxGxPCFzIJWpXvtDvMgOazu;

		private static bool TqFvsqFPtvxFgaAuaSQmzdpsAUCw;

		private static bool ROiCsEApoinzMWBXeDPkialwGtmV;

		private static int MuWmAgklbHmoQdkzxECOwDPeFRUaA;

		private static int jlBEqHKjUDDhVTIkPgBNxXejleLHA;

		[CustomObfuscation(rename = false)]
		internal static int _id;

		private static int avMksdsvFXITrTdrbcRLuujLfqRQ;

		private static int XJXbGFtGtnhWdoMxcPMcrEuyEJMB;

		private static bool GJIoqpeFlSgtXTGhUyqxqppuBrcw;

		private static readonly UnityTouch anKnhHkJHASgpFNEmYksuYjcudyn;

		private static readonly PlayerHelper nNnrEVdmXbYiFmjBqnWpuARQkHoR;

		private static readonly ControllerHelper EaKOGphjFSDlbhqBGTVMhxOJzzUV;

		private static readonly MappingHelper vxwLsuDMisPyzQOPQPEoWAACCwrhA;

		private static readonly TimeHelper jTZXZyRvnjsLVBtGVbCzarzUkwfb;

		private static readonly ConfigHelper tJVdMzqLSMVjbTkBIETodqpmwNDE;

		private static readonly LocalizationHelper ZWYeLkxGEvWBGFmJLGduaCZpwpNJ;

		private static readonly GlyphHelper UCSnDESAmFQbBSTXlUDbxpCFHoVy;

		private static KZotvnGAHBaJnZPldYeBXWmirJmL KTlqDJvgpEhkndsEcnjWuPpfhZegA;

		private static UserDataStore ssZCPbHVsxUheYbwcZKRsCxnNTtE;

		private static IControllerAssigner bltTmWXirvaIOleaXPdbdsbeBTMy;

		private static SqccyWYBnZsgVjUSCBiSqdoenwLG mDJAaKOdFaHFEnzSxHhKjsuSNViQ;

		private static int SVMPRXBmdWAUjHJyiieHGmGhJwPJb;

		private static SafeAction<ControllerStatusChangedEventArgs> uUxqbKykYtnbOhmGcbIOzEbsChjC;

		private static SafeAction<ControllerStatusChangedEventArgs> NHHaaThhSabelwfjItiCWFRUbepK;

		private static SafeAction<ControllerStatusChangedEventArgs> qJPVMsrpeQQFEjEVuiVIjIRxfwODA;

		private static SafeAction lFLErzhpSszWWqCbIMeYIwgHLfIk;

		private static SafeAction PfhNdKFZrqpYFOcMLVpsyASQRUFe;

		private static SafeAction TXZCntKnIwLFhaYUnYhujuhqbGcIA;

		private static SafeAction DuHIRYzEpJscGdGxPQRbnnJkbwUm;

		private static SafeAction XvvLHZiTqybeOnBeNeJHkXpzEQOR;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationFocusChangedEvent;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationPauseChangedEvent;

		private static Action NwyqrQDOgrhNZxfeJIQnJxLAMsiD;

		private static Action<UpdateLoopType> NbxPBpDGdSnkNTIBaCpIGhcAFKzS;

		private static Action<UpdateLoopType> fEyFTXJIyqFrRiaGPmPOKYiXrpMpA;

		private static Action<UpdateLoopType> GOhWwIBmIEkVLptccqJrlYPWQNjo;

		private static Action lTRzFwsWLjdEHOcBBWVAHZrVeUEb;

		private static Action<bool> vbzmbYhcTVyQQqNoMgxFBBMycPzm;

		private static Action<bool> AiwwgowAZHkjjumMJLoHmyUxPNc;

		private static Action<bool> qAyOJjxNkXyXmUuiWaPRclVmabHc;

		private static Action<FullScreenMode> wQSLzQqYYpPehzigcjyghVnuzbhj;

		private static Action diEhnNEaBdaxAMaZbpRQmxtTdbmh;

		private static Action<bool> RAmsoXPJnXBdANCIOckjGpSknLhBb;

		[CustomObfuscation(rename = false)]
		internal static double unscaledDeltaTime;

		[CustomObfuscation(rename = false)]
		internal static double unscaledTime;

		[CustomObfuscation(rename = false)]
		internal static double unscaledTimePrev;

		[CustomObfuscation(rename = false)]
		internal static uint currentFrame;

		[CustomObfuscation(rename = false)]
		internal static uint previousFrame;

		[CustomObfuscation(rename = false)]
		internal static uint absFrame;

		private static KZotvnGAHBaJnZPldYeBXWmirJmL bbBBrcEkOraOJcDTQuujlYEFiVof => KTlqDJvgpEhkndsEcnjWuPpfhZegA ?? (KTlqDJvgpEhkndsEcnjWuPpfhZegA = new KZotvnGAHBaJnZPldYeBXWmirJmL(wzlteJdDPZYmtywPXjGXrWAAIKvJ.updateLoop));

		private static bool OJOMZlJOGXljekIvoskoxARRkUuo => SVMPRXBmdWAUjHJyiieHGmGhJwPJb > 0;

		public static PlayerHelper players
		{
			get
			{
				if (!WugjmBgLTJdXmPxOcjVoTkTTUlEC)
				{
					QHOfuRBfROqATHkfjNXRkCQNBPPHA();
					return null;
				}
				return nNnrEVdmXbYiFmjBqnWpuARQkHoR;
			}
		}

		public static ControllerHelper controllers
		{
			get
			{
				if (!WugjmBgLTJdXmPxOcjVoTkTTUlEC)
				{
					QHOfuRBfROqATHkfjNXRkCQNBPPHA();
					return null;
				}
				return EaKOGphjFSDlbhqBGTVMhxOJzzUV;
			}
		}

		public static MappingHelper mapping
		{
			get
			{
				if (!WugjmBgLTJdXmPxOcjVoTkTTUlEC)
				{
					QHOfuRBfROqATHkfjNXRkCQNBPPHA();
					return null;
				}
				return vxwLsuDMisPyzQOPQPEoWAACCwrhA;
			}
		}

		public static UnityTouch touch
		{
			get
			{
				if (!WugjmBgLTJdXmPxOcjVoTkTTUlEC)
				{
					QHOfuRBfROqATHkfjNXRkCQNBPPHA();
					return null;
				}
				return anKnhHkJHASgpFNEmYksuYjcudyn;
			}
		}

		public static TimeHelper time
		{
			get
			{
				if (!WugjmBgLTJdXmPxOcjVoTkTTUlEC)
				{
					QHOfuRBfROqATHkfjNXRkCQNBPPHA();
					return null;
				}
				return jTZXZyRvnjsLVBtGVbCzarzUkwfb;
			}
		}

		public static IUserDataStore userDataStore
		{
			get
			{
				if (!WugjmBgLTJdXmPxOcjVoTkTTUlEC)
				{
					QHOfuRBfROqATHkfjNXRkCQNBPPHA();
					return null;
				}
				return ssZCPbHVsxUheYbwcZKRsCxnNTtE;
			}
		}

		public static ConfigHelper configuration
		{
			get
			{
				if (!WugjmBgLTJdXmPxOcjVoTkTTUlEC)
				{
					QHOfuRBfROqATHkfjNXRkCQNBPPHA();
					return null;
				}
				return tJVdMzqLSMVjbTkBIETodqpmwNDE;
			}
		}

		public static LocalizationHelper localization
		{
			get
			{
				if (!WugjmBgLTJdXmPxOcjVoTkTTUlEC)
				{
					QHOfuRBfROqATHkfjNXRkCQNBPPHA();
					return null;
				}
				return ZWYeLkxGEvWBGFmJLGduaCZpwpNJ;
			}
		}

		public static GlyphHelper glyphs
		{
			get
			{
				if (!WugjmBgLTJdXmPxOcjVoTkTTUlEC)
				{
					QHOfuRBfROqATHkfjNXRkCQNBPPHA();
					return null;
				}
				return UCSnDESAmFQbBSTXlUDbxpCFHoVy;
			}
		}

		public static string programVersion => 1 + "." + 1 + "." + 64 + "." + 1 + ".U2022";

		public static bool usingUnityInput => TxCplICMnTZpPiXwadmbEnzHOQTt;

		public static bool unityJoystickIdentificationRequired
		{
			get
			{
				if (!WugjmBgLTJdXmPxOcjVoTkTTUlEC)
				{
					return false;
				}
				if (isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull)
				{
					return true;
				}
				return false;
			}
		}

		public static bool isReady => WugjmBgLTJdXmPxOcjVoTkTTUlEC;

		[CustomObfuscation(rename = false)]
		internal static int id => _id;

		[CustomObfuscation(rename = false)]
		internal static bool initialized => WugjmBgLTJdXmPxOcjVoTkTTUlEC;

		[CustomObfuscation(rename = false)]
		internal static UpdateLoopType currentUpdateLoop => DpzeCDeMaNUxfpjNsyZnwPPsigHi;

		[CustomObfuscation(rename = false)]
		internal static ConfigVars configVars => wzlteJdDPZYmtywPXjGXrWAAIKvJ;

		[CustomObfuscation(rename = false)]
		internal static IConfigVars_Internal pluginConfigVars => wzlteJdDPZYmtywPXjGXrWAAIKvJ;

		[CustomObfuscation(rename = false)]
		internal static UserData UserData => CMuKNpKzoZWoovDXKkZgsiLlOCFy;

		[CustomObfuscation(rename = false)]
		internal static Platform currentPlatform => yYubrrhmzcQeEpBSLvzpxyvmkALy;

		[CustomObfuscation(rename = false)]
		internal static WebplayerPlatform webplayerPlatform => RnABkzMQAOJCrSsDFjSEarshMOcm;

		[CustomObfuscation(rename = false)]
		internal static EditorPlatform editorPlatform => jVrMZpwBfxvSHnqDpPQGNDMVTIIx;

		[CustomObfuscation(rename = false)]
		internal static bool checkNeverPressed
		{
			get
			{
				if (yYubrrhmzcQeEpBSLvzpxyvmkALy == Platform.Linux && TxCplICMnTZpPiXwadmbEnzHOQTt)
				{
					return true;
				}
				if (yYubrrhmzcQeEpBSLvzpxyvmkALy == Platform.OSX && (TxCplICMnTZpPiXwadmbEnzHOQTt || primaryInputManager.inputSourceType == InputSource.OSX))
				{
					return true;
				}
				if (UnityTools.isAndroidPlatform && TxCplICMnTZpPiXwadmbEnzHOQTt)
				{
					return true;
				}
				if (yYubrrhmzcQeEpBSLvzpxyvmkALy == Platform.Webplayer && RnABkzMQAOJCrSsDFjSEarshMOcm == WebplayerPlatform.OSX)
				{
					return true;
				}
				if (yYubrrhmzcQeEpBSLvzpxyvmkALy == Platform.WebGL)
				{
					return true;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isEditor => jVrMZpwBfxvSHnqDpPQGNDMVTIIx != EditorPlatform.None;

		[CustomObfuscation(rename = false)]
		internal static Guid defaultHardwareJoystickMapGuid
		{
			get
			{
				if (!WugjmBgLTJdXmPxOcjVoTkTTUlEC)
				{
					return Guid.Empty;
				}
				return hiPSsPHyqmWsHPcaZFVmfgZvUkXl.defaultHardwareJoystickMapGuid;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isRunningInEditMode => TqFvsqFPtvxFgaAuaSQmzdpsAUCw;

		[CustomObfuscation(rename = false)]
		internal static bool isEditorPaused => UnityTools.externalTools.isEditorPaused;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTime => ZUxrPexAiNmADkUhVBcmMDJmGRUEA.fhOXJbKIWDSpQSCPcUtKHQNYUtSo;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTimePrev => ZUxrPexAiNmADkUhVBcmMDJmGRUEA.wYgWLrAmBbBKeMvqISEkeuGghttU;

		[CustomObfuscation(rename = false)]
		internal static double realTime
		{
			get
			{
				if (!WugjmBgLTJdXmPxOcjVoTkTTUlEC)
				{
					return 0.0;
				}
				return ZUxrPexAiNmADkUhVBcmMDJmGRUEA.rYNzwnlqcwjaWmZpmZjTyxspnfrG;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static int currentUnityFrame
		{
			get
			{
				if (!WugjmBgLTJdXmPxOcjVoTkTTUlEC)
				{
					return 0;
				}
				return mDJAaKOdFaHFEnzSxHhKjsuSNViQ.bBosxDPUruIZPrYsvTuGmldoDEeEA;
			}
		}

		private static bool qqwKRTTCiVRupoSPceNhaCkfJYPf
		{
			get
			{
				if (UnityTools.unityVersion >= UnityTools.UnityVersion.UNITY_5_1)
				{
					return uNuydNmiuTSHDwqDgoEYnqmXBfFu == "Game";
				}
				return uNuydNmiuTSHDwqDgoEYnqmXBfFu == "UnityEditor.GameView";
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isAllowedEditorWindowFocused
		{
			get
			{
				if (wzlteJdDPZYmtywPXjGXrWAAIKvJ.allowInputInEditorSceneView && UnityTools.externalTools.IsEditorSceneViewFocused())
				{
					return true;
				}
				if (!ROiCsEApoinzMWBXeDPkialwGtmV)
				{
					return qqwKRTTCiVRupoSPceNhaCkfJYPf;
				}
				return true;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isUnityEditorFocused
		{
			get
			{
				if (NeEVntlckjaQuIKbzjPdCmfDUwQhc is INativePlatformHelper nativePlatformHelper)
				{
					return nativePlatformHelper.isApplicationFocused;
				}
				return ROiCsEApoinzMWBXeDPkialwGtmV;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isWindowsStandaloneWebplayerOrEditorPlatform
		{
			get
			{
				if (!WugjmBgLTJdXmPxOcjVoTkTTUlEC)
				{
					return false;
				}
				if (!TxCplICMnTZpPiXwadmbEnzHOQTt)
				{
					return false;
				}
				if (yYubrrhmzcQeEpBSLvzpxyvmkALy != Platform.Windows && (yYubrrhmzcQeEpBSLvzpxyvmkALy != Platform.Webplayer || RnABkzMQAOJCrSsDFjSEarshMOcm != WebplayerPlatform.Windows))
				{
					return jVrMZpwBfxvSHnqDpPQGNDMVTIIx == EditorPlatform.Windows;
				}
				return true;
			}
		}

		private static bool EjklkcLEkgCKPPtXGzieXnkLpvcn
		{
			get
			{
				if (!WugjmBgLTJdXmPxOcjVoTkTTUlEC)
				{
					return false;
				}
				if (!mDJAaKOdFaHFEnzSxHhKjsuSNViQ.ReBxGqZauQYfDMdMRzrynaBQqHgk.value)
				{
					if (GJIoqpeFlSgtXTGhUyqxqppuBrcw)
					{
						return false;
					}
					if ((!isEditor || !isUnityEditorFocused) && !mDJAaKOdFaHFEnzSxHhKjsuSNViQ.DKkoVeRlcTlrDfzlNfaSsWRFpacf.value)
					{
						return false;
					}
				}
				return true;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFocused
		{
			get
			{
				if (WugjmBgLTJdXmPxOcjVoTkTTUlEC)
				{
					return mDJAaKOdFaHFEnzSxHhKjsuSNViQ.ReBxGqZauQYfDMdMRzrynaBQqHgk.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsPaused
		{
			get
			{
				if (WugjmBgLTJdXmPxOcjVoTkTTUlEC)
				{
					return mDJAaKOdFaHFEnzSxHhKjsuSNViQ.ZErbmgGKzLFfTADIgkNdTOsxrHei.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFullScreen
		{
			get
			{
				if (WugjmBgLTJdXmPxOcjVoTkTTUlEC)
				{
					return mDJAaKOdFaHFEnzSxHhKjsuSNViQ.lXlYlCwcWfqJtdFDRnkejMdSWZnu.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationRunInBackground
		{
			get
			{
				if (WugjmBgLTJdXmPxOcjVoTkTTUlEC)
				{
					return mDJAaKOdFaHFEnzSxHhKjsuSNViQ.DKkoVeRlcTlrDfzlNfaSsWRFpacf.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool timeScaleIsPaused
		{
			get
			{
				if (WugjmBgLTJdXmPxOcjVoTkTTUlEC)
				{
					return mDJAaKOdFaHFEnzSxHhKjsuSNViQ.pmlAdSKskpmHDTCBQJwHHEiYeTVj.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static InputManager_Base rewiredInputManager => SiXOGfYAfmKJkNWCcNWqoXmYteDF;

		[CustomObfuscation(rename = false)]
		internal static PlatformInputManager primaryInputManager
		{
			get
			{
				if (!WugjmBgLTJdXmPxOcjVoTkTTUlEC)
				{
					QHOfuRBfROqATHkfjNXRkCQNBPPHA();
					return null;
				}
				return NeEVntlckjaQuIKbzjPdCmfDUwQhc.primaryInputManager;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static IControllerAssigner controllerAssigner
		{
			get
			{
				return bltTmWXirvaIOleaXPdbdsbeBTMy;
			}
			set
			{
				bltTmWXirvaIOleaXPdbdsbeBTMy = value;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static RewiredVersion rewiredVersion => new RewiredVersion(programVersion);

		[CustomObfuscation(rename = false)]
		internal static int timeScalePauseChangedCount => XJXbGFtGtnhWdoMxcPMcrEuyEJMB;

		public static event Action<ControllerStatusChangedEventArgs> ControllerConnectedEvent
		{
			add
			{
				uUxqbKykYtnbOhmGcbIOzEbsChjC += value;
			}
			remove
			{
				uUxqbKykYtnbOhmGcbIOzEbsChjC -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerPreDisconnectEvent
		{
			add
			{
				NHHaaThhSabelwfjItiCWFRUbepK += value;
			}
			remove
			{
				NHHaaThhSabelwfjItiCWFRUbepK -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerDisconnectedEvent
		{
			add
			{
				qJPVMsrpeQQFEjEVuiVIjIRxfwODA += value;
			}
			remove
			{
				qJPVMsrpeQQFEjEVuiVIjIRxfwODA -= value;
			}
		}

		public static event Action InputSourceUpdateEvent
		{
			add
			{
				lFLErzhpSszWWqCbIMeYIwgHLfIk += value;
			}
			remove
			{
				lFLErzhpSszWWqCbIMeYIwgHLfIk -= value;
			}
		}

		public static event Action EditorRecompileEvent
		{
			add
			{
				PfhNdKFZrqpYFOcMLVpsyASQRUFe += value;
			}
			remove
			{
				PfhNdKFZrqpYFOcMLVpsyASQRUFe -= value;
			}
		}

		public static event Action PreShutDownEvent
		{
			add
			{
				TXZCntKnIwLFhaYUnYhujuhqbGcIA += value;
			}
			remove
			{
				TXZCntKnIwLFhaYUnYhujuhqbGcIA -= value;
			}
		}

		public static event Action ShutDownEvent
		{
			add
			{
				DuHIRYzEpJscGdGxPQRbnnJkbwUm += value;
			}
			remove
			{
				DuHIRYzEpJscGdGxPQRbnnJkbwUm -= value;
			}
		}

		public static event Action InitializedEvent
		{
			add
			{
				XvvLHZiTqybeOnBeNeJHkXpzEQOR += value;
			}
			remove
			{
				XvvLHZiTqybeOnBeNeJHkXpzEQOR -= value;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationFocusChangedEvent
		{
			add
			{
				_ApplicationFocusChangedEvent = (Action<bool>)Delegate.Combine(_ApplicationFocusChangedEvent, value);
			}
			remove
			{
				_ApplicationFocusChangedEvent = (Action<bool>)Delegate.Remove(_ApplicationFocusChangedEvent, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationPauseChangedEvent
		{
			add
			{
				_ApplicationPauseChangedEvent = (Action<bool>)Delegate.Combine(_ApplicationPauseChangedEvent, value);
			}
			remove
			{
				_ApplicationPauseChangedEvent = (Action<bool>)Delegate.Remove(_ApplicationPauseChangedEvent, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action EarlyUpdateEvent
		{
			add
			{
				NwyqrQDOgrhNZxfeJIQnJxLAMsiD = (Action)Delegate.Combine(NwyqrQDOgrhNZxfeJIQnJxLAMsiD, value);
			}
			remove
			{
				NwyqrQDOgrhNZxfeJIQnJxLAMsiD = (Action)Delegate.Remove(NwyqrQDOgrhNZxfeJIQnJxLAMsiD, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> BeforeTimeManagerUpdateEvent
		{
			add
			{
				NbxPBpDGdSnkNTIBaCpIGhcAFKzS = (Action<UpdateLoopType>)Delegate.Combine(NbxPBpDGdSnkNTIBaCpIGhcAFKzS, value);
			}
			remove
			{
				NbxPBpDGdSnkNTIBaCpIGhcAFKzS = (Action<UpdateLoopType>)Delegate.Remove(NbxPBpDGdSnkNTIBaCpIGhcAFKzS, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateStartedEvent
		{
			add
			{
				fEyFTXJIyqFrRiaGPmPOKYiXrpMpA = (Action<UpdateLoopType>)Delegate.Combine(fEyFTXJIyqFrRiaGPmPOKYiXrpMpA, value);
			}
			remove
			{
				fEyFTXJIyqFrRiaGPmPOKYiXrpMpA = (Action<UpdateLoopType>)Delegate.Remove(fEyFTXJIyqFrRiaGPmPOKYiXrpMpA, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateEndedEvent
		{
			add
			{
				GOhWwIBmIEkVLptccqJrlYPWQNjo = (Action<UpdateLoopType>)Delegate.Combine(GOhWwIBmIEkVLptccqJrlYPWQNjo, value);
			}
			remove
			{
				GOhWwIBmIEkVLptccqJrlYPWQNjo = (Action<UpdateLoopType>)Delegate.Remove(GOhWwIBmIEkVLptccqJrlYPWQNjo, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action LateUpdateEvent
		{
			add
			{
				lTRzFwsWLjdEHOcBBWVAHZrVeUEb = (Action)Delegate.Combine(lTRzFwsWLjdEHOcBBWVAHZrVeUEb, value);
			}
			remove
			{
				lTRzFwsWLjdEHOcBBWVAHZrVeUEb = (Action)Delegate.Remove(lTRzFwsWLjdEHOcBBWVAHZrVeUEb, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationIsFullScreenChangedEvent
		{
			add
			{
				vbzmbYhcTVyQQqNoMgxFBBMycPzm = (Action<bool>)Delegate.Combine(vbzmbYhcTVyQQqNoMgxFBBMycPzm, value);
			}
			remove
			{
				vbzmbYhcTVyQQqNoMgxFBBMycPzm = (Action<bool>)Delegate.Remove(vbzmbYhcTVyQQqNoMgxFBBMycPzm, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationRunInBackgroundChangedEvent
		{
			add
			{
				AiwwgowAZHkjjumMJLoHmyUxPNc = (Action<bool>)Delegate.Combine(AiwwgowAZHkjjumMJLoHmyUxPNc, value);
			}
			remove
			{
				AiwwgowAZHkjjumMJLoHmyUxPNc = (Action<bool>)Delegate.Remove(AiwwgowAZHkjjumMJLoHmyUxPNc, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> TimeScalePauseChangedEvent
		{
			add
			{
				qAyOJjxNkXyXmUuiWaPRclVmabHc = (Action<bool>)Delegate.Combine(qAyOJjxNkXyXmUuiWaPRclVmabHc, value);
			}
			remove
			{
				qAyOJjxNkXyXmUuiWaPRclVmabHc = (Action<bool>)Delegate.Remove(qAyOJjxNkXyXmUuiWaPRclVmabHc, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<FullScreenMode> ApplicationFullScreenModeChangedEvent
		{
			add
			{
				wQSLzQqYYpPehzigcjyghVnuzbhj = (Action<FullScreenMode>)Delegate.Combine(wQSLzQqYYpPehzigcjyghVnuzbhj, value);
			}
			remove
			{
				wQSLzQqYYpPehzigcjyghVnuzbhj = (Action<FullScreenMode>)Delegate.Remove(wQSLzQqYYpPehzigcjyghVnuzbhj, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action SceneLoadedEvent
		{
			add
			{
				diEhnNEaBdaxAMaZbpRQmxtTdbmh = (Action)Delegate.Combine(diEhnNEaBdaxAMaZbpRQmxtTdbmh, value);
			}
			remove
			{
				diEhnNEaBdaxAMaZbpRQmxtTdbmh = (Action)Delegate.Remove(diEhnNEaBdaxAMaZbpRQmxtTdbmh, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> EditorPauseChangedEvent
		{
			add
			{
				RAmsoXPJnXBdANCIOckjGpSknLhBb = (Action<bool>)Delegate.Combine(RAmsoXPJnXBdANCIOckjGpSknLhBb, value);
			}
			remove
			{
				RAmsoXPJnXBdANCIOckjGpSknLhBb = (Action<bool>)Delegate.Remove(RAmsoXPJnXBdANCIOckjGpSknLhBb, value);
			}
		}

		static ReInput()
		{
			ROiCsEApoinzMWBXeDPkialwGtmV = true;
			MuWmAgklbHmoQdkzxECOwDPeFRUaA = -1;
			jlBEqHKjUDDhVTIkPgBNxXejleLHA = -1;
			_id = -1;
			avMksdsvFXITrTdrbcRLuujLfqRQ = 0;
			anKnhHkJHASgpFNEmYksuYjcudyn = UnityTouch.bYRFvehkIbyygUUNrYjJaMGIwPdr;
			nNnrEVdmXbYiFmjBqnWpuARQkHoR = PlayerHelper.XizyukbhlOxmCVRsQucvFuONrdIW;
			EaKOGphjFSDlbhqBGTVMhxOJzzUV = ControllerHelper.pJDMGevuVCXoaIrbxyhEgKGtMfaJ;
			vxwLsuDMisPyzQOPQPEoWAACCwrhA = MappingHelper.afbXnOENdMgXBEamUofpoAxsXAOl;
			jTZXZyRvnjsLVBtGVbCzarzUkwfb = TimeHelper.ULdESjaAHkIrXDdgHqOgFSYlIzBJB;
			tJVdMzqLSMVjbTkBIETodqpmwNDE = ConfigHelper.ZcYrKCkJuNJCAMGMyerfLChsULiL;
			ZWYeLkxGEvWBGFmJLGduaCZpwpNJ = LocalizationHelper.BbDtvNZzjkwYPjUMWFeyUUWrqHFL;
			UCSnDESAmFQbBSTXlUDbxpCFHoVy = GlyphHelper.XVvXDYLbvEAmVlwdhtTNnPjaUGV;
			uUxqbKykYtnbOhmGcbIOzEbsChjC = new SafeAction<ControllerStatusChangedEventArgs>(uymibArYmfqrNrQqBtYwAqArflTX._003C_003E9.MHJEefRZlaAKeHBDniycdHXJjpOx);
			NHHaaThhSabelwfjItiCWFRUbepK = new SafeAction<ControllerStatusChangedEventArgs>(uymibArYmfqrNrQqBtYwAqArflTX._003C_003E9.hAdnbhKkBLkGfFDcbqjFHKSeSzb);
			qJPVMsrpeQQFEjEVuiVIjIRxfwODA = new SafeAction<ControllerStatusChangedEventArgs>(uymibArYmfqrNrQqBtYwAqArflTX._003C_003E9.PhDBumrinkKwgeMXOsvlEKTnKrDl);
			lFLErzhpSszWWqCbIMeYIwgHLfIk = new SafeAction(uymibArYmfqrNrQqBtYwAqArflTX._003C_003E9.qnfkSyjRROLLmDjhmSxVEAGPcMqK);
			PfhNdKFZrqpYFOcMLVpsyASQRUFe = new SafeAction(uymibArYmfqrNrQqBtYwAqArflTX._003C_003E9.YELbmxalBVovKCfoiVaMLGpIBZEOB);
			TXZCntKnIwLFhaYUnYhujuhqbGcIA = new SafeAction(uymibArYmfqrNrQqBtYwAqArflTX._003C_003E9.bGciilELSVVdkUkmpKTVvYoNHXkJ);
			DuHIRYzEpJscGdGxPQRbnnJkbwUm = new SafeAction(uymibArYmfqrNrQqBtYwAqArflTX._003C_003E9.lZjEbhkhMwYnMXOOqNYUSpbjKsZE);
			XvvLHZiTqybeOnBeNeJHkXpzEQOR = new SafeAction(uymibArYmfqrNrQqBtYwAqArflTX._003C_003E9.VtHLeVWqnQIjtpOkyJswuIYHrXMK);
			SafeDelegate.S_ExceptionHandler = uymibArYmfqrNrQqBtYwAqArflTX._003C_003E9.WTgGlpCIVpnRzZKMjFvwumtUAAqe;
		}

		private static void LLkLObPcyoaGcHcUvgEwypWYRXgX()
		{
			SVMPRXBmdWAUjHJyiieHGmGhJwPJb++;
		}

		private static void xKHRHpPEvhWIfJqbEhJJRINtzIzW()
		{
			SVMPRXBmdWAUjHJyiieHGmGhJwPJb--;
			if (SVMPRXBmdWAUjHJyiieHGmGhJwPJb < 0)
			{
				SVMPRXBmdWAUjHJyiieHGmGhJwPJb = 0;
			}
		}

		public static void Update()
		{
			if (WugjmBgLTJdXmPxOcjVoTkTTUlEC)
			{
				if (wzlteJdDPZYmtywPXjGXrWAAIKvJ.updateMode != UpdateMode.Manual)
				{
					Logger.LogError("Rewired cannot be updated manually unless Update Mode is set to Manual.");
				}
				else
				{
					SiXOGfYAfmKJkNWCcNWqoXmYteDF.DoUpdate(UpdateLoopType.Update, UpdateLoopSetting.Update);
				}
			}
		}

		public static void Reset()
		{
			if (WugjmBgLTJdXmPxOcjVoTkTTUlEC && !(SiXOGfYAfmKJkNWCcNWqoXmYteDF == null))
			{
				if (OJOMZlJOGXljekIvoskoxARRkUuo)
				{
					Logger.LogError("You are attempting to reset Rewired in the middle of its update routine, probably in an event callback. This is inherently unsafe and would lead to undefined behavior. Rewired will not be reset.");
				}
				else
				{
					SiXOGfYAfmKJkNWCcNWqoXmYteDF.ResetAll();
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool IsInputAllowed(ControllerType controllerType)
		{
			if (!EjklkcLEkgCKPPtXGzieXnkLpvcn)
			{
				return false;
			}
			if (jVrMZpwBfxvSHnqDpPQGNDMVTIIx != EditorPlatform.None && (controllerType == ControllerType.Keyboard || controllerType == ControllerType.Mouse))
			{
				if (GJIoqpeFlSgtXTGhUyqxqppuBrcw)
				{
					if (!mDJAaKOdFaHFEnzSxHhKjsuSNViQ.ReBxGqZauQYfDMdMRzrynaBQqHgk.value)
					{
						return false;
					}
				}
				else if (!isAllowedEditorWindowFocused)
				{
					return false;
				}
			}
			return true;
		}

		private static void rUlAFpkiMbRosbJOcLIwvpLobQncA()
		{
			yYubrrhmzcQeEpBSLvzpxyvmkALy = UnityTools.platform;
			RnABkzMQAOJCrSsDFjSEarshMOcm = UnityTools.webplayerPlatform;
			jVrMZpwBfxvSHnqDpPQGNDMVTIIx = UnityTools.editorPlatform;
		}

		internal static void zBnIqvHAhplzNGiaaStZTPeYRaIr(InputManager_Base P_0, Func<ConfigVars, object> P_1, ConfigVars P_2, ControllerDataFiles P_3, UserData P_4, Func<UnityTools.uaEpAarlcIaaOoCOqAQxcyWtCvMkA> P_5, Action<Platform> P_6, Action<InputManager_Base.GUoeUqIPflOMcxuTTOQzYtRhrIFM> P_7)
		{
			try
			{
				LLkLObPcyoaGcHcUvgEwypWYRXgX();
				_id = avMksdsvFXITrTdrbcRLuujLfqRQ;
				avMksdsvFXITrTdrbcRLuujLfqRQ++;
				WugjmBgLTJdXmPxOcjVoTkTTUlEC = true;
				oLNgxlxGxPCFzIJWpXvtDvMgOazu = true;
				TqFvsqFPtvxFgaAuaSQmzdpsAUCw = UnityTools.isEditor && !Application.isPlaying;
				if (UnityTools.isEditor)
				{
					CheckRewiredVersionCompatibility();
				}
				SiXOGfYAfmKJkNWCcNWqoXmYteDF = P_0;
				wzlteJdDPZYmtywPXjGXrWAAIKvJ = P_2;
				rUlAFpkiMbRosbJOcLIwvpLobQncA();
				if (P_2.logToScreen)
				{
					Logger.logToScreen = true;
				}
				UnityTools.externalTools.EditorPausedStateChangedEvent += hhIFkyuAyfTdutfLEwVcADBqtSiU;
				hiPSsPHyqmWsHPcaZFVmfgZvUkXl = P_3;
				CMuKNpKzoZWoovDXKkZgsiLlOCFy = P_4;
				YpCSnSudifTSMpgspQIKIrvkDhjD = new TimerAbs(1.0);
				ZUxrPexAiNmADkUhVBcmMDJmGRUEA = new vPtPjlHynTaMHkqnhlwwFawlvjhN();
				LocalizationManager.Initialize();
				GlyphManager.Initialize();
				P_4.MOejVWshIoocysdUmWMQAUxOgKHH();
				ThreadSafeUnityInput.Initialize();
				mDJAaKOdFaHFEnzSxHhKjsuSNViQ = new SqccyWYBnZsgVjUSCBiSqdoenwLG();
				if (!UnityTools.isEditor)
				{
					ROiCsEApoinzMWBXeDPkialwGtmV = Application.isFocused;
				}
				mDJAaKOdFaHFEnzSxHhKjsuSNViQ.ReBxGqZauQYfDMdMRzrynaBQqHgk.Set(ROiCsEApoinzMWBXeDPkialwGtmV);
				mDJAaKOdFaHFEnzSxHhKjsuSNViQ.ReBxGqZauQYfDMdMRzrynaBQqHgk.Use();
				if (jVrMZpwBfxvSHnqDpPQGNDMVTIIx != EditorPlatform.None)
				{
					mDJAaKOdFaHFEnzSxHhKjsuSNViQ.ReBxGqZauQYfDMdMRzrynaBQqHgk.getValueDelegate = uymibArYmfqrNrQqBtYwAqArflTX._003C_003E9.bNXmmBnosxSRvUmENcwHUNKvZzVV;
					if (TqFvsqFPtvxFgaAuaSQmzdpsAUCw)
					{
						ROiCsEApoinzMWBXeDPkialwGtmV = qqwKRTTCiVRupoSPceNhaCkfJYPf;
					}
					mDJAaKOdFaHFEnzSxHhKjsuSNViQ.ReBxGqZauQYfDMdMRzrynaBQqHgk.Set(isUnityEditorFocused && isAllowedEditorWindowFocused);
				}
				jzmeMmEMclcKefgBjhDTEgPAzsIbc();
				List<ICustomPlatformInitializer> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<ICustomPlatformInitializer>(P_0.gameObject);
				if (componentsInSelfAndChildren != null)
				{
					for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
					{
						Behaviour behaviour = componentsInSelfAndChildren[i] as Behaviour;
						if (behaviour == null || !behaviour.enabled || !behaviour.gameObject.activeInHierarchy)
						{
							continue;
						}
						CustomPlatformInitOptions customPlatformInitOptions = componentsInSelfAndChildren[i].GetCustomPlatformInitOptions();
						if (customPlatformInitOptions != null)
						{
							XKZBcbGtoHHVfKdsghmQDHfhSpIfA.ASHOODGilyBECGFESwuuceCIVuaO(customPlatformInitOptions);
							bool num = jVrMZpwBfxvSHnqDpPQGNDMVTIIx != EditorPlatform.None;
							P_7(new InputManager_Base.GUoeUqIPflOMcxuTTOQzYtRhrIFM
							{
								QGiJXeIaJmTrNdhSQiTfbyFcRLZH = Platform.Custom,
								ZazFonbKqpDfGigtglooKsbBEUaqC = EditorPlatform.None,
								JPVnoCQmDFbQJcbOyJwErVHZJZfc = WebplayerPlatform.None
							});
							rUlAFpkiMbRosbJOcLIwvpLobQncA();
							ZUxrPexAiNmADkUhVBcmMDJmGRUEA = new vPtPjlHynTaMHkqnhlwwFawlvjhN();
							if (num)
							{
								Logger.LogWarning("A custom platform is in use. All input will be managed by user-defined custom platform handling.");
							}
							break;
						}
					}
				}
				kjwVOdBCRJiRoMlPrKiZSyeSbUlN(P_1, P_5(), P_6);
				UnityInputHelper.Initialize(P_2, NeEVntlckjaQuIKbzjPdCmfDUwQhc.inputSourceType);
				QYXTlPbvvfyHDodSqaxHRoHhFdw = new tJoKaBpeixEcmjlcjTQCbZQpjqFR(P_4.GetActions_Copy());
				jFidDAJTYMYSSrBGXbdjHWSiLLLfB = new ruLXWgGHNYKBNoYhWlYmLdtbexbY(P_2, NeEVntlckjaQuIKbzjPdCmfDUwQhc);
				kaDCuNAiSdnlkLeWRajALqrXMggab = new XCvMDQBADcmACIDQJmYqAKqBfrW(P_2);
				NeEVntlckjaQuIKbzjPdCmfDUwQhc.DeviceConnectedEvent += zSzayTbySOipgfrjwcLTyiISvZQO;
				NeEVntlckjaQuIKbzjPdCmfDUwQhc.DeviceDisconnectedEvent += gcLRmJsrjOquxopzRTxtOYCWQxwD;
				NeEVntlckjaQuIKbzjPdCmfDUwQhc.UpdateControllerInfoEvent += woWHLXNOUPdWDPYrzDbNMklBwEge;
				jFidDAJTYMYSSrBGXbdjHWSiLLLfB.PTAfSvaPqwFLLQaNUEhITJUdepvI += aAmwUfhIhjIKAkrywrARkBmPgAFuA;
				jFidDAJTYMYSSrBGXbdjHWSiLLLfB.ldzDrzaMWtEtHkmsZNkiodTCOZWTA += kaDCuNAiSdnlkLeWRajALqrXMggab.bhugyPdMIslQsLJplczhlDapQQOCb;
				ThreadSafeUnityInput.PostInitialize();
				cJhLGwNpmiuKmQCJUbnEhlDoLJXMA();
				ThreadSafeUnityInput.PostInitialize2();
				ssZCPbHVsxUheYbwcZKRsCxnNTtE = UnityTools.GetComponent<UserDataStore>(SiXOGfYAfmKJkNWCcNWqoXmYteDF);
				if (ssZCPbHVsxUheYbwcZKRsCxnNTtE != null)
				{
					ssZCPbHVsxUheYbwcZKRsCxnNTtE.Initialize();
				}
				uRRuLBuQawhzUdjKyUtztTuVDSFS();
				oLNgxlxGxPCFzIJWpXvtDvMgOazu = false;
				if (TqFvsqFPtvxFgaAuaSQmzdpsAUCw)
				{
					Logger.Log("Rewired is running in Edit mode.");
				}
				if (XvvLHZiTqybeOnBeNeJHkXpzEQOR != null)
				{
					XvvLHZiTqybeOnBeNeJHkXpzEQOR.Invoke();
				}
			}
			catch (Exception)
			{
				WugjmBgLTJdXmPxOcjVoTkTTUlEC = false;
				oLNgxlxGxPCFzIJWpXvtDvMgOazu = false;
				throw;
			}
			finally
			{
				xKHRHpPEvhWIfJqbEhJJRINtzIzW();
			}
		}

		internal static void vXAwdNhgZrEYFjxqUIsOHJXjndVP()
		{
			try
			{
				LLkLObPcyoaGcHcUvgEwypWYRXgX();
				if (ZUxrPexAiNmADkUhVBcmMDJmGRUEA != null)
				{
					ZUxrPexAiNmADkUhVBcmMDJmGRUEA.OMqpcgDMZdXDJuulrObiOHhqIcWm();
				}
				if (configVars.deferControllerConnectedEventsOnStart)
				{
					for (int i = 0; i < jFidDAJTYMYSSrBGXbdjHWSiLLLfB.BZmSVymcSLcbcCvESSRKrvmAIKVl; i++)
					{
						Joystick joystick = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.FmfxwfhlxDwfpqdOLrqFojAgTbO[i];
						gsBENFAnvloBkClpcrZcHrzCCJVY(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
					}
				}
			}
			finally
			{
				xKHRHpPEvhWIfJqbEhJJRINtzIzW();
			}
		}

		internal static void TGaMaXhFzXnhKLXmShCFDcpXihBbA(UpdateLoopType P_0)
		{
			if (!WugjmBgLTJdXmPxOcjVoTkTTUlEC)
			{
				return;
			}
			try
			{
				LLkLObPcyoaGcHcUvgEwypWYRXgX();
				tIifbbkWXyVmcrhYvnhSkTRljHgHb(P_0);
				if ((uint)P_0 <= 1u)
				{
					rdCSMOGVlWQFAwvjIurBBEItCGhcA(P_0);
				}
			}
			finally
			{
				xKHRHpPEvhWIfJqbEhJJRINtzIzW();
			}
		}

		private static void tIifbbkWXyVmcrhYvnhSkTRljHgHb(UpdateLoopType P_0)
		{
			if (mDJAaKOdFaHFEnzSxHhKjsuSNViQ != null)
			{
				mDJAaKOdFaHFEnzSxHhKjsuSNViQ.LAjGlCkKbTWOciNbVfdMbbEtJvVi();
			}
			Action<UpdateLoopType> nbxPBpDGdSnkNTIBaCpIGhcAFKzS = NbxPBpDGdSnkNTIBaCpIGhcAFKzS;
			if (nbxPBpDGdSnkNTIBaCpIGhcAFKzS != null)
			{
				try
				{
					nbxPBpDGdSnkNTIBaCpIGhcAFKzS(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.BeforeTimeManagerUpdateEvent", exception);
				}
			}
			ZUxrPexAiNmADkUhVBcmMDJmGRUEA.BeTRKigRknWaCEsUWXHMxZgafMzu(P_0);
		}

		private static void rdCSMOGVlWQFAwvjIurBBEItCGhcA(UpdateLoopType P_0)
		{
			int frameCount = Time.frameCount;
			if (MuWmAgklbHmoQdkzxECOwDPeFRUaA == frameCount)
			{
				return;
			}
			MuWmAgklbHmoQdkzxECOwDPeFRUaA = frameCount;
			if (UnityInputHelper.inputSourceType == InputSource.Fallback)
			{
				ThreadSafeUnityInput.ThreadFrameStart();
				UnityInputHelper.Update();
				ThreadSafeUnityInput.Update();
			}
			Action nwyqrQDOgrhNZxfeJIQnJxLAMsiD = NwyqrQDOgrhNZxfeJIQnJxLAMsiD;
			if (nwyqrQDOgrhNZxfeJIQnJxLAMsiD == null)
			{
				return;
			}
			try
			{
				nwyqrQDOgrhNZxfeJIQnJxLAMsiD();
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.EarlyUpdateEvent", exception);
			}
		}

		internal static void DGRDRJLckHHoiCnlaFiEZUUSZwuZ(UpdateLoopType P_0)
		{
			if (!WugjmBgLTJdXmPxOcjVoTkTTUlEC)
			{
				return;
			}
			try
			{
				LLkLObPcyoaGcHcUvgEwypWYRXgX();
				if (DpzeCDeMaNUxfpjNsyZnwPPsigHi != P_0)
				{
					DpzeCDeMaNUxfpjNsyZnwPPsigHi = P_0;
				}
				if (editorPlatform != EditorPlatform.None)
				{
					uNuydNmiuTSHDwqDgoEYnqmXBfFu = mDJAaKOdFaHFEnzSxHhKjsuSNViQ.woGCmidcCrKhdTyCdWyMCLJWwjhVA.value;
				}
				if (UnityInputHelper.inputSourceType == InputSource.UnityInputSystem)
				{
					int frameCount = Time.frameCount;
					if (jlBEqHKjUDDhVTIkPgBNxXejleLHA != frameCount || wzlteJdDPZYmtywPXjGXrWAAIKvJ.updateMode == UpdateMode.Manual)
					{
						jlBEqHKjUDDhVTIkPgBNxXejleLHA = frameCount;
						ThreadSafeUnityInput.ThreadFrameStart();
						UnityInputHelper.Update();
						ThreadSafeUnityInput.Update();
					}
				}
				if (xfZNQVtjBKMSfoeOsEPUkXdEqgniA)
				{
					if (YpCSnSudifTSMpgspQIKIrvkDhjD.Update())
					{
						xfZNQVtjBKMSfoeOsEPUkXdEqgniA = false;
						YpCSnSudifTSMpgspQIKIrvkDhjD.Clear();
					}
					else
					{
						bbBBrcEkOraOJcDTQuujlYEFiVof.XBwyxElbDvipkmxEJkxNCUhhMoSm(P_0);
					}
				}
				mDJAaKOdFaHFEnzSxHhKjsuSNViQ.mBwESeRIchBRYpavpRJmnCwWXkFR();
				Action<UpdateLoopType> action = fEyFTXJIyqFrRiaGPmPOKYiXrpMpA;
				if (action != null)
				{
					try
					{
						action(P_0);
					}
					catch (Exception exception)
					{
						HandleCallbackException("ReInput.UpdateStartedEvent", exception);
					}
				}
				NeEVntlckjaQuIKbzjPdCmfDUwQhc.Update(P_0);
				if (lFLErzhpSszWWqCbIMeYIwgHLfIk != null)
				{
					lFLErzhpSszWWqCbIMeYIwgHLfIk.Invoke();
				}
				jFidDAJTYMYSSrBGXbdjHWSiLLLfB.kJEzgSqpIgiZHnKtcfHjBsUpGltH(P_0);
				Action<UpdateLoopType> gOhWwIBmIEkVLptccqJrlYPWQNjo = GOhWwIBmIEkVLptccqJrlYPWQNjo;
				if (gOhWwIBmIEkVLptccqJrlYPWQNjo != null)
				{
					try
					{
						gOhWwIBmIEkVLptccqJrlYPWQNjo(P_0);
						return;
					}
					catch (Exception exception2)
					{
						HandleCallbackException("ReInput.UpdateEndedEvent", exception2);
						return;
					}
				}
			}
			finally
			{
				xKHRHpPEvhWIfJqbEhJJRINtzIzW();
			}
		}

		internal static void zOUjLvyJozHLMdVUGDmszNGYRVPw()
		{
			Action action = lTRzFwsWLjdEHOcBBWVAHZrVeUEb;
			if (action == null)
			{
				return;
			}
			try
			{
				LLkLObPcyoaGcHcUvgEwypWYRXgX();
				action();
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.LateUpdateEvent", exception);
			}
			finally
			{
				xKHRHpPEvhWIfJqbEhJJRINtzIzW();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static void EditorUpdate()
		{
			if (WugjmBgLTJdXmPxOcjVoTkTTUlEC && TqFvsqFPtvxFgaAuaSQmzdpsAUCw)
			{
				TGaMaXhFzXnhKLXmShCFDcpXihBbA(UpdateLoopType.Update);
				DGRDRJLckHHoiCnlaFiEZUUSZwuZ(UpdateLoopType.Update);
				zOUjLvyJozHLMdVUGDmszNGYRVPw();
			}
		}

		internal static void DCxEPMMgTUavrCziFGFVnfQfapJZA()
		{
			if (OJOMZlJOGXljekIvoskoxARRkUuo)
			{
				Logger.LogError("You are destroying or disabling the Rewired Input Manager while Rewired is in the middle of its update routine, probably in an event callback. This is inherently unsafe and will result in undefined behavior. You should never do this.");
			}
			if (TXZCntKnIwLFhaYUnYhujuhqbGcIA != null)
			{
				TXZCntKnIwLFhaYUnYhujuhqbGcIA.Invoke();
			}
			if (NeEVntlckjaQuIKbzjPdCmfDUwQhc != null)
			{
				NeEVntlckjaQuIKbzjPdCmfDUwQhc.OnDestroy();
			}
			hFHbkPzgQeyeBSyTqsmHaACuXVdp();
			if (DuHIRYzEpJscGdGxPQRbnnJkbwUm != null)
			{
				DuHIRYzEpJscGdGxPQRbnnJkbwUm.Invoke();
				DuHIRYzEpJscGdGxPQRbnnJkbwUm = null;
			}
		}

		internal static void nZEPMkmAENvYaCTRoLMVMYEgFPom()
		{
			if (PfhNdKFZrqpYFOcMLVpsyASQRUFe == null)
			{
				return;
			}
			try
			{
				LLkLObPcyoaGcHcUvgEwypWYRXgX();
				PfhNdKFZrqpYFOcMLVpsyASQRUFe.Invoke();
			}
			finally
			{
				xKHRHpPEvhWIfJqbEhJJRINtzIzW();
			}
		}

		internal static void IkhMwhbHIwuFjckVTaxeAiKIHkDiA(bool P_0)
		{
			ROiCsEApoinzMWBXeDPkialwGtmV = P_0;
			if (jVrMZpwBfxvSHnqDpPQGNDMVTIIx == EditorPlatform.None && WugjmBgLTJdXmPxOcjVoTkTTUlEC)
			{
				mDJAaKOdFaHFEnzSxHhKjsuSNViQ.ReBxGqZauQYfDMdMRzrynaBQqHgk.Set(P_0);
				mDJAaKOdFaHFEnzSxHhKjsuSNViQ.ReBxGqZauQYfDMdMRzrynaBQqHgk.TriggerEvent();
			}
		}

		internal static void eTuJPSwhbfqczVLoraZLaOKEECwq(bool P_0)
		{
			if (WugjmBgLTJdXmPxOcjVoTkTTUlEC)
			{
				mDJAaKOdFaHFEnzSxHhKjsuSNViQ.ZErbmgGKzLFfTADIgkNdTOsxrHei.Set(P_0);
				mDJAaKOdFaHFEnzSxHhKjsuSNViQ.ZErbmgGKzLFfTADIgkNdTOsxrHei.TriggerEvent();
			}
		}

		internal static void nTQfRHaFtlMkQHevHFksJHmFnpRtc()
		{
			if (!WugjmBgLTJdXmPxOcjVoTkTTUlEC)
			{
				return;
			}
			Action action = diEhnNEaBdaxAMaZbpRQmxtTdbmh;
			if (action == null)
			{
				return;
			}
			try
			{
				action();
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.SceneLoadedEvent", exception);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static HardwareJoystickMap_InputManager GetHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			return hiPSsPHyqmWsHPcaZFVmfgZvUkXl.BpSxdsofGUQwqarnncHmRXWOIyuD(bridgedController);
		}

		internal static HardwareJoystickMap QkBdsatCynGRQxrtNpstMBAHtFjP(Guid P_0)
		{
			return hiPSsPHyqmWsHPcaZFVmfgZvUkXl.GetHardwareJoystickMap(P_0);
		}

		internal static HardwareJoystickTemplateMap YpzVZXqiKvBsMXgoepwiqXNIYxGb(Guid P_0)
		{
			return hiPSsPHyqmWsHPcaZFVmfgZvUkXl.GetJoystickTemplate(P_0);
		}

		internal static yEMXOGECwzMVyBoTWRRwImnnslF TnoFTDOTIhrtqdBSnqaAenKTnBzK(Guid P_0)
		{
			return hiPSsPHyqmWsHPcaZFVmfgZvUkXl.TDSpxLZKcySeQYfsUNAqrMPYDkrgA(P_0);
		}

		internal static IHardwareControllerTemplateMap ppSRPWiLADzVuRYLseQODUFXcaUr(Guid P_0)
		{
			return hiPSsPHyqmWsHPcaZFVmfgZvUkXl.GetControllerTemplate(P_0);
		}

		internal static IHardwareControllerTemplateMap eAylNDjsDsrRgMCQQRdVtdwWehhc(Guid P_0)
		{
			return hiPSsPHyqmWsHPcaZFVmfgZvUkXl.AHogRrciwBECTBWdNmGxWTbAAxUQA(P_0);
		}

		internal static IList<yEMXOGECwzMVyBoTWRRwImnnslF> fdgLyKGpMsUbNwGYDfqkesKGDNchb(Guid P_0)
		{
			HardwareJoystickMap hardwareJoystickMap = hiPSsPHyqmWsHPcaZFVmfgZvUkXl.GetHardwareJoystickMap(P_0);
			if (hardwareJoystickMap == null)
			{
				return EmptyObjects<yEMXOGECwzMVyBoTWRRwImnnslF>.EmptyReadOnlyIListT;
			}
			string[] templateGuidsOrig = hardwareJoystickMap.GetTemplateGuidsOrig();
			if (templateGuidsOrig == null || templateGuidsOrig.Length == 0)
			{
				return EmptyObjects<yEMXOGECwzMVyBoTWRRwImnnslF>.EmptyReadOnlyIListT;
			}
			List<yEMXOGECwzMVyBoTWRRwImnnslF> list = null;
			for (int i = 0; i < templateGuidsOrig.Length; i++)
			{
				Guid guid;
				try
				{
					guid = new Guid(templateGuidsOrig[i]);
				}
				catch
				{
					Logger.LogWarning("Controller Template GUID is invalid: " + templateGuidsOrig[i]);
					continue;
				}
				yEMXOGECwzMVyBoTWRRwImnnslF yEMXOGECwzMVyBoTWRRwImnnslF2 = TnoFTDOTIhrtqdBSnqaAenKTnBzK(guid);
				if (yEMXOGECwzMVyBoTWRRwImnnslF2 == null)
				{
					Logger.LogWarning("Controller Template was not found for GUID " + guid.ToString());
					continue;
				}
				if (list == null)
				{
					list = new List<yEMXOGECwzMVyBoTWRRwImnnslF>();
				}
				ListTools.AddIfUnique(list, yEMXOGECwzMVyBoTWRRwImnnslF2);
			}
			if (list == null)
			{
				return EmptyObjects<yEMXOGECwzMVyBoTWRRwImnnslF>.EmptyReadOnlyIListT;
			}
			return list;
		}

		[CustomObfuscation(rename = false)]
		internal static int GetNewJoystickId()
		{
			return jFidDAJTYMYSSrBGXbdjHWSiLLLfB.qDTJXOYmrJdDmfrNFZpffvfiDtiC();
		}

		[CustomObfuscation(rename = false)]
		internal static void HandleCallbackException(string source, Exception exception)
		{
			string msg = "An exception occurred inside an event handler or callback.\nSource: " + source + "\n\nThis happens if your event handler/callback code throws an exception. This means the error is in your code, not Rewired. Read the exception message and the stack trace carefully to find the source of the exception being thrown by your code.\n\nThis can also happen if you forget to unsubscribe to an event in a MonoBehaviour class and that object gets destroyed. Make sure you unsubscribe to events in OnDisable or OnDestroy. Rewired will attempt to continue running.\n\nException:\n" + ((exception.InnerException != null) ? exception.InnerException : exception);
			Logger.LogException((exception.InnerException != null) ? exception.InnerException : exception, msg, requiredThreadSafety: true);
		}

		[CustomObfuscation(rename = false)]
		internal static void HandleExternException(string source, Exception exception)
		{
			Logger.LogException((exception.InnerException != null) ? exception.InnerException : exception, string.Empty, requiredThreadSafety: true);
		}

		[CustomObfuscation(rename = false)]
		internal static void HandleExternalInterfaceException(string source, Exception exception)
		{
			string msg = "An exception occurred inside an external function call.\nSource: " + source + "\n\nThis happens if the external function throws an exception. This could indicate the error is in your code if Rewired is calling a function in an interface implementation you created. Read the exception message and the stack trace carefully to find the source of the exception being thrown.\n\nThis can also happen if you forget to unsubscribe to an event in a MonoBehaviour class and that object gets destroyed.\n\nException:\n" + ((exception.InnerException != null) ? exception.InnerException : exception);
			Logger.LogException((exception.InnerException != null) ? exception.InnerException : exception, msg, requiredThreadSafety: true);
		}

		internal static void ULbEgoDZFDMZbbzkKZNWvvPyiQxg()
		{
			if (WugjmBgLTJdXmPxOcjVoTkTTUlEC)
			{
				uRRuLBuQawhzUdjKyUtztTuVDSFS();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static void CheckRewiredVersionCompatibility()
		{
			if (UnityTools.unityVersionObj != null && 2022 != UnityTools.unityVersionObj.major)
			{
				erfclIHgRPwqGNFLPQNKFmZajhlZA();
			}
		}

		internal static float AjbGBgLXkztJCVBHOXhAYDgxKGiW()
		{
			return mDJAaKOdFaHFEnzSxHhKjsuSNViQ.oEZzpviILlZbqsTiTmDWLXQQbtWK.value;
		}

		[CustomObfuscation(rename = false)]
		internal static bool CheckInitialized()
		{
			if (!WugjmBgLTJdXmPxOcjVoTkTTUlEC)
			{
				Logger.LogError("Rewired is not initialized. You must have an active and enabled Rewired Input Manager in the scene before calling any part of the Rewired API.");
				return false;
			}
			return true;
		}

		[CustomObfuscation(rename = false)]
		internal static bool CheckInitialized(int reInputId)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			if (_id != reInputId)
			{
				Logger.LogError("You are attemping to access an object that was created by a previous session or different instance of Rewired and is no longer valid. When Rewired is reset or the Rewired Input Manager is disabled or destroyed, all old object references become invalid and can no longer be used. If you deinitialize Rewired, you cannot use locally stored Rewired objects obtained prior to deinitialization and you must get new objects from the Rewired API.");
				return false;
			}
			return true;
		}

		private static void cJhLGwNpmiuKmQCJUbnEhlDoLJXMA()
		{
			kaDCuNAiSdnlkLeWRajALqrXMggab.ZRUMpIOHrfPFzYHRzUVbZrbUvNMu();
			jFidDAJTYMYSSrBGXbdjHWSiLLLfB.OuhcZfgSkevBrldLORfxDuGYIfQGA(NeEVntlckjaQuIKbzjPdCmfDUwQhc.GetInputDataUpdateDelegate(), CMuKNpKzoZWoovDXKkZgsiLlOCFy.GetInputBehaviors_Copy());
			NeEVntlckjaQuIKbzjPdCmfDUwQhc.Initialize();
		}

		private static void hFHbkPzgQeyeBSyTqsmHaACuXVdp()
		{
			if (SiXOGfYAfmKJkNWCcNWqoXmYteDF != null)
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(SiXOGfYAfmKJkNWCcNWqoXmYteDF);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					componentsInSelfAndChildren[i].Deinitialize();
				}
			}
			SiXOGfYAfmKJkNWCcNWqoXmYteDF = null;
			NeEVntlckjaQuIKbzjPdCmfDUwQhc = null;
			QYXTlPbvvfyHDodSqaxHRoHhFdw = null;
			if (jFidDAJTYMYSSrBGXbdjHWSiLLLfB != null)
			{
				jFidDAJTYMYSSrBGXbdjHWSiLLLfB.Dispose();
			}
			jFidDAJTYMYSSrBGXbdjHWSiLLLfB = null;
			kaDCuNAiSdnlkLeWRajALqrXMggab = null;
			hiPSsPHyqmWsHPcaZFVmfgZvUkXl = null;
			if (CMuKNpKzoZWoovDXKkZgsiLlOCFy != null)
			{
				CMuKNpKzoZWoovDXKkZgsiLlOCFy.pyvHPwLnFHfhhhwUFaEhejWamAyac();
			}
			CMuKNpKzoZWoovDXKkZgsiLlOCFy = null;
			LocalizationHelper.fQGpbMxoARPlLuInATOMgapyYkC();
			GlyphHelper.LDheNbaWCcMShgGFVHcYmadUkBIiA();
			LocalizationManager.Deinitialize();
			GlyphManager.Deinitialize();
			bltTmWXirvaIOleaXPdbdsbeBTMy = null;
			WugjmBgLTJdXmPxOcjVoTkTTUlEC = false;
			wzlteJdDPZYmtywPXjGXrWAAIKvJ = null;
			DpzeCDeMaNUxfpjNsyZnwPPsigHi = UpdateLoopType.Update;
			TxCplICMnTZpPiXwadmbEnzHOQTt = false;
			yYubrrhmzcQeEpBSLvzpxyvmkALy = Platform.Windows;
			RnABkzMQAOJCrSsDFjSEarshMOcm = WebplayerPlatform.None;
			jVrMZpwBfxvSHnqDpPQGNDMVTIIx = EditorPlatform.None;
			xfZNQVtjBKMSfoeOsEPUkXdEqgniA = false;
			YpCSnSudifTSMpgspQIKIrvkDhjD = null;
			ZUxrPexAiNmADkUhVBcmMDJmGRUEA = null;
			uNuydNmiuTSHDwqDgoEYnqmXBfFu = null;
			GJIoqpeFlSgtXTGhUyqxqppuBrcw = false;
			TqFvsqFPtvxFgaAuaSQmzdpsAUCw = false;
			ROiCsEApoinzMWBXeDPkialwGtmV = true;
			MuWmAgklbHmoQdkzxECOwDPeFRUaA = -1;
			jlBEqHKjUDDhVTIkPgBNxXejleLHA = -1;
			_id = -1;
			XJXbGFtGtnhWdoMxcPMcrEuyEJMB = 0;
			SVMPRXBmdWAUjHJyiieHGmGhJwPJb = 0;
			unscaledDeltaTime = 0.0;
			unscaledTime = 0.0;
			unscaledTimePrev = 0.0;
			currentFrame = 0u;
			previousFrame = 0u;
			absFrame = 0u;
			uUxqbKykYtnbOhmGcbIOzEbsChjC.Clear();
			NHHaaThhSabelwfjItiCWFRUbepK.Clear();
			qJPVMsrpeQQFEjEVuiVIjIRxfwODA.Clear();
			lFLErzhpSszWWqCbIMeYIwgHLfIk.Clear();
			PfhNdKFZrqpYFOcMLVpsyASQRUFe.Clear();
			_ApplicationFocusChangedEvent = null;
			_ApplicationPauseChangedEvent = null;
			vbzmbYhcTVyQQqNoMgxFBBMycPzm = null;
			AiwwgowAZHkjjumMJLoHmyUxPNc = null;
			wQSLzQqYYpPehzigcjyghVnuzbhj = null;
			qAyOJjxNkXyXmUuiWaPRclVmabHc = null;
			NwyqrQDOgrhNZxfeJIQnJxLAMsiD = null;
			fEyFTXJIyqFrRiaGPmPOKYiXrpMpA = null;
			GOhWwIBmIEkVLptccqJrlYPWQNjo = null;
			lTRzFwsWLjdEHOcBBWVAHZrVeUEb = null;
			TXZCntKnIwLFhaYUnYhujuhqbGcIA = null;
			diEhnNEaBdaxAMaZbpRQmxtTdbmh = null;
			RAmsoXPJnXBdANCIOckjGpSknLhBb = null;
			aTXIWIivUagHRvpFaaoPeloIimRhb();
			mDJAaKOdFaHFEnzSxHhKjsuSNViQ = null;
			ThreadSafeUnityInput.Deinitialize();
			UnityInputHelper.Deinitialize();
			if (UnityTools.externalTools != null)
			{
				UnityTools.externalTools.EditorPausedStateChangedEvent -= hhIFkyuAyfTdutfLEwVcADBqtSiU;
			}
			XKZBcbGtoHHVfKdsghmQDHfhSpIfA.NtebgqJhSVCMKQSCmajbGTMaajAfB();
		}

		private static void UuAdhDUFwaxsJnWcRMzWfBViaGtN()
		{
			if (!xfZNQVtjBKMSfoeOsEPUkXdEqgniA)
			{
				xfZNQVtjBKMSfoeOsEPUkXdEqgniA = true;
				bbBBrcEkOraOJcDTQuujlYEFiVof.LJwcrVLZovWsdAtCZyJDmNdntpBN();
				bbBBrcEkOraOJcDTQuujlYEFiVof.pRBbfcazZFKWKBxqxxSCMCiZRkWpA();
			}
			YpCSnSudifTSMpgspQIKIrvkDhjD.Start();
		}

		private static void QHOfuRBfROqATHkfjNXRkCQNBPPHA()
		{
			Logger.LogError("Rewired is not initialized. Do you have a Rewired Input Manager in the scene and enabled?");
		}

		private static void zSzayTbySOipgfrjwcLTyiISvZQO(BridgedController P_0)
		{
			if (P_0.sourceJoystick == null)
			{
				return;
			}
			jFidDAJTYMYSSrBGXbdjHWSiLLLfB.AFQnawoogqUuoghzYbeWjfltItzVA(P_0);
			Joystick joystick = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.CjsxcJaHUvrHCwxyCGmMBABZwBpQ(P_0.sourceJoystick.rewiredId);
			if (joystick != null)
			{
				kaDCuNAiSdnlkLeWRajALqrXMggab.jGnpQZErQXaFZcbTBErDlmtsMceu(joystick);
				if (!configVars.deferControllerConnectedEventsOnStart || !oLNgxlxGxPCFzIJWpXvtDvMgOazu)
				{
					gsBENFAnvloBkClpcrZcHrzCCJVY(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		private static void gcLRmJsrjOquxopzRTxtOYCWQxwD(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				Joystick joystick = jFidDAJTYMYSSrBGXbdjHWSiLLLfB.CjsxcJaHUvrHCwxyCGmMBABZwBpQ(P_0.rewiredId);
				if (joystick != null)
				{
					jFidDAJTYMYSSrBGXbdjHWSiLLLfB.FGidPCTeJRfbSkSvvnsSFYbijMAtb(P_0.rewiredId);
					ZgvmvxCFpBBqiYTRzZXmBzMKnVVt(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		private static void gsBENFAnvloBkClpcrZcHrzCCJVY(ControllerStatusChangedEventArgs P_0)
		{
			if (uUxqbKykYtnbOhmGcbIOzEbsChjC != null)
			{
				uUxqbKykYtnbOhmGcbIOzEbsChjC.Invoke(P_0);
			}
		}

		private static void aAmwUfhIhjIKAkrywrARkBmPgAFuA(ControllerStatusChangedEventArgs P_0)
		{
			if (NHHaaThhSabelwfjItiCWFRUbepK != null)
			{
				NHHaaThhSabelwfjItiCWFRUbepK.Invoke(P_0);
			}
		}

		private static void ZgvmvxCFpBBqiYTRzZXmBzMKnVVt(ControllerStatusChangedEventArgs P_0)
		{
			if (qJPVMsrpeQQFEjEVuiVIjIRxfwODA != null)
			{
				qJPVMsrpeQQFEjEVuiVIjIRxfwODA.Invoke(P_0);
			}
		}

		private static void woWHLXNOUPdWDPYrzDbNMklBwEge(UpdateControllerInfoEventArgs P_0)
		{
			jFidDAJTYMYSSrBGXbdjHWSiLLLfB.eYZAAUHIhAWERVzuccmuYrySdyqU(P_0);
		}

		private static void dOGGgNXNkfUSBtBmcDqPkChCsFdGA(bool P_0)
		{
			if (!WugjmBgLTJdXmPxOcjVoTkTTUlEC)
			{
				return;
			}
			Action<bool> applicationFocusChangedEvent = _ApplicationFocusChangedEvent;
			if (applicationFocusChangedEvent == null)
			{
				return;
			}
			try
			{
				applicationFocusChangedEvent(P_0);
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.ApplicationFocusChangedEvent", exception);
			}
		}

		private static void xfIdGoJnRQLxYDKVJjJKDvKhykZCB(bool P_0)
		{
			if (!WugjmBgLTJdXmPxOcjVoTkTTUlEC)
			{
				return;
			}
			Action<bool> applicationPauseChangedEvent = _ApplicationPauseChangedEvent;
			if (applicationPauseChangedEvent == null)
			{
				return;
			}
			try
			{
				applicationPauseChangedEvent(P_0);
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.ApplicationPauseChangedEvent", exception);
			}
		}

		private static void vRcbfZTzQXuVBUflCHBMGStwrVFV(bool P_0)
		{
			Action<bool> action = vbzmbYhcTVyQQqNoMgxFBBMycPzm;
			if (action != null)
			{
				try
				{
					action(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationIsFullScreenChangedEvent", exception);
				}
			}
		}

		private static void uoVPZlRHJsgHCBuiTwYNLrQFWeLk(int P_0)
		{
			if (wQSLzQqYYpPehzigcjyghVnuzbhj != null)
			{
				try
				{
					wQSLzQqYYpPehzigcjyghVnuzbhj((FullScreenMode)P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationFullScreenModeChangedEvent", exception);
				}
			}
		}

		private static void DlgGmXNnnyrnspRUKbMWelTMiEfJ(bool P_0)
		{
			Action<bool> aiwwgowAZHkjjumMJLoHmyUxPNc = AiwwgowAZHkjjumMJLoHmyUxPNc;
			if (aiwwgowAZHkjjumMJLoHmyUxPNc != null)
			{
				try
				{
					aiwwgowAZHkjjumMJLoHmyUxPNc(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationRunInBackgroundChangedEvent", exception);
				}
			}
		}

		private static void DTSfHcXMqsUPdGybWpftSijsgwtL(bool P_0)
		{
			XJXbGFtGtnhWdoMxcPMcrEuyEJMB++;
			Action<bool> action = qAyOJjxNkXyXmUuiWaPRclVmabHc;
			if (action != null)
			{
				try
				{
					action(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.TimeScalePauseChangedEvent", exception);
				}
			}
		}

		private static void jzmeMmEMclcKefgBjhDTEgPAzsIbc()
		{
			if (mDJAaKOdFaHFEnzSxHhKjsuSNViQ != null)
			{
				aTXIWIivUagHRvpFaaoPeloIimRhb();
				mDJAaKOdFaHFEnzSxHhKjsuSNViQ.ReBxGqZauQYfDMdMRzrynaBQqHgk.ChangedEvent += dOGGgNXNkfUSBtBmcDqPkChCsFdGA;
				mDJAaKOdFaHFEnzSxHhKjsuSNViQ.ZErbmgGKzLFfTADIgkNdTOsxrHei.ChangedEvent += xfIdGoJnRQLxYDKVJjJKDvKhykZCB;
				mDJAaKOdFaHFEnzSxHhKjsuSNViQ.lXlYlCwcWfqJtdFDRnkejMdSWZnu.ChangedEvent += vRcbfZTzQXuVBUflCHBMGStwrVFV;
				mDJAaKOdFaHFEnzSxHhKjsuSNViQ.DKkoVeRlcTlrDfzlNfaSsWRFpacf.ChangedEvent += DlgGmXNnnyrnspRUKbMWelTMiEfJ;
				mDJAaKOdFaHFEnzSxHhKjsuSNViQ.LMgWHMNUFnDWprFDywcqaOSejnnM.ChangedEvent += uoVPZlRHJsgHCBuiTwYNLrQFWeLk;
				mDJAaKOdFaHFEnzSxHhKjsuSNViQ.pmlAdSKskpmHDTCBQJwHHEiYeTVj.ChangedEvent += DTSfHcXMqsUPdGybWpftSijsgwtL;
			}
		}

		private static void aTXIWIivUagHRvpFaaoPeloIimRhb()
		{
			if (mDJAaKOdFaHFEnzSxHhKjsuSNViQ != null)
			{
				mDJAaKOdFaHFEnzSxHhKjsuSNViQ.ReBxGqZauQYfDMdMRzrynaBQqHgk.ChangedEvent -= dOGGgNXNkfUSBtBmcDqPkChCsFdGA;
				mDJAaKOdFaHFEnzSxHhKjsuSNViQ.ZErbmgGKzLFfTADIgkNdTOsxrHei.ChangedEvent -= xfIdGoJnRQLxYDKVJjJKDvKhykZCB;
				mDJAaKOdFaHFEnzSxHhKjsuSNViQ.lXlYlCwcWfqJtdFDRnkejMdSWZnu.ChangedEvent -= vRcbfZTzQXuVBUflCHBMGStwrVFV;
				mDJAaKOdFaHFEnzSxHhKjsuSNViQ.DKkoVeRlcTlrDfzlNfaSsWRFpacf.ChangedEvent -= DlgGmXNnnyrnspRUKbMWelTMiEfJ;
				mDJAaKOdFaHFEnzSxHhKjsuSNViQ.LMgWHMNUFnDWprFDywcqaOSejnnM.ChangedEvent -= uoVPZlRHJsgHCBuiTwYNLrQFWeLk;
				mDJAaKOdFaHFEnzSxHhKjsuSNViQ.pmlAdSKskpmHDTCBQJwHHEiYeTVj.ChangedEvent -= DTSfHcXMqsUPdGybWpftSijsgwtL;
			}
		}

		private static void hhIFkyuAyfTdutfLEwVcADBqtSiU(bool P_0)
		{
			Action<bool> rAmsoXPJnXBdANCIOckjGpSknLhBb = RAmsoXPJnXBdANCIOckjGpSknLhBb;
			if (rAmsoXPJnXBdANCIOckjGpSknLhBb != null)
			{
				try
				{
					rAmsoXPJnXBdANCIOckjGpSknLhBb(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.EditorPauseChangedEvent", exception);
				}
			}
		}

		private static void kjwVOdBCRJiRoMlPrKiZSyeSbUlN(Func<ConfigVars, object> P_0, UnityTools.uaEpAarlcIaaOoCOqAQxcyWtCvMkA P_1, Action<Platform> P_2)
		{
			if (!configVars.alwaysUseUnityInput)
			{
				bool flag = false;
				if (P_1.pKzPdYWRLQIBEDIiWOHMmurkkxFt != P_1.PzgCyMmtbvhmhaaGeejAAuYbPCHFB)
				{
					UnityTools.uaEpAarlcIaaOoCOqAQxcyWtCvMkA uaEpAarlcIaaOoCOqAQxcyWtCvMkA = P_1;
					uaEpAarlcIaaOoCOqAQxcyWtCvMkA.pKzPdYWRLQIBEDIiWOHMmurkkxFt = P_1.PzgCyMmtbvhmhaaGeejAAuYbPCHFB;
					UnityTools.XgYPxiDBjDowbkxvxjBuzTsjHTKh(uaEpAarlcIaaOoCOqAQxcyWtCvMkA);
					P_2(uaEpAarlcIaaOoCOqAQxcyWtCvMkA.PzgCyMmtbvhmhaaGeejAAuYbPCHFB);
					rUlAFpkiMbRosbJOcLIwvpLobQncA();
					flag = true;
				}
				if (!configVars.IsPrimaryInputSourceUnityInputManager(P_1.PzgCyMmtbvhmhaaGeejAAuYbPCHFB, P_1.KjaRKLMFuVettClmsdKddNDGRJFtA, isEditor) && !configVars.IsPrimaryInputSourceUnityInputManager(P_1.pKzPdYWRLQIBEDIiWOHMmurkkxFt, P_1.KjaRKLMFuVettClmsdKddNDGRJFtA, isEditor))
				{
					List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(SiXOGfYAfmKJkNWCcNWqoXmYteDF);
					for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
					{
						if (componentsInSelfAndChildren[i].Initialize(P_1.PzgCyMmtbvhmhaaGeejAAuYbPCHFB, wzlteJdDPZYmtywPXjGXrWAAIKvJ) is PlatformInputManager neEVntlckjaQuIKbzjPdCmfDUwQhc)
						{
							NeEVntlckjaQuIKbzjPdCmfDUwQhc = neEVntlckjaQuIKbzjPdCmfDUwQhc;
							return;
						}
					}
				}
				if (flag)
				{
					UnityTools.XgYPxiDBjDowbkxvxjBuzTsjHTKh(P_1);
					P_2(P_1.PzgCyMmtbvhmhaaGeejAAuYbPCHFB);
					rUlAFpkiMbRosbJOcLIwvpLobQncA();
					flag = false;
				}
			}
			if (configVars.IsPrimaryInputSourceUnityInputManager(yYubrrhmzcQeEpBSLvzpxyvmkALy, RnABkzMQAOJCrSsDFjSEarshMOcm, isEditor))
			{
				NeEVntlckjaQuIKbzjPdCmfDUwQhc = TkUfHaWxbioNVMlCYFQEeHGdfiGRA(true, false, out var _);
				TxCplICMnTZpPiXwadmbEnzHOQTt = NeEVntlckjaQuIKbzjPdCmfDUwQhc != null;
				if (NeEVntlckjaQuIKbzjPdCmfDUwQhc == null)
				{
				}
			}
			else if (configVars.IsPrimaryInputSourceUnityInputSystem(yYubrrhmzcQeEpBSLvzpxyvmkALy, RnABkzMQAOJCrSsDFjSEarshMOcm, isEditor))
			{
				NeEVntlckjaQuIKbzjPdCmfDUwQhc = GcRrOTLHfrHpYDqmoJhxbZbzKTSDb(true, false, out var _);
			}
			else if (yYubrrhmzcQeEpBSLvzpxyvmkALy == Platform.Windows || yYubrrhmzcQeEpBSLvzpxyvmkALy == Platform.OSX || yYubrrhmzcQeEpBSLvzpxyvmkALy == Platform.Linux || (yYubrrhmzcQeEpBSLvzpxyvmkALy == Platform.WindowsAppStore && !isEditor) || (yYubrrhmzcQeEpBSLvzpxyvmkALy == Platform.WindowsUWP && !isEditor) || (yYubrrhmzcQeEpBSLvzpxyvmkALy == Platform.WebGL && !isEditor) || (yYubrrhmzcQeEpBSLvzpxyvmkALy == Platform.iOS && !isEditor) || (yYubrrhmzcQeEpBSLvzpxyvmkALy == Platform.tvOS && !isEditor))
			{
				try
				{
					NeEVntlckjaQuIKbzjPdCmfDUwQhc = P_0(wzlteJdDPZYmtywPXjGXrWAAIKvJ) as PlatformInputManager;
					if (NeEVntlckjaQuIKbzjPdCmfDUwQhc == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError(yYubrrhmzcQeEpBSLvzpxyvmkALy.ToString() + " platform could not be initialized! Is the Rewired " + yYubrrhmzcQeEpBSLvzpxyvmkALy.ToString() + " library installed? See the documentation for more information.");
					NeEVntlckjaQuIKbzjPdCmfDUwQhc = null;
				}
			}
			else if (yYubrrhmzcQeEpBSLvzpxyvmkALy == Platform.XboxOne && !isEditor)
			{
				Logger.LogError("Xbox One (XDK) platform is not supported in this version of Unity or Rewired. Xbox One (XDK) is only supported in Unity 2020 and prior.");
			}
			else if ((yYubrrhmzcQeEpBSLvzpxyvmkALy == Platform.PS4 && !isEditor) || (yYubrrhmzcQeEpBSLvzpxyvmkALy == Platform.PS5 && !isEditor))
			{
				try
				{
					NeEVntlckjaQuIKbzjPdCmfDUwQhc = P_0(wzlteJdDPZYmtywPXjGXrWAAIKvJ) as PlatformInputManager;
					if (NeEVntlckjaQuIKbzjPdCmfDUwQhc == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch
				{
					Logger.LogError(yYubrrhmzcQeEpBSLvzpxyvmkALy.ToString() + " platform could not be initialized! Is the Rewired " + yYubrrhmzcQeEpBSLvzpxyvmkALy.ToString() + " plugin installed? See the documentation for more information.");
					NeEVntlckjaQuIKbzjPdCmfDUwQhc = null;
				}
			}
			else if ((yYubrrhmzcQeEpBSLvzpxyvmkALy == Platform.GameCoreXboxOne || yYubrrhmzcQeEpBSLvzpxyvmkALy == Platform.GameCoreScarlett) && !isEditor)
			{
				try
				{
					NeEVntlckjaQuIKbzjPdCmfDUwQhc = P_0(wzlteJdDPZYmtywPXjGXrWAAIKvJ) as PlatformInputManager;
					if (NeEVntlckjaQuIKbzjPdCmfDUwQhc == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch
				{
					string text3 = ((yYubrrhmzcQeEpBSLvzpxyvmkALy == Platform.GameCoreXboxOne) ? "Xbox One" : "Xbox Series X");
					Logger.LogError(text3 + " platform could not be initialized! Is the Rewired " + text3 + " library installed? See the documentation for more information.");
					NeEVntlckjaQuIKbzjPdCmfDUwQhc = null;
				}
			}
			else if (yYubrrhmzcQeEpBSLvzpxyvmkALy == Platform.Ouya && !isEditor)
			{
				Logger.LogError("Ouya is no longer supported.");
				NeEVntlckjaQuIKbzjPdCmfDUwQhc = null;
			}
			else if (yYubrrhmzcQeEpBSLvzpxyvmkALy == Platform.Custom)
			{
				try
				{
					NeEVntlckjaQuIKbzjPdCmfDUwQhc = new CustomInputManager(XKZBcbGtoHHVfKdsghmQDHfhSpIfA.wEhwhzLmBhdhiFuacBYMoDnsnHyhb(), wzlteJdDPZYmtywPXjGXrWAAIKvJ.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
					if (NeEVntlckjaQuIKbzjPdCmfDUwQhc == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("Custom platform could not be initialized due to an exception!");
					NeEVntlckjaQuIKbzjPdCmfDUwQhc = null;
					throw;
				}
			}
			if (NeEVntlckjaQuIKbzjPdCmfDUwQhc == null)
			{
				NeEVntlckjaQuIKbzjPdCmfDUwQhc = cULisAEXGVirkKdMWNNTXljCdMkHA(configVars);
				TxCplICMnTZpPiXwadmbEnzHOQTt = NeEVntlckjaQuIKbzjPdCmfDUwQhc is CMxwGZjFpYvocDsKTBgbeUxNyuuHA;
			}
			if (!isEditor && UnityTools.isAndroidPlatform && NeEVntlckjaQuIKbzjPdCmfDUwQhc is CMxwGZjFpYvocDsKTBgbeUxNyuuHA)
			{
				try
				{
					UnityTools.HGibNKTxgWTXsSSrCpyiwwxviScG = P_0(wzlteJdDPZYmtywPXjGXrWAAIKvJ) as IAndroidFallbackPlatformHelper;
				}
				catch (Exception msg)
				{
					Logger.LogError(msg);
				}
			}
		}

		private static PlatformInputManager cULisAEXGVirkKdMWNNTXljCdMkHA(ConfigVars P_0)
		{
			string text = null;
			bool isUnityInputManagerEnabled = UnityTools.externalTools.isUnityInputManagerEnabled;
			int num;
			int num2;
			if (UnityTools.supportsUnityInputSystem)
			{
				num = (UnityTools.externalTools.isUnityInputSystemEnabled ? 1 : 0);
				if (num != 0)
				{
					num2 = ((!isUnityInputManagerEnabled) ? 1 : 0);
					goto IL_002b;
				}
			}
			else
			{
				num = 0;
			}
			num2 = 0;
			goto IL_002b;
			IL_002b:
			bool flag = (byte)num2 != 0;
			UnityInputSourceType fallbackUnityInputType = P_0.GetFallbackUnityInputType();
			if (num != 0 && (flag || fallbackUnityInputType == UnityInputSourceType.InputSystem))
			{
				PlatformInputManager platformInputManager = GcRrOTLHfrHpYDqmoJhxbZbzKTSDb(false, true, out text);
				if (platformInputManager != null)
				{
					return platformInputManager;
				}
			}
			string text2 = null;
			if (!flag)
			{
				PlatformInputManager platformInputManager = TkUfHaWxbioNVMlCYFQEeHGdfiGRA(false, true, out text2);
				if (platformInputManager != null)
				{
					return platformInputManager;
				}
			}
			string text3 = "Failed to initialize a Unity input source. Input will not function.\n";
			text3 = (flag ? (text3 + "\nUnity Input System could not be initialized. Error: " + text) : ((!UnityTools.supportsUnityInputSystem || !UnityTools.externalTools.isUnityInputSystemEnabled) ? (text3 + "\nUnity Input Manager could not be initialized. Error: " + text2) : (text3 + "\nNeither Unity Input System nor Unity Input Manager could not be initialized. At least one must be enabled or input will not function. Rewired first attempts to use Unity Input System, and if that fails, it attempts to fall back to Unity Input Manager. Errors were encountered attempting to initialize both input sources:\n" + text + "\n" + text2)));
			Logger.LogError(text3);
			return null;
		}

		private static CMxwGZjFpYvocDsKTBgbeUxNyuuHA TkUfHaWxbioNVMlCYFQEeHGdfiGRA(bool P_0, bool P_1, out string P_2)
		{
			P_2 = null;
			try
			{
				if (!UnityTools.externalTools.isUnityInputManagerEnabled)
				{
					throw new Exception();
				}
				return new CMxwGZjFpYvocDsKTBgbeUxNyuuHA(wzlteJdDPZYmtywPXjGXrWAAIKvJ.updateLoop);
			}
			catch (Exception)
			{
				string text = (P_0 ? "The Primary Input Source for this platform is currently set to Unity Input Manager. " : string.Empty);
				if (!UnityTools.externalTools.isUnityInputManagerEnabled)
				{
					text += "Unity Input Manager is not enabled in Unity Player Settings -> Active Input Handling. You must set this to \"Input Manager (Old)\" or \"Both\" to use Unity Input Manager.";
				}
				P_2 = "Unity Input Manager could not be initialized. " + text;
				if (!P_1)
				{
					Logger.LogError(P_2);
				}
				return null;
			}
		}

		private static UnityInputSystemInputManager GcRrOTLHfrHpYDqmoJhxbZbzKTSDb(bool P_0, bool P_1, out string P_2)
		{
			P_2 = null;
			if (!UnityTools.supportsUnityInputSystem)
			{
				P_2 = "Unity Input System is not supported in this version of Unity.";
				if (!P_1)
				{
					Logger.LogError(P_2);
				}
				return null;
			}
			try
			{
				return UnityInputSystemInputManager.Create(GetHardwareJoystickMap_InputManager, GetNewJoystickId);
			}
			catch (Exception)
			{
				string text = (P_0 ? "The Primary Input Source for this platform is currently set to Unity Input System. " : string.Empty);
				text = (UnityTools.externalTools.isUnityInputSystemEnabled ? (text + "Is Unity Input System package " + Consts.unityInputSystemMinimumVersion?.ToString() + "+ installed?") : (text + "Unity Input System is not enabled in Unity Player Settings -> Active Input Handling. You must set this to \"Input System Package (New)\" or \"Both\" to use Unity Input System."));
				P_2 = "Unity Input System could not be initialized. " + text;
				if (!P_1)
				{
					Logger.LogError(P_2);
				}
				return null;
			}
		}

		private static void uRRuLBuQawhzUdjKyUtztTuVDSFS()
		{
			if (GJIoqpeFlSgtXTGhUyqxqppuBrcw != wzlteJdDPZYmtywPXjGXrWAAIKvJ.GetPlatformVar_ignoreInputWhenAppNotInFocus())
			{
				GJIoqpeFlSgtXTGhUyqxqppuBrcw = !GJIoqpeFlSgtXTGhUyqxqppuBrcw;
			}
		}

		private static void erfclIHgRPwqGNFLPQNKFmZajhlZA()
		{
			if (!(UnityTools.unityVersionObj == null))
			{
				string[] obj = new string[7] { "The version of Rewired installed (", programVersion, ") was not designed for Unity ", null, null, null, null };
				int major = UnityTools.unityVersionObj.major;
				obj[3] = major.ToString();
				obj[4] = ". Please install Rewired for Unity ";
				major = UnityTools.unityVersionObj.major;
				obj[5] = major.ToString();
				obj[6] = ".\n\nThis warning does not mean that Rewired will not function, but it may not function optimally.\n\nSome different major versions of Unity download Asset Store assets to the same folder location on disk, so if you download an asset in one version of the Unity editor, then open another version of the Unity editor and install the asset without re-downloading it, the wrong asset version will be installed. To fix this, manually re-download Rewired in the Unity Asset Store panel in this version of the Unity Editor, then install it.\n\nIf you are using a beta version of a new major version of Unity, you will have to wait until the release of the final version before a compatible version of Rewired can be uploaded to the Asset Store. When the new version is ready, it will be available through the Unity Asset Store for download as usual.";
				Logger.LogWarning(string.Concat(obj));
			}
		}
	}
}
