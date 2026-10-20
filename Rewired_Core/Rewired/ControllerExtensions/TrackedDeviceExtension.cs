using Rewired.ControllerExtensions.Internal;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public class TrackedDeviceExtension : Controller.Extension
	{
		protected class Source : IControllerExtensionSource
		{
			public readonly ITrackedDeviceExtensionSource source;

			public Source(ITrackedDeviceExtensionSource P_0)
			{
				source = P_0;
			}
		}

		private bool jwyQSkzwNxqzbxIBTeBHbpVvWWxJ;

		public bool isTracked
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return false;
				}
				if (!jwyQSkzwNxqzbxIBTeBHbpVvWWxJ || !base.enabled)
				{
					return false;
				}
				return ((Source)GetSource()).source.isTracked;
			}
		}

		public TrackedDeviceTrackedValueFlags trackedValues
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return TrackedDeviceTrackedValueFlags.None;
				}
				if (!jwyQSkzwNxqzbxIBTeBHbpVvWWxJ || !base.enabled)
				{
					return TrackedDeviceTrackedValueFlags.None;
				}
				return ((Source)GetSource()).source.trackedValues;
			}
		}

		public Vector3 position
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return default(Vector3);
				}
				if (!jwyQSkzwNxqzbxIBTeBHbpVvWWxJ || !base.enabled)
				{
					return default(Vector3);
				}
				return ((Source)GetSource()).source.position;
			}
		}

		public Quaternion rotation
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return Quaternion.identity;
				}
				if (!jwyQSkzwNxqzbxIBTeBHbpVvWWxJ || !base.enabled)
				{
					return Quaternion.identity;
				}
				return ((Source)GetSource()).source.rotation;
			}
		}

		public Vector3 velocity
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return default(Vector3);
				}
				if (!jwyQSkzwNxqzbxIBTeBHbpVvWWxJ || !base.enabled)
				{
					return default(Vector3);
				}
				return ((Source)GetSource()).source.velocity;
			}
		}

		public Vector3 angularVelocity
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return default(Vector3);
				}
				if (!jwyQSkzwNxqzbxIBTeBHbpVvWWxJ || !base.enabled)
				{
					return default(Vector3);
				}
				return ((Source)GetSource()).source.angularVelocity;
			}
		}

		public Vector3 acceleration
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return default(Vector3);
				}
				if (!jwyQSkzwNxqzbxIBTeBHbpVvWWxJ || !base.enabled)
				{
					return default(Vector3);
				}
				return ((Source)GetSource()).source.acceleration;
			}
		}

		public Vector3 angularAcceleration
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return default(Vector3);
				}
				if (!jwyQSkzwNxqzbxIBTeBHbpVvWWxJ || !base.enabled)
				{
					return default(Vector3);
				}
				return ((Source)GetSource()).source.angularAcceleration;
			}
		}

		public TrackedDeviceExtension(ITrackedDeviceExtensionSource P_0)
			: base(new Source(P_0))
		{
		}

		protected TrackedDeviceExtension(Source P_0)
			: base(P_0)
		{
		}

		protected TrackedDeviceExtension(TrackedDeviceExtension P_0)
			: base(P_0)
		{
		}

		internal override Controller.Extension Clone()
		{
			return new TrackedDeviceExtension(this);
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (jwyQSkzwNxqzbxIBTeBHbpVvWWxJ)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			jwyQSkzwNxqzbxIBTeBHbpVvWWxJ = source is Source && ((Source)source).source != null;
		}
	}
}
