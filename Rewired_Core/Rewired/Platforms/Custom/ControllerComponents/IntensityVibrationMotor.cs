namespace Rewired.Platforms.Custom.ControllerComponents
{
	public class IntensityVibrationMotor : VibrationMotor<IntensityVibration>, IIntensityVibrationMotor, IVibrationMotor
	{
		public override void SetVibration(IntensityVibration vibration, float duration)
		{
			if (vibration.intensity == 0f)
			{
				Clear();
			}
			else
			{
				base.SetVibration(vibration, duration);
			}
		}

		void IIntensityVibrationMotor.SetVibration(IntensityVibration vibration, float duration)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(vibration, duration);
		}

		protected override IntensityVibration GetDefaultValue()
		{
			return default(IntensityVibration);
		}
	}
}
