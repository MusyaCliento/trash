using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OS_File : Selectable, ISelectHandler, IEventSystemHandler, IPointerClickHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, OSPointerClickHandler, ISubmitHandler, IDeselectHandler
{
	private OS_Manager os;

	public string itemName;

	public OS_Filesystem.FileInfo fileInfo;

	public bool canDrag = true;

	private bool dragging;

	public bool selectable = true;

	private bool selected;

	public bool open;

	private RectTransform currentContainer;

	private Image sprite;

	private Color targetColor = Color.white;

	private Color currentColor = Color.white;

	public InputField nameText;

	public RectTransform nameTextBackplate;

	private Transform parent;

	private OS_Folder parentFolder;

	public float dClickTime = 0.5f;

	private float cTime;

	private Vector2 offset;

	private string id;

	private void Update()
	{
		if (open)
		{
			currentColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * 15f);
		}
		else if (selected)
		{
			currentColor = Color.Lerp(currentColor, Color.red, Time.deltaTime * 15f);
		}
		else
		{
			currentColor = Color.Lerp(currentColor, Color.white, Time.deltaTime * 15f);
		}
		if ((bool)sprite)
		{
			sprite.color = currentColor;
		}
		ColorBlock colorBlock = nameText.colors;
		colorBlock.normalColor = currentColor;
		nameText.colors = colorBlock;
		cTime += Time.deltaTime;
	}

	public void Initialize(OS_Filesystem.FileInfo info, OS_Folder folder, OS_Manager osMan)
	{
		if (osMan == null)
		{
			os = OS_Manager.activeComputer;
		}
		else
		{
			os = osMan;
		}
		bool hasInitialized = info.hasInitialized;
		info.Initialize(os);
		Debug.Log(info.name + " initialized with type " + info.type.ToString() + " has initialized: " + hasInitialized);
		sprite = GetComponent<Image>();
		currentContainer = base.transform.parent.GetComponent<RectTransform>();
		cTime = 1f;
		fileInfo = info;
		if (!fileInfo.useWorldPosition)
		{
			GetComponent<RectTransform>().anchoredPosition = fileInfo.position;
		}
		else
		{
			fileInfo.useWorldPosition = false;
			fileInfo.position = GetComponent<RectTransform>().anchoredPosition;
		}
		fileInfo.fileObject = this;
		itemName = fileInfo.name;
		base.transform.name = fileInfo.name + "_File";
		nameText.text = itemName;
		nameTextBackplate.sizeDelta = new Vector2(nameText.preferredWidth + 4f, 14f);
		sprite.sprite = info.icon;
		parent = base.transform.parent;
		parentFolder = folder;
		if (folder != null && folder.file != null)
		{
			fileInfo.parent = folder.file.fileInfo;
		}
		base.transform.localScale = Vector3.one;
		id = Guid.NewGuid().ToString();
		if ((!hasInitialized || !fileInfo.hasBeenOpened) && info.openOnInitialize)
		{
			OpenFile();
		}
	}

	public void OpenFile()
	{
		if (open)
		{
			return;
		}
		fileInfo.OnOpen();
		sprite.sprite = fileInfo.openIcon;
		targetColor = Color.grey;
		open = true;
		selected = true;
		if ((bool)fileInfo.windowAsset)
		{
			if (fileInfo.targetWindow == null)
			{
				fileInfo.targetWindow = os.CreateAppWindow(fileInfo.windowAsset, id);
				if (fileInfo.type == OS_Filesystem.FileInfo.fileType.folder)
				{
					Debug.Log(fileInfo.targetWindow);
					Debug.Log(fileInfo.targetWindow.GetComponent<OS_Folder>());
					Debug.Log(fileInfo);
					Debug.Log(fileInfo.children);
					fileInfo.targetWindow.GetComponent<OS_Folder>().CreateFiles(fileInfo.children);
					fileInfo.targetWindow.transform.position = (Vector2)parentFolder.transform.position + new Vector2(15f, 15f);
				}
			}
			else
			{
				fileInfo.targetWindow.gameObject.SetActive(value: true);
				fileInfo.targetWindow.SetWindowName(fileInfo.name);
			}
			fileInfo.targetWindow.OpenApp(this);
			fileInfo.targetWindow.file = this;
			fileInfo.targetWindow.transform.SetAsLastSibling();
		}
		OS_Manager.soundPlayer.PlaySound("os:click");
	}

	public void CloseFile()
	{
		open = false;
		fileInfo.open = false;
		targetColor = Color.white;
		selected = false;
		sprite.sprite = fileInfo.icon;
	}

	internal void CloseFileRecursive()
	{
		if (fileInfo.children == null)
		{
			return;
		}
		foreach (OS_Filesystem.FileInfo child in fileInfo.children)
		{
			if (child != null && child.fileObject != null)
			{
				child.fileObject.CloseFileRecursive();
			}
		}
		if (open)
		{
			CloseFile();
		}
	}

	public void MoveIntoFolder(OS_Folder folder)
	{
		base.transform.SetParent(folder.contents.transform);
		parent = base.transform.parent;
		fileInfo.position = GetComponent<RectTransform>().anchoredPosition;
		fileInfo.SetLocation(folder.location + folder.windowName + "/");
		parentFolder.RemoveFile(fileInfo);
		folder.AddFile(fileInfo);
		parentFolder = folder;
		if (folder != null && folder.file != null)
		{
			fileInfo.parent = folder.file.fileInfo;
		}
	}

	public void RemoveFromFolder()
	{
	}

	public void DeleteFile()
	{
		if (fileInfo.open || open)
		{
			CloseFile();
		}
		fileInfo.parent.DeleteChild(fileInfo);
	}

	public void OSPointerClick(PointerEventData eventData)
	{
	}

	public override void OnSelect(BaseEventData eventData)
	{
		selected = true;
		base.OnSelect(eventData);
	}

	public override void OnDeselect(BaseEventData eventData)
	{
		selected = false;
		base.OnDeselect(eventData);
	}

	public void OnSubmit(BaseEventData eventData)
	{
		OpenFile();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			sprite.color = Color.grey;
			if (cTime <= dClickTime)
			{
				OpenFile();
			}
			cTime = 0f;
		}
		OS_Manager.soundPlayer.PlaySound("os:click");
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (!canDrag || open || !dragging || fileInfo.open || !fileInfo.canMove)
		{
			return;
		}
		base.transform.position = OS_Manager.mousePosition + offset;
		fileInfo.position = GetComponent<RectTransform>().anchoredPosition;
		if (RaycastUtilities.PointerIsOverUI(eventData.position, "Folder", "OS"))
		{
			OS_Folder component = RaycastUtilities.UIRaycast(eventData.position, "Folder", "OS").transform.GetComponent<OS_Folder>();
			if (component != null && (component.file == null || !IsParent(fileInfo, component.file.fileInfo)))
			{
				MoveIntoFolder(component);
			}
		}
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		offset = (Vector2)base.transform.position - OS_Manager.mousePosition;
		base.transform.SetAsLastSibling();
		OS_Manager.soundPlayer.PlaySound("os:drag-start");
		dragging = true;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (GetComponent<RectTransform>().anchoredPosition.y > -20f)
		{
			Vector2 vector = new Vector3(GetComponent<RectTransform>().anchoredPosition.x, -20f);
			fileInfo.position = vector;
			GetComponent<RectTransform>().anchoredPosition = vector;
		}
		dragging = false;
		OS_Manager.soundPlayer.PlaySound("os:drag-end");
	}

	public void SetText(string s)
	{
		fileInfo.name = s;
		itemName = fileInfo.name;
		base.transform.name = fileInfo.name + "_File";
		nameTextBackplate.sizeDelta = new Vector2(nameText.textComponent.preferredWidth + 4f, 14f);
	}

	public void ResetBackerWidth()
	{
		nameTextBackplate.sizeDelta = new Vector2(nameText.preferredWidth + 4f, 14f);
	}

	public bool IsDescendant(OS_Filesystem.FileInfo target, List<OS_Filesystem.FileInfo> children)
	{
		if (children == null || children.Count == 0)
		{
			return false;
		}
		foreach (OS_Filesystem.FileInfo child in children)
		{
			if (child == target)
			{
				return true;
			}
			if (child.children != null && child.children.Count > 0 && IsDescendant(target, child.children))
			{
				return true;
			}
		}
		return false;
	}

	public bool IsParent(OS_Filesystem.FileInfo targetParent, OS_Filesystem.FileInfo targetChild)
	{
		bool flag = false;
		int num = 0;
		if (targetChild.parent == null)
		{
			return false;
		}
		OS_Filesystem.FileInfo fileInfo = targetChild.parent;
		while (!flag && num < 100)
		{
			num++;
			if (targetParent == fileInfo)
			{
				return true;
			}
			if (fileInfo.parent == null)
			{
				return false;
			}
			fileInfo = fileInfo.parent;
		}
		return false;
	}
}
