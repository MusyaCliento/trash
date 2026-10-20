using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class UnityJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool uIrkmMeqDEYUyyloSXrGRycKHtKU;

		public void Awake()
		{
			uIrkmMeqDEYUyyloSXrGRycKHtKU = new FaXaygPpJAdhDKhdLKgIvJmmBCvT();
			uIrkmMeqDEYUyyloSXrGRycKHtKU.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			uIrkmMeqDEYUyyloSXrGRycKHtKU.Start();
		}

		public void Update()
		{
			uIrkmMeqDEYUyyloSXrGRycKHtKU.Update();
		}

		public void OnDestroy()
		{
			uIrkmMeqDEYUyyloSXrGRycKHtKU.OnDestroy();
		}
	}
}
