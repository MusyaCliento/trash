using System;
using System.Collections.Generic;

[Serializable]
public class SessionEventModule_SendMessageToModules : SessionEventModule
{
	[Serializable]
	public class Message
	{
		public string targetID;

		public string message;
	}

	public List<Message> messages;

	public override void Initialize(SessionEvent s)
	{
		base.Initialize(s);
		Activate();
	}

	public override void Activate()
	{
		foreach (Message message in messages)
		{
			sessionEvent.SendMessageToModule(message.targetID, message.message);
		}
		base.Activate();
	}
}
