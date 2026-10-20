using System;
using System.Collections.Generic;

namespace Rewired.Utils.Interfaces
{
	public interface IExternalTools
	{
		bool isEditorPaused { get; }

		bool isUnityInputManagerEnabled { get; }

		bool isUnityInputSystemEnabled { get; }

		bool tvOS_allowExitToHome { get; set; }

		bool tvOS_allowRemoteRotation { get; set; }

		bool tvOS_remoteReportAbsoluteDpadValues { get; set; }

		bool tvOS_remoteTouchesEnabled { get; set; }

		event Action<bool> EditorPausedStateChangedEvent;

		void Destroy();

		object GetPlatformInitializer();

		string GetFocusedEditorWindowTitle();

		bool IsEditorSceneViewFocused();

		bool LinuxInput_IsJoystickPreconfigured(string name);

		void GetDeviceVIDPIDs(out List<int> vids, out List<int> pids);

		int GetAndroidAPILevel();

		void WindowsStandalone_ForwardRawInput(IntPtr rawInputHeaderIndices, IntPtr rawInputDataIndices, uint indicesCount, IntPtr rawInputData, uint rawInputDataSize);

		bool UnityUI_Graphic_GetRaycastTarget(object graphic);

		void UnityUI_Graphic_SetRaycastTarget(object graphic, bool value);

		IControllerTemplate CreateControllerTemplate(Guid typeGuid, object payload);

		Type[] GetControllerTemplateTypes();

		Type[] GetControllerTemplateInterfaceTypes();
	}
}
