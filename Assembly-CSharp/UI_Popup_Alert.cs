using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Popup_Alert : MonoBehaviour
{
	public class PopupData
	{
		public string title;

		public string desc;

		public string leftButtonDesc;

		public string rightButtonDesc;

		public Action leftButtonAction;

		public Action rightButtonAction;
	}

	public TMP_Text titleText;

	public TMP_Text descriptionText;

	public Button leftButton;

	public Button rightButton;

	public TMP_Text leftButtonText;

	public TMP_Text rightButtonText;

	private PopupData popupData;

	public void SetData(PopupData data)
	{
		titleText.text = data.title;
		descriptionText.text = data.desc;
		leftButtonText.text = data.leftButtonDesc;
		rightButtonText.text = data.rightButtonDesc;
		if (data.rightButtonDesc == "")
		{
			rightButton.gameObject.SetActive(value: false);
		}
		if (data.leftButtonDesc == "")
		{
			leftButton.gameObject.SetActive(value: false);
		}
		popupData = data;
	}

	public void PressButton(int i = 0)
	{
		if (i == 0)
		{
			if (popupData.leftButtonAction != null)
			{
				popupData.leftButtonAction();
			}
		}
		else if (popupData.rightButtonAction != null)
		{
			popupData.rightButtonAction();
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
