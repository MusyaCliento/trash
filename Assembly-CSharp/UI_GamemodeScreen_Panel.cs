using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_GamemodeScreen_Panel : MonoBehaviour, GamemodeHolder
{
	public string id;

	public Leaderboard_Panel leaderboard;

	public Image background;

	public UI_LerpOpen lerpOpen;

	public Selectable firstSelect;

	public Transform settingRoot;

	public UI_GamemodeSetting gamemodeSettingAsset;

	public UnityEvent openEvent;

	public UnityEvent closeEvent;

	public TMP_Text descriptionField;

	public GameObject gamemodeInfoPanel;

	public GameObject newGameSettingsPanel;

	public TMP_Text playText;

	public TMP_Text continueButtonText;

	public List<GameObject> hasSaveObjects;

	public List<GameObject> noSaveObjects;

	private UT_StatText[] stats;

	internal UI_GamemodeScreen gamemodeScreen;

	public void Initialize(UI_GamemodeScreen gS)
	{
		stats = GetComponentsInChildren<UT_StatText>();
		UT_StatText[] array = stats;
		foreach (UT_StatText obj in array)
		{
			obj.source = UT_StatText.StatSource.modeHolder;
			obj.SetHolder(this);
		}
		gamemodeScreen = gS;
		newGameSettingsPanel.SetActive(value: false);
		gamemodeInfoPanel.SetActive(value: true);
	}

	public void ModeSetup()
	{
		if (GetGamemode() == null)
		{
			Debug.LogError("Gamemode is null for gamemode panel " + id);
			playText.text = "Play";
		}
		else
		{
			playText.text = GetGamemode().newGameText;
			FillSettings();
		}
	}

	public UT_StatText[] GetStats()
	{
		return stats;
	}

	public void StartNewGameCheck()
	{
		newGameSettingsPanel.SetActive(value: false);
		gamemodeInfoPanel.SetActive(value: false);
		if (CL_OverlayUIManager.instance != null)
		{
			Message_Manager.Message_Packet packet = new Message_Manager.Message_Packet
			{
				type = "default",
				closeText = "<color=yellow>Nevermind",
				aText = "<color=red>Okay",
				message = "<color=red><b>Warning!</b></color>\n<color=yellow>This will erase your current saved run.",
				screenPos = new Vector2(0f, 0f),
				optionAFunction = StartNewGame,
				closeFunction = CloseSettingsPanel
			};
			CL_OverlayUIManager.instance.messageManager.CreateMessage(packet);
		}
	}

	public void StartNewGame()
	{
		UI_GamemodeScreen.instance.DeleteGamemodeSave();
		UI_GamemodeScreen.instance.RefreshCurrentGamemode();
		if (GetGamemode().useGamemodeSettings)
		{
			newGameSettingsPanel.SetActive(value: true);
			gamemodeInfoPanel.SetActive(value: false);
		}
		else
		{
			LoadGamemode();
		}
	}

	public void CloseSettingsPanel()
	{
		newGameSettingsPanel.SetActive(value: false);
		gamemodeInfoPanel.SetActive(value: true);
	}

	public void LoadGamemode()
	{
		StatManager.instance.SaveStats();
		UI_GamemodeScreen.instance.LoadGamemode();
	}

	public void LoadGamemodeSave()
	{
		UI_GamemodeScreen.instance.LoadGamemodeSave();
	}

	public void DeleteGamemodeSave()
	{
		UI_GamemodeScreen.instance.DeleteGamemodeSave();
	}

	public void CloseWindow()
	{
		UI_GamemodeScreen.instance.CloseWindow();
	}

	public M_Gamemode GetGamemode()
	{
		return UI_GamemodeScreen.instance.GetGamemode();
	}

	public void FillSettings()
	{
		Debug.Log("Child Count: " + settingRoot.childCount);
		foreach (Transform item in settingRoot)
		{
			Debug.Log("Destroying: " + item.name);
			Object.Destroy(item.gameObject);
		}
		foreach (GamemodeSetting gamemodeSetting in GetGamemode().gamemodeSettings)
		{
			UI_GamemodeSetting gamemodeButtonAsset = gamemodeSettingAsset;
			if (gamemodeSetting.gamemodeButtonAsset != null)
			{
				gamemodeButtonAsset = gamemodeSetting.gamemodeButtonAsset;
			}
			Object.Instantiate(gamemodeButtonAsset, settingRoot).Initialize(gamemodeSetting, this);
		}
	}
}
