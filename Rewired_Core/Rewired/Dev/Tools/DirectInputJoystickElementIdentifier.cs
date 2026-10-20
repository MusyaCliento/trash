using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class DirectInputJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool KTYCgluKrISOWlXySJIivdoymrVl;

		public void Awake()
		{
			if (MYONAhdjhxgJKBzyPNBLRXruHSzm())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				KTYCgluKrISOWlXySJIivdoymrVl = WONgWgQUCwUJmKvTejTnbODTMdJK.FDTKfimtkoQZzcaIMSzkhmvPtWqK("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
				if (KTYCgluKrISOWlXySJIivdoymrVl == null)
				{
					Logger.LogError("DirectInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					KTYCgluKrISOWlXySJIivdoymrVl.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (KTYCgluKrISOWlXySJIivdoymrVl != null)
			{
				KTYCgluKrISOWlXySJIivdoymrVl.Start();
			}
		}

		public void Update()
		{
			if (KTYCgluKrISOWlXySJIivdoymrVl != null)
			{
				KTYCgluKrISOWlXySJIivdoymrVl.Update();
			}
		}

		public void OnDestroy()
		{
			if (KTYCgluKrISOWlXySJIivdoymrVl != null)
			{
				KTYCgluKrISOWlXySJIivdoymrVl.OnDestroy();
			}
			KTYCgluKrISOWlXySJIivdoymrVl = null;
		}

		private bool MYONAhdjhxgJKBzyPNBLRXruHSzm()
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
