using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_GamemodeSetting : MonoBehaviour
{
	public GamemodeSetting gamemodeSetting;

	public Toggle toggle;

	public GameObject lockObject;

	public TMP_Text titleText;

	public TMP_Text descriptionText;

	public TMP_Text unlockHint;

	private UI_GamemodeScreen_Panel gamemodePanel;

	public Image outline;

	private bool hasBeenDestroyed;

	private bool hasInitialized;

	public int unselectedHeight = 48;

	public int selectedHeight = 48;

	public UnityEvent onActivated;

	public UnityEvent onDeactivated;

	private static Action refresh;

	public void Initialize(GamemodeSetting setting, UI_GamemodeScreen_Panel gp)
	{
		if (!hasInitialized)
		{
			gamemodeSetting = setting;
			gamemodePanel = gp;
			bool flag = gamemodeSetting.unlock.CheckUnlock();
			if (!flag)
			{
				StatManager.saveData.SetSetting(gamemodePanel.GetGamemode().gamemodeName, gamemodeSetting.id, state: false);
			}
			bool isOn = gamemodePanel.GetGamemode().HasActiveSetting(gamemodeSetting.id);
			toggle.isOn = isOn;
			titleText.text = gamemodeSetting.title;
			descriptionText.text = gamemodeSetting.description;
			unlockHint.text = gamemodeSetting.unlock.unlockHint;
			if (gamemodeSetting.unlock.showProgression)
			{
				TMP_Text tMP_Text = unlockHint;
				tMP_Text.text = tMP_Text.text + ": " + gamemodeSetting.unlock.GetProgressString();
			}
			lockObject.SetActive(!flag);
			UpdateColor();
			toggle.onValueChanged.AddListener(ToggleSetting);
			refresh = (Action)Delegate.Combine(refresh, new Action(UpdateColor));
			hasInitialized = false;
		}
	}

	private void OnDestroy()
	{
		refresh = (Action)Delegate.Remove(refresh, new Action(UpdateColor));
		hasBeenDestroyed = true;
	}

	private void UpdateColor()
	{
		if (hasBeenDestroyed || toggle == null || outline == null)
		{
			return;
		}
		RectTransform component = GetComponent<RectTransform>();
		Vector2 sizeDelta = component.sizeDelta;
		if (selectedHeight != unselectedHeight)
		{
			if (toggle.isOn)
			{
				sizeDelta.y = selectedHeight;
			}
			else
			{
				sizeDelta.y = unselectedHeight;
			}
			component.DOSizeDelta(sizeDelta, 0.5f);
		}
		if (toggle.isOn)
		{
			onActivated.Invoke();
		}
		else
		{
			onDeactivated.Invoke();
		}
		Color color = gamemodeSetting.color;
		if (!toggle.isOn)
		{
			color *= Color.grey;
		}
		bool flag = gamemodeSetting.unlock.CheckUnlock();
		bool flag2 = false;
		foreach (string exclusiveSetting in gamemodeSetting.exclusiveSettings)
		{
			if (gamemodePanel.GetGamemode().HasActiveSetting(exclusiveSetting) && !gamemodePanel.GetGamemode().HasActiveSetting(gamemodeSetting.id))
			{
				flag2 = true;
				break;
			}
		}
		if (!flag)
		{
			color = Color.grey;
			descriptionText.text = gamemodeSetting.unlock.unlockHint;
			if (gamemodeSetting.unlock.showProgression)
			{
				TMP_Text tMP_Text = descriptionText;
				tMP_Text.text = tMP_Text.text + ": " + gamemodeSetting.unlock.GetProgressString();
			}
			toggle.interactable = false;
		}
		else if (flag2)
		{
			color = Color.grey;
			descriptionText.text = "LOCKED";
			if (toggle != null)
			{
				toggle.interactable = false;
			}
		}
		else
		{
			descriptionText.text = gamemodeSetting.description;
			if (toggle != null)
			{
				toggle.interactable = true;
			}
		}
		outline.color = color;
		if (toggle != null)
		{
			toggle.targetGraphic.color = color;
			toggle.graphic.color = color;
		}
		titleText.color = color;
		descriptionText.color = color;
		unlockHint.color = color;
	}

	private void Update()
	{
	}

	public void ToggleSetting(bool b)
	{
		StatManager.saveData.SetSetting(gamemodePanel.GetGamemode().gamemodeName, gamemodeSetting.id, b);
		DOTween.Complete(base.transform);
		base.transform.localScale = Vector3.one;
		base.transform.DOPunchScale(Vector3.one * 0.015f, 0.5f);
		UpdateColor();
		refresh?.Invoke();
		gamemodePanel.gamemodeScreen.RefreshCurrentGamemode();
		SettingsManager.RefreshSettings();
	}
}
