using UnityEngine;

public class UI_DisableInteractionOnGamepad : MonoBehaviour
{
	private CanvasGroup group;

	private void Start()
	{
		group = GetComponent<CanvasGroup>();
	}

	private void Update()
	{
		group.interactable = !InputManager.IsGamepad();
	}
}
