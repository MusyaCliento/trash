using UnityEngine;

namespace Rewired.ControllerExtensions.Internal
{
	public interface IDualShock4DualSenseCommonExtensionSource
	{
		float batteryLevel { get; }

		bool batteryCharging { get; }

		float leftMotor { get; set; }

		float rightMotor { get; set; }

		float lightColorR { get; set; }

		float lightColorG { get; set; }

		float lightColorB { get; set; }

		float lightFlashOnDuration { get; set; }

		float lightFlashOffDuration { get; set; }

		Vector3 accelerometerValue { get; }

		Vector3 accelerometerValueRaw { get; }

		Vector3 gyroscopeValue { get; }

		Vector3 gyroscopeValueRaw { get; }

		Vector3 lastGyroscopeValue { get; }

		Vector3 lastGyroscopeValueRaw { get; }

		Quaternion orientation { get; }

		int maxTouches { get; }

		void ResetOrientation();

		int GetTouchCount();

		bool IsTouchingAtTouchId(int touchId);

		bool IsTouchingAtIndex(int index);

		int GetTouchIdAtIndex(int index);

		bool GetTouchPositionByIndex(int index, out Vector2 position);

		bool GetTouchPositionByTouchId(int touchId, out Vector2 position);

		bool GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY);

		bool GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY);

		void StopLightFlash();

		void StopVibration();
	}
}
