using System;
using System.Collections.Generic;

namespace Rewired.Platforms.Custom
{
	public abstract class CustomPlatformInputSource : CustomInputSource
	{
		public new abstract class Joystick : CustomInputSource.Joystick
		{
			protected Joystick(string P_0, long P_1, int P_2, int P_3)
				: base(P_0, P_1, P_2, P_3)
			{
				_isConnected = true;
			}
		}

		public sealed class InitOptions
		{
			public CustomPlatformUnifiedKeyboardSource unifiedKeyboardSource;

			public CustomPlatformUnifiedMouseSource unifiedMouseSource;
		}

		private readonly CustomPlatformConfigVars vIyHxBmDTapFhkVhzoZtMkcRtfRK;

		private readonly bool KCTZFpsrFkaebGiCnkvTscxqkWgM;

		private readonly bool gXlsAkIVHINvNBQqcdvlzItnmvwJ;

		private bool HlXKLRukqUgvYRMHntgOonWiUEyD;

		protected CustomPlatformInputSource(CustomPlatformConfigVars P_0, InitOptions P_1)
			: base(100, (P_1 != null && P_1.unifiedKeyboardSource != null && P_0.useNativeKeyboard) ? new QsWTxiVUdoQOCnINxMCPYdSoPrQg(P_1.unifiedKeyboardSource) : null, (P_1 != null && P_1.unifiedMouseSource != null && P_0.useNativeMouse) ? new xghRvlLxyPpXuZsJSeOklBaJSdvg(P_1.unifiedMouseSource) : null)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("configVars");
			}
			vIyHxBmDTapFhkVhzoZtMkcRtfRK = P_0;
			if (P_1 == null || P_1.unifiedKeyboardSource == null)
			{
				P_0.useNativeKeyboard = false;
			}
			if (P_1 == null || P_1.unifiedMouseSource == null)
			{
				P_0.useNativeMouse = false;
			}
			KCTZFpsrFkaebGiCnkvTscxqkWgM = P_0.useNativeKeyboard;
			gXlsAkIVHINvNBQqcdvlzItnmvwJ = P_0.useNativeMouse;
		}

		internal virtual void quMlLgEXCFXNHKEbmcTVpSkaIxrv()
		{
			base.xwgFJSCCAtKsEYtsyekkPgdVaXbwA();
			if (KCTZFpsrFkaebGiCnkvTscxqkWgM && kNkiwkCGFNGsPxUIStjGksYSXuwC() is pRDgLchjiEOPcnRILfvcikMCaUIN)
			{
				(kNkiwkCGFNGsPxUIStjGksYSXuwC() as pRDgLchjiEOPcnRILfvcikMCaUIN).FoEgKvCSSVATzcsDVVwiHqBhsGQq();
			}
			if (gXlsAkIVHINvNBQqcdvlzItnmvwJ && fzeVNVbjdoenzXBHzdVDVEiBmWjg() is pRDgLchjiEOPcnRILfvcikMCaUIN)
			{
				(fzeVNVbjdoenzXBHzdVDVEiBmWjg() as pRDgLchjiEOPcnRILfvcikMCaUIN).FoEgKvCSSVATzcsDVVwiHqBhsGQq();
			}
		}

		protected override void OnAfterUpdate()
		{
			base.OnAfterUpdate();
			IList<CustomInputSource.Joystick> joysticks = GetJoysticks();
			int count = joysticks.Count;
			for (int i = 0; i < count; i++)
			{
				joysticks[i].Update2();
			}
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (!HlXKLRukqUgvYRMHntgOonWiUEyD)
			{
				HlXKLRukqUgvYRMHntgOonWiUEyD = true;
			}
		}
	}
}
