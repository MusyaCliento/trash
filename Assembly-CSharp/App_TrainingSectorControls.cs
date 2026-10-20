using System.Collections.Generic;
using DarkMachine.UI;
using UnityEngine;

public class App_TrainingSectorControls : MonoBehaviour
{
	public List<M_Region> sectorRegions;

	public Dictionary<string, App_TrainingSectorControls_Toggle> toggleList;

	public SubmitSlider floodSpeedSlider;

	private void Start()
	{
		floodSpeedSlider.value = GamemodeModule_Training.GetSectorSettings().floodSpeed;
		UpdateToggles();
	}

	public void AddToggle(App_TrainingSectorControls_Toggle toggle)
	{
		if (toggleList == null)
		{
			toggleList = new Dictionary<string, App_TrainingSectorControls_Toggle>();
		}
		toggleList.Add(toggle.id, toggle);
	}

	public void UpdateToggles()
	{
		UpdateToggleState("modeStandard", !GamemodeModule_Training.GetSectorSettings().race);
		UpdateToggleState("modeRace", GamemodeModule_Training.GetSectorSettings().race);
		if (!GamemodeModule_Training.GetSectorSettings().zoneClimbing && !GamemodeModule_Training.GetSectorSettings().zoneItems && !GamemodeModule_Training.GetSectorSettings().zoneMastery)
		{
			GamemodeModule_Training.GetSectorSettings().zoneClimbing = true;
		}
		if (GamemodeModule_Training.GetSectorSettings().race)
		{
			GamemodeModule_Training.GetSectorSettings().hazardBarnacles = false;
			GamemodeModule_Training.GetSectorSettings().hazardFlood = false;
			GamemodeModule_Training.GetSectorSettings().hazardDrones = false;
			GamemodeModule_Training.GetSectorSettings().hazardTurrets = false;
		}
		UpdateToggleState("zoneClimbing", GamemodeModule_Training.GetSectorSettings().zoneClimbing);
		UpdateToggleState("zoneItems", GamemodeModule_Training.GetSectorSettings().zoneItems);
		UpdateToggleState("zoneMastery", GamemodeModule_Training.GetSectorSettings().zoneMastery);
		UpdateToggleState("hazardBarnacles", GamemodeModule_Training.GetSectorSettings().hazardBarnacles);
		UpdateToggleState("hazardFlood", GamemodeModule_Training.GetSectorSettings().hazardFlood);
		UpdateToggleState("hazardDrones", GamemodeModule_Training.GetSectorSettings().hazardDrones);
		UpdateToggleState("hazardTurrets", GamemodeModule_Training.GetSectorSettings().hazardTurrets);
		GamemodeModule_Training.GetSectorSettings().floodSpeed = floodSpeedSlider.value;
		UpdateInteractableState("hazardBarnacles", !GamemodeModule_Training.GetSectorSettings().race);
		UpdateInteractableState("hazardFlood", !GamemodeModule_Training.GetSectorSettings().race);
		UpdateInteractableState("hazardDrones", !GamemodeModule_Training.GetSectorSettings().race && CL_AchievementManager.GetAchievementValue("ACH_PIPEWORKS"));
		UpdateInteractableState("hazardTurrets", !GamemodeModule_Training.GetSectorSettings().race && CL_AchievementManager.GetAchievementValue("ACH_HABITATION"));
		floodSpeedSlider.interactable = !GamemodeModule_Training.GetSectorSettings().race && GamemodeModule_Training.GetSectorSettings().hazardFlood;
		GamemodeModule_Training.UpdateSectorFlags();
	}

	private void UpdateToggleState(string id, bool b)
	{
		if (toggleList.ContainsKey(id) && toggleList[id].GetToggle().isOn != b)
		{
			Debug.Log("Updating Toggle State: " + id + " :: " + b);
			toggleList[id].GetToggle().SetIsOnWithoutNotify(b);
		}
	}

	private void UpdateInteractableState(string id, bool b)
	{
		if (toggleList.ContainsKey(id) && toggleList[id].GetToggle().interactable != b)
		{
			toggleList[id].SetInteractable(b);
		}
	}

	public void ToggleSetting(string id, bool b)
	{
		switch (id)
		{
		case "modeStandard":
			GamemodeModule_Training.GetSectorSettings().race = false;
			break;
		case "modeRace":
			GamemodeModule_Training.GetSectorSettings().race = true;
			break;
		case "zoneClimbing":
			GamemodeModule_Training.GetSectorSettings().zoneClimbing = b;
			break;
		case "zoneItems":
			GamemodeModule_Training.GetSectorSettings().zoneItems = b;
			break;
		case "zoneMastery":
			GamemodeModule_Training.GetSectorSettings().zoneMastery = b;
			break;
		case "hazardBarnacles":
			GamemodeModule_Training.GetSectorSettings().hazardBarnacles = b;
			break;
		case "hazardDrones":
			GamemodeModule_Training.GetSectorSettings().hazardDrones = b;
			break;
		case "hazardFlood":
			GamemodeModule_Training.GetSectorSettings().hazardFlood = b;
			break;
		case "hazardTurrets":
			GamemodeModule_Training.GetSectorSettings().hazardTurrets = b;
			break;
		}
		UpdateToggles();
	}
}
