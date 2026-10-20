using Rewired.Utils;

namespace Rewired.Platforms.Custom.ControllerComponents
{
	public struct IntensityVibration
	{
		private float hngOOaTWJigURKxrKKAgyVKKGzzK;

		public float intensity
		{
			get
			{
				return hngOOaTWJigURKxrKKAgyVKKGzzK;
			}
			set
			{
				hngOOaTWJigURKxrKKAgyVKKGzzK = MathTools.Clamp01(value);
			}
		}

		public IntensityVibration(float P_0)
		{
			hngOOaTWJigURKxrKKAgyVKKGzzK = MathTools.Clamp01(P_0);
		}
	}
}
