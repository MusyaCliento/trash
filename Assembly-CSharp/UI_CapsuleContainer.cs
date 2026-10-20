using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CapsuleContainer : MonoBehaviour
{
	public bool showOnEnable = true;

	private List<UI_CapsuleButton> buttons = new List<UI_CapsuleButton>();

	public float showDelay = 0.1f;

	public float showWait = 1f;

	private void OnEnable()
	{
		ShowEffect();
	}

	public void ShowEffect()
	{
		buttons = new List<UI_CapsuleButton>();
		if (showOnEnable)
		{
			buttons.AddRange(GetComponentsInChildren<UI_CapsuleButton>());
			StartCoroutine(ShowButtons());
		}
	}

	private IEnumerator ShowButtons()
	{
		yield return new WaitForSeconds(showWait);
		for (int i = 0; i < buttons.Count; i++)
		{
			if (buttons[i].gameObject.activeSelf)
			{
				buttons[i].Show();
				yield return new WaitForSeconds(showDelay);
			}
		}
	}
}
