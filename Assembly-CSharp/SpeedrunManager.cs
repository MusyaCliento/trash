using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpeedrunManager
{
	public class SpeedrunEvent
	{
		public string id;

		public float time;
	}

	public static List<SpeedrunEvent> sessionEvents;

	public static void Initialize()
	{
		sessionEvents = new List<SpeedrunEvent>();
	}

	public static void AddEvent(string s)
	{
		SpeedrunEvent speedrunEvent = new SpeedrunEvent();
		speedrunEvent.id = s;
		speedrunEvent.time = CL_GameManager.gMan.GetGameTime();
		Debug.Log($"Speedlog: Reached {s} at {speedrunEvent.time}");
		sessionEvents.Add(speedrunEvent);
	}

	public static void SaveLog()
	{
		if (sessionEvents == null || sessionEvents.Count == 0)
		{
			return;
		}
		string text = "";
		string text2 = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
		text = text + "White Knuckle Speedrun Report - " + Application.version + "\n";
		text = text + text2 + " -- " + CL_GameManager.GetGamemodeName() + "\n";
		foreach (SpeedrunEvent sessionEvent in sessionEvents)
		{
			text += $"{sessionEvent.id} - {sessionEvent.time}\n";
		}
		string text3 = Path.Combine(Application.persistentDataPath, "Run Records");
		Directory.CreateDirectory(text3);
		File.WriteAllLines(Path.Combine(text3, "runrecord-" + CL_GameManager.GetGamemodeName() + "-" + text2 + ".txt"), text.Split('\n'));
	}
}
