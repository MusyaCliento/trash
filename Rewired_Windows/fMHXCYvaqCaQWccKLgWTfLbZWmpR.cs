using System;
using System.Collections.Generic;
using System.Text;
using Rewired;
using Rewired.InputSources.SDL3;
using Rewired.Interfaces;
using Rewired.Internal;

internal sealed class fMHXCYvaqCaQWccKLgWTfLbZWmpR : IElementIdentifierTool
{
	private GUIText XPAZxDxbSzwQaSEOFueFPrrJduSg;

	private readonly StringBuilder ccXWCFxyzWyZDBAjBpaYTMeCQbwK = new StringBuilder();

	private int bHrHatGdAhpoDaiJkQDMiVZreWgo;

	private SDL3InputSource UIaUQjnhqylCmDWuEyzMDEEDCsYc;

	private Guid jXHkJDvAGIltUApkqEBXdSeOuwlLA;

	private IList<ELcxqnjIBKqLBxYuSmwWERrVPWMu> aRETnZiTDlZYNoEeuTOdtgnZfaeo;

	private bool DTbBZgsJFwYUznOhXFcDAtPcPnPV;

	private bool ZkMSIgZsFoXyhmkmaGWDOrBXpVUd;

	public void Initialize(GUIText text)
	{
		XPAZxDxbSzwQaSEOFueFPrrJduSg = text;
	}

	void IElementIdentifierTool.Initialize(GUIText text)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Initialize
		this.Initialize(text);
	}

	public void Start()
	{
		UIaUQjnhqylCmDWuEyzMDEEDCsYc = ReInput.primaryInputManager.inputSource as SDL3InputSource;
		if (UIaUQjnhqylCmDWuEyzMDEEDCsYc == null)
		{
			Logger.LogError("Unable to initialize SDL3 element identifier! You must add a Rewired Input Manager to the scene and set the input mode to SDL3.");
			return;
		}
		ReInput.primaryInputManager.SystemDeviceConnectedEvent += ukdlpEcPhxUtaCuIVLaVOEhItnyb;
		ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += lAIgmcFrGhHLxPbqBaxMLLiLyJOKA;
		dOTlgUqLEgpBfMsgxIYlPetMAANH();
		ZkMSIgZsFoXyhmkmaGWDOrBXpVUd = true;
	}

	void IElementIdentifierTool.Start()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Start
		this.Start();
	}

	public void Update()
	{
		if (!ZkMSIgZsFoXyhmkmaGWDOrBXpVUd)
		{
			return;
		}
		ccXWCFxyzWyZDBAjBpaYTMeCQbwK.Length = 0;
		ccXWCFxyzWyZDBAjBpaYTMeCQbwK.Append("SDL3 Joystick Element Identifier\n\n");
		XPAZxDxbSzwQaSEOFueFPrrJduSg.text = ccXWCFxyzWyZDBAjBpaYTMeCQbwK.ToString();
		int num = bHrHatGdAhpoDaiJkQDMiVZreWgo;
		Guid guid = jXHkJDvAGIltUApkqEBXdSeOuwlLA;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyboardKeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyboardKeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyboardKeyCode.KeypadPlus))
		{
			bHrHatGdAhpoDaiJkQDMiVZreWgo++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyboardKeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyboardKeyCode.Minus))
		{
			bHrHatGdAhpoDaiJkQDMiVZreWgo--;
		}
		if (DTbBZgsJFwYUznOhXFcDAtPcPnPV)
		{
			dOTlgUqLEgpBfMsgxIYlPetMAANH();
			DTbBZgsJFwYUznOhXFcDAtPcPnPV = false;
		}
		int num2 = ((aRETnZiTDlZYNoEeuTOdtgnZfaeo != null) ? aRETnZiTDlZYNoEeuTOdtgnZfaeo.Count : 0);
		if (num2 == 0)
		{
			return;
		}
		if (bHrHatGdAhpoDaiJkQDMiVZreWgo < 0)
		{
			bHrHatGdAhpoDaiJkQDMiVZreWgo = num2 - 1;
		}
		else if (bHrHatGdAhpoDaiJkQDMiVZreWgo >= num2)
		{
			bHrHatGdAhpoDaiJkQDMiVZreWgo = 0;
		}
		ELcxqnjIBKqLBxYuSmwWERrVPWMu eLcxqnjIBKqLBxYuSmwWERrVPWMu = aRETnZiTDlZYNoEeuTOdtgnZfaeo[bHrHatGdAhpoDaiJkQDMiVZreWgo];
		jXHkJDvAGIltUApkqEBXdSeOuwlLA = eLcxqnjIBKqLBxYuSmwWERrVPWMu.yhicbDjyGKhUgYmbAOJdueUvjYqM;
		bool flag = false;
		if (num != bHrHatGdAhpoDaiJkQDMiVZreWgo || guid != jXHkJDvAGIltUApkqEBXdSeOuwlLA)
		{
			flag = true;
		}
		if (num2 > 0)
		{
			ccXWCFxyzWyZDBAjBpaYTMeCQbwK.Append(num2).Append(" connected devices:\n");
		}
		for (int i = 0; i < num2; i++)
		{
			ccXWCFxyzWyZDBAjBpaYTMeCQbwK.Append(aRETnZiTDlZYNoEeuTOdtgnZfaeo[i].daoSvnTfYTUAaCJXGklyVPSSbAmL + "\n");
		}
		ccXWCFxyzWyZDBAjBpaYTMeCQbwK.Append("\n");
		ccXWCFxyzWyZDBAjBpaYTMeCQbwK.Append("Current SDL3 device ").Append(bHrHatGdAhpoDaiJkQDMiVZreWgo).Append(": \"")
			.Append(eLcxqnjIBKqLBxYuSmwWERrVPWMu.daoSvnTfYTUAaCJXGklyVPSSbAmL)
			.Append("\"\n");
		ccXWCFxyzWyZDBAjBpaYTMeCQbwK.Append("(Press + or - to change monitored device id.)\n\n");
		ybYiwlfiFklRbfvAwtKngvqqAKzWA("Product Name", "\"" + eLcxqnjIBKqLBxYuSmwWERrVPWMu.daoSvnTfYTUAaCJXGklyVPSSbAmL + "\"");
		ybYiwlfiFklRbfvAwtKngvqqAKzWA("Is Bluetooth Device", eLcxqnjIBKqLBxYuSmwWERrVPWMu.dexsMRpLwKOUSoLocjETHHnwoAZBA);
		ybYiwlfiFklRbfvAwtKngvqqAKzWA("Device Type", eLcxqnjIBKqLBxYuSmwWERrVPWMu.ItnCYRLJnKBmnpgFmcQWidYUVwVk.ToString());
		ybYiwlfiFklRbfvAwtKngvqqAKzWA("Product Id", eLcxqnjIBKqLBxYuSmwWERrVPWMu.OVQKsdpbdMzmshGknASsTZkRsrRK);
		ybYiwlfiFklRbfvAwtKngvqqAKzWA("Vendor Id", eLcxqnjIBKqLBxYuSmwWERrVPWMu.BhxIldEqUyqbetLRaeOhGmTOJbLJA);
		ybYiwlfiFklRbfvAwtKngvqqAKzWA("Serial", eLcxqnjIBKqLBxYuSmwWERrVPWMu.LXXyrJdNjVXGOQzagSSrotZAsgcC);
		ybYiwlfiFklRbfvAwtKngvqqAKzWA("Path", eLcxqnjIBKqLBxYuSmwWERrVPWMu.OCEbEtfBQbYzavNyEFadfKqcnWQyA);
		ybYiwlfiFklRbfvAwtKngvqqAKzWA("Motor Count", eLcxqnjIBKqLBxYuSmwWERrVPWMu.NTqOpHFbvHuyLbLaEdmbjLPuKsdI);
		ccXWCFxyzWyZDBAjBpaYTMeCQbwK.Append("\n");
		ybYiwlfiFklRbfvAwtKngvqqAKzWA("Axis Count", eLcxqnjIBKqLBxYuSmwWERrVPWMu.AcyBhZIsGMjxlZeMJKbUKUVxrNLkA);
		ybYiwlfiFklRbfvAwtKngvqqAKzWA("Button Count", eLcxqnjIBKqLBxYuSmwWERrVPWMu.SRVuCLhCpZdMYEgpAkVXiLKJPlHwA);
		ybYiwlfiFklRbfvAwtKngvqqAKzWA("Hat Count", eLcxqnjIBKqLBxYuSmwWERrVPWMu.gBQAhHZqEhmzzZdatQzUBwwjxfQG);
		ccXWCFxyzWyZDBAjBpaYTMeCQbwK.Append("\n");
		if (flag)
		{
			Logger.Log(string.Concat("" + "Device Name: \"" + eLcxqnjIBKqLBxYuSmwWERrVPWMu.daoSvnTfYTUAaCJXGklyVPSSbAmL + "\"\n", "Identifier: ", eLcxqnjIBKqLBxYuSmwWERrVPWMu.qtaMmMJdCHVLpnFhWSJFQyJUgzlq.ToString(), "\n"));
		}
		for (int j = 0; j < eLcxqnjIBKqLBxYuSmwWERrVPWMu.VCSrMqGhkXwhyzceIIHOMztZZsld; j++)
		{
			ybYiwlfiFklRbfvAwtKngvqqAKzWA("Axis " + j, eLcxqnjIBKqLBxYuSmwWERrVPWMu.tEMLhmWbGNkFOHKSEmsERrKUCRti(j) + " (" + eLcxqnjIBKqLBxYuSmwWERrVPWMu.esPPzTqcpnuQWEfhfrMGLsUqEhCh(j) + ")");
		}
		for (int k = 0; k < eLcxqnjIBKqLBxYuSmwWERrVPWMu.SlETggxFmtZKNrhpkGUsIavgapwu; k++)
		{
			ybYiwlfiFklRbfvAwtKngvqqAKzWA("Hat " + k, eLcxqnjIBKqLBxYuSmwWERrVPWMu.ERSfDsbkkVLoiGcHdodUPHGwspFFB(k));
		}
		string text = "";
		for (int l = 0; l < eLcxqnjIBKqLBxYuSmwWERrVPWMu.yFvlsWgHwliaKHPFCBOqdDAmQWIZ; l++)
		{
			if (eLcxqnjIBKqLBxYuSmwWERrVPWMu.zHldmjeUCpWmYMLuFdiOabeGgUQDB(l))
			{
				if (text != "")
				{
					text += ", ";
				}
				text += l;
			}
		}
		ybYiwlfiFklRbfvAwtKngvqqAKzWA("Buttons ", text);
		XPAZxDxbSzwQaSEOFueFPrrJduSg.text = ccXWCFxyzWyZDBAjBpaYTMeCQbwK.ToString();
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

	private void dOTlgUqLEgpBfMsgxIYlPetMAANH()
	{
		aRETnZiTDlZYNoEeuTOdtgnZfaeo = UIaUQjnhqylCmDWuEyzMDEEDCsYc.GetJoysticks<ELcxqnjIBKqLBxYuSmwWERrVPWMu>();
	}

	private void ukdlpEcPhxUtaCuIVLaVOEhItnyb()
	{
		yQfTthQVBLQgeCCqWRYgZQMkbLfg();
	}

	private void lAIgmcFrGhHLxPbqBaxMLLiLyJOKA()
	{
		yQfTthQVBLQgeCCqWRYgZQMkbLfg();
	}

	private void yQfTthQVBLQgeCCqWRYgZQMkbLfg()
	{
		AllrabAXCqcvAYahMwaCsnYdZUKv();
		DTbBZgsJFwYUznOhXFcDAtPcPnPV = true;
	}

	private void AllrabAXCqcvAYahMwaCsnYdZUKv()
	{
		bHrHatGdAhpoDaiJkQDMiVZreWgo = 0;
		jXHkJDvAGIltUApkqEBXdSeOuwlLA = Guid.Empty;
		aRETnZiTDlZYNoEeuTOdtgnZfaeo = null;
		DTbBZgsJFwYUznOhXFcDAtPcPnPV = false;
	}

	private void ybYiwlfiFklRbfvAwtKngvqqAKzWA(string P_0, object P_1)
	{
		ccXWCFxyzWyZDBAjBpaYTMeCQbwK.Append(P_0).Append(" = ").Append(P_1)
			.AppendLine();
	}
}
