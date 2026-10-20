using System.ComponentModel;

namespace Rewired.Platforms
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum TVOSPrimaryInputSource
	{
		Native = 0,
		UnityInputManager = 100,
		UnityInputSystem = 101
	}
}
