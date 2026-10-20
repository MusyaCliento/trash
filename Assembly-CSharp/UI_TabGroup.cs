using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_TabGroup : MonoBehaviour
{
	[Serializable]
	public class Tab
	{
		public string name;

		public Button button;

		public GameObject tabObject;

		public Selectable firstSelect;

		public TMP_Text buttonText;

		public bool onlyDev;
	}

	private bool active;

	public Color openColor;

	public Color closeColor;

	public bool changeTextColor;

	public Color textOpenColor;

	public Color textCloseColor;

	public List<Tab> tabs;

	public string tabLeftButton;

	public string tabRightButton;

	private int currentTab;

	public bool disableIfGamepad;

	public bool autoSelectOnEnable;

	private CanvasGroup group;

	public CanvasGroup parentCanvasGroup;

	public AudioClip switchTabSound;

	public float switchTabSoundVolume = 0.5f;

	public UnityEvent EventOnChangeTab;

	private void Start()
	{
		group = GetComponent<CanvasGroup>();
		foreach (Tab g in tabs)
		{
			if (g.button != null)
			{
				g.button.onClick.AddListener(delegate
				{
					SelectTab(g.name);
				});
				if (g.onlyDev)
				{
					g.button.gameObject.SetActive(value: false);
				}
			}
		}
		SelectTab(tabs[0].name, skipAudio: true);
	}

	private void OnEnable()
	{
		StartCoroutine(FrameWait());
		IEnumerator FrameWait()
		{
			yield return new WaitForSecondsRealtime(0.1f);
			active = true;
		}
	}

	private void OnDisable()
	{
		active = false;
	}

	public void SelectTab(string tabName)
	{
		SelectTab(tabName, skipAudio: false);
	}

	public void SelectTab(string tabName, bool skipAudio)
	{
		for (int i = 0; i < tabs.Count; i++)
		{
			Tab tab = tabs[i];
			if (tab.name == tabName)
			{
				tab.button.image.color = openColor;
				if (changeTextColor)
				{
					tab.buttonText.color = textOpenColor;
				}
				tab.tabObject.SetActive(value: true);
				currentTab = i;
				if (tab.firstSelect != null && EventSystem.current.currentSelectedGameObject != tab.firstSelect)
				{
					tab.firstSelect.Select();
				}
			}
			else
			{
				tab.button.image.color = closeColor;
				if (changeTextColor)
				{
					tab.buttonText.color = textCloseColor;
				}
				tab.tabObject.SetActive(value: false);
			}
		}
		if (switchTabSound != null && !skipAudio)
		{
			AudioManager.PlayUISound(switchTabSound, switchTabSoundVolume);
		}
		EventOnChangeTab.Invoke();
	}

	private void Update()
	{
		if (!active || (parentCanvasGroup != null && !parentCanvasGroup.interactable))
		{
			return;
		}
		if (disableIfGamepad)
		{
			if (InputManager.instance != null && InputManager.IsGamepad() && !SettingsManager.settings.allowCombinedInput)
			{
				group.interactable = false;
			}
			else
			{
				group.interactable = true;
			}
		}
		if ((parentCanvasGroup == null || parentCanvasGroup.interactable) && tabLeftButton != "" && tabRightButton != "")
		{
			if (InputManager.GetButton(tabLeftButton).Down)
			{
				SwitchTab(-1);
			}
			else if (InputManager.GetButton(tabRightButton).Down)
			{
				SwitchTab();
			}
		}
	}

	private void SwitchTab(int x = 1)
	{
		currentTab += x;
		if (currentTab >= tabs.Count)
		{
			currentTab = 0;
		}
		if (currentTab < 0)
		{
			currentTab = tabs.Count - 1;
		}
		if (!tabs[currentTab].button.gameObject.activeSelf)
		{
			SwitchTab(x);
			return;
		}
		for (int i = 0; i < tabs.Count; i++)
		{
			Tab tab = tabs[i];
			if (tab.name == tabs[currentTab].name)
			{
				tab.button.Select();
				tab.button.onClick.Invoke();
			}
		}
	}
}
