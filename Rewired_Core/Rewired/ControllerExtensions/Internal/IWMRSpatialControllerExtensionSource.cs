using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.ControllerExtensions.Internal
{
	public interface IWMRSpatialControllerExtensionSource : ITrackedDeviceExtensionSource, IControllerExtensionSource
	{
		float batteryLevel { get; }

		float sourceLossRisk { get; }

		Vector3 sourceLossMitigationDirection { get; }

		Vector3 pointerPosition { get; }

		Quaternion pointerRotation { get; }
	}
}
