using UnityEngine;
using UnityEngine.UI;

public class OS_ButtonAudio : MonoBehaviour
{
	public string pressAudio = "os:app-button";

	private Button button;

	private void Awake()
	{
		button = GetComponent<Button>();
		if (!(button == null))
		{
			button.onClick.AddListener(PressButton);
		}
	}

	public void PressButton()
	{
		OS_Manager.soundPlayer.PlaySound(pressAudio);
	}
}
