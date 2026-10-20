using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Febucci.UI;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class UI_DMTextAnim : MonoBehaviour
{
	[Serializable]
	private class ShuffleChar
	{
		public int index;

		public char original;

		public float swapInterval;

		public float returnChance;

		public float nextSwap;
	}

	[Header("Target")]
	[SerializeField]
	private TMP_Text tmp;

	private TextAnimator_TMP animCore;

	[Header("Defaults for missing tag values")]
	[Min(0f)]
	public float defaultSwapSeconds = 0.2f;

	[Range(0f, 1f)]
	public float defaultReturnChance = 0.4f;

	[Header("Random Replacement Pool")]
	[Tooltip("Characters used when shuffling (excluding a revert-to-original roll).")]
	public string randomPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

	[Header("Behavior")]
	[Tooltip("Start shuffling automatically on Start().")]
	public bool playOnStart = true;

	private StringBuilder displayBuilder = new StringBuilder();

	private char[] workingChars;

	private List<ShuffleChar> shuffleChars = new List<ShuffleChar>();

	private bool isParsed;

	private void Reset()
	{
		tmp = GetComponent<TMP_Text>();
	}

	private void Awake()
	{
		if (!tmp)
		{
			tmp = GetComponent<TMP_Text>();
		}
		animCore = GetComponent<TextAnimator_TMP>();
	}

	private void Start()
	{
		if (playOnStart)
		{
			ParseAndApply();
		}
	}

	private void Update()
	{
		if (!isParsed || shuffleChars.Count == 0)
		{
			return;
		}
		bool flag = false;
		float time = Time.time;
		for (int i = 0; i < shuffleChars.Count; i++)
		{
			ShuffleChar shuffleChar = shuffleChars[i];
			if (time < shuffleChar.nextSwap)
			{
				continue;
			}
			shuffleChar.nextSwap = time + Mathf.Max(0.0001f, shuffleChar.swapInterval);
			if (UnityEngine.Random.value < shuffleChar.returnChance)
			{
				if (workingChars[shuffleChar.index] != shuffleChar.original)
				{
					workingChars[shuffleChar.index] = shuffleChar.original;
					flag = true;
				}
			}
			else if (!string.IsNullOrEmpty(randomPool))
			{
				char c = randomPool[UnityEngine.Random.Range(0, randomPool.Length)];
				int num = 0;
				while (c == workingChars[shuffleChar.index] && num++ < 4)
				{
					c = randomPool[UnityEngine.Random.Range(0, randomPool.Length)];
				}
				if (workingChars[shuffleChar.index] != c)
				{
					workingChars[shuffleChar.index] = c;
					flag = true;
				}
			}
		}
		if (flag)
		{
			if (animCore == null)
			{
				tmp.text = new string(workingChars);
			}
			else
			{
				animCore.SwapText(new string(workingChars));
			}
		}
	}

	public void ParseAndApply()
	{
		if (!tmp)
		{
			tmp = GetComponent<TMP_Text>();
		}
		string text = tmp.text ?? string.Empty;
		shuffleChars.Clear();
		displayBuilder.Length = 0;
		int num = 0;
		while (num < text.Length)
		{
			int num2 = text.IndexOf("[randomchar", num, StringComparison.OrdinalIgnoreCase);
			if (num2 < 0)
			{
				displayBuilder.Append(text, num, text.Length - num);
				break;
			}
			if (num2 > num)
			{
				displayBuilder.Append(text, num, num2 - num);
			}
			int num3 = text.IndexOf(']', num2);
			if (num3 < 0)
			{
				break;
			}
			string text2 = text.Substring(num2, num3 - num2 + 1);
			float b = ExtractFloatAttribute(text2, "s", defaultSwapSeconds);
			float returnChance = Mathf.Clamp01(ExtractFloatAttribute(text2, "c", defaultReturnChance));
			int num4 = num3 + 1;
			int num5 = text.IndexOf("[/randomchar]", num4, StringComparison.OrdinalIgnoreCase);
			if (num5 < 0)
			{
				displayBuilder.Append(text, num2, num3 - num2 + 1);
				num = num3 + 1;
				continue;
			}
			string text3 = text.Substring(num4, num5 - num4);
			int length = displayBuilder.Length;
			displayBuilder.Append(text3);
			int length2 = text3.Length;
			for (int i = 0; i < length2; i++)
			{
				char c = text3[i];
				if (!char.IsWhiteSpace(c) && c != '\r')
				{
					ShuffleChar item = new ShuffleChar
					{
						index = length + i,
						original = c,
						swapInterval = Mathf.Max(0f, b),
						returnChance = returnChance,
						nextSwap = Time.time + UnityEngine.Random.value * Mathf.Max(0.0001f, b)
					};
					shuffleChars.Add(item);
				}
			}
			num = num5 + "[/randomchar]".Length;
		}
		workingChars = displayBuilder.ToString().ToCharArray();
		if (animCore == null)
		{
			tmp.text = new string(workingChars);
		}
		else
		{
			animCore.SwapText(new string(workingChars));
		}
		isParsed = true;
	}

	public void SetTextWithRandomTags(string textWithTags)
	{
		if (!tmp)
		{
			tmp = GetComponent<TMP_Text>();
		}
		if (animCore == null)
		{
			tmp.text = textWithTags ?? string.Empty;
		}
		else
		{
			animCore.SwapText(textWithTags ?? string.Empty);
		}
		ParseAndApply();
	}

	private static float ExtractFloatAttribute(string tag, string name, float defaultValue)
	{
		int num = tag.IndexOf(name, StringComparison.OrdinalIgnoreCase);
		if (num < 0)
		{
			return defaultValue;
		}
		num = tag.IndexOf('=', num);
		if (num < 0)
		{
			return defaultValue;
		}
		for (num++; num < tag.Length && char.IsWhiteSpace(tag[num]); num++)
		{
		}
		if (num >= tag.Length)
		{
			return defaultValue;
		}
		if (tag[num] == '"' || tag[num] == '\'')
		{
			char value = tag[num];
			int num2 = num + 1;
			int num3 = tag.IndexOf(value, num2);
			if (num3 < 0)
			{
				return defaultValue;
			}
			if (float.TryParse(tag.Substring(num2, num3 - num2), NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
			{
				return result;
			}
			return defaultValue;
		}
		int num4 = num;
		int i;
		for (i = num4; i < tag.Length && !char.IsWhiteSpace(tag[i]) && tag[i] != ']'; i++)
		{
		}
		if (float.TryParse(tag.Substring(num4, i - num4), NumberStyles.Float, CultureInfo.InvariantCulture, out var result2))
		{
			return result2;
		}
		return defaultValue;
	}
}
