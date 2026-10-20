using System;
using System.IO;
using UnityEngine;

namespace BSPImporter
{
	public class FTXLoader
	{
		public static Texture2D LoadFTX(string path)
		{
			using FileStream fileStream = File.Open(path, FileMode.Open);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, (int)fileStream.Length);
			Texture2D texture2D = new Texture2D(BitConverter.ToInt32(array, 0), BitConverter.ToInt32(array, 4));
			int num = 12;
			for (int num2 = texture2D.height - 1; num2 >= 0; num2--)
			{
				for (int i = 0; i < texture2D.width; i++)
				{
					texture2D.SetPixel(i, num2, new Color32(array[num], array[num + 1], array[num + 2], array[num + 3]));
					num += 4;
				}
			}
			texture2D.Apply();
			return texture2D;
		}
	}
}
