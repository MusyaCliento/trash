namespace Rewired.Platforms.Custom.ControllerComponents
{
	public interface IIntensityVibrationMotor : IVibrationMotor
	{
		IntensityVibration GetVibration();

		void SetVibration(IntensityVibration vibration, float duration);
	}
}
