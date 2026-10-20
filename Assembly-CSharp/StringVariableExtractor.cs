using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class StringVariableExtractor
{
	public class StringVariable
	{
		public string name;

		public string value;
	}

	public static List<StringVariable> ExtractVariables(string text)
	{
		List<StringVariable> list = new List<StringVariable>();
		foreach (Match item in new Regex("<(\\w+)=(.*?)>").Matches(text))
		{
			StringVariable stringVariable = new StringVariable();
			stringVariable.name = item.Groups[1].Value;
			stringVariable.value = item.Groups[2].Value;
			list.Add(stringVariable);
		}
		return list;
	}
}
