using System.Collections.Generic;
using UnityEngine;

public class UI_Menu : MonoBehaviour
{
	public List<UI_MenuButton> menuButtons = new List<UI_MenuButton>();

	private CanvasGroup group;

	private void OnEnable()
	{
		EnableMenu();
	}

	internal void DisableMenus(UI_MenuButton activeButton)
	{
		group.interactable = false;
		foreach (UI_MenuButton menuButton in menuButtons)
		{
			if (menuButton != activeButton)
			{
				menuButton.DisableScreen();
			}
		}
	}

	public void EnableMenu()
	{
		if (group == null)
		{
			group = GetComponent<CanvasGroup>();
		}
		group.interactable = true;
	}

	private void Awake()
	{
		menuButtons.AddRange(GetComponentsInChildren<UI_MenuButton>(includeInactive: true));
		foreach (UI_MenuButton menuButton in menuButtons)
		{
			menuButton.Initialize(this);
		}
		group = GetComponent<CanvasGroup>();
		DisableMenus(null);
		group.interactable = true;
	}
}
