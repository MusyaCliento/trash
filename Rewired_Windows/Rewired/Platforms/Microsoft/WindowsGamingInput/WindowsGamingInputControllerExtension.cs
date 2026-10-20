using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Microsoft.WindowsGamingInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class WindowsGamingInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class xeKeuBNIzNgnRTrXsVoXOVgAIRAG : IControllerExtensionSource
		{
			private GYSwgkbaVYVjtqJQdbyLjufrdwPAA KQwrLJmUrsjJTNUsdallfQYmAwifA;

			public GYSwgkbaVYVjtqJQdbyLjufrdwPAA twihylKJmOOxOdRhqGNKkdpnxYdI => KQwrLJmUrsjJTNUsdallfQYmAwifA;

			public xeKeuBNIzNgnRTrXsVoXOVgAIRAG(GYSwgkbaVYVjtqJQdbyLjufrdwPAA P_0)
			{
				KQwrLJmUrsjJTNUsdallfQYmAwifA = P_0;
			}
		}

		private xeKeuBNIzNgnRTrXsVoXOVgAIRAG jnWMtXaagCKFJebPOOLTHpqPUErP;

		private bool hIDaTyUwgCfKdFAVBdZYkkAeKNsT;

		private Joystick joystick => GetController<Joystick>();

		public DeviceType deviceType => (DeviceType)jnWMtXaagCKFJebPOOLTHpqPUErP.twihylKJmOOxOdRhqGNKkdpnxYdI.vxWAOXKtrIlNsYDtpXttCwLCymuJ;

		public IntPtr nativePointer
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return IntPtr.Zero;
				}
				if (!hIDaTyUwgCfKdFAVBdZYkkAeKNsT || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (jnWMtXaagCKFJebPOOLTHpqPUErP.twihylKJmOOxOdRhqGNKkdpnxYdI == null)
				{
					return IntPtr.Zero;
				}
				return jnWMtXaagCKFJebPOOLTHpqPUErP.twihylKJmOOxOdRhqGNKkdpnxYdI.nzLkcNfYQNcZziYNDBJPMJgnNZGP;
			}
		}

		public string nonRoamableId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!hIDaTyUwgCfKdFAVBdZYkkAeKNsT || !base.enabled)
				{
					return string.Empty;
				}
				if (jnWMtXaagCKFJebPOOLTHpqPUErP.twihylKJmOOxOdRhqGNKkdpnxYdI == null)
				{
					return string.Empty;
				}
				return jnWMtXaagCKFJebPOOLTHpqPUErP.twihylKJmOOxOdRhqGNKkdpnxYdI.wAWwugIxLsQMhleLVfPKJqhKOXHRA;
			}
		}

		public bool isWireless
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return false;
				}
				if (!hIDaTyUwgCfKdFAVBdZYkkAeKNsT || !base.enabled)
				{
					return false;
				}
				if (jnWMtXaagCKFJebPOOLTHpqPUErP.twihylKJmOOxOdRhqGNKkdpnxYdI == null)
				{
					return false;
				}
				return jnWMtXaagCKFJebPOOLTHpqPUErP.twihylKJmOOxOdRhqGNKkdpnxYdI.WredYwYmPOkLyVoXKuMIXCGtzJRe;
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
				if (!hIDaTyUwgCfKdFAVBdZYkkAeKNsT || !base.enabled)
				{
					return string.Empty;
				}
				if (jnWMtXaagCKFJebPOOLTHpqPUErP.twihylKJmOOxOdRhqGNKkdpnxYdI == null)
				{
					return string.Empty;
				}
				return jnWMtXaagCKFJebPOOLTHpqPUErP.twihylKJmOOxOdRhqGNKkdpnxYdI.zsqqRgVbCZUvlcLtmNrbcrDQoXOO;
			}
		}

		string IHIDControllerExtension.manufacturer => string.Empty;

		ushort IHIDControllerExtension.vendorId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!hIDaTyUwgCfKdFAVBdZYkkAeKNsT || !base.enabled)
				{
					return 0;
				}
				if (jnWMtXaagCKFJebPOOLTHpqPUErP.twihylKJmOOxOdRhqGNKkdpnxYdI == null)
				{
					return 0;
				}
				return jnWMtXaagCKFJebPOOLTHpqPUErP.twihylKJmOOxOdRhqGNKkdpnxYdI.TSJYXEZNXMWoZQNpmHRZexREYzvc.vendorId;
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
				if (!hIDaTyUwgCfKdFAVBdZYkkAeKNsT || !base.enabled)
				{
					return 0;
				}
				if (jnWMtXaagCKFJebPOOLTHpqPUErP.twihylKJmOOxOdRhqGNKkdpnxYdI == null)
				{
					return 0;
				}
				return jnWMtXaagCKFJebPOOLTHpqPUErP.twihylKJmOOxOdRhqGNKkdpnxYdI.TSJYXEZNXMWoZQNpmHRZexREYzvc.productId;
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
				if (!hIDaTyUwgCfKdFAVBdZYkkAeKNsT || !base.enabled)
				{
					return 0;
				}
				if (jnWMtXaagCKFJebPOOLTHpqPUErP.twihylKJmOOxOdRhqGNKkdpnxYdI == null)
				{
					return 0;
				}
				return jnWMtXaagCKFJebPOOLTHpqPUErP.twihylKJmOOxOdRhqGNKkdpnxYdI.AoMtxTlhmHocgVxOwhsCOCEbJfWM;
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
				if (!hIDaTyUwgCfKdFAVBdZYkkAeKNsT || !base.enabled)
				{
					return 0;
				}
				if (jnWMtXaagCKFJebPOOLTHpqPUErP.twihylKJmOOxOdRhqGNKkdpnxYdI == null)
				{
					return 0;
				}
				return jnWMtXaagCKFJebPOOLTHpqPUErP.twihylKJmOOxOdRhqGNKkdpnxYdI.hyHpcoYQmPTnupTuhkTOchvGnSzQ;
			}
		}

		internal WindowsGamingInputControllerExtension(GYSwgkbaVYVjtqJQdbyLjufrdwPAA P_0)
			: base(new xeKeuBNIzNgnRTrXsVoXOVgAIRAG(P_0))
		{
		}

		private WindowsGamingInputControllerExtension(WindowsGamingInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (hIDaTyUwgCfKdFAVBdZYkkAeKNsT)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			jnWMtXaagCKFJebPOOLTHpqPUErP = source as xeKeuBNIzNgnRTrXsVoXOVgAIRAG;
			hIDaTyUwgCfKdFAVBdZYkkAeKNsT = jnWMtXaagCKFJebPOOLTHpqPUErP != null;
		}

		internal override Controller.Extension Clone()
		{
			return new WindowsGamingInputControllerExtension(this);
		}
	}
}
