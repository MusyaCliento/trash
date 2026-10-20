using UnityEngine;

public class Item_Data_Text_Single : Item_Data_Text
{
	[TextArea(5, 10)]
	public string text;

	public override string GetText()
	{
		return text;
	}
}
