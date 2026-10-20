using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_GamemodeScreen : MonoBehaviour, GamemodeHolder
{
	public static UI_GamemodeScreen instance;

	private M_Gamemode baseGamemode;

	public Dictionary<string, UI_GamemodeScreen_Panel> activePanels;

	public GameObject loadingText;

	public CanvasGroup gamemodeSelectorGroup;

	private UI_GamemodeScreen_Panel currentPanel;

	private CanvasGroup group;

	private void Awake()
	{
		instance = this;
		group = GetComponent<CanvasGroup>();
		base.gameObject.SetActive(value: false);
		activePanels = new Dictionary<string, UI_GamemodeScreen_Panel>();
	}

	public void Initialize(M_Gamemode mode)
	{
		if (currentPanel != null)
		{
			currentPanel.gameObject.SetActive(value: false);
		}
		baseGamemode = mode;
		if (!activePanels.ContainsKey(mode.gamemodePanel.id))
		{
			activePanels.Add(mode.gamemodePanel.id, Object.Instantiate(mode.gamemodePanel, base.transform));
			activePanels[mode.gamemodePanel.id].Initialize(this);
		}
		currentPanel = activePanels[mode.gamemodePanel.id];
		activePanels[mode.gamemodePanel.id].gameObject.SetActive(value: true);
		activePanels[mode.gamemodePanel.id].ModeSetup();
		OpenWindow();
		group.interactable = true;
		gamemodeSelectorGroup.interactable = false;
		currentPanel.firstSelect.Select();
		if (currentPanel.descriptionField != null)
		{
			currentPanel.descriptionField.text = baseGamemode.modeDescription;
		}
		CL_GameManager.gamemode = baseGamemode;
		CL_GameManager.gMan.baseGamemode = baseGamemode;
		if (mode.screenArt != null)
		{
			currentPanel.background.sprite = mode.screenArt;
		}
		RefreshCurrentGamemode();
		SettingsManager.RefreshSettings();
	}

	public void RefreshCurrentGamemode()
	{
		UT_StatText[] stats = currentPanel.GetStats();
		for (int i = 0; i < stats.Length; i++)
		{
			stats[i].RefreshText(baseGamemode.GetGamemodeName());
		}
		UI_GamemodeText[] componentsInChildren = GetComponentsInChildren<UI_GamemodeText>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].Refresh();
		}
		currentPanel.leaderboard.Refresh();
		bool flag = CL_SaveManager.SessionFileExists(baseGamemode.gamemodeName, CL_GameManager.IsHardmode());
		if (CL_GameManager.gamemode.IsCompetitive() || CL_GameManager.GetBaseGamemode().IsCompetitive())
		{
			flag = false;
		}
		foreach (GameObject hasSaveObject in currentPanel.hasSaveObjects)
		{
			hasSaveObject.SetActive(flag);
		}
		foreach (GameObject noSaveObject in currentPanel.noSaveObjects)
		{
			noSaveObject.SetActive(!flag);
		}
		if (flag)
		{
			currentPanel.continueButtonText.text = "Continue: " + CL_SaveManager.GetSessionArea(baseGamemode.gamemodeName, baseGamemode.IsHardMode());
		}
		StatManager.saveData.SetupGamemode(baseGamemode.GetGamemodeName());
		StatManager.refreshStatText?.Invoke();
	}

	public void LoadGamemode()
	{
		CL_GameManager.gamemode = baseGamemode;
		SceneManager.LoadScene(baseGamemode.gamemodeScene);
		loadingText.SetActive(value: true);
	}

	public void LoadGamemodeSave()
	{
		CL_SaveManager.loadSessionSaveOnLoad = true;
		LoadGamemode();
	}

	public void DeleteGamemodeSave()
	{
		CL_SaveManager.DeleteSessionSave(baseGamemode.gamemodeName, baseGamemode.IsHardMode());
		CL_SaveManager.isSavedRun = false;
	}

	public void CloseWindow()
	{
		currentPanel.closeEvent.Invoke();
		if (currentPanel.lerpOpen != null)
		{
			currentPanel.lerpOpen.Hide();
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
		gamemodeSelectorGroup.interactable = true;
		group.interactable = false;
	}

	public void OpenWindow()
	{
		base.gameObject.SetActive(value: true);
		if (currentPanel.lerpOpen != null)
		{
			currentPanel.lerpOpen.Show();
		}
		currentPanel.openEvent.Invoke();
	}

	public M_Gamemode GetGamemode()
	{
		return baseGamemode;
	}
}
