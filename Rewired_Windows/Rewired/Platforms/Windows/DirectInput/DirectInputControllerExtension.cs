using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.DirectInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class DirectInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class zWndpnDEZhKWnkRJMKMGDiUjkwsg : IControllerExtensionSource
		{
			private UTyQEMVineRQmjtixsdHzIMSbUZe TTylYciqJEShXMlDNphWBqykiKCo;

			private rFYMuRcYbuHgyLSUxjNPLSHTPkLR wQILlwiarqVsOMJjFIDnbsdlNBsEb;

			public UTyQEMVineRQmjtixsdHzIMSbUZe tbmGfOvfbHJPDhHivDyMWHMHzOFT => TTylYciqJEShXMlDNphWBqykiKCo;

			public rFYMuRcYbuHgyLSUxjNPLSHTPkLR iavDTSgJHZBvTFmvIUxgpfVrObnvb => wQILlwiarqVsOMJjFIDnbsdlNBsEb;

			public zWndpnDEZhKWnkRJMKMGDiUjkwsg(UTyQEMVineRQmjtixsdHzIMSbUZe P_0, rFYMuRcYbuHgyLSUxjNPLSHTPkLR P_1)
			{
				TTylYciqJEShXMlDNphWBqykiKCo = P_0;
				wQILlwiarqVsOMJjFIDnbsdlNBsEb = P_1;
			}
		}

		private zWndpnDEZhKWnkRJMKMGDiUjkwsg RokiKNCeFJBDwKsFfIYbuTeaCZlS;

		private bool vKjAUNNywIoBfYnGsYOabkqfAfgkA;

		private Joystick joystick => GetController<Joystick>();

		public Guid instanceGuid
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return Guid.Empty;
				}
				if (!vKjAUNNywIoBfYnGsYOabkqfAfgkA || !base.enabled)
				{
					return Guid.Empty;
				}
				if (RokiKNCeFJBDwKsFfIYbuTeaCZlS.iavDTSgJHZBvTFmvIUxgpfVrObnvb == null)
				{
					return Guid.Empty;
				}
				return RokiKNCeFJBDwKsFfIYbuTeaCZlS.tbmGfOvfbHJPDhHivDyMWHMHzOFT.gPdNFUoLpXnWxHqaioqXdBJsVuWK;
			}
		}

		public Guid productGuid
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return Guid.Empty;
				}
				if (!vKjAUNNywIoBfYnGsYOabkqfAfgkA || !base.enabled)
				{
					return Guid.Empty;
				}
				if (RokiKNCeFJBDwKsFfIYbuTeaCZlS.iavDTSgJHZBvTFmvIUxgpfVrObnvb == null)
				{
					return Guid.Empty;
				}
				return RokiKNCeFJBDwKsFfIYbuTeaCZlS.tbmGfOvfbHJPDhHivDyMWHMHzOFT.KGqdhBHUknswGuNHWGWgROAtaLGuA;
			}
		}

		public string instanceName
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!vKjAUNNywIoBfYnGsYOabkqfAfgkA || !base.enabled)
				{
					return string.Empty;
				}
				return RokiKNCeFJBDwKsFfIYbuTeaCZlS.iavDTSgJHZBvTFmvIUxgpfVrObnvb.ZVHWpcVAPAcfasMqWKZyxBQxZmuU.UTJVgKUwblORsQGYFfGeGbnmUTmy;
			}
		}

		string IHIDControllerExtension.productName
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!vKjAUNNywIoBfYnGsYOabkqfAfgkA || !base.enabled)
				{
					return string.Empty;
				}
				return RokiKNCeFJBDwKsFfIYbuTeaCZlS.iavDTSgJHZBvTFmvIUxgpfVrObnvb.ZVHWpcVAPAcfasMqWKZyxBQxZmuU.rrbeItDPswvFJuhRZTgGHluLJkcq;
			}
		}

		public Guid forceFeedbackDriverGuid
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return Guid.Empty;
				}
				if (!vKjAUNNywIoBfYnGsYOabkqfAfgkA || !base.enabled)
				{
					return Guid.Empty;
				}
				if (RokiKNCeFJBDwKsFfIYbuTeaCZlS.iavDTSgJHZBvTFmvIUxgpfVrObnvb == null)
				{
					return Guid.Empty;
				}
				return RokiKNCeFJBDwKsFfIYbuTeaCZlS.tbmGfOvfbHJPDhHivDyMWHMHzOFT.xbRqXBGptZCjTOvKtgHZVbsZwYwi;
			}
		}

		ushort IHIDControllerExtension.usagePage
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!vKjAUNNywIoBfYnGsYOabkqfAfgkA || !base.enabled)
				{
					return 0;
				}
				if (RokiKNCeFJBDwKsFfIYbuTeaCZlS.iavDTSgJHZBvTFmvIUxgpfVrObnvb == null)
				{
					return 0;
				}
				return RokiKNCeFJBDwKsFfIYbuTeaCZlS.tbmGfOvfbHJPDhHivDyMWHMHzOFT.SsVAJFJLCOGjgOLbnFGEfszUPPZX;
			}
		}

		ushort IHIDControllerExtension.usage
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!vKjAUNNywIoBfYnGsYOabkqfAfgkA || !base.enabled)
				{
					return 0;
				}
				if (RokiKNCeFJBDwKsFfIYbuTeaCZlS.iavDTSgJHZBvTFmvIUxgpfVrObnvb == null)
				{
					return 0;
				}
				return RokiKNCeFJBDwKsFfIYbuTeaCZlS.tbmGfOvfbHJPDhHivDyMWHMHzOFT.uPeUlwYvPAkrttRmaFOlehRvDIel;
			}
		}

		public DirectInputDeviceType deviceType
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return DirectInputDeviceType.Device;
				}
				if (!vKjAUNNywIoBfYnGsYOabkqfAfgkA || !base.enabled)
				{
					return DirectInputDeviceType.Device;
				}
				if (RokiKNCeFJBDwKsFfIYbuTeaCZlS.iavDTSgJHZBvTFmvIUxgpfVrObnvb == null)
				{
					return DirectInputDeviceType.Device;
				}
				return (DirectInputDeviceType)RokiKNCeFJBDwKsFfIYbuTeaCZlS.tbmGfOvfbHJPDhHivDyMWHMHzOFT.wJjWoUWIsYyuiGJuBmiAlBQeDNmD;
			}
		}

		public int deviceSubtype
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!vKjAUNNywIoBfYnGsYOabkqfAfgkA || !base.enabled)
				{
					return 0;
				}
				if (RokiKNCeFJBDwKsFfIYbuTeaCZlS.iavDTSgJHZBvTFmvIUxgpfVrObnvb == null)
				{
					return 0;
				}
				return RokiKNCeFJBDwKsFfIYbuTeaCZlS.tbmGfOvfbHJPDhHivDyMWHMHzOFT.flsZRWQsaIcWqjZddOMJAWZYyXSF;
			}
		}

		public int rawType
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!vKjAUNNywIoBfYnGsYOabkqfAfgkA || !base.enabled)
				{
					return 0;
				}
				if (RokiKNCeFJBDwKsFfIYbuTeaCZlS.iavDTSgJHZBvTFmvIUxgpfVrObnvb == null)
				{
					return 0;
				}
				return RokiKNCeFJBDwKsFfIYbuTeaCZlS.tbmGfOvfbHJPDhHivDyMWHMHzOFT.cAOEpnchXxplUbvTfoJGMXnSBljIB;
			}
		}

		public bool isHumanInterfaceDevice
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return false;
				}
				if (!vKjAUNNywIoBfYnGsYOabkqfAfgkA || !base.enabled)
				{
					return false;
				}
				if (RokiKNCeFJBDwKsFfIYbuTeaCZlS.iavDTSgJHZBvTFmvIUxgpfVrObnvb == null)
				{
					return false;
				}
				return RokiKNCeFJBDwKsFfIYbuTeaCZlS.tbmGfOvfbHJPDhHivDyMWHMHzOFT.tRyadbDHPaElKHkhapxQIgvDhiUTA;
			}
		}

		public DirectInputDeviceAxisMode axisMode
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return DirectInputDeviceAxisMode.Absolute;
				}
				if (!vKjAUNNywIoBfYnGsYOabkqfAfgkA || !base.enabled)
				{
					return DirectInputDeviceAxisMode.Absolute;
				}
				return (DirectInputDeviceAxisMode)RokiKNCeFJBDwKsFfIYbuTeaCZlS.iavDTSgJHZBvTFmvIUxgpfVrObnvb.ZVHWpcVAPAcfasMqWKZyxBQxZmuU.iUiSHlEwBCTtkvjyzsPSAdMgLJJW;
			}
		}

		public int bufferSize
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!vKjAUNNywIoBfYnGsYOabkqfAfgkA || !base.enabled)
				{
					return 0;
				}
				return RokiKNCeFJBDwKsFfIYbuTeaCZlS.iavDTSgJHZBvTFmvIUxgpfVrObnvb.ZVHWpcVAPAcfasMqWKZyxBQxZmuU.cqSkvkAmvHmhuGAoNeejvZYMNhpp;
			}
		}

		public Guid classGuid
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return Guid.Empty;
				}
				if (!vKjAUNNywIoBfYnGsYOabkqfAfgkA || !base.enabled)
				{
					return Guid.Empty;
				}
				return RokiKNCeFJBDwKsFfIYbuTeaCZlS.iavDTSgJHZBvTFmvIUxgpfVrObnvb.ZVHWpcVAPAcfasMqWKZyxBQxZmuU.MEHIlaWyujxNucWhPCvMvdlnUHGF;
			}
		}

		public int forceFeedbackGain
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!vKjAUNNywIoBfYnGsYOabkqfAfgkA || !base.enabled)
				{
					return 0;
				}
				return RokiKNCeFJBDwKsFfIYbuTeaCZlS.iavDTSgJHZBvTFmvIUxgpfVrObnvb.ZVHWpcVAPAcfasMqWKZyxBQxZmuU.YwxfVlEAzcMvCRHJPgtdwBINwYwb;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (vKjAUNNywIoBfYnGsYOabkqfAfgkA && base.enabled)
				{
					RokiKNCeFJBDwKsFfIYbuTeaCZlS.iavDTSgJHZBvTFmvIUxgpfVrObnvb.ZVHWpcVAPAcfasMqWKZyxBQxZmuU.YwxfVlEAzcMvCRHJPgtdwBINwYwb = value;
				}
			}
		}

		public string interfacePath
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!vKjAUNNywIoBfYnGsYOabkqfAfgkA || !base.enabled)
				{
					return string.Empty;
				}
				return RokiKNCeFJBDwKsFfIYbuTeaCZlS.iavDTSgJHZBvTFmvIUxgpfVrObnvb.ZVHWpcVAPAcfasMqWKZyxBQxZmuU.VLTgKPRWXpYtQNFGpcIQkAFzxfyK;
			}
		}

		public int joystickId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!vKjAUNNywIoBfYnGsYOabkqfAfgkA || !base.enabled)
				{
					return 0;
				}
				return RokiKNCeFJBDwKsFfIYbuTeaCZlS.iavDTSgJHZBvTFmvIUxgpfVrObnvb.ZVHWpcVAPAcfasMqWKZyxBQxZmuU.QLEEWiasqjIkNrXoovyLnYZJtFLGA;
			}
		}

		ushort IHIDControllerExtension.productId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!vKjAUNNywIoBfYnGsYOabkqfAfgkA || !base.enabled)
				{
					return 0;
				}
				return (ushort)RokiKNCeFJBDwKsFfIYbuTeaCZlS.iavDTSgJHZBvTFmvIUxgpfVrObnvb.ZVHWpcVAPAcfasMqWKZyxBQxZmuU.zdfuVksFXiQtCHPlhGPiXWmpEMBKA;
			}
		}

		ushort IHIDControllerExtension.vendorId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!vKjAUNNywIoBfYnGsYOabkqfAfgkA || !base.enabled)
				{
					return 0;
				}
				return (ushort)RokiKNCeFJBDwKsFfIYbuTeaCZlS.iavDTSgJHZBvTFmvIUxgpfVrObnvb.ZVHWpcVAPAcfasMqWKZyxBQxZmuU.wlEVOpJLteSEIhAOUIIkDMwszDqu;
			}
		}

		string IHIDControllerExtension.manufacturer => string.Empty;

		internal DirectInputControllerExtension(UTyQEMVineRQmjtixsdHzIMSbUZe P_0, rFYMuRcYbuHgyLSUxjNPLSHTPkLR P_1)
			: base(new zWndpnDEZhKWnkRJMKMGDiUjkwsg(P_0, P_1))
		{
		}

		private DirectInputControllerExtension(DirectInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (vKjAUNNywIoBfYnGsYOabkqfAfgkA)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			RokiKNCeFJBDwKsFfIYbuTeaCZlS = source as zWndpnDEZhKWnkRJMKMGDiUjkwsg;
			vKjAUNNywIoBfYnGsYOabkqfAfgkA = RokiKNCeFJBDwKsFfIYbuTeaCZlS != null;
		}

		internal override Controller.Extension Clone()
		{
			return new DirectInputControllerExtension(this);
		}
	}
}
