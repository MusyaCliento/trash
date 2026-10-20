using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class App_SavePage : MonoBehaviour
{
	[Serializable]
	public class Menu
	{
		public string name;

		public GameObject windowObject;

		public Selectable firstSelect;
	}

	public Button purchaseButton;

	public TMP_Text floppyText;

	public Transform diskCardParent;

	public App_SavePage_DiskCard cardPrefab;

	private List<App_SavePage_DiskCard> diskCards = new List<App_SavePage_DiskCard>();

	public List<Menu> menus;

	public OS_Window fulfillmentWindow;

	public OS_Window scanWindow;

	public OS_Window scanFinishWindow;

	public GameObject noDisksDetected;

	public AudioClip finishMindscanSound;

	private OS_Window window;

	private bool busy;

	private string currentMenu = "main";

	private void Awake()
	{
		window = GetComponent<OS_Window>();
		OS_Window oS_Window = window;
		oS_Window.openAction = (Action)Delegate.Combine(oS_Window.openAction, new Action(OnOpen));
	}

	private void OnOpen()
	{
		Debug.Log("Opened!");
		ChangeMenu(menus[0].name);
		UpdateSaveText();
		CheckIronKnuckle();
	}

	private void OnDisable()
	{
		CL_UIManager.instance.reviveGroup.gameObject.SetActive(value: false);
	}

	private void CheckIronKnuckle()
	{
		if (CL_GameManager.gamemode.IsCompetitive() || CL_GameManager.IsIronKnuckle())
		{
			Message_Manager.Message_Packet message_Packet = new Message_Manager.Message_Packet();
			message_Packet.type = "default";
			message_Packet.closeText = "Quit";
			message_Packet.closeFunction = window.CloseApp;
			if (CL_GameManager.IsIronKnuckle())
			{
				message_Packet.message = "You are playing in IRON KNUCKLE mode. Saves are not available.";
			}
			else
			{
				message_Packet.message = "You are playing in COMPETITIVE mode. Saves are not available.";
			}
			message_Packet.screenPos = new Vector2(0f, 0f);
			window.os.messageManager.CreateMessage(message_Packet);
		}
	}

	private void UpdateSaveText()
	{
		List<CL_SaveManager.SaveState> allSaveStatesByType = CL_SaveManager.GetAllSaveStatesByType(CL_SaveManager.SaveState.SaveType.disk);
		string text = "SAVES | <mspace=5>";
		int num = 0;
		string text2 = "";
		if (allSaveStatesByType.Count > 0)
		{
			foreach (CL_SaveManager.SaveState item in allSaveStatesByType)
			{
				if (window.os.worldInterface != null)
				{
					if (item.id == window.os.worldInterface.computerID)
					{
						_ = item.amount;
						text += $"{item.id}:<color=red>{item.amount}</color> ";
					}
					else
					{
						text2 += $"{item.id}:<color=red>{item.amount}</color> ";
						num += item.amount;
					}
				}
			}
			if (num > 0)
			{
				text += text2;
			}
		}
		else
		{
			text += "NO BACKUP DATA FOUND";
		}
		floppyText.text = text;
		if (diskCards.Count > 0)
		{
			for (int num2 = diskCards.Count - 1; num2 >= 0; num2--)
			{
				UnityEngine.Object.Destroy(diskCards[num2].gameObject);
			}
			diskCards.Clear();
		}
		List<Item> disks = OS_Manager.activeComputer.GetDiskController().GetDisks();
		foreach (Item item2 in disks)
		{
			App_SavePage_DiskCard app_SavePage_DiskCard = UnityEngine.Object.Instantiate(cardPrefab, diskCardParent);
			string diskName = "Untitled Disk";
			int capacity = 1;
			foreach (string datum in item2.data)
			{
				if (datum.Contains("name:"))
				{
					diskName = datum.Split(':')[1];
				}
				else if (datum.Contains("capacity:"))
				{
					capacity = int.Parse(datum.Split(':')[1]);
				}
			}
			app_SavePage_DiskCard.Initialize(diskName, capacity);
			diskCards.Add(app_SavePage_DiskCard);
		}
		if (disks.Count == 0 && currentMenu == "reformat")
		{
			ChangeMenu("nodisks");
		}
		else if (disks.Count > 0 && currentMenu == "nodisks")
		{
			ChangeMenu("reformat");
		}
	}

	public void AddSave(int capacity = 1)
	{
		CL_SaveManager.CreateOrUpdateSaveState(window.os.worldInterface.computerID, "disk", CL_SaveManager.SaveState.SaveType.disk, capacity);
		CL_SaveManager.instance.SaveSession(eraseStats: false, saveToFile: false, clearItems: false, "diskbackup", resetRoom: true);
		UpdateSaveText();
	}

	public void LoadSave()
	{
		window.os.Deactivate();
		CL_SaveManager.LoadSave(CL_SaveManager.GetSaveStateByID(window.os.worldInterface.computerID, CL_SaveManager.SaveState.SaveType.disk));
	}

	public void StartReformat()
	{
		List<Item> disks;
		if (!busy && !CL_GameManager.gamemode.IsCompetitive() && !CL_GameManager.IsIronKnuckle())
		{
			disks = window.os.GetDiskController().GetDisks();
			Message_Manager.Message_Packet message_Packet = new Message_Manager.Message_Packet();
			message_Packet.type = "default";
			message_Packet.closeText = "Proceed";
			message_Packet.aText = "Cancel";
			message_Packet.closeFunction = Reformat;
			message_Packet.optionAFunction = Cancel;
			message_Packet.message = "This will erase all data on these disks. Proceed?";
			message_Packet.screenPos = new Vector2(0f, 0f);
			window.os.messageManager.CreateMessage(message_Packet);
		}
		static void Cancel()
		{
		}
		void Finish()
		{
			foreach (Item item in disks)
			{
				int capacity = 1;
				foreach (string datum in item.data)
				{
					if (datum.Contains("capacity:"))
					{
						capacity = int.Parse(datum.Split(':')[1]);
					}
				}
				AddSave(capacity);
			}
			CL_SaveManager.instance.SaveLastSessionToFile(removeLastDisk: false);
			window.os.GetDiskController().WipeDisks();
			StartCoroutine(PurchaseSequence());
			ChangeMenu("main");
		}
		void Reformat()
		{
			Message_Manager.Message_Packet packet = new Message_Manager.Message_Packet
			{
				type = "loading",
				closeText = "OK",
				message = "Reformatting..",
				screenPos = new Vector2(0f, 0f),
				data = new List<string> { "0.25" },
				closeFunction = Finish
			};
			window.os.messageManager.CreateMessage(packet);
		}
	}

	public void ChangeMenu(string menuName)
	{
		if (busy)
		{
			return;
		}
		foreach (Menu menu in menus)
		{
			menu.windowObject.SetActive(menu.name == menuName);
			if (menu.name == menuName && menu.firstSelect != null)
			{
				menu.firstSelect.Select();
			}
		}
		currentMenu = menuName;
		UpdateSaveText();
		List<Item> disks = OS_Manager.activeComputer.GetDiskController().GetDisks();
		if (disks.Count == 0 && currentMenu == "reformat")
		{
			ChangeMenu("nodisks");
		}
		else if (disks.Count > 0 && currentMenu == "nodisks")
		{
			ChangeMenu("reformat");
		}
	}

	private IEnumerator PurchaseSequence()
	{
		busy = true;
		yield return new WaitForSeconds(0.5f);
		window.os.audioClipHandler.PlaySound("os:error");
		OS_Window purchaseWindow = window.os.CreateAppWindow(fulfillmentWindow, window.id + "-purchase");
		while (purchaseWindow != null)
		{
			yield return null;
		}
		window.os.audioClipHandler.PlaySound("save:startscan");
		OS_Window scan = window.os.CreateAppWindow(scanWindow, window.id + "-purchase");
		CL_CameraControl.Shake(0.005f);
		CL_UIManager.instance.reviveGroup.gameObject.SetActive(value: true);
		AudioSource reviveAudio = CL_UIManager.instance.reviveGroup.GetComponent<AudioSource>();
		while ((double)CL_UIManager.instance.reviveGroup.alpha < 0.5)
		{
			CL_UIManager.instance.reviveGroup.alpha += Time.unscaledDeltaTime * 0.2f;
			reviveAudio.volume += Time.unscaledDeltaTime * 0.2f;
			yield return null;
		}
		yield return new WaitForSeconds(3.5f);
		CL_CameraControl.Shake(0.005f);
		OS_Window scanFinish = window.os.CreateAppWindow(scanFinishWindow, window.id + "-scanFinish");
		scan.QuitApp();
		CL_GameManager.gMan.localPlayer.health = 1f;
		BuffContainer buffContainer = new BuffContainer();
		buffContainer.loseOverTime = true;
		buffContainer.loseRate = 0.05f;
		buffContainer.buffs = new List<BuffContainer.Buff>();
		buffContainer.buffs.Add(new BuffContainer.Buff
		{
			id = "roided",
			maxAmount = 0.5f
		});
		buffContainer.buffs.Add(new BuffContainer.Buff
		{
			id = "pilled",
			maxAmount = 0.5f
		});
		buffContainer.SetMultiplier(1f);
		buffContainer.Initialize();
		CL_GameManager.gMan.localPlayer.curBuffs.AddBuff(buffContainer);
		while (CL_UIManager.instance.reviveGroup.alpha > 0f)
		{
			CL_UIManager.instance.reviveGroup.alpha -= Time.unscaledDeltaTime * 0.5f;
			reviveAudio.volume -= Time.unscaledDeltaTime * 0.5f;
			yield return null;
		}
		CL_UIManager.instance.reviveGroup.gameObject.SetActive(value: false);
		window.os.audioClipHandler.PlaySound("save:endscan");
		while (scanFinish != null)
		{
			yield return null;
		}
		CL_CameraControl.Shake(0.005f);
		window.os.audioClipHandler.PlaySound("os:error");
		UpdateSaveText();
		busy = false;
		yield return new WaitForSeconds(0.5f);
		CL_UIManager.instance.reviveGroup.gameObject.SetActive(value: false);
		ChangeMenu("main");
	}
}
