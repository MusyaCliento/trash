using System.ComponentModel;

namespace Rewired.Platforms.UnityInputSystem
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public class UnityInputSystemInputSourceInitOptions
	{
		public bool handleKeyboard;

		public bool handleMouse;

		public bool handleJoysticks;

		public bool xrDevicesOnlyMode;

		internal UnityInputSystemInputSourceInitOptions()
		{
		}

		public bool TryGetConfigValue<T>(string key, out T value)
		{
			if (ReInput.pluginConfigVars == null || string.IsNullOrEmpty(key))
			{
				value = default(T);
				return false;
			}
			return ReInput.pluginConfigVars.values.TryGetValue<T>(key, out value);
		}
	}
}
