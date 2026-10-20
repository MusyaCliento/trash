using Rewired.HID.Drivers;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class RailDriverExtension : Controller.Extension, IHIDControllerExtension
	{
		private class zfFbpYkMyvfmEVIlYXQReIlOOOkR : IControllerExtensionSource
		{
			public readonly IDriver_RailDriver SThWPrDhpBdzgZsQyxjuPHACaECEA;

			public zfFbpYkMyvfmEVIlYXQReIlOOOkR(IDriver_RailDriver P_0)
			{
				SThWPrDhpBdzgZsQyxjuPHACaECEA = P_0;
			}
		}

		private zfFbpYkMyvfmEVIlYXQReIlOOOkR krnoQqjcuUXyZvFbWrsuOQzwpovl;

		private Joystick joystick => GetController<Joystick>();

		public bool speakerEnabled
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return false;
				}
				if (krnoQqjcuUXyZvFbWrsuOQzwpovl.SThWPrDhpBdzgZsQyxjuPHACaECEA == null)
				{
					return false;
				}
				return krnoQqjcuUXyZvFbWrsuOQzwpovl.SThWPrDhpBdzgZsQyxjuPHACaECEA.SpeakerEnabled;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (krnoQqjcuUXyZvFbWrsuOQzwpovl.SThWPrDhpBdzgZsQyxjuPHACaECEA != null)
				{
					krnoQqjcuUXyZvFbWrsuOQzwpovl.SThWPrDhpBdzgZsQyxjuPHACaECEA.SpeakerEnabled = value;
				}
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
				return krnoQqjcuUXyZvFbWrsuOQzwpovl.SThWPrDhpBdzgZsQyxjuPHACaECEA.vendorId;
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
				return krnoQqjcuUXyZvFbWrsuOQzwpovl.SThWPrDhpBdzgZsQyxjuPHACaECEA.productId;
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
				return krnoQqjcuUXyZvFbWrsuOQzwpovl.SThWPrDhpBdzgZsQyxjuPHACaECEA.productName;
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
				return krnoQqjcuUXyZvFbWrsuOQzwpovl.SThWPrDhpBdzgZsQyxjuPHACaECEA.manufacturer;
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
				return krnoQqjcuUXyZvFbWrsuOQzwpovl.SThWPrDhpBdzgZsQyxjuPHACaECEA.usagePage;
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
				return krnoQqjcuUXyZvFbWrsuOQzwpovl.SThWPrDhpBdzgZsQyxjuPHACaECEA.usage;
			}
		}

		internal RailDriverExtension(IDriver_RailDriver P_0)
			: base(new zfFbpYkMyvfmEVIlYXQReIlOOOkR(P_0))
		{
		}

		private RailDriverExtension(RailDriverExtension P_0)
			: base(P_0)
		{
		}

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (krnoQqjcuUXyZvFbWrsuOQzwpovl.SThWPrDhpBdzgZsQyxjuPHACaECEA != null && base.enabled)
			{
				krnoQqjcuUXyZvFbWrsuOQzwpovl.SThWPrDhpBdzgZsQyxjuPHACaECEA.SetLEDDisplay(digitIndex, digitBitValues);
			}
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (krnoQqjcuUXyZvFbWrsuOQzwpovl.SThWPrDhpBdzgZsQyxjuPHACaECEA != null && base.enabled)
			{
				krnoQqjcuUXyZvFbWrsuOQzwpovl.SThWPrDhpBdzgZsQyxjuPHACaECEA.SetLEDDisplay(digit1BitValues, digit2BitValues, digit3BitValues);
			}
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			krnoQqjcuUXyZvFbWrsuOQzwpovl = source as zfFbpYkMyvfmEVIlYXQReIlOOOkR;
		}

		internal override Controller.Extension Clone()
		{
			return new RailDriverExtension(this);
		}
	}
}
