using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WKColorSet_New", menuName = "White Knuckle/Settings/WKColorSet")]
public class ColorSettingsSet : ScriptableObject
{
	public List<ColorSetting> colorSettings;
}
