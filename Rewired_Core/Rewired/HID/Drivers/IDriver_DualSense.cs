using Rewired.ControllerExtensions;
using Rewired.ControllerExtensions.Internal;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal interface IDriver_DualSense : IDualSenseExtensionSource, IDualShock4DualSenseCommonExtensionSource, IControllerDriver, IHIDControllerExtension
	{
	}
}
