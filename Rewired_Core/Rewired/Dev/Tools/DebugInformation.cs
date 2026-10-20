using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	public class DebugInformation : MonoBehaviour
	{
		private class ZLdgzeuFGnBHDWzImfaPUbCZCsao : IDisposable
		{
			public readonly bool CIkfXThOynxfPEPAAVDnavDieDMRA;

			public ZLdgzeuFGnBHDWzImfaPUbCZCsao(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				CIkfXThOynxfPEPAAVDnavDieDMRA = NIgAyNnYOaasXMVyEfVhJXVLCFG(P_0, P_1, P_2);
				BoewWkXcptfEpfuXzagxlweGyNwQA.HvWRWiFmaIGmTTHrSBNcylgzjLlCA++;
			}

			private bool NIgAyNnYOaasXMVyEfVhJXVLCFG(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				return ioauKunbCvoWcjFgzYsiuLgjVtBo(P_1, GUILayout.Toggle(vggzKMzOwprCPzFhsZGMcwbwBgjR(P_1, P_2), new GUIContent(P_0, P_0), GetToggleStyle()), P_2);
			}

			private bool vggzKMzOwprCPzFhsZGMcwbwBgjR(string P_0, IDictionary<string, bool> P_1)
			{
				if (!P_1.ContainsKey(P_0))
				{
					P_1.Add(P_0, value: false);
				}
				return P_1[P_0];
			}

			private bool ioauKunbCvoWcjFgzYsiuLgjVtBo(string P_0, bool P_1, IDictionary<string, bool> P_2)
			{
				if (!P_2.ContainsKey(P_0))
				{
					P_2.Add(P_0, P_1);
				}
				else
				{
					P_2[P_0] = P_1;
				}
				return P_1;
			}

			public void Dispose()
			{
				BoewWkXcptfEpfuXzagxlweGyNwQA.HvWRWiFmaIGmTTHrSBNcylgzjLlCA--;
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}
		}

		private static class BoewWkXcptfEpfuXzagxlweGyNwQA
		{
			private static int oTVrqdnBmbYxlimtIFnoYbWgXfqX;

			public static int HvWRWiFmaIGmTTHrSBNcylgzjLlCA
			{
				get
				{
					return oTVrqdnBmbYxlimtIFnoYbWgXfqX;
				}
				set
				{
					oTVrqdnBmbYxlimtIFnoYbWgXfqX = Mathf.Max(0, b);
				}
			}
		}

		private static class QgsfUjzyZHbNzfZrivDsWRHsbWAw
		{
			public static void SXEqiVLQgEWonhAXrGbZcGChcSaEA()
			{
				GUILayout.BeginHorizontal();
			}

			public static void ziDGFiQuUrfIaVivSqxpnyTRiYGc()
			{
				GUILayout.EndHorizontal();
			}

			public static void dSfprfBCaNHifbnaMLchBAHJlxbH()
			{
				GUILayout.BeginVertical();
			}

			public static void jKqZsqjyplEeNzkgfzNVJqLDmlVm()
			{
				GUILayout.EndVertical();
			}

			public static void BUabLaaGxAnEmDshKNoIfhxvHSfaA(string P_0, AnEZhEwnJklhfumniaXrUEHxaKwT P_1)
			{
				GUILayout.Label(P_0, ANxiniGHZurWVIbYQfVmAEeOFoBg());
			}

			public static void jdxbLdjHnSJZcAmUDDPWcwIXnVwIc(string P_0, string P_1)
			{
				GUILayout.Label(P_0 + ": " + P_1, ANxiniGHZurWVIbYQfVmAEeOFoBg());
			}

			public static void BYUIvWzocVkHFoOQNLnNOXXJeNTe(string P_0, AnimationCurve P_1)
			{
				GUILayout.Label(P_0 + ": Curves are not visualized by this tool.");
			}

			public static bool RSwkZmFQdBaWKlvchWGwfBTblBUM(string P_0, bool P_1)
			{
				return GUILayout.Toggle(P_1, P_0, ANxiniGHZurWVIbYQfVmAEeOFoBg());
			}
		}

		private static class yIEeJmfeosptrKLwMGLFrxwQgkTu
		{
			[CompilerGenerated]
			private static float fpDYLSmhtRuQkJyUUDxqFoamnkeG;

			[CompilerGenerated]
			private static float fygPNLrGVulCSxjifNWbtjzqQhkM;

			public static float xmsrJMnFveFmoVfLprrnUXphMYTt
			{
				[CompilerGenerated]
				get
				{
					return fpDYLSmhtRuQkJyUUDxqFoamnkeG;
				}
				[CompilerGenerated]
				set
				{
					fpDYLSmhtRuQkJyUUDxqFoamnkeG = num;
				}
			}

			public static float YKUwdfMlldLGrwqVnxfUjXLXAUd
			{
				[CompilerGenerated]
				get
				{
					return fygPNLrGVulCSxjifNWbtjzqQhkM;
				}
				[CompilerGenerated]
				set
				{
					fygPNLrGVulCSxjifNWbtjzqQhkM = num;
				}
			}
		}

		internal enum AnEZhEwnJklhfumniaXrUEHxaKwT
		{
			None = 0,
			Info = 1,
			Warning = 2,
			Error = 3
		}

		[Serializable]
		private sealed class EpjYGYbebpCoYbcSJcSakRGhcqQf
		{
			public static readonly EpjYGYbebpCoYbcSJcSakRGhcqQf _003C_003E9 = new EpjYGYbebpCoYbcSJcSakRGhcqQf();

			public static Comparison<InputAction> _003C_003E9__17_0;

			internal int KtwDRZFDnHqiTYAjcOYGxXObhCyPA(InputAction P_0, InputAction P_1)
			{
				return P_0.name.CompareTo(P_1.name);
			}
		}

		private sealed class BBSzbClbspBIgcyKEJKqGnePngvvA
		{
			public InputCategory axrQAdmDmAcVvbtRATRrAwHInibrA;

			internal bool PCEwqwBOjiHBMDzEPrAEtEAARQxxA(InputAction P_0)
			{
				return P_0.categoryId == axrQAdmDmAcVvbtRATRrAwHInibrA.id;
			}
		}

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _fontSize = 13;

		private static DebugInformation JgAPcYCFjKTCDCTBRkvgNeJaaBbL;

		private IDictionary<string, bool> tGECYsbLeSYEEqHPKpNGsWoubCATA = new Dictionary<string, bool>();

		private static Vector2 UGGDBhbgBrJxXsCifIKWHZMHOYSD;

		private const string QLWMOEZEAAGKoETwkEMDHFwbcsyLb = "Rewired_DebugInformation";

		private const string vKZkptRuZvnCvctADjIJcOwkeJbL = "Rewired Debug Information";

		private const int EOeUayPOcFPneumJiUwrBLrGOZhv = 20;

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			JgAPcYCFjKTCDCTBRkvgNeJaaBbL = this;
			if (tGECYsbLeSYEEqHPKpNGsWoubCATA.Count == 0)
			{
				tGECYsbLeSYEEqHPKpNGsWoubCATA.Add("Rewired_DebugInformation", value: true);
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			if (JgAPcYCFjKTCDCTBRkvgNeJaaBbL == this)
			{
				JgAPcYCFjKTCDCTBRkvgNeJaaBbL = null;
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			BoewWkXcptfEpfuXzagxlweGyNwQA.HvWRWiFmaIGmTTHrSBNcylgzjLlCA = 0;
			GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height));
			UGGDBhbgBrJxXsCifIKWHZMHOYSD = GUILayout.BeginScrollView(UGGDBhbgBrJxXsCifIKWHZMHOYSD, GUILayout.ExpandWidth(expand: true), GUILayout.ExpandHeight(expand: true));
			DrawDebugInformation(enabled: true, tGECYsbLeSYEEqHPKpNGsWoubCATA);
			GUILayout.EndScrollView();
			GUILayout.EndArea();
		}

		public static void DrawDebugInformation(bool enabled, IDictionary<string, bool> foldouts)
		{
			bool num = GUI.enabled;
			if (!ReInput.isReady || !enabled)
			{
				GUI.enabled = false;
			}
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.SXEqiVLQgEWonhAXrGbZcGChcSaEA();
			GUILayout.FlexibleSpace();
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.ziDGFiQuUrfIaVivSqxpnyTRiYGc();
			Rect lastRect = GUILayoutUtility.GetLastRect();
			float num2 = lastRect.width / 3f;
			yIEeJmfeosptrKLwMGLFrxwQgkTu.xmsrJMnFveFmoVfLprrnUXphMYTt = lastRect.width - num2;
			yIEeJmfeosptrKLwMGLFrxwQgkTu.YKUwdfMlldLGrwqVnxfUjXLXAUd = num2;
			PHbayMfOwNFgnJWNhioBorXuHSAHA(enabled, foldouts);
			GUI.enabled = num;
			yIEeJmfeosptrKLwMGLFrxwQgkTu.xmsrJMnFveFmoVfLprrnUXphMYTt = 0f;
			yIEeJmfeosptrKLwMGLFrxwQgkTu.YKUwdfMlldLGrwqVnxfUjXLXAUd = 0f;
		}

		private static void PHbayMfOwNFgnJWNhioBorXuHSAHA(bool P_0, IDictionary<string, bool> P_1)
		{
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Rewired Debug Information", "Rewired_DebugInformation", P_1);
			if (!ReInput.isReady || !P_0)
			{
				GUILayout.Label("There is no active Rewired Input Manager in the scene.");
			}
			else
			{
				if (!zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
				{
					return;
				}
				hqDGvolbwMPyuiuiTMbuPCVFAPFT(P_1, "Rewired_DebugInformation");
				bool flag = ReInput.configuration.disableNativeInput;
				if (!flag && (ReInput.currentPlatform == Platform.Windows || ReInput.currentPlatform == Platform.OSX || ReInput.currentPlatform == Platform.Linux) && (ReInput.primaryInputManager.inputSourceType == InputSource.Fallback || ReInput.primaryInputManager.inputSourceType == InputSource.Fallback_PreConfigured || ReInput.primaryInputManager.inputSourceType == InputSource.UnityInputSystem))
				{
					flag = true;
				}
				if (flag)
				{
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.BUabLaaGxAnEmDshKNoIfhxvHSfaA("Native input is disabled. Many special features are unavailable without native input.", AnEZhEwnJklhfumniaXrUEHxaKwT.Warning);
				}
				QGlTCnospQrpnBWGNUccoonUGsaJA(P_1, "Rewired_DebugInformation");
				string text = "Rewired_DebugInformation_controllers";
				using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao2 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Controllers", text, P_1);
				if (zLdgzeuFGnBHDWzImfaPUbCZCsao2.CIkfXThOynxfPEPAAVDnavDieDMRA)
				{
					vDlQgtmXLFevmuwpSNMKwGtUZGVb(ReInput.controllers.Joysticks, P_1, text);
					zmttNgyBwldVjMLbvNPWfDSbEJPN(ReInput.controllers.CustomControllers, P_1, text);
					hznrfsgOqkWMnbABfNXXcyehURVD(P_1, "Rewired_DebugInformation");
					KqLVcmEdsOfxpMtdKfjtDPVBlGZn(P_1, "Rewired_DebugInformation");
				}
				return;
			}
		}

		private static void hqDGvolbwMPyuiuiTMbuPCVFAPFT(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_info";
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Info", text, P_0);
			if (zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Rewired Version", ReInput.programVersion);
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Platform", ReInput.currentPlatform.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Primary Input Source", ReInput.primaryInputManager.inputSourceType.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Keyboard Input Source", ReInput.controllers.Keyboard.inputSource.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Mouse Input Source", ReInput.controllers.Keyboard.inputSource.ToString());
				if (ReInput.currentPlatform == Platform.Windows)
				{
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Use Windows Gaming Input", ReInput.configuration.useWindowsGamingInput.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Use XInput", ReInput.configuration.useXInput.ToString());
				}
				else if (ReInput.currentPlatform == Platform.WindowsUWP)
				{
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Support HID Devices", ReInput.configuration.windowsUWPSupportHIDDevices.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Support Gamepads", ReInput.configuration.windowsUWPSupportGamepads.ToString());
				}
				else if (ReInput.currentPlatform == Platform.OSX)
				{
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Use Game Controller Framework", ReInput.configuration.useAppleGameControllerFramework.ToString());
				}
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Enhanced Device Support", ReInput.configuration.enhancedDeviceSupport.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Native Keyboard Handling", ReInput.configuration.nativeKeyboardSupport.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Physical Key Mapping", ReInput.configVars.unityUsePhysicalKeys.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Show System Key Labels", ReInput.configVars.showSystemKeyLabels.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Native Mouse Handling", ReInput.configuration.nativeMouseSupport.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Support XR Controllers", ReInput.configuration.supportXRControllers.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Ignore Input When App Not in Focus", ReInput.configuration.ignoreInputWhenAppNotInFocus.ToString());
			}
		}

		private static void QGlTCnospQrpnBWGNUccoonUGsaJA(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_players";
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Players (" + ReInput.players.allPlayerCount + ")", text, P_0);
			if (zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				int playerCount = ReInput.players.playerCount;
				for (int i = 0; i < playerCount; i++)
				{
					wYTOZlAMSXjzRtFadBNZtxCpbHkH(ReInput.players.GetPlayer(i), i, P_0, text);
				}
				wYTOZlAMSXjzRtFadBNZtxCpbHkH(ReInput.players.SystemPlayer, -1, P_0, text);
			}
		}

		private static void vDlQgtmXLFevmuwpSNMKwGtUZGVb(IList<Joystick> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Joysticks (" + num + ")", P_2 + "_joysticks", P_1);
			if (!zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Joystick joystick = P_0[i];
				int id = joystick.id;
				string text = P_2 + "_joystick" + id;
				using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao2 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(i + ": " + ((joystick.name == "Unknown Controller") ? joystick.hardwareName : joystick.name), text, P_1);
				if (!zLdgzeuFGnBHDWzImfaPUbCZCsao2.CIkfXThOynxfPEPAAVDnavDieDMRA)
				{
					continue;
				}
				id = joystick.id;
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Id (unique id)", id.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Name", joystick.name);
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Hardware Name", joystick.hardwareName);
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Is Recognized", (joystick.hardwareTypeGuid != Guid.Empty).ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Enabled", joystick.enabled.ToString());
				string text2 = string.Empty;
				for (int j = 0; j < ReInput.players.allPlayerCount; j++)
				{
					Player player = ReInput.players.AllPlayers[j];
					if (ReInput.controllers.IsJoystickAssignedToPlayer(joystick.id, player.id))
					{
						if (text2 != string.Empty)
						{
							text2 += ", ";
						}
						text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
					}
				}
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("System Id", joystick.systemId.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Unity Id", ReInput.usingUnityInput ? joystick.unityId.ToString() : "--");
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Hardware Type Guid", joystick.hardwareTypeGuid.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Hardware Identifier", joystick.hardwareIdentifier);
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Device Instance Guid", joystick.deviceInstanceGuid.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Tag", joystick.tag);
				pXDqCcvkxbJDjfeQJbNiamlutBYr(joystick.Axes, P_1, text);
				sEsdqhSJlPEzJIVRJTqgTWWWpSyp(joystick.Buttons, ControllerType.Joystick, P_1, text);
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Axis2D Count", joystick.axis2DCount.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Hat Count", joystick.hatCount.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("D-Pad Count", joystick.directionalPadCount.ToString());
				xxOvPWZFHvIQiUbNZtVXOnhVDvxEA(joystick, P_1, text);
				CalibrationMap calibrationMap = joystick.calibrationMap;
				using (ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao3 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Calibration Map", text + "_calibrationMap", P_1))
				{
					if (zLdgzeuFGnBHDWzImfaPUbCZCsao3.CIkfXThOynxfPEPAAVDnavDieDMRA)
					{
						int axisCount = calibrationMap.axisCount;
						for (int k = 0; k < axisCount; k++)
						{
							AxisCalibration axisCalibration = calibrationMap.Axes[k];
							using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao4 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(k + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + k, P_1);
							if (zLdgzeuFGnBHDWzImfaPUbCZCsao4.CIkfXThOynxfPEPAAVDnavDieDMRA)
							{
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Enabled", axisCalibration.enabled.ToString());
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Calibrated Max", axisCalibration.calibratedMax.ToString());
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Calibrated Min", axisCalibration.calibratedMin.ToString());
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Calibrated Zero", axisCalibration.calibratedZero.ToString());
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Dead Zone", axisCalibration.deadZone.ToString());
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Upper Dead Zone", axisCalibration.upperDeadZone.ToString());
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Invert", axisCalibration.invert.ToString());
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Sensitivity Type", axisCalibration.sensitivityType.ToString());
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Sensitivity", axisCalibration.sensitivity.ToString());
								if (axisCalibration.sensitivityCurve != null)
								{
									bool num2 = GUI.enabled;
									GUI.enabled = false;
									QgsfUjzyZHbNzfZrivDsWRHsbWAw.BYUIvWzocVkHFoOQNLnNOXXJeNTe("Sensitivity Curve", axisCalibration.sensitivityCurve);
									GUI.enabled = num2;
								}
								else
								{
									QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Sensitivity Curve", "--");
								}
							}
						}
						axisCount = calibrationMap.axis2DCount;
						for (int l = 0; l < axisCount; l++)
						{
							Axis2DCalibration axis2DCalibration = calibrationMap.Axes2D[l];
							using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao5 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(l + ": Axis2D Calibration", text + "_Axis2DCalibration" + l, P_1);
							if (zLdgzeuFGnBHDWzImfaPUbCZCsao5.CIkfXThOynxfPEPAAVDnavDieDMRA)
							{
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Dead Zone Type", axis2DCalibration.deadZoneType.ToString());
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Sensitivity Type", axis2DCalibration.sensitivityType.ToString());
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Clamp Type", axis2DCalibration.clampType.ToString());
							}
						}
					}
				}
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Supports Vibration", joystick.supportsVibration.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Vibration Motor Count", joystick.vibrationMotorCount.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Extension Count", joystick.Extensions.Count.ToString());
				for (int m = 0; m < joystick.Extensions.Count; m++)
				{
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Extension Type", (joystick.Extensions[m] != null) ? joystick.Extensions[m].GetType().Name : "--");
				}
				ToVMUqUThSJClqkzyNSLOgzrdJlo(joystick, P_1, text);
			}
		}

		private static void hznrfsgOqkWMnbABfNXXcyehURVD(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_mouse";
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Mouse", text, P_0);
			if (!zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				return;
			}
			Mouse mouse = ReInput.controllers.Mouse;
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Enabled", mouse.enabled.ToString());
			string text2 = string.Empty;
			for (int i = 0; i < ReInput.players.allPlayerCount; i++)
			{
				Player player = ReInput.players.AllPlayers[i];
				if (player.controllers.hasMouse)
				{
					if (text2 != string.Empty)
					{
						text2 += ", ";
					}
					text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
				}
			}
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Screen Position", mouse.screenPosition.ToString());
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Screen Position Prev", mouse.screenPositionPrev.ToString());
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Screen Position Delta", mouse.screenPositionDelta.ToString());
			pXDqCcvkxbJDjfeQJbNiamlutBYr(mouse.Axes, P_0, text);
			sEsdqhSJlPEzJIVRJTqgTWWWpSyp(mouse.Buttons, ControllerType.Mouse, P_0, text);
			xxOvPWZFHvIQiUbNZtVXOnhVDvxEA(mouse, P_0, text);
			ToVMUqUThSJClqkzyNSLOgzrdJlo(mouse, P_0, text);
		}

		private static void KqLVcmEdsOfxpMtdKfjtDPVBlGZn(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_keyboard";
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Keyboard", text, P_0);
			if (!zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				return;
			}
			Keyboard keyboard = ReInput.controllers.Keyboard;
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Enabled", keyboard.enabled.ToString());
			string text2 = string.Empty;
			for (int i = 0; i < ReInput.players.allPlayerCount; i++)
			{
				Player player = ReInput.players.AllPlayers[i];
				if (player.controllers.hasKeyboard)
				{
					if (text2 != string.Empty)
					{
						text2 += ", ";
					}
					text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
				}
			}
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Extension Count", keyboard.Extensions.Count.ToString());
			for (int j = 0; j < keyboard.Extensions.Count; j++)
			{
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Extension Type", (keyboard.Extensions[j] != null) ? keyboard.Extensions[j].GetType().Name : "--");
			}
			sEsdqhSJlPEzJIVRJTqgTWWWpSyp(keyboard.Buttons, ControllerType.Keyboard, P_0, text);
			xxOvPWZFHvIQiUbNZtVXOnhVDvxEA(keyboard, P_0, text);
			ToVMUqUThSJClqkzyNSLOgzrdJlo(keyboard, P_0, text);
		}

		private static void zmttNgyBwldVjMLbvNPWfDSbEJPN(IList<CustomController> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Custom Controllers (" + num + ")", P_2 + "_customControllers", P_1);
			if (!zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				CustomController customController = P_0[i];
				int id = customController.id;
				string text = P_2 + "_customController" + id;
				using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao2 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(i + ": " + customController.name, text, P_1);
				if (!zLdgzeuFGnBHDWzImfaPUbCZCsao2.CIkfXThOynxfPEPAAVDnavDieDMRA)
				{
					continue;
				}
				id = customController.id;
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Id", id.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Name", customController.name);
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Hardware Name", customController.hardwareName);
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Tag", customController.tag);
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Hardware Identifier", customController.hardwareIdentifier);
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Enabled", customController.enabled.ToString());
				string text2 = string.Empty;
				for (int j = 0; j < ReInput.players.allPlayerCount; j++)
				{
					Player player = ReInput.players.AllPlayers[j];
					if (ReInput.controllers.IsCustomControllerAssignedToPlayer(customController.id, player.id))
					{
						if (text2 != string.Empty)
						{
							text2 += ", ";
						}
						text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
					}
				}
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
				pXDqCcvkxbJDjfeQJbNiamlutBYr(customController.Axes, P_1, text);
				sEsdqhSJlPEzJIVRJTqgTWWWpSyp(customController.Buttons, ControllerType.Custom, P_1, text);
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Axis2D Count", customController.axis2DCount.ToString());
				using (ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao3 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Element Identifiers", text + "_elementIdentifiers", P_1))
				{
					if (zLdgzeuFGnBHDWzImfaPUbCZCsao3.CIkfXThOynxfPEPAAVDnavDieDMRA)
					{
						int num2 = ((customController.AxisElementIdentifiers != null) ? customController.AxisElementIdentifiers.Count : 0);
						using (ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao4 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Axis Element Identifiers (" + num2 + ")", text + "_axisEIs", P_1))
						{
							if (zLdgzeuFGnBHDWzImfaPUbCZCsao4.CIkfXThOynxfPEPAAVDnavDieDMRA)
							{
								for (int k = 0; k < num2; k++)
								{
									ControllerElementIdentifier controllerElementIdentifier = customController.AxisElementIdentifiers[k];
									using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao5 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(k + ": " + controllerElementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename + " (id: " + controllerElementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid + ")", text + "_AxisEI" + k + "_" + controllerElementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename, P_1);
									if (zLdgzeuFGnBHDWzImfaPUbCZCsao5.CIkfXThOynxfPEPAAVDnavDieDMRA)
									{
										QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Id", controllerElementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid.ToString());
										QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Name", controllerElementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename);
									}
								}
							}
						}
						num2 = ((customController.ButtonElementIdentifiers != null) ? customController.ButtonElementIdentifiers.Count : 0);
						using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao6 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Button Element Identifiers (" + num2 + ")", text + "_buttonEIs", P_1);
						if (zLdgzeuFGnBHDWzImfaPUbCZCsao6.CIkfXThOynxfPEPAAVDnavDieDMRA)
						{
							for (int l = 0; l < num2; l++)
							{
								ControllerElementIdentifier controllerElementIdentifier2 = customController.ButtonElementIdentifiers[l];
								using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao7 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(l + ": " + controllerElementIdentifier2.XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename + " (id: " + controllerElementIdentifier2.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid + ")", text + "_ButtonEI" + l + "_" + controllerElementIdentifier2.XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename, P_1);
								if (zLdgzeuFGnBHDWzImfaPUbCZCsao7.CIkfXThOynxfPEPAAVDnavDieDMRA)
								{
									QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Id", controllerElementIdentifier2.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid.ToString());
									QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Name", controllerElementIdentifier2.XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename);
								}
							}
						}
					}
				}
				CalibrationMap calibrationMap = customController.calibrationMap;
				using (ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao8 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Calibration Map", text + "_calibrationMap", P_1))
				{
					if (zLdgzeuFGnBHDWzImfaPUbCZCsao8.CIkfXThOynxfPEPAAVDnavDieDMRA)
					{
						int num2 = calibrationMap.axisCount;
						for (int m = 0; m < num2; m++)
						{
							AxisCalibration axisCalibration = calibrationMap.Axes[m];
							using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao9 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(m + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + m, P_1);
							if (zLdgzeuFGnBHDWzImfaPUbCZCsao9.CIkfXThOynxfPEPAAVDnavDieDMRA)
							{
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Enabled", axisCalibration.enabled.ToString());
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Calibrated Max", axisCalibration.calibratedMax.ToString());
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Calibrated Min", axisCalibration.calibratedMin.ToString());
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Calibrated Zero", axisCalibration.calibratedZero.ToString());
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Dead Zone", axisCalibration.deadZone.ToString());
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Upper Dead Zone", axisCalibration.upperDeadZone.ToString());
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Invert", axisCalibration.invert.ToString());
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Sensitivity Type", axisCalibration.sensitivityType.ToString());
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Sensitivity", axisCalibration.sensitivity.ToString());
								if (axisCalibration.sensitivityCurve != null)
								{
									bool num3 = GUI.enabled;
									GUI.enabled = false;
									QgsfUjzyZHbNzfZrivDsWRHsbWAw.BYUIvWzocVkHFoOQNLnNOXXJeNTe("Sensitivity Curve", axisCalibration.sensitivityCurve);
									GUI.enabled = num3;
								}
								else
								{
									QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Sensitivity Curve", "--");
								}
							}
						}
					}
				}
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Extension Count", customController.Extensions.Count.ToString());
				for (int n = 0; n < customController.Extensions.Count; n++)
				{
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Extension Type", (customController.Extensions[n] != null) ? customController.Extensions[n].GetType().Name : "--");
				}
				ToVMUqUThSJClqkzyNSLOgzrdJlo(customController, P_1, text);
			}
		}

		private static void wYTOZlAMSXjzRtFadBNZtxCpbHkH(Player P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_player" + P_0.id;
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao((P_0.id == 9999999) ? "System Player" : (P_1 + ": " + P_0.name), text, P_2);
			if (!zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				return;
			}
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Player Id", P_0.id.ToString());
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Name", P_0.name);
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Descriptive Name", P_0.descriptiveName);
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Is Playing", P_0.isPlaying.ToString());
			using (ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao2 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Controllers", text + "_controllers", P_2))
			{
				if (zLdgzeuFGnBHDWzImfaPUbCZCsao2.CIkfXThOynxfPEPAAVDnavDieDMRA)
				{
					Player.ControllerHelper controllers = P_0.controllers;
					vDlQgtmXLFevmuwpSNMKwGtUZGVb(controllers.Joysticks, P_2, text);
					zmttNgyBwldVjMLbvNPWfDSbEJPN(controllers.CustomControllers, P_2, text);
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Has Mouse", controllers.hasMouse.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Has Keyboard", controllers.hasKeyboard.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Exclude From Controller Auto Assignment", controllers.excludeFromControllerAutoAssignment.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Last Active Controller", (controllers.GetLastActiveController() != null) ? controllers.GetLastActiveController().name.ToString() : "NULL");
				}
			}
			string text2 = text + "_controllerMaps";
			using (ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao3 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Controller Maps", text2, P_2))
			{
				if (zLdgzeuFGnBHDWzImfaPUbCZCsao3.CIkfXThOynxfPEPAAVDnavDieDMRA)
				{
					PvvlzgRCvVgoOmuvyZbMUHEbqDKQ(ControllerType.Keyboard, P_0.controllers.maps.GetMaps<KeyboardMap>(0), "Keyboard Maps", P_2, text2 + "_keyboard");
					PvvlzgRCvVgoOmuvyZbMUHEbqDKQ(ControllerType.Mouse, P_0.controllers.maps.GetMaps<MouseMap>(0), "Mouse Maps", P_2, text2 + "_mouse");
					string text3 = text2 + "_joystickMaps";
					using (ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao4 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Joystick Maps (" + P_0.controllers.joystickCount + ")", text3, P_2))
					{
						if (zLdgzeuFGnBHDWzImfaPUbCZCsao4.CIkfXThOynxfPEPAAVDnavDieDMRA)
						{
							for (int i = 0; i < P_0.controllers.joystickCount; i++)
							{
								Joystick joystick = P_0.controllers.Joysticks[i];
								IList<JoystickMap> maps = P_0.controllers.maps.GetMaps<JoystickMap>(joystick.id);
								string text4 = text3;
								int id = joystick.id;
								text3 = text4 + "_joystickId" + id;
								PvvlzgRCvVgoOmuvyZbMUHEbqDKQ(ControllerType.Joystick, maps, (joystick.name != "Unknown Controller") ? joystick.name : joystick.hardwareName, P_2, text3);
							}
						}
					}
					text3 = text2 + "_customControllerMaps";
					using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao5 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Custom Controller Maps (" + P_0.controllers.customControllerCount + ")", text3, P_2);
					if (zLdgzeuFGnBHDWzImfaPUbCZCsao5.CIkfXThOynxfPEPAAVDnavDieDMRA)
					{
						for (int j = 0; j < P_0.controllers.customControllerCount; j++)
						{
							CustomController customController = P_0.controllers.CustomControllers[j];
							IList<CustomControllerMap> maps2 = P_0.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
							string text5 = text3;
							int id = customController.id;
							text3 = text5 + "_customControllerId" + id;
							PvvlzgRCvVgoOmuvyZbMUHEbqDKQ(ControllerType.Custom, maps2, customController.name, P_2, text3);
						}
					}
				}
			}
			text2 = text + "_controllerMapLayoutManager";
			using (ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao6 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Layout Manager", text2, P_2))
			{
				if (zLdgzeuFGnBHDWzImfaPUbCZCsao6.CIkfXThOynxfPEPAAVDnavDieDMRA)
				{
					xiEgnUWlnoEfhRIBhHOwMbBtYyYf(P_0.controllers.maps.layoutManager, P_2, text2);
				}
			}
			text2 = text + "_controllerMapEnabler";
			using (ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao7 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Map Enabler", text2, P_2))
			{
				if (zLdgzeuFGnBHDWzImfaPUbCZCsao7.CIkfXThOynxfPEPAAVDnavDieDMRA)
				{
					SVKzbiVUINkjDHRzRyGFtajZfTVJA(P_0.controllers.maps.mapEnabler, P_2, text2);
				}
			}
			text2 = text + "_inputBehaviors";
			npwHyuhEBAECRfshefyEAWakBibP(P_0.controllers.maps.InputBehaviors, P_2, text2);
			text2 = text + "_actions";
			List<InputAction> list = new List<InputAction>(ReInput.mapping.Actions);
			list.Sort(EpjYGYbebpCoYbcSJcSakRGhcqQf._003C_003E9.KtwDRZFDnHqiTYAjcOYGxXObhCyPA);
			IList<InputCategory> actionCategories = ReInput.mapping.ActionCategories;
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao8 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Actions (" + list.Count + ")", text2, P_2);
			if (!zLdgzeuFGnBHDWzImfaPUbCZCsao8.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				return;
			}
			for (int k = 0; k < actionCategories.Count; k++)
			{
				BBSzbClbspBIgcyKEJKqGnePngvvA bBSzbClbspBIgcyKEJKqGnePngvvA = new BBSzbClbspBIgcyKEJKqGnePngvvA();
				bBSzbClbspBIgcyKEJKqGnePngvvA.axrQAdmDmAcVvbtRATRrAwHInibrA = actionCategories[k];
				string text6 = text2 + "_actionCat" + bBSzbClbspBIgcyKEJKqGnePngvvA.axrQAdmDmAcVvbtRATRrAwHInibrA.id;
				int num = ListTools.Count(list, bBSzbClbspBIgcyKEJKqGnePngvvA.PCEwqwBOjiHBMDzEPrAEtEAARQxxA);
				using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao9 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("id " + bBSzbClbspBIgcyKEJKqGnePngvvA.axrQAdmDmAcVvbtRATRrAwHInibrA.id + ": " + bBSzbClbspBIgcyKEJKqGnePngvvA.axrQAdmDmAcVvbtRATRrAwHInibrA.name + " (" + num + ")", text6, P_2);
				if (!zLdgzeuFGnBHDWzImfaPUbCZCsao9.CIkfXThOynxfPEPAAVDnavDieDMRA)
				{
					continue;
				}
				for (int l = 0; l < list.Count; l++)
				{
					InputAction inputAction = list[l];
					if (inputAction.categoryId != bBSzbClbspBIgcyKEJKqGnePngvvA.axrQAdmDmAcVvbtRATRrAwHInibrA.id)
					{
						continue;
					}
					string text7 = text6 + "_actionId" + inputAction.id;
					using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao10 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("id " + inputAction.id + ": " + inputAction.name + ": " + P_0.GetAxis(inputAction.id).ToString("f3"), text7, P_2);
					if (zLdgzeuFGnBHDWzImfaPUbCZCsao10.CIkfXThOynxfPEPAAVDnavDieDMRA)
					{
						QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Axis Value", P_0.GetAxis(inputAction.id).ToString());
						QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Axis Raw Value", P_0.GetAxisRaw(inputAction.id).ToString());
						QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Button Value", P_0.GetButton(inputAction.id).ToString());
						QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Button Double Press Value", P_0.GetButtonDoublePressHold(inputAction.id).ToString());
						QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Button Short Press Value", P_0.GetButtonShortPress(inputAction.id).ToString());
						QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Button Long Press Value", P_0.GetButtonLongPress(inputAction.id).ToString());
						QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Button Repeating Value", P_0.GetButtonRepeating(inputAction.id).ToString());
						QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Negative Button Value", P_0.GetNegativeButton(inputAction.id).ToString());
						QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Negative Button Double Press Value", P_0.GetNegativeButtonDoublePressHold(inputAction.id).ToString());
						QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Negative Button Short Press Value", P_0.GetNegativeButtonShortPress(inputAction.id).ToString());
						QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Negative Button Long Press Value", P_0.GetNegativeButtonLongPress(inputAction.id).ToString());
						QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Negative Button Repeating Value", P_0.GetNegativeButtonRepeating(inputAction.id).ToString());
						QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Axis Time Active", P_0.GetAxisTimeActive(inputAction.id).ToString());
						QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Axis Time Inactive", P_0.GetAxisTimeInactive(inputAction.id).ToString());
						QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Axis Raw Time Active", P_0.GetAxisRawTimeActive(inputAction.id).ToString());
						QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Axis Raw Time Inactive", P_0.GetAxisRawTimeInactive(inputAction.id).ToString());
						QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Button Time Pressed", P_0.GetButtonTimePressed(inputAction.id).ToString());
						QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Button Time Unpressed", P_0.GetButtonTimeUnpressed(inputAction.id).ToString());
						QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Negative Button Time Pressed", P_0.GetNegativeButtonTimePressed(inputAction.id).ToString());
						QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Negative Button Time Unpressed", P_0.GetNegativeButtonTimeUnpressed(inputAction.id).ToString());
					}
				}
			}
		}

		private static void npwHyuhEBAECRfshefyEAWakBibP(IList<InputBehavior> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Input Behaviors (" + num + ")", P_2 + "_inputBehaviors", P_1);
			if (zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				for (int i = 0; i < num; i++)
				{
					YWrEbGRUvLXKNJUZkuXIEZLfbePR(P_0[i], i, P_1, P_2);
				}
			}
		}

		private static void YWrEbGRUvLXKNJUZkuXIEZLfbePR(InputBehavior P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_inputBehavior" + P_0.id;
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(P_1 + ": " + P_0.name, text, P_2);
			if (zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Id", P_0.id.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Name", P_0.name);
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Digital Axis Gravity", P_0.digitalAxisGravity.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Digital Axis Instant Reverse", P_0.digitalAxisInstantReverse.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Digital Axis Sensitivity", P_0.digitalAxisSensitivity.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Digital Axis Snap", P_0.digitalAxisSnap.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Joystick Axis Sensitivity", P_0.joystickAxisSensitivity.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Custom Controller Axis Sensitivity", P_0.customControllerAxisSensitivity.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Mouse XY Axis Mode", P_0.mouseXYAxisMode.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Mouse XY Axis Sensitivity", P_0.mouseXYAxisSensitivity.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Mouse XY Axis Delta Calc", P_0.mouseXYAxisDeltaCalc.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Mouse Other Axis Mode", P_0.mouseOtherAxisMode.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Mouse Other Axis Sensitivity", P_0.mouseOtherAxisSensitivity.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Button Dead Zone", P_0.buttonDeadZone.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Button Double Press Speed", P_0.buttonDoublePressSpeed.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Button Short Press Time", P_0.buttonShortPressTime.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Button Short Press Expires In", P_0.buttonShortPressExpiresIn.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Button Long Press Time", P_0.buttonLongPressTime.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Button Long Press Expires In", P_0.buttonLongPressExpiresIn.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Button Down Buffer", P_0.buttonDownBuffer.ToString());
			}
		}

		private static void xxOvPWZFHvIQiUbNZtVXOnhVDvxEA(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Element Identifiers", P_2 + "_elementIdentifiers", P_1);
			if (!zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				return;
			}
			int num;
			if (P_0 is ControllerWithAxes)
			{
				ControllerWithAxes controllerWithAxes = P_0 as ControllerWithAxes;
				num = ((controllerWithAxes.AxisElementIdentifiers != null) ? controllerWithAxes.AxisElementIdentifiers.Count : 0);
				using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao2 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Axis Element Identifiers (" + num + ")", P_2 + "_axisEIs", P_1);
				if (zLdgzeuFGnBHDWzImfaPUbCZCsao2.CIkfXThOynxfPEPAAVDnavDieDMRA)
				{
					for (int i = 0; i < num; i++)
					{
						ControllerElementIdentifier controllerElementIdentifier = controllerWithAxes.AxisElementIdentifiers[i];
						using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao3 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(i + ": " + controllerElementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename + " (id: " + controllerElementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid + ")", P_2 + "_AxisEI" + i + "_" + controllerElementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename, P_1);
						if (zLdgzeuFGnBHDWzImfaPUbCZCsao3.CIkfXThOynxfPEPAAVDnavDieDMRA)
						{
							QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Id", controllerElementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid.ToString());
							QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Name", controllerElementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename);
						}
					}
				}
			}
			if (P_0 == null)
			{
				return;
			}
			num = ((P_0.ButtonElementIdentifiers != null) ? P_0.ButtonElementIdentifiers.Count : 0);
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao4 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Button Element Identifiers (" + num + ")", P_2 + "_buttonEIs", P_1);
			if (!zLdgzeuFGnBHDWzImfaPUbCZCsao4.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				return;
			}
			for (int j = 0; j < num; j++)
			{
				ControllerElementIdentifier controllerElementIdentifier2 = P_0.ButtonElementIdentifiers[j];
				using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao5 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(j + ": " + controllerElementIdentifier2.XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename + " (id: " + controllerElementIdentifier2.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid + ")", P_2 + "_ButtonEI" + j + "_" + controllerElementIdentifier2.XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename, P_1);
				if (zLdgzeuFGnBHDWzImfaPUbCZCsao5.CIkfXThOynxfPEPAAVDnavDieDMRA)
				{
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Id", controllerElementIdentifier2.XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Name", controllerElementIdentifier2.XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename);
				}
			}
		}

		private static void sEsdqhSJlPEzJIVRJTqgTWWWpSyp(IList<Controller.Button> P_0, ControllerType P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string obj = ((P_1 == ControllerType.Keyboard) ? "Key" : "Button");
			int num = P_0?.Count ?? 0;
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(obj + "s (" + num + ")", P_3 + "_Buttons", P_2);
			if (!zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Controller.Button button = P_0[i];
				using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao2 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(i + ": " + ((P_1 == ControllerType.Keyboard) ? (Keyboard.GetKeyboardKeyCodeByButtonIndex(i).ToString() + " (" + Keyboard.GetKeyName(Keyboard.GetKeyboardKeyCodeByButtonIndex(i)) + ")") : button.elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename) + ": " + (button.value ? "Pressed" : "") + " (" + button.pressure.ToString("f3") + ")", P_3 + "_" + button.name, P_2);
				if (zLdgzeuFGnBHDWzImfaPUbCZCsao2.CIkfXThOynxfPEPAAVDnavDieDMRA)
				{
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Is Member Element", button.isMemberElement.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Is Pressure Sensitive", button.isPressureSensitive.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value", button.value.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value Prev", button.valuePrev.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Pressure", button.pressure.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Pressure Prev", button.pressurePrev.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Just Pressed", button.justPressed.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Just Released", button.justReleased.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Just Double Pressed", button.justDoublePressed.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Double Pressed And Held", button.doublePressedAndHeld.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Time Pressed", button.timePressed.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Time Unpressed", button.timeUnpressed.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Last Time Pressed", button.lastTimePressed.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Last Time Unpressed", button.lastTimeUnpressed.ToString());
				}
			}
		}

		private static void pXDqCcvkxbJDjfeQJbNiamlutBYr(IList<Controller.Axis> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Axes (" + num + ")", P_2 + "_Axes", P_1);
			if (!zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Controller.Axis axis = P_0[i];
				using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao2 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(i + ": " + axis.elementIdentifier.XAukkdYkRkAZDxUWBprlnhBlowWG_002Ename + ": " + axis.value.ToString("f3") + " (" + axis.valueRaw.ToString("f3") + ")", P_2 + "_" + axis.name, P_1);
				if (zLdgzeuFGnBHDWzImfaPUbCZCsao2.CIkfXThOynxfPEPAAVDnavDieDMRA)
				{
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Is Member Element", axis.isMemberElement.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value", axis.value.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value Raw", axis.valueRaw.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value Prev", axis.valuePrev.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value Raw Prev", axis.valueRawPrev.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value Delta", axis.valueDelta.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value Delta Raw", axis.valueDeltaRaw.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Time Active", axis.timeActive.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Time Active Raw", axis.timeActiveRaw.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Time Inactive", axis.timeInactive.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Time Inactive Raw", axis.timeInactiveRaw.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Last Time Active", axis.lastTimeActive.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Last Time Active Raw", axis.lastTimeActiveRaw.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Last Time Inactive", axis.lastTimeInactive.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Last Time Inactive Raw", axis.lastTimeInactiveRaw.ToString());
				}
			}
		}

		private static void PvvlzgRCvVgoOmuvyZbMUHEbqDKQ<_0001>(ControllerType P_0, IList<_0001> P_1, string P_2, IDictionary<string, bool> P_3, string P_4) where _0001 : ControllerMap
		{
			string text = P_4 + "_controllerMaps";
			int num = P_1?.Count ?? 0;
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(P_2 + " (" + num + ")", text, P_3);
			if (!zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				string text2 = (P_1[i].enabled ? "Enabled" : "Disabled");
				InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_1[i].categoryId);
				InputLayout layout = ReInput.mapping.GetLayout(P_0, P_1[i].layoutId);
				string text3 = ((mapCategory != null) ? mapCategory.name : "n/a");
				string text4 = ((layout != null) ? layout.name : "n/a");
				using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao2 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(i + ": " + text3 + ", " + text4 + ": " + text2, P_4 + "_index" + i, P_3);
				if (zLdgzeuFGnBHDWzImfaPUbCZCsao2.CIkfXThOynxfPEPAAVDnavDieDMRA)
				{
					if (P_1[i] is ControllerMapWithAxes)
					{
						jbuwZOYYlCmmrgROOiZaSsjsRwwG(P_1[i] as ControllerMapWithAxes, P_3, text + i);
					}
					else
					{
						ELgWtgXIUmTbSxdxtohbiOzXBwOHA(P_1[i], P_3, text + i);
					}
				}
			}
		}

		private static void ELgWtgXIUmTbSxdxtohbiOzXBwOHA(ControllerMap P_0, IDictionary<string, bool> P_1, string P_2)
		{
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Id (unique id)", P_0.id.ToString());
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Source Map Id", P_0.sourceMapId.ToString());
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Enabled", P_0.enabled.ToString());
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Controller Type", P_0.controllerType.ToString());
			if (P_0.controllerType == ControllerType.Joystick || P_0.controllerType == ControllerType.Custom)
			{
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Controller Id", P_0.controllerId.ToString());
			}
			string text = P_0.categoryId.ToString();
			if (P_0.categoryId >= 0)
			{
				try
				{
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_0.categoryId);
					if (mapCategory != null)
					{
						text = text + " (" + mapCategory.name + ")";
					}
				}
				catch
				{
				}
			}
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Category Id", text);
			string text2 = P_0.layoutId.ToString();
			if (P_0.layoutId >= 0)
			{
				try
				{
					InputLayout layout = ReInput.mapping.GetLayout(P_0.controllerType, P_0.layoutId);
					if (layout != null)
					{
						text2 = text2 + " (" + layout.name + ")";
					}
				}
				catch
				{
				}
			}
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Layout Id", text2);
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Is Modified", P_0.isModified.ToString());
			if (P_0.isModified)
			{
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Modified Time", P_0.modifiedTime.ToString());
			}
			int buttonMapCount = P_0.buttonMapCount;
			string text3 = P_2 + "_buttonMaps";
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Button Maps (" + buttonMapCount + ")", text3, P_1);
			if (zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				for (int i = 0; i < buttonMapCount; i++)
				{
					gEkLofQybidHAupxlkTJMhwEeHrC(P_0.controllerType, P_0.ButtonMaps[i], i, P_1, text3 + i);
				}
			}
		}

		private static void jbuwZOYYlCmmrgROOiZaSsjsRwwG(ControllerMapWithAxes P_0, IDictionary<string, bool> P_1, string P_2)
		{
			ELgWtgXIUmTbSxdxtohbiOzXBwOHA(P_0, P_1, P_2);
			string text = P_2 + "_axisMaps";
			int axisMapCount = P_0.axisMapCount;
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Axis Maps (" + axisMapCount + ")", text, P_1);
			if (zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				for (int i = 0; i < axisMapCount; i++)
				{
					gEkLofQybidHAupxlkTJMhwEeHrC(P_0.controllerType, P_0.AxisMaps[i], i, P_1, text + i);
				}
			}
		}

		private static void gEkLofQybidHAupxlkTJMhwEeHrC(ControllerType P_0, ActionElementMap P_1, int P_2, IDictionary<string, bool> P_3, string P_4)
		{
			string text = "Action Element Map";
			InputAction action = ReInput.mapping.GetAction(P_1.actionId);
			string text2 = ((action != null) ? action.name : string.Empty);
			string text3 = PBSCDoDfUQCKWgRWQbZnCCRpvYyKA(P_1);
			if (!string.IsNullOrEmpty(text3))
			{
				text = P_1.elementIdentifierName + " (" + text3 + ")";
			}
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(P_2 + ": " + text, P_4 + "_" + P_2, P_3);
			if (!zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				return;
			}
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Id (unique id)", P_1.id.ToString());
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Enabled", P_1.enabled.ToString());
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Element Type", P_1.elementType.ToString());
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Action Id", P_1.actionId + " " + ((action != null) ? ("(" + text2 + ")") : ""));
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Element Identifier Id", P_1.elementIdentifierId.ToString());
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Element Identifier Name", P_1.elementIdentifierName);
			if (P_1.elementType == ControllerElementType.Axis)
			{
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Element Index", P_1.elementIndex.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Axis Range", P_1.axisRange.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Axis Type", P_1.axisType.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Invert", P_1.invert.ToString());
			}
			else if (P_1.elementType == ControllerElementType.Button)
			{
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Element Index", P_1.elementIndex.ToString());
				if (P_0 == ControllerType.Keyboard)
				{
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Key Code", P_1.keyCode.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Keyboard Key Code", P_1.keyboardKeyCode.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Has Modifiers", P_1.hasModifiers.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Modifier Key 1", P_1.modifierKey1.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Modifier Key 2", P_1.modifierKey2.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Modifier Key 3", P_1.modifierKey3.ToString());
				}
			}
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Axis Contribution", P_1.axisContribution.ToString());
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Modified Timestamp", P_1.modifiedTime.ToString());
		}

		private static string PBSCDoDfUQCKWgRWQbZnCCRpvYyKA(ActionElementMap P_0)
		{
			InputAction action = ReInput.mapping.GetAction(P_0.actionId);
			if (action == null)
			{
				return string.Empty;
			}
			string text = string.Empty;
			if (P_0.elementType == ControllerElementType.Button || (P_0.elementType == ControllerElementType.Axis && P_0.axisType == AxisType.Split))
			{
				if (P_0.axisContribution == Pole.Positive)
				{
					text = action.positiveDescriptiveName;
					if (string.IsNullOrEmpty(text))
					{
						text = ((!string.IsNullOrEmpty(action.descriptiveName)) ? (action.descriptiveName + " +") : (action.name + " +"));
					}
				}
				else
				{
					text = action.negativeDescriptiveName;
					if (string.IsNullOrEmpty(text))
					{
						text = ((!string.IsNullOrEmpty(action.descriptiveName)) ? (action.descriptiveName + " -") : (action.name + " -"));
					}
				}
			}
			else if (P_0.elementType == ControllerElementType.Axis && P_0.axisType == AxisType.Normal)
			{
				text = ((!string.IsNullOrEmpty(action.descriptiveName)) ? action.descriptiveName : action.name);
			}
			return text;
		}

		private static void xiEgnUWlnoEfhRIBhHOwMbBtYyYf(ControllerMapLayoutManager P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (HoIFCocmHJruIqOKadxqgwSMtGthA("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Load from User Data Store", P_0.loadFromUserDataStore.ToString());
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Rule Sets (" + count + ")", text, P_1);
			if (zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				for (int i = 0; i < count; i++)
				{
					vnzcjyadbsihXVnYeGscXRVlsHER(P_0.ruleSets[i], i, P_1, text + i);
				}
			}
		}

		private static void vnzcjyadbsihXVnYeGscXRVlsHER(ControllerMapLayoutManager.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = P_0?.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapLayoutManager_002ERule_003E_002ECount ?? 0;
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
			if (!zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				return;
			}
			if (HoIFCocmHJruIqOKadxqgwSMtGthA("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Tag", P_0.tag);
			string text = P_3 + "_rules";
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao2 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Rules (" + P_0.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapLayoutManager_002ERule_003E_002ECount + ")", text, P_2);
			if (!zLdgzeuFGnBHDWzImfaPUbCZCsao2.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				ControllerMapLayoutManager.Rule rule = P_0[i];
				string text2 = text + i;
				using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao3 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
				if (!zLdgzeuFGnBHDWzImfaPUbCZCsao3.CIkfXThOynxfPEPAAVDnavDieDMRA)
				{
					continue;
				}
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Tag", rule.tag);
				tfEGaSjIapGYIodASkEyzkwlZKmVA(rule.controllerSetSelector, P_2, text2);
				int[] categoryIds = rule.categoryIds;
				int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
				using (ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao4 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
				{
					if (zLdgzeuFGnBHDWzImfaPUbCZCsao4.CIkfXThOynxfPEPAAVDnavDieDMRA)
					{
						if (num2 == 0)
						{
							QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Category", "All Map Categories");
						}
						else
						{
							for (int j = 0; j < categoryIds.Length; j++)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
								string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Category " + j, text3);
							}
						}
					}
				}
				InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, rule.layoutId);
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc(rule.controllerSetSelector.controllerType.ToString() + " Layout", (layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
			}
		}

		private static void SVKzbiVUINkjDHRzRyGFtajZfTVJA(ControllerMapEnabler P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (HoIFCocmHJruIqOKadxqgwSMtGthA("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Rule Sets (" + count + ")", text, P_1);
			if (zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				for (int i = 0; i < count; i++)
				{
					FamiDGsgNeLazpRxjiKIjVkDDGPX(P_0.ruleSets[i], i, P_1, text + i);
				}
			}
		}

		private static void FamiDGsgNeLazpRxjiKIjVkDDGPX(ControllerMapEnabler.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = P_0?.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapEnabler_002ERule_003E_002ECount ?? 0;
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
			if (!zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				return;
			}
			if (HoIFCocmHJruIqOKadxqgwSMtGthA("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Tag", P_0.tag);
			string text = P_3 + "_rules";
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao2 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Rules (" + P_0.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapEnabler_002ERule_003E_002ECount + ")", text, P_2);
			if (!zLdgzeuFGnBHDWzImfaPUbCZCsao2.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				ControllerMapEnabler.Rule rule = P_0[i];
				string text2 = text + i;
				using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao3 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
				if (!zLdgzeuFGnBHDWzImfaPUbCZCsao3.CIkfXThOynxfPEPAAVDnavDieDMRA)
				{
					continue;
				}
				if (HoIFCocmHJruIqOKadxqgwSMtGthA("Enable", rule.enable))
				{
					rule.enable = !rule.enable;
				}
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Tag", rule.tag);
				tfEGaSjIapGYIodASkEyzkwlZKmVA(rule.controllerSetSelector, P_2, text2);
				int[] categoryIds = rule.categoryIds;
				int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
				using (ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao4 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
				{
					if (zLdgzeuFGnBHDWzImfaPUbCZCsao4.CIkfXThOynxfPEPAAVDnavDieDMRA)
					{
						if (num2 == 0)
						{
							QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Category", "All Map Categories");
						}
						else
						{
							for (int j = 0; j < categoryIds.Length; j++)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
								string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
								QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Category " + j, text3);
							}
						}
					}
				}
				int[] layoutIds = rule.layoutIds;
				int num3 = ((layoutIds != null) ? layoutIds.Length : 0);
				using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao5 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Layouts (" + num3 + ")", text2 + "_layoutIds", P_2);
				if (!zLdgzeuFGnBHDWzImfaPUbCZCsao5.CIkfXThOynxfPEPAAVDnavDieDMRA)
				{
					continue;
				}
				if (num3 == 0)
				{
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Layout", (rule.controllerSetSelector.type == ControllerSetSelector.Type.All) ? "All Layouts" : ("All " + rule.controllerSetSelector.controllerType.ToString() + " Layouts"));
					continue;
				}
				for (int k = 0; k < layoutIds.Length; k++)
				{
					InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, layoutIds[k]);
					string text4 = ((layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc(rule.controllerSetSelector.controllerType.ToString() + " Layout " + k, text4);
				}
			}
		}

		private static void tfEGaSjIapGYIodASkEyzkwlZKmVA(ControllerSetSelector P_0, IDictionary<string, bool> P_1, string P_2)
		{
			string text = P_2 + "_controllerSetSelector";
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Controller Set Selector", text, P_1);
			if (zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Type", StringTools.AddSpacesToSentence(P_0.type.ToString(), preserveAcronyms: false));
				if (P_0.type != ControllerSetSelector.Type.All)
				{
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Controller Type", P_0.controllerType.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.HardwareType)
				{
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Hardware Type Guid", P_0.hardwareTypeGuid.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Hardware Identifier", P_0.hardwareIdentifier);
				}
				if (P_0.type == ControllerSetSelector.Type.ControllerTemplateType)
				{
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Controller Template Type Guid", P_0.controllerTemplateTypeGuid.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.PersistentControllerInstance)
				{
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Device Instance Guid", P_0.deviceInstanceGuid.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.SessionControllerInstance)
				{
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Controller Id", P_0.controllerId.ToString());
				}
			}
		}

		private static void ToVMUqUThSJClqkzyNSLOgzrdJlo(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			P_2 += "_templates";
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Templates (" + P_0.templateCount + ")", P_2, P_1);
			if (zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				for (int i = 0; i < P_0.templateCount; i++)
				{
					cLLGBZCPGOfLvbLbfBlrOUMbrzSub(P_0.Templates[i], i, P_2, P_1);
				}
			}
		}

		private static void cLLGBZCPGOfLvbLbfBlrOUMbrzSub(IControllerTemplate P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(((P_1 >= 0) ? (P_1 + ": ") : "") + P_0.name, P_2, P_3);
			if (!zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				return;
			}
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Type GUID", P_0.typeGuid.ToString());
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Class Type", P_0.GetType().ToString());
			P_2 += "_elements";
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao2 = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Elements (" + P_0.elementCount + ")", P_2, P_3);
			if (zLdgzeuFGnBHDWzImfaPUbCZCsao2.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				for (int i = 0; i < P_0.elementCount; i++)
				{
					ehQJfvZtMCrmSpujpnPgWjhIelRL(P_0.elements[i], i, P_2, P_3);
				}
			}
		}

		private static void ehQJfvZtMCrmSpujpnPgWjhIelRL(IControllerTemplateElement P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(((P_1 >= 0) ? ": " : "") + P_0.descriptiveName + " (id: " + P_0.id + ")", P_2, P_3);
			if (zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Id", P_0.id.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Name", P_0.descriptiveName.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Type", P_0.type.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Exists", P_0.exists.ToString());
				if (P_0.type == ControllerTemplateElementType.Button)
				{
					dHLuPhgkhgIMMxGMfVJhghRYAyhj(P_0 as IControllerTemplateButton, P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Axis)
				{
					kxdXGlfQQjsirXabkzjtjXbTXQZJ(P_0 as IControllerTemplateAxis, P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.DPad)
				{
					IControllerTemplateDPad controllerTemplateDPad = P_0 as IControllerTemplateDPad;
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value", controllerTemplateDPad.value.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value Prev", controllerTemplateDPad.valuePrev.ToString());
					aaZDKuSDltqtrxekyCDYHyUVlGrLA(controllerTemplateDPad.up, "Up", P_2, P_3);
					aaZDKuSDltqtrxekyCDYHyUVlGrLA(controllerTemplateDPad.right, "Right", P_2, P_3);
					aaZDKuSDltqtrxekyCDYHyUVlGrLA(controllerTemplateDPad.down, "Down", P_2, P_3);
					aaZDKuSDltqtrxekyCDYHyUVlGrLA(controllerTemplateDPad.left, "Left", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Hat)
				{
					IControllerTemplateHat controllerTemplateHat = P_0 as IControllerTemplateHat;
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value", controllerTemplateHat.value.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value Prev", controllerTemplateHat.valuePrev.ToString());
					aaZDKuSDltqtrxekyCDYHyUVlGrLA(controllerTemplateHat.up, "up", P_2, P_3);
					aaZDKuSDltqtrxekyCDYHyUVlGrLA(controllerTemplateHat.upRight, "upRight", P_2, P_3);
					aaZDKuSDltqtrxekyCDYHyUVlGrLA(controllerTemplateHat.right, "right", P_2, P_3);
					aaZDKuSDltqtrxekyCDYHyUVlGrLA(controllerTemplateHat.downRight, "downRight", P_2, P_3);
					aaZDKuSDltqtrxekyCDYHyUVlGrLA(controllerTemplateHat.down, "down", P_2, P_3);
					aaZDKuSDltqtrxekyCDYHyUVlGrLA(controllerTemplateHat.downLeft, "downLeft", P_2, P_3);
					aaZDKuSDltqtrxekyCDYHyUVlGrLA(controllerTemplateHat.left, "left", P_2, P_3);
					aaZDKuSDltqtrxekyCDYHyUVlGrLA(controllerTemplateHat.upLeft, "upLeft", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Stick)
				{
					IControllerTemplateStick controllerTemplateStick = P_0 as IControllerTemplateStick;
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value", controllerTemplateStick.value.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value Prev", controllerTemplateStick.valuePrev.ToString());
					hVGcyEoDoJdCqeoAThmWnIeablnAA(controllerTemplateStick.horizontal, "horizontal", P_2, P_3);
					hVGcyEoDoJdCqeoAThmWnIeablnAA(controllerTemplateStick.vertical, "vertical", P_2, P_3);
					hVGcyEoDoJdCqeoAThmWnIeablnAA(controllerTemplateStick.rotation, "rotation", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Throttle)
				{
					IControllerTemplateThrottle controllerTemplateThrottle = P_0 as IControllerTemplateThrottle;
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value", controllerTemplateThrottle.value.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value Prev", controllerTemplateThrottle.valuePrev.ToString());
					hVGcyEoDoJdCqeoAThmWnIeablnAA(controllerTemplateThrottle.throttle, "throttle", P_2, P_3);
					aaZDKuSDltqtrxekyCDYHyUVlGrLA(controllerTemplateThrottle.minDetent, "zeroDetent", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.ThumbStick)
				{
					IControllerTemplateThumbStick controllerTemplateThumbStick = P_0 as IControllerTemplateThumbStick;
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value", controllerTemplateThumbStick.value.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value Prev", controllerTemplateThumbStick.valuePrev.ToString());
					hVGcyEoDoJdCqeoAThmWnIeablnAA(controllerTemplateThumbStick.horizontal, "horizontal", P_2, P_3);
					hVGcyEoDoJdCqeoAThmWnIeablnAA(controllerTemplateThumbStick.vertical, "vertical", P_2, P_3);
					aaZDKuSDltqtrxekyCDYHyUVlGrLA(controllerTemplateThumbStick.press, "press", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Yoke)
				{
					IControllerTemplateYoke controllerTemplateYoke = P_0 as IControllerTemplateYoke;
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value", controllerTemplateYoke.value.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value Prev", controllerTemplateYoke.valuePrev.ToString());
					hVGcyEoDoJdCqeoAThmWnIeablnAA(controllerTemplateYoke.rotation, "rotation", P_2, P_3);
					hVGcyEoDoJdCqeoAThmWnIeablnAA(controllerTemplateYoke.pushPull, "pushPull", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Stick6D)
				{
					IControllerTemplateStick6D controllerTemplateStick6D = P_0 as IControllerTemplateStick6D;
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Position", controllerTemplateStick6D.position.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Position Prev", controllerTemplateStick6D.positionPrev.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Rotation", controllerTemplateStick6D.rotation.ToString());
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Rotation Prev", controllerTemplateStick6D.rotationPrev.ToString());
					hVGcyEoDoJdCqeoAThmWnIeablnAA(controllerTemplateStick6D.positionX, "PositionX", P_2, P_3);
					hVGcyEoDoJdCqeoAThmWnIeablnAA(controllerTemplateStick6D.positionY, "PositionY", P_2, P_3);
					hVGcyEoDoJdCqeoAThmWnIeablnAA(controllerTemplateStick6D.positionZ, "PositionZ", P_2, P_3);
					hVGcyEoDoJdCqeoAThmWnIeablnAA(controllerTemplateStick6D.rotationX, "RotationX", P_2, P_3);
					hVGcyEoDoJdCqeoAThmWnIeablnAA(controllerTemplateStick6D.rotationY, "RotationY", P_2, P_3);
					hVGcyEoDoJdCqeoAThmWnIeablnAA(controllerTemplateStick6D.rotationZ, "RotationZ", P_2, P_3);
				}
				else
				{
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Unknown element type", P_0.type.ToString());
				}
			}
		}

		private static void hVGcyEoDoJdCqeoAThmWnIeablnAA(IControllerTemplateAxis P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				kxdXGlfQQjsirXabkzjtjXbTXQZJ(P_0, P_2, P_3);
			}
		}

		private static void aaZDKuSDltqtrxekyCDYHyUVlGrLA(IControllerTemplateButton P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				dHLuPhgkhgIMMxGMfVJhghRYAyhj(P_0, P_2, P_3);
			}
		}

		private static void kxdXGlfQQjsirXabkzjtjXbTXQZJ(IControllerTemplateAxis P_0, string P_1, IDictionary<string, bool> P_2)
		{
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value", P_0.value.ToString());
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value Prev", P_0.valuePrev.ToString());
			YoyyOCQOPjnODOjjsLOedZjptKsv(P_0.source, "target", P_1, P_2);
		}

		private static void dHLuPhgkhgIMMxGMfVJhghRYAyhj(IControllerTemplateButton P_0, string P_1, IDictionary<string, bool> P_2)
		{
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value", P_0.value.ToString());
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Value Prev", P_0.valuePrev.ToString());
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Pressure", P_0.pressure.ToString());
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Pressure Prev", P_0.pressurePrev.ToString());
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Just Pressed", P_0.justPressed.ToString());
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Just Released", P_0.justReleased.ToString());
			ZGWlCGEIDhcgiGMbQVRkkPvfXDtz(P_0.source, "target", P_1, P_2);
		}

		private static void YoyyOCQOPjnODOjjsLOedZjptKsv(IControllerTemplateAxisSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao("Axis Target", P_2, P_3);
			if (zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Split Axis", P_0.splitAxis.ToString());
				jKuJOYouTLEvkFnBTjwLZuyscLwfA(P_0.fullTarget, "target", P_2, P_3);
				jKuJOYouTLEvkFnBTjwLZuyscLwfA(P_0.positiveTarget, "positiveTarget", P_2, P_3);
				jKuJOYouTLEvkFnBTjwLZuyscLwfA(P_0.negativeTarget, "negativeTarget", P_2, P_3);
			}
		}

		private static void ZGWlCGEIDhcgiGMbQVRkkPvfXDtz(IControllerTemplateButtonSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			jKuJOYouTLEvkFnBTjwLZuyscLwfA(P_0.target, "target", P_2, P_3);
		}

		private static void jKuJOYouTLEvkFnBTjwLZuyscLwfA(IControllerElementTarget P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using ZLdgzeuFGnBHDWzImfaPUbCZCsao zLdgzeuFGnBHDWzImfaPUbCZCsao = new ZLdgzeuFGnBHDWzImfaPUbCZCsao(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (zLdgzeuFGnBHDWzImfaPUbCZCsao.CIkfXThOynxfPEPAAVDnavDieDMRA)
			{
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Element Identifier Id", P_0.elementIdentifierId.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Axis Range", P_0.axisRange.ToString());
				QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Has Target", P_0.hasTarget.ToString());
				if (P_0.hasTarget)
				{
					QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc("Target Element", P_0.descriptiveName);
				}
			}
		}

		private static bool HoIFCocmHJruIqOKadxqgwSMtGthA(string P_0, bool P_1)
		{
			QgsfUjzyZHbNzfZrivDsWRHsbWAw.jdxbLdjHnSJZcAmUDDPWcwIXnVwIc(P_0, P_1.ToString());
			return false;
		}

		private static GUIStyle ANxiniGHZurWVIbYQfVmAEeOFoBg()
		{
			return HhZHYoJDtvrYvcEqNumhjhAKOGoR(new GUIStyle(GUI.skin.label)
			{
				margin = 
				{
					top = 1,
					bottom = 1
				},
				fontSize = JgAPcYCFjKTCDCTBRkvgNeJaaBbL._fontSize
			});
		}

		public static GUIStyle GetToggleStyle()
		{
			GUIStyle gUIStyle = HhZHYoJDtvrYvcEqNumhjhAKOGoR(new GUIStyle(GUI.skin.toggle)
			{
				margin = 
				{
					top = 0,
					bottom = 0
				}
			});
			gUIStyle.fontSize = JgAPcYCFjKTCDCTBRkvgNeJaaBbL._fontSize;
			return gUIStyle;
		}

		private static GUIStyle HhZHYoJDtvrYvcEqNumhjhAKOGoR(GUIStyle P_0)
		{
			P_0 = new GUIStyle(P_0);
			P_0.margin.left = BoewWkXcptfEpfuXzagxlweGyNwQA.HvWRWiFmaIGmTTHrSBNcylgzjLlCA * 20;
			return P_0;
		}
	}
}
