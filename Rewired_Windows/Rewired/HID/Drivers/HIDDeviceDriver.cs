using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Config;
using Rewired.Platforms;
using Rewired.Utils;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class HIDDeviceDriver : IControllerDriver, IDisposable
	{
		[CustomObfuscation(rename = false)]
		public enum DriverType
		{
			None = 0,
			DualShock4 = 1,
			DualSense = 2,
			RailDriver = 3,
			SwitchJoyConLeft = 4,
			SwitchJoyConRight = 5,
			SwitchProController = 6
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal struct HIDProperties
		{
			public ushort vendorId;

			public ushort productId;

			public string productName;

			public string manufacturer;

			public ushort usagePage;

			public ushort usage;

			public int maxInputReportLength;

			public int maxOutputReportLength;

			public int maxFeatureReportLength;

			public HIDProperties(ushort P_0, ushort P_1, string P_2, string P_3, ushort P_4, ushort P_5, int P_6, int P_7, int P_8)
			{
				vendorId = P_0;
				productId = P_1;
				productName = P_2;
				manufacturer = P_3;
				usagePage = P_4;
				usage = P_5;
				maxInputReportLength = P_6;
				maxOutputReportLength = P_7;
				maxFeatureReportLength = P_8;
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal interface IHIDDevice
		{
			HIDProperties properties { get; }

			bool WriteSync(svXcjurRenDjMJrGFPPkrmozhhdx outputReport, int timeoutMs);

			void WriteAsync(svXcjurRenDjMJrGFPPkrmozhhdx outputReport, int timeoutMs);

			bool ReadSync(IntPtr buffer, int bytesToRead, int timeoutMs);

			byte[] GetHidFeatureData(byte reportId, int reportLength, int timeoutMs, int retryCount);
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal struct InitArgs
		{
			public readonly UpdateLoopSetting updateLoopSetting;

			public readonly OzbKZwmCsAMtNgCdYlCwZEMUUFwG connectionType;

			public readonly int minAxisValue;

			public readonly int maxAxisValue;

			public readonly int hatZeroValue;

			public readonly int hatSpan;

			public readonly IHIDDevice hidDevice;

			public readonly Action initializedCallback;

			public InitArgs(UpdateLoopSetting P_0, OzbKZwmCsAMtNgCdYlCwZEMUUFwG P_1, int P_2, int P_3, int P_4, int P_5, IHIDDevice P_6, Action P_7)
			{
				updateLoopSetting = P_0;
				connectionType = P_1;
				minAxisValue = P_2;
				maxAxisValue = P_3;
				hatZeroValue = P_4;
				hatSpan = P_5;
				hidDevice = P_6;
				initializedCallback = P_7;
			}
		}

		public enum MiNaIzDPKzaXZdztgHayeKZcnRCwb
		{
			None = 0,
			AsyncInitialization = 1
		}

		private enum yOSWDLKMnTDqJReTukQyKDpYWkvo
		{
			None = 0,
			Initializing = 1,
			Initialized = 2,
			Error = 3
		}

		public okLUGVdjnOaHkqUoOikOkGMRQUCY[] axes;

		public JdXatRCvdrGKOPnZjOPQbsdPzHroA[] buttons;

		public GEIDFkFhuurDROYbxKEnrCaVcLKaA[] hats;

		public dHcOwexRBkWbxHglTolQUMSGZbys[] accelerometers;

		public jntvuWnVLbBPQuLLgPmMmaPxgSGi[] gyroscopes;

		public NaCRucjlkvXgCSkUJCtQCAeoSdInA[] touchpads;

		public uctGEmIAndGsnBPlyPlnhlfoOqoG[] vibrationMotors;

		public nmpBQAovYKAFTjYpVLxEGKXmVudz[] lights;

		private yOSWDLKMnTDqJReTukQyKDpYWkvo oIQUJvkHuexvCslizeozbqUVWKMs;

		private MiNaIzDPKzaXZdztgHayeKZcnRCwb PLNypcPyrccFumCbUAqCHhmCTEBl;

		private InitArgs KzNeQpaEjBBsfcukdXEKFICEMVPGc;

		[CompilerGenerated]
		private Action<MiNaIzDPKzaXZdztgHayeKZcnRCwb> rJPVEYyDUwfRAXjopeAQvupXVitl;

		[CompilerGenerated]
		private Action XkcraCrofehrLFxGVuuFlbIEDKVaA;

		private bool JslBljLGUZFTfLpHTjsMhYJTYvwp;

		int IControllerDriver.AxisCount
		{
			get
			{
				if (axes == null)
				{
					return 0;
				}
				return axes.Length;
			}
		}

		int IControllerDriver.ButtonCount
		{
			get
			{
				if (buttons == null)
				{
					return 0;
				}
				return buttons.Length;
			}
		}

		int IControllerDriver.HatCount
		{
			get
			{
				if (hats == null)
				{
					return 0;
				}
				return hats.Length;
			}
		}

		int IControllerDriver.AccelerometerCount
		{
			get
			{
				if (accelerometers == null)
				{
					return 0;
				}
				return accelerometers.Length;
			}
		}

		int IControllerDriver.GyroscopeCount
		{
			get
			{
				if (gyroscopes == null)
				{
					return 0;
				}
				return gyroscopes.Length;
			}
		}

		int IControllerDriver.TouchpadCount
		{
			get
			{
				if (touchpads == null)
				{
					return 0;
				}
				return touchpads.Length;
			}
		}

		int IControllerDriver.LightCount
		{
			get
			{
				if (lights == null)
				{
					return 0;
				}
				return lights.Length;
			}
		}

		int IControllerDriver.VibrationMotorCount
		{
			get
			{
				if (vibrationMotors == null)
				{
					return 0;
				}
				return vibrationMotors.Length;
			}
		}

		public bool IsInitialized => oIQUJvkHuexvCslizeozbqUVWKMs == yOSWDLKMnTDqJReTukQyKDpYWkvo.Initialized;

		public MiNaIzDPKzaXZdztgHayeKZcnRCwb Errors => PLNypcPyrccFumCbUAqCHhmCTEBl;

		protected InitArgs initArgs => KzNeQpaEjBBsfcukdXEKFICEMVPGc;

		protected bool disposed => JslBljLGUZFTfLpHTjsMhYJTYvwp;

		public event Action<MiNaIzDPKzaXZdztgHayeKZcnRCwb> ErrorEvent
		{
			[CompilerGenerated]
			add
			{
				Action<MiNaIzDPKzaXZdztgHayeKZcnRCwb> action = rJPVEYyDUwfRAXjopeAQvupXVitl;
				Action<MiNaIzDPKzaXZdztgHayeKZcnRCwb> action2;
				do
				{
					action2 = action;
					Action<MiNaIzDPKzaXZdztgHayeKZcnRCwb> value2 = (Action<MiNaIzDPKzaXZdztgHayeKZcnRCwb>)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref rJPVEYyDUwfRAXjopeAQvupXVitl, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action<MiNaIzDPKzaXZdztgHayeKZcnRCwb> action = rJPVEYyDUwfRAXjopeAQvupXVitl;
				Action<MiNaIzDPKzaXZdztgHayeKZcnRCwb> action2;
				do
				{
					action2 = action;
					Action<MiNaIzDPKzaXZdztgHayeKZcnRCwb> value2 = (Action<MiNaIzDPKzaXZdztgHayeKZcnRCwb>)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref rJPVEYyDUwfRAXjopeAQvupXVitl, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public event Action InitializedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = XkcraCrofehrLFxGVuuFlbIEDKVaA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref XkcraCrofehrLFxGVuuFlbIEDKVaA, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = XkcraCrofehrLFxGVuuFlbIEDKVaA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref XkcraCrofehrLFxGVuuFlbIEDKVaA, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		protected HIDDeviceDriver(InitArgs P_0)
		{
			KzNeQpaEjBBsfcukdXEKFICEMVPGc = P_0;
		}

		public abstract void Update(UpdateLoopType updateLoop);

		public abstract bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp);

		public abstract Controller.Extension CreateControllerExtension();

		private void IjfrtoLtxgJOTJBKKLrCqDXsEuaHA()
		{
			if (oIQUJvkHuexvCslizeozbqUVWKMs == yOSWDLKMnTDqJReTukQyKDpYWkvo.None)
			{
				oIQUJvkHuexvCslizeozbqUVWKMs = yOSWDLKMnTDqJReTukQyKDpYWkvo.Initializing;
				OnInitialize();
			}
		}

		protected abstract void OnInitialize();

		protected void InitializationFinished(bool initialized)
		{
			if (oIQUJvkHuexvCslizeozbqUVWKMs == yOSWDLKMnTDqJReTukQyKDpYWkvo.Initializing)
			{
				oIQUJvkHuexvCslizeozbqUVWKMs = (initialized ? yOSWDLKMnTDqJReTukQyKDpYWkvo.Initialized : yOSWDLKMnTDqJReTukQyKDpYWkvo.Error);
				if (oIQUJvkHuexvCslizeozbqUVWKMs == yOSWDLKMnTDqJReTukQyKDpYWkvo.Initialized)
				{
					KzNeQpaEjBBsfcukdXEKFICEMVPGc.initializedCallback?.Invoke();
					XkcraCrofehrLFxGVuuFlbIEDKVaA?.Invoke();
				}
			}
		}

		protected void Error(MiNaIzDPKzaXZdztgHayeKZcnRCwb error)
		{
			PLNypcPyrccFumCbUAqCHhmCTEBl |= error;
			rJPVEYyDUwfRAXjopeAQvupXVitl?.Invoke(error);
		}

		public static HIDDeviceDriver GetDriver(DriverType driverId, InitArgs hidDriverInitArgs)
		{
			HIDDeviceDriver hIDDeviceDriver = null;
			try
			{
				switch (driverId)
				{
				case DriverType.DualShock4:
					if (UnityTools.effectivePlatform == Platform.Linux)
					{
						return null;
					}
					hIDDeviceDriver = new DualShock4Driver(hidDriverInitArgs);
					break;
				case DriverType.DualSense:
					hIDDeviceDriver = new DualSenseDriver(hidDriverInitArgs);
					break;
				case DriverType.RailDriver:
					hIDDeviceDriver = new RailDriverDriver(hidDriverInitArgs);
					break;
				case DriverType.SwitchJoyConLeft:
					hIDDeviceDriver = new NintendoSwitchJoyConLeftDriver(hidDriverInitArgs);
					break;
				case DriverType.SwitchJoyConRight:
					hIDDeviceDriver = new NintendoSwitchJoyConRightDriver(hidDriverInitArgs);
					break;
				case DriverType.SwitchProController:
					hIDDeviceDriver = new NintendoSwitchProControllerDriver(hidDriverInitArgs);
					break;
				}
				hIDDeviceDriver?.IjfrtoLtxgJOTJBKKLrCqDXsEuaHA();
				return hIDDeviceDriver;
			}
			catch
			{
				if (hIDDeviceDriver != null)
				{
					try
					{
						hIDDeviceDriver.Dispose();
					}
					catch
					{
					}
				}
				return null;
			}
		}

		public static DriverType FindDriverId(int vendorId, int productId, IList<EnhancedDeviceSupportDeviceType> exclusions)
		{
			if (DualShock4Driver.Matches(vendorId, productId))
			{
				if (exclusions != null && exclusions.Contains(EnhancedDeviceSupportDeviceType.SonyDualShock4))
				{
					return DriverType.None;
				}
				return DriverType.DualShock4;
			}
			if (DualSenseDriver.Matches(vendorId, productId))
			{
				if (exclusions != null && exclusions.Contains(EnhancedDeviceSupportDeviceType.SonyDualSense))
				{
					return DriverType.None;
				}
				return DriverType.DualSense;
			}
			if (RailDriverDriver.Matches(vendorId, productId))
			{
				if (exclusions != null && exclusions.Contains(EnhancedDeviceSupportDeviceType.PIEngineeringRailDriver))
				{
					return DriverType.None;
				}
				return DriverType.RailDriver;
			}
			if (NintendoSwitchJoyConLeftDriver.Matches(vendorId, productId))
			{
				if (exclusions != null && exclusions.Contains(EnhancedDeviceSupportDeviceType.NintendoSwitchJoyConLeft))
				{
					return DriverType.None;
				}
				return DriverType.SwitchJoyConLeft;
			}
			if (NintendoSwitchJoyConRightDriver.Matches(vendorId, productId))
			{
				if (exclusions != null && exclusions.Contains(EnhancedDeviceSupportDeviceType.NintendoSwitchJoyConRight))
				{
					return DriverType.None;
				}
				return DriverType.SwitchJoyConRight;
			}
			if (NintendoSwitchProControllerDriver.Matches(vendorId, productId))
			{
				if (exclusions != null && exclusions.Contains(EnhancedDeviceSupportDeviceType.NintendoSwitchProController))
				{
					return DriverType.None;
				}
				return DriverType.SwitchProController;
			}
			return DriverType.None;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~HIDDeviceDriver()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!JslBljLGUZFTfLpHTjsMhYJTYvwp)
			{
				JslBljLGUZFTfLpHTjsMhYJTYvwp = true;
			}
		}

		public static bool IsCriticalError(MiNaIzDPKzaXZdztgHayeKZcnRCwb errors)
		{
			if ((errors & MiNaIzDPKzaXZdztgHayeKZcnRCwb.AsyncInitialization) != MiNaIzDPKzaXZdztgHayeKZcnRCwb.None)
			{
				return true;
			}
			return false;
		}
	}
}
