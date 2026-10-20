namespace Rewired.Platforms.Custom.ControllerComponents
{
	public interface IVibrationComponent
	{
		int motorCount { get; }

		void StopVibration();

		void StopVibration(int motorIndex);
	}
}
