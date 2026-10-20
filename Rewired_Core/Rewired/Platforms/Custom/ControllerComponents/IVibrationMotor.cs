namespace Rewired.Platforms.Custom.ControllerComponents
{
	public interface IVibrationMotor
	{
		float renewInterval { get; set; }

		void Update();

		void Clear();
	}
}
