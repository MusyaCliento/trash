using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_TrinketPicker : MonoBehaviour
{
	public UI_GamemodeScreen_Panel parentPanel;

	public UI_TrinketPicker_Icon iconPrefab;

	public Transform trinketIconRoot;

	public Transform bindingIconRoot;

	public TMP_Text scoreMultiplierText;

	public TMP_Text descriptionText;

	public TMP_Text costText;

	public Transform pipHolder;

	public Image pipPrefab;

	public Sprite filledPipSprite;

	public Sprite emptyPipSprite;

	private List<Image> pips = new List<Image>();

	public Button playButton;

	public List<Trinket> selectedTrinkets = new List<Trinket>();

	public List<UI_TrinketPicker_Icon> trinketIcons = new List<UI_TrinketPicker_Icon>();

	public AudioClip trinketSelectClip;

	public AudioClip trinketDeselectClip;

	public AudioClip bindingSelectClip;

	public AudioClip bindingDeselectClip;

	private M_Gamemode currentGamemode;

	private float prevMult = 1f;

	private int lastUsedBudget;

	private int lastTotalBudget;

	private Coroutine hideTrinketDecriptionCoroutine;

	private TweenerCore<Color, Color, ColorOptions> currentColorBlend;

	public void Initialize()
	{
		if (parentPanel != null)
		{
			currentGamemode = parentPanel.GetGamemode();
		}
		else
		{
			currentGamemode = CL_GameManager.GetBaseGamemode();
		}
		ReloadTrinkets();
	}

	private void OnEnable()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Combine(SettingsManager._OnRefreshAllSettings, new Action(ReloadTrinkets));
	}

	private void OnDisable()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Remove(SettingsManager._OnRefreshAllSettings, new Action(ReloadTrinkets));
	}

	public void ReloadTrinkets()
	{
		selectedTrinkets.Clear();
		if (currentGamemode.availableTrinkets != null)
		{
			List<Trinket> trinkets = currentGamemode.availableTrinkets.trinkets;
			PopulateTrinkets(trinkets, trinketIconRoot, allowInIronKnuckle: false);
			List<Trinket> bindings = currentGamemode.availableTrinkets.bindings;
			PopulateTrinkets(bindings, bindingIconRoot);
			descriptionText.text = "";
		}
		else
		{
			PopulateTrinkets(null, trinketIconRoot);
			PopulateTrinkets(null, bindingIconRoot);
			descriptionText.text = "No trinkets available for this gamemode.";
			costText.text = "";
			playButton.interactable = true;
		}
		if (currentGamemode.IsIronKnuckle())
		{
			descriptionText.text = "Trinkets are not available in Iron Knuckle";
		}
		UpdateTrinketActivation();
	}

	public void PopulateTrinkets(List<Trinket> trinketsToPopulate, Transform root = null, bool allowInIronKnuckle = true)
	{
		foreach (Transform item in root)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
		if (trinketsToPopulate == null || trinketsToPopulate.Count == 0 || (!allowInIronKnuckle && currentGamemode.IsIronKnuckle()))
		{
			return;
		}
		string gamemodeName = currentGamemode.GetGamemodeName();
		List<string> gamemodeTrinkets = StatManager.saveData.GetGamemodeTrinkets(gamemodeName);
		foreach (Trinket item2 in trinketsToPopulate)
		{
			bool flag = true;
			foreach (string item3 in item2.settingBlacklist)
			{
				if (currentGamemode.HasActiveSetting(item3))
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				UI_TrinketPicker_Icon uI_TrinketPicker_Icon = UnityEngine.Object.Instantiate(iconPrefab, root);
				uI_TrinketPicker_Icon.SetTrinket(item2, this);
				trinketIcons.Add(uI_TrinketPicker_Icon);
				if (gamemodeTrinkets.Contains(item2.name) && !selectedTrinkets.Contains(item2) && item2.IsUnlocked())
				{
					selectedTrinkets.Add(item2);
				}
			}
		}
	}

	public void HoverTrinket(Trinket t)
	{
		ShowTrinketDescription(t);
	}

	public void SelectTrinket(Trinket t)
	{
		ShowTrinketDescription(t);
		int num = 0;
		int num2 = 1;
		bool flag = false;
		if (selectedTrinkets.Contains(t))
		{
			selectedTrinkets.Remove(t);
			flag = true;
			AudioManager.PlayUISound(t.isBinding ? bindingDeselectClip : trinketDeselectClip);
		}
		if (!flag && !selectedTrinkets.Contains(t))
		{
			AudioManager.PlayUISound(t.isBinding ? bindingSelectClip : trinketSelectClip);
		}
		foreach (Trinket selectedTrinket in selectedTrinkets)
		{
			if (!selectedTrinket.isBinding)
			{
				num += selectedTrinket.cost;
			}
			else
			{
				num2 += selectedTrinket.cost;
			}
		}
		if (!flag)
		{
			if (t.isBinding)
			{
				num2 += t.cost;
			}
			else
			{
				num += t.cost;
			}
		}
		if (!selectedTrinkets.Contains(t) && !flag)
		{
			selectedTrinkets.Add(t);
		}
		if (num <= num2)
		{
			costText.text = "";
			List<string> list = new List<string>();
			foreach (Trinket selectedTrinket2 in selectedTrinkets)
			{
				list.Add(selectedTrinket2.name);
			}
			StatManager.saveData.SetGamemodeTrinkets(currentGamemode.GetGamemodeName(), list);
			playButton.interactable = true;
		}
		else
		{
			List<string> list2 = new List<string>();
			foreach (Trinket selectedTrinket3 in selectedTrinkets)
			{
				list2.Add(selectedTrinket3.name);
			}
			StatManager.saveData.SetGamemodeTrinkets(currentGamemode.GetGamemodeName(), list2);
			costText.text = "<color=\"red\">Too expensive!";
			playButton.interactable = false;
		}
		UpdateTrinketActivation();
	}

	private void UpdateTrinketActivation()
	{
		foreach (UI_TrinketPicker_Icon trinketIcon in trinketIcons)
		{
			bool flag = false;
			foreach (Trinket selectedTrinket in selectedTrinkets)
			{
				if (trinketIcon.trinket == selectedTrinket)
				{
					flag = true;
				}
			}
			if (flag)
			{
				trinketIcon.Activate();
			}
			else
			{
				trinketIcon.Deactivate();
			}
		}
		int num = 0;
		int num2 = 1;
		foreach (Trinket selectedTrinket2 in selectedTrinkets)
		{
			if (selectedTrinket2.isBinding)
			{
				num2++;
			}
			else
			{
				num++;
			}
		}
		Trinket.ScoreCalc scoreCalc = Trinket.CalculateScoreFromTrinkets(selectedTrinkets);
		float num3 = 1f + scoreCalc.bindingValue + scoreCalc.trinketValue;
		if (num > num2)
		{
			costText.text = "<color=\"red\">Too expensive!";
			playButton.interactable = false;
		}
		else
		{
			costText.text = "";
			playButton.interactable = true;
		}
		UpdatePips(num2, num);
		scoreMultiplierText.text = Math.Round(num3, 2) + "X";
		float num4 = num3 - prevMult;
		if (num4 != 0f)
		{
			num4 *= 0.5f;
			DOTween.Complete(scoreMultiplierText.transform);
			scoreMultiplierText.transform.localScale = Vector3.one;
			scoreMultiplierText.transform.DOPunchScale(Vector3.one * num4, 0.3f, 5, 0.5f).SetUpdate(isIndependentUpdate: true);
		}
		prevMult = num3;
	}

	private void UpdatePips(int totalBudget, int usedBudget)
	{
		if (pips.Count > Mathf.Max(totalBudget, usedBudget))
		{
			for (int num = pips.Count - 1; num >= Mathf.Max(totalBudget, usedBudget); num--)
			{
				UnityEngine.Object.Destroy(pips[num].gameObject);
				pips.RemoveAt(num);
			}
		}
		for (int i = 0; i < Mathf.Max(totalBudget, usedBudget); i++)
		{
			if (i >= pips.Count)
			{
				Image image = UnityEngine.Object.Instantiate(pipPrefab, pipHolder);
				pips.Add(image);
				image.gameObject.SetActive(value: true);
			}
			if (i >= usedBudget)
			{
				pips[i].sprite = emptyPipSprite;
			}
			else
			{
				pips[i].sprite = filledPipSprite;
			}
			if (i >= totalBudget)
			{
				pips[i].color = Color.red;
			}
			else
			{
				pips[i].color = Color.white;
			}
			if (lastTotalBudget != totalBudget && i == totalBudget - 1)
			{
				DOTween.Complete(pips[i].transform);
				pips[i].transform.localScale = Vector3.one;
				pips[i].transform.DOPunchScale(Vector3.one * 0.2f, 0.5f).SetUpdate(isIndependentUpdate: true);
			}
			if (lastUsedBudget != usedBudget && i == usedBudget - 1)
			{
				DOTween.Complete(pips[i].transform);
				pips[i].transform.localScale = Vector3.one;
				pips[i].transform.DOPunchScale(Vector3.one * 0.2f, 0.5f).SetUpdate(isIndependentUpdate: true);
			}
		}
		lastTotalBudget = totalBudget;
		lastUsedBudget = usedBudget;
	}

	public void ShowTrinketDescription(Trinket t)
	{
		descriptionText.text = t.GetDescription();
		DOTween.Kill(currentColorBlend);
		currentColorBlend = descriptionText.DOColor(Color.white, 0.5f).SetUpdate(isIndependentUpdate: true);
	}

	public void ShowDescription(string desc)
	{
		descriptionText.text = desc;
		DOTween.Kill(currentColorBlend);
		currentColorBlend = descriptionText.DOColor(Color.white, 0.5f).SetUpdate(isIndependentUpdate: true);
	}

	public void HideDescription()
	{
		DOTween.Kill(currentColorBlend);
		currentColorBlend = descriptionText.DOColor(Color.clear, 0.5f).SetUpdate(isIndependentUpdate: true);
	}

	private void Update()
	{
	}
}
