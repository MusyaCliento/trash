using System;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.InputSources.SDL2;
using Rewired.Interfaces;

internal class oGnUlRfovDGQUoBGyxHJqfqybVbFA : mmPixGkNrSmtDGIDPEZUiOYOuFCLA
{
	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.SDL2;

	public oGnUlRfovDGQUoBGyxHJqfqybVbFA(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2, bool P_3, bool P_4, bool P_5)
		: base(P_0, P_1, P_2, P_3, P_4, P_5)
	{
	}

	protected virtual IInputSource QMGOmQFRXCTayQHvOOlPWaOWUTWr(UpdateLoopSetting P_0, bool P_1, bool P_2, bool P_3, bool P_4)
	{
		return new SDL2InputSource(P_0, P_1, P_2, P_3, P_4);
	}
}
