using System.Collections.Generic;
using UnityEngine;

public class OS_ResourceManager : MonoBehaviour
{
	public List<Sprite> pictures;

	public Dictionary<string, Sprite> pictureFiles;

	public List<Sprite> icons;

	public Dictionary<string, Sprite> iconFiles;

	public List<AudioClip> sounds;

	public Dictionary<string, AudioClip> soundFiles;

	private void Start()
	{
		pictureFiles = new Dictionary<string, Sprite>();
		if (pictures != null)
		{
			foreach (Sprite picture in pictures)
			{
				if (!(picture == null))
				{
					pictureFiles.Add(picture.name, picture);
				}
			}
		}
		iconFiles = new Dictionary<string, Sprite>();
		foreach (Sprite icon in icons)
		{
			iconFiles.Add(icon.name, icon);
		}
		soundFiles = new Dictionary<string, AudioClip>();
		foreach (AudioClip sound in sounds)
		{
			soundFiles.Add(sound.name, sound);
		}
	}

	public Sprite GetPicture(string name)
	{
		return pictureFiles[name];
	}

	public Sprite GetIcon(string name)
	{
		return iconFiles[name];
	}

	public AudioClip GetSound(string name)
	{
		return soundFiles[name];
	}
}
