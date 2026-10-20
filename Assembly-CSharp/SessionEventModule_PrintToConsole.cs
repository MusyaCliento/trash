using System;
using System.Collections.Generic;

[Serializable]
public class SessionEventModule_PrintToConsole : SessionEventModule
{
	public List<string> consoleMessages;

	public string consoleCommand;

	public override void Initialize(SessionEvent s)
	{
		base.Initialize(s);
		Activate();
	}

	public override void Activate()
	{
		if (consoleMessages.Count > 0)
		{
			foreach (string consoleMessage in consoleMessages)
			{
				CommandConsole.Log(consoleMessage);
			}
		}
		if (consoleCommand != "")
		{
			CommandConsole.instance.ExecuteCommand(consoleCommand, recordHistory: true);
		}
		base.Activate();
	}
}
