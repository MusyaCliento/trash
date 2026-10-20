namespace Rewired.ControllerExtensions.Internal
{
	public interface IDualSenseExtensionSource : IDualShock4DualSenseCommonExtensionSource
	{
		DualSenseVibrationMode vibrationMode { get; set; }

		DualSenseMicrophoneLightMode microphoneLightMode { get; set; }

		DualSenseOtherLightBrightness otherLightBrightness { get; set; }

		DualSensePlayerLightFlags playerLights { get; set; }

		bool SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect);

		DualSenseTriggerEffectStates GetTriggerEffectStates();
	}
}
