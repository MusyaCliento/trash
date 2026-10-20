using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OS_Folder : OS_Window
{
	public GameObject contents;

	public List<OS_Filesystem.FileInfo> subFiles = new List<OS_Filesystem.FileInfo>();

	public string location = "Desktop/";

	public GridLayoutGroup gridSorter;

	public bool locked;

	public TMP_Text infoText;

	public override void Start()
	{
		base.Start();
		UpdateInfoText();
	}

	public void CreateFiles(List<OS_Filesystem.FileInfo> files)
	{
		os.GetFilesystem().CreateFiles(files, this);
	}

	public void AddFile(OS_Filesystem.FileInfo newFile)
	{
		if (!subFiles.Contains(newFile))
		{
			subFiles.Add(newFile);
		}
		if (file != null)
		{
			file.fileInfo.children = subFiles;
		}
		UpdateInfoText();
	}

	public void RemoveFile(OS_Filesystem.FileInfo newFile)
	{
		if (subFiles.Contains(newFile))
		{
			subFiles.Remove(newFile);
		}
		if (file != null)
		{
			file.fileInfo.children = subFiles;
		}
		UpdateInfoText();
	}

	public override void CloseApp()
	{
		OS_Manager.soundPlayer.PlaySound("os:folder-close");
		closeEvent.Invoke();
		file.CloseFile();
		bool flag = true;
		if (subFiles.Count > 0)
		{
			foreach (OS_Filesystem.FileInfo subFile in subFiles)
			{
				if (subFile.fileObject.open)
				{
					flag = false;
					break;
				}
			}
		}
		if (!flag)
		{
			base.gameObject.SetActive(value: false);
		}
		else
		{
			os.CloseAppWindow(this, id);
		}
	}

	public void SortFiles()
	{
		List<Transform> list = new List<Transform>();
		foreach (Transform item in contents.transform)
		{
			list.Add(item);
		}
		list.Sort((Transform a, Transform b) => a.name.CompareTo(b.name));
		for (int num = 0; num < list.Count; num++)
		{
			list[num].SetSiblingIndex(num);
		}
		if (gridSorter != null)
		{
			StartCoroutine(Sorter());
		}
	}

	private IEnumerator Sorter()
	{
		gridSorter.enabled = true;
		yield return null;
		gridSorter.enabled = false;
	}

	public void NewFolder()
	{
		NewFolder(OS_Manager.mouseRealPosition);
	}

	public OS_File NewFolder(Vector2 pos, string folderName = "New Folder", OS_Filesystem.IconType icon = null, bool createAtWorldPosition = true)
	{
		OS_Filesystem.FileInfo fileInfo = new OS_Filesystem.FileInfo();
		fileInfo.type = OS_Filesystem.FileInfo.fileType.folder;
		fileInfo.name = folderName;
		fileInfo.SetLocation(location);
		fileInfo.useCustomFiletype = false;
		if (icon != null)
		{
			fileInfo.icon = icon.icon;
			fileInfo.openIcon = icon.openIcon;
		}
		if (os == null)
		{
			os = OS_Manager.activeComputer;
		}
		if (fileInfo.targetWindow != null)
		{
			fileInfo.targetWindow.Initialize(os);
		}
		contents.GetComponent<RectTransform>();
		fileInfo.position = pos;
		fileInfo.useWorldPosition = createAtWorldPosition;
		return os.GetFilesystem().CreateFile(fileInfo, this);
	}

	public override void SelectFirst()
	{
		if (subFiles[0].fileObject.IsInteractable())
		{
			subFiles[0].fileObject.Select();
		}
	}

	public void UpdateInfoText()
	{
		if (infoText != null)
		{
			infoText.text = $"{subFiles.Count} Items";
		}
	}
}
