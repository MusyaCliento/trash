using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GamemodeModule_Training : GamemodeModule
{
	public class SectorSettings
	{
		public bool race;

		public bool zoneClimbing = true;

		public bool zoneItems = true;

		public bool zoneMastery = true;

		public bool hazardFlood;

		public bool hazardBarnacles;

		public bool hazardDrones;

		public bool hazardTurrets;

		public float floodSpeed = 0.1f;
	}

	public class RoomScore
	{
		public string id;

		public float timeToBeat;
	}

	private List<RoomScore> roomScores;

	public static SectorSettings sectorSettings;

	public DEN_DeathFloor floodAsset;

	public float floodSpeedMult = 2f;

	public float winScoreMultiplier = 5f;

	public static SectorSettings GetSectorSettings()
	{
		if (sectorSettings == null)
		{
			sectorSettings = new SectorSettings();
		}
		return sectorSettings;
	}

	public static void UpdateSectorFlags()
	{
		CL_GameManager.SetGameFlag("race", sectorSettings.race);
		CL_GameManager.SetGameFlag("zoneClimbing", sectorSettings.zoneClimbing);
		CL_GameManager.SetGameFlag("zoneItems", sectorSettings.zoneItems);
		CL_GameManager.SetGameFlag("zoneMastery", sectorSettings.zoneMastery);
		CL_GameManager.SetGameFlag("hazardFlood", sectorSettings.hazardFlood);
		CL_GameManager.SetGameFlag("hazardBarnacles", sectorSettings.hazardBarnacles);
		CL_GameManager.SetGameFlag("hazardDrones", sectorSettings.hazardDrones);
		CL_GameManager.SetGameFlag("hazardTurrets", sectorSettings.hazardTurrets);
	}

	public override void Initialize(M_Gamemode gamemode)
	{
		base.Initialize(gamemode);
		if (sectorSettings == null)
		{
			sectorSettings = new SectorSettings();
		}
		roomScores = new List<RoomScore>();
		StatManager.SaveData.GameModeData gamemodeSaveData = gamemode.GetGamemodeSaveData();
		if (gamemodeSaveData != null)
		{
			Debug.Log((string)StatManager.GetStatisticValue(gamemodeSaveData.stats, "roomScoreData"));
		}
		UpdateSectorFlags();
	}

	public override void RunEvent(string e)
	{
		base.RunEvent(e);
		if (e == "start" && sectorSettings.hazardFlood)
		{
			DEN_DeathFloor dEN_DeathFloor = UnityEngine.Object.Instantiate(floodAsset, new Vector3(0f, -50f, 0f), Quaternion.identity);
			float num = Mathf.Max(floodSpeedMult, 0.05f);
			dEN_DeathFloor.speed *= sectorSettings.floodSpeed * num;
			dEN_DeathFloor.speedIncreaseRate *= sectorSettings.floodSpeed * num;
		}
	}

	public override void OnFinish(bool hasFinished)
	{
	}

	public override float GetScore(bool hasFinished = false)
	{
		float num = CL_GameManager.gMan.GetPlayerBestTravelDistance() * CL_GameManager.gMan.GetPlayerTravelSpeed();
		if (hasFinished)
		{
			num *= winScoreMultiplier;
		}
		return num;
	}
}
