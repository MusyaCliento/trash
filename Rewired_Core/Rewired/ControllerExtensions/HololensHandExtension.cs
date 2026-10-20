using Rewired.ControllerExtensions.Internal;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class HololensHandExtension : TrackedDeviceExtension
	{
		private sealed class haBgeHGTMmXMYsqKeRddVaGtRnmcA : Source
		{
			public haBgeHGTMmXMYsqKeRddVaGtRnmcA(IHololensHandExtensionSource P_0)
				: base(P_0)
			{
			}
		}

		private bool rqMpShekadebfotCafWpepJyObfsA;

		private IHololensHandExtensionSource tSource => (IHololensHandExtensionSource)((haBgeHGTMmXMYsqKeRddVaGtRnmcA)GetSource()).source;

		public float sourceLossRisk
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0f;
				}
				if (!rqMpShekadebfotCafWpepJyObfsA || !base.enabled)
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
				if (!rqMpShekadebfotCafWpepJyObfsA || !base.enabled)
				{
					return default(Vector3);
				}
				return tSource.sourceLossMitigationDirection;
			}
		}

		public HololensHandExtension(IHololensHandExtensionSource P_0)
			: base(new haBgeHGTMmXMYsqKeRddVaGtRnmcA(P_0))
		{
		}

		private HololensHandExtension(HololensHandExtension P_0)
			: base(P_0)
		{
		}

		internal override Controller.Extension Clone()
		{
			return new HololensHandExtension(this);
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (rqMpShekadebfotCafWpepJyObfsA)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			rqMpShekadebfotCafWpepJyObfsA = source is haBgeHGTMmXMYsqKeRddVaGtRnmcA && ((haBgeHGTMmXMYsqKeRddVaGtRnmcA)source).source != null;
		}
	}
}
