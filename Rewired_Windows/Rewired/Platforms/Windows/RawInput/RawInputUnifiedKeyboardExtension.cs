using Rewired.Interfaces;

namespace Rewired.Platforms.Windows.RawInput
{
	public sealed class RawInputUnifiedKeyboardExtension : Controller.Extension
	{
		private class YYJGHCMKGHMlVmORmeSdgFSrxjzN : IControllerExtensionSource
		{
			private pKsmEHzqbGUnPrIgUbPlXlJimyVh wxKMepBCHmsptnnofkvPmADsIUvCA;

			public pKsmEHzqbGUnPrIgUbPlXlJimyVh uhmcAuEvdycpmYdvuVSxheRsiEIv => wxKMepBCHmsptnnofkvPmADsIUvCA;

			public YYJGHCMKGHMlVmORmeSdgFSrxjzN(pKsmEHzqbGUnPrIgUbPlXlJimyVh P_0)
			{
				wxKMepBCHmsptnnofkvPmADsIUvCA = P_0;
			}
		}

		private YYJGHCMKGHMlVmORmeSdgFSrxjzN HzvaBmFVacYPNBxzXcSsEQTfOZplb;

		private bool ZaMgCaSESZfELNSGyQftqnoFSgiT;

		public KeyboardLayout keyboardLayout
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return KeyboardLayout.US;
				}
				if (!ZaMgCaSESZfELNSGyQftqnoFSgiT || !base.enabled)
				{
					return KeyboardLayout.US;
				}
				return HzvaBmFVacYPNBxzXcSsEQTfOZplb.uhmcAuEvdycpmYdvuVSxheRsiEIv.hqaiRKzHwcGEWHVuyUwHUpmfIOwH;
			}
		}

		internal RawInputUnifiedKeyboardExtension(pKsmEHzqbGUnPrIgUbPlXlJimyVh P_0)
			: base(new YYJGHCMKGHMlVmORmeSdgFSrxjzN(P_0))
		{
		}

		private RawInputUnifiedKeyboardExtension(RawInputUnifiedKeyboardExtension P_0)
			: base(P_0)
		{
		}

		internal Controller.Extension DzUVszNlxItqYCnLhDCwVXRkTLIT()
		{
			return new RawInputUnifiedKeyboardExtension(this);
		}

		internal void YnjgjccJRSPkZiEhBKnzVtorTLshc(UpdateLoopType P_0)
		{
			if (ZaMgCaSESZfELNSGyQftqnoFSgiT)
			{
				_ = base.enabled;
			}
		}

		internal void ctaEBkDWzjyjOGXFslhCIlXgFPaE(IControllerExtensionSource P_0)
		{
			HzvaBmFVacYPNBxzXcSsEQTfOZplb = P_0 as YYJGHCMKGHMlVmORmeSdgFSrxjzN;
			ZaMgCaSESZfELNSGyQftqnoFSgiT = HzvaBmFVacYPNBxzXcSsEQTfOZplb != null;
		}
	}
}
