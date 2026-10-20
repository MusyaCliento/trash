using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_FirstSelect : MonoBehaviour
{
	private Selectable button;

	public bool gamepadOnly;

	public bool forceSelection;

	private void OnEnable()
	{
		button = GetComponent<Selectable>();
		if ((!gamepadOnly || InputManager.IsGamepad()) && button.IsInteractable())
		{
			button.Select();
		}
	}

	private void Update()
	{
		if (button.IsInteractable() && (!gamepadOnly || InputManager.IsGamepad()) && (InputManager.GetVector("Navigate").Down || forceSelection))
		{
			if (EventSystem.current.currentSelectedGameObject == null)
			{
				button.Select();
			}
			else if (!EventSystem.current.currentSelectedGameObject.activeInHierarchy || !EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().IsInteractable())
			{
				button.Select();
			}
		}
	}
}
