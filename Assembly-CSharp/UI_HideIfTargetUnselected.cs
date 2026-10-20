using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_HideIfTargetUnselected : MonoBehaviour
{
	public Selectable targetSelection;

	private TMP_Text text;

	private Image image;

	private void Start()
	{
		text = GetComponent<TMP_Text>();
		image = GetComponent<Image>();
	}

	private void Update()
	{
		if (targetSelection != null && EventSystem.current.currentSelectedGameObject != targetSelection.gameObject)
		{
			if (image != null)
			{
				image.enabled = false;
			}
			if (text != null)
			{
				text.enabled = false;
			}
		}
		else
		{
			if (image != null)
			{
				image.enabled = true;
			}
			if (text != null)
			{
				text.enabled = true;
			}
		}
	}
}
