using Rewired.ControllerExtensions;
using Rewired.ControllerExtensions.Internal;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal interface IDriver_DualShock4 : IDualShock4ExtensionSource, IDualShock4DualSenseCommonExtensionSource, IControllerDriver, IHIDControllerExtension
	{
	}
}
