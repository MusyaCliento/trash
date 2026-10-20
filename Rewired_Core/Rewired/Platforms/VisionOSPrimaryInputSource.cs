using System.ComponentModel;

namespace Rewired.Platforms
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum VisionOSPrimaryInputSource
	{
		Native = 0,
		UnityInputManager = 100,
		UnityInputSystem = 101
	}
}
