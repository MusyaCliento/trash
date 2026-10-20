using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class RawInputJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool KkoNDAEIPajOYNIarMWAsnnfjBfL;

		public void Awake()
		{
			if (UlsrIsGBEWgtDcKGflnAKyubzReC())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				KkoNDAEIPajOYNIarMWAsnnfjBfL = WONgWgQUCwUJmKvTejTnbODTMdJK.FDTKfimtkoQZzcaIMSzkhmvPtWqK("Rewired_Windows", "RawInput") as IElementIdentifierTool;
				if (KkoNDAEIPajOYNIarMWAsnnfjBfL == null)
				{
					Logger.LogError("RawInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					KkoNDAEIPajOYNIarMWAsnnfjBfL.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (KkoNDAEIPajOYNIarMWAsnnfjBfL != null)
			{
				KkoNDAEIPajOYNIarMWAsnnfjBfL.Start();
			}
		}

		public void Update()
		{
			if (KkoNDAEIPajOYNIarMWAsnnfjBfL != null)
			{
				KkoNDAEIPajOYNIarMWAsnnfjBfL.Update();
			}
		}

		public void OnDestroy()
		{
			if (KkoNDAEIPajOYNIarMWAsnnfjBfL != null)
			{
				KkoNDAEIPajOYNIarMWAsnnfjBfL.OnDestroy();
			}
			KkoNDAEIPajOYNIarMWAsnnfjBfL = null;
		}

		private bool UlsrIsGBEWgtDcKGflnAKyubzReC()
		{
			InputManager_Base[] array = UnityTools.FindObjectsOfType<InputManager_Base>();
			if (array == null || array.Length == 0)
			{
				Logger.LogError("No active Rewired Input Manager was found in the scene! You must create a Rewired Input Manager for the tool to function.");
				return false;
			}
			return true;
		}
	}
}
