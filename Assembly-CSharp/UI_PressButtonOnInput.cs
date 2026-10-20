using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_PressButtonOnInput : MonoBehaviour
{
	public string input;

	private Button button;

	public bool disableButtonIfGamepad;

	public Selectable requiredParentSelected;

	private bool wasInteractable;

	public bool assumeInteractable;

	private void Start()
	{
		button = GetComponent<Button>();
		wasInteractable = button.interactable;
	}

	private void Update()
	{
		if (disableButtonIfGamepad && InputManager.IsGamepad() && !button.interactable)
		{
			button.interactable = wasInteractable;
		}
		if (assumeInteractable)
		{
			button.interactable = true;
		}
		bool flag = true;
		if (requiredParentSelected != null && EventSystem.current.currentSelectedGameObject != requiredParentSelected.gameObject)
		{
			flag = false;
		}
		if (button.IsInteractable() && InputManager.GetButton(input).Down && flag)
		{
			StartCoroutine(FrameWait());
		}
		if (disableButtonIfGamepad && InputManager.IsGamepad())
		{
			wasInteractable = button.interactable;
			button.interactable = false;
		}
		else if (wasInteractable && button.interactable)
		{
			button.interactable = true;
		}
		IEnumerator FrameWait()
		{
			yield return null;
			button.onClick.Invoke();
		}
	}
}
