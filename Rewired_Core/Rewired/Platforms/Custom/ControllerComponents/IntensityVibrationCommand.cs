namespace Rewired.Platforms.Custom.ControllerComponents
{
	public struct IntensityVibrationCommand
	{
		public int motorIndex;

		public IntensityVibration vibration;

		public float duration;

		public bool stopOtherMotors;
	}
}
