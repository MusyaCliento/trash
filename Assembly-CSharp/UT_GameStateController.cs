using UnityEngine;

public class UT_GameStateController : MonoBehaviour
{
	public string state;

	public void Send()
	{
		CL_GameManager.ChangeState(state);
	}

	public void RestartScene()
	{
		CL_GameManager.ChangeState("restart");
	}

	public void LoadMainMenu()
	{
		CL_GameManager.gamemode = null;
		CL_GameManager.gMan.LoadScene("Main-Menu");
	}

	public void SetGamemode(M_Gamemode gamemode)
	{
		CL_GameManager.gMan.SetGamemode(gamemode);
	}

	public void LoadScene(string sceneName)
	{
		CL_GameManager.gMan.LoadScene(sceneName);
	}

	public void SetTimerState(bool b)
	{
		CL_GameManager.gMan.SetTimerState(b);
	}

	public void SetGameTimer(float f)
	{
		CL_GameManager.gMan.SetGameTime(f);
	}

	public void SetPause(bool b)
	{
		if (b)
		{
			CL_GameManager.gMan.Pause();
		}
		else
		{
			CL_GameManager.gMan.UnPause();
		}
	}

	public void ResetScores()
	{
		StatManager.instance.EraseStats();
		CL_GameManager.gMan.LoadScene("Main-Menu");
	}

	public void ResetWorld(bool keepItems = false)
	{
		CL_SaveManager.SaveState save = (keepItems ? CL_SaveManager.CreateOrUpdateSaveState("reset", "reset", CL_SaveManager.SaveState.SaveType.resetwithitems) : CL_SaveManager.CreateOrUpdateSaveState("reset", "reset", CL_SaveManager.SaveState.SaveType.reset));
		CL_SaveManager.LoadSave(save);
	}

	public void RefreshStatText()
	{
		if (StatManager.refreshStatText != null)
		{
			StatManager.refreshStatText();
		}
	}

	public void SetWhiteOutFade(float f)
	{
		CL_UIManager.instance.SetVignetteTarget("whiteout", f);
	}

	public void SetBlackOutFade(float f)
	{
		CL_UIManager.instance.SetVignetteTarget("fade", f);
	}

	public void CutToBlack()
	{
		CL_UIManager.instance.SetVignette("fade", 1f);
	}

	public void FlashVignette(string n)
	{
		CL_UIManager.instance.FlashVignette(n);
	}

	public void QuickFlashVignette(string n)
	{
		CL_UIManager.instance.QuickFlashVignette(n);
	}

	public void CreateBugReport()
	{
		BugReporter.CreateBugReport();
	}

	public void SetPresetSeed(string s)
	{
		WorldLoader.SetPresetSeed(s);
	}

	public void SetSafe(bool b)
	{
		CL_GameManager.SetSafe(b);
	}

	public void DeleteSave()
	{
		CL_SaveManager.DeleteSessionSave(CL_GameManager.GetGamemodeName(includeOptions: false, mainMode: true), CL_GameManager.IsHardmode());
		CL_SaveManager.isSavedRun = false;
	}

	public void SaveRun(bool clearStats = true)
	{
		CL_SaveManager.instance.SaveSession(clearStats);
	}

	public void SaveLastSessionToFile()
	{
		CL_SaveManager.instance.SaveLastSessionToFile();
	}

	public void UnsafeExit()
	{
		CL_SaveManager.instance.SaveLastSessionToFile(removeLastDisk: true, ENT_Player.GetPlayer().HasPerk("Perk_AnomalousBonds"));
		StatManager.sessionStats = new StatManager.GameStats();
		LoadMainMenu();
	}

	public void SaveStats()
	{
		StatManager.instance.SaveStats();
	}

	public void SaveAdjustedStats()
	{
		StatManager.instance.SaveStats(writeAll: false);
	}

	public void ClearSessionStats()
	{
		StatManager.sessionStats = new StatManager.GameStats();
	}

	public void StopAllWorldEvents()
	{
		CL_EventManager.StopAllEvents();
	}

	public void SetRoaches(int i)
	{
		CL_GameManager.SetRoaches(i);
	}

	public void KillPlayer()
	{
		ENT_Player.playerObject.Kill("", null);
	}

	public void RemoveRevives()
	{
		CL_SaveManager.saveStates.Clear();
	}

	public void LoadGamemode(M_Gamemode gm)
	{
		CL_GameManager.gamemode = gm;
		CL_GameManager.gMan.LoadScene(gm.gamemodeScene);
	}

	public void Win()
	{
		CL_GameManager.gMan.Win();
	}
}
