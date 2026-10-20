using System;
using Rewired.Data;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;

namespace Rewired.InputManagers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class Initializer : PlatformInitializer
	{
		internal const string initErrorMsg = "";

		private static PlatformInitializer aLTnBxVOpdvjrUeIGuhSGEDHExyW;

		public static PlatformInitializer GetPlatformInitializer()
		{
			if (aLTnBxVOpdvjrUeIGuhSGEDHExyW == null)
			{
				aLTnBxVOpdvjrUeIGuhSGEDHExyW = new Initializer();
			}
			return aLTnBxVOpdvjrUeIGuhSGEDHExyW;
		}

		public override object Initialize(IConfigVars_Internal configVars)
		{
			if (UnityTools.platform == Platform.Windows || UnityTools.platform == Platform.WindowsAppStore)
			{
				ConfigVars configVars2 = (ConfigVars)configVars;
				if (configVars2.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.SDL3)
				{
					try
					{
						return new gatbCOGclPOtoAOFWtORncfPSolQA(configVars2, ReInput.GetHardwareJoystickMap_InputManager, ReInput.GetNewJoystickId, true, false, false) ?? throw new Exception();
					}
					catch
					{
						Logger.LogError("SDL3 could not be initialized! Make sure you have the SDL3 library installed. Please see the documentation for more information.");
						configVars2.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.SDL2;
					}
				}
				if (UnityTools.platform == Platform.Windows && configVars2.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.SDL2)
				{
					try
					{
						return new oGnUlRfovDGQUoBGyxHJqfqybVbFA(configVars2, ReInput.GetHardwareJoystickMap_InputManager, ReInput.GetNewJoystickId, true, false, false) ?? throw new Exception();
					}
					catch
					{
						Logger.LogError("SDL2 could not be initialized! Make sure you have the SDL2 library installed. Please see the documentation for more information.");
						configVars2.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
					}
				}
				try
				{
					return new qkWHxmOkuUhrVDInECtyqYOZATeS(configVars2, ReInput.GetHardwareJoystickMap_InputManager, ReInput.GetNewJoystickId);
				}
				catch (Exception)
				{
					Logger.LogWarning("Rewired will fall back to Unity input. Certain features may not be available.\n");
					return null;
				}
			}
			return null;
		}

		public override IElementIdentifierTool CreateTool(string inputSourceString)
		{
			if (string.Equals(inputSourceString, "DirectInput", StringComparison.Ordinal))
			{
				return new RRWWOSeavpEjItqLSFnoBCfFTJBU();
			}
			if (string.Equals(inputSourceString, "RawInput", StringComparison.Ordinal))
			{
				return new vAozFiksHjVahBCkGkhFXvKKLJmo();
			}
			if (string.Equals(inputSourceString, "SDL2", StringComparison.Ordinal))
			{
				return new aspgCKrCvFpOVZulKUGsPWITAabc();
			}
			if (string.Equals(inputSourceString, "SDL3", StringComparison.Ordinal))
			{
				return new fMHXCYvaqCaQWccKLgWTfLbZWmpR();
			}
			return null;
		}
	}
}
