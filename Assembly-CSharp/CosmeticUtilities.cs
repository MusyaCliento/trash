using System.IO;
using UnityEngine;

public static class CosmeticUtilities
{
	public static void SaveSpriteAsPNG(Sprite sprite, string fullPath)
	{
		if (sprite == null)
		{
			Debug.LogError("SaveSpriteAsPNG: sprite is null.");
			return;
		}
		Texture2D texture = sprite.texture;
		if (texture == null)
		{
			Debug.LogError("SaveSpriteAsPNG: sprite.texture is null.");
			return;
		}
		Rect textureRect = sprite.textureRect;
		int num = Mathf.RoundToInt(textureRect.width);
		int num2 = Mathf.RoundToInt(textureRect.height);
		Texture2D texture2D = new Texture2D(num, num2, TextureFormat.RGBA32, mipChain: false);
		Color[] pixels = texture.GetPixels(Mathf.RoundToInt(textureRect.x), Mathf.RoundToInt(textureRect.y), num, num2);
		texture2D.SetPixels(pixels);
		texture2D.Apply();
		byte[] array = texture2D.EncodeToPNG();
		if (array == null || array.Length == 0)
		{
			Debug.LogError("SaveSpriteAsPNG: EncodeToPNG failed.");
			return;
		}
		string directoryName = Path.GetDirectoryName(fullPath);
		if (!Directory.Exists(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
		File.WriteAllBytes(fullPath, array);
		Debug.Log("Sprite exported to: " + fullPath);
	}

	public static string GetCosmeticFolderPath()
	{
		return Path.Combine(Application.dataPath, "Mods", "Cosmetics");
	}
}
