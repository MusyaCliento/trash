using System.ComponentModel;

namespace Rewired.Platforms
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum LinuxStandalonePrimaryInputSource
	{
		Native = 0,
		SDL2 = 10,
		SDL3 = 11,
		UnityInputManager = 100,
		UnityInputSystem = 101
	}
}
