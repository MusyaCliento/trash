using System;
using System.Collections.Generic;
using Rewired.Data;
using Rewired.Platforms.UnityInputManager;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal static class UnityInputHelper
	{
		private class ryMIlCGVxnOuYhCKwIBUkMmasWrSA
		{
			public string[] eaqxNClGkPZPGxXOZZgVkpWppsP;

			public string[] DfyTtFBGChhLsvGyjMdExGvvXjXQ;

			public ryMIlCGVxnOuYhCKwIBUkMmasWrSA(int P_0)
			{
				eaqxNClGkPZPGxXOZZgVkpWppsP = new string[29];
				for (int i = 0; i < eaqxNClGkPZPGxXOZZgVkpWppsP.Length; i++)
				{
					eaqxNClGkPZPGxXOZZgVkpWppsP[i] = UnityTools.GetUnityInputAxisName(P_0, i);
				}
				if (P_0 + 1 > 16)
				{
					DfyTtFBGChhLsvGyjMdExGvvXjXQ = new string[20];
					for (int j = 0; j < DfyTtFBGChhLsvGyjMdExGvvXjXQ.Length; j++)
					{
						DfyTtFBGChhLsvGyjMdExGvvXjXQ[j] = UnityTools.GetUnityInputButtonName(P_0, j);
					}
				}
			}
		}

		private static bool HhETIglhXLjiJnMuJraQeXpKnNCM;

		private static ryMIlCGVxnOuYhCKwIBUkMmasWrSA[] vLFixiESPCIUJKmfHgQdHtvNBgwrA;

		private static Action ViFgYnKoJdgCrAEvrhTIbTvdMFAMB;

		public static InputSource inputSourceType
		{
			get
			{
				if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
				{
					return InputSource.None;
				}
				return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.ZsYGZMHAVaQJsbywdNyvkJZOfPIy;
			}
		}

		public static string inputSourceTypeString
		{
			get
			{
				if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
				{
					return null;
				}
				return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.inputSourceTypeString;
			}
		}

		public static Vector2 mousePosition
		{
			get
			{
				if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
				{
					return default(Vector2);
				}
				return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.mousePosition;
			}
		}

		public static Vector2 mouseScrollDelta
		{
			get
			{
				if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
				{
					return default(Vector2);
				}
				return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.mouseScrollDelta;
			}
		}

		public static bool mousePresent
		{
			get
			{
				if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
				{
					return false;
				}
				return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.mousePresent;
			}
		}

		public static bool anyKey
		{
			get
			{
				if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
				{
					return false;
				}
				return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.anyKey;
			}
		}

		public static Vector3 acceleration
		{
			get
			{
				if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
				{
					return default(Vector2);
				}
				return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.acceleration;
			}
		}

		public static bool touchSupported
		{
			get
			{
				if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
				{
					return false;
				}
				return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.touchSupported;
			}
		}

		public static int touchCount
		{
			get
			{
				if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
				{
					return 0;
				}
				return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.touchCount;
			}
		}

		public static UnityTouch[] touches => UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.touches;

		public static bool simulateMouseWithTouches
		{
			get
			{
				if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
				{
					return false;
				}
				return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.simulateMouseWithTouches;
			}
			set
			{
				if (HhETIglhXLjiJnMuJraQeXpKnNCM)
				{
					UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.simulateMouseWithTouches = value;
				}
			}
		}

		public static bool multiTouchEnabled
		{
			get
			{
				if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
				{
					return false;
				}
				return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.multiTouchEnabled;
			}
			set
			{
				if (HhETIglhXLjiJnMuJraQeXpKnNCM)
				{
					UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.multiTouchEnabled = value;
				}
			}
		}

		public static event Action KeyboardLayoutChangedEvent
		{
			add
			{
				ViFgYnKoJdgCrAEvrhTIbTvdMFAMB = (Action)Delegate.Combine(ViFgYnKoJdgCrAEvrhTIbTvdMFAMB, value);
			}
			remove
			{
				ViFgYnKoJdgCrAEvrhTIbTvdMFAMB = (Action)Delegate.Remove(ViFgYnKoJdgCrAEvrhTIbTvdMFAMB, value);
			}
		}

		static UnityInputHelper()
		{
			vLFixiESPCIUJKmfHgQdHtvNBgwrA = new ryMIlCGVxnOuYhCKwIBUkMmasWrSA[16];
			for (int i = 0; i < vLFixiESPCIUJKmfHgQdHtvNBgwrA.Length; i++)
			{
				vLFixiESPCIUJKmfHgQdHtvNBgwrA[i] = new ryMIlCGVxnOuYhCKwIBUkMmasWrSA(i);
			}
		}

		public static float GetJoystickAxisValueByJoystickId(int joystickId, int axisIndex)
		{
			if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
			{
				return 0f;
			}
			if (joystickId <= 0 || joystickId > 16)
			{
				return 0f;
			}
			if (axisIndex >= 29)
			{
				return 0f;
			}
			return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.GetAxis(vLFixiESPCIUJKmfHgQdHtvNBgwrA[joystickId - 1].eaqxNClGkPZPGxXOZZgVkpWppsP[axisIndex]);
		}

		public static float GetJoystickAxisRawValueByJoystickId(int joystickId, int axisIndex)
		{
			if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
			{
				return 0f;
			}
			if (joystickId <= 0 || joystickId > 16)
			{
				return 0f;
			}
			if (axisIndex >= 29)
			{
				return 0f;
			}
			return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.GetAxisRaw(vLFixiESPCIUJKmfHgQdHtvNBgwrA[joystickId - 1].eaqxNClGkPZPGxXOZZgVkpWppsP[axisIndex]);
		}

		public static float GetJoystickAxisValueByJoystickIndex(int joystickIndex, int axisIndex)
		{
			return GetJoystickAxisValueByJoystickId(joystickIndex + 1, axisIndex);
		}

		public static float GetJoystickAxisRawValueByJoystickIndex(int joystickIndex, int axisIndex)
		{
			return GetJoystickAxisRawValueByJoystickId(joystickIndex + 1, axisIndex);
		}

		public static bool GetJoystickButtonValueByJoystickId(int joystickId, int buttonIndex)
		{
			if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
			{
				return false;
			}
			if (joystickId <= 0 || joystickId > 16)
			{
				return false;
			}
			if (buttonIndex >= 20)
			{
				return false;
			}
			int num = joystickId - 1;
			if (joystickId <= 16)
			{
				int keyCode = 350 + 20 * num + buttonIndex;
				return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.GetKey(keyCode);
			}
			return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.GetButton(vLFixiESPCIUJKmfHgQdHtvNBgwrA[num].DfyTtFBGChhLsvGyjMdExGvvXjXQ[buttonIndex]);
		}

		public static bool GetJoystickButtonValueByJoystickIndex(int joystickIndex, int buttonIndex)
		{
			if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
			{
				return false;
			}
			return GetJoystickButtonValueByJoystickId(joystickIndex + 1, buttonIndex);
		}

		public static void GetJoystickNames(IList<string> results)
		{
			if (HhETIglhXLjiJnMuJraQeXpKnNCM)
			{
				UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.GetJoystickNames(results);
			}
		}

		public static bool GetKey(KeyboardKeyCode keyCode)
		{
			if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
			{
				return false;
			}
			return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.GetKey((int)keyCode);
		}

		public static bool GetKeyDown(KeyboardKeyCode keyCode)
		{
			if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
			{
				return false;
			}
			return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.GetKeyDown((int)keyCode);
		}

		public static bool GetKeyUp(KeyboardKeyCode keyCode)
		{
			if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
			{
				return false;
			}
			return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.GetKeyUp((int)keyCode);
		}

		public static bool GetButton(string name)
		{
			if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
			{
				return false;
			}
			return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.GetButton(name);
		}

		public static bool GetButtonDown(string name)
		{
			if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
			{
				return false;
			}
			return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.GetButtonDown(name);
		}

		public static bool GetButtonUp(string name)
		{
			if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
			{
				return false;
			}
			return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.GetButtonUp(name);
		}

		public static bool GetMouseButton(int index)
		{
			if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
			{
				return false;
			}
			return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.GetMouseButton(index);
		}

		public static bool GetMouseButtonDown(int index)
		{
			if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
			{
				return false;
			}
			return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.GetMouseButtonDown(index);
		}

		public static bool GetMouseButtonUp(int index)
		{
			if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
			{
				return false;
			}
			return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.GetMouseButtonUp(index);
		}

		public static float GetAxis(string name)
		{
			if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
			{
				return 0f;
			}
			return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.GetAxis(name);
		}

		public static float GetAxisRaw(string name)
		{
			if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
			{
				return 0f;
			}
			return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.GetAxisRaw(name);
		}

		public static UnityTouch GetTouch(int index)
		{
			if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
			{
				return default(UnityTouch);
			}
			return UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.GetTouch(index);
		}

		internal static bool GetKeyLabels(string[] keyLabels, string[] modifierLabelsShort, string[] modifierLabelsLong)
		{
			if (!HhETIglhXLjiJnMuJraQeXpKnNCM)
			{
				return false;
			}
			if (keyLabels == null || keyLabels.Length != 132)
			{
				return false;
			}
			if (modifierLabelsShort == null || modifierLabelsShort.Length != Consts.keyboardModifierKeys.Count)
			{
				return false;
			}
			if (modifierLabelsLong == null || modifierLabelsLong.Length != Consts.keyboardModifierKeys.Count)
			{
				return false;
			}
			UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.GetKeyLabels(keyLabels, modifierLabelsShort, modifierLabelsLong);
			IList<string> keyboardKeyNames = Consts.keyboardKeyNames;
			for (int i = 0; i < 132; i++)
			{
				if (string.IsNullOrEmpty(keyLabels[i]))
				{
					keyLabels[i] = keyboardKeyNames[i];
				}
			}
			Rewired.Utils.Interfaces.IReadOnlyDictionary<int, Keyboard.ModifierKeyInfo> modifierKeyInfo = Consts.modifierKeyInfo;
			for (int j = 1; j < modifierKeyInfo.Count; j++)
			{
				if (string.IsNullOrEmpty(modifierLabelsShort[j]))
				{
					modifierLabelsShort[j] = modifierKeyInfo[j].shortName;
				}
				if (string.IsNullOrEmpty(modifierLabelsLong[j]))
				{
					modifierLabelsLong[j] = modifierKeyInfo[j].longName;
				}
			}
			return true;
		}

		internal static void Update()
		{
			if (HhETIglhXLjiJnMuJraQeXpKnNCM)
			{
				UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.Update();
			}
		}

		internal static void Initialize(ConfigVars configVars, InputSource inputSource)
		{
			HhETIglhXLjiJnMuJraQeXpKnNCM = UnityInputManagerProxyBase.kUQdmfdQHVjIdcQtjSAKnRRCaKWSc(configVars, inputSource);
			if (HhETIglhXLjiJnMuJraQeXpKnNCM && UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu != null)
			{
				UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.KeyboardLayoutChangedEvent += CrmrMuNkHbgAbwCWBgzPuIunfBCf;
			}
		}

		internal static void Deinitialize()
		{
			if (HhETIglhXLjiJnMuJraQeXpKnNCM && UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu != null)
			{
				UnityInputManagerProxyBase.MJjpgEmAODOlqLaRmBDSjkVzThu.KeyboardLayoutChangedEvent -= CrmrMuNkHbgAbwCWBgzPuIunfBCf;
			}
			UnityInputManagerProxyBase.NFaoNRkMVoYmSjqqBEogUyZwTlLb();
			HhETIglhXLjiJnMuJraQeXpKnNCM = false;
		}

		private static void CrmrMuNkHbgAbwCWBgzPuIunfBCf()
		{
			ViFgYnKoJdgCrAEvrhTIbTvdMFAMB?.Invoke();
		}
	}
}
