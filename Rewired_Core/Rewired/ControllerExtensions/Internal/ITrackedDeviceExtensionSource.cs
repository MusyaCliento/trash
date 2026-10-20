using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.ControllerExtensions.Internal
{
	public interface ITrackedDeviceExtensionSource : IControllerExtensionSource
	{
		bool isTracked { get; }

		TrackedDeviceTrackedValueFlags trackedValues { get; }

		Vector3 position { get; }

		Quaternion rotation { get; }

		Vector3 velocity { get; }

		Vector3 angularVelocity { get; }

		Vector3 acceleration { get; }

		Vector3 angularAcceleration { get; }
	}
}
