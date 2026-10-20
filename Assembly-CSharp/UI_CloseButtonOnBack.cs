using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI_CloseButtonOnBack : MonoBehaviour
{
	private Button button;

	private bool active;

	private void Start()
	{
		button = GetComponent<Button>();
	}

	private void OnEnable()
	{
		active = true;
	}

	private void OnDisable()
	{
		active = false;
	}

	private void Update()
	{
		if (active && button.IsInteractable() && (InputManager.GetButton("UIBackButton").Down || Input.GetKeyDown(KeyCode.Escape)))
		{
			StartCoroutine(FrameWait());
		}
		IEnumerator FrameWait()
		{
			yield return null;
			button.onClick.Invoke();
		}
	}
}
