using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class App_Unlocker : MonoBehaviour
{
	private OS_Window window;

	private string password;

	public string flagOnUnlock;

	public string saveFlagOnUnlock;

	public TMP_InputField inputField;

	public UnityEvent hasFlagEvent;

	public UnityEvent unlockEvent;

	public UnityEvent failEvent;

	public GameObject authorizationWindow;

	public GameObject passcodeWindow;

	public TMP_Text authorizationTitleObject;

	public TMP_Text authorizationCostTextObject;

	public Button authorizationConfirmButton;

	public GameObject roachCounter;

	private string requireFlag;

	private bool unlocked;

	private bool showAuthorizationMenu;

	private int authorizationCost;

	private string authorizationTitle;

	private void Start()
	{
		window = GetComponent<OS_Window>();
		Dictionary<string, string> dictionary = DarkMachineFunctions.ParseKeyValueString(window.file.fileInfo.data);
		dictionary.TryGetValue("password", out password);
		if (dictionary.TryGetValue("passwordFlag", out var value))
		{
			password = CL_GameManager.GetGameFlag(value).data;
		}
		dictionary.TryGetValue("requireFlag", out requireFlag);
		dictionary.TryGetValue("unlockFlag", out flagOnUnlock);
		dictionary.TryGetValue("unlockSaveFlag", out saveFlagOnUnlock);
		dictionary.TryGetValue("authorizeOnFlag", out var value2);
		if (dictionary.TryGetValue("showAuthorizationMenu", out var value3))
		{
			showAuthorizationMenu = bool.Parse(value3);
		}
		if (dictionary.TryGetValue("authorizationCost", out var value4))
		{
			authorizationCost = int.Parse(value4);
		}
		dictionary.TryGetValue("authorizationTitle", out authorizationTitle);
		if (CL_GameManager.HasActiveFlag(flagOnUnlock, useUnlockAll: true) || CL_GameManager.HasActiveFlag(saveFlagOnUnlock, useUnlockAll: true))
		{
			hasFlagEvent.Invoke();
		}
		authorizationWindow.SetActive(value: false);
		if (!string.IsNullOrEmpty(value2) && CL_GameManager.HasActiveFlag(value2, useUnlockAll: true))
		{
			Debug.Log("Checking Authorization Flag: " + value2);
			CheckAuthorize();
		}
		roachCounter?.SetActive(value: false);
	}

	private void OnEnable()
	{
		inputField.ActivateInputField();
	}

	private void Update()
	{
	}

	public void Unlock()
	{
		if ((string.IsNullOrEmpty(requireFlag) || CL_GameManager.HasActiveFlag(requireFlag, useUnlockAll: true)) && !unlocked)
		{
			roachCounter?.SetActive(value: false);
			passcodeWindow.SetActive(value: true);
			authorizationWindow.SetActive(value: false);
			unlockEvent.Invoke();
			window.os.worldInterface.GetEventController().PlayEvent("unlock");
			unlocked = true;
			if (flagOnUnlock != null && flagOnUnlock != "")
			{
				CL_GameManager.SetGameFlag(flagOnUnlock, state: true);
			}
			if (saveFlagOnUnlock != null && saveFlagOnUnlock != "")
			{
				CL_GameManager.SetGameFlag(saveFlagOnUnlock, state: true, "", save: true);
			}
			CL_GameManager.AddRoaches(-authorizationCost);
		}
	}

	public void CheckAuthorize()
	{
		if (showAuthorizationMenu)
		{
			authorizationWindow.SetActive(value: true);
			passcodeWindow.SetActive(value: false);
			if (string.IsNullOrEmpty(authorizationTitle))
			{
				authorizationTitleObject.text = authorizationTitle;
			}
			if (authorizationCost > 0)
			{
				authorizationCostTextObject.transform.parent.gameObject.SetActive(value: true);
				roachCounter?.SetActive(value: true);
				if (CL_GameManager.GetRoaches() < authorizationCost)
				{
					authorizationConfirmButton.interactable = false;
					authorizationCostTextObject.text = $"<color=red>Cost: {authorizationCost}</color>";
				}
				else
				{
					authorizationCostTextObject.text = $"Cost: {authorizationCost}";
					authorizationConfirmButton.interactable = true;
				}
			}
			else
			{
				authorizationCostTextObject.transform.parent.gameObject.SetActive(value: false);
				roachCounter?.SetActive(value: false);
			}
		}
		else
		{
			Unlock();
		}
	}

	public void AuthorizeConfirm()
	{
	}

	public void CheckPassword()
	{
		if (inputField.text == password)
		{
			CheckAuthorize();
		}
		else
		{
			failEvent.Invoke();
		}
	}

	public void InputKey(string k)
	{
		if (k == "del")
		{
			if (inputField.text.Length > 0)
			{
				inputField.text = inputField.text.Remove(inputField.text.Length - 1);
			}
		}
		else if (inputField.text.Length < inputField.characterLimit)
		{
			inputField.text += k;
		}
	}
}
