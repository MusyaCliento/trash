using TMPro;
using UnityEngine;

public class App_SavePage_DiskCard : MonoBehaviour
{
	public TMP_Text text;

	internal void Initialize(string diskName, int capacity)
	{
		text.text = $"{diskName}\nCapacity: {capacity}x";
	}
}
