using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal sealed class RRWWOSeavpEjItqLSFnoBCfFTJBU : IElementIdentifierTool
{
	private GUIText SojcKuguHwmwEbsxABfnMgFdcngq;

	private string tZWHwsFzpvryAOVBrVYoAGCOjGoj;

	private int IzXUeRFZetFNFGUEmJpZyMTputXO;

	private PuzDJRCxXcZXBmquMyeKTHoPUks sajNzuuWPkHZymUJUwCZwGhSAPGBA;

	private IJySsOxfJZoqgcJpcZGpRDTPCFrG qNJCvcpgHQVLgjpjCObSyVIWjTVk;

	private Guid chNMpqJjzUEFfcnyKyAeyzxmQHIJ;

	private IList<UTyQEMVineRQmjtixsdHzIMSbUZe> DVHKahingEoPmlbtKDjoKGCEvBsvA;

	private IList<UTyQEMVineRQmjtixsdHzIMSbUZe> HLijwbTBaBEDrGZeEEUuhFidMaQEb;

	private bool AevqTZbzMKwEWUPRmCDYFbQSSzky;

	private bool EwzrFWBCgUzBGGGFLELGrOHaTcef;

	private bool CNcpadWsDgfSHKunKenKXlfvUkGU;

	private int oxWEIIIzEaWsPumusvRLkviHjUPcb;

	private TimerRealTime ABbasAbEKhocuyFppqaLlyPrKWFf;

	public void Initialize(GUIText text)
	{
		SojcKuguHwmwEbsxABfnMgFdcngq = text;
	}

	void IElementIdentifierTool.Initialize(GUIText text)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Initialize
		this.Initialize(text);
	}

	public void Start()
	{
		if (ReInput.isEditor && ReInput.editorPlatform != EditorPlatform.Windows)
		{
			Logger.LogError("Direct Input cannot be run on this platform. You must be running the editor in Windows.");
		}
		else if (ReInput.currentPlatform != Platform.Windows)
		{
			Logger.LogError("Direct Input cannot be run on this build target. Be sure Unity's build target is set to Windows Standalone.");
		}
		else if (ReInput.primaryInputManager.inputSource is InputSourceWrapper<PuzDJRCxXcZXBmquMyeKTHoPUks> { source: not null } inputSourceWrapper)
		{
			sajNzuuWPkHZymUJUwCZwGhSAPGBA = inputSourceWrapper.source;
			ReInput.primaryInputManager.SystemDeviceConnectedEvent += ujtdotcpXHilTuLtvEcODgpDsnDkc;
			ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += yeIJfvmVtxZRhqHendCFloQYeviW;
			ABbasAbEKhocuyFppqaLlyPrKWFf = new TimerRealTime(1.0);
			ABbasAbEKhocuyFppqaLlyPrKWFf.Start();
			cgUWprvAkfYabgcokGXLdCLuLoCGA();
			CNcpadWsDgfSHKunKenKXlfvUkGU = true;
		}
		else
		{
			Logger.LogError("Unable to initialize Direct Input! You must add a Rewired Input Manager to the scene and set the input mode to Direct Input.");
		}
	}

	void IElementIdentifierTool.Start()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Start
		this.Start();
	}

	public void Update()
	{
		if (!CNcpadWsDgfSHKunKenKXlfvUkGU)
		{
			return;
		}
		tZWHwsFzpvryAOVBrVYoAGCOjGoj = "Direct Input Joystick Element Identifier\n\n";
		SojcKuguHwmwEbsxABfnMgFdcngq.text = tZWHwsFzpvryAOVBrVYoAGCOjGoj;
		int izXUeRFZetFNFGUEmJpZyMTputXO = IzXUeRFZetFNFGUEmJpZyMTputXO;
		Guid guid = chNMpqJjzUEFfcnyKyAeyzxmQHIJ;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyboardKeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyboardKeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyboardKeyCode.KeypadPlus))
		{
			IzXUeRFZetFNFGUEmJpZyMTputXO++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyboardKeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyboardKeyCode.Minus))
		{
			IzXUeRFZetFNFGUEmJpZyMTputXO--;
		}
		if (ABbasAbEKhocuyFppqaLlyPrKWFf.Update())
		{
			int num = sajNzuuWPkHZymUJUwCZwGhSAPGBA.upqnBoQPZJgbrHEIukWrKpnKwcPk(cOhhDjZBePQFVLMIFaodEQtjsqZJA.All, OJZMDLzBRIdZoAVPTbqRprFJTssS.AttachedOnly);
			if (num != oxWEIIIzEaWsPumusvRLkviHjUPcb)
			{
				oxWEIIIzEaWsPumusvRLkviHjUPcb = num;
				EwzrFWBCgUzBGGGFLELGrOHaTcef = true;
			}
			ABbasAbEKhocuyFppqaLlyPrKWFf.Start();
		}
		if (EwzrFWBCgUzBGGGFLELGrOHaTcef)
		{
			cgUWprvAkfYabgcokGXLdCLuLoCGA();
			EwzrFWBCgUzBGGGFLELGrOHaTcef = false;
		}
		int num2 = ((DVHKahingEoPmlbtKDjoKGCEvBsvA != null) ? DVHKahingEoPmlbtKDjoKGCEvBsvA.Count : 0);
		if (num2 == 0)
		{
			return;
		}
		if (IzXUeRFZetFNFGUEmJpZyMTputXO < 0)
		{
			IzXUeRFZetFNFGUEmJpZyMTputXO = num2 - 1;
		}
		else if (IzXUeRFZetFNFGUEmJpZyMTputXO >= num2)
		{
			IzXUeRFZetFNFGUEmJpZyMTputXO = 0;
		}
		chNMpqJjzUEFfcnyKyAeyzxmQHIJ = DVHKahingEoPmlbtKDjoKGCEvBsvA[IzXUeRFZetFNFGUEmJpZyMTputXO].gPdNFUoLpXnWxHqaioqXdBJsVuWK;
		bool flag = false;
		if (izXUeRFZetFNFGUEmJpZyMTputXO != IzXUeRFZetFNFGUEmJpZyMTputXO || guid != chNMpqJjzUEFfcnyKyAeyzxmQHIJ)
		{
			flag = true;
		}
		if (qNJCvcpgHQVLgjpjCObSyVIWjTVk == null || flag)
		{
			if (qNJCvcpgHQVLgjpjCObSyVIWjTVk != null)
			{
				qNJCvcpgHQVLgjpjCObSyVIWjTVk.IwNWsmpJozXysImeieINzhgLqjiS();
			}
			qNJCvcpgHQVLgjpjCObSyVIWjTVk = new IJySsOxfJZoqgcJpcZGpRDTPCFrG(sajNzuuWPkHZymUJUwCZwGhSAPGBA, DVHKahingEoPmlbtKDjoKGCEvBsvA[IzXUeRFZetFNFGUEmJpZyMTputXO].gPdNFUoLpXnWxHqaioqXdBJsVuWK);
			if (qNJCvcpgHQVLgjpjCObSyVIWjTVk == null)
			{
				return;
			}
			IList<dWyxBkIUPMORAuPdNMABdUWdAyFH> list = qNJCvcpgHQVLgjpjCObSyVIWjTVk.GAnDYhdhuSOtDqrWkjAZgNebRjyYB();
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if ((list[i].VnCKjhlZjGjKyshitkQBEwpkEqYr.VNUwtRupLmFpCYlBzOWAwSxmRjMG & JBcFUjjKPNSJZpmwjTspczQHewI.Axis) != JBcFUjjKPNSJZpmwjTspczQHewI.All)
					{
						qNJCvcpgHQVLgjpjCObSyVIWjTVk.ZVHWpcVAPAcfasMqWKZyxBQxZmuU.WVKkuUZceXyeWsplLFNIdUMcypvhA = new eUjSHhffpbkQhyNTubjChIsBwUjoA(-65535, 65535);
					}
				}
			}
			qNJCvcpgHQVLgjpjCObSyVIWjTVk.lKudTReqXTqfadBHhkYChczUaimMB();
		}
		uQPOritqCmojDTcNoDHVMaAqBRZQ uQPOritqCmojDTcNoDHVMaAqBRZQ2;
		try
		{
			uQPOritqCmojDTcNoDHVMaAqBRZQ2 = qNJCvcpgHQVLgjpjCObSyVIWjTVk.cyRRVuJNFwUwSlAAMuktMRNPwBsP();
		}
		catch
		{
			uQPOritqCmojDTcNoDHVMaAqBRZQ2 = null;
		}
		if (uQPOritqCmojDTcNoDHVMaAqBRZQ2 == null)
		{
			return;
		}
		if (num2 > 0)
		{
			tZWHwsFzpvryAOVBrVYoAGCOjGoj = tZWHwsFzpvryAOVBrVYoAGCOjGoj + num2 + " connected devices:\n";
		}
		for (int j = 0; j < num2; j++)
		{
			tZWHwsFzpvryAOVBrVYoAGCOjGoj = tZWHwsFzpvryAOVBrVYoAGCOjGoj + DVHKahingEoPmlbtKDjoKGCEvBsvA[j].FeYNFHLhgUivGWxojyZVZwwJgvsj + "\n";
		}
		tZWHwsFzpvryAOVBrVYoAGCOjGoj += "\n";
		tZWHwsFzpvryAOVBrVYoAGCOjGoj = tZWHwsFzpvryAOVBrVYoAGCOjGoj + "Current DI device " + IzXUeRFZetFNFGUEmJpZyMTputXO + ": " + DVHKahingEoPmlbtKDjoKGCEvBsvA[IzXUeRFZetFNFGUEmJpZyMTputXO].FeYNFHLhgUivGWxojyZVZwwJgvsj + "\n";
		tZWHwsFzpvryAOVBrVYoAGCOjGoj += "(Press + or - to change monitored device id.)\n\n";
		KodeqRXhpKlJftcQxGHLymSwWVsN("Identifier", new PidVid(qNJCvcpgHQVLgjpjCObSyVIWjTVk.DnWUJYSosSANhFKfJSOgcKGIYrkPb.KGqdhBHUknswGuNHWGWgROAtaLGuA));
		KodeqRXhpKlJftcQxGHLymSwWVsN("Instance GUID", qNJCvcpgHQVLgjpjCObSyVIWjTVk.DnWUJYSosSANhFKfJSOgcKGIYrkPb.gPdNFUoLpXnWxHqaioqXdBJsVuWK);
		KodeqRXhpKlJftcQxGHLymSwWVsN("Product Id", qNJCvcpgHQVLgjpjCObSyVIWjTVk.ZVHWpcVAPAcfasMqWKZyxBQxZmuU.zdfuVksFXiQtCHPlhGPiXWmpEMBKA);
		KodeqRXhpKlJftcQxGHLymSwWVsN("Device Type", qNJCvcpgHQVLgjpjCObSyVIWjTVk.rhVSTskoAdAkZabCrrGFhBOPTGZGA.rZVOleeitLcnexlaGjVHisVzQsgq.ToString());
		tZWHwsFzpvryAOVBrVYoAGCOjGoj += "\n";
		KodeqRXhpKlJftcQxGHLymSwWVsN("Axis Count", qNJCvcpgHQVLgjpjCObSyVIWjTVk.rhVSTskoAdAkZabCrrGFhBOPTGZGA.arvVDjjfCaXxPtzAkNFMDquUblCb);
		KodeqRXhpKlJftcQxGHLymSwWVsN("Button Count", qNJCvcpgHQVLgjpjCObSyVIWjTVk.rhVSTskoAdAkZabCrrGFhBOPTGZGA.qSvsSCNmzWuFgnRvwrEmcRuuvYVj);
		KodeqRXhpKlJftcQxGHLymSwWVsN("Hat Count", qNJCvcpgHQVLgjpjCObSyVIWjTVk.rhVSTskoAdAkZabCrrGFhBOPTGZGA.PugBAzAuoucVkJqyOpqMFTzvKhZnA);
		tZWHwsFzpvryAOVBrVYoAGCOjGoj += "\n";
		if (flag)
		{
			Logger.Log("Device Name: \"" + DVHKahingEoPmlbtKDjoKGCEvBsvA[IzXUeRFZetFNFGUEmJpZyMTputXO].FeYNFHLhgUivGWxojyZVZwwJgvsj + "\"");
			Logger.Log("Identifier: " + new PidVid(qNJCvcpgHQVLgjpjCObSyVIWjTVk.DnWUJYSosSANhFKfJSOgcKGIYrkPb.KGqdhBHUknswGuNHWGWgROAtaLGuA).ToString());
		}
		for (int k = 0; k < 32; k++)
		{
			int num3 = dKnAaaBtkJuiHmTtEQcfcIHZmJiyA((DirectInputAxis)k, uQPOritqCmojDTcNoDHVMaAqBRZQ2);
			DirectInputAxis directInputAxis = (DirectInputAxis)k;
			string text = directInputAxis.ToString();
			KodeqRXhpKlJftcQxGHLymSwWVsN(text, num3 + " (" + iqSocCrSwZNHwevqmQNJCcYcAwTt(num3) + ")");
		}
		int[] array = uQPOritqCmojDTcNoDHVMaAqBRZQ2.oFDYAZcHldFNjIFjijejzJqPrzCPA;
		for (int l = 0; l < 4; l++)
		{
			int num4 = array[l];
			string text2 = "Hat " + l;
			KodeqRXhpKlJftcQxGHLymSwWVsN(text2, num4);
		}
		bool[] array2 = uQPOritqCmojDTcNoDHVMaAqBRZQ2.CdhkqlrkrWueANTWqCEaOOzCmWKF;
		string text3 = "";
		for (int m = 0; m < 128; m++)
		{
			if (array2[m])
			{
				if (text3 != "")
				{
					text3 += ", ";
				}
				text3 += m;
			}
		}
		KodeqRXhpKlJftcQxGHLymSwWVsN("Buttons ", text3);
		SojcKuguHwmwEbsxABfnMgFdcngq.text = tZWHwsFzpvryAOVBrVYoAGCOjGoj;
	}

	void IElementIdentifierTool.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	private void cgUWprvAkfYabgcokGXLdCLuLoCGA()
	{
		DVHKahingEoPmlbtKDjoKGCEvBsvA = sajNzuuWPkHZymUJUwCZwGhSAPGBA.yyUZqaQkYUtCDGgAKGpXlflpfnLGA(cOhhDjZBePQFVLMIFaodEQtjsqZJA.GameControl, OJZMDLzBRIdZoAVPTbqRprFJTssS.AttachedOnly);
		HLijwbTBaBEDrGZeEEUuhFidMaQEb = sajNzuuWPkHZymUJUwCZwGhSAPGBA.yyUZqaQkYUtCDGgAKGpXlflpfnLGA(cOhhDjZBePQFVLMIFaodEQtjsqZJA.All, OJZMDLzBRIdZoAVPTbqRprFJTssS.AttachedOnly);
		oxWEIIIzEaWsPumusvRLkviHjUPcb = ((HLijwbTBaBEDrGZeEEUuhFidMaQEb != null) ? HLijwbTBaBEDrGZeEEUuhFidMaQEb.Count : 0);
	}

	private void ujtdotcpXHilTuLtvEcODgpDsnDkc()
	{
		WbmcmHgWbRTnWuOxhjGsMqaihHsXA();
	}

	private void yeIJfvmVtxZRhqHendCFloQYeviW()
	{
		WbmcmHgWbRTnWuOxhjGsMqaihHsXA();
	}

	private void WbmcmHgWbRTnWuOxhjGsMqaihHsXA()
	{
		cYjGsJMWMSCFEeHhKdOpQoJwrscP();
		EwzrFWBCgUzBGGGFLELGrOHaTcef = true;
	}

	private void cYjGsJMWMSCFEeHhKdOpQoJwrscP()
	{
		IzXUeRFZetFNFGUEmJpZyMTputXO = 0;
		qNJCvcpgHQVLgjpjCObSyVIWjTVk = null;
		chNMpqJjzUEFfcnyKyAeyzxmQHIJ = Guid.Empty;
		DVHKahingEoPmlbtKDjoKGCEvBsvA = null;
		HLijwbTBaBEDrGZeEEUuhFidMaQEb = null;
		AevqTZbzMKwEWUPRmCDYFbQSSzky = false;
		EwzrFWBCgUzBGGGFLELGrOHaTcef = false;
		oxWEIIIzEaWsPumusvRLkviHjUPcb = 0;
	}

	private void KodeqRXhpKlJftcQxGHLymSwWVsN(string P_0, object P_1)
	{
		tZWHwsFzpvryAOVBrVYoAGCOjGoj = tZWHwsFzpvryAOVBrVYoAGCOjGoj + P_0 + " = " + P_1.ToString() + "\n";
	}

	private int dKnAaaBtkJuiHmTtEQcfcIHZmJiyA(DirectInputAxis P_0, uQPOritqCmojDTcNoDHVMaAqBRZQ P_1)
	{
		return P_0 switch
		{
			DirectInputAxis.X => P_1.obTmgmDpublknGtnIrTsamUKkoKj, 
			DirectInputAxis.Y => P_1.ZvUFnBtLzCKMoXfPmGkXgSEulsBY, 
			DirectInputAxis.Z => P_1.IpCfPtGJfFKLqRFFZlZPCnKIPLCiA, 
			DirectInputAxis.RotationX => P_1.CdejOEsUiDlvdAxJTEPADcPFlAYd, 
			DirectInputAxis.RotationY => P_1.QxrUYIkNCeyPRxhXPyDlavhweHrJ, 
			DirectInputAxis.RotationZ => P_1.TZNIgSgUITkRGNpeGEVNgBaSLNuS, 
			DirectInputAxis.Slider0 => P_1.qZpwwOtRpwXllTHZcGrBCdcEaSqHA[0], 
			DirectInputAxis.Slider1 => P_1.qZpwwOtRpwXllTHZcGrBCdcEaSqHA[1], 
			DirectInputAxis.VelocityX => P_1.HDYLFfrHEfqhlmPSMlHNSykLuBuW, 
			DirectInputAxis.VelocityY => P_1.fXaahwNwEZTqPHoGXTXUhTbdfwjb, 
			DirectInputAxis.VelocityZ => P_1.sGsrexbBEiqNKrKODQoOnllciJAq, 
			DirectInputAxis.AngularVelocityX => P_1.jArYLmMiCXiGYkeRZdLrZuoEcOJLA, 
			DirectInputAxis.AngularVelocityY => P_1.ugwxtaatqqOcJYODjjOqhctNmwQFb, 
			DirectInputAxis.AngularVelocityZ => P_1.vBjqnlSkdGBAonhKRbWAGfEvMpGQA, 
			DirectInputAxis.VelocitySlider0 => P_1.poZcfEtGCZChDNVxmfNEHOoNVYWQA[0], 
			DirectInputAxis.VelocitySlider1 => P_1.poZcfEtGCZChDNVxmfNEHOoNVYWQA[1], 
			DirectInputAxis.AccelerationX => P_1.lRTpTXAnSmiCSxhLaXMDIbraayrq, 
			DirectInputAxis.AccelerationY => P_1.mHSMliolUBWrVEqesbllbUSAOJge, 
			DirectInputAxis.AccelerationZ => P_1.waJZKjyrpoGHxCxwMXyznRMaHbND, 
			DirectInputAxis.AngularAccelerationX => P_1.vhdwZkNCVwNWJfzflFzWMCcaAIru, 
			DirectInputAxis.AngularAccelerationY => P_1.mbGPdmpAqQHhmnCqGgEDYeKaWvXy, 
			DirectInputAxis.AngularAccelerationZ => P_1.uUmGDvxSgKziyzRGNQohUtVdRFJF, 
			DirectInputAxis.AccelerationSlider0 => P_1.JUerymjoyAwhqxKjQefCqXjcGiQl[0], 
			DirectInputAxis.AccelerationSlider1 => P_1.JUerymjoyAwhqxKjQefCqXjcGiQl[1], 
			DirectInputAxis.ForceX => P_1.RCFpQWVhDhDqNLfwoQctigBQBHRE, 
			DirectInputAxis.ForceY => P_1.xhSmsazaJqgphccFefmmxllOarGR, 
			DirectInputAxis.ForceZ => P_1.PaeJGnumCcUJNYcVTpTnHDjhHzbH, 
			DirectInputAxis.TorqueX => P_1.mxhYyxVfoYdSQzjfNFYCBdwDEFae, 
			DirectInputAxis.TorqueY => P_1.HlRvwjKSOtpzZJRsqbAowzBPHgTW, 
			DirectInputAxis.TorqueZ => P_1.RVZZhhhVtzQEXDPVpGLFaALTklPK, 
			DirectInputAxis.ForceSlider0 => P_1.YQEEstMEFhgtAgwkQDgoOToGnVyE[0], 
			DirectInputAxis.ForceSlider1 => P_1.YQEEstMEFhgtAgwkQDgoOToGnVyE[1], 
			_ => 0, 
		};
	}

	private float iqSocCrSwZNHwevqmQNJCcYcAwTt(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}

	public void OnDestroy()
	{
		if (qNJCvcpgHQVLgjpjCObSyVIWjTVk != null)
		{
			qNJCvcpgHQVLgjpjCObSyVIWjTVk.IwNWsmpJozXysImeieINzhgLqjiS();
		}
	}

	void IElementIdentifierTool.OnDestroy()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnDestroy
		this.OnDestroy();
	}
}
