using System;
using System.Collections.Generic;
using UnityEngine;

public class Message_Manager : MonoBehaviour
{
	[Serializable]
	public class MessageType
	{
		public string name;

		public Message messageAsset;
	}

	public class Message_Packet
	{
		public string type;

		public string message;

		public string closeText;

		public string aText;

		public Action closeFunction;

		public Action optionAFunction;

		public Vector2 screenPos;

		public List<string> data;
	}

	public Transform messageParent;

	public Transform blocker;

	public List<MessageType> messageTypes;

	public bool showingMessage;

	public void HideBlocker()
	{
		blocker.gameObject.SetActive(value: false);
		showingMessage = false;
	}

	public void ShowBlocker()
	{
		blocker.gameObject.SetActive(value: true);
		showingMessage = true;
	}

	public Message CreateMessage(Message_Packet packet)
	{
		foreach (MessageType messageType in messageTypes)
		{
			if (messageType.name == packet.type)
			{
				Message message = UnityEngine.Object.Instantiate(messageType.messageAsset, packet.screenPos, Quaternion.identity, messageParent);
				message.transform.localPosition = packet.screenPos;
				message.Initialize(packet);
				message.exitFunction = (Action)Delegate.Combine(message.exitFunction, new Action(HideBlocker));
				ShowBlocker();
				return message;
			}
		}
		Message message2 = UnityEngine.Object.Instantiate(messageTypes[0].messageAsset, packet.screenPos, Quaternion.identity, messageParent);
		message2.transform.localPosition = packet.screenPos;
		message2.Initialize(packet);
		message2.exitFunction = (Action)Delegate.Combine(message2.exitFunction, new Action(HideBlocker));
		ShowBlocker();
		Debug.Log("Showing Message");
		return message2;
	}

	public bool IsShowingMessage()
	{
		return showingMessage;
	}
}
