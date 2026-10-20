using System;
using System.Collections.Generic;
using System.Text;
using Rewired;
using Rewired.InputSources.SDL2;
using Rewired.Interfaces;
using Rewired.Internal;

internal sealed class aspgCKrCvFpOVZulKUGsPWITAabc : IElementIdentifierTool
{
	private GUIText GEYHCfKYmpgLYJqkzPXguDvKZXhAA;

	private readonly StringBuilder rpfDlCqFHUpaNUDahCjWOBDucYgU = new StringBuilder();

	private int uCDykeybBpTGcIPhCxRyxlrqAjyu;

	private SDL2InputSource VgihNIMupUQpSLPAYBfYOVuEsUTQ;

	private Guid eYaFduuyxRoMokVJlGiwksAWAPGe;

	private IList<EwqrfRnhEGRfNObqLvBUXUSUEutP> PBShKYDZqnfrZrHUJNzEorRbLwiGA;

	private bool SsQITZYJsfJvCiNeULnazmTyoIeH;

	private bool IzhhhILFyCNDeXglrffPLVwXIEHf;

	public void Initialize(GUIText text)
	{
		GEYHCfKYmpgLYJqkzPXguDvKZXhAA = text;
	}

	void IElementIdentifierTool.Initialize(GUIText text)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Initialize
		this.Initialize(text);
	}

	public void Start()
	{
		VgihNIMupUQpSLPAYBfYOVuEsUTQ = ReInput.primaryInputManager.inputSource as SDL2InputSource;
		if (VgihNIMupUQpSLPAYBfYOVuEsUTQ == null)
		{
			Logger.LogError("Unable to initialize SDL2 element identifier! You must add a Rewired Input Manager to the scene and set the input mode to SDL2.");
			return;
		}
		ReInput.primaryInputManager.SystemDeviceConnectedEvent += KzrhdXyPecwFTykipclsFOBqcbABA;
		ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += KHuXhErYOsJCMLOPgnRLsHZmPRBr;
		rTNEAOfUPfkPIEstsYHCntguCEewA();
		IzhhhILFyCNDeXglrffPLVwXIEHf = true;
	}

	void IElementIdentifierTool.Start()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Start
		this.Start();
	}

	public void Update()
	{
		if (!IzhhhILFyCNDeXglrffPLVwXIEHf)
		{
			return;
		}
		rpfDlCqFHUpaNUDahCjWOBDucYgU.Length = 0;
		rpfDlCqFHUpaNUDahCjWOBDucYgU.Append("SDL2 Joystick Element Identifier\n\n");
		GEYHCfKYmpgLYJqkzPXguDvKZXhAA.text = rpfDlCqFHUpaNUDahCjWOBDucYgU.ToString();
		int num = uCDykeybBpTGcIPhCxRyxlrqAjyu;
		Guid guid = eYaFduuyxRoMokVJlGiwksAWAPGe;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyboardKeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyboardKeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyboardKeyCode.KeypadPlus))
		{
			uCDykeybBpTGcIPhCxRyxlrqAjyu++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyboardKeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyboardKeyCode.Minus))
		{
			uCDykeybBpTGcIPhCxRyxlrqAjyu--;
		}
		if (SsQITZYJsfJvCiNeULnazmTyoIeH)
		{
			rTNEAOfUPfkPIEstsYHCntguCEewA();
			SsQITZYJsfJvCiNeULnazmTyoIeH = false;
		}
		int num2 = ((PBShKYDZqnfrZrHUJNzEorRbLwiGA != null) ? PBShKYDZqnfrZrHUJNzEorRbLwiGA.Count : 0);
		if (num2 == 0)
		{
			return;
		}
		if (uCDykeybBpTGcIPhCxRyxlrqAjyu < 0)
		{
			uCDykeybBpTGcIPhCxRyxlrqAjyu = num2 - 1;
		}
		else if (uCDykeybBpTGcIPhCxRyxlrqAjyu >= num2)
		{
			uCDykeybBpTGcIPhCxRyxlrqAjyu = 0;
		}
		EwqrfRnhEGRfNObqLvBUXUSUEutP ewqrfRnhEGRfNObqLvBUXUSUEutP = PBShKYDZqnfrZrHUJNzEorRbLwiGA[uCDykeybBpTGcIPhCxRyxlrqAjyu];
		eYaFduuyxRoMokVJlGiwksAWAPGe = ewqrfRnhEGRfNObqLvBUXUSUEutP.yhicbDjyGKhUgYmbAOJdueUvjYqM;
		bool flag = false;
		if (num != uCDykeybBpTGcIPhCxRyxlrqAjyu || guid != eYaFduuyxRoMokVJlGiwksAWAPGe)
		{
			flag = true;
		}
		if (num2 > 0)
		{
			rpfDlCqFHUpaNUDahCjWOBDucYgU.Append(num2).Append(" connected devices:\n");
		}
		for (int i = 0; i < num2; i++)
		{
			rpfDlCqFHUpaNUDahCjWOBDucYgU.Append(PBShKYDZqnfrZrHUJNzEorRbLwiGA[i].daoSvnTfYTUAaCJXGklyVPSSbAmL + "\n");
		}
		rpfDlCqFHUpaNUDahCjWOBDucYgU.Append("\n");
		rpfDlCqFHUpaNUDahCjWOBDucYgU.Append("Current SDL2 device ").Append(uCDykeybBpTGcIPhCxRyxlrqAjyu).Append(": \"")
			.Append(ewqrfRnhEGRfNObqLvBUXUSUEutP.daoSvnTfYTUAaCJXGklyVPSSbAmL)
			.Append("\"\n");
		rpfDlCqFHUpaNUDahCjWOBDucYgU.Append("(Press + or - to change monitored device id.)\n\n");
		ZWxYEaYQtSNaDmaKODEtLQnibazX("Product Name", "\"" + ewqrfRnhEGRfNObqLvBUXUSUEutP.daoSvnTfYTUAaCJXGklyVPSSbAmL + "\"");
		ZWxYEaYQtSNaDmaKODEtLQnibazX("Is Bluetooth Device", ewqrfRnhEGRfNObqLvBUXUSUEutP.dexsMRpLwKOUSoLocjETHHnwoAZBA);
		ZWxYEaYQtSNaDmaKODEtLQnibazX("Device Type", ewqrfRnhEGRfNObqLvBUXUSUEutP.ItnCYRLJnKBmnpgFmcQWidYUVwVk.ToString());
		ZWxYEaYQtSNaDmaKODEtLQnibazX("Product Id", ewqrfRnhEGRfNObqLvBUXUSUEutP.OVQKsdpbdMzmshGknASsTZkRsrRK);
		ZWxYEaYQtSNaDmaKODEtLQnibazX("Vendor Id", ewqrfRnhEGRfNObqLvBUXUSUEutP.BhxIldEqUyqbetLRaeOhGmTOJbLJA);
		ZWxYEaYQtSNaDmaKODEtLQnibazX("Serial", ewqrfRnhEGRfNObqLvBUXUSUEutP.LXXyrJdNjVXGOQzagSSrotZAsgcC);
		ZWxYEaYQtSNaDmaKODEtLQnibazX("Path", ewqrfRnhEGRfNObqLvBUXUSUEutP.OCEbEtfBQbYzavNyEFadfKqcnWQyA);
		ZWxYEaYQtSNaDmaKODEtLQnibazX("Motor Count", ewqrfRnhEGRfNObqLvBUXUSUEutP.NTqOpHFbvHuyLbLaEdmbjLPuKsdI);
		rpfDlCqFHUpaNUDahCjWOBDucYgU.Append("\n");
		ZWxYEaYQtSNaDmaKODEtLQnibazX("Axis Count", ewqrfRnhEGRfNObqLvBUXUSUEutP.AcyBhZIsGMjxlZeMJKbUKUVxrNLkA);
		ZWxYEaYQtSNaDmaKODEtLQnibazX("Button Count", ewqrfRnhEGRfNObqLvBUXUSUEutP.SRVuCLhCpZdMYEgpAkVXiLKJPlHwA);
		ZWxYEaYQtSNaDmaKODEtLQnibazX("Hat Count", ewqrfRnhEGRfNObqLvBUXUSUEutP.gBQAhHZqEhmzzZdatQzUBwwjxfQG);
		rpfDlCqFHUpaNUDahCjWOBDucYgU.Append("\n");
		if (flag)
		{
			Logger.Log(string.Concat("" + "Device Name: \"" + ewqrfRnhEGRfNObqLvBUXUSUEutP.daoSvnTfYTUAaCJXGklyVPSSbAmL + "\"\n", "Identifier: ", ewqrfRnhEGRfNObqLvBUXUSUEutP.qtaMmMJdCHVLpnFhWSJFQyJUgzlq.ToString(), "\n"));
		}
		for (int j = 0; j < ewqrfRnhEGRfNObqLvBUXUSUEutP.VCSrMqGhkXwhyzceIIHOMztZZsld; j++)
		{
			ZWxYEaYQtSNaDmaKODEtLQnibazX("Axis " + j, ewqrfRnhEGRfNObqLvBUXUSUEutP.tEMLhmWbGNkFOHKSEmsERrKUCRti(j) + " (" + ewqrfRnhEGRfNObqLvBUXUSUEutP.esPPzTqcpnuQWEfhfrMGLsUqEhCh(j) + ")");
		}
		for (int k = 0; k < ewqrfRnhEGRfNObqLvBUXUSUEutP.SlETggxFmtZKNrhpkGUsIavgapwu; k++)
		{
			ZWxYEaYQtSNaDmaKODEtLQnibazX("Hat " + k, ewqrfRnhEGRfNObqLvBUXUSUEutP.ERSfDsbkkVLoiGcHdodUPHGwspFFB(k));
		}
		string text = "";
		for (int l = 0; l < ewqrfRnhEGRfNObqLvBUXUSUEutP.yFvlsWgHwliaKHPFCBOqdDAmQWIZ; l++)
		{
			if (ewqrfRnhEGRfNObqLvBUXUSUEutP.zHldmjeUCpWmYMLuFdiOabeGgUQDB(l))
			{
				if (text != "")
				{
					text += ", ";
				}
				text += l;
			}
		}
		ZWxYEaYQtSNaDmaKODEtLQnibazX("Buttons ", text);
		GEYHCfKYmpgLYJqkzPXguDvKZXhAA.text = rpfDlCqFHUpaNUDahCjWOBDucYgU.ToString();
	}

	void IElementIdentifierTool.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	public void OnDestroy()
	{
	}

	void IElementIdentifierTool.OnDestroy()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnDestroy
		this.OnDestroy();
	}

	private void rTNEAOfUPfkPIEstsYHCntguCEewA()
	{
		PBShKYDZqnfrZrHUJNzEorRbLwiGA = VgihNIMupUQpSLPAYBfYOVuEsUTQ.GetJoysticks<EwqrfRnhEGRfNObqLvBUXUSUEutP>();
	}

	private void KzrhdXyPecwFTykipclsFOBqcbABA()
	{
		RVPWFaNJpsjtnDOFWeWQQqxfAjGS();
	}

	private void KHuXhErYOsJCMLOPgnRLsHZmPRBr()
	{
		RVPWFaNJpsjtnDOFWeWQQqxfAjGS();
	}

	private void RVPWFaNJpsjtnDOFWeWQQqxfAjGS()
	{
		zUCfbNCzRJCfFDNRjNbOBkANfjPT();
		SsQITZYJsfJvCiNeULnazmTyoIeH = true;
	}

	private void zUCfbNCzRJCfFDNRjNbOBkANfjPT()
	{
		uCDykeybBpTGcIPhCxRyxlrqAjyu = 0;
		eYaFduuyxRoMokVJlGiwksAWAPGe = Guid.Empty;
		PBShKYDZqnfrZrHUJNzEorRbLwiGA = null;
		SsQITZYJsfJvCiNeULnazmTyoIeH = false;
	}

	private void ZWxYEaYQtSNaDmaKODEtLQnibazX(string P_0, object P_1)
	{
		rpfDlCqFHUpaNUDahCjWOBDucYgU.Append(P_0).Append(" = ").Append(P_1)
			.AppendLine();
	}
}
