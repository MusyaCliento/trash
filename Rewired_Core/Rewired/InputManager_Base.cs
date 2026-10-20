using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Rewired.Config;
using Rewired.Data;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired
{
	[AddComponentMenu("")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExecuteInEditMode]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public abstract class InputManager_Base : MonoBehaviour
	{
		private enum mTuLBwbNWTsPeRJpdOYVElpjsQzp
		{
			Initialization = 0,
			Update = 1,
			Destroy = 2
		}

		internal struct GUoeUqIPflOMcxuTTOQzYtRhrIFM
		{
			public Platform QGiJXeIaJmTrNdhSQiTfbyFcRLZH;

			public EditorPlatform ZazFonbKqpDfGigtglooKsbBEUaqC;

			public WebplayerPlatform JPVnoCQmDFbQJcbOyJwErVHZJZfc;
		}

		private sealed class CLumbWHSzytzPJiPzCZeQHOLODph
		{
			public InputManager_Base EqjWixFAWZFpGDruwOionmdFblLqA;

			public UnityTools.uaEpAarlcIaaOoCOqAQxcyWtCvMkA lBYzybgIFtFmCllxEYHyXhixFcQp;

			public string XpqGTNgegChkrUYMdVNjDMLGqsaZ;

			internal void OGEygPIEWbslUbPyBVphvEHAZMiB(GUoeUqIPflOMcxuTTOQzYtRhrIFM P_0)
			{
				EqjWixFAWZFpGDruwOionmdFblLqA.platform = P_0.QGiJXeIaJmTrNdhSQiTfbyFcRLZH;
				EqjWixFAWZFpGDruwOionmdFblLqA.editorPlatform = P_0.ZazFonbKqpDfGigtglooKsbBEUaqC;
				EqjWixFAWZFpGDruwOionmdFblLqA.webplayerPlatform = P_0.JPVnoCQmDFbQJcbOyJwErVHZJZfc;
				lBYzybgIFtFmCllxEYHyXhixFcQp.pKzPdYWRLQIBEDIiWOHMmurkkxFt = P_0.QGiJXeIaJmTrNdhSQiTfbyFcRLZH;
				lBYzybgIFtFmCllxEYHyXhixFcQp.ntRQvjrGkItafLbOeSiLDpItjikDA = P_0.ZazFonbKqpDfGigtglooKsbBEUaqC;
				lBYzybgIFtFmCllxEYHyXhixFcQp.KjaRKLMFuVettClmsdKddNDGRJFtA = P_0.JPVnoCQmDFbQJcbOyJwErVHZJZfc;
				UnityTools.XgYPxiDBjDowbkxvxjBuzTsjHTKh(lBYzybgIFtFmCllxEYHyXhixFcQp);
				XpqGTNgegChkrUYMdVNjDMLGqsaZ = null;
			}

			internal UnityTools.uaEpAarlcIaaOoCOqAQxcyWtCvMkA buAJVPLBTemEiHcBjVJTnNRdCrsL()
			{
				return lBYzybgIFtFmCllxEYHyXhixFcQp;
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _dontDestroyOnLoad = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private UserData _userData = new UserData();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerDataFiles _controllerDataFiles;

		protected bool isCompiling;

		[NonSerialized]
		private bool SodYzhqbgJFctgAyVRfjQBHnhRpGb;

		[NonSerialized]
		private bool mglmoSzifyaHBPWlyaTOeUTYGeBy;

		[NonSerialized]
		protected EditorPlatform editorPlatform;

		[NonSerialized]
		protected Platform platform;

		[NonSerialized]
		protected WebplayerPlatform webplayerPlatform;

		[NonSerialized]
		protected bool isEditor;

		[NonSerialized]
		protected bool _detectedPlatformInEditor;

		[NonSerialized]
		[CustomObfuscation(rename = false)]
		protected ScriptingBackend scriptingBackend = ScriptingBackend.DotNet;

		[NonSerialized]
		[CustomObfuscation(rename = false)]
		protected ScriptingAPILevel scriptingAPILevel;

		[NonSerialized]
		private bool uTMelLPPVLxRPzaSySjGqaQDTRnF;

		private bool BYgeDOfudpGUPalkQLBxePHLwICr;

		public UserData userData
		{
			get
			{
				return _userData;
			}
			internal set
			{
				_userData = value;
			}
		}

		public ControllerDataFiles dataFiles
		{
			get
			{
				return _controllerDataFiles;
			}
			set
			{
				if (ReInput.isReady)
				{
					Logger.LogError("Controller Data Files cannot be set while Rewired is initialized. Disable the GameObject or the Input Manager component before setting this value.");
				}
				else
				{
					_controllerDataFiles = value;
				}
			}
		}

		public bool runInEditMode
		{
			get
			{
				return _userData.ConfigVars.runInEditMode;
			}
			set
			{
				_userData.ConfigVars.runInEditMode = value;
				if (!Application.isPlaying && UnityTools.IsActiveAndEnabled(this) && UnityTools.IsObjectInScene(this))
				{
					if (value)
					{
						TryStartRunInEditMode();
					}
					else
					{
						TryStopRunInEditMode();
					}
				}
			}
		}

		internal bool isRunningInEditMode
		{
			get
			{
				if (ReInput.isRunningInEditMode)
				{
					return ReInput.rewiredInputManager == this;
				}
				return false;
			}
		}

		internal void DontDestroyOnLoad()
		{
			_dontDestroyOnLoad = true;
			if (_dontDestroyOnLoad && Application.isPlaying)
			{
				UnityEngine.Object.DontDestroyOnLoad(base.transform.root.gameObject);
			}
		}

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			BYgeDOfudpGUPalkQLBxePHLwICr = true;
			if ((Application.isPlaying || _userData.ConfigVars.runInEditMode) && base.enabled)
			{
				nnyaFXktCHvKznkedLWZJwAgXDpd();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			if ((Application.isPlaying || _userData.ConfigVars.runInEditMode) && (!Application.isPlaying || BYgeDOfudpGUPalkQLBxePHLwICr) && !SodYzhqbgJFctgAyVRfjQBHnhRpGb && !mglmoSzifyaHBPWlyaTOeUTYGeBy)
			{
				KjCTIImiOLHdjTIQyvbmwisatOVg();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			if (Application.isPlaying || _userData.ConfigVars.runInEditMode)
			{
				YxngebGRoIbUVkPaSVzvBrRmYjzS(true);
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnDestroy()
		{
			YxngebGRoIbUVkPaSVzvBrRmYjzS(false);
		}

		private void YxngebGRoIbUVkPaSVzvBrRmYjzS(bool P_0)
		{
			SodYzhqbgJFctgAyVRfjQBHnhRpGb = false;
			uTMelLPPVLxRPzaSySjGqaQDTRnF = false;
			mglmoSzifyaHBPWlyaTOeUTYGeBy = false;
			try
			{
				if (ReInput.rewiredInputManager == this)
				{
					ReInput.DCxEPMMgTUavrCziFGFVnfQfapJZA();
				}
			}
			catch (Exception ex)
			{
				GymJufzeXOSEfvsPnkFNeqLYXTZD(mTuLBwbNWTsPeRJpdOYVElpjsQzp.Destroy, "destruction", ex);
			}
			OnDeinitialized();
		}

		[CustomObfuscation(rename = false)]
		private void OnApplicationFocus(bool isFocused)
		{
			if (!uTMelLPPVLxRPzaSySjGqaQDTRnF)
			{
				ReInput.IkhMwhbHIwuFjckVTaxeAiKIHkDiA(isFocused);
				_ = SodYzhqbgJFctgAyVRfjQBHnhRpGb;
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnApplicationPause(bool isPaused)
		{
			if (!uTMelLPPVLxRPzaSySjGqaQDTRnF)
			{
				ReInput.eTuJPSwhbfqczVLoraZLaOKEECwq(isPaused);
				_ = SodYzhqbgJFctgAyVRfjQBHnhRpGb;
			}
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
			if ((!UnityTools.isEditor || Application.isPlaying) && SodYzhqbgJFctgAyVRfjQBHnhRpGb && !mglmoSzifyaHBPWlyaTOeUTYGeBy)
			{
				ReInput.vXAwdNhgZrEYFjxqUIsOHJXjndVP();
			}
		}

		[CustomObfuscation(rename = false)]
		private void Update()
		{
			if (SodYzhqbgJFctgAyVRfjQBHnhRpGb && !mglmoSzifyaHBPWlyaTOeUTYGeBy && (!UnityTools.isEditor || Application.isPlaying) && _userData.ConfigVars.updateMode != UpdateMode.Manual)
			{
				DoUpdate(UpdateLoopType.Update, UpdateLoopSetting.Update);
			}
		}

		[CustomObfuscation(rename = false)]
		private void FixedUpdate()
		{
			if (SodYzhqbgJFctgAyVRfjQBHnhRpGb && !mglmoSzifyaHBPWlyaTOeUTYGeBy && (!UnityTools.isEditor || Application.isPlaying) && _userData.ConfigVars.updateMode != UpdateMode.Manual)
			{
				DoUpdate(UpdateLoopType.FixedUpdate, UpdateLoopSetting.FixedUpdate);
			}
		}

		[CustomObfuscation(rename = false)]
		private void LateUpdate()
		{
			if (!SodYzhqbgJFctgAyVRfjQBHnhRpGb || mglmoSzifyaHBPWlyaTOeUTYGeBy || (UnityTools.isEditor && !Application.isPlaying))
			{
				return;
			}
			try
			{
				ReInput.zOUjLvyJozHLMdVUGDmszNGYRVPw();
			}
			catch (Exception ex)
			{
				GymJufzeXOSEfvsPnkFNeqLYXTZD(mTuLBwbNWTsPeRJpdOYVElpjsQzp.Update, "update (Late Update)", ex);
			}
		}

		internal void OnGUIUpdate()
		{
			if (SodYzhqbgJFctgAyVRfjQBHnhRpGb && !mglmoSzifyaHBPWlyaTOeUTYGeBy && (!UnityTools.isEditor || Application.isPlaying) && _userData.ConfigVars.updateMode != UpdateMode.Manual && (_userData.ConfigVars.updateLoop & UpdateLoopSetting.OnGUI) != UpdateLoopSetting.None)
			{
				DoUpdate(UpdateLoopType.OnGUI, UpdateLoopSetting.OnGUI);
			}
		}

		internal void DoUpdate(UpdateLoopType updateLoopType, UpdateLoopSetting updateLoopSettingBit)
		{
			if (!SodYzhqbgJFctgAyVRfjQBHnhRpGb || mglmoSzifyaHBPWlyaTOeUTYGeBy)
			{
				return;
			}
			try
			{
				CheckRecompile();
				ReInput.TGaMaXhFzXnhKLXmShCFDcpXihBbA(updateLoopType);
				if ((_userData.ConfigVars.updateLoop & updateLoopSettingBit) != UpdateLoopSetting.None)
				{
					ReInput.DGRDRJLckHHoiCnlaFiEZUUSZwuZ(updateLoopType);
				}
			}
			catch (Exception ex)
			{
				GymJufzeXOSEfvsPnkFNeqLYXTZD(mTuLBwbNWTsPeRJpdOYVElpjsQzp.Update, "update (" + updateLoopType.ToString() + ")", ex);
			}
		}

		internal void TryStartRunInEditMode()
		{
			if (SodYzhqbgJFctgAyVRfjQBHnhRpGb || !Application.isEditor || Application.isPlaying)
			{
				return;
			}
			if (ReInput.isReady)
			{
				Logger.LogWarning("Rewired is already running in Edit mode. Do you have multiple Rewired Input Managers in the scene? If you want to run this Rewired Input Manager, you must stop the one currently running first.");
				return;
			}
			if (_userData.ConfigVars.alwaysUseUnityInput)
			{
				Logger.LogWarning("Rewired cannot run in Edit mode when native input is disabled.");
				return;
			}
			if (!IsEditModeSupported())
			{
				Logger.LogWarning("Rewired cannot run in Edit mode on this editor platform with the current settings.");
				return;
			}
			string text = null;
			GetSupportedEditModeControllerTypes(out var keyboardSupported, out var mouseSupported, out var joystickSupported);
			if (!keyboardSupported)
			{
				if (!string.IsNullOrEmpty(text))
				{
					text += ", ";
				}
				text += "Keyboard";
			}
			if (!mouseSupported)
			{
				if (!string.IsNullOrEmpty(text))
				{
					text += ", ";
				}
				text += "Mouse";
			}
			if (!joystickSupported)
			{
				if (!string.IsNullOrEmpty(text))
				{
					text += ", ";
				}
				text += "Joystick";
			}
			if (!string.IsNullOrEmpty(text))
			{
				Logger.LogWarning("The current editor platform and/or input source settings do not support the following input devices in Edit mode:\n" + text);
			}
			uTMelLPPVLxRPzaSySjGqaQDTRnF = false;
			KjCTIImiOLHdjTIQyvbmwisatOVg();
		}

		internal void TryStopRunInEditMode()
		{
			if (Application.isEditor && !Application.isPlaying && ReInput.isReady)
			{
				YxngebGRoIbUVkPaSVzvBrRmYjzS(false);
			}
		}

		private bool KjCTIImiOLHdjTIQyvbmwisatOVg()
		{
			if (SodYzhqbgJFctgAyVRfjQBHnhRpGb)
			{
				return true;
			}
			nnyaFXktCHvKznkedLWZJwAgXDpd();
			if (SodYzhqbgJFctgAyVRfjQBHnhRpGb)
			{
				ReInput.vXAwdNhgZrEYFjxqUIsOHJXjndVP();
			}
			return SodYzhqbgJFctgAyVRfjQBHnhRpGb;
		}

		private void nnyaFXktCHvKznkedLWZJwAgXDpd()
		{
			CLumbWHSzytzPJiPzCZeQHOLODph cLumbWHSzytzPJiPzCZeQHOLODph = new CLumbWHSzytzPJiPzCZeQHOLODph();
			cLumbWHSzytzPJiPzCZeQHOLODph.EqjWixFAWZFpGDruwOionmdFblLqA = this;
			if (uTMelLPPVLxRPzaSySjGqaQDTRnF)
			{
				return;
			}
			try
			{
				if (!ViNgdXsvixTHnMFIDByVakkMHbkib())
				{
					return;
				}
				if (_dontDestroyOnLoad && Application.isPlaying)
				{
					UnityEngine.Object.DontDestroyOnLoad(base.transform.root.gameObject);
				}
				DetectPlatform();
				if (_userData == null || _userData.ConfigVars == null || _controllerDataFiles == null)
				{
					Logger.LogError("Error! DataFiles is missing or corrupt! Make sure you have the DataFiles file linked in the inspector.");
					return;
				}
				if ((_userData.ConfigVars.updateLoop & UpdateLoopSetting.Update) == 0)
				{
					userData.ConfigVars.updateLoop |= UpdateLoopSetting.Update;
				}
				if (_userData.ConfigVars.updateMode == UpdateMode.Manual)
				{
					userData.ConfigVars.updateLoop = UpdateLoopSetting.Update;
				}
				if ((_userData.ConfigVars.updateLoop & UpdateLoopSetting.OnGUI) == UpdateLoopSetting.OnGUI && base.gameObject.GetComponent<OnGUIHelper>() == null)
				{
					OnGUIHelper onGUIHelper = base.gameObject.AddComponent<OnGUIHelper>();
					onGUIHelper.hideFlags = HideFlags.HideAndDontSave;
					onGUIHelper.hideFlags |= HideFlags.HideInInspector;
				}
				Platform platform = this.platform;
				cLumbWHSzytzPJiPzCZeQHOLODph.XpqGTNgegChkrUYMdVNjDMLGqsaZ = mTVBMPJSkGYFihoGsvChKKVBZTKL();
				cLumbWHSzytzPJiPzCZeQHOLODph.lBYzybgIFtFmCllxEYHyXhixFcQp = new UnityTools.uaEpAarlcIaaOoCOqAQxcyWtCvMkA(platform, this.platform, editorPlatform, isEditor, webplayerPlatform, scriptingBackend, scriptingAPILevel, GetExternalTools());
				Action<GUoeUqIPflOMcxuTTOQzYtRhrIFM> action = cLumbWHSzytzPJiPzCZeQHOLODph.OGEygPIEWbslUbPyBVphvEHAZMiB;
				UnityTools.XgYPxiDBjDowbkxvxjBuzTsjHTKh(cLumbWHSzytzPJiPzCZeQHOLODph.lBYzybgIFtFmCllxEYHyXhixFcQp);
				ReInput.zBnIqvHAhplzNGiaaStZTPeYRaIr(this, MtsBJCkptaCAlGPLgEcSYLdCRyPX, _userData.ConfigVars, _controllerDataFiles, _userData, cLumbWHSzytzPJiPzCZeQHOLODph.buAJVPLBTemEiHcBjVJTnNRdCrsL, bgawmLCmiSZPLIeghdkDFjqEOKsu, action);
				SodYzhqbgJFctgAyVRfjQBHnhRpGb = true;
				mglmoSzifyaHBPWlyaTOeUTYGeBy = false;
				if (!string.IsNullOrEmpty(cLumbWHSzytzPJiPzCZeQHOLODph.XpqGTNgegChkrUYMdVNjDMLGqsaZ))
				{
					Logger.LogWarning(cLumbWHSzytzPJiPzCZeQHOLODph.XpqGTNgegChkrUYMdVNjDMLGqsaZ);
				}
				OnInitialized();
			}
			catch (Exception ex)
			{
				GymJufzeXOSEfvsPnkFNeqLYXTZD(mTuLBwbNWTsPeRJpdOYVElpjsQzp.Initialization, "initialization", ex);
			}
		}

		private void bgawmLCmiSZPLIeghdkDFjqEOKsu(Platform P_0)
		{
			platform = P_0;
		}

		private object MtsBJCkptaCAlGPLgEcSYLdCRyPX(ConfigVars P_0)
		{
			List<Assembly> list = null;
			return WONgWgQUCwUJmKvTejTnbODTMdJK.DmEbKMkljisZGCmuTbBruRqBtICC(XBQFnFBjkEeyIvaqldJPcKLJjVwaA(), list, P_0);
		}

		private string mTVBMPJSkGYFihoGsvChKKVBZTKL()
		{
			if (editorPlatform == EditorPlatform.None)
			{
				return null;
			}
			if (OdamTpGLOhEQlPzPkLNwznKuNoEm())
			{
				return null;
			}
			string result = string.Format("The current build target is set to {0}. Controller capabilities in the Unity editor may not accurately reflect those in a {0} build.", platform.ToString());
			switch (editorPlatform)
			{
			case EditorPlatform.Windows:
				platform = Platform.Windows;
				break;
			case EditorPlatform.OSX:
				platform = Platform.OSX;
				break;
			case EditorPlatform.Linux:
				platform = Platform.Linux;
				break;
			default:
				result = "Unsupported Unity editor platform detected. Input is not guarateed to function in the editor.";
				break;
			}
			return result;
		}

		private bool OdamTpGLOhEQlPzPkLNwznKuNoEm()
		{
			switch (editorPlatform)
			{
			case EditorPlatform.Windows:
				if (platform == Platform.Windows)
				{
					return true;
				}
				break;
			case EditorPlatform.OSX:
				if (platform == Platform.OSX)
				{
					return true;
				}
				break;
			case EditorPlatform.Linux:
				if (platform == Platform.Linux)
				{
					return true;
				}
				break;
			}
			return false;
		}

		private string XBQFnFBjkEeyIvaqldJPcKLJjVwaA()
		{
			if (!ReInput.isEditor && ReInput.webplayerPlatform != WebplayerPlatform.None)
			{
				return string.Empty;
			}
			return ReInput.currentPlatform switch
			{
				Platform.Windows => "Rewired_Windows", 
				Platform.OSX => "Rewired_OSX", 
				Platform.Linux => "Rewired_Linux", 
				_ => string.Empty, 
			};
		}

		private bool ViNgdXsvixTHnMFIDByVakkMHbkib()
		{
			uTMelLPPVLxRPzaSySjGqaQDTRnF = false;
			if (ReInput.isReady)
			{
				if (Application.isPlaying)
				{
					if (Application.isEditor)
					{
						Logger.LogWarning("Only one Rewired Input Manager may exist in a scene. This additional Rewired Input Manager game object will be deleted. You may see this warning if you are loading a new level that contains a Rewired Input Manager. If that's the case, you can safely ignore this warning. This warning will never be logged in a build.");
					}
					UnityEngine.Object.Destroy(base.gameObject);
					return false;
				}
				uTMelLPPVLxRPzaSySjGqaQDTRnF = true;
				Logger.LogWarning("Only one Rewired Input Manager may exist in a scene.");
				return false;
			}
			return true;
		}

		protected void RecompileStart()
		{
			ReInput.nZEPMkmAENvYaCTRoLMVMYEgFPom();
			ReInput.DCxEPMMgTUavrCziFGFVnfQfapJZA();
		}

		protected void RecompileEnd()
		{
			if (!Application.isPlaying)
			{
				_ = userData.ConfigVars.runInEditMode;
			}
		}

		protected void OnSceneLoaded()
		{
			if (ReInput.isReady)
			{
				ReInput.nTQfRHaFtlMkQHevHFksJHmFnpRtc();
			}
		}

		private void GymJufzeXOSEfvsPnkFNeqLYXTZD(mTuLBwbNWTsPeRJpdOYVElpjsQzp P_0, string P_1, Exception P_2)
		{
			P_1 = "An exception occurred during " + P_1 + ".";
			bool flag = false;
			if (P_0 == mTuLBwbNWTsPeRJpdOYVElpjsQzp.Initialization || P_0 == mTuLBwbNWTsPeRJpdOYVElpjsQzp.Destroy)
			{
				P_1 += " Input will not function.";
				flag = true;
			}
			else
			{
				P_1 += " Rewired will attempt to continue running.";
			}
			Logger.LogException((P_2.InnerException != null) ? P_2.InnerException : P_2, P_1 + "\n\nException:\n" + ((P_2.InnerException != null) ? P_2.InnerException : P_2));
			if (flag)
			{
				mglmoSzifyaHBPWlyaTOeUTYGeBy = true;
			}
		}

		[CustomObfuscation(rename = false)]
		internal void ResetAll()
		{
			YxngebGRoIbUVkPaSVzvBrRmYjzS(false);
			KjCTIImiOLHdjTIQyvbmwisatOVg();
		}

		[CustomObfuscation(rename = false)]
		internal EditorPlatform GetEditorPlatform()
		{
			if (!SodYzhqbgJFctgAyVRfjQBHnhRpGb && !_detectedPlatformInEditor)
			{
				DetectPlatform();
			}
			_detectedPlatformInEditor = true;
			return editorPlatform;
		}

		[CustomObfuscation(rename = false)]
		internal void GetSupportedEditModeControllerTypes(out bool keyboardSupported, out bool mouseSupported, out bool joystickSupported)
		{
			keyboardSupported = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Keyboard, editorPlatform);
			mouseSupported = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Mouse, editorPlatform);
			joystickSupported = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Joystick, editorPlatform);
		}

		[CustomObfuscation(rename = false)]
		internal bool IsEditModeSupported()
		{
			if (editorPlatform == EditorPlatform.None)
			{
				GetEditorPlatform();
			}
			bool num = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Keyboard, editorPlatform);
			bool flag = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Mouse, editorPlatform);
			bool flag2 = _userData.ConfigVars.IsEditModeInputSupported(ControllerType.Joystick, editorPlatform);
			return num || flag || flag2;
		}

		protected abstract void OnInitialized();

		protected abstract void OnDeinitialized();

		protected abstract void DetectPlatform();

		protected abstract void CheckRecompile();

		protected abstract IExternalTools GetExternalTools();
	}
}
