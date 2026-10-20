using System;
using System.Collections.Generic;
using UnityEngine;

public class OS_Filesystem : MonoBehaviour
{
	[Serializable]
	public class FileInfoDefault
	{
		public string name;

		public FileInfo info;
	}

	[Serializable]
	public class IconType
	{
		public string name;

		public Sprite icon;

		public Sprite openIcon;
	}

	[Serializable]
	public class FileInfo
	{
		public enum fileType
		{
			program = 0,
			folder = 1,
			data = 2,
			alias = 3,
			image = 4,
			audio = 5,
			text = 6
		}

		public OS_FileDataAsset fileDataAsset;

		public string name;

		[HideInInspector]
		public string location = "Desktop/";

		public fileType type;

		public string data;

		public TextAsset textAssetData;

		public Sprite imageAssetData;

		public bool useCustomFiletype = true;

		public bool openOnInitialize;

		public bool canMove = true;

		internal bool hasInitialized;

		internal bool hasBeenOpened;

		public List<FileInfo> children;

		[SerializeReference]
		public FileInfo parent;

		public Sprite icon;

		public Sprite openIcon;

		[HideInInspector]
		public OS_File fileObject;

		[HideInInspector]
		public OS_Window targetWindow;

		public OS_Window windowAsset;

		public bool useWorldPosition;

		public bool overrideDataAssetPosition;

		[RectPreview(396f, 256f, interiorWidth = 242f, interiorHeight = 114f, flipX = true)]
		public Vector2 position;

		[HideInInspector]
		public bool open;

		public virtual void Initialize(OS_Manager os)
		{
			if (hasInitialized)
			{
				return;
			}
			hasInitialized = true;
			if (fileDataAsset != null)
			{
				CopyFileInfo(fileDataAsset.fileInfo);
			}
			if (type == fileType.folder && children != null)
			{
				foreach (FileInfo child in children)
				{
					child.parent = this;
					child.Initialize(os);
				}
			}
			if (!useCustomFiletype)
			{
				Debug.Log(type.ToString());
				FileInfo defaultFiletype = os.GetFilesystem().GetDefaultFiletype(type.ToString());
				if (icon == null)
				{
					icon = defaultFiletype.icon;
					openIcon = defaultFiletype.openIcon;
				}
				windowAsset = defaultFiletype.windowAsset;
			}
		}

		private void CopyFileInfo(FileInfo source)
		{
			name = source.name;
			type = source.type;
			data = source.data;
			textAssetData = source.textAssetData;
			imageAssetData = source.imageAssetData;
			useCustomFiletype = source.useCustomFiletype;
			icon = source.icon;
			openIcon = source.openIcon;
			windowAsset = source.windowAsset;
			openOnInitialize = source.openOnInitialize;
			canMove = source.canMove;
			children = new List<FileInfo>();
			if (source.children != null)
			{
				children.AddRange(source.children);
			}
			if (!overrideDataAssetPosition)
			{
				useWorldPosition = source.useWorldPosition;
				position = source.position;
			}
		}

		public void OnOpen()
		{
			hasBeenOpened = true;
		}

		internal void DeleteChild(FileInfo file)
		{
			Debug.Log("Deleting Child: " + file.name);
			if (file.open)
			{
				file.fileObject.CloseFileRecursive();
			}
			children.Remove(file);
			UnityEngine.Object.Destroy(file.fileObject.gameObject);
		}

		public void SetLocation(string newLocation)
		{
			location = newLocation;
		}

		public FileInfo GetCopy()
		{
			FileInfo fileInfo = new FileInfo();
			fileInfo.name = name;
			fileInfo.fileDataAsset = fileDataAsset;
			fileInfo.type = type;
			fileInfo.data = data;
			fileInfo.textAssetData = textAssetData;
			fileInfo.imageAssetData = imageAssetData;
			fileInfo.useCustomFiletype = useCustomFiletype;
			fileInfo.icon = icon;
			fileInfo.openIcon = openIcon;
			fileInfo.windowAsset = windowAsset;
			fileInfo.useWorldPosition = useWorldPosition;
			fileInfo.position = position;
			fileInfo.openOnInitialize = openOnInitialize;
			fileInfo.canMove = canMove;
			fileInfo.children = new List<FileInfo>();
			if (children != null)
			{
				foreach (FileInfo child in children)
				{
					FileInfo copy = child.GetCopy();
					copy.parent = fileInfo;
					fileInfo.children.Add(copy);
				}
			}
			return fileInfo;
		}

		public string GetName()
		{
			if (fileDataAsset != null)
			{
				return fileDataAsset.fileInfo.name;
			}
			return name;
		}
	}

	private OS_Manager os;

	public OS_Folder desktop;

	public List<FileInfo> desktopFiles;

	public List<FileInfo> fileSystem;

	public OS_File filePrefab;

	public List<IconType> icons = new List<IconType>();

	public Sprite folderDefaultIcon;

	public Sprite folderOpenDefaultIcon;

	public OS_Folder folderApp;

	public List<FileInfoDefault> defaultFiletypes = new List<FileInfoDefault>();

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void Initialize(OS_Manager o)
	{
		os = o;
		fileSystem = new List<FileInfo>();
		FileInfo fileInfo = new FileInfo();
		fileInfo.name = "Desktop";
		fileInfo.SetLocation("");
		fileInfo.type = FileInfo.fileType.folder;
		fileInfo.open = true;
		fileInfo.targetWindow = desktop;
		List<FileInfo> fileList = (fileInfo.children = UnityEngine.Object.Instantiate(o.worldInterface.desktopData).GetFiles());
		desktop.file = UnityEngine.Object.Instantiate(filePrefab, desktop.transform.position, Quaternion.identity, desktop.transform.parent);
		desktop.file.Initialize(fileInfo, desktop, os);
		desktop.file.gameObject.SetActive(value: false);
		fileSystem.Add(fileInfo);
		CreateFiles(fileList, desktop);
	}

	private void Update()
	{
	}

	public void CreateFiles(List<FileInfo> fileList, OS_Folder folder)
	{
		if (fileList == null)
		{
			fileList = new List<FileInfo>();
		}
		foreach (FileInfo file in fileList)
		{
			UnityEngine.Object.Instantiate(filePrefab, file.position, Quaternion.identity, folder.contents.transform).Initialize(file, folder, os);
			folder.AddFile(file);
		}
	}

	public OS_File CreateFiles(FileInfo file, OS_Folder folder)
	{
		OS_File oS_File = UnityEngine.Object.Instantiate(filePrefab, file.position, Quaternion.identity, folder.contents.transform);
		oS_File.Initialize(file, folder, os);
		return oS_File;
	}

	public OS_File CreateFile(FileInfo file, OS_Folder folder)
	{
		if (file.type == FileInfo.fileType.folder)
		{
			if (file.icon == null)
			{
				file.icon = GetIcon("folder").icon;
				file.openIcon = GetIcon("folder").openIcon;
			}
			file.windowAsset = folderApp;
		}
		OS_File oS_File = UnityEngine.Object.Instantiate(filePrefab, file.position, Quaternion.identity);
		oS_File.transform.SetParent(folder.contents.transform, worldPositionStays: true);
		oS_File.Initialize(file, folder, os);
		folder.AddFile(file);
		return oS_File;
	}

	public void CreateFolder(string name, OS_Folder location, Sprite icon = null)
	{
	}

	public IconType GetIcon(string name)
	{
		foreach (IconType icon in icons)
		{
			if (icon.name == name)
			{
				return icon;
			}
		}
		return icons[0];
	}

	public FileInfo GetDefaultFiletype(string name)
	{
		foreach (FileInfoDefault defaultFiletype in defaultFiletypes)
		{
			if (defaultFiletype.name == name)
			{
				return defaultFiletype.info;
			}
		}
		return defaultFiletypes[0].info;
	}
}
