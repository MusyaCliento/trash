using System;
using System.Collections.Generic;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired
{
	public sealed class Mouse : ControllerWithAxes
	{
		private TimerAbs rPHevSEDwbhFgqBpTNEJeRKPlGTk;

		private float[] MsJIipVNSHfLKgNKQLCWkedhyGrb;

		private Vector2 MJijJRAMLpbDHBEtzxAtRdMlraWUA;

		private Vector2 UNKzfWbKRHMYgOYcoKtRHuWtoSZp;

		private int eiXmtsIYLGswFITlREzvZyqlUwAG;

		private readonly IUnifiedMouseSource fIrkDRamoqospJaYPGLGMOdQROfq;

		private static Guid OycMGLjVSZqPQaFgPorbjVkRsrtD;

		public Vector2 screenPosition
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return Vector2.zero;
				}
				return MJijJRAMLpbDHBEtzxAtRdMlraWUA;
			}
		}

		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return Vector2.zero;
				}
				return UNKzfWbKRHMYgOYcoKtRHuWtoSZp;
			}
		}

		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return Vector2.zero;
				}
				return MJijJRAMLpbDHBEtzxAtRdMlraWUA - UNKzfWbKRHMYgOYcoKtRHuWtoSZp;
			}
		}

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != sYoYcnbgceNmZCFbjxQoahCmBDVAA)
				{
					ReInput.CheckInitialized(sYoYcnbgceNmZCFbjxQoahCmBDVAA);
					return Guid.Empty;
				}
				return OycMGLjVSZqPQaFgPorbjVkRsrtD;
			}
		}

		internal Mouse(string P_0, IUnifiedMouseSource P_1)
			: this(0, P_1.inputSource, P_0, InputTools.FormatHardwareIdentifierString(P_0), P_1.axisCount, P_1.buttonCount, P_1.hardwareMap, (P_1 == null) ? null : ((P_1.controllerExtension == null) ? null : new Extension[1] { P_1.controllerExtension }), new ControllerDataUpdater(P_1.inputSource, P_1.axisCount, P_1.buttonCount, null))
		{
			fIrkDRamoqospJaYPGLGMOdQROfq = P_1;
			OycMGLjVSZqPQaFgPorbjVkRsrtD = MiscTools.CreateGuidHashSHA1("[Universal Mouse]");
			EPRdHvMTqwabaKQBybJMATOxbzNDb();
		}

		private Mouse(int P_0, InputSource P_1, string P_2, string P_3, int P_4, int P_5, HardwareControllerMap_Game P_6, IList<Extension> P_7, ControllerDataUpdater P_8)
			: base(P_0, P_1, P_2, P_2, P_3, ControllerType.Mouse, Consts.hardwareTypeGuid_universalMouse, P_4, P_5, null, P_6, P_7, P_8)
		{
		}

		internal void MhjoSaNbfUuiDxyGFvfKWIDACgODA(UpdateLoopType P_0)
		{
			fIrkDRamoqospJaYPGLGMOdQROfq.UpdateInputData(ONcPOmEPPyOeIZfvFoSEEYgzfzdq);
			vyCpASKgznrSGjlXeDnKTYNUWDwT(P_0);
			DkYFPixRYOcyMeGOrJuBBcUAVGkmb();
		}

		protected override bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (MsJIipVNSHfLKgNKQLCWkedhyGrb == null)
			{
				MsJIipVNSHfLKgNKQLCWkedhyGrb = new float[_axisCount];
			}
			if (rPHevSEDwbhFgqBpTNEJeRKPlGTk == null)
			{
				rPHevSEDwbhFgqBpTNEJeRKPlGTk = new TimerAbs(1.0);
			}
			if (rPHevSEDwbhFgqBpTNEJeRKPlGTk.Update() || !rPHevSEDwbhFgqBpTNEJeRKPlGTk.running)
			{
				rPHevSEDwbhFgqBpTNEJeRKPlGTk.Start();
				Array.Clear(MsJIipVNSHfLKgNKQLCWkedhyGrb, 0, MsJIipVNSHfLKgNKQLCWkedhyGrb.Length);
			}
			if (ReInput.currentUpdateLoop == UpdateLoopType.OnGUI && !ReInput.configVars.GetPlatformVar_useNativeMouse())
			{
				MsJIipVNSHfLKgNKQLCWkedhyGrb[index] += axes[index].valueRaw * 0.5f;
			}
			else
			{
				MsJIipVNSHfLKgNKQLCWkedhyGrb[index] += axes[index].valueRaw;
			}
			float num = MsJIipVNSHfLKgNKQLCWkedhyGrb[index];
			if (MathTools.Abs(num) <= axes[index].zAQaZHyHWtIpzmySIDEsIphBotfe)
			{
				return false;
			}
			pole = ((!(num >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = asJEgTisjEcLUALQMOtkJoREArlC.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			rPHevSEDwbhFgqBpTNEJeRKPlGTk.running = false;
			return true;
		}

		internal void dcVCTghrwGFulVPNPdzRwmjdZmYi()
		{
			XIMdugOqsgGQtgPqQYXcFguOELdDb();
			if (rPHevSEDwbhFgqBpTNEJeRKPlGTk != null)
			{
				rPHevSEDwbhFgqBpTNEJeRKPlGTk.Clear();
			}
			MJijJRAMLpbDHBEtzxAtRdMlraWUA = Vector2.zero;
			UNKzfWbKRHMYgOYcoKtRHuWtoSZp = Vector2.zero;
		}

		internal bool ZytpBpTNdLyFVjiuXaEtrZxbxeBb(bool P_0)
		{
			if (!base.cTAoJOVqPUVvaYThibiPDfgKvVps(P_0))
			{
				return false;
			}
			if (fIrkDRamoqospJaYPGLGMOdQROfq is IGetSetEnabled)
			{
				(fIrkDRamoqospJaYPGLGMOdQROfq as IGetSetEnabled).enabled = P_0;
			}
			if (P_0)
			{
				DkYFPixRYOcyMeGOrJuBBcUAVGkmb();
				UNKzfWbKRHMYgOYcoKtRHuWtoSZp = screenPosition;
			}
			return true;
		}

		private void DkYFPixRYOcyMeGOrJuBBcUAVGkmb()
		{
			int currentUnityFrame = ReInput.currentUnityFrame;
			if (currentUnityFrame != eiXmtsIYLGswFITlREzvZyqlUwAG)
			{
				UNKzfWbKRHMYgOYcoKtRHuWtoSZp = MJijJRAMLpbDHBEtzxAtRdMlraWUA;
				MJijJRAMLpbDHBEtzxAtRdMlraWUA = fIrkDRamoqospJaYPGLGMOdQROfq.mousePosition;
				eiXmtsIYLGswFITlREzvZyqlUwAG = currentUnityFrame;
			}
		}
	}
}
