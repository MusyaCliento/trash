using TMPro;
using UnityEngine;

public class UI_VersionText : MonoBehaviour
{
	public string append;

	private void Awake()
	{
		GetComponent<TMP_Text>().text = DarkMachineFunctions.GetVersionName(append);
	}
}
