using UnityEngine;
using UnityEngine.Events;

public class UI_MenuScreen : MonoBehaviour
{
	private UI_Menu menu;

	private CanvasGroup group;

	public UnityEvent openEvent;

	public UnityEvent closeEvent;

	public bool startEnabled;

	private bool initialized;

	internal void Disable()
	{
		group.interactable = false;
	}

	internal void Initialize(UI_MenuButton uI_MenuButton, UI_Menu parentMenu)
	{
		menu = parentMenu;
		group = GetComponent<CanvasGroup>();
		group.interactable = startEnabled;
		initialized = true;
	}

	private void Start()
	{
		if (!initialized)
		{
			Initialize(null, GetComponentInParent<UI_Menu>());
		}
	}

	public void Open()
	{
		Debug.Log("Opening Menu");
		if (group == null)
		{
			group = GetComponent<CanvasGroup>();
		}
		group.interactable = true;
		openEvent.Invoke();
	}

	public void CloseScreen()
	{
		if (menu != null)
		{
			menu.EnableMenu();
		}
		closeEvent.Invoke();
	}
}
