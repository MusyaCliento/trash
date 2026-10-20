using System;
using System.Text.RegularExpressions;
using Rewired;
using Rewired.Glyphs.UnityUI;
using TMPro;
using UnityEngine;

public class UI_TextHints : MonoBehaviour
{
	private TMP_Text text;

	private string originalText;

	private string currentScheme;

	private Player input;

	public bool hideUnlessGamepad;

	public string forceSchemeName = "";

	private UnityTextMeshProGlyphHelper glyphHelper;

	private void Awake()
	{
		if (text == null)
		{
			text = GetComponent<TMP_Text>();
			originalText = text.text;
			if (text == null)
			{
				return;
			}
		}
		glyphHelper = GetComponent<UnityTextMeshProGlyphHelper>();
		if (glyphHelper == null)
		{
			glyphHelper = base.gameObject.AddComponent<UnityTextMeshProGlyphHelper>();
		}
		originalText = ReplaceCurlyBraces(originalText, delegate(string key)
		{
			Debug.Log(originalText + " " + key);
			return "<rewiredElement type=\"glyphOrText\" playerId=0 actionName=\"" + key + "\">";
		});
		input = InputManager.GetPlayerInput();
		currentScheme = "";
		SettingsManager._OnRefreshAllSettings = (Action)Delegate.Combine(SettingsManager._OnRefreshAllSettings, new Action(ReloadText));
	}

	private void OnEnable()
	{
		if (text == null)
		{
			text = GetComponent<TMP_Text>();
			originalText = text.text;
			if (text == null)
			{
				return;
			}
		}
		ReloadText();
	}

	private void Update()
	{
		if (hideUnlessGamepad && !InputManager.IsGamepad())
		{
			text.enabled = false;
			text.renderMode = TextRenderFlags.DontRender;
		}
		else
		{
			text.enabled = true;
			text.renderMode = TextRenderFlags.Render;
		}
	}

	public void ReloadText()
	{
		if (glyphHelper != null)
		{
			glyphHelper.text = originalText;
		}
	}

	public void RefreshText()
	{
		originalText = text.text;
	}

	public static string GetHintText(string s)
	{
		return s;
	}

	public static string ReplaceCurlyBraces(string input, Func<string, string> replacer)
	{
		return Regex.Replace(input, "\\{([^}]*)\\}", delegate(Match match)
		{
			string value = match.Groups[1].Value;
			return replacer(value);
		});
	}
}
