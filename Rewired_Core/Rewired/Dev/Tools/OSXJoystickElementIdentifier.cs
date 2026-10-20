using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class OSXJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool ARhovwSTZiNAgLJvNHUyQOdxxUMg;

		public void Awake()
		{
			if (CLowOHdzeLfYRZnZWDzdHrCnpdnb())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				ARhovwSTZiNAgLJvNHUyQOdxxUMg = WONgWgQUCwUJmKvTejTnbODTMdJK.FDTKfimtkoQZzcaIMSzkhmvPtWqK("Rewired_OSX", "OSX") as IElementIdentifierTool;
				if (ARhovwSTZiNAgLJvNHUyQOdxxUMg == null)
				{
					Logger.LogError("MacOS Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					ARhovwSTZiNAgLJvNHUyQOdxxUMg.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (ARhovwSTZiNAgLJvNHUyQOdxxUMg != null)
			{
				ARhovwSTZiNAgLJvNHUyQOdxxUMg.Start();
			}
		}

		public void Update()
		{
			if (ARhovwSTZiNAgLJvNHUyQOdxxUMg != null)
			{
				ARhovwSTZiNAgLJvNHUyQOdxxUMg.Update();
			}
		}

		public void OnDestroy()
		{
			if (ARhovwSTZiNAgLJvNHUyQOdxxUMg != null)
			{
				ARhovwSTZiNAgLJvNHUyQOdxxUMg.OnDestroy();
			}
			ARhovwSTZiNAgLJvNHUyQOdxxUMg = null;
		}

		private bool CLowOHdzeLfYRZnZWDzdHrCnpdnb()
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
