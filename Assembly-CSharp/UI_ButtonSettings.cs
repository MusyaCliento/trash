using UnityEngine;
using UnityEngine.UI;

public class UI_ButtonSettings : MonoBehaviour
{
	private Button button;

	private void Start()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(OnButtonPress);
	}

	private void OnButtonPress()
	{
		button.Select();
	}
}
