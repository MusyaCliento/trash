using System.ComponentModel;

namespace Rewired.Platforms.UnityInputSystem
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum UnityInputSystemDeviceType
	{
		Unknown = 0,
		Keyboard = 1,
		Mouse = 2,
		GenericJoystick = 3,
		Gamepad = 4,
		OtherJoystick = 5,
		TrackedDevice = 6
	}
}
