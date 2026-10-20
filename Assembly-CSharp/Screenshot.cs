using System;
using System.IO;
using UnityEngine;

public class Screenshot
{
	public static void TakeScreenshot(int size = 1, string setPath = "")
	{
		string text = Path.Combine(Application.persistentDataPath, "Screenshots");
		Directory.CreateDirectory(text);
		if (setPath != "")
		{
			text = setPath;
		}
		string text2 = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff");
		string path = "Screenshot_" + text2 + ".png";
		string text3 = Path.Combine(text, path);
		ScreenCapture.CaptureScreenshot(text3, size);
		Debug.Log("Screenshot saved to: " + text3);
	}
}
