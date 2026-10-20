using Rewired.ControllerExtensions.Internal;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class WMRSpatialControllerExtension : TrackedDeviceExtension
	{
		private sealed class dqRVylzqBwPxqqKtvkfuAVRbMaOf : Source
		{
			public dqRVylzqBwPxqqKtvkfuAVRbMaOf(IWMRSpatialControllerExtensionSource P_0)
				: base(P_0)
			{
			}
		}

		private bool EBeArjbPzbGnHPjUHAVttXthGgtG;

		private IWMRSpatialControllerExtensionSource tSource => (IWMRSpatialControllerExtensionSource)((dqRVylzqBwPxqqKtvkfuAVRbMaOf)GetSource()).source;

		public float sourceLossRisk
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0f;
				}
				if (!EBeArjbPzbGnHPjUHAVttXthGgtG || !base.enabled)
				{
					return 0f;
				}
				return tSource.sourceLossRisk;
			}
		}

		public Vector3 sourceLossMitigationDirection
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return default(Vector3);
				}
				if (!EBeArjbPzbGnHPjUHAVttXthGgtG || !base.enabled)
				{
					return default(Vector3);
				}
				return tSource.sourceLossMitigationDirection;
			}
		}

		private Vector3 pointerPosition
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return default(Vector3);
				}
				if (!EBeArjbPzbGnHPjUHAVttXthGgtG || !base.enabled)
				{
					return default(Vector3);
				}
				return tSource.pointerPosition;
			}
		}

		private Quaternion pointerRotation
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return Quaternion.identity;
				}
				if (!EBeArjbPzbGnHPjUHAVttXthGgtG || !base.enabled)
				{
					return Quaternion.identity;
				}
				return tSource.pointerRotation;
			}
		}

		public WMRSpatialControllerExtension(IWMRSpatialControllerExtensionSource P_0)
			: base(new dqRVylzqBwPxqqKtvkfuAVRbMaOf(P_0))
		{
		}

		private WMRSpatialControllerExtension(WMRSpatialControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override Controller.Extension Clone()
		{
			return new WMRSpatialControllerExtension(this);
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (EBeArjbPzbGnHPjUHAVttXthGgtG)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			EBeArjbPzbGnHPjUHAVttXthGgtG = source is dqRVylzqBwPxqqKtvkfuAVRbMaOf && ((dqRVylzqBwPxqqKtvkfuAVRbMaOf)source).source != null;
		}
	}
}
