using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class RuntimeSpriteImporter
{
	private static readonly HashSet<string> validExtensions = new HashSet<string> { ".png", ".jpg", ".jpeg" };

	public static (List<Sprite> spriteList, Dictionary<string, Sprite> spriteDict) LoadSpritesFromFolder(string folderPath, bool pathIsRelativeToPersistentData = true, float pixelsPerUnit = 100f, FilterMode filterMode = FilterMode.Point, bool loadLinear = false, bool recursive = false, bool toLower = false)
	{
		Dictionary<string, Sprite> dictionary = new Dictionary<string, Sprite>();
		List<Sprite> list = new List<Sprite>();
		string text = ResolveFolderPath(folderPath, pathIsRelativeToPersistentData);
		if (!Directory.Exists(text))
		{
			Debug.LogWarning("[RuntimeSpriteImporter] Folder does not exist: " + text);
			return (spriteList: list, spriteDict: dictionary);
		}
		List<string> list2 = new List<string>();
		FindFiles(list2, folderPath, "");
		foreach (string item in list2)
		{
			if (!IsValidImageExtension(item))
			{
				continue;
			}
			string text2 = Path.ChangeExtension(item, null);
			bool linear = loadLinear;
			if (Path.GetFileNameWithoutExtension(text2).Contains("_rgb"))
			{
				linear = false;
			}
			else if (Path.GetFileNameWithoutExtension(text2).Contains("_linear"))
			{
				linear = true;
			}
			Sprite sprite = LoadSpriteFromFile(Path.Combine(folderPath, item), pixelsPerUnit, filterMode, mipmap: false, linear);
			if (sprite == null)
			{
				Debug.LogWarning("[RuntimeSpriteImporter] Failed to load sprite from file: " + item);
				continue;
			}
			if (toLower)
			{
				text2 = text2.ToLower();
			}
			sprite.name = text2;
			dictionary[text2] = sprite;
			list.Add(sprite);
		}
		Directory.GetDirectories(text);
		return (spriteList: list, spriteDict: dictionary);
		static void FindFiles(List<string> outPaths, string basePath, string prepend)
		{
			string[] files = Directory.GetFiles(basePath);
			foreach (string path in files)
			{
				outPaths.Add(prepend + Path.GetFileName(path));
			}
			files = Directory.GetDirectories(basePath);
			foreach (string text3 in files)
			{
				FindFiles(outPaths, text3, prepend + Path.GetFileName(text3) + "/");
			}
		}
	}

	public static Sprite LoadSpriteFromFile(string filePath, float pixelsPerUnit = 100f, FilterMode filterMode = FilterMode.Point, bool mipmap = false, bool linear = false)
	{
		if (string.IsNullOrEmpty(filePath))
		{
			Debug.LogError("[RuntimeSpriteImporter] LoadSpriteFromFile: filePath is null/empty.");
			return null;
		}
		if (!File.Exists(filePath))
		{
			Debug.LogError("[RuntimeSpriteImporter] LoadSpriteFromFile: file doesn't exist: " + filePath);
			return null;
		}
		if (!IsValidImageExtension(filePath))
		{
			Debug.LogWarning("[RuntimeSpriteImporter] LoadSpriteFromFile: unsupported extension: " + filePath);
			return null;
		}
		try
		{
			byte[] data = File.ReadAllBytes(filePath);
			Texture2D texture2D = new Texture2D(2, 2, TextureFormat.RGBA32, mipmap, linear);
			if (!texture2D.LoadImage(data))
			{
				Debug.LogWarning("[RuntimeSpriteImporter] Texture2D.LoadImage failed on: " + filePath);
				UnityEngine.Object.Destroy(texture2D);
				return null;
			}
			texture2D.filterMode = filterMode;
			texture2D.wrapMode = TextureWrapMode.Clamp;
			texture2D.Apply();
			return Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), pixelsPerUnit, 0u, SpriteMeshType.FullRect);
		}
		catch (Exception ex)
		{
			Debug.LogError("[RuntimeSpriteImporter] Exception loading \"" + filePath + "\":\n" + ex);
			return null;
		}
	}

	private static string ResolveFolderPath(string folderPath, bool pathIsRelativeToPersistentData)
	{
		if (pathIsRelativeToPersistentData)
		{
			return Path.Combine(Application.persistentDataPath, folderPath);
		}
		return folderPath;
	}

	private static bool IsValidImageExtension(string filePath)
	{
		string extension = Path.GetExtension(filePath);
		if (string.IsNullOrEmpty(extension))
		{
			return false;
		}
		extension = extension.ToLower();
		return validExtensions.Contains(extension);
	}
}
