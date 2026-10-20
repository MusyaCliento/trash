using System;
using System.ComponentModel;

namespace Rewired.Platforms
{
	[Obsolete("Use MacOSStandalonePrimaryInputSource instead.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum OSXStandalonePrimaryInputSource
	{
		Native = 0,
		GameController = 1,
		SDL2 = 10,
		UnityInputManager = 100,
		UnityInputSystem = 101
	}
}
