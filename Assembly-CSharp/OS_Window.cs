using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class OS_Window : MonoBehaviour
{
	public string windowName = "NULLNAME";

	public OS_File file;

	public UnityEvent openEvent;

	public UnityEvent closeEvent;

	public UnityEvent moveEvent;

	private UI_Window ui;

	internal string id;

	public bool forceFront;

	public bool fullscreen;

	internal OS_Manager os;

	public Action openAction;

	public Selectable firstSelect;

	private CanvasGroup canvasGroup;

	public virtual void Start()
	{
		ui = GetComponent<UI_Window>();
		if (ui != null && ui.GetTitleBar() != null)
		{
			ui.GetTitleBar().SetTitle(windowName);
		}
		canvasGroup = GetComponent<CanvasGroup>();
		if (canvasGroup == null)
		{
			canvasGroup = base.gameObject.AddComponent<CanvasGroup>();
		}
	}

	private void Update()
	{
		if (forceFront)
		{
			base.transform.SetAsLastSibling();
		}
		CheckFirstSelect();
	}

	public virtual void CloseApp()
	{
		OS_Manager.soundPlayer.PlaySound("os:file-close");
		closeEvent.Invoke();
		file.CloseFile();
		os.CloseAppWindow(this, id);
	}

	public virtual void QuitApp()
	{
		OS_Manager.activeComputer.QuitAppWindow(this, id);
		if ((bool)file)
		{
			file.CloseFile();
		}
		closeEvent.Invoke();
	}

	public virtual void OpenApp(OS_File f)
	{
		file = f;
		if ((bool)file)
		{
			file.open = true;
			file.fileInfo.open = true;
		}
		openEvent.Invoke();
		SetWindowName(file.fileInfo.name);
		if (openAction != null)
		{
			openAction();
		}
	}

	public void MoveToTop()
	{
		base.transform.SetAsLastSibling();
	}

	public void SetID(string s)
	{
		id = s;
	}

	public void Initialize(OS_Manager o)
	{
		os = o;
	}

	internal void SetWindowName(string name)
	{
		windowName = file.fileInfo.name;
		base.gameObject.name = file.fileInfo.name;
		if (ui != null && ui.GetTitleBar() != null)
		{
			ui.GetTitleBar().SetTitle(windowName);
		}
	}

	public void CheckFirstSelect()
	{
		if (InputManager.IsGamepad())
		{
			if (EventSystem.current.currentSelectedGameObject == null)
			{
				SelectFirst();
			}
			else if (!EventSystem.current.currentSelectedGameObject.activeInHierarchy || !EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().IsInteractable())
			{
				SelectFirst();
			}
		}
	}

	public virtual void SelectFirst()
	{
		if (!(firstSelect == null) && firstSelect.IsInteractable())
		{
			firstSelect.Select();
		}
	}
}
