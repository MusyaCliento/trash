using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
	public string messageText;

	public TMP_Text textObject;

	public TMP_Text closeText;

	public TMP_Text optionAText;

	internal Action closeFunction;

	internal Action optionAFunction;

	public Action exitFunction;

	public Selectable firstSelect;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void CloseMessage(string s)
	{
		if (closeFunction != null)
		{
			closeFunction();
		}
		exitFunction();
		UnityEngine.Object.Destroy(base.gameObject);
		if (OS_Manager.activeComputer != null)
		{
			OS_Manager.soundPlayer.PlaySound("os:app-button");
		}
	}

	public void OptionA(string s)
	{
		if (optionAFunction != null)
		{
			optionAFunction();
		}
		exitFunction();
		UnityEngine.Object.Destroy(base.gameObject);
		if (OS_Manager.activeComputer != null)
		{
			OS_Manager.soundPlayer.PlaySound("os:app-button");
		}
	}

	public virtual void Initialize(string message, string closeString)
	{
		textObject.text = message;
		closeText.text = closeString;
		firstSelect.Select();
	}

	public virtual void Initialize(string message, Action cF, string closeString)
	{
		textObject.text = message;
		closeFunction = cF;
		closeText.text = closeString;
		firstSelect.Select();
	}

	public virtual void Initialize(string message, Action cF, string closeString, Action aF, string aString)
	{
		textObject.text = message;
		closeFunction = cF;
		closeText.text = closeString;
		optionAFunction = aF;
		optionAText.text = aString;
		optionAText.transform.parent.gameObject.SetActive(value: true);
		firstSelect.Select();
	}

	public virtual void Initialize(Message_Manager.Message_Packet packet)
	{
		textObject.text = packet.message;
		if (packet.closeFunction != null)
		{
			closeFunction = packet.closeFunction;
		}
		closeText.text = packet.closeText;
		if (packet.optionAFunction != null)
		{
			optionAFunction = packet.optionAFunction;
			optionAText.text = packet.aText;
			optionAText.transform.parent.gameObject.SetActive(value: true);
		}
		else
		{
			optionAText.transform.parent.gameObject.SetActive(value: false);
		}
		firstSelect.Select();
	}
}
