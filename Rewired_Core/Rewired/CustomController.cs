using System;
using System.Collections.Generic;
using Rewired.Utils;

namespace Rewired
{
	public sealed class CustomController : ControllerWithAxes
	{
		private int EXcIlblhIEFiKjAFHAuzPmLJmVheA;

		private Func<int, float> ZKMcVZXswxtvbBeLZAiqfRrsHMKQ;

		private Func<int, bool> KeBIuPmMiFkkyWtxXocmLvRFedHo;

		private bool BibKimbUBOTAkFZKVBPjYrPkGWeR;

		private Guid SZNVwkTaWhBaXHBVCZavdTzxGwgp;

		public int sourceControllerId => EXcIlblhIEFiKjAFHAuzPmLJmVheA;

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return Guid.Empty;
				}
				return SZNVwkTaWhBaXHBVCZavdTzxGwgp;
			}
		}

		internal CustomController(XeeCNgHjZMIswyGERJdBBjwJCnEBA P_0)
			: this(P_0.HBZblCBazeDfqCkWSDYrcRQYsMwoA, P_0.XHeLXBkEPmqdmYKhknXQSUsWRJXh, P_0.gtUHQOMvYkRjYAksobERwOUBiIYN, P_0.ADDDCghZjPcBqomFNqaRChwimBYzB, P_0.zBKJPlzimjZyagilmPlkXySOQmSy, P_0.JsFMMvVfsnXVqqgsMGZDSybWHEgM, P_0.LgGByklfbGExtuEOzPazEUlFRlKb, P_0.BlEDQbDUmfikEbtsAqRbAChLwPzT, P_0.sAFWPhaoKuiAiWeWyWJkOJPWbOVdA, P_0.qlPyMfStFAUFVrytfjcRexWrMcci, null, new ControllerDataUpdater(P_0.ADDDCghZjPcBqomFNqaRChwimBYzB, P_0.BlEDQbDUmfikEbtsAqRbAChLwPzT, P_0.sAFWPhaoKuiAiWeWyWJkOJPWbOVdA, null))
		{
		}

		private CustomController(int P_0, int P_1, Guid P_2, InputSource P_3, string P_4, string P_5, string P_6, int P_7, int P_8, HardwareControllerMap_Game P_9, IList<Extension> P_10, ControllerDataUpdater P_11)
			: base(P_0, P_3, P_4, P_5, P_6, ControllerType.Custom, P_2, P_7, P_8, null, P_9, P_10, P_11)
		{
			EXcIlblhIEFiKjAFHAuzPmLJmVheA = P_1;
			SZNVwkTaWhBaXHBVCZavdTzxGwgp = MiscTools.CreateGuidHashSHA1("CustomController device instance GUID: sourceId = " + EXcIlblhIEFiKjAFHAuzPmLJmVheA + ", controllerId = " + P_0);
			EPRdHvMTqwabaKQBybJMATOxbzNDb();
		}

		internal void YwaBklKtnduwXFPUllzVWXhARgBUA()
		{
			if (!BibKimbUBOTAkFZKVBPjYrPkGWeR)
			{
				return;
			}
			if (ZKMcVZXswxtvbBeLZAiqfRrsHMKQ != null)
			{
				for (int i = 0; i < _axisCount; i++)
				{
					ONcPOmEPPyOeIZfvFoSEEYgzfzdq.axisValues[i] = ZKMcVZXswxtvbBeLZAiqfRrsHMKQ(i);
				}
			}
			if (KeBIuPmMiFkkyWtxXocmLvRFedHo != null)
			{
				for (int j = 0; j < _buttonCount; j++)
				{
					ONcPOmEPPyOeIZfvFoSEEYgzfzdq.buttonValues[j] = KeBIuPmMiFkkyWtxXocmLvRFedHo(j);
				}
			}
		}

		public void SetAxisValue(int index, float value)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _axisCount)
				{
					Logger.LogWarning(index + " is not a valid Axis index.");
				}
				else
				{
					ONcPOmEPPyOeIZfvFoSEEYgzfzdq.axisValues[index] = value;
				}
			}
		}

		public void SetAxisValue(string elementName, float value)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
			}
			else if (base.enabled)
			{
				int axisIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetAxisIndex(elementName);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning("\"" + axisIndex + "\" is not a valid Axis name.");
				}
				else
				{
					ONcPOmEPPyOeIZfvFoSEEYgzfzdq.axisValues[axisIndex] = value;
				}
			}
		}

		public void SetAxisValueById(int elementId, float value)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
			}
			else if (base.enabled)
			{
				int axisIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetAxisIndex(elementId);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning(elementId + " is not a valid Axis id.");
				}
				else
				{
					ONcPOmEPPyOeIZfvFoSEEYgzfzdq.axisValues[axisIndex] = value;
				}
			}
		}

		public void SetButtonValue(int index, bool value)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _buttonCount)
				{
					Logger.LogWarning(index + " is not a valid Button index.");
				}
				else
				{
					ONcPOmEPPyOeIZfvFoSEEYgzfzdq.buttonValues[index] = value;
				}
			}
		}

		public void SetButtonValue(string elementName, bool value)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
			}
			else if (base.enabled)
			{
				int buttonIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetButtonIndex(elementName);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning("\"" + buttonIndex + "\" is not a valid Button name.");
				}
				else
				{
					ONcPOmEPPyOeIZfvFoSEEYgzfzdq.buttonValues[buttonIndex] = value;
				}
			}
		}

		public void SetButtonValueById(int elementId, bool value)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
			}
			else if (base.enabled)
			{
				int buttonIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetButtonIndex(elementId);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning(elementId + " is not a valid Button id.");
				}
				else
				{
					ONcPOmEPPyOeIZfvFoSEEYgzfzdq.buttonValues[buttonIndex] = value;
				}
			}
		}

		public void SetAxisUpdateCallback(Func<int, float> callback)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return;
			}
			ZKMcVZXswxtvbBeLZAiqfRrsHMKQ = callback;
			if (!BibKimbUBOTAkFZKVBPjYrPkGWeR)
			{
				BibKimbUBOTAkFZKVBPjYrPkGWeR = true;
			}
		}

		public void SetButtonUpdateCallback(Func<int, bool> callback)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
				return;
			}
			KeBIuPmMiFkkyWtxXocmLvRFedHo = callback;
			if (!BibKimbUBOTAkFZKVBPjYrPkGWeR)
			{
				BibKimbUBOTAkFZKVBPjYrPkGWeR = true;
			}
		}

		public void ClearAxisValue(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _axisCount)
				{
					Logger.LogWarning(index + " is not a valid Axis index.");
					return;
				}
				float num = ((_calibrationMap != null) ? _calibrationMap.GetAxis(index).calibratedZero : 0f);
				ONcPOmEPPyOeIZfvFoSEEYgzfzdq.axisValues[index] = num;
			}
		}

		public void ClearAxisValue(string elementName)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
			}
			else if (base.enabled)
			{
				int axisIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetAxisIndex(elementName);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning("\"" + axisIndex + "\" is not a valid Axis name.");
				}
				else
				{
					ClearAxisValue(axisIndex);
				}
			}
		}

		public void ClearAxisValueById(int elementId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
			}
			else if (base.enabled)
			{
				int axisIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetAxisIndex(elementId);
				if (axisIndex < 0 || axisIndex >= _axisCount)
				{
					Logger.LogWarning(elementId + " is not a valid Axis id.");
				}
				else
				{
					ClearAxisValue(axisIndex);
				}
			}
		}

		public void ClearButtonValue(int index)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
			}
			else if (base.enabled)
			{
				if (index < 0 || index >= _buttonCount)
				{
					Logger.LogWarning(index + " is not a valid Button index.");
					return;
				}
				ONcPOmEPPyOeIZfvFoSEEYgzfzdq.buttonValues[index] = false;
				ONcPOmEPPyOeIZfvFoSEEYgzfzdq.buttonPressureValues[index] = 0f;
			}
		}

		public void ClearButtonValue(string elementName)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
			}
			else if (base.enabled)
			{
				int buttonIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetButtonIndex(elementName);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning("\"" + buttonIndex + "\" is not a valid Button name.");
				}
				else
				{
					ClearButtonValue(buttonIndex);
				}
			}
		}

		public void ClearButtonValueById(int elementId)
		{
			if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
			{
				ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
			}
			else if (base.enabled)
			{
				int buttonIndex = asJEgTisjEcLUALQMOtkJoREArlC.GetButtonIndex(elementId);
				if (buttonIndex < 0 || buttonIndex >= _buttonCount)
				{
					Logger.LogWarning(elementId + " is not a valid Button id.");
				}
				else
				{
					ClearButtonValue(buttonIndex);
				}
			}
		}
	}
}
