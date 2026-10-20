using System;
using System.Collections.Generic;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Platforms.UnityInputManager
{
	internal sealed class UnityInputManagerProxy : UnityInputManagerProxyBase
	{
		private int _joystickNamesLastFrameChecked;

		private string[] _joystickNames;

		public override string inputSourceTypeString => "UnityInputManager";

		public override Vector2 mousePosition => Input.mousePosition;

		public override Vector2 mouseScrollDelta => Input.mouseScrollDelta;

		public override bool anyKey => Input.anyKey;

		public override bool mousePresent => Input.mousePresent;

		public override Vector3 acceleration => Input.acceleration;

		public override bool touchSupported => Input.touchSupported;

		public override int touchCount => Input.touchCount;

		public override UnityTouch[] touches
		{
			get
			{
				Touch[] array = Input.touches;
				UnityTouch[] array2 = new UnityTouch[array.Length];
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i] = ToRewired(array[i]);
				}
				return array2;
			}
		}

		public override bool simulateMouseWithTouches
		{
			get
			{
				return Input.simulateMouseWithTouches;
			}
			set
			{
				Input.simulateMouseWithTouches = value;
			}
		}

		public override bool multiTouchEnabled
		{
			get
			{
				return Input.multiTouchEnabled;
			}
			set
			{
				Input.multiTouchEnabled = value;
			}
		}

		public override event Action KeyboardLayoutChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void StaticInitialize()
		{
			if (GlobalObjectProvider.Register("createUnityInputManagerProxy", CreateInstanceForObjectProvider) && ReInput.isReady)
			{
				Debug.LogError("Rewired: " + typeof(UnityInputManagerProxy).Name + ".StaticInitialize was called after Rewired was already initialized. StaticInitialize must be called before Rewired is initialized. This can occur if you are instantiating Rewired in the RuntimeInitializeOnLoadMethod callback. Rewired should be initialized using the Rewired Initializer. See the Input Manager section of the documentation for more information.");
			}
		}

		private static bool CreateInstanceForObjectProvider(object arg1, object arg2, out object result)
		{
			result = null;
			if (!(arg1 is int))
			{
				return false;
			}
			if ((int)arg1 != 4)
			{
				return false;
			}
			result = new UnityInputManagerProxy();
			return true;
		}

		public UnityInputManagerProxy()
		{
			_joystickNamesLastFrameChecked = -1;
			_joystickNames = new string[0];
		}

		public override bool GetKey(int keyCode)
		{
			return Input.GetKey((KeyCode)keyCode);
		}

		public override bool GetKeyDown(int keyCode)
		{
			return Input.GetKeyDown((KeyCode)keyCode);
		}

		public override bool GetKeyUp(int keyCode)
		{
			return Input.GetKeyUp((KeyCode)keyCode);
		}

		public override bool GetButton(string name)
		{
			return Input.GetButton(name);
		}

		public override bool GetButtonDown(string name)
		{
			return Input.GetButtonDown(name);
		}

		public override bool GetButtonUp(string name)
		{
			return Input.GetButtonUp(name);
		}

		public override bool GetMouseButton(int index)
		{
			return Input.GetMouseButton(index);
		}

		public override bool GetMouseButtonDown(int index)
		{
			return Input.GetMouseButtonDown(index);
		}

		public override bool GetMouseButtonUp(int index)
		{
			return Input.GetMouseButtonUp(index);
		}

		public override float GetAxis(string name)
		{
			return Input.GetAxis(name);
		}

		public override float GetAxisRaw(string name)
		{
			return Input.GetAxisRaw(name);
		}

		public override UnityTouch GetTouch(int index)
		{
			return ToRewired(Input.GetTouch(index));
		}

		public override int GetJoystickNames(IList<string> results)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			UpdateJoystickNames();
			int count = results.Count;
			for (int i = 0; i < _joystickNames.Length; i++)
			{
				results.Add(_joystickNames[i]);
			}
			return results.Count - count;
		}

		public override bool GetKeyLabels(string[] keyLabels, string[] modifierLabelsShort, string[] modifierLabelsLong)
		{
			return false;
		}

		public override void Update()
		{
		}

		public override void Deinitialize()
		{
		}

		private void UpdateJoystickNames()
		{
			int frameCount = Time.frameCount;
			if (frameCount != _joystickNamesLastFrameChecked)
			{
				_joystickNamesLastFrameChecked = frameCount;
				_joystickNames = Input.GetJoystickNames();
			}
		}

		private static UnityTouch ToRewired(Touch touch)
		{
			return new UnityTouch
			{
				deltaPosition = touch.deltaPosition,
				deltaTime = touch.deltaTime,
				fingerId = touch.fingerId,
				phase = ToRewired(touch.phase),
				position = touch.position,
				rawPosition = touch.rawPosition,
				tapCount = touch.tapCount,
				type = ToRewired(touch.type),
				altitudeAngle = touch.altitudeAngle,
				azimuthAngle = touch.azimuthAngle,
				maximumPossiblePressure = touch.maximumPossiblePressure,
				pressure = touch.pressure,
				radius = touch.radius,
				radiusVariance = touch.radiusVariance
			};
		}

		private static UnityTouch.TouchPhase ToRewired(TouchPhase touchPhase)
		{
			return touchPhase switch
			{
				TouchPhase.Began => UnityTouch.TouchPhase.Began, 
				TouchPhase.Moved => UnityTouch.TouchPhase.Moved, 
				TouchPhase.Stationary => UnityTouch.TouchPhase.Stationary, 
				TouchPhase.Ended => UnityTouch.TouchPhase.Ended, 
				TouchPhase.Canceled => UnityTouch.TouchPhase.Canceled, 
				_ => UnityTouch.TouchPhase.Canceled, 
			};
		}

		private static UnityTouch.TouchType ToRewired(TouchType touchType)
		{
			return touchType switch
			{
				TouchType.Direct => UnityTouch.TouchType.Direct, 
				TouchType.Indirect => UnityTouch.TouchType.Indirect, 
				TouchType.Stylus => UnityTouch.TouchType.Stylus, 
				_ => UnityTouch.TouchType.Direct, 
			};
		}
	}
}
