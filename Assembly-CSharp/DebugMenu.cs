using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugMenu : MonoBehaviour
{
	public class DebugText
	{
		public string name;

		public string text;

		public TMP_Text textObject;
	}

	private static DebugMenu instance;

	private GameObject defaultText;

	private Dictionary<string, DebugText> debugTextDictionary = new Dictionary<string, DebugText>();

	private static bool vis;

	public static bool visible
	{
		get
		{
			return vis;
		}
		set
		{
			if (vis == value)
			{
				return;
			}
			vis = value;
			if (instance != null)
			{
				instance.gameObject.SetActive(value);
			}
			if (!value)
			{
				return;
			}
			foreach (DebugText value2 in instance.debugTextDictionary.Values)
			{
				value2.textObject.text = value2.text;
			}
		}
	}

	private void Start()
	{
		defaultText = base.transform.GetChild(0).gameObject;
		defaultText.SetActive(value: false);
		base.gameObject.SetActive(vis);
		instance = this;
	}

	private void OnDestroy()
	{
		instance = null;
	}

	public static void CreateDebugText(string name, string content)
	{
		if (!(instance == null))
		{
			DebugText debugText = new DebugText
			{
				name = name,
				text = content,
				textObject = Object.Instantiate(instance.defaultText, instance.transform).GetComponent<TMP_Text>()
			};
			debugText.textObject.gameObject.SetActive(value: true);
			instance.debugTextDictionary.Add(name, debugText);
			if (vis)
			{
				debugText.textObject.text = content;
			}
		}
	}

	public static void UpdateDebugText(string name, string content)
	{
		if (!(instance == null))
		{
			if (!instance.debugTextDictionary.ContainsKey(name))
			{
				CreateDebugText(name, content);
			}
			instance.debugTextDictionary[name].text = content;
			if (vis)
			{
				instance.debugTextDictionary[name].textObject.text = content;
			}
		}
	}

	public static void DeleteDebugText(string name)
	{
		if (!(instance == null) && instance.debugTextDictionary.ContainsKey(name))
		{
			Object.Destroy(instance.debugTextDictionary[name].textObject.gameObject);
			instance.debugTextDictionary.Remove(name);
		}
	}
}
