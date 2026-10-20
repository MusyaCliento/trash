using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.ControllerExtensions.Internal
{
	public interface IHololensHandExtensionSource : ITrackedDeviceExtensionSource, IControllerExtensionSource
	{
		float sourceLossRisk { get; }

		Vector3 sourceLossMitigationDirection { get; }
	}
}
