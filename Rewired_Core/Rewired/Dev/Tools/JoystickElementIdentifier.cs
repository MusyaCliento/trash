using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class JoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool rgrvHnCqPWuLDaKLOskpZUXxLFDM;

		public void Awake()
		{
			if (!FIHnCDsPhLXtBOMqlCHWfmWdWJcHA())
			{
				return;
			}
			if (base.transform.position != Vector3.zero)
			{
				base.transform.position = Vector3.zero;
			}
			if (ReInput.UserData.ConfigVars.alwaysUseUnityInput || ReInput.usingUnityInput)
			{
				InputSource inputSourceType = ReInput.primaryInputManager.inputSourceType;
				if (inputSourceType == InputSource.Fallback || inputSourceType == InputSource.Fallback_PreConfigured)
				{
					rgrvHnCqPWuLDaKLOskpZUXxLFDM = new FaXaygPpJAdhDKhdLKgIvJmmBCvT();
				}
				else
				{
					GlobalObjectProvider.TryGetObject<IElementIdentifierTool>("createElementIdentifierTool", (int)ReInput.primaryInputManager.inputSourceType, ReInput.primaryInputManager.inputSource, out rgrvHnCqPWuLDaKLOskpZUXxLFDM);
				}
			}
			else
			{
				Platform platform = UnityTools.platform;
				if (UnityTools.isEditor)
				{
					switch (UnityTools.editorPlatform)
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
					}
				}
				InputSource inputSourceType = ReInput.primaryInputManager.inputSourceType;
				if (inputSourceType == InputSource.Fallback || inputSourceType == InputSource.Fallback_PreConfigured)
				{
					rgrvHnCqPWuLDaKLOskpZUXxLFDM = new FaXaygPpJAdhDKhdLKgIvJmmBCvT();
				}
				else
				{
					GlobalObjectProvider.TryGetObject<IElementIdentifierTool>("createElementIdentifierTool", (int)ReInput.primaryInputManager.inputSourceType, ReInput.primaryInputManager.inputSource, out rgrvHnCqPWuLDaKLOskpZUXxLFDM);
				}
				if (rgrvHnCqPWuLDaKLOskpZUXxLFDM == null)
				{
					switch (platform)
					{
					case Platform.Windows:
						switch (ReInput.primaryInputManager.inputSourceType)
						{
						case InputSource.DirectInput:
							rgrvHnCqPWuLDaKLOskpZUXxLFDM = WONgWgQUCwUJmKvTejTnbODTMdJK.FDTKfimtkoQZzcaIMSzkhmvPtWqK("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
							break;
						case InputSource.RawInput:
							rgrvHnCqPWuLDaKLOskpZUXxLFDM = WONgWgQUCwUJmKvTejTnbODTMdJK.FDTKfimtkoQZzcaIMSzkhmvPtWqK("Rewired_Windows", "RawInput") as IElementIdentifierTool;
							break;
						case InputSource.SDL2:
							rgrvHnCqPWuLDaKLOskpZUXxLFDM = WONgWgQUCwUJmKvTejTnbODTMdJK.FDTKfimtkoQZzcaIMSzkhmvPtWqK("Rewired_Windows", "SDL2") as IElementIdentifierTool;
							break;
						case InputSource.SDL3:
							rgrvHnCqPWuLDaKLOskpZUXxLFDM = WONgWgQUCwUJmKvTejTnbODTMdJK.FDTKfimtkoQZzcaIMSzkhmvPtWqK("Rewired_Windows", "SDL3") as IElementIdentifierTool;
							break;
						}
						break;
					case Platform.WindowsAppStore:
						rgrvHnCqPWuLDaKLOskpZUXxLFDM = new FaXaygPpJAdhDKhdLKgIvJmmBCvT();
						break;
					case Platform.WindowsUWP:
						rgrvHnCqPWuLDaKLOskpZUXxLFDM = WONgWgQUCwUJmKvTejTnbODTMdJK.FDTKfimtkoQZzcaIMSzkhmvPtWqK("", "WindowsUWP") as IElementIdentifierTool;
						break;
					case Platform.OSX:
						switch (ReInput.primaryInputManager.inputSourceType)
						{
						case InputSource.OSX:
							rgrvHnCqPWuLDaKLOskpZUXxLFDM = WONgWgQUCwUJmKvTejTnbODTMdJK.FDTKfimtkoQZzcaIMSzkhmvPtWqK("Rewired_OSX", "OSX") as IElementIdentifierTool;
							break;
						case InputSource.SDL2:
							rgrvHnCqPWuLDaKLOskpZUXxLFDM = WONgWgQUCwUJmKvTejTnbODTMdJK.FDTKfimtkoQZzcaIMSzkhmvPtWqK("Rewired_OSX", "SDL2") as IElementIdentifierTool;
							break;
						case InputSource.SDL3:
							rgrvHnCqPWuLDaKLOskpZUXxLFDM = WONgWgQUCwUJmKvTejTnbODTMdJK.FDTKfimtkoQZzcaIMSzkhmvPtWqK("Rewired_OSX", "SDL3") as IElementIdentifierTool;
							break;
						case InputSource.AppleGameController:
							rgrvHnCqPWuLDaKLOskpZUXxLFDM = WONgWgQUCwUJmKvTejTnbODTMdJK.FDTKfimtkoQZzcaIMSzkhmvPtWqK("Rewired_OSX", "AppleGameController") as IElementIdentifierTool;
							break;
						}
						break;
					case Platform.Linux:
						switch (ReInput.primaryInputManager.inputSourceType)
						{
						case InputSource.Linux:
							rgrvHnCqPWuLDaKLOskpZUXxLFDM = WONgWgQUCwUJmKvTejTnbODTMdJK.FDTKfimtkoQZzcaIMSzkhmvPtWqK("Rewired_Linux", "Linux") as IElementIdentifierTool;
							break;
						case InputSource.SDL2:
							rgrvHnCqPWuLDaKLOskpZUXxLFDM = WONgWgQUCwUJmKvTejTnbODTMdJK.FDTKfimtkoQZzcaIMSzkhmvPtWqK("Rewired_Linux", "SDL2") as IElementIdentifierTool;
							break;
						case InputSource.SDL3:
							rgrvHnCqPWuLDaKLOskpZUXxLFDM = WONgWgQUCwUJmKvTejTnbODTMdJK.FDTKfimtkoQZzcaIMSzkhmvPtWqK("Rewired_Linux", "SDL3") as IElementIdentifierTool;
							break;
						}
						break;
					case Platform.WebGL:
						rgrvHnCqPWuLDaKLOskpZUXxLFDM = WONgWgQUCwUJmKvTejTnbODTMdJK.FDTKfimtkoQZzcaIMSzkhmvPtWqK("Rewired_WebGL", "WebGL") as IElementIdentifierTool;
						break;
					case Platform.GameCoreXboxOne:
					case Platform.GameCoreScarlett:
						rgrvHnCqPWuLDaKLOskpZUXxLFDM = WONgWgQUCwUJmKvTejTnbODTMdJK.FDTKfimtkoQZzcaIMSzkhmvPtWqK("Rewired_GameCore", "GameCore") as IElementIdentifierTool;
						break;
					case Platform.iOS:
						if (ReInput.primaryInputManager.inputSourceType == InputSource.AppleGameController)
						{
							rgrvHnCqPWuLDaKLOskpZUXxLFDM = WONgWgQUCwUJmKvTejTnbODTMdJK.FDTKfimtkoQZzcaIMSzkhmvPtWqK("Rewired_iOS", "AppleGameController") as IElementIdentifierTool;
						}
						break;
					case Platform.tvOS:
						if (ReInput.primaryInputManager.inputSourceType == InputSource.AppleGameController)
						{
							rgrvHnCqPWuLDaKLOskpZUXxLFDM = WONgWgQUCwUJmKvTejTnbODTMdJK.FDTKfimtkoQZzcaIMSzkhmvPtWqK("Rewired_tvOS", "AppleGameController") as IElementIdentifierTool;
						}
						break;
					}
				}
			}
			if (rgrvHnCqPWuLDaKLOskpZUXxLFDM == null && UnityTools.isAndroidPlatform)
			{
				switch (ReInput.primaryInputManager.inputSourceType)
				{
				case InputSource.SDL2:
					rgrvHnCqPWuLDaKLOskpZUXxLFDM = WONgWgQUCwUJmKvTejTnbODTMdJK.FDTKfimtkoQZzcaIMSzkhmvPtWqK("Rewired_Android", "SDL2") as IElementIdentifierTool;
					break;
				case InputSource.SDL3:
					rgrvHnCqPWuLDaKLOskpZUXxLFDM = WONgWgQUCwUJmKvTejTnbODTMdJK.FDTKfimtkoQZzcaIMSzkhmvPtWqK("Rewired_Android", "SDL3") as IElementIdentifierTool;
					break;
				}
			}
			if (rgrvHnCqPWuLDaKLOskpZUXxLFDM == null)
			{
				Logger.LogWarning("There was an error initializing the platform tool for the current platform and input source. Unity input will be shown instead.");
				rgrvHnCqPWuLDaKLOskpZUXxLFDM = new FaXaygPpJAdhDKhdLKgIvJmmBCvT();
			}
			rgrvHnCqPWuLDaKLOskpZUXxLFDM.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			if (rgrvHnCqPWuLDaKLOskpZUXxLFDM != null)
			{
				rgrvHnCqPWuLDaKLOskpZUXxLFDM.Start();
			}
		}

		public void Update()
		{
			if (rgrvHnCqPWuLDaKLOskpZUXxLFDM != null)
			{
				rgrvHnCqPWuLDaKLOskpZUXxLFDM.Update();
			}
		}

		public void OnDestroy()
		{
			if (rgrvHnCqPWuLDaKLOskpZUXxLFDM != null)
			{
				rgrvHnCqPWuLDaKLOskpZUXxLFDM.OnDestroy();
			}
			rgrvHnCqPWuLDaKLOskpZUXxLFDM = null;
		}

		private bool FIHnCDsPhLXtBOMqlCHWfmWdWJcHA()
		{
			if (!ReInput.isReady)
			{
				Logger.LogError("No active Rewired Input Manager was found in the scene! You must create a Rewired Input Manager for the tool to function.");
				return false;
			}
			return true;
		}
	}
}
