using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class CL_LocalizationManager : MonoBehaviour
{
	[Serializable]
	public class LocalizationLine
	{
		public string id;

		public string text;
	}

	[Serializable]
	public class Localization
	{
		public class LocalizationTextGroup
		{
			public string id;

			public Dictionary<string, string> lines;

			public string GetLine(string key)
			{
				if (!lines.ContainsKey(key))
				{
					return "";
				}
				return lines[key];
			}
		}

		public List<LocalizationTextGroup> textGroups;

		public Dictionary<string, string> announcements;

		public string GetLine(string group, string key)
		{
			foreach (LocalizationTextGroup textGroup in textGroups)
			{
				if ((group == null || textGroup.id == group) && textGroup.lines.TryGetValue(key, out var value))
				{
					return value;
				}
			}
			Debug.LogError("LOCALIZATION ERROR: Unable to find line - " + group + " " + key);
			return "";
		}
	}

	public static Localization currentLocalization;

	private void Awake()
	{
		LoadLocalization();
	}

	private void LoadLocalization(string lang = "en", bool forceReimport = false)
	{
		currentLocalization = new Localization();
		currentLocalization.textGroups = new List<Localization.LocalizationTextGroup>();
		TextAsset[] array = Resources.LoadAll<TextAsset>("Localization/" + lang);
		foreach (TextAsset textAsset in array)
		{
			Debug.Log("Found Localization File: " + textAsset.name);
			Localization.LocalizationTextGroup item = JsonConvert.DeserializeObject<Localization.LocalizationTextGroup>(textAsset.text);
			currentLocalization.textGroups.Add(item);
		}
		Debug.Log(currentLocalization);
	}

	public string ProcessString(string input)
	{
		return input;
	}

	public static string GetLocalization(string groupid, string lineid)
	{
		if (currentLocalization == null)
		{
			return "";
		}
		return currentLocalization.GetLine(groupid, lineid);
	}

	public static string GetLocalization(string combinedString)
	{
		if (currentLocalization == null)
		{
			return "";
		}
		string[] array = combinedString.Split(':');
		if (array.Length > 1)
		{
			return currentLocalization.GetLine(array[0], array[1]);
		}
		return "";
	}
}
