using System;
using System.Collections.Generic;
using System.ComponentModel;
using Rewired.Internal;
using Rewired.Utils.Interfaces;
using Rewired.Utils.Platforms.Windows;
using UnityEngine.UI;
using UnityEngine.Windows;

namespace Rewired.Utils
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ExternalTools : IExternalTools
	{
		public static class Static
		{
			public static bool IsUnityInputManagerEnabled()
			{
				return true;
			}

			public static bool IsUnityInputSystemEnabled()
			{
				return true;
			}
		}

		private static Func<object> _getPlatformInitializerDelegate;

		private bool _isEditorPaused;

		private Action<bool> _EditorPausedStateChangedEvent;

		public static Func<object> getPlatformInitializerDelegate
		{
			get
			{
				return _getPlatformInitializerDelegate;
			}
			set
			{
				_getPlatformInitializerDelegate = value;
			}
		}

		public bool isEditorPaused => _isEditorPaused;

		public bool isUnityInputManagerEnabled => Static.IsUnityInputManagerEnabled();

		public bool isUnityInputSystemEnabled => Static.IsUnityInputSystemEnabled();

		public bool tvOS_allowExitToHome
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool tvOS_allowRemoteRotation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool tvOS_remoteReportAbsoluteDpadValues
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool tvOS_remoteTouchesEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event Action<bool> EditorPausedStateChangedEvent
		{
			add
			{
				_EditorPausedStateChangedEvent = (Action<bool>)Delegate.Combine(_EditorPausedStateChangedEvent, value);
			}
			remove
			{
				_EditorPausedStateChangedEvent = (Action<bool>)Delegate.Remove(_EditorPausedStateChangedEvent, value);
			}
		}

		public void Destroy()
		{
		}

		public object GetPlatformInitializer()
		{
			return Main.GetPlatformInitializer();
		}

		public string GetFocusedEditorWindowTitle()
		{
			return string.Empty;
		}

		public bool IsEditorSceneViewFocused()
		{
			return false;
		}

		public bool LinuxInput_IsJoystickPreconfigured(string name)
		{
			return false;
		}

		public void GetDeviceVIDPIDs(out List<int> vids, out List<int> pids)
		{
			vids = new List<int>();
			pids = new List<int>();
		}

		public int GetAndroidAPILevel()
		{
			return -1;
		}

		public void WindowsStandalone_ForwardRawInput(IntPtr rawInputHeaderIndices, IntPtr rawInputDataIndices, uint indicesCount, IntPtr rawInputData, uint rawInputDataSize)
		{
			Input.ForwardRawInput(rawInputHeaderIndices, rawInputDataIndices, indicesCount, rawInputData, rawInputDataSize);
		}

		public bool UnityUI_Graphic_GetRaycastTarget(object graphic)
		{
			if (graphic as Graphic == null)
			{
				return false;
			}
			return (graphic as Graphic).raycastTarget;
		}

		public void UnityUI_Graphic_SetRaycastTarget(object graphic, bool value)
		{
			if (!(graphic as Graphic == null))
			{
				(graphic as Graphic).raycastTarget = value;
			}
		}

		public IControllerTemplate CreateControllerTemplate(Guid typeGuid, object payload)
		{
			return ControllerTemplateFactory.Create(typeGuid, payload);
		}

		public Type[] GetControllerTemplateTypes()
		{
			return ControllerTemplateFactory.templateTypes;
		}

		public Type[] GetControllerTemplateInterfaceTypes()
		{
			return ControllerTemplateFactory.templateInterfaceTypes;
		}
	}
}
