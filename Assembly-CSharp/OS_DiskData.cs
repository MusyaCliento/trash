using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Disk Data File", menuName = "White Knuckle/OS/Disk Data")]
public class OS_DiskData : ScriptableObject
{
	public enum DiskDataType
	{
		standard = 0,
		diskDataList = 1
	}

	[Serializable]
	public class DiskDataSelector
	{
		public string name;

		public List<OS_Filesystem.FileInfo> files;
	}

	public string diskName;

	public string id;

	public DiskDataType type;

	public List<OS_DiskData> randomDisks;

	public List<OS_Filesystem.FileInfo> files;

	public bool useRandomSelector;

	private int selectedDisk = -1;

	public List<DiskDataSelector> diskDataSelectors;

	private bool hasInitialized;

	private OS_DiskData chosenDisk;

	public bool isComputerDesktop;

	public Sprite desktopBackground;

	public void Initialize()
	{
		hasInitialized = true;
		selectedDisk = UnityEngine.Random.Range(0, diskDataSelectors.Count);
	}

	public List<OS_Filesystem.FileInfo> GetFiles()
	{
		if (type == DiskDataType.diskDataList)
		{
			if (chosenDisk == null)
			{
				chosenDisk = UnityEngine.Object.Instantiate(randomDisks[UnityEngine.Random.Range(0, randomDisks.Count)]);
			}
			chosenDisk.Initialize();
			return chosenDisk.GetFiles();
		}
		if (!useRandomSelector)
		{
			return files;
		}
		if (selectedDisk == -1)
		{
			Initialize();
		}
		return diskDataSelectors[selectedDisk].files;
	}

	internal string GetDiskName()
	{
		if (type == DiskDataType.diskDataList)
		{
			if (chosenDisk == null)
			{
				chosenDisk = randomDisks[UnityEngine.Random.Range(0, randomDisks.Count)];
			}
			return chosenDisk.GetDiskName();
		}
		return diskName;
	}
}
