using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class App_TrainingSectorControls_Toggle : MonoBehaviour
{
	public string id;

	private Toggle toggle;

	public string toggleAudio = "os:click";

	public App_TrainingSectorControls app;

	private CanvasGroup group;

	private TMP_Text text;

	private void Awake()
	{
		toggle = GetComponent<Toggle>();
		toggle.onValueChanged.AddListener(delegate
		{
			SendState();
		});
		app.AddToggle(this);
		group = base.gameObject.AddComponent<CanvasGroup>();
		text = GetComponentInChildren<TMP_Text>();
	}

	public void SendState()
	{
		OS_Manager.soundPlayer.PlaySound(toggleAudio);
		app.ToggleSetting(id, toggle.isOn);
	}

	public Toggle GetToggle()
	{
		return toggle;
	}

	public void SetInteractable(bool b)
	{
		toggle.interactable = b;
		text.color = (b ? Color.white : Color.grey);
	}
}
