using UnityEngine;

[CreateAssetMenu(fileName = "New File Data Asset", menuName = "White Knuckle/OS/File Data Asset")]
public class OS_FileDataAsset : ScriptableObject
{
	public OS_Filesystem.FileInfo fileInfo;

	public OS_Filesystem.FileInfo GetFileInfo()
	{
		return fileInfo.GetCopy();
	}
}
