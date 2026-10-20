namespace Rewired.InputSources.SDL
{
	internal enum SDLDeviceType
	{
		[CustomObfuscation(rename = false)]
		Joystick = 0,
		[CustomObfuscation(rename = false)]
		Gamepad = 1,
		[CustomObfuscation(rename = false)]
		Mouse = 2,
		[CustomObfuscation(rename = false)]
		Keyboard = 3
	}
}
