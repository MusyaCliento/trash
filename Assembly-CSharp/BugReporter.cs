using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class BugReporter
{
	public static void CreateBugReport()
	{
		try
		{
			string persistentDataPath = Application.persistentDataPath;
			string text = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
			string text2 = Path.Combine(persistentDataPath, "Reports", "Report-" + text);
			Directory.CreateDirectory(text2);
			string text3 = Path.Combine(persistentDataPath, "Player.log");
			string text4 = Path.Combine(persistentDataPath, "Player-prev.log");
			if (File.Exists(text3))
			{
				File.Copy(text3, Path.Combine(text2, "Player.log"), overwrite: true);
			}
			if (File.Exists(text4))
			{
				File.Copy(text4, Path.Combine(text2, "Player-prev.log"), overwrite: true);
			}
			if (File.Exists(Path.Combine(persistentDataPath, "wk_save.json")))
			{
				File.Copy(Path.Combine(persistentDataPath, "wk_save.json"), Path.Combine(text2, "wk_save.json"), overwrite: true);
			}
			if (File.Exists(Path.Combine(persistentDataPath, "settings.json")))
			{
				File.Copy(Path.Combine(persistentDataPath, "settings.json"), Path.Combine(text2, "settings.json"), overwrite: true);
			}
			File.WriteAllText(Path.Combine(text2, "sessionreport.txt"), GetBugReportString());
			CL_GameManager.gMan.UnPause();
			Screenshot.TakeScreenshot(1, text2);
			string text5 = text2.Replace("/", "\\");
			Process.Start("explorer.exe", "/select," + text5);
			CL_GameManager.gMan.StartCoroutine(WaitOneFrame());
			UnityEngine.Debug.Log("Bug report generated successfully at: " + text2);
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("Error creating bug report: " + ex.Message);
		}
		static IEnumerator WaitOneFrame()
		{
			yield return null;
			CL_GameManager.gMan.Pause();
		}
	}

	public static string GetBugReportString()
	{
		string text = "";
		List<string> list = new List<string>();
		list.Add("Report: " + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
		list.Add("Version: " + Application.version);
		list.Add("");
		list.Add("Gamemode: " + CL_GameManager.GetGamemodeName());
		list.Add($"Ascent: {CL_GameManager.gMan.GetPlayerAscent()}");
		list.Add($"Ascent Rate: {CL_GameManager.gMan.GetPlayerAscentRate()}");
		list.Add($"Travel Distance: {CL_GameManager.gMan.GetPlayerBestTravelDistance()}");
		list.Add($"Travel Speed: {CL_GameManager.gMan.GetPlayerTravelSpeed()}");
		list.Add($"Current Score: {CL_GameManager.gMan.GetPlayerAscentRate() * CL_GameManager.gMan.GetPlayerAscent()}");
		list.Add($"Player Corrected Height: {CL_GameManager.gMan.GetPlayerCorrectedHeight()}");
		list.Add($"Roaches: {CL_GameManager.GetRoaches()}");
		list.Add("");
		if (WorldLoader.initialized)
		{
			list.Add($"WorldLoader - Current Level: {WorldLoader.instance.GetCurrentLevel().GetLevel().levelName} @ {WorldLoader.instance.GetCurrentBranch().levelTracker.IndexOf(WorldLoader.instance.GetCurrentLevel())} || pos - {WorldLoader.instance.GetCurrentLevel().GetLevel().transform.position}");
			list.Add($"WorldLoader - Current Seed: {WorldLoader.instance.seed}");
			list.Add($"WorldLoader - Starting Seed: {WorldLoader.instance.startingSeed}");
			list.Add($"WorldLoader - Loaded Levels: {WorldLoader.instance.GetCurrentBranch().levelTracker.Count}");
			foreach (WorldLoader.LevelInfo item in WorldLoader.instance.GetCurrentBranch().levelTracker)
			{
				list.Add("Level - " + item.GetLevel().levelName);
			}
		}
		else
		{
			list.Add("WorldLoader: Not Initialized");
		}
		list.Add("");
		list.Add("Player Info");
		list.Add($"Player-Pos: {ENT_Player.playerObject.transform.position}");
		list.Add($"Player-Health: {ENT_Player.playerObject.health}");
		list.Add("Player-LastHit: " + ENT_Player.playerObject.GetLastHitSource());
		list.Add("--");
		list.Add($"Player-Perks: {ENT_Player.playerObject.perks.Count}");
		foreach (Perk perk in ENT_Player.playerObject.perks)
		{
			list.Add("Perk - " + perk.id);
		}
		list.Add("--");
		list.Add($"Player-Buffs: {ENT_Player.playerObject.curBuffs.currentBuffs.Count}");
		foreach (BuffContainer currentBuff in ENT_Player.playerObject.curBuffs.currentBuffs)
		{
			list.Add($"BuffContainer - {currentBuff.id} || Current Mult:{currentBuff.GetMultiplier()}");
			foreach (BuffContainer.Buff buff in currentBuff.buffs)
			{
				list.Add($"-- Buff - id: {buff.id} || amount: {buff.amount}");
			}
		}
		list.Add("--");
		list.Add($"Player-Items: {ENT_Player.GetInventory().GetItemCount()}");
		foreach (Item item2 in ENT_Player.GetInventory().GetItems())
		{
			list.Add("Item - " + item2.itemName);
		}
		list.Add("--");
		list.Add("");
		if (CL_ProgressionManager.instance != null)
		{
			list.Add($"Progression Unlocks: {CL_ProgressionManager.GetUnlockList().Count}");
			foreach (ProgressionUnlock unlock in CL_ProgressionManager.GetUnlockList())
			{
				list.Add($"Unlock - {unlock.id} || {unlock.CheckUnlock()}");
			}
		}
		list.Add("");
		if (CL_GameManager.gMan.sessionFlags != null)
		{
			list.Add($"Session Flags: {CL_GameManager.gMan.sessionFlags.Count}");
			foreach (CL_GameManager.SessionFlag sessionFlag in CL_GameManager.gMan.sessionFlags)
			{
				list.Add($"Flag - {sessionFlag.name} || {sessionFlag.state} || {sessionFlag.data}");
			}
		}
		list.Add("");
		if (DEN_DeathFloor.instance != null)
		{
			list.Add($"DeathGoo - Active: {DEN_DeathFloor.instance.IsActive()}");
			list.Add($"DeathGoo - Height: {DEN_DeathFloor.instance.transform.position.y}");
			list.Add($"DeathGoo - Speed: {DEN_DeathFloor.instance.GetCurrentSpeed()}");
			list.Add($"DeathGoo - Speed Multiplier: {DEN_DeathFloor.instance.GetCurrentSpeedMult()}");
		}
		list.Add("");
		if (CommandConsole.instance != null)
		{
			list.Add("Command Console: Active");
			foreach (string item3 in CommandConsole.instance.GetCommandHistory())
			{
				list.Add("CC || " + item3);
			}
		}
		foreach (string item4 in list)
		{
			text += item4;
			text += "\n";
		}
		return text;
	}
}
