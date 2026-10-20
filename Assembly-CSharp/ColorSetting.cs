using UnityEngine;

[CreateAssetMenu(fileName = "New WKColor", menuName = "White Knuckle/Settings/WKColor")]
public class ColorSetting : ScriptableObject
{
	public enum ColorType
	{
		red = 0,
		yellow = 1
	}

	public string title;

	public Color red = DarkMachineCrayons.red;

	public Color yellow = DarkMachineCrayons.yellow;

	public Color GetColor(ColorType colorType)
	{
		return colorType switch
		{
			ColorType.red => red, 
			ColorType.yellow => yellow, 
			_ => Color.white, 
		};
	}
}
