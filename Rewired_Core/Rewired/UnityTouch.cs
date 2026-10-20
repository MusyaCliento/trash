using Rewired.Config;
using UnityEngine;

namespace Rewired
{
	public struct UnityTouch
	{
		public enum TouchPhase
		{
			Began = 0,
			Moved = 1,
			Stationary = 2,
			Ended = 3,
			Canceled = 4
		}

		public enum TouchType
		{
			Direct = 0,
			Indirect = 1,
			Stylus = 2
		}

		public UnityInputSourceType inputSourceType;

		public float altitudeAngle;

		public float azimuthAngle;

		public Vector2 deltaPosition;

		public float deltaTime;

		public int fingerId;

		public float maximumPossiblePressure;

		public TouchPhase phase;

		public Vector2 position;

		public float pressure;

		public float radius;

		public float radiusVariance;

		public Vector2 rawPosition;

		public int tapCount;

		public TouchType type;
	}
}
