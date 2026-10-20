using System;
using Rewired.Data.Mapping;
using Rewired.Interfaces;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class UnityUnifiedKeyboardSource : IUnifiedKeyboardSource, IGetSetEnabled, IDisposable
	{
		private const int uYbpHiAoLfnYXKqphKyrUbEeFKcbA = 132;

		private static HardwareControllerMap_Game jDXKshrBBiaDpYXUJuWaceensCGN;

		private bool UKvGUqaxAoocHIoQCDbuUhOyShSbA;

		private readonly string[] KDLNxABjUSSgiZQxfKvfsJESjprT;

		private readonly string[] nuPqCxVgkyEOlbggedBtFwZeBbmub;

		private readonly string[] ZtKdUWLUjiIQFpiRuWQGJYbTOKWW;

		private bool UDZVFPoYykrdTwgQTxBFCfDyIMyz;

		bool IGetSetEnabled.enabled
		{
			get
			{
				return UKvGUqaxAoocHIoQCDbuUhOyShSbA;
			}
			set
			{
				if (UKvGUqaxAoocHIoQCDbuUhOyShSbA != value)
				{
					UKvGUqaxAoocHIoQCDbuUhOyShSbA = value;
					Clear();
					ThreadSafeUnityInput.keyboard.Monitor(value);
				}
			}
		}

		InputSource IUnifiedKeyboardSource.inputSource => InputSource.UnityKeyboardAndMouse;

		HardwareControllerMap_Game IUnifiedKeyboardSource.hardwareMap
		{
			get
			{
				if (jDXKshrBBiaDpYXUJuWaceensCGN == null)
				{
					jDXKshrBBiaDpYXUJuWaceensCGN = CreateHardwareMap();
				}
				return jDXKshrBBiaDpYXUJuWaceensCGN;
			}
		}

		int IUnifiedKeyboardSource.buttonCount => 132;

		Controller.Extension IUnifiedKeyboardSource.controllerExtension => null;

		public UnityUnifiedKeyboardSource()
		{
			KDLNxABjUSSgiZQxfKvfsJESjprT = new string[132];
			nuPqCxVgkyEOlbggedBtFwZeBbmub = new string[Consts.keyboardModifierKeys.Count];
			ZtKdUWLUjiIQFpiRuWQGJYbTOKWW = new string[Consts.keyboardModifierKeys.Count];
			Rewired_002EInterfaces_002EIGetSetEnabled_002Eenabled = true;
			ThreadSafeUnityInput.keyboard.KeyboardLayoutChangedEvent += PWYlZCPKcJXVZchJfDEKTzktHhhX;
		}

		public void UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			if (UKvGUqaxAoocHIoQCDbuUhOyShSbA)
			{
				ThreadSafeUnityInput.keyboard.GetThreadFrameKeyValues(dataUpdater.buttonValues);
			}
		}

		void IUnifiedKeyboardSource.UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UpdateInputData
			this.UpdateInputData(dataUpdater);
		}

		public void Clear()
		{
		}

		void IUnifiedKeyboardSource.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Clear
			this.Clear();
		}

		internal static HardwareControllerMap_Game CreateHardwareMap()
		{
			ControllerElementIdentifier[] array = new ControllerElementIdentifier[132];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new ControllerElementIdentifier(i, Consts.keyboardKeyNames[i], Consts.keyboardKeyNames[i], string.Empty, ControllerElementType.Button, true);
			}
			int[] array2 = new int[132];
			for (int j = 0; j < 132; j++)
			{
				array2[j] = array[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid;
			}
			HardwareButtonInfo[] array3 = new HardwareButtonInfo[132];
			for (int k = 0; k < 132; k++)
			{
				array3[k] = new HardwareButtonInfo();
			}
			return new HardwareControllerMap_Game("Keyboard", default(HardwareControllerMapIdentifier), array, array2, new int[0], new AxisCalibrationData[0], new AxisRange[0], new HardwareAxisInfo[0], array3, null);
		}

		private void PWYlZCPKcJXVZchJfDEKTzktHhhX()
		{
			if (ThreadSafeUnityInput.keyboard.GetKeyLabels(KDLNxABjUSSgiZQxfKvfsJESjprT, nuPqCxVgkyEOlbggedBtFwZeBbmub, ZtKdUWLUjiIQFpiRuWQGJYbTOKWW))
			{
				Keyboard keyboard = ReInput.controllers.Keyboard;
				for (int i = 0; i < 132; i++)
				{
					Keyboard.SetKeyName(keyboard.GetKeyCodeByButtonIndex(i), KDLNxABjUSSgiZQxfKvfsJESjprT[i]);
				}
				for (int j = 0; j < Consts.keyboardModifierKeys.Count; j++)
				{
					Keyboard.SetModifierKeyName(Consts.keyboardModifierKeys[j], nuPqCxVgkyEOlbggedBtFwZeBbmub[j], ZtKdUWLUjiIQFpiRuWQGJYbTOKWW[j]);
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~UnityUnifiedKeyboardSource()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (UDZVFPoYykrdTwgQTxBFCfDyIMyz)
			{
				return;
			}
			if (disposing)
			{
				if (UKvGUqaxAoocHIoQCDbuUhOyShSbA)
				{
					ThreadSafeUnityInput.keyboard.Monitor(state: false);
				}
				ThreadSafeUnityInput.keyboard.KeyboardLayoutChangedEvent -= PWYlZCPKcJXVZchJfDEKTzktHhhX;
			}
			UDZVFPoYykrdTwgQTxBFCfDyIMyz = true;
		}

		public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
		{
			if (jDXKshrBBiaDpYXUJuWaceensCGN == null)
			{
				jDXKshrBBiaDpYXUJuWaceensCGN = CreateHardwareMap();
			}
			return jDXKshrBBiaDpYXUJuWaceensCGN.GetElementType(elementIdentifierId);
		}
	}
}
