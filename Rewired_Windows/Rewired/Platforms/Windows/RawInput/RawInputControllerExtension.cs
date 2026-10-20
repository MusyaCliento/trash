using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.RawInput
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class RawInputControllerExtension : Controller.Extension, IHIDControllerExtension
	{
		private class AAUHUtyRQNHSFSHiVeHUHPHdPKSIb : IControllerExtensionSource
		{
			private QMQjWbDoKRhaRVmjlawINgNoJnPr fSxuzJYdDwefTNygWrVLsMuYHzzP;

			public QMQjWbDoKRhaRVmjlawINgNoJnPr MLHVmxkOpzESbjCPEqKPrcmLcjuDb => fSxuzJYdDwefTNygWrVLsMuYHzzP;

			public AAUHUtyRQNHSFSHiVeHUHPHdPKSIb(QMQjWbDoKRhaRVmjlawINgNoJnPr P_0)
			{
				fSxuzJYdDwefTNygWrVLsMuYHzzP = P_0;
			}
		}

		private AAUHUtyRQNHSFSHiVeHUHPHdPKSIb xJTFHXREFzfShdrZuTHsyXWBSeZj;

		private bool WQWVZjlAcLFgPGTaZXrMnhZosBor;

		private Joystick joystick => GetController<Joystick>();

		public IntPtr hidDeviceHandle
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return IntPtr.Zero;
				}
				if (!WQWVZjlAcLFgPGTaZXrMnhZosBor || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb == null)
				{
					return IntPtr.Zero;
				}
				return xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb.DBTqBLqRsnBRzJXzDKTzOGLLAJiT.TbIhnNJzSpWiqjSMyhHsQPjClOgG;
			}
		}

		public IntPtr rawInputDeviceHandle
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return IntPtr.Zero;
				}
				if (!WQWVZjlAcLFgPGTaZXrMnhZosBor || !base.enabled)
				{
					return IntPtr.Zero;
				}
				if (xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb == null)
				{
					return IntPtr.Zero;
				}
				return xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb.MUjMKpvlxHyNGczJsJjSwQNkRtcs;
			}
		}

		public string devicePath
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!WQWVZjlAcLFgPGTaZXrMnhZosBor || !base.enabled)
				{
					return string.Empty;
				}
				if (xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb == null)
				{
					return string.Empty;
				}
				return xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb.DBTqBLqRsnBRzJXzDKTzOGLLAJiT.RsQMxqgZDSDzVtlFwLKirMUYRqPG;
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
				if (!WQWVZjlAcLFgPGTaZXrMnhZosBor || !base.enabled)
				{
					return string.Empty;
				}
				if (xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb == null)
				{
					return string.Empty;
				}
				return xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb.MJCEwRBVuVKSGDFqTrsuJVtjFKBab;
			}
		}

		string IHIDControllerExtension.manufacturer
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!WQWVZjlAcLFgPGTaZXrMnhZosBor || !base.enabled)
				{
					return string.Empty;
				}
				if (xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb == null)
				{
					return string.Empty;
				}
				return xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb.TpwfkVxStQbrzDQkYyLhIsDfkqmFA;
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
				if (!WQWVZjlAcLFgPGTaZXrMnhZosBor || !base.enabled)
				{
					return 0;
				}
				if (xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb == null)
				{
					return 0;
				}
				return (ushort)xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb.UIDBCQFGvhtUWvgAxequFCQKjHjA;
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
				if (!WQWVZjlAcLFgPGTaZXrMnhZosBor || !base.enabled)
				{
					return 0;
				}
				if (xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb == null)
				{
					return 0;
				}
				return (ushort)xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb.QhSgzIhvKfsJeIaXJhbIxtnlJSzmA;
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
				if (!WQWVZjlAcLFgPGTaZXrMnhZosBor || !base.enabled)
				{
					return Guid.Empty;
				}
				if (xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb == null)
				{
					return Guid.Empty;
				}
				return xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb.ivpdrYRhLgwLyrtsRFoaeEevvzRJ;
			}
		}

		public bool isBluetoothDevice
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return false;
				}
				if (!WQWVZjlAcLFgPGTaZXrMnhZosBor || !base.enabled)
				{
					return false;
				}
				if (xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb == null)
				{
					return false;
				}
				return xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb.CDIlMCeJNcMdbbkgVhwkeOlHCOww;
			}
		}

		public string bluetoothDeviceName
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				if (!WQWVZjlAcLFgPGTaZXrMnhZosBor || !base.enabled)
				{
					return string.Empty;
				}
				if (xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb == null)
				{
					return string.Empty;
				}
				return xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb.VQoWzcAGPoQlIieOrWohGPvFaMtI;
			}
		}

		public int hubId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return -1;
				}
				if (!WQWVZjlAcLFgPGTaZXrMnhZosBor || !base.enabled)
				{
					return -1;
				}
				if (xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb == null)
				{
					return -1;
				}
				return xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb.RexRfhyDMuiOORsxhVQlRffKcxOI;
			}
		}

		public int portId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return -1;
				}
				if (!WQWVZjlAcLFgPGTaZXrMnhZosBor || !base.enabled)
				{
					return -1;
				}
				if (xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb == null)
				{
					return -1;
				}
				return xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb.ILbJCMdESsTkRFboYpwuabEYgRWW;
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
				if (!WQWVZjlAcLFgPGTaZXrMnhZosBor || !base.enabled)
				{
					return 0;
				}
				if (xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb == null)
				{
					return 0;
				}
				return (ushort)xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb.DBTqBLqRsnBRzJXzDKTzOGLLAJiT.YYzFmtrEAtiRNtPjhZbbbhzJBxoo.YHaocuphiCGBhKcRoqVlRwiBJVrGA;
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
				if (!WQWVZjlAcLFgPGTaZXrMnhZosBor || !base.enabled)
				{
					return 0;
				}
				if (xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb == null)
				{
					return 0;
				}
				return (ushort)xJTFHXREFzfShdrZuTHsyXWBSeZj.MLHVmxkOpzESbjCPEqKPrcmLcjuDb.DBTqBLqRsnBRzJXzDKTzOGLLAJiT.YYzFmtrEAtiRNtPjhZbbbhzJBxoo.NEzrNjrjnXJIZxmooNEMWPidoNIu;
			}
		}

		internal RawInputControllerExtension(QMQjWbDoKRhaRVmjlawINgNoJnPr P_0)
			: base(new AAUHUtyRQNHSFSHiVeHUHPHdPKSIb(P_0))
		{
		}

		private RawInputControllerExtension(RawInputControllerExtension P_0)
			: base(P_0)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (WQWVZjlAcLFgPGTaZXrMnhZosBor)
			{
				_ = base.enabled;
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			xJTFHXREFzfShdrZuTHsyXWBSeZj = source as AAUHUtyRQNHSFSHiVeHUHPHdPKSIb;
			WQWVZjlAcLFgPGTaZXrMnhZosBor = xJTFHXREFzfShdrZuTHsyXWBSeZj != null;
		}

		internal override Controller.Extension Clone()
		{
			return new RawInputControllerExtension(this);
		}
	}
}
