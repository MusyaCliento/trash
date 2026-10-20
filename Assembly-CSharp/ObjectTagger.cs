using System.Collections.Generic;
using UnityEngine;

public sealed class ObjectTagger : MonoBehaviour
{
	public List<string> tags = new List<string>();

	public bool HasTag(string t)
	{
		return tags.Contains(t);
	}

	public bool HasTagInList(string[] strings)
	{
		foreach (string item in strings)
		{
			if (tags.Contains(item))
			{
				return true;
			}
		}
		return false;
	}

	public void AddTag(string tag)
	{
		if (!tags.Contains(tag))
		{
			tags.Add(tag);
		}
	}

	public void RemoveTag(string tag)
	{
		if (tags.Contains(tag))
		{
			tags.Remove(tag);
		}
	}

	public static bool TagCheck(GameObject checkObject, string[] triggerTags)
	{
		ObjectTagger component = checkObject.GetComponent<ObjectTagger>();
		if (component != null && component.HasTagInList(triggerTags))
		{
			return true;
		}
		return false;
	}

	public static bool TagCheck(GameObject checkObject, string tag)
	{
		return TagCheck(checkObject, new string[1] { tag });
	}

	public static bool TagCheck(GameObject checkObject, string[] triggerTags, out ObjectTagger tagger)
	{
		tagger = checkObject.GetComponent<ObjectTagger>();
		if (tagger != null && tagger.HasTagInList(triggerTags))
		{
			return true;
		}
		return false;
	}
}
