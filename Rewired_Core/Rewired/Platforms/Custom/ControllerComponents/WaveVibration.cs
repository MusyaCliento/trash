using Rewired.Utils;

namespace Rewired.Platforms.Custom.ControllerComponents
{
	public struct WaveVibration
	{
		private float VtnlajoArSWvBDbMHnKBDmfSgskn;

		private float JLUGzTVPAViZylwpUDwRuChmAKHg;

		public float amplitude
		{
			get
			{
				return VtnlajoArSWvBDbMHnKBDmfSgskn;
			}
			set
			{
				VtnlajoArSWvBDbMHnKBDmfSgskn = MathTools.Clamp01(value);
			}
		}

		public float frequency
		{
			get
			{
				return JLUGzTVPAViZylwpUDwRuChmAKHg;
			}
			set
			{
				JLUGzTVPAViZylwpUDwRuChmAKHg = MathTools.Clamp01(value);
			}
		}

		public WaveVibration(float P_0, float P_1)
		{
			VtnlajoArSWvBDbMHnKBDmfSgskn = MathTools.Clamp01(P_0);
			JLUGzTVPAViZylwpUDwRuChmAKHg = MathTools.Clamp01(P_1);
		}
	}
}
