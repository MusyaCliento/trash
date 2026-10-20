using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Gamemode_Button : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, GamemodeHolder
{
	public M_Gamemode gamemode;

	private UI_GamemodeScreen gamemodeScreen;

	private UT_StatText[] stats;

	private bool initialized;

	public TMP_Text title;

	public UI_LerpOpen runInProgressDisplay;

	public TMP_Text roachCounter;

	public GameObject roachCounterRoot;

	public bool showMedals;

	public List<Sprite> medals;

	public Image medalImage;

	private UI_CapsuleButton capsule;

	public TMP_Text unlockText;

	private bool isHovering;

	private void Awake()
	{
		stats = GetComponentsInChildren<UT_StatText>();
		capsule = GetComponent<UI_CapsuleButton>();
		capsule.unlockAchievement = gamemode.unlockAchievement;
		unlockText.text = gamemode.unlockHint;
		if (gamemode.hiddenUntilUnlocked)
		{
			base.gameObject.SetActive(value: false);
		}
		if (!showMedals)
		{
			return;
		}
		int num = ChallengeMode.GetMedalRankFromGamemode(gamemode) - 1;
		if (gamemode.HasWonGamemode() && num >= 0)
		{
			Debug.Log(num);
			if (num >= medals.Count)
			{
				num = 0;
			}
			medalImage.sprite = medals[num];
			medalImage.gameObject.SetActive(value: true);
		}
	}

	private void OnEnable()
	{
		if (!initialized && (bool)UI_GamemodeScreen.instance)
		{
			gamemodeScreen = UI_GamemodeScreen.instance;
			Initialize();
		}
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Combine(SettingsManager._OnRefreshAllSettings, new Action(UpdateOnSettingsRefresh));
	}

	private void OnDisable()
	{
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Remove(SettingsManager._OnRefreshAllSettings, new Action(UpdateOnSettingsRefresh));
	}

	private void UpdateOnSettingsRefresh()
	{
		if (runInProgressDisplay != null)
		{
			bool flag = CL_SaveManager.SessionFileExists(gamemode.gamemodeName, gamemode.IsHardMode());
			if (gamemode.IsCompetitive() || CL_GameManager.GetBaseGamemode().IsCompetitive())
			{
				flag = false;
			}
			if (flag)
			{
				runInProgressDisplay.Show();
				title.color = new Color(1f, 0.52f, 0f);
			}
			else
			{
				runInProgressDisplay.Hide();
				title.color = Color.white;
			}
		}
		if (roachCounter != null)
		{
			int value = StatManager.saveData.GetRoachBankByID(gamemode.GetRoachBankID()).value;
			if (value <= 0 || !gamemode.showBankAmount)
			{
				roachCounterRoot.SetActive(value: false);
			}
			else
			{
				roachCounterRoot.SetActive(value: true);
			}
			roachCounter.text = value.ToString() ?? "";
		}
	}

	private void Update()
	{
		if (!initialized && (bool)UI_GamemodeScreen.instance)
		{
			gamemodeScreen = UI_GamemodeScreen.instance;
			Initialize();
		}
	}

	public void Initialize()
	{
		initialized = true;
		GetComponent<Button>().onClick.AddListener(delegate
		{
			gamemodeScreen.Initialize(gamemode);
		});
		GetComponent<Image>().sprite = gamemode.capsuleArt;
		if (gamemode.useCustomCapsuleName && (gamemode.capsuleName != null || gamemode.capsuleName != ""))
		{
			title.text = gamemode.capsuleName;
		}
		else
		{
			title.text = gamemode.gamemodeName;
		}
		UT_StatText[] array = stats;
		for (int num = 0; num < array.Length; num++)
		{
			array[num].RefreshText(gamemode.gamemodeName);
		}
		UpdateOnSettingsRefresh();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		isHovering = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		isHovering = false;
	}

	public void OnSelect(BaseEventData data)
	{
		isHovering = true;
	}

	public void OnDeselect(BaseEventData data)
	{
		isHovering = false;
	}

	public M_Gamemode GetGamemode()
	{
		return gamemode;
	}
}
