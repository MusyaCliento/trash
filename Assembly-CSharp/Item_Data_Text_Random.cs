using System.Collections.Generic;
using UnityEngine;

public class Item_Data_Text_Random : Item_Data_Text
{
	[TextArea(5, 10)]
	public List<string> strings;

	[HideInInspector]
	public string selectedString;

	public override string GetText()
	{
		if (selectedString == null || selectedString == "")
		{
			selectedString = strings[Random.Range(0, strings.Count)];
		}
		return selectedString;
	}
}
