namespace Rewired
{
	[CustomObfuscation(rename = false)]
	public enum InputSource
	{
		None = 0,
		DirectInput = 1,
		XInput = 2,
		OSX = 3,
		Fallback = 4,
		RawInput = 5,
		Fallback_PreConfigured = 6,
		Linux = 7,
		WindowsUWP = 8,
		WebGL = 9,
		UnityInputSystem = 10,
		Steam = 18,
		SDL2 = 19,
		XboxOne = 21,
		PS4 = 22,
		NintendoSwitch = 24,
		GameCoreXboxOne = 26,
		GameCoreScarlett = 27,
		PS5 = 28,
		AppleGameController = 29,
		WindowsGamingInput = 30,
		NintendoSwitch2 = 31,
		SDL3 = 32,
		InternalDriver = 49,
		UnityKeyboardAndMouse = 50,
		Custom = 100
	}
}
