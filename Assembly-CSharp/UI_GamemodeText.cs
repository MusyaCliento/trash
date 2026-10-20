using TMPro;
using UnityEngine;

public class UI_GamemodeText : MonoBehaviour
{
	public string append = "";

	private TMP_Text text;

	public bool includeGamemodeOptions = true;

	private void Awake()
	{
		text = GetComponent<TMP_Text>();
	}

	private void OnEnable()
	{
		Refresh();
	}

	public void Refresh()
	{
		if (CL_GameManager.gamemode != null)
		{
			text.text = append + CL_GameManager.GetGamemodeName(includeGamemodeOptions);
		}
		else
		{
			text.text = "";
		}
	}
}
