using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Cosmetic_Info
{
	public string id;

	public string tag;

	public List<string> flags;

	public string cosmeticName;

	public string author;

	public string description;

	public string credits;

	public int compatibilityVersion;

	public string unlock;

	public List<string> datapacks;

	public Sprite cardBackground;

	public Sprite cardForeground;

	public string cosmeticParent;
}
