using System;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class UnityUnifiedMouseSource : IUnifiedMouseSource, IGetSetEnabled, IDisposable
	{
		private class tJFWDTJbCUpHbtTYVQoYHBdwTQPE
		{
			private float[] KGUFuVKBSxoaMaJyahJVSxYjkyLt;

			private bool[] gszOCanligmMCtvhTShmIXZmoyOj;

			public tJFWDTJbCUpHbtTYVQoYHBdwTQPE(int P_0, int P_1)
			{
				gszOCanligmMCtvhTShmIXZmoyOj = new bool[P_0];
				KGUFuVKBSxoaMaJyahJVSxYjkyLt = new float[P_1];
			}

			public void XtYlCNxTlzHUdDAdQERRIQpIzRSf(bool[] P_0, float[] P_1)
			{
				Array.Copy(P_0, gszOCanligmMCtvhTShmIXZmoyOj, P_0.Length);
				for (int i = 0; i < KGUFuVKBSxoaMaJyahJVSxYjkyLt.Length; i++)
				{
					KGUFuVKBSxoaMaJyahJVSxYjkyLt[i] += P_1[i];
				}
			}

			public void mZXzHWmmNgcnuDaNTQMPWIgekUzs(ControllerDataUpdater P_0)
			{
				Array.Copy(KGUFuVKBSxoaMaJyahJVSxYjkyLt, P_0.axisValues, KGUFuVKBSxoaMaJyahJVSxYjkyLt.Length);
				Array.Copy(gszOCanligmMCtvhTShmIXZmoyOj, P_0.buttonValues, gszOCanligmMCtvhTShmIXZmoyOj.Length);
			}

			public void MYmbAUauOvdPtqtNMviCFbFhFQPEb()
			{
				Array.Clear(KGUFuVKBSxoaMaJyahJVSxYjkyLt, 0, KGUFuVKBSxoaMaJyahJVSxYjkyLt.Length);
				Array.Clear(gszOCanligmMCtvhTShmIXZmoyOj, 0, gszOCanligmMCtvhTShmIXZmoyOj.Length);
			}

			public void dpIPNdvGQiEXByNiXNuxScfKAAdX()
			{
				Array.Clear(KGUFuVKBSxoaMaJyahJVSxYjkyLt, 0, KGUFuVKBSxoaMaJyahJVSxYjkyLt.Length);
			}
		}

		[Serializable]
		private sealed class rzsbUPUVzvCbaIKHEzDSodtCJQKu
		{
			public static readonly rzsbUPUVzvCbaIKHEzDSodtCJQKu _003C_003E9 = new rzsbUPUVzvCbaIKHEzDSodtCJQKu();

			public static Func<tJFWDTJbCUpHbtTYVQoYHBdwTQPE> _003C_003E9__20_0;

			internal tJFWDTJbCUpHbtTYVQoYHBdwTQPE vBrKYJfSEIUBKueiXyiJOGEdoIXA()
			{
				return new tJFWDTJbCUpHbtTYVQoYHBdwTQPE(7, 4);
			}
		}

		private static HardwareControllerMap_Game GOaObOdRsFHzMlWSmoBWcFYkAXKR;

		private UpdateLoopDataSet<tJFWDTJbCUpHbtTYVQoYHBdwTQPE> glufKwdCSowKPCyTfqCfVacLUkYD;

		private float[] uuVMgRWCMCodIMBiEHphDEkjBfNV;

		private bool[] hvUhodOStjzZSZdEcFTPjBgadWpQ;

		private bool trblLjIdMYeSCEbVYJoTsWOXWIAr;

		private bool qmnRPTsbBxXieoCajnrvdtdAUbsH;

		bool IGetSetEnabled.enabled
		{
			get
			{
				return trblLjIdMYeSCEbVYJoTsWOXWIAr;
			}
			set
			{
				if (trblLjIdMYeSCEbVYJoTsWOXWIAr != value)
				{
					trblLjIdMYeSCEbVYJoTsWOXWIAr = value;
					Clear();
					ThreadSafeUnityInput.mouse.Monitor(value);
				}
			}
		}

		InputSource IUnifiedMouseSource.inputSource => InputSource.UnityKeyboardAndMouse;

		HardwareControllerMap_Game IUnifiedMouseSource.hardwareMap
		{
			get
			{
				if (GOaObOdRsFHzMlWSmoBWcFYkAXKR == null)
				{
					GOaObOdRsFHzMlWSmoBWcFYkAXKR = CreateHardwareMap();
				}
				return GOaObOdRsFHzMlWSmoBWcFYkAXKR;
			}
		}

		int IUnifiedMouseSource.buttonCount => 7;

		int IUnifiedMouseSource.axisCount => 4;

		Vector2 IUnifiedMouseSource.mousePosition
		{
			get
			{
				if (!trblLjIdMYeSCEbVYJoTsWOXWIAr)
				{
					return default(Vector2);
				}
				return ThreadSafeUnityInput.mouse.mousePosition;
			}
		}

		Controller.Extension IUnifiedMouseSource.controllerExtension => null;

		public UnityUnifiedMouseSource()
		{
			glufKwdCSowKPCyTfqCfVacLUkYD = new UpdateLoopDataSet<tJFWDTJbCUpHbtTYVQoYHBdwTQPE>(ReInput.configVars.updateLoop, rzsbUPUVzvCbaIKHEzDSodtCJQKu._003C_003E9.vBrKYJfSEIUBKueiXyiJOGEdoIXA);
			uuVMgRWCMCodIMBiEHphDEkjBfNV = new float[4];
			hvUhodOStjzZSZdEcFTPjBgadWpQ = new bool[7];
			Rewired_002EInterfaces_002EIGetSetEnabled_002Eenabled = true;
			ReInput.UpdateEndedEvent += shicsfDOJWQoXwFSdmYBLzejjvqFA;
			ThreadSafeUnityInput.mouse.InputUpdatedEvent += YByFuFFtzsgRXOjBhtUrpSpzDjDdb;
		}

		public void UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			glufKwdCSowKPCyTfqCfVacLUkYD.Get(ReInput.currentUpdateLoop).mZXzHWmmNgcnuDaNTQMPWIgekUzs(dataUpdater);
		}

		void IUnifiedMouseSource.UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UpdateInputData
			this.UpdateInputData(dataUpdater);
		}

		public void Clear()
		{
			int count = glufKwdCSowKPCyTfqCfVacLUkYD.Count;
			for (int i = 0; i < count; i++)
			{
				glufKwdCSowKPCyTfqCfVacLUkYD.Get(i).MYmbAUauOvdPtqtNMviCFbFhFQPEb();
			}
		}

		void IUnifiedMouseSource.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Clear
			this.Clear();
		}

		private void YByFuFFtzsgRXOjBhtUrpSpzDjDdb()
		{
			if (trblLjIdMYeSCEbVYJoTsWOXWIAr)
			{
				ThreadSafeUnityInput.mouse.GetLatestAxisValues(uuVMgRWCMCodIMBiEHphDEkjBfNV);
				ThreadSafeUnityInput.mouse.GetThreadFrameButtonValues(hvUhodOStjzZSZdEcFTPjBgadWpQ);
				int count = glufKwdCSowKPCyTfqCfVacLUkYD.Count;
				for (int i = 0; i < count; i++)
				{
					glufKwdCSowKPCyTfqCfVacLUkYD.Get(i).XtYlCNxTlzHUdDAdQERRIQpIzRSf(hvUhodOStjzZSZdEcFTPjBgadWpQ, uuVMgRWCMCodIMBiEHphDEkjBfNV);
				}
			}
		}

		private void shicsfDOJWQoXwFSdmYBLzejjvqFA(UpdateLoopType P_0)
		{
			glufKwdCSowKPCyTfqCfVacLUkYD.Get(P_0).dpIPNdvGQiEXByNiXNuxScfKAAdX();
		}

		internal static HardwareControllerMap_Game CreateHardwareMap()
		{
			ControllerElementIdentifier[] array = new ControllerElementIdentifier[Consts.unityUnifiedMouseElementIdentifiers.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new ControllerElementIdentifier(Consts.unityUnifiedMouseElementIdentifiers[i]);
			}
			int[] array2 = new int[7];
			int[] array3 = new int[4];
			int num = 0;
			int num2 = 0;
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j].elementType == ControllerElementType.Axis)
				{
					array3[num2++] = array[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid;
				}
				else if (array[j].elementType == ControllerElementType.Button)
				{
					array2[num++] = array[j].XAukkdYkRkAZDxUWBprlnhBlowWG_002Eid;
				}
			}
			AxisCalibrationData[] array4 = new AxisCalibrationData[4];
			AxisRange[] array5 = new AxisRange[4];
			HardwareAxisInfo[] array6 = new HardwareAxisInfo[4];
			HardwareButtonInfo[] array7 = new HardwareButtonInfo[7];
			for (int k = 0; k < 4; k++)
			{
				array4[k] = AxisCalibrationData.Raw;
				array5[k] = AxisRange.Full;
				float num3 = (((uint)k > 1u) ? 2f : 100f);
				array6[k] = new HardwareAxisInfo(AxisCoordinateMode.Relative, false, num3, SpecialAxisType.None);
			}
			for (int l = 0; l < 7; l++)
			{
				array7[l] = new HardwareButtonInfo();
			}
			HardwareJoystickMap.CompoundElement[] array8 = new HardwareJoystickMap.CompoundElement[Consts.unifiedMouseCompoundElements_readOnly.Count];
			for (int m = 0; m < Consts.unifiedMouseCompoundElements_readOnly.Count; m++)
			{
				array8[m] = new HardwareJoystickMap.CompoundElement(Consts.unifiedMouseCompoundElements_readOnly[m]);
			}
			return new HardwareControllerMap_Game("Mouse", default(HardwareControllerMapIdentifier), array, array2, array3, array4, array5, array6, array7, array8);
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

		~UnityUnifiedMouseSource()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (qmnRPTsbBxXieoCajnrvdtdAUbsH)
			{
				return;
			}
			if (disposing)
			{
				if (trblLjIdMYeSCEbVYJoTsWOXWIAr)
				{
					ThreadSafeUnityInput.mouse.Monitor(state: false);
				}
				ReInput.UpdateEndedEvent -= shicsfDOJWQoXwFSdmYBLzejjvqFA;
				ThreadSafeUnityInput.mouse.InputUpdatedEvent -= YByFuFFtzsgRXOjBhtUrpSpzDjDdb;
			}
			qmnRPTsbBxXieoCajnrvdtdAUbsH = true;
		}

		public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
		{
			if (GOaObOdRsFHzMlWSmoBWcFYkAXKR == null)
			{
				GOaObOdRsFHzMlWSmoBWcFYkAXKR = CreateHardwareMap();
			}
			return GOaObOdRsFHzMlWSmoBWcFYkAXKR.GetElementType(elementIdentifierId);
		}
	}
}
