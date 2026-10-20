namespace Rewired.Platforms.Custom.ControllerComponents
{
	public interface IIntensityVibrationComponent : IVibrationComponent
	{
		IntensityVibration GetVibration(int motorIndex);

		void SetVibration(IntensityVibrationCommand vibration);
	}
}
