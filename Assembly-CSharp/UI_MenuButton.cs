using UnityEngine;
using UnityEngine.UI;

public class UI_MenuButton : MonoBehaviour
{
	public UI_MenuScreen screen;

	private UI_Menu parentMenu;

	public void OpenScreen()
	{
		parentMenu.DisableMenus(this);
		screen.Open();
	}

	public void DisableScreen()
	{
		screen.Disable();
	}

	public void Initialize(UI_Menu menu)
	{
		parentMenu = menu;
		screen.Initialize(this, parentMenu);
		GetComponent<Button>().onClick.AddListener(OpenScreen);
	}
}
