using System.Collections.Generic;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;

internal sealed class FaXaygPpJAdhDKhdLKgIvJmmBCvT : IElementIdentifierTool
{
	private GUIText pWqRgMWflxdZgKbruGdCAjUFRYQf;

	private string DOlQJlgzVaqNrzJhLdNdgyplulFtA;

	private int uxbaiIfyZCNXdfvsYqDeBfiBtQss = 1;

	public void Initialize(GUIText text)
	{
		pWqRgMWflxdZgKbruGdCAjUFRYQf = text;
	}

	void IElementIdentifierTool.Initialize(GUIText text)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Initialize
		this.Initialize(text);
	}

	public void Start()
	{
		List<string> list = new List<string>();
		UnityInputHelper.GetJoystickNames(list);
		string text = "Detected " + list.Count + " attached joysticks";
		if (list.Count > 0)
		{
			text += ":\n";
		}
		foreach (string item in list)
		{
			text = text + "\"" + item + "\"\n";
		}
		Logger.Log(text);
	}

	void IElementIdentifierTool.Start()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Start
		this.Start();
	}

	public void Update()
	{
		if (UnityInputHelper.GetKeyDown(KeyboardKeyCode.Equals) || UnityInputHelper.GetKeyDown(KeyboardKeyCode.Plus) || UnityInputHelper.GetKeyDown(KeyboardKeyCode.KeypadPlus))
		{
			uxbaiIfyZCNXdfvsYqDeBfiBtQss++;
		}
		if (UnityInputHelper.GetKeyDown(KeyboardKeyCode.KeypadMinus) || UnityInputHelper.GetKeyDown(KeyboardKeyCode.Minus))
		{
			uxbaiIfyZCNXdfvsYqDeBfiBtQss--;
		}
		if (uxbaiIfyZCNXdfvsYqDeBfiBtQss <= 0)
		{
			uxbaiIfyZCNXdfvsYqDeBfiBtQss = 16;
		}
		else if (uxbaiIfyZCNXdfvsYqDeBfiBtQss > 16)
		{
			uxbaiIfyZCNXdfvsYqDeBfiBtQss = 1;
		}
		DOlQJlgzVaqNrzJhLdNdgyplulFtA = "Unity Joystick Element Identifier:\n\n";
		List<string> list = new List<string>();
		UnityInputHelper.GetJoystickNames(list);
		if (list.Count > 0)
		{
			DOlQJlgzVaqNrzJhLdNdgyplulFtA += "Connected joysticks:\n";
		}
		else
		{
			DOlQJlgzVaqNrzJhLdNdgyplulFtA += "No joysticks detected.\n";
		}
		for (int i = 0; i < list.Count; i++)
		{
			DOlQJlgzVaqNrzJhLdNdgyplulFtA = DOlQJlgzVaqNrzJhLdNdgyplulFtA + "[" + i + "] \"" + list[i] + "\"";
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(list[i]))
			{
				DOlQJlgzVaqNrzJhLdNdgyplulFtA += " [UNITY PRE-CONFIGURED]";
			}
			DOlQJlgzVaqNrzJhLdNdgyplulFtA += "\n";
		}
		DOlQJlgzVaqNrzJhLdNdgyplulFtA += "\n";
		DOlQJlgzVaqNrzJhLdNdgyplulFtA = DOlQJlgzVaqNrzJhLdNdgyplulFtA + "Current Unity Joystick Id: " + uxbaiIfyZCNXdfvsYqDeBfiBtQss + "\n";
		DOlQJlgzVaqNrzJhLdNdgyplulFtA += "(Press + or - to change monitored joystick id.)\n\n";
		for (int j = 0; j < 29; j++)
		{
			string text = "Axis " + j;
			float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(uxbaiIfyZCNXdfvsYqDeBfiBtQss, j);
			miKWRrWuCCVSReRoEnnJVAHcHYme(text, joystickAxisValueByJoystickId);
		}
		for (int k = 0; k < 20; k++)
		{
			string text2 = "Button " + k;
			bool joystickButtonValueByJoystickId = UnityInputHelper.GetJoystickButtonValueByJoystickId(uxbaiIfyZCNXdfvsYqDeBfiBtQss, k);
			miKWRrWuCCVSReRoEnnJVAHcHYme(text2, joystickButtonValueByJoystickId);
		}
		pWqRgMWflxdZgKbruGdCAjUFRYQf.text = DOlQJlgzVaqNrzJhLdNdgyplulFtA;
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

	private void miKWRrWuCCVSReRoEnnJVAHcHYme(string P_0, object P_1)
	{
		DOlQJlgzVaqNrzJhLdNdgyplulFtA = DOlQJlgzVaqNrzJhLdNdgyplulFtA + P_0 + " = " + P_1.ToString() + "\n";
	}
}
