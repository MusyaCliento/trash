using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Data;
using Rewired.Internal;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Platforms.UnityInputManager
{
	public abstract class UnityInputManagerProxyBase
	{
		public const string inputSourceTypeString_unityInputManager = "UnityInputManager";

		public const string inputSourceTypeString_unityInputSystem = "UnityInputSystem";

		private InputSource qHtYMxGhCTgJUDzsHJydsCrwQywAA = (InputSource)(-1);

		private static UnityInputManagerProxyBase lMXGvBkvNTIeTeHCLQSRhibfdSLZA;

		public abstract string inputSourceTypeString { get; }

		public abstract Vector2 mousePosition { get; }

		public abstract Vector2 mouseScrollDelta { get; }

		public abstract bool anyKey { get; }

		public abstract bool mousePresent { get; }

		public abstract Vector3 acceleration { get; }

		public abstract bool touchSupported { get; }

		public abstract int touchCount { get; }

		public abstract UnityTouch[] touches { get; }

		public abstract bool simulateMouseWithTouches { get; set; }

		public abstract bool multiTouchEnabled { get; set; }

		internal InputSource ZsYGZMHAVaQJsbywdNyvkJZOfPIy
		{
			get
			{
				if (qHtYMxGhCTgJUDzsHJydsCrwQywAA >= InputSource.None)
				{
					return qHtYMxGhCTgJUDzsHJydsCrwQywAA;
				}
				string text = inputSourceTypeString;
				if (!(text == "UnityInputManager"))
				{
					if (text == "UnityInputSystem")
					{
						qHtYMxGhCTgJUDzsHJydsCrwQywAA = InputSource.UnityInputSystem;
					}
					else
					{
						qHtYMxGhCTgJUDzsHJydsCrwQywAA = InputSource.None;
					}
				}
				else
				{
					qHtYMxGhCTgJUDzsHJydsCrwQywAA = InputSource.Fallback;
				}
				return qHtYMxGhCTgJUDzsHJydsCrwQywAA;
			}
		}

		internal static UnityInputManagerProxyBase MJjpgEmAODOlqLaRmBDSjkVzThu => lMXGvBkvNTIeTeHCLQSRhibfdSLZA;

		public abstract event Action KeyboardLayoutChangedEvent;

		public abstract bool GetKey(int keyCode);

		public abstract bool GetKeyDown(int keyCode);

		public abstract bool GetKeyUp(int keyCode);

		public abstract bool GetButton(string name);

		public abstract bool GetButtonDown(string name);

		public abstract bool GetButtonUp(string name);

		public abstract bool GetMouseButton(int index);

		public abstract bool GetMouseButtonDown(int index);

		public abstract bool GetMouseButtonUp(int index);

		public abstract float GetAxis(string name);

		public abstract float GetAxisRaw(string name);

		public abstract int GetJoystickNames(IList<string> results);

		public abstract UnityTouch GetTouch(int index);

		public abstract bool GetKeyLabels(string[] keyLabels, string[] modifierLabelsShort, string[] modifierLabelsLong);

		public abstract void Update();

		public abstract void Deinitialize();

		internal static bool kUQdmfdQHVjIdcQtjSAKnRRCaKWSc(ConfigVars P_0, InputSource P_1)
		{
			UnityPrimaryInputSource unityInputSourceDependency = UnityTools.GetUnityInputSourceDependency(P_1);
			bool isUnityInputManagerEnabled = UnityTools.externalTools.isUnityInputManagerEnabled;
			bool flag = UnityTools.supportsUnityInputSystem && UnityTools.externalTools.isUnityInputSystemEnabled;
			bool flag2 = UnityTools.supportsUnityInputSystem && ((flag && !isUnityInputManagerEnabled) || unityInputSourceDependency == UnityPrimaryInputSource.InputSystem);
			bool flag3 = !UnityTools.supportsUnityInputSystem || !flag || unityInputSourceDependency == UnityPrimaryInputSource.InputManager;
			if (!flag2)
			{
				P_1 = InputSource.Fallback;
			}
			UnityInputSourceType fallbackUnityInputType = P_0.GetFallbackUnityInputType();
			if (!flag3 && flag && (flag2 || fallbackUnityInputType == UnityInputSourceType.InputSystem))
			{
				P_1 = InputSource.UnityInputSystem;
			}
			if (!GlobalObjectProvider.TryGetObject<UnityInputManagerProxyBase>("createUnityInputManagerProxy", (int)P_1, null, out lMXGvBkvNTIeTeHCLQSRhibfdSLZA))
			{
				P_1 = ((P_1 == InputSource.Fallback) ? InputSource.UnityInputSystem : InputSource.Fallback);
				GlobalObjectProvider.TryGetObject<UnityInputManagerProxyBase>("createUnityInputManagerProxy", (int)P_1, null, out lMXGvBkvNTIeTeHCLQSRhibfdSLZA);
			}
			if (lMXGvBkvNTIeTeHCLQSRhibfdSLZA == null)
			{
				if (!flag3 && (flag2 || (flag && fallbackUnityInputType == UnityInputSourceType.InputSystem)))
				{
					Logger.LogError("Error creating Unity Input Proxy. Input will not function. Is Unity Input System package " + Consts.unityInputSystemMinimumVersion?.ToString() + "+ installed?");
					return false;
				}
				Logger.LogError("Error creating Unity Input Proxy. Input will not function.");
				return false;
			}
			return true;
		}

		internal static void NFaoNRkMVoYmSjqqBEogUyZwTlLb()
		{
			if (lMXGvBkvNTIeTeHCLQSRhibfdSLZA != null)
			{
				lMXGvBkvNTIeTeHCLQSRhibfdSLZA.Deinitialize();
			}
			lMXGvBkvNTIeTeHCLQSRhibfdSLZA = null;
		}
	}
}
