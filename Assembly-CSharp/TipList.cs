using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tip List", menuName = "White Knuckle/Other/Tip List")]
public class TipList : ScriptableObject
{
	public List<string> tips;

	public string GetTip()
	{
		return tips[Random.Range(0, tips.Count)];
	}
}
