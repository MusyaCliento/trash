using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SessionEventModule_TextEvent : SessionEventModule
{
	public enum ScrawlType
	{
		header = 0,
		ascentHeader = 1,
		highscoreHeader = 2,
		tip = 3,
		descriptor = 4
	}

	public ScrawlType type;

	public bool randomLines;

	[TextArea]
	public string playScrawl;

	[TextArea]
	public List<string> lines;

	public override void Initialize(SessionEvent s)
	{
		base.Initialize(s);
		Activate();
	}

	public void Play()
	{
		string text = playScrawl;
		if (randomLines)
		{
			text = lines[UnityEngine.Random.Range(0, lines.Count)];
		}
		if (text != "")
		{
			if (type == ScrawlType.header)
			{
				CL_UIManager.instance.header.ShowText(text);
			}
			else if (type == ScrawlType.ascentHeader)
			{
				CL_UIManager.instance.ascentHeader.ShowText(text);
			}
			else if (type == ScrawlType.highscoreHeader)
			{
				CL_UIManager.instance.highscoreHeader.ShowText(text);
			}
			else if (type == ScrawlType.tip)
			{
				CL_UIManager.instance.tipHeader.ShowText(text);
			}
		}
	}

	public override void Activate()
	{
		base.Activate();
		Play();
	}
}
